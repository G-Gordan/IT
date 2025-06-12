<?php
//Program sadrži funkciju koja ispituje ulaznu varijablu i elemente niza, iako je u pitanju multidimenzionalni niz, bez obzira na broj nivoa
// 1. Prihvata ulazne varijable bilo kog tipa i ispituje ih 
// 2. ispisuje ime ključa i vrednosti
// 3. ako je element ulaznog niza ugnježdeni niz, razlaže ga i ispisuje bez obzira koliko nivoa ugnježdenja ima

//NIZ za testiranje:
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

echo "Niz za testiranje:";
print('<pre>');
print_r($a);
print('</pre>');
print('<hr>');
echo "Elementi niza za testiranje:";
print('<br>');

Function niztest($fniz1){
		
	If  (is_array($fniz1)) {
			foreach ($fniz1 as $kinex1 => $member1) {
			if   (is_array($member1)) {
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
	}
}
niztest($a);

?>