* MATARH.PRG PREGLED ARHIVSKIH PODATAKA
SET CONFIRM ON
CLEAR SCREEN
i_ime=SPACE(10)
n_ime=SPACE(10)
r_ime=SPACE(10)
DO WHILE .T.
  @ 1,0 TO 3,78 DOUBLE
  @ 5,0 TO 23,78 DOUBLE
  @ 2,3 SAY "MATARH"
  @ 2,25 SAY "PREGLED ARHIVE"
  @ 2,61 SAY "''ESC'' za kraj"
  m_izbor=1
  @ 7,12 PROMPT " GOD/STV/MES ";
         MESSAGE "ARHIVA PO GODINI,STOVARISTU I MESECU"
  @ 7,30 PROMPT " GOD/STV/VRS ";
         MESSAGE "ARHIVA PO GODINI,STOVARISTU I MAT OBRASCU"
  @ 7,48 PROMPT " KARTA MATERIJALA ";
         MESSAGE "ARHIVA PO GODINI,STOVARISTU,ARTIKLU I KONTU"
  CLEAR TYPEAHEAD
  MENU TO m_izbor
  DO CASE
    CASE LASTKEY()=27
         SET CONFIRM OFF
         CLEAR SCREEN
         RETURN
    CASE m_izbor=1
         DO arhmes WITH i_ime
    CASE m_izbor=2
         DO arhvrs WITH n_ime
    CASE m_izbor=3
         DO arhkar WITH r_ime
    OTHERWISE
         EXIT
  ENDCASE
ENDDO
CLEAR SCREEN
RUN DEL &i_ime
RUN DEL &n_ime
RUN DEL &r_ime
SET CONFIRM OFF
CLOSE DATABASES
RETURN
**********************************************************
PROCEDURE ARHMES
PARAMETERS i_ime
*--- arhivski podaci po godini,stovaristu i mesecu
SET CONFIRM ON
m_god=SPACE(2)
m_stv=0
m_mes=0
m_kst=0
m_ime=SPACE(10)
i_ime=SPACE(10)
aa=0
red=6
m_odl="D"
DECLARE tab[30]
tab[1]="01"
tab[2]="02"
tab[3]="03"
tab[4]="04"
tab[5]="05"
tab[9]="09"
tab[10]="10"
tab[11]="11"
tab[12]="12"
tab[13]="13"
tab[14]="14"
tab[20]="20"
tab[21]="21"
tab[23]="23"
tab[24]="24"
tab[30]="30"
*
@  9,2 SAY "Izgled liste :"
@ 10,2 SAY "                   ARHIVSKI PODACI ZA STOVARISTE xxx"
@ 11,2 SAY "Mesec xx   Godina xxxx"
@ 12,2 SAY "-------------------------------------------------------------------------"
@ 13,2 SAY "  ARTIKAL  VK OS SS-D-S  BRD  KOLICINA   OSTALI PODACI"
@ 14,2 SAY "-------------------------------------------------------------------------"
*
DO WHILE .T.
  @ 16,10 SAY "Godina            : " GET m_god PICTURE "!9"
  @ 18,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 20,10 SAY "MESEC             : " GET m_mes PICTURE "99";
          VALID(m_mes>0 .AND. m_mes<13)
  READ
  IF LASTKEY() = 27
    SET CONFIRM OFF
    CLEAR SCREEN
    RETURN
  ENDIF
  m_ime="prom"+m_god+".dbf"
  IF FILE("&m_ime")
    SELECT 1
    USE &m_ime
    i_ime="prom"+m_god+".ntx"
    IF ! FILE ("&i_ime")
      INDEX ON STR(stv,3)+STR(mes,2)+STR(art,10)+STR(vrs,2) TO &i_ime
    ENDIF
    USE &m_ime INDEX &i_ime
    GO TOP
  ELSE
    @ 22,3 SAY "Nema podataka za tu godinu !"
    INKEY(3)
    @ 22,3 SAY "                            "
    m_god=SPACE(2)
    m_stv=0
    m_mes=0
    LOOP
  ENDIF
  SEEK STR(m_stv,3)+STR(m_mes,2)
  IF FOUND()
    CLEAR SCREEN
    DO WHILE m_stv=stv .AND. m_mes=mes .AND. ! EOF()
      IF aa=0
        @ 1,1 SAY "              ARHIVSKI PODACI ZA STOVARISTE "+STR(m_stv,3)
        @ 2,1 SAY "Mesec "+STR(m_mes,2)+"   Godina "+m_god+"                                     "+DTOC(DATE())
        @ 3,1 SAY "------------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL  VK OS SS-D-S   BRD  KOLICINA   OSTALI PODACI"
        @ 5,1 SAY "------------------------------------------------------------------------------"
        aa=1
      ENDIF
      m_kst=kst/1000
      @ red,1  SAY STR(art,10)+" "+tab[vrs]+" "+osu+" "+STR(dob,6)+" "+STR(brd,5)+" "+STR(m_kst,9,3)
      @ red,40 SAY ost
      red=red+1
      IF red = 23
        red=6
        aa=0
        @ 23,1 SAY "Pritisni bilo sta za listanje !"
        INKEY(0)
        @ 6,0 CLEAR TO 23,79
      ENDIF
      SKIP
    ENDDO
    @ red,40 SAY "  "
    EXIT
  ELSE
    @ 22,3 SAY "Nema podataka za to STV/MES !"
    INKEY(3)
    @ 22,3 SAY "                             "
    m_stv=0
    m_mes=0
    LOOP
  ENDIF
ENDDO
IF LASTKEY() = 27
  SET CONFIRM OFF
  CLEAR SCREEN
  RETURN
ENDIF
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    RETURN
  ENDIF
  m_kst=0
  aa=0
  red=6
  m_odl="D"
  DECLARE tab[30]
  tab[1]="01"
  tab[2]="02"
  tab[3]="03"
  tab[4]="04"
  tab[5]="05"
  tab[9]="09"
  tab[10]="10"
  tab[11]="11"
  tab[12]="12"
  tab[13]="13"
  tab[14]="14"
  tab[20]="20"
  tab[21]="21"
  tab[23]="23"
  tab[24]="24"
  tab[30]="30"
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  SELECT 1
  USE &m_ime INDEX &i_ime
  GO TOP
  DO WHILE .T.
    SEEK STR(m_stv,3)+STR(m_mes,2)
    IF FOUND()
      CLEAR SCREEN
      DO WHILE m_stv=stv .AND. m_mes=mes .AND. ! EOF()
        IF aa=0
          @ 1,1 SAY "              ARHIVSKI PODACI ZA STOVARISTE "+STR(m_stv,3)
          @ 2,1 SAY "Mesec "+STR(m_mes,2)+"   Godina "+m_god+"                                     "+DTOC(DATE())
          @ 3,1 SAY "------------------------------------------------------------------------------"
          @ 4,1 SAY "  ARTIKAL  VK OS SS-D-S   BRD  KOLICINA   OSTALI PODACI"
          @ 5,1 SAY "------------------------------------------------------------------------------"
          aa=1
        ENDIF
        m_kst=kst/1000
        @ red,1  SAY STR(art,10)+" "+tab[vrs]+" "+osu+" "+STR(dob,6)+" "+STR(brd,5)+" "+STR(m_kst,9,3)
        @ red,40 SAY ost
        red=red+1
        IF red = 54
          red=6
          aa=0
        ENDIF
        SKIP
      ENDDO
      @ red,40 SAY "  "
      EXIT
    ENDIF
  ENDDO
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
RETURN
**********************************************************
PROCEDURE ARHVRS
PARAMETERS n_ime
*--- arhivski podaci po godini,stovaristu i MAT obrascu
SET CONFIRM ON
m_god=SPACE(2)
m_stv=0
m_mat=0
m_kst=0
k_ime=SPACE(10)
n_ime=SPACE(10)
aa=0
red=6
m_odl="D"
DECLARE tab[30]
tab[1]="01"
tab[2]="02"
tab[3]="03"
tab[4]="04"
tab[5]="05"
tab[9]="09"
tab[10]="10"
tab[11]="11"
tab[12]="12"
tab[13]="13"
tab[14]="14"
tab[20]="20"
tab[21]="21"
tab[23]="23"
tab[24]="24"
tab[30]="30"
*
@  9,2 SAY "Izgled liste :"
@ 10,2 SAY "                   ARHIVSKI PODACI ZA STOVARISTE xxx"
@ 11,2 SAY "MAT - xx   Godina xxxx"
@ 12,2 SAY "-------------------------------------------------------------------------"
@ 13,2 SAY "  ARTIKAL MES OS SS-D-S  BRD  KOLICINA   OSTALI PODACI"
@ 14,2 SAY "-------------------------------------------------------------------------"
*
DO WHILE .T.
  @ 16,10 SAY "Godina            : " GET m_god PICTURE "!9"
  @ 18,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 20,10 SAY "MAT obrazac       : " GET m_mat PICTURE "99";
          VALID(m_mat>0 .AND. m_mat<31)
  READ
  IF LASTKEY() = 27
    SET CONFIRM OFF
    CLEAR SCREEN
    RETURN
  ENDIF
  k_ime="prom"+m_god+".dbf"
  IF FILE("&k_ime")
    SELECT 1
    USE &k_ime
    n_ime="prmo"+m_god+".ntx"
    IF ! FILE ("&n_ime")
      INDEX ON STR(stv,3)+STR(vrs,2)+STR(art,10)+STR(mes,2) TO &n_ime
    ENDIF
    USE &k_ime INDEX &n_ime
    GO TOP
  ELSE
    @ 22,3 SAY "Nema podataka za tu godinu !"
    INKEY(3)
    @ 22,3 SAY "                            "
    m_god=SPACE(2)
    m_stv=0
    m_mat=0
    LOOP
  ENDIF
  SEEK STR(m_stv,3)+STR(m_mat,2)
  IF FOUND()
    CLEAR SCREEN
    DO WHILE m_stv=stv .AND. m_mat=vrs .AND. ! EOF()
      IF aa=0
        @ 1,1 SAY "              ARHIVSKI PODACI ZA STOVARISTE "+STR(m_stv,3)
        @ 2,1 SAY "MAT "+tab[vrs]+"   Godina "+m_god
        @ 3,1 SAY "------------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL MES OS SS-D-S   BRD  KOLICINA   OSTALI PODACI"
        @ 5,1 SAY "------------------------------------------------------------------------------"
        aa=1
      ENDIF
      m_kst=kst/1000
      @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+STR(dob,6)+" "+STR(brd,5)+" "+STR(m_kst,9,3)
      @ red,40 SAY ost
      red=red+1
      IF red = 23
        red=6
        aa=0
        @ 23,1 SAY "Pritisni bilo sta za listanje !"
        INKEY(0)
        @ 6,0 CLEAR TO 23,79
      ENDIF
      SKIP
    ENDDO
    @ red,40 SAY "  "
    EXIT
  ELSE
    @ 22,3 SAY "Nema podataka za to STV/MAT !"
    INKEY(3)
    @ 22,3 SAY "                             "
    m_stv=0
    m_mes=0
    LOOP
  ENDIF
ENDDO
IF LASTKEY() = 27
  SET CONFIRM OFF
  CLEAR SCREEN
  RETURN
ENDIF
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    RETURN
  ENDIF
  m_kst=0
  aa=0
  red=6
  m_odl="D"
  DECLARE tab[30]
  tab[1]="01"
  tab[2]="02"
  tab[3]="03"
  tab[4]="04"
  tab[5]="05"
  tab[9]="09"
  tab[10]="10"
  tab[11]="11"
  tab[12]="12"
  tab[13]="13"
  tab[14]="14"
  tab[20]="20"
  tab[21]="21"
  tab[23]="23"
  tab[24]="24"
  tab[30]="30"
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  SELECT 1
  USE &k_ime INDEX &n_ime
  GO TOP
  DO WHILE .T.
    SEEK STR(m_stv,3)+STR(m_mat,2)
    IF FOUND()
      CLEAR SCREEN
      DO WHILE m_stv=stv .AND. m_mat=vrs .AND. ! EOF()
        IF aa=0
          @ 1,1 SAY "              ARHIVSKI PODACI ZA STOVARISTE "+STR(m_stv,3)
          @ 2,1 SAY "MAT "+tab[vrs]+"   Godina "+m_god
          @ 3,1 SAY "------------------------------------------------------------------------------"
          @ 4,1 SAY "  ARTIKAL MES OS SS-D-S   BRD  KOLICINA   OSTALI PODACI"
          @ 5,1 SAY "------------------------------------------------------------------------------"
          aa=1
        ENDIF
        m_kst=kst/1000
        @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+STR(dob,6)+" "+STR(brd,5)+" "+STR(m_kst,9,3)
        @ red,40 SAY ost
        red=red+1
        IF red = 54
          red=6
          aa=0
        ENDIF
        SKIP
      ENDDO
      @ red,40 SAY "  "
      EXIT
    ENDIF
  ENDDO
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
RETURN
**********************************************************
PROCEDURE ARHKAR
PARAMETERS r_ime
*--- arhivski podaci po godini,stovaristu,artiklu i kontu
SET CONFIRM ON
CLEAR SCREEN
*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "ARHKAR"
@ 2,21 SAY "KARTA MATERIJALA-ARHIVSKA"
@ 2,61 SAY "''ESC'' za kraj"
*
m_god=SPACE(2)
m_stv=0
m_art=0
m_kst=0
m_pst=0
k_ime=SPACE(10)
r_ime=SPACE(10)
m_nza=SPACE(42)
m_jmr=SPACE(3)
m_pit=SPACE(70)
m_knt=0
m_ula=0
m_izl=0
m_sta=0
m_uk1=0
m_uk2=0
c_ula=SPACE(11)
c_izl=SPACE(11)
m_sel=0
m_i24=" "
red=7
m_odl="D"
aa=0
pol=SPACE(20)
DECLARE tak[7]
tak[1]="Novo               "
tak[2]="Polovno            "
tak[3]="Zastarelo - novo   "
tak[4]="Zastarelo - polovno"
tak[5]="Obrada,,, - novo   "
tak[6]="Obrada,,, - polovno"
tak[7]="Upotreba           "
DECLARE taj[53]
taj[01]="KOM"
taj[02]="PAR"
taj[03]="GAR"
taj[13]="M 1"
taj[23]="M 2"
taj[33]="M 3"
taj[41]="GR "
taj[42]="KG "
taj[43]="T  "
taj[53]="L  "
DECLARE tss[9]
tss[1]="199"
tss[2]="299"
tss[3]="399"
tss[4]="499"
tss[5]="599"
tss[6]="699"
tss[7]="799"
tss[8]="899"
tss[9]="988"
DECLARE tas[9]
tas[1]="Sektor STP "
tas[2]="Sektor VV  "
tas[3]="Sektor ZOP "
tas[4]="Sektor ETP "
tas[5]="Sektor ZOVS"
tas[6]="Sektor UPR "
tas[7]="Sektor COK "
tas[8]="Sektor NAB "
tas[9]="Sektor DRS "
*
@  6,1 SAY "Izgled liste :"
@  7,1 SAY "Godina               KARTA MATERIJALA - konto                         MAT-56 B"
@  8,1 SAY "Stovariste : xxx               DATUM"
@  9,1 SAY "Artikal    : xxxxxxxxxx  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xx xxxxxxx"
@ 10,1 SAY "------------------------------------------------------------------------------"
@ 11,1 SAY " DATUM   VRS OSN  BRDDOBAVLJAC-KORISNIK-STOVARISTE    ULAZ    IZLAZ     STANJE"
@ 12,1 SAY "------------------------------------------------------------------------------"
*
SELECT 1
USE Prom INDEX promdd
GO TOP
SELECT 2
USE Matc INDEX matcid
GO TOP
@ 15,9 CLEAR
DO WHILE .T.
  @ 14,10 SAY "Godina            : " GET m_god PICTURE "!9"
  @ 16,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 18,10 SAY "Sifra ARTIKLA     : " GET m_art PICTURE "9999999999";
          VALID(m_art>0)
  @ 20,10 SAY "Selekcija         : " GET m_sel PICTURE "9";
          VALID(m_sel>0)
  @ 17,50 SAY "1 - Novo"
  @ 18,50 SAY "2 - Polovno"
  @ 19,50 SAY "3 - Zastarelo - novo"
  @ 20,50 SAY "4 - Zastarelo - polovno"
  @ 21,50 SAY "5 - Obrada ,,, - novo"
  @ 22,50 SAY "6 - Obrada ,,, - polovno"
  @ 23,50 SAY "7 - Upotreba"
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  k_ime="prom"+m_god+".dbf"
  IF FILE("&k_ime")
    SELECT 1
    USE &k_ime
    n_ime="porm"+m_god+".ntx"
    IF ! FILE ("&n_ime")
      INDEX ON STR(stv,3)+STR(art,10)+DTOS(dat) TO &n_ime
    ENDIF
    USE &k_ime INDEX &n_ime
    GO TOP
  ELSE
    @ 22,3 SAY "Nema podataka za tu godinu !"
    INKEY(3)
    @ 22,3 SAY "                            "
    m_god=SPACE(2)
    m_stv=0
    m_art=0
    m_sel=0
    LOOP
  ENDIF
  SELECT 2
  USE Matc INDEX matcid
  GO TOP
  SEEK m_art
  IF FOUND() .AND. nza#"  "
    m_nza=nza
    m_jmr=taj[VAL(jmr)]
  ELSE
    m_nza="Nepoznat naziv ?                          "
    m_jmr="   "
  ENDIF
  SELECT 1
  USE &k_ime INDEX &n_ime
  GO TOP
  SEEK STR(m_stv,3)+STR(m_art,10)
  IF ! FOUND()
    @ 22,1 SAY "Tog STOVARISTA-ARTIKLA nema u promenama !"
    INKEY(3)
    @ 22,1 SAY "                                         "
    LOOP
  ENDIF
  CLEAR SCREEN
  DO WHILE m_art=art .AND. ! EOF()
    IF aa=0
      @ 1,1 SAY "Godina     : "+m_god+"       KARTA MATERIJALA - "+tak[m_sel]+"         MAT-56 B"
      @ 2,1 SAY "Stovariste : "+STR(stv,3)+"                                             Datum : "+DTOC(DATE())
      @ 3,1 SAY "Artikal    : "+STR(art,10)+" "+m_nza+m_jmr+" "+STR(m_knt,7)
      @ 4,1 SAY "------------------------------------------------------------------------------"
      @ 5,1 SAY " DATUM   VK OSN  BRD  DOBAV.-KORISN.-STOVAR.        ULAZ      IZLAZ     STANJE"
      @ 6,1 SAY "------------------------------------------------------------------------------"
      aa=1
    ENDIF
    DO CASE
      CASE m_sel=1
        IF osu="00" .AND. vrs#09
          IF vrs=24
            m_i24="L"
          ENDIF
          m_ula=kst
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="05" .AND. vrs#09
          m_ula=kst*(-1)
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="10" .AND. vrs#24 .AND. brd<4000
          m_ula=0
          m_izl=kst
          m_sta=m_sta-m_izl
        ELSEIF osu="10" .AND. vrs=20 .AND. brd>4000
          m_ula=kst
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="15" .AND. vrs#24 .AND. brd<4000
          m_ula=0
          m_izl=kst*(-1)
          m_sta=m_sta-m_izl
        ELSEIF osu="15" .AND. vrs=20 .AND. brd>4000
          m_ula=kst*(-1)
          m_izl=0
          m_sta=m_sta+m_ula
        ELSE
          SKIP
          LOOP
        ENDIF
      CASE m_sel=2
        IF osu="01"
          m_ula=kst
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="06"
          m_ula=kst*(-1)
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="11" .AND. vrs=20 .AND. brd>4000
          m_ula=kst
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="11" .AND. vrs#24
          m_ula=0
          m_izl=kst
          m_sta=m_sta-m_izl
        ELSEIF osu="16" .AND. vrs=20 .AND. brd>4000
          m_ula=kst*(-1)
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="16" .AND. vrs#24
          m_ula=0
          m_izl=kst*(-1)
          m_sta=m_sta-m_izl
        ELSEIF osu="12" .AND. vrs#23 .AND. vrs#24
          m_ula=kst
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="17" .AND. vrs#23 .AND. vrs#24
          m_ula=kst*(-1)
          m_izl=0
          m_sta=m_sta+m_ula
        ELSE
          SKIP
          LOOP
        ENDIF
      CASE m_sel=3
        IF osu="03"
          m_ula=kst
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="08"
          m_ula=kst*(-1)
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="13"
          m_ula=0
          m_izl=kst
          m_sta=m_sta-m_izl
        ELSEIF osu="18"
          m_ula=0
          m_izl=kst*(-1)
          m_sta=m_sta-m_izl
        ELSE
          SKIP
          LOOP
        ENDIF
      CASE m_sel=4
        IF osu="04"
          m_ula=kst
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="09"
          m_ula=kst*(-1)
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="14"
          m_ula=0
          m_izl=kst
          m_sta=m_sta-m_izl
        ELSEIF osu="19"
          m_ula=0
          m_izl=kst*(-1)
          m_sta=m_sta-m_izl
        ELSE
          SKIP
          LOOP
        ENDIF
      CASE m_sel=5
        IF osu="10" .AND. vrs=23
          m_ula=kst
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="15" .AND. vrs=23
          m_ula=kst*(-1)
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="10" .AND. vrs=24
          m_i24="D"
          m_ula=0
          m_izl=kst
          m_sta=m_sta-m_izl
        ELSEIF osu="15" .AND. vrs=24
          m_i24="D"
          m_ula=0
          m_izl=kst*(-1)
          m_sta=m_sta-m_izl
        ELSE
          SKIP
          LOOP
        ENDIF
      CASE m_sel=6
        IF osu="11" .AND. vrs=23
          m_ula=kst
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="16" .AND. vrs=23
          m_ula=kst*(-1)
          m_izl=0
          m_sta=m_sta+m_ula
        ELSEIF osu="11" .AND. vrs=24
          m_i24="D"
          m_ula=0
          m_izl=kst
          m_sta=m_sta-m_izl
        ELSEIF osu="16" .AND. vrs=24
          m_i24="D"
          m_ula=0
          m_izl=kst*(-1)
          m_sta=m_sta-m_izl
        ELSE
          SKIP
          LOOP
        ENDIF
      CASE m_sel=7
        IF osu="12"
          m_ula=0
          m_izl=kst
          m_sta=m_sta-m_izl
        ELSEIF osu="17"
          m_ula=0
          m_izl=kst*(-1)
          m_sta=m_sta-m_izl
        ELSE
          SKIP
          LOOP
        ENDIF
    ENDCASE
    @ red,1  SAY DTOC(dat)+" "+STR(vrs,2)+" "+osu+" "+m_i24+STR(brd,5)
    pol=STR(dob,6)
    FOR i = 1 TO 9
      IF SUBSTR(STR(dob),1,3)=tss[i]
        pol=tas[i]
      ENDIF
    NEXT
    IF vrs=01 .OR. vrs=12
      pol=SUBSTR(dom,1,20)
    ENDIF
    IF vrs=20
      pol=STR(dob,6)
    ENDIF
    @ red,23 SAY pol
    IF m_ula=0
      c_ula="        ---"
    ELSE
      c_ula=STR(m_ula/1000,11,3)
      m_uk1=m_uk1+m_ula/1000
    ENDIF
    IF m_izl=0
      c_izl="        ---"
    ELSE
      c_izl=STR(m_izl/1000,11,3)
      m_uk2=m_uk2+m_izl/1000
    ENDIF
    m_sta=m_sta/1000
    @ red,46 SAY c_ula+c_izl+STR(m_sta,11,3)
    m_sta=m_sta*1000
    pol=SPACE(20)
    m_i24=" "
    red=red+1
    IF red > 21
      red=7
      aa=0
      @ 23,1 SAY "Pritisni bilo sta za listanje !"
      INKEY(0)
      @ 7,0 CLEAR TO 23,79
    ENDIF
    IF LASTKEY() = 27
      EXIT
    ENDIF
    SKIP
    LOOP
  ENDDO
  IF LASTKEY() = 27
    EXIT
  ENDIF
  @ red,40 SAY "Ukupno"+STR(m_uk1,11,3)+STR(m_uk2,11,3)
  red=red+1
  @ red,40 SAY "  "
  EXIT
ENDDO
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  m_ula=0
  m_izl=0
  c_ula=SPACE(11)
  c_izl=SPACE(11)
  m_sta=0
  m_knt=0
  m_uk1=0
  m_uk2=0
  aa=0
  red=7
  INKEY(0)
  *
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  USE &k_ime INDEX &n_ime
  SELECT 2
  USE Matc INDEX matcid
  GO TOP
  GO TOP
  DO WHILE .T.
    SET DEVICE TO PRINT
    * SET PRINTER TO STAMPA
    SELECT 2
    USE Matc INDEX matcid
    GO TOP
    SEEK m_art
    IF FOUND() .AND. nza#"  "
      m_nza=nza
      m_jmr=taj[VAL(jmr)]
    ELSE
      m_nza="Nepoznat naziv ?                          "
      m_jmr="   "
    ENDIF
    SELECT 1
    USE &k_ime INDEX &n_ime
    GO TOP
    SEEK STR(m_stv,3)+STR(m_art,10)
    DO WHILE m_art=art .AND. ! EOF()
      IF aa=0
        @ 1,1 SAY "Godina     : "+m_god+"      KARTA MATERIJALA - "+tak[m_sel]+"          MAT-56 B"
        @ 2,1 SAY "Stovariste : "+STR(stv,3)+"                                             Datum : "+DTOC(DATE())
        @ 3,1 SAY "Artikal    : "+STR(art,10)+" "+m_nza+m_jmr+" "+STR(m_knt,7)
        @ 4,1 SAY "------------------------------------------------------------------------------"
        @ 5,1 SAY " DATUM   VK OSN  BRD  DOBAV.-KORISN.-STOVAR.        ULAZ      IZLAZ     STANJE"
        @ 6,1 SAY "------------------------------------------------------------------------------"
        aa=1
      ENDIF
      DO CASE
        CASE m_sel=1
          IF osu="00" .AND. vrs#09
            IF vrs=24
              m_i24="L"
            ENDIF
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="05" .AND. vrs#09
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="10" .AND. vrs#24 .AND. brd<4000
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="10" .AND. vrs=20 .AND. brd>4000
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="15" .AND. vrs#24 .AND. brd<4000
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSEIF osu="15" .AND. vrs=20 .AND. brd>4000
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=2
          IF osu="01"
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="06"
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="11" .AND. vrs=20 .AND. brd>4000
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="11" .AND. vrs#24
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="16" .AND. vrs=20 .AND. brd>4000
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="16" .AND. vrs#24
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSEIF osu="12" .AND. vrs#23 .AND. vrs#24
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="17" .AND. vrs#23 .AND. vrs#24
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=3
          IF osu="03"
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="08"
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="13"
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="18"
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=4
          IF osu="04"
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="09"
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="14"
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="19"
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=5
          IF osu="10" .AND. vrs=23
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="15" .AND. vrs=23
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="10" .AND. vrs=24
            m_i24="D"
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="15" .AND. vrs=24
            m_i24="D"
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=6
          IF osu="11" .AND. vrs=23
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="16" .AND. vrs=23
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="11" .AND. vrs=24
            m_i24="D"
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="16" .AND. vrs=24
            m_i24="D"
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=7
          IF osu="12"
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="17"
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSE
            SKIP
            LOOP
          ENDIF
      ENDCASE
      @ red,1  SAY DTOC(dat)+" "+STR(vrs,2)+" "+osu+" "+m_i24+STR(brd,5)
      pol=STR(dob,6)
      FOR i = 1 TO 9
        IF SUBSTR(STR(dob),1,3)=tss[i]
          pol=tas[i]
        ENDIF
      NEXT
      IF vrs=01 .OR. vrs=12
        pol=SUBSTR(dom,1,20)
      ENDIF
      IF vrs=20
        pol=STR(dob,6)
      ENDIF
      @ red,23 SAY pol
      IF m_ula=0
        c_ula="        ---"
      ELSE
        c_ula=STR(m_ula/1000,11,3)
        m_uk1=m_uk1+m_ula/1000
      ENDIF
      IF m_izl=0
        c_izl="        ---"
      ELSE
        c_izl=STR(m_izl/1000,11,3)
        m_uk2=m_uk2+m_izl/1000
      ENDIF
      m_sta=m_sta/1000
      @ red,46 SAY c_ula+c_izl+STR(m_sta,11,3)
      m_sta=m_sta*1000
      pol=SPACE(20)
      m_i24=" "
      red=red+1
      IF red > 58
        red=7
        aa=0
      ENDIF
      SKIP
      LOOP
    ENDDO
    EXIT
  ENDDO
  @ red,40 SAY "Ukupno"+STR(m_uk1,11,3)+STR(m_uk2,11,3)
  red=red+1
  @ red,40 SAY "  "
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN
