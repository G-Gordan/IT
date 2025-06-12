<?php include('blocks/header.php'); ?>

<?php 

	$autori = $conn->query("SELECT * FROM opstine");
	$red = $autori->fetch_all();
	
	
	
	if(isset($_POST['registracija']))
	{
		
		$ime = $_POST['ime_prezime'];
		$email = $_POST['email'];
		$lozinka = md5($_POST['lozinka']);
		$jmbg = $_POST['jmbg'];
		$datum = $_POST['datum_rodjenja'];
		$opstina = $_POST['opstina'];
		
		//var_dump($_POST);
		$conn->query("INSERT INTO korisnici (ime_prezime,email,lozinka,jmbg,datum_rodjenja,opstina )VALUES('$ime','$email','$lozinka','$jmbg','$datum','$opstina')");
		var_dump($conn);
		
	}



?>
<form method="POST" action="">
	<div>
		<label for="naziv">Ime i prezime</label>
		<input type="text" name="ime_prezime" id="ime_prezime" />
	</div>
	
	<div>
		<label for="naziv">Email</label>
		<input type="text" name="email" id="email" />
	</div>
	
	<div>
		<label for="naziv">Lozinka</label>
		<input type="password" name="lozinka" id="lozinka" />
	</div>
	
	<div>
		<label for="naziv">jmbg</label>
		<input type="text" name="jmbg" id="jmbg" />
	</div>
	
	<div>
		<label for="naziv">Datum rodjenja</label>
		<input type="date"  value="2017-06-01" name="datum_rodjenja" id="daum rodjenja" />
	</div>
	
	
	<div>
		<label for="autor">Autor knjige</label>
		<select name="opstina" id="opstina">
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

	
	<button type="submit" name="registracija">Dodaj knjigu</button>
</form>


