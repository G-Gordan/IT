CLEAR
m_baza:=SPACE(12)
@ 2,2 SAY "Unesite ime baze sa navedenom ekstenzijom - " GET m_baza
READ
IF ! FILE(m_baza)
 @ 3,2 SAY "Ta baza ne postoji !"
ELSE
 USE &m_baza
 COPY TO osob STRUCTURE EXTENDED
 CLOSE
 USE osob
 m_brsl:=RECCOUNT()
 crta:=REPLICATE("-",52)
 m_red:=6
 @ 4,4 SAY "IME POLJA"
 @ 4,17 SAY "KARAKTER"
 @ 4,27 SAY "BROJ MESTA"
 @ 4,41 SAY "BROJ DECIMALA"
 @ 5,3 SAY crta
 FOR i=1 TO m_brsl
  @ m_red,4 SAY field_name
  @ m_red,17 SAY field_type
  @ m_red,27 SAY STR(field_len,3)
  @ m_red,41 SAY STR(field_dec,3)
  m_red:=m_red+1
  SKIP
 NEXT
 @ m_red,3 SAY crta
ERASE osob.dbf
ENDIF
QUIT
