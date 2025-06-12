SELECT *
INTO dbo.table1
FROM OPENROWSET('MSDASQL',
    'Driver={Microsoft Excel Driver (*.xls)};DBQ=d:\prodos.xls',
    'SELECT * FROM [sheet1$]')
