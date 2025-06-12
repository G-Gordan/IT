CLEAR

SELECT 1
IF ! FILE("artindc.ntx")
 USE ccc
 INDEX ON art TO artindc
ELSE
 USE ccc INDEX artindc
ENDIF

SELECT 2
IF ! FILE("artinda.ntx")
 USE aaa
 INDEX ON art TO artinda
ELSE
 USE aaa INDEX artinda
ENDIF
m_atra:=0
m_oznc:=0
m_kolc:=0

@ 2,2  SAY "Prebacujem podatke OZN i KOL iz baze CCC u AAA !"
@ 4,14 SAY "ART"
@ 4,19 SAY "OZN"
@ 4,25 SAY "KOL"
@ 5,2 SAY REPLICATE ("-",70)
red=5
DO WHILE .T.
 @ 3,2  SAY "Radim-petljam !"
 red:=red+1
 SELECT 1
 m_arta:=B->art
 @ red,14 SAY m_arta
 SEEK B->art
 IF FOUND()
  @ red,2 SAY "Nasao     "
  m_oznc:=ozn
  m_kolc:=kol
  SELECT 2
  REPLACE ozn WITH A->ozn
  REPLACE kol WITH A->kol
  @ red,19 SAY m_oznc
  @ red,25 SAY m_kolc
  @ red,40 SAY "Prepisao"
 ELSE
  @ red,2 SAY "Nije nasao"
  SELECT 2
 ENDIF
 SKIP
 IF EOF()
  @ 23,2  SAY "Baza AAA.DBF je prosla !"
  EXIT
 ENDIF
ENDDO
USE
QUIT


