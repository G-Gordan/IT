/*
 * $Id: while.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

// while loop test

PROCEDURE Main()

   LOCAL x := 0

   DO WHILE x++ < 1000
      ? x
   ENDDO

   RETURN
