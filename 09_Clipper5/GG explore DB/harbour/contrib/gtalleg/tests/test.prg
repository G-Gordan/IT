/*
 * $Id: test.prg 18719 2012-12-03 14:42:48Z vszakats $
 */

#require "gtalleg"

PROCEDURE Main()

#if defined( __HBSCRIPT__HBSHELL )
   hbshell_gtSelect( "GTALLEG" )
#endif

   CLS
   Alert( "Hello world!" )

   RETURN
