/*
 * $Id: regextst.prg 18726 2012-12-05 16:38:11Z vszakats $
 */

// Test for regular expression functions -
// This allows to use a fine tune regex to use them in programs
// Giancarlo Niccolai

#include "inkey.ch"

PROCEDURE Main()

   LOCAL pCompiled
   LOCAL cRegex
   LOCAL cSentence
   LOCAL nRow, oErr
   LOCAL aMatch, cMatch

   LOCAL GetList := {}

   SET CONFIRM ON

   CLS

   @ 2, 15 SAY "Regular expression test"

   @ 4, 5 SAY "Insert regular expression(s) and strings to test for."
   @ 5, 5 SAY "Press <Esc> to exit"

   cRegex := Space( 60 )
   cSentence := Space( 120 )
   DO WHILE LastKey() != K_ESC

      @ 8, 5 SAY "REGEX : " GET cRegex PICTURE "@S30"
      @ 9, 5 SAY "PHRASE: " GET cSentence PICTURE "@S60"
      READ
      IF LastKey() != K_ESC

         @ 12, 5 CLEAR TO 24, 79

         BEGIN SEQUENCE WITH {| oErr | Break( oErr ) }
            pCompiled := hb_regexComp( RTrim( cRegex ) )
         RECOVER USING oErr
            @ 12, 5 SAY "Invalid REGEX expression"
            LOOP
         END SEQUENCE

         aMatch := hb_regex( pCompiled, RTrim( cSentence ) )
         IF aMatch != NIL
            @ 12, 5 SAY "MATCHES:"
            nRow := 13
            FOR EACH cMatch IN aMatch
               @ nRow++, 5 SAY ">" + cMatch
            NEXT
         ELSE
            @ 12, 5 SAY "No matches"
         ENDIF
      ENDIF
   ENDDO

   CLS

   RETURN
