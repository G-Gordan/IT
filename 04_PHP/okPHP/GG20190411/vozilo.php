<?php

include_once('trosak.php');

class Vozilo extends Trosak {
	function potrosnja($km, $lit) {
		return $km/$lit;
	}

	function vremeputa($km, $prbrz) {
		return $km/$prbrz;
	}
}


?>