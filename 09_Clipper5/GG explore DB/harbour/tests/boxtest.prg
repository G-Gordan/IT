/*
 * $Id: boxtest.prg 18583 2012-11-16 16:53:48Z vszakats $
 */

PROCEDURE Main()

   CLS

   @ 0, 0, 15, 50 BOX "         " COLOR "W+/B"
   MESSAGE( '@ 0, 0, 15, 50 BOX "         " COLOR "W+/B"' )

   __Box( 1, 1, 5, 7 )
   MESSAGE( '__Box( 1, 1, 5, 7 )' )

   __Box( 1, 1, 5, 7, "X" )
   MESSAGE( '__Box( 1, 1, 5, 7, "X" )' )

   __BoxD( 2, 2, 6, 8 )
   MESSAGE( '__BoxD( 2, 2, 6, 8 )' )

   __BoxS( 3, 3, 7, 9 )
   MESSAGE( '__BoxS( 3, 3, 7, 9 )' )

   RETURN

PROCEDURE MESSAGE( cText )

   @ 16, 0 CLEAR TO 16, 79
   @ 16, 0 SAY cText
   OutStd( Chr( 7 ) )
   Inkey( 0 )

   RETURN
