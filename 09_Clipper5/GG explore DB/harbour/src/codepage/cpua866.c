/*
 * $Id: cpua866.c 18809 2013-01-31 23:07:23Z vszakats $
 */

/*
 * Harbour Project source code:
 * National Collation Support Module (UA866)
 *
 * Copyright 2004 Pavel Tsarenko <tpe2@mail.ru>
 * www - http://www.xharbour.org
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this software; see the file COPYING.txt.  If not, write to
 * the Free Software Foundation, Inc., 59 Temple Place, Suite 330,
 * Boston, MA 02111-1307 USA (or visit the web site http://www.gnu.org/).
 *
 * As a special exception, the Harbour Project gives permission for
 * additional uses of the text contained in its release of Harbour.
 *
 * The exception is that, if you link the Harbour libraries with other
 * files to produce an executable, this does not by itself cause the
 * resulting executable to be covered by the GNU General Public License.
 * Your use of that executable is in no way restricted on account of
 * linking the Harbour library code into it.
 *
 * This exception does not however invalidate any other reasons why
 * the executable file might be covered by the GNU General Public License.
 *
 * This exception applies only to the code released by the Harbour
 * Project under the name Harbour.  If you copy code from other
 * Harbour Project or Free Software Foundation releases into a copy of
 * Harbour, as the General Public License permits, the exception does
 * not apply to the code that you add in this way.  To avoid misleading
 * anyone as to the status of such modified files, you must delete
 * this exception notice from them.
 *
 * If you write modifications of your own for Harbour, it is your choice
 * whether to permit this exception to apply to your modifications.
 * If you do not wish that, delete this exception notice.
 *
 */

/* NOTE: This collation misses two characters (Ґґ) from
         the Ukrainian alphabet and uses non-cyrillic
         versions for another two (Іі), because the
         originals cannot be encoded in CP-866:
           Ґ - U+0490 - http://codepoints.net/U+0490
           ґ - U+0491 - http://codepoints.net/U+0491
           І - U+0406 - http://codepoints.net/U+0406
           і - U+0456 - http://codepoints.net/U+0456
         [druzus/vszakats] */

#define HB_CP_ID        UA866
#define HB_CP_INFO      "Ukrainian CP-866"
#define HB_CP_UNITB     HB_UNITB_866
#define HB_CP_ACSORT    HB_CDP_ACSORT_NONE
#define HB_CP_UPPER     "АБВГДЕЁЄЖЗИIЇЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"
#define HB_CP_LOWER     "абвгдеёєжзиiїйклмнопрстуфхцчшщъыьэюя"
#define HB_CP_UTF8

/* include CP registration code */
#include "hbcdpreg.h"
