<?php

//print('RADI');
//include('funkcije.php');

//$basicniz=['Petar', 'Marko', 'Jovan', 'Nenad', 'Dragan', 'Slavko', 'Mirko', 'Predrag', 'Ivan'];

//novniz();
//slucaj(2);
//slucaj2(1);
//slucaj3(0,5);

/*include_once('man.php');
$test = new Man();
$test->Sing();*/

/*include_once('vozilo.php');
$sporov = new Vozilo();
include_once('trosak.php');
$sporot = new Trosak();

echo "Prosecna potrosnja je: ";
print_r($sporov->potrosnja(350, 25));
echo "<br>";
echo "Vreme putovanja je: ";
print_r($sporov->vremeputa(350, 50));
echo "<br>";

print_r($sporot->kupovnamoc(1000000, 90000));
echo "<br>";
print_r($sporot->odrzavanje(85000, 5000));
*/

include_once('cerka.php');
//include_once('majka.php');
$hrana = new Cerka();
print_r($hrana->pasulj());

?>