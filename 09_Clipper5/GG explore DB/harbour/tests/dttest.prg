/*
 * $Id: dttest.prg 18424 2012-11-01 16:35:14Z vszakats $
 */

/*
 * Harbour Project source code:
 *
 * Copyright 2010 Carlos Bacco
 * www - http://harbour-project.org
 *
 */

#include "simpleio.ch"

PROCEDURE Main()

   ? hb_DateTime( 1974 )

   ? " ValType( hb_DateTime() ) =>", ValType( hb_DateTime() )
   ? " Year(    hb_DateTime() ) =>", Year(    hb_DateTime() )
   ? " Month(   hb_DateTime() ) =>", Month(   hb_DateTime() )
   ? " Day(     hb_DateTime() ) =>", Day(     hb_DateTime() )
   ?

   ? " ValType( hb_DateTime( 1974, 5, 31 ) ) =>", ValType( hb_DateTime( 1974, 5, 31 ) )
   ? " Year(    hb_DateTime( 1974, 5, 31 ) ) =>", Year(    hb_DateTime( 1974, 5, 31 ) )
   ? " Month(   hb_DateTime( 1974, 5, 31 ) ) =>", Month(   hb_DateTime( 1974, 5, 31 ) )
   ? " Day(     hb_DateTime( 1974, 5, 31 ) ) =>", Day(     hb_DateTime( 1974, 5, 31 ) )
   ? " DToC(    hb_DateTime( 1974, 5, 31 ) ) =>", DToC(    hb_DateTime( 1974, 5, 31 ) )
   ?

   ? " ValType( hb_DateTime( 1974, 31, 5, NIL, NIL, NIL ) ) =>", ValType( hb_DateTime( 1974, 31, 5, NIL, NIL, NIL ) )
   ?

   ? " ValType( hb_DateTime( 2001, 10, 13, 18, 42, 16 ) ) =>", ValType( hb_DateTime( 2001, 10, 13, 18, 42, 16 ) )
   ?

   ? " ValType( hb_DateTime( NIL, NIL, NIL, 10, 36, 5 ) )     =>", ValType( hb_DateTime( NIL, NIL, NIL, 10, 36, 5 ) )
   ? "          hb_DateTime( NIL, NIL, NIL, 10, 36, 5 )       =>",          hb_DateTime( NIL, NIL, NIL, 10, 36, 5 )
   ?

   ? " ValType( hb_DateTime( NIL, NIL, NIL, 10, 36, 5, 176 ) ) =>", ValType( hb_DateTime( NIL, NIL, NIL, 10, 36, 5, 176 ) )
   ? "          hb_DateTime( NIL, NIL, NIL, 10, 36, 5, 176 )   =>",          hb_DateTime( NIL, NIL, NIL, 10, 36, 5, 176 )

   ? " ValType( hb_DateTime( 0, 0, 0, 10, 36, 5, 176 ) ) =>", ValType( hb_DateTime( 0, 0, 0, 10, 36, 5, 176 ) )
   ? "          hb_DateTime( 0, 0, 0, 10, 36, 5, 176 )   =>",          hb_DateTime( 0, 0, 0, 10, 36, 5, 176 )

   RETURN
