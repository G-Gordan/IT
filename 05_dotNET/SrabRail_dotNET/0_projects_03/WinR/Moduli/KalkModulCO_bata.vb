Imports System.Data.SqlClient
Module KalkModulCO
    Public SpecijalniHCD As Boolean = False
    Public sqlVlasnistvoKola As String = ""

    Public Sub bNadjiPrevozninuCO()

        Dim bKolKoef, bPrevKoef As Decimal
        Dim PV As String

        '------------ RID --------------
        mNizRidCo(0) = "720221"
        mNizRidCo(1) = "280110"
        mNizRidCo(2) = "280700"
        mNizRidCo(3) = "280800"
        mNizRidCo(4) = "281129"
        mNizRidCo(5) = "281310"
        mNizRidCo(6) = "283711"
        mNizRidCo(7) = "284910"
        mNizRidCo(8) = "290250"
        mNizRidCo(9) = "290321"
        mNizRidCo(10) = "290712"
        mNizRidCo(11) = "291611"
        mNizRidCo(12) = "291612"
        mNizRidCo(13) = "291614"
        mNizRidCo(14) = "293100"
        mNizRidCo(15) = "390311"
        '-------------------------------

        SpecijalniHCD = False

        ' ZA UVOZ-IZVOZ:

        ' bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
        ' prvo se vidi da li je preko luke Bar ili za/iz HSH i ŽCG - procedura bDaLiJeBarIHSH(DaNe)
        ' za "obican" uvoz i izvoz tabela je 122
        ' za luku Bar, HSH i ŽCG tabela je 161

        DaLiJeSpecijalniHCD(mBrojUg, SpecijalniHCD)

        If Microsoft.VisualBasic.Right(mBrojUg, 2) = "00" Then
            If IzborSaobracaja = "4" Then              'TRANZIT
                If Not (bKontejneri) Then
                    bNadjiPrevozninu00CO(mPrevoznina)  'CoAneksi OK
                Else
                    bNadjiPrevozninuKontCO(mPrevoznina)
                End If
            Else
                If Not (bKontejneri) Then
                    mTabelaCena = "122"
                    bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina) 'CoAneksi OK
                Else
                    bNadjiPrevozninuKontCO(mPrevoznina)
                End If
            End If

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "67" Then 'sporazum 767; isto kao TEA, sa drugom tabelom 
            bValuta = "17"
            If Not (bKontejneri) Then
                mTabelaCena = "767"
                bNadjiPrevozninuTEA(mTabelaCena, mPrevoznina)
            Else
                mTabelaCena = "134"
                bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
            End If

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "02" Then
            If IzborSaobracaja = "4" Then
                bNadjiPrevozninu02CO(mPrevoznina) 'CoAneksi OK
            Else
                mTabelaCena = "122"
                bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
            End If

        ElseIf ((Microsoft.VisualBasic.Right(mBrojUg, 2) = "01") Or _
                (Microsoft.VisualBasic.Right(mBrojUg, 2) = "33") Or _
                (Microsoft.VisualBasic.Right(mBrojUg, 2) = "44") Or _
                (Microsoft.VisualBasic.Right(mBrojUg, 2) = "66") Or _
                (Microsoft.VisualBasic.Right(mBrojUg, 2) = "96") Or _
                (Microsoft.VisualBasic.Right(mBrojUg, 2) = "97") Or _
                (Microsoft.VisualBasic.Right(mBrojUg, 2) = "04") Or _
                (Microsoft.VisualBasic.Right(mBrojUg, 2) = "73")) Then

            If IzborSaobracaja = "4" Then
                bNadjiPrevozninu01CO(mPrevoznina) 'CoAneksi OK
            Else
                mTabelaCena = "122"
                bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina) 'CoAneksi OK
            End If

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "05" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "06" Then
            bNadjiPrevozninu05COUI(mTabelaCena, mPrevoznina)

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" Or _
               Microsoft.VisualBasic.Right(mBrojUg, 2) = "93" Then 'TEA+TEA prazna kola za ug. 160993
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

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "22" Or _
               mBrojUg = "301523" Or mBrojUg = "301524" Or _
               mBrojUg = "301123" Or mBrojUg = "301124" Or _
               mBrojUg = "301223" Or mBrojUg = "301224" Or _
               mBrojUg = "301323" Or mBrojUg = "301324" Or _
               mBrojUg = "301423" Or mBrojUg = "301424" Or _
               mBrojUg = "301423" Or mBrojUg = "301524" Or _
               Microsoft.VisualBasic.Right(mBrojUg, 2) = "42" Then

            bNadjiPrevozninu22CO(mPrevoznina) 'CoAneksi OK

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "68" Then                       ' jug-sever gvozdje i vino!
            bNadjiPrevozninu00CO(mPrevoznina) 'ok

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "69" Then                       ' jug-sever
            bNadjiPrevozninu00CO(mPrevoznina) 'ok
        ElseIf mBrojUg = "011470" Or mBrojUg = "011471" Or mBrojUg = "011472" Or _
               mBrojUg = "011570" Or mBrojUg = "011571" Or mBrojUg = "011572" Then
            bNadjiPrevozninu01CO(mPrevoznina) 'CoAneksi OK

            'ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "70" Then                       ' jug-sever grupe kola iskljuceno 2014 zbog 011470=voz
            '    bNadjiPrevozninu00CO(mPrevoznina) 'ok

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "11" Then
            If IzborSaobracaja <> "4" Then mTabelaCena = "122"
            bNadjiPrevozninu11CO(mPrevoznina) 'CoAneksi OK

        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "12" Then                       ' revizija praznih kola
            bNadjiPrevozninu12CO(mPrevoznina)

        ElseIf mBrojUg = "301099" Or mBrojUg = "301199" Or mBrojUg = "301299" Then                                                                      ' Militzer
            bNadjiPrevozninuMil99(mPrevoznina) 'CoAneksi OK

        ElseIf mBrojUg = "301198" Or mBrojUg = "301298" Then
            'If IzborSaobracaja = "4" Then
            '    bNadjiPrevozninu02CO(mPrevoznina) 'CoAneksi OK
            'Else
            '    mTabelaCena = "122"
            '    bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
            'End If

            'Militzer uvoz/izvoz
            mTabelaCena = "122"
            bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
        End If



        'If SpecijalniHCD Then
        '    bNadjiPrevozninuSpecHCD(mBrojUg, mPrevoznina)  'Specijalni, "HARDKODIRANI"

        'Else
        '    If Microsoft.VisualBasic.Right(mBrojUg, 2) = "00" Then
        '        If IzborSaobracaja = "4" Then              'TRANZIT
        '            If Not (bKontejneri) Then
        '                bNadjiPrevozninu00CO(mPrevoznina)  'CoAneksi OK
        '            Else
        '                bNadjiPrevozninuKontCO(mPrevoznina)
        '            End If
        '        Else
        '            If Not (bKontejneri) Then
        '                mTabelaCena = "122"
        '                bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina) 'CoAneksi OK
        '            Else
        '                bNadjiPrevozninuKontCO(mPrevoznina)
        '            End If
        '        End If

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "67" Then 'sporazum 767; isto kao TEA, sa drugom tabelom 
        '        bValuta = "17"
        '        If Not (bKontejneri) Then
        '            mTabelaCena = "767"
        '            bNadjiPrevozninuTEA(mTabelaCena, mPrevoznina)
        '        Else
        '            mTabelaCena = "134"
        '            bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
        '        End If

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "02" Then
        '        If IzborSaobracaja = "4" Then
        '            bNadjiPrevozninu02CO(mPrevoznina) 'CoAneksi OK
        '        Else
        '            mTabelaCena = "122"
        '            bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina)
        '        End If

        '    ElseIf ((Microsoft.VisualBasic.Right(mBrojUg, 2) = "01") Or _
        '            (Microsoft.VisualBasic.Right(mBrojUg, 2) = "33") Or _
        '            (Microsoft.VisualBasic.Right(mBrojUg, 2) = "96") Or _
        '            (Microsoft.VisualBasic.Right(mBrojUg, 2) = "97") Or _
        '            (Microsoft.VisualBasic.Right(mBrojUg, 2) = "73")) Then

        '        If IzborSaobracaja = "4" Then
        '            bNadjiPrevozninu01CO(mPrevoznina) 'CoAneksi OK
        '        Else
        '            mTabelaCena = "122"
        '            bNadjiPrevozninu00COUI(mTabelaCena, mPrevoznina) 'CoAneksi OK
        '        End If

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "05" Then
        '        bNadjiPrevozninu05COUI(mTabelaCena, mPrevoznina)

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" Or _
        '           Microsoft.VisualBasic.Right(mBrojUg, 2) = "93" Then 'TEA+TEA prazna kola za ug. 160993
        '        bValuta = "17"
        '        If Not (bKontejneri) Then
        '            If IzborSaobracaja = 4 Then
        '                mTabelaCena = "681"
        '            Else
        '                mTabelaCena = "680"
        '            End If
        '            bNadjiPrevozninuTEA(mTabelaCena, mPrevoznina)
        '        Else
        '            mTabelaCena = "134"
        '            bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
        '        End If

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "22" Or _
        '           mBrojUg = "301023" Or mBrojUg = "301024" Or _
        '           mBrojUg = "301123" Or mBrojUg = "301124" Then
        '        bNadjiPrevozninu22CO(mPrevoznina) 'CoAneksi OK

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "68" Then                       ' jug-sever gvozdje i vino!
        '        bNadjiPrevozninu00CO(mPrevoznina) 'ok

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "69" Then                       ' jug-sever
        '        bNadjiPrevozninu00CO(mPrevoznina) 'ok

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "70" Then                       ' jug-sever grupe kola
        '        bNadjiPrevozninu00CO(mPrevoznina) 'ok

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "11" Then
        '        If IzborSaobracaja <> "4" Then mTabelaCena = "122"
        '        bNadjiPrevozninu11CO(mPrevoznina) 'CoAneksi OK

        '    ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "12" Then                       ' revizija praznih kola
        '        bNadjiPrevozninu12CO(mPrevoznina)

        '    ElseIf mBrojUg = "301099" Or mBrojUg = "301199" Then                                                                      ' Militzer
        '        bNadjiPrevozninuMil99(mPrevoznina) 'CoAneksi OK

        '    End If
        'End If

    End Sub
    Public Sub NadjiVrstu00CO(ByVal inPrelaz1 As String, ByVal inPrelaz2 As String, _
                                        ByVal inOtpravnaUprava As String, ByVal inUputnaUprava As String, _
                                        ByRef outVrsta00Tranzita As Byte)

        outVrsta00Tranzita = 1               'suvozemni

        Select Case inPrelaz1
            Case "14170", "16051", "16871", "21001"
                outVrsta00Tranzita = 2       'recni
        End Select

        Select Case inPrelaz2
            Case "14170", "16051", "16871", "21001"
                outVrsta00Tranzita = 2       'recni
        End Select

    End Sub

    Public Sub bNadjiPrevozninu00CO(ByRef Prevoznina As Decimal)

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim RedniBroj As Int32 = 1
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
        Dim DoTona As String = "45"


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
                Tabela = mTabelaCena 'Tabela = "181"
            ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "70" Then
                Tabela = mTabelaCena 'Tabela = "193"
            Else
                Tabela = mTabelaCena
            End If
        ElseIf bVrsta00tranzita = 2 Then              ' recni
            mTabelaCena = "172"
            Tabela = "172"
            'ElseIf bVrsta00tranzita = 3 Then         ' morski itd.
            '    Tabela = "???"
        End If

        Prevoznina = 0
        bRedovanOrocen = "R"

        If dtKola.Rows.Count > 0 Then
            'RedniBroj = 0
            ''Dim KolaNhm As DataRow
            ''For Each KolaNhm In dtNhm.Rows
            ''    _mNHM = KolaNhm.Item("NHM")
            ''Next

            For Each KolaRed In dtKola.Rows    ' petlja po kolima 

                IBK = KolaRed.Item("IndBrojKola")
                Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                TipKola = KolaRed.Item("Tip")
                Vlasnistvo = KolaRed.Item("Vlasnik")
                BrOsovina = KolaRed.Item("Osovine")

                If Vrsta = "O" Then Vrsta = 1
                If Vrsta = "S" Then Vrsta = 2

                If TipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If

                If Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Then
                    TovarenaPrazna = "TK"
                End If

                bValuta = "17"

                bProveri8606(_mNHM, bNHM8606, bNHMKao8606)

                If (bNHM8606 Or bNHMKao8606) Then
                    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                           "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                           bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                Else
                    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                           TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                           bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                End If


                Dim TabelaTemp As String
                Dim KolKoefTemp, StavKoefTemp, PrevKoefTemp As Decimal

                If Vrsta = "O" Then Vrsta = 1
                If Vrsta = "S" Then Vrsta = 2

                bNadjiKolPrevKoef(mBrojUg, "0", Vrsta, Vlasnistvo, TovarenaPrazna, "00", "00", bPrevozninaKoef, PV)

                KolKoef = 1
                bStavKoef = 1
                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)
                If Microsoft.VisualBasic.Left(mBrojUg, 4) = "1012" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "1112" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "1212" Or _
                   Microsoft.VisualBasic.Left(mBrojUg, 4) = "1013" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "1113" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "1213" Then
                    If Microsoft.VisualBasic.Left(KolaRed.Item("Serija"), 1) = "H" Then
                        KolKoef = 1
                    End If
                End If

                If KolKoef = 0 Then KolKoef = 1

                TabelaTemp = Tabela
                KolKoefTemp = KolKoef
                StavKoefTemp = bStavKoef

                bNadjiUgKoef(mBrojUg, bVrstaSaobracaja, "N", PrevKoefTemp, PV) '!!!inReka

                If Not (PV = "") Then
                    Tabela = TabelaTemp
                    KolKoef = KolKoefTemp
                    bStavKoef = StavKoefTemp
                End If

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
                            RacMasaPoKolima = RacMasaPoKolima + MasaTemp
                        End If
                    Next
                End If

                If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "10" Or _
                    Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "11" Or _
                    Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "12" Or _
                    Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "13" Or _
                    Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "14" Or _
                    Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "15" Then
                    Razred = "0"
                End If

                bZaokruziMasuNa100k(RacMasaPoKolima)
                bZaokrMasuNaOsovineP(RacMasaPoKolima, TovarenaPrazna, BrOsovina, RacMasaPoKolima)

                PrevozninaPoKolima = 0

                Dim _mBrojUg As String
                Dim _razred1 As String = "1"
                Dim _razred2 As String = "2"
                Dim _razred3 As String = "3"


                If Tabela = "173" Then            ' ****00
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

                    'prodos 2014?
                    If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "10" Or _
                       Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "11" Or _
                       Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "12" Or _
                       Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "13" Or _
                       Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "14" Or _
                       Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "15" Then      '#nesa#

                        Select Case RacMasaPoKolima
                            Case 10000, 15000, 20000, 25000, 30000, 35000, 40000, 45000
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

                                If (RacMasaPoKolima > 25000) And (RacMasaPoKolima < 30000) Then
                                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 25000, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav1, PV)
                                    '&&&
                                    If VozarinskiStav1 = 0 Then
                                        bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 25000, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav1, PV)
                                    End If
                                    '&&&

                                    Masa2 = 30000
                                End If


                                If (RacMasaPoKolima > 30000) And (RacMasaPoKolima < 35000) Then
                                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 30000, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav1, PV)
                                    '&&&
                                    If VozarinskiStav1 = 0 Then
                                        bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 30000, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav1, PV)
                                    End If
                                    '&&&

                                    Masa2 = 35000
                                End If

                                If (RacMasaPoKolima > 35000 And RacMasaPoKolima < 40000) Then
                                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, 15000, bTkm, Razred, VozarinskiStav1, PV)
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 35000, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav1, PV)
                                    '&&&
                                    If VozarinskiStav1 = 0 Then
                                        bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 35000, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav1, PV)
                                    End If
                                    '&&&

                                    Masa2 = 40000
                                End If

                                If (RacMasaPoKolima > 40000 And RacMasaPoKolima < 45000) Then
                                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, 15000, bTkm, Razred, VozarinskiStav1, PV)
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 40000, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav1, PV)
                                    '&&&
                                    If VozarinskiStav1 = 0 Then
                                        bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 40000, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav1, PV)
                                    End If
                                    '&&&

                                    Masa2 = 45000
                                End If

                                If (RacMasaPoKolima > 45000) Then
                                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, 15000, bTkm, Razred, VozarinskiStav1, PV)
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 45000, mStanica1, mStanica2, ProdosUprava, "0", Razred, VozarinskiStav1, PV)
                                    '&&&
                                    If VozarinskiStav1 = 0 Then
                                        bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, 45000, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav1, PV)
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
                                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, Masa2, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav2, PV)
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
                        ' 8605, 8606


                        If (Microsoft.VisualBasic.Left(_mNHM, 4) = "8604" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "8605" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "8606" Or _
                            Microsoft.VisualBasic.Left(_mNHM, 4) = "9921" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "9922") And _
                            Microsoft.VisualBasic.Right(mBrojUg, 2) = "00" And _
                            Vlasnistvo = "P" Then

                            Dim bMasa As Integer = 0
                            If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "11" Or Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "12" Or _
                               Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "13" Or Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "14" Then 'GODINA
                                If BrOsovina = 2 Then
                                    bMasa = 25000
                                ElseIf BrOsovina = 4 Then
                                    bMasa = 45000
                                End If
                            Else
                                bMasa = 45000
                            End If

                            bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, bMasa, mStanica1, mStanica2, "00", "0", Razred, VozarinskiStav2, PV)

                            RacMasaPoKolima = NHMRed.Item("Masa")
                            KolKoef = 1 ' bilo Mandic, Slavica: 0.7  bilo : ' UG CO Cl. 2 tac.10 ; bilo: NHMKolKoef = 1
                            bStavKoef = 1
                            bZaokruziMasuNa100k(RacMasaPoKolima)

                            PrevozninaPoKolima = RacMasaPoKolima * VozarinskiStav2 * KolKoef / 1000
                            bVozarinskiStavPoKolima = VozarinskiStav2
                            bRacunskaMasaPoKolima = RacMasaPoKolima

                        End If
                        ' 8605, 8606
                        bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    End If
                ElseIf Tabela = "181" Then  ' ****69

                    If BrOsovina = 2 Then
                        _razred1 = "1"
                    Else
                        _razred1 = "2"
                    End If

                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "00", "0", _razred1, VozarinskiStav, PV)
                    If PV = "" And VozarinskiStav = 0 Then
                        bNadjiVozarinskiStavCO("000000", Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "00", "0", _razred1, VozarinskiStav, PV)
                    End If

                    If Vlasnistvo = "P" And _razred1 = "2" Then KolKoef = 0.9
                    If Vlasnistvo = "Z" And Vrsta = 2 Then KolKoef = 1

                    PrevozninaPoKolima = bStavKoef * VozarinskiStav * KolKoef
                    bRacunskaMasaPoKolima = RacMasaPoKolima ' zbog nevazenja ugovora

                    bVozarinskiStavPoKolima = VozarinskiStav
                ElseIf Tabela = "193" Then  '  ****70
                    If BrOsovina = 2 Then
                        _razred1 = "1"
                    Else
                        _razred1 = "2"
                    End If

                    bNadjiVozarinskiStavCO(mBrojUg, Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "00", "0", _razred1, VozarinskiStav, PV)
                    If PV = "" And VozarinskiStav = 0 Then
                        bNadjiVozarinskiStavCO("000000", Tabela, mDatumKalk, MasaTemp, mStanica1, mStanica2, "00", "0", _razred1, VozarinskiStav, PV)
                    End If

                    If Vlasnistvo = "P" Then KolKoef = 0.9

                    PrevozninaPoKolima = bStavKoef * VozarinskiStav * KolKoef
                    bRacunskaMasaPoKolima = RacMasaPoKolima ' zbog nevazenja ugovora

                    bVozarinskiStavPoKolima = VozarinskiStav
                ElseIf Tabela = "161" Then  '  Izvoz / uvoz ZS - luka Bar/HSH
                    bNadjiPrevozninu00COUI(Tabela, PrevozninaPoKolima)
                End If


                ' * * * * *  ANEKS  * * * * *

                Dim ugUslovZaStav As Integer
                Dim ugCena As Decimal
                Dim ugTipCene As Integer
                Dim ugRetVal As String = ""
                Dim ugDodatak As Decimal
                Dim ugKoeficijent As Decimal
                Dim NHMTemp As String
                Dim Stitna As String
                Dim StvarnaMasaPoKolima As Decimal = 0
                Dim tmpMasa As Int32
                Dim outStav As String

                Stitna = KolaRed.Item("Stitna")

                If Stitna = "N" Then Stitna = "1"
                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        StvarnaMasaPoKolima = StvarnaMasaPoKolima + NHMRed.Item("Masa")
                    End If
                Next
                NHMTemp = dtNhm.Rows(0).Item("NHM")

                '.........................................................
                bNadjiMasuIStavDo45(StvarnaMasaPoKolima, tmpMasa, outStav)
                ugUslovZaStav = CType(outStav, Int32)
                '.........................................................

                ' ************************* Novi AneksCO *******************************

                NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                               BrOsovina, "P", Vlasnistvo, Stitna, _
                               mDatumKalk, 1, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                               ugUslovZaStav, ugCena, ugTipCene, sqlVlasnistvoKola, ugRetVal)

                If ugTipCene = 1 Then                       'procenat na tarifu
                    ugKoeficijent = ugCena
                End If

                If (ugRetVal = "") Then
                    Dim RacMasaZaAneks As Decimal = 0

                    bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)
                    bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                                     RacMasaZaAneks, ugCena, StvarnaMasaPoKolima, _
                                     bTkm, ugDodatak, PrevozninaPoKolima)

                    If Not (ugTipCene = 1) Then
                        bVozarinskiStavPoKolima = ugCena
                    End If
                    bRacunskaMasaPoKolima = RacMasaPoKolima     'zbog nevazenja ugovora
                End If
                ''bRacunskaMasaPoKolima = RacMasaPoKolima 'zbog nevazenja ugovora
                ' ************************* end Novi AneksCO ***************************

                If nmNarPos And RedniBroj <= bNPUkupno Then
                    PrevozninaPoKolima = PrevozninaPoKolima * bNPKoef
                End If

                If Tabela <> "181" And ugTipCene <> 10 Then 'Za Jug-Sever ne vazi min. prevoznina
                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                    End If
                End If

                KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                Prevoznina = Prevoznina + PrevozninaPoKolima
                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        'Dim bNaftaJe As Boolean = False
                        'Dim bDodatakZaNaftu As Decimal
                        Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                        'bDaLiJeNafta(NHMRed.Item("NHM"), bNaftaJe)
                        'If bNaftaJe Then
                        '    bNadjiNaftu(NHMRed.Item("NHM"), bTkm, bDodatakZaNaftu)
                        '    ''''Prevoznina = Prevoznina + bDodatakZaNaftu
                        '    KolaRed.Item("Naknada") = KolaRed.Item("Naknada") + bDodatakZaNaftu
                        'End If
                        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        bZaokruziMasuNa100k(MasaTemp1)
                        If bRacunskaMasaNHM <= MasaTemp1 Then bRacunskaMasaNHM = MasaTemp1
                        If bRacunskaMasaNHM <= BrOsovina * 5000 Then bRacunskaMasaNHM = BrOsovina * 5000

                        NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    End If
                Next
                RedniBroj = RedniBroj + 1
            Next
        End If
    End Sub
    Public Sub bNadjiPrevozninu00COUI(ByVal Tabela As String, ByRef Prevoznina As Decimal)
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, Stitna As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1
        Dim PrevKoef As Decimal = 1
        ''''''''Dim Masa1R, Masa2R, Masa3R As Integer
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
        Dim Prev As Decimal = 0
        Dim RacMasaPoKolima As Integer
        Dim DoTona As String = "25"
        Dim bVrsta00tranzita As Byte
        Dim inReka As String = ""

        Dim bNaftaJe As Boolean = False '20.12.2010
        'Dim mBrutoMasaTmp As Int32 = 0

        Prevoznina = 0
        bRedovanOrocen = "R"

        DoTona = "45"

        If Microsoft.VisualBasic.Right(mBrojUg, 2) = "01" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "02" Then
            NadjiVrstu00CO(mStanica1, mStanica2, mOtpUprava, mPrUprava, bVrsta00tranzita)
            If bVrsta00tranzita = 1 Then
                inReka = "N"
            ElseIf bVrsta00tranzita = 2 Then
                inReka = "D"
            End If
            '***SQL
            bNadjiUgKoef(mBrojUg, IzborSaobracaja, inReka, KolKoef, PV)
        End If

        If dtKola.Rows.Count > 0 Then

            'For Each KolaRed In dtKola.Rows
            '    mBrutoMasaTmp = mBrutoMasaTmp + KolaRed.Item("Tara")
            'Next
            'For Each NHMRed In dtNhm.Rows
            '    mBrutoMasaTmp = mBrutoMasaTmp + NHMRed.Item("Masa")
            'Next
            Dim _tmpBrojac As Int32 = 1

            For Each KolaRed In dtKola.Rows

                IBK = KolaRed.Item("IndBrojKola")
                Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                TipKola = KolaRed.Item("Tip")
                Vlasnistvo = KolaRed.Item("Vlasnik")
                BrOsovina = KolaRed.Item("Osovine")

                If BrOsovina = 2 Then
                    DoTona = "25"
                Else
                    DoTona = "45"
                End If

                Stitna = KolaRed.Item("Stitna")

                If Vrsta = "O" Then Vrsta = 1
                If Vrsta = "S" Then Vrsta = 2

                If TipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If
                If Microsoft.VisualBasic.Left(_mNHM, 4) = "9941" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Then
                    TovarenaPrazna = "TK"
                End If

                '***SQL WinRoba
                bProveri8606(_mNHM, bNHM8606, bNHMKao8606)

                If (bNHM8606 Or bNHMKao8606) Then
                    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                    "TK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                    bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                    'bilo "PK" 4/11/2014 Djaja

                Else
                    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                           TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                           bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                End If



                pubSerijaKola = KolaRed.Item("Serija") '## T kola
                pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola

                '***SQL WinRobaCene
                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)
                'KolKoef = 1


                'If Microsoft.VisualBasic.Left(mBrojUg, 4) = "1012" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "1112" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "1212" Or _
                '   Microsoft.VisualBasic.Left(mBrojUg, 4) = "1013" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "1113" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "1213" Then
                '    If Microsoft.VisualBasic.Left(KolaRed.Item("Serija"), 1) = "H" Then
                '        KolKoef = 1
                '    End If
                'End If


                Dim KPK As Decimal = 1

                '***SQL WinRoba
                bNadjiKolPrevKoef(mBrojUg, TipKola, "0", "0", "00", "00", "00", KPK, PV)
                'KPK = 0.7

                If PV = "" Then KolKoef = KPK

                If dtNhm.Rows.Count > 0 Then
                    Masa1R = 0
                    Masa2R = 0
                    Masa3R = 0
                    Prev1R = 0
                    Prev2R = 0
                    Prev3R = 0

                    For Each NHMRed In dtNhm.Rows
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            NHMTemp = NHMRed.Item("NHM")
                            Nhm8606 = NHMRed.Item("NHM")
                            MasaTemp = NHMRed.Item("Masa")
                            Razred = NHMRed.Item("R")
                            Select Case Razred  'grupisanje po razredima
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

                    If Microsoft.VisualBasic.Right(mBrojUg, 2) = "01" Or _
                       Microsoft.VisualBasic.Right(mBrojUg, 2) = "02" Then
                        bDaLiJeNafta(dtNhm.Rows(0).Item("NHM"), bNaftaJe)
                        If bNaftaJe = False Then '20.12.2010
                            TonskiStav = "45"
                        Else
                            bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, DoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                        End If
                    Else
                        bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, DoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                    End If

                    ' ----------------------------------------- 8605, 8606 -------------------------------------------
                    If (Microsoft.VisualBasic.Left(_mNHM, 4) = "8604" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "8605" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "8606") And _
                        (Microsoft.VisualBasic.Right(mBrojUg, 2) = "00" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "01" Or _
                         Microsoft.VisualBasic.Right(mBrojUg, 2) = "02") Then

                        'meša racunske mase?! iskljuceno 29.3.2013
                        'Masa1R = NHMRed.Item("Masa")
                        'Masa2R = 0
                        'Masa3R = 0
                        'bZaokruziMasuNa100k(Masa1R)

                        If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "11" Then '2011
                            If BrOsovina = 2 Then
                                TonskiStav = "25"
                            ElseIf BrOsovina = 4 Then
                                TonskiStav = "45"
                            End If
                        Else
                            'TonskiStav = "45"  1.11.2011: CO 091100, Èl.12 !!
                            'If BrOsovina = 2 Then
                            '    TonskiStav = "25"
                            'ElseIf BrOsovina = 4 Then
                            '    TonskiStav = "45"
                            'End If

                            TonskiStav = "45"
                        End If

                        KolKoef = 1 'bilo: 0.7 Slavica 19/3/2014; bilo: 1 'Cl 2, tac. 10  KolKoef = 1

                    End If
                    ' --------------------------------------- end 8605, 8606 ------------------------------------------


                    TonskiStavInteger = CType(TonskiStav, Integer)
                    MasaTemp = TonskiStavInteger * 1000

                    ' prevoznine po razredima:

                    'Dodatak zbog datuma vazenja Prodosa i ostalih ugovora

                    Dim temp_DatumUI As Date = mDatumKalk

                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "1", VozarinskiStav, PV)
                    '***SQL
                    bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "1", VozarinskiStav, PV)
                    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    ' zaokruzivanje?
                    If Not (Masa1R = 0) Then
                        bVozarinskiStavPoKolima = VozarinskiStav
                    End If

                    Prev1R = Prev1R * bPrevozninaKoef


                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "2", VozarinskiStav, PV)
                    '***SQL
                    If Masa2R > 0 Then
                        bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "2", VozarinskiStav, PV)
                        Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                        ' zaokruzivanje?
                        If Not (Masa2R = 0) And (Masa1R = 0) Then
                            bVozarinskiStavPoKolima = VozarinskiStav
                        End If
                        Prev2R = Prev2R * bPrevozninaKoef
                    End If


                    'bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "3", VozarinskiStav, PV)
                    '***SQL
                    If Masa3R > 0 Then
                        bNadjiVozarinskiStavkmCO("000000", Tabela, mDatumKalk, MasaTemp, bTkm, "0", "0", "3", VozarinskiStav, PV)
                        Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                        ' zaokruzivanje?
                        If Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0) Then
                            bVozarinskiStavPoKolima = VozarinskiStav
                        End If

                        Prev3R = Prev3R * bPrevozninaKoef

                    End If

                    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

                    'zaokruzivanje na 0.10 ...
                    ''Dim bNaftaJe As Boolean = False izmena 20.12.2010
                    bNadjiPrevKoefCOUI(PrevKoef)

                    bDaLiJeNafta(dtNhm.Rows(0).Item("NHM"), bNaftaJe)
                    If bNaftaJe = True Then
                        PrevKoef = 1
                    End If

                    PrevozninaPoKolima = PrevozninaPoKolima * PrevKoef
                    bZaokruziNaDeseteNavise(PrevozninaPoKolima)

                    ' Testiraj na minimalnu prevozninu
                    RacMasaPoKolima = Masa1R + Masa2R + Masa3R
                    bRacunskaMasaPoKolima = RacMasaPoKolima

                    'vracanje datuma
                    mDatumKalk = temp_DatumUI


                    ' * * * * *  ANEKS  * * * * *
                    Dim ugUslovZaStav As Integer = TonskiStavInteger
                    Dim ugCena As Decimal
                    Dim ugTipCene As Integer
                    Dim ugRetVal As String = ""
                    Dim ugDodatak As Decimal
                    Dim ugKoeficijent As Decimal
                    Dim StvarnaMasaPoKolima As Decimal = 0
                    Dim tmpMasa As Int32
                    Dim outStav As String
                    Dim rvco As String
                    Dim RacMasaZaAneks As Decimal

                    ' $#$#$#$#$
                    Dim outStav86 As String
                    ' $#$#$#$#$

                    If mVrstaPrevoza = "V" Then
                        nmBMV = nmBMV
                    Else
                        nmBMV = 1
                    End If

                    NHMTemp = dtNhm.Rows(0).Item("NHM")

                    Stitna = KolaRed.Item("Stitna")
                    If Stitna = "N" Then Stitna = "1"

                    For Each NHMRed In dtNhm.Rows
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            StvarnaMasaPoKolima = StvarnaMasaPoKolima + NHMRed.Item("Masa")
                        End If
                    Next
                    '.........................................................
                    bNadjiMasuIStavDo45(StvarnaMasaPoKolima, tmpMasa, outStav)

                    ' $#$#$#$#$ Dodato formalno za probu 
                    outStav86 = outStav

                    If tmpMasa <= 5000 * BrOsovina Then
                        tmpMasa = 5000 * BrOsovina
                    End If
                    bNadjiMasuIStavDo45(tmpMasa, tmpMasa, outStav)   ' samo da bi se dobila sifra stava (outStav)
                    ' $#$#$#$#$ Dodato formalno za probu

                    ugUslovZaStav = CType(outStav, Int32)
                    '.........................................................

                    ' ************************* Novi AneksCO *******************************
                    If (Microsoft.VisualBasic.Left(_mNHM, 4) = "8604" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "8605" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "8606") And _
                        (Microsoft.VisualBasic.Right(mBrojUg, 2) = "00" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "01") And _
                        nmNarPos = True Then

                        ugUslovZaStav = CType(outStav86, Int32)
                        TonskiStavInteger = ugUslovZaStav

                    End If

                    NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                                   BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, _
                                   mDatumKalk, nmBMV, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                   ugUslovZaStav, ugCena, ugTipCene, sqlVlasnistvoKola, ugRetVal)

                    '=========================== korekcija aneksa ===============================
                    'ISPRAVITI ODAVDE!!
                    If (ugRetVal = "") Then

                        bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)

                        bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, RacMasaZaAneks, ugCena, _
                                         RacMasaZaAneks, bTkm, ugDodatak, Prev)

                        'ostalo staro dok ne ispravim
                        If ugTipCene = 3 Then '? 2014 And (ugUslovZaStav = TonskiStavInteger)) Then
                            If RTrim(sqlVlasnistvoKola) = "P" Then
                                KolKoef = 1
                            End If

                            VozarinskiStav = ugCena
                            Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            If Not (Masa1R = 0) Then
                                bVozarinskiStavPoKolima = VozarinskiStav
                            End If
                            Prev2R = Prev2R * bPrevozninaKoef

                            Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            If Not (Masa2R = 0) And (Masa1R = 0) Then
                                bVozarinskiStavPoKolima = VozarinskiStav
                            End If
                            Prev2R = Prev2R * bPrevozninaKoef

                            Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            If Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0) Then
                                bVozarinskiStavPoKolima = VozarinskiStav
                            End If
                            Prev3R = Prev3R * bPrevozninaKoef

                            PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!
                            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                            Prev = PrevozninaPoKolima 'mora ovako zbog (***)!

                            ' $#$#$#$#$
                            RacMasaZaAneks = Masa1R + Masa2R + Masa3R
                            ' $#$#$#$#$
                        End If
                        'end

                        PrevozninaPoKolima = Prev '(***)
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

                    If ugTipCene = 5 Or ugTipCene = 15 Then
                        PrevozninaPoKolima = 0
                        Prevoznina = ugCena
                    End If

                    If Not (ugTipCene = 12) Then
                        bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    End If

                    If nmNarPos And _tmpBrojac <= bNPUkupno Then
                        PrevozninaPoKolima = PrevozninaPoKolima * bNPKoef
                    End If

                    If ugTipCene <> 5 And ugTipCene <> 10 And ugTipCene <> 15 Then
                        If PrevozninaPoKolima <= bMinPrevoznina Then
                            PrevozninaPoKolima = bMinPrevoznina
                        End If
                    End If
                    ' ------------- end ostaje dok se ne ispravi


                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                    KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                    Prevoznina = Prevoznina + PrevozninaPoKolima
                    bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                End If

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
                _tmpBrojac = _tmpBrojac + 1
            Next

        Else
            'nema ni kola ni prevoznine
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
        Dim RacunskaMasaPoKolima, VozarinskiStavPoKolima As Decimal
        Dim bABCD As Integer                   ' broj ukupno realizovanih vozova
        Dim BrutoMasa As Decimal
        Dim bPkolKoef As Decimal = 1

        Util.sNadjiNaziv("TabNaziv", mBrojUg, "", "", 1, xNaziv, xPovVrednost)
        mTabelaCena = xNaziv

        PrevozninaPoKolima = 0

        If mBrojUg = "835745" Or mBrojUg = "835758" Or mBrojUg = "844517" Then 'AdriaCombi
            mTabelaCena = "333"
        End If

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
            RacunskaMasaPoKolima = 0

            For Each NHMRed In dtNhm.Rows                                                ' petlja po robi za jedna kola
                If NHMRed.Item("IndBrojKola") = IBK Then
                    MasaTemp = NHMRed.Item("Masa")
                    DuzinaKontTemp = NHMRed.Item("UTI")
                    bNadjiRasterCO(DuzinaKontTemp, MasaTemp, RasterTemp)
                    IzStav = 0
                    RacunskaMasaPoKolima = RacunskaMasaPoKolima + MasaTemp
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
                        ' 2010 IzStav = 135 'cena po UTI
                        If mObrGodina = "2011" Then
                            IzStav = 170 'cena po UTI
                        ElseIf mObrGodina = "2012" Then
                            IzStav = 200 'cena po UTI
                        End If
                    ElseIf mBrojUg = "835758" Then 'AdriaCombi
                        If mObrGodina = "2012" Then
                            IzStav = 305 'cena po UTI
                        ElseIf mObrGodina = "2013" Then
                            If Microsoft.VisualBasic.Left(dtNhm.Rows(0).Item("NHM"), 4) = "9931" Then
                                IzStav = 330 * 0.37  'Tg. 27-2.1.l 4/13-032 7/2/2013
                                bZaokruziNaDeseteNavise(IzStav)
                            Else
                                IzStav = 330         'cena po UTI
                            End If
                        End If
                    ElseIf mBrojUg = "844517" Then 'AdriaCombi
                        If mObrGodina = "2012" Or mObrGodina = "2013" Then
                            IzStav = 345 'cena po UTI
                        End If
                    ElseIf mBrojUg = "931817" Then 'Eurolog
                        IzStav = 2772 'cena po vozu
                    End If

                    PrevozninaZaUTI = IzStav '* RasterTemp

                    bZaokruziMasuNa100k(MasaTemp)
                    NHMRed.Item("RacMasaNHM") = MasaTemp
                    NHMRed.Item("VozarinskiStavNHM") = IzStav 'bVozarinskiStav

                    If mBrojUg = "835745" Or mBrojUg = "835758" Or mBrojUg = "844517" Then 'AdriaCombi
                        PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaZaUTI
                    ElseIf mBrojUg = "931817" Then 'Eurolog
                        PrevozninaPoKolima = 2772 'cena po vozu
                    End If

                End If
            Next


            If mBrojUg = "835758" And Microsoft.VisualBasic.Left(dtNhm.Rows(0).Item("NHM"), 4) = "9931" Then
            Else
                bZaokruziNaCeleNavise(PrevozninaPoKolima)  ' ili na desete?
            End If

            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            Prevoznina = PrevozninaPoKolima
            dtKola.Rows(0).Item("Prevoznina") = Prevoznina
            dtKola.Rows(0).Item("RacunskaMasa") = RacunskaMasaPoKolima
            dtKola.Rows(0).Item("VozarinskiStav") = IzStav

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

        mProcenatBM = 0 'postavlja na nulu


        If Not (bBarIHSH) Then  ' Nije Bar i Albanija

            'bABCD = 2000 'Tumacenje ugovora: uvek vazi cena iz tabele D
            bNadjiBrojRealizovanihVozova(mBrojUg, mStanica1, mStanica2, bABCD, PV)

            If mBrojUg = "100901" Or mBrojUg = "100997" Or mBrojUg = "110901" Or mBrojUg = "120901" Then      '#b#
                bABCD = 2001
            End If                                                                      '#b#

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


            If mOtpUprava = "83" Then 'USLOV ZBOG ITALIJE
                mTabelaCena = "213"
            End If

            'If mMakis = "ZA" Then
            '    mTabelaCena = "212"
            'End If

            'ne treba 10.6.2011

            '?2014: proveriti !!!
            If ((mStanica1 = "16201") Or (mStanica2 = "16201")) Then
                bNadjiBrutoMasu(mBrutoMasaPoPosiljci, bPKolKoef)
                bABCD = mBrutoMasaPoPosiljci / 1000 ' u tonama
                mTabelaCena = "212"
            Else
                bNadjiBrutoMasu(mBrutoMasaPoPosiljci, bPKolKoef)
            End If

            Dim _mNHMInt = CInt(_mNHM)


            If (_mNHMInt = 860500 Or _
                (_mNHMInt >= 860600 And _mNHMInt <= 860699) Or _
                (_mNHMInt >= 992110 And _mNHMInt <= 992140) Or _
                (_mNHMInt >= 992210 And _mNHMInt <= 992240)) And _
                Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "14" And mSumaKola >= 17 And IzborSaobracaja = "4" Then

                bPKolKoef = 1

            End If


            If mBrojUg = "101396" Or mBrojUg = "111396" Or mBrojUg = "121396" Or mBrojUg = "101301" Or mBrojUg = "111301" Or mBrojUg = "121301" Or _
                mBrojUg = "801496" Or mBrojUg = "811496" Or mBrojUg = "801401" Or mBrojUg = "811401" Or _
                mBrojUg = "801596" Or mBrojUg = "811596" Or mBrojUg = "801501" Or mBrojUg = "811501" Then

                If mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X" Then
                    'nema korekcije cene
                Else

                    CoVozoviProcenatZaBM(mBrojUg, mStanica1, mStanica2, CInt(nmBMV), mProcenatBM, rv1)

                    If mProcenatBM > 0 Then 'zbog reklamacije 10.11.2011
                        MsgBox("Prema podacima iz baze primenjuje se uvecanje prevoznine za: " & mProcenatBM.ToString & " % . Proverite podatke.", vbYes + vbInformation, "Poruka: Uvecanje prevoznine")
                    Else
                        mProcenatBM = 0
                    End If
                End If
            End If

            bVozarinskiStav = mPrevoznina

            '-------------------------------------------------------------------------
            bCenaPoVozu00 = 0
            bCenaPoVozuOt = 0
            bCenaPoVozuUp = 0
            '------------ ispitati procenat neto tona za Makedoniju - Samo Prodos!

            Dim TempPrUprava As String

            'and mRucnaNajava <> "D"


            'zbog testa
            'If mRucnaNajava <> "D" Then
            '    If (mBrojUg = "101001" Or mBrojUg = "111001" Or mBrojUg = "121001") Or _
            '                   (mBrojUg = "101101" Or mBrojUg = "111101" Or mBrojUg = "121101") _
            '                   And Not (mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X") Then

            '        Dim PovrVr As String
            '        TempPrUprava = mPrUprava
            '        bNadjiUpravu6573(mBrojUg, mNajava, mObrMesec, mObrGodina, mPrUprava, PovrVr)
            '    End If
            'End If

            ''!!skini!!

            'If Len(mNajava) > 0 Then
            '    If ((mBrojUg = "101001" Or mBrojUg = "111001" Or mBrojUg = "121001") Or _
            '       (mBrojUg = "101101" Or mBrojUg = "111101" Or mBrojUg = "121101") Or _
            '       (mBrojUg = "101201" Or mBrojUg = "111201" Or mBrojUg = "121201") Or _
            '       (mBrojUg = "101301" Or mBrojUg = "111301" Or mBrojUg = "121301")) _
            '       And Not (mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X") Then

            '        Dim PovrVr As String
            '        TempPrUprava = mPrUprava
            '        bNadjiUpravu6573(mBrojUg, mNajava, mObrMesec, mObrGodina, mPrUprava, PovrVr)
            '    End If
            'End If

            '------------ ispitati procenat neto tona za Makedoniju - Samo Prodos!


            bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, "00", "0", "0", bCenaPoVozu00, PV)

            If bCenaPoVozu00 = 0 Then
                bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, mOtpUprava, "0", "0", bCenaPoVozuOt, PV)
            End If
            If bCenaPoVozu00 = 0 And bCenaPoVozuOt = 0 Then
                bNadjiVozarinskiStavCO(mBrojUg, mTabelaCena, mDatumKalk, bABCD, mStanica1, mStanica2, mPrUprava, "0", "0", bCenaPoVozuUp, PV)
            End If



            ''zbog toga jer u tranzitu unose bez najave voza!! 15.11.2011.
            'If mRucnaNajava <> "D" Then
            '    If (mBrojUg = "101001" Or mBrojUg = "111001" Or mBrojUg = "121001") Or _
            '                   (mBrojUg = "101101" Or mBrojUg = "111101" Or mBrojUg = "121101") And _
            '                    Not (mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X") Then

            '        mPrUprava = TempPrUprava

            '    End If
            'End If

            ''!!zbog toga jer u tranzitu unose bez najave voza!! 15.11.2011.
            'If Len(mNajava) > 0 Then
            '    If ((mBrojUg = "101001" Or mBrojUg = "111001" Or mBrojUg = "121001") Or _
            '       (mBrojUg = "101101" Or mBrojUg = "111101" Or mBrojUg = "121101") Or _
            '       (mBrojUg = "101201" Or mBrojUg = "111201" Or mBrojUg = "121201") Or _
            '       (mBrojUg = "101301" Or mBrojUg = "111301" Or mBrojUg = "121301")) And _
            '        Not (mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X") Then

            '        mPrUprava = TempPrUprava
            '    End If
            'End If

            If Not (bCenaPoVozu00 = 0) Then
                mPrevoznina = bCenaPoVozu00
            ElseIf Not (bCenaPoVozuOt = 0) Then
                mPrevoznina = bCenaPoVozuOt
            ElseIf Not (bCenaPoVozuUp = 0) Then
                mPrevoznina = bCenaPoVozuUp
            End If

            If mBrojUg = "101396" Or mBrojUg = "111396" Or mBrojUg = "121396" Or mBrojUg = "101301" Or mBrojUg = "111301" Or mBrojUg = "121301" Or _
               mBrojUg = "801496" Or mBrojUg = "811496" Or mBrojUg = "801401" Or mBrojUg = "811401" Then

                If mNajava.Substring(1, 1) = "X" Or Left(mNajava, 1) = "X" Then
                    'nema korekcije cene
                Else
                    mPrevoznina = mPrevoznina * (1 + mProcenatBM / 100)
                    '''bZaokruziNaCeleNavise(mPrevoznina)
                End If
            End If


            mPrevoznina = mPrevoznina * bPKolKoef ' cl.11 0.7 P kola

            bZaokruziNaCeleNavise(mPrevoznina)

            bVozarinskiStav = mPrevoznina
            bVozarinskiStavPoKolima = bVozarinskiStav       'formalno


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
            bVozarinskiStavPoKolima = bVozarinskiStav
        End If

        ' ------------------------- Upis racunske mase i vozarinskog stava po robi -------------------------
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK As String
        Dim MasaTemp As Integer


        ' * * * * *  ANEKS  * * * * *
        For Each KolaRed In dtKola.Rows    ' petlja po kolima
            Dim Vlasnistvo As String = KolaRed.Item("Vlasnik")
            Dim Stitna As String = KolaRed.Item("Stitna")
            Dim NHMTemp As String
            Dim ugUslovZaStav As Integer = 1
            Dim ugCena As Decimal
            Dim ugTipCene As Integer
            Dim ugRetVal As String
            Dim RacMasaZaAneks As Decimal
            Dim Prev As Decimal = 0
            Dim ugDodatak As Decimal = 0
            Dim ugKoeficijent As Decimal = 0
            Dim PrevozninaPoKolima As Decimal

            IBK = KolaRed.Item("IndBrojKola")
            Dim BrOsovina As Integer = KolaRed.Item("Osovine")
            '======================================================================
            'Dim bRacunskaMasaNHM As Decimal = 0 ''!!bRacunskaMasaPoKolima 'nije dobro, kod 481101 sm i rm su pomerene za 1 red !!
            bRacunskaMasaPoKolima = 0
            For Each NHMRed In dtNhm.Rows
                Dim bRacunskaMasaNHM As Decimal = 0
                If NHMRed.Item("IndBrojKola") = IBK Then
                    'Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                    NHMTemp = NHMRed.Item("NHM")

                    '' -- CO Nafta
                    'Dim bNaftaJe As Boolean = False
                    'Dim bDodatakZaNaftu As Decimal
                    'bDaLiJeNafta(NHMRed.Item("NHM"), bNaftaJe) 'if saobracaj="4" !!!
                    'If bNaftaJe Then
                    '    bNadjiNaftu(NHMRed.Item("NHM"), bTkm, bDodatakZaNaftu)
                    '    Prevoznina = Prevoznina + bDodatakZaNaftu
                    'End If
                    '' -- end CO Nafta


                    ' ************************* Novi AneksCO *******************************

                    If Stitna = "N" Then Stitna = "1"
                    NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                                   BrOsovina, "V", Vlasnistvo, Stitna, _
                                   mDatumKalk, CType(nmBMV, Int32), Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                   ugUslovZaStav, ugCena, ugTipCene, sqlVlasnistvoKola, ugRetVal)

                    ' ************************* end Novi AneksCO ***************************


                    'If mBrojUg = "651301" Then
                    '    'ANEKS broj 1: aneks važi za obicna kola u vozu, inace redovan ugovor
                    '    'promenljiva Stitna treba da bude vezano još i za obicna ili specijalna kola

                    'End If

                    'nova cena po aneksu, ide u korekciju aneksa
                    Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                    bZaokruziMasuNa100k(MasaTemp1)

                    If bRacunskaMasaNHM <= MasaTemp1 Then bRacunskaMasaNHM = MasaTemp1
                    If Microsoft.VisualBasic.Right(mBrojUg, 2) <> "33" And Microsoft.VisualBasic.Right(mBrojUg, 2) <> "44" Then 'Radojka-"ne treba to meni" 08.12.2011
                        If bRacunskaMasaNHM <= BrOsovina * 5000 Then bRacunskaMasaNHM = BrOsovina * 5000
                    End If
                    If (ugRetVal = "") Then bVozarinskiStavPoKolima = ugCena

                    '=========================== korekcija aneksa ===============================
                    If (ugRetVal = "") Then

                        bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)

                        bKorigujPoAneksu(ugTipCene, Prev, ugKoeficijent, _
                                         RacMasaZaAneks, ugCena, _
                                         RacMasaZaAneks, bTkm, ugDodatak, Prev)

                        PrevozninaPoKolima = Prev
                        bVozarinskiStavPoKolima = ugCena

                        '-------------- novo: 10/03/2014
                        If ugTipCene = 5 Or ugTipCene = 14 Or ugTipCene = 15 Then
                            mPrevoznina = PrevozninaPoKolima
                        Else
                            mPrevoznina = mPrevoznina + PrevozninaPoKolima
                        End If

                        bRacunskaMasaPoKolima = RacMasaZaAneks
                    End If
                    '========================= end korekcija aneksa =============================
                    NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                    NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + bRacunskaMasaNHM

                End If ' dodato ovde
            Next
            KolaRed.Item("Prevoznina") = mPrevoznina
            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
        Next

    End Sub
    Public Sub bNadjiPrevozninu02CO(ByRef Prevoznina As Decimal)  ' grupa kola

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1
        Dim Masa As Integer
        Dim MasaTemp As Integer
        Dim Razred As String
        Dim TonskiStav As String
        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim TonskiStavInteger As Integer
        Dim PrevozninaPoKolima As Decimal = 0
        Dim RacMasaPoKolima As Integer
        Dim Tabela As String
        Dim bVrsta00tranzita As Byte = 1
        Dim ProdosUprava As String = "00"
        Dim NHMTemp As String

        Prevoznina = 0
        bRedovanOrocen = "R"

        If dtKola.Rows.Count > 0 Then

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

            For Each KolaRed In dtKola.Rows
                IBK = KolaRed.Item("IndBrojKola")
                Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                TipKola = KolaRed.Item("Tip")
                Vlasnistvo = KolaRed.Item("Vlasnik")
                BrOsovina = KolaRed.Item("Osovine")

                If Vrsta = "O" Then Vrsta = 1
                If Vrsta = "S" Then Vrsta = 2

                If TipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If

                If Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Then
                    TovarenaPrazna = "TK"
                End If

                bProveri8606(_mNHM, bNHM8606, bNHMKao8606)
                If (bNHM8606 Or bNHMKao8606) Then
                    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                           "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                           bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                Else
                    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                           TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                           bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                End If


                bNadjiKolPrevKoef(mBrojUg, "0", Vrsta, Vlasnistvo, TovarenaPrazna, "00", "00", bPrevozninaKoef, PV)

                If dtNhm.Rows.Count > 0 Then
                    RacMasaPoKolima = 0
                    For Each NHMRed In dtNhm.Rows
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            Razred = NHMRed.Item("R")
                            RacMasaPoKolima = RacMasaPoKolima + MasaTemp
                        End If
                    Next
                    bZaokruziMasuNa100k(RacMasaPoKolima)
                    bZaokrMasuNaOsovineP(RacMasaPoKolima, TovarenaPrazna, BrOsovina, RacMasaPoKolima)
                    bRacunskaMasaPoKolima = RacMasaPoKolima

                    Dim _razred As String
                    PrevozninaPoKolima = 0

                    If Vlasnistvo = "Z" Then
                        _razred = "1"
                    Else
                        _razred = "2"
                    End If
                    If Microsoft.VisualBasic.Left(_mNHM, 4) = "8605" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "8606" Or _
                       Microsoft.VisualBasic.Left(_mNHM, 4) = "9921" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "9922" Then
                        _razred = "1"
                    End If

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
                        End If
                    Else
                        PrevozninaPoKolima = RacMasaPoKolima * bStavKoef * VozarinskiStav * KolKoef / 1000
                        PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef
                    End If

                    ' * * * * *  ANEKS  * * * * *
                    Vlasnistvo = KolaRed.Item("Vlasnik")
                    Dim Stitna As String = KolaRed.Item("Stitna")
                    'Dim NHMTemp As String
                    Dim ugUslovZaStav As Integer = 1
                    Dim ugCena As Decimal
                    Dim ugTipCene As Integer
                    Dim ugRetVal As String
                    Dim RacMasaZaAneks As Decimal
                    Dim Prev As Decimal = 0
                    Dim ugDodatak As Decimal = 0
                    Dim ugKoeficijent As Decimal = 0
                    NHMTemp = NHMRed.Item("NHM")

                    ' ************************* Novi AneksCO *******************************

                    If Stitna = "N" Then Stitna = "1"
                    NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                                   BrOsovina, "G", Vlasnistvo, Stitna, _
                                   mDatumKalk, 1, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                   ugUslovZaStav, ugCena, ugTipCene, sqlVlasnistvoKola, ugRetVal)

                    ' ************************* end Novi AneksCO ***************************


                    'nova cena po aneksu, ide u korekciju aneksa
                    Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                    bZaokruziMasuNa100k(MasaTemp1)

                    'If (ugRetVal = "") Then bVozarinskiStavPoKolima = ugCena


                    '=========================== korekcija aneksa ===============================
                    If (ugRetVal = "") Then

                        bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)

                        bKorigujPoAneksu(ugTipCene, Prev, ugKoeficijent, _
                                         RacMasaZaAneks, ugCena, _
                                         RacMasaZaAneks, bTkm, ugDodatak, Prev)

                        PrevozninaPoKolima = Prev
                        bVozarinskiStavPoKolima = ugCena
                        'mPrevoznina = PrevozninaPoKolima
                        bRacunskaMasaPoKolima = RacMasaZaAneks
                    End If
                    '========================= end korekcija aneksa =============================
                End If


                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                Prevoznina = Prevoznina + PrevozninaPoKolima
                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        'Dim bNaftaJe As Boolean = False
                        'Dim bDodatakZaNaftu As Decimal
                        Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima

                        'bDaLiJeNafta(NHMRed.Item("NHM"), bNaftaJe)

                        'If bNaftaJe Then
                        '    bNadjiNaftu(NHMRed.Item("NHM"), bTkm, bDodatakZaNaftu)
                        '    Prevoznina = Prevoznina + bDodatakZaNaftu
                        'End If

                        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        bZaokruziMasuNa100k(MasaTemp1)

                        If bRacunskaMasaNHM <= MasaTemp1 Then bRacunskaMasaNHM = MasaTemp1
                        If bRacunskaMasaNHM <= BrOsovina * 5000 Then bRacunskaMasaNHM = BrOsovina * 5000

                        NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    End If
                Next
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


        If dtKola.Rows.Count > 0 Then
            For Each KolaRed In dtKola.Rows
                IBK = KolaRed.Item("IndBrojKola")
                Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                TipKola = KolaRed.Item("Tip")
                Vlasnistvo = KolaRed.Item("Vlasnik")
                BrOsovina = KolaRed.Item("Osovine")

                If Vrsta = "O" Then Vrsta = 1
                If Vrsta = "S" Then Vrsta = 2

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "00", "K", bVrstaStanice, "P", _
                                     "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


                '-----------------------------------------------------------------------------

                If VozarinskiStav <> 0 Then  '  relacija postoji , pa je prema 1.
                    PrevozninaPoKolima = VozarinskiStav
                    bVozarinskiStav = PrevozninaPoKolima

                    'Prodos novi ugovor za 2011.
                    '?2014
                    'If Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1011" Or _
                    '   Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1111" Or _
                    '   Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1211" Or _
                    '   Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1012" Or _
                    '   Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1112" Or _
                    '   Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1212" Or _
                    '   Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1013" Then

                    '    'Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1113" Or _
                    '    'Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1213" Then

                    '    If (mStanica1 = "16517" And mStanica2 = "11028") Or _
                    '       (mStanica1 = "16517" And mStanica2 = "12498") Or _
                    '       (mStanica1 = "11028" And mStanica2 = "16517") Or _
                    '       (mStanica1 = "12498" And mStanica2 = "16517") Or _
                    '       (mStanica1 = "23499" And mStanica2 = "11028") Or _
                    '       (mStanica1 = "23499" And mStanica2 = "12498") Or _
                    '       (mStanica1 = "11028" And mStanica2 = "23499") Or _
                    '       (mStanica1 = "12498" And mStanica2 = "23499") Then

                    '        PrevozninaPoKolima = 0
                    '        bVozarinskiStavPoKolima = 0
                    '        bVozarinskiStav = 0

                    '    End If
                    'End If

                    'Prodos,Senker,Ekspres stari ugovor za 2010.
                    'If Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1010" Or _
                    '   Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1110" Or _
                    '   Microsoft.VisualBasic.Mid(mBrojUg, 1, 4) = "1210" Then

                    '    PrevozninaPoKolima = 0
                    '    bVozarinskiStavPoKolima = 0
                    '    bVozarinskiStav = 0

                    'End If

                Else   'relacija ne postoji, pa je prema 2.

                    If bVrstaSaobracaja = 4 Then 'tranzit
                        Dim bVrsta00tranzita As Byte = 1

                        ' prazna "P" kola - sopstvena masa i prevozni stav 1. razreda tablice za tranzit ( ! )
                        NadjiVrstu00CO(mStanica1, mStanica2, mOtpUprava, mPrUprava, bVrsta00tranzita)

                        ' Vrsta00Tranzita: 1-suvozemni, 2-recni, 3-morski ( preko luke Bar ), ...
                        If bVrsta00tranzita = 1 Then                  ' suvozemni
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

                    ElseIf ((bVrstaSaobracaja = 2) Or (bVrstaSaobracaja = 3)) Then 'UVOZ,IZVOZ

                        Dim DoTona As String = "45"
                        If dtNhm.Rows.Count > 0 Then
                            Masa1R = 0
                            Dim Prev1R As Decimal = 0
                            For Each NHMRed In dtNhm.Rows
                                If NHMRed.Item("IndBrojKola") = IBK Then
                                    MasaTemp = NHMRed.Item("Masa")
                                    Razred = "1" 'NHMRed.Item("R")
                                    Masa1R = MasaTemp
                                End If
                                bZaokruziMasuNa100k(Masa1R)
                            Next

                            PrevozninaPoKolima = 0

                            TonskiStavInteger = CType(DoTona, Integer)
                            MasaTemp = TonskiStavInteger * 1000

                            bNadjiVozarinskiStavkmCO("000000", "122", mDatumKalk, MasaTemp, bTkm, "0", "0", "1", VozarinskiStav, PV)
                            Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                            ' zaokruzivanje?
                            Prev1R = Prev1R * bPrevozninaKoef * 0.3
                            bRacunskaMasaPoKolima = MasaTemp
                            bVozarinskiStavPoKolima = VozarinskiStav
                            VozarinskiStav = 0

                            PrevozninaPoKolima = Prev1R

                            bZaokruziNaDeseteNavise(PrevozninaPoKolima)

                            ' Testiraj na minimalnu prevozninu
                            If PrevozninaPoKolima < bMinPrevoznina Then
                                PrevozninaPoKolima = bMinPrevoznina
                            End If
                            RacMasaPoKolima = Masa1R '  + Masa2R + Masa3R

                        End If
                    End If
                    '---------------------- end
                End If


                ' * * * * *  ANEKS  * * * * *

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
                Dim RacMasaZaAneks As Decimal

                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        StvarnaMasaPoKolima = StvarnaMasaPoKolima + NHMRed.Item("Masa")
                    End If
                Next

                NHMTemp = dtNhm.Rows(0).Item("NHM")

                ' ************************* Novi AneksCO *******************************

                NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                               BrOsovina, mVrstaPrevoza, "P", "1", _
                               mDatumKalk, 1, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                               1, ugCena, ugTipCene, sqlVlasnistvoKola, ugRetVal)

                '=========================== korekcija aneksa ===============================
                If (ugRetVal = "") Then

                    bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)

                    bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                                     RacMasaZaAneks, ugCena, _
                                     RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)

                    '-------------------------------------------
                    bZaokruziNaDeseteNavise(PrevozninaPoKolima)   '  Slavica
                    '-------------------------------------------

                    If Not (ugTipCene = 1) Then
                        bVozarinskiStavPoKolima = ugCena
                    End If
                End If

                If ugTipCene > 0 And ugTipCene <> 10 Then 'minimalna prevoznina
                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                    End If
                End If

                KolaRed.Item("Prevoznina") = PrevozninaPoKolima

                ' ------------------------------
                KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                Prevoznina = Prevoznina + PrevozninaPoKolima
                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        bZaokruziMasuNa100k(MasaTemp1)
                        NHMRed.Item("RacMasaNHM") = MasaTemp1
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    End If
                Next

            Next
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
            If ugTipCene <> 10 Then
                If PrevozninaPoKolima <= bMinPrevoznina Then
                    PrevozninaPoKolima = bMinPrevoznina
                End If
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

        'bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

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

            If Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Then
                TovarenaPrazna = "TK"
            End If

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

            ''===========  CO 2011: Uvecanje stava za 30% zbog RID-a ============
            'i_Pronasao = 0
            ''Dim mNizRidCo(16) As String

            ''mNizRidCo(0) = "720221"
            ''mNizRidCo(1) = "280110"
            ''mNizRidCo(2) = "280700"
            ''mNizRidCo(3) = "280800"
            ''mNizRidCo(4) = "281129"
            ''mNizRidCo(5) = "281310"
            ''mNizRidCo(6) = "283711"
            ''mNizRidCo(7) = "284910"
            ''mNizRidCo(8) = "290250"
            ''mNizRidCo(9) = "290321"
            ''mNizRidCo(10) = "290712"
            ''mNizRidCo(11) = "291611"
            ''mNizRidCo(12) = "291612"
            ''mNizRidCo(13) = "291614"
            ''mNizRidCo(14) = "293100"
            ''mNizRidCo(15) = "390311"

            'i_Pronasao = Array.BinarySearch(mNizRidCo, _mNHM)

            'If i_Pronasao >= 0 Then

            '    outVozarinskiStav = outVozarinskiStav * 1.3 '+30% ugovori CO 2011
            '    bZaokruziNaDeseteNavise(outVozarinskiStav)

            'End If
            ''===========  end Uvecanje stava za 30% zbog RID-a ============

            bZaokruziNaDeseteNavise(outVozarinskiStav)

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
        'spKomanda.CommandTimeout = 360

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

            ''===========  CO 2011: Uvecanje stava za 30% zbog RID-a ============
            'i_Pronasao = 0
            ''Dim mNizRidCo(16) As String

            ''mNizRidCo(0) = "720221"
            ''mNizRidCo(1) = "280110"
            ''mNizRidCo(2) = "280700"
            ''mNizRidCo(3) = "280800"
            ''mNizRidCo(4) = "281129"
            ''mNizRidCo(5) = "281310"
            ''mNizRidCo(6) = "283711"
            ''mNizRidCo(7) = "284910"
            ''mNizRidCo(8) = "290250"
            ''mNizRidCo(9) = "290321"
            ''mNizRidCo(10) = "290712"
            ''mNizRidCo(11) = "291611"
            ''mNizRidCo(12) = "291612"
            ''mNizRidCo(13) = "291614"
            ''mNizRidCo(14) = "293100"
            ''mNizRidCo(15) = "390311"

            'i_Pronasao = Array.BinarySearch(mNizRidCo, _mNHM)

            'If i_Pronasao >= 0 Then

            '    outVozarinskiStav = outVozarinskiStav * 1.3 '+30% ugovori CO 2011
            '    bZaokruziNaDeseteNavise(outVozarinskiStav)

            'End If
            ''===========  end Uvecanje stava za 30% zbog RID-a ============

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

        If mVrstaPrevoza = "V" And Not (mBrojUg = "301524" Or mBrojUg = "301124" Or mBrojUg = "301224" Or mBrojUg = "301324" Or mBrojUg = "301424") Then               ' kontejnerski voz Proodos
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

        Else
            bNadjiPrevozninuKontTEA("135", mPrevoznina) 'za 2011 bilo "133"
            'Upis racunske mase i vozarinskog stava je tu uracunat

        End If
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
        'spKomanda.CommandTimeout = 360

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
            If outRetVal = "                                                  " Then
                outRetVal = ""
            End If
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
    Public Sub bNadjiNaftu(ByVal inNHM As String, ByVal intkm As Integer, ByRef outDodatak As Decimal)

        Dim NHM14 As Integer

        outDodatak = 0

        NHM14 = CType(Microsoft.VisualBasic.Left(inNHM, 4), Integer)

        If ((NHM14 = 2709) Or (NHM14 = 2710) Or (NHM14 = 2711)) Or ((NHM14 >= 2721) And (NHM14 <= 2749)) Then
            If IzborSaobracaja = "4" Then
                If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "10" Then
                    If Microsoft.VisualBasic.Left(mBrojUg, 2) = "10" Or Microsoft.VisualBasic.Left(mBrojUg, 2) = "11" Or Microsoft.VisualBasic.Left(mBrojUg, 2) = "12" Then
                        If intkm < 101 Then outDodatak = 55
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 165
                        If intkm > 350 Then outDodatak = 205
                    Else
                        If intkm < 101 Then outDodatak = 53
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 162
                        If intkm > 350 Then outDodatak = 201
                    End If
                ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "11" Then
                    If Microsoft.VisualBasic.Left(mBrojUg, 2) = "10" Or Microsoft.VisualBasic.Left(mBrojUg, 2) = "11" Or Microsoft.VisualBasic.Left(mBrojUg, 2) = "12" Then
                        If intkm < 101 Then outDodatak = 55
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 165
                        If intkm > 350 Then outDodatak = 205
                    Else
                        If intkm < 101 Then outDodatak = 53
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 162
                        If intkm > 350 Then outDodatak = 201
                    End If
                ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "12" Then
                    If intkm < 101 Then outDodatak = 57
                    If (intkm > 100) And (intkm < 351) Then outDodatak = 169
                    If intkm > 350 Then outDodatak = 210
                ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "13" Then
                    If Microsoft.VisualBasic.Left(mBrojUg, 2) = "10" Or Microsoft.VisualBasic.Left(mBrojUg, 2) = "11" Or Microsoft.VisualBasic.Left(mBrojUg, 2) = "12" Then
                        If intkm < 101 Then outDodatak = 59
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 173
                        If intkm > 350 Then outDodatak = 216
                    Else
                        If intkm < 101 Then outDodatak = 57
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 169
                        If intkm > 350 Then outDodatak = 210

                        'P.Mikasinovic 19/8/2013; Telegram 248 od 09.jula.13 
                        If Microsoft.VisualBasic.Left(mBrojUg, 4) = "7413" And mStanica1 = "23499" And mStanica2 = "12498" Then
                            If intkm > 350 Then outDodatak = 105
                        End If

                        'P.Mikasinovic 12/9/2013; Telegram 130 od 08.januara.13 
                        If mBrojUg = "061302" And mStanica1 = "12498" And mStanica2 = "23499" Then
                            If intkm > 350 Then outDodatak = 0
                        End If

                        'P.Mikasinovic 19/8/2013; Telegram 334 od 09.jula.13 
                        If mBrojUg = "061301" And mStanica1 = "23499" And mStanica2 = "12498" And Microsoft.VisualBasic.Left(inNHM, 4) = "2711" Then
                            If intkm > 350 Then outDodatak = 105
                        End If
                    End If
                ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "14" Then
                    If Microsoft.VisualBasic.Left(mBrojUg, 2) = "11" Or Microsoft.VisualBasic.Left(mBrojUg, 2) = "12" Then
                        If intkm < 101 Then outDodatak = 57 '59
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 169 '173
                        If intkm > 350 Then outDodatak = 210 '216
                    Else
                        If intkm < 101 Then outDodatak = 57
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 169
                        If intkm > 350 Then outDodatak = 210

                        'P.Mikasinovic 19/8/2013; Telegram 248 od 09.jula.13 
                        If Microsoft.VisualBasic.Left(mBrojUg, 4) = "7413" And mStanica1 = "23499" And mStanica2 = "12498" Then
                            If intkm > 350 Then outDodatak = 105
                        End If

                        'P.Mikasinovic 12/9/2013; Telegram 130 od 08.januara.13 
                        If mBrojUg = "061302" And mStanica1 = "12498" And mStanica2 = "23499" Then
                            If intkm > 350 Then outDodatak = 0
                        End If

                        'P.Mikasinovic 19/8/2013; Telegram 334 od 09.jula.13 
                        If mBrojUg = "061301" And mStanica1 = "23499" And mStanica2 = "12498" And Microsoft.VisualBasic.Left(inNHM, 4) = "2711" Then
                            If intkm > 350 Then outDodatak = 105
                        End If

                    End If

                ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "15" Then
                    If Microsoft.VisualBasic.Left(mBrojUg, 2) = "11" Or Microsoft.VisualBasic.Left(mBrojUg, 2) = "12" Then
                        If intkm < 101 Then outDodatak = 57 '59
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 169 '173
                        If intkm > 350 Then outDodatak = 210 '216
                    Else
                        If intkm < 101 Then outDodatak = 57
                        If (intkm > 100) And (intkm < 351) Then outDodatak = 169
                        If intkm > 350 Then outDodatak = 210

                        ''''P.Mikasinovic 19/8/2013; Telegram 248 od 09.jula.13 
                        '''If Microsoft.VisualBasic.Left(mBrojUg, 4) = "7413" And mStanica1 = "23499" And mStanica2 = "12498" Then
                        '''    If intkm > 350 Then outDodatak = 105
                        '''End If

                        ''''P.Mikasinovic 12/9/2013; Telegram 130 od 08.januara.13 
                        '''If mBrojUg = "061302" And mStanica1 = "12498" And mStanica2 = "23499" Then
                        '''    If intkm > 350 Then outDodatak = 0
                        '''End If

                        ''''P.Mikasinovic 19/8/2013; Telegram 334 od 09.jula.13 
                        '''If mBrojUg = "061301" And mStanica1 = "23499" And mStanica2 = "12498" And Microsoft.VisualBasic.Left(inNHM, 4) = "2711" Then
                        '''    If intkm > 350 Then outDodatak = 105
                        '''End If

                    End If

                End If
            End If
        End If

        'RID za ugovor 101200
        If inNHM = "720220" Or inNHM = "720221" Or inNHM = "720222" Or inNHM = "720223" Or inNHM = "720224" Or _
           inNHM = "720225" Or inNHM = "720226" Or inNHM = "720227" Or inNHM = "720228" Or inNHM = "720229" Or _
           inNHM = "280110" Or inNHM = "280700" Or inNHM = "280800" Or inNHM = "281129" Or inNHM = "281310" Or _
           inNHM = "283711" Or inNHM = "284910" Or inNHM = "290250" Or inNHM = "290321" Or inNHM = "290712" Or _
           inNHM = "291611" Or inNHM = "291612" Or inNHM = "291614" Or inNHM = "293100" Or inNHM = "390311" Then

            If IzborSaobracaja = "4" Then
                If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "12" Then
                    If intkm < 101 Then outDodatak = 57
                    If (intkm > 100) And (intkm < 351) Then outDodatak = 169
                    If intkm > 350 Then outDodatak = 210
                End If
            End If

        End If

    End Sub
    Public Sub bDaLiJeNafta(ByVal inNHM As String, ByRef outDaNe As Boolean)

        Dim NHM14 As Integer
        outDaNe = False

        NHM14 = CType(Microsoft.VisualBasic.Left(inNHM, 4), Integer)

        If (NHM14 = 2709) Or (NHM14 = 2710) Or (NHM14 = 2711) Or ((NHM14 >= 2721) And (NHM14 <= 2749)) Then
            outDaNe = True
        End If

        'RID za novi ugovor 101200
        If inNHM = "720220" Or inNHM = "720221" Or inNHM = "720222" Or inNHM = "720223" Or inNHM = "720224" Or _
           inNHM = "720225" Or inNHM = "720226" Or inNHM = "720227" Or inNHM = "720228" Or inNHM = "720229" Or _
           inNHM = "280110" Or inNHM = "280700" Or inNHM = "280800" Or inNHM = "281129" Or inNHM = "281310" Or _
           inNHM = "283711" Or inNHM = "284910" Or inNHM = "290250" Or inNHM = "290321" Or inNHM = "290712" Or _
           inNHM = "291611" Or inNHM = "291612" Or inNHM = "291614" Or inNHM = "293100" Or inNHM = "390311" Then

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

        If (inBrojUgovora = "481101") And (NHM14 = 2606) Then
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
    Public Sub bNadjiPrevKoefCOUI(ByRef outPrevKoefCOUI As Decimal)

        Dim PKola, ZSKola, RIVOsl As Boolean        ' formalno, samo za probu

        If Microsoft.VisualBasic.Right(mBrojUg, 2) = "02" Then      ' grupe kola
            If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "07" Then
                If (Not ((mStanica1 = "15723") Or (mStanica2 = "15723"))) Then
                    If IzborSaobracaja = "2" Then
                        outPrevKoefCOUI = 0.9
                    ElseIf IzborSaobracaja = "3" Then
                        outPrevKoefCOUI = 0.95
                    End If
                Else
                    outPrevKoefCOUI = 1 ' za Prijepolje
                End If
            Else
                If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "14" Then
                    If IzborSaobracaja = "2" Then
                        outPrevKoefCOUI = 0.95                  ' grupe, uvoz, 2014
                    ElseIf IzborSaobracaja = "3" Then
                        outPrevKoefCOUI = 0.95                  ' grupe, izvoz, 2014
                    End If
                ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "15" Then
                    If IzborSaobracaja = "2" Then
                        outPrevKoefCOUI = 0.95                  ' grupe, uvoz, 2015
                    ElseIf IzborSaobracaja = "3" Then
                        outPrevKoefCOUI = 0.95                  ' grupe, izvoz, 2015
                    End If
                Else
                    If IzborSaobracaja = "2" Then
                        outPrevKoefCOUI = 0.9
                    ElseIf IzborSaobracaja = "3" Then
                        outPrevKoefCOUI = 0.95
                    End If
                End If
            End If
        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "01" Then  ' vozovi
            If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "07" Then
                If (Not ((mStanica1 = "15723") Or (mStanica2 = "15723"))) Then
                    If IzborSaobracaja = "2" Then
                        outPrevKoefCOUI = 0.8
                    ElseIf IzborSaobracaja = "3" Then
                        outPrevKoefCOUI = 0.85
                    End If
                Else
                    outPrevKoefCOUI = 0.9 ' za Prijepolje
                End If
            Else
                If Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "15" Then
                    If IzborSaobracaja = "2" Then
                        outPrevKoefCOUI = 0.85                  ' vozovi, uvoz, 2014
                    ElseIf IzborSaobracaja = "3" Then
                        If Not (ZSKola) And Not (RIVOsl) Then
                            outPrevKoefCOUI = 0.85                  ' vozovi, izvoz, 2015, strane upr. neosl. RIV
                        End If
                        If PKola Or ZSKola Or RIVOsl Then
                            outPrevKoefCOUI = 0.9                   ' vozovi, izvoz, 2015, P-kola, ŽS i strane upr. osl. RIV
                        End If
                    End If
                ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 3, 2) = "14" Then
                    If IzborSaobracaja = "2" Then
                        outPrevKoefCOUI = 0.85                  ' vozovi, uvoz, 2014
                    ElseIf IzborSaobracaja = "3" Then
                        outPrevKoefCOUI = 0.85                  ' vozovi, izvoz, 2014
                    End If
                Else
                    If IzborSaobracaja = "2" Then
                        outPrevKoefCOUI = 0.8
                    ElseIf IzborSaobracaja = "3" Then
                        outPrevKoefCOUI = 0.85
                    End If
                End If

            End If
        End If
    End Sub
    Public Sub NadjiAneks(ByVal inUgovor As String, ByVal inSaobracaj As String, _
                          ByVal inStanicaOd As String, ByVal inStanicaDo As String, _
                          ByVal inOsovine As Int32, ByVal inVrstaPrevoza As String, _
                          ByVal inVlasnistvoKola As String, ByVal inVrstaKola As String, _
                          ByVal inDatum As Date, ByVal inNHM As String, ByVal inUslovZaStav As Int32, _
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

        Dim ulUslovZaStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUslovZaStav", SqlDbType.Int))
        ulUslovZaStav.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUslovZaStav").Value = inUslovZaStav

        ''Dim izUslovZaStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUslovZaStav", SqlDbType.Int))
        ''izUslovZaStav.Direction = ParameterDirection.Output
        ''spKomanda.Parameters("@outUslovZaStav").Value = outUslovZaStav

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
                outIzlaz = inCena * inRacunskaMasa / 1000 '8/8/2014 !!

                'outIzlaz = ?inUlaz1 * inKoeficijent    ' TonskiStav * Koeficijent
            Case 4, 5, 15       'Cena po kolima, Cena po vozu, Cena po vozu za BMV 
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

            Case 2, 13
                bZaokruziMasuNa100k(MasaPoKolima)
                outRacunskaMasa = MasaPoKolima
            Case 3

                ' bilo do 11/9/2014: outRacunskaMasa = MasaPoKolima
                'bZaokruziMasuNa100k(MasaPoKolima) 'djaja email 11/9/2014

                bZaokruziMasuNa100k(MasaPoKolima) '2. vraceno 15/8/2014 - djaja 
                outRacunskaMasa = MasaPoKolima    '1. vraceno 15/8/2014 - djaja email

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

    Public Sub bNadjiPrevozninu05COUI(ByVal Tabela As String, ByRef Prevoznina As Decimal)
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
        Dim Prev1R As Decimal
        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim TonskiStavInteger As Integer

        Dim PrevozninaPoKolima As Decimal = 0
        Dim RacMasaPoKolima As Integer
        Dim bVrsta00tranzita As Byte
        Dim DoTona As String = "25"
        Dim inReka As String = ""

        Dim ugCena As Decimal
        Dim ugTipCene As Integer
        Dim ugRetVal As String
        Dim RacMasaZaAneks As Decimal
        Dim Prev As Decimal = 0
        Dim ugKoeficijent As Decimal = 0
        Dim ugDodatak As Decimal = 0

        Prevoznina = 0
        mPrevoznina = 0
        bRedovanOrocen = "R"


        If dtKola.Rows.Count > 0 Then
            For Each KolaRed In dtKola.Rows
                IBK = KolaRed.Item("IndBrojKola")
                Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                TipKola = KolaRed.Item("Tip")
                Vlasnistvo = KolaRed.Item("Vlasnik")
                BrOsovina = KolaRed.Item("Osovine")

                Stitna = KolaRed.Item("Stitna")

                If Vrsta = "O" Then Vrsta = 1
                If Vrsta = "S" Then Vrsta = 2

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "00", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                                     "TK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                pubSerijaKola = KolaRed.Item("Serija") '## T kola
                pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola
                bNadjiTipKolaKoef(TipKola, "00", "00000", mDatumKalk, KolKoef, PV)

                If dtNhm.Rows.Count > 0 Then
                    Masa1R = 0
                    Prev1R = 0

                    For Each NHMRed In dtNhm.Rows
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            NHMTemp = NHMRed.Item("NHM")          '  "1701" - šecer
                            MasaTemp = NHMRed.Item("Masa")
                            Razred = NHMRed.Item("R")             '  "1"  
                            Masa1R = Masa1R + MasaTemp

                        End If
                        bZaokruziMasuNa100k(Masa1R)
                    Next

                    PrevozninaPoKolima = 0
                    bZaokrMasuNaOsovineP(Masa1R, "TK", BrOsovina, Masa1R)


                    ' ************************* Novi AneksCO *******************************
                    NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                                   BrOsovina, "V", Vlasnistvo, "1", _
                                   mDatumKalk, 1, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                                   1, ugCena, ugTipCene, sqlVlasnistvoKola, ugRetVal)

                    '=========================== korekcija aneksa ===============================
                    If (ugRetVal = "") Then

                        bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)

                        bKorigujPoAneksu(ugTipCene, Prev, ugKoeficijent, _
                                         RacMasaZaAneks, ugCena, _
                                         RacMasaZaAneks, bTkm, ugDodatak, Prev)

                        PrevozninaPoKolima = Prev
                        bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                        'mPrevoznina = PrevozninaPoKolima
                        bVozarinskiStavPoKolima = ugCena
                        bRacunskaMasaPoKolima = RacMasaZaAneks

                        If PrevozninaPoKolima <= bMinPrevoznina Then
                            PrevozninaPoKolima = bMinPrevoznina
                        End If

                        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                        KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                        KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima

                        Prevoznina = Prevoznina + PrevozninaPoKolima
                        bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima
                    End If
                    '========================= end korekcija aneksa =============================
                    ' ************************* end Novi AneksCO ***************************


                    'If mBrojUg = "101005" Then
                    '    ' *****COANEKS


                    '    Dim ugUslovZaStav As Integer = TonskiStavInteger
                    '    Dim ugCena As Decimal
                    '    Dim ugTipCene As Integer
                    '    Dim ugRetVal As String = ""
                    '    Dim ugDodatak As Decimal
                    '    Dim ugKoeficijent As Decimal


                    '    ' izracunati promenljivu "Stitna"
                    '    NadjiAneks(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                    '                BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, mDatumKalk, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                    '                ugUslovZaStav, ugCena, ugTipCene, ugRetVal)

                    '    If (ugRetVal = "") Then
                    '        Dim RacMasaZaAneks As Decimal
                    '        bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)

                    '        'Usaglasiti mase - ulazne parametre: 
                    '        bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                    '                             RacMasaZaAneks, ugCena, _
                    '                             RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)

                    '        bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    '        bVozarinskiStavPoKolima = ugCena
                    '        bRacunskaMasaPoKolima = RacMasaZaAneks


                    '        If PrevozninaPoKolima <= bMinPrevoznina Then
                    '            PrevozninaPoKolima = bMinPrevoznina
                    '        End If

                    '        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                    '        KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                    '        KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                    '        Prevoznina = Prevoznina + PrevozninaPoKolima
                    '        bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

                    '    End If

                    '    ' *****COANEKS


                    'End If

                End If


                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                        Dim bRacunskaMasaNHM As Decimal = bRacunskaMasaPoKolima
                        bZaokruziMasuNa100k(MasaTemp1)

                        If bRacunskaMasaNHM <= MasaTemp1 Then bRacunskaMasaNHM = MasaTemp1
                        If bRacunskaMasaNHM <= BrOsovina * 5000 Then bRacunskaMasaNHM = BrOsovina * 5000

                        NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    End If
                Next

            Next
        End If

    End Sub
    Public Sub bKorigujPoAneksuAG(ByVal Tabela As String, ByRef Prevoznina As Decimal)

        ' AGIT 030722 i slicni


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

        Dim NHM As String

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
            If Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Then
                TovarenaPrazna = "TK"
            End If


            ' Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna

            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            KolKoef = 1
            'If Vlasnistvo = "P" Or Vlasnistvo = "I" Then
            '    KolKoef = 0.8
            'End If
            ' proveriti ulazne parametre
            pubSerijaKola = KolaRed.Item("Serija") '## T kola
            pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola
            bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

            For Each NHMRed In dtNhm.Rows
                If IBK = NHMRed.Item("IndBrojKola") Then
                    DuzinaKontStr = NHMRed.Item("UTI")
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    StvMasa = NHMRed.Item("Masa")
                    bNadjiRasterTEA(DuzinaKont, StvMasa, Raster)

                    NHM = NHMRed.Item("NHM")

                    PrevozninaPoKont = 0

                    'bNadjiVozarinskiStavKontTEA(Tabela, mDatumKalk, bTkm, VozarinskiStav, PV)

                    'NadjiAneks(...)
                    'bKorigujPoAneksuAG(...)

                    'VozarinskiStav = bStavKoef * VozarinskiStav
                    'bZaokruziNaDeseteNavise(VozarinskiStav)

                    PrevozninaPoKont = VozarinskiStav * Raster '  * KolKoef * bPrevozninaKoef
                    bZaokruziNaDeseteNavise(PrevozninaPoKont)
                    '###
                    NHMRed.Item("RacMasaNHM") = StvMasa
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                    NHMRed.Item("UTIRaster") = Raster

                    'bRacunskaMasaPoKolima = StvMasa
                    'bVozarinskiStavPoKolima = VozarinskiStav
                    '###

                    PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaPoKont

                End If
                '###
                bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + StvMasa
                '###

            Next
            ' proba na minimalnu prevozninu - nema po AGIT aneksu

            'If mTarifa = "00" And Microsoft.VisualBasic.Left(NHM, 4) = "9931" Then
            '    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
            '              "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            '              bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
            'End If

            'If PrevozninaPoKolima <= bMinPrevoznina Then
            '    PrevozninaPoKolima = bMinPrevoznina
            'End If

            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            Prevoznina = Prevoznina + PrevozninaPoKolima
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

        Next
    End Sub
    Public Sub bNadjiPrevozninuMil99(ByRef Prevoznina As Decimal)    ' Militzer za USSteel

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow

        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, NHM As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1
        Dim MasaTemp As Integer
        Dim Razred As String

        Dim VozarinskiStav As Decimal
        Dim PV As String

        Dim PrevozninaPoKolima As Decimal = 0

        bRacunskaMasa = 0
        Prevoznina = 0

        If dtNhm.Rows(0).Item("NHM") = "992100" Or dtNhm.Rows(0).Item("NHM") = "992200" Then
            bSvaTovarena = "PK"
        Else
            bSvaTovarena = "TK"
        End If

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
                pubSerijaKola = KolaRed.Item("Serija") '## T kola
                pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola
                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

                If dtNhm.Rows.Count > 0 Then
                    bRacunskaMasaPoKolima = 0
                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            NHMRed.Item("RacMasaNHM") = MasaTemp
                            bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + MasaTemp
                            NHM = dtNhm.Rows(0).Item("NHM")
                        End If
                    Next

                    bZaokruziMasuNa100k(bRacunskaMasaPoKolima)

                    If bRacunskaMasaPoKolima < 10000 Then
                        bRacunskaMasaPoKolima = 10000
                    End If

                    bProveri8606(_mNHM, bNHM8606, bNHMKao8606)
                    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                                         "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                         bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                    If (bNHM8606 Or bNHMKao8606) Then
                        bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                                             bSvaTovarena, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                             bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                    Else

                    End If


                    PrevozninaPoKolima = 0

                End If

                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima


                ' ************************* Novi AneksCO *******************************
                NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                               BrOsovina, mVrstaPrevoza, Vlasnistvo, Vrsta, _
                               mDatumKalk, 1, Microsoft.VisualBasic.Left(NHM, 4), _
                               1, VozarinskiStav, 2, sqlVlasnistvoKola, PV)

                ' *********************** end Novi AneksCO *****************************

                Dim KolPrevKoef As Decimal = 1

                PrevozninaPoKolima = bRacunskaMasaPoKolima * VozarinskiStav * KolPrevKoef / 1000

                bZaokruziNaDeseteNavise(PrevozninaPoKolima)

                If PrevozninaPoKolima <= bMinPrevoznina Then
                    PrevozninaPoKolima = bMinPrevoznina
                End If

                If PV = "" Then
                Else
                    MsgBox("Uslovi ugovora nisu zadovoljeni! Proverite podatke.", vbYes + vbInformation, "Poruka: Aneks 88/99")
                    PrevozninaPoKolima = 0
                End If

                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                KolaRed.Item("VozarinskiStav") = VozarinskiStav

                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                    End If
                Next
                Prevoznina = Prevoznina + PrevozninaPoKolima
            Next    ' petlja po kolima
            'Prevoznina = Prevoznina + PrevozninaPoKolima
        End If
    End Sub

    Public Sub bNadjiPrevozninu844514(ByRef Prevoznina As Decimal)          ' AdriaKombi pojedinacne
        '
        ' racuna se za svaki UTI, zaokruzuje na deset navise i sabira za kola
        ' 
        ' 
        ' 
        ' naci cenu ( po UTI-ju ) - ulaz - OTPRAVNA stanica, uputna stanica; 
        '                           izlaz - voz. stav ( cena po UTI-ju ), naknada po kolima ( VAG-za zel.kola);

        ' naci raster  - ulaz - masa i duzina kontejnera;
        '                izlaz - raster koeficijent
        '
        ' PrevozninaPoUTI-ju = voz.stav * raster * provizija ;  ( provizija = 1.008 )
        ' Prevoznina = Suma(PrevozninaPoUTI-ju) + NaknadaPoKolima 

        ' polja za UTI-je u tabeli NHM :
        '"UTI", String                                 5 tip - duzina
        '"UTIIB",String                                6 Ind. broj kontenera [GRANICA]
        '"UTITara", Int32                            7 tara kontenera [GRANICA]
        '"UTIRaster", Decimal                     8 primenjeni raster
        '"UTINHM", String                           9 roba u kontejneru [GRANICA]
        '"UTIBuletin", String                       10 predajni list [GRANICA]
        '"UTIPlombe", String                      11broj plombi [GRANICA]


        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim MasaTemp As Integer
        Dim NHMTemp As Integer
        Dim IBK As String
        Dim Vlasnistvo As String
        Dim TovarenaPrazna As String
        Dim DuzinaKontTemp As String
        Dim RasterTemp As Decimal = 1
        Dim IzStav, StavPoTEA As Decimal
        Dim PovVr As String
        Dim PrevozninaZaUTI, PrevozninaPoKolima, NaknadaPoKolima As Decimal
        Dim RacunskaMasaPoKolima, VozarinskiStavPoKolima As Decimal
        Dim UgTipCene As Integer
        Dim UgRetVal As String
        Dim UgSifraNapomene As Int32
        Dim UgNaknadaPoKolima As Decimal

        Util.sNadjiNaziv("TabNaziv", mBrojUg, "", "", 1, xNaziv, xPovVrednost)
        mTabelaCena = xNaziv

        PrevozninaPoKolima = 0
        NaknadaPoKolima = 0

        IBK = dtKola.Rows(0).Item("IndBrojKola")
        Vlasnistvo = dtKola.Rows(0).Item("Vlasnik")
        bMinPrevoznina = 0

        If dtNhm.Rows(0).Item("NHM") = "994100" Then
            TovarenaPrazna = "TU"
        ElseIf dtNhm.Rows(0).Item("NHM") = "993100" Then
            TovarenaPrazna = "PK"
        End If

        'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
        'TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
        'bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

        For Each NHMRed In dtNhm.Rows                                                ' petlja po robi za jedna kola
            If NHMRed.Item("IndBrojKola") = IBK Then
                MasaTemp = NHMRed.Item("Masa")
                DuzinaKontTemp = NHMRed.Item("UTI")
                NHMTemp = NHMRed.Item("NHM")
                bNadjiRasterCO(DuzinaKontTemp, MasaTemp, RasterTemp)

                If (DuzinaKontTemp = "40") And (NHMTemp = 993100) Then
                    RasterTemp = 0.42
                End If

                IzStav = 0

                Dim S1, S2 As String
                If bVrstaSaobracaja = 2 Then
                    S1 = Microsoft.VisualBasic.Right(mOtpStanica, 5)
                    S2 = mStanica2
                ElseIf bVrstaSaobracaja = 3 Then
                    S2 = mStanica1
                    S1 = Microsoft.VisualBasic.Right(mPrStanica, 5)
                End If

                bNadjiCenuAKombi(mBrojUg, "2", S1, S2, _
                            "1", "P", Vlasnistvo, "1", mDatumKalk, Microsoft.VisualBasic.Left(NHMTemp, 4), "1", _
                            IzStav, UgTipCene, UgSifraNapomene, UgNaknadaPoKolima, UgRetVal)

                PrevozninaZaUTI = (IzStav + UgNaknadaPoKolima) * RasterTemp * 1.008
                bZaokruziNaDeseteNavise(PrevozninaZaUTI)
                bZaokruziMasuNa100k(MasaTemp)

                bVozarinskiStav = IzStav

                NHMRed.Item("RacMasaNHM") = MasaTemp
                NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStav
                NHMRed.Item("UtiRaster") = RasterTemp
                RacunskaMasaPoKolima = RacunskaMasaPoKolima + MasaTemp
                PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaZaUTI
            End If
        Next

        'If PrevozninaPoKolima <= bMinPrevoznina Then
        '    PrevozninaPoKolima = bMinPrevoznina
        'End If

        ''If Vlasnistvo = "Z" Then
        ''    NaknadaPoKolima = UgNaknadaPoKolima
        ''Else
        ''    NaknadaPoKolima = 0
        ''End If

        Prevoznina = PrevozninaPoKolima
        dtKola.Rows(0).Item("Prevoznina") = Prevoznina
        dtKola.Rows(0).Item("Naknada") = UgNaknadaPoKolima 'per uti ?????????? da li treba - 
        dtKola.Rows(0).Item("RacunskaMasa") = RacunskaMasaPoKolima
        dtKola.Rows(0).Item("VozarinskiStav") = IzStav


    End Sub
    Public Sub bNadjiPrevozninu844516(ByRef Prevoznina As Decimal) ' AdriaKombi marš.vozovi

        Dim KolaRed, NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, Stitna As String
        Dim BrOsovina As Integer
        Dim DuzinaKontStr As String
        Dim DuzinaKont As Integer
        Dim StvMasa As Integer
        Dim RMNHM As Integer
        Dim UkupnoKola As Byte
        Dim CenaPoVozu As Decimal
        Dim PrevozninaPoKolima As Decimal = 0
        Dim PrevozninaPoKont As Decimal = 0
        Dim VozarinskiStav As Decimal
        Dim Raster As Decimal

        Dim PV As String
        Dim BMasa, BMasaKola, NaknadaZaKola, UgNaknadaPoKolima As Decimal

        Dim NHM As String

        Dim bAntDodatak, bAntDodatakUTI As Decimal

        ' Postupak:
        ' 
        ' - u cenu ulaze: 
        '   1. - fiksni iznos za voz ( CenaPoVozu do stanice 16050 ) - koji zavisi od mase voza
        '   2. - naknada za zel. kola ( po kolima )
        '      - zbir 1. i 2. se množi provizijom ( *1.003 ) 
        '   3. - dodatni deo prevoznine ( "antena" ) posebno za svaki UTI, pomnožen rasterom;
        '        ovaj deo zavisi od uputne stanice i ne mnozi se provizijom
        '   
        ' - uracunati minimalnu prevozninu ?


        UkupnoKola = dtKola.Rows.Count

        Prevoznina = 0

        ' nalazenje cene i naknade je HCD
        '   BMasa kada je sve na jednom tovarnom listu:
        Dim StanicaVIA As String = 16050
        Dim MasaTemp, UTITara, UkUTIMasa, MasaPoKolima As Int32
        Dim CenaAnt As Decimal = 0



        '     HCD
        UgNaknadaPoKolima = 14
        '     HCD



        For Each KolaRed In dtKola.Rows         ' petlja po kolima i nalazenje bruto mase, ako je sve na jednom t.l.
            IBK = KolaRed.Item("IndBrojKola")   ' kao i ant. dodatka 
            MasaPoKolima = 0

            For Each NHMRed In dtNhm.Rows   '  petlja po robi
                If NHMRed.Item("IndBrojKola") = IBK Then
                    MasaTemp = NHMRed.Item("Masa")
                    UTITara = NHMRed.Item("UTITara")
                    DuzinaKontStr = NHMRed.Item("UTI")
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    UkUTIMasa = MasaTemp + UTITara
                    bZaokruziMasuNa100k(UkUTIMasa)
                    MasaPoKolima = MasaPoKolima + UkUTIMasa

                    ' bNadjiCenuAnt(mStanica1, mStanica2, CenaAnt) ili
                    ' HCDCenaAnt
                    '
                    If IzborSaobracaja = "2" Then
                        If mStanica2 = "23450" Then
                            CenaAnt = 185
                        ElseIf mStanica2 = "16871" Then
                            CenaAnt = 110
                        ElseIf mStanica2 = "16501" Then
                            CenaAnt = 85
                        ElseIf mStanica2 = "16051" Then
                            CenaAnt = 57
                        ElseIf mStanica2 = "21001" Then
                            CenaAnt = 67
                        End If
                    ElseIf IzborSaobracaja = "3" Then
                        If mStanica1 = "23450" Then
                            CenaAnt = 185
                        ElseIf mStanica1 = "16871" Then
                            CenaAnt = 110
                        ElseIf mStanica1 = "16501" Then
                            CenaAnt = 85
                        ElseIf mStanica1 = "16051" Then
                            CenaAnt = 57
                        ElseIf mStanica1 = "21001" Then
                            CenaAnt = 67
                        End If

                    End If

                    ' HCDCenaAnt

                    bNadjiRasterCO(DuzinaKont, UkUTIMasa, Raster)
                    bAntDodatakUTI = CenaAnt * Raster
                    bZaokruziNaDeseteNavise(bAntDodatakUTI) '???
                    bAntDodatak = bAntDodatak + bAntDodatakUTI

                End If
            Next
            BMasa = BMasa + MasaPoKolima
        Next    ' petlja po kolima

        '        If Flag = 0 And (bAntDodatakUTI > 0) Then
        Dim RedNak As DataRow

        If dtNaknade.Rows.Count > 0 Then
            For Each RedNak In dtNaknade.Rows
                If RedNak.Item("Sifra") <> "84" And RedNak.Item("IvicniBroj") <> "45" Then
                    Dim dtRow As DataRow = dtNaknade.NewRow
                    dtNaknade.Rows.Add(New Object() {"84", "45", (CType(bAntDodatakUTI, String)), "17", 1, 0, "0", "CO", "I"})
                End If
            Next
        Else
            Dim dtRow As DataRow = dtNaknade.NewRow
            dtNaknade.Rows.Add(New Object() {"84", "45", (CType(bAntDodatakUTI, String)), "17", 1, 0, "0", "CO", "I"})
        End If

        'Dim dtRow As DataRow = dtNaknade.NewRow
        'dtNaknade.Rows.Add(New Object() {"84", "45", (CType(bAntDodatakUTI, String)), "17", 1, 0, "0", "CO", "I"})

        '      Flag = 1
        '       End If

        ' dobijena BMasa je tekuca masa po t.l. koji se trenutno obradjuje

        Dim Najava As String
        Dim MasaPoNajavi As Int32
        'bNadjiRealMasuPoNajavi(Najava, MasaPoNajavi)

        bNadjiBrutoMasu844516(MasaPoNajavi)
        ' MasaPoNajavi je masa po najavi iz baze, bez tekuceg tovarnog lista

        BMasa = BMasa + MasaPoNajavi


        '     HCD
        If BMasa <= 800000 Then
            CenaPoVozu = 1478
        Else
            CenaPoVozu = 1568
        End If
        '     HCD

        ' nalazenje cene i naknade je HCD

        Prevoznina = CenaPoVozu

        For Each KolaRed In dtKola.Rows ' ponovo petlja po kolima zbog upisa rac.masa, prevoznina i stavova
            PrevozninaPoKolima = 0
            bRacunskaMasaPoKolima = 0

            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            TipKola = Left(KolaRed.Item("Tip"), 1)
            BrOsovina = KolaRed.Item("Osovine")
            Stitna = KolaRed.Item("Stitna")

            For Each NHMRed In dtNhm.Rows   '  petlja po robi
                Dim bRacunskaMasaNHM As Int32
                Dim bVozarinskiStavNHM As Decimal = 0

                If NHMRed.Item("IndBrojKola") = IBK Then
                    bRacunskaMasaNHM = NHMRed.Item("Masa") + NHMRed.Item("UTITara")
                    bZaokruziMasuNa100k(bRacunskaMasaNHM)
                    bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + bRacunskaMasaNHM

                    bNadjiRasterCO(DuzinaKont, bRacunskaMasaNHM, Raster)

                    NHMRed.Item("UTIRaster") = Raster
                    NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                    NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavNHM
                End If
            Next

            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            ''If Vlasnistvo = "Z" Then
            ''    NaknadaZaKola = UgNaknadaPoKolima
            ''Else
            ''    NaknadaZaKola = 0
            ''End If

            ' Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna

            'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
            '       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


            'If PrevozninaPoKolima <= bMinPrevoznina Then        ' ? minimalna prevoznina ?
            '    PrevozninaPoKolima = bMinPrevoznina

            'End If

            ' šta sve obuhvata prevoznina po kolima i da li se uopste daje po kolima (zbog min prevoznine);
            ' da li je u to ukljucena i provizija?
            ' sta je sa ostalim koje treba upisati u slog ( dokle?)

            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            'KolaRed.Item("Naknada") = NaknadaZaKola
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima
        Next

        'Prevoznina = (CenaPoVozu + bAntDodatak) * 1.003

    End Sub
    Public Sub bNadjiCenuAKombi(ByVal inUgovor As String, ByVal inSaobracaj As String, _
                          ByVal inStanicaOd As String, ByVal inStanicaDo As String, _
                          ByVal inOsovine As Int32, ByVal inVrstaPrevoza As String, _
                          ByVal inVlasnistvoKola As String, ByVal inVrstaKola As String, _
                          ByVal inDatum As Date, ByVal inNHM As String, ByVal inUslovZaStav As Int32, _
                          ByRef outCena As Decimal, ByRef outTipCene As Int32, _
                          ByRef outSifraPrimedbe As Int32, ByRef outNaknadaPoKolima As Decimal, _
                          ByRef outRetVal As String)

        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.bspNadjiCenuAKombi", OkpDbVeza)
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

        Dim ulUslovZaStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUslovZaStav", SqlDbType.Int))
        ulUslovZaStav.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUslovZaStav").Value = inUslovZaStav

        ''Dim izUslovZaStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUslovZaStav", SqlDbType.Int))
        ''izUslovZaStav.Direction = ParameterDirection.Output
        ''spKomanda.Parameters("@outUslovZaStav").Value = outUslovZaStav

        Dim izCena As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outCena", SqlDbType.Decimal))
        izCena.Size = 9
        izCena.Precision = 10
        izCena.Scale = 2
        izCena.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outCena").Value = outCena

        Dim izTipCene As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTipCene", SqlDbType.Int))
        izTipCene.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTipCene").Value = outTipCene

        Dim izNaknadaPoKolima As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNaknadaPoKolima", SqlDbType.Decimal))
        izNaknadaPoKolima.Size = 9
        izNaknadaPoKolima.Precision = 10
        izNaknadaPoKolima.Scale = 2
        izNaknadaPoKolima.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNaknadaPoKolima").Value = outNaknadaPoKolima

        Dim izSifraPrimedbe As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraPrimedbe", SqlDbType.Int))
        izSifraPrimedbe.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraPrimedbe").Value = outSifraPrimedbe

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()
            outCena = spKomanda.Parameters("@outCena").Value
            outTipCene = spKomanda.Parameters("@outTipCene").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value
            outNaknadaPoKolima = spKomanda.Parameters("@outNaknadaPoKolima").Value
        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub bNadjiBrutoMasu844516(ByRef outBrutoMasa As Int32)

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK As String

        Dim MasaTemp, UtiTara, NHMMasaTemp, BrutoMasaPoKolima, BrutoMasaPoNajavi, MasaTLIzBaze As Integer

        Dim PV, _rv As String

        ' u ukupnu masu ne ulazi masa kola, vec samo masa robe i masa kontejnera

        outBrutoMasa = 0

        bNadjiMasuAKombiPoTL(outBrutoMasa)      ' masa po TL koji je trenutno aktivan

        '---------------- Realizovana Bruto masa za najavu ----------------------

        bNadjiBMAKombi(mBrojUg, mNajava, mObrGodina, BrutoMasaPoNajavi, _rv)
        ' BrutoMasaPoNajavi je masa po najavi (iz baze)

        ' ako se radi o azuriranju, od mase po najavi treba da se oduzme uk.masa (iz baze) po TL koji se azurira:

        MasaTLIzBaze = 0
        If MasterAction = "Upd" Then
            bNadjiBMAKombiZaTLIzBaze(mBrojUg, mNajava, mOtpUprava, mOtpStanica, mOtpBroj, mOtpDatum, MasaTLIzBaze, _rv)
        End If

        outBrutoMasa = BrutoMasaPoNajavi - MasaTLIzBaze

        'If OkpDbVeza.State = ConnectionState.Closed Then
        '    OkpDbVeza.Open()
        'End If


    End Sub

    Public Sub bNadjiBMAKombi(ByVal inBrojUg As String, ByVal inNajava As String, ByVal inObrGodina As String, _
                                 ByRef outBMAKombi As Integer, _
                                 ByRef rv As String)

        rv = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.okpNajavaPregledBMAKombi", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        ulUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = inBrojUg

        Dim ulNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10))
        ulNajava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNajava").Value = inNajava

        Dim ulGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4))
        ulGodina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inGodina").Value = inObrGodina

        '-------------------------------------- Izlazne promenljive ----------------------------------------------

        Dim izlBMAKombi As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBMAKombi", SqlDbType.Int, 4))
        izlBMAKombi.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBMAKombi").Value = outBMAKombi

        '---------------------------------------------------------------------------------------------------------
        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = rv

        Try
            spKomanda.ExecuteScalar()

            outBMAKombi = spKomanda.Parameters("@outBMAKombi").Value
            rv = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            rv = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            rv = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub bNadjiMasuAKombiPoTL(ByRef outBMAKombi As Integer)

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK As String

        Dim MasaTemp, UtiTara, NHMMasaTemp, BrutoMasaPoKolima As Integer

        If dtKola.Rows.Count > 0 Then
            BrutoMasaPoKolima = 0
            For Each KolaRed In dtKola.Rows    ' petlja po kolima
                IBK = KolaRed.Item("IndBrojKola")
                If dtNhm.Rows.Count > 0 Then
                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            UtiTara = NHMRed.Item("UTITara")
                        End If
                    Next
                    NHMMasaTemp = MasaTemp + UtiTara
                    bZaokruziMasuNa100k(NHMMasaTemp)
                    BrutoMasaPoKolima = BrutoMasaPoKolima + NHMMasaTemp    'masa po tov.listu koji je trenutno u gridu
                End If
                outBMAKombi = outBMAKombi + BrutoMasaPoKolima
            Next    ' petlja po kolima
        End If
    End Sub
    Public Sub bNadjiBMAKombiZaTLIzBaze(ByVal inBrojUg As String, ByVal inNajava As String, ByVal inOtpUprava As String, _
                                            ByVal inOtpStanica As String, ByVal inOtpBroj As Int32, ByVal inOtpDatum As Date, _
                                            ByRef outBMAKombi As Integer, ByRef rv As String)

        rv = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.okpNajavaPregledBMAKombiZaTL", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        ulUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = inBrojUg

        Dim ulNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10))
        ulNajava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNajava").Value = inNajava

        Dim ulOtpUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulOtpUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = inOtpUprava

        Dim ulOtpStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulOtpStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = inOtpStanica

        Dim ulOtpBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4))
        ulOtpBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = inOtpBroj

        Dim ulOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime))
        ulOtpDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpDatum").Value = inOtpDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------

        Dim izlBMAKombi As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolaReal", SqlDbType.Int, 4))
        izlBMAKombi.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKolaReal").Value = outBMAKombi

        '---------------------------------------------------------------------------------------------------------
        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = rv

        Try
            spKomanda.ExecuteScalar()

            outBMAKombi = spKomanda.Parameters("@outKolaReal").Value
            rv = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            rv = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            rv = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub bNadjiPrevozninu835753(ByRef Prevoznina As Decimal) ' AdriaKombi marš.vozovi

        Dim KolaRed, NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, Stitna As String
        Dim BrOsovina As Integer
        Dim DuzinaKontStr As String
        Dim DuzinaKont As Integer
        Dim StvMasa As Integer
        Dim RMNHM As Integer
        Dim UkupnoKola As Byte
        Dim CenaPoVozu As Decimal
        Dim PrevozninaPoKolima As Decimal = 0
        Dim PrevozninaPoKont As Decimal = 0
        Dim VozarinskiStav As Decimal
        Dim Raster As Decimal

        Dim PV As String
        Dim BMasa, BMasaKola, NaknadaZaKola, UgNaknadaPoKolima As Decimal

        Dim NHM As String
        Dim ugCena As Decimal
        Dim ugTipCene As Integer
        Dim ugRetVal As String


        UkupnoKola = dtKola.Rows.Count

        Prevoznina = 0

        ''-------------------------- nalazenje cene i naknade je HCD
        'If (mStanica1 = "16517" And mStanica2 = "12498") Or (mStanica1 = "12498" And mStanica2 = "16517") Then
        '    CenaPoVozu = 4995 ' 2010: 4530 '16092010: 4330
        '    'doraditi za 2 bruto mase...
        'End If
        '' nalazenje cene i naknade je HCD

        Vlasnistvo = "1"

        ' ************************* Novi AneksCO *******************************
        NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, BrOsovina, "V", Vlasnistvo, 1, _
                       mDatumKalk, CType(nmBMV, Int32), "9941", 1, CenaPoVozu, ugTipCene, sqlVlasnistvoKola, ugRetVal)
        ' ************************* end Novi AneksCO ***************************


        Prevoznina = CenaPoVozu

        For Each KolaRed In dtKola.Rows ' rac.masa, prevoznina i stavova
            PrevozninaPoKolima = 0
            bRacunskaMasaPoKolima = 0

            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            TipKola = Left(KolaRed.Item("Tip"), 1)
            BrOsovina = KolaRed.Item("Osovine")
            Stitna = KolaRed.Item("Stitna")

            For Each NHMRed In dtNhm.Rows
                Dim bRacunskaMasaNHM As Int32
                Dim bVozarinskiStavNHM As Decimal = 0

                If NHMRed.Item("IndBrojKola") = IBK Then
                    bVozarinskiStavNHM = CenaPoVozu

                    bRacunskaMasaNHM = NHMRed.Item("Masa") + NHMRed.Item("UTITara")
                    bZaokruziMasuNa100k(bRacunskaMasaNHM)
                    bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + bRacunskaMasaNHM

                    bNadjiRasterCO(DuzinaKont, bRacunskaMasaNHM, Raster)

                    NHMRed.Item("UTIRaster") = Raster
                    NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                    NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavNHM
                End If
            Next

            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            bVozarinskiStavPoKolima = CenaPoVozu
            PrevozninaPoKolima = CenaPoVozu

            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima
        Next
    End Sub
    Public Sub bNadjiPrevozninu836902(ByRef Prevoznina As Decimal) ' AdriaKombi marš.vozovi

        Dim KolaRed, NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, Stitna As String
        Dim BrOsovina As Integer
        Dim DuzinaKontStr As String
        Dim DuzinaKont As Integer
        Dim StvMasa As Integer
        Dim RMNHM As Integer
        Dim UkupnoKola As Byte
        Dim CenaPoVozu As Decimal
        Dim PrevozninaPoKolima As Decimal = 0
        Dim PrevozninaPoKont As Decimal = 0
        Dim VozarinskiStav As Decimal
        Dim Raster As Decimal

        Dim PV As String
        Dim BMasa, BMasaKola, NaknadaZaKola, UgNaknadaPoKolima As Decimal

        Dim NHMTemp As String
        Dim ugCena As Decimal
        Dim ugTipCene As Integer
        Dim ugRetVal As String


        UkupnoKola = dtKola.Rows.Count

        Prevoznina = 0

        ''-------------------------- nalazenje cene i naknade je HCD
        'If (mStanica1 = "16517" And mStanica2 = "12498") Or (mStanica1 = "12498" And mStanica2 = "16517") Then
        '    CenaPoVozu = 4995 ' 2010: 4530 '16092010: 4330
        '    'doraditi za 2 bruto mase...
        'End If
        '' nalazenje cene i naknade je HCD

        Vlasnistvo = "1"

        ' ************************* Novi AneksCO *******************************
        'NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
        '               BrOsovina, "V", Vlasnistvo, 1, _
        '               mDatumKalk, CType(nmBMV, Int32), "9941", _
        '               1, CenaPoVozu, ugTipCene, ugRetVal)

        ' ************************* end Novi AneksCO ***************************


        Prevoznina = CenaPoVozu

        For Each KolaRed In dtKola.Rows ' rac.masa, prevoznina i stavova
            PrevozninaPoKolima = 0
            bRacunskaMasaPoKolima = 0

            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            TipKola = Left(KolaRed.Item("Tip"), 1)
            BrOsovina = KolaRed.Item("Osovine")
            Stitna = KolaRed.Item("Stitna")

            For Each NHMRed In dtNhm.Rows
                Dim bRacunskaMasaNHM As Int32
                Dim bVozarinskiStavNHM As Decimal = 0

                If NHMRed.Item("IndBrojKola") = IBK Then
                    bVozarinskiStavNHM = CenaPoVozu

                    bRacunskaMasaNHM = NHMRed.Item("Masa") + NHMRed.Item("UTITara")
                    bZaokruziMasuNa100k(bRacunskaMasaNHM)
                    bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + bRacunskaMasaNHM

                    bNadjiRasterCO(DuzinaKont, bRacunskaMasaNHM, Raster)
                    NHMTemp = NHMRed.Item("NHM")
                    'NHMRed.Item("UTIRaster") = Raster
                    NHMRed.Item("RacMasaNHM") = bRacunskaMasaNHM
                    NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavNHM
                End If
            Next

            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                           BrOsovina, "V", Vlasnistvo, Stitna, _
                           mDatumKalk, 1, Microsoft.VisualBasic.Left(NHMTemp, 4), _
                           "1", ugCena, ugTipCene, sqlVlasnistvoKola, ugRetVal)

            bVozarinskiStavPoKolima = CenaPoVozu
            PrevozninaPoKolima = ugCena

            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima
        Next
        Prevoznina = PrevozninaPoKolima
    End Sub

    Public Sub NadjiAneksNovo(ByVal inUgovor As String, ByVal inSaobracaj As String, _
                              ByVal inStanicaOd As String, ByVal inStanicaDo As String, _
                              ByVal inOsovine As Int32, ByVal inVrstaPrevoza As String, _
                              ByVal inVlasnistvoKola As String, ByVal inVrstaKola As String, _
                              ByVal inDatum As Date, ByVal inBrutoMasaVoza As Int32, ByVal inNHM As String, _
                              ByVal inUslovZaStav As Int32, ByRef outCena As Decimal, ByRef outTipCene As Int32, ByRef outVlasnistvoKola As String, _
                              ByRef outRetVal As String)

        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spString As String

        If Microsoft.VisualBasic.Right(mBrojUg, 2) = "22" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "42" Then
            spString = "roba1708.spNadjiAneksNovo3"
        Else
            spString = "spNadjiAneksNovo2"
        End If

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

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()
            outCena = spKomanda.Parameters("@outCena").Value
            outTipCene = spKomanda.Parameters("@outTipCene").Value
            outVlasnistvoKola = spKomanda.Parameters("@outVlasnistvoKola").Value
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
