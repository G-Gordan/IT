CLEAR

***Formiranje baze MATCRAD.dbf***
IF ! FILE("MATCRAD.DBF")
 CREATE Radna
 STORE "ART       N100" TO polje1
 STORE "NZA       C42 " TO polje2
 STORE "JMR       N2 0" TO polje3
 STORE "KNT       N7 0" TO polje4
 STORE "OZN       N1 0" TO polje5
 STORE "KOL       N9 3" TO polje6
 FOR i:=1 TO 6
  STORE STR(i,1) TO broj
  APPEND BLANK
  STORE "polje" + broj TO pl
  REPLACE Field_name WITH SUBSTR(&pl,1,10)
  REPLACE Field_type WITH SUBSTR(&pl,11,1)
  REPLACE Field_len WITH VAL(SUBSTR(&pl,12,2)
  REPLACE Field_dec WITH VAL(SUBSTR(&pl,14,1)
 NEXT
 CREATE Matcrad FROM Radna
 USE
 ERASE Radna
ENDIF
CLEAR SCREEN
IF FILE("Matcrad.dbf")
 @ 1,30 SAY "Kreirana je baza MATCRAD.DBF !"
ENDIF

***Prepisivanje podataka iz 
