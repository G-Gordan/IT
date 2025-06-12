<?php



/*
$c="ava trava glava sprava";
$d=explode(' ',$c);
print('<pre>');
print_r($d);
print('</pre>');
*

/*
$a ="soFijA";
$b = strtoupper($a);
print_r($a);
print('<br>');
print_r($b);
*/


/*$br1 = 9;
$br2 = 3;*/

Function Saberi($a,$b){
	if (is_numeric($a) AND is_numeric($b)){ // AND - &&
		$c = $a + $b;
		return $c;
	} else {
		exit("Varijabla za sabiranje nije broj!");
	}
	
}
/*$sabiranje = Saberi($br1,$br2);
print_r($sabiranje);
print('<br>');*/

Function Oduzmi($a,$b){
	if (!is_numeric($a)){ 					//OR - ||
		exit("Varijabla A nije broj, nego je: ".$a."!");
		if (!is_numeric($b)){
			exit("Varijabla B nije broj, nego je: ".$b."!");
		}
	} elseif ($b>$a) {
		exit("Umanjilac je veci od umanjenika!");
	}
	$c = $a - $b;
	return $c;
}
/*$oduzimanje = Oduzmi($br1,$br2);
print_r($oduzimanje);
print('<br>');*/

Function Pomnozi($a,$b){
	$c = $a * $b;
	return $c;
}
/*$mnozenje = Pomnozi($br1,$br2);
print_r($mnozenje);
print('<br>');*/

Function Podeli($a,$b){
	$c = $a / $b;
	return $c;
}
/*$deljenje = Podeli($br1,$br2);
print_r($deljenje);
print('<br>');*/

Function Total(){
	/*$s = Saberi($br1,$br1);
	$o = Oduzmi($br1,$br2);
	$pm = Pomnozi($br1,$br2);
	$pd = Podeli($br1,$br2);*/
	$s = Saberi(9,3);
	$o = Oduzmi("w",13);
	$pm = Pomnozi(9,3);
	$pd = Podeli(9,3);
	$tot = $s + $o + $pm + $pd;
	return $tot;
}

$prttot = Total();
print_r($prttot);

/*$auta = ["Audi","Fiat","Toyota"];
$laptop = ["Dell","Lenovo","Asus"];
$mobil = ["Samsung","Nokia","Huawei"];
$total2 = array_merge($auta,$laptop,$mobil);
print('<pre>');
print_r($total2);
print('</pre');*/

/*
$total = [$auta,$laptop,$mobil];
print('<pre>');
print_r($total);
print('</pre>');
*/

/*
echo "I like PHP1<br>" ;
//exit;
print ("I like PHP2<br>");
print "I like PHP2B<br>";
print_r("I like PHP3");
//print(PHP_EOL);
print("<br>");
$imeprez = "Gordan" . " " . "Grujic";
echo $imeprez;
print("<br>");
print($imeprez);
*/


/*define ("PHP_EOL", "\r\n");
define ("PHP_EOL", "\n");
print ("I like PHP2");
print(PHP_EOL);
print "I like PHP2B";*/

?>