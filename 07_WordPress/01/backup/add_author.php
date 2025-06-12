<?php include('blocs/header.php');?>

<?php 
	if(isset($_POST['dodaj_autora']))
	{
		
		$autor = $_POST['ime_prezime'];
		//$pisac = $_POST['autor'];
		//$isbn = $_POST['isbn'];
		
		//var_dump($_POST);
		$conn->query("INSERT INTO autor (ime_prezime)VALUES('$autor')");
		var_dump($conn);
		
	}



?>
<form method="POST" action="">
	<div>
		<label for="naziv">Naziv</label>
		<input type="text" name="ime_prezime" id="naziv" />
	</div>
	
	<button type="submit" name="dodaj_autora">Dodaj knjigu</button>
</form>


