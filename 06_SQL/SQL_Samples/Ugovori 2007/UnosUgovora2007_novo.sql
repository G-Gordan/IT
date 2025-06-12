-- 1. Komitenti
-- 2. Ugovori
-- 3. TabNaziv
-- 4. SifTabCen(Datum)
-- 5. TabDatumM(Datum)
-- 6. TabMase
-- 7. TabRel(Datum)
-- 8. TabStavR


------------------------------- U G O V O R I 

Drop table _Ugovori
Select * from Ugovori where Substring(BrojUgovora,1,4)=6006

Select * into _Ugovori from Ugovori where Substring(BrojUgovora,1,4)=4606
Select * from _Ugovori

Update _Ugovori
Set BrojUgovora = Left(BrojUgovora,3) + '7' + Right(BrojUgovora,2)
Select * from _Ugovori

Insert into Ugovori Select * from _Ugovori
Select * from Ugovori where Substring(BrojUgovora,1,4)=6007


-------------------------------  1.Izmena podataka u tabeli TabNaziv

Select * from TabNaziv where Substring(Ugovor,1,4)= '4606'

Drop table _TabNaziv
Select * into _TabNaziv from TabNaziv where Substring(Ugovor,1,4)= '4606'
Select * from _TabNaziv

Update _TabNaziv
Set Ugovor = Left(Ugovor,3) + '7' + Right(Ugovor,2)
Select * from _TabNaziv

Insert into TabNaziv Select * from _TabNaziv
Select * from TabNaziv where Substring(Ugovor,1,4)= '3007'


------------------------------- 2. Izmena podataka u tabeli SifTabCen(Datum)

Select * from SifTabCen where Substring(Ugovor,1,4)= '4606'

Drop table _SifTabCen
Select * into _SifTabCen from SifTabCen where Substring(Ugovor,1,4)='4606'
Select * from _SifTabCen

Update _SifTabCen
Set Ugovor = Left(Ugovor,3) + '7' + Right(Ugovor,2), VaziOD='02/01/2007', VaziDo='1/31/2008'
Select * from _SifTabCen

Insert into SifTabCen Select * from _SifTabCen
Select * from SifTabCen where Substring(Ugovor,1,4)= '3007'


------------------------------- 3. Izmena podataka u tabeli TabDatumM(Datum)

Select * from TabDatumM where Substring(Ugovor,1,4)= '4606'

Drop table _TabDatumM
Select * into _TabDatumM from TabDatumM where Substring(Ugovor,1,4)='4606'
Select * from _TabDatumM

Update _TabDatumM
Set Ugovor = Left(Ugovor,3) + '7' + Right(Ugovor,2), DatumOD='02/01/2007', DatumDo='1/31/2008'
Select * from _TabDatumM

Insert into TabDatumM Select * from _TabDatumM
Select * from TabDatumM where Substring(Ugovor,1,4)= '3007'


------------------------------- 4. Izmena podataka u tabeli TabMase

Select * from TabMase where Substring(Ugovor,1,4)= '4606'

Drop table _TabMase
Select * into _TabMase from TabMase where Substring(Ugovor,1,4)= '4606'
Select * from _TabMase

Update _TabMase
Set Ugovor = Left(Ugovor,3) + '7' + Right(Ugovor,2)
Select * from _TabMase

Insert into TabMase Select * from _TabMase
Select * from TabMase where Substring(Ugovor,1,4)= '3007'


------------------------------- 5. Izmena podataka u tabeli TabRel(Datum)

Select * from TabRel where Substring(Ugovor,1,4)= '0507'

Drop table _TabRel
Select * into _TabRel from TabRel where Substring(Ugovor,1,4)= '0507'
Select * from _TabRel

Update _TabRel
Set Ugovor = '3007' + Right(Ugovor,2)
Select * from _TabRel

Insert into TabRel Select * from _TabRel


----------------------------------- 6. Izmena podataka u tabeli TabStavR

Drop table _TabStavR
Select * into _TabStavR from TabStavR where Substring(Ugovor,1,4)= '0507'
Select * from _TabStavR

Update _TabStavR
Set Ugovor = '3007' + Right(Ugovor,2)
Select * from _TabStavR

Insert into TabStavR Select * from _TabStavR

