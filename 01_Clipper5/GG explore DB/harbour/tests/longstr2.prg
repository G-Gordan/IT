//NOTEST - You'll want to test this with the output redirected to a file!
/*
 * $Id: longstr2.prg 18182 2012-09-30 21:12:01Z vszakats $
 */

PROCEDURE Main()

   LOCAL short := "1234567890"
   LOCAL i, long, very_long

   long := short
   FOR i := 1 TO 12
      long += long
   NEXT

   very_long := long
   FOR i := 1 TO 5
      very_long += very_long
   NEXT

   OutErr( Len( short ), Len( long ), Len( very_long ) )
   QOut  ( Len( short ), Len( long ), Len( very_long ) )

   OutStd( hb_eol() )
   OutStd( Len( short ), Len( long ), Len( very_long ) )

   OutStd( hb_eol() )
   OutStd( hb_eol() )
   OutStd( short )

   OutStd( hb_eol() )
   OutStd( hb_eol() )
   OutStd( long )

   OutStd( hb_eol() )
   OutStd( hb_eol() )
   OutStd( very_long )

   RETURN
