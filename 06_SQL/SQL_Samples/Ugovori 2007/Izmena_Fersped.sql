/*
--samo jednom
Drop table _TabRel
Select * into _TabRel from TabRel where Substring(Ugovor,1,4)= '0507'
Select * from _TabRel

Drop table _TabStavR
Select * into _TabStavR from TabStavR where Substring(Ugovor,1,4)= '0507'
Select * from _TabStavR
*/


-- 1
Update _TabRel
Set Ugovor = '26' + Right(Ugovor,4)
--Select * from _TabRel

Update _TabStavR
Set Ugovor = '26' + Right(Ugovor,4)
--Select * from _TabStavR

-- 2
DELETE FROM TabStavR
WHERE     (Left(Ugovor,4) = '2607')

DELETE FROM TabRel
WHERE     (Left(Ugovor,4) = '2607')


-- 3
Insert into TabRel Select * from _TabRel
Insert into TabStavR Select * from _TabStavR
