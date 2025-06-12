<?php
	//print_r($_SERVER);
	$trenutna_stranica = basename($_SERVER['SCRIPT_FILENAME']);
?>
<div class="col-sm-12 mainmenu">
	<nav id="mainmenu">
		<ul>
		<!-- class="active" -->
			<li <?php if($trenutna_stranica=='index.php') 
						echo ' class="active" '; ?>><a href="index.php">Početna</a></li>
			<li <?php if($trenutna_stranica=='ponuda.php') 
						echo ' class="active" '; ?>><a href="ponuda.php">Ponuda</a>
				<ul>
					<li <?php if($trenutna_stranica=='web-developer.php') 
						echo ' class="active" '; ?>><a href="web-developer.php">Web developer</a>
				</ul>
			</li>
			<li <?php if($trenutna_stranica=='kontakt.php') 
						echo ' class="active" '; ?>><a href="kontakt.php">Kontakt</a></li>
		</ul>
	</nav>
</div>
			