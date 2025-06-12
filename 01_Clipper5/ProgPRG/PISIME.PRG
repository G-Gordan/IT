CLEAR

@ 2,2 SAY "Sad ce da izlista !"
INKEY(0)
RUN DIR/p
? "I Z L I S T A O   JE   !"
INKEY(0)

DO WHILE .T.
 CLEAR SCREEN
 m_upis:="D"
 @ 12,26 SAY "DA LI ZELITE DA PROMENITE IME NEKOG FAJLA ? (D/N)";
         GET m_upis PICTURE "!" VALID(m_upis $ "DdNn")
 READ
 CLEAR SCREEN
 IF m_upis = "N"
  EXIT
 ELSEIF m_upis = "D"
  CLOSE DATABASES
  m_sime:=SPACE(12)
  m_nime:=SPACE(12)
  @ 12,26 SAY "FAJL POD IMENOM " GET m_sime
  @ 13,26 SAY "'OCU DA SE ZOVE " GET m_nime
  READ
  IF ! FILE(m_sime)
   @ 14,26 SAY "TOGA NECE DA BIDNE MAJSTORU !"
   INKEY(0)
   LOOP
  ENDIF
  m_sime:=ALLTRIM(m_sime)
  m_nime:=ALLTRIM(m_nime)
  RENAME &m_sime TO &m_nime
 ENDIF
ENDDO
QUIT
