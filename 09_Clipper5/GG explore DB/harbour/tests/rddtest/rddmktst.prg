/*
 * $Id: rddmktst.prg 18204 2012-10-03 15:37:14Z vszakats $
 */

/*
 * Harbour Project source code:
 *    RDD tests
 *
 * Copyright 2008 Przemyslaw Czerpak <druzus / at / priv.onet.pl>
 * www - http://harbour-project.org
 *
 */

//#define _TEST_ADS_

//#define _CLIPPER53_

//#define _TEST_DESCEND_
//#define _TEST_UNIQUE_
//#define _TEST_SCOPE_
//#define _TEST_CMPDIDX_

#ifdef _TEST_ADS_
  #undef _TEST_DESCEND_
  #undef _TEST_UNIQUE_
#endif

#define _TEST_CREATE_

#include "rddtst.prg"

#ifndef _TEST_CMPDIDX_
  #command RDDTEST INDEX on <key> tag <tg> to <fi> [ FOR <for> ] [ <desc: DESCENDING> ] => ;
           RDDTEST INDEX on <key> to <tg> [ FOR <for> ] [ <desc> ]
#endif


function test_main()
RDDTEST LOCAL n

RDDTEST RDDSETDEFAULT()

RDDTEST USE _DBNAME SHARED

/* movments in empty DB */
RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(0)
RDDTEST DBGOTO(0)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(0)
RDDTEST SET DELETE ON
RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(0)
RDDTEST DBGOTO(0)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(0)
RDDTEST SET DELETE OFF

RDDTEST INDEX on FNUM tag TG_N to _DBNAME
RDDTEST INDEX on FSTR tag TG_C to _DBNAME

RDDTEST ORDSETFOCUS()

RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(0)
RDDTEST DBGOTO(0)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(0)
RDDTEST SET DELETE ON
RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(0)
RDDTEST DBGOTO(0)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(0)

RDDTEST DBGOTO(0)
RDDTEST DBSEEK('', .t.,.f.)
RDDTEST DBSEEK('', .t.,.t.)
RDDTEST DBSEEK('', .f.,.f.)
RDDTEST DBSEEK('', .f.,.t.)

RDDTEST SET DELETE OFF

RDDTEST ;
  for n := 1 to N_LOOP                     ;;
    dbappend()                             ;;
    replace FNUM with int( ( n + 2 ) / 3 ) ;;
    replace FSTR with chr( FNUM +48 )      ;;
  next

RDDTEST dbcommit()
RDDTEST dbunlock()

// seeking test
RDDTEST ORDSETFOCUS(1)
RDDTEST ORDSETFOCUS()
RDDTEST DBSEEK(0,.t.,.f.)
RDDTEST DBSEEK(0,.t.,.t.)
RDDTEST DBSEEK(0.5,.t.,.f.)
RDDTEST DBSEEK(0.5,.t.,.t.)
RDDTEST DBSEEK(1.0,.t.,.f.)
RDDTEST DBSEEK(1.0,.t.,.t.)
RDDTEST DBSEEK(2.0,.t.,.f.)
RDDTEST DBSEEK(2.0,.t.,.t.)
RDDTEST DBSEEK(2.5,.t.,.f.)
RDDTEST DBSEEK(2.5,.t.,.t.)
RDDTEST DBSEEK(5.0,.t.,.f.)
RDDTEST DBSEEK(5.0,.t.,.t.)
RDDTEST ORDSETFOCUS(2)
RDDTEST ORDSETFOCUS()

RDDTEST DBSEEK('', .t.,.f.)
RDDTEST DBSEEK('', .t.,.t.)
RDDTEST DBSEEK(' ',.t.,.f.)
RDDTEST DBSEEK(' ',.t.,.t.)
RDDTEST DBSEEK('0',.t.,.f.)
RDDTEST DBSEEK('0',.t.,.t.)
RDDTEST DBSEEK('1',.t.,.f.)
RDDTEST DBSEEK('1',.t.,.t.)
RDDTEST DBSEEK('2',.t.,.f.)
RDDTEST DBSEEK('2',.t.,.t.)
RDDTEST DBSEEK('3',.t.,.f.)
RDDTEST DBSEEK('3',.t.,.t.)
RDDTEST DBSEEK('4',.t.,.f.)
RDDTEST DBSEEK('4',.t.,.t.)
RDDTEST DBSEEK('5',.t.,.f.)
RDDTEST DBSEEK('5',.t.,.t.)
RDDTEST DBSEEK('6',.t.,.f.)
RDDTEST DBSEEK('6',.t.,.t.)

#ifdef _TEST_SCOPE_
RDDTEST ORDSCOPE(TOPSCOPE,'3')
RDDTEST ORDSCOPE(BOTTOMSCOPE,'4')
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST DBSEEK('', .t.,.f.)
RDDTEST DBSEEK('', .t.,.t.)
RDDTEST DBSEEK(' ',.t.,.f.)
RDDTEST DBSEEK(' ',.t.,.t.)
RDDTEST DBSEEK('0',.t.,.f.)
RDDTEST DBSEEK('0',.t.,.t.)
RDDTEST DBSEEK('1',.t.,.f.)
RDDTEST DBSEEK('1',.t.,.t.)
RDDTEST DBSEEK('2',.t.,.f.)
RDDTEST DBSEEK('2',.t.,.t.)
RDDTEST DBSEEK('3',.t.,.f.)
RDDTEST DBSEEK('3',.t.,.t.)
RDDTEST DBSEEK('4',.t.,.f.)
RDDTEST DBSEEK('4',.t.,.t.)
RDDTEST DBSEEK('5',.t.,.f.)
RDDTEST DBSEEK('5',.t.,.t.)
RDDTEST DBSEEK('6',.t.,.f.)
RDDTEST DBSEEK('6',.t.,.t.)

RDDTEST ORDSCOPE(TOPSCOPE,'3')
RDDTEST ORDSCOPE(BOTTOMSCOPE,'2')
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST DBSEEK('',.t.,.f.)
RDDTEST DBSEEK('',.t.,.t.)
RDDTEST DBSEEK('1',.t.,.f.)
RDDTEST DBSEEK('1',.t.,.t.)
RDDTEST DBSEEK('2',.t.,.f.)
RDDTEST DBSEEK('2',.t.,.t.)
RDDTEST DBSEEK('3',.t.,.f.)
RDDTEST DBSEEK('3',.t.,.t.)
RDDTEST DBSEEK('4',.t.,.f.)
RDDTEST DBSEEK('4',.t.,.t.)
#endif

#ifdef _TEST_DESCEND_
RDDTEST ORDDESCEND()
RDDTEST ORDDESCEND(,,.t.)
RDDTEST ORDDESCEND()
#endif
#ifdef _TEST_SCOPE_
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST ORDSCOPE(TOPSCOPE,NIL)
RDDTEST ORDSCOPE(BOTTOMSCOPE,NIL)
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
#endif
RDDTEST DBSEEK('', .t.,.f.)
RDDTEST DBSEEK('', .t.,.t.)
RDDTEST DBSEEK(' ',.t.,.f.)
RDDTEST DBSEEK(' ',.t.,.t.)
RDDTEST DBSEEK('0',.t.,.f.)
RDDTEST DBSEEK('0',.t.,.t.)
RDDTEST DBSEEK('1',.t.,.f.)
RDDTEST DBSEEK('1',.t.,.t.)
RDDTEST DBSEEK('2',.t.,.f.)
RDDTEST DBSEEK('2',.t.,.t.)
RDDTEST DBSEEK('3',.t.,.f.)
RDDTEST DBSEEK('3',.t.,.t.)
RDDTEST DBSEEK('4',.t.,.f.)
RDDTEST DBSEEK('4',.t.,.t.)
RDDTEST DBSEEK('5',.t.,.f.)
RDDTEST DBSEEK('5',.t.,.t.)
RDDTEST DBSEEK('6',.t.,.f.)
RDDTEST DBSEEK('6',.t.,.t.)
#ifdef _TEST_SCOPE_
RDDTEST ORDSCOPE(TOPSCOPE,'4')
RDDTEST ORDSCOPE(BOTTOMSCOPE,'3')
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST DBSEEK('', .t.,.f.)
RDDTEST DBSEEK('', .t.,.t.)
RDDTEST DBSEEK(' ',.t.,.f.)
RDDTEST DBSEEK(' ',.t.,.t.)
RDDTEST DBSEEK('0',.t.,.f.)
RDDTEST DBSEEK('0',.t.,.t.)
RDDTEST DBSEEK('1',.t.,.f.)
RDDTEST DBSEEK('1',.t.,.t.)
RDDTEST DBSEEK('2',.t.,.f.)
RDDTEST DBSEEK('2',.t.,.t.)
RDDTEST DBSEEK('3',.t.,.f.)
RDDTEST DBSEEK('3',.t.,.t.)
RDDTEST DBSEEK('4',.t.,.f.)
RDDTEST DBSEEK('4',.t.,.t.)
RDDTEST DBSEEK('5',.t.,.f.)
RDDTEST DBSEEK('5',.t.,.t.)
RDDTEST DBSEEK('6',.t.,.f.)
RDDTEST DBSEEK('6',.t.,.t.)

RDDTEST ORDSCOPE(TOPSCOPE,'3')
RDDTEST ORDSCOPE(BOTTOMSCOPE,'4')
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST DBSEEK('', .t.,.f.)
RDDTEST DBSEEK('', .t.,.t.)
RDDTEST DBSEEK(' ',.t.,.f.)
RDDTEST DBSEEK(' ',.t.,.t.)
RDDTEST DBSEEK('0',.t.,.f.)
RDDTEST DBSEEK('0',.t.,.t.)
RDDTEST DBSEEK('1',.t.,.f.)
RDDTEST DBSEEK('1',.t.,.t.)
RDDTEST DBSEEK('2',.t.,.f.)
RDDTEST DBSEEK('2',.t.,.t.)
RDDTEST DBSEEK('3',.t.,.f.)
RDDTEST DBSEEK('3',.t.,.t.)
RDDTEST DBSEEK('4',.t.,.f.)
RDDTEST DBSEEK('4',.t.,.t.)
RDDTEST DBSEEK('5',.t.,.f.)
RDDTEST DBSEEK('5',.t.,.t.)
RDDTEST DBSEEK('6',.t.,.f.)
RDDTEST DBSEEK('6',.t.,.t.)
#endif

RDDTEST INDEX on FSTR tag TG_C to _DBNAME DESCEND
RDDTEST DBSEEK('',.t.,.f.)
RDDTEST DBSEEK('',.t.,.t.)
RDDTEST DBSEEK(' ',.t.,.f.)
RDDTEST DBSEEK(' ',.t.,.t.)
RDDTEST DBSEEK('0',.t.,.f.)
RDDTEST DBSEEK('0',.t.,.t.)
RDDTEST DBSEEK('1',.t.,.f.)
RDDTEST DBSEEK('1',.t.,.t.)
RDDTEST DBSEEK('2',.t.,.f.)
RDDTEST DBSEEK('2',.t.,.t.)
RDDTEST DBSEEK('3',.t.,.f.)
RDDTEST DBSEEK('3',.t.,.t.)
RDDTEST DBSEEK('4',.t.,.f.)
RDDTEST DBSEEK('4',.t.,.t.)
RDDTEST DBSEEK('5',.t.,.f.)
RDDTEST DBSEEK('5',.t.,.t.)
RDDTEST DBSEEK('6',.t.,.f.)
RDDTEST DBSEEK('6',.t.,.t.)

#ifdef _TEST_SCOPE_
RDDTEST ORDSCOPE(TOPSCOPE,'4')
RDDTEST ORDSCOPE(BOTTOMSCOPE,'3')
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST DBSEEK('', .t.,.f.)
RDDTEST DBSEEK('', .t.,.t.)
RDDTEST DBSEEK(' ',.t.,.f.)
RDDTEST DBSEEK(' ',.t.,.t.)
RDDTEST DBSEEK('0',.t.,.f.)
RDDTEST DBSEEK('0',.t.,.t.)
RDDTEST DBSEEK('1',.t.,.f.)
RDDTEST DBSEEK('1',.t.,.t.)
RDDTEST DBSEEK('2',.t.,.f.)
RDDTEST DBSEEK('2',.t.,.t.)
RDDTEST DBSEEK('3',.t.,.f.)
RDDTEST DBSEEK('3',.t.,.t.)
RDDTEST DBSEEK('4',.t.,.f.)
RDDTEST DBSEEK('4',.t.,.t.)
RDDTEST DBSEEK('5',.t.,.f.)
RDDTEST DBSEEK('5',.t.,.t.)
RDDTEST DBSEEK('6',.t.,.f.)
RDDTEST DBSEEK('6',.t.,.t.)
#endif

// skiping test
RDDTEST INDEX on FSTR tag TG_C to _DBNAME
RDDTEST DBGOTOP()
RDDTEST DBSKIP(0)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(0)
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(0)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(0)

RDDTEST DBGOTO(1)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(5)
RDDTEST DBSKIP(5)
RDDTEST DBSKIP(5)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(-5)
RDDTEST DBSKIP(10)
RDDTEST DBSKIP(-5)
RDDTEST DBGOTO(16)
RDDTEST DBSKIP(-1)

#ifdef _TEST_SCOPE_
RDDTEST ORDSCOPE(TOPSCOPE,'3')
RDDTEST ORDSCOPE(BOTTOMSCOPE,'4')
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
#endif
RDDTEST DBGOTO(1)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(1)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(4)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(4)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(6)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(6)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(7)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(7)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(12)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(12)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(13)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(13)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(14)
RDDTEST DBSKIP(-1)
RDDTEST DBGOTO(16)
RDDTEST DBSKIP(-1)

RDDTEST ORDSETFOCUS(0)
RDDTEST DBGOTOP()
RDDTEST DBSKIP(-1)
RDDTEST DBGOTOP()
RDDTEST DBSKIP(-10)

RDDTEST INDEX on FSTR tag TG_C to _DBNAME FOR FNUM>2 .and. FNUM<=4
RDDTEST DBGOTO(1)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(1)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(4)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(4)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(6)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(6)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(7)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(7)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(12)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(12)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(13)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(13)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(14)
RDDTEST DBSKIP(-1)
RDDTEST DBGOTO(16)
RDDTEST DBSKIP(-1)

RDDTEST INDEX on FSTR tag TG_C to _DBNAME FOR FNUM!=2 .and. FNUM<4
RDDTEST DBGOTO(1)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(1)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(4)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(4)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(7)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(7)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(10)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(10)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(13)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(13)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(14)
RDDTEST DBSKIP(-1)
RDDTEST DBGOTO(16)
RDDTEST DBSKIP(-1)


RDDTEST DBGOTOP()
RDDTEST DBSKIP(1)
RDDTEST DBGOTOP()
RDDTEST DBSKIP(-1)

RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(1)
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(-1)

#ifdef _TEST_SCOPE_
RDDTEST ORDSCOPE(TOPSCOPE,'5')
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
#endif
RDDTEST DBGOTO(1)
RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()

RDDTEST INDEX on FSTR tag TG_C to _DBNAME FOR FNUM==6
RDDTEST DBGOTO(1)
RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()

#ifdef _TEST_SCOPE_
RDDTEST ORDSCOPE()
RDDTEST ORDSCOPE(TOPSCOPE)
RDDTEST ORDSCOPE(BOTTOMSCOPE)
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST ORDSCOPE(TOPSCOPE,NIL)
RDDTEST ORDSCOPE(BOTTOMSCOPE,NIL)
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST ORDSCOPE(TOPSCOPE,NIL)
RDDTEST ORDSCOPE(BOTTOMSCOPE,NIL)
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST ORDSCOPE(TOPSCOPE,{||'3'})
RDDTEST ORDSCOPE(BOTTOMSCOPE,{||'4'})
RDDTEST DBORDERINFO(DBOI_SCOPETOP)
RDDTEST DBORDERINFO(DBOI_SCOPEBOTTOM)
RDDTEST ORDSCOPE({},'3')
RDDTEST ORDSCOPE(BOTTOMSCOPE,'4')
RDDTEST ORDSCOPE()
RDDTEST ORDSCOPE(TOPSCOPE)
RDDTEST ORDSCOPE(BOTTOMSCOPE)
RDDTEST ORDSCOPE(TOPSCOPE)
RDDTEST ORDSCOPE(BOTTOMSCOPE)
RDDTEST ORDSCOPE(TOPSCOPE,'3')
RDDTEST ORDSCOPE(0)
RDDTEST ORDSCOPE(1)
RDDTEST ORDSCOPE(2)
RDDTEST ORDSCOPE(3)
#ifdef _TEST_DESCEND_
RDDTEST ORDDESCEND(,,.t.)
RDDTEST ORDSCOPE(0)
RDDTEST ORDSCOPE(1)
RDDTEST ORDSCOPE(2)
RDDTEST ORDSCOPE(3)
RDDTEST ORDDESCEND(,,.f.)
#endif
RDDTEST ORDSCOPE(TOPSCOPE,NIL)
#endif

#ifdef _TEST_UNIQUE_
RDDTEST INDEX on FSTR tag TG_C to _DBNAME
RDDTEST DBGOTOP()
RDDTEST ORDSKIPUNIQUE()
RDDTEST ORDSKIPUNIQUE(1)
RDDTEST ORDSKIPUNIQUE(2)
RDDTEST ORDSKIPUNIQUE(-1)
RDDTEST ORDSKIPUNIQUE(-2)
RDDTEST DBGOTOP()
RDDTEST ORDSKIPUNIQUE(-1)
RDDTEST ORDSKIPUNIQUE()
RDDTEST DBGOBOTTOM()
RDDTEST ORDSKIPUNIQUE(-1)
RDDTEST ORDSKIPUNIQUE()
RDDTEST ORDSKIPUNIQUE()
RDDTEST ORDSKIPUNIQUE(-1)

RDDTEST ORDSETFOCUS(0)
RDDTEST DBGOTO(1)
RDDTEST ORDSKIPUNIQUE()
RDDTEST ORDSKIPUNIQUE(-1)

RDDTEST INDEX on FSTR tag TG_C to _DBNAME FOR FNUM!=2 .and. FNUM<4
RDDTEST DBGOTO(4)
RDDTEST ORDSKIPUNIQUE(-1)
RDDTEST DBGOTO(4)
RDDTEST ORDSKIPUNIQUE()
RDDTEST DBGOTO(13)
RDDTEST ORDSKIPUNIQUE(-1)
RDDTEST DBGOTO(13)
RDDTEST ORDSKIPUNIQUE()
#endif

RDDTEST INDEX on FSTR tag TG_C to _DBNAME FOR RECNO()!=5 DESCEND
RDDTEST DBGOTO(5)
RDDTEST DBSKIP(-1)
RDDTEST DBGOTO(5)
RDDTEST DBSKIP(1)
#ifdef _TEST_UNIQUE_
RDDTEST DBGOTO(5)
RDDTEST ORDSKIPUNIQUE(-1)
RDDTEST DBGOTO(5)
RDDTEST ORDSKIPUNIQUE()
#endif

RDDTEST INDEX on FSTR tag TG_C to _DBNAME FOR RECNO()!=5
RDDTEST DBGOTO(5)
RDDTEST DBSKIP(-1)
RDDTEST DBGOTO(5)
RDDTEST DBSKIP(1)
#ifdef _TEST_UNIQUE_
RDDTEST DBGOTO(5)
RDDTEST ORDSKIPUNIQUE(-1)
RDDTEST DBGOTO(5)
RDDTEST ORDSKIPUNIQUE()
#endif

/* filter test and skipping */
RDDTEST ORDSETFOCUS(0)
RDDTEST SET DELETE ON
RDDTEST FLOCK()
RDDTEST DBGOTO(1)
RDDTEST DBDELETE()
RDDTEST DBGOTO(3)
RDDTEST DBDELETE()
RDDTEST DBGOTO(6)
RDDTEST DBDELETE()
RDDTEST DBGOTO(7)
RDDTEST DBDELETE()
RDDTEST DBGOTO(13)
RDDTEST DBDELETE()
RDDTEST DBGOTO(14)
RDDTEST DBDELETE()
RDDTEST DBGOTO(15)
RDDTEST DBDELETE()
RDDTEST DBGOTO(16)
RDDTEST DBDELETE()
RDDTEST DBCOMMIT()
RDDTEST DBUNLOCK()

RDDTEST DBGOTOP()
RDDTEST DBSKIP(-1)
RDDTEST DBGOTOP()
RDDTEST DBSKIP(-10)
RDDTEST DBSKIP(5)
RDDTEST DBSKIP(-5)
RDDTEST DBSKIP(6)
RDDTEST DBSKIP(-7)
RDDTEST DBSKIP(8)
RDDTEST DBSKIP(-20)
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(1)
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(10)
RDDTEST DBSKIP(-5)
RDDTEST DBSKIP(5)
RDDTEST DBSKIP(-6)
RDDTEST DBSKIP(7)
RDDTEST DBSKIP(-8)
RDDTEST DBSKIP(20)
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(-20)

RDDTEST FLOCK()
RDDTEST DELETE ALL
RDDTEST DBUNLOCK()
RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()
RDDTEST DBGOTO(7)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(7)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(0)
RDDTEST DBGOTO(0)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(7)
RDDTEST DBRLOCK()
RDDTEST DBRECALL()
RDDTEST DBUNLOCK()
RDDTEST DBGOTO(4)
RDDTEST DBSKIP(-1)
RDDTEST DBGOTO(4)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(11)
RDDTEST DBSKIP(-1)
RDDTEST DBGOTO(11)
RDDTEST DBSKIP(1)

RDDTEST SET DELETE OFF
RDDTEST FLOCK()
RDDTEST RECALL ALL
RDDTEST DBUNLOCK()
RDDTEST SET DELETE ON
RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()
RDDTEST DBCOMMIT()

/* and the same but with active index */
RDDTEST ORDSETFOCUS(1)
RDDTEST SET DELETE ON
RDDTEST FLOCK()
RDDTEST DBGOTO(1)
RDDTEST DBDELETE()
RDDTEST DBGOTO(3)
RDDTEST DBDELETE()
RDDTEST DBGOTO(6)
RDDTEST DBDELETE()
RDDTEST DBGOTO(7)
RDDTEST DBDELETE()
RDDTEST DBGOTO(13)
RDDTEST DBDELETE()
RDDTEST DBGOTO(14)
RDDTEST DBDELETE()
RDDTEST DBGOTO(15)
RDDTEST DBDELETE()
RDDTEST DBGOTO(16)
RDDTEST DBDELETE()
RDDTEST DBCOMMIT()
RDDTEST DBUNLOCK()

RDDTEST DBGOTOP()
RDDTEST DBSKIP(-1)
RDDTEST DBGOTOP()
RDDTEST DBSKIP(-10)
RDDTEST DBSKIP(5)
RDDTEST DBSKIP(-5)
RDDTEST DBSKIP(6)
RDDTEST DBSKIP(-7)
RDDTEST DBSKIP(8)
RDDTEST DBSKIP(-20)
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(1)
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(10)
RDDTEST DBSKIP(-5)
RDDTEST DBSKIP(5)
RDDTEST DBSKIP(-6)
RDDTEST DBSKIP(7)
RDDTEST DBSKIP(-8)
RDDTEST DBSKIP(20)
RDDTEST DBGOBOTTOM()
RDDTEST DBSKIP(-20)

RDDTEST FLOCK()
RDDTEST DELETE ALL
RDDTEST DBCOMMIT()
RDDTEST DBUNLOCK()
RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()
RDDTEST DBGOTO(7)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(7)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(-1)
RDDTEST DBSKIP(0)
RDDTEST DBGOTO(0)
RDDTEST DBSKIP(1)
RDDTEST DBSKIP(-1)

RDDTEST DBGOTO(0)
RDDTEST DBSKIP(1)
/* This test give unrepeatable results in Clipper and I don't know why yet,
   so I temporary diable it */
#ifdef _DISABLED_
RDDTEST DBSEEK('', .t.,.f.)
RDDTEST DBSEEK('', .t.,.t.)
RDDTEST DBSEEK('', .f.,.f.)
RDDTEST DBSEEK('', .f.,.t.)
RDDTEST DBSEEK('2', .t.,.f.)
RDDTEST DBSEEK('2', .t.,.t.)
RDDTEST DBSEEK('2', .f.,.f.)
RDDTEST DBSEEK('2', .f.,.t.)
#endif

RDDTEST DBGOTO(7)
RDDTEST DBRLOCK()
RDDTEST DBRECALL()
RDDTEST DBUNLOCK()
RDDTEST DBGOTO(4)
RDDTEST DBSKIP(-1)
RDDTEST DBGOTO(4)
RDDTEST DBSKIP(1)
RDDTEST DBGOTO(11)
RDDTEST DBSKIP(-1)
RDDTEST DBGOTO(11)
RDDTEST DBSKIP(1)

RDDTEST SET DELETE OFF
RDDTEST FLOCK()
RDDTEST RECALL ALL
RDDTEST DBUNLOCK()
RDDTEST SET DELETE ON
RDDTEST DBGOTOP()
RDDTEST DBGOBOTTOM()
RDDTEST DBCOMMIT()

RDDTEST INDEX on FSTR tag TG_C to _DBNAME
RDDTEST DBSEEK(padr(' ',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr(' ',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('0',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('0',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('1',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('1',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('2',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('2',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('3',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('3',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('4',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('4',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('5',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('5',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('6',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('6',10)+" ",.t.,.t.)

RDDTEST DBSEEK(padr(' ',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr(' ',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('0',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('0',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('1',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('1',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('2',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('2',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('3',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('3',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('4',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('4',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('5',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('5',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('6',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('6',10)+"*",.t.,.t.)

#ifdef _TEST_SCOPE_
RDDTEST ORDSCOPE(TOPSCOPE,'3')
RDDTEST ORDSCOPE(BOTTOMSCOPE,'4')

RDDTEST DBSEEK(padr(' ',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr(' ',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('0',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('0',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('1',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('1',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('2',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('2',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('3',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('3',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('4',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('4',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('5',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('5',10)+" ",.t.,.t.)
RDDTEST DBSEEK(padr('6',10)+" ",.t.,.f.)
RDDTEST DBSEEK(padr('6',10)+" ",.t.,.t.)

RDDTEST DBSEEK(padr(' ',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr(' ',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('0',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('0',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('1',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('1',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('2',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('2',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('3',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('3',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('4',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('4',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('5',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('5',10)+"*",.t.,.t.)
RDDTEST DBSEEK(padr('6',10)+"*",.t.,.f.)
RDDTEST DBSEEK(padr('6',10)+"*",.t.,.t.)
#endif

return nil
