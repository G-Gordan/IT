SELECT     TabRel.Ugovor AS ugovor, TabRel.RelStavka AS Realcija, TabRel.StOd AS OD, TabRel.StDo AS DO, TabStavR.MasaStavka AS [Masa stavka], 
                      TabStavR.Stav AS CENA
FROM         TabRel INNER JOIN
                      TabStavR ON TabRel.Ugovor = TabStavR.Ugovor AND TabRel.SifTab = TabStavR.SifTab AND TabRel.SifIzmR = TabStavR.SifIzmR AND 
                      TabRel.RelStavka = TabStavR.RelStavka
WHERE     (TabRel.Ugovor = '050701')