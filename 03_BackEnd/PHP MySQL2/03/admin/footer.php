<?php 
$_TITLE = 'Admin Panel';
include 'modules/head.php'; 

if( isset( $_REQUEST['footer'] ) ){
	// treba da se $_REQUEST['footer'] upise u fajl data/footer.txt, umesto postojece
	$novifajl =  strip_tags( $_REQUEST['footer'], 
							 '<p><br><a><h4><h5><h6>' );
	file_put_contents( '../data/footer.txt', $novifajl );
}


?>
<script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
<script>tinymce.init({ selector:'.editor-teksta' });</script>
	<div class="container">
		<h1>Izmena footera</h1>
		
		<form action="footer.php" method="post">
			<div class="form-group">
				<label for="poruka">
					Footer
				</label>
				<textarea class="form-control editor-teksta" 
					style="height:200px" 
					name="footer"><?php readfile('../data/footer.txt'); ?></textarea>
			</div>
			<input class="btn btn-primary" 
				type="submit" value="Sacuvaj promene" />
			<a href="index.php" class="btn btn-link">Ponisti</a>
		</form>
	</div>
<?php include 'modules/footer.php'; ?>
