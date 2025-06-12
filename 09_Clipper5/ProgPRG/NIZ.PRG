CLEAR

DO WHILE .T.
 m_naz:=SPACE(12)
 @ 7,5 SAY "Uneti naziv  " GET m_naz
 READ
 CLEAR SCREEN
 IF LASTKEY() =27
  EXIT
 ENDIF

 ar1:=1
 brm:=1
 m1:=" "
 m1a:=m_naz
 brm1:=1
 brzn1:=LEN(m1a)
 DO WHILE brm <= brzn1
  m1b:=SUBSTR(m1a,brm,1)
  brm:=brm+1
  IF m1b = "." .OR. m1b = " "
   EXIT
  ENDIF
  m1:=m1+m1b

 ENDDO

 m1:=ALLTRIM(m1)
 @ 8,5 SAY m1

ENDDO

m2:=" "
brmst:=LEN(m1)+2
m2:=SUBSTR(m_naz,brmst,3)
@ 10,5 SAY m2



QUIT
