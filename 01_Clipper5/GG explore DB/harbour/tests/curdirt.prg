/*
 * $Id: curdirt.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

PROCEDURE Main()

   ? CurDir()
   ? CurDir( "C" )
   ? CurDir( "C:" )
   ? CurDir( "D:" )
   ? CurDir( "A" )

   RETURN
