<?php

include_once('benzin.php');

class Malotrosi extends Benzin {
	
	public $kubika = 1600;
	public $maxbrzina = 180;

	function __construct() {
		echo "KONSTRUKTOR";
		print("<br>");
	}

	function Sagoreva() {
		return "malo trosi benzina";
	}

}


?>