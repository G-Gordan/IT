-- Ugovori.BrojUgovora + Ugovori.SifraKorisnika



----------------------- Ugovori

Drop table x_Ugovori
Select * into x_Ugovori from Ugovori where Substring(BrojUgovora,1,4)= '0508'
Select * from x_Ugovori 

Update x_Ugovori
Set BrojUgovora = '08' + Right(BrojUgovora,4),
    SifraKorisnika = '11'

Insert into Ugovori Select * from x_Ugovori


----------------------- TabNaziv

Drop table x_TabNaziv
Select * into x_TabNaziv from TabNaziv where Substring(Ugovor,1,4)= '0508'
Select * from x_TabNaziv

Update x_TabNaziv
Set Ugovor = '05' + Right(Ugovor,4)

Insert into TabNaziv Select * from x_TabNaziv


----------------------- SifTabCen

Drop table x_SifTabCen
Select * into x_SifTabCen from SifTabCen where Substring(Ugovor,1,4)='0508'
select * from x_siftabcen
Update x_SifTabCen
Set Ugovor = '05' + Right(Ugovor,4)

Insert into SifTabCen Select * from x_SifTabCen


-----------------------  TabDatumM

Drop table x_TabDatumM
Select * into x_TabDatumM from TabDatumM where Substring(Ugovor,1,4)='0508'
select * from x_tabdatumm

Update x_TabDatumM
Set Ugovor = '05' + Right(Ugovor,4)

Insert into TabDatumM Select * from x_TabDatumM



----------------------- TabMase

Drop table x_TabMase
Select * into x_TabMase from TabMase where Substring(Ugovor,1,4)= '1008'
select * from x_TabMase

Update x_TabMase
Set Ugovor = '05' + Right(Ugovor,4)

	siftab='171'

Insert into TabMase Select * from x_TabMase


--===================== TabRel

-- 00

Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor = '100800'
select * from x_TabRel

Update x_TabRel
Set Ugovor = '05' + Right(Ugovor,4)

Insert into TabRel Select * from x_TabRel


-- 01

Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor = '100801' and (SifTab = '210') -- or SifTab = '213')
select * from x_TabRel

Update x_TabRel
Set Ugovor = '05' + Right(Ugovor,4)

Insert into TabRel Select * from x_TabRel


-- 02

Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor = '100802'
select * from x_TabRel

Update x_TabRel
Set Ugovor = '050802'

Insert into TabRel Select * from x_TabRel


-- 69

Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor = '100869'
select * from x_TabRel

Update x_TabRel
Set Ugovor = '050869'

Insert into TabRel Select * from x_TabRel



--===================== TabStav



-- 00

Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100800'
select * from x_TabStavR

Update x_TabStavR
Set Ugovor = '050800'

Insert into TabStavR Select * from x_TabStavR


-- 01

Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100801' and SifTab = '210' --or SifTab = '213')
select * from x_TabStavR

Update x_TabStavR
Set Ugovor = '050801'

Insert into TabStavR Select * from x_TabStavR


-- 02

Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100802'
select * from x_TabStavR

Update x_TabStavR
Set Ugovor = '050802'

Insert into TabStavR Select * from x_TabStavR


-- 69

Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '100869'
select * from x_tabstavr

Update x_TabStavR
Set Ugovor = '050869'

Insert into TabStavR Select * from x_TabStavR






























