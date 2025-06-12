<?php require('core/connection.php'); ?>

<?php
	if(isset($_POST['dodaj_knjigu']))
	{	
		$naziv = $_POST('naziv');
		$autor = $_POST ('autor');
		$isbn  = $_POST ('isbn');
		var_dump ($_POST);
		$conn->query("INSERT_INTO Knjige (naziv_knjige,id_autor,ISBN)VALUES('$naziv','$pisac','$isbn')"); 
		var_dump ($conn);
		
	}		

?>


<form method="POST" action="">
	<div>
		<label for="naziv">Naziv</label>
		<input type="text" name=naziv" id="naziv" />
	</div>
	<div>
		<label for="autor">Autor Knjige</label>
		<select name="autor" id="autor">
			<option value="1" >Ivo Andric</option>
			<option value="2" >Mesa Selimovic</option>
			<option value="3" >Dobrica Cosic</option>
		</select>
	</div>
	<div>
		<label for="isbn">ISBN<label/>
		<input type="text" name="isbn" id="isbn"/>
	</div>
	
	<input type="submit" name="dodaj knjigu" value="posalji" />

</form>