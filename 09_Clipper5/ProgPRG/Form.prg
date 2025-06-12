* FORM.PRG - PROGRAM ZA FORMIRANJE DBF
***************************************
CLEAR SCREEN
@ 5,10 SAY "Radim... !"
SELECT 1
USE matp
PACK
APPEND FIELDS art,nza,jmr,knt FROM matc.txt SDF
CLOSE DATABASES
