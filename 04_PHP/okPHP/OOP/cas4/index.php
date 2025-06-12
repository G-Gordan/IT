<?php

require 'Auto.php';

$opel= new Auto("Opel","6500","crna","2000");

echo "<br><br>";

$toyota=new Auto("Land Cruser","40000","crna","2017"); 
//echo $opel;
echo $toyota;
echo "<br><br>";
echo "Cena vozila je ".$opel->promeniCenu();
echo "<br><br>";
///echo $opel;
$opel->promeniBoju("zuta");
echo $opel;


?>