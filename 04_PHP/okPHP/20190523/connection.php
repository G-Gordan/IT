<?php
//$servername = "127.0.0.1";
$servername = "localhost";
$username = "root";
$password = "";
$dbname= "cas10oop";

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    // set the PDO error mode to exception
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    echo "Connected successfully"; 
    //$sql = "INSERT INTO kategorije(kategorija, opis, trajanje) VALUES ('Z', 'Zmaj', 180)";
    //$conn->exec($sql);
    //$stmt = $conn->prepere($sql);// bindovanje
    //$stmt->execute();
    //echo "Query successfully"; 
    }
catch(PDOException $e)
    {
    echo "Connection failed: " . $e->getMessage();
    }

try {
    $sql = "INSERT INTO kategorije(kategorija, opis, trajanje) VALUES ('Z', 'Zmaj', 180)";
	$conn->exec($sql);
	/*$sql = "INSERT INTO kategorije(kategorija, opis, trajanje) VALUES ('Z', 'Zmaj', 180)";
	$conn->exec($sql);
    $sql = "INSERT INTO kategorije(kategorija, opis, trajanje) VALUES ('Z', 'Zmaj', 180)";
    $conn->exec($sql);// INSERT, UPDATE, DELETE 
    //$stmt = $conn->prepare($sql); // SELECT
    //$stmt->execute();*/
    echo "Query successfully"; 
    }
catch(PDOException $e)
    {
    echo "Error: " . $e->getMessage();
    }

$conn = null;


    //$stmt = $conn->prepare("DELETE * FROM messages WHERE id = 2"); 
    //$stmt->execute();
?>
<!--
https://www.w3schools.com/php/php_mysql_connect.asp
https://www.w3schools.com/php/php_mysql_select.asp

SELECT * FROM vozila WHERE godiste > 2000 AND model LIKE '%a%' GROUP BY cena DESC LIMIT 3;
SELECT * FROM vozila WHERE idvozila = 5 AND idvozila < 6 OR idvozila = 4;
SELECT * FROM vozila WHERE idvozila = 5 AND idvozila < 3 OR idvozila = 4;
SELECT * FROM visina;
SELECT * FROM visina WHERE visina < 170 OR visina < 190 AND visina > 180 AND visina = 193;
SELECT * FROM visina WHERE visina < 170 OR visina < 190 AND visina > 180;
-->