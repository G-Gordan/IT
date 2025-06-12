<?php require_once "init.php"; ?>
<?php
	//proverim da li je uopste setovana akcija, tj. da li je forma submit-ovana, i ako jeste, proverim da li je to uopste ta forma
	if( isset($_POST['akcija']) and $_POST['akcija']=='update' ){ 
		$id = intval( $_POST['id'] );
		$ime = $db->real_escape_string($_POST['ime']);
		$prezime = $db->real_escape_string($_POST['prezime']);
		$telefon = $db->real_escape_string($_POST['telefon']);
		$adresa = $db->real_escape_string( nl2br($_POST['adresa']) );
		$pol = $db->real_escape_string( $_POST['pol'] ); //radio
		$nivo_obrazovanja_id = $db->real_escape_string( $_POST['nivo_obrazovanja_id'] ); //radio
		$zaposlen = isset( $_POST['zaposlen'] );
		
		//validacija
		//unos u bazu
		$upit = "UPDATE imenik SET ime='$ime', 
						prezime='$prezime', 
						telefon='$telefon', adresa='$adresa', 
						zaposlen = '$zaposlen',
						nivo_obrazovanja_id = '$nivo_obrazovanja_id',
						pol = '$pol'
					WHERE id=$id";
		$db->query($upit);
		if( isset($_FILES['slika'])  ){
			$validacija = true;
			//da li je odgovarajuceg tipa
			$ekstenzija = pathinfo($_FILES['slika']['name'],PATHINFO_EXTENSION);
			if($ekstenzija != "jpg" && $ekstenzija != "png" && $ekstenzija != "jpeg" && $ekstenzija != "gif" ) {
				echo "Sorry, only JPG, JPEG, PNG & GIF files are allowed.";
				$validacija = false;
			}
			//da li je odgovarajuce velicine u MB
			if ($_FILES["slika"]["size"] > 1000000) {
				echo "Sorry, your file is too large.";
				$validacija = false;
			}
			$odrediste = 'slike/' . time() . $_FILES['slika']['name'];
			//konacno proverim da li mozda vec postoji takav fajl
			if (file_exists($odrediste)) {
				echo "Sorry, file already exists.";
				$validacija = false;
				//ili dodam broj 2 na kraj, ili dodam trenutno vreme ili ...
				
			}
			//ako sve u redu, prebacujem fajl
			if($validacija){
				move_uploaded_file($_FILES["slika"]["tmp_name"], $odrediste);
				//kopirao fajl, sada treba da ih nekako povezem
				//prvo obrisem postojecu
				$upit = "SELECT slika FROM imenik WHERE id=$id";
				$rez = $db->query($upit);
				$red = $rez->fetch_object();
				$zabrisanje = $red->slika;
				unlink($zabrisanje);
				//pa zapisem putanju do nove
				$upit = "UPDATE imenik SET slika='$odrediste' WHERE id=$id";
				$db->query($upit);
			}
		}
		//unos je sacuvan, prebaci na spisak (a i ne mora, moze da ostane ovde)
		//header("Location: index.php"); die();
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
  
  <script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
  <script>tinymce.init({ selector:'textarea' });</script>
</head>
<body>
	<div class="container">
		<form method="post" action="edit.php" enctype="multipart/form-data">
			<input type="hidden" name="akcija" value="update" />
			<input type="hidden" name="id" value="<?= $red->id ?>" />
			Ime: <input type="text" name="ime" value="<?= $red->ime ?>" /> <br/>
			Prezime: <input type="text" name="prezime" value="<?= $red->prezime ?>" /> <br/>
			Telefon: <input type="text" name="telefon" value="<?= $red->telefon ?>" /> <br/>
			Slika: <input type="file" name="slika" /> <br />
			<img src="<?= $red->slika ?>" /> <br /> 
			Adresa:<br/>
			<textarea name="adresa"><?= $red->adresa ?></textarea>
			<br/>
			<input type="checkbox" name="zaposlen" <?php if($red->zaposlen) echo 'checked'; ?> /> Zaposlen <br/>
			<br/>
			Pol:
			<input type="radio" name="pol" value="m" <?php if($red->pol=='m') echo 'checked'; ?> /> M
			<input type="radio" name="pol" value="z" <?php if($red->pol=='z') echo 'checked'; ?> /> Z
			<br/>
			Nivo obrazovanja
			<select name="nivo_obrazovanja_id">
				<?php
					$upit = "select * from nivo_obrazovanja";
					$rez = $db->query($upit);
					while( $no = $rez->fetch_object() ){
					?>
						<option <?php if($red->nivo_obrazovanja_id==$no->id) echo 'selected'; ?> value="<?= $no->id ?>"><?= $no->naziv ?></option>
					<?php	
				} ?>
				
				
			</select><br/>
			
			<br/><br/>
			<input type="submit" value="Sacuvaj promene" />
		</form>
	</div>
</body>
</html>