/*
 * $Id: prtesc.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

#require "hbnf"

PROCEDURE Main( cParm1 )

   IF PCount() > 0
      ? ft_EscCode( cParm1 )
   ELSE
      ? "Usage: PRT_ESC  'escape code sequence' "
      ? "            outputs converted code to  standard output"
      ?
   ENDIF

   RETURN
