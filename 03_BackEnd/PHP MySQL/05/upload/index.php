<?php require_once "init.php"; ?>
<?php
	//proverim da li je uopste setovana akcija, tj. da li je forma submit-ovana, i ako jeste, proverim da li je to uopste ta forma
	if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='delete' ){ 
		$id = $_REQUEST['id'];
		
		$upit = " SELECT * FROM imenik WHERE id=$id ";
		$rez = $db->query($upit);
		$red = $rez->fetch_object();
		
		if(!$red) {
			$status = 'Ne postoji takav zapis!';
		} else {
			$status = "Unos ". $red->ime . " " . $red->prezime ." je obrisan!";
			
			$upit = " DELETE FROM imenik WHERE id=$id LIMIT 1 ";
			$db->query($upit);
		}
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
	<div class="container">
		<?php
			if(isset($status)) echo '<div>',$status,'</div>';
		?>
		<table class="table">
			<thead>
				<tr>
					<th>Ime</th>
					<th>Prezime</th>
					<th>Telefon</th>
					<th>Adresa</th>
					<th>Zaposlen</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
				<?php
					$rez = $db->query( " SELECT * FROM imenik " );
					while(  $red = $rez->fetch_object()  ){
				?>
					<tr>
						<td><?= $red->ime ?></td>
						<td><?= $red->prezime ?></td>
						<td><?= $red->telefon ?></td>
						<td><?= $red->adresa ?></td>
						<td><?php if($red->zaposlen) echo 'Zaposlen'; else echo 'Nezaposlen'; ?></td>
						<td>
							<a href="edit.php?id=<?= $red->id ?>" class="btn"><span class="glyphicon glyphicon-pencil"></span></a>
							<a href="javascript:void(0)" 
					onclick=" if(confirm('Potvrdite brisanje')){ window.location.href='index.php?akcija=delete&id=<?= $red->id ?>'; } "
									class="btn"><span class="glyphicon glyphicon-trash"></span></a>
						</td>
					</tr>
				<?php } ?>
			</tbody>
		</table>
		<a href="insert.php" class="btn btn-primary">Dodaj nov</a>
	</div>
</body>
</html>