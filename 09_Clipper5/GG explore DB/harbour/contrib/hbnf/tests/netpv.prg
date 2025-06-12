/*
 * $Id: netpv.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main()

   ? ft_NetPV( 10000, 10, { 10000, 15000, 16000, 17000 } )

   RETURN
