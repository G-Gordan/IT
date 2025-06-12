/*
 * $Id: seconds.prg 18580 2012-11-16 15:23:20Z vszakats $
 */

/* Test Seconds() */
/* Harbour Project source code
   http://harbour-project.org/
   Donated to the public domain on 2001-03-08 by David G. Holm <dholm@jsd-llc.com>
*/

PROCEDURE Main( cParam )

   LOCAL n, limit := 10

   CLS

   IF ! Empty( cParam )
      limit := Val( cParam )
   ENDIF
   ? Seconds()
   FOR n := 1 TO limit
      IF Empty( cParam )
         ? "Pause:"
         Inkey( 0 )
      ENDIF
      ? Seconds()
   NEXT

   RETURN
