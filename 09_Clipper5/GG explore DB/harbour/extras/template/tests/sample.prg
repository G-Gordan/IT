/*
 * $Id: sample.prg 18730 2012-12-06 13:50:22Z vszakats $
 */

#require "hbtpl"

PROCEDURE Main()

   /* Using public API */

   ? hbtpl_MyPublicFunction()
   ? hbtpl_MyPublicFunction_In_C()

   /* Using public constant */

   ? HBTPL_MYCONSTANT

   /* Using public command */

   HBTPL_PRINT "Hello"

   RETURN
