DECLARE @Ugovor char(6) 
DECLARE @Najava char(10) 
DECLARE @IBK char(12) 
DECLARE @Realizovano char(1) 
DECLARE @MyCursor CURSOR

SET @MyCursor = CURSOR 
FOR
SELECT dbo.SlogKalk.Ugovor, dbo.SlogKalk.Najava, dbo.SlogKola.IBK, dbo.NajavaKola.Realizovano
FROM   dbo.NajavaKola INNER JOIN
       dbo.SlogKola ON dbo.NajavaKola.IBK = dbo.SlogKola.IBK INNER JOIN
       dbo.SlogKalk ON dbo.SlogKola.RecID = dbo.SlogKalk.RecID AND dbo.SlogKola.Stanica = dbo.SlogKalk.Stanica

--SELECT KolaStavka FROM NajavaKola

OPEN @MyCursor
FETCH NEXT FROM @MyCursor INTO @Ugovor, @Najava, @IBK, @Realizovano

WHILE @@FETCH_STATUS = 0
 BEGIN
  if @Realizovano = 0
     PRINT @Realizovano
	 
  FETCH NEXT FROM @MyCursor INTO @Realizovano
 END
CLOSE @MyCursor
DEALLOCATE @MyCursor