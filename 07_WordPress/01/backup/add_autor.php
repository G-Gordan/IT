<?php require('core/connection.php');?>
<?php include('blocs/header.php');?>
<?php
	if(isset($_POST['dodaj_autora']))
	{	
		$autor=$_POST["ime_prezime"];
		$conn->query("INSERT INTO autor (ime_prezime)VALUES('$autor')"); 
		
		
	}		

?>


<form method="POST" action="">
	
	<div>
		<label for="autor">Autor Knjige</label>
		<input type="text" name="ime_prezime" id='ime_prezime'/>
	</div>
	
	<input type="submit" name="dodaj_autora" value="dodaj_autora" />

</form>