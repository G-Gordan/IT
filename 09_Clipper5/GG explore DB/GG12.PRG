
**********************************************************************
*****************************GLAVNI MENI ZA RAD***********************
**********************************************************************

SET CURSOR OFF
SET SCOREBOARD OFF

*****Registruje vreme na ulasku radi racunanja koriscenja programa****
SET DATE GERMAN
p_pocdan:=SPACE(8)
p_pocvrem:=" "
p_pocdan:=DATE()
p_pocvrem:=TIME()
**********************************************************************

m_upisnv:="N"

***Javne (vidljive) promenljive***
PUBLIC m_br, p_slovniz, p_ispis, p_2brr, p_2red, p_2izlaz, p_pokbrr,;
       p_pokred, m_upisnv, p_redbrbaz, m_22brsl, m_imbzpt, m_suvabz


**************Ime tekuceg direktorijuma**************

p_imeput:=SPACE(100)
p_brznakniz:=0
p_brskida:=0
p_slovo:=SPACE(1)
p_slovniz:=SPACE(1)
p_ispis:=SPACE(1)
*****Formiranje imena diraktorija-grane*****
p_imeput:=CURDIR()
p_imeput:=ALLTRIM(p_imeput)
p_brznakniz:=LEN(p_imeput)
p_mestoskid:=0
p_brskida:=0

DO WHILE .T.
 *Odredjuje mesto sa koga se skida slovo*
 p_mestoskid:=p_brznakniz-p_brskida
 *Vadi slovo iz niza*
 p_slovo:=SUBSTR(p_imeput,p_mestoskid,1)
 *Do pocetka ispisa imena*
 IF p_slovo="\" .OR. p_brznakniz=p_brskida+1
  EXIT
 ENDIF
 p_slovniz:=p_slovo+p_slovniz
 p_brskida:=p_brskida+1
 *Ako nista nije upisano*
 IF p_slovniz=" "
  p_ispis:="NEPOZNAT"
  EXIT
 ENDIF
ENDDO

IF p_brskida#0
 p_ispis:=UPPER(ALLTRIM(p_slovniz))
ENDIF


************ISPITIVANJE FAJLOVA TEKUCEG DIREKTORIJA************

DO isptdrkt

*****************POSTAVKA I RAD GLAVNOG MENIJA********************
SET COLOR TO "GR+/B,R/G,,,"
CLS
SET WRAP ON
SET MESSAGE TO 23 CENTER

***Promenljive za racunenje vremena***

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

***Glavni upitni meni***
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


********Registruje vreme na izlasku*************
p_krjdan:=DATE()
p_krjvrem:=TIME()
*********Ispisuje pocetno i krajnje vreme**********
CLS
@ 7,23 SAY "Pocetno vreme: "+DTOC(p_pocdan)+" - "+p_pocvrem
@ 8,23 SAY "Krajnje vreme: "+DTOC(p_krjdan)+" - "+p_krjvrem
************Racuna razliku vremena*************
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

*******Ispisuje razliku vremena******
@ 12,10 SAY "Program ste koristili: "+p_danz+" dana, - "+;
           p_satz+" sati, "+p_minz+" minuta i "+p_secz+" sekundi !"
INKEY(5)
**************************************

CLOSE DATABASES
ERASE podgran.dbf
ERASE imebaze.dbf
ERASE osob.dbf
ERASE osobx.dbf
ERASE imeplprt.dbf
ERASE osobpret.dbf
ERASE bzzavred.dbf
ERASE bzzapret.dbf
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

***Ubacivanje podataka o direktorijumu u matricu***
matr:=DIRECTORY()

ar1:=1
red:=4
m_prov:=SPACE(4)
AADD(matr,"KRAJ")

***Odredjuje redni broj (mesto) elementa "KRAJ", broj fajlova je m_br-1***
m_br:=ASCAN(matr,"KRAJ")

*************Upis podataka o direktorijumu iz matrice u bazu***************

***Formiranje baze koja prihvata podatke o dirktorijumu iz matrice***

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


USE podgran

DO WHILE .T.

 IF m_br=ar1
  EXIT
 ENDIF

 **Preskakanje baze IMEBAZE.DBF**
 IF matr[ar1,1]="IMEBAZE.DBF"
   ar1:=ar1+1
   LOOP
 ENDIF
 ***Razdavajanje imena fajla od ekstenzije***

 *Postavka promenljivih*
 p_imexfj:=SPACE(12)
 p_jedslo:=SPACE(1)
 p_brief:=1
 p_imefj:=SPACE(12)
 p_ekstfj:=SPACE(3)

 *Obrada*
 p_imexfj:=matr[ar1,1]
 **Uzimanje ekstenzije**
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

 ***Upis podataka iz matrice u databazu***
 APPEND BLANK
 REPLACE redbr WITH ar1, ime WITH p_imefj, ekst WITH p_ekstfj,;
         velicina WITH matr[ar1,2], datum WITH matr[ar1,3],;
         vreme WITH matr[ar1,4],;
         a WITH matr[ar1,5]
 
 ar1:=ar1+1

***Obelezavanje obradjenih procenata***
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

***Omogucavanje prekida rada i izlaska iz procedure***
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

*************************Ispisivanje na ekranu*******************

CLEAR
SET DATE GERMAN
SET CONFIRM ON
SET CURSOR OFF
SET COLOR TO "GR+/B"
CLS

SELECT 1
USE podgran

*****************Kretanje po ekranu******************

********************Zaglavlje*****************
SET COLOR TO "BG+/B"
***Okvir***
@ 0,0 TO 24,79 DOUBLE
@ 4,3 TO 22,76
**Poruke**
@ 1,70 SAY "Izlaz-Esc"
@ 2,1 SAY "Ime direktojrija:" + p_ispis + " - Broj fajlova:" + ;
           ALLTRIM(STR(m_br-1))
@ 2,52 SAY "Broj u zaglavlju-> REDOSLED"
@ 23,1 SAY "Skok:PAGE UP-" + CHR(24) + " PAGE DOWN-" + CHR(25)
@ 23,57 SAY "Listanje:GORE-" + CHR(24) + " DOLE-" + CHR(25)

**Zaglavlje**
SET COLOR TO "GR+/B"

@ 3,4 SAY "RED"
@ 3,8 SAY "1-Red Br"
@ 3,19 SAY "2-Ime"
@ 3,30 SAY "3-Ekst"
@ 3,38 SAY "4-Bajta"
@ 3,48 SAY "5-Datum"
@ 3,58 SAY "6-Vreme"
@ 3,68 SAY "7-Atrib"
************Ispis podataka***********
p_red:=5
p_izlaz:=0
p_gdlist:=1
p_redbro:=1

DO WHILE .T.

******* Ispis - kretanje ********
***Ispis uzduzne linije ***
  @ 4,3 TO 22,7 COLOR "BG+/B"
  @ 4,7 SAY CHR(194) COLOR "BG+/B"
  @ 22,7 SAY CHR(193) COLOR "BG+/B"
***Ispis podataka***
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

*****Ispis za ceo ekran do kraja baze*****
**Ako baza (DIR) ima vise od 17 fajlove**
  IF EOF() .AND. p_red<22 .AND. m_br>17
    p_red:=5
    GO BOTTOM
    p_redbro:=m_br-17
    SKIP -16
    @ 5,4 CLEAR TO 21,74
    LOOP
  ENDIF

*******Ceka da se pritisne taster*******
  IF p_red=22 .OR. BOF() .OR. EOF()
    IF p_izlaz=0

********ISPISUJE: dan u nedelji, datum i vreme - ceka taster*******

********Postavka********
      SET DATE GERMAN
*******Promenljive*********
      danispi:=DATE()-1
      vremispi=" "
      p_danned:=0
      p_zdanned:=SPACE(1)
      p_taster:=0
****************************

*******Ispisuje trenurno vreme,broji dok ceka da pritisnete taster********
      DO WHILE .T.
        SET CONFIRM OFF

********Uzima sistemski datum i vreme*******
*U trenu promene dana (00-h), brise prostor za ispis, jer se menja duzina*
        IF danispi<DATE()
          @ 1,1 CLEAR TO 1,55
        ENDIF
        danispi:=DATE()
        vremispi:=TIME()

*********Odredjuje dan u nedelji**********
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

************Ispisuje: dan u nedelji, datun i vreme**********
        @ 1,1 SAY "Danas je: "+p_zdanned+", "+DTOC(danispi)+;
        " - Vreme: "+vremispi COLOR "BG+/B"

************Registruje pritisnutu tipku***********
        CLEAR TYPEAHEAD
        p_taster:=INKEY()

********Izlazi ako se pritisne blo koja dirka********
        IF p_taster#0
          SET CONFIRM ON
          EXIT
        ENDIF

      ENDDO

********Izlazak********
    ELSEIF p_izlaz=1
      p_izlaz:=0
    ENDIF

*****Izlazak*****
*------- Prekid
    IF LASTKEY()=27
     CLOSE DATABASES
     ERASE gdlistin.ntx
     SET COLOR TO "GR+/B,R/G,,,"
     CLS
     @ 4,27 TO 10,51
     RETURN

*****Listanje*****
*------- Pregled kolone "1-REDBR"
    ELSEIF LASTKEY()=49
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      *Listanje od gore*
      IF p_gdlist#12
        p_gdlist:=12
        INDEX ON STR(redbr) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      *Listanje od dole*
      ELSEIF p_gdlist=12
        p_gdlist:=11
        INDEX ON DESCEND(STR(redbr)) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

*-------- Pregled kolone "2-IME" 
    ELSEIF LASTKEY()=50
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      *Listanje od gore*
      IF p_gdlist#22
        p_gdlist:=22
        INDEX ON ime+ekst TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      *Listanje od dole*
      ELSEIF p_gdlist=22
        p_gdlist:=21
        INDEX ON DESCEND(ime+ekst) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

*-------- Pregled kolone "3-EKST" 
    ELSEIF LASTKEY()=51
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      *Listanje od gore*
      IF p_gdlist#32
        p_gdlist:=32
        INDEX ON ekst+ime TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      *Listanje od dole*
      ELSEIF p_gdlist=32
        p_gdlist:=31
        INDEX ON DESCEND(ekst+ime) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

*-------- Pregled kolone "4-VELICINA" 
    ELSEIF LASTKEY()=52
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      *Listanje od gore*
      IF p_gdlist#42
        p_gdlist:=42
        INDEX ON STR(velicina)+ime TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      *Listanje od dole*
      ELSEIF p_gdlist=42
        p_gdlist:=41
        INDEX ON DESCEND(STR(velicina)+ime) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

*-------- Pregled kolone "5-DATUM" 
    ELSEIF LASTKEY()=53
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      *Listanje od gore*
      IF p_gdlist#52
        p_gdlist:=52
        INDEX ON DTOS(datum)+vreme TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      *Listanje od dole*
      ELSEIF p_gdlist=52
        p_gdlist:=51
        INDEX ON DESCEND(DTOS(datum)+vreme) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

*-------- Pregled kolone "6-VREME" 
    ELSEIF LASTKEY()=54
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      *Listanje od gore*
      IF p_gdlist#62
        p_gdlist:=62
        INDEX ON vreme TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      *Listanje od dole*
      ELSEIF p_gdlist=62
        p_gdlist:=61
        INDEX ON DESCEND(vreme) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

*-------- Pregled kolone "7-A" 
    ELSEIF LASTKEY()=55
      IF FILE("gdlistin.ntx")
        CLOSE DATABASES
        ERASE gdlistin.ntx
        USE podgran
      ENDIF
      *Listanje od gore*
      IF p_gdlist#72
        p_gdlist:=72
        INDEX ON a TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      *Listanje od dole*
      ELSEIF p_gdlist=72
        p_gdlist:=71
        INDEX ON DESCEND(a) TO gdlistin.ntx
        p_red:=5
        p_redbro:=1
        GO TOP
        @ 5,4 CLEAR TO 21,74
        LOOP
      ENDIF

*****Kretanje gore-dole*****
*------- Na gore po jedan
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

*------- Na gore skok
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

*------- Na dole po jedan
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

*------- Na dole skok
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

*------- Neka druga tipka
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

*******PREGLED I IZBOR BAZE*******

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

*****Formiranje radne baze IMEBAZE.DBF*****
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
    
*******************ZAGLAVLJE******************
CLS

***Broj databaza u direktoriju***
m_22brsl:=0
SELECT 2
m_22brsl:=RECCOUNT()

***Zaglavlje i poruke***
*Okvir*
@ 0,0 TO 24,79 DOUBLE
***Ispis poruka***
@ 5,29 SAY "Red"
@ 5,33 SAY "Ime databaze"    

@ 1,1 SAY "Ime direktorija: " + p_ispis +;
           " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
@ 1,63 SAY "Datum: "+DTOC(DATE())+"."
@ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
           "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 

***********Kretanje po ekranu*************
p_2brr:=1
p_2red:=7
p_2izlaz:=0
p_pokbrr:=1
p_pokred:=7
m_baza:=SPACE(12)


**********Petlja za ispis**********
GO TOP
DO WHILE .T.
  ***Ispis zaglavlja i podataka***
  @ 6,32 TO 15,45
  @ 6,28 TO 15,32
  @ 6,32 SAY CHR(194)
  @ 15,32 SAY CHR(193)
  @ 1,1 CLEAR TO 1,62
  @ 1,1 SAY "Ime direktorija: " + p_ispis +;
             " - Broj databaza: " + ALLTRIM(STR(m_22brsl))

  ***Ispis databaza***
  @ p_2red,29 SAY ALLTRIM(STR(redbrojb))
  @ p_2red,33 SAY ALLTRIM(imebaze)
  ********************

  SKIP
  p_2red:=p_2red+1


  *Kraj stranice*
  IF p_2red=15 .OR. BOF() .OR. EOF()

      ***Ispis zelenog okvira***
      GO p_pokbrr
      @ p_pokred,32 SAY CHR(179) COLOR "GR+/G"
      @ p_pokred,29 SAY "   " COLOR "R/G"
      @ p_pokred,29 SAY ALLTRIM(STR(redbrojb)) COLOR "R/G"
      @ p_pokred,33 SAY imebaze COLOR "R/G"
      **************************

      INKEY(0)

*------- Prekid rada
    IF LASTKEY()=27
      CLOSE DATABASES
      ERASE imebaze.dbf
      ERASE ekstime.ntx
      SET COLOR TO "GR+/B,R/G,,,"
      CLS
      @ 4,27 TO 10,51
      RETURN

*------- Potvrda izbora
    ELSEIF LASTKEY()=13
      m_baza:=imebaze
      DO prgpodbz
      p_2red:=7
      GO p_2brr
      LOOP

*------- Pravljenje nove baze
    ELSEIF LASTKEY()=-4
      DO kreirbaz
      m_22brsl:=m_22brsl+1
      p_2red:=7
      GO p_2brr
      LOOP

*-------Brisanje databaze
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
      *Brise databazu fizicki*
      m_brisanje:=" "
      m_brisanje:=imebaze+".dbf"
      ERASE &m_brisanje
      *Brise ime baze iz baze sa imenima*
      GO p_pokbrr
      DELETE
      PACK
      *Ponovo analizira direktorijum*
      DO isptdrkt
      *Otvara ponovo bazu IMEBAZE.DBF koja sadrzi imena baza*
      USE imebaze
      *Priprema novi ispis*
      m_22brsl:=m_22brsl-1
      p_2brr:=1
      p_2red:=7
      p_pokbrr:=1
      p_pokred:=7
      GO p_2brr
      *Zaglavlje i poruke*
      SET COLOR TO "GR+/B,R/G,,,"
      CLS
      ***Zaglavlje i poruke***
      *Okvir*
      @ 0,0 TO 24,79 DOUBLE
      ***Ispis poruka***
      @ 5,29 SAY "Red"
      @ 5,33 SAY "Ime databaze"    
      @ 1,1 SAY "Ime direktorija: " + p_ispis +;
                 " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
      @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
      @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
                 "*"+"Nova_baza:F5"+"*"+;
                 "Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25)
      LOOP

*------- NA dole
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
      ***Na kraju stranice krece se stranica a pokazivac ostaje na dnu***
      IF p_pokred=p_2red-1
        p_2red:=7
        p_2brr:=p_2brr+1
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      **Kretanje pokzivaca do kraja stranice**
      ELSEIF p_pokred<p_2red-1
        p_pokred:=p_pokred+1
        p_2red:=7
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ENDIF

*------- Na gore
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

*------- Neka druga tipka
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


***********************PREGLED PODATAKA O POLJIMA BAZE*********************
PROCEDURE PRGPODBZ
************Pregled podataka o poljima izabrane baze podataka**************

m_baza:=ALLTRIM(LOWER(m_baza)) + ".dbf"

******************Formiranje i punjenje baze OSOB.DBF********************
SELECT 5

IF FILE("imeplprt.dbf")
  CLOSE
  ERASE imeplprt.dbf
ENDIF

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

***********Kretanje po ekranu*************
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

*------- Prekid i vracanje u izbor databaze
    IF LASTKEY()=27
      CLOSE DATABASES
      ERASE osob.dbf
      SELECT 2
      USE imebaze
      SET COLOR TO "GR+/B,R/G,,,"
      CLS
      ***Zaglavlje i poruke***
      *Okvir*
      @ 0,0 TO 24,79 DOUBLE
      ***Ispis poruka***
      @ 5,29 SAY "Red"
      @ 5,33 SAY "Ime databaze"    
      @ 1,1 SAY "Ime direktorija: " + p_ispis +;
                " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
      @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
      @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
                 "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 
      RETURN
*------- NA dole
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
*------- Na gore
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
*------- Neka druga tipka
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

***Kreiranje baze za proveru imena***
SELECT 5
IF FILE("osobx.dbf")
  CLOSE 
  ERASE osobx.dbf
ENDIF
IF FILE("imeplprt.dbf")
  CLOSE 
  ERASE imeplprt.dbf
ENDIF
IF FILE("imeplpri.ntx")
  CLOSE 
  ERASE imeplpri.ntx
ENDIF


p_mtimpl:=0
p_mtimpl:=ARRAY(1,4)
p_mtimpl[1,1]:="imepolja"
p_mtimpl[1,2]:="c"
p_mtimpl[1,3]:=10
p_mtimpl[1,4]:=0
DBCREATE("imeplprt",p_mtimpl)
USE imeplprt

SELECT 3
CLS

m_imnvbz:=SPACE(8)
m_dobroime:="D"

DO WHILE .T.
  m_prbime:=" "
  **Unos imena baze**
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
    ***Zaglavlje i poruke***
    *Okvir*
    @ 0,0 TO 24,79 DOUBLE
    ***Ispis poruka***
    @ 5,29 SAY "Red"
    @ 5,33 SAY "Ime databaze"    
    @ 1,1 SAY "Ime direktorija: " + p_ispis +;
              " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
    @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
    @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
               "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 
    RETURN
  ENDIF
  *Obezbedjuje da nesto mora nade upise*
  IF EMPTY(m_imnvbz)
    LOOP
  ENDIF
  @ 13,24 CLEAR TO 11,22
  m_imnvbz:=LOWER(m_imnvbz)
  **Provera upisanih znakova**
  m_brupsime:=0
  m_znimnbz:=" "
  m_imnvbz:=ALLTRIM(m_imnvbz)
  m_brupsime:=LEN(m_imnvbz)
  FOR l=1 TO m_brupsime
    m_znimnbz:=SUBSTR(m_imnvbz,l,1)
    IF m_znimnbz $ "1234567890_qwertyuiopasdfghjklzxcvbnm"
      *Treba samo da prodje*
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
  **Sprecava pravljenje baze pod vec postojecim imenim**
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

*Kreira bazu OSOB sa poljima:field_name, type, len i dec*
CREATE osob
APPEND BLANK


***Zaglavlje***
CLS
@ 4,23 TO 22,54 DOUBLE
@ 24,1 SAY "Izlaz:Esc*Novo_polje:F5*Unos:Enter*Brisanje:Delete*"+;
           "Kreiranje:F7*Kretanje:"+CHR(24)+"-"+CHR(25)
           
**Zaglavlje**
@ 3,24 SAY "Ime polja"
@ 3,35 SAY "Tip"
@ 3,39 SAY "Duzina"
@ 3,46 SAY "Decimale"
*Spajalice uzduznih linija i okvira*
@ 4,34 SAY CHR(209)
@ 4,38 SAY CHR(209)
@ 4,45 SAY CHR(209)
@ 22,34 SAY CHR(207)
@ 22,38 SAY CHR(207)
@ 22,45 SAY CHR(207)

**Matrica koja odredjuje pocetno mesto za ispis pokretnog polja**
DECLARE p_mtrfrm[4]
p_mtrfrm[1]:=24
p_mtrfrm[2]:=36
p_mtrfrm[3]:=41
p_mtrfrm[4]:=48

**Promenljive**
m_brslnv:=0
m_brppnv:=0
m_rdppnv:=0
m_klppnv:=1
m_trnvsl:=0
m_upnvpl:="N"

***Upis***
DO WHILE .T.
  m_brrdnv:=0

  *Bisanje postojecih podataka i poruke*
  @ 1,1 CLEAR TO 1,40
  @ 5,24 CLEAR TO 21,53
  @ 23,10 CLEAR TO 23,65
  *Uzduzne linije*
  FOR z=1 TO 17
    @ 4+z,34 SAY CHR(179)
    @ 4+z,38 SAY CHR(179)
    @ 4+z,45 SAY CHR(179)
  NEXT

  ***Ispis postojecih podataka***
  DO WHILE .T.
    m_brrdnv:=m_brrdnv+1
    @ m_brrdnv+4,24 SAY field_name COLOR "BG+/B"
    @ m_brrdnv+4,36 SAY field_type COLOR "BG+/B"
    @ m_brrdnv+4,41 SAY field_len COLOR "BG+/B"
    @ m_brrdnv+4,48 SAY field_dec COLOR "BG+/B"
    SKIP
    IF m_brrdnv=17 .OR. EOF()
      SKIP -m_brrdnv
      EXIT
    ENDIF
  ENDDO
  ********************************

  ***Ispis pokretnog polja***
  *Postavljanje na odredjeni slog za uzimanje*
  IF m_rdppnv>0
    SKIP m_rdppnv
  ENDIF
  *Uzima broj slogova baze i poziciju trenutnog sloga*
  m_brslnv:=RECCOUNT()
  m_trnvsl:=RECNO()
  *Uzimanje sloga zavisno od zeljene pozicije*
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

  **Ispis pokretnog polja**
  @ m_rdppnv+5,p_mtrfrm[m_klppnv] SAY m_isppnv COLOR "B/W"
  ********************************************************

  *Broj polja databaze*
  @ 1,1 SAY "Baza: "+UPPER(m_imnvbz)+;
            " - Polje: "+ALLTRIM(STR(m_trnvsl))+"/"+ALLTRIM(STR(m_brslnv))

  ***Zastoj***
  IF m_upnvpl="N"
    INKEY(0)
  ENDIF

***Izlazak***
  IF LASTKEY()=27
    m_brisbz:="N"
    @ 23,1 CLEAR TO 23,78
    @ 23,19 SAY "Odustajete od kreiranja baze:"+UPPER( m_imnvbz)+;
            " (D/N) - " GET m_brisbz PICTURE "!" VALID(m_brisbz $ "DdNn") 
    READ
    @ 23,1 CLEAR TO 23,78
    IF m_brisbz="N"
      LOOP
    ENDIF
    m_22brsl:=m_22brsl-1
    CLOSE
    ERASE osob.dbf
    SELECT 5
    CLOSE
    ERASE imeplprt.dbf
    SELECT 2
    SET COLOR TO "GR+/B,R/G,,,"
    CLS
    ***Zaglavlje i poruke***
    *Okvir*
    @ 0,0 TO 24,79 DOUBLE
    ***Ispis poruka***
    @ 5,29 SAY "Red"
    @ 5,33 SAY "Ime databaze"    
    @ 1,1 SAY "Ime direktorija: " + p_ispis +;
              " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
    @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
    @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
               "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 
    RETURN

***Kreiranje napravljene baze i slanje na ispitivanje direktorijuma (F7)***
   ELSEIF LASTKEY()=-6
    *Potvrda kreiranja*
    m_brisbz:="N"
    @ 23,1 CLEAR TO 22,78
    @ 23,5 SAY "Formiranje:"+UPPER( m_imnvbz)+;
               ". Nepotpuni slogovi bice izbrisani !"+;
               "(D/N) ->" GET m_brisbz PICTURE "!" VALID(m_brisbz $ "DdNn") 
    READ
    @ 23,1 CLEAR TO 23,78
    IF m_brisbz="N"
      LOOP
    ENDIF
    **Ciscenje baze od nepotpunih slogova**
    GO TOP
    DO WHILE !EOF()
      IF EMPTY(field_name) .OR. EMPTY(field_type) .OR. EMPTY(field_len)
        DELETE
        PACK
      ENDIF
      SKIP
    ENDDO
    **Prebacivanje podataka u matricu, radi pripreme za formiranje*
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
    **Kreiranje baze po podacima iz matrice**
    DBCREATE(m_imnvbz,p_mtform)
    USE
    **Slanje programa da ponovo registruje sve u direktoriju**
    m_upisnv:="D"
    CLOSE 
    ERASE osob.dbf
    DO isptdrkt
    **Vraca se kao na "Esc"**
    SELECT 2
    USE imebaze
    APPEND BLANK
    REPLACE imebaze WITH UPPER(m_imnvbz), redbrojb WITH p_redbrbaz+1
    SET COLOR TO "GR+/B,R/G,,,"
    CLS
    ***Zaglavlje i poruke***
    *Okvir*
    @ 0,0 TO 24,79 DOUBLE
    ***Ispis poruka***
    @ 5,29 SAY "Red"
    @ 5,33 SAY "Ime databaze"    
    @ 1,1 SAY "Ime direktorija: " + p_ispis +;
              " - Broj databaza: " + ALLTRIM(STR(m_22brsl))
    @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
    @ 23,3 SAY "Pregled:Enter"+"*"+"Brisanje:Delete"+"*"+"Izlaz:Esc"+;
               "*"+"Nova_baza:F5"+"*"+"Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25) 
    RETURN

***Otvaranje novog sloga (F5)***
  ELSEIF LASTKEY()=-4
    **Omogucuje otvaranje novog sloga i postavlja polje na mesto za upis**
    *Prebacuje upis odmah na polje za ime*
    m_klppnv:=1
    *Otvara novi slog*
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
    **Upis imena polja**
    @ 23,24 SAY "Ime sadrzi: slovo, broj ili _ "
    *Upis i kontrola*
    DO WHILE.T.
      m_xdobrpl:="D"
      m_xdobroime:="D"

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

      **Proverava da li je to ime vec upisano**
      SELECT 5
      GO TOP
      DO WHILE !EOF()
        IF ALLTRIM(UPPER(imepolja))=ALLTRIM(UPPER(m_upnvpd))
          m_xdobrpl:="N"
          SELECT 3
          EXIT
        ENDIF
        SKIP
      ENDDO
      IF m_xdobrpl="N"
        LOOP
      ENDIF
      SELECT 3

      **Kontrola ispravnosti upisanih podataka**
      m_upnvpd:=ALLTRIM(LOWER(m_upnvpd))
      **Provera upisanih znakova**
      m_brmsime:=0
      m_zimplj:=" "
      m_brmsime:=LEN(m_upnvpd)
      *Ne dozvoljava broj na prvom mestu*
      m_zimplj:=SUBSTR(m_upnvpd,1,1)
      IF m_zimplj $ "1234567890_"
        LOOP
      ENDIF
      FOR w=1 TO m_brmsime
        m_zimplj:=SUBSTR(m_upnvpd,w,1)
        IF m_zimplj $ "1234567890_qwertyuiopasdfghjklzxcvbnm"
          *Treba samo da prodje*
          m_xdobroime:="D"
        ELSE
          m_xdobroime:="N"
          EXIT
        ENDIF
      NEXT
      IF m_xdobroime="D"
        EXIT
      ENDIF
    ENDDO

    *Ako nije nista upisano, brse novi slog*
    IF EMPTY(m_upnvpd)
      IF m_rdppnv>0
        SKIP m_rdppnv
      ENDIF
      DELETE
      PACK
      IF m_rdppnv>0
        SKIP -m_rdppnv
      ENDIF
      IF m_brslnv>17
        GO BOTTOM
        SKIP-16
        m_rdppnv:=16
      ELSEIF m_brslnv<18
        GO TOP
        m_rdppnv:=m_brslnv-2
      ENDIF
      LOOP
    ENDIF

    **Upis u bazu prihvacenih podataka**
    IF m_rdppnv>0
      SKIP m_rdppnv
    ENDIF
    REPLACE field_name WITH m_upnvpd
    IF m_rdppnv>0
      SKIP -m_rdppnv
    ENDIF

     *Upis imena u bazu za proveru*
     SELECT 5
     APPEND BLANK
     REPLACE imepolja WITH m_upnvpd
     SELECT 3

    LOOP


***Brisanje sloga (podataka o polju)***
  ELSEIF LASTKEY()=7
    IF m_brslnv=0
      LOOP
    ENDIF
    IF m_rdppnv>0
      SKIP m_rdppnv
    ENDIF

    *Brisanje imena iz baze koja cuva imena za proveru, da se ne ponavljaju*
    m_uzppnv:=" "
    m_uzppnv:=field_name
    SELECT 5
*    SEEK m_uzppnv
    GO TOP
    DO WHILE !EOF()
      IF imepolja=m_uzppnv
        DELETE
        PACK
      ENDIF
      SKIP
    ENDDO
    SELECT 3

    *Brisanje izabranog sloga*
    DELETE
    PACK
    IF m_rdppnv>0
      SKIP -m_rdppnv
    ENDIF

    IF m_trnvsl=m_brslnv
      IF m_brslnv>17
        GO BOTTOM
        SKIP-16
        m_rdppnv:=16
      ELSEIF m_brslnv<18
        GO TOP
        m_rdppnv:=m_rdppnv-1
      ENDIF
    ELSEIF m_trnvsl<m_brslnv
      SKIP m_trnvsl-(m_rdppnv+1)
    ENDIF
    LOOP

***Azuriranje podataka i njihova izmena***
  ELSEIF LASTKEY()=13
    SET CONFIRM ON
    SET CURSOR ON
    *Postavljanje na odredjeni slog za upis*
    IF m_rdppnv>0
      SKIP m_rdppnv
    ENDIF
    ***Upis imena polja***
    IF m_klppnv=1
      m_plppnv:=field_name
      DO WHILE .T.
        m_dobrpl:="D"
        @ 23,24 SAY "Ime sadrzi: slovo, broj ili _ "
        **Unos**
        *Pamti ono sto je bilo*
        m_pamtiime:=m_plppnv
        @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv COLOR "R/W"
        READ
        *Omogucuje izlaz*
        IF LASTKEY()=27 .OR. m_pamtiime=m_plppnv
          IF m_rdppnv>0
            SKIP -m_rdppnv
          ENDIF
          SET CONFIRM OFF
          SET CURSOR OFF
          EXIT
        ENDIF
        **Proverava da li je to ime vec upisano**
        SELECT 5
*        SEEK m_plppnv
*        IF FOUND()
        GO TOP
        DO WHILE !EOF()
          IF ALLTRIM(UPPER(imepolja))=ALLTRIM(UPPER(m_plppnv))
            SELECT 3
            m_dobrpl:="N"
            EXIT
          ENDIF
          SKIP
        ENDDO
        IF m_dobrpl="N"
          LOOP
        ENDIF
        SELECT 3
        **Kontrolise ispravnost upisanog imena**
        m_plppnv:=ALLTRIM(LOWER(m_plppnv))
        **Provera upisanih znakova**
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
            *Treba samo da prodje*
            m_dobroime:="D"
          ELSE
            m_dobroime:="N"
            EXIT
          ENDIF
        NEXT
        IF m_dobroime="D"
          **Unos u bazu**
          REPLACE field_name WITH m_plppnv
          IF m_rdppnv>0
            SKIP -m_rdppnv
          ENDIF
          SET CONFIRM OFF
          SET CURSOR OFF

          *Upis imena u bazu za proveru*
          SELECT 5
          APPEND BLANK
          REPLACE imepolja WITH m_plppnv
          SELECT 3

          EXIT
        ENDIF
      ENDDO
      *Izbacuje iz ispisa i vraca na obican pregled*
      LOOP
    ***Upis tipa polja***
    ELSEIF m_klppnv=2
      *Onemogucava upis ako je ime prazno*
      IF EMPTY(field_name)
        m_klppnv:=1
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      **Unos**
      m_plppnv:=field_type
      @ 23,21 SAY "Polje:slovo-C,broj-N,datum-D,logik-L"
      **Unos**
      @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv COLOR "R/W" PICTURE "!" ;
                                      VALID(m_plppnv $ "CcNnDdLl")
      READ
      *Omogucuje izlaz*
      IF LASTKEY()=27
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      **Upis tipa u bazu**
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
    ***Upis broja mesta u polju***
    ELSEIF m_klppnv=3
      *Onemogucava upis ako je ime i tip prazno*
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
      *Uzima vrdnost iz polja*
      m_plppnv:=field_len
      *Poruka za nacin upisa*
      @ 23,24 SAY "Mesta:C<1000,N<20,uvek:D=8,L=1"
      **Unos**
      IF field_type="C"
        @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv ;
                                      RANGE 1,999 COLOR "R/W"
        READ
      ELSEIF field_type="N"
        @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv ;
                                      RANGE 1,19 COLOR "R/W"
        READ
      ENDIF
      *Omogucuje izlaz na Esc*
      IF LASTKEY()=27
        IF m_rdppnv>0
          SKIP -m_rdppnv
        ENDIF
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      **Upis u bazu**
      REPLACE field_len WITH m_plppnv
      IF m_rdppnv>0
        SKIP -m_rdppnv
      ENDIF
      SET CONFIRM OFF
      SET CURSOR OFF
      LOOP
    ***Upis decimala za numerike***
    ELSEIF m_klppnv=4
      *Onemogucava upis ako je ime, tip i br. mesat prazno*
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
      *Poruka za nacin upisa*
      @ 23,25 SAY "Samo za N:br.mesta-2(ne>15)"
      **Unos**
      *Uzima iz baze*
      m_plppnv:=field_dec
      DO WHILE .T.
        @ m_rdppnv+5,p_mtrfrm[m_klppnv] GET m_plppnv RANGE 1,15 COLOR "R/W"
        READ
        *Omogucuje izlaz na Esc*
        IF LASTKEY()=27
          m_plppnv:=0
          EXIT
        ENDIF
        IF field_len-m_plppnv<2
          LOOP
        ENDIF
        EXIT
      ENDDO
      **Upis u bazu**
      REPLACE field_dec WITH m_plppnv
      IF m_rdppnv>0
        SKIP -m_rdppnv
      ENDIF
      SET CONFIRM OFF
      SET CURSOR OFF
      LOOP
    ENDIF


***Pomeranje podataka***
*------- Pritisnut taster za levo
  ELSEIF LASTKEY()=19
    IF m_klppnv=1
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE U LEVO" COLOR "RB+/B"
      INKEY (1.1)
    ELSEIF m_klppnv>1
      m_klppnv:=m_klppnv-1
    ENDIF
    LOOP

*------- Pritisnut taster za desno
  ELSEIF LASTKEY()=4
    IF m_klppnv=4
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE U DESNO" COLOR "RB+/B"
      INKEY (1.1)
    ELSEIF m_klppnv<4
      m_klppnv:=m_klppnv+1
    ENDIF
    LOOP


*****Kretanje gore-dole*****
*------- Na gore po jedan
  ELSEIF LASTKEY()=5 
    IF m_rdppnv=0
      SKIP -1
      IF BOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
        INKEY(1.2)                 
        GO TOP
      ENDIF
      LOOP
    ENDIF
    m_rdppnv:=m_rdppnv-1
    LOOP

*------- Na gore skok
  ELSEIF LASTKEY()=18
    SKIP -1
    IF BOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
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

*------- Na dole po jedan
  ELSEIF LASTKEY()=24 
    m_rdppnv:=m_rdppnv+1
    SKIP m_rdppnv
    IF EOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
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

*------- Na dole skok
  ELSEIF LASTKEY()=3
    SKIP 17
    IF EOF()  .AND. m_brslnv>17
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      GO BOTTOM
      SKIP -16
      LOOP
    ELSEIF EOF() .AND. m_brslnv<18
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
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

*------- Neka druga tipka
  ELSE
    @ 23,1 CLEAR TO 23,78
    @ 23,34 SAY "POGRESAN TASTER" COLOR "RB+/B"
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

*******PREGLED I IZBOR BAZE*******

SELECT 2
IF FILE("imebaze.dbf")
  CLOSE
  ERASE imebaze.dbf
ENDIF

*****Formiranje radne baze IMEBAZE.DBF*****
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


*******************ZAGLAVLJE******************

CLS

***Broj databaza u direktoriju***
m_2brsl:=0
m_2brsl:=RECCOUNT()


***********Kretanje po ekranu*************
p_2brr:=1
p_2red:=7
p_2izlaz:=0
p_pokbrr:=1
p_pokred:=7
m_baza:=SPACE(12)

***Okvir zaglavlja***
@ 0,0 TO 24,79 DOUBLE

@ 5,29 SAY "Red"
@ 5,33 SAY "Ime databaze"

***Ispis poruka***
@ 1,1 SAY "Ime direktorija: " + p_ispis +;
           " - Broj databaza: " + ALLTRIM(STR(m_2brsl))
@ 23,17 SAY "Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25)+"*Izbor:Enter*Izlaz:Esc"

**********Petlja za ispis**********
GO TOP
DO WHILE .T.
  ***Ispis zaglavlja i podataka***
  @ 6,32 TO 15,45
  @ 6,28 TO 15,32
  @ 6,32 SAY CHR(194)
  @ 15,32 SAY CHR(193)

  @ 1,63 SAY "Datum: "+DTOC(DATE())+"."

  ***Ispis databaza***
  @ p_2red,29 SAY ALLTRIM(STR(redbrojb))
  @ p_2red,33 SAY ALLTRIM(imebaze)
  ********************

  SKIP
  p_2red:=p_2red+1

  *Kraj stranice*
  IF p_2red=15 .OR. BOF() .OR. EOF()
      ***Ispis zelenog okvira***
      GO p_pokbrr
      @ p_pokred,32 SAY CHR(179) COLOR "GR+/G"
      @ p_pokred,29 SAY "   " COLOR "R/G"
      @ p_pokred,29 SAY ALLTRIM(STR(redbrojb)) COLOR "R/G"
      @ p_pokred,33 SAY imebaze COLOR "R/G"
      **************************

      INKEY(0)

*------- Prekid rada
    IF LASTKEY()=27
      CLOSE DATABASES
      ERASE imebaze.dbf
      ERASE ekstime.ntx
      SET COLOR TO "GR+/B,R/G,,,"
      CLS
      @ 4,27 TO 10,51
      RETURN

*------- Potvrda izbora
    ELSEIF LASTKEY()=13
      m_baza:=imebaze
      *****Poziva proceduru za manipulaciju podacima*****
      DO manpodbz
      p_2red:=7
      GO p_2brr
      LOOP

*------- NA dole
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
      ***Na kraju stranice krece se stranica a pokazivac ostaje na dnu***
      IF p_pokred=p_2red-1
        p_2red:=7
        p_2brr:=p_2brr+1
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      **Kretanje pokzivaca do kraja stranice**
      ELSEIF p_pokred<p_2red-1
        p_pokred:=p_pokred+1
        p_2red:=7
        GO p_2brr
        @ 6,28 CLEAR TO 15,45
        LOOP
      ENDIF

*------- Na gore
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

*------- Neka druga tipka
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

*****Zadata baza*****
m_suvabz:=" "
m_suvabz:=m_baza
m_baza:=ALLTRIM(LOWER(m_baza)) + ".dbf"
SELECT 4
USE &m_baza
m_brslbz:=LASTREC()
CLOSE

*Prebacivanje imena u proceduru za pretragu*
m_imbzpt:=m_baza

*****Formiranje i punjenje baze OSOB.DBF koja sadrzi oasobine polja*****
SELECT 3
IF FILE("osob.dbf")
  CLOSE DATABASES
  ERASE osob.dbf
ENDIF

***Baza OSOB sadrzi: field_name, field_type, field_len, field_dec***
USE &m_baza
COPY TO osob STRUCTURE EXTENDED
CLOSE
USE osob
m_brsl:=RECCOUNT()
m_brslpt:=m_brsl

***Obelezavanje neregularnog "C" polja sa "888"***
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

*************************PRIKAZ NA EKRANU*************************
CLS

SELECT 4
USE &m_baza
GO TOP

***Boja okvira i zaglavlja***
SET COLOR TO "BG+/B"
@ 0,0 TO 24,79 DOUBLE COLOR "GR+/B"

***************Zaglavlje***************
***Boja poruka***
SET COLOR TO "G+/B"

***Postavka promenljivih***
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

  **Uputstvo za uptrbu**
  @ 23,1 CLEAR TO 23,78
  *Ispisuje zavisno od potrebe (F10)*
  IF m_ispF10="PRVI"
    @ 23,2 SAY "Korak:"+CHR(24)+"-"+CHR(25)+"*Skok:PageUp"+CHR(24)+;
               "-PageDown"+CHR(25)+"*Izmena:Enter*Izlaz:Esc*F10(F-1,2,3,4,5,6,8)"
  ELSEIF m_ispF10="DRUGI"
    @ 23,1 SAY "F1:T-polje*F2:T-izraz*F3:Opet_F1-2*F8:T-sve*F4:Skok*"+;
               "F5:Nov_slog*F6:Brise*F10:P"
  ENDIF
  SELECT 3
  GO m_pocpolje
  m_brmsuk:=0
  m_uzetoplj:=0
  m_pocmesto:=0

  ***Za DESNO (samo racuna parametre za ispis na ekranu)***
  IF m_taster="D" 
    DO WHILE .T.
      m_brmspl:=0
      m_brmsdc:=0
      m_uzetoplj:=m_uzetoplj+1
  
      m_brmspl:=field_len
      m_brmsdc:=field_dec

      ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
      IF m_brmspl<10
        m_brmspl:=10
      ENDIF
      
      ***Sabira polja koja treba da se prikazu***
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

  ***Za LEVO (samo racuna parametre za ispis na ekranu)***
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
  
      ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
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

  ***Ispis 's desna za kretanje u levo***
  IF m_taster="L" .AND. BOF()
    m_taster:="D"
    m_prvoplj:="D"
    m_brpslnd:="D"
    LOOP
  ENDIF

  *****Iracunavanje pocetka ispisa*****
  IF m_brmsuk>74
    m_brmsuk:=74
  ENDIF
  m_pocmesto:=39-INT(m_brmsuk/2)


  ***********************************
  **********   I S P I S   **********

  @ 2,1 CLEAR TO 22,78
  @ 4,1 TO 22,78 COLOR "GR+/B"

  ***** Ispis zaglavlja: ime polja, karakter, broj mesta i decimala *****
  *Promenljive zaglavlje*
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

  *Postavka matrica*
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

  ***Ispisuje zaglavlje i priprema ekran za ispis podataka***
  DO WHILE .T.
    m_brjc1:=m_brjc1+1

    m_brmspl:=field_len
    m_brmsdc:=field_dec

    ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
    IF m_brmspl<10
      m_brmspl:=10
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zauzima vise od 74 mesta***
    IF m_brmspl>74
      m_brmspl:=74
    ENDIF

    ***Odredjuje pocetak ispisa podataka u zaglavlju na sredini***
    m_mestisp:=m_zpocmesto+INT((m_brmspl-8)/2)
    m_kollin:=m_zpocmesto+m_brmspl+1

    ***Vraca pravu vrednost onom blesavom i onom normalnom polju***
    IF field_type="C" .AND. field_len=888 .AND. field_dec=888
      m_brmpis:=1024
      m_brmdis:=0
    ELSE
      m_brmpis:=field_len
      m_brmdis:=field_dec
    ENDIF

    **********Ispis zaglavlja**********
    @ 2,m_mestisp SAY field_name COLOR "GR+/B"
    @ 3,m_mestisp SAY "("+ALLTRIM(STR(m_brjc1))+")"+;
                      field_type+"-"+ALLTRIM(STR(m_brmpis))+;
                      "-"+ALLTRIM(STR(m_brmdis)) COLOR "GR+/B"
    *********************************************************

    ***Punjenje matrica osobinama polja za ispis podataka***
    p_mtrime[m_brjc1]:=field_name
    p_mtrtip[m_brjc1]:=field_type
    p_mtrplj[m_brjc1]:=field_len

    ***Izbacuje ako je to sve sto treba da se prikaze u ovom krugu***
    SKIP
    IF m_brjc1=m_uzetoplj
      EXIT
    ENDIF

    ***Ispis uzduzne razdelne linije***
    FOR w=1 TO 17
      m_redlin:=4+w
      @ m_redlin,m_kollin SAY CHR(179) COLOR "GR+/B"
    NEXT
    @ 4,m_kollin SAY CHR(194) COLOR "GR+/B"
    @ 22,m_kollin SAY CHR(193) COLOR "GR+/B"

    ***Pomera pocetno mesto za ispis i dodaje mesto za liniju***
    m_zpocmesto:=m_zpocmesto+m_brmspl+1

  ENDDO

  ************************************
  ********** Ispis podataka **********
  ************************************

  m_kolpod:=m_pocmesto+1
  m_brjc2:=1

  ***Pocetak ispisa JEDNE TURE (EKRANA)***
  DO WHILE .T.

    m_redpod:=5
    p_mtrpcm[m_brjc2]:=m_kolpod

    ***Ispisuje JEDNU KOLONU od izabranog polja***
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
       
      ***Ispis***
      *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
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

      ***Izbacuje kad stigne do kraja stranice***
      IF m_redpod=22
        EXIT
      ENDIF
    ENDDO

    ***Vraca ispis za sledecu kolonu***
    SELECT 4
    SKIP-(m_redpod-5)
    SELECT 3

    ***Izbacuje ako je to sve sto treba da se prikaze u ovom krugu***
    IF m_brjc2=m_uzetoplj
      EXIT
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
    IF p_mtrplj[m_brjc2]<10
      p_mtrplj[m_brjc2]:=10
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zauzima vise od 74 mesta***
    IF p_mtrplj[m_brjc2]>74
      p_mtrplj[m_brjc]:=74
    ENDIF

    ***Pomera pocetno mesto za ispis i dodaje mesto za zarez i za liniju***
    m_kolpod:=m_kolpod+p_mtrplj[m_brjc2]+1

    *Brojac kruga*
    m_brjc2:=m_brjc2+1

  ENDDO

  ***************************************************
  ***************Ispis pokretnog polja***************

  **Postavljanje na polje posle pomeranja ekrana**
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

  **Uzimanje podatka za ispis u pokretnom polju**
  *Podesavanje na zeljeni slog*
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
  ***Odredjuje mesto za ispis***
  m_pokkol:=p_mtrpcm[m_pkol]
  m_pokred:=5+m_pred

  ***Ispis pokretnog polja***
  *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
  IF p_mtrplj[m_pkol]>74
    @ m_pokred,m_pokkol SAY m_pokpolje PICTURE "@S74" COLOR "B/W"
  ELSEIF p_mtrplj[m_pkol]<75
    @ m_pokred,m_pokkol SAY m_pokpolje COLOR "B/W"
  ENDIF
  *****************************************

  **Korekcija za broj polja, kad ide s' desna na pocetno**
  IF m_brpslnd="D"
    m_brpslnd:="N"
    m_trnplj:=m_pkol
  ENDIF

  **Korekcija ako je krajnji desni ispis o bazi, slogovima i poljima**
  IF m_kortrp="D"
    m_trnplj:=m_brsl-m_uzetoplj+m_pkol
  ENDIF

  **Ispis podataka o bazi, slogovima i poljima**
  @ 1,1 CLEAR TO 1,78
  @ 1,2 SAY "BAZA:"+ALLTRIM(UPPER(m_baza))+;
            " * SLOG:"+ALLTRIM(STR(m_trnslg))+"/"+ALLTRIM(STR(m_brslbz))+;
            " * POLJE:"+ALLTRIM(STR(m_trnplj))+"/"+ALLTRIM(STR(m_brsl))

  *****Zastoj za prihvat pritisnutog tastera*****
  IF m_novupis="NIJE"
    INKEY(0)
  ENDIF

***Izlazak iz pregleda podataka, na nivo za izbor baze***
*------- Prekid i vracanje u izbor databaze
  IF LASTKEY()=27
    CLOSE DATABASES
    ERASE osob.dbf
    SELECT 4
    ERASE gdlistpg.ntx
    SELECT 2
    USE imebaze
    SET COLOR TO "GR+/B,R/G,,,"
    CLS
    ***Okvir zaglavlja***
    @ 0,0 TO 24,79 DOUBLE
    @ 5,29 SAY "Red"
    @ 5,33 SAY "Ime databaze"
    ***Ispis poruka***
    @ 1,1 SAY "Ime direktorija: " + p_ispis +;
               " - Broj databaza: " + ALLTRIM(STR(m_2brsl))
    @ 23,17 SAY "Listanje:GORE"+CHR(24)+"-DOLE"+CHR(25)+;
                "*Izbor:Enter*Izlaz:Esc"
    RETURN


***Prihvatanje odabranog podatka i njegova izmena***
  ELSEIF LASTKEY()=13
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    SELECT 4
    **Azuriranje podataka**
    SET CONFIRM ON
    SET CURSOR ON
    *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
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

***Pretraga po zadatom kriteriju (F1)***
  ELSEIF LASTKEY()=28
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    SET CONFIRM ON
    SET CURSOR ON
    *Unos kriterija*
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
    *Unos vrednosti*
    SELECT 4
    *Otvaranje praznog sloga radi uzimanja praznih polja*
    APPEND BLANK
    *Uzimanje praznog polja za upis*
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
    *Obezbedjuje da polja koja imaju vise od 42 mesta klize*
    IF p_mtrplj[m_pkol]>42
      @ 23,20 SAY " * Vrednost:" GET m_vrednost PICTURE "@S42" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<43
      @ 23,20 SAY " * Vrednost:" GET m_vrednost COLOR "R/W"
    ENDIF
    READ
    SET CONFIRM OFF
    SET CURSOR OFF
    *Brisanje slog-modela za unos*
    DELETE
    PACK
    *Kriteriji za postavljanje na pocetak ispisa*
    m_trnslg:=1
    m_pred:=0
    *Omogucuje izlaz*
    IF LASTKEY()=27
      GO TOP
      LOOP
    ENDIF  
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
    **Pretraga**
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
    *Neuspesna pretraga*
    IF EOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,31 SAY "Pretraga neuspesna"
      INKEY(1.1)
      GO TOP
      LOOP
    ENDIF
    m_ponprt:="DA"
    m_vrsprt:="F1"
    *Postavljanje  na nadjeni slog*
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


***Pretraga po zadatom delu izraza (F2)***
  ELSEIF LASTKEY()=-1
    *Obezbedjuje da se ispis ne pomera levo-desno*
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    *Vraca ako tip polja nije karakter*
    IF p_mtrtip[m_pkol] # "C"
      LOOP
    ENDIF
    *Prebacivanje radnog polja*
    SELECT 4
    *Otvaranje praznog sloga radi uzimanja praznih polja*
    APPEND BLANK
    *Uzimanje praznog polja za upis*
    m_imeuzmi:=" "
    m_prtizraz:=" "
    m_imeuzmi:=p_mtrime[m_pkol]
    m_prtizraz:=&m_imeuzmi
    *Brisanje slog-modela za unos*
    DELETE
    PACK
    *Kriteriji za postavljanje na pocetak ispisa*
    m_trnslg:=1
    m_pred:=0
    GO TOP
    *Unos izraza*
    SET CONFIRM ON
    SET CURSOR ON
    @ 23,1 CLEAR TO 23,78
    *Obezbedjuje da polja koja imaju vise od 62 mesta klize*
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
    *Pretraga polja po zadatom izrazu*
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
    m_prebroj:=0
    DO WHILE .T.
      m_prebroj:=m_prebroj+1
      m_brptpl:=LEN(ALLTRIM(&m_imeuzmi))
      m_brptzn:=LEN(ALLTRIM(m_prtizraz))
      *Ako je zadato vise znakova nego sto polja ima, nema sta da se trazi*
      IF m_brptpl<m_brptzn
        SKIP
        LOOP
      ENDIF
      *Pretraga po jednom polju*
      m_nasobre:="N"
      m_2uporedj:=" "
      m_2uporedj:=UPPER(ALLTRIM(m_prtizraz))
      FOR a=1 TO m_brptpl+1-m_brptzn
        m_1uporedj:=SPACE(m_brptzn)
        m_1uporedj:=UPPER(SUBSTR(&m_imeuzmi,a,m_brptzn))
        *Ako je negde pronadjeno izbacuje iz dalje pretrage*
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
    *Neuspesna pretraga*
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
    *Postavljanje  na nadjeni slog*
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


***Ponovna pretraga po prethodno zadatom kriterijumu ili delu izraza (F3)***
  ELSEIF LASTKEY()=-2
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    **Ne dozvoljava ponovnu pretragu**
    IF m_ponprt="NE"
      @ 23,1 CLEAR TO 23,78
      @ 23,25 SAY "Unesite kriterijum pretrage"
      INKEY(1.6)
      LOOP
    ENDIF
    *Otvaranje radnog polja*
    SELECT 4
    *Postavljanje na naredni slog za pretragu*
    GO TOP
    SKIP m_trnslg
    m_trnslg:=m_trnslg+1

    **Ponovna pretraga po zadatoj vrednosti**
    IF m_vrsprt="F1"
      **Pretraga**
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
      *Neuspesna pretraga*
      IF EOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,33 SAY "Nema podataka"
        INKEY(1.1)
        *Kriteriji za postavljanje na pocetak ispisa*
        m_trnslg:=1
        m_pred:=0
        GO TOP
        LOOP
      ENDIF
      *Postavljanje  na nadjeni slog*
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

    **Pretraga po zadatom delu izraza**
    ELSEIF m_vrsprt="F2"
      *Pretraga polja po zadatom izrazu*
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
      DO WHILE .T.
        m_prebroj:=m_prebroj+1
        m_brptpl:=LEN(ALLTRIM(&m_imeuzmi))
        m_brptzn:=LEN(ALLTRIM(m_prtizraz))
        *Ako je zadato vise znakova nego sto polja ima, nema sta da se trazi*
        IF m_brptpl<m_brptzn
          SKIP
          LOOP
        ENDIF
        *Pretraga u okviru jednog polja*
        m_nasobre:="N"
        m_2uporedj:=" "
        m_2uporedj:=UPPER(ALLTRIM(m_prtizraz))
        FOR a=1 TO m_brptpl+1-m_brptzn
          m_1uporedj:=SPACE(m_brptzn)
          m_1uporedj:=UPPER(SUBSTR(&m_imeuzmi,a,m_brptzn))
          *Ako je negde pronadjeno izbacuje iz dalje pretrage*
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
      *Neuspesna pretraga*
      IF EOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,33 SAY "Nema podataka"
        INKEY(1.6)
        *Kriteriji za postavljanje na pocetak ispisa*
        m_trnslg:=1
        m_pred:=0
        GO TOP
        LOOP
      ENDIF
      *Postavljanje  na nadjeni slog*
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


***Skok na zadati slog (red) (F4)***
  ELSEIF LASTKEY()=-3
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    *Uzimanje broja za skok*
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
    *Skok na zadati slog*
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


***Upis novog sloga (reda) i novih podataka (F5)***
  ELSEIF LASTKEY()=-4
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 4
    **Uklanja indeksnu bazu**
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    m_gdlist:=0
    **Omogucuje otvaranje novog sloga i postavlja polje na mesto za upis**
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
    **Upis novog podatka**
    SET CONFIRM ON
    SET CURSOR ON
    *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
    IF p_mtrplj[m_pkol]>74
      @ m_pokred,m_pokkol GET m_pokpolje PICTURE "@S74" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<75
      @ m_pokred,m_pokkol GET m_pokpolje COLOR "R/W"
    ENDIF
    READ
    *Ako nije nista upisano, brse novi slog*
    IF EMPTY(m_pokpolje)
      *Vraca ako je baza prazna*
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
    **Upis**
    SKIP m_pred
    REPLACE &m_imeuzmi WITH m_pokpolje
    SKIP -m_pred
    SET CONFIRM OFF
    SET CURSOR OFF
    LOOP

***Brisanje sloga na kome se nalazi pokretno polje (F6)***
  ELSEIF LASTKEY()=-5
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    @ 23,1 CLEAR TO 23,78
    @ 23,17 SAY "Potvrdite brisanje obelezenog sloga (D/N):"
    m_brisanje:="N"
    @ 23,60 GET m_brisanje PICTURE "!" VALID(m_brisanje $ "DdNn") COLOR "R/W"
    READ
    IF m_brisanje="N"
    *Samo da preskoci*
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


***Pretraga po svi kriterijumima (F8)***
  ELSEIF LASTKEY()=-7
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Poziv na pretragu*
    DO pretraga
    IF m_brslbz<18
      SELECT 4
      USE &m_baza
      GO TOP
    ENDIF
    *Kriteriji za postavljanje na pocetak ispisa*
    m_trnslg:=1
    m_pred:=0
    SELECT 3
    USE osob
    GO TOP
    LOOP



***Ispis pomocnog menija (F10)***
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


***Indeksiranje i redjanje podataka***
*------- Pregled kolone (1)
  ELSEIF LASTKEY()=49
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
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
    *Listanje od gore*
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
    *Listanje od dole*
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
*--------- Pregled kolone (2)
  ELSEIF LASTKEY()=50
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
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
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (3)
  ELSEIF LASTKEY()=51
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
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
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (4) 
  ELSEIF LASTKEY()=52
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
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
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (5)
    ELSEIF LASTKEY()=53
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
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
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (6)
    ELSEIF LASTKEY()=54
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
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
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (7)
    ELSEIF LASTKEY()=55
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
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
    *Listanje od gore*
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
    *Listanje od dole*
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


***Pomeranje podataka***
*------- Pritisnut taster za levo
  ELSEIF LASTKEY()=19
    m_gdlist:=1
    m_ponprt="NE"
    m_zadnplj:="N"
    IF m_taster="L" .AND. m_pkol#1
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_pkol=1
      m_taster:="L"
      *Izbacuje korekciju krajnjeg desnog ispisa jer se ekran pomera u desno*
      m_kortrp:="N"
      IF m_pocpolje=1
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE U LEVO" COLOR "RB+/B"
        INKEY (1.1)
        @ 23,34 SAY "                 "
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

*------- Pritisnut taster za desno
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


*****Kretanje gore-dole*****
*------- Na gore po jedan
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

*------- Na gore skok
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

*------- Na dole po jedan
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

*------- Na dole skok
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

*------- Neka druga tipka
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






********************************************************************
PROCEDURE PRETRAGA
*********Pretraga podataka po svim mogucim kritarijumima************

*PRIPREMA*
********************************************************************
*Formiranje i punjenje baze OSOBPRET.DBF koja sadrzi osobine polja*
SELECT 6
IF FILE("osobpret.dbf")
  CLOSE 
  ERASE osobpret.dbf
ENDIF

***Baza OSOBPRET sadrzi: field_name, field_type, field_len, field_dec***
*USE &m_imbzpt
SELECT 4
COPY TO osobpret STRUCTURE EXTENDED
*CLOSE
GO TOP
SELECT 6
USE osobpret
m_brslpt:=RECCOUNT()

***Ogranicenje neregularnog "C" polja sa 999 mesta***
p_ubaciti:=999
GO TOP
DO WHILE .T.
 IF field_type="C" .AND. field_len=0
  REPLACE field_len WITH p_ubaciti 
 ELSEIF field_type="C" .AND. field_dec#0
  REPLACE field_len WITH p_ubaciti 
 ENDIF
 SKIP
 IF EOF()
  EXIT
 ENDIF
ENDDO

*Formiranje matrice za redni broj, ime, karakter i upis kriterija pretrage*
p_mtpret:=0
p_mtpret:=ARRAY(m_brslpt,5)
GO TOP
FOR e=1 TO m_brslpt
  p_mtpret[e,1]:=e
  p_mtpret[e,2]:=field_name
  p_mtpret[e,3]:=field_type
  p_mtpret[e,4]:=field_len
  p_mtpret[e,5]:=" "
  SKIP
NEXT

*Prebacivanje podataka u matricu, radi pripreme za formiranje*
p_mtvred:=0
p_mtvred:=ARRAY(m_brslpt,4)
GO TOP
FOR b=1 TO m_brslpt
  p_mtvred[b,1]:=field_name
  p_mtvred[b,2]:=field_type
  p_mtvred[b,3]:=field_len
  p_mtvred[b,4]:=field_dec
  SKIP
NEXT

**Kreiranje baze po podacima iz matrice**
SELECT 7
IF FILE("bzzavred.dbf")
  CLOSE 
  ERASE bzzavred.dbf
ENDIF
DBCREATE("bzzavred",p_mtvred)
*CLOSE
USE bzzavred
APPEND BLANK


*ISPIS PO EKRANU I UNOS VREDNOSTI ZA PRETRAGU*
********************************************************************
*************************PRIKAZ NA EKRANU*************************
CLS

***Boja  i okvira***
SET COLOR TO "GR+/B"
@ 0,0 TO 24,79 DOUBLE 

***************Zaglavlje***************
*** Ispis zaglavlja: redni broj, ime polja, karakter, vrednost***
@ 3,2 SAY "RdBr  Ime-Vrsta   K                      Vrednost"

**Uputstvo za uptrbu**
@ 23,17 SAY "Korak:"+CHR(24)+"-"+CHR(25)+"*Izmena:Enter*Pretraga:F8*Izlaz:Esc"

***Postavka promenljivih***

m_ptpkrd:=1
m_ptpkkl:=20
m_isppod:=15
m_brjc3:=15
m_itrnplj:=1


***********************************
**********   I S P I S   **********
DO WHILE .T.

  @ 4,1 CLEAR TO 21,78
  *Zaglavlje i linije u ispisu teksta*
  @ 4,1 TO 21,78
  FOR t=1 TO 17
    @ 4+t,6 SAY CHR(179)
    @ 4+t,19 SAY CHR(179)
    @ 4+t,21 SAY CHR(179)
  NEXT
  @ 4,6 SAY CHR(194)
  @ 4,19 SAY CHR(194)
  @ 4,21 SAY CHR(194)
  @ 21,6 SAY CHR(193)
  @ 21,19 SAY CHR(193)
  @ 21,21 SAY CHR(193)

  ************************************
  ********** Ispis podataka **********
  ************************************
  m_isppod:=m_isppod-(m_brjc3-1)
  m_brjc3:=1
  DO WHILE .T.
    *Ispis podataka o: rednom broju, imenu polja-karakteru*
    @ 4+m_brjc3,2 SAY ALLTRIM(STR(p_mtpret[m_isppod,1])) COLOR "BG+/B"
    @ 4+m_brjc3,7 SAY p_mtpret[m_isppod,2] COLOR "BG+/B"
    @ 4+m_brjc3,17 SAY "-"+p_mtpret[m_isppod,3] COLOR "BG+/B"
    @ 4+m_brjc3,20 SAY p_mtpret[m_isppod,5] COLOR "BG+/B"

    *Ispis polja za unos vrednosti za pretragu*
    m_vrduzmi:=" "
    IF p_mtpret[m_isppod,3]="C" .OR. p_mtpret[m_isppod,3]="L" 
      m_vrdsdr:=" "
      m_vrduzmi:=p_mtpret[m_isppod,2]
      m_vrdsdr:=&m_vrduzmi
    ELSEIF p_mtpret[m_isppod,3]="N"
      m_vrdsdr:=0
      m_vrduzmi:=p_mtpret[m_isppod,2]
      m_vrdsdr:=&m_vrduzmi
    ELSEIF p_mtpret[m_isppod,3]="D"
      m_vrdsdr:=DATE()
      m_vrduzmi:=p_mtpret[m_isppod,2]
      m_vrdsdr:=&m_vrduzmi
    ENDIF  
       
    *Ispis vrednosti pretrage*
    *Obezbedjuje da polja koja imaju vise od 56 mesta klize*
    IF p_mtpret[m_isppod,4]>56
      @ 4+m_brjc3,22 SAY m_vrdsdr PICTURE "@S56" COLOR "BG+/B"
    ELSEIF p_mtpret[m_isppod,4]<57
      @ 4+m_brjc3,22 SAY m_vrdsdr COLOR "BG+/B"
    ENDIF

    ***Izbacuje kad stigne do kraja stranice***
    IF m_brjc3=16 .OR. m_isppod=m_brslpt
      EXIT
    ENDIF

    *Brojac kruga*
    m_brjc3:=m_brjc3+1
    m_isppod:=m_isppod+1

  ENDDO

  ***************************************************
  ***************Ispis pokretnog polja***************

  **Uzimanje podatka za ispis u pokretnom polju**
  IF m_ptpkkl=20
    m_vrdsdr:=" "
    m_vrdsdr:=p_mtpret[m_itrnplj,5]
  ELSEIF m_ptpkkl=22
    *Ispis polja za unos vrednosti za pretragu*
    m_vrduzmi:=" "
    IF p_mtpret[m_itrnplj,3]="C" .OR. p_mtpret[m_itrnplj,3]="L" 
      m_vrdsdr:=" "
      m_vrduzmi:=p_mtpret[m_itrnplj,2]
      m_vrdsdr:=&m_vrduzmi
    ELSEIF p_mtpret[m_itrnplj,3]="N"
      m_vrdsdr:=0
      m_vrduzmi:=p_mtpret[m_itrnplj,2]
      m_vrdsdr:=&m_vrduzmi
    ELSEIF p_mtpret[m_itrnplj,3]="D"
      m_vrdsdr:=DATE()
      m_vrduzmi:=p_mtpret[m_itrnplj,2]
      m_vrdsdr:=&m_vrduzmi
    ENDIF  
  ENDIF


  ***Ispis pokretnog polja***
  IF m_ptpkkl=20
    @ 4+m_ptpkrd,20 SAY m_vrdsdr COLOR "B/W"
  ELSEIF m_ptpkkl=22
    *Obezbedjuje da polja koja imaju vise od 56 mesta klize*
    IF p_mtpret[m_itrnplj,4]>56
      @ 4+m_ptpkrd,22 SAY m_vrdsdr PICTURE "@S56" COLOR "B/W"
    ELSEIF p_mtpret[m_itrnplj,4]<57
      @ 4+m_ptpkrd,22 SAY m_vrdsdr COLOR "B/W"
    ENDIF
  ENDIF

  **Ispis podataka o bazi, slogovima i poljima**
  @ 1,1 CLEAR TO 1,77
  @ 1,1 SAY "Baza:"+ALLTRIM(UPPER(m_suvabz))+;
            " * Polje:"+ALLTRIM(STR(m_itrnplj))+"/"+ALLTRIM(STR(m_brslpt))+;
            " * UNESI: kriterij (K) i vrednost" COLOR "G+/B"

  *****Zastoj za prihvat pritisnutog tastera*****
    INKEY(0)
  ***********************************************


***Izlazak iz pretrage podataka, na nivo za pregled i azuriranje***
*------- Prekid i vracanje u izbor databaze
  IF LASTKEY()=27
    CLOSE
    ERASE bzzavred.dbf
    SELECT 6
    CLOSE
    ERASE osobpret.dbf
    RETURN


***Prihvatanje odabranog podatka i njegova izmena***
  ELSEIF LASTKEY()=13
    **Azuriranje podataka**
    SET CONFIRM ON
    SET CURSOR ON
    *Unos kritarija*
    IF m_ptpkkl=20
      @ 4+m_ptpkrd,20 GET m_vrdsdr VALID (m_vrdsdr $ "><= ") COLOR "R/W"
      READ
      p_mtpret[m_itrnplj,5]:=m_vrdsdr
    *Unos vrednosti*
    ELSEIF m_ptpkkl=22
      *Obezbedjuje da polja koja imaju vise od 56 mesta klize*
      IF p_mtpret[m_itrnplj,4]>56
        @ 4+m_ptpkrd,22 GET m_vrdsdr PICTURE "@S56" COLOR "R/W"
      ELSEIF p_mtpret[m_itrnplj,4]<57
        @ 4+m_ptpkrd,22 GET m_vrdsdr COLOR "R/W"
      ENDIF
      READ
      REPLACE &m_vrduzmi WITH m_vrdsdr
    ENDIF
    SET CONFIRM OFF
    SET CURSOR OFF
    LOOP


***Izlazak iz upisa radi pretrage (F8)***
*------- Pretraga i ubacivanje u bazu nadjenih podataka
  ELSEIF LASTKEY()=-7
    GO TOP
    EXIT


***Pomeranje podataka***
*------- Pritisnut taster za levo
  ELSEIF LASTKEY()=19
    IF m_ptpkkl=20
      LOOP
    ENDIF
    m_ptpkkl:=20
    LOOP


*------- Pritisnut taster za desno
  ELSEIF LASTKEY()=4
    IF m_ptpkkl=22
      LOOP
    ENDIF
    m_ptpkkl:=22
    LOOP


*****Kretanje gore-dole*****
*------- Na gore po jedan
  ELSEIF LASTKEY()=5 
    IF m_itrnplj=1 
      LOOP
    ENDIF
    IF m_ptpkrd=1
      m_isppod:=m_isppod-1
    ELSEIF m_ptpkrd>1
      m_ptpkrd:=m_ptpkrd-1
    ENDIF
    m_itrnplj:=m_itrnplj-1
    LOOP


*------- Na dole po jedan
  ELSEIF LASTKEY()=24 
    IF m_itrnplj=m_brslpt
      LOOP
    ENDIF
    IF m_ptpkrd=16
      m_isppod:=m_isppod+1
    ELSEIF m_ptpkrd<16
      m_ptpkrd:=m_ptpkrd+1
    ENDIF
    m_itrnplj:=m_itrnplj+1
    LOOP


*------- Neka druga tipka
  ELSE
    LOOP
  ENDIF

ENDDO




*PRETRAGA PODATAKA I PUNJENJE BAZE SA NADJENIM PODACIMA*
*********************************************************


**Provera da li ima ma kakav podatak za pretragu**
m_imavrd:="N"
FOR c=1 TO m_brslpt
  m_ptpodx:=" "
  m_ptpodx:=p_mtpret[c,2]
  IF ! EMPTY(&m_ptpodx)
    m_imavrd:="D"
    EXIT
  ENDIF
NEXT
IF m_imavrd="N"
  CLOSE 
  ERASE bzzavred.dbf
  SELECT 6
  CLOSE
  ERASE osobpret.dbf
  RETURN
ENDIF

*Formiranje baze za punjenje nadjenih podataka*
SELECT 8
IF FILE("bzzapret.dbf")
  CLOSE 
  ERASE bzzapret.dbf
ENDIF
DBCREATE("bzzapret",p_mtvred)
USE bzzapret

***Pretraga i punjenje***
SELECT 7
GO TOP

***Pretraga po prvom kriteriju i punjenje nadjenim podacima***
**Po zadatoj vrednosti**
@ 23,1 CLEAR TO 23,78
@ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"

m_brptrg:=0
m_kraj1p:="N"
DO WHILE .T.

  m_brptrg:=m_brptrg+1
  m_vrxptr:="VREDNOST"

  *Uzimanje sadrzaja za uporedjivanje*
  m_provim:=" "
  IF p_mtpret[m_brptrg,3]="C" .OR. p_mtpret[m_brptrg,3]="L" 
    m_uuzmsdr:=" "
    m_provim:=p_mtpret[m_brptrg,2]
    m_uuzmsdr:=&m_provim
  ELSEIF p_mtpret[m_brptrg,3]="N"
    m_uuzmsdr:=0
    m_provim:=p_mtpret[m_brptrg,2]
    m_uuzmsdr:=&m_provim
  ELSEIF p_mtpret[m_brptrg,3]="D"
    m_uuzmsdr:=DATE()
    m_provim:=p_mtpret[m_brptrg,2]
    m_uuzmsdr:=&m_provim
  ENDIF  

  **Vraca ako je polje za vrednost prazno**
  *Preskace nepotpune podatke*
  IF p_mtpret[m_brptrg,3]="D" .OR. p_mtpret[m_brptrg,3]="L" .OR. ;
     p_mtpret[m_brptrg,3]="C" .AND. EMPTY(m_uuzmsdr)
     LOOP
  ENDIF
  IF p_mtpret[m_brptrg,3]="D" .OR. p_mtpret[m_brptrg,3]="L" .OR. ;
     p_mtpret[m_brptrg,3]="N" .AND. EMPTY(p_mtpret[m_brptrg,5])
     LOOP
   ENDIF
   *Odredjuje vrstu pretrage*
   IF p_mtpret[m_brptrg,3]="C" .AND. EMPTY(p_mtpret[m_brptrg,5]) 
     m_vrxptr:="IZRAZ"
   ENDIF

  SELECT 4
 IF m_vrxptr = "VREDNOST"

  *Uzimanje uslova pretrage*
  m_pprtga:=" "
  m_pprtga:=p_mtpret[m_brptrg,5]

  *Uzimanje vrste sadrzaja za pretragu*
  m_provim:=" "
  IF p_mtpret[m_brptrg,3]="C" .OR. p_mtpret[m_brptrg,3]="L" 
    m_puzmsdr:=" "
    m_provim:=p_mtpret[m_brptrg,2]
  ELSEIF p_mtpret[m_brptrg,3]="N"
    m_puzmsdr:=0
    m_provim:=p_mtpret[m_brptrg,2]
  ELSEIF p_mtpret[m_brptrg,3]="D"
    m_puzmsdr:=DATE()
    m_provim:=p_mtpret[m_brptrg,2]
  ENDIF  

  **Prva pretraga**
  m_bspret:=0
  DO WHILE .T.

    *Uzimanje sadrzaja za pretragu*
    m_puzmsdr:=&m_provim
    IF m_pprtga = "="
      IF m_uuzmsdr=m_puzmsdr 
        *Ubacuje nadjeni podatak*
        SELECT 8
        APPEND BLANK
        FOR y=1 TO m_brslpt
          *Uzimanje sadrzaja za prepisivanje*
          m_rprovim:=" "
          IF p_mtpret[y,3]="C" .OR. p_mtpret[y,3]="L" 
            m_ruzmsdr:=" "
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="N"
            m_ruzmsdr:=0
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="D"
            m_ruzmsdr:=DATE()
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ENDIF  
          REPLACE &m_rprovim WITH m_ruzmsdr
        NEXT
        SELECT 4
      ENDIF
    ELSEIF m_pprtga = ">"
      IF m_puzmsdr>m_uuzmsdr
        *Ubacuje nadjeni podatak*
        SELECT 8
        APPEND BLANK
        FOR y=1 TO m_brslpt
          *Uzimanje sadrzaja za prepisivanje*
          m_rprovim:=" "
          IF p_mtpret[y,3]="C" .OR. p_mtpret[y,3]="L" 
            m_ruzmsdr:=" "
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="N"
            m_ruzmsdr:=0
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="D"
            m_ruzmsdr:=DATE()
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ENDIF  
          REPLACE &m_rprovim WITH m_ruzmsdr
        NEXT
        SELECT 4
      ENDIF
    ELSEIF m_pprtga = "<"
      IF m_puzmsdr<m_uuzmsdr
        *Ubacuje nadjeni podatak*
        SELECT 8
        APPEND BLANK
        FOR y=1 TO m_brslpt
          *Uzimanje sadrzaja za prepisivanje*
          m_rprovim:=" "
          IF p_mtpret[y,3]="C" .OR. p_mtpret[y,3]="L" 
            m_ruzmsdr:=" "
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="N"
            m_ruzmsdr:=0
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="D"
            m_ruzmsdr:=DATE()
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ENDIF  
          REPLACE &m_rprovim WITH m_ruzmsdr
        NEXT
        SELECT 4
      ENDIF
    ENDIF
    SKIP
    IF EOF()
      *Ako nije upisani i nadjeno nista*
      SELECT 8
      m_bspret:=LASTREC()
      IF m_bspret=0
        CLS
        @ 12,15 SAY "Nema korektnih kriterija - pretraga neuspesna !"
        INKEY(7.5)
        CLOSE
        ERASE bzzavred.dbf
        SELECT 6
        CLOSE
        ERASE osobpret.dbf
        RETURN
      ENDIF
      *Izlazak*
      SELECT 4
      GO TOP
      m_kraj1p:="D"
      EXIT
    ENDIF
  ENDDO

 ELSEIF m_vrxptr = "IZRAZ"

  **Pretraga po zadatom delu izraza**
  m_xbrptpl:=0
  m_xbrptzn:=0
  XBROJX:=0
  m_bspret:=0
  DO WHILE .T.
  XBROJX:=XBROJX+1

    *Kraj pretrage*
    IF EOF()
      *Ako nije upisano i nadjeno nista*
      SELECT 8
      m_bspret:=LASTREC()
      IF m_bspret=0
        CLS
        @ 12,15 SAY "Nema korektnih kriterija - pretraga neuspesna !"
*        @ 14,15 SAY STR(m_xbrptpl)+m_puzmsdr+STR(m_xbrptzn)+m_uuzmsdr+STR(XBROJX)
        INKEY(7.5)
        CLOSE
        ERASE bzzavred.dbf
        SELECT 6
        CLOSE
        ERASE osobpret.dbf
        RETURN
      ENDIF
      *Izlazak*
      SELECT 4
      GO TOP
      m_kraj1p:="D"
      EXIT
    ENDIF

    *Uzimanje sadrzaja za pretragu*
    m_puzmsdr:=&m_provim

    m_xbrptpl:=LEN(ALLTRIM(m_puzmsdr))
    m_xbrptzn:=LEN(ALLTRIM(m_uuzmsdr))
    *Ako je zadato vise znakova nego sto ima polja, nema sta da se trazi*
    IF m_xbrptpl<m_xbrptzn
      SKIP
      LOOP
    ENDIF
    *Pretraga u okviru jednog polja*
    m_xnasobre:="N"
    m_uuzmsdr:=UPPER(ALLTRIM(m_uuzmsdr))
    FOR v=1 TO m_xbrptpl+1-m_xbrptzn
      m_xxuporedj:=" "
      m_xxuporedj:=UPPER(SUBSTR(m_puzmsdr,v,m_xbrptzn))
      *Ako je negde pronadjeno izbacuje iz dalje pretrage*
      IF m_uuzmsdr = m_xxuporedj
        m_xnasobre:="D"
        EXIT
      ENDIF
    NEXT
    *Ubacuje nadjeni slog*
    IF m_xnasobre="D"
      SELECT 8
      APPEND BLANK
      FOR y=1 TO m_brslpt
        *Uzimanje sadrzaja za prepisivanje*
        m_rprovim:=" "
        IF p_mtpret[y,3]="C" .OR. p_mtpret[y,3]="L" 
          m_ruzmsdr:=" "
          m_rprovim:=p_mtpret[y,2]
          m_ruzmsdr:=D->&m_rprovim
        ELSEIF p_mtpret[y,3]="N"
          m_ruzmsdr:=0
          m_rprovim:=p_mtpret[y,2]
          m_ruzmsdr:=D->&m_rprovim
        ELSEIF p_mtpret[y,3]="D"
          m_ruzmsdr:=DATE()
          m_rprovim:=p_mtpret[y,2]
          m_ruzmsdr:=D->&m_rprovim
        ENDIF  
        REPLACE &m_rprovim WITH m_ruzmsdr
      NEXT
      SELECT 4
    ENDIF
    SKIP
  ENDDO

 ENDIF

  *Kraj pretrage*
  IF  m_kraj1p = "D"
    EXIT
  ENDIF

ENDDO


******************************************************
*** Da se prazni baza preko ostalih zadatih uslova ***

SELECT 8
GO TOP

DO WHILE .T.

  *Kraj pretrage potvrda brisanja*
  IF m_brslpt=m_brptrg
    PACK
    EXIT
  ENDIF

  m_brptrg:=m_brptrg+1
  m_vrxptr:="VREDNOST"

  *Uzimanje sadrzaja za uporedjivanje*
  m_provim:=" "
  IF p_mtpret[m_brptrg,3]="C" .OR. p_mtpret[m_brptrg,3]="L" 
    m_uuzmsdr:=" "
    m_provim:=p_mtpret[m_brptrg,2]
  ELSEIF p_mtpret[m_brptrg,3]="N"
    m_uuzmsdr:=0
    m_provim:=p_mtpret[m_brptrg,2]
  ELSEIF p_mtpret[m_brptrg,3]="D"
    m_uuzmsdr:=DATE()
    m_provim:=p_mtpret[m_brptrg,2]
  ENDIF  
  m_uuzmsdr:=G->&m_provim

  *Preskace nepotpune podatke**
  IF p_mtpret[m_brptrg,3]="D" .OR. p_mtpret[m_brptrg,3]="L" .OR. ;
     p_mtpret[m_brptrg,3]="C" .AND. EMPTY(m_uuzmsdr)
     LOOP
  ENDIF
  IF p_mtpret[m_brptrg,3]="D" .OR. p_mtpret[m_brptrg,3]="L" .OR. ;
     p_mtpret[m_brptrg,3]="N" .AND. EMPTY(p_mtpret[m_brptrg,5])
     LOOP
  ENDIF
  *Odredjuje vrstu pretrage*
  IF p_mtpret[m_brptrg,3]="C" .AND. EMPTY(p_mtpret[m_brptrg,5])
    m_vrxptr:="IZRAZ"
  ENDIF

 IF m_vrxptr = "VREDNOST"

  DO WHILE .T.

    *Uzimanje vrste sadrzaja za pretragu*
    m_provim:=" "
    IF p_mtpret[m_brptrg,3]="C" .OR. p_mtpret[m_brptrg,3]="L" 
      m_puzmsdr:=" "
      m_provim:=p_mtpret[m_brptrg,2]
    ELSEIF p_mtpret[m_brptrg,3]="N"
      m_puzmsdr:=0
      m_provim:=p_mtpret[m_brptrg,2]
    ELSEIF p_mtpret[m_brptrg,3]="D"
      m_puzmsdr:=DATE()
      m_provim:=p_mtpret[m_brptrg,2]
    ENDIF  
    *Uzimanje sadrzaja za pretragu*
    m_puzmsdr:=&m_provim

    IF p_mtpret[m_brptrg,5] = "="
      IF m_puzmsdr#m_uuzmsdr
        *Brise nadjeni podatak*
        DELETE
      ENDIF
    ELSEIF p_mtpret[m_brptrg,5] = ">"
      IF m_puzmsdr<m_uuzmsdr .OR. m_puzmsdr=m_uuzmsdr
        *Brise nadjeni podatak*
        DELETE
      ENDIF
    ELSEIF p_mtpret[m_brptrg,5] = "<"
      IF m_puzmsdr>m_uuzmsdr .OR. m_puzmsdr=m_uuzmsdr
        *Brise nadjeni podatak*
        DELETE
      ENDIF
    ENDIF
    SKIP
    IF EOF()
      GO TOP
      EXIT
    ENDIF
  ENDDO

 ELSEIF m_vrxptr = "IZRAZ"

  DO WHILE .T.

    *Uzimanje sadrzaja za pretragu*
    m_provim:=" "
    m_puzmsdr:=" "
    m_provim:=p_mtpret[m_brptrg,2]
    *Uzimanje sadrzaja za pretragu*
    m_puzmsdr:=&m_provim


    **Pretraga po zadatom delu izraza**
    m_xbrptpl:=0
    m_xbrptpl:=0

    m_xbrptpl:=LEN(ALLTRIM(m_puzmsdr))
    m_xbrptzn:=LEN(ALLTRIM(m_uuzmsdr))
    *Ako je zadato vise znakova nego sto polja ima, nema sta da se trazi*
    IF m_xbrptpl<m_xbrptzn
      EXIT
    ENDIF
    *Pretraga u okviru jednog polja*
    m_xnasobre:="N"
    m_x1uporedj:=" "
    m_x1uporedj:=UPPER(ALLTRIM(m_uuzmsdr))
    FOR v=1 TO m_xbrptpl+1-m_xbrptzn
      m_x2uporedj:=SPACE(m_xbrptzn)
      m_x2uporedj:=UPPER(SUBSTR(m_puzmsdr,v,m_xbrptzn))
      *Ako je negde pronadjeno izbacuje iz dalje pretrage*
      IF m_x1uporedj = m_x2uporedj
        m_xnasobre:="D"
        EXIT
      ENDIF
    NEXT
    *Brise nadjeni podatak*
    IF m_xnasobre="N"
      DELETE
    ENDIF
    SKIP
    IF EOF()
      GO TOP
      EXIT
    ENDIF
  ENDDO

 ENDIF

ENDDO


     *********************************************
     ***********    ISPIS I PREGLED   ************


********Manipulacija podacima iz pretrage izabrane baze podataka**********

*****Zadata baza*****
**Broj slogova koji zadovoljavaju kriterijum pretrage**
m_prtbrs:=LASTREC()

*************************PRIKAZ NA EKRANU*************************
CLS

GO TOP

***Boja okvira i zaglavlja***
SET COLOR TO "BG+/B"
@ 0,0 TO 24,79 DOUBLE COLOR "GR+/B"

***************Zaglavlje***************
***Boja poruka***
SET COLOR TO "G+/B"

***Postavka promenljivih***
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

  **Uputstvo za uptrbu**
  @ 23,1 CLEAR TO 23,78
  *Ispisuje zavisno od potrebe (F10)*
  IF m_ispF10="PRVI"
    @ 23,2 SAY "Korak:"+CHR(24)+"-"+CHR(25)+"*Skok:PageUp"+CHR(24)+;
               "-PageDown"+CHR(25)+"*Izmena:Enter*Izlaz:Esc*F10(F-1,2,3,4,5,6)"
  ELSEIF m_ispF10="DRUGI"
    @ 23,1 SAY "F1:Trazi_polje*F2:Trazi_izraz*F3:Opet_F1-2*F4:Skok*"+;
               "F5:Nov_slog*F6:Brise*F10:P"
  ENDIF
  SELECT 3
  GO m_pocpolje
  m_brmsuk:=0
  m_uzetoplj:=0
  m_pocmesto:=0

  ***Za DESNO (samo racuna parametre za ispis na ekranu)***
  IF m_taster="D" 
    DO WHILE .T.
      m_brmspl:=0
      m_brmsdc:=0
      m_uzetoplj:=m_uzetoplj+1
  
      m_brmspl:=field_len
      m_brmsdc:=field_dec

      ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
      IF m_brmspl<10
        m_brmspl:=10
      ENDIF
      
      ***Sabira polja koja treba da se prikazu***
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

  ***Za LEVO (samo racuna parametre za ispis na ekranu)***
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
  
      ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
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

  ***Ispis 's desna za kretanje u levo***
  IF m_taster="L" .AND. BOF()
    m_taster:="D"
    m_prvoplj:="D"
    m_brpslnd:="D"
    LOOP
  ENDIF

  *****Iracunavanje pocetka ispisa*****
  IF m_brmsuk>74
    m_brmsuk:=74
  ENDIF
  m_pocmesto:=39-INT(m_brmsuk/2)


  ***********************************
  **********   I S P I S   **********

  @ 2,1 CLEAR TO 22,78
  @ 4,1 TO 22,78 COLOR "GR+/B"

  ***** Ispis zaglavlja: ime polja, karakter, broj mesta i decimala *****
  *Promenljive zaglavlje*
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

  *Postavka matrica*
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

  ***Ispisuje zaglavlje i priprema ekran za ispis podataka***
  DO WHILE .T.
    m_brjc1:=m_brjc1+1

    m_brmspl:=field_len
    m_brmsdc:=field_dec

    ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
    IF m_brmspl<10
      m_brmspl:=10
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zauzima vise od 74 mesta***
    IF m_brmspl>74
      m_brmspl:=74
    ENDIF

    ***Odredjuje pocetak ispisa podataka u zaglavlju na sredini***
    m_mestisp:=m_zpocmesto+INT((m_brmspl-8)/2)
    m_kollin:=m_zpocmesto+m_brmspl+1

    ***Vraca pravu vrednost onom blesavom i onom normalnom polju***
    IF field_type="C" .AND. field_len=888 .AND. field_dec=888
      m_brmpis:=1024
      m_brmdis:=0
    ELSE
      m_brmpis:=field_len
      m_brmdis:=field_dec
    ENDIF

    **********Ispis zaglavlja**********
    @ 2,m_mestisp SAY field_name COLOR "GR+/B"
    @ 3,m_mestisp SAY "("+ALLTRIM(STR(m_brjc1))+")"+;
                      field_type+"-"+ALLTRIM(STR(m_brmpis))+;
                      "-"+ALLTRIM(STR(m_brmdis)) COLOR "GR+/B"
    *********************************************************

    ***Punjenje matrica osobinama polja za ispis podataka***
    p_mtrime[m_brjc1]:=field_name
    p_mtrtip[m_brjc1]:=field_type
    p_mtrplj[m_brjc1]:=field_len

    ***Izbacuje ako je to sve sto treba da se prikaze u ovom krugu***
    SKIP
    IF m_brjc1=m_uzetoplj
      EXIT
    ENDIF

    ***Ispis uzduzne razdelne linije***
    FOR w=1 TO 17
      m_redlin:=4+w
      @ m_redlin,m_kollin SAY CHR(179) COLOR "GR+/B"
    NEXT
    @ 4,m_kollin SAY CHR(194) COLOR "GR+/B"
    @ 22,m_kollin SAY CHR(193) COLOR "GR+/B"

    ***Pomera pocetno mesto za ispis i dodaje mesto za liniju***
    m_zpocmesto:=m_zpocmesto+m_brmspl+1

  ENDDO

  ************************************
  ********** Ispis podataka **********
  ************************************

  m_kolpod:=m_pocmesto+1
  m_brjc2:=1

  ***Pocetak ispisa JEDNE TURE (EKRANA)***
  DO WHILE .T.

    m_redpod:=5
    p_mtrpcm[m_brjc2]:=m_kolpod

    ***Ispisuje JEDNU KOLONU od izabranog polja***
    DO WHILE .T.
      m_imeuzmi:=" "
      IF p_mtrtip[m_brjc2]="C" .OR. p_mtrtip[m_brjc2]="L"
        m_sadrzaj:=" "
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=H->&m_imeuzmi
      ELSEIF p_mtrtip[m_brjc2]="N"
        m_sadrzaj:=0
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=H->&m_imeuzmi
      ELSEIF p_mtrtip[m_brjc2]="D"
        m_sadrzaj:=DATE()
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=H->&m_imeuzmi
      ENDIF  
       
      ***Ispis***
      *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
      IF p_mtrplj[m_brjc2]>74
        @ m_redpod,m_kolpod SAY m_sadrzaj PICTURE "@S74" COLOR "BG+/B"
      ELSEIF p_mtrplj[m_brjc2]<75
        @ m_redpod,m_kolpod SAY m_sadrzaj COLOR "BG+/B"
      ENDIF

      SELECT 8
      SKIP
      IF EOF()
        GO BOTTOM
        EXIT
      ENDIF 
      SELECT 3

      m_redpod:=m_redpod+1

      ***Izbacuje kad stigne do kraja stranice***
      IF m_redpod=22
        EXIT
      ENDIF
    ENDDO

    ***Vraca ispis za sledecu kolonu***
    SELECT 8
    SKIP-(m_redpod-5)
    SELECT 3

    ***Izbacuje ako je to sve sto treba da se prikaze u ovom krugu***
    IF m_brjc2=m_uzetoplj
      EXIT
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
    IF p_mtrplj[m_brjc2]<10
      p_mtrplj[m_brjc2]:=10
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zauzima vise od 74 mesta***
    IF p_mtrplj[m_brjc2]>74
      p_mtrplj[m_brjc]:=74
    ENDIF

    ***Pomera pocetno mesto za ispis i dodaje mesto za zarez i za liniju***
    m_kolpod:=m_kolpod+p_mtrplj[m_brjc2]+1

    *Brojac kruga*
    m_brjc2:=m_brjc2+1

  ENDDO

  ***************************************************
  ***************Ispis pokretnog polja***************

  **Postavljanje na polje posle pomeranja ekrana**
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

  **Uzimanje podatka za ispis u pokretnom polju**
  *Podesavanje na zeljeni slog*
  SELECT 8
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
  ***Odredjuje mesto za ispis***
  m_pokkol:=p_mtrpcm[m_pkol]
  m_pokred:=5+m_pred

  ***Ispis pokretnog polja***
  *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
  IF p_mtrplj[m_pkol]>74
    @ m_pokred,m_pokkol SAY m_pokpolje PICTURE "@S74" COLOR "B/W"
  ELSEIF p_mtrplj[m_pkol]<75
    @ m_pokred,m_pokkol SAY m_pokpolje COLOR "B/W"
  ENDIF
  *****************************************

  **Korekcija za broj polja, kad ide s' desna na pocetno**
  IF m_brpslnd="D"
    m_brpslnd:="N"
    m_trnplj:=m_pkol
  ENDIF

  **Korekcija ako je krajnji desni ispis o bazi, slogovima i poljima**
  IF m_kortrp="D"
    m_trnplj:=m_brsl-m_uzetoplj+m_pkol
  ENDIF

  **Ispis podataka o bazi, slogovima i poljima**
  @ 1,1 CLEAR TO 1,78
  @ 1,1 SAY "Pretrazena baza:"+ALLTRIM(UPPER(m_baza))+;
            " * Slog:"+ALLTRIM(STR(m_trnslg))+"/"+ALLTRIM(STR(m_prtbrs))+;
            " * Polje:"+ALLTRIM(STR(m_trnplj))+"/"+;
            ALLTRIM(STR(m_brsl)) COLOR "R+/B"

  *****Zastoj za prihvat pritisnutog tastera*****
  IF m_novupis="NIJE"
    INKEY(0)
  ENDIF

***Izlazak iz pregleda podataka, na nivo za izbor baze***
*------- Prekid i vracanje u izbor databaze
  IF LASTKEY()=27
    CLOSE
    ERASE bzzavred.dbf
    SELECT 6
    CLOSE
    ERASE osobpret.dbf
    SELECT 8
    CLOSE
    ERASE bzzapret.dbf
    ERASE gdlistpg.ntx
    RETURN


***Prihvatanje odabranog podatka i njegova izmena***
*  ELSEIF LASTKEY()=13
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    SELECT 8
    **Azuriranje podataka**
    SET CONFIRM ON
    SET CURSOR ON
    *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
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

***Pretraga po zadatom kriteriju (F1)***
  ELSEIF LASTKEY()=28
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    SET CONFIRM ON
    SET CURSOR ON
    *Unos kriterija*
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
    *Unos vrednosti*
    SELECT 8
    *Otvaranje praznog sloga radi uzimanja praznih polja*
    APPEND BLANK
    *Uzimanje praznog polja za upis*
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
    *Obezbedjuje da polja koja imaju vise od 42 mesta klize*
    IF p_mtrplj[m_pkol]>42
      @ 23,20 SAY " * Vrednost:" GET m_vrednost PICTURE "@S42" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<43
      @ 23,20 SAY " * Vrednost:" GET m_vrednost COLOR "R/W"
    ENDIF
    READ
    SET CONFIRM OFF
    SET CURSOR OFF
    *Brisanje slog-modela za unos*
    DELETE
    PACK
    *Kriteriji za postavljanje na pocetak ispisa*
    m_trnslg:=1
    m_pred:=0
    *Omogucuje izlaz*
    IF LASTKEY()=27
      GO TOP
      LOOP
    ENDIF  
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
    **Pretraga**
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
    *Neuspesna pretraga*
    IF EOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,31 SAY "Pretraga neuspesna"
      INKEY(1.1)
      GO TOP
      LOOP
    ENDIF
    m_ponprt:="DA"
    m_vrsprt:="F1"
    *Postavljanje  na nadjeni slog*
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


***Pretraga po zadatom delu izraza (F2)***
  ELSEIF LASTKEY()=-1
    *Obezbedjuje da se ispis ne pomera levo-desno*
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    *Vraca ako tip polja nije karakter*
    IF p_mtrtip[m_pkol] # "C"
      LOOP
    ENDIF
    *Prebacivanje radnog polja*
    SELECT 8
    *Otvaranje praznog sloga radi uzimanja praznih polja*
    APPEND BLANK
    *Uzimanje praznog polja za upis*
    m_imeuzmi:=" "
    m_prtizraz:=" "
    m_imeuzmi:=p_mtrime[m_pkol]
    m_prtizraz:=&m_imeuzmi
    *Brisanje slog-modela za unos*
    DELETE
    PACK
    *Kriteriji za postavljanje na pocetak ispisa*
    m_trnslg:=1
    m_pred:=0
    GO TOP
    *Unos izraza*
    SET CONFIRM ON
    SET CURSOR ON
    @ 23,1 CLEAR TO 23,78
    *Obezbedjuje da polja koja imaju vise od 62 mesta klize*
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
    *Pretraga polja po zadatom izrazu*
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
    m_prebroj:=0
    DO WHILE .T.
      m_prebroj:=m_prebroj+1
      m_brptpl:=LEN(ALLTRIM(&m_imeuzmi))
      m_brptzn:=LEN(ALLTRIM(m_prtizraz))
      *Ako je zadato vise znakova nego sto polja ima, nema sta da se trazi*
      IF m_brptpl<m_brptzn
        SKIP
        LOOP
      ENDIF
      *Pretraga po jednom polju*
      m_nasobre:="N"
      m_2uporedj:=" "
      m_2uporedj:=UPPER(ALLTRIM(m_prtizraz))
      FOR a=1 TO m_brptpl+1-m_brptzn
        m_1uporedj:=SPACE(m_brptzn)
        m_1uporedj:=UPPER(SUBSTR(&m_imeuzmi,a,m_brptzn))
        *Ako je negde pronadjeno izbacuje iz dalje pretrage*
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
    *Neuspesna pretraga*
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
    *Postavljanje  na nadjeni slog*
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


***Ponovna pretraga po prethodno zadatom kriterijumu ili delu izraza (F3)***
  ELSEIF LASTKEY()=-2
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    **Ne dozvoljava ponovnu pretragu**
    IF m_ponprt="NE"
      @ 23,1 CLEAR TO 23,78
      @ 23,25 SAY "Unesite kriterijum pretrage"
      INKEY(1.6)
      LOOP
    ENDIF
    *Otvaranje radnog polja*
    SELECT 8
    *Postavljanje na naredni slog za pretragu*
    GO TOP
    SKIP m_trnslg
    m_trnslg:=m_trnslg+1

    **Ponovna pretraga po zadatoj vrednosti**
    IF m_vrsprt="F1"
      **Pretraga**
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
      *Neuspesna pretraga*
      IF EOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,33 SAY "Nema podataka"
        INKEY(1.1)
        *Kriteriji za postavljanje na pocetak ispisa*
        m_trnslg:=1
        m_pred:=0
        GO TOP
        LOOP
      ENDIF
      *Postavljanje  na nadjeni slog*
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

    **Pretraga po zadatom delu izraza**
    ELSEIF m_vrsprt="F2"
      *Pretraga polja po zadatom izrazu*
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"
      DO WHILE .T.
        m_prebroj:=m_prebroj+1
        m_brptpl:=LEN(ALLTRIM(&m_imeuzmi))
        m_brptzn:=LEN(ALLTRIM(m_prtizraz))
        *Ako je zadato vise znakova nego sto polja ima, nema sta da se trazi*
        IF m_brptpl<m_brptzn
          SKIP
          LOOP
        ENDIF
        *Pretraga u okviru jednog polja*
        m_nasobre:="N"
        m_2uporedj:=" "
        m_2uporedj:=UPPER(ALLTRIM(m_prtizraz))
        FOR a=1 TO m_brptpl+1-m_brptzn
          m_1uporedj:=SPACE(m_brptzn)
          m_1uporedj:=UPPER(SUBSTR(&m_imeuzmi,a,m_brptzn))
          *Ako je negde pronadjeno izbacuje iz dalje pretrage*
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
      *Neuspesna pretraga*
      IF EOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,33 SAY "Nema podataka"
        INKEY(1.6)
        *Kriteriji za postavljanje na pocetak ispisa*
        m_trnslg:=1
        m_pred:=0
        GO TOP
        LOOP
      ENDIF
      *Postavljanje  na nadjeni slog*
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


***Skok na zadati slog (red) (F4)***
  ELSEIF LASTKEY()=-3
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    *Uzimanje broja za skok*
    SET CONFIRM ON
    SET CURSOR ON
    DO WHILE .T.
      @ 23,1 CLEAR TO 23,78
      @ 23,1 SAY "Unesite broj sloga, ne veci od: "
      m_skokna:=m_prtbrs
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
    SELECT 8
    *Skok na zadati slog*
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


***Upis novog sloga (reda) i novih podataka (F5)***
*  ELSEIF LASTKEY()=-4
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 8
    **Uklanja indeksnu bazu**
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    m_gdlist:=0
    **Omogucuje otvaranje novog sloga i postavlja polje na mesto za upis**
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
    **Upis novog podatka**
    SET CONFIRM ON
    SET CURSOR ON
    *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
    IF p_mtrplj[m_pkol]>74
      @ m_pokred,m_pokkol GET m_pokpolje PICTURE "@S74" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<75
      @ m_pokred,m_pokkol GET m_pokpolje COLOR "R/W"
    ENDIF
    READ
    *Ako nije nista upisano, brse novi slog*
    IF EMPTY(m_pokpolje)
      *Vraca ako je baza prazna*
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
    **Upis**
    SKIP m_pred
    REPLACE &m_imeuzmi WITH m_pokpolje
    SKIP -m_pred
    SET CONFIRM OFF
    SET CURSOR OFF
    LOOP

***Brisanje sloga na kome se nalazi pokretno polje (F6)***
*  ELSEIF LASTKEY()=-5
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    @ 23,1 CLEAR TO 23,78
    @ 23,17 SAY "Potvrdite brisanje obelezenog sloga (D/N):"
    m_brisanje:="N"
    @ 23,60 GET m_brisanje PICTURE "!" VALID(m_brisanje $ "DdNn") COLOR "R/W"
    READ
    IF m_brisanje="N"
    *Samo da preskoci*
    ELSEIF m_brisanje="D"
      SELECT 8
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


***Pretraga po svi kriterijumima (F8)***
*  ELSEIF LASTKEY()=-7
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Poziv na pretragu*
    DO pretraga
    IF m_brslbz<18
      SELECT 8
      GO TOP
    ENDIF
    *Kriteriji za postavljanje na pocetak ispisa*
    m_trnslg:=1
    m_pred:=0
    LOOP


***Stampa pretrazenih podataka (F9)***
  ELSEIF LASTKEY()=-8
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    CLS
    @ 12,21 SAY "S T A M P A NJ E nije u funkciji !!!"
    INKEY (0)
    LOOP


***Ispis pomocnog menija (F10)***
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
      SELECT 8
      GO TOP
    ENDIF
    LOOP


***Indeksiranje i redjanje podataka***
*------- Pregled kolone (1)
  ELSEIF LASTKEY()=49
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
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
    *Listanje od dole*
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
*--------- Pregled kolone (2)
  ELSEIF LASTKEY()=50
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<2
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (3)
  ELSEIF LASTKEY()=51
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<3
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (4) 
  ELSEIF LASTKEY()=52
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<4
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (5)
    ELSEIF LASTKEY()=53
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<5
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (6)
    ELSEIF LASTKEY()=54
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<6
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
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
    *Listanje od dole*
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

*-------- Pregled kolone (7)
    ELSEIF LASTKEY()=55
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    IF m_uzetoplj<7
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
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
    *Listanje od dole*
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


***Pomeranje podataka***
*------- Pritisnut taster za levo
  ELSEIF LASTKEY()=19
    m_gdlist:=1
    m_ponprt="NE"
    m_zadnplj:="N"
    IF m_taster="L" .AND. m_pkol#1
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_pkol=1
      m_taster:="L"
      *Izbacuje korekciju krajnjeg desnog ispisa jer se ekran pomera u desno*
      m_kortrp:="N"
      IF m_pocpolje=1
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE U LEVO" COLOR "RB+/B"
        INKEY (1.1)
        @ 23,34 SAY "                 "
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

*------- Pritisnut taster za desno
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


*****Kretanje gore-dole*****
*------- Na gore po jedan
  ELSEIF LASTKEY()=5 
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_pred=0
      SELECT 8
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

*------- Na gore skok
  ELSEIF LASTKEY()=18
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 8
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

*------- Na dole po jedan
  ELSEIF LASTKEY()=24 
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    m_pred:=m_pred+1
    SELECT 8
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

*------- Na dole skok
  ELSEIF LASTKEY()=3
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 8
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

*------- Neka druga tipka
  ELSE
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    @ 23,1 CLEAR TO 23,78
    @ 23,34 SAY "POGRESAN TASTER" COLOR "RB+/B"
    INKEY(1.7)
    @ 23,34 SAY "               " 
    IF m_brslbz<18
      SELECT 8
      GO TOP
    ENDIF
    LOOP
  ENDIF

ENDDO






