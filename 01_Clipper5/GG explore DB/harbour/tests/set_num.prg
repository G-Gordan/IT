/*
 * $Id: set_num.prg 18682 2012-11-28 00:09:22Z vszakats $
 */

// Testing SET

PROCEDURE Main()

   LOCAL n

   FOR n := 1 TO _SET_COUNT
      ? Set( n )
   NEXT

   RETURN
