<?php

include_once 'sabiranje.php';
include_once 'spajanje.php';
include_once 'velikaslova.php';
include_once 'nizfor.php';

print_r(fsabiranje(3,8));
print('<br>');
print_r(fspajanje("Pera","Perich"));
print('<br>');
print_r(fvelikaslova("mAla Slova ", "I VeLIka SlOvA"));

print('<br>');
print('<hr>');
//$mnniz = [1, 3, 4, 8, 9, 11, 14];
//numniz($mnniz);
//numniz([1, 3, 4, 8, 9, 11, 14]);
numniz(5);
print('<hr>');
$maniz = ['prvi'=>1, 'drugi'=>3, 'treci'=>4, 'cetvrti'=>8, 'peti'=>9, 'sedmi'=>11, 'osmi'=>14];
ascniz($maniz);

?>