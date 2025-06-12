<?php 
require '../dbconnect.php';

$id = $_REQUEST['id'];

$db->query(" delete from vest where id='$id' ");

header("Location: vesti-spisak.php");

?>