<?php

$path = "uploads/cat*";
$fileInfo = glob($path);
$fileActualName = fileInfo[0];

if (!unlink($fileActualName)) {
	echo "You have an error!";
} else {
	header("Location: index.php?deletesucess");
}


?>