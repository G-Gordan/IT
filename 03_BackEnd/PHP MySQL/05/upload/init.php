<?php
$db = new mysqli('localhost', 'root', '', 'php1');
// Check connection
if ($db->connect_error) {
	die("Greska u konektovanju: " . $db->connect_error);
}
$db->query("set names utf8");
//$db->set_charset('utf8');
?>