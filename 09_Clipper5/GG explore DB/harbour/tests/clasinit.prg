/*
 * $Id: clasinit.prg 18199 2012-10-02 18:38:03Z vszakats $
 */

// Using Harbour Class HBClass

PROCEDURE Main()

   LOCAL oForm := TForm():New()
   LOCAL oSecond

   ? "What's the default oForm and calculate area"
   ? hb_ValToExp(  oForm )
   ? oForm:CalcArea()
   ? "Set nTop to 5 and recalculate"
   oForm:nTop := 5
   ? hb_ValToExp(  oForm )
   ? oForm:CalcArea()

   ? "Create a new instance and calculate area"
   oSecond := TForm():New()
   ? hb_ValToExp(  oSecond )
   ? oSecond:CalcArea()

   RETURN

FUNCTION TForm()

   STATIC oClass

   IF oClass == NIL
      oClass := HBClass():New( "TFORM" )    // starts a new class definition

      oClass:AddData( "cName" )           // define this class objects datas
      oClass:AddData( "nTop"   , 10 )
      oClass:AddData( "nLeft"  , 10 )
      oClass:AddData( "nBottom", 20 )
      oClass:AddData( "nRight" , 40 )

      oClass:AddMethod( "New",  @New() )  // define this class objects methods
      oClass:AddMethod( "Show", @Show() )
      oClass:AddInline( "CalcArea", ;
         {| self | ( ::nRight - ::nLeft ) * ( ::nBottom - ::nTop ) } )

      oClass:Create()                     // builds this class
   ENDIF

   RETURN oClass:Instance()                  // builds an object of this class

STATIC FUNCTION New()

   LOCAL Self := QSelf()

   RETURN Self

STATIC FUNCTION Show()

   LOCAL Self := QSelf()

   ? "lets show a form from here :-)"

   RETURN NIL
