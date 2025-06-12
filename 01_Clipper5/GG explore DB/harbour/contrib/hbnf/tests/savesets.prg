/*
 * $Id: savesets.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main()

   LOCAL aSets := ft_SaveSets()

   HB_SYMBOL_UNUSED( aSets )

   Inkey( 0 )

   RETURN
