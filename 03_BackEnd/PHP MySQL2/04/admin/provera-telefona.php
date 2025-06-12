<?php
	$zapisi = file('../data/imenik.txt');
	foreach($zapisi as $zapis){
		$delovi = explode('|', $zapis);
		$tel = trim($delovi[1]);

		if($tel==$_REQUEST['telefon']){
			echo 'ZAUZET';
			die();
		}
	}

	echo 'SLOBODAN';
?>