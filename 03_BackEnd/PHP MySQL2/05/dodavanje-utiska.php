<?php
	//dohvati poslati utisak, u $_REQUEST
	//unese to u fajl
	//redirektuje na utisci.php
	
	$datum = date("d.n.Y.");
	$ime = $_REQUEST['ime'];
	$utisak =  str_replace(
					["\r\n", "\n", "\r"],
					"<br />", 
					$_REQUEST['poruka']
				);
	
	$novired = "$datum|$ime|$utisak\n";
	
	/*
	$fajl = fopen("data/utisci.txt", "a");
	fputs($fajl, $novired);
	fclose($fajl);
	*/
	file_put_contents('data/utisci.txt', 
			$novired, FILE_APPEND);
	
	header("Location: utisci.php");
?>