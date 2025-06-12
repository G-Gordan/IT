/*
 * $Id: testcp.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "xhb"

PROCEDURE Main()

   xhb_CopyFile( __FILE__, "testcp.bak", {| x | QOut( x ) } )

   RETURN
