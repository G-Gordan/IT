<?php

include_once ("vozilo.php");

 Class Auto extends Vozilo{

	public $travelrs;
	function __construct($tockovi, $brzina, $gorivo, $putnika){
		parent::__construct($tockovi, $brzina, $gorivo);
				$this->travelers=$putnika;
	}
}

?>