<?php 
require '../dbconnect.php';

$_TITLE = 'Admin Panel';
include 'modules/head.php'; 
?>
	<div class="container">
		<h1>Vesti</h1>
		<table class="table">
			<thead>
				<tr>
					<td>Naslov</td><td>Datum</td><td>Akcije</td>
				</tr>
			</thead>
			<tbody>
				<?php
				$rez = $db->query('select id,naslov,datum from vest');
				while(  $vest = $rez->fetch_object()  ){
					?>
					<tr>
						<td><?= $vest->naslov ?></td>
						<td><?= $vest->datum ?></td>
						<td>
							<a href="vesti-edit.php?id=<?= $vest->id ?>">
								<i class="fa fa-pencil"></i> Izmeni
							</a>
							<a href="javascript:void(0)" 
								onclick=" if( window.confirm('Potvrdite brisanje') ){ window.location = 'vesti-obrisi.php?id=<?= $vest->id ?>'; } ">
								<i class="fa fa-times" style="color:red"></i> Obrisi
							</a>
						</td>
					</tr>
					<?php
				}
				?>
			</tbody>
		</table>
		<a href="vesti-dodaj.php" class="btn btn-primary">Dodaj novu vest</a>
	
	</div>
<?php include 'modules/footer.php'; ?>
