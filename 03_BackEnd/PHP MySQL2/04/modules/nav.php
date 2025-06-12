<?php
	//print_r($_SERVER);
	$trenutna_stranica = basename($_SERVER['SCRIPT_FILENAME']);
?>
<div class="col-sm-12 mainmenu">
	<nav id="mainmenu">
		<ul>
		<!-- class="active" -->
		<?php
			/*
			<li <?php if($trenutna_stranica=='index.php') 
						echo ' class="active" '; ?>><a href="index.php">Početna</a></li>
			<li <?php if($trenutna_stranica=='ponuda.php') 
						echo ' class="active" '; ?>><a href="ponuda.php">Ponuda</a></li>
			<li <?php if($trenutna_stranica=='kontakt.php') 
						echo ' class="active" '; ?>><a href="kontakt.php">Kontakt</a></li>
			<li <?php if($trenutna_stranica=='utisci.php') 
						echo ' class="active" '; ?>><a href="utisci.php">Utisci</a></li>
			*/
			
			$linkovi = file("data/nav.txt");
			foreach($linkovi as $link){
				$delovi = explode("|", $link);
				$skript = $delovi[0];
				$naziv = $delovi[1];
				
				echo '<li ';
				if($trenutna_stranica == $skript){
					echo ' class="active" ';
				}
				echo '><a href="' . $skript . '">' . $naziv . '</a></li>';
			}
		?>
		</ul>
	</nav>
</div>
			