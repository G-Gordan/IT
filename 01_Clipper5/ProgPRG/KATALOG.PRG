CLEAR

***Formiranje matrice sa podacima o fajlovime iz tekuceg DOS kataloga***
matrk:=DIRECTORY()

IF EMPTY(matrk)
 @ 1,2 SAY " M A T R I C A   J E   P R A Z N A   ! "
ELSE
 @ 1,2 SAY " M A T R I C A   J E   I S P U NJ E N A   ! "
ENDIF

***Brojanje areja(nivoa, upisanih fajlova) u matrici***
AADD(matrk,"KRAJ")
p_brf:=0
p_brf:=ASCAN(matrk,"KRAJ")-1
@ 2,2 SAY "U tekucem direktorijumu ima "+ALLTRIM(STR(p_brf))+" fajlova !"

***Formiranje baze sa osobinama svih fajlova iz tekuce DOS kataloga***
matr1:=0
IF ! FILE("podkat.dbf")
 matrpk:=ARRAY(5,4)
 matrpk[1,1] := "nazbppk"
 matrpk[1,2] := "c"
 matrpk[1,3] := 8
 matrpk[1,4] := 0
 matrpk[2,1] := "ekst"
 matrpk[2,2] := "c"
 matrpk[2,3] := 3
 matrpk[2,4] := 0
 matrpk[3,1] := "prostor"
 matrpk[3,2] := "n"
 matrpk[3,3] := 11
 matrpk[3,4] := 0
 matrpk[4,1] := "datumfor"
 matrpk[4,2] := "d"
 matrpk[4,3] := 8
 matrpk[4,4] := 0
 matrpk[5,1] := "vremefor"
 matrpk[5,2] := "c"
 matrpk[5,3] := 9
 matrpk[5,4] := 0
 DBCREATE("podkat",matrpk)
 CLOSE DATABASES
 IF FILE("podkat.dbf")
  @ 3,2 SAY"Formirana je baza podataka PODKAT.DBF"
 ENDIF
ENDIF

***Formiranje baza sa osobinama i kompatibilnosti baza podataka i indeksa***
matrpb:=0
IF ! FILE("podbaza.dbf")
 matrpb:=ARRAY(7,4)
 matrpb[1,1] := "nazbppb"
 matrpb[1,2] := "c"
 matrpb[1,3] := 8
 matrpb[1,4] := 0
 matrpb[2,1] := "imepolja"
 matrpb[2,2] := "c"
 matrpb[2,3] := 10
 matrpb[2,4] := 0
 matrpb[3,1] := "tippolja"
 matrpb[3,2] := "c"
 matrpb[3,3] := 1
 matrpb[3,4] := 0
 matrpb[4,1]:= "brmesta"
 matrpb[4,2]:= "n"
 matrpb[4,3]:= 3
 matrpb[4,4]:= 0
 matrpb[5,1]:= "brdecimala"
 matrpb[5,2]:= "n"
 matrpb[5,3]:= 3
 matrpb[5,4]:= 0
 matrpb[6,1]:= "nazivind"
 matrpb[6,2]:= "c"
 matrpb[6,3]:= 12
 matrpb[6,4]:= 0
 matrpb[7,1]:= "mozeiline"
 matrpb[7,2]:= "l"
 matrpb[7,3]:= 1
 matrpb[7,4]:= 0
 DBCREATE("podbaza",matrpb)
 CLOSE DATABASES
 IF FILE("podbaza.dbf")
  @ 3,40 SAY "i PODBAZA.DBF"
 ENDIF
ENDIF

***Formiranje indeksnih baza***
USE podkat
IF ! FILE("pknazind.ntx")
 INDEX ON nazbppk TO pknazind
ENDIF
IF ! FILE("pkeksind.ntx")
 INDEX ON ekst TO pkeksind
ENDIF
USE


USE podbaza
IF ! FILE("pbnazind.ntx")
 INDEX ON nazbppb TO pbnazind
ENDIF
IF ! FILE("pbimeind.ntx")
 INDEX ON imepolja TO pbimeind
ENDIF
IF ! FILE("pbindind.ntx")
 INDEX ON nazivind TO pbindind
ENDIF
IF ! FILE("pbmozind.ntx")
 INDEX ON mozeiline TO pbmozind
ENDIF
USE

***Upisuje osobine fajlova iz matrice u promenljive***
p_brar:=1
p_red:=4
p_umet:="     "

DO WHILE .T.

***Obezbedjuje prekid kada prodje poslednji fajl***
 IF p_brar>p_brf
  EXIT
 ENDIF

***Uzima znak po znak iz naziva i odvaja ime od ekstenzije***
 p_brm1:=1
 m1:=" "
 p_ar1:=matrk[p_brar,1]
 p_brznar1:=LEN(p_ar1)
 DO WHILE p_brm1 <= p_brznar1
  p_znar1:=SUBSTR(p_ar1,p_brm1,1)
  p_brm1:=p_brm1+1
  IF p_znar1 = "." .OR. p_znar1 = " "
   EXIT
  ENDIF
  m1:=m1+p_znar1
 ENDDO
 m1:=ALLTRIM(m1)

***Odvaja ekstenziju od naziva***
 m2:=" "
 p_brmst:=LEN(m1)+2
 m2:=SUBSTR(p_ar1,p_brmst,3)
 
***Ubacuje podatke***
 m3:=matrk[p_brar,2]

 m4:=matrk[p_brar,3]

 m5:=matrk[p_brar,4]+LOWER(matrk[p_brar,5])

*** Prikazuje na ekranu fajlove tekuceg direktorijuma***
* @ p_red+1,3 SAY m1+p_umet+m2+p_umet+ALLTRIM(STR(m3))+p_umet+DTOC(m4)+p_umet+m5
* p_red:=p_red+1
* IF p_red=21
*  @ p_red+2,2 SAY "Pritisnite bilo sta za dalje listanje !"
*  INKEY(0)
*  CLEAR SCREEN
*  p_red:=4
* ENDIF

***Ubacuje podatke o elemnt. kataloga iz matrice (MATRK) u bazu PODKAT.DBF***
 USE podkat INDEX pknazind, pkeksind
 APPEND BLANK
 REPLACE nazbppk WITH m1, ekst WITH m2, prostor WITH m3, datumfor WITH m4,;
         vremefor WITH m5
 USE
 
***Broji tekuce areje matrice***
 p_brar:=p_brar+1

ENDDO

***Upis imena DBF baze i osobina za svako polje u PODBAZA***
SELECT 1
USE podkat INDEX pkeksind
SELECT 2
USE podbaza INDEX pbnazind, pbimeind, pbindind, pbmozind
SELECT 1
SEEK "DBF"

DO WHILE ekst="DBF"
 p_imebp:=ALLTRIM(nazbppk)
 SELECT 3
 USE &p_imebp
 COPY TO osobbp STRUCTURE EXTENDED
* SELECT 4
* USE osobbp
* p_brslosbp:=RECCOUNT()
* FOR i:=1 TO p_brslosbp
  SELECT 2
  APPEND BLANK
  REPLACE nazbppb WITH A->nazbppk
  SELECT 1
  SKIP
  IF EOF()
    EXIT
  ENDIF
* , imepolja WITH D->field_name,;
*          tippolja WITH D->fiela_type, brmesta WITH D->field_len,;
*          brdecimala WITH D->field_dec
*  SELECT 4
*  SKIP
* NEXT
ENDDO



*ar1:=1
*red:=4
*DO WHILE .T.
* IF m_br=ar1
*  @ red+1,2 SAY "N E M A   V I S E   !"
*  EXIT
* ENDIF
* @ red,2 SAY ALLTRIM(STR(ar1))+"     "+p_matrk[ar1,1]+"   "+;
*             STR(p_matrk[ar1,2])+"   "+DTOC(p_matrk[ar1,3])+;
*             "   "+p_matrk[ar1,4]+"   "+p_matrk[ar1,5]
* ar1:=ar1+1
* red:=red+1
* IF red=21
*  @ red+2,2 SAY "Pritisnite bilo sta za dalje listanje !"
*  INKEY(0)
*  CLEAR SCREEN
*  red:=4
* ENDIF
*ENDDO

CLOSE DATABASES

***Brise sve baze napravljene ovim programom***
*ERASE podkat.dbf
*ERASE podbaza.dbf
ERASE pknazind.ntx
ERASE pkeksind.ntx
ERASE pbnazind.ntx
ERASE pbimeind.ntx
ERASE pbindind.ntx
ERASE pbmozind.ntx

QUIT
