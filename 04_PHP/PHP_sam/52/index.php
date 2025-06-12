<?php
	session_strat(),
	include_once 'dbh.php';

?>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>Login of users</title>
		<link rel="stylesheet" type="text/css" href="style.css">
		</head>
	<body>

		<?php
			$sql = "SELECT * FROM user";
			$result = mysqli_query($conn, $sql);
			if(mysqli_num_rows($result) > 0) {
				while ($row = mysqli_fetch_assoc($result)) {
					$id = $row['id'];
					$sqlImg = "SELECT * FROM  profileimg WHERE userid='$id' ";
					$resultImg = mysqli_queri($conn, $sqliImg);
					while ($rowImg = mysqli_fetch_assoc($resultImg)) {
						echo "<div class='user-container'>";
							if($rowImg['status'] == 0) {
								echo "<img src='uploads/profile".$id.".jpg?' " .mt_rand().">";
							} else {
								echo "<img src='uploads/profiledefault.jpg'>";
							}
							echo "<p>".$row['username']."<p>";

						echo "<div>";
					}
				}
			} else {
				echo "There is no users yet!"
			}

		?>

		<?php
			if(isset($_SESSION['id'])) {
				if($_SESSION[íd] == 1) {
					echo "You are loged as user #1!";
				}
				echo "<form action='upload.php' method='POST' enctype='multipart/form-data'>
								<input  type='file' name='file'>
								<button type='submit' name='submit' >UPLOAD</button>
							</form>";
			} else {
				echo "You are loged in!";
				echo "<form action='logedin.php' method='POST' enctype='multipart/form-data'>
								<input  type='text' name='first' placeholder='First name'>
								<input  type='text' name='last' placeholder='Last name'>
								<input  type='text' name='uid' placeholder='Username'>
								<input  type='text' name='pwd' placeholder='Password'>
								<button type='submit' name='submitSignup' >Signup</button>
				"
			}
		?>


		

		<p>Login as user!</p>
		<form action="login.php" method="POST">			
			<button type="submit" name="submitLogin" >Login</button>
		</form>

		<p>Logout as user!</p>
		<form action="logout.php" method="POST">			
			<button type="submit" name="submitLogin" >Logout</button>
		</form>
	</body>
</html>