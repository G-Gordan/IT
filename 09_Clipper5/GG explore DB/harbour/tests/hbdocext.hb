/*
 * $Id: hbdocext.hb 18414 2012-10-31 13:04:01Z vszakats $
 */

/*
 * HBDOC extractor from source
 *
 * Copyright 2010 Viktor Szakats (harbour syenar.net)
 * www - http://harbour-project.org
 *
 */

#include "directry.ch"
#include "simpleio.ch"

PROCEDURE Main()

   LOCAL aFile
   LOCAL cFile
   LOCAL cDst

   LOCAL cHdr := ;
      "/*" + hb_eol() + ;
      " * $" + "Id" + "$" + hb_eol() + ;
      " */" + hb_eol()

   FOR EACH aFile IN Directory( hb_osFileMask() )
      cFile := __hbdoc_ToSource( __hbdoc_FromSource( MemoRead( aFile[ F_NAME ] ) ) )
      IF ! Empty( cFile )
         cDst := hb_FNameExtSet( aFile[ F_NAME ], ".txt" )
         IF ! hb_FileExists( cDst )
            ? "Saving", cDst
            hb_MemoWrit( cDst, cHdr + cFile )
         ENDIF
      ENDIF
   NEXT

   RETURN
