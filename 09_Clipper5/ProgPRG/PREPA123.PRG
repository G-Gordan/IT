* Prebacuje podatke iz BBB u AAA ako polje ART vec ne postoji u AAA
* i ispisuje sta je upisano a sta vec postoji u AAA
* Daje broj slogova baze BBB i broji uradjeno u %

CLEAR SCREEN
@ 2,2 SAY "Prepisujem bazu BBB.DBF u bazu AAA.DBF !"

m_brsl:=0
m_obrsl:=0
m_artc:=0
m_brpr:=0
m_brnpr:=0
red:=5

baza:="bbb"
indbaza:="artindb"
kljuc:="art"
SELECT 1
IF ! FILE("artindb.ntx")
 USE &baza
 INDEX ON &kljuc TO &indbaza
ELSE
 USE &baza INDEX &indbaza
ENDIF
m_brsl:=RECCOUNT()
@ 21,2 SAY "Baza " + UPPER(baza) + " ima " + ALLTRIM(STR(m_brsl))  + " slogova !"

SELECT 2
IF ! FILE("artinda.ntx")
 USE aaa
 INDEX ON art TO artinda
ELSE
 USE aaa INDEX artinda
ENDIF


DO WHILE .T.
 m_obrsl:=m_obrsl+1
 red:=red+1
 m_artc:=A->art
 SEEK m_artc
 IF ! FOUND()
  GO BOTTOM
  APPEND BLANK
  REPLACE art WITH A->art
  REPLACE nza WITH A->nza
  REPLACE jmr WITH A->jmr
  REPLACE knt WITH A->knt
  @ red,2 SAY "Slog sa poljem ART=" + STR(m_artc) + " JE PREPISAN !"
  m_brpr:=m_brpr+1
 ELSE
  @ red,2 SAY "Slog sa poljem ART=" + STR(m_artc) + " VEC POSTOJI !"
  m_brnpr:=m_brnpr+1
 ENDIF

 mr_obrsl:=100*m_obrsl/m_brsl

 mr_brpr:=100*m_brpr/m_brsl

 mr_brnpr:=100*m_brnpr/m_brsl
 

 @ 20,2 SAY "Obradjeno je " + STR(mr_obrsl,6,2);
            + "%, prepisano " + STR(mr_brpr,6,2);
            + "%, a neprepisano " + STR(mr_brnpr,6,2) + "% slogova !"
 INKEY(0.7)

 SELECT 1
 SKIP
 IF EOF ()
  @ 22,2 SAY "Baza za upis ja prosla !"
  EXIT
 ENDIF
 SELECT 2

ENDDO
USE
@ 23,2 SAY "U P I S   Z A V R S E N   !"
ERASE artinda.ntx
ERASE atrindb.ntx
QUIT

