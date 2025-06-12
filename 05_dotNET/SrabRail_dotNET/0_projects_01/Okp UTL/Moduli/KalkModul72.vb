Imports System.Data.SqlClient


Module KalkModul72
    ' Friend NHM4 As String = ""
    Public Sub bNadjiPrevozninu00L(ByVal Tabela As String, ByRef Prevoznina As Decimal) 'RSD
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

        Dim bNPZaKola As String = ""

        'If bVrstaSaobracaja = 0 Then
        '    bDoTona = "25"
        'Else
        '    bDoTona = "45"
        'End If

        bDoTona = "25"                  ' ovo je procedura za RSD

        Dim Ka As Decimal = 1

        'If mBrojUg = "200379" Then 'Uss ex-im
        '    bStavKoef = 0.5
        'End If

        Prevoznina = 0

        bRedovanOrocen = "R"

        Dim k As Int16 = 1

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
                bNPZaKola = KolaRed.Item("ICF")


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
                Dim bSaobracaj As Integer
                If bValuta = "72" Then
                    bSaobracaj = 1
                ElseIf bValuta = "17" Then
                    bSaobracaj = 2
                End If

                Dim bRetValLok As String = ""



                bNadjiSveIzZSKoefPos(bSaobracaj, mTarifa, bVrstaPosiljke, "M", Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                pubSerijaKola = KolaRed.Item("Serija") '## T kola
                pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola

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
                            NHMRed.Item("RacMasaNHM") = MasaTemp
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

                    'bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, bDoTona, Masa1R, Masa2R, Masa3R, TonskiStav)

                    'If (bVrstaSaobracaja = 2 Or bVrstaSaobracaja = 3) And TipKola = "7" Then
                    '    TonskiStav = "45"
                    'End If

                    ' Dodato zbog praznih kola

                    NHM = NHMRed.Item("NHM")

                    'Dim bNHMKao8606 = False
                    If NHM = "992110" Or NHM = "992120" Or NHM = "992130" Or NHM = "992140" Or _
                       NHM = "992210" Or NHM = "992220" Or NHM = "992230" Or NHM = "992240" Or _
                       Microsoft.VisualBasic.Left(NHM, 4) = "8601" Or Microsoft.VisualBasic.Left(NHM, 4) = "8602" Or _
                       Microsoft.VisualBasic.Left(NHM, 4) = "8603" Or Microsoft.VisualBasic.Left(NHM, 4) = "8604" Or _
                       Microsoft.VisualBasic.Left(NHM, 4) = "8605" Then
                        bNHMKao8606 = True
                        TovarenaPrazna = "TK"
                    Else
                        bNHMKao8606 = False
                    End If

                    'Dim NHM4 As String = ""

                    NHM4 = (Microsoft.VisualBasic.Left(NHM, 4))

                    If (NHM4 = "9921" Or NHM4 = "9922") And Not (bNHMKao8606) Then
                        'Or NHM4 = "8601" Or NHM4 = "8602" Or NHM4 = "8603" _
                        'Or NHM4 = "8604" Or NHM4 = "8605" Or NHM4 = "8606") _

                        bZaokruziMasuNa100k(Masa1R)

                        If Masa1R < 10000 Then
                            Masa1R = 10000
                        End If

                        TovarenaPrazna = "PK"
                        TipKola = "7"
                        If (NHM4 = "9921" Or NHM4 = "9922") And Not (bNHMKao8606) Then
                            KolKoef = 0.3
                        Else
                            KolKoef = 1
                        End If


                        Dim TovPraMP As String
                        Dim VlasnMP As String
                        bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                        If TovPraMP = "" Then
                            TovPraMP = TovarenaPrazna
                        End If
                        If VlasnMP = "" Then
                            VlasnMP = Vlasnistvo
                        End If

                        bNadjiSveIzZSKoefPos(1, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                                             TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                             bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                        ' Tarifa 2015
                        'bNadjiSveIzZSKoefPos(1, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                        '                     TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                        '                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)


                        'If (mDatumKalk >= #2/1/2008#) And ((bVrstaSaobracaja = 2 Or bVrstaSaobracaja = 3)) Then
                        '    bDoTona = "45"
                        '    TonskiStav = "45"
                        '    'Masa1R = dtNhm.Rows(0).Item("Masa")
                        '    bZaokruziMasuNa100k(Masa100)
                        '    Masa1R = Masa100
                        'Else
                        '    bDoTona = "25"
                        'End If
                    End If
                    ' Dodato zbog praznih kola


                    If NHM4 = "8606" Or (bNHMKao8606) Then
                        'TovarenaPrazna = "TK"       po Z.Mandicu 29.03.2013
                        'Vlasnistvo = "Z"            uneto dole "P" i "PK"   


                        Dim TovPraMP As String
                        Dim VlasnMP As String
                        bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)

                        If TovPraMP = "" Then
                            TovPraMP = "PK"
                        End If
                        If VlasnMP = "" Then
                            VlasnMP = "P"
                        End If

                        bNadjiSveIzZSKoefPos(1, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                                                                     TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                                                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)
                        ' Tarifa 2015
                        'bNadjiSveIzZSKoefPos(1, mTarifa, bVrstaPosiljke, bVrstaStanice, "P", _
                        '                                             "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                        '                                             bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)
                        KolKoef = 1
                    End If




                    bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, bDoTona, Masa1R, Masa2R, Masa3R, TonskiStav)

                    bPrevozninaKoef = 1

                    TonskiStavInteger = CType(TonskiStav, Integer)

                    If ((bVrstaSaobracaja = 0) And (TovarenaPrazna = "PK") And (mDatumKalk >= #1/1/2013#)) Then
                        If BrOsovina = 2 Then
                            TonskiStavInteger = 15
                        Else
                            TonskiStavInteger = 25
                        End If
                        Masa1R = Masa100
                    End If

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


                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "2", VozarinskiStav, PV)
                    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000
                    ' zaokruzivanje?
                    '###
                    If (Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0)) Then
                        bVozarinskiStavPoKolima = VozarinskiStav
                    End If
                    '###
                    Prev3R = Prev3R * bPrevozninaKoef


                    If ((mDatumKalk >= #1/1/2013#) And (bVrstaSaobracaja = 0) And ((TipKola = "1") Or (TipKola = "2"))) Then

                        If NHM4 = "8606" Or (bNHMKao8606) Then
                            bPrevozninaKoef = 1
                        Else
                            bPrevozninaKoef = 1.2
                        End If

                    End If

                    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!
                    PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef ' zbog +20% od 1.1.2013 za unutrasnje



                    '### xx
                    For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            '### 
                            NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                            Select Case NHMRed.Item("R")                                       ' grupisanje po razredima
                                Case "1"
                                    NHMRed.Item("RacMasaNHM") = Masa1R
                                Case "2"
                                    NHMRed.Item("RacMasaNHM") = Masa2R
                                Case "3"
                                    NHMRed.Item("RacMasaNHM") = Masa3R
                            End Select
                            '### 

                            If bPorekloRobe = 0 Then
                                NHMRed.Item("PorekloRobe") = 0
                            Else
                                NHMRed.Item("PorekloRobe") = 1
                            End If

                        End If
                    Next
                    '### 

                    If bNarocitaPosiljka Then
                        'If bNPZaKola = "DaNP" Then
                        If bNPZaKola = "D" Then
                            PrevozninaPoKolima = PrevozninaPoKolima * bNPKoef
                        End If
                    End If

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
                    '!!! Dodati u konacnu verziju
                    KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima

                End If
                Prevoznina = Prevoznina + PrevozninaPoKolima
                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                k = k + 1                   ' zbog NP

            Next    ' petlja po kolima

        Else
            ' nema ni kola ni prevoznine
        End If

    End Sub
    Public Sub bNadjiPrevozninuNeNulaL(ByVal inTabela As String, ByRef outPrevoznina As Decimal)
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
        Dim TovarenaPrazna As String
        Dim Vlasnistvo As String

        Dim TonskiStav As String
        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim TonskiStavInteger As Integer
        Dim PrevozninaPoKolima As Decimal

        Dim UkupnaMasa91 As Decimal = 0

        Dim NHM As String = ""

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

        ' - INTERNO SIFRIRANJE ZA PROMENLJIVU bTarifa72:  ( prema unutr. saobracaju )
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


        ' - INTERNO SIFRIRANJE ZA PROMENLJIVU bTarifa72:  ( prema Z.Mandicu )
        '
        '    49 - Grupa kola - clan 59 - 4
        '    46 - Marsrutni voz - cl. 57 - 1
        '   (91)- P9 Uputnica za besplatan prevoz
        '   (92)- SPT49 - Prevoz za potrebe ZS
        '   (93)- NP - Narocite posiljke
        '    39 - Mesoviti vojni transport cl. 45 - 4
        '    40 - Mesoviti vojni transport cl. 45 - 6
        '    43 - Ostali tovarni pribor u vlasnistvu korisnika prevoza cl. 52 - 9        
        '    48 - Poseban voz - cl. 58 - 5
        '    99 - besplatan prevoz


        ' racunanje prosecne mase 

        UkupnoKola = dtKola.Rows.Count
        For Each KolaRed In dtKola.Rows    ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            For Each NHMRed In dtNhm.Rows                       '  da li treba dozvoliti da bude vise masa na jednim kolima 
                If NHMRed.Item("IndBrojKola") = IBK Then        '  ili treba obezbediti da bude na svim kolima po jedna roba i to ista na svim kolima ?
                    MasaTemp = NHMRed.Item("Masa")
                    UkupnaMasa = UkupnaMasa + MasaTemp
                    NHM = NHMRed.Item("NHM")
                End If
            Next
            BrOsovina = KolaRed.Item("Osovine")
            UkupnoOsovina = UkupnoOsovina + BrOsovina
        Next


        bPrevozninaKoef = 1

        UkupnaMasa91 = UkupnaMasa


        If bTarifa72 = 44 Or bTarifa72 = 45 Then
            If UkupnaMasa < 10000 * UkupnoKola Then
                UkupnaMasa = 10000 * UkupnoKola
            End If
        End If


        If bTarifa72 = 46 Then
            If NHM = "992100" Or NHM = "992200" Then
                If UkupnoKola < 11 Then
                    If UkupnaMasa < 600000 Then
                        UkupnaMasa = 600000
                    End If
                End If
            Else
                If UkupnaMasa < 600000 Then
                    UkupnaMasa = 600000
                End If
            End If
        End If


        If bTarifa72 = 92 Then    'SPT49 - Prevoz za potrebe ZS ( ranije JZ tarifa )
            mTabelaCena = "490"
        End If


        bZaokrMasuNaOsovineP(UkupnaMasa, bSvaTovarena, UkupnoOsovina, UkupnaMasa)


        ProsecnaMasa = UkupnaMasa / UkupnoKola                         ' prosecna masa po kolima
        bZaokruziMasuNa100k(ProsecnaMasa)                                   ' prosecna masa po kolima zaokruzena na 100k navise

        bRacunskaMasaPoKolima = ProsecnaMasa


        outPrevoznina = 0

        Dim k As Int16 = 1
        Dim Cena(4) As Decimal
        Dim RacMasPoKolima As Decimal = 0

        For Each KolaRed In dtKola.Rows                                         ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            '       Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
            TipKola = Left(KolaRed.Item("Tip"), 1)
            For Each NHMRed In dtNhm.Rows                                '  da li treba dozvoliti da bude vise masa na jednim kolima 
                If NHMRed.Item("IndBrojKola") = IBK Then              '  ili treba obezbediti da bude na svim kolima po jedna roba i to ista na svim kolima ?
                    Razred = NHMRed.Item("R")                               ' u principu, ni ne treba petlja, vec da se ucita bilo koji razred
                    If bTarifa72 = 92 Then                            'SPT49 - Prevoz za potrebe ZS ( ranije JZ tarifa )
                        MasaTemp = NHMRed.Item("Masa")
                        bRacunskaMasaPoKolima = MasaTemp
                        bZaokruziMasuNa100k(bRacunskaMasaPoKolima)
                    End If


                End If
            Next

            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            Razred = NHMRed.Item("R")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            '       BrOsovina = KolaRed.Item("Osovine")

            NHM = NHMRed.Item("NHM")
            NHM4 = (Microsoft.VisualBasic.Left(NHM, 4))

            If bTarifa72 = 91 Then
                MasaTemp = UkupnaMasa91
            End If

            Dim bSaobracaj As Integer
            If bValuta = "72" Then
                bSaobracaj = 1
            ElseIf bValuta = "17" Then
                bSaobracaj = 2
            End If

            'Dim bNHMKao8606 = False
            If NHM = "992110" Or NHM = "992120" Or NHM = "992130" Or NHM = "992140" Or _
               NHM = "992210" Or NHM = "992220" Or NHM = "992230" Or NHM = "992240" Or _
               Microsoft.VisualBasic.Left(NHM, 4) = "8601" Or Microsoft.VisualBasic.Left(NHM, 4) = "8602" Or _
               Microsoft.VisualBasic.Left(NHM, 4) = "8603" Or Microsoft.VisualBasic.Left(NHM, 4) = "8604" Or _
               Microsoft.VisualBasic.Left(NHM, 4) = "8605" Then
                bNHMKao8606 = True
                TovarenaPrazna = "TK"
            Else
                bNHMKao8606 = False
            End If

            If NHM4 = "8606" Or (bNHMKao8606) Then
                'TovarenaPrazna = "TK"       po Z.Mandicu 29.03.2013;
                'Vlasnistvo = "Z"            uneto dole "P" i "PK" 
            End If

            Dim bRetValLok As String = ""

            'bNadjiSveIzZSKoefPos(bSaobracaj, mTarifa, bVrstaPosiljke, "M", "P", _
            '                     "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            '                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

            Dim TovPraMP As String
            Dim VlasnMP As String
            bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
            If TovPraMP = "" Then
                TovPraMP = TovarenaPrazna
            End If
            If VlasnMP = "" Then
                VlasnMP = Vlasnistvo
            End If
            bNadjiSveIzZSKoefPos(bSaobracaj, mTarifa, bVrstaPosiljke, "M", VlasnMP, _
                                 TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                 bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)
            ' Tarifa 2015
            'bNadjiSveIzZSKoefPos(bSaobracaj, mTarifa, bVrstaPosiljke, "M", Vlasnistvo, _
            '                     TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            '                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)




            pubSerijaKola = KolaRed.Item("Serija") '## T kola
            pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola

            bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

            If NHM4 = "8606" Or (bNHMKao8606) Then
                KolKoef = 1
            End If


            MasaTemp = ProsecnaMasa

            Dim RacunskiRazred As String
            If Razred = "3" Then
                RacunskiRazred = "2"
            Else
                RacunskiRazred = Razred
            End If


            If Not (TovarenaPrazna = "PK") Then             ' tovarena
                If bValuta = 72 Then
                    bNadjiMasuIStavDo25(MasaTemp, MasaTemp, TonskiStav)
                Else
                    bNadjiMasuIStavGM("122", MasaTemp, bTkm, RacunskiRazred, MasaTemp, TonskiStav, PV)
                End If
            Else                                            ' prazna
                If bValuta = 72 Then
                    If MasaTemp <= 10000 Then
                        MasaTemp = 10000
                    End If

                Else
                    bNadjiMasuIStavGM("122", MasaTemp, bTkm, RacunskiRazred, MasaTemp, TonskiStav, PV)      ' isto kao tovarena ?
                    'If (mDatumKalk >= #1/1/0201#) Then
                    TonskiStav = "45"
                    'End If
                End If
            End If



            ProsecnaMasa = MasaTemp

            TonskiStavInteger = CType(TonskiStav, Integer)

            If ((bVrstaSaobracaja = 0) And (TovarenaPrazna = "PK")) Then
                If (mDatumKalk < #1/1/2013#) Then
                    bNadjiMasuIStavDo25(MasaTemp, MasaTemp, TonskiStav)
                    TonskiStavInteger = CType(TonskiStav, Integer)
                    ProsecnaMasa = MasaTemp
                    bRacunskaMasaPoKolima = ProsecnaMasa
                Else
                    If BrOsovina = 2 Then
                        TonskiStavInteger = 15
                    Else
                        TonskiStavInteger = 25
                    End If
                End If
            End If

            MasaTemp = TonskiStavInteger * 1000

            bNadjiVozarinskiStav(mTabelaCena, mDatumKalk, MasaTemp, bTkm, RacunskiRazred, VozarinskiStav, PV)

            If mTabelaCena = "490" Then
                bNadjiVozarinskiStavKont("490", mDatumKalk, "00800", bTkm, Cena(0), PV)
                VozarinskiStav = Cena(0)
                bMinPrevoznina = 0
            End If



            VozarinskiStav = bStavKoef * VozarinskiStav
            bZaokruziNaDeseteNavise(VozarinskiStav)
            bVozarinskiStavPoKolima = VozarinskiStav

            PrevozninaPoKolima = ProsecnaMasa * VozarinskiStav * KolKoef / 1000  ' u din
            If bTarifa72 = 92 Then
                'PrevozninaPoKolima = bRacunskaMasaPoKolima * VozarinskiStav * KolKoef / 1000  ' u din
                PrevozninaPoKolima = bRacunskaMasaPoKolima * VozarinskiStav / 1000   ' u din ; ne treba koeficijent za kola
            End If


            ' kada zaokruzivanje?

            If bTarifa72 = 42 Or bTarifa72 = 43 Then
                PrevozninaPoKolima = 0.5 * PrevozninaPoKolima    ' tovarni pribor
            End If

            If bNarocitaPosiljka And k <= bNPUkupno Then
                PrevozninaPoKolima = PrevozninaPoKolima * bNPKoef
            End If

            If ((mDatumKalk >= #1/1/2013#) And (bVrstaSaobracaja = 0)) And ((TipKola = "1") Or (TipKola = "2")) And Not (bTarifa72 = 92) Then
                bPrevozninaKoef = 1.2
            End If

            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef

            ' proba na minimalnu prevozninu

            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            'If bTarifa72 = 99 Then                   
            '    PrevozninaPoKolima = 0
            'End If


            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            outPrevoznina = outPrevoznina + PrevozninaPoKolima
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

            '### xx
            For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM , masa, porekla robe
                If NHMRed.Item("IndBrojKola") = IBK Then
                    '### 
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav      '??????? formalno
                    NHMRed.Item("RacMasaNHM") = ProsecnaMasa     '?????? formalno
                    '### 
                    If bPorekloRobe = 0 Then
                        NHMRed.Item("PorekloRobe") = 0
                    Else
                        NHMRed.Item("PorekloRobe") = 1
                    End If
                End If
            Next
            '### 
            k = k + 1
        Next


        If bTarifa72 = 91 Then
            bPrevoznina91ZaPDV = outPrevoznina
            outPrevoznina = bNepokrivenaMasa * VozarinskiStav / 1000
            If ((mDatumKalk >= #1/1/2013#) And (bVrstaSaobracaja = 0)) And ((TipKola = "1") Or (TipKola = "2")) Then
                outPrevoznina = outPrevoznina * 1.2
            End If

        End If



        bZaokruziNaDeseteNavise(outPrevoznina)

        If bTarifa72 = 91 And bNepokrivenaMasa > 0 Then
            bPr91Nepokrivena = outPrevoznina
        End If


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
                Select Case SifKomPra
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

            pubSerijaKola = KolaRed.Item("Serija") '## T kola
            pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola

            bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            Dim bSaobracaj As Integer
            If bValuta = "72" Then
                bSaobracaj = 1
            ElseIf bValuta = "17" Then
                bSaobracaj = 2
            End If

            Dim bRetValLok As String = ""

            bNadjiSveIzZSKoefPos(bSaobracaj, mTarifa, bVrstaPosiljke, "M", VlasnistvoKola, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

            VozarinskiStav = PrevozninaPoKolima

            VozarinskiStav = bStavKoef * VozarinskiStav
            If b35Posto Then
                bPrevozninaKoef = 0.65
            Else
                bPrevozninaKoef = 1
            End If


            If ((mDatumKalk >= #1/1/2013#) And (bVrstaSaobracaja = 0) And ((TipKola = "1") Or (TipKola = "2"))) Then

                bPrevozninaKoef = bPrevozninaKoef * 1.2

            End If


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
            'Prevoznina = Prevoznina + PrevozninaPoKolima
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima
            '### xx
            For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM i masa i porekla robe
                If NHMRed.Item("IndBrojKola") = IBK Then
                    '### 
                    Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                    bZaokruziMasuNa100k(MasaTemp1)
                    NHMRed.Item("RacMasaNHM") = MasaTemp1
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                    '### 
                    If bPorekloRobe = 0 Then
                        NHMRed.Item("PorekloRobe") = 0
                    Else
                        NHMRed.Item("PorekloRobe") = 1
                    End If
                End If
            Next
            '### 
            Prevoznina = Prevoznina + PrevozninaPoKolima

        Next
        bZaokruziNaDeseteNavise(Prevoznina)
    End Sub
    Public Sub bNadjiNizNazivaSt72L(ByVal inNizSifara As String, _
                                           ByRef outNizNaziva As String, _
                                           ByRef outRetVal As String)

        outRetVal = ""


        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.bspNadjiNizNazivaSt72L", DbVeza)
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
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Public Sub bNadjiNazivStanice72L(ByVal inSifraStanice As String, _
                                ByRef outNazivStanice As String, _
                                ByRef outRetVal As String)

        outRetVal = ""


        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiNazivStanice72L", DbVeza)
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
            DbVeza.Close()
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
                    ''xxNHMRed.Item("RacMasaNHM") = MasaTemp1
                    ''xxNHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                    NHMRed.Item("RacMasaNHM") = MasaTemp1
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
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

    Public Sub bNadjiZbirStvarnihMasa(ByRef outUkupnaStvMasa As Decimal)

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK As String
        Dim MasaTemp As Integer = 0
        Dim StvMasaPoKolima As Integer = 0

        outUkupnaStvMasa = 0

        For Each KolaRed In dtKola.Rows    ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            StvMasaPoKolima = 0
            For Each NHMRed In dtNhm.Rows
                If NHMRed.Item("IndBrojKola") = IBK Then
                    MasaTemp = NHMRed.Item("Masa")
                    StvMasaPoKolima = StvMasaPoKolima + MasaTemp
                End If

            Next

            outUkupnaStvMasa = outUkupnaStvMasa + StvMasaPoKolima
        Next

    End Sub
    Public Sub bNadjiRacunskuMasuPoPosiljciPoRazredima(ByRef outRaz1 As String, ByRef outRacMasa1 As Decimal, _
                                                       ByRef outRaz2 As String, ByRef outRacMasa2 As Decimal, _
                                                       ByRef outRaz3 As String, ByRef outRacMasa3 As Decimal)

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK As String
        Dim Vlasnistvo As String
        Dim MasaTemp As Integer = 0
        Dim MasaPoKolima As Integer = 0
        Dim BrOsovina As Integer
        Dim Razred As String
        Dim RacunskaMasaPoKolima As Integer = 0

        outRaz1 = ""
        outRacMasa1 = 0
        outRaz2 = ""
        outRacMasa2 = 0
        outRaz3 = ""
        outRacMasa3 = 0

        For Each KolaRed In dtKola.Rows    ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            BrOsovina = KolaRed.Item("Osovine")

            For Each NHMRed In dtNhm.Rows
                If NHMRed.Item("IndBrojKola") = IBK Then
                    'MasaTemp = NHMRed.Item("Masa")
                    'bZaokruziMasuNa100k(MasaTemp)
                    MasaTemp = NHMRed.Item("RacMasaNHM")
                    Razred = NHMRed.Item("R")

                    'If (MasaTemp < NHMRed.Item("RacMasaNHM")) And bTarifa72 = 0 Then
                    '    MasaTemp = NHMRed.Item("RacMasaNHM")
                    'End If

                    Select Case Razred                                        ' grupisanje po razredima
                        Case "1"
                            outRaz1 = "1"
                            outRacMasa1 = outRacMasa1 + MasaTemp
                        Case "2"
                            outRaz2 = "2"
                            outRacMasa2 = outRacMasa2 + MasaTemp
                        Case "3"
                            outRaz3 = "3"
                            outRacMasa3 = outRacMasa3 + MasaTemp
                    End Select
                End If
            Next

            'If RacunskaMasaPoKolima < BrOsovina * 5000 Then
            '    RacunskaMasaPoKolima = BrOsovina * 5000
            'End If

        Next

        'If ((mVrstaPrevoza = "G") Or (mVrstaPrevoza = "V")) And Not (mBrojUg = "200379") And Not (mBrojUg = "") Then
        If ((mVrstaPrevoza = "G") Or (mVrstaPrevoza = "V")) And Not (mBrojUg = "") Then
            outRacMasa1 = bRacunskaMasa571
            outRacMasa2 = 0
            outRacMasa3 = 0
        End If

        If outRacMasa1 = 0 Then
            If outRacMasa2 = 0 Then
                outRacMasa1 = outRacMasa3
                outRaz1 = "3"
                outRacMasa3 = 0
            Else
                outRacMasa1 = outRacMasa2
                outRaz1 = "2"
                outRaz2 = ""
                outRacMasa2 = 0
                outRaz3 = ""
                outRacMasa3 = 0
            End If
        End If

    End Sub
    Public Sub bNadjiMasuIStavGM( _
                            ByVal inSifraTabele As String, _
                            ByVal inMasa As Integer, _
                            ByVal intkm As Integer, _
                            ByVal inRazred As String, _
                            ByRef outMasa As Integer, _
                            ByRef outSifraStava As String, _
                            ByRef outRetVal As String)



        outMasa = 0
        outSifraStava = ""
        outRetVal = ""


        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiMasuIStavGM", DbVezaCene)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulSifraTabele As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraTabele", SqlDbType.Char, 3))
        ulSifraTabele.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraTabele").Value = inSifraTabele

        Dim ulMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inMasa", SqlDbType.Int))
        ulMasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inMasa").Value = inMasa

        Dim ultkm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int))
        ultkm.Direction = ParameterDirection.Input
        spKomanda.Parameters("@intkm").Value = intkm

        Dim ulRazred As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRazred", SqlDbType.Char, 1))
        ulRazred.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRazred").Value = inRazred

        Dim izlMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMasa", SqlDbType.Int))
        izlMasa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMasa").Value = outMasa

        Dim izlSifraStava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraStava", SqlDbType.Char, 2))
        izlSifraStava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraStava").Value = outSifraStava

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal


        Try

            If DbVezaCene.State = ConnectionState.Closed Then
                DbVezaCene.Open()
            End If

            spKomanda.ExecuteScalar()
            outMasa = spKomanda.Parameters("@outMasa").Value
            outSifraStava = spKomanda.Parameters("@outSifraStava").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVezaCene.Close()
            spKomanda.Dispose()
        End Try


    End Sub

    Public Sub bIznoseNaknadaUDTNaNulu()
        Dim Nak_Red As DataRow
        If dtNaknade.Rows.Count > 0 Then
            For Each Nak_Red In dtNaknade.Rows
                If Not (Nak_Red.Item("Sifra") = "62") Then
                    Nak_Red.Item("Iznos") = 0
                End If
            Next
        End If

    End Sub

    Public Sub bPrevoznineUDTNaNulu()
        Dim Kola_Red As DataRow
        If dtKola.Rows.Count > 0 Then
            For Each Kola_Red In dtNaknade.Rows
                Kola_Red.Item("PrevozninaPoKolima") = 0
            Next
        End If
    End Sub
    Public Sub bNadjiPrevozninuKont72UI(ByVal Tabela As String, ByRef Prevoznina As Decimal)

        Dim KolaRed, NHMRed As DataRow
        Dim IBK As String
        Dim Vlasnistvo As String
        Dim TovarenaPrazna As String
        Dim DuzinaKontStr As String
        Dim DuzinaKont As Integer
        Dim StvMasa As Integer
        Dim UkupnoKola As Byte
        Dim PrevozninaPoKolima As Decimal
        Dim PrevozninaPoKont As Decimal
        Dim VozarinskiStav As Decimal
        Dim Raster As Decimal
        Dim KolKoef As Decimal
        Dim PV As String

        ' Postupak:
        ' - cena se racuna posebno za svaki UTI i zaokruzuje se samo  jednom i to po UTI-ju na ceo euro navise
        ' - na osnovu duzine ( odnosno sifre LC/CL ) i bruto mase naci raster koeficijent
        ' - na osnovu tkm nalazi se osnovna cena ( str.26 )       
        ' - uracunati bStavKoef
        ' - uracunati bPrevozninaKoef
        ' - uracunati minimalnu prevozninu


        UkupnoKola = dtKola.Rows.Count

        Prevoznina = 0
        Dim TipKola As String
        For Each KolaRed In dtKola.Rows                                         ' petlja po kolima
            PrevozninaPoKolima = 0
            bRacunskaMasaPoKolima = 0
            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            TipKola = KolaRed.Item("Tip")

            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            ' Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna

            Dim bSaobracaj As Integer
            If bValuta = "72" Then
                bSaobracaj = 1
            ElseIf bValuta = "17" Then
                bSaobracaj = 2
            End If

            Dim bRetValLok As String = ""



            bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", Vlasnistvo, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

            
            KolKoef = 1
            'If Vlasnistvo = "P" Or Vlasnistvo = "I" Then
            '    KolKoef = 0.8
            'End If

            For Each NHMRed In dtNhm.Rows
                If IBK = NHMRed.Item("IndBrojKola") Then
                    DuzinaKontStr = Microsoft.VisualBasic.Left(NHMRed.Item("UTI"), 2)
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    StvMasa = NHMRed.Item("Masa")
                    Dim bTovPraKon As String = ""
                    If Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "9931" Then
                        bTovPraKon = "PraKon"
                    Else
                        bTovPraKon = "TovKon"
                    End If
                    bNadjiRaster72UI(DuzinaKont, StvMasa, bTovPraKon, Raster)

                    PrevozninaPoKont = 0

                    bNadjiVozarinskiStavKontTEA(Tabela, mDatumKalk, bTkm, VozarinskiStav, PV)
                    VozarinskiStav = bStavKoef * VozarinskiStav
                    bZaokruziNaDeseteNavise(VozarinskiStav)

                    PrevozninaPoKont = VozarinskiStav * Raster * KolKoef * bPrevozninaKoef
                    bZaokruziNaDeseteNavise(PrevozninaPoKont)


                    'If Ugovor = "031522" Then

                    'End If

                    NHMRed.Item("UTIRaster") = Raster
                    NHMRed.Item("RacMasaNHM") = StvMasa
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav

                    If bPorekloRobe = 0 Then
                        NHMRed.Item("PorekloRobe") = 0
                    Else
                        NHMRed.Item("PorekloRobe") = 1
                    End If


                    PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaPoKont
                    bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + StvMasa

                End If
            Next
            ' proba na minimalnu prevozninu

            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima

            'If Vlasnistvo = "Z" Then
            '    KolaRed.Item("Naknada") = 36
            'End If

            Prevoznina = Prevoznina + PrevozninaPoKolima
        Next
    End Sub
    Public Sub bNadjiRaster72UI(ByVal inDuzinaKont As String, ByVal inStvMasa As Integer, ByVal inTovareniPrazni As String, ByRef outRaster As Decimal)

        If inTovareniPrazni = "TovKon" Then
            Select Case inDuzinaKont
                Case "10"
                    If inStvMasa <= 8000 Then
                        outRaster = 0.37
                    ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                        outRaster = 0.45
                    ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                        outRaster = 0.55
                    ElseIf inStvMasa > 22000 And inStvMasa <= 34000 Then
                        outRaster = 0.75
                    ElseIf inStvMasa > 34000 Then
                        outRaster = 0.85
                    End If
                Case "20"
                    If inStvMasa <= 8000 Then
                        outRaster = 0.37
                    ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                        outRaster = 0.5
                    ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                        outRaster = 0.55
                    ElseIf inStvMasa > 22000 And inStvMasa <= 34000 Then
                        outRaster = 0.75
                    ElseIf inStvMasa > 34000 Then
                        outRaster = 0.85
                    End If
                Case "30"
                    If inStvMasa <= 8000 Then
                        outRaster = 0.5
                    ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                        outRaster = 0.55
                    ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                        outRaster = 0.75
                    ElseIf inStvMasa > 22000 And inStvMasa <= 34000 Then
                        outRaster = 0.75
                    ElseIf inStvMasa > 34000 Then
                        outRaster = 0.85
                    End If
                Case "40"
                    If inStvMasa <= 8000 Then
                        outRaster = 0.65
                    ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                        outRaster = 0.65
                    ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                        outRaster = 0.85
                    ElseIf inStvMasa > 22000 And inStvMasa <= 34000 Then
                        outRaster = 0.85
                    ElseIf inStvMasa > 34000 Then
                        outRaster = 0.9
                    End If
                Case "50"
                    If inStvMasa <= 8000 Then
                        outRaster = 0.7
                    ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                        outRaster = 0.75
                    ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                        outRaster = 1
                    ElseIf inStvMasa > 22000 And inStvMasa <= 34000 Then
                        outRaster = 1
                    ElseIf inStvMasa > 34000 Then
                        outRaster = 1
                    End If
                Case "70"
                    If inStvMasa <= 8000 Then
                        outRaster = 0.7
                    ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                        outRaster = 0.75
                    ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                        outRaster = 1
                    ElseIf inStvMasa > 22000 And inStvMasa <= 34000 Then
                        outRaster = 1
                    ElseIf inStvMasa > 34000 Then
                        outRaster = 1
                    End If
            End Select

        ElseIf inTovareniPrazni = "PraKon" Then
            Select Case inDuzinaKont
                Case "10"
                    outRaster = 0.37
                Case "20"
                    outRaster = 0.37
                Case "30"
                    outRaster = 0.5
                Case "40"
                    outRaster = 0.65
                Case "50"
                    outRaster = 0.7
                Case "70"
                    outRaster = 0.7
            End Select
        End If
    End Sub

    Public Sub bNadjiPrevozninuUSSLStoNeValja(ByRef Prevoznina As Decimal)    ' US Steel

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow

        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1
        Dim MasaTemp As Integer
        Dim Razred As String

        Dim VozarinskiStav As Decimal
        Dim PV As String

        Dim PrevozninaPoKolima As Decimal = 0

        bRacunskaMasa = 0
        Prevoznina = 0

        Dim NHM As String = dtNhm.Rows(0).Item("NHM")

        NHM4 = (Microsoft.VisualBasic.Left(NHM, 4))


        'Dim bNHMKao8606 = False
        If NHM = "992110" Or NHM = "992120" Or NHM = "992130" Or NHM = "992140" Or _
           NHM = "992210" Or NHM = "992220" Or NHM = "992230" Or NHM = "992240" Or _
           NHM = "860400" Or NHM = "860500" Then
            bNHMKao8606 = True
            TovarenaPrazna = "TK"
        Else
            bNHMKao8606 = False
        End If

        If (NHM4 = "9921" Or NHM = "9922") And Not (bNHMKao8606) Then
            bSvaTovarena = "PK"
        Else
            bSvaTovarena = "TK"
        End If

        If bSvaTovarena = "TK" Then              ' tovarena

            If dtKola.Rows.Count > 0 Then

                For Each KolaRed In dtKola.Rows    ' petlja po kolima

                    IBK = KolaRed.Item("IndBrojKola")
                    Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                    TipKola = KolaRed.Item("Tip")
                    Vlasnistvo = KolaRed.Item("Vlasnik")
                    BrOsovina = KolaRed.Item("Osovine")

                    '$$$
                    If Vrsta = "O" Then
                        Vrsta = 1
                    End If
                    If Vrsta = "S" Then
                        Vrsta = 2
                    End If
                    '$$$

                    pubSerijaKola = KolaRed.Item("Serija") '## T kola
                    pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola
                    bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

                    If TipKola = "7" Then
                        TovarenaPrazna = "PK"
                    Else
                        TovarenaPrazna = "TK"
                    End If

                    If dtNhm.Rows.Count > 0 Then
                        bRacunskaMasaPoKolima = 0
                        For Each NHMRed In dtNhm.Rows   '  petlja po robi
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                MasaTemp = NHMRed.Item("Masa")
                                NHMRed.Item("RacMasaNHM") = MasaTemp
                                bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + MasaTemp
                            End If
                        Next

                        bZaokruziMasuNa100k(bRacunskaMasaPoKolima)

                        If bRacunskaMasaPoKolima < 10000 Then
                            bRacunskaMasaPoKolima = 10000
                        End If

                        bVrstaStanice = "M"
                        Dim bTarifa As String = "36"

                        Dim bSaobracaj As Integer

                        If bVrstaSaobracaja = 0 Then
                            bSaobracaj = 1
                            bValuta = "72"
                        Else
                            bSaobracaj = 2
                            bValuta = "17"
                        End If

                        Dim bRetValLok As String = ""

                        bNadjiSveIzZSKoefPos(bSaobracaj, bTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                               TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)


                        PrevozninaPoKolima = 0

                    End If

                    bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima


                    bNadjiVozarinskiStavUSSL(Vlasnistvo, VozarinskiStav)
                    ' VozarinskiStav  u RSD za bVrstaSaobracaja = 0
                    '                 u EUR za bVrstaSaobracaja <> 0

                    Dim KolPrevKoef As Decimal = 1
                    PV = ""
                    bNadjiKolPrevKoef("200379", TipKola, "0", "0", "00", "00", "00", KolPrevKoef, PV)

                    VozarinskiStav = VozarinskiStav * KolPrevKoef

                    If Vlasnistvo = "P" Then
                        bZaokruziNaDeseteNavise(VozarinskiStav)
                    End If

                    If mStanica1 = "13603" And mStanica2 = "13670" And Not (Vlasnistvo = "Z") Then
                        KolPrevKoef = 1
                        VozarinskiStav = 1.25
                    End If

                    PrevozninaPoKolima = bRacunskaMasaPoKolima * VozarinskiStav / 1000

                    bZaokruziNaDeseteNavise(PrevozninaPoKolima)


                    If bVrstaSaobracaja = 0 Then
                        Dim bKurs As Decimal
                        Dim bRetValLok As String = ""

                        NadjiKurs("17", "3", mOtpDatum, bKursOt, bRetValLok)
                        NadjiKurs("17", "3", mPrDatum, bKursPr, bRetValLok)

                        If mSifraIzjave = "1" Then      ' franko svi troskovi
                            bKurs = bKursOt
                        ElseIf mSifraIzjave = "0" Then  ' upuceno sve
                            bKurs = bKursPr
                        ElseIf mSifraIzjave = "2" Then  ' franko prevoznina ukljucivo
                            bKurs = bKursOt
                        ElseIf mSifraIzjave = "3" Then  ' franko prevoznina
                            bKurs = bKursOt

                            'ElseIf mSifraIzjave = "4" Then  ' franko do iznosa

                        End If
                        PrevozninaPoKolima = PrevozninaPoKolima * bKurs
                        bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    End If

                    bVozarinskiStavPoKolima = VozarinskiStav

                    'mPrevoznina = mIznosDin

                    ' bZaokruziNaDeseteNavise(PrevozninaPoKolima)

                    If ((mStanica1 = "13603" And mStanica2 = "13670")) Or ((mStanica2 = "13603" And mStanica1 = "13670")) Then
                        bMinPrevoznina = 0
                    End If

                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                    End If

                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                    KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = VozarinskiStav

                    For Each NHMRed In dtNhm.Rows
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                            NHMRed.Item("RacMasaNHM") = bRacunskaMasaPoKolima
                        End If
                    Next
                    Prevoznina = Prevoznina + PrevozninaPoKolima

                Next    ' petlja po kolima

            End If

        ElseIf bSvaTovarena = "PK" Then    ' prazna

            bNadjiPrevozninu00L("122", Prevoznina)

        End If

    End Sub
    Public Sub bNadjiPrevozninuUSSL(ByRef Prevoznina As Decimal)    ' US Steel

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1
        Dim MasaTemp As Integer
        Dim Razred As String

        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim PrevozninaPoKolima As Decimal = 0

        Dim bKurs As Decimal

        bRacunskaMasa = 0
        Prevoznina = 0


        ' #### pokupiti potrebne parametre prvih kola, jer se smatra da su isti za ostala kola ( za grupu ili voz )
        ' ako je grupa ili voz, odgovarajuci parametri sledecih kola ce po potrebi kroz petlju prekriti ove za prva kola

        IBK = dtKola.Rows(0).Item("IndBrojKola")
        Vrsta = dtKola.Rows(0).Item("Vrsta")     ' 1 - obicna,  2 - specijalna

        '$$$
        If Vrsta = "O" Then
            Vrsta = 1
        End If
        If Vrsta = "S" Then
            Vrsta = 2
        End If
        '$$$

        TipKola = dtKola.Rows(0).Item("Tip")
        Vlasnistvo = dtKola.Rows(0).Item("Vlasnik")
        BrOsovina = dtKola.Rows(0).Item("Osovine")



        ' ovaj deo dole je pod komentarom zbog 992110 - 992140, 992210- 992240
        'If dtNhm.Rows(0).Item("NHM") = "992100" Or dtNhm.Rows(0).Item("NHM") = "992200" Then
        '    bSvaTovarena = "PK"
        'Else
        '    bSvaTovarena = "TK"
        'End If
        ' ovaj deo gore je pod komentarom zbog 992110-992140, 992210-992240


        '!!!!!!!!!!!!!!!
        ' ovaj deo dole je dodat zbog 992110-992140, 992210-992240
        Dim NHM As String = dtNhm.Rows(0).Item("NHM")

        NHM4 = (Microsoft.VisualBasic.Left(NHM, 4))

        'Dim bNHMKao8606 = False
        If NHM = "992110" Or NHM = "992120" Or NHM = "992130" Or NHM = "992140" Or _
           NHM = "992210" Or NHM = "992220" Or NHM = "992230" Or NHM = "992240" Or _
           NHM = "860400" Or NHM = "860500" Then
            bNHMKao8606 = True
            TovarenaPrazna = "TK"
        Else
            bNHMKao8606 = False
        End If

        If (NHM4 = "9921" Or NHM = "9922") And Not (bNHMKao8606) Then
            bSvaTovarena = "PK"
        Else
            bSvaTovarena = "TK"
        End If

        ' ovaj deo gore je dodat zbog 992110-992140, 992210-992240
        '!!!!!!!!!!!!!!!


        If TipKola = "7" Then
            TovarenaPrazna = "PK"
        Else
            TovarenaPrazna = "TK"
        End If

        bVrstaStanice = "M"
        Dim bTarifa As String = "36"

        Dim bSaobracaj As Integer

        If bVrstaSaobracaja = 0 Then
            bSaobracaj = 1
            bValuta = "72"
        Else
            bSaobracaj = 2
            bValuta = "17"
        End If

        Dim KolPrevKoef As Decimal = 1
        PV = ""
        bNadjiKolPrevKoef("200379", TipKola, "0", "0", "00", "00", "00", KolPrevKoef, PV)

        If bVrstaSaobracaja = 0 Then

            Dim bRetValLok As String = ""

            NadjiKurs("17", "3", mOtpDatum, bKursOt, bRetValLok)
            NadjiKurs("17", "3", mPrDatum, bKursPr, bRetValLok)

            If mSifraIzjave = "1" Then      ' franko svi troskovi
                bKurs = bKursOt
            ElseIf mSifraIzjave = "0" Then  ' upuceno sve
                bKurs = bKursPr
            ElseIf mSifraIzjave = "2" Then  ' franko prevoznina ukljucivo
                bKurs = bKursOt
            ElseIf mSifraIzjave = "3" Then  ' franko prevoznina
                bKurs = bKursOt

                'ElseIf mSifraIzjave = "4" Then  ' franko do iznosa

            End If
            'PrevozninaPoKolima = PrevozninaPoKolima * bKurs
            'bZaokruziNaDeseteNavise(PrevozninaPoKolima)
        End If

        ' #### pokupiti potrebne parametre prvih kola, jer se smatra da su isti za ostala kola ( za grupu ili voz )
        ' ako je grupa ili voz, odgovarajuci parametri sledecih kola ce po potrebi kroz petlju prekriti ove za prva kola

        Dim ZbirRacMasa As Decimal = 0

        If bSvaTovarena = "TK" Then         ' tovarena

            If dtKola.Rows.Count = 1 Then

                ' T kola ????????

                '''''''pubSerijaKola = KolaRed.Item("Serija") '## T kola
                '''''''pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola

                ' T kola ????????

                ZbirRacMasa = 0
                If dtNhm.Rows.Count > 0 Then
                    bRacunskaMasaPoKolima = 0
                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            NHMRed.Item("RacMasaNHM") = MasaTemp
                            bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + MasaTemp
                        End If
                    Next

                    bZaokruziMasuNa100k(bRacunskaMasaPoKolima)

                    If bRacunskaMasaPoKolima < 10000 Then
                        bRacunskaMasaPoKolima = 10000
                    End If

                    ZbirRacMasa = bRacunskaMasaPoKolima

                End If

            ElseIf dtKola.Rows.Count > 1 Then               '   grupa, voz

                ZbirRacMasa = 0

                For Each KolaRed In dtKola.Rows   '  petlja po kolima
                    bRacunskaMasaPoKolima = 0
                    IBK = KolaRed.Item("IndBrojKola")
                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + MasaTemp
                        End If
                    Next                        '  petlja po robi

                    'bZaokruziMasuNa100k(bRacunskaMasaPoKolima)             ' ukinuto ovde - mail prepiska 8.4.2015 

                    ZbirRacMasa = ZbirRacMasa + bRacunskaMasaPoKolima

                Next                                '  petlja po kolima

                bZaokruziMasuNa100k(ZbirRacMasa)                  ' dodato ovde - mail prepiska 8.4.2015 

                If ZbirRacMasa < 10000 * dtKola.Rows.Count Then
                    ZbirRacMasa = 10000 * dtKola.Rows.Count
                End If

            End If      ' RowCount = 1 ili >1

            bNadjiVozarinskiStavUSSL(Vlasnistvo, VozarinskiStav)

            ' VozarinskiStav  u RSD za bVrstaSaobracaja = 0
            '                 u EUR za bVrstaSaobracaja <> 0

            If ((mStanica1 = "13603" And mStanica2 = "13670")) Or ((mStanica2 = "13603" And mStanica1 = "13670")) Then
                VozarinskiStav = VozarinskiStav
            Else
                VozarinskiStav = VozarinskiStav * KolPrevKoef
                If Vlasnistvo = "P" Then
                    bZaokruziNaDeseteNavise(VozarinskiStav)
                End If
            End If

            bVozarinskiStavPoKolima = VozarinskiStav

            Prevoznina = ZbirRacMasa * VozarinskiStav / 1000

            bZaokruziNaDeseteNavise(Prevoznina)

            bRacunskaMasa571 = ZbirRacMasa

            If bVrstaSaobracaja = 0 Then
                Prevoznina = Prevoznina * bKurs
                bZaokruziNaDeseteNavise(Prevoznina)
            End If

            Dim bRetValLok As String = ""

            Dim TovPraMP As String
            Dim VlasnMP As String
            bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
            If TovPraMP = "" Then
                TovPraMP = TovarenaPrazna
            End If
            If VlasnMP = "" Then
                VlasnMP = Vlasnistvo
            End If
            bNadjiSveIzZSKoefPos(bSaobracaj, bTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                   TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

            ' Tarifa 2015
            'bNadjiSveIzZSKoefPos(bSaobracaj, bTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
            '       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)


            If ((mStanica1 = "13603" And mStanica2 = "13670")) Or ((mStanica2 = "13603" And mStanica1 = "13670")) Then
                bMinPrevoznina = 0
            End If

            If Prevoznina <= bMinPrevoznina * dtKola.Rows.Count Then
                Prevoznina = bMinPrevoznina * dtKola.Rows.Count
            End If


        ElseIf bSvaTovarena = "PK" Then     ' prazna

            bNadjiPrevozninu00L("122", Prevoznina)

        End If

        ' posebno dodati upis racunskih masa i stavova u tabele
        Dim bProsecnaRacMasa As Decimal = 0
        For Each KolaRed In dtKola.Rows   '  petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")

            KolaRed.Item("Prevoznina") = Prevoznina
            KolaRed.Item("RacunskaMasa") = ZbirRacMasa
            KolaRed.Item("VozarinskiStav") = VozarinskiStav

            For Each NHMRed In dtNhm.Rows
                If NHMRed.Item("IndBrojKola") = IBK Then
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                    bProsecnaRacMasa = ZbirRacMasa / dtKola.Rows.Count
                    bZaokruziMasuNa100k(bProsecnaRacMasa)
                    NHMRed.Item("RacMasaNHM") = bProsecnaRacMasa
                End If
            Next
        Next                                '  petlja po kolima

        ' posebno dodati upis racunskih masa i stavova u tabele


    End Sub

    Public Sub bNadjiVozarinskiStavUSSL(ByVal inVlasnistvo As String, ByRef vsUSSteel As Decimal)    ' US Steel

        Dim s1USSteel As String
        Dim s2USSteel As String

        If bVrstaSaobracaja = "1" Or bVrstaSaobracaja = "3" Or bVrstaSaobracaja = "5" Or bVrstaSaobracaja = "8" Then  'uvoz
            s1USSteel = mStanica1
            s2USSteel = mStanica2
        ElseIf bVrstaSaobracaja = "2" Or bVrstaSaobracaja = "4" Or bVrstaSaobracaja = "6" Or bVrstaSaobracaja = "9" Then                      'izvoz
            s1USSteel = mStanica2
            s2USSteel = mStanica1
        End If


        If (mDatumKalk < #1/1/2013#) Then
            If bVrstaSaobracaja = 0 Then
                s1USSteel = mStanica1
                s2USSteel = mStanica2
                If s1USSteel = "13603" Then
                    Select Case s2USSteel
                        Case "13201"
                            vsUSSteel = 2.1
                        Case "13905"
                            vsUSSteel = 2.4
                        Case "13350"
                            vsUSSteel = 2.4
                        Case "14514"
                            vsUSSteel = 2.4
                        Case "12107"
                            vsUSSteel = 4.3
                        Case "16350"
                            vsUSSteel = 4.3
                        Case "13009"
                            vsUSSteel = 4.8
                        Case "12108"
                            vsUSSteel = 4.8
                    End Select
                End If
                s1USSteel = mStanica2
                s2USSteel = mStanica1
                If s1USSteel = "13603" Then
                    Select Case s2USSteel
                        Case "13201"
                            vsUSSteel = 2.1
                        Case "13905"
                            vsUSSteel = 2.4
                        Case "13350"
                            vsUSSteel = 2.4
                        Case "14514"
                            vsUSSteel = 2.4
                        Case "12107"
                            vsUSSteel = 4.3
                        Case "16350"
                            vsUSSteel = 4.3
                        Case "13009"
                            vsUSSteel = 4.8
                        Case "12108"
                            vsUSSteel = 4.8
                    End Select
                End If

            End If              ' bVrstaSaobracaja = 0

            If bVrstaSaobracaja <> 0 Then
                s1USSteel = mStanica1
                s2USSteel = mStanica2
                Select Case s1USSteel
                    Case "23499"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 10.5
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 10.35
                        End If
                    Case "22899"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 10.7
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 11.2
                        End If
                    Case "21099"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 7.6
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 9
                        End If
                    Case "11028"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 12.2
                        ElseIf mStanica2 = "16350" Then
                            vsUSSteel = 18.0
                        End If
                    Case "12498"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 11.5
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 16.9
                        End If
                    Case "16517"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 7.9
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 5.3
                        End If
                    Case "13670"
                        If s2USSteel = "13603" Then
                            If inVlasnistvo = "P" Then
                                vsUSSteel = 1.25
                            ElseIf inVlasnistvo = "Z" Then
                                vsUSSteel = 1.65
                            End If
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 6.35
                        End If
                    Case "16319"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 9.85
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 5.3
                        End If
                    Case "21001"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 4
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 4.65
                        End If
                    Case "16051"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 3.3
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 3.95
                        End If
                    Case "14170"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 10.7
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 12.85
                        End If
                    Case "16871"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 6.6
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 3.65
                        End If
                End Select

                s1USSteel = mStanica2
                s2USSteel = mStanica1
                Select Case s1USSteel
                    Case "23499"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 10.5
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 10.35
                        End If
                    Case "22899"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 10.7
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 11.2
                        End If
                    Case "21099"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 7.6
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 9
                        End If
                    Case "11028"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 12.2
                        ElseIf mStanica2 = "16350" Then
                            vsUSSteel = 18.0
                        End If
                    Case "12498"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 11.5
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 16.9
                        End If
                    Case "16517"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 7.9
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 5.3
                        End If
                    Case "13670"
                        If s2USSteel = "13603" Then
                            If inVlasnistvo = "P" Then
                                vsUSSteel = 1.25
                            ElseIf inVlasnistvo = "Z" Then
                                vsUSSteel = 1.65
                            End If
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 6.35
                        End If
                    Case "16319"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 9.85
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 5.3
                        End If
                    Case "21001"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 4
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 4.65
                        End If
                    Case "16051"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 3.3
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 3.95
                        End If
                    Case "14170"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 10.7
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 12.85
                        End If
                    Case "16871"
                        If s2USSteel = "13603" Then
                            vsUSSteel = 6.6
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 3.65
                        End If
                End Select

            End If          ' bVrstaSaobracaja <>0

        ElseIf (mDatumKalk >= #1/1/2013#) Then
            If bVrstaSaobracaja = 0 Then
                s1USSteel = mStanica1
                s2USSteel = mStanica2
                If s1USSteel = "13603" Then
                    Select Case s2USSteel
                        Case "13201"
                            vsUSSteel = 2.1
                        Case "13905"
                            vsUSSteel = 2.4
                        Case "13350"
                            vsUSSteel = 2.4
                        Case "14514"
                            vsUSSteel = 2.4
                        Case "13060"
                            If (mDatumKalk >= #5/1/2013#) Then      '1. maj 2015
                                vsUSSteel = 4.05
                            End If
                        Case "12107"
                            vsUSSteel = 4.3
                        Case "16350"
                            vsUSSteel = 4.3
                        Case "13009"
                            vsUSSteel = 4.8
                        Case "12108"
                            vsUSSteel = 4.8
                    End Select


                End If
                s1USSteel = mStanica2
                s2USSteel = mStanica1
                If s1USSteel = "13603" Then
                    Select Case s2USSteel
                        Case "13201"
                            vsUSSteel = 2.1
                        Case "13905"
                            vsUSSteel = 2.4
                        Case "13350"
                            vsUSSteel = 2.4
                        Case "14514"
                            vsUSSteel = 2.4
                        Case "13060"
                            If (mDatumKalk >= #5/1/2013#) Then       '1. maj 2015
                                vsUSSteel = 4.05
                            End If
                        Case "12107"
                            vsUSSteel = 4.3
                        Case "16350"
                            vsUSSteel = 4.3
                        Case "13009"
                            vsUSSteel = 4.8
                        Case "12108"
                            vsUSSteel = 4.8
                    End Select
                End If

            End If

            If bVrstaSaobracaja <> 0 Then
                s1USSteel = mStanica1
                s2USSteel = mStanica2
                Select Case s1USSteel
                    Case "23499"            ' Subotica gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 10.65
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 10.5
                        End If
                    Case "22899"            ' Kikinda gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 11
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 11.4
                        End If
                    Case "21099"            ' Vrsac gr.
                        If s2USSteel = "13603" Then         ' Radinac       
                            vsUSSteel = 7.8
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 9.25
                        End If
                    Case "11028"            ' Presevo gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 12.55
                        ElseIf mStanica2 = "16350" Then     ' Sabac
                            vsUSSteel = 18.3
                        End If
                    Case "12498"            ' Dimitrovgrad gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 11.5
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 17.2
                        End If
                    Case "16517"            ' Sid gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 8.1
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 5.4
                        End If
                    Case "13670"            ' Smederevo
                        If s2USSteel = "13603" Then         ' Radinac
                            If inVlasnistvo = "P" Then
                                vsUSSteel = 1.28                ' treba 1.28 kao i obratno
                            ElseIf inVlasnistvo = "Z" Then
                                vsUSSteel = 1.7                 ' treba  1.70
                            End If
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 6.7
                        End If
                    Case "16319"            ' Brasina gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 10
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 5.4
                        End If
                    Case "21001"            ' Pancevo Varos
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 4.1
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 4.75
                        End If
                    Case "16051"            ' Beograd D.Grad
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 3.4
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 4.05
                        End If
                    Case "14170"            ' Prahovo pristaniste
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 11
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 13.2
                        End If
                    Case "16871"            ' Novi Sad ranzirna
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 6.8
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 3.75                ' Sabac
                        End If
                End Select

                s1USSteel = mStanica2
                s2USSteel = mStanica1
                Select Case s1USSteel
                    Case "23499"            ' Subotica gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 10.65
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 10.5
                        End If
                    Case "22899"            ' Kikinda gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 11
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 11.4
                        End If
                    Case "21099"            ' Vrsac gr.
                        If s2USSteel = "13603" Then         ' Radinac       
                            vsUSSteel = 7.8
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 9.25
                        End If
                    Case "11028"            ' Presevo gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 12.55
                        ElseIf mStanica2 = "16350" Then     ' Sabac
                            vsUSSteel = 18.3
                        End If
                    Case "12498"            ' Dimitrovgrad gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 11.5
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 17.2
                        End If
                    Case "16517"            ' Sid gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 8.1
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 5.4
                        End If
                    Case "13670"            ' Smederevo
                        If s2USSteel = "13603" Then         ' Radinac
                            If inVlasnistvo = "P" Then
                                vsUSSteel = 1.28                ' treba 1.28 kao i obratno
                            ElseIf inVlasnistvo = "Z" Then
                                vsUSSteel = 1.7                 ' treba  1.70
                            End If
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 6.7
                        End If
                    Case "16319"            ' Brasina gr.
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 10
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 5.4
                        End If
                    Case "21001"            ' Pancevo Varos
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 4.1
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 4.75
                        End If
                    Case "16051"            ' Beograd D.Grad
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 3.4
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 4.05
                        End If
                    Case "14170"            ' Prahovo pristaniste
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 11
                        ElseIf s2USSteel = "16350" Then     ' Sabac
                            vsUSSteel = 13.2
                        End If
                    Case "16871"            ' Novi Sad ranzirna
                        If s2USSteel = "13603" Then         ' Radinac
                            vsUSSteel = 6.8
                        ElseIf s2USSteel = "16350" Then
                            vsUSSteel = 3.75                ' Sabac
                        End If
                End Select

            End If      ' bVrstaSaobracaja <>0


        End If          ' mDatumKalk >= 1.1.2013.


    End Sub
    Public Sub bNadjiPrevozninuCOL(ByRef outPrevoznina As Decimal) 'RSD
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

        Dim bNPZaKola As String = ""

        Dim NHMTemp As String

        Dim bStvarnaMasaPoKolima As Decimal = 0
        Dim bStvarnaMasaPoPosiljci As Decimal = 0
        outPrevoznina = 0

        bRedovanOrocen = "R"

        Dim ugUslovZaStav As Integer = TonskiStavInteger
        Dim ugCena As Decimal
        Dim ugTipCene As Integer
        Dim ugRetVal As String = ""
        Dim ugDodatak As Decimal
        Dim ugKoeficijent As Decimal
        'Dim StvarnaMasaPoKolima As Decimal = 0
        Dim tmpMasa As Int32
        Dim outStav As String
        Dim rvco As String
        Dim RacMasaZaAneks As Decimal
        Dim k As Int16 = 1

        Dim bSmartCargoSmedRadTR As Boolean = False
        Dim bHSSmedRadTR As Boolean = False

        Dim bStanicaTemp1 = ""
        Dim bStanicaTemp2 = ""

        If mManipulativnoMesto1 <> "" Then
            bStanicaTemp1 = mStanica1
            mStanica1 = mManipulativnoMesto1
        End If

        If mManipulativnoMesto2 <> "" Then
            bStanicaTemp2 = mStanica2
            mStanica2 = mManipulativnoMesto2
        End If


        If (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0286") And _
                ((mStanica1 = "13670" And mStanica2 = "13603") Or (mStanica1 = "14514" And mStanica2 = "13603")) Then
            bSmartCargoSmedRadTR = True
        End If

        If (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") And _
              ((mStanica1 = "13670" And mStanica2 = "13603") Or (mStanica1 = "13603" And mStanica2 = "13670")) Then
            bHSSmedRadTR = True
        End If


        '   Upis racunske mase i voz. stava
        '   Prvo sve rac mase na nulu:

        If dtKola.Rows.Count > 0 Then                             ' ako su ispravno upisana bar jedna kola
            For Each KolaRed In dtKola.Rows                            ' petlja po kolima - pocetak
                IBK = KolaRed.Item("IndBrojKola")
                For Each NHMRed In dtNhm.Rows   '  petlja po robi za racunske mase
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        NHMRed.Item("RacMasaNHM") = 0
                    End If
                Next
            Next                                                        ' petlja po kolima - kraj
        Else
            'nema ni kola ni prevoznine
        End If

        bKurs = 1  ' zbog CO za unutrasnji-unutrasnji inace; 25.07.2016
        bKursOt = 1 ' zbog CO za unutrasnji-unutrasnji inace; 25.07.2016
        bKursPr = 1 ' zbog CO za unutrasnji-unutrasnji inace; 25.07.2016
        If Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786" Then
            Dim strRetVal = ""
            NadjiKurs("17", 3, mOtpDatum, bKursOt, strRetVal)
            NadjiKurs("17", 3, mPrDatum, bKursPr, strRetVal)
            If mSifraIzjave = "1" Then      ' franko svi troskovi
                bKurs = bKursOt
            ElseIf mSifraIzjave = "0" Then  ' upuceno sve
                bKurs = bKursPr
            ElseIf mSifraIzjave = "2" Then  ' franko prevoznina ukljucivo
                bKurs = bKursOt
            ElseIf mSifraIzjave = "3" Then  ' franko prevoznina
                bKurs = bKursOt
            End If
        End If



        If bVrstaSaobracaja = 0 Then                    'RSD

            If mVrstaPrevoza = "P" Then
                mPrevoznina = 0
                If dtKola.Rows.Count > 0 Then
                    'RedniBroj = 0
                    For Each KolaRed In dtKola.Rows    ' petlja po kolima za RSD
                        ' ucitavanje polja
                        'dodeliti vrednosti za promenljive
                        IBK = KolaRed.Item("IndBrojKola")
                        Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                        TipKola = Left(KolaRed.Item("Tip"), 1)
                        Vlasnistvo = KolaRed.Item("Vlasnik")
                        BrOsovina = KolaRed.Item("Osovine")
                        bStitna = KolaRed.Item("Stitna")
                        bNPZaKola = KolaRed.Item("ICF")

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
                        Dim bSaobracaj As Integer
                        If bValuta = "72" Then
                            bSaobracaj = 1
                        ElseIf bValuta = "17" Then
                            bSaobracaj = 2
                        End If

                        ' postavljeno mTarifa = "36" zbog nalazenja minimalne prevoznine

                        Dim bRetValLok As String = ""

                        Dim TovPraMP As String
                        Dim VlasnMP As String
                        bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                        If TovPraMP = "" Then
                            TovPraMP = TovarenaPrazna
                        End If
                        If VlasnMP = "" Then
                            VlasnMP = Vlasnistvo
                        End If

                        bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", VlasnMP, _
                               TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                        bStvarnaMasaPoKolima = 0

                        For Each NHMRed In dtNhm.Rows   '  petlja po robi
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                bStvarnaMasaPoKolima = bStvarnaMasaPoKolima + NHMRed.Item("Masa")
                                'NHMTemp = NHMRed.Item("NHM")
                            End If
                        Next

                        ' Testiraj na minimalnu prevozninu

                        'Prevoznina = Prevoznina + PrevozninaPoKolima
                        'bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                        ' ------------- ostaje dok se ne ispravi
                        'If ugTipCene = 4 Or ugTipCene = 5 Then
                        '    bMinPrevoznina = 0
                        'End If

                        'If mBrojUg = "141300" Or mBrojUg = "111311" Then
                        '    bMinPrevoznina = 15
                        'End If

                        'If ugTipCene = 5 Or ugTipCene = 15 Then
                        '    PrevozninaPoKolima = 0
                        '    outPrevoznina = ugCena
                        'End If

                        'If Not (ugTipCene = 12) Then
                        '    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                        'End If

                        'If ugTipCene <> 5 And ugTipCene <> 10 And ugTipCene <> 15 Then
                        '    If PrevozninaPoKolima <= bMinPrevoznina Then
                        '        PrevozninaPoKolima = bMinPrevoznina
                        '    End If
                        'End If
                        '' ------------- end ostaje dok se ne ispravi

                        'KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                        'KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                        'KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                        'KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                        'outPrevoznina = outPrevoznina + PrevozninaPoKolima
                        'bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima



                        'For Each NHMRed In dtNhm.Rows
                        '    If NHMRed.Item("IndBrojKola") = IBK Then
                        '        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        '        Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                        '        bZaokruziMasuNa100k(MasaTemp1)

                        '        If bRacunskaMasaNHM <= MasaTemp1 Then
                        '            bRacunskaMasaNHM = MasaTemp1
                        '        End If
                        '        If bRacunskaMasaNHM <= BrOsovina * 5000 Then
                        '            bRacunskaMasaNHM = BrOsovina * 5000
                        '        End If

                        '        NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                        '        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                        '    End If
                        'Next

                        bStvarnaMasaPoPosiljci = bStvarnaMasaPoPosiljci + bStvarnaMasaPoKolima

                        ' * * * * *  ANEKS  * * * * *

                        NHMTemp = dtNhm.Rows(0).Item("NHM")

                        'Dim Stitna As String               zamenjeno sa bStitna
                        bStitna = KolaRed.Item("Stitna")
                        If bStitna = "N" Then bStitna = "1"


                        If bNarocitaPosiljka Then
                            ugUslovZaStav = 19
                        Else
                            ugUslovZaStav = 1       ' formalno
                        End If

                        ' ************************* Novi AneksCO *******************************

                        ugUslovZaStav = TonskiStavInteger
                        ugRetVal = ""

                        NadjiAneksNovo(mBrojUg, "1", mStanica1, mStanica2, _
                                       BrOsovina, mVrstaPrevoza, Vlasnistvo, bStitna, _
                                       mDatumKalk, 0, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                       ugUslovZaStav, ugCena, ugTipCene, ugRetVal)

                        '=========================== korekcija aneksa ===============================                   
                        If (ugRetVal = "") Then

                            ' dok se ne unesu izracunati stavovi za privatna kola
                            If Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786" And Vlasnistvo = "P" And ugCena <> 0 Then
                                Dim bAneksTg As String = ""
                                Dim ugCena1, ugTipCene1, sqlVlasnistvoKola1 ' formalno
                                Dim nmBMV1 As Int32 = 0

                                bNadjiTg(mBrojUg, "1", mStanica1, mStanica2, _
                                               BrOsovina, mVrstaPrevoza, Vlasnistvo, bStitna, _
                                               mDatumKalk, nmBMV1, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                               ugUslovZaStav, ugCena1, ugTipCene1, sqlVlasnistvoKola1, bAneksTg, ugRetVal)

                                ''' dosledno:
                                '''If bAneksTg = "osn.ugovor" Or bAneksTg = "117" Or bAneksTg = "351f" Or bAneksTg = "353f" Then
                                '''    ugCena = 0.9 * ugCena
                                '''    bZaokruziNaDeseteNavise(ugCena)
                                '''End If

                                ' bez poziva na broj Tg
                                ugCena = 0.9 * ugCena
                                bZaokruziNaDeseteNavise(ugCena)

                            End If


                            
                            bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)            '27.07.2016

                            'RacMasaZaAneks = bStvarnaMasaPoPosiljci

                            If Microsoft.VisualBasic.Left(mBrojUg, 4) = "5255" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "5248" Then
                                If RacMasaZaAneks < 600000 Then
                                    RacMasaZaAneks = 600000
                                End If
                            End If

                            bZaokruziMasuNa100k(RacMasaZaAneks)

                            'bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                            '                 RacMasaZaAneks, ugCena, _
                            '                 RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)

                            'ostalo staro dok ne ispravim
                            'If ((ugTipCene = 3) And (ugUslovZaStav = TonskiStavInteger)) Then
                            '    'ponovo, jer je nov stav:
                            '    VozarinskiStav = ugCena
                            '    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '    If Not (Masa1R = 0) Then
                            '        bVozarinskiStavPoKolima = VozarinskiStav
                            '    End If
                            '    Prev2R = Prev2R * bPrevozninaKoef

                            '    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '    If Not (Masa2R = 0) And (Masa1R = 0) Then
                            '        bVozarinskiStavPoKolima = VozarinskiStav
                            '    End If
                            '    Prev2R = Prev2R * bPrevozninaKoef

                            '    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '    If Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0) Then
                            '        bVozarinskiStavPoKolima = VozarinskiStav
                            '    End If
                            '    Prev3R = Prev3R * bPrevozninaKoef

                            '    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!
                            '    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                            '    Prev = PrevozninaPoKolima 'mora ovako zbog (***)!

                            '    ' $#$#$#$#$
                            '    RacMasaZaAneks = Masa1R + Masa2R + Masa3R
                            '    ' $#$#$#$#$
                            'End If
                            'end


                            'If ugTipCene = 1 Then
                            '    'bVozarinskiStavPoKolima = ugCena
                            'Else
                            '    bVozarinskiStavPoKolima = ugCena
                            'End If

                            '''''''''''mPrevoznina = PrevozninaPoKolima

                            'bRacunskaMasaPoKolima = RacMasaZaAneks

                            '   26.07.2016;     zaokruzivanje dva puta

                            'outPrevoznina = RacMasaZaAneks * ugCena * bKurs / 1000

                            PrevozninaPoKolima = RacMasaZaAneks * ugCena / 1000

                            bZaokruziNaDeseteNavise(PrevozninaPoKolima)

                            If mBrojUg = "078600" Then                  ' dok se ne sredi RSD - EUR cene i vrste obracuna
                                PrevozninaPoKolima = PrevozninaPoKolima * bKurs
                                bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                            End If

                            '   26.07.2016;     zaokruzivanje dva puta

                            If ugTipCene <> 10 Then
                                If PrevozninaPoKolima < bMinPrevoznina Then
                                    PrevozninaPoKolima = bMinPrevoznina
                                End If
                            End If



                            IBK = KolaRed.Item("IndBrojKola")
                            For Each NHMRed In dtNhm.Rows   '  petlja po robi za racunske mase
                                If NHMRed.Item("IndBrojKola") = IBK Then
                                    NHMRed.Item("RacMasaNHM") = RacMasaZaAneks
                                    NHMRed.Item("VozarinskiStavNHM") = ugCena
                                End If
                            Next

                        End If
                        '========================= end korekcija aneksa =============================
                        mPrevoznina = mPrevoznina + PrevozninaPoKolima

                    Next    ' petlja po kolima

                Else            ' If UkupnoKola > 0
                    'nema ni kola ni prevoznine
                End If

                outPrevoznina = mPrevoznina


                '''''''Upis racunske mase i voz. stava
                ''''''' Prvo sve rac mase na nulu:
                ''''''If dtKola.Rows.Count > 0 Then                             ' ako su ispravno upisana bar jedna kola
                ''''''    For Each KolaRed In dtKola.Rows                            ' petlja po kolima - pocetak
                ''''''        IBK = KolaRed.Item("IndBrojKola")
                ''''''        For Each NHMRed In dtNhm.Rows   '  petlja po robi za racunske mase
                ''''''            If NHMRed.Item("IndBrojKola") = IBK Then
                ''''''                NHMRed.Item("RacMasaNHM") = 0
                ''''''            End If
                ''''''        Next
                ''''''    Next                                                        ' petlja po kolima - kraj
                ''''''Else
                ''''''    'nema ni kola ni prevoznine
                ''''''End If




                ''''''If dtKola.Rows.Count > 0 Then                             ' ako su ispravno upisana bar jedna kola
                ''''''    For Each KolaRed In dtKola.Rows                            ' petlja po kolima - pocetak
                ''''''        IBK = KolaRed.Item("IndBrojKola")

                ''''''        For Each NHMRed In dtNhm.Rows   '  petlja po robi za racunske mase
                ''''''            If NHMRed.Item("IndBrojKola") = IBK Then
                ''''''                dtNhm.Rows(0).Item("RacMasaNHM") = RacMasaZaAneks
                ''''''                NHMRed.Item("VozarinskiStavNHM") = ugCena
                ''''''            End If
                ''''''        Next
                ''''''        KolaRed.Item("Prevoznina") = outPrevoznina
                ''''''        KolaRed.Item("RacunskaMasa") = RacMasaZaAneks
                ''''''        KolaRed.Item("VozarinskiStav") = ugCena
                ''''''    Next                                                        ' petlja po kolima - kraj

                ''''''Else
                ''''''    'nema ni kola ni prevoznine
                ''''''End If

                bRacunskaMasa571 = RacMasaZaAneks               ' za prikaz na glavnoj formi
                bVozarinskiStavPoKolima = ugCena                ' za prikaz na glavnoj formi

            ElseIf mVrstaPrevoza = "G" Or mVrstaPrevoza = "V" Then

                mPrevoznina = 0
                If dtKola.Rows.Count > 0 Then
                    'RedniBroj = 0
                    For Each KolaRed In dtKola.Rows    ' petlja po kolima za RSD
                        ' ucitavanje polja
                        'dodeliti vrednosti za promenljive
                        IBK = KolaRed.Item("IndBrojKola")
                        Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                        TipKola = Left(KolaRed.Item("Tip"), 1)
                        Vlasnistvo = KolaRed.Item("Vlasnik")
                        BrOsovina = KolaRed.Item("Osovine")
                        bStitna = KolaRed.Item("Stitna")
                        bNPZaKola = KolaRed.Item("ICF")

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
                        Dim bSaobracaj As Integer
                        If bValuta = "72" Then
                            bSaobracaj = 1
                        ElseIf bValuta = "17" Then
                            bSaobracaj = 2
                        End If

                        ' postavljeno mTarifa = "36" zbog nalazenja minimalne prevoznine

                        Dim bRetValLok As String = ""

                        Dim TovPraMP As String
                        Dim VlasnMP As String
                        bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                        If TovPraMP = "" Then
                            TovPraMP = TovarenaPrazna
                        End If
                        If VlasnMP = "" Then
                            VlasnMP = Vlasnistvo
                        End If

                        bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", VlasnMP, _
                               TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                        bStvarnaMasaPoKolima = 0

                        For Each NHMRed In dtNhm.Rows   '  petlja po robi
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                bStvarnaMasaPoKolima = bStvarnaMasaPoKolima + NHMRed.Item("Masa")
                                'NHMTemp = NHMRed.Item("NHM")
                            End If
                        Next

                        ' Testiraj na minimalnu prevozninu

                        'Prevoznina = Prevoznina + PrevozninaPoKolima
                        'bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                        ' ------------- ostaje dok se ne ispravi
                        'If ugTipCene = 4 Or ugTipCene = 5 Then
                        '    bMinPrevoznina = 0
                        'End If


                        'If mBrojUg = "141300" Or mBrojUg = "111311" Then
                        '    bMinPrevoznina = 15
                        'End If

                        'If ugTipCene = 5 Or ugTipCene = 15 Then
                        '    PrevozninaPoKolima = 0
                        '    outPrevoznina = ugCena
                        'End If

                        'If Not (ugTipCene = 12) Then
                        '    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                        'End If

                        'If ugTipCene <> 5 And ugTipCene <> 10 And ugTipCene <> 15 Then
                        '    If PrevozninaPoKolima <= bMinPrevoznina Then
                        '        PrevozninaPoKolima = bMinPrevoznina
                        '    End If
                        'End If
                        '' ------------- end ostaje dok se ne ispravi


                        bStvarnaMasaPoPosiljci = bStvarnaMasaPoPosiljci + bStvarnaMasaPoKolima

                        ' * * * * *  ANEKS  * * * * *

                        'Dim ugUslovZaStav As Integer = TonskiStavInteger
                        'Dim ugCena As Decimal
                        'Dim ugTipCene As Integer
                        'Dim ugRetVal As String = ""
                        'Dim ugDodatak As Decimal
                        'Dim ugKoeficijent As Decimal
                        ''Dim StvarnaMasaPoKolima As Decimal = 0
                        'Dim tmpMasa As Int32
                        'Dim outStav As String
                        'Dim rvco As String
                        'Dim RacMasaZaAneks As Decimal

                        For Each NHMRed In dtNhm.Rows   '  petlja po robi za racunske mase
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                NHMRed.Item("RacMasaNHM") = RacMasaZaAneks
                                NHMRed.Item("VozarinskiStavNHM") = ugCena
                            End If
                        Next


                        ''mPrevoznina = outPrevoznina

                        '''''End If                  '  "P"  "G"  "V"
                        '''''''End If
                        '========================= end korekcija aneksa =============================
                        mPrevoznina = mPrevoznina + PrevozninaPoKolima

                    Next    ' petlja po kolima

                Else            ' If UkupnoKola > 0
                    'nema ni kola ni prevoznine
                End If


                ' PREBACITI OVDE RAÈUNANJE ZA VOZ I GRUPU

                NHMTemp = dtNhm.Rows(0).Item("NHM")

                Dim Stitna As String
                Stitna = dtKola.Rows(0).Item("Stitna")
                If Stitna = "N" Then Stitna = "1"


                If bNarocitaPosiljka Then
                    ugUslovZaStav = 19
                Else
                    ugUslovZaStav = 1       ' formalno
                End If

                ' ************************* Novi AneksCO *******************************

                ugUslovZaStav = TonskiStavInteger
                ugRetVal = ""
                NadjiAneksNovo(mBrojUg, "1", mStanica1, mStanica2, _
                               BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, _
                               mDatumKalk, 0, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                               ugUslovZaStav, ugCena, ugTipCene, ugRetVal)

                '=========================== korekcija aneksa ===============================                   
                If (ugRetVal = "") Then

                    ' dok se ne unesu izracunati stavovi za privatna kola
                    If Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786" And Vlasnistvo = "P" And ugCena <> 0 Then
                        Dim bAneksTg As String = ""
                        Dim ugCena1, ugTipCene1, sqlVlasnistvoKola1 ' formalno
                        Dim nmBMV1 As Int32 = 0

                        bNadjiTg(mBrojUg, "1", mStanica1, mStanica2, _
                                       BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, _
                                       mDatumKalk, nmBMV1, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                       ugUslovZaStav, ugCena1, ugTipCene1, sqlVlasnistvoKola1, bAneksTg, ugRetVal)

                        ''' dosledno:
                        '''If bAneksTg = "osn.ugovor" Or bAneksTg = "117" Or bAneksTg = "351f" Or bAneksTg = "353f" Then
                        '''    ugCena = 0.9 * ugCena
                        '''    bZaokruziNaDeseteNavise(ugCena)
                        '''End If

                        ' bez poziva na broj Tg
                        ugCena = 0.9 * ugCena
                        bZaokruziNaDeseteNavise(ugCena)
                    End If
                End If

                'bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)            '27.07.2016

                'RacMasaZaAneks = bStvarnaMasaPoPosiljci

                'bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                '                 RacMasaZaAneks, ugCena, _
                '                 RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)

                'ostalo staro dok ne ispravim
                'If ((ugTipCene = 3) And (ugUslovZaStav = TonskiStavInteger)) Then
                '    'ponovo, jer je nov stav:
                '    VozarinskiStav = ugCena
                '    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                '    If Not (Masa1R = 0) Then
                '        bVozarinskiStavPoKolima = VozarinskiStav
                '    End If
                '    Prev2R = Prev2R * bPrevozninaKoef

                '    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                '    If Not (Masa2R = 0) And (Masa1R = 0) Then
                '        bVozarinskiStavPoKolima = VozarinskiStav
                '    End If
                '    Prev2R = Prev2R * bPrevozninaKoef

                '    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                '    If Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0) Then
                '        bVozarinskiStavPoKolima = VozarinskiStav
                '    End If
                '    Prev3R = Prev3R * bPrevozninaKoef

                '    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!
                '    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                '    Prev = PrevozninaPoKolima 'mora ovako zbog (***)!

                '    ' $#$#$#$#$
                '    RacMasaZaAneks = Masa1R + Masa2R + Masa3R
                '    ' $#$#$#$#$
                'End If
                'end


                'If ugTipCene = 1 Then
                '    'bVozarinskiStavPoKolima = ugCena
                'Else
                '    bVozarinskiStavPoKolima = ugCena
                'End If

                IBK = KolaRed.Item("IndBrojKola")


                RacMasaZaAneks = bStvarnaMasaPoPosiljci

                bZaokruziMasuNa100k(RacMasaZaAneks)

                If Microsoft.VisualBasic.Left(mBrojUg, 4) = "5255" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "5248" Then
                    If RacMasaZaAneks < 600000 Then
                        RacMasaZaAneks = 600000
                    End If
                End If

                mPrevoznina = RacMasaZaAneks * ugCena / 1000

                bZaokruziNaDeseteNavise(mPrevoznina)

                mPrevoznina = mPrevoznina * bKurs

                bZaokruziNaDeseteNavise(mPrevoznina)

                If mPrevoznina < bMinPrevoznina * dtKola.Rows.Count Then               'za vise kola
                    mPrevoznina = bMinPrevoznina * dtKola.Rows.Count
                End If


                outPrevoznina = mPrevoznina


                '''''''Upis racunske mase i voz. stava
                ''''''' Prvo sve rac mase na nulu:
                ''''''If dtKola.Rows.Count > 0 Then                             ' ako su ispravno upisana bar jedna kola
                ''''''    For Each KolaRed In dtKola.Rows                            ' petlja po kolima - pocetak
                ''''''        IBK = KolaRed.Item("IndBrojKola")
                ''''''        For Each NHMRed In dtNhm.Rows   '  petlja po robi za racunske mase
                ''''''            If NHMRed.Item("IndBrojKola") = IBK Then
                ''''''                NHMRed.Item("RacMasaNHM") = 0
                ''''''            End If
                ''''''        Next
                ''''''    Next                                                        ' petlja po kolima - kraj
                ''''''Else
                ''''''    'nema ni kola ni prevoznine
                ''''''End If

                If dtKola.Rows.Count > 0 Then                             ' ako su ispravno upisana bar jedna kola
                    For Each KolaRed In dtKola.Rows                            ' petlja po kolima - pocetak
                        IBK = KolaRed.Item("IndBrojKola")

                        For Each NHMRed In dtNhm.Rows   '  petlja po robi za racunske mase
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                'dtNhm.Rows(0).Item("RacMasaNHM") = RacMasaZaAneks
                                NHMRed.Item("VozarinskiStavNHM") = ugCena
                            End If
                        Next
                        'KolaRed.Item("Prevoznina") = outPrevoznina
                        'KolaRed.Item("RacunskaMasa") = RacMasaZaAneks
                        KolaRed.Item("VozarinskiStav") = ugCena
                    Next                                                        ' petlja po kolima - kraj

                Else
                    'nema ni kola ni prevoznine
                End If

                bRacunskaMasa571 = RacMasaZaAneks               ' za prikaz na glavnoj formi
                bVozarinskiStavPoKolima = ugCena                ' za prikaz na glavnoj formi

            End If


        ElseIf (bVrstaSaobracaja <> 0) Then             'EUR

            'Dim bbbSaobr As String = "1"

            'Select Case bVrstaSaobracaja
            '    Case 1            'uvoz reex.
            '        bbbSaobr = "2"
            '    Case 2              'izvoz reex.
            '        bbbSaobr = "3"
            '    Case 5              'recni uvoz
            '        bbbSaobr = "2"
            '    Case 6              'recni izvoz
            '        bbbSaobr = "3"
            'End Select

            If mVrstaPrevoza = "P" Then
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
                        bNPZaKola = KolaRed.Item("ICF")


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
                        Dim bSaobracaj As Integer
                        If bValuta = "72" Then
                            bSaobracaj = 1
                        ElseIf bValuta = "17" Then
                            bSaobracaj = 2
                        End If

                        ' postavljeno mTarifa = "36" zbog nalazenja minimalne prevoznine

                        Dim bRetValLok As String = ""

                        Dim TovPraMP As String
                        Dim VlasnMP As String
                        bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                        If TovPraMP = "" Then
                            TovPraMP = TovarenaPrazna
                        End If
                        If VlasnMP = "" Then
                            VlasnMP = Vlasnistvo
                        End If

                        bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", VlasnMP, _
                               TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                        ' Tarifa 2015
                        'bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", Vlasnistvo, _
                        '       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                        '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)


                        bStvarnaMasaPoKolima = 0
                        bRacunskaMasaPoKolima = 0

                        For Each NHMRed In dtNhm.Rows   '  petlja po robi
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                bStvarnaMasaPoKolima = bStvarnaMasaPoKolima + NHMRed.Item("Masa")
                                MasaTemp = NHMRed.Item("Masa")


                                bZaokruziMasuNa100k(MasaTemp)
                                '### 
                                NHMRed.Item("RacMasaNHM") = MasaTemp
                                '### 
                                bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + MasaTemp
                                NHMTemp = NHMRed.Item("NHM")
                            End If
                        Next

                        PrevozninaPoKolima = 0

                        ' -----

                        ' Testiraj na minimalnu prevozninu

                        'Prevoznina = Prevoznina + PrevozninaPoKolima
                        'bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                        ' * * * * *  ANEKS  * * * * *

                        NHMTemp = dtNhm.Rows(0).Item("NHM")

                        Dim Stitna As String
                        Stitna = KolaRed.Item("Stitna")
                        If Stitna = "N" Then Stitna = "1"


                        If bNarocitaPosiljka Then
                            ugUslovZaStav = 19
                        Else
                            ugUslovZaStav = 1       ' formalno
                        End If




                        ' ************************* Novi AneksCO *******************************
                        Dim bbSaobr As String = "1"
                        Select Case bVrstaSaobracaja
                            Case 1            'uvoz reex.
                                bbSaobr = "2"
                            Case 2              'izvoz reex.
                                bbSaobr = "3"
                            Case 5              'recni uvoz
                                bbSaobr = "2"
                            Case 6              'recni izvoz
                                bbSaobr = "3"
                        End Select


                        NadjiAneksNovo(mBrojUg, bbSaobr, mStanica1, mStanica2, _
                                       BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, _
                                       mDatumKalk, 0, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                       ugUslovZaStav, ugCena, ugTipCene, ugRetVal)






                        If Left(mBrojUg, 4) = "0786" And Vlasnistvo = "P" And ugCena <> 0 Then
                            Dim bAneksTg As String = ""
                            Dim ugCena1, ugTipCene1, sqlVlasnistvoKola1 ' formalno
                            Dim nmBMV As Decimal = 1                   ' formalno

                            bNadjiTg(mBrojUg, bbSaobr, mStanica1, mStanica2, _
                                           BrOsovina, mVrstaPrevoza, "Z", Stitna, _
                                           mDatumKalk, nmBMV, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                           ugUslovZaStav, ugCena1, ugTipCene1, sqlVlasnistvoKola1, bAneksTg, ugRetVal)

                            If Microsoft.VisualBasic.Left(bAneksTg, 10) = "osn.ugovor" Or _
                               Microsoft.VisualBasic.Left(bAneksTg, 3) = "351" Then
                                If Not ((mStanica1 = "13603" And mStanica2 = "13670") Or (mStanica1 = "13670" And mStanica2 = "13603")) Then
                                    ugCena = 0.9 * ugCena
                                    bZaokruziNaDeseteNavise(ugCena)
                                End If
                            End If

                        End If

                        ' 15.9.2016
                        If Microsoft.VisualBasic.Left(mBrojUg, 4) = "0286" And Vlasnistvo = "P" And ugCena <> 0 Then
                            Dim bAneksTg As String = ""
                            Dim ugCena1, ugTipCene1, sqlVlasnistvoKola1 ' formalno
                            Dim nmBMV1 As Int32 = 0
                            Dim ugRetVal1 As String = ""

                            bNadjiTg(mBrojUg, bbSaobr, mStanica1, mStanica2, _
                                           BrOsovina, mVrstaPrevoza, Vlasnistvo, bStitna, _
                                           mDatumKalk, nmBMV1, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                           ugUslovZaStav, ugCena1, ugTipCene1, sqlVlasnistvoKola1, bAneksTg, ugRetVal1)

                            ''' dosledno:
                            '''If bAneksTg = "osn.ugovor" Or bAneksTg = "117" Or bAneksTg = "351f" Or bAneksTg = "353f" Then
                            '''    ugCena = 0.9 * ugCena
                            '''    bZaokruziNaDeseteNavise(ugCena)
                            '''End If

                            ' bez poziva na broj Tg

                            If Not ((mStanica1 = "13603" And mStanica2 = "13670") Or (mStanica1 = "13670" And mStanica2 = "13603")) Then
                                ugCena = 0.9 * ugCena
                                bZaokruziNaDeseteNavise(ugCena)
                            End If

                        End If

                        '=========================== korekcija aneksa ===============================
                        'ISPRAVITI ODAVDE!!
                        If (ugRetVal = "") Then

                            bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)

                            bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                                             RacMasaZaAneks, ugCena, _
                                             RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)

                            'ostalo staro dok ne ispravim
                            'If ((ugTipCene = 3) And (ugUslovZaStav = TonskiStavInteger)) Then
                            '    'ponovo, jer je nov stav:
                            '    VozarinskiStav = ugCena
                            '    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '    If Not (Masa1R = 0) Then
                            '        bVozarinskiStavPoKolima = VozarinskiStav
                            '    End If
                            '    Prev2R = Prev2R * bPrevozninaKoef

                            '    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '    If Not (Masa2R = 0) And (Masa1R = 0) Then
                            '        bVozarinskiStavPoKolima = VozarinskiStav
                            '    End If
                            '    Prev2R = Prev2R * bPrevozninaKoef

                            '    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '    If Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0) Then
                            '        bVozarinskiStavPoKolima = VozarinskiStav
                            '    End If
                            '    Prev3R = Prev3R * bPrevozninaKoef

                            '    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!
                            '    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                            '    Prev = PrevozninaPoKolima 'mora ovako zbog (***)!

                            '    ' $#$#$#$#$
                            '    RacMasaZaAneks = Masa1R + Masa2R + Masa3R
                            '    ' $#$#$#$#$
                            'End If
                            'end


                            If ugTipCene = 1 Then
                                'bVozarinskiStavPoKolima = ugCena
                            Else
                                bVozarinskiStavPoKolima = ugCena
                            End If

                            '''''''''''mPrevoznina = PrevozninaPoKolima

                            bRacunskaMasaPoKolima = RacMasaZaAneks
                        End If
                        '========================= end korekcija aneksa =============================


                        ' ------------- ostaje dok se ne ispravi
                        If ugTipCene = 4 Or ugTipCene = 5 Then
                            bMinPrevoznina = 0
                        End If


                        If mBrojUg = "141300" Or mBrojUg = "111311" Then
                            bMinPrevoznina = 15
                        End If

                        If ugTipCene = 5 Or ugTipCene = 15 Then
                            PrevozninaPoKolima = 0
                            outPrevoznina = ugCena
                        End If

                        If Not (ugTipCene = 12) Then
                            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                        End If

                        If (ugTipCene <> 5 And ugTipCene <> 10 And ugTipCene <> 15) And Not (bSmartCargoSmedRadTR) And Not (bHSSmedRadTR) Then
                            If PrevozninaPoKolima <= bMinPrevoznina Then
                                PrevozninaPoKolima = bMinPrevoznina
                            End If
                        End If
                        ' ------------- end ostaje dok se ne ispravi

                        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                        KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                        KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                        outPrevoznina = outPrevoznina + PrevozninaPoKolima
                        bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima



                        For Each NHMRed In dtNhm.Rows
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                                Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                                bZaokruziMasuNa100k(MasaTemp1)

                                If bRacunskaMasaNHM <= MasaTemp1 Then
                                    bRacunskaMasaNHM = MasaTemp1
                                End If
                                If bRacunskaMasaNHM <= BrOsovina * 5000 Then
                                    bRacunskaMasaNHM = BrOsovina * 5000
                                End If

                                NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                                NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                            End If
                        Next


                    Next    ' petlja po kolima

                Else
                    'nema ni kola ni prevoznine
                End If
            ElseIf mVrstaPrevoza = "G" Or mVrstaPrevoza = "V" Then
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
                        bNPZaKola = KolaRed.Item("ICF")


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
                        Dim bSaobracaj As Integer
                        If bValuta = "72" Then
                            bSaobracaj = 1
                        ElseIf bValuta = "17" Then
                            bSaobracaj = 2
                        End If

                        ' postavljeno mTarifa = "36" zbog nalazenja minimalne prevoznine

                        Dim bRetValLok As String = ""

                        Dim TovPraMP As String
                        Dim VlasnMP As String
                        bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                        If TovPraMP = "" Then
                            TovPraMP = TovarenaPrazna
                        End If
                        If VlasnMP = "" Then
                            VlasnMP = Vlasnistvo
                        End If

                        bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", VlasnMP, _
                               TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                        ' Tarifa 2015
                        'bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", Vlasnistvo, _
                        '       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                        '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)


                        bStvarnaMasaPoKolima = 0
                        bRacunskaMasaPoKolima = 0

                        For Each NHMRed In dtNhm.Rows   '  petlja po robi
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                bStvarnaMasaPoKolima = bStvarnaMasaPoKolima + NHMRed.Item("Masa")
                                MasaTemp = NHMRed.Item("Masa")
                                'bZaokruziMasuNa100k(MasaTemp)
                                '### 
                                NHMRed.Item("RacMasaNHM") = MasaTemp
                                '### 
                                'bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + MasaTemp
                                NHMTemp = NHMRed.Item("NHM")
                            End If
                        Next


                        ' * * * * *  ANEKS  * * * * *

                        NHMTemp = dtNhm.Rows(0).Item("NHM")

                        Dim bbStitna As String
                        bbStitna = KolaRed.Item("Stitna")
                        If bbStitna = "N" Then bbStitna = "1"


                        If bNarocitaPosiljka Then
                            ugUslovZaStav = 19
                        Else
                            ugUslovZaStav = 1       ' formalno
                        End If




                        ' ************************* Novi AneksCO *******************************
                        Dim bbbSaobr As String = "1"
                        Select Case bVrstaSaobracaja
                            Case 1            'uvoz reex.
                                bbbSaobr = "2"
                            Case 2              'izvoz reex.
                                bbbSaobr = "3"
                            Case 5              'recni uvoz
                                bbbSaobr = "2"
                            Case 6              'recni izvoz
                                bbbSaobr = "3"
                        End Select


                        NadjiAneksNovo(mBrojUg, bbbSaobr, mStanica1, mStanica2, _
                                       BrOsovina, mVrstaPrevoza, Vlasnistvo, bbStitna, _
                                       mDatumKalk, 0, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                       ugUslovZaStav, ugCena, ugTipCene, ugRetVal)

                        '15.9.2016
                        If Microsoft.VisualBasic.Left(mBrojUg, 4) = "0286" And Vlasnistvo = "P" And ugCena <> 0 Then
                            Dim bAneksTg As String = ""
                            Dim ugCena1, ugTipCene1, sqlVlasnistvoKola1 ' formalno
                            Dim nmBMV1 As Int32 = 0

                            bNadjiTg(mBrojUg, bbbSaobr, mStanica1, mStanica2, _
                                           BrOsovina, mVrstaPrevoza, Vlasnistvo, bStitna, _
                                           mDatumKalk, nmBMV1, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                           ugUslovZaStav, ugCena1, ugTipCene1, sqlVlasnistvoKola1, bAneksTg, ugRetVal)

                            ''' dosledno:
                            '''If bAneksTg = "osn.ugovor" Or bAneksTg = "117" Or bAneksTg = "351f" Or bAneksTg = "353f" Then
                            '''    ugCena = 0.9 * ugCena
                            '''    bZaokruziNaDeseteNavise(ugCena)
                            '''End If

                            ' bez poziva na broj Tg

                            If Not ((mStanica1 = "13603" And mStanica2 = "13670") Or (mStanica1 = "13670" And mStanica2 = "13603")) Then
                                ugCena = 0.9 * ugCena
                                bZaokruziNaDeseteNavise(ugCena)
                            End If

                        End If


                        '=========================== korekcija aneksa ===============================
                        'ISPRAVITI ODAVDE!!
                        If (ugRetVal = "") Then

                            bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)

                            bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                                             RacMasaZaAneks, ugCena, _
                                             RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)

                            'ostalo staro dok ne ispravim
                            'If ((ugTipCene = 3) And (ugUslovZaStav = TonskiStavInteger)) Then
                            '    'ponovo, jer je nov stav:
                            '    VozarinskiStav = ugCena
                            '    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '    If Not (Masa1R = 0) Then
                            '        bVozarinskiStavPoKolima = VozarinskiStav
                            '    End If
                            '    Prev2R = Prev2R * bPrevozninaKoef

                            '    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '    If Not (Masa2R = 0) And (Masa1R = 0) Then
                            '        bVozarinskiStavPoKolima = VozarinskiStav
                            '    End If
                            '    Prev2R = Prev2R * bPrevozninaKoef

                            '    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '    If Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0) Then
                            '        bVozarinskiStavPoKolima = VozarinskiStav
                            '    End If
                            '    Prev3R = Prev3R * bPrevozninaKoef

                            '    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!
                            '    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                            '    Prev = PrevozninaPoKolima 'mora ovako zbog (***)!

                            '    ' $#$#$#$#$
                            '    RacMasaZaAneks = Masa1R + Masa2R + Masa3R
                            '    ' $#$#$#$#$
                            'End If
                            'end


                            If ugTipCene = 1 Then
                                'bVozarinskiStavPoKolima = ugCena
                            Else
                                bVozarinskiStavPoKolima = ugCena
                            End If

                            '''''''''''mPrevoznina = PrevozninaPoKolima

                            bRacunskaMasaPoKolima = RacMasaZaAneks
                        End If
                        '========================= end korekcija aneksa =============================


                        ' ------------- ostaje dok se ne ispravi
                        If ugTipCene = 4 Or ugTipCene = 5 Then
                            bMinPrevoznina = 0
                        End If


                        If mBrojUg = "141300" Or mBrojUg = "111311" Then
                            bMinPrevoznina = 15
                        End If

                        If ugTipCene = 5 Or ugTipCene = 15 Then
                            PrevozninaPoKolima = 0
                            outPrevoznina = ugCena
                        End If

                        If Not (ugTipCene = 12) Then
                            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                        End If

                        If (ugTipCene <> 5 And ugTipCene <> 10 And ugTipCene <> 15) And Not (bSmartCargoSmedRadTR) And Not (bHSSmedRadTR) Then
                            If PrevozninaPoKolima <= bMinPrevoznina Then
                                PrevozninaPoKolima = bMinPrevoznina
                            End If
                        End If
                        ' ------------- end ostaje dok se ne ispravi

                        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                        KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                        KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                        outPrevoznina = outPrevoznina + PrevozninaPoKolima
                        bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima



                        For Each NHMRed In dtNhm.Rows
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                                'Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                                'bZaokruziMasuNa100k(MasaTemp1)

                                '        If bRacunskaMasaNHM <= MasaTemp1 Then
                                '            bRacunskaMasaNHM = MasaTemp1
                                '        End If
                                '        If bRacunskaMasaNHM <= BrOsovina * 5000 Then
                                '            bRacunskaMasaNHM = BrOsovina * 5000
                                '        End If

                                NHMRed.Item("RacMasaNHM") = bRacunskaMasaPoKolima
                                NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                            End If
                        Next
                        bStvarnaMasaPoPosiljci = bStvarnaMasaPoPosiljci + bStvarnaMasaPoKolima

                    Next    ' petlja po kolima                    

                Else
                    'nema ni kola ni prevoznine
                End If


                ' PREBACITI OVDE RACUNANJE PREVOZNINE

                Dim Stitna As String
                Stitna = KolaRed.Item("Stitna")
                If Stitna = "N" Then Stitna = "1"


                If bNarocitaPosiljka Then
                    ugUslovZaStav = 19
                Else
                    ugUslovZaStav = 1       ' formalno
                End If




                ' ************************* Novi AneksCO *******************************
                Dim bbSaobr As String = "1"
                Select Case bVrstaSaobracaja
                    Case 1            'uvoz reex.
                        bbSaobr = "2"
                    Case 2              'izvoz reex.
                        bbSaobr = "3"
                    Case 5              'recni uvoz
                        bbSaobr = "2"
                    Case 6              'recni izvoz
                        bbSaobr = "3"
                End Select


                NadjiAneksNovo(mBrojUg, bbSaobr, mStanica1, mStanica2, _
                               BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, _
                               mDatumKalk, 0, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                               ugUslovZaStav, ugCena, ugTipCene, ugRetVal)


                '=========================== korekcija aneksa ===============================
                'ISPRAVITI ODAVDE!!
                If (ugRetVal = "") Then

                    bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)


                    If mBrojUg = "078601" Or mBrojUg = "078602" Then
                        RacMasaZaAneks = bStvarnaMasaPoPosiljci
                        bZaokruziMasuNa100k(RacMasaZaAneks)
                    End If

                    bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                                    RacMasaZaAneks, ugCena, _
                                    RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)

                    If mBrojUg = "078601" Or mBrojUg = "078602" Then
                        bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                        mPrevoznina = PrevozninaPoKolima
                    End If

                    'ostalo staro dok ne ispravim
                    'If ((ugTipCene = 3) And (ugUslovZaStav = TonskiStavInteger)) Then
                    '    'ponovo, jer je nov stav:
                    '    VozarinskiStav = ugCena
                    '    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    '    If Not (Masa1R = 0) Then
                    '        bVozarinskiStavPoKolima = VozarinskiStav
                    '    End If
                    '    Prev2R = Prev2R * bPrevozninaKoef

                    '    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    '    If Not (Masa2R = 0) And (Masa1R = 0) Then
                    '        bVozarinskiStavPoKolima = VozarinskiStav
                    '    End If
                    '    Prev2R = Prev2R * bPrevozninaKoef

                    '    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    '    If Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0) Then
                    '        bVozarinskiStavPoKolima = VozarinskiStav
                    '    End If
                    '    Prev3R = Prev3R * bPrevozninaKoef

                    '    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!
                    '    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    '    Prev = PrevozninaPoKolima 'mora ovako zbog (***)!

                    '    ' $#$#$#$#$
                    '    RacMasaZaAneks = Masa1R + Masa2R + Masa3R
                    '    ' $#$#$#$#$
                    'End If
                    'end


                    'If ugTipCene = 1 Then
                    '    'bVozarinskiStavPoKolima = ugCena
                    'Else
                    '    bVozarinskiStavPoKolima = ugCena
                    'End If

                    '''''''''''mPrevoznina = PrevozninaPoKolima

                    bRacunskaMasaPoKolima = RacMasaZaAneks
                End If
                '========================= end korekcija aneksa =============================


                ' ------------- ostaje dok se ne ispravi
                'If ugTipCene = 4 Or ugTipCene = 5 Then
                '    bMinPrevoznina = 0
                'End If


                'If mBrojUg = "141300" Or mBrojUg = "111311" Then
                '    bMinPrevoznina = 15
                'End If

                'If ugTipCene = 5 Or ugTipCene = 15 Then
                '    PrevozninaPoKolima = 0
                '    outPrevoznina = ugCena
                'End If

                'If Not (ugTipCene = 12) Then
                '    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                'End If

                bZaokruziNaDeseteNavise(mPrevoznina)

                If (ugTipCene <> 5 And ugTipCene <> 10 And ugTipCene <> 15) And Not (bSmartCargoSmedRadTR) And Not (bHSSmedRadTR) Then
                    If mPrevoznina < bMinPrevoznina * dtKola.Rows.Count Then               'za vise kola
                        mPrevoznina = bMinPrevoznina * dtKola.Rows.Count
                    End If
                End If

                outPrevoznina = mPrevoznina

                ' ------------- end ostaje dok se ne ispravi

                'KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                'KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                'KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                'KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                'outPrevoznina = outPrevoznina + PrevozninaPoKolima
                'bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima



                'For Each NHMRed In dtNhm.Rows
                '    If NHMRed.Item("IndBrojKola") = IBK Then
                '        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                '        Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                '        bZaokruziMasuNa100k(MasaTemp1)

                '        If bRacunskaMasaNHM <= MasaTemp1 Then
                '            bRacunskaMasaNHM = MasaTemp1
                '        End If
                '        If bRacunskaMasaNHM <= BrOsovina * 5000 Then
                '            bRacunskaMasaNHM = BrOsovina * 5000
                '        End If

                '        NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                '        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                '    End If
                'Next

            End If
            bRacunskaMasa571 = RacMasaZaAneks


        End If                  ' bVrstaSaobracaja <> 0



        If mManipulativnoMesto1 <> "" Then
            mStanica1 = bStanicaTemp1
        End If

        If mManipulativnoMesto2 <> "" Then
            mStanica2 = bStanicaTemp2
        End If


    End Sub

    Public Sub NadjiAneksNovo(ByVal inUgovor As String, ByVal inSaobracaj As String, _
                                 ByVal inStanicaOd As String, ByVal inStanicaDo As String, _
                                 ByVal inOsovine As Int32, ByVal inVrstaPrevoza As String, _
                                 ByVal inVlasnistvoKola As String, ByVal inVrstaKola As String, _
                                 ByVal inDatum As Date, ByVal inBrutoMasaVoza As Int32, ByVal inNHM As String, _
                                 ByVal inUslovZaStav As Int32, ByRef outCena As Decimal, ByRef outTipCene As Int32, _
                                 ByRef outRetVal As String)

        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("spNadjiAneksNovo", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        ulUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = inUgovor

        Dim ulSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1))
        ulSaobracaj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSaobracaj").Value = inSaobracaj

        Dim ulStanicaOd As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanicaOd", SqlDbType.Char, 5))
        ulStanicaOd.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanicaOd").Value = inStanicaOd

        Dim ulStanicaDo As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanicaDo", SqlDbType.Char, 5))
        ulStanicaDo.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanicado").Value = inStanicaDo

        Dim ulOsovine As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOsovine", SqlDbType.Int))
        ulOsovine.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOsovine").Value = inOsovine

        Dim ulVrstaPrevoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaPrevoza", SqlDbType.Char, 1))
        ulVrstaPrevoza.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaPrevoza").Value = inVrstaPrevoza

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 2))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulVrstaKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaKola", SqlDbType.Char, 1))
        ulVrstaKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaKola").Value = inVrstaKola

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = inDatum

        Dim ulBrutoMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrutoMasa", SqlDbType.Int))
        ulBrutoMasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrutoMasa").Value = inBrutoMasaVoza

        Dim ulNHM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNHM", SqlDbType.Char, 4))
        ulNHM.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNHM").Value = inNHM

        Dim ulUslovZaStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUslovZaStav", SqlDbType.Int))
        ulUslovZaStav.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUslovZaStav").Value = inUslovZaStav

        Dim izCena As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outCena", SqlDbType.Decimal))
        izCena.Size = 9
        izCena.Precision = 10
        izCena.Scale = 2
        izCena.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outCena").Value = outCena

        Dim izTipCene As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTipCene", SqlDbType.Int))
        izTipCene.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTipCene").Value = outTipCene

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()
            outCena = spKomanda.Parameters("@outCena").Value
            outTipCene = spKomanda.Parameters("@outTipCene").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value
        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub

    Public Sub bKorigujPoAneksu(ByVal inVrstaKorekcije As Integer, ByVal inPrevoznina As Decimal, ByVal inKoeficijent As Decimal, _
                                   ByVal inRacunskaMasa As Decimal, ByVal inCena As Decimal, ByVal inStvarnaMasa As Integer, _
                                   ByVal intkm As Integer, ByVal inDodatak As Decimal, ByRef outIzlaz As Decimal)

        ' outIzlaz - cena zavisi od uslova prevoza

        Select Case inVrstaKorekcije
            Case 1              'Procenat na tarifu
                outIzlaz = inPrevoznina * inCena
            Case 2, 12, 13      'Cena po toni, Cena po toni za stvarnu masu                              
                outIzlaz = inCena * inRacunskaMasa / 1000
            Case 3              'Cena po tonskom stavu
                'outIzlaz = ?inUlaz1 * inKoeficijent    ' TonskiStav * Koeficijent
            Case 4, 5, 15, 18, 19     'Cena po kolima, Cena po vozu, Cena po vozu za BMV 
                outIzlaz = inCena
            Case 6
                outIzlaz = inKoeficijent * inStvarnaMasa * intkm / 100 ' StvMasa * km * 0.02
            Case 7
                outIzlaz = inPrevoznina + inDodatak
            Case 8
                outIzlaz = inCena * +inDodatak
            Case 9              'Cena po UTI-ju   
                ' bKorigujPoAneksuAG(Stanica1,Stanica2,cenaPoKontejneru,Prevoznina,SifraNaknade,IznosNaknade)
            Case 10             'Prev=0; MinPrev=0;            
                outIzlaz = 0
        End Select

    End Sub

    Public Sub bNadjiRacMasuZaAneks(ByVal inIBK As String, ByVal inVrstaKorekcije As Integer, ByRef outRacunskaMasa As Integer)

        Dim KolaRed, NHMRed As DataRow
        Dim IBK, Razred As String
        Dim MasaTemp As Decimal
        Dim Masa1R, Masa2R, Masa3R As Integer
        Dim MasaPoKolima As Integer = 0
        'Dim MasaPoPosiljci As Integer = 0

        Masa1R = 0
        Masa1R = 0
        Masa1R = 0
        'inVrstaKorekcije = 2 'NEZAVRSENO!!

        For Each NHMRed In dtNhm.Rows   '  petlja po robi
            If NHMRed.Item("IndBrojKola") = inIBK Then
                MasaTemp = NHMRed.Item("Masa")
                Razred = NHMRed.Item("R")
                Select Case Razred      ' grupisanje po razredima
                    Case "1"
                        Masa1R = Masa1R + MasaTemp
                    Case "2"
                        Masa2R = Masa2R + MasaTemp
                    Case "3"
                        Masa3R = Masa3R + MasaTemp
                End Select
            End If
            MasaPoKolima = Masa1R + Masa2R + Masa3R
        Next

        Select Case inVrstaKorekcije
            Case 1

            Case 2, 13, 18, 19
                bZaokruziMasuNa100k(MasaPoKolima)
                outRacunskaMasa = MasaPoKolima
            Case 3
                outRacunskaMasa = MasaPoKolima
            Case 4, 5, 15
                outRacunskaMasa = MasaPoKolima
            Case 6

            Case 7

            Case 8

            Case 9

            Case 12     ' isto kao pod 2, samo za stvarnu masu, zbog aneksa T518 za 090801, gde je "stvarna masa kola"
                outRacunskaMasa = MasaPoKolima
        End Select
    End Sub
    '''''   OPŠTA STRUKTURA I PETLJE U SLUCAJU ANEKSA

    '''''If dtKola.Rows.Count > 0 Then                                  ' ako su ispravno upisana bar jedna kola
    '''''    For Each KolaRed In dtKola.Rows                            ' petlja po kolima
    '''''        ' ucitavanje polja i dodela vrednosti za promenljive

    '''''        IBK = KolaRed.Item("IndBrojKola")
    '''''        Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
    '''''        TipKola = Left(KolaRed.Item("Tip"), 1)
    '''''        ' . . .
    '''''        bNPZaKola = KolaRed.Item("ICF")

    '''''        ' . . .
    '''''        ' . . .
    '''''        ' . . .

    '''''        bNadjiSveIzZSKoefPos( . . . )                          ' minimalna prevoznina

    '''''        bStvarnaMasaPoKolima = 0
    '''''        bRacunskaMasaPoKolima = 0

    '''''        For Each NHMRed In dtNhm.Rows   '  petlja po robi za racunanje masa
    '''''            If NHMRed.Item("IndBrojKola") = IBK Then
    '''''                bStvarnaMasaPoKolima = bStvarnaMasaPoKolima + NHMRed.Item("Masa")
    '''''                MasaTemp = NHMRed.Item("Masa")
    '''''                bZaokruziMasuNa100k(MasaTemp)
    '''''                '### 
    '''''                NHMRed.Item("RacMasaNHM") = MasaTemp
    '''''                '### 
    '''''                bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + MasaTemp
    '''''                NHMTemp = NHMRed.Item("NHM")
    '''''            End If
    '''''        Next

    '''''        PrevozninaPoKolima = 0

    '''''        ' -----                

    '''''        'Prevoznina = Prevoznina + PrevozninaPoKolima
    '''''        'bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

    '''''        ' * * * * *  ANEKS  * * * * *

    '''''        Dim ugUslovZaStav As Integer = TonskiStavInteger
    '''''        Dim ugCena As Decimal
    '''''        Dim ugTipCene As Integer
    '''''        Dim ugRetVal As String = ""
    '''''        ' . . .
    '''''        ' . . .
    '''''        ' . . .
    '''''        ' ************************* Novi AneksCO *******************************
    '''''        NadjiAneksNovo(mBrojUg, . . .,ugRetVal )
    '''''        '=========================== korekcija po aneksu ===============================

    '''''        If (ugRetVal = "") Then
    '''''            bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)
    '''''            bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
    '''''                             RacMasaZaAneks, ugCena, _
    '''''                             RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)

    '''''            '''''''''''mPrevoznina = PrevozninaPoKolima

    '''''            bRacunskaMasaPoKolima = RacMasaZaAneks
    '''''        End If
    '''''        '========================= end korekcija aneksa =============================

    '''''        ' Testiranje na minimalnu prevozninu
    '''''        If ugTipCene <> 5 And ugTipCene <> 10 And ugTipCene <> 15 Then
    '''''            If PrevozninaPoKolima <= bMinPrevoznina Then
    '''''                PrevozninaPoKolima = bMinPrevoznina
    '''''            End If
    '''''        End If

    '''''        ' ------------- end

    '''''        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
    '''''        KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima

    '''''        ' . . .

    '''''        For Each NHMRed In dtNhm.Rows       ' dodatna provera na osovine
    '''''            If NHMRed.Item("IndBrojKola") = IBK Then
    '''''                bZaokruziMasuNa100k(MasaTemp1)
    '''''                If bRacunskaMasaNHM <= MasaTemp1 Then
    '''''                    bRacunskaMasaNHM = MasaTemp1
    '''''                End If
    '''''                If bRacunskaMasaNHM <= BrOsovina * 5000 Then
    '''''                    bRacunskaMasaNHM = BrOsovina * 5000
    '''''                End If
    '''''                NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
    '''''                NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
    '''''            End If
    '''''        Next

    '''''    Next    ' petlja po kolima

    '''''Else
    '''''    'nema ni kola ni prevoznine
    '''''End If

    '''''   OPŠTA STRUKTURA I PETLJE U SLUÈAJU ANEKSA
    'Raèunanje prevoznine za maršrutne vozove:


    ' Mail Mlaðenko Ðajiæ:
    'Ukupna stvarna masa za pošiljaoèev maršrutni voz utvrðuje se sabiranjem stvarne mase  stvari u svim kolima, odnosno sopstvene mase (tare) praznih kola. 
    'Proseèna raèunska masa po jednim kolima utvrðuje se tako što se ukupna stvarna masa  pošiljke, no najmanje 600.000 kg, 
    'podeli brojem kola u vozu i dobijena masa zaokruži na 100 kg naviše, no najmanje 5.000 kg po osovini za tovarena kola, odnosno 10.000 kg za jedna prazna kola. 

    'Za izraèunavanje prevoznine za maršrutne vozove kada su sa korisnicima ugovoreni neto stavovi, ukupna raèunska masa se utvrðuje kao zbir pojedinaènih stvarnih masa. 
    'Tako dobijen iznos se zaokružuje na 100 kg naviše i množi sa prevoznim stavom po toni. 


    Public Sub Fake()

        'If dtKola.Rows.Count > 0 Then                                  ' ako su ispravno upisana bar jedna kola
        '    For Each KolaRed In dtKola.Rows                            ' petlja po kolima - pocetak
        '        IBK = KolaRed.Item("IndBrojKola")

        '        For Each NHMRed In dtNhm.Rows   '  petlja po robi za racunanje masa
        '            If NHMRed.Item("IndBrojKola") = IBK Then
        '                NHMRed.Item("RacMasaNHM") = MasaTemp

        '                NHMTemp = NHMRed.Item("NHM")
        '            End If
        '        Next

        '        PrevozninaPoKolima = 0

        '        NadjiAneksNovo(mBrojUg, . . .,ugRetVal )
        '        If (ugRetVal = "") Then
        '            bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)
        '            bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
        '                             RacMasaZaAneks, ugCena, _
        '                             RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)

        '            '''mPrevoznina = PrevozninaPoKolima

        '            bRacunskaMasaPoKolima = RacMasaZaAneks
        '        End If

        '        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
        '        KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima

        '    Next    ' petlja po kolima

        'Else
        '    'nema ni kola ni prevoznine
        'End If
    End Sub

    Public Sub bNadjiPrevozninuKont72UI_CO22(ByRef Prevoznina As Decimal)

        Dim KolaRed, NHMRed As DataRow
        Dim IBK As String
        Dim Vlasnistvo As String
        Dim TovarenaPrazna As String
        Dim DuzinaKontStr As String
        Dim DuzinaKont As Integer
        Dim StvMasa As Integer
        Dim UkupnoKola As Byte
        Dim PrevozninaPoKolima As Decimal
        Dim PrevozninaPoKont As Decimal
        Dim VozarinskiStav As Decimal
        Dim Raster As Decimal = 1
        Dim KolKoef As Decimal
        Dim PV As String
        Dim BrOsovina As Integer

        Dim UgUslovZaStav As Integer = 0
        Dim ugRetVal As String = ""
        Dim Stitna As String = "N"
        Dim UgCena As Decimal = 0
        Dim UgTipCene As Integer = 0
        Dim NHMTemp As String = ""


        ' Postupak:
        ' - cena se racuna posebno za svaki UTI i zaokruzuje se samo  jednom i to po UTI-ju na ceo euro navise
        ' - na osnovu duzine ( odnosno sifre LC/CL ) i bruto mase naci raster koeficijent
        ' - na osnovu tkm nalazi se osnovna cena ( str.26 )       
        ' - uracunati bStavKoef
        ' - uracunati bPrevozninaKoef
        ' - uracunati minimalnu prevozninu


        UkupnoKola = dtKola.Rows.Count

        Prevoznina = 0
        Dim TipKola As String
        For Each KolaRed In dtKola.Rows                                         ' petlja po kolima
            PrevozninaPoKolima = 0
            bRacunskaMasaPoKolima = 0
            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            TipKola = KolaRed.Item("Tip")

            BrOsovina = KolaRed.Item("Osovine")


            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            ' Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna

            Dim bSaobracaj As Integer
            If bValuta = "72" Then
                bSaobracaj = 1
            ElseIf bValuta = "17" Then
                bSaobracaj = 2
            End If

            Dim bRetValLok As String = ""

            bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", Vlasnistvo, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

            KolKoef = 1
            'If Vlasnistvo = "P" Or Vlasnistvo = "I" Then
            '    KolKoef = 0.8
            'End If

            For Each NHMRed In dtNhm.Rows
                If IBK = NHMRed.Item("IndBrojKola") Then
                    DuzinaKontStr = Microsoft.VisualBasic.Left(NHMRed.Item("UTI"), 2)
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    StvMasa = NHMRed.Item("Masa")
                    Dim bTovPraKon As String = ""
                    NHMTemp = Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4)
                    'If NHMTemp = "9931" Then
                    '    bTovPraKon = "PraKon"
                    'Else
                    '    bTovPraKon = "TovKon"
                    'End If
                    'bNadjiRaster72UI(DuzinaKont, StvMasa, bTovPraKon, Raster)

                    PrevozninaPoKont = 0

                    'bNadjiVozarinskiStavKontTEA(Tabela, mDatumKalk, bTkm, VozarinskiStav, PV)


                    ' ************************* Novi AneksCO *******************************

                    UgUslovZaStav = DuzinaKont
                    ugRetVal = ""
                    NadjiAneksNovo(mBrojUg, "1", mStanica1, mStanica2, _
                                   BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, _
                                   mDatumKalk, 0, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                   UgUslovZaStav, UgCena, UgTipCene, ugRetVal)

                    '=========================== korekcija aneksa ===============================             

                    'VozarinskiStav = bStavKoef * VozarinskiStav
                    VozarinskiStav = bStavKoef * UgCena
                    bZaokruziNaDeseteNavise(VozarinskiStav)

                    'PrevozninaPoKont = VozarinskiStav * Raster * KolKoef * bPrevozninaKoef
                    PrevozninaPoKont = UgCena
                    bZaokruziNaDeseteNavise(PrevozninaPoKont)

                    NHMRed.Item("UTIRaster") = Raster
                    NHMRed.Item("RacMasaNHM") = StvMasa
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav

                    If bPorekloRobe = 0 Then
                        NHMRed.Item("PorekloRobe") = 0
                    Else
                        NHMRed.Item("PorekloRobe") = 1
                    End If

                    PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaPoKont
                    bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + StvMasa

                End If
            Next
            ' proba na minimalnu prevozninu

            If UgTipCene <> 10 And UgTipCene <> 91 Then
                If PrevozninaPoKolima <= bMinPrevoznina Then
                    PrevozninaPoKolima = bMinPrevoznina
                End If
            End If

            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima

            'If Vlasnistvo = "Z" Then
            '    KolaRed.Item("Naknada") = 36
            'End If

            Prevoznina = Prevoznina + PrevozninaPoKolima
        Next
    End Sub

    Public Sub bPraznaKaoRobaTar2015(ByVal inDatum As Date, ByVal inNHM As String, ByRef outTovarenaPrazna As String, ByRef outVlasnistvoZaMP As String)

        Dim inNHMInt As Integer

        inNHMInt = CType(inNHM, Integer)

        outTovarenaPrazna = ""
        outVlasnistvoZaMP = ""

        If inDatum >= #1/15/2015# Then
            If inNHM = "992100" Or inNHM = "992200" Then
                outTovarenaPrazna = "PK"
            Else
                outTovarenaPrazna = "TK"
            End If
            If ((inNHMInt >= 992110) And (inNHMInt <= 992140)) Or ((inNHMInt >= 992210) And (inNHMInt <= 992240)) Or _
                (inNHMInt = 860400) Or (inNHMInt = 860500) Or (inNHMInt = 860600) Then
                outVlasnistvoZaMP = "Z"
            End If
        End If

    End Sub
    Public Sub bNadjiTg(ByVal inUgovor As String, ByVal inSaobracaj As String, _
                                  ByVal inStanicaOd As String, ByVal inStanicaDo As String, _
                                  ByVal inOsovine As Int32, ByVal inVrstaPrevoza As String, _
                                  ByVal inVlasnistvoKola As String, ByVal inVrstaKola As String, _
                                  ByVal inDatum As Date, ByVal inBrutoMasaVoza As Int32, ByVal inNHM As String, _
                                  ByVal inUslovZaStav As Int32, ByRef outCena As Decimal, ByRef outTipCene As Int32, ByRef outVlasnistvoKola As String, _
                                  ByRef outTg As String, _
                                  ByRef outRetVal As String)

        outRetVal = ""
        outCena = 0

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spString As String = "roba1708.spNadjiTgAneksa"

        'If Microsoft.VisualBasic.Right(mBrojUg, 2) = "22" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "42" Then
        '    spString = "roba1708.spNadjiAneksNovo3"
        'Else
        '    spString = "spNadjiAneksNovo2"
        'End If

        Dim spKomanda As New SqlClient.SqlCommand(spString, OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        ulUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = inUgovor

        Dim ulSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1))
        ulSaobracaj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSaobracaj").Value = inSaobracaj

        Dim ulStanicaOd As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanicaOd", SqlDbType.Char, 5))
        ulStanicaOd.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanicaOd").Value = inStanicaOd

        Dim ulStanicaDo As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanicaDo", SqlDbType.Char, 5))
        ulStanicaDo.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanicado").Value = inStanicaDo

        Dim ulOsovine As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOsovine", SqlDbType.Int))
        ulOsovine.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOsovine").Value = inOsovine

        Dim ulVrstaPrevoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaPrevoza", SqlDbType.Char, 1))
        ulVrstaPrevoza.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaPrevoza").Value = inVrstaPrevoza

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 2))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulVrstaKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaKola", SqlDbType.Char, 1))
        ulVrstaKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaKola").Value = inVrstaKola

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = inDatum

        Dim ulBrutoMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrutoMasa", SqlDbType.Int))
        ulBrutoMasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrutoMasa").Value = inBrutoMasaVoza

        Dim ulNHM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNHM", SqlDbType.Char, 4))
        ulNHM.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNHM").Value = inNHM

        Dim ulUslovZaStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUslovZaStav", SqlDbType.Int))
        ulUslovZaStav.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUslovZaStav").Value = inUslovZaStav

        Dim izCena As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outCena", SqlDbType.Decimal))
        izCena.Size = 9
        izCena.Precision = 10
        izCena.Scale = 2
        izCena.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outCena").Value = outCena

        Dim izTipCene As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTipCene", SqlDbType.Int))
        izTipCene.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTipCene").Value = outTipCene

        Dim izVlKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVlasnistvoKola", SqlDbType.Char, 2))
        izVlKola.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVlasnistvoKola").Value = outVlasnistvoKola

        Dim izTg As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTg", SqlDbType.Char, 10))
        izTg.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTg").Value = outTg

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()
            outCena = spKomanda.Parameters("@outCena").Value
            outTipCene = spKomanda.Parameters("@outTipCene").Value
            outVlasnistvoKola = spKomanda.Parameters("@outVlasnistvoKola").Value
            outTg = spKomanda.Parameters("@outTg").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

            'If inUgovor = "401601" And inVlasnistvoKola = "P" And outCena <> 0 Then
            '    outCena = 0.9 * outCena
            '    bZaokruziNaDeseteNavise(outCena)
            'End If


        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"

        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()

        End Try
    End Sub
End Module
