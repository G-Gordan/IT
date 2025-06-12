-- 1. Komitenti
-- 2. Ugovori
-- 3. TabNaziv
-- 4. SifTabCen(Datum)
-- 5. TabDatumM(Datum)
-- 6. TabMase
-- 7. TabRel(Datum)
-- 8. TabStavR


-- 1. Komitenti



-- 2. Ugovori

Drop table x_Ugovori
Select * into x_Ugovori from Ugovori where Substring(BrojUgovora,1,4)= '1008'
--Select * from x_Ugovori

Update x_Ugovori
Set BrojUgovora = '11' + Right(BrojUgovora,4),
    SifraKorisnika = '3'
--Select * from x_Ugovori

Insert into Ugovori Select * from x_Ugovori


-- 3. TabNaziv

Drop table x_TabNaziv
Select * into x_TabNaziv from TabNaziv where Substring(Ugovor,1,4)= '1008'
Select * from x_TabNaziv

Update x_TabNaziv
Set Ugovor = '11' + Right(Ugovor,4)

Insert into TabNaziv Select * from x_TabNaziv


-- 4. SifTabCen

Drop table x_SifTabCen
Select * into x_SifTabCen from SifTabCen where Substring(Ugovor,1,4)='1008'
Select * from x_SifTabCen

Update x_SifTabCen
Set Ugovor = '11' + Right(Ugovor,4)
Select * from x_SifTabCen

Insert into SifTabCen Select * from x_SifTabCen


-- 5. TabDatumM

Drop table x_TabDatumM
Select * into x_TabDatumM from TabDatumM where Substring(Ugovor,1,4)='1008'
Select * from x_TabDatumM

Update x_TabDatumM
Set Ugovor = '11' + Right(Ugovor,4)
Select * from x_TabDatumM

Insert into TabDatumM Select * from x_TabDatumM



-- 5. TabMase

Drop table x_TabMase
Select * into x_TabMase from TabMase where Substring(Ugovor,1,4)= '1008'
Select * from x_TabMase

Update x_TabMase
Set Ugovor = '11' + Right(Ugovor,4)
Select * from x_TabMase

Insert into TabMase Select * from x_TabMase



-- 6. TabRel
-- 00; 01 (210,213); 02; 69


-- 6.00
Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor = '100800'
Select * from x_TabRel
Update x_TabRel
Set Ugovor = '11' + Right(Ugovor,4)
Insert into TabRel Select * from x_TabRel

-- 6.01
/*
Drop table x_TabRel
--Select * into x_TabRel_sacuvanoProodos from TabRel where Ugovor = '100801' --and (SifTab = '210' or SifTab = '213')
--Select * from x_TabRel_sacuvanoProodos
Update x_TabRel
Set Ugovor = '12' + Right(Ugovor,4)
Insert into TabRel Select * from x_TabRel
--Insert into TabRel Select * from x_TabRel_NoviUgovori
*/

Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor = '100801' and (SifTab = '210' or SifTab = '213')
Select * from x_TabRel
Update x_TabRel
Set Ugovor = '11' + Right(Ugovor,4)
Insert into TabRel Select * from x_TabRel

-- 6.02
Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor = '100802'
Select * from x_TabRel
Update x_TabRel
Set Ugovor = '11' + Right(Ugovor,4)
Insert into TabRel Select * from x_TabRel

-- 6.69
Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor = '100869'
Select * from x_TabRel
Update x_TabRel
Set Ugovor = '11' + Right(Ugovor,4)
Insert into TabRel Select * from x_TabRel


-- 6.22

Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor = '100822'
Select * from x_TabRel
Update x_TabRel
Set Ugovor = '11' + Right(Ugovor,4)
Insert into TabRel Select * from x_TabRel




-- 7. TabStavR
-- 00; 01 (210,213); 02; 69


-- 7.00
Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100800'
Select * from x_TabStavR

Update x_TabStavR
Set Ugovor = '11' + Right(Ugovor,4)

Insert into TabStavR Select * from x_TabStavR


-- 7.01
Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100801' and (SifTab = '210' or SifTab = '213')
Select * from x_TabStavR

Update x_TabStavR
Set Ugovor = '11' + Right(Ugovor,4)

Insert into TabStavR Select * from x_TabStavR


-- 7.22
Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100822'
Select * from x_TabStavR
Update x_TabStavR
Set Ugovor = '110822'
Insert into TabStavR Select * from x_TabStavR


-- 7.02
Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100802'
Select * from x_TabStavR
Update x_TabStavR
Set Ugovor = '110802'
Insert into TabStavR Select * from x_TabStavR


--ostali ugovori

Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100702'
Select * from x_TabStavR

--Update x_TabStavR
--Set Ugovor = '12' + Right(Ugovor,4)

Insert into TabRel Select * from _TabRel

-- 7.69
Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100869'
Select * from x_TabStavR
Update x_TabStavR
Set Ugovor = '11' + Right(Ugovor,4)
Insert into TabStavR Select * from x_TabStavR





Drop table _TabStavR
Select * into _TabStavR from TabStavR where Ugovor = '100800'
Select * from _TabStavR


Update _TabStavR
Set Ugovor = '190700'
--Set Ugovor = '3707' + Right(Ugovor,2)

delete x_TabStavR_00
where relstavka='20' and (stav = 21.9 or stav = 19.3 or stav = 17.5 )


Insert into TabStavR Select * from _TabStavR

Insert into TabStav Select * from radnik.PrivTabStav_ekspres


Insert into TabStavR Select * from x_TabStavR_22
Insert into TabStavR Select * from radnik.x_TabStavR_69


--DELETE FROM TabRel WHERE Ugovor = '100801'
Select * into x_TabRel_sacuvanoProodos from TabRel where Ugovor = '100801'
Select * into x_TabRel_NoviUgovori from TabRel where Ugovor = '100800'

DELETE FROM x_TabStavR_00 WHERE relstavka = '9' and (masastavka = '6' or masastavka = '7' or masastavka = '8') 


Drop table xx_TabRel_Za_02
Select * into xx_TabRel_Za_02 from TabRel where Ugovor = '100800'
Select * from xx_TabRel_Za_02
Update xx_TabRel_Za_02
Set Ugovor = '100802',
    SifTab='192'

DELETE FROM TabRel WHERE ugovor = '100802'

Insert into TabRel Select * from xx_TabRel_Za_02