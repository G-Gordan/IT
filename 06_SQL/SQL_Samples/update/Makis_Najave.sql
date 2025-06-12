-- 1. Formira dataset za izabrani broj najave
SELECT IBK
FROM   NajavaKola
WHERE  (KomBrojVoza = 'xt007') AND (BrUgovora = '100701')

-- 2. Radi u petlji od prvih do poslednjih kola

-- 3. Trazi kola u SlogKalk
SELECT  dbo.SlogKalk.RecID
FROM    dbo.SlogKalk INNER JOIN
        dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica
WHERE   (dbo.SlogKola.IBK = '314327536327') AND (SUBSTRING(dbo.SlogKalk.Najava, 2, 1) = 'X') AND (dbo.SlogKalk.Najava2 = '0')

-- 4. Update za dobijeni RecID
UPDATE SlogKalk
SET    Najava2 = 'XD001', NajavaKola2 = 20
WHERE  RecID = 15607

--prikaz sta je uradio
Select Najava, NajavaKola, Najava2, NajavaKola2
From SlogKalk
WHERE  RecID = 15607


