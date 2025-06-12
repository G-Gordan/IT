/*
 * $Id: cmphello.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

//
// Compile Hello
//
// This program compiles hello.prg
//
// Written by Eddie Runia <eddie@runia.com>
// www - http://harbour-project.org
//
// Placed in the public domain
//

PROCEDURE Main()

   ? "About to compile hello.prg"
   ?
   hb_run( ".." + hb_ps() + "bin" + hb_ps() + "harbour hello.prg -gh" )
   ? "Finished compiling"

   RETURN
