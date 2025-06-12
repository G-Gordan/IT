SELECT     TOP 100 PERCENT dbo.SlogKalk.Ugovor, dbo.SlogKalk.Najava, dbo.SlogKalk.NajavaKola, dbo.SlogKalk.OtpStanica AS STANICA, 
                      dbo.SlogKalk.OtpBroj AS BROJOTP, dbo.SlogKola.IBK, dbo.SlogKola.Tara AS TARA, dbo.SlogRoba.SMasa AS NETO, 
                      dbo.SlogRoba.RMasa AS RACMASA, dbo.SlogKalk.tlPrevFr AS PREVOZNINA, dbo.SlogKalk.tlNakCo AS NAK, dbo.SlogKalk.tlNakCo82 AS NAKCO, 
                      dbo.SlogKola.Naknada AS NAK_ZKOLA
FROM         dbo.SlogKalk INNER JOIN
                      dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN
                      dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND 
                      dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka
WHERE     (dbo.SlogKalk.Najava = 'sg025')
ORDER BY dbo.SlogKalk.OtpBroj