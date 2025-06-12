/*
 * $Id: nwlstat.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main()

   ? "Logical station: " + Str( ft_NWLStat() )

   RETURN
