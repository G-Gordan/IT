<?php
	$predlozi = [
		'beograd',
		'beocin',
		'baric',
		'novi sad',
		'nis',
		'smederevo',
		'krusevac'
	];
	
	
//	print_r($_REQUEST);
	
	$upisano = $_REQUEST['pretraga'];
	
	$rezultat = [];
	
	foreach( $predlozi as $predlog ){
		//ako $upisano se nalazi u $predlog, i to na pocetku, tj. na mestu 0
		if( strpos($predlog, $upisano)===0 ){
			//to se prihvata kao rezultat
			$rezultat[] = $predlog; //dodaj u niz, na kraj
		}
	}
	
	// print_r( $rezultat );  //nije preterano koirsno, ali eto, radi...
	/*  za ovo moram da rucno cepam podatke, tako sto javascript poziva .split()
	$tekstualni_prikaz = '';
	foreach($rezultat as $r){
		$tekstualni_prikaz .= $r . ',';
	}
	
	$tekstualni_prikaz = trim($tekstualni_prikaz, ',');
	
	echo $tekstualni_prikaz;
	*/
	
	$json_zapis = json_encode($rezultat); //sta god da je ovde, json ce da se snadje...
	echo $json_zapis;
	
	
?>