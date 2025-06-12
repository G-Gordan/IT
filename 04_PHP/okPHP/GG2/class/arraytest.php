<?php


$b=[
[[["AAAA4"], "BBB3"], "BB2"],
"Pera",
"C1",
2345, 
"FIAT",
"F1"];

echo $b[0] [0] [0] [0] ;


//$a=["a1"=>"AAA3", "b1"=>"B1", "c1"=>"C1"];
//$a=["a1"=>["a2"=>"AAA3", "b2"=>"BB2"], "b1"=>"B1", "c1"=>"C1"];
$a=["a1"=>["a2"=>["a3"=>["a4"=>"AAAA4"], "b3"=>"BBB3"], "b2"=>"BB2"], "b1"=>"B1", "c1"=>"C1"];

//print_r($a ["c1"] )  ;

print('<pre>');
print_r($a);
print('</pre>');

//var_dump($a);


?>