<?php
	$prvibroj = $_REQUEST['a'];
	$drugibroj = $_REQUEST['b'];

	$zbir = $prvibroj + $drugibroj;
?>
<html>
<body>
	<div class="container">
		<h2>
		<?= $zbir ?>
		</h2>
	</div>
</body>
</html>