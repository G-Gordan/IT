CLEAR

matr:=DIRECTORY()

IF EMPTY(matr)
 @ 1,2 SAY " M A T R I C A   J E   P R A Z N A   ! "
ELSE
 @ 1,2 SAY " M A T R I C A   J E   I S P U NJ E N A   ! "
ENDIF

ar1:=1
red:=4
m_prov:=SPACE(4)
AADD(matr,"KRAJ")

m_br:=ASCAN(matr,"KRAJ")-1

@ 2,2 SAY "U tekucem direktorijumu ima "+ALLTRIM(STR(m_br))+" fajlova !"

@ 3,1 SAY "Formirana je baza: "
p_matr1:=0
IF ! FILE("podkat.dbf")
 p_matr1:=ARRAY(14,4)
 p_matr1[1,1] := "naziv"
 p_matr1[1,2] := "c"
 p_matr1[1,3] := 8
 p_matr1[1,4] := 0
 p_matr1[2,1] := "ekst"
 p_matr1[2,2] := "c"
 p_matr1[2,3] := 3
 p_matr1[2,4] := 0
 p_matr1[3,1] := "prostor"
 p_matr1[3,2] := "n"
 p_matr1[3,3] := 11
 p_matr1[3,4] := 0
 p_matr1[4,1] := "datumfor"
 p_matr1[4,2] := "d"
 p_matr1[4,3] := 8
 p_matr1[4,4] := 0
 p_matr1[5,1] := "vremefor"
 p_matr1[5,2] := "c"
 p_matr1[5,3] := 8
 p_matr1[5,4] := 0
 p_matr1[6,1] := "doba"
 p_matr1[6,2] := "c"
 p_matr1[6,3] := 1
 p_matr1[6,4] := 0
 p_matr1[7,1] := "indexbaza"
 p_matr1[7,2] := "c"
 p_matr1[7,3] := 8
 p_matr1[7,4] := 0
 p_matr1[8,1] := "imepolja"
 p_matr1[8,2] := "c"
 p_matr1[8,3] := 10
 p_matr1[8,4] := 0
 p_matr1[9,1] := "tippolja"
 p_matr1[9,2] := "c"
 p_matr1[9,3] := 1
 p_matr1[9,4] := 0
 p_matr1[10,1]:= "brmesta"
 p_matr1[10,2]:= "n"
 p_matr1[10,3]:= 3
 p_matr1[10,4]:= 0
 p_matr1[11,1]:= "brdecimala"
 p_matr1[11,2]:= "n"
 p_matr1[11,3]:= 3
 p_matr1[11,4]:= 0
 p_matr1[12,1]:= "bazapodtk"
 p_matr1[12,2]:= "c"
 p_matr1[12,3]:= 8
 p_matr1[12,4]:= 0
 p_matr1[13,1]:= "kljuc"
 p_matr1[13,2]:= "c"
 p_matr1[13,3]:= 10
 p_matr1[13,4]:= 0
 p_matr1[14,1]:= "mozeiline"
 p_matr1[14,2]:= "l"
 p_matr1[14,3]:= 1
 p_matr1[14,4]:= 0
 DBCREATE("podkat", p_matr1)
 CLOSE DATABASES
 IF FILE("podkat.dbf")
  @ 3,20 SAY"PODKAT.DBF ! "
 ENDIF
ENDIF

USE podkat

IF ! FILE("pknazind.ntx")
 INDEX ON naziv TO pknazind
ENDIF
IF ! FILE("pkeksind.ntx")
 INDEX ON ekst TO pkeksind
ENDIF
IF ! FILE("pkproind.ntx")
 INDEX ON prostor TO pkproind
ENDIF
IF ! FILE("pkdatind.ntx")
 INDEX ON datumfor TO pkdatind
ENDIF
IF ! FILE("pkvreind.ntx")
 INDEX ON vremefor TO pkvreind
ENDIF
IF ! FILE("pkdobind.ntx")
 INDEX ON doba TO pkdobind
ENDIF
IF ! FILE("pkindind.ntx")
 INDEX ON indexbaza TO pkindind
ENDIF
IF ! FILE("pkimeind.ntx")
 INDEX ON imepolja TO pkimeind
ENDIF
IF ! FILE("pktipind.ntx")
 INDEX ON tippolja TO pktipind
ENDIF
IF ! FILE("pkbrmind.ntx")
 INDEX ON brmesta TO pkbrmind
ENDIF
IF ! FILE("pkbrdind.ntx")
 INDEX ON brdecimala TO pkbrdind
ENDIF
IF ! FILE("pkbazind.ntx")
 INDEX ON bazapodtk TO pkbazind
ENDIF
IF ! FILE("pkkljind.ntx")
 INDEX ON kljuc TO pkkljind
ENDIF
IF ! FILE("pkmozind.ntx")
 INDEX ON mozeiline TO pkmozind
ENDIF


*DO WHILE .T.
* @ red,2 SAY ALLTRIM(STR(ar1))+"     "+matr[ar1,1]+"   "+STR(matr[ar1,2])+;
*             "   "+DTOC(matr[ar1,3])+"   "+matr[ar1,4]+"   "+matr[ar1,5]
* IF m_br=ar1
*  @ red+2,2 SAY "NEMA VISE !"
*  EXIT
* ENDIF
* ar1:=ar1+1
* red:=red+1
* IF red=21
*  @ red+2,2 SAY "Pritisnite bilo sta za dalje listanje !"
*  INKEY(0)
*  CLEAR SCREEN
*  red:=4
* ENDIF
*ENDDO

QUIT
