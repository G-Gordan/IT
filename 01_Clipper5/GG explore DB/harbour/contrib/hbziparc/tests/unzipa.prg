/*
 * $Id: unzipa.prg 18703 2012-11-29 12:56:43Z vszakats $
 */

#require "hbziparc"

PROCEDURE Main( cZip, ... )

   ? hb_UnzipFile( cZip, NIL, .F., NIL, NIL, hb_AParams(), {| x, y | QOut( Str( x / y * 100, 3 ) + "%" ) } )

   RETURN
