CLEAR

SELECT 1
IF ! FILE("artind1.ntx")
 USE matc1
 INDEX ON art TO artind1
ELSE
 USE matc1 INDEX artind1
ENDIF
m_brsl:=RECCOUNT()


SELECT 2
IF ! FILE("artind2.ntx")
 USE matc2
 INDEX ON art TO artind2
ELSE
 USE matc2 INDEX artind2
ENDIF
*m_atra:=0
*m_oznc:=0
*m_kolc:=0

@ 2,2  SAY "Prebacujem podatke OZN i KOL iz baze MATC1 u MATC2 !"
*@ 4,14 SAY "ART"
*@ 4,19 SAY "OZN"
*@ 4,25 SAY "KOL"
*@ 5,2 SAY REPLICATE ("-",70)
*red=5

m_brpr:=0
DO WHILE .T.
 m_brpr:=m_brpr+1
 @ 3,2  SAY "Radim-petljam !"
* red:=red+1
 SELECT 1
* m_arta:=B->art
* @ red,14 SAY m_arta
 SEEK B->art
 IF FOUND()
*  @ red,2 SAY "Nasao     "
*  m_oznc:=ozn
*  m_kolc:=kol
  SELECT 2
  REPLACE ozn WITH A->ozn
  REPLACE kol WITH A->kol
*  @ red,40 SAY "Prepisao"
*  @ red,19 SAY m_oznc
*  @ red,25 SAY m_kolc
 ELSE
*  @ red,2 SAY "Nije nasao"
  SELECT 2
 ENDIF
 SKIP
 IF EOF()
  @ 22,2  SAY "Baza MATC2.DBF je prosla !"
  EXIT
 ENDIF

 mr_brpr:=100*m_brpr/m_brsl
 @ 20,2 SAY "Obradjeno je " + STR(mr_brpr,6,2) + "% slogova !"

ENDDO
USE
QUIT


