<?php


include_once ("stat.php");
echo Stat::conprop;
print("<br>");
echo Stat::$statprop;
Stat::statmet();


/*
include_once ("statb.php");
include_once ("statc.php");

$sb = new StatB();
$sc = new StatC();
$sb->statprop = "PROMENA";
echo $sc->statprop;
*/

/*
include_once ("auto.php");
include_once ("kamion.php");

$a = new Auto(4,200,"benzin",4);
$k = new Kamion(6,120,"dizel","kiper");

print_r($a);
print("<br>");
print_r($k);
print("<br>");
*/


/*
include_once ("b.php");
$b = new B();
echo $b->a;
*/


/*print_r($p->radi1.", ".$p->radi2.", ".$p->radi3) ; //poziva svojstva abstraktne klase
print("<br>");echo $a->kretanje;
print("<br>");
$a->Pokret();
print("<br>");
print("<br>");
print_r($p);
print("<br>");
print_r($p->radi1.", ".$p->radi2.", ".$p->radi3) ; //poziva svojstva abstraktne klase
print("<br>");
echo $p->kretanje;
print("<br>");
$p->Pokret();
print("<br>");*/

?>