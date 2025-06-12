<?php

Function uvecajkljuc($ukljuc){
	return strtoupper($ukljuc);
}


Function numniz($nniz){
If (is_array($nniz)){
	Foreach ($nniz As $elnniza){
		print_r($elnniza);
		print('<br>');
	}
}else{
	echo "Prosledjena vrednost nije niz!";
	}
}

Function ascniz($aniz){
	Foreach ($aniz As $kljuc=>$elaniza){
		If ($elaniza == 3 || $elaniza == 4 || $elaniza == 11){ 
		print_r(uvecajkljuc($kljuc));
		echo ' broj je: ';
		print_r($elaniza);
		print('<br>');
		}
	}
}



?>