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


        outMasa1 = inMasa1
        outMasa2 = inMasa2
        outMasa3 = inMasa3


        ZaokMasaPoKolima = inMasa1 + inMasa2 + inMasa3

        bZaokrMasuNaOsovineP(ZaokMasaPoKolima, bSvaTovarena, inOsovine, PomMasa1)

        bNadjiMax3(inMasa1, inMasa2, inMasa3, PomMasa2, RMax)

        If inDoTona = "25" Then
            bNadjiMasuIStavDo25(PomMasa1, PomMasa3, outStav)
        ElseIf inDoTona = "45" Then
            bNadjiMasuIStavDo45(PomMasa1, PomMasa3, outStav)
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
            If inMasa < inOsovine * 5000 Then
                outMasa = inOsovine * 5000
            Else
                outMasa = inMasa
            End If
        End If

        If inTovarena = "PK" Then

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
            outMasa = ((inMasa + 49) / 50) * 50
        Else
            outMasa = ((inMasa + 99) / 100) * 100
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
        spKomanda.Parameters("@outPouzece").Value = outPredujam

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

        Dim spKomanda As New SqlClient.SqlCommand("roba.uspIzrStavK", DbVezaCene)
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

    Public Sub bNadjiPrevozninu00T(ByVal Tabela As String, ByRef Prevoznina As Decimal)
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

                '14.06.
                'TipKola = "7"
                If TipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                ' 14.06.

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

                    PrevozninaPoKolima = 0

                    bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, "25", Masa1R, Masa2R, Masa3R, TonskiStav)
                    TonskiStavInteger = CType(TonskiStav, Integer)
                    MasaTemp = TonskiStavInteger * 1000
                    ' prevoznine po razredima:
                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "1", VozarinskiStav, PV)
                    Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / 10 / 1000
                    ' zaokruzivanje?
                    Prev1R = Prev1R * bPrevozninaKoef
                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "2", VozarinskiStav, PV)
                    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / 10 / 1000
                    ' zaokruzivanje?
                    Prev2R = Prev2R * bPrevozninaKoef
                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "3", VozarinskiStav, PV)
                    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / 10 / 1000
                    ' zaokruzivanje?
                    Prev3R = Prev3R * bPrevozninaKoef
                    PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

                    'zaokruzivanje na 0.10 chf...
                    'bzaokruzina desetenavise(prevozninapokolima)


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

            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "68", bVrstaPosiljke, bVrstaStanice, VlasnistvoKola, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            If (VrstaKola = "2" And VlasnistvoKola = "Z" And GrTovKola > 80000) Then     ' zeleznicka specijalna preko 80t
                'za stvarnu masu
            Else
                bZaokruziMasuNa100k(UkupnaMasa)
            End If

            RacMasa = UkupnaMasa

            bZaokrMasuNaOsovineINadjiKolKoefTEA(RacMasa, TaraKola, GrTovKola, VlasnistvoKola, VrstaKola, _
                                                                        SerijaKola, IFrigo, TovarenaPrazna, BrOsovina, RacMasa, KolKoef)

            bNadjiRIDKoef(bVrstaSaobracaja, mRazredRid, RidKoef)

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

            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnistvoKola, _
                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

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

            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "68", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
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

        VrstaStanice() ' Da li je granicna

        If IzborSaobracaja = "1" Then          ' ----------------- L O K A L ------------------
            '                                             ( UNUTRASNJI TOVARNI LIST )
            ' mVrstaSaobracaja :
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

            If mVrstaSaobracaja = 0 Then
                If mTarifa = "36" Then    ' redovna tarifa
                    bValuta = "72"          'DIN
                    If bKontejneri = False Then
                        mTabelaCena = "121"
                        bNadjiPrevozninu72L(mTabelaCena, mPrevoznina)
                    Else                    ' kontejneri sa kombinacijama
                        bNadjiPrevozninuKont72L(mPrevoznina)
                    End If
                ElseIf mTarifa = "00" Then     ' ugovoriKP
                    'Dim kPrevoznina As Decimal
                    Dim kPov As String
                    If mBrojUg = "911901" Then
                        bNadjiPrevozninu911901L(mPrevoznina, kPov)
                    Else
                        '''''''''''''bNadjiPrevozninuROKP(mPrevoznina, kPov)
                    End If
                End If
            Else                       ' mVrstaSaobracaja <> 0 
                If mTarifa = "36" Then    ' redovna tarifa
                    bValuta = "17"
                    If bKontejneri = False Then
                        mTabelaCena = "122"
                        bNadjiPrevozninu00T(mTabelaCena, mPrevoznina)
                    Else
                        mTabelaCena = "133" ' proveriti!!!
                        bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
                    End If
                ElseIf mTarifa = "00" Then     ' ugovoriKP - isto kao uvoz/izvoz
                    'Dim kPrevoznina As Decimal
                    Dim kPov As String
                    If mBrojUg = "911901" Then
                        bNadjiPrevozninu911901L(mPrevoznina, kPov)
                    Else
                        ''''''''''''bNadjiPrevozninuROKP(mPrevoznina, kPov)
                    End If
                End If
            End If

            ' END LOKAL ( UNUT. T.L. )

        ElseIf IzborSaobracaja = "2" Then      ' ------------------ U V O Z -------------------
            If mTarifa = "36" Then
                bValuta = "17"
                If bKontejneri = False Then
                    mTabelaCena = "122"
                    bNadjiPrevozninu00T(mTabelaCena, mPrevoznina)
                Else
                    mTabelaCena = "133" ' proveriti!!!
                    bNadjiPrevozninuKont(mTabelaCena, mPrevoznina)
                End If
            ElseIf mTarifa = "68" Then
                bValuta = "17"
                If Not (bKontejneri) Then
                    mTabelaCena = "680"
                    bNadjiPrevozninuTEA(mTabelaCena, mPrevoznina)
                Else
                    mTabelaCena = "134"  ' proveriti!!!
                    bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
                End If
            ElseIf mTarifa = "00" Then   ' Ugovori
                Dim pv As Decimal
                Dim por As String = ""
                Dim xNaziv As String = ""
                Dim xPovVrednost As String = ""

                If mVrstaObracuna = "IC" Then   'proveriti
                    Util.sNadjiNaziv("TabNaziv", mBrojUg, "", "", 1, xNaziv, xPovVrednost)
                    mTabelaCena = xNaziv

                    'kada ima vise tabela za isti ugovor, napraviti niz i izabrati prema uslovu ili sl.

                    '------------------------------ uslov zbog vrste voza --------------------------------
                    'If mBrojUg = "993353" Then
                    '    If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
                    '        mTabelaCena = "202"
                    '    Else
                    '        mTabelaCena = "201"
                    '    End If
                    'ElseIf mBrojUg = "993354" Then
                    '    If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
                    '        mTabelaCena = "202"
                    '    Else
                    '        mTabelaCena = "201"
                    '    End If
                    'End If
                    '-------------------------------------------------------------------------------------
                    'ubaciti racunanje vise UTI ako je mTabelaCena=220

                    'StavIcf(mBrojUg, mTabelaCena, mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "", "0", pv, por)

                    If mTabelaCena = 221 Then
                        'bPrevozninaKoef = pv
                        mTabelaCena = "914"
                        bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina) 'isto kao i za TEA
                    Else
                        StavIcf(mBrojUg, mTabelaCena, mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "", "0", pv, por)
                    End If

                    'pv=cena za voz 
                    'Na kraju unosa voza potrebno izracunati bruto masu voza zbog korekcije cene
                    'upisuje se cena samo kod prvih kola u vozu 
                ElseIf mVrstaObracuna = "CO" Then
                    bNadjiPrevozninuCO()
                ElseIf mVrstaObracuna = "RO" Then 'Komercijalne povlastice

                End If

            End If
        ElseIf IzborSaobracaja = "3" Then      ' ----------------- I Z V O Z ------------------
            If mTarifa = "36" Then
                bValuta = "17"
                If bKontejneri = False Then
                    mTabelaCena = "122"
                    bNadjiPrevozninu00T(mTabelaCena, mPrevoznina)
                Else
                    mTabelaCena = "133" ' proveriti!!!
                    bNadjiPrevozninuKont(mTabelaCena, mPrevoznina)
                End If
            ElseIf mTarifa = "68" Then
                bValuta = "17"
                If Not (bKontejneri) Then
                    mTabelaCena = "680"
                    bNadjiPrevozninuTEA(mTabelaCena, mPrevoznina)
                Else
                    mTabelaCena = "134"  ' proveriti!!!
                    bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
                End If
            ElseIf mTarifa = "00" Then   ' Ugovori
                Dim pv As Decimal
                Dim por As String = ""
                Dim xNaziv As String = ""
                Dim xPovVrednost As String = ""

                If mVrstaObracuna = "IC" Then   'proveriti
                    Util.sNadjiNaziv("TabNaziv", mBrojUg, "", "", 1, xNaziv, xPovVrednost)
                    mTabelaCena = xNaziv

                    'kada ima vise tabela za isti ugovor, napraviti niz i izabrati prema uslovu ili sl.

                    '------------------------------ uslov zbog vrste voza --------------------------------
                    'If mBrojUg = "993353" Then
                    '    If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
                    '        mTabelaCena = "202"
                    '    Else
                    '        mTabelaCena = "201"
                    '    End If
                    'ElseIf mBrojUg = "993354" Then
                    '    If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
                    '        mTabelaCena = "202"
                    '    Else
                    '        mTabelaCena = "201"
                    '    End If
                    'End If
                    '-------------------------------------------------------------------------------------
                    'ubaciti racunanje vise UTI ako je mTabelaCena=220

                    'StavIcf(mBrojUg, mTabelaCena, mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "", "0", pv, por)

                    If mTabelaCena = 221 Then
                        'bPrevozninaKoef = pv
                        mTabelaCena = "914"
                        bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina) 'isto kao i za TEA
                    Else
                        StavIcf(mBrojUg, mTabelaCena, mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "", "0", pv, por)
                    End If

                    'pv=cena za voz 
                    'Na kraju unosa voza potrebno izracunati bruto masu voza zbog korekcije cene
                    'upisuje se cena samo kod prvih kola u vozu 
                ElseIf mVrstaObracuna = "CO" Then
                    bNadjiPrevozninuCO()
                ElseIf mVrstaObracuna = "RO" Then

                End If

            End If

        ElseIf IzborSaobracaja = "4" Then      ' --------------- T R A N Z I T ----------------
            If mTarifa = "38" Then
                bValuta = "85"
                If bKontejneri = False Then
                    mTabelaCena = "380"
                    bNadjiPrevozninu00T(mTabelaCena, mPrevoznina)
                Else
                    bNadjiPrevozninuKont(mTabelaCena, mPrevoznina)
                End If
            ElseIf mTarifa = "68" Then
                bValuta = "17"
                If Not (bKontejneri) Then
                    mTabelaCena = "681"
                    bNadjiPrevozninuTEA(mTabelaCena, mPrevoznina)
                Else
                    mTabelaCena = "134"
                    bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
                End If
            ElseIf mTarifa = "00" Then 'Ugovori
                Dim pv As Decimal
                Dim por As String = ""
                Dim xNaziv As String = ""
                Dim xPovVrednost As String = ""

                If mVrstaObracuna = "IC" Then
                    Util.sNadjiNaziv("TabNaziv", mBrojUg, "", "", 1, xNaziv, xPovVrednost)
                    mTabelaCena = xNaziv

                    'kada ima vise tabela za isti ugovor, napraviti niz i izabrati prema uslovu ili sl.

                    '------------------------------ uslov zbog vrste voza --------------------------------
                    If mBrojUg = "993353" Then
                        If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
                            mTabelaCena = "202"
                        Else
                            mTabelaCena = "201"
                        End If
                    ElseIf mBrojUg = "993354" Then
                        If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
                            mTabelaCena = "202"
                        Else
                            mTabelaCena = "201"
                        End If
                    End If
                    '-------------------------------------------------------------------------------------
                    'ubaciti racunanje vise UTI ako je mTabelaCena=220

                    'StavIcf(mBrojUg, mTabelaCena, mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "", "0", pv, por)

                    If mTabelaCena = 221 Then
                        'bPrevozninaKoef = pv
                        mTabelaCena = "914"
                        bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina) 'isto kao i za TEA
                    Else
                        StavIcf(mBrojUg, mTabelaCena, mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "", "0", pv, por)
                    End If

                    'pv=cena za voz 
                    'Na kraju unosa voza potrebno izracunati bruto masu voza zbog korekcije cene
                    'upisuje se cena samo kod prvih kola u vozu 
                ElseIf mVrstaObracuna = "CO" Then
                    bNadjiPrevozninuCO()
                ElseIf mVrstaObracuna = "RO" Then

                End If

            End If
        End If

        bNadjiRacunskuMasuPoPosiljci(bRacunskaMasa)

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
        ElseIf IzborSaobracaja = "4" Then
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

End Module
