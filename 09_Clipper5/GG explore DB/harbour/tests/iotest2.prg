/*
 * $Id: iotest2.prg 18197 2012-10-02 11:59:22Z vszakats $
 */

// Testing Harbour file io features
// using freadstr instead of fread

PROCEDURE Main()

   LOCAL h
   LOCAL cstr := " "

   h := FCreate( "test.txt" )
   ? "create handle", h

   FWrite( h, "This test worked if you can see this" )

   FClose( h )

   h := FOpen( "test.txt" )
   ? "open handle", h
   ?
   /* try to read what is there */
   DO WHILE Asc( cstr ) != 0
      cstr := FReadStr( h, 1 )
      ?? cstr
   ENDDO

   FClose( h )

   RETURN
