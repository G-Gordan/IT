<?php

Function f2f($br) {
	
	If ($br == 5) {

		echo $br;
		
		exit($br);
		die;

	}else{
		$br++;
		return f2f($br);
	}
	
}

f2f(1);

?>