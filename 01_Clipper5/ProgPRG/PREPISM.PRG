*********************************************
* Program za prpisivanje DBF u TXT i obrnuto
*********************************************
SET COLOR TO gr+/b
CLEAR SCREEN
m_dbf=SPACE(10)
k_dbf=SPACE(14)
t_txt=SPACE(14)
DO WHILE .T.
  @ 1,0 TO 3,78 DOUBLE
  @ 5,0 TO 23,78 DOUBLE
  @ 2,3 SAY "PREPIS"
  @ 2,25 SAY "PREPIS TABELE-DATOTEKE"
  @ 2,61 SAY "''ESC'' za kraj"
  m_izbor=1
  @ 7,20 PROMPT " DBF  u  TXT ";
         MESSAGE "PREPISIVANJE DBF TABELE U txt DATOTEKU"
  @ 7,38 PROMPT " TXT  u  DBF ";
         MESSAGE "PREPISIVANJE TXT DATOTEKE U DBF TABELU"
  CLEAR TYPEAHEAD
  MENU TO m_izbor
  DO CASE
    CASE LASTKEY()=27
         SET CONFIRM OFF
         CLEAR SCREEN
         RETURN
    CASE m_izbor=1
         @ 14,10 SAY "DBF  " GET m_dbf PICTURE "@9"
         @ 16,10 SAY "DBF FILE bez nastavka .DBF"
         READ
         IF LASTKEY()=27
           EXIT
         ENDIF
         p_dbf=ALLTRIM(m_dbf)
         k_dbf=p_dbf+".DBF"
         t_txt=p_dbf+".TXT"
         IF ! FILE(k_dbf)
           @ 14,50 SAY "Taj DBF ne postoji !"
           INKEY(0)
           m_dbf=SPACE(10)
           LOOP
         ENDIF
         SELECT 1
         USE &k_dbf
         COPY TO &t_txt sdf
         aa=RECCOUNT()
         @ 18,10 SAY "Prepisano "+STR(aa,9)
         INKEY(3)
         CLEAR SCREEN
         QUIT
    CASE m_izbor=2
         @ 14,10 SAY "TXT  " GET m_dbf PICTURE "@9"
         @ 16,10 SAY "TXT FILE bez nastavka .TXT"
         @ 18,10 SAY "DBF FILE mora da postoji prazna !"
         READ
         IF LASTKEY()=27
           EXIT
         ENDIF
         p_dbf=ALLTRIM(m_dbf)
         k_dbf=p_dbf+".DBF"
         t_txt=p_dbf+".TXT"
         SELECT 1
         USE &k_dbf
         aa=RECCOUNT()
         IF aa>0
           @ 14,50 SAY k_dbf+" nije prazna !"
           INKEY(0)
           EXIT
         ENDIF
         APPEND FROM &t_txt sdf
         aa=RECCOUNT()
         @ 20,10 SAY "Prepisano "+STR(aa,9)
         INKEY(3)
         CLEAR SCREEN
         QUIT
    OTHERWISE
         EXIT
  ENDCASE
ENDDO
CLEAR SCREEN
CLOSE DATABASES
RETURN
