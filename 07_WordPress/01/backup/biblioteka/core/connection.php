<?php
  $conn = new mysqli("localhost","Bip","Bip123","knjizara");
  
  if($conn->connect_errno){
  
	echo $conn->connect_error;
	die();
  }
  
	else{

		
}
  
  //$conn->query("INSERT INTO opstine (naziv) VALUES('Boljevac')");
  
  
  //echo '<pre>';
  //var_dump ($conn);
  //echo '</pre>';
  
  
  
  
  
  
  
?>