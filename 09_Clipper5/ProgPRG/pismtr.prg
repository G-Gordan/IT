CLEAR

matr:=DIRECTORY()

IF EMPTY(matr)
 @ 1,2 SAY " P R A Z N A   ! "
ELSE
 @ 1,2 SAY " I S P U NJ E N A   ! "
ENDIF

ar1:=1
red:=4
m_prov:=SPACE(4)
AADD(matr,"KRAJ")

m_br:=ASCAN(matr,"KRAJ")

@ 2,2 SAY "U tekucem direktorijumu ima "+ALLTRIM(STR(m_br-1))+" fajlova !"

DO WHILE .T.
 IF m_br=ar1
  @ red+2,2 SAY "NEMA VISE !"
  EXIT
 ENDIF
 @ red,2 SAY ALLTRIM(STR(ar1))+"     "+matr[ar1,1]+"   "+STR(matr[ar1,2])+;
             "   "+DTOC(matr[ar1,3])+"   "+matr[ar1,4]+"   "+matr[ar1,5]
 ar1:=ar1+1
 red:=red+1
 IF red=21
  @ red+2,2 SAY "Pritisnite bilo sta za dalje listanje !"
  INKEY(0)
  CLEAR SCREEN
  red:=4
 ENDIF
ENDDO

*FOR i:=1 TO LEN(matr)
* ? matr[i]
*NEXT
*INKEY(0)

QUIT
