<?php
	
	$server = "localhost";
	$username = "";
	$password = "";
	$database = "test";

	$conn = mysqli_connect($server, $username, $password, $database);
	if (!conn) {
		die("Connection failed: ".mysqli_connect_error());
	}

	?>