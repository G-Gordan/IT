<?php 
	$provera_a = rand(1,9);
	$provera_b = rand(1,9);
	$provera_odgovor = $provera_a + $provera_b;
	setcookie('odgovor',$provera_odgovor);


	$_TITLE = 'Kontakt';
	include 'modules/head.php'; 
	
	
	if( isset($_REQUEST['ime']) ){ //ako je poslata forma
		$ime = $_REQUEST['ime'];
		$email = $_REQUEST['email'];
		$telefon = $_REQUEST['telefon'];
		$poruka = strip_tags($_REQUEST['poruka']);
		$antispam = $_REQUEST['a'];
		//provera da li je sve uneto u odgovarajucem formatu
		$validno = true;
		$status_msg = '';
		if( !preg_match("/^[a-z ]{3,50}$/i", $ime) ){
			$validno = false;
			$status_msg .= '<p>Ime nije validno</p>';
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
		//provera poruke
		if( strlen($poruka)<10 or strlen($poruka)>1000 ){
			$validno = false;
			$status_msg .= '<p>Poruka mora imati izmedju 10 i 1000 znakova</p>';
		}
		
		if($antispam != $_COOKIE['odgovor'] ){
			$validno = false;
			$status_msg .= '<p>Pitanje nije odgovoreno</p>';
		}
		
		if($validno){
			//sve je u redu, saljem mejl
			$sadrzaj = "
Poruka sa sajta

Ime: $ime
Telefon: $telefon
Email: $email
Poruka:
$poruka
";
			mail('kontakt@sajt.com', 'Poruka sa sajta', $sadrzaj);
			
		} else {
			echo $status_msg;
		}
		
	}
	
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row">
			<div class="col-sm-12 col-md-9 sadrzaj">
				<h1>Kontakt</h1>
				<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2830.2964623471985!2d20.4575944151188!3d44.81552468451241!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x475a7ab269084adb%3A0x1d3d037c60ce3599!2sCET+-+Computer+Equipment+and+Trade!5e0!3m2!1sen!2srs!4v1452527531592" width="100%" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
				<form method="post" action="kontakt.php"  role="form">
					<div class="container-fluid kontakt-forma">
						<div class="row">
							<div class="col-sm-4">
									<div class="form-group">
										<label for="ime">
											Ime i prezime
										</label>
										<input type="text" id="ime" name="ime"  class="form-control"  placeholder="Pera Peric" />
									</div>
									<div class="form-group">
										<label for="email">
											Email
										</label>
										<input type="text" name="email" class="form-control" placeholder="pera@peric.com" />
									</div>
									<div class="form-group">
										<label for="telefon">
											Telefon
										</label>
										<input type="text" name="telefon" class="form-control" placeholder="+381.11/123-4567" />
									</div>
							</div>
							<div class="col-sm-8">
									<div class="form-group">
										<label for="poruka">
											Poruka
										</label>
										<textarea class="form-control" id="poruka" style="height:183px" name="poruka"></textarea>
									</div>
									Anti-spam kontrola: <?= $provera_a ?> + <?= $provera_b ?> = <input type="text" name="a" />
									<input class="btn btn-default" type="submit" value="Pošalji" />
							</div>
						</div>
					</div>
				</form>
			</div>
			<div class="col-sm-12 col-md-3 sidebar">
				<aside>
					<?php include 'modules/specijalna-ponuda.php'; ?>
					<?php include 'modules/last-minute.php'; ?>
					<?php include 'modules/prijava_za_posao.php'; ?>
				</aside>
			</div>
		</div>

<?php include 'modules/footer.php'; ?>
