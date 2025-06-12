using System;


public class Korisnik
//-----------------------------------------------
{
    public Korisnik()
    {
    }
    
    public int IdDoz { get; set; }
    public string IdDozC { get; set; }
    public string Broj { get; set; }
    public string Ime { get; set; }
    public string Zvanje { get; set; }
    public string Preduzece { get; set; }
    public string OrgDeo { get; set; }
    public string Reon { get; set; }
    public string BrLK { get; set; }
    public string SUP { get; set; }
    public string Datum { get; set; }
    public int Stampa { get; set; }
   // public string Izdata { get; set; }

}

public class Overa
//-----------------------------------------------
{
    public Overa()
    {
    }

    public int IdDoz { get; set; }
    public string Broj { get; set; }
    public int Godina { get; set; }
   

}



