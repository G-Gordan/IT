<!DOCTYPE html>
<html lang="en">
<head>
  <title>Nizovi</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
	<h2>Nizovi</h2>
	<pre><?php
		$fajl = fopen("fajl.txt", 'r');
		/*
		$prvired = fgets($fajl);
		echo $prvired;
		$prvired = fgets($fajl);
		echo $prvired;
		fclose($fajl);
		
		$fajl = fopen("fajl.txt", 'a');
		fputs($fajl, 'Novi tekst'.PHP_EOL.'Drugi red');
		*/
		/*
		$redovi_u_fajlu = [];
		while( $red = fgets($fajl) ){
			$redovi_u_fajlu[] = $red;
		}
		
		$redovi_u_fajlu = file('fajl.txt');
		
		$fajl = file_get_contents('fajl.txt');
		echo $fajl;
		
		file_put_contents("fajl.txt", "novi sadrzaj", FILE_APPEND);
		*/
	?>
	</pre>
</body>
</html>