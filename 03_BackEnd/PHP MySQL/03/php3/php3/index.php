<!DOCTYPE html>
<html lang="en">
<head>
  <title>MySQL konektovanje</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
	<div class="container">
	
	
	
	<?php
		$konekcija = new mysqli('localhost', 'root', '', 'php1');
		// Check connection
		if ($konekcija->connect_error) {
			die("Greska u konektovanju: " . $konekcija->connect_error);
		} 
		echo "Uspesna konekcija";
	
		$rezultatupita = $konekcija->query( " SELECT * FROM imenik ORDER BY prezime DESC " );
	
		print_r($rezultatupita);
		
		//$red = $rezultatupita->fetch_array();
		#$red = $rezultatupita->fetch_assoc();
		#$ime = $red['ime'];
		
		#$red = $rezultatupita->fetch_object();
		#$ime = $red->ime;
		
		#print_r($red);
		
		
		//ucitavanje svih redova
		
		echo '<table class="table">';
		
		//while( ( $red = $rezultatupita->fetch_object() )!=false ){
		while(  $red = $rezultatupita->fetch_object()  ){
			echo '<tr>
					<td>', $red->ime, ' ', $red->prezime, '</td>
					<td>', $red->telefon, '</td>
				</tr>';
		}
		
		echo '</table>';
	?>
	
	
	
	
	</div>
</body>
</html>