/*
 * $Id: test.prg 18214 2012-10-04 02:28:44Z vszakats $
 */

PROCEDURE Main()

   LOCAL s := " " + Chr( 0 ) + "  mab  " + Chr( 0 ) + " "

   StrDump( s )
   ? s

   ? '"' + LTrim( s ) + '"'
   ? '"' + RTrim( s ) + '"'
   ? '"' + AllTrim( s ) + '"'

   RETURN

STATIC PROCEDURE StrDump( s )
   LOCAL tmp
   FOR EACH tmp IN s
      ? Asc( tmp )
   NEXT
   RETURN
