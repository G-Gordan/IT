<?php
require_once "dbconnect.php";
?>
<section class="specijalna-ponuda">
	<h3>Specijalna ponuda</h3>
	<?php
		$rez = $db->query('select id,naziv, cena, slika from proizvod 
							where specijalna_ponuda=1 ');
		while(  $proizvod = $rez->fetch_object()  ){
		?>
		<div>
			<img src="<?= $proizvod->slika ?>" />
			<h4><a href="proizvod.php?id=<?= $proizvod->id ?>"><?= $proizvod->naziv ?></a></h4>
			<div class="cena"><?= $proizvod->cena ?>&euro;</div>
		</div>
		<?php 
		} 
	?>
</section>