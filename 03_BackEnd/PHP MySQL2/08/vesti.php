<?php 
	$_TITLE = 'Vesti';
	include 'modules/head.php'; 
?>
	<div class="container-fluid">
		<div class="row">
			<?php include 'modules/header.php'; ?>
			<?php include 'modules/nav.php'; ?>
		</div>
		<div class="row">
			<div class="col-sm-12 col-md-9 sadrzaj">
				<h1>VESTI</h1>
				<form method="get" action="vesti.php">
					<input type="text" name="filter" />
					<input type="submit" value="Pretrazi" />
				</form>
				<?php
					if(isset($_REQUEST['filter']) and $_REQUEST['filter']){
						echo '<p>
								Prikazuju se vesti koje sadrze termin "' . $_REQUEST['filter'] . '"
							</p>';
					}
				?>
				
				<?php
					require_once "dbconnect.php";
					$upit = 'select id,naslov,kraci_opis from vest where 1 ';
					
					if(isset($_REQUEST['filter']) and $_REQUEST['filter']!=''){
						//$upit .= ' AND naslov LIKE "%'. $_REQUEST['filter'] .'%" ';
						
						$filter = $db->real_escape_string($_REQUEST['filter']);
						
						$upit .= "  AND (
								naslov LIKE '%{$filter}%' 
								OR kraci_opis LIKE '%{$filter}%'
								OR pun_opis LIKE '%{$filter}%' 
										) ";
					}
					
					$rez = $db->query($upit);
					while(  $vest = $rez->fetch_object()  ){
						?>
							<article>
								<h3><?= $vest->naslov ?></h3>
								<div>
									<p><?= $vest->kraci_opis ?></p>
									<a href="vest.php?id=<?= $vest->id ?>">Opsirnije</a>
								</div>
							</article>
						<?php
					}
				?>
				
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