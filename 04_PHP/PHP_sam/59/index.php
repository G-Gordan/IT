<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title></title>
		</head>
	<body>
		<?php
			$string = "My name is Daniel, Daniel is my name";

			/*
			//proverava da li se Daniel sadrzi u stringu i daje 1/0 ili true/false
			if (preg_match("/Daniel/", $string)) {
				echo "It is match!";
			}
			*/

			/*
			//sve vrednosti stringa koje se slazu sa Daniel i ni unosi u visedimenzionalni matricu
			if (preg_match_all("/Da(ni)el/", $string, $array)) {
				//print_r($array);
				echo $array[ 0][1];
			}
			*/

			//menja stari izraz sa novim u stringu
			$string2 = preg_replace("/Daniel/", "Johan", $string);
			echo $string2;

		?>
	</body>
</html>