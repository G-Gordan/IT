/*
 * $Id: hbmagic.ch 15893 2010-11-25 09:40:20Z vszakats $
 */

/*
 * Copyright (c) Christos Zoulas 2003.
 * All Rights Reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice immediately at the beginning of the file, without modification,
 *    this list of conditions, and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR AND CONTRIBUTORS ``AS IS'' AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHOR OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS
 * OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
 * LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 */

#ifndef HBMAGIC_CH_
#define HBMAGIC_CH_

#define MAGIC_NONE              0x000000 /* No flags */
#define MAGIC_DEBUG             0x000001 /* Turn on debugging */
#define MAGIC_SYMLINK           0x000002 /* Follow symlinks */
#define MAGIC_COMPRESS          0x000004 /* Check inside compressed files */
#define MAGIC_DEVICES           0x000008 /* Look at the contents of devices */
#define MAGIC_MIME_TYPE         0x000010 /* Return the MIME type */
#define MAGIC_CONTINUE          0x000020 /* Return all matches */
#define MAGIC_CHECK             0x000040 /* Print warnings to stderr */
#define MAGIC_PRESERVE_ATIME    0x000080 /* Restore access time on exit */
#define MAGIC_RAW               0x000100 /* Don't translate unprintable chars */
#define MAGIC_ERROR             0x000200 /* Handle ENOENT etc as real errors */
#define MAGIC_MIME_ENCODING     0x000400 /* Return the MIME encoding */
#define MAGIC_MIME              hb_bitOr( MAGIC_MIME_TYPE, MAGIC_MIME_ENCODING )
#define MAGIC_APPLE             0x000800 /* Return the Apple creator and type */
#define MAGIC_NO_CHECK_COMPRESS 0x001000 /* Don't check for compressed files */
#define MAGIC_NO_CHECK_TAR      0x002000 /* Don't check for tar files */
#define MAGIC_NO_CHECK_SOFT     0x004000 /* Don't check magic entries */
#define MAGIC_NO_CHECK_APPTYPE  0x008000 /* Don't check application type */
#define MAGIC_NO_CHECK_ELF      0x010000 /* Don't check for elf details */
#define MAGIC_NO_CHECK_TEXT     0x020000 /* Don't check for text files */
#define MAGIC_NO_CHECK_CDF      0x040000 /* Don't check for cdf files */
#define MAGIC_NO_CHECK_TOKENS   0x100000 /* Don't check tokens */
#define MAGIC_NO_CHECK_ENCODING 0x200000 /* Don't check text encodings */

/* Defined for backwards compatibility (renamed) */
#define MAGIC_NO_CHECK_ASCII    MAGIC_NO_CHECK_TEXT

/* Defined for backwards compatibility; do nothing */
#define MAGIC_NO_CHECK_FORTRAN  0x000000 /* Don't check ascii/fortran */
#define MAGIC_NO_CHECK_TROFF    0x000000 /* Don't check ascii/troff */

#endif /* HBMAGIC_CH_ */
