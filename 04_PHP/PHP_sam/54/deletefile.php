<?php
$path = "uploads/cat.jpg";

if (!unlink($path)) {
	echo "You have an error!";
} else {
	header("Location: index.php?deletesucess");
}


?>