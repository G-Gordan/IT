/*
 * $Id: dbevalts.prg 18414 2012-10-31 13:04:01Z vszakats $
 */

PROCEDURE Main()

   LOCAL nCount

   USE test

   dbGoto( 4 )
   ? RecNo()
   COUNT TO nCount
   ? RecNo(), nCount
   COUNT TO nCount NEXT 10
   ? RecNo(), nCount

   RETURN
