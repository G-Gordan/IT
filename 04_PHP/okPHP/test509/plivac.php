<?php

include_once ("covek.php");

 class Plivac extends Covek{
	public $kretanje="pliva"; //Overriding
	public function Pokret(){
		echo "krece se brzo u vodi"; //Overriding
	}
}

?>