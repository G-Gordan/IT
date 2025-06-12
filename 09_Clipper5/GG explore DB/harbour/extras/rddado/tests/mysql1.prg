/*
 * $Id: mysql1.prg 18526 2012-11-12 01:10:56Z vszakats $
 */

#require "rddado"

#include "adordd.ch"

REQUEST ADORDD

PROCEDURE Main()

   USE test00 VIA "ADORDD" TABLE "ACCOUNTS" MYSQL ;
      FROM "www.freesql.org" USER "myuser" PASSWORD "mypass"

   Browse()

   USE

   RETURN
