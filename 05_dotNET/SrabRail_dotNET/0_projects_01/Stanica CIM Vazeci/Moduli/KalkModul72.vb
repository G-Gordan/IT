Imports System.Data.SqlClient

Module KalkModul72
    Public Sub bNadjiPrevozninu72L(ByVal Tabela As String, ByRef Prevoznina As Decimal)
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        'Dim RedniBroj As Int32
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, NHM As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1

        Dim Masa1R, Masa2R, Masa3R As Integer
        Dim MasaTemp As Integer
        Dim Razred As String
        Dim TonskiStav As String
        Dim Prev1R, Prev2R, Prev3R As Decimal
        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim TonskiStavInteger As Integer

        Dim PrevozninaPoKolima As Decimal = 0
        Dim RacMasaPoKolima As Integer

        Dim bDoTona As String
        Dim bStitna As String

        If mVrstaSaobracaja = 0 Then
            bDoTona = "25"
        Else
            bDoTona = "45"
        End If

        Dim Ka As Decimal = 1

        'If mBrojUg = "200379" Then 'Uss ex-im
        '    bStavKoef = 0.5
        'End If

        Prevoznina = 0
        bRedovanOrocen = "R"


        If dtKola.Rows.Count > 0 Then
            'RedniBroj = 0
            For Each KolaRed In dtKola.Rows    ' petlja po kolima
                ' ucitavanje polja

                'dodeliti vrednosti za promenljive

                IBK = KolaRed.Item("IndBrojKola")
                Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                TipKola = Left(KolaRed.Item("Tip"), 1)
                Vlasnistvo = KolaRed.Item("Vlasnik")
                BrOsovina = KolaRed.Item("Osovine")
                bStitna = KolaRed.Item("Stitna")

                '$$$
                If Vrsta = "O" Then
                    Vrsta = 1
                End If
                If Vrsta = "S" Then
                    Vrsta = 2
                End If
                '$$$

                '14.06.
                'TipKola = "7"
                If TipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If

                '"M" - ista je min prevoznina za granicnu stanicu i stanicu na mrezi
                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, "M", Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

                Dim Masa100 As Integer
                If dtNhm.Rows.Count > 0 Then
                    Masa1R = 0
                    Masa2R = 0
                    Masa3R = 0
                    Prev1R = 0
                    Prev2R = 0
                    Prev3R = 0

                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            Razred = NHMRed.Item("R")
                            bZaokruziMasuNa100k(MasaTemp)
                            '### 
                            '''xxNHMRed.Item("RacMasaNHM") = MasaTemp
                            '### 

                            Select Case Razred                                        ' grupisanje po razredima
                                Case "1"
                                    Masa1R = Masa1R + MasaTemp
                                Case "2"
                                    Masa2R = Masa2R + MasaTemp
                                Case "3"
                                    Masa3R = Masa3R + MasaTemp
                            End Select
                        End If
                    Next

                    Masa100 = Masa1R

                    PrevozninaPoKolima = 0

                    bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, bDoTona, Masa1R, Masa2R, Masa3R, TonskiStav)

                    'If (bVrstaSaobracaja = 2 Or bVrstaSaobracaja = 3) And TipKola = "7" Then
                    '    TonskiStav = "45"
                    'End If

                    ' Dodato zbog praznih kola
                    NHM = NHMRed.Item("NHM")
                    If ((Microsoft.VisualBasic.Left(NHM, 4) = "9921" Or Microsoft.VisualBasic.Left(NHM, 4) = "9922")) Then

                        TovarenaPrazna = "PK"
                        bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                                             TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                             bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                        If (mDatumKalk >= #2/1/2008#) Then
                            bDoTona = "45"
                            TonskiStav = "45"
                            'Masa1R = dtNhm.Rows(0).Item("Masa")
                            bZaokruziMasuNa100k(Masa100)
                            Masa1R = Masa100
                        Else
                            bDoTona = "25"

                            'TonskiStav = "25"
                        End If
                    End If
                    ' Dodato zbog praznih kola

                    ' -----
                    TonskiStavInteger = CType(TonskiStav, Integer)
                    MasaTemp = TonskiStavInteger * 1000
                    ' prevoznine po razredima:
                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "1", VozarinskiStav, PV)
                    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000
                    ' zaokruzivanje?
                    '###
                    If (Not (Masa1R = 0)) Then
                        bVozarinskiStavPoKolima = VozarinskiStav
                    End If
                    '###

                    Prev1R = Prev1R * bPrevozninaKoef
                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "2", VozarinskiStav, PV)
                    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000
                    ' zaokruzivanje?
                    '###
                    If (Not (Masa2R = 0) And (Masa1R = 0)) Then
                        bVozarinskiStavPoKolima = VozarinskiStav
                    End If
                    '###

                    Prev2R = Prev2R * bPrevozninaKoef
                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "3", VozarinskiStav, PV)
                    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000
                    ' zaokruzivanje?
                    '###
                    If (Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0)) Then
                        bVozarinskiStavPoKolima = VozarinskiStav
                    End If
                    '###

                    Prev3R = Prev3R * bPrevozninaKoef
                    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

                    '### xx
                    '''For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM
                    '''    If NHMRed.Item("IndBrojKola") = IBK Then
                    '''        '### 
                    '''        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    '''        Select Case NHMRed.Item("R")                                       ' grupisanje po razredima
                    '''            Case "1"
                    '''                NHMRed.Item("RacMasaNHM") = Masa1R
                    '''            Case "2"
                    '''                NHMRed.Item("RacMasaNHM") = Masa2R
                    '''            Case "3"
                    '''                NHMRed.Item("RacMasaNHM") = Masa3R
                    '''        End Select
                    '''        '### 
                    '''    End If
                    '''Next
                    '### 



                    ' Testiraj na minimalnu prevozninu
                    RacMasaPoKolima = Masa1R + Masa2R + Masa3R
                    bRacunskaMasaPoKolima = RacMasaPoKolima


                    'kao u TEA 
                    'If bStitna = "D" Then
                    '    If TovarenaPrazna = "PK" Then
                    '        'PrevozninaPoKolima = 0
                    '        PrevozninaPoKolima = 0.12 * BrOsovina * bTkm
                    '    Else
                    '        'PrevozninapoKolima ostaje
                    '    End If
                    'End If

                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                    End If

                    bZaokruziNaDeseteNavise(PrevozninaPoKolima)

                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                    KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima

                End If
                Prevoznina = Prevoznina + PrevozninaPoKolima
                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

            Next    ' petlja po kolima

        Else
            ' nema ni kola ni prevoznine
        End If

    End Sub
    Public Sub bNadjiPrevozninuNeNulaT(ByVal TarifaK72 As String, ByVal Tabela As String, ByRef Prevoznina As Decimal)
        Dim KolaRed, NHMRed As DataRow
        Dim IBK As String
        Dim MasaTemp As Integer

        Dim Razred As String

        Dim UkupnoKola As Byte
        Dim UkupnaMasa As Integer = 0
        Dim ProsecnaMasa As Integer
        Dim TipKola As String
        Dim BrOsovina As Byte
        Dim UkupnoOsovina As Integer = 0
        Dim KolKoef As Decimal
        'Dim TovarenaPrazna As String
        Dim TonskiStav As String
        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim TonskiStavInteger As Integer
        Dim PrevozninaPoKolima As Decimal

        ' Postupak:
        ' - naci zbir svih stvarnih masa ( za sva kola )
        ' - naci ukupan broj osovina ( za sva kola )
        ' - korigovati masu na osovine - ulaz: ukupna stvarna masa i ukupan broj osovina ( sva kola su ili tovarena ili prazna );
        '   ako je tarifa '44' ili '45' minimalna masa je 10000*UkupnoKola
        '   ako je tarifa '46' minimalna masa je 500000 )
        ' - tako dobijenu masu podeliti sa ukupnim brojem kola 
        ' - tako dobijenu ( prosecnu ) masu zaokruziti na 100k navise
        ' - naci tonski stav ( tj. kolonu u tablici ) uz korigovanje mase ( ako je potrebno ) u smislu granicnih masa   > NadjiMasuIStav
        ' - naci vozarinski stav ( stav iz tablice ); razred je isti za sva kola, jer je na njima po jedna ista roba
        ' - korigovati vozarinski stav ( *bStavKoef, "popust na vozarinski stav" ) i (?)zaokruziti na 10 navise
        ' - naci tip svakih kola ( kao i koeficijent )
        ' - naci prevozninu po svakim kolima kao proizvod mase i vozarinskog stava
        ' - zaokruzivanje po kolima?
        '   ako je tarifa '42' ili '43' prevozninu pomnoziti sa 0.5
        ' - testirati svaka kola na minimalnu prevozninu ( ili celu posiljku uz MinPrevPosiljke = UkupnoKola*MinPrevPoKolima ? )
        '   ako je tarifa '40' minimalna prevoznina se racuna kao tarifni stav prvog razreda 25-to tonskog stava za tkm, pomnozen sa 500000 i 
        '   sa koeficijentom bStavKoef, pa zaokruzen na 10 navise
        ' - pomnoziti prevozninu koeficijentom bPrevozninaKoef - "popust na prevozninu"

        ' - INTERNO SIFRIRANJE ZA PROMENLJIVU TarifaK:  ( prema unutr. saobracaju )
        '
        '   39 - Mesoviti vojni transport cl. 45 - 4
        '   40 - Mesoviti vojni transport cl. 45 - 6
        '   42 - Pokrivaci i nosaci pokrivaca vlasnistvo korisnika prevoza cl. 51 - 11
        '   43 - Ostali tovarni pribor u vlasnistvu korisnika prevoza cl. 52 - 9
        '   44 - Specijalna kola za prevoz plina (gasa) u gasovitom stanju i kola sa
        '           masinama za hladjenje bez prostora za tovarenje cl. 55 - 2 drugi stav
        '   45 - Prazna kola korisnika prevoza sa masinama za hladjenje bez prostora za
        '           tovarenje, kola za stanovanje, kola kuhinje, kola radionice i ostala
        '           kola korisnika prevoza koja nisu uvrstena u kolski park Zeleznice cl. 56 - 6. i cl. 39 - 8
        '   46 - Posiljaocev marsutni voz - cl. 57 - 1
        '   47 - Posiljaocev marsutni voz - cl. 57 - 5
        '   48 - Poseban voz - cl. 58 - 5
        '   49 - Grupa kola - clan 59 - 4
        '   50 - Vracanje pretega u otpravnu stanicu cl.63 - 1 pod b


        ' racunanje prosecne mase 

        UkupnoKola = dtKola.Rows.Count
        For Each KolaRed In dtKola.Rows    ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            For Each NHMRed In dtNhm.Rows                                '  da li treba dozvoliti da bude vise masa na jednim kolima 
                If NHMRed.Item("IndBrojKola") = IBK Then              '  ili treba obezbediti da bude na svim kolima po jedna roba i to ista na svim kolima ?
                    MasaTemp = NHMRed.Item("Masa")
                    UkupnaMasa = UkupnaMasa + MasaTemp
                End If
            Next
            BrOsovina = KolaRed.Item("Osovine")
            UkupnoOsovina = UkupnoOsovina + BrOsovina
        Next

        If TarifaK72 = "44" Or TarifaK72 = "45" Then
            If UkupnaMasa < 10000 * UkupnoKola Then
                UkupnaMasa = 10000 * UkupnoKola
            End If
        End If

        If TarifaK72 = "46" Then
            If UkupnaMasa < 500000 Then
                UkupnaMasa = 500000
            End If
        End If

        bZaokrMasuNaOsovineP(UkupnaMasa, bSvaTovarena, UkupnoOsovina, UkupnaMasa)


        ProsecnaMasa = UkupnaMasa / UkupnoKola                         ' prosecna masa po kolima
        bZaokruziMasuNa100k(ProsecnaMasa)                                   ' prosecna masa po kolima zaokruzena na 100k navise

        bRacunskaMasaPoKolima = ProsecnaMasa


        Prevoznina = 0

        For Each KolaRed In dtKola.Rows                                         ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            '       Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
            TipKola = Left(KolaRed.Item("Tip"), 1)
            For Each NHMRed In dtNhm.Rows                                '  da li treba dozvoliti da bude vise masa na jednim kolima 
                If NHMRed.Item("IndBrojKola") = IBK Then              '  ili treba obezbediti da bude na svim kolima po jedna roba i to ista na svim kolima ?
                    Razred = NHMRed.Item("R")                               ' u principu, ni ne treba petlja, vec da se ucita bilo koji razred
                End If
            Next

            Razred = NHMRed.Item("R")
            '       Vlasnistvo = KolaRed.Item("Vlasnik")
            '       BrOsovina = KolaRed.Item("Osovine")
            '       TovarenaPrazna = KolaRed.Item("Tovarena")


            bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

            MasaTemp = ProsecnaMasa
            bNadjiMasuIStavDo25(MasaTemp, MasaTemp, TonskiStav)

            TonskiStavInteger = CType(TonskiStav, Integer)
            MasaTemp = TonskiStavInteger * 1000

            bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, Razred, VozarinskiStav, PV)
            VozarinskiStav = bStavKoef * VozarinskiStav
            bZaokruziNaDeseteNavise(VozarinskiStav)
            bVozarinskiStavPoKolima = VozarinskiStav

            PrevozninaPoKolima = ProsecnaMasa * VozarinskiStav * KolKoef / 10 / 1000   ' u santimima
            ' kada zaokruzivanje?

            If TarifaK72 = "42" Or TarifaK72 = "43" Then
                PrevozninaPoKolima = 0.5 * PrevozninaPoKolima    ' tovarni pribor
            End If

            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef

            PrevozninaPoKolima = PrevozninaPoKolima / 100                                ' u CHF

            ' proba na minimalnu prevozninu

            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            Prevoznina = Prevoznina + PrevozninaPoKolima
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

            '### xx
            '''For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM i masa
            '''    If NHMRed.Item("IndBrojKola") = IBK Then
            '''        '### 
            '''        NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav      '???????
            '''        NHMRed.Item("RacMasaNHM") = ProsecnaMasa     '??????
            '''        '### 
            '''    End If
            '''Next
            '### 

        Next

    End Sub
    Public Sub bNadjiPrevozninuKont72L(ByRef Prevoznina As Decimal)

        Dim KolaRed, NHMRed As DataRow
        Dim IBK, VlasnistvoKola As String
        Dim DuzinaKontStr As String
        Dim DuzinaKont As Integer
        Dim mSifraKomb As String
        Dim UkupnaMasa, MasaKont As Integer

        'Dim MasaTemp As Integer

        'Dim Razred As String

        Dim UkupnoKola As Byte
        Dim TipKola As String
        Dim KolKoef As Decimal
        Dim TovarenaPrazna As String
        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim PrevozninaPoKolimaTov As Decimal = 0
        Dim PrevozninaPoKolimaPra As Decimal = 0
        Dim PrevozninaPoKolima As Decimal
        bRedovanOrocen = "R"

        ' Postupak:
        '   - na kolima moze da bude najvise osam kontejnera
        '   - sifrirati svaki kontejner:
        '       10' prazan - 1
        '       20' prazan - 2
        '       30' prazan - 3
        '       40' prazan - 4
        '       10' tovaren - 5
        '       20  tovaren - 6
        '       30' tovaren - 7
        '       40' tovaren - 8
        '   - sifrirati realnu kombinaciju kontejnera od ( 1x10' do 2x40 )
        '       ( teoretski najvise 8x10' na kolima )
        '   - grupisati prazne i tovarene kontejnere
        '   - prevesti u dozvoljene 'tarifske' kombinacije;
        '       ( prakticno je dozvoljena svaka kombinacija ciji je zbir duzina 80' )
        '   - dozvoljene kombinacije ( i cene ) za SVE TOVARENE ili SVE PRAZNE kontejnere u kombinaciji:
        '       40'         - iz tablice
        '       20'         - iz tablice
        '       2x20'       - iz tablice
        '       40' i 20'   - iz tablice
        '       3x20'       - iz tablice
        '       4x20'       - kao 2xPrevoznina(40')
        '       2x20' + 40' - kao 2xPrevoznina(40')
        '       2x40'       - kao 2xPrevoznina(40')
        '       20' + 2x30' - kao 2xPrevoznina(40') + Prevoznina(20')
        '       - par kontejnera od 10' i svaki dalji zapoceti par racuna se kao kontejner od 20'
        '       - kontejner od 30' racuna se kao kontejner od 40'
        '   - za kombinaciju TOVARENIH I PRAZNIH kontejnera:
        '       deo za tovarene se racuna kao kombinacija za tovarene
        '       deo za prazne se racuna kao Prevoznina(40') pomnozena koeicijentom
        '           0.39    - za jedan prazan od 40'
        '           0.312   - za jedan prazan od 20'
        '           0.546   - za dva prazna od 20'
        '           0.624   - za jedan prazan od 40' i jedan prazan od 20'
        '           0.702   - za tri prazna od 20'
        '       deo za tovarene i deo za prazne se saberu    
        ' - naci vozarinski stav za kombinaciju kontejnera iz tablice ; 
        ' - korigovati vozarinski stav ( *bStavKoef, "popust na vozarinski stav" ) i (?)zaokruziti na 10 navise
        ' - zaokruzivanje po kolima
        ' - pomnoziti prevozninu koeficijentom bPrevozninaKoef - "popust na prevozninu"
        ' - testirati svaka kola na minimalnu prevozninu 

        UkupnoKola = dtKola.Rows.Count

        Prevoznina = 0

        For Each KolaRed In dtKola.Rows                                         ' petlja po kolima
            Dim PraTov As String
            Dim Pra10 As Int16 = 0
            Dim Pra20 As Int16 = 0
            Dim Pra30 As Int16 = 0
            Dim Pra40 As Int16 = 0
            Dim Tov10 As Int16 = 0
            Dim Tov20 As Int16 = 0
            Dim Tov30 As Int16 = 0
            Dim Tov40 As Int16 = 0
            Dim Praznih As Int16 = 0
            Dim Tovarenih As Int16 = 0
            Dim Tov20Tar As Int16 = 0
            Dim Tov30Tar As Int16 = 0
            Dim Tov40Tar As Int16 = 0
            Dim SifKomTov As Int16 = 0          ' sifra kombinacije tovarenih
            Dim SifKomPra As Int16 = 0          ' sifra kombinacije praznih

            Dim K40 As Boolean = False
            Dim CTov(4) As Decimal
            Dim CPra(4) As Decimal

            Dim k As Int16
            For k = 0 To 4
                CTov(k) = 0
                CPra(k) = 0
            Next

            IBK = KolaRed.Item("IndBrojKola")
            '       Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
            TipKola = Left(KolaRed.Item("Tip"), 1)
            VlasnistvoKola = KolaRed.Item("Vlasnik")                            ' "Z", "P", "I"

            UkupnaMasa = 0

            For Each NHMRed In dtNhm.Rows
                If IBK = NHMRed.Item("IndBrojKola") Then
                    DuzinaKontStr = NHMRed.Item("UTI")
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    MasaKont = NHMRed.Item("Masa")


                    If Left(NHMRed.Item("NHM"), 4) = "9931" Then
                        PraTov = "Prazan"
                    End If
                    If Left(NHMRed.Item("NHM"), 4) = "9941" Then
                        PraTov = "Tovaren"
                    End If

                    Select Case DuzinaKont
                        Case 10
                            If PraTov = "Prazan" Then
                                Pra10 = Pra10 + 1
                            End If
                            If PraTov = "Tovaren" Then
                                Tov10 = Tov10 + 1
                            End If
                        Case 20
                            If PraTov = "Prazan" Then
                                Pra20 = Pra20 + 1
                            End If
                            If PraTov = "Tovaren" Then
                                Tov20 = Tov20 + 1
                            End If
                        Case 30
                            If PraTov = "Prazan" Then
                                Pra30 = Pra30 + 1
                            End If
                            If PraTov = "Tovaren" Then
                                Tov30 = Tov30 + 1
                            End If
                        Case 40
                            If PraTov = "Prazan" Then
                                Pra40 = Pra40 + 1
                            End If
                            If PraTov = "Tovaren" Then
                                Tov40 = Tov40 + 1
                                If MasaKont > 24000 Then
                                    K40 = True
                                End If
                            End If

                    End Select


                    UkupnaMasa = UkupnaMasa + MasaKont
                    '###
                    '''xxNHMRed.Item("RacMasaNHM") = MasaKont
                    '###


                End If
            Next

            Praznih = Pra10 + Pra20 + Pra30 + Pra40
            Tovarenih = Tov10 + Tov20 + Tov30 + Tov40

            ' Nadji niz cena za tkm za tovarene i prazne ( tj. odgovarajuca vrsta )
            ' CTov(0), CTov(1), ... , CTov(4)
            ' CPra(0), CPra(1), ... , CPra(4)

            Dim a As Decimal = 0

            For k = 0 To 4
                Dim KombK As String
                If k = 0 Then
                    KombK = "00100"
                ElseIf k = 1 Then
                    KombK = "10000"
                ElseIf k = 2 Then
                    KombK = "20000"
                ElseIf k = 3 Then
                    KombK = "10100"
                ElseIf k = 4 Then
                    KombK = "30000"
                End If
                bNadjiVozarinskiStavKont("131", mDatumKalk, KombK, bTkm, CTov(k), PV)
                bNadjiVozarinskiStavKont("132", mDatumKalk, KombK, bTkm, CPra(k), PV)
            Next


            If Tovarenih > 0 Then    ' deo za tovarene

                SifKomTov = 1000 * Tov40 + 100 * Tov30 + 10 * Tov20 + Tov10
                ' prva cifra - ukupno od 40', druga cifra - ukupno od 30', 
                '       treca cifra - ukupno od 20', cetvrta cifra - ukupno od 10'
                Dim SifraKalTov As Int16
                Select Case SifKomTov
                    Case 1              ' 1x10'                     1x20'
                        SifraKalTov = 1
                    Case 2              ' 2x10'                     1x20'
                        SifraKalTov = 1
                    Case 3              ' 3x10'                     2x20'
                        SifraKalTov = 2
                    Case 4              ' 4x10'                     2x20'
                        SifraKalTov = 2
                    Case 5              ' 5x10'                     3x20'
                        SifraKalTov = 3
                    Case 6              ' 6x10'                     3x20'
                        SifraKalTov = 3
                    Case 7              ' 7x10'                     4x20'               2x40'
                        SifraKalTov = 4
                    Case 8              ' 8x10'                     4x20'               2x40'
                        SifraKalTov = 4
                    Case 10             ' 1x20'                     1x20'
                        SifraKalTov = 1
                    Case 11             ' 1x20' + 1x10'             2x20'
                        SifraKalTov = 2
                    Case 12             ' 1x20' + 2x10'             2x20'
                        SifraKalTov = 2
                    Case 13             ' 1x20' + 3x10'             3x20'
                        SifraKalTov = 3
                    Case 14             ' 1x20' + 4x10'             3x20'
                        SifraKalTov = 3
                    Case 15             ' 1x20' + 5x10'             4x20'               2x40'
                        SifraKalTov = 4
                    Case 16             ' 1x20' + 6x10'             4x20'               2x40'
                        SifraKalTov = 4
                    Case 20             ' 2x20'                     2x20'
                        SifraKalTov = 2
                    Case 21             ' 2x20' + 1x10'             3x20'
                        SifraKalTov = 3
                    Case 22             ' 2x20' + 2x10'             3x20'
                        SifraKalTov = 3
                    Case 23             ' 2x20' + 3x10'             4x20'               2x40'
                        SifraKalTov = 4
                    Case 24             ' 2x20' + 4x10'             4x20'               2x40'
                        SifraKalTov = 4
                    Case 30             ' 3x20'                     3x20'
                        SifraKalTov = 3
                    Case 31             ' 3x20' + 1x10'             4x20'               2x40'
                        SifraKalTov = 4
                    Case 32             ' 3x20' + 2x10'             4x20'               2x40'
                        SifraKalTov = 4
                    Case 40             ' 4x20'                     4x20'               2x40'
                        SifraKalTov = 4
                    Case 100            ' 1x30'                     1x40'
                        SifraKalTov = 5
                    Case 101            ' 1x30' + 1x10'             1x40' + 1x20'
                        SifraKalTov = 6
                    Case 102            ' 1x30' + 2x10'             1x40' + 1x20'
                        SifraKalTov = 6
                    Case 103            ' 1x30' + 3x10'             1x40' + 2x20'       2x40'
                        SifraKalTov = 4
                    Case 104            ' 1x30' + 4x10'             1x40' + 2x20'       2x40'
                        SifraKalTov = 4
                    Case 105            ' 1x30' + 5x10'             1x40' + 3x20'   ?
                        SifraKalTov = 7
                    Case 110            ' 1x30' + 1x20'             1x40' + 1x20'
                        SifraKalTov = 6
                    Case 111            ' 1x30' + 1x20' + 1x10'     1x40' + 2x20'       2x40'
                        SifraKalTov = 4
                    Case 112            ' 1x30' + 1x20' + 2x10      1x40' + 2x20'       2x40'
                        SifraKalTov = 4
                    Case 113            ' 1x30' + 1x20' + 3x10'     1x40' + 3x20'   ?
                        SifraKalTov = 7
                    Case 120            ' 1x30' + 2x20'             1x40' + 2x20'       2x40'
                        SifraKalTov = 4
                    Case 121            ' 1x30' + 2x20' + 1x10'     1x40' + 3x20'   ?
                        SifraKalTov = 7
                    Case 200            ' 2x30'                     2x40'
                        SifraKalTov = 4
                    Case 201            ' 2x30' + 1x10'             2x30' + 1x20'    
                        SifraKalTov = 8
                    Case 202            ' 2x30' + 2x10'             2x30' + 1x20'   
                        SifraKalTov = 8
                    Case 210            ' 2x30' + 1x20'             
                        SifraKalTov = 8
                    Case 1000           ' 1x40'                     1x40' 
                        SifraKalTov = 5
                    Case 1001           ' 1x40' + 1x10'             1x40' + 1x20'
                        SifraKalTov = 6
                    Case 1002           ' 1x40' + 2x10'             1x40' + 1x20'
                        SifraKalTov = 6
                    Case 1003           ' 1x40' + 3x10'             1x40' + 2x20'       2x40'       
                        SifraKalTov = 4
                    Case 1004           ' 1x40' + 4x10'             1x40' + 2x20'       2x40'
                        SifraKalTov = 4
                    Case 1010           ' 1x40' + 1x20'             1x40' + 1x20'
                        SifraKalTov = 6
                    Case 1011           ' 1x40' + 1x20' + 1x10'     1x40' + 1x20'     
                        SifraKalTov = 6
                    Case 1012           ' 1x40' + 1x20' + 2x10'     1x40' + 1x20'
                        SifraKalTov = 6
                    Case 1020           ' 1x40' + 2x20'             1x40' + 2x20'       2x40'
                        SifraKalTov = 4
                    Case 1100           ' 1x40' + 1x30'             2x40'
                        SifraKalTov = 4
                    Case 1101           ' 1x40' + 1x30' + 1x10'     2x40' + 1x20'   ?
                        SifraKalTov = 9
                    Case 2000           ' 2x40                      2x40'
                        SifraKalTov = 4
                End Select

                Select Case SifraKalTov
                    Case 1
                        PrevozninaPoKolimaTov = CTov(1)
                    Case 2
                        PrevozninaPoKolimaTov = CTov(2)
                    Case 3
                        PrevozninaPoKolimaTov = CTov(4)
                    Case 4
                        PrevozninaPoKolimaTov = 2 * CTov(0)
                    Case 5
                        If K40 Then
                            PrevozninaPoKolimaTov = 1.2 * CTov(0)
                        Else
                            PrevozninaPoKolimaTov = CTov(0)
                        End If
                    Case 6
                        If K40 Then
                            PrevozninaPoKolimaTov = 1.125 * CTov(3)
                        Else
                            PrevozninaPoKolimaTov = CTov(3)
                        End If
                    Case 7
                        PrevozninaPoKolimaTov = CTov(0) + CTov(4)      '?
                    Case 8
                        PrevozninaPoKolimaTov = 2 * CTov(0) + CTov(1)
                    Case 9
                        PrevozninaPoKolimaTov = 2 * CTov(0) + CTov(1)  '?
                End Select

            End If

            If Tovarenih > 0 And Praznih > 0 Then   ' kombinacija tovarenih i praznih
                CPra(0) = 0.39 * CPra(0)
                CPra(1) = 0.312 * CPra(1)
                CPra(2) = 0.546 * CPra(2)
                CPra(3) = 0.624 * CPra(3)
                CPra(4) = 0.702 * CPra(4)
            End If


            If Tovarenih = 0 And Praznih > 0 Then   ' svi prazni

                Dim Uslov065 As Boolean = False     ' videti da li se ovo javlja i kako se sifrira
                If Uslov065 Then
                    For k = 0 To 4
                        CPra(k) = 0.65 * CPra(k)
                    Next

                End If

                SifKomPra = 1000 * Pra40 + 100 * Pra30 + 10 * Pra20 + Pra10
                ' prva cifra - ukupno od 40', druga cifra - ukupno od 30', 
                '       treca cifra - ukupno od 20', cetvrta cifra - ukupno od 10'
                Dim SifraKalPra As Int16
                Select Case SifKomTov
                    Case 1              ' 1x10'                     1x20'
                        SifraKalPra = 1
                    Case 2              ' 2x10'                     1x20'
                        SifraKalPra = 1
                    Case 3              ' 3x10'                     2x20'
                        SifraKalPra = 2
                    Case 4              ' 4x10'                     2x20'
                        SifraKalPra = 2
                    Case 5              ' 5x10'                     3x20'
                        SifraKalPra = 3
                    Case 6              ' 6x10'                     3x20'
                        SifraKalPra = 3
                    Case 7              ' 7x10'                     4x20'               2x40'
                        SifraKalPra = 4
                    Case 8              ' 8x10'                     4x20'               2x40'
                        SifraKalPra = 4
                    Case 10             ' 1x20'                     1x20'
                        SifraKalPra = 1
                    Case 11             ' 1x20' + 1x10'             2x20'
                        SifraKalPra = 2
                    Case 12             ' 1x20' + 2x10'             2x20'
                        SifraKalPra = 2
                    Case 13             ' 1x20' + 3x10'             3x20'
                        SifraKalPra = 3
                    Case 14             ' 1x20' + 4x10'             3x20'
                        SifraKalPra = 3
                    Case 15             ' 1x20' + 5x10'             4x20'               2x40'
                        SifraKalPra = 4
                    Case 16             ' 1x20' + 6x10'             4x20'               2x40'
                        SifraKalPra = 4
                    Case 20             ' 2x20'                     2x20'
                        SifraKalPra = 2
                    Case 21             ' 2x20' + 1x10'             3x20'
                        SifraKalPra = 3
                    Case 22             ' 2x20' + 2x10'             3x20'
                        SifraKalPra = 3
                    Case 23             ' 2x20' + 3x10'             4x20'               2x40'
                        SifraKalPra = 4
                    Case 24             ' 2x20' + 4x10'             4x20'               2x40'
                        SifraKalPra = 4
                    Case 30             ' 3x20'                     3x20'
                        SifraKalPra = 3
                    Case 31             ' 3x20' + 1x10'             4x20'               2x40'
                        SifraKalPra = 4
                    Case 32             ' 3x20' + 2x10'             4x20'               2x40'
                        SifraKalPra = 4
                    Case 40             ' 4x20'                     4x20'               2x40'
                        SifraKalPra = 4
                    Case 100            ' 1x30'                     1x40'
                        SifraKalPra = 5
                    Case 101            ' 1x30' + 1x10'             1x40' + 1x20'
                        SifraKalPra = 6
                    Case 102            ' 1x30' + 2x10'             1x40' + 1x20'
                        SifraKalPra = 6
                    Case 103            ' 1x30' + 3x10'             1x40' + 2x20'       2x40'
                        SifraKalPra = 4
                    Case 104            ' 1x30' + 4x10'             1x40' + 2x20'       2x40'
                        SifraKalPra = 4
                    Case 105            ' 1x30' + 5x10'             1x40' + 3x20'   ?
                        SifraKalPra = 7
                    Case 110            ' 1x30' + 1x20'             1x40' + 1x20'
                        SifraKalPra = 6
                    Case 111            ' 1x30' + 1x20' + 1x10'     1x40' + 2x20'       2x40'
                        SifraKalPra = 4
                    Case 112            ' 1x30' + 1x20' + 2x10      1x40' + 2x20'       2x40'
                        SifraKalPra = 4
                    Case 113            ' 1x30' + 1x20' + 3x10'     1x40' + 3x20'   ?
                        SifraKalPra = 7
                    Case 120            ' 1x30' + 2x20'             1x40' + 2x20'       2x40'
                        SifraKalPra = 4
                    Case 121            ' 1x30' + 2x20' + 1x10'     1x40' + 3x20'   ?
                        SifraKalPra = 7
                    Case 200            ' 2x30'                     2x40'
                        SifraKalPra = 4
                    Case 201            ' 2x30' + 1x10'             2x30' + 1x20'    
                        SifraKalPra = 8
                    Case 202            ' 2x30' + 2x10'             2x30' + 1x20'   
                        SifraKalPra = 8
                    Case 210            ' 2x30' + 1x20'             
                        SifraKalPra = 8
                    Case 1000           ' 1x40'                     1x40' 
                        SifraKalPra = 5
                    Case 1001           ' 1x40' + 1x10'             1x40' + 1x20'
                        SifraKalPra = 6
                    Case 1002           ' 1x40' + 2x10'             1x40' + 1x20'
                        SifraKalPra = 6
                    Case 1003           ' 1x40' + 3x10'             1x40' + 2x20'       2x40'       
                        SifraKalPra = 4
                    Case 1004           ' 1x40' + 4x10'             1x40' + 2x20'       2x40'
                        SifraKalPra = 4
                    Case 1010           ' 1x40' + 1x20'             1x40' + 1x20'
                        SifraKalPra = 6
                    Case 1011           ' 1x40' + 1x20' + 1x10'     1x40' + 1x20'     
                        SifraKalPra = 6
                    Case 1012           ' 1x40' + 1x20' + 2x10'     1x40' + 1x20'
                        SifraKalPra = 6
                    Case 1020           ' 1x40' + 2x20'             1x40' + 2x20'       2x40'
                        SifraKalPra = 4
                    Case 1100           ' 1x40' + 1x30'             2x40'
                        SifraKalPra = 4
                    Case 1101           ' 1x40' + 1x30' + 1x10'     2x40' + 1x20'   ?
                        SifraKalPra = 9
                    Case 2000           ' 2x40                      2x40'
                        SifraKalPra = 4
                End Select

                Select Case SifraKalPra
                    Case 1
                        PrevozninaPoKolimaPra = CPra(1)
                    Case 2
                        PrevozninaPoKolimaPra = CPra(2)
                    Case 3
                        PrevozninaPoKolimaPra = CPra(4)
                    Case 4
                        PrevozninaPoKolimaPra = 2 * CPra(0)
                    Case 5
                        If K40 Then
                            PrevozninaPoKolimaPra = 1.2 * CPra(0)
                        Else
                            PrevozninaPoKolimaPra = CPra(0)
                        End If
                    Case 6
                        If K40 Then
                            PrevozninaPoKolimaPra = 1.125 * CPra(3)
                        Else
                            PrevozninaPoKolimaPra = CPra(3)
                        End If
                    Case 7
                        PrevozninaPoKolimaPra = CPra(0) + CPra(4)      '?
                    Case 8
                        PrevozninaPoKolimaPra = 2 * CPra(0) + CPra(1)
                    Case 9
                        PrevozninaPoKolimaPra = 2 * CPra(0) + CPra(1)  '?
                End Select


            End If

            PrevozninaPoKolima = PrevozninaPoKolimaTov + PrevozninaPoKolimaPra


            '       Vlasnistvo = KolaRed.Item("Vlasnik")
            '       BrOsovina = KolaRed.Item("Osovine")
            '       TovarenaPrazna = KolaRed.Item("Tovarena")

            bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnistvoKola, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            VozarinskiStav = PrevozninaPoKolima

            VozarinskiStav = bStavKoef * VozarinskiStav
            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef
            bVozarinskiStavPoKolima = VozarinskiStav
            bRacunskaMasaPoKolima = UkupnaMasa

            ' proba na minimalnu prevozninu
            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            Prevoznina = Prevoznina + PrevozninaPoKolima
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima
            '### xx
            '''For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM i masa
            '''    If NHMRed.Item("IndBrojKola") = IBK Then
            '''        '### 
            '''        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
            '''        bZaokruziMasuNa100k(MasaTemp1)
            '''        NHMRed.Item("RacMasaNHM") = MasaTemp1
            '''        NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
            '''        '### 
            '''    End If
            '''Next
            '### 

        Next
        bZaokruziNaDeseteNavise(Prevoznina)
    End Sub
    Public Sub bNadjiNizNazivaSt72L(ByVal inNizSifara As String, _
                                           ByRef outNizNaziva As String, _
                                           ByRef outRetVal As String)

        outRetVal = ""

        Dim DbVezaTest As New SqlConnection
        Dim TEST_CONNECTION_STRING As String = "Server=10.0.4.31;DataBase=TestOkpWinRoba;User=Radnik;Password=roba2006"
        Dim connRobaTest As New SqlConnection(TEST_CONNECTION_STRING)
        DbVezaTest = connRobaTest

        If DbVezaTest.State = ConnectionState.Closed Then
            DbVezaTest.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiNizNazivaSt72L", DbVezaTest)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulNizSifara As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNizSifaraSt", SqlDbType.VarChar, 150))
        ulNizSifara.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNizSifaraSt").Value = inNizSifara

        Dim izNizNaziva As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNizNazivaSt", SqlDbType.VarChar, 600))
        izNizNaziva.Direction = ParameterDirection.Output

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()

            outNizNaziva = spKomanda.Parameters("@outNizNazivaSt").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            If outRetVal = "                                                  " Then
                outRetVal = ""
            End If
            DbVezaTest.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Public Sub bNadjiNazivStanice72L(ByVal inSifraStanice As String, _
                                ByRef outNazivStanice As String, _
                                ByRef outRetVal As String)

        outRetVal = ""

        Dim DbVezaTest As New SqlConnection
        Dim TEST_CONNECTION_STRING As String = "Server=10.0.4.31;DataBase=TestOkpWinRoba;User=Radnik;Password=roba2006"
        Dim connRobaTest As New SqlConnection(TEST_CONNECTION_STRING)
        DbVezaTest = connRobaTest

        If DbVezaTest.State = ConnectionState.Closed Then
            DbVezaTest.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiNazivStanice72L", DbVezaTest)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulSifraStanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraStanice", SqlDbType.Char, 5))
        ulSifraStanice.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraStanice").Value = inSifraStanice

        Dim izNazivStanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivStanice", SqlDbType.Char, 20))
        izNazivStanice.Direction = ParameterDirection.Output


        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()
            outNazivStanice = spKomanda.Parameters("@outNazivStanice").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            If outRetVal = "                                                  " Then
                outRetVal = ""
            End If
            DbVezaTest.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub bNadjiPrevozninu911901L(ByRef outPrevoznina As Decimal, ByRef outPovVr As String)

        Dim TipCene As Integer = 0
        Dim Cena As Decimal = 0
        Dim PovVred As String = ""

        Dim KolaRed, NHMRed As DataRow
        Dim IBK As String
        Dim PrevozninaPoKolima As Decimal = 0
        Dim RacMasaPoKolima = 0
        Dim MasaKont As Decimal = 0
        Dim VozarinskiStav = 0

        outPrevoznina = 0

        For Each KolaRed In dtKola.Rows                                         ' petlja po kolima

            IBK = KolaRed.Item("IndBrojKola")

            Dim UkupnaMasa As Decimal = 0

            For Each NHMRed In dtNhm.Rows       ' po robi

                If IBK = NHMRed.Item("IndBrojKola") Then

                    If NHMRed.Item("NHM") = "994100" Then
                        If NHMRed.Item("UTI") = "10" Then
                            TipCene = 1
                        End If
                    Else

                    End If

                    If NHMRed.Item("NHM") = "993100" Then
                        If NHMRed.Item("UTI") = "10" Then
                            TipCene = 2
                        End If
                    Else

                    End If


                    MasaKont = NHMRed.Item("Masa")
                    UkupnaMasa = UkupnaMasa + MasaKont                    '###
                    ''''xxNHMRed.Item("RacMasaNHM") = MasaKont
                    '###

                End If
            Next                    ' po robi

            bNadjiStav911901L(mStanica1, mStanica2, TipCene, Cena, PovVred)
            'Dim Uslov065 As Boolean = False     ' videti da li se ovo javlja i kako se sifrira
            'If Uslov065 Then
            ' Cena = 0.65 * Cena
            'End If
            PrevozninaPoKolima = Cena

            VozarinskiStav = PrevozninaPoKolima
            bVozarinskiStavPoKolima = VozarinskiStav
            bRacunskaMasaPoKolima = UkupnaMasa
            bZaokruziMasuNa100k(bRacunskaMasaPoKolima)

            ' proba na minimalnu prevozninu
            'If PrevozninaPoKolima <= bMinPrevoznina Then
            '    PrevozninaPoKolima = bMinPrevoznina
            'End If

            ''''xxKolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            ''''xxKolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima

            outPrevoznina = outPrevoznina + PrevozninaPoKolima

            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima
            '### 
            For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM i masa
                If NHMRed.Item("IndBrojKola") = IBK Then
                    '### 
                    Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                    bZaokruziMasuNa100k(MasaTemp1)
                    '''xxNHMRed.Item("RacMasaNHM") = MasaTemp1
                    '''xxNHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                    '### 
                End If
            Next
            '### 

        Next
        bZaokruziNaDeseteNavise(outPrevoznina)

    End Sub
    Public Sub bNadjiStav911901L(ByVal inStanica1 As String, _
                                 ByVal inStanica2 As String, _
                                 ByVal inTipCene As Integer, _
                                 ByRef outCena As String, _
                                 ByRef outRetVal As String)

        outRetVal = ""

        'Dim DbVezaTest As New SqlConnection
        'Dim TEST_CONNECTION_STRING As String = "Server=10.0.4.31;DataBase=TestOkpWinRoba;User=Radnik;Password=roba2006"
        'Dim connRobaTest As New SqlConnection(TEST_CONNECTION_STRING)
        'DbVezaTest = connRobaTest

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.bspNadjiCenuHot", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica1", SqlDbType.VarChar, 5))
        ulStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica1").Value = inStanica1

        Dim ulStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica2", SqlDbType.VarChar, 5))
        ulStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica2").Value = inStanica2

        Dim ulTipCene As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTipCene", SqlDbType.Int, 4))
        ulTipCene.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTipCene").Value = inTipCene

        Dim izCena As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outCena", SqlDbType.Decimal))
        izCena.Size = 9
        izCena.Precision = 18
        izCena.Scale = 2
        izCena.Direction = ParameterDirection.Output

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()
            outCena = spKomanda.Parameters("@outCena").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            If outRetVal = "                                                  " Then        ' 50
                outRetVal = ""
            End If
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

End Module
