
Select * from TabNaziv where Substring(ugovor,1,4)=1006

-- 1.Izmena podataka u tabeli TabNaziv
Select * into PrivTabNaziv from TabNaziv where Ugovor='100600'
Select * from PrivTabNaziv

Update PrivTabNaziv
Set Ugovor ='110700'
Select * from PrivTabNaziv

Insert into TabNaziv
Select * from PrivTabNaziv

Select * from TabNaziv where Ugovor='110700'
--uklanjanje privremene tabele
Drop table PrivTabNaziv



--2. Izmena podataka u tabeli SifTabCena

Select *into PrivSifTabCen from SifTabCen where Ugovor='100700'--Substring(ugovor,1,4)=1006
Select * from PrivSifTabCen

Update PrivSifTabCen
Set Ugovor ='110700',VaziOD='01/01/2007',VaziDo='12/31/2007'
Select * from PrivSifTabCen
	--!!! Treba izvrsiti samo ovaj kod
	Insert into SifTabCen
	Select * from PrivSifTabCen 
--provera upisa podataka
Select * from SifTabCen where Ugovor='110700'
--uklanjanje privremene tabele
Drop table PrivSifTabCen

--3. Izmena podataka u tabeli TabDatumM
--Select * from TabDatumM where Ugovor='110600'
Select *into PrivTabDatumM from TabDatumM where Ugovor='100700'--Substring(ugovor,1,4)=1006
Select * from PrivTabDatumM

Update PrivTabDatumM
Set Ugovor ='110700',DatumOD='01/01/2007',DatumDo='12/31/2007'
Select * from PrivTabDatumM

--!!! Treba izvrsiti samo ovaj kod
	Insert into TabDatumM
	Select * from PrivTabDatumM

Select * from TabDatumM where Ugovor='110700'
--uklanjanje privremene tabele
Drop table PrivTabDatumM

--4. Izmena podataka u tabeli TabMase
Select * from TabMase where Ugovor='110600'
Select *into PrivTabMase from TabMase where Ugovor='100700'--Substring(ugovor,1,4)=1006
Select * from PrivTabMase

Update PrivTabMase
Set Ugovor ='110700'
Select * from PrivTabMase

--!!! Treba izvrsiti samo ovaj 
kod
	Insert into TabMase
	Select * from PrivTabMase
Select * from TabMase where Ugovor = '110700'
--uklanjanje privremene tabele
Drop table PrivTabMase


--5. Izmena podataka u tabeli TabRel
Select *into PrivTabRel from TabRel where Ugovor='100700'--substring(ugovor,1,4)=1006
Select * from PrivTabRel

Update PrivTabRel
Set Ugovor ='110700',DatumOD='01/01/2007',DatumDo='12/31/2007'
Select * from PrivTabRel

--!!! Treba izvrsiti samo ovaj kod
	Insert into TabRel
	Select * from PrivTabRel
--uklanjanje privremene tabele
Drop table PrivTabRel

Select * from TabRel where Ugovor = '110700'


--6. Izmena podataka u tabeli TabStavR

Select *into PrivTabStavR from TabStavR where Ugovor='100700'--Substring(ugovor,1,4)=1006
Select * from PrivTabStavR

Update PrivTabStavR
Set Ugovor ='110700'
Select * from PrivTabStavR

--!!! Treba izvrsiti samo ovaj kod
	Insert into TabStavR
	Select * from PrivTabStavR
Select * from TabStavR where Ugovor='110700'

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