

SET CONFIRM ON
SET COLOR TO "BG/RB,G/RB"
CLS


***Postavka matrica***

*Matrica za dane u mesecu*
DECLARE mtr1[12]
mtr1[1]:=31
mtr1[2]:=28
mtr1[3]:=31
mtr1[4]:=30
mtr1[5]:=31
mtr1[6]:=30
mtr1[7]:=31
mtr1[8]:=31
mtr1[9]:=30
mtr1[10]:=31
mtr1[11]:=30
mtr1[12]:=31

*Matrica za dane u nedelji nove ere*
DECLARE mtr2[7]
mtr2[1]:="Subota"
mtr2[2]:="Nedelja"
mtr2[3]:="Ponedeljak"
mtr2[4]:="Utorak"
mtr2[5]:="Sreda"
mtr2[6]:="Cetvrtak"
mtr2[7]:="Petak"

*Matrica za dane u nedelji pre nove ere*
DECLARE mtr3[7]
mtr3[1]:="Nedelja"
mtr3[2]:="Subota"
mtr3[3]:="Petak"
mtr3[4]:="Cetvrtak"
mtr3[5]:="Sreda"
mtr3[6]:="Utorak"
mtr3[7]:="Ponedeljak"
***Unos podataka***


DO WHILE .T.

  DO WHILE .T.
  
    CLS
      
    m_god:=0
    m_mes:=0
    m_dan:=0
    m_era:=1

    m_prestup:=0
    m_isprm:=1
    m_isprd:=1
    m_isprav:=0

    @ 3,20 SAY "Cao Majo srce milo, pa 'de si ti meni!"
    @ 7,27 SAY "Dan (32>d>0)  :"
    @ 8,27 SAY "Mesec (13>m>0):"
    @ 9,27 SAY "Godina (g>=0) :"
    @ 0,70 SAY "Esc->Kraj"
    @ 7,44 GET m_dan PICTURE "@B 99" VALID (32>m_dan .AND. m_dan>0)
    @ 8,44 GET m_mes PICTURE "@B 99" VALID (13>m_mes .AND. m_mes>0)
    @ 9,44 GET m_god PICTURE "@B 999999999" VALID (m_god>=0)
    READ

    IF LASTKEY()=27
      CLS
      @ 12,20 SAY "Zdravo srce, vidimo se !"
      INKEY(2)
      SET COLOR TO "W/N"
      CLS
      QUIT
    ENDIF
  
    @ 14,27 PROMPT "Nove ere"
    @ 14,38 PROMPT "Pre nove ere"
    MENU TO m_era

    FOR a=1 TO 12
      IF m_mes=a
        m_isprm:=1
        m_isprav:=1
        EXIT
      ELSE
        m_isprm:=0   
      ENDIF
    NEXT
    IF m_isprm=0
      @ 11,44 SAY "Mesec nije pravilno upisan!"
      m_mes:=0
      INKEY(3)
      LOOP
    ENDIF
      
    m_prestup:=m_god/4-INT(m_god/4)
    IF m_prestup=0
      IF m_mes=2
        IF m_dan>29
          @ 12,44 SAY "Februar prestupne godine nema vise od 29 dana!"
          m_dan:=0
          LOOP
        ELSE
          m_isprav:=1
        ENDIF
      ENDIF
    ENDIF
  
    IF m_prestup#0 .AND. m_dan>mtr1[m_mes] 
      m_isprd:=0
      @ 12,44 SAY "Unetom mesecu neodgovara broj dana!"
      m_dan:=0
      INKEY(3)
      LOOP
    ELSEIF m_prestup=0 .AND. m_mes=2 .AND. m_dan>mtr1[m_mes]+1
      m_isprd:=0
      @ 12,44 SAY "Unetom mesecu neodgovara broj dana!"
      m_dan:=0
      INKEY(3)
      LOOP
    ELSEIF m_prestup=0 .AND. m_mes#2 .AND. m_dan>mtr1[m_mes]
      m_isprd:=0
      @ 12,44 SAY "Unetom mesecu neodgovara broj dana!"
      m_dan:=0
      INKEY(3)
      LOOP
    ELSE
      m_isprd:=1
      m_isprav:=1
    ENDIF
  
    IF m_isprav=1
      EXIT
    ENDIF
  ENDDO
  
  ***Sabiranje dana***

  m_dans:=0
  m_mes2:=0
  m_mess:=0
  m_gods:=0
  m_gops:=0
  m_danuku:=0

  *Dana*
  m_dans:=m_dan
  *Dana po mesecima*
  m_mes2:=m_mes-1
  FOR b=1 TO m_mes2
    m_mess:=m_mess+mtr1[b]
  NEXT
  *Dana po godinama*
  IF m_god>0
    m_gods:=365*(m_god-1)
  ENDIF
  *Dana po prestupnim godinama*
  m_gops:=INT(m_god/4)+1
  *Ukupno dana*
  m_danuku:=m_dans+m_mess+m_gods+m_gops
  IF m_prestup=0
    IF m_era=1
      IF m_mes<3
        m_danuku:=m_danuku-1
      ENDIF
    ELSEIF m_era=2
      IF m_mes>2
        m_danuku:=m_danuku+1
      ENDIF
    ENDIF
  ENDIF

  ***Racunanje dana u nedelji***

  m_danned:=0
  m_danraz:=0

  m_danned:=INT(m_danuku/7)*7
  m_danraz:=m_danuku-m_danned
  IF m_danraz=0
    m_danraz:=7
  ENDIF

  ***Ispis nadjenog dana nedelje***

  IF m_era=1      
    @ 17,8 SAY "Datum: "+ALLTRIM(STR(m_dan))+"/"+;
               ALLTRIM(STR(m_mes))+"/"+ALLTRIM(STR(m_god))+;
               " godine"+" nove ere "+" -> Dan u nedelji: "+;
               mtr2[m_danraz]
  ELSEIF m_era=2
    @ 17,8 SAY "Datum: "+ALLTRIM(STR(m_dan))+"/"+;
               ALLTRIM(STR(m_mes))+"/"+ALLTRIM(STR(m_god))+;
               " godine"+" pre nove ere "+" -> Dan u nedelji: "+;
               mtr3[m_danraz]
  ENDIF

  ***Upit za dalji rad***
  
  m_izabir:=SPACE(1)
  @ 19,20 SAY "Da li zelis da nastavis (D/N) ?";
          GET m_izabir PICTURE "!" VALID(m_izabir $ "DdNn")
  READ

  CLS
  IF m_izabir="N" .OR. m_izabir="n"
    EXIT
  ENDIF

ENDDO
CLS
@ 12,20 SAY "Zdravo srce, vidimo se !"
INKEY(2)
SET COLOR TO "W/N"
CLS
QUIT



