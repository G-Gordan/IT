/*
 * $Id: inline.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

//
// Test of inline function
//

PROCEDURE Main()

   LOCAL oForm := TForm():New()

   ? oForm:ClassName()
   oForm:cText := "Let's show a form here :-)"

   oForm:Show()

   RETURN

FUNCTION TForm()

   STATIC oClass

   IF oClass == NIL
      oClass := HBClass():New( "TFORM" )    // starts a new class definition

      oClass:AddData( "cText" )           // define this class objects datas
      oClass:AddData( "nTop" )
      oClass:AddData( "nLeft" )
      oClass:AddData( "nBottom" )
      oClass:AddData( "nRight" )

      oClass:AddMethod( "New",  @New() )  // define this class objects methods
      oClass:AddInline( "Show", {| self | QOut( self:cText ) } )

      oClass:Create()                     // builds this class
   ENDIF

   RETURN oClass:Instance()                  // builds an object of this class

STATIC FUNCTION New()

   LOCAL Self := QSelf()

   ::nTop    := 10
   ::nLeft   := 10
   ::nBottom := 20
   ::nRight  := 40

   RETURN Self
