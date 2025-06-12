<?php 
	require_once "dbconnect.php";
	
	//ovom skriptu pristupa se sa vest.php?id=4
	$id = $_REQUEST['id'];
	
	$rez = $db->query('select * from vest where id='.$id  );
	$vest = $rez->fetch_object();
	if(!$vest){
		echo '404 - nepostojeca stranica';
		die(); //prekidamo skript, nema sta da prikaze, ovde je kraj izvrsavanja
	}
	//a ako jeste dobro - ide dalje...
	
	
	$_TITLE = $vest->naslov;
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
								<h1><?= $vest->naslov ?></h1>
							</div>
							<div class="col-xs-12 opis-kursa">
								<p>
									<?= $vest->kraci_opis ?>
								</p>
								<p>
									<?= $vest->pun_opis ?>
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
