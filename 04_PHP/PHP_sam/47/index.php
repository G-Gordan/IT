<?php
	include_once 'dbh.php';
>?
<!DOCTYPE html>
<html>
<head>
	<title></title>
</head>
<body>
	<?php

	$sql = "SELECT * FROM data";
	$result = mysqli_query($conn, $sql);
	$datas = array();
	if (mysqli_num_row($result) > 0) {
		while($row = mysqli_fetch_assoc($result)) {
			$datas[] = $row;
			//echo $row['text']; //ispisuje vrednosti svih polja iz kolone text
		}
	}
	//print_r($datas);
	//foreach ($datas[0] as $data ) {   //ovako prikazuje samo podatke iz prvog reda - sloga
	//		echo $data;
	//		echo $data['text']; //$data je takođe niz koji sadrži samo jedan red i ovako prikazuje samo podatke kolone text

	foreach ($datas as $data) {
		echo $data['text']. " - "; //text je ime kolone u tebeli data, baze test

	}

	?>
</body>
</html>

