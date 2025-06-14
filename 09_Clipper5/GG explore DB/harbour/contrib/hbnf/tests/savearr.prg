/*
 * $Id: savearr.prg 18598 2012-11-17 22:20:13Z vszakats $
 */

#require "hbnf"

PROCEDURE Main()

   LOCAL aArray := { ;
      { "Invoice 1", hb_SToD( "19910415" ), 1234.32, .T. }, ;
      { "Invoice 2", Date(), 234.98, .F. }, ;
      { "Invoice 3", Date() + 1, 0, .T. } }, aSave
   LOCAL nErrorCode := 0

   SET DATE ANSI
   SET CENTURY OFF /* TOFIX: RTEs with ON */

   ft_SaveArr( aArray, "invoice.dat", @nErrorCode )
   IF nErrorCode == 0
      CLS
      DispArray( aArray )
      aSave := ft_RestArr( "invoice.dat", @nErrorCode )
      IF nErrorCode == 0
         DispArray( aSave )
      ELSE
         ? "Error restoring array"
      ENDIF
   ELSE
      ? "Error writing array"
   ENDIF

   RETURN

FUNCTION DispArray( aTest )

   LOCAL nk

   FOR nk := 1 TO Len( aTest )
      ? aTest[ nk, 1 ]
      ?? "  "
      ?? DToC( aTest[ nk, 2 ] )
      ?? "  "
      ?? Str( aTest[ nk, 3 ] )
      ?? "  "
      ?? iif( aTest[ nk, 4 ], "true", "false" )
   NEXT

   RETURN NIL
