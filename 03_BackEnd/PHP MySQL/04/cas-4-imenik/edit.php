<?php require_once "init.php"; ?>
<?php
	//proverim da li je uopste setovana akcija, tj. da li je forma submit-ovana, i ako jeste, proverim da li je to uopste ta forma
	if( isset($_POST['akcija']) and $_POST['akcija']=='update' ){ 
		$id = $_POST['id'];
		$ime = $_POST['ime'];
		$prezime = $_POST['prezime'];
		$telefon = $_POST['telefon'];
		//validacija
		//unos u bazu
		$upit = "UPDATE imenik SET ime='$ime', prezime='$prezime', telefon='$telefon' WHERE id=$id";
		$db->query($upit);
		//unos je sacuvan, prebaci na spisak (a i ne mora, moze da ostane ovde)
		header("Location: index.php"); die();
	}
	$id = $_REQUEST['id'];
	$upit = "SELECT * FROM imenik WHERE id=$id";
	$rez = $db->query($upit);
	$red = $rez->fetch_object();
	if(!$red) { echo 'Ne postoji ovaj zapis!'; die(); }
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Imenik - izmena zapisa</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
	<div class="container">
		<form method="post" action="edit.php">
			<input type="hidden" name="akcija" value="update" />
			<input type="hidden" name="id" value="<?= $red->id ?>" />
			Ime: <input type="text" name="ime" value="<?= $red->ime ?>" /> <br/>
			Prezime: <input type="text" name="prezime" value="<?= $red->prezime ?>" /> <br/>
			Telefon: <input type="text" name="telefon" value="<?= $red->telefon ?>" /> <br/>
			<input type="submit" value="Sacuvaj promene" />
		</form>
	</div>
</body>
</html>