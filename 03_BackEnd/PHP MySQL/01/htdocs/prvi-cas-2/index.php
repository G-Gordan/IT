<?php $TITLE = 'Dobrodosli'; ?>
<?php require "modules/head.php" ?>
<?php require "modules/header.php" ?>
<?php require "modules/nav.php" ?>
	<div class="container" style="background-color:white">
		<div class="row">
			<div class="col-md-9 col-sm-8 col-xs-12 glavni-sadrzaj">
				<main>
					<header>
						<h1>CET ŠKOLA RAČUNARA</h1>
					</header>
					<section>
						<iframe width="100%" height="315" src="https://www.youtube.com/embed/BcNgSCjjjlc" frameborder="0" allowfullscreen></iframe>
					</section>
					<section>
						<?php
							//ucitam fajl, kao niz redova - jedan red=jedan string=jedan element niza
							//for petljom prodjem kroz sve redove
								//svaki red pocepam na mestu |
									//prvi deo je naslov, drugi deo je tekst
							
							$redovi = file('data/novosti.txt');
							/*
							for($i=0; $i<sizeof($redovi); $i++){
								$red = $redovi[$i];
								
								$delovi = explode('|', $red);
								
								$naslov = $delovi[0];
								$tekst = $delovi[1];
								
							}
							*/
							foreach( $redovi as $red ){
								
								$delovi = explode('|', $red);
								
								$naslov = $delovi[0];
								$tekst = $delovi[1];
								?>
								<article>
									<h2><?= $naslov ?></h2>
									<p><?= $tekst ?></p>
								</article>
								<?php
							}
						?>	
					</section>
				</main>
			</div>
			<div class="col-md-3 col-sm-4 col-xs-12">
				<aside>
					<?php require "modules/specijalna-ponuda.php" ?>
					<?php require "modules/last-minute.php" ?>
				</aside>
			</div>
		</div>
	</div>
<?php require "modules/footer.php" ?>