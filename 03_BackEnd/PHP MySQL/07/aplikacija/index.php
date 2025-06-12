<?php 
$ACCESS_LEVEL = 0;
require_once "init.php"; ?>
<?php

if(isset($_REQUEST['komentar'])){
	if( $_SESSION['access_level'] > 0 ){
		$komentar = $_REQUEST['komentar'];
		$username = $_SESSION['username'];
		$datum = date("Y-m-d");
		//YYYY-MM-DD HH:II:SS
		$upit = "INSERT INTO komentari (komentar, username, datum) 
					VALUES ('$komentar', '$username', '$datum')";
		$db->query($upit);
	}
	else {
		echo 'Nemas pravo da pises komentare!'; die();
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
<?php include 'user-module.php' ?>
	<div class="container">
		<h1>Imenik v.1.0</h1>
		<table class="table">
			<thead>
				<tr>
					<th>Ime</th>
					<th>Prezime</th>
					<th>Telefon</th>
					<th>Adresa</th>
					<th>Zaposlen</th>
					<th>Nivo obrazovanja</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
				<?php  
				$upit = " SELECT imenik.*, nivo_obrazovanja.naziv 
					FROM imenik 
					LEFT JOIN nivo_obrazovanja  ON nivo_obrazovanja.id = imenik.nivo_obrazovanja_id
				";
					$rez = $db->query( $upit );
									
					while(  $red = $rez->fetch_object()  ){
				?>
					<tr>
						<td><?= $red->ime ?></td>
						<td><?= $red->prezime ?></td>
						<td><?= $red->telefon ?></td>
						<td><?= $red->adresa ?></td>
						<td><?php if($red->zaposlen) echo 'Zaposlen'; else echo 'Nezaposlen'; ?></td>
						<td><?php echo $red->naziv ?></td>
					</tr>
				<?php } ?>
			</tbody>
		</table>
		
		<?php if( $_SESSION['access_level'] > 0 ){ ?>
				<p>
				Ovo je poruka vidljiva samo za registrovanje korisnike
				</p>
				
				<?php
					$upit = 'SELECT * FROM komentari ORDER BY datum DESC';
					$rez = $db->query($upit);
					while( $komentar = $rez->fetch_object() ){
						?>
						<div class="panel panel-default">
							<div class="panel-heading">
								<?php echo $komentar->username ?>
							</div>
							<div class="panel-body">
								<?php echo $komentar->komentar ?>
							</div>
							<div class="panel-footer">
								<?php echo $komentar->datum ?>
							</div>
						</div>
						<?php
					}
				?>
				
				<form method="post" action="index.php">
					Komentar: <input type="text" name="komentar" /> <button>Posalji</button>
				</form>
		
		<?php } ?>
		
	</div>
</body>
</html>