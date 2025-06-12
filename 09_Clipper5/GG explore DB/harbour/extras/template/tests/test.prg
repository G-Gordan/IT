/*
 * $Id: test.prg 18730 2012-12-06 13:50:22Z vszakats $
 */

#require "hbtpl"
#require "hbtest"

PROCEDURE Main()

   /* Testing public API */

   HBTEST hbtpl_MyPublicFunction()      IS "It works"
   HBTEST hbtpl_MyPublicFunction_In_C() IS "It works from C"

   /* Testing public constant */

   HBTEST HBTPL_MYCONSTANT              IS 100

   RETURN
