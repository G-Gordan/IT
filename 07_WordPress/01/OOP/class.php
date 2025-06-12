<?php

class Zaposleni
{
	//polja ili osobine
	public $ime = "milos";
	public $titula;
	private $plata = 26000;
	public $prijava;
	public $odjava;
	
	public $jmbg;
	
	public function __construct($jmbg,$ime)
	{
		$this->jmbg = $jmbg;
		$this->ime = $ime;
		
	}
	
	public function getPlata()
	{
		return $this->plata;
	}
	
	public function setPlata($plata)
	{
		$this->plata = $plata;
	}
	
	
	
	//Funkcija ili metoda
	
	public function prijava()
	{
		$this->prijava = date("h:i:s");
	}
	public function odjava()

	{
		$this->odjava = date("h:i:s");
	}
	
	
	
	
}

$z1 = new zaposleni(123498394589345898, "Marina");	
$z1->ime='uzahir';
If(isset($_POST['prijava']))
{
	var_dump("kliknuto");
	$z1->prijava();
}
else if(isset($_POST['odjava']))
{
	$z1->odjava();
}
$z1->prijava();
echo $z1->prijava;

echo $z1->ime;

$z2 = new zaposleni();
$z2->ime='marina';

echo $z2->ime;

$z3 = new zaposleni();
echo $z3->ime;

$z1->setPlata(56000);
echo $z1->getPlata();

echo $z->jmbg;



?>

<form method="POST" action="">
<input type="submit" name="prijava" value="prijava"/>
<input type="submit" name="odjava" value="odjava"/>



</form>