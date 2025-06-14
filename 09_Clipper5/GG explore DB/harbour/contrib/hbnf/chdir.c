/*
 * $Id: chdir.c 18153 2012-09-27 00:06:59Z vszakats $
 */

/*
 * Author....: Ted Means
 * CIS ID....: 73067,3332
 *
 * This is an original work by Ted Means and is placed in the
 * public domain.
 *
 * Modification history:
 * ---------------------
 *
 *     Rev 1.2   15 Aug 1991 23:07:20   GLENN
 *  Forest Belt proofread/edited/cleaned up doc
 *
 *     Rev 1.1   14 Jun 1991 19:54:20   GLENN
 *  Minor edit to file header
 *
 *     Rev 1.0   01 Apr 1991 01:03:10   GLENN
 *  Nanforum Toolkit
 *
 */

#include "hbapi.h"
#include "hbapifs.h"

HB_FUNC( FT_CHDIR )
{
   hb_retl( HB_ISCHAR( 1 ) && hb_fsChDir( hb_parc( 1 ) ) );
}
