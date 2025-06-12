/*
 * $Id: cint86.c 18414 2012-10-31 13:04:01Z vszakats $
 */

#include "hbapi.h"

HB_FUNC( FT_INT86 )
{
#if defined( HB_OS_DOS )
   {
      int iTODO;
   }
#endif
   hb_retl( HB_FALSE );
}
