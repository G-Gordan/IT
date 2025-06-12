<html>
<head>
	<title>Sabiranje</title>
</head>
<body>
	<form method="get" action="sabiranje3.php">
		Brojevi = <input type="text" name="brojevi" value="" placeholder="1,2,3" /> <br />
		<input type="submit" value="Saberi" />
	</form>
	<?php
		if( isset( $_REQUEST['brojevi'] ) ){
			$brojevi = explode(',' , $_REQUEST['brojevi'] );
			$zbir = 0;
			for( $i=0; $i<count($brojevi); $i++ ){
				$zbir += $brojevi[$i];
			}
			echo "Zbir je <b> $zbir </b>";
			$niz = array();
			$niz = [];
			$niz[5] = 'element nula';
			$niz[] = 'poslednji element';
			$niz[3] = 'element tri';
			$niz['a'] = 'element a';
			$niz[] = 'drugi poslednji element';
			print_r($niz);
			foreach($niz as $indeks=>$vrednost){
				echo 'Niz na indeksu ' . $indeks
					. ' ima vrednost ' . $vrednost
					. ' a moze da se pise i ovako ' . $niz[$indeks] . '<br />';
			}
			foreach($niz as $element){
				echo $element;
			}
			
		}
	?>
</body>
</html>