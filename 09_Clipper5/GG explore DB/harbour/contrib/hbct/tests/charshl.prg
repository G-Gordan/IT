/*
 * $Id: charshl.prg 18716 2012-12-03 13:52:22Z vszakats $
 */

/*
 * Harbour Project source code:
 *   Test CT3 function CharShl()
 *
 * Copyright 2001 IntTec GmbH, Neunlindenstr 32, 79106 Freiburg, Germany
 *        Author: Martin Vogel <vogel@inttec.de>
 *
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

#ifdef __HARBOUR__
#require "hbct"
#else
#define hb_ntos( n ) LTrim( Str( n ) )
#endif

PROCEDURE Main()

   LOCAL ni, cStr

   ctinit()

   ? "Begin test of CharShl()"
   ?

   // simple tests
   ? "Simple tests:"
   ? '  CharShl(Chr(1)+Chr(2)+Chr(4)+Chr(8)+Chr(16)+Chr(32)+'
   ? '           Chr(64)+Chr(128), 3) == '
   ? '  Chr(8)+Chr(16)+Chr(32)+Chr(64)+Chr(128)+Chr(0)+Chr(0)+Chr(0) ? -->'

   ? '  '
   cStr := CharShl( Chr( 1 ) + Chr( 2 ) + Chr( 4 ) + Chr( 8 ) + Chr( 16 ) + Chr( 32 ) + Chr( 64 ) + Chr( 128 ), 3 )
   FOR ni := 1 TO Len( cStr )
      ?? "Chr(" + hb_ntos( Asc( SubStr( cStr, ni, 1 ) ) ) + ")"
      IF ni < Len( cStr )
         ?? "+"
      ENDIF
   NEXT
   ?

   ? "End test of CharShl()"
   ?

   ctexit()

   RETURN
