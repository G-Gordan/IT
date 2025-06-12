<?php 
$ACCESS_LEVEL = 0;  //password reset se radi ako covek ne moze da se uloguje, znaci ovo treba da bude public
require_once "init.php"; 
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Reset passworda</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
	<div class="container">
		<h1>Reset passworda</h1>
		<?php  if(isset($status)) echo $status; ?>
		<?php
			if(isset($_REQUEST['poruka'])){
				if($_REQUEST['poruka'] == 'pristup_zabranjen') echo 'Zabranjen pristup! Ulogujte se';
				
			}
		?>
		<form method="post" action="user.php">
			<input type="hidden" name="akcija" value="reset-password" />
			Email: <input type="text" name="email" /> <br />
			Username: <input type="text" name="username" /> <br />
			<button>Promeni</button>
		</form>
	</div>
</body>
</html>