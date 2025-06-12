<?php 
require '../dbconnect.php';

$id = $_REQUEST['id'];

$db->query(" delete from proizvod where id='$id' ");

header("Location: proizvodi-spisak.php");

?>