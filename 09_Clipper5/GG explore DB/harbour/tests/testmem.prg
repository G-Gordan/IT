/*
 * $Id: testmem.prg 18182 2012-09-30 21:12:01Z vszakats $
 */

// Testing memory release

PROCEDURE Main()

   LOCAL a, b

   a := "Hello"
   b := 2

   HB_SYMBOL_UNUSED( a )
   HB_SYMBOL_UNUSED( b )

   RETURN
