<html>
<head>
	<title>Sabiranje</title>
</head>
<body>
	<form method="get" action="sabiranje2.php">
		a= <input type="text" name="a" value="<?php if(isset($_REQUEST['a'])) echo $_REQUEST['a']; ?>" /> <br />
		b= <input type="text" name="b" value="<?php if(isset($_REQUEST['b'])) echo $_REQUEST['b']; ?>" /> <br />
		c= <input type="text" name="c" value="<?php if(isset($_REQUEST['c'])) echo $_REQUEST['c']; ?>" /> <br />
		<input type="submit" value="Saberi" />
	</form>
	
	<?php
		if( isset( $_REQUEST['a'] ) 
			and isset($_REQUEST['b']) 
			and isset($_REQUEST['c']) 
		){
			$a = $_REQUEST['a'];
			$b = $_REQUEST['b'];
			$c = $_REQUEST['c'];
			
			$zbir = $a + $b + $c;
			$prosek = $zbir / 3;
			
			echo 'Zbir je ' . $zbir;
			echo '<br />';
			echo 'Prosek je ' . $prosek;
		}
		
		/*
		$a = $_REQUEST;
		echo PHP_EOL;
		echo $a;
		echo PHP_EOL;
		print_r($a);
		echo PHP_EOL;
		var_dump($a);
		echo PHP_EOL;
		die();
		exit();
		*/
	?>
</body>
</html>