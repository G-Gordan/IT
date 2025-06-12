CLEAR SCREEN
p_mat:=0
IF ! FILE("ccc.dbf")
 p_mat:=ARRAY(3,4)
 p_mat[1,1] := "nas"
 p_mat[1,2] := "c"
 p_mat[1,3] := 2
 p_mat[1,4] := 0
 p_mat[2,1] := "ozn"
 p_mat[2,2] := "n"
 p_mat[2,3] := 1
 p_mat[2,4] := 0
 p_mat[3,1] := "kol"
 p_mat[3,2] := "n"
 p_mat[3,3] := 9
 p_mat[3,4] := 3
 DBCREATE("ccc", p_mat)
 USE
 @ 9,7 SAY "Kreirana je baza podataka CCC.DBF !"
ELSE
 @ 9,7 SAY "Baza podataka CCC.DBF vec postoji !"
ENDIF
QUIT
