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
					<td>Naziv</td><td>Pocinje</td><td></td><td>Akcije</td>
				</tr>
			</thead>
			<tbody>
			
				<?php
				
				$rez = $db->query('select id,naziv,pocinje,specijalna_ponuda from proizvod');
				while(  $proizvod = $rez->fetch_object()  ){
					?>
					<tr>
						<td><?= $proizvod->naziv ?></td>
						<td><?= $proizvod->pocinje ?></td>
						<td><?php 
								if($proizvod->specijalna_ponuda){
									echo ' <i class="fa fa-check-circle" style="color:green"></i> ';
								} // else - nista, nije specijalna ponuda...
							?></td>
						<td><i class="fa fa-pencil"></i> <i class="fa fa-times" style="color:red"></i>  </td>
					</tr>
					<?php
				}
				?>
			</tbody>
		</table>
		
	</div>
<?php include 'modules/footer.php'; ?>
