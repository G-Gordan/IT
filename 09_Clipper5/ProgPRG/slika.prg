
SET COLOR TO "GR+/G"
CLS

*****Postavka promenljivih********
m_br:=0
p_brisp:=1

*********Definisanje matrice**********
p_mtrcrt:=0
p_mtrcrt:=ARRAY(221,2)

*******Punjenje matrice*************
p_mtrcrt[1,1]:=21
p_mtrcrt[1,2]:=4
p_mtrcrt[2,1]:=21
p_mtrcrt[2,2]:=5
p_mtrcrt[3,1]:=21
p_mtrcrt[3,2]:=6
p_mtrcrt[4,1]:=21
p_mtrcrt[4,2]:=7
p_mtrcrt[5,1]:=21
p_mtrcrt[5,2]:=8
p_mtrcrt[6,1]:=21
p_mtrcrt[6,2]:=9
p_mtrcrt[7,1]:=21
p_mtrcrt[7,2]:=10
p_mtrcrt[8,1]:=21
p_mtrcrt[8,2]:=11
p_mtrcrt[9,1]:=21
p_mtrcrt[9,2]:=12
p_mtrcrt[10,1]:=21
p_mtrcrt[10,2]:=13
p_mtrcrt[11,1]:=21
p_mtrcrt[11,2]:=14

p_mtrcrt[12,1]:=21
p_mtrcrt[12,2]:=25
p_mtrcrt[13,1]:=21
p_mtrcrt[13,2]:=26
p_mtrcrt[14,1]:=21
p_mtrcrt[14,2]:=27
p_mtrcrt[15,1]:=21
p_mtrcrt[15,2]:=28
p_mtrcrt[16,1]:=21
p_mtrcrt[16,2]:=29
p_mtrcrt[17,1]:=21
p_mtrcrt[17,2]:=30
p_mtrcrt[18,1]:=21
p_mtrcrt[18,2]:=31
p_mtrcrt[19,1]:=21
p_mtrcrt[19,2]:=32

p_mtrcrt[20,1]:=21
p_mtrcrt[20,2]:=40
p_mtrcrt[21,1]:=21
p_mtrcrt[21,2]:=41
p_mtrcrt[22,1]:=21
p_mtrcrt[22,2]:=42
p_mtrcrt[23,1]:=21
p_mtrcrt[23,2]:=43
p_mtrcrt[24,1]:=21
p_mtrcrt[24,2]:=44

p_mtrcrt[25,1]:=21
p_mtrcrt[25,2]:=50
p_mtrcrt[26,1]:=21
p_mtrcrt[26,2]:=51
p_mtrcrt[27,1]:=21
p_mtrcrt[27,2]:=52

p_mtrcrt[28,1]:=21
p_mtrcrt[28,2]:=67
p_mtrcrt[29,1]:=21
p_mtrcrt[29,2]:=68
p_mtrcrt[30,1]:=21
p_mtrcrt[30,2]:=69

p_mtrcrt[31,1]:=20
p_mtrcrt[31,2]:=5
p_mtrcrt[32,1]:=20
p_mtrcrt[32,2]:=6

p_mtrcrt[33,1]:=20
p_mtrcrt[33,2]:=24
p_mtrcrt[34,1]:=20
p_mtrcrt[34,2]:=25

p_mtrcrt[35,1]:=20
p_mtrcrt[35,2]:=32
p_mtrcrt[36,1]:=20
p_mtrcrt[36,2]:=33

p_mtrcrt[37,1]:=20
p_mtrcrt[37,2]:=39
p_mtrcrt[38,1]:=20
p_mtrcrt[38,1]:=40

p_mtrcrt[39,1]:=20
p_mtrcrt[39,2]:=44
p_mtrcrt[40,1]:=20
p_mtrcrt[40,2]:=45

p_mtrcrt[41,1]:=20
p_mtrcrt[41,2]:=50
p_mtrcrt[42,1]:=20
p_mtrcrt[42,2]:=51
p_mtrcrt[43,1]:=20
p_mtrcrt[43,2]:=52

p_mtrcrt[44,1]:=20
p_mtrcrt[44,2]:=67
p_mtrcrt[45,1]:=20
p_mtrcrt[45,2]:=68
p_mtrcrt[46,1]:=20
p_mtrcrt[46,2]:=69

p_mtrcrt[47,1]:=19
p_mtrcrt[47,2]:=6
p_mtrcrt[48,1]:=19
p_mtrcrt[48,2]:=7

p_mtrcrt[49,1]:=19
p_mtrcrt[49,2]:=33
p_mtrcrt[50,1]:=19
p_mtrcrt[50,2]:=34

p_mtrcrt[51,1]:=19
p_mtrcrt[51,2]:=38
p_mtrcrt[52,1]:=19
p_mtrcrt[52,2]:=39

p_mtrcrt[53,1]:=19
p_mtrcrt[53,2]:=45
p_mtrcrt[54,1]:=19
p_mtrcrt[54,2]:=46

p_mtrcrt[55,1]:=19
p_mtrcrt[55,2]:=50
p_mtrcrt[56,1]:=19
p_mtrcrt[56,2]:=51
p_mtrcrt[57,1]:=19
p_mtrcrt[57,2]:=52

p_mtrcrt[58,1]:=19
p_mtrcrt[58,2]:=67
p_mtrcrt[59,1]:=19
p_mtrcrt[59,2]:=68
p_mtrcrt[60,1]:=19
p_mtrcrt[60,2]:=69

p_mtrcrt[61,1]:=18
p_mtrcrt[61,2]:=7
p_mtrcrt[62,1]:=18
p_mtrcrt[62,2]:=8

p_mtrcrt[63,1]:=18
p_mtrcrt[63,2]:=33
p_mtrcrt[64,1]:=18
p_mtrcrt[64,2]:=34

p_mtrcrt[65,1]:=18
p_mtrcrt[65,2]:=37
p_mtrcrt[66,1]:=18
p_mtrcrt[66,2]:=38

p_mtrcrt[67,1]:=18
p_mtrcrt[67,2]:=46
p_mtrcrt[68,1]:=18
p_mtrcrt[68,2]:=47

p_mtrcrt[69,1]:=18
p_mtrcrt[69,2]:=50
p_mtrcrt[70,1]:=18
p_mtrcrt[70,2]:=51
p_mtrcrt[71,1]:=18
p_mtrcrt[71,2]:=52

p_mtrcrt[72,1]:=18
p_mtrcrt[72,2]:=67
p_mtrcrt[73,1]:=18
p_mtrcrt[73,2]:=68
p_mtrcrt[74,1]:=18
p_mtrcrt[74,2]:=69

p_mtrcrt[75,1]:=17
p_mtrcrt[75,2]:=8
p_mtrcrt[76,1]:=17
p_mtrcrt[76,2]:=9

p_mtrcrt[77,1]:=17
p_mtrcrt[77,2]:=32
p_mtrcrt[78,1]:=17
p_mtrcrt[78,2]:=33

p_mtrcrt[79,1]:=17
p_mtrcrt[79,2]:=37
p_mtrcrt[80,1]:=17
p_mtrcrt[80,2]:=38

p_mtrcrt[81,1]:=17
p_mtrcrt[81,2]:=46
p_mtrcrt[82,1]:=17
p_mtrcrt[82,2]:=47

p_mtrcrt[83,1]:=17
p_mtrcrt[83,2]:=50
p_mtrcrt[84,1]:=17
p_mtrcrt[84,2]:=51
p_mtrcrt[85,1]:=17
p_mtrcrt[85,2]:=52

p_mtrcrt[86,1]:=17
p_mtrcrt[86,2]:=67
p_mtrcrt[87,1]:=17
p_mtrcrt[87,2]:=68
p_mtrcrt[88,1]:=17
p_mtrcrt[88,2]:=69

p_mtrcrt[89,1]:=16
p_mtrcrt[89,2]:=9
p_mtrcrt[90,1]:=16
p_mtrcrt[90,2]:=10

p_mtrcrt[91,1]:=16
p_mtrcrt[91,2]:=17
p_mtrcrt[92,1]:=16
p_mtrcrt[92,2]:=18
p_mtrcrt[93,1]:=16
p_mtrcrt[93,2]:=19
p_mtrcrt[94,1]:=16
p_mtrcrt[94,2]:=20
p_mtrcrt[95,1]:=16
p_mtrcrt[95,2]:=21

p_mtrcrt[96,1]:=16
p_mtrcrt[96,2]:=26
p_mtrcrt[97,1]:=16
p_mtrcrt[97,2]:=27
p_mtrcrt[98,1]:=16
p_mtrcrt[98,2]:=28
p_mtrcrt[99,1]:=16
p_mtrcrt[99,2]:=29
p_mtrcrt[100,1]:=16
p_mtrcrt[100,2]:=30
p_mtrcrt[101,1]:=16
p_mtrcrt[101,2]:=31
p_mtrcrt[102,1]:=16
p_mtrcrt[102,2]:=32

p_mtrcrt[103,1]:=16
p_mtrcrt[103,2]:=37
p_mtrcrt[104,1]:=16
p_mtrcrt[104,2]:=38

p_mtrcrt[105,1]:=16
p_mtrcrt[105,2]:=46
p_mtrcrt[106,1]:=16
p_mtrcrt[106,2]:=47

p_mtrcrt[107,1]:=16
p_mtrcrt[107,2]:=50
p_mtrcrt[108,1]:=16
p_mtrcrt[108,2]:=51
p_mtrcrt[109,1]:=16
p_mtrcrt[109,2]:=52

p_mtrcrt[110,1]:=16
p_mtrcrt[110,2]:=67
p_mtrcrt[111,1]:=16
p_mtrcrt[111,2]:=68
p_mtrcrt[112,1]:=16
p_mtrcrt[112,2]:=69

p_mtrcrt[113,1]:=15
p_mtrcrt[113,2]:=10
p_mtrcrt[114,1]:=15
p_mtrcrt[114,2]:=11

p_mtrcrt[115,1]:=15
p_mtrcrt[115,2]:=25
p_mtrcrt[116,1]:=15
p_mtrcrt[116,2]:=26

p_mtrcrt[117,1]:=15
p_mtrcrt[117,2]:=37
p_mtrcrt[118,1]:=15
p_mtrcrt[118,1]:=38

p_mtrcrt[119,1]:=15
p_mtrcrt[119,2]:=46
p_mtrcrt[120,1]:=15
p_mtrcrt[120,2]:=47

p_mtrcrt[121,1]:=15
p_mtrcrt[121,2]:=50
p_mtrcrt[122,1]:=15
p_mtrcrt[122,2]:=51
p_mtrcrt[123,1]:=15
p_mtrcrt[123,2]:=52
p_mtrcrt[124,1]:=15
p_mtrcrt[124,2]:=53
p_mtrcrt[125,1]:=15
p_mtrcrt[125,2]:=54
p_mtrcrt[126,1]:=15
p_mtrcrt[126,2]:=55
p_mtrcrt[127,1]:=15
p_mtrcrt[127,2]:=56
p_mtrcrt[128,1]:=15
p_mtrcrt[128,2]:=57

p_mtrcrt[129,1]:=15
p_mtrcrt[129,2]:=67
p_mtrcrt[130,1]:=15
p_mtrcrt[130,2]:=68
p_mtrcrt[131,1]:=15
p_mtrcrt[131,2]:=69

p_mtrcrt[132,1]:=14
p_mtrcrt[132,2]:=11
p_mtrcrt[133,1]:=14
p_mtrcrt[133,2]:=12

p_mtrcrt[134,1]:=14
p_mtrcrt[134,2]:=24
p_mtrcrt[135,1]:=14
p_mtrcrt[135,2]:=25

p_mtrcrt[136,1]:=14
p_mtrcrt[136,2]:=37
p_mtrcrt[137,1]:=14
p_mtrcrt[137,2]:=38

p_mtrcrt[138,1]:=14
p_mtrcrt[138,2]:=46
p_mtrcrt[139,1]:=14
p_mtrcrt[139,2]:=47

p_mtrcrt[140,1]:=14
p_mtrcrt[140,2]:=50
p_mtrcrt[141,1]:=14
p_mtrcrt[141,2]:=51
p_mtrcrt[142,1]:=14
p_mtrcrt[142,2]:=52

p_mtrcrt[143,1]:=14
p_mtrcrt[143,2]:=67
p_mtrcrt[144,1]:=14
p_mtrcrt[144,2]:=68
p_mtrcrt[145,1]:=14
p_mtrcrt[145,2]:=69

p_mtrcrt[146,1]:=13
p_mtrcrt[146,2]:=12
p_mtrcrt[147,1]:=13
p_mtrcrt[147,2]:=13

p_mtrcrt[148,1]:=13
p_mtrcrt[148,2]:=24
p_mtrcrt[149,1]:=13
p_mtrcrt[149,2]:=25

p_mtrcrt[150,1]:=13
p_mtrcrt[150,2]:=38
p_mtrcrt[151,1]:=13
p_mtrcrt[151,2]:=39

p_mtrcrt[152,1]:=13
p_mtrcrt[152,2]:=45
p_mtrcrt[153,1]:=13
p_mtrcrt[153,2]:=46

p_mtrcrt[154,1]:=13
p_mtrcrt[154,2]:=50
p_mtrcrt[155,1]:=13
p_mtrcrt[155,2]:=51
p_mtrcrt[156,1]:=13
p_mtrcrt[156,2]:=52

p_mtrcrt[157,1]:=13
p_mtrcrt[157,2]:=67
p_mtrcrt[158,1]:=13
p_mtrcrt[158,2]:=68
p_mtrcrt[159,1]:=13
p_mtrcrt[159,2]:=69

p_mtrcrt[160,1]:=12
p_mtrcrt[160,2]:=13
p_mtrcrt[161,1]:=12
p_mtrcrt[161,2]:=14

p_mtrcrt[162,1]:=12
p_mtrcrt[162,2]:=25
p_mtrcrt[163,1]:=12
p_mtrcrt[163,2]:=26

p_mtrcrt[164,1]:=12
p_mtrcrt[164,2]:=33
p_mtrcrt[165,1]:=12
p_mtrcrt[165,2]:=34

p_mtrcrt[166,1]:=12
p_mtrcrt[166,2]:=39
p_mtrcrt[167,1]:=12
p_mtrcrt[167,2]:=40

p_mtrcrt[168,1]:=12
p_mtrcrt[168,2]:=44
p_mtrcrt[169,1]:=12
p_mtrcrt[169,2]:=45

p_mtrcrt[170,1]:=12
p_mtrcrt[170,2]:=50
p_mtrcrt[171,1]:=12
p_mtrcrt[171,2]:=51
p_mtrcrt[172,1]:=12
p_mtrcrt[172,2]:=52

p_mtrcrt[173,1]:=12
p_mtrcrt[173,2]:=67
p_mtrcrt[174,1]:=12
p_mtrcrt[174,2]:=68
p_mtrcrt[175,1]:=12
p_mtrcrt[175,2]:=69

p_mtrcrt[176,1]:=11
p_mtrcrt[176,2]:=4
p_mtrcrt[177,1]:=11
p_mtrcrt[177,2]:=5
p_mtrcrt[178,1]:=11
p_mtrcrt[178,2]:=6
p_mtrcrt[179,1]:=11
p_mtrcrt[179,2]:=7
p_mtrcrt[180,1]:=11
p_mtrcrt[180,2]:=8
p_mtrcrt[181,1]:=11
p_mtrcrt[181,2]:=9
p_mtrcrt[182,1]:=11
p_mtrcrt[182,2]:=10
p_mtrcrt[183,1]:=11
p_mtrcrt[183,2]:=11
p_mtrcrt[184,1]:=11
p_mtrcrt[184,2]:=12
p_mtrcrt[185,1]:=11
p_mtrcrt[185,2]:=13
p_mtrcrt[186,1]:=11
p_mtrcrt[186,2]:=14

p_mtrcrt[187,1]:=11
p_mtrcrt[187,2]:=26
p_mtrcrt[188,1]:=11
p_mtrcrt[188,2]:=27
p_mtrcrt[189,1]:=11
p_mtrcrt[189,2]:=28
p_mtrcrt[190,1]:=11
p_mtrcrt[190,2]:=29
p_mtrcrt[191,1]:=11
p_mtrcrt[191,2]:=30
p_mtrcrt[192,1]:=11
p_mtrcrt[192,2]:=31
p_mtrcrt[193,1]:=11
p_mtrcrt[193,2]:=32
p_mtrcrt[194,1]:=11
p_mtrcrt[194,2]:=33

p_mtrcrt[195,1]:=11
p_mtrcrt[195,2]:=40
p_mtrcrt[196,1]:=11
p_mtrcrt[196,2]:=41
p_mtrcrt[197,1]:=11
p_mtrcrt[197,2]:=42
p_mtrcrt[198,1]:=11
p_mtrcrt[198,2]:=43
p_mtrcrt[199,1]:=11
p_mtrcrt[199,1]:=43

p_mtrcrt[200,1]:=11
p_mtrcrt[200,2]:=50
p_mtrcrt[201,1]:=11
p_mtrcrt[201,2]:=51
p_mtrcrt[202,1]:=11
p_mtrcrt[202,2]:=52
p_mtrcrt[203,1]:=11
p_mtrcrt[203,2]:=53
p_mtrcrt[204,1]:=11
p_mtrcrt[204,2]:=54
p_mtrcrt[205,1]:=11
p_mtrcrt[205,2]:=55
p_mtrcrt[206,1]:=11
p_mtrcrt[206,2]:=56
p_mtrcrt[207,1]:=11
p_mtrcrt[207,2]:=57
p_mtrcrt[208,1]:=11
p_mtrcrt[208,2]:=58
p_mtrcrt[209,1]:=11
p_mtrcrt[209,2]:=59
p_mtrcrt[210,1]:=11
p_mtrcrt[210,2]:=60

p_mtrcrt[211,1]:=11
p_mtrcrt[211,2]:=63
p_mtrcrt[212,1]:=11
p_mtrcrt[212,2]:=64
p_mtrcrt[213,1]:=11
p_mtrcrt[213,2]:=65
p_mtrcrt[214,1]:=11
p_mtrcrt[214,2]:=66
p_mtrcrt[215,1]:=11
p_mtrcrt[215,2]:=67
p_mtrcrt[216,1]:=11
p_mtrcrt[216,2]:=68
p_mtrcrt[217,1]:=11
p_mtrcrt[217,2]:=69
p_mtrcrt[218,1]:=11
p_mtrcrt[218,2]:=70
p_mtrcrt[219,1]:=11
p_mtrcrt[219,2]:=71
p_mtrcrt[220,1]:=11
p_mtrcrt[220,2]:=72
p_mtrcrt[221,1]:=11
p_mtrcrt[221,2]:=73





**********Ubacivanje granicnika*************
AADD(p_mtrcrt,"KRAJ")
m_br:=ASCAN(p_mtrcrt,"KRAJ")
*? m_br

******Ispisivanje***********
DO WHILE .T.
 @ p_mtrcrt[p_brisp,1],p_mtrcrt[p_brisp,2] SAY CHR(219)
 p_brisp:=p_brisp+1
 IF p_brisp=m_br
  EXIT
 ENDIF
ENDDO

********Izlazak***********
SET COLOR TO "W/N"
@ 23,0 CLEAR TO 24,79
QUIT




