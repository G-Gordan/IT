<?php
if (isset($_POST['submit'])) {
	//$file=$_FILES['file'];
	$fileName=$_FILES['file']['name'];
	$fileTmpName=$_FILES['file']['tmp_name'];
	$fileSize=$_FILES['file']['size'];
	$fileError=$_FILES['file']['error'];
	$fileType=$_FILES['file']['type'];

	$fileExt = explode('.', fileName);//razbija string na elemente niza razdvojene tackom
	$fileActualExt = strtolouer(end($fileExt));//uzima zadnji element niza, ekstenziju

	$allowed=['jpg', 'jpeg', 'png', 'pdf'];

	if (in_array($fileActualExt, $allowed)) {
		if ($fileError === 0) {
			if ($fileSize < 100000) {//100Kb
				$fileNameNew=uniqid('', true).".".$fileActualExt;
				$fileDestination="uploads/".$fileNameNew;//uploads je folder u rootu u koji se smesta uploadovani fajl

				move_uploaded_file($file, $fileDestination);
				header("Location: index.php?uploadsuccess");
			} else {
				echo "Fajl je prevelik!"
			}
		} else {
			echo "Desila se geska..."
		}
	} else {
		echo "Ne mozete uploadovati ovaj tip fajla!";
	}
}

?>