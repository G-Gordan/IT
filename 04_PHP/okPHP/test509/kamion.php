<?php

include_once ("vozilo.php");

 Class Kamion extends Vozilo{

	public $load;
	function __construct($tockovi, $brzina, $gorivo, $teret){
		parent:: __construct($tockovi, $brzina, $gorivo);
		$this->load=$teret;
	}
}

?>