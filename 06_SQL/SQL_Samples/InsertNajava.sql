--import iz excela
Drop table Prodos

SELECT * 
INTO [dbo].[Prodos]
FROM OPENROWSET('Microsoft.Jet.OLEDB.4.0',
                'Excel 8.0;Database=D:\.NET\prodos.xls;IMEX=1;HDR=NO',
                'SELECT * FROM [Sheet1$]')


--kopira u drugu privremenu tabelu i brise nepotrebne podatke
Drop table My_Prodos
Select * into My_Prodos from Prodos
DELETE FROM My_Prodos WHERE isnumeric(F1)=0 or isnumeric(F2)=0
Select * from My_Prodos

--konacan rezultat
Select F1,F2 from My_Prodos






