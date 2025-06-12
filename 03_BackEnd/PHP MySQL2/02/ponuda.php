<?php 
	$_TITLE = 'Ponuda';
	include 'modules/head.php'; 
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row">
			<div class="col-sm-12 col-md-9 sadrzaj">
				<h1>PONUDA</h1>
						<article>
							<h3>HTML & CSS</h3>
							<div>
								<img src="img/kursevi/html-css.jpg" alt="HTML & CSS"/>
								<p>
									HTML i CSS su osnovni gradivni elementi Interneta, jezici koji pokreću web. U ovom kursu videćete kako HTML čini osnovu weba i na koji način se CSS ugrađuje i proširuje mogućnosti HTML-a. Upoznaćete se sa mogućnostima oba jezika, njihovom sintaksom, primenom i često korišćenim tehnikama. Razumećete osnove Bootstrap biblioteke i izgradnje responsive stranica. Naučićete kako da napravite web sajt od početka, pripremite sadržaj i grafiku i prilagodite web sajt mobilnim uređajima.
								</p>
								<div class="cena">100&euro;</div>
							</div>
						</article><article>
							<h3>JavaScript & jQuery</h3>
							<div>
								<img src="img/kursevi/js.jpg" alt="JavaScript & jQuery"/>
								<p>
									JavaScript je de facto glavni jezik za dodavanje interakcije web stranicama, a jQuery njegova najpopularnija biblioteka. Web dizajneri koji poznaju JavaScript i JQuery su u bitnoj prednosti jer sa web sajtom mogu da urade mnogo više nego samo uz HTML i CSS.
								</p>
								<div class="cena">120&euro;</div>
							</div>
						</article><article>
							<h3>PHP & MySQL</h3>
							<div>
								<img src="img/kursevi/php.jpg" alt="PHP & MySQL"/>
								<p>
									Znate HTML, CSS i JavaScript i spremni ste za sledeći korak? PHP programski jezik, u sprezi sa MySQL bazom podataka, je završni korak ka izradi kompletne web aplikacije. PHP je na webu zastupljen na preko 80% sajtova, a neke popularne PHP aplikacije su Facebook, Twitter, Wikipedia, Joomla!, WordPress...
								</p>
								<div class="cena">200&euro;</div>
							</div>	
						</article><article>
							<h3>Web developer</h3>
							<div>
								<img src="img/kursevi/web.jpg" alt="Web developer"/>
								<p>
									Želite dobro plaćen posao, fleksibilno radno vreme, raznovrsne projekte? Web developer je zanimanje čija popularnost konstantno raste. Web developer može raditi sam ili u timu, po projektu ili u firmi. Mogućnosti zaposlenja nisu ograničene samo na softverske kompanije – web developeri se najčešće bave freelancing-om.
								</p>
								<div class="cena">320&euro;</div>
							</div>			
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