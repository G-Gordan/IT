CLEAR
@ 0,0 CLEAR
IF ! FILE("aaa.dbf")
 CREATE pomoc1
 STORE "art       n100" TO polje1
 STORE "nza       c42 " TO polje2
 STORE "jmr       n2 0" TO polje3
 STORE "knt       n7 0" TO polje4
 STORE "ozn       n1 0" TO polje5
 STORE "kol       n9 3" TO polje6
  FOR i=1 TO 6
   APPEND BLANK
   STORE STR(i,1) TO broj
   STORE "polje"+broj TO p1
   REPLACE field_name WITH SUBSTR(&p1,1,10)
   REPLACE field_type WITH SUBSTR(&p1,11,1)
   REPLACE field_len  WITH VAL(SUBSTR(&p1,12,2))
   REPLACE field_dec  WITH VAL(SUBSTR(&p1,14,1))
  NEXT
 CREATE aaa FROM pomoc1
 USE
 DELETE FILE pomoc1.dbf
ENDIF
@ 7,7 SAY "Kreirana ja baza podaka AAA.DBF !"
IF ! FILE ("bbb.dbf")
 CREATE pomoc2
  polje1 := "art       n100" 
  polje2 := "nza       c42 " 
  polje3 := "jmr       n2 0" 
  polje4 := "knt       n7 0" 
  FOR i=1 TO 4
   APPEND BLANK
    broj := STR(i,1) 
    p1   := "polje"+broj 
   REPLACE field_name WITH SUBSTR(&p1,1,10)
   REPLACE field_type WITH SUBSTR(&p1,11,1)
   REPLACE field_len  WITH VAL(SUBSTR(&p1,12,2))
   REPLACE field_dec  WITH VAL(SUBSTR(&p1,14,1))
  NEXT
 CREATE bbb FROM pomoc2
 USE
 DELETE FILE pomoc2.dbf
ENDIF
@ 8,7 SAY "Kreirana je baza podataka BBB.DBF !"
*IF ! ("ccc.dbf")
* p_mat[3,4]
* p_mat[1,1] := "nas"
* p_mat[1,2] := "c"
* p_mat[1,3] := 2
* p_mat[1,4] := 0
* p_mat[2,1] := "ozn"
* p_mat[2,2] := "n"
* p_mat[2,3] := 1
* p_mat[2,4] := 0
* p_mat[3,1] := "kol"
* p_mat[3,2] := "n"
* p_mat[3,3] := 9
* p_mat[3,4] := 3
* DBCREATE("ccc", p_mat)
* USE
*ENDIF
*@ 9,7 SAY "Kreirana je baza podataka CCC.DBF !"
QUIT

 

