<?php
	//$_GET['a']
	//$_POST['a']
	
	$a = $_REQUEST['a'];
	$b = $_REQUEST['b'];
	$c = $_REQUEST['c'];
	
	$zbir = $a + $b + $c;
	$prosek = $zbir / 3;
	
	echo 'Zbir je ' . $zbir;
	echo '<br />';
	echo 'Prosek je ' . $prosek;
?>