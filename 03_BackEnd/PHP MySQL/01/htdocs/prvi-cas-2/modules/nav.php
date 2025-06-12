<?php
$skript =  $_SERVER['SCRIPT_NAME'];
//echo $skript; //   /prvi-cas-2/index.php

$kosacrtapos = strrpos($skript, '/');
$stranica = substr($skript, $kosacrtapos+1);

?>
	<div class="container-fluid glavni-meni">
		<div class="container">
			<div class="row">
				<div class="col-xs-12">
					<nav>
						<a href="index.php" <?php if($stranica == 'index.php') echo 'class="active"'; ?> >Pocetna</a>
						<a href="ponuda.php" <?php if($stranica == 'ponuda.php') echo 'class="active"'; ?> >Ponuda</a>
						<a href="kontakt.php" <?php if($stranica == 'kontakt.php') echo 'class="active"'; ?> >Kontakt</a>
					</nav>
				</div>
			</div>
		</div>
	</div>