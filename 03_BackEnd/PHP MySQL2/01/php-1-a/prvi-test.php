<html>
<head><title>Test php</title></head>
<body>
<?php
	print "Hello world!";
	$a = 15;
	$b = 13 + 2;
	$c = $a + $b;
	$d = 2 * $a;
	echo "2*15=" . $d . PHP_EOL;
	echo "2*15=<b>$d</b>\n <br />";
	echo '... $d ';
	
	$a = '15 ...';
	$c = 12 + $a;
	print $c;
	
	//false true 
	//false = false, null, 0, ''
	//true = sve ostalo
	/* operacije poredjenja i logicki operatori
	<
	>
	<=
	>=
	!=
	==
	
	and   &&
	or    ||
	!
	
	()
	*/
	// jednoredni komentar
	/*
		viseredni komentar
	*/
	
	if( $a > 10 ){
		print "a je vece od 10";
	}
	else if( $a>=0 ){
		print "a je jednocifreni pozitivan broj";
	}
	else {
		print "a je negativan";
	}
	
	$i = 0;
	while( $i<10 ){
		
		echo $i . '<br />';
		
		$i++;
		//++$i;
		//$i = $i+1;
		//$i += 1;
	}
	/*
	do{
		
	} while( ... );
	*/
	for( $i=0; $i<10; $i++ ){
		echo $i . '<br />';
	}
?>
</body>
</html>