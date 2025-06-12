<?php 
	$_TITLE = 'Ponuda';
	include 'modules/head.php'; 
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row">
			<div class="col-sm-12 col-md-9 sadrzaj">
				<h1>PONUDA</h1>
				
				<?php
					require_once "dbconnect.php";
					
					$rez = $db->query('select * from kategorija');
					while(  $kategorija = $rez->fetch_object()  ){
						?>
							<article>
								<h3>
									<a href="kategorija.php?id=<?= $kategorija->id ?>">
										<?= $kategorija->naziv ?>
									</a>
								</h3>
								<div>
									<p><?= $kategorija->opis ?></p>
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
					<?php include 'modules/prijava_za_posao.php'; ?>
				</aside>
			</div>
		</div>

<?php include 'modules/footer.php'; ?>