UPDATE 	dbo.UgKp_Tip5
SET 	dbo.UgKp_Tip5.NacinObrade=dbo.Cena_UgovorKP.NacinObrade
FROM 	dbo.Cena_UgovorKP
WHERE  	dbo.Cena_UgovorKP.BrojUgovora=dbo.UgKp_Tip5.BrojUgovora and
	dbo.Cena_UgovorKP.Aneks=dbo.UgKp_Tip5.Aneks
