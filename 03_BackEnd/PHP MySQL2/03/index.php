<?php 
	$_TITLE = 'Pocetna';
	include 'modules/head.php'; 
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row">
			<div class="col-sm-12 col-md-9 sadrzaj">
				<h1>CET ŠKOLA RAČUNARA</h1>
				<iframe width="100%" height="315" src="https://www.youtube.com/embed/BcNgSCjjjlc" frameborder="0" allowfullscreen></iframe>
				<article>
					<h3><span class="cet">CET</span> na Sajmu knjiga 2015.</h3>
					<p>
						Na Sajmu knjiga u Beogradu (od 25.oktobra – 1.novembra 2015.) <span class="cet">CET</span> je predstavio nove naslove: <b>Autodesk Revit</b>, <b>Naučite programiranje</b>, <b>Uvod u Pyton</b>, <b>Web programiranje</b>, <b>IOS 8</b>.
						<br/><a class="readmore btn btn-info" href="#">Opširnije</a>
					</p>
				</article>
				<article>
					<h3>U prodaji Office 2016</h3>
					<p>
						Odeljenje <span class="cet">CET</span> softvera započelo je prodaju najnovijeg Office 2016, koji je dodatak Office 365 Microsoft pretplatničkom servisu baziranom na cloud-u. <br/>
						Office 2016 aplikacije prvenstveno pomažu timskom radu.
						<br/><a class="readmore btn btn-info" href="#">Opširnije</a>
					</p>
				</article>
				<article>
					<h3>Besplatno testiranje</h3>
					<p>
						Kompanija <span style="color:#03D8B5; font-weight:bold">CET</span> je pokrenula besplatan online test Excel-a za sve one koji žele da provere svoje znanje ovog popularnog programa. <br/>
						Odgovarajući na postavljena pitanja možete proveriti da li je vaš nivo znanja odgovarajući ili je potrebno da dođete na obuku.
						<br/><a class="readmore btn btn-info" href="#">Opširnije</a>
					</p>	
				</article>			
			</div>
			<div class="col-sm-12 col-md-3 sidebar">
				<aside>
					<?php include 'modules/specijalna-ponuda.php'; ?>
					<?php include 'modules/last-minute.php'; ?>
				</aside>
			</div>
		</div>
<?php include 'modules/footer.php'; ?>