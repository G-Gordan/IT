/*

	Increment values

*/

DECLARE @counter int
SET @counter = 470
UPDATE radnik.t8445
SET @counter = RecID = @counter + 1

Insert into CoAneksi
Select * from radnik.t8445


