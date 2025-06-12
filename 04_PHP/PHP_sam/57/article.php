<?php
include 'header.php';
?>

<h1>Article page</h1>

<div class="article-container">
	<?php

		$title = mysqli_real_escape_string($conn, $_GET['search']);// stavlja GET umesto POST metoda da bi se rezultat video u URL-u
		$date = mysqli_real_escape_string($conn, $_GET['date']);

		$sql="SELECT * FROM article WHERE a_title=$title AND a_date=$date";
		$result=mysqli_query($conn, $sql);
		$queryResult=mysqli_num_rows($result);

		if ($queryResult > 0) {
			while ( $row = mysqli_fetch_assoc($result)) {
				echo "<div class='article-box'>
					<h3>".$row['a_title']."</h3>
					<p>".$row['a_text']."</p>
					<p>".$row['a_date']."</p>
					<p>".$row['a_author']."</p>
				</div>"
			}
		}
	?>
	
</div>
		
	</body>
</html>