/*
 * $Id: cdow.prg 18414 2012-10-31 13:04:01Z vszakats $
 */

PROCEDURE Main()

   ? CMonth( Date() )
   ? CMonth( Date() + 31 )
   ? CMonth( Date() + 60 )

   ? CDoW( Date() )
   ? CDoW( Date() + 6 )
   ? CDoW( Date() + 7 )

   RETURN
