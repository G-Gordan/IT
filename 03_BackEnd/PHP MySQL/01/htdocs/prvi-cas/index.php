<html>
<body>
	<h1>Prvi cas, php</h1>
	
	<?php
		if( isset($_REQUEST['a'])) {
			$prvibroj = $_REQUEST['a'];
			$drugibroj = $_REQUEST['b'];
			$zbir = $prvibroj + $drugibroj;	
		} else {
			$zbir = '';
		}
	?>
	
	<form method="get" action="#">
		<input type="text" name="a" 
			value="<?php if(isset($_REQUEST['a'])) echo $_REQUEST['a'] ?>" /> +
		<input type="text" name="b"
			value="<?php if(isset($_REQUEST['b'])) echo $_REQUEST['b'] ?>"
		/> = <?= $zbir ?>
		<br/>
		<input type="submit" value="Saberi" />
	</form>
	
</body>
</html>