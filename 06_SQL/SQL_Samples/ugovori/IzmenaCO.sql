
Select * from TabNaziv where Substring(ugovor,1,4)=1006

-- 1.Izmena podataka u tabeli TabNaziv
Select * into PrivTabNaziv from TabNaziv where Ugovor='100669'
Select * from PrivTabNaziv

Update PrivTabNaziv
Set Ugovor ='100769'
Select * from PrivTabNaziv

Insert into TabNaziv
Select * from PrivTabNaziv
--uklanjanje privremene tabele
Drop table PrivTabNaziv

--2. Izmena podataka u tabeli SifTabCena

Select *into PrivSifTabCen from SifTabCen where Ugovor='100669'--Substring(ugovor,1,4)=1006
Select * from PrivSifTabCen

Update PrivSifTabCen
Set Ugovor ='100769',VaziOD='01/01/2007',VaziDo='12/31/2007'
Select * from PrivSifTabCen
	--!!! Treba izvrsiti samo ovaj kod
	Insert into SifTabCen
	Select * from PrivSifTabCen 
--uklanjanje privremene tabele
Drop table PrivSifTabCen

--3. Izmena podataka u tabeli TabDatumM

Select *into PrivTabDatumM from TabDatumM where Ugovor='100669'--Substring(ugovor,1,4)=1006
Select * from PrivTabDatumM

Update PrivTabDatumM
Set Ugovor ='100769',DatumOD='01/01/2007',DatumDo='12/31/2007'
Select * from PrivTabDatumM

--!!! Treba izvrsiti samo ovaj kod
	Insert into TabDatumM
	Select * from PrivTabDatumM
--uklanjanje privremene tabele
Drop table PrivTabDatumM

--4. Izmena podataka u tabeli TabMase

Select *into PrivTabMase from TabMase where Ugovor='100669'--Substring(ugovor,1,4)=1006
Select * from PrivTabMase

Update PrivTabMase
Set Ugovor ='100769'
Select * from PrivTabMase

--!!! Treba izvrsiti samo ovaj kod
	Insert into TabMase
	Select * from PrivTabMase

--uklanjanje privremene tabele
Drop table PrivTabMase


--5. Izmena podataka u tabeli TabRel
Select *into PrivTabRel from TabRel where Ugovor='100669'--Substring(ugovor,1,4)=1006
Select * from PrivTabRel

Update PrivTabRel
Set Ugovor ='100769',DatumOD='01/01/2007',DatumDo='12/31/2007'
Select * from PrivTabRel

--!!! Treba izvrsiti samo ovaj kod
	Insert into TabRel
	Select * from PrivTabRel
--uklanjanje privremene tabele
Drop table PrivTabRel


--6. Izmena podataka u tabeli TabStavR

Select *into PrivTabStavR from TabStavR where Ugovor='100669'--Substring(ugovor,1,4)=1006
Select * from PrivTabStavR

Update PrivTabStavR
Set Ugovor ='100769'
Select * from PrivTabStavR

--!!! Treba izvrsiti samo ovaj kod
	Insert into TabStavR
	Select * from PrivTabStavR

--uklanjanje privremene tabele
Drop table PrivTabStavR


--Provera Unetih izmena
Select * from TabNaziv where Substring(Ugovor,4,1)=7
--Delete TabNaziv where Ugovor='100700' and SifTab='192'

Select * from SifTabCen where Substring(Ugovor,4,1)=7
--Delete SifTabCen where Ugovor='100700' and SifTab='192'

Select * from TabDatumM where Substring(Ugovor,4,1)=7

Select * from TabMase where Substring(Ugovor,4,1)=7

Select * from TabRel where Substring(Ugovor,4,1)=7

Select * from TabStavR where Substring(Ugovor,4,1)=7


Select *into PrivTabRel from TabRel where Ugovor='100669'--Substring(ugovor,1,4)=1006
Select * from PrivTabRel

Update TabRel
Set DatumDo='01/31/2007'
where left(Ugovor,4)='0306' and DatumDo='12/31/2006'

Update TabRel
Set DatumDo='01/31/2007'
where left(Ugovor,4)<>'1006' and left(Ugovor,4)<>'1106' and left(Ugovor,4)<>'1206' and
      left(Ugovor,4)<>'1007' and left(Ugovor,4)<>'1107' and left(Ugovor,4)<>'1207' and
      left(Ugovor,2)<>'99' 