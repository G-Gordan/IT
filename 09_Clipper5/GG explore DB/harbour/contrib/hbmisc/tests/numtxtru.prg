/*
 * $Id: numtxtru.prg 18414 2012-10-31 13:04:01Z vszakats $
 */

#require "hbmisc"

REQUEST HB_CODEPAGE_UTF8EX

PROCEDURE Main()

   CLS

   hb_cdpSelect( "UTF8EX" )
   hb_SetTermCP( "UTF8EX" )

   ? "Press ESC to break"
   ? "Russian"
   Test( "ru" )
   ? "Ukrainian"
   Test( "uk" )
   ? "Belorussian"
   Test( "be" )

   RETURN

PROCEDURE Test( cLang )

   LOCAL nTemp

   FOR nTemp := 1 TO 1000000000
      OutStd( ;
         PadR( MnyToTxtRU( nTemp + ( nTemp % 100 ) * 0.01, cLang, , 3 ), 100 ) + " " + ;
         PadR( NumToTxtRU( nTemp, cLang, , .T. ), 100 ) + " " + ;
         PadR( DateToTxtRU( Date() + nTemp, cLang, .T. ), 50 ) + hb_eol() )
      IF nTemp % 1000 == 0
         ? nTemp
      ENDIF
      IF nTemp % 10000 == 0
         IF Inkey() == 27
            EXIT
         ENDIF
      ENDIF
   NEXT

   RETURN
