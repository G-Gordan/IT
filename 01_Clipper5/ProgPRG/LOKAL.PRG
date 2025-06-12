**********************************************************
* LOKAL.PRG - PROGRAM LOKALNE BANKE PODATAKA (NOVA KONTA)
**********************************************************
* PROCEDURE u programu
* LOKAM  - Glavni meni
* GLPR   - Glavna procedura
* CEKA   - Procedura za cekanje
* UPUT   - Uputstvo
* MIZB   - Maska za izbor unosa
* UNOS   - Unos jednog dokumenta
* ZAG1   - Provera zaglavlja
* ZAG2   - Postavka reda zaglavlja
* RED1   - Postavka reda za unos
* RED2   - Unos jednog reda
* STOV   - Unos stovarista
* LOKO   - Unos lokomotiva
* ST20   - Unos stovarista za MAT-20
* DOBA   - Unos dobavljaca i izvodjaca radova
* VKVK   - Unos VK
* BRDO   - Unos broja dokumenta
* MESE   - Unos meseca
* KOLI   - Unos kolicine i broja motora
* SESE   - Unos sektor,sekcije
* OSNO   - Unos osnova
* MD10   - Modul 10
* ARTI   - Unos artikla
* EKR1   - Kretanje po ekranu - zaglavlje
* EKR2   - Kretanje po ekranu - stavka
* IZVE   - Meni izvestaja
* ISPR   - Meni ispravki
* MATI   - Ispravka maticne
* STAN   - Ispravka stanja
* PROM   - Ispravka promena (izvodjac radova i broj motora)
* REMO   - Remonteri
* REM1   - Ispravka ili unos remontera
* REM2   - Stampa remontera
*********************************************************

********* POCETAK************
** Postavljanje setova ****

CLEAR ALL
SET WRAP ON
SET BELL OFF
SET DELETE ON
SET CURSOR OFF
SET CONFIRM OFF
SET COLOR TO gr+/b
SET DATE GERMAN
SET SCOREBOARD ON
SET MESSAGE TO 24 CENTER

******** Slika *****

CLEAR SCREEN
@ 1,8  TO 17,67 DOUBLE
@ 2,11 TO 16,64 DOUBLE
@ 4,15 SAY "ß      ÜÛÛÛÛÛÛß     ÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ"
INKEY(0.1)
@ 5,15 SAY "     ÜÛÛÛÛÛÛß     ÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ"
INKEY(0.1)
@ 6,15 SAY "   ÜÛÛÛÛÛÛß     ÜÛÛÛÛÛß"
INKEY(0.1)
@ 7,15 SAY " ÜÛÛÛÛÛÛß     ÜÛÛÛÛÛß"
INKEY(0.1)
@ 8,15 SAY "ÛÛÛÛÛÛß     ÜÛÛÛÛÛß    ÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜ"
INKEY(0.1)
@ 9,15 SAY "ÛÛÛÛß     ÜÛÛÛÛÛß    ÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜ"
INKEY(0.1)
@10,15 SAY "ÛÛß     ÜÛÛÛÛÛß    ÜÛÛÛÛß  COK Beograd  ßÛÛÛÛÜ"
INKEY(0.1)
@11,15 SAY "ß     ÜÛÛÛÛÛß    ÜÛÛÛÛß    verzija 3.2    ÛÛÛÛ"
INKEY(0.1)
@12,15 SAY "    ÜÛÛÛÛÛß    ÜÛÛÛÛß   oktobar 2001.   ÜÛÛÛÛß"
INKEY(0.1)
@13,15 SAY "  ÜÛÛÛÛÛß    ÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛß"
INKEY(0.1)
@14,15 SAY "ÜÛÛÛÛÛß    ÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛß"
INKEY(0.1)
@18,23 TO 22,53 DOUBLE
INKEY(0.1)

****Ispisuje mesto (stovariste) na kome se unose podaci

@20,28 SAY "Banka podataka :"
SELECT 3
USE mesto
@20,45 SAY mesto
DO ceka
**********************************************************

** Formira databaze i indeksiranje ***

CLEAR SCREEN
red=1
rr=0
IF ! FILE("matc.dbf")
  CREATE pmatc
  STORE "art       n10 " TO polje1
  STORE "nza       c42 " TO polje2
  STORE "jmr       c2  " TO polje3
  STORE "knt       n7  " TO polje4
  STORE "min       n11 " TO polje5
  STORE "vre       n3  " TO polje6
  STORE "ozn       n1  " TO polje7
  FOR i=1 TO 7
    STORE STR(i,1) TO broj
    APPEND BLANK
    STORE "polje"+broj TO p1
    REPLACE field_name WITH SUBSTR(&p1,1,10)
    REPLACE field_type WITH SUBSTR(&p1,11,1)
    REPLACE field_len WITH VAL(SUBSTR(&p1,12,2))
    REPLACE field_dec WITH VAL(SUBSTR(&p1,14,1))
  NEXT
  CREATE matc FROM pmatc
  INDEX ON art TO matcid
  INDEX ON STR(ozn,1)+STR(art,10) TO matcod
  USE
  ERASE pmatc.dbf
ENDIF
IF ! FILE("stan.dbf")
  CREATE pstan
  STORE "stv       n3  " TO polje10
  STORE "art       n10 " TO polje11
  STORE "knt       n7  " TO polje12
  STORE "sus       n13 " TO polje13
  STORE "sis       n13 " TO polje14
  STORE "kst       n11 " TO polje15
  STORE "kon       n1  " TO polje16
  STORE "pst       n11 " TO polje17
  STORE "dat       d8  " TO polje18
  STORE "dap       d8  " TO polje19
  FOR i=10 TO 19
    STORE STR(i,2) TO broj
    APPEND BLANK
    STORE "polje"+broj TO p1
    REPLACE field_name WITH SUBSTR(&p1,1,10)
    REPLACE field_type WITH SUBSTR(&p1,11,1)
    REPLACE field_len WITH VAL(SUBSTR(&p1,12,2))
    REPLACE field_dec WITH VAL(SUBSTR(&p1,14,1))
  NEXT
  CREATE stan FROM pstan
  INDEX ON STR(art,10)+STR(kon,1)+STR(stv,3) TO stanad
  INDEX ON STR(stv,3)+STR(art,10)+STR(kon,1) TO stansd
  INDEX ON STR(stv,3)+STR(kon,1)+STR(art,10) TO stankd
  INDEX ON STR(stv,3)+STR(kon,1)+STR(knt,7)+STR(art,10) TO standd
  USE
  ERASE pstan.dbf
ENDIF
IF ! FILE("prom.dbf")
  CREATE pprom
  STORE "stv       n3  " TO polje10
  STORE "art       n10 " TO polje11
  STORE "vrs       n2  " TO polje12
  STORE "osu       c2  " TO polje13
  STORE "mes       n2  " TO polje14
  STORE "dob       n6  " TO polje15
  STORE "brd       n5  " TO polje16
  STORE "kst       n8  " TO polje17
  STORE "ost       c41 " TO polje18
  STORE "mst       c4  " TO polje19
  STORE "mss       n2  " TO polje20
  STORE "dat       d8  " TO polje21
  STORE "dom       c30 " TO polje22
  FOR i=10 TO 22
    STORE STR(i,2) TO broj
    APPEND BLANK
    STORE "polje"+broj TO p1
    REPLACE field_name WITH SUBSTR(&p1,1,10)
    REPLACE field_type WITH SUBSTR(&p1,11,1)
    REPLACE field_len WITH VAL(SUBSTR(&p1,12,2))
    REPLACE field_dec WITH VAL(SUBSTR(&p1,14,1))
  NEXT
  CREATE prom FROM pprom
  INDEX ON STR(stv,3)+STR(mes,2)+STR(brd,5)+STR(vrs,2) TO promid
  INDEX ON STR(stv,3)+STR(art,10)+STR(mes,2)+DTOS(dat) TO promdd
  INDEX ON STR(stv,3)+STR(art,10)+STR(vrs,2)+STR(mes,2) TO promvd
  INDEX ON STR(stv,3)+STR(vrs,2)+STR(dob,6)+STR(art,10) TO prombd
  INDEX ON STR(stv,3)+STR(art,10)+STR(vrs,2)+STR(dob,6)+STR(mes,2) TO promad
  INDEX ON STR(stv,3)+STR(dob,6)+STR(art,10)+STR(vrs,2)+STR(mes,2) TO promrd
  INDEX ON STR(stv,3)+STR(dob,6)+STR(art,10)+ost+STR(vrs,2)+osu TO promod
  USE
  ERASE pprom.dbf
ENDIF

IF ! FILE("proz.dbf")
  CREATE pproz
  STORE "stv       n3  " TO polje10
  STORE "art       n10 " TO polje11
  STORE "vrs       n2  " TO polje12
  STORE "osu       c2  " TO polje13
  STORE "mes       n2  " TO polje14
  STORE "dob       n6  " TO polje15
  STORE "brd       n5  " TO polje16
  STORE "kst       n8  " TO polje17
  STORE "ost       c41 " TO polje18
  STORE "mst       c4  " TO polje19
  STORE "mss       n2  " TO polje20
  STORE "dat       d8  " TO polje21
  STORE "dom       c30 " TO polje22
  FOR i=10 TO 22
    STORE STR(i,2) TO broj
    APPEND BLANK
    STORE "polje"+broj TO p1
    REPLACE field_name WITH SUBSTR(&p1,1,10)
    REPLACE field_type WITH SUBSTR(&p1,11,1)
    REPLACE field_len WITH VAL(SUBSTR(&p1,12,2))
    REPLACE field_dec WITH VAL(SUBSTR(&p1,14,1))
  NEXT
  CREATE proz FROM pproz
  INDEX ON STR(stv)+STR(art)+DTOS(dat) TO prozsd
  USE
  ERASE pproz.dbf
ENDIF

IF ! FILE("izvr.dbf")
  CREATE pizvr
  STORE "izv       n6  " TO polje1
  STORE "dom       c30 " TO polje2
  FOR i=1 TO 2
    STORE STR(i,1) TO broj
    APPEND BLANK
    STORE "polje"+broj TO p1
    REPLACE field_name WITH SUBSTR(&p1,1,10)
    REPLACE field_type WITH SUBSTR(&p1,11,1)
    REPLACE field_len WITH VAL(SUBSTR(&p1,12,2))
    REPLACE field_dec WITH VAL(SUBSTR(&p1,14,1))
  NEXT
  CREATE izvr FROM pizvr
  INDEX ON izv TO izvrid
  USE
  ERASE pizvr.dbf
ENDIF

IF ! FILE("stiz.dbf")
  CREATE pstiz
  STORE "stv       n3  " TO polje1
  STORE "art       n10 " TO polje2
  STORE "izv       n6  " TO polje3
  STORE "ost       c41 " TO polje4
  STORE "kst       n8  " TO polje5
  FOR i=1 TO 5
    STORE STR(i,1) TO broj
    APPEND BLANK
    STORE "polje"+broj TO p1
    REPLACE field_name WITH SUBSTR(&p1,1,10)
    REPLACE field_type WITH SUBSTR(&p1,11,1)
    REPLACE field_len WITH VAL(SUBSTR(&p1,12,2))
    REPLACE field_dec WITH VAL(SUBSTR(&p1,14,1))
  NEXT
  CREATE stiz FROM pstiz
  INDEX ON STR(stv,3)+STR(art,10)+STR(izv,6)+ost TO stizsd
  INDEX ON STR(stv,3)+STR(izv,6)+STR(art,10)+ost TO stizid
  INDEX ON STR(stv,3)+ost+STR(izv,6)+STR(art,10) TO stizod
  USE
  ERASE pstiz.dbf
ENDIF


*** Indeksiranje ***

IF ! FILE("matcid.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje MATC po ART"
  USE matc
  INDEX ON art TO matcid
ENDIF

IF ! FILE("matcod.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje MATC po OZN+ART"
  USE matc
  INDEX ON STR(ozn,1)+STR(art,10) TO matcod
ENDIF

IF ! FILE("stanad.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje STAN po ART+KON+STV"
  USE stan
  INDEX ON STR(art,10)+STR(kon,1)+STR(stv,3) TO stanad
ENDIF

IF ! FILE("stansd.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje STAN po STV+ART+KON"
  USE stan
  INDEX ON STR(stv,3)+STR(art,10)+STR(kon,1) TO stansd
ENDIF

IF ! FILE("stankd.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje STAN po STV+KON+ART"
  USE stan
  INDEX ON STR(stv,3)+STR(kon,1)+STR(art,10) TO stankd
ENDIF

IF ! FILE("standd.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje STAN po STV+KON+KNT+ART"
  USE stan
  INDEX ON STR(stv,3)+STR(kon,1)+STR(knt,7)+STR(art,10) TO standd
ENDIF

IF ! FILE("promid.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje PROM po STV+MSS+BRD+VRS"
  USE prom
  INDEX ON STR(stv,3)+STR(mes,2)+STR(brd,5)+STR(vrs,2) TO promid
ENDIF

IF ! FILE("promdd.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje PROM po STV+ART+MES+DAT"
  USE prom
  INDEX ON STR(stv,3)+STR(art,10)+STR(mes,2)+DTOS(dat) TO promdd
ENDIF

IF ! FILE("promvd.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje PROM po STV+ART+VRS+MES"
  USE prom
  INDEX ON STR(stv,3)+STR(art,10)+STR(vrs,2)+STR(mes,2) TO promvd
ENDIF

IF ! FILE("prombd.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje PROM po STV+VRS+DOB+ART"
  USE prom
  INDEX ON STR(stv,3)+STR(vrs,2)+STR(dob,6)+STR(art,10) TO prombd
ENDIF

IF ! FILE("promad.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje PROM po STV+ART+VRS+DOB+MES"
  USE prom
  INDEX ON STR(stv,3)+STR(art,10)+STR(vrs,2)+STR(dob,6)+STR(mes,2) TO promad
ENDIF

IF ! FILE("promrd.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje PROM po STV+DOB+ART+VRS+MES"
  USE prom
  INDEX ON STR(stv,3)+STR(dob,6)+STR(art,10)+STR(vrs,2)+STR(mes,2) TO promrd
ENDIF

IF ! FILE("promod.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje PROM po STV+ART+OST+VRS+OSU"
  USE prom
  INDEX ON STR(stv,3)+STR(dob,6)+STR(art,10)+ost+STR(vrs,2)+osu TO promod
ENDIF

IF ! FILE("prozsd.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje PROZ po STV+ART+DAT"
  USE proz
  INDEX ON STR(stv,3)+STR(art,10)+DTOS(DATE()) TO prozsd
ENDIF

IF ! FILE("ddob.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje DDOB po SFDOB"
  USE ddob
  INDEX ON sfdob TO ddob
ENDIF

IF ! FILE("dlok.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje DLOK po SFDOB"
  USE dlok
  INDEX ON sfdob TO dlok
ENDIF

IF ! FILE("dmat.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje DMAT po VK"
  USE dmat
  INDEX ON vk TO dmat
ENDIF

IF ! FILE("dour.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje DOUR po SFOUR"
  USE dour
  INDEX ON sfour TO dour
ENDIF

IF ! FILE("dstov.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje DSTOV po SFSTV"
  USE dstov
  INDEX ON sfstv TO dstov
ENDIF

IF ! FILE("grdati.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje GRDAT po NN"
  USE grdat
  INDEX ON nn TO grdati
ENDIF

IF ! FILE("u1dat.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje U1DAT po SFSTV+VK+BRDOK"
  USE u1dat
  INDEX ON STR(sfstv,3)+STR(vk,2)+STR(brdok,5) TO u1dat
ENDIF

IF ! FILE("izvrid.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje IZVR po IZV"
  USE izvr
  INDEX ON izv TO izvrid
ENDIF

IF ! FILE("stizsd.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje STIZ po STV,ART,IZV,OST"
  USE stiz
  INDEX ON STR(stv,3)+STR(art,10)+STR(izv,6)+ost TO stizsd
ENDIF

IF ! FILE("stizid.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje STIZ po STV,IZV,ART,OST"
  USE stiz
  INDEX ON STR(stv,3)+STR(izv,6)+STR(art,10)+ost TO stizid
ENDIF

IF ! FILE("stizod.ntx")
  rr=1
  red=red+1
  @red,10 SAY "indeksiranje STIZ po STV,OST,IZV,ART"
  USE stiz
  INDEX ON STR(stv,3)+ost+STR(izv,6)+STR(art,10) TO stizod
ENDIF

CLEAR
SET CURSOR ON
IF rr=1
  red=red+1
  @red,10 SAY "Startuj program jos jednom !"
  DO ceka
  QUIT
ENDIF
DO lokam
QUIT


**********************************************************
*      Program za glavni meni                            *
**********************************************************
PROCEDURE LOKAM
CLEAR SCREEN
@ 3,10 SAY "Proveravam ispravnost relacija MATC i STAN !"
c_art=0
c_stv=0
rod=5
dod=43
SELECT 4
USE matc INDEX matcid

****** Ako nadje prazan prostor, konstatuje nove sifre u MATC ****

DO WHILE ! EOF()
  IF nza = "         "
    @ 20,2 SAY "Imas nove sifre u MATC ! "
    @ 21,2 SAY "Udji u ISPRAVKE / MATICNA"
    INKEY(5)
    EXIT
  ENDIF
  SKIP
ENDDO
SELECT 4
USE matc INDEX matcid

*** Sifru artikla iz STAN trzi u MATC, ako nadje konstatuje da je nova ***

SELECT 6
USE stan INDEX stanad
GO TOP
c_art=F->art
DO WHILE ! EOF()
  SELECT 4
  SEEK c_art
  IF ! FOUND()
    @ 20,2 SAY "Imas novu sifru u STAN !  "+STR(c_art)
    @ 21,2 SAY "Prepisi sifru i posle udji u ISPRAVKE / MATICNA"
    INKEY(0)
    @ 20,2 SAY "                                      "
    @ 21,2 SAY "                                               "
  ENDIF
  SELECT 6
  *** Uzima novi ART ***
  SKIP
  c_art=F->art
  LOOP
ENDDO
CLOSE DATABASES

*** Ispisuje stovarista ***

@ 5,5 SAY "U banci imas podatke o stovaristima :"
SELECT 6
USE stan INDEX stansd
c_stv=stv
@ rod,dod SAY c_stv
DO WHILE ! EOF()
  IF c_stv=stv
    SKIP
    LOOP
  ENDIF
  dod=dod+4
  *** Granicnik za kolone ***
  IF dod>77
    dod=43
    rod=rod+2
  ENDIF
  *** Ispisuje stovariste ***
  @ rod,dod SAY stv
  c_stv=stv
  @ rod,dod SAY stv
  c_stv=stv
ENDDO
INKEY(7)

*** Daje izbor za glavni meni ***

CLEAR SCREEN
DO WHILE .T.
  @ 1,0 TO 3,78 DOUBLE
  @ 5,0 TO 23,78 DOUBLE
  @ 2,3 SAY "LOKAM"
  @ 2,25 SAY "GLAVNI IZBOR"
  @ 2,61 SAY "''ESC'' za kraj"
  m_izbor=1
  @10,20 PROMPT " UNOS                     (LOKAL)";
         MESSAGE "UNOS PODATAKA ZA MATERIJALNO POSLOVANJE"
  @12,20 PROMPT " IZVESTAJI                   ''  ";
         MESSAGE "RAZNI IZVESTAJI I STAMPE"
  @14,20 PROMPT " ISPRAVKE                    ''  ";
         MESSAGE "ISPRAVKE U STANJU I MATICNOJ"
  @16,20 PROMPT " ODRZAVANJE BANKE         (MATODR)";
         MESSAGE "ODRZAVANJE RELACIJA U BANCI PODATAKA"
  @18,20 PROMPT " PREGLED ARHIVE           (MATARH)";
         MESSAGE "PREGLED ARHIVSKIH PODATAKA IZ RELACIJE ''PROM''"
  CLEAR TYPEAHEAD
  MENU TO m_izbor
  DO CASE
    CASE LASTKEY()=27
         EXIT
    CASE m_izbor=1
         DO glpr
    CASE m_izbor=2
         DO izve
    CASE m_izbor=3
         DO ispr
    CASE m_izbor=4
         DO matodr
    CASE m_izbor=5
         DO matarh
    OTHERWISE
         EXIT
  ENDCASE
ENDDO
CLEAR SCREEN
CLOSE DATABASES
RETURN


**********************************************************
*      Glavni program za materijalno poslovanje          *
**********************************************************

PROCEDURE GLPR
CLEAR

*** Postavlja promenljive ***
m_mes=0
m_god=SPACE(2)
m_dat=SPACE(10)
*** Vadi mesec iz datuma ***
m_mes=VAL(SUBSTR(DTOC(DATE()),4,2))


IF m_mes = 1
  *** Vadi aktuelni datum iz sistema ***
  m_god=SUBSTR(STR(VAL(SUBSTR(DTOC(DATE()),7,2))+99,3),2,2)
  *** Proverava da li postoji databaza sa promenama ***
  m_dat="PROM"+m_god+".DBF"
  IF ! FILE("&m_dat")
    @ 21,1 SAY "Arhiviraj podatke iz prosle godine !"
    @ 22,1 SAY "GLAVNI IZBOR - ODRZAVANJE BANKE !"
    INKEY(0)
    CLEAR SCREEN
  ENDIF
ENDIF

***--- Otvara bazu za uputstvo za rad
SELECT 5
USE matuput

*** Matrica koja sadrzi sifru OUR-a (radne jedinice) ***
DECLARE TAB911[13]
TAB911[1]= 199
TAB911[2]= 299
TAB911[3]= 399
TAB911[4]= 499
TAB911[5]= 599
TAB911[6]= 604
TAB911[7]= 614
TAB911[8]= 650
TAB911[9]= 699
TAB911[10]=707
TAB911[11]=899
TAB911[12]=799
TAB911[13]=800

*** Formira matricu ***
DECLARE MAB[50]

*** Postavljanje promenljivih kao javne ***
PUBLIC in,ost,TAB911,MAB
ost=' '
PUBLIC pol1,matbr
PUBLIC m_vk,m_osn,m_stv,m_broj,m_odl,m_brd,m_dob,b_stv
PUBLIC m_kon,m_ddd,s_kst,k_kst,m_izv,m_dom,b_mot,e_kst


Rad1 = .T.
STORE ' ' TO f1
DO WHILE Rad1

  SELECT 1
  *** datoteka za unos slogova
  USE u1dat
  ZAP
  *** stavljeno ZAP umesto PACK da bi brisalo sva slogove iz datoteke u1dat !
  *--- kada proradi prenos ova datoteka moze da bude korisna !
  * PACK

  *** Daje broj slogova u datoteci U1DAT ***
  brsl=LASTREC()
  *** Ogranicava broj slogova zbog mesta na flopi disketi ***
  IF brsl<2000
    *--- moze jos da unosi - ima mesta na disketi
    ind40=0
  ELSE
    *--- nema vise unosa - mora da konvertuje banku
    ind40=1
  ENDIF


  CLEAR
  f1 = ' '
  *** ind40 je pokazivac da li ja bilo preko 2000 slogova ***
  IF ind40=1
    *** Ispisuje tacku (CHR(7)) ***
    ?? CHR(7)
    *** Postavlja crnu podlogu ***
    SET COLOR TO /w
    *** Obavestenje o upisu ***
    @ 21,10 SAY '  U banku MATERIJALNOG POSLOVANJA je upisano 2000 slogova   '
    @ 22,10 SAY '        Izvrsi KONVERZIJU u sekvencijalnu datoteku          '
    *** Postavlja boje zuto/plavo ***
    SET COLOR TO gr+/b
  ENDIF

  *** Poziva proceduru za masku
  DO mizb


  *** Oradjuje funkcije izabrane u MIZB ***
  Rad10 = .T.
  DO WHILE Rad10
    *** Potvrdjuje izbor iz MIZB ***
    READ
    *** Obezbedjuje izlazak iz petlje u slucaju da se to ne promeni ***
    Rad10 = .F.
    DO CASE

      *** Odabran je - izlazak ***
      CASE LASTKEY()=27
        EXIT

      *** Odabran je - Unos slogova ***
      CASE f1 = '1'
        IF ind40=1
          *--- nema vise unosa - mora da konvertuje banku
          EXIT
        ENDIF
        *--- unos slogova
        DO unos

      *** Odabran je - Kraj obrade (konvertovanje, brisanje) ***
      CASE f1 = '2'
        *** konvertovanje u .TXT datoteku i brisanje banke
        @ 21,01 CLEAR
        SELECT 1
        USE u1dat
        GO BOTTOM
        brsl = RECNO()
        *** Ako je prvi slog ujedno i krajnji ***
        IF EOF()
          ***    nema slogova u U1DAT.DBF
          ?? CHR(7)
          *** Postavlja boju podloge u crno ***
          SET COLOR TO /w
          @ 22,16 SAY ' Banka je PRAZNA ! Proveri ________.TXT FILE ! '
          *** Postavlja boju zuta/plava ***
          SET COLOR TO gr+/b
          *** Poziva proceduru za cekanje ***
          DO ceka
          *** Ako prvi slog nije i poslednji ***
        ELSE
          *** ima slogova u U1DAT.DBF
          *** Ispisuje tacku ***
          ?? CHR(7)
          I=0
          *** Uzima sistemsko vreme ***
          strvreme=TIME()
          @ 21,10 SAY 'START: '+strvreme

          *** Formira ime databaze TXT ***
          DO WHILE .T.
            ***--- formiraj jedinstveno ime TXT datoteke
            STORE '     ' TO DATTXT
            *** Ubacuje u DATTXT samo ime databaze ***
            DATTXT='M'+SUBSTR(DTOC(DATE()),4,2)+SUBSTR(TIME(),4,2)
            ***- formirano je neko ime za TXT datoteku
            *** Ubacuje u DAT ime baze sa ekstenzijom ***
            DAT=UPPER(TRIM(DATTXT))+'.TXT'
            *** Ako baza sa takvim imenom vec postoji ... ***
            IF FILE ('&DAT')
              ***--- duplo ime TXT datoteke
              I=I+1
              *** Uzima i ispisuje sistemsko vreme ***
              vreme=TIME()
              @ 21,30 SAY 'VREME: '+vreme
              *** Ako je u petlji oko 3 minuta, a nova baza nije napravljena ***
              IF i>600
                ***- proslo tri minuta, a nema baze sa novim imenom ***
                ?? CHR(7)
                ?? CHR(7)
                SET COLOR TO /w
                @ 22,29 SAY ' Konvertovanje nije uspelo ! Obrisi disk pa ponovi '
                @ 24,29 SAY ' ENTER (ÄÙ)    '
                SET COLOR TO gr+/b
                ?? CHR(7)
                dirka=0
                *** Radi (ceka) dok se ne pritisne "Enter" ***
                DO WHILE dirka <> 13
                  dirka=INKEY()
                ENDDO
                EXIT

              ***- probaj jos dok se vreme ne promeni bar za minut ***
              ELSE
                LOOP
              ENDIF

            *** Ako ne postoji datoteka sa novonastalim imenom ***
            ELSE
              ***- ime TXT datoteke je jedinstveno
              ?? CHR(7)
              SET COLOR TO /w
              @ 22,29 SAY ' Ukupno unetih slogova: '+STR(brsl,4)+' '
              @ 22,60 SAY ' '+DAT
              *** CHR(25) je strelica na dole ***
              @ 22,10 SAY ' '+CHR(25)+' konvertujem '+CHR(25)+' '
              SET COLOR TO gr+/b

              *** Ukljucenje zvuka da pisti dok traje kovertovanje ***
              SET TALK ON
              *** Knvertovanje ***
              COPY TO &DATTXT SDF
              *** Iskljucenje zvuka ***
              SET TALK OFF

              ?? CHR(7)
              SET COLOR TO /w
              @ 24,10 SAY '      Prepisi potrebne podatke i pritisni ENTER  (ÄÙ)      '
              SET COLOR TO gr+/b
              dirka=0
              *** Radi (ceka) dok se ne pritisne "Enter" ***
              DO WHILE dirka <> 13
                dirka=INKEY()
              ENDDO
              *** Brise datoteku U1DAT ***
              ZAP
              EXIT
            ENDIF
          ENDDO
        ENDIF
        *** Nesto je odradjeno i obezbedjuje se izlazak iz petlje ***
        Rad1 = .F.
      *** Odabran je -  Uputstvo za rad ***

      CASE f1 = '3'
        *--- uputstvo za rad
        SELECT 5
        USE matuput
        *** Poziva proceduru za ispis Uputstva ***
        DO uput

      *** Odabran je - Kraj ***
      CASE f1 = '6'
        *--- kraj posla
        Rad1 = .F.

      *** Omogucuje izfrsenje opcije koja nije obuhvacena sa CASE ***
      OTHERWISE
        ?? CHR(7)
        *--- pogresan izbor
        SET COLOR TO /w
        @ 22,18 SAY ' Moguci izbor je 1,2,3 ili 6 -> kraj '
        SET COLOR TO gr+/b
        @ 22,1 CLEAR
        f1 = ' '
        @ 17,43 GET f1 PICTURE '!'
        *** Omogucuje vracanje na pocetak petlje ***
        Rad10 = .T.
    ENDCASE 
  ENDDO 
  *** Omogucuje izlaz ***
  IF LASTKEY()=27
    EXIT
  ENDIF
ENDDO 
CLEAR SCREEN
RETURN



**********************************************************
*      Omogucuje zastoj prikaza na ekranu                *
**********************************************************

PROCEDURE CEKA
?? INKEY(3)
RETURN



**********************************************************
*      Listanje uputstva za unos                         *
**********************************************************

PROCEDURE UPUT
CLEAR
SET COLOR TO /w
@ 1,3  SAY '          U P U T S T V O   Z A   U N O S   P O D A T A K A'
@ 1,62 SAY '           '
SET COLOR TO gr+/b
GO TOP
DO WHILE .NOT. EOF()
  *--- prikazuje slogove sve dok ne dodje do kraja datoteke
  @ 3,1 CLEAR
  *** Daje kolonu od 2. ***
  k=2
  DO WHILE .NOT. EOF() .AND. k<22
    **** prikazuje 20 redova po ekranu od 2 do 22 ***
    @ k+1,1 SAY red
    SKIP
    k=k+1
  ENDDO
  SET COLOR TO /w
  @ 24,4 SAY ' SCROLL: gore () , dole () ,'
  @ 24,33 SAY ' P-pocetak , K-kraj a ENTER za prekid ! '
  SET COLOR TO gr+/b
  dirka=0
  DO WHILE .T.
    dirka=INKEY()
    DO CASE
      *** Ako je pritisnut "Enter" ***
      CASE dirka=13
        EXIT
      *** Strelica gore ***
      CASE dirka=5  .OR. dirka=56
        SKIP -30
        EXIT
      *** Strelica dole ***
      CASE dirka=24 .OR. dirka=50
        SKIP -10
        EXIT
      *** Ako je izabrano P-pocetak ***
      CASE dirka=80 .OR. dirka=112
        GO TOP
        EXIT
      *** Ako je izabrano K-kraj ***
      CASE dirka=75 .OR. dirka=107
        GO BOTTOM
        SKIP -10
        EXIT
      OTHERWISE
        LOOP
    ENDCASE
  ENDDO
  *** Izabran je "Enter" ***
  IF dirka=13
    EXIT
  ENDIF
ENDDO
RETURN



**********************************************************
*      Maska za primarni meni                            *
**********************************************************

PROCEDURE MIZB
@  1,10 SAY 'ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ»'
@  2,10 SAY 'º       M A T E R I J A L N O    P O S L O V A N J E       º'
@  3,10 SAY 'ÌÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¹'
@  4,10 SAY 'º                                                          º'
@  5,10 SAY 'º                                                          º'
@  6,10 SAY 'º                    Izbor  poslova:                       º'
@  7,10 SAY 'º                                                          º'
@  8,10 SAY 'º              ( 1 ) UNOS SLOGOVA ( uneto:      )          º'
@  9,10 SAY 'º                                                          º'
@ 10,10 SAY 'º              ( 2 ) KRAJ OBRADE MATERIJALNOG POSLOVANJA   º'
@ 11,10 SAY 'º                    (konvertovanje,brisanje)              º'
@ 12,10 SAY 'º                                                          º'
@ 13,10 SAY 'º              ( 3 ) UPUTSTVO ZA RAD                       º'
@ 14,10 SAY 'º                                                          º'
@ 15,10 SAY 'º              ( 6 ) Kraj  posla  ( dirka ESC )            º'
@ 16,10 SAY 'º                                                          º'
@ 17,10 SAY 'º                    Tvoj izbor:' GET f1 PICTURE '!'
@ 18,10 SAY 'º                                                          º'
@ 19,10 SAY 'º                                                          º'
@ 20,10 SAY 'ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼'
@ 17,69 SAY 'º'
@  8,53 SAY STR(brsl,4)
RETURN



**********************************************************
*      Unos jednog dokumenta                             *
**********************************************************

PROCEDURE UNOS

SELECT 7
*--- datoteka promena
USE prom INDEX promid

SELECT 6
*--- datoteka stanja
USE stan INDEX stansd

SELECT 4
*--- maticna datoteka
USE matc INDEX matcid

SELECT 3
*--- datoteka za mesto unosa
USE mesto
*--- 1) unos slogova
CLEAR
**********************
*** Matrica sadrzi konta novih artikala ***
DECLARE tak[37]
tak[1] =1010000
tak[2] =1010001
tak[3] =1010002
tak[4] =1010003
tak[5] =1010004
tak[6] =1010006
tak[7] =1010007
tak[8] =1010008
tak[9] =1010009
tak[10]=1010010
tak[11]=1010011
tak[12]=1010012
tak[13]=1010013
tak[14]=1010014
tak[15]=1010015
tak[16]=1010029
*
tak[17]=1020000
tak[18]=1020010
tak[19]=1020020
tak[20]=1020030
tak[21]=1020040
tak[22]=1020050
tak[23]=1020060
tak[24]=1020070
tak[25]=1020080
*
tak[26]=1030000
tak[27]=1030010
tak[28]=1030020
tak[29]=1030030
tak[30]=1030040
tak[31]=1030050
tak[32]=1030060
tak[33]=1030080
tak[34]=1030090
tak[35]=1030190
tak[36]=1031000
tak[37]=1032000
**********************
*** Matrica sadrzi konta zastarelih novih artikala ***
DECLARE tap[3]
tap[1] =1015000
tap[2] =1025000
tap[3] =1030070
**********************
*** Matrica sadrzi konta polovnih artikala ***
DECLARE tar[37]
tar[1] =1010100
tar[2] =1010101
tar[3] =1010102
tar[4] =1010103
tar[5] =1010104
tar[6] =1010106
tar[7] =1010107
tar[8] =1010108
tar[9] =1010109
tar[10]=1010110
tar[11]=1010111
tar[12]=1010112
tar[13]=1010113
tar[14]=1010114
tar[15]=1010115
tar[16]=1010129
*
tar[17]=1020100
tar[18]=1020110
tar[19]=1020120
tar[20]=1020130
tar[21]=1020140
tar[22]=1020150
tar[23]=1020160
tar[24]=1020170
tar[25]=1020180
*
tar[26]=1033000
tar[27]=1033000
tar[28]=1033000
tar[29]=1033000
tar[30]=1033000
tar[31]=1033000
tar[32]=1033000
tar[33]=1033100
tar[34]=1033200
tar[35]=1033000
tar[36]=1034000
tar[37]=1035000
**********************
*** Matrica sadrzi konta zastarelih polovnih artikala ***
DECLARE tas[3]
tas[1] =1015010
tas[2] =1025010
tas[3] =1030170
**********************
*** Matrica sadrzi konta artikala na upotrebi ***
DECLARE tan[12]
tan[1] =1033000
tan[2] =1033000
tan[3] =1033000
tan[4] =1033000
tan[5] =1033000
tan[6] =1033000
tan[7] =1033000
tan[8] =1033100
tan[9] =1033200
tan[10]=1033000
tan[11]=1034000
tan[12]=1035000
**********************


SELECT 1
*** Strelica na gore ***
f=CHR(24)
*** Strelica na desno ***
s=CHR(26)
*** Postavljanje promenljivih ***
***Indikator unosa naziva dobavljaca***
rb=0
*** Desna strana MAT-a 24 ***
i24=1
zto=1
mvk=0
m_vk=SPACE(2)
m_kon=0
m_osn=SPACE(2)
m_odl=SPACE(1)
msfour=0
msfstv=0
msfdob=0
mbrdok=0
mmesec=0
mmesto=C->mesto
@ 23,01 CLEAR
sfstv1=0
****--- unos jednog dokumenta
rad9=.T.
DO WHILE rad9
  SELECT 1
  USE u1dat
  APPEND BLANK
  bsl=RECNO()
  *** Ogranicava broj slogova ***
  IF bsl > 2000
    *--- uneto je dovoljno slogova za 1 punu disketu - konvertuj
    DELETE
    PACK
    ind40=1
    EXIT
  ENDIF
  @ 01,53 SAY 'SLOG BROJ '+STR(bsl,5)
  *** Mesto (stovariste,grad) unosa ***
  @ 01,74 SAY mmesto
  fun=CHR(24)
  @ 5,1 SAY ' '
  DO WHILE .T.
    *--- unos zaglavlja (i podataka iz zaglavlja) sa eventualnim ispravkama*
    *** Postavlja i prazni promenljivu "gres" ***
    gres=' '
    ****---Proverava ispravnost VK ***
    DO WHILE .T.
      vk1='  '
      @ 03,01 SAY 'VK ' GET vk1 PICTURE '!9'
      READ

      *** Vrlo interesantna petlja koja izvrsava kontra uslov ***
      *** "rb"=1 pokazuje da je bilo unosa po VK24 ***
      IF vk1='24' .AND. rb=1
      *NISTA*
      ELSE
        m_ddd=SPACE(30)
        @ 5,1 CLEAR
      ENDIF

      m_vk=vk1
      *** Reaguje samo ako je ispisan neki od znakova iz skupa ***
      IF SUBSTR(vk1,1,1) $ 'Kk0123456789'
        DO CASE
          CASE vk1='01'
            @ 01,17 SAY 'PRIJEM MATERIJALA             '
          CASE vk1='02'
            @ 01,17 SAY 'POVRATNICA                    '
          CASE vk1='03'
            @ 01,17 SAY 'KASACIJA OSNOVNIH SREDSTAVA   '
          CASE vk1='04'
            @ 01,17 SAY 'RASHODOVANJE SITNOG INVENTARA '
          CASE vk1='05'
            @ 01,17 SAY 'SPISAK VISKA                  '
          CASE vk1='09'
            @ 01,17 SAY 'TREBOVANJE                    '
          CASE vk1='10'
            @ 01,17 SAY 'IZVADNICA                     '
          CASE vk1='11'
            @ 01,17 SAY 'IZVADNICA ZA GORIVO I MAZIVO  '
          CASE vk1='12'
            @ 01,17 SAY 'OTPREMNICA                    '
          CASE vk1='13'
            @ 01,17 SAY 'SPISAK MANJKA                 '
          CASE vk1='14'
            @ 01,17 SAY 'PREDLOG ZA RASHODOVANJE       '
          CASE vk1='20'
            @ 01,17 SAY 'SPROVODNICA                   '
          CASE vk1='21'
            @ 01,17 SAY 'DOSTAVNICA                    '
          CASE vk1='23'
            @ 01,17 SAY 'PREDAJA NA OBRADU,DORADU,,    '
          CASE vk1='24'
            @ 01,17 SAY 'PRIJEM SA OBRADE,DORADE,,,ULAZ'
          CASE vk1='30'
            @ 01,17 SAY 'POCETNO STANJE                '
        ENDCASE
        *--- 1. pozicija u vk je ispravno uneta
        *** Obezbedjuje izlazak ***
        IF SUBSTR(vk1,1,1) $ 'Kk'
          ***--- kraj unosa***
          EXIT
        ENDIF
      ELSE
        ***--- 1. pozicija u vk nije ispravno uneta***
        LOOP
      ENDIF
      *** VK-20 je prenos materijala iz jednog u drugo stovariste ***
      IF m_vk="20"
           @ 21,01 SAY "Ulaz ili izlaz (U/I) ?";
                GET m_odl PICTURE "!" VALID(m_odl $ "UI")
        READ
      ENDIF
      *** Upis VK u bazu U1DAT ***
      REPLACE vk WITH VAL(vk1)

      *** Daje vrednost promenljivoj ***
      in='n'

      *** Poziva proceduru VKVK koja proverava ispravnost VK ***
      DO vkvk

      IF in='n'
        *--- nije pronadjen u tabeli
        LOOP
      ELSE
        *--- nadjen u tabeli
        EXIT
      ENDIF
    ENDDO

    @ 22,01 CLEAR
    *** Ako je otkucano "Kk" ide na kraj ***
    IF SUBSTR(vk1,1,1) $ 'Kk'
      *--- kraj unosa
      *** Brise slog koji na mestu vk ima upisano "Kk" ***
      DELETE
      PACK
      EXIT
    ENDIF
    ****--- VK je unet ispravno, idemo dalje ...***

    *** VK i MVK se izjednacuju (dole) u daljem radu programa ***
    IF vk=mvk
      REPLACE sfour WITH msfour,sfstv WITH msfstv,sfdob WITH msfdob,;
              brdok WITH mbrdok,mesec WITH mmesec,mesto WITH mmesto

    ELSE
      sfstv1=0
    ENDIF


    *** Mislim da je - i24 je uvek ovde =1 ***
    *** Obavestava o unosu leve strane VK-24 ***
    IF vk=24 .AND. i24=2
            gres=gres1

    ELSE
      *** Ako nema greske, ako je VK ispravan ***
      gres1=' '

      *** Postavlja zaglavlje za zeljeni VK obrazac ***
      DO zag2

      *** Proverava ispravnost podataka koji se unose u zaglavlje VK ***
      DO zag1

    ENDIF

    *** Poziva proceduru za kretanje po zaglavlju pri unosu podataka ***
    DO ekr1 WITH 5,1

    *** Ide sa na dalji unos, nema ispravki unetog u zaglavlje ***
    IF fun=CHR(24)
      ***--- nema ispravki***
      *** "s" je CHR(26) - streloca desno*** 
      @ 5,1 SAY s
      *** Greska pri unosu zaglavlja ***
      gresz=TRIM(gres)
      EXIT

    ELSE
      ****--- ima ispravki***
      *** f je CHR(24) - strelica gore***
      @ 5,1 SAY f
      *** Vraca na pocetak unosa zaglavlja ***
      LOOP
    ENDIF
  ENDDO
  *** Ako se na mestu unosa "vk1" upise "K" ili "k" prekida unos ***
  IF SUBSTR(vk1,1,1) $ 'Kk'
    *--- prekid unosa
    EXIT
  ENDIF

  *** Pocinje unos stavki ***
  *--- unos stavki

  *** Poziva proceduru za postavljanje reda (zaglavlja) za unos ***
  DO red1

  ***Pocinje unos od 10-og reda***
  red=10
  ima='D'
  ***Obezbedjuje unos do 22-og reda***
  DO WHILE red<22
    @ red,5 SAY ' '
    fun=CHR(26)
    DO WHILE .T.
      *--- unos stavki i eventualne ispravke
      gres=' '
      osn2=' '
      DO CASE
        CASE vk=1.OR.vk=2.OR.vk=3.OR.vk=4.OR.vk=5.OR.;
             vk=30.OR.(vk=24.AND.i24=2)
             osn1='0'
        CASE vk=10.OR.vk=11.OR.vk=12.OR.vk=13.OR.vk=14.OR.;
             vk=20.OR.vk=21.OR.vk=23.OR.(vk=24.AND.i24=1)
             IF vk=24
               @ 01,42 SAY 'IZLAZ'
             ENDIF
             osn1='1'
        OTHERWISE
             osn1=' '
      ENDCASE
      ***dodaje prazno mesto iza osnova***
      osnn=osn1+osn2
      REPLACE osn WITH osnn
      *--- OSN - ne mora da bude ispravan
      ***brojcanik***
      i=0
      DO WHILE .T.
        i=i+1
        ***Prihvata osnov***
        @ red,03 GET osn
        READ
        m_osn=osn
        ***Odvaja prvu i drugu cifru osnova***
        osn1=SUBSTR(osn,1,1)
        osn2=SUBSTR(osn,2,1)
        *** Obezbedjuje prolaz samo odredjenim simbojima ***
        IF ( osn1 $ 'Kk' .AND. osn2 $ ' 0123456789' ) .OR. ;
           ( osn1 $ '0123456789' .AND. osn2 $ '0123456789' )
          *--- 1. i 2. cifra osnova je ispravna
          *** Obezbedjuje prekid ***
          IF osn1 $ 'Kk'
            *--- nece vise da unosi ...
            EXIT
          ELSE
            *--- proveri OSN
            ***daje pretpostavku da je osnov neispravan***
            in='n'

            *** Poziva proceduru OSNO
            DO osno WITH in

            IF in='n'
              *--- neispravan osn
              ***Ako je 3. krug (pokusaj) unosa osnova***
              IF i=3
                *--- neka ide dalje
                ***Evidentira kao gresku***
                gres=TRIM(gres)+'O'
                ***Izlazi iz unosa osnova***
                EXIT
              ELSE
                ***--- neka se popravi (daje jos pokusaja) ***
                LOOP
              ENDIF
            ELSE
              ***Ako je ispravan osn ide dalje na unos***
              EXIT
            ENDIF
          ENDIF
        ELSE
          *--- 1. i/iil 2. cifra osnova nije ispravna
          ?? CHR(7)
          ***Ponavlja unos***
          LOOP
        ENDIF
      ENDDO

      @ 22,01 CLEAR
      IF osn1 $ 'Kk'
        *--- nece vise da unosi
        ***Vrednost promenljive "red" je simbolicna***
        red=99
        ***Brise podatke iz sloga iz koga se izlazi***
        DELETE
        PACK
        @ 6,1 CLEAR
        EXIT
      ENDIF
      ***--- nastavlja sa unosom stavki***
      *** Ispis poruka ***
      IF vk=10 .AND. (m_osn="12" .OR. m_osn="17")
        @ 09,64 SAY " NOVO   UPOTREBA"
      ELSEIF vk=23
        IF m_osn="10" .OR. m_osn="15"
          @ 09,64 SAY "NOVO      OBRADA"
        ELSE
          @ 09,64 SAY "POLOV.    OBRADA"
        ENDIF
      ELSE
        @ 09,64 SAY "                "
      ENDIF

      ***Poziva proceduru "RED2" za ispis linije***
      DO red2

      ***Poziva proceduru "RED2" za ispis reda i (broj,kol) artikla***
      DO ekr2 WITH red,1

      *** Nije data strelica za prelazak na dalji rad ***
      IF fun=' '
        *--- hoce da ispravlja stavku
        @ red,1 SAY s
        LOOP
      *** Dalji unos ***
      ELSE
        ***********************************
        *  Ovde je bila raspodela po MAT-01
        ***********************************
        *--- ide na sledecu stavku
        @ red,1 SAY ' '
        *** Greska pri unosu stavki (slogova) ***
        gress=TRIM(gres)
        EXIT
      ENDIF
    ENDDO
    IF osn1 $ 'Kk'
      *--- prekida unos stavki
      EXIT
    ENDIF

    *** Sabira greske zaglavlja i stavki ***
    gres=TRIM(gresz)+TRIM(gress)

    *** Puni slogove baze U1DAT ***
    REPLACE greska WITH gres,ostatak WITH ost,slnum WITH RECNO(),;
            mesto WITH mmesto

    *----------------------------------------------------------
    *--- instrukcije za azuriranje lokalne banke podataka
    *----------------------------------------------------------
    *--- moguca konta  1 - ulaz novog i starog materijala ...
    *---               2 - ulaz polovnog materijala ...
    *---               3 - ulaz nepotrebnog i zastarelog novog ...
    *---               4 - ulaz nepotrebnog i zastarelog polovnog ...
    *---               5 - nov materijal u obradi, doradi ...
    *---               6 - polovan materijal u obradi, doradi ...
    *---               2 - nov materijal na upotrebi ...
    *----------------------------------------------------------

    p_ind=0
    p_kst=0
    *** otatak sloga: broj motora i primarno  (maticno) stovariste ***
    p_ost=SPACE(41)
    s_kst=0
    k_kst=0
    u_kst=0
    r_kst=0
    i_kst=0
    m_knt=0
    r_sif=SPACE(14)
    aaa=0
    *** Poziva radno polje sa otvorenom MATC bazom ***
    SELECT 4
    *** Trazi broj artikla ***
    SEEK m_broj
    IF FOUND()
      aaa=1
      IF m_kon=1
        m_knt=knt
        *** Za VK-10 sa osnovom 12 ***
        IF VAL(m_vk)=10 .AND. VAL(m_osn)=12
          *** Za konta artikala od nafte do drumskih vozila ***
          FOR i=26 TO 37
            IF tak[i]=knt
              *** Uzima konto za tehniku na upotrebi ***
              m_knt=tan[i-25]
            ENDIF
          NEXT
        ENDIF
      *** Kod VK-10 sa osn 12; VK-10 sa osn 17; m_osn=01,06,11,16 ***
      ELSEIF m_kon=2
        *** Od zeleza do drumskih vozila ***
        FOR i=1 TO 37
          IF tak[i]=knt
            *** Uzima konto za polovne materijale ***
            m_knt=tar[i]
          ENDIF
        NEXT
      *** Kod m_osn=03,08,13,18 ***
      ELSEIF m_kon=3
        m_knt=knt
      *** Kod m_osn=04,09,14,19 ***
      ELSEIF m_kon=4
        ***Od zeleza do drveta ***
        FOR i=1 TO 3
          IF tap[i]=knt
            *** Uzima konto za zastarelo ***
            m_knt=tas[i]
          ENDIF
        NEXT
      *** Kod m_osn=10,15; m_vk=24 i m_osn=11,16; m_vk=24 ***
      ELSEIF m_kon=5 .OR. m_kon=6
        *--- samo zbog eventualne greske KONTO / OSN
        m_knt=1
      ENDIF
    ENDIF

    ***Ako se dati konto ne poklapa sa unetim***
    IF m_knt=0 .AND. knt>0
      *--- samo zbog potpuno novih stavki u stanju
      @ 21,01 SAY "Greska u tabeli KONTA ili nemoguca varijanta !!!"
      INKEY(0)
      @ red,5 CLEAR
      @ 21,01 CLEAR
      SELECT 1
      USE u1dat
      APPEND BLANK
      LOOP
    ENDIF
    ***Kao sifru uzima: stovariste, br. artikla, konto***
    ***sve pretvara u karakter - pretraga po vise polja***
    r_sif=m_stv+STR(m_broj,10)+STR(m_kon,1)
    ***Kod mata 20 uzima dobavljaca***
    IF VAL(m_vk)=20 .AND. m_odl="U"
      r_sif=m_dob+STR(m_broj,10)+STR(m_kon,1)
    ENDIF
    *** Azurira datoteku STAN ***
    SELECT 6
    USE stan INDEX stansd, stankd, stanad, standd
    ***pretraga djumle, po vise karaktera***
    SEEK r_sif
    *-------------------------
    *--- azuriranje STAN
    *-------------------------
    ***ako pronadje***
    IF FOUND()
      *** Za unos - ulaz ***
      IF VAL(m_osn)<5 .AND. VAL(m_vk)#9
        *--- osn 00,01,03 i 04
        IF VAL(m_vk)=30
          @ 21,01 SAY "Tu stavku vec imas na stanju !!!"
          INKEY(0)
        ENDIF
        @ 21,01 CLEAR

        ***"m_kst" je uneta kolicina,"kst" krajnje stanje,"sus" suma ulaza***
        ***"p_kst" - pkavo krajnje stanje***
        p_kst=kst+m_kst
        ***"u_kst - uneto sranje***
        u_kst=sus+m_kst

        ***--- azuriranje databaze STAN***
        REPLACE kst WITH p_kst,sus WITH u_kst,dat WITH DATE()
      *** Za izlaz ***
      ELSEIF VAL(m_osn)<10 .AND. VAL(m_vk)#9
        *--- osn 05,06,08 i 09
        p_kst=kst-m_kst
        u_kst=sus-m_kst
        *** Ogranicava skidanje artikla sa stanja ***
        IF p_kst<0
          @ 21,01 SAY "Nemas toliko na stanju !  KST ="+STR(kst/1000,11,3)
          INKEY(0)
          @ 21,01 CLEAR
        ENDIF
        ***--- azuriranje databaze STAN ***
        REPLACE kst WITH p_kst,sus WITH u_kst,dat WITH DATE()
      ELSEIF VAL(m_osn)<15 .AND. VAL(m_vk)#11 .AND. VAL(m_vk)#9
        ***--- osn 10,11,12,13 i 14***
        ***Kod VK20-sprovodnica, broj dokumenta>4000 onome ko prima robu*** 
        IF VAL(m_vk)=20 .AND. (VAL(m_osn)>9 .AND. VAL(m_osn)<15) .AND. m_brd>4000
          p_kst=kst+m_kst
          u_kst=sus+m_kst
          ***--- azuriranje relacije STAN***
          REPLACE kst WITH p_kst,sus WITH u_kst,dat WITH DATE()
        ELSE
          p_kst=kst-m_kst
          i_kst=sis+m_kst
          IF p_kst<0
            @ 21,01 SAY "Nemas toliko na stanju !  KST ="+STR(kst/1000,11,3)
            INKEY(0)
            @ red,5 CLEAR
            @ 21,01 CLEAR
            red=red-1
            SELECT 1
            ***--- brisanje poslednjeg sloga iz U1DAT***
            p_ind=1
            DELETE
            PACK
          ELSE
            REPLACE kst WITH p_kst,sis WITH i_kst,dat WITH DATE()
            IF VAL(m_vk)=10 .AND. VAL(m_osn)=12
              s_kst=p_kst
              m_kon=2

              FOR i=26 TO 37
                ***ako konto nadje u "novi"***
                IF tak[i]=knt
                  ***u m_knt ubacuje vrednost iz "na upotrbi"***
                  m_knt=tan[i-25]
                ENDIF
              NEXT
              *** Formira gomilu za grupno tretrazivanje ***
              r_sif=m_stv+STR(m_broj,10)+STR(m_kon,1)
              SEEK r_sif

              IF FOUND()
                p_kst=kst+m_kst
                u_kst=sus+m_kst
                REPLACE kst WITH p_kst,sus WITH u_kst,dat WITH DATE()
                k_kst=p_kst
              *** Ako ne nadje otvara novi slog ***
              ELSE
                APPEND BLANK
                REPLACE stv WITH VAL(m_stv), art WITH m_broj,knt WITH m_knt,;
                        sus WITH m_kst,kst WITH m_kst, kon WITH m_kon,;
                        dat WITH DATE(),dap WITH DATE()
                k_kst=m_kst
              ENDIF
            ENDIF

            IF VAL(m_vk)=23 .AND. (VAL(m_osn)=10 .OR. VAL(m_osn)=11)
              ***od kolicine se skidaju 3 nule, od decimala***
              r_kst=p_kst/1000
              @ red,58 SAY STR(r_kst,11,3)
              s_kst=p_kst
              ***Ubacuje konta po osnovu 10***
              IF VAL(m_osn)=10
                m_kon=5
                IF SUBSTR(STR(m_broj,10),1,1)="1"
                  m_knt=1011000
                ELSEIF SUBSTR(STR(m_broj,10),1,1)="2"
                  m_knt=1021000
                ELSEIF SUBSTR(STR(m_broj,10),1,1)="3" .OR.;
                       SUBSTR(STR(m_broj,10),1,1)="4"
                  m_knt=1036000
                ENDIF
              ELSEIF VAL(m_osn)=11
                m_kon=6
                IF SUBSTR(STR(m_broj,10),1,1)="1"
                  m_knt=1011100
                ELSEIF SUBSTR(STR(m_broj,10),1,1)="2"
                  m_knt=1021100
                ELSEIF SUBSTR(STR(m_broj,10),1,1)="3" .OR.;
                       SUBSTR(STR(m_broj,10),1,1)="4"
                  m_knt=1036100
                ENDIF
              ENDIF
              ***Grupna pretraga niza karaktera***
              r_sif=m_stv+STR(m_broj,10)+STR(m_kon,1)
              SEEK r_sif
              IF FOUND()
                p_kst=kst+m_kst
                u_kst=sus+m_kst
                REPLACE kst WITH p_kst,sus WITH u_kst,dat WITH DATE()
                k_kst=p_kst
              ELSE
                APPEND BLANK
                REPLACE stv WITH VAL(m_stv), art WITH m_broj,knt WITH m_knt,;
                        sus WITH m_kst,kst WITH m_kst, kon WITH m_kon,;
                        dat WITH DATE(),dap WITH DATE()
                k_kst=m_kst
              ENDIF


              ***Ako kolicina ima bilo kakvu vrednost***
              IF k_kst<>0
                r_kst=k_kst/1000
                @ red,69 SAY STR(r_kst,11,3)
              ELSE
                @ red,75 SAY "      0.000"
              ENDIF
            ENDIF
          ENDIF
        ENDIF
      *** za osnov manji od 20 ***
      ELSEIF VAL(m_osn)<20 .AND. VAL(m_vk)#11 .AND. VAL(m_vk)#9
        ***--- osn 15,16,17,18 i 19***
        IF VAL(m_vk)=10 .AND. VAL(m_osn)=17
          *** Povecava krajnje stanje, a smanjuje sumu izlaza ***
          p_kst=kst+m_kst
          *** Osnov 17 je storniranje izlaza ***
          i_kst=sis-m_kst
          s_kst=p_kst
          ***--- azuriranje relacije STAN***
          REPLACE kst WITH p_kst,sis WITH i_kst,dat WITH DATE()
          m_kon=2
          ***menja konto sa "novo" na "u upotrebi"***
          FOR i=26 TO 37
            IF tak[i]=knt
              m_knt=tan[i-25]
            ENDIF
          NEXT
          ***Trazi odredjeni slog***
          r_sif=m_stv+STR(m_broj,10)+STR(m_kon,1)
          SEEK r_sif
          IF FOUND()
            *** Storniranje unosa ***
            p_kst=kst-m_kst
            u_kst=sus-m_kst
            REPLACE kst WITH p_kst,sus WITH u_kst,dat WITH DATE()
            k_kst=p_kst
          ELSE
            ***daje unesenoj kolicini negativnu vrednost***
            m_kst=m_kst*(-1)
            APPEND BLANK
            REPLACE stv WITH VAL(m_stv), art WITH m_broj,knt WITH m_knt,;
                    sus WITH m_kst,kst WITH m_kst, kon WITH m_kon,;
                    dat WITH DATE(),dap WITH DATE()
            k_kst=m_kst
          ENDIF
        ***Za VK20, m_brd>4000 za primaoca robe***
        ELSEIF VAL(m_vk)=20 .AND. (VAL(m_osn)>14 .AND. VAL(m_osn)<20) .AND. m_brd>4000
          ***Storniranje izlaza, sa osnovom:10,11,12,13,14***
          p_kst=kst-m_kst
          i_kst=sus-m_kst
          *--- azuriranje relacije STAN
          REPLACE kst WITH p_kst,sus WITH i_kst,dat WITH DATE()
        ELSEIF VAL(m_vk)=23 .AND. (VAL(m_osn)=15 .OR. VAL(m_osn)=16)
          ***Storniranje izlaza sa osnovom:10 i 11***
          p_kst=kst+m_kst
          i_kst=sis-m_kst
          REPLACE kst WITH p_kst,sis WITH i_kst,dat WITH DATE()
          r_kst=p_kst/1000
          @ red,58 SAY STR(r_kst,11,3)
          ***ubacivanje konta***
          IF VAL(m_osn)=15
            m_kon=5
            IF SUBSTR(STR(m_broj,10),1,1)="1"
              m_knt=1011000
            ELSEIF SUBSTR(STR(m_broj,10),1,1)="2"
              m_knt=1021000
            ELSEIF SUBSTR(STR(m_broj,10),1,1)="3" .OR.;
                   SUBSTR(STR(m_broj,10),1,1)="4"
              m_knt=1036000
            ENDIF
          ***ubacivanje konta***
          ELSEIF VAL(m_osn)=16
            m_kon=6
            IF SUBSTR(STR(m_broj,10),1,1)="1"
              m_knt=1011100
            ELSEIF SUBSTR(STR(m_broj,10),1,1)="2"
              m_knt=1021100
            ELSEIF SUBSTR(STR(m_broj,10),1,1)="3" .OR.;
                   SUBSTR(STR(m_broj,10),1,1)="4"
              m_knt=1036100
            ENDIF
          ENDIF
          ***tarzanje grupnog sloga***
          r_sif=m_stv+STR(m_broj,10)+STR(m_kon,1)
          SEEK r_sif
          IF FOUND()
            *** Artikal je izasao sa jednog konta i usao u drugi konto !? ***
            p_kst=kst-m_kst
            u_kst=sus-m_kst
            REPLACE kst WITH p_kst,sus WITH u_kst,dat WITH DATE()
            k_kst=p_kst
          ELSE
            k_kst=m_kst
            APPEND BLANK
            REPLACE stv WITH VAL(m_stv), art WITH m_broj,knt WITH m_knt,;
                    sus WITH m_kst,kst WITH m_kst, kon WITH m_kon,;
                    dat WITH DATE(),dap WITH DATE()
          ENDIF
          *** Nema nicega na stanju ***
          IF p_kst<>0
            r_kst=k_kst/1000
            @ red,69 SAY STR(r_kst,11,3)
          ELSE
            @ red,75 SAY "      0.000"
          ENDIF
        *** Azuriranje bilo kog drugog izlaza ***
        ELSE
          p_kst=kst+m_kst
          i_kst=sis-m_kst
          ***--- azuriranje relacije STAN***
          REPLACE kst WITH p_kst,sis WITH i_kst,dat WITH DATE()
        ENDIF
      ***Namirivanje sopstvenih lokomotiva gorivom i mazivom***
      ELSEIF VAL(m_osn)=10 .AND. VAL(m_vk)=11
        *--- mat11 i osn 10
        p_kst=kst-m_kst
        i_kst=sis+m_kst
        IF p_kst<0
          @ 21,01 SAY "Nemas toliko na stanju !  KST ="+STR(kst/1000,11,3)
          INKEY(0)
          @ red,5 CLEAR
          @ 21,01 CLEAR
          red=red-1
          SELECT 1
          ***--- brisanje poslednjeg sloga iz U1DAT***
          p_ind=1
          DELETE
          PACK
        ELSE
          ***--- azuriranje relacije STAN za izlaz kolicine***
          REPLACE kst WITH p_kst,sis WITH i_kst,dat WITH DATE()
        ENDIF
      ELSEIF VAL(m_osn)=15 .AND. VAL(m_vk)=11
        ***--- mat11 i osn 15 - storno izlaza sa osnovom 10 ***
        p_kst=kst+m_kst
        i_kst=sis-m_kst
        ***--- azuriranje relacije STAN***
        REPLACE kst WITH p_kst,sis WITH i_kst,dat WITH DATE()
      ENDIF
    ELSE
    ***-------------------------
    ***--- nova stavka u STAN***
    ***-------------------------
      @ 21,01 SAY "Nova stavka na tvom stanju !"
      INKEY(0)
      IF VAL(m_osn)<5 .AND. VAL(m_vk)#9
        ***--- osn 00,01,03 i 04 - unosi ***
        @ 22,01 SAY "Otvoricemo ti novu stavku u stanju !"
        INKEY(0)
        p_kst=m_kst
        ***--- azuriranje relacije STAN***
        APPEND BLANK
        REPLACE stv WITH VAL(m_stv), art WITH m_broj, sus WITH p_kst,;
                kst WITH p_kst, knt WITH m_knt, kon WITH m_kon,;
                dat WITH DATE(), dap WITH DATE()
        *** "aaa" oznacava da li artikal vec postoji ***
        IF aaa=0
          *** U ovom radnom polju je MATC.DBF ***
          SELECT 4
          APPEND BLANK
          REPLACE art WITH m_broj, jmr WITH "99"
          *** U ovom radnom polju je STAN.DBF ***
          SELECT 6
        ENDIF
      ELSEIF VAL(m_osn)<10 .AND. VAL(m_vk)#9
        *** Osnov: 05,06,08 i 09 su storna unosa: 00,01,02,03 i 04 ***
        ***sada se obradjuju artikli koji nisu nadjeni***
        @ 22,01 SAY "Storniras ono cega nemas na stanju !"
        INKEY(0)
        p_kst=m_kst*(-1)
        ***--- azuriranje relacije STAN***
        APPEND BLANK
        REPLACE stv WITH VAL(m_stv), art WITH m_broj, sus WITH p_kst,;
                kst WITH p_kst, knt WITH m_knt, kon WITH m_kon,;
                dat WITH DATE(), dap WITH DATE()
        ***artikal ne postoji u bazi***
        IF aaa=0
          SELECT 4
          APPEND BLANK
          REPLACE art WITH m_broj, jmr WITH "99"
          SELECT 6
        ENDIF
      ELSEIF VAL(m_osn)<15 .AND. VAL(m_vk)#11 .AND. VAL(m_vk)#9
        ***--- osn 10,11,12,13 i 14 - izlazi, a m_brd>4000 za primaoca ***
        IF VAL(m_vk)=20 .AND. (VAL(m_osn)>9 .AND. VAL(m_osn)<15) .AND. m_brd>4000
          ***--- azuriranje relacije STAN***
          p_kst=m_kst
          APPEND BLANK
          REPLACE stv WITH VAL(m_dob), art WITH m_broj, sus WITH p_kst,;
                  kst WITH p_kst, knt WITH m_knt, kon WITH m_kon,;
                  dat WITH DATE(), dap WITH DATE()
          ***artikal nije nadjen u bazi***
          IF aaa=0
            SELECT 4
            APPEND BLANK
            REPLACE art WITH m_broj, jmr WITH "99"
            SELECT 6
          ENDIF
        ***Obarada po matu 23***
        ELSE
          IF VAL(m_vk)=23
            @ 22,01 SAY "Saljes na obradu... ono cega nemas !"
          ELSE
            @ 22,01 SAY "Izdajes ono cega nemas na stanju !"
          ENDIF
          INKEY(0)
          @ red,5 CLEAR
          @ 21,01 CLEAR
          red=red-1
          SELECT 1
          ***--- brisanje poslednjeg sloga iz U1DAT***
          p_ind=1
          DELETE
          PACK
        ENDIF
      *** Storniranje ***
      ELSEIF VAL(m_osn)<20 .AND. VAL(m_vk)#11 .AND. VAL(m_vk)#9
        *--- osn 15,16,17,18 i 19
        @ 22,01 SAY "Storniras ono cega nemas na stanju !"
        INKEY(0)
        IF aaa=0
          *** Polje sa MATC.DBF ***
          SELECT 4
          APPEND BLANK
          REPLACE art WITH m_broj, jmr WITH "99"
          *** POLJE sa STAN.DBF ***
          SELECT 6
        ENDIF
        *** "m_brd">4000 za primaoca robe ***
        IF VAL(m_vk)=20 .AND. (VAL(m_osn)>14 .AND. VAL(m_osn)<20) .AND. m_brd>4000
          p_kst=m_kst*(-1)
          ***--- azuriranje relacije STAN***
          APPEND BLANK
          REPLACE stv WITH VAL(m_dob), art WITH m_broj, sus WITH p_kst,;
                  kst WITH p_kst, knt WITH m_knt, kon WITH m_kon,;
                  dat WITH DATE(), dap WITH DATE()
        *** MAT10-Sitan inventar, OSN:12-izlaz, OSN:17-storno ***
        ELSEIF VAL(m_vk)=10 .AND. (VAL(m_osn)=12 .OR. VAL(m_osn)=17)
          IF VAL(m_osn)=12
            @ 22,01 SAY "Izdajes na upotrebu ono cega nemas !"
          ELSE
            @ 22,01 SAY "Storniras ono sto nije ni izdato na upotrebu !"
          END
          INKEY(0)
          @ red,5 CLEAR
          @ 21,01 CLEAR
          SELECT 1
          ***-- brisanje poslednjeg sloga iz U1DAT***
          p_ind=1
          DELETE
          PACK
        ELSEIF VAL(m_vk)=23
          p_kst=m_kst
          ***-- azuriranje relacije STAN ***
          APPEND BLANK
          REPLACE stv WITH VAL(m_stv), art WITH m_broj, sis WITH p_kst,;
                  kst WITH p_kst, knt WITH m_knt, kon WITH m_kon,;
                  dat WITH DATE(), dap WITH DATE()
          r_kst=p_kst/1000
          @ red,58 SAY STR(r_kst,11,3)
          *** Novo=1, a novo na obradi i doradi=5, pa je razlika 4 ***
          m_kon=m_kon+4
          SEEK m_stv+STR(m_broj,10)+STR(m_kon,1)
          p_kst=kst-m_kst
          ***ubacujie novo stanje***
          REPLACE kst WITH p_kst
          IF p_kst<>0
            r_kst=p_kst/1000
            @ red,69 SAY STR(r_kst,11,3)
          ELSE
            @ red,75 SAY "      0.000"
          ENDIF
        ***Za bilim koji drugi dokument***
        ELSE
          p_kst=m_kst
          ***--- azuriranje relacije STAN***
          APPEND BLANK
          REPLACE stv WITH VAL(m_stv), art WITH m_broj, sis WITH p_kst,;
                  kst WITH p_kst, knt WITH m_knt, kon WITH m_kon,;
                  dat WITH DATE(), dap WITH DATE()
        ENDIF
      *** Izdavanje goriva i maziva ***
      ELSEIF VAL(m_osn)=10 .AND. VAL(m_vk)=11
        ***--- mat 11 i osn 10***
        @ 22,01 SAY "Izdajes ono cega nemas na stanju !"
        INKEY(0)
        @ red,5 CLEAR
        @ 21,01 CLEAR
        red=red-1
        SELECT 1
        ***--- brisanje poslednjeg sloga iz U1DAT***
        p_ind=1
        DELETE
        PACK
      *** Storniranje izdavanja goriva i maziva ***
      ELSEIF VAL(m_osn)=15 .AND. VAL(m_vk)=11
        ***--- mat11 i osn 15***
        @ 22,01 SAY "Storniras ono cega nemas na stanju !"
        INKEY(0)
        IF aaa=0
          SELECT 4
          APPEND BLANK
          REPLACE art WITH m_broj, jmr WITH "99"
          SELECT 6
        ENDIF
        p_kst=m_kst*(-1)
        ***--- azuriranje relacije STAN***
        APPEND BLANK
        REPLACE stv WITH VAL(m_stv), art WITH m_broj, sis WITH p_kst,;
                kst WITH p_kst, knt WITH m_knt, kon WITH m_kon,;
                dat WITH DATE(), dap WITH DATE()
      ENDIF
      @ 21,01 CLEAR
    ENDIF
    *** Ako je novom promenom dobijeno pozitivno stanje ***
    IF p_kst>=0
      *** Izlaz i storno sitnog inventara ***
      IF m_vk="10" .AND. (m_osn="12" .OR. m_osn="17")
        r_kst=s_kst/1000
        @ red,58 SAY STR(r_kst,11,3)
        SEEK m_stv+STR(m_broj,10)+STR(m_kon,1)
        IF FOUND()
          r_kst=kst/1000
          @ red,69 SAY STR(r_kst,11,3)
        ELSE
          @ red,75 SAY "      0.000"
        ENDIF
      *** Za svaki MAT osim za 23 ***
      ELSEIF m_vk#"23"
        r_kst=p_kst/1000
        @ red,69 SAY STR(r_kst,11,3)
      ENDIF
    *** Ako je dobijeno stanje manje od nule ***
    ELSE
      IF p_ind=0
        r_kst=p_kst/1000
        @ red,69 SAY STR(r_kst,11,3)
      ENDIF
    ENDIF
    ***----------------------------
    *** azuriranje relacije STIZ, koja sadrzi stanje po izvodjacima ***
    ***----------------------------
    ***ako za VK23 broj motora ima neku vrednost***
    IF VAL(m_vk)=23 .AND. b_mot # " "
      p_ost=SUBSTR(b_mot,1,30)+"        "+STR(b_stv,3)
      p_kst=0
      SELECT 8
      USE stiz INDEX stizsd, stizid, stizod
      SEEK m_stv+STR(m_broj,10)+STR(m_izv,6)+b_mot
      IF FOUND()
        *** izlaz iz VK23 novog i polovnog za kolicinu vecu od nula ***
        IF VAL(m_vk)=23.AND.(VAL(m_osn)=10.OR.VAL(m_osn)=11).AND.kst>0
          @ 23,1 SAY "Taj motor je vec zaduzen !"
          INKEY(3)
          @ 23,1 SAY "                          "
        *** storno prethodnog ***
        ELSEIF VAL(m_vk)=23 .AND. (VAL(m_osn)=15 .OR. VAL(m_osn)=16)
          p_kst=kst-m_kst
          REPLACE kst WITH p_kst
        ENDIF
      *** Ako motor nije nadjen u stovaristu ***
      ELSE
        IF VAL(m_vk)=23 .AND. (VAL(m_osn)=10 .OR. VAL(m_osn)=11)
          p_kst=m_kst
          APPEND BLANK
          REPLACE stv WITH VAL(m_stv), art WITH m_broj, izv WITH m_izv,;
                  ost WITH p_ost, kst WITH p_kst
        ELSEIF VAL(m_vk)=23 .AND. (VAL(m_osn)=15 .OR. VAL(m_osn)=16)
          @ 23,1 SAY "Storniras nepostojeci motor !"
          INKEY(3)
          @ 23,1 SAY "                             "
        ENDIF
      ENDIF
    ENDIF
    *** Upis u desnu stranu (i24=1) MAT-a 24 sa upisanim brojem motora ***
    IF VAL(m_vk)=24 .AND. i24=1 .AND. b_mot # " "
      p_ost=SUBSTR(b_mot,1,30)
      p_kst=0
      SELECT 8
      USE stiz INDEX stizsd, stizid, stizod
      SEEK m_stv+STR(m_broj,10)+STR(m_izv,6)+p_ost
      *** Ako je odredjeni motor nadjen ***
      IF FOUND()
        *** Izdavanje sitnog inventara ***
        IF VAL(m_vk)=24 .AND. (VAL(m_osn)=10 .OR. VAL(m_osn)=11)
          p_kst=kst-m_kst
          REPLACE kst WITH p_kst
          IF p_kst=0
            DELETE
            PACK
          ENDIF
        *** storno izdavanja ***
        ELSEIF VAL(m_vk)=24 .AND. (VAL(m_osn)=15 .OR. VAL(m_osn)=16)
          p_kst=kst+m_kst
          REPLACE kst WITH p_kst
        ENDIF
      *** Motor nije nadjen ***
      ELSE
        @ 23,1 SAY "Taj motor nema zaduzenje !"
        INKEY(3)
        @ 23,1 SAY "                          "
      ENDIF
    ENDIF


    *-----------------------------------------
    *--- Ovde je bilo azuriranje ST01 izlazima
    *-----------------------------------------
    *** "p_ind" ima vrednost 1 ako je brisan poluunesen slog slog ***
    IF p_ind=0
      SELECT 7
      *--------------------------------------------
      *--- azuriranje relacije PROM i relacije PROZ
      *--------------------------------------------
      USE prom INDEX promid,promdd,promvd,prombd,promad,promrd,promod
      APPEND BLANK
      REPLACE stv WITH A->sfstv, art WITH A->broj, vrs WITH A->vk,;
              osu WITH A->osn, mes WITH A->mesec, dob WITH A->sfdob,;
              brd WITH A->brdok, kst WITH A->kol, ost WITH p_ost,;
              mst WITH A->mesto, dat WITH DATE()
              ***Ako je sprovodnica koju je pravio primalac robe***
              IF A->vk = 20 .AND. m_brd>4000
                REPLACE stv WITH VAL(SUBSTR(STR(A->sfdob,6),4,3)),;
                        dob WITH A->sfstv
              ELSEIF A->vk=01.OR.A->vk=12.OR.A->vk=21
                REPLACE dom WITH m_ddd
              ELSEIF A->vk=23.OR.A->vk=24
                REPLACE dob WITH m_izv, dom WITH m_dom
                *** Indikator unosa naziva dobavljaca ***
                IF rb=0 .AND. A->vk=24
                  rb=1
                ELSE
                  rb=0
                ENDIF
              ENDIF
      ***Sa 60000 se obelezavaju artikli koji se nabavljaju za zimu***
      IF A->brdok > 59999
        SELECT 9
        *** PROZ.DBF sadrzi promene za zimu ***
        USE proz INDEX prozsd
        APPEND BLANK
        REPLACE stv WITH A->sfstv, art WITH A->broj, vrs WITH A->vk,;
                osu WITH A->osn, mes WITH A->mesec, dob WITH A->sfdob,;
                brd WITH A->brdok, kst WITH A->kol, ost WITH A->ostatak,;
                mst WITH A->mesto, dat WITH DATE(),dom WITH m_ddd
      ENDIF
    ELSE
      *** "p_ind" - indikator brisanja poslednjeg sloga ***
      p_ind=0
    ENDIF
    *----------------------------------------------------------
    *--- kraj azuriranja lokalne banke podataka
    *----------------------------------------------------------

    *** Provera broja slogova radi punjenja i cuvanja na disketi ***
    *** Bira radno polje sa U1DAT.DBF ***
    SELECT 1
    APPEND BLANK
    bsl=RECNO()
    IF bsl > 2000
      ***- uneto je dovoljno slogova za 1 punu disketu - konvertuj ***
      ***Brise trenutno zapoceti slog za unos***
      DELETE
      PACK
      *** Obezbedjuje izlazak iz petlje ***
      ind40=1
      rad9=.f.
      EXIT
    ENDIF
    *** Upis u U1DAT.DBF ***
    REPLACE vk WITH mvk,sfour WITH msfour,sfstv WITH msfstv,;
            sfdob WITH msfdob,brdok WITH mbrdok,mesec WITH mmesec,;
            mesto WITH mmesto
    ***upis greske***
    gres=gres1
    ***Ispisuje broj slogova u bazi***
    @ 01,53 SAY 'SLOG BROJ '+STR(bsl,5)
    ***Ako je red 22. cisti i vraca na pocetak***
    red=red+1
    IF red=22
      red=10
      @ 10,1 CLEAR
    ENDIF
  ENDDO 
  @ 23,05 CLEAR
  ***Dodatna radnja za levu stranu VK24***
  IF vk=24 .AND. i24=2
    REPLACE vk WITH mvk
  ENDIF
ENDDO 
RETURN



**********************************************************
*      Provera zaglavlja MAT obrasca                     *
**********************************************************

PROCEDURE ZAG1

*** ZTO=1 je pocetna vrednost ***
IF zto=1
  REPLACE sfour WITH 899
  @ 3,16 GET sfour VALID(sfour=899)
  READ

  *** Poziva proceduru STOV za unos stovarista ***
  DO stov WITH 0

ENDIF
*
mvk=vk
msfour=sfour
msfstv=sfstv
*
DO CASE
  CASE vk=3.OR.vk=4.OR.vk=5.OR.vk=9.OR.vk=13.OR.vk=14

    *** Poziva proceduru SESE za unos sektora, sekcije ***
    *--- SFDOB(PRVI I DRUGI DEO BROJA) - ne mora da bude ispravna,0-u+i
    DO sese WITH 0

    msfdob=sfdob

  CASE vk=2.OR.vk=10

    *** Poziva proceduru za unos sektora, sekcije ***
    *--- SFDOB(SEK I SEC  SER. I BR. LOK) - ne mora da bude ispravna,0-u+i
    DO sese WITH 0
    msfdob=sfdob

  CASE vk=11
    *** Poziva proceduru LOKO za unos lokomotiva ***
    *--- SFDOB(SERIJA I BR.VUC.VOZILA) - ne mora da bude ispravna,0-u+i
    DO loko WITH 0
    msfdob=sfdob

  CASE vk=20

    *** Poziva proceduru ST20 za unos stovarista kod mata 20 ***
    *--- SFSTV(DRUGO STOVARISTE) - ne mora da bude ispravna,0-u+i
    DO st20 WITH 0
    msfdob=sfdob

  CASE vk=1 .OR. vk=12 .OR. vk=21 .OR. vk=23 .OR. vk=24

    *** Poziva proceduru DOBA za  unos dobavljaca ***
    *--- SFDOB(SIFRA DOBAVLJACA) - ne mora da bude ispravna,0-u+i
    DO doba WITH 0
    IF m_vk="23" .OR. m_vk="24"
      *** Umesto dobavljaca ide izvodjac radova kod VK 23 i 24 ***
      msfdob=m_izv
    ELSE
      msfdob=sfdob
    ENDIF
  ***Bilo koja druga mogucnost***
  OTHERWISE
    @ 03,42 GET sfdob
    READ
    msfdob=sfdob
ENDCASE

*** Poziva proceduru BRDO za upis broja dokumenta ***
*--- BRDOK - ne mora da bude ispravna,0-u+i
DO brdo WITH 0,3,61,'brdok',1,99999,'B', ;
'an BROJ DOKUMENTA - potvrdi '
mbrdok=brdok
m_brd=brdok

*** Poziva proceduru MESE za upis meseca ***
*--- MESEC - ne mora da bude ispravna,0-u+i
DO mese WITH 0,3,76,'mesec',1,12,'M', ;
'an MESEC - potvrdi '
mmesec=mesec
gres1=gres

RETURN



**********************************************************
*      Postavka reda zaglavlja za unos podataka          *
**********************************************************

PROCEDURE ZAG2

*** J=donja polukocka (220) ***
J=CHR(220)
DVA=J+J
TRI=DVA+J
CET=TRI+J
PET=TRI+J+J
SEST=PET+J
SEDAM=SEST+J
OSAM=SEDAM+J
DEVET=OSAM+J
DESET=DEVET+J

*** FUN belezi da li zelimo ispravke unetog podatka ***
IF fun<>' '
  ****--- prvi put se unosi slog (nije ispravka)***
  @ 03,07 SAY '  PREDU  '+TRI+'  STOVA  '+TRI
  @ 04,04 SAY '1 2  ZECE   3 5  RISTE  6 8'
  @ 03,54 SAY 'BROJ   '+PET+'   MESEC  '+DVA
  *** Obavestava o vrsti VK ***
  DO CASE
    CASE vk=12
      @ 04,50 SAY ' OTPREMN.'
    CASE vk=11
      @ 04,50 SAY 'IZVADNICE'
    CASE vk=20
      @ 04,50 SAY 'SPROVODN.'
    CASE vk=23 .OR. vk=24
      @ 04,50 SAY 'ZAPISNIKA'
    OTHERWISE
      @ 04,50 SAY 'DOKUMENTA'
  ENDCASE

  @ 04,61 SAY '15 19'
  @ 04,74 SAY '20 21'
  *** Zaglavlje za odredjene VK ***
  DO CASE
    CASE vk=2.OR.vk=3.OR.vk=4.OR.vk=5.OR.vk=9.OR.vk=10.OR. ;
         vk=13.OR.vk=14 .OR.vk=22
      @ 03,33 SAY '   BROJ  '+SEST
      @ 04,33 SAY '         '
    CASE vk=11
      @ 03,33 SAY '  SERIJA '+SEST
      @ 04,33 SAY '  I BROJ '
    CASE vk=12 .OR.vk=21
      @ 03,33 SAY '                '
      @ 04,33 SAY 'PRIMALAC '
    CASE vk=20
      @ 03,33 SAY ' STOVA      '+TRI
      @ 04,33 SAY ' RISTE   '
    CASE vk=23 .OR. vk=24
      @ 03,33 SAY 'IZVODJAC        '
      @ 04,33 SAY ' RADOVA  '
    OTHERWISE
      @ 03,33 SAY '                '
      @ 04,33 SAY 'DOBAVLJAC'
  ENDCASE
ELSE
  ****--- ispravka vec unetog sloga i ispis our,stov,dob,dok i mes ***
  SET COLOR TO /w
  @ 03,16 SAY STR(sfour,3)
  @ 03,28 SAY STR(sfstv,3)
  IF vk=20
    @ 03,45 SAY SFDOB PICTURE "999"
  ELSEIF vk=01
  ELSE
    @ 03,42 SAY STR(sfdob,6)
  ENDIF
  @ 03,61 SAY STR(brdok,5)
  @ 03,76 SAY STR(mesec,2)
  SET COLOR TO gr+/b
ENDIF
RETURN



**********************************************************
*      Postavka reda za unos                             *
**********************************************************
*** Unos prvog reda zaglavlja ***
PROCEDURE RED1
@ 07,01 SAY 'OSNOV'
@ 07,08 SAY 'BROJ IZ '
@ 07,19 SAY 'KOLICINA '
@ 08,01 SAY 'ULAZA'
IF vk>9 .AND. vk#30
  @ 08,01 SAY 'IZLAZA'
ENDIF
@ 08,08 SAY 'IMENIKA'
@ 08,72 SAY 'KOLICINA'
@ 09,01 SAY '22 23'
@ 09,07 SAY '24      33'
@ 09,18 SAY '34     41'
DO CASE
  CASE vk=20 .AND. m_odl='U'
    @ 08,01 SAY 'ULAZA '
  CASE vk=24
    @ 08,01 SAY 'IZLAZA'
    IF i24=2
      i24=1
    ELSE
      i24=2
    ENDIF
ENDCASE
RETURN
**********************************************************
*      Unos reda promena                                 *
**********************************************************
*** Unosi vrednosti iz RDE1-zaglavlja ***
PROCEDURE RED2
J=CHR(220)
DVA=J+J
TRI=DVA+J
CET=TRI+J
PET=TRI+J+J
SEST=PET+J
SEDAM=SEST+J
OSAM=SEDAM+J
DEVET=OSAM+J
DESET=DEVET+J
JEDAN=DESET+J
*** Ako FUN ima vrednost strelice u desno ***
IF fun=CHR(26)
  *--- prvi put unosi stavku (nema ispravke)
  ***ispisuje liniju***
  @ red,07 SAY DESET+' '+DEVET
ELSE
  *--- ispravka vec unete stavke
  SET COLOR TO /w
  ***Ispisuje broj artikla***
  @ red,07 SAY STR(broj,10)
  ***Ispisuje kolicinu***
  @ red,18 SAY STR(kol,8)
  SET COLOR TO gr+/b
ENDIF
*--- BROJ - ne mora da bude ispravan,0-u+i

***Poziva proceduru ARTI za unos sloga artikla***
DO arti WITH 0,red
*--- KOL - ne mora da bude ispravan,0-unos
*** VK-10 obradjuje utrosak sitnog inventara i ambalaze ***
IF VK=10
  ***Obradjuje samo artikle koji pocinju sa "3" (sitan inventar)***
  IF SUBSTR(STR(broj,10),1,1)="3"
    *** Poziva proceduru KOLI za unos kolicine i motora ***
    DO koli WITH 0,red,18,'kol',1,999999,'K',;
    'na KOLICINA - mora biti 0-999999 - potvrdi '
  ***Obradjuje ostale artikle koji ne pocinju sa "3"***
  ELSE
    *** Poziva proceduru KOLI za unos kolicine i broja motora ***
    DO koli WITH 0,red,18,'kol',1,99999999,'K',;
    'na KOLICINA - mora biti > 0 - potvrdi '
  ENDIF
*** Za podatke koji nisu sa VK10 ***
ELSE
  *** Poziva proceduru KOLI za unos kolicine i broja motora ***
  DO koli WITH 0,red,18,'kol',1,99999999,'K',;
  'na KOLICINA - mora biti > 0 - potvrdi '
ENDIF
RETURN



**********************************************************
*      Unos stovarista                                   *
**********************************************************
*** Unos stovarista ***
PROCEDURE STOV
PARAMETERS c
SELECT 2
USE dstov INDEX dstov
SELECT 1
USE u1dat
***ide na zadnji slog***
GOTO bsl
i=0
m_stv=SPACE(3)
DO WHILE .T.
  ***brojac krugova***
  i=i+1
  *** "c" odredjuje da li je ispravka ili unos ***
  IF c=1
    *--- ispravka + unos
    i=i-1
    c=0
  ELSE
    *--- unos + ispravka
    @ 03,28 GET sfstv
    READ
    m_stv=STR(sfstv,3)
    *** MAT20 - Ulaz ***
    IF m_vk="20" .AND. m_odl="U"
    ELSE
      SELECT 6
      USE stan INDEX stansd
      SEEK m_stv
      *** Ako to stovariste nije nasao ***
      IF ! FOUND()
        @ 21,01 SAY "To nije tvoje STOVARISTE !"
        INKEY(0)
        @ 21,01 CLEAR
        SELECT 1
        LOOP
      ENDIF
      *** Vraca u U1DAT ***
      SELECT 1
    ENDIF
  ENDIF
  *** Uspostavlja se relacija izmedju U1DAT i DSTOV po kljucu "sfstv" ***
  SET RELATION TO sfstv INTO dstov
  ***Ako stovariste iz U1DAT pronadje u DSTOV, a # od 0***
  IF sfstv=b->sfstv .AND. sfstv # 0
    *--- kontrolisani podatak je ispravan
    EXIT
  ***Nema stovarista ili je broj stov. = 0***
  ELSE
    *--- kontrolisani podatak nije ispravan
    ?? CHR(7)
    SET COLOR TO /w
    @ 22,01 SAY ' Neispravno STOVARISTE - potvrdi       '
    SET COLOR TO gr+/b
    ***Ako je treci krug (pokusaj)***
    IF i=3
      ***- neka program ide dalje***
      ***Belezi gresku u upisu stovarista***
      gres=TRIM(gres)+'S'
      EXIT
    ELSE
      ***- neka se popravi***
      LOOP
    ENDIF
  ENDIF
ENDDO
@ 22,01 CLEAR
RETURN



**********************************************************
*      Unos lokomotiva                                   *
**********************************************************
*** Unos lokomotiva ***
PROCEDURE LOKO
PARAMETERS c
SELECT 3
USE dlok INDEX dlok
SELECT 1
USE u1dat
GOTO bsl
i=0
DO WHILE .T.
  ***Brojac***
  i=i+1
  *** "c" parametar za ispravku i unos ***
  IF c=1
    *--- ispravka + unos
    i=i-1
    c=0
  ELSE
    *--- unos + ispravka
    @ 03,42 GET sfdob
    READ
  ENDIF
  *** Povezuje U1DAT.DBF i DLOK.DBF po kljucu "sfdob" ***
  SET RELATION TO sfdob INTO dlok
  ***Ako pronadje i sifra dobavljaca ima neku vrednost***
  IF sfdob=c->sfdob .AND. sfdob # 0
    ***- kontrolisani podatak je ispravan***
    EXIT
  ELSE
    ***- kontrolisani podatak nije ispravan***
    ?? CHR(7)
    SET COLOR TO /w
    @ 22,01 SAY ' Neispravna SERIJA I BROJ VUCNOG VOZILA - potvrdi '
    SET COLOR TO gr+/b
    IF i=3
      ***- neka program ide dalje***
      gres=TRIM(gres)+'L'
      EXIT
    ELSE
      ***- neka se popravi***
      LOOP
    ENDIF
  ENDIF
ENDDO
@ 22,01 CLEAR
RETURN



**********************************************************
*      Unos stovarista za MAT 20                         *
**********************************************************
*** Unos stovarista ***
PROCEDURE ST20
PARAMETERS c
m_dob=0
SELECT 2
USE dstov INDEX dstov
SELECT 1
USE u1dat
GOTO bsl
i=0
DO WHILE .T.
  ***brojac***
  i=i+1
  ***Unos ili ispravka***
  IF c=1
    *--- ispravka + unos
    i=i-1
    c=0
  ELSE
    *--- unos + ispravka
    SELECT 1
    @ 03,45 GET sfdob PICTURE "999"
    READ
    m_dob=STR(sfdob,3)
    ***Kontrola unosa stovarista***
    IF m_stv=m_dob
      @ 22,01 SAY "Dva puta isto stovariste ???"
      ***Procedura za cekanje***
      DO ceka
      @ 22,01 CLEAR
    ENDIF
    *** Prazan uslov omogucava kontraizvrsenje od izlazne sprovodnice ***
    IF VAL(m_vk)=20 .AND. m_odl="I"
      *
    ELSEIF VAL(m_vk)=20
      SELECT 6
      USE stan INDEX stansd
      ***Trazi stovariste u stanju po grupnoj indeksnoj, a "stv" je prvo polje***
      SEEK m_dob
      IF ! FOUND()
        @ 22,01 SAY "To nije tvoje STOVARISTE !"
        ***Cekanje***
        DO ceka
        @ 22,01 CLEAR
        SELECT 1
        LOOP
      ENDIF
      SELECT 1
    ENDIF
  ENDIF
  SELECT 2
  ***Za VK20 u U1DAT.DBF u polju "sfdob N-6-0" se nalazi stovariste ***
  ***Trazi sifru stovarista (prva 3 mesta iz sfdob) iz U1DAT.DBF u DSTOV.DBF***
  SEEK VAL(STR(A->sfdob,3))
  IF FOUND()
    ***- kontrolisani podatak je ispravan***
    EXIT
  ELSE
    ***- kontrolisani podatak nije ispravan***
    ?? CHR(7)
    SET COLOR TO /w
    *** Drugo je ono u koga se salje ili iz koga se prima ***
    @ 22,01 SAY ' Neispravno DRUGO STOVARISTE - potvrdi '
    SET COLOR TO gr+/b
    IF i=3
      ***- neka program ide dalje***
      gres=TRIM(gres)+'T'
      EXIT
    ELSE
      ***- neka se popravi***
      LOOP
    ENDIF
  ENDIF
ENDDO
SELECT 1
@ 22,01 CLEAR
RETURN



**********************************************************
*      Unos dobavljaca i izvodjaca radova                *
**********************************************************
***Obradjuje dobavljaca i izvodjaca radova***
PROCEDURE DOBA
PARAMETERS c
m_dob=0
m_izv=0
m_dom=SPACE(30)
SELECT 3
USE izvr INDEX izvrid
SELECT 2
USE ddob INDEX ddob
SELECT 1
USE u1dat
GOTO bsl
i=0
DO WHILE .T.
  ***brojac***
  i=i+1
  IF c=1
    *--- ispravka + unos
    i=i-1
    c=0
  ELSE
    *--- unos + ispravka
    ***- unos DOBAVLJACA za MAT-01,MAT-12,MAT-21,MAT-23 ili MAT-24***
    IF m_vk="01".OR.m_vk="12".OR.m_vk="21"
      @ 5,33 GET m_ddd PICTURE "@9" VALID (m_ddd # " ")
      READ
      EXIT
    ELSEIF m_vk="23".OR.m_vk="24"
      SELECT 3
      @ 03,42 GET m_izv PICTURE '999999'
      READ
      SET COLOR TO /w
      *** "m_izv" (izv) je numerik, sifra dobavljaca ***
      SEEK m_izv
      ***ako je nasao izvodjaca radova***
      IF FOUND()
        SET COLOR TO /w
        *** "dom" je karakter, ime izvodjaca radova ***
        @ 05,33 SAY dom
        m_dom=dom
        SET COLOR TO gr+/b
      ELSE
        SET COLOR TO /w
        @ 05,33 SAY "Nepoznat ?"
        m_dom="Nepoznat ?"
        SET COLOR TO gr+/b
      ENDIF
      SELECT 1
      EXIT
    ELSE
      @ 03,42 GET sfdob
      READ
    ENDIF
  ENDIF
  SET RELATION TO sfdob INTO ddob
  IF sfdob=B->sfdob .AND. sfdob # 0
    ***- kontrolisani podatak je ispravan***
    EXIT
  ELSE
    ***- kontrolisani podatak nije ispravan***
    ?? CHR(7)
    SET COLOR TO /w
    @ 22,01 SAY ' Neispravan DOBAVLJAC  -  potvrdi      '
    SET COLOR TO gr+/b
    IF i=3
      ***- registruje gresku i ide dalje**
      gres=TRIM(gres)+'D'
      EXIT
    ELSE
      ***- neka se popravi - novi pokusaj***
      SELECT 1
      LOOP
    ENDIF
  ENDIF
ENDDO
@ 22,01 CLEAR
RETURN



**********************************************************
*      Unos VK - vrste dokumenta                         *
**********************************************************
*** Unos i provera vrste dokumenata ***
PROCEDURE VKVK
SELECT 2
USE dmat INDEX dmat
SELECT 1
USE u1dat
GOTO bsl
*** Povezuje i proverava po VK iz U1DAT.DBF u DMAT.DBF ***
SET RELATION TO VK INTO DMAT
*** NAsao ***
IF VK=b->VK .AND. VK # 0
  ***--- kontrolisani podatak je ispravan***
  in='i'
*** Nije nasao ***
ELSE
  ***--- kontrolisani podatak nije ispravan***
  ?? CHR(7)
  SET COLOR TO /w
  @ 22,01 SAY ' Neispravan VK '
  SET COLOR TO gr+/b
ENDIF
RETURN



**********************************************************
*      Unos broja dokumenta                              *
**********************************************************
***Prihvata broj dokumenata***
PROCEDURE BRDO
PARAMETERS c,a,b,polje,gr1,gr2,kodgr,poruka
i=0
m_kst=0
DO WHILE .T.
  ***brojcanik***
  i=i+1
  IF c=1
    *--- ispravka+unos
    i=i-1
    c=0
  ELSE
    *--- unos+ispravka
    @ a,b GET &polje
    READ
    m_kst=&polje
    m_sif=&polje
    ***Kod VK20, m_brd<4000 za posiljaoca robe sprovodnicom***
    *** "kodgr" je kod greske i ima slovo zavisno gde je greska nastala ***
    *** "kodgr"-PROCEDURE: "B"-BRDO; "M"-MESE; "K"-KOLI ***
    IF m_vk="20" .AND. m_odl="U" .AND. kodgr="B";
      .AND. m_kst<4000
      @ 22,01 SAY "BROJ DOKUMENTA mora poceti sa 04..."
      INKEY(0)
      @ 22,01 SAY "                                   "
      LOOP
    *** m_brd=00 za posiljaoca, a =04 za primaoca po sprovodnici ***
    *** Pri greski kod unosa broja dokumenta ***
    ELSEIF m_vk="20" .AND. m_odl="I" .AND. kodgr="B";
      .AND. m_kst>4000
      @ 22,01 SAY "BROJ DOKUMENTA mora biti manji od 4000 "
      INKEY(0)
      @ 22,01 SAY "                                       "
      LOOP
    ELSEIF m_vk="20" .AND. m_odl="U" .AND. kodgr="B"
      *** Unosi u promenljivu prihvacenu vrednost broja dokumenta ***
      m_sif=&polje
    ENDIF
  ENDIF
  *** "gr1" i "gr2" su gornja i donja granica od: BRDO, MESE i KOLI ***
  IF gr1<= &polje .AND. &polje<=gr2
    ***- ispravan podatak***
    EXIT
  ELSE
    ***- neispravan podatak***
    ?? CHR(7)
    SET COLOR TO /w
    @ 22,01 SAY ' Neisprav'+poruka
    SET COLOR TO gr+/b
    IF i=3
      ***- ide dalje posle 3 pokusaja ***
      gres=TRIM(gres)+kodgr
      EXIT
    ELSE
      ***- neka se popravi (pokusa) 3 puta***
      LOOP
    ENDIF
  ENDIF
ENDDO
@ 22,01 CLEAR TO 22,78
RETURN



**********************************************************
*      Unos meseca                                       *
**********************************************************
***Provera unosa meseca***
PROCEDURE MESE
PARAMETERS c,a,b,polje,gr1,gr2,kodgr,poruka
i=0
DO WHILE .T.
  ***brojcanik***
  i=i+1
  IF c=1
    ***- ispravka+unos***
    i=i-1
    c=0
  ELSE
    ***- unos+ispravka***
    @ a,b GET &polje
    READ
  ENDIF
  ***Proverava da li prelazi okvire***
  IF gr1<= &polje .AND. &polje<=gr2
    ***- ispravan podatak***
    EXIT
  ELSE
    ***- neispravan podatak***
    ?? CHR(7)
    SET COLOR TO /w
    @ 22,01 SAY ' Neisprav'+poruka
    SET COLOR TO gr+/b
    IF i=3
      ***- ide dalje posle 3 pokusaja***
      gres=TRIM(gres)+kodgr
      EXIT
    ELSE
      ***- neka se popravi (pokusa) 3 puta***
      LOOP
    ENDIF
  ENDIF
ENDDO
@ 22,01 CLEAR TO 22,78
RETURN



**********************************************************
*      Unos kolicine i broja motora                      *
**********************************************************
***Provera unosa kolicine i broja motora***
PROCEDURE KOLI
PARAMETERS c,a,b,polje,gr1,gr2,kodgr,poruka
i=0
m_kkk=0
m_kkr=VAL(SPACE(8))
p_kkk=0
m_kst=0
r_kst=0
p_kst=0
b_stv=0
m_ost=SPACE(20)
m_os2=0
m_mot="N"
m_mtr="N"
m_odg="D"
b_mot=SPACE(30)
DO WHILE .T.
  ***brojcanik***
  i=i+1
  IF c=1
    ***- ispravka+unos***
    i=i-1
    c=0
  ELSE
    ***- unos+ispravka***
    ***za VK23 ili desnu stranu VK24***
    IF m_vk="23" .OR. (m_vk="24" .AND. i24=1)
      @ 22,01 SAY "Da li je to motor ? (D/N)" GET m_mtr PICTURE "!";
                   VALID (m_mtr $ "DNdn")
      @ 23,01 SAY "Motori moraju biti uneti pojedinacno !"
      READ
      @ 22,01 SAY "                                      "
      @ 23,01 SAY "                                      "
    ENDIF
    ***Uzima kolicinu***
    @ a,b GET m_kkk PICTURE "99999.999"
    READ
    m_kkr=m_kkk*1000
    REPLACE kol WITH m_kkr
    ***Uzima memorijsko krajnje stanje***
    m_kst=&polje
  ENDIF
  ***Proverava da li prevazilazi okvire i zalazi u gresku***
  IF gr1<= &polje .AND. &polje<=gr2
    ***- ispravan podatak***
  ELSE
    ***- neispravan podatak***
    ?? CHR(7)
    SET COLOR TO /w
    @ 22,01 SAY ' Neisprav'+poruka
    SET COLOR TO gr+/b
    IF i=3
      ***- dalje pokusava, a gresku pamti***
      gres=TRIM(gres)+kodgr
    ELSE
      ***- neka se popravi (3 puta)***
      LOOP
    ENDIF
  ENDIF
  SELECT 4
  USE matc INDEX matcid
  ***Pretrazuje broj artikla***
  SEEK STR(m_broj,10)
  IF FOUND()
    ***U "jmr" je sifra za jedinicu mere***
    DO WHILE (jmr="01" .OR. jmr="02" .OR. jmr="03")
      *** Uzima iz kolicine decimale ***
      p_kst=VAL(SUBSTR(STR(m_kkr,8),6,3))
      *** Ne dozvoljava decimale za sifre JMR od: komad, par, garnitura ***
      IF p_kst>0
        @ 21,1 SAY "Pogresno uneta KOLICINA - JMR !"
        DO ceka
        ***cisti ekran***
        @ 21,1 CLEAR
        ***prazni promenljive***
        m_kkk=0
        m_kkr=VAL(SPACE(8))
        m_kst=0
        ***Uzima novu kolicinu***
        @ a,b GET m_kkk PICTURE "99999.999"
        READ
        ***Dodaje 3 nule radi upisa u polje databaze***
        m_kkr=m_kkk*1000
        r_kst=m_kkk*1000
        ***Upisuje prihvacen podatak u U1DAT.DBF***
        SELECT 1
        REPLACE kol WITH m_kkr
        m_kst=&polje
        ***Vraca u radno polje gde je MATC.DBF***
        SELECT 4
        LOOP
      ENDIF
      EXIT
    ENDDO
  ENDIF
  *** Poziva polje gde je U1DAT.DBF ***
  SELECT 1
  *** Ako se radi o unosu broja motora kod VK23 i VK24; ("b"=18???) ***
  IF (vk=23 .OR. vk=24) .AND. b=18 .AND. (m_mtr="D" .OR. m_mtr="d")
    SELECT 8
    *** STIZ.DBF - Stanje kod izvodjaca radova ***
    USE stiz INDEX stizsd
    SEEK m_stv+STR(m_broj,10)+STR(m_izv,6)
    IF FOUND()
      ***Radi dok je odredjeno: stovariste, artikal, izvodjac***
      DO WHILE stv=VAL(m_stv) .AND. art=m_broj .AND. izv=m_izv
        *** "BB" - Broj motora za koga se ne zna sifra ***
        IF SUBSTR(ost,1,2)="BB"
          *** Uzima ostatak ***
          m_ost=ost
        ENDIF
        SKIP
        LOOP
      ENDDO
    ENDIF
    ***Ako "m_ost" ima bilo koju vrednost (bilo je u IF="BB")***
    IF m_ost # " "
      ***Ide se kod U1DAT.DBF***
      SELECT 1
      ***Za VK24 uzima prvih 5 mesta - ime i zadnja 3 - sifra***
      IF vk=24
        b_mot=SUBSTR(m_ost,1,5)+"                         "
        b_stv=SUBSTR(m_ost,39,3)
      ***Posle "BB" su 3 mesta za redni broj pod kojim je unesen motor***
      ELSE
        m_os2=VAL(SUBSTR(m_ost,3,3))
        ***Dodaje 1 da bi ponudio prvi sledeci slobodan broj***
        m_os2=m_os2+1
        ***Spaja "BB" i prvi sledeci slobodan broj, radi ispisa***
        b_mot=SUBSTR(m_ost,1,2)+STRZERO(m_os2,3)+"                         "
      ENDIF
    ***Ako u "m_ost" nema bas nista daje oznaku za prvi motor***
    ELSE
      b_mot="BB001                         "
    ENDIF
    *** Poziva U1DAT.DBF ***
    SELECT 1
    ***Ako se korisnik odlucio za upis motora***
    IF (m_mtr="D" .OR. m_mtr="d")
      @ 23,1 SAY "Da li imas broj motora (D/N) ?";
             GET m_mot PICTURE"!" VALID(m_mot $ "DdNn")
      READ
    ENDIF
    ***Radi dok ima broj motora (=.T.)***
    DO WHILE m_mot="D" .OR. m_mot="d"
      red=red+1
      @ red,14 SAY "Broj motora : "
      @ red,28 GET b_mot PICTURE"@9" VALID(b_mot # " ")
      READ
      *** Za VK23 ***
      IF vk=23
        DO WHILE .T.
          *** Uzima broj stovarista ***
          @ red,60 SAY "STV : "GET b_stv PICTURE"999" VALID(b_stv>0)
          READ
          *** Ide u DSTOV.DBF ***
          SELECT 2
          USE dstov INDEX dstov
          *** Pretrazuje zadato stovariste ***
          SEEK b_stv
          ***Ako nadje stovariste izlazi iz procedure i nastavlja dalji upis***
          IF FOUND()
            @ red,1 CLEAR TO 23,78
            SELECT 1
            red=red-1
            RETURN
          ***Stovariste nije nadjeno***
          ELSE
            @ 23,1 SAY "Nepostojece stovariste !           "
            INKEY(3)
            @ 23,1 SAY "                                   "
            b_stv=0
            ***Vraca se radi novog pokusaja***
            LOOP
          ENDIF
        ENDDO
      ENDIF
      *** Za VK24 ***
      IF vk=24
        *** Poziva Izvodjace radova, bazu - DSOV.DBF***
        SELECT 8
        USE Stiz INDEX stizid
        ***Trazi po: stovaristu, izvodjacu radova, artiklu***
        SEEK m_stv+STR(m_izv,6)+STR(m_broj,10)
        IF FOUND()
          ***Radi dokle postoje zadate vrednosti (stv,art,izv)***
          DO WHILE VAL(m_stv)=stv .AND. m_broj=art .AND. m_izv=izv
            ***Ako uneti broj motora nadje u bazi izlazi iz petlje***
            IF b_mot=SUBSTR(ost,1,30)
              EXIT
            ***Ide na dalju pretragu***
            ELSE
              SKIP
              LOOP
            ENDIF
          ENDDO
          *** Cisti i obezbedjuje red za dalji upis ***
          @ red,1 CLEAR TO 23,78
          red=red-1
          EXIT
        ***Ako uneti broj nije nadjen***
        ELSE
          @ 22,1 SAY "Pogresan broj motora !"
          @ 23,1 SAY "Ides dalje, bez obzira !              ";
                 GET m_odg PICTURE"!"
          READ
          ***Prihvata uneto i izlazi iz procedure***
          IF m_odg="D" .OR. m_odg="d"
            @ red,1 CLEAR TO 23,78
            red=red-1
            EXIT
          ENDIF
          ***Cisti i obezbedjuje novi pokusaj unosa motora***
          @ red,1 CLEAR TO 23,78
          red=red-1
          b_mot=SPACE(30)
          LOOP
        ENDIF
      ENDIF
      ***Cisti i obezbedjuje dalji rad***
      @ red,1 CLEAR TO 23,78
      EXIT
    ENDDO
    ***Radnje u slucaju da korisnik nema broj motora***
    DO WHILE m_mot="N" .OR. m_mot="n"
      *** Za VK23 ***
      IF vk=23
        ***Unos broja motora u novi red***
        red=red+1
        @ red,14 SAY "Broj motora : "
        @ red,28 GET b_mot PICTURE"@9" VALID(b_mot # " ")
        READ
        *** Unos stovarista ***
        DO WHILE .T.
          @ red,60 SAY "STV : "GET b_stv PICTURE"999" VALID(b_stv>0)
          READ
          *** Odlazi kod DSOV.DBF ***
          SELECT 2
          USE dstov INDEX dstov
          ***Pretrazuje zadato stovariste***
          SEEK b_stv
          ***Ako nadje izlazi iz procedure i vraca se kod U1DAT.DBF***
          IF FOUND()
            @ red,1 CLEAR TO 23,78
            SELECT 1
            red=red-1
            RETURN
          ***Nije nasao stovariste***
          ELSE
            @ 23,1 SAY "Nepostojece stovariste !           "
            INKEY(3)
            @ 23,1 SAY "                                   "
            ***prazni promenljivu***
            b_stv=0
            *** Daje novi pokusaj upis broja motora ***
            LOOP
          ENDIF
        ENDDO
      ENDIF
      *** Za VK24 ***
      IF vk=24
        ***Daje ispis broja motora***
        red=red+1
        @ red,14 SAY "Broj motora : "
        @ red,28 SAY b_mot+"  "+b_stv
        INKEY(0)
        @ red,1 CLEAR TO 23,78
        SELECT 1
        red=red-1
      ENDIF
      EXIT
    ENDDO
  ENDIF
  *** Ako artikal koji se upisuje nije motor ***
  IF m_mtr="N" .OR. m_mtr="n"
    @ red+1,1 CLEAR TO 23,78
  ENDIF
  EXIT
ENDDO
SELECT 1
RETURN



**********************************************************
*      Unos sektor,sekcije                               *
**********************************************************
*** Provera unosa sektora ***
PROCEDURE SESE
PARAMETERS c
*** DLOK.DBF sadrzi sifre lokomotiva ***
SELECT 3
USE dlok INDEX dlok
SELECT 2
*** DOUR.DBF sadrzi sifre sekcija ***
USE dour INDEX dour
SELECT 1
*** U1DAT.DBF sadrzi sifre sektora ***
USE u1dat
GOTO bsl
i=0
DO WHILE .T.
  i=i+1
  IF c=1
    *--- ispravke+unos
    i=i-1
    c=0
  ELSE
    *--- unos+ispravke
    @ 03,42 GET sfdob
    READ
  ENDIF
  ***pd1 je parametar ispravnosti imena sektora***
  pd1=' '
  ***pd2 je parametar ispravnosti imena sekcije***
  pd2=' '
  ***Uzima iz baze sifru sektora+sekcije i stavlja u promenljivu "dob"***
  dob=STR(sfdob,6)
  ***Uzima po jedan znak (broj) iz sifre sektora***
  dob1a=SUBSTR(dob,1,1)
  dob1b=SUBSTR(dob,2,2)
  dob22=SUBSTR(dob,4,3)
  ***Uzima celu sifru sektora i pojedinacne cifre i konvertuje u broj***
  dob1=VAL(SUBSTR(dob,1,3))
  doba=VAL(dob1a)
  dobb=VAL(dob1b)
  dob2=VAL(dob22)
  ***Trazi sifru OUR-a iz DLOK.DBF u zadatoj matrici***
  FOR J=1 TO 13
    IF dob1=TAB911[J]  &&...sfdob 9-12 postoji u tabeli
      ***Ako nadje izlazi iz petlje***
      EXIT
    ENDIF
  NEXT
  ***Ako je izasao iz petlje "FOR..." pre kompletnog prolaska***
  IF J<=13  &&...ispravan prvi deo sfdob
    *** Ubacuje vrednost indeksa za ispravnu sifru sekcije ***
    pd1='    '
  ELSE  &&...neispravan prvi deo sfdob
    pd1='prvi'
  ENDIF
  *** Odlazi do DOUR.DBF ***
  SELECT 2
  *** Pretrazuje sifru sekcije u DOUR.DBF ***
  SEEK dob2
  IF FOUND()
    *--- ispravan drugi deo sfdob
    pd2='     '
  ELSE
    *--- neispravan drugi deo sfdob
    pd2='drugi'
  ENDIF
  SELECT 1
  ***postavlja promenljivu***
  vez=' '
  ***ako su ispravni i sekcija i sektor***
  IF pd1 # ' ' .AND. pd2 # ' '
    vez=' I '
  ENDIF
  ***povezuje u znakovni niz***
  pd=pd1+vez+pd2
  ***Ispravne su obe od cifara***
  IF pd1 = ' ' .AND. pd2 = ' '
    *--- ispravan i prvi i drugi deo sfdob
    EXIT
  ***Ako je neispravna jedna od sifara***
  ELSE
    ***ako je MAT02 ili MAT10***
    IF m_vk="02" .OR. m_vk="10"
      ***Povezuje i pretrazuje DLOK.DBF po "sfdob" iz U1DAT.DBF***
      SET RELATION TO sfdob INTO dlok
      IF sfdob=c->sfdob .AND. sfdob # 0
        ***ako pronadje, izlazi iz petlje***
        EXIT
      ***Sektora-sekcija nije pronadjena, pa se radi o lokomotivi***
      ELSE
        ***- kontrolisani podatak nije ispravan***
        ?? CHR(7)
        SET COLOR TO /w
        @ 22,01 SAY ' Neispravna SERIJA I BROJ VUCNOG VOZILA - potvrdi '
        SET COLOR TO gr+/b
        IF i=3
          ***- neka ide dalje***
          gres=TRIM(gres)+'L'
          EXIT
        ELSE
          ***- neka se popravi***
          LOOP
        ENDIF
      ENDIF
    ENDIF
    ***- postoji neka greska ...***
    ?? CHR(7)
    SET COLOR TO /w
    ***Ispisuje ("pd" - "prvi i drugi") poruku***
    @ 22,01 SAY ' Neispravan '+TRIM(pd)+' deo BROJA - potvrdi '
    SET COLOR TO gr+/b
    IF i=3
      ***- neka ide dalje***
      gres=TRIM(gres)+'X'
      EXIT
    ELSE
      ***- neka se popravi***
      LOOP
    ENDIF
  ENDIF
ENDDO
@ 22,01 CLEAR
RETURN



**********************************************************
*      Unos osnova                                       *
**********************************************************
***Provera unosa osnova***
PROCEDURE OSNO
PARAMETERS in
IF vk # 24
  ***leva strana od VK 24***
  i24=1
ENDIF
***Promenljive "pd1" i "pd2" su deo obavestenja o delu neispravnog osnova***
pd1=' '
pd2=' '
osn1=SUBSTR(osn,1,1)
osn2=SUBSTR(osn,2,1)
DO CASE
  ***Unos VK 1,2,3,4,5,30 ***
  CASE vk=1.OR.vk=2.OR.vk=3.OR.vk=4.OR.vk=5.OR.vk=30
    IF osn1 = '0'
    ELSE
      pd1='prvi'
    ENDIF
    ***obezbedjuje izvrsenje suprotnog uslova***
    IF osn2 $ '0156'
    ELSE
      pd2='drugi'
    ENDIF
  ***ako je desna strana od VK 24***
  CASE vk=24.AND.i24=2
    IF osn1 = '0'
    ELSE
      pd1='prvi'
    ENDIF
    ***ako je druga cifra osnova razlicita od "0156"***
    IF osn2 $ '0156'
    ELSE
      pd2='drugi'
    ENDIF
  ***unos leve strane VK 24***
  CASE vk=24.AND.i24=1
    IF osn1 = '1'
    ELSE
      pd1='prvi'
    ENDIF
    IF osn2 $ '0156'
    ELSE
      pd2='drugi'
    ENDIF
  ***Unos VK 10 - evidencija izlaza materijala***
  CASE vk=10
    IF osn1='1'
    ELSE
      pd1='prvi'
    ENDIF
    IF osn2 $ '012567'
    ELSE
      pd2='drugi'
    ENDIF
  *** Unos VK 11,12,13,14,20,21,23,***
  CASE vk=11.OR.vk=12.OR.vk=13.OR.vk=14.OR.vk=20.OR.vk=21.OR.vk=23
    IF osn1='1'
    ELSE
      pd1='prvi'
    ENDIF
    IF osn2 $ '0156'
    ELSE
      pd2='drugi'
    ENDIF
  OTHERWISE
ENDCASE
*** Ako je nesto uneseno u pd1 i pd2 ***
IF pd1 # ' ' .AND. pd2 # ' '
  vez=' I '
ELSE
  vez=' '
ENDIF
*** Ako je unos osnova ispravan ***
IF pd1=' ' .AND. pd2=' '
  in='i'
*** Ako je unos osnova neispravan ***
ELSE
  pd=pd1+vez+pd2
  ?? CHR(7)
  SET COLOR TO /w
  @ 22,01 SAY ' Neispravan '+TRIM(pd)+' deo OSNOVA - potvrdi '
  SET COLOR TO gr+/b
ENDIF
RETURN


**********************************************************
*      Modul 10                                          *
**********************************************************
*** Daje modul 10 za sifru artikla ***
PROCEDURE MD10
*** "poll" je broj artikla ***
PARAMETERS poll
poll1=STR(&poll,10)
sss=0
mno=2
k=9
***Omogucuje uzimanje svake od 10 cifara***
DO WHILE k>0
  ***Uzima jednu od cifara***
  p1s=SUBSTR(poll1,k,1)
  ***Mnozi se samo svaka druga cifra***
  IF mno=2
    ***mnozi cifru sa dva***
    p2v=mno*VAL(p1s)
    ***ako je proizvod dvocifren razdvaja prvu i drugu cifru***
    IF p2v>9
      p2s=STR(p2v,2)
      p31=SUBSTR(p2s,1,1)
      p32=SUBSTR(p2s,2,1)
      ***sabira proizvode cifara***
      sss=sss+VAL(p31)+VAL(p32)
    ELSE
      ***sabira proizvode cifara***
      sss=sss+p2v
    ENDIF
    ***Obavestava da je mnozenje izvrseno***
    mno=1
  ELSE
    ***Sledeci krug se ne mnozi, a sabira se sa prethodnom zbirom*** 
    sss=sss+VAL(p1s)
    mno=2
  ENDIF
  k=k-1
ENDDO
***Konvertuje u znakovni niz***
s4=STR(sss,3)
***Uzima zadnju cifru iz niza***
s5=SUBSTR(s4,3,1)
***Odredjuje kontrolni broj***
IF s5='0'
  kb=0
ELSE
  kb=10-VAL(s5)
ENDIF
RETURN



**********************************************************
*      Unos artikla                                      *
**********************************************************
***Procedura za proveru unosa artikla***
PROCEDURE ARTI
PARAMETERS c,rrr
i=0
bb=0
vv=0
rrd=rrr+2
rdd=5
m_broj=0
m_brk=0
e_kst=0
m_ost=SPACE(20)
m_nza=SPACE(42)
mi=1
DO WHILE .T.
  i=i+1
  IF c=1
    ***- ispravke+unos***
    i=i-1
    c=0
  ELSE
    ***- unos+ispravke***
    IF VAL(m_vk)=11
      *** "1471107076" je DIZEL GORIVO ***
      REPLACE broj WITH 1471107076
    ENDIF
    ***Daje mogucnost unosa drugog broja***
    @ rrr,07 GET broj
    READ
    m_broj=broj
  ENDIF
  ***Ako je upisana "0"***
  IF broj=0
    ?? CHR(7)
    SET COLOR TO /w
    @ 22,01 SAY ' Neispravan BROJ -> mora biti veci od nule ! '
    SET COLOR TO gr+/b
    IF i=3
      ***- neka ide dalje***
      gres=TRIM(gres)+'I'
    ELSE
      ***- neka se popravi***
      LOOP
    ENDIF
  ENDIF
  ***uzima broj artikla, i proverava kontrolni broj***
  pol=STR(broj,10)
  PUBLIC kb
  DO md10 WITH pol
  kb1=SUBSTR(pol,10,1)
  IF VAL(kb1)=kb
    ***- ispravan kontrolni broj***
  ELSE
    ?? CHR(7)
    SET COLOR TO /w
    @ 22,01 SAY ' Neispravan BROJ po modulu 10 - potvrdi '
    SET COLOR TO gr+/b
    IF i=3
      ***- neka ide dalje***
      gres=TRIM(gres)+'I'
    ELSE
      ***- neka se popravi***
      LOOP
    ENDIF
  ENDIF
  ***Izlaz sitnog inventara na upotrbu***
  IF VAL(m_vk)=10 .AND. VAL(m_osn)=12
    ***Ako broj artikla pocinje sa: 1,2 ili 5***
    IF SUBSTR(STR(m_broj,10),1,1)="1" .OR.;
      SUBSTR(STR(m_broj,10),1,1)="2" .OR.;
      SUBSTR(STR(m_broj,10),1,1)="5"
      @ 21,01 SAY "Greska u tabeli KONTA ili pogresna varijanta VRS/OSN/ART !!!"
      INKEY(0)
      @ 21,01 CLEAR
    ENDIF
  ***Ako kod VK10 broj artikla ne pocinje sa 147***
  ELSEIF VAL(m_vk)=11
    IF SUBSTR(STR(m_broj,10),1,3)#"147"
      @ 21,01 SAY "Greska u tabeli KONTA ili pogresna varijanta VRS/OSN/ART !!!"
      INKEY(0)
      @ 21,01 CLEAR
    ENDIF
  ***Kod VK24 ulaz i izlaz novog i polovnog materijala***
  ELSEIF VAL(m_vk)=24 .AND. (VAL(m_osn)=00 .OR. VAL(m_osn)=01 .OR.;
                             VAL(m_osn)=10 .OR. VAL(m_osn)=11)
    *** "Stiz" - stanje sa izvodjacima ***
    SELECT 8
    USE Stiz INDEX stizid
    ***Pretrazuje po:stv,art,izv***
    SEEK m_stv+STR(m_izv,6)+STR(m_broj,10)
    ***Ako je nasao "ostatak sloga"***
    IF FOUND()
      ***Radi za sve slogove sa zadatom kombinacijom (stv-art-izv)***
      DO WHILE VAL(m_stv)=stv .AND. m_broj=art .AND. m_izv=izv
        ***(vv=0) Prvi ispis i ulazak u petlju***
        IF vv=0
          @ rrd,rdd SAY "Motori :"
          vv=1
        ENDIF
        m_ost=ost
        ***Ispisuje Ostatak sloga (rrd-red, rdd-kolona)***
        @ rrd,rdd+10 SAY SUBSTR(m_ost,1,18)
        ***dodaje novi red***
        rrd=rrd+1
        ***Brojcanik za kolicinu motora na odredjenoj sifri artikla***
        m_brk=m_brk+1
        ***Daje red iz pocetka, a kolonu baca na 36***
        IF rrd=22
          rrd=red+2
          rdd=36
        ENDIF
        SKIP
      ENDDO
    ENDIF
  ENDIF
  *** Provera da li artikal ima "m_broj" (ART) u MATC.dbf ***
  SELECT 4
  USE matc INDEX matcid
  SEEK m_broj
  *** Ako artikal nije registrovan ***
  IF ! FOUND()
    SET COLOR TO /w
    @ 22,01 SAY "Ovaj BROJ se ne nalazi u tvojoj banci !"
    *** Ako su VK za IZLAZ artikla ***
    IF VAL(m_vk)>9 .AND. VAL(m_vk)#24
      @ 23,01 SAY "Nemas ga na stanju !"
      SET COLOR TO gr+/b
      INKEY(0)
    *** Ako su VK za ULAZ artikla ***
    ELSE
      @ 23,01 SAY "Bice ti automatski otvoren !"
      SET COLOR TO gr+/b
      INKEY(0)
    ENDIF
  ENDIF
  ***--------------------------------------------------------***
  ***- Dodeljivanje konta na bazi osnova ulaza - izlaza -***
  ***--------------------------------------------------------***
  DO CASE
    CASE m_osn="00" .OR. m_osn="05"
      m_kon=1
    CASE m_osn="01" .OR. m_osn="06"
      m_kon=2
    CASE m_osn="03" .OR. m_osn="08"
      m_kon=3
    CASE m_osn="04" .OR. m_osn="09"
      m_kon=4
    CASE (m_osn="10" .OR. m_osn="15") .AND. m_vk="24"
      m_kon=5
    CASE m_osn="10" .OR. m_osn="15"
      m_kon=1
    CASE (m_osn="11" .OR. m_osn="16") .AND. m_vk="24"
      m_kon=6
    CASE m_osn="11" .OR. m_osn="16"
      m_kon=2
    CASE m_osn="12" .OR. m_osn="17"
      m_kon=1
    CASE m_osn="13" .OR. m_osn="18"
      m_kon=3
    CASE m_osn="14" .OR. m_osn="19"
      m_kon=4
  END CASE
  *** Ponovo pretrazuje MATC.DBF po ART i reaguje ako je nadjeno ***
  SELECT 4
  USE matc INDEX matcid
  SEEK m_broj
  IF FOUND()
    ***Ako nadje preuzima naziv***
    m_nza=nza
  ELSE
    m_nza="Nepoznat naziv ?                    "
  ENDIF
  *** Ispisuje naziv ***
  IF (m_vk="10" .AND. m_osn="12") .OR. m_vk="23"
    @ rrr,27 SAY SUBSTR(m_nza,1,32)
  ELSE
    @ rrr,27 SAY SUBSTR(m_nza,1,42)
  ENDIF
  ***Uzima STAN.DBF gde je stanje po artiklima***
  SELECT 6
  USE stan INDEX stansd
  p_kon=0
  ***Pretrazuje po:stv,art,knt***
  IF m_vk="20" .AND. m_odl="U"
    SEEK m_dob+STR(m_broj,10)+STR(m_kon,1)
  ELSE
    SEEK m_stv+STR(m_broj,10)+STR(m_kon,1)
  ENDIF
  IF FOUND()
    ***Izlaz i storno po MAT-10 ili izlaz po MAT-23***
    IF (m_vk="10" .AND. (m_osn="12" .OR. m_osn="17")) .OR. m_vk="23"
      ***skida decimale***
      r_kst=kst/1000
      ***ispisuje "r_kst" u duzini 11 sa 3 decimale***
      @ rrr,58 SAY STR(r_kst,11,3)
      ***promena (uvecanje) konta***
      IF m_vk="10"
        p_kon=m_kon+1
      ELSE
        p_kon=m_kon+4
      ENDIF
      ***Pretrazuje po:stv,art,knt***
      SEEK m_stv+STR(m_broj,10)+STR(p_kon,1)
      IF FOUND()
        ***Ispis***
        r_kst=kst/1000
        @ rrr,69 SAY STR(r_kst,11,3)
      ***nema nista***
      ELSE
        @ rrr,75 SAY "      0.000"
      ENDIF
    ***Ako ima motora po osnovi NOVO*** 
    ELSEIF m_brk>0 .AND. SUBSTR(m_osn,1,1)="1"
      @ rrr,69 SAY STR(m_brk,11,3)
      ***kolicinu cuva***
      e_kst=m_brk
      ***cisti brojcanik***
      m_brk=0
    ELSE
      r_kst=kst/1000
      @ rrr,69 SAY STR(r_kst,11,3)
    ENDIF
  *** Ako nije nadjeno ***
  ELSE
    ***Za VK23***
    IF m_vk="23"
      @ rrr,64 SAY "      0.000"
      ***Prebacuje na obradu i doradu pa pretrzuje***
      p_kon=m_kon+4
      SEEK m_stv+STR(m_broj,10)+STR(p_kon,1)
      IF FOUND()
        r_kst=kst/1000
        @ rrr,69 SAY STR(r_kst,11,3)
      ELSE
        @ rrr,75 SAY "      0.000"
      ENDIF
    ELSE
      @ rrr,75 SAY "      0.000"
    ENDIF
  ENDIF
  SELECT 1
  EXIT
ENDDO
@ 22,01 CLEAR
@ 23,01 CLEAR
RETURN



**********************************************************
*      Kretanje po ekranu - zaglavlje                    *
**********************************************************
*** Omogucuje prebacivanje u novi red za zglavlje ***
PROCEDURE EKR1
PARAMETERS red1,col1
DO WHILE .T.
  fun=CHR(24)
  @ red1,col1 GET fun
  READ
  IF fun=CHR(24) .OR. fun=' '
    EXIT
  ELSE
    ?? CHR(7)
    LOOP
  ENDIF
ENDDO
RETURN



**********************************************************
*      Kretanje po ekranu - stavke                       *
**********************************************************
*** Omogucuje prelazak u novi red za ispis stavki ***
PROCEDURE EKR2
PARAMETERS red1,col1
DO WHILE .T.
  fun=CHR(26)
  @ red1,col1 GET fun
  READ
  IF fun=CHR(26) .OR. fun=' '
    EXIT
  ELSE
    ?? CHR(7)
    LOOP
  ENDIF
ENDDO
RETURN



**********************************************************
*      Meni izvestaja                                    *
**********************************************************
*** Stampanje i zaglavlje ***
PROCEDURE IZVE
CLEAR SCREEN
*Ponovno indeksiranje zbog eventualnih promena*
SELECT 3
USE izvr INDEX izvrid
SELECT 4
USE matc INDEX matcid
CLOSE DATABASES
SELECT 6
USE stan INDEX stanad,stansd,stankd,standd
CLOSE DATABASES
SELECT 7
USE prom INDEX promid,promdd,promvd,prombd,promad,promrd,promod
CLOSE DATABASES
SELECT 9
USE proz INDEX prozsd
CLOSE DATABASES

***Priprema baze za upotrebu***
*CLOSE DATABASES
*ERASE stamp.dbf
IF ! FILE("stamp.dbf")
 SELECT 10
 CREATE pstamp
 STORE "izborst   n2  " TO polje1
 APPEND BLANK
 REPLACE field_name WITH SUBSTR(polje1,1,10)
 REPLACE field_type WITH SUBSTR(polje1,11,1)
 REPLACE field_len WITH VAL(SUBSTR(polje1,12,2))
 REPLACE field_dec WITH VAL(SUBSTR(polje1,14,1))
 CREATE stamp FROM pstamp
 USE
 ERASE pstamp.dbf
 USE stamp
 APPEND BLANK
ELSE
 SELECT 10
 USE stamp
 REPLACE izborst WITH 0
ENDIF


***Izbor za stampanje***
DO WHILE .T.
  @ 1,0 TO 3,78 DOUBLE
  @ 5,0 TO 23,78 DOUBLE
  @ 2,3 SAY "IZVE"
  @ 2,25 SAY "IZVESTAJI I STAMPE"
  @ 2,61 SAY "''ESC'' za kraj"
  m_izbor=1
  @  6,16 PROMPT " ARTIKAL PO STOVARISTIMA             (S_ARU) ";
          MESSAGE "STANJE ARTIKLA PO SVIM STOVARISTIMA"
  @  7,16 PROMPT " DNEVNA PROMENA STANJA               (S_DNE) ";
          MESSAGE "ARTIKLI SA PROMENJENIM STANJEM"
  @  8,22 PROMPT " PREGLED STANJA ZALIHA         (S_STV) ";
          MESSAGE "STANJE ZALIHA U TVOM STOVARISTU"
  @  9,22 PROMPT " STANJE NA OSNOVU DELA SIFRE   (S_ART) ";
          MESSAGE "STANJE ZALIHA NA OSNOVU DELA SIFRE ARTIKLA"
  @ 10,22 PROMPT " LISTANJE MATICNE              (S_NAZ) ";
          MESSAGE "STANJE ZALIHA NA OSNOVU DELA NAZIVA ARTIKLA"
  @ 11,22 PROMPT " KARTA MATERIJALA              (S_KAR) ";
          MESSAGE "LISTANJE PROMENA NA ODREDJENOJ SIFRI"
  @ 12,16 PROMPT " ODREDJENI DOKUMENT/ARTIKAL          (S_DOK) ";
          MESSAGE "LISTANJE PROMENA NA ODREDJENOJ SIFRI"
  @ 13,16 PROMPT " PREGLED PROMENA                     (S_PRO) ";
          MESSAGE "LISTANJE PROMENA OD POCETKA GODINE"
  @ 14,16 PROMPT " ODREDJENI DOKUMENT                  (S_DOD) ";
          MESSAGE "LISTANJE ODREDJENOG DOKUMENTA"
  @ 15,22 PROMPT " REMONTER           MAT-23,24  (S_REM) ";
          MESSAGE "LISTANJE ODREDJENOG REMONTERA"
  @ 16,22 PROMPT " REMONTER-ZBIRNO    MAT-23,24  (S_RER) ";
          MESSAGE "ODREDJENI REMONTER - ZBIRNO"
  @ 17,22 PROMPT " MOTOR              MAT-23,24  (S_RBM) ";
          MESSAGE "ODREDJENI BROJ MOTORA"
  @ 18,22 PROMPT " ARTIKAL-REMONTER   MAT-23,24  (S_ARE) ";
          MESSAGE "LISTA PO ARTIKLIMA I REMONTERIMA"
  @ 19,16 PROMPT " UKUPNE NABAVKE                      (S_UKU) ";
          MESSAGE "NABAVKE U TOKU TEKUCE GODINE"
  @ 20,16 PROMPT " UTROSAK ARTIKALA                    (S_UTR) ";
          MESSAGE "LISTANJE UTROSKA PO ARTIKLIMA"
  @ 21,22 PROMPT " NEGATIVNO STANJE              (S_NEG) ";
          MESSAGE "LISTANJE NEGATIVNIH STAVKI"
  @ 22,22 PROMPT " NEAKTIVNE STAVKE              (S_NEA) ";
          MESSAGE "LISTANJE NEAKTIVNIH STAVKI"
  ***Potvrda izbora***
  CLEAR TYPEAHEAD
  MENU TO m_izbor
  ***Izlaz***
  IF LASTKEY()=27
   EXIT
  ENDIF

  ***Upis***
  REPLACE izborst WITH m_izbor
  DO stamplok

*  DO CASE
*    CASE LASTKEY()=27
*         EXIT
*    CASE m_izbor=1
*         DO s_aru
*    CASE m_izbor=2
*         DO s_dne
*    CASE m_izbor=3
*         DO s_stv
*    CASE m_izbor=4
*         DO s_art
*    CASE m_izbor=5
*         DO s_naz
*    CASE m_izbor=6
*         DO s_kar
*    CASE m_izbor=7
*         DO s_dok
*    CASE m_izbor=8
*         DO s_pro
*    CASE m_izbor=9
*         DO s_dod
*    CASE m_izbor=10
*         DO s_rem
*    CASE m_izbor=11
*         DO s_rer
*    CASE m_izbor=12
*         DO s_rbm
*    CASE m_izbor=13
*         DO s_are
*    CASE m_izbor=14
*         DO s_uku
*    CASE m_izbor=15
*         DO s_utr
*    CASE m_izbor=16
*         DO s_neg
*    CASE m_izbor=17
*         DO s_nea
*    OTHERWISE
*         EXIT
*  ENDCASE
ENDDO
CLOSE DATABASES
CLEAR SCREEN
RETURN



**********************************************************
*      Meni ispravki stanja, maticne i remontera         *
**********************************************************
*** Zaglavlje za ispravke ***
PROCEDURE ISPR
CLEAR SCREEN
DO WHILE .T.
  @ 1,0 TO 3,78 DOUBLE
  @ 5,0 TO 23,78 DOUBLE
  @ 2,3 SAY "ISPR"
  @ 2,20 SAY "IZMENE U MATC, STAN, PROM I IZVR"
  @ 2,61 SAY "''ESC'' za kraj"
  m_izbor=1
  @ 7,12 PROMPT " MATICNA ";
         MESSAGE "IZMENE U RELACIJI MATC"
  @ 7,26 PROMPT " STANJE ";
         MESSAGE "IZMENE U RELACIJI STAN"
  @ 7,39 PROMPT " PROMENE ";
         MESSAGE "IZMENE U RELACIJI PROM"
  @ 7,53 PROMPT " REMONTERI ";
         MESSAGE "IZMENE U RELACIJI IZVR"
  CLEAR TYPEAHEAD
  MENU TO m_izbor
  DO CASE
    CASE LASTKEY()=27
         EXIT
    CASE m_izbor=1
         DO mati
    CASE m_izbor=2
         DO stan
    CASE m_izbor=3
         DO prom
    CASE m_izbor=4
         DO remo
    OTHERWISE
         EXIT
  ENDCASE
ENDDO
CLEAR SCREEN
RETURN



**********************************************************
*      Ispravke maticne                                  *
**********************************************************
*** Ispravke MATC.DBF ***
PROCEDURE MATI
SET CONFIRM ON
SELECT 4
USE matc INDEX matcid, matcod
m_nza=SPACE(42)
m_jmr=SPACE(2)
m_art=0
m_knt=0
m_min=0
m_vre=0
m_ozn=0
m_dan="D"
*
*** Realno TAK konta ima 54, ali nemaju svi artikli pandan za polovno ***
*** zato je obradjeno samo 37 u matrici, a svih 54 se nalazi u MATC.DBF ***
DECLARE tak[37]
tak[1] =1010000
tak[2] =1010001
tak[3] =1010002
tak[4] =1010003
tak[5] =1010004
tak[6] =1010006
tak[7] =1010007
tak[8] =1010008
tak[9] =1010009
tak[10]=1010010
tak[11]=1010011
tak[12]=1010012
tak[13]=1010013
tak[14]=1010014
tak[15]=1010015
tak[16]=1010029
*
tak[17]=1020000
tak[18]=1020010
tak[19]=1020020
tak[20]=1020030
tak[21]=1020040
tak[22]=1020050
tak[23]=1020060
tak[24]=1020070
tak[25]=1020080
*
tak[26]=1030000
tak[27]=1030010
tak[28]=1030020
tak[29]=1030030
tak[30]=1030040
tak[31]=1030050
tak[32]=1030060
tak[33]=1030080
tak[34]=1030090
tak[35]=1030190
tak[36]=1031000
tak[37]=1032000
**********************
DECLARE tap[3]
tap[1] =1015000
tap[2] =1025000
tap[3] =1030070
**********************
DECLARE tar[37]
tar[1] =1010100
tar[2] =1010101
tar[3] =1010102
tar[4] =1010103
tar[5] =1010104
tar[6] =1010106
tar[7] =1010107
tar[8] =1010108
tar[9] =1010109
tar[10]=1010110
tar[11]=1010111
tar[12]=1010112
tar[13]=1010113
tar[14]=1010114
tar[15]=1010115
tar[16]=1010129
*
tar[17]=1020100
tar[18]=1020110
tar[19]=1020120
tar[20]=1020130
tar[21]=1020140
tar[22]=1020150
tar[23]=1020160
tar[24]=1020170
tar[25]=1020180
*
tar[26]=1033000
tar[27]=1033000
tar[28]=1033000
tar[29]=1033000
tar[30]=1033000
tar[31]=1033000
tar[32]=1033000
tar[33]=1033100
tar[34]=1033200
tar[35]=1033000
tar[36]=1034000
tar[37]=1035000
**********************
DECLARE tas[3]
tas[1] =1015010
tas[2] =1025010
tas[3] =1030170
**********************
DECLARE tan[12]
tan[1] =1033000
tan[2] =1033000
tan[3] =1033000
tan[4] =1033000
tan[5] =1033000
tan[6] =1033000
tan[7] =1033000
tan[8] =1033100
tan[9] =1033200
tan[10]=1033000
tan[11]=1034000
tan[12]=1035000

*** Unos novog artikla ***
@ 7,1 CLEAR TO 7,76
*** Radi do kraja ***
DO WHILE ! EOF()
  *** Naziv artikla nije upisan ***
  IF nza = "           "
    @  7,3  SAY "Sifra artikla    "+STR(art,10)
    m_art=art
    @  9,3  SAY "Naziv artikla "
    @ 11,3  SAY "Jedinica mere "
    @ 13,3  SAY "Konto         "
    @ 13,35 SAY "Konto MORA biti novi !"
    @ 15,3  SAY "Minimalne zalihe "
    @ 15,35 SAY "Bez decimalnih mesta !"
    @ 17,3  SAY "Vreme isporuke   "
    @ 17,35 SAY "U danima !"
    @ 19,3  SAY "Oznaka  "
    @  9,22 GET m_nza
    *** "m_jmr" - jedinica mere ***
    @ 11,22 GET m_jmr VALID (m_jmr $ "01,02,03,13,23,33,41,42,43,53")
    *** Konta - 7 (TAK,TAR,TAN,TAP,TAS)***
    @ 13,22 GET m_knt PICTURE "9999999";
            VALID (m_knt>1009999 .AND. m_knt<1320001)
    *** Minimalna kolicina kao signal za nabavku ***
    @ 15,22 GET m_min PICTURE "99999999999"
    *** Vreme neophodno za nabavku ***
    @ 17,22 GET m_vre PICTURE "999"
    *** Oznaka za jednokratno oznacavanje artikala po nekom osnovu ***
    @ 19,22 GET m_ozn PICTURE "9"
    READ
    REPLACE nza WITH m_nza, jmr WITH m_jmr, knt WITH m_knt,;
            min WITH m_min, vre WITH m_vre, ozn WITH m_ozn
    *** Pretraga artikla na stanju ***
    SELECT 6
    USE stan INDEX stanad,stansd,stankd,standd
    SEEK STR(m_art,10)
    IF FOUND()
      *** Radi sve dok ima odredjenog artikla ***
      DO WHILE m_art=art
        DO CASE
          *** Novo ***
          CASE kon=1
            REPLACE knt WITH m_knt
          *** Polovno ***
          CASE kon=2
            *** Ima 37 konta po TAK i TAR ***
            FOR i=1 TO 37
              ***Prebacuje sa novog na polovno***
              IF tak[i]=m_knt
                REPLACE knt WITH tar[i]
              ENDIF
            NEXT
          *** Zastarelo - novo ***
          CASE kon=3
            REPLACE knt WITH m_knt
          *** Zastarelo - polovno ***
          CASE kon=4
            *** TAS ima 3 stavke ***
            FOR i=1 TO 3
              ***Prebacuje sa novog zastarelog na polovno zastarelo***
              IF tap[i]=m_knt
                REPLACE knt WITH tas[i]
              ENDIF
            NEXT
          *** Novo na obradi i doradi ***
          CASE kon=5
            ***Kada sifra artikla pocinje sa "1"***
            IF SUBSTR(STR(m_art,10),1,1)="1"
              m_knt=1011000
            ***Kada sifra artikla pocinje sa "2"***
            ELSEIF SUBSTR(STR(m_art,10),1,1)="2"
              m_knt=1021000
            ***Kada sifra artikla pocinje sa "3" ili "4"***
            ELSEIF SUBSTR(STR(m_art,10),1,1)="3" .OR.;
                   SUBSTR(STR(m_art,10),1,1)="4"
              m_knt=1036000
            ENDIF
            REPLACE knt WITH m_knt
          ** Polovno na obradi i doradi ***
          CASE kon=6
            ***Kada sifra artikla pocinje sa "1"***
            IF SUBSTR(STR(m_art,10),1,1)="1"
              m_knt=1011100
            ***Kada sifra artikla pocinje sa "2"***
            ELSEIF SUBSTR(STR(m_art,10),1,1)="2"
              m_knt=1021100
            ***Kada sifra artikla pocinje sa "3" ili "4"***
            ELSEIF SUBSTR(STR(m_art,10),1,1)="3" .OR.;
                   SUBSTR(STR(m_art,10),1,1)="4"
              m_knt=1036100
            ENDIF
            REPLACE knt WITH m_knt
          ***"Na upotrebi" (stari konto), sad je prebaceno na "polovno"***
          CASE kon=7
            FOR i=26 TO 37
              IF tak[i]=knt
                m_knt=tan[i-25]
              ENDIF
            NEXT
            REPLACE knt WITH m_knt
        ENDCASE
        *** Uzima sledeci artikal ***
        SKIP
      ENDDO
    ENDIF
    ***Prebacuje na radno polje sa MATC.DBF***
    SELECT 4
  ENDIF
  *** Cisti promenljive ***
  m_nza=SPACE(42)
  m_jmr=SPACE(2)
  m_knt=0
  m_min=0
  m_vre=0
  SKIP
ENDDO
*** Ispravka artikala ***
@ 6,1 CLEAR TO 22,77
SELECT 4
USE matc INDEX matcid, matcod
m_sif=0
m_nza=SPACE(42)
m_jmr=SPACE(2)
m_knt=0
m_min=0
m_vre=0
m_dan="D"
DO WHILE m_dan="D"
  @ 7,5 SAY "Unesi sifru ARTIKLA : " GET m_sif PICTURE "9999999999";
        VALID (m_sif>0)
  READ
  SEEK m_sif
  IF FOUND()
    m_nza=nza
    m_jmr=jmr
    m_knt=knt
    m_ozn=ozn
    @  9,3  SAY "Naziv artikla "
    @ 11,3  SAY "Jedinica mere "
    @ 13,3  SAY "Konto         "
    @ 13,35 SAY "Konto MORA biti novi !"
    @ 15,3  SAY "Minimalne zalihe "
    @ 15,35 SAY "Bez decimalnih mesta !"
    @ 17,3  SAY "Vreme isporuke   "
    @ 17,35 SAY "U danima !"
    @ 19,3  SAY "Oznaka  "
    @  9,22 GET m_nza
    @ 11,22 GET m_jmr VALID (m_jmr $ "01,02,03,13,23,33,41,42,43,53")
    @ 13,22 GET m_knt PICTURE "9999999"
    @ 15,22 GET m_min PICTURE "99999999999"
    @ 17,22 GET m_vre PICTURE "999"
    @ 19,22 GET m_ozn PICTURE "9"
    READ
    REPLACE nza WITH m_nza, jmr WITH m_jmr, knt WITH m_knt,;
            min WITH m_min, vre WITH m_vre, ozn WITH m_ozn
    @ 21,5 SAY "Nastavljas sa izmenama D/N ? ";
           GET m_dan PICTURE "!" VALID(m_dan $ "DdNn")
    READ
    IF m_dan="D" .OR. m_dan="d"
      m_sif=0
      m_nza=SPACE(42)
      m_jmr=SPACE(2)
      m_knt=0
      m_min=0
      m_vre=0
      m_ozn=0
      LOOP
    ELSE
      m_dan="N"
      EXIT
    ENDIF
  ELSE
    @ 21,5 SAY "Ta SIFRA ARTIKLA ne postoji ! ESC-izlaz, ENTER-nova sifra"
    INKEY(0)
    IF LASTKEY()=27
      EXIT
    ENDIF
    @ 21,5 SAY "                                                         "
    m_sif=0
    LOOP
  ENDIF
ENDDO
CLEAR
SET CONFIRM OFF
CLOSE DATABASES
RETURN



**********************************************************
*      Ispravke stanja                                   *
**********************************************************
***Ispravka STAN.DBF***
PROCEDURE STAN
SET CONFIRM ON
SELECT 6
USE stan INDEX stansd,stanad,stankd,standd
m_skl=0
m_sif=0
m_kon=0
m_knt=0
m_sus=0
m_sis=0
m_kst=0
m_pst=0
m_dan="D"
***Unos podataka za pretragu (stv,art,knt)***
DO WHILE m_dan="D"
  @ 9,5 SAY "Sifra STOVARISTA : " GET m_skl PICTURE "999";
        VALID (m_skl>0)
  @11,5 SAY "Sifra ARTIKLA    : " GET m_sif PICTURE "9999999999";
        VALID (m_sif>0)
  @13,5 SAY "Selekcija        : " GET m_kon PICTURE "9";
        VALID (m_kon<8)
  @13,50 SAY "1 - Novo               "
  @14,50 SAY "2 - Polovno"
  @15,50 SAY "3 - Zastarelo - novo   "
  @16,50 SAY "4 - Zastarelo - polovno"
  @17,50 SAY "5 - Obrada,,, - novo   "
  @18,50 SAY "6 - Obrada,,, - polovno"
  @19,50 SAY "2 - Upotreba"
  READ
  ***Pretraga po zadatim kriterijumima***
  SEEK STR(m_skl,3)+STR(m_sif,10)+STR(m_kon,1)
  ***Ako nadje radi ispis i peihvata novi upis (ispravke)***
  IF FOUND()
    m_knt=knt
    m_sus=sus/1000
    m_sis=sis/1000
    m_kst=kst/1000
    m_pst=pst/1000
    @ 15,5  SAY "Konto         "
    @ 17,5  SAY "Suma ulaza    "
    @ 19,5  SAY "Suma izlaza   "
    @ 21,5  SAY "Kolicina      "
    @ 21,37 SAY "Pocetno stanje "
    @ 15,22 GET m_knt
    @ 17,22 GET m_sus PICTURE "999999999.999"
    @ 19,22 GET m_sis PICTURE "999999999.999"
    @ 21,24 GET m_kst PICTURE "9999999.999"
    @ 21,53 GET m_pst PICTURE "9999999.999"
    READ
    m_sus=m_sus*1000
    m_sis=m_sis*1000
    m_kst=m_kst*1000
    m_pst=m_pst*1000
    REPLACE knt WITH m_knt, sus WITH m_sus, sis WITH m_sis,;
            kst WITH m_kst, pst WITH m_pst
    @ 22,5 SAY "Nastavljas sa izmenama D/N ? ";
           GET m_dan PICTURE "!" VALID(m_dan $ "DdNn")
    READ
    ***Nastavak daljih izmena***
    IF m_dan="D" .OR. m_dan="d"
      m_skl=0
      m_sif=0
      m_kon=0
      LOOP
    ELSE
      EXIT
    ENDIF
  ***Nije pronadjena zadata kombinacija (stv,art,knt)***
  ELSE
    @ 22,5 SAY "To STV-ART-KON ne postoji ! ESC-izlaz, ENTER-nova sifra"
    INKEY(0)
    ***Izlazak***
    IF LASTKEY()=27
      EXIT
    ENDIF
    *** Ciscenje ***
    @ 22,5 SAY "                                                       "
    m_skl=0
    m_sif=0
    m_kon=0
    LOOP
  ENDIF
ENDDO
CLEAR
SET CONFIRM OFF
CLOSE DATABASES
RETURN



**********************************************************
*  Ispravka izvodjaca radova i broja motora u MAT-23     *              *
**********************************************************
*** Ispravka izvodjaca i motora ***
PROCEDURE PROM
SET CONFIRM ON
SELECT 7
USE prom INDEX promod,promdd,promvd,prombd,promad,promrd,promid
m_skl=0
m_rad=0
m_art=0
m_osu=SPACE(2)
m_mot=SPACE(41)
p_rad=0
m_dan="D"
*** Pretraga zadate kombinacije ***
DO WHILE m_dan="D"
  @ 9,5 SAY "Sifra STOVARISTA : " GET m_skl PICTURE "999";
        VALID (m_skl>0)
  @11,5 SAY "Izvodjac radova  : " GET m_rad PICTURE "999999"
  @13,5 SAY "Sifra artikla    : " GET m_art PICTURE "9999999999";
        VALID (m_art>0)
  READ
  IF LASTKEY()=27
    EXIT
  ENDIF
  SEEK STR(m_skl,3)+STR(m_rad,6)+STR(m_art,10)
  *** Ako nadje ispisuje sve na zadatoj kombinaciji ***
  IF FOUND()
    m_mot=ost
    m_osu=osu
    p_rad=dob
    DO WHILE m_skl=stv .AND. m_rad=dob .AND. m_art=art
      *** "vrs" u PROM.DBF sadrzi MAT oznaku ***
      *** Za MAT-23 ***
      IF vrs=23
        @ 11,34 GET p_rad PICTURE "999999"
        @ 15,5 SAY "Osnov izlaza     :  "+m_osu
        @ 17,5 SAY "Broj motora      : " GET m_mot PICTURE "@9"
        @ 22,5 SAY "Unesi novi broj !               "
        READ
        IF LASTKEY()=27
          EXIT
        ENDIF
        REPLACE dob WITH p_rad, ost WITH m_mot
        @ 22,5 SAY "Nastavljas sa izmenama D/N ? ";
               GET m_dan PICTURE "!" VALID(m_dan $ "DdNn")
        READ
        IF m_dan="D" .OR. m_dan="d"
          @ 22,5 SAY "                                "
          SKIP
          m_mot=ost
          m_osu=osu
          p_rad=0
          LOOP
        ELSE
          EXIT
        ENDIF
      *** Za bilo koji drugi MAT ***
      ELSE
        SKIP
        m_mot=ost
        m_osu=osu
        p_rad=0
        LOOP
      ENDIF
    ENDDO
    @ 22,5 SAY "Nema vise podataka na toj sifri !"
    INKEY(0)
    IF LASTKEY()=27
      EXIT
    ENDIF
  *** Ako nije nadjena zadata kombinacija ***
  ELSE
    @ 22,1 SAY "To STV-IZV-ART-MOT ne postoji ! ESC-izlaz, ENTER-nova sifra"
    INKEY(0)
    IF LASTKEY()=27
      EXIT
    ENDIF
    @ 22,1 SAY "                                                           "
    m_skl=0
    m_rad=0
    m_art=0
    LOOP
  ENDIF
ENDDO
CLEAR
SET CONFIRM OFF
CLOSE DATABASES
RETURN



**********************************************************
*      Meni remontera                                    *
**********************************************************
*** Meni za upit, upis ili stampu remontera ***
PROCEDURE REMO
SET CONFIRM ON
DO WHILE .T.
  m_izbor=1
  @ 10,20 PROMPT " UPIT / UPIS ";
         MESSAGE "IZMENE ILI UPIS NOVOG"
  @ 10,40 PROMPT " STAMPA ";
         MESSAGE "STAMPA REMONTERA"
  CLEAR TYPEAHEAD
  MENU TO m_izbor
  DO CASE
    CASE LASTKEY()=27
         EXIT
    CASE m_izbor=1
         DO rem1
    CASE m_izbor=2
         DO rem2
    OTHERWISE
         EXIT
  ENDCASE
ENDDO
@ 10,1 CLEAR TO 10,76
CLOSE DATABASES
RETURN



**********************************************************
*      Ispravka ili unos novog remontera                 *
**********************************************************
***Ispravka/unos remontera***
PROCEDURE REM1
SET CONFIRM ON
SELECT 3
USE izvr INDEX izvrid
m_rem=0
m_dom=SPACE(30)
m_dan="D"
DO WHILE m_dan="D"
  ***Prihvata sifru za pretragu***
  @ 12,5 SAY "Sifra REMONTERA : " GET m_rem PICTURE "999999";
        VALID (m_rem>0)
  READ
  IF LASTKEY()=27
    EXIT
  ENDIF
  ***Pretraga***
  SEEK m_rem
  IF FOUND()
    m_dom=dom
    @ 16,5  SAY "Naziv  "
    ***Upis naziva remontera***
    @ 16,13 GET m_dom PICTURE "@9" VALID(m_dom # " ")
    READ
    REPLACE dom WITH m_dom
    @ 22,5 SAY "Nastavljas sa izmenama (D/N) ? ";
           GET m_dan PICTURE "!" VALID(m_dan $ "DdNn")
    READ
    IF m_dan="D" .OR. m_dan="d"
      @ 22,5 SAY "                                  "
      m_rem=0
      LOOP
    ELSE
      EXIT
    ENDIF
  ***Remonter nije nadjen i predlaze se unos***
  ELSE
    @ 14,5 SAY "Unosis novog remontera !"
    @ 16,5  SAY "Naziv  "
    @ 16,13 GET m_dom PICTURE "@9"
    READ
    IF LASTKEY()=27
      EXIT
    ENDIF
    APPEND BLANK
    REPLACE izv WITH m_rem, dom WITH m_dom
    @ 22,5 SAY "Nastavljas sa unosom (D/N) ? ";
           GET m_dan PICTURE "!" VALID(m_dan $ "DdNn")
    READ
    IF m_dan="D" .OR. m_dan="d"
      @ 14,5 SAY "                        "
      @ 22,5 SAY "                                "
      m_rem=0
      LOOP
    ELSE
      EXIT
    ENDIF
  ENDIF
ENDDO
@ 10,1 CLEAR TO 22,76
SET CONFIRM OFF
CLOSE DATABASES
RETURN



**********************************************************
*      Stampa remontera                                  *
**********************************************************
***Stampa remontera***
PROCEDURE REM2
SET CONFIRM ON
m_izv=0
m_naz=SPACE(30)
aa=0
red=6
SELECT 2
USE mesto
SELECT 3
USE izvr INDEX izvrid
***Stampac nije prikljucen na paralelni port racunara i spreman za rad***
IF ! ISPRINTER()
  @ 20,10 SAY "Odustao si od stampe !"
  INKEY(2)
  SET CONFIRM OFF
  CLEAR SCREEN
  CLOSE DATABASES
  RETURN
ENDIF
***Upucuje sadrzaj komande SAY sa ekrana na printer***
SET DEVICE TO PRINT
* SET PRINTER TO STAMPA
*** Radi sve do kraja baze ***
DO WHILE ! EOF()
  ***Ispis zaglavlja pri ispisu nove stranice***
  IF aa=0
    @ 1,16 SAY "REMONTERI            "+DTOC(DATE())
    SELECT 2
    ***Milan ima umesto mesta (BGD) "MILA" i ovo samo njemu treba***
    IF mesto="MILA"
      red=8
      @ 3,1  SAY "PR005, ISPZLHT, Q1, PPK1.TPARTN"
      @ 4,1  SAY "INSERT(psif,naziv,grad,ziror)(c6,c35,c20,c18)"
    ENDIF
    SELECT 3
    @ red-3,1  SAY "---------------------------------------------"
    @ red-2,1  SAY " REMONTER         NAZIV I MESTO"
    @ red-1,1  SAY "---------------------------------------------"
    aa=1
  ENDIF
  m_izv=izv
  m_naz=dom
  @ red,3 SAY STR(izv,6)+"   "+m_naz
  red=red+1
  ***Posle 55-og reda daje novi ispis zaglavlja***
  IF red > 55
    red=6
    aa=0
  ENDIF
  SKIP
  LOOP
ENDDO
@ red,3 SAY " "
SET DEVICE TO SCREEN
@ 20,10 SAY "Zavrsena stampa !"
INKEY(3)
@ 20,10 SAY "                 "
SET CONFIRM OFF
CLOSE DATABASES
RETURN
