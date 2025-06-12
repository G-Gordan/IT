/*
 * $Id: calling.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

// Calling different PRG functions

PROCEDURE Main()

   SecondOne()

   DO Fourth WITH "from Fourth() function"    // Testing the old fashion DO ...

   ? "Ok, back to Main()"

   RETURN

FUNCTION SecondOne()

   ? "Ok, this is from Second() function call"

   Third()

   RETURN NIL

FUNCTION Third()

   ? "Ok, this is from Third() function call"

   RETURN NIL

FUNCTION Fourth( cText )

   ? cText

   RETURN NIL
