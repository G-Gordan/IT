/*
 * $Id: isbit.prg 18462 2012-11-07 02:57:26Z vszakats $
 */

/*
 * Author....: Forest Belt, Computer Diagnostic Services, Inc.
 * CIS ID....: ?
 *
 * This is an original work by Forest Belt and is placed in the
 * public domain.
 *
 * Modification history:
 * ---------------------
 *
 *    Rev 1.2   15 Aug 1991 23:03:46   GLENN
 * Forest Belt proofread/edited/cleaned up doc
 *
 *    Rev 1.1   14 Jun 1991 19:52:02   GLENN
 * Minor edit to file header
 *
 *    Rev 1.0   01 Apr 1991 01:01:32   GLENN
 * Nanforum Toolkit
 *
 */

FUNCTION ft_IsBit( cInbyte, nBitPos )

   IF HB_ISSTRING( cInbyte ) .AND. HB_ISNUMERIC( nBitPos )
      RETURN hb_bitTest( hb_BCode( cInbyte ), nBitpos )
   ENDIF

   RETURN NIL
