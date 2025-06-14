/*
 * $Id: hterrsys.prg 18773 2013-01-24 14:20:54Z vszakats $
 */

/*
 * Harbour Project source code:
 *    HTML output conversion
 *
 * Copyright 2000 Manos Aspradakis <maspr@otenet.gr>
 * www - http://harbour-project.org
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version, with one exception:
 *
 * The exception is that if you link the Harbour Runtime Library (HRL)
 * and/or the Harbour Virtual Machine (HVM) with other files to produce
 * an executable, this does not by itself cause the resulting executable
 * to be covered by the GNU General Public License. Your use of that
 * executable is in no way restricted on account of linking the HRL
 * and/or HVM code into it.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA (or visit
 * their web site at http://www.gnu.org/).
 *
 */

/*
 * The following parts are Copyright of the individual authors.
 * www - http://harbour-project.org
 *
 * Copyright 2000 Luiz Rafael Culik <culik@sl.conex.net>
 *    Porting this library to Harbour
 *
 * See doc/license.txt for licensing terms.
 *
 */

#include "error.ch"
#include "cgi.ch"

#define DEF_ERR_HEADER "Date : " + DToC( Date() ) + "<br />" + "Time : " + Time() + "<br />"

// put messages to STDERR
#command ? <list,...>   =>  ?? Chr( 13 ) + Chr( 10 ) ; ?? <list>
#command ?? <list,...>  =>  OutErr( <list> )

REQUEST HARDCR
REQUEST MEMOWRIT

STATIC s_bFixCorrupt
STATIC s_cErrFooter  := " "


/***
* DefError()
*/

#if 0

STATIC FUNCTION xhb_cgi_DefError( e )

   LOCAL i
   LOCAL cMessage   := ""
   LOCAL cErrString := ""
   LOCAL nH         := iif( HtmlPageHandle() == NIL, 0, HtmlPageHandle() )

   // by default, division by zero yields zero
   IF e:genCode == EG_ZERODIV
      RETURN 0
   ENDIF

   IF e:genCode == EG_CORRUPTION
      IF HB_ISBLOCK( s_bFixCorrupt )
         Eval( s_bFixCorrupt, e )
         RETURN .F.
      ELSE
         RETURN .F.
      ENDIF
   ENDIF

   // for network open error, set NetErr() and subsystem default
   IF e:genCode == EG_OPEN .AND. ( e:osCode == 32 .OR. e:osCode == 5 ) ;
         .AND. e:canDefault

      NetErr( .T. )
      RETURN .F.                    // NOTE

   ENDIF

   // for lock error during APPEND BLANK, set NetErr() and subsystem default
   IF e:genCode == EG_APPENDLOCK .AND. e:canDefault

      NetErr( .T. )
      RETURN .F.                    // NOTE

   ENDIF

   // build error message
   cMessage += ErrorMessage( e )

   // display message and traceback
   IF ! Empty( e:osCode )
      cMessage += " (DOS Error   : " + hb_ntos( e:osCode ) + ")"
   ENDIF

   // RESET System //

   cErrString := CRLF() + "</td></tr></table>" + CRLF()
   cErrString += '<table bgcolor="white" border CellPadding=1 CellSpacing=1 cols=2 width=80%>'

   cErrString += '<tr><td bgcolor="black" align="center">'
   cErrstring += '<font face = "verdana" size ="5" color="white">' + CRLF()
   cErrString += "<b>ERROR REPORT</b>"
   cErrString += "</td></tr>"

   cErrString += '<tr><td bgcolor="blue">'
   cErrstring += '<font face = "verdana" size ="2" color="white">' + CRLF()
   cErrString += DEF_ERR_HEADER
   cErrString += "</td></tr>"

   cErrString += '<tr><td bgcolor="red">'
   cErrstring += '<font face ="verdana" size ="2" color="white">' + CRLF()
   cErrString += '<em>' + cMessage + '</em>'

   cErrString += '</td></tr><tr><td bgcolor="cyan">' + CRLF()
   cErrstring += '<font face ="verdana" size ="2" color="black">' + CRLF()
   cErrString += "ERRORCODE...... :" + hb_ntos( e:GenCode ) + "<br />" + CRLF()
   cErrString += "SUBSYSTEM..... :" + e:SubSystem + "<br />" + CRLF()
   cErrString += "DESCRIPTION...:" + e:Description + "<br />" + CRLF()
   cErrString += "OPERATION......:" + e:Operation + "<br />" + CRLF()
   cErrString += "FILENAME........ :" + e:FileName + "<br />" + CRLF()
   cErrString += "TRIES............. :" + hb_ntos( e:Tries ) + CRLF()

   cErrString += '</td></tr>'
   cErrString += '<tr><td bgcolor="red">'
   cErrstring += '<font face ="verdana" size ="2" color="white">' + CRLF()
   cErrstring += '<em>'

   i := 2

   DO WHILE ! Empty( ProcName( i ) )

      cErrString += "Called from " + RTrim( ProcName( i ) ) + ;
         "(" + hb_ntos( ProcLine( i ) ) + ") <br />" + CRLF()

      i++
   ENDDO

   cErrstring += '</em>'
   cErrString += '</td></tr>'
   cErrString += '<tr><td bgcolor="black">'
   cErrstring += '<font face ="verdana" size ="2" color="white">' + CRLF()
   cErrstring += "Extra Notes..."

   cErrString += "</td>" + CRLF() + "</tr>" + CRLF() + "</table>" + CRLF()
   FWrite( nH, "<br />" + cErrString + CRLF() )
   MemoWrit( "Error.Log", HardCR( cErrString ) + CRLF() + ;
      HardCR( MemoRead( "Error.Log" ) ) )

   FWrite( nH, "</td>" + CRLF() + "</tr>" + CRLF() + "</table>" + CRLF() )

   HtmlJSCmd( nH, 'Alert("There was an error processing your request:\n' + ;
      'Look at the bottom of this page for\n' + ;
      'error description and parameters...");' )
   FWrite( nH, "</font>" + CRLF() + "</body></html>" + CRLF() )

   CLOSE ALL

   ErrorLevel( 1 )
   QUIT

   RETURN .F.

#endif

FUNCTION SetCorruptFunc( bFunc )

   IF HB_ISBLOCK( bFunc )
      s_bFixCorrupt := bFunc
   ENDIF

   RETURN s_bFixCorrupt

FUNCTION SetErrorFooter()

   RETURN s_cErrFooter

/***
* ErrorMessage()
*/

#if 0

STATIC FUNCTION ErrorMessage( e )

   LOCAL cMessage := ""

   // start error message
   cMessage += iif( e:severity > ES_WARNING, "Error ", "Warning " )

   // add subsystem name if available
   IF HB_ISSTRING( e:subsystem )
      cMessage += e:subsystem()
   ELSE
      cMessage += "???"
   ENDIF

   // add subsystem's error code if available
   IF HB_ISNUMERIC( e:subCode )
      cMessage += "/" + hb_ntos( e:subCode )
   ELSE
      cMessage += "/???"
   ENDIF

   // add error description if available
   IF HB_ISSTRING( e:description )
      cMessage += "<br />  " + e:description
   ENDIF

   // add either filename or operation
   IF ! Empty( e:filename )
      cMessage += ": " + e:filename

   ELSEIF ! Empty( e:operation )
      cMessage += ": " + e:operation

   ENDIF
   cMessage += CRLF()

   RETURN cMessage

#endif
