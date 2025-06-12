USE nalog
m_prezime:=" "
m_ime:=" "
m_odlazak:=DATE()
m_povratak:=DATE()
m_serija_no:=" "
m_odrediste:=" "
m_nalog_prim:=" "
m_dan_predat:=DATE()
FOR i=1 TO 200
  GOTO i
  m_prezime:=prezime
  m_ime:=ime
  m_odlazak:=odlazak
  m_povratak:=povratak
  m_serija_no:=serija_no
  m_odrediste:=odrediste
  m_nalog_prim:=nalog_prim
  m_dan_predat:=dan_predat
  APPEND BLANK
  REPLACE prezime WITH m_prezime, ime WITH m_ime, odlazak WITH m_odlazak,;
          povratak WITH m_povratak, serija_no WITH m_serija_no,;
          odrediste WITH m_odrediste, nalog_prim WITH m_nalog_prim,;
          dan_predat WITH m_dan_predat
NEXT
QUIT
