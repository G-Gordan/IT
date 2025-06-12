Imports System.Data.SqlClient
Module KalkModulRO
    Public Sub bNadjiPrevozninuRO()

        ' nacin obracuna ( vrsta povlastice - cene ) moze da bude:
        '       - "1" povlastica ( koeficijent ) na redovnu tarifu 
        '       - "2" cena po toni
        '       - "3" cena po tonskom stavu ( daje se konkretna cena za 10-to tonski, 15-to tonski ...)
        '       - "4" cena po kolima
        '       - cena po UTI-ju - univerzalne
        '       - cena po UTI kombinaciji 

        ' sve povlastice i cene mogu da zavise od:
        '       - relacije ( otpravna i uputna stanice )
        '       - parametara samih kola :
        '               vlasnistva ( Z, P, I )
        '               serije kola
        '               vrste kola ( obicna, specijalna )
        '               ( tovarena, prazna )
        '               broja osovina
        '       - vrste kolske posiljke
        '               za pojedinacna kola
        '               za grupu kola
        '               za voz
        ' teoretski, postoji mogucnost da data povlastica - cena ne zavisi ni od jednog gornjeg parametra, 
        '       tj. da vazi za bilo koju vrednost odredjenog parametra ( bilo koju relaciju, bilo koju vrstu kola, ... )

        ' u jednom ugovoru mogu da se kombinuju cene, na pr. po toni ( za tovarena kola ) i po kolima ( za prazna kola )



        ' Procedure za redovne tarife:
        '               NadjiPrevozninu00T                            spt31 i spt36



    End Sub
    Public Sub bProveriUgovorKP()
        ' uslovi ( parametri ) koji se proveravaju:
        '           broj ugovora
        '           vrsta saobracaja
        '           datum
        '           otpravna stanica
        '           uputna stanica
        '           vlasnistvo kola ( Z-zeleznicka, P-privatna, I-u zakupu )
        '           vrsta kola ( D-specijalna, N-obicna )
        '           serija kola 
        '           status ( T- tovaren UTI, P-prazan UTI )
        '       -   NHM pozicija
        '           
        ' svi parametri moraju da se podudaraju, osim za one gde ugovori vaze za bilo koju vrednost
    End Sub
    Public Sub bNadjiCenuKoeficijentIzUgovoraKP()

        ' - 13 tacaka ( po ugovorima )
        '       -   1. broj ugovora i dopune ( aneksa )
        '       -   2. korisnik prevoza ( ne utice na kalkulaciju, samo se evidentira )
        '       -   3. podrucje vaznosti ( otpravne i uputne stanice )
        '       -   4. vrsta stvari ( NHM )
        '       -   5. primenjena tarifa ( redovna - spt36, TEA... )
        '       -   6. nacin otpreme ( tip kola - vlasnistvo )
        '       -   7. povlastica - vrsta i iznos ( koeficijent(procenat), stav po toni, kolima, posiljci , sa konkretnom relacijom... );
        '               u ovoj tacki mogu da budu navedeni i dodatni uslovi-troskovi ( za osovinsko opterecenje, ... )
        '       -   8. nacin racunanja naknada ( i opstih tarifskih propisa - ? a tacka 5.? )
        '       -   9. odstupanje od opstih i tarifskih odredaba ( ? a tacka 7.? )
        '       - 10. platilac troskova ( ne utice na kalkulaciju, samo se evidentira )
        '       - 11. popunjavanje zahteva u tovarnom listu ( ne utice na kalkulaciju )
        '       - 12. posebne odredbe ( uglavnom ne utice na kalkulaciju  )
        '       - 13. rok vaznosti ( datum )
        ' 
        ' 
        'ulazni parametri:
        '       - broj ugovora
        '                           - broj aneksa
        '       - stanica od
        '       - stanica do
        '       - vlasnistvo kola ( Z-zeleznicka, P-privatna, I-u zakupu )
        '       - vrsta kola ( D-specijalna, N-obicna )
        '       - serija kola
        '       - status ( T- tovaren UTI, P-prazan UTI )
        '       - NHM pozicija
        '       - sifra naknade        
        '       - datum tarifiranja

        'izlazni parametri
        '       - cena
        '       - koeficijent
        '       - valuta
        '       - nacin obracuna ( obrade )
        '       - iznos naknade
        '       - porez
        '       - min prevoznina
        '       - min prevoznina iznos
        '       - uprava
        '       - sifra korisnika
        '       - saobracaj
        '       - sifra komitenta
        '       - naziv komitenta



    End Sub

End Module
