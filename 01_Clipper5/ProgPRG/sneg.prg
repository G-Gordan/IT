
SET CURSOR OFF
SET COLOR TO "GR+/B"
CLS

p_red:=-1
p_krajred:=22
p_brojcanik:=1

DO WHILE .T.
 IF p_brojcanik=6
  EXIT
 ENDIF
 IF p_red<p_krajred
  @ p_red,10 SAY " "
 ENDIF
 p_red:=p_red+1
 @ p_red,10 SAY CHR(219)
 INKEY(0.07)
 IF p_red=p_krajred
*  @ p_red,10 SAY CHR(219)
  p_red:=0
  p_krajred:=p_krajred-1
  p_brojcanik:=p_brojcanik+1
  LOOP
 ENDIF
ENDDO

*CLS
@ 23,0 SAY " "


SET COLOR TO "W/N"
@ 23,0 CLEAR TO 24,79
QUIT

