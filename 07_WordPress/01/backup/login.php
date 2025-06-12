<?php include('blocs/header.php');?>

<?php



if(isset($_POST['log_in']))
	{	
		
		$imejl = $_POST ['imejl'];
		$lozinka  = md5 ($_POST ['lozinka']);
		$conn->query("INSERT INTO korisnici (imejl,lozinka)VALUES('$imejl','$lozinka'"); 
		$korisnici = $conn->query("SELECT * FROM korisnici WHERE imejl='$imejl' AND lozinka='$lozinka'");
		$red = $korisnici->fetch_all();
		
		if ($red){
			//session_start();
			$_SESSION['id'] = $red['0'];
			var_dump ($SESSION);
		}else{
			echo "Nepostojeci korisnik";
		}
			
		
		
		
		
	}	









?>





<form method="POST" action="">
	
	<div>
		<label for="imejl">Imejl</label> 
		<input type="text" name="imejl" id="imejl"/>
	</div>
	
	<div>
		<label for="lozinka">Lozinka</label>
		<input type="password" name="lozinka" id="lozinka"/>
	</div>
		

	
	<button type="submit" name="log_in">Log in</button>
	
	
	
	
	
	
</form>



