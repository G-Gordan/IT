/*
 * $Id: uc16_gen.prg 18582 2012-11-16 16:44:37Z vszakats $
 */

/*
 * Harbour Project source code:
 *    code to generate C source with conversion tables between BIG5 and UCS16
 *    using data defined by Unicode, Inc. in BIG5.TXT
 *
 * Copyright 2011 Przemyslaw Czerpak <druzus / at / priv.onet.pl>
 * www - http://harbour-project.org
 *
 */


//#define DO_START_OPT

/* character flags */
#define HB_CDP_DIGIT    0x01
#define HB_CDP_ALPHA    0x02
#define HB_CDP_LOWER    0x04
#define HB_CDP_UPPER    0x08

proc main()
   local cLine, aLine
   local cGenCat
   local nCode, nUpper, nLower, nFlags
   local nUppers, nLowers
   local nMinCh, nMinUp, nMinLo
   local nMaxCh, nMaxUp, nMaxLo
   local nBitCh, nBitUp, nBitLo
   local aLower, aUpper, aFlags
   local cResult
   local aInd, aVal, hVal
   local n, nn

   local nWarning := 2
   local lConvAll := .f.

   aLower := afill( array( 0x10000 ), 0 )
   aUpper := afill( array( 0x10000 ), 0 )
   aFlags := afill( array( 0x10000 ), 0 )
   nMaxCh := nMaxUp := nMaxLo := 0x0000
   nMinCh := nMinUp := nMinLo := 0xFFFF
   nUppers := nLowers := 0

   for each cLine in hb_aTokens( hb_memoRead( "UnicodeData.txt" ), hb_eol() )
      if ! empty( cLine )
         aLine := hb_aTokens( cLine, ";" )
         if len( aLine ) == 15
            nCode   := hb_hexToNum( aLine[ 1 ] )
            if nCode > 0 .and. nCode < 0xFFFF
               nUpper  := hb_hexToNum( aLine[ 13 ] )
               nLower  := hb_hexToNum( aLine[ 14 ] )
               nFlags  := 0
               cGenCat := aLine[ 3 ]
               if "Lu" $ cGenCat
                  nFlags := hb_bitOR( nFlags, HB_CDP_ALPHA, HB_CDP_UPPER )
                  if "Lt" $ cGenCat
                     ? "title + upper, line:", cLine:__enumIndex()
                  endif
               elseif nLower != 0
                  if "Lt" $ cGenCat .or. ! lConvAll
                     nLower := 0
                  elseif nWarning >= 2
                     ? "lower for non upper, line:", cLine:__enumIndex()
                  endif
               endif
               if "Ll" $ cGenCat
                  if "Lt" $ cGenCat
                     ? "title + lower, line:", cLine:__enumIndex()
                  endif
                  nFlags := hb_bitOR( nFlags, HB_CDP_ALPHA, HB_CDP_LOWER )
               elseif nUpper != 0
                  if "Lt" $ cGenCat .or. ! lConvAll
                     nUpper := 0
                  elseif nWarning >= 2
                     ? "upper for non lower, line:", cLine:__enumIndex()
                  endif
               endif
               if nCode >= asc( "0" ) .and. nCode <= asc( "9" )
                  nFlags := hb_bitOR( nFlags, HB_CDP_DIGIT )
               endif
               if nUpper >= 0xFFFF
                  ? "Lower out of range, line:", cLine:__enumIndex()
               endif
               if nLower >= 0xFFFF
                  ? "Upper out of range, line:", cLine:__enumIndex()
               endif
               if nCode > 0 .and. nCode < 0xFFFF
                  if nFlags > 0
                     aFlags[ nCode ] := nFlags
                     if nMaxCh < nCode
                        nMaxCh := nCode
                     endif
                     if nMinCh > nCode
                        nMinCh := nCode
                     endif
                  endif
                  if nUpper > 0
                     nUppers++
                     aUpper[ nCode ] := nUpper
                     if nMaxUp < nCode
                        nMaxUp := nCode
                     endif
                     if nMinUp > nCode
                        nMinUp := nCode
                     endif
                  endif
                  if nLower > 0
                     nLowers++
                     aLower[ nCode ] := nLower
                     if nMaxLo < nCode
                        nMaxLo := nCode
                     endif
                     if nMinLo > nCode
                        nMinLo := nCode
                     endif
                  endif
               endif
            endif
         else
            ? "Wrong line:", cLine:__enumIndex()
         endif
      endif
   next

   ? "uppers#:", nUppers
   ? "min upper:", nMinUp
   ? "max upper:", nMaxUp
   ? "TOUPPER tables."
   ? "raw size:", hb_ntos( ( nMaxUp - nMinUp + 1 ) * 2 )
#ifndef DO_START_OPT
   nMinUp := min( nMinUp, 48 ) // optimal
#endif
   n := min_size16( aUpper, @nMinUp, nMaxUp, @nBitUp )
   ? "minimal size:", hb_ntos( n ), ;
     "for", hb_ntos( hb_bitshift( 1, nBitUp ) ), "byte blocks, (from: " + hb_ntos( nMinUp ) + ")"
   ?

   ? "lowers#:", nLowers
   ? "min lower:", nMinLo
   ? "max lower:", nMaxLo
   ? "TOLOWER tables."
   ? "raw size:", hb_ntos( ( nMaxLo - nMinLo + 1 ) * 2 )
#ifndef DO_START_OPT
   nMinLo := min( nMinLo, 32 ) // optimal
#endif
   n := min_size16( aLower, @nMinLo, nMaxLo, @nBitLo )
   ? "minimal size:", hb_ntos( n ), ;
     "for", hb_ntos( hb_bitshift( 1, nBitLo ) ), "byte blocks, (from: "+hb_ntos( nMinLo ) + ")"
   ?

   ? "min char:", nMinCh
   ? "max char:", nMaxCh
   ? "ATTR tables."
   ? "raw size:", hb_ntos( int( ( nMaxCh - nMinCh + 2 ) / 2 ) )
#ifndef DO_START_OPT
   nMinCh := min( nMinCh, 0 ) // optimal
#endif
   n := min_size04( aFlags, @nMinCh, nMaxCh, @nBitCh )
   ? "minimal size:", hb_ntos( n ), ;
     "for", hb_ntos( hb_bitshift( 1, nBitCh ) ), "byte blocks, (from: " + hb_ntos( nMinCh ) + ")"
   ?
*/


   cResult := ;
      "/*" + hb_eol() + ;
      " * $Id: uc16_gen.prg 18582 2012-11-16 16:44:37Z vszakats $" + hb_eol() + ;
      " */" + hb_eol() + ;
      hb_eol() + ;
      "/*" + hb_eol() + ;
      " * Harbour Project source code:" + hb_eol() + ;
      " *    Unicode character tables" + hb_eol() + ;
      " *    code generated automatically by tests/uc_gen.prg" + hb_eol() + ;
      " *" + hb_eol() + ;
      " * Copyright 2012 Przemyslaw Czerpak <druzus / at / priv.onet.pl>" + hb_eol() + ;
      " * www - http://harbour-project.org" + hb_eol() + ;
      " *" + hb_eol() + ;
      " */" + hb_eol() + ;
      hb_eol()

   cResult += '#include "hbapi.h"' + hb_eol()
   cResult += hb_eol()


   cResult += hb_eol()
   cResult += "#define HB_UCUP_FIRST   0x" + hb_numToHex( nMinUp, 4 ) + hb_eol()
   cResult += "#define HB_UCUP_LAST    0x" + hb_numToHex( nMaxUp, 4 ) + hb_eol()
   cResult += "#define HB_UCUP_BITS    " + hb_ntos( nBitUp ) + hb_eol()
   cResult += hb_eol()

   calc_size16( aUpper, nMinUp, nMaxUp, nBitUp, @hVal, @aInd, @nn )
   aVal := hash_to_array16( hVal )
   check_conv16( aUpper, aInd, aVal, nMinUp,  nMaxUp, nBitUp )

   cResult += array_to_code( aInd, "s_up_idx", nn )
   cResult += hb_eol()
   cResult += array_to_code( aVal, "s_up_val", 2 )
   cResult += hb_eol()
   cResult += index_func16( "s_uc_upper", "s_up_idx", "s_up_val", ;
                            "HB_UCUP_FIRST", "HB_UCUP_LAST", "HB_UCUP_BITS" )


   cResult += hb_eol()
   cResult += "#define HB_UCLO_FIRST   0x" + hb_numToHex( nMinLo, 4 ) + hb_eol()
   cResult += "#define HB_UCLO_LAST    0x" + hb_numToHex( nMaxLo, 4 ) + hb_eol()
   cResult += "#define HB_UCLO_BITS    " + hb_ntos( nBitLo ) + hb_eol()
   cResult += hb_eol()

   calc_size16( aLower, nMinLo, nMaxLo, nBitLo, @hVal, @aInd, @nn )
   aVal := hash_to_array16( hVal )
   check_conv16( aLower, aInd, aVal, nMinLo,  nMaxLo, nBitLo )

   cResult += array_to_code( aInd, "s_lo_idx", nn )
   cResult += hb_eol()
   cResult += array_to_code( aVal, "s_lo_val", 2 )
   cResult += hb_eol()
   cResult += index_func16( "s_uc_lower", "s_lo_idx", "s_lo_val", ;
                            "HB_UCLO_FIRST", "HB_UCLO_LAST", "HB_UCLO_BITS" )


   cResult += hb_eol()
   cResult += "#define HB_UCFL_FIRST   0x" + hb_numToHex( nMinCh, 4 ) + hb_eol()
   cResult += "#define HB_UCFL_LAST    0x" + hb_numToHex( nMaxCh, 4 ) + hb_eol()
   cResult += "#define HB_UCFL_BITS    " + hb_ntos( nBitCh ) + hb_eol()
   cResult += hb_eol()

   calc_size04( aFlags, nMinCh, nMaxCh, nBitCh, @hVal, @aInd, @nn )
   aVal := hash_to_array04( hVal )
   check_conv04( aFlags, aInd, aVal, nMinCh,  nMaxCh, nBitCh )

   cResult += array_to_code( aInd, "s_ch_idx", nn )
   cResult += hb_eol()
   cResult += array_to_code( aVal, "s_ch_val", 1 )
   cResult += hb_eol()
   cResult += index_func04( "s_uc_flags", "s_ch_idx", "s_ch_val", ;
                            "HB_UCFL_FIRST", "HB_UCFL_LAST", "HB_UCFL_BITS" )


   hb_memowrit( "uc16def.c", cResult )
return

static function array_to_code( aVal, cName, nn )
   local cResult, l, n

   cResult := "static const " + ;
              iif( nn == 1, "HB_BYTE", "HB_USHORT" ) + " " + ;
              cName + "[ " + hb_ntos( len( aVal ) ) + " ] =" + hb_eol()
   cResult += "{" + hb_eol()
   l := 0
   for n := 1 to len( aVal )
      if ++l > iif( nn == 1, 12, 8 )
         l := 1
         cResult += ","
         cResult += hb_eol()
         cResult += "   "
      elseif n == 1
         cResult += "   "
      else
         cResult += ", "
      endif
      cResult += "0x"
      cResult += hb_numToHex( aVal[ n ], nn * 2 )
   next
   cResult += hb_eol()
   cResult += "};" + hb_eol()
return cResult;

static function hash_to_array16( hVal )
   local aVal := {}, cLine, n
   for each cLine in hVal
      for n := 1 to len( cLine ) step( 2 )
         aadd( aVal, bin2w( substr( cLine, n, 2 ) ) )
      next
   next
return aVal

static function hash_to_array04( hVal )
   local aVal := {}, cLine, c
   for each cLine in hVal
      for each c in cLine
         aadd( aVal, asc( c ) )
      next
   next
return aVal

static function index_func16( cName, cNameInd, cNameConv, cMin, cMax, cBit )
   local cResult

   cResult := "static HB_USHORT " + cName + "( int n )" + hb_eol() + ;
              "{" + hb_eol() + ;
              "   n -= " + cMin + ";" + hb_eol() + ;
              "   if( n >= 0 && n <= ( " + cMax + " - " + cMin + " ) )" + hb_eol() + ;
              "   {" + hb_eol() + ;
              "      return " + cNameConv + "[ ( " + cNameInd + ;
                     "[ n >> " + cBit + " ] << " + cBit + " ) +" + hb_eol() + ;
              space( len( cNameConv ) + 15 ) + ;
                     "( n & ( ( 1 << " + cBit + " ) - 1 ) ) ];" + hb_eol() + ;
              "   }" + hb_eol() + ;
              "   return 0;" + hb_eol() + ;
              "}" + hb_eol()

return cResult

static function index_func04( cName, cNameInd, cNameConv, cMin, cMax, cBit )
   local cResult

   cResult := "static int " + cName + "( int n )" + hb_eol() + ;
              "{" + hb_eol() + ;
              "   n -= " + cMin + ";" + hb_eol() + ;
              "   if( n >= 0 && n <= ( " + cMax + " - " + cMin + " ) )" + hb_eol() + ;
              "   {" + hb_eol() + ;
              "      HB_BYTE v;" + hb_eol() + ;
              "      v = " + cNameConv + "[ ( " + cNameInd + ;
                     "[ n >> " + cBit + " ] << ( " + cBit + " - 1 ) ) +" + hb_eol() + ;
              space( len( cNameConv ) + 12 ) + ;
                     "( ( n & ( ( 1 << " + cBit + " ) - 1 ) ) >> 1 ) ];" + hb_eol() + ;
              "      return n & 1 ? v >> 4 : v & 0x0F;" + hb_eol() + ;
              "   }" + hb_eol() + ;
              "   return 0;" + hb_eol() + ;
              "}" + hb_eol()

return cResult

function min_size16( aVal, nMin, nMax, nBit )
   local n, nM, nS, nSize, nMinX
   nSize := 0xFFFFFF
   nMinX := nMin
#ifdef DO_START_OPT
   for nM := 0 to nMin
#else
   for nM := nMin to nMin
#endif
      for n := 1 to 16
         nS := calc_size16( aVal, nM, nMax, n )
         if nS < nSize
            nSize := nS
            nBit := n
            nMinX := nM
         endif
      next
   next
   nMin := nMinX
return nSize

function calc_size16( aVal, nMin, nMax, nBit, hVal, aInd, nn )
   local nLine, n, cLine, c

   nLine := int( 2 ^ ( nBit + 1 ) )

   cLine := ""
   hVal := {=>}
   aInd := {}
   hb_hKeepOrder( hVal, .t. )
   for n := nMin to nMax
      cLine += i2bin( iif( n == 0, 0, aVal[ n ] ) )
      if len( cLine ) == nLine
         hVal[ cLine ] := cLine
         aadd( aInd, hb_hpos( hVal, cLine ) - 1 )
         cLine := ""
      endif
   next
   if ! cLine == ""
      for each c in hVal
         if c = cLine
            cLine := c
            exit
         endif
      next
      hVal[ cLine ] := cLine
      aadd( aInd, hb_hpos( hVal, cLine ) - 1 )
   endif
   nn := iif( len( aInd ) > 256, 2, 1 )
   n := len( aInd ) * nn
   for each c in hVal
      n += len( c )
   next

return n

function min_size04( aVal, nMin, nMax, nBit )
   local n, nM, nS, nSize, nMinX
   nSize := 0xFFFFFF
   nMinX := nMin
#ifdef DO_START_OPT
   for nM := 0 to nMin
#else
   for nM := nMin to nMin
#endif
      for n := 1 to 16
         nS := calc_size04( aVal, nM, nMax, n )
         if nS < nSize
            nSize := nS
            nBit := n
            nMinX := nM
         endif
      next
   next
   nMin := nMinX
return nSize

function calc_size04( aVal, nMin, nMax, nBit, hVal, aInd, nn )
   local nLine, n, cLine, c

   nLine := int( 2 ^ ( nBit - 1 ) )

   cLine := ""
   hVal := {=>}
   aInd := {}
   hb_hKeepOrder( hVal, .t. )
   for n := nMin to nMax step 2
      cLine += chr( iif( n == 0, 0, aVal[ n ] ) + aVal[ n + 1 ] * 16 )
      if len( cLine ) == nLine
         hVal[ cLine ] := cLine
         aadd( aInd, hb_hpos( hVal, cLine ) - 1 )
         cLine := ""
      endif
   next
   if ! cLine == ""
      for each c in hVal
         if c = cLine
            cLine := c
            exit
         endif
      next
      hVal[ cLine ] := cLine
      aadd( aInd, hb_hpos( hVal, cLine ) - 1 )
   endif
   nn := iif( len( aInd ) > 256, 2, 1 )
   n := len( aInd ) * nn
   for each c in hVal
      n += len( c )
   next

return n

static function conv_get16( n, aInd, aVal, nMin, nMax, nBit )
   local nDiv
   if n >= nMin .and. n <= nMax
      nDiv := 2 ^ nBit
      n -= nMin
      return aVal[ aInd[ n / nDiv + 1 ] * nDiv + n % nDiv + 1 ]
   endif
return 0

static function check_conv16( aConv, aInd, aVal, nMin, nMax, nBit )
   local n, nVal
   for n := 1 to len( aConv )
      nVal := conv_get16( n, aInd, aVal, nMin, nMax, nBit )
      if aConv[ n ] != nVal
         ? "Wrong decoding:", n, aConv[ n ], nVal, len( aConv ), nMax //, hb_eol()
         break
//         exit
      endif
   next
return nil

static function conv_get04( n, aInd, aVal, nMin, nMax, nBit )
   local nDiv, nByte, nInd
   if n >= nMin .and. n <= nMax
      nDiv := int( 2 ^ nBit )
      n -= nMin
//      nInd := aInd[ n / nDiv + 1 ] * nDiv + n % nDiv
//      nByte := aVal[ nInd / 2 + 1 ]
//      return iif( n % 2 == 0, hb_bitAnd( nByte, 0x0F ), int( nByte / 16 ) )

      nInd := aInd[ n / nDiv + 1 ] * nDiv / 2 + ( n % nDiv ) / 2
      nByte := aVal[ nInd + 1 ]
      return iif( n % 2 == 1, int( nByte / 16 ), hb_bitAnd( nByte, 0x0F ) )

//      v = s_ch_val[ ( s_ch_idx[ n >> HB_UCFL_BITS ] << ( HB_UCFL_BITS - 1 ) ) +
//                    ( ( n & ( ( 1 << HB_UCFL_BITS ) - 1 ) ) >> 1 ) ];
//      return n & 1 ? v >> 4 : v & 0x0F;

   endif
return 0

static function check_conv04( aConv, aInd, aVal, nMin, nMax, nBit )
   local n, nVal
   for n := 1 to len( aConv )
      nVal := conv_get04( n, aInd, aVal, nMin, nMax, nBit )
      if aConv[ n ] != nVal
         ? "Wrong decoding:", n, aConv[ n ], nVal, len( aConv ), nMax //, hb_eol()
//         break
//         exit
      endif
   next
return nil
