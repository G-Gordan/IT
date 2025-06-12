SELECT     dbo.SlogKalk.RecID
FROM         dbo.SlogKalk INNER JOIN
                      dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica
WHERE     (dbo.SlogKola.IBK = '314327536327') AND (SUBSTRING(dbo.SlogKalk.Najava, 2, 1) = 'X') AND (dbo.SlogKalk.Najava2 = '0')