<?php 
	$_TITLE = 'Utisci';
	include 'modules/head.php'; 
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row">
			<div class="col-sm-12 col-md-9 sadrzaj">
				<h1>Utisci</h1>
				
				<?php
					/*
					$fajl = fopen("data/utisci.txt", "r");
					while(  $red = fgets($fajl)  ){
						//obradim taj $red
						
					}
					fclose($fajl);
					*/
					$redovi = file("data/utisci.txt");
					foreach($redovi as $red){
						//svaki red je oblika datum|ime|utisak
						
						$delovi = explode("|", $red);
						
						$datum = $delovi[0];
						$ime = $delovi[1];
						$utisak = $delovi[2];
						?>
							<div class="utisak">
								<datetime><?= $datum ?></datetime>
								<span class="ime"><?= $ime ?></span>
								<p><?= $utisak ?></p>
							</div>
						<?php
					}
				?>
				<form method="post" action="dodavanje-utiska.php"  role="form">
					<div class="container-fluid kontakt-forma">
						<div class="form-group">
							<label for="ime">
								Ime i prezime
							</label>
							<input type="text" id="ime" name="ime"  class="form-control"  placeholder="Pera Peric" />
						</div>
						<div class="form-group">
							<label for="poruka">
								Poruka
							</label>
							<textarea class="form-control" id="poruka" style="height:183px" name="poruka"></textarea>
						</div>
						<input class="btn btn-default" type="submit" value="Pošalji" />
					</div>
				</form>
			</div>
			<div class="col-sm-12 col-md-3 sidebar">
				<aside>
					<?php include 'modules/specijalna-ponuda.php'; ?>
					<?php include 'modules/last-minute.php'; ?>
					<?php include 'modules/prijava_za_posao.php'; ?>
				</aside>
			</div>
		</div>

<?php include 'modules/footer.php'; ?>
