**********************************************************
* LOKSTV.PRG - PROGRAM ZA IZMENE U DSTOV I DLOK
**********************************************************
SET CONFIRM ON
CLEAR SCREEN
DO WHILE .T.
  @ 1,0 TO 3,78 DOUBLE
  @ 5,0 TO 23,78 DOUBLE
  @ 2,3 SAY "LOKSTV"
  @ 2,25 SAY "IZMENE U DLOK I DSTOV"
  @ 2,61 SAY "''ESC'' za kraj"
  m_izbor:=1
  @ 7,15 PROMPT " IZMENE U DLOK ";
         MESSAGE "IZMENE U LOKOMOTIVAMA"
  @ 7,40 PROMPT " IZMENE U DSTOV ";
         MESSAGE "IZMENE U STOVARISTIMA"
  CLEAR TYPEAHEAD
  MENU TO m_izbor
  DO CASE
    CASE LASTKEY()=27
         EXIT
    CASE m_izbor=1
         DO izmlok
    CASE m_izbor=2
         DO izmstv
    OTHERWISE
         EXIT
  ENDCASE
ENDDO
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN
**********************************************************
* Izmene u lokomotivama
**********************************************************
PROCEDURE IZMLOK
SELECT 1
USE dlok INDEX dlok
m_lok:=0
m_dan:="D"
m_odl:="N"
DO WHILE m_dan="D"
  @ 5,0 TO 23,78 DOUBLE
  @ 9,5 SAY "Sifra LOKOMOTIVE : " GET m_lok PICTURE "999999";
        VALID (m_lok>0)
  READ
  IF LASTKEY()=27
    EXIT
  ENDIF
  SEEK m_lok
  IF FOUND()
    m_odl:="N"
    @ 11,5 SAY "Ta sifra vec postoji !"
    @ 13,5 SAY "Da li hoces da je izbacis (D/N)?";
           GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
    READ
    IF m_odl="D" .OR. m_odl="d"
      DELETE
      PACK
      @ 15,5 SAY "Sifra "+STR(m_lok,6)+" izbacena"
      INKEY(3)
      m_lok:=0
      @ 10,1 CLEAR
      LOOP
    ELSE
      m_lok:=0
      @ 10,1 CLEAR
      LOOP
    ENDIF
  ELSE
    APPEND BLANK
    REPLACE sfdob WITH m_lok
    @ 15,5 SAY "Sifra je ubacena"
    INDEX ON sfdob TO dlok
    @ 17,5 SAY "DLOK.DBF je indeksirana !"
    INKEY(3)
    @ 10,1 CLEAR
    m_lok:=0
  ENDIF
END
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN
**********************************************************
* Izmene u stovaristima
**********************************************************
PROCEDURE IZMSTV
SELECT 2
USE dstov INDEX dstov
m_stv:=0
m_uns:="D"
m_din:="N"
DO WHILE m_uns="D"
 @ 5,0 TO 23,78 DOUBLE
 @ 9,5 SAY "Sifra STOVARISTA : " GET m_stv PICTURE "999";
       VALID (m_stv>0)
 READ
 IF LASTKEY()=27
  EXIT
 ENDIF
 SEEK m_stv
 IF FOUND()
  m_din:="N"
  @ 11,5 SAY "Ta sifra vec postoji !"
  @ 13,5 SAY "Da li hoces da je izbacis (D/N)?";
         GET m_din PICTURE "!" VALID (m_din $ "DdNn")
  READ
  IF m_din="D" .OR. m_din="d"
   DELETE
   PACK
   @ 15,5 SAY "Sifra "+STR(m_stv,6)+" izbacena"
   INKEY (3)
   m_stv:=0
   @ 10,1 CLEAR
   LOOP
  ENDIF
 ELSE
  APPEND BLANK
  REPLACE sfstv WITH m_stv
  @ 15,5 SAY "Sifra je ubacena"
  INDEX ON sfstv TO dstv
  @ 17,5 SAY "DSTV.DBF je indeksirana !"
  INKEY(3)
  @ 10,1 CLEAR
  m_stv:=0
 ENDIF
END
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN
**********************************************************

