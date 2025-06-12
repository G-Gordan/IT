/*
 * $Id: altdtest.prg 17835 2012-07-18 13:41:31Z vszakats $
 */

// Testing AltD()
// Notice you have to compile it using /b

PROCEDURE Main()

   AltD( 1 )   // Enables the debugger. Press F5 to go

   Alert( "debugger enabled" )

   AltD()      // Invokes the debugger

   Alert( "debugger invoked" )

   RETURN
