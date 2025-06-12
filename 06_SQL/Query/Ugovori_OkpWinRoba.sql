Drop table x_Ugovori
Select * into x_Ugovori from Ugovori where Substring(BrojUgovora,1,4)= '1008'
Select * from x_Ugovori


Update x_Ugovori
Set BrojUgovora = '12' + Right(BrojUgovora,4),
    SifraKorisnika = '73'

Insert into Ugovori Select * from x_Ugovori
Select * from Ugovori where Substring(BrojUgovora,1,4)= '1208'