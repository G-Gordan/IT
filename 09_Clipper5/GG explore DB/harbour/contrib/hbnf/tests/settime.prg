/*
 * $Id: settime.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main( cTime )

   cTime := iif( cTime == NIL, Time(), cTime )
   ? "Setting time to: " + cTime  + "... "
   ft_SetTime( cTime )
   ? "Time is now: " + Time()

   RETURN
