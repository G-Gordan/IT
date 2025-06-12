/*
 * $Id: tscmdarg.c 18223 2012-10-05 01:03:41Z vszakats $
 */

#include "hbapi.h"

void hb_cmdargTEST( void )
{
   char * pszArg;

   printf( "INFO: %i\n", hb_cmdargCheck( "INFO" ) );
   printf( "   F: %s\n", pszArg = hb_cmdargString( "F" ) ); if( pszArg ) hb_xfree( pszArg );
   printf( "  Fn: %i\n", hb_cmdargNum( "F" ) );
   printf( "TEMP: %s\n", pszArg = hb_cmdargString( "TEMP" ) ); if( pszArg ) hb_xfree( pszArg );

   printf( "INFO: %i\n", hb_cmdargCheck( "INFO" ) );
   printf( "   F: %s\n", pszArg = hb_cmdargString( "F" ) ); if( pszArg ) hb_xfree( pszArg );
   printf( "  Fn: %i\n", hb_cmdargNum( "F" ) );
   printf( "TEMP: %s\n", pszArg = hb_cmdargString( "TEMP" ) ); if( pszArg ) hb_xfree( pszArg );
}
