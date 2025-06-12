<?php 
require '../dbconnect.php';

if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='insert' ){
	//ok, utvrdio sam da je forma submit-ovana
	//pokupim podatke iz forme
	$naslov = $_REQUEST['naslov'];
	$datum = $_REQUEST['datum'];
	$kraci_opis = $_REQUEST['kraci_opis'];
	$pun_opis = $_REQUEST['pun_opis'];
	//proverim podatke?
	
	//i uradim insert
	$db->query(" insert into vest 
						(naslov,datum,kraci_opis,pun_opis)
				values ( '$naslov','$datum','$kraci_opis','$pun_opis' )
			");
	$noviid = $db->insert_id;
	
	//varijanta kada saljem klijenta na spisak
	//header("Location: vesti-spisak.php"); die();
	
	//varijanta kada saljem klijenta na izmenu te nove vesti
	header("Location: vesti-edit.php?id=$noviid"); die();
	
}


$_TITLE = 'Admin Panel';
include 'modules/head.php'; 
?>
<script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
<script>tinymce.init({ selector:'#pun_opis' });</script>

<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

<script>
	$(function(){
		$('#datum').datepicker({
			dateFormat: 'yy-mm-dd'
		});
	});
</script>

	<div class="container">
		<h1>Nova vest</h1>
		
		<form action="vesti-dodaj.php" method="post">
			<input type="hidden" name="akcija" value="insert" />
			<div class="form-group">
				<label for="poruka">Naslov</label>
				<input class="form-control" type="text" name="naslov" value="" />
			</div>
			<div class="form-group">
				<label for="poruka">Datum</label>
				<input class="form-control" id="datum" type="text" name="datum" value="" />
			</div>
			<div class="form-group">
				<label for="poruka">Kraci opis</label>
				<textarea class="form-control" name="kraci_opis"></textarea>
			</div>
			<div class="form-group">
				<label for="poruka">Duzi opis </label>
				<textarea class="form-control" name="pun_opis" id="pun_opis"></textarea>
			</div>
			<input type="submit" value="Sacuvaj promene" /> 
			<a href="vesti-spisak.php">Otkazi</a>
		</form>
	
	</div>
<?php include 'modules/footer.php'; ?>
