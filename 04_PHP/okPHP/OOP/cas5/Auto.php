<?php

class Auto{
    private $marka;
    private $cena;
    private $godiste;
    private $boja;
    

    public function __construct($m,$c,$b,$g)
    {
        $this->marka=$m;
        $this->cena=$c;
        $this->boja=$b;
    
        $this->godiste=$g;
    }
     public function getMarka(){
         return $this->marka;
     }
     public function getCena(){
        return $this->cena;
    }
    

    public function getGodiste(){
        return $this->godiste;
    }
    public function getBoja(){
        return $this->boja;
    }
    public function promeniCenu()
    {
        if($this->godiste<2004){
            ////auto dedeljujemo novu vrednost nakon popusta
        $popust=$this->cena*0.7;
        $this->cena=$popust;
        return $this->cena; 
        }else{
            return $this->cena;   
        }
    
    }
    public function promeniBoju($novaboja){
        $this->boja=$novaboja;
    }

    

    public function __toString(){
        return "Marka auta je ".$this->getMarka()." cena auta je ".$this->promeniCenu()."$"." boja auta je ".$this->getBoja()." godiste auta je ".$this->getGodiste()." god"; 
    }


    }


?>