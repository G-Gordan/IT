<?php
class Kupiauto {
	function kupovnamoc($godprim, $cenavoz) {
		if ($godprim >= $cenavoz) {
			return "Realna kupovina";
		}else{
			return "Ne realna kupovina";
		}
		
	}
}

?>