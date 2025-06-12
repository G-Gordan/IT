
**********************************************************
********************ISPIS POKRETNOG LOGO-a****************
**********************************************************

SET CURSOR OFF
SET COLOR TO "GR+/B"
CLS


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

*******Postavka promenljivih za ispis i kretanje********
p_red:=0
p_kol:=0
p_brred:=21
p_1brojac:=1
p_2brojac:=1
p_brisp:=1
p_redgl:=0
p_kolgl:=0
p_reddd:=0
p_koldd:=0

**********Ispis i kretanje**********
DO WHILE .T.

********Jedan ispis************
 DO WHILE .T.

  p_red:=p_mtr1[p_2brojac,1]-p_brred
  p_kol:=p_mtr1[p_2brojac,2]
  @ p_red,p_kol SAY CHR(219)
  p_brisp:=p_brisp+1
  IF p_brisp=m_br
   p_brisp:=1
   EXIT
  ENDIF
  p_2brojac:=p_2brojac+1

 ENDDO
 p_2brojac:=1

***********Brzina padanja********
 INKEY(0.05)

************Granicnik (izbacuje u 22. redu)***********
 p_1brojac:=p_1brojac+1
 IF p_1brojac=24
  EXIT
 ENDIF

********Brisac prethodno ispisanog znaka**********
 p_redgl:=11-p_brred
 p_reddd:=21-p_brred
 @ p_redgl,4 CLEAR TO p_reddd,14
 p_brred:=p_brred-1

ENDDO


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

*******Postavka promenljivih za ispis i kretanje********
p_red:=0
p_kol:=0
p_brred:=16
p_1brojac:=1
p_2brojac:=1
p_brisp:=1
p_redgl:=0
p_kolgl:=0
p_reddd:=0
p_koldd:=0

**********Ispis i kretanje**********
DO WHILE .T.

********Jedan ispis************
 DO WHILE .T.

  p_red:=p_mtr2[p_2brojac,1]-p_brred
  p_kol:=p_mtr2[p_2brojac,2]
  @ p_red,p_kol SAY CHR(219)
  p_brisp:=p_brisp+1
  IF p_brisp=m_br
   p_brisp:=1
   EXIT
  ENDIF
  p_2brojac:=p_2brojac+1

 ENDDO
 p_2brojac:=1

*******Brzina padanja********
 INKEY(0.05)

************Granicnik (izbacuje u 17. redu)***********
 p_1brojac:=p_1brojac+1
 IF p_1brojac=19
  EXIT
 ENDIF

********Brisac prethodno ispisanog znaka**********
 p_redgl:=16-p_brred
 p_reddd:=16-p_brred
 @ p_redgl,17 CLEAR TO p_reddd,21
 p_brred:=p_brred-1

ENDDO


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

*******Postavka promenljivih za ispis i kretanje********
p_red:=0
p_kol:=0
p_brred:=21
p_1brojac:=1
p_2brojac:=1
p_brisp:=1
p_redgl:=0
p_kolgl:=0
p_reddd:=0
p_koldd:=0

**********Ispis i kretanje**********
DO WHILE .T.

********Jedan ispis************
 DO WHILE .T.

  p_red:=p_mtr3[p_2brojac,1]-p_brred
  p_kol:=p_mtr3[p_2brojac,2]
  @ p_red,p_kol SAY CHR(219)
  p_brisp:=p_brisp+1
  IF p_brisp=m_br
   p_brisp:=1
   EXIT
  ENDIF
  p_2brojac:=p_2brojac+1

 ENDDO
 p_2brojac:=1

*******Brzina padanja********
 INKEY(0.05)

************Granicnik (izbacuje u 22. redu)***********
 p_1brojac:=p_1brojac+1
 IF p_1brojac=24
  EXIT
 ENDIF

********Brisac prethodno ispisanog znaka**********
 p_redgl:=11-p_brred
 p_reddd:=21-p_brred
 @ p_redgl,24 CLEAR TO p_reddd,34
 p_brred:=p_brred-1

ENDDO


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

*******Postavka promenljivih za ispis i kretanje********
p_red:=0
p_kol:=0
p_brred:=21
p_1brojac:=1
p_2brojac:=1
p_brisp:=1
p_redgl:=0
p_kolgl:=0
p_reddd:=0
p_koldd:=0

**********Ispis i kretanje**********
DO WHILE .T.

********Jedan ispis************
 DO WHILE .T.

  p_red:=p_mtr4[p_2brojac,1]-p_brred
  p_kol:=p_mtr4[p_2brojac,2]
  @ p_red,p_kol SAY CHR(219)
  p_brisp:=p_brisp+1
  IF p_brisp=m_br
   p_brisp:=1
   EXIT
  ENDIF
  p_2brojac:=p_2brojac+1

 ENDDO
 p_2brojac:=1

********Brzina padanja********
 INKEY(0.05)

************Granicnik (izbacuje u 22. redu)***********
 p_1brojac:=p_1brojac+1
 IF p_1brojac=24
  EXIT
 ENDIF

********Brisac prethodno ispisanog znaka**********
 p_redgl:=11-p_brred
 p_reddd:=21-p_brred
 @ p_redgl,37 CLEAR TO p_reddd,47
 p_brred:=p_brred-1

ENDDO


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

*******Postavka promenljivih za ispis i kretanje********
p_red:=0
p_kol:=0
p_brred:=21
p_1brojac:=1
p_2brojac:=1
p_brisp:=1
p_redgl:=0
p_kolgl:=0
p_reddd:=0
p_koldd:=0

**********Ispis i kretanje**********
DO WHILE .T.

********Jedan ispis************
 DO WHILE .T.

  p_red:=p_mtr5[p_2brojac,1]-p_brred
  p_kol:=p_mtr5[p_2brojac,2]
  @ p_red,p_kol SAY CHR(219)
  p_brisp:=p_brisp+1
  IF p_brisp=m_br
   p_brisp:=1
   EXIT
  ENDIF
  p_2brojac:=p_2brojac+1

 ENDDO
 p_2brojac:=1

*********Brzina padanja*********
 INKEY(0.05)

************Granicnik (izbacuje u 22. redu)***********
 p_1brojac:=p_1brojac+1
 IF p_1brojac=24
  EXIT
 ENDIF

********Brisac prethodno ispisanog znaka**********
 p_redgl:=11-p_brred
 p_reddd:=21-p_brred
 @ p_redgl,50 CLEAR TO p_reddd,60
 p_brred:=p_brred-1

ENDDO


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

*******Postavka promenljivih za ispis i kretanje********
p_red:=0
p_kol:=0
p_brred:=21
p_1brojac:=1
p_2brojac:=1
p_brisp:=1
p_redgl:=0
p_kolgl:=0
p_reddd:=0
p_koldd:=0

**********Ispis i kretanje**********
DO WHILE .T.

********Jedan ispis************
 DO WHILE .T.

  p_red:=p_mtr6[p_2brojac,1]-p_brred
  p_kol:=p_mtr6[p_2brojac,2]
  @ p_red,p_kol SAY CHR(219)
  p_brisp:=p_brisp+1
  IF p_brisp=m_br
   p_brisp:=1
   EXIT
  ENDIF
  p_2brojac:=p_2brojac+1

 ENDDO
 p_2brojac:=1

********Brzina padanja********
 INKEY(0.05)

************Granicnik (izbacuje u 22. redu)***********
 p_1brojac:=p_1brojac+1
 IF p_1brojac=24
  EXIT
 ENDIF

********Brisac prethodno ispisanog znaka**********
 p_redgl:=11-p_brred
 p_reddd:=21-p_brred
 @ p_redgl,63 CLEAR TO p_reddd,73
 p_brred:=p_brred-1

ENDDO


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
@ 3,45 SAY CHR(219) COLOR"N/N"
@ 3,47 SAY CHR(219) COLOR"G+/N"
@ 3,49 SAY CHR(219) COLOR"G/N"
@ 3,51 SAY CHR(219) COLOR"GR/N"
@ 3,53 SAY CHR(219) COLOR"N+/N"


*******Zastoj******
INKEY(3)


**********************************************************************
*****************************GLAVNI MENI ZA RAD***********************
**********************************************************************

SET COLOR TO "GR+/R,G/RB+,,,"
CLS
SET WRAP ON
SET MESSAGE TO 23 CENTER
@ 4,27 TO 10,51

DO WHILE .T.

*Senka na prompotovima*
* m_yred:=5
* FOR y=1 TO 3
*   @ m_yred,33 SAY REPLICATE(CHR(219),12) COLOR "RB+/RB+"
*   m_yred:=m_yred+2
* NEXT
* m_xred:=6
* FOR x=1 TO 3
*   @ m_xred-1,45 SAY CHR(220) COLOR "RB/R"
*   @ m_xred,34 SAY REPLICATE(CHR(223),12) COLOR "RB/R"
*   m_xred:=m_xred+2
* NEXT

* SET COLOR TO "GR+/RB+"
 p_izbor:=1
 @ 5,33 PROMPT "Direktorijum";
 MESSAGE ("Ispitivanje tekuceg dirktorijuma (listanje fajlova)")
 @ 7,33 PROMPT "Polja - baza";
 MESSAGE ("Ispitivanje izabrane data baze (karakteristike polja)")
 @ 9,33 PROMPT "Indeksiranje";
 MESSAGE ("Indeksiranje izabrane baze po izbranom kljucu (-vima)")
 CLEAR TYPEAHEAD
 MENU TO p_izbor

 DO CASE
  CASE p_izbor=0
   @ 23,2 SAY "Izabrali ste ESC"
   EXIT
  CASE p_izbor=1
   DO ispdrkt
  CASE p_izbor=2
   DO ispbaza
  CASE p_izbor=3
   DO indksbz
  ENDCASE

ENDDO

SET COLOR TO "N/G"
CLS
@ 11,31 SAY "KRAJ PROGRAMA - 3" 
INKEY(1.5)
SET COLOR TO "N/GR"
CLS
@ 11,31 SAY "KRAJ PROGRAMA - 2" 
INKEY(1.5)
SET COLOR TO "N/R"
CLS
@ 11,31 SAY "KRAJ PROGRAMA - 1" 
INKEY(1.5)

SET COLOR TO "W/N"
CLS
QUIT
************************** K R A J programa *********************



*****************************ISPITIVANJE DIREKTORIJUMA**********************
PROCEDURE ISPDRKT
************Ispis fajlova tekuceg direktorija sa karakteristikama***********

CLEAR
SET DATE GERMAN
SET CONFIRM ON
SET CURSOR OFF

CLOSE DATABASES
ERASE podgran.dbf

matr:=DIRECTORY()

ar1:=1
red:=4
m_prov:=SPACE(4)
AADD(matr,"KRAJ")

m_br:=ASCAN(matr,"KRAJ")


*************Upis podataka o direktorijumu iz matrice u bazu***************

******Formiranje baze koja prihvata podatke o dirktorijumu iz matrice*******

SET COLOR TO "W/B,"

CLS
p_mat:=0

p_mat:=ARRAY(6,4)
p_mat[1,1] := "redbr"
p_mat[1,2] := "n"
p_mat[1,3] := 6
p_mat[1,4] := 0
p_mat[2,1] := "imeekst"
p_mat[2,2] := "c"
p_mat[2,3] := 75
p_mat[2,4] := 0
p_mat[3,1] := "velicina"
p_mat[3,2] := "n"
p_mat[3,3] := 14
p_mat[3,4] := 0
p_mat[4,1] := "datum"
p_mat[4,2] := "d"
p_mat[4,3] := 0
p_mat[4,4] := 0
p_mat[5,1] := "vreme"
p_mat[5,2] := "c"
p_mat[5,3] := 8
p_mat[5,4] := 0
p_mat[6,1] := "a"
p_mat[6,2] := "c"
p_mat[6,3] := 4
p_mat[6,4] := 0

DBCREATE("podgran", p_mat)
USE
@ 9,7 SAY "Kreirana je baza podataka PODGRAN.DBF !" COLOR "G+/B"
@ 10,7 SAY "Baza PODGRAN.DBF se puni fajlovima tekuceg direktorija !" ;
            COLOR "W/B"

***************Podloga za skalu*************

m_brfajl:=m_br-1
m_kol:=7
FOR i=1 TO 50
 @ 20,m_kol SAY CHR(176) COLOR "GR+/B"
 m_kol:=m_kol+1
NEXT

***************Upis u bazu i brojanje skale************

m_brf:=1
m_pr:=0
m_or:=2
m_kol:=7
m_brkc:=0
m_kol2:=0
m_kol3:=0
m_razlika:=0
m_brraz:=1

DO WHILE .T.

 IF m_br=ar1
  @ 10,0 CLEAR TO 11,78 
  @ 10,7 SAY "Baza PODGRAN.DBF je napunjena !" COLOR "G+/B"
  INKEY(2)
  EXIT
 ENDIF

 USE podgran
 APPEND BLANK
 REPLACE redbr WITH ar1, imeekst WITH matr[ar1,1],;
         velicina WITH matr[ar1,2], datum WITH matr[ar1,3],;
         vreme WITH matr[ar1,4],;
         a WITH matr[ar1,5]
 
 ar1:=ar1+1

 m_pr:=100*m_brf/m_brfajl
 m_brkc:=m_pr/2
 m_brkc:=ROUND(m_brkc,0)
 FOR i=1 TO m_brkc
  @ 20,m_kol SAY CHR(219) COLOR "GR+/B"
  @ 20,59 SAY STR(m_pr,6,2)+" %" COLOR"GR+/B"
  m_kol:=m_kol+1
 NEXT
 m_kol:=7
 m_brf:=m_brf+1

ENDDO
CLOSE DATABASES


*************************Ispisivanje na ekranu*******************

SET CURSOR OFF
SET COLOR TO "GR+/R"
CLS

SELECT 1
USE podgran

*****************Kretanje po ekranu******************

**************Ime tekuceg direktorijuma**************

p_imeput:=SPACE(100)
p_brznakniz:=0
p_brskida:=0
p_slovo:=SPACE(1)
p_slovniz:=SPACE(1)
p_ispis:=SPACE(1)

*****Formiranje imena diraktorija-grane*****
p_imeput:=CURDIR()
p_imeput:=ALLTRIM(p_imeput)
p_brznakniz:=LEN(p_imeput)
p_brskida:=0
p_brizlaz:=0
DO WHILE .T.
 p_brznakniz:=p_brznakniz-p_brskida
 p_slovo:=SUBSTR(p_imeput,p_brznakniz,1)
 p_brznakniz:=LEN(p_imeput)
 IF p_slovo="\" 
  EXIT
 ENDIF
 p_slovniz:=p_slovo+p_slovniz
 p_brskida:=p_brskida+1
 IF p_slovniz=" "
  p_ispis:="na osnovoj grni diska"
  EXIT
 ENDIF
 p_brizlaz:=p_brizlaz+1
ENDDO

IF p_brizlaz#0
 p_ispis:="na dirktoriju "+ALLTRIM(p_slovniz)
ENDIF

********************Zaglavlje*****************
  SET COLOR TO "G/R"
  @ 0,0 TO 24,79 DOUBLE
  @ 4,3 TO 22,75
  SET COLOR TO "GR+/R"
  @ 2,3 SAY "Broj fajlova " + p_ispis + " je: " + ;
              ALLTRIM(STR(m_br-1))
  @ 3,9 SAY "Red Br"
  @ 3,19 SAY "Ime Ekst"
  @ 3,34 SAY "Velicina"
  @ 3,45 SAY "Datum"
  @ 3,56 SAY "Vreme"
  @ 3,67 SAY "Atribut"

  @ 23,37 SAY "Izlaz-Esc"
  @ 1,59 SAY "Datum: "+DTOC(DATE())+"."
  @ 23,53 SAY "Listanje: GORE-" + CHR(24) + " DOLE-" + CHR(25)

***********Ispis podataka***********
p_brr:=1
p_red:=5
p_izlaz:=0
DO WHILE .T.
******* Ispis ********
  @ p_red,11 SAY ALLTRIM(STR(redbr))
  @ p_red,19 SAY ALLTRIM(imeekst)
  @ p_red,34 SAY ALLTRIM(STR(velicina))
  @ p_red,45 SAY DTOC(datum)
  @ p_red,56 SAY vreme
  @ p_red,67 SAY a
  SKIP
  p_red:=p_red+1
  IF p_red=22 .OR. BOF() .OR. EOF()
    IF p_izlaz=0
      INKEY(0)
    ELSEIF p_izlaz=1
      p_izlaz:=0
    ENDIF
*------- Prekid
    IF LASTKEY()=27
     CLOSE DATABASES
     SET COLOR TO "GR+/R,RB+/G,,,"
     CLS
     @ 4,27 TO 10,51
     RETURN
*------- NA dole
    ELSEIF LASTKEY()=24 
      IF EOF()
        @ 23,3 SAY "Nema daljeg listanja na dole !"
        INKEY(1.2)
        @ 23,3 SAY "                              "
        p_red:=5
        GO p_brr
        LOOP
      ENDIF
      @ 5,4 CLEAR TO 21,74
      p_red:=5
      p_brr:=p_brr+1
      GO p_brr
      LOOP
*------- Na gore
    ELSEIF LASTKEY()=5 
      p_red:=5
      p_brr=p_brr-1
      GO p_brr
      IF BOF()
        @ 23,3 SAY "Nema daljeg listanja na gore !"
        INKEY(1.2)
        @ 23,3 SAY "                              "
        p_red:=5
        p_brr:=p_brr+1
        GO p_brr
        LOOP
      ENDIF
      @ 5,4 CLEAR TO 21,74
      LOOP
*------- Neka druga tipka
    ELSE
        IF LASTKEY ()=24 .OR. LASTKEY()=5
          p_izlaz:=1
          LOOP
        ENDIF
        @ 23,3 SAY "POGRESAN TASTER !"
        INKEY(1.2)
        @ 23,3 SAY "                 " 
      p_red:=5
      GO p_brr
      LOOP
    ENDIF
  ENDIF
ENDDO
SET COLOR TO
CLEAR SCREEN
CLOSE DATABASES
ERASE prodgran.dbf
SET COLOR TO "GR+/R,RB+/G,,,"
CLS
@ 4,27 TO 10,51
RETURN


******************************ISPITIVANJE BAZE*******************************
PROCEDURE ISPBAZA
***********************Ispisivanje podataka o elementima baze****************

CLOSE DATABASES
ERASE osob.dbf
SET COLOR TO "G/RB,W/R,,,"
CLS

m_baza:=SPACE(20)
DO WHILE .T.
 @ 12,14 SAY "Unesite ime baze podataka: " GET m_baza 
 READ
 IF LASTKEY() = 27
 SET COLOR TO "GR+/R,RB+/G,,,"
 CLS
 @ 4,27 TO 10,51
 RETURN
 ENDIF
 m_baza:=ALLTRIM(m_baza) + ".dbf"
 IF ! FILE(m_baza)
  @ 3,2 SAY "NE POSTOJI baza:" + UPPER(m_baza) + " u tekucem direktoriju !"
  INKEY(3)
  m_baza:=SPACE(20) 
  CLS
  LOOP
 ELSE
  EXIT
 ENDIF
ENDDO

******************Formiranje i punjenje baze OSOB.DBF********************
USE &m_baza
COPY TO osob STRUCTURE EXTENDED
CLOSE
USE osob
m_brsl:=RECCOUNT()

*************Obelezavanje neregularnog "C" polja sa "888"****************
p_ubaciti:=888
GO TOP
DO WHILE .T.
 IF field_type="C" .AND. field_len=0
  REPLACE field_len WITH p_ubaciti , field_dec WITH p_ubaciti
 ELSEIF field_type="C" .AND. field_dec#0
  REPLACE field_len WITH p_ubaciti , field_dec WITH p_ubaciti
 ENDIF
 SKIP
 IF EOF()
  EXIT
 ENDIF
ENDDO
GO TOP

***************Zaglavlje***************
SET COLOR TO "R/W"
CLS
@ 1,22 SAY "U bazi: " + UPPER(m_baza) +;
           " ima " + ALLTRIM(STR(m_brsl)) + " polja !"
SET COLOR TO "B/W"

@ 3,13 SAY "Ime Polja"
@ 3,28 SAY "Karakter"
@ 3,40 SAY "Broj mesta"
@ 3,54 SAY "Broj decimala"
@ 0,0 TO 24,79 DOUBLE
@ 4,11 TO 22,68

***********Kretanje po ekranu*************
p_brr:=1
p_red:=5
p_izlaz:=0

DO WHILE .T.
  SET COLOR TO "N/W"
  @ 1,2 SAY "Izlaz: Esc"
  @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
  @ 23,55 SAY "Listanje: GORE-" + CHR(24) + " DOLE-" + CHR(25)
  @ p_red,13 SAY field_name
  @ p_red,28 SAY field_type
  @ p_red,40 SAY ALLTRIM(STR(field_len,4))
  @ p_red,54 SAY ALLTRIM(STR(field_dec,3))
  SKIP
  p_red:=p_red+1
  IF p_red=22 .OR. BOF() .OR. EOF()
    IF p_izlaz=0
      INKEY(0)
    ELSEIF p_izlaz=1
      p_izlaz:=0
    ENDIF
*------- Prekid
    IF LASTKEY()=27
      CLOSE DATABASES
     SET COLOR TO "GR+/R,RB+/G,,,"
     CLS
     @ 4,27 TO 10,51
     RETURN
*------- NA dole
    ELSEIF LASTKEY()=24 
      IF EOF()
        @ 23,3 SAY "Nema daljeg listanja na dole !"
        INKEY(1.2)
        @ 23,3 SAY "                              "
        p_red:=5
        GO p_brr
        LOOP
      ENDIF
      @ 5,12 CLEAR TO 21,67
      @ 23,3 SAY SPACE(30)
      p_red:=5
      p_brr:=p_brr+1
      GO p_brr
      LOOP
*------- Na gore
    ELSEIF LASTKEY()=5 
      p_red:=5
      p_brr=p_brr-1
      GO p_brr
      IF BOF()
        @ 23,3 SAY "Nema daljeg listanja na gore !"
        INKEY(1.2)
        @ 23,3 SAY "                              "
        p_red:=5
        p_brr:=p_brr+1
        GO p_brr
        @ 5,12 CLEAR TO 21,67
        LOOP
      ENDIF
      @ 23,3 SAY SPACE(30)
      @ 5,12 CLEAR TO 21,67
      LOOP
*------- Neka druga tipka
    ELSE
      FOR i=1 TO 3
        IF LASTKEY ()=24 .OR. LASTKEY()=5
          p_izlaz:=1
          LOOP
        ENDIF
        @ 23,31 SAY "POGRESAN TASTER !"
        INKEY(0.7)
        @ 23,31 SAY "                 " 
        INKEY(0.3)
      NEXT
      p_red:=5
      GO p_brr
      LOOP
    ENDIF
  ENDIF
ENDDO
CLOSE DATABASES
SET COLOR TO "GR+/R,RB+/G,,,"
CLS
@ 4,27 TO 10,51
RETURN


****************************INDEKSIRANJE**********************************
PROCEDURE INDKSBZ
************************Unos baze koja se indeksira***********************

CLEAR
SET COLOR TO "W/B,GR+/W,,,"
CLS

m_baza:=SPACE(20)
DO WHILE .T.
 @ 2,2 SAY "Unesite ime baze podataka: " GET m_baza 
 READ
 IF LASTKEY() = 27
  CLS
 SET COLOR TO "GR+/R,RB+/G,,,"
 CLS
 @ 4,27 TO 10,51
 RETURN
 ENDIF
 m_baza:=ALLTRIM(m_baza) + ".dbf"
 IF ! FILE(m_baza)
  @ 3,2 SAY "NE POSTOJI baza:" + UPPER(m_baza) + " u tekucem direktoriju !"
  INKEY(3)
  m_baza:=SPACE(20) 
  CLS
  LOOP
 ELSE
  EXIT
 ENDIF
ENDDO

p_baza:=SPACE(12)
p_polje:=SPACE(10)
p_karak:=SPACE(1)
p_imeindbaz:=SPACE(8)
p_izraz:=SPACE(100)
p_brp:=1
p_izbor:=SPACE(1)

p_baza:=m_baza


*************Pravljenje izraza za indeksiranje****************

DO WHILE .T.

 @ 1,28 SAY "I N D E K S I R A NJ E" COLOR "G+/B"
 @ 4,4 SAY "Naziv polja: " GET p_polje
 @ 6,4 SAY "Karakter polja: " GET p_karak PICTURE "!" VALID(p_karak $ "NCDL")
 @ 7,4 SAY "N-numerik, C-karakter, D-datum, L-logik"
 READ

 IF LASTKEY() = 27
  SET COLOR TO "GR+/R,RB+/G,,,"
  CLS
  @ 4,27 TO 10,51
  RETURN
 ENDIF

 IF p_brp=1
  IF p_karak = "C"
   p_izraz:=ALLTRIM(p_polje)
   @ 8,4 SAY "Polje: " + p_izraz
  ELSEIF p_karak = "N"
   p_izraz:="STR(" + ALLTRIM(p_polje) + ")"
   @ 8,4 SAY "Polje: " + p_izraz
  ELSEIF p_karak = "D"
   p_izraz:="DTOC(" + ALLTRIM(p_polje) + ")"
   @ 8,4 SAY "Polje: " + p_izraz
  ELSEIF p_karak = "L"
   @ 11,4 SAY "Logicke promenljive za sada ne primamo !!!"
   INKEY(3)
   @ 10,0 CLEAR
   p_polje:="          "
   p_karak:=" "
   LOOP
  ENDIF
 ELSEIF p_brp>1
  IF p_karak = "C"
   p_izraz:=p_izraz + "+" + ALLTRIM(p_polje)
   @ 8,4 SAY "Izraz: " + p_izraz
  ELSEIF p_karak = "N"
   p_izraz:=p_izraz + "+" + "STR(" + ALLTRIM(p_polje) + ")"
   @ 8,4 SAY "Izraz: " + p_izraz
  ELSEIF p_karak = "D"
   p_izraz:=p_izraz + "+" + "DTOC(" + ALLTRIM(p_polje) + ")"
   @ 8,4 SAY "Izraz: " + p_izraz
  ELSEIF p_karak = "L"
    @ 11,4 SAY "Logicke promenljive za sada ne prihvatam !!!"
   INKEY(3)
   p_polje:="          "
   p_karak:=" "
   LOOP
  ENDIF
 ENDIF

 @ 11,4 SAY "Da li zelite dalji unos D/N ?" GET p_izbor ;
        PICTURE "!" VALID(p_izbor $ "DN")
 READ

 IF p_izbor == "N"
  @ 10,0 CLEAR
  EXIT
 ENDIF
 p_brp:=p_brp+1
 p_polje:="          "
 p_izbor:=" "
 p_karak:=" "
 @ 10,0 CLEAR 
ENDDO

**********Prekid ako je pritisnut "Esc"************
IF LASTKEY() = 27
 CLS
SET COLOR TO "GR+/R,RB+/G,,,"
CLS
@ 4,27 TO 10,51
RETURN
ENDIF

*****************Ime indeksne baze*****************
DO WHILE .T.
 @ 10,4 SAY "Naziv indeksne baze: " GET p_imeindbaz
 READ
 IF LASTKEY() = 27
  SET COLOR TO "GR+/R,RB+/G,,,"
  CLS
  *SET MESSAGE TO 23 CENTER
  @ 4,27 TO 10,51
  RETURN
 ENDIF
 p_imeindbaz:=ALLTRIM(p_imeindbaz)+".ntx"
 IF FILE (p_imeindbaz)
  @ 11,4 SAY "Indeksna baza sa nazivom: " + UPPER(p_imeindbaz) +;
         " vec postoji !!!"
     p_imeindbaz:=SPACE(8)
   INKEY(2)
   @ 11,4 SAY SPACE(50)
   LOOP
 ENDIF
 @ 11,4 SAY p_imeindbaz
 INKEY(2)
 EXIT
ENDDO

********Razdvajanje imena od ekstenzije*************
p_duzniz:=LEN(p_imeindbaz)
p_duzniz:=p_duzniz-4
p_imeindbaz:=SUBSTR(p_imeindbaz,1,p_duzniz)

*********Evo konacno i indeksiranja************
IF p_brp = 1
  @ 17,5 SAY "Indeksiram " + UPPER(p_baza) + " sa " + p_imeindbaz
  INKEY(2)
  USE &p_baza
  INDEX ON &p_polje TO &p_imeindbaz
ENDIF
IF p_brp > 1
  @ 17,5 SAY "Indeksiram " + p_baza +" sa " + p_imeindbaz
  INKEY(2)
  USE &p_baza
  INDEX ON &p_izraz TO &p_imeindbaz
ENDIF

SET COLOR TO "GR+/R,RB+/G,,,"
CLS
@ 4,27 TO 10,51
RETURN



