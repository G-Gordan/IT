<?php
	$status = '';
	$validno = true;
	
	if( isset( $_REQUEST['akcija'] ) and $_REQUEST['akcija']=='Dodaj' ){
		//prihvatanje promenljivih
		$i = $_REQUEST['ime'];
		$t = $_REQUEST['tel'];
		
		//validacija
		if( strpos($i, ',')!==false ){
			//greska!
			$status = 'Zapeta nije dozvoljena u imenu osobe! <br/>';
			$validno = false;
		}
		if( strpos($t, ',')!==false ){
			//greska!
			$status = $status . 'Zapeta nije dozvoljena u telefonu! <br/>';
			$validno = false;
		}
		
		//obrada
		if($validno==true){
			$novired = $i . ',' . $t . PHP_EOL;
			file_put_contents("baza.txt", $novired, FILE_APPEND);
		}
		//else - ne moze, nije validno
	}
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Imenik</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
	<h2>Imenik</h2>
	<?php 
		if($validno==false){
			echo '<div>';
			echo $status;
			echo '<hr/></div>';
		}
	?>
	<table class="table">
		<thead>
			<tr><th>Ime</th><th>Broj telefona</th></tr>
		</thead>
		<tbody>
			<?php
				$redovi = file('baza.txt');
				foreach($redovi as $red){
					$delovi = explode(',', $red);
					$ime = $delovi[0]; //ovo je gadjanje napamet
					$tel = $delovi[1];
					echo '<tr><td>' . $ime . '</td><td>' . $tel . '</td></tr>';
				}
			?>
		</tbody>
	</table>
	<form action="index.php" method="post">
		Ime: <input type="text" name="ime" value="<?php
			if($validno == false) echo $i;
		?>" /> <br/>
		Telefon: <input type="text" name="tel" value="<?php
			if($validno == false) echo $t;
		?>" /> <br/> 
		<input type="submit" value="Dodaj" name="akcija" />
	</form>
	
</body>
</html>