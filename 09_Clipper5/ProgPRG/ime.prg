******Ime tekuceg direktorijuma*******

CLS
p_imeput:=SPACE(100)
p_brznakniz:=0
p_brskida:=0
p_slovo:=SPACE(1)
p_slovniz:=SPACE(100)

*******Formiranje imena***********
p_imeput:=CURDIR()
p_imeput:=ALLTRIM(p_imeput)
p_brznakniz:=LEN(p_imeput)
p_brskida:=0
*p_brizlaz:=0
DO WHILE .T.
 p_brznakniz:=p_brznakniz-p_brskida
 p_slovo:=SUBSTR(p_imeput,p_brznakniz,1)
 p_brznakniz:=LEN(p_imeput)
 IF p_slovo="\" 
  EXIT
 ENDIF
 p_slovniz:=p_slovo+p_slovniz
*? p_slovo+p_slovniz+STR(p_brznakniz)+STR(p_brskida)
*INKEY(0)
*IF LASTKEY()=27
* QUIT
*ENDIF
 p_brskida:=p_brskida+1
 IF p_slovniz=" " 
  @ 15,20 SAY "Vi niste u direktorijumu vec na osnovnom disku !!!"
  QUIT
 ENDIF
* p_brizlaz:=p_brizlaz+1
ENDDO

  @ 15,20 SAY "Ime ovog direktorijuma je: " + p_slovniz
QUIT
