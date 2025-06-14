/*
 * $Id: say.prg 18208 2012-10-03 20:56:06Z vszakats $
 */

// Tests @ SAY with and without PICTURE clauses

PROCEDURE Main()

   CLS
   SET CENTURY ON
   @ 2, 39 TO 7, 39 DOUBLE
   @ 0, 0 SAY "Testing @ SAY with and without PICTURE clauses"
   @ 0, 60 SAY Date()
   SET CENTURY OFF
   @ 2, 1  SAY -1.25
   @ 2, 41 SAY -1.25   PICTURE "@( 99,999.99"
   @ 3, 1  SAY  1.25   PICTURE "@( 9,999.99"
   @ 3, 41 SAY  1.25   PICTURE "@( $9,999.99"
   @ 5, 1  SAY Date()
   @ 5, 41 SAY Date()  PICTURE "@E"
   @ 7, 1  SAY "Hello"
   @ 7, 41 SAY "Hello" PICTURE "@!"

   RETURN
