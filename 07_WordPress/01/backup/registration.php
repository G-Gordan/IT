<?php include('blocs/header.php');?>

<?php


if(isset($_POST['unesite_podatke']))
	{	
		$ime_prezime= $_POST['ime_prezime'];
		$imejl = $_POST ['imejl'];
		$lozinka  = md5 ($_POST ['lozinka']);
		$jmbg = $_POST['jmbg'];
		$datum_rodjenja = $_POST['datum_rodjenja'];
		$opstina = $_POST['opstina'];
		
		
		$conn->query("INSERT INTO korisnici (ime_prezime,imejl,lozinka,jmbg,datum_rodjenja,opstina)VALUES('$ime_prezime','$imejl','$lozinka','$jmbg','$datum_rodjenja','$opstina')"); 
		
		
	}	









?>





<form method="POST" action="">
	<div>
		<label for="ime_prezime">Ime Prezime</label>
		<input type="text" name="ime_prezime" id="naziv" />
	</div>
	
	<div>
		<label for="imejl">Imejl</label> 
		<input type="text" name="imejl" id="imejl"/>
	</div>
	
	<div>
		<label for="lozinka">Lozinka</label>
		<input type="password" name="lozinka" id="lozinka"/>
	</div>
		
	<div>
		<label for="jmbg">JMBG</label>
		<input type="text" name="jmbg" id="jmbg"/>
	</div>
	
	<div>
		<label for="datum_rodjenja">Datum_rodjenja</label>
		<input type="text" name="datum_rodjenja" id="datum_rodjenja"/>
	</div>
	
	<div>
		<label for="opstina">Opstina</label>
		<input type="text" name="opstina" id="opstina"/>
	</div>
	

	
	
	<button type="submit" name="unesite_podatke">Unesite podatke</button>
	
	
	
	
	
	
</form>



