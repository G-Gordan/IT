/*
 * $Id: tiptime.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

/*
 * Copyright 2009 Viktor Szakats (harbour syenar.net)
 * www - http://harbour-project.org
 */

#require "hbtip"

#include "simpleio.ch"

PROCEDURE Main()

   ? ">" + tip_TimeStamp() + "<"
   ? ">" + tip_TimeStamp( NIL, 200 ) + "<"
   ? ">" + tip_TimeStamp( Date() ) + "<"
   ? ">" + tip_TimeStamp( Date(), 200 ) + "<"
   ? ">" + tip_TimeStamp( hb_DateTime() ) + "<"
   ? ">" + tip_TimeStamp( hb_DateTime(), 200 ) + "<"

   RETURN
