/*
 * $Id: arreval.prg 17835 2012-07-18 13:41:31Z vszakats $
 */

PROCEDURE Main()

   LOCAL a := { 100, 200, 300 }

   AEval( a, {| nValue, nIndex | QOut( nValue, nIndex ) } )

   RETURN
