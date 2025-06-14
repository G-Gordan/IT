/*
 * $Id: adirtest.prg 18580 2012-11-16 15:23:20Z vszakats $
 */

PROCEDURE Main()

   TestIt( "*.*" )
   TestIt( "\" )
   TestIt( "..\" )
   TestIt( "..\*.*" )

   RETURN

STATIC FUNCTION TestIt( cSpec )

   LOCAL a
   LOCAL a1
   LOCAL a2
   LOCAL a3
   LOCAL a4
   LOCAL a5

// In order to account for documented behavour, this call will ensure
// that ADir() returns the same length array in both cases.
// ie: ADir( cSpec ) could return a different length array than
// ADir( cSpec,,,,,{} )

   a := ADir( cSpec, , , , , {} )

   SET DATE ANSI
   SET CENTURY ON

   a1 := Array( a )
   a2 := Array( a )
   a3 := Array( iif( a >= 1, a - 1, a ) )
   a4 := Array( a )
   a5 := Array( a + 1 )

   OutStd( "--------------------------------------------------------" )
   OutStd( hb_eol() )

   ADir( cSpec, a1, a2, a3, a4, a5 )

   AEval( a1, {| tmp | OutStd( tmp ), OutStd( hb_eol() ) } )
   AEval( a2, {| tmp | OutStd( tmp ), OutStd( hb_eol() ) } )
   AEval( a3, {| tmp | OutStd( tmp ), OutStd( hb_eol() ) } )
   AEval( a4, {| tmp | OutStd( tmp ), OutStd( hb_eol() ) } )
   AEval( a5, {| tmp | OutStd( tmp ), OutStd( hb_eol() ) } )

   ADir( cSpec, 10, "A", NIL, NIL, NIL )

   RETURN NIL
