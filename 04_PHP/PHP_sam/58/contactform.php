<?php
if (isset($_POST['submit'])) {
	$name = $_POST['name'];
	$subject = $_POST['subject'];
	$mailFrom = $_POST['mail'];
	$mesage = $_POST['mesage'];

	$mailTo = "dani@mmtuts.net";
	$headers = "From: ".$mailFrom;
	$txt = "You have received an e-mail from ".$name.".\n\n".$mesage;// znak \n obezbedjuje prelazak u novi red ( u ovom slucaju 2X)

	mail($mailTo, $subject, $txt, $headers);
	header("Location: index.php?mailsend");

}
?>