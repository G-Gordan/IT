<?php 
	$_TITLE = 'Kontakt';
	include 'modules/head.php'; 
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
				<form method="post" action="#"  role="form">
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
