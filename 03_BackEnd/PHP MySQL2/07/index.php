<?php 
	require_once 'dbconnect.php';

	$_TITLE = 'Pocetna';
	include 'modules/head.php'; 
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row">
			<div class="col-sm-12 col-md-9 sadrzaj">
				<h1>CET ŠKOLA RAČUNARA</h1>
				<iframe width="100%" height="315" src="https://www.youtube.com/embed/BcNgSCjjjlc" frameborder="0" allowfullscreen></iframe>
				
				<?php
				$rez = $db->query(' select id, naslov, kraci_opis 
									from vest 
									order by datum desc 
									limit 3
									');
				while(  $vest = $rez->fetch_object()  ){
					?>
						<article>
							<h3><?= $vest->naslov ?></h3>
							<p>
								<?= $vest->kraci_opis ?>
								<br/><a class="readmore btn btn-info" 
										href="vest.php?id=<?= $vest->id ?>">Opširnije</a>
							</p>
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