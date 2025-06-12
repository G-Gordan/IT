<?php 
$ACCESS_LEVEL = 2;
require_once "../init.php"; ?>
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
	
	
	//ako ima filtera, treba da se nekako dodaju uslovi, tj. WHERE
	if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='pretraga' ){ 
		$ime = $db->real_escape_string($_REQUEST['ime']);
		$prezime = $db->real_escape_string($_REQUEST['prezime']);
		$telefon = $db->real_escape_string($_REQUEST['telefon']);
		$adresa = $db->real_escape_string($_REQUEST['adresa']);
		//if(isset($_REQUEST['zaposlen'])) $zaposlen = 1; else $zaposlen = 0;
		$nivo_obrazovanja_id = $db->real_escape_string($_REQUEST['nivo_obrazovanja_id']);
		
		//generise drugaciji upit - za svaki parametar proverava da li je poslat, ako jeste, na upit dolepi odgovarajuci uslov
		$upit = " SELECT imenik.*, nivo_obrazovanja.naziv 
					FROM imenik 
					LEFT JOIN nivo_obrazovanja ON nivo_obrazovanja.id = imenik.nivo_obrazovanja_id
					WHERE 1";  //1 je ovde da bi popunio mesto i resio problem sa AND u nastavku, a ne menja nista jer je sam po sebi logicki true
			if($ime){
				$upit .= " AND imenik.ime LIKE '%$ime%' ";
			}
			if($prezime){
				$upit .= " AND imenik.prezime LIKE '%$prezime%' ";
			}
			if($telefon){
				$upit .= " AND imenik.telefon LIKE '%$telefon%' ";
			}
			if($adresa){
				$upit .= " AND imenik.adresa LIKE '%$adresa%' ";
			}
			if($nivo_obrazovanja_id){
				$upit .= " AND imenik.nivo_obrazovanja_id = $nivo_obrazovanja_id ";
			}
	}
	else{
		//ako nema filtera, onda sve
		$upit = " SELECT imenik.*, nivo_obrazovanja.naziv 
					FROM imenik 
					LEFT JOIN nivo_obrazovanja  ON nivo_obrazovanja.id = imenik.nivo_obrazovanja_id
				";
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
	<?php include 'modules/user.php' ?>


	<div class="container">
		<?php
			if(isset($status)) echo '<div>',$status,'</div>';
		?>
		<table class="table">
			<thead>
				<tr>
					<form method="get" action="#">
						<input type="hidden" name="akcija" value="pretraga" />
						<th><input type="text" name="ime" /></th>
						<th><input type="text" name="prezime" /></th>
						<th><input type="text" name="telefon" /></th>
					<th>
							<select name="nivo_obrazovanja_id">
								<option></option>
								<?php
									$upit2 = "select * from nivo_obrazovanja";
									$rez2 = $db->query($upit2);
									while( $no = $rez2->fetch_object() ){
									?>
										<option value="<?= $no->id ?>"><?= $no->naziv ?></option>
									<?php	
								} ?>
							</select>
						</th>
						<th><input type="submit" value="Pretrazi" /></th>
					</form>
				</tr>
				<tr>
					<th>Ime</th>
					<th>Prezime</th>
					<th>Telefon</th>
					<th>Nivo obrazovanja</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
				<?php /* prvi nacin, bez join, sa dodatnim upitom za svaki red
					$rez = $db->query( " SELECT * FROM imenik " );
					while(  $red = $rez->fetch_object()  ){
						$upit2 = "select naziv from nivo_obrazovanja where id=".$red->nivo_obrazovanja_id;
						$rez2 = $db->query($upit2);
						$nobr = $rez2->fetch_object();
				?>
					<tr>
						<td><?= $red->ime ?></td>
						<td><?= $red->prezime ?></td>
						<td><?= $red->telefon ?></td>
						<td><?= $red->adresa ?></td>
						<td><?php if($red->zaposlen) echo 'Zaposlen'; else echo 'Nezaposlen'; ?></td>
						<td><?php if($nobr) echo $nobr->naziv ?></td>
						<td>
							<a href="edit.php?id=<?= $red->id ?>" class="btn"><span class="glyphicon glyphicon-pencil"></span></a>
							<a href="javascript:void(0)" 
					onclick=" if(confirm('Potvrdite brisanje')){ window.location.href='list.php?akcija=delete&id=<?= $red->id ?>'; } "
									class="btn"><span class="glyphicon glyphicon-trash"></span></a>
						</td>
					</tr>
				<?php } */ ?>
				
				
				<?php  // 
					$rez = $db->query( $upit );
									
					while(  $red = $rez->fetch_object()  ){
				?>
					<tr>
						<td><?= $red->ime ?></td>
						<td><?= $red->prezime ?></td>
						<td><?= $red->telefon ?></td>
						<td><?php echo $red->naziv ?></td>
						<td>
							<a href="edit.php?id=<?= $red->id ?>" class="btn"><span class="glyphicon glyphicon-pencil"></span></a>
							<a href="javascript:void(0)" 
					onclick=" if(confirm('Potvrdite brisanje')){ window.location.href='list.php?akcija=delete&id=<?= $red->id ?>'; } "
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