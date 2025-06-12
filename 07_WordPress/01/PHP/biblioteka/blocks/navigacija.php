<a href="index.php">Naslovna</a>

<?php
if((Isset($_SESSION['id']))):   ?>
<a href="login.php">login</a>
<a href="registration.php">registracija</a>

<?php endif/ ?>


<?php if((Isset($_SESSION['id']))):   ?>
<a href="add_author.php">dodaj autora</a>
<a href="add_book.php">dodaj knjigu</a>
<?php endif/ ?>



<?php if((Isset($_SESSION['id']))):   ?>
<a href="logout.php">Logout</a>
<?php endif/ ?>
