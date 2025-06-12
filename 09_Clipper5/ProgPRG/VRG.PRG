
CLS

SET DATE GERMAN


*****Formiranje radne baze IMEBAZE.DBF*****
p_mat2:=0
p_mat2:=ARRAY(1,4)
p_mat2[1,1] := "vreme"
p_mat2[1,2] := "d"
p_mat2[1,3] := 8
p_mat2[1,4] := 0

DBCREATE("bzdtg", p_mat2)
vremsis:=DATE()

@ 2,1 SAY DTOC(vremsis)

USE bzdtg
APPEND BLANK
REPLACE vreme WITH vremsis

QUIT
