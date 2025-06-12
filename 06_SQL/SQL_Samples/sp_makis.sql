SELECT     SlogKalk.Ugovor AS Ugovor, SlogKalk.Najava2 AS Najava, SlogKalk.NajavaKola2 AS [Ukupno kola], SlogKalk.ZsIzPrelaz AS Izlaz, 
                      SlogKalk.IzEtiketa AS Nalepnica, SlogKola.IBK, SlogKola.Tara, SlogRoba.SMasa, SlogKalk.rSumaFr AS Ukupno, SlogKalk.rPrevFr AS Prevoznina, 
                      SlogKalk.rNakFr AS Naknade
FROM         SlogKalk INNER JOIN
                      SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN
                      SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka
WHERE     (SlogKalk.Najava2 = 'xt043')
ORDER BY SlogKalk.IzEtiketa