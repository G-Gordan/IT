CREATE TABLE [SlogK211] (
	[RecID] [int] NOT NULL ,
	[Stanica] [char] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Stavka] [int] NOT NULL ,
	[SifraK211] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	CONSTRAINT [PK_SlogK211] PRIMARY KEY  CLUSTERED 
	(
		[RecID],
		[Stanica],
		[Stavka]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO




Select * into PrivK211 from 
(
SELECT     recid, stanica, SifraK211
FROM       SlogKalk
WHERE     (ObrGodina = '2008') AND (ObrMesec = '2') AND (Saobracaj = '3') AND (SifraK211 <> '')
) ss
Select * from PrivK211


--PrivK211_dod


Select * into PrivK211_0714 from 
(
SELECT     recid, stanica, SifraK211
FROM       PrivK211
WHERE     (SifraK211 = '0714')
) ss
Select * from PrivK211_0714



Select * into PrivK211_14 from 
(
SELECT * FROM PrivK211_07

) ss
Select * from PrivK211_14


Select * into K211_import from 
(
SELECT * FROM PrivK211
union all
SELECT * FROM PrivK211_dod
) ss
Select * from K211_import







SELECT     recid, stanica, left(SifraK211,2)
FROM       PrivK211
union all
SELECT     recid, stanica, right(left(SifraK211,4),2)
FROM       PrivK211