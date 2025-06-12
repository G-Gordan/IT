<?php 
require '../dbconnect.php';

$_TITLE = 'Admin Panel';
include 'modules/head.php'; 
?>
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

<script>
	$(function(){
		$('.datum').datepicker({
			dateFormat: 'yy-mm-dd'
		});
	});
</script>

	<div class="container">
		<h1>Vesti</h1>
		<table class="table">
			<thead>
				<tr>
					<script>
						function reset_filter(){
							$("#filter_od").val('');
							$("#filter_do").val('');
							$("#filter_naslov").val('');
							$("#filter_form").submit();
						}
					</script>
					<form method="get" action="vesti-spisak.php" id="filter_form">
						<td>
							<input type="text" id="filter_naslov" name="filter_naslov" 
									value="<?php if(isset($_REQUEST['filter_naslov'])) echo $_REQUEST['filter_naslov'] ?>" />
						</td>
						<td>
							<input type="text" id="filter_od" name="filter_od" size="7" 
									class="datum" value="<?php if(isset($_REQUEST['filter_od'])) echo $_REQUEST['filter_od'] ?>" /> -
							<input type="text" id="filter_do" name="filter_do" size="7" 
									class="datum" value="<?php if(isset($_REQUEST['filter_do'])) echo $_REQUEST['filter_do'] ?>" />
						</td>
						<td>
							<input type="button" value="Ocisti" onclick="reset_filter()" />
							<input type="submit" value="Pretrazi" />
						</td>
					</form>
				</tr>
				<tr>
					<td>Naslov</td><td>Datum</td><td>Akcije</td>
				</tr>
			</thead>
			<tbody>
				<?php
				$upit = 'select id,naslov,datum from vest WHERE 1 '; //pripremam se za eventualne uslove...
				if( isset($_REQUEST['filter_od']) and $_REQUEST['filter_od']!='' ){
					$upit .= " AND datum >= '{$_REQUEST['filter_od']}' ";
				}
				if( isset($_REQUEST['filter_do']) and $_REQUEST['filter_do']!='' ){
					$upit .= " AND datum <= '{$_REQUEST['filter_do']}' ";
				}
				if( isset($_REQUEST['filter_naslov']) and $_REQUEST['filter_naslov'] ){
					$upit .= " AND naslov LIKE '%{$_REQUEST['filter_naslov']}%' ";
				}
				
				//echo $upit; 
				
				$rez = $db->query($upit);
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
