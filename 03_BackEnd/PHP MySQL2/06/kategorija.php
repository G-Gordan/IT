<?php
	require_once "dbconnect.php";
	
	$id = $_REQUEST['id'];
	$rez = $db->query('select * from kategorija where id='.$id);
	$kategorija = $rez->fetch_object();
	if(!$kategorija){
		echo '404'; die();
	}
	
	$_TITLE = $kategorija->naziv;
	include 'modules/head.php'; 
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row">
			<div class="col-sm-12 col-md-9 sadrzaj">
				
					<h1><?= $kategorija->naziv ?></h1>
					<p>
						<?= $kategorija->opis ?>
					</p>
					<?php
					
					$rez = $db->query('select id,naziv,kraci_opis,cena,slika 
										from proizvod
										where kat_id = ' . $id );
					while(  $proizvod = $rez->fetch_object()  ){
						?>
							<article>
								<h3><?= $proizvod->naziv ?></h3>
								<div>
									<img src="<?= $proizvod->slika ?>" alt="<?= $proizvod->naziv ?>"/>
									<p><?= $proizvod->kraci_opis ?></p>
									<div class="cena"><?= $proizvod->cena ?>&euro;</div>
									<a href="proizvod.php?id=<?= $proizvod->id ?>">Opsirnije</a>
								</div>
							</article>
						<?php
					}
				?>
				
			</div>
			<div class="col-sm-12 col-md-3 sidebar">
				<aside>
					<?php include 'modules/specijalna-ponuda.php'; ?>
					<?php include 'modules/last-minute.php'; ?>
				</aside>
			</div>
		</div>

<?php include 'modules/footer.php'; ?>