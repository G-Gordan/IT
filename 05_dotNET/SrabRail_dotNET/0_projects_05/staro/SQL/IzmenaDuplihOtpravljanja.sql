update SlogUIC
set OtpBroj=52195
where  (Sloguic.OtpUprava = '0072') AND (Sloguic.OtpStanica = '7223450') 
	AND (Sloguic.OtpBroj = 521960) AND Sloguic.OtpDatum = '2/23/2008'

update SlogNaknada
set OtpBroj=52195
where  (SlogNaknada.OtpUprava = '0072') AND (SlogNaknada.OtpStanica = '7223450') 
	AND (SlogNaknada.OtpBroj = 521960) AND SlogNaknada.OtpDatum = '2/23/2008'


update SlogRoba
set OtpBroj=52195
where  (SlogRoba.OtpUprava = '0072') AND (SlogRoba.OtpStanica = '7223450') 
	AND (SlogRoba.OtpBroj = 521960) AND SlogRoba.OtpDatum = '2/23/2008'


update SlogKola
set OtpBroj=52195
where  (SlogKola.OtpUprava = '0072') AND (SlogKola.OtpStanica = '7223450') 
	AND (SlogKola.OtpBroj = 521960) AND SlogKola.OtpDatum = '2/23/2008'

update SlogKalk
set OtpBroj=52195
where  (SlogKalk.OtpUprava = '0072') AND (SlogKalk.OtpStanica = '7223450') 
	AND (SlogKalk.OtpBroj = 521960) AND SlogKalk.OtpDatum = '2/23/2008'


