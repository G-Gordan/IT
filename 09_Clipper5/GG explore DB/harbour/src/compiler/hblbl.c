/*
 * $Id: hblbl.c 18748 2012-12-19 06:19:13Z vszakats $
 */

/*
 * Harbour Project source code:
 * generate table with jump labels
 *
 * Copyright 2006 Przemyslaw Czerpak < druzus /at/ priv.onet.pl >
 * www - http://harbour-project.org
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

#include "hbcomp.h"
#include "hbassert.h"

#define HB_LABEL_FUNC( func )  HB_PCODE_FUNC( func, PHB_LABEL_INFO )
typedef HB_LABEL_FUNC( HB_LABEL_FUNC_ );
typedef HB_LABEL_FUNC_ * PHB_LABEL_FUNC;

/*
 * jump functions
 */
static HB_LABEL_FUNC( hb_p_jumpnear )
{
   HB_SIZE nNewPos = nPCodePos + ( signed char ) pFunc->pCode[ nPCodePos + 1 ];

   cargo->pnLabels[ nNewPos ]++;
   return 2;
}

static HB_LABEL_FUNC( hb_p_jump )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_SIZE nNewPos = nPCodePos + HB_PCODE_MKSHORT( pAddr );

   cargo->pnLabels[ nNewPos ]++;
   return 3;
}

static HB_LABEL_FUNC( hb_p_jumpfar )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_SIZE nNewPos = nPCodePos + HB_PCODE_MKINT24( pAddr );

   cargo->pnLabels[ nNewPos ]++;
   return 4;
}

static HB_LABEL_FUNC( hb_p_jumpfalsenear )
{
   HB_SIZE nNewPos = nPCodePos + ( signed char ) pFunc->pCode[ nPCodePos + 1 ];

   cargo->fCondJump = HB_TRUE;
   cargo->pnLabels[ nNewPos ]++;
   return 2;
}

static HB_LABEL_FUNC( hb_p_jumpfalse )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_SIZE nNewPos = nPCodePos + HB_PCODE_MKSHORT( pAddr );

   cargo->fCondJump = HB_TRUE;
   cargo->pnLabels[ nNewPos ]++;
   return 3;
}

static HB_LABEL_FUNC( hb_p_jumpfalsefar )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_SIZE nNewPos = nPCodePos + HB_PCODE_MKINT24( pAddr );

   cargo->fCondJump = HB_TRUE;
   cargo->pnLabels[ nNewPos ]++;
   return 4;
}

static HB_LABEL_FUNC( hb_p_jumptruenear )
{
   HB_SIZE nNewPos = nPCodePos + ( signed char ) pFunc->pCode[ nPCodePos + 1 ];

   cargo->fCondJump = HB_TRUE;
   cargo->pnLabels[ nNewPos ]++;
   return 2;
}

static HB_LABEL_FUNC( hb_p_jumptrue )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_SIZE nNewPos = nPCodePos + HB_PCODE_MKSHORT( pAddr );

   cargo->fCondJump = HB_TRUE;
   cargo->pnLabels[ nNewPos ]++;
   return 3;
}

static HB_LABEL_FUNC( hb_p_jumptruefar )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_SIZE nNewPos = nPCodePos + HB_PCODE_MKINT24( pAddr );

   cargo->fCondJump = HB_TRUE;
   cargo->pnLabels[ nNewPos ]++;
   return 4;
}

static HB_LABEL_FUNC( hb_p_seqalways )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_SIZE nAlwaysPos = nPCodePos + HB_PCODE_MKINT24( pAddr );

   if( cargo->fSetSeqBegin )
      cargo->pnLabels[ nAlwaysPos ]++;
   return 4;
}

static HB_LABEL_FUNC( hb_p_alwaysbegin )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_SIZE nAlwaysEndPos = nPCodePos + HB_PCODE_MKINT24( pAddr );

   if( cargo->fSetSeqBegin )
      cargo->pnLabels[ nAlwaysEndPos ]++;
   return 4;
}

static HB_LABEL_FUNC( hb_p_seqbegin )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_SIZE nRecoverPos = nPCodePos + HB_PCODE_MKINT24( pAddr );

   if( cargo->fSetSeqBegin )
      cargo->pnLabels[ nRecoverPos ]++;
   return 4;
}

static HB_LABEL_FUNC( hb_p_seqend )
{
   HB_BYTE * pAddr = &pFunc->pCode[ nPCodePos + 1 ];
   HB_ISIZ nOffset = HB_PCODE_MKINT24( pAddr );
   HB_SIZE nNewPos = nPCodePos + nOffset;

   if( cargo->fSetSeqBegin || nOffset != 4 )
      cargo->pnLabels[ nNewPos ]++;
   return 4;
}

/* NOTE: The  order of functions have to match the order of opcodes
 *       mnemonics
 */
static const PHB_LABEL_FUNC s_GenLabelFuncTable[] =
{
   NULL,                       /* HB_P_AND,                  */
   NULL,                       /* HB_P_ARRAYPUSH,            */
   NULL,                       /* HB_P_ARRAYPOP,             */
   NULL,                       /* HB_P_ARRAYDIM,             */
   NULL,                       /* HB_P_ARRAYGEN,             */
   NULL,                       /* HB_P_EQUAL,                */
   NULL,                       /* HB_P_ENDBLOCK,             */
   NULL,                       /* HB_P_ENDPROC,              */
   NULL,                       /* HB_P_EXACTLYEQUAL,         */
   NULL,                       /* HB_P_FALSE,                */
   NULL,                       /* HB_P_FORTEST,              */
   NULL,                       /* HB_P_FUNCTION,             */
   NULL,                       /* HB_P_FUNCTIONSHORT,        */
   NULL,                       /* HB_P_FRAME,                */
   NULL,                       /* HB_P_FUNCPTR,              */
   NULL,                       /* HB_P_GREATER,              */
   NULL,                       /* HB_P_GREATEREQUAL,         */
   NULL,                       /* HB_P_DEC,                  */
   NULL,                       /* HB_P_DIVIDE,               */
   NULL,                       /* HB_P_DO,                   */
   NULL,                       /* HB_P_DOSHORT,              */
   NULL,                       /* HB_P_DUPLICATE,            */
   NULL,                       /* HB_P_PUSHTIMESTAMP,        */
   NULL,                       /* HB_P_INC,                  */
   NULL,                       /* HB_P_INSTRING,             */
   hb_p_jumpnear,              /* HB_P_JUMPNEAR,             */
   hb_p_jump,                  /* HB_P_JUMP,                 */
   hb_p_jumpfar,               /* HB_P_JUMPFAR,              */
   hb_p_jumpfalsenear,         /* HB_P_JUMPFALSENEAR,        */
   hb_p_jumpfalse,             /* HB_P_JUMPFALSE,            */
   hb_p_jumpfalsefar,          /* HB_P_JUMPFALSEFAR,         */
   hb_p_jumptruenear,          /* HB_P_JUMPTRUENEAR,         */
   hb_p_jumptrue,              /* HB_P_JUMPTRUE,             */
   hb_p_jumptruefar,           /* HB_P_JUMPTRUEFAR,          */
   NULL,                       /* HB_P_LESSEQUAL,            */
   NULL,                       /* HB_P_LESS,                 */
   NULL,                       /* HB_P_LINE,                 */
   NULL,                       /* HB_P_LOCALNAME,            */
   NULL,                       /* HB_P_MACROPOP,             */
   NULL,                       /* HB_P_MACROPOPALIASED,      */
   NULL,                       /* HB_P_MACROPUSH,            */
   NULL,                       /* HB_P_MACROARRAYGEN,        */
   NULL,                       /* HB_P_MACROPUSHLIST,        */
   NULL,                       /* HB_P_MACROPUSHINDEX,       */
   NULL,                       /* HB_P_MACROPUSHPARE,        */
   NULL,                       /* HB_P_MACROPUSHALIASED,     */
   NULL,                       /* HB_P_MACROSYMBOL,          */
   NULL,                       /* HB_P_MACROTEXT,            */
   NULL,                       /* HB_P_MESSAGE,              */
   NULL,                       /* HB_P_MINUS,                */
   NULL,                       /* HB_P_MODULUS,              */
   NULL,                       /* HB_P_MODULENAME,           */
                               /* start: pcodes generated by macro compiler */
   NULL,                       /* HB_P_MMESSAGE,             */
   NULL,                       /* HB_P_MPOPALIASEDFIELD,     */
   NULL,                       /* HB_P_MPOPALIASEDVAR,       */
   NULL,                       /* HB_P_MPOPFIELD,            */
   NULL,                       /* HB_P_MPOPMEMVAR,           */
   NULL,                       /* HB_P_MPUSHALIASEDFIELD,    */
   NULL,                       /* HB_P_MPUSHALIASEDVAR,      */
   NULL,                       /* HB_P_MPUSHBLOCK,           */
   NULL,                       /* HB_P_MPUSHFIELD,           */
   NULL,                       /* HB_P_MPUSHMEMVAR,          */
   NULL,                       /* HB_P_MPUSHMEMVARREF,       */
   NULL,                       /* HB_P_MPUSHSYM,             */
   NULL,                       /* HB_P_MPUSHVARIABLE,        */
                               /* end: */
   NULL,                       /* HB_P_MULT,                 */
   NULL,                       /* HB_P_NEGATE,               */
   NULL,                       /* HB_P_NOOP,                 */
   NULL,                       /* HB_P_NOT,                  */
   NULL,                       /* HB_P_NOTEQUAL,             */
   NULL,                       /* HB_P_OR,                   */
   NULL,                       /* HB_P_PARAMETER,            */
   NULL,                       /* HB_P_PLUS,                 */
   NULL,                       /* HB_P_POP,                  */
   NULL,                       /* HB_P_POPALIAS,             */
   NULL,                       /* HB_P_POPALIASEDFIELD,      */
   NULL,                       /* HB_P_POPALIASEDFIELDNEAR,  */
   NULL,                       /* HB_P_POPALIASEDVAR,        */
   NULL,                       /* HB_P_POPFIELD,             */
   NULL,                       /* HB_P_POPLOCAL,             */
   NULL,                       /* HB_P_POPLOCALNEAR,         */
   NULL,                       /* HB_P_POPMEMVAR,            */
   NULL,                       /* HB_P_POPSTATIC,            */
   NULL,                       /* HB_P_POPVARIABLE,          */
   NULL,                       /* HB_P_POWER,                */
   NULL,                       /* HB_P_PUSHALIAS,            */
   NULL,                       /* HB_P_PUSHALIASEDFIELD,     */
   NULL,                       /* HB_P_PUSHALIASEDFIELDNEAR, */
   NULL,                       /* HB_P_PUSHALIASEDVAR,       */
   NULL,                       /* HB_P_PUSHBLOCK,            */
   NULL,                       /* HB_P_PUSHBLOCKSHORT,       */
   NULL,                       /* HB_P_PUSHFIELD,            */
   NULL,                       /* HB_P_PUSHBYTE,             */
   NULL,                       /* HB_P_PUSHINT,              */
   NULL,                       /* HB_P_PUSHLOCAL,            */
   NULL,                       /* HB_P_PUSHLOCALNEAR,        */
   NULL,                       /* HB_P_PUSHLOCALREF,         */
   NULL,                       /* HB_P_PUSHLONG,             */
   NULL,                       /* HB_P_PUSHMEMVAR,           */
   NULL,                       /* HB_P_PUSHMEMVARREF,        */
   NULL,                       /* HB_P_PUSHNIL,              */
   NULL,                       /* HB_P_PUSHDOUBLE,           */
   NULL,                       /* HB_P_PUSHSELF,             */
   NULL,                       /* HB_P_PUSHSTATIC,           */
   NULL,                       /* HB_P_PUSHSTATICREF,        */
   NULL,                       /* HB_P_PUSHSTR,              */
   NULL,                       /* HB_P_PUSHSTRSHORT,         */
   NULL,                       /* HB_P_PUSHSYM,              */
   NULL,                       /* HB_P_PUSHSYMNEAR,          */
   NULL,                       /* HB_P_PUSHVARIABLE,         */
   NULL,                       /* HB_P_RETVALUE,             */
   NULL,                       /* HB_P_SEND,                 */
   NULL,                       /* HB_P_SENDSHORT,            */
   hb_p_seqbegin,              /* HB_P_SEQBEGIN,             */
   hb_p_seqend,                /* HB_P_SEQEND,               */
   NULL,                       /* HB_P_SEQRECOVER,           */
   NULL,                       /* HB_P_SFRAME,               */
   NULL,                       /* HB_P_STATICS,              */
   NULL,                       /* HB_P_STATICNAME,           */
   NULL,                       /* HB_P_SWAPALIAS,            */
   NULL,                       /* HB_P_TRUE,                 */
   NULL,                       /* HB_P_ZERO,                 */
   NULL,                       /* HB_P_ONE,                  */
   NULL,                       /* HB_P_MACROFUNC,            */
   NULL,                       /* HB_P_MACRODO,              */
   NULL,                       /* HB_P_MPUSHSTR,             */
   NULL,                       /* HB_P_LOCALNEARADDINT,      */
   NULL,                       /* HB_P_MACROPUSHREF          */
   NULL,                       /* HB_P_PUSHLONGLONG          */
   NULL,                       /* HB_P_ENUMSTART             */
   NULL,                       /* HB_P_ENUMNEXT              */
   NULL,                       /* HB_P_ENUMPREV              */
   NULL,                       /* HB_P_ENUMEND               */
   NULL,                       /* HB_P_SWITCH                */
   NULL,                       /* HB_P_PUSHDATE              */
                               /* optimalization of inlined math operations */
   NULL,                       /* HB_P_PLUSEQPOP             */
   NULL,                       /* HB_P_MINUSEQPOP            */
   NULL,                       /* HB_P_MULTEQPOP             */
   NULL,                       /* HB_P_DIVEQPOP              */
   NULL,                       /* HB_P_PLUSEQ                */
   NULL,                       /* HB_P_MINUSEQ               */
   NULL,                       /* HB_P_MULTEQ                */
   NULL,                       /* HB_P_DIVEQ                 */
   NULL,                       /* HB_P_WITHOBJECTSTART       */
   NULL,                       /* HB_P_WITHOBJECTMESSAGE     */
   NULL,                       /* HB_P_WITHOBJECTEND         */
   NULL,                       /* HB_P_MACROSEND             */
   NULL,                       /* HB_P_PUSHOVARREF           */
   NULL,                       /* HB_P_ARRAYPUSHREF          */
   NULL,                       /* HB_P_VFRAME                */
   NULL,                       /* HB_P_LARGEFRAME            */
   NULL,                       /* HB_P_LARGEVFRAME           */
   NULL,                       /* HB_P_PUSHSTRHIDDEN         */
   NULL,                       /* HB_P_LOCALADDINT           */
   NULL,                       /* HB_P_MODEQPOP              */
   NULL,                       /* HB_P_EXPEQPOP              */
   NULL,                       /* HB_P_MODEQ                 */
   NULL,                       /* HB_P_EXPEQ                 */
   NULL,                       /* HB_P_DUPLUNREF             */
   NULL,                       /* HB_P_MPUSHBLOCKLARGE       */
   NULL,                       /* HB_P_MPUSHSTRLARGE         */
   NULL,                       /* HB_P_PUSHBLOCKLARGE        */
   NULL,                       /* HB_P_PUSHSTRLARGE          */
   NULL,                       /* HB_P_SWAP                  */
   NULL,                       /* HB_P_PUSHVPARAMS           */
   NULL,                       /* HB_P_PUSHUNREF             */
   hb_p_seqalways,             /* HB_P_SEQALWAYS             */
   hb_p_alwaysbegin,           /* HB_P_ALWAYSBEGIN           */
   NULL,                       /* HB_P_ALWAYSEND             */
   NULL,                       /* HB_P_DECEQPOP              */
   NULL,                       /* HB_P_INCEQPOP              */
   NULL,                       /* HB_P_DECEQ                 */
   NULL,                       /* HB_P_INCEQ                 */
   NULL,                       /* HB_P_LOCALDEC              */
   NULL,                       /* HB_P_LOCALINC              */
   NULL,                       /* HB_P_LOCALINCPUSH          */
   NULL,                       /* HB_P_PUSHFUNCSYM           */
   NULL,                       /* HB_P_HASHGEN               */
   NULL,                       /* HB_P_SEQBLOCK              */
   NULL,                       /* HB_P_THREADSTATICS         */
   NULL                        /* HB_P_PUSHAPARAMS           */
};

void hb_compGenLabelTable( PHB_HFUNC pFunc, PHB_LABEL_INFO label_info )
{
   const PHB_LABEL_FUNC * pFuncTable = s_GenLabelFuncTable;
   HB_SIZE nLabel = 0, n;

   assert( HB_P_LAST_PCODE == sizeof( s_GenLabelFuncTable ) / sizeof( PHB_LABEL_FUNC ) );

   hb_compPCodeEval( pFunc, ( const PHB_PCODE_FUNC * ) pFuncTable, ( void * ) label_info );

   for( n = 0; n < pFunc->nPCodePos; ++n )
   {
      if( label_info->pnLabels[ n ] )
      {
         label_info->pnLabels[ n ] = ++nLabel;
      }
   }
}
