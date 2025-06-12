/*
 * $Id: testerro.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

// Testing Harbour Error system

PROCEDURE Main()

   LOCAL n

   ? "We are running and now an error will raise"

   n++      // an error should raise here

   HB_SYMBOL_UNUSED( n )

   RETURN
