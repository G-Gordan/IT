/*
 * $Id: rand1.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

/*
 * Author....: Gary Baren
 * CIS ID....: 75470,1027
 *
 * This is an original work by Gary Baren and is hereby placed in the
 * public domain.
 *
 * Modification history:
 * ---------------------
 *
 *    Rev 1.2   15 Aug 1991 23:04:30   GLENN
 * Forest Belt proofread/edited/cleaned up doc
 *
 *    Rev 1.1   14 Jun 1991 19:52:46   GLENN
 * Minor edit to file header
 *
 *    Rev 1.0   07 Jun 1991 23:03:38   GLENN
 * Initial revision.
 *
 */

FUNCTION ft_Rand1( nMax )

   THREAD STATIC t_nSeed

   LOCAL m := 100000000, b := 31415621

   t_nSeed := iif( t_nSeed == NIL, Seconds(), t_nSeed )

   RETURN nMax * ( ( t_nSeed := Mod( t_nSeed * b + 1, m ) ) / m )
