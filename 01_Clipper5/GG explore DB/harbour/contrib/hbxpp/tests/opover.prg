/*
 * $Id: opover.prg 18414 2012-10-31 13:04:01Z vszakats $
 */

#require "hbxpp"

#include "hbxpp.ch"

PROCEDURE Main()

   LOCAL cString := "ABC"

   ? cString[ 2 ]   // ------>   'B'

   RETURN
