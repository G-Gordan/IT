<!DOCTYPE html>
<html lang="en">
<head>
  <title>Nizovi</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
	<h2>Nizovi</h2>
	<pre>
	<?php
	$niz = array();
	$niz = [];
	/*
	$niz = ['prvi' , 'drugi' , 'treci'];
	$niz = [
				14=>'prvi' , 
				15=>'drugi' , 
				0=>'treci'
			];
	
	$niz = [
				'ime'=>'Petar',
				'prezime'=>'Prvulovic',
				'prosek_ocena'=>[ 4.5, 4.77, 5.0, 3.66 ]
			];
	
	$treci_razred = $niz['prosek_ocena'][2];
	
	$objekat = new stdClass();
		$objekat->ime = 'Petar';
		$objekat->prezime = 'Prvulovic';
	
	echo $niz['ime'];
	echo $objekat->ime;
	*/
	$niz[0] = 'prvi element';
	$niz[1] = 'drugi element';
	$niz[2] = $niz[1] . ' i dodatak...';
	
	
	
	
	/*
	$i = 0;
	while( $i < count($niz) ){
		
		echo $niz[ $i ];
		echo ', ';
		
		$i++;
	}
	
	for($i=0; $i<count($niz); $i++){
		echo $niz[ $i ];
		echo ', ';
	}
	*/
	
	$niz[5] = 'poslednji';
	
	$niz['cetvrti element'] = 4;
	
	$niz[] = 'ovo je poslednji element';
	
	foreach($niz as $vrednost){
		echo $vrednost;
		echo ', ';
	}
	
	foreach($niz as $indeks=>$vrednost){
		echo $vrednost;
		//ili ovako..
		echo $niz[$indeks];
		
		echo ', ';
	}
	
	
	echo count($niz);
	print_r($niz);
	
	
	
	
	
	/*
	var_dump($niz);
	
	echo json_encode($niz);
	echo PHP_EOL;
	
	$a = 12;
	echo json_encode($a);
	echo PHP_EOL;
	
	$obj = new stdClass();
	$obj->ime = 'Petar';
	$obj->prezime = 'Prvulovic';
	echo PHP_EOL;
	echo json_encode($obj);
	*/
	
	$tekst = 'Abc,Def,GHI';
	$delovi = explode(',', $tekst);
	print_r($delovi);
	
	echo PHP_EOL;
	
	$delovi = array_reverse($delovi);
	$novitekst = implode('-', $delovi);
	print_r($novitekst);
	
	
	
	?>
	</pre>
</body>
</html>