-- Ugovori.BrojUgovora + Ugovori.SifraKorisnika



----------------------- Ugovori

Drop table x_Ugovori
Select * into x_Ugovori from Ugovori where BrojUgovora= '993353'

Update x_Ugovori
Set BrojUgovora = '05' + Right(BrojUgovora,4),
    SifraKorisnika = '23'

Insert into Ugovori Select * from x_Ugovori


----------------------- TabNaziv

Drop table x_TabNaziv
Select * into x_TabNaziv from TabNaziv where Ugovor= '993353'
Select * from x_TabNaziv

Update x_TabNaziv
Set Ugovor = '05' + Right(Ugovor,4)

Insert into TabNaziv Select * from x_TabNaziv


----------------------- SifTabCen

Drop table x_SifTabCen
Select * into x_SifTabCen from SifTabCen where Ugovor='993353'
select * from x_siftabcen

Update x_SifTabCen
Set Ugovor = '05' + Right(Ugovor,4)

Insert into SifTabCen Select * from x_SifTabCen


-----------------------  TabDatumM

Drop table x_TabDatumM
Select * into x_TabDatumM from TabDatumM where Ugovor='993353'
select * from x_tabdatumm

Delete x_tabdatumm
where sifizmm='1'

Update x_TabDatumM
Set sifizmm = '3',
     datumod='1/1/2008',
     datumdo='12/31/2008'

Insert into TabDatumM Select * from x_TabDatumM



----------------------- TabMase

Drop table x_TabMase
Select * into x_TabMase from TabMase where Ugovor='993353'
select * from x_TabMase
Delete x_tabmase
where sifizmm='1'

Update x_TabMase
Set sifizmm = '3'

	siftab='171'

Insert into TabMase Select * from x_TabMase


--===================== TabRel

-- 00

Drop table x_TabRel
Select * into x_TabRel from TabRel where Ugovor='993353'
select * from x_TabRel

Select * from TabRel where Ugovor='993354'

Update TabRel
Set  datumdo='12/31/2008'
where Ugovor='993353'

Insert into TabRel Select * from x_TabRel




--===================== TabStav



-- 00

Drop table x_TabStavR
Select * into x_TabStavR from TabStavR where Ugovor = '993353'
select * from x_TabStavR

Update x_TabStavR
Set Ugovor = '050800'

Insert into TabStavR Select * from x_TabStavR
























