/*
 * $Id: cgi.prg 18716 2012-12-03 13:52:22Z vszakats $
 */

/*
 * xHarbour Project source code:
 * TIPCgi Class oriented cgi protocol
 *
 * Copyright 2006 Lorenzo Fiorini <lorenzo.fiorini@gmail.com>
 *
 * code from:
 * TIP Class oriented Internet protocol library
 *
 * Copyright 2003 Giancarlo Niccolai <gian@niccolai.ws>
 * www - http://harbour-project.org
 *
 *    CGI Session Manager Class
 *
 * Copyright 2003-2006 Francesco Saverio Giudice <info / at / fsgiudice / dot / com>
 * www - http://www.xharbour.org
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this software; see the file COPYING.txt.  If not, write to
 * the Free Software Foundation, Inc., 59 Temple Place, Suite 330,
 * Boston, MA 02111-1307 USA (or visit the web site http://www.gnu.org/).
 *
 * As a special exception, the Harbour Project gives permission for
 * additional uses of the text contained in its release of Harbour.
 *
 * The exception is that, if you link the Harbour libraries with other
 * files to produce an executable, this does not by itself cause the
 * resulting executable to be covered by the GNU General Public License.
 * Your use of that executable is in no way restricted on account of
 * linking the Harbour library code into it.
 *
 * This exception does not however invalidate any other reasons why
 * the executable file might be covered by the GNU General Public License.
 *
 * This exception applies only to the code released by the Harbour
 * Project under the name Harbour.  If you copy code from other
 * Harbour Project or Free Software Foundation releases into a copy of
 * Harbour, as the General Public License permits, the exception does
 * not apply to the code that you add in this way.  To avoid misleading
 * anyone as to the status of such modified files, you must delete
 * this exception notice from them.
 *
 * If you write modifications of your own for Harbour, it is your choice
 * whether to permit this exception to apply to your modifications.
 * If you do not wish that, delete this exception notice.
 *
 */

#include "hbclass.ch"

#include "fileio.ch"

#define CGI_IN  0
#define CGI_OUT 1
#define _CRLF Chr( 13 ) + Chr( 10 )
#define _BR "<br />"

CREATE CLASS TIPCgi

   VAR HTTP_RAW_POST_DATA

   VAR cCgiHeader
   VAR cHtmlPage
   VAR hGets        INIT { => }
   VAR hPosts       INIT { => }
   VAR hCookies     INIT { => }
   VAR hSession     INIT { => }
   VAR bSavedErrHandler
   VAR cSessionSavePath
   VAR cSID
   VAR cDumpSavePath
   VAR lDumpHtml    INIT .F.
   VAR Cargo

   METHOD New()
   METHOD Header( cValue )
   METHOD Redirect( cUrl )
   METHOD Write( cString )
   METHOD Flush()
   METHOD ErrHandler( xError )

   METHOD StartHtml( hOptions )
   METHOD EndHtml()
   METHOD SaveHtmlPage( cFile )

   METHOD StartSession( cSID )
   METHOD DestroySession( cID )
   METHOD CreateSID( cCRCKey ) INLINE ::cSID := tip_GenerateSID( cCrcKey )
   METHOD CheckCrcSID( cSID, cCRCKey ) INLINE tip_CheckSID( cSID, cCRCKey )
   METHOD SessionEncode()
   METHOD SessionDecode( cData )

ENDCLASS

METHOD New() CLASS TIPCgi

   LOCAL aTemp
   LOCAL aVar
   LOCAL lPost
   LOCAL nCount
   LOCAL nLen
   LOCAL nRead
   LOCAL cTemp

   ::bSavedErrHandler := ErrorBlock( {| e | ::ErrHandler( e ) } )

   ::cCgiHeader := ""
   ::cHtmlPage := ""

   lPost := ( "POST" $ Upper( GetEnv( "REQUEST_METHOD" ) ) )
   IF lPost
      nLen := Val( GetEnv( "CONTENT_LENGTH" ) )
      cTemp := Space( nLen )
      IF ( ( nRead := FRead( CGI_IN, @cTemp, nLen ) ) != nLen )
         ::ErrHandler( "post error read " + hb_ntos( nRead ) + " instead of " + hb_ntos( nLen ) )
      ELSE
         ::HTTP_RAW_POST_DATA := cTemp
         aTemp := hb_ATokens( cTemp, "&" )
         nLen := Len( aTemp )
         IF nLen > 0
            FOR nCount := 1 TO nLen
               aVar := hb_ATokens( aTemp[ nCount ], "=" )
               IF Len( aVar ) == 2
                  ::hPosts[ AllTrim( tip_URLDecode( aVar[ 1 ] ) ) ] := tip_URLDecode( aVar[ 2 ] )
               ENDIF
            NEXT
         ENDIF
      ENDIF
   ELSE
      cTemp := GetEnv( "QUERY_STRING" )
      IF ! Empty( cTemp )
         aTemp := hb_ATokens( cTemp, "&" )
         nLen := Len( aTemp )
         IF nLen > 0
            FOR nCount := 1 TO nLen
               aVar := hb_ATokens( aTemp[ nCount ], "=" )
               IF Len( aVar ) == 2
                  ::hGets[ AllTrim( tip_URLDecode( aVar[ 1 ] ) ) ] := tip_URLDecode( aVar[ 2 ] )
               ENDIF
            NEXT
         ENDIF
      ENDIF
   ENDIF

   cTemp := GetEnv( "HTTP_COOKIE" )
   IF ! Empty( cTemp )
      aTemp := hb_ATokens( cTemp, ";" )
      nLen := Len( aTemp )
      IF nLen > 0
         FOR nCount := 1 TO nLen
            aVar := hb_ATokens( aTemp[ nCount ], "=" )
            IF Len( aVar ) == 2
               ::hCookies[ AllTrim( tip_URLDecode( aVar[ 1 ] ) ) ] := tip_URLDecode( aVar[ 2 ] )
            ENDIF
         NEXT
      ENDIF
   ENDIF

   RETURN Self

METHOD Header( cValue ) CLASS TIPCgi

   IF Empty( cValue )
      ::cCgiHeader += "Content-Type: text/html" + _CRLF
   ELSE
      ::cCgiHeader += cValue + _CRLF
   ENDIF

   RETURN Self

METHOD Redirect( cUrl ) CLASS TIPCgi

   ::cCgiHeader += "Location: " + cUrl + _CRLF

   RETURN Self

METHOD Flush() CLASS TIPCgi

   LOCAL cStream
   LOCAL lRet

   LOCAL nH
   LOCAL cFile

   LOCAL cSID := ::cSID
   LOCAL cSession

   hb_HEval( ::hCookies, {| k, v | ::cCgiHeader += "Set-Cookie: " + k + "=" + v + ";" + _CRLF } )

   cStream := ::cCgiHeader + _CRLF + ::cHtmlPage + _CRLF

   lRet := ( FWrite( CGI_OUT, cStream ) == hb_BLen( cStream ) )

   IF ::lDumpHtml
      IF Empty( ::cDumpSavePath )
         ::cDumpSavePath := hb_DirTemp()
      ENDIF
      IF ( nH := FCreate( ::cDumpSavePath + "dump.html", FC_NORMAL ) ) != F_ERROR
         FWrite( nH, ::cHtmlPage )
      ENDIF
      FClose( nH )
   ENDIF

   ::cCgiHeader := ""
   ::cHtmlPage := ""

   IF ! Empty( cSID )

      cFile := ::cSessionSavePath + "SESSIONID_" + cSID

      IF ( nH := FCreate( cFile, FC_NORMAL ) ) != F_ERROR
         cSession := ::SessionEncode()
         IF FWrite( nH, cSession ) != hb_BLen( cSession )
            ::Write( "ERROR: On writing session file : " + cFile + ", File error : " + hb_CStr( FError() ) )
         ENDIF
         FClose( nH )
      ELSE
         ::Write( "ERROR: On writing session file : " + cFile + ", File error : " + hb_CStr( FError() ) )
      ENDIF
   ENDIF

   RETURN lRet

METHOD SaveHtmlPage( cFile ) CLASS TIPCgi

   LOCAL nFile
   LOCAL lSuccess
   LOCAL cStream

   nFile := FCreate( cFile )

   IF nFile != F_ERROR
      cStream := ::cHtmlPage + _CRLF
      lSuccess := ( FWrite( nFile, cStream ) == hb_BLen( cStream ) )
      FClose( nFile )
   ELSE
      lSuccess := .F.
   ENDIF

   RETURN lSuccess

METHOD StartSession( cSID ) CLASS TIPCgi

   LOCAL nH
   LOCAL cFile
   LOCAL nFileSize
   LOCAL cBuffer

   IF Empty( cSID )

      IF ( nH := hb_HPos( ::hGets, "SESSIONID" ) ) != 0
         cSID := hb_HValueAt( ::hGets, nH )
      ELSEIF ( nH := hb_HPos( ::hPosts, "SESSIONID" ) ) != 0
         cSID := hb_HValueAt( ::hPosts, nH )
      ELSEIF ( nH := hb_HPos( ::hCookies, "SESSIONID" ) ) != 0
         cSID := hb_HValueAt( ::hCookies, nH )
      ENDIF

   ENDIF

   IF Empty( ::cSessionSavePath )
      ::cSessionSavePath := hb_DirTemp()
   ENDIF

   IF ! Empty( cSID )

      ::cSID := cSID

      cFile := ::cSessionSavePath + "SESSIONID_" + cSID

      IF hb_FileExists( cFile )
         IF ( nH := FOpen( cFile, FO_READ ) ) != F_ERROR
            nFileSize := FSeek( nH, 0, FS_END )
            FSeek( nH, 0, FS_SET )
            cBuffer := Space( nFileSize )
            IF ( FRead( nH, @cBuffer, nFileSize ) ) != nFileSize
               ::ErrHandler( "ERROR: On reading session file : " + cFile + ", File error : " + hb_CStr( FError() ) )
            ELSE
               ::SessionDecode( cBuffer )
            ENDIF
            FClose( nH )
         ENDIF
      ELSE
         ::ErrHandler( "ERROR: On opening session file : " + cFile + ", file not exist." )
      ENDIF

   ELSE

      ::CreateSID()
      ::hSession := { => }

   ENDIF

   ::hCookies[ "SESSIONID" ] := ::cSID

   RETURN Self

METHOD SessionEncode() CLASS TIPCgi

   RETURN hb_Serialize( ::hSession )

METHOD SessionDecode( cData ) CLASS TIPCgi

   ::hSession := hb_Deserialize( cData )

   RETURN HB_ISHASH( ::hSession )

METHOD DestroySession( cID ) CLASS TIPCgi

   LOCAL cFile
   LOCAL cSID := ::cSID
   LOCAL lRet

   IF ! Empty( cID )
      cSID := cID
   ENDIF

   IF ! Empty( cSID )

      ::hSession := { => }

      cFile := ::cSessionSavePath + "SESSIONID_" + cSID

      IF !( lRet := ( FErase( cFile ) == 0 ) )
         ::Write( "ERROR: On deleting session file : " + cFile + ", File error : " + hb_CStr( FError() ) )
      ELSE
         ::hCookies[ "SESSIONID" ] := cSID + "; expires= " + tip_DateToGMT( Date() - 1 )
         ::CreateSID()
         cSID := ::cSID
         ::hCookies[ "SESSIONID" ] := cSID
      ENDIF

   ENDIF

   RETURN lRet

METHOD ErrHandler( xError ) CLASS TIPCgi

   LOCAL nCalls
   LOCAL cErrMsg := ""

   cErrMsg += '<table border="1">'

   cErrMsg += "<tr><td>SCRIPT NAME:</td><td>" + GetEnv( "SCRIPT_NAME" ) + "</td></tr>"

   IF HB_ISOBJECT( xError )
      cErrMsg += "<tr><td>CRITICAL ERROR:</td><td>" + xError:Description + "</td></tr>"
      cErrMsg += "<tr><td>OPERATION:</td><td>" + xError:Operation + "</td></tr>"
      cErrMsg += "<tr><td>OS ERROR:</td><td>" + hb_ntos( xError:OsCode ) + " IN " + xError:SubSystem + "/" + hb_ntos( xError:SubCode ) + "</td></tr>"
      cErrMsg += "<tr><td>FILENAME:</td><td>" + Right( xError:FileName, 40 ) + "</td></tr>"
   ELSEIF HB_ISSTRING( xError )
      cErrMsg += "<tr><td>ERROR MESSAGE:</td><td>" + tip_HtmlSpecialChars( xError ) + "</td></tr>"
   ENDIF

   nCalls := 1
   DO WHILE ! Empty( ProcName( nCalls ) )
      cErrMsg += "<tr><td>PROC/LINE:</td><td>" + ProcName( nCalls ) + "/" + hb_ntos( ProcLine( nCalls ) ) + "</td></tr>"
      nCalls++
   ENDDO

   cErrMsg += "</table>"

   ::Write( cErrMsg )

   OutErr( cErrMsg )

   ::Flush()

   QUIT

   RETURN NIL

METHOD Write( cString ) CLASS TIPCgi

   ::cHtmlPage += cString + _CRLF

   RETURN Self

METHOD StartHtml( hOptions ) CLASS TIPCgi

   ::cHtmlPage += ;
      '<?xml version="1.0"' + HtmlOption( hOptions, "encoding", " " ) + "?>" + _CRLF + ;
      '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"' + _CRLF + ;
      '"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">' + _CRLF + ;
      '<html xmlns="http://www.w3.org/1999/xhtml">' + ;
      "<head>" + ;
      HtmlTag( hOptions, "title", "title" ) + ;
      HtmlScript( hOptions ) + ;
      HtmlStyle( hOptions ) + ;
      HtmlLinkRel( hOptions ) + ;
      "</head>" + ;
      "<body " + ;
      HtmlAllOption( hOptions ) + ;
      ">"

   RETURN Self

METHOD EndHtml() CLASS TIPCgi

   ::cHtmlPage += "</body></html>"

   RETURN Self

STATIC FUNCTION HtmlTag( xVal, cKey, cDefault )

   LOCAL cVal := ""

   hb_default( @cDefault, "" )

   IF ! Empty( xVal ) .AND. ! Empty( cKey )
      IF hb_HHasKey( xVal, cKey )
         cVal := hb_HGet( xVal, cKey )
         hb_HDel( xVal, cKey )
      ENDIF
   ENDIF

   IF cVal == ""
      cVal := cDefault
   ENDIF

   IF !( cVal == "" )
      cVal := "<" + cKey + ">" + cVal + "</" + cKey + ">"
   ENDIF

   RETURN cVal

/*
STATIC FUNCTION HtmlAllTag( hTags, cSep )

   LOCAL cVal := ""

   hb_default( @cSep, " " )

   hb_HEval( hTags, {| k | cVal += HtmlTag( hTags, k ) + cSep } )

   RETURN cVal
*/

STATIC FUNCTION HtmlOption( xVal, cKey, cPre, cPost, lScan )

   LOCAL cVal := ""

   IF ! Empty( xVal )
      IF Empty( cKey )
         cVal := xVal
      ELSEIF hb_HHasKey( xVal, cKey )
         cVal := hb_HGet( xVal, cKey )
         IF Empty( lScan )
            hb_HDel( xVal, cKey )
         ENDIF
         cVal := cKey + '="' + cVal + '"'
         IF cPre != NIL
            cVal := cPre + cVal
         ENDIF
         IF cPost != NIL
            cVal := cVal + cPost
         ENDIF
      ENDIF
   ENDIF

   RETURN cVal

STATIC FUNCTION HtmlAllOption( hOptions, cSep )

   LOCAL cVal := ""

   IF ! Empty( hOptions )
      hb_default( @cSep, " " )

      hb_HEval( hOptions, {| k | cVal += HtmlOption( hOptions, k,,, .T. ) + cSep } )
   ENDIF

   RETURN cVal

/*
STATIC FUNCTION HtmlValue( xVal, cKey, cDefault )

   LOCAL cVal := ""

   hb_default( @cDefault, "" )

   IF ! Empty( xVal ) .AND. ! Empty( cKey )
      IF hb_HHasKey( xVal, cKey )
         cVal := hb_HGet( xVal, cKey )
         hb_HDel( xVal, cKey )
      ENDIF
   ENDIF

   IF cVal == ""
      cVal := cDefault
   ENDIF

   RETURN cVal

STATIC FUNCTION HtmlAllValue( hValues, cSep )

   LOCAL cVal := ""

   IF ! Empty( hValues )
      hb_default( @cSep, " " )

      hb_HEval( hValues, {| k | cVal += HtmlValue( hValues, k ) + cSep } )
   ENDIF

   RETURN cVal
*/

STATIC FUNCTION HtmlScript( hVal, cKey )

   LOCAL hTmp
   LOCAL cRet := ""
   LOCAL cVal
   LOCAL nPos
   LOCAL cTmp

   hb_default( @cKey, "script" )

   IF ! Empty( hVal )
      IF ( nPos := hb_HPos( hVal, cKey ) ) != 0
         hTmp := hb_HValueAt( hVal, nPos )
         IF HB_ISHASH( hTmp )
            IF ( nPos := hb_HPos( hTmp, "src" ) ) != 0
               cVal := hb_HValueAt( hTmp, nPos )
               IF HB_ISSTRING( cVal )
                  cVal := { cVal }
               ENDIF
               IF HB_ISARRAY( cVal )
                  cTmp := ""
                  AScan( cVal, {| cFile | cTmp += '<script src="' + cFile + '" type="text/javascript"></script>' + _CRLF } )
                  cRet += cTmp
               ENDIF
            ENDIF
            IF ( nPos := hb_HPos( hTmp, "var" ) ) != 0
               cVal := hb_HValueAt( hTmp, nPos )
               IF HB_ISSTRING( cVal )
                  cVal := { cVal }
               ENDIF
               IF HB_ISARRAY( cVal )
                  cTmp := ""
                  AScan( cVal, {| cVar | cTmp += cVar } )
                  cRet += '<script type="text/javascript">' + _CRLF + "<!--" + _CRLF + cTmp + _CRLF + "-->" + _CRLF + "</script>" + _CRLF
               ENDIF
            ENDIF
         ENDIF
         hb_HDel( hVal, cKey )
      ENDIF
   ENDIF

   RETURN cRet

STATIC FUNCTION HtmlStyle( hVal, cKey )

   LOCAL hTmp
   LOCAL cRet := ""
   LOCAL cVal
   LOCAL nPos
   LOCAL cTmp

   hb_default( @cKey, "style" )

   IF ! Empty( hVal )
      IF ( nPos := hb_HPos( hVal, cKey ) ) != 0
         hTmp := hb_HValueAt( hVal, nPos )
         IF HB_ISHASH( hTmp )
            IF ( nPos := hb_HPos( hTmp, "src" ) ) != 0
               cVal := hb_HValueAt( hTmp, nPos )
               IF HB_ISSTRING( cVal )
                  cVal := { cVal }
               ENDIF
               IF HB_ISARRAY( cVal )
                  cTmp := ""
                  AScan( cVal, {| cFile | cTmp += '<link rel="StyleSheet" href="' + cFile + '" type="text/css">' + _CRLF } )
                  cRet += cTmp
               ENDIF
            ENDIF
            IF ( nPos := hb_HPos( hTmp, "var" ) ) != 0
               cVal := hb_HValueAt( hTmp, nPos )
               IF HB_ISSTRING( cVal )
                  cVal := { cVal }
               ENDIF
               IF HB_ISARRAY( cVal )
                  cTmp := ""
                  AScan( cVal, {| cVar | cTmp += cVar } )
                  cRet += '<style type="text/css">' + _CRLF + "<!--" + _CRLF + cTmp + _CRLF + "-->" + _CRLF + "</style>" + _CRLF
               ENDIF
            ENDIF
         ENDIF
         hb_HDel( hVal, cKey )
      ENDIF
   ENDIF

   RETURN cRet

STATIC FUNCTION HtmlLinkRel( hVal, cKey )

   LOCAL hTmp
   LOCAL cRet := ""
   LOCAL cVal
   LOCAL nPos
   LOCAL cTmp

   hb_default( @cKey, "link" )

   IF ! Empty( hVal )
      IF ( nPos := hb_HPos( hVal, cKey ) ) != 0
         hTmp := hb_HValueAt( hVal, nPos )
         IF HB_ISHASH( hTmp )
            IF ( nPos := hb_HPos( hTmp, "rel" ) ) != 0
               cVal := hb_HValueAt( hTmp, nPos )
               IF HB_ISSTRING( cVal )
                  cVal := { cVal, cVal }
               ENDIF
               IF HB_ISARRAY( cVal )
                  cTmp := ""
                  AScan( cVal, {| aVal | cTmp += '<link rel="' + aVal[ 1 ] + '" href="' + aVal[ 2 ] + '"/>' + _CRLF } )
                  cRet += cTmp
               ENDIF
            ENDIF
         ENDIF
         hb_HDel( hVal, cKey )
      ENDIF
   ENDIF

   RETURN cRet
