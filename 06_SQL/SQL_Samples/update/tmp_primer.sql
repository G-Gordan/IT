USE okpwinroba
GO
DECLARE abc CURSOR FOR
SELECT IBK
FROM   NajavaKola
WHERE  (KomBrojVoza = 'xt007') AND (BrUgovora = '100701')

OPEN abc

FETCH NEXT FROM abc
WHILE (@@FETCH_STATUS = 0)
   FETCH NEXT FROM abc

CLOSE abc
DEALLOCATE abc
GO

--primer2
declare @tt int
declare @ibk char(12)

USE OkpWinRoba
GO
WHILE (NajavaKola.KomBrojVoza = 'xt007') AND (NajavaKola.BrUgovora = '100701')
 BEGIN
	set @ibk = najavakola.ibk
	SELECT  @tt = dbo.SlogKalk.RecID
	FROM    dbo.SlogKalk INNER JOIN
	        dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica
	WHERE   (dbo.SlogKola.IBK = @ibk) AND (SUBSTRING(dbo.SlogKalk.Najava, 2, 1) = 'X') AND (dbo.SlogKalk.Najava2 = '0')

	UPDATE SlogKalk
	SET    Najava2 = 'XD001', NajavaKola2 = 20
	WHERE  RecID = @tt
 END



