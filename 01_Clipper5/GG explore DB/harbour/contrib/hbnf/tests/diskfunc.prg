/*
 * $Id: diskfunc.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main( cDrv )

   ? "Disk size:   " + Str( ft_DskSize( cDrv ) )
   ? "Free bytes:  " + Str( ft_DskFree( cDrv ) )

   RETURN
