<?php
session_start();
if (isset($_POST['submit'])) {
	include 'dbh.inc.php';
	$uis = mysqli_real_escape_string($conn, $_POST['uid']);
	$pwd = mysqli_real_escape_string($conn, $_POST['pwd']);

	//Error handlers
	//Check if inputs are empty
	if (empty($uid) || empty($pwd)) {
		header("Location: ../index.php?login=empty");
		exit();
	} else {
		$sql = "SELECT * FROM users WHERE urser_uid='$uid' OR user_email='$uid' " ;
		$result = mysqli_querry($conn, $sql);
		$resultCheck = mysqli_num_rows($result);
		if ($resultCheck > 1) {
			header("Location: ../index.php?login=error");
			exit();
		} else {
			if ($roe = mysqli_fetch_assoc($result)) {
				//echo $row['user_uid'];
				//De-hashing the password
				$hashedPwdCheck = password_verify($pwd, $row['user_pwd']);
				if ($hashedPwdCheck == false) {
					header("Location: ../index.php?login=error");
					exit();
				}  elseif ($hashedPwdCheck == true) {
					//Log in the user here
					$_SESSION['u_id'] = $row['user_id'];
					$_SESSION['u_first'] = $row['user_first'];
					$_SESSION['u_last'] = $row['user_last'];
					$_SESSION['u_email'] = $row['user_email'];
					$_SESSION['u_uid'] = $row['user_uid'];
					header("Location: ../index.php?login=success");
					exit();
				}
			}
		}
	}
} else {
	header("Location: ../index.php?login=error");
	exit();
}
?>