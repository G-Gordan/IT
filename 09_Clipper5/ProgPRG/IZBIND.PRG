CLEAR SCREEN

p_baza:=SPACE(12)
p_polje1:=SPACE(10)
p_polje2:=SPACE(10)
p_polje3:=SPACE(10)
p_polje4:=SPACE(10)
p_polje5:=SPACE(10)
p_polje6:=SPACE(10)
p_ime1indbaz:=SPACE(8)
p_ime2indbaz:=SPACE(8)
p_izraz:=SPACE(100)

p_baza:="aaa.dbf"
p_polje1:="art"
p_polje2:="nza"
p_polje3:="jmr"
p_polje4:="knt"
p_polje5:="ozn"
p_polje6:="kol"
p_ime1indbaz:="1probibz"
p_ime2indbaz:="2probibz"

IF ! FILE("aaa.dbf")
 @ 5,5 SAY "Baza AAA.DBF ne postoji u tekucem direktoriju !"
 QUIT
ENDIF

*IF ! FILE("1probibz.ntx")
* @ 5,5 SAY "Indeksiram AAA.DBF sa 1PROBIBZ.NTX"
* USE &p_baza
* INDEX ON &p_polje1 TO &p_ime1indbaz
*ELSE
* @ 5,5 SAY "Baza 1PROBIBZ.NTX vec postoji u tekucem direktorijumu !"
* QUIT
*ENDIF

*p_zaart:=SPACE(3)
*p_zaknt:=SPACE(3)
*p_zakol:=SPACE(3)

*p_zaart:=STR(LTRIM(TRIM(&p_polje1)))
*p_zaknt:=STR(LTRIM(TRIM(&p_polje4)))
*p_zakol:=STR(LTRIM(TRIM(&p_polje6)))

*@ 10,5 SAY p_zaart+p_zaknt+p_zakol

IF ! FILE("2probibz.ntx")
 @ 6,5 say "Indeksiram AAA.DBF sa 2PROBIBZ.NTX"
 USE &p_baza
 p_izraz:="STR(&p_polje1,10)+&p_polje2+STR(&p_polje4,7)+STR(&p_polje6,9,3)"
 INDEX ON &p_izraz TO &p_ime2indbaz
ELSE
 @ 5,5 SAY "Baza 2PROBIBZ.NTX vec postoji u tekucem dirktorijumu !"
 QUIT
ENDIF


QUIT

