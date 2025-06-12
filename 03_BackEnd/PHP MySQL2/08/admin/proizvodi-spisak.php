<?php 
require '../dbconnect.php';

$_TITLE = 'Admin Panel';
include 'modules/head.php'; 
?>
	<div class="container">
		<h1>Proizvodi</h1>
		<table class="table">
			<thead>
				<tr>
					<td>Naziv</td>
					<td>Kategorija</td>
					<td>Pocinje</td>
					<td></td>
					<td>Akcije</td>
				</tr>
			</thead>
			<tbody>
				<?php
				/* prvi nacin - ako spajam kroz php
				$rez = $db->query('select * from proizvod');
				while(  $proizvod = $rez->fetch_object()  ){
					
					$rez2 = $db->query("select * from kategorija 
										where id = " .$proizvod->kat_id );
					$kat = $rez2->fetch_object();
				*/	
				//drugi nacin - ako sql spaja
				$rez = $db->query("select proizvod.*, 
											kategorija.naziv as 'kategorija'
									from proizvod
									join kategorija on kategorija.id=proizvod.kat_id
								");
				while(  $proizvod = $rez->fetch_object()  ){
					?>
					<tr>
						<td><?= $proizvod->naziv ?></td>
						
						<?php /*  <td><?= $kat->naziv ?></td> */ ?>
						<td><?= $proizvod->kategorija ?></td>
						
						<td><?= $proizvod->pocinje ?></td>
						<td><?php 
								if($proizvod->specijalna_ponuda){
									echo ' <i class="fa fa-check-circle" style="color:green"></i> ';
								} // else - nista, nije specijalna ponuda...
							?></td>
						<td>
							<a href="proizvodi-edit.php?id=<?= $proizvod->id ?>">
								<i class="fa fa-pencil"></i> 
							</a>
							<i class="fa fa-times" style="color:red"></i>  
						</td>
					</tr>
					<?php
				}
				?>
			</tbody>
		</table>
		<a href="">Dodaj nov proizvod</a>
	</div>
<?php include 'modules/footer.php'; ?>
