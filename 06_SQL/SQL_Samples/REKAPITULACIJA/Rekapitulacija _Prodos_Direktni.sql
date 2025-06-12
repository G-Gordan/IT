SELECT     TOP 100 PERCENT dbo.SlogKalk.Ugovor, dbo.SlogKalk.Najava, COUNT(dbo.SlogKola.KolaStavka) AS KOLA, SUM(DISTINCT dbo.SlogKola.Tara) 
                      AS TARA, SUM(dbo.SlogRoba.SMasa) AS NETO, SUM(dbo.SlogKola.Tara + dbo.SlogRoba.SMasa) AS BRUTO
FROM         dbo.SlogKalk INNER JOIN
                      dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN
                      dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND 
                      dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka
WHERE     (dbo.SlogKalk.ObrMesec = '3')AND (SubString(dbo.SlogKalk.Najava,2,1) <> 'X')
GROUP BY dbo.SlogKalk.ObrMesec, dbo.SlogKalk.Najava, dbo.SlogKalk.Ugovor
HAVING      (dbo.SlogKalk.Ugovor = '100601') OR
                      (dbo.SlogKalk.Ugovor = '100701') OR
                      (dbo.SlogKalk.Ugovor = '100622') OR
                      (dbo.SlogKalk.Ugovor = '100722') OR
                      (dbo.SlogKalk.Ugovor = '110601') OR
                      (dbo.SlogKalk.Ugovor = '110701') OR
                      (dbo.SlogKalk.Ugovor = '110622') OR
                      (dbo.SlogKalk.Ugovor = '110722') OR
                      (dbo.SlogKalk.Ugovor = '120601') OR
                      (dbo.SlogKalk.Ugovor = '120701') OR
                      (dbo.SlogKalk.Ugovor = '120722')
ORDER BY dbo.SlogKalk.Ugovor, dbo.SlogKalk.Najava