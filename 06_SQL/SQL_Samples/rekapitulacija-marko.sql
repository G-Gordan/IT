SELECT     Komitent.Naziv AS Korisnik, SlogKalk.Ugovor AS Ugovor, SUM(SlogKalk.UkupnoKola) AS Kola, COUNT(SlogKalk.Najava) AS Vozova, 
                      SUM(SlogKola.Tara) AS Tara, SUM(SlogRoba.SMasa) AS Neto, SUM(SlogKalk.tlPrevFr) AS Prevoznina, SUM(SlogKalk.tlNakCo82) AS NakCO, 
                      SUM(SlogKalk.tlNakCo) AS NakOst, SUM(SlogKalk.tlPrevFr + SlogKalk.tlNakCo82 + SlogKalk.tlNakCo) AS Ukupno
FROM         Ugovori INNER JOIN
                      Komitent ON Ugovori.SifraKorisnika = Komitent.Sifra INNER JOIN
                      SlogKalk ON Ugovori.BrojUgovora = SlogKalk.Ugovor INNER JOIN
                      SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN
                      SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka
GROUP BY SlogKalk.Ugovor, Komitent.Naziv, SlogKalk.ObrMesec, SlogKalk.Najava
HAVING      (SlogKalk.ObrMesec = '2') AND (SlogKalk.Najava > '0')
ORDER BY SlogKalk.Ugovor