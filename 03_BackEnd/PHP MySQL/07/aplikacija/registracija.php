<?php 
$ACCESS_LEVEL = 0;
require_once "init.php"; 
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Registracija</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
	<div class="container">
		<h1>Registracija</h1>
		<?php  if(isset($status)) echo $status; ?>
		<?php
			if(isset($_REQUEST['poruka'])){
				if($_REQUEST['poruka'] == 'pristup_zabranjen') echo 'Zabranjen pristup! Ulogujte se';
				
			}
		?>
		<form method="post" action="user.php">
			<input type="hidden" name="akcija" value="register" />
			Username: <input type="text" name="u" /> <br />
			Password: <input type="password" name="p" /> <br />
			Repeat password: <input type="password" name="p2" /> <br />
			Email: <input type="text" name="email" /> <br />
			<button>Napravi nalog</button>
		</form>
		<a href="password-recovery.php">Zaboravljena lozinka?</a> <br/>
		<a href="login.php">Login</a> <br/>
	</div>
</body>
</html>