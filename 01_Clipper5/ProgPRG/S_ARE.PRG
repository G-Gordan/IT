* S_ARE.PRGLED STANJA PO ARTIKLU I REMONTERU
SET CONFIRM ON
CLEAR SCREEN
*** Okvir ***
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_ARE"
@ 2,25 SAY "ARTIKAL - REMONTER"
@ 2,61 SAY "''ESC''  za kraj"
*** postavljanje promenljivih ***
m_stv=0
m_kst=0
p_kst=0
r_kst=0
m_art=0
m_knt=0
m_kon="6"
m_nza=SPACE(42)
m_jmr=SPACE(3)
m_odl="N"
aa=0
pp=0
*** Jedinice mere ***
DECLARE taj[99]
taj[01]="KOM"
taj[02]="PAR"
taj[03]="GAR"
taj[13]="M 1"
taj[23]="M 2"
taj[33]="M 3"
taj[41]="GR "
taj[42]="KG "
taj[43]="T  "
taj[53]="L  "
taj[99]="XXX"
red=5
*** Postavka zaglavlja ***
@  6,1 SAY "Izgled liste :"
@  8,1 SAY "                STANJE PO ARTIKLIMA I REMONTERIMA"
@ 10,1 SAY "---------------------------------------------------------------------------"
@ 11,1 SAY " ARTIKAL         NAZIV                               JMR  KONTO  STANJE"
@ 12,1 SAY "                            REMONTER                            KOLICINA"
@ 13,1 SAY "---------------------------------------------------------------------------"
*** Postavka radnih polja ***
SELECT 1
USE Matc INDEX matcid
SELECT 2
USE Izvr INDEX izvrid
SELECT 4
USE Stan INDEX stankd
SELECT 3
USE Stiz INDEX stizsd
@ 7,1 CLEAR TO 7,76
DO WHILE .T.
  *** Upis stovarista ***
  @ 15,10 SAY "Stovariste        : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  *** Izlaz iz petlje ***
  READ
  IF LASTKEY() = 27
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  *** Prettraga ***
  SEEK STR(m_stv,3)
  *** Ako zadato stovariste nije nadjeno ***
  IF ! FOUND()
    @ 23,1 SAY "To STV ne postoji u STIZ !"
    INKEY(0)
    @ 23,1 SAY "                          "
    m_stv=0
    LOOP
  ENDIF
  m_art=art
  m_izv=izv
  CLEAR SCREEN
  *** Radi do kraja baze ***
  DO WHILE ! EOF()
    *** Ako je prvi krug (aa=0) - postavlja zaglavlje ***
    IF aa=0
      @ 1,22SAY "STANJE PO ARTIKLIMA I REMONTERIMA"
      @ 2,1 SAY "Stovariste : "+STR(m_stv,3)
      @ 2,68 SAY DTOC(DATE())
      @ 3,1 SAY "----------------------------------------------------------------------------"
      @ 4,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO     STANJE"
      @ 5,1 SAY "----------------------------------------------------------------------------"
      aa=1
    ENDIF
    *** Pretrazuje odredjeni artikal po zadatom stovaristu ***
    SELECT 4
    SEEK STR(m_stv,3)+m_kon+STR(m_art,10)
    ***ako je nasao, uzima vrednosti i skida decimale***
    IF FOUND()
      m_knt=knt
      m_kst=kst/1000
    ***ako ne nadje, upisuje nule*** 
    ELSE
      m_knt=0
      m_kst=0
    ENDIF
    SELECT 1
    *** Pretrazuje artikal po maticnoj bazi ***
    USE Matc INDEX matcid
    SEEK m_art
    IF FOUND()
      IF jmr="  "
        m_nza="Nepoznat naziv ?                          "
        m_jmr="   "
      ELSE
        m_nza=nza
        m_jmr=taj[VAL(jmr)]
      ENDIF
    ELSE
      m_nza="Nepoznat naziv ?                          "
      m_jmr="   "
    ENDIF
    *** Ispis nadjene kombinacije ***
    red=red+1
    @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+"   "+STR(m_kst,7)
    red=red+1
    SELECT 3
    *** Ispis sve kombinacije zadatih STV i ART ***
    DO WHILE m_stv=stv .AND. m_art=art
      *** Sabira krajnje stanje za nekog izvodjaca ***
      DO WHILE m_stv=stv .AND. m_art=art .AND. m_izv=izv
        p_kst=p_kst+kst
        SKIP
      ENDDO
      *** Ide na sledeceg izvodjaca ***
      SELECT 2
      SEEK m_izv
      IF FOUND()
        *** "dom" je IME kod izvodjaca radova - remontera ***
        m_dom=dom
      ELSE
        m_izv=0
        m_dom="Nepoznati remonter !          "
      ENDIF
      p_kst=p_kst/1000
      @ red,20 SAY STR(m_izv,6)+" "+m_dom+"           "+STR(p_kst,7)
      red=red+1
      ***Kraj ekrana - novi ispis***
      IF red>21
        red=5
        aa=0
        p_kst=0
        m_izv=C->izv
        *** Izbacuje iz petlje i nastavlja rad posle "ENDDO" ***
        EXIT
      ENDIF
      SELECT 3
      p_kst=0
      m_izv=izv
    ENDDO
    *** Prvi ispis stranice aa=0 ***
    IF aa=0
      @ 23,1 SAY "Pritisni bilo sta za dalje, ESC - izlazak"
      INKEY(0)
      IF LASTKEY()=27
        EXIT
      ENDIF
      CLEAR SCREEN
      *** vraca na petlju za sledeci upis i pregled ***
      LOOP
    *** Ako pronadje zadato stovariste ***
    ELSEIF m_stv=stv
      m_art=art
      m_izv=izv
      p_kst=0
    *** Nije prvi krug i nije nadjeno stovariste ***
    ELSE
      EXIT
    ENDIF
  ENDDO
  EXIT
ENDDO

*******
***************
********

@ 23,1 CLEAR
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,77
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  *
  SET DEVICE TO PRINT
     SET PRINTER TO STAMPA
  *
  m_kst=0
  p_kst=0
  r_kst=0
  m_art=0
  m_knt=0
  m_kon="6"
  m_nza=SPACE(42)
  m_jmr=SPACE(3)
  aa=0
  red=5
  *
  SELECT 1
  USE Matc INDEX matcid
  SELECT 2
  USE Izvr INDEX izvrid
  SELECT 4
  USE Stan INDEX stankd
  SELECT 3
  USE Stiz INDEX stizsd
  @ 7,1 CLEAR TO 7,76
  DO WHILE .T.
    SEEK STR(m_stv,3)
    m_art=art
    m_izv=izv
    CLEAR SCREEN
    DO WHILE ! EOF()
      IF aa=0
        @ 1,22SAY "STANJE PO ARTIKLIMA I REMONTERIMA"
        @ 2,1 SAY "Stovariste : "+STR(m_stv,3)
        @ 2,68 SAY DTOC(DATE())
        @ 3,1 SAY "----------------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO     STANJE"
        @ 5,1 SAY "----------------------------------------------------------------------------"
        aa=1
      ENDIF
      SELECT 4
      SEEK STR(m_stv,3)+m_kon+STR(m_art,10)
      IF FOUND()
        m_knt=knt
        m_kst=kst/1000
      ELSE
        m_knt=0
        m_kst=0
      ENDIF
      SELECT 1
      USE Matc INDEX matcid
      SEEK m_art
      IF FOUND()
        IF jmr="  "
          m_nza="Nepoznat naziv ?                          "
          m_jmr="   "
        ELSE
          m_nza=nza
          m_jmr=taj[VAL(jmr)]
        ENDIF
      ELSE
        m_nza="Nepoznat naziv ?                          "
        m_jmr="   "
      ENDIF
      red=red+1
      @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+"   "+STR(m_kst,7)
      red=red+1
      SELECT 3
      SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_izv,6)
      DO WHILE m_stv=stv .AND. m_art=art
        DO WHILE m_stv=stv .AND. m_art=art .AND. m_izv=izv
          p_kst=p_kst+C->kst
          SKIP
        ENDDO
        SELECT 2
        SEEK m_izv
        IF FOUND()
          m_dom=dom
        ELSE
          m_izv=0
          m_dom="Nepoznati remonter !          "
        ENDIF
        p_kst=p_kst/1000
        @ red,20 SAY STR(m_izv,6)+" "+m_dom+"           "+STR(p_kst,7)
        red=red+1
        IF red>55
          red=5
          aa=0
          p_kst=0
          m_izv=C->izv
          EXIT
        ENDIF
        SELECT 3
        p_kst=0
        m_izv=izv
      ENDDO
      IF m_stv=stv
        m_art=art
        m_izv=izv
        p_kst=0
      ELSE
        EXIT
      ENDIF
      SELECT 4
    ENDDO
    EXIT
  ENDDO
ENDIF
red=red+1
@ red,1 SAY "  "
SET CONFIRM OFF
SET DEVICE TO SCREEN
CLEAR SCREEN
CLOSE DATABASES
RETURN
