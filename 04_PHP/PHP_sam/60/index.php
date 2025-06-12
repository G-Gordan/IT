<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title></title>
		</head>
	<body>
		<?php
			$string = "My name is Daniel, Daniel is my name";

			// * funkcija jeste Case Sensitive!!!
			//echo preg_match("/(a|b|c)/", $string);// daje 1/0 ili true/false akostring sadrzi bar jedan od znakova
			//echo preg_match("/[abc]/", $string);// isto kao prethodno
			//echo preg_match("/[^abc]/", $string);// proverava da se navedeni znakovi NE SADRZE u stringu
			//echo preg_match("/[A-Z]/", $string);// proverava da li string sadrzi bilo koji karakter od velikog A do velikog Z
			//echo preg_match("/[a-zA-Z0-9]/", $string);// trazi bilo koje malo ili veliko slovo ili cifru
			//echo preg_match("/D*/", $string);// proverava da li u stringu ima vise slova D i daje 1/0 ili true/false
			
			//preg_match_all("/D*/", $string, $array);
			//print_r($array);// daje niz gde je svako slovo i spejs prazan niz u nizu samo onaj koji jeste D ima element D
			
			/*
			preg_match_all("/D+/", $string, $array);
			print_r($array);// daje niz koji ima elemente D
			*/

			//preg_match_all("/D.*/", $string, $array);
			//print_r($array);// daje niz koji sadrzi jedan element, string koji pocinje prvim znakom koji se trazi (D) i tera do kraja
		
			/*
			preg_match_all("/D.+/", $string, $array);
			print_r($array);// isto daje niz koji sadrzi jedan element, string koji pocinje prvim znakom koji se trazi (D) i tera do kraja
			*/

			/*
			preg_match_all("/D.*m/", $string, $array);
			print_r($array);// daje niz koji sadrzi jedan element, string koji pocinje prvim znakom koji se trazi (D) i zavrsava se sa moslednjim m u nizu
			*/

			/*
			$string = "My 1name2 is Daniel, 1Daniel2 is my name";
			preg_match_all("/1.*?2/", $string, $array);
			print_r($array);// daje niz koji sadrzi elemente, skup karaktera izmedju 1 i 2 zajedno sa jedan i 2 (1name2 i 1Daniel2)
			*/

			//$string = "My name is Daniel, Daniel is my name";
			//echo preg_match("/D{2}/", $string);// proverava da li ima mesto gde je jedno veliko D - daje 0 (false)
			//echo preg_match("/D{1,2}/", $string);// proverava da li ima mesto gde je jedno veliko D ili 2 D jedno do drugog - daje 1 (true)
			//echo preg_match("/D{1,}/", $string);// proverava da li ima mesto gde je jedno veliko D ili vise njih jedno do drugog - daje 1 (true)
			//echo preg_match("/\D{3}/", $string);// proverava da li ima mesto gde 3 karaktera (racuna i spejs, zarez, tacka...) zajedno a da nisu brojevi (digital), da jesu brojevi treba staviti malo d

			/*
			preg_match_all("/\D{3}/", $string, $array);
			print_r($array);// daje multidimenu matricu koja sadrzi nizove koji su NE brojevi sa po 3 bilo kaj znaka zajedno (moze i spejs, zarez, tacka...)
			*/

			/*
			preg_match_all("/\S{3}/", $string, $array);
			print_r($array);// daje multidimenu matricu koja sadrzi nizove koji su NE brojevi sa po 3 znaka (stringa)zajedno ali BEZ spejsova, zareza, tacki. SAMO SLOVA
			*/

			//echo preg_match("/^M/", $string);//daje 1 (true) ako string pocinje sa M
			//echo preg_match("/e$/", $string);//daje 1 (true) ako se string zavrsava sa e
			//echo preg_match("/^M.*e$/", $string);//daje 1 (true) ako string pocinje sa M, uzima sve stringove iza M (*) i zavrsava sa sa e
			echo preg_match("/\^.*e$/", $string);//daje 1 (true) ako string pocinje sa ^, neophodan je znak \ da bi ^ tretirao kao obican karakter a ne kao operator


		?>
	</body>
</html>