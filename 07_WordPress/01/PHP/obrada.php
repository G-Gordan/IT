<?php
if(isset($_POST['posalji']))
{ 
	if ((empty($_POST['Godine'])) and (empty($_POST['Ime'])))
	{
		echo "Molimo da unesete godine i ime";
	}

	else if(empty($_POST['Ime']))
	{
	
		echo "Molimo da unesete ime";
		
	}
	else if (empty($_POST['Godine']))
	{
		echo "Molimo da unesete godine";
	}
	
	else
	{
		echo $_POST['ime']. "ima" .$_GET['godine']. "godina" ; 
	}
	
}


?>