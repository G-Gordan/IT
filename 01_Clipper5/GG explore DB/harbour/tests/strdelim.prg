/*
 * $Id: strdelim.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

PROCEDURE Main()

   LOCAL aArray := { { NIL } }

   aArray[ 1 /*first*/ ][ 1 /* second */ ] := [Hello]

   ? aArray[ 1 ][ 1 ]

   ? 'World "Peace[!]"'

   ? "Harbour 'Power[!]'"

   ? [King 'Clipper "!"']

   RETURN
