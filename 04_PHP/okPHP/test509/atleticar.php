<?php

include_once ("covek.php");

 Class Atleticar extends Covek{
	public $kretanje="trci"; //Overriding
	public function Pokret(){
		echo "krece se brzo po tlu"; //Overriding
	}
}

?>