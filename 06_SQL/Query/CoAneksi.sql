/*

	Upisivanje aneksa za CO

 

*/

--1. CoAneksi
drop table tmp_CoAneksi
Select * into tmp_CoAneksi from CoAneksi where Ugovor='780802'
Select * from tmp_CoAneksi

update tmp_coAneksi
set 	RecID = RecID+83,
	VrstaPrevoza='V',
	Ugovor='780801'

Insert into CoAneksi
Select * from tmp_coAneksi


--2. CoAneksiNhm
drop table tmp_CoAneksiNhm
Select * into tmp_CoAneksiNhm from CoAneksiNhm where RecID>299
Select * from tmp_CoAneksiNhm

update tmp_coAneksiNhm
set RecID = RecID+83

Insert into CoAneksiNhm
Select * from tmp_coAneksiNhm
