<!DOCTYPE html>
<html>
<head>
	<title></title>
</head>
<body>
	<?php
		/*
		echo "test123";
		echo "<br>";
		echo password_hash ("test123", PASSWORD_DEFAULT);
		*/

		$insert = "test123";
		$hashedPwdInDb =  password_hash ("test123", PASSWORD_DEFAULT);
		echo password_verify($insert, $hashedPwdInDb);

	?>
</body>
</html>
