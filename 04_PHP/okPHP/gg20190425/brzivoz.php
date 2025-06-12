<?php

include_once('voz.php');

Class Brzi_voz extends Voz{
public $radi = "BRZO";

	/*public function Brzo_vozi() {
		return "BRZO";
	}*/
echo $this->$radi;

}

//$this->$radi = $this->Brzo_vozi();

?>