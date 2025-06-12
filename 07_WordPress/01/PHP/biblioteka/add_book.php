<?php include('blocks/header.php'); ?>
<?php if(isset($_SESSION['id')))
<?php 

	$autori = $conn->query("SELECT * FROM autor");
	$red = $autori->fetch_all();

	
	
	
	if(isset($_POST['dodaj_knjigu']))
	{
		
		$naziv = $_POST['naziv'];
		$pisac = $_POST['autor'];
		$isbn = $_POST['isbn'];
		
		//var_dump($_POST);
		$conn->query("INSERT INTO knjige (naziv_knjige,id_autor,isbn)VALUES('$naziv','$pisac','$isbn')");
		var_dump($conn);
		
	}



?>
<form method="POST" action="">
	<div>
		<label for="naziv">Naziv</label>
		<input type="text" name="naziv" id="naziv" />
	</div>
	
	<div>
		<label for="autor">Autor knjige</label>
		<select name="autor" id="autor">
			<?php 
			foreach($red as $el)
			{
			?>
				<option value="<?php echo $el[0]; ?>" ><?php echo $el[1]; ?></option>
			<?php
			}
			?>
			
		
		</select>
	</div>
	
	<div>
		<label for="isbn">ISBN</label>
		<input type="text" name="isbn" id="isbn" />
	</div>
	
	<button type="submit" name="dodaj_knjigu">Dodaj knjigu</button>
</form>


