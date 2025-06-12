/*
 * $Id: d2e.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main( cNum, cPrec )

   __defaultNIL( @cPrec, "6" )

   ? ft_D2E( Val( cNum ), Val( cPrec ) )

   RETURN
