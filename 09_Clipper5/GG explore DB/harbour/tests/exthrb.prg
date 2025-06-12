/*
 * $Id: exthrb.prg 17835 2012-07-18 13:41:31Z vszakats $
 */

// see also testhrb.prg

FUNCTION Msg()

   ? "Function called from HRB file"

   RETURN .T.

FUNCTION msg2()

   RETURN Msg()
