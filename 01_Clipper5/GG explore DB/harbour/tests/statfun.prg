/*
 * $Id: statfun.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

// Testing a static function call

PROCEDURE Main()

   ? "From Main()"

   SecondOne()

   ? "From Main() again"

   RETURN

STATIC FUNCTION SecondOne()

   ? "From Second()"

   RETURN NIL
