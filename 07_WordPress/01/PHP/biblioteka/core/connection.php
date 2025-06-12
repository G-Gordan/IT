<?php
 $conn = new mysqli("localhost","bib","bib123","knjizara");
 
 if($conn->connect_errno){
	 echo $conn->connect_error;
	 die();
 }else{
	//echo "Uspesna konekcija"; 
 }
 
 //$conn->query("INSERT INTO opstine (naziv) VALUES ('Boljevac')");
 
?>