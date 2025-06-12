<?php
//$servername = "127.0.0.1";
$servername = "localhost";
$username = "root";
$password = "";
$dbname= "cas10oop";

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    echo "Connected successfully";
    print("<br>");
    }
catch(PDOException $e)
    {
    echo "Connection failed: " . $e->getMessage();
    }

try {

    //$sql = "INSERT INTO kategorije(kategorija, opis, trajanje) VALUES ('Z', 'Zmaj', 180)";
    //$conn->exec($sql);

    // $sql = "UPDATE kategorije SET kategorija='TR', opis='Trotinet', trajanje='222' WHERE kategorija='Z'";
    // $conn->exec($sql);

     $sql = "DELETE FROM kategorije WHERE kategorija='TR'";
     $conn->exec($sql);

    /*
    $stmt = $conn->prepare("SELECT kategorija, opis, trajanje FROM kategorije");
    $stmt->execute();
    $result = $stmt->fetch(PDO::FETCH_ASSOC);
    print_r($result);
    print("\n");
    */
    echo "Query successfully";
    print("<br>");

    }
catch(PDOException $e)
    {
    echo "Error: " . $e->getMessage();
    }

$conn = null;

?>
<!--
    //$sql = "INSERT INTO kategorije(kategorija, opis, trajanje) VALUES ('Z', 'Zmaj', 180)";
    //$conn->exec($sql);// INSERT, UPDATE, DELETE - exec semo prosledjuje qury
    //$stmt = $conn->prepare($sql);
    //$stmt->execute(); // SELECT - execute prosledjuje i vraca rezultat
-->