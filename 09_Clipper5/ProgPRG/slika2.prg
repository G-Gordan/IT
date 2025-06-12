***************Ispisuje "Z-SOFT" slovo po slovo******************


SET CURSOR OFF
SET COLOR TO "GR+/N"
CLS

********** Paleta boja ***********
@ 1,29 SAY "P A L E T A   B O J A"
@ 3,25 SAY CHR(219) COLOR"W+/N"
@ 3,27 SAY CHR(219) COLOR"W/N"
@ 3,29 SAY CHR(219) COLOR"GR+/N"
@ 3,31 SAY CHR(219) COLOR"R+/N"
@ 3,33 SAY CHR(219) COLOR"R/N"
@ 3,35 SAY CHR(219) COLOR"RB+/N"
@ 3,37 SAY CHR(219) COLOR"RB/N"
@ 3,39 SAY CHR(219) COLOR"BG+/N"
@ 3,41 SAY CHR(219) COLOR"BG/N"
@ 3,43 SAY CHR(219) COLOR"B+/N"
@ 3,45 SAY CHR(219) COLOR"B/N"
@ 3,47 SAY CHR(219) COLOR"G+/N"
@ 3,49 SAY CHR(219) COLOR"G/N"
@ 3,51 SAY CHR(219) COLOR"GR/N"
@ 3,53 SAY CHR(219) COLOR"N+/N"



********* Matrica za slovo "Z" **********
*****Postavka promenljivih********
m_br:=0
p_brisp:=1

p_mtr1:=0
p_mtr1:=ARRAY(40,2)

*****1. red*****
p_mtr1[1,1]:=21
p_mtr1[1,2]:=4
p_mtr1[2,1]:=21
p_mtr1[2,2]:=5
p_mtr1[3,1]:=21
p_mtr1[3,2]:=6
p_mtr1[4,1]:=21
p_mtr1[4,2]:=7
p_mtr1[5,1]:=21
p_mtr1[5,2]:=8
p_mtr1[6,1]:=21
p_mtr1[6,2]:=9
p_mtr1[7,1]:=21
p_mtr1[7,2]:=10
p_mtr1[8,1]:=21
p_mtr1[8,2]:=11
p_mtr1[9,1]:=21
p_mtr1[9,2]:=12
p_mtr1[10,1]:=21
p_mtr1[10,2]:=13
p_mtr1[11,1]:=21
p_mtr1[11,2]:=14

****2. red******
p_mtr1[12,1]:=20
p_mtr1[12,2]:=5
p_mtr1[13,1]:=20
p_mtr1[13,2]:=6

****3. red*****
p_mtr1[14,1]:=19
p_mtr1[14,2]:=6
p_mtr1[15,1]:=19
p_mtr1[15,2]:=7

*****4. red*****
p_mtr1[16,1]:=18
p_mtr1[16,2]:=7
p_mtr1[17,1]:=18
p_mtr1[17,2]:=8
       
*****5. red*****
p_mtr1[18,1]:=17
p_mtr1[18,2]:=8
p_mtr1[19,1]:=17
p_mtr1[19,2]:=9

*****6. red*****
p_mtr1[20,1]:=16
p_mtr1[20,2]:=9
p_mtr1[21,1]:=16
p_mtr1[21,2]:=10

*****7. red*****
p_mtr1[22,1]:=15
p_mtr1[22,2]:=10
p_mtr1[23,1]:=15
p_mtr1[23,2]:=11

*****8. red*****
p_mtr1[24,1]:=14
p_mtr1[24,2]:=11
p_mtr1[25,1]:=14
p_mtr1[25,2]:=12

*****9. red*****
p_mtr1[26,1]:=13
p_mtr1[26,2]:=12
p_mtr1[27,1]:=13
p_mtr1[27,2]:=13

*****10.red*****
p_mtr1[28,1]:=12
p_mtr1[28,2]:=13
p_mtr1[29,1]:=12
p_mtr1[29,2]:=14

*****11. red****
p_mtr1[30,1]:=11
p_mtr1[30,2]:=4
p_mtr1[31,1]:=11
p_mtr1[31,2]:=5
p_mtr1[32,1]:=11
p_mtr1[32,2]:=6
p_mtr1[33,1]:=11
p_mtr1[33,2]:=7
p_mtr1[34,1]:=11
p_mtr1[34,2]:=8
p_mtr1[35,1]:=11
p_mtr1[35,2]:=9
p_mtr1[36,1]:=11
p_mtr1[36,2]:=10
p_mtr1[37,1]:=11
p_mtr1[37,2]:=11
p_mtr1[38,1]:=11
p_mtr1[38,2]:=12
p_mtr1[39,1]:=11
p_mtr1[39,2]:=13
p_mtr1[40,1]:=11
p_mtr1[40,2]:=14

**********Ubacivanje granicnika*************
AADD(p_mtr1,"KRAJ")
m_br:=ASCAN(p_mtr1,"KRAJ")
*? m_br

******Ispisivanje***********
DO WHILE .T.
 @ p_mtr1[p_brisp,1],p_mtr1[p_brisp,2] SAY CHR(219)
 p_brisp:=p_brisp+1
 IF p_brisp=m_br
  EXIT
 ENDIF
ENDDO
INKEY(0.5)


********* Matrica za znak "-" **********
*****Postavka promenljivih********
m_br:=0
p_brisp:=1

p_mtr2:=0
p_mtr2:=ARRAY(5,2)

*****6. red****
p_mtr2[1,1]:=16
p_mtr2[1,2]:=17
p_mtr2[2,1]:=16
p_mtr2[2,2]:=18
p_mtr2[3,1]:=16
p_mtr2[3,2]:=19
p_mtr2[4,1]:=16
p_mtr2[4,2]:=20
p_mtr2[5,1]:=16
p_mtr2[5,2]:=21

**********Ubacivanje granicnika*************
AADD(p_mtr2,"KRAJ")
m_br:=ASCAN(p_mtr2,"KRAJ")
*? m_br

******Ispisivanje***********
DO WHILE .T.
 @ p_mtr2[p_brisp,1],p_mtr2[p_brisp,2] SAY CHR(219)
 p_brisp:=p_brisp+1
 IF p_brisp=m_br
  EXIT
 ENDIF
ENDDO
INKEY(0.5)


*********** Matrica za slovo "S" **********
*****Postavka promenljivih********
m_br:=0
p_brisp:=1

p_mtr3:=0
p_mtr3:=ARRAY(43,2)
     
****1. red****
p_mtr3[1,1]:=21
p_mtr3[1,2]:=25
p_mtr3[2,1]:=21
p_mtr3[2,2]:=26
p_mtr3[3,1]:=21
p_mtr3[3,2]:=27
p_mtr3[4,1]:=21
p_mtr3[4,2]:=28
p_mtr3[5,1]:=21
p_mtr3[5,2]:=29
p_mtr3[6,1]:=21
p_mtr3[6,2]:=30
p_mtr3[7,1]:=21
p_mtr3[7,2]:=31
p_mtr3[8,1]:=21
p_mtr3[8,2]:=32

*****2. red*****
**1**
p_mtr3[9,1]:=20
p_mtr3[9,2]:=24
p_mtr3[10,1]:=20
p_mtr3[10,2]:=25
**2**
p_mtr3[11,1]:=20
p_mtr3[11,2]:=32
p_mtr3[12,1]:=20
p_mtr3[12,2]:=33

*****3. red****
p_mtr3[13,1]:=19
p_mtr3[13,2]:=33
p_mtr3[14,1]:=19
p_mtr3[14,2]:=34

*****4. red*****
p_mtr3[15,1]:=18
p_mtr3[15,2]:=33
p_mtr3[16,1]:=18
p_mtr3[16,2]:=34

*****5. red*****
p_mtr3[17,1]:=17
p_mtr3[17,2]:=33
p_mtr3[18,1]:=17
p_mtr3[18,2]:=34

******6. red****
p_mtr3[19,1]:=16
p_mtr3[19,2]:=32
p_mtr3[20,1]:=16
p_mtr3[20,2]:=33

*****7. red*****
p_mtr3[21,1]:=15
p_mtr3[21,2]:=26
p_mtr3[22,1]:=15
p_mtr3[22,2]:=27
p_mtr3[23,1]:=15
p_mtr3[23,2]:=28
p_mtr3[24,1]:=15
p_mtr3[24,2]:=29
p_mtr3[25,1]:=15
p_mtr3[25,2]:=30
p_mtr3[26,1]:=15
p_mtr3[26,2]:=31
p_mtr3[27,1]:=15
p_mtr3[27,2]:=32

*****8. red*****
p_mtr3[28,1]:=14
p_mtr3[28,2]:=25
p_mtr3[29,1]:=14
p_mtr3[29,2]:=26
     
*****9. red*****
p_mtr3[30,1]:=13
p_mtr3[30,2]:=24
p_mtr3[31,1]:=13
p_mtr3[31,2]:=25

*****10. red****
**1**
p_mtr3[32,1]:=12
p_mtr3[32,2]:=25
p_mtr3[33,1]:=12
p_mtr3[33,2]:=26
**2**
p_mtr3[34,1]:=12
p_mtr3[34,2]:=33
p_mtr3[35,1]:=12
p_mtr3[35,2]:=34

*****11. red****
p_mtr3[36,1]:=11
p_mtr3[36,2]:=26
p_mtr3[37,1]:=11
p_mtr3[37,2]:=27
p_mtr3[38,1]:=11
p_mtr3[38,2]:=28
p_mtr3[39,1]:=11
p_mtr3[39,2]:=29
p_mtr3[40,1]:=11
p_mtr3[40,2]:=30
p_mtr3[41,1]:=11
p_mtr3[41,2]:=31
p_mtr3[42,1]:=11
p_mtr3[42,2]:=32
p_mtr3[43,1]:=11
p_mtr3[43,2]:=33

**********Ubacivanje granicnika*************
AADD(p_mtr3,"KRAJ")
m_br:=ASCAN(p_mtr3,"KRAJ")
*? m_br

******Ispisivanje***********
DO WHILE .T.
 @ p_mtr3[p_brisp,1],p_mtr3[p_brisp,2] SAY CHR(219)
 p_brisp:=p_brisp+1
 IF p_brisp=m_br
  EXIT
 ENDIF
ENDDO
INKEY(0.5)


********* Matrica za slovo "O" **************
*****Postavka promenljivih********
m_br:=0
p_brisp:=1

p_mtr4:=0
p_mtr4:=ARRAY(50,2)

****1. red****
p_mtr4[1,1]:=21
p_mtr4[1,2]:=40
p_mtr4[2,1]:=21
p_mtr4[2,2]:=41
p_mtr4[3,1]:=21
p_mtr4[3,2]:=42
p_mtr4[4,1]:=21
p_mtr4[4,2]:=43
p_mtr4[5,1]:=21
p_mtr4[5,2]:=44

****2. red****
**1**
p_mtr4[6,1]:=20
p_mtr4[6,2]:=38
p_mtr4[7,1]:=20
p_mtr4[7,2]:=39
p_mtr4[8,1]:=20
p_mtr4[8,2]:=40
**2**
p_mtr4[9,1]:=20
p_mtr4[9,2]:=44
p_mtr4[10,1]:=20
p_mtr4[10,2]:=45
p_mtr4[11,1]:=20
p_mtr4[11,2]:=46

****3. red****
**1**
p_mtr4[12,1]:=19
p_mtr4[12,2]:=37
p_mtr4[13,1]:=19
p_mtr4[13,2]:=38
**2**
p_mtr4[14,1]:=19
p_mtr4[14,2]:=46
p_mtr4[15,1]:=19
p_mtr4[15,2]:=47

*****4. red*****
**1**
p_mtr4[16,1]:=18
p_mtr4[16,2]:=37
p_mtr4[17,1]:=18
p_mtr4[17,2]:=38
**2**
p_mtr4[18,1]:=18
p_mtr4[18,2]:=46
p_mtr4[19,1]:=18
p_mtr4[19,2]:=47

*****5. red****
**1**
p_mtr4[20,1]:=17
p_mtr4[20,2]:=37
p_mtr4[21,1]:=17
p_mtr4[21,2]:=38
**2**  
p_mtr4[22,1]:=17
p_mtr4[22,2]:=46
p_mtr4[23,1]:=17
p_mtr4[23,2]:=47
       
****6. red****
**1**
p_mtr4[24,1]:=16
p_mtr4[24,2]:=37
p_mtr4[25,1]:=16
p_mtr4[25,2]:=38
**2**
p_mtr4[26,1]:=16
p_mtr4[26,2]:=46
p_mtr4[27,1]:=16
p_mtr4[27,2]:=47

****7. red****
**1**
p_mtr4[28,1]:=15
p_mtr4[28,2]:=37
p_mtr4[29,1]:=15
p_mtr4[29,1]:=38
**2**
p_mtr4[30,1]:=15
p_mtr4[30,2]:=46
p_mtr4[31,1]:=15
p_mtr4[31,2]:=47

****8. red****
**1**
p_mtr4[32,1]:=14
p_mtr4[32,2]:=37
p_mtr4[33,1]:=14
p_mtr4[33,2]:=38
**2**
p_mtr4[34,1]:=14
p_mtr4[34,2]:=46
p_mtr4[35,1]:=14
p_mtr4[35,2]:=47

****9. red****
**1**
p_mtr4[36,1]:=13
p_mtr4[36,2]:=37
p_mtr4[37,1]:=13
p_mtr4[37,2]:=38
**2**
p_mtr4[38,1]:=13
p_mtr4[38,2]:=46
p_mtr4[39,1]:=13
p_mtr4[39,2]:=47

*****10. red****
**1**
p_mtr4[40,1]:=12
p_mtr4[40,2]:=38
p_mtr4[41,1]:=12
p_mtr4[41,2]:=39
p_mtr4[42,1]:=12
p_mtr4[42,2]:=40
**2**
p_mtr4[43,1]:=12
p_mtr4[43,2]:=44
p_mtr4[44,1]:=12
p_mtr4[44,2]:=45
p_mtr4[45,1]:=12
p_mtr4[45,2]:=46

****11. red****
p_mtr4[46,1]:=11
p_mtr4[46,2]:=40
p_mtr4[47,1]:=11
p_mtr4[47,2]:=41
p_mtr4[48,1]:=11
p_mtr4[48,2]:=42
p_mtr4[49,1]:=11
p_mtr4[49,2]:=43
p_mtr4[50,1]:=11
p_mtr4[50,1]:=43

**********Ubacivanje granicnika*************
AADD(p_mtr4,"KRAJ")
m_br:=ASCAN(p_mtr4,"KRAJ")
*? m_br

******Ispisivanje***********
DO WHILE .T.
 @ p_mtr4[p_brisp,1],p_mtr4[p_brisp,2] SAY CHR(219)
 p_brisp:=p_brisp+1
 IF p_brisp=m_br
  EXIT
 ENDIF
ENDDO
INKEY(0.5)


************* Matrica za slovo "F" ***************
*****Postavka promenljivih********
m_br:=0
p_brisp:=1

p_mtr5:=0
p_mtr5:=ARRAY(46,2)

****1. red****             
p_mtr5[1,1]:=21
p_mtr5[1,2]:=50
p_mtr5[2,1]:=21
p_mtr5[2,2]:=51
p_mtr5[3,1]:=21
p_mtr5[3,2]:=52

****2. red****
p_mtr5[4,1]:=20
p_mtr5[4,2]:=50
p_mtr5[5,1]:=20
p_mtr5[5,2]:=51
p_mtr5[6,1]:=20
p_mtr5[6,2]:=52

****3. red****
p_mtr5[7,1]:=19
p_mtr5[7,2]:=50
p_mtr5[8,1]:=19
p_mtr5[8,2]:=51
p_mtr5[9,1]:=19
p_mtr5[9,2]:=52

****4. red****
p_mtr5[10,1]:=18
p_mtr5[10,2]:=50
p_mtr5[11,1]:=18
p_mtr5[11,2]:=51
p_mtr5[12,1]:=18
p_mtr5[12,2]:=52

****5. red****
p_mtr5[13,1]:=17
p_mtr5[13,2]:=50
p_mtr5[14,1]:=17
p_mtr5[14,2]:=51
p_mtr5[15,1]:=17
p_mtr5[15,2]:=52

*****6. red*****
p_mtr5[16,1]:=16
p_mtr5[16,2]:=50
p_mtr5[17,1]:=16
p_mtr5[17,2]:=51
p_mtr5[18,1]:=16
p_mtr5[18,2]:=52

*****7. red*****
p_mtr5[19,1]:=15
p_mtr5[19,2]:=50
p_mtr5[20,1]:=15
p_mtr5[20,2]:=51
p_mtr5[21,1]:=15
p_mtr5[21,2]:=52
p_mtr5[22,1]:=15
p_mtr5[22,2]:=53
p_mtr5[23,1]:=15
p_mtr5[23,2]:=54
p_mtr5[24,1]:=15
p_mtr5[24,2]:=55
p_mtr5[25,1]:=15
p_mtr5[25,2]:=56
p_mtr5[26,1]:=15
p_mtr5[26,2]:=57

*****8. red*****
p_mtr5[27,1]:=14
p_mtr5[27,2]:=50
p_mtr5[28,1]:=14
p_mtr5[28,2]:=51
p_mtr5[29,1]:=14
p_mtr5[29,2]:=52

*****9. red*****
p_mtr5[30,1]:=13
p_mtr5[30,2]:=50
p_mtr5[31,1]:=13
p_mtr5[31,2]:=51
p_mtr5[32,1]:=13
p_mtr5[32,2]:=52

*****10. red****
p_mtr5[33,1]:=12
p_mtr5[33,2]:=50
p_mtr5[34,1]:=12
p_mtr5[34,2]:=51
p_mtr5[35,1]:=12
p_mtr5[35,2]:=52

*****11. red****
p_mtr5[36,1]:=11
p_mtr5[36,2]:=50
p_mtr5[37,1]:=11
p_mtr5[37,2]:=51
p_mtr5[38,1]:=11
p_mtr5[38,2]:=52
p_mtr5[39,1]:=11
p_mtr5[39,2]:=53
p_mtr5[40,1]:=11
p_mtr5[40,2]:=54
p_mtr5[41,1]:=11
p_mtr5[41,2]:=55
p_mtr5[42,1]:=11
p_mtr5[42,2]:=56
p_mtr5[43,1]:=11
p_mtr5[43,2]:=57
p_mtr5[44,1]:=11
p_mtr5[44,2]:=58
p_mtr5[45,1]:=11
p_mtr5[45,2]:=59
p_mtr5[46,1]:=11
p_mtr5[46,2]:=60

**********Ubacivanje granicnika*************
AADD(p_mtr5,"KRAJ")
m_br:=ASCAN(p_mtr5,"KRAJ")
*? m_br

******Ispisivanje***********
DO WHILE .T.
 @ p_mtr5[p_brisp,1],p_mtr5[p_brisp,2] SAY CHR(219)
 p_brisp:=p_brisp+1
 IF p_brisp=m_br
  EXIT
 ENDIF
ENDDO
INKEY(0.5)


*************** Matrica za slovo "T" ***********
*****Postavka promenljivih********
m_br:=0
p_brisp:=1

p_mtr6:=0
p_mtr6:=ARRAY(41,2)

*****1. red*****
p_mtr6[1,1]:=21
p_mtr6[1,2]:=67
p_mtr6[2,1]:=21
p_mtr6[2,2]:=68
p_mtr6[3,1]:=21
p_mtr6[3,2]:=69

*****2. red*****
p_mtr6[4,1]:=20
p_mtr6[4,2]:=67
p_mtr6[5,1]:=20
p_mtr6[5,2]:=68
p_mtr6[6,1]:=20
p_mtr6[6,2]:=69

*****3. red*****
p_mtr6[7,1]:=19
p_mtr6[7,2]:=67
p_mtr6[8,1]:=19
p_mtr6[8,2]:=68
p_mtr6[9,1]:=19
p_mtr6[9,2]:=69

*****4. red*****
p_mtr6[10,1]:=18
p_mtr6[10,2]:=67
p_mtr6[11,1]:=18
p_mtr6[11,2]:=68
p_mtr6[12,1]:=18
p_mtr6[12,2]:=69

*****5. red*****
p_mtr6[13,1]:=17
p_mtr6[13,2]:=67
p_mtr6[14,1]:=17
p_mtr6[14,2]:=68
p_mtr6[15,1]:=17
p_mtr6[15,2]:=69

*****6. red*****
p_mtr6[16,1]:=16
p_mtr6[16,2]:=67
p_mtr6[17,1]:=16
p_mtr6[17,2]:=68
p_mtr6[18,1]:=16
p_mtr6[18,2]:=69

*****7. red*****
p_mtr6[19,1]:=15
p_mtr6[19,2]:=67
p_mtr6[20,1]:=15
p_mtr6[20,2]:=68
p_mtr6[21,1]:=15
p_mtr6[21,2]:=69

*****8. red*****
p_mtr6[22,1]:=14
p_mtr6[22,2]:=67
p_mtr6[23,1]:=14
p_mtr6[23,2]:=68
p_mtr6[24,1]:=14
p_mtr6[24,2]:=69

*****9. red******
p_mtr6[25,1]:=13
p_mtr6[25,2]:=67
p_mtr6[26,1]:=13
p_mtr6[26,2]:=68
p_mtr6[27,1]:=13
p_mtr6[27,2]:=69

*****10. red*****
p_mtr6[28,1]:=12
p_mtr6[28,2]:=67
p_mtr6[29,1]:=12
p_mtr6[29,2]:=68
p_mtr6[30,1]:=12
p_mtr6[30,2]:=69

*****11. red*****
p_mtr6[31,1]:=11
p_mtr6[31,2]:=63
p_mtr6[32,1]:=11
p_mtr6[32,2]:=64
p_mtr6[33,1]:=11
p_mtr6[33,2]:=65
p_mtr6[34,1]:=11
p_mtr6[34,2]:=66
p_mtr6[35,1]:=11
p_mtr6[35,2]:=67
p_mtr6[36,1]:=11
p_mtr6[36,2]:=68
p_mtr6[37,1]:=11
p_mtr6[37,2]:=69
p_mtr6[38,1]:=11
p_mtr6[38,2]:=70
p_mtr6[39,1]:=11
p_mtr6[39,2]:=71
p_mtr6[40,1]:=11
p_mtr6[40,2]:=72
p_mtr6[41,1]:=11
p_mtr6[41,2]:=73

**********Ubacivanje granicnika*************
AADD(p_mtr6,"KRAJ")
m_br:=ASCAN(p_mtr6,"KRAJ")
*? m_br

******Ispisivanje***********
DO WHILE .T.
 @ p_mtr6[p_brisp,1],p_mtr6[p_brisp,2] SAY CHR(219)
 p_brisp:=p_brisp+1
 IF p_brisp=m_br
  EXIT
 ENDIF
ENDDO
INKEY(1.7)


********Izlazak***********

SET CURSOR ON
SET COLOR TO "W/N"
@ 23,0 CLEAR TO 24,79
QUIT



***************KRAJ*****************



