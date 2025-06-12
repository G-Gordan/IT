<?php 
	require_once "dbconnect.php";
	
	//ovom skriptu pristupa se sa vest.php?id=4
	
	//id takodje mora da se ocisti jer korisnik moze da ga menja
	$id = $db->real_escape_string( $_REQUEST['id'] );
	//$upit = "select * from vest where id='$id' ";
	//drugi nacin   12; drop table
	$id = intval( $_REQUEST['id'] );
	$upit = "select * from vest where id=$id ";
	
	$rez = $db->query($upit);
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
							<h4>Komentari</h4>
							<?php 
								//unos novog komentara ako je poslat
								if(isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='dodaj_komentar' ){
									$ime = $db->real_escape_string( strip_tags( $_REQUEST['ime'] ) );
									$sadrzaj = $db->real_escape_string( nl2br( strip_tags( $_REQUEST['sadrzaj'] ) ) );
									//provera validnosti unetog
									//ime najmanje 3 slova najvise 50
									//sadrzaj najmanje 5 slova, najvise 500
									$validno = true;
									$status_msg = '';
									if( strlen($ime)<3 or strlen($ime)>50 ){
										$validno = false;
										$status_msg .= '<p>Ime mora biti izmedju 3 i 50 slova</p>';
									}
									if( strlen($sadrzaj)<5 or strlen($sadrzaj)>500 ){
										$validno = false;
										$status_msg .= '<p>Komentar mora biti izmedju 5 i 500 slova</p>';
									}
									//ok, proverio sam, sad ako je sve u redu vrsim upit, ako nije - nista
									if($validno){
										$datum = date("Y-m-d H:i:s");
										$upit = " INSERT INTO komentar (autor, datum, sadrzaj, vest_id)
													VALUES ('$ime', '$datum', '$sadrzaj', '$id') ";
										$db->query($upit);
										echo $upit;
									}
									else{
										echo $status_msg;
									}
								}
								
								
								$upit = "SELECT * FROM komentar 
											WHERE vest_id = '$id' ";
								$rez = $db->query($upit);
								while( $komentar = $rez->fetch_object() ){
									?>
									
									<div class="komentar">
										<datetime><?= $komentar->datum ?></datetime>
										<span class="autor" style="font-weight:bold"><?= $komentar->autor ?></span>
										<p><?= $komentar->sadrzaj ?></p>
									</div>
									
									<?php
								}
							?>
							<hr />
							<form method="post" action="vest.php">
								<input type="hidden" name="akcija" value="dodaj_komentar" />
								<input type="hidden" name="id" value="<?php echo $id ?>" />
								Ime <br /><input type="text" name="ime" /> <br />
								Komentar <br /><textarea name="sadrzaj"></textarea> <br />
								<input type="submit" value="Posalji komentar" />
							</form>
						</div>
					</div>
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
