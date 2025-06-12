CLEAR
SET CURSOR  OFF

m_kol:=10
FOR i=1 TO 50
 @ 10,m_kol SAY CHR(176)
 m_kol:=m_kol+1
NEXT

m_br:=1
m_pr:=0
m_or:=2
m_kol:=10
FOR i=1 TO 173 
 m_pr:=100*m_br/173
 @ 10,62 SAY STR(m_pr,6,2)
 IF m_pr>=m_or
  @ 10,m_kol SAY CHR(219)
  m_kol:=m_kol+1
  m_or:=m_or+2
 ENDIF
 m_br:=m_br+1
 INKEY(0.1)
NEXT

QUIT
