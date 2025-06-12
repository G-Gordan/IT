Imports System.Data.SqlClient
Module KalkModulCO
    Public Sub bNadjiPrevozninuCO()

        Dim bKolKoef, bPrevKoef As Decimal
        Dim PV As String

        ' ZA UVOZ-IZVOZ:

        ' bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
        ' prvo se vidi da li je preko luke Bar ili za/iz HSH i ŽCG - procedura bDaLiJeBarIHSH(DaNe)
        ' za "obican" uvoz i izvoz tabela je 122
        ' za luku Bar, HSH i ŽCG tabela je 161

        If Microsoft.VisualBasic.Right(mBrojUg, 2) = "00" Then                           ' "obicne" pojedinacne posiljke;  tu su i kontejneri
            If IzborSaobracaja = "4" Then        ' TRANZIT
                If Not (bKontejneri) Then
                    bNadjiPrevozninu00CO(mPrevoznina) 'ok
                Else
                    bNadjiPrevozninuKontCO(mPrevoznina)
                End If
            Else
                If Not (bKontejneri) Then
                    'sta sa Albanijom!!
                    'mTabelaCena = "161" 'sta sa Albanijom!!
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
                mTabelaCena = "122"
                bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
            End If
        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "01" Then                       ' vozovi
            If IzborSaobracaja = "4" Then        ' TRANZIT
                bNadjiPrevozninu01CO(mPrevoznina)
            Else                                 ' UVOZ_IZVOZ
                mTabelaCena = "122"
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

        End If

    End Sub
    Public Sub NadjiTabelu(ByVal _BrojUg As String, ByRef _mTabelaCena As String)

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
        Dim RacMasaPoKolima As Integer

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


                If TipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If

                bValuta = "17"
                Dim bSaobracaj As Integer
                If bValuta = "72" Then
                    bSaobracaj = 1
                ElseIf bValuta = "17" Then
                    bSaobracaj = 2
                End If

                Dim bRetValLok As String = ""

                bNadjiSveIzZSKoefPos(bSaobracaj, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                '--------------????
                'Select Case TipKola
                '    Case "1"
                '        KolKoef = 1.0
                '    Case "2"
                '        KolKoef = 1.3
                '    Case "3"
                '        KolKoef = 0.8
                '    Case "4"
                '        KolKoef = 0.7
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


                ' dodato za probu
                '                Tabela = "171"
                KolKoef = 1
                bStavKoef = 1
                ' dodato za probu


                TabelaTemp = Tabela
                KolKoefTemp = KolKoef
                StavKoefTemp = bStavKoef
                'PrevKoefTemp=bPrevKoef

                bNadjiUgKoef(mBrojUg, IzborSaobracaja, "N", PrevKoefTemp, PV) '!!!inReka

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

                            'bNadjiVozarinskiStav(Tabela, mDatumKalk, Masa2, bTkm, Razred, VozarinskiStav2, PV)
                            bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, Masa2, mStanica1, mStanica2, "00", "0", "0", VozarinskiStav2, PV)
                            VozarinskiStav2 = bStavKoef * VozarinskiStav2
                            bZaokruziNaDeseteNavise(VozarinskiStav2)
                            PrevozninaPoKolima2 = Masa2 * VozarinskiStav2 * KolKoef / 1000
                            PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef

                            PrevozninaPoKolima = PrevozninaPoKolima1
                            If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                PrevozninaPoKolima = PrevozninaPoKolima2
                            End If
                            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    End Select
                End If    ' "171"

                If Tabela = "173" Then 'prodos
                    Dim ProdosUprava As String = "00"
                    Dim Masa1, Masa2 As Integer
                    Dim VozarinskiStav1, VozarinskiStav2, PrevozninaPoKolima1, PrevozninaPoKolima2 As Decimal

                    '''If mStanica1 = "12498" Or mStanica1 = "11028" Or mStanica1 = "15723" Then
                    '''    ProdosUprava = Microsoft.VisualBasic.Mid(mOtpStanica, 1, 2)
                    '''End If

                    '''If mStanica2 = "12498" Or mStanica2 = "11028" Or mStanica2 = "15723" Then
                    '''    ProdosUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)
                    '''End If

                    Masa1 = 0
                    Masa2 = 0
                    VozarinskiStav1 = 0
                    VozarinskiStav2 = 0
                    PrevozninaPoKolima1 = 0
                    PrevozninaPoKolima2 = 0

                    Select Case RacMasaPoKolima
                        Case 10000, 15000, 20000, 25000
                            'bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav, PV)
                            bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, ProdosUprava, "0", "0", VozarinskiStav, PV)

                            VozarinskiStav = bStavKoef * VozarinskiStav
                            bZaokruziNaDeseteNavise(VozarinskiStav)
                            PrevozninaPoKolima = RacMasaPoKolima * VozarinskiStav * KolKoef / 1000
                            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef

                        Case Else
                            If (RacMasaPoKolima > 10000 And RacMasaPoKolima < 15000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 10000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 10000, mStanica1, mStanica2, ProdosUprava, "0", "0", VozarinskiStav1, PV)
                                Masa2 = 15000
                            End If

                            If (RacMasaPoKolima > 15000 And RacMasaPoKolima < 20000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 15000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 15000, mStanica1, mStanica2, ProdosUprava, "0", "0", VozarinskiStav1, PV)
                                Masa2 = 20000
                            End If

                            If (RacMasaPoKolima > 20000 And RacMasaPoKolima < 25000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 20000, mStanica1, mStanica2, ProdosUprava, "0", "0", VozarinskiStav1, PV)
                                Masa2 = 25000
                            End If

                            If (RacMasaPoKolima > 25000) Then
                                'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, ProdosUprava, "0", "0", VozarinskiStav1, PV)
                                Masa2 = RacMasaPoKolima
                            End If

                            Masa1 = RacMasaPoKolima

                            VozarinskiStav1 = bStavKoef * VozarinskiStav1
                            bZaokruziNaDeseteNavise(VozarinskiStav1)
                            PrevozninaPoKolima1 = Masa1 * VozarinskiStav1 * KolKoef / 1000
                            PrevozninaPoKolima1 = PrevozninaPoKolima1 * bPrevozninaKoef

                            'bNadjiVozarinskiStav(Tabela, mDatumKalk, Masa2, bTkm, Razred, VozarinskiStav2, PV)
                            bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, Masa2, mStanica1, mStanica2, ProdosUprava, "0", "0", VozarinskiStav2, PV)
                            VozarinskiStav2 = bStavKoef * VozarinskiStav2
                            bZaokruziNaDeseteNavise(VozarinskiStav2)
                            PrevozninaPoKolima2 = Masa2 * VozarinskiStav2 * KolKoef / 1000
                            PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef

                            PrevozninaPoKolima = PrevozninaPoKolima1
                            If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                PrevozninaPoKolima = PrevozninaPoKolima2
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
                    'vazilo je za sve ugovore
                    'bNadjiVozarinskiStavCO("000000", Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", _razred1, VozarinskiStav, PV)

                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "00", "0", _razred1, VozarinskiStav, PV)
                    PrevozninaPoKolima = bStavKoef * VozarinskiStav * KolKoef

                End If

                'If Tabela = "121" Then   ' uvoz - izvoz    ???????????? otkud 121? i inace ne valja procedura
                ' ZATO JE SVE IZBACENO I URADJENO U POSEBNOJ PROCEDURI       bNadjiPrevozninuOOCOUI
                '    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                '        If NHMRed.Item("IndBrojKola") = IBK Then
                '            MasaTemp = NHMRed.Item("Masa")
                '            Razred = NHMRed.Item("R")
                '            '    bZaokruziMasuNa100k(MasaTemp)
                '            Select Case Razred                                        ' grupisanje po razredima
                '                Case "1"
                '                    Masa1R = Masa1R + MasaTemp
                '                Case "2"
                '                    Masa2R = Masa2R + MasaTemp
                '                Case "3"
                '                    Masa3R = Masa3R + MasaTemp
                '            End Select
                '            'RacMasaPoKolima = RacMasaPoKolima + MasaTemp
                '        End If
                '    Next

                '    ''''''''''''  Koriguj mase po razredima       >>>>> izlaz je valjda MasaTemp


                '    ' prevoznine po razredima:

                '    bNadjiVozarinskiStavCO(_mBrojUg, "121", mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav, PV)
                '    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                '    '' zaokruzivanje?
                '    Prev1R = Prev1R * bPrevozninaKoef


                '    bNadjiVozarinskiStavCO(_mBrojUg, "121", mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "2", VozarinskiStav, PV)
                '    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                '    '' zaokruzivanje?
                '    Prev1R = Prev1R * bPrevozninaKoef

                '    bNadjiVozarinskiStavCO(_mBrojUg, "121", mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "3", VozarinskiStav, PV)
                '    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                '    '' zaokruzivanje?
                '    Prev1R = Prev1R * bPrevozninaKoef

                '    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

                '    'zaokruzivanje na 0.10 e
                '    'bzaokruzina desetenavise(prevozninapokolima)


                '    ' Testiraj na minimalnu prevozninu
                '    ' RacMasaPoKolima = Masa1R + Masa2R + Masa3R
                'End If

                If Tabela = "161" Then
                    bNadjiPrevozninu00COUI(Tabela, PrevozninaPoKolima)
                End If

                If PrevozninaPoKolima <= bMinPrevoznina Then
                    PrevozninaPoKolima = bMinPrevoznina
                End If

                KolaRed.Item("Prevoznina") = PrevozninaPoKolima

                'End If               valjda
                Prevoznina = Prevoznina + PrevozninaPoKolima

            Next    ' petlja po kolima

        End If

    End Sub                             ' 00CO
    Public Sub bNadjiPrevozninu00COUI(ByVal Tabela As String, ByRef Prevoznina As Decimal)
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

                bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)


                'Select Case TipKola
                '    Case "1"
                '        KolKoef = 1.0
                '    Case "2"
                '        KolKoef = 1.3
                '    Case "3"
                '        KolKoef = 0.8
                '    Case "4"
                '        KolKoef = 0.7                            P R O V E R I T I   !!!
                '    Case "5"
                '        KolKoef = 0.8
                '    Case "6"
                '        KolKoef = 0.8
                '    Case "7"
                '        KolKoef = 0.3
                'End Select

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
                    Prev1R = Prev1R * bPrevozninaKoef

                    '                   bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "2", VozarinskiStav, PV)
                    bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "2", VozarinskiStav, PV)
                    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    ' zaokruzivanje?
                    Prev2R = Prev2R * bPrevozninaKoef

                    '                  bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "3", VozarinskiStav, PV)
                    bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "3", VozarinskiStav, PV)
                    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    ' zaokruzivanje?
                    Prev3R = Prev3R * bPrevozninaKoef

                    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

                    'zaokruzivanje na 0.10 ...
                    bZaokruziNaDeseteNavise(PrevozninaPoKolima)


                    ' Testiraj na minimalnu prevozninu
                    RacMasaPoKolima = Masa1R + Masa2R + Masa3R

                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                    End If

                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima

                End If
                Prevoznina = Prevoznina + PrevozninaPoKolima

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
    Public Sub bNadjiPrevozninu01CO(ByRef Prevoznina As Decimal)          ' vozovi

        Dim bIzborABCD As String
        Dim bABCD As Integer ' String
        Dim bCenaPoVozu00, bCenaPoVozuOt, bCenaPoVozuUp As Decimal
        'Dim bCenaPoVozu As Decimal
        Dim bCena As Decimal
        Dim bBarIHSH As Boolean = False
        Dim bVrsta As Integer ' String

        Dim PV As String = ""

        'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
        '       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
        '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

        bDaLiJeBarIHSH(bBarIHSH)


        If Not (bBarIHSH) Then  ' NIje Bar i Albanija

            'bIzborABCD = "E"

            'Select Case bIzborABCD
            '    Case "A"
            '        bABCD = "1"
            '    Case "B"
            '        bABCD = "2"
            '    Case "C"
            '        bABCD = "3"
            '    Case "D"
            '        bABCD = "4"
            '    Case "E"
            '        bABCD = "5"
            'End Select

            bABCD = 200 'kolona A ; kolona C: bABCD = 2000

            ' u ovom slucaju je razredstavka uvek nula, a izbor A, B, C, D je kroz stavke ulazne mase
            'mTabelaCena = "210"

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


            'bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, "00", "0", "0", bCenaPoVozu, PV)
            'mPrevoznina = bCenaPoVozu

            'uvesti koeficijent ili iskoristiti postojeci
            ' mPrevoznina = NekiKoef*mPrevoznina 
            ' zaokruzivanje na ceo iznos

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

            bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bVrsta, mStanica1, mStanica2, "0", "0", bVrsta, bCena, PV)
            mPrevoznina = bCena

            'If bVrsta = "3" Then
            '    mPrevoznina = bCena * UkupnoKola
            'End If    ili ubaciti u petlju, pa testirati za svaka kola?

        End If

        ' Testirati na minimalnu prevozninu

        '           If PrevozninaPoKolima <= bMinPrevoznina Then
        '                       PrevozninaPoKolima = bMinPrevoznina
        '        End If

        ' Upisi na PRVA kola
        ' KolaRed.Item("Prevoznina") = PrevozninaPoKolima

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


                '' postavljeno zbog probe
                'TipKola = "7"
                '' postavljeno zbog probe

                '' postavljeno zbog probe
                'Vlasnistvo = "P"
                '' postavljeno zbog probe


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
                bNadjiSveIzZSKoefPos(bSaobracaj, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)


                'Select Case TipKola
                '    Case "1"
                '        KolKoef = 1.0
                '    Case "2"
                '        KolKoef = 1.3
                '    Case "3"
                '        KolKoef = 0.8
                '    Case "4"
                '        KolKoef = 0.7
                '    Case "5"
                '        KolKoef = 0.8
                '    Case "6"
                '        KolKoef = 0.8
                '    Case "7"
                '        KolKoef = 0.3
                'End Select

                ' umesto ovoga gore ukljuciti proceduru NadjiKolKoef

                If dtNhm.Rows.Count > 0 Then

                    RacMasaPoKolima = 0

                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            Razred = NHMRed.Item("R")
                            'bZaokruziMasuNa100k(MasaTemp)

                            RacMasaPoKolima = RacMasaPoKolima + MasaTemp

                        End If
                    Next
                    bZaokruziMasuNa100k(RacMasaPoKolima)

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

                    If mStanica2 = "11028" Then
                        If mStanica1 <> "12498" Then
                            ProdosUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)
                        End If
                    End If
                    '------------------------------------------------------

                    bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, RacMasaPoKolima, mStanica1, mStanica2, ProdosUprava, "0", _razred, VozarinskiStav, PV)

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

                                    bNadjiVozarinskiStavCO(xString, mTabelaCena, mDatumKalk, Masa2, mStanica1, mStanica2, ProdosUprava, "0", _razred, VozarinskiStav2, PV)
                                    VozarinskiStav2 = bStavKoef * VozarinskiStav2
                                    bZaokruziNaDeseteNavise(VozarinskiStav2)
                                    PrevozninaPoKolima2 = Masa2 * VozarinskiStav2 * KolKoef / 1000
                                    PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef

                                    PrevozninaPoKolima = PrevozninaPoKolima1
                                    If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                        PrevozninaPoKolima = PrevozninaPoKolima2
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

                        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                    End If
                End If
                Prevoznina = Prevoznina + PrevozninaPoKolima
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
        bNadjiVozarinskiStavCO("000011", "310", mDatumKalk, 1, mStanica1, mStanica2, "0", "0", "0", VozarinskiStav, PV)

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

                Dim bSaobracaj As Integer
                If bValuta = "72" Then
                    bSaobracaj = 1
                ElseIf bValuta = "17" Then
                    bSaobracaj = 2
                End If

                Dim bRetValLok As String = ""

                bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                       "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)


                If VozarinskiStav <> 0 Then  '  relacija postoji , pa je prema 1.
                    PrevozninaPoKolima = VozarinskiStav
                Else                    '   relacija ne postoji, pa je prema 2.   ( TRANZIT ILI UVOZ-IZVOZ ):

                    If IzborSaobracaja = 4 Then

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

                                    Masa1 = bStvMasa

                                    VozarinskiStav1 = bStavKoef * VozarinskiStav1
                                    bZaokruziNaDeseteNavise(VozarinskiStav1)
                                    PrevozninaPoKolima1 = Masa1 * VozarinskiStav1 * KolKoef / 1000
                                    PrevozninaPoKolima1 = PrevozninaPoKolima1 * bPrevozninaKoef * 0.3
                                    bZaokruziNaDeseteNavise(PrevozninaPoKolima1)

                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "0", "0", "1", VozarinskiStav2, PV)
                                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, Masa2, bTkm, Razred, VozarinskiStav2, PV)
                                    VozarinskiStav1 = bStavKoef * VozarinskiStav2
                                    bZaokruziNaDeseteNavise(VozarinskiStav2)
                                    PrevozninaPoKolima2 = Masa2 * VozarinskiStav1 * KolKoef / 1000
                                    PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef * 0.3
                                    bZaokruziNaDeseteNavise(PrevozninaPoKolima2)

                                    PrevozninaPoKolima = PrevozninaPoKolima1
                                    If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                        PrevozninaPoKolima = PrevozninaPoKolima2
                                    End If

                            End Select


                            ' zaokruzivanje?
                            ' zaokruzivanje na 0.10 e
                            ' bzaokruzina desetenavise(prevozninapokolima)
                        End If

                    ElseIf ((IzborSaobracaja = 2) Or (IzborSaobracaja = 3)) Then ' UVOZ, IZVOZ

                        Dim DoTona As String = "45"

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

                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                    End If

                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima

                End If

                Prevoznina = Prevoznina + PrevozninaPoKolima

            Next    ' petlja po kolima


        End If


    End Sub                                     ' 11CO   


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

            Dim bSaobracaj As Integer
            If bValuta = "72" Then
                bSaobracaj = 1
            ElseIf bValuta = "17" Then
                bSaobracaj = 2
            End If

            Dim bRetValLok As String = ""

            bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

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
End Module
