*.... Finansijsko knjigovodstvo: Knjigovodstvo - korekcije
*
CLEAR ALL
SET EXCLUSIVE OFF
SET CONFIRM OFF
SET WRAP ON
SET TALK OFF
SET ECHO OFF
SET SCOREBOARD OFF
SET EXACT OFF
*SET DATE GERMAN
SET EPOCH TO 1920
SET DATE FORMAT "dd.mm.yy"
SET ESCAPE OFF
SET COLOR TO G+/N,G+/N
PUBLIC XUSER,XADM,COMF,COMF1,REPR,F0,F5,IST,IAK,XOUR
store 0 to IST,IAK
PUBLIC DBF,OPT,NERR,XR,SNDUG,SNPOT,ESC,PRVIPUT,BRNAL,YSFKOM,ZOUR
PUBLIC SCRNNUM, MAXSCRN, OLDSCRN, AGXNTX, AGXKEY, AGXKEYR, AGXKEYC
PUBLIC ACTDB,ERR,XDAY,DDD,XMAX,MODCHECK,S0,XRBR,WSFKOM,XSFGRU,QSFGRU
PUBLIC PAGE_NO,LINE_NO,RECORD_NO,TOP_MARG,BOT_MARG,MAX_LINE,PG_FT_LINS
PUBLIC TOP_RECORD,RECORDS,RECS_ON_PG,XTIME,XDATE,OUTP_DEV,FNLST
*--------------------------------------------------------------------
do BAZEAD  &&-alokacija sifarnika na zajednickom direktorijumu
*--------------------------------------------------------------------
XUSER="þþ"
DO WHILE YEAR(DATE())<1990 .OR. LEFT(TIME(),2)='00'
  CLEAR
  @ 18,0 SAY 'Datum i vreme nisu postavljeni. Molimo vas uradite to.'
  ? CHR(7)+CHR(7)+CHR(7)
  ?
  ?
  RUN DATE
  RUN TIME
ENDDO
*--------------------------------------------------------------------
CLEAR
public XNAZFIR
use FIRMA exclusive
XNAZFIR=NAZFIR
***
XTIP_S=TIP_S
XUSER=space(8)
XUSER=alltrim(gete("USER"))
XL=len(XUSER)
XUSER=XUSER+space(8-XL)
XR=SPACE(2)
CLEAR
COMF='TIMD'
DO RAZNO
SET COLOR TO G+/ ,G+/
*
NERR=.F.
DBF="ADMINI"
OPT="S"  &&-Shared
COMF="OPEN"
DO RAZNO  &&-Use Admini shared
if NERR  &&-Open uspeo
   SET INDEX TO ADMINI
   SET FILTER TO ! DELETED()
else  &&-Open nije uspeo
   RETURN
endif
*------------------------informacije o ovlascenjima korisnika
VLADA=XUSER+'  '
COMF='ENCR'
DO RAZNO
SEEK LEFT(VLADA,8)
***
if ! found()
 CLEAR
 COMF='TIMD'
 DO RAZNO
 ?? chr(7)
 SET COLOR TO G+/ ,G+/
 @  5,0 SAY "FINANSISKO KNJIGOVODSTVO"
 @ 22,0 say "USER ne postoji u evidenciji. Konsultujte administratora !"
 WAIT
 RETURN
endif
if ADM5=.F.
 CLEAR
 COMF='TIMD'
 DO RAZNO
 ?? chr(7)
 SET COLOR TO G+/ ,G+/
 @  5,0 SAY "FINANSISKO KNJIGOVODSTVO - Knjigovodstvo - korekcije"
 @ 22,0 SAY "Zao mi je - niste autorizovani za ovaj posao. Konsultujte administratora !"
 WAIT
 RETURN
ENDIF
XR=strzero(BROJ,2)  &&-redni broj korisnika (privatna datoteka)
ZOUR="   "  &&-autorizacija za posebni our
USE
*--------------------------------------------------------------------
set key 28 to UPUT
set key -9 to DALJE  &&-F10
DO AKD0  &&-Knjigovodstvo - korekcije
RETURN
*
PROCEDURE AKD0
F0 = ' '
do while .t.
  clear
  SET COLOR TO W+/N,G+/N
  COMF='TIMD'
  DO RAZNO
  SET COLOR TO G+/N,N/W
  @ 2,0,14,79 BOX 'ÉÍ»º¼ÍÈº'
  @ 4,15 say " Korekcija proknjizenih podataka  -  Izbor posla: "
  set color to /w
  @ 24,0  say '  Izbor:   / Potvrda izbora: ÄÙ (Enter) / Prekid:'+;
              ' Esc / Uputstvo za rad: F1  '
  SET COLOR TO G+/N,N/W
  close databases
  do while .t.
   @  6,20 prompt " 1 - Korekcija proknjizene Analitike "
   @  7,20 prompt " 2 - Korekcija proknjizene Sintetike "
   @  9,20 prompt " 3 - Print FILE "
   @ 10,20 prompt " 4 - List FILE "
   @ 12,20 prompt " 5 - Kraj posla (ESC) "
   MENU TO F0
   DIRKA=lastkey()
   if DIRKA=13 .or. DIRKA=27
    *--- izvrsio je izbor ili je pritisnuo ESC
    exit
   endif
  enddo
  do case
   case F0=0.or.F0=5  &&-ESC-kraj posla
    clear
    RETURN
   case F0=1
    DO AKD1  &&-korekcija analitike
    CLOSE DATABASES
    loop
   case F0=2
    DO AKD2  &&-korekcija sintetike
    CLOSE DATABASES
    loop
   case F0=3
    *--- print
    FNLST = space(20)
    do while .T.
     @ 23,0  clear
     @ 23,0  say '3-Unesite ime FILE-a (?) :'
     @ 23,27 get FNLST PICT '!!!!!!!!!!!!!!!!!!!!'
     SET ESCAPE ON
     read
     SET ESCAPE OFF
     if lastkey()=27
      exit
     endif
     if empty(FNLST)
      ?? chr(7)
      loop
     endif
     if trim(FNLST)='?'
      *--- prikaz PRN datoteka
      save screen
      clear screen
      RUN DIR *.PRN
      wait 'Za nastavak pritisni neku dirku ...'
      restore screen
      exit
     endif
     keyboard ''
     @ 24,0
     FNLST=trim(FNLST)
     if ! file('&FNLST') .and. ! file('&FNLST..PRN')
      @ 24,0
      @ 24,0 SAY 'Datoteka &FNLST ne postoji.'
      loop
     else
      if ! file('&FNLST')
       FNLST='&FNLST..PRN'
      *RUN PRINT &FNLST
       RUN TYPE  &FNLST > PRN
      endif
     endif
     exit
    enddo
    @ 21,0
    loop
   case F0=4
    *--- list
    FNLST = space(20)
    do while .T.
     @ 23,0  clear
     @ 23,0  say '4-Unesite ime FILE-a (?) :'
     @ 23,27 get FNLST PICT '!!!!!!!!!!!!!!!!!!!!'
     SET ESCAPE ON
     read
     SET ESCAPE OFF
     if lastkey()=27
      exit
     endif
     if empty(FNLST)
      ?? chr(7)
      loop
     endif
     if trim(FNLST)='?'
      *--- prikaz PRN datoteka
      save screen
      clear screen
      RUN DIR *.PRN
      wait 'Za nastavak pritisni neku dirku ...'
      restore screen
      exit
     endif
     keyboard ''
     @ 24,0
     FNLST=trim(FNLST)
     if ! file('&FNLST') .and. ! file('&FNLST..PRN')
      @ 24,0
      @ 24,0 SAY 'Datoteka &FNLST ne postoji.'
      loop
     else
      if ! file('&FNLST')
       FNLST='&FNLST..PRN'
       RUN LIST &FNLST
      endif
     endif
     exit
    enddo
    @ 21,0
    loop
  endcase
enddo
? chr(7)
clear
close databases
RETURN
*
*
PROCEDURE UPUT
save screen
RUN LIST FKUPUT.TXT
restore screen
RETURN
*
PROCEDURE RAZNO
*******************************************************************************
*                                                                             *
*  Ovo je program u kome se nalaze rutine koje su zajednicke u aplikaciji.    *
*  Rutine se biraju u zavisnosti od promenljive COMF:                         *
*                                                                             *
*   1. COMF='YDAT' - Pretvaranje datuma  XDATED  u Julijanski oblik u DDD     *
*   2. COMF='DATY' - Pretvaranje Julijanskog dana DDD u datum XDATED          *
*   3. COMF='TIMD' - Prikaz zaglavlja ekrana: korisnik, datum, vreme, dan     *
*   4. COMF='ENCR' - Enkripcija polja VLADA. Koristi se kod AGXADM.           *
*   5. COMF='DECR' - Dekripcija polja VLADA. Koristi se kod AGXADM.           *
*                                                                             *
*******************************************************************************
DO CASE
  CASE COMF='YDAT'
    PRIVATE MO,SW,X
    MO=MONTH(XDATED)
    SW=IIF(MOD(YEAR(XDATED),4)=0,.T.,.F.)
    DDD=0
    X=1
    DO WHILE X<MO
      DO CASE
        CASE X=2
          DDD=DDD+IIF(SW,29,28)
        CASE X=4 .OR. X=6 .OR. X=9 .OR. X=11
          DDD=DDD+30
        OTHERWISE
          DDD=DDD+31
      ENDCASE
      X=X+1
    ENDDO
    DDD=DDD+DAY(XDATED)
    RELEASE MO,SW,X
  CASE COMF='DATY'
    PRIVATE YE,MO,DA,SW,X
    YE=INT(VALDAT/1000)
    DDD=MOD(VALDAT,1000)
    SW=IIF(MOD(YE+1900,4)=0,.T.,.F.)
    X=1
    DO WHILE .T.
      DO CASE
        CASE X=2
          DDD=DDD-IIF(SW,29,28)
          IF DDD<1
            DDD=DDD+IIF(SW,29,28)
            EXIT
          ENDIF
        CASE X=4 .OR. X=6 .OR. X=9 .OR. X=11
          DDD=DDD-30
          IF DDD<1
            DDD=DDD+30
            EXIT
          ENDIF
        OTHERWISE
          DDD=DDD-31
          IF DDD<1
            DDD=DDD+31
            EXIT
          ENDIF
      ENDCASE
      X=X+1
    ENDDO
    XDATED=CTOD(STR(DDD,2)+'.'+STR(X,2)+'.'+STR(YE,2))
    RELEASE MO,SW,X
  CASE COMF='TIMD'
    PRIVATE XTIME,XDATE
    XTIME = TIME()
    XDATE = DATE()
    COMF1='DAYS'
    DO RAZNO1
    SET COLOR TO G+/ ,G+/
    @ 0,0 SAY XNAZFIR
    @ 0,24 SAY '('+XUSER
    @ 0,33 SAY '-'+XR+')'
    @ 0,40 SAY XTIME PICT "XXXXXXXX"
    SET CENTURY ON
    @ 0,50 SAY XDATE PICT "XXXXXXXXXX"
    SET CENTURY OFF
    @ 0,70 SAY XDAY PICT "XXXXXXXXXX"
    RELEASE XTIME,XDATE
  RETURN
  CASE COMF='ENCR'
    PRIVATE A,B,C,D,E,F,G,H,I
    A=CHR(ASC(VLADA)+ASC(SUBSTR(VLADA,2,1)))
    B=CHR(ASC(SUBSTR(VLADA,2,1))+ASC(SUBSTR(VLADA,3,1)))
    C=CHR(ASC(SUBSTR(VLADA,3,1))+ASC(SUBSTR(VLADA,4,1)))
    D=CHR(ASC(SUBSTR(VLADA,4,1))+ASC(SUBSTR(VLADA,5,1)))
    E=CHR(ASC(SUBSTR(VLADA,5,1))+ASC(SUBSTR(VLADA,6,1)))
    F=CHR(ASC(SUBSTR(VLADA,6,1))+ASC(SUBSTR(VLADA,7,1)))
    G=CHR(ASC(SUBSTR(VLADA,7,1))+ASC(SUBSTR(VLADA,8,1)))
    H=CHR(ASC(SUBSTR(VLADA,8,1))+ASC(SUBSTR(VLADA,9,1)))
    I=CHR(ASC(SUBSTR(VLADA,9,1))+32)
   *clear
   *? substr(vlada,1,1),substr(vlada,2,1),substr(vlada,3,1),substr(vlada,4,1),;
   *  substr(vlada,5,1),substr(vlada,6,1),substr(vlada,7,1),substr(vlada,8,1),;
   *  substr(vlada,9,1)
   *? asc(substr(vlada,1,1)),asc(substr(vlada,2,1)),asc(substr(vlada,3,1)),asc(substr(vlada,4,1)),;
   *  asc(substr(vlada,5,1)),asc(substr(vlada,6,1)),asc(substr(vlada,7,1)),asc(substr(vlada,8,1)),;
   *  asc(substr(vlada,9,1))
   *? a,b,c,d,e,f,g,h,i
   *wait
    VLADA=A+B+C+D+E+F+G+H+"  "
   *? vlada
   *wait
    RELEASE A,B,C,D,E,F,G,H,I
    RETURN
  CASE COMF='DECR'
    PRIVATE A,B,C,D,E,F,G,H,F1,F2,F3,F4,F5,F6,F7,F8
    A=ASC(VLADA)
    B=ASC(SUBSTR(VLADA,2,1))
    C=ASC(SUBSTR(VLADA,3,1))
    D=ASC(SUBSTR(VLADA,4,1))
    E=ASC(SUBSTR(VLADA,5,1))
    F=ASC(SUBSTR(VLADA,6,1))
    G=ASC(SUBSTR(VLADA,7,1))
    H=ASC(SUBSTR(VLADA,8,1))
    F8=H-32
    F7=G-F8
    F6=F-F7
    F5=E-F6
    F4=D-F5
    F3=C-F4
    F2=B-F3
    F1=A-F2
    VLADA=CHR(F1)+CHR(F2)+CHR(F3)+CHR(F4)+CHR(F5)+;
          CHR(F6)+CHR(F7)+CHR(F8)+' '
    RELEASE A,B,C,D,E,F,G,H,F1,F2,F3,F4,F5,F6,F7,F8
    RETURN
  CASE COMF='OPEN'
    PRIVATE FOREVER                && OPEN FILE
    FOREVER=10
    NERR=.T.
    USE
    DO WHILE FOREVER>0
      IF OPT='E'                   && exclusive
        USE &DBF EXCLUSIVE
      ELSE
        USE &DBF                   && shared
      ENDIF
      IF .NOT. NETERR()            && USE succeeds
        RETURN
      ENDIF
      INKEY(1)                     && wait 1 second
      FOREVER=FOREVER-1
    ENDDO
    NERR=.F.                       && USE fails
    OPT=' '
    @ 24,0
    @ 24,0 SAY 'Ne moze se pristupiti entitetu &DBF !!!.  Pritisnite neku tipku ... ' ;
           GET OPT
    READ
    RETURN
  CASE COMF='FLOC'                 && file lock
    PRIVATE FOREVER
    FOREVER=10
    NERR=.T.
    IF FLOCK()
      RETURN                       && locked
    ENDIF
    DO WHILE FOREVER>0
      INKEY(.5)                    && wait 1/2 second
      FOREVER=FOREVER-.5
      IF FLOCK()
        RETURN                     && locked
      ENDIF
    ENDDO
    NERR=.F.                       && not locked
    OPT=' '
    @ 24,0
    @ 24,0 SAY 'Neuspesno zakljucavanje entiteta &DBF !!!.  Pritisnite neku tipku ... ' ;
           GET OPT
    READ
    RETURN
  CASE COMF='RLOC'                 && record lock
    PRIVATE FOREVER
    FOREVER=10
    NERR=.T.
    IF RLOCK()
      RETURN                       && locked
    ENDIF
    DO WHILE FOREVER>0
      IF RLOCK()
        RETURN                     && locked
      ENDIF
      INKEY(.5)                    && wait 1/2 second
      FOREVER=FOREVER-.5
    ENDDO
    NERR=.F.                       && not locked
    OPT=' '
    @ 24,0
    @ 24,0 SAY 'Neuspesno zakljucavanje sloga iz &DBF !!!.  Pritisnite neku tipku ... ' ;
           GET OPT
    READ
    RETURN
  CASE COMF='ADDR'                 && add record
    PRIVATE FOREVER
    FOREVER=10
    NERR=.T.
    APPEND BLANK
    IF .NOT. NETERR()
      RETURN
    ENDIF
    DO WHILE FOREVER>0
      APPEND BLANK
      IF .NOT. NETERR()
        RETURN
      ENDIF
      INKEY(.5)                    && wait 1/2 second
      FOREVER=FOREVER-.5
    ENDDO
    NERR=.F.
    OPT=' '
    @ 24,0
    @ 24,0 SAY 'Neuspesno dodavanje novog sloga u &DBF !!!.  Pritisnite neku tipku ... ' ;
           GET OPT
    READ
    RETURN                         && not locked
ENDCASE
RETURN
*
PROCEDURE RAZNO1
*******************************************************************************
*                                                                             *
*  Ovo je program u kome se nalaze rutine koje su zajednicke u aplikaciji.    *
*  Rutine se biraju u zavisnosti od promenljive COMF1:                        *
*                                                                             *
*   1. COMF1='DAYS' - Formiranje naziva dana iz tekuceg datuma u  XDAY.       *
*                                                                             *
*******************************************************************************
DO CASE
  CASE COMF1='DAYS'
    DAY=DOW(DATE())
    DO CASE
      CASE DAY=1
        XDAY='Nedelja   '
      CASE DAY=2
        XDAY='Ponedeljak'
      CASE DAY=3
        XDAY='Utorak    '
      CASE DAY=4
        XDAY='Sreda     '
      CASE DAY=5
        XDAY='Cetvrtak  '
      CASE DAY=6
        XDAY='Petak     '
      CASE DAY=7
        XDAY='Subota    '
    ENDCASE
ENDCASE
RETURN
*
FUNCTION FOUR
if substr(XOUR,1,1)='?'
 *--- hoce pregled sifara our-a
 MPP=' '
 SAVE SCREEN
 DO IZBOR1 with MPP
 RESTORE SCREEN
 if MPP='I'
  *--- izvrsio je izbor
  XOUR=SFOUR
 else
  *--- nije izvr{io izbor
  XOUR=space(3)
 endif
 set color to /w
 @ 6,39 say XOUR
 set color to
endif
select 2  &&-Sifour/Sifour,shared
seek XOUR
if ! found()
 @ 24,0
 @ 24,0 say "Neispravna SIFRA ORG.JEDINICE -> ne postoji u sifarniku !"
 ??CHR(7)
 RETURN(.F.)
endif
@ 24,0
RETURN(.T.)
*
FUNCTION FOURQ
if substr(QOUR,1,1)='?'
 *--- hoce pregled sifara our-a
 MPP=' '
 SAVE SCREEN
 DO IZBOR1 with MPP
 RESTORE SCREEN
 if MPP='I'
  *--- izvrsio je izbor
  QOUR=SFOUR
 else
  *--- nije izvr{io izbor
  QOUR=space(3)
 endif
 set color to /w
 @ 6,58 say QOUR
 set color to
endif
if ! empty(QOUR)
 select 2  &&-Sifour/Sifour,shared
 seek QOUR
 if ! found()
  @ 24,0
  @ 24,0 say "Neispravna SIFRA ORG.JEDINICE -> ne postoji u sifarniku !"
  ??CHR(7)
  RETURN(.F.)
 endif
endif
@ 24,0
RETURN(.T.)
*
FUNCTION FKONTO1
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if substr(XKONTO,1,1)='?'
 *--- hoce pregled konta
 MPP=' '
 SAVE SCREEN
 DO IZBOR2 with MPP
 RESTORE SCREEN
 if MPP='I'
  *--- izvrsio je izbor
  XKONTO=SFKON
 else
  *--- nije izvr{io izbor
  XKONTO=space(9)
 endif
 set color to /w
 @ 8,39 say XKONTO
 set color to
endif
if len(alltrim(XKONTO))<3
 @ 24,0
 @ 24,0 say "Neispravan KONTO -> mora biti najmanje TROCIFREN !"
 ??CHR(7)
 RETURN(.F.)
endif
select 3  &&-Sifkon/Sifkon,shared
seek XKONTO
if ! found()
 @ 24,0
 @ 24,0 say "Neispravan KONTO -> ne postoji u sifarniku !"
 ??CHR(7)
 RETURN(.F.)
endif
@ 24,0
RETURN(.T.)
*
FUNCTION FSFKOM
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if substr(XSFKOM,1,1)>="?".or.;
   (substr(XSFKOM,1,1)>="A".and.substr(XSFKOM,1,1)<="Z")  &&-A:Z
 *--- hoce pregled sifara komitenata
 MPP=' '
 SAVE SCREEN
 DO IZBOR3 with MPP
 RESTORE SCREEN
 if MPP='I'
  *--- izvrsio je izbor
  XSFKOM=alltrim(SFKOM)
 else
  *--- nije izvr{io izbor
  XSFKOM=space(6)
 endif
 NN=val(XSFKOM)
 YSFKOM=strzero(NN,6)
 set color to /w
 @ 9,39 say YSFKOM
 set color to
endif
NN=val(XSFKOM)
YSFKOM=strzero(NN,6)
set color to /w
@ 9,39 say YSFKOM
set color to
XSFGRU=space(6)
select 5  &&-Sifkom/Ssifkom,shared
set order to 1
seek YSFKOM
if ! found()
 @ 24,0
 @ 24,0  say "Neispravna SIFRA KOMITENTA -> ne postoji u sifarniku !"
 ??CHR(7)
 RETURN(.F.)
endif
XSFGRU=SFGRU
@ 24,0
RETURN(.T.)
*
FUNCTION FSFKOMQ
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if substr(QSFKOM,1,1)>="?".or.;
   (substr(QSFKOM,1,1)>="A".and.substr(QSFKOM,1,1)<="Z")  &&-A:Z
 *--- hoce pregled sifara komitenata
 MPP=' '
 SAVE SCREEN
 DO IZBOR3Q with MPP
 RESTORE SCREEN
 if MPP='I'
  *--- izvrsio je izbor
  QSFKOM=alltrim(SFKOM)
 else
  *--- nije izvr{io izbor
  QSFKOM=space(6)
 endif
 set color to /w
 @ 9,58 say QSFKOM
 set color to
endif
select 5  &&-Sifkom/Ssifkom,shared
set order to 1
QSFGRU=space(6)
if ! empty(QSFKOM)
 NN=val(QSFKOM)
 WSFKOM=strzero(NN,6)
 select 5  &&-Sifkom/Ssifkom,shared
 seek WSFKOM
 if ! found()
  @ 24,0
  @ 24,0  say "Neispravna SIFRA KOMITENTA -> ne postoji u sifarniku !"
  ??CHR(7)
  RETURN(.F.)
 endif
 QSFGRU=SFGRU
endif
@ 24,0
RETURN(.T.)
*
PROCEDURE IZBOR1
PARAMETERS PP
*--- prikaz sifara our-a u "prozoru"
set color to
@  3,37,19,78 BOX 'ÚÄ¿³ÙÄÀ³'
RED=1
do while RED<16
 @ RED+3,38 say space(40)
 RED=RED+1
enddo
select 2  &&-Sifour/Sifour,shared
go top
BRSTR=1
do while .not.eof()
 BIRA=.t.
 do while BIRA
  @ 4,38 say    '   ESC   PgUp   PgDn         ENTER    '
  @ 5,38 prompt '   IZABERI   SIFRU   RADNE   JEDINICE   '
  @ 4,75 say str(BRSTR,3)
  RED=1
  do while RED<14
   @ RED+5,38 say space(40)
   RED=RED+1
  enddo
  RED=5
  do while RED<18 .and. ! eof()
   RED=RED+1
   @ RED,38 prompt " "+SFOUR+" - "+NAZOUR+"   "
   skip
  enddo
  if eof()
   @ RED+1,38 say '- K r a j -'
  endif
  MENU TO MENI3
  if MENI3=0
   RETURN
  endif
  DODIR=lastkey()
  if DODIR=13 .and. MENI3 = 1
   skip -(RED-5)
  endif
  if DODIR=13 .and. MENI3 > 1
   BIRA=.f.
  endif
  if DODIR=3 .or. DODIR=18
   BIRA=.f.
  endif
  if (DODIR != 13) .and. (DODIR != 3) .and. (DODIR != 18) .and.;
     (MENI3 > 0)
   skip -(RED-5)
  endif
  if (DODIR = 3) .and. eof()
   skip -(RED-5)
   BIRA=.t.
  endif
 enddo BIRA
 if DODIR=13
  *--- izvr{io je izbor
  BRSLOG=(RED-5)-(MENI3-2)
  skip -(BRSLOG)
  PP='I'
  exit
 endif
 if DODIR=3
  MENI3=1
 endif
 if DODIR=18
  BRSTR=BRSTR-1
  if BRSTR<1
   BRSTR=1
   skip -(RED-5)
  else
   SKIP -(RED+8)
  endif
  MENI3=1
 else
  BRSTR=BRSTR+1
 endif
enddo
RETURN
*
PROCEDURE IZBOR2
PARAMETERS PP
*--- prikaz sifara konta u "prozoru"
set color to
@  3,37,19,78 BOX 'ÚÄ¿³ÙÄÀ³'
RED=1
do while RED<16
 @ RED+3,38 say space(40)
 RED=RED+1
enddo
select 3  &&-Sifkon/Sifkon,shared
go top
BRSTR=1
do while .not.eof()
 BIRA=.t.
 do while BIRA
  @ 4,38 say    '   ESC   PgUp   PgDn         ENTER    '
  @ 5,38 prompt '        IZABERI   SIFRU   KONTA         '
  @ 4,75 say str(BRSTR,3)
  RED=1
  do while RED<14
   @ RED+5,38 say space(40)
   RED=RED+1
  enddo
  RED=5
  do while RED<18 .and. ! eof()
   RED=RED+1
   @ RED,38 prompt SFKON+"-"+NAZKON1
   skip
  enddo
  if eof()
   @ RED+1,38 say '- K r a j -'
  endif
  MENU TO MENI3
  if MENI3=0
   RETURN
  endif
  DODIR=lastkey()
  if DODIR=13 .and. MENI3 = 1
   skip -(RED-5)
  endif
  if DODIR=13 .and. MENI3 > 1
   BIRA=.f.
  endif
  if DODIR=3 .or. DODIR=18
   BIRA=.f.
  endif
  if (DODIR != 13) .and. (DODIR != 3) .and. (DODIR != 18) .and.;
     (MENI3 > 0)
   skip -(RED-5)
  endif
  if (DODIR = 3) .and. eof()
   skip -(RED-5)
   BIRA=.t.
  endif
 enddo BIRA
 if DODIR=13
  *--- izvr{io je izbor
  BRSLOG=(RED-5)-(MENI3-2)
  skip -(BRSLOG)
  PP='I'
  exit
 endif
 if DODIR=3
  MENI3=1
 endif
 if DODIR=18
  BRSTR=BRSTR-1
  if BRSTR<1
   BRSTR=1
   skip -(RED-5)
  else
   SKIP -(RED+8)
  endif
  MENI3=1
 else
  BRSTR=BRSTR+1
 endif
enddo
RETURN
*
PROCEDURE IZBOR3
PARAMETERS PP
*--- prikaz sifara komitenata u "prozoru"
*--- izgled ekrana ---------------------------------------------------
set color to
@  3,37,19,78 BOX 'ÚÄ¿³ÙÄÀ³'
RED=1
do while RED<16
 @ RED+3,38 say space(40)
 RED=RED+1
enddo
if substr(XSFKOM,1,1)="?"
 SLOVO=" "
else
 SLOVO=substr(XSFKOM,1,1)
 if (substr(XSFKOM,2,1)>="A".and.substr(XSFKOM,2,1)<="Z")
  SLOVO=SLOVO+substr(XSFKOM,2,1)
 endif
 if (substr(XSFKOM,3,1)>="A".and.substr(XSFKOM,3,1)<="Z")
  SLOVO=SLOVO+substr(XSFKOM,3,1)
 endif
endif
SLOV=trim(SLOVO)
SLEN=len(SLOV)
select 5  &&-Sifkom/Asifkom,shared
set order to 2
go top
RED=1
do while RED<16
 @ RED+3,38 say space(40)
 RED=RED+1
enddo
if SLEN=0
 *---sva slova (ceo sifarnik)
 BRSTR=1
 do while ! eof()
  BIRA=.t.
  do while BIRA
   @ 4,38 say    '   ESC   PgUp   PgDn         ENTER    '
   @ 5,38 prompt '       IZABERI  SIFRU  KOMITENTA        '
   @ 4,75 say str(BRSTR,3)
   RED=1
   do while RED<14
    @ RED+5,38 say space(40)
    RED=RED+1
   enddo
   RED=5
   do while RED<18 .and. ! eof()
    RED=RED+1
    @ RED,38 prompt SFKOM+'-'+substr(NKOM,1,33)
    skip
   enddo
   if eof()
    @ RED+1,38 say '- K r a j -'
   endif
   MENU TO MENI3
   if MENI3=0
    RETURN
   endif
   DODIR=lastkey()
   if DODIR=13 .and. MENI3 = 1
    skip -(RED-5)
   endif
   if DODIR=13 .and. MENI3 > 1
    BIRA=.f.
   endif
   if DODIR=3 .or. DODIR=18
    BIRA=.f.
   endif
   if (DODIR != 13) .and. (DODIR != 3) .and. (DODIR != 18) .and.;
      (MENI3 > 0)
    skip -(RED-5)
   endif
   if (DODIR = 3) .and. eof()
    skip -(RED-5)
    BIRA=.t.
   endif
  enddo BIRA
  if DODIR=13
   *--- izvr{io je izbor
   BRSLOG=(RED-5)-(MENI3-2)
   skip -(BRSLOG)
   PP='I'
   exit
  endif
  if DODIR=3
   MENI3=1
  endif
  if DODIR=18
   BRSTR=BRSTR-1
   if BRSTR<1
    BRSTR=1
    skip -(RED-5)
   else
    SKIP -(RED+8)
   endif
   MENI3=1
  else
   BRSTR=BRSTR+1
  endif
 enddo
else
 *---samo odredjeno slovo
 set exact off
 seek SLOV
 set exact on
 BRSTR=1
 do while ! eof() .and. substr(NKOM,1,SLEN)=SLOV
  BIRA=.t.
  do while BIRA
   @ 4,38 say    '   ESC   PgUp   PgDn         ENTER    '
   @ 5,38 prompt '  IZABERI SIFRU KOMITENTA (SLOVO: '+SLOV+')  '
   @ 4,75 say str(BRSTR,3)
   RED=1
   do while RED<14
    @ RED+5,38 say space(40)
    RED=RED+1
   enddo
   RED=5
   do while RED<18 .and. ! eof() .and. substr(NKOM,1,SLEN)=SLOV
    RED=RED+1
    @ RED,38 prompt SFKOM+'-'+substr(NKOM,1,33)
    skip
   enddo
   if eof() .or. substr(NKOM,1,SLEN)<>SLOV
    @ RED+1,38 say '- K r a j -'
   endif
   MENU TO MENI3
   if MENI3=0
    RETURN
   endif
   DODIR=lastkey()
   if DODIR=13 .and. MENI3 = 1
    skip -(RED-5)
   endif
   if DODIR=13 .and. MENI3 > 1
    BIRA=.f.
   endif
   if DODIR=3 .or. DODIR=18
    BIRA=.f.
   endif
   if (DODIR != 13) .and. (DODIR != 3) .and. (DODIR != 18) .and.;
      (MENI3 > 0)
    skip -(RED-5)
   endif
   if (DODIR = 3)
    if eof() .or. substr(NKOM,1,SLEN)<>SLOV
     skip -(RED-5)
     BIRA=.t.
    endif
   endif
  enddo BIRA
  if DODIR=13
   *--- izvr{io je izbor
   BRSLOG=(RED-5)-(MENI3-2)
   skip -(BRSLOG)
   PP='I'
   exit
  endif
  if DODIR=3
   MENI3=1
  endif
  if DODIR=18
   BRSTR=BRSTR-1
   if BRSTR<1
    BRSTR=1
    skip -(RED-5)
   else
    SKIP -(RED+8)
   endif
   MENI3=1
  else
   BRSTR=BRSTR+1
  endif
 enddo
endif
RETURN
*
PROCEDURE IZBOR3Q
PARAMETERS PP
*--- prikaz sifara komitenata u "prozoru"
*--- izgled ekrana ---------------------------------------------------
set color to
@  3,37,19,78 BOX 'ÚÄ¿³ÙÄÀ³'
RED=1
do while RED<16
 @ RED+3,38 say space(40)
 RED=RED+1
enddo
if substr(QSFKOM,1,1)="?"
 SLOVO=" "
else
 SLOVO=substr(QSFKOM,1,1)
 if (substr(QSFKOM,2,1)>="A".and.substr(QSFKOM,2,1)<="Z")
  SLOVO=SLOVO+substr(QSFKOM,2,1)
 endif
 if (substr(QSFKOM,3,1)>="A".and.substr(QSFKOM,3,1)<="Z")
  SLOVO=SLOVO+substr(QSFKOM,3,1)
 endif
endif
SLOV=trim(SLOVO)
SLEN=len(SLOV)
select 5  &&-Sifkom/Asifkom,shared
set order to 2
go top
RED=1
do while RED<16
 @ RED+3,38 say space(40)
 RED=RED+1
enddo
if SLEN=0
 *---sva slova (ceo sifarnik)
 BRSTR=1
 do while ! eof()
  BIRA=.t.
  do while BIRA
   @ 4,38 say    '   ESC   PgUp   PgDn         ENTER    '
   @ 5,38 prompt '       IZABERI  SIFRU  KOMITENTA        '
   @ 4,75 say str(BRSTR,3)
   RED=1
   do while RED<14
    @ RED+5,38 say space(40)
    RED=RED+1
   enddo
   RED=5
   do while RED<18 .and. ! eof()
    RED=RED+1
    @ RED,38 prompt SFKOM+'-'+substr(NKOM,1,33)
    skip
   enddo
   if eof()
    @ RED+1,38 say '- K r a j -'
   endif
   MENU TO MENI3
   if MENI3=0
    RETURN
   endif
   DODIR=lastkey()
   if DODIR=13 .and. MENI3 = 1
    skip -(RED-5)
   endif
   if DODIR=13 .and. MENI3 > 1
    BIRA=.f.
   endif
   if DODIR=3 .or. DODIR=18
    BIRA=.f.
   endif
   if (DODIR != 13) .and. (DODIR != 3) .and. (DODIR != 18) .and.;
      (MENI3 > 0)
    skip -(RED-5)
   endif
   if (DODIR = 3) .and. eof()
    skip -(RED-5)
    BIRA=.t.
   endif
  enddo BIRA
  if DODIR=13
   *--- izvr{io je izbor
   BRSLOG=(RED-5)-(MENI3-2)
   skip -(BRSLOG)
   PP='I'
   exit
  endif
  if DODIR=3
   MENI3=1
  endif
  if DODIR=18
   BRSTR=BRSTR-1
   if BRSTR<1
    BRSTR=1
    skip -(RED-5)
   else
    SKIP -(RED+8)
   endif
   MENI3=1
  else
   BRSTR=BRSTR+1
  endif
 enddo
else
 *---samo odredjeno slovo
 set exact off
 seek SLOV
 set exact on
 BRSTR=1
 do while ! eof() .and. substr(NKOM,1,SLEN)=SLOV
  BIRA=.t.
  do while BIRA
   @ 4,38 say    '   ESC   PgUp   PgDn         ENTER    '
   @ 5,38 prompt '  IZABERI SIFRU KOMITENTA (SLOVO: '+SLOV+')  '
   @ 4,75 say str(BRSTR,3)
   RED=1
   do while RED<14
    @ RED+5,38 say space(40)
    RED=RED+1
   enddo
   RED=5
   do while RED<18 .and. ! eof() .and. substr(NKOM,1,SLEN)=SLOV
    RED=RED+1
    @ RED,38 prompt SFKOM+'-'+substr(NKOM,1,33)
    skip
   enddo
   if eof() .or. substr(NKOM,1,SLEN)<>SLOV
    @ RED+1,38 say '- K r a j -'
   endif
   MENU TO MENI3
   if MENI3=0
    RETURN
   endif
   DODIR=lastkey()
   if DODIR=13 .and. MENI3 = 1
    skip -(RED-5)
   endif
   if DODIR=13 .and. MENI3 > 1
    BIRA=.f.
   endif
   if DODIR=3 .or. DODIR=18
    BIRA=.f.
   endif
   if (DODIR != 13) .and. (DODIR != 3) .and. (DODIR != 18) .and.;
      (MENI3 > 0)
    skip -(RED-5)
   endif
   if (DODIR = 3)
    if eof() .or. substr(NKOM,1,SLEN)<>SLOV
     skip -(RED-5)
     BIRA=.t.
    endif
   endif
  enddo BIRA
  if DODIR=13
   *--- izvr{io je izbor
   BRSLOG=(RED-5)-(MENI3-2)
   skip -(BRSLOG)
   PP='I'
   exit
  endif
  if DODIR=3
   MENI3=1
  endif
  if DODIR=18
   BRSTR=BRSTR-1
   if BRSTR<1
    BRSTR=1
    skip -(RED-5)
   else
    SKIP -(RED+8)
   endif
   MENI3=1
  else
   BRSTR=BRSTR+1
  endif
 enddo
endif
RETURN
*
PROCEDURE AKD1
*--- korekcija podataka analitike ---
KEYBOARD ''
clear
SET COLOR TO W+/N,N/W
COMF='TIMD'
DO RAZNO
SET COLOR TO G+/N,N/W
@ 2,17 say "KOREKCIJA VEC PROKNJIZENIH PODATAKA U ANALITICI"
@  3,0 say "ÚÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÂÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ¿"
@  4,0 say "³                                      POSTOJECI       ³  NOVI PODACI          ³"
@  5,0 say "ÃÄKnjige za PDV: Stopa,Knjiga,Tacka.  ù  ù ù ù ù  ù ÄÄÄÅÄù  ù ù ù ù  ù ÄÄÄÄÄÄÄÄ´"
@  6,0 say "³ Sifra radne jedinice..........(?).. ù   ù            ³ ù   ù Valutaù__.__.__ù³"
@  7,0 say "³ Sifra objekta   za RJ.........(?).. ù    ù           ³ ù   ù                 ³"
@  8,0 say "³ Konto.........................(?).. ù         ù      ³ ùxxxxxxxxxxxxxxxxxxxxù³"
@  9,0 say "³ Sifra komitenta...............(?).. ù      ù    God. ³ ù      ù    God.      ³"
@ 10,0 say "³ Broj racuna - izvorni broj/Godina.. ù         ùù    ù³ ù         ùù    ù     ³"
@ 11,0 say "³ Broj sloga za korekciju............                  ³ ù     ù               ³"
@ 12,0 say "ÃÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÁÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ´"
@ 13,0 say "³ Nalog Dat.nal. Opis                D/P      Iznos    Dat.DPO   Valuta   Slog ³"
@ 14,0 say "³                                                                              ³"
*             xxxxx xx.xx.xx xxxxxxxxxxxxxxxxxxxx x xxx.xxx.xxx,xx xx.xx.xx xx.xx.xx xxxxx
*             2     8        17                   3840             55       64       73
@ 15,0 say "³                                                                              ³"
@ 16,0 say "³                                                                              ³"
@ 17,0 say "³                                                                              ³"
@ 18,0 say "³                                                                              ³"
@ 19,0 say "³                                                                              ³"
@ 20,0 say "³                                                                              ³"
@ 21,0 say "³                                                                              ³"
@ 22,0 say "ÀÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÙ"
select 6
NERR=.F.
do while ! NERR
 DBF=ODEDBF
 OPT="S"  &&-Shared
 COMF="OPEN"
 DO RAZNO  &&-Use Sifode shared
 if NERR  &&-Open uspeo
    SET INDEX TO &ODENTX
    SET FILTER TO ! DELETED()
 endif
enddo
select 5
NERR=.F.
do while ! NERR
 DBF=KOMDBF
 OPT="S"  &&-Shared
 COMF="OPEN"
 DO RAZNO  &&-Use Sifkom shared
 if NERR  &&-Open uspeo
    SET INDEX TO &KOMSIF,&KOMABC
    SET FILTER TO ! DELETED()
 endif
enddo
select 3
NERR=.F.
do while ! NERR
 DBF=KONDBF
 OPT="S"  &&-Shared
 COMF="OPEN"
 DO RAZNO  &&-Use Sifkon shared
 if NERR  &&-Open uspeo
    SET INDEX TO &KONNTX
    SET FILTER TO ! DELETED()
 endif
enddo
select 2
NERR=.F.
do while ! NERR
 DBF=OURDBF
 OPT="S"  &&-Shared
 COMF="OPEN"
 DO RAZNO  &&-Use Sifour shared
 if NERR  &&-Open uspeo
    SET INDEX TO &OURNTX
    SET FILTER TO ! DELETED()
 endif
enddo
select 1
*-use  KUPDOB index OKUPDOB,KKUPDOB,RKUPDOB,VKUPDOB,ZKUPDOB
NERR=.F.
do while ! NERR
 DBF="KUPDOB"
 OPT="S"  &&-Shared
 COMF="OPEN"
 DO RAZNO  &&-Use Kupdob shared
 if NERR  &&-Open uspeo
    SET INDEX TO OKUPDOB,KKUPDOB,RKUPDOB,VKUPDOB,ZKUPDOB
    SET FILTER TO ! DELETED()
 endif
enddo
*----------------------------------------------------------------------
public TSLOG,XI
declare TSLOG[200]
do while .t.
 for I=1 to 200
  TSLOG[I]=0
 next
 XI=0
 store space(3) to XOUR,QOUR
 store space(3) to XSFODE,QSFODE
 XKONTO="         "
 store space(6) to XSFKOM,QSFKOM,YSFKOM,WSFKOM
 store space(6) to XSFGRU,QSFGRU
 store 0 to XGODINA,QGODINA
 store 0 to XSLOG
 store space(9) to XIZVBR,QIZVBR
 store ctod("  .  .  ") to XVALUTA
 store ctod("  .  .  ") to QVALUTA
 store space(20) to XOPIS,QOPIS
 store 0 to XSTOPA,QSTOPA
 store " " to XKNJIGA,QKNJIGA
 store 0 to XTACKA,QTACKA
 @  5,39 say "  "
 @  5,44 say " "
 @  5,48 say "  "
 @  5,58 say "  "
 @  5,63 say " "
 @  5,67 say "  "
 @  6,39 say "   "
 @  6,58 say "   "
 @  6,70 say "  .  .  "
 @  7,39 say "   "
 @  7,58 say "   "
 @  8,39 say "         "
 @  8,58 say space(20)
 @  9,39 say "      "
 @  9,58 say "      "
 @ 10,39 say "         "
 @ 10,50 say "    "
 @ 10,58 say "         "
 @ 10,69 say "    "
 @ 11,58 say "      "
 for I=14 to 21
  @ I,1 say space(78)
 next
 @ 23,0 clear
 @ 24,0 say "Unesi podatke za pronalazenje STAVKI ...   (ESC-prekid rada)"
 @  6,39 get XOUR picture "!99" valid FOUR()
 @  7,39 get XSFODE picture "!99" valid FSFODE()
 @  8,39 get XKONTO picture "!99999999" valid FKONTO1()
 @  9,39 get XSFKOM picture "!!!999" valid FSFKOM()
 @ 10,39 get XIZVBR picture "!!!!!!!!!"
 @ 10,50 get XGODINA picture "9999"
 set escape on
 read
 set escape off
 if lastkey()=27
  return
 endif
 select 1  &&-Kupdob/Okupdob,shared
 KLJUC=XOUR+XSFODE+XKONTO+YSFKOM+str(XGODINA,4)+XIZVBR
 seek KLJUC
 if ! found()
  ?? chr(7)
  @ 23,0 clear
  @ 23,0 say "Nema podataka za navedenu RAD.JED, OBJEKAT, KONTO, KOMITENTA,GODINU i RACUN !"
  ?? inkey(3)
  loop
 endif
 RED=14
 do while ! eof().and.OUR=XOUR.and.SFODE=XSFODE.and.KONTO=XKONTO.and.;
                      SFKOM=YSFKOM.and.GODINA=XGODINA.and.IZVBR=XIZVBR
  set color to /w
  @ RED,2  say NALOG picture "99999"
  @ RED,8  say DATNAL
  @ RED,17 say OPIS
  @ RED,38 say DP
  @ RED,40 say IZNOS picture "@E 999,999,999.99"
  @ RED,55 say DATDPO
  @ RED,64 say VALUTA
  @ RED,73 say recno() picture "999999"
  set color to
  XI=XI+1
  TSLOG[XI]=recno()
  RED=RED+1
  if RED>21
   skip
   exit
  endif
  skip
 enddo
 set color to
 @ 23,0 clear
 if RED>21
  @ 23,0 say "F10 - sledeca grupa podataka ..."
 endif
 @ 24,0 say "Unesi NOVE PODATKE za izmenu PRIKAZANIH ...  (ESC-prekid rada)"
 @ 11,58 get XSLOG   picture "999999" valid FXSLOG()
 @  5,58 get QSTOPA  picture "99" valid FSTOPA()
 @  5,63 get QKNJIGA picture "9" valid FKNJIGA()
 @  5,67 get QTACKA  picture "99" valid FTACKA()
 @  6,58 get QOUR    picture "!99" valid FOURQ()
 @  7,58 get QSFODE  picture "!99" valid FSFODEQ()
 @  8,58 get QOPIS   picture "!!!!!!!!!!!!!!!!!!!!"
 @  9,58 get QSFKOM  picture "!!!999" valid FSFKOMQ()
 @ 10,58 get QIZVBR  picture "!!!!!!!!!"
 @  6,70 get QVALUTA
 @ 10,69 get QGODINA picture "9999"
 set escape on
 read
 set escape off
 if lastkey()=27
  loop
 endif
 if QOUR="   ".and.QSFODE="   ".and.QSFKOM="      ".and.QGODINA=0.and.QIZVBR=space(9);
    .and.QVALUTA=ctod("  .  .  ").and.QOPIS=space(20)
  ?? chr(7)
  @ 24,0
  @ 24,0 say "Nema izmena ..."
  ?? inkey(2)
  loop
 endif
 ?? chr(7)
 @ 24,0
 @ 24,0 say "Komitent / Broj racuna - IZMENA U TOKU ..."
 RED=14
 select 1  &&-Kupdob/Okupdob,shared
*KLJUC=XOUR+XSFODE+XKONTO+YSFKOM+XIZVBR
 goto XSLOG
 if OUR=XOUR.and.SFODE=XSFODE.and.KONTO=XKONTO.and.SFKOM=YSFKOM.and.;
    GODINA=XGODINA.and.IZVBR=XIZVBR
  do while .T.
   NERR=.F.
   DBF="KUPDOB"
   OPT="S"  &&-Shared
   COMF="RLOC"
   DO RAZNO  &&-Lock record
   if NERR  &&-Lock record je uspeo
    exit
   else  &&-Lock record nije uspeo
    loop
   endif
  enddo
  if QOUR<>"   "
   replace OUR with QOUR
   select 2  &&-Sifour
   seek QOUR
   if found()
    select 1  &&-Kupdob
    replace SFREO with B->SFREO
   endif
   select 1  &&-Kupdob
  endif
  if QSFODE<>"   "
   replace SFODE with QSFODE
  endif
  if QSFKOM<>"      "
   replace SFKOM with WSFKOM,SFGRU with QSFGRU
  endif
  if QIZVBR<>space(9)
   replace IZVBR with QIZVBR
  endif
  if QGODINA>0
   replace GODINA with QGODINA
  endif
  if QVALUTA<>ctod("  .  .  ")
   replace VALUTA with QVALUTA
  endif
  if QOPIS<>space(20)
   replace OPIS with QOPIS
  endif
  if QKNJIGA<>" "
   replace STOPA with QSTOPA,KNJIGA with QKNJIGA,TACKA with QTACKA
  endif
  UNLOCK
 endif
enddo
RETURN
*
PROCEDURE DALJE
*-aktivira se kada se pritisne F10
set color to
for I=14 to 21
 @ I,2  say space(76)
next
if F0=1  &&-analitika
 RED=14
 do while ! eof().and.OUR=XOUR.and.SFODE=XSFODE.and.KONTO=XKONTO.and.;
                      SFKOM=YSFKOM.and.GODINA=XGODINA.and.IZVBR=XIZVBR
  set color to /w
  @ RED,2  say NALOG picture "99999"
  @ RED,8  say DATNAL
  @ RED,17 say OPIS
  @ RED,38 say DP
  @ RED,40 say IZNOS picture "@E 999,999,999.99"
  @ RED,55 say DATDPO
  @ RED,64 say VALUTA
  @ RED,73 say recno() picture "999999"
  set color to
  XI=XI+1
  TSLOG[XI]=recno()
  RED=RED+1
  if RED>21
   skip
   exit
  endif
  skip
 enddo
elseif F0=2  &&-sintetika
 RED=14
 do while ! eof().and.OUR=XOUR.and.SFODE=XSFODE.and.KONTO=XKONTO.and.;
                      DATNAL=XDATNA.and.NALOG=XNALOG
  set color to /w
  @ RED,2  say NALOG picture "99999"
  @ RED,8  say DATNAL
  @ RED,17 say OPIS
  @ RED,38 say DP
  @ RED,40 say IZNOS picture "@E 999,999,999.99"
  @ RED,55 say DATDPO
  @ RED,73 say recno() picture "999999"
  set color to
  XI=XI+1
  TSLOG[XI]=recno()
  RED=RED+1
  if RED>21
   skip
   exit
  endif
  skip
 enddo
endif
@ 23,0
if RED>21
 @ 23,0 say "F10 - sledeca grupa podataka ..."
endif
RETURN
*
FUNCTION FSFODE
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if substr(XSFODE,1,1)='?'
 *--- hoce pregled sifara odeljenja
 MPP=' '
 SAVE SCREEN
 DO IZBORO with MPP
 RESTORE SCREEN
 if MPP='I'
  *--- izvrsio je izbor
  XSFODE=SFODE
 else
  *--- nije izvr{io izbor
  XSFODE=space(3)
 endif
 set color to /w
 @ 7,39 say XSFODE
 SET COLOR TO W+/N,G+/N
endif
if empty(XSFODE)
 @ 24,0
 @ 24,0 SAY "OBAVEZNO unesi SIFRU OBJEKTA (moze kao sifra RJD)   !"
 ??CHR(7)
 RETURN(.F.)
endif
NN=val(XSFODE)
XSFODE=strzero(NN,3)
@ 7,39 say XSFODE
select 6  &&...Sifode
seek XSFODE
if ! found()
 @ 24,0
 @ 24,0 SAY "Uneta  SIFRA OBJEKTA  ne postoji u sifarniku !"
 ??CHR(7)
 RETURN(.F.)
endif
if SFOUR<>XOUR
 @ 24,0
 @ 24,0 SAY "Uneta  SIFRA OBJEKTA  NE ODGOVARA SIFRI RJD !"
 ??CHR(7)
 RETURN(.F.)
endif
@ 24,0
RETURN(.T.)
*
FUNCTION FSFODEQ
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if substr(QSFODE,1,1)='?'
 *--- hoce pregled sifara odeljenja
 MPP=' '
 SAVE SCREEN
 DO IZBORO with MPP
 RESTORE SCREEN
 if MPP='I'
  *--- izvrsio je izbor
  QSFODE=SFODE
 else
  *--- nije izvr{io izbor
  QSFODE=space(3)
 endif
 set color to /w
 @ 7,58 say QSFODE
 SET COLOR TO W+/N,G+/N
endif
if ! empty(QOUR)
 if empty(QSFODE)
  @ 24,0
  @ 24,0 SAY "OBAVEZNO unesi SIFRU OBJEKTA (moze kao sifra RJD)   !"
  ??CHR(7)
  RETURN(.F.)
 endif
else
 if ! empty(QSFODE)
  @ 24,0
  @ 24,0 SAY "Ako upises SIFRU OBJEKTA, upisi i SIFRU RJD   !"
  ??CHR(7)
  RETURN(.F.)
 endif
 RETURN(.T.)
endif
NN=val(QSFODE)
QSFODE=strzero(NN,3)
@ 7,58 say QSFODE
select 6  &&...Sifode
seek QSFODE
if ! found()
 @ 24,0
 @ 24,0 SAY "Uneta  SIFRA OBJEKTA  ne postoji u sifarniku !"
 ??CHR(7)
 RETURN(.F.)
endif
if ! empty(QOUR)
 if QOUR<>SFOUR  &&-iz Sifode.dbf
  @ 24,0
  @ 24,0 SAY "Uneta  SIFRA OBJEKTA  ne odgovara unetoj SIFRI RADNE JEDINICE !"
  ??CHR(7)
  RETURN(.F.)
 endif
endif
@ 24,0
RETURN(.T.)
*
PROCEDURE IZBORO
PARAMETERS PP
*--- prikaz sifara odeljenja u "prozoru"
@  3,37,19,78 BOX 'ÚÄ¿³ÙÄÀ³'
RED=1
do while RED<16
 @ RED+3,38 say space(40)
 RED=RED+1
enddo
select 6  &&-Sifode
go top
BRSTR=1
do while .not.eof()
 BIRA=.t.
 do while BIRA
  @ 4,38 say    '   ESC   PgUp   PgDn         ENTER    '
  @ 5,38 prompt '        IZABERI SIFRU OBJEKTA           '
  @ 4,75 say str(BRSTR,3)
  RED=1
  do while RED<14
   @ RED+5,38 say space(40)
   RED=RED+1
  enddo
  RED=5
  do while RED<18 .and. ! eof()
   RED=RED+1
   @ RED,38 prompt " "+SFODE+" "+substr(NAZODE,1,31)+" "
   skip
  enddo
  if eof()
   @ RED+1,38 say '- K r a j -'
  endif
  MENU TO MENI3
  if MENI3=0
   RETURN
  endif
  DODIR=lastkey()
  if DODIR=13 .and. MENI3 = 1
   skip -(RED-5)
  endif
  if DODIR=13 .and. MENI3 > 1
   BIRA=.f.
  endif
  if DODIR=3 .or. DODIR=18
   BIRA=.f.
  endif
  if (DODIR != 13) .and. (DODIR != 3) .and. (DODIR != 18) .and.;
     (MENI3 > 0)
   skip -(RED-5)
  endif
  if (DODIR = 3) .and. eof()
   skip -(RED-5)
   BIRA=.t.
  endif
 enddo BIRA
 if DODIR=13
  *--- izvr{io je izbor
  BRSLOG=(RED-5)-(MENI3-2)
  skip -(BRSLOG)
  PP='I'
  exit
 endif
 if DODIR=3
  MENI3=1
 endif
 if DODIR=18
  BRSTR=BRSTR-1
  if BRSTR<1
   BRSTR=1
   skip -(RED-5)
  else
   SKIP -(RED+8)
  endif
  MENI3=1
 else
  BRSTR=BRSTR+1
 endif
enddo
RETURN
*
FUNCTION FXSLOG
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if XSLOG=0
 @ 24,0
 @ 24,0 SAY "OBAVEZNO unesi BROJ SLOGA (REDA) koji zelis da KORIGUJES !"
 ??CHR(7)
 RETURN(.F.)
endif
NADJEN=0
for I=1 to XI
 if TSLOG[I]=XSLOG
  NADJEN=1
  exit
 endif
next
if NADJEN=0
 @ 24,0
 @ 24,0 SAY "Uneti BROJ SLOGA ne postoji ZA PODATKE NA EKRANU !?"
 ??CHR(7)
 RETURN(.F.)
endif
goto XSLOG
if F0=1  &&-analitika
 QOUR=OUR; QSFODE=SFODE; QOPIS=OPIS; QSFKOM=SFKOM; QIZVBR=IZVBR
 QVALUTA=VALUTA; QGODINA=GODINA
 QSTOPA=STOPA; QKNJIGA=KNJIGA; QTACKA=TACKA
 set color to /w
 @  5,39 say STOPA picture "99"
 @  5,44 say KNJIGA picture "!"
 @  5,48 say TACKA picture "99"
 *
 @  5,58 say QSTOPA picture "99"
 @  5,63 say QKNJIGA picture "!"
 @  5,67 say QTACKA picture "99"
 *
 @  6,58 say QOUR   picture "!99"
 @  7,58 say QSFODE picture "!99"
 @  8,58 say QOPIS  picture "!!!!!!!!!!!!!!!!!!!!"
 @  9,58 say QSFKOM picture "!!!999"
 @ 10,58 say QIZVBR picture "!!!!!!!!!"
 @  6,70 say QVALUTA
 @ 10,69 say QGODINA picture "9999"
 set color to
elseif F0=2  &&-sintetika
 QOUR=OUR; QSFODE=SFODE; QOPIS=OPIS
 set color to /w
 @  6,58 say QOUR   picture "!99"
 @  7,58 say QSFODE picture "!99"
 @  8,58 say QOPIS  picture "!!!!!!!!!!!!!!!!!!!!"
 set color to
endif
@ 24,0
RETURN(.T.)
*
PROCEDURE AKD2
*--- korekcija podataka sintetike ---
KEYBOARD ''
clear
SET COLOR TO W+/N,N/W
COMF='TIMD'
DO RAZNO
SET COLOR TO G+/N,N/W
@ 2,17 say "KOREKCIJA VEC PROKNJIZENIH PODATAKA U SINTETICI"
@  3,0 say "ÚÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÂÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ¿"
@  4,0 say "³                                      POSTOJECI       ³  NOVI PODACI          ³"
@  5,0 say "ÃÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÅÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ´"
@  6,0 say "³ Sifra radne jedinice..........(?).. ù   ù            ³ ù   ù                 ³"
@  7,0 say "³ Sifra objekta   za RJ.........(?).. ù    ù           ³ ù   ù                 ³"
@  8,0 say "³ Konto.........................(?).. ù         ù      ³ ùxxxxxxxxxxxxxxxxxxxxù³"
@  9,0 say "³ Broj naloga........................ ù     ù          ³                       ³"
@ 10,0 say "³ Datum naloga....................... ù        ù       ³                       ³"
@ 11,0 say "³ Broj sloga za korekciju............                  ³ ù     ù               ³"
@ 12,0 say "ÃÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÁÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ´"
@ 13,0 say "³ Nalog Dat.nal. Opis                D/P      Iznos    Dat.DPO            Slog ³"
@ 14,0 say "³                                                                              ³"
*             xxxxx xx.xx.xx xxxxxxxxxxxxxxxxxxxx x xxx.xxx.xxx,xx xx.xx.xx          xxxxx
*             2     8        17                   3840             55                73
@ 15,0 say "³                                                                              ³"
@ 16,0 say "³                                                                              ³"
@ 17,0 say "³                                                                              ³"
@ 18,0 say "³                                                                              ³"
@ 19,0 say "³                                                                              ³"
@ 20,0 say "³                                                                              ³"
@ 21,0 say "³                                                                              ³"
@ 22,0 say "ÀÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÙ"
select 6
NERR=.F.
do while ! NERR
 DBF=ODEDBF
 OPT="S"  &&-Shared
 COMF="OPEN"
 DO RAZNO  &&-Use Sifode shared
 if NERR  &&-Open uspeo
    SET INDEX TO &ODENTX
    SET FILTER TO ! DELETED()
 endif
enddo
select 3
NERR=.F.
do while ! NERR
 DBF=KONDBF
 OPT="S"  &&-Shared
 COMF="OPEN"
 DO RAZNO  &&-Use Sifkon shared
 if NERR  &&-Open uspeo
    SET INDEX TO &KONNTX
    SET FILTER TO ! DELETED()
 endif
enddo
select 2
NERR=.F.
do while ! NERR
 DBF=OURDBF
 OPT="S"  &&-Shared
 COMF="OPEN"
 DO RAZNO  &&-Use Sifour shared
 if NERR  &&-Open uspeo
    SET INDEX TO &OURNTX
    SET FILTER TO ! DELETED()
 endif
enddo
select 1
*-use  GLAKNG index OGLAKNG,KGLAKNG,RGLAKNG
NERR=.F.
do while ! NERR
 DBF="GLAKNG"
 OPT="S"  &&-Shared
 COMF="OPEN"
 DO RAZNO  &&-Use Glakng shared
 if NERR  &&-Open uspeo
    SET INDEX TO OGLAKNG,KGLAKNG,RGLAKNG
    SET FILTER TO ! DELETED()
 endif
enddo
*----------------------------------------------------------------------
public TSLOG,XI
declare TSLOG[200]
do while .t.
 for I=1 to 200
  TSLOG[I]=0
 next
 XI=0
 store space(3) to XOUR,QOUR
 store space(3) to XSFODE,QSFODE
 XKONTO="         "
 XNALOG=0
 XDATNA=ctod("  .  .  ")
 store space(20) to XOPIS,QOPIS
 store 0 to XSLOG
 @  6,39 say "   "
 @  6,58 say "   "
 @  7,39 say "   "
 @  7,58 say "   "
 @  8,39 say "         "
 @  8,58 say space(20)
 @  9,39 say "     "
 @ 10,39 say "        "
 @ 11,58 say "      "
 for I=14 to 21
  @ I,1 say space(78)
 next
 @ 23,0 clear
 @ 24,0 say "Unesi podatke za pronalazenje STAVKI ...   (ESC-prekid rada)"
 @  6,39 get XOUR picture "!99" valid FOUR()
 @  7,39 get XSFODE picture "!99" valid FSFODE()
 @  8,39 get XKONTO picture "!99999999" valid FKONTO1()
 @  9,39 get XNALOG picture "99999" valid FNALOG()
 @ 10,39 get XDATNA
 set escape on
 read
 set escape off
 if lastkey()=27
  return
 endif
 select 1  &&-Glakng/Oglakng,shared
 KLJUC=XOUR+XSFODE+XKONTO+dtos(XDATNA)+str(XNALOG,5)
 seek KLJUC
 if ! found()
  ?? chr(7)
  @ 23,0 clear
  @ 23,0 say "Nema podataka za navedenu RAD.JED, OBJEKAT, KONTO, BROJ i DATUM NALOGA !"
  ?? inkey(3)
  loop
 endif
 RED=14
 do while ! eof().and.OUR=XOUR.and.SFODE=XSFODE.and.KONTO=XKONTO.and.;
                      DATNAL=XDATNA.and.NALOG=XNALOG
  set color to /w
  @ RED,2  say NALOG picture "99999"
  @ RED,8  say DATNAL
  @ RED,17 say OPIS
  @ RED,38 say DP
  @ RED,40 say IZNOS picture "@E 999,999,999.99"
  @ RED,55 say DATDPO
  @ RED,73 say recno() picture "999999"
  set color to
  XI=XI+1
  TSLOG[XI]=recno()
  RED=RED+1
  if RED>21
   skip
   exit
  endif
  skip
 enddo
 set color to
 @ 23,0 clear
 if RED>21
  @ 23,0 say "F10 - sledeca grupa podataka ..."
 endif
 @ 24,0 say "Unesi NOVE PODATKE za izmenu PRIKAZANIH ...  (ESC-prekid rada)"
 @ 11,58 get XSLOG  picture "999999" valid FXSLOG()
 @  6,58 get QOUR   picture "!99" valid FOURQ()
 @  7,58 get QSFODE picture "!99" valid FSFODEQ()
 @  8,58 get QOPIS  picture "!!!!!!!!!!!!!!!!!!!!"
 set escape on
 read
 set escape off
 if lastkey()=27
  loop
 endif
 if QOUR="   ".and.QSFODE="   ".and.QOPIS=space(20)
  ?? chr(7)
  @ 24,0
  @ 24,0 say "Nema izmena ..."
  ?? inkey(2)
  loop
 endif
 ?? chr(7)
 @ 24,0
 @ 24,0 say "Radna jedinica / Objekat - IZMENA U TOKU ..."
 RED=14
 select 1  &&-Glakng/Oglakng,shared
 goto XSLOG
 if OUR=XOUR.and.SFODE=XSFODE.and.KONTO=XKONTO.and.NALOG=XNALOG
  do while .T.
   NERR=.F.
   DBF="GLAKNG"
   OPT="S"  &&-Shared
   COMF="RLOC"
   DO RAZNO  &&-Lock record
   if NERR  &&-Lock record je uspeo
    exit
   else  &&-Lock record nije uspeo
    loop
   endif
  enddo
  if QOUR<>"   "
   replace OUR with QOUR
   select 2  &&-Sifour
   seek QOUR
   if found()
    select 1  &&-Glakng
    replace SFREO with B->SFREO
   endif
   select 1  &&-Glakng
  endif
  if QSFODE<>"   "
   replace SFODE with QSFODE
  endif
  if QOPIS<>space(20)
   replace OPIS with QOPIS
  endif
  UNLOCK
 endif
enddo
RETURN
*
FUNCTION FNALOG
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if XNALOG=0
 @ 24,0
 @ 24,0 say "OBAVEZNO upisi BROJ NALOGA (0=pocetno stanje i ne moze se menjati)."
 ??CHR(7)
 RETURN(.F.)
endif
@ 24,0
RETURN(.T.)
*
FUNCTION FSTOPA
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if ! (QSTOPA=0.or.QSTOPA=10.or.QSTOPA=20)
 @ 24,0
 @ 24,0 say "Upisi PORESKU STOPU: 0 , 10 ili 20 %  !"
 ??CHR(7)
 RETURN(.F.)
endif
@ 24,0
RETURN(.T.)
*
FUNCTION FKNJIGA
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if ! (QKNJIGA="1".or.QKNJIGA="2".or.QKNJIGA="3".or.QKNJIGA="6".or.;
      QKNJIGA="7".or.QKNJIGA="4".or.QKNJIGA="5".or.QKNJIGA="8".or.;
      QKNJIGA="9".or.QKNJIGA=" ")
 @ 24,0
 @ 24,0 say "Upisi KNJIGU: 1, 2, 3, 6, 7 (ulaz) ili 4, 5, 8, 9 (izlaz) "
 ??CHR(7)
 RETURN(.F.)
endif
if QSTOPA>0.and.QKNJIGA=" "
 @ 24,0
 @ 24,0 say "Ako upises PORESKU STOPU, tada upisi i KNJIGU za PDV  !? "
 ??CHR(7)
 RETURN(.F.)
endif
@ 24,0
RETURN(.T.)
*
FUNCTION FTACKA
if lastkey()=5
 @ 24,0
 RETURN(.T.)
endif
if QKNJIGA="1"
 if ! (QTACKA=00.or.QTACKA=19)
  @ 24,0
  @ 24,0 say "Za KNJIGU=1, TACKA moze: 00 ili 19 "
  ??CHR(7)
  RETURN(.F.)
 endif
endif
if QKNJIGA="2"
 if ! (QTACKA=07.or.QTACKA=08.or.QTACKA=09.or.;
       QTACKA=10.or.QTACKA=11.or.QTACKA=12)
  @ 24,0
  @ 24,0 say "Za KNJIGU=2, TACKA moze: 07, 09, 09, 10, 11, 12 "
  ??CHR(7)
  RETURN(.F.)
 endif
endif
if QKNJIGA="3"
 if ! (QTACKA=13.or.QTACKA=14)
  @ 24,0
  @ 24,0 say "Za KNJIGU=3, TACKA moze: 13, 14 "
  ??CHR(7)
  RETURN(.F.)
 endif
endif
if QKNJIGA="4"
 if ! (QTACKA=00.or.QTACKA=15.or.QTACKA=18.or.;
       QTACKA=20.or.QTACKA=21)
  @ 24,0
  @ 24,0 say "Za KNJIGU=4, TACKA moze: 00, 15, 18, 20, 21 "
  ??CHR(7)
  RETURN(.F.)
 endif
endif
if QKNJIGA="5"
 if ! (QTACKA=21.or.QTACKA=22.or.QTACKA=23.or.QTACKA=24)
  @ 24,0
  @ 24,0 say "Za KNJIGU=5, TACKA moze: 21, 22, 23, 24 "
  ??CHR(7)
  RETURN(.F.)
 endif
endif
if QKNJIGA="8"
 if ! (QTACKA=00.or.QTACKA=37.or.QTACKA=38)
  @ 24,0
  @ 24,0 say "Za KNJIGU=5, TACKA moze: 00, 37, 38 "
  ??CHR(7)
  RETURN(.F.)
 endif
endif
if QKNJIGA="9"
 if ! (QTACKA=06.or.QTACKA=07.or.QTACKA=08)
  @ 24,0
  @ 24,0 say "Za KNJIGU=5, TACKA moze: 00, 07, 08 "
  ??CHR(7)
  RETURN(.F.)
 endif
endif
@ 24,0
RETURN(.T.)
*
