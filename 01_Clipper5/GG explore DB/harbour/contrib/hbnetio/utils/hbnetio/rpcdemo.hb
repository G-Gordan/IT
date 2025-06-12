/*
 * $Id: rpcdemo.hb 17462 2012-05-08 15:51:55Z vszakats $
 */

/*
 * RPC demo module for hbnetio server.
 *    Usage: 'hbnetio -rpc=rpcdemo.hb'
 *
 * Copyright 2010 Viktor Szakats (harbour syenar.net)
 * www - http://www.harbour-project.org
 *
 */

STATIC FUNCTION HBNETIOSRV_RPCMAIN( sFunc, ... )

   OutStd( "DO", sFunc:name, "WITH", ..., hb_eol() )

   RETURN sFunc:exec( ... )
