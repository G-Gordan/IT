Imports System.Data.SqlClient
Module KalkModulCO
    Public SpecijalniHCD As Boolean = False
    Public Sub bNadjiPrevozninuCO()

        Dim bKolKoef, bPrevKoef As Decimal
        Dim PV As String

        SpecijalniHCD = False

        ' ZA UVOZ-IZVOZ:

        ' bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
        ' prvo se vidi da li je preko luke Bar ili za/iz HSH i ŽCG - procedura bDaLiJeBarIHSH(DaNe)
        ' za "obican" uvoz i izvoz tabela je 122
        ' za luku Bar, HSH i ŽCG tabela je 161

        DaLiJeSpecijalniHCD(mBrojUg, SpecijalniHCD)

        If SpecijalniHCD Then
            bNadjiPrevozninuSpecHCD(mBrojUg, mPrevoznina)                                   ' Specijalni, "HARDKODIRANI"

        Else
            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "00" Then                           ' "obicne" pojedinacne posiljke;  tu su i kontejneri
                If IzborSaobracaja = "4" Then        ' TRANZIT
                    If Not (bKontejneri) Then
                        bNadjiPrevozninu00CO(mPrevoznina) 'ok
                    Else
                        bNadjiPrevozninuKontCO(mPrevoznina)
                    End If
                Else                                    ' UVOZ/IZVOZ
                    If Not (bKontejneri) Then
                        If mStanica1 = "15723" Or mStanica2 = "15723" Then
                            mTabelaCena = "161"
                        Else
                            mTabelaCena = "122"
                        End If
                        bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
                    Else
                        bNadjiPrevozninuKontCO(mPrevoznina)
                    End If
                End If
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "67" Then                       ' sporazum 767  ; isto kao TEA, sa drugom tabelom 
                bValuta = "17"
                If Not (bKontejneri) Then
                    mTabelaCena = "767"
                    bNadjiPrevozninuTEA(mTabelaCena, mPrevoznina)
                Else
                    mTabelaCena = "134"
                    bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
                End If
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "02" Then                       ' grupe kola
                If IzborSaobracaja = "4" Then        ' TRANZIT
                    bNadjiPrevozninu02CO(mPrevoznina) ' ok
                Else                                 ' UVOZ_IZVOZ
                    If mStanica1 = "15723" Or mStanica2 = "15723" Then
                        mTabelaCena = "161"
                    Else
                        mTabelaCena = "122"
                    End If
                    bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
                End If
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "01" Then                       ' vozovi
                If IzborSaobracaja = "4" Then        ' TRANZIT
                    bNadjiPrevozninu01CO(mPrevoznina)
                Else                                 ' UVOZ_IZVOZ
                    If mStanica1 = "15723" Or mStanica2 = "15723" Then
                        mTabelaCena = "161"
                    Else
                        mTabelaCena = "122"
                    End If
                    bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
                End If
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" Then                       ' TEA tarifa
                bValuta = "17"
                If Not (bKontejneri) Then
                    If IzborSaobracaja = 4 Then
                        mTabelaCena = "681"
                    Else
                        mTabelaCena = "680"
                    End If
                    bNadjiPrevozninuTEA(mTabelaCena, mPrevoznina)
                Else
                    mTabelaCena = "134"
                    bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
                End If
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "22" Then                       ' Kontenerski voz Prodos
                bNadjiPrevozninu22CO(mPrevoznina)
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "68" Then                       ' jug-sever gvozdje i vino!
                bNadjiPrevozninu00CO(mPrevoznina) 'ok
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "69" Then                       ' jug-sever
                bNadjiPrevozninu00CO(mPrevoznina) 'ok
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "11" Then                       ' prazna "P" kola
                If IzborSaobracaja = "4" Then        ' TRANZIT
                    bNadjiPrevozninu11CO(mPrevoznina)
                Else                                              ' UVOZ_IZVOZ
                    mTabelaCena = "122"
                    'bNadjiPrevozninu11COUI(mTabelaCena, mPrevoznina)
                    bNadjiPrevozninu11CO(mPrevoznina)
                End If
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "12" Then                       ' revizija praznih kola
                bNadjiPrevozninu12CO(mPrevoznina)
            End If
        End If

    End Sub
    Public Sub NadjiVrstu00CO(ByVal inPrelaz1 As String, ByVal inPrelaz2 As String, _
                                            ByVal inOtpravnaUprava As String, ByVal inUputnaUprava As String, _
                                            ByRef outVrsta00Tranzita As Byte)

        outVrsta00Tranzita = 1               ' suvozemni

        Select Case inPrelaz1
            Case "14170", "16051", "16871", "21001"
                outVrsta00Tranzita = 2       ' recni
        End Select

        Select Case inPrelaz2
            Case "14170", "16051", "16871", "21001"
                outVrsta00Tranzita = 2       ' recni
        End Select

    End Sub

    Public Sub bNadjiPrevozninu00CO(ByRef Prevoznina As Decimal)

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        'Dim RedniBroj As Int32
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
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
        Dim VozarinskiStavPoKolima As Decimal = 0
        Dim RacMasaPoKolima As Integer = 0

        Dim Tabela As String

        Dim bVrsta00tranzita As Byte = 1

        NadjiVrstu00CO(mStanica1, mStanica2, mOtpUprava, mPrUprava, bVrsta00tranzita)
        ' Vrsta00Tranzita: 1-suvozemni, 2-recni, 3-morski ( preko luke Bar ), ...


        '------------------ Nalazi sifru tabele iz SifTabCen ---------------------
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""

        Util.sNadjiNaziv("NazivTabele", mBrojUg, "", "", 1, xNaziv, xPovVrednost)

        If xPovVrednost <> "" Then
            mTabelaCena = " "
        Else
            mTabelaCena = xNaziv
        End If
        '-------------------------------------------------------------------------

        If bVrsta00tranzita = 1 Then                  ' suvozemni
            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "69" Then
                'mTabelaCena = "181"
                'Tabela = "181"
                Tabela = mTabelaCena
            Else
                'If Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1006" Then
                '    mTabelaCena = "173"
                '    Tabela = "173"
                'Else
                '    mTabelaCena = "171"
                '    Tabela = "171"
                'End If
                Tabela = mTabelaCena
            End If
        ElseIf bVrsta00tranzita = 2 Then              ' recni
            mTabelaCena = "172"
            Tabela = "172"
            'ElseIf bVrsta00tranzita = 3 Then         ' morski itd.
            '    Tabela = "???"
        End If

        '2007: ne treba za Prodos
        'Dim bBarIHSH As Boolean = False
        'bDaLiJeBarIHSH(bBarIHSH)
        'If bBarIHSH Then
        '    mTabelaCena = "161"
        '    Tabela = "161"
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

                If TipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If

                bValuta = "17"

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                '--------------????
                'Select Case TipKola
                '    Case "1"
                '        KolKoef = 1.0
                '    Case "2"
                '        KolKoef = 1.2
                '    Case "3"
                '        KolKoef = 0.8
                '    Case "4"
                '        KolKoef = 0.8
                '    Case "5"
                '        KolKoef = 0.8
                '    Case "6"
                '        KolKoef = 0.8
                '    Case "7"
                '        KolKoef = 0.3
                'End Select
                '----------------
                '*****

                Dim TabelaTemp As String
                Dim KolKoefTemp, StavKoefTemp, PrevKoefTemp As Decimal

                '$$$
                If Vrsta = "O" Then
                    Vrsta = 1
                End If
                If Vrsta = "S" Then
                    Vrsta = 2
                End If
                bNadjiKolPrevKoef(mBrojUg, "0", Vrsta, Vlasnistvo, TovarenaPrazna, "00", "00", bPrevozninaKoef, PV)
                '$$$ 

                KolKoef = 1
                bStavKoef = 1

                TabelaTemp = Tabela
                KolKoefTemp = KolKoef
                StavKoefTemp = bStavKoef
                'PrevKoefTemp=bPrevKoef

                'provera
                bNadjiUgKoef(mBrojUg, bVrstaSaobracaja, "N", PrevKoefTemp, PV) '!!!inReka

                If Not (PV = "") Then
                    Tabela = TabelaTemp
                    KolKoef = KolKoefTemp
                    bStavKoef = StavKoefTemp
                    'bPrevKoef =PrevKoefTemp

                End If
                '*****

                If dtNhm.Rows.Count > 0 Then
                    Masa1R = 0
                    Masa2R = 0
                    Masa3R = 0
                    Prev1R = 0
                    Prev2R = 0
                    Prev3R = 0

                    '***

                    RacMasaPoKolima = 0
                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            Razred = NHMRed.Item("R")


                            '    bZaokruziMasuNa100k(MasaTemp)
                            'Select Case Razred                                        ' grupisanje po razredima izbaceno
                            '    Case "1"
                            '        Masa1R = Masa1R + MasaTemp
                            '    Case "2"
                            '        Masa2R = Masa2R + MasaTemp
                            '    Case "3"
                            '        Masa3R = Masa3R + MasaTemp
                            'End Select
                            RacMasaPoKolima = RacMasaPoKolima + MasaTemp
                        End If
                    Next
                End If

                bZaokruziMasuNa100k(RacMasaPoKolima)
                bZaokrMasuNaOsovineP(RacMasaPoKolima, TovarenaPrazna, BrOsovina, RacMasaPoKolima)

                PrevozninaPoKolima = 0

                Dim _mBrojUg As String
                Dim _razred1 As String = "1"
                Dim _razred2 As String = "2"
                Dim _razred3 As String = "3"

                'If Tabela = "171" Then
                '    _razred1 = "0"
                '    _razred2 = "0"
                '    _razred3 = "0"
                '    _mBrojUg = mBrojUg
                'ElseIf Tabela = "181" Then
                '    _mBrojUg = "000000"
                '    If BrOsovina = 2 Then
                '        _razred1 = "1"
                '    Else
                '        _razred1 = "2"
                '    End If
                '    _razred2 = "0"
                '    _razred3 = "0"
                'End If

                '            bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, Masa1R, Masa2R, Masa3R, TonskiStav)
                '            TonskiStavInteger = CType(TonskiStav, Integer)
                '            MasaTemp = TonskiStavInteger * 1000

                If Tabela = "171" Then
                    Dim Masa1, Masa2 As Integer
                    Dim VozarinskiStav1, VozarinskiStav2, PrevozninaPoKolima1, PrevozninaPoKolima2 As Decimal
                    Masa1 = 0
                    Masa2 = 0
                    VozarinskiStav1 = 0
                    VozarinskiStav2 = 0
                    PrevozninaPoKolima1 = 0
                    PrevozninaPoKolima2 = 0

                    Select Case RacMasaPoKolima
                        Case 10000, 15000, 20000, 25000
                            'bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav, PV)
                            bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, "00", "0", "0", VozarinskiStav, PV)

                            VozarinskiStav = bStavKoef * VozarinskiStav
                            bZaokruziNaDeseteNavise(VozarinskiStav)
                            PrevozninaPoKolima = RacMasaPoKolima * VozarinskiStav * KolKoef / 1000
                            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef
                            bRacunskaMasaPoKolima = RacMasaPoKolima
                            bVozarinskiStavPoKolima = VozarinskiStav

                        Case Else
                            If (RacMasaPoKolima > 10000 And RacMasaPoKolima < 15000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 10000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 10000, mStanica1, mStanica2, "00", "0", "0", VozarinskiStav1, PV)
                                Masa2 = 15000
                            End If

                            If (RacMasaPoKolima > 15000 And RacMasaPoKolima < 20000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 15000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 15000, mStanica1, mStanica2, "00", "0", "0", VozarinskiStav1, PV)
                                Masa2 = 20000
                            End If

                            If (RacMasaPoKolima > 20000 And RacMasaPoKolima < 25000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 20000, mStanica1, mStanica2, "00", "0", "0", VozarinskiStav1, PV)
                                Masa2 = 25000
                            End If

                            If (RacMasaPoKolima > 25000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, "00", "0", "0", VozarinskiStav1, PV)
                                Masa2 = RacMasaPoKolima
                            End If

                            Masa1 = RacMasaPoKolima

                            VozarinskiStav1 = bStavKoef * VozarinskiStav1
                            bZaokruziNaDeseteNavise(VozarinskiStav1)
                            PrevozninaPoKolima1 = Masa1 * VozarinskiStav1 * KolKoef / 1000
                            PrevozninaPoKolima1 = PrevozninaPoKolima1 * bPrevozninaKoef
                            bRacunskaMasaPoKolima = Masa1
                            bVozarinskiStavPoKolima = VozarinskiStav1

                            'bNadjiVozarinskiStav(Tabela, mDatumKalk, Masa2, bTkm, Razred, VozarinskiStav2, PV)
                            bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, Masa2, mStanica1, mStanica2, "00", "0", "0", VozarinskiStav2, PV)
                            VozarinskiStav2 = bStavKoef * VozarinskiStav2
                            bZaokruziNaDeseteNavise(VozarinskiStav2)
                            PrevozninaPoKolima2 = Masa2 * VozarinskiStav2 * KolKoef / 1000
                            PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef

                            PrevozninaPoKolima = PrevozninaPoKolima1
                            If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                PrevozninaPoKolima = PrevozninaPoKolima2
                                bRacunskaMasaPoKolima = Masa2
                                bVozarinskiStavPoKolima = VozarinskiStav2

                            End If
                            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    End Select
                End If    ' "171"

                If Tabela = "173" Then 'prodos
                    Dim ProdosUprava As String = "00"
                    Dim Masa1, Masa2 As Integer
                    Dim VozarinskiStav1, VozarinskiStav2, PrevozninaPoKolima1, PrevozninaPoKolima2 As Decimal

                    If mStanica1 = "12498" Or mStanica1 = "11028" Or mStanica1 = "15723" Then
                        ProdosUprava = Microsoft.VisualBasic.Mid(mOtpStanica, 1, 2)
                    End If

                    If mStanica2 = "12498" Or mStanica2 = "11028" Or mStanica2 = "15723" Then
                        ProdosUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)
                    End If

                    Masa1 = 0
                    Masa2 = 0
                    VozarinskiStav1 = 0
                    VozarinskiStav2 = 0
                    PrevozninaPoKolima1 = 0
                    PrevozninaPoKolima2 = 0

                    Select Case RacMasaPoKolima
                        Case 10000, 15000, 20000, 25000
                            'bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav, PV)
                            bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav, PV)

                            '&&&
                            If VozarinskiStav = 0 Then
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav, PV)
                            End If
                            '&&&


                            VozarinskiStav = bStavKoef * VozarinskiStav
                            bZaokruziNaDeseteNavise(VozarinskiStav)
                            PrevozninaPoKolima = RacMasaPoKolima * VozarinskiStav * KolKoef / 1000
                            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef
                            bRacunskaMasaPoKolima = RacMasaPoKolima
                            bVozarinskiStavPoKolima = VozarinskiStav

                        Case Else
                            If (RacMasaPoKolima > 10000 And RacMasaPoKolima < 15000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 10000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 10000, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav1, PV)

                                '&&&
                                If VozarinskiStav1 = 0 Then
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 10000, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav1, PV)
                                End If
                                '&&&

                                Masa2 = 15000
                            End If

                            If (RacMasaPoKolima > 15000 And RacMasaPoKolima < 20000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 15000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 15000, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav1, PV)
                                '&&&
                                If VozarinskiStav1 = 0 Then
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 15000, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav1, PV)
                                End If
                                '&&&

                                Masa2 = 20000
                            End If

                            If (RacMasaPoKolima > 20000 And RacMasaPoKolima < 25000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 20000, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav1, PV)
                                '&&&
                                If VozarinskiStav1 = 0 Then
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 20000, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav1, PV)
                                End If
                                '&&&

                                Masa2 = 25000
                            End If

                            If (RacMasaPoKolima > 25000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav1, PV)
                                '&&&
                                If VozarinskiStav1 = 0 Then
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav1, PV)
                                End If
                                '&&&

                                Masa2 = RacMasaPoKolima
                            End If

                            Masa1 = RacMasaPoKolima

                            VozarinskiStav1 = bStavKoef * VozarinskiStav1
                            bZaokruziNaDeseteNavise(VozarinskiStav1)
                            PrevozninaPoKolima1 = Masa1 * VozarinskiStav1 * KolKoef / 1000
                            PrevozninaPoKolima1 = PrevozninaPoKolima1 * bPrevozninaKoef
                            bRacunskaMasaPoKolima = Masa1
                            bVozarinskiStavPoKolima = VozarinskiStav1

                            'bNadjiVozarinskiStav(Tabela, mDatumKalk, Masa2, bTkm, Razred, VozarinskiStav2, PV)
                            bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, Masa2, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav2, PV)
                            '&&&
                            If VozarinskiStav2 = 0 Then
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 10000, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav2, PV)
                            End If
                            '&&&

                            VozarinskiStav2 = bStavKoef * VozarinskiStav2
                            bZaokruziNaDeseteNavise(VozarinskiStav2)
                            PrevozninaPoKolima2 = Masa2 * VozarinskiStav2 * KolKoef / 1000
                            PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef

                            PrevozninaPoKolima = PrevozninaPoKolima1
                            If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                PrevozninaPoKolima = PrevozninaPoKolima2
                                bRacunskaMasaPoKolima = Masa2
                                bVozarinskiStavPoKolima = VozarinskiStav2

                            End If
                            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    End Select
                End If    ' "173"


                If Tabela = "181" Then

                    If BrOsovina = 2 Then
                        _razred1 = "1"
                    Else
                        _razred1 = "2"
                    End If

                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "00", "0", _razred1, VozarinskiStav, PV)
                    If PV = "" And VozarinskiStav = 0 Then
                        bNadjiVozarinskiStavCO("000000", Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "00", "0", _razred1, VozarinskiStav, PV)
                    End If

                    If Vlasnistvo = "P" Then
                        KolKoef = 0.9
                    End If

                    PrevozninaPoKolima = bStavKoef * VozarinskiStav * KolKoef
                    bVozarinskiStavPoKolima = VozarinskiStav

                End If


                If Tabela = "161" Then
                    bNadjiPrevozninu00COUI(Tabela, PrevozninaPoKolima)
                End If

                ' *****COANEKS

                Dim ugUslovZaStav As Integer
                Dim ugCena As Decimal
                Dim ugTipCene As Integer
                Dim ugRetVal As String = ""
                Dim ugDodatak As Decimal
                Dim ugKoeficijent As Decimal
                Dim NHMTemp As String
                Dim Stitna As String
                Dim StvarnaMasaPoKolima As Decimal = 0

                Stitna = KolaRed.Item("Stitna")

                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        StvarnaMasaPoKolima = StvarnaMasaPoKolima + NHMRed.Item("Masa")
                    End If
                Next

                NHMTemp = dtNhm.Rows(0).Item("NHM")

                NadjiAneks(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                            BrOsovina, "P", Vlasnistvo, Stitna, mDatumKalk, Microsoft.VisualBasic.Left(NHMTemp, 4), ugUslovZaStav, _
                            ugCena, ugTipCene, ugRetVal)

                If ugTipCene = 1 Then
                    ugKoeficijent = ugCena
                End If

                If (ugRetVal = "") Then
                    bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, bRacunskaMasaPoKolima, ugCena, _
                    StvarnaMasaPoKolima, bTkm, ugDodatak, PrevozninaPoKolima)
                    If Not (ugTipCene = 1) Then
                        bVozarinskiStavPoKolima = ugCena
                    End If

                End If

                ' *****COANEKS

                If Tabela <> "181" Then 'Za Jug-Sever ne vazi min. prevoznina
                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                    End If
                End If

                KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                Prevoznina = Prevoznina + PrevozninaPoKolima
                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                '###
                For Each NHMRed In dtNhm.Rows   '  petlja po robi
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        '0304
                        Dim bNaftaJe As Boolean = False
                        Dim bDodatakZaNaftu As Decimal
                        Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                        bDaLiJeNafta(NHMRed.Item("NHM"), bNaftaJe)
                        If bNaftaJe Then
                            'bUkupnoKolaSaNaftom = bUkupnoKolaSaNaftom + 1
                            bNadjiNaftu(NHMRed.Item("NHM"), bTkm, bDodatakZaNaftu)
                            Prevoznina = Prevoznina + bDodatakZaNaftu
                        End If
                        '0304
                        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        bZaokruziMasuNa100k(MasaTemp1)
                        '0304
                        If bRacunskaMasaNHM <= MasaTemp1 Then
                            bRacunskaMasaNHM = MasaTemp1
                        End If
                        If bRacunskaMasaNHM <= BrOsovina * 5000 Then
                            bRacunskaMasaNHM = BrOsovina * 5000
                        End If
                        '0304
                        NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                        '0304

                        'Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        'bZaokruziMasuNa100k(MasaTemp1)
                        'NHMRed.Item("RacMasaNHM") = MasaTemp1
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    End If
                Next
                '###

            Next    ' petlja po kolima

        End If

    End Sub                             ' 00CO
    Public Sub bNadjiPrevozninu00COUI(ByVal Tabela As String, ByRef Prevoznina As Decimal)
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, Stitna As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1
        Dim PrevKoef As Decimal = 1
        Dim Masa1R, Masa2R, Masa3R As Integer
        Dim MasaTemp As Integer
        Dim NHMTemp As String
        Dim Razred As String
        Dim TonskiStav As String
        Dim Prev1R, Prev2R, Prev3R As Decimal
        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim TonskiStavInteger As Integer

        Dim PrevozninaPoKolima As Decimal = 0
        Dim RacMasaPoKolima As Integer
        Dim DoTona As String = "25"
        Dim bVrsta00tranzita As Byte
        Dim inReka As String = ""



        Prevoznina = 0
        bRedovanOrocen = "R"


        If Tabela = "122" Then
            DoTona = "25"
        End If

        If Tabela = "161" Then
            DoTona = "45"
        End If

        If Microsoft.VisualBasic.Right(mBrojUg, 2) = "01" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "02" Then
            NadjiVrstu00CO(mStanica1, mStanica2, mOtpUprava, mPrUprava, bVrsta00tranzita)
            If bVrsta00tranzita = 1 Then
                inReka = "N"
            ElseIf bVrsta00tranzita = 2 Then
                inReka = "D"
            End If
            bNadjiUgKoef(mBrojUg, IzborSaobracaja, inReka, KolKoef, PV)
        End If

        If dtKola.Rows.Count > 0 Then
            'RedniBroj = 0
            For Each KolaRed In dtKola.Rows    ' petlja po kolima
                ' ucitavanje polja
                'dodeliti vrednosti za promenljive

                IBK = KolaRed.Item("IndBrojKola")
                Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                TipKola = KolaRed.Item("Tip")
                Vlasnistvo = KolaRed.Item("Vlasnik")
                BrOsovina = KolaRed.Item("Osovine")
                Stitna = KolaRed.Item("Stitna")

                '$$$
                If Vrsta = "O" Then
                    Vrsta = 1
                End If
                If Vrsta = "S" Then
                    Vrsta = 2
                End If
                '$$$

                If TipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If



                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


                Select Case TipKola
                    Case "1"
                        KolKoef = 1.0
                    Case "2"
                        KolKoef = 1.2
                    Case "3"
                        KolKoef = 0.8
                    Case "4"
                        KolKoef = 0.8
                    Case "5"
                        KolKoef = 0.8
                    Case "6"
                        KolKoef = 0.8
                    Case "7"
                        KolKoef = 0.3
                End Select

                If dtNhm.Rows.Count > 0 Then
                    Masa1R = 0
                    Masa2R = 0
                    Masa3R = 0
                    Prev1R = 0
                    Prev2R = 0
                    Prev3R = 0

                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            NHMTemp = NHMRed.Item("NHM")
                            MasaTemp = NHMRed.Item("Masa")
                            Razred = NHMRed.Item("R")
                            Select Case Razred                                        ' grupisanje po razredima
                                Case "1"
                                    Masa1R = Masa1R + MasaTemp
                                Case "2"
                                    Masa2R = Masa2R + MasaTemp
                                Case "3"
                                    Masa3R = Masa3R + MasaTemp
                            End Select
                        End If
                        bZaokruziMasuNa100k(Masa1R)
                        bZaokruziMasuNa100k(Masa2R)
                        bZaokruziMasuNa100k(Masa3R)
                    Next

                    PrevozninaPoKolima = 0

                    bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, DoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                    TonskiStavInteger = CType(TonskiStav, Integer)
                    MasaTemp = TonskiStavInteger * 1000

                    ' prevoznine po razredima:

                    '                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "1", VozarinskiStav, PV)
                    bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "1", VozarinskiStav, PV)
                    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    ' zaokruzivanje?
                    If Not (Masa1R = 0) Then
                        bVozarinskiStavPoKolima = VozarinskiStav
                    End If

                    Prev1R = Prev1R * bPrevozninaKoef


                    '                   bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "2", VozarinskiStav, PV)
                    bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "2", VozarinskiStav, PV)
                    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    ' zaokruzivanje?
                    If Not (Masa2R = 0) And (Masa1R = 0) Then
                        bVozarinskiStavPoKolima = VozarinskiStav
                    End If

                    Prev2R = Prev2R * bPrevozninaKoef


                    '                  bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "3", VozarinskiStav, PV)
                    bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "3", VozarinskiStav, PV)
                    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    ' zaokruzivanje?
                    If Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0) Then
                        bVozarinskiStavPoKolima = VozarinskiStav
                    End If

                    Prev3R = Prev3R * bPrevozninaKoef

                    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

                    'zaokruzivanje na 0.10 ...


                    bNadjiPrevKoefCOUI(PrevKoef)
                    bZaokruziNaDeseteNavise(PrevozninaPoKolima * PrevKoef)


                    ' Testiraj na minimalnu prevozninu
                    RacMasaPoKolima = Masa1R + Masa2R + Masa3R
                    bRacunskaMasaPoKolima = RacMasaPoKolima

                    ' *****COANEKS

                    Dim ugUslovZaStav As Integer
                    Dim ugCena As Decimal
                    Dim ugTipCene As Integer
                    Dim ugRetVal As String = ""
                    Dim ugDodatak As Decimal
                    Dim ugKoeficijent As Decimal

                    ' izracunati promenljivu "Stitna"
                    NadjiAneks(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                                BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, mDatumKalk, Microsoft.VisualBasic.Left(NHMTemp, 4), ugUslovZaStav, _
                                ugCena, ugTipCene, ugRetVal)

                    If (ugRetVal = "") Then
                        bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, bRacunskaMasaPoKolima, ugCena, _
                        (Masa1R + Masa2R + Masa3R), bTkm, ugDodatak, PrevozninaPoKolima)
                        bVozarinskiStavPoKolima = ugCena
                    End If

                    ' *****COANEKS

                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                    End If


                    '  !!!!    koji vozarinski stav upisati ako postoje tri razreda  i kod svakog se racuna posebna prevoznina ???
                    ' da li raditi kao kod 00T ???
                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                    KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                    Prevoznina = Prevoznina + PrevozninaPoKolima
                    bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                End If


                '###
                'For Each NHMRed In dtNhm.Rows   '  petlja po robi
                '    If NHMRed.Item("IndBrojKola") = IBK Then
                '        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                '        bZaokruziMasuNa100k(MasaTemp1)
                '        NHMRed.Item("RacMasaNHM") = MasaTemp1
                '        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                '    End If
                'Next
                '###
                '###
                For Each NHMRed In dtNhm.Rows   '  petlja po robi
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        '0304
                        Dim bNaftaJe As Boolean = False
                        Dim bDodatakZaNaftu As Decimal
                        Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                        bDaLiJeNafta(NHMRed.Item("NHM"), bNaftaJe)
                        If bNaftaJe Then
                            'bUkupnoKolaSaNaftom = bUkupnoKolaSaNaftom + 1
                            bNadjiNaftu(NHMRed.Item("NHM"), bTkm, bDodatakZaNaftu)
                            Prevoznina = Prevoznina + bDodatakZaNaftu
                        End If
                        '0304
                        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        bZaokruziMasuNa100k(MasaTemp1)
                        '0304
                        If bRacunskaMasaNHM <= MasaTemp1 Then
                            bRacunskaMasaNHM = MasaTemp1
                        End If
                        If bRacunskaMasaNHM <= BrOsovina * 5000 Then
                            bRacunskaMasaNHM = BrOsovina * 5000
                        End If
                        '0304
                        NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                        '0304
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    End If
                Next
                '###

            Next    ' petlja po kolima

        Else
            ' nema ni kola ni prevoznine
        End If

    End Sub

    Public Sub bDaLiJeBarIHSH(ByRef outBarIHSH As Boolean)
        outBarIHSH = False
        'If (mStanica2 = "15715" And (mPrUprava = "41") Or ((mPrStanica = "31080") And (mPrUprava = "62"))) Then
        If mPrUprava = "41" Or mPrUprava = "62" Then
            outBarIHSH = True
        End If
        If mOtpUprava = "41" Or mOtpUprava = "62" Then
            outBarIHSH = True
        End If
    End Sub
    Public Sub bNadjiPrevozninuICF(ByRef Prevoznina As Decimal)          ' ICF
        ' If Pojedinacne Then
        '
        ' naci da li je data cena po kontejneru ili se primenjuje koeficijent na cenu iz tablica
        '      bNadjiVozarinskiStavKontTEA
        ' izracunati raster
        ' izmnoziti cenu sa rasterom 
        ' sumirati po svim UTI-jima na kolima i dodati gde treba naknadu za koriscenje kola ( po kolima ili UTI-ju ? )

        ' ElseIf Vozovi Then

        ' testirati da li su mix ili shuttle ( iz najave )
        ' naci ukupnu masu
        ' naci ukupno vozova
        ' naci cenu po vozu ( ulaz - stanice, uprave, mix/shuttle, ukupna masa, ukupno vozova; 
        '                              izlaz - voz. stav, naknada za koriscenje kola ) 

        ' End If
        ' polja za UTI-je u tabeli NHM :
        '"UTI", String                                 5 tip - duzina
        '"UTIIB",String                               6 Ind. broj kontenera [GRANICA]
        '"UTITara", Int32                            7 tara kontenera [GRANICA]
        '"UTIRaster", Decimal                     8 primenjeni raster
        '"UTINHM", String                           9 roba u konteneru [GRANICA]
        '"UTIBuletin", String                       10 predajni list [GRANICA]
        '"UTIPlombe", String                      11broj plombi [GRANICA]


        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim MasaTemp As Integer
        Dim IBK As String
        Dim Vlasnistvo As String
        Dim TovarenaPrazna As String
        Dim DuzinaKontTemp As String
        Dim RasterTemp As Decimal = 1
        Dim IzStav, StavPoTEA As Decimal
        Dim PovVr As String
        Dim PrevozninaZaUTI, PrevozninaPoKolima As Decimal
        Dim bABCD As Integer                   ' broj ukupno realizovanih vozova
        Dim BrutoMasa As Decimal
        Dim bPkolKoef As Decimal = 1

        Util.sNadjiNaziv("TabNaziv", mBrojUg, "", "", 1, xNaziv, xPovVrednost)
        mTabelaCena = xNaziv

        PrevozninaPoKolima = 0

        If ((mTabelaCena = "220") Or (mTabelaCena = "221")) Then            ' pojedinacne
            IBK = dtKola.Rows(0).Item("IndBrojKola")
            Vlasnistvo = dtKola.Rows(0).Item("Vlasnik")
            bMinPrevoznina = 0

            ' usaglasiti ulazne parametre
            TovarenaPrazna = "TU"
            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
            TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            For Each NHMRed In dtNhm.Rows                                                ' petlja po robi za jedna kola
                If NHMRed.Item("IndBrojKola") = IBK Then
                    MasaTemp = NHMRed.Item("Masa")
                    DuzinaKontTemp = NHMRed.Item("UTI")
                    bNadjiRasterCO(DuzinaKontTemp, MasaTemp, RasterTemp)
                    IzStav = 0
                    ' razvojiti Sopron i ne-Sopron u bazi
                    StavIcfN(mBrojUg, "220", mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "0", "0", IzStav, PovVr)
                    If IzStav = 0 Then
                        StavIcfN(mBrojUg, "221", mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "0", "0", IzStav, PovVr)
                    End If
                    If (mTabelaCena = "220") Then                            ' cena po UTI-ju
                        PrevozninaZaUTI = IzStav * RasterTemp

                    ElseIf (mTabelaCena = "221") Then                     ' koeficijent na cenu po UTI-ju iz tarife (tab 914)
                        bNadjiVozarinskiStavKontTEA("914", mDatumKalk, bTkm, StavPoTEA, PovVr)
                        PrevozninaZaUTI = StavPoTEA * IzStav * RasterTemp
                    End If


                    bZaokruziMasuNa100k(MasaTemp)
                    NHMRed.Item("RacMasaNHM") = MasaTemp
                    NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStav

                    PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaZaUTI
                End If
            Next

            bZaokruziNaCeleNavise(PrevozninaPoKolima)  ' ili na desete?

            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            Prevoznina = PrevozninaPoKolima
            dtKola.Rows(0).Item("Prevoznina") = Prevoznina

        ElseIf ((mTabelaCena = "201") Or (mTabelaCena = "202")) Then       ' vozovi

            If mBrojUg = "993353" Then
                If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then 'shuttle
                    mTabelaCena = "202"
                Else                                                          ' mix  
                    mTabelaCena = "201"
                End If
            ElseIf mBrojUg = "993354" Then
                If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
                    mTabelaCena = "202"
                Else
                    mTabelaCena = "201"
                End If
            End If

            BrutoMasa = 0
            bNadjiBrutoMasu(BrutoMasa, bPkolKoef)
            bNadjiBrojRealizovanihVozova(mBrojUg, mStanica1, mStanica2, bABCD, PovVr)

            StavIcfN(mBrojUg, mTabelaCena, mDatumKalk, BrutoMasa, mStanica1, mStanica2, "00", "", "0", Prevoznina, PovVr)

            '----------- Upis racunske mase i vozarinskog stava po robi za ceo voz----------
            bVozarinskiStav = Prevoznina
            For Each KolaRed In dtKola.Rows    ' petlja po kolima
                IBK = KolaRed.Item("IndBrojKola")
                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        MasaTemp = NHMRed.Item("Masa")
                        bZaokruziMasuNa100k(MasaTemp)
                        NHMRed.Item("RacMasaNHM") = MasaTemp
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStav
                    End If
                Next
            Next
        ElseIf (mTabelaCena = "333") Then       ' Adria combi pojedinacne
            IBK = dtKola.Rows(0).Item("IndBrojKola")
            Vlasnistvo = dtKola.Rows(0).Item("Vlasnik")
            bMinPrevoznina = 0

            ' usaglasiti ulazne parametre
            TovarenaPrazna = "TU"
            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
            TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            For Each NHMRed In dtNhm.Rows                                                ' petlja po robi za jedna kola
                If NHMRed.Item("IndBrojKola") = IBK Then
                    MasaTemp = NHMRed.Item("Masa")
                    DuzinaKontTemp = NHMRed.Item("UTI")
                    bNadjiRasterCO(DuzinaKontTemp, MasaTemp, RasterTemp)
                    IzStav = 0

                    ''' razvojiti Sopron i ne-Sopron u bazi
                    ''StavIcfN(mBrojUg, "220", mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "0", "0", IzStav, PovVr)
                    ''If IzStav = 0 Then
                    ''    StavIcfN(mBrojUg, "221", mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "0", "0", IzStav, PovVr)
                    ''End If
                    ''If (mTabelaCena = "220") Then                            ' cena po UTI-ju
                    ''    PrevozninaZaUTI = IzStav * RasterTemp

                    ''ElseIf (mTabelaCena = "221") Then                     ' koeficijent na cenu po UTI-ju iz tarife (tab 914)
                    ''    bNadjiVozarinskiStavKontTEA("914", mDatumKalk, bTkm, StavPoTEA, PovVr)
                    ''    PrevozninaZaUTI = StavPoTEA * IzStav * RasterTemp
                    ''End If

                    If mBrojUg = "835745" Then 'AdriaCombi
                        IzStav = 135 'cena po UTI
                    ElseIf mBrojUg = "931817" Then 'Eurolog
                        IzStav = 2772 'cena po vozu
                    End If

                    PrevozninaZaUTI = IzStav '* RasterTemp

                    bZaokruziMasuNa100k(MasaTemp)
                    NHMRed.Item("RacMasaNHM") = MasaTemp
                    NHMRed.Item("VozarinskiStavNHM") = IzStav 'bVozarinskiStav

                    If mBrojUg = "835745" Then 'AdriaCombi
                        PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaZaUTI
                    ElseIf mBrojUg = "931817" Then 'Eurolog
                        PrevozninaPoKolima = 2772 'cena po vozu
                    End If

                End If
            Next

            bZaokruziNaCeleNavise(PrevozninaPoKolima)  ' ili na desete?

            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            Prevoznina = PrevozninaPoKolima
            dtKola.Rows(0).Item("Prevoznina") = Prevoznina

        End If
    End Sub

    Public Sub bNadjiPrevozninu01CO(ByRef Prevoznina As Decimal)          ' vozovi

        Dim bIzborABCD As String
        Dim bABCD As Integer ' String
        Dim bCenaPoVozu00, bCenaPoVozuOt, bCenaPoVozuUp As Decimal
        Dim bCena As Decimal
        Dim bBarIHSH As Boolean = False
        Dim bVrsta As Integer ' String
        Dim bPKolKoef As Decimal = 1

        Dim PV As String = ""

        'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
        '       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
        '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

        bDaLiJeBarIHSH(bBarIHSH)


        If Not (bBarIHSH) Then  ' Nije Bar i Albanija

            'bABCD = 2000 'Tumacenje ugovora: uvek vazi cena iz tabele D

            bNadjiBrojRealizovanihVozova(mBrojUg, mStanica1, mStanica2, bABCD, PV)
            'U bazi nisu azurirani brojevi vozova u tabeli COVOZOVI! 29.05.2007.

            If mBrojUg = "100701" Or mBrojUg = "110701" Or mBrojUg = "120701" Then
                bABCD = 1601 'Tumacenje ugovora: uvek vazi cena iz tabele D
            End If

            '------------------ Nalazi sifru tabele iz SifTabCen ---------------------
            Dim xNaziv As String = ""
            Dim xPovVrednost As String = ""
            Dim rv1 As String

            Util.sNadjiNaziv("NazivTabele", mBrojUg, "", "", 1, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                mTabelaCena = " "
            Else
                mTabelaCena = xNaziv
            End If

            If ((mStanica1 = "16201") Or (mStanica2 = "16201")) Then
                bNadjiBrutoMasu(mBrutoMasaPoPosiljci, bPKolKoef)
                bABCD = mBrutoMasaPoPosiljci / 1000 ' u tonama
                mTabelaCena = "212"
            Else
                bNadjiBrutoMasu(mBrutoMasaPoPosiljci, bPKolKoef)
            End If

            If mBrojUg = "100701" Or mBrojUg = "110701" Or mBrojUg = "120701" Then
                If mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X" Then
                    'nema korekcije cene
                Else
                    CoVozoviProcenatZaBM(mBrojUg, mStanica1, mStanica2, (mBrutoMasaPoPosiljci / 1000), mProcenatBM, rv1)
                End If
            End If

            bVozarinskiStav = mPrevoznina

            '-------------------------------------------------------------------------
            bCenaPoVozu00 = 0
            bCenaPoVozuOt = 0
            bCenaPoVozuUp = 0

            '------------ ispitati procenat neto tona za Makedoniju - Samo Prodos!

            Dim TempPrUprava As String

            If (mBrojUg = "100701" Or mBrojUg = "110701" Or mBrojUg = "120701") _
                And Not (mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X") Then
                Dim PovrVr As String
                TempPrUprava = mPrUprava
                bNadjiUpravu6573(mBrojUg, mNajava, mObrMesec, mObrGodina, mPrUprava, PovrVr)

            End If

            '------------ ispitati procenat neto tona za Makedoniju - Samo Prodos!

            bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, "00", "0", "0", bCenaPoVozu00, PV)
            bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, mOtpUprava, "0", "0", bCenaPoVozuOt, PV)
            bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, mPrUprava, "0", "0", bCenaPoVozuUp, PV)

            If (mBrojUg = "100701" Or mBrojUg = "110701" Or mBrojUg = "120701") _
                    And Not (mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X") Then
                mPrUprava = TempPrUprava
            End If

            If Not (bCenaPoVozu00 = 0) Then
                mPrevoznina = bCenaPoVozu00
            ElseIf Not (bCenaPoVozuOt = 0) Then
                mPrevoznina = bCenaPoVozuOt
            ElseIf Not (bCenaPoVozuUp = 0) Then
                mPrevoznina = bCenaPoVozuUp
            End If

            '***
            '5100
            'StariObracunskiMesec=4
            'NoviObracunskiMesec=5
            '

            If mBrojUg = "100701" Or mBrojUg = "110701" Or mBrojUg = "120701" Then
                If mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X" Then
                    'nema korekcije cene
                Else
                    mPrevoznina = mPrevoznina * (1 + mProcenatBM / 100)
                    '''bZaokruziNaCeleNavise(mPrevoznina)
                End If
            End If

            If Microsoft.VisualBasic.Left(mBrojUg.ToString, 2) = "10" Or _
               Microsoft.VisualBasic.Left(mBrojUg.ToString, 2) = "11" Or _
               Microsoft.VisualBasic.Left(mBrojUg.ToString, 2) = "12" Then

            Else
                mPrevoznina = mPrevoznina * bPKolKoef
            End If

            bZaokruziNaCeleNavise(mPrevoznina)

            bVozarinskiStav = mPrevoznina

        Else  ' Bar i Albanija

            ' If "Z" kola Then bVrsta = "1"
            ' If tovarena "P" kola Then bVrsta= "2"
            ' If prazna "P" kola Then bVrsta= "3"


            '------------------ Nalazi sifru tabele iz SifTabCen ---------------------
            Dim xNaziv As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiNaziv("NazivTabele", mBrojUg, "", "", 1, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                mTabelaCena = " "
            Else
                mTabelaCena = xNaziv
            End If
            '-------------------------------------------------------------------------
            bVrsta = 1

            'mTabelaCena = "211"

            bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bVrsta, mStanica1, mStanica2, "00", "0", "0", bCena, PV)
            mPrevoznina = bCena
            bVozarinskiStav = bCena

            'If bVrsta = "3" Then
            '    mPrevoznina = bCena * UkupnoKola
            'End If    ili ubaciti u petlju, pa testirati za svaka kola?

        End If

        ' ---------------------------------- Upis racunske mase i vozarinskog stava po robi --------------------------------
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK As String
        Dim MasaTemp As Integer

        For Each KolaRed In dtKola.Rows    ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            Dim BrOsovina As Integer = KolaRed.Item("Osovine")

            'For Each NHMRed In dtNhm.Rows
            '    If NHMRed.Item("IndBrojKola") = IBK Then
            '        MasaTemp = NHMRed.Item("Masa")
            '        bZaokruziMasuNa100k(MasaTemp)
            '        NHMRed.Item("RacMasaNHM") = MasaTemp
            '        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStav
            '    End If
            'Next
            '###
            For Each NHMRed In dtNhm.Rows   '  petlja po robi
                If NHMRed.Item("IndBrojKola") = IBK Then
                    '0304
                    Dim bNaftaJe As Boolean = False
                    Dim bDodatakZaNaftu As Decimal
                    Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                    bDaLiJeNafta(NHMRed.Item("NHM"), bNaftaJe)
                    If bNaftaJe Then
                        'bUkupnoKolaSaNaftom = bUkupnoKolaSaNaftom + 1
                        bNadjiNaftu(NHMRed.Item("NHM"), bTkm, bDodatakZaNaftu)
                        Prevoznina = Prevoznina + bDodatakZaNaftu
                    End If
                    '0304
                    Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                    bZaokruziMasuNa100k(MasaTemp1)
                    '0304
                    If bRacunskaMasaNHM <= MasaTemp1 Then
                        bRacunskaMasaNHM = MasaTemp1
                    End If
                    If bRacunskaMasaNHM <= BrOsovina * 5000 Then
                        bRacunskaMasaNHM = BrOsovina * 5000
                    End If
                    '0304
                    NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                    '0304
                    NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                End If
            Next
            '###


        Next

    End Sub                                                 ' 01CO
    Public Sub bNadjiPrevozninu02CO(ByRef Prevoznina As Decimal)  ' grupa kola

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        'Dim RedniBroj As Int32
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1

        '        Dim Masa1R, Masa2R, Masa3R As Integer
        Dim Masa As Integer
        Dim MasaTemp As Integer
        Dim Razred As String
        Dim TonskiStav As String
        '       Dim Prev1R, Prev2R, Prev3R As Decimal
        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim TonskiStavInteger As Integer

        Dim PrevozninaPoKolima As Decimal = 0
        Dim RacMasaPoKolima As Integer

        Dim Tabela As String

        Dim bVrsta00tranzita As Byte = 1


        Prevoznina = 0
        bRedovanOrocen = "R"

        If dtKola.Rows.Count > 0 Then
            'RedniBroj = 0

            '------------------ Nalazi sifru tabele iz SifTabCen ---------------------
            Dim xNaziv As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiNaziv("NazivTabele", mBrojUg, "", "", 1, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                mTabelaCena = " "
            Else
                mTabelaCena = xNaziv
            End If
            '-------------------------------------------------------------------------

            For Each KolaRed In dtKola.Rows    ' petlja po kolima 
                ' ucitavanje polja

                'dodeliti vrednosti za promenljive

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

                If TipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


                If Vrsta = "O" Then
                    Vrsta = 1
                End If
                If Vrsta = "S" Then
                    Vrsta = 2
                End If
                bNadjiKolPrevKoef(mBrojUg, "0", Vrsta, Vlasnistvo, TovarenaPrazna, "00", "00", bPrevozninaKoef, PV)

                If dtNhm.Rows.Count > 0 Then

                    RacMasaPoKolima = 0

                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            Razred = NHMRed.Item("R")

                            RacMasaPoKolima = RacMasaPoKolima + MasaTemp

                        End If
                    Next
                    bZaokruziMasuNa100k(RacMasaPoKolima)
                    bRacunskaMasaPoKolima = RacMasaPoKolima

                    Dim _razred As String

                    PrevozninaPoKolima = 0

                    If Vlasnistvo = "Z" Then
                        _razred = "1"
                    Else
                        _razred = "2"
                    End If

                    '---------------- ispituje upravu -----------------------
                    Dim ProdosUprava As String = "00"
                    'If mStanica1 = "11028" Then
                    '    ProdosUprava = Microsoft.VisualBasic.Mid(mOtpStanica, 1, 2)
                    'End If

                    If Microsoft.VisualBasic.Left(mBrojUg, 2) = "10" Or _
                       Microsoft.VisualBasic.Left(mBrojUg, 2) = "11" Or _
                       Microsoft.VisualBasic.Left(mBrojUg, 2) = "12" Then

                        If mStanica2 = "11028" Then
                            If mStanica1 <> "12498" Then
                                ProdosUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)
                            End If
                        End If

                    End If

                    '------------------------------------------------------

                    bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, ProdosUprava, "0", _razred, VozarinskiStav, PV)
                    bVozarinskiStavPoKolima = VozarinskiStav

                    If VozarinskiStav = 0 Then
                        '------------------ Nalazi sifru tabele iz SifTabCen ---------------------
                        Dim x1Naziv As String = ""
                        Dim x1PovVrednost As String = ""
                        Dim xString As String
                        Dim xString1 As String
                        Dim xString2 As String = "00"

                        xString1 = Microsoft.VisualBasic.Mid(mBrojUg, 1, 4)
                        xString = xString1 & xString2

                        Util.sNadjiNaziv("NazivTabele", xString, "", "", 1, x1Naziv, x1PovVrednost)

                        If x1PovVrednost <> "" Then
                            mTabelaCena = " "
                        Else
                            mTabelaCena = x1Naziv
                        End If
                        '-------------------------------------------------------------------------
                        If mStanica1 = "12498" Or mStanica1 = "11028" Or mStanica1 = "15723" Then
                            ProdosUprava = Microsoft.VisualBasic.Mid(mOtpStanica, 1, 2)
                        End If

                        If mStanica2 = "12498" Or mStanica2 = "11028" Or mStanica2 = "15723" Then
                            ProdosUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)
                        End If

                        '---
                        If mTabelaCena = "173" Then 'prodos

                            Dim Masa1, Masa2 As Integer
                            Dim VozarinskiStav1, VozarinskiStav2, PrevozninaPoKolima1, PrevozninaPoKolima2 As Decimal

                            Masa1 = 0
                            Masa2 = 0
                            VozarinskiStav1 = 0
                            VozarinskiStav2 = 0
                            PrevozninaPoKolima1 = 0
                            PrevozninaPoKolima2 = 0
                            Select Case RacMasaPoKolima
                                Case 10000, 15000, 20000, 25000

                                    bNadjiVozarinskiStavCO(xString, mTabelaCena, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, ProdosUprava, "0", _razred, VozarinskiStav, PV)

                                    VozarinskiStav = bStavKoef * VozarinskiStav
                                    bZaokruziNaDeseteNavise(VozarinskiStav)
                                    PrevozninaPoKolima = RacMasaPoKolima * VozarinskiStav * KolKoef / 1000
                                    PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef
                                    bRacunskaMasaPoKolima = RacMasaPoKolima
                                    bVozarinskiStavPoKolima = VozarinskiStav


                                Case Else
                                    If (RacMasaPoKolima > 10000 And RacMasaPoKolima < 15000) Then
                                        bNadjiVozarinskiStavCO(xString, mTabelaCena, mDatumKalk, 10000, mStanica1, mStanica2, ProdosUprava, "0", _razred, VozarinskiStav1, PV)
                                        Masa2 = 15000
                                    End If

                                    If (RacMasaPoKolima > 15000 And RacMasaPoKolima < 20000) Then
                                        bNadjiVozarinskiStavCO(xString, mTabelaCena, mDatumKalk, 15000, mStanica1, mStanica2, ProdosUprava, "0", _razred, VozarinskiStav1, PV)
                                        Masa2 = 20000
                                    End If

                                    If (RacMasaPoKolima > 20000 And RacMasaPoKolima < 25000) Then
                                        bNadjiVozarinskiStavCO(xString, mTabelaCena, mDatumKalk, 20000, mStanica1, mStanica2, ProdosUprava, "0", _razred, VozarinskiStav1, PV)
                                        Masa2 = 25000
                                    End If

                                    If (RacMasaPoKolima > 25000) Then
                                        bNadjiVozarinskiStavCO(xString, mTabelaCena, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, ProdosUprava, "0", _razred, VozarinskiStav1, PV)
                                        Masa2 = RacMasaPoKolima
                                    End If

                                    Masa1 = RacMasaPoKolima

                                    VozarinskiStav1 = bStavKoef * VozarinskiStav1
                                    bZaokruziNaDeseteNavise(VozarinskiStav1)
                                    PrevozninaPoKolima1 = Masa1 * VozarinskiStav1 * KolKoef / 1000
                                    PrevozninaPoKolima1 = PrevozninaPoKolima1 * bPrevozninaKoef
                                    bRacunskaMasaPoKolima = Masa1
                                    bVozarinskiStavPoKolima = VozarinskiStav1

                                    bNadjiVozarinskiStavCO(xString, mTabelaCena, mDatumKalk, Masa2, mStanica1, mStanica2, ProdosUprava, "0", _razred, VozarinskiStav2, PV)
                                    VozarinskiStav2 = bStavKoef * VozarinskiStav2
                                    bZaokruziNaDeseteNavise(VozarinskiStav2)
                                    PrevozninaPoKolima2 = Masa2 * VozarinskiStav2 * KolKoef / 1000
                                    PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef

                                    PrevozninaPoKolima = PrevozninaPoKolima1
                                    If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                        PrevozninaPoKolima = PrevozninaPoKolima2
                                        bRacunskaMasaPoKolima = Masa2
                                        bVozarinskiStavPoKolima = VozarinskiStav2

                                    End If
                                    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                            End Select
                        End If    ' end  prodos kada nema relacije za grupu kola
                    Else
                        PrevozninaPoKolima = RacMasaPoKolima * bStavKoef * VozarinskiStav * KolKoef / 1000
                        ' zaokruzivanje?
                        PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef

                        'zaokruzivanje na 0.10 e
                        'bzaokruzina desetenavise(prevozninapokolima)

                        ' Testiraj na minimalnu prevozninu - nema ( Prema na pr. 140600 )
                        'If PrevozninaPoKolima <= bMinPrevoznina Then
                        '    PrevozninaPoKolima = bMinPrevoznina
                        'End If

                        '                        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                    End If
                End If

                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                Prevoznina = Prevoznina + PrevozninaPoKolima
                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima
                '###
                'For Each NHMRed In dtNhm.Rows   '  petlja po robi
                '    If NHMRed.Item("IndBrojKola") = IBK Then
                '        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                '        bZaokruziMasuNa100k(MasaTemp1)
                '        NHMRed.Item("RacMasaNHM") = MasaTemp1
                '        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                '    End If
                'Next
                '###
                '###
                For Each NHMRed In dtNhm.Rows   '  petlja po robi
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        '0304
                        Dim bNaftaJe As Boolean = False
                        Dim bDodatakZaNaftu As Decimal
                        Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                        bDaLiJeNafta(NHMRed.Item("NHM"), bNaftaJe)
                        If bNaftaJe Then
                            'bUkupnoKolaSaNaftom = bUkupnoKolaSaNaftom + 1
                            bNadjiNaftu(NHMRed.Item("NHM"), bTkm, bDodatakZaNaftu)
                            Prevoznina = Prevoznina + bDodatakZaNaftu
                        End If
                        '0304
                        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        bZaokruziMasuNa100k(MasaTemp1)
                        '0304
                        If bRacunskaMasaNHM <= MasaTemp1 Then
                            bRacunskaMasaNHM = MasaTemp1
                        End If
                        If bRacunskaMasaNHM <= BrOsovina * 5000 Then
                            bRacunskaMasaNHM = BrOsovina * 5000
                        End If
                        '0304
                        NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                        '0304
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    End If
                Next
                '###


            Next
            bZaokruziNaDeseteNavise(Prevoznina)
        End If

    End Sub                                        ' 02CO
    Public Sub bNadjiPrevozninu11CO(ByRef Prevoznina As Decimal)

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        'Dim RedniBroj As Int32
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1

        Dim Masa1R, Masa2R, Masa3R As Integer
        Dim MasaTemp As Integer
        Dim Razred As String
        Dim TonskiStav As String
        'Dim Prev1R, Prev2R, Prev3R As Decimal

        Dim VozarinskiStav1 As Decimal
        Dim VozarinskiStav2 As Decimal
        Dim VozarinskiStav As Decimal

        Dim PV As String
        Dim TonskiStavInteger As Integer

        Dim PrevozninaPoKolima1 As Decimal = 0
        Dim PrevozninaPoKolima2 As Decimal = 0
        Dim PrevozninaPoKolima As Decimal = 0

        Dim RacMasaPoKolima As Integer

        Dim Tabela As String
        Dim bStvMasa As Decimal
        Dim Masa1 As Decimal
        Dim Masa2 As Decimal

        Prevoznina = 0
        bRedovanOrocen = "R"
        TovarenaPrazna = "PK"
        Vlasnistvo = "P"

        ' 1. - naci da li postoji u tabeli 3.1 (310) stav za odgovarajucu relaciju
        ' 2. - ako postoji pomnoziti stav po kolima sa ukupnim brojem kola u posiljci
        ' 3. - ako ne postoji, naci prevozninu za poj. posiljku i odg. saobracaj (uvoz,izvoz,tranzit) i pomnozi sa 0.3

        mTabelaCena = "310"
        bNadjiVozarinskiStavCO("000011", "310", mDatumKalk, 1, mStanica1, mStanica2, "00", "0", "0", VozarinskiStav, PV)
        bVozarinskiStavPoKolima = VozarinskiStav ' proveriti da li je po kolima

        'If (PV = "") Then  '  relacija postoji , pa je prema 1.
        '    PrevozninaPoKolima = VozarinskiStav
        'End If

        If dtKola.Rows.Count > 0 Then
            'RedniBroj = 0
            For Each KolaRed In dtKola.Rows    ' petlja po kolima 
                ' ucitavanje polja

                'dodeliti vrednosti za promenljive

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

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "00", "K", bVrstaStanice, "P", _
                       "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                If VozarinskiStav <> 0 Then  '  relacija postoji , pa je prema 1.
                    PrevozninaPoKolima = VozarinskiStav
                    bVozarinskiStav = PrevozninaPoKolima

                    'Prodos,Senker,Ekspres
                    If Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "10" Or _
                       Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "12" Then

                        PrevozninaPoKolima = 0
                        bVozarinskiStavPoKolima = 0

                    End If

                    If Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "11" Then

                        If Not (((mStanica1 = "16517" And mStanica2 = "15723") Or _
                         (mStanica1 = "23499" And mStanica2 = "15723") Or _
                         (mStanica1 = "22899" And mStanica2 = "15723") Or _
                         (mStanica1 = "21099" And mStanica2 = "15723") Or _
                         (mStanica1 = "12498" And mStanica2 = "15723") Or _
                         (mStanica1 = "11028" And mStanica2 = "15723") Or _
                         (mStanica1 = "16319" And mStanica2 = "15723") Or _
                         (mStanica2 = "16517" And mStanica1 = "15723") Or _
                         (mStanica2 = "23499" And mStanica1 = "15723") Or _
                         (mStanica2 = "22899" And mStanica1 = "15723") Or _
                         (mStanica2 = "21099" And mStanica1 = "15723") Or _
                         (mStanica2 = "12498" And mStanica1 = "15723") Or _
                         (mStanica2 = "11028" And mStanica1 = "15723") Or _
                         (mStanica2 = "16319" And mStanica1 = "15723")) And _
                            mDatumKalk >= "2/9/2007") Then

                            PrevozninaPoKolima = 0
                            bVozarinskiStavPoKolima = 0

                        End If
                    End If


                Else                    '   relacija ne postoji, pa je prema 2.   ( TRANZIT ILI UVOZ-IZVOZ ):

                    If bVrstaSaobracaja = 4 Then

                        Dim bVrsta00tranzita As Byte = 1

                        ' prazna "P" kola - sopstvena masa i prevozni stav 1. razreda tablice za tranzit ( ! )
                        NadjiVrstu00CO(mStanica1, mStanica2, mOtpUprava, mPrUprava, bVrsta00tranzita)

                        ' Vrsta00Tranzita: 1-suvozemni, 2-recni, 3-morski ( preko luke Bar ), ...
                        If bVrsta00tranzita = 1 Then                    ' suvozemni
                            Tabela = "181"
                        ElseIf bVrsta00tranzita = 2 Then              ' recni
                            Tabela = "172"
                            'ElseIf bVrsta00tranzita = 3 Then         ' morski itd.
                            '    Tabela = "???"

                        End If

                        If dtNhm.Rows.Count > 0 Then
                            Masa1R = 0
                            Masa2R = 0
                            Masa3R = 0

                            For Each NHMRed In dtNhm.Rows   '  petlja po robi
                                If NHMRed.Item("IndBrojKola") = IBK Then
                                    MasaTemp = NHMRed.Item("Masa")
                                    ' Razred = NHMRed.Item("R")
                                    '    '?                            bZaokruziMasuNa100k(MasaTemp)
                                    '    Select Case Razred                                        ' grupisanje po razredima   I S K L J U C I T I, NEMA POTREBE
                                    '        Case "1"                                                   '  pojavice se samo jedna masa ( masa praznih kola )
                                    '            Masa1R = Masa1R + MasaTemp
                                    '        Case "2"
                                    '            Masa2R = Masa2R + MasaTemp
                                    '        Case "3"
                                    '            Masa3R = Masa3R + MasaTemp
                                    '    End Select
                                End If
                            Next

                            bStvMasa = MasaTemp

                            bZaokruziMasuNa100k(bStvMasa)

                            PrevozninaPoKolima1 = 0
                            PrevozninaPoKolima2 = 0
                            PrevozninaPoKolima = 0

                            ' kao u najopstijem slucaju, dakle:
                            ' - ukoliko je ukupna masa izmedju nazivnih masa za stavove ( 10t, 15t, 20t i 25t ) racunati prevoznine za:
                            '   1- nizi tonski tonski stav i ukupnu  masu i 2- visi tonski stav i visu nazivnu masu;
                            '   usvojiti racunsku masu i vozarinski stav koji daju nizu prevozninu
                            ' -  korigovati vozarinski stav ( *bStavKoef, "popust na vozarinski stav" ) i (?)zaokruziti 

                            Select Case bStvMasa
                                Case 10000, 15000, 20000, 25000
                                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav, PV)
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav, PV)
                                    VozarinskiStav = bStavKoef * VozarinskiStav
                                    bZaokruziNaDeseteNavise(VozarinskiStav)
                                    PrevozninaPoKolima = bStvMasa * VozarinskiStav * KolKoef / 1000
                                    PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef
                                    bRacunskaMasaPoKolima = bStvMasa
                                    bVozarinskiStavPoKolima = VozarinskiStav

                                Case Else

                                    If (bStvMasa > 10000 And bStvMasa < 15000) Then
                                        'bNadjiVozarinskiStav(Tabela, mDatumKalk, 10000, bTkm, Razred, VozarinskiStav1, PV)
                                        bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav1, PV)
                                        Masa2 = 15000
                                    End If

                                    If (bStvMasa > 15000 And bStvMasa < 20000) Then
                                        'bNadjiVozarinskiStav(Tabela, mDatumKalk, 15000, bTkm, Razred, VozarinskiStav1, PV)
                                        bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav1, PV)
                                        Masa2 = 20000
                                    End If

                                    If (bStvMasa > 20000 And bStvMasa < 25000) Then
                                        'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                        bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav1, PV)
                                        Masa2 = 25000
                                    End If
                                    '*******
                                    If (bStvMasa > 25000) Then
                                        'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                        bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav1, PV)
                                        Masa2 = MasaTemp
                                    End If
                                    '*******

                                    Masa1 = bStvMasa

                                    VozarinskiStav1 = bStavKoef * VozarinskiStav1
                                    bZaokruziNaDeseteNavise(VozarinskiStav1)
                                    PrevozninaPoKolima1 = Masa1 * VozarinskiStav1 * KolKoef / 1000
                                    PrevozninaPoKolima1 = PrevozninaPoKolima1 * bPrevozninaKoef * 0.3
                                    bZaokruziNaDeseteNavise(PrevozninaPoKolima1)
                                    bRacunskaMasaPoKolima = Masa1
                                    bVozarinskiStavPoKolima = VozarinskiStav1

                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav2, PV)
                                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, Masa2, bTkm, Razred, VozarinskiStav2, PV)
                                    VozarinskiStav2 = bStavKoef * VozarinskiStav2
                                    bZaokruziNaDeseteNavise(VozarinskiStav2)
                                    PrevozninaPoKolima2 = Masa2 * VozarinskiStav1 * KolKoef / 1000
                                    PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef * 0.3
                                    bZaokruziNaDeseteNavise(PrevozninaPoKolima2)

                                    PrevozninaPoKolima = PrevozninaPoKolima1
                                    If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                        PrevozninaPoKolima = PrevozninaPoKolima2
                                        bRacunskaMasaPoKolima = Masa2
                                        bVozarinskiStavPoKolima = VozarinskiStav2

                                    End If

                            End Select


                            ' zaokruzivanje?
                            ' zaokruzivanje na 0.10 e
                            ' bzaokruzina desetenavise(prevozninapokolima)
                        End If

                    ElseIf ((bVrstaSaobracaja = 2) Or (bVrstaSaobracaja = 3)) Then ' UVOZ, IZVOZ

                        Dim DoTona As String = "45"          ' da ne bi bilo brljoka
                        Tabela = "122"                        ' da ne bi bilo brljoka ( bez Bara i HSH )

                        If Tabela = "122" Then
                            DoTona = "25"
                        End If

                        If Tabela = "161" Then
                            DoTona = "45"
                        End If

                        If dtNhm.Rows.Count > 0 Then
                            Masa1R = 0
                            Masa2R = 0
                            Masa3R = 0
                            Dim Prev1R As Decimal = 0
                            Dim Prev2R As Decimal = 0
                            Dim Prev3R As Decimal = 0

                            For Each NHMRed In dtNhm.Rows   '  petlja po robi
                                If NHMRed.Item("IndBrojKola") = IBK Then
                                    MasaTemp = NHMRed.Item("Masa")
                                    Razred = NHMRed.Item("R")
                                    'Select Case Razred                                        ' grupisanje po razredima  ????????
                                    '    Case "1"
                                    '        Masa1R = Masa1R + MasaTemp
                                    '    Case "2"
                                    '        Masa2R = Masa2R + MasaTemp
                                    '    Case "3"
                                    '        Masa3R = Masa3R + MasaTemp
                                    'End Select
                                    Masa1R = MasaTemp
                                    Masa2R = 0
                                    Masa3R = 0
                                End If
                                bZaokruziMasuNa100k(Masa1R)
                                'bZaokruziMasuNa100k(Masa2R)
                                'bZaokruziMasuNa100k(Masa3R)
                            Next

                            PrevozninaPoKolima = 0

                            bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, DoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                            TonskiStavInteger = CType(TonskiStav, Integer)
                            MasaTemp = TonskiStavInteger * 1000

                            ' prevoznine po razredima:

                            '                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "1", VozarinskiStav, PV)
                            bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "1", VozarinskiStav, PV)
                            Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            ' zaokruzivanje?
                            Prev1R = Prev1R * bPrevozninaKoef * 0.3
                            'bRacunskaMasaPoKolima = MasaTemp
                            bVozarinskiStavPoKolima = VozarinskiStav

                            ''                   bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "2", VozarinskiStav, PV)
                            'bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "1", VozarinskiStav, PV)
                            'Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '' zaokruzivanje?
                            'Prev2R = Prev2R * bPrevozninaKoef

                            ''                  bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "3", VozarinskiStav, PV)
                            'bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "1", VozarinskiStav, PV)
                            'Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            '' zaokruzivanje?
                            'Prev3R = Prev3R * bPrevozninaKoef

                            PrevozninaPoKolima = Prev1R    '+ Prev2R + Prev3R                 ' po kolima !!!!!

                            'zaokruzivanje na 0.10 ...
                            bZaokruziNaDeseteNavise(PrevozninaPoKolima)

                            ' Testiraj na minimalnu prevozninu
                            RacMasaPoKolima = Masa1R '  + Masa2R + Masa3R

                        End If
                    End If


                    ' *****COANEKS
                    bRacunskaMasaPoKolima = RacMasaPoKolima
                    Dim ugUslovZaStav As Integer
                    Dim ugCena As Decimal
                    Dim ugTipCene As Integer
                    Dim ugRetVal As String = ""
                    Dim ugDodatak As Decimal
                    Dim ugKoeficijent As Decimal
                    Dim NHMTemp As String
                    Dim Stitna As String
                    Dim StvarnaMasaPoKolima As Decimal = 0

                    Stitna = KolaRed.Item("Stitna")

                    For Each NHMRed In dtNhm.Rows
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            StvarnaMasaPoKolima = StvarnaMasaPoKolima + NHMRed.Item("Masa")
                        End If
                    Next

                    NHMTemp = dtNhm.Rows(0).Item("NHM")

                    NadjiAneks(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                                BrOsovina, "P", Vlasnistvo, Stitna, mDatumKalk, Microsoft.VisualBasic.Left(NHMTemp, 4), ugUslovZaStav, _
                                ugCena, ugTipCene, ugRetVal)

                    If ugTipCene = 1 Then
                        ugKoeficijent = ugCena
                    End If

                    If (ugRetVal = "") Then
                        bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, bRacunskaMasaPoKolima, ugCena, _
                        StvarnaMasaPoKolima, bTkm, ugDodatak, PrevozninaPoKolima)
                        If Not (ugTipCene = 1) Then
                            bVozarinskiStavPoKolima = ugCena
                        End If

                    End If

                    ' *****COANEKS




                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                    End If

                    'Prodos,Senker,Ekspres
                    If Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "10" Or _
                       Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "12" Then

                        PrevozninaPoKolima = 0
                        bVozarinskiStavPoKolima = 0

                    End If

                    If Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "11" Then

                        If Not (((mStanica1 = "16517" And mStanica2 = "15723") Or _
                         (mStanica1 = "23499" And mStanica2 = "15723") Or _
                         (mStanica1 = "22899" And mStanica2 = "15723") Or _
                         (mStanica1 = "21099" And mStanica2 = "15723") Or _
                         (mStanica1 = "12498" And mStanica2 = "15723") Or _
                         (mStanica1 = "11028" And mStanica2 = "15723") Or _
                         (mStanica1 = "16319" And mStanica2 = "15723") Or _
                         (mStanica2 = "16517" And mStanica1 = "15723") Or _
                         (mStanica2 = "23499" And mStanica1 = "15723") Or _
                         (mStanica2 = "22899" And mStanica1 = "15723") Or _
                         (mStanica2 = "21099" And mStanica1 = "15723") Or _
                         (mStanica2 = "12498" And mStanica1 = "15723") Or _
                         (mStanica2 = "11028" And mStanica1 = "15723") Or _
                         (mStanica2 = "16319" And mStanica1 = "15723")) And _
                            mDatumKalk >= "2/9/2007") Then

                            PrevozninaPoKolima = 0
                            bVozarinskiStavPoKolima = 0

                        End If
                    End If

                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima

                End If

                KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                Prevoznina = Prevoznina + PrevozninaPoKolima
                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                '###
                For Each NHMRed In dtNhm.Rows   '  petlja po robi
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        bZaokruziMasuNa100k(MasaTemp1)
                        NHMRed.Item("RacMasaNHM") = MasaTemp1
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    End If
                Next
                '###

            Next    ' petlja po kolima

        End If

    End Sub                                     ' 11CO   
    Public Sub bNadjiPrevozninu12CO(ByRef Prevoznina As Decimal)
        Dim KolaRed, U As DataRow

        Dim NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        Dim Tara As Decimal
        Dim PrevozninaPoKolima As Decimal = 0
        Dim BrOsovina As Integer

        Prevoznina = 0

        If dtKola.Rows.Count > 0 Then

            'For Each KolaRed In dtKola.Rows    ' ne treba petlja po kolima 

            IBK = dtKola.Rows(0).Item("IndBrojKola")
            Vrsta = dtKola.Rows(0).Item("Vrsta")     ' 1 - obicna,  2 - specijalna
            TipKola = dtKola.Rows(0).Item("Tip")
            Vlasnistvo = dtKola.Rows(0).Item("Vlasnik")
            Tara = dtKola.Rows(0).Item("Tara")

            If Not (Tara = 0) Then
                bRacunskaMasaPoKolima = Tara
                bZaokruziMasuNa100k(bRacunskaMasaPoKolima)
            End If


            Dim MasaTemp As Integer = 0
            Dim StvarMasa As Integer = 0

            ' videti sta da se radi sa masama kada su kola ptazna, tara nije upisana, 
            ' a masa je upisana kao stvarna masa na kolima, tj da li je sve ovo dole korektno;
            ' ovde se za rac. masu uzima tara ( jer su kola prazna ), a kada tara nije upisana uzima 
            ' se prakticno prva ( i trebalo bi da bude jedina ) masa u NHM tabeli


            'For Each NHMRed In dtNhm.Rows                        ' petlja po robi ne treba
            'If NHMRed.Item("IndBrojKola") = IBK Then
            MasaTemp = dtNhm.Rows(0).Item("Masa")
            bZaokruziMasuNa100k(MasaTemp)
            If Tara = 0 Then
                bRacunskaMasaPoKolima = MasaTemp
            End If
            dtNhm.Rows(0).Item("RacMasaNHM") = MasaTemp
            dtNhm.Rows(0).Item("VozarinskiStavNHM") = 0.022
            'End If
            'Next                                                                  ' petlja po robi           

            If Vrsta = "O" Then
                Vrsta = 1
            End If

            If Vrsta = "S" Then
                Vrsta = 2
            End If

            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "00", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                   "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
            PrevozninaPoKolima = 0.022 * bTkm * bRacunskaMasaPoKolima / 1000
            bZaokruziNaDeseteNavise(PrevozninaPoKolima)

            ' *****COANEKS

            Dim ugUslovZaStav As Integer
            Dim ugCena As Decimal
            Dim ugTipCene As Integer
            Dim ugRetVal As String = ""
            Dim ugDodatak As Decimal
            Dim ugKoeficijent As Decimal
            Dim NHMTemp As String
            Dim Stitna As String
            Dim StvarnaMasaPoKolima As Decimal = 0

            Stitna = KolaRed.Item("Stitna")

            For Each NHMRed In dtNhm.Rows
                If NHMRed.Item("IndBrojKola") = IBK Then
                    StvarnaMasaPoKolima = StvarnaMasaPoKolima + NHMRed.Item("Masa")
                End If
            Next

            NHMTemp = dtNhm.Rows(0).Item("NHM")

            NadjiAneks(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                        BrOsovina, "P", Vlasnistvo, Stitna, mDatumKalk, Microsoft.VisualBasic.Left(NHMTemp, 4), ugUslovZaStav, _
                        ugCena, ugTipCene, ugRetVal)

            If ugTipCene = 1 Then
                ugKoeficijent = ugCena
            End If

            If (ugRetVal = "") Then
                bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, bRacunskaMasaPoKolima, ugCena, _
                StvarnaMasaPoKolima, bTkm, ugDodatak, PrevozninaPoKolima)
                If Not (ugTipCene = 1) Then
                    bVozarinskiStavPoKolima = ugCena
                End If

            End If

            ' *****COANEKS




            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If
            'Next                                                 ' ni ne treba petlja jer postoje samo jedna kola
            Prevoznina = PrevozninaPoKolima       ' ni ne treba petlja jer postoje samo jedna kola

        End If


    End Sub
    Public Sub bNadjiPrevozninuSpecHCD(ByVal inBrojUgovora As String, ByRef outPrevoznina As Decimal)


        Dim KolaRed As DataRow
        Dim NHMRed As DataRow

        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        Dim Tara As Decimal
        Dim PrevozninaPoKolima As Decimal = 0
        Dim MasaTemp As Decimal
        Dim Stav As Decimal

        outPrevoznina = 0

        If inBrojUgovora = "480701" Then
            ' naci prevozninu za tekuca kola
            ' dodati na ukupnu prevozninu

            Vlasnistvo = dtKola.Rows(0).Item("Vlasnik")
            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "00", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                           "TK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                 bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            If dtKola.Rows(0).Item("Vlasnik") = "Z" Then
                Stav = 9.95
            Else
                Stav = 9.95     '  ?
            End If

            bRacunskaMasaPoKolima = 0
            For Each NHMRed In dtNhm.Rows                        ' petlja po robi
                MasaTemp = NHMRed.Item("Masa")
                bZaokruziMasuNa100k(MasaTemp)
                NHMRed.Item("RacMasaNHM") = MasaTemp
                bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + MasaTemp
                NHMRed.Item("VozarinskiStavNHM") = Stav
            Next                                                                  ' petlja po robi           
            PrevozninaPoKolima = Stav * bRacunskaMasaPoKolima / 1000
            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

        End If

        dtKola.Rows(0).Item("RacunskaMasa") = bRacunskaMasaPoKolima
        dtKola.Rows(0).Item("VozarinskiStav") = Stav
        dtKola.Rows(0).Item("Prevoznina") = PrevozninaPoKolima

        outPrevoznina = PrevozninaPoKolima

    End Sub


    Public Sub bNadjiPrevozninu69CO(ByRef Prevoznina As Decimal)  ' ne koristi se

        'Dim KolaRed As DataRow
        'Dim NHMRed As DataRow
        ''Dim RedniBroj As Int32
        'Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        'Dim BrOsovina As Byte
        'Dim KolKoef As Decimal = 1

        'Dim Masa1R, Masa2R, Masa3R As Integer
        'Dim MasaTemp As Integer
        'Dim Razred As String
        'Dim TonskiStav As String
        'Dim Prev1R, Prev2R, Prev3R As Decimal
        'Dim VozarinskiStav As Decimal
        'Dim PV As String
        'Dim TonskiStavInteger As Integer

        'Dim PrevozninaPoKolima As Decimal = 0
        'Dim RacMasaPoKolima As Integer

        'Dim Tabela As String

        'Dim bVrsta00tranzita As Byte = 1




        'Prevoznina = 0
        'bRedovanOrocen = "R"

        'If dtKola.Rows.Count > 0 Then
        '    'RedniBroj = 0
        '    For Each KolaRed In dtKola.Rows    ' petlja po kolima 
        '        ' ucitavanje polja

        '        'dodeliti vrednosti za promenljive

        '        IBK = KolaRed.Item("IndBrojKola")
        '        Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
        '        TipKola = KolaRed.Item("Tip")
        '        Vlasnistvo = KolaRed.Item("Vlasnik")
        '        BrOsovina = KolaRed.Item("Osovine")


        '        '14.06.
        '        TipKola = "7"
        '        If TipKola = "7" Then
        '            TovarenaPrazna = "PK"
        '        Else
        '            TovarenaPrazna = "TK"
        '        End If


        '        bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
        '               TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
        '               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


        '        'Select Case TipKola
        '        '    Case "1"
        '        '        KolKoef = 1.0
        '        '    Case "2"
        '        '        KolKoef = 1.3
        '        '    Case "3"
        '        '        KolKoef = 0.8
        '        '    Case "4"
        '        '        KolKoef = 0.7
        '        '    Case "5"
        '        '        KolKoef = 0.8
        '        '    Case "6"
        '        '        KolKoef = 0.8
        '        '    Case "7"
        '        '        KolKoef = 0.3
        '        'End Select

        '        ' umesto ovoga gore ukljuciti proceduru NadjiKolKoef


        '        If dtNhm.Rows.Count > 0 Then
        '            Masa1R = 0
        '            Masa2R = 0
        '            Masa3R = 0
        '            Prev1R = 0
        '            Prev2R = 0
        '            Prev3R = 0

        '            For Each NHMRed In dtNhm.Rows   '  petlja po robi
        '                If NHMRed.Item("IndBrojKola") = IBK Then
        '                    MasaTemp = NHMRed.Item("Masa")
        '                    Razred = NHMRed.Item("R")
        '                    bZaokruziMasuNa100k(MasaTemp)
        '                    Select Case Razred                                        ' grupisanje po razredima
        '                        Case "1"
        '                            Masa1R = Masa1R + MasaTemp
        '                        Case "2"
        '                            Masa2R = Masa2R + MasaTemp
        '                        Case "3"
        '                            Masa3R = Masa3R + MasaTemp
        '                    End Select
        '                End If
        '            Next

        '            ' da li je ulaz masaTemp?

        '            PrevozninaPoKolima = 0

        '            bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, Masa1R, Masa2R, Masa3R, TonskiStav)
        '            TonskiStavInteger = CType(TonskiStav, Integer)
        '            MasaTemp = TonskiStavInteger * 1000
        '            ' prevoznine po razredima:
        '            bNadjiVozarinskiStavCO(mBrojUg, "171", mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav, PV)
        '            Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 10 / 1000
        '            ' zaokruzivanje?
        '            Prev1R = Prev1R * bPrevozninaKoef
        '            bNadjiVozarinskiStavCO(mBrojUg, "171", mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "2", VozarinskiStav, PV)
        '            Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 10 / 1000
        '            ' zaokruzivanje?
        '            Prev2R = Prev2R * bPrevozninaKoef
        '            bNadjiVozarinskiStavCO(mBrojUg, "171", mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "3", VozarinskiStav, PV)
        '            Prev3R = Masa3R * rbStavKoef * VozarinskiStav * KolKoef / 10 / 1000
        '            ' zaokruzivanje?
        '            Prev3R = Prev3R * bPrevozninaKoef
        '            PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

        '            'zaokruzivanje na 0.10 e
        '            'bzaokruzina desetenavise(prevozninapokolima)


        '            ' Testiraj na minimalnu prevozninu
        '            RacMasaPoKolima = Masa1R + Masa2R + Masa3R

        '            If PrevozninaPoKolima <= bMinPrevoznina Then
        '                PrevozninaPoKolima = bMinPrevoznina
        '            End If

        '            KolaRed.Item("Prevoznina") = PrevozninaPoKolima

        '        End If
        '        Prevoznina = Prevoznina + PrevozninaPoKolima

        '    Next    ' petlja po kolima

        'Else
        '    ' nema ni kola ni prevoznine
        'End If


    End Sub                                                ' 69CO
    Public Sub bNadjiPrevozninu92CO(ByRef Prevoznina As Decimal)                       '  pozvati standardnu TEA proceduru

        'Dim KolaRed As DataRow
        'Dim NHMRed As DataRow
        ''Dim RedniBroj As Int32
        'Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        'Dim BrOsovina As Byte
        'Dim KolKoef As Decimal = 1

        'Dim Masa1R, Masa2R, Masa3R As Integer
        'Dim MasaTemp As Integer
        'Dim Razred As String
        'Dim TonskiStav As String
        'Dim Prev1R, Prev2R, Prev3R As Decimal
        'Dim VozarinskiStav As Decimal
        'Dim PV As String
        'Dim TonskiStavInteger As Integer

        'Dim PrevozninaPoKolima As Decimal = 0
        'Dim RacMasaPoKolima As Integer

        'Dim Tabela As String

        'Dim bVrsta00tranzita As Byte = 1


        'Prevoznina = 0
        'bRedovanOrocen = "R"

        'If dtKola.Rows.Count > 0 Then
        '    'RedniBroj = 0
        '    For Each KolaRed In dtKola.Rows    ' petlja po kolima 
        '        ' ucitavanje polja

        '        'dodeliti vrednosti za promenljive

        '        IBK = KolaRed.Item("IndBrojKola")
        '        Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
        '        TipKola = KolaRed.Item("Tip")
        '        Vlasnistvo = KolaRed.Item("Vlasnik")
        '        BrOsovina = KolaRed.Item("Osovine")
        '        TipKola = KolaRed.Item("Tip")

        '        '14.06.
        '        TipKola = "7"
        '        If TipKola = "7" Then
        '            TovarenaPrazna = "PK"
        '        Else
        '            TovarenaPrazna = "TK"
        '        End If


        '        bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
        '               TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
        '               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
        '        ' 14.06.

        '        Select Case TipKola
        '            Case "1"
        '                KolKoef = 1.0
        '            Case "2"
        '                KolKoef = 1.3
        '            Case "3"
        '                KolKoef = 0.8
        '            Case "4"
        '                KolKoef = 0.7
        '            Case "5"
        '                KolKoef = 0.8
        '            Case "6"
        '                KolKoef = 0.8
        '            Case "7"
        '                KolKoef = 0.3
        '        End Select
        '        If dtNhm.Rows.Count > 0 Then
        '            Masa1R = 0
        '            Masa2R = 0
        '            Masa3R = 0
        '            Prev1R = 0
        '            Prev2R = 0
        '            Prev3R = 0

        '            For Each NHMRed In dtNhm.Rows   '  petlja po robi
        '                If NHMRed.Item("IndBrojKola") = IBK Then
        '                    MasaTemp = NHMRed.Item("Masa")
        '                    Razred = NHMRed.Item("R")
        '                    bZaokruziMasuNa100k(MasaTemp)
        '                    Select Case Razred                                        ' grupisanje po razredima
        '                        Case "1"
        '                            Masa1R = Masa1R + MasaTemp
        '                        Case "2"
        '                            Masa2R = Masa2R + MasaTemp
        '                        Case "3"
        '                            Masa3R = Masa3R + MasaTemp
        '                    End Select
        '                End If
        '            Next

        '            ' da li je ulaz masaTemp?

        '            PrevozninaPoKolima = 0

        '            bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, Masa1R, Masa2R, Masa3R, TonskiStav)
        '            TonskiStavInteger = CType(TonskiStav, Integer)
        '            MasaTemp = TonskiStavInteger * 1000
        '            ' prevoznine po razredima:
        '            bNadjiVozarinskiStavCO(mBrojUg, "171", mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav, PV)
        '            Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 10 / 1000
        '            ' zaokruzivanje?
        '            Prev1R = Prev1R * bPrevozninaKoef
        '            bNadjiVozarinskiStavCO(mBrojUg, "171", mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "2", VozarinskiStav, PV)
        '            Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 10 / 1000
        '            ' zaokruzivanje?
        '            Prev2R = Prev2R * bPrevozninaKoef
        '            bNadjiVozarinskiStavCO(mBrojUg, "171", mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "3", VozarinskiStav, PV)
        '            Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 10 / 1000
        '            ' zaokruzivanje?
        '            Prev3R = Prev3R * bPrevozninaKoef
        '            PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

        '            'zaokruzivanje na 0.10 e
        '            'bzaokruzina desetenavise(prevozninapokolima)


        '            ' Testiraj na minimalnu prevozninu
        '            RacMasaPoKolima = Masa1R + Masa2R + Masa3R

        '            If PrevozninaPoKolima <= bMinPrevoznina Then
        '                PrevozninaPoKolima = bMinPrevoznina
        '            End If

        '            KolaRed.Item("Prevoznina") = PrevozninaPoKolima

        '        End If
        '        Prevoznina = Prevoznina + PrevozninaPoKolima

        '    Next    ' petlja po kolima

        'Else
        '    ' nema ni kola ni prevoznine
        'End If


    End Sub                                                ' 92CO

    Public Sub bNadjiRasterCO(ByVal inDuzinaKont As String, ByVal inStvMasa As Integer, ByRef outRaster As Decimal)

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

    End Sub
    Public Sub bNadjiPrevozninuKontCO(ByRef Prevoznina As Decimal)

        ' dodati specificnosti za CO

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


        Dim Tabela As String = "134"  ' CO kontejneri

        ' Postupak:
        ' - cena se racuna posebno za svaki UTI i zaokruzuje se samo  jednom i to po UTI-ju na ceo euro navise
        ' - na osnovu duzine ( odnosno sifre LC/CL ) i bruto mase naci raster koeficijent
        ' - na osnovu tkm nalazi se osnovna cena ( str.218 )
        ' - cene prevoza u privatnim kolima se smanjuju za 20% (mKolKoef = 0.8 )
        ' - uracunati bStavKoef
        ' - uracunati bPrevozninaKoef
        ' - uracunati minimalnu prevozninu
        ' ? ICF tarifa minprev, P kola

        UkupnoKola = dtKola.Rows.Count

        Prevoznina = 0
        bValuta = "17"
        bRedovanOrocen = "R"

        Dim TipKola As String
        For Each KolaRed In dtKola.Rows                                         ' petlja po kolima
            PrevozninaPoKolima = 0
            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            TipKola = KolaRed.Item("Tip")

            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            ' Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna


            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            KolKoef = 1
            If Vlasnistvo = "P" Or Vlasnistvo = "I" Then
                KolKoef = 0.8
            End If

            For Each NHMRed In dtNhm.Rows
                If IBK = NHMRed.Item("IndBrojKola") Then
                    DuzinaKontStr = NHMRed.Item("UTI")
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    StvMasa = NHMRed.Item("Masa")
                    bNadjiRasterCO(DuzinaKont, StvMasa, Raster)

                    PrevozninaPoKont = 0

                    ' Tabela je "134", a procedura je ista kao za TEA
                    bNadjiVozarinskiStavKontTEA(Tabela, mDatumKalk, bTkm, VozarinskiStav, PV)
                    VozarinskiStav = bStavKoef * VozarinskiStav

                    '###
                    Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                    bZaokruziMasuNa100k(MasaTemp1)
                    NHMRed.Item("RacMasaNHM") = MasaTemp1
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                    '###

                    PrevozninaPoKont = VozarinskiStav * Raster * KolKoef * bPrevozninaKoef
                    bZaokruziNaDeseteNavise(PrevozninaPoKont)

                    PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaPoKont
                End If
            Next
            ' proba na minimalnu prevozninu

            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            KolaRed.Item("Prevoznina") = PrevozninaPoKolima

            Prevoznina = Prevoznina + PrevozninaPoKolima
        Next
    End Sub
    Public Sub bNadjiRacunskuMasuPoKolima(ByVal outRacMasa As Decimal)


    End Sub

    Public Sub bNadjiVozarinskiStavCO(ByVal inBrUgovora As String, _
                                      ByVal inTabelaCena As String, _
                                      ByVal inDatumKalk As Date, _
                                      ByVal inMasa As Integer, _
                                      ByVal inStanica1 As String, _
                                      ByVal inStanica2 As String, _
                                      ByVal inUprava As String, _
                                      ByVal inTipK As String, _
                                      ByVal inRazred As String, _
                                      ByRef outVozarinskiStav As Decimal, _
                                      ByRef outRetVal As String)


        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        'Dim outProv As Integer = 0

        Dim spKomanda As New SqlClient.SqlCommand("dbo.uspIzrStavR", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUgovora As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipUgovor", SqlDbType.Char, 6))
        ulBrUgovora.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipUgovor").Value = inBrUgovora

        Dim ulTabelaCena As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipTabC", SqlDbType.Char, 3))
        ulTabelaCena.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipTabC").Value = inTabelaCena

        Dim ulDatumKalk As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipDatum", SqlDbType.DateTime))
        ulDatumKalk.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipDatum").Value = inDatumKalk

        Dim ulMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipMasa", SqlDbType.Int))
        ulMasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipMasa").Value = inMasa

        Dim ulStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipSt1", SqlDbType.Char, 5))
        ulStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipSt1").Value = inStanica1

        Dim ulStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipSt2", SqlDbType.Char, 5))
        ulStanica2.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipSt2").Value = inStanica2

        Dim ulUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipUprava", SqlDbType.Char, 2))
        ulUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipUprava").Value = inUprava

        Dim ulTipK As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipTipK", SqlDbType.Char, 1))
        ulTipK.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipTipK").Value = inTipK

        Dim ulRazred As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRaz", SqlDbType.Char, 1))
        ulRazred.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipRaz").Value = inRazred

        Dim izVozarinskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upStav", SqlDbType.Money, 9))
        izVozarinskiStav.Direction = ParameterDirection.Output
        'izVozarinskiStav.Size = 8
        'izVozarinskiStav.Precision = 19
        'izVozarinskiStav.Scale = 4

        'Dim upProv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upProv", SqlDbType.Int))
        'upProv.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@upProv").Value = outProv

        'Dim PovratnaVrednost As SqlClient.SqlParameter
        'PovratnaVrednost = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@PovrVrednost", SqlDbType.Int))
        'PovratnaVrednost.Direction = ParameterDirection.ReturnValue

        Try
            'cnRoba.Open()
            'DbVezaCene.Open()
            spKomanda.ExecuteScalar()
            'Dim Pom As Int16 = spKomanda.Parameters("@PovrVrednost").Value
            'Pom = spKomanda.Parameters("@PovrVrednost").Value
            'If Pom <> 0 Then outRetVal = " Neuspesan upit!" 'Pom = spKomanda.Parameters("@PovrVrednost").Value

            outVozarinskiStav = spKomanda.Parameters("@upStav").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            'cnRoba.Close()
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub bNadjiVozarinskiStavkmCO(ByVal inBrUgovora As String, _
                                                    ByVal inTabelaCena As String, _
                                                    ByVal inDatumKalk As Date, _
                                                    ByVal inMasa As Integer, _
                                                    ByVal intkm As Integer, _
                                                    ByVal inUprava As String, _
                                                    ByVal inTipK As String, _
                                                    ByVal inRazred As String, _
                                                    ByRef outVozarinskiStav As Decimal, _
                                                    ByRef outRetVal As String)


        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        'Dim outProv As Integer = 0

        Dim spKomanda As New SqlClient.SqlCommand("dbo.uspIzrStav", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUgovora As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipUgovor", SqlDbType.Char, 6))
        ulBrUgovora.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipUgovor").Value = inBrUgovora

        Dim ulTabelaCena As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipTabC", SqlDbType.Char, 3))
        ulTabelaCena.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipTabC").Value = inTabelaCena

        Dim ulDatumKalk As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipDatum", SqlDbType.DateTime))
        ulDatumKalk.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipDatum").Value = inDatumKalk

        Dim ulMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipMasa", SqlDbType.Int))
        ulMasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipMasa").Value = inMasa

        Dim ultkm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipkm", SqlDbType.Int))
        ultkm.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipkm").Value = intkm

        Dim ulRazred As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRaz", SqlDbType.Char, 1))
        ulRazred.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipRaz").Value = inRazred

        Dim izVozarinskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upStav", SqlDbType.Money))
        izVozarinskiStav.Direction = ParameterDirection.Output
        izVozarinskiStav.Size = 8
        izVozarinskiStav.Precision = 19
        izVozarinskiStav.Scale = 2

        'Dim upProv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upProv", SqlDbType.Int))
        'upProv.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@upProv").Value = outProv

        'Dim PovratnaVrednost As SqlClient.SqlParameter
        'PovratnaVrednost = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@PovrVrednost", SqlDbType.Int))
        'PovratnaVrednost.Direction = ParameterDirection.ReturnValue

        Try
            'cnRoba.Open()
            'DbVezaCene.Open()
            spKomanda.ExecuteScalar()
            'Dim Pom As Int16 = spKomanda.Parameters("@PovrVrednost").Value
            'Pom = spKomanda.Parameters("@PovrVrednost").Value
            'If Pom <> 0 Then outRetVal = " Neuspesan upit!" 'Pom = spKomanda.Parameters("@PovrVrednost").Value

            outVozarinskiStav = spKomanda.Parameters("@upStav").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            'cnRoba.Close()
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub

    Public Sub bNadjiUgKoef(ByVal inBrUgovora As String, _
                            ByVal inVrstaSaobracaja As String, _
                            ByVal inReka As String, _
                            ByRef outPrevKoef As Decimal, _
                            ByRef outRetVal As String)

        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiUgKoef", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUgovora As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUgovora.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrUgovora

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaSaobracaja", SqlDbType.Char, 1))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaSaobracaja").Value = inVrstaSaobracaja

        Dim ulReka As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inReka", SqlDbType.Char, 1))
        ulReka.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inReka").Value = inReka

        Dim izPrevKoef As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevKoef", SqlDbType.Decimal))
        izPrevKoef.Direction = ParameterDirection.Output
        izPrevKoef.Size = 5
        izPrevKoef.Precision = 6
        izPrevKoef.Scale = 2

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()

            outPrevKoef = spKomanda.Parameters("@outPrevKoef").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub bNadjiBrojRealizovanihVozova(ByVal inBrUgovora As String, _
                                  ByVal inStanica1 As String, _
                                  ByVal inStanica2 As String, _
                                  ByRef outRealizovanoVozova As Integer, _
                                  ByRef outRetVal As String)


        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiBrojRealizovanihVozova", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUgovora As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUgovora.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrUgovora

        Dim ulStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica1", SqlDbType.Char, 5))
        ulStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica1").Value = inStanica1

        Dim ulStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica2", SqlDbType.Char, 5))
        ulStanica2.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica2").Value = inStanica2

        Dim izRealizovanoVozova As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRealizovanoVozova", SqlDbType.Int))
        izRealizovanoVozova.Direction = ParameterDirection.Output

        Dim izRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50))
        izRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()

            outRealizovanoVozova = spKomanda.Parameters("@outRealizovanoVozova").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub bNadjiPrevozninu22CO(ByRef Prevoznina As Decimal)          ' Proodos kontejnerski vozovi

        Dim bIzborABCD As String
        Dim bABCD As Integer ' String
        Dim bCenaPoVozu00, bCenaPoVozuOt, bCenaPoVozuUp As Decimal
        Dim bCena As Decimal
        Dim bVrsta As Integer ' String

        Dim PV As String = ""

        'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
        '       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
        '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

        bNadjiBrojRealizovanihVozova(mBrojUg, mStanica1, mStanica2, bABCD, PV)

        '-------------------------------------------------------------------------
        bCenaPoVozu00 = 0

        mTabelaCena = "211" 'privremeno

        bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, "00", "0", "0", bCenaPoVozu00, PV)

        mPrevoznina = bCenaPoVozu00

        ' bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bVrsta, mStanica1, mStanica2, "0", "0", bVrsta, bCena, PV)
        ' mPrevoznina = bCena

        ' Testirati na minimalnu prevozninu

        '           If PrevozninaPoKolima <= bMinPrevoznina Then
        '                       PrevozninaPoKolima = bMinPrevoznina
        '        End If

        ' Upisi na PRVA kola
        ' KolaRed.Item("Prevoznina") = PrevozninaPoKolima

        ' ---------------------------------- Upis racunske mase i vozarinskog stava po robi --------------------------------
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK As String
        Dim bRacunskaMasaNHM As Decimal

        For Each KolaRed In dtKola.Rows    ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            Dim BrOsovina As Integer
            BrOsovina = KolaRed.Item("Osovine")
            For Each NHMRed In dtNhm.Rows
                If NHMRed.Item("IndBrojKola") = IBK Then
                    bRacunskaMasaNHM = NHMRed.Item("Masa")
                    bZaokruziMasuNa100k(bRacunskaMasaNHM)
                    If bRacunskaMasaNHM <= BrOsovina * 5000 Then
                        bRacunskaMasaNHM = BrOsovina * 5000
                    End If
                    NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                    NHMRed.Item("VozarinskiStavNHM") = bCenaPoVozu00
                End If
            Next
        Next
    End Sub                                                 ' 01CO
    Public Sub bNadjiKolPrevKoef(ByVal inBrUgovora As String, _
                                        ByVal inTip As String, _
                                        ByVal inVrsta As String, _
                                        ByVal inVlasnistvo As String, _
                                        ByVal inTovarenaPrazna As String, _
                                        ByVal inTarifa As String, _
                                        ByVal inDodUslov As String, _
                                        ByRef outKolPrevKoef As Decimal, _
                                        ByRef outRetVal As String)

        ' inTip                        1  -  7 za tip kola,    0  ako ne utice 
        ' inVrsta                     1 - obicna,  2 - specijalna,   0  ako ne utice 
        ' inVlasnistvo              Z  zeleznicka,   P   privatna,    I   iznajmljena,   0  ako ne utice 
        ' inTovarenaPrazna     TK  tovarena,     PK  prazna,     00  ako ne utice 
        ' inTarifa                    00  ako ne utice 
        ' inDodUslov               00  ako ga nema


        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiKolPrevKoef", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUgovora As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrUgovora", SqlDbType.Char, 6))
        ulBrUgovora.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrUgovora").Value = inBrUgovora

        Dim ulTip As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTip", SqlDbType.Char, 1))
        ulTip.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTip").Value = inTip

        Dim ulVrsta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrsta", SqlDbType.Char, 1))
        ulVrsta.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrsta").Value = inVrsta

        Dim ulVlasnistvo As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvo", SqlDbType.Char, 1))
        ulVlasnistvo.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvo").Value = inVlasnistvo

        Dim ulTovarenaPrazna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTovarenaPrazna", SqlDbType.Char, 2))
        ulTovarenaPrazna.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTovarenaPrazna").Value = inTovarenaPrazna

        Dim ulTarifa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTarifa", SqlDbType.Char, 2))
        ulTarifa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTarifa").Value = inTarifa

        Dim ulDodUslov As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDodUslov", SqlDbType.Char, 2))
        ulDodUslov.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDodUslov").Value = inDodUslov

        Dim izKolPrevKoef As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolPrevKoef", SqlDbType.Decimal))
        izKolPrevKoef.Direction = ParameterDirection.Output
        izKolPrevKoef.Size = 5
        izKolPrevKoef.Precision = 6
        izKolPrevKoef.Scale = 2

        Dim izRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50))
        izRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()

            outKolPrevKoef = spKomanda.Parameters("@outKolPrevKoef").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub bNadjiPrevozninu01COMakis(ByRef Prevoznina As Decimal)          ' vozovi

        Dim bIzborABCD As String
        Dim bABCD As Integer ' String
        Dim bCenaPoVozu00, bCenaPoVozuOt, bCenaPoVozuUp As Decimal

        Dim bCena As Decimal
        Dim bBarIHSH As Boolean = False
        Dim bVrsta As Integer ' String

        Dim PV As String = ""

        bNadjiBrojRealizovanihVozova(mBrojUg, mStanica1, mStanica2, bABCD, PV)

        '------------------ Nalazi sifru tabele iz SifTabCen ---------------------
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""

        Util.sNadjiNaziv("NazivTabele", mBrojUg, "", "", 1, xNaziv, xPovVrednost)

        If xPovVrednost <> "" Then
            mTabelaCena = " "
        Else
            mTabelaCena = xNaziv
        End If

        If ((mStanica1 = "16201") Or (mStanica2 = "16201")) Then
            'bNadjiBrutoMasu(mBrutoMasaPoPosiljci)
            bABCD = Int(mBrutoMasaPoPosiljci / 1000) ' u tonama
            mTabelaCena = "212"
        Else
        End If

        bVozarinskiStav = mPrevoznina

        '-------------------------------------------------------------------------
        bCenaPoVozu00 = 0
        bCenaPoVozuOt = 0
        bCenaPoVozuUp = 0

        bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, "00", "0", "0", bCenaPoVozu00, PV)
        bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, mOtpUprava, "0", "0", bCenaPoVozuOt, PV)
        bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, mPrUprava, "0", "0", bCenaPoVozuUp, PV)

        If Not (bCenaPoVozu00 = 0) Then
            mPrevoznina = bCenaPoVozu00
        ElseIf Not (bCenaPoVozuOt = 0) Then
            mPrevoznina = bCenaPoVozuOt
        ElseIf Not (bCenaPoVozuUp = 0) Then
            mPrevoznina = bCenaPoVozuUp
        End If

        bVozarinskiStav = mPrevoznina

    End Sub
    Public Sub bNadjiNaftu(ByVal inNHM As String, ByVal intkm As Integer, _
                                      ByRef outDodatak As Decimal)

        Dim NHM14 As Integer

        outDodatak = 0

        NHM14 = CType(Microsoft.VisualBasic.Left(inNHM, 4), Integer)

        If (NHM14 = 2709) Or (NHM14 = 2711) Or ((NHM14 >= 2721) And (NHM14 <= 2749)) Then

            If intkm < 101 Then outDodatak = 53
            If (intkm > 100) And (intkm < 351) Then outDodatak = 162
            If intkm > 350 Then outDodatak = 201

        End If


    End Sub
    Public Sub bDaLiJeNafta(ByVal inNHM As String, _
                                          ByRef outDaNe As Boolean)

        Dim NHM14 As Integer
        outDaNe = False

        NHM14 = CType(Microsoft.VisualBasic.Left(inNHM, 4), Integer)

        If (NHM14 = 2709) Or (NHM14 = 2711) Or ((NHM14 >= 2721) And (NHM14 <= 2749)) Then
            outDaNe = True
        End If

    End Sub
    Public Sub DaLiJeSpecijalniHCD(ByVal inBrojUgovora As String, _
                                           ByRef outDaNe As Boolean)

        Dim NHMRed As DataRow
        Dim NHM14 As Integer

        outDaNe = False
        UpisPoKolima = False

        NHM14 = CType(Microsoft.VisualBasic.Left(dtNhm.Rows(0).Item("NHM"), 4), Integer)

        If (inBrojUgovora = "480701") And (NHM14 = 2606) Then
            outDaNe = True
            UpisPoKolima = True
        End If

    End Sub

    Public Sub bNadjiUpravu6573(ByVal inBrojUgovora As String, _
                                ByVal inBrojNajave As String, _
                                ByVal inObrMesec As String, _
                                ByVal inObrGodina As String, _
                                ByRef outUprava As String, _
                                ByRef outRetVal As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiUpravu6573", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUgovora As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUgovora.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        Dim ulBrojNajave As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojNajave", SqlDbType.Char, 10))
        ulBrojNajave.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojNajave").Value = inBrojNajave

        Dim ulObrMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2))
        ulObrMesec.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inObrMesec").Value = inObrMesec

        Dim ulObrGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4))
        ulObrGodina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inObrGodina").Value = inObrGodina

        Dim izUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUprava", SqlDbType.Char, 2))
        izUprava.Direction = ParameterDirection.Output

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()

            outUprava = spKomanda.Parameters("@outUprava").Value
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
    Public Sub bObradiAnekse(ByVal inBrojUgovora As String)

        '   Parametri koji uticu na anekse:
        '   ULAZ:
        '   - broj ugovora ( detaljan, a ne osnovni );
        '   - datum pocetka vazenja;
        '   - NHM pozicije ( glave );
        '   - relacije ( stanica Od i stanica Do );
        '   - vlasnistvo kola;
        '   - broj osovina kola;
        '   - broj vozova;
        '   IZLAZ:
        '   - cena ( cetiri cene - zbog vozova );
        '   - vrsta cene ( po toni, po kolima, po vozu, koeficijent( tj. procenat ) )


        If Microsoft.VisualBasic.Left(inBrojUgovora, 4) = "0507" Then           ' 050700 FERSPED

        ElseIf Microsoft.VisualBasic.Right(inBrojUgovora, 4) = "0607" Then      ' 060700 TCL
            If Microsoft.VisualBasic.Right(inBrojUgovora, 2) = "01" Then
                ' tel.298
                ' If ((NHM = 2711) And
                '   ( Datum >= 01.02.2007 ) And
                '   ( Vlasnistvo kola = P ) And
                '   ( Broj Osovina = 4 )) Then
                '       If (Stanica1=Sid And Stanica2=Dimitrovgrad) Or Then
                '          (Stanica1=Sid And Stanica2=Presevo) Or  
                '          (Stanica1=Subotica And Stanica2=Presevo) Or  
                '          (Stanica1=Subotica And Stanica2=Dimitrovgrad) Or  
                '          (Stanica1=Sid And Stanica2=Prijepolje) Or  
                '          (Stanica1=Sid And Stanica2=Vrsac) Then
                '               Cena = 0.75
                '               VrstaCene = Koeficijent
                '   End If
            ElseIf Microsoft.VisualBasic.Right(inBrojUgovora, 2) = "02" Then
                ' tel.298
                ' If ((NHM = 2711) And
                '   ( Datum >= 01.02.2007 ) And
                '   ( Vlasnistvo kola = P ) And
                '   ( Broj Osovina = 4 )) Then
                '       If Stanica1=Sid And Stanica2=Dimitrovgrad Then
                '           Cena = 12.4
                '           VrstaCene = PoToni
                '       ElseIf Stanica1=Sid And Stanica2=Presevo Then
                '           Cena = 14.5
                '           VrstaCene = PoToni
                '       ElseIf Stanica1=Subotica And Stanica2=Presevo Then
                '           Cena = 16.3
                '           VrstaCene = PoToni
                '       ElseIf Stanica1=Subotica And Stanica2=Dimitrovgrad Then
                '           Cena = 12.6
                '           VrstaCene = PoToni
                '       ElseIf Stanica1=Sid And Stanica2=Prijepolje Then
                '           Cena = 14.4
                '           VrstaCene = PoToni
                '       ElseIf Stanica1=Sid And Stanica2=Vrsac Then
                '           Cena = 8.5
                '           VrstaCene = PoToni
                '       End If
                ' If ((NHM = PrivatnaPrazna, tj. PrivatnePrazneCisterne ) And
                '   ( Datum >= 01.02.2007 ) And
                '   ( Vlasnistvo kola = P ) And
                '   ( Broj Osovina = 4 )) Then
                '       If Stanica1=Sid And Stanica2=Dimitrovgrad Then
                '           Cena = 115
                '           VrstaCene = PoKolima
                '       ElseIf Stanica1=Sid And Stanica2=Presevo Then
                '           Cena = 116
                '           VrstaCene = PoKolima
                '       ElseIf Stanica1=Subotica And Stanica2=Presevo Then
                '           Cena = 131
                '           VrstaCene = PoKolima
                '       ElseIf Stanica1=Subotica And Stanica2=Dimitrovgrad Then
                '           Cena = 119
                '           VrstaCene = PoKolima
                '       ElseIf Stanica1=Sid And Stanica2=Prijepolje Then
                '           Cena = 95
                '           VrstaCene = PoKolima
                '       ElseIf Stanica1=Sid And Stanica2=Vrsac Then
                '           Cena = 60
                '           VrstaCene = PoKolima
                '       End If
            End If

        End If
    End Sub
    Public Sub bNadjiPrevKoefCOUI(ByRef outPrevKoefCOUI As Decimal)

        If Microsoft.VisualBasic.Right(mBrojUg, 2) = "02" Then      ' grupe kola

            If (Not ((mStanica1 = "15723") Or (mStanica2 = "15723"))) Then
                If IzborSaobracaja = "2" Then
                    outPrevKoefCOUI = 0.95
                ElseIf IzborSaobracaja = "3" Then
                    outPrevKoefCOUI = 0.9
                End If
            Else : outPrevKoefCOUI = 1 ' za Prijepolje
            End If

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "01" Then  ' vozovi

            If (Not ((mStanica1 = "15723") Or (mStanica2 = "15723"))) Then
                If IzborSaobracaja = "2" Then
                    outPrevKoefCOUI = 0.8
                ElseIf IzborSaobracaja = "3" Then
                    outPrevKoefCOUI = 0.85
                End If
            Else : outPrevKoefCOUI = 0.9 ' za Prijepolje
            End If

        End If

    End Sub
    Public Sub bKorigujPoAneksu(ByVal inVrstaKorekcije As Integer, ByVal inPrevoznina As Decimal, ByVal inKoeficijent As Decimal, ByVal inRacunskaMasa As Decimal, _
           ByVal inCena As Decimal, ByVal inStvarnaMasa As Integer, ByVal intkm As Integer, ByVal inDodatak As Decimal, ByRef outIzlaz As Decimal)


        Select Case inVrstaKorekcije
            Case 1
                outIzlaz = inPrevoznina * inKoeficijent    ' Prevoznina * Koeficijent                
            Case 2
                outIzlaz = inCena * inRacunskaMasa / 1000  ' CenaPoToni * RacMasa
                'Case 3
                '   outIzlaz = inUlaz1 * inKoeficijent    ' TonskiStav * Koeficijent
            Case 4, 5
                outIzlaz = inCena              ' CenaPoKolima, CenaPoVozu
            Case 6
                outIzlaz = inKoeficijent * inStvarnaMasa * intkm / 100 ' StvMasa * km * 0.02
            Case 7
                outIzlaz = inPrevoznina + inDodatak
        End Select



    End Sub
    Public Sub NadjiAneks(ByVal inUgovor As String, ByVal inSaobracaj As String, _
                           ByVal inStanicaOd As String, ByVal inStanicaDo As String, _
                           ByVal inOsovine As Int32, ByVal inVrstaPrevoza As String, _
                           ByVal inVlasnistvoKola As String, ByVal inVrstaKola As String, _
                           ByVal inDatum As Date, ByVal inNHM As String, ByVal outUslovZaStav As Int32, _
                           ByRef outCena As Decimal, ByRef outTipCene As Int32, _
                           ByRef outRetVal As String)

        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("spNadjiAneks", OkpDbVeza)
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

        Dim ulNHM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNHM", SqlDbType.Char, 4))
        ulNHM.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNHM").Value = inNHM

        Dim izUslovZaStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUslovZaStav", SqlDbType.Int))
        izUslovZaStav.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUslovZaStav").Value = outUslovZaStav

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
End Module
