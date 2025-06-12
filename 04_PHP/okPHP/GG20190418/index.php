<?php

//vezba: Overriding

//include_once('benzin.php');
//include_once('dizel.php');
//include_once('gas.php');
include_once('malotrosi.php');

$mtb = new Malotrosi();
echo $mtb->Sagoreva();
print("<br>");
print_r($mtb);
print("<br>");
//print_r($mtb->kubika);
echo $mtb->kubika;


?>