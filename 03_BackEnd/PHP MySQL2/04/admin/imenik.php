<?php 
$_TITLE = 'Admin Panel';
include 'modules/head.php'; 


if( isset( $_REQUEST['ime'] ) ){
	$novired = PHP_EOL . $_REQUEST['ime'] . '|' . $_REQUEST['tel'];
	file_put_contents('../data/imenik.txt', $novired, FILE_APPEND);
}

?>
	<div class="container">
		<h1>Kontakti</h1>
		
		<table class="table">
			<thead>
				<tr>
					<td>Ime</td><td>Telefon</td>
				</tr>
			</thead>
			<tbody>
				<?php
					$kontakti = file('../data/imenik.txt');
					foreach($kontakti as $kontakt){
						$delovi = explode('|', $kontakt);
						$ime = $delovi[0];
						$tel = $delovi[1];
						echo "<tr><td>$ime</td><td>$tel</td></tr>";
					}
				?>
			</tbody>
		</table>
		<form action="imenik.php" method="post">
			<input type="text" name="ime" />
			<input type="text" name="tel" id="tel" onkeyup=" proveriTelefon() " />
			<input type="submit" value="Dodaj" />
		</form>
	</div>
	<script>
		function proveriTelefon(){
			$.ajax({
				url:'provera-telefona.php',
				data:{
					telefon:$('#tel').val()
				},
				success:function(odgovor){
					if(odgovor=='ZAUZET'){
						$('#tel').css('background-color', 'red');
					} else{
						$('#tel').css('background-color', 'white');
					}
				}
			});
		}
	</script>
	
	
<?php include 'modules/footer.php'; ?>
