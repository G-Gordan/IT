/*
 * $Id: test.prg 18779 2013-01-24 22:14:39Z vszakats $
 */

#require "hbhpdf"

PROCEDURE Main()

   ? hb_HPDF_GetErrorString()
   ? hb_HPDF_GetErrorString( NIL )
   ? hb_HPDF_GetErrorString( "a" )
   ? hb_HPDF_GetErrorString( {} )
   ? hb_HPDF_GetErrorString( 100 )
   ? hb_HPDF_GetErrorString( HPDF_ARRAY_ITEM_UNEXPECTED_TYPE )

   RETURN
