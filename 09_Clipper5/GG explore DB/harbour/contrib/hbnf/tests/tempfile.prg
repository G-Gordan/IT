/*
 * $Id: tempfile.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

#include "fileio.ch"

PROCEDURE Main( cPath, cHide )

   LOCAL cFile, nHandle

   cFile := ft_TempFil( cPath, cHide == "Y" )

   IF ! Empty( cFile )
      ? cFile
      nHandle := FOpen( cFile, FO_WRITE )
      FWrite( nHandle, "This is a test!" )
      FClose( nHandle )
   ELSE
      ? "An error occurred"
   ENDIF

   RETURN
