/*
 * $Id: macroa.c 11685 2009-07-09 21:22:22Z vszakats $
 */

/* hbexpra.c is also included from ../compiler/expropta.c
 * However it produces a slighty different code if used in
 * macro compiler (there is an additional parameter passed to some functions)
 * 1.21 - ignore this magic number - this is used to force compilation
*/

#define HB_MACRO_SUPPORT

#include "hbmacro.h"
#include "hbcomp.h"

#include "hbexpra.c"
