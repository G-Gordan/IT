SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE spBrisanjeSlogRobaUI2  

(

	@inAkcija		AS CHAR(3),
	@inRecID 		AS integer ,
	@inStanicaUnosa	AS CHAR(5),
	@inKolaStavka		AS integer,
	@inRobaStavka		AS integer

)
AS


DELETE FROM SlogRoba WHERE RecID = @inRecID AND Stanica = @inStanicaUnosa AND KolaStavka = @inKolaStavka AND RobaStavka = @inRobaStavka 
DELETE FROM SlogKola WHERE RecID = @inRecID AND Stanica = @inStanicaUnosa AND KolaStavka = @inKolaStavka

RETURN @@RowCount
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-------------------------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE spUpisSlogK211UI
(

	@inAkcija		AS CHAR(3),
	@inRecID		AS INTEGER,
	@inStanicaUnosa	AS CHAR(5),
	@inStavka		AS INTEGER,
	@inSifraK211	 	AS CHAR(2)

)
AS

IF @inAkcija = 'New' 
   BEGIN
	INSERT INTO  SlogK211 (RecID, Stanica, Stavka, SifraK211) 
		VALUES ( @inRecID, @inStanicaUnosa, @inStavka, @inSifraK211)
   END
ELSE IF @inAkcija = 'Del' 
   BEGIN
	DELETE FROM SlogK211 WHERE RecID=@inRecID And Stanica=@inStanicaUnosa And Stavka=@inStavka
   END
ELSE IF @inAkcija = 'Upd' 
   BEGIN
	UPDATE SlogK211
	SET	SifraK211		= @inSifraK211
	WHERE RecID=@inRecID and Stanica=@inStanicaUnosa and Stavka=@inStavka
   END

RETURN @@RowCount

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

---------------------------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE spUpisSlogUicUI
(

	@inAkcija		AS CHAR(3),
	@inRecID		AS INTEGER,
	@inStanicaUnosa	AS CHAR(5),
	@inOtpUprava	 	AS CHAR(4),
	@inOtpStanica	 	AS CHAR(7),
	@inOtpBroj		AS INTEGER,
	@inOtpDatum		AS DATETIME,
	@inUicStavka		AS INTEGER,
	@inUprava 		AS CHAR(2), 
	@inSifraGS 		AS CHAR(3), 
	@inSifraPP 		AS CHAR(2), 
	@inUlaz		AS CHAR(4), 
	@inIzlaz		AS CHAR(4), 
	--@inTarifa		AS CHAR(2), 
	@inValuta		AS CHAR(2), 
	@inPrevozninaFR	AS DECIMAL(12,2),
	@inPrevozninaUP	AS DECIMAL(12,2),
	@inNak1 		AS CHAR(2), 
	@inIznos1                       AS DECIMAL(12,2),
	@inNak2 		AS CHAR(2), 
	@inIznos2                       AS DECIMAL(12,2),
	@inNak3 		AS CHAR(2), 
	@inIznos3                       AS DECIMAL(12,2),
	@inNaknadeFR		AS DECIMAL(12,2),
	@inNaknadeUP		AS DECIMAL(12,2),
	@inSumaDinFR		AS DECIMAL(12,2),
	@inSumaDinUP		AS DECIMAL(12,2),
	@inValutaPred		AS CHAR(2), 
	@inPredujam 		AS DECIMAL(12,2),
	@inValutaTL		AS CHAR(2), 
	@inTLFranko		AS DECIMAL(12,2),
	@inTLUpuceno		AS DECIMAL(12,2)

)
AS


IF @inAkcija = 'New' 
   BEGIN
	INSERT INTO  SlogUic (RecID, Stanica, StavkaUIC, OtpUprava, OtpStanica, OtpBroj, OtpDatum, Uprava, SifraGS, SifraPP, UlPrelaz, IzPrelaz, Valuta, PrevFR, PrevUP, Nak1, Iznos1, Nak2, Iznos2, Nak3, Iznos3, NaknadeFR, NaknadeUP, SumaDinFR, SumaDinUP, PredujamVal, Predujam, tlValuta, tlFranko, tlUpuceno ) 
	VALUES ( @inRecID, @inStanicaUnosa, @inUicStavka, @inOtpUprava , @inOtpStanica , @inOtpBroj, @inOtpDatum , @inUprava, @inSifraGS, @inSifraPP, @inUlaz, @inIzlaz, @inValuta, @inPrevozninaFR, @inPrevozninaUP, @inNak1, @inIznos1, @inNak2, @inIznos2, @inNak3, @inIznos3, @inNaknadeFR, @inNaknadeUP, @inSumaDinFR, @inSumaDinUP, @inValutaPred, @inPredujam, @inValutaTL, @inTLFranko, @inTLUpuceno)

   END
ELSE IF @inAkcija = 'Del' 
   BEGIN
	DELETE FROM SlogUic  WHERE RecID = @inRecID And Stanica = @inStanicaUnosa And StavkaUic=@inUicStavka
   END
ELSE IF @inAkcija = 'Upd' 
   BEGIN
	UPDATE SlogUic
	SET	
		OtpUprava	 = @inOtpUprava,
		OtpStanica	 = @inOtpStanica,
		OtpBroj		 = @inOtpBroj,
		OtpDatum	 = @inOtpDatum,
		Uprava		 = @inUprava,
		SifraGS		 = @inSifraGS,
		SifraPP		 = @inSifraPP,
		UlPrelaz	 	 = @inUlaz,
		IzPrelaz	 	 = @inIzlaz,
		Valuta		 = @inValuta,
		PrevFR		 = @inPrevozninaFR,
		PrevUP		 = @inPrevozninaUP,
		Nak1		 = @inNak1,
		Iznos1		 = @inIznos1,
		Nak2		 = @inNak2,
		Iznos2		 = @inIznos2,
		Nak3		 = @inNak3,
		Iznos3		 = @inIznos3,
		NaknadeFR	 = @inNaknadeFR,
		NaknadeUP	 = @inNaknadeUP,
		SumaDinFR	 = @inSumaDinFR,
		SumaDinUP	 = @inSumaDinUP,
		PredujamVal	 = @inValutaPred,
		Predujam	 = @inPredujam,
		tlValuta	 	 = @inValutaTL,
		tlFranko	 	 = @intlFranko,
		tlUpuceno	 = @intlUpuceno
		
	WHERE RecID = @inRecID And Stanica = @inStanicaUnosa And StavkaUic=@inUicStavka

   END

RETURN @@RowCount

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

---------------------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE spUpisSlogUicUI
(

	@inAkcija		AS CHAR(3),
	@inRecID		AS INTEGER,
	@inStanicaUnosa	AS CHAR(5),
	@inOtpUprava	 	AS CHAR(4),
	@inOtpStanica	 	AS CHAR(7),
	@inOtpBroj		AS INTEGER,
	@inOtpDatum		AS DATETIME,
	@inUicStavka		AS INTEGER,
	@inUprava 		AS CHAR(2), 
	@inSifraGS 		AS CHAR(3), 
	@inSifraPP 		AS CHAR(2), 
	@inUlaz		AS CHAR(4), 
	@inIzlaz		AS CHAR(4), 
	--@inTarifa		AS CHAR(2), 
	@inValuta		AS CHAR(2), 
	@inPrevozninaFR	AS DECIMAL(12,2),
	@inPrevozninaUP	AS DECIMAL(12,2),
	@inNak1 		AS CHAR(2), 
	@inIznos1                       AS DECIMAL(12,2),
	@inNak2 		AS CHAR(2), 
	@inIznos2                       AS DECIMAL(12,2),
	@inNak3 		AS CHAR(2), 
	@inIznos3                       AS DECIMAL(12,2),
	@inNaknadeFR		AS DECIMAL(12,2),
	@inNaknadeUP		AS DECIMAL(12,2),
	@inSumaDinFR		AS DECIMAL(12,2),
	@inSumaDinUP		AS DECIMAL(12,2),
	@inValutaPred		AS CHAR(2), 
	@inPredujam 		AS DECIMAL(12,2),
	@inValutaTL		AS CHAR(2), 
	@inTLFranko		AS DECIMAL(12,2),
	@inTLUpuceno		AS DECIMAL(12,2)

)
AS


IF @inAkcija = 'New' 
   BEGIN
	INSERT INTO  SlogUic (RecID, Stanica, StavkaUIC, OtpUprava, OtpStanica, OtpBroj, OtpDatum, Uprava, SifraGS, SifraPP, UlPrelaz, IzPrelaz, Valuta, PrevFR, PrevUP, Nak1, Iznos1, Nak2, Iznos2, Nak3, Iznos3, NaknadeFR, NaknadeUP, SumaDinFR, SumaDinUP, PredujamVal, Predujam, tlValuta, tlFranko, tlUpuceno ) 
	VALUES ( @inRecID, @inStanicaUnosa, @inUicStavka, @inOtpUprava , @inOtpStanica , @inOtpBroj, @inOtpDatum , @inUprava, @inSifraGS, @inSifraPP, @inUlaz, @inIzlaz, @inValuta, @inPrevozninaFR, @inPrevozninaUP, @inNak1, @inIznos1, @inNak2, @inIznos2, @inNak3, @inIznos3, @inNaknadeFR, @inNaknadeUP, @inSumaDinFR, @inSumaDinUP, @inValutaPred, @inPredujam, @inValutaTL, @inTLFranko, @inTLUpuceno)

   END
ELSE IF @inAkcija = 'Del' 
   BEGIN
	DELETE FROM SlogUic  WHERE RecID = @inRecID And Stanica = @inStanicaUnosa And StavkaUic=@inUicStavka
   END
ELSE IF @inAkcija = 'Upd' 
   BEGIN
	UPDATE SlogUic
	SET	
		OtpUprava	 = @inOtpUprava,
		OtpStanica	 = @inOtpStanica,
		OtpBroj		 = @inOtpBroj,
		OtpDatum	 = @inOtpDatum,
		Uprava		 = @inUprava,
		SifraGS		 = @inSifraGS,
		SifraPP		 = @inSifraPP,
		UlPrelaz	 	 = @inUlaz,
		IzPrelaz	 	 = @inIzlaz,
		Valuta		 = @inValuta,
		PrevFR		 = @inPrevozninaFR,
		PrevUP		 = @inPrevozninaUP,
		Nak1		 = @inNak1,
		Iznos1		 = @inIznos1,
		Nak2		 = @inNak2,
		Iznos2		 = @inIznos2,
		Nak3		 = @inNak3,
		Iznos3		 = @inIznos3,
		NaknadeFR	 = @inNaknadeFR,
		NaknadeUP	 = @inNaknadeUP,
		SumaDinFR	 = @inSumaDinFR,
		SumaDinUP	 = @inSumaDinUP,
		PredujamVal	 = @inValutaPred,
		Predujam	 = @inPredujam,
		tlValuta	 	 = @inValutaTL,
		tlFranko	 	 = @intlFranko,
		tlUpuceno	 = @intlUpuceno
		
	WHERE RecID = @inRecID And Stanica = @inStanicaUnosa And StavkaUic=@inUicStavka

   END

RETURN @@RowCount

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--------------------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE spUpisSlogDencaneUI
(

	@inAkcija		AS CHAR(3),
	@inRecID		AS INTEGER,
	@inStanicaUnosa	AS CHAR(5),
	@inOtpUprava	 	AS CHAR(4),
	@inOtpStanica	 	AS CHAR(7),
	@inOtpBroj		AS INTEGER,
	@inOtpDatum		AS DATETIME,
	@inDencanoStavka	AS INTEGER,
	@inTarife	 	AS INTEGER,
	@inStvMasa		AS INTEGER, 
	@inRacMasa		AS INTEGER, 
	@inTip		 	AS INTEGER,
	@inKomada		AS INTEGER,
	@inIznos	 	AS DECIMAL(12,2),
	@inValuta	 	AS CHAR(2)

)
AS

IF @inAkcija = 'New' 
   BEGIN
	INSERT INTO  SlogDencane ( RecID, Stanica, OtpUprava, OtpStanica, OtpBroj, OtpDatum, DencanoStavka, 
		  					   Tarife, StvMasa, RacMasa, Tip, Komada, Iznos, Valuta ) 
	VALUES ( @inRecID, @inStanicaUnosa, @inOtpUprava , @inOtpStanica , @inOtpBroj, @inOtpDatum , @inDencanoStavka, 
 	                 @inTarife, @inStvMasa, @inRacMasa, @inTip, @inKomada, @inIznos, @inValuta ) 
   END
ELSE IF @inAkcija = 'Del' 
   BEGIN
	DELETE FROM SlogDencane  WHERE RecID = @inRecID And Stanica = @inStanicaUnosa And DencanoStavka=@inDencanoStavka 
   END
ELSE IF @inAkcija = 'Upd' 
   BEGIN
	UPDATE SlogDencane
	SET
		OtpUprava		= @inOtpUprava,
		OtpStanica		= @inOtpStanica,
		OtpBroj			= @inOtpBroj,
		OtpDatum		= @inOtpDatum,
		Tarife			=  @inTarife,	
	              StvMasa	 	=  @inStvMasa,
		RacMasa 		=  @inRacMasa,
		Tip 	  		=  @inTip,		 	
		Komada 		=  @inKomada,
		Iznos	   		=  @inIznos,	 
		Valuta	  		=  @inValuta	 

	WHERE RecID = @inRecID And Stanica = @inStanicaUnosa And DencanoStavka=@inDencanoStavka 
   END
RETURN @@RowCount

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE spUpisSlogNaknadeUI
(

	@inAkcija		AS CHAR(3),
	@inRecID		AS INTEGER,
	@inStanicaUnosa	AS CHAR(5),
	@inOtpUprava	 	AS CHAR(4),
	@inOtpStanica	 	AS CHAR(7),
	@inOtpBroj		AS INTEGER,
	@inOtpDatum		AS DATETIME,
	@inNaknadeStavka	AS INTEGER,
	@inSifraNaknade 	AS CHAR(2),
	@inIvicniBroj	 	AS CHAR(2),
	@inIznos 		AS DECIMAL(12,2),
	@inValuta	 	AS CHAR(2), 
	@inKolicina		AS INTEGER, 
	@inDanCas		AS INTEGER,
	@inPlacanje	 	AS CHAR(2), 
	@inVrsta	 	AS CHAR(1) 


)
AS

IF @inAkcija = 'New' 
   BEGIN
	INSERT INTO  SlogNaknada (RecID, Stanica, OtpUprava, OtpStanica, OtpBroj, OtpDatum, NaknadeStavka, SifraNaknade, IvicniBroj, Iznos, Valuta, Kolicina, DanCas, Placanje, Vrsta) 
		VALUES ( @inRecID, @inStanicaUnosa, @inOtpUprava , @inOtpStanica , @inOtpBroj, @inOtpDatum , @inNaknadeStavka, @inSifraNaknade, @inIvicniBroj, @inIznos, @inValuta, @inKolicina, @inDanCas, @inPlacanje, @inVrsta)
   END
ELSE IF @inAkcija = 'Del' 
   BEGIN

	DELETE FROM SlogNaknada WHERE RecID = @inRecID And Stanica = @inStanicaUnosa And NaknadeStavka = @inNaknadeStavka
   END
ELSE IF @inAkcija = 'Upd' 
   BEGIN
	UPDATE SlogNaknada
	SET
		OtpUprava		= @inOtpUprava,
		OtpStanica		= @inOtpStanica,
		OtpBroj			= @inOtpBroj,
		OtpDatum		= @inOtpDatum,
		SifraNaknade		= @inSifraNaknade ,
             		IvicniBroj		= @inIvicniBroj , 
		Iznos			= @inIznos ,
		Valuta			= @inValuta, 
		Kolicina			= @inKolicina,
		DanCas			= @inDanCas,
		Placanje		= @inPlacanje,
		Vrsta			= @inVrsta
	
	WHERE RecID = @inRecID and Stanica = @inStanicaUnosa and NaknadeStavka = @inNaknadeStavka
   END

RETURN @@RowCount

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--------------------------
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE spUpisSlogRobaUI
(

	@inAkcija		AS CHAR(3),
	@inRecID		AS INTEGER,
	@inStanicaUnosa	AS CHAR(5),
	@inOtpUprava		AS CHAR(4),
	@inOtpStanica		AS CHAR(7),
	@inOtpBroj		AS INTEGER,
	@inOtpDatum		AS DATETIME,
	@inKolaStavka		AS INTEGER,
	@inRobaStavka		AS INTEGER,
	@inNHM	 	AS CHAR(6), 
	@inR		 	AS CHAR(1), 
	@inSMasa		AS INTEGER, 
	@inRacMasa		AS INTEGER, 
	@inVozStav	 	AS DECIMAL(12,2),
	@inRID		 	AS CHAR(1) ,
	@inUtiTip	 	AS CHAR(2) ,
	@inUtiIB	 	AS CHAR(11),
	@inUtiTara	 	AS INTEGER,
	@inUtiRaster	 	AS DECIMAL,
	@inUtiNHM	 	AS CHAR(6), 
	@inUtiPredajniList 	AS CHAR(10),
	@inUtiBrPlombe 	AS CHAR(12)


)
AS

IF @inAkcija = 'New' 
   BEGIN
	INSERT INTO  SlogRoba (RecID, Stanica,OtpUprava, OtpStanica, OtpBroj, OtpDatum, KolaStavka, RobaStavka, NHM, NHMRazred, SMasa, RMasa, VozStav, RID, UtiTip, UtiIB, UtiTara, UtiRaster, UtiNHM, UtiPredajniList, UtiBrPlombe ) 
			VALUES ( @inRecID, @inStanicaUnosa, @inOtpUprava , @inOtpStanica , @inOtpBroj, @inOtpDatum , @inKolaStavka, @inRobaStavka, @inNHM, @inR, @inSMasa, @inRacMasa, @inVozStav, @inRID, @inUtiTip,@inUtiIB, @inUtiTara, @inUtiRaster,@inUtiNHM, @inUtiPredajniList,@inUtiBrPlombe)
   END
ELSE IF @inAkcija = 'Del' 
   BEGIN
		DELETE FROM SlogRoba  WHERE RecID = @inRecID And Stanica = @inStanicaUnosa And KolaStavka = @inKolaStavka And RobaStavka=@inRobaStavka 	
   END
ELSE IF @inAkcija = 'Upd' 
   BEGIN
	UPDATE SlogRoba
	SET	
		OtpUprava		= @inOtpUprava,
		OtpStanica		= @inOtpStanica,
		OtpBroj			= @inOtpBroj,
		OtpDatum		= @inOtpDatum,
		NHM			= @inNHM ,
             		NHMRazred		= @inR , 
		SMasa			= @inSMasa ,
		RMasa			= @inRacMasa ,
		VozStav		= @inVozStav ,
		RID			= @inRID, 
		UtiTip			= @inUtiTip,
		UtiIB			= @inUtiIB,
		UtiTara			= @inUtiTara,
		utiRaster		= @inUtiRaster,
		UtiNHM			= @inUtiNHM, 
		UtiPredajniList		= @inUtiPredajniList,
		UtiBrPlombe 		= @inUtiBrPlombe 	

	WHERE RecID = @inRecID and Stanica = @inStanicaUnosa and KolaStavka = @inKolaStavka  and RobaStavka=@inRobaStavka 	
   END
RETURN @@RowCount
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE spUpisSlogKolaUI
(

	@inAkcija		AS CHAR(3),
	@inRecID		AS INTEGER,
	@inStanicaUnosa		AS CHAR(5),
	@inOtpUprava	 	AS CHAR(4),
	@inOtpStanica	 	AS CHAR(7),
	@inOtpBroj		AS INTEGER,
	@inOtpDatum		AS DATETIME,
	@inKolaStavka		AS INTEGER,
	@inIBK	 		AS CHAR(12), 
	@inIBKOK 		AS CHAR(1), 
	@inUprava 		AS CHAR(6), 
	@inVlasnik 		AS CHAR(1), 
	@inSerija	 	AS CHAR(11), 
	@inOsovine		AS INTEGER, 
	@inTara		AS INTEGER, 
	@inGranTov		AS INTEGER,
	@inStitna 		AS CHAR(1),
	@inTipKola	 	AS CHAR(2), 
	@inPrevoznina 		AS DECIMAL(12,2),
	@inNaknada 		AS DECIMAL(12,2),
	@inICF	 		AS CHAR(1)


)
AS



IF @inAkcija = 'New' 
   BEGIN
	INSERT INTO  SlogKola (RecID, Stanica, OtpUprava, OtpStanica, OtpBroj, OtpDatum, KolaStavka, IBK, Kontrola, Uprava, Vlasnik, Serija, Osovine, Tara, GranTov, Stitna, TipKola, Prevoznina, Naknada, ICF) 
		   VALUES ( @inRecID, @inStanicaUnosa, @inOtpUprava , @inOtpStanica , @inOtpBroj, @inOtpDatum , @inKolaStavka, @inIBK, @inIBKOK, @inUprava, @inVlasnik, @inSerija, @inOsovine, @inTara, @inGranTov, @inStitna, @inTipKola,@inPrevoznina, @inNaknada, @inICF)
   END
ELSE IF @inAkcija = 'Del' 
   BEGIN
		DELETE FROM SlogKola WHERE RecID = @inRecID And Stanica = @inStanicaUnosa And KolaStavka=@inKolaStavka
   END
ELSE IF @inAkcija = 'Upd' 
   BEGIN
	UPDATE SlogKola
	SET	
		OtpUprava		= @inOtpUprava,
		OtpStanica		= @inOtpStanica,
		OtpBroj			= @inOtpBroj,
		OtpDatum		= @inOtpDatum,
		IBK			= @inIBK ,
    		Kontrola			= @inIBKOK , 
		Uprava			= @inUprava ,
		Vlasnik			= @inVlasnik, 
		Serija			= @inSerija

	WHERE RecID = @inRecID and Stanica = @inStanicaUnosa and KolaStavka = @inKolaStavka

   END

RETURN @@RowCount
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-------------------------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE spUpisSlogKalkUI
(

	@inAkcija		AS CHAR(3),
	@inStanicaUnosa	AS CHAR(5),
	@inOtpUprava		AS CHAR(4),
	@inOtpStanica		AS CHAR(7),
	@inOtpBroj		AS INTEGER,
	@inOtpDatum		AS DATETIME,
	@inObrGodina		AS CHAR(4),
	@inObrMesec		AS CHAR(2),
	@inZsUlPrelaz 		AS CHAR(5),
	@inUlEtiketa 		AS INTEGER,
	@inDatumUlaza		AS DATETIME,
	@inZsIzPrelaz 		AS CHAR(5),
	@inIzEtiketa		AS INTEGER,
	@inDatumIzlaza		AS DATETIME,
	@inPrUprava	 	AS CHAR(4),
	@inPrStanica		AS CHAR(7),
	@inPrBroj		AS INTEGER,
	@inPrDatum		AS DATETIME,
	@inBrojVoza		AS INTEGER,
	@inSatVoza	 	AS CHAR(5),
	@inNajava	 	AS CHAR(10),
	@inNajavaKola		AS INTEGER,
	@inNajava2	 	AS CHAR(10),
	@inNajavaKola2	AS INTEGER,
	@inSifraTarife		AS CHAR(2),
	@inUgovor		AS CHAR(6),
	@inPosiljalac		AS INTEGER,
	@inPlatilacFRR		AS INTEGER,
	@inPrimalac		AS INTEGER,
	@inPlatilacNFR		AS INTEGER,
	@inVrPos		AS CHAR(1),
	@inPrevoz		AS CHAR(1),
	@inSaobracaj		AS CHAR(1),
	@inVrSao		AS INTEGER,
	@inVrPrevoza		AS CHAR(1),
	@inUKK		AS INTEGER,
	@inZsPrevozniPut	AS INTEGER,
	@intkm			AS INTEGER,
	@inskm			AS INTEGER,
	@inIzjava		AS INTEGER,
	@inFrRacun		AS CHAR(10),
	@inK115_e		AS DECIMAL(12,2),
	@inK115_d		AS DECIMAL(12,2),
	@inFrankoPoCIM_e	AS DECIMAL(12,2),
	@inFrankoPoCIM_d	AS DECIMAL(12,2),
	@inFrNaknade		AS CHAR(8),
   	@inFrDoPrelaza		AS CHAR(4),
	@inIncoterms		AS CHAR(3),
	@inIsporukaVal		AS CHAR(3),
	@inIsporuka		AS DECIMAL(12,2),
	@inPouzeceVal		AS CHAR(3),
	@inPouzece		AS DECIMAL(12,2),
	@inVrednostRobeVal	AS CHAR(3),
	@inVrednostRobe	AS DECIMAL(12,2),
	@inTLValuta		AS CHAR(2),
	@inTLSumaFR		AS DECIMAL(12,2),
	@inTLSumaUP		AS DECIMAL(12,2),
	@inTLSumaFRDin	AS DECIMAL(12,2),
	@inTLSumaUPDin	AS DECIMAL(12,2),
	@inTLPrevFR		AS DECIMAL(12,2),
	@inTLPrevUP		AS DECIMAL(12,2),
	@inTLNakFR		AS DECIMAL(12,2),
	@inTLNakUP		AS DECIMAL(12,2),
	@inTLPrevFRDin	AS DECIMAL(12,2),
	@inTLPrevUPDin	AS DECIMAL(12,2),
	@inTLNakFRDin	AS DECIMAL(12,2),
	@inTLNakUPDin	AS DECIMAL(12,2),
	@inTLNakCo82		AS DECIMAL(12,2),
	@inTLNakCo		AS DECIMAL(12,2),
	@inrSumaFR		AS DECIMAL(12,2),
	@inrSumaUP		AS DECIMAL(12,2),
	@inrSumaFRDin		AS DECIMAL(12,2),
	@inrSumaUPDin	AS DECIMAL(12,2),
	@inrK115_d		AS DECIMAL(12,2),
	@inSifraK211		AS CHAR(20),
	@inReferent1		AS CHAR(4),
	@inObradaDatum	AS DATETIME,
	@inCarStanica		AS CHAR(5),
	@inCarPrimalacPIB	AS CHAR(10),
	@inCarPrimalacNaziv	AS CHAR(30),
	@inCarPrimalacSediste	AS CHAR(30),
	@inCarPrimalacZemlja	AS CHAR(5),
	@inCarValuta		AS CHAR(5),
	@inCarFaktura		AS DECIMAL(12,2),
	@inCarBrFakture	AS CHAR(10),
	@inCarDokumenti	AS CHAR(100),
	@inCarKnjiga		AS CHAR(10),
	@inCarDatum		AS DATETIME,
	@inCarAgent 	    	AS CHAR(30),
	@inCarXml        		AS CHAR(1),
	@inServer 		AS CHAR(1),
	@inUpdRecID		AS INTEGER,
	@inUpdStanicaRecID	AS CHAR(5), 
	@oppRecID 	            	AS INTEGER OUTPUT


)
AS

set @oppRecID=0

IF @inAkcija = 'New'
   BEGIN
	INSERT INTO  SlogKalk (Stanica, OtpUprava, OtpStanica, OtpBroj, OtpDatum, ObrGodina, ObrMesec,
			ZsUlPrelaz, UlEtiketa, DatumUlaza, ZsIzPrelaz, IzEtiketa, DatumIzlaza, PrUprava, PrStanica, PrBroj, PrDatum,
			BrojVoza, SatVoza, Najava, NajavaKola, Najava2, NajavaKola2, ObrGodina2, ObrMesec2, SifraTarife, Ugovor, Posiljalac, PlatilacFRR, Primalac,  PlatilacNFR, VrPos, Prevoz, Saobracaj, VrSao, VrPrevoza, UkupnoKola, PrevozniPutZs,
			TkmZS, SkmZS, SifraIzjave, FrRacun, K115_e, K115_d,  FrankoPoCIM_e, FrankoPoCIM_d, FrNaknade, FrDoPrelaza, Incoterms, IsporukaVal, Isporuka, PouzeceVal, Pouzece, VrednostRobeVal, VrednostRobe,
			tlValuta, tlSumaFr, tlSumaUp, tlSumaFrDin, tlSumaUpDin, tlPrevFr, tlPrevUp, tlNakFr, tlNakUp, tlPrevFrDin, tlPrevUpDin, tlNakFrDin, tlNakUpDin, tlNakCo82, tlNakCo, rSumaFr, rSumaUp, rSumaFrDin, rSumaUpDin, rK115_d, SifraK211, Referent1, DatumObrade,
			CarStanica, CarPrimalacPIB, CarPrimalacNaziv, CarPrimalacSediste, CarPrimalacZemlja, CarValuta, CarFaktura, CarBrojFakture, CarDokumenti, CarKnjiga,
			CarDatum, CarAgent, CarXml, Server)
	VALUES ( @inStanicaUnosa, @inOtpUprava , @inOtpStanica , @inOtpBroj, @inOtpDatum , @inObrGodina, @inObrMesec, @inZsUlPrelaz, @inUlEtiketa, @inDatumUlaza,
			@inZsIzPrelaz, @inIzEtiketa, @inDatumIzlaza, @inPrUprava, @inPrStanica, @inPrBroj, @inPrDatum, @inBrojVoza, @inSatVoza, @inNajava,@inNajavaKola, @inNajava2, @inNajavaKola2, @inObrGodina, @inObrMesec,
			@inSifraTarife, @inUgovor, @inPosiljalac, @inPlatilacFRR, @inPrimalac, @inPlatilacNFR, @inVrPos, @inPrevoz, @inSaobracaj, @inVrSao,@inVrPrevoza,@inUKK, @inZsPrevozniPut, @intkm,
			@inskm, @inIzjava, @inFrRacun, @inK115_e, @inK115_d, @inFrankoPoCIM_e, @inFrankoPoCIM_d, @inFrNaknade, @inFrDoPrelaza, @inIncoterms, @inIsporukaVal, @inIsporuka, @inPouzeceVal, @inPouzece, @inVrednostRobeVal, @inVrednostRobe,
			@inTLValuta, @inTLSumaFr, @inTLSumaUp, @inTLSumaFrDin, @inTLSumaUpDin, @inTLPrevFr, @inTLPrevUp, @inTLNakFr, @inTLNakUp, @inTLPrevFrDin, @inTLPrevUpDin, @inTLNakFrDin, 
			@inTLNakUpDin, @inTLNakCo82, @inTLNakCo, @inrSumaFr, @inrSumaUp, @inrSumaFrDin, @inrSumaUpDin, @inrK115_d, @inSifraK211, @inReferent1, @inObradaDatum, @inCarStanica, @inCarPrimalacPIB, @inCarPrimalacNaziv, @inCarPrimalacSediste,
			@inCarPrimalacZemlja, @inCarValuta, @inCarFaktura, @inCarBrFakture, @inCarDokumenti, @inCarKnjiga, @inCarDatum, @inCarAgent, @inCarXml, @inServer)

	set @oppRecID=@@IDENTITY

   END
ELSE IF @inAkcija = 'Del'
    BEGIN
	 	 DELETE FROM SlogKalk WHERE RecID = @inUpdRecID and Stanica = @inUpdStanicaRecID
    END
ELSE IF @inAkcija = 'Upd'
    BEGIN

    UPDATE SlogKalk
	SET  

	OtpUprava				= @inOtpUprava,
	OtpStanica				= @inOtpStanica,
	OtpBroj					= @inOtpBroj,
	OtpDatum        		= @inOtpDatum,
	ObrGodina       		= @inObrGodina,
	ObrMesec        		= @inObrMesec,
	ZsUlPrelaz      		= @inZsUlPrelaz,
	UlEtiketa       		= @inUlEtiketa,
	DatumUlaza      		= @inDatumUlaza,
	ZsIzPrelaz				= @inZsIzPrelaz,
	IzEtiketa       		= @inIzEtiketa,
	DatumIzlaza     		= @inDatumIzlaza,
	PrUprava        		= @inPrUprava,
	PrStanica       		= @inPrStanica,
	PrBroj          		= @inPrBroj,
	PrDatum         		= @inPrDatum,
	BrojVoza        		= @inBrojVoza,
	SatVoza         		= @inSatVoza,
	Najava          		= @inNajava,
	NajavaKola      		= @inNajavaKola,
	Najava2          		= @inNajava2,
	NajavaKola2      		= @inNajavaKola2,
	ObrGodina2       		= @inObrGodina,
	ObrMesec2        		= @inObrMesec,
	SifraTarife     		= @inSifraTarife,
	Ugovor          		= @inUgovor,
	Posiljalac      		= @inPosiljalac,
	PlatilacFRR     		= @inPlatilacFRR,
	Primalac        		= @inPrimalac,
	PlatilacNFR     		= @inPlatilacNFR,
	VrPos           		= @inVrPos,
	Prevoz          		= @inPrevoz,
	Saobracaj       		= @inSaobracaj,
	VrSao           		= @inVrSao,
	VrPrevoza       		= @inVrPrevoza,
	UkupnoKola				= @inUKK,
	PrevozniPutZs			= @inZsPrevozniPut,
	TkmZS             		= @intkm,
	SkmZS             		= @inskm,
	SifraIzjave       		= @inIzjava,
	FrRacun         		= @inFrRacun,
	K115_e					= @inK115_e, 
	K115_d					= @inK115_d,  
	FrankoPoCIM_e			= @inFrankoPoCIM_e, 
	FrankoPoCIM_d			= @inFrankoPoCIM_d,
	FrNaknade       		= @inFrNaknade,
	FrDoPrelaza     		= @inFrDoPrelaza,
	Incoterms       		= @inIncoterms,
	IsporukaVal     		= @inIsporukaVal,
	Isporuka        		= @inIsporuka,
	PouzeceVal      		= @inPouzeceVal,
	Pouzece         		= @inPouzece,
	VrednostRobeVal			= @inVrednostRobeVal,
	VrednostRobe    	= @inVrednostRobe,
	TLValuta     		= @inTLValuta,
	TLSumaFR	   		= @inTLSumaFR,
	TLSumaUP			= @inTLSumaUP,
	TLSumaFRDin   		= @inTLSumaFRDin,
	TLSumaUPDin  		= @inTLSumaUPDin,
	TLPrevFR       		= @inTLPrevFR,
	TLPrevUP       		= @inTLPrevUP,
	TLNakFR        		= @inTLNakFR,
	TLNakUP        		= @inTLNakUP,
	TLPrevFRDin    		= @inTLPrevFR,
	TLPrevUPDin   		= @inTLPrevUP,
	TLNakFRDin     		= @inTLNakFR,
	TLNakUPDin     		= @inTLNakUP,
	TLNakCo82      		= @inTLNakCo82,
	TLNakCo      		= @inTLNakCo,
	rSumaFR				= @inrSumaFR,
	rSumaUP				= @inrSumaUP,
	rSumaFRDin			= @inrSumaFRDin,
	rSumaUPDin			= @inrSumaUPDin,
	rK115_d				= @inrK115_d,
	SifraK211			= @inSifraK211,
	Referent1      		= @inReferent1,
	DatumObrade     	= @inObradaDatum

	WHERE RecID = @inUpdRecID and Stanica = @inUpdStanicaRecID

	SELECT @oppRecID= RecID From SlogKalk 
	WHERE OtpUprava=@inOtpUprava and OtpStanica=@inOtpStanica and OtpBroj=@inOtpBroj and OtpDatum=@inOtpDatum
	
    END
RETURN @@RowCount

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

