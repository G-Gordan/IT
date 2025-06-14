/*
 * $Id: testprn2.prg 18700 2012-11-29 12:19:10Z vszakats $
 */

#require "hbwin"

PROCEDURE Main()

   LOCAL nPrn := 1
   LOCAL cFileName := Space( 40 )
   LOCAL GetList := {}

   LOCAL aPrn := win_printerList()

   CLS

   IF Empty( aPrn )
      Alert( "No printers installed - Cannot continue" )
   ELSE
      DO WHILE nPrn != 0
         CLS
         @ 0, 0 SAY "win_PrintFileRaw() test program. Choose a printer to test"
         @ 1, 0 SAY "File name:" GET cFileName PICT "@!K"
         READ
         @ 2, 0 TO MaxRow(), MaxCol()
         nPrn := AChoice( 3, 1, MaxRow() - 1, MaxCol() - 1, aPrn, .T.,, nPrn )
         IF nPrn != 0
            PrnTest( aPrn[ nPrn ], cFileName )
         ENDIF
      ENDDO
   ENDIF

   RETURN

STATIC PROCEDURE PrnTest( cPrinter, cFileName )

   IF Empty( cFileName )
      hb_MemoWrit( cFileName := "_hbtest.prn", "Hello World!" + Chr( 12 ) )
   ENDIF

   Alert( "win_PrintFileRaw() returned: " + hb_ntos( win_PrintFileRaw( cPrinter, cFileName, "testing raw printing" ) ) )

   RETURN
