/*
 * $Id: testhbf.prg 18580 2012-11-16 15:23:20Z vszakats $
 */

/*
test program for hb_f*()
harbour clones for nanfor's ft_f*()
inplementation of :
  * hb_FUse()
  * hb_FSkip()
  * hb_FEof()
  * hb_FRecNo()
  * hb_FReadLn()
  * hb_FLastRec()
  * hb_FGoto()
  * hb_FGoTop()
  * hb_FGoBottom()
*/

#require "hbmisc"

PROCEDURE Main()

   // open a text file here
   IF hb_FUse( __FILE__, 0 ) > 1

      DO WHILE ! hb_FEof()
         ? "line " + Str( hb_FRecNo(), 2 ) + " " + hb_FReadLn()
         hb_FSkip( 1 )
      ENDDO
      ?
      my_goto( 18 )
      my_goto( 2 )

      hb_FGoBottom()
      ?
      ? "after hb_FGoBottom() now in line # " + hb_ntos( hb_FRecNo() )

      hb_FGoTop()
      ?
      ? "after hb_FGoTop() now in line # " + hb_ntos( hb_FRecNo() )

      ?
      ? "hb_FLastRec() = " + hb_ntos( hb_FLastRec() )

      // close the file
      hb_FUse()
   ENDIF

   RETURN

STATIC PROCEDURE my_goto( n_go )

   hb_FGoto( n_go )
   ?
   ? "after hb_FGoto(" + hb_ntos( n_go ) + ")"
   ? "line " + hb_ntos( hb_FRecNo() ) + " is " + LTrim( hb_FReadLn() )

   RETURN
