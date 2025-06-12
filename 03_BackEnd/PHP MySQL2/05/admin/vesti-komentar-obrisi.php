<?php 
require '../dbconnect.php';

$komentar_id = $_REQUEST['komentar_id'];  //id komentara!
$vest_id = $_REQUEST['vest_id'];  //id vesti, sluzi da znam gde se vracam

$db->query(" delete from komentar where id='$komentar_id' ");

header("Location: vesti-edit.php?id=$vest_id");

?>