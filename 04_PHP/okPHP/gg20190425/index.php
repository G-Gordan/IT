<?php

include_once('brzivoz.php');

$brzivoz = new Brzi_voz();

$samovoz = $brzivoz->Vozi_putnike();
//$samobrzi = $brzivoz->Brzo_vozi();
$samobrzi = $brzivoz->$radi;
echo $samovoz." ".$samobrzi;


?>