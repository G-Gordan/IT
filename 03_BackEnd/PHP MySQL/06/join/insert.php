<?php require_once "init.php"; ?>
<?php
	//proverim da li je uopste setovana akcija, tj. da li je forma submit-ovana, i ako jeste, proverim da li je to uopste ta forma
	if( isset($_POST['akcija']) and $_POST['akcija']=='insert' ){ 
		$ime = $_POST['ime'];
		$prezime = $_POST['prezime'];
		$telefon = $_POST['telefon'];
		
		//validacija
		
		//unos u bazu
		$upit = "INSERT INTO imenik (ime, prezime, telefon) VALUES ('$ime', '$prezime', '$telefon') ";
		$db->query($upit);
		$novid = $db->insert_id;
		//unos je dodat, prebaci na spisak
		header("Location: index.php");
		die();
	}
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Imenik - nov zapis</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
	<div class="container">
		<form method="post" action="insert.php">
			<input type="hidden" name="akcija" value="insert" />
			Ime: <input type="text" name="ime" value="" /> <br/>
			Prezime: <input type="text" name="prezime" value="" /> <br/>
			Telefon: <input type="text" name="telefon" value="" /> <br/>
			<input type="submit" value="Napravi nov zapis" />
		</form>
	</div>
</body>
</html>