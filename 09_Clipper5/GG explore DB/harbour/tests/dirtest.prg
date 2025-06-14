/*
 * $Id: dirtest.prg 18414 2012-10-31 13:04:01Z vszakats $
 */

// directory test

#include "directry.ch"

PROCEDURE Main( filespec, attribs, cshort )

   LOCAL aDir
   LOCAL x, lShort := .F.

   IF ! cshort == NIL .AND. ( Upper( cShort ) == "TRUE" .OR. Upper( cShort ) == ".T." )
      lShort := .T.
   ENDIF

// aDir := ASort( Directory( filespec, attribs, lShort ),,, {| x, y | Upper( x[ F_NAME ] ) < Upper( y[ F_NAME ] ) } )
   aDir := Directory( filespec, attribs, lShort )

   SET CENTURY ON

   FOR x := 1 TO Len( aDir )
      ? ;
         PadR( aDir[ x, F_NAME ], 20 ), "|", ;
         Transform( aDir[ x, F_SIZE ], "9,999,999,999" ), "|", ;
         aDir[ x, F_DATE ], "|", ;
         aDir[ x, F_TIME ], "|", ;
         aDir[ x, F_ATTR ]
   NEXT

   RETURN
