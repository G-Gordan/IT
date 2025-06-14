/*
 * $Id: objarr.prg 18199 2012-10-02 18:38:03Z vszakats $
 */

//
// Object Array syntax test
//
// Written by Eddie Runia <eddie@runia.com>
// www - http://harbour-project.org
//
// Placed in the public domain
//

PROCEDURE Main()

   LOCAL o := TNumber():New()

   ? "Direct reference : ", hb_ValToStr( o:x )

   o:x[ 1 ]     := "I am a data"
   o:Get()[ 2 ] := "I am a method"
   ? "Assign text      : ", hb_ValToStr( o:x )

   o:x[ 1 ]     := 4
   o:Get()[ 2 ] := 4
   ? "Assign 4         : ", hb_ValToStr( o:x )

   ? "Post increment   : ", o:x[ 1 ]++ , o:Get()[ 2 ]++
   ? "After            : ", o:x[ 1 ]   , o:Get()[ 2 ]
   ? "Pre decrement    : ", --o:x[ 1 ] , --o:Get()[ 2 ]
   ? "After            : ", o:x[ 1 ]   , o:Get()[ 2 ]

   o:x[ 1 ]     += 2
   o:Get()[ 2 ] += 2
   ? "Plus 2           : ", hb_ValToStr( o:x )

   o:x[ 1 ]     -= 3
   o:Get()[ 2 ] -= 3
   ? "Minus 3          : ", hb_ValToStr( o:x )

   o:x[ 1 ]     *= 3
   o:Get()[ 2 ] *= 3
   ? "Times 3          : ", hb_ValToStr( o:x )

   o:x[ 1 ]     /= 1.5
   o:Get()[ 2 ] /= 1.5
   ? "Divide by 1.5    : ", hb_ValToStr( o:x )

   o:x[ 1 ]     %= 4
   o:Get()[ 2 ] %= 4
   ? "Modulus 4        : ", hb_ValToStr( o:x )

   o:x[ 1 ]     ^= 3
   o:Get()[ 2 ] ^= 3
   ? "To the power 3   : ", hb_ValToStr( o:x )

   ? "Global stack"
   ? hb_ValToExp(  __dbgVMStkGList() )
   ? "Statics"
   ? hb_ValToExp(  __dbgVMVarSList() )

   RETURN

FUNCTION TNumber()                              // Very simple class

   STATIC oNumber

   IF oNumber == NIL
      oNumber := HBClass():New( "TNumber" )

      oNumber:AddData  ( "x"   )
      oNumber:AddMethod( "Get", @Get() )
      oNumber:AddMethod( "New", @New() )
      oNumber:Create()
   ENDIF

   RETURN oNumber:Instance()

STATIC FUNCTION New()

   LOCAL self := QSelf()

   ::x := { 1, 1 }

   RETURN self

STATIC FUNCTION Get()

   LOCAL self := QSelf()

   RETURN ::x
