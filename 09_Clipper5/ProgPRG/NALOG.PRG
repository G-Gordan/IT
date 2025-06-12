***********************************************************
* NALOG.PRG - PROGRAM ZA VODJENJE I PREGLED PUTNIH NALOGA *
***********************************************************
CLEAR ALL
SET SCOREBOARD OFF
SET WRAP ON
SET DELETE ON
SET CURSOR OFF
SET CONFIRM OFF
SET DATE GERMAN
SET MESSAGE TO 24 CENTER
SET COLOR TO W+/N
CLEAR SCREEN
@ 2,11 TO 17,64 DOUBLE
@ 1,8  TO 18,67 DOUBLE
@ 4,15 SAY "п      мллллллп     млллллллллллллллллллл" COLOR "R/N"
INKEY(0.04)
@ 5,15 SAY "     мллллллп     млллллллллллллллллллллл" COLOR "R/N"
INKEY(0.04)
@ 6,15 SAY "   мллллллп     млллллп"                   COLOR "R/N"
INKEY(0.04)
@ 7,15 SAY " мллллллп     млллллп"                     COLOR "R/N"
INKEY(0.04)
@ 8,15 SAY "ллллллп     млллллп    млллллллллллллллллм" COLOR "B/N"
INKEY(0.04)
@ 9,15 SAY "ллллп     млллллп    млллллллллллллллллллллм" COLOR "B/N"
INKEY(0.04)
@10,15 SAY "ллп     млллллп    мллллп               пллллм" COLOR "B/N"
INKEY(0.04)
@11,15 SAY "п     млллллп    мллллп    jun 2002       лллл" COLOR "B/N"
INKEY(0.04)
@12,15 SAY "    млллллп    мллллп      COK Beograd  мллллп"
INKEY(0.04)
@13,15 SAY "  млллллп    млллллллллллллллллллллллллллллп"
INKEY(0.04)
@14,15 SAY "млллллп    млллллллллллллллллллллллллллллп"
INKEY(0.04)
@15,15 SAY "ллллп    млллллллллллллллллллллллллллллп"
INKEY(0.04)
@19,28 TO 21,49 DOUBLE
@20,34 SAY "Zalihe-soft"
INKEY(7.4)



**************************MANIPULACIJA PODACIMA***************************
************Manipulacija podacima izabrane baze podataka******************

**Javne promenljive**
PUBLIC m_prtbrs


*****Zadata baza*****
m_baza:="nalog"
m_baza:=ALLTRIM(LOWER(m_baza)) + ".dbf"
SELECT 4
USE &m_baza
m_brslbz:=LASTREC()
CLOSE

*Prebacivanje imena u proceduru za pretragu*
m_imbzpt:=m_baza

*****Formiranje i punjenje baze OSOB.DBF koja sadrzi oasobine polja*****
SELECT 5
IF FILE("osobx.dbf")
  CLOSE DATABASES
  ERASE osobx.dbf
ENDIF

***Baza OSOBX sadrzi: field_name, field_type, field_len, field_dec***
USE &m_baza
COPY TO osobx STRUCTURE EXTENDED
CLOSE
USE osobx
m_brslos:=LASTREC()
GO TOP

***Ubacivanje i rednog broja polja***
IF FILE("osob.dbf")
  CLOSE DATABASES
  ERASE osob.dbf
ENDIF

*****Formiranje baze OSOB.DBF*****
p_mtosob:=0
p_mtosob:=ARRAY(m_brslos,5)
p_mtosob[1,1]:="red_broj"
p_mtosob[1,2]:="N"
p_mtosob[1,3]:=3
p_mtosob[1,4]:=0
p_mtosob[2,1]:="field_name"
p_mtosob[2,2]:="C"
p_mtosob[2,3]:=10
p_mtosob[2,4]:=0
p_mtosob[3,1]:="field_type"
p_mtosob[3,2]:="C"
p_mtosob[3,3]:=1
p_mtosob[3,4]:=0
p_mtosob[4,1]:="field_len"
p_mtosob[4,2]:="N"
p_mtosob[4,3]:=3
p_mtosob[4,4]:=0
p_mtosob[5,1]:="field_dec"
p_mtosob[5,2]:="N"
p_mtosob[5,3]:=3
p_mtosob[5,4]:=0
DBCREATE("osob", p_mtosob)

SELECT 5
USE osobx
SELECT 3
USE osob

FOR g=1 TO m_brslos
  APPEND BLANK
  REPLACE red_broj WITH g , field_name WITH E->field_name ,;
          field_type WITH E->field_type , field_len WITH E->field_len ,;
          field_dec WITH E->field_dec
  SELECT 5
  SKIP
  SELECT 3
NEXT

m_brsl:=RECCOUNT()
m_brslpt:=m_brsl

***Obelezavanje neregularnog "C" polja sa "888"***
p_ubaciti:=888
GO TOP
DO WHILE .T.
 IF field_type="C" .AND. field_len=0
  REPLACE field_len WITH p_ubaciti , field_dec WITH p_ubaciti
 ELSEIF field_type="C" .AND. field_dec#0
  REPLACE field_len WITH p_ubaciti , field_dec WITH p_ubaciti
 ENDIF
 SKIP
 IF EOF()
  EXIT
 ENDIF
ENDDO
GO TOP

*************************PRIKAZ NA EKRANU*************************
CLS

SELECT 4
USE &m_baza
GO TOP

***Boja okvira i zaglavlja***
SET COLOR TO "BG+/B"
@ 0,0 TO 24,79 DOUBLE COLOR "GR+/B"

***************Zaglavlje***************
***Boja poruka***
SET COLOR TO "G+/B"

***Postavka promenljivih***
m_pocpolje:=1
m_taster:="D"
m_deskrj:=1

m_gdlist:=1
m_promin:=" "
m_npromin:=0
m_dpromin:=DATE()

m_pokred:=5
m_pokkol:=0
m_pkol:=1
m_pred:=0
m_pomekr:="D"
m_prvoplj:="N"
m_zadnplj:="N"

m_trnslg:=1
IF m_brslbz=0
  m_trnslg:=0
ENDIF
m_skokna:=0
m_deljskok:=0
m_oduzskok:=0
m_trnplj:=1
m_brpslnd:="N"

m_novupis:="NIJE"
m_ponprt:="NE"
m_vrsprt:="  "
m_ispF10:="PRVI"
m_kortrp:="N"
m_upsnov:="N"
m_vrcprt:="N"


DO WHILE .T.

  **Uputstvo za uptrbu**
  @ 23,1 CLEAR TO 23,78
  *Ispisuje zavisno od potrebe (F10)*
  IF m_ispF10="PRVI"
    @ 23,6 SAY "Korak:"+CHR(24)+"-"+CHR(25)+"*Skok:PageUp"+CHR(24)+;
               "-PageDown"+CHR(25)+;
               "*Izmena:Enter*Izlaz:Esc*F10(F-5,6,8)" COLOR "G+/B"
  ELSEIF m_ispF10="DRUGI"
    @ 23,18 SAY "F5:Nov_slog*F6:Brise*F8:Trazi sve*F10:Pomoc" COLOR "G+/B"
  ENDIF
  SELECT 3
  GO m_pocpolje
  m_brmsuk:=0
  m_uzetoplj:=0
  m_pocmesto:=0

  ***Za DESNO (samo racuna parametre za ispis na ekranu)***
  IF m_taster="D" 
    DO WHILE .T.
      m_brmspl:=0
      m_brmsdc:=0
      m_uzetoplj:=m_uzetoplj+1
  
      m_brmspl:=field_len
      m_brmsdc:=field_dec

      ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
      IF m_brmspl<10
        m_brmspl:=10
      ENDIF
      
      ***Sabira polja koja treba da se prikazu***
      IF field_type="C" .AND. field_len=888 .AND. field_dec=888
        m_brmsuk:=m_brmsuk+1024+1
        IF m_brmsuk>1025 
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-1024-2
          EXIT
        ENDIF
      ELSE
        m_brmsuk:=m_brmsuk+m_brmspl+1
        IF m_brmsuk>74 .AND. m_uzetoplj=1
          m_brmsuk:=m_brmsuk-1
          EXIT
        ELSEIF m_brmsuk>74 .AND. m_uzetoplj>1
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-m_brmspl-2
          EXIT
        ENDIF
      ENDIF

      SKIP

      IF EOF() .AND. m_pocpolje>1
        m_kortrp:="D"
        m_pocpolje:=m_brsl+1
        m_taster:="L"
        IF m_zadnplj="D"
          m_zadnplj:="N"
        ELSE
          m_zadnplj:="D"
        ENDIF
        m_deskrj:=2
        GO m_brsl
        m_brmsuk:=0
        m_uzetoplj:=0
        m_pocmesto:=0        
        EXIT
      ELSEIF EOF() .AND. m_pocpolje=1
        m_brmsuk:=m_brmsuk-1
        EXIT
      ENDIF
    ENDDO
  ENDIF

  ***Za LEVO (samo racuna parametre za ispis na ekranu)***
  IF m_taster="L" 
    DO WHILE .T.
  
       IF m_deskrj=1
        SKIP-1
      ENDIF
  
      IF m_deskrj=2
        m_deskrj:=1
      ENDIF
      IF BOF()
        m_pocpolje:=1
        EXIT
      ENDIF
  
      m_brmspl:=0
      m_brmsdc:=0
      m_uzetoplj:=m_uzetoplj+1
  
      m_brmspl:=field_len
      m_brmsdc:=field_dec
  
      ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
      IF m_brmspl<10
        m_brmspl:=10
      ENDIF
  
      IF field_type="C" .AND. field_len=888 .AND. field_dec=888
        m_brmsuk:=m_brmsuk+1024+1
        IF m_brmsuk>1025
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-1024-2
          m_pocpolje:=m_pocpolje-m_uzetoplj
          EXIT
        ENDIF
      ELSE
        m_brmsuk:=m_brmsuk+m_brmspl+1
        IF m_brmsuk>74 .AND. m_uzetoplj=1
          m_pocpolje:=m_pocpolje-m_uzetoplj
          m_bemsuk:=m_brmsuk-1
          EXIT
        ELSEIF m_brmsuk>74 .AND. m_uzetoplj>1
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-m_brmspl-2
          m_pocpolje:=m_pocpolje-m_uzetoplj
          EXIT
        ENDIF
      ENDIF
    ENDDO
  ENDIF

  ***Ispis 's desna za kretanje u levo***
  IF m_taster="L" .AND. BOF()
    m_taster:="D"
    m_prvoplj:="D"
    m_brpslnd:="D"
    LOOP
  ENDIF

  *****Iracunavanje pocetka ispisa*****
  IF m_brmsuk>74
    m_brmsuk:=74
  ENDIF
  m_pocmesto:=39-INT(m_brmsuk/2)


  ***********************************
  **********   I S P I S   **********

  @ 2,1 CLEAR TO 22,78
  @ 4,1 TO 22,78 COLOR "GR+/B"

  ***** Ispis zaglavlja: ime polja, karakter, broj mesta i decimala *****
  *Promenljive zaglavlje*
  m_zpocmesto:=0
  m_brjc1:=0
  m_brmspl:=0
  m_brmsdc:=0
  m_prethisp:=0
  m_mestisp:=0
  m_redlin:=0
  m_kollin:=0
  m_brmpis:=0
  m_brmdis:=0

  m_kolpod:=0

  *Postavka matrica*
  p_mtrrbr:=0
  p_mtrrbr:=ARRAY(m_uzetoplj,1)
  p_mtrime:=" "
  p_mtrime:=ARRAY(m_uzetoplj,1)
  p_mtrtip:=" "
  p_mtrtip:=ARRAY(m_uzetoplj,1)
  p_mtrplj:=0
  p_mtrplj:=ARRAY(m_uzetoplj,1)
  p_mtrpcm:=0
  p_mtrpcm:=ARRAY(m_uzetoplj,1)

  m_zpocmesto:=m_pocmesto

  GO m_pocpolje

  ***Ispisuje zaglavlje i priprema ekran za ispis podataka***
  DO WHILE .T.
    m_brjc1:=m_brjc1+1

    m_brmspl:=field_len
    m_brmsdc:=field_dec

    ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
    IF m_brmspl<10
      m_brmspl:=10
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zauzima vise od 74 mesta***
    IF m_brmspl>74
      m_brmspl:=74
    ENDIF

    ***Odredjuje pocetak ispisa podataka u zaglavlju na sredini***
    m_mestisp:=m_zpocmesto+INT((m_brmspl-8)/2)
    m_kollin:=m_zpocmesto+m_brmspl+1

    ***Vraca pravu vrednost onom blesavom i onom normalnom polju***
    IF field_type="C" .AND. field_len=888 .AND. field_dec=888
      m_brmpis:=1024
      m_brmdis:=0
    ELSE
      m_brmpis:=field_len
      m_brmdis:=field_dec
    ENDIF

    **********Ispis zaglavlja**********
    @ 2,m_mestisp SAY field_name COLOR "GR+/B"
    @ 3,m_mestisp SAY "("+ALLTRIM(STR(red_broj))+")"+;
                      field_type+"-"+ALLTRIM(STR(m_brmpis))+;
                      "-"+ALLTRIM(STR(m_brmdis)) COLOR "GR+/B"
    *********************************************************

    ***Punjenje matrica osobinama polja za ispis podataka***
    p_mtrime[m_brjc1]:=field_name
    p_mtrtip[m_brjc1]:=field_type
    p_mtrplj[m_brjc1]:=field_len

    ***Izbacuje ako je to sve sto treba da se prikaze u ovom krugu***
    SKIP
    IF m_brjc1=m_uzetoplj
      EXIT
    ENDIF

    ***Ispis uzduzne razdelne linije***
    FOR w=1 TO 17
      m_redlin:=4+w
      @ m_redlin,m_kollin SAY CHR(179) COLOR "GR+/B"
    NEXT
    @ 4,m_kollin SAY CHR(194) COLOR "GR+/B"
    @ 22,m_kollin SAY CHR(193) COLOR "GR+/B"

    ***Pomera pocetno mesto za ispis i dodaje mesto za liniju***
    m_zpocmesto:=m_zpocmesto+m_brmspl+1

  ENDDO

  ************************************
  ********** Ispis podataka **********
  ************************************

  m_kolpod:=m_pocmesto+1
  m_brjc2:=1

  ***Pocetak ispisa JEDNE TURE (EKRANA)***
  DO WHILE .T.

    m_redpod:=5
    p_mtrpcm[m_brjc2]:=m_kolpod

    ***Ispisuje JEDNU KOLONU od izabranog polja***
    DO WHILE .T.
      m_imeuzmi:=" "
      IF p_mtrtip[m_brjc2]="C" .OR. p_mtrtip[m_brjc2]="L"
        m_sadrzaj:=" "
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=D->&m_imeuzmi
      ELSEIF p_mtrtip[m_brjc2]="N"
        m_sadrzaj:=0
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=D->&m_imeuzmi
      ELSEIF p_mtrtip[m_brjc2]="D"
        m_sadrzaj:=DATE()
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=D->&m_imeuzmi
      ENDIF  
       
      ***Ispis***
      *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
      IF p_mtrplj[m_brjc2]>74
        @ m_redpod,m_kolpod SAY m_sadrzaj PICTURE "@S74" COLOR "BG+/B"
      ELSEIF p_mtrplj[m_brjc2]<75
        @ m_redpod,m_kolpod SAY m_sadrzaj COLOR "BG+/B"
      ENDIF

      SELECT 4
      SKIP
      IF EOF()
        GO BOTTOM
        EXIT
      ENDIF 
      SELECT 3

      m_redpod:=m_redpod+1

      ***Izbacuje kad stigne do kraja stranice***
      IF m_redpod=22
        EXIT
      ENDIF
    ENDDO

    ***Vraca ispis za sledecu kolonu***
    SELECT 4
    SKIP-(m_redpod-5)
    SELECT 3

    ***Izbacuje ako je to sve sto treba da se prikaze u ovom krugu***
    IF m_brjc2=m_uzetoplj
      EXIT
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
    IF p_mtrplj[m_brjc2]<10
      p_mtrplj[m_brjc2]:=10
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zauzima vise od 74 mesta***
    IF p_mtrplj[m_brjc2]>74
      p_mtrplj[m_brjc]:=74
    ENDIF

    ***Pomera pocetno mesto za ispis i dodaje mesto za zarez i za liniju***
    m_kolpod:=m_kolpod+p_mtrplj[m_brjc2]+1

    *Brojac kruga*
    m_brjc2:=m_brjc2+1

  ENDDO

  ***************************************************
  ***************Ispis pokretnog polja***************

  **Postavljanje na polje posle pomeranja ekrana**
  IF m_taster="D" .AND. m_pomekr="D" 
    IF m_prvoplj="N" .AND. m_zadnplj="N"
      m_pkol:=1
    ELSEIF m_prvoplj="D" 
      m_pkol:=m_uzetoplj
      m_prvoplj:="N"
    ENDIF
    m_pomekr:="N"
  ELSEIF m_taster="L" .AND. m_pomekr="D"
    IF m_zadnplj="N"
      m_pkol:=m_uzetoplj
    ELSEIF m_zadnplj="D" 
      m_pkol:=1
      m_zadnplj:="N"
    ENDIF
    m_pomekr:="N"
  ENDIF

  *Korekcija za vracanje sa pretrage*
  IF m_vrcprt="D"
    m_trnplj:=1
    m_pkol:=1
  ENDIF

  **Uzimanje podatka za ispis u pokretnom polju**
  *Podesavanje na zeljeni slog*
  SELECT 4
  IF m_pred>0
    SKIP m_pred
  ENDIF
  m_imeuzmi:=" "
  IF p_mtrtip[m_pkol]="C" .OR. p_mtrtip[m_pkol]="L"
    m_pokpolje:=" "
    m_imeuzmi:=p_mtrime[m_pkol]
    m_pokpolje:=&m_imeuzmi
  ELSEIF p_mtrtip[m_pkol]="N"
    m_pokpolje:=0
    m_imeuzmi:=p_mtrime[m_pkol]
    m_pokpolje:=&m_imeuzmi
  ELSEIF p_mtrtip[m_pkol]="D"
    m_pokpolje:=DATE()
    m_imeuzmi:=p_mtrime[m_pkol]
    m_pokpolje:=&m_imeuzmi
  ENDIF  
  IF m_pred>0
    SKIP -m_pred
  ENDIF
  SELECT 3
  ***Odredjuje mesto za ispis***
  m_pokkol:=p_mtrpcm[m_pkol]
  m_pokred:=5+m_pred

  ***Ispis pokretnog polja***
  *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
  IF p_mtrplj[m_pkol]>74
    @ m_pokred,m_pokkol SAY m_pokpolje PICTURE "@S74" COLOR "B/W"
  ELSEIF p_mtrplj[m_pkol]<75
    @ m_pokred,m_pokkol SAY m_pokpolje COLOR "B/W"
  ENDIF
  *****************************************

  **Korekcija za broj polja, kad ide s' desna na pocetno**
  IF m_brpslnd="D"
    m_brpslnd:="N"
    m_trnplj:=m_pkol
  ENDIF

  **Korekcija ako je krajnji desni ispis o bazi, slogovima i poljima**
  IF m_kortrp="D" 
    m_kortrp:="N"
    m_trnplj:=m_brsl-m_uzetoplj+m_pkol
  ENDIF

  **Korekcija ako je upisivan novi slog**
  IF m_upsnov="D" .OR. m_vrcprt="D"
    m_upsnov:="N"
    m_vrcprt:="N"
    m_trnplj:=1
  ENDIF

  **Ispis podataka o bazi, slogovima i poljima**
  @ 1,1 CLEAR TO 1,78
  @ 1,1 SAY "BAZA:"+ALLTRIM(UPPER(m_baza))+;
            " * SLOG:"+ALLTRIM(STR(m_trnslg))+"/"+ALLTRIM(STR(m_brslbz))+;
            " * POLJE:"+ALLTRIM(STR(m_trnplj))+"/"+;
            ALLTRIM(STR(m_brsl)) COLOR "G+/B"

  *****Zastoj za prihvat pritisnutog tastera*****
  IF m_novupis="NIJE"
    INKEY(0)
  ENDIF

***Izlazak iz pregleda podataka, kraj rada***
*------- Prekid rada
  IF LASTKEY()=27

    CLOSE DATABASES
    ERASE osob.dbf
    ERASE osobx.dbf
    ERASE imeplprt.dbf
    ERASE osobpret.dbf
    ERASE bzzavred.dbf
    ERASE bzzapret.dbf
    ERASE gdlistin.ntx
    ERASE gdlistpg.ntx
    ERASE ekstime.ntx
    ***KRAJ*** 
    SET COLOR TO "W/N"
    CLS
    QUIT
************************** K R A J programa *********************


***Prihvatanje odabranog podatka i njegova izmena***
  ELSEIF LASTKEY()=13
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    SELECT 4
    **Azuriranje podataka**
    SET CONFIRM ON
    SET CURSOR ON
    *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
    IF p_mtrplj[m_pkol]>74
      @ m_pokred,m_pokkol GET m_pokpolje PICTURE "@S74" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<75
      @ m_pokred,m_pokkol GET m_pokpolje COLOR "R/W"
    ENDIF
    READ
    SKIP m_pred
    REPLACE &m_imeuzmi WITH m_pokpolje
    SKIP -m_pred
    SET CONFIRM OFF
    SET CURSOR OFF
    LOOP

***Upis novog sloga (reda) i novih podataka (F5)***
  ELSEIF LASTKEY()=-4
    m_upsnov:="D"
    m_gdlist:=1
    m_ponprt="NE"
    m_taster:="L"
    m_zadnplj:="N"
    *Izbacuje korekciju krajnjeg desnog ispisa jer se ekran pomera u desno*
    m_kortrp:="N"
    m_pocpolje:=1
    m_pkol:=1
    SELECT 4
    **Uklanjanje indeksne baze**
    IF FILE("gdlistin.ntx")
      CLOSE INDEXES
      ERASE gdlistin.ntx
    ENDIF
    m_gdlist:=0
    **Omogucuje otvaranje novog sloga i postavlja polje na mesto za upis**
    IF m_novupis="NIJE"
      m_novupis:="JESTE"
      APPEND BLANK
      IF m_brslbz>16
        SKIP-16
        m_pred:=16
        m_brslbz:=m_brslbz+1
      ELSEIF m_brslbz<17
        SKIP-m_brslbz
        m_pred:=m_brslbz
        m_brslbz:=m_brslbz+1
      ENDIF
      m_trnslg:=m_brslbz
      LOOP
    ENDIF
    m_novupis:="NIJE"
    **Upis novog podatka**
    SET CONFIRM ON
    SET CURSOR ON
    *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
    IF p_mtrplj[m_pkol]>74
      @ m_pokred,m_pokkol GET m_pokpolje PICTURE "@S74" COLOR "R/W"
    ELSEIF p_mtrplj[m_pkol]<75
      @ m_pokred,m_pokkol GET m_pokpolje COLOR "R/W"
    ENDIF
    READ
    *Ako nije nista upisano, brse novi slog*
    IF EMPTY(m_pokpolje)
      *Vraca ako je baza prazna*
      IF m_brslbz=1
        m_brslbz:=0
        m_trnslg:=m_brslbz
        DELETE
        PACK
        SET CONFIRM OFF
        SET CURSOR OFF
        LOOP
      ENDIF
      SKIP m_pred
      DELETE
      PACK
      SKIP -m_pred
      m_brslbz:=m_brslbz-1
      GO BOTTOM
      IF m_brslbz>17
        SKIP-16
        m_pred:=16
      ELSEIF m_brslbz<18
        GO TOP
        m_pred:=m_brslbz-1
      ENDIF
      m_trnslg:=m_brslbz
      SET CONFIRM OFF
      SET CURSOR OFF
      LOOP
    ENDIF
    **Upis**
    SKIP m_pred
    REPLACE &m_imeuzmi WITH m_pokpolje
    SKIP -m_pred
    SET CONFIRM OFF
    SET CURSOR OFF
    LOOP

***Brisanje sloga na kome se nalazi pokretno polje (F6)***
  ELSEIF LASTKEY()=-5
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    @ 23,1 CLEAR TO 23,78
    @ 23,17 SAY "Potvrdite brisanje obelezenog sloga (D/N):"
    m_brisanje:="N"
    @ 23,60 GET m_brisanje PICTURE "!" VALID(m_brisanje $ "DdNn") COLOR "R/W"
    READ
    IF m_brisanje="N"
    *Samo da preskoci*
    ELSEIF m_brisanje="D"
      SELECT 4
      SKIP m_pred
      DELETE
      PACK
      IF m_trnslg=m_brslbz
        m_trnslg:=m_brslbz-1
        IF m_brslbz>17
          SKIP m_trnslg-(m_pred+1)
          m_pred:=16
        ELSEIF m_brslbz<18
          GO TOP
          m_pred:=m_brslbz-2
        ENDIF
      ELSEIF m_trnslg<m_brslbz
        SKIP m_trnslg-(m_pred+1)
      ENDIF
      m_brslbz:=m_brslbz-1
    ENDIF
    LOOP

***Pretraga po svi kriterijumima (F8)***
  ELSEIF LASTKEY()=-7
    m_gdlist:=1
    m_ponprt="NE"
    m_vrcprt:="D"
    m_pocpolje:=1
    *Poziv na pretragu*
    DO pretraga
    IF m_brslbz<18
      SELECT 4
      GO TOP
    ENDIF
    *Kriteriji za postavljanje na pocetak ispisa*
    m_trnslg:=1
    m_pred:=0
    SELECT 3
    USE osob
    GO TOP
    LOOP

***Ispis pomocnog menija (F10)***
  ELSEIF LASTKEY()=-9
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_ispF10="PRVI"
      m_ispF10:="DRUGI"
    ELSEIF m_ispF10="DRUGI"
      m_ispF10:="PRVI"
    ENDIF
    IF m_brslbz<18
      SELECT 4
      GO TOP
    ENDIF
    LOOP


***Indeksiranje i redjanje podataka***
*------- Pregled kolone (1)
  ELSEIF LASTKEY()=49
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistin.ntx")
      CLOSE INDEXES
      ERASE gdlistin.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#12
      m_gdlist:=12
      INDEX ON prezime+ime TO gdlistin.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=12
      m_gdlist:=11
      INDEX ON DESCEND(prezime+ime) TO gdlistin.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*--------- Pregled kolone (2)
  ELSEIF LASTKEY()=50
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistin.ntx")
      CLOSE INDEXES
      ERASE gdlistin.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#22
      m_gdlist:=22
      INDEX ON ime+prezime TO gdlistin.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=22
      m_gdlist:=21
      INDEX ON DESCEND(ime+prezime) TO gdlistin.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (3)
  ELSEIF LASTKEY()=51
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistin.ntx")
      CLOSE INDEXES
      ERASE gdlistin.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#32
      m_gdlist:=32
      INDEX ON DTOS(odlazak)+DTOS(povratak) TO gdlistin.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=32
      m_gdlist:=31
      INDEX ON DESCEND(DTOS(odlazak)+DTOS(povratak)) TO gdlistin.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (4) 
  ELSEIF LASTKEY()=52
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistin.ntx")
      CLOSE INDEXES
      ERASE gdlistin.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#42
      m_gdlist:=42
      INDEX ON DTOS(povratak)+DTOS(odlazak) TO gdlistin.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=42
      m_gdlist:=41
      INDEX ON DESCEND(DTOS(povratak)+DTOS(odlazak)) TO gdlistin.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (5)
    ELSEIF LASTKEY()=53
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistin.ntx")
      CLOSE INDEXES
      ERASE gdlistin.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#52
      m_gdlist:=52
      INDEX ON serija_no TO gdlistin.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=52
      m_gdlist:=51
      INDEX ON DESCEND(serija_no) TO gdlistin.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (6)
    ELSEIF LASTKEY()=54
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistin.ntx")
      CLOSE INDEXES
      ERASE gdlistin.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#62
      m_gdlist:=62
      INDEX ON odrediste+prezime+ime TO gdlistin.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=62
      m_gdlist:=61
      INDEX ON DESCEND(odrediste+prezime+ime) TO gdlistin.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (7)
    ELSEIF LASTKEY()=55
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistin.ntx")
      CLOSE INDEXES
      ERASE gdlistin.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#72
      m_gdlist:=72
      INDEX ON nalog_prim+DTOS(dan_predat) TO gdlistin.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=72
      m_gdlist:=71
      INDEX ON DESCEND(nalog_prim+DTOS(dan_predat)) TO gdlistin.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (8)
    ELSEIF LASTKEY()=56
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 4
    IF FILE("gdlistin.ntx")
      CLOSE INDEXES
      ERASE gdlistin.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#82
      m_gdlist:=82
      INDEX ON DTOS(dan_predat)+nalog_prim TO gdlistin.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=82
      m_gdlist:=81
      INDEX ON DESCEND(DTOS(dan_predat)+nalog_prim) TO gdlistin.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF


***Pomeranje podataka***
*------- Pritisnut taster za levo
  ELSEIF LASTKEY()=19
    m_gdlist:=1
    m_ponprt="NE"
    m_zadnplj:="N"
    IF m_taster="L" .AND. m_pkol#1
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_pkol=1
      m_taster:="L"
      *Izbacuje korekciju krajnjeg desnog ispisa jer se ekran pomera u desno*
      m_kortrp:="N"
      IF m_pocpolje=1
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE U LEVO" COLOR "RB+/B"
        INKEY (1.1)
        @ 23,34 SAY "                 "
        LOOP
      ELSEIF m_pocpolje>1
        m_pomekr:="D"
        m_trnplj:=m_trnplj-1
        LOOP
      ENDIF
    ENDIF
    m_pkol:=m_pkol-1
    m_trnplj:=m_trnplj-1
    LOOP

*------- Pritisnut taster za desno
  ELSEIF LASTKEY()=4
    m_gdlist:=1
    m_taster:="D"
    m_prvoplj:="N"
    m_ponprt="NE"
    IF m_pkol=m_uzetoplj
      IF m_pocpolje+m_uzetoplj=m_brsl+1
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE U DESNO" COLOR "RB+/B"
        INKEY (1.1)
        @ 23,34 SAY "                  "
        LOOP
      ELSEIF m_pocpolje+m_uzetoplj<m_brsl+1
        m_pomekr:="D"
        m_pocpolje:=m_pocpolje+m_uzetoplj
        m_trnplj:=m_trnplj+1
        LOOP
      ENDIF
    ENDIF
    m_pkol:=m_pkol+1
    m_trnplj:=m_trnplj+1
    LOOP


*****Kretanje gore-dole*****
*------- Na gore po jedan
  ELSEIF LASTKEY()=5 
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_pred=0
      SELECT 4
      SKIP -1
      IF BOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
        INKEY(1.2)                 
        @ 23,34 SAY "                  " 
        GO TOP
        LOOP
      ENDIF
      m_trnslg:=m_trnslg-1
      LOOP
    ENDIF
    m_pred:=m_pred-1
    m_trnslg:=m_trnslg-1
    LOOP

*------- Na gore skok
  ELSEIF LASTKEY()=18
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 4
    SKIP -1
    IF BOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      GO TOP
      LOOP
    ENDIF
    SKIP -16
    IF BOF()
      GO TOP
      m_trnslg:=m_pred+1
      LOOP
    ENDIF
    m_trnslg:=m_trnslg-17
    LOOP

*------- Na dole po jedan
  ELSEIF LASTKEY()=24 
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    m_pred:=m_pred+1
    SELECT 4
    SKIP m_pred
    IF EOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      SKIP -m_pred
      m_pred:=m_pred-1
      LOOP
    ENDIF
    SKIP -m_pred
    IF m_pred=17
      m_pred:=16
      SKIP
    ENDIF
    m_trnslg:=m_trnslg+1
    LOOP

*------- Na dole skok
  ELSEIF LASTKEY()=3
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 4
    SKIP 17
    IF EOF()  .AND. m_brslbz>17
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      GO BOTTOM
      SKIP -16
      LOOP
    ELSEIF EOF() .AND. m_brslbz<18
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      GO TOP
      LOOP
    ENDIF
    SKIP 17
    IF EOF()
      GO BOTTOM
      SKIP -16
      SELECT 3
      m_trnslg:=m_brslbz-(16-m_pred)
      LOOP
    ENDIF
    SKIP -17
    m_trnslg:=m_trnslg+17
    LOOP

*------- Neka druga tipka
  ELSE
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    @ 23,1 CLEAR TO 23,78
    @ 23,34 SAY "POGRESAN TASTER" COLOR "RB+/B"
    INKEY(1.7)
    @ 23,34 SAY "               " 
    IF m_brslbz<18
      SELECT 4
      GO TOP
    ENDIF
    LOOP
  ENDIF

ENDDO




********************************************************************
PROCEDURE PRETRAGA
*********Pretraga podataka po svim mogucim kritarijumima************


*PRIPREMA*
********************************************************************
*Formiranje i punjenje baze OSOBPRET.DBF koja sadrzi osobine polja*
SELECT 6
IF FILE("osobpret.dbf")
  CLOSE 
  ERASE osobpret.dbf
ENDIF

***Baza OSOBPRET sadrzi: field_name, field_type, field_len, field_dec***
*USE &m_imbzpt
SELECT 4
COPY TO osobpret STRUCTURE EXTENDED
*CLOSE
GO TOP
SELECT 6
USE osobpret
m_brslpt:=RECCOUNT()

***Ogranicenje neregularnog "C" polja sa 999 mesta***
p_ubaciti:=999
GO TOP
DO WHILE .T.
 IF field_type="C" .AND. field_len=0
  REPLACE field_len WITH p_ubaciti 
 ELSEIF field_type="C" .AND. field_dec#0
  REPLACE field_len WITH p_ubaciti 
 ENDIF
 SKIP
 IF EOF()
  EXIT
 ENDIF
ENDDO

*Formiranje matrice za redni broj, ime, karakter i upis kriterija pretrage*
p_mtpret:=0
p_mtpret:=ARRAY(m_brslpt,5)
GO TOP
FOR e=1 TO m_brslpt
  p_mtpret[e,1]:=e
  p_mtpret[e,2]:=field_name
  p_mtpret[e,3]:=field_type
  p_mtpret[e,4]:=field_len
  p_mtpret[e,5]:=" "
  SKIP
NEXT

*Prebacivanje podataka u matricu, radi pripreme za formiranje*
p_mtvred:=0
p_mtvred:=ARRAY(m_brslpt,4)
GO TOP
FOR b=1 TO m_brslpt
  p_mtvred[b,1]:=field_name
  p_mtvred[b,2]:=field_type
  p_mtvred[b,3]:=field_len
  p_mtvred[b,4]:=field_dec
  SKIP
NEXT

**Kreiranje baze po podacima iz matrice**
SELECT 7
IF FILE("bzzavred.dbf")
  CLOSE 
  ERASE bzzavred.dbf
ENDIF
DBCREATE("bzzavred",p_mtvred)
*CLOSE
USE bzzavred
APPEND BLANK


*ISPIS PO EKRANU I UNOS VREDNOSTI ZA PRETRAGU*
********************************************************************
*************************PRIKAZ NA EKRANU*************************
CLS

***Boja  i okvira***
SET COLOR TO "GR+/B"
@ 0,0 TO 24,79 DOUBLE 

***************Zaglavlje***************
*** Ispis zaglavlja: redni broj, ime polja, karakter, vrednost***
@ 3,2 SAY "RdBr  Ime-Vrsta   K                      Vrednost"

**Uputstvo za uptrbu**
@ 23,17 SAY "Korak:"+CHR(24)+"-"+CHR(25)+"*Izmena:Enter*Pretraga:F8*Izlaz:Esc"

***Postavka promenljivih***

m_ptpkrd:=1
m_ptpkkl:=20
m_isppod:=15
m_brjc3:=15
m_itrnplj:=1


***********************************
**********   I S P I S   **********
DO WHILE .T.

  @ 4,1 CLEAR TO 21,78
  *Zaglavlje i linije u ispisu teksta*
  @ 4,1 TO 21,78
  FOR t=1 TO 17
    @ 4+t,6 SAY CHR(179)
    @ 4+t,19 SAY CHR(179)
    @ 4+t,21 SAY CHR(179)
  NEXT
  @ 4,6 SAY CHR(194)
  @ 4,19 SAY CHR(194)
  @ 4,21 SAY CHR(194)
  @ 21,6 SAY CHR(193)
  @ 21,19 SAY CHR(193)
  @ 21,21 SAY CHR(193)

  ************************************
  ********** Ispis podataka **********
  ************************************
  m_isppod:=m_isppod-(m_brjc3-1)
  m_brjc3:=1
  DO WHILE .T.
    *Ispis podataka o: rednom broju, imenu polja-karakteru*
    @ 4+m_brjc3,2 SAY ALLTRIM(STR(p_mtpret[m_isppod,1])) COLOR "BG+/B"
    @ 4+m_brjc3,7 SAY p_mtpret[m_isppod,2] COLOR "BG+/B"
    @ 4+m_brjc3,17 SAY "-"+p_mtpret[m_isppod,3] COLOR "BG+/B"
    @ 4+m_brjc3,20 SAY p_mtpret[m_isppod,5] COLOR "BG+/B"

    *Ispis polja za unos vrednosti za pretragu*
    m_vrduzmi:=" "
    IF p_mtpret[m_isppod,3]="C" .OR. p_mtpret[m_isppod,3]="L" 
      m_vrdsdr:=" "
      m_vrduzmi:=p_mtpret[m_isppod,2]
      m_vrdsdr:=&m_vrduzmi
    ELSEIF p_mtpret[m_isppod,3]="N"
      m_vrdsdr:=0
      m_vrduzmi:=p_mtpret[m_isppod,2]
      m_vrdsdr:=&m_vrduzmi
    ELSEIF p_mtpret[m_isppod,3]="D"
      m_vrdsdr:=DATE()
      m_vrduzmi:=p_mtpret[m_isppod,2]
      m_vrdsdr:=&m_vrduzmi
    ENDIF  
       
    *Ispis vrednosti pretrage*
    *Obezbedjuje da polja koja imaju vise od 56 mesta klize*
    IF p_mtpret[m_isppod,4]>56
      @ 4+m_brjc3,22 SAY m_vrdsdr PICTURE "@S56" COLOR "BG+/B"
    ELSEIF p_mtpret[m_isppod,4]<57
      @ 4+m_brjc3,22 SAY m_vrdsdr COLOR "BG+/B"
    ENDIF

    ***Izbacuje kad stigne do kraja stranice***
    IF m_brjc3=16 .OR. m_isppod=m_brslpt
      EXIT
    ENDIF

    *Brojac kruga*
    m_brjc3:=m_brjc3+1
    m_isppod:=m_isppod+1

  ENDDO

  ***************************************************
  ***************Ispis pokretnog polja***************

  **Uzimanje podatka za ispis u pokretnom polju**
  IF m_ptpkkl=20
    m_vrdsdr:=" "
    m_vrdsdr:=p_mtpret[m_itrnplj,5]
  ELSEIF m_ptpkkl=22
    *Ispis polja za unos vrednosti za pretragu*
    m_vrduzmi:=" "
    IF p_mtpret[m_itrnplj,3]="C" .OR. p_mtpret[m_itrnplj,3]="L" 
      m_vrdsdr:=" "
      m_vrduzmi:=p_mtpret[m_itrnplj,2]
      m_vrdsdr:=&m_vrduzmi
    ELSEIF p_mtpret[m_itrnplj,3]="N"
      m_vrdsdr:=0
      m_vrduzmi:=p_mtpret[m_itrnplj,2]
      m_vrdsdr:=&m_vrduzmi
    ELSEIF p_mtpret[m_itrnplj,3]="D"
      m_vrdsdr:=DATE()
      m_vrduzmi:=p_mtpret[m_itrnplj,2]
      m_vrdsdr:=&m_vrduzmi
    ENDIF  
  ENDIF


  ***Ispis pokretnog polja***
  IF m_ptpkkl=20
    @ 4+m_ptpkrd,20 SAY m_vrdsdr COLOR "B/W"
  ELSEIF m_ptpkkl=22
    *Obezbedjuje da polja koja imaju vise od 56 mesta klize*
    IF p_mtpret[m_itrnplj,4]>56
      @ 4+m_ptpkrd,22 SAY m_vrdsdr PICTURE "@S56" COLOR "B/W"
    ELSEIF p_mtpret[m_itrnplj,4]<57
      @ 4+m_ptpkrd,22 SAY m_vrdsdr COLOR "B/W"
    ENDIF
  ENDIF

  **Ispis podataka o bazi, slogovima i poljima**
  @ 1,1 CLEAR TO 1,77
  @ 1,1 SAY "Baza: NALOG"+;
            " * Polje:"+ALLTRIM(STR(m_itrnplj))+"/"+ALLTRIM(STR(m_brslpt))+;
            " * UNESI: kriterij (K) i vrednost" COLOR "G+/B"

  *****Zastoj za prihvat pritisnutog tastera*****
    INKEY(0)
  ***********************************************


***Izlazak iz pretrage podataka, na nivo za pregled i azuriranje***
*------- Prekid i vracanje u izbor databaze
  IF LASTKEY()=27
    CLOSE
    ERASE bzzavred.dbf
    SELECT 6
    CLOSE
    ERASE osobpret.dbf
    RETURN


***Prihvatanje odabranog podatka i njegova izmena***
  ELSEIF LASTKEY()=13
    **Azuriranje podataka**
    SET CONFIRM ON
    SET CURSOR ON
    *Unos kritarija*
    IF m_ptpkkl=20
      @ 4+m_ptpkrd,20 GET m_vrdsdr VALID (m_vrdsdr $ "><=") COLOR "R/W"
      READ
      p_mtpret[m_itrnplj,5]:=m_vrdsdr
    *Unos vrednosti*
    ELSEIF m_ptpkkl=22
      *Obezbedjuje da polja koja imaju vise od 56 mesta klize*
      IF p_mtpret[m_itrnplj,4]>56
        @ 4+m_ptpkrd,22 GET m_vrdsdr PICTURE "@S56" COLOR "R/W"
      ELSEIF p_mtpret[m_itrnplj,4]<57
        @ 4+m_ptpkrd,22 GET m_vrdsdr COLOR "R/W"
      ENDIF
      READ
      REPLACE &m_vrduzmi WITH m_vrdsdr
    ENDIF
    SET CONFIRM OFF
    SET CURSOR OFF
    LOOP


***Izlazak iz upisa radi pretrage (F8)***
*------- Pretraga i ubacivanje u bazu nadjenih podataka
  ELSEIF LASTKEY()=-7
    GO TOP
    EXIT


***Pomeranje podataka***
*------- Pritisnut taster za levo
  ELSEIF LASTKEY()=19
    IF m_ptpkkl=20
      LOOP
    ENDIF
    m_ptpkkl:=20
    LOOP


*------- Pritisnut taster za desno
  ELSEIF LASTKEY()=4
    IF m_ptpkkl=22
      LOOP
    ENDIF
    m_ptpkkl:=22
    LOOP


*****Kretanje gore-dole*****
*------- Na gore po jedan
  ELSEIF LASTKEY()=5 
    IF m_itrnplj=1 
      LOOP
    ENDIF
    IF m_ptpkrd=1
      m_isppod:=m_isppod-1
    ELSEIF m_ptpkrd>1
      m_ptpkrd:=m_ptpkrd-1
    ENDIF
    m_itrnplj:=m_itrnplj-1
    LOOP


*------- Na dole po jedan
  ELSEIF LASTKEY()=24 
    IF m_itrnplj=m_brslpt
      LOOP
    ENDIF
    IF m_ptpkrd=16
      m_isppod:=m_isppod+1
    ELSEIF m_ptpkrd<16
      m_ptpkrd:=m_ptpkrd+1
    ENDIF
    m_itrnplj:=m_itrnplj+1
    LOOP


*------- Neka druga tipka
  ELSE
    LOOP
  ENDIF

ENDDO




*PRETRAGA PODATAKA I PUNJENJE BAZE SA NADJENIM PODACIMA*
*********************************************************


**Provera da li ima ma kakav podatak za pretragu**
m_imavrd:="N"
FOR c=1 TO m_brslpt
  m_ptpodx:=" "
  m_ptpodx:=p_mtpret[c,2]
  IF ! EMPTY(&m_ptpodx)
    m_imavrd:="D"
    EXIT
  ENDIF
NEXT
IF m_imavrd="N"
  CLOSE 
  ERASE bzzavred.dbf
  SELECT 6
  CLOSE
  ERASE osobpret.dbf
  RETURN
ENDIF

*Formiranje baze za punjenje nadjenih podataka*
SELECT 8
IF FILE("bzzapret.dbf")
  CLOSE 
  ERASE bzzapret.dbf
ENDIF
DBCREATE("bzzapret",p_mtvred)
USE bzzapret

***Pretraga i punjenje***
SELECT 7
GO TOP


***Pretraga po prvom kriteriju i punjenje nadjenim podacima***
**Po zadatoj vrednosti**
@ 23,1 CLEAR TO 23,78
@ 23,27 SAY "Pretraga podataka je u toku" COLOR "RB+/B"

m_brptrg:=0
m_kraj1p:="N"
DO WHILE .T.

  m_brptrg:=m_brptrg+1
  m_vrxptr:="VREDNOST"

  *Kraj pretrage*
  IF m_brslpt<m_brptrg
    CLS
    @ 12,15 SAY "Nema korektnih kriterija - pretraga neuspesna !"
    INKEY(7.5)
    CLOSE
    ERASE bzzavred.dbf
    SELECT 6
    CLOSE
    ERASE osobpret.dbf
    RETURN
  ENDIF

  *Uzimanje sadrzaja za uporedjivanje*
  m_provim:=" "
  IF p_mtpret[m_brptrg,3]="C" .OR. p_mtpret[m_brptrg,3]="L" 
    m_uuzmsdr:=" "
    m_provim:=p_mtpret[m_brptrg,2]
    m_uuzmsdr:=&m_provim
  ELSEIF p_mtpret[m_brptrg,3]="N"
    m_uuzmsdr:=0
    m_provim:=p_mtpret[m_brptrg,2]
    m_uuzmsdr:=&m_provim
  ELSEIF p_mtpret[m_brptrg,3]="D"
    m_uuzmsdr:=DATE()
    m_provim:=p_mtpret[m_brptrg,2]
    m_uuzmsdr:=&m_provim
  ENDIF  

  **Vraca ako je polje za vrednost prazno**
  *Preskace nepotpune podatke*
  IF p_mtpret[m_brptrg,3]="D" .OR. p_mtpret[m_brptrg,3]="L" .OR. ;
     p_mtpret[m_brptrg,3]="C" .AND. EMPTY(m_uuzmsdr)
     LOOP
  ENDIF
  IF p_mtpret[m_brptrg,3]="D" .OR. p_mtpret[m_brptrg,3]="L" .OR. ;
     p_mtpret[m_brptrg,3]="N" .AND. EMPTY(p_mtpret[m_brptrg,5])
     LOOP
   ENDIF
   *Odredjuje vrstu pretrage*
   IF p_mtpret[m_brptrg,3]="C" .AND. EMPTY(p_mtpret[m_brptrg,5]) 
     m_vrxptr:="IZRAZ"
   ENDIF

  SELECT 4
 IF m_vrxptr = "VREDNOST"

  *Uzimanje uslova pretrage*
  m_pprtga:=" "
  m_pprtga:=p_mtpret[m_brptrg,5]

  *Uzimanje vrste sadrzaja za pretragu*
  m_provim:=" "
  IF p_mtpret[m_brptrg,3]="C" .OR. p_mtpret[m_brptrg,3]="L" 
    m_puzmsdr:=" "
    m_provim:=p_mtpret[m_brptrg,2]
  ELSEIF p_mtpret[m_brptrg,3]="N"
    m_puzmsdr:=0
    m_provim:=p_mtpret[m_brptrg,2]
  ELSEIF p_mtpret[m_brptrg,3]="D"
    m_puzmsdr:=DATE()
    m_provim:=p_mtpret[m_brptrg,2]
  ENDIF  

  **Prva pretraga**
  DO WHILE .T.

    *Uzimanje sadrzaja za pretragu*
    m_puzmsdr:=&m_provim
    IF m_pprtga = "="
      IF m_uuzmsdr=m_puzmsdr 
        *Ubacuje nadjeni podatak*
        SELECT 8
        APPEND BLANK
        FOR y=1 TO m_brslpt
          *Uzimanje sadrzaja za prepisivanje*
          m_rprovim:=" "
          IF p_mtpret[y,3]="C" .OR. p_mtpret[y,3]="L" 
            m_ruzmsdr:=" "
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="N"
            m_ruzmsdr:=0
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="D"
            m_ruzmsdr:=DATE()
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ENDIF  
          REPLACE &m_rprovim WITH m_ruzmsdr
        NEXT
        SELECT 4
      ENDIF
    ELSEIF m_pprtga = ">"
      IF m_puzmsdr>m_uuzmsdr
        *Ubacuje nadjeni podatak*
        SELECT 8
        APPEND BLANK
        FOR y=1 TO m_brslpt
          *Uzimanje sadrzaja za prepisivanje*
          m_rprovim:=" "
          IF p_mtpret[y,3]="C" .OR. p_mtpret[y,3]="L" 
            m_ruzmsdr:=" "
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="N"
            m_ruzmsdr:=0
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="D"
            m_ruzmsdr:=DATE()
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ENDIF  
          REPLACE &m_rprovim WITH m_ruzmsdr
        NEXT
        SELECT 4
      ENDIF
    ELSEIF m_pprtga = "<"
      IF m_puzmsdr<m_uuzmsdr
        *Ubacuje nadjeni podatak*
        SELECT 8
        APPEND BLANK
        FOR y=1 TO m_brslpt
          *Uzimanje sadrzaja za prepisivanje*
          m_rprovim:=" "
          IF p_mtpret[y,3]="C" .OR. p_mtpret[y,3]="L" 
            m_ruzmsdr:=" "
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="N"
            m_ruzmsdr:=0
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ELSEIF p_mtpret[y,3]="D"
            m_ruzmsdr:=DATE()
            m_rprovim:=p_mtpret[y,2]
            m_ruzmsdr:=D->&m_rprovim
          ENDIF  
          REPLACE &m_rprovim WITH m_ruzmsdr
        NEXT
        SELECT 4
      ENDIF
    ENDIF
    SKIP
    IF EOF()
      GO TOP
      m_kraj1p:="D"
      EXIT
    ENDIF
  ENDDO

 ELSEIF m_vrxptr = "IZRAZ"

  **Pretraga po zadatom delu izraza**
  m_xbrptpl:=0
  m_xbrptzn:=0
  DO WHILE .T.

    *Uzimanje sadrzaja za pretragu*
    m_puzmsdr:=&m_provim

    m_xbrptpl:=LEN(ALLTRIM(m_puzmsdr))
    m_xbrptzn:=LEN(ALLTRIM(m_uuzmsdr))
    *Ako je zadato vise znakova nego sto ima polja, nema sta da se trazi*
    IF m_xbrptpl<m_xbrptzn
      CLS
      @ 12,15 SAY "Nema korektnih kriterija - pretraga neuspesna !"
      INKEY(7.5)
      CLOSE
      ERASE bzzavred.dbf
      SELECT 6
      CLOSE
      ERASE osobpret.dbf
      RETURN
    ENDIF
    *Pretraga u okviru jednog polja*
    m_xnasobre:="N"
    m_uuzmsdr:=UPPER(ALLTRIM(m_uuzmsdr))
    FOR v=1 TO m_xbrptpl+1-m_xbrptzn
      m_xxuporedj:=" "
      m_xxuporedj:=UPPER(SUBSTR(m_puzmsdr,v,m_xbrptzn))
      *Ako je negde pronadjeno izbacuje iz dalje pretrage*
      IF m_uuzmsdr = m_xxuporedj
        m_xnasobre:="D"
        EXIT
      ENDIF
    NEXT
    *Ubacuje nadjeni slog*
    IF m_xnasobre="D"
      SELECT 8
      APPEND BLANK
      FOR y=1 TO m_brslpt
        *Uzimanje sadrzaja za prepisivanje*
        m_rprovim:=" "
        IF p_mtpret[y,3]="C" .OR. p_mtpret[y,3]="L" 
          m_ruzmsdr:=" "
          m_rprovim:=p_mtpret[y,2]
          m_ruzmsdr:=D->&m_rprovim
        ELSEIF p_mtpret[y,3]="N"
          m_ruzmsdr:=0
          m_rprovim:=p_mtpret[y,2]
          m_ruzmsdr:=D->&m_rprovim
        ELSEIF p_mtpret[y,3]="D"
          m_ruzmsdr:=DATE()
          m_rprovim:=p_mtpret[y,2]
          m_ruzmsdr:=D->&m_rprovim
        ENDIF  
        REPLACE &m_rprovim WITH m_ruzmsdr
      NEXT
      SELECT 4
    ENDIF
    SKIP
    IF EOF()
      GO TOP
      m_kraj1p:="D"
      EXIT
    ENDIF
  ENDDO

 ENDIF

  *Kraj pretrage*
  IF  m_kraj1p = "D"
    EXIT
  ENDIF

ENDDO


******************************************************
*** Da se prazni baza preko ostalih zadatih uslova ***

SELECT 8
GO TOP

DO WHILE .T.

  *Kraj pretrage potvrda brisanja*
  IF m_brslpt=m_brptrg
    PACK
    EXIT
  ENDIF

  m_brptrg:=m_brptrg+1
  m_vrxptr:="VREDNOST"

  *Uzimanje sadrzaja za uporedjivanje*
  m_provim:=" "
  IF p_mtpret[m_brptrg,3]="C" .OR. p_mtpret[m_brptrg,3]="L" 
    m_uuzmsdr:=" "
    m_provim:=p_mtpret[m_brptrg,2]
  ELSEIF p_mtpret[m_brptrg,3]="N"
    m_uuzmsdr:=0
    m_provim:=p_mtpret[m_brptrg,2]
  ELSEIF p_mtpret[m_brptrg,3]="D"
    m_uuzmsdr:=DATE()
    m_provim:=p_mtpret[m_brptrg,2]
  ENDIF  
  m_uuzmsdr:=G->&m_provim

  *Preskace nepotpune podatke**
  IF p_mtpret[m_brptrg,3]="D" .OR. p_mtpret[m_brptrg,3]="L" .OR. ;
     p_mtpret[m_brptrg,3]="C" .AND. EMPTY(m_uuzmsdr)
     LOOP
  ENDIF
  IF p_mtpret[m_brptrg,3]="D" .OR. p_mtpret[m_brptrg,3]="L" .OR. ;
     p_mtpret[m_brptrg,3]="N" .AND. EMPTY(p_mtpret[m_brptrg,5])
     LOOP
  ENDIF
  *Odredjuje vrstu pretrage*
  IF p_mtpret[m_brptrg,3]="C" .AND. EMPTY(p_mtpret[m_brptrg,5])
    m_vrxptr:="IZRAZ"
  ENDIF

 IF m_vrxptr = "VREDNOST"

  DO WHILE .T.

    *Uzimanje vrste sadrzaja za pretragu*
    m_provim:=" "
    IF p_mtpret[m_brptrg,3]="C" .OR. p_mtpret[m_brptrg,3]="L" 
      m_puzmsdr:=" "
      m_provim:=p_mtpret[m_brptrg,2]
    ELSEIF p_mtpret[m_brptrg,3]="N"
      m_puzmsdr:=0
      m_provim:=p_mtpret[m_brptrg,2]
    ELSEIF p_mtpret[m_brptrg,3]="D"
      m_puzmsdr:=DATE()
      m_provim:=p_mtpret[m_brptrg,2]
    ENDIF  
    *Uzimanje sadrzaja za pretragu*
    m_puzmsdr:=&m_provim

    IF p_mtpret[m_brptrg,5] = "="
      IF m_puzmsdr#m_uuzmsdr
        *Brise nadjeni podatak*
        DELETE
      ENDIF
    ELSEIF p_mtpret[m_brptrg,5] = ">"
      IF m_puzmsdr<m_uuzmsdr .OR. m_puzmsdr=m_uuzmsdr
        *Brise nadjeni podatak*
        DELETE
      ENDIF
    ELSEIF p_mtpret[m_brptrg,5] = "<"
      IF m_puzmsdr>m_uuzmsdr .OR. m_puzmsdr=m_uuzmsdr
        *Brise nadjeni podatak*
        DELETE
      ENDIF
    ENDIF
    SKIP
    IF EOF()
      GO TOP
      EXIT
    ENDIF
  ENDDO

 ELSEIF m_vrxptr = "IZRAZ"

  DO WHILE .T.

    *Uzimanje sadrzaja za pretragu*
    m_provim:=" "
    m_puzmsdr:=" "
    m_provim:=p_mtpret[m_brptrg,2]
    *Uzimanje sadrzaja za pretragu*
    m_puzmsdr:=&m_provim


    **Pretraga po zadatom delu izraza**
    m_xbrptpl:=0
    m_xbrptpl:=0

    m_xbrptpl:=LEN(ALLTRIM(m_puzmsdr))
    m_xbrptzn:=LEN(ALLTRIM(m_uuzmsdr))
    *Ako je zadato vise znakova nego sto polja ima, nema sta da se trazi*
    IF m_xbrptpl<m_xbrptzn
      EXIT
    ENDIF
    *Pretraga u okviru jednog polja*
    m_xnasobre:="N"
    m_x1uporedj:=" "
    m_x1uporedj:=UPPER(ALLTRIM(m_uuzmsdr))
    FOR v=1 TO m_xbrptpl+1-m_xbrptzn
      m_x2uporedj:=SPACE(m_xbrptzn)
      m_x2uporedj:=UPPER(SUBSTR(m_puzmsdr,v,m_xbrptzn))
      *Ako je negde pronadjeno izbacuje iz dalje pretrage*
      IF m_x1uporedj = m_x2uporedj
        m_xnasobre:="D"
        EXIT
      ENDIF
    NEXT
    *Brise nadjeni podatak*
    IF m_xnasobre="N"
      DELETE
    ENDIF
    SKIP
    IF EOF()
      GO TOP
      EXIT
    ENDIF
  ENDDO

 ENDIF

ENDDO


     *********************************************
     ***********    ISPIS I PREGLED   ************


********Manipulacija podacima iz pretrage izabrane baze podataka**********

*****Zadata baza*****
**Broj slogova koji zadovoljavaju kriterijum pretrage**
m_prtbrs:=LASTREC()

*************************PRIKAZ NA EKRANU*************************
CLS

GO TOP

***Boja okvira i zaglavlja***
SET COLOR TO "BG+/B"
@ 0,0 TO 24,79 DOUBLE COLOR "GR+/B"

***************Zaglavlje***************
***Boja poruka***
SET COLOR TO "G+/B"

***Postavka promenljivih***
m_pocpolje:=1
m_taster:="D"
m_deskrj:=1

m_gdlist:=1
m_promin:=" "
m_npromin:=0
m_dpromin:=DATE()

m_pokred:=5
m_pokkol:=0
m_pkol:=1
m_pred:=0
m_pomekr:="D"
m_prvoplj:="N"
m_zadnplj:="N"

m_trnslg:=1
IF m_brslbz=0
  m_trnslg:=0
ENDIF
m_skokna:=0
m_deljskok:=0
m_oduzskok:=0
m_trnplj:=1
m_brpslnd:="N"

m_novupis:="NIJE"
m_ponprt:="NE"
m_vrsprt:="  "
m_ispF10:="PRVI"
m_kortrp:="N"


DO WHILE .T.

  **Uputstvo za uptrbu**
  @ 23,1 CLEAR TO 23,78
  @ 23,14 SAY "Korak:"+CHR(24)+"-"+CHR(25)+"*Skok:PageUp"+CHR(24)+;
             "-PageDown"+CHR(25)+;
             "*Izlaz:Esc*F9:Stampa" COLOR "G+/B"
  SELECT 3
  GO m_pocpolje
  m_brmsuk:=0
  m_uzetoplj:=0
  m_pocmesto:=0

  ***Za DESNO (samo racuna parametre za ispis na ekranu)***
  IF m_taster="D" 
    DO WHILE .T.
      m_brmspl:=0
      m_brmsdc:=0
      m_uzetoplj:=m_uzetoplj+1
  
      m_brmspl:=field_len
      m_brmsdc:=field_dec

      ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
      IF m_brmspl<10
        m_brmspl:=10
      ENDIF
      
      ***Sabira polja koja treba da se prikazu***
      IF field_type="C" .AND. field_len=888 .AND. field_dec=888
        m_brmsuk:=m_brmsuk+1024+1
        IF m_brmsuk>1025 
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-1024-2
          EXIT
        ENDIF
      ELSE
        m_brmsuk:=m_brmsuk+m_brmspl+1
        IF m_brmsuk>74 .AND. m_uzetoplj=1
          m_brmsuk:=m_brmsuk-1
          EXIT
        ELSEIF m_brmsuk>74 .AND. m_uzetoplj>1
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-m_brmspl-2
          EXIT
        ENDIF
      ENDIF

      SKIP

      IF EOF() .AND. m_pocpolje>1
        m_kortrp:="D"
        m_pocpolje:=m_brsl+1
        m_taster:="L"
        IF m_zadnplj="D"
          m_zadnplj:="N"
        ELSE
          m_zadnplj:="D"
        ENDIF
        m_deskrj:=2
        GO m_brsl
        m_brmsuk:=0
        m_uzetoplj:=0
        m_pocmesto:=0        
        EXIT
      ELSEIF EOF() .AND. m_pocpolje=1
        m_brmsuk:=m_brmsuk-1
        EXIT
      ENDIF
    ENDDO
  ENDIF

  ***Za LEVO (samo racuna parametre za ispis na ekranu)***
  IF m_taster="L" 
    DO WHILE .T.
  
       IF m_deskrj=1
        SKIP-1
      ENDIF
  
      IF m_deskrj=2
        m_deskrj:=1
      ENDIF
      IF BOF()
        m_pocpolje:=1
        EXIT
      ENDIF
  
      m_brmspl:=0
      m_brmsdc:=0
      m_uzetoplj:=m_uzetoplj+1
  
      m_brmspl:=field_len
      m_brmsdc:=field_dec
  
      ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
      IF m_brmspl<10
        m_brmspl:=10
      ENDIF
  
      IF field_type="C" .AND. field_len=888 .AND. field_dec=888
        m_brmsuk:=m_brmsuk+1024+1
        IF m_brmsuk>1025
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-1024-2
          m_pocpolje:=m_pocpolje-m_uzetoplj
          EXIT
        ENDIF
      ELSE
        m_brmsuk:=m_brmsuk+m_brmspl+1
        IF m_brmsuk>74 .AND. m_uzetoplj=1
          m_pocpolje:=m_pocpolje-m_uzetoplj
          m_bemsuk:=m_brmsuk-1
          EXIT
        ELSEIF m_brmsuk>74 .AND. m_uzetoplj>1
          m_uzetoplj:=m_uzetoplj-1
          m_brmsuk:=m_brmsuk-m_brmspl-2
          m_pocpolje:=m_pocpolje-m_uzetoplj
          EXIT
        ENDIF
      ENDIF
    ENDDO
  ENDIF

  ***Ispis 's desna za kretanje u levo***
  IF m_taster="L" .AND. BOF()
    m_taster:="D"
    m_prvoplj:="D"
    m_brpslnd:="D"
    LOOP
  ENDIF

  *****Iracunavanje pocetka ispisa*****
  IF m_brmsuk>74
    m_brmsuk:=74
  ENDIF
  m_pocmesto:=39-INT(m_brmsuk/2)


  ***********************************
  **********   I S P I S   **********

  @ 2,1 CLEAR TO 22,78
  @ 4,1 TO 22,78 COLOR "GR+/B"

  ***** Ispis zaglavlja: ime polja, karakter, broj mesta i decimala *****
  *Promenljive zaglavlje*
  m_zpocmesto:=0
  m_brjc1:=0
  m_brmspl:=0
  m_brmsdc:=0
  m_prethisp:=0
  m_mestisp:=0
  m_redlin:=0
  m_kollin:=0
  m_brmpis:=0
  m_brmdis:=0

  m_kolpod:=0

  *Postavka matrica*
  p_mtrrbr:=0
  p_mtrrbr:=ARRAY(m_uzetoplj,1)
  p_mtrime:=" "
  p_mtrime:=ARRAY(m_uzetoplj,1)
  p_mtrtip:=" "
  p_mtrtip:=ARRAY(m_uzetoplj,1)
  p_mtrplj:=0
  p_mtrplj:=ARRAY(m_uzetoplj,1)
  p_mtrpcm:=0
  p_mtrpcm:=ARRAY(m_uzetoplj,1)

  m_zpocmesto:=m_pocmesto

  GO m_pocpolje

  ***Ispisuje zaglavlje i priprema ekran za ispis podataka***
  DO WHILE .T.
    m_brjc1:=m_brjc1+1

    m_brmspl:=field_len
    m_brmsdc:=field_dec

    ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
    IF m_brmspl<10
      m_brmspl:=10
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zauzima vise od 74 mesta***
    IF m_brmspl>74
      m_brmspl:=74
    ENDIF

    ***Odredjuje pocetak ispisa podataka u zaglavlju na sredini***
    m_mestisp:=m_zpocmesto+INT((m_brmspl-8)/2)
    m_kollin:=m_zpocmesto+m_brmspl+1

    ***Vraca pravu vrednost onom blesavom i onom normalnom polju***
    IF field_type="C" .AND. field_len=888 .AND. field_dec=888
      m_brmpis:=1024
      m_brmdis:=0
    ELSE
      m_brmpis:=field_len
      m_brmdis:=field_dec
    ENDIF

    **********Ispis zaglavlja**********
    @ 2,m_mestisp SAY field_name COLOR "GR+/B"
    @ 3,m_mestisp SAY "("+ALLTRIM(STR(red_broj))+")"+;
                      field_type+"-"+ALLTRIM(STR(m_brmpis))+;
                      "-"+ALLTRIM(STR(m_brmdis)) COLOR "GR+/B"
    *********************************************************

    ***Punjenje matrica osobinama polja za ispis podataka***
    p_mtrime[m_brjc1]:=field_name
    p_mtrtip[m_brjc1]:=field_type
    p_mtrplj[m_brjc1]:=field_len

    ***Izbacuje ako je to sve sto treba da se prikaze u ovom krugu***
    SKIP
    IF m_brjc1=m_uzetoplj
      EXIT
    ENDIF

    ***Ispis uzduzne razdelne linije***
    FOR w=1 TO 17
      m_redlin:=4+w
      @ m_redlin,m_kollin SAY CHR(179) COLOR "GR+/B"
    NEXT
    @ 4,m_kollin SAY CHR(194) COLOR "GR+/B"
    @ 22,m_kollin SAY CHR(193) COLOR "GR+/B"

    ***Pomera pocetno mesto za ispis i dodaje mesto za liniju***
    m_zpocmesto:=m_zpocmesto+m_brmspl+1

  ENDDO

  ************************************
  ********** Ispis podataka **********
  ************************************

  m_kolpod:=m_pocmesto+1
  m_brjc2:=1

  ***Pocetak ispisa JEDNE TURE (EKRANA)***
  DO WHILE .T.

    m_redpod:=5
    p_mtrpcm[m_brjc2]:=m_kolpod

    ***Ispisuje JEDNU KOLONU od izabranog polja***
    DO WHILE .T.
      m_imeuzmi:=" "
      IF p_mtrtip[m_brjc2]="C" .OR. p_mtrtip[m_brjc2]="L"
        m_sadrzaj:=" "
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=H->&m_imeuzmi
      ELSEIF p_mtrtip[m_brjc2]="N"
        m_sadrzaj:=0
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=H->&m_imeuzmi
      ELSEIF p_mtrtip[m_brjc2]="D"
        m_sadrzaj:=DATE()
        m_imeuzmi:=p_mtrime[m_brjc2]
        m_sadrzaj:=H->&m_imeuzmi
      ENDIF  
       
      ***Ispis***
      *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
      IF p_mtrplj[m_brjc2]>74
        @ m_redpod,m_kolpod SAY m_sadrzaj PICTURE "@S74" COLOR "BG+/B"
      ELSEIF p_mtrplj[m_brjc2]<75
        @ m_redpod,m_kolpod SAY m_sadrzaj COLOR "BG+/B"
      ENDIF

      SELECT 8
      SKIP
      IF EOF()
        GO BOTTOM
        EXIT
      ENDIF 
      SELECT 3

      m_redpod:=m_redpod+1

      ***Izbacuje kad stigne do kraja stranice***
      IF m_redpod=22
        EXIT
      ENDIF
    ENDDO

    ***Vraca ispis za sledecu kolonu***
    SELECT 8
    SKIP-(m_redpod-5)
    SELECT 3

    ***Izbacuje ako je to sve sto treba da se prikaze u ovom krugu***
    IF m_brjc2=m_uzetoplj
      EXIT
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zuzima manje od 10 mesta***
    IF p_mtrplj[m_brjc2]<10
      p_mtrplj[m_brjc2]:=10
    ENDIF

    ***Obezbedjuje da ni jedno polje ne zauzima vise od 74 mesta***
    IF p_mtrplj[m_brjc2]>74
      p_mtrplj[m_brjc]:=74
    ENDIF

    ***Pomera pocetno mesto za ispis i dodaje mesto za zarez i za liniju***
    m_kolpod:=m_kolpod+p_mtrplj[m_brjc2]+1

    *Brojac kruga*
    m_brjc2:=m_brjc2+1

  ENDDO

  ***************************************************
  ***************Ispis pokretnog polja***************

  **Postavljanje na polje posle pomeranja ekrana**
  IF m_taster="D" .AND. m_pomekr="D" 
    IF m_prvoplj="N" .AND. m_zadnplj="N"
      m_pkol:=1
    ELSEIF m_prvoplj="D" 
      m_pkol:=m_uzetoplj
      m_prvoplj:="N"
    ENDIF
    m_pomekr:="N"
  ELSEIF m_taster="L" .AND. m_pomekr="D"
    IF m_zadnplj="N"
      m_pkol:=m_uzetoplj
    ELSEIF m_zadnplj="D" 
      m_pkol:=1
      m_zadnplj:="N"
    ENDIF
    m_pomekr:="N"
  ENDIF

  **Uzimanje podatka za ispis u pokretnom polju**
  *Podesavanje na zeljeni slog*
  SELECT 8
  IF m_pred>0
    SKIP m_pred
  ENDIF
  m_imeuzmi:=" "
  IF p_mtrtip[m_pkol]="C" .OR. p_mtrtip[m_pkol]="L"
    m_pokpolje:=" "
    m_imeuzmi:=p_mtrime[m_pkol]
    m_pokpolje:=&m_imeuzmi
  ELSEIF p_mtrtip[m_pkol]="N"
    m_pokpolje:=0
    m_imeuzmi:=p_mtrime[m_pkol]
    m_pokpolje:=&m_imeuzmi
  ELSEIF p_mtrtip[m_pkol]="D"
    m_pokpolje:=DATE()
    m_imeuzmi:=p_mtrime[m_pkol]
    m_pokpolje:=&m_imeuzmi
  ENDIF  
  IF m_pred>0
    SKIP -m_pred
  ENDIF
  SELECT 3
  ***Odredjuje mesto za ispis***
  m_pokkol:=p_mtrpcm[m_pkol]
  m_pokred:=5+m_pred

  ***Ispis pokretnog polja***
  *Obezbedjuje da polja koja imaju vise od 74 mesta klize*
  IF p_mtrplj[m_pkol]>74
    @ m_pokred,m_pokkol SAY m_pokpolje PICTURE "@S74" COLOR "B/W"
  ELSEIF p_mtrplj[m_pkol]<75
    @ m_pokred,m_pokkol SAY m_pokpolje COLOR "B/W"
  ENDIF
  *****************************************

  **Korekcija za broj polja, kad ide s' desna na pocetno**
  IF m_brpslnd="D"
    m_brpslnd:="N"
    m_trnplj:=m_pkol
  ENDIF

  **Korekcija ako je krajnji desni ispis o bazi, slogovima i poljima**
  IF m_kortrp="D"
    m_trnplj:=m_brsl-m_uzetoplj+m_pkol
  ENDIF

  **Ispis podataka o bazi, slogovima i poljima**
  @ 1,1 CLEAR TO 1,78
  @ 1,1 SAY "Pretrazena baza:"+ALLTRIM(UPPER(m_baza))+;
            " * Slog:"+ALLTRIM(STR(m_trnslg))+"/"+ALLTRIM(STR(m_prtbrs))+;
            " * Polje:"+ALLTRIM(STR(m_trnplj))+"/"+;
            ALLTRIM(STR(m_brsl)) COLOR "R+/B"

  *****Zastoj za prihvat pritisnutog tastera*****
  IF m_novupis="NIJE"
    INKEY(0)
  ENDIF

***Izlazak iz pregleda podataka, na nivo za izbor baze***
*------- Prekid i vracanje u izbor databaze
  IF LASTKEY()=27
    CLOSE
    ERASE bzzavred.dbf
    SELECT 6
    CLOSE
    ERASE osobpret.dbf
    SELECT 8
    CLOSE
    ERASE bzzapret
    IF FILE("gdlistpg.ntx")
      ERASE gdlistpg.ntx
    ENDIF
    SELECT 8
    ERASE gdlistpg.ntx
    RETURN


***Izbor stampe i stampanje (F9)***
  ELSEIF LASTKEY()=-8
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    CLS
    *Upitni meni***
    p_xizbor:=1
    DO WHILE .T.
      @ 6,27 TO 10,51
      @ 1,22 SAY "S T A M P A NJ E   P O D A T A K A"
      @ 22,34 SAY "Izlaz->Esc"
      @ 7,33 PROMPT "Predaja naloga";
      MESSAGE ("Prezime*Ime*Serija_No*Nalog_prim*Dan_predat")
      @ 9,33 PROMPT "Nosilac naloga";
      MESSAGE ("Prezime*Ime*Serija_No*Odlazak*Odrediste*Povratak")
      CLEAR TYPEAHEAD
      MENU TO p_xizbor
      DO CASE
        CASE p_xizbor=0
        CLS
        EXIT
      CASE p_xizbor=1
        DO stmppred
        SET COLOR TO "G+/B"
        CLS
      CASE p_xizbor=2
        DO stmpnosi
        SET COLOR TO "G+/B"
        CLS
      ENDCASE
    ENDDO
    GO TOP
    m_trnslg:=1
    m_pred:=0
    SET COLOR TO "BG+/B"
    CLS
    LOOP


***Indeksiranje i redjanje podataka***
*------- Pregled kolone (1)
  ELSEIF LASTKEY()=49
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#12
      m_gdlist:=12
      INDEX ON prezime+ime TO gdlistpg.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=12
      m_gdlist:=11
      INDEX ON DESCEND(prezime+ime) TO gdlistpg.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*--------- Pregled kolone (2)
  ELSEIF LASTKEY()=50
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#22
      m_gdlist:=22
      INDEX ON ime+prezime TO gdlistpg.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=22
      m_gdlist:=21
      INDEX ON DESCEND(ime+prezime) TO gdlistpg.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (3)
  ELSEIF LASTKEY()=51
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#32
      m_gdlist:=32
      INDEX ON DTOS(odlazak)+DTOS(povratak) TO gdlistpg.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=32
      m_gdlist:=31
      INDEX ON DESCEND(DTOS(odlazak)+DTOS(povratak)) TO gdlistpg.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (4) 
  ELSEIF LASTKEY()=52
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#42
      m_gdlist:=42
      INDEX ON DTOS(povratak)+DTOS(odlazak) TO gdlistpg.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=42
      m_gdlist:=41
      INDEX ON DESCEND(DTOS(povratak)+DTOS(odlazak)) TO gdlistpg.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (5)
    ELSEIF LASTKEY()=53
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#52
      m_gdlist:=52
      INDEX ON serija_no TO gdlistpg.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=52
      m_gdlist:=51
      INDEX ON DESCEND(serija_no) TO gdlistpg.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (6)
    ELSEIF LASTKEY()=54
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#62
      m_gdlist:=62
      INDEX ON odrediste+prezime+ime TO gdlistpg.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=62
      m_gdlist:=61
      INDEX ON DESCEND(odrediste+prezime+ime) TO gdlistpg.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (7)
    ELSEIF LASTKEY()=55
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#72
      m_gdlist:=72
      INDEX ON nalog_prim+DTOS(dan_predat) TO gdlistpg.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=72
      m_gdlist:=71
      INDEX ON DESCEND(nalog_prim+DTOS(dan_predat)) TO gdlistpg.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF

*-------- Pregled kolone (8)
    ELSEIF LASTKEY()=56
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    *Vraca ako je baza prazna*
    IF m_brslbz=0
      @ 23,1 CLEAR TO 23,78
      @ 23,27 SAY "Databaza nema podataka !"
      INKEY(1.6)
      LOOP
    ENDIF
    m_trnslg:=1
    m_pred:=0
    @ 23,1 CLEAR TO 23,78
    @ 23,27 SAY "R E Dj A M   P O D A T K E" COLOR "RB+/B"
    SELECT 8
    IF FILE("gdlistpg.ntx")
      CLOSE INDEXES
      ERASE gdlistpg.ntx
    ENDIF
    *Listanje od gore*
    IF m_gdlist#82
      m_gdlist:=82
      INDEX ON DTOS(dan_predat)+nalog_prim TO gdlistpg.ntx
      @ 23,34 SAY "                    "
      LOOP
    *Listanje od dole*
    ELSEIF m_gdlist=82
      m_gdlist:=81
      INDEX ON DESCEND(DTOS(dan_predat)+nalog_prim) TO gdlistpg.ntx
      SELECT 3
      @ 23,34 SAY "                    "
      LOOP
    ENDIF


***Pomeranje podataka***
*------- Pritisnut taster za levo
  ELSEIF LASTKEY()=19
    m_gdlist:=1
    m_ponprt="NE"
    m_zadnplj:="N"
    IF m_taster="L" .AND. m_pkol#1
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_pkol=1
      m_taster:="L"
      *Izbacuje korekciju krajnjeg desnog ispisa jer se ekran pomera u desno*
      m_kortrp:="N"
      IF m_pocpolje=1
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE U LEVO" COLOR "RB+/B"
        INKEY (1.1)
        @ 23,34 SAY "                 "
        LOOP
      ELSEIF m_pocpolje>1
        m_pomekr:="D"
        m_trnplj:=m_trnplj-1
        LOOP
      ENDIF
    ENDIF
    m_pkol:=m_pkol-1
    m_trnplj:=m_trnplj-1
    LOOP

*------- Pritisnut taster za desno
  ELSEIF LASTKEY()=4
    m_gdlist:=1
    m_taster:="D"
    m_prvoplj:="N"
    m_ponprt="NE"
    IF m_pkol=m_uzetoplj
      IF m_pocpolje+m_uzetoplj=m_brsl+1
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE U DESNO" COLOR "RB+/B"
        INKEY (1.1)
        @ 23,34 SAY "                  "
        LOOP
      ELSEIF m_pocpolje+m_uzetoplj<m_brsl+1
        m_pomekr:="D"
        m_pocpolje:=m_pocpolje+m_uzetoplj
        m_trnplj:=m_trnplj+1
        LOOP
      ENDIF
    ENDIF
    m_pkol:=m_pkol+1
    m_trnplj:=m_trnplj+1
    LOOP


*****Kretanje gore-dole*****
*------- Na gore po jedan
  ELSEIF LASTKEY()=5 
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    IF m_pred=0
      SELECT 8
      SKIP -1
      IF BOF()
        @ 23,1 CLEAR TO 23,78
        @ 23,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
        INKEY(1.2)                 
        @ 23,34 SAY "                  " 
        GO TOP
        LOOP
      ENDIF
      m_trnslg:=m_trnslg-1
      LOOP
    ENDIF
    m_pred:=m_pred-1
    m_trnslg:=m_trnslg-1
    LOOP

*------- Na gore skok
  ELSEIF LASTKEY()=18
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 8
    SKIP -1
    IF BOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA GORE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      GO TOP
      LOOP
    ENDIF
    SKIP -16
    IF BOF()
      GO TOP
      m_trnslg:=m_pred+1
      LOOP
    ENDIF
    m_trnslg:=m_trnslg-17
    LOOP

*------- Na dole po jedan
  ELSEIF LASTKEY()=24 
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    m_pred:=m_pred+1
    SELECT 8
    SKIP m_pred
    IF EOF()
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      SKIP -m_pred
      m_pred:=m_pred-1
      LOOP
    ENDIF
    SKIP -m_pred
    IF m_pred=17
      m_pred:=16
      SKIP
    ENDIF
    m_trnslg:=m_trnslg+1
    LOOP

*------- Na dole skok
  ELSEIF LASTKEY()=3
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    SELECT 8
    SKIP 17
    IF EOF()  .AND. m_brslbz>17
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      GO BOTTOM
      SKIP -16
      LOOP
    ELSEIF EOF() .AND. m_brslbz<18
      @ 23,1 CLEAR TO 23,78
      @ 23,34 SAY "NEMA DALJE NA DOLE" COLOR "RB+/B"
      INKEY(1.2)
      @ 23,34 SAY "                  " 
      GO TOP
      LOOP
    ENDIF
    SKIP 17
    IF EOF()
      GO BOTTOM
      SKIP -16
      SELECT 3
      m_trnslg:=m_brslbz-(16-m_pred)
      LOOP
    ENDIF
    SKIP -17
    m_trnslg:=m_trnslg+17
    LOOP

*------- Neka druga tipka
  ELSE
    IF m_taster="L"
      m_pocpolje:=m_pocpolje+m_uzetoplj
    ENDIF
    @ 23,1 CLEAR TO 23,78
    @ 23,34 SAY "POGRESAN TASTER" COLOR "RB+/B"
    INKEY(1.7)
    @ 23,34 SAY "               " 
    IF m_brslbz<18
      SELECT 8
      GO TOP
    ENDIF
    LOOP
  ENDIF

ENDDO



*************************************************************
PROCEDURE STMPPRED
***********Stampanje podataka o predatim nalozima************

SET COLOR TO "N/GR+"
SELECT 8
CLS

***Kontrolise da li je stampac prikljucen na paralelni port***
IF ! ISPRINTER()
  @ 12,28 SAY "Stampac nije prikljucen !"
  INKEY(4)
  CLEAR SCREEN
  RETURN
ENDIF

**Obavestenje o broju potrbnih strana**
m_brojsx:=0
m_brojst:=0
m_brojst:=m_prtbrs/55
m_brojsx:=INT(m_brojst)
IF m_brojst>m_brojsx
  m_brojst:=m_brojsx+1
ENDIF
@ 10,27 SAY "Broj papira za stampanje:"+ALLTRIM(STR(m_brojst))            
INKEY(7)

***Upucuje ispis na stampac***
SET DEVICE TO PRINTER
*  SET PRINTER TO provstmp

***Ispis***
GO TOP
m_brzast:=0
DO WHILE .T.
  ***Zaglavlje***
  *Gornja linija*
  @ 1,1 SAY CHR(218)
  @ 1,2 SAY REPLICATE(CHR(196),15)
  @ 1,17 SAY CHR(194)
  @ 1,18 SAY REPLICATE(CHR(196),12)
  @ 1,30 SAY CHR(194)
  @ 1,31 SAY REPLICATE(CHR(196),9)
  @ 1,40 SAY CHR(194)
  @ 1,41 SAY REPLICATE(CHR(196),25)
  @ 1,66 SAY CHR(194)
  @ 1,67 SAY REPLICATE(CHR(196),8)
  @ 1,75 SAY CHR(191)
  *Zaglavlje*
  @ 2,1 SAY CHR(179)
  @ 2,6 SAY "PREZIME"
  @ 2,17 SAY CHR(179)
  @ 2,22 SAY "IME"
  @ 2,30 SAY CHR(179)
  @ 2,31 SAY "SERIJA_NO"
  @ 2,40 SAY CHR(179)
  @ 2,46 SAY "NALOG_PRIMIO"
  @ 2,66 SAY CHR(179)
  @ 2,67 SAY "DAN_PRED"
  @ 2,75 SAY CHR(179)
  *Donja linija zaglavlja*
  @ 3,1 SAY CHR(195)
  @ 3,2 SAY REPLICATE(CHR(196),15)
  @ 3,17 SAY CHR(197)
  @ 3,18 SAY REPLICATE(CHR(196),12)
  @ 3,30 SAY CHR(197)
  @ 3,31 SAY REPLICATE(CHR(196),9)
  @ 3,40 SAY CHR(197)
  @ 3,41 SAY REPLICATE(CHR(196),25)
  @ 3,66 SAY CHR(197)
  @ 3,67 SAY REPLICATE(CHR(196),8)
  @ 3,75 SAY CHR(180)
  ***Ispis podataka***
  m_brzais:=0
  DO WHILE .T.
    m_brzais:=m_brzais+1
    @ 3+m_brzais,1 SAY CHR(179)
    @ 3+m_brzais,2 SAY prezime
    @ 3+m_brzais,17 SAY CHR(179)
    @ 3+m_brzais,18 SAY ime
    @ 3+m_brzais,30 SAY CHR(179)
    @ 3+m_brzais,32 SAY serija_no
    @ 3+m_brzais,40 SAY CHR(179)
    @ 3+m_brzais,41 SAY nalog_prim
    @ 3+m_brzais,66 SAY CHR(179)
    @ 3+m_brzais,67 SAY dan_predat
    @ 3+m_brzais,75 SAY CHR(179)
    SKIP
    IF m_brzais=55 .OR. EOF()
      EXIT
    ENDIF
  ENDDO
  IF m_brzais<55
    m_linije:=55-m_brzais
    FOR t=1 TO m_linije
      @ 3+m_brzais+t,1 SAY CHR(179)
      @ 3+m_brzais+t,17 SAY CHR(179)
      @ 3+m_brzais+t,30 SAY CHR(179)
      @ 3+m_brzais+t,40 SAY CHR(179)
      @ 3+m_brzais+t,66 SAY CHR(179)
      @ 3+m_brzais+t,75 SAY CHR(179)
    NEXT
  ENDIF
  *Donja linija*
  @ 59,1 SAY CHR(192)
  @ 59,2 SAY REPLICATE(CHR(196),15)
  @ 59,17 SAY CHR(193)
  @ 59,18 SAY REPLICATE(CHR(196),12)
  @ 59,30 SAY CHR(193)
  @ 59,31 SAY REPLICATE(CHR(196),9)
  @ 59,40 SAY CHR(193)
  @ 59,41 SAY REPLICATE(CHR(196),25)
  @ 59,66 SAY CHR(193)
  @ 59,67 SAY REPLICATE(CHR(196),8)
  @ 59,75 SAY CHR(217)
  *Obelezavanje stranice*
  m_brzast:=m_brzast+1
  @ 60,32 SAY "Strana:"+ALLTRIM(STR(m_brzast))+"/"+ALLTRIM(STR(m_brojst))
  IF EOF()
    EXIT
  ENDIF
ENDDO


**Kraj stampe**
SET DEVICE TO SCREEN
CLEAR SCREEN
RETURN



*************************************************************
PROCEDURE STMPNOSI
***********Stampanje podataka o predatim nalozima************

SET COLOR TO "N/GR+"
SELECT 8
CLS

***Kontrolise da li je stampac prikljucen na paralelni port***
IF ! ISPRINTER()
  @ 12,28 SAY "Stampac nije prikljucen !"
  INKEY(5)
  CLEAR SCREEN
  RETURN
ENDIF

**Obavestenje o broju potrbnih strana**
m_brojsx:=0
m_brojst:=0
m_brojst:=m_prtbrs/55
m_brojsx:=INT(m_brojst)
IF m_brojst>m_brojsx
  m_brojst:=m_brojsx+1
ENDIF
@ 10,27 SAY "Broj papira za stampanje:"+ALLTRIM(STR(m_brojst))            
INKEY(7)
CLS

***Upucuje ispis na stampac***
SET DEVICE TO PRINTER
*  SET PRINTER TO provstmp

***Ispis***
GO TOP
m_brzast:=0
DO WHILE .T.
  ***Zaglavlje***
  *Gornja linija*
  @ 1,1 SAY CHR(218)
  @ 1,2 SAY REPLICATE(CHR(196),15)
  @ 1,17 SAY CHR(194)
  @ 1,18 SAY REPLICATE(CHR(196),12)
  @ 1,30 SAY CHR(194)
  @ 1,31 SAY REPLICATE(CHR(196),9)
  @ 1,40 SAY CHR(194)
  @ 1,41 SAY REPLICATE(CHR(196),8)
  @ 1,49 SAY CHR(194)
  @ 1,50 SAY REPLICATE(CHR(196),15)
  @ 1,65 SAY CHR(194)
  @ 1,66 SAY REPLICATE(CHR(196),8)
  @ 1,74 SAY CHR(191)
  *Zaglavlje*
  @ 2,1 SAY CHR(179)
  @ 2,6 SAY "PREZIME"
  @ 2,17 SAY CHR(179)
  @ 2,22 SAY "IME"
  @ 2,30 SAY CHR(179)
  @ 2,31 SAY "SERIJA_NO"
  @ 2,40 SAY CHR(179)
  @ 2,41 SAY "ODLAZAK"
  @ 2,49 SAY CHR(179)
  @ 2,53 SAY "ODREDISTE"
  @ 2,65 SAY CHR(179)
  @ 2,66 SAY "POVRATAK"
  @ 2,74 SAY CHR(179)
  *Donja linija zaglavlja*
  @ 3,1 SAY CHR(195)
  @ 3,2 SAY REPLICATE(CHR(196),15)
  @ 3,17 SAY CHR(197)
  @ 3,18 SAY REPLICATE(CHR(196),12)
  @ 3,30 SAY CHR(197)
  @ 3,31 SAY REPLICATE(CHR(196),9)
  @ 3,40 SAY CHR(197)
  @ 3,41 SAY REPLICATE(CHR(196),8)
  @ 3,49 SAY CHR(197)
  @ 3,50 SAY REPLICATE(CHR(196),15)
  @ 3,65 SAY CHR(197)
  @ 3,66 SAY REPLICATE(CHR(196),8)
  @ 3,74 SAY CHR(180)
  ***Ispis podataka***
  m_brzais:=0
  DO WHILE .T.
    m_brzais:=m_brzais+1
    @ 3+m_brzais,1 SAY CHR(179)
    @ 3+m_brzais,2 SAY prezime
    @ 3+m_brzais,17 SAY CHR(179)
    @ 3+m_brzais,18 SAY ime
    @ 3+m_brzais,30 SAY CHR(179)
    @ 3+m_brzais,31 SAY serija_no
    @ 3+m_brzais,40 SAY CHR(179)
    @ 3+m_brzais,41 SAY odlazak
    @ 3+m_brzais,49 SAY CHR(179)
    @ 3+m_brzais,50 SAY odrediste
    @ 3+m_brzais,65 SAY CHR(179)
    @ 3+m_brzais,66 SAY povratak
    @ 3+m_brzais,74 SAY CHR(179)
    SKIP
    IF m_brzais=55 .OR. EOF()
      EXIT
    ENDIF
  ENDDO
  IF m_brzais<55
    m_linije:=55-m_brzais
    FOR t=1 TO m_linije
      @ 3+m_brzais+t,1 SAY CHR(179)
      @ 3+m_brzais+t,17 SAY CHR(179)
      @ 3+m_brzais+t,30 SAY CHR(179)
      @ 3+m_brzais+t,40 SAY CHR(179)
      @ 3+m_brzais+t,49 SAY CHR(179)
      @ 3+m_brzais+t,65 SAY CHR(179)
      @ 3+m_brzais+t,74 SAY CHR(179)
    NEXT
  ENDIF
  *Donja linija*
  @ 59,1 SAY CHR(192)
  @ 59,2 SAY REPLICATE(CHR(196),15)
  @ 59,17 SAY CHR(193)
  @ 59,18 SAY REPLICATE(CHR(196),12)
  @ 59,30 SAY CHR(193)
  @ 59,31 SAY REPLICATE(CHR(196),9)
  @ 59,40 SAY CHR(193)
  @ 59,41 SAY REPLICATE(CHR(196),8)
  @ 59,49 SAY CHR(193)
  @ 59,50 SAY REPLICATE(CHR(196),15)
  @ 59,65 SAY CHR(193)
  @ 59,66 SAY REPLICATE(CHR(196),8)
  @ 59,74 SAY CHR(217)
  *Obelezavanje stranice*
  m_brzast:=m_brzast+1
  @ 60,31 SAY "Strana:"+ALLTRIM(STR(m_brzast))+"/"+ALLTRIM(STR(m_brojst))
  IF EOF()
    EXIT
  ENDIF
ENDDO


**Kraj stampe**
SET DEVICE TO SCREEN
CLEAR SCREEN
RETURN





