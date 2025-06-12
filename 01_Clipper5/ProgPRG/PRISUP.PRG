

*********************************GLAVNI MENI ZA RAD***********************
SET COLOR TO "GR+/R,RB+/G,,,"
CLS
SET WRAP ON
SET MESSAGE TO 23 CENTER
@ 4,11 TO 10,35

DO WHILE .T.

 p_izbor:=1
 @ 5,18 PROMPT "Direktorijum";
 MESSAGE ("Ispitivanje tekuceg dirktorijuma (listanje fajlova)")
 @ 6,18 PROMPT "Baza podataka";
 MESSAGE ("Ispitivanje izabrane baze podataka (karakteristike polja)")
 @ 7,18 PROMPT "Indeksiranje";
 MESSAGE ("Indeksiranje izabrane baze po izbranom kljucu (-vima)")
 CLEAR TYPEAHEAD
 MENU TO p_izbor

 DO CASE
  CASE p_izbor=0
   @ 23,2 SAY "Izabrali ste ESC"
   EXIT
  CASE p_izbor=1
   DO ispdrkt
  CASE p_izbor=2
   DO ispbaza
  CASE p_izbor=3
   DO indksbz
  ENDCASE

ENDDO


*@ 24,0 SAY " "
*INKEY(3)
SET COLOR TO "B+/B"
CLS
@ 5,4 SAY "KRAJ PROGRAMA - 3sec !!!" COLOR "G+/B"
INKEY(1)
@ 5,4 SAY "KRAJ PROGRAMA - 2sec !!!" COLOR "GR+/B"
INKEY(1)
@ 5,4 SAY "KRAJ PROGRAMA - 1sec !!!" COLOR "R+/B"
INKEY(1)

SET COLOR TO "W/N"
CLS
QUIT
************************** K R A J programa *********************



*****************************ISPITIVANJE DIREKTORIJUMA**********************

PROCEDURE ISPDRKT

****************************************************************************

CLEAR
SET DATE GERMAN
SET CONFIRM ON
SET CURSOR OFF

CLOSE DATABASES
ERASE podgran.dbf

matr:=DIRECTORY()

*IF EMPTY(matr)
* @ 1,2 SAY " P R A Z N A   ! "
*ELSE
* @ 1,2 SAY " I S P U NJ E N A   ! "
*ENDIF

ar1:=1
red:=4
m_prov:=SPACE(4)
AADD(matr,"KRAJ")

m_br:=ASCAN(matr,"KRAJ")

*@ 2,2 SAY "U tekucem direktorijumu ima "+ALLTRIM(STR(m_br-1))+" fajlova !"




***********Upis podataka o direktorijumu iz matrice u bazu*************


******Formiranje baze koja prihvata podatke o dirktorijumu iz matrice*******

SET COLOR TO "W/B,"

CLS
p_mat:=0
IF ! FILE("podgran.dbf")

 p_mat:=ARRAY(6,4)
 p_mat[1,1] := "redbr"
 p_mat[1,2] := "n"
 p_mat[1,3] := 6
 p_mat[1,4] := 0
 p_mat[2,1] := "imeekst"
 p_mat[2,2] := "c"
 p_mat[2,3] := 75
 p_mat[2,4] := 0
 p_mat[3,1] := "velicina"
 p_mat[3,2] := "n"
 p_mat[3,3] := 14
 p_mat[3,4] := 0
 p_mat[4,1] := "datum"
 p_mat[4,2] := "d"
 p_mat[4,3] := 0
 p_mat[4,4] := 0
 p_mat[5,1] := "vreme"
 p_mat[5,2] := "c"
 p_mat[5,3] := 8
 p_mat[5,4] := 0
 p_mat[6,1] := "a"
 p_mat[6,2] := "c"
 p_mat[6,3] := 4
 p_mat[6,4] := 0

 DBCREATE("podgran", p_mat)
 USE
 @ 9,7 SAY "Kreirana je baza podataka PODGRAN.DBF !" COLOR "G+/B"
 @ 10,7 SAY "Baza PODGRAN.DBF se puni fajlovima tekuceg direktorija !" ;
             COLOR "W/B"
ELSE
 SET COLOR TO "W/N"
 CLS
 @ 9,7 SAY "Baza podataka PODGRAN.DBF vec postoji !" 
 INKEY(2.5)
* QUIT
*EXIT
RETURN
ENDIF

***************Podloga za skalu*************


m_brfajl:=m_br-1
m_kol:=7
FOR i=1 TO 50
 @ 20,m_kol SAY CHR(176) COLOR "GR+/B"
 m_kol:=m_kol+1
NEXT

***************Upis u bazu i brojanje skale************

m_brf:=1
m_pr:=0
m_or:=2
m_kol:=7
m_brkc:=0
m_kol2:=0
m_kol3:=0
m_razlika:=0
m_brraz:=1

DO WHILE .T.

 IF m_br=ar1
  @ 10,0 CLEAR TO 11,78 
  @ 10,7 SAY "Baza PODGRAN.DBF je napunjena !" COLOR "G+/B"
*  QUIT
  INKEY(2)
  EXIT
 ENDIF

 USE podgran
 APPEND BLANK
 REPLACE redbr WITH ar1, imeekst WITH matr[ar1,1],;
         velicina WITH matr[ar1,2], datum WITH matr[ar1,3],;
         vreme WITH matr[ar1,4],;
         a WITH matr[ar1,5]
 
 ar1:=ar1+1

 
* FOR i=1 TO m_brfajl 
  m_pr:=100*m_brf/m_brfajl
*  m_brkc:=INT(m_pr)
  m_brkc:=m_pr/2
  m_brkc:=ROUND(m_brkc,0)
*  m_brkc:=INT(m_brkc)
*  m_brkc:=m_brkc/2
  FOR i=1 TO m_brkc
   @ 20,m_kol SAY CHR(219) COLOR "GR+/B"
   @ 20,59 SAY STR(m_pr,6,2)+" %" COLOR"GR+/B"
*   +STR(m_brkc,3)+STR(m_kol,3)
*   m_razlika:=m_kol-m_kol2
*   IF m_razlika>1
*    FOR i=1 TO m_razlika
*     m_kol3:=m_kol2+m_brraz
*     @ 18,m_kol3 SAY CHR(219)
*     m_brraz:=m_brraz+1
*    NEXT
*   ENDIF
*   m_kol2:=m_kol
   m_kol:=m_kol+1
  NEXT
  m_kol:=7
*  IF m_pr>=m_or
*   @ 18,m_kol SAY CHR(219)
*   m_kol:=m_kol+1
*   m_or:=m_or+2
*  ENDIF
  m_brf:=m_brf+1
*  INKEY(0)
* NEXT
 
*QUIT

ENDDO
CLOSE DATABASES


*************************Ispisivanje na ekranu*******************

SET CURSOR OFF
SET COLOR TO "GR+/R"
CLS

*ar1:=1
*red:=4
SELECT 1
USE podgran

*@ 4,0 SAY p_crta

*@ 3,2 SAY "Ovo je zaglavlje !"
*INKEY(0)
*QUIT

*****************************

***Kretanje po ekranu***
*p_brr:=1
*p_red:=5
*p_izlaz:=0
*p_imeput:=SPACE(100)
*p_brznakniz:=0
*p_slovo:=SPACE(1)
*p_slovniz:=SPACE(100)

*SELECT 1
*USE xxxxwwww

*DO WHILE .T.
******Ime tekuceg direktorijuma*******

*CLS
p_imeput:=SPACE(100)
p_brznakniz:=0
p_brskida:=0
p_slovo:=SPACE(1)
p_slovniz:=SPACE(1)
p_ispis:=SPACE(1)

*******Formiranje imena diraktorija-grane***********
p_imeput:=CURDIR()
p_imeput:=ALLTRIM(p_imeput)
p_brznakniz:=LEN(p_imeput)
p_brskida:=0
p_brizlaz:=0
DO WHILE .T.
 p_brznakniz:=p_brznakniz-p_brskida
 p_slovo:=SUBSTR(p_imeput,p_brznakniz,1)
 p_brznakniz:=LEN(p_imeput)
 IF p_slovo="\" 
  EXIT
 ENDIF
 p_slovniz:=p_slovo+p_slovniz
*? p_slovo+p_slovniz+STR(p_brznakniz)+STR(p_brskida)
*INKEY(0)
*IF LASTKEY()=27
* QUIT
*ENDIF
 p_brskida:=p_brskida+1
 IF p_slovniz=" "
  p_ispis:="na osnovoj grni diska"
*  @ 15,20 SAY "Vi niste u direktorijumu vec na osnovnom disku !!!"
  EXIT
*  QUIT
 ENDIF
 p_brizlaz:=p_brizlaz+1
ENDDO

IF p_brizlaz#0
 p_ispis:="na dirktoriju "+ALLTRIM(p_slovniz)
*  @ 15,20 SAY "Ime ovog direktorijuma je: " + p_slovniz
ENDIF


*******Ime tekuceg direktorijuma*******
*p_imeput:=CURDIR()
*p_imeput:=ALLTRIM(p_imeput)
*p_brznakniz:=LEN(p_imeput)
*p_brskida:=1
*DO WHILE .T.
* p_slovo:=SUBSTR(p_imeput,p_znakniz,1)
* IF p_slovo="\"
*  EXIT
* ENDIF
* p_slovniz:=p_slovo+p_slovniz
* p_znakniz:=p_znakniz-p_brskina
* p_brskida:=p_brskida+1
*ENDDO

********************Zaglavlje*****************
  SET COLOR TO "G/R"
  @ 0,0 TO 24,79 DOUBLE
  @ 4,3 TO 22,75
  SET COLOR TO "GR+/R"
  @ 2,3 SAY "Broj fajlova " + p_ispis + " je: " + ;
              ALLTRIM(STR(m_br-1))
  @ 3,11 SAY "REDBR"
  @ 3,19 SAY "IMEEKST"
  @ 3,34 SAY "VELICINA"
  @ 3,45 SAY "DATUM"
  @ 3,56 SAY "VREME"
  @ 3,67 SAY "A"

*  p_crta:=REPLICATE("-",78)

  @ 23,37 SAY "Izlaz-Esc"
  @ 1,59 SAY "Datum: "+DTOC(DATE())+"."
  @ 23,53 SAY "Listanje: GORE-" + CHR(24) + " DOLE-" + CHR(25)

***********Ispis podataka***********
p_brr:=1
p_red:=5
p_izlaz:=0
DO WHILE .T.
  @ p_red,11 SAY ALLTRIM(STR(redbr))
  @ p_red,19 SAY ALLTRIM(imeekst)
  @ p_red,34 SAY ALLTRIM(STR(velicina))
  @ p_red,45 SAY DTOC(datum)
  @ p_red,56 SAY vreme
  @ p_red,67 SAY a
  SKIP
*  ar1:=ar1+1
*  red:=red+1
*  @ p_red,32 SAY vrs+"  "+osn+"  "+dob
*  SKIP
  p_red:=p_red+1
  IF p_red=22
    IF p_izlaz=0
      INKEY(0)
    ELSEIF p_izlaz=1
      p_izlaz:=0
    ENDIF
*------- Prekid
    IF LASTKEY()=27
      CLOSE DATABASES
*      ERASE xxxxwwww.dbf
*      EXIT

     SET COLOR TO "GR+/R,RB+/G,,,"
     CLS
*     SET MESSAGE TO 23 CENTER
     @ 4,11 TO 10,35
     RETURN

**------- NA dole
*    ELSEIF LASTKEY()=24 
*      IF EOF()
*        @ 23,3 SAY "Nema daljeg listanja na dole !"
*        p_red:=7
*        GO p_brr
*        LOOP
*      ENDIF
*      @ 6,1 CLEAR TO 23,78
*      p_red:=7
*      p_brr:=p_brr+1
*      GO p_brr
*      LOOP

**------- Na gore
*------- NA dole
    ELSEIF LASTKEY()=24 
      IF EOF()
        @ 23,3 SAY "Nema daljeg listanja na dole !"
        INKEY(3)
        @ 23,3 SAY "                              "
        p_red:=5
*        p_brr:=p_brr-1
        GO p_brr
        LOOP
      ENDIF
      @ 5,4 CLEAR TO 21,74
      p_red:=5
      p_brr:=p_brr+1
      GO p_brr
      LOOP

*------- Na gore
    ELSEIF LASTKEY()=5 
      p_red:=5
      p_brr=p_brr-1
      GO p_brr
      IF BOF()
        @ 23,3 SAY "Nema daljeg listanja na gore !"
        INKEY(3)
        @ 23,3 SAY "                              "
        p_red:=5
        p_brr:=p_brr+1
        GO p_brr
        LOOP
      ENDIF
      @ 5,4 CLEAR TO 21,74
      LOOP
*------- Neka druga tipka
    ELSE
*      FOR i=1 TO 3
        IF LASTKEY ()=24 .OR. LASTKEY()=5
          p_izlaz:=1
          LOOP
        ENDIF
        @ 23,3 SAY "POGRESAN TASTER !"
        INKEY(3)
        @ 23,3 SAY "                 " 
*        INKEY(0.3)
*      NEXT
      p_red:=5
      GO p_brr
      LOOP
    ENDIF
  ENDIF
ENDDO
CLOSE DATABASES
*ERASE xxxxwwww.dbf
SET COLOR TO
*CLOSE DATABASES
CLEAR SCREEN
*QUIT



*************Ispisivanje (samo jedanput) na ekranu**************
*DO WHILE .T.
* IF m_br=ar1
*  @ red+1,2 SAY "NEMA VISE !"
*  EXIT
* ENDIF
* @ red,2 SAY ALLTRIM(STR(redbr))
* @ red,10 SAY ALLTRIM(imeekst)
* @ red,24 SAY ALLTRIM(STR(velicina))
* @ red,42 SAY DTOC(datum)
* @ red,52 SAY vreme
* @ red,63 SAY a
* SKIP
* ar1:=ar1+1
* red:=red+1
* IF red=21
*  @ red+2,2 SAY "Pritisnite bilo sta za dalje listanje !"
*  INKEY(0)
*  @ 5,0 CLEAR 
*  red:=4
* ENDIF
*ENDDO

*FOR i:=1 TO LEN(matr)
* ? matr[i]
*NEXT
*INKEY(0)

*@ p_red+1,2 SAY "Pritisnite bilo sta za dalji rad !"
*INKEY(0)
CLOSE DATABASES

*QUIT

CLOSE DATABASES
ERASE prodgran.dbf
SET COLOR TO "GR+/R,RB+/G,,,"
CLS
*SET MESSAGE TO 23 CENTER
@ 4,11 TO 10,35
RETURN


******************************ISPITIVANJE BAZE*******************************

PROCEDURE ISPBAZA

*****************************************************************************

CLOSE DATABASES
ERASE osob.dbf
SET COLOR TO "B/W+,W/N,,,"
CLS

*m_brojac:=0
m_baza:=SPACE(20)
DO WHILE .T.
 @ 2,2 SAY "Unesite ime baze podataka: " GET m_baza 
 READ
 IF LASTKEY() = 27
*  CLEAR SCREEN
*  @ 5,4 SAY "KRAJ PROGRAMA - 3sec !!!"
*  INKEY(1)
*  @ 5,4 SAY "KRAJ PROGRAMA - 2sec !!!"
*  INKEY(1)
*  @ 5,4 SAY "KRAJ PROGRAMA - 1sec !!!"
*  INKEY(1)
*  CLS
*  QUIT
 SET COLOR TO "GR+/R,RB+/G,,,"
 CLS
*SET MESSAGE TO 23 CENTER
 @ 4,11 TO 10,35
 RETURN
 ENDIF
 m_baza:=ALLTRIM(m_baza) + ".dbf"
 IF ! FILE(m_baza)
  @ 3,2 SAY "NE POSTOJI baza:" + UPPER(m_baza) + " u tekucem direktoriju !"
*  @ 3,2 SAY "Ta baza ne postoji !"
  INKEY(3)
  m_baza:=SPACE(20) 
  CLS
  LOOP
 ELSE
  EXIT
 ENDIF
ENDDO


*****************Formiranje baze OSOB.DBF********************
*p_matric:=0
*IF ! FILE("osob.dbf")

* p_matric:=ARRAY(4,4)
* p_matric[1,1] := "field_name"
* p_matric[1,2] := "c"
* p_matric[1,3] := 10
* p_matric[1,4] := 0
* p_matric[2,1] := "field_type"
* p_matric[2,2] := "c"
* p_matric[2,3] := 1
* p_matric[2,4] := 0
* p_matric[3,1] := "field_len"
* p_matric[3,2] := "n"
* p_matric[3,3] := 4
* p_matric[3,4] := 0
* p_matric[4,1] := "field_dec"
* p_matric[4,2] := "n"
* p_matric[4,3] := 3
* p_matric[4,4] := 0
* DBCREATE("osob", p_matric)
* USE

*QUIT
* @ 9,7 SAY "Kreirana je baza podataka OSOB.DBF !"
* @ 10,7 SAY "Baza OSOB.DBF se puni podacima o zadatoj bazi !"
*ELSE
* @ 9,7 SAY "Baza podataka OSOB.DBF vec postoji !"
* QUIT
*ENDIF





******************Punjenje baze OSOB.DBF********************
USE &m_baza
COPY TO osob STRUCTURE EXTENDED
CLOSE
USE osob
m_brsl:=RECCOUNT()

*************Obelezavanje neregularnog "C" polja sa "888"****************
p_ubaciti:=888
GO TOP
DO WHILE .T.
 IF field_type="C" .AND. field_len=0
  REPLACE field_len WITH p_ubaciti , field_dec WITH p_ubaciti
 ELSEIF field_type="C" .AND. field_dec#0
  REPLACE field_len WITH p_ubaciti , field_dec WITH p_ubaciti
 ENDIF
 SKIP
 IF EOF()
  EXIT
 ENDIF
ENDDO
GO TOP

***************Zaglavlje***************
*crta:=REPLICATE("-",52)
*m_red:=6
CLS

SET COLOR TO "R/W"
@ 1,22 SAY "U bazi: " + UPPER(m_baza) +;
           " ima " + ALLTRIM(STR(m_brsl)) + " polja !"
SET COLOR TO "B/W"

@ 3,13 SAY "IME POLJA"
@ 3,28 SAY "KARAKTER"
@ 3,40 SAY "BROJ MESTA"
@ 3,54 SAY "BROJ DECIMALA"
*@ 5,3 SAY crta
@ 0,0 TO 24,79 DOUBLE
@ 4,11 TO 22,68


***Kretanje po ekranu***
p_brr:=1
p_red:=5
p_izlaz:=0
*SELECT 1
*USE xxxxwwww

DO WHILE .T.
  SET COLOR TO "N/W"
  @ 1,2 SAY "Izlaz: Esc"
  @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
  @ 23,55 SAY "Listanje: GORE-" + CHR(24) + " DOLE-" + CHR(25)
  @ p_red,13 SAY field_name
  @ p_red,28 SAY field_type
  @ p_red,40 SAY ALLTRIM(STR(field_len,4))
  @ p_red,54 SAY ALLTRIM(STR(field_dec,3))
*  @ p_red,32 SAY vrs+"  "+osn+"  "+dob
  SKIP
  p_red:=p_red+1
  IF p_red=22
    IF p_izlaz=0
      INKEY(0)
    ELSEIF p_izlaz=1
      p_izlaz:=0
    ENDIF
*------- Prekid
    IF LASTKEY()=27
      CLOSE DATABASES
*      ERASE xxxxwwww.dbf
*      EXIT
     SET COLOR TO "GR+/R,RB+/G,,,"
     CLS
*     SET MESSAGE TO 23 CENTER
     @ 4,11 TO 10,35
     RETURN

*------- NA dole
    ELSEIF LASTKEY()=24 
      IF EOF()
        @ 23,3 SAY "Nema daljeg listanja na dole !"
        p_red:=5
        GO p_brr
        LOOP
      ENDIF
      @ 5,12 CLEAR TO 21,67
      @ 23,3 SAY SPACE(30)
      p_red:=5
      p_brr:=p_brr+1
      GO p_brr
      LOOP

*------- Na gore
    ELSEIF LASTKEY()=5 
      @ 5,12 CLEAR TO 21,67
      p_red:=5
      p_brr=p_brr-1
      GO p_brr
      IF BOF()
        @ 23,3 SAY "Nema daljeg listanja na gore !"
        p_red:=5
        p_brr:=p_brr+1
        GO p_brr
        LOOP
      ENDIF
      @ 23,3 SAY SPACE(30)
      LOOP
*------- Neka druga tipka
    ELSE
      FOR i=1 TO 3
        IF LASTKEY ()=24 .OR. LASTKEY()=5
          p_izlaz:=1
          LOOP
        ENDIF
        @ 23,31 SAY "POGRESAN TASTER !"
        INKEY(1.2)
        @ 23,31 SAY "                 " 
        INKEY(0.3)
      NEXT
      p_red:=5
      GO p_brr
      LOOP
    ENDIF
  ENDIF
ENDDO
CLOSE DATABASES
*ERASE xxxxwwww.dbf
*CLOSE DATABASES
*CLEAR SCREEN
*QUIT


*FOR i=1 TO m_brsl
* @ m_red,4 SAY field_name
* @ m_red,17 SAY field_type
* @ m_red,27 SAY STR(field_len,3)
* @ m_red,41 SAY STR(field_dec,3)
* m_red:=m_red+1
* m_brojac:=m_brojac+1
* SKIP
* IF m_red=21
*  @ m_red+1,2 SAY "Pritisnite bilo sta za dalje listanje !"
*  INKEY(0)
*  @ 6,0 CLEAR 
*  m_red:=6
* ENDIF
*NEXT
*@ m_red,2 SAY crta
*CLOSE DATABASES
*ERASE osob.dbf

*QUIT


*@ p_red+1,3 SAY "Pritisnite bilo sta za dalji rad !"
*INKEY(0)

CLOSE DATABASES
*ERASE osob.dbf
SET COLOR TO "GR+/R,RB+/G,,,"
CLS
*SET MESSAGE TO 23 CENTER
@ 4,11 TO 10,35
RETURN


****************************INDEKSIRANJE**********************************

PROCEDURE INDKSBZ

*********************Unos baze koja se indeksira****************
CLEAR
SET COLOR TO "W/B,GR+/W,,,"
CLS

*m_brojac:=0
m_baza:=SPACE(20)
DO WHILE .T.
 @ 2,2 SAY "Unesite ime baze podataka: " GET m_baza 
 READ
 IF LASTKEY() = 27
  CLS
*  @ 5,4 SAY "KRAJ PROGRAMA - 3sec !!!"
*  INKEY(1)
*  @ 5,4 SAY "KRAJ PROGRAMA - 2sec !!!"
*  INKEY(1)
*  @ 5,4 SAY "KRAJ PROGRAMA - 1sec !!!"
*  INKEY(1)
*  CLEAR SCREEN
*  QUIT
*  EXIT
 SET COLOR TO "GR+/R,RB+/G,,,"
 CLS
* SET MESSAGE TO 23 CENTER
 @ 4,11 TO 10,35
 RETURN
 ENDIF
 m_baza:=ALLTRIM(m_baza) + ".dbf"
 IF ! FILE(m_baza)
  @ 3,2 SAY "NE POSTOJI baza:" + UPPER(m_baza) + " u tekucem direktoriju !"
*  @ 3,2 SAY "Ta baza ne postoji !"
  INKEY(3)
  m_baza:=SPACE(20) 
  CLS
  LOOP
 ELSE
  EXIT
*  SET COLOR TO "GR+/R,RB+/G,,,"
*  CLS
** SET MESSAGE TO 23 CENTER
*  @ 4,11 TO 10,35
*  RETURN
 ENDIF
ENDDO



p_baza:=SPACE(12)
p_polje:=SPACE(10)
p_karak:=SPACE(1)
p_imeindbaz:=SPACE(8)
p_izraz:=SPACE(100)
p_brp:=1
p_izbor:=SPACE(1)

p_baza:=m_baza


*************Pravljenje izraza za indeksiranje****************

DO WHILE .T.

 @ 1,28 SAY "I N D E K S I R A NJ E" COLOR "G+/B"
 @ 4,4 SAY "Naziv polja: " GET p_polje
 @ 6,4 SAY "Karakter polja: " GET p_karak PICTURE "!" VALID(p_karak $ "NCDL")
 @ 7,4 SAY "N-numerik, C-karakter, D-datum, L-logik"
 READ

 IF LASTKEY() = 27
*  SET COLOR TO "W/N"
*  EXIT
  SET COLOR TO "GR+/R,RB+/G,,,"
  CLS
*  SET MESSAGE TO 23 CENTER
  @ 4,11 TO 10,35
  RETURN
 ENDIF

 IF p_brp=1
  IF p_karak = "C"
   p_izraz:=ALLTRIM(p_polje)
   @ 8,4 SAY "Polje: " + p_izraz
  ELSEIF p_karak = "N"
   p_izraz:="STR(" + ALLTRIM(p_polje) + ")"
   @ 8,4 SAY "Polje: " + p_izraz
  ELSEIF p_karak = "D"
   p_izraz:="DTOC(" + ALLTRIM(p_polje) + ")"
   @ 8,4 SAY "Polje: " + p_izraz
  ELSEIF p_karak = "L"
*   p_izraz:=  (p_polje)
*   @ 8,4 SAY "Polje: " + p_izraz
   @ 11,4 SAY "Logicke promenljive za sada ne primamo !!!"
   INKEY(3)
   @ 10,0 CLEAR
   p_polje:="          "
   p_karak:=" "
   LOOP
  ENDIF
 ELSEIF p_brp>1
  IF p_karak = "C"
   p_izraz:=p_izraz + "+" + ALLTRIM(p_polje)
   @ 8,4 SAY "Izraz: " + p_izraz
  ELSEIF p_karak = "N"
   p_izraz:=p_izraz + "+" + "STR(" + ALLTRIM(p_polje) + ")"
   @ 8,4 SAY "Izraz: " + p_izraz
  ELSEIF p_karak = "D"
   p_izraz:=p_izraz + "+" + "DTOC(" + ALLTRIM(p_polje) + ")"
   @ 8,4 SAY "Izraz: " + p_izraz
  ELSEIF p_karak = "L"
*   p_izraz:=p_izraz + "+" +   (p_polje)
*   @ 8,4 SAY "Izraz: " + p_izraz
    @ 11,4 SAY "Logicke promenljive za sada ne prihvatam !!!"
   INKEY(3)
   p_polje:="          "
   p_karak:=" "
   LOOP
  ENDIF
 ENDIF

 @ 11,4 SAY "Da li zelite dalji unos D/N ?" GET p_izbor ;
        PICTURE "!" VALID(p_izbor $ "DN")
 READ

 IF p_izbor == "N"
  @ 10,0 CLEAR
  EXIT
 ENDIF
 p_brp:=p_brp+1
 p_polje:="          "
 p_izbor:=" "
 p_karak:=" "
 @ 10,0 CLEAR 
ENDDO



**********Prekid ako je pritisnut "Esc"************
IF LASTKEY() = 27
 CLS
* SET COLOR TO "W/N"
* QUIT
SET COLOR TO "GR+/R,RB+/G,,,"
CLS
*SET MESSAGE TO 23 CENTER
@ 4,11 TO 10,35
RETURN
ENDIF

***************Ime indeksne baze*****************
DO WHILE .T.
 @ 10,4 SAY "Naziv indeksne baze: " GET p_imeindbaz
 READ
 IF LASTKEY() = 27
  SET COLOR TO "GR+/R,RB+/G,,,"
  CLS
  *SET MESSAGE TO 23 CENTER
  @ 4,11 TO 10,35
  RETURN
 ENDIF
 p_imeindbaz:=ALLTRIM(p_imeindbaz)+".ntx"
 IF FILE (p_imeindbaz)
  @ 11,4 SAY "Indeksna baza sa nazivom: " + UPPER(p_imeindbaz) +;
         " vec postoji !!!"
  
*  LOOP
*  EXIT
*  INKEY(2.5)
*  SET COLOR TO "GR+/R,RB+/G,,,"
*  CLS
*  *SET MESSAGE TO 23 CENTER
*  @ 4,11 TO 10,35
*  RETURN
   p_imeindbaz:=SPACE(8)
   INKEY(2)
   @ 11,4 SAY SPACE(50)
   LOOP
 ENDIF
 @ 11,4 SAY p_imeindbaz
* p_imeindbaz:=SPACE(8)
 INKEY(2)
 EXIT
ENDDO


*@ 15,4 SAY "Za sad toliko - stisni nesto (na tastaturi, naravno) !"
*INKEY(0)

*QUIT


*IF ! FILE(p_baza)
* @ 17,5 SAY "Baza " + UPPER(p_baza) + " ne postoji u tekucem direktoriju !"
** QUIT
*INKEY(2.5)
*SET COLOR TO "GR+/R,RB+/G,,,"
*CLS
**SET MESSAGE TO 23 CENTER
*@ 4,11 TO 10,35
*RETURN
*ENDIF

********Razdvajanje imena od ekstenzije*************
p_duzniz:=LEN(p_imeindbaz)
p_duzniz:=p_duzniz-4
p_imeindbaz:=SUBSTR(p_imeindbaz,1,p_duzniz)

*********Evo konacno i indeksiranja************
IF p_brp = 1
* IF ! FILE(p_imeindbaz)
  @ 17,5 SAY "Indeksiram " + UPPER(p_baza) + " sa " + p_imeindbaz
  INKEY(2)
  USE &p_baza
  INDEX ON &p_polje TO &p_imeindbaz
* ELSE
*  @ 17,5 SAY "Indeksna baza " + UPPER(p_imeindbaz) + ;
*             " vec postoji u tekucem direktorijumu !"
**  QUIT
*  SET COLOR TO "GR+/R,RB+/G,,,"
*  CLS
**  SET MESSAGE TO 23 CENTER
*  @ 4,11 TO 10,35
*  RETURN
* ENDIF
ENDIF


*p_zaart:=SPACE(3)
*p_zaknt:=SPACE(3)
*p_zakol:=SPACE(3)

*p_zaart:=STR(LTRIM(TRIM(&p_polje1)))
*p_zaknt:=STR(LTRIM(TRIM(&p_polje4)))
*p_zakol:=STR(LTRIM(TRIM(&p_polje6)))

*@ 10,5 SAY p_zaart+p_zaknt+p_zakol


IF p_brp > 1
* IF ! FILE(p_imeindbaz)
  @ 17,5 SAY "Indeksiram " + p_baza +" sa " + p_imeindbaz
  INKEY(2)
  USE &p_baza
 * p_izraz:="STR(&p_polje1,10)+&p_polje2+STR(&p_polje4,7)+STR(&p_polje6,9,3)"
  INDEX ON &p_izraz TO &p_imeindbaz
* ELSE
*  @ 17,5 SAY "Indeksna baza " + UPPER(p_imeindbaz) +;
*             " vec postoji u tekucem dirktorijumu !"
* * QUIT
* INKEY(2.5)
* SET COLOR TO "GR+/R,RB+/G,,,"
* CLS
** SET MESSAGE TO 23 CENTER
* @ 4,11 TO 10,35
* RETURN
* ENDIF
ENDIF

*CLS
*@ 5,4 SAY "KRAJ PROGRAMA - 3sec !!!"
*INKEY(1)
*@ 5,4 SAY "KRAJ PROGRAMA - 2sec !!!"
*INKEY(1)
*@ 5,4 SAY "KRAJ PROGRAMA - 1sec !!!"
*INKEY(1)
*CLEAR SCREEN


SET COLOR TO "GR+/R,RB+/G,,,"
CLS
*SET MESSAGE TO 23 CENTER
@ 4,11 TO 10,35
*SET COLOR TO
RETURN
*SET COLOR TO "W/N"
*QUIT





****Kretanje po ekranu***
*p_brr:=1
*p_red:=7
*p_izlaz:=0
*SELECT 1
*USE xxxxwwww
*
* DO WHILE .T.
*  SET COLOR TO "G/R"
*  @ 0,0 TO 24,79 DOUBLE
*  @ 6,14 TO 17,64
*  SET COLOR TO "GR+/R"
*  @ 1,2 SAY "Izlaz: Esc"
*  @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
*  @ 23,55 SAY "Listanje: GORE-" + CHR(24) + " DOLE-" + CHR(25)
*  @ p_red,32 SAY vrs+"  "+osn+"  "+dob
*  SKIP
*  p_red:=p_red+1
*  IF p_red=17
*    IF p_izlaz=0
*      INKEY(0)
*    ELSEIF p_izlaz=1
*      p_izlaz:=0
*    ENDIF
**------- Prekid
*    IF LASTKEY()=27
*      CLOSE DATABASES
*      ERASE xxxxwwww.dbf
*      EXIT
*
**------- NA dole
*    ELSEIF LASTKEY()=24 
*      IF EOF()
*        @ 23,3 SAY "Nema daljeg listanja na dole !"
*        p_red:=7
*        GO p_brr
*        LOOP
*      ENDIF
*      @ 6,1 CLEAR TO 23,78
*      p_red:=7
*      p_brr:=p_brr+1
*      GO p_brr
*      LOOP
*
**------- Na gore
*    ELSEIF LASTKEY()=5 
*      @ 6,1 CLEAR TO 23,78
*      p_red:=7
*      p_brr=p_brr-1
*     GO p_brr
*     IF BOF()
*       @ 23,3 SAY "Nema daljeg listanja na gore !"
*       p_red:=7
*       p_brr:=p_brr+1
*       GO p_brr
*       LOOP
*     ENDIF
*     LOOP
**------- Neka druga tipka
*    ELSE
*      FOR i=1 TO 3
*        IF LASTKEY ()=24 .OR. LASTKEY()=5
*          p_izlaz:=1
*          LOOP
*        ENDIF
*        @ 18,31 SAY "POGRESAN TASTER !"
*        INKEY(1.2)
*        @ 18,31 SAY "                 " 
*        INKEY(0.3)
*      NEXT
*      p_red:=7
*      GO p_brr
*      LOOP
*     ENDIF
*   ENDIF
* ENDDO




