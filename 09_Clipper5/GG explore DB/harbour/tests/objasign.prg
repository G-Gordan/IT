/*
 * $Id: objasign.prg 18199 2012-10-02 18:38:03Z vszakats $
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

   ? "Direct reference : ", o:x

   o:x := "I am a data"
   ? "Assign text      : ", o:x

   o:x := 4
   ? "Assign 4         : ", o:x

   ? "Post increment   : ", o:x++
   ? "After            : ", o:x
   ? "Pre decrement    : ", --o:x
   ? "After            : ", o:x

   o:x += 2
   ? "Plus 2           : ", o:x

   o:x -= 3
   ? "Minus 3          : ", o:x

   o:x *= 3
   ? "Times 3          : ", o:x

   o:x /= 1.5
   ? "Divide by 1.5    : ", o:x

   o:x %= 4
   ? "Modulus 4        : ", o:x

   o:x ^= 3
   ? "To the power 3   : ", o:x

   ? "Global stack"
   ? hb_ValToExp(  __dbgVMStkGList() )
   ? "Statics"
   ? hb_ValToExp(  __dbgVMVarSList() )

   RETURN

FUNCTION TNumber()                              // Very simple class

   STATIC oNumber

   IF oNumber == NIL
      oNumber := HBClass():New( "TNumber" )

      oNumber:AddData( "x" )
      oNumber:AddMethod( "New", @New() )
      oNumber:Create()
   ENDIF

   RETURN oNumber:Instance()

STATIC FUNCTION New()

   LOCAL self := QSelf()

   ::x := 1

   RETURN self
