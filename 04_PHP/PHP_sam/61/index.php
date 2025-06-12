<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<meta name="description" content="This is an example of meta description. This will often show up in search results.">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<title>NASLOV</title>
		</head>
	<body>
		
		<?php
			// NIJE PREPORUCLJIVO ZA PASSWORD VEC ZA UNIQUE URL ILI FILE NAME!
			/*
			function generateKey() {
				$keyLenght = 8;
				$str = "1234567890abcdefghijklmnopqrstuvwxyz()/$";
				$randStr = substr(str_shuffle($str), 0, $keyLenght);//iz promesanog stringa $str uzima, pocev od prvog mesta, 8 karaktera
				return $randStr;
			}
			*/

			/*
			function generateKey() {
				//$randStr = uniqid();//daje 13 jedinstvenih brojeva koji se ne ponavljaju
				//$randStr = uniqid('daniel');//daniel je opcioni prefiks a iza njega sledi 13 jedinstvenih brojeva koji se ne ponavljaju
				$randStr = uniqid('daniel', true);//daniel je opcioni prefiks a iza njega sada sledi 15 jedinstvenih brojeva koji se ne ponavljaju, pa tacke (.), pa jos 8 unique brojeva - default je false (a ne true)
				return $randStr;
			}
			*/


			// OVO MOZE DAS EKORISTI ZA PASSWORD!
			$conn = mysqli_connect("localhost", "root", "", "php62");

			function checkKeys($conn, $randStr) {
				$sql = "SELECT * FROM keystring"; // keystring - je tabela sa id-ovima
				$result = mysqli_query($conn, $sql);
				while ($row = mysqli_fetch_assoc($result)) {
					if ($row['keystringKey'] == $randStr) { // keystringKey - je polje tabele
						$keyExists = true;
						break;
					} else {
						$keyExists = false;
					}
				}
				return $keyExists;
			}

			function generateKey($conn) {
				$keyLenght = 1;// moze se povecati na 8 karaktera kao za standardan password
				//$str = "1234567890abcdefghijklmnopqrstuvwxyz()/$";
				$str = "abcdefgh";// moze da se vrati ceo skup karaktera ako su i u tabeli id-ovi ili passwordi sa po 8 karaktera
				$randStr = substr(str_shuffle($str), 0, $keyLenght);
				$checkKey = checkKeys($conn, $randStr);
				while ($checkKey == true) {
					$randStr = substr(str_shuffle($str), 0, $keyLenght);
					$checkKey = checkKeys($conn, $randStr);
				}
				return $randStr;
			}

			echo generateKey($conn);// posto su u tabeli baze A, b i c, nikada ne izbacuje ove vrednosti vec ostalih 5 (d,e,f,g i h)

		?>

	</body>
</html>