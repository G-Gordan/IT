/*
 * $Id: gcd.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main( cNum1, cNum2 )

   ? ft_GCD( Val( cNum1 ), Val( cNum2 ) )

   RETURN
