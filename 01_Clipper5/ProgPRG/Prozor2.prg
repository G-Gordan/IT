SET COLOR TO "GR+/R,RB+/G,,,"
CLEAR SCREEN
SET WRAP ON
SET MESSAGE TO 23 CENTER
@ 4,11 TO 10,35

DO WHILE .T.

 p_izbor:=1
 @ 5,18 PROMPT "1. OPCIJA";
 MESSAGE ("Odredjena radnja pod opcijom 1")
 @ 6,18 PROMPT "2. OPCIJA";
 MESSAGE ("Odredjena radnja pod opcijom 2")
 @ 7,18 PROMPT "3. OPCIJA";
 MESSAGE ("Odredjena radnja pod opcijom 3")
 @ 8,18 PROMPT "4. OPCIJA";
 MESSAGE ("Odredjena radnja pod opcijom 4")
 @ 9,18 PROMPT "5. OPCIJA";
 MESSAGE ("Odredjena radnja pod opcijom 5")
 MENU TO p_izbor

 DO CASE
  CASE p_izbor=0
   @ 23,2 SAY "Izabrali ste ESC"
   EXIT
  CASE p_izbor=1
   @ 23,2 SAY "Izabrali ste 1"
   EXIT
  CASE p_izbor=2
   @ 23,2 SAY "Izabrali ste 2"
   EXIT
  CASE p_izbor=3
   @ 23,2 SAY "Izabrali ste 3"
   EXIT
  CASE p_izbor=4
   @ 23,2 SAY "Izabrali ste 4"
   EXIT
  CASE p_izbor=5
   @ 23,2 SAY "Izabrali ste 5"
   EXIT
 ENDCASE

ENDDO


@ 24,0 SAY " "
INKEY(3)
SET COLOR TO 
CLEAR SCREEN
