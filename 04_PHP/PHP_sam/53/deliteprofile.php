<?php
session_start();
include_once 'dbh.php';
$sessionid = $_SESSION['id']; //uzima  broj sesije kao sufiks za ime fajla koji se brise
$filename = "uploads/profile".$sessionid."*"; //zvezdica "*" menja bilo koje znakove u nastavku
$fileinfo = glob($filename);
$fileext = explode(".", $fileinfo[ 0]);
$fileactualext = $fileinfo[ 1];

$file = "uploads/profile".$sessionid.".".$fileactualext;

if(!unlink($file)) {
	echo "File was not deleted!";
} else {
	echo "File is deleted!";
}

$sql = "UPDATE profileimg SET status = 1 WHERE userid='$sessionid';"; 
mysqli_query($conn, $sql);

header=("Location: index.php?deletesiccess");

?>