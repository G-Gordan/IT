<?php

include_once('kupiauto.php');

class Trosak extends Kupiauto {
	function odrzavanje($mesprim, $mesodrz) {
		if (0.05*$mesprim >= $mesodrz) {
			return "Realno odrzavanje";
		}else{
			return "Ne realno odrzavanje";
		}
	}
}


?>