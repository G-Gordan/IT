CLEAR

mtr1:=ARRAY(5)
mtr1[1]:="OVCA"
mtr1[2]:="KOZA"
mtr1[3]:="KRAVA"
mtr1[4]:="KONJ"
mtr1[5]:="PAS"


mtr2:=ARRAY(5)
mtr2[1]:="BELA"
mtr2[2]:="SARENA"
mtr2[3]:="BRAON"
mtr2[4]:="SIV"
mtr2[5]:="CRN"

DO WHILE .T.
 IF LASTKEY()=27
  EXIT
 ENDIF
 p_zelja:=SPACE(6)
 @ 2,2 SAY "Izaberite zivotinju :ovca, koza, krava, konj, pas  !" GET p_zelja;
       PICTURE "@!" 
 READ
 CLEAR SCREEN
 p_ime:=ALLTRIM(p_zelja)
 p_br:=1
 DO WHILE p_br<=5
  p_proba:=mtr1[p_br]
  p_br:=p_br+1
  IF p_ime # p_proba
   LOOP
  ELSE
   EXIT
  ENDIF
 ENDDO
 IF p_br = 6
  LOOP
 ENDIF
 p_nivo:=ASCAN(mtr1,p_ime)
 p_osobina:=mtr2[p_nivo]
 @ 3,2 SAY STR(p_nivo)+"   "+p_ime+"   "+p_osobina
ENDDO
QUIT
