/*
 * $Id: nwuid.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main()

   LOCAL x, cUid

   ? "I am: [" + ft_NWUID() + "]"
   ? "---------------------"

   FOR x := 1 TO 100
      cUid := ft_NWUID( x )
      IF ! Empty( cUid )
         ? Str( x, 3 ) + Space( 3 ) + cUid
      ENDIF
   NEXT

   RETURN
