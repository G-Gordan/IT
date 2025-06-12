CLS


stampa:=0


SELECT 10
USE stamp
stampa:=izborst


DO CASE
CASE stampa=1
  * Stanje artikla po stovaristima *
  DO s_aru
CASE stampa=2
  * Artikli po dnevnim promenama stanja *
  DO s_dne
CASE stampa=3
  * Pregled stanja zaliha u tvom stovaristu *
  DO s_stv
CASE stampa=4
  * Stanje zaliha na osnovu dela sifre artikla *
  DO s_art
CASE stampa=5
  * Listanje maticne i stanja zaliha na osnovu dela naziva artikla *
  DO s_naz
CASE stampa=6
  * Listanje karte materijala i promena na odredjenoj sifri *
  DO s_kar
CASE stampa=7
  * Listanje promena na odredjenoj sifri (dokument/artikal) *
  DO s_dok
CASE stampa=8
  * Pregled promena od pocetka godine *
  DO s_pro
CASE stampa=9
  * Listanje odredjenog dokumenta *
  DO s_dod
CASE stampa=10
  * Listanje odredjenog remontera *
  DO s_rem
CASE stampa=11
  * Listanje odredjenog remontera - zbirno *
  DO s_rer
CASE stampa=12
  * Odredjeni broj motora *
  DO s_rbm
CASE stampa=13
  * Listanje po artiklima i remonterima *
  DO s_are
CASE stampa=14
  * Ukupne nabavke u toku tekuce godine *
  DO s_uku
CASE stampa=15
  * Listanje utroska po artiklima *
  DO s_utr
CASE stampa=16
  * Listanje stavki sa negativnim stanjem *
  DO s_neg
CASE stampa=17
  * Listanje neaktivnih stavki *
  DO s_nea
ENDCASE
CLOSE DATABASES
RETURN



**********************
*Programi za stampanje
**********************


******************************
PROCEDURE s_are
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

*** Stampa izvestaja ***
@ 23,1 CLEAR
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  ***Ispis poruka***
  @ 15,1 CLEAR TO 23,77
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  ***Kontrolise da li je stampac prikljucen na paralelni port ***
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  ***Upucuje ispis na stampac***
  SET DEVICE TO PRINT
     SET PRINTER TO STAMPA
  ***postavlja promenljive***
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
  ***postavlja radna polja***
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
    ***Radi do kraja***
    DO WHILE ! EOF()
      ***Ispisuje samo u prvom ispisu stranice***
      IF aa=0
        @ 1,22SAY "STANJE PO ARTIKLIMA I REMONTERIMA"
        @ 2,1 SAY "Stovariste : "+STR(m_stv,3)
        @ 2,68 SAY DTOC(DATE())
        @ 3,1 SAY "----------------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO     STANJE"
        @ 5,1 SAY "----------------------------------------------------------------------------"
        aa=1
      ENDIF
      ***Pretrazuje zadatu kombinaciju STV+KNT+ART***
      SELECT 4
      SEEK STR(m_stv,3)+m_kon+STR(m_art,10)
      IF FOUND()
        m_knt=knt
        m_kst=kst/1000
      ELSE
        m_knt=0
        m_kst=0
      ENDIF
      ***Pretrazuje ART u MATC.DBF***
      SELECT 1
      USE Matc INDEX matcid
      SEEK m_art
      ***Nadjen je ART***
      IF FOUND()
        ***Jedinica mere nema upisanu vrednost***
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
      *** Ispisuje nadjeni slug ***
      red=red+1
      @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+"   "+STR(m_kst,7)
      red=red+1
      *** Pretrazuje stanje izvodjaca ***
      SELECT 3
      SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_izv,6)
      DO WHILE m_stv=stv .AND. m_art=art
        *** Sabira kolicinu za odredjenog izvodjaca po zadatom STV+ART ***
        DO WHILE m_stv=stv .AND. m_art=art .AND. m_izv=izv
          p_kst=p_kst+C->kst
          SKIP
        ENDDO
        ***Trazi izvodjaca i uzima njegovo ime***
        SELECT 2
        SEEK m_izv
        IF FOUND()
          m_dom=dom
        ELSE
          m_izv=0
          m_dom="Nepoznati remonter !          "
        ENDIF
        p_kst=p_kst/1000
        *** Ispis sloga ***
        @ red,20 SAY STR(m_izv,6)+" "+m_dom+"           "+STR(p_kst,7)
        red=red+1
        *** Ako je ispis na papiru stigao do kraja ***
        IF red>55
          red=5
          aa=0
          p_kst=0
          m_izv=C->izv
          EXIT
        ENDIF
        *** Prelazi u radno polje gde je stanje izvodjaca ***
        SELECT 3
        p_kst=0
        m_izv=izv
      ENDDO
      *** Kad se pri ispisu, uzima novi artkal za isto stovariste  ***
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



*********************************
PROCEDURE s_art
* S_ART.PRG STAMPA SA DELOM SIFRE ARTIKLA*
SET CONFIRM ON
CLEAR SCREEN
*Okvir i deo zaglavlja*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_ART"
@ 2,25 SAY "STAMPA SA DELOM SIFRE ARTIKLA"
@ 2,61 SAY "''ESC'' za kraj"
*Postavka promenljivih*
m_art=SPACE(10)
p_art=0
m_nza=0
m_jmr=SPACE(3)
m_stv=0
m_kst=0
m_knt=0
m_odl="N"
t=SPACE(1)
* Matrica za jedinice mere *
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
*Postavka promenljivih*
aa=0
bb=0
cc=0
dd=0
ee=0
b=0
br=0
ba=0
red=6
*Zaglavlje*
@  6,1 SAY "Izgled izvestaja :"
@  8,1 SAY "         STANJE NOVIH ZALIHA NA OSNOVU DELA SIFRE ARTIKLA"
@  9,1 SAY "---------------------------------------------------------------------------"
@ 10,1 SAY " ARTIKAL    NAZIV                                    JMR  KONTO    KOLICINA"
@ 11,1 SAY "---------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Stan INDEX stankd
GO TOP
SELECT 2
USE Matc INDEX matcid
GO TOP
@ 15,9 CLEAR
DO WHILE .T.
  *Unos podataka*
  @ 13,8 SAY "STOVARISTE             :  " GET m_stv PICTURE "999";
          VALID(m_stv > 0)
  @ 15,8 SAY "Pocetak sifre ARTIKLA  :  " GET m_art PICTURE "@9";
          VALID(m_art # " ")
  @ 16,8 SAY "obavezno sa '*' na kraju !"
  READ
  *izlazak iz petlje*
  IF LASTKEY() = 27
    ee=1
    CLEAR SCREEN
    EXIT
  ENDIF
  * Pretraga stovarista *
  SELECT 1
  USE Stan INDEX stankd
  GO TOP
  SEEK STR(m_stv,3)
  IF ! FOUND()
    @ 21,1 SAY "To stovariste nije tvoje !"
    INKEY(3)
    m_stv=0
    @ 21,1 SAY "                          "
    LOOP
  ENDIF
  FOR i = 1 TO 10
    t = SUBSTR(m_art,i,1)
    IF t = "*"
      * Odredjeuje koliko je slova bilo pre znaka "*" *
      b=i-1
      EXIT
    ENDIF
  NEXT
  *Ako u "b" nije upisano nista*
  IF b = 0
    @ 15,50 SAY "Nisi stavio '*' na kraju !"
    INKEY(3)
    @ 15,50 SAY "                          "
    m_art=SPACE(10)
    LOOP
  ENDIF
  *Radi za sve podatke o zadatom stovaristu*
  DO WHILE m_stv=stv
    *Dok je nova roba na zadatom stovaristu*
    DO WHILE m_stv=stv .AND. kon=1
      *Ako uneti deo sifre artikla odgovara istom tolikom delu (b) iz baze*
      IF m_art=SUBSTR(STR(art,10),1,b)
        *Nema nista na krajnjem stanju*
        IF kst = 0
          SKIP
          LOOP
        ENDIF
        bb=1
        cc=1
        *Prvi ispis stranice*
        IF aa=0
          CLEAR SCREEN
          @ 1,10SAY "STANJE NOVIH ZALIHA NA OSNOVU DELA SIFRE ARTIKLA I KOLICINA#0"
          @ 2,1 SAY "Stovariste : "+STR(stv,3)+"     Artikli : "+m_art+"                           "+DTOC(DATE())
          @ 3,1 SAY "----------------------------------------------------------------------------"
          @ 4,1 SAY " ARTIKAL      NAZIV                                   JMR  KONTO    KOLICINA"
          @ 5,1 SAY "----------------------------------------------------------------------------"
          aa=1
        ENDIF
        m_kst=kst/1000
        m_knt=knt
        *Pretrazuje artikal iz U1DAT u MATC*
        SELECT 2
        USE Matc INDEX matcid
        GO TOP
        SEEK A->art
        IF FOUND()
          *nema jedinice mere jer je nova stavka*
          IF jmr="  "
            m_nza="Nepoznat naziv ?                          "
            m_jmr="   "
          *Uzima jedinicu mere iz matrice*
          ELSE
            m_nza=nza
            m_jmr=taj[VAL(jmr)]
          ENDIF
        *nije nadjeno*
        ELSE
          m_nza="Nepoznat naziv ?                          "
          m_jmr="   "
        ENDIF
        * Ispis stanja odredjenog artikla *
        @ red,1 SAY STR(A->art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(m_kst,10,3)
        red=red+1
        br=br+1
        *Kada ispise ceo ekran*
        IF red=23
          SELECT 1
          @ 23,2 SAY "Unazad sa PAGE UP, bilo sta za dalje !"
          INKEY(0)
          * Ako je pritisnuto "Page Up" *
          IF LASTKEY()=18
            SKIP -23
            br=br-23
            *Ako ima manje od 23 za novi ispis*
            IF br<0
              br=0
              GO TOP
              SEEK STR(m_stv,3)
              cc=0
            ENDIF
          ENDIF
          *Izlazak*
          IF LASTKEY()=27
            EXIT
          ENDIF
          red=6
          aa=0
        ENDIF
        SELECT 1
      *Nema trazenog dela imena u bazi*
      ELSE
        IF cc=1
          EXIT
        ENDIF
      ENDIF
      *Proverzva sledeci artikal iz baze*
      SKIP
    ENDDO
    IF cc=0
      EXIT
    ENDIF
    IF LASTKEY()=27
      EXIT
    ENDIF
    @ 23,2 SAY "Pomeranje unazad sa PAGE UP !         "
    INKEY(0)
    *Ako je pritisnuto "Page Up"*
    IF LASTKEY()=18
      SKIP -20
      red=6
      aa=0
      cc=0
    ENDIF
  ENDDO
  *Ako nije bilo nikakvog ispisa (bb=0)*
  IF bb = 0
    @ 23,2 SAY "Ne postoje sifre sa tim pocetnim ciframa !"
    INKEY(4)
    @ 23,2 SAY "                                          "
    LOOP
  ENDIF
  @ 23,2 SAY "Nema vise podataka u banci !          "
  @ 23,50 SAY "  "
  INKEY(0)
  EXIT
ENDDO
*Ako je "Esc" izabrano gore kod unosa podataka*
IF LASTKEY() = 27 .AND. ee=1
  SET DEVICE TO SCREEN
  SET CONFIRM OFF
  CLOSE DATABASES
  CLEAR SCREEN
  RETURN
ENDIF
*Upit za stampanje*
@ 23,1 CLEAR
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
aa=0
cc=0
red=6
*Izabrano stampanje*
IF m_odl="D" .OR. m_odl="d"
  *Ispis okvira i poruka*
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *Stampac nije prikljucen*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  *Upucuje ispis na stampac*
  SET DEVICE TO PRINT
  *  SET PRINTER TO STAMPA
  *Pretrazuje stanje po stovaristu*
  SELECT 1
  USE Stan INDEX stankd
  GO TOP
  SEEK STR(m_stv,3)
  DO WHILE m_stv=stv .AND. kon=1
    *Ako je nadjen artikal po delu sifre*
    IF m_art=SUBSTR(STR(art,10),1,b)
      *Nema na stanju*
      IF kst = 0
        SKIP
        LOOP
      ENDIF
      cc=1
      *Pri prvom ispisu stranice ispisuje zaglavlje*
      IF aa=0
        @ 1,10SAY "STANJE NOVIH ZALIHA NA OSNOVU DELA SIFRE ARTIKLA I KOLICINA#0"
        @ 2,1 SAY "Stovariste : "+STR(stv,3)+"     Artikli : "+m_art+"                           "+DTOC(DATE())
        @ 3,1 SAY "----------------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL      NAZIV                                   JMR  KONTO    KOLICINA"
        @ 5,1 SAY "----------------------------------------------------------------------------"
        aa=1
      ENDIF
      m_kst=kst/1000
      m_knt=knt
      SELECT 2
      USE Matc INDEX matcid
      GO TOP
      SEEK A->art
      IF FOUND()
        *Nova sifra na stanju*
        IF jmr="  "
          m_nza="Nepoznat naziv ?                          "
          m_jmr="   "
        *Nadjeno i uzima vrednost NZA iz baze i po JMR iz matrice*
        ELSE
          m_nza=nza
          m_jmr=taj[VAL(jmr)]
        ENDIF
      *Nije nadjeno*
      ELSE
        m_nza="Nepoznat naziv ?                          "
        m_jmr="   "
      ENDIF
      * Ispis nadjenog sloga *
      @ red,1 SAY STR(A->art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(m_kst,10,3)
      red=red+1
      *Ogranicava red na 58*
      IF red=58
        red=6
        aa=0
      ENDIF
      SELECT 1
    *Nema zadate kombinacije dela naziva artikla*
    ELSE
      IF cc=1
        EXIT
      ENDIF
    ENDIF
    SKIP
  ENDDO
  @ red,1 SAY "  "
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLOSE DATABASES
CLEAR SCREEN
RETURN



**********************************
PROCEDURE s_aru
* S_ARU.PRG ARTIKAL U SVIM STOVARISTIMA
SET CONFIRM ON
CLEAR SCREEN
*Okvir i deo zaglavlja*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_ARU"
@ 2,25 SAY "ARTIKAL U SVIM STOVARISTIMA"
@ 2,61 SAY "''ESC'' za kraj"
*Postavka promenljivih*
m_kst=0
m_art=0
m_kon=0
m_stv=0
m_nza=SPACE(42)
m_jmr=SPACE(3)
m_knt=0
m_sel=0
p_sel=0
m_kol=0.00
m_odl="N"
aa=0
*Postavka matrice sa kontima*
DECLARE tak[7]
tak[1]="Novo"
tak[2]="Polovno"
tak[3]="Nepotrebno - Zastarelo (novo)"
tak[4]="Nepotrebno - Zastarelo (polovno)"
tak[5]="Na obradi,,, (novo)"
tak[6]="Na obradi,,, (polovno)"
tak[7]="Upotreba"
*Postavka matrice sa jedinicama mere*
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
red=7
*Ispis zaglavlja*
@  6,1 SAY "Izgled liste :"
@  8,1 SAY "               ARTIKAL PO STOVARISTIMA (kolicina>0)"
@ 10,1 SAY " ARTIKAL         NAZIV                                     JM  KONTO"
@ 11,1 SAY "-------------------------"
@ 12,1 SAY " STOVARISTE   KOLICINA"
@ 13,1 SAY "-------------------------"
*Postavka radnih polja*
SELECT 1
USE Stan INDEX stanad
GO TOP
SELECT 2
USE Matc INDEX matcid
GO TOP
@ 15,9 CLEAR
*Upit za unos podataka*
DO WHILE .T.
  @ 14,10 SAY "Sifra ARTIKLA : " GET m_art PICTURE "9999999999";
          VALID(m_art>0)
  @ 16,10 SAY "Selekcija         : " GET m_sel PICTURE "9";
          VALID(m_sel>0 .AND. m_sel<7)
  @ 16,55 SAY "1 - Novo"
  @ 17,55 SAY "2 - Polovno"
  @ 18,55 SAY "3 - Zastarelo - novo"
  @ 19,55 SAY "4 - Zastarelo - polovno"
  @ 20,55 SAY "5 - Na obradi - novo"
  @ 21,55 SAY "6 - Na obradi - polovno"
  @ 22,55 SAY "2 - Upotreba"
  READ
  p_sel=m_sel
  *"Esc" - izlazak iz stampe*
  IF LASTKEY() = 27
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  *Pretrazuje artikal na stanju*
  SELECT 1
  USE Stan INDEX stanad
  GO TOP
  SEEK STR(m_art,10)
  IF ! FOUND()
    @ 14,40 SAY "Tog ARTIKLA nema na stanju !"
    INKEY(2)
    @ 14,40 SAY "                            "
    m_art=0
    LOOP
  ENDIF
  *Pretrazuje artikal po kontu*
  SEEK STR(m_art,10)+STR(m_sel,1)
  IF ! FOUND()
    @ 23,1 SAY "Na tom KONTU nema tog ARTIKLA !"
    INKEY(0)
    @ 23,1 SAY "                                "
    m_art=0
    m_sel=0
    LOOP
  ENDIF
  CLEAR SCREEN
  m_kon=kon
  SELECT 2
  USE Matc INDEX matcid
  GO TOP
  SEEK A->art
  *Nadjeno*
  IF FOUND()
    *Novi artikal*
    IF jmr="  "
      m_nza="Nepoznat naziv ?                          "
      m_jmr="   "
    *Nadjenvec poznati artikal*
    ELSE
      m_nza=nza
      m_jmr=taj[VAL(jmr)]
    ENDIF
  *Nije nadjeno*
  ELSE
    m_nza="Nepoznat naziv ?                          "
    m_jmr="   "
  ENDIF
  SELECT 1
  *Ispisuje sve kombinacije artikla sa datim kontom do kraja baze*
  DO WHILE m_art=art .AND. m_sel=kon .AND. ! EOF()
    *Prvi ispis - ispis zaglavlja*
    IF aa=0
      m_knt=knt
      @ 1,18SAY "ARTIKAL PO STOVARISTIMA (kolicina # 0)"
      @ 3,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+"   "+DTOC(DATE())
      @ 4,1 SAY "------------------------------"
      @ 5,1 SAY "   STOVARISTE      KOLICINA"
      @ 6,1 SAY "------------------------------"
      aa=1
    ENDIF
    m_stv=stv
    m_kst=kst/1000
    @ red,8 SAY STR(m_stv,3)+"     "+STR(m_kst,12,3)
    m_kol=m_kol+m_kst
    red=red+1
    SKIP
    *Ako red predje 22 ispisuje novu stranicu na ekranu*
    IF red > 22
      red=7
      aa=0
      INKEY(0)
      @ 7,0 CLEAR TO 23,79
    ENDIF
  ENDDO
  @ red,8 SAY "  "
  EXIT
ENDDO
@ red,18 SAY "==========="
red=red+1
*Sabira i ispisuje ukupnu kolicinu*
@ red,9 SAY "Ukupno "+STR(m_kol,12,3)+"   "+tak[m_sel]
*Upit za stampanje*
@ 23,1 CLEAR
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
*Izabrano stampanje*
IF m_odl="D" .OR. m_odl="d"
  *Okvir i poruke za stampanje*
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *Provera da li je prikljucen printer*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  *Postavka radnih polja*
  SELECT 1
  USE Stan INDEX stanad
  GO TOP
  SELECT 2
  USE Matc INDEX matcid
  GO TOP
  *Pretraga artikla u MATC.DBF*
  SEEK m_art
  IF FOUND()
    m_nza=nza
    m_jmr=taj[VAL(jmr)]
  ELSE
    m_nza="Nepoznat naziv ?                          "
    m_jmr="   "
  ENDIF
  *Ispis na printeru*
  DO WHILE .T.
    m_kol=0.00
    m_kon=0
    m_sel=p_sel
    aa=0
    red=7
    *Upucuje ispis na printer*
    SET DEVICE TO PRINT
    * SET PRINTER TO STAMPA
    *Pretrazuje artikal sa jednocifrenim kontom*
    SELECT 1
    SEEK STR(m_art,10)+STR(m_sel,1)
    *Ispisuje dok ima zadatog artikla sa kontom, do kraja*
    DO WHILE m_art=art .AND. m_sel=kon .AND. ! EOF()
      *Prvi ispis stranice ispisuje zaglavlje*
      IF aa=0
        m_knt=knt
        @ 1,18SAY "ARTIKAL PO STOVARISTIMA (kolicina # 0)"
        @ 3,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+"   "+DTOC(DATE())
        @ 4,1 SAY "------------------------------"
        @ 5,1 SAY "   STOVARISTE      KOLICINA"
        @ 6,1 SAY "------------------------------"
        aa=1
      ENDIF
      m_stv=stv
      m_kst=kst/1000
      *Ispis podataka*
      @ red,8 SAY STR(m_stv,3)+"     "+STR(m_kst,12,3)
      m_kol=m_kol+m_kst
      red=red+1
      SKIP
      *Ako je kraj stranice*
      IF red > 55
        red=7
        aa=0
        INKEY(0)
        @ 7,0 CLEAR TO 23,79
      ENDIF
    ENDDO
    @ red,8 SAY "  "
    EXIT
  ENDDO
  *Podvlaci sabira ukupnu kolicinu*
  @ red,18 SAY "==========="
  red=red+1
  @ red,9 SAY "Ukupno "+STR(m_kol,12,3)+"   "+tak[m_sel]
  red=red+1
  @ red,9 SAY "  "
*Odluka za stampu je "Nn"*
ELSE
  SET DEVICE TO SCREEN
  @ 20,1 CLEAR TO 23,79
  @ 23,1 SAY "Odustao si od stampe !"
  INKEY(2)
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN


******************************
PROCEDURE s_dne
* S_DNE.PRG DNEVNA PROMENA STANJA*
SET CONFIRM ON
CLEAR SCREEN
*Postavka okvira*
@ 1,0 TO 3,78 DOUBLE
@ 5,0 TO 23,78 DOUBLE
@ 2,3 SAY "S_DNE"
@ 2,25 SAY "DNEVNE PROMENE STANJA"
@ 2,61 SAY "''ESC'' za kraj"
*Matrica sa jedinicama mere*
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
*Promenljive za upis*
m_stv=0
nn=0
m_nza=SPACE(42)
m_jmr=SPACE(3)
*Upis stovarista*
DO WHILE nn=0
  @ 8,10 SAY "STOVARISTE : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  *Pretraga stovarista u stanju*
  SELECT 1
  USE Stan INDEX stansd
  GO TOP
  SEEK STR(m_stv,3)
  IF ! FOUND()
    @ 22,3 SAY "Nema podataka za to STV !"
    INKEY(3)
    @ 22,3 SAY "                         "
    m_stv=0
    LOOP
  ENDIF
  *Stovariste nadjeno*
  @ 15,1 CLEAR TO 21,77
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *Nema ukljucenog stampaca*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  aa=0
  red=6
  *Upucuje na stampac*
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  SELECT 1
  *Radi dok je zadato stovariste = STV iz STAN.DBF*
  DO WHILE m_stv=A->stv
    IF A->kon=1 .AND. A->dat=DATE()
      *Pretrazuje da li artikal postoji*
      SELECT 2
      USE Matc INDEX matcid
      GO TOP
      SEEK A->art
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
      SELECT 1
      *Prvi ispis stranice i ispis zaglavlja*
      IF aa=0
        @ 1,1 SAY "                     PREGLED DNEVNE PROMENE STANJA"
        @ 2,1 SAY "Stovariste : "+STR(m_stv,3)+"                                               "+DTOC(DATE())
        @ 3,1 SAY "------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL  NAZIV ARTIKLA                                JMR    KOLICINA"
        @ 5,1 SAY "------------------------------------------------------------------------"
        aa=1
      ENDIF
      m_kst=kst/1000
      *Ispis podataka*
      @ red,1 SAY STR(art,10)+" "+m_nza+"    "+m_jmr+"  "+STR(m_kst,9,3)
      red=red+1
      *Kraj stranice*
      IF red = 55
        red=6
        aa=0
      ENDIF
    ENDIF
    SKIP
    LOOP
  ENDDO
  @ red,1 SAY "  "
  EXIT
ENDDO
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN



***********************************
PROCEDURE s_dod
* S_DOD.PRG STAMPA ODREDJENOG DOKUMENTA
SET CONFIRM ON
CLEAR SCREEN
*Okvir stranice*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_DOD"
@ 2,25 SAY "ODREDJENI DOKUMENT"
@ 2,61 SAY "''ESC''  za kraj"
*Promenljive*
m_stv=0
m_dok=0
m_mes=0
m_mat=0
m_art=0
m_osu=SPACE(2)
m_kst=0
m_mss=0
m_nza=SPACE(42)
m_jmr=SPACE(3)
aa=0
red=6
m_vrs=SPACE(27)
m_dob=SPACE(6)
m_ost=SPACE(38)
m_znk=" "
m_odl="N"
*Matrice sa oznakama matova*
DECLARE tab[30]
tab[1]="01"
tab[2]="02"
tab[3]="03"
tab[4]="04"
tab[5]="05"
tab[9]="09"
tab[10]="10"
tab[11]="11"
tab[12]="12"
tab[13]="13"
tab[14]="14"
tab[20]="20"
tab[21]="21"
tab[23]="23"
tab[24]="24"
tab[30]="30"
*Matrica sa jedinicama mere*
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
*Zaglavlje za ispis*
@  6,1 SAY "Izgled liste :"
@  7,1 SAY "                  DOKUMENT BROJ xxxxx     MAT-xx"
@  8,1 SAY "Stovariste : xxx"
@  9,1 SAY "------------------------------------------------------------------------------"
@ 10,1 SAY "D-S-P MES OSN ARTIKAL   KOLICINA           NAZIV                           JMR"
@ 11,1 SAY "------------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Matc INDEX matcid
GO TOP
SELECT 2
USE Prom INDEX promid
GO TOP
@ 15,9 CLEAR
*Unos podataka*
DO WHILE .T.
  @ 13,10 SAY "STOVARISTE     : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 15,10 SAY "MESEC          : " GET m_mes PICTURE "99";
          VALID((m_mes>0 .AND. m_mes<13) .OR. m_mes=99)
  @ 17,10 SAY "BROJ DOKUMENTA : " GET m_dok PICTURE "99999";
          VALID(m_dok>0)
  @ 19,10 SAY "MAT obrazac    : " GET m_mat PICTURE "99";
          VALID(m_mat>0)
  READ
  *Izlaz na "Esc"*
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  *Pretraga zadate kombinacije
  SEEK STR(m_stv,3)+STR(m_mes,2)+STR(m_dok,5)+STR(m_mat,2)
  IF ! FOUND()
    @ 22,1 SAY "Tog STV-MES-DOK-MAT nema u promenama !"
    INKEY(3)
    @ 22,1 SAY "                                      "
    m_stv=0
    m_mes=0
    m_dok=0
    m_mat=0
    LOOP
  ENDIF
  m_art=art
  CLEAR SCREEN
  *Ispisuje sve zadate kombinacije STV+MES+BRD+VRS(mat)*
  DO WHILE m_stv=stv.AND.m_mes=mes.AND.m_dok=brd.AND.m_mat=vrs
    m_osu=osu
    IF aa=0
      @ 1,25SAY "MAT-"+tab[vrs]+"    DOKUMENT"+STR(brd,5)
      @ 2,1 SAY "Stovariste : "+STR(stv,3)+"                                                      "+DTOC(DATE())
      @ 3,1 SAY "-------------------------------------------------------------------------------"
      @ 4,1 SAY "D-S-P  MS OS  ARTIKAL    KOLICINA        NAZIV                              JMR"
      @ 5,1 SAY "-------------------------------------------------------------------------------"
      aa=1
    ENDIF
    *Bila je ideja za mesec, ali ovo je uvek "0" (moze se i brisati)*
    IF mss=0
      m_kst=kst/1000
      @ red,1 SAY STR(dob,6)+" "+STR(mes,2)+" "+m_osu+" "+STR(art,10)+" "+STR(m_kst,9,3)
      SELECT 1
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
      @ red,35 SAY m_nza+m_jmr
      *Ispis broja motora*
      IF B->ost # " "
        red=red+1
        @ red,22 SAY "Broj motora : "+B->ost
      ENDIF
      red=red+1
      *Kraj stranice*
      IF red > 22
        red=6
        aa=0
        @ 23,1 SAY "Pritisni bilo sta za listanje !"
        INKEY(0)
        @ 7,0 CLEAR TO 23,79
      ENDIF
    ENDIF
    *Promena sloga u promenama*
    SELECT 2
    SKIP
    IF EOF()
      EXIT
    ENDIF
    m_art=art
    LOOP
  ENDDO
  @ 23,5 SAY "Nema vise podataka !"
  @ 23,50 SAY "  "
  INKEY(0)
  EXIT
ENDDO
*Upit za stampu*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
*Izabrano stampanje*
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  aa=0
  red=6
  INKEY(0)
  *Printer nije prikljucen*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  USE Matc INDEX matcid
  SELECT 2
  USE Prom INDEX promid
  @ 15,9 CLEAR
  *Petlja za stampanje*
  DO WHILE .T.
    SET DEVICE TO PRINT
    * SET PRINTER TO STAMPA
    SEEK STR(m_stv,3)+STR(m_mes,2)+STR(m_dok,5)+STR(m_mat,2)
    m_art=art
    CLEAR SCREEN
    DO WHILE m_stv=stv.AND.m_mes=mes.AND.m_dok=brd.AND.m_mat=vrs
      m_osu=osu
      IF aa=0
        @ 1,25SAY "MAT-"+tab[vrs]+"    DOKUMENT"+STR(brd,5)
        @ 2,1 SAY "Stovariste : "+STR(stv,3)+"                                                      "+DTOC(DATE())
        @ 3,1 SAY "-------------------------------------------------------------------------------"
        @ 4,1 SAY "D-S-P  MS OS  ARTIKAL    KOLICINA        NAZIV                              JMR"
        @ 5,1 SAY "-------------------------------------------------------------------------------"
        aa=1
      ENDIF
      IF mss=0
        m_kst=kst/1000
        @ red,1 SAY STR(dob,6)+" "+STR(mes,2)+" "+m_osu+" "+STR(art,10)+" "+STR(m_kst,9,3)
        SELECT 1
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
        @ red,35 SAY m_nza+m_jmr
        *Polje "ost" sadrzi broj motora i stovariste*
        IF B->ost # " "
          red=red+1
          @ red,22 SAY "Broj motora : "+B->ost
        ENDIF
        red=red+1
        IF red > 54
          red=6
          aa=0
        ENDIF
      ENDIF
      *Uzima sledeci artikal sa zadatom kombinacijom iz PROM.DBF*
      SELECT 2
      SKIP
      IF EOF()
        EXIT
      ENDIF
      m_art=art
      LOOP
    ENDDO
    EXIT
  ENDDO
ENDIF
SET CONFIRM OFF
SET DEVICE TO SCREEN
CLEAR SCREEN
CLOSE DATABASES
RETURN





*************************************
PROCEDURE s_dok
* S_DOK.PRG STAMPA ODREDJENOG DOKUMENTA
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_DOK"
@ 2,25 SAY "ODREDJENI DOKUMENT"
@ 2,61 SAY "''ESC''  za kraj"
*Promenljive*
m_stv=0
m_art=0
m_dok=0
m_mes=0
m_kst=0
m_nza=SPACE(42)
m_jmr=SPACE(3)
m_knt=0
aa=0
red=7
m_vrs=SPACE(27)
m_dob=SPACE(6)
m_znk=" "
m_odl="N"
*Matrica matova*
DECLARE tab[30]
tab[1]="01"
tab[2]="02"
tab[3]="03"
tab[4]="04"
tab[5]="05"
tab[9]="09"
tab[10]="10"
tab[11]="11"
tab[12]="12"
tab[13]="13"
tab[14]="14"
tab[20]="20"
tab[21]="21"
tab[23]="23"
tab[24]="24"
tab[30]="30"
*Matrica jedinice mere*
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
*Zaglavlje*
@  6,1 SAY "Izgled liste :"
@  7,1 SAY "                  DOKUMENT MAT - xx"
@  8,1 SAY "Stovariste : xxx"
@  9,1 SAY "Artikal    : xxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xx xxxxxxx "
@ 10,1 SAY "------------------------------------------------------------------------------"
@ 11,1 SAY " DATUM   VRS  OSN  DOBAVLJAC             BRD  MES  KOLICINA"
@ 12,1 SAY "------------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Matc INDEX matcid
GO TOP
SELECT 2
USE Prom INDEX promvd
GO TOP
@ 15,9 CLEAR
DO WHILE .T.
  *Uzimanje podataka*
  @ 14,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 16,10 SAY "Sifra ARTIKLA     : " GET m_art PICTURE "9999999999";
          VALID(m_art>0)
  @ 18,10 SAY "Dokument   :  MAT - " GET m_dok PICTURE "99";
          VALID(m_dok>0)
  *Mesec je 99, ako je nova sifra*
  @ 18,38 SAY "MESEC : " GET m_mes PICTURE "99";
          VALID((m_mes>0 .AND. m_mes<13) .OR. m_mes=99)
  @ 18,55 SAY "99 - za sve mesece !"
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  SEEK m_art
  IF FOUND()
    IF jmr="  "
      m_nza="Nepoznat naziv ?                          "
      m_jmr="   "
      m_knt=0
    ELSE
      m_nza=nza
      m_jmr=taj[VAL(jmr)]
      m_knt=knt
    ENDIF
  ELSE
    m_nza="Nepoznat naziv ?                          "
    m_jmr="   "
    m_knt=0
  ENDIF
  SELECT 2
  IF m_mes < 99
    SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_dok,2)+STR(m_mes,2)
  ELSE
    SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_dok,2)
  ENDIF
  IF ! FOUND()
    *Mesec je 99, ako je nova sifra*
    IF m_mes < 99
      @ 22,1 SAY "Tog STV-ART-DOK-MES nema u promenama !"
    ELSE
      @ 22,1 SAY "Tog STV-ART-DOK nema u promenama !"
    ENDIF
    INKEY(3)
    @ 22,1 SAY "                                      "
    m_stv=0
    m_art=0
    m_dok=0
    m_mes=0
    LOOP
  ENDIF
  CLEAR SCREEN
  DO WHILE m_art=art.AND.m_dok=vrs.AND. ! EOF()
    IF aa=0
      *Izbor dokumenta*
      DO CASE
        CASE vrs=01
          m_vrs="PRIJEM MATERIJALA          "
          m_dob="DOBAVLJAC     "
        CASE vrs=02
          m_vrs="POVRATNICA                 "
          m_dob="SEKTOR,SEKCIJA"
        CASE vrs=03
          m_vrs="KASACIJA OSNOVNIH SREDSTAVA"
          m_dob="SEKTOR,SEKCIJA"
        CASE vrs=04
          m_vrs="RASHODOVANJE SIT. INVENTARA"
          m_dob="SEKTOR,SEKCIJA"
        CASE vrs=05
          m_vrs="SPISAK VISKA               "
          m_dob="SEKTOR,SEKCIJA"
        CASE vrs=09
          m_vrs="TREBOVANJE                 "
          m_dob="SEKTOR,SEKCIJA"
        CASE vrs=10
          m_vrs="IZVADNICA                  "
          m_dob="SEKTOR,SEKCIJA"
        CASE vrs=11
          m_vrs="IZVADNICA ZA GORIVO,MAZIVO "
          m_dob="SERIJA I BROJ "
        CASE vrs=12
          m_vrs="OTPREMNICA                 "
          m_dob="PRIMALAC      "
        CASE vrs=13
          m_vrs="SPISAK MANJKA              "
          m_dob="SEKTOR,SEKCIJA"
        CASE vrs=14
          m_vrs="PREDLOG ZA RASHODOVANJE    "
          m_dob="SEKTOR,SEKCIJA"
        CASE vrs=20
          m_vrs="SPROVODNICA                "
          m_dob="    STOVARISTE"
        CASE vrs=21
          m_vrs="DOSTAVNICA                 "
          m_dob=" PRIMALAC     "
        CASE vrs=23
          m_vrs="PREDAJA NA ODRADU,,,       "
          m_dob="IZVODJAC      "
        CASE vrs=24
          m_vrs="PRIJEM SA OBRADE,,,        "
          m_dob="DOBAVLJAC     "
        CASE vrs=30
          m_vrs="POCETNO STANJE             "
          m_dob="DOBAVLJAC     "
      ENDCASE
      *Zaglavlje*
      @ 1,25SAY "MAT-"+tab[vrs]+"   "+m_vrs
      @ 2,1 SAY "Stovariste : "+STR(stv,3)
      @ 3,1 SAY "Artikal    : "+STR(art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)
      @ 4,1 SAY "------------------------------------------------------------------------------"
      @ 5,1 SAY " DATUM   VRS OSN "+m_dob+"                    BRD MES       KOLICINA"
      @ 6,1 SAY "------------------------------------------------------------------------------"
      aa=1
    ENDIF
    IF mss=0
      *Leva ili desna strana mata 24*
      IF vrs=24 .AND. (osu="00" .OR. osu="01")
        m_znk="L"
      ELSEIF vrs=24
        m_znk="D"
      ENDIF
      m_kst=kst/1000
      *Kod Mat:01,12,21,23 i 24, ispisuje ime, a kod drugih sifru*
      IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
        @ red,1  SAY DTOC(dat)+"  "+tab[vrs]+m_znk+" "+osu+" "+dom+" "+STR(brd,5)+"  "+STR(mes,2)
      ELSE
        @ red,1  SAY DTOC(dat)+"  "+tab[vrs]+m_znk+" "+osu+" "+STR(dob)
        @ red,49 SAY STR(brd,5)+"  "+STR(mes,2)
      ENDIF
      @ red,65 SAY STR(m_kst,9,3)
      IF ost # " "
        red=red+1
        @ red,45 SAY "Broj motora : "+ost
      ENDIF
      red=red+1
    ENDIF
    *Kraj reda*
    IF red = 23
      red=7
      aa=0
      @ 23,1 SAY "Pritisni bilo sta za listanje !"
      INKEY(0)
      @ 7,0 CLEAR TO 23,79
    ENDIF
    SKIP
    *Sa "99" se obelezava neispravan slog*
    IF m_mes<99
      IF mes<>m_mes
        EXIT
      ENDIF
    ENDIF
    LOOP
  ENDDO
  @ red,35 SAY "  "
  EXIT
ENDDO
*Upit za stampu*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  aa=0
  red=7
  INKEY(0)
  *Nema printera*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  USE Matc INDEX matcid
  GO TOP
  SELECT 2
  USE Prom INDEX promvd
  GO TOP
  *Petlja za stampu*
  DO WHILE .T.
    SET DEVICE TO PRINT
    * SET PRINTER TO STAMPA
    *Pretraga*
    IF m_mes < 99
      SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_dok,2)+STR(m_mes,2)
    ELSE
      SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_dok,2)
    ENDIF
    DO WHILE m_art=art.AND.m_dok=vrs.AND. ! EOF()
      *Prvi ispis stranice*
      IF aa=0
        DO CASE
          *Ispis poruke zavisno od Mat obrasca*
          CASE vrs=01
            m_vrs="PRIJEM MATERIJALA          "
            m_dob="DOBAVLJAC     "
          CASE vrs=02
            m_vrs="POVRATNICA                 "
            m_dob="SEKTOR,SEKCIJA"
          CASE vrs=03
            m_vrs="KASACIJA OSNOVNIH SREDSTAVA"
            m_dob="SEKTOR,SEKCIJA"
          CASE vrs=04
            m_vrs="RASHODOVANJE SIT. INVENTARA"
            m_dob="SEKTOR,SEKCIJA"
          CASE vrs=05
            m_vrs="SPISAK VISKA               "
            m_dob="SEKTOR,SEKCIJA"
          CASE vrs=09
            m_vrs="TREBOVANJE                 "
            m_dob="SEKTOR,SEKCIJA"
          CASE vrs=10
            m_vrs="IZVADNICA                  "
            m_dob="SEKTOR,SEKCIJA"
          CASE vrs=11
            m_vrs="IZVADNICA ZA GORIVO,MAZIVO "
            m_dob="SERIJA I BROJ "
          CASE vrs=12
            m_vrs="OTPREMNICA                 "
            m_dob="PRIMALAC      "
          CASE vrs=13
            m_vrs="SPISAK MANJKA              "
            m_dob="SEKTOR,SEKCIJA"
          CASE vrs=14
            m_vrs="PREDLOG ZA RASHODOVANJE    "
            m_dob="SEKTOR,SEKCIJA"
          CASE vrs=20
            m_vrs="SPROVODNICA                "
            m_dob="    STOVARISTE"
          CASE vrs=21
            m_vrs="DOSTAVNICA                 "
            m_dob=" PRIMALAC     "
          CASE vrs=23
            m_vrs="PREDAJA NA ODRADU,,,       "
            m_dob="IZVODJAC      "
          CASE vrs=24
            m_vrs="PRIJEM SA OBRADE,,,        "
            m_dob="DOBAVLJAC     "
          CASE vrs=30
            m_vrs="POCETNO STANJE             "
            m_dob="DOBAVLJAC     "
        ENDCASE
        *Ispis zaglavlja*
        @ 1,25SAY "MAT-"+tab[vrs]+"   "+m_vrs
        @ 2,1 SAY "Stovariste : "+STR(stv,3)
        @ 3,1 SAY "Artikal    : "+STR(art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)
        @ 4,1 SAY "------------------------------------------------------------------------------"
        @ 5,1 SAY " DATUM   VRS OSN "+m_dob+"                    BRD MES       KOLICINA"
        @ 6,1 SAY "------------------------------------------------------------------------------"
        aa=1
      ENDIF
      IF mss=0
        IF vrs=24 .AND. (osu="00" .OR. osu="01")
          m_znk="L"
        ELSEIF vrs=24
          m_znk="D"
        ENDIF
        m_kst=kst/1000
        IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
          @ red,1  SAY DTOC(dat)+"  "+tab[vrs]+m_znk+" "+osu+" "+dom+" "+STR(brd,5)+"  "+STR(mes,2)
        ELSE
          @ red,1  SAY DTOC(dat)+"  "+tab[vrs]+m_znk+" "+osu+" "+STR(dob)
          @ red,49 SAY STR(brd,5)+"  "+STR(mes,2)
        ENDIF
        @ red,65 SAY STR(m_kst,9,3)
        IF ost # " "
          red=red+1
          @ red,45 SAY "Broj motora : "+ost
        ENDIF
        red=red+1
      ENDIF
      IF red = 60
        red=7
        aa=0
      ENDIF
      SKIP
      IF m_mes<99
        IF mes<>m_mes
          EXIT
        ENDIF
      ENDIF
      LOOP
    ENDDO
    @ red,35 SAY "  "
    EXIT
  ENDDO
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN



*******************************
PROCEDURE s_kar
* S_KAR.PRG KARTA MATERIJALA
*Stampanje karte materijala - kretanje ispisa gore-dole po ekranu*
SET CONFIRM ON
CLEAR SCREEN
*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_KAR"
@ 2,25 SAY "KARTA MATERIJALA"
@ 2,61 SAY "''ESC'' za kraj"
*Pravi novu pomocnu bazu za ispis kretanjem*
ERASE tpom.dbf
IF ! FILE("tpom.dbf")
  CREATE ptpom
  STORE "dat       c8  " TO polje10
  STORE "vrs       c2  " TO polje11
  STORE "osn       c2  " TO polje12
  STORE "ozn       c1  " TO polje13
  STORE "brd       c5  " TO polje14
  STORE "mes       c2  " TO polje15
  STORE "dob       c20 " TO polje16
  STORE "ula       c11 " TO polje17
  STORE "izl       c11 " TO polje18
  STORE "sta       c11 " TO polje19
  FOR i=10 TO 19
    STORE STR(i,2) TO broj
    APPEND BLANK
    STORE "polje"+broj TO p1
    REPLACE field_name WITH SUBSTR(&p1,1,10)
    REPLACE field_type WITH SUBSTR(&p1,11,1)
    REPLACE field_len WITH VAL(SUBSTR(&p1,12,2))
    REPLACE field_dec WITH VAL(SUBSTR(&p1,14,1))
  NEXT
  CREATE tpom FROM ptpom
  ERASE ptpom.dbf
ENDIF
CLOSE DATABASES
*Postavka promenljivih*
m_stv=0
m_art=0
m_kst=0
m_pst=0
m_nza=SPACE(42)
m_jmr=SPACE(3)
m_pit=SPACE(70)
m_dat=SPACE(8)
m_vrs=SPACE(2)
m_osn=SPACE(2)
m_brd=SPACE(5)
m_knt=0
m_ula=0
m_izl=0
m_sta=0
m_mes=0
m_mec=0
m_uk1=0
m_uk2=0
c_ula=SPACE(11)
c_izl=SPACE(11)
m_sel=0
m_i24=" "
red=8
br=0
m_odl="N"
aa=0
pp=0
pol=SPACE(20)
*Matrica osnova*
DECLARE tak[7]
tak[1]="Novo               "
tak[2]="Polovno            "
tak[3]="Zastarelo - novo   "
tak[4]="Zastarelo - polovno"
tak[5]="Obrada,,, - novo   "
tak[6]="Obrada,,, - polovno"
tak[7]="Upotreba           "
DECLARE tav[1000]
*Jedinica mere*
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
*OUR-i*
DECLARE tss[9]
tss[1]="199"
tss[2]="299"
tss[3]="399"
tss[4]="499"
tss[5]="599"
tss[6]="699"
tss[7]="799"
tss[8]="899"
tss[9]="988"
*Sektori*
DECLARE tas[9]
tas[1]="Sektor STP "
tas[2]="Sektor VV  "
tas[3]="Sektor ZOP "
tas[4]="Sektor ETP "
tas[5]="Sektor ZOVS"
tas[6]="Sektor UPR "
tas[7]="Sektor COK "
tas[8]="Sektor NAB "
tas[9]="Sektor DRS "
*Zaglavlje*
@  6,1 SAY "Izgled liste :"
@  7,1 SAY "                           KARTA MATERIJALA                           MAT-56 B"
@  8,1 SAY "Stovariste : xxx               DATUM                       STANJE : xxxxxxxxxx"
@  9,1 SAY "Artikal    : xxxxxxxxxx  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xx xxxxxxx"
@ 10,1 SAY "------------------------------------------------------------------------------"
@ 11,1 SAY " DATUM   VRS OSN  BRDDOBAVLJAC-KORISNIK-STOVARISTE    ULAZ    IZLAZ     STANJE"
@ 12,1 SAY "------------------------------------------------------------------------------"
*Radna polja*
SELECT 4
USE Tpom
GO TOP
SELECT 1
USE Stan INDEX stansd
GO TOP
SELECT 2
USE Matc INDEX matcid
GO TOP
SELECT 3
USE Prom INDEX promdd
GO TOP
@ 15,9 CLEAR
DO WHILE .T.
  *Unos podataka za pretragu*
  @ 14,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 16,10 SAY "Sifra ARTIKLA     : " GET m_art PICTURE "9999999999";
          VALID(m_art>0)
  @ 18,10 SAY "Selekcija         : " GET m_sel PICTURE "9";
          VALID(m_sel>0)
  @ 20,10 SAY "Mesec             : " GET m_mec PICTURE "99"
  @ 21,10 SAY "Unesi mesec ili nista !"
  *Osnovi*
  @ 17,50 SAY "1 - Novo"
  @ 18,50 SAY "2 - Polovno"
  @ 19,50 SAY "3 - Zastarelo - novo"
  @ 20,50 SAY "4 - Zastarelo - polovno"
  @ 21,50 SAY "5 - Obrada ,,, - novo"
  @ 22,50 SAY "6 - Obrada ,,, - polovno"
  @ 23,50 SAY "2 - Upotreba"
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  USE Stan INDEX stansd
  GO TOP
  *Pretraga na stanju*
  SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_sel,1)
  IF ! FOUND()
    @ 22,1 SAY "Tog STOVARISTA-ARTIKLA-KONTA nema na stanju !"
    INKEY(3)
    @ 22,1 SAY "                                             "
    m_stv=0
    m_art=0
    m_sel=0
    m_mec=0
    LOOP
  ENDIF
  m_kst=kst/1000
  m_pst=pst/1000
  m_sta=pst
  m_knt=knt
  *Proverava artkal u maticnoj*
  SELECT 2
  USE Matc INDEX matcid
  GO TOP
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
  *Pretrazuje u promenama (dokument)*
  SELECT 3
  USE Prom INDEX promdd
  GO TOP
  IF m_mec=0
    SEEK STR(m_stv,3)+STR(m_art,10)
  ELSE
    SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_mec,2)
  ENDIF
  IF ! FOUND()
    @ 22,1 SAY "Tog STOVARISTA-ARTIKLA-MESECA nema u promenama !"
    INKEY(3)
    @ 22,1 SAY "                                                "
    LOOP
  ENDIF
  CLEAR SCREEN
  *Ispis*
  DO WHILE m_stv=stv .AND. m_art=art .AND. ! EOF()
    *Ispis nove stranice*
    IF aa=0
      @ 1,1 SAY "                      KARTA MATERIJALA - "+tak[m_sel]+"         MAT-56 B"
      @ 2,1 SAY "Stovariste : "+STR(stv,3)+"      Datum : "+DTOC(DATE())+"                    STANJE :"+STR(m_kst,11,3)
      @ 3,1 SAY "Artikal    : "+STR(art,10)+" "+m_nza+m_jmr+" "+STR(m_knt,7)
      @ 4,1 SAY "------------------------------------------------------------------------------"
      @ 5,1 SAY " DATUM   VK OSN  BRD  MES DOBAV.-KORISN.-STOVAR.    ULAZ      IZLAZ     STANJE"
      @ 6,1 SAY "------------------------------------------------------------------------------"
      IF pp = 0
        @ 7,52 SAY "Pocetno stanje :"+STR(m_pst,11,3)
        pp=1
      ENDIF
      aa=1
    ENDIF
    IF mss=0
      DO CASE
        *Dvocifrena sifra (novo, polovno, obrada-dorada, ...)*
        CASE m_sel=1
          *Kombinacije osnova i broja dokumenta (VK)*
          IF osu="00" .AND. vrs#09
            IF vrs=24
              m_i24="L"
            ENDIF
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="05" .AND. vrs#09
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="10" .AND. vrs#24 .AND. brd<4000
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="10" .AND. vrs=20 .AND. brd>4000
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="12" .AND. vrs=10
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="17" .AND. vrs=10
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSEIF osu="15" .AND. vrs#24 .AND. brd<4000
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSEIF osu="15" .AND. vrs=20 .AND. brd>4000
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=2
          IF osu="01"
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="06"
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="11" .AND. vrs=20 .AND. brd>4000
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="11" .AND. vrs#24
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="12"
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="16" .AND. vrs=20 .AND. brd>4000
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="16" .AND. vrs#24
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSEIF osu="17"
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=3
          IF osu="03"
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="08"
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="13"
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="18"
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=4
          IF osu="04"
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="09"
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="14"
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="19"
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=5
          IF osu="10" .AND. vrs=23
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="15" .AND. vrs=23
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="10" .AND. vrs=24
            m_i24="D"
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="15" .AND. vrs=24
            m_i24="D"
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSE
            SKIP
            LOOP
          ENDIF
        CASE m_sel=6
          IF osu="11" .AND. vrs=23
            m_ula=kst
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="16" .AND. vrs=23
            m_ula=kst*(-1)
            m_izl=0
            m_sta=m_sta+m_ula
          ELSEIF osu="11" .AND. vrs=24
            m_i24="D"
            m_ula=0
            m_izl=kst
            m_sta=m_sta-m_izl
          ELSEIF osu="16" .AND. vrs=24
            m_i24="D"
            m_ula=0
            m_izl=kst*(-1)
            m_sta=m_sta-m_izl
          ELSE
            SKIP
            LOOP
          ENDIF
      ENDCASE
      m_mes=mes
      m_dat=DTOC(dat)
      m_vrs=STR(vrs,2)
      m_osn=osu
      m_brd=STR(brd,5)
      *Upis podataka u TPOM.DBF prema trazenom*
      SELECT 4
      USE tpom
      APPEND BLANK
      REPLACE dat WITH m_dat, vrs WITH m_vrs, osn WITH m_osn
      REPLACE ozn WITH m_i24, brd WITH STR(C->brd,5), mes WITH STR(m_mes,2)
      SELECT 3
      pol=STR(dob,6)
      *Trazi OUR*
      FOR i = 1 TO 9
        IF SUBSTR(STR(dob),1,3)=tss[i]
          pol=tas[i]
        ENDIF
      NEXT
      IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
        pol=SUBSTR(dom,1,20)
      ENDIF
      IF vrs=20
        pol=STR(dob,6)
      ENDIF
      SELECT 4
      REPLACE dob WITH pol
      *Ulaz - krajnje stanje*
      SELECT 3
      IF m_ula=0
        c_ula="        ---"
      ELSE
        c_ula=STR(m_ula/1000,11,3)
        m_uk1=m_uk1+m_ula/1000
      ENDIF
      IF m_izl=0
        c_izl="        ---"
      ELSE
        c_izl=STR(m_izl/1000,11,3)
        m_uk2=m_uk2+m_izl/1000
      ENDIF
      m_sta=m_sta/1000
      SELECT 4
      *Upisuje ulaz, izlaz i stanje*
      REPLACE ula WITH c_ula, izl WITH c_izl, sta WITH STR(m_sta,11,3)
      SELECT 3
      m_sta=m_sta*1000
      pol=SPACE(20)
      m_i24=" "
      red=red+1
      br=br+1
    ENDIF
    SKIP
    *Uneta je vrednost meseca*
    IF m_mec#0
      IF m_mec=mes
        LOOP
      ELSE
        EXIT
      ENDIF
    ENDIF
    LOOP
  ENDDO
  SELECT 4
  *TPOM.DBF je pomocna baza za kretanje ekranom*
  USE tpom
  GO TOP
  SET CURSOR OFF
  red=8
  brr=1
  rrr=0
  *Ispis sa kretanjem*
  DO WHILE .T.
    @ red,1  SAY dat+" "+vrs+" "+osn+" "+ozn+brd+" "+mes+"  "+dob
    @ red,46 SAY ula+izl+sta
    SKIP
    IF EOF()
      rrr=1
      @ 23,1 SAY "Nema vise podataka"
      INKEY(0)
      @ 23,1 SAY "                  "
      IF LASTKEY()=27
        EXIT
      ENDIF
    ENDIF
    red=red+1
    IF red=22
      @ 23,55 SAY "Gore , Dole , Kraj ESC"
      INKEY(0)
      IF LASTKEY()=24 .AND. rrr=1
        red=8
        rrr=0
        GO brr
        LOOP
      ELSEIF LASTKEY()=24
        rrr=0
        red=8
        brr=brr+1
        GO brr
        LOOP
      ELSEIF LASTKEY()=5
        brr=brr-1
        IF brr=0
          brr=1
          @ 23,1 SAY "Na vrhu si !"
          INKEY(2)
          @ 23,1 SAY "            "
        ENDIF
        rrr=0
        red=8
        GO brr
        LOOP
      ELSE
        IF LASTKEY()=27
          EXIT
        ENDIF
        @ 23,1 SAY "Pogresno dugme !"
        INKEY(2)
        @ 23,1 SAY "                "
        rrr=0
        red=8
        GO brr
        LOOP
      ENDIF
    ENDIF
  ENDDO
  EXIT
ENDDO
*Stampa*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  m_ula=0
  m_izl=0
  c_ula=SPACE(11)
  c_izl=SPACE(11)
  m_sta=0
  m_mes=0
  m_knt=0
  m_uk1=0
  m_uk2=0
  aa=0
  pp=0
  red=8
  INKEY(0)
  *Proverava da li je prikljucen printer*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  *Postavka radnih polja*
  SELECT 1
  USE Stan INDEX stansd
  GO TOP
  SELECT 2
  USE Matc INDEX matcid
  GO TOP
  SELECT 3
  USE Prom INDEX promdd
  GO TOP
  *Ispis na printeru*
  DO WHILE .T.
    SET DEVICE TO PRINT
    *SET PRINTER TO STAMPA*
    SELECT 1
    USE Stan INDEX stansd
    GO TOP
    SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_sel,1)
    m_kst=kst/1000
    m_pst=pst/1000
    m_sta=pst
    m_knt=knt
    CLEAR SCREEN
    SELECT 2
    USE Matc INDEX matcid
    GO TOP
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
    SELECT 3
    USE Prom INDEX promdd
    GO TOP
    IF m_mec=0
      SEEK STR(m_stv,3)+STR(m_art,10)
    ELSE
      SEEK STR(m_stv,3)+STR(m_art,10)+STR(m_mec,2)
    ENDIF
    *Ispis dok vazi zadata kombinacija*
    DO WHILE m_stv=stv .AND. m_art=art .AND. ! EOF()
      *Ispis zaglavlja pri novom ispisu stranice*
      IF aa=0
        @ 1,1 SAY "                      KARTA MATERIJALA - "+tak[m_sel]+"         MAT-56 B"
        @ 2,1 SAY "Stovariste : "+STR(stv,3)+"      Datum : "+DTOC(DATE())+"                    STANJE :"+STR(m_kst,11,3)
        @ 3,1 SAY "Artikal    : "+STR(art,10)+" "+m_nza+m_jmr+" "+STR(m_knt,7)
        @ 4,1 SAY "------------------------------------------------------------------------------"
        @ 5,1 SAY " DATUM   VK OSN  BRD  MES DOBAV.-KORISN.-STOVAR.    ULAZ      IZLAZ     STANJE"
        @ 6,1 SAY "------------------------------------------------------------------------------"
        IF pp = 0
          @ 7,52 SAY "Pocetno stanje :"+STR(m_pst,11,3)
          pp=1
        ENDIF
        aa=1
      ENDIF
      IF mss=0
        DO CASE
          *Izbor oznake (novo, polovno, dorada, ...)*
          CASE m_sel=1
            *Kombinacija osnova i vrste dokumenta*
            IF osu="00" .AND. vrs#09
              IF vrs=24
                m_i24="L"
              ENDIF
              m_ula=kst
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="05" .AND. vrs#09
              m_ula=kst*(-1)
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="10" .AND. vrs#24 .AND. brd<4000
              m_ula=0
              m_izl=kst
              m_sta=m_sta-m_izl
            ELSEIF osu="10" .AND. vrs=20 .AND. brd>4000
              m_ula=kst
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="12" .AND. vrs=10
              m_ula=0
              m_izl=kst
              m_sta=m_sta-m_izl
            ELSEIF osu="17" .AND. vrs=10
              m_ula=0
              m_izl=kst*(-1)
              m_sta=m_sta-m_izl
            ELSEIF osu="15" .AND. vrs#24 .AND. brd<4000
              m_ula=0
              m_izl=kst*(-1)
              m_sta=m_sta-m_izl
            ELSEIF osu="15" .AND. vrs=20 .AND. brd>4000
              m_ula=kst*(-1)
              m_izl=0
              m_sta=m_sta+m_ula
            ELSE
              SKIP
              LOOP
            ENDIF
          CASE m_sel=2
            IF osu="01"
              m_ula=kst
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="06"
              m_ula=kst*(-1)
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="11" .AND. vrs=20 .AND. brd>4000
              m_ula=kst
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="11" .AND. vrs#24
              m_ula=0
              m_izl=kst
              m_sta=m_sta-m_izl
            ELSEIF osu="12"
              m_ula=kst
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="16" .AND. vrs=20 .AND. brd>4000
              m_ula=kst*(-1)
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="16" .AND. vrs#24
              m_ula=0
              m_izl=kst*(-1)
              m_sta=m_sta-m_izl
            ELSEIF osu="17"
              m_ula=kst*(-1)
              m_izl=0
              m_sta=m_sta+m_ula
            ELSE
              SKIP
              LOOP
            ENDIF
          CASE m_sel=3
            IF osu="03"
              m_ula=kst
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="08"
              m_ula=kst*(-1)
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="13"
              m_ula=0
              m_izl=kst
              m_sta=m_sta-m_izl
            ELSEIF osu="18"
              m_ula=0
              m_izl=kst*(-1)
              m_sta=m_sta-m_izl
            ELSE
              SKIP
              LOOP
            ENDIF
          CASE m_sel=4
            IF osu="04"
              m_ula=kst
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="09"
              m_ula=kst*(-1)
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="14"
              m_ula=0
              m_izl=kst
              m_sta=m_sta-m_izl
            ELSEIF osu="19"
              m_ula=0
              m_izl=kst*(-1)
              m_sta=m_sta-m_izl
            ELSE
              SKIP
              LOOP
            ENDIF
          CASE m_sel=5
            IF osu="10" .AND. vrs=23
              m_ula=kst
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="15" .AND. vrs=23
              m_ula=kst*(-1)
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="10" .AND. vrs=24
              m_i24="D"
              m_ula=0
              m_izl=kst
              m_sta=m_sta-m_izl
            ELSEIF osu="15" .AND. vrs=24
              m_i24="D"
              m_ula=0
              m_izl=kst*(-1)
              m_sta=m_sta-m_izl
            ELSE
              SKIP
              LOOP
            ENDIF
          CASE m_sel=6
            IF osu="11" .AND. vrs=23
              m_ula=kst
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="16" .AND. vrs=23
              m_ula=kst*(-1)
              m_izl=0
              m_sta=m_sta+m_ula
            ELSEIF osu="11" .AND. vrs=24
              m_i24="D"
              m_ula=0
              m_izl=kst
              m_sta=m_sta-m_izl
            ELSEIF osu="16" .AND. vrs=24
              m_i24="D"
              m_ula=0
              m_izl=kst*(-1)
              m_sta=m_sta-m_izl
            ELSE
              SKIP
              LOOP
            ENDIF
        ENDCASE
        *uzima mesec iz baze*
        m_mes=mes
        *Ispis*
        @ red,1  SAY DTOC(dat)+" "+STR(vrs,2)+" "+osu+" "+m_i24+STR(brd,5)+" "+STR(m_mes,2)
        pol=STR(dob,6)
        *Trazi OUR*
        FOR i = 1 TO 9
          IF SUBSTR(STR(dob),1,3)=tss[i]
            pol=tas[i]
          ENDIF
        NEXT
        IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
          pol=SUBSTR(dom,1,20)
        ENDIF
        IF vrs=20
          pol=STR(dob,6)
        ENDIF
        @ red,27 SAY pol
        IF m_ula=0
          c_ula="        ---"
        ELSE
          c_ula=STR(m_ula/1000,11,3)
          m_uk1=m_uk1+m_ula/1000
        ENDIF
        IF m_izl=0
          c_izl="        ---"
        ELSE
          c_izl=STR(m_izl/1000,11,3)
          m_uk2=m_uk2+m_izl/1000
        ENDIF
        m_sta=m_sta/1000
        @ red,46 SAY c_ula+c_izl+STR(m_sta,11,3)
        m_sta=m_sta*1000
        pol=SPACE(20)
        m_i24=" "
        red=red+1
      ENDIF
      *Granicnik za kraj stranice*
      IF red > 58
        red=7
        aa=0
      ENDIF
      SKIP
      IF m_mec#0
        IF m_mec=mes
          LOOP
        ELSE
          EXIT
        ENDIF
      ENDIF
      LOOP
    ENDDO
    *Sabira ukupno*
    @ red,40 SAY "Ukupno"+STR(m_uk1,11,3)+STR(m_uk2,11,3)
    red=red+1
    @ red,46 SAY "  "
    EXIT
  ENDDO
ENDIF
*Vraca ispis na ekran*
SET DEVICE TO SCREEN
SET CONFIRM OFF
SET CURSOR ON
CLEAR SCREEN
CLOSE DATABASES
ERASE tpom.dbf
RETURN




**********************************
PROCEDURE s_naz
*Pregled naziva ako je poznat deo imena*
* S_NAZ.PRG STANJE SA DELOM NAZIVA ARTIKLA
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_NAZ.PRG"
@ 2,20 SAY "STANJE NOVOG SA DELOM NAZIVA ARTIKLA"
@ 2,61 SAY "''ESC'' za kraj"
@ 5,0 TO 22,79 DOUBLE
*Postavka promenljivih*
m_naz=SPACE(15)
m_art=SPACE(3)
p_art=0
p_nza=SPACE(42)
p_jmr=SPACE(2)
p_kst=0
m_kst=0
*Matrica sa mestima za eventualni deo naziva*
DECLARE m_n[14]
m_n[1] =SPACE(1)
m_n[2] =SPACE(2)
m_n[3] =SPACE(3)
m_n[4] =SPACE(4)
m_n[5] =SPACE(5)
m_n[6] =SPACE(6)
m_n[7] =SPACE(7)
m_n[8] =SPACE(8)
m_n[9] =SPACE(9)
m_n[10]=SPACE(10)
m_n[11]=SPACE(11)
m_n[12]=SPACE(12)
m_n[13]=SPACE(13)
m_n[14]=SPACE(14)
red=6
b=0
t=SPACE(1)
aa=0
an=0
at=0
bb=0
m_odl="N"
SELECT 2
USE Stan INDEX stanad
*Prihvatanje upisa podataka za pretragu*
DO WHILE .T.
  SELECT 1
  USE Matc INDEX matcid
  @ 10,8 SAY "Deo naziva ARTIKLA    : " GET m_naz PICTURE "@9";
          VALID(m_naz # " ")
  @ 11,8 SAY "Obavezno VELIKIM slovima i sa '*' na kraju !"
  @ 13,8 SAY "Pocetak sifre ARTIKLA : " GET m_art PICTURE "999";
          VALID(m_art # " ")
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    EXIT
  ENDIF
  *Trazi "*" - kraj znakovnog niza*
  FOR i = 1 TO 15
    t = SUBSTR(m_naz,i,1)
    IF t = "*"
      b=i-1
      EXIT
    ENDIF
  NEXT
  *Ako je "*" na prvom mestu (nije nista upisano)*
  IF SUBSTR(m_naz,1,1)="*"
    b=1
  *U petlji "FOR...", "b" nije dobilo vrednost*
  ELSEIF b = 0
    @ 10,50 SAY "Nisi stavio '*' na kraju !"
    INKEY(3)
    @ 10,50 SAY "                          "
    m_naz=SPACE(15)
    LOOP
  ENDIF
  *Ubacuje u matricu znakovni niz na mesto sa odgovarajucim brojem znakova*
  m_n[b] = SUBSTR(m_naz,1,b)
  *Radi do kraja*
  DO WHILE ! EOF()
    *Ako nadje prva 3 broja od artikla*
    IF SUBSTR(STR(art),1,3)=m_art
      at=1
    ELSE
      *Ako je artikal nadjen*
      IF at=1
        EXIT
      ENDIF
      SKIP
      LOOP
    ENDIF
    *Ako je "*" na prvom mestu*
    IF SUBSTR(m_naz,1,1)="*"
      an=1
      p_art=art
      p_nza=nza
      p_jmr=jmr
    ELSE
      *Polje za naziv artikla ima 42 karakterna mesta*
      FOR i = 1 TO (42-b)
        *Ako ga nadje*
        IF SUBSTR(nza,i,b) = m_n[b]
          an = 1
          p_art=art
          p_nza=nza
          p_jmr=jmr
        ENDIF
      NEXT
    ENDIF
    *Ako je nadjeno*
    IF an = 1
      an = 0
      bb = 1
      *Prvi ispis stranice*
      IF aa=0
        CLEAR SCREEN
        @ 1,12SAY "STANJE NOVOG NA OSNOVU DELA NAZIVA ARTIKLA"
        @ 2,1 SAY m_naz+" "+m_art+"*"+"                                         "+DTOC(DATE())
        @ 3,1 SAY "---------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL      NAZIV                                    JMR   KOLICINA"
        @ 5,1 SAY "---------------------------------------------------------------------"
        aa=1
      ENDIF
      SELECT 2
      SEEK STR(p_art,10)
      IF FOUND()
        *Sabira krajnje stanje*
        DO WHILE p_art=B->art .AND. kon=1
          m_kst=m_kst+B->kst
          SKIP
        ENDDO
        p_kst=m_kst/1000
        @ red,1 SAY STR(p_art,10)+" "+p_nza+"  "+p_jmr+" "+STR(p_kst,11,3)
      ELSE
        @ red,1 SAY STR(p_art,10)+" "+p_nza+"  "+p_jmr+"         ---"
      ENDIF
      m_kst=0
      red=red+1
      *Kraj ekrana*
      IF red=23
        @ 23,2 SAY "Pritisni bilo sta za listanje !"
        INKEY(0)
        red=6
        aa=0
        IF LASTKEY()=27
          EXIT
        ENDIF
      ENDIF
      SELECT 1
    ENDIF
    SKIP
  ENDDO
  *Nije nadjeno*
  IF bb = 0
    @ 23,2 SAY "Ne postoje sifre sa tim delom naziva !"
    INKEY(4)
    @ 23,2 SAY "                                      "
    an=0
    at=0
    b=0
    m_naz=SPACE(15)
    m_art=SPACE(3)
    SELECT 2
    GO TOP
    LOOP
  ENDIF
  @ 23,2 SAY "Nema vise podataka u banci !    "
  INKEY(0)
  EXIT
ENDDO
*Upit za stampanje*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  red=6
  b=0
  t=SPACE(1)
  aa=0
  an=0
  at=0
  bb=0
  INKEY(0)
  *Ako printer nije ukljucen*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SET DEVICE TO PRINTER
  * SET PRINTER TO STAMPA
  SELECT 1
  USE Matc INDEX matcid
  *Odredjuje mesto znaka "*" i broj znakova u nizu*
  FOR i = 1 TO 15
    t = SUBSTR(m_naz,i,1)
    IF t = "*"
      b=i-1
      EXIT
    ENDIF
  NEXT
  *Ako je "*" na prvom mestu*
  IF SUBSTR(m_naz,1,1)="*"
    b=1
  ENDIF
  m_n[b] = SUBSTR(m_naz,1,b)
  *Pretraga do kraja*
  DO WHILE ! EOF()
    *Ako nadje prva 3 broja sifre artikla*
    IF SUBSTR(STR(art),1,3)=m_art
      at=1
    ELSE
      IF at=1
        EXIT
      ENDIF
      SKIP
      LOOP
    ENDIF
    *Ako je "*" na prvom mestu*
    IF SUBSTR(m_naz,1,1)="*"
      an=1
      p_art=art
      p_nza=nza
      p_jmr=jmr
    ELSE
      FOR i = 1 TO (42-b)
        *Trazi da li u bilo kom delu naziva postoji data kombinacija znakova*
        IF SUBSTR(nza,i,b) = m_n[b]
          an = 1
          p_art=art
          p_nza=nza
          p_jmr=jmr
        ENDIF
      NEXT
    ENDIF
    *Ako je nadjeno*
    IF an = 1
      an = 0
      bb = 1
      *Prvi ispis stranice*
      IF aa=0
        @ 1,12SAY "STANJE NOVOG NA OSNOVU DELA NAZIVA ARTIKLA"
        @ 2,1 SAY m_naz+" "+m_art+"*"+"                                         "+DTOC(DATE())
        @ 3,1 SAY "---------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL      NAZIV                                    JMR   KOLICINA"
        @ 5,1 SAY "---------------------------------------------------------------------"
        aa=1
      ENDIF
      SELECT 2
      SEEK STR(p_art,10)
      *Ako je nadjeno*
      IF FOUND()
        *Sabira kolicinu*
        DO WHILE p_art=B->art .AND. kon=1
          m_kst=m_kst+B->kst
          SKIP
        ENDDO
        p_kst=m_kst/1000
        @ red,1 SAY STR(p_art,10)+" "+p_nza+"  "+p_jmr+" "+STR(p_kst,11,3)
      ELSE
        @ red,1 SAY STR(p_art,10)+" "+p_nza+"  "+p_jmr+"         ---"
      ENDIF
      m_kst=0
      red=red+1
      *Ako je kraj ispisa stranice*
      IF red=57
        red=6
        aa=0
      ENDIF
      SELECT 1
    ENDIF
    SKIP
  ENDDO
ENDIF
red=red+1
@ red,1 SAY "  "
SET CONFIRM OFF
SET DEVICE TO SCREEN
CLEAR SCREEN
CLOSE DATABASES
RETURN



*********************************
PROCEDURE s_nea
* S_NEA.PRG STAMPA NEAKTIVNIH STAVKI
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_NEA"
@ 2,25 SAY "STAMPA NEAKTIVNIH STAVKI"
@ 2,61 SAY "''ESC'' za kraj"
*Postavka promenljivih*
m_nza=0
m_jmr=SPACE(3)
m_stv=0
m_kst=0
m_knt=0
m_kon=0
m_per=0
aa=0
bb=0
d1=0
d2=0
d3=0
*Oznake - konta*
DECLARE tab[6]
tab[1]="Novo"
tab[2]="Polovno - Na upotrebi"
tab[3]="Nepotrebno - Zastarelo (novo)"
tab[4]="Nepotrebno - Zastarelo (polovno)"
tab[5]="Na obradi,,,(novo)"
tab[6]="Na obradi,,,(polovno)"
*Jedinica mere*
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
red=6
*Ispis zaglavlja*
@  6,1 SAY "Izgled izvestaja :"
@  7,1 SAY "                            NEAKTIVNE STAVKE"
@  8,1 SAY "Stovariste"
@  9,1 SAY "---------------------------------------------------------------------------"
@ 10,1 SAY " ARTIKAL    NAZIV                                    JMR  KONTO    KOLICINA"
@ 11,1 SAY "---------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Stan INDEX standd
GO TOP
SELECT 2
USE Matc INDEX matcid
GO TOP
@ 15,9 CLEAR
*Unos podataka*
DO WHILE .T.
  @ 13,8 SAY "STOVARISTE          : " GET m_stv PICTURE "999";
          VALID(m_stv > 0)
  @ 15,8 SAY "Period (u godinama) : " GET m_per PICTURE "9";
          VALID(m_per > 0)
  READ
  m_per=m_per+1
  *Izlazak*
  IF LASTKEY() = 27
    CLEAR SCREEN
    EXIT
  ENDIF
  SELECT 1
  USE Stan INDEX standd
  GO TOP
  SEEK STR(m_stv,3)
  *Nepostoji na stanju*
  IF ! FOUND()
    @ 21,1 SAY "To stovariste nije tvoje !"
    INKEY(3)
    m_stv=0
    @ 21,1 SAY "                          "
    LOOP
  ENDIF
  DO WHILE m_stv=stv
    *Uzima sistemski datum - godinu*
    d1=VAL(SUBSTR(DTOC(DATE()),7,2))
    *Uzima datum poslednje promene - godinu*
    d2=VAL(SUBSTR(DTOC(A->dat),7,2))
    *Uzima datum pocetnog stanja - godinu*
    d3=VAL(SUBSTR(DTOC(A->dap),7,2))
    *Ako odgovara period poslednje promene ili prvog unosa, a nema promene*
    IF (d1-d2=m_per) .OR. (DTOC(A->dat)=" " .AND. (d1-d3=m_per))
      bb=1
      *Prvi ispis - ispis zaglavlja*
      IF aa=0
        CLEAR SCREEN
        @ 1,10SAY "NEAKTIVNE STAVKE (nema ULAZ, nema IZLAZ) "+STR(m_per-1,1)+" god. i vise !"
        @ 2,1 SAY "Stovariste : "+STR(stv,3)+"                                                   "+DTOC(DATE())
        @ 3,1 SAY "----------------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL      NAZIV                                  JMR  KONTO     KOLICINA"
        @ 5,1 SAY "----------------------------------------------------------------------------"
        aa=1
      ENDIF
      m_kst=kst/1000
      m_knt=knt
      IF m_kon=kon
      *Ispis oznake - konta*
      ELSE
        @ red,13 SAY tab[kon]
        red=red+1
      ENDIF
      m_kon=kon
      SELECT 2
      USE Matc INDEX matcid
      GO TOP
      *Pretrazuje artikal u STAN.DBF*
      SEEK A->art
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
      @ red,1 SAY STR(A->art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(m_kst,10,3)
      red=red+1
      *Kraj ispisa na ekranu*
      IF red=23
        @ 23,2 SAY "Pritisni bilo sta za listanje !"
        INKEY(0)
        IF LASTKEY()=27
          CLEAR SCREEN
          SET CONFIRM OFF
          CLOSE DATABASES
          RETURN
        ENDIF
        red=6
        aa=0
      ENDIF
      SELECT 1
    ENDIF
    SKIP
  ENDDO
  *Nista nije nadjeno*
  IF bb = 0
    @ 23,2 SAY "Ne postoje neaktivne stavke !"
    INKEY(4)
    @ 23,2 SAY "                             "
    m_per=0
    LOOP
  ENDIF
  @ 23,2 SAY "Nema vise podataka u banci ! "
  INKEY(0)
  CLEAR SCREEN
  @ red,1 SAY "  "
  EXIT
ENDDO
SET CONFIRM OFF
CLOSE DATABASES
RETURN



***************************************
PROCEDURE s_neg
* S_NEG.PRG STAMPA STAVKI SA NEGATIVNIM STANJEM
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_NEG"
@ 2,25 SAY "STAMPA NEGATIVNIH STAVKI"
@ 2,61 SAY "''ESC'' za kraj"
*
m_nza=0
m_jmr=SPACE(3)
m_stv=0
m_kst=0
m_knt=0
m_kon=0
aa=0
bb=0
DECLARE tab[7]
tab[1]="Novo"
tab[2]="Polovno"
tab[3]="Nepotrebno - Zastarelo (novo)"
tab[4]="Nepotrebno - Zastarelo (polovno)"
tab[5]="Na obradi,,,(novo)"
tab[6]="Na obradi,,,(polovno)"
tab[7]="Upotreba"
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
red=6
*Zaglavlje*
@  6,1 SAY "Izgled izvestaja :"
@  7,1 SAY "                     STAVKE SE NEGATIVNIM STANJEM"
@  8,1 SAY "Stovariste"
@  9,1 SAY "---------------------------------------------------------------------------"
@ 10,1 SAY " ARTIKAL    NAZIV                                    JMR  KONTO    KOLICINA"
@ 11,1 SAY "---------------------------------------------------------------------------"
*
SELECT 1
USE Stan INDEX stankd
GO TOP
SELECT 2
USE Matc INDEX matcid
GO TOP
@ 15,9 CLEAR
DO WHILE .T.
  *Unos stovarista*
  @ 13,8 SAY "STOVARISTE             :  " GET m_stv PICTURE "999";
          VALID(m_stv > 0)
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    EXIT
  ENDIF
  SELECT 1
  USE Stan INDEX stankd
  GO TOP
  SEEK STR(m_stv,3)
  *Nije nadjeno*
  IF ! FOUND()
    @ 21,1 SAY "To stovariste nije tvoje !"
    INKEY(3)
    m_stv=0
    @ 21,1 SAY "                          "
    LOOP
  ENDIF
  *Ispisuje sve kombinacije za zadato stovariste*
  DO WHILE m_stv=stv
    *Krajnje stanje negativno - manje od 0*
    IF A->kst < 0
      bb=1
      *Prvi ispis - zaglavlje*
      IF aa=0
        CLEAR SCREEN
        @ 1,20SAY "STAVKE SA NEGATIVNIM STANJEM"
        @ 2,1 SAY "Stovariste : "+STR(stv,3)+"                                                   "+DTOC(DATE())
        @ 3,1 SAY "----------------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL      NAZIV                                  JMR  KONTO     KOLICINA"
        @ 5,1 SAY "----------------------------------------------------------------------------"
        aa=1
      ENDIF
      *Skida nule od decimala*
      m_kst=kst/1000
      m_knt=knt
      IF m_kon=kon
      *Vadi oznaku iz matrice (konto)*
      ELSE
        @ red,13 SAY tab[kon]
        red=red+1
      ENDIF
      m_kon=kon
      SELECT 2
      USE Matc INDEX matcid
      GO TOP
      *Trazi artikal na stanju*
      SEEK A->art
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
      @ red,1 SAY STR(A->art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(m_kst,10,3)
      red=red+1
      *Ispis je stigao do kraja ekrana*
      IF red=23
        @ 23,2 SAY "Pritisni bilo sta za listanje !"
        INKEY(0)
        *Izlaz - "Esc"*
        IF LASTKEY()=27
          CLEAR SCREEN
          SET CONFIRM OFF
          CLOSE DATABASES
          RETURN
        ENDIF
        red=6
        aa=0
      ENDIF
      SELECT 1
    ENDIF
    SKIP
  ENDDO
  *Nista nije nadjeno*
  IF bb = 0
    @ 23,2 SAY "Ne postoje stavke sa negativnom kolicinom !"
    INKEY(4)
    @ 23,2 SAY "                                           "
    LOOP
  ENDIF
  @ 23,2 SAY "Nema vise podataka u banci !    "
  INKEY(0)
  CLEAR SCREEN
  @ red,1 SAY "  "
  EXIT
ENDDO
SET CONFIRM OFF
CLOSE DATABASES
RETURN


****************************************
PROCEDURE s_pro
* S_PRO.PRG PREGLED PROMENA OD POCETKA GODINE
SET CONFIRM ON
CLEAR SCREEN
DO WHILE .T.
  *Okvir*
  @ 1,0 TO 3,78 DOUBLE
  @ 5,0 TO 23,78 DOUBLE
  @ 2,3 SAY "S_PRO"
  @ 2,25 SAY "PREGLED PROMENA"
  @ 2,61 SAY "''ESC'' za kraj"
  m_izbor=1
  *Vrste pregleda*
  @ 7,8  PROMPT " PREGLED STV/MES ";
         MESSAGE "PROMENE PO STOVARISTU I MESECU"
  @ 7,28 PROMPT " PREGLED STV/VRS ";
         MESSAGE "PROMENE PO STOVARISTU I MAT OBRASCU"
  @ 7,48 PROMPT " PREGLED STV/VRS/MES ";
         MESSAGE "PROMENE PO STOVARISTU, MAT OBRASCU I MESECU"
  CLEAR TYPEAHEAD
  MENU TO m_izbor
  *Izbor*
  DO CASE
    CASE LASTKEY()=27
         EXIT
    CASE m_izbor=1
         DO promes
    CASE m_izbor=2
         DO provrs
    CASE m_izbor=3
         DO provrm
    OTHERWISE
         EXIT
  ENDCASE
ENDDO
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN




**********************************************************
PROCEDURE PROMES
*--- promene po stovaristu i mesecu
SET CONFIRM ON
m_stv=0
m_mes=0
m_kst=0
aa=0
red=6
m_odl="N"
*Matrica sa VK ili MAT-ovima*
DECLARE tab[30]
tab[1]="01"
tab[2]="02"
tab[3]="03"
tab[4]="04"
tab[5]="05"
tab[9]="09"
tab[10]="10"
tab[11]="11"
tab[12]="12"
tab[13]="13"
tab[14]="14"
tab[20]="20"
tab[21]="21"
tab[23]="23"
tab[24]="24"
tab[30]="30"
*Zaglavlje*
@  9,2 SAY "Izgled liste :"
@ 10,2 SAY "                   PREGLED PROMENA ZA STOVARISTE xxx"
@ 11,2 SAY "Mesec xx"
@ 12,2 SAY "-------------------------------------------------------------------------"
@ 13,2 SAY "  ARTIKAL  VK OS SEK.SEC-DOB-STV          BRD  KOLICINA"
@ 14,2 SAY "-------------------------------------------------------------------------"
*Unos podtaka*
DO WHILE .T.
  @ 16,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 18,10 SAY "MESEC             : " GET m_mes PICTURE "99";
          VALID(m_mes>0 .AND. m_mes<13)
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    RETURN
  ENDIF
  SELECT 1
  USE prom INDEX promid
  GO TOP
  SEEK STR(m_stv,3)+STR(m_mes,2)
  *Ako je nadjeno ("mss" je bilo predvidjeno za neke analize)*
  IF FOUND() .AND. mss=0
    CLEAR SCREEN
    *Ispisuje zadatu kombinaciju STV i MES do kraja*
    DO WHILE m_stv=stv.AND.m_mes=mes.AND. ! EOF()
      *Prvi ispis stranice - zaglavlje*
      IF aa=0
        @ 1,1 SAY "              PREGLED PROMENA ZA STOVARISTE "+STR(m_stv,3)
        @ 2,1 SAY "Mesec "+STR(m_mes,2)
        @ 3,1 SAY "------------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL  VK OS SEK,SEC-DOB-STV                   BRD  KOLICINA"
        @ 5,1 SAY "------------------------------------------------------------------------------"
        aa=1
      ENDIF
      *"mss" uvej je 0 (ne koristi se)*
      IF mss=0
        m_kst=kst/1000
        *Ispis za odredjene MAT-ove*
        IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
          @ red,1  SAY STR(art,10)+" "+tab[vrs]+" "+osu+" "+dom+" "+STR(brd,5)
        ELSE
          @ red,1  SAY STR(art,10)+" "+tab[vrs]+" "+osu+" "+STR(dob,6)+"                         "+STR(brd,5)
        ENDIF
        @ red,56 SAY STR(m_kst,9,3)
        red=red+1
        *Kraj ispisa na ekranu - zadnji red*
        IF red = 23
          red=6
          aa=0
          @ 23,1 SAY "Pritisni bilo sta za listanje !"
          INKEY(0)
          @ 6,0 CLEAR TO 23,79
          IF LASTKEY()=27
            EXIT
          ENDIF
        ENDIF
      ENDIF
      SKIP
    ENDDO
    @ red,4 SAY "  "
    EXIT
  *Nije nadjeno*
  ELSE
    @ 22,3 SAY "Nema podataka za to STV/MES !"
    INKEY(3)
    @ 22,3 SAY "                             "
    m_stv=0
    m_mes=0
    LOOP
  ENDIF
ENDDO
IF LASTKEY() = 27
  SET CONFIRM OFF
  CLEAR SCREEN
  RETURN
ENDIF
*Upit za stampanje*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *Ako printer nije ukljucen*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    RETURN
  ENDIF
  m_kst=0
  aa=0
  red=6
  m_odl="N"
  *Matrica sa matovima*
  DECLARE tab[30]
  tab[1]="01"
  tab[2]="02"
  tab[3]="03"
  tab[4]="04"
  tab[5]="05"
  tab[9]="09"
  tab[10]="10"
  tab[11]="11"
  tab[12]="12"
  tab[13]="13"
  tab[14]="14"
  tab[20]="20"
  tab[21]="21"
  tab[23]="23"
  tab[24]="24"
  tab[30]="30"
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  SELECT 1
  USE prom INDEX promid
  GO TOP
  DO WHILE .T.
    *Pretrazuje zadatu kombinaciju stovarista i meseca*
    SEEK STR(m_stv,3)+STR(m_mes,2)
    *Ako je nadjeno*
    IF FOUND()
      CLEAR SCREEN
      DO WHILE m_stv=stv.AND.m_mes=mes.AND. ! EOF()
        *Prvi ispis zaglavlja*
        IF aa=0
          @ 1,1 SAY "              PREGLED PROMENA ZA STOVARISTE "+STR(m_stv,3)
          @ 2,1 SAY "Mesec "+STR(m_mes,2)
          @ 3,1 SAY "------------------------------------------------------------------------------"
          @ 4,1 SAY "  ARTIKAL  VK OS SEK,SEC-DOB-STV                   BRD  KOLICINA"
          @ 5,1 SAY "------------------------------------------------------------------------------"
          aa=1
        ENDIF
        IF mss=0
          m_kst=kst/1000
          *Ispis nadjenih slogova po MAT-ovima*
          IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
            @ red,1  SAY STR(art,10)+" "+tab[vrs]+" "+osu+" "+dom+" "+STR(brd,5)
          ELSE
            @ red,1  SAY STR(art,10)+" "+tab[vrs]+" "+osu+" "+STR(dob,6)+"                         "+STR(brd,5)
          ENDIF
          @ red,56 SAY STR(m_kst,9,3)
          red=red+1
          IF red = 54
            red=6
            aa=0
          ENDIF
        ENDIF
        SKIP
      ENDDO
      @ red,4 SAY "  "
      EXIT
    ENDIF
  ENDDO
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN




**********************************************************
PROCEDURE PROVRS
*--- promene po stovaristu i MAT obrascu
SET CONFIRM ON
m_stv=0
m_mat=0
m_kst=0
aa=0
red=6
m_odl="N"
*MAT-ovi*
DECLARE tab[30]
tab[1]="01"
tab[2]="02"
tab[3]="03"
tab[4]="04"
tab[5]="05"
tab[9]="09"
tab[10]="10"
tab[11]="11"
tab[12]="12"
tab[13]="13"
tab[14]="14"
tab[20]="20"
tab[21]="21"
tab[23]="23"
tab[24]="24"
tab[30]="30"
*Zaglavlje*
@  9,2 SAY "Izgled liste :"
@ 10,2 SAY "                   PREGLED PROMENA ZA STOVARISTE xxx"
@ 11,2 SAY "MAT - xx"
@ 12,2 SAY "-------------------------------------------------------------------------"
@ 13,2 SAY "  ARTIKAL MES OS SEK,SEC-DOB-STV                    BRD  KOLICINA"
@ 14,2 SAY "-------------------------------------------------------------------------"
*Unos*
DO WHILE .T.
  @ 16,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 18,10 SAY "MAT obrazac       : " GET m_mat PICTURE "99";
          VALID(m_mat>0 .AND. m_mat<31)
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    RETURN
  ENDIF
  SELECT 1
  USE prom
  INDEX ON STR(stv,3)+STR(vrs,2)+STR(mes,2)+STR(brd,5) TO prompd
  USE prom INDEX prompd
  GO TOP
  *Pretraga mata po stoveristima*
  SEEK STR(m_stv,3)+STR(m_mat,2)
  IF FOUND()
    CLEAR SCREEN
    *Ispis za nadjene zadate kombinacije*
    DO WHILE m_stv=stv .AND. m_mat=vrs .AND. ! EOF()
      IF aa=0
        @ 1,1 SAY "              PREGLED PROMENA ZA STOVARISTE "+STR(m_stv,3)
        @ 2,1 SAY "MAT "+tab[vrs]
        @ 3,1 SAY "------------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL MES OS SEK,SEC-DOB-STV                   BRD  KOLICINA"
        @ 5,1 SAY "------------------------------------------------------------------------------"
        aa=1
      ENDIF
      IF mss=0
        m_kst=kst/1000
        IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
          @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+dom+" "+STR(brd,5)
        ELSE
          @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+STR(dob,6)+"                         "+STR(brd,5)
        ENDIF
        @ red,56 SAY STR(m_kst,9,3)
        red=red+1
        IF red = 23
          red=6
          aa=0
          @ 23,1 SAY "Pritisni bilo sta za listanje !"
          INKEY(0)
          @ 6,0 CLEAR TO 23,79
        ENDIF
      ENDIF
      SKIP
    ENDDO
    @ red,4 SAY "  "
    EXIT
  *Nije nadjeno*
  ELSE
    @ 22,3 SAY "Nema podataka za to STV/MAT !"
    INKEY(3)
    @ 22,3 SAY "                             "
    m_stv=0
    m_mes=0
    LOOP
  ENDIF
ENDDO
*Upit za stampanje*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *Nije prikljucen stampac*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    RETURN
  ENDIF
  m_kst=0
  aa=0
  red=6
  m_odl="N"
  *MAT-ovi*
  DECLARE tab[30]
  tab[1]="01"
  tab[2]="02"
  tab[3]="03"
  tab[4]="04"
  tab[5]="05"
  tab[9]="09"
  tab[10]="10"
  tab[11]="11"
  tab[12]="12"
  tab[13]="13"
  tab[14]="14"
  tab[20]="20"
  tab[21]="21"
  tab[23]="23"
  tab[24]="24"
  tab[30]="30"
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  SELECT 1
  USE prom INDEX prompd
  GO TOP
  DO WHILE .T.
    *Pretraga*
    SEEK STR(m_stv,3)+STR(m_mat,2)
    *Ako je nadjen*
    IF FOUND()
      CLEAR SCREEN
      *Ispisuje za sve nadjene zadate kombinacije*
      DO WHILE m_stv=stv .AND. m_mat=vrs .AND. ! EOF()
        IF aa=0
          @ 1,1 SAY "              PREGLED PROMENA ZA STOVARISTE "+STR(m_stv,3)
          @ 2,1 SAY "MAT "+tab[vrs]
          @ 3,1 SAY "------------------------------------------------------------------------------"
          @ 4,1 SAY "  ARTIKAL MES OS SEK,SEC-DOB-STV                   BRD  KOLICINA"
          @ 5,1 SAY "------------------------------------------------------------------------------"
          aa=1
        ENDIF
        IF mss=0
          m_kst=kst/1000
          IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
            @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+dom+" "+STR(brd,5)
          ELSE
            @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+STR(dob,6)+"                         "+STR(brd,5)
          ENDIF
          @ red,56 SAY STR(m_kst,9,3)
          red=red+1
          IF red = 54
            red=6
            aa=0
          ENDIF
        ENDIF
        SKIP
      ENDDO
      @ red,4 SAY "  "
      EXIT
    ENDIF
  ENDDO
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN




**********************************************************
PROCEDURE PROVRM
*--- promene po stovaristu, MAT obrascu i mesecu
SET CONFIRM ON
m_stv=0
m_mat=0
m_kst=0
m_mes=0
aa=0
red=6
m_odl="N"
*MAT-ovi*
DECLARE tab[30]
tab[1]="01"
tab[2]="02"
tab[3]="03"
tab[4]="04"
tab[5]="05"
tab[9]="09"
tab[10]="10"
tab[11]="11"
tab[12]="12"
tab[13]="13"
tab[14]="14"
tab[20]="20"
tab[21]="21"
tab[23]="23"
tab[24]="24"
tab[30]="30"
*Zaglavl;je*
@  9,2 SAY "Izgled liste :"
@ 10,2 SAY "                   PREGLED PROMENA ZA STOVARISTE xxx"
@ 11,2 SAY "MAT - xx"
@ 12,2 SAY "-------------------------------------------------------------------------"
@ 13,2 SAY "  ARTIKAL MES OS SEK,SEC-DOB-STV                    BRD  KOLICINA"
@ 14,2 SAY "-------------------------------------------------------------------------"
*Unos podataka za pretragu*
DO WHILE .T.
  @ 16,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 18,10 SAY "MAT obrazac       : " GET m_mat PICTURE "99";
          VALID(m_mat>0 .AND. m_mat<31)
  @ 20,10 SAY "Mesec             : " GET m_mes PICTURE "99";
          VALID(m_mes>0)
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    RETURN
  ENDIF
  SELECT 1
  USE prom
  INDEX ON STR(stv,3)+STR(vrs,2)+STR(mes,2)+STR(brd,5) TO prompd
  USE prom INDEX prompd
  GO TOP
  *Pretrazivanje*
  SEEK STR(m_stv,3)+STR(m_mat,2)+STR(m_mes,2)
  IF FOUND()
    CLEAR SCREEN
    *Ispisuje dok ima podataka prema unetom zahtevu*
    DO WHILE m_stv=stv .AND. m_mat=vrs .AND. m_mes=mes .AND. ! EOF()
      IF aa=0
        @ 1,1 SAY "              PREGLED PROMENA ZA STOVARISTE "+STR(m_stv,3)
        @ 2,1 SAY "MAT "+tab[vrs]
        @ 3,1 SAY "------------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL MES OS SEK,SEC-DOB-STV                   BRD  KOLICINA"
        @ 5,1 SAY "------------------------------------------------------------------------------"
        aa=1
      ENDIF
      IF mss=0
        m_kst=kst/1000
        IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
          @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+dom+" "+STR(brd,5)
        ELSE
          @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+STR(dob,6)+"                         "+STR(brd,5)
        ENDIF
        @ red,56 SAY STR(m_kst,9,3)
        red=red+1
        IF red = 23
          red=6
          aa=0
          @ 23,1 SAY "Pritisni bilo sta za listanje !"
          INKEY(0)
          @ 6,0 CLEAR TO 23,79
        ENDIF
      ENDIF
      SKIP
    ENDDO
    @ red,4 SAY "  "
    EXIT
  ELSE
    @ 22,3 SAY "Nema podataka za to STV/MAT/MES !"
    INKEY(3)
    @ 22,3 SAY "                                 "
    m_stv=0
    m_mat=0
    m_mes=0
    LOOP
  ENDIF
ENDDO
*Upit za stampu*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *Proverava ima li printera*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    RETURN
  ENDIF
  m_kst=0
  aa=0
  red=6
  m_odl="N"
  *MAT-ovi*
  DECLARE tab[30]
  tab[1]="01"
  tab[2]="02"
  tab[3]="03"
  tab[4]="04"
  tab[5]="05"
  tab[9]="09"
  tab[10]="10"
  tab[11]="11"
  tab[12]="12"
  tab[13]="13"
  tab[14]="14"
  tab[20]="20"
  tab[21]="21"
  tab[23]="23"
  tab[24]="24"
  tab[30]="30"
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  SELECT 1
  USE prom INDEX prompd
  GO TOP
  DO WHILE .T.
    *Pretrazuje zadatu kombinaciju*
    SEEK STR(m_stv,3)+STR(m_mat,2)+STR(m_mes,2)
    IF FOUND()
      *Ispisuje nadjeno*
      CLEAR SCREEN
      DO WHILE m_stv=stv .AND. m_mat=vrs .AND. m_mes=mes .AND. ! EOF()
        IF aa=0
          @ 1,1 SAY "              PREGLED PROMENA ZA STOVARISTE "+STR(m_stv,3)
          @ 2,1 SAY "MAT "+tab[vrs]
          @ 3,1 SAY "------------------------------------------------------------------------------"
          @ 4,1 SAY "  ARTIKAL MES OS SEK,SEC-DOB-STV                   BRD  KOLICINA"
          @ 5,1 SAY "------------------------------------------------------------------------------"
          aa=1
        ENDIF
        IF mss=0
          m_kst=kst/1000
          IF vrs=01 .OR. vrs=12 .OR. vrs=21 .OR. vrs=23 .OR. vrs=24
            @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+dom+" "+STR(brd,5)
          ELSE
            @ red,1  SAY STR(art,10)+" "+STR(mes,2)+" "+osu+" "+STR(dob,6)+"                         "+STR(brd,5)
          ENDIF
          @ red,56 SAY STR(m_kst,9,3)
          red=red+1
          IF red = 54
            red=6
            aa=0
          ENDIF
        ENDIF
        SKIP
      ENDDO
      @ red,4 SAY "  "
      EXIT
    ENDIF
  ENDDO
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN



************************************
PROCEDURE s_rbm
* S_RBM.PRG STAMPA ODREDJENOG BROJA MOTORA
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_RBM"
@ 2,25 SAY "ODREDJENI BROJ MOTORA"
@ 2,61 SAY "''ESC''  za kraj"
*Postavlja promenljive*
m_stv=0
m_izv=0
m_ost=SPACE(30)
m_art=0
m_kst=0
m_dom=SPACE(20)
m_nza=SPACE(42)
aa=0
red=6
m_odl="N"
*Zaglavlje*
@  6,1 SAY "Izgled liste :"
@  7,1 SAY "STOV              MOTOR  xxxxxxxxxxxxxxxxxxxx"
@  8,1 SAY "ARTIKAL  NAZIV                                                       DATUM"
@  9,1 SAY "------------------------------------------------------------------------------"
@ 10,1 SAY " REMONTER    NAZIV                               VRS OSN MES  BRD   KOLICINA"
@ 11,1 SAY "------------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Matc INDEX matcid
SELECT 2
USE Izvr INDEX izvrid
SELECT 3
USE Stiz INDEX stizod
@ 15,9 CLEAR
DO WHILE .T.
  *Unos podataka za pretragu*
  @ 13,10 SAY "STOVARISTE     : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 15,10 SAY "BROJ MOTORA    : " GET m_ost PICTURE "@9";
          VALID(m_ost # " ")
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  *Pretraga u stanju izvodjaca*
  SEEK STR(m_stv,3)+m_ost
  IF ! FOUND()
    @ 22,1 SAY "Tog STV-OST nema !"
    INKEY(3)
    @ 22,1 SAY "                  "
    m_stv=0
    m_ost=SPACE(30)
    LOOP
  ENDIF
  m_art=art
  m_ost=ost
  m_izv=izv
  SELECT 2
  *Pretraga u izvodjacima radova (izvrsiocima)*
  SEEK m_izv
  IF ! FOUND()
    m_dom="Nepoznat ?"
  ELSE
    m_dom=dom
  ENDIF
  SELECT 1
  SEEK m_art
  IF FOUND()
    m_nza=nza
  ELSE
    m_nza="Nepoznat naziv ?                          "
  ENDIF
  CLEAR SCREEN
  SELECT 3
  *Ispis svih nadjenih zadatih kombinacija*
  DO WHILE m_stv=stv .AND. m_ost=ost
    IF aa=0
      @ 1,1 SAY "STOVARISTE  "+STR(m_stv,3)+"              MOTOR : "+m_ost
      @ 2,1 SAY STR(m_art,10)+"  "+m_nza+"                "+DTOC(DATE())
      @ 3,1 SAY "-------------------------------------------------------------------------------"
      @ 4,1 SAY " REMONTER   NAZIV                                                KOLICINA"
      @ 5,1 SAY "-------------------------------------------------------------------------------"
      aa=1
    ENDIF
    SELECT 3
    DO WHILE m_ost=ost
      @ red,3 SAY STR(m_izv,6)+"    "+m_dom
      m_kst=kst/1000
      @ red,65 SAY STR(m_kst,7)
      red=red+1
      *Kraj ispisa - zadnji red nma ekranu*
      IF red > 21
        red=6
        aa=0
        @ 23,1 SAY "Pritisni bilo sta za listanje !"
        INKEY(0)
        @ 7,0 CLEAR TO 23,79
      ENDIF
      SKIP
      IF m_izv=izv
      ELSE
        m_izv=izv
        SELECT 2
        SEEK m_izv
        IF ! FOUND()
          m_dom="Nepoznat ?"
        ELSE
          m_dom=dom
        ENDIF
      ENDIF
      SELECT 3
    ENDDO
    EXIT
  ENDDO
  @ 23,5 SAY "Nema vise podataka !"
  INKEY(0)
  EXIT
ENDDO
*Upit za stampanje*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  aa=0
  red=6
  INKEY(0)
  *Provera printera*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  USE Matc INDEX matcid
  SELECT 2
  USE Izvr INDEX izvrid
  SELECT 3
  USE Prom INDEX prommd
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  DO WHILE .T.
    *Pretraga u promenama*
    SEEK STR(m_stv,3)+m_ost
    m_art=art
    m_ost=ost
    m_dob=dob
    SELECT 2
    *Pretraga u izvodjacima radova*
    SEEK m_dob
    IF ! FOUND()
      m_dom="Nepoznat ?"
    ELSE
      m_dom=dom
    ENDIF
    SELECT 1
    *Pretraga artikla u maticnoj*
    SEEK m_art
    IF FOUND()
      m_nza=nza
    ELSE
      m_nza="Nepoznat naziv ?                          "
    ENDIF
    CLEAR SCREEN
    SELECT 3
    *Ispisuje sve nadjene podatke za zadatu kombinaciju*
    DO WHILE m_stv=stv .AND. m_ost=ost
      IF aa=0
        @ 1,1 SAY "STOVARISTE  "+STR(m_stv,3)+"              MOTOR : "+m_ost
        @ 2,1 SAY STR(m_art,10)+"  "+m_nza+"                "+DTOC(DATE())
        @ 3,1 SAY "-------------------------------------------------------------------------------"
        @ 4,1 SAY " REMONTER   NAZIV                                     VK OS MS   BRD   KOLICINA"
        @ 5,1 SAY "-------------------------------------------------------------------------------"
        aa=1
      ENDIF
      IF vrs=23 .OR. vrs=24
        SELECT 3
        DO WHILE m_ost=ost .AND. (vrs=23 .OR. vrs=24)
          IF m_izv=dob
          ELSE
            m_izv=dob
            @ red,3 SAY STR(m_izv,6)+"    "+m_dom
          ENDIF
          m_kst=kst/1000
          @ red,55 SAY STR(vrs,2)+" "+osu+" "+STR(mes,2)+" "+STR(brd,5)+STR(m_kst,11,3)
          red=red+1
          IF red > 55
            red=6
            aa=0
          ENDIF
          SKIP
          *Kontra upit - ako izvodjac radova u bazi nije isti kao trazeni*
          IF m_izv=dob
          ELSE
            m_dob=dob
            SELECT 2
            SEEK m_dob
            IF ! FOUND()
              m_dom="Nepoznat ?"
            ELSE
              m_dom=dom
            ENDIF
          ENDIF
          SELECT 3
        ENDDO
        EXIT
      ENDIF
      SKIP
      m_art=art
      LOOP
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



***********************************
PROCEDURE s_rem
* S_REM.PRG STAMPA ODREDJENOG REMONTERA
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_REM"
@ 2,25 SAY "ODREDJENI REMONTER"
@ 2,61 SAY "''ESC''  za kraj"
*Postavka promenljivih*
m_stv=0
m_izv=0
m_art=0
m_kst=0
m_dom=SPACE(20)
m_nza=SPACE(42)
aa=0
red=6
m_odl="N"
*Zaglavlje*
@  6,1 SAY "Izgled liste :"
@  7,1 SAY "                  REMONTER xxxxxx xxxxxxxxxxxxxxxxxxxx"
@  8,1 SAY "STOVARISTE                                                           DATUM"
@  9,1 SAY "------------------------------------------------------------------------------"
@ 10,1 SAY " ARTIKAL     NAZIV                               VRS OSN MES  BRD   KOLICINA"
@ 11,1 SAY "------------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Matc INDEX matcid
SELECT 2
USE Izvr INDEX izvrid
SELECT 3
USE Prom INDEX promrd
@ 15,9 CLEAR
DO WHILE .T.
  *Unos podataka*
  @ 13,10 SAY "STOVARISTE     : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 15,10 SAY "REMONTER       : " GET m_izv PICTURE "999999";
          VALID(m_izv>0)
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  SEEK STR(m_stv,3)+STR(m_izv,6)
  IF ! FOUND()
    @ 22,1 SAY "Tog STV-IZV nema !"
    INKEY(3)
    @ 22,1 SAY "                  "
    m_stv=0
    m_izv=0
    LOOP
  ENDIF
  m_art=art
  SELECT 2
  SEEK m_izv
  IF ! FOUND()
    m_dom="Nepoznat ?"
  ELSE
    m_dom=dom
  ENDIF
  CLEAR SCREEN
  SELECT 3
  *Ispisuje sve sto odgovara zadatoj kombinaciji*
  DO WHILE m_stv=stv .AND. m_izv=dob
    IF aa=0
      @ 1,1 SAY "                REMONTER : "+STR(m_izv,6)+" - "+m_dom
      @ 2,1 SAY "STOVARISTE "+str(m_stv,3)+"                                                        "+DTOC(DATE())
      @ 3,1 SAY "-------------------------------------------------------------------------------"
      @ 4,1 SAY " ARTIKAL    NAZIV                                     VK OS MS  BRD    KOLICINA"
      @ 5,1 SAY "-------------------------------------------------------------------------------"
      aa=1
    ENDIF
    IF vrs=23 .OR. vrs=24
      SELECT 1
      SEEK m_art
      IF FOUND()
        m_nza=nza
      ELSE
        m_nza="Nepoznat naziv ?                          "
      ENDIF
      SELECT 3
      @ red,1 SAY STR(m_art,10)+" "+m_nza
      DO WHILE m_izv=dob.AND.m_art=art.AND.(vrs=23.OR.vrs=24)
        m_kst=kst/1000
        @ red,55 SAY STR(vrs,2)+" "+osu+" "+STR(mes,2)+STR(brd,5)+" "+STR(m_kst,11,3)
        red=red+1
        IF ost # " "
          @ red,18 SAY "Broj motora : "+ost
          red=red+1
        ENDIF
        IF red > 21
          red=5
          aa=0
          @ 23,1 SAY "Pritisni bilo sta za listanje !"
          INKEY(0)
          @ 7,0 CLEAR TO 23,79
          SKIP
          EXIT
        ENDIF
        SKIP
      ENDDO
      red=red+1
      m_art=art
      LOOP
    ENDIF
    SKIP
    m_art=art
    LOOP
  ENDDO
  @ 23,5 SAY "Nema vise podataka !"
  INKEY(0)
  EXIT
ENDDO
*Upit za stampanje*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  aa=0
  red=6
  INKEY(0)
  *Provera stampaca*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  USE Matc INDEX matcid
  SELECT 2
  USE Izvr INDEX izvrid
  SELECT 3
  USE Prom INDEX promrd
  DO WHILE .T.
    SET DEVICE TO PRINT
    * SET PRINTER TO STAMPA
    SEEK STR(m_stv,3)+STR(m_izv,6)
    m_art=art
    SELECT 2
    SEEK m_izv
    IF ! FOUND()
      m_dom="Nepoznat ?"
    ELSE
      m_dom=dom
    ENDIF
    CLEAR SCREEN
    SELECT 3
    *Ispisuje sve nadjene zadate kombinacije*
    DO WHILE m_stv=stv .AND. m_izv=dob
      IF aa=0
        @ 1,1 SAY "                REMONTER : "+STR(m_izv,6)+" - "+m_dom
        @ 2,1 SAY "STOVARISTE "+str(m_stv,3)+"                                                        "+DTOC(DATE())
        @ 3,1 SAY "-------------------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL    NAZIV                                     VK OS MS  BRD    KOLICINA"
        @ 5,1 SAY "-------------------------------------------------------------------------------"
        aa=1
      ENDIF
      IF vrs=23 .OR. vrs=24
        SELECT 1
        SEEK m_art
        IF FOUND()
          m_nza=nza
        ELSE
          m_nza="Nepoznat naziv ?                          "
        ENDIF
        SELECT 3
        @ red,1 SAY STR(m_art,10)+" "+m_nza
        DO WHILE m_izv=dob.AND.m_art=art.AND.(vrs=23.OR.vrs=24)
          m_kst=kst/1000
          @ red,55 SAY STR(vrs,2)+" "+osu+" "+STR(mes,2)+STR(brd,5)+" "+STR(m_kst,11,3)
          red=red+1
          IF ost # " "
            @ red,18 SAY "Broj motora : "+ost
            red=red+1
          ENDIF
          IF red > 55
            red=5
            aa=0
            SKIP
            EXIT
          ENDIF
          SKIP
        ENDDO
        red=red+1
        m_art=art
        LOOP
      ENDIF
      SKIP
      m_art=art
      LOOP
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



**************************************
PROCEDURE s_stv
* S_STV.PRG SVI ARTIKLI JEDNOG STOVARISTA
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_STV"
@ 2,25 SAY "SVI ARTIKLI JEDNOG STOVARISTA"
@ 2,61 SAY "''ESC'' za kraj"
*Postavka promenljivih*
m_stv=0
m_kst=0
m_art=0
m_knt=0
m_kon=0
m_ime=SPACE(28)
m_stm=SPACE(20)
m_nza=SPACE(42)
m_jmr=SPACE(3)
m_sel=0
p_sel=0
m_poc=0
m_odl="N"
aa=0
bb=0
dd=0
br=0
*Matrica konta - osnova*
DECLARE tak[7]
tak[1]="Novo"
tak[2]="Polovno"
tak[3]="Nepotrebno - Zastarelo (novo)"
tak[4]="Nepotrebno - Zastarelo (polovno)"
tak[5]="Na obradi,,, (novo)"
tak[6]="Na obradi,,, (polovno)"
tak[7]="Upotreba"
*Matrica jedinica mere*
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
red=7
*Zaglavlje*
@  6,1 SAY "Izgled liste :"
@  8,1 SAY "                STANJE ZALIHA U STOVARISTU XXX (kolicina>0)"
@ 10,1 SAY "---------------------------------------------------------------------------"
@ 11,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO   KOLICINA"
@ 12,1 SAY "---------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Stan INDEX standd
GO TOP
SELECT 2
USE Matc INDEX matcid
GO TOP
@ 15,9 CLEAR
DO WHILE .T.
  *Unos podataka za pretragu*
  @ 14,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 16,10 SAY "Selekcija         : " GET m_sel PICTURE "9";
          VALID(m_sel>0 .AND. m_sel<8)
  *Za slucaj da je stampa prekinuta (najmanji broj artikla je 1010001020)*
  @ 18,10 SAY "Od pocetka ?      : " GET m_poc PICTURE "9999999999";
          VALID(m_poc=0 .OR. m_poc>1000000000)
  @ 19,10 SAY "Unesi 0 ili sifru ARTIKLA"
  @ 16,55 SAY "1 - Novo"
  @ 17,55 SAY "2 - Polovno - Upotreba"
  @ 18,55 SAY "3 - Zastarelo - novo"
  @ 19,55 SAY "4 - Zastarelo - polovno"
  @ 20,55 SAY "5 - Na obradi - novo"
  @ 21,55 SAY "6 - Na obradi - polovno"
  @ 22,55 SAY "7 - S V E"
  READ
  p_sel=m_sel
  IF LASTKEY() = 27
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  USE Stan INDEX standd
  GO TOP
  SEEK STR(m_stv,3)
  IF ! FOUND()
    @ 14,40 SAY "Tog stovarista nema na stanju !"
    INKEY(2)
    @ 14,40 SAY "                               "
    m_stv=0
    LOOP
  ENDIF
  IF m_sel=7
    SEEK STR(m_stv,3)
    m_sel=kon
    dd=1
  ELSE
    SEEK STR(m_stv,3)+STR(m_sel,1)
    IF ! FOUND()
      @ 23,1 SAY "Na tom kontu nema artikala !"
      INKEY(0)
      @ 23,1 SAY "                            "
      m_stv=0
      m_sel=0
      LOOP
    ENDIF
    *Najmanja sifra artikla je 1010001020*
    IF m_poc>1000000000
      DO WHILE ! EOF()
        IF art=m_poc
          bb=1
          EXIT
        ELSE
          SKIP
          LOOP
        ENDIF
      ENDDO
      IF bb=0
        @ 23,2 SAY "Nepoznata sifra artikla !"
        INKEY(3)
        EXIT
      ENDIF
    ENDIF
  ENDIF
  CLEAR SCREEN
  m_kon=kon
  *Radi za sve zadate STV i KON do kraja*
  DO WHILE m_stv=stv .AND. m_sel=kon .AND. ! EOF()
    bb=1
    IF kst = 0
      SKIP
      LOOP
    ENDIF
    IF aa=0
      @ 1,18SAY "STANJE ZALIHA U STOVARISTU "+STR(m_stv,3)+" (kolicina # 0)"
      @ 2,67SAY DTOC(DATE())
      @ 3,1 SAY "----------------------------------------------------------------------------"
      @ 4,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO    KOLICINA"
      @ 5,1 SAY "----------------------------------------------------------------------------"
      @ 6,4 SAY " konto :  "+tak[m_sel]
      aa=1
    ENDIF
    IF m_kon=kon
    ELSE
      red=red+1
      @ red,4 SAY " konto  : "+tak[kon]
      red=red+1
      m_kon=kon
    ENDIF
    m_art=art
    m_knt=knt
    m_kst=kst/1000
    SELECT 2
    USE Matc INDEX matcid
    GO TOP
    SEEK A->art
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
    @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(m_kst,10,3)
    red=red+1
    br=br+1
    SELECT 1
    SKIP
    *Ispis je stigao do kraja ekrana*
    IF red > 22
      SELECT 1
      @ 23,2 SAY "Unazad sa PAGE UP, bilo sta za dalje !"
      INKEY(0)
      IF LASTKEY()=18
        SKIP -23
        br=br-23
        IF br<0
          br=0
          GO TOP
          SEEK STR(m_stv,3)
        ENDIF
      ENDIF
      red=7
      aa=0
      m_kon=kon
      @ 7,0 CLEAR TO 23,79
      IF LASTKEY()=27
        EXIT
      ENDIF
    ENDIF
    IF m_sel<>kon .AND. dd=1
      m_sel=kon
      SEEK STR(m_stv,3)+STR(m_sel,1)
    ENDIF
  ENDDO
  @ red,1 SAY "  "
  EXIT
ENDDO
IF bb=0
  SET CONFIRM OFF
  CLEAR SCREEN
  CLOSE DATABASES
  RETURN
ENDIF
@ 23,1 CLEAR
*Upit za stampu*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
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
  SELECT 1
  USE Stan INDEX standd
  GO TOP
  SELECT 2
  USE Matc INDEX matcid
  GO TOP
  DO WHILE .T.
    m_kon=0
    m_sel=p_sel
    aa=0
    red=7
    SET DEVICE TO PRINT
    * SET PRINTER TO STAMPA
    SELECT 1
    *Pretraga stovarista u stanju*
    SEEK STR(m_stv,3)
    IF m_sel=7
      SEEK STR(m_stv,3)
      m_sel=kon
      dd=1
    ELSE
      SEEK STR(m_stv,3)+STR(m_sel,1)
    ENDIF
    CLEAR SCREEN
    m_kon=kon
    IF m_poc>1000000000
      DO WHILE ! EOF()
        IF art=m_poc
          EXIT
        ELSE
          SKIP
          LOOP
        ENDIF
      ENDDO
    ENDIF
    *Ispis za sve nadjene zadate kombinacije*
    DO WHILE m_stv=stv .AND. m_sel=kon .AND. ! EOF()
      IF kst = 0
        SKIP
        LOOP
      ENDIF
      IF aa=0
        @ 1,18SAY "STANJE ZALIHA U STOVARISTU "+STR(m_stv,3)+" (kolicina # 0)"
        @ 2,67SAY DTOC(DATE())
        @ 3,1 SAY "----------------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO    KOLICINA"
        @ 5,1 SAY "----------------------------------------------------------------------------"
        @ 6,4 SAY " konto :  "+tak[m_sel]
        aa=1
      ENDIF
      IF m_kon=kon
      ELSE
        red=red+1
        @ red,4 SAY " konto  : "+tak[kon]
        red=red+1
        m_kon=kon
      ENDIF
      m_art=art
      m_knt=knt
      m_kst=kst/1000
      SELECT 2
      USE Matc INDEX matcid
      GO TOP
      SEEK A->art
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
      @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(m_kst,10,3)
      red=red+1
      SELECT 1
      SKIP
      IF red > 60
        red=7
        aa=0
        m_kon=kon
      ENDIF
      IF m_sel<>kon .AND. dd=1
        m_sel=kon
        SEEK STR(m_stv,3)+STR(m_sel,1)
      ENDIF
    ENDDO
    @ red,1 SAY "  "
    EXIT
  ENDDO
ELSE
  SET DEVICE TO SCREEN
  @ 20,1 CLEAR TO 23,79
  @ 23,1 SAY "Odustao si od stampe !"
  INKEY(2)
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN



********************************
PROCEDURE s_rer
* S_RER.PRG ODREDJENI REMONTER
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_RER"
@ 2,25 SAY "ODREDJENI REMONTER"
@ 2,61 SAY "''ESC''  za kraj"
*Postavka promenljivih*
m_stv=0
m_izv=0
m_art=0
r_art=0
m_kst=0
m_dom=SPACE(20)
m_nza=SPACE(42)
aa=0
bb=0
cc=0
red=6
m_odl="N"
*Zaglavlje*
@  6,1 SAY "Izgled liste :"
@  7,1 SAY "                  REMONTER xxxxxx xxxxxxxxxxxxxxxxxxxx"
@  8,1 SAY "STOVARISTE                                                           DATUM"
@  9,1 SAY "------------------------------------------------------------------------------"
@ 10,1 SAY " ARTIKAL     NAZIV                             KOLICINA    BROJ MOTORA"
@ 11,1 SAY "------------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Matc INDEX matcid
SELECT 2
USE Izvr INDEX izvrid
SELECT 3
USE Stiz INDEX stizid
@ 15,9 CLEAR
DO WHILE .T.
  *Unos podataka*
  @ 13,10 SAY "STOVARISTE     : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 15,10 SAY "REMONTER       : " GET m_izv PICTURE "999999";
          VALID(m_izv>0)
  READ
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  SEEK STR(m_stv,3)+STR(m_izv,6)
  IF ! FOUND()
    @ 22,1 SAY "Tog STV-IZV nema !"
    INKEY(3)
    @ 22,1 SAY "                  "
    m_stv=0
    m_izv=0
    LOOP
  ENDIF
  m_art=art
  m_ost=ost
  SELECT 2
  SEEK m_izv
  IF ! FOUND()
    m_dom="Nepoznat ?"
  ELSE
    m_dom=dom
  ENDIF
  CLEAR SCREEN
  SELECT 3
  *Ispis svih nadjenih zadatih kombinacija*
  DO WHILE m_stv=stv .AND. m_izv=izv
    IF aa=0
      @ 1,1 SAY "                REMONTER : "+STR(m_izv,6)+" - "+m_dom
      @ 2,1 SAY "STOVARISTE "+str(m_stv,3)+"                                                        "+DTOC(DATE())
      @ 3,1 SAY "-------------------------------------------------------------------------------"
      @ 4,1 SAY " ARTIKAL    NAZIV                                        KOLIC. BROJ MOTORA"
      @ 5,1 SAY "-------------------------------------------------------------------------------"
      aa=1
    ENDIF
    IF r_art=m_art
      m_kst=kst/1000
      @ red,54 SAY STR(m_kst,10,3)+" "+m_ost
    ELSE
      SELECT 1
      SEEK m_art
      IF FOUND()
        m_nza=nza
      ELSE
        m_nza="Nepoznat naziv ?                          "
      ENDIF
      SELECT 3
      m_kst=kst/1000
      red=red+1
      @ red,1 SAY STR(m_art,10)+" "+m_nza
      @ red,54 SAY STR(m_kst,10,3)+" "+m_ost
      r_art=m_art
      m_art=art
      m_ost=ost
      m_kst=0
    ENDIF
    IF red > 21
      red=5
      aa=0
      @ 23,1 SAY "Pritisni bilo sta za listanje !"
      INKEY(0)
      @ 7,0 CLEAR TO 23,79
    ENDIF
    red=red+1
    bb=0
    SKIP
    m_art=art
    m_ost=ost
    LOOP
  ENDDO
  @ 23,5 SAY "Nema vise podataka !"
  INKEY(0)
  EXIT
ENDDO
*Upit za stampu*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  aa=0
  red=6
  r_art=0
  m_kst=0
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
  SELECT 1
  USE Matc INDEX matcid
  SELECT 2
  USE Izvr INDEX izvrid
  SELECT 3
  USE Stiz INDEX stizid
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  DO WHILE .T.
    SEEK STR(m_stv,3)+STR(m_izv,6)
    m_art=art
    m_ost=ost
    SELECT 2
    SEEK m_izv
    IF ! FOUND()
      m_dom="Nepoznat ?"
    ELSE
      m_dom=dom
    ENDIF
    CLEAR SCREEN
    SELECT 3
    *Stampa svih nadjenih zadatih kombinacija*
    DO WHILE m_stv=stv .AND. m_izv=izv
      IF aa=0
        @ 1,1 SAY "                REMONTER : "+STR(m_izv,6)+" - "+m_dom
        @ 2,1 SAY "STOVARISTE "+str(m_stv,3)+"                                                        "+DTOC(DATE())
        @ 3,1 SAY "-------------------------------------------------------------------------------"
        @ 4,1 SAY " ARTIKAL    NAZIV                                        KOLIC. BROJ MOTORA"
        @ 5,1 SAY "-------------------------------------------------------------------------------"
        aa=1
      ENDIF
      IF r_art=m_art
        m_kst=kst/1000
        @ red,54 SAY STR(m_kst,10,3)+" "+m_ost
      ELSE
        SELECT 1
        SEEK m_art
        IF FOUND()
          m_nza=nza
        ELSE
          m_nza="Nepoznat naziv ?                          "
        ENDIF
        SELECT 3
        m_kst=kst/1000
        @ red,1 SAY STR(m_art,10)+" "+m_nza
        @ red,54 SAY STR(m_kst,10,3)+" "+m_ost
        r_art=m_art
        m_art=art
        m_ost=ost
        m_kst=0
      ENDIF
      IF red > 55
        red=5
        aa=0
      ENDIF
      red=red+1
      bb=0
      SKIP
      m_art=art
      m_ost=ost
      LOOP
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



**********************************
PROCEDURE s_utr
* S_UTR.PRG SUMARNI UTROSAK ARTIKALA ZA JEDNO STOVARISTA
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_UTR"
@ 2,25 SAY "SUMARNI UTROSAK ZA STOVARISTE"
@ 2,61 SAY "''ESC'' za kraj"
*Postavka promenljivih*
m_stv=0
m_sek=0
m_sec=0
m_mat=0
m_dob=0
m_kst=0
p_kst=0
m_art=0
m_knt=0
m_nza=SPACE(42)
m_jmr=SPACE(3)
m_odl="N"
aa=0
bb=0
*Matrica jedinica mere*
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
red=6
*Zaglavlje*
@  6,1 SAY "Izgled liste :"
@  8,1 SAY "    UTROSAK NOVOG U TOKU xxxx GODINE U STOVARISTU xxx"
@  9,1 SAY "SEKTOR : xxx    SEKCIJA : xxx"
@ 10,1 SAY "---------------------------------------------------------------------------"
@ 11,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO   KOLICINA"
@ 12,1 SAY "---------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Prom INDEX prombd
GO TOP
SELECT 2
USE Matc INDEX matcid
GO TOP
@ 15,9 CLEAR
DO WHILE .T.
  *Unos podataka za pretragu*
  @ 14,10 SAY "Sifra STOVARISTA       : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 16,10 SAY "Sifra SEKTORA (SERIJA) : " GET m_sek PICTURE "999";
          VALID(m_sek>0)
  @ 18,10 SAY "Sifra SEKCIJE (BROJ)   : " GET m_sec PICTURE "999";
          VALID(m_sec>0)
  @ 20,10 SAY "MAT - obrazac          : " GET m_mat PICTURE "99";
          VALID(m_mat>0)
  READ
  m_dob=VAL(STR(m_sek,3)+STR(m_sec,3))
  IF LASTKEY() = 27
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  USE Prom INDEX prombd
  GO TOP
  *Pretraga u promenama*
  SEEK STR(m_stv,3)+STR(m_mat,2)+STR(m_dob,6)
  IF ! FOUND()
    @ 14,40 SAY "Tog STV, SEK, SEC, MAT nema u promenama !"
    INKEY(2)
    @ 14,40 SAY "                                         "
    m_stv=0
    m_mat=0
    m_sek=0
    m_sec=0
    LOOP
  ENDIF
  m_art=art
  CLEAR SCREEN
  *Ispisuje nadjene zadate kombinacije*
  DO WHILE m_stv=stv .AND. m_mat=vrs .AND. m_dob=dob .AND.;
           m_art=art .AND. ! EOF()
    DO WHILE (m_art=art)
      IF m_art=art .AND. osu="10"
        m_kst=m_kst+kst
        SKIP
        LOOP
      ELSEIF m_art=art .AND. osu="15"
        m_kst=m_kst-kst
        SKIP
        LOOP
      ELSEIF m_art=art
        SKIP
        LOOP
      ENDIF
    ENDDO
    bb=1
    *Ispis zaglavlja*
    IF aa=0
      @ 1,1 SAY "             UTROSAK NOVOG U TOKU 20"+SUBSTR(DTOC(DATE()),7,2)+".god. U STOVARISTU "+STR(m_stv,3)
      @ 2,1 SAY "SEKTOR (SERIJA) : "+STR(m_sek,3)+"  SEKCIJA (BROJ VOZILA) : "+STR(m_sec,3)+"                  "+DTOC(DATE())
      @ 3,1 SAY "----------------------------------------------------------------------------"
      @ 4,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO    KOLICINA"
      @ 5,1 SAY "----------------------------------------------------------------------------"
      aa=1
    ENDIF
    SELECT 2
    USE Matc INDEX matcid
    GO TOP
    SEEK m_art
    IF FOUND()
      IF jmr="  "
        m_nza="Nepoznat naziv ?                          "
        m_knt=0
        m_jmr="   "
      ELSE
        m_nza=nza
        m_knt=knt
        m_jmr=taj[VAL(jmr)]
      ENDIF
    ELSE
      m_nza="Nepoznat naziv ?                          "
      m_knt=0
      m_jmr="   "
    ENDIF
    p_kst=m_kst/1000
    m_kst=0
    IF p_kst=0
    ELSE
      @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(p_kst,10,3)
      red=red+1
    ENDIF
    m_art=A->art
    SELECT 1
    IF red > 22
      @ 23,1 SAY "Pritisni bilo sta za listanje !"
      INKEY(0)
      red=6
      aa=0
      @ 6,0 CLEAR TO 23,79
      IF LASTKEY()=27
        EXIT
      ENDIF
    ENDIF
  ENDDO
  @ red,1 SAY "  "
  EXIT
ENDDO
IF bb=0
  SET CONFIRM OFF
  CLEAR SCREEN
  CLOSE DATABASES
  RETURN
ENDIF
@ 23,1 CLEAR
*Upit za stampu*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
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
  aa=0
  red=6
  m_kst=0
  p_kst=0
  m_art=0
  m_knt=0
  m_nza=SPACE(42)
  m_jmr=SPACE(3)
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  SELECT 1
  USE Prom INDEX prombd
  GO TOP
  SEEK STR(m_stv,3)+STR(m_mat,2)+STR(m_dob,6)
  m_art=art
  CLEAR SCREEN
  *Ispis svih nadjenih zadatih podataka do kraja databaze*
  DO WHILE m_stv=stv .AND. m_mat=vrs .AND. m_dob=dob .AND.;
           m_art=art .AND. ! EOF()
    DO WHILE (m_art=art)
      IF m_art=art .AND. osu="10"
        m_kst=m_kst+kst
        SKIP
        LOOP
      ELSEIF m_art=art .AND. osu="15"
        m_kst=m_kst-kst
        SKIP
        LOOP
      ELSEIF m_art=art
        SKIP
        LOOP
      ENDIF
    ENDDO
    bb=1
    *Ispis zaglavlja - prvi ispis stranice*
    IF aa=0
      @ 1,1 SAY "             UTROSAK NOVOG U TOKU 20"+SUBSTR(DTOC(DATE()),7,2)+".god. U STOVARISTU "+STR(m_stv,3)
      @ 2,1 SAY "SEKTOR (SERIJA) : "+STR(m_sek,3)+"  SEKCIJA (BROJ VOZILA) : "+STR(m_sec,3)+"                  "+DTOC(DATE())
      @ 3,1 SAY "----------------------------------------------------------------------------"
      @ 4,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO    KOLICINA"
      @ 5,1 SAY "----------------------------------------------------------------------------"
      aa=1
    ENDIF
    SELECT 2
    USE Matc INDEX matcid
    GO TOP
    SEEK m_art
    *Pretraga artikla u maticnoj bazi*
    IF FOUND()
      IF jmr="  "
        m_nza="Nepoznat naziv ?                          "
        m_knt=0
        m_jmr="   "
      ELSE
        m_nza=nza
        m_knt=knt
        m_jmr=taj[VAL(jmr)]
      ENDIF
    ELSE
      m_nza="Nepoznat naziv ?                          "
      m_knt=0
      m_jmr="   "
    ENDIF
    p_kst=m_kst/1000
    m_kst=0
    IF p_kst=0
    ELSE
      @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(p_kst,10,3)
      red=red+1
    ENDIF
    m_art=A->art
    SELECT 1
    IF red > 54
      red=6
      aa=0
    ENDIF
  ENDDO
  @ red,1 SAY "  "
ELSE
  SET DEVICE TO SCREEN
  @ 20,1 CLEAR TO 23,79
  @ 23,1 SAY "Odustao si od stampe !"
  INKEY(2)
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN


***************************************
PROCEDURE s_uku
* S_UKU.PRG SUMARNA NABAVKA ARTIKALA ZA JEDNO STOVARISTA
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 2,3  SAY "S_UKU"
@ 2,25 SAY "SUMARNA NABAVKA ZA STOVARISTE"
@ 2,61 SAY "''ESC'' za kraj"
*Postavka promenljivih*
m_stv=0
m_kst=0
p_kst=0
m_art=0
m_knt=0
m_nza=SPACE(42)
m_jmr=SPACE(3)
m_odl="N"
aa=0
bb=0
*Matrica jedinica mere*
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
red=6
*Zaglavlje*
@  6,1 SAY "Izgled liste :"
@  8,1 SAY "                NABAVKA U TOKU xxxx GODINE U STOVARISTU xxx"
@ 10,1 SAY "---------------------------------------------------------------------------"
@ 11,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO   KOLICINA"
@ 12,1 SAY "---------------------------------------------------------------------------"
*Postavka radnih polja*
SELECT 1
USE Prom INDEX promvd
GO TOP
SELECT 2
USE Matc INDEX matcid
GO TOP
@ 15,9 CLEAR
DO WHILE .T.
  *Unos podataka za tretragu*
  @ 14,10 SAY "Sifra STOVARISTA  : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  READ
  IF LASTKEY() = 27
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SELECT 1
  USE Prom INDEX promvd
  GO TOP
  SEEK STR(m_stv,3)
  IF ! FOUND()
    @ 14,40 SAY "Tog stovarista nema u promenama !"
    INKEY(2)
    @ 14,40 SAY "                                 "
    m_stv=0
    LOOP
  ENDIF
  m_art=art
  CLEAR SCREEN
  *Ispis nadjenih zadatih kombinacija*
  DO WHILE m_stv=stv .AND. ! EOF()
    IF aa=0
      @ 1,18SAY "NABAVKA U TOKU 20"+SUBSTR(DTOC(DATE()),7,2)+".god. U STOVARISTU "+STR(m_stv,3)
      @ 2,1 SAY "MAT 01 i osnovi 00 i 05"
      @ 2,69SAY DTOC(DATE())
      @ 3,1 SAY "----------------------------------------------------------------------------"
      @ 4,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO    KOLICINA"
      @ 5,1 SAY "----------------------------------------------------------------------------"
      aa=1
    ENDIF
    bb=1
    IF m_art=art .AND. vrs=01 .AND. osu="00"
      m_kst=m_kst+kst
      SKIP
      LOOP
    ELSEIF m_art=art .AND. vrs=01 .AND. osu="05"
      m_kst=m_kst-kst
      SKIP
      LOOP
    ELSEIF m_art=art
      SKIP
      LOOP
    ENDIF
    IF m_kst=0
      m_art=A->art
      LOOP
    ENDIF
    SELECT 2
    USE Matc INDEX matcid
    GO TOP
    *Pretraga artikla u maticnoj bazi podataka*
    SEEK m_art
    IF FOUND()
      IF jmr="  "
        m_nza="Nepoznat naziv ?                          "
        m_knt=0
        m_jmr="   "
      ELSE
        m_nza=nza
        m_knt=knt
        m_jmr=taj[VAL(jmr)]
      ENDIF
    ELSE
      m_nza="Nepoznat naziv ?                          "
      m_knt=0
      m_jmr="   "
    ENDIF
    p_kst=m_kst/1000
    m_kst=0
    @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(p_kst,10,3)
    m_art=A->art
    red=red+1
    SELECT 1
    *Ispis je stigao do kraja ekrana*
    IF red > 22
      @ 23,1 SAY "Pritisni bilo sta za listanje !"
      INKEY(0)
      red=6
      aa=0
      @ 6,0 CLEAR TO 23,79
      IF LASTKEY()=27
        EXIT
      ENDIF
    ENDIF
  ENDDO
  IF m_kst>0
    SELECT 2
    USE Matc INDEX matcid
    GO TOP
    *Pretraga artikla u maticnoj databazi*
    SEEK m_art
    IF FOUND()
      m_nza=nza
      m_knt=knt
      m_jmr=taj[VAL(jmr)]
    ELSE
      m_nza="Nepoznat naziv ?                          "
      m_knt=0
      m_jmr="   "
    ENDIF
    p_kst=m_kst/1000
    m_kst=0
    @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(p_kst,10,3)
  ENDIF
  red=red+1
  @ red,1 SAY "  "
  EXIT
ENDDO
IF bb=0
  SET CONFIRM OFF
  CLEAR SCREEN
  CLOSE DATABASES
  RETURN
ENDIF
@ 23,1 CLEAR
*Upit za stampanje*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
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
  aa=0
  red=6
  m_kst=0
  p_kst=0
  m_art=0
  m_knt=0
  m_nza=SPACE(42)
  m_jmr=SPACE(3)
  SET DEVICE TO PRINT
  * SET PRINTER TO STAMPA
  SELECT 1
  USE Prom INDEX promvd
  GO TOP
  SEEK STR(m_stv,3)
  m_art=art
  CLEAR SCREEN
  *Ispis svih kombinacija za zadato stovariste*
  DO WHILE m_stv=stv .AND. ! EOF()
    IF aa=0
      @ 1,18SAY "NABAVKA U TOKU 20"+SUBSTR(DTOC(DATE()),7,2)+".god. U STOVARISTU "+STR(m_stv,3)
      @ 2,1 SAY "MAT 01 i osnovi 00 i 05"
      @ 2,69SAY DTOC(DATE())
      @ 3,1 SAY "----------------------------------------------------------------------------"
      @ 4,1 SAY " ARTIKAL         NAZIV                                JMR  KONTO    KOLICINA"
      @ 5,1 SAY "----------------------------------------------------------------------------"
      aa=1
    ENDIF
    bb=1
    IF m_art=art .AND. vrs=01 .AND. osu="00"
      m_kst=m_kst+kst
      SKIP
      LOOP
    ELSEIF m_art=art .AND. vrs=01 .AND. osu="05"
      m_kst=m_kst-kst
      SKIP
      LOOP
    ELSEIF m_art=art
      SKIP
      LOOP
    ENDIF
    IF m_kst=0
      m_art=A->art
      LOOP
    ENDIF
    SELECT 2
    USE Matc INDEX matcid
    GO TOP
    *Pretraga artikla u maticnoj*
    SEEK m_art
    IF FOUND()
      IF jmr="  "
        m_nza="Nepoznat naziv ?                          "
        m_knt=0
        m_jmr="   "
      ELSE
        m_nza=nza
        m_knt=knt
        m_jmr=taj[VAL(jmr)]
      ENDIF
    ELSE
      m_nza="Nepoznat naziv ?                          "
      m_knt=0
      m_jmr="   "
    ENDIF
    p_kst=m_kst/1000
    m_kst=0
    @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(p_kst,10,3)
    m_art=A->art
    red=red+1
    SELECT 1
    IF red > 54
      red=6
      aa=0
    ENDIF
  ENDDO
  IF m_kst>0
    SELECT 2
    USE Matc INDEX matcid
    GO TOP
    SEEK m_art
    *Pretraga artikla u maticnoj*
    IF FOUND()
      m_nza=nza
      m_knt=knt
      m_jmr=taj[VAL(jmr)]
    ELSE
      m_nza="Nepoznat naziv ?                          "
      m_knt=0
      m_jmr="   "
    ENDIF
    p_kst=m_kst/1000
    m_kst=0
    @ red,1 SAY STR(m_art,10)+" "+m_nza+" "+m_jmr+" "+STR(m_knt,7)+" "+STR(p_kst,10,3)
  ENDIF
  red=red+1
  @ red,1 SAY "  "
ELSE
  SET DEVICE TO SCREEN
  @ 20,1 CLEAR TO 23,79
  @ 23,1 SAY "Odustao si od stampe !"
  INKEY(2)
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN


********************
*Stampa sa klizanjem
********************


PROCEDURE s_ppp
* S_PPP.PRG STAMPA SA KLIZANJEM
SET CURSOR OFF
CLEAR SCREEN
*Promenljive*
brr=1
rrr=0
red=6
SELECT 1
USE tpriv
DO WHILE .T.
  *Brise u izabranom delu*
  @ 20,1 CLEAR TO 23,78
  *Ispis polja iz TPRIV.DBF*
  @ red,3 SAY vrs+"  "+osn+"  "+dob
  *Sledeci slog*
  SKIP
  *Ako stigne do kraja*
  IF EOF()
    rrr=1
    @ 22,1 SAY "Nema vise podataka"
    INKEY(0)
    IF LASTKEY()=27
      EXIT
    ENDIF
*   red=15
  ENDIF
  *Sledeci red*
  red=red+1
  *Ako je krajnji red*
  IF red=16
    INKEY(0)
    *Pritisnuto je dugme za "DOLE", a baza je izlistana do kraja*
    IF LASTKEY()=24 .AND. rrr=1
      @ 23,1 SAY "Rekao sam ti da nema vise podataka !"
      INKEY(0)
    *Pritisnuto je dugme za "DOLE", a baza nije stigla do kraja*
    ELSEIF LASTKEY()=24
      rrr=0
      @ 6,1 CLEAR TO 23,78
      red=6
      brr=brr+1
      USE tpriv
      GO brr
      LOOP
    *Pritisnuto je dugme za dole*
    ELSEIF LASTKEY()=5
      *Prati sta je zadnje pritisnuto "GORE" ili "DOLE"*
      brr=brr-1
      *Parametar za vrh*
      IF brr=0
        brr=1
        @ 22,1 SAY "Na vrhu si !"
        INKEY(2)
      ENDIF
      *Parametar za kraj baze*
      rrr=0
      @ 6,1 CLEAR TO 23,78
      red=6
      GO brr
      LOOP
    *Omogucuje izlazak iz petlje ako je pritisnuto bilo sta drugo*
    ELSE
      EXIT
    ENDIF
    *Parametar za kraj baze*
    IF rrr=1
      @ 21,1 CLEAR TO 23,78
      red=6
      rrr=0
      GO brr
      LOOP
    ENDIF
  ENDIF
ENDDO
SET CURSOR ON
CLOSE DATABASES
CLEAR SCREEN
RETURN


********************
******************* Nabavka za zimu - na kraju
********************


PROCEDURE s_nab
* S_NAB.PRG PROGRAM ZA PRACENJE ZIME
SET CONFIRM ON
CLEAR SCREEN
DO WHILE .T.
  *Okvir*
  @ 1,0 TO 3,78 DOUBLE
  @ 5,0 TO 23,78 DOUBLE
  @ 2,3 SAY "S_NAB"
  @ 2,25 SAY "ZIMSKE PRIPREME"
  @ 2,61 SAY "''ESC'' za kraj"
  *Unos podataka*
  m_izbor=1
  @ 7,15 PROMPT " STANJE PO STOVARISTIMA ";
         MESSAGE "STANJE SVIH OZNACENIH ARTIKALA"
  @ 7,45 PROMPT " PROMENE ZA PERIOD ";
         MESSAGE "SVE PROMENE ZA ODREDJENI PERIOD"
  CLEAR TYPEAHEAD
  MENU TO m_izbor
  *Poziv programa po izboru*
  DO CASE
    CASE LASTKEY()=27
         EXIT
    CASE m_izbor=1
         DO zim_sta
    CASE m_izbor=2
         DO zim_pro
    OTHERWISE
         EXIT
  ENDCASE
ENDDO
CLEAR SCREEN
RETURN


**********************************************************


PROCEDURE ZIM_STA
SET CONFIRM ON
CLEAR SCREEN
*Okvir*
@ 1,0 TO 3,78 DOUBLE
@ 5,0 TO 23,78 DOUBLE
@ 2,3 SAY "ZIM_STA"
@ 2,25 SAY "STANJE ZA ZIMU"
@ 2,61 SAY "''ESC'' za kraj"
*Postavka promenljivih*
m_ozn=0
m_art=0
m_nza=0
m_jmr=0
m_stv=0
m_kst=0
p_kst=0
aa=0
nn=0
ib=0
red=6
m_odl="N"
*Zaglavlje*
@  9,2 SAY "Izgled liste :"
@ 10,2 SAY "               PREGLED STANJA ARTIKALA ZA ZIMU"
@ 12,2 SAY "-------------------------------------------------------------------------"
@ 13,2 SAY "  ARTIKAL    NAZIV                                  JMR   STV    KOLICINA"
@ 14,2 SAY "-------------------------------------------------------------------------"
*Unos oznake - sifre*
DO WHILE .T.
  @ 16,10 SAY "Oznaka       : " GET m_ozn PICTURE "9";
          VALID(m_ozn>0)
  READ
  *Izlazak - "Esc"*
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  *Postavka radnih polja*
  SELECT 1
  USE stan INDEX stanad
  GO TOP
  SELECT 2
  USE matc INDEX matcod
  GO TOP
  *Pretrazuje zadatu oznaku*
  SEEK STR(m_ozn,1)
  *Nije nadjeno*
  IF ! FOUND()
    @ 22,3 SAY "Nema podataka za tu OZN !"
    INKEY(3)
    @ 22,3 SAY "                         "
    m_ozn=0
    LOOP
  ENDIF
  *Preuzima podatke*
  m_art=art
  m_nza=nza
  m_jmr=jmr
  CLEAR SCREEN
  *Ispisuje sve slogove (polja) sa zadatom sifrom artikla*
  DO WHILE m_art=art
    SELECT 1
    SEEK STR(m_art,10)
    *Ako nije nadjen trazeni artikal*
    IF ! FOUND()
      SELECT 2
      SKIP
      *Uzima sledecu oznaku koja odgovara trazenoj*
      IF ozn=m_ozn
        m_art=art
        m_nza=nza
        m_jmr=jmr
        LOOP
      ELSE
        EXIT
      ENDIF
    ENDIF
    *Sve osim novog (kon=1)*
    IF kon=1
    ELSE
      SELECT 2
      SKIP
      *Uzima oznaku*
      IF ozn=m_ozn
        m_art=art
        m_nza=nza
        m_jmr=jmr
        LOOP
      ELSE
        EXIT
      ENDIF
    ENDIF
    m_stv=stv
    *Ispisuje za zadat artikal u stovaristu*
    DO WHILE m_art=art
      *Prvi ispis stranice - zaglavlja*
      IF aa=0
        @ 1,1 SAY "               PREGLED STANJA ARTIKALA ZA ZIMU "
        @ 2,1 SAY "Lista "+STR(m_ozn,1)+"                                                            "+DTOC(DATE())
        @ 3,1 SAY "---------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL     NAZIV ARTIKLA                           JMR  STV     KOLICINA"
        @ 5,1 SAY "---------------------------------------------------------------------------"
        aa=1
      ENDIF
      m_kst=kst/1000
      p_kst=p_kst+m_kst
      *Ispis stovarista i krajnjeg stanja, ako je artikal na "novo"*
      IF ib=1
        @ red,60 SAY STR(m_stv,3)+"  "+STR(m_kst,11,3)
        ib=0
      ELSE
        @ red,1 SAY STR(art,10)+" "+m_nza+"  "+m_jmr+"  "+STR(m_stv,3)+"  "+STR(m_kst,11,3)
      ENDIF
      *Sledeci red*
      red=red+1
      *Brojac*
      nn=nn+1
      *Granicnik ispisa na ekranu*
      IF red > 21
        red=6
        aa=0
        @ 23,1 SAY "Pritisni bilo sta za listanje !"
        INKEY(0)
        IF LASTKEY()=27
          EXIT
        ENDIF
        @ 6,0 CLEAR TO 23,79
      ENDIF
      SELECT 1
      *Sta da radi ako je kraj baze*
      DO WHILE ! EOF()
        SKIP
        *Ako odgovara artikal*
        IF m_art=art
          IF kon=1
            m_stv=stv
            ib=1
            EXIT
          ELSE
            nn=0
            p_kst=0
            LOOP
          ENDIF
        *Ako artikal nije isti*
        ELSE
          IF nn>1
            @ red,64 SAY "============"
            red=red+1
            @ red,55 SAY "Ukupno :  "+STR(p_kst,11,3)
            red=red+1
          ENDIF
          nn=0
          m_stv=stv
          p_kst=0
          EXIT
        ENDIF
      ENDDO
    ENDDO
    SELECT 2
    SKIP
    *Ako odgovara oznaka*
    IF ozn=m_ozn
      m_art=art
      m_nza=nza
      m_jmr=jmr
      LOOP
    ELSE
      EXIT
    ENDIF
    LOOP
  ENDDO
  IF nn>1
    @ red,64 SAY "============"
    red=red+1
    @ red,55 SAY "Ukupno :  "+STR(p_kst,11,3)
  ENDIF
  @ red,1 SAY "  "
  EXIT
ENDDO
IF LASTKEY() = 27
  SET CONFIRM OFF
  CLEAR SCREEN
  CLOSE DATABASES
  RETURN
ENDIF
*Upit za stampanje*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *Printer nije ukljucen*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SET DEVICE TO PRINT
  *  SET PRINTER TO STAMPA
  m_art=0
  m_nza=0
  m_jmr=0
  m_kst=0
  p_kst=0
  aa=0
  nn=0
  red=6
  SELECT 1
  USE stan INDEX stanad
  GO TOP
  SELECT 2
  USE matc INDEX matcod
  GO TOP
  SEEK STR(m_ozn,1)
  m_art=art
  m_nza=nza
  m_jmr=jmr
  CLEAR SCREEN
  *Radi dok ART odgovara tazenom*
  DO WHILE m_art=art
    SELECT 1
    *Pretrazuje u stanju*
    SEEK STR(m_art,10)
    IF ! FOUND()
      SELECT 2
      *Prebacuje sledeci slog u maticnoj*
      SKIP
      IF ozn=m_ozn
        m_art=art
        m_nza=nza
        m_jmr=jmr
        LOOP
      ELSE
        EXIT
      ENDIF
    ENDIF
    IF kon=1
    ELSE
      SELECT 2
      *Sledeci red u maticnoj*
      SKIP
      IF ozn=m_ozn
        m_art=art
        m_nza=nza
        m_jmr=jmr
        LOOP
      ELSE
        EXIT
      ENDIF
    ENDIF
    m_stv=stv
    *Za sve nadjene artikle prema zadatom*
    DO WHILE m_art=art
      IF aa=0
        @ 1,1 SAY "               PREGLED STANJA ARTIKALA ZA ZIMU "
        @ 2,1 SAY "Lista "+STR(m_ozn,1)+"                                                            "+DTOC(DATE())
        @ 3,1 SAY "---------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL     NAZIV ARTIKLA                           JMR  STV     KOLICINA"
        @ 5,1 SAY "---------------------------------------------------------------------------"
        aa=1
      ENDIF
      m_kst=kst/1000
      p_kst=p_kst+m_kst
      IF ib=1
        @ red,60 SAY STR(m_stv,3)+"  "+STR(m_kst,11,3)
        ib=0
      ELSE
        @ red,1 SAY STR(art,10)+" "+m_nza+"  "+m_jmr+"  "+STR(m_stv,3)+"  "+STR(m_kst,11,3)
      ENDIF
      red=red+1
      nn=nn+1
      IF red > 60
        red=6
        aa=0
      ENDIF
      SELECT 1
      *Radi do kraja*
      DO WHILE ! EOF()
        SKIP
        *Ako artikal odgovara*
        IF m_art=art
          *Novo*
          IF kon=1
            m_stv=stv
            ib=1
            EXIT
          ELSE
            nn=0
            p_kst=0
            LOOP
          ENDIF
        ELSE
          *Nije prvi ispis*
          IF nn>1
            @ red,64 SAY "============"
            red=red+1
            @ red,55 SAY "Ukupno :  "+STR(p_kst,11,3)
            red=red+1
          ENDIF
          nn=0
          m_stv=stv
          p_kst=0
          EXIT
        ENDIF
      ENDDO
    ENDDO
    SELECT 2
    *Sledeci slog u maticnoj*
    SKIP
    IF ozn=m_ozn
      m_art=art
      m_nza=nza
      m_jmr=jmr
      LOOP
    ELSE
      EXIT
    ENDIF
    LOOP
  ENDDO
  *Nije prvi red*
  IF nn>1
    @ red,64 SAY "============"
    red=red+1
    @ red,55 SAY "Ukupno :  "+STR(p_kst,11,3)
  ENDIF
  @ red,1 SAY "  "
ENDIF
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN


**********************************************************


PROCEDURE ZIM_PRO
SET CONFIRM ON
CLEAR SCREEN
*Postavka okvira*
@ 1,0 TO 3,78 DOUBLE
@ 5,0 TO 23,78 DOUBLE
@ 2,3 SAY "ZIM_STA"
@ 2,25 SAY "STANJE ZA ZIMU"
@ 2,61 SAY "''ESC'' za kraj"
*Postavka promenljivih*
m_stv=0
m_ozn=0
m_dat=DATE()
m_da1=SPACE(8)
p_da1=SPACE(4)
v_da1=0
m_da2=SPACE(8)
p_da2=SPACE(4)
v_da2=0
m_art=0
m_nza=0
m_jmr=0
m_kst=0
u_kst=0
i_kst=0
s_kst=0
aa=0
nn=0
ib=0
red=6
m_odl="N"
*Zaglavlje*
@  9,2 SAY "Izgled liste :"
@ 10,2 SAY "                      PREGLED PROMENA ZA ZIMU"
@ 12,2 SAY "-------------------------------------------------------------------------"
@ 13,2 SAY "  ARTIKAL    NAZIV                            JMR   SS    UL    IZ    NS"
@ 14,2 SAY "-------------------------------------------------------------------------"
*Unos podataka*
DO WHILE .T.
  @ 15,10 SAY "Stovariste   : " GET m_stv PICTURE "999";
          VALID(m_stv>0)
  @ 17,10 SAY "Oznaka       : " GET m_ozn PICTURE "9";
          VALID(m_ozn>0)
  @ 19,10 SAY "Datum        : " GET m_dat PICTURE "@D"
  READ
  *Izlazak - "Esc"*
  IF LASTKEY() = 27
    CLEAR SCREEN
    SET CONFIRM OFF
    CLOSE DATABASES
    RETURN
  ENDIF
  *Postavka radnih polja*
  SELECT 1
  USE stan INDEX stanad
  GO TOP
  SELECT 3
  USE prom INDEX promdd
  GO TOP
  SELECT 2
  USE matc INDEX matcod
  GO TOP
  SEEK STR(m_ozn,1)
  *Nije nadjeno*
  IF ! FOUND()
    @ 22,3 SAY "Nema podataka u MATC za tu OZN !"
    INKEY(3)
    @ 22,3 SAY "                                "
    m_stv=0
    m_ozn=0
    m_dat=DATE()
    LOOP
  ENDIF
  m_art=art
  m_nza=nza
  m_jmr=jmr
  CLEAR SCREEN
  *Radi dok ima trazenog artikla*
  DO WHILE m_art=art
    SELECT 1
    *Trazi na stanju*
    SEEK STR(m_art,10)
    *Nije nadjeno*
    IF ! FOUND()
      SELECT 2
      *Trazi u maticnoj*
      SKIP
      IF ozn=m_ozn
        m_art=art
        m_nza=nza
        m_jmr=jmr
        LOOP
      ELSE
        EXIT
      ENDIF
    ENDIF
    *Ako nije novo*
    IF kon=1
    ELSE
      SELECT 2
      SKIP
      IF ozn=m_ozn
        m_art=art
        m_nza=nza
        m_jmr=jmr
        LOOP
      ELSE
        EXIT
      ENDIF
    ENDIF
    m_stv=stv
    *Radi dok artikal odgovara trazenom*
    DO WHILE m_art=art
      IF aa=0
        @ 1,1 SAY "                        PREGLED PROMENA ZA ZIMU"
        @ 2,1 SAY "Stovariste "+STR(stv,3)+"   Lista "+STR(m_ozn,1)
        @ 2,70SAY DTOC(DATE())
        @ 3,1 SAY "------------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL     NAZIV ARTIKLA                      JMR     SS    UL    IZ    NS"
        @ 5,1 SAY "------------------------------------------------------------------------------"
        aa=1
      ENDIF
      *Uzima krajnje stanje iz promena*
      m_kst=kst
      SELECT 3
      SEEK STR(m_stv,3)+STR(m_art,10)
      *Poljae koje je uvek nula*
      IF mss=0
        *Nadjeno je*
        IF FOUND()
          *Uneti datum pretvara u karakter*
          m_da1=DTOS(m_dat)
          *Uzima mesec i dan*
          p_da1=SUBSTR(m_da1,5,4)
          *Konvertuje znakovni u numericki niz*
          v_da1=VAL(p_da1)
          *Radi za odredjenu kombinaciju STV i ART do kraja baze*
          DO WHILE m_stv=stv .AND. m_art=art .AND. ! EOF()
            *Uzima datum iz promena*
            m_da2=DTOS(dat)
            *Odvaja mesec i dan*
            p_da2=SUBSTR(m_da2,5,4)
            *Pretvara karakter u numerik*
            v_da2=VAL(p_da2)
            *Ako je uneti datum manji od onoga iz baze*
            IF v_da2 >= v_da1
              *Osnov - sifra*
              *Ulaz*
              IF osu < "05"
                u_kst=u_kst+kst
              *Storno ulaza*
              ELSEIF osu < "10"
                u_kst=u_kst-kst
              *Izlaz*
              ELSEIF osu < "15"
                i_kst=i_kst+kst
              *Storno izlaza*
              ELSEIF osu < "20"
                i_kst=i_kst-kst
              ENDIF
              SKIP
              LOOP
            ELSE
              SKIP
              LOOP
            ENDIF
          ENDDO
          *staro stanje=momentalno stanje+izlazno stanje-ulazno stanje*
          s_kst=m_kst+i_kst-u_kst
          *Ispis podataka *
          @ red,1  SAY STR(m_art,10)+" "+SUBSTR(m_nza,1,38)+" "+m_jmr
          @ red,54 SAY STR(s_kst/1000,6)+STR(u_kst/1000,6)
          @ red,66 SAY STR(i_kst/1000,6)+STR(m_kst/1000,6)
          *Novi red*
          red=red+1
          *Ciscenje promenljivih*
          m_kst=0
          i_kst=0
          u_kst=0
          s_kst=0
          EXIT
        *Nije nadjeno*
        ELSE
          @ red,1  SAY STR(m_art,10)+" "+SUBSTR(m_nza,1,38)+" "+m_jmr
          @ red,72 SAY STR(m_kst/1000,6)
          red=red+1
          EXIT
        ENDIF
      ENDIF
      SKIP
    ENDDO
    *Ako je ispis stigao do kraja ekrana*
    IF red=22
      aa=0
      red=6
      @ 23,1 SAY "Pritisni bilo sta za listanje !"
      INKEY(0)
      IF LASTKEY()=27
        EXIT
      ENDIF
      @ 6,0 CLEAR TO 23,79
    ENDIF
    SELECT 2
    *Novi red u maticnoj*
    SKIP
    *Preuzimanje vrednosti polja*
    m_art=art
    m_nza=nza
    m_jmr=jmr
    LOOP
  ENDDO
  EXIT
ENDDO
IF LASTKEY() = 27
  SET CONFIRM OFF
  CLEAR SCREEN
  CLOSE DATABASES
  RETURN
ENDIF
*Upit za stampanje*
@ 23,1 SAY "Da li hoces da stampas ovaj izvestaj (D/N) ?";
       GET m_odl PICTURE "!" VALID (m_odl $ "DdNn")
READ
*Ciscenje promenljivih*
m_kst=0
u_kst=0
i_kst=0
s_kst=0
aa=0
nn=0
ib=0
red=6
IF m_odl="D" .OR. m_odl="d"
  @ 15,1 CLEAR TO 23,79
  @ 16,10 SAY "Ukljuci stampac !"
  @ 18,10 SAY "Namesti USKI papir i pritisni bilo sta !"
  @ 0,0 SAY " "
  INKEY(0)
  *Provera printera*
  IF ! ISPRINTER()
    @ 20,10 SAY "Odustao si od stampe !"
    INKEY(2)
    SET CONFIRM OFF
    CLEAR SCREEN
    CLOSE DATABASES
    RETURN
  ENDIF
  SET DEVICE TO PRINT
  *  SET PRINTER TO STAMPA
  *Postavka promenljivih*
  SELECT 1
  USE stan INDEX stanad
  GO TOP
  SELECT 3
  USE prom INDEX promdd
  GO TOP
  SELECT 2
  USE matc INDEX matcod
  GO TOP
  SEEK STR(m_ozn,1)
  m_art=art
  m_nza=nza
  m_jmr=jmr
  CLEAR SCREEN
  *Radi sve dok ima zadatog artikla*
  DO WHILE m_art=art
    SELECT 1
    SEEK STR(m_art,10)
    *Nije nadjeno*
    IF ! FOUND()
      SELECT 2
      *Sledeci slog u maticnoj*
      SKIP
      IF ozn=m_ozn
        m_art=art
        m_nza=nza
        m_jmr=jmr
        LOOP
      ELSE
        EXIT
      ENDIF
    ENDIF
    *Kontra uslov da artikal nije novi*
    IF kon=1
    ELSE
      SELECT 2
      SKIP
      IF ozn=m_ozn
        m_art=art
        m_nza=nza
        m_jmr=jmr
        LOOP
      ELSE
        EXIT
      ENDIF
    ENDIF
    *Uzima stovariste*
    m_stv=stv
    *Radi dok vazi zadati artikal*
    DO WHILE m_art=art
      *Prvi ispis stranice*
      IF aa=0
        @ 1,1 SAY "                        PREGLED PROMENA ZA ZIMU"
        @ 2,1 SAY "Stovariste "+STR(stv,3)+"   Lista "+STR(m_ozn,1)
        @ 2,70SAY DTOC(DATE())
        @ 3,1 SAY "------------------------------------------------------------------------------"
        @ 4,1 SAY "  ARTIKAL     NAZIV ARTIKLA                      JMR     SS    UL    IZ    NS"
        @ 5,1 SAY "------------------------------------------------------------------------------"
        aa=1
      ENDIF
      m_kst=kst
      SELECT 3
      *Pretraga zadatog stovarista i artikla*
      SEEK STR(m_stv,3)+STR(m_art,10)
      IF FOUND()
        *Sredjivanje zadatog datuma*
        m_da1=DTOS(m_dat)
        p_da1=SUBSTR(m_da1,5,4)
        v_da1=VAL(p_da1)
        *Obradjuje zadato stovariste i artikal do kraja baze*
        DO WHILE m_stv=stv .AND. m_art=art .AND. ! EOF()
          *Sredjuje datum iz baze*
          m_da2=DTOS(dat)
          p_da2=SUBSTR(m_da2,5,4)
          v_da2=VAL(p_da2)
          *Ako je uneti adatum manji od onog iz baze*
          IF v_da2 >= v_da1
            *Osnovi*
            IF osu < "05"
              u_kst=u_kst+kst
            ELSEIF osu < "10"
              u_kst=u_kst-kst
            ELSEIF osu < "15"
              i_kst=i_kst+kst
            ELSEIF osu < "20"
              i_kst=i_kst-kst
            ENDIF
            SKIP
            LOOP
          ELSE
            SKIP
            LOOP
          ENDIF
        ENDDO
        *Racuna staro krajnje stanje*
        s_kst=m_kst+i_kst-u_kst
        *Ispis podataka*
        @ red,1  SAY STR(m_art,10)+" "+SUBSTR(m_nza,1,38)+" "+m_jmr
        @ red,54 SAY STR(s_kst/1000,6)+STR(u_kst/1000,6)
        @ red,66 SAY STR(i_kst/1000,6)+STR(m_kst/1000,6)
        *Novi red za ispis*
        red=red+1
        *Ciscenje promenljivih*
        m_kst=0
        i_kst=0
        u_kst=0
        s_kst=0
        EXIT
      *Nije nasao*
      ELSE
        @ red,1  SAY STR(m_art,10)+" "+SUBSTR(m_nza,1,38)+" "+m_jmr
        @ red,72 SAY STR(m_kst/1000,6)
        red=red+1
        EXIT
      ENDIF
    ENDDO
    *Kraj lista pa pise od pocetka*
    IF red=60
      aa=0
      red=6
    ENDIF
    SELECT 2
    SKIP
    m_art=art
    m_nza=nza
    m_jmr=jmr
    LOOP
  ENDDO
ENDIF
@ red,1 SAY "  "
SET DEVICE TO SCREEN
SET CONFIRM OFF
CLEAR SCREEN
CLOSE DATABASES
RETURN





