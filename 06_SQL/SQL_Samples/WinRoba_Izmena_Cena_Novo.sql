-- 1. Komitenti
-- 2. Ugovori
-- 3. TabNaziv
-- 4. SifTabCen
-- 5. TabDatumM
-- 6. TabMase
-- 7. TabRel
-- 8. TabStavR



-- UGOVORI
Drop table _Ugovori
Select * from Ugovori where Substring(BrojUgovora,1,4)=0606

Select * into _Ugovori from Ugovori where Substring(BrojUgovora,1,4)=0606
Select * from _Ugovori

Insert into Ugovori
Select * from _Ugovori

Select * from Ugovori where Substring(BrojUgovora,1,4)=0607
Drop table _Ugovori



-- 1.Izmena podataka u tabeli TabNaziv
Select * from TabNaziv where ugovor=060692

Drop table _TabNaziv
Select * into _TabNaziv from TabNaziv where Ugovor='060611'
Select * from _TabNaziv

Update _TabNaziv
Set Ugovor ='060702'
Select * from _TabNaziv

Insert into TabNaziv
Select * from _TabNaziv

Select * from TabNaziv where Ugovor='060702'
Drop table _TabNaziv



--2. Izmena podataka u tabeli SifTabCen

Select * from SifTabCen where Substring(Ugovor,1,4)=0607

Drop table _SifTabCen
Select * into _SifTabCen from SifTabCen where Substring(Ugovor,1,4)=0606
Select * from _SifTabCen

Update _SifTabCen
Set VaziOD='02/01/2007',VaziDo='1/31/2008'

Insert into SifTabCen Select * from _SifTabCen

--Select * from SifTabCen where Ugovor='050702'
--Drop table _SifTabCen



--3. Izmena podataka u tabeli TabDatumM


Select * from TabDatumM where Substring(Ugovor,1,4)=0606

-- redom: 00,01,02
	Drop table _TabDatumM
	Select * into _TabDatumM from TabDatumM where Ugovor='060602'
	Select * from _TabDatumM

	Update _TabDatumM
	Set Ugovor ='060702',DatumOD='02/01/2007',DatumDo='1/31/2008'
	Select * from _TabDatumM

	Insert into TabDatumM Select * from _TabDatumM

	Select * from TabDatumM where Ugovor='060702'
-- end redom: 00,01,02



--4. Izmena podataka u tabeli TabMase

Select * from TabMase where Substring(Ugovor,1,4)= '0606'

-- redom: 00,01,02
	Drop table _TabMase
	Select * into _TabMase from TabMase where Ugovor='060602'
	Select * from _TabMase

	Update _TabMase
	Set Ugovor ='060702'
	Select * from _TabMase

	Insert into TabMase Select * from _TabMase

	Select * from TabMase where Ugovor = '060702'
-- end redom: 00,01,02

-- 5. Izmena podataka u tabeli TabRel


Select * from TabRel where Substring(Ugovor,1,4)= '0606'

Drop table _TabRel_Nedostajuce_02
Select * into _TabRel_Nedostajuce_02 from TabRel where Ugovor='050702'
Select * from _TabRel_Nedostajuce_02

Update _TabRel_Nedostajuce_02
Set Ugovor ='060702'

	Select * from _TabRel_Nedostajuce_02
	Update _TabRel_Nedostajuce
	Set Ugovor ='060701',DatumOD='02/01/2007',DatumDo='1/31/2008'
	Select * from _TabRel

		Insert into TabRel Select * from _TabRel_Nedostajuce_02

-- redom: 00,01,02
	Drop table _TabRel
	Select * into _TabRel from TabRel where Ugovor='060602'
	Select * from _TabRel
	-- Select * from _TabRel_noverelacije

	Update _TabRel
	Set Ugovor ='060702',DatumOD='02/01/2007',DatumDo='1/31/2008'
	Select * from _TabRel

	Insert into TabRel Select * from _TabRel
        -- Insert into TabRel Select * from _TabRel_NoveRelacije

	Select * from TabRel where Ugovor = '060702'
-- end redom: 00,01,02



--6. Izmena podataka u tabeli TabStavR

	Select * from TabStavR where Ugovor='050701'

-- Pojedinacne
	Drop table _TabStavR_00
	Select * into _TabStavR_00 from TabStavR where Ugovor='050700'
	Select * from _TabStavR_00

	Update _TabStavR_00
	Set Ugovor ='060700'
	Select * from _TabStavR_00

	Insert into TabStavR select * from _TabStavR_00
-- Grupe
	Drop table _TabStavR_02
	Select * into _TabStavR_02 from TabStavR where Ugovor='050702'
	Select * from _TabStavR_02

	Update _TabStavR_02
	Set Ugovor ='060702'
	Select * from _TabStavR_02
	
	Insert into TabStavR select * from _TabStavR_02
-- Voz
	Drop table _TabStavR_01
	Select * into _TabStavR_01 from TabStavR where Ugovor='050701'
	Select * from _TabStavR_01

	Update _TabStavR_01
	Set Ugovor ='060701'
	Select * from _TabStavR_01

	Insert into TabStavR select * from _TabStavR_01


	--Drop table _TabRel
	--Select * into _TabRel from TabRel where Ugovor='050701'
	--Select * from _TabRel
	--Insert into TabRel select * from _TabRel

	--Drop table _TabStavR_01_pristanista

	--Select * into _TabStavR_01_pristanista from TabStavR where Ugovor='050701'
	--Select * from _TabStavR_01_pristanista
	--Insert into TabStavR select * from _TabStavR_01_pristanista 



	--Insert into TabStavR select * from _TabStavR_01_prijepolje 

	--Insert into TabStavR select * from _TabStavR_00
	--Select * from TabStavR


--prijepolje

Select * from TabRel where Ugovor='050701'
Select * from TabstavR where Ugovor='050601'


Select * from _TabRel_Noverelacije
Update _TabRel_Noverelacije
Set Ugovor ='050701', SifTab='210' 
Select * from _TabRel_Noverelacije
Insert into TabRel Select * from _TabRel_NoveRelacije


Select * from _TabStavR_02
Select * into _TabStavR_02_Prijepolje from _TabStavR_02
Select * from _TabStavR_02_Prijepolje



Select * into _TabStavR_02_ZaPrijepolje from TabStavR Where ugovor='050700'
Select * from _TabStavR_02_ZaPrijepolje
Insert into TabStavR Select * from _TabStavR_02_ZaPrijepolje

Insert into _TabStavR_02 Select * from _TabStavR_02_Prijepolje
-- end prijepolje

Update _TabStavR_02
Set Ugovor ='050702' 
Select * from _TabStavR_02

Insert into TabStavR
Select * from _TabStavR_02



Update PrivTabStavR
Set stav =7600
where relstavka='17' or relstavka='20'
Select * from PrivTabStavR

Select * from TabStavR where Ugovor ='050601'


Update PrivTabStavR
Set Ugovor ='580601'
Select * from PrivTabStavR

--!!! Treba izvrsiti samo ovaj kod
	Insert into TabStavR
	Select * from PrivTabStavR
Select * from TabStavR where Ugovor='580602' and siftab='191'

--uklanjanje privremene tabele
Drop table PrivTabStavR


--Provera Unetih izmena
Select * from TabNaziv where Substring(Ugovor,4,1)=7
Select * from TabNaziv where Substring(Ugovor,1,4)=1007


--Delete TabNaziv where Ugovor='100700' and SifTab='192'

Select * from SifTabCen where Substring(Ugovor,4,1)=7
--Delete SifTabCen where Ugovor='100700' and SifTab='192'

Select * from TabDatumM where Substring(Ugovor,4,1)=7

Select * from TabMase where Substring(Ugovor,4,1)=7

Select * from TabRel where Substring(Ugovor,4,1)=7

Select * from TabStavR where Substring(Ugovor,4,1)=7



--izmena

--Select * into t_ugovori from ugovori where brojUgovora=100722 or (brojUgovora=100701) -- and siftab=212)
Select * into t_tabnaziv from Tabnaziv where Ugovor=100722 or (Ugovor=100701 and siftab=212)
Select * into t_siftabcen from siftabcen where Ugovor=100722 or (Ugovor=100701 and siftab=212)
Select * into t_tabrel from tabrel where Ugovor=100722 or (Ugovor=100701 and siftab=212)
Select * into t_tabdatumm from tabdatumm where Ugovor=100722 or (Ugovor=100701 and siftab=212)
Select * into t_tabmase from tabmase where Ugovor=100722 or (Ugovor=100701 and siftab=212)
Select * into t_tabstavr from tabstavr where Ugovor=100722 or (Ugovor=100701 and siftab=212)

--Select * into t_tabnaziv from Tabnaziv where Ugovor=100722


Select * from ugovori where brojUgovora=100722
Select * from Tabnaziv where Ugovor=100722
Select * from sifTabcen where Ugovor=100722
Select * from Tabrel where Ugovor=100722
Select * from Tabdatumm where Ugovor=100722
Select * from Tabmase where Ugovor=100722
Select * from TabStavR where Ugovor=100722

Select * from Tabnaziv where Ugovor=100701 or Ugovor=100722