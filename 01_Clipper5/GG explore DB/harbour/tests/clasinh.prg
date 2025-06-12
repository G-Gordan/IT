/*
 * $Id: clasinh.prg 18773 2013-01-24 14:20:54Z vszakats $
 */

#include "hbclass.ch"

PROCEDURE Main()

   LOCAL oObject, oBase

   oObject := TAnyClass():New()
   oBase := TClassBase():New()

   HB_SYMBOL_UNUSED( oObject )
   HB_SYMBOL_UNUSED( oBase )

   RETURN

CREATE CLASS TClassBase

   METHOD New()
   METHOD Test() INLINE Alert( "Test" )

ENDCLASS

METHOD New() CLASS TClassBase

   RETURN Self

CREATE CLASS TAnyClass FROM TClassBase

   METHOD New()

ENDCLASS

METHOD New() CLASS TAnyClass

   ::super:New()
   ::super:Test()

   RETURN Self
