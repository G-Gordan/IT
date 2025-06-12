SELECT     TOP 100 PERCENT SlogKalk.Ugovor AS UGOVOR, COUNT(DISTINCT SlogKalk.Najava) AS [Vozovi/Grupe], COUNT(SlogKola.KolaStavka) 
                      AS [Ukupno kola], SUM(DISTINCT SlogKalk.tlPrevFr) AS PREVOZNINA1, SlogKalk.rPrevFr AS PREVOZNINA2, SUM(SlogKalk.tlNakCo82) AS [NAK ZA PCO],
                       SUM(SlogKalk.tlNakCo) AS [NAK CO], SUM(SlogKalk.rNakFr) AS [NAK RANZIRANJE], SUM(SlogKola.Naknada) AS [NAK Z KOLA]
FROM         SlogKalk INNER JOIN
                      SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN
                      SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka
WHERE     (SlogKalk.ObrMesec = '1')
GROUP BY SlogKalk.ObrMesec, SlogKalk.Ugovor, SlogKalk.rPrevFr
ORDER BY SlogKalk.Ugovor, COUNT(DISTINCT SlogKalk.Najava)


SELECT     TOP 100 PERCENT SlogKalk.Ugovor AS UGOVOR, COUNT(DISTINCT SlogKalk.Najava) AS [Vozovi/Grupe], COUNT(SlogKola.KolaStavka) 
                      AS [Ukupno kola], SUM(DISTINCT SlogKalk.tlPrevFr) AS PREVOZNINA1, SlogKalk.rPrevFr AS PREVOZNINA2, SUM(SlogKalk.tlNakCo82) AS [NAK ZA PCO],
                       SUM(SlogKalk.tlNakCo) AS [NAK CO], SUM(SlogKalk.rNakFr) AS [NAK RANZIRANJE], SUM(SlogKola.Naknada) AS [NAK Z KOLA]
FROM         SlogKalk INNER JOIN
                      SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN
                      SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka
WHERE     (SlogKalk.ObrMesec = '1')
GROUP BY SlogKalk.ObrMesec, SlogKalk.Ugovor, SlogKalk.rPrevFr
ORDER BY SlogKalk.Ugovor, COUNT(DISTINCT SlogKalk.Najava)