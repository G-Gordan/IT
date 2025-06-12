SET COLOR TO "GR+/R"
CLS
p_taster:=0
p_taster2:=0
p_brojcanik:=0
vreme:=" "
DO WHILE .T.
 IF p_brojcanik=0
  p_pocvrem:=TIME()
 ENDIF


 vreme:=TIME()
 @ 3,3 SAY "Vreme: "+vreme
 p_taster:=INKEY()
 IF p_taster#p_taster2
  @ 7,3 SAY "                                                            "
  @ 7,3 SAY "Pritisnut je taster sa ASCII kodom: "+ALLTRIM(STR(p_taster))
  p_taster2:=p_taster
 ENDIF
 IF p_taster <> 0
*  @ 11,3 SAY "BRAVO !!!"
   EXIT
*  QUIT
 ENDIF
 IF p_brojcanik=100000
  @ 5,17 SAY "<- Izbrojao !"
  EXIT
 ENDIF
 p_brojcanik:=p_brojcanik+1
 @ 5,3 SAY "Krug: "+ALLTRIM(STR(p_brojcanik))
ENDDO

SET COLOR TO "W/N"
p_red:=ROW()+1
@ p_red,0 CLEAR TO 24,79

QUIT
