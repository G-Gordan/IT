
CLS

SET DATE FRENCH


*****Formiranje radne baze IMEBAZE.DBF*****
p_mat2:=0
p_mat2:=ARRAY(1,4)
p_mat2[1,1] := "vreme"
p_mat2[1,2] := "d"
p_mat2[1,3] := 8
p_mat2[1,4] := 0

DBCREATE("bzdtf", p_mat2)
vremsis:=DATE()

@ 2,1 SAY DTOC(vremsis)

USE bzdtf
APPEND BLANK
REPLACE vreme WITH vremsis

QUIT
