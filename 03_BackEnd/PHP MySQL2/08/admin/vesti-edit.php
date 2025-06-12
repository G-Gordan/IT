<?php 
require '../dbconnect.php';

$id = $_REQUEST['id'];

if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='update' ){
	//ok, utvrdio sam da je forma submit-ovana
	//pokupim podatke iz forme
	$naslov = $_REQUEST['naslov'];
	$datum = $_REQUEST['datum'];
	$kraci_opis = $_REQUEST['kraci_opis'];
	$pun_opis = $_REQUEST['pun_opis'];
	//proverim podatke?
	
	//i uradim update
	$db->query(" update vest 
					set naslov='$naslov',
						datum='$datum',
						kraci_opis='$kraci_opis',
						pun_opis='$pun_opis'
					where id='$id'
					");
}

//sada ucitam vrednosti tog reda
$rez = $db->query('select * from vest where id='.$id  );
$vest = $rez->fetch_object();
if(!$vest){
	echo '404 - nepostojeca stranica';
	die(); //prekidamo skript, nema sta da prikaze, ovde je kraj izvrsavanja
}

$_TITLE = 'Admin Panel';
include 'modules/head.php'; 
?>
<script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
<script>tinymce.init({ selector:'#pun_opis' });</script>
	<div class="container">
		<h1>Izmena vesti</h1>
		
		<form action="vesti-edit.php" method="post">
			<input type="hidden" name="id" value="<?= $vest->id ?>" />
			<input type="hidden" name="akcija" value="update" />
			<div class="form-group">
				<label for="poruka">Naslov</label>
				<input class="form-control" type="text" name="naslov" value="<?= $vest->naslov ?>" />
			</div>
			<div class="form-group">
				<label for="poruka">Datum</label>
				<input class="form-control" type="text" name="datum" value="<?= $vest->datum ?>" />
			</div>
			<div class="form-group">
				<label for="poruka">Kraci opis</label>
				<textarea class="form-control" name="kraci_opis"><?= $vest->kraci_opis ?></textarea>
			</div>
			<div class="form-group">
				<label for="poruka">Duzi opis </label>
				<textarea class="form-control" name="pun_opis" id="pun_opis"><?= $vest->pun_opis ?></textarea>
			</div>
			<input type="submit" value="Sacuvaj promene" /> 
			<a href="vesti-spisak.php">Otkazi</a>
		</form>
		
		<h4>Komentari</h4>
		<?php 
			//unos novog komentara ako je poslat
			if(isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='dodaj_komentar' ){
				$ime = $_REQUEST['ime'];
				$sadrzaj = $_REQUEST['sadrzaj'];
				$datum = date("Y-m-d H:i:s");
				$upit = " INSERT INTO komentar (autor, datum, sadrzaj, vest_id)
							VALUES ('$ime', '$datum', '$sadrzaj', '$id') ";
				$db->query($upit);
				
				echo $upit;
			}
			
			
			$upit = "SELECT * FROM komentar WHERE vest_id = '$id' ";
			$rez = $db->query($upit);
			while( $komentar = $rez->fetch_object() ){
				?>
				
				<div class="komentar">
					<a href="vesti-komentar-obrisi.php?komentar_id=<?= $komentar->id ?>&vest_id=<?= $id ?>" class="btn btn-danger">Obrisi komentar</a>
					<datetime><?= $komentar->datum ?></datetime>
					<span class="autor" style="font-weight:bold"><?= $komentar->autor ?></span>
					<p><?= $komentar->sadrzaj ?></p>
				</div>
				<hr />
				
				<?php
			}
		?>
	
	</div>
<?php include 'modules/footer.php'; ?>
