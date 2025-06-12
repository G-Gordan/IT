<?php
class Osoba{

    private $ime;
    private $prezime;
    private $godiste;
    ///get metod ima kljucnu rec return i sluzi da nam vrati

 public function getIme(){
     return $this->ime;
 }  
 public function getPrezime(){
     return $this->prezime;
 }
 public function getGodiste(){
    return $this->godiste;
}
 ///set metode sluze za dodeljivanje vrednosti atributima
 public function setIme($i){
     if (strlen($i)>2) {
         $this->ime=$i;
     }else{
         echo "Ime mora sadrzati bar 3 karakter<br>";
     }
   
}
 public function setPrezime($p){
     $this->prezime=$p;
  
}
public function setGodiste($g){
    if ($g<1920 or $g>2019) {
        echo "Neispravno godiste<br>";
    }else{
        $this->godiste=$g;
    }
    
}  
   
}
//// kreiranje objekat van klase 
$osoba = new Osoba();
$osoba->setIme('Ana');
$osoba->setPrezime('Maric');
$osoba->setGodiste('1910');
echo $osoba->getPrezime();
echo $osoba->getIme();
echo $osoba->getGodiste();

?>