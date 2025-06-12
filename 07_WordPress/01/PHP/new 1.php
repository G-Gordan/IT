<?php

$matrica = array();
$niz1 = array (1,2,3);
$niz2 = array (4,5,6);
$niz3 = array (7,8,9);
$matrica [0] = $niz1;
$matrica [1] = $niz2;
$matrica [2] = $niz3;

for ($i=0; $i<2; $i++)
{
	
	for($j=0; $j<3; $j++){
	echo "<pre>";
	var_dump($matrica[$i] [$j]);	
	echo "</pre>";
	}
	
}

foreach ($matrica as $kolona)
{
	echo "<pre>";
	{foreach ($kolona as $element)
	var_dump ($element);}
	echo "</pre>";
}

function obrada_matrice($a, $b)
{
	
	$zbir = $a+$b;
	
	return $zbir;
}

$rez = obrada_matrice(123,56);
$rez1 = obrada_matrice (121,6);

var_dump ($rez1);



?>