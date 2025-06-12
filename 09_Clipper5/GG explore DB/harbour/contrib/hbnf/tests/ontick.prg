/*
 * $Id: ontick.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

/*
 * Harbour Project source code:
 *
 * Copyright 2011 Viktor Szakats (harbour syenar.net)
 * www - http://harbour-project.org
 *
 */

#require "hbnf"

PROCEDURE Main()

   CLS

   ft_OnTick( {|| OutStd( hb_MilliSeconds(), hb_eol() ) } )

   Inkey( 0 )

   ft_OnTick( {|| OutStd( hb_MilliSeconds(), hb_eol() ) }, 18 )

   Inkey( 0 )

   ft_OnTick()

   Inkey( 0 )

   RETURN
