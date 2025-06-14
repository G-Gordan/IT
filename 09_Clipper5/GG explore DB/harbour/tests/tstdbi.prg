/*
 * $Id: tstdbi.prg 18583 2012-11-16 16:53:48Z vszakats $
 */

#ifndef __HARBOUR__
   #xtranslate hb_eol() => ( Chr( 13 ) + Chr( 10 ) )
#endif

PROCEDURE Main()

   LOCAL i
   LOCAL cStr := ""

   USE "test" NEW

   FOR i := 1 TO 100
      cStr += Str( i ) + " " + xToStr( dbInfo( i ) ) + hb_eol()
   NEXT
   cStr += Str(  101 ) + " " + xToStr( dbInfo(  101 ) ) + hb_eol()
   cStr += Str(  101 ) + " " + xToStr( dbInfo(  101, 1 ) ) + hb_eol()
   cStr += Str(  101 ) + " " + xToStr( dbInfo(  101, 2 ) ) + hb_eol()
   cStr += Str(  102 ) + " " + xToStr( dbInfo(  102 ) ) + hb_eol()
   cStr += Str(  101 ) + " " + xToStr( dbInfo(  102, 1 ) ) + hb_eol()
   cStr += Str(  101 ) + " " + xToStr( dbInfo(  102, 2 ) ) + hb_eol()
   cStr += Str(  999 ) + " " + xToStr( dbInfo(  999 ) ) + hb_eol()
   cStr += Str( 1000 ) + " " + xToStr( dbInfo( 1000 ) ) + hb_eol()

#ifdef __HARBOUR__
   MemoWrit( "dbihb.txt", cStr )
#else
   MemoWrit( "dbicl.txt", cStr )
#endif

   ? dbRecordInfo( 1 )
   ? dbRecordInfo( 2 )
   ? dbRecordInfo( 3 )
   ? dbRecordInfo( 4 )
   ? dbRecordInfo( 5 )

   ? dbFieldInfo( 1, 1 )
   ? dbFieldInfo( 2, 1 )
   ? dbFieldInfo( 3, 1 )
   ? dbFieldInfo( 4, 1 )

   RETURN

STATIC FUNCTION xToStr( xValue )

   SWITCH ValType( xValue )
   CASE "N"
      RETURN Str( xValue )
   CASE "D"
      RETURN DToC( xValue )
   CASE "C"
   CASE "M"
      RETURN xValue
   CASE "L"
      RETURN iif( xValue, ".T.", ".F." )
   CASE "A"
      RETURN "A" + hb_ntos( Len( xValue ) )
   CASE "U"
      RETURN "NIL"
   ENDSWITCH

   RETURN ""
