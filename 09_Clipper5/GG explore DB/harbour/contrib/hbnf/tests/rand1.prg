/*
 * $Id: rand1.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

// Write 100 random numbers from 1 to 100 to stdout.
// Run it multiple times and redirect output to a file
// to check it

PROCEDURE Main()

   LOCAL x

   FOR x := 1 TO 100
      ? Int( ft_Rand1( 100 ) )
   NEXT

   RETURN
