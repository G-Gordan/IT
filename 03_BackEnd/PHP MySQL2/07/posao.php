<?php 
	require_once "dbconnect.php";
	
	if(isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='posalji_prijavu'){
		$ime_i_prezime = $_REQUEST['ime_i_prezime'];
		$telefon = $_REQUEST['telefon'];
		$email = $_REQUEST['email'];
		
//prvi nacin
		$cv = 'cv/'.$_FILES['cv']['name'];  // u folder cv, izvorno ime
		//i sada proveravam da li fajl postoji, ako postoji dodajem prefiks - broj.
		//to radim dok god ne naidjem na broj koji nije zauzet
		$i = 2;
		while( file_exists($cv) ){
			$i++;
			//ime je zauzeto, pravi novo
			$cv = 'cv/'.$i.$_FILES['cv']['name'];
		}
		
//druga varijanta - dodam unikatni prefiks
		$cv = 'cv/'.time().rand(1,1000).$_FILES['cv']['name'];
		
		
		
		move_uploaded_file($_FILES['cv']['tmp_name'], $cv);
		$db->query("insert into prijava_za_posao (ime_i_prezime, telefon, email, cv) values ('$ime_i_prezime','$telefon','$email','$cv')");
	}
	
	$_TITLE = 'Zaposljavamo';
	include 'modules/head.php';
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row sadrzaj_container">
			<div class="col-sm-12 col-md-9 sadrzaj" style="margin-bottom: -999999px; padding-bottom: 999999px;">
					<h1>Prijava za posao</h1>
							<form method="post" action="posao.php" enctype="multipart/form-data">
								<input type="hidden" name="akcija" value="posalji_prijavu" />
								Ime i prezime <br /><input type="text" name="ime_i_prezime" /> <br />
								Telefon <br /><input type="text" name="telefon" /> <br />
								Email <br /><input type="text" name="email" /> <br />
								Biografija <br /><input type="file" name="cv" /> <br />
								<input type="submit" value="Posalji prijavu" />
							</form>
			</div>
			<div class="col-sm-12 col-md-3 sidebar">
				<aside>
					<?php include 'modules/specijalna-ponuda.php'; ?>
					<?php include 'modules/last-minute.php'; ?>
				</aside>
			</div>
		</div>

<?php include 'modules/footer.php'; ?>
