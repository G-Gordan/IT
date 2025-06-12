<?php

$a=[
"nizA1"=>["nizA2"=>["nizA3"=>["valA4"=>"AAAA4"], 
						   			"valB3"=>"BBB3"],
				"valB2"=>"BB2"],
"Pera",
"valC1"=>"C1",
2345, 
"nizBG1"=>["nizBG2"=>["nizBG23"=>["valBG4"=>"BGGGGG"], 
						   				"valBGB3"=>"BBGBGBG3"],
					"valBGG2"=>"BGGBB2"],
"auto"=>"FIAT",
"f1"=>"F1",
"nizG1"=>["nizG2"=>["nizG3"=>["valG4"=>"GGGGG"], 
						   			"valGB3"=>"BGBGBG3"],
					"valGGB2"=>"GGBB2"]];

//print_r($a ["c1"] )  ;
echo "Niz za testiranje:";
print('<pre>');
print_r($a);
print('</pre>');
print('<hr>');
echo "Elementi niza za testiranje:";
print('<br>');
//var_dump($a);

//UBACI TRI RAZLICITE MATRICE I FOR PETLJU DA POZOVE SVE TRI


Function niztest($fniz1){
	$arrstep = 0;
	// - da ispisuje redni broj clana, kog je nivoa matrice i koje mu je ime kljuca
	If  (is_array($fniz1)) {
		// -  ako je ovo matrica da ispisuje redni broj , kog je nivoa matrice i koje mu je ime kljuca, a ako je zadnji po dubini, da ispise njegovu vrednost i  da je varaá na dalje razlaganje po clanovima
		$arrnmbr = count($fniz1); //daje broj elemenata niza
		$arrkys = array_keys($fniz1); //skuplja u niz kljuceve niza
		$arrmbr = array_values($fniz1); //sakuplja u niz elemente niza
				
				//var_dump($fniz);
		foreach ($fniz1 as $kinex1 => $member1) {

			if   (is_array($member1)) {
				$arrstep++;
				// da ponovo poziva istu funkciju i brojac povecava za 1
				
				print_r("KLJUČ: ".$kinex1. " - NIZ: ");

				print('<pre>');
				print_r($member1);
				print('</pre>');
				foreach ($member1 as $kinex2 => $member2) {
				if   (is_array($member2)) {
					print('<pre>');
					print_r($member2);
					print('</pre>');
					}
				}
			}else{
				print_r("KLJUČ: ".$kinex1. " - VREDNOST: ");
				print('<pre>');
				print_r($member1);
				print('</pre>');
			}
		}
	}else{
		$arrstep=0;
	}

}
niztest($a);

?>