/*
 * $Id: fixcase.hb 18736 2012-12-09 13:54:48Z vszakats $
 */

/*
 * Function naming casing fixer
 *
 * The script takes proper casing from .hbx files
 * and applies it to whole source tree. (except
 * C sources and some certain files)
 *
 * BEWARE: ugly code
 *
 * Copyright 2012 Viktor Szakats (harbour syenar.net)
 * www - http://harbour-project.org
 *
 */

#include "directry.ch"
#include "simpleio.ch"

PROCEDURE Main( cFile )

   LOCAL aFile
   LOCAL cExt

   LOCAL hAll := { => }

   LOCAL hExtExceptions := { ;
      hb_libExt() => NIL, ;
      ".zip"  => NIL, ;
      ".7z"   => NIL, ;
      ".exe"  => NIL, ;
      ".o"    => NIL, ;
      ".js"   => NIL, ;
      ".dif"  => NIL, ;
      ".c"    => NIL, ;
      ".h"    => NIL, ;
      ".api"  => NIL, ;
      ".exe"  => NIL, ;
      ".y"    => NIL, ;
      ".yyc"  => NIL, ;
      ".yyh"  => NIL, ;
      ".a"    => NIL, ;
      ".afm"  => NIL, ;
      ".bmp"  => NIL, ;
      ".dat"  => NIL, ;
      ".dbf"  => NIL, ;
      ".exe"  => NIL, ;
      ".frm"  => NIL, ;
      ".gif"  => NIL, ;
      ".icns" => NIL, ;
      ".ico"  => NIL, ;
      ".jpg"  => NIL, ;
      ".lbl"  => NIL, ;
      ".lib"  => NIL, ;
      ".mdb"  => NIL, ;
      ".ng"   => NIL, ;
      ".odt"  => NIL, ;
      ".pdf"  => NIL, ;
      ".pfb"  => NIL, ;
      ".png"  => NIL, ;
      ".sq3"  => NIL, ;
      ".tif"  => NIL }

   LOCAL hFileExceptions := { ;
      "ChangeLog.txt" => NIL, ;
      "std.ch"        => NIL, ;
      "wcecon.prg"    => NIL, ;
      "uc16_gen.prg"  => NIL, ;
      "clsscope.prg"  => NIL, ;
      "speedstr.prg"  => NIL, ;
      "cpinfo.prg"    => NIL, ;
      "clsccast.prg"  => NIL, ;
      "clsicast.prg"  => NIL, ;
      "clsscast.prg"  => NIL, ;
      "big5_gen.prg"  => NIL, ;
      "foreach2.prg"  => NIL, ;
      "speedtst.prg"  => NIL, ;
      "keywords.prg"  => NIL, ;
      "xhb-diff.txt"  => NIL, ;
      "pp.txt"        => NIL, ;
      "locks.txt"     => NIL, ;
      "oldnews.txt"   => NIL, ;
      "news.html"     => NIL, ;
      "news1.html"    => NIL, ;
      "c_std.txt"     => NIL, ;
      "tracing.txt"   => NIL, ;
      "pcode.txt"     => NIL }

   LOCAL aMaskExceptions := { ;
      "contrib/xhb/thtm.prg"       , ;
      "contrib/hbnetio/readme.txt" , ;
      "contrib/hbnetio/tests/*"    , ;
      "extras/httpsrv/home/*"      , ;
      "tests/hbpptest/*"           , ;
      "tests/mt/*"                 , ;
      "tests/multifnc/*"           , ;
      "tests/rddtest/*"            }

   hb_cdpSelect( "EN" )

   hb_HCaseMatch( hAll, .F. )

   __hbformat_BuildListOfFunctions( hAll )

   IF HB_ISSTRING( cFile )
      ProcFile( hAll, cFile )
   ELSE
      FOR EACH aFile IN hb_DirScan( "", hb_osFileMask() )
         cExt := hb_FNameExt( aFile[ F_NAME ] )
         IF ! Empty( hb_FNameExt( aFile[ F_NAME ] ) ) .AND. ;
            !( hb_FNameExt( aFile[ F_NAME ] ) $ hExtExceptions ) .AND. ;
            !( hb_FNameNameExt( aFile[ F_NAME ] ) $ hFileExceptions ) .AND. ;
            AScan( aMaskExceptions, {| tmp | hb_FileMatch( StrTran( aFile[ F_NAME ], "\", "/" ), tmp ) } ) == 0
            ProcFile( hAll, aFile[ F_NAME ] )
         ENDIF
      NEXT
   ENDIF

   RETURN

STATIC PROCEDURE ProcFile( hAll, cFileName )

   LOCAL cLog := MemoRead( cFileName )
   LOCAL cHit
   LOCAL tmp

   LOCAL nPos
   LOCAL cName

   LOCAL a
   LOCAL cProper

   LOCAL nChanged := 0

   FOR EACH a IN hb_regexAll( "([A-Za-z] |[^A-Za-z_:]|^)([A-Za-z_][A-Za-z0-9_]+\()", cLog,,,,, .T. )
      IF Len( a[ 2 ] ) != 2 .OR. !( Left( a[ 2 ], 1 ) $ "D" /* "METHOD" */ )
         cProper := ProperCase( hAll, hb_StrShrink( a[ 3 ], 1 ) ) + "("
         IF !( cProper == a[ 3 ] ) .AND. ;
            !( Upper( cProper ) == "FILE(" ) .AND. ; /* interacts with "file(s)" text */
            !( Upper( cProper ) == "INT(" )          /* interacts with SQL statements */
            cLog := StrTran( cLog, a[ 1 ], StrTran( a[ 1 ], a[ 3 ], cProper ) )
            ? cFileName, a[ 3 ], cProper, "|" + a[ 1 ] + "|"
            nChanged++
         ENDIF
      ENDIF
   NEXT

   IF nChanged > 0
      ? cFileName, "changed: ", nChanged
      hb_MemoWrit( cFileName, cLog )
   ENDIF

   RETURN

STATIC FUNCTION ProperCase( hAll, cName )

   IF cName $ hAll
      RETURN hb_HKeyAt( hAll, hb_HPos( hAll, cName ) )
   ENDIF

   RETURN cName

STATIC PROCEDURE __hbformat_BuildListOfFunctions( hFunctions )

   WalkDir( hb_DirBase() + ".." + hb_ps() + "include", hFunctions )
   WalkDir( hb_DirBase() + ".." + hb_ps() + "contrib", hFunctions )
   WalkDir( hb_DirBase() + ".." + hb_ps() + "extras", hFunctions )

   RETURN

STATIC PROCEDURE WalkDir( cDir, hFunctions )

   LOCAL aFile

   cDir := hb_DirSepAdd( cDir )

   FOR EACH aFile IN hb_DirScan( cDir, "*.hbx" )
      HBXToFuncList( hFunctions, hb_MemoRead( cDir + aFile[ F_NAME ] ) )
   NEXT

   RETURN

STATIC PROCEDURE HBXToFuncList( hFunctions, cHBX )
   LOCAL cLine

   FOR EACH cLine IN hb_ATokens( StrTran( cHBX, Chr( 13 ) ), Chr( 10 ) )
      IF Left( cLine, Len( "DYNAMIC " ) ) == "DYNAMIC "
         hFunctions[ SubStr( cLine, Len( "DYNAMIC " ) + 1 ) ] := NIL
      ENDIF
   NEXT

   RETURN
