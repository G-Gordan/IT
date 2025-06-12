<?php

include_once ("atleticar.php");
include_once ("plivac.php");

$a = new Atleticar();
$p = new Plivac();

print_r($a);
print("<br>");
print_r($p->radi1.", ".$p->radi2.", ".$p->radi3) ; //poziva svojstva abstraktne klase
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
print("<br>");

?>