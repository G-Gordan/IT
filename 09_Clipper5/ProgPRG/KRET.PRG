***** S_PPPP.PRG STAMPA SA KLIZANJEM*****

SET CURSOR OFF
SET COLOR TO "GR+/R"
SET DATE GERMAN
CLEAR SCREEN

***Foremiranje radne baze podataka***
IF ! FILE("XXXXWWWW.DBF")
 CREATE pomoc1
 STORE "vrs       c3  " TO polje1
 STORE "osn       c3  " TO polje2
 STORE "dob       c20 " TO polje3
  FOR i=1 TO 3
   APPEND BLANK
   STORE STR(i,1) TO broj
   STORE "polje"+broj TO p1
   REPLACE field_name WITH SUBSTR(&p1,1,10)
   REPLACE field_type WITH SUBSTR(&p1,11,1)
   REPLACE field_len  WITH VAL(SUBSTR(&p1,12,2))
   REPLACE field_dec  WITH VAL(SUBSTR(&p1,14,1))
  NEXT
 CREATE xxxxwwww FROM pomoc1
 USE
 DELETE FILE pomoc1.dbf
ELSE
  @ 1,15 SAY "Baza XXXXWWWW.DBF vec postoji u tekucem direktorijumu !?"
  @ 2,15 SAY "IZBRISI JE !"
  QUIT
ENDIF
*@ 3,15 SAY "Kreirana ja baza podaka XXXXWWWW.DBF !"
*****************************

***Puni bazu XXXXWWWW.DBF podacima***
 p_matr:=ARRAY(30,3)
 p_matr[1,1]:="001"
 p_matr[1,2]:=" 1A"
 p_matr[1,3]:="AAAAA"
 p_matr[2,1]:="002"
 p_matr[2,2]:=" 2B"
 p_matr[2,3]:="BBBBB"
 p_matr[3,1]:="003"
 p_matr[3,2]:=" 3C"
 p_matr[3,3]:="CCCCC"
 p_matr[4,1]:="004"
 p_matr[4,2]:=" 4D"
 p_matr[4,3]:="DDDDD"
 p_matr[5,1]:="005"
 p_matr[5,2]:=" 5E"
 p_matr[5,3]:="EEEEE"
 p_matr[6,1]:="006"
 p_matr[6,2]:=" 6F"
 p_matr[6,3]:="FFFFF"
 p_matr[7,1]:="007"
 p_matr[7,2]:=" 7G"
 p_matr[7,3]:="GGGGG"
 p_matr[8,1]:="008"
 p_matr[8,2]:=" 8H"
 p_matr[8,3]:="HHHHH"
 p_matr[9,1]:="009"
 p_matr[9,2]:=" 9I"
 p_matr[9,3]:="IIIII"
 p_matr[10,1]:="010"
 p_matr[10,2]:="10J"
 p_matr[10,3]:="JJJJJ"
 p_matr[11,1]:="011"
 p_matr[11,2]:="11K"
 p_matr[11,3]:="KKKKK"
 p_matr[12,1]:="012"
 p_matr[12,2]:="12L"
 p_matr[12,3]:="LLLLL"
 p_matr[13,1]:="013"
 p_matr[13,2]:="13M"
 p_matr[13,3]:="MMMMM"
 p_matr[14,1]:="014"
 p_matr[14,2]:="14N"
 p_matr[14,3]:="NNNNN"
 p_matr[15,1]:="015"
 p_matr[15,2]:="15O"
 p_matr[15,3]:="OOOOO"
 p_matr[16,1]:="016"
 p_matr[16,2]:="16P"
 p_matr[16,3]:="PPPPP"
 p_matr[17,1]:="017"
 p_matr[17,2]:="17R"
 p_matr[17,3]:="RRRRR"
 p_matr[18,1]:="018"
 p_matr[18,2]:="18S"
 p_matr[18,3]:="SSSSS"
 p_matr[19,1]:="019"
 p_matr[19,2]:="19T"
 p_matr[19,3]:="TTTTT"
 p_matr[20,1]:="020"
 p_matr[20,2]:="20U"
 p_matr[20,3]:="UUUUU"

SELECT 1
USE xxxxwwww
GO TOP
FOR i = 1 TO 20
  APPEND BLANK
  REPLACE vrs WITH p_matr[i,1],osn WITH p_matr[i,2],dob WITH p_matr[i,3]
NEXT
* @ 4,15 SAY "Baza je napunjena podacima !"
* INKEY(2)
*****************************

***Kretanje po ekranu***
p_brr:=1
p_red:=7
p_izlaz:=0
SELECT 1
USE xxxxwwww

DO WHILE .T.
  SET COLOR TO "G/R"
  @ 0,0 TO 24,79 DOUBLE
  @ 6,14 TO 17,64
  SET COLOR TO "GR+/R"
  @ 1,2 SAY "Izlaz: Esc"
  @ 1,63 SAY "Datum: "+DTOC(DATE())+"."
  @ 23,55 SAY "Listanje: GORE-" + CHR(24) + " DOLE-" + CHR(25)
  @ p_red,32 SAY vrs+"  "+osn+"  "+dob
  SKIP
  p_red:=p_red+1
  IF p_red=17
    IF p_izlaz=0
      INKEY(0)
    ELSEIF p_izlaz=1
      p_izlaz:=0
    ENDIF
*------- Prekid
    IF LASTKEY()=27
      CLOSE DATABASES
      ERASE xxxxwwww.dbf
      EXIT

*------- NA dole
    ELSEIF LASTKEY()=24 
      IF EOF()
        @ 23,3 SAY "Nema daljeg listanja na dole !"
        p_red:=7
        GO p_brr
        LOOP
      ENDIF
      @ 6,1 CLEAR TO 23,78
      p_red:=7
      p_brr:=p_brr+1
      GO p_brr
      LOOP

*------- Na gore
    ELSEIF LASTKEY()=5 
      @ 6,1 CLEAR TO 23,78
      p_red:=7
      p_brr=p_brr-1
      GO p_brr
      IF BOF()
        @ 23,3 SAY "Nema daljeg listanja na gore !"
        p_red:=7
        p_brr:=p_brr+1
        GO p_brr
        LOOP
      ENDIF
      LOOP
*------- Neka druga tipka
    ELSE
      FOR i=1 TO 3
        IF LASTKEY ()=24 .OR. LASTKEY()=5
          p_izlaz:=1
          LOOP
        ENDIF
        @ 18,31 SAY "POGRESAN TASTER !"
        INKEY(1.2)
        @ 18,31 SAY "                 " 
        INKEY(0.3)
      NEXT
      p_red:=7
      GO p_brr
      LOOP
    ENDIF
  ENDIF
ENDDO
CLOSE DATABASES
ERASE xxxxwwww.dbf
SET COLOR TO
CLOSE DATABASES
CLEAR SCREEN
QUIT
