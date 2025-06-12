SELECT * 
INTO [dbo].[Prodos_Temp]
FROM OPENROWSET('Microsoft.Jet.OLEDB.4.0',
                'Excel 8.0;Database=D:\.NET\prodos.xls;IMEX=1',
                'SELECT * FROM [Sheet1$]')

SELECT * 
INTO [dbo].[Schenker_Temp]
FROM OPENROWSET('Microsoft.Jet.OLEDB.4.0',
                'Excel 8.0;Database=D:\.NET\Schenker.xls;IMEX=1',
                'SELECT * FROM [Tabelle1$]')