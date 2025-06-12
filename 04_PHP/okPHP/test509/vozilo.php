<?php

abstract Class Vozilo{
	public $wheels;
	public $speed;
	public $fuel;
	public function __construct($tockovi, $brzina, $gorivo){
		$this->wheels=$tockovi;
		$this->speed=$brzina;
		$this->fuel=$gorivo;
	}
}

?>