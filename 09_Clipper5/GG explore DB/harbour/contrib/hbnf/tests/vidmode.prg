/*
 * $Id: vidmode.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main( cMode )

   ft_SetMode( Val( cMode ) )
   ? "Video mode is: " + Str( ft_GetMode() )

   RETURN
