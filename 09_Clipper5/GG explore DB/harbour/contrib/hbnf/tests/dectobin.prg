/*
 * $Id: dectobin.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main()

   LOCAL X

   FOR X := 1 TO 255
      ? ft_Dec2Bin( x )
   NEXT

   RETURN
