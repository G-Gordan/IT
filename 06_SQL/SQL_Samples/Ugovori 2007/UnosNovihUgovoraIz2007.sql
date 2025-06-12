Update _Ugovori
Set BrojUgovora = '7407' + Right(BrojUgovora,2),SifraKorisnika=112
Select * from _Ugovori

Update _TabNaziv
Set Ugovor = '7407' + Right(Ugovor,2)
Select * from _TabNaziv

Update _SifTabCen
Set Ugovor = '7407' + Right(Ugovor,2)
Select * from _SifTabCen

Update _TabDatumM
Set Ugovor = '7407' + Right(Ugovor,2)
Select * from _TabDatumM

Update _TabMase
Set Ugovor = '7407' + Right(Ugovor,2)
Select * from _TabMase

Update _TabRel
Set Ugovor = '7407' + Right(Ugovor,2)
Select * from _TabRel

Update _TabStavR
Set Ugovor = '7407' + Right(Ugovor,2)
Select * from _TabStavR

Insert into Ugovori Select * from _Ugovori
Insert into TabNaziv Select * from _TabNaziv
Insert into SifTabCen Select * from _SifTabCen
Insert into TabDatumM Select * from _TabDatumM
Insert into TabMase Select * from _TabMase
Insert into TabRel Select * from _TabRel
Insert into TabStavR Select * from _TabStavR

