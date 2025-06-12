
**********************************************************************
*****************************GLAVNI MENI ZA RAD***********************
**********************************************************************

SET CURSOR OFF
SET SCOREBOARD OFF

SET DATE GERMAN
p_pocdan:=SPACE(8)
p_pocvrem:=" "
p_pocdan:=DATE()
p_pocvrem:=TIME()
**********************************************************************

m_upisnv:="N"

PUBLIC m_br, p_slovniz, p_ispis, p_2brr, p_2red, p_2izlaz, p_pokbrr,;
       p_pokred, m_upisnv, p_redbrbaz, m_22brsl


p_imeput:=SPACE(100)
p_brznakniz:=0
p_brskida:=0
p_slovo:=SPACE(1)
p_slovniz:=SPACE(1)
p_ispis:=SPACE(1)
p_imeput:=CURDIR()
p_imeput:=ALLTRIM(p_imeput)
p_brznakniz:=LEN(p_imeput)
p_mestoskid:=0
p_brskida:=0
p_brizlaz:=0
DO WHILE .T.
 p_mestoskid:=p_brznakniz-p_brskida
 p_slovo:=SUBSTR(p_imeput,p_mestoskid,1)
 IF p_slovo="\"
  EXIT
 ENDIF
 p_slovniz:=p_slovo+p_slovniz
 p_brskida:=p_brskida+1
 IF p_slovniz=" " .OR. p_brznakniz=p_brizlaz
  p_ispis:="NEPOZNAT"
  EXIT
 ENDIF
 p_brizlaz:=p_brizlaz+1
ENDDO

IF p_brizlaz#0
 p_ispis:=UPPER(ALLTRIM(p_slovniz))
ENDIF


DO isptdrkt

SET COLOR TO "GR+/B,R/G,,,"
CLS
SET WRAP ON
SET MESSAGE TO 23 CENTER

p_brojcanik:=0
p_krjdan:=SPACE(8)

p_danraz:=SPACE(8)
p_krjvrem:=" "
p_vremraz:=0
p_dansec:=0
p_pocetak:=0
p_kraj:=0
p_razlika:=0

p_satp:=0
p_minp:=0
p_secp:=0
p_satk:=0
p_mink:=0
p_sack:=0
p_dan:=0
p_sat:=0
p_min:=0
p_sec:=0

p_dandec:=0
p_satdec:=0
p_mindec:=0

p_nula:="0"
p_cifra:=0

p_danz:=SPACE(1)
p_satz:=SPACE(1)
p_minz:=SPACE(1)
p_secz:=SPACE(1)

p_izbor:=1
DO WHILE .T.

 @ 4,27 TO 10,51
 @ 1,34 SAY "Izlaz->Esc"

 @ 5,29 PROMPT "Analiza direktorijuma";
 MESSAGE ("Ispitivanje tekuceg dirktorijuma (lista svih fajlova)")
 @ 7,29 PROMPT "Analiza databaza .DBF";
 MESSAGE ("Ispitivanje databaze (karakteristike, nova, brisanje)")
 @ 9,29 PROMPT "Analiza podataka baze";
 MESSAGE ("Ispitivanje podataka baze (pregled, pretraga, izmena)")
 CLEAR TYPEAHEAD
 MENU TO p_izbor

 DO CASE
  CASE p_izbor=0
   EXIT
  CASE p_izbor=1
   DO pregdrkt
  CASE p_izbor=2
   DO ispbaza
  CASE p_izbor=3
   DO izmprgbz
  ENDCASE

ENDDO

p_krjdan:=DATE()
p_krjvrem:=TIME()
CLS
@ 7,23 SAY "Pocetno vreme: "+DTOC(p_pocdan)+" - "+p_pocvrem
@ 8,23 SAY "Krajnje vreme: "+DTOC(p_krjdan)+" - "+p_krjvrem
p_danraz:=p_krjdan-p_pocdan
p_dansec:=p_danraz*86400

p_satp:=VAL(SUBSTR(p_pocvrem,1,2))
p_minp:=VAL(SUBSTR(p_pocvrem,4,2))
p_secp:=VAL(SUBSTR(p_pocvrem,7,2))
p_satk:=VAL(SUBSTR(p_krjvrem,1,2))
p_mink:=VAL(SUBSTR(p_krjvrem,4,2))
p_seck:=VAL(SUBSTR(p_krjvrem,7,2))

p_satp:=p_satp*3600
p_minp:=p_minp*60
p_satk:=p_satk*3600
p_mink:=p_mink*60

p_pocetak:=p_satp+p_minp+p_secp
p_kraj:=p_danraz+p_satk+p_mink+p_seck
p_razlika:=p_kraj-p_pocetak

p_dandec:=p_razlika/86400
p_dan:=INT(p_dandec)
p_danz:=ALLTRIM(STR(p_dan))
p_razlika:=p_razlika-p_dan*86400
p_satdec:=p_razlika/3600
p_sat:=INT(p_satdec)
p_satz:=ALLTRIM(STR(p_sat))
p_cifra:=LEN(p_satz)

IF p_cifra=1
 p_satz:=p_nula+p_satz
ENDIF
p_cifra:=0

p_razlika:=p_razlika-p_sat*3600
p_mindec:=p_razlika/60
p_min:=INT(p_mindec)
p_minz:=ALLTRIM(STR(p_min))
p_cifra:=LEN(p_minz)

IF p_cifra=1
 p_minz:=p_nula+p_minz
ENDIF
p_cifra:=0

p_razlika:=p_razlika-p_min*60
p_sec:=p_razlika
p_secz:=ALLTRIM(STR(p_sec))
p_cifra:=LEN(p_secz)
IF p_cifra=1
 p_seczn:=p_nula+p_secz
ENDIF

@ 12,10 SAY "Program ste koristili: "+p_danz+" dana, - "+;
           p_satz+" sati, "+p_minz+" minuta i "+p_secz+" sekundi !"
INKEY(5)

CLOSE DATABASES
ERASE podgran.dbf
ERASE imebaze.dbf
ERASE osob.dbf
ERASE gdlistin.ntx
ERASE ekstime.ntx

***KRAJ***

SET COLOR TO "W/N"
CLS
QUIT
************************** K R A J programa *********************




*************************************************************************
PROCEDURE ISPTDRKT
***************Priprema podataka o tekucem direktoriju******************

SELECT 1

IF FILE ("podgran.dbf")
  CLOSE
  ERASE podgran.dbf
ENDIF

matr:=DIRECTORY()

ar1:=1
red:=4
m_prov:=SPACE(4)
AADD(matr,"KRAJ")

m_br:=ASCAN(matr,"KRAJ")


p_mat:=0
p_mat:=ARRAY(7,4)
p_mat[1,1] := "redbr"
p_mat[1,2] := "n"
p_mat[1,3] := 6
p_mat[1,4] := 0
p_mat[2,1] := "ime"
p_mat[2,2] := "c"
p_mat[2,3] := 12
p_mat[2,4] := 0
p_mat[3,1] := "ekst"
p_mat[3,2] := "c"
p_mat[3,3] := 3
p_mat[3,4] := 0
p_mat[4,1] := "velicina"
p_mat[4,2] := "n"
p_mat[4,3] := 14
p_mat[4,4] := 0
p_mat[5,1] := "datum"
p_mat[5,2] := "d"
p_mat[5,3] := 0
p_mat[5,4] := 0
p_mat[6,1] := "vreme"
p_mat[6,2] := "c"
p_mat[6,3] := 8
p_mat[6,4] := 0
p_mat[7,1] := "a"
p_mat[7,2] := "c"
p_mat[7,3] := 4
p_mat[7,4] := 0

DBCREATE("podgran", p_mat)
USE

SET COLOR TO "GR+/B,"
CLS

@ 2,0 SAY REPLICATE ("_",78) COLOR "GR+/B"
@ 3,7 SAY "ESC -> za prekid i izlazak" COLOR "BG+/B"
@ 18,7 SAY "Program obradjuje fajlove: "+ALLTRIM(STR(m_br-1))+;
           " direktorija: " + p_ispis  COLOR "G+/B"
@ 22,0 SAY REPLICATE ("_",78) COLOR "GR+/B"


m_brfajl:=m_br-1
m_kol:=7
FOR i=1 TO 50
 @ 20,m_kol SAY CHR(176) COLOR "GR+/B"
 m_kol:=m_kol+1
NEXT

m_brf:=1
m_pr:=0
m_or:=2
m_kol:=7
m_brkc:=0
m_kol2:=0
m_kol3:=0
m_razlika:=0
m_brraz:=1


USE podgran

DO WHILE .T.

 IF m_br=ar1
  EXIT
 ENDIF

 IF matr[ar1,1]="IMEBAZE.DBF"
   ar1:=ar1+1
   LOOP
 ENDIF

 p_imexfj:=SPACE(12)
 p_jedslo:=SPACE(1)
 p_brief:=1
 p_imefj:=SPACE(12)
 p_ekstfj:=SPACE(3)

 p_imexfj:=matr[ar1,1]
 DO WHILE .T.
  p_jedslo:=SUBSTR(p_imexfj,p_brief,1)
  p_brief:=p_brief+1
  IF p_brief>12 .OR. p_jedslo=" "
   EXIT
  ELSEIF p_jedslo # "."
   p_imefj:=ALLTRIM(p_imefj)+p_jedslo
  ELSEIF p_jedslo = "."
   FOR b=1 TO 3
    p_jedslo:=SUBSTR(p_imexfj,p_brief,1)
    p_brief:=p_brief+1
    p_ekstfj:=ALLTRIM(p_ekstfj)+p_jedslo
   NEXT
   EXIT
  ENDIF
 ENDDO

 APPEND BLANK
 REPLACE redbr WITH ar1, ime WITH p_imefj, ekst WITH p_ekstfj,;
         velicina WITH matr[ar1,2], datum WITH matr[ar1,3],;
         vreme WITH matr[ar1,4],;
         a WITH matr[ar1,5]
 
 ar1:=ar1+1

 m_pr:=100*m_brf/m_brfajl
 m_brkc:=m_pr/2
 m_brkc:=ROUND(m_brkc,0)
 FOR i=1 TO m_brkc
  @ 20,m_kol SAY CHR(219) COLOR "GR+/B"
  @ 20,59 SAY STR(m_pr,6,2)+" %" COLOR"GR+/B"
  m_kol:=m_kol+1
 NEXT
 m_kol:=7
 m_brf:=m_brf+1

 INKEY()
 IF LASTKEY()=27
  @ 23,7 SAY "UNOS JE PREKINUT ! -- Od:"+ALLTRIM(STR(m_br-1))+", upisano je:"+;
             ALLTRIM(STR(ar1))+" fajlova." COLOR "BG+/B"
  INKEY(11)
  CLOSE DATABASES
  ERASE podgran.dbf
  SET COLOR TO "GR+/B,R/G,,,"
  CLS
  @ 4,27 TO 10,51
  RETURN
 ENDIF

ENDDO
CLOSE DATABASES
CLS
RETURN


*****************************PREGLED DIREKTORIJUMA**************************
PROCEDURE PREGDRKT
************Ispis fajlova tekuceg direktorija sa karakteristikama***********


IF ! FILE("podgran.dbf")
  DO isptdrkt
ENDIF

CLEAR
SET DATE GERMAN
SET CONFIRM ON
SET CURSOR OFF
SET COLOR TO "GR+/B"
CLS

SELECT 1
USE podgran

SET COLOR TO "BG+/B"
@ 0,0 TO 24,79 DOUBLE
@ 4,3 TO 22,76
@ 1,70 SAY "Izlaz-Esc"
@ 2,1 SAY "Ime direktojrija:" + p_ispis + " - Broj fajlova:" + ;
           ALLTRIM(STR(m_br-1))
@ 2,52 SAY "Broj u zaglavlju-> REDOSLED"
@ 23,1 SAY "Skok:PAGE UP-" + CHR(24) + " PAGE DOWN-" + CHR(25)
@ 23,57 SAY "Listanje:GORE-" + CHR(24) + " DOLE-" + CHR(25)

SET COLOR TO "GR+/B"

@ 3,4 SAY "RED"
@ 3,8 SAY "1-Red Br"
@ 3,19 SAY "2-Ime"
@ 3,30 SAY "3-Ekst"
@ 3,38 SAY "4-Bajta"
@ 3,48 SAY "5-Datum"
@ 3,58 SAY "6-Vreme"
@ 3,68 SAY "7-Atrib"
p_red:=5
p_izlaz:=0
p_gdlist:=1
p_redbro:=1

DO WHILE .T.

  @ 4,3 TO 22,7 COLOR "BG+/B"
  @ 4,7 SAY CHR(194) COLOR "BG+/B"
  @ 22,7 SAY CHR(193) COLOR "BG+/B"
  @ p_red,4  SAY ALLTRIM(STR(p_redbro))
  @ p_red,10 SAY ALLTRIM(STR(redbr))
  @ p_red,19 SAY ALLTRIM(ime)
  @ p_red,30 SAY ALLTRIM(ekst)
  @ p_red,38 SAY ALLTRIM(STR(velicina))
  @ p_red,48 SAY DTOC(datum)
  @ p_red,58 SAY vreme
  @ p_red,72 SAY a
  p_red:=p_red+1
  p_redbro:=p_redbro+1
  SKIP

  IF EOF() .AND. p_red<22 .AND. m_br>17
    p_red:=5
    GO BOTTOM
    p_redbro:=m_br-17
    SKIP -16
    @ 5,4 CLEAR TO 21,74
    LOOP
  ENDIF

  IF p_red=22 .OR. BOF() .OR. EOF()
    IF p_izlaz=0

      SET DATE GERMAN
      danispi:=DATE()-1
      vremispi=" "
      p_danned:=0
      p_zdanned:=SPACE(1)
      p_taster:=0

      DO WHILE .T.
        SET CONFIRM OFF

        IF danispi<DATE()
          @ 1,1 CLEAR TO 1,55
        ENDIF
        danispi:=DATE()
        vremispi:=TIME()

        p_danned:=DOW(DATE())
        DO CASE
        CASE p_danned=1
          p_zdanned:="Nedelja"
        CASE p_danned=2
          p_zdanned:="Ponedeljak"
        CASE p_danned=3
          p_zdanned:="Utorak"
        CASE p_danned=4
          p_zdanned:="Sreda"
        CASE p_danned=5
          p_zdanned:="Cetvrtak"
        CASE p_danned=6
          p_zdanned:="Petak"
        CASE p_danned=7
          p_zdanned:="Subota"
        ENDCASE

        @ 1,1 SAY "Danas je: "+p_zdanned+", "+DTOC(danispi)+;
        " - Vreme: "+vremispi COLOR "BG+/B"

        CLEAR TYPEAHEAD
        p_taster:=INKEY()

        IF p_taster#0
          SET CONFIRM ON
          EXIT
        ENDIF

      ENDDO

    ELSEIF p_izlaz=1
      p_izlaz:=0
    ENDIF

    IF LASTKEY()=27
     CLOSE DATABASES
     ERASE gdlistin.ntx
     SET COLOR TO "GR+/B,R/G,,,"
     CLS
     @ 4,27 TO 10,51
     RETURN

    ELSEIF LASTKEY()=49
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      IF p_gdlist#12
        p_gdlist:=12
        INDEX ON STR(redbr) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ELSEIF p_gdlist=12
        p_gdlist:=11
        INDEX ON DESCEND(STR(redbr)) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

    ELSEIF LASTKEY()=50
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      IF p_gdlist#22
        p_gdlist:=22
        INDEX ON ime+ekst TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ELSEIF p_gdlist=22
        p_gdlist:=21
        INDEX ON DESCEND(ime+ekst) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

    ELSEIF LASTKEY()=51
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      IF p_gdlist#32
        p_gdlist:=32
        INDEX ON ekst+ime TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ELSEIF p_gdlist=32
        p_gdlist:=31
        INDEX ON DESCEND(ekst+ime) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

    ELSEIF LASTKEY()=52
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      IF p_gdlist#42
        p_gdlist:=42
        INDEX ON STR(velicina)+ime TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ELSEIF p_gdlist=42
        p_gdlist:=41
        INDEX ON DESCEND(STR(velicina)+ime) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

    ELSEIF LASTKEY()=53
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      IF p_gdlist#52
        p_gdlist:=52
        INDEX ON DTOS(datum)+vreme TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ELSEIF p_gdlist=52
        p_gdlist:=51
        INDEX ON DESCEND(DTOS(datum)+vreme) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

    ELSEIF LASTKEY()=54
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      IF p_gdlist#62
        p_gdlist:=62
        INDEX ON vreme TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ELSEIF p_gdlist=62
        p_gdlist:=61
        INDEX ON DESCEND(vreme) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

    ELSEIF LASTKEY()=55
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      IF p_gdlist#72
        p_gdlist:=72
        INDEX ON a TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ELSEIF p_gdlist=72
        p_gdlist:=71
        INDEX ON DESCEND(a) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

    ELSEIF LASTKEY()=5 
      p_red:=5
      p_redbro:=p_redbro-18
      SKIP -18
      IF BOF()
        @ 23,30 SAY "NEMA VISE LISTANJA GORE!"
        INKEY(1.2)                 
        @ 23,30 SAY "                        "
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF
      @ 5,4 CLEAR TO 21,74
      LOOP

    ELSEIF LASTKEY()=18
      p_redbro:=p_redbro-18
      SKIP -18
      IF BOF()
        @ 23,30 SAY "NEMA VISE LISTANJA GORE!"
        INKEY(1.2)
        @ 23,30 SAY "                        "
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF
      p_redbro:=p_redbro+18
      SKIP 18
      p_red:=5
      p_redbro:=p_redbro-34
      IF p_redbro<1
        p_redbro:=1
      ENDIF
      SKIP -34
      @ 5,4 CLEAR TO 21,74
      LOOP

    ELSEIF LASTKEY()=24 
      IF EOF() .AND. m_br>17
        @ 23,30 SAY "NEMA VISE LISTANJA DOLE!"
        INKEY(1.2)
        @ 23,30 SAY "                        "
        p_red:=5
        p_redbro:=m_br-17
        GO BOTTOM
        SKIP -16
        @ 5,4 CLEAR TO 21,74
        LOOP
      ELSEIF EOF() .AND. m_br<18
        @ 23,30 SAY "NEMA VISE LISTANJA DOLE!"
        INKEY(1.2)
        @ 23,30 SAY "                        "
        p_red:=5
        GO TOP
        p_redbro:=1
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF
      @ 5,4 CLEAR TO 21,74
      p_red:=5
      p_redbro:=p_redbro-16
      SKIP -16
      @ 5,4 CLEAR TO 21,74
      LOOP

    ELSEIF LASTKEY()=3
      IF EOF()  .AND. m_br>17
        @ 23,30 SAY "NEMA VISE LISTANJA DOLE!"
        INKEY(1.2)
        @ 23,30 SAY "                        "
        p_red:=5
        GO BOTTOM
        p_redbro:=m_br-17
        SKIP -16
        @ 5,4 CLEAR TO 21,74
        LOOP
      ELSEIF EOF() .AND. m_br<18
        @ 23,30 SAY "NEMA VISE LISTANJA DOLE!"
        INKEY(1.2)
        @ 23,30 SAY "                        "
        p_red:=5
        GO TOP
        p_redbro:=1
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF
      @ 5,4 CLEAR TO 21,74
      p_red:=5
      @ 5,4 CLEAR TO 21,74
      LOOP      

    ELSE
      IF LASTKEY()=5 .OR. LASTKEY()=18 .OR. LASTKEY ()=24 .OR. LASTKEY()=3 
        p_izlaz:=1
        LOOP
      ENDIF
      @ 23,30 SAY "POGRESAN TASTER !"
      INKEY(1.7)
      @ 23,30 SAY "                 " 
      p_red:=5
      IF m_br<18
        GO TOP
        p_redbro:=1
      ELSEIF m_br>17
        SKIP -17
        p_redbro:=p_redbro-17
      ENDIF
      LOOP
    ENDIF
  ENDIF
ENDDO



******************************ISPITIVANJE BAZE*******************************
PROCEDURE ISPBAZA
***********************Ispisivanje podataka o elementima baze****************


IF ! FILE("podgran.dbf")
  DO isptdrkt
ENDIF

SELECT 1
USE podgran
INDEX ON ekst+ime TO ekstime.ntx

SEEK "DBF"

IF ! FOUND()
  CLS
  @ 0,0 TO 24,79 DOUBLE
  @ 1,1 SAY "F5 -> kreiranje nove databaze"
  @ 11,17 SAY "U OVOM DIRKTORIJU NE POSTOJI NIJEDNA DATABAZA"
  @ 23,1 SAY "Bilo sta (osim F5) -> Izlazak"
  INKEY(0)
  IF LASTKEY()=-5
    DO kreirbaz
  ELSE
    CLOSE DATABASES
    ERASE ekstime.ntx
    SET COLOR TO "GR+/B,R/G,,,"
    CLS
    @ 4,27 TO 10,51
    RETURN
  ENDIF
ELSEIF FOUND()
  SELECT 2
  IF FILE("imebaze.dbf")
    CLOSE 
    ERASE imebaze.dbf
  ENDIF
ENDIF

p_mat2:=0
p_mat2:=ARRAY(2,4)
p_mat2[1,1] := "redbrojb"
p_mat2[1,2] := "n"
p_mat2[1,3] := 3
p_mat2[1,4] := 0
p_mat2[2,1] := "imebaze"
p_mat2[2,2] := "c"
p_mat2[2,3] := 12
p_mat2[2,4] := 0
  
DBCREATE("imebaze", p_mat2)
USE
  
SELECT 2
USE imebaze
p_redbrbaz:=0
DO WHILE .T.
  p_redbrbaz:=p_redbrbaz+1
  SELECT 2
  APPEND BLANK
  REPLACE imebaze WITH A->ime, redbrojb WITH p_redbrbaz
  SELECT 1
  SKIP
  IF ekst # "DBF"
    EXIT
  ENDIF
ENDDO
    
CLS

m_22brsl:=0
SELECT 2
m_22brsl:=RECCOUNT()

@ 0,0 TO 24,79 DOUBLE
@ 5,29 SAY "Red"
@ 5,33 SAY "Ime databaze"    

@ 1,1 SAY "Ime direktorija: " + p_ispis +;
           " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
@ 1,63 SAY "Datum: "+DTOC(DATE())+"."
@ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
           "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 

p_2brr:=1
p_2red:=7
p_2izlaz:=0
p_pokbrr:=1
p_pokred:=7
m_baza:=SPACE(12)

GO TOP
DO WHILE .T.
  @ 6,32 TO 15,45
  @ 6,28 TO 15,32
  @ 6,32 SAY CHR(194)
  @ 15,32 SAY CHR(193)
  @ 1,1 CLEAR TO 1,62
  @ 1,1 SAY "Ime direktorija: " + p_ispis +;
             " - Broj databaza: " + ALLTRIM(STR(m_22brsl))

  @ p_2red,29 SAY ALLTRIM(STR(redbrojb))
  @ p_2red,33 SAY ALLTRIM(imebaze)

  SKIP
  p_2red:=p_2red+1

  IF p_2red=15 .OR. BOF() .OR. EOF()

      GO p_pokbrr
      @ p_pokred,32 SAY CHR(179) COLOR "GR+/G"
      @ p_pokred,29 SAY "   " COLOR "R/G"
      @ p_pokred,29 SAY ALLTRIM(STR(redbrojb)) COLOR "R/G"
      @ p_pokred,33 SAY imebaze COLOR "R/G"

      INKEY(0)

    IF LASTKEY()=27
      CLOSE DATABASES
      ERASE imebaze.dbf
      ERASE ekstime.ntx
      SET COLOR TO "GR+/B,R/G,,,"
      CLS
      @ 4,27 TO 10,51
      RETURN

    ELSEIF LASTKEY()=13
      m_baza:=imebaze
      DO prgpodbz
      p_2red:=7
      GO p_2brr
      LOOP

    ELSEIF LASTKEY()=-4
      DO kreirbaz
      m_22brsl:=m_22brsl+1
      p_2red:=7
      GO p_2brr
      LOOP

    ELSEIF LASTKEY()=7
      @ 20,1 CLEAR TO 22,78
      m_potvrd:="N"
      @ 20,12 SAY "Potvrdite brisanje databaze:"+ALLTRIM(UPPER(imebaze))+;
                  ".DBF"+"(D/N) ->" ;
                  GET m_potvrd PICTURE "!" VALID(m_potvrd $ "DdNn")
      READ
      @ 20,1 CLEAR TO 22,78
      IF m_potvrd="N"
        p_2red:=7
        GO p_2brr
        LOOP
      ENDIF
      m_brisanje:=" "
      m_brisanje:=imebaze+".dbf"
      ERASE &m_brisanje
      GO p_pokbrr
      DELETE
      PACK
      DO isptdrkt
      USE imebaze
      m_22brsl:=m_22brsl-1
      p_2brr:=1
      p_2red:=7
      p_pokbrr:=1
      p_pokred:=7
      GO p_2brr
      SET COLOR TO "GR+/B,R/G,,,"
      CLS
      @ 0,0 TO 24,79 DOUBLE
      @ 5,29 SAY "Red"
      @ 5,33 SAY "Ime databaze"    
      @ 1,1 SAY "Ime direktorija: " + p_ispis +;
                 " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
      @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
      @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
                 "*"+"Nova_baza:F5"+"*"+;
                 "Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25)
      LOOP

    ELSEIF LASTKEY()=24 
      p_pokbrr:=p_pokbrr+1
      GO p_pokbrr
      IF EOF()
        @ 20,25 SAY "NEMA VISE LISTANJA DOLE"
        INKEY(1.2)
        @ 20,25 SAY "                       "
        p_2red:=7
        p_pokbrr:=p_pokbrr-1
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ENDIF
      IF p_pokred=p_2red-1
        p_2red:=7
        p_2brr:=p_2brr+1
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ELSEIF p_pokred<p_2red-1
        p_pokred:=p_pokred+1
        p_2red:=7
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ENDIF

    ELSEIF LASTKEY()=5 
      p_pokbrr:=p_pokbrr-1
      p_pokred:=p_pokred-1
      p_2red:=7
      IF p_pokred>7
        *
      ELSEIF p_pokred=6
        p_2brr=p_2brr-1
        p_pokred:=p_pokred+1
      ENDIF
      GO p_2brr
      IF BOF()
        @ 20,25 SAY "NEMA VISE LISTANJA GORE"
        INKEY(1.2)
        @ 20,25 SAY "                       "
        p_2brr:=p_2brr+1
        p_pokbrr:=p_pokbrr+1
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ENDIF
      @ 6,28 CLEAR TO 15,45
      LOOP

    ELSE
      @ 20,29 SAY "POGRESAN TASTER"
      INKEY(1.7)
      @ 20,29 SAY "               " 
      p_2red:=7
      GO p_2brr
      LOOP
    ENDIF
  ENDIF
ENDDO


***********************PREGLED PODATAKA BAZE*************************
PROCEDURE PRGPODBZ
************Pregled podataka izabrane baze podataka******************

m_baza:=ALLTRIM(LOWER(m_baza)) + ".dbf"

SELECT 5

IF FILE("osobx.dbf")
  CLOSE DATABASES
  ERASE osobx.dbf
ENDIF

USE &m_baza
COPY TO osobx STRUCTURE EXTENDED
CLOSE
USE osobx

SELECT 3

IF FILE("osob.dbf")
  CLOSE 
  ERASE osob.dbf
ENDIF

p_matb:=0
p_matb:=ARRAY(5,4)
p_matb[1,1]:="brojfjl"
p_matb[1,2]:="n"
p_matb[1,3]:=3
p_matb[1,4]:=0
p_matb[2,1]:="field_name"
p_matb[2,2]:="c"
p_matb[2,3]:=10
p_matb[2,4]:=0
p_matb[3,1]:="field_type"
p_matb[3,2]:="c"
p_matb[3,3]:=1
p_matb[3,4]:=0
p_matb[4,1]:="field_len"
p_matb[4,2]:="n"
p_matb[4,3]:=3
p_matb[4,4]:=0
p_matb[5,1]:="field_dec"
p_matb[5,2]:="n"
p_matb[5,3]:=3
p_matb[5,4]:=0

DBCREATE("osob", p_matb)
USE
  
USE osob

m_brzaupis:=0
DO WHILE .T.
  m_brzaupis:=m_brzaupis+1
  APPEND BLANK
  REPLACE brojfjl WITH m_brzaupis, field_name WITH E->field_name,;
          field_type WITH E->field_type, field_len WITH E->field_len,;
          field_dec WITH E->field_dec
  SELECT 5
  SKIP
  IF EOF()
    CLOSE 
    ERASE osobx.dbf
    SELECT 3
    EXIT
  ENDIF
  SELECT 3
ENDDO
m_brsl:=RECCOUNT()

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

SET COLOR TO "G+/B"
CLS
@ 1,20 SAY "Baza:" + ALLTRIM(UPPER(m_baza)) +;
           " - Broj polja:" + ALLTRIM(STR(m_brsl)) 
SET COLOR TO "BG+/B"

@ 3,10 SAY "R.Br."
@ 3,15 SAY "* Ime Polja"
@ 3,29 SAY "* Karakter"
@ 3,41 SAY "* Broj mesta"
@ 3,55 SAY "* Broj decimala"
@ 0,0 TO 24,79 DOUBLE
@ 4,9 TO 22,70

p_brr:=1
p_red:=5
p_izlaz:=0
DO WHILE .T.
  SET COLOR TO "GR+/B"
  @ 1,2 SAY "Izlaz: Esc"
  @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
  @ 23,55 SAY "Listanje: GORE-" + CHR(24) + " DOLE-" + CHR(25)
  @ p_red,10 SAY brojfjl
  @ p_red,14 SAY " * "+field_name
  @ p_red,28 SAY " *    "+field_type
  @ p_red,40 SAY " *    "+ALLTRIM(STR(field_len,4))
  @ p_red,54 SAY " *      "+ALLTRIM(STR(field_dec,3))
  SKIP
  p_red:=p_red+1

  IF p_red=22 .OR. BOF() .OR. EOF()
      INKEY(0)

    IF LASTKEY()=27
      CLOSE DATABASES
      ERASE osob.dbf
      SELECT 2
      USE imebaze
      SET COLOR TO "GR+/B,R/G,,,"
      CLS
      @ 0,0 TO 24,79 DOUBLE
      @ 5,29 SAY "Red"
      @ 5,33 SAY "Ime databaze"    
      @ 1,1 SAY "Ime direktorija: " + p_ispis +;
                " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
      @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
      @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
                 "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 
      RETURN
    ELSEIF LASTKEY()=24 
      IF EOF()
        @ 23,3 SAY "Nema daljeg listanja na dole !"
        INKEY(1.2)
        @ 23,3 SAY "                              "
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
    ELSEIF LASTKEY()=5 
      p_red:=5
      p_brr=p_brr-1
      GO p_brr
      IF BOF()
        @ 23,3 SAY "Nema daljeg listanja na gore !"
        INKEY(1.2)
        @ 23,3 SAY "                              "
        p_red:=5
        p_brr:=p_brr+1
        GO p_brr
        @ 5,12 CLEAR TO 21,67
        LOOP
      ENDIF
      @ 23,3 SAY SPACE(30)
      @ 5,12 CLEAR TO 21,67
      LOOP
    ELSE
      @ 23,31 SAY "POGRESAN TASTER !"
      INKEY(1.7)
      @ 23,31 SAY "                 " 
      p_red:=5
      GO p_brr
      LOOP
    ENDIF
  ENDIF
ENDDO


**************************KREIRANjE BAZE***********************
PROCEDURE KREIRBAZ
********************Kreiranje nove databaze********************

CLS

SELECT 3
CLS

m_imnvbz:=SPACE(8)
m_dobroime:="D"

DO WHILE .T.
  m_prbime:=" "
  @ 8,24 SAY "Ime sadrzi: slovo, broj ili _ "
  @ 9,23 TO 15,54
  @ 16,33 SAY "Izlaz -> Esc"
  SET CONFIRM ON
  SET CURSOR ON
  @ 11,25 SAY "Unesite ime baze:" GET m_imnvbz
  READ
  SET CONFIRM OFF
  SET CURSOR OFF
  IF LASTKEY()=27
    SELECT 2
    SET COLOR TO "GR+/B,R/G,,,"
    CLS
    @ 0,0 TO 24,79 DOUBLE
    @ 5,29 SAY "Red"
    @ 5,33 SAY "Ime databaze"    
    @ 1,1 SAY "Ime direktorija: " + p_ispis +;
              " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
    @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
    @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
               "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 
    RETURN
  ENDIF
  IF EMPTY(m_imnvbz)
    LOOP
  ENDIF
  @ 13,24 CLEAR TO 11,22
  m_imnvbz:=LOWER(m_imnvbz)
  m_brupsime:=0
  m_znimnbz:=" "
  m_imnvbz:=ALLTRIM(m_imnvbz)
  m_brupsime:=LEN(m_imnvbz)
  FOR l=1 TO m_brupsime
    m_znimnbz:=SUBSTR(m_imnvbz,l,1)
    IF m_znimnbz $ "1234567890_qwertyuiopasdfghjklzxcvbnm"
      m_dobroime:="D"
    ELSE
      @ 13,25 SAY "Neispravan naziv baze !      "
      m_dobroime:="N"
      EXIT
    ENDIF
  NEXT
  IF m_dobroime="N"
    LOOP
  ENDIF
  m_prbime:=m_imnvbz+".dbf"
  IF FILE(m_prbime)
    @ 13,25 SAY "Ta baza vec postoji !"
    m_dobroime:="N"
    LOOP
  ENDIF
  EXIT
ENDDO

IF FILE("osob.dbf")
  CLOSE
  ERASE osob.dbf
ENDIF

CREATE osob
APPEND BLANK

CLS
@ 4,23 TO 21,54 DOUBLE
@ 24,1 SAY "Izlaz:Esc*Novo_polje:F5*Unos:Enter*Brisanje:Delete*"+;
           "Kreiranje:F7*Kretanje:"+CHR(24)+"-"+CHR(25)
           
@ 3,24 SAY "Ime polja"
@ 3,35 SAY "Tip"
@ 3,39 SAY "Duzina"
@ 3,46 SAY "Decimale"
@ 4,34 SAY CHR(209)
@ 4,38 SAY CHR(209)
@ 4,45 SAY CHR(209)
@ 21,34 SAY CHR(207)
@ 21,38 SAY CHR(207)
@ 21,45 SAY CHR(207)

DECLARE p_mtrfrm[4]
p_mtrfrm[1]:=24
p_mtrfrm[2]:=36
p_mtrfrm[3]:=41
p_mtrfrm[4]:=48

m_brslnv:=0
m_brppnv:=0
m_rdppnv:=0
m_klppnv:=1
m_trnvsl:=0
m_upnvpl:="N"

DO WHILE .T.
  m_brrdnv:=0

  @ 5,24 CLEAR TO 20,53
  @ 22,10 CLEAR TO 22,65
  FOR z=1 TO 16
    @ 4+z,34 SAY CHR(179)
    @ 4+z,38 SAY CHR(179)
    @ 4+z,45 SAY CHR(179)
  NEXT

  DO WHILE .T.
    m_brrdnv:=m_brrdnv+1
    @ m_brrdnv+4,24 SAY field_name COLOR "BG+/B"
    @ m_brrdnv+4,36 SAY field_type COLOR "BG+/B"
    @ m_brrdnv+4,41 SAY field_len COLOR "BG+/B"
    @ m_brrdnv+4,48 SAY field_dec COLOR "BG+/B"
    SKIP
    IF m_brrdnv=16 .OR. EOF()
      SKIP -m_brrdnv
      EXIT
    ENDIF
  ENDDO

  IF m_rdppnv>0
    SKIP m_rdppnv
  ENDIF
  m_brslnv:=RECCOUNT()
  m_trnvsl:=RECNO()
  IF m_klppnv=1 
    m_isppnv:=" "
    m_isppnv:=field_name
  ELSEIF m_klppnv=2 
    m_isppnv:=" "
    m_isppnv:=field_type
  ELSEIF m_klppnv=3
    m_isppnv:=0
    m_isppnv:=field_len
  ELSEIF m_klppnv=4
    m_isppnv:=0
    m_isppnv:=field_dec
  ENDIF
  IF m_rdppnv>0
    SKIP -m_rdppnv
  ENDIF

  @ m_rdppnv+5,p_mtrfrm[m_klppnv] SAY m_isppnv COLOR "B/W"

  @ 1,1 SAY "Baza: "+UPPER(m_imnvbz)+;
            " - Polje: "+ALLTRIM(STR(m_trnvsl))+"/"+ALLTRIM(STR(m_brslnv))

  IF m_upnvpl="N"
    INKEY(0)
  ENDIF

  IF LASTKEY()=27
    m_brisbz:="N"
    @ 22,1 CLEAR TO 22,78
    @ 22,19 SAY "Odustajete od kreiranja baze:"+UPPER( m_imnvbz)+;
            " (D/N) - " GET m_brisbz PICTURE "!" VALID(m_brisbz $ "DdNn") 
    READ
    @ 22,1 CLEAR TO 22,78
    IF m_brisbz="N"
      LOOP
    ENDIF
    m_22brsl:=m_22brsl-1
    CLOSE
    ERASE osob.dbf
    SELECT 2
    SET COLOR TO "GR+/B,R/G,,,"
    CLS
    @ 0,0 TO 24,79 DOUBLE
    @ 5,29 SAY "Red"
    @ 5,33 SAY "Ime databaze"    
    @ 1,1 SAY "Ime direktorija: " + p_ispis +;
              " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
    @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
    @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
               "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 
    RETURN

   ELSEIF LASTKEY()=-6
    m_brisbz:="N"
    @ 22,1 CLEAR TO 22,78
    @ 22,5 SAY "Formiranje:"+UPPER( m_imnvbz)+;
               ". Nepotpuni slogovi bice izbrisani !"+;
               "(D/N) ->" GET m_brisbz PICTURE "!" VALID(m_brisbz $ "DdNn") 
    READ
    @ 22,1 CLEAR TO 22,78
    IF m_brisbz="N"
      LOOP
    ENDIF
    GO TOP
    DO WHILE !EOF()
      IF EMPTY(field_name) .OR. EMPTY(field_type) .OR. EMPTY(field_len)
        DELETE
        PACK
      ENDIF
      SKIP
    ENDDO
    m_brslxx:=0
    m_brslxx:=RECCOUNT()
    p_mtform:=0
    p_mtform:=ARRAY(m_brslxx,4)
    GO TOP
    FOR q=1 TO m_brslxx
      p_mtform[q,1]:=field_name
      p_mtform[q,2]:=field_type
      p_mtform[q,3]:=field_len
      p_mtform[q,4]:=field_dec
      SKIP
    NEXT
    DBCREATE(m_imnvbz,p_mtform)
    USE
    m_upisnv:="D"
    CLOSE 
    ERASE osob.dbf
    DO isptdrkt
    SELECT 2
    USE imebaze
    APPEND BLANK
    REPLACE imebaze WITH UPPER(m_imnvbz), redbrojb WITH p_redbrbaz+1
    SET COLOR TO "GR+/B,R/G,,,"
    CLS
    @ 0,0 TO 24,79 DOUBLE
    @ 5,29 SAY "Red"
    @ 5,33 SAY "Ime databaze"    
    @ 1,1 SAY "Ime direktorija: " + p_ispis +;
              " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
    @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
    @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
               "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 
    RETURN

  ELSEIF LASTKEY()=-4
    m_klppnv:=1
    IF m_upnvpl="N"
      m_upnvpl:="D"
      APPEND BLANK
      m_upnvpd:=field_name
      IF m_brslnv>16
        SKIP-16
        m_rdppnv:=16
        m_brslnv:=m_brslnv+1
      ELSEIF m_brslnv<17
        SKIP-m_brslnv
        m_rdppnv:=m_brslnv
        m_brslnv:=m_brslnv+1
      ENDIF
      LOOP
    ENDIF
    m_upnvpl:="N"
    @ 22,24 SAY "Ime sadrzi: slovo, broj ili _ "
    DO WHILE.T.
      SET CONFIRM ON
      SET CURSOR ON
      @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_upnvpd COLOR "R/W"
      READ
      SET CONFIRM OFF
      SET CURSOR OFF
      IF LASTKEY()=27
        m_upnvpd:=" "
        EXIT
      ENDIF
      m_upnvpd:=ALLTRIM(LOWER(m_upnvpd))
      m_brmsime:=0
      m_zimplj:=" "
      m_brmsime:=LEN(m_upnvpd)
      m_zimplj:=SUBSTR(m_upnvpd,1,1)
      IF m_zimplj $ "1234567890_"
        LOOP
      ENDIF
      FOR w=1 TO m_brmsime
        m_zimplj:=SUBSTR(m_upnvpd,w,1)
        IF m_zimplj $ "1234567890_qwertyuiopasdfghjklzxcvbnm"
          m_dobroime:="D"
        ELSE
          m_dobroime:="N"
          EXIT
        ENDIF
      NEXT
      IF m_dobroime="D"
        EXIT
      ENDIF
    ENDDO

    IF EMPTY(m_upnvpd)
      IF m_rdppnv>0
        SKIP m_rdppnv
      ENDIF
      DELETE
      PACK
      IF m_rdppnv>0
        SKIP -m_rdppnv
      ENDIF
      IF m_brslnv>16
        GO BOTTOM
        SKIP-15
        m_rdppnv:=16
      ELSEIF m_brslnv<17
        GO TOP
        m_rdppnv:=m_rdppnv-1
      ENDIF
      LOOP
    ENDIF

    IF m_rdppnv>0
      SKIP m_rdppnv
    ENDIF
    REPLACE field_name WITH m_upnvpd
    IF m_rdppnv>0
      SKIP -m_rdppnv
    ENDIF
    LOOP

  ELSEIF LASTKEY()=7
    IF m_brslnv=0
      IF m_brslnv<18
        GO TOP
      ENDIF
      LOOP
    ENDIF
    IF m_rdppnv>0
      SKIP m_rdppnv
    ENDIF
    DELETE
    PACK
    IF m_rdppnv>0
      SKIP -m_rdppnv
    ENDIF
    IF m_trnvsl=m_brslnv
      IF m_brslnv>16
        GO BOTTOM
        SKIP-15
        m_rdppnv:=16
      ELSEIF m_brslnv<17
        GO TOP
        m_rdppnv:=m_rdppnv-1
      ENDIF
    ENDIF
    LOOP

  ELSEIF LASTKEY()=13
    SET CONFIRM ON
    SET CURSOR ON
    IF m_rdppnv>0
      SKIP m_rdppnv
    ENDIF
    IF m_klppnv=1
      m_plppnv:=field_name
      DO WHILE .T.
        m_dobrpl:="D"
        @ 22,24 SAY "Ime sadrzi: slovo, broj ili _ "
        @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv COLOR "R/W"
        READ
        IF LASTKEY()=27
          IF m_rdppnv>0
            SKIP -m_rdppnv
          ENDIF
          SET CONFIRM OFF
          SET CURSOR OFF
          EXIT
        ENDIF
        m_plppnv:=ALLTRIM(LOWER(m_plppnv))
        m_brmsime:=0
        m_zimplj:=" "
        m_brmsime:=LEN(m_plppnv)
        m_zimplj:=SUBSTR(m_plppnv,1,1)
        IF m_zimplj $ "1234567890_"
          LOOP
        ENDIF
        FOR w=1 TO m_brmsime
          m_zimplj:=SUBSTR(m_plppnv,w,1)
          IF m_zimplj $ "1234567890_qwertyuiopasdfghjklzxcvbnm"
            m_dobroime:="D"
          ELSE
            m_dobroime:="N"
            EXIT
          ENDIF
        NEXT
        IF m_dobroime="D"
          REPLACE field_name WITH m_plppnv
          IF m_rdppnv>0
            SKIP -m_rdppnv
          ENDIF
          SET CONFIRM OFF
          SET CURSOR OFF
          EXIT
        ENDIF
      ENDDO
      LOOP
    ELSEIF m_klppnv=2
      IF EMPTY(field_name)
        m_klppnv:=1
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      m_plppnv:=field_type
      @ 22,21 SAY "Polje:slovo-C,broj-N,datum-D,logik-L"
      @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv COLOR "R/W" PICTURE "!" ;
                                      VALID(m_plppnv $ "CcNnDdLl")
      READ
      IF LASTKEY()=27
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      REPLACE field_type WITH m_plppnv
      IF m_plppnv="D"
        REPLACE field_len WITH 8
      ELSEIF m_plppnv="L"
        REPLACE field_len WITH 1
      ENDIF
      IF m_rdppnv>0
        SKIP -m_rdppnv
      ENDIF
      SET CONFIRM OFF
      SET CURSOR OFF
      LOOP
    ELSEIF m_klppnv=3
      IF EMPTY(field_name) .OR. EMPTY(field_name) .AND. EMPTY(field_type)
        m_klppnv:=1
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ELSEIF EMPTY(field_type) .OR. field_type="D" .OR. field_type="L"
        m_klppnv:=2
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      m_plppnv:=field_len
      @ 22,24 SAY "Mesta:C<1000,N<20,uvek:D=8,L=1"
      IF field_type="C"
        @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv ;
                                      RANGE 1,999 COLOR "R/W"
        READ
      ELSEIF field_type="N"
        @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv ;
                                      RANGE 1,19 COLOR "R/W"
        READ
      ENDIF
      IF LASTKEY()=27
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      REPLACE field_len WITH m_plppnv
      IF m_rdppnv>0
        SKIP -m_rdppnv
      ENDIF
      SET CONFIRM OFF
      SET CURSOR OFF
      LOOP
    ELSEIF m_klppnv=4
      IF EMPTY(field_name) .OR. ;
         EMPTY(field_name) .AND. EMPTY(field_type) .OR. ;
         EMPTY(field_name) .AND. EMPTY(field_type) .AND. EMPTY(field_len)
        m_klppnv:=1
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ELSEIF EMPTY(field_type) .OR. ;
             EMPTY(field_type) .AND. EMPTY(field_len) .OR. ;
             field_type="C" .OR. field_type="D" .OR. field_type="L"
        m_klppnv:=2
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ELSEIF EMPTY(field_len)
        m_klppnv:=3
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      @ 22,25 SAY "Samo za N:br.mesta-2(ne>15)"
      m_plppnv:=field_dec
      DO WHILE .T.
        @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv RANGE 1,15 COLOR "R/W"
        READ
        IF LASTKEY()=27
          m_plppnv:=0
          EXIT
        ENDIF
        IF field_len-m_plppnv<2
          LOOP
        ENDIF
        EXIT
      ENDDO
      REPLACE field_dec WITH m_plppnv
      IF m_rdppnv>0
        SKIP -m_rdppnv
      ENDIF
      SET CONFIRM OFF
      SET CURSOR OFF
      LOOP
    ENDIF


  ELSEIF LASTKEY()=19
    IF m_klppnv=1
      @ 22,1 CLEAR TO 22,78
      @ 22,34 SAY "NEMA DALJE U LEVO" COLOR "RB+/B"
      INKEY (1.1)
    ELSEIF m_klppnv>1
      m_klppnv:=m_klppnv-1
    ENDIF
    LOOP

  ELSEIF LASTKEY()=4
    IF m_klppnv=4
      @ 22,1 CLEAR TO 22,78
      @ 22,34 SAY "NEMA DALJE U DESNO" COLOR "RB+/B"
      INKEY (1.1)
    ELSEIF m_klppnv<4
      m_klppnv:=m_klppnv+1
    ENDIF
    LOOP


  ELSEIF LASTKEY()=5 
    IF m_rdppnv=0
      SKIP -1
      IF BOF()
        @ 22,1 CLEAR TO 22,78
        @ 22,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
        INKEY(1.2)                 
        GO TOP
      ENDIF
      LOOP
    ENDIF
    m_rdppnv:=m_rdppnv-1
    LOOP

  ELSEIF LASTKEY()=18
    SKIP -1
    IF BOF()
      @ 22,1 CLEAR TO 22,78
      @ 22,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
      INKEY(1.2)
      GO TOP
      LOOP
    ENDIF
    SKIP -16
    IF BOF()
      GO TOP
      LOOP
    ENDIF
    LOOP

  ELSEIF LASTKEY()=24 
    m_rdppnv:=m_rdppnv+1
    SKIP m_rdppnv
    IF EOF()
      @ 22,1 CLEAR TO 22,78
      @ 22,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      SKIP -m_rdppnv
      m_rdppnv:=m_rdppnv-1
      LOOP
    ENDIF
    SKIP -m_rdppnv
    IF m_rdppnv=17
      m_rdppnv:=16
      SKIP
    ENDIF
    LOOP

  ELSEIF LASTKEY()=3
    SKIP 17
    IF EOF()  .AND. m_brslnv>17
      @ 22,1 CLEAR TO 22,78
      @ 22,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      GO BOTTOM
      SKIP -16
      LOOP
    ELSEIF EOF() .AND. m_brslnv<18
      @ 22,1 CLEAR TO 22,78
      @ 22,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      GO TOP
      LOOP
    ENDIF
    SKIP 17
    IF EOF()
      GO BOTTOM
      SKIP -16
      LOOP
    ENDIF
    SKIP -17
    LOOP

  ELSE
    @ 22,1 CLEAR TO 22,78
    @ 22,34 SAY "POGRESAN TASTER" COLOR "RB+/B"
    INKEY(1.7)
    IF m_brslnv<18
      GO TOP
    ENDIF
    LOOP
  ENDIF
ENDDO



*****************************OBRADA PODATAKA*********************************
PROCEDURE IZMPRGBZ
******************Manipulacija sa podacima izabrane baze*********************

SELECT 1

IF ! FILE("podgran.dbf")
  DO isptdrkt
ENDIF

USE podgran
INDEX ON ekst+ime TO ekstime.ntx

SEEK "DBF"

IF ! FOUND()
  CLS
  @ 0,0 TO 24,79 DOUBLE
  @ 11,17 SAY "U OVOM DIRKTORIJU NE POSTOJI NIJEDNA DATABAZA"
  @ 23,1 SAY "Pritisni bilo sta -> IZLAZ"
  INKEY(0)
  CLOSE DATABASES
  ERASE ekstime.ntx
  SET COLOR TO "GR+/B,R/G,,,"
  CLS
  @ 4,27 TO 10,51
  RETURN
ENDIF

SELECT 2
IF FILE("imebaze.dbf")
  CLOSE
  ERASE imebaze.dbf
ENDIF

p_mat2:=0
p_mat2:=ARRAY(2,4)
p_mat2[1,1] := "redbrojb"
p_mat2[1,2] := "n"
p_mat2[1,3] := 3
p_mat2[1,4] := 0
p_mat2[2,1] := "imebaze"
p_mat2[2,2] := "c"
p_mat2[2,3] := 12
p_mat2[2,4] := 0

DBCREATE("imebaze", p_mat2)
USE

USE imebaze

p_redbrbaz:=1
DO WHILE .T.
  SELECT 2
  APPEND BLANK
  REPLACE imebaze WITH A->ime, redbrojb WITH p_redbrbaz
  p_redbrbaz:=p_redbrbaz+1
  SELECT 1
  SKIP
  IF ekst # "DBF"
    SELECT 2
    EXIT
  ENDIF
ENDDO


CLS

m_2brsl:=0
m_2brsl:=RECCOUNT()

p_2brr:=1
p_2red:=7
p_2izlaz:=0
p_pokbrr:=1
p_pokred:=7
m_baza:=SPACE(12)

@ 0,0 TO 24,79 DOUBLE

@ 5,29 SAY "Red"
@ 5,33 SAY "Ime databaze"

@ 1,1 SAY "Ime direktorija: " + p_ispis +;
           " - Broj databaza: " + ALLTRIM(STR(m_2brsl))
@ 23,17 SAY "Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25)+"*Izbor:Enter*Izlaz:Esc"

GO TOP
DO WHILE .T.
  @ 6,32 TO 15,45
  @ 6,28 TO 15,32
  @ 6,32 SAY CHR(194)
  @ 15,32 SAY CHR(193)

  @ 1,63 SAY "Datum: "+DTOC(DATE())+"."

  @ p_2red,29 SAY ALLTRIM(STR(redbrojb))
  @ p_2red,33 SAY ALLTRIM(imebaze)

  SKIP
  p_2red:=p_2red+1

  IF p_2red=15 .OR. BOF() .OR. EOF()
      GO p_pokbrr
      @ p_pokred,32 SAY CHR(179) COLOR "GR+/G"
      @ p_pokred,29 SAY "   " COLOR "R/G"
      @ p_pokred,29 SAY ALLTRIM(STR(redbrojb)) COLOR "R/G"
      @ p_pokred,33 SAY imebaze COLOR "R/G"

      INKEY(0)

    IF LASTKEY()=27
      CLOSE DATABASES
      ERASE imebaze.dbf
      ERASE ekstime.ntx
      SET COLOR TO "GR+/B,R/G,,,"
      CLS
      @ 4,27 TO 10,51
      RETURN

    ELSEIF LASTKEY()=13
      m_baza:=imebaze
      DO manpodbz
      p_2red:=7
      GO p_2brr
      LOOP

    ELSEIF LASTKEY()=24 
      p_pokbrr:=p_pokbrr+1
      GO p_pokbrr
      IF EOF()
        @ 20,25 SAY "NEMA VISE LISTANJA DOLE"
        INKEY(1.2)
        @ 20,25 SAY "                       "
        p_2red:=7
        p_pokbrr:=p_pokbrr-1
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ENDIF
      IF p_pokred=p_2red-1
        p_2red:=7
        p_2brr:=p_2brr+1
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ELSEIF p_pokred<p_2red-1
        p_pokred:=p_pokred+1
        p_2red:=7
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ENDIF

    ELSEIF LASTKEY()=5 
      p_pokbrr:=p_pokbrr-1
      p_pokred:=p_pokred-1
      p_2red:=7
      IF p_pokred>7
        *
      ELSEIF p_pokred=6
        p_2brr=p_2brr-1
        p_pokred:=p_pokred+1
      ENDIF
      GO p_2brr
      IF BOF()
        @ 20,25 SAY "NEMA VISE LISTANJA GORE"
        INKEY(1.2)
        @ 20,25 SAY "                       "
        p_2brr:=p_2brr+1
        p_pokbrr:=p_pokbrr+1
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ENDIF
      @ 6,28 CLEAR TO 15,45
      LOOP

    ELSE
      @ 20,29 SAY "POGRESAN TASTER"
      INKEY(1.7)
      @ 20,29 SAY "               " 
      p_2red:=7
      GO p_2brr
      LOOP
    ENDIF
  ENDIF
ENDDO



**************************MANIPULACIJA PODACIMA***************************
PROCEDURE MANPODBZ
************Manipulacija podacima izabrane baze podataka******************

m_baza:=ALLTRIM(LOWER(m_baza)) + ".dbf"
SELECT 4
USE &m_baza
m_brslbz:=LASTREC()
CLOSE


SELECT 3
IF FILE("osob.dbf")
  CLOSE DATABASES
  ERASE osob.dbf
ENDIF

USE &m_baza
COPY TO osob STRUCTURE EXTENDED
CLOSE
USE osob
m_brsl:=RECCOUNT()

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

CLS

SELECT 4
USE &m_baza
GO TOP

SET COLOR TO "BG+/B"
@ 0,0 TO 24,79 DOUBLE COLOR "GR+/B"

SET COLOR TO "G+/B"

m_pocpolje:=1
m_taster:="D"
m_deskrj:=1

m_gdlist:=1
m_promin:=" "
m_npromin:=0
m_dpromin:=DATE()

m_pokred:=5
m_pokkol:=0
m_pkol:=1
m_pred:=0
m_pomekr:="D"
m_prvoplj:="N"
m_zadnplj:="N"

m_trnslg:=1
IF m_brslbz=0
  m_trnslg:=0
ENDIF
m_skokna:=0
m_deljskok:=0
m_oduzskok:=0
m_trnplj:=1
m_brpslnd:="N"

m_novupis:="NIJE"
m_ponprt:="NE"
m_vrsprt:="  "
m_ispF10:="PRVI"
m_kortrp:="N"


DO WHILE .T.

  @ 23,1 CLEAR TO 23,78
  IF m_ispF10="PRVI"
    @ 23,3 SAY "Korak:"+CHR(24)+"-"+CHR(25)+"*Skok:PageUp"+CHR(24)+;
               "-PageDown"+CHR(25)+"*Izmena:Enter*Izlaz:Esc*F10(F-1,2,3,4,5,6)"
  ELSEIF m_ispF10="DRUGI"
    @ 23,1 SAY "F1:Trazi_vrednost*F2:Trazi_izraz*"+;
               "F3:Opet_F1-2*F4:Skok*F5:Nov_slog*F6:Brise*F10"
  ENDIF
  SELECT 3
  GO m_pocpolje
  m_brmsuk:=0
  m_uzetoplj:=0
  m_pocmesto:=0

  IF m_taster="D" 
    DO WHILE .T.
      m_brmspl:=0
      m_brmsdc:=0
      m_uzetoplj:=m_uzetoplj+1
  
      m_brmspl:=field_len
      m_brmsdc:=field_dec

      IF m_brmspl<10
        m_brmspl:=10
      ENDIF
      
      IF field_type="C" .AND. field_len=888 .AND. field_dec=888
        m_brmsuk:=m_brmsuk+1024+1
        IF m_brmsuk>1025 
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-1024-2
          EXIT
        ENDIF
      ELSE
        m_brmsuk:=m_brmsuk+m_brmspl+1
        IF m_brmsuk>74 .AND. m_uzetoplj=1
          m_brmsuk:=m_brmsuk-1
          EXIT
        ELSEIF m_brmsuk>74 .AND. m_uzetoplj>1
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-m_brmspl-2
          EXIT
        ENDIF
      ENDIF

      SKIP

      IF EOF() .AND. m_pocpolje>1
        m_kortrp:="D"
        m_pocpolje:=m_brsl+1
        m_taster:="L"
        IF m_zadnplj="D"
          m_zadnplj:="N"
        ELSE
          m_zadnplj:="D"
        ENDIF
        m_deskrj:=2
        GO m_brsl
        m_brmsuk:=0
        m_uzetoplj:=0
        m_pocmesto:=0        
        EXIT
      ELSEIF EOF() .AND. m_pocpolje=1
        m_brmsuk:=m_brmsuk-1
        EXIT
      ENDIF
    ENDDO
  ENDIF

  IF m_taster="L" 
    DO WHILE .T.
  
       IF m_deskrj=1
        SKIP-1
      ENDIF
  
      IF m_deskrj=2
        m_deskrj:=1
      ENDIF
      IF BOF()
        m_pocpolje:=1
        EXIT
      ENDIF
  
      m_brmspl:=0
      m_brmsdc:=0
      m_uzetoplj:=m_uzetoplj+1
  
      m_brmspl:=field_len
      m_brmsdc:=field_dec
  
      IF m_brmspl<10
        m_brmspl:=10
      ENDIF
  
      IF field_type="C" .AND. field_len=888 .AND. field_dec=888
        m_brmsuk:=m_brmsuk+1024+1
        IF m_brmsuk>1025
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-1024-2
          m_pocpolje:=m_pocpolje-m_uzetoplj
          EXIT
        ENDIF
      ELSE
        m_brmsuk:=m_brmsuk+m_brmspl+1
        IF m_brmsuk>74 .AND. m_uzetoplj=1
          m_pocpolje:=m_pocpolje-m_uzetoplj
          m_bemsuk:=m_brmsuk-1
          EXIT
        ELSEIF m_brmsuk>74 .AND. m_uzetoplj>1
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-m_brmspl-2
          m_pocpolje:=m_pocpolje-m_uzetoplj
          EXIT
        ENDIF
      ENDIF
    ENDDO
  ENDIF

  IF m_taster="L" .AND. BOF()
    m_taster:="D"
    m_prvoplj:="D"
    m_brpslnd:="D"
    LOOP
  ENDIF

  IF m_brmsuk>74
    m_brmsuk:=74
  ENDIF
  m_pocmesto:=39-INT(m_brmsuk/2)


  @ 2,1 CLEAR TO 22,78
  @ 4,1 TO 22,78 COLOR "GR+/B"

  m_zpocmesto:=0
  m_brjc1:=0
  m_brmspl:=0
  m_brmsdc:=0
  m_prethisp:=0
  m_mestisp:=0
  m_redlin:=0
  m_kollin:=0
  m_brmpis:=0
  m_brmdis:=0

  m_kolpod:=0

  p_mtrime:=" "
  p_mtrime:=ARRAY(m_uzetoplj,1)
  p_mtrtip:=" "
  p_mtrtip:=ARRAY(m_uzetoplj,1)
  p_mtrplj:=0
  p_mtrplj:=ARRAY(m_uzetoplj,1)
  p_mtrpcm:=0
  p_mtrpcm:=ARRAY(m_uzetoplj,1)

  m_zpocmesto:=m_pocmesto

  GO m_pocpolje

  DO WHILE .T.
    m_brjc1:=m_brjc1+1

    m_brmspl:=field_len
    m_brmsdc:=field_dec

    IF m_brmspl<10
      m_brmspl:=10
    ENDIF

    IF m_brmspl>74
      m_brmspl:=74
    ENDIF

    m_mestisp:=m_zpocmesto+INT((m_brmspl-8)/2)
    m_kollin:=m_zpocmesto+m_brmspl+1

    IF field_type="C" .AND. field_len=888 .AND. field_dec=888
      m_brmpis:=1024
      m_brmdis:=0
    ELSE
      m_brmpis:=field_len
      m_brmdis:=field_dec
    ENDIF

    @ 2,m_mestisp SAY field_name COLOR "GR+/B"
    @ 3,m_mestisp SAY "("+ALLTRIM(STR(m_brjc1))+")"+;
                      field_type+"-"+ALLTRIM(STR(m_brmpis))+;
                      "-"+ALLTRIM(STR(m_brmdis)) COLOR "GR+/B"

    p_mtrime[m_brjc1]:=field_name
    p_mtrtip[m_brjc1]:=field_type
    p_mtrplj[m_brjc1]:=field_len

    SKIP
    IF m_brjc1=m_uzetoplj
      EXIT
    ENDIF

    FOR w=1 TO 17
      m_redlin:=4+w
      @ m_redlin,m_kollin SAY CHR(179) COLOR "GR+/B"
    NEXT
    @ 4,m_kollin SAY CHR(194) COLOR "GR+/B"
    @ 22,m_kollin SAY CHR(193) COLOR "GR+/B"

    m_zpocmesto:=m_zpocmesto+m_brmspl+1

  ENDDO


  m_kolpod:=m_pocmesto+1
  m_brjc2:=1

  DO WHILE .T.

    m_redpod:=5
    p_mtrpcm[m_brjc2]:=m_kolpod

    DO WHILE .T.
      m_imeuzmi:=" "
      IF p_mtrtip[m_brjc2]="C" .OR. p_mtrtip[m_brjc2]="L"
        m_sadrzaj:=" "
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=D->&m_imeuzmi
      ELSEIF p_mtrtip[m_brjc2]="N"
        m_sadrzaj:=0
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=D->&m_imeuzmi
      ELSEIF p_mtrtip[m_brjc2]="D"
        m_sadrzaj:=DATE()
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=D->&m_imeuzmi
      ENDIF  
       
      IF p_mtrplj[m_brjc2]>74
        @ m_redpod,m_kolpod SAY m_sadrzaj PICTURE "@S74" COLOR "BG+/B"
      ELSEIF p_mtrplj[m_brjc2]<75
        @ m_redpod,m_kolpod SAY m_sadrzaj COLOR "BG+/B"
      ENDIF

      SELECT 4
      SKIP
      IF EOF()
        GO BOTTOM
        EXIT
      ENDIF 
      SELECT 3

      m_redpod:=m_redpod+1

      IF m_redpod=22
        EXIT
      ENDIF
    ENDDO

    SELECT 4
    SKIP-(m_redpod-5)
    SELECT 3

    IF m_brjc2=m_uzetoplj
      EXIT
    ENDIF

    IF p_mtrplj[m_brjc2]<10
      p_mtrplj[m_brjc2]:=10
    ENDIF

    IF p_mtrplj[m_brjc2]>74
      p_mtrplj[m_brjc]:=74
    ENDIF

    m_kolpod:=m_kolpod+p_mtrplj[m_brjc2]+1

    m_brjc2:=m_brjc2+1

  ENDDO


  IF m_taster="D" .AND. m_pomekr="D" 
    IF m_prvoplj="N" .AND. m_zadnplj="N"
      m_pkol:=1
    ELSEIF m_prvoplj="D" 
      m_pkol:=m_uzetoplj
      m_prvoplj:="N"
    ENDIF
    m_pomekr:="N"
  ELSEIF m_taster="L" .AND. m_pomekr="D"
    IF m_zadnplj="N"
      m_pkol:=m_uzetoplj
    ELSEIF m_zadnplj="D" 
      m_pkol:=1
      m_zadnplj:="N"
    ENDIF
    m_pomekr:="N"
  ENDIF

  SELECT 4
  IF m_pred>0
    SKIP m_pred
  ENDIF
  m_imeuzmi:=" "
  IF p_mtrtip[m_pkol]="C" .OR. p_mtrtip[m_pkol]="L"
    m_pokpolje:=" "
    m_imeuzmi:=p_mtrime[m_pkol]
    m_pokpolje:=&m_imeuzmi
  ELSEIF p_mtrtip[m_pkol]="N"
    m_pokpolje:=0
    m_imeuzmi:=p_mtrime[m_pkol]
    m_pokpolje:=&m_imeuzmi
  ELSEIF p_mtrtip[m_pkol]="D"
    m_pokpolje:=DATE()
    m_imeuzmi:=p_mtrime[m_pkol]
    m_pokpolje:=&m_imeuzmi
  ENDIF  
  IF m_pred>0
    SKIP -m_pred
  ENDIF
  SELECT 3
  m_pokkol:=p_mtrpcm[m_pkol]
  m_pokred:=5+m_pred

  IF p_mtrplj[m_pkol]>74
    @ m_pokred,m_pokkol SAY m_pokpolje PICTURE "@S74" COLOR "B/W"
  ELSEIF p_mtrplj[m_pkol]<75
    @ m_pokred,m_pokkol SAY m_pokpolje COLOR "B/W"
  ENDIF

  IF m_brpslnd="D"
    m_brpslnd:="N"
    m_trnplj:=m_pkol
  ENDIF

  IF m_kortrp="D"
    m_trnplj:=m_brsl-m_uzetoplj+m_pkol
  ENDIF

  @ 1,1 CLEAR TO 1,78
  @ 1,1 SAY "BAZA:"+ALLTRIM(UPPER(m_baza))+;
            " * SLOG:"+ALLTRIM(STR(m_trnslg))+"/"+ALLTRIM(STR(m_brslbz))+;
            " * POLJE:"+ALLTRIM(STR(m_trnplj))+"/"+ALLTRIM(STR(m_brsl))

  IF m_novupis="NIJE"
    INKEY(0)
  ENDIF

  IF LASTKEY()=27
    CLOSE DATABASES
    ERASE osob.dbf
    SELECT 4
    ERASE gdlistpg.ntx
    SELECT 2
    USE imebaze
    SET COLOR TO "GR+/B,R/G,,,"
    CLS
    @ 0,0 TO 24,79 DOUBLE
    @ 5,29 SAY "Red"
    @ 5,33 SAY "Ime databaze"
    @ 1,1 SAY "Ime direktorija: " + p_ispis +;
               " - Broj databaza: " + ALLTRIM(STR(m_2brsl))
    @ 23,17 SAY "Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25)+;
                "*Izbor:Enter*Izlaz:Esc"
    RETURN


  ELSEIF LASTKEY()=13
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    SELECT 4
    SET CONFIRM ON
    SET CURSOR ON
    IF p_mtrplj[m_pkol]>74
      @ m_pokred,m_pokkol GET m_pokpolje PICTURE "@S74" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<75
      @ m_pokred,m_pokkol GET m_pokpolje COLOR "R/W"
    ENDIF
    READ
    SKIP m_pred
    REPLACE &m_imeuzmi WITH m_pokpolje
    SKIP -m_pred
    SET CONFIRM OFF
    SET CURSOR OFF
    LOOP

  ELSEIF LASTKEY()=28
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    SET CONFIRM ON
    SET CURSOR ON
    @ 23,1 CLEAR TO 23,78
    m_kriterij:=" "
    @ 23,1 SAY "Kriterij (>,<,=):" GET m_kriterij;
           VALID (m_kriterij $ "><=") COLOR "R/W"
    READ
    IF LASTKEY()=27
      SET CONFIRM OFF
      SET CURSOR OFF
      LOOP
    ENDIF  
    SELECT 4
    APPEND BLANK
    m_imeuzmi:=" "
    IF p_mtrtip[m_pkol]="C" .OR. p_mtrtip[m_pkol]="L"
      m_vrednost:=" "
      m_imeuzmi:=p_mtrime[m_pkol]
      m_vrednost:=&m_imeuzmi
    ELSEIF p_mtrtip[m_pkol]="N"
      m_vrednost:=0
      m_imeuzmi:=p_mtrime[m_pkol]
      m_vrednost:=&m_imeuzmi
    ELSEIF p_mtrtip[m_pkol]="D"
      m_vrednost:=DATE()
      m_imeuzmi:=p_mtrime[m_pkol]
      m_vrednost:=&m_imeuzmi
    ENDIF  
    IF p_mtrplj[m_pkol]>42
      @ 23,20 SAY " * Vrednost:" GET m_vrednost PICTURE "@S42" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<43
      @ 23,20 SAY " * Vrednost:" GET m_vrednost COLOR "R/W"
    ENDIF
    READ
    SET CONFIRM OFF
    SET CURSOR OFF
    DELETE
    PACK
    m_trnslg:=1
    m_pred:=0
    IF LASTKEY()=27
      GO TOP
      LOOP
    ENDIF  
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
    GO TOP
    m_brtraz:=1
    IF m_kriterij = "="
      DO WHILE .T.
        IF m_vrednost=&m_imeuzmi .OR. EOF()
          m_trnslg:=m_brtraz
          EXIT
        ENDIF
        SKIP
        m_brtraz:=m_brtraz+1
      ENDDO
    ELSEIF m_kriterij = ">"
      DO WHILE .T.
        IF m_vrednost<&m_imeuzmi .OR. EOF()
          m_trnslg:=m_brtraz
          EXIT
        ENDIF
        m_brtraz:=m_brtraz+1
        SKIP
      ENDDO
    ELSEIF m_kriterij = "<"
      DO WHILE .T.
        IF m_vrednost>&m_imeuzmi .OR. EOF()
          m_trnslg:=m_brtraz
          EXIT
        ENDIF    
        m_brtraz:=m_brtraz+1
        SKIP
      ENDDO
    ENDIF
    IF EOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,31 SAY "Pretraga neuspesna"
      INKEY(1.1)
      GO TOP
      LOOP
    ENDIF
    m_ponprt:="DA"
    m_vrsprt:="F1"
    IF m_brslbz>17
      IF m_trnslg<8
        GO TOP
        m_pred:=m_trnslg-1
      ELSEIF m_brslbz-m_trnslg<8
        GO BOTTOM
        SKIP -16
        m_pred:=17-(m_brslbz-m_trnslg+1)
      ELSE
        GO TOP
        SKIP m_trnslg-9
        m_pred:=8
      ENDIF
    ELSEIF m_brslbz<18
      GO TOP
      m_pred:=m_trnslg-1
    ENDIF
    LOOP


  ELSEIF LASTKEY()=-1
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    IF p_mtrtip[m_pkol] # "C"
      LOOP
    ENDIF
    SELECT 4
    APPEND BLANK
    m_imeuzmi:=" "
    m_prtizraz:=" "
    m_imeuzmi:=p_mtrime[m_pkol]
    m_prtizraz:=&m_imeuzmi
    DELETE
    PACK
    m_trnslg:=1
    m_pred:=0
    GO TOP
    SET CONFIRM ON
    SET CURSOR ON
    @ 23,1 CLEAR TO 23,78
    IF p_mtrplj[m_pkol]>62
      @ 23,1 SAY "Unesite izraz:" GET m_prtizraz PICTURE "@S62" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<63
      @ 23,1 SAY "Unesite izraz:" GET m_prtizraz COLOR "R/W"
    ENDIF
    READ
    SET CONFIRM OFF
    SET CURSOR OFF
    IF LASTKEY()=27
      LOOP
    ENDIF  
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
    m_prebroj:=0
    DO WHILE .T.
      m_prebroj:=m_prebroj+1
      m_brptpl:=LEN(ALLTRIM(&m_imeuzmi))
      m_brptzn:=LEN(ALLTRIM(m_prtizraz))
      IF m_brptpl<m_brptpl
        SKIP
        LOOP
      ENDIF
      m_nasobre:="N"
      m_2uporedj:=" "
      m_2uporedj:=UPPER(ALLTRIM(m_prtizraz))
      FOR a=1 TO m_brptpl+1-m_brptzn
        m_1uporedj:=SPACE(m_brptzn)
        m_1uporedj:=UPPER(SUBSTR(&m_imeuzmi,a,m_brptzn))
        IF m_1uporedj = m_2uporedj
          m_nasobre:="D"
          EXIT
        ENDIF
      NEXT
      IF m_nasobre="D"
        EXIT
      ENDIF
      SKIP
      IF EOF()
        EXIT
      ENDIF
    ENDDO
    IF EOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,31 SAY "Pretraga neuspesna"
      INKEY(1.6)
      @ 23,1 CLEAR TO 23,78
      GO TOP
      LOOP
    ENDIF
    m_ponprt:="DA"
    m_vrsprt:="F2"
    m_trnslg:=m_prebroj
    IF m_brslbz>17
      IF m_trnslg<9
        GO TOP
        m_pred:=m_trnslg-1
      ELSEIF m_brslbz-m_trnslg<8
        GO BOTTOM
        SKIP -16
        m_pred:=17-(m_brslbz-m_trnslg+1)
      ELSE
        GO TOP
        SKIP m_trnslg-9
        m_pred:=8
      ENDIF
    ELSEIF m_brslbz<18
      GO TOP
      m_pred:=m_trnslg-1
    ENDIF
    LOOP


  ELSEIF LASTKEY()=-2
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    IF m_ponprt="NE"
      @ 23,1 CLEAR TO 23,78
      @ 23,25 SAY "Unesite kriterijum pretrage"
      INKEY(1.6)
      LOOP
    ENDIF
    SELECT 4
    GO TOP
    SKIP m_trnslg
    m_trnslg:=m_trnslg+1

    IF m_vrsprt="F1"
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
      IF m_kriterij = "="
        DO WHILE .T.
          IF m_vrednost=&m_imeuzmi .OR. EOF()
            EXIT
          ENDIF
          SKIP
          m_trnslg:=m_trnslg+1
        ENDDO
      ELSEIF m_kriterij = ">"
        DO WHILE .T.
          IF m_vrednost<&m_imeuzmi .OR. EOF()
            EXIT
          ENDIF
          SKIP
          m_trnslg:=m_trnslg+1
        ENDDO
      ELSEIF m_kriterij = "<"
        DO WHILE .T.
          IF m_vrednost>&m_imeuzmi .OR. EOF()
            EXIT
          ENDIF    
          SKIP
          m_trnslg:=m_trnslg+1
        ENDDO
      ENDIF
      IF EOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,33 SAY "Nema podataka"
        INKEY(1.1)
        m_trnslg:=1
        m_pred:=0
        GO TOP
        LOOP
      ENDIF
      IF m_brslbz>17
        IF m_trnslg<9
          GO TOP
          m_pred:=m_trnslg-1
        ELSEIF m_brslbz-m_trnslg<8
          GO BOTTOM
          SKIP -16
          m_pred:=17-(m_brslbz-m_trnslg+1)
        ELSE
          GO TOP
          SKIP m_trnslg-9
          m_pred:=8
        ENDIF
      ELSEIF m_brslbz<18
        GO TOP
        m_pred:=m_trnslg-1
      ENDIF
      LOOP

    ELSEIF m_vrsprt="F2"
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
      DO WHILE .T.
        m_prebroj:=m_prebroj+1
        m_brptpl:=LEN(ALLTRIM(&m_imeuzmi))
        m_brptzn:=LEN(ALLTRIM(m_prtizraz))
        IF m_brptpl<m_brptpl
          SKIP
          LOOP
        ENDIF
        m_nasobre:="N"
        m_2uporedj:=" "
        m_2uporedj:=UPPER(ALLTRIM(m_prtizraz))
        FOR a=1 TO m_brptpl+1-m_brptzn
          m_1uporedj:=SPACE(m_brptzn)
          m_1uporedj:=UPPER(SUBSTR(&m_imeuzmi,a,m_brptzn))
          IF m_1uporedj = m_2uporedj
            m_nasobre:="D"
            EXIT
          ENDIF
        NEXT
        IF m_nasobre="D"
          EXIT
        ENDIF
        SKIP
        IF EOF()
          EXIT
        ENDIF
      ENDDO
      IF EOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,33 SAY "Nema podataka"
        INKEY(1.6)
        m_trnslg:=1
        m_pred:=0
        GO TOP
        LOOP
      ENDIF
      m_trnslg:=m_prebroj
      IF m_brslbz>17
        IF m_trnslg<8
          GO TOP
          m_pred:=m_trnslg-1
        ELSEIF m_brslbz-m_trnslg<8
          GO BOTTOM
          SKIP -16
          m_pred:=17-(m_brslbz-m_trnslg+1)
        ELSE
          GO TOP
          SKIP m_trnslg-9
          m_pred:=8
        ENDIF
      ELSEIF m_brslbz<18
        GO TOP
        m_pred:=m_trnslg-1
      ENDIF
    ENDIF
    LOOP


  ELSEIF LASTKEY()=-3
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    SET CONFIRM ON
    SET CURSOR ON
    DO WHILE .T.
      @ 23,1 CLEAR TO 23,78
      @ 23,1 SAY "Unesite broj sloga, ne veci od: "
      m_skokna:=m_brslbz
      @ 23,33 GET m_skokna COLOR "R/W"
      READ
      IF m_skokna>0 .AND. m_skokna<m_brslbz+1
        m_trnslg:=m_skokna
        m_skokna:=m_skokna-1
        EXIT
      ENDIF
    ENDDO
    SET CONFIRM OFF
    SET CURSOR OFF
    IF LASTKEY()=27
      LOOP
    ENDIF
    SELECT 4
    IF m_brslbz>17
      IF m_skokna<8
        GO TOP
        m_pred:=m_skokna
      ELSEIF m_brslbz-m_skokna<9
        GO BOTTOM
        SKIP -16
        m_pred:=17-(m_brslbz-m_skokna)
      ELSE
        GO TOP
        SKIP m_skokna-8
        m_pred:=8
      ENDIF
    ELSEIF m_brslbz<18
      GO TOP
      m_pred:=m_skokna
    ENDIF
    LOOP


  ELSEIF LASTKEY()=-4
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 4
    IF m_novupis="NIJE"
      m_novupis:="JESTE"
      APPEND BLANK
      IF m_brslbz>16
        SKIP-16
        m_pred:=16
        m_brslbz:=m_brslbz+1
      ELSEIF m_brslbz<17
        SKIP-m_brslbz
        m_pred:=m_brslbz
        m_brslbz:=m_brslbz+1
      ENDIF
      m_trnslg:=m_brslbz
      LOOP
    ENDIF
    m_novupis:="NIJE"
    SET CONFIRM ON
    SET CURSOR ON
    IF p_mtrplj[m_pkol]>74
      @ m_pokred,m_pokkol GET m_pokpolje PICTURE "@S74" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<75
      @ m_pokred,m_pokkol GET m_pokpolje COLOR "R/W"
    ENDIF
    READ
    IF EMPTY(m_pokpolje)
      IF m_brslbz=1
        m_brslbz:=0
        m_trnslg:=m_brslbz
        DELETE
        PACK
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      SKIP m_pred
      DELETE
      PACK
      SKIP -m_pred
      m_brslbz:=m_brslbz-1
      GO BOTTOM
      IF m_brslbz>17
        SKIP-16
        m_pred:=16
      ELSEIF m_brslbz<18
        GO TOP
        m_pred:=m_brslbz-1
      ENDIF
      m_trnslg:=m_brslbz
      SET CONFIRM OFF
      SET CURSOR OFF
      LOOP
    ENDIF
    SKIP m_pred
    REPLACE &m_imeuzmi WITH m_pokpolje
    SKIP -m_pred
    SET CONFIRM OFF
    SET CURSOR OFF
    LOOP

  ELSEIF LASTKEY()=-5
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    @ 23,1 CLEAR TO 23,78
    @ 23,17 SAY "Potvrdite brisanje obelezenog sloga (D/N):"
    m_brisanje:="N"
    @ 23,60 GET m_brisanje PICTURE "!" VALID(m_brisanje $ "DdNn") COLOR "R/W"
    READ
    IF m_brisanje="N"
    ELSEIF m_brisanje="D"
      SELECT 4
      SKIP m_pred
      DELETE
      PACK
      IF m_trnslg=m_brslbz
        m_trnslg:=m_brslbz-1
        IF m_brslbz>17
          SKIP m_trnslg-(m_pred+1)
          m_pred:=16
        ELSEIF m_brslbz<18
          GO TOP
          m_pred:=m_brslbz-2
        ENDIF
      ELSEIF m_trnslg<m_brslbz
        SKIP m_trnslg-(m_pred+1)
      ENDIF
      m_brslbz:=m_brslbz-1
    ENDIF
    LOOP

  ELSEIF LASTKEY()=-9
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_ispF10="PRVI"
      m_ispF10:="DRUGI"
    ELSEIF m_ispF10="DRUGI"
      m_ispF10:="PRVI"
    ENDIF
    IF m_brslbz<18
      SELECT 4
      GO TOP
    ENDIF
    LOOP


  ELSEIF LASTKEY()=49
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    IF m_gdlist#12
      m_gdlist:=12
      IF p_mtrtip[1]="N"
        m_npromin:=p_mtrime[1]
        INDEX ON STR(&m_npromin) TO gdlistpg.ntx
      ELSEIF p_mtrtip[1]="D"
        m_dpromin:=p_mtrime[1]
        INDEX ON DTOS(&m_dpromin) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[1]
        INDEX ON &m_promin TO gdlistpg.ntx
      ENDIF
      @ 23,34 SAY "                    "
      LOOP
    ELSEIF m_gdlist=12
      m_gdlist:=11
      IF p_mtrtip[1]="N"
        m_npromin:=p_mtrime[1]
        INDEX ON DESCEND(STR(&m_npromin)) TO gdlistpg.ntx
      ELSEIF p_mtrtip[1]="D"
        m_dpromin:=p_mtrime[1]
        INDEX ON DESCEND(DTOS(&m_dpromin)) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[1]
        INDEX ON DESCEND(&m_promin) TO gdlistpg.ntx
      ENDIF
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

  ELSEIF LASTKEY()=50
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<2
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    IF m_gdlist#22
      m_gdlist:=22
      IF p_mtrtip[2]="N"
        m_npromin:=p_mtrime[2]
        INDEX ON STR(&m_npromin) TO gdlistpg.ntx
      ELSEIF p_mtrtip[2]="D"
        m_dpromin:=p_mtrime[2]
        INDEX ON DTOS(&m_dpromin) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[2]
        INDEX ON &m_promin TO gdlistpg.ntx
      ENDIF
      @ 23,34 SAY "                    "
      LOOP
    ELSEIF m_gdlist=22
      m_gdlist:=21
      IF p_mtrtip[2]="N"
        m_npromin:=p_mtrime[2]
        INDEX ON DESCEND(STR(&m_npromin)) TO gdlistpg.ntx
      ELSEIF p_mtrtip[2]="D"
        m_dpromin:=p_mtrime[2]
        INDEX ON DESCEND(DTOS(&m_dpromin)) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[2]
        INDEX ON DESCEND(&m_promin) TO gdlistpg.ntx
      ENDIF
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

  ELSEIF LASTKEY()=51
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<3
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    IF m_gdlist#32
      m_gdlist:=32
      IF p_mtrtip[3]="N"
        m_npromin:=p_mtrime[3]
        INDEX ON STR(&m_npromin) TO gdlistpg.ntx
      ELSEIF p_mtrtip[3]="D"
        m_dpromin:=p_mtrime[3]
        INDEX ON DTOS(&m_dpromin) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[3]
        INDEX ON &m_promin TO gdlistpg.ntx
      ENDIF
      @ 23,34 SAY "                    "
      LOOP
    ELSEIF m_gdlist=32
      m_gdlist:=31
      IF p_mtrtip[3]="N"
        m_npromin:=p_mtrime[3]
        INDEX ON DESCEND(STR(&m_npromin)) TO gdlistpg.ntx
      ELSEIF p_mtrtip[3]="D"
        m_dpromin:=p_mtrime[3]
        INDEX ON DESCEND(DTOS(&m_dpromin)) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[3]
        INDEX ON DESCEND(&m_promin) TO gdlistpg.ntx
      ENDIF
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

  ELSEIF LASTKEY()=52
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<4
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    IF m_gdlist#42
      m_gdlist:=42
      IF p_mtrtip[4]="N"
        m_npromin:=p_mtrime[4]
        INDEX ON STR(&m_npromin) TO gdlistpg.ntx
      ELSEIF p_mtrtip[4]="D"
        m_dpromin:=p_mtrime[4]
        INDEX ON DTOS(&m_dpromin) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[4]
        INDEX ON &m_promin TO gdlistpg.ntx
      ENDIF
      @ 23,34 SAY "                    "
      LOOP
    ELSEIF m_gdlist=42
      m_gdlist:=41
      IF p_mtrtip[4]="N"
        m_npromin:=p_mtrime[4]
        INDEX ON DESCEND(STR(&m_npromin)) TO gdlistpg.ntx
      ELSEIF p_mtrtip[4]="D"
        m_dpromin:=p_mtrime[4]
        INDEX ON DESCEND(DTOS(&m_dpromin)) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[4]
        INDEX ON DESCEND(&m_promin) TO gdlistpg.ntx
      ENDIF
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

    ELSEIF LASTKEY()=53
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<5
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    IF m_gdlist#52
      m_gdlist:=52
      IF p_mtrtip[5]="N"
        m_npromin:=p_mtrime[5]
        INDEX ON STR(&m_npromin) TO gdlistpg.ntx
      ELSEIF p_mtrtip[5]="D"
        m_dpromin:=p_mtrime[5]
        INDEX ON DTOS(&m_dpromin) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[5]
        INDEX ON &m_promin TO gdlistpg.ntx
      ENDIF
      @ 23,34 SAY "                    "
      LOOP
    ELSEIF m_gdlist=52
      m_gdlist:=51
      IF p_mtrtip[5]="N"
        m_npromin:=p_mtrime[5]
        INDEX ON DESCEND(STR(&m_npromin)) TO gdlistpg.ntx
      ELSEIF p_mtrtip[5]="D"
        m_dpromin:=p_mtrime[5]
        INDEX ON DESCEND(DTOS(&m_dpromin)) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[5]
        INDEX ON DESCEND(&m_promin) TO gdlistpg.ntx
      ENDIF
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

    ELSEIF LASTKEY()=54
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<6
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    IF m_gdlist#62
      m_gdlist:=62
      IF p_mtrtip[6]="N"
        m_npromin:=p_mtrime[6]
        INDEX ON STR(&m_npromin) TO gdlistpg.ntx
      ELSEIF p_mtrtip[6]="D"
        m_dpromin:=p_mtrime[6]
        INDEX ON DTOS(&m_dpromin) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[6]
        INDEX ON &m_promin TO gdlistpg.ntx
      ENDIF
      @ 23,34 SAY "                    "
      LOOP
    ELSEIF m_gdlist=62
      m_gdlist:=61
      IF p_mtrtip[6]="N"
        m_npromin:=p_mtrime[6]
        INDEX ON DESCEND(STR(&m_npromin)) TO gdlistpg.ntx
      ELSEIF p_mtrtip[6]="D"
        m_dpromin:=p_mtrime[6]
        INDEX ON DESCEND(DTOS(&m_dpromin)) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[6]
        INDEX ON DESCEND(&m_promin) TO gdlistpg.ntx
      ENDIF
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

    ELSEIF LASTKEY()=55
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKE(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<7
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    IF m_gdlist#72
      m_gdlist:=72
      IF p_mtrtip[7]="N"
        m_npromin:=p_mtrime[7]
        INDEX ON STR(&m_npromin) TO gdlistpg.ntx
      ELSEIF p_mtrtip[7]="D"
        m_dpromin:=p_mtrime[7]
        INDEX ON DTOS(&m_dpromin) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[7]
        INDEX ON &m_promin TO gdlistpg.ntx
      ENDIF
      @ 23,34 SAY "                    "
      LOOP
    ELSEIF m_gdlist=72
      m_gdlist:=71
      IF p_mtrtip[7]="N"
        m_npromin:=p_mtrime[7]
        INDEX ON DESCEND(STR(&m_npromin)) TO gdlistpg.ntx
      ELSEIF p_mtrtip[7]="D"
        m_dpromin:=p_mtrime[7]
        INDEX ON DESCEND(DTOS(&m_dpromin)) TO gdlistpg.ntx
      ELSE
        m_promin:=p_mtrime[7]
        INDEX ON DESCEND(&m_promin) TO gdlistpg.ntx
      ENDIF
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF


  ELSEIF LASTKEY()=19
    m_gdlist:=1
    m_ponprt="NE"
    m_zadnplj:="N"
    IF m_taster="L" .AND. m_pkol#1
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_pkol=1
      m_taster:="L"
      m_kortrp:="N"
      IF m_pocpolje=1
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE U LEVO" COLOR "RB+/B"
        INKEY (1.1)
        @ 23,34 SAY "                 "
        m_prodji="D"
        LOOP
      ELSEIF m_pocpolje>1
        m_pomekr:="D"
        m_trnplj:=m_trnplj-1
        LOOP
      ENDIF
    ENDIF
    m_pkol:=m_pkol-1
    m_trnplj:=m_trnplj-1
    LOOP

  ELSEIF LASTKEY()=4
    m_gdlist:=1
    m_taster:="D"
    m_prvoplj:="N"
    m_ponprt="NE"
    IF m_pkol=m_uzetoplj
      IF m_pocpolje+m_uzetoplj=m_brsl+1
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE U DESNO" COLOR "RB+/B"
        INKEY (1.1)
        @ 23,34 SAY "                  "
        LOOP
      ELSEIF m_pocpolje+m_uzetoplj<m_brsl+1
        m_pomekr:="D"
        m_pocpolje:=m_pocpolje+m_uzetoplj
        m_trnplj:=m_trnplj+1
        LOOP
      ENDIF
    ENDIF
    m_pkol:=m_pkol+1
    m_trnplj:=m_trnplj+1
    LOOP


  ELSEIF LASTKEY()=5 
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_pred=0
      SELECT 4
      SKIP -1
      IF BOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
        INKEY(1.2)                 
        @ 23,34 SAY "                  " 
        GO TOP
        LOOP
      ENDIF
      m_trnslg:=m_trnslg-1
      LOOP
    ENDIF
    m_pred:=m_pred-1
    m_trnslg:=m_trnslg-1
    LOOP

  ELSEIF LASTKEY()=18
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 4
    SKIP -1
    IF BOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      GO TOP
      LOOP
    ENDIF
    SKIP -16
    IF BOF()
      GO TOP
      m_trnslg:=m_pred+1
      LOOP
    ENDIF
    m_trnslg:=m_trnslg-17
    LOOP

  ELSEIF LASTKEY()=24 
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    m_pred:=m_pred+1
    SELECT 4
    SKIP m_pred
    IF EOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      SKIP -m_pred
      m_pred:=m_pred-1
      LOOP
    ENDIF
    SKIP -m_pred
    IF m_pred=17
      m_pred:=16
      SKIP
    ENDIF
    m_trnslg:=m_trnslg+1
    LOOP

  ELSEIF LASTKEY()=3
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 4
    SKIP 17
    IF EOF()  .AND. m_brslbz>17
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      GO BOTTOM
      SKIP -16
      LOOP
    ELSEIF EOF() .AND. m_brslbz<18
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      GO TOP
      LOOP
    ENDIF
    SKIP 17
    IF EOF()
      GO BOTTOM
      SKIP -16
      SELECT 3
      m_trnslg:=m_brslbz-(16-m_pred)
      LOOP
    ENDIF
    SKIP -17
    m_trnslg:=m_trnslg+17
    LOOP

  ELSE
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    @ 23,1 CLEAR TO 23,78
    @ 23,34 SAY "POGRESAN TASTER" COLOR "RB+/B"
    INKEY(1.7)
    @ 23,34 SAY "               " 
    IF m_brslbz<18
      SELECT 4
      GO TOP
    ENDIF
    LOOP
  ENDIF

ENDDO



