/*
 * $Id: access1.prg 18526 2012-11-12 01:10:56Z vszakats $
 */

#require "rddado"

#include "adordd.ch"

REQUEST ADORDD

PROCEDURE Main()

   SET DATE ANSI
   SET CENTURY ON

   USE ( hb_DirBase() + "test.mdb" ) VIA "ADORDD" TABLE "Table1"

   CLS
   Browse()

   USE

   RETURN
