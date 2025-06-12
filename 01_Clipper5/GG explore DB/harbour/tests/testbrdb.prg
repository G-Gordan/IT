/*
 * $Id: testbrdb.prg 17834 2012-07-18 12:00:10Z vszakats $
 */

// Testing Browse()

PROCEDURE Main()

   LOCAL cColor

   cColor := SetColor( "W+/B" )
   CLS

   USE test
   Browse()

   SetColor( cColor )
   CLS

   RETURN
