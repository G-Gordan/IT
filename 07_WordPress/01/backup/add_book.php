<?php include('blocs/header.php');?>
<?php
	$autori = $conn->query("SELECT * FROM autor");
	$red = $autori->fetch_all();
	
	
	var_dump ($red);

	if(isset($_POST['dodaj_knjigu']))
	{	
		$naziv = $_POST['naziv'];
		$autor = $_POST ['autor'];
		$isbn  = $_POST ['isbn'];
		var_dump ($_POST);
		$conn->query("INSERT INTO Knjige (naziv_knjige,id_autor,ISBN)VALUES('$naziv','$pisac','$isbn')"); 
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
		<?php
		foreach ($red as $el){
		?>	
		 <option value="<?php echo $el[0]; ?>" ><?php echo $el[1] ?></option>
	
		<?php
		}
	
	?>
			
			
		</select>
	</div>
	<div>
		<label for="isbn">ISBN<label/>
		<input type="text" name="isbn" id="isbn"/>
	</div>
	
	<input type="submit" name="dodaj knjigu" value="posalji" />

</form>