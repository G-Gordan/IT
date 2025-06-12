SELECT dbo.SlogKalk.OtpUprava, dbo.SlogKalk.OtpStanica, dbo.SlogKalk.OtpBroj, dbo.SlogKalk.OtpDatum, dbo.SlogKalk.ObrGodina, dbo.SlogKalk.ObrMesec, 
                      dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.ZsIzPrelaz, dbo.SlogKalk.Najava, dbo.SlogKalk.NajavaKola, dbo.SlogKalk.Ugovor, dbo.SlogKalk.tlSumaFr, 
                      dbo.SlogKalk.tlPrevFr, dbo.SlogKalk.tlNakFr, dbo.SlogKalk.tlNakCo82, dbo.SlogKola.IBK, dbo.SlogRoba.SMasa, dbo.SlogRoba.RMasa, 
                      dbo.SlogKola.Tara, dbo.SlogRoba.NHM
into  _PrimeSped
FROM         dbo.SlogKalk INNER JOIN
                      dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN
                      dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND 
                      dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka
WHERE     (LEFT(dbo.SlogKalk.Ugovor, 4) = '3606')

