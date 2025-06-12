<?php

$matrica = array(array (1,2,3),array (4,5,6), array (7,8,9));
$matrica1 = array(array (1,5,8),array (1,9,8), array (1,3,8), array(3,5,7));

for ($i=0; $i<2; $i++){

}

function matrice($niz, $serija)
{

	for ($i=0; $i<$serija; $i++){
{
	foreach ($niz as $kolona)
{
	foreach ($kolona as $element)
	{
	echo "<pre>";
	var_dump ($element);
	echo "</pre>";
	}

	}
}
}
}

matrice($matrica, 1);
matrice($matrica1, 1);




?>