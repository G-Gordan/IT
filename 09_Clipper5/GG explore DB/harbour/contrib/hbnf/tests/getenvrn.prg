/*
 * $Id: getenvrn.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

#include "simpleio.ch"

PROCEDURE Main()

   LOCAL a
   LOCAL c

   LOCAL tmp

   a := Array( ft_GetE() )
   ft_GetE( @a )
   FOR tmp := 1 TO Len( a )
      ? a[ tmp ]
   NEXT

   ? "-------------------------------------"

   c := ""
   ft_GetE( @c )
   ? c

   RETURN
