<?php
	session_start();
?>
<!DOCTYPE html>
<html>
<head>
	<title></title>
	<link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>

	<header>
		<nav>
			<div class="main-wrapper">
				<ul>
					<li><a hraf="index.php">Home</a></li>
				</ul>
				<div class="nav-login">
					<?php
						if (isset($_SESSION[ú_id])) {
							echo '<form action="includes/logout.inc.php" method="POST">
									<button type="submit" name="submit">Logout</button>
									</form>';
						} else {
							echo '<form action+"includes/login.inc.php" method="POST">
									<input type="text" name="uid" placeholder="Username/e-mail">
									<input type="password" name="pwd" placeholder="Password">
									<button type="submit" name="submit">Log in</button>
									</form>
									<a href="singup.php">Sing up</a>';
						}
					?>
					
				</div>
			</div>
		</nav>
	</header>