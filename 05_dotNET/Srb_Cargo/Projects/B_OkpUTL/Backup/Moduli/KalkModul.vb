Imports System.Data.SqlClient
Module KalkModul

    Public Sub StavIcf(ByVal ulazUg As String, ByVal TabC As String, ByVal DatumUg As Date, ByVal MasaUg As Int32, ByVal Sta1 As String, ByVal Sta2 As String, _
                                   ByVal Uprava1 As String, ByVal TipKola1 As Char, ByVal Razred1 As Char, ByRef izlazStav As Decimal, _
                                   ByRef izlazRetVal As String)

        Dim KolaRed, NHMRed As DataRow
        izlazRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("uspIzrStavR", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim mUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipUgovor", SqlDbType.Char, 6))
        mUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipUgovor").Value = ulazUg

        Dim mTabC As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipTabC", SqlDbType.Char, 3))
        mTabC.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipTabC").Value = TabC

        Dim mDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipDatum", SqlDbType.DateTime))
        mDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipDatum").Value = DatumUg

        Dim mMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipMasa", SqlDbType.Int))
        mMasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipMasa").Value = MasaUg

        Dim tStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipSt1", SqlDbType.Char, 5))
        tStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipSt1").Value = Sta1

        Dim tStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipSt2", SqlDbType.Char, 5))
        tStanica2.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipSt2").Value = Sta2

        Dim mUprava1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipUprava", SqlDbType.Char, 2))
        mUprava1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipUprava").Value = Uprava1

        Dim mTipKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipTipK", SqlDbType.Char, 1))
        mTipKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipTipK").Value = TipKola1

        Dim mRazred As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRaz", SqlDbType.Char, 1))
        mRazred.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipRaz").Value = Razred1

        Dim mIzlazStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upStav", SqlDbType.Money)) 'Decimal
        mIzlazStav.Direction = ParameterDirection.Output
        mIzlazStav.Size = 8 '9
        mIzlazStav.Precision = 19 '18
        mIzlazStav.Scale = 2

        Dim PovratnaVrednost As SqlClient.SqlParameter
        PovratnaVrednost = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upProv", SqlDbType.Int))
        PovratnaVrednost.Direction = ParameterDirection.ReturnValue

        Try
            spKomanda.ExecuteScalar()
            Dim Pom As Int16 = spKomanda.Parameters("@upProv").Value
            If Pom <> 0 Then
                izlazRetVal = " Neuspesan upit!"
            End If

            izlazStav = spKomanda.Parameters("@upStav").Value

            '----------------------- dodati racunanje za ukupan broj UTI -----------------------
            'za slucajeve mTabelaCena=220, za vozove ne treba
            Dim PrevozninaPoKolima As Decimal = 0

            If mTabelaCena = 220 Then
                For Each KolaRed In dtKola.Rows
                    For Each NHMRed In dtNhm.Rows
                        PrevozninaPoKolima = PrevozninaPoKolima + izlazStav * bPrevozninaKoef
                    Next
                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                Next
                mPrevoznina = PrevozninaPoKolima
                izlazStav = mPrevoznina
            Else
                mPrevoznina = izlazStav.ToString
            End If

            ' proba na minimalnu prevozninu
            'If PrevozninaPoKolima <= bMinPrevoznina Then
            '    PrevozninaPoKolima = bMinPrevoznina
            'End If
            '-------------------------------------------------------------------------------------

            'mPrevoznina = izlazStav.ToString
        Catch SQLexp As SqlException
            izlazRetVal = SQLexp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            izlazRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub bNadjiMasuIStavDo25( _
     ByVal inMasa As Integer, _
     ByRef outMasa As Integer, _
     ByRef outSifraStava As String _
                                    )

        outMasa = 0
        outSifraStava = ""

        If (inMasa <= 12000.0) Then
            outSifraStava = "10"          ' 10t 
            If inMasa <= 10000.0 Then
                outMasa = 10000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 12100.0) And (inMasa <= 15800.0)) Then
            outSifraStava = "15"           '15t
            If inMasa <= 15000.0 Then
                outMasa = 15000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 15900.0) And (inMasa <= 21700.0)) Then
            outSifraStava = "20"              '20t
            If inMasa <= 20000.0 Then
                outMasa = 20000.0
            Else : outMasa = inMasa
            End If
        End If

        If (inMasa >= 21800.0) Then
            outSifraStava = "25"              '25t
            If inMasa <= 25000.0 Then
                outMasa = 25000.0
            Else : outMasa = inMasa
            End If
        End If

    End Sub
    Public Sub bNadjiMasuIStavDo45( _
     ByVal inMasa As Integer, _
     ByRef outMasa As Integer, _
     ByRef outSifraStava As String _
                                    )

        outMasa = 0
        outSifraStava = ""

        If (inMasa <= 12900.0) Then
            outSifraStava = "10"          ' 10t 
            If inMasa <= 10000.0 Then
                outMasa = 10000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 13000.0) And (inMasa <= 19000.0)) Then
            outSifraStava = "15"           '15t
            If inMasa <= 15000.0 Then
                outMasa = 15000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 19100.0) And (inMasa <= 23800.0)) Then
            outSifraStava = "20"              '20t
            If inMasa <= 20000.0 Then
                outMasa = 20000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 23900.0) And (inMasa <= 29100.0)) Then
            outSifraStava = "25"              '25t
            If inMasa <= 25000.0 Then
                outMasa = 25000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 29200.0) And (inMasa <= 33700.0)) Then
            outSifraStava = "30"              '30t
            If inMasa <= 30000.0 Then
                outMasa = 30000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 33800.0) And (inMasa <= 38200.0)) Then
            outSifraStava = "35"              '35t
            If inMasa <= 35000.0 Then
                outMasa = 35000.0
            Else : outMasa = inMasa
            End If
        End If


        If ((inMasa >= 38300.0) And (inMasa <= 42900.0)) Then
            outSifraStava = "40"              '40t
            If inMasa <= 40000.0 Then
                outMasa = 40000.0
            Else : outMasa = inMasa
            End If
        End If



        If (inMasa >= 43000.0) Then
            outSifraStava = "45"              '45t
            If inMasa <= 45000.0 Then
                outMasa = 45000.0
            Else : outMasa = inMasa
            End If
        End If

    End Sub

    Public Sub bNadjiMax2( _
                                          ByVal inA As Decimal, _
                                          ByVal inB As Decimal, _
                                          ByRef outMax2 As Decimal)

        If (inA >= inB) Then
            outMax2 = inA
        Else
            outMax2 = inB
        End If

    End Sub
    Public Sub bNadjiMax3( _
                ByVal inA As Decimal, _
                ByVal inB As Decimal, _
                ByVal inC As Decimal, _
                ByRef outMax3 As Decimal, _
                ByRef outRazredMax As Integer)

        bNadjiMax2(inA, inB, outMax3)
        bNadjiMax2(outMax3, inC, outMax3)

        If outMax3 = inC Then
            outRazredMax = 3
        End If

        If outMax3 = inB Then
            outRazredMax = 2
        End If

        If outMax3 = inA Then
            outRazredMax = 1
        End If

    End Sub

    Public Sub bKorigujRacMasePoRazredima( _
              ByVal inMasa1 As Integer, _
              ByVal inMasa2 As Integer, _
              ByVal inMasa3 As Integer, _
              ByVal inOsovine As Integer, _
              ByVal inDoTona As String, _
              ByRef outMasa1 As Integer, _
              ByRef outMasa2 As Integer, _
              ByRef outMasa3 As Integer, _
              ByRef outStav As String)

        Dim ZaokMasaPoKolima As Integer
        Dim PomMasa1 As Integer
        Dim PomMasa2 As Integer
        Dim PomMasa3 As Integer
        Dim RMax As Integer    ' razred sa najvecom masom
        Dim PV As String



        outMasa1 = inMasa1
        outMasa2 = inMasa2
        outMasa3 = inMasa3


        ZaokMasaPoKolima = inMasa1 + inMasa2 + inMasa3

        bZaokrMasuNaOsovineP(ZaokMasaPoKolima, bSvaTovarena, inOsovine, PomMasa1)

        bNadjiMax3(inMasa1, inMasa2, inMasa3, PomMasa2, RMax)

        If inDoTona = "25" Then
            bNadjiMasuIStavDo25(PomMasa1, PomMasa3, outStav)
        ElseIf inDoTona = "45" Then
            'If ((bVrstaSaobracaja = 2) Or (bVrstaSaobracaja = 3)) Then
            bNadjiMasuIStavGM("122", PomMasa1, bTkm, RMax, PomMasa3, outStav, PV)  ' proveriti da li je Rmax
            'Else
            'bNadjiMasuIStavDo45(PomMasa1, PomMasa3, outStav)
            'End If

        End If

        ' dodavanje razlike na najvecu masu ( ako su iste - na skuplju )

        If RMax = 1 Then
            outMasa1 = outMasa1 + (PomMasa3 - ZaokMasaPoKolima)
        End If

        If RMax = 2 Then
            outMasa2 = outMasa2 + (PomMasa3 - ZaokMasaPoKolima)
        End If

        If RMax = 3 Then
            outMasa3 = outMasa3 + (PomMasa3 - ZaokMasaPoKolima)
        End If

    End Sub

    Public Sub bZaokrMasuNaOsovineP( _
            ByVal inMasa As Integer, _
            ByVal inTovarena As String, _
            ByVal inOsovine As Integer, _
            ByRef outMasa As Integer)


        If inTovarena = "TK" Then
            ' $$8606$$uklopiti uslov za 992110 ...
            If Not (NHM4 = "8606") Then
                If inMasa < inOsovine * 5000 Then
                    outMasa = inOsovine * 5000
                Else
                    outMasa = inMasa
                End If
            Else                 '8606                
                If inMasa < 10000 Then
                    outMasa = 10000
                Else
                    outMasa = inMasa
                End If
            End If
        End If

        If bNHMKao8606 Then
            If inMasa < 10000 Then
                outMasa = 10000
            Else
                outMasa = inMasa
            End If
        End If

        If (inTovarena = "PK") Then
            If inMasa < 10000 Then
                outMasa = 10000
            Else
                outMasa = inMasa
            End If
        End If

    End Sub
    Public Sub bZaokrMasuNaOsovineINadjiKolKoefTEA( _
                ByVal inMasa As Integer, _
                ByVal inTara As Integer, _
                ByVal inGrTovarenja As Integer, _
                ByVal inVlasnistvo As String, _
                ByVal inSpecijalna As String, _
                ByVal inSerija As String, _
                ByVal inIFrigo As String, _
                ByVal inTovarena As String, _
                ByVal inOsovine As Integer, _
                ByRef outMasa As Integer, _
                ByRef outKolKoef As Decimal)

        ' inMasa - ulazna masa u kg
        ' inVlasnistvo - 'Z' - zeleznicka, 'P' - privatna, 'I' - iznajmljena, 'S' - sinska
        ' inSpecijalna - '1' - obicna, '2' - specijalna 
        ' inSerija - celokupna slovna oznaka serije
        ' inPoTEA - 'D' - ako posiljka podleze samo TEA tarifi, 'N' - ako se primenjuje ugovor
        ' inIFrigo - 'D' - ako su Interfrigo kola, inace 'N'
        ' inTovarena - 'TK' - tovarena, 'PK' - prazna
        ' inOsovine - broj osovina
        ' outMasa - izlazna minimalna masa
        ' outKolKoef - izlazni koeficijent

        outKolKoef = 1
        If inMasa < 5000 * inOsovine Then
            outMasa = 5000 * inOsovine
        Else
            outMasa = inMasa
        End If

        If inVlasnistvo = "Z" Then
            'Microsoft.VisualBasic.Mid(inSerija, 1, 1)

            If Microsoft.VisualBasic.Mid(inSerija, 1, 1) = "I" Then
                outMasa = (20 * inOsovine - inTara / 1000) / 2              ' proveriti jedinice
                outKolKoef = 1
            ElseIf Microsoft.VisualBasic.Mid(inSerija, 1, 1) = "U" Or Microsoft.VisualBasic.Mid(inSerija, 1, 1) = "Z" Or _
                   Microsoft.VisualBasic.Mid(inSerija, 1, 2) = "Ua" Or Microsoft.VisualBasic.Mid(inSerija, 1, 2) = "Ta" Then

                If inSpecijalna = "1" Then   ' obicna
                    outKolKoef = 1
                Else                                  ' specijalna
                    outKolKoef = 1.2
                End If

            ElseIf Microsoft.VisualBasic.Mid(inSerija, 1, 1) = "T" Then
                outKolKoef = 1.3
                ' ukljuciti telegram od 8.6.2001.

            ElseIf Microsoft.VisualBasic.Mid(inSerija, 1, 1) = "L" Or Microsoft.VisualBasic.Mid(inSerija, 1, 1) = "S" Then
                outMasa = 20000
                outKolKoef = 1
            End If

            If inGrTovarenja > 80 And inGrTovarenja < 120 Then
                'If inPoTEA = "N" Then 'kod ugovora - zasto 18000!
                outMasa = 18000
                'End If
                outKolKoef = 1.4
            End If
            If inGrTovarenja >= 120 Then
                'If inPoTEA = "N" Then
                outMasa = 18000
                'End If
            outKolKoef = 1.8
        End If

        ElseIf (inVlasnistvo = "P" Or inVlasnistvo = "I") Then
        'dodati checkbox interfrigo i izmeniti proceduru o kolima

        If inIFrigo = "D" Then      ' interfrigo
            outKolKoef = 1
        ElseIf inIFrigo = "N" Then
            If inTovarena = "PK" Then
                outKolKoef = 1
            Else
                outKolKoef = 0.8
            End If
        End If

        ElseIf (inVlasnistvo = "S") Then
        outKolKoef = 1
        End If

    End Sub
    Public Sub bZaokruziMasuNa100k(ByRef Masa As Integer)
        Masa = Int((Masa + 99) / 100) * 100
    End Sub

    Public Sub bZaokruziMasuDenc( _
            ByVal inMasa As Integer, _
            ByRef outMasa As Integer)

        If inMasa < 1000 Then
            outMasa = Int((inMasa + 49) / 50) * 50
        Else
            outMasa = Int((inMasa + 99) / 100) * 100
        End If

    End Sub

    Public Sub bNadjiTipKola( _
            ByVal inVrsta As Char, _
            ByVal inTovarena As String, _
            ByVal inVlasnistvo As Char, _
            ByRef outTip As Char, _
            ByRef outKolKoef As Decimal)

        'obicna(1) ili specijalna(2)
        'tovarena(TK) ili prazna(PK)
        'zeleznicka(Z),privatna(P), u zakupu(I)

        Dim p1 As Integer
        Dim p2 As Integer
        Dim p3 As Integer
        Dim p123 As Integer


        If inVrsta = "1" Then p1 = 1 ' obicna
        If inVrsta = "2" Then p1 = 2 ' specijalna

        If inTovarena = "TK" Then p2 = 1 ' tovarena
        If inTovarena = "PK" Then p2 = 2 ' prazna

        If inVlasnistvo = "Z" Then p3 = 1 ' zeleznicka" Then
        If inVlasnistvo = "P" Then p3 = 2 ' privatna" Then
        If inVlasnistvo = "I" Then p3 = 2 ' iznajmljena ( u zakupu )

        p123 = p1 * 100 + p2 * 10 + p3


        outTip = "1"
        outKolKoef = 1

        Select Case 123
            Case 111
                outKolKoef = 1.0
                outTip = "1"
            Case 211
                outKolKoef = 1.3
                outTip = "2"
            Case 112
                outKolKoef = 0.8
                outTip = "3"
            Case 212
                outKolKoef = 0.7
                outTip = "4"
            Case 113
                outKolKoef = 0.8
                outTip = "5"
            Case 213
                outKolKoef = 0.8
                outTip = "6"
            Case 121, 221, 122, 222, 123, 223
                outKolKoef = 0.3
                outTip = "7"
        End Select

    End Sub

    'Public Sub bPostaviTestPodatke()
    '    Dim Str As String
    '    Dim m As Int16

    '    Dim NHMRed As DataRow
    '    Dim KolaRed As DataRow

    '    ' upis - ciklus po kolima odavde

    '    KolaRed = dtKola.NewRow()
    '    KolaRed.Item("IndBrojKola") = "317270902222"
    '    KolaRed.Item("Uprava") = "55"
    '    KolaRed.Item("Vlasnik") = "Z"            ' Z, P, I
    '    KolaRed.Item("Serija") = "Tabc"
    '    KolaRed.Item("Vrsta") = "1"    ' 1 - obicna,  2 - specijalna
    '    KolaRed.Item("Osovine") = 4
    '    KolaRed.Item("Tara") = 5000
    '    KolaRed.Item("GrTov") = 50000
    '    KolaRed.Item("Stitna") = "D"
    '    KolaRed.Item("Tip") = "5"
    '    KolaRed.Item("Prevoznina") = 0
    '    KolaRed.Item("Naknada") = 0
    '    KolaRed.Item("ICF") = "D"
    '    dtKola.Rows.Add(KolaRed)


    '    ' upis - ciklus po robi odavde

    '    NHMRed = dtNhm.NewRow()
    '    NHMRed.Item("IndBrojKola") = "317270902222"
    '    NHMRed.Item("NHM") = "100100"
    '    NHMRed.Item("Masa") = 15910
    '    NHMRed.Item("R") = "1"
    '    NHMRed.Item("RID") = "0"
    '    NHMRed.Item("UTI") = "20"
    '    dtNhm.Rows.Add(NHMRed)

    '    ' upis - ciklus po robi dovde

    '    NHMRed = dtNhm.NewRow()
    '    NHMRed.Item("IndBrojKola") = "317270902222"
    '    NHMRed.Item("NHM") = "100200"
    '    NHMRed.Item("Masa") = 5412
    '    NHMRed.Item("R") = "2"
    '    NHMRed.Item("RID") = "0"
    '    NHMRed.Item("UTI") = "20"
    '    dtNhm.Rows.Add(NHMRed)

    '    NHMRed = dtNhm.NewRow()
    '    NHMRed.Item("IndBrojKola") = "317270902222"
    '    NHMRed.Item("NHM") = "100300"
    '    NHMRed.Item("Masa") = 2325
    '    NHMRed.Item("R") = "3"
    '    NHMRed.Item("RID") = "0"
    '    NHMRed.Item("UTI") = "40"
    '    dtNhm.Rows.Add(NHMRed)



    '    KolaRed = dtKola.NewRow()
    '    KolaRed.Item("IndBrojKola") = "317270903333"
    '    KolaRed.Item("Uprava") = "44"
    '    KolaRed.Item("Vlasnik") = "P"            ' Z, P, I
    '    KolaRed.Item("Serija") = "Gcde"
    '    KolaRed.Item("Vrsta") = "2"    ' 1 - obicna,  2 - specijalna
    '    KolaRed.Item("Osovine") = 8
    '    KolaRed.Item("Tara") = 4000
    '    KolaRed.Item("GrTov") = 40000
    '    KolaRed.Item("Stitna") = "D"
    '    KolaRed.Item("Tip") = "2"
    '    KolaRed.Item("Prevoznina") = 0
    '    KolaRed.Item("Naknada") = 0
    '    KolaRed.Item("ICF") = "N"
    '    dtKola.Rows.Add(KolaRed)


    '    ' upis - ciklus po robi odavde

    '    NHMRed = dtNhm.NewRow()
    '    NHMRed.Item("IndBrojKola") = "317270903333"
    '    NHMRed.Item("NHM") = "100100"
    '    NHMRed.Item("Masa") = 2213
    '    NHMRed.Item("R") = "1"
    '    NHMRed.Item("RID") = "0"
    '    NHMRed.Item("UTI") = "20"
    '    dtNhm.Rows.Add(NHMRed)

    '    '' upis - ciklus po robi dovde

    '    NHMRed = dtNhm.NewRow()
    '    NHMRed.Item("IndBrojKola") = "317270903333"
    '    NHMRed.Item("NHM") = "100200"
    '    NHMRed.Item("Masa") = 4412
    '    NHMRed.Item("R") = "2"
    '    NHMRed.Item("RID") = "0"
    '    NHMRed.Item("UTI") = "20"
    '    dtNhm.Rows.Add(NHMRed)

    '    NHMRed = dtNhm.NewRow()
    '    NHMRed.Item("IndBrojKola") = "317270903333"
    '    NHMRed.Item("NHM") = "100300"
    '    NHMRed.Item("Masa") = 7325
    '    NHMRed.Item("R") = "3"
    '    NHMRed.Item("RID") = "0"
    '    NHMRed.Item("UTI") = "20"
    '    dtNhm.Rows.Add(NHMRed)


    '    mTabelaCena = "381"
    '    mDatumKalk = "5.4.2006"
    '    btkm = 555
    '    IzborSaobracaja = "2"
    '    bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
    '    mTarifa = "38"
    '    bVrstaPosiljke = "K"
    '    bVrstaStanice = "G"
    '    bVlasnistvo = "Z"
    '    bTovarenaPrazna = "TK"
    '    bRedovanOrocen = "R"
    '    bValuta = "84"

    '    If KolaRed.Item("Tip") = 7 Then
    '        bTovarenaPrazna = "PK"
    '    Else
    '        bTovarenaPrazna = "TK"
    '    End If


    '    If dtNhm.Rows(0).Item("NHM") = "992100" Or dtNhm.Rows(0).Item("NHM") = "992200" Then
    '        bSvaTovarena = "PK"
    '    Else : bSvaTovarena = "TK"
    '    End If

    '  End Sub
    Public Sub bNadjiSveIzZSKoefPos(ByVal inVrstaSaobracaja As Integer, _
                                                                ByVal inTarifa As String, _
                                                                ByVal inVrstaPosiljke As String, _
                                                                ByVal inVrstaStanice As String, _
                                                                ByVal inVlasnistvoKola As String, _
                                                                ByVal inTovarenaPrazna As String, _
                                                                ByRef outMinPrevoznina As Decimal, _
                                                                ByRef outDodPrevoznina As Decimal, _
                                                                ByRef outKoef As Decimal, _
                                                                ByRef outKoefNak As Decimal, _
                                                                ByRef outKoefInd As Decimal, _
                                                                ByRef outKoefInd1 As Decimal, _
                                                                ByRef outKoefRid As Decimal, _
                                                                ByRef outPouzece As Decimal, _
                                                                ByRef outPredujam As Decimal, _
                                                                ByVal inDatum As Date, _
                                                                ByVal inRedovanOrocen As String, _
                                                                ByVal inValuta As String, _
                                                                ByRef outRetVal As String)
        ' TovarenaPrazna - tovarena, prazna, tovaren UTI, prazan UTI
        outRetVal = ""

        Dim spKomanda As New SqlClient.SqlCommand("bspNadjiSveIzZSKoefPos", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaSaobracaja", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaSaobracaja").Value = inVrstaSaobracaja

        Dim ulTarifa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTarifa", SqlDbType.Char, 2))
        ulTarifa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTarifa").Value = inTarifa

        Dim ulVrstaPosiljke As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaPosiljke", SqlDbType.Char, 1))
        ulVrstaPosiljke.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaPosiljke").Value = inVrstaPosiljke

        Dim ulVrstastanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaStanice", SqlDbType.Char, 1))
        ulVrstastanice.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaStanice").Value = inVrstaStanice

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 1))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulTovarenaPrazna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTovarenaPrazna", SqlDbType.Char, 2))
        ulTovarenaPrazna.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTovarenaPrazna").Value = inTovarenaPrazna

        Dim izlMinPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinPrevoznina", SqlDbType.Decimal))
        izlMinPrevoznina.Size = 9
        izlMinPrevoznina.Precision = 10
        izlMinPrevoznina.Scale = 2
        izlMinPrevoznina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinPrevoznina").Value = outMinPrevoznina

        Dim izlDodPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outDodPrevoznina", SqlDbType.Decimal))
        izlDodPrevoznina.Size = 9
        izlDodPrevoznina.Precision = 10
        izlDodPrevoznina.Scale = 2
        izlDodPrevoznina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outDodPrevoznina").Value = outDodPrevoznina

        Dim izlKoef As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKoef", SqlDbType.Decimal))
        izlKoef.Size = 9
        izlKoef.Precision = 10
        izlKoef.Scale = 2
        izlKoef.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKoef").Value = outKoef

        Dim izlKoefNak As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKoefNak", SqlDbType.Decimal))
        izlKoefNak.Size = 9
        izlKoefNak.Precision = 10
        izlKoefNak.Scale = 2
        izlKoefNak.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKoefNak").Value = outKoefNak

        Dim izlKoefInd As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKoefInd", SqlDbType.Decimal))
        izlKoefInd.Size = 9
        izlKoefInd.Precision = 10
        izlKoefInd.Scale = 2
        izlKoefInd.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKoefInd").Value = outKoefInd

        Dim izlKoefInd1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKoefInd1", SqlDbType.Decimal))
        izlKoefInd1.Size = 9
        izlKoefInd1.Precision = 10
        izlKoefInd1.Scale = 2
        izlKoefInd1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKoefInd1").Value = outKoefInd1

        Dim izlKoefRid As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKoefRid", SqlDbType.Decimal))
        izlKoefRid.Size = 9
        izlKoefRid.Precision = 10
        izlKoefRid.Scale = 2
        izlKoefRid.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKoefRid").Value = outKoefRid

        Dim izlPouzece As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPouzece", SqlDbType.Decimal))
        izlPouzece.Size = 9
        izlPouzece.Precision = 10
        izlPouzece.Scale = 2
        izlPouzece.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPouzece").Value = outPouzece

        Dim izlPredujam As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPredujam", SqlDbType.Decimal))
        izlPredujam.Size = 9
        izlPredujam.Precision = 10
        izlPredujam.Scale = 2
        izlPredujam.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPredujam").Value = outPredujam

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = inDatum

        Dim ulRedovanOrocen As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRedovanOrocen", SqlDbType.Char, 1))
        ulRedovanOrocen.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRedovanOrocen").Value = inRedovanOrocen

        Dim ulValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inValuta", SqlDbType.Char, 2))
        ulValuta.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inValuta").Value = inValuta

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            spKomanda.ExecuteScalar()
            'Dim Pom As Int16 = spKomanda.Parameters("@PovrVrednost").Value
            'Pom = spKomanda.Parameters("@PovrVrednost").Value
            'If Pom <> 0 Then outRetVal = " Neuspesan upit!" 'Pom = spKomanda.Parameters("@PovrVrednost").Value

            outMinPrevoznina = spKomanda.Parameters("@outMinPrevoznina").Value
            outDodPrevoznina = spKomanda.Parameters("@outDodPrevoznina").Value
            outKoef = spKomanda.Parameters("@outKoef").Value
            outKoefNak = spKomanda.Parameters("@outKoefNak").Value
            outKoefInd = spKomanda.Parameters("@outKoefInd").Value
            outKoefInd1 = spKomanda.Parameters("@outKoefInd1").Value
            outKoefRid = spKomanda.Parameters("@outKoefRid").Value
            outPouzece = spKomanda.Parameters("@outPouzece").Value
            outPredujam = spKomanda.Parameters("@outPredujam").Value
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
    Public Sub bNadjiRasterTEA(ByVal inDuzinaKont As String, ByVal inStvMasa As Integer, ByRef outRaster As Decimal)

        Select Case inDuzinaKont
            Case "20"
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
            Case "25"
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
    Public Sub bZaokruziNaDeseteNavise(ByRef izlaz As Decimal)
        ' ulaz - decimalan broj sa dve decimale
        ' izlaz - zaokruzen na desete delove navise

        izlaz = Int((izlaz + 0.099) * 10) / 10

    End Sub
    Public Sub bZaokruziNaCeleNavise(ByRef izlaz As Decimal)
        ' ulaz - decimalan broj sa dve decimale
        ' izlaz - zaokruzen na cele navise

        izlaz = (Int(izlaz + 0.99) * 10) / 10

    End Sub
    Public Sub bNadjiRIDKoef(ByVal inVrstaSaobr As Integer, _
                                          ByVal inRIDRazred As Int16, _
                                          ByRef outRIDKoef As Decimal)

        If inRIDRazred = 1 Or inRIDRazred = 7 Then
            outRIDKoef = 2
        End If

        If inRIDRazred = 2 Then
            If inVrstaSaobr = 2 Or inVrstaSaobr = 3 Then
                outRIDKoef = 1.1
            End If
            If inVrstaSaobr = 4 Then
                outRIDKoef = 1.3
            End If

        End If

    End Sub

    Public Sub bNadjiVozarinskiStav(ByVal inTabelaCena As String, _
                                                    ByVal inDatumKalk As Date, _
                                                    ByVal inMasa As Integer, _
                                                    ByVal intkm As Integer, _
                                                    ByVal inRazred As String, _
                                                    ByRef outVozarinskiStav As Decimal, _
                                                    ByRef outRetVal As String)

        outRetVal = ""

        Dim outProv As Integer = 0

        Dim spKomanda As New SqlClient.SqlCommand("roba.uspIzrStav", DbVezaCene)
        spKomanda.CommandType = CommandType.StoredProcedure

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

        Dim upProv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upProv", SqlDbType.Int))
        upProv.Direction = ParameterDirection.Output
        spKomanda.Parameters("@upProv").Value = outProv

        'Dim PovratnaVrednost As SqlClient.SqlParameter
        'PovratnaVrednost = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@PovrVrednost", SqlDbType.Int))
        'PovratnaVrednost.Direction = ParameterDirection.ReturnValue

        Try
            'cnRoba.Open()
            If DbVezaCene.State = ConnectionState.Closed Then
                DbVezaCene.Open()
            End If

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
            DbVezaCene.Close()
            spKomanda.Dispose()
        End Try
    End Sub

    Public Sub bNadjiVozarinskiStavKont(ByVal inTabelaCena As String, _
                                                       ByVal inDatumKalk As Date, _
                                                       ByVal inKombinacija As String, _
                                                       ByVal intkm As Integer, _
                                                       ByRef outVozarinskiStav As Decimal, _
                                                       ByRef outRetVal As String)

        outRetVal = ""

        Dim outProv As Integer = 0

        Dim spKomanda As New SqlClient.SqlCommand("dbo.uspIzrStavK", DbVezaCene)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulTabelaCena As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipTabC", SqlDbType.Char, 3))
        ulTabelaCena.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipTabC").Value = inTabelaCena

        Dim ulDatumKalk As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipDatum", SqlDbType.DateTime))
        ulDatumKalk.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipDatum").Value = inDatumKalk

        Dim ulKombinacija As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipKomb", SqlDbType.Char))
        ulKombinacija.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipKomb").Value = inKombinacija

        Dim ultkm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipkm", SqlDbType.Int))
        ultkm.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipkm").Value = intkm

        Dim izVozarinskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upStav", SqlDbType.Money))
        izVozarinskiStav.Direction = ParameterDirection.Output
        izVozarinskiStav.Size = 8
        izVozarinskiStav.Precision = 19
        izVozarinskiStav.Scale = 2

        Dim upProv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upProv", SqlDbType.Int))
        upProv.Direction = ParameterDirection.Output
        spKomanda.Parameters("@upProv").Value = outProv

        'Dim PovratnaVrednost As SqlClient.SqlParameter
        'PovratnaVrednost = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@PovrVrednost", SqlDbType.Int))
        'PovratnaVrednost.Direction = ParameterDirection.ReturnValue

        Try
            'cnRoba.Open()
            If DbVezaCene.State = ConnectionState.Closed Then
                DbVezaCene.Open()
            End If

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
            DbVezaCene.Close()
            spKomanda.Dispose()
        End Try
    End Sub

    Public Sub bNadjiVozarinskiStavKontTEA(ByVal inTabelaCena As String, _
                                                       ByVal inDatumKalk As Date, _
                                                       ByVal intkm As Integer, _
                                                       ByRef outVozarinskiStav As Decimal, _
                                                       ByRef outRetVal As String)

        outRetVal = ""

        Dim outProv As Integer = 0

        Dim spKomanda As New SqlClient.SqlCommand("uspIzrStavKTea", DbVezaCene)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulTabelaCena As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipTabC", SqlDbType.Char, 3))
        ulTabelaCena.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipTabC").Value = inTabelaCena

        Dim ulDatumKalk As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipDatum", SqlDbType.DateTime))
        ulDatumKalk.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipDatum").Value = inDatumKalk

        Dim ultkm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipkm", SqlDbType.Int))
        ultkm.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipkm").Value = intkm

        Dim izVozarinskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upStav", SqlDbType.Money))
        izVozarinskiStav.Direction = ParameterDirection.Output
        izVozarinskiStav.Size = 8
        izVozarinskiStav.Precision = 19
        izVozarinskiStav.Scale = 2

        Dim upProv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upProv", SqlDbType.Int))
        upProv.Direction = ParameterDirection.Output
        spKomanda.Parameters("@upProv").Value = outProv

        'Dim PovratnaVrednost As SqlClient.SqlParameter
        'PovratnaVrednost = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@PovrVrednost", SqlDbType.Int))
        'PovratnaVrednost.Direction = ParameterDirection.ReturnValue

        Try
            'cnRoba.Open()

            If DbVezaCene.State = ConnectionState.Closed Then
                DbVezaCene.Open()
            End If
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
            DbVezaCene.Close()
            spKomanda.Dispose()
        End Try
    End Sub

    Public Sub bNadjiPrevozninu00UI(ByVal Tabela As String, ByRef Prevoznina As Decimal)    ' osnova je bNadjiPrevozninu00COUI
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
        Dim RacMasaPoKolima As Integer
        Dim DoTona As String = "25"
        Dim bVrsta00tranzita As Byte
        Dim inReka As String = ""

        Prevoznina = 0
        bRedovanOrocen = "R"
        bVrstaStanice = "M"
        DoTona = "45"

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
                If Microsoft.VisualBasic.Left(_mNHM, 4) = "9931" Or Microsoft.VisualBasic.Left(_mNHM, 4) = "9941" Then
                    TovarenaPrazna = "TK"
                End If

                Dim bRetValLok As String = ""

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "36", bVrstaPosiljke, "M", Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)



                pubSerijaKola = KolaRed.Item("Serija") '## T kola
                pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola
                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

                'Dim KPK As Decimal = 1                             zbog ugovora

                'bNadjiKolPrevKoef(mBrojUg, TipKola, "0", "0", "00", "00", "00", KPK, PV)

                'If PV = "" Then
                '    KolKoef = KPK
                'End If

                bPrevozninaKoef = 1

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

                    ' Dodato zbog praznih kola
                    NHMTemp = NHMRed.Item("NHM")

                    'Dim bNHMKao8606 = False
                    If NHMTemp = "992110" Or NHMTemp = "992120" Or NHMTemp = "992130" Or NHMTemp = "992140" Or _
                        NHMTemp = "992210" Or NHMTemp = "992220" Or NHMTemp = "992230" Or NHMTemp = "992240" Or _
                        Microsoft.VisualBasic.Left(NHMTemp, 4) = "8601" Or Microsoft.VisualBasic.Left(NHMTemp, 4) = "8602" Or _
                        Microsoft.VisualBasic.Left(NHMTemp, 4) = "8603" Or Microsoft.VisualBasic.Left(NHMTemp, 4) = "8604" Or _
                        Microsoft.VisualBasic.Left(NHMTemp, 4) = "8605" Then
                        TovarenaPrazna = "TK"
                        bNHMKao8606 = True
                    Else
                        bNHMKao8606 = False
                    End If


                    Dim NHM4 As String = (Microsoft.VisualBasic.Left(NHMTemp, 4))
                    If (NHM4 = "9921" Or NHM4 = "9922" _
                     Or NHM4 = "8601" Or NHM4 = "8602" Or NHM4 = "8603" _
                     Or NHM4 = "8604" Or NHM4 = "8605" Or NHM4 = "8606") _
                     Then

                        'ponovo 01.12.2014
                        Masa1R = NHMRed.Item("Masa")
                        Masa2R = 0                          'proveriti
                        Masa3R = 0                          'proveriti
                        bZaokruziMasuNa100k(Masa1R)
                        'ponovo 01.12.2014

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

                        ' $$8606$$uporediti sa RSD delom ovo dole
                        'If NHM4 = "8606" Or (bNHMKao8606) Then
                        '    TovarenaPrazna = "TK"
                        '    Vlasnistvo = "Z"
                        'End If
                        ' $$8606$$uporediti sa RSD delom ovo gore

                        ' dodato 14.8.2013
                        If NHM4 = "8606" Or (bNHMKao8606) Then
                            TovarenaPrazna = "PK"
                            'Vlasnistvo = "Z"
                        End If
                        ' dodato 14.8.2013

                        Dim TovPraMP As String
                        Dim VlasnMP As String
                        bPraznaKaoRobaTar2015(mDatumKalk, NHMTemp, TovPraMP, VlasnMP)
                        If TovPraMP = "" Then
                            TovPraMP = TovarenaPrazna
                        End If
                        If VlasnMP = "" Then
                            VlasnMP = Vlasnistvo
                        End If
                        bNadjiSveIzZSKoefPos(2, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                                             TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                             bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                        ' Tarifa 2015
                        'bNadjiSveIzZSKoefPos(2, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                        '                     TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                        '                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                        If (mDatumKalk >= #2/1/2008#) And ((NHM4 = "9921" Or NHM4 = "9922") And Not (bNHMKao8606)) Then
                            TonskiStav = "45"
                        Else

                        End If
                    End If
                    ' Dodato zbog praznih kola


                    TonskiStavInteger = CType(TonskiStav, Integer)
                    MasaTemp = TonskiStavInteger * 1000

                    ' prevoznine po razredima:


                    'Dodatak zbog datuma vazenja Prodosa i ostalih ugovora

                    Dim temp_DatumUI As Date = mDatumKalk



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


                    'bNadjiPrevKoefCOUI(PrevKoef)

                    'bDaLiJeNafta(dtNhm.Rows(0).Item("NHM"), bNaftaJe)
                    'If bNaftaJe = True Then
                    '    PrevKoef = 1
                    'End If

                    PrevozninaPoKolima = PrevozninaPoKolima * PrevKoef
                    bZaokruziNaDeseteNavise(PrevozninaPoKolima)


                    ' Testiraj na minimalnu prevozninu
                    RacMasaPoKolima = Masa1R + Masa2R + Masa3R
                    bRacunskaMasaPoKolima = RacMasaPoKolima

                    'vracanje datuma
                    mDatumKalk = temp_DatumUI

                    ' *****COANEKS

                    'Dim ugUslovZaStav As Integer = TonskiStavInteger
                    'Dim ugCena As Decimal
                    'Dim ugTipCene As Integer
                    'Dim ugRetVal As String = ""
                    'Dim ugDodatak As Decimal
                    'Dim ugKoeficijent As Decimal

                    '' zbog 090801,02
                    'If mBrojUg = "090801" Or mBrojUg = "090802" Then
                    '    bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, DoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                    '    TonskiStavInteger = CType(TonskiStav, Integer)
                    '    ugUslovZaStav = TonskiStavInteger
                    '    MasaTemp = TonskiStavInteger * 1000
                    'End If
                    '' zbog 090801,02

                    '' izracunati promenljivu "Stitna"
                    'NadjiAneks(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                    '            BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, mDatumKalk, Microsoft.VisualBasic.Left(NHMTemp, 4), ugUslovZaStav, _
                    '            ugCena, ugTipCene, ugRetVal)

                    'If ugTipCene = 1 Then
                    '    ugKoeficijent = ugCena
                    'End If

                    'If (ugRetVal = "") Then
                    '    Dim RacMasaZaAneks As Decimal
                    '    bNadjiRacMasuZaAneks(IBK, ugTipCene, RacMasaZaAneks)

                    '    If ugTipCene = 12 Then
                    '        RacMasaZaAneks = RacMasaZaAneks '+ KolaRed.Item("Tara")
                    '    End If
                    '    If (ugTipCene = 13) Then
                    '        If (RacMasaZaAneks >= 25000) Then
                    '            bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                    '                             RacMasaZaAneks, ugCena, _
                    '                             RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)
                    '            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    '            bVozarinskiStavPoKolima = ugCena
                    '        End If
                    '    Else

                    '        'Usaglasiti mase - ulazne parametre: 
                    '        bKorigujPoAneksu(ugTipCene, PrevozninaPoKolima, ugKoeficijent, _
                    '                         RacMasaZaAneks, ugCena, _
                    '                         RacMasaZaAneks, bTkm, ugDodatak, PrevozninaPoKolima)
                    '        If ((ugTipCene = 3) And (ugUslovZaStav = TonskiStavInteger)) Then
                    '            'ponovo, jer je nov stav:
                    '            VozarinskiStav = ugCena
                    '            Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    '            If Not (Masa1R = 0) Then
                    '                bVozarinskiStavPoKolima = VozarinskiStav
                    '            End If
                    '            Prev2R = Prev2R * bPrevozninaKoef

                    '            Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    '            If Not (Masa2R = 0) And (Masa1R = 0) Then
                    '                bVozarinskiStavPoKolima = VozarinskiStav
                    '            End If
                    '            Prev2R = Prev2R * bPrevozninaKoef

                    '            Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 1000
                    '            If Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0) Then
                    '                bVozarinskiStavPoKolima = VozarinskiStav
                    '            End If
                    '            Prev3R = Prev3R * bPrevozninaKoef

                    '            PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!
                    '            bZaokruziNaDeseteNavise(PrevozninaPoKolima)

                    '        End If

                    '        bVozarinskiStavPoKolima = ugCena
                    '        'bRacunskaMasaPoKolima = RacMasaZaAneks
                    '    End If
                    'End If

                    ' *****COANEKS
                    'If ugTipCene = 4 Or ugTipCene = 5 Then
                    '    bMinPrevoznina = 0
                    'End If

                    'If ugTipCene = 5 Then
                    '    PrevozninaPoKolima = 0
                    '    Prevoznina = ugCena
                    'End If

                    'If Not (ugTipCene = 12) Then
                    bZaokruziNaDeseteNavise(PrevozninaPoKolima)
                    'End If

                    'If ugTipCene <> 10 Then
                    If PrevozninaPoKolima <= bMinPrevoznina Then
                        PrevozninaPoKolima = bMinPrevoznina
                        'End If
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

                For Each NHMRed In dtNhm.Rows   '  petlja po robi
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
                        If bPorekloRobe = 0 Then
                            NHMRed.Item("PorekloRobe") = 0
                        Else
                            NHMRed.Item("PorekloRobe") = 1
                        End If
                    End If
                Next


            Next    ' petlja po kolima

        Else
            ' nema ni kola ni prevoznine
        End If

    End Sub
    Public Sub bNadjiPrevozninuNeNulaT(ByVal TarifaK As String, ByVal Tabela As String, ByRef Prevoznina As Decimal)
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

        If TarifaK = "44" Or TarifaK = "45" Then
            If UkupnaMasa < 10000 * UkupnoKola Then
                UkupnaMasa = 10000 * UkupnoKola
            End If
        End If

        If TarifaK = "46" Then
            If UkupnaMasa < 500000 Then
                UkupnaMasa = 500000
            End If
        End If

        bZaokrMasuNaOsovineP(UkupnaMasa, bSvaTovarena, UkupnoOsovina, UkupnaMasa)


        ProsecnaMasa = UkupnaMasa / UkupnoKola                         ' prosecna masa po kolima
        bZaokruziMasuNa100k(ProsecnaMasa)                                   ' prosecna masa po kolima zaokruzena na 100k navise



        Prevoznina = 0

        For Each KolaRed In dtKola.Rows                                         ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            '       Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
            TipKola = KolaRed.Item("Tip")
            For Each NHMRed In dtNhm.Rows                                '  da li treba dozvoliti da bude vise masa na jednim kolima 
                If NHMRed.Item("IndBrojKola") = IBK Then              '  ili treba obezbediti da bude na svim kolima po jedna roba i to ista na svim kolima ?
                    Razred = NHMRed.Item("R")                               ' u principu, ni ne treba petlja, vec da se ucita bilo koji razred
                End If
            Next

            Razred = NHMRed.Item("R")
            '       Vlasnistvo = KolaRed.Item("Vlasnik")
            '       BrOsovina = KolaRed.Item("Osovine")
            '       TovarenaPrazna = KolaRed.Item("Tovarena")
            Select Case TipKola
                Case "1"
                    KolKoef = 1.0
                Case "2"
                    KolKoef = 1.3
                Case "3"
                    KolKoef = 0.8
                Case "4"
                    KolKoef = 0.7
                Case "5"
                    KolKoef = 0.8
                Case "6"
                    KolKoef = 0.8
                Case "7"
                    KolKoef = 0.3
            End Select

            MasaTemp = ProsecnaMasa
            bNadjiMasuIStavDo25(MasaTemp, MasaTemp, TonskiStav)

            TonskiStavInteger = CType(TonskiStav, Integer)
            MasaTemp = TonskiStavInteger * 1000

            bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, Razred, VozarinskiStav, PV)
            VozarinskiStav = bStavKoef * VozarinskiStav
            bZaokruziNaDeseteNavise(VozarinskiStav)

            PrevozninaPoKolima = ProsecnaMasa * VozarinskiStav * KolKoef / 10 / 1000   ' u santimima
            ' kada zaokruzivanje?

            If TarifaK = "42" Or TarifaK = "43" Then
                PrevozninaPoKolima = 0.5 * PrevozninaPoKolima    ' tovarni pribor
            End If

            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef

            PrevozninaPoKolima = PrevozninaPoKolima / 100                                ' u CHF

            ' proba na minimalnu prevozninu

            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            Prevoznina = Prevoznina + PrevozninaPoKolima
        Next

    End Sub
    Public Sub bNadjiPrevozninuTEA(ByVal Tabela As String, ByRef Prevoznina As Decimal)
        Dim KolaRed, NHMRed As DataRow
        Dim IBK, TovarenaPrazna As String
        Dim MasaTemp As Integer
        Dim Razred As String
        Dim RInt As Byte

        Dim UkupnoKola As Byte
        Dim UkupnoStitnih As Byte
        'Dim UkupnoTovarenihStitnih As Byte

        Dim UkupnaMasa As Integer = 0
        Dim ProsecnaMasa As Integer
        Dim TipKola As String
        Dim BrOsovina As Byte
        Dim UkupnoOsovinaStitnih As Integer = 0
        Dim KolKoef As Decimal
        Dim RidKoef As Decimal = 1

        'Dim TonskiStav As String
        Dim VozarinskiStav As Decimal
        Dim PV As String
        'Dim TonskiStavInteger As Integer
        Dim PrevozninaPoKolima As Decimal
        Dim VrstaKola As String
        Dim VlasnistvoKola As String
        Dim SerijaKola As String
        Dim GrTovKola As Decimal
        Dim TaraKola As Integer
        Dim bStitna As String

        Dim PoTEA As String
        Dim IFrigo As String = "N"

        Dim RacMasa As Decimal
        Dim Masa1 As Decimal
        Dim Masa2 As Decimal
        Dim VozarinskiStav1 As Decimal
        Dim VozarinskiStav2 As Decimal
        Dim PrevozninaPoKolima1 As Decimal
        Dim PrevozninaPoKolima2 As Decimal

        ' Postupak:
        ' - svaka kola prati tovarni list; kada ima vise kola, radi se za svaka kola posebno, zaokruzuje se, pa se sabira

        ' - (ok) racunska masa po kolima dobija se sabiranjem svih stvarnih masa na kolima i zaokruzivanjem  na 100kg navise, OSIM ZA:
        '   (ok)specijalna zeleznicka kola nosivosti preko 80000kg, gde ostaje stvarna masa ( uz min 5000kg/osovini )
        '   (ok)specijalna zeleznicka kola sa spustenim podom gde ostaje stvarna masa ( uz min 5000kg/osovini ), ako je nosivost >80t, isto kao gore

        ' - (ok) racunati sa najskupljim razredom na kolima ( ako ima 1. 2. i 3. - za 1. , za 1. i 2. - za 1. , za 2. i 3. - za 2. ...)
        ' - (ok) korigovati masu na osovine - minimalna masa je 5000kg po osovini;
        ' - za prazna sinska vozila prevoznina se racuna za taru vozila
        '   za tovarena sinska vozila traze se prevoznine za taru vozila i za robu na vozilu, pa se naplacuje visa prevoznina
        ' - (ok)za prevoz dugackih stvari na vise kola i uz stitna kola, smatra se da je roba jednako rasporedjena na svim kolima;
        '   tada se trazi prosecna masa po kolima i zaokruzuje se na 100kg navise ( uz korigovanje na 5000kg po osovini ) i
        '   sve se prikazuje na jednom tovarnom listu
        '   (ok)za svaka stitna kola naplacuje se na JZ(ZS) 0.12 eura po osovinskom kilometru
        '   (ok) minimalma prevoznina ( otkud ovde 10.1 ?) je  33.00 (u/i) i 66.00 (tranzit) eura po kolima 

        ' - (ok) ukoliko je ukupna masa izmedju nazivnih masa za stavove ( 10t, 15t, 20t i 25t ) racunati prevoznine za:
        '   (ok)1- nizi tonski tonski stav i ukupnu  masu i 2- visi tonski stav i visu nazivnu masu;
        '   (ok)usvojiti racunsku masu i vozarinski stav koji daju nizu prevozninu
        ' - (?ok) korigovati vozarinski stav ( *bStavKoef, "popust na vozarinski stav" ) i (?)zaokruziti 
        ' - (ok) naci tip kola ( kao i koeficijent ) 
        '   (ok)(? vidi 20.2 ...  verovatno treba nova procedura NadjiTipKolaIKoefTEA )
        ' - tip kola se ne odrazava samo na koeficijent, vec i na nacin racunanja prevoznine
        ' - (ok) za specijalna kola u svojini zeleznice mKolKoef na JZ(ZS) je 1.2 ( povecanje 20% )
        ' - (ok) naci prevozninu kao proizvod mase, vozarinskog stava i koeficijenta za tip kola                
        ' - (ok) za specijalna zeleznicka kola nosivosti preko 80000kg bPrevozninaKoef je:
        '   (ok) 80t>nosivost>=120t  : bPrevozninaKoef=1.4  ( +40% )
        '   (ok) 120t>nosivost>=180t: bPrevozninaKoef=1.8  ( +80% ) 
        ' - (ok) pomnoziti prevozninu koeficijentom bPrevozninaKoef - "koeficijent na prevozninu"
        ' - (ok) pomnoziti prevozninu koeficijentom mRIDKoef ukoliko roba pripada odredjenim RID razredima
        ' - (ok) zaokruziti prevozninu na evro navise
        ' - (ok) naci minimalnu prevozninu ( zavisi i od stanica ) i testirati kola na minimalnu prevozninu          


        '--------------------------------------------------------------------------------------------------------
        UkupnoKola = dtKola.Rows.Count
        Prevoznina = 0
        UkupnaMasa = 0
        UkupnoKola = dtKola.Rows.Count
        UkupnoStitnih = 0
        UkupnoOsovinaStitnih = 0

        '------------------------------ za stitna kola ------------------------------------
        For Each KolaRed In dtKola.Rows
            BrOsovina = KolaRed.Item("Osovine")
            If KolaRed.Item("Stitna") = "D" Then
                UkupnoOsovinaStitnih = UkupnoOsovinaStitnih + BrOsovina
            End If
        Next

        '------------------------------ kalkulacija ------------------------------------
        For Each KolaRed In dtKola.Rows                ' glavna petlja po kolima za racunanje prevoznine; tu se racunaju i tovarena stitna kola

            IBK = KolaRed.Item("IndBrojKola")
            TipKola = KolaRed.Item("TIP")

            ' sabiranje masa po kolima
            RInt = 2                                                            ' ima samo 1. i 2. razred; racuna se po skupljem ( nizem ) razredu
            For Each NHMRed In dtNhm.Rows
                If NHMRed.Item("IndBrojKola") = IBK Then
                    MasaTemp = NHMRed.Item("Masa")
                    UkupnaMasa = UkupnaMasa + MasaTemp
                    If CType(NHMRed.Item("R"), Byte) <= RInt Then
                        RInt = CType(NHMRed.Item("R"), Byte)
                    End If
                End If
            Next

            Razred = CType(RInt, String)

            VrstaKola = KolaRed.Item("Vrsta")                                   ' 1 - obicna,  2 - specijalna
            VlasnistvoKola = KolaRed.Item("Vlasnik")                            ' "Z", "P", "I"
            BrOsovina = KolaRed.Item("Osovine")
            GrTovKola = KolaRed.Item("GrTov")
            SerijaKola = KolaRed.Item("Serija")
            TaraKola = KolaRed.Item("Tara")
            bStitna = KolaRed.Item("Stitna")

            If TipKola = 7 Then
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

            bNadjiSveIzZSKoefPos(bSaobracaj, "68", bVrstaPosiljke, bVrstaStanice, VlasnistvoKola, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

            If (VrstaKola = "2" And VlasnistvoKola = "Z" And GrTovKola > 80000) Then     ' zeleznicka specijalna preko 80t
                'za stvarnu masu
            Else
                bZaokruziMasuNa100k(UkupnaMasa)
            End If

            RacMasa = UkupnaMasa

            bZaokrMasuNaOsovineINadjiKolKoefTEA(RacMasa, TaraKola, GrTovKola, VlasnistvoKola, VrstaKola, _
                                                                        SerijaKola, IFrigo, TovarenaPrazna, BrOsovina, RacMasa, KolKoef)

            bNadjiRIDKoef(bSaobracaj, mRazredRid, RidKoef)

            Select Case RacMasa
                Case 10000, 15000, 20000, 25000
                    bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav, PV)
                    VozarinskiStav = bStavKoef * VozarinskiStav
                    bZaokruziNaDeseteNavise(VozarinskiStav)
                    PrevozninaPoKolima = RacMasa * VozarinskiStav * KolKoef * RidKoef / 1000
                    PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef

                Case Else

                    If (RacMasa > 10000 And RacMasa < 15000) Then
                        bNadjiVozarinskiStav(Tabela, mDatumKalk, 10000, bTkm, Razred, VozarinskiStav1, PV)
                        Masa2 = 15000
                    End If

                    If (RacMasa > 15000 And RacMasa < 20000) Then
                        bNadjiVozarinskiStav(Tabela, mDatumKalk, 15000, bTkm, Razred, VozarinskiStav1, PV)
                        Masa2 = 20000
                    End If

                    If (RacMasa > 20000 And RacMasa < 25000) Then
                        bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                        Masa2 = 25000
                    End If

                    Masa1 = RacMasa

                    VozarinskiStav1 = bStavKoef * VozarinskiStav1
                    bZaokruziNaDeseteNavise(VozarinskiStav1)
                    PrevozninaPoKolima1 = Masa1 * VozarinskiStav1 * KolKoef * RidKoef / 1000
                    PrevozninaPoKolima1 = PrevozninaPoKolima1 * bPrevozninaKoef

                    bNadjiVozarinskiStav(Tabela, mDatumKalk, Masa2, bTkm, Razred, VozarinskiStav2, PV)
                    VozarinskiStav2 = bStavKoef * VozarinskiStav2
                    bZaokruziNaDeseteNavise(VozarinskiStav2)
                    PrevozninaPoKolima2 = Masa2 * VozarinskiStav2 * KolKoef * RidKoef / 1000
                    PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef

                    PrevozninaPoKolima = PrevozninaPoKolima1
                    If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                        PrevozninaPoKolima = PrevozninaPoKolima2
                    End If
                    If bStitna = "D" Then
                        If UkupnaMasa = 0 Then
                            PrevozninaPoKolima = 0
                        End If
                        PrevozninaPoKolima = PrevozninaPoKolima + 0.12 * BrOsovina * bTkm
                    End If
            End Select

            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
            '-------------------------------------------------
            'bZaokruziNaCeleNavise(PrevozninaPoKolima)
            'zaokruzivanje na kraju kada se saberu i naknade
            '-------------------------------------------------

            ' dodati deo kalkulacije za sinska vozila

            'minimalna prevoznina
            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            Prevoznina = Prevoznina + PrevozninaPoKolima
        Next

    End Sub
    Public Sub bNadjiPrevozninuKont(ByVal Tabela As String, ByRef Prevoznina As Decimal)

        Dim KolaRed, NHMRed As DataRow
        Dim IBK, VlasnistvoKola As String
        Dim DuzinaKontStr As String
        Dim DuzinaKont As Integer
        Dim UkupnaDuzina As Integer = 0       ' Ukupna duzina kontejnera na kolima
        Dim mUkupnaDuzina As String             ' sifra kombinacije kontejnera
        Dim mSifraKomb As String

        'Dim MasaTemp As Integer

        'Dim Razred As String

        Dim UkupnoKola As Byte
        Dim TipKola As String
        'Dim KolKoef As Decimal
        Dim TovarenaPrazna As String
        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim PrevozninaPoKolima As Decimal
        bRedovanOrocen = "R"

        ' Postupak:
        ' - naci zbir svih duzina kontejnera        ( sta za 20'+30' ? )
        ' - naci vozarinski stav ( stav iz tablice ); 
        ' - korigovati vozarinski stav ( *bStavKoef, "popust na vozarinski stav" ) i (?)zaokruziti na 10 navise
        ' ?- naci tip svakih kola ( kao i koeficijent )
        ' -
        ' - zaokruzivanje po kolima?

        ' - testirati svaka kola na minimalnu prevozninu ( ili celu posiljku uz MinPrevPosiljke = UkupnoKola*MinPrevPoKolima ? )
        ' - pomnoziti prevozninu koeficijentom bPrevozninaKoef - "popust na prevozninu"

        UkupnoKola = dtKola.Rows.Count

        Prevoznina = 0

        For Each KolaRed In dtKola.Rows                                         ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            '       Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
            TipKola = KolaRed.Item("Tip")
            VlasnistvoKola = KolaRed.Item("Vlasnik")                            ' "Z", "P", "I"


            UkupnaDuzina = 0
            For Each NHMRed In dtNhm.Rows
                If IBK = NHMRed.Item("IndBrojKola") Then
                    DuzinaKontStr = NHMRed.Item("UTI")
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    UkupnaDuzina = UkupnaDuzina + DuzinaKont
                End If
            Next
            mUkupnaDuzina = CType(UkupnaDuzina, String)

            '       Vlasnistvo = KolaRed.Item("Vlasnik")
            '       BrOsovina = KolaRed.Item("Osovine")
            '       TovarenaPrazna = KolaRed.Item("Tovarena")
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


            '14.06.
            'TipKola = "7"
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

            bNadjiSveIzZSKoefPos(bSaobracaj, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnistvoKola, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

            ' 14.06.
            Select Case mUkupnaDuzina
                Case 20
                    mSifraKomb = "10000"
                Case 30
                    mSifraKomb = "01000"
                Case 40
                    mSifraKomb = "00100"
                    'Case 50
                    'mSifraKomb = "0000"
                Case 60
                    mSifraKomb = "00010"
                    'Case 70
                    'mSifraKomb = "10000"
                Case 80
                    mSifraKomb = "00001"
            End Select

            bNadjiVozarinskiStavKont(Tabela, mDatumKalk, mSifraKomb, bTkm, VozarinskiStav, PV)
            VozarinskiStav = bStavKoef * VozarinskiStav

            PrevozninaPoKolima = VozarinskiStav
            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef

            ' proba na minimalnu prevozninu
            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            Prevoznina = Prevoznina + PrevozninaPoKolima
        Next
        bZaokruziNaDeseteNavise(Prevoznina)
    End Sub
    Public Sub bNadjiPrevozninuKontTEA(ByVal Tabela As String, ByRef Prevoznina As Decimal)

        'radi i za ICF TabNaziv=221
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
            If Vlasnistvo = "P" Or Vlasnistvo = "I" Then
                KolKoef = 0.8
            End If

            For Each NHMRed In dtNhm.Rows
                If IBK = NHMRed.Item("IndBrojKola") Then
                    DuzinaKontStr = NHMRed.Item("UTI")
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    StvMasa = NHMRed.Item("Masa")
                    bNadjiRasterTEA(DuzinaKont, StvMasa, Raster)

                    PrevozninaPoKont = 0

                    bNadjiVozarinskiStavKontTEA(Tabela, mDatumKalk, bTkm, VozarinskiStav, PV)
                    VozarinskiStav = bStavKoef * VozarinskiStav
                    bZaokruziNaDeseteNavise(VozarinskiStav)

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

    Public Sub bNadjiPrevozninuGlavni()

        Dim mBrojUgNISTemp As String = ""
        Dim mVrstaPrevozaNISTemp As String = ""
        Dim mTarifaNISTemp As String = ""
        Dim bTarifa72NISTemp As Byte = 0

        ' NIS + Petrohemija, Standaard gas, MTBE
        If mBrojUg = "118790" Or mBrojUg = "118791" Or mBrojUg = "118792" Or mBrojUg = "118799" Or _
                       mBrojUg = "118780" Or mBrojUg = "118781" Or mBrojUg = "118782" Or mBrojUg = "118988" Or _
                       mBrojUg = "118770" Or mBrojUg = "118771" Or mBrojUg = "118772" Or mBrojUg = "118977" Then

            mBrojUgNISTemp = mBrojUg

            If mBrojUg = "118790" Or mBrojUg = "118780" Or mBrojUg = "118770" Then
                mBrojUg = "118700"
            End If

            If mBrojUg = "118791" Or mBrojUg = "118781" Or mBrojUg = "118771" Then
                mBrojUg = "118701"
            End If

            If mBrojUg = "118792" Or mBrojUg = "118782" Or mBrojUg = "118772" Then
                mBrojUg = "118702"
            End If

            If mBrojUg = "118799" Or mBrojUg = "118788" Or mBrojUg = "118777" Then
                mBrojUg = "118711"
            End If

        End If
        ' NIS + Petrohemija, Standaard gas, MTBE


        If mBrojUg = "118701" Then      ' proveriti striktnije
            bTarifa72 = 0
        End If

        If mBrojUg = "118700" Or mBrojUg = "118702" Then

            If mBrojUg = "118700" Then
                bTarifa72 = 0
            ElseIf mBrojUg = "118702" Then
                bTarifa72 = 49
            End If

            mBrojUgNISTemp = mBrojUg
            mBrojUg = ""
            mTarifaNISTemp = mTarifa
            mTarifa = "36"

        End If



        ' $$8606$$ PROVERITI SVE ZA 8606 I 9921-22

        VrstaStanice() ' Da li je granicna

        'bVrstaSaobracajaTemp = bVrstaSaobracaja

        If bVrstaPosiljke = "K" Then
            If IzborSaobracaja = "1" Then          ' ----------------- L O K A L ------------------
                '                                             ( UNUTRASNJI TOVARNI LIST )
                ' bVrstaSaobracaja :
                '   0 - unutrasnji saobracaj
                '   1 - uvoz reekspedicija
                '   2 - izvoz reekspedicija
                '   3 - lucki uvoz
                '   4 - lucki izvoz
                '   5 - recni uvoz
                '   6 - recni izvoz
                '   7
                '   8 - uvoz zeleznica-drum
                '   9 - izvoz zeleznica-drum

                If (bVrstaSaobracaja = 0) Then  ' DIN
                    If mTarifa = "36" Then    ' redovna tarifa
                        bValuta = "72"          ' DIN
                        If bKontejneri = False Then
                            mTabelaCena = "121"
                            If bTarifa72 = 0 Then
                                bNadjiPrevozninu00L(mTabelaCena, mPrevoznina)
                            Else
                                bNadjiPrevozninuNeNulaL(mTabelaCena, mPrevoznina)
                            End If
                        Else
                            bNadjiPrevozninuKont72L(mPrevoznina)        ' kontejneri sa kombinacijama
                        End If
                    ElseIf mTarifa = "00" Then     ' ugovoriKP
                        'Dim kPrevoznina As Decimal
                        Dim kPov As String
                        If mBrojUg = "911901" Then
                            bNadjiPrevozninu911901L(mPrevoznina, kPov)
                        ElseIf mBrojUg = "200379" Then
                            bNadjiPrevozninuUSSL(mPrevoznina)
                        Else
                            If mVrstaObracuna = "CD" Then
                                bNadjiPrevozninuCOL(mPrevoznina)
                            Else
                                bNadjiPrevozninuROKP(mPrevoznina, kPov) '  "RO"
                            End If
                        End If
                    End If                          ' redovna - ugovori     DIN
                Else                       ' bVrstaSaobracaja = 1,...,9          EUR
                    If mTarifa = "36" Then    ' redovna tarifa
                        bValuta = "17"
                        If bKontejneri = False Then
                            mTabelaCena = "122"
                            If bTarifa72 = 0 Then
                                bNadjiPrevozninu00UI(mTabelaCena, mPrevoznina)
                            Else
                                bNadjiPrevozninuNeNulaL(mTabelaCena, mPrevoznina)
                            End If
                        Else
                            mTabelaCena = "133" ' proveriti!!!
                            bNadjiPrevozninuKont72UI(mTabelaCena, mPrevoznina)
                        End If
                    ElseIf mTarifa = "00" Then     ' ugovori - isto kao uvoz/izvoz
                        'Dim kPrevoznina As Decimal
                        Dim kPov As String
                        If mBrojUg = "911901" Then
                            bNadjiPrevozninu911901L(mPrevoznina, kPov)
                        ElseIf mBrojUg = "200379" Then
                            bNadjiPrevozninuUSSL(mPrevoznina)
                        Else
                            If mVrstaObracuna = "CO" Or mVrstaObracuna = "CD" Then
                                If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "22" Or (mBrojUg = "971600") Then
                                    bNadjiPrevozninuKont72UI_CO22(mPrevoznina)
                                Else
                                    bNadjiPrevozninuCOL(mPrevoznina)
                                End If
                            Else
                                bNadjiPrevozninuROKP(mPrevoznina, kPov)     '  "RO"                                
                            End If
                        End If
                    End If                                  ' redovna - ugovori     EUR
                End If                                  ' DIN - EUR
            End If                                  ' utl    
        Else
            bNadjiPrevozninuDenc(mPrevoznina)
        End If                                      ' kolske - dencane

        If bValuta = "17" Then
            bbPrevozninaUEvrima = mPrevoznina
        End If

        bNadjiRacunskuMasuPoPosiljci(bRacunskaMasa)
        bIzTBPrevoznina = False

        If mBrojUgNISTemp = "118700" Or mBrojUgNISTemp = "118702" Then
            mBrojUg = mBrojUgNISTemp
            mTarifa = mTarifaNISTemp
        End If

        ' NIS + Petrohemija, Standaard gas, MTBE
        If mBrojUgNISTemp = "118790" Or mBrojUgNISTemp = "118791" Or mBrojUgNISTemp = "118792" Or mBrojUgNISTemp = "118999" Or _
            mBrojUgNISTemp = "118780" Or mBrojUgNISTemp = "118781" Or mBrojUgNISTemp = "118782" Or mBrojUgNISTemp = "118988" Or _
            mBrojUgNISTemp = "118770" Or mBrojUgNISTemp = "118771" Or mBrojUgNISTemp = "118772" Or mBrojUgNISTemp = "118977" Then
            mBrojUg = mBrojUgNISTemp
        End If
        ' NIS + Petrohemija, Standaard gas, MTBE


    End Sub
    Public Sub VrstaStanice()
        If IzborSaobracaja = "2" Then
            Select Case mStanica2
                Case "23450", "22850", "21009", "12499", "11027", "16314", "16516"
                    bVrstaStanice = "G"
                Case Else
                    bVrstaStanice = "M"
            End Select
        ElseIf IzborSaobracaja = "3" Then
            Select Case mStanica1
                Case "23450", "22850", "21009", "12499", "11027", "16314", "16516"
                    bVrstaStanice = "G"
                Case Else
                    bVrstaStanice = "M"
            End Select
        ElseIf IzborSaobracaja = "1" Or IzborSaobracaja = "4" Then
            bVrstaStanice = "M"
        End If
    End Sub
    Public Sub bNadjiRacunskuMasuPoPosiljci(ByRef outRacMasa As Decimal)

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK As String
        Dim Vlasnistvo As String
        Dim MasaTemp As Integer = 0
        Dim MasaPoKolima As Integer = 0
        Dim BrOsovina As Integer
        Dim RacunskaMasaPoKolima As Integer = 0
        outRacMasa = 0

        For Each KolaRed In dtKola.Rows    ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            BrOsovina = KolaRed.Item("Osovine")

            For Each NHMRed In dtNhm.Rows
                If NHMRed.Item("IndBrojKola") = IBK Then
                    MasaTemp = NHMRed.Item("Masa")
                    'NHMRed.Item("RacMasa")=

                    MasaPoKolima = MasaPoKolima + MasaTemp
                End If

            Next
            bZaokruziMasuNa100k(MasaPoKolima)

            RacunskaMasaPoKolima = MasaPoKolima

            If RacunskaMasaPoKolima < BrOsovina * 5000 Then
                RacunskaMasaPoKolima = BrOsovina * 5000
            End If
            outRacMasa = outRacMasa + RacunskaMasaPoKolima
        Next

    End Sub
    Public Sub bNadjiTipKolaKoef( _
                ByVal inTip As String, _
                ByVal inSifraTarife As String, _
                ByVal inUslov As String, _
                ByVal inDatumKalk As Date, _
                ByRef outKolKoef As Decimal, _
                ByRef outRetVal As String)

        outKolKoef = 1
        outRetVal = ""

        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiKolKoef", DbVezaCene)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulTip As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTip", SqlDbType.Char, 1))
        ulTip.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTip").Value = inTip

        Dim ulSifraTarife As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2))
        ulSifraTarife.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraTarife").Value = inSifraTarife

        Dim ulUslov As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUslov", SqlDbType.Char, 5))
        ulUslov.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUslov").Value = inUslov

        Dim ulDatumKalk As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumKalk", SqlDbType.DateTime))
        ulDatumKalk.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatumKalk").Value = inDatumKalk

        Dim izlKolKoef As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolKoef", SqlDbType.Decimal))
        izlKolKoef.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKolKoef").Value = outKolKoef
        izlKolKoef.Size = 5
        izlKolKoef.Precision = 5
        izlKolKoef.Scale = 2


        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try

            If DbVezaCene.State = ConnectionState.Closed Then
                DbVezaCene.Open()
            End If

            spKomanda.ExecuteScalar()
            outKolKoef = spKomanda.Parameters("@outKolKoef").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

            '''' ## T kola
            '''If (mDatumKalk >= "4/1/2009") And ((inTip = 1) Or (inTip = 2)) And pubIBK = "72" And Microsoft.VisualBasic.Left(pubSerijaKola, 1) = "T" Then
            '''    outKolKoef = 1
            '''End If
            '''' ## T kola

            If ((bVrstaSaobracaja = 0) And (bValuta = "72") And (mDatumKalk >= "1/1/2013")) Then ' ( bVrstaSaobracaja -> 0...9 )
                Select Case inTip
                    Case "1"
                        outKolKoef = 1
                    Case "2"
                        outKolKoef = 1.2
                    Case "3"
                        outKolKoef = 0.9
                    Case "4"
                        outKolKoef = 0.9
                    Case "5"
                        outKolKoef = 0.9
                    Case "6"
                        outKolKoef = 0.9
                    Case 7

                End Select
            End If

            ' ## T kola
            If (mDatumKalk >= "4/1/2009") And ((inTip = 1) Or (inTip = 2)) And pubIBK = "72" And Microsoft.VisualBasic.Left(pubSerijaKola, 1) = "T" Then
                outKolKoef = 1
            End If
            ' ## T kola


        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVezaCene.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub bNadjiPrevozninuDenc(ByRef outPrevoznina As Decimal)    ' dencane

        Dim DencaneRed As DataRow

        Dim StvMasaD, RacMasaD, TipD, KomD As Int32
        Dim TarifaD, ValutaD As String
        Dim MasaTemp As Integer

        Dim VozarinskiStav As Decimal
        Dim PV As String
        Dim PrevozninaPoPosiljci As Decimal = 0

        PrevozninaPoPosiljci = 0

        'If dtDencane.Rows(0).Item("Tarifa") = "00" Then
        '    bSvaTovarena = "PK"
        'Else : bSvaTovarena = "TK"
        'End If


        'bRacunskaMasaPoKolima = 0

        Dim TarInt, TarTipD As Integer
        Dim bTarDKoef As Decimal

        Dim bMasaD(2) As Int32
        Dim bTarD(2) As String
        Dim bTipD(2) As Integer
        Dim bKomadaD(2) As Int32

        'Dim bKolMasa(2) As Integer
        Dim Kontr(31) As Integer
        Dim nizMasa(31) As Integer
        Dim nizTar(31) As Integer
        Dim nizTip(31) As Integer
        Dim nizKomada(31) As Integer

        Dim bZbirMasaD As Decimal

        For k As Integer = 0 To 31
            Kontr(k) = 0
            nizMasa(k) = 0
            nizTar(k) = 0
            nizTip(k) = 0
            nizKomada(k) = 0
        Next K


        For Each DencaneRed In dtDencane.Rows    ' petlja po robama

            'Friend dtDencane As DataTable = New DataTable("DENCANE")
            '("SMasa",  Int32)
            '("RMasa",  Int32)
            '("Tarifa", String)
            '("Tip",    Int32)
            '("Komada", Int32)
            '("Iznos",  Decimal)
            '("Valuta", String)
            '("Action", String)


            StvMasaD = DencaneRed.Item("SMasa")
            TarifaD = DencaneRed.Item("Tarifa")
            TipD = DencaneRed.Item("Tip")
            KomD = DencaneRed.Item("Komada")

            TarInt = CType(TarifaD, Integer)
            TarTipD = 10 * TarInt + TipD


            Select Case TarTipD
                Case 0
                    Kontr(0) = Kontr(0) + 1
                    nizMasa(0) = nizMasa(0) + StvMasaD
                    nizTar(0) = "0"
                    nizTip(0) = 0
                    nizKomada(0) = nizKomada(0) + KomD
                Case 41
                    Kontr(1) = Kontr(1) + 1
                    nizMasa(1) = nizMasa(1) + StvMasaD
                    nizTar(1) = "4"
                    nizTip(1) = 1
                    nizKomada(1) = nizKomada(1) + KomD
                Case 42
                    Kontr(2) = Kontr(2) + 1
                    nizMasa(2) = nizMasa(2) + StvMasaD
                    nizTar(2) = "4"
                    nizTip(2) = 2
                    nizKomada(2) = nizKomada(2) + KomD
                Case 43
                    Kontr(3) = Kontr(3) + 1
                    nizMasa(3) = nizMasa(3) + StvMasaD
                    nizTar(3) = "4"
                    nizTip(3) = 3
                    nizKomada(3) = nizKomada(3) + KomD
                Case 44
                    Kontr(4) = Kontr(4) + 1
                    nizMasa(4) = nizMasa(4) + StvMasaD
                    nizTar(4) = "4"
                    nizTip(4) = 4
                    nizKomada(4) = nizKomada(4) + KomD
                Case 80
                    Kontr(5) = Kontr(5) + 1
                    nizMasa(5) = nizMasa(5) + StvMasaD
                    nizTar(5) = "8"
                    nizTip(5) = 0
                    nizKomada(5) = nizKomada(5) + KomD
                Case 90
                    Kontr(6) = Kontr(6) + 1
                    nizMasa(6) = nizMasa(6) + StvMasaD
                    nizTar(6) = "9"
                    nizTip(6) = 0
                    nizKomada(6) = nizKomada(6) + KomD
                Case 110
                    Kontr(7) = Kontr(7) + 1
                    nizMasa(7) = nizMasa(7) + StvMasaD
                    nizTar(7) = "11"
                    nizTip(7) = 0
                    nizKomada(7) = nizKomada(7) + KomD
                Case 120
                    Kontr(8) = Kontr(8) + 1
                    nizMasa(8) = nizMasa(8) + StvMasaD
                    nizTar(8) = "12"
                    nizTip(8) = 0
                    nizKomada(8) = nizKomada(8) + KomD
                Case 130
                    Kontr(9) = Kontr(9) + 1
                    nizMasa(9) = nizMasa(9) + StvMasaD
                    nizTar(9) = "13"
                    nizTip(9) = 0
                    nizKomada(9) = nizKomada(9) + KomD
                Case 150
                    Kontr(10) = Kontr(10) + 1
                    nizMasa(10) = nizMasa(10) + StvMasaD
                    nizTar(10) = "15"
                    nizTip(10) = 0
                    nizKomada(10) = nizKomada(10) + KomD
                Case 171
                    Kontr(11) = Kontr(11) + 1
                    nizMasa(11) = nizMasa(11) + StvMasaD
                    nizTar(11) = "17"
                    nizTip(11) = 1
                    nizKomada(11) = nizKomada(11) + KomD
                Case 172
                    Kontr(12) = Kontr(12) + 1
                    nizMasa(12) = nizMasa(12) + StvMasaD
                    nizTar(12) = "17"
                    nizTip(12) = 2
                    nizKomada(12) = nizKomada(12) + KomD
                Case 173
                    Kontr(13) = Kontr(13) + 1
                    nizMasa(13) = nizMasa(13) + StvMasaD
                    nizTar(13) = "17"
                    nizTip(13) = 3
                    nizKomada(13) = nizKomada(13) + KomD
                Case 174
                    Kontr(14) = Kontr(14) + 1
                    nizMasa(14) = nizMasa(14) + StvMasaD
                    nizTar(14) = "17"
                    nizTip(14) = 4
                    nizKomada(14) = nizKomada(14) + KomD
                Case 175
                    Kontr(15) = Kontr(15) + 1
                    nizMasa(15) = nizMasa(15) + StvMasaD
                    nizTar(15) = "17"
                    nizTip(15) = 5
                    nizKomada(15) = nizKomada(15) + KomD
                Case 176
                    Kontr(16) = Kontr(16) + 1
                    nizMasa(16) = nizMasa(16) + StvMasaD
                    nizTar(16) = "17"
                    nizTip(16) = 6
                    nizKomada(16) = nizKomada(16) + KomD
                Case 177
                    Kontr(17) = Kontr(17) + 1
                    nizMasa(17) = nizMasa(17) + StvMasaD
                    nizTar(17) = "17"
                    nizTip(17) = 7
                    nizKomada(18) = nizKomada(18) + KomD
                Case 211
                    Kontr(18) = Kontr(18) + 1
                    nizMasa(18) = nizMasa(18) + StvMasaD
                    nizTar(18) = "21"
                    nizTip(18) = 1
                    nizKomada(19) = nizKomada(19) + KomD
                Case 212
                    Kontr(19) = Kontr(19) + 1
                    nizMasa(19) = nizMasa(19) + StvMasaD
                    nizTar(19) = "21"
                    nizTip(19) = 2
                    nizKomada(19) = nizKomada(19) + KomD
                Case 221
                    Kontr(20) = Kontr(20) + 1
                    nizMasa(20) = nizMasa(20) + StvMasaD
                    nizTar(20) = "22"
                    nizTip(20) = 1
                    nizKomada(20) = nizKomada(20) + KomD
                Case 222
                    Kontr(21) = Kontr(21) + 1
                    nizMasa(21) = nizMasa(21) + StvMasaD
                    nizTar(21) = "22"
                    nizTip(21) = 2
                    nizKomada(21) = nizKomada(21) + KomD
                Case 223
                    Kontr(22) = Kontr(22) + 1
                    nizMasa(22) = nizMasa(22) + StvMasaD
                    nizTar(22) = "22"
                    nizTip(22) = 3
                    nizKomada(22) = nizKomada(22) + KomD
                Case 224
                    Kontr(23) = Kontr(23) + 1
                    nizMasa(23) = nizMasa(23) + StvMasaD
                    nizTar(23) = "22"
                    nizTip(23) = 4
                    nizKomada(23) = nizKomada(23) + KomD
                Case 261
                    Kontr(24) = Kontr(24) + 1
                    nizMasa(24) = nizMasa(24) + StvMasaD
                    nizTar(24) = "26"
                    nizTip(24) = 1
                    nizKomada(24) = nizKomada(24) + KomD
                Case 262
                    Kontr(25) = Kontr(25) + 1
                    nizMasa(25) = nizMasa(25) + StvMasaD
                    nizTar(25) = "26"
                    nizTip(25) = 2
                    nizKomada(25) = nizKomada(25) + KomD
                Case 263
                    Kontr(26) = Kontr(26) + 1
                    nizMasa(26) = nizMasa(26) + StvMasaD
                    nizTar(26) = "26"
                    nizTip(26) = 3
                    nizKomada(26) = nizKomada(26) + KomD
                Case 264
                    Kontr(27) = Kontr(27) + 1
                    nizMasa(27) = nizMasa(27) + StvMasaD
                    nizTar(27) = "26"
                    nizTip(27) = 4
                    nizKomada(27) = nizKomada(27) + KomD
                Case 280
                    Kontr(28) = Kontr(28) + 1
                    nizMasa(28) = nizMasa(28) + StvMasaD
                    nizTar(28) = "28"
                    nizTip(28) = 0
                    nizKomada(28) = nizKomada(28) + KomD
                Case 290
                    Kontr(29) = Kontr(29) + 1
                    nizMasa(29) = nizMasa(29) + StvMasaD
                    nizTar(29) = "29"
                    nizTip(29) = 0
                    nizKomada(29) = nizKomada(29) + KomD
                Case 300
                    Kontr(30) = Kontr(30) + 1
                    nizMasa(30) = nizMasa(30) + StvMasaD
                    nizTar(30) = "30"
                    nizTip(30) = 0
                    nizKomada(30) = nizKomada(30) + KomD
                Case 990
                    Kontr(31) = Kontr(31) + 1
                    nizMasa(31) = nizMasa(31) + StvMasaD
                    nizTar(31) = "99"
                    nizTip(31) = 0
                    nizKomada(31) = nizKomada(31) + KomD
            End Select
        Next  ' petlja po robama

        Dim a As Integer = 0

        For k As Integer = 0 To 2
            bMasaD(k) = 0
            bTarD(k) = ""
            bTipD(k) = 0
            bKomadaD(k) = 0
            '    bKolMasa(k) = 0
        Next k

        For k As Integer = 0 To 31
            If Kontr(k) > 0 Then
                If a <= 2 Then
                    bMasaD(a) = nizMasa(k)
                    bTarD(a) = nizTar(k)
                    bTipD(a) = nizTip(k)
                    bKomadaD(a) = nizKomada(k)
                Else
                    ' Greska! Ima vise od tri razlicite tarife. Obraditi.
                End If
                a = a + 1
            End If
        Next k

        ' Rezultat ovoga iznad je bMasaD(0..2), bTarD(0..2), bTipD(0..2), bKomadaD(0..2)

        bNadjiZbirMasaD(bMasaD, bTarD, bTipD, bKomadaD, bZbirMasaD, bTarDKoef)

        bZaokruziMasuDenc(bZbirMasaD, RacMasaD)

        'If Dencane And bValuta ="17" Then

        If bVrstaSaobracaja = 0 Then
            mTabelaCena = "111"             ' cene u DIN
        Else
            If mTarifa = "46" Then      ' Ekspres
                mTabelaCena = "801"
            Else
                mTabelaCena = "112"
            End If
        End If


        Dim Kdec = 0.1      ' koeficijent za tabelu ( cena je za 10kg )
        'End If

        bNadjiVozarinskiStav(mTabelaCena, mDatumKalk, RacMasaD, bTkm, "0", VozarinskiStav, PV)

        PrevozninaPoPosiljci = RacMasaD * VozarinskiStav * bTarDKoef * Kdec

        ' dodato za probu
        bVrstaStanice = "M"
        ' dodato za probu
        '"36"
        Dim bSaobracaj As Integer
        If bValuta = "72" Then
            bSaobracaj = 1
        ElseIf bValuta = "17" Then
            bSaobracaj = 2
        End If

        Dim bRetValLok As String = ""

        bNadjiSveIzZSKoefPos(bSaobracaj, mTarifa, bVrstaPosiljke, bVrstaStanice, "Z", _
               "TK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

        bZaokruziNaDeseteNavise(PrevozninaPoPosiljci)

        If PrevozninaPoPosiljci <= bMinPrevoznina Then
            PrevozninaPoPosiljci = bMinPrevoznina
        End If

        For Each DencaneRed In dtDencane.Rows    ' petlja po robama ponovo 
            DencaneRed.Item("Iznos") = PrevozninaPoPosiljci ' samo u jedan red, jer je prevoznina "ukupna"
            DencaneRed.Item("RMasa") = RacMasaD
            'KolaRed.Item("VozarinskiStav") = 0
            'bZaokruziNaDeseteNavise(PrevozninaPoKolima)
        Next    ' petlja po robama
        '        Prevoznina = Prevoznina + PrevozninaPoKolima

        outPrevoznina = PrevozninaPoPosiljci

    End Sub
    Public Sub bNadjiZbirMasaD(ByVal inMasa As Integer(), ByVal inTarifa As String(), _
                       ByVal inTip As Int32(), ByVal inKomada As Int32(), _
                       ByRef outZbirMasa As Decimal, ByRef outTarKoef As Decimal)

        Dim inTarifaInt(2) As Int32
        Dim PomMasa1 As Decimal = 0
        Dim PomMasa2 As Decimal = 0
        Dim Masa17 As Decimal = 0

        Dim bMasaD(2) As Int32

        Dim Tez2a(4) As Integer
        Tez2a(1) = 400
        Tez2a(2) = 700
        Tez2a(3) = 1000
        Tez2a(4) = 1500

        Dim Tez2b(7) As Integer
        Tez2b(1) = 700
        Tez2b(2) = 400
        Tez2b(3) = 170
        Tez2b(4) = 550
        Tez2b(5) = 70
        Tez2b(6) = 30
        Tez2b(7) = 80

        Dim Tez2c(4) As Integer
        Tez2a(1) = 200
        Tez2a(2) = 350
        Tez2a(3) = 500
        Tez2a(4) = 2000

        outZbirMasa = 0
        outTarKoef = 1

        For k As Int16 = 0 To 2
            If Not (inTarifa(k)) = "" Then
                inTarifaInt(k) = CType(inTarifa(k), Integer)
            Else
                inTarifaInt(k) = 0
            End If
        Next

        For k As Int16 = 0 To 2
            If inMasa(k) > 0 Then
                Select Case inTarifaInt(k)
                    Case 0, 20, 26, 28, 29, 30, 99
                        outZbirMasa = outZbirMasa + inMasa(k)
                    Case 4
                        PomMasa1 = CType((inMasa(k) * 2.5 + 0.9), Integer)
                        PomMasa2 = Tez2a(inTip(k)) * inKomada(k)
                        If PomMasa1 > PomMasa2 Then
                            outZbirMasa = outZbirMasa + PomMasa1
                        Else
                            outZbirMasa = outZbirMasa + PomMasa2
                        End If
                    Case 8, 9, 11
                        PomMasa1 = CType((inMasa(k) * 2.5 + 0.9), Integer)
                        If PomMasa1 > 100 Then
                            outZbirMasa = outZbirMasa + PomMasa1
                        Else
                            outZbirMasa = outZbirMasa + 100
                        End If
                    Case 12
                        If inMasa(k) > 1000 Then
                            outZbirMasa = outZbirMasa + inMasa(k) 'ili + MasaD(k) - stvarna k-ta masa ? proveriti
                        Else
                            outZbirMasa = outZbirMasa + 1000
                        End If
                    Case 13
                        PomMasa1 = CType((inMasa(k) * 2.5 + 0.9), Integer)
                        If PomMasa1 > 1000 Then
                            outZbirMasa = outZbirMasa + PomMasa1
                        Else
                            outZbirMasa = outZbirMasa + 1000
                        End If
                    Case 15
                        If inMasa(k) > 4000 Then
                            outZbirMasa = outZbirMasa + inMasa(k)
                        Else
                            outZbirMasa = outZbirMasa + 4000
                        End If
                    Case 21
                        If Not (mTarifa = "46") Then         ' dencane
                            PomMasa1 = inMasa(k)
                            PomMasa2 = 150 * inKomada(k)
                            If PomMasa1 > PomMasa2 Then
                                outZbirMasa = outZbirMasa + PomMasa1
                            Else
                                outZbirMasa = outZbirMasa + PomMasa2
                            End If
                            If (inTarifaInt(0) = 0 Or inTarifaInt(0) = 21) And _
                                (inTarifaInt(1) = 0 Or inTarifaInt(1) = 21) And _
                                (inTarifaInt(2) = 0 Or inTarifaInt(2) = 21) Then
                                outTarKoef = 0.9
                            End If
                        Else  ' mTarifa = "46" - Ekspres
                            outZbirMasa = outZbirMasa + 2.5 * inMasa(k)
                            If outZbirMasa < 100 Then
                                outZbirMasa = 100
                            End If
                        End If
                    Case 22
                        PomMasa1 = Tez2b(inTip(k)) * inKomada(k)
                        If PomMasa1 > inMasa(k) Then
                            outZbirMasa = outZbirMasa + PomMasa1
                        Else
                            outZbirMasa = outZbirMasa + inMasa(k)
                        End If
                End Select
            End If
        Next

        ' tarife 26,28,29 i 30 ako su to jedine tarife
        If inMasa(1) = 0 Then
            If inTarifa(0) = 26 Then
                outTarKoef = 0.8
            End If
            If (inTarifa(0) = 28) Or (inTarifa(0) = 29) Then
                outTarKoef = 0.5
            End If
            If (inTarifa(0) = 30) Then
                outTarKoef = 2
            End If
        End If

        ' tarifa 17
        For k As Int16 = 0 To 2
            If (inMasa(k) > 0) And (inTarifaInt(k) = 17) Then
                PomMasa1 = Tez2b(inTip(k)) * inKomada(k)
                If PomMasa1 < inMasa(k) Then
                    PomMasa1 = inMasa(k)
                End If
                Masa17 = Masa17 + PomMasa1
            End If
        Next

        If Masa17 > 0 And Masa17 < 3000 Then
            Masa17 = 3000
        End If

        outZbirMasa = outZbirMasa + Masa17

    End Sub

    Public Sub bZaokruziNaDeseteNanize(ByRef izlaz As Decimal)
        ' ulaz - decimalan broj sa dve decimale
        ' izlaz - zaokruzen na desete delove navise

        izlaz = Int((izlaz * 10)) / 10

    End Sub
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
            If outRetVal = "                                                  " Then
                outRetVal = ""
            End If
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub

End Module
