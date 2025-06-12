
**********************************************************************
*****************************GLAVNI MENI ZA RAD***********************
**********************************************************************

**************   Postavka SET-ova i SLIKA   ***********
CLEAR ALL
SET SCOREBOARD OFF
SET WRAP ON
SET DELETE ON
SET CURSOR OFF
SET CONFIRM OFF
SET DATE GERMAN
SET MESSAGE TO 24 CENTER
SET COLOR TO W+/N
CLEAR SCREEN
@ 2,11 TO 17,64 DOUBLE
@ 1,8  TO 18,67 DOUBLE
@ 4,15 SAY "п      мллллллп     млллллллллллллллллллл" COLOR "R/N"
INKEY(0.04)
@ 5,15 SAY "     мллллллп     млллллллллллллллллллллл" COLOR "R/N"
INKEY(0.04)
@ 6,15 SAY "   мллллллп     млллллп"                   COLOR "R/N"
INKEY(0.04)
@ 7,15 SAY " мллллллп     млллллп"                     COLOR "R/N"
INKEY(0.04)
@ 8,15 SAY "ллллллп     млллллп    млллллллллллллллллм" COLOR "B/N"
INKEY(0.04)
@ 9,15 SAY "ллллп     млллллп    млллллллллллллллллллллм" COLOR "B/N"
INKEY(0.04)
@10,15 SAY "ллп     млллллп    мллллп               пллллм" COLOR "B/N"
INKEY(0.04)
@11,15 SAY "п     млллллп    мллллп    jul 2002       лллл" COLOR "B/N"
INKEY(0.04)
@12,15 SAY "    млллллп    мллллп      COK Beograd  мллллп"
INKEY(0.04)
@13,15 SAY "  млллллп    млллллллллллллллллллллллллллллп"
INKEY(0.04)
@14,15 SAY "млллллп    млллллллллллллллллллллллллллллп"
INKEY(0.04)
@15,15 SAY "ллллп    млллллллллллллллллллллллллллллп"
INKEY(0.04)
@19,28 TO 21,49 DOUBLE
@20,34 SAY "Zalihe-soft"
INKEY(7.4)





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

************************UPUCUJE NA RAD******************

DO izmprgbz

*********************************************************
***  KRAJ  ***

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
  CLS
  QUIT
 ENDIF

ENDDO
CLOSE DATABASES
CLS
RETURN


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
    @ 23,10 SAY "Korak:"+CHR(24)+"-"+CHR(25)+"*Skok:PageUp"+CHR(24)+;
               "-PageDown"+CHR(25)+"*Izlaz:Esc*F10(F-1,2,3,4,8)"
  ELSEIF m_ispF10="DRUGI"
    @ 23,8 SAY "F1:T-polje*F2:T-izraz*F3:Opet_F1-2*F8:T-sve*F4:Skok*"+;
               "F10:Pomoc"
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


***Pretraga po svim kriterijumima (F8)***
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
      @ 4+m_ptpkrd,20 GET m_vrdsdr VALID (m_vrdsdr $ "><=") COLOR "R/W"
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

SELECT 8
USE bzzapret
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
    @ 23,10 SAY "Korak:"+CHR(24)+"-"+CHR(25)+"*Skok:PageUp"+CHR(24)+;
               "-PageDown"+CHR(25)+"*Izlaz:Esc*F10(F-1,2,3,4)"
  ELSEIF m_ispF10="DRUGI"
    @ 23,8 SAY "F1:Trazi_polje*F2:Trazi_izraz*F3:Opet_F1-2*F4:Skok*"+;
               "F10:Pomoc"
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
    ERASE gdlistpg.ntx
    RETURN


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






