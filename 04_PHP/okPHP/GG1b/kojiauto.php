<?php

include_once('audi.php');
include_once('citroen.php');
include_once('fiat.php');

$auto1 = new Audi();
$auto2 = new Citroen();
$auto3 = new Fiat();
$r=rand(1, 3);
$auto = "auto".$r;
echo $auto;
echo "<br>";

If (get_class($auto)="auto1") {
	echo "auto je Audi";
}elseif (get_class($auto)="auto2") {
	echo "auto je Citroen";
}elseif (get_class($auto)="auto3") {
	echo "auto je Fiat";
}


?>