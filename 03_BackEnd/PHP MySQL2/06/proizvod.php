<?php 
	require_once "dbconnect.php";
	
	//ovom skriptu pristupa se sa proizvod.php?id=4
	$id = $_REQUEST['id'];
	
	$rez = $db->query("select proizvod.*, kategorija.naziv as 'kategorija'
						from proizvod 
						join kategorija on kategorija.id=proizvod.kat_id
						where proizvod.id=".$id  );
	$proizvod = $rez->fetch_object();
	if(!$proizvod){ //ako proizvod ne valja/nema nista/nijedan red nije vracen
		echo '404 - nepostojeca stranica';
		die(); //prekidamo skript, nema sta da prikaze, ovde je kraj izvrsavanja
	}
	//a ako jeste dobro - ide dalje...
	
	
	$_TITLE = $proizvod->naziv;
	include 'modules/head.php'; 
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row sadrzaj_container">
			<div class="col-sm-12 col-md-9 sadrzaj" style="margin-bottom: -999999px; padding-bottom: 999999px;">
					<div class="container-fluid">
						<div class="row">
							<div class="col-xs-12">
								<h1><?= $proizvod->naziv ?></h1>
								<h4>
									<a href="kategorija.php?id=<?= $proizvod->kat_id ?>">
										<?php
											//ovo je nacin bez join-a
											//$rez = $db->query("select * from kategorija 
											//					where id = " .$proizvod->kat_id );
											//$kat = $rez->fetch_object();
											//echo $kat->naziv;
											
											//ovo je sa join-om
											echo $proizvod->kategorija;
										?>
									</a>
								</h4>
							</div>
							<div class="col-xs-12 col-sm-4 col-md-2">
								<img src="<?= $proizvod->slika ?>" alt="<?= $proizvod->naziv ?>"/>
							</div>
							<div class="col-xs-12 col-sm-6 col-md-3">
								<table>
									<tr>
										<td>Puna cena:</td><td><?= $proizvod->cena ?></td>
									</tr>
									<tr>
										<td>Trajanje časova:</td><td><?= $proizvod->trajanje_dana ?></td>
									</tr>
									<tr>
										<td>Trajanje dana:</td><td><?= $proizvod->trajanje_casova ?></td>
									</tr>
									<tr>
										<td>Počinje:</td><td><?= $proizvod->pocinje ?></td>
									</tr>
									<tr>
										<td>Vreme:</td><td><?= $proizvod->vreme ?></td>
									</tr>
								</table>
							</div>
							<div class="col-xs-12 opis-kursa">
								<p>
									<?= $proizvod->kraci_opis ?>
								</p>
								<p>
									<?= $proizvod->pun_opis ?>
								</p>
							</div>
						</div>
					</div>
			</div>
			<div class="col-sm-12 col-md-3 sidebar">
				<aside>
					<?php include 'modules/specijalna-ponuda.php'; ?>
					<?php include 'modules/last-minute.php'; ?>
				</aside>
			</div>
		</div>

<?php include 'modules/footer.php'; ?>
