CLEAR
SET CURSOR OFF
SET COLOR TO "GR+/B"
CLEAR SCREEN

***Formiranje baze MATCRAD.dbf***
IF ! FILE("MATCRAD.DBF")
 CREATE Radna
 STORE "ART       N100" TO polje1
 STORE "NZA       C42 " TO polje2
 STORE "JMR       N2 0" TO polje3
 STORE "KNT       N7 0" TO polje4
 STORE "OZN       N1 0" TO polje5
 STORE "KOL       N9 3" TO polje6
 FOR i:=1 TO 6
  STORE STR(i,1) TO broj
  APPEND BLANK
  STORE "polje" + broj TO pl
  REPLACE Field_name WITH SUBSTR(&pl,1,10)
  REPLACE Field_type WITH SUBSTR(&pl,11,1)
  REPLACE Field_len WITH VAL(SUBSTR(&pl,12,2))
  REPLACE Field_dec WITH VAL(SUBSTR(&pl,14,1))
 NEXT
 CREATE Matcrad FROM Radna
 USE
ENDIF
ERASE Radna.dbf
IF FILE("Matcrad.dbf")
 @ 1,10 SAY "Kreirana je baza MATCRAD.DBF !" COLOR "BG+/B"
ENDIF

***Prepisivanje podataka iz MATCM.dbf u MATCRAD.dbf !"***
IF ! FILE("MATCM.DBF")
 @ 10,10 SAY "BAZA MATCM.DBF NE POSTOJI U TEKUCEM DIREKTORIJUMU !"
 @ 23,10 SAY " "
 QUIT
ENDIF
@ 9,10 SAY "Prepisujem slogove iz baze MATCM u bazu MATCRAD !"
SELECT 1
USE Matcm.dbf
m_brsl:=RECCOUNT()
SELECT 2
USE Matcrad.dbf
GO TOP

m_brojac:=0
m_pr:=0
m_or:=2

m_kol:=10
FOR i=1 TO 50
 @ 10,m_kol SAY CHR(176)
 m_kol:=m_kol+1
NEXT
m_kol:=10

DO WHILE .T.
 APPEND BLANK
 REPLACE art WITH A->art
 REPLACE nza WITH A->nza
 REPLACE jmr WITH VAL(A->jmr)
 REPLACE knt WITH A->knt

 ***Skala i brojac za prepisane slogove***
 m_brojac:=m_brojac+1
 m_pr:=100*m_brojac/m_brsl
 @ 11,10 SAY "Prepisano je "
 @ 11,23 SAY ALLTRIM(STR(m_brojac))
 @ 11,30 SAY "slogova "
 @ 11,38 SAY STR(m_pr,6,2)
 @ 11,44 SAY "% baze."
 IF m_pr>=m_or
  @ 10,m_kol SAY CHR(219)
  m_kol:=m_kol+1
  m_or:=m_or+2
 ENDIF

 SELECT 1
 SKIP
 IF EOF()
  @ 2,10 SAY "Baza MATCM.dbf je PROSLA !" COLOR "BG+/B"
  EXIT
 ENDIF
 SELECT 2

ENDDO

***Prepisivanje podataka iz polja OZN i KOL baze MATC.dbf prema polju ART !"
IF ! FILE("MATCC.DBF")
 @ 10,10 SAY "BAZA MATCC.DBF NE POSTOJI U TEKUCEM DIREKTORIJUMU !"
 @ 23,10 SAY " "
 QUIT
ENDIF
SELECT 3
USE Matcc.dbf
IF FILE ("MCARTIDX.NTX")
 ERASE Mcartidx.ntx
ENDIF
@ 5,10 SAY "Indeksiram bazu MATCC.DBF po polju ART !" COLOR "BG+/B"
INDEX ON art TO MCARTIDX.ntx
USE Matcc.dbf INDEX Mcartidx.ntx

SELECT 2
USE Matcrad.dbf
IF FILE ("MRARTIDX.NTX")
 ERASE Mrartidx.ntx
ENDIF
@ 6,10 SAY "Indeksiram bazu MATCRAD.DBF po polju ART !" COLOR "BG+/B"
INDEX ON art TO MRARTIDX.ntx
USE Matcrad.dbf INDEX Mrartidx.ntx

@ 14,10 SAY "Prepisujem polja OZN i ART iz baze MATCC u bazu MATCRAD prema ART !"
m_brsl:=RECCOUNT()
m_brprep:=0
m_brojac:=0
m_pr:=0
m_or:=2

m_kol:=10
FOR i=1 TO 50
 @ 15,m_kol SAY CHR(176)
 m_kol:=m_kol+1
NEXT
m_kol:=10

SELECT 2
GO TOP
SELECT 3

DO WHILE .T.
 m_brojac:=m_brojac+1
 m_pretraga:=B->art
 SEEK m_pretraga
 IF FOUND()
  REPLACE B->ozn WITH ozn
  REPLACE B->kol WITH kol
  m_brprep:=m_brprep+1
  SELECT 2
  SKIP
  IF EOF()
   @ 15,m_kol SAY CHR(219)
   @ 16,23 SAY ALLTRIM(STR(m_brojac))
   @ 17,23 SAY ALLTRIM(STR(m_brprep))
   @ 3,10  SAY "Baza MATCRAD.dbf je PROSLA !" COLOR "BG+/B"
   EXIT
  ENDIF
  SELECT 3
 ELSE
  SELECT 2
  SKIP
  IF EOF()
   @ 15,m_kol SAY CHR(219)
   @ 16,23 SAY ALLTRIM(STR(m_brojac))
   @ 17,23 SAY ALLTRIM(STR(m_brprep))
   @ 3,10  SAY "Baza MATCRAD.dbf je PROSLA !" COLOR "BG+/B"
   EXIT
  ENDIF
  SELECT 3
 ENDIF
 
 ***Skala i brojac za prepisane slogove***
 m_pr:=100*m_brojac/m_brsl
 @ 16,10 SAY "Provereno je "
 @ 16,23 SAY ALLTRIM(STR(m_brojac))
 @ 16,30 SAY "slogova "
 @ 16,38 SAY STR(m_pr,6,2)
 @ 16,44 SAY "% baze."
 @ 17,10 SAY "Prepisano je"
 @ 17,23 SAY ALLTRIM(STR(m_brprep))
 @ 17,30 SAY "slogova (polja OZN i KOL)."
 @ 18,10 SAY "Nije proslo"
 @ 18,23 SAY ALLTRIM(STR(m_brojac-m_brprep))
 @ 18,30 SAY "slogova."
 IF m_pr>=m_or
  @ 15,m_kol SAY CHR(219)
  m_kol:=m_kol+1
  m_or:=m_or+2
 ENDIF

ENDDO

@ 22,10 SAY "Sta sam prepis'o, prepis'o sam !"
@ 23,10 SAY " "

QUIT


