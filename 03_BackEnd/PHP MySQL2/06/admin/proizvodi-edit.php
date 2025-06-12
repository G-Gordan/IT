<?php 
require '../dbconnect.php';

$id = $_REQUEST['id'];

if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='update' ){
	//ok, utvrdio sam da je forma submit-ovana
	//pokupim podatke iz forme
	$naziv = $_REQUEST['naziv'];
	$kraci_opis = $_REQUEST['kraci_opis'];
	$pun_opis = $_REQUEST['pun_opis'];
	$slika = $_REQUEST['slika'];
	$cena = $_REQUEST['cena'];
	$trajanje_dana = $_REQUEST['trajanje_dana'];
	$trajanje_casova = $_REQUEST['trajanje_casova'];
	$pocinje = $_REQUEST['pocinje'];
	$vreme = $_REQUEST['vreme'];
	$kat_id = $_REQUEST['kat_id'];
	//checkbox se malo drugacije obradjuje
	if(isset($_REQUEST['specijalna_ponuda'])) $specijalna_ponuda = 1;
	else $specijalna_ponuda = 0;
	
	//proverim podatke?
	
	//i uradim update
	$db->query(" update proizvod 
					set naziv='$naziv',
						kraci_opis='$kraci_opis',
						pun_opis='$pun_opis',
						slika='$slika',
						cena='$cena',
						trajanje_dana='$trajanje_dana',
						trajanje_casova='$trajanje_casova',
						pocinje='$pocinje',
						vreme='$vreme',
						specijalna_ponuda='$specijalna_ponuda',
						kat_id='$kat_id'
					where id='$id'
					");
}

//sada ucitam polja tog reda
$rez = $db->query('select * from proizvod where id='.$id  );
$proizvod = $rez->fetch_object();
if(!$proizvod){
	echo '404 - nepostojeca stranica';
	die(); //prekidamo skript, nema sta da prikaze, ovde je kraj izvrsavanja
}

$_TITLE = 'Admin Panel';
include 'modules/head.php'; 
?>
<script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
<script>tinymce.init({ selector:'#pun_opis' });</script>
	<div class="container">
		<h1>Izmena kursa</h1>
		
		<form action="proizvodi-edit.php" method="post">
			<input type="hidden" name="id" value="<?= $proizvod->id ?>" />
			<input type="hidden" name="akcija" value="update" />
			<div class="form-group">
				<label for="poruka">Naziv</label>
				<input class="form-control" type="text" name="naziv" value="<?= $proizvod->naziv ?>" />
			</div>
			<div class="form-group">
				<label for="poruka">Kategorija</label>
				<select class="form-control" name="kat_id">
					<?php
						$rez2 = $db->query("select * from kategorija");
						while( $kat = $rez2->fetch_object() ){
							if( $proizvod->kat_id==$kat->id ){
								echo '<option selected value="'.$kat->id.'">'.$kat->naziv.'</option>';
							}
							else{
								echo '<option value="'.$kat->id.'">'.$kat->naziv.'</option>';
							}
						}
					?>
				</select>
			</div>
			
			<div class="form-group">
				<label for="poruka">Kraci opis</label>
				<textarea class="form-control" name="kraci_opis"><?= $proizvod->kraci_opis ?></textarea>
			</div>
			<div class="form-group">
				<label for="poruka">Duzi opis </label>
				<textarea class="form-control" name="pun_opis" id="pun_opis"><?= $proizvod->pun_opis ?></textarea>
			</div>
			<div class="form-group">
				<label for="poruka">Slika</label>
				<input class="form-control" type="text" name="slika" value="<?= $proizvod->slika ?>" />
			</div>
			<div class="row">
			<div class="form-group col-sm-4">
				<label for="poruka">Cena</label>
				<input class="form-control" type="text" name="cena" value="<?= $proizvod->cena ?>" />
			</div>
			<div class="form-group col-sm-4">
				<label for="poruka">Trajanje dana</label>
				<input class="form-control" type="text" name="trajanje_dana" value="<?= $proizvod->trajanje_dana ?>" />
			</div>
			<div class="form-group col-sm-4">
				<label for="poruka">Trajanje casova</label>
				<input class="form-control" type="text" name="trajanje_casova" value="<?= $proizvod->trajanje_casova ?>" />
			</div>
			<div class="form-group col-sm-4">
				<label for="poruka">Pocinje</label>
				<input class="form-control" type="text" name="pocinje" value="<?= $proizvod->pocinje ?>" />
			</div>
			<div class="form-group col-sm-4">
				<label for="poruka">Vreme</label>
				<input class="form-control" type="text" name="vreme" value="<?= $proizvod->vreme ?>" />
			</div>
			<div class="form-group col-sm-4">
				<label for="poruka">Specijalna ponuda
					<input type="checkbox" name="specijalna_ponuda" <?php if($proizvod->specijalna_ponuda) { echo ' checked '; } ?> />
				</label>
			</div>
			</div>
			<div class="row">
				<input type="submit" value="Sacuvaj promene" /> 
				<a href="proizvodi-spisak.php">Otkazi</a>
			</div>
		</form>
	</div>
<?php include 'modules/footer.php'; ?>
