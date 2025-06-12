/*
 * $Id: sleep.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

// Invoke by running SLEEP 1.0 to sleep 1.0 seconds

PROCEDURE Main( nSleep )

   ? "Time is now: " + Time()
   ft_Sleep( Val( nSleep ) )
   ? "Time is now: " + Time()

   RETURN
