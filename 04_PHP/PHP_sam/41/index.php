<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>Error handler tutorial!</title>
		<link rel="stylesheet" href="css/style.css">
	</head>
	<body>
		<h2>Singup</h2>
		<form action="includes/singup.inc.php" method="POST">
			<input type="text" name="first" placeholder="Firstname">
			<input type="text" name="last" placeholder="Lastname">
			<input type="text" name="email" placeholder="E-mail">
			<input type="text" name="uid" placeholder="Username">
			<input type="password" name="pwd" placeholder="Password">
			<button type="submit" name="submit">SIng up</button>
		</form>
		<?php
			$fullUrl = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";

			if (strpos($fullUrl, "singup=empty") == true) {
				echo "<p class='error'>Niste popunili sva polja!</p>";
				exit();
			} elseif (strpos($fullUrl, "singup=char") == true) {
				echo "<p class='error'>Niste ispravno uneli karaktere!</p>";
				exit();
			} elseif (strpos($fullUrl, "singup=email") == true) {
				echo "<p class='error'>Niste pravilno uneli email!</p>";
				exit();
			} elseif (strpos($fullUrl, "singup=success") == true) {
				echo "<p class='success'>Uspešno ste prosledili podatke!</p>";
				exit();
			}
		?>
	</body>
</html>