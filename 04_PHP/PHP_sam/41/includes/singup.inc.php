<?php
//proveravamo da li kliknuto Singup dugme
if (isset($_POST['submit'])) {
	//povezujemo sa fajlom za konekciju
	//include_once 'dbh.inc.php';
	//prihvatamo podatke iz forme
	$first = $_POST['first'];
	$last = $_POST['last'];
	$email = $_POST['email'];
	$uid = $_POST['uid'];
	$pwd = $_POST['pwd'];

//provera da li su uneti podaci
	if (empty($first) || empty($last) || empty($email) || empty($uid) || empty($pwd)) {
		header("Location: ../index.php?singup=empty");
			echo "RADI 1";
			exit();
	} 
	else {
		echo "RADI 2";
		//provera da li su upisani ispravni karakteri
		if (!preg_match("/^[a-zA-Z]*$/", $first) || (!preg_match("/^[a-zA-Z]*$/", $last)) {
			header("Location: ../index.php?singup=char");
				echo " - RADI 3";
			exit();
		} else {
			//provera validnosti emaila
			if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
				header("Location: ../index.php?singup=email");
				exit();
			} else {
				header("Location: ../index.php?singup=success");
				exit();
			}
		}
	}
} else {
	header("Location: ../index.php");
	exit();
}

?>