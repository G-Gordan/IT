CLS

IF ! FILE("matc.dbf")
  @ 10,22 SAY "NE POSTOJI DATOTEKA MATC.DBF !"
  QUIT
ENDIF

IF ! FILE("stan.dbf")
  @ 10,22 SAY "NE POSTOJI DATOTEKA STAN.DBF !"
  QUIT
ENDIF

ERASE mxzwqoo.dbf
ERASE mxzwqoo.ntx
ERASE matosob.dbf

@ 10,23 SAY "REIMENUJEM DATOTEKU MATC.DBF"
RENAME matc.dbf TO mxzwqoo.dbf

SELECT 1
USE mxzwqoo
CLS
@ 10,19 SAY "INDEKSIRANJE BAZE PO KLJUCU -> ART !"
INDEX ON art TO mxzwqoo
COPY TO matosob STRUCTURE EXTENDED

SELECT 2
USE stan
m_brslst:=LASTREC()

SELECT 4
USE matosob
m_brslos:=LASTREC()

mtr_osob:=ARRAY(m_brslos,4)
FOR a=1 TO m_brslos
  mtr_osob[a,1]:=field_name
  mtr_osob[a,2]:=field_type
  mtr_osob[a,3]:=field_len
  mtr_osob[a,4]:=field_dec
  SKIP
NEXT
SELECT 3
DBCREATE("MATC",mtr_osob)
USE matc

SET COLOR TO "GR+/B"
CLS
SET CURSOR  OFF
m_kol:=15
FOR i=1 TO 50
  @ 10,m_kol SAY CHR(176)
  m_kol:=m_kol+1
NEXT
m_brojac:=1
m_procen:=0
m_prered:=2
m_kol:=15

m_artsta:=0
DO WHILE .T.
  m_artsta:=B->art
  SEEK m_artsta
  IF FOUND()
    SELECT 3
    APPEND BLANK
    REPLACE art WITH A->art , nza WITH A->nza , jmr WITH A->jmr ,;
            knt WITH A->knt , min WITH A->min , vre WITH A->vre ,;
            ozn WITH A->ozn
  ENDIF
  SELECT 2
  SKIP

  m_procen:=100*m_brojac/m_brslst
  @ 10,68 SAY ALLTRIM(STR(m_procen,6,2))+"%"
  IF m_procen>=m_prered
    @ 10,m_kol SAY CHR(219)
    m_kol:=m_kol+1
    m_prered:=m_prered+2
  ENDIF
  m_brojac:=m_brojac+1

  IF EOF()
    EXIT
  ENDIF
  SELECT 1
ENDDO

@ 18,18 SAY "PRECISCAVANJE MATC.DBF PO STAN.DBF ZAVRSENO !"
INKEY(5.4)

CLOSE DATABASES
ERASE mxzwqoo.dbf
ERASE mxzwqoo.ntx
ERASE matosob.dbf
SET COLOR TO "W/N"
CLS

QUIT



