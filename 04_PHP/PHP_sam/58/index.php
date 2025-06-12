<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>Contact form tutorial</title>
		<link rel="stylesheet"  href="https://fonts.googleapis.com/css?family=Roboto+Condensed:400.700">
		<link rel="stylesheet" type="stext/css" href="style.css">
		</head>
	<body>
			<main>
				<p>SEND E-MAIL</p>
				<form class="contact-form" action="contactform.php" method="POST">
					<input type="text" name="name" plceholder="Full name">
					<input type="text" name="email" plceholder="Your e-mail">
					<input type="text" name="subject" plceholder="Subject">
					<textarea name="mesage" placeholder="Mesage" rows="8" cols="80"></textarea>
					<button type="submit" name="submi">SEND MAIL</button>
				</form>
			</main>
		</body>
</html>