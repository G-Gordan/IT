CREATE PROCEDURE  NadjiUvozJCI
(

                              @inOtpUprava 	As char(4),
                              @inOtpStanica 	As char(7),
                              @inOtpBroj 		As integer,
                              @inDatum 		As Datetime,
                              @outRecID	 	As integer OUTPUT,
                              @outStanicaID	As char(5) OUTPUT,
                              @outRetVal 		AS VarChar(50)  OUTPUT
 )

 AS

Set @outRetVal = ''

Select	@outRecID=RecID, @outStanicaID = Stanica
From	 SlogKalk 
Where	 (@inOtpBroj = OtpBroj) and (@inOtpStanica = OtpStanica) and (@inOtpUprava = OtpUprava) and (@inDatum = OtpDatum)


If @@RowCount < 1
begin
       Set @outRetVal = 'Neuspesan upit'
       Set @outRecID = 0
       Set @outStanicaRecID='0'
end
GO


---------------okp
CREATE PROCEDURE  NadjiTL1
(

                              @inOtpUprava 	As char(4),
                              @inOtpStanica 	As char(7),
                              @inOtpBroj 		As integer,
                              @inDatum 		As Datetime,
                              @outRecID		As integer	OUTPUT,
                              @outStanicaRecID	As char(5)	OUTPUT,
                              @outRetVal 		As VarChar(50)	OUTPUT
 )

 AS
 Set @outRetVal = ''
  
Select	@outRecID=RecID, @outStanicaRecID=Stanica
From SlogKalk 
Where (@inOtpBroj = OtpBroj) and (@inOtpStanica = OtpStanica) and (@inOtpUprava = OtpUprava) and (@inDatum = OtpDatum)

If @@RowCount < 1
Begin
  Set @outRetVal = 'Neuspesan upit'
  Set @outRecID = 0
End
GO

