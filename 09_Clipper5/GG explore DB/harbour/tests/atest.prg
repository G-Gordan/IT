/*
 * $Id: atest.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

// releasing arrays test

PROCEDURE Main()

   LOCAL a := { 1 }

   a[ 1 ] := a
   a[ 1 ] := NIL

   ? "The array will try to be released now..."

   RETURN
