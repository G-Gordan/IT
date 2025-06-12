
SET CURSOR  OFF
SET COLOR TO "GR+/B"

CLS

IF ! FILE("matc.dbf")
  @ 12,27 SAY "Nema databaze MATC.DBF !"
  INKEY(0)
  SET COLOR TO "W/N"
  CLS
  QUIT
ENDIF


USE matc
*Broj slogova*
m_brslogova:=RECCOUNT()

*poruka*
@ 12,18 SAY "Ispravka slova je u toku (Esc->izlaz) !"

*Postavlja podlogu za skalu*
m_kol:=10
FOR i=1 TO 50
 @ 10,m_kol SAY CHR(176) COLOR "GR+/B"
 m_kol:=m_kol+1
NEXT

*slova*
m_brslova:=0
m_brojac:=1
m_djmesto:=0
m_djbroji:=0

*skala*
m_pr:=0
m_or:=2
m_kol:=10

*Pretraga, izmena i brojanje*
DO WHILE .T.
  m_brslova:=LEN(ALLTRIM(nza))
  m_djmesto:=42-m_brslova
  m_slovo:=" "
  m_recniz:=" "
  FOR x=1 TO m_brslova
    *Prekid*
    INKEY()
    IF LASTKEY()=27
      @ 12,0 CLEAR TO 12,79
      @ 12,25 SAY "Prepravka slova je prekinuta !"
      INKEY(5)
      SET COLOR TO "W/N"
      CLS
      QUIT
    ENDIF
    m_slovo:=SUBSTR(nza,x,1)
    *Slovo S-SH*
    IF m_slovo=CHR(175) .OR. m_slovo=CHR(91)
      m_slovo:="S"
    *Slovo DJ*
    ELSEIF m_slovo=CHR(208) .OR. m_slovo=CHR(92)
      *za manje od 42 znaka upisuje "DJ", a posle "D"*
      IF m_brslova=42
        m_slovo:="D"
      ELSEIF m_brslova<42  
        m_slovo:="DJ"
        m_brslova:=m_brslova+1
      ENDIF
    *Slovo Z-ZSH*
    ELSEIF m_slovo=CHR(189) .OR. m_slovo=CHR(64)
      m_slovo:="Z"
    *Slovo C-meko*
    ELSEIF m_slovo=CHR(209) .OR. m_slovo=CHR(93)
      m_slovo:="C"
    *Slovo C-tvrdo*
    ELSEIF m_slovo=CHR(197) .OR. m_slovo=CHR(94)
      m_slovo:="C"
    ENDIF
    m_recniz:=m_recniz+m_slovo
  NEXT

  *Upis izmenjenog naziva u databazu MATC.DBF*
  REPLACE nza WITH ALLTRIM(m_recniz)

  *Ispis skale*
  m_pr:=100*m_brojac/m_brslogova
  @ 10,62 SAY STR(m_pr,6,2) + "%" COLOR "GR+/B"
  IF m_pr>=m_or
    @ 10,m_kol SAY CHR(219) COLOR "GR+/B"
    m_kol:=m_kol+1
    m_or:=m_or+2
  ENDIF

  *Prekid*
  INKEY()
  IF LASTKEY()=27
    @ 12,0 CLEAR TO 12,79
    @ 12,25 SAY "Prepravka slova je prekinuta !"
    INKEY(7)
    SET COLOR TO "W/N"
    CLS
    QUIT
  ENDIF

  *Skok na sledeci slog*
  SKIP
  IF EOF()
    EXIT
  ENDIF
  m_brojac:=m_brojac+1

ENDDO

@ 12,0 CLEAR TO 12,79
@ 12,25 SAY "Prepravka je zavrsena !"
INKEY(7)

SET COLOR TO "W/N"
CLS
QUIT


