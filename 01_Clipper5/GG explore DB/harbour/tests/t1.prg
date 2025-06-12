/*
 * $Id: t1.prg 18323 2012-10-15 09:03:33Z vszakats $
 */

// while loop test

PROCEDURE Main()

   LOCAL i := 0
   LOCAL cb := {|| QOut( "test" ) }

   WHILE i < 1000
      ? i
      Eval( cb )
      i++
   ENDDO

   RETURN
