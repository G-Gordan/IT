<?php  

/*$x = 1;
 while($x <= 5) {
  echo "Broj: $x <br>";
  $x++;
} */

/*$x = 6;
//$x =1;
do {
    echo "Broj: $x <br>";
    $x++;
} while ($x <= 5);
*/

/*$br =1;
$w ="";
while($br <= 5) {
 //$w = $w."A";
 if($br%2==0){
  		$w .="A";
  }else{
  	  	$w .="a";
  		  }
        $br++;
 	} 
echo $w;
echo "<br>";
echo $br;
*/

/*$br =3;
$w =NULL;
while (strlen($w)<5) {
 if($br%2==0){
        $w .="A";
          }else{
        $w .="a";
         }
        $br++;
  } 
echo $w;
echo strlen($w);
echo $br;
*/

/*$br =5;
$a=[];
 while($br <= 9) {
array_push($a, $br);
$br++;
 } 
print_r($a);
*/

/*$br=1;
$a=[];
 while(count($a) <=5) {
// na 5 članova prođe i tada doda 6-ti član niza
array_push($a, $br);
echo count($a);
echo "<br>";
$br++;
 } 
print_r($a);
*/

/*
$dani = array("Pon", "Uto", "Sre", "Cet", "Pet", "Sub", "Ned");
echo count($dani);
echo "<br>";
echo sizeof($dani);
*/

/*$arr =["jabuka", "banana", "kajsija", "limun"];
$i = 0;
while ($i < count($arr)) {
   $a = $arr[$i];
   echo $a ."\n";
   $i++;
}
echo "<br>";
// or
$i = 0;
$c = count($arr);
while ($i < $c) {
   $a = $arr[$i];
   echo $a ."\n";
   $i++;
}*/

/*$zivotinje = ['zec', 'srna', 'konj', 'prase','ovca','fazan','krokodil'];
$i = 0;
while ($i < count($zivotinje))
{
    echo "<li>$zivotinje[$i]</li>";
    //echo $i;
    $i++;
}*/

/*$br =1;
$bl =FALSE;
while($bl== FALSE) {
    if($br==5){
      $bl =TRUE;
    }
    $br++;
  } 
echo $br;
echo $bl;
*/

/*$boje = ["bela", "plava", "zelena", "braon"]; 
foreach ($boje as $key=>$value) {
    echo "{$key} - {$value} <br>";
}*/

/*for($i=1; $i<=1000; $i+=$i){
	echo "Broj: $i <br>";
}*/


//for($i=0; $i<=5; $i++) {
// ako hoémo da imamo 2 reda sa 5 zvezdica
for($i=0; $i<5; $i++) {
  for($j=0; $j<$i; $j++) {
    echo "*";
  }
  echo "<br>";
}
for($i=5; $i>0; $i--) {
  for($j=0; $j<$i; $j++) {
    echo "*";
  }
  echo "<br>";
}

?>  