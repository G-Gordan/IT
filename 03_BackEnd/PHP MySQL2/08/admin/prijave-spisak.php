<?php 
require '../dbconnect.php';

$_TITLE = 'Admin Panel';
include 'modules/head.php'; 
?>
	<div class="container">
		<h1>Prijave</h1>
		<table class="table">
			<thead>
				<tr>
					<td>Ime i prezime</td><td>Telefon</td><td>Email</td><td>Fajl</td>
				</tr>
			</thead>
			<tbody>
				<?php
				$upit = 'select * from prijava_za_posao ';
				$rez = $db->query($upit);
				while(  $p = $rez->fetch_object()  ){
					?>
					<tr>
						<td><?= $p->ime_i_prezime ?></td>
						<td><?= $p->telefon ?></td>
						<td><?= $p->email ?></td>
						<td>
							<a href="../<?= urlencode($p->cv) ?>">
								<?= $p->cv ?>
							</a>
						</td>
					</tr>
					<?php
				}
				?>
			</tbody>
		</table>
	</div>
<?php include 'modules/footer.php'; ?>
