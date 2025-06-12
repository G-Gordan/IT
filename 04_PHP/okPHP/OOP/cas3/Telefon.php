<?php

class Telefon{

    private $marka;
    private $model;
    private $cena;
    private $boja;
    
    public function __construct($m,$mo, $c,$b){
        $this->marka=$m;
        $this->model=$mo;
        $this->cena=$c;
        $this->boja=$b;
    }
        
    
    public function getMarka(){
        return $this->marka;
    }

    public function getModel(){
        return $this->model;
    }
    
    public function getCena(){
        return $this->cena;
    }

    public function getBoja(){
        return $this->boja;
    }
    
 public function __toString()
 {
     return "Marka telefona je ".$this->getMarka(). " model telefona je ".$this->getModel(). " cena telefona je ".$this->getCena()."$"." boja telfona je ".$this->getBoja()."."; 
 }
} 
$nokia= new Telefon("Nokia","9",560,"crna");
$samsung= new Telefon("Samsung","s10",1000,"bela");

echo $nokia."<br>";
echo $samsung;
?>