<?php
//include_once ("connection.php");
/*
include_once ("insert.php");
Insert();
*/

// K O N E K C I J A
//$servername može biti IPadd ili domen
//$servername = "127.0.0.1";
$servername = "localhost";
$dbname="cas10oop";
$username = "root";
$password = "";

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

// I N S E R T
//try {
	
	// INSERT - opcija 1
	//$sql=("INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES('X', 'X man', 888888)");
	//$conn->exec($sql);
	// prepare sql
	////$stmt = $conn->prepare("INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES('G', 'Podmornica', 100)"); 
	//$stmt = $conn->prepare("INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES('S', 'Supersonic', 10000)"); 
	//$stmt = $conn->prepare($sql);
  	//$stmt->execute();
  
	// INSERT - opcija 2
   /*$sql = "INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES('G', 'Podmornica', 100)";
 	$stmt = $conn->prepare($sql);
  	$stmt->execute();
  	 */

 // INSERT - opcija 3 
 /*
$stmt = $conn->prepare("INSERT INTO kategorije (kategorija, opis, trajanje) VALUES (?, ?, ?)");
$stmt->bindParam(1, $val1);
$stmt->bindParam(2, $val2);
$stmt->bindParam(3, $val3);
$val1 = 'TR';
$val2 = 'Trotinet';
$val3 = 1;
$stmt->execute();
  */
/*
	// INSERT - opcija 4
 	$stmt = $conn->prepare("INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES(:kategorija, :opis, :trajanje)"); 
    // priprema i povezivanje argumenata (parametara) sa poljima tabele
    $stmt->bindParam(':kategorija', $kategorija);
    $stmt->bindParam(':opis', $opis);
    $stmt->bindParam(':trajanje', $trajanje);
    //ubacivanje sloga podataka u  tabelu baze
    $kategorija = "T";
    $opis = "Traktor";
    $trajanje = 3;
    $stmt->execute();
    
    //ubacivanje novog sloga podataka u  tabelu baze
    $kategorija = "BC";
    $opis = "Bicikla";
    $trajanje = 2;
    $stmt->execute();
    //ubacivanje novog sloga podataka u  tabelu baze
    $kategorija = "SK";
    $opis = "Skejt";
    $trajanje = 1;
    $stmt->execute();
 */




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
  }   
	catch(PDOException $e)
    {
    echo "Error: " . $e->getMessage();
    }
*/




/*
// D E L E T E
$sql = "DELETE FROM kategorije WHERE kategorija='BC' ";
$conn->exec($sql);
*/

// S E L E C T i prikaz kroz niz
$stmt = $conn->prepare("SELECT kategorija, opis, trajanje FROM kategorije");
$stmt->execute();
/* uzima sve slogove iz query-ja i postavlja u rezultat */
print("Rezultat postavljenog query-ja:\n");
$result = $stmt->fetchAll();
print_r($result);


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
}
catch(PDOException $e) {
    echo "Error: " . $e->getMessage();
}
$conn = null;
echo "</table>";
*/
$conn = null;

?>