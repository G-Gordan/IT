SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE  NadjiTL2NajavaUI
(

                              @inOtpUprava 	As char(4),
                              @inOtpStanica 	As char(7),
                              @inOtpBroj 		As integer,
                              @inDatum 		As Datetime,
                              @outRecID 		As integer OUTPUT,
                              @outStanicaRecID	 As char(5) OUTPUT,
                              @outPrUprava 	As char(4) OUTPUT,
                              @outPrStanica 	As char(7) OUTPUT,
                              @outRetVal 		As VarChar(50) OUTPUT
 )

 AS
 Set @outRetVal = ''
  
Select	@outRecID=RecID, @outStanicaRecID=Stanica, @outPrUprava=PrUprava, @outPrStanica=PrStanica
From 	SlogKalk Where (@inOtpBroj = OtpBroj) and (@inOtpStanica = OtpStanica) and (@inOtpUprava = OtpUprava) and (@inDatum = OtpDatum)

If @@RowCount < 1
	Set @outRetVal = 'Neuspesan upit'
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

