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
Select * from Ugovori where Substring(BrojUgovora,1,4)=4606

Select * into _Ugovori from Ugovori where Substring(BrojUgovora,1,4)=4606
Select * from _Ugovori

Update _Ugovori
Set BrojUgovora = Left(BrojUgovora,3) + '7' + Right(BrojUgovora,2)
Select * from _Ugovori

Insert into Ugovori Select * from _Ugovori
Select * from Ugovori where Substring(BrojUgovora,1,4)=3007


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
Set Ugovor = '4607' + Right(Ugovor,2)
Select * from _TabRel

Insert into TabRel Select * from _TabRel


/*
Priprema nedostajucih relacija(Prijepolje)

Drop table _TabRel_Nedostajuce_00
Select * into _TabRel_Nedostajuce_00 from TabRel where Ugovor='050700'
Select * from _TabRel_Nedostajuce_00

Drop table _TabRel_Nedostajuce_01
Select * into _TabRel_Nedostajuce_01 from TabRel where Ugovor='050701'
Select * from _TabRel_Nedostajuce_01

Drop table _TabRel_Nedostajuce_02
Select * into _TabRel_Nedostajuce_02 from TabRel where Ugovor='050702'
Select * from _TabRel_Nedostajuce_02
*/


/*
--Simplam nije imao sve relacije od prosle godine!

Drop table _TabRel_Nedostajuce_02_simplam
Select * into _TabRel_Nedostajuce_02_simplam from TabRel where Ugovor='050701'
Select * from _TabRel_Nedostajuce_02_simplam

--otici u Manager i u TabRel za taj ugovor ostaviti samo one relacije koje nedostaju u proslogodisnjem ugovoru

Update _TabRel_Nedostajuce_02_simplam
Set Ugovor ='160701'
*/

--drop table _TabRel_Nedostajuce_02_izFerspeda
--Select * into _TabRel_Nedostajuce_02_izFerspeda from TabRel where Ugovor='050700'
--Select * from TabRel where Substring(Ugovor,1,4)= '4606'


--promena broja ugovora u nedostajucim relacijama
/*
Update _TabRel_Nedostajuce_02
Set Ugovor ='300702'
Update _TabRel_Nedostajuce_01
Set Ugovor ='300701'
Update _TabRel_Nedostajuce_00
Set Ugovor ='300700'


Drop table _TabRel
Select * into _TabRel from TabRel where Substring(Ugovor,1,4)= '3006'
Select * from _TabRel

Update _TabRel
Set Ugovor = Left(Ugovor,3) + '7' + Right(Ugovor,2),DatumOD='02/01/2007', DatumDo='1/31/2008'
Select * from _TabRel

Insert into TabRel Select * from _TabRel

Insert into TabRel Select * from _TabRel_Nedostajuce_00
Insert into TabRel Select * from _TabRel_Nedostajuce_01
Insert into TabRel Select * from _TabRel_Nedostajuce_02


/*

	Ako nedostaju relacije!!!

*/

/*
Select * from _TabRel_Nedostajuce_02_Simplam  -- PELCER ZA NEDOSTAJUCE
Update _TabRel_Nedostajuce_02_Simplam
Set Ugovor = '300701', SifTab='210'
Select * from _TabRel_Nedostajuce_02_Simplam

Insert into TabRel Select * from _TabRel_Nedostajuce_02_Simplam


--Select * from TabRel where Substring(Ugovor,1,4)= '1607'
--Select * from TabRel where Ugovor= '160702'

*/

----------------------------------- 6. Izmena podataka u tabeli TabStavR

--Select * from TabStavR where Substring(Ugovor,1,4)= '3006'
--Select * from TabStavR where Ugovor= '300702'

Drop table _TabStavR
Select * into _TabStavR from TabStavR where Substring(Ugovor,1,4)= '0507'
Select * from _TabStavR

Update _TabStavR
Set Ugovor = '4607' + Right(Ugovor,2)
Select * from _TabStavR

Insert into TabStavR Select * from _TabStavR


/*
-- Pojedinacne
	Drop table _TabStavR_00
	Select * into _TabStavR_00 from TabStavR where Ugovor='050700' -- 0507 JE PELCER ZA CENE!
	Select * from _TabStavR_00

	Update _TabStavR_00
	Set Ugovor ='460700'
	Select * from _TabStavR_00

	Insert into TabStavR select * from _TabStavR_00
-- Grupe
	Drop table _TabStavR_02
	Select * into _TabStavR_02 from TabStavR where Ugovor='050702' -- 0507 JE PELCER ZA CENE!
	Select * from _TabStavR_02

	Update _TabStavR_02
	Set Ugovor ='460702'
	Select * from _TabStavR_02
	
	Insert into TabStavR select * from _TabStavR_02
-- Voz
	Drop table _TabStavR_01
	Select * into _TabStavR_01 from TabStavR where Ugovor='050701' -- 0507 JE PELCER ZA CENE!
	Select * from _TabStavR_01

	Update _TabStavR_01
	Set Ugovor ='460701'
	Select * from _TabStavR_01

	Insert into TabStavR select * from _TabStavR_01

*/