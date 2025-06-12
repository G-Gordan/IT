Drop table x_SifTabCen
Select * into x_SifTabCen from SifTabCen where Ugovor='000011'
select * from x_siftabcen

Update x_SifTabCen
Set sifizmt = '2',
vaziod='2/1/2008',
vazido='1/31/2009'

Insert into SifTabCen Select * from x_SifTabCen


Drop table x_TabRel_11
Select * into x_TabRel_11 from TabRel where Ugovor = '100800'
select * from x_TabRel_11

Update x_TabRel_11
Set sifizmr = '2'

Update x_TabRel_11
Set Ugovor = '000011',
	siftab='310',
	datumdo='1/31/2009'

Insert into TabRel Select * from x_TabRel_11


Drop table x_TabStavR_11
Select * into x_TabStavR_11 from TabStavR where Ugovor = '000011'
select * from x_TabStavR_11

Update x_TabStavR_11
Set sifizmr = '2'

Insert into TabStavR Select * from x_TabStavR_11