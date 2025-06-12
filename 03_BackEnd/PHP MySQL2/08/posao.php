<?php 
	require_once "dbconnect.php";
	
	if(isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='posalji_prijavu'){
		$ime_i_prezime = $db->real_escape_string($_REQUEST['ime_i_prezime']);
		$telefon = $db->real_escape_string($_REQUEST['telefon']);
		$email = $db->real_escape_string($_REQUEST['email']);
		
		$validno = true;
		$status_msg = '';
		//provera - trazim gresku
		if( !preg_match("/[a-z]{3,} [a-z]{3,}/i", $ime_i_prezime) ){ //provera imena
			$validno = false;
			$status_msg .= '<p>Ime i prezime nisu korektno uneti</p>';
		}
		//provera telefona
		if( !preg_match("/^[0-9]{3}[\/]?[0-9]{3}[\-][0-9]{3,4}$/", $telefon) ){
			$validno = false;
			$status_msg .= '<p>Broj telefona nije validan</p>';
		}
		//provera emaila
		$pattern = '/^(?!(?:(?:\\x22?\\x5C[\\x00-\\x7E]\\x22?)|(?:\\x22?[^\\x5C\\x22]\\x22?)){255,})(?!(?:(?:\\x22?\\x5C[\\x00-\\x7E]\\x22?)|(?:\\x22?[^\\x5C\\x22]\\x22?)){65,}@)(?:(?:[\\x21\\x23-\\x27\\x2A\\x2B\\x2D\\x2F-\\x39\\x3D\\x3F\\x5E-\\x7E]+)|(?:\\x22(?:[\\x01-\\x08\\x0B\\x0C\\x0E-\\x1F\\x21\\x23-\\x5B\\x5D-\\x7F]|(?:\\x5C[\\x00-\\x7F]))*\\x22))(?:\\.(?:(?:[\\x21\\x23-\\x27\\x2A\\x2B\\x2D\\x2F-\\x39\\x3D\\x3F\\x5E-\\x7E]+)|(?:\\x22(?:[\\x01-\\x08\\x0B\\x0C\\x0E-\\x1F\\x21\\x23-\\x5B\\x5D-\\x7F]|(?:\\x5C[\\x00-\\x7F]))*\\x22)))*@(?:(?:(?!.*[^.]{64,})(?:(?:(?:xn--)?[a-z0-9]+(?:-+[a-z0-9]+)*\\.){1,126}){1,}(?:(?:[a-z][a-z0-9]*)|(?:(?:xn--)[a-z0-9]+))(?:-+[a-z0-9]+)*)|(?:\\[(?:(?:IPv6:(?:(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){7})|(?:(?!(?:.*[a-f0-9][:\\]]){7,})(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,5})?::(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,5})?)))|(?:(?:IPv6:(?:(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){5}:)|(?:(?!(?:.*[a-f0-9]:){5,})(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,3})?::(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,3}:)?)))?(?:(?:25[0-5])|(?:2[0-4][0-9])|(?:1[0-9]{2})|(?:[1-9]?[0-9]))(?:\\.(?:(?:25[0-5])|(?:2[0-4][0-9])|(?:1[0-9]{2})|(?:[1-9]?[0-9]))){3}))\\]))$/iD';
		if( strlen($email)==0 or !preg_match($pattern, $email) ){
			$validno = false;
			$status_msg .= '<p>Email nije validan</p>';
		}
		//provera fajla
		if(!isset($_FILES['cv'])){
			$validno = false;
			$status_msg .= '<p>Fajl nije prikljucen</p>';
		}
		
		
		//ako je sve u redu, onda vrsim zapis
		if($validno){
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
			//$cv = 'cv/'.time().rand(1,1000).$_FILES['cv']['name'];
			
			move_uploaded_file($_FILES['cv']['tmp_name'], $cv);
			$db->query("insert into prijava_za_posao (ime_i_prezime, telefon, email, cv) values ('$ime_i_prezime','$telefon','$email','$cv')");
		} else {
			echo $status_msg;
		}
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
