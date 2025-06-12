-- 1. Komitenti
-- 2. Ugovori
-- 3. TabNaziv
-- 4. SifTabCen(Datum)
-- 5. TabDatumM(Datum)
-- 6. TabMase
-- 7. TabRel(Datum)
-- 8. TabStavR


------------------------------- U G O V O R I 
Select * from Ugovori where Substring(BrojUgovora,1,4)='6007'

/*
Select * from Ugovori where Substring(BrojUgovora,1,4)='0507'


Drop table _Ugovori
Select * from Ugovori where Substring(BrojUgovora,1,4)='4606'

Select * into _Ugovori from Ugovori where Substring(BrojUgovora,1,4)=4606
Select * from _Ugovori

Update _Ugovori
Set BrojUgovora = Left(BrojUgovora,3) + '7' + Right(BrojUgovora,2)
Select * from _Ugovori

Insert into Ugovori Select * from _Ugovori
Select * from Ugovori where Substring(BrojUgovora,1,4)=6007
*/


Drop table _Ugovori
Select * into _Ugovori from Ugovori where Substring(BrojUgovora,1,4)= '0507'
--Select * FROM _Ugovori
--Select * into _Ugovori from Ugovori where Substring(BrojUgovora,1,4)= '1906'

Update _Ugovori
--Set BrojUgovora = '6007' + Right(BrojUgovora,2)
Set BrojUgovora = Left(BrojUgovora,3) + '7' + Right(BrojUgovora,2)

Insert into Ugovori Select * from _Ugovori

-------------------------------  1.Izmena podataka u tabeli TabNaziv


Drop table _TabNaziv
Select * into _TabNaziv from TabNaziv where Substring(Ugovor,1,4)= '1906'

Update _TabNaziv
Set Ugovor = Left(Ugovor,3) + '7' + Right(Ugovor,2)

Insert into TabNaziv Select * from _TabNaziv


------------------------------- 2. Izmena podataka u tabeli SifTabCen(Datum)

Drop table _SifTabCen
Select * into _SifTabCen from SifTabCen where Substring(Ugovor,1,4)='1906'

Update _SifTabCen
Set Ugovor = Left(Ugovor,3) + '7' + Right(Ugovor,2), VaziOD='02/01/2007', VaziDo='1/31/2008'

Insert into SifTabCen Select * from _SifTabCen



------------------------------- 3. Izmena podataka u tabeli TabDatumM(Datum)

Drop table _TabDatumM
Select * into _TabDatumM from TabDatumM where Substring(Ugovor,1,4)='1906'

Update _TabDatumM
Set Ugovor = Left(Ugovor,3) + '7' + Right(Ugovor,2), DatumOD='02/01/2007', DatumDo='1/31/2008'

Insert into TabDatumM Select * from _TabDatumM


------------------------------- 4. Izmena podataka u tabeli TabMase


Drop table _TabMase
Select * into _TabMase from TabMase where Substring(Ugovor,1,4)= '1906'

Update _TabMase
Set Ugovor = Left(Ugovor,3) + '7' + Right(Ugovor,2)

Insert into TabMase Select * from _TabMase


------------------------------- 5. Izmena podataka u tabeli TabRel(Datum)


Drop table _TabRel
Select * into _TabRel from TabRel where Ugovor= '050700'
--Select * into _TabRel from TabRel where Substring(Ugovor,1,4)= '0507'
--Set Ugovor = '1907' + Right(Ugovor,2)

Update _TabRel
Set Ugovor = '190700'

Insert into TabRel Select * from _TabRel

----------------------------------- 6. Izmena podataka u tabeli TabStavR

Drop table _TabStavR
Select * into _TabStavR from TabStavR where Ugovor = '050700'
--Select * into _TabStavR from TabStavR where Substring(Ugovor,1,4)= '0507'

Update _TabStavR
Set Ugovor = '190700'
--Set Ugovor = '3707' + Right(Ugovor,2)

Insert into TabStavR Select * from _TabStavR

