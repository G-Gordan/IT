SELECT     TOP 100 PERCENT dbo.SlogKalk.Najava AS NAJAVA, dbo.SlogKalk.Ugovor AS UGOVOR, SUM(dbo.SlogKalk.tlPrevFr) AS PREVOZNINA, 
                      SUM(dbo.SlogKalk.tlNakCo82) AS CO82, SUM(dbo.SlogKalk.tlNakCo) AS NAKCO, SUM(dbo.SlogKola.Tara) AS TARA, SUM(dbo.SlogRoba.SMasa) 
                      AS NETO, COUNT(dbo.SlogKola.KolaStavka) AS KOLA
FROM         dbo.SlogKalk INNER JOIN
                      dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN
                      dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND 
                      dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka
GROUP BY dbo.SlogKalk.ObrMesec, dbo.SlogKalk.Najava, dbo.SlogKalk.Ugovor
HAVING      (dbo.SlogKalk.Ugovor = '100701') AND (dbo.SlogKalk.ObrMesec = '1')
ORDER BY dbo.SlogKalk.Najava, dbo.SlogKalk.Ugovor