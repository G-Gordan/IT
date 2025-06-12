/*
 * $Id: testsha1.prg 18580 2012-11-16 15:23:20Z vszakats $
 */

/*
 * Harbour Project source code:
 *
 * Rewritten from C: Viktor Szakats (harbour syenar.net)
 * www - http://harbour-project.org
 */

PROCEDURE Main()

   ? ">" + hb_SHA1( "hello" ) + "<"
   ? ">" + hb_SHA1( "hello", .F. ) + "<"
   ? ">" + hb_SHA1( "hello", .T. ) + "<"

   ? ">" + hb_HMAC_SHA1( "hello", "key" ) + "<"
   ? ">" + hb_HMAC_SHA1( "hello", "key", .F. ) + "<"
   ? ">" + hb_HMAC_SHA1( "hello", "key", .T. ) + "<"

   RETURN
