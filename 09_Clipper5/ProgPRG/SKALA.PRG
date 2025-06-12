CLEAR
SET CURSOR  OFF
SET COLOR TO " /B"

m_red:=0
FOR i=1 TO 25
 @ m_red,0 SAY SPACE(80)
 m_red:=m_red+1
NEXT

m_kol:=10
FOR i=1 TO 50
 @ 10,m_kol SAY CHR(178) COLOR "R/W"
 m_kol:=m_kol+1
NEXT

m_br:=1
m_pr:=0
m_or:=2
m_kol:=10
FOR i=1 TO 173 
 m_pr:=100*m_br/173
 @ 10,62 SAY STR(m_pr,6,2) COLOR "G/B"
 IF LASTKEY()=27
  EXIT
 ENDIF
 IF m_pr>=m_or
  @ 10,m_kol SAY CHR(219) COLOR "G/ "
  m_kol:=m_kol+1
  m_or:=m_or+2
 ENDIF
 m_br:=m_br+1
 INKEY(0.1)
NEXT

SET COLOR TO
QUIT
