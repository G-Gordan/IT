<html>
	<head>
	</head>
		<body>
			<h1> Vinca</h1>
			<p> kursevi php </p>
			<?php //phpinfo(); ?>
		</body>
			
</html>




<?php

$ocena = 4;

if ($ocena>1 and $ocena<3)
{
	echo "prvi nivo";
}
else if ($ocena>4 and $ocena<6)
{
	echo "drugi nivo";
}
else if ($ocena>7 and $ocena<8)
{
	echo "treci nivo";
}
else if ($ocena>9 and $ocena<10)
{
	echo "cetvrti nivo";
}
else if ($ocena=1)
{
	echo "greska";
}
?>