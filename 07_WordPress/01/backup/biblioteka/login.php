<?php include('blocks/header.php'); ?>

<?php 

	
	
	
	
	if(isset($_POST['login']))
	{
		
		
		$email = $_POST['email'];
		$lozinka = md5($_POST['lozinka']);
		
		$korisnici = $conn->query("SELECT * FROM korisnici WHERE email='$email' AND lozinka='$lozinka'");
		$red = $korisnici->fetch_all();
		
		if($red){
			
			//session_start();
			$_SESSION['id'] = $red['0'];
			
			var_dump($_SESSION);
			
		}else{
			
			echo "Nepostojeci korisnik";
		}
		
	}



?>
<form method="POST" action="">
	
	<div>
		<label for="naziv">Email</label>
		<input type="text" name="email" id="email" />
	</div>
	
	<div>
		<label for="naziv">Lozinka</label>
		<input type="password" name="lozinka" id="lozinka" />
	</div>
	
	<button type="submit" name="login">login</button>
</form>


