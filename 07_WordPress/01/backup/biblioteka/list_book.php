<?php include("blocks/header.php"); ?>
<?php
$knjige = $conn->query("SELECT * FROM knjige");
$nizovi = $knjige->fetch_all();
?>


<ol>
<?php foreach($nizovi as $knjiga){ ?>

	<li><?php echo $knjiga[1] ?> - <?php echo $knjiga[3] ?></li>
	
<?php } ?>
</ol>