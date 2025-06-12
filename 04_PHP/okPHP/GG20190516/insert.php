<?php


try {

    $sql=("INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES('Y', 'Yhuman', 12345)");
    $conn->exec($sql);
    echo "Novi slog je uspešno unet";
    print("<br>");

// I N S E R T
  
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

  }   
	catch(PDOException $e)
    {
    echo "Error: " . $e->getMessage();
    }


?>

<!--
  // prepare sql parameters
  //$stmt = $conn->prepare("INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES('S', 'Supersonic', 10000)"); 
  //$stmt = $conn->prepare("INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES('G', 'Podmornica', 100)"); 
   /*$sql = "INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES('G', 'Podmornica', 100)";
   $stmt = $conn->prepare($sq);
   */
   //$stmt->execute();
  
/*
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
*/

   /*
    $sql = "SELECT kategorija, opis, trajanje FROM kategorije";
	$result = $conn->query($sql);
    */

	//$stmt = $conn->prepare("INSERT INTO  kategorije(kategorija, opis, trajanje) VALUES('H', 'Avion', 200)"); 
    //$stmt = $conn->prepare("DELETE FROM kategorije WHERE kategorija = 'H'"); 
    //$stmt = $conn->prepare("DELETE * FROM messages WHERE id = 2"); 
    //$stmt->execute();
    //echo " - Izvršen unos!"; 

/*
    $sql = "INSERT INTO kategorije (kategorija, opis, trajanje)
    VALUES(:kategorija, :opis, :trajanje)";
    // use exec() because no results are returned
    $conn->exec($sql);
*/

/*
    // unos sledećeg reda
   $kategorija = "M";
    $opis = "Meteor";
    $trajanje = 5000;
    $stmt->execute();

    $kategorija = "R";
    $opis = "Raketa";
    $trajanje = 1000;
    $stmt->execute();
*/
-->