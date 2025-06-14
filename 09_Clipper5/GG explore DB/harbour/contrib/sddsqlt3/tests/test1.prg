/*
 * $Id: test1.prg 18724 2012-12-04 13:20:54Z vszakats $
 */

#require "rddsql"
#require "sddsqlt3"

#include "simpleio.ch"

REQUEST SDDSQLITE3, SQLMIX

PROCEDURE Main()

   LOCAL tmp

#if defined( __HBSCRIPT__HBSHELL )
   rddRegister( "SQLBASE" )
   rddRegister( "SQLMIX" )
   hb_SDDSQLITE3_Register()
#endif

   rddSetDefault( "SQLMIX" )
   SET DATE ANSI
   SET CENTURY ON

   AEval( rddList(), {| X | QOut( X ) } )

   ? "-1-"
   ? "Connect:", tmp := rddInfo( RDDI_CONNECT, { "SQLITE3", hb_DirBase() + "test.sq3" } )
   IF tmp == 0
      ? "Unable connect to the server"
   ENDIF
   ? "-2-"
   ? "Use:", dbUseArea( .T., , "select * from t1", "t1" )
   ? "-3-"
   ? "Alias:", Alias()
   ? "-4-"
   ? "DB struct:", hb_ValToExp( dbStruct() )
   ? "-5-"
   FOR tmp := 1 TO FCount()
      ? FieldName( tmp ), hb_FieldType( tmp )
   NEXT
   ? "-6-"
   Inkey( 0 )
   Browse()

   INDEX ON FIELD->AGE TO age
   dbGoTop()
   Browse()
   dbCloseArea()

   RETURN
