<?php

session_start();
if(isset($_POST['submitLogin'])) {
	SESSION['id'] = 1;
	header("Location: insex.php");
}

?>