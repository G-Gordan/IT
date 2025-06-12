
*************ISPISUJE: dan u nedelji, datum i vreme**************


*********Postavka********
SET DATE GERMAN
SET COLOR TO "GR+/R"
CLS

*******Promenljive*********
p_taster:=0
*p_taster2:=0
p_brojcanik:=0
dan:=SPACE(8)
p_pocdan:=SPACE(8)
p_krjdan:=SPACE(8)

p_danraz:=SPACE(8)
vremae=" "
p_pocvrem:=" "
p_krjvrem:=" "
p_vremraz:=0
p_dansec:=0
p_pocetak:=0
p_kraj:=0
p_razlika:=0

p_satp:=0
p_minp:=0
p_secp:=0
p_satk:=0
p_mink:=0
p_sack:=0
p_dan:=0
p_sat:=0
p_min:=0
p_sec:=0

p_dandec:=0
p_satdec:=0
p_mindec:=0

p_nula:="0"
p_cifra:=0

p_danz:=SPACE(1)
p_satz:=SPACE(1)
p_minz:=SPACE(1)
p_secz:=SPACE(1)

p_danned:=0
p_zdanned:=SPACE(1)
****************************

**********Registruje vreme na ulasku*********
p_pocdan:=DATE()
p_pocvrem:=TIME()


*******Ispisuje trenurno vreme,broji dok ceka da pritisnete taster********
DO WHILE .T.

* IF p_brojcanik=0
*  p_pocvrem:=TIME()
* ENDIF

********Uzima sistemski datum i vreme************
 dan:=DATE()
 vreme:=TIME()

*********Odredjuje dan u nedelji************
 p_danned:=DOW(DATE())
 DO CASE
 CASE p_danned=1
  p_zdanned:="Nedelja"
 CASE p_danned=2
  p_zdanned:="Ponedeljak"
 CASE p_danned=3
  p_zdanned:="Utorak"
 CASE p_danned=4
  p_zdanned:="Sreda"
 CASE p_danned=5
  p_zdanned:="Cetvrtak"
 CASE p_danned=6
  p_zdanned:="Petak"
 CASE p_danned=7
  p_zdanned:="Subota"
 ENDCASE

************Ispisuje: dan u nedelji, datun i vreme**********
 @ 1,3 SAY "Danas je: "+p_zdanned+" - "+DTOC(dan)+" - "+vreme

************Registruje pritisnutu tipku***********
 p_taster:=INKEY()
 @ 7,3 SAY "Pritisnut je taster sa ASCII kodom: "+ALLTRIM(STR(p_taster))
* IF p_taster#p_taster2
*  @ 7,3 SAY "                                                            "
*  @ 7,3 SAY "Pritisnut je taster sa ASCII kodom: "+ALLTRIM(STR(p_taster))
*  p_taster2:=p_taster
* ENDIF

*********Izlazi ako se pritisne blo koja dirka*********
 IF p_taster <> 0
*  @ 9,3 SAY "BRAVO !!!"
   EXIT
*  QUIT
 ENDIF

**********Kad izbroji zadato (100.000) izlazi iz petlje*********
 IF p_brojcanik=100000
  @ 5,17 SAY "<- Izbrojao !"
  EXIT
 ENDIF

***********Broji i ispisuje krugove********
 p_brojcanik:=p_brojcanik+1
 @ 5,3 SAY "Krug: "+ALLTRIM(STR(p_brojcanik))
ENDDO


********Registruje vreme na izlasku*************
p_krjdan:=DATE()
p_krjvrem:=TIME()

*********Ispisuje pocetno i krajnje vreme**********
@ 3,0 CLEAR TO 4,78
@ 3,3 SAY "Pocetno vreme: "+DTOC(p_pocdan)+" - "+p_pocvrem
@ 4,3 SAY "Krajnje vreme: "+DTOC(p_krjdan)+" - "+p_krjvrem


************Racuna razliku vremena*******************

p_danraz:=p_krjdan-p_pocdan
p_dansec:=p_danraz*86400

p_satp:=VAL(SUBSTR(p_pocvrem,1,2))
p_minp:=VAL(SUBSTR(p_pocvrem,4,2))
p_secp:=VAL(SUBSTR(p_pocvrem,7,2))
p_satk:=VAL(SUBSTR(p_krjvrem,1,2))
p_mink:=VAL(SUBSTR(p_krjvrem,4,2))
p_seck:=VAL(SUBSTR(p_krjvrem,7,2))

p_satp:=p_satp*3600
p_minp:=p_minp*60
p_satk:=p_satk*3600
p_mink:=p_mink*60

p_pocetak:=p_satp+p_minp+p_secp
p_kraj:=p_danraz+p_satk+p_mink+p_seck
p_razlika:=p_kraj-p_pocetak

p_dandec:=p_razlika/86400
p_dan:=INT(p_dandec)
p_danz:=ALLTRIM(STR(p_dan))

p_razlika:=p_razlika-p_dan*86400
p_satdec:=p_razlika/3600
p_sat:=INT(p_satdec)
p_satz:=ALLTRIM(STR(p_sat))
p_cifra:=LEN(p_satz)
IF p_cifra=1
 p_satz:=p_nula+p_satz
ENDIF
p_cifra:=0

p_razlika:=p_razlika-p_sat*3600
p_mindec:=p_razlika/60
p_min:=INT(p_mindec)
p_minz:=ALLTRIM(STR(p_min))
p_cifra:=LEN(p_minz)
IF p_cifra=1
 p_minz:=p_nula+p_minz
ENDIF
p_cifra:=0

p_razlika:=p_razlika-p_min*60
p_sec:=p_razlika
p_secz:=ALLTRIM(STR(p_sec))
p_cifra:=LEN(p_secz)
IF p_cifra=1
 p_seczn:=p_nula+p_secz
ENDIF
*p_cifra:=0

*******Ispisuje razliku vremena******
@ 15,1 SAY "Program ste koristili: "+p_danz+" dana, - "+;
           p_satz+" sati, "+p_minz+" minuta i "+p_secz+" sekundi !"



*IF p_satk<p_satp
* p_satk:=p_satk+24
* p_sat:=p_satk-p_satp
*ELSE
* p_sat:=p_satk-p_satp
*ENDIF
*p_min:=p_mink-p_minp
*p_sec:=p_seck-p_secp

*@ 8,3 SAY "Program je radio:"+ALLTRIM(STR(p_sat))+":"+ALLTRIM(STR(p_min))+;
*          ":"+ALLTRIM(STR(p_sec))  


*p_vremraz:=VAL(vreme)-VAL(p_pocvrem)




********Izlazak********
SET COLOR TO "W/N"
p_red:=ROW()+1
@ p_red,0 CLEAR TO 24,79

QUIT
