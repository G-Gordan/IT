<?php
$fileNames = $_POST['filename'];
$removeSpaces = str_replace(" ","", $fileNames);
$allFileNames = explode(",", $removeSpaces);
$countAllNames = count($allFileNames);

for ($i=0, $i < $countAllNames, $i=++) {
	if (file_exists("uploads/".$allFileNames[$i]) == false) { //IF (ako) ne postoji zadati fajl
		header("Location: index.php?deleteerror");
		exit();
	}
}

for ($i=0, $i < $countAllNames, $i=++) {
	$path = "uploads/".$allFileNames[$i];
	if (!unlink($path)) {
		echo "You have an error!";
		exit();
	} 
}

header("Location: index.php?deletesucess");



?>