-- PRVO PREBACITI tabelu REZIMI iz baze tranzit 
-- pa pustiti skrip koji sledi a on 
-- 1. kreira tabele TPOM1,TPOM2,TPOM3,TPOM4 i SLOGIBM2(koja se na kraju prebacuje u txt)
-- 2. kreiraj funkciju dbo.brkola 
-- 3. kreira procedure dbo.tip1, dbo.tip2, dbo.naknada , dbo.prev i dbo.zaIBM

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[brkola]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[brkola]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tip1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tip1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tip2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tip2]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[naknada]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[naknada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[prev]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[prev]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[zaIBM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[zaIBM]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SLOGIBM2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SLOGIBM2]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TPOM1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TPOM1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TPOM2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TPOM2]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TPOM3]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TPOM3]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TPOM4]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TPOM4]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE FUNCTION dbo.brkola(@sif int)  
RETURNS int
 AS  
BEGIN 
Return (select count(*)  from kola where PosID=@sif)
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE TABLE [dbo].[SLOGIBM2] (
	[VRSLOGA] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[SIFOTST] [nvarchar] (7) COLLATE Latin1_General_CI_AS NULL ,
	[BROTPRAV] [float] NULL ,
	[SIFUPST] [nvarchar] (7) COLLATE Latin1_General_CI_AS NULL ,
	[BRPRISP] [float] NULL ,
	[DATOTPRAV] [nvarchar] (6) COLLATE Latin1_General_CI_AS NULL ,
	[DATPRISP] [nvarchar] (6) COLLATE Latin1_General_CI_AS NULL ,
	[VANPUT] [nvarchar] (3) COLLATE Latin1_General_CI_AS NULL ,
	[UGOVORCO] [nvarchar] (6) COLLATE Latin1_General_CI_AS NULL ,
	[VRSTAPOS] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[VRSTASAO] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[PREVOZ] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[POSZAHTEV] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[STARANOVA] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[RAZRED] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[STAV] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[POZICIJA] [nvarchar] (5) COLLATE Latin1_General_CI_AS NULL ,
	[UKKOLA] [float] NULL ,
	[STVMASA] [float] NULL ,
	[RACMASA] [float] NULL ,
	[RAVNE] [float] NULL ,
	[BOKS] [float] NULL ,
	[TIPKOLA1] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[UKKOLA1] [float] NULL ,
	[OSOVINA1] [float] NULL ,
	[TIPKOLA2] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[UKKOLA2] [float] NULL ,
	[OSOVINA2] [float] NULL ,
	[TIPKOLA3] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[UKKOLA3] [float] NULL ,
	[OSOVINA3] [float] NULL ,
	[SMASA1] [float] NULL ,
	[POZICIJA1] [nvarchar] (5) COLLATE Latin1_General_CI_AS NULL ,
	[RAZRED1] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[TARIFA1] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[VOZSTAV1] [float] NULL ,
	[RACMASA1] [float] NULL ,
	[SMASA2] [float] NULL ,
	[POZICIJA2] [nvarchar] (5) COLLATE Latin1_General_CI_AS NULL ,
	[RAZRED2] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[TARIFA2] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[VOZSTAV2] [float] NULL ,
	[RACMASA2] [float] NULL ,
	[SMASA3] [float] NULL ,
	[POZICIJA3] [nvarchar] (5) COLLATE Latin1_General_CI_AS NULL ,
	[RAZRED3] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[TARIFA3] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[VOZSTAV3] [float] NULL ,
	[RACMASA3] [float] NULL ,
	[TKM] [float] NULL ,
	[SKM] [float] NULL ,
	[IZJAVAOPL] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[FRDOPREL] [nvarchar] (3) COLLATE Latin1_General_CI_AS NULL ,
	[SIFVALPOIZ] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[IZNPI] [float] NULL ,
	[KORISNIKCO] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[PREDUJAM] [float] NULL ,
	[JZTAR] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[REEKS] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[SIFULPREL] [nvarchar] (3) COLLATE Latin1_General_CI_AS NULL ,
	[SIFIZPREL] [nvarchar] (3) COLLATE Latin1_General_CI_AS NULL ,
	[VALUTAJZ] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[TARPOV] [float] NULL ,
	[UGOPOV] [float] NULL ,
	[VISE] [float] NULL ,
	[DODATAK] [float] NULL ,
	[PZO] [float] NULL ,
	[NAKN1] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[IZNNAK1] [float] NULL ,
	[NAKN2] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[IZNNAK2] [float] NULL ,
	[NAKN3] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[IZNNAK3] [float] NULL ,
	[NAKN4] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[IZNNAK4] [float] NULL ,
	[NAKN5] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[IZNNAK5] [float] NULL ,
	[NAKN6] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[IZNNAK6] [float] NULL ,
	[NAKN7] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[IZNNAK7] [float] NULL ,
	[NAKN8] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[IZNNAK8] [float] NULL ,
	[ZARFRAN] [float] NULL ,
	[ZARUPU] [float] NULL ,
	[OBRADA] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[IZRACUNATO] [float] NULL ,
	[FRANKO] [float] NULL ,
	[UPUCENO] [float] NULL ,
	[RAZLFRAN] [float] NULL ,
	[RAZLUPU] [float] NULL ,
	[PRAZNO1] [float] NULL ,
	[PRAZNO2] [float] NULL ,
	[USLUGEFRAN] [float] NULL ,
	[USLUGEUPU] [float] NULL ,
	[PRAZNO3] [float] NULL ,
	[PRAZNO4] [nvarchar] (1) COLLATE Latin1_General_CI_AS NULL ,
	[ISBG] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[USBG] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[SKMBG] [float] NULL ,
	[TKMBG] [float] NULL ,
	[ISNS] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[USNS] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[SKNS] [float] NULL ,
	[TKNS] [float] NULL ,
	[ISPG] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[USPG] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[SKMPG] [float] NULL ,
	[TKMPG] [float] NULL ,
	[ISLJ] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[USLJ] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[SKLJ] [float] NULL ,
	[TKLJ] [float] NULL ,
	[ISBH] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[USBH] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[SKBH] [float] NULL ,
	[TKBH] [float] NULL ,
	[ISSK] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[USSK] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[SKMSK] [float] NULL ,
	[TKMSK] [float] NULL ,
	[ISZG] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[USZG] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[SKZG] [float] NULL ,
	[TKZG] [float] NULL ,
	[ISKP] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[USKP] [nvarchar] (2) COLLATE Latin1_General_CI_AS NULL ,
	[SKKP] [float] NULL ,
	[TKKP] [float] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TPOM1] (
	[IDKola] [int] NOT NULL ,
	[PosID] [int] NULL ,
	[BrojOsovina] [smallint] NULL ,
	[Tip] [char] (1) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TPOM2] (
	[PosID] [int] NULL ,
	[tip1] [char] (1) COLLATE Latin1_General_CI_AS NULL ,
	[ukkola1] [int] NULL ,
	[osovina1] [int] NULL ,
	[tip2] [char] (1) COLLATE Latin1_General_CI_AS NULL ,
	[ukkola2] [int] NULL ,
	[osovina2] [int] NULL ,
	[tip3] [char] (1) COLLATE Latin1_General_CI_AS NULL ,
	[ukkola3] [int] NULL ,
	[osovina3] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TPOM3] (
	[ID] [int] NOT NULL ,
	[nak] [float] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TPOM4] (
	[ID] [int] NOT NULL ,
	[prev] [float] NULL 
) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.tip1
@mes char(2),
@god char(4) 
 AS
delete  from TPOM1

insert into TPOM1 
  select k.IDKola,k.PosID,k.BrojOsovina,tip=
  case 
  when (k.Specijalna='O' and r.Vlasnik='Z' and (k.NHM<>'9921' or k.NHM<>'9922')) then '1'
  when (k.Specijalna='S' and r.Vlasnik='Z' and (k.NHM<>'9921' or k.NHM<>'9922')) then '2'
  when (k.Specijalna='O' and r.Vlasnik='P' and (k.NHM<>'9921' or k.NHM<>'9922')) then '3'
  when (k.Specijalna='S' and r.Vlasnik='P' and (k.NHM<>'9921' or k.NHM<>'9922')) then '4'
  when (k.Specijalna='O' and r.Vlasnik='I' and (k.NHM<>'9921' or k.NHM<>'9922')) then '5'
  when (k.Specijalna='S' and r.Vlasnik='I' and (k.NHM<>'9921' or k.NHM<>'9922')) then '6'
  when ((r.Vlasnik='P' or r.Vlasnik='I' ) and (k.NHM='9921' or k.NHM='9922')) then '7'
  else '0'
 end
from POSILJKE p join VOZOVI v on p.VozID=v.IDVoz
 join KOLA k on p.ID=k.PosID and v.IDVoz=k.VozID
 join Rezimi r on k.Rezim=r.Rezim
where v.Godina=@god and v.MesecObracuna=@mes


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.tip2
as
Declare @p int

Declare @p1 char(1)
Declare @p2 int
Declare @p3 int	

Declare @p4 char(1)
Declare @p5 int
Declare @p6 int	
Declare @p7 char(1)
Declare @p8 int
Declare @p9 int	
Declare @p10 char(1)
Declare @p11 int
Declare @p12 int	

delete  from TPOM2 	
Declare pp cursor for
select PosID from TPOM1

open pp
fetch next from pp into @p
while @@fetch_status=0
begin
       declare ppp cursor for
       select Tip,count(*),sum(BrojOsovina) from TPOM1 where PosID=@p group by Tip

      open ppp
      fetch next from ppp into @p1,@p2,@p3
        set @p4=@p1
        set @p5=@p2
        set @p6=@p3
              fetch next from ppp into @p1,@p2,@p3
        if  @@fetch_status=-1
         begin 
         set @p7=0
         set @p8=0
         set @p9=0
         set @p10=0
         set @p11=0
         set @p12=0
          close ppp 
        end 
        else 
         begin 
         set @p7=@p1
         set @p8=@p2
         set @p9=@p3
         
         fetch next from ppp into @p1,@p2,@p3
          if  @@fetch_status=-1
            begin 
            set @p10=0
            set @p11=0
            set @p12=0
             close ppp 
           end 
           else 
           begin 
           set @p10=@p1
           set @p11=@p2
           set @p12=@p3
           
           close ppp 
         end
      end
  deallocate ppp
insert into TPOM2 values(@p,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)
fetch next from pp into @p
end
close pp
deallocate pp


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.naknada
(
@mes char(2),
@god char(4)
)
as
Declare @p int
Declare @nak float
 Declare @nak1 float
Declare @nak2 float
Declare @nak6 float
Declare @nak8 float
	    
delete  from TPOM3	
Declare pp cursor for
select p.ID ,
p.NaknadaI,
case
            when p.StanicaU='16201' then 12
            else 0
           end,
p.Ukupno-p.Prevoznina,
 case 
    when p.NaknadaSifI in('2001','2101','2999','3403','4509','5001','8203','9999') then p.NaknadaI
    else 0
    end 
from posiljke  p join VOZOVI v on p.VozID=v.IDVoz
 where v.Godina=@god and v.MesecObracuna=@mes

open pp
fetch next from pp into @p,@nak1,@nak2,@nak6,@nak8
while @@fetch_status=0
begin 
       
set @nak=@nak1+@nak2+@nak6+@nak8

insert into TPOM3 values(@p,@nak)
fetch next from pp into @p,@nak1,@nak2,@nak6,@nak8
end
close pp
deallocate pp


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE dbo.prev
@mes char(2),
@god char(4) 
 AS
delete  from TPOM4

insert into TPOM4
select p.ID,
case
when right(p.Ugovor,2)='00' and right(p.UgovorCO,2)='00' then p.Prevoznina
when right(p.Ugovor,2)='11' and right(p.UgovorCO,2)='00' then p.Prevoznina  

--when p.Ugovor='100611' and right(p.UgovorCO,2)='00' then 0
--when p.Ugovor='110611' and right(p.UgovorCO,2)='00' then 0
--when p.Ugovor='120611' and right(p.UgovorCO,2)='00' then 0

when right(p.Ugovor,2)='69' and right(p.UgovorCO,2)='00' then p.Prevoznina 
when right(p.Ugovor,2)='00' and right(p.UgovorCO,2)='00' then p.Prevoznina
when p.Ugovor='931817' and p.UgovorCO='931817' 		 then v.Ukupno -- Vozovi.Ukupno
else
  case
  when p.rbr='01' then v.ObracunatIznos
  else
  0
  end
end

 from posiljke p  join VOZOVI v on p.VozID=v.IDVoz 
 where v.Godina=@god and v.MesecObracuna=@mes
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.zaIBM
 @mes char(2),
 @god char(4) 
 AS
delete  from SLOGIBM2

insert into SLOGIBM2
  select 
'09' as vr,  --vrsloga
p.OtprUprava+p.OtprStanica, --sifotst
p.BrojOtpravljanja,  --brotprav
p.UputUprava+p.UputStanica, --sifupstan
p.NalepnicaI, --brprisp
convert(varchar(6),p.DatumOtpravljanja,12), --datotprav
convert(varchar(6),p.DatumOtpravljanja,12), -- datprisp
'000', --vanput
p.Ugovor,--ili Ugovor jer su oni preneli ugovor --ugovorco ????
p.VrstaPosiljke, --vrstapos
p.VrstaSaobracaja, --vrstasao
'1', --prevoz
'0', --poszahtev
'0', --staranova
p.Razred, --razred
stav= case   --stav 
when p.RacunskaTezina *1000<=10000 then '2'
when (p.RacunskaTezina*1000 >10000 and p.RacunskaTezina *1000<=15000) then '3'
when (p.RacunskaTezina*1000 >15000 and p.RacunskaTezina*1000 <=20000) then '4' 
when p.RacunskaTezina*1000 >20000 then '5'
else '0'
end,
'0'+p.NHM, --pozicija
dbo.brkola(p.ID), --ukkola
p.StvarnaTezina*1000, --stvmasa
p.RacunskaTezina*1000, --racmasa
p.PaleteRavne, --ravne
p.PaleteBoks, --boks 
tp.tip1, --tipkola1
tp.ukkola1,  --ukkola1
tp.osovina1,  --osovina1 
tp.tip2, --tipkola2
tp.ukkola2,  --ukkola2
tp.osovina2,  --osovina2 
tp.tip3, --tipkola3
tp.ukkola3,  --ukkola3
tp.osovina3,  --osovina3 
p.StvarnaTezina*1000, --smasa1
'0'+p.NHM, --pozicija1
p.Razred, --razred1
'00', --tarifa1
0, --vozstav1
p.RacunskaTezina*1000, --racmasa1
0, --smasa2
'00000', --pozicija2
'0',   --razred2
'00',  --tarifa2
0,     --vozstav2
0,     --racmasa2
0, --smasa3
'00000', --pozicija3
'0',  --razred3
'00',  --tarifa3
0,     --vozstav3
0,     --racmasa3
p.TarifskiKm, --tkm
p.StvarniKm, --skm
'0', --izjavaopl
'000', --frdoprel
'00', --sifvalpoiz
0, --iznpi
'00', --korisnikco
0, --predujam
'00', --jztar
'0', --reeks
case p.StanicaU   --sifulprel
when    '12498' then '620'
when    '16517' then '501'
when    '21099' then '661'
when    '16201' then '997'
when    '16319' then '531'
when    '23499' then '711'
when    '11028' then '676'
else '000'
end,
case p.StanicaI   --sifizprel
when    '12498' then '620'
when    '16517' then '501'
when    '21099' then '661'
when    '16201' then '997'
when    '16319' then '531'
when    '23499' then '711'
when    '11028' then '676'
else '000'
end,
case v.Valuta   --valutajz
when    'EUR' then '17'
when    'CHF' then '85'
when    'DIN' then '72'
when    'USD' then '02'
else '00'
end,
0, --tarpov
0, --ugopov
0, --vise
0, --dodatak
0, --pzo
'90',--nakn1 ??????? postoji i 91 ???????????????
p.NaknadaI,--iznnak1
'91',--nakn2
case --iznnak2
when p.StanicaU='16201' then 12
else 0
end,
'99',--nakn3
0,--iznnak3
'00',--nakn4
0,--iznnak4
'00',--nakn5
0,--iznnak5
'91',--nakn6
p.Ukupno-p.Prevoznina,--iznnak6
'00',--nakn7
0,--iznnak7
'91',--nakn8
case --iznnak8
when p.NaknadaSifI in('2001','2101','2999','3403','4509','5001','8203','9999') then p.NaknadaI
else 0
end,
0, --zarfran
0, --zarupu
'0', --obrada
t.prev,--izracunato
0,--franko
-- start 25.01.
case
when (p.Ugovor='100611' or p.Ugovor='110611' or p.Ugovor='120611') and right(p.UgovorCO,2)='00' then 0
else 
case
when right(p.Ugovor,2)='00' and right(p.UgovorCO,2)='00' then p.ukupno
when right(p.Ugovor,2)='02' and right(p.UgovorCO,2)='00' then p.ukupno
when right(p.Ugovor,2)='11' and right(p.UgovorCO,2)='00' then p.ukupno
when right(p.Ugovor,2)='69' and right(p.UgovorCO,2)='00' then p.ukupno
when right(p.Ugovor,2)='67' and right(p.UgovorCO,2)='00' then p.ukupno
else
  case
  when p.Ugovor<>'100601' and p.rbr='01' then v.ukupno
  when p.Ugovor='100601' then v.ukupno
  else
  0
  end
end
end,
--p.ukupno, --Izmenjeno 23.01.2007    t.prev+n.nak,--upuceno ??????'
-- end 25.01.
0,--razfran
--dodati case iz start 25.01.
-p.ukupno, --Izmenjeno 23.01.2007  -(t.prev+n.nak),--razlupu  ??????
0, --prazno1
0, --prazno2
0,--uslugefran
n.nak,  --uslugeupu  
0, --prazno3
'0', --prazno4
'00', --isbg
'00', --usbg
p.StvarniKm, --skmbg ???????? 
p.TarifskiKm, --tkmbg  ????????
'00',
'00',
0,
0,
'00',
'00',
0,
0,
'00',
'00',
0,
0,
'00',
'00',
0,
0,
'00',
'00',
0,
0,
'00',
'00',
0,
0,
'00',
'00',
0,
0
from POSILJKE p join VOZOVI v on p.VozID=v.IDVoz
 join KOLA k on p.ID=k.PosID and v.IDVoz=k.VozID
 join TPOM2 tp on p.ID=tp.PosID
 join TPOM3 n on p.ID=n.ID
 join TPOM4 t on p.ID=t.ID
 where v.Godina=@god and v.MesecObracuna=@mes
--where p.ID='292269'
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

