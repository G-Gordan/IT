DECLARE @AccountID INT
DECLARE @getAccountID CURSOR

SET @getAccountID = CURSOR FOR
SELECT KolaStavka
FROM NajavaKola

OPEN @getAccountID
FETCH NEXT FROM @getAccountID INTO @AccountID

WHILE @@FETCH_STATUS = 0
 BEGIN
  if @AccountID < 5
     PRINT @AccountID
	 
  FETCH NEXT FROM @getAccountID INTO @AccountID
 END
CLOSE @getAccountID
DEALLOCATE @getAccountID