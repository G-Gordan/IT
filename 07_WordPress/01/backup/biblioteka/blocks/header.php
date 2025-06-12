<?php
	require('core/connection.php');
	session_start();
	
	var_dump($_SESSION);
?>

<a href="login.php">login</a>
<a href="registration.php">registracija</a>
<a href="add_author.php">dodaj autora</a>
<a href="add_book.php">dodaj knjigu</a>