<?php

require 'Auto.php';

$opel= new Auto("Opel","6500","crna","2000");

$honda= new Auto("Civik","7000","crvena","2007");

$toyota= new Auto("Land Cruser","40000","crna","2017"); 

$mercedes= new Auto("c200","40000","bordo","2017");

$automobili=array($opel,$honda,$toyota,$mercedes);
/// ispis niza pomocu petlje 

//foreach($automobili as $pom){
   //echo $pom."<br>";
//}
///// napisati funkciju koja iz niza vraca najskuplji auto

function najskupljiAuto($automobili){
    //// lazna prepostavka
/// upordjuje svaki objekat prvi sa svakim narednim dok ne utvrdi koji je najskulji
$max=$automobili[0];
///prpostavka da je najskuplji u nizu prvi auto
foreach($automobili as $pom){
    if($pom->getCena()>$max->getCena()){
        $max=$pom;
    }
}
return $max;
}

function najjeftinijiiAuto($automobili){
    //// lazna prepostavka
/// upordjuje svaki objekat prvi sa svakim narednim dok ne utvrdi koji je najskulji
$min=$automobili[0];
///prpostavka da je najskuplji u nizu prvi auto
foreach($automobili as $pom){
    if($pom->getCena()<$min->getCena()){
        $min=$pom;
    }
}
return $min;
}

function prosecnaCenaSvih($automobili){
    $prosek;
    $sumacena=0;
    $brAuta=0;
    //// dajemo prepostavke
    foreach ($automobili as $pom) {
        ///sabiramo sve cene u promenljivu suma cena
        $sumacena+=$pom->getCena();
        $brAuta++;
    }
    $prosek=$sumacena/$brAuta;
    return $prosek;

}
//// funkcija koja na osnovu unetog broja treba da proveri koji su  automili mladji od tog godista


function brojMladjiauto($automobili,$unetogodiste){
    $brojauta=0;

    foreach($automobili as $pom){
        if($pom->getGodiste()>$unetogodiste){
            $brojauta++;
        }
    }


}


///////POZIVI FUNKCIJAAAAAA
echo "Najskuplji auto je ".najskupljiAuto($automobili);
echo "<br><br>";
echo "Najjeftiniji auto je ".najjeftinijiiAuto($automobili);
echo "<br><br>";
echo "Prosecan cena svih automobila je  ".prosecnaCenaSvih($automobili);
echo "<br><br>";
echo "Broja automobil koji su mladji od unetog godista je  ".brojMladjiauto($automobili,"2010");
?>