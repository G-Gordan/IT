<?php
if($_SESSION['access_level']>0){
?>
<div class="container-fluid" style="background-color:silver">
Zdravo <?php echo $_SESSION['username'] ?>,  <a href="user.php?akcija=logout">Odloguj se</a>
</div>
<?php } else { ?>
<div class="container-fluid" style="background-color:silver">
<a href="login.php">Login</a>
</div>
<?php } ?>