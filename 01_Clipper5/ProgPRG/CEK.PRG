* CEK.PRG - INICIJALNI PROGRAM PRACENJA CEKOVA
CLEAR
SET BELL OFF
SET DELETE ON
SET DATE GERMAN
SET WRAP ON
SET MESSAGE TO 24 CENTER
SET CONFIRM OFF
SET CURSOR OFF
SET INTENSITY OFF
datum=DATE()
PUBLIC datum
@ 2,12 TO 17,69 DOUBLE
@ 3,14 SAY "²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²"
INKEY(0.1)
@ 4,14 SAY "²²²                                                ²²²"
INKEY(0.1)
@ 5,14 SAY "²²²  ÛÛÛÛÛÛ  ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛÛÛß  Ü²²²"
INKEY(0.1)
@ 6,14 SAY "²²²  ÛÛÛÛÛÛ  ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛß  Ü²²²²²"
INKEY(0.1)
@ 7,14 SAY "²²²  ÛÛÛÛÛÛ  ÛÛÛÛÛÛ                ÛÛÛÛÛÛÛÛß  Ü²²²²²²²"
INKEY(0.1)
@ 8,14 SAY "²²²  ÛÛÛÛÛÛ  ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛÛÛ  ßßßßßßß  Ü²²²²²²²²²"
INKEY(0.1)
@ 9,14 SAY "²²²  ÛÛÛÛÛÛ  ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛÛÛ  ÜÜÜÜÜÜÜ  ß²²²²²²²²²"
INKEY(0.1)
@10,14 SAY "²²²          ÛÛÛÛÛÛ                ÛÛÛÛÛÛÛÛÜ  ß²²²²²²²"
INKEY(0.1)
@11,14 SAY "²²²²²²²²²²   ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛÜ  ß²²²²²"
INKEY(0.1)
@12,14 SAY "²²²²²²²²²²   ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛÛÛÛÛÜ  ß²²²"
INKEY(0.1)
@13,14 SAY "²²²²²²²²²²                                         ²²²"
INKEY(0.1)
@14,14 SAY "²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²"
INKEY(0.1)
@15,14 SAY "²²²²²²²²a²u²t²o²r²²:²²M²i²l²a²n²²P²e²j²o²v²i²c²²²²²²²²"
INKEY(0.1)
@16,14 SAY "²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²²"
INKEY(0.1)
@19,9  TO 23,49 DOUBLE
@19,53 TO 23,71 DOUBLE
@21,14 SAY "PRACENJE STANJA I UTROSKA CEKOVA"
INKEY(0.1)
red=2
IF ! FILE("prom.dbf")
 CREATE pprom
 STORE "broj      n7 0" TO polje1
 STORE "dati      d8  " TO polje2
 STORE "datv      d8  " TO polje3
 STORE "izno      n9 2" TO polje4
 STORE "opis      c30 " TO polje5
 STORE "real      n1 0" TO polje6
 FOR i=1 TO 6
 STORE STR(i,1) TO broj
 APPEND BLANK
 STORE "polje"+broj TO p1
 REPLACE field_name WITH SUBSTR(&p1,1,10)
 REPLACE field_type WITH SUBSTR(&p1,11,1)
 REPLACE field_len WITH VAL(SUBSTR(&p1,12,2))
 REPLACE field_dec WITH VAL(SUBSTR(&p1,14,1))
 NEXT
 CREATE prom FROM pprom
 INDEX ON broj TO promid
 INDEX ON datv TO promvd
 USE
 ERASE pprom.dbf
ENDIF
IF ! FILE("ulaz.dbf")
 CREATE pulaz
 STORE "redb      n3  " TO polje1
 STORE "datu      d8  " TO polje2
 STORE "izno      n9 2" TO polje3
 STORE "opis      c30 " TO polje4
 STORE "stan      n9 2" TO polje5
 FOR i=1 TO 5
 STORE STR(i,1) TO broj
 APPEND BLANK
 STORE "polje"+broj TO p1
 REPLACE field_name WITH SUBSTR(&p1,1,10)
 REPLACE field_type WITH SUBSTR(&p1,11,1)
 REPLACE field_len WITH VAL(SUBSTR(&p1,12,2))
 REPLACE field_dec WITH VAL(SUBSTR(&p1,14,1))
 NEXT
 CREATE ulaz FROM pulaz
 INDEX ON datu TO ulazid
 INDEX ON redb TO ulazrd
 USE
 ERASE pulaz.dbf
ENDIF

IF ! FILE("promid.ntx")
 red=red+1
 @red,3 SAY "INDEKSIRANJE PROM PO BROJ-u"
 USE prom
 INDEX ON broj TO promid
ENDIF

IF ! FILE("promvd.ntx")
 red=red+1
 @red,3 SAY "INDEKSIRANJE PROM PO DATV-u"
 USE prom
 INDEX ON datv TO promvd
ENDIF

IF ! FILE("ulazid.ntx")
 red=red+1
 @red,3 SAY "INDEKSIRANJE ULAZ PO DATU-mu"
 USE ulaz
 INDEX ON datu TO ulazid
ENDIF

IF ! FILE("ulazrd.ntx")
 red=red+1
 @red,3 SAY "INDEKSIRANJE ULAZ PO REDB-u"
 USE ulaz
 INDEX ON redb TO ulazrd
ENDIF
a = 0
loz = SPACE(5)
lov = SPACE(5)
lov = "ATSOP"
DO WHILE lov = "ATSOP"
 @21,55 SAY "Unesi lozinku !"
 SET COLOR TO \N
 @22,55 GET loz PICTURE "@!" VALID(loz#"     ")
 READ
 SET COLOR TO
 IF lov # loz
  @21,55 SAY "  Pogresna !!! "
  loz = SPACE(5)
  INKEY(2)
  a=a+1
  IF a=3
   @21,55 SAY "Cao nema vise !"
   INKEY(2)
   CLEAR SCREEN
   @ 8,25 TO 12,45 DOUBLE
   @10,30 SAY "ZAVRSEN RAD"
   INKEY(2)
   CLEAR ALL
   CLEAR SCREEN
   QUIT
  ENDIF
  LOOP
 ENDIF
 EXIT
ENDDO
SET CURSOR ON
SET INTENSITY ON
DO cek_meni
***************************************************
* CEK_MENI - PROGRAM ZA GLAVNI MENI
PROCEDURE CEK_MENI
DO WHILE .T.
 CLEAR SCREEN
 @ 1,0 TO 3,78 DOUBLE
 @ 5,0 TO 23,78 DOUBLE
 @ 2,3 SAY "CEK_MENI"
 @ 2,25 SAY "GLAVNI IZBOR"
 @ 2,61 SAY "''ESC'' za kraj"
 m_izbor=1
 @ 8,25 PROMPT "UNOS PROMENA";
        MESSAGE "UNOS IZDATIH CEKOVA"
 @10,35 PROMPT "ISPRAVKA PROMENA";
        MESSAGE "ISPRAVKA BILO KOG UNETOG PODATKA"
 @12,25 PROMPT "UNOS REALIZOVANIH CEKOVA";
        MESSAGE "AZURIRANJE IZDATIH CEKOVA"
 @14,25 PROMPT "ULAZ PRIMANJA";
        MESSAGE "UNOS NOVIH PRIMANJA"
 @16,35 PROMPT "ISPRAVKA ULAZ-a";
        MESSAGE "ISPRAVKA BILO KOG UNETOG PODATKA"
 @18,25 PROMPT "UNOS NOVIH CEKOVA";
        MESSAGE "UNOS BROJEVA NOVODOBIJENE SERIJE CEKOVA"
 @20,25 PROMPT "PREGLEDI";
        MESSAGE "SVE VRSTE PREGLEDA STANJA"
 CLEAR TYPEAHEAD
 MENU TO m_izbor
 DO CASE
  CASE LASTKEY()=27
       EXIT
  CASE m_izbor=1
       DO prm_meni
  CASE m_izbor=2
       DO prm_ispr
  CASE m_izbor=3
       DO pro_meni
  CASE m_izbor=4
       DO ula_meni
  CASE m_izbor=5
       DO ula_ispr
  CASE m_izbor=6
       DO uno_ceko
  CASE m_izbor=7
       DO pre_meni
 ENDCASE
ENDDO
CLEAR SCREEN
@ 8,25 TO 12,45 DOUBLE
@10,30 SAY "ZAVRSEN RAD"
INKEY(2)
CLEAR ALL
CLEAR SCREEN
QUIT
***************************************************
* PRM_MENI - MENI PROMENA
PROCEDURE PRM_MENI
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRM_MENI"
@ 2,25 SAY "UNOS NOVOG SLOGA PROMENA"
@ 2,61 SAY "''ESC'' za kraj"
m_upis="D"
m_broj=0
@ 6,3 SAY "Proveri da li je DATUM ispravan ?"
RUN DATE
m_dati=DATE()
m_datv=DATE()
m_dav=SPACE(8)
m_dai=SPACE(8)
m_izno=0
m_opis=SPACE(30)
m_real=0
@ 6,0 CLEAR
DO WHILE m_upis="D"
 SELECT 1
 USE prom INDEX promid, promvd
 @  6,3 SAY "BROJ CEKA        " GET m_broj PICTURE "9999999";
       VALID(m_broj>0)
 @  8,3 SAY "DATUM IZDAVANJA  "
 @ 10,3 SAY "DATUM VAZENJA    "
 @ 12,3 SAY "IZNOS            "
 @ 14,3 SAY "OPIS             "
 READ
 IF LASTKEY()=27
  EXIT
 ENDIF
 SEEK m_broj
 IF .NOT. FOUND()
  @ 6,35 SAY "Taj broj ceka ne postoji !"
  INKEY(2)
  m_broj=0
  @ 6,35 SAY "                          "
  LOOP
 ENDIF
 IF izno <> 0
  @ 6,35 SAY "Taj cek je vec unet !"
  INKEY(2)
  m_broj=0
  @ 6,35 SAY "                     "
  LOOP
 ENDIF
 @  8,21 GET m_dati PICTURE "@D"
 READ
 m_dai=DTOC(m_dati)
 m_dati=CTOD(m_dai)
 @ 10,21 GET m_datv PICTURE "@D"
 READ
 m_dav=DTOC(m_datv)
 m_datv=CTOD(m_dav)
 @ 12,21 GET m_izno PICTURE "9999999.99"
 @ 14,21 GET m_opis PICTURE "@!"
 READ
 IF LASTKEY() = 27
  EXIT
 ENDIF
 m_izbor=1
 @22,29 PROMPT "UNOS - DA";
        MESSAGE "UPIS SLOGA U RELACIJU"
 @22,41 PROMPT "UNOS - NE";
        MESSAGE "ODUSTAJE SE OD UPISA"
 CLEAR TYPEAHEAD
 MENU TO m_izbor
 DO CASE
  CASE m_izbor=2 .OR. LASTKEY()=27
       CLEAR GETS
       @ 5,0 CLEAR
       m_broj=0
       m_opis=SPACE(30)
       m_real=0
       LOOP
  CASE m_izbor=1
       IF m_izno=0
        m_real=2
       ENDIF
       REPLACE broj WITH m_broj, dati WITH m_dati, datv WITH m_datv,;
               izno WITH m_izno, opis WITH m_opis, real WITH m_real
       m_real=0
 ENDCASE
 @ 22,0 CLEAR
 @ 22,20 SAY "Da li nastavljas unos (D/N)?" GET m_upis;
         PICTURE "!" VALID(m_upis $ "DNdn")
 READ
 @ 5,0 CLEAR
 m_dati=DATE()
 m_datv=DATE()
 m_opis=SPACE(30)
 m_izno=0
 m_real=0
ENDDO
USE
RELEASE ALL
RETURN
***************************************************
* PRM_ISPR - ISPRAVKA UNETIH PROMENA
PROCEDURE PRM_ISPR
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRM_ISPR"
@ 2,25 SAY "ISPRAVKA UNETIH PROMENA"
@ 2,61 SAY "''ESC'' za kraj"
m_br = 0
crta = REPLICATE("-",78)
red = 9
m_broj = 0
m_dati = DATE()
m_datv = DATE()
m_izno = 0
m_opis = SPACE(30)
m_real = 0
m_seri = 0
a = 1
SELECT 1
USE prom INDEX promid, promvd
DO WHILE m_seri = 0
 @ 5,1 SAY "Unesi broj serije  " GET m_seri PICTURE "9999";
       VALID(m_seri>0)
 READ
 DO WHILE SUBSTR(STR(broj,7),1,4) # STR(m_seri,4)
  SKIP
  IF EOF()
   EXIT
  ENDIF
 ENDDO
 IF EOF()
  @ 5,35 SAY "Ta serija ne postoji !"
  INKEY(0)
  GO TOP
  @ 5,35 SAY "                      "
  m_seri = 0
  IF LASTKEY() = 27
   EXIT
  ENDIF
  LOOP
 ENDIF
ENDDO
@  6,1  SAY crta
@  7,1  SAY "BR. CEKA  DAT.IZDAV. DAT.VAZENJA   IZNOS    OPIS"
@  7,75 SAY "REAL"
@  8,1  SAY crta
DO WHILE .T.
 @ 24,1 SAY "END - izmene u slogu !             "
 DO WHILE m_seri = VAL(SUBSTR(STR(broj,7),1,4))
  m_broj = broj
  m_dati = dati
  m_datv = datv
  m_izno = izno
  m_opis = opis
  m_real = real
  @ red,1  GET m_broj PICTURE "9999999"
  @ red,11 SAY m_dati
  @ red,23 SAY m_datv
  @ red,33 SAY m_izno
  @ red,45 SAY m_opis
  @ red,76 SAY m_real
  SKIP
  IF EOF()
   EXIT
  ENDIF
  READ
  INKEY(0)
  IF LASTKEY() = 6
   SEEK m_broj
   IF A->real = 0
    @ red,1  GET m_broj PICTURE "9999999"
    @ red,11 GET m_dati PICTURE "@D"
    @ red,23 GET m_datv PICTURE "@D"
    @ red,32 GET m_izno PICTURE "9999999.99"
    @ red,45 GET m_opis PICTURE "@!"
    @ red,76 GET m_real PICTURE "9"
    READ
    REPLACE dati WITH m_dati,;
            datv WITH m_datv, izno WITH m_izno,;
            opis WITH m_opis, real WITH m_real
   ELSEIF A->real = 1
    @ 23,1 SAY "Taj cek je realizovan !"
   ELSE
    @ 23,1 SAY "Taj cek je ponisten !"
   ENDIF
   @ 24,1 SAY "ENTER - nastavak izmena, ESC - kraj"
   SKIP
   INKEY(0)
   @ 23,1 SAY "                       "
  ENDIF
  IF LASTKEY() = 27
   EXIT
  ENDIF
  red=red+1
  IF red=19
   red=9
   @ 9,0 CLEAR
  ENDIF
 ENDDO
 IF LASTKEY() = 27
  EXIT
 ENDIF
 IF m_seri # VAL(SUBSTR(STR(broj,7),1,4))
  red = red - 1
 ENDIF
 IF EOF() .OR. m_seri # VAL(SUBSTR(STR(broj,7),1,4))
  @ 23,1 SAY "Nema vise podataka u banci !"
  INKEY(0)
  IF LASTKEY() = 6
   red = red + 1
   SEEK m_broj
   @ red,1  GET m_broj PICTURE "9999999"
   @ red,11 GET m_dati PICTURE "@D"
   @ red,23 GET m_datv PICTURE "@D"
   @ red,32 GET m_izno PICTURE "9999999.99"
   @ red,45 GET m_opis PICTURE "@!"
   @ red,76 GET m_real PICTURE "9"
   READ
   REPLACE dati WITH m_dati,;
           datv WITH m_datv, izno WITH m_izno,;
           opis WITH m_opis, real WITH m_real
   EXIT
  ENDIF
  EXIT
 ENDIF
 @ 9,0 CLEAR
 red = 9
ENDDO
USE
RELEASE ALL
RETURN
***************************************************
* PRO_MENI - MENI REALIZOVANIH CEKOVA
PROCEDURE PRO_MENI
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRO_MENI"
@ 2,25 SAY "UNOS REALIZOVANIH CEKOVA"
@ 2,61 SAY "''ESC'' za kraj"
m_upis="D"
m_broj=0
m_stan=0
SELECT 1
USE prom INDEX promid, promvd
SELECT 2
USE ulaz INDEX ulazrd, ulazid
DO WHILE m_upis="D"
 IF LASTKEY()=27
  EXIT
 ENDIF
 @  6,3 SAY "BROJ CEKA        " GET m_broj PICTURE "9999999";
       VALID(m_broj>0)
 READ
 SELECT 1
 SEEK m_broj
 IF ! FOUND()
  @ 6,35 SAY "Taj broj ceka ne postoji !"
  INKEY(2)
  m_broj=0
  @ 6,35 SAY "                           "
  LOOP
 ENDIF
 IF izno = 0
  @ 6,35 SAY "Taj cek nije izdat !"
  INKEY(2)
  m_broj=0
  @ 6,35 SAY "                    "
  LOOP
 ENDIF
 @  8,3 SAY "DATUM IZDAVANJA   " + DTOC(dati)
 @ 10,3 SAY "DATUM VAZENJA     " + DTOC(datv)
 @ 12,3 SAY "IZNOS            " + STR(izno,9,2)
 @ 14,3 SAY "OPIS              " + opis
 IF LASTKEY() = 27
  EXIT
 ENDIF
 m_real = real
 IF m_real = 1
  @ 6,45 SAY "Ovaj cek je VEC REALIZOVAN !"
  INKEY(3)
  @ 5,0 CLEAR
  LOOP
 ENDIF
 @ 16,35 SAY "0 - nije, 1 - jeste"
 @ 16,3 SAY "REALIZOVAN       " GET m_real PICTURE "9";
        RANGE 0,1
 READ
 m_izbor=1
 @22,29 PROMPT "UNOS - DA";
        MESSAGE "UPIS SLOGA U RELACIJU"
 @22,41 PROMPT "UNOS - NE";
        MESSAGE "ODUSTAJE SE OD UPISA"
 CLEAR TYPEAHEAD
 MENU TO m_izbor
 DO CASE
  CASE m_izbor=2 .OR. LASTKEY()=27
       CLEAR GETS
       @ 5,0 CLEAR
       m_broj=0
       m_real=0
       LOOP
  CASE m_izbor=1 .AND. m_real=1
       REPLACE real WITH m_real
       SELECT 2
       GO BOTTOM
       m_stan=B->stan - A->izno
       REPLACE stan WITH m_stan
       CLOSE DATABASES
       SELECT 1
       USE prom INDEX promid, promvd
       SELECT 2
       USE ulaz INDEX ulazrd, ulazid
 ENDCASE
 @ 22,0 CLEAR
 @ 22,20 SAY "Da li nastavljas unos (D/N)?" GET m_upis;
         PICTURE "!" VALID(m_upis $ "DNdn")
 READ
 @ 5,0 CLEAR
 m_real=0
ENDDO
USE
RELEASE ALL
RETURN
***************************************************
* ULA_MENI - MENI ULAZA NOVIH PRIMANJA
PROCEDURE ULA_MENI
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "ULA_MENI"
@ 2,25 SAY "UNOS NOVIH PRIMANJA"
@ 2,61 SAY "''ESC'' za kraj"
m_upis="D"
m_datu=DATE()
m_dtu=SPACE(8)
m_izno=0
m_stan=0
m_redb=0
m_opis=SPACE(30)
SELECT 1
USE ulaz INDEX ulazrd, ulazid
DO WHILE m_upis="D"
 IF LASTKEY()=27
  EXIT
 ENDIF
 @  6,3  SAY "TEKUCI DATUM"
 @  8,3  SAY "IZNOS UPLATE"
 @ 10,3  SAY "OPIS"
 @  6,25 GET m_datu PICTURE "@D"
 @  8,25 GET m_izno PICTURE "9999999.99";
         VALID(m_izno<>0)
 @ 10,25 GET m_opis PICTURE "@!"
 READ
 IF LASTKEY() = 27
  EXIT
 ENDIF
 m_izbor=1
 @22,29 PROMPT "UNOS - DA";
        MESSAGE "UPIS SLOGA U RELACIJU"
 @22,41 PROMPT "UNOS - NE";
        MESSAGE "ODUSTAJE SE OD UPISA"
 CLEAR TYPEAHEAD
 MENU TO m_izbor
 DO CASE
  CASE m_izbor=2 .OR. LASTKEY()=27
       CLEAR GETS
       @ 5,0 CLEAR
       m_datu=DATE()
       m_izno=0
       m_opis=SPACE(30)
       LOOP
  CASE m_izbor=1
       GO BOTTOM
       m_redb=A->redb + 1
       m_stan=A->stan+m_izno
       m_dtu=DTOC(m_datu)
       m_datu=CTOD(m_dtu)
       APPEND BLANK
       REPLACE redb WITH m_redb, datu WITH m_datu, izno WITH m_izno,;
               opis WITH m_opis, stan WITH m_stan
       CLOSE DATABASES
       USE ulaz INDEX ulazrd, ulazid
 ENDCASE
 @ 22,0 CLEAR
 @ 22,20 SAY "Da li nastavljas unos (D/N)?" GET m_upis;
         PICTURE "!" VALID(m_upis $ "DNdn")
 READ
 @ 5,0 CLEAR
 m_datu=DATE()
 m_izno=0
 m_opis=SPACE(30)
ENDDO
USE
RELEASE ALL
RETURN
***************************************************
* ULA_ISPR - ISPRAVKA UNETIH ULAZA
PROCEDURE ULA_ISPR
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "ULA_ISPR"
@ 2,25 SAY "ISPRAVKA UNETIH ULAZ-a"
@ 2,61 SAY "''ESC'' za kraj"
crta = REPLICATE("-",74)
m_redb = 0
m_datu = DATE()
m_dtu = SPACE(8)
m_izno = 0
m_opis = SPACE(30)
m_stan = 0
i_stan = 0
red = 9
SELECT 1
USE ulaz INDEX ulazrd, ulazid
@  6,1  SAY crta
@  7,1  SAY "RED.BROJ   DATUM        IZNOS     OPIS"
@  7,69 SAY "STANJE"
@  8,1  SAY crta
DO WHILE .T.
 @ 24,1 SAY "END - izmene u slogu !             "
 DO WHILE red < 19
  m_redb = redb
  m_datu = datu
  m_izno = izno
  m_opis = opis
  m_stan = stan
  @ red,3  GET m_redb PICTURE "999"
  @ red,11 SAY m_datu
  @ red,23 SAY m_izno
  @ red,35 SAY m_opis
  @ red,67 SAY m_stan
  SKIP
  IF EOF()
   EXIT
  ENDIF
  READ
  INKEY(0)
  IF LASTKEY() = 6
   SEEK m_redb
   i_izno = izno
   @ red,3  GET m_redb PICTURE "999"
   @ red,11 GET m_datu PICTURE "@D"
   @ red,22 GET m_izno PICTURE "9999999.99"
   @ red,35 GET m_opis PICTURE "@!"
   @ red,66 GET m_stan PICTURE "9999999.99"
   READ
   m_stan=m_stan-i_izno+m_izno
   m_dtu=DTOC(m_datu)
   m_datu=CTOD(m_dtu)
   REPLACE redb WITH m_redb, datu WITH m_datu, izno WITH m_izno,;
           opis WITH m_opis, stan WITH m_stan
   @ 24,1 SAY "ENTER - nastavak izmena, ESC - kraj"
   INKEY(0)
   SKIP
   IF EOF()
    EXIT
   ENDIF
   INKEY(0)
  ENDIF
  IF LASTKEY() = 27
   EXIT
  ENDIF
  red=red+1
 ENDDO
 IF LASTKEY() = 27
  EXIT
 ENDIF
 IF EOF()
  @ 23,1 SAY "Nema vise podataka u banci !"
  INKEY(0)
  IF LASTKEY() = 6
   SEEK m_redb
   i_izno = izno
   @ red,3  GET m_redb PICTURE "999"
   @ red,11 GET m_datu PICTURE "@D"
   @ red,22 GET m_izno PICTURE "9999999.99"
   @ red,35 GET m_opis PICTURE "@!"
   @ red,66 GET m_stan PICTURE "9999999.99"
   READ
   m_stan=m_stan-i_izno+m_izno
   m_dtu=DTOC(m_datu)
   m_datu=CTOD(m_dtu)
   REPLACE redb WITH m_redb, datu WITH m_datu, izno WITH m_izno,;
           opis WITH m_opis, stan WITH m_stan
   red = red + 1
   EXIT
  ENDIF
  EXIT
 ENDIF
 red = 9
 @ 9,0 CLEAR
ENDDO
USE
RELEASE ALL
RETURN
***************************************************
* UNO_CEKO - UNOS NOVIH CEKOVA
PROCEDURE UNO_CEKO
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "UNO_CEKO"
@ 2,25 SAY "UNOS NOVE SERIJE CEKOVA"
@ 2,61 SAY "''ESC'' za kraj"
m_dat=DATE()
m_dt=SPACE(8)
m_upis="D"
m_broj=0
m_ceko=0
red = 10
kol = 3
a = 0
SELECT 1
USE prom INDEX promid, promvd
@ 6,0 CLEAR
DO WHILE m_upis="D"
 IF LASTKEY()=27
  EXIT
 ENDIF
 @ 6,3 SAY "BROJ PRVOG CEKA (sedam mesta) " GET m_broj PICTURE "9999999";
       VALID(m_broj>0)
 @ 8,3 SAY "BROJ CEKOVA (10 ili 20) " GET m_ceko PICTURE "99";
       VALID(m_ceko>0)
 READ
 DO WHILE a = 0
  IF m_broj = VAL(STR(broj,7))
   @ 6,53 SAY "Ta serija vec postoji"
   INKEY(3)
   @ 6,53 SAY "                     "
   a = 1
   EXIT
  ENDIF
  SKIP
  IF EOF()
   EXIT
  ENDIF
 ENDDO
 IF a = 1
  m_broj = 0
  a = 0
  LOOP
 ENDIF
 IF m_ceko = 10
  FOR i = 1 TO 10
   m_dt=DTOC(m_dat)
   m_dat=CTOD(m_dt)
   APPEND BLANK
   REPLACE broj WITH m_broj, datv WITH m_dat
   @ red,3 SAY STR(m_broj,7)
   m_broj = m_broj + 1
   red = red + 1
  NEXT
 ELSEIF m_ceko = 20
  FOR i = 1 TO 20
   m_dt=DTOC(m_dat)
   m_dat=CTOD(m_dt)
   APPEND BLANK
   REPLACE broj WITH m_broj, datv WITH m_dat
   @ red,kol SAY STR(m_broj,7)
   m_broj = m_broj + 1
   IF red = 19
    red = 9
    kol = 18
   ENDIF
   red = red + 1
  NEXT
 ELSE
  @ 8,53 SAY "Pogresan broj cekova"
  INKEY(3)
  LOOP
 ENDIF
 CLOSE DATABASES
 @ 22,3 SAY "Zavrsen posao. Pritisni bilo sta za izlaz"
 INKEY(0)
 EXIT
ENDDO
USE
RELEASE ALL
RETURN
***************************************************
* PRE_MENI - MENI PREGLEDA
PROCEDURE PRE_MENI
CLEAR
DO WHILE .T.
 CLEAR SCREEN
 @ 1,0 TO 3,78 DOUBLE
 @ 5,0 TO 23,78 DOUBLE
 @ 2,3 SAY "PRE_MENI"
 @ 2,25 SAY "RAZNI PREGLEDI"
 @ 2,61 SAY "''ESC'' za kraj"
 m_izbor=1
 @ 7,25 PROMPT "SVE SERIJE - REDOM";
        MESSAGE "IZLISTAVANJE SVIH SERIJA"
 @ 9,25 PROMPT "ODREDJENA SERIJA CEKOVA";
        MESSAGE "IZLISTAVANJE ODREDJENE SERIJE"
 @11,25 PROMPT "SVI NEREALIZOVANI";
        MESSAGE "IZLISTAVANJE SVIH NEREALIZOVANIH CEKOVA"
 @13,25 PROMPT "SVE UPLATE";
        MESSAGE "IZLISTAVANJE SVIH UPLATA NA TEKUCI RACUN"
 @15,25 PROMPT "STANJE ODREDJENOG DATUMA";
        MESSAGE "STANJE SA SVIM CEKOVIMA DO ODREDJENOG DATUMA"
 @17,25 PROMPT "PREGLED ULAZA I IZLAZA POSLEDNJE GODINE";
        MESSAGE "PRACENJE STANJA PO DATUMIMA ZA POSLEDNJU GODINU"
 @19,25 PROMPT "PREGLED ULAZA I IZLAZA";
        MESSAGE "PRACENJE STANJA PO DATUMIMA DOGADJAJA"
 @21,25 PROMPT "PREGLED ULAZA I REALIZOVANIH IZLAZA";
        MESSAGE "PRACENJE STANJA PO DATUMIMA DOGADJAJA"
 CLEAR TYPEAHEAD
 MENU TO m_izbor
 DO CASE
  CASE LASTKEY()=27
       EXIT
  CASE m_izbor=1
       DO pre_redo
  CASE m_izbor=2
       DO pre_odre
  CASE m_izbor=3
       DO pre_nere
  CASE m_izbor=4
       DO pre_upla
  CASE m_izbor=5
       DO pre_datu
  CASE m_izbor=6
       DO pre_posl
  CASE m_izbor=7
       DO pre_uliz
  CASE m_izbor=8
       DO pre_uire
 ENDCASE
ENDDO
CLOSE ALL
CLEAR SCREEN
RETURN
***************************************************
* PRE_REDO - IZLISTAVANJE SVIH SERIJA REDOM
PROCEDURE PRE_REDO
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRE_REDO"
@ 2,25 SAY "SVE SERIJE - REDOM"
@ 2,61 SAY "''ESC'' za kraj"
crta = REPLI("-",78)
re=SPACE(1)
red=9
SELECT 1
USE prom INDEX promid
@  6,1  SAY crta
@  7,1  SAY "BR. CEKA  DAT.IZDAV. DAT.VAZENJA   IZNOS    OPIS"
@  7,75 SAY "REAL"
@  8,1  SAY crta
DO WHILE .T.
 DO WHILE red<19
  IF A->real=1
   re = "*"
  ELSEIF A->real=0
   re = "-"
  ELSE
   re = "P"
  ENDIF
  @ red,1 SAY STR(broj,7)+"   "+DTOC(dati)+"    "+DTOC(datv)
  @ red,33 SAY STR(izno,9,2)+"   "+opis+"  "+re
  red=red+1
  SKIP
  IF EOF() .OR. LASTKEY() = 27
   EXIT
  ENDIF
 ENDDO
 IF EOF()
  @ 23,1 SAY "Nema vise podataka u banci !"
  INKEY(0)
  EXIT
 ENDIF
 @ 23,1 SAY "Pritisni bilo sta za nastavak izlistavanja !"
 INKEY(0)
 IF LASTKEY() = 27
  EXIT
 ENDIF
 @ 9,0 CLEAR
 red = 9
ENDDO
CLOSE ALL
CLEAR SCREEN
RETURN
***************************************************
* PRE_ODRE - IZLISTAVANJE ODREDJENE SERIJE
PROCEDURE PRE_ODRE
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRE_ODRE"
@ 2,25 SAY "ODREDJENA SERIJA"
@ 2,61 SAY "''ESC'' za kraj"
m_broj=0
crta = REPLI("-",78)
re=SPACE(1)
red=9
SELECT 1
USE prom INDEX promid
DO WHILE .T.
 @  6,3 SAY "BROJ SERIJE (cetiri cifre)   " GET m_broj PICTURE "9999";
       VALID(m_broj>0)
 READ
 DO WHILE SUBSTR(STR(broj,7),1,4) # STR(m_broj,4)
  SKIP
  IF EOF()
   @ 6,40 SAY "Ta serija ne postoji !"
   INKEY(2)
   @ 6,40 SAY "                      "
   m_broj=0
   EXIT
  ENDIF
 ENDDO
 IF LASTKEY() = 27
  EXIT
 ENDIF
 IF EOF()
  GO TOP
  LOOP
 ENDIF
 @  6,1  SAY crta
 @  7,1  SAY "BR. CEKA  DAT.IZDAV. DAT.VAZENJA   IZNOS    OPIS"
 @  7,75 SAY "REAL"
 @  8,1  SAY crta
 DO WHILE SUBSTR(STR(broj,7),1,4) = STR(m_broj,4)
  IF A->real=1
   re = "*"
  ELSEIF A->real=0
   re = "-"
  ELSE
   re = "P"
  ENDIF
  @ red,1 SAY STR(broj,7)+"   "+DTOC(dati)+"    "+DTOC(datv)
  @ red,33 SAY STR(izno,9,2)+"   "+opis+"  "+re
  red=red+1
  SKIP
  IF EOF()
   @ 23,1 SAY "Nema vise podataka u banci !"
   INKEY(0)
   EXIT
  ENDIF
  IF red = 19
   @ 23,1 SAY "Pritisni bilo sta za nastavak listanja !"
   INKEY(0)
   IF SUBSTR(STR(broj,7),1,4) # STR(m_broj,4)
    EXIT
   ENDIF
   red = 9
   @ 9,0 CLEAR
  ENDIF
 ENDDO
 @ 24,1 SAY "ESC - izlazak, BILO STA - izlistavanje druge serije"
 INKEY(0)
 IF LASTKEY() = 27
  EXIT
 ENDIF
 GO TOP
 @ 6,0 CLEAR
 m_broj=0
 red=9
ENDDO
CLOSE ALL
CLEAR SCREEN
RETURN
***************************************************
* PRE_NERE - IZLISTAVANJE NEREALIZOVANIH CEKOVA
PROCEDURE PRE_NERE
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRE_NERE"
@ 2,25 SAY "SVI NEREALIZOVANI CEKOVI"
@ 2,61 SAY "''ESC'' za kraj"
crta = REPLI("-",78)
red=9
SELECT 1
USE prom INDEX promid
@  6,1  SAY crta
@  7,1  SAY "BR. CEKA  DAT.IZDAV. DAT.VAZENJA   IZNOS    OPIS"
@  7,75 SAY "REAL"
@  8,1  SAY crta
DO WHILE .T.
 DO WHILE real = 0
  DO WHILE red<19
   @ red,1 SAY STR(broj,7)+"   "+DTOC(dati)+"    "+DTOC(datv)
   @ red,33 SAY STR(izno,9,2)+"   "+opis+"  "+"-"
   red=red+1
   SKIP
   DO WHILE real = 1 .OR. real = 2
    SKIP
   ENDDO
   IF EOF() .OR. LASTKEY() = 27
    EXIT
   ENDIF
  ENDDO
  IF EOF()
   @ 23,1 SAY "Nema vise podataka u banci !"
   @ 24,1 SAY "ESC - izlazak, BILO STA - izlistavanje od pocetka"
   INKEY(0)
   IF LASTKEY() = 27
    EXIT
   ENDIF
   @ 10,0 CLEAR
   red = 9
   GO TOP
   LOOP
  ENDIF
  @ 23,1 SAY "Pritisni bilo sta za nastavak izlistavanja !"
  INKEY(0)
  IF LASTKEY() = 27
   EXIT
  ENDIF
  @ 10,0 CLEAR
  red = 9
 ENDDO
 IF LASTKEY() = 27
  EXIT
 ENDIF
 SKIP
 LOOP
ENDDO
CLOSE ALL
CLEAR SCREEN
RETURN
***************************************************
* PRE_UPLA - IZLISTAVANJE SVIH UPLATA
PROCEDURE PRE_UPLA
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRE_UPLA"
@ 2,25 SAY "SVE UPLATE"
@ 2,61 SAY "''ESC'' za kraj"
crta = REPLI("-",53)
red=9
uku=0
SELECT 1
USE ulaz INDEX ulazid
@  6,1  SAY crta
@  7,1  SAY "DATUM ULAZA     IZNOS      OPIS"
@  8,1  SAY crta
DO WHILE .T.
 DO WHILE red<21
  @ red,3 SAY DTOC(datu)+"    "+STR(izno,9,2)+"    "+opis
  red=red+1
  uku=uku+izno
  SKIP
  IF EOF() .OR. LASTKEY() = 27
   EXIT
  ENDIF
 ENDDO
 IF EOF()
  red=red+1
  @ red,3 SAY "UKUPNO      "+STR(uku,9,2)
  @ 23,1 SAY "Nema vise podataka u banci !"
  @ 24,1 SAY "ESC - izlazak, BILO STA - izlistavanje od pocetka"
  INKEY(0)
  IF LASTKEY() = 27
   EXIT
  ENDIF
  @ 10,0 CLEAR
  red = 9
  uku = 0
  GO TOP
  LOOP
 ENDIF
 @ 23,1 SAY "Pritisni bilo sta za nastavak izlistavanja !"
 INKEY(0)
 IF LASTKEY() = 27
  EXIT
 ENDIF
 @ 10,0 CLEAR
 red = 9
ENDDO
CLOSE ALL
CLEAR SCREEN
RETURN
***************************************************
* PRE_DATU - STANJE ODREDJENOG DATUMA SA SVIM CEKOVIMA
PROCEDURE PRE_DATU
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRE_DATU"
@ 2,25 SAY "STANJE ODREDJENOG DATUMA"
@ 2,61 SAY "''ESC'' za kraj"
m_broj=DATE()
m_brj=SPACE(8)
m_upl=0
m_rea=0
m_sta=0
DO WHILE LASTKEY() # 27
 @  6,3 SAY "UNESI DATUM (dan,mesec,godina) " GET m_broj PICTURE "@D"
 READ
 SELECT 1
 USE prom INDEX promvd
 SELECT 2
 USE ulaz INDEX ulazid
 DO WHILE ! EOF()
  m_brj=DTOC(m_broj)
  m_broj=CTOD(m_brj)
  IF B->datu <= m_broj
   m_upl=m_upl+B->izno
  ENDIF
  SKIP
 ENDDO
 SELECT 1
 DO WHILE ! EOF()
  IF A->datv <= m_broj
   m_rea=m_rea+A->izno
  ENDIF
  SKIP
 ENDDO
 m_sta=m_upl-m_rea
 @ 10,1  SAY "UPLACENO"
 @ 10,24 SAY "IZDATO DO TOG DATUMA"
 @ 10,61 SAY "STANJE"
 SET COLOR TO /W
 @ 10,11 SAY STR(m_upl,9,2)
 @ 10,46 SAY STR(m_rea,9,2)
 @ 10,68 SAY STR(m_sta,9,2)
 IF m_sta<0
  @ 20,5 SAY "U minusu si !!!"
 ELSE
  @ 20,5 SAY "Dobro poslujes!  U plusu si!"
 ENDIF
 SET COLOR TO
 INKEY(0)
 m_broj=DATE()
 m_upl=0
 m_rea=0
 m_sta=0
ENDDO
CLOSE ALL
CLEAR SCREEN
RETURN
***************************************************
* PRE_POSL - PREGLED ULAZA I IZLAZA POSLEDNJE GODINE
PROCEDURE PRE_POSL
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRE_POSL"
@ 2,25 SAY "PREGLED ULAZA I IZLAZA"
@ 2,61 SAY "''ESC'' za kraj"
m_sta = 0
m_re = SPACE(1)
crta = REPLI("-",78)
red = 7
@ 5,1 SAY " DATUM     BROJ      ULAZ      IZLAZ    OPIS"
@ 5,68 SAY "REAL STANJE"
@ 6,1 SAY crta
SELECT 1
USE prom INDEX promvd
SELECT 2
USE ulaz INDEX ulazid
DO WHILE ! EOF()
 IF A->datv > B->datu
  IF B->redb = 1
   m_sta=m_sta+B->stan
  ELSE
   m_sta=m_sta+B->izno
  ENDIF
  IF SUBST(DTOC(datum),7,2) = SUBSTR(DTOC(B->datu),7,2)
   @ red,1  SAY DTOC(B->datu)+"         "+STR(B->izno,9,2)
   @ red,39 SAY B->opis
   @ red,71 SAY STR(m_sta,9,2)
   red = red + 1
  ENDIF
  SELECT 2
  SKIP
  IF EOF()
   EXIT
  ENDIF
 ELSEIF A->datv = B->datu
  IF B->redb = 1
   m_sta=m_sta+B->stan
  ELSE
   m_sta=m_sta+B->izno
  ENDIF
  IF SUBST(DTOC(datum),7,2) = SUBSTR(DTOC(B->datu),7,2)
   @ red,1  SAY DTOC(B->datu)+"         "+STR(B->izno,9,2)
   @ red,39 SAY B->opis
   @ red,71 SAY STR(m_sta,9,2)
   red = red + 1
  ENDIF
  SELECT 2
  SKIP
  IF EOF()
   EXIT
  ENDIF
  IF A->real = 0
   m_re = "-"
  ELSEIF A->real = 1
   m_re = "*"
  ELSE
   m_re = "P"
  ENDIF
  IF A->izno # 0
   m_sta=m_sta-A->izno
   IF SUBST(DTOC(datum),7,2) = SUBSTR(DTOC(A->datv),7,2)
    @ red,1 SAY DTOC(A->datv)+" "+STR(A->broj,7)+"            "+STR(A->izno,9,2)
    @ red,39 SAY A->opis+" "+m_re+STR(m_sta,9,2)
    red = red + 1
   ENDIF
  ENDIF
  SELECT 1
  SKIP
  IF EOF()
   EXIT
  ENDIF
 ELSE
  IF A->real = 0
   m_re = "-"
  ELSEIF A->real = 1
   m_re = "*"
  ELSE
   m_re = "P"
  ENDIF
  IF A->izno # 0
   m_sta=m_sta-A->izno
   IF SUBST(DTOC(datum),7,2) = SUBSTR(DTOC(A->datv),7,2)
    @ red,1 SAY DTOC(A->datv)+" "+STR(A->broj,7)+"            "+STR(A->izno,9,2)
    @ red,39 SAY A->opis+" "+m_re+STR(m_sta,9,2)
    red=red+1
   ENDIF
  ENDIF
  SELECT 1
  SKIP
  IF EOF()
   EXIT
  ENDIF
 ENDIF
 IF red > 21
  @ 23,1  SAY "Pritisni bilo sta za nastavak izlistavanja"
  INKEY(0)
  red = 7
  @ 7,0 CLEAR
 ENDIF
ENDDO
SELECT 1
DO WHILE ! EOF()
 m_sta=m_sta-A->izno
 IF A->real = 0
  m_re = "-"
 ELSEIF A->real = 1
  m_re = "*"
 ELSE
  m_re = "P"
 ENDIF
 IF A->izno # 0
  IF SUBST(DTOC(datum),7,2) = SUBSTR(DTOC(A->datv),7,2)
   @ red,1 SAY DTOC(A->datv)+" "+STR(A->broj,7)+"            "+STR(A->izno,9,2)
   @ red,39 SAY A->opis+" "+m_re+STR(m_sta,9,2)
   red = red + 1
  ENDIF
 ENDIF
 IF red > 21
  @ 23,1  SAY "Pritisni bilo sta za nastavak izlistavanja"
  INKEY(0)
  red = 7
  @ 7,0 CLEAR
 ENDIF
 SKIP
ENDDO
SELECT 2
DO WHILE ! EOF()
 IF B->redb = 1
  m_sta=m_sta+B->stan
 ELSE
  m_sta=m_sta+B->izno
 ENDIF
 IF SUBST(DTOC(datum),7,2) = SUBSTR(DTOC(B->datu),7,2)
  @ red,1  SAY DTOC(B->datu)+"         "+STR(B->izno,9,2)
  @ red,39 SAY B->opis
  @ red,71 SAY STR(m_sta,9,2)
  red = red + 1
 ENDIF
 SKIP
 IF EOF()
  EXIT
 ENDIF
ENDDO
@ 23,1  SAY "Nema vise podataka !"
INKEY(0)
CLOSE ALL
CLEAR SCREEN
RETURN
***************************************************
* PRE_ULIZ - PREGLED ULAZA I IZLAZA
PROCEDURE PRE_ULIZ
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRE_ULIZ"
@ 2,25 SAY "PREGLED ULAZA I IZLAZA"
@ 2,61 SAY "''ESC'' za kraj"
m_sta = 0
m_re = SPACE(1)
crta = REPLI("-",78)
red = 7
@ 5,1 SAY " DATUM     BROJ      ULAZ      IZLAZ    OPIS"
@ 5,68 SAY "REAL STANJE"
@ 6,1 SAY crta
SELECT 1
USE prom INDEX promvd
SELECT 2
USE ulaz INDEX ulazid
DO WHILE ! EOF()
 IF A->datv > B->datu
  IF B->redb = 1
   m_sta=m_sta+B->stan
  ELSE
   m_sta=m_sta+B->izno
  ENDIF
  @ red,1  SAY DTOC(B->datu)+"         "+STR(B->izno,9,2)
  @ red,39 SAY B->opis
  @ red,71 SAY STR(m_sta,9,2)
  red = red + 1
  SELECT 2
  SKIP
  IF EOF()
   EXIT
  ENDIF
 ELSEIF A->datv = B->datu
  IF B->redb = 1
   m_sta=m_sta+B->stan
  ELSE
   m_sta=m_sta+B->izno
  ENDIF
  @ red,1  SAY DTOC(B->datu)+"         "+STR(B->izno,9,2)
  @ red,39 SAY B->opis
  @ red,71 SAY STR(m_sta,9,2)
  red = red + 1
  SELECT 2
  SKIP
  IF EOF()
   EXIT
  ENDIF
  IF A->real = 0
   m_re = "-"
  ELSEIF A->real = 1
   m_re = "*"
  ELSE
   m_re = "P"
  ENDIF
  IF A->izno # 0
   m_sta=m_sta-A->izno
   @ red,1 SAY DTOC(A->datv)+" "+STR(A->broj,7)+"            "+STR(A->izno,9,2)
   @ red,39 SAY A->opis+" "+m_re+STR(m_sta,9,2)
   red = red + 1
  ENDIF
  SELECT 1
  SKIP
  IF EOF()
   EXIT
  ENDIF
 ELSE
  IF A->real = 0
   m_re = "-"
  ELSEIF A->real = 1
   m_re = "*"
  ELSE
   m_re = "P"
  ENDIF
  IF A->izno # 0
   m_sta=m_sta-A->izno
   @ red,1 SAY DTOC(A->datv)+" "+STR(A->broj,7)+"            "+STR(A->izno,9,2)
   @ red,39 SAY A->opis+" "+m_re+STR(m_sta,9,2)
   red=red+1
  ENDIF
  SELECT 1
  SKIP
  IF EOF()
   EXIT
  ENDIF
 ENDIF
 IF red > 21
  @ 23,1  SAY "Pritisni bilo sta za nastavak izlistavanja"
  INKEY(0)
  red = 7
  @ 7,0 CLEAR
 ENDIF
ENDDO
SELECT 1
DO WHILE ! EOF()
 m_sta=m_sta-A->izno
 IF A->real = 0
  m_re = "-"
 ELSEIF A->real = 1
  m_re = "*"
 ELSE
  m_re = "P"
 ENDIF
 IF A->izno # 0
  @ red,1 SAY DTOC(A->datv)+" "+STR(A->broj,7)+"            "+STR(A->izno,9,2)
  @ red,39 SAY A->opis+" "+m_re+STR(m_sta,9,2)
  red = red + 1
 ENDIF
 IF red > 21
  @ 23,1  SAY "Pritisni bilo sta za nastavak izlistavanja"
  INKEY(0)
  red = 7
  @ 7,0 CLEAR
 ENDIF
 SKIP
ENDDO
SELECT 2
DO WHILE ! EOF()
 IF B->redb = 1
  m_sta=m_sta+B->stan
 ELSE
  m_sta=m_sta+B->izno
 ENDIF
 @ red,1  SAY DTOC(B->datu)+"         "+STR(B->izno,9,2)
 @ red,39 SAY B->opis
 @ red,71 SAY STR(m_sta,9,2)
 red = red + 1
 SKIP
 IF EOF()
  EXIT
 ENDIF
ENDDO
@ 23,1  SAY "Nema vise podataka !"
INKEY(0)
CLOSE ALL
CLEAR SCREEN
RETURN
***************************************************
* PRE_UIRE - PREGLED ULAZA I REALIZOVANIH IZLAZA
PROCEDURE PRE_UIRE
CLEAR
@ 1,0 TO 3,78 DOUBLE
@ 2,3 SAY "PRE_UIRE"
@ 2,25 SAY "SVI ULAZI I REALIZOVANI IZLAZI"
@ 2,61 SAY "''ESC'' za kraj"
m_sta = 0
m_re = SPACE(1)
crta = REPLI("-",68)
red = 7
@ 5,1 SAY " DATUM      BROJ       ULAZ        IZLAZ      REAL      STANJE"
@ 6,1 SAY crta
SELECT 1
USE prom INDEX promvd
SELECT 2
USE ulaz INDEX ulazid
DO WHILE ! EOF()
 IF A->datv > B->datu
  IF B->redb = 1
   m_sta=m_sta+B->stan
  ELSE
   m_sta=m_sta+B->izno
  ENDIF
  @ red,1  SAY DTOC(B->datu)+"            "+STR(B->izno,9,2)
  @ red,56 SAY STR(m_sta,9,2)
  red = red + 1
  SELECT 2
  SKIP
  IF EOF()
   EXIT
  ENDIF
 ELSEIF A->datv = B->datu
  IF B->redb = 1
   m_sta=m_sta+B->stan
  ELSE
   m_sta=m_sta+B->izno
  ENDIF
  @ red,1  SAY DTOC(B->datu)+"            "+STR(B->izno,9,2)
  @ red,56 SAY STR(m_sta,9,2)
  red = red + 1
  IF A->real = 1
   m_re = "*"
   m_sta=m_sta-A->izno
   @ red,1 SAY DTOC(A->datv)+"  "+STR(A->broj,7)+"               "+STR(A->izno,9,2)
   @ red,49 SAY m_re+"      "+STR(m_sta,9,2)
   red = red + 1
  ENDIF
  SELECT 2
  SKIP
  IF EOF()
   EXIT
  ENDIF
  SELECT 1
  SKIP
 ELSE
  IF A->real = 1
   m_re = "*"
   m_sta=m_sta-A->izno
   @ red,1 SAY DTOC(A->datv)+"  "+STR(A->broj,7)+"               "+STR(A->izno,9,2)
   @ red,49 SAY m_re+"      "+STR(m_sta,9,2)
   red=red+1
  ENDIF
  SELECT 1
  SKIP
 ENDIF
 IF red = 22
  @ 23,1  SAY "Pritisni bilo sta za nastavak izlistavanja"
  INKEY(0)
  red = 7
  @ 7,0 CLEAR
 ENDIF
ENDDO
SELECT 1
DO WHILE ! EOF()
 m_sta=m_sta-A->izno
 IF A->real = 1
  m_re = "*"
  @ red,1 SAY DTOC(A->datv)+"  "+STR(A->broj,7)+"               "+STR(A->izno,9,2)
  @ red,49 SAY m_re+"      "+STR(m_sta,9,2)
  red = red + 1
 ENDIF
 SKIP
ENDDO
SELECT 2
DO WHILE ! EOF()
 IF B->redb = 1
  m_sta=m_sta+B->stan
 ELSE
  m_sta=m_sta+B->izno
 ENDIF
 @ red,1  SAY DTOC(B->datu)+"            "+STR(B->izno,9,2)
 @ red,56 SAY STR(m_sta,9,2)
 red = red + 1
 SKIP
 IF EOF()
  EXIT
 ENDIF
ENDDO
@ 23,1  SAY "Nema vise podataka !"
INKEY(0)
CLOSE ALL
CLEAR SCREEN
RETURN
