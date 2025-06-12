/*
 * $Id: testpid.prg 18414 2012-10-31 13:04:01Z vszakats $
 */

/*
 * Harbour Project source code:
 *
 * Copyright 2010 Viktor Szakats (harbour syenar.net)
 * www - http://harbour-project.org
 *
 */

#require "hbunix"

#include "simpleio.ch"

PROCEDURE Main()

   ? posix_getpid()

   RETURN
