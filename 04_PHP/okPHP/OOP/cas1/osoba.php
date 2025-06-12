<?php
class Osoba{
	
public $ime='Marija';	
public $prezime='Maric';
public $godiste='1993';
	
}
///kreiranje objekta -inicijalizacija klase

$osoba=new Osoba();
var_dump($osoba);
$student=new Osoba();echo "<br>";
var_dump($student);echo "<br><br>";

////stampanje vrednosti jednog atributa

echo $osoba->prezime;


?>