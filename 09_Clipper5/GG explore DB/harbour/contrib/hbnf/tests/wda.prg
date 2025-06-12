/*
 * $Id: wda.prg 18598 2012-11-17 22:20:13Z vszakats $
 */

#require "hbnf"

PROCEDURE Main( cDate, cDays )

   LOCAL nDays := ft_AddWkDy( hb_SToD( cDate ), Val( cDays ) )

   ? "Num days to add: " + Str( nDays )
   ? "New date:        " + DToC( hb_SToD( cDate ) + nDays )

   RETURN
