CLEAR
m_ime:=SPACE(8)
@ 1,2 SAY "Unesite ime baze podataka (bez ekstenzije)" GET m_ime
READ
*indtip:=SPACE(20)
indkluc:=SPACE(12)
*indtip:=INDEXEXT(m_ime)

*@ 3,2 SAY indtip

br:=0
FOR i:=1 TO 9
 br:=br+1
 USE &m_ime INDEX aaaart,cccart,aaanza,aaajmr,aaaknt,aaaozn,cccozn,aaakol,;
 ccckol
 indkluc:=INDEXKEY(br)
 @ br+4,2 SAY indkluc
NEXT
QUIT
******Komanda INDEXKEY() daje izraz (kljuc) aktivne indeksne baze po  ******
******zadatom rednom broju u zagradi komande.                         ******
******Komanda INDEXORD() daje redni broj poretka zadate indeksne baze.******

