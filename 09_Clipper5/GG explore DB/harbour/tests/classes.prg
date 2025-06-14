/*
 * $Id: classes.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

// Using Harbour Class HBClass

PROCEDURE Main()

   LOCAL oForm := TForm():New()

   ? oForm:ClassName()

   oForm:Show()

   RETURN

FUNCTION TForm()

   STATIC oClass

   IF oClass == NIL
      oClass := HBClass():New( "TFORM" )    // starts a new class definition

      oClass:AddData( "cName" )           // define this class objects datas
      oClass:AddData( "nTop" )
      oClass:AddData( "nLeft" )
      oClass:AddData( "nBottom" )
      oClass:AddData( "nRight" )

      oClass:AddMethod( "New",  @New() )  // define this class objects methods
      oClass:AddMethod( "Show", @Show() )

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

STATIC FUNCTION Show()

   LOCAL Self := QSelf()

   ? "lets show a form from here :-)"

   RETURN NIL
