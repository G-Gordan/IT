<?php

session_start();

if(!isset($ACCESS_LEVEL)){ echo 'Nevazeca podesavanja skripta'; die(); }

if($_SESSION['access_level'] < $ACCESS_LEVEL){
	header("Location: login.php?poruka=pristup_zabranjen"); die();
}


$db = new mysqli('localhost', 'root', '', 'php1');
// Check connection
if ($db->connect_error) {
	die("Greska u konektovanju: " . $db->connect_error);
}
$db->query("set names utf8");
//$db->set_charset('utf8');
?>