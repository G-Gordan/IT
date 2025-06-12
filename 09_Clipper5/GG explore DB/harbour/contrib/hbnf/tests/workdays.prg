/*
 * $Id: workdays.prg 18598 2012-11-17 22:20:13Z vszakats $
 */

#require "hbnf"

PROCEDURE Main( cStart, cStop )

   ? ft_Workdays( hb_SToD( cStart ), hb_SToD( cStop ) )

   RETURN
