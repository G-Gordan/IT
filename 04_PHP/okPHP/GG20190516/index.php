<?php
include_once ("connection.php");

include_once ("insert.php");


//try {

// U P D A T E
//$sql = "UPDATE kategorije SET kategorija='RL' , opis='Rolsule', trajanje=11 WHERE kategorija='SK' ";
//$stmt = $conn->prepare($sql);
//$stmt->execute();
//$conn->exec($sql);

// U P D A T E - Brise samo odredjena polja, postavljanjem NULL vrednosti
//$sql = "UPDATE kategorije SET kategorija=NULL , trajanje=NULL WHERE kategorija='RL' ";
//$stmt = $conn->prepare($sql);
//$stmt->execute();
//$conn->exec($sql);

/*
    echo "Novi slog je uspešno unet";
    print("<br>");
    
  }   catch(PDOException $e)
    {
    echo "Error: " . $e->getMessage();
    }
*/



/*
// D E L E T E
$sql = "DELETE FROM kategorije WHERE kategorija='BC' ";
$conn->exec($sql);
*/



/*
// S E L E C T i prikaz kroz niz
$stmt = $conn->prepare("SELECT kategorija, opis, trajanje FROM kategorije");
$stmt->execute();*/
/* uzima sve slogove iz query-ja i postavlja u rezultat */
/*print("Rezultat postavljenog query-ja:\n");
$result = $stmt->fetchAll(PDO::FETCH_ASSOC);
print('<pre>');
print_r($result);
print('</pre>');
//echo '<pre>', print_r($result), '<pre>';
*/

// S E L E C T i prikaz kroz tabelu
/*echo "<table style='border: solid 1px black;'>";
echo "<tr><th>Kategorija</th><th>Opis</th><th>Trajanje</th></tr>";

class TableRows extends RecursiveIteratorIterator { 
    function __construct($it) { 
        parent::__construct($it, self::LEAVES_ONLY); 
    }
    function current() {
        return "<td style='width:150px;border:1px solid black;'>" . parent::current(). "</td>";
    }
    function beginChildren() { 
        echo "<tr>"; 
    } 
    function endChildren() { 
        echo "</tr>" . "\n";
    } 
} 

try {
    $stmt = $conn->prepare("SELECT kategorija, opis, trajanje FROM kategorije GROUP BY trajanje"); 
    $stmt->execute();

    // ispisuje rezultat upita
    $result = $stmt->setFetchMode(PDO::FETCH_ASSOC); 
    foreach(new TableRows(new RecursiveArrayIterator($stmt->fetchAll())) as $k=>$rezultat) { 
        echo $rezultat;
    }
} catch(PDOException $e) {
    echo "Error: " . $e->getMessage();
}
$conn = null;
echo "</table>";
*/
$conn = null;

?>