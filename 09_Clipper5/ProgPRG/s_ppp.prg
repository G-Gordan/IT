* S_PPP.PRG STAMPA SA KLIZANJEM
SET CURSOR OFF
CLEAR SCREEN
*
brr=1
rrr=0
red=6
SELECT 1
USE tpriv
DO WHILE .T.
  @ 20,1 CLEAR TO 23,78
  @ red,3 SAY vrs+"  "+osn+"  "+dob
  SKIP
  IF EOF()
    rrr=1
    @ 22,1 SAY "Nema vise podataka"
    INKEY(0)
    IF LASTKEY()=27
      EXIT
    ENDIF
*   red=15
  ENDIF
  red=red+1
  IF red=16
    INKEY(0)
    IF LASTKEY()=24 .AND. rrr=1
      @ 23,1 SAY "Rekao sam ti da nema vise podataka !"
      INKEY(0)
    ELSEIF LASTKEY()=24
      rrr=0
      @ 6,1 CLEAR TO 23,78
      red=6
      brr=brr+1
      USE tpriv
      GO brr
      LOOP
    ELSEIF LASTKEY()=5
      brr=brr-1
      IF brr=0
        brr=1
        @ 22,1 SAY "Na vrhu si !"
        INKEY(2)
      ENDIF
      rrr=0
      @ 6,1 CLEAR TO 23,78
      red=6
      GO brr
      LOOP
    ELSE
      EXIT
    ENDIF
    IF rrr=1
      @ 21,1 CLEAR TO 23,78
      red=6
      rrr=0
      GO brr
      LOOP
    ENDIF
  ENDIF
ENDDO
SET CURSOR ON
CLOSE DATABASES
CLEAR SCREEN
RETURN
