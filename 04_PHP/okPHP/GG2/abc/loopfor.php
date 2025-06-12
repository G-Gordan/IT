<?php

Function Sabiranje() {
	$zbir=0;
	For ($i=10; $i<51; $i++) {
		$zbir=$zbir+$i;
	}
	print_r("Zbir brojeva od 10 do 50 je: ".$zbir);
}

Function PetMeseci() {
	$meseci=["januar", "februar", "mart", "april", "maj", "jun", "jul", "avgust", "septembar", "oktobar", "novembar", "decembar"];

	$petmes="";
	//$brch1=1;
	echo "Prvih 5 meseci su: ";
	Foreach ($meseci As $key=>$jedmes) {
		$petmes=$petmes.$jedmes;
		If ($key == 4) {
			print_r($petmes);
			exit();
		}
		$petmes=$petmes.", ";
	}
}
Sabiranje();
print('<br>');
PetMeseci();

?>