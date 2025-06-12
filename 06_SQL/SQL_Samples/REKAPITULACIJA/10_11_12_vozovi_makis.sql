SELECT     TOP 100 PERCENT SlogKalk.Najava2, COUNT(SlogKola.KolaStavka) AS KOLA, SUM(SlogKola.Tara) AS TARA, SUM(SlogRoba.SMasa) AS NETO, 
                      SUM(SlogKola.Tara + SlogRoba.SMasa) AS BRUTO, SlogKalk.Najava2 AS Expr1
FROM         SlogKalk INNER JOIN
                      SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN
                      SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka
WHERE     (SlogKalk.ObrMesec = '3') AND (SlogKalk.Najava2 > '0')
GROUP BY SlogKalk.ObrMesec, SlogKalk.Najava2
ORDER BY SlogKalk.Najava2