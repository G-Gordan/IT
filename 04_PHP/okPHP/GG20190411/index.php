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

include_once('vozilo.php');
$auto = new Vozilo();
//include_once('trosak.php');
//$sporot = new Trosak();

print_r($auto->kupovnamoc(1000000, 90000));
echo "<br>";
print_r($auto->odrzavanje(85000, 5000));
echo "<br>";
echo "Prosecna potrosnja goriva na 350km je: ";
print_r($auto->potrosnja(350, 25));
echo "<br>";
echo "Vreme putovanja na 350 km je: ";
print_r($auto->vremeputa(350, 50));




/*include_once('cerka.php');
//include_once('majka.php');
$hrana = new Cerka();
print_r($hrana->pasulj());
*/

?>