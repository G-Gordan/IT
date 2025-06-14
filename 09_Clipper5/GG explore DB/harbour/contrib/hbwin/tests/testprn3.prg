/*
 * $Id: testprn3.prg 18615 2012-11-20 15:39:43Z vszakats $
 */

/*
 * Harbour Project source code:
 *
 * Copyright 2009 Viktor Szakats (harbour syenar.net)
 * www - http://harbour-project.org
 *
 */

#require "hbwin"

#include "simpleio.ch"

PROCEDURE Main()

   Dump( win_printerList( .F., .F. ) )
   Dump( win_printerList( .F., .T. ) )
   Dump( win_printerList( .T., .F. ) )
   Dump( win_printerList( .T., .T. ) )

   ? "WIN_PRINTERGETDEFAULT:", ">" + win_printerGetDefault() + "<"
   ? "WIN_PRINTERSTATUS:", win_printerStatus()

   RETURN

STATIC PROCEDURE Dump( a )

   LOCAL b, c

   ? "=================="
   FOR EACH b IN a
      ?
      IF HB_ISARRAY( b )
         FOR EACH c IN b
            ?? c:__enumIndex(), c
            IF c:__enumIndex() == 2
               ?? ">>" + win_printerPortToName( c ) + "<<",  "|>>" + win_printerPortToName( c, .T. ) + "<<|"
            ENDIF
            ?
         NEXT
         ? "-----"
      ELSE
         ? b, win_printerExists( b ), win_printerStatus( b )
      ENDIF
   NEXT

   RETURN
