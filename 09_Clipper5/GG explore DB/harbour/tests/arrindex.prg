/*
 * $Id: arrindex.prg 18414 2012-10-31 13:04:01Z vszakats $
 */

PROCEDURE Main()

   LOCAL a, b, c

   a := { {, } }

   a[ 1, 2 ] := [Hello]

   c := { 1 }

   b := a[ c[ 1 ] ][ Val( [ 2 ] ) ]

   ? b

   RETURN
