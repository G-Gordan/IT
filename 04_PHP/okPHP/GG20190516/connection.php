<?php




// K O N E K C I J A
//$servername može biti IPadd ili domen
//$servername = "127.0.0.1";
$servername = "localhost";
$dbname="cas10oop";
$username = "root";
$password = "";
  

   /* echo "Konekcija uspešna1"; 
    print("<br>");*/


try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    // postavljanje PDO error moda za exception
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    echo "Konekcija uspešna"; 
    print("<br>");
        }
    catch(PDOException $e)
    {
    echo "Konekcija neuspešna: " . $e->getMessage();
    print("<br>");
    }



/*
 print("<br>");
//$servername = "127.0.0.1";
$servername = "localhost";
$dbname="cas10oop";
$username = "root";
$password = "";

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    // set the PDO error mode to exception
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    echo "Connected successfully"; 
    }
catch(PDOException $e)
    {
    echo "Connection failed: " . $e->getMessage();
    }
    */

  /*  $stmt = $conn->prepare("INSERT INTO  messages(imeproizvodjaca, model, godiste, cena) VALUES('ZASTAVA', '101', 1970, 100)"); 
    //$stmt = $conn->prepare("DELETE * FROM messages WHERE id = 2"); 
    $stmt->execute();
*/

//$conn = null;

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