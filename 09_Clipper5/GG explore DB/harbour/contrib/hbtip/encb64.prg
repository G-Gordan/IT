/*
 * $Id: encb64.prg 18716 2012-12-03 13:52:22Z vszakats $
 */

/*
 * xHarbour Project source code:
 * TIP Class oriented Internet protocol library
 *
 * Copyright 2003 Giancarlo Niccolai <gian@niccolai.ws>
 * www - http://harbour-project.org
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

CREATE CLASS TIPEncoderBase64 FROM TIPEncoder

   // Set this to .T. to enable RFC 2068 (HTTP/1.1) exception to
   // RFC 2045 (MIME) base64 format. This exception consists in
   // not applying CRLF after each 76 output bytes.
   VAR bHttpExcept

   METHOD New()      Constructor
   METHOD Encode( cData )
   METHOD Decode( cData )

ENDCLASS

METHOD New() CLASS TIPEncoderBase64

   ::cName := "Base64"
   ::bHttpExcept := .F.

   RETURN Self

METHOD Encode( cData ) CLASS TIPEncoderBase64
   RETURN tip_Base64Encode( cData, iif( ::bHttpExcept, NIL, 72 ), Chr( 13 ) + Chr( 10 ) )

METHOD Decode( cData ) CLASS TIPEncoderBase64
   RETURN hb_base64Decode( cData )

FUNCTION tip_Base64Encode( cBinary, nLineLength, cCRLF )

   LOCAL cTextIn := hb_base64Encode( cBinary )

   LOCAL cText
   LOCAL tmp

   IF ! HB_ISNUMERIC( nLineLength )
      RETURN cTextIn
   ENDIF

   hb_default( @cCRLF, hb_eol() )

   cText := ""
   FOR tmp := 1 TO Len( cTextIn ) STEP nLineLength
      cText += SubStr( cTextIn, tmp, nLineLength ) + cCRLF
   NEXT

   RETURN cText
