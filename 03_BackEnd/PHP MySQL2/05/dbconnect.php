<?php
$db = new mysqli('localhost', 'root', '', 'sajt2');
if ($db->connect_errno) {
	echo "Error: " . $db->connect_error;
	die();
}
$db->query('set names utf8');
?>