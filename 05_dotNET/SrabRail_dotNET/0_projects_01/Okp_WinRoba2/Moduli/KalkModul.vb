Imports System.Data.SqlClient


Module KalkModul
    Public DaLiJe8606 As String = "NE"
    Public USSNHM As String = ""
    Public USSIBK As String = ""
    Public Nhm8606 As String = ""
    Public BMVozaPoTL As Decimal = 0
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
    Public Sub StavIcfN(ByVal ulazUg As String, ByVal TabC As String, ByVal DatumUg As Date, ByVal MasaUg As Int32, ByVal Sta1 As String, ByVal Sta2 As String, _
                                  ByVal Uprava1 As String, ByVal TipKola1 As Char, ByVal Razred1 As Char, ByRef izlazStav As Decimal, _
                                  ByRef izlazRetVal As String)

        'Dim KolaRed, NHMRed As DataRow
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

            ''----------------------- dodati racunanje za ukupan broj UTI -----------------------
            ''za slucajeve mTabelaCena=220, za vozove ne treba
            'Dim PrevozninaPoKolima As Decimal = 0

            'If mTabelaCena = 220 Then
            '    For Each KolaRed In dtKola.Rows
            '        For Each NHMRed In dtNhm.Rows
            '            PrevozninaPoKolima = PrevozninaPoKolima + izlazStav * bPrevozninaKoef
            '        Next
            '        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            '    Next
            '    mPrevoznina = PrevozninaPoKolima
            '    izlazStav = mPrevoznina
            'Else
            '    mPrevoznina = izlazStav.ToString
            'End If

            '' proba na minimalnu prevozninu
            ''If PrevozninaPoKolima <= bMinPrevoznina Then
            ''    PrevozninaPoKolima = bMinPrevoznina
            ''End If
            ''-------------------------------------------------------------------------------------

            ''mPrevoznina = izlazStav.ToString
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
                ByRef outSifraStava As String)

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
    Public Sub bNadjiMasuIStavDo45(ByVal inMasa As Integer, ByRef outMasa As Integer, ByRef outSifraStava As String)

        outMasa = 0
        outSifraStava = ""

        If (inMasa <= 12999.0) Then
            outSifraStava = "10"          ' 10t 
            If inMasa <= 10000.0 Then
                outMasa = 10000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 13000.0) And (inMasa <= 19099.0)) Then
            outSifraStava = "15"           '15t
            If inMasa <= 15000.0 Then
                outMasa = 15000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 19100.0) And (inMasa <= 23899.0)) Then
            outSifraStava = "20"              '20t
            If inMasa <= 20000.0 Then
                outMasa = 20000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 23900.0) And (inMasa <= 29199.0)) Then
            outSifraStava = "25"              '25t
            If inMasa <= 25000.0 Then
                outMasa = 25000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 29200.0) And (inMasa <= 33799.0)) Then
            outSifraStava = "30"              '30t
            If inMasa <= 30000.0 Then
                outMasa = 30000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 33800.0) And (inMasa <= 38299.0)) Then
            outSifraStava = "35"              '35t
            If inMasa <= 35000.0 Then
                outMasa = 35000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 38300.0) And (inMasa <= 42999.0)) Then
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

    Public Sub bNadjiMasuIStavDo45Ug(ByVal inMasa As Integer, ByRef outMasa As Integer, ByRef outSifraStava As String)

        outMasa = 0
        outSifraStava = ""

        If ((inMasa >= 33700.0) And (inMasa <= 38399.0)) Then
            outSifraStava = "35"              '35t
            If inMasa <= 35000.0 Then
                outMasa = 35000.0
            Else : outMasa = inMasa
            End If
        End If

        If ((inMasa >= 38400.0) And (inMasa <= 42399.0)) Then
            outSifraStava = "40"              '40t
            If inMasa <= 40000.0 Then
                outMasa = 40000.0
            Else : outMasa = inMasa
            End If
        End If

        If (inMasa >= 42400.0) Then
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
            If ((bVrstaSaobracaja = 2) Or (bVrstaSaobracaja = 3)) Then
                bNadjiMasuIStavGM("122", PomMasa1, bTkm, RMax, PomMasa3, outStav, PV)  ' proveriti da li je Rmax
            Else
                bNadjiMasuIStavDo45(PomMasa1, PomMasa3, outStav)
            End If
        End If

        ' dodavanje razlike na najvecu masu ( ako su iste - na skuplju )
        ' iskljuèeno za HNM 860800: za sopstvenu masu kola!
        If Microsoft.VisualBasic.Left(Nhm8606, 4) = "8604" Or _
           Microsoft.VisualBasic.Left(Nhm8606, 4) = "8605" Or _
           Microsoft.VisualBasic.Left(Nhm8606, 4) = "8606" Then
            outMasa1 = outMasa1

        Else
            If RMax = 1 Then
                outMasa1 = outMasa1 + (PomMasa3 - ZaokMasaPoKolima)
            End If

            If RMax = 2 Then
                outMasa2 = outMasa2 + (PomMasa3 - ZaokMasaPoKolima)
            End If

            If RMax = 3 Then
                outMasa3 = outMasa3 + (PomMasa3 - ZaokMasaPoKolima)
            End If

        End If

        'If RMax = 1 Then
        '    outMasa1 = outMasa1 + (PomMasa3 - ZaokMasaPoKolima)
        'End If

        'If RMax = 2 Then
        '    outMasa2 = outMasa2 + (PomMasa3 - ZaokMasaPoKolima)
        'End If

        'If RMax = 3 Then
        '    outMasa3 = outMasa3 + (PomMasa3 - ZaokMasaPoKolima)
        'End If

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
                ByVal inGrTovarenja As Decimal, _
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
        ' outMasa - izlazna raèunska masa
        ' outKolKoef - izlazni koeficijent

        Dim tmp_GrToDec As Decimal
        outKolKoef = 1
        If inMasa < 5000 * inOsovine Then
            outMasa = 5000 * inOsovine
        Else
            outMasa = inMasa
        End If

        If inVlasnistvo = "Z" Then

            If Microsoft.VisualBasic.Mid(inSerija, 1, 1) = "I" Then
                'outMasa = (20000 * inOsovine - inTara) / 2              ' proveriti jedinice

                tmp_GrToDec = (inGrTovarenja * 1000) / 2

                outMasa = CType(tmp_GrToDec, Int32)

                If outMasa < inMasa Then
                    outMasa = inMasa
                End If

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

            ElseIf Microsoft.VisualBasic.Mid(inSerija, 1, 1) = "L" Or Microsoft.VisualBasic.Mid(inSerija, 1, 1) = "S" Then
                outMasa = 20000

                If outMasa < inMasa Then
                    outMasa = inMasa
                End If

                outKolKoef = 1
            End If

            If inGrTovarenja > 80 And inGrTovarenja < 120 Then
                outMasa = 18000
                If outMasa < inMasa Then
                    outMasa = inMasa
                End If

                outKolKoef = 1.4
            End If
            If inGrTovarenja >= 120 Then
                outMasa = 18000
                If outMasa < inMasa Then
                    outMasa = inMasa
                End If

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

                    If DaLiJe8606 = "DA" Then '8606 'IZMENA OKP 26.3.2010
                        outKolKoef = 1
                    Else
                        outKolKoef = 0.7
                    End If

                    'outKolKoef = 0.7 'IZMENA Od 1.5.2008. staro: outKolKoef = 0.8
                End If
            End If

        ElseIf (inVlasnistvo = "S") Then
            outKolKoef = 1
        End If

        If inTovarena = "PK" Then        '   ttv 2/2013
            If inMasa < 10000 Then
                outMasa = 10000
            Else
                outMasa = inMasa
            End If
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
            ByRef outTip As Char)

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
        'outKolKoef = 1

        Select Case 123
            Case 111
                'outKolKoef = 1.0
                outTip = "1"
            Case 211
                'outKolKoef = 1.3
                outTip = "2"
            Case 112
                'outKolKoef = 0.8
                outTip = "3"
            Case 212
                'outKolKoef = 0.8
                outTip = "4"
            Case 113
                'outKolKoef = 0.8
                outTip = "5"
            Case 213
                'outKolKoef = 0.8
                outTip = "6"
            Case 121, 221, 122, 222, 123, 223
                'outKolKoef = 0.3
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

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

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
            'If DbVeza.State = ConnectionState.Closed Then
            '    DbVeza.Open()
            'End If

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
    Public Sub bNadjiRasterAGIT(ByVal inDuzinaKont As String, ByVal inStvMasa As Integer, ByRef outRaster As Decimal)

        Select Case inDuzinaKont
            Case "10"
                If inStvMasa <= 8000 Then
                    outRaster = 0.37
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.45
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 0.55
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 33000 Then
                    outRaster = 0.85
                End If
            Case "20"
                If inStvMasa <= 8000 Then
                    outRaster = 0.37
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.5
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 0.55
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 33000 Then
                    outRaster = 0.85
                End If
            Case "30"
                If inStvMasa <= 8000 Then
                    outRaster = 0.5
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.55
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 33000 Then
                    outRaster = 0.85
                End If
            Case "40"
                If inStvMasa <= 8000 Then
                    outRaster = 0.65
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.65
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 0.85
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 0.85
                ElseIf inStvMasa > 33000 Then
                    outRaster = 0.9
                End If
            Case "50"
                If inStvMasa <= 8000 Then
                    outRaster = 0.7
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 1
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 1
                ElseIf inStvMasa > 33000 Then
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

    Public Sub bNadjiRasterTEA(ByVal inDuzinaKont As String, ByVal inStvMasa As Integer, ByRef outRaster As Decimal)

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
    Public Sub bNadjiRasterCO(ByVal inDuzinaKont As String, ByVal inStvMasa As Integer, ByRef outRaster As Decimal)

        Select Case inDuzinaKont
            Case "10"
                If inStvMasa <= 8000 Then
                    outRaster = 0.37
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.45
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 0.55
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 33000 Then
                    outRaster = 0.85
                End If
            Case "20"
                If inStvMasa <= 8000 Then
                    outRaster = 0.37
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.5
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 0.55
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 33000 Then
                    outRaster = 0.85
                End If
            Case "30"
                If inStvMasa <= 8000 Then
                    outRaster = 0.5
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.55
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 33000 Then
                    outRaster = 0.85
                End If
            Case "40"
                If inStvMasa <= 8000 Then
                    outRaster = 0.65
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.65
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 0.85
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 0.85
                ElseIf inStvMasa > 33000 Then
                    outRaster = 0.9
                End If
            Case "50"
                If inStvMasa <= 8000 Then
                    outRaster = 0.7
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 1
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 1
                ElseIf inStvMasa > 33000 Then
                    outRaster = 1
                End If
            Case "70"
                If inStvMasa <= 8000 Then
                    outRaster = 0.7
                ElseIf inStvMasa > 8000 And inStvMasa <= 16500 Then
                    outRaster = 0.75
                ElseIf inStvMasa > 16500 And inStvMasa <= 22000 Then
                    outRaster = 1
                ElseIf inStvMasa > 22000 And inStvMasa <= 33000 Then
                    outRaster = 1
                ElseIf inStvMasa > 33000 Then
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
    Public Sub bNadjiRIDKoef(ByVal inVrstaSaobr As Integer, ByVal inRIDRazred As Int16, _
                             ByRef outRIDKoef As Decimal)

        If inRIDRazred = 1 Or inRIDRazred = 7 Then
            outRIDKoef = 2
        End If

        'If inRIDRazred = 2 Then
        '    If inVrstaSaobr = 2 Or inVrstaSaobr = 3 Then
        '        outRIDKoef = 1.1
        '    End If
        '    If inVrstaSaobr = 4 Then
        '        outRIDKoef = 1.3
        '    End If

        'End If

        If inRIDRazred = 2 Then
            If ((inVrstaSaobr = 2) Or (inVrstaSaobr = 3)) And (mDatumKalk < (#1/1/2006#)) Then
                outRIDKoef = 1.1
            End If
            If inVrstaSaobr = 4 Then
                outRIDKoef = 1.3
            End If
        End If

    End Sub

    Public Sub bNadjiVozarinskiStav(ByVal inTabelaCena As String, ByVal inDatumKalk As Date, ByVal inMasa As Integer, _
                                    ByVal intkm As Integer, ByVal inRazred As String, ByRef outVozarinskiStav As Decimal, _
                                    ByRef outRetVal As String)


        outRetVal = ""

        Dim outProv As Integer = 0

        Dim spKomanda As New SqlClient.SqlCommand("radnik.uspIzrStav", DbVezaCene)
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

        Dim spKomanda As New SqlClient.SqlCommand("radnik.uspIzrStavKTea", DbVezaCene)
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
        'za test: Public Sub bNadjiPrevozninu00T15(ByVal Tabela As String, ByRef Prevoznina As Decimal)
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

        Dim bDoTona As String ' ZA PROBU
        Dim bStitna As String


        Dim PrevozninaPoPosiljci As Decimal = 0


        ''If mTarifa = "36" Then
        ''    bDoTona = "45"
        ''Else

        ''End If
        If mTarifa = "36" And (mDatumKalk >= #2/1/2008#) Then
            bDoTona = "45"
        Else
            bDoTona = "25"
        End If

        '''''''bDoTona = "45"  'OD 1. FEBRUARA 2008. 

        ''If (bVrstaSaobracaja = 2 Or bVrstaSaobracaja = 3) Then ' dodati jos, na pr. saobr. sa CG, ako bude 
        ''    bDoTona = "45"
        ''Else
        ''    bDoTona = "25"
        ''End If

        Dim Ka As Decimal = 1

        If bVrstaSaobracaja = 4 Then
            Ka = 10
        End If

        If mBrojUg = "200379" Then 'Uss ex-im
            bStavKoef = 0.5
        End If

        Prevoznina = 0
        bRedovanOrocen = "R"


        If mVrstaPrevoza = "P" Then

            If dtKola.Rows.Count > 0 Then
                'RedniBroj = 0
                Dim _tmpBrojac As Int32 = 1
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

                    bProveri8606(_mNHM, bNHM8606, bNHMKao8606)

                    Dim TovPraMP As String
                    Dim VlasnMP As String
                    bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                    If VlasnMP = "" Then
                        VlasnMP = Vlasnistvo
                    End If
                    If (bNHM8606 Or bNHMKao8606) Then
                        If TovPraMP = "" Then
                            TovPraMP = "PK"
                        End If
                        bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                               TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                        ' Tarifa 2015

                        'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                        '       "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                        '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                    Else
                        If TovPraMP = "" Then
                            TovPraMP = TovarenaPrazna
                        End If
                        bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                               TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                        ' Tarifa 2015

                        'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                        '       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                        '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                    End If


                    ' 14.06.

                    'Select Case TipKola
                    '    Case "1"
                    '        KolKoef = 1.0
                    '    Case "2"
                    '        KolKoef = 1.3
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
                                'NHMRed.Item("RacMasaNHM") = MasaTemp
                                '### 

                                If Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8604" Or _
                                   Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8605" Or _
                                   Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8606" Then
                                    KolKoef = 1 ' Mandic,Slavica: bilo 0.7   bilo : 'Tumacenje iz ug. cl.2 tac.10 ; bilo: KolKoef = 1
                                End If

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
                            'Dim TovPraMP As String                            
                            'Dim VlasnMP As String
                            bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                            If TovPraMP = "" Then
                                TovPraMP = TovarenaPrazna
                            End If
                            If VlasnMP = "" Then
                                VlasnMP = Vlasnistvo
                            End If

                            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                                                 TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                                 bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                            ' Tarifa 2015
                            'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                            '                     TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                            '                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


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

                        If Masa2R > 0 Then
                            bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "2", VozarinskiStav, PV)
                            Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000
                            ' zaokruzivanje?
                            '###
                            If (Not (Masa2R = 0) And (Masa1R = 0)) Then
                                bVozarinskiStavPoKolima = VozarinskiStav
                            End If
                            '###
                            Prev2R = Prev2R * bPrevozninaKoef
                        End If

                        If Masa3R > 0 Then
                            bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "3", VozarinskiStav, PV)
                            Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000
                            ' zaokruzivanje?
                            '###
                            If (Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0)) Then
                                bVozarinskiStavPoKolima = VozarinskiStav
                            End If
                            '###
                            Prev3R = Prev3R * bPrevozninaKoef
                        End If

                        PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

                        '### 
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
                            End If
                        Next
                        '### 

                        'zaokruzivanje na 0.10 chf...
                        'bzaokruzina desetenavise(prevozninapokolima)


                        ' Testiraj na minimalnu prevozninu
                        RacMasaPoKolima = Masa1R + Masa2R + Masa3R
                        bRacunskaMasaPoKolima = RacMasaPoKolima


                        'kao u TEA 
                        If bStitna = "D" Then
                            If TovarenaPrazna = "PK" Then
                                'PrevozninaPoKolima = 0
                                PrevozninaPoKolima = 0.12 * BrOsovina * bTkm
                            Else
                                'PrevozninapoKolima ostaje
                            End If
                        End If

                        If nmNarPos And _tmpBrojac <= bNPUkupno Then
                            PrevozninaPoKolima = PrevozninaPoKolima * bNPKoef
                        End If

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

                    _tmpBrojac = _tmpBrojac + 1

                Next    ' petlja po kolima

            Else
                ' nema ni kola ni prevoznine
            End If


        ElseIf (mVrstaPrevoza = "G" Or mVrstaPrevoza = "V") Then

            ' ukinuto je zaokruzivanje pojedinacnih masa na 100k i grupisanje po razredima
            ' sabiraju se sve stvarne mase, suma se podeli ukupnim brojem kola, zaokruzi na 100k i to je zaokruzena prosecna racunska masa po kolima
            ' za zaokruzenu prosecnu racunsku masu po kolima se nadje stav
            ' razdvoji se i akumulira broj kola po tipovima



            ' racunska masa po posiljci je ( brojkola x zaokruzena prosecna racunska masa po kolima )
            If dtKola.Rows.Count > 0 Then
                'RedniBroj = 0
                Dim _tmpBrojac As Int32 = 1
                Dim UkupnaStvarnaMasa As Integer = 0
                'Dim PrevozninaPoPosiljci As Decimal = 0

                Dim UkKolaT1 As Int32 = 0
                Dim UkKolaT2 As Int32 = 0
                Dim UkKolaT3 As Int32 = 0
                Dim UkKolaT4 As Int32 = 0
                Dim UkKolaT5 As Int32 = 0
                Dim UkKolaT6 As Int32 = 0
                Dim UkKolaT7 As Int32 = 0
                Dim KolKoefT1 As Decimal = 0
                Dim KolKoefT2 As Decimal = 0
                Dim KolKoefT3 As Decimal = 0
                Dim KolKoefT4 As Decimal = 0
                Dim KolKoefT5 As Decimal = 0
                Dim KolKoefT6 As Decimal = 0
                Dim KolKoefT7 As Decimal = 0

                Dim UkupnoZKola As Int32 = 0
                Dim UkupnoPKola As Int32 = 0

                Dim UkupnoOsovina As Int32 = 0

                Dim MinPrevZ As Decimal = 0
                Dim MinPrevP As Decimal = 0
                Dim MinPrevZaPosiljku As Decimal = 0

                Dim MasaR As Decimal = 0                ' radna promenljiva
                Dim RacunskaMasaPoPosiljci As Decimal = 0

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

                    'bProveri8606(_mNHM, bNHM8606, bNHMKao8606)

                    'If (bNHM8606 Or bNHMKao8606) Then
                    '    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                    '           "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                    '           bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                    'Else
                    '    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                    '           TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                    '           bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                    'End If

                    Select Case TipKola
                        Case "1"
                            If UkKolaT1 = 0 Then
                                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoefT1, PV)
                            End If
                            UkKolaT1 = UkKolaT1 + 1
                        Case "2"
                            If UkKolaT2 = 0 Then
                                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoefT2, PV)
                            End If
                            UkKolaT2 = UkKolaT2 + 1
                        Case "3"
                            If UkKolaT3 = 0 Then
                                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoefT3, PV)
                            End If
                            UkKolaT3 = UkKolaT3 + 1
                        Case "4"
                            If UkKolaT4 = 0 Then
                                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoefT4, PV)
                            End If
                            UkKolaT4 = UkKolaT4 + 1
                        Case "5"
                            If UkKolaT5 = 0 Then
                                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoefT5, PV)
                            End If
                            UkKolaT5 = UkKolaT5 + 1
                        Case "6"
                            If UkKolaT6 = 0 Then
                                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoefT6, PV)
                            End If
                            UkKolaT6 = UkKolaT6 + 1
                        Case "7"
                            If UkKolaT7 = 0 Then
                                bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoefT7, PV)
                            End If
                            UkKolaT7 = UkKolaT7 + 1
                    End Select

                    If Vlasnistvo = "Z" Then
                        If UkupnoZKola = 0 Then
                            Dim TovPraMP As String
                            Dim VlasnMP As String
                            bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                            If TovPraMP = "" Then
                                TovPraMP = TovarenaPrazna
                            End If
                            If VlasnMP = "" Then
                                VlasnMP = "Z"
                            End If
                            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                                                          TovPraMP, MinPrevZ, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                                          bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                            ' Tarifa 2015
                            'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, "Z", _
                            '                              TovarenaPrazna, MinPrevZ, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                            '                              bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                        End If
                        UkupnoZKola = UkupnoZKola + 1
                    ElseIf Vlasnistvo = "P" Then
                        If UkupnoPKola = 0 Then
                            Dim TovPraMP As String
                            Dim VlasnMP As String
                            bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                            If TovPraMP = "" Then
                                TovPraMP = TovarenaPrazna
                            End If
                            If VlasnMP = "" Then
                                VlasnMP = "P"
                            End If
                            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, "P", _
                                                          TovPraMP, MinPrevP, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                                          bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                            ' Tarifa 2015
                            'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, "P", _
                            '                              TovarenaPrazna, MinPrevP, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                            '                              bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                        End If
                        UkupnoPKola = UkupnoPKola + 1
                    End If

                    UkupnoOsovina = UkupnoOsovina + BrOsovina

                    'pubSerijaKola = KolaRed.Item("Serija") '## T kola
                    'pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola

                    Dim PrevR As Decimal = 0
                    If dtNhm.Rows.Count > 0 Then
                        Masa1R = 0
                        Masa2R = 0
                        Masa3R = 0

                        For Each NHMRed In dtNhm.Rows   '  petlja po robi, ako je vise roba na jednim kolima
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                MasaTemp = NHMRed.Item("Masa")
                                Razred = NHMRed.Item("R")
                                'bZaokruziMasuNa100k(MasaTemp)

                                If Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8604" Or _
                                   Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8605" Or _
                                   Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8606" Then
                                    KolKoef = 1 ' Mandic,Slavica: bilo 0.7   bilo : 'Tumacenje iz ug. cl.2 tac.10 ; bilo: KolKoef = 1
                                End If

                                Select Case Razred                                         'grupisanje po razredima 
                                    Case "1"
                                        Masa1R = Masa1R + MasaTemp
                                    Case "2"
                                        Masa2R = Masa2R + MasaTemp
                                    Case "3"
                                        Masa3R = Masa3R + MasaTemp
                                End Select

                            End If
                        Next

                        MasaR = Masa1R + Masa2R + Masa3R            ' moze da postoji samo jedna

                        UkupnaStvarnaMasa = UkupnaStvarnaMasa + MasaR

                        ' Dodato zbog praznih kola
                        NHM = NHMRed.Item("NHM")
                        If ((Microsoft.VisualBasic.Left(NHM, 4) = "9921" Or Microsoft.VisualBasic.Left(NHM, 4) = "9922")) Then

                            TovarenaPrazna = "PK"

                            Dim TovPraMP As String
                            Dim VlasnMP As String
                            bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                            If TovPraMP = "" Then
                                TovPraMP = TovarenaPrazna
                            End If
                            If VlasnMP = "" Then
                                VlasnMP = Vlasnistvo
                            End If
                            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                                                 TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                                 bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                            ' Tarifa 2015
                            'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                            '                     TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                            '                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


                            If (mDatumKalk >= #2/1/2008#) Then
                                bDoTona = "45"
                                TonskiStav = "45"
                                'Masa1R = dtNhm.Rows(0).Item("Masa")
                                bZaokruziMasuNa100k(MasaR)
                                Masa1R = MasaR
                            Else
                                bDoTona = "25"

                                'TonskiStav = "25"
                            End If
                        End If
                        ' Dodato zbog praznih kola

                        'RacMasaPoKolima = Masa1R + Masa2R + Masa3R

                        'kao u TEA 
                        'If bStitna = "D" Then
                        '    If TovarenaPrazna = "PK" Then
                        '        'PrevozninaPoKolima = 0
                        '        PrevozninaPoKolima = 0.12 * BrOsovina * bTkm
                        '    Else
                        '        'PrevozninapoKolima ostaje
                        '    End If
                        'End If

                        'If nmNarPos And _tmpBrojac <= bNPUkupno Then
                        '    PrevozninaPoKolima = PrevozninaPoKolima * bNPKoef
                        'End If

                    End If

                    _tmpBrojac = _tmpBrojac + 1

                Next    ' petlja po kolima

                Dim bProsecnaStvarnaMasa As Integer = 0
                Dim bZaokruzenaProsecnaStvarnaMasa As Integer = 0
                bProsecnaStvarnaMasa = UkupnaStvarnaMasa / dtKola.Rows.Count
                bZaokruziMasuNa100k(bProsecnaStvarnaMasa)

                bZaokruzenaProsecnaStvarnaMasa = bProsecnaStvarnaMasa

                If Razred = "1" Then
                    Masa1R = bZaokruzenaProsecnaStvarnaMasa
                    Masa2R = 0
                    Masa2R = 0
                Else
                    Masa1R = 0
                    Masa2R = bZaokruzenaProsecnaStvarnaMasa
                    Masa3R = 0
                End If

                bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, bDoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                MasaR = Masa1R + Masa2R + Masa3R


                TonskiStavInteger = CType(TonskiStav, Integer)
                MasaTemp = TonskiStavInteger * 1000
                RacunskaMasaPoPosiljci = MasaR * dtKola.Rows.Count
                '====================

                If RacunskaMasaPoPosiljci < 5000 * UkupnoOsovina Then
                    RacunskaMasaPoPosiljci = 5000 * UkupnoOsovina

                    bProsecnaStvarnaMasa = RacunskaMasaPoPosiljci / dtKola.Rows.Count
                    bZaokruziMasuNa100k(bProsecnaStvarnaMasa)

                    bZaokruzenaProsecnaStvarnaMasa = bProsecnaStvarnaMasa

                    If Razred = "1" Then
                        Masa1R = bZaokruzenaProsecnaStvarnaMasa
                        Masa2R = 0
                        Masa2R = 0
                    Else
                        Masa1R = 0
                        Masa2R = bZaokruzenaProsecnaStvarnaMasa
                        Masa3R = 0
                    End If

                    bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, bDoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                    MasaR = Masa1R + Masa2R + Masa3R

                    TonskiStavInteger = CType(TonskiStav, Integer)
                    MasaTemp = TonskiStavInteger * 1000

                End If
                If mVrstaPrevoza = "V" Then
                    If dtKola.Rows.Count > 1 Then
                        If RacunskaMasaPoPosiljci < 600000 Then
                            RacunskaMasaPoPosiljci = 600000
                        End If
                    Else
                        If RacunskaMasaPoPosiljci < 5000 * UkupnoOsovina Then
                            RacunskaMasaPoPosiljci = 5000 * UkupnoOsovina
                            'bProsecnaStvarnaMasa = RacunskaMasaPoPosiljci / dtKola.Rows.Count
                        End If
                    End If

                    'bZaokruziMasuNa100k(bProsecnaStvarnaMasa)

                    'bZaokruzenaProsecnaStvarnaMasa = bProsecnaStvarnaMasa

                    'If Razred = "1" Then
                    '    Masa1R = bZaokruzenaProsecnaStvarnaMasa
                    '    Masa2R = 0
                    '    Masa2R = 0
                    'Else
                    '    Masa1R = 0
                    '    Masa2R = bZaokruzenaProsecnaStvarnaMasa
                    '    Masa3R = 0
                    'End If

                    'bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, bDoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                    'MasaR = Masa1R + Masa2R + Masa3R

                    'TonskiStavInteger = CType(TonskiStav, Integer)
                    'MasaTemp = TonskiStavInteger * 1000

                    bProsecnaStvarnaMasa = RacunskaMasaPoPosiljci / dtKola.Rows.Count
                    bZaokruziMasuNa100k(bProsecnaStvarnaMasa)

                    bZaokruzenaProsecnaStvarnaMasa = bProsecnaStvarnaMasa

                    If Razred = "1" Then
                        Masa1R = bZaokruzenaProsecnaStvarnaMasa
                        Masa2R = 0
                        Masa2R = 0
                    Else
                        Masa1R = 0
                        Masa2R = bZaokruzenaProsecnaStvarnaMasa
                        Masa3R = 0
                    End If

                    bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, bDoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                    MasaR = Masa1R + Masa2R + Masa3R

                    TonskiStavInteger = CType(TonskiStav, Integer)
                    MasaTemp = TonskiStavInteger * 1000

                End If
                '


                bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, Razred, VozarinskiStav, PV)
                '====================

                ''''TonskiStavInteger = CType(TonskiStav, Integer)
                ''''MasaTemp = TonskiStavInteger * 1000
                ''''bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, Razred, VozarinskiStav, PV)

                ''''' minimalna masa
                ''''' UkupnoOsovina * 5000kg za grupu i voz; 600.000kg za voz
                ''''RacunskaMasaPoPosiljci = MasaR * dtKola.Rows.Count

                ''''If RacunskaMasaPoPosiljci < 5000 * UkupnoOsovina Then
                ''''    RacunskaMasaPoPosiljci = 5000 * UkupnoOsovina
                ''''End If


                'If mVrstaPrevoza = "V" Then
                '    If RacunskaMasaPoPosiljci < 600000 Then
                '        RacunskaMasaPoPosiljci = 600000

                '        '-------------------------------------------------
                '        bProsecnaStvarnaMasa = RacunskaMasaPoPosiljci / dtKola.Rows.Count
                '        bZaokruziMasuNa100k(bProsecnaStvarnaMasa)

                '        bZaokruzenaProsecnaStvarnaMasa = bProsecnaStvarnaMasa

                '        If Razred = "1" Then
                '            Masa1R = bZaokruzenaProsecnaStvarnaMasa
                '            Masa2R = 0
                '            Masa2R = 0
                '        Else
                '            Masa1R = 0
                '            Masa2R = bZaokruzenaProsecnaStvarnaMasa
                '            Masa3R = 0
                '        End If

                '        bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, bDoTona, Masa1R, Masa2R, Masa3R, TonskiStav)
                '        MasaR = Masa1R + Masa2R + Masa3R

                '        TonskiStavInteger = CType(TonskiStav, Integer)
                '        MasaTemp = TonskiStavInteger * 1000
                '        bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, Razred, VozarinskiStav, PV)
                '        '-------------------------------------------------
                '    Else
                '        PrevozninaPoPosiljci = MasaR * VozarinskiStav * (UkKolaT1 * KolKoefT1 + UkKolaT2 * KolKoefT2 + UkKolaT3 * KolKoefT3 + _
                '                               UkKolaT4 * KolKoefT4 + UkKolaT5 * KolKoefT5 + UkKolaT6 * KolKoefT6 + UkKolaT7 * KolKoefT7) / Ka / 1000
                '    End If
                'Else
                '    PrevozninaPoPosiljci = MasaR * VozarinskiStav * (UkKolaT1 * KolKoefT1 + UkKolaT2 * KolKoefT2 + UkKolaT3 * KolKoefT3 + _
                '                           UkKolaT4 * KolKoefT4 + UkKolaT5 * KolKoefT5 + UkKolaT6 * KolKoefT6 + UkKolaT7 * KolKoefT7) / Ka / 1000
                'End If
                ' minimalna masa

                'PrevR = MasaR * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000


                PrevozninaPoPosiljci = MasaR * VozarinskiStav * (UkKolaT1 * KolKoefT1 + UkKolaT2 * KolKoefT2 + UkKolaT3 * KolKoefT3 + _
                                       UkKolaT4 * KolKoefT4 + UkKolaT5 * KolKoefT5 + UkKolaT6 * KolKoefT6 + UkKolaT7 * KolKoefT7) / Ka / 1000


                ' minimalna prevoznina 
                MinPrevZaPosiljku = UkupnoZKola * MinPrevZ + UkupnoPKola * MinPrevP
                If PrevozninaPoPosiljci < MinPrevZaPosiljku Then
                    PrevozninaPoPosiljci = MinPrevZaPosiljku
                End If
                ' minimalna prevoznina 


                For Each KolaRed In dtKola.Rows
                    IBK = KolaRed.Item("IndBrojKola")
                    KolaRed.Item("RacunskaMasa") = MasaR
                    KolaRed.Item("Vozarinskistav") = VozarinskiStav

                    For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                            NHMRed.Item("RacMasaNHM") = MasaR
                        End If
                    Next
                Next

            Else
                ' nema ni kola ni prevoznine
            End If

            Prevoznina = PrevozninaPoPosiljci
        End If

        If (mBrojUg = "200379") And dtNhm.Rows(0).Item("NHM") = "992200" And mVrstaPrevoza <> "P" Then '(dtKola.Rows.Count >= 6) Then
            Dim UkupnaStvarnaMasa As Decimal = 0
            Dim ProsecnaMasa As Decimal = 0
            Dim ZaokruzenaProsecnaMasa As Decimal = 0

            If Not (((mStanica1 = "13670") And (mStanica2 = "13603")) Or ((mStanica2 = "13670") And (mStanica1 = "13603"))) Then

                ' nije Radinac-Smederevo + v.v.

                For Each KolaRed In dtKola.Rows    ' petlja po kolima                    
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


                    If dtNhm.Rows.Count > 0 Then
                        Masa1R = 0

                        For Each NHMRed In dtNhm.Rows   '  petlja po robi
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                MasaTemp = NHMRed.Item("Masa")

                                Masa1R = Masa1R + MasaTemp

                            End If
                        Next

                    End If
                    UkupnaStvarnaMasa = UkupnaStvarnaMasa + Masa1R
                Next    ' petlja po kolima

                bNadjiVozarinskiStav(Tabela, mDatumKalk, 45000, bTkm, "1", VozarinskiStav, PV)

                bVozarinskiStavPoKolima = VozarinskiStav

                ProsecnaMasa = UkupnaStvarnaMasa / dtKola.Rows.Count
                MasaTemp = ProsecnaMasa
                bZaokruziMasuNa100k(MasaTemp)
                ZaokruzenaProsecnaMasa = MasaTemp
                Prevoznina = ZaokruzenaProsecnaMasa / 1000 * 0.3 * 0.5 * VozarinskiStav * dtKola.Rows.Count
                bZaokruziNaDeseteNavise(Prevoznina)

                TovarenaPrazna = "PK"

                Dim TovPraMP As String
                Dim VlasnMP As String
                bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                If TovPraMP = "" Then
                    TovPraMP = TovarenaPrazna
                End If
                If VlasnMP = "" Then
                    VlasnMP = Vlasnistvo
                End If

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                                     TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                'Tarifa 2015
                'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                '                                    TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                '                                    bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


                If Prevoznina <= bMinPrevoznina * dtKola.Rows.Count Then
                    Prevoznina = bMinPrevoznina * dtKola.Rows.Count
                End If



                For Each KolaRed In dtKola.Rows    ' petlja po kolima                    
                    IBK = KolaRed.Item("IndBrojKola")
                    bVozarinskiStavPoKolima = VozarinskiStav
                    PrevozninaPoKolima = 0
                    KolaRed.Item("VozarinskiStav") = VozarinskiStav
                    KolaRed.Item("RacunskaMasa") = ZaokruzenaProsecnaMasa
                    KolaRed.Item("Prevoznina") = 0
                    For Each NHMRed In dtNhm.Rows   '  petlja po robi - za upis rac. masa i voz.stavova NHM
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                            NHMRed.Item("RacMasaNHM") = ZaokruzenaProsecnaMasa
                        End If
                    Next
                Next

            ElseIf (((mStanica1 = "13670") And (mStanica2 = "13603")) Or ((mStanica2 = "13670") And (mStanica1 = "13603"))) Then
                ' jeste Radinac-Smederevo + v.v.

                Prevoznina = 0
                bVozarinskiStavPoKolima = VozarinskiStav
                For Each KolaRed In dtKola.Rows    ' petlja po kolima                    
                    IBK = KolaRed.Item("IndBrojKola")
                    bVozarinskiStavPoKolima = VozarinskiStav
                    For Each NHMRed In dtNhm.Rows   '  petlja po robi - za upis rac. masa i voz.stavova NHM
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                            NHMRed.Item("RacMasaNHM") = ZaokruzenaProsecnaMasa
                        End If
                    Next
                Next

            End If
        End If ' "200379"


    End Sub
    ''Public Sub bNadjiPrevozninu00T(ByVal Tabela As String, ByRef Prevoznina As Decimal)
    ''    Dim KolaRed As DataRow
    ''    Dim NHMRed As DataRow
    ''    'Dim RedniBroj As Int32
    ''    Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, NHM As String
    ''    Dim BrOsovina As Byte
    ''    Dim KolKoef As Decimal = 1

    ''    Dim Masa1R, Masa2R, Masa3R As Integer
    ''    Dim MasaTemp As Integer
    ''    Dim Razred As String
    ''    Dim TonskiStav As String
    ''    Dim Prev1R, Prev2R, Prev3R As Decimal
    ''    Dim VozarinskiStav As Decimal
    ''    Dim PV As String
    ''    Dim TonskiStavInteger As Integer

    ''    Dim PrevozninaPoKolima As Decimal = 0
    ''    Dim RacMasaPoKolima As Integer

    ''    Dim bDoTona As String ' ZA PROBU
    ''    Dim bStitna As String

    ''    ''If mTarifa = "36" Then
    ''    ''    bDoTona = "45"
    ''    ''Else

    ''    ''End If
    ''    If mTarifa = "36" And (mDatumKalk >= #2/1/2008#) Then
    ''        bDoTona = "45"
    ''    Else
    ''        bDoTona = "25"
    ''    End If

    ''    '''''''bDoTona = "45"  'OD 1. FEBRUARA 2008. 

    ''    ''If (bVrstaSaobracaja = 2 Or bVrstaSaobracaja = 3) Then ' dodati jos, na pr. saobr. sa CG, ako bude 
    ''    ''    bDoTona = "45"
    ''    ''Else
    ''    ''    bDoTona = "25"
    ''    ''End If

    ''    Dim Ka As Decimal = 1

    ''    If bVrstaSaobracaja = 4 Then
    ''        Ka = 10
    ''    End If

    ''    If mBrojUg = "200379" Then 'Uss ex-im
    ''        bStavKoef = 0.5
    ''    End If

    ''    Prevoznina = 0
    ''    bRedovanOrocen = "R"

    ''    If dtKola.Rows.Count > 0 Then
    ''        'RedniBroj = 0
    ''        Dim _tmpBrojac As Int32 = 1
    ''        For Each KolaRed In dtKola.Rows    ' petlja po kolima
    ''            ' ucitavanje polja

    ''            'dodeliti vrednosti za promenljive

    ''            IBK = KolaRed.Item("IndBrojKola")
    ''            Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
    ''            TipKola = Left(KolaRed.Item("Tip"), 1)
    ''            Vlasnistvo = KolaRed.Item("Vlasnik")
    ''            BrOsovina = KolaRed.Item("Osovine")
    ''            bStitna = KolaRed.Item("Stitna")


    ''            '$$$
    ''            If Vrsta = "O" Then
    ''                Vrsta = 1
    ''            End If
    ''            If Vrsta = "S" Then
    ''                Vrsta = 2
    ''            End If
    ''            '$$$

    ''            '14.06.
    ''            'TipKola = "7"
    ''            If TipKola = "7" Then
    ''                TovarenaPrazna = "PK"
    ''            Else
    ''                TovarenaPrazna = "TK"
    ''            End If

    ''            bProveri8606(_mNHM, bNHM8606, bNHMKao8606)

    ''            If (bNHM8606 Or bNHMKao8606) Then
    ''                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
    ''                       "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
    ''                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
    ''            Else
    ''                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
    ''                       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
    ''                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
    ''            End If

    ''            ' 14.06.

    ''            'Select Case TipKola
    ''            '    Case "1"
    ''            '        KolKoef = 1.0
    ''            '    Case "2"
    ''            '        KolKoef = 1.3
    ''            '    Case "3"
    ''            '        KolKoef = 0.8
    ''            '    Case "4"
    ''            '        KolKoef = 0.8
    ''            '    Case "5"
    ''            '        KolKoef = 0.8
    ''            '    Case "6"
    ''            '        KolKoef = 0.8
    ''            '    Case "7"
    ''            '        KolKoef = 0.3
    ''            'End Select

    ''            pubSerijaKola = KolaRed.Item("Serija") '## T kola
    ''            pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola

    ''            bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)


    ''            Dim Masa100 As Integer
    ''            If dtNhm.Rows.Count > 0 Then
    ''                Masa1R = 0
    ''                Masa2R = 0
    ''                Masa3R = 0
    ''                Prev1R = 0
    ''                Prev2R = 0
    ''                Prev3R = 0

    ''                For Each NHMRed In dtNhm.Rows   '  petlja po robi
    ''                    If NHMRed.Item("IndBrojKola") = IBK Then
    ''                        MasaTemp = NHMRed.Item("Masa")
    ''                        Razred = NHMRed.Item("R")
    ''                        bZaokruziMasuNa100k(MasaTemp)
    ''                        '### 
    ''                        NHMRed.Item("RacMasaNHM") = MasaTemp
    ''                        '### 

    ''                        If Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8604" Or _
    ''                           Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8605" Or _
    ''                           Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8606" Then
    ''                            KolKoef = 1 ' Mandic,Slavica: bilo 0.7   bilo : 'Tumacenje iz ug. cl.2 tac.10 ; bilo: KolKoef = 1
    ''                        End If

    ''                        Select Case Razred                                        ' grupisanje po razredima
    ''                            Case "1"
    ''                                Masa1R = Masa1R + MasaTemp
    ''                            Case "2"
    ''                                Masa2R = Masa2R + MasaTemp
    ''                            Case "3"
    ''                                Masa3R = Masa3R + MasaTemp
    ''                        End Select
    ''                    End If
    ''                Next

    ''                Masa100 = Masa1R

    ''                PrevozninaPoKolima = 0

    ''                bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, bDoTona, Masa1R, Masa2R, Masa3R, TonskiStav)

    ''                'If (bVrstaSaobracaja = 2 Or bVrstaSaobracaja = 3) And TipKola = "7" Then
    ''                '    TonskiStav = "45"
    ''                'End If

    ''                ' Dodato zbog praznih kola
    ''                NHM = NHMRed.Item("NHM")
    ''                If ((Microsoft.VisualBasic.Left(NHM, 4) = "9921" Or Microsoft.VisualBasic.Left(NHM, 4) = "9922")) Then

    ''                    TovarenaPrazna = "PK"
    ''                    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
    ''                                         TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
    ''                                         bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

    ''                    If (mDatumKalk >= #2/1/2008#) Then
    ''                        bDoTona = "45"
    ''                        TonskiStav = "45"
    ''                        'Masa1R = dtNhm.Rows(0).Item("Masa")
    ''                        bZaokruziMasuNa100k(Masa100)
    ''                        Masa1R = Masa100
    ''                    Else
    ''                        bDoTona = "25"

    ''                        'TonskiStav = "25"
    ''                    End If
    ''                End If
    ''                ' Dodato zbog praznih kola

    ''                ' -----
    ''                TonskiStavInteger = CType(TonskiStav, Integer)
    ''                MasaTemp = TonskiStavInteger * 1000
    ''                ' prevoznine po razredima:
    ''                bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "1", VozarinskiStav, PV)
    ''                Prev1R = Masa1R * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000
    ''                ' zaokruzivanje?
    ''                '###
    ''                If (Not (Masa1R = 0)) Then
    ''                    bVozarinskiStavPoKolima = VozarinskiStav
    ''                End If
    ''                '###

    ''                Prev1R = Prev1R * bPrevozninaKoef

    ''                If Masa2R > 0 Then
    ''                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "2", VozarinskiStav, PV)
    ''                    Prev2R = Masa2R * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000
    ''                    ' zaokruzivanje?
    ''                    '###
    ''                    If (Not (Masa2R = 0) And (Masa1R = 0)) Then
    ''                        bVozarinskiStavPoKolima = VozarinskiStav
    ''                    End If
    ''                    '###
    ''                    Prev2R = Prev2R * bPrevozninaKoef
    ''                End If

    ''                If Masa3R > 0 Then
    ''                    bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, "3", VozarinskiStav, PV)
    ''                    Prev3R = Masa3R * bStavKoef * VozarinskiStav * KolKoef / Ka / 1000
    ''                    ' zaokruzivanje?
    ''                    '###
    ''                    If (Not (Masa3R = 0) And (Masa1R = 0) And (Masa2R = 0)) Then
    ''                        bVozarinskiStavPoKolima = VozarinskiStav
    ''                    End If
    ''                    '###
    ''                    Prev3R = Prev3R * bPrevozninaKoef
    ''                End If

    ''                PrevozninaPoKolima = Prev1R + Prev2R + Prev3R                 ' po kolima !!!!!

    ''                '### 
    ''                For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM
    ''                    If NHMRed.Item("IndBrojKola") = IBK Then
    ''                        '### 
    ''                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
    ''                        Select Case NHMRed.Item("R")                                       ' grupisanje po razredima
    ''                            Case "1"
    ''                                NHMRed.Item("RacMasaNHM") = Masa1R
    ''                            Case "2"
    ''                                NHMRed.Item("RacMasaNHM") = Masa2R
    ''                            Case "3"
    ''                                NHMRed.Item("RacMasaNHM") = Masa3R
    ''                        End Select
    ''                        '### 
    ''                    End If
    ''                Next
    ''                '### 

    ''                'zaokruzivanje na 0.10 chf...
    ''                'bzaokruzina desetenavise(prevozninapokolima)


    ''                ' Testiraj na minimalnu prevozninu
    ''                RacMasaPoKolima = Masa1R + Masa2R + Masa3R
    ''                bRacunskaMasaPoKolima = RacMasaPoKolima


    ''                'kao u TEA 
    ''                If bStitna = "D" Then
    ''                    If TovarenaPrazna = "PK" Then
    ''                        'PrevozninaPoKolima = 0
    ''                        PrevozninaPoKolima = 0.12 * BrOsovina * bTkm
    ''                    Else
    ''                        'PrevozninapoKolima ostaje
    ''                    End If
    ''                End If

    ''                If nmNarPos And _tmpBrojac <= bNPUkupno Then
    ''                    PrevozninaPoKolima = PrevozninaPoKolima * bNPKoef
    ''                End If

    ''                If PrevozninaPoKolima <= bMinPrevoznina Then
    ''                    PrevozninaPoKolima = bMinPrevoznina
    ''                End If

    ''                bZaokruziNaDeseteNavise(PrevozninaPoKolima)

    ''                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
    ''                KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
    ''                KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima

    ''            End If
    ''            Prevoznina = Prevoznina + PrevozninaPoKolima
    ''            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

    ''            _tmpBrojac = _tmpBrojac + 1

    ''        Next    ' petlja po kolima

    ''    Else
    ''        ' nema ni kola ni prevoznine
    ''    End If



    ''    If (mBrojUg = "200379") And dtNhm.Rows(0).Item("NHM") = "992200" And mVrstaPrevoza <> "P" Then '(dtKola.Rows.Count >= 6) Then
    ''        Dim UkupnaStvarnaMasa As Decimal = 0
    ''        Dim ProsecnaMasa As Decimal = 0
    ''        Dim ZaokruzenaProsecnaMasa As Decimal = 0

    ''        If Not (((mStanica1 = "13670") And (mStanica2 = "13603")) Or ((mStanica2 = "13670") And (mStanica1 = "13603"))) Then

    ''            ' nije Radinac-Smederevo + v.v.

    ''            For Each KolaRed In dtKola.Rows    ' petlja po kolima                    
    ''                IBK = KolaRed.Item("IndBrojKola")
    ''                Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
    ''                TipKola = Left(KolaRed.Item("Tip"), 1)
    ''                Vlasnistvo = KolaRed.Item("Vlasnik")
    ''                BrOsovina = KolaRed.Item("Osovine")
    ''                bStitna = KolaRed.Item("Stitna")

    ''                '$$$
    ''                If Vrsta = "O" Then
    ''                    Vrsta = 1
    ''                End If
    ''                If Vrsta = "S" Then
    ''                    Vrsta = 2
    ''                End If
    ''                '$$$

    ''                '14.06.
    ''                'TipKola = "7"
    ''                If TipKola = "7" Then
    ''                    TovarenaPrazna = "PK"
    ''                Else
    ''                    TovarenaPrazna = "TK"
    ''                End If


    ''                If dtNhm.Rows.Count > 0 Then
    ''                    Masa1R = 0

    ''                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
    ''                        If NHMRed.Item("IndBrojKola") = IBK Then
    ''                            MasaTemp = NHMRed.Item("Masa")

    ''                            Masa1R = Masa1R + MasaTemp

    ''                        End If
    ''                    Next

    ''                End If
    ''                UkupnaStvarnaMasa = UkupnaStvarnaMasa + Masa1R
    ''            Next    ' petlja po kolima

    ''            bNadjiVozarinskiStav(Tabela, mDatumKalk, 45000, bTkm, "1", VozarinskiStav, PV)

    ''            bVozarinskiStavPoKolima = VozarinskiStav

    ''            ProsecnaMasa = UkupnaStvarnaMasa / dtKola.Rows.Count
    ''            MasaTemp = ProsecnaMasa
    ''            bZaokruziMasuNa100k(MasaTemp)
    ''            ZaokruzenaProsecnaMasa = MasaTemp
    ''            Prevoznina = ZaokruzenaProsecnaMasa / 1000 * 0.3 * 0.5 * VozarinskiStav * dtKola.Rows.Count
    ''            bZaokruziNaDeseteNavise(Prevoznina)

    ''            TovarenaPrazna = "PK"
    ''            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
    ''                                 TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
    ''                                 bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

    ''            If Prevoznina <= bMinPrevoznina * dtKola.Rows.Count Then
    ''                Prevoznina = bMinPrevoznina * dtKola.Rows.Count
    ''            End If



    ''            For Each KolaRed In dtKola.Rows    ' petlja po kolima                    
    ''                IBK = KolaRed.Item("IndBrojKola")
    ''                bVozarinskiStavPoKolima = VozarinskiStav
    ''                PrevozninaPoKolima = 0
    ''                KolaRed.Item("VozarinskiStav") = VozarinskiStav
    ''                KolaRed.Item("RacunskaMasa") = ZaokruzenaProsecnaMasa
    ''                KolaRed.Item("Prevoznina") = 0
    ''                For Each NHMRed In dtNhm.Rows   '  petlja po robi - za upis rac. masa i voz.stavova NHM
    ''                    If NHMRed.Item("IndBrojKola") = IBK Then
    ''                        NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
    ''                        NHMRed.Item("RacMasaNHM") = ZaokruzenaProsecnaMasa
    ''                    End If
    ''                Next
    ''            Next

    ''        ElseIf (((mStanica1 = "13670") And (mStanica2 = "13603")) Or ((mStanica2 = "13670") And (mStanica1 = "13603"))) Then
    ''            ' jeste Radinac-Smederevo + v.v.

    ''            Prevoznina = 0
    ''            bVozarinskiStavPoKolima = VozarinskiStav
    ''            For Each KolaRed In dtKola.Rows    ' petlja po kolima                    
    ''                IBK = KolaRed.Item("IndBrojKola")
    ''                bVozarinskiStavPoKolima = VozarinskiStav
    ''                For Each NHMRed In dtNhm.Rows   '  petlja po robi - za upis rac. masa i voz.stavova NHM
    ''                    If NHMRed.Item("IndBrojKola") = IBK Then
    ''                        NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
    ''                        NHMRed.Item("RacMasaNHM") = ZaokruzenaProsecnaMasa
    ''                    End If
    ''                Next
    ''            Next

    ''        End If
    ''    End If ' "200379"


    ''End Sub
    'Public Sub bNadjiPrevozninuNeNulaT(ByVal TarifaK As String, ByVal Tabela As String, ByRef Prevoznina As Decimal)
    '    Dim KolaRed, NHMRed As DataRow
    '    Dim IBK As String
    '    Dim MasaTemp As Integer

    '    Dim Razred As String


    '    Dim UkupnoKola As Byte
    '    Dim UkupnaMasa As Integer = 0
    '    Dim ProsecnaMasa As Integer
    '    Dim TipKola As String
    '    Dim BrOsovina As Byte
    '    Dim UkupnoOsovina As Integer = 0
    '    Dim KolKoef As Decimal
    '    'Dim TovarenaPrazna As String
    '    Dim TonskiStav As String
    '    Dim VozarinskiStav As Decimal
    '    Dim PV As String
    '    Dim TonskiStavInteger As Integer
    '    Dim PrevozninaPoKolima As Decimal

    '    ' Postupak:
    '    ' - naci zbir svih stvarnih masa ( za sva kola )
    '    ' - naci ukupan broj osovina ( za sva kola )
    '    ' - korigovati masu na osovine - ulaz: ukupna stvarna masa i ukupan broj osovina ( sva kola su ili tovarena ili prazna );
    '    '   ako je tarifa '44' ili '45' minimalna masa je 10000*UkupnoKola
    '    '   ako je tarifa '46' minimalna masa je 500000 )
    '    ' - tako dobijenu masu podeliti sa ukupnim brojem kola 
    '    ' - tako dobijenu ( prosecnu ) masu zaokruziti na 100k navise
    '    ' - naci tonski stav ( tj. kolonu u tablici ) uz korigovanje mase ( ako je potrebno ) u smislu granicnih masa   > NadjiMasuIStav
    '    ' - naci vozarinski stav ( stav iz tablice ); razred je isti za sva kola, jer je na njima po jedna ista roba
    '    ' - korigovati vozarinski stav ( *bStavKoef, "popust na vozarinski stav" ) i (?)zaokruziti na 10 navise
    '    ' - naci tip svakih kola ( kao i koeficijent )
    '    ' - naci prevozninu po svakim kolima kao proizvod mase i vozarinskog stava
    '    ' - zaokruzivanje po kolima?
    '    '   ako je tarifa '42' ili '43' prevozninu pomnoziti sa 0.5
    '    ' - testirati svaka kola na minimalnu prevozninu ( ili celu posiljku uz MinPrevPosiljke = UkupnoKola*MinPrevPoKolima ? )
    '    '   ako je tarifa '40' minimalna prevoznina se racuna kao tarifni stav prvog razreda 25-to tonskog stava za tkm, pomnozen sa 500000 i 
    '    '   sa koeficijentom bStavKoef, pa zaokruzen na 10 navise
    '    ' - pomnoziti prevozninu koeficijentom bPrevozninaKoef - "popust na prevozninu"

    '    ' - INTERNO SIFRIRANJE ZA PROMENLJIVU TarifaK:  ( prema unutr. saobracaju )
    '    '
    '    '   39 - Mesoviti vojni transport cl. 45 - 4
    '    '   40 - Mesoviti vojni transport cl. 45 - 6
    '    '   42 - Pokrivaci i nosaci pokrivaca vlasnistvo korisnika prevoza cl. 51 - 11
    '    '   43 - Ostali tovarni pribor u vlasnistvu korisnika prevoza cl. 52 - 9
    '    '   44 - Specijalna kola za prevoz plina (gasa) u gasovitom stanju i kola sa
    '    '           masinama za hladjenje bez prostora za tovarenje cl. 55 - 2 drugi stav
    '    '   45 - Prazna kola korisnika prevoza sa masinama za hladjenje bez prostora za
    '    '           tovarenje, kola za stanovanje, kola kuhinje, kola radionice i ostala
    '    '           kola korisnika prevoza koja nisu uvrstena u kolski park Zeleznice cl. 56 - 6. i cl. 39 - 8
    '    '   46 - Posiljaocev marsutni voz - cl. 57 - 1
    '    '   47 - Posiljaocev marsutni voz - cl. 57 - 5
    '    '   48 - Poseban voz - cl. 58 - 5
    '    '   49 - Grupa kola - clan 59 - 4
    '    '   50 - Vracanje pretega u otpravnu stanicu cl.63 - 1 pod b


    '    ' racunanje prosecne mase 

    '    UkupnoKola = dtKola.Rows.Count
    '    For Each KolaRed In dtKola.Rows    ' petlja po kolima
    '        IBK = KolaRed.Item("IndBrojKola")
    '        For Each NHMRed In dtNhm.Rows                                '  da li treba dozvoliti da bude vise masa na jednim kolima 
    '            If NHMRed.Item("IndBrojKola") = IBK Then              '  ili treba obezbediti da bude na svim kolima po jedna roba i to ista na svim kolima ?
    '                MasaTemp = NHMRed.Item("Masa")
    '                UkupnaMasa = UkupnaMasa + MasaTemp
    '            End If
    '        Next
    '        BrOsovina = KolaRed.Item("Osovine")
    '        UkupnoOsovina = UkupnoOsovina + BrOsovina
    '    Next

    '    If TarifaK = "44" Or TarifaK = "45" Then
    '        If UkupnaMasa < 10000 * UkupnoKola Then
    '            UkupnaMasa = 10000 * UkupnoKola
    '        End If
    '    End If

    '    If TarifaK = "46" Then
    '        If UkupnaMasa < 500000 Then
    '            UkupnaMasa = 500000
    '        End If
    '    End If

    '    bZaokrMasuNaOsovineP(UkupnaMasa, bSvaTovarena, UkupnoOsovina, UkupnaMasa)


    '    ProsecnaMasa = UkupnaMasa / UkupnoKola                         ' prosecna masa po kolima
    '    bZaokruziMasuNa100k(ProsecnaMasa)                                   ' prosecna masa po kolima zaokruzena na 100k navise

    '    bRacunskaMasaPoKolima = ProsecnaMasa


    '    Prevoznina = 0

    '    For Each KolaRed In dtKola.Rows                                         ' petlja po kolima
    '        IBK = KolaRed.Item("IndBrojKola")
    '        '       Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
    '        TipKola = Left(KolaRed.Item("Tip"), 1)
    '        For Each NHMRed In dtNhm.Rows                                '  da li treba dozvoliti da bude vise masa na jednim kolima 
    '            If NHMRed.Item("IndBrojKola") = IBK Then              '  ili treba obezbediti da bude na svim kolima po jedna roba i to ista na svim kolima ?
    '                Razred = NHMRed.Item("R")                               ' u principu, ni ne treba petlja, vec da se ucita bilo koji razred
    '            End If
    '        Next

    '        Razred = NHMRed.Item("R")
    '        '       Vlasnistvo = KolaRed.Item("Vlasnik")
    '        '       BrOsovina = KolaRed.Item("Osovine")
    '        '       TovarenaPrazna = KolaRed.Item("Tovarena")

    '        'Select Case TipKola
    '        '    Case "1"
    '        '        KolKoef = 1.0
    '        '    Case "2"
    '        '        KolKoef = 1.3
    '        '    Case "3"
    '        '        KolKoef = 0.8
    '        '    Case "4"
    '        '        KolKoef = 0.8
    '        '    Case "5"
    '        '        KolKoef = 0.8
    '        '    Case "6"
    '        '        KolKoef = 0.8
    '        '    Case "7"
    '        '        KolKoef = 0.3
    '        'End Select
    '        pubSerijaKola = KolaRed.Item("Serija") '## T kola
    '        pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola
    '        bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

    '        MasaTemp = ProsecnaMasa
    '        bNadjiMasuIStavDo25(MasaTemp, MasaTemp, TonskiStav)

    '        TonskiStavInteger = CType(TonskiStav, Integer)
    '        MasaTemp = TonskiStavInteger * 1000

    '        bNadjiVozarinskiStav(Tabela, mDatumKalk, MasaTemp, bTkm, Razred, VozarinskiStav, PV)
    '        VozarinskiStav = bStavKoef * VozarinskiStav
    '        bZaokruziNaDeseteNavise(VozarinskiStav)
    '        bVozarinskiStavPoKolima = VozarinskiStav

    '        PrevozninaPoKolima = ProsecnaMasa * VozarinskiStav * KolKoef / 10 / 1000   ' u santimima
    '        ' kada zaokruzivanje?

    '        If TarifaK = "42" Or TarifaK = "43" Then
    '            PrevozninaPoKolima = 0.5 * PrevozninaPoKolima    ' tovarni pribor
    '        End If

    '        PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef

    '        PrevozninaPoKolima = PrevozninaPoKolima / 100                                ' u CHF

    '        ' proba na minimalnu prevozninu

    '        If PrevozninaPoKolima <= bMinPrevoznina Then
    '            PrevozninaPoKolima = bMinPrevoznina
    '        End If

    '        KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
    '        KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
    '        KolaRed.Item("Prevoznina") = PrevozninaPoKolima
    '        Prevoznina = Prevoznina + PrevozninaPoKolima
    '        bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

    '        '### 
    '        For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM i masa
    '            If NHMRed.Item("IndBrojKola") = IBK Then
    '                '### 
    '                NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav      '???????
    '                NHMRed.Item("RacMasaNHM") = ProsecnaMasa     '??????
    '                '### 
    '            End If
    '        Next
    '        '### 

    '    Next

    'End Sub
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
        Dim PraznaKola As String = "D"




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
        'For Each KolaRed In dtKola.Rows
        '    BrOsovina = KolaRed.Item("Osovine")
        '    If KolaRed.Item("Stitna") = "D" Then
        '        UkupnoOsovinaStitnih = UkupnoOsovinaStitnih + BrOsovina


        '    End If
        'Next

        '------------------------------ kalkulacija ------------------------------------
        Dim RBKola As Int16 = 1
        For Each KolaRed In dtKola.Rows                ' glavna petlja po kolima za racunanje prevoznine; tu se racunaju i tovarena stitna kola

            IBK = KolaRed.Item("IndBrojKola")
            TipKola = Left(KolaRed.Item("Tip"), 1)
            UkupnaMasa = 0

            ' sabiranje masa po kolima
            RInt = 2                                                            ' ima samo 1. i 2. razred; racuna se po skupljem ( nizem ) razredu
            For Each NHMRed In dtNhm.Rows
                If NHMRed.Item("IndBrojKola") = IBK Then
                    MasaTemp = NHMRed.Item("Masa")
                    UkupnaMasa = UkupnaMasa + MasaTemp
                    If CType(NHMRed.Item("R"), Byte) <= RInt Then
                        RInt = CType(NHMRed.Item("R"), Byte)
                    End If
                    'If Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8606" And Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "9921" Or Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "9922" Then
                    If Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "9921" Or Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "9922" Then
                        PraznaKola = "D"
                    Else
                        PraznaKola = "N"
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

            '$$$
            If VrstaKola = "O" Then
                VrstaKola = 1
            End If
            If VrstaKola = "S" Then
                VrstaKola = 2
            End If
            '$$$

            '"8605": Mandic 20/8/2013
            If Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8604" Or _
               Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8605" Or _
               Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4) = "8606" Then
                DaLiJe8606 = "DA"
            Else
                DaLiJe8606 = "NE"
            End If


            If TipKola = 7 Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            bProveri8606(_mNHM, bNHM8606, bNHMKao8606)
            Dim TovPraMP As String
            Dim VlasnMP As String
            bPraznaKaoRobaTar2015(mDatumKalk, _mNHM, TovPraMP, VlasnMP)
            If VlasnMP = "" Then
                VlasnMP = VlasnistvoKola
            End If

            If (bNHM8606 Or bNHMKao8606) Then
                If TovPraMP = "" Then
                    TovPraMP = "PK"
                End If

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "68", bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                       TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                ' Tarifa 2015
                'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "68", bVrstaPosiljke, bVrstaStanice, VlasnistvoKola, _
                '       "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
            Else
                If TovPraMP = "" Then
                    TovPraMP = TovarenaPrazna
                End If
                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "68", bVrstaPosiljke, bVrstaStanice, VlasnMP, _
                       TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                ' Tarifa 2015
                'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "68", bVrstaPosiljke, bVrstaStanice, VlasnistvoKola, _
                '       TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                '       bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
            End If



            If (VrstaKola = "2" And VlasnistvoKola = "Z" And GrTovKola > 80000) Then     ' zeleznicka specijalna preko 80t
                'za stvarnu masu
            Else
                bZaokruziMasuNa100k(UkupnaMasa)
            End If

            RacMasa = UkupnaMasa

            bZaokrMasuNaOsovineINadjiKolKoefTEA(RacMasa, TaraKola, GrTovKola, VlasnistvoKola, VrstaKola, _
                                                SerijaKola, IFrigo, TovarenaPrazna, BrOsovina, RacMasa, KolKoef)

            If (bNHM8606 Or bNHMKao8606) Then           ' ttv 2/2013
                If UkupnaMasa < 10000 Then
                    RacMasa = 10000
                Else
                    RacMasa = UkupnaMasa
                End If
            End If

            bNadjiRIDKoef(bVrstaSaobracaja, mRazredRid, RidKoef)

            If PraznaKola = "N" Then
                If mDatumKalk <= #1/31/2008# Then
                    Select Case RacMasa
                        Case 10000, 15000, 20000, 25000
                            bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav, PV)
                            VozarinskiStav = bStavKoef * VozarinskiStav
                            bZaokruziNaDeseteNavise(VozarinskiStav)
                            PrevozninaPoKolima = RacMasa * VozarinskiStav * KolKoef * RidKoef / 1000
                            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef
                            bRacunskaMasaPoKolima = RacMasa
                            bVozarinskiStavPoKolima = VozarinskiStav

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
                            '*******
                            If (RacMasa > 25000) Then
                                bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav1, PV)
                                Masa2 = RacMasa
                            End If
                            '*******

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
                            bRacunskaMasaPoKolima = Masa1
                            bVozarinskiStavPoKolima = VozarinskiStav1

                            If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                PrevozninaPoKolima = PrevozninaPoKolima2
                                bRacunskaMasaPoKolima = Masa2
                                bVozarinskiStavPoKolima = VozarinskiStav2
                            End If

                    End Select
                Else
                    Select Case RacMasa
                        Case 10000, 15000, 20000, 25000, 30000, 35000, 40000, 45000
                            bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav, PV)
                            VozarinskiStav = bStavKoef * VozarinskiStav
                            bZaokruziNaDeseteNavise(VozarinskiStav)
                            PrevozninaPoKolima = RacMasa * VozarinskiStav * KolKoef * RidKoef / 1000
                            PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef
                            bRacunskaMasaPoKolima = RacMasa
                            bVozarinskiStavPoKolima = VozarinskiStav

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

                            If (RacMasa > 25000 And RacMasa < 30000) Then
                                bNadjiVozarinskiStav(Tabela, mDatumKalk, 25000, bTkm, Razred, VozarinskiStav1, PV)
                                Masa2 = 30000
                            End If

                            If (RacMasa > 30000 And RacMasa < 35000) Then
                                bNadjiVozarinskiStav(Tabela, mDatumKalk, 30000, bTkm, Razred, VozarinskiStav1, PV)
                                Masa2 = 35000
                            End If

                            If (RacMasa > 35000 And RacMasa < 40000) Then
                                bNadjiVozarinskiStav(Tabela, mDatumKalk, 35000, bTkm, Razred, VozarinskiStav1, PV)
                                Masa2 = 40000
                            End If

                            If (RacMasa > 40000 And RacMasa < 45000) Then
                                bNadjiVozarinskiStav(Tabela, mDatumKalk, 40000, bTkm, Razred, VozarinskiStav1, PV)
                                Masa2 = 45000
                            End If

                            If (RacMasa > 45000) Then
                                bNadjiVozarinskiStav(Tabela, mDatumKalk, 45000, bTkm, Razred, VozarinskiStav1, PV)
                                Masa2 = RacMasa
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
                            bRacunskaMasaPoKolima = Masa1
                            bVozarinskiStavPoKolima = VozarinskiStav1

                            If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                                PrevozninaPoKolima = PrevozninaPoKolima2
                                bRacunskaMasaPoKolima = Masa2
                                bVozarinskiStavPoKolima = VozarinskiStav2
                            End If
                    End Select

                End If

                '''Select Case RacMasa
                '''    Case 10000, 15000, 20000, 25000
                '''        bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav, PV)
                '''        VozarinskiStav = bStavKoef * VozarinskiStav
                '''        bZaokruziNaDeseteNavise(VozarinskiStav)
                '''        PrevozninaPoKolima = RacMasa * VozarinskiStav * KolKoef * RidKoef / 1000
                '''        PrevozninaPoKolima = PrevozninaPoKolima * bPrevozninaKoef
                '''        bRacunskaMasaPoKolima = RacMasa
                '''        bVozarinskiStavPoKolima = VozarinskiStav

                '''    Case Else

                '''        If (RacMasa > 10000 And RacMasa < 15000) Then
                '''            bNadjiVozarinskiStav(Tabela, mDatumKalk, 10000, bTkm, Razred, VozarinskiStav1, PV)
                '''            Masa2 = 15000
                '''        End If

                '''        If (RacMasa > 15000 And RacMasa < 20000) Then
                '''            bNadjiVozarinskiStav(Tabela, mDatumKalk, 15000, bTkm, Razred, VozarinskiStav1, PV)
                '''            Masa2 = 20000
                '''        End If

                '''        If (RacMasa > 20000 And RacMasa < 25000) Then
                '''            bNadjiVozarinskiStav(Tabela, mDatumKalk, 20000, bTkm, Razred, VozarinskiStav1, PV)
                '''            Masa2 = 25000
                '''        End If
                '''        '*******
                '''        If (RacMasa > 25000) Then
                '''            bNadjiVozarinskiStav(Tabela, mDatumKalk, RacMasa, bTkm, Razred, VozarinskiStav1, PV)
                '''            Masa2 = RacMasa
                '''        End If
                '''        '*******

                '''        Masa1 = RacMasa

                '''        VozarinskiStav1 = bStavKoef * VozarinskiStav1
                '''        bZaokruziNaDeseteNavise(VozarinskiStav1)
                '''        PrevozninaPoKolima1 = Masa1 * VozarinskiStav1 * KolKoef * RidKoef / 1000
                '''        PrevozninaPoKolima1 = PrevozninaPoKolima1 * bPrevozninaKoef

                '''        bNadjiVozarinskiStav(Tabela, mDatumKalk, Masa2, bTkm, Razred, VozarinskiStav2, PV)
                '''        VozarinskiStav2 = bStavKoef * VozarinskiStav2
                '''        bZaokruziNaDeseteNavise(VozarinskiStav2)
                '''        PrevozninaPoKolima2 = Masa2 * VozarinskiStav2 * KolKoef * RidKoef / 1000
                '''        PrevozninaPoKolima2 = PrevozninaPoKolima2 * bPrevozninaKoef

                '''        PrevozninaPoKolima = PrevozninaPoKolima1
                '''        bRacunskaMasaPoKolima = Masa1
                '''        bVozarinskiStavPoKolima = VozarinskiStav1

                '''        If PrevozninaPoKolima2 < PrevozninaPoKolima1 Then
                '''            PrevozninaPoKolima = PrevozninaPoKolima2
                '''            bRacunskaMasaPoKolima = Masa2
                '''            bVozarinskiStavPoKolima = VozarinskiStav2
                '''        End If
                '''End Select
            Else
                'PrevozninaPoKolima = 0.1 * BrOsovina * bTkm
                'bRacunskaMasaPoKolima = RacMasa
                'bVozarinskiStavPoKolima = PrevozninaPoKolima

                bNadjiVozarinskiStav(Tabela, mDatumKalk, 45000, bTkm, "1", VozarinskiStav, PV)
                PrevozninaPoKolima = RacMasa * VozarinskiStav * 0.3 / 1000
                If PrevozninaPoKolima <= bMinPrevoznina Then
                    PrevozninaPoKolima = bMinPrevoznina
                End If
                bRacunskaMasaPoKolima = RacMasa
                bVozarinskiStavPoKolima = VozarinskiStav

            End If

            If bStitna = "D" Then
                If PraznaKola = "D" Then
                    'PrevozninaPoKolima = 0
                    PrevozninaPoKolima = 0.12 * BrOsovina * bTkm
                Else
                    'PrevozninapoKolima ostaje
                End If
            End If

            bZaokruziNaDeseteNavise(PrevozninaPoKolima)
            '-------------------------------------------------
            'bZaokruziNaCeleNavise(PrevozninaPoKolima)
            'zaokruzivanje na kraju kada se saberu i naknade
            '-------------------------------------------------

            ' dodati deo kalkulacije za sinska vozila

            If nmNarPos And RBKola <= bNPUkupno Then
                PrevozninaPoKolima = PrevozninaPoKolima * bNPKoef
            End If

            'minimalna prevoznina
            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            '### 
            For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM i masa
                If NHMRed.Item("IndBrojKola") = IBK Then
                    '### 
                    'Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                    'bZaokruziMasuNa100k(MasaTemp1)
                    'NHMRed.Item("RacMasaNHM") = MasaTemp1
                    NHMRed.Item("RacMasaNHM") = bRacunskaMasaPoKolima
                    NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    '### 
                End If
            Next
            '### 

            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            Prevoznina = Prevoznina + PrevozninaPoKolima
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima
            RBKola = RBKola + 1

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
        Dim UkupnaMasa, MasaKont As Integer

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
            TipKola = Left(KolaRed.Item("Tip"), 1)
            VlasnistvoKola = KolaRed.Item("Vlasnik")                            ' "Z", "P", "I"


            UkupnaDuzina = 0
            UkupnaMasa = 0

            For Each NHMRed In dtNhm.Rows
                If IBK = NHMRed.Item("IndBrojKola") Then
                    DuzinaKontStr = NHMRed.Item("UTI")
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    UkupnaDuzina = UkupnaDuzina + DuzinaKont
                    MasaKont = NHMRed.Item("Masa")
                    UkupnaMasa = UkupnaMasa + MasaKont
                    '###
                    NHMRed.Item("RacMasaNHM") = MasaKont
                    '###


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

            'bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

            '14.06.
            'TipKola = "7"
            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If
            Dim TovPraMP As String
            Dim VlasnMP As String
            bPraznaKaoRobaTar2015(mDatumKalk, _mNHM, TovPraMP, VlasnMP) ' da li je _mNHM tacno izracunato ?
            If TovPraMP = "" Then
                TovPraMP = TovarenaPrazna
            End If
            If VlasnMP = "" Then
                VlasnMP = VlasnistvoKola
            End If
            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnistvoKola, _
                   TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            ' Tarifa 2015
            'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, VlasnistvoKola, _
            '                   TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            '                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


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
            '### 
            For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM i masa
                If NHMRed.Item("IndBrojKola") = IBK Then
                    '### 
                    Dim MasaTemp1 As Integer = NHMRed.Item("Masa")
                    bZaokruziMasuNa100k(MasaTemp1)
                    NHMRed.Item("RacMasaNHM") = MasaTemp1
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                    '### 
                End If
            Next
            '### 

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
        Dim RMNHM As Integer
        Dim UkupnoKola As Byte
        Dim PrevozninaPoKolima As Decimal
        Dim PrevozninaPoKont As Decimal
        Dim VozarinskiStav As Decimal
        Dim Raster As Decimal
        Dim KolKoef As Decimal
        Dim PV As String

        Dim NHM As String
        '------------------------------------
        Dim AgitAneks As Boolean = False
        Dim KampakisAneks As Boolean = False
        Dim MMAneks As Boolean = False
        '------------------------------------
        Dim BrOsovina As Byte
        Dim Stitna As String

        Dim ugretval As String
        Dim ugcena As Decimal
        Dim ugtipcene As Int32


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
        For Each KolaRed In dtKola.Rows                   ' petlja po kolima
            PrevozninaPoKolima = 0
            bRacunskaMasaPoKolima = 0

            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")
            TipKola = Left(KolaRed.Item("Tip"), 1)

            Stitna = KolaRed.Item("Stitna")
            BrOsovina = KolaRed.Item("Osovine")

            If TipKola = "7" Then
                TovarenaPrazna = "PK"
            Else
                TovarenaPrazna = "TK"
            End If

            Dim TovPraMP As String
            Dim VlasnMP As String
            bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)   ' da li je NHM tacno izracunato ?
            If TovPraMP = "" Then
                TovPraMP = TovarenaPrazna
            End If
            If VlasnMP = "" Then
                VlasnMP = Vlasnistvo
            End If
            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                   TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                   bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            ' Tarifa 2015
            'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
            '                  TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            '                  bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


            KolKoef = 1

            pubSerijaKola = KolaRed.Item("Serija") '## T kola
            pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola
            bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

            '------------------------ prolazi po robi --------------------------
            For Each NHMRed In dtNhm.Rows
                If IBK = NHMRed.Item("IndBrojKola") Then
                    DuzinaKontStr = NHMRed.Item("UTI")
                    DuzinaKont = CType(DuzinaKontStr, Integer)
                    StvMasa = NHMRed.Item("Masa")
                    bNadjiRasterTEA(DuzinaKont, StvMasa, Raster)

                    NHM = NHMRed.Item("NHM")

                    PrevozninaPoKont = 0

                    bNadjiVozarinskiStavKontTEA(Tabela, mDatumKalk, bTkm, VozarinskiStav, PV)

                    VozarinskiStav = bStavKoef * VozarinskiStav
                    bZaokruziNaDeseteNavise(VozarinskiStav)
                    PrevozninaPoKont = VozarinskiStav * Raster * KolKoef * bPrevozninaKoef




                    ' ========================== NadjiAneks ============================
                    If mBrojUg = "031022" Or mBrojUg = "031122" Or mBrojUg = "031222" Or mBrojUg = "031322" Or mBrojUg = "031422" Or mBrojUg = "031522" Or mBrojUg = "031622" Then
                        ugretval = ""
                        ugcena = 0
                        ugtipcene = 0

                        NadjiAneks(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, _
                                   mDatumKalk, Microsoft.VisualBasic.Left(NHM, 4), DuzinaKontStr, ugcena, ugtipcene, ugretval)

                        If ugtipcene = 9 Then ' cena po utiju 
                            KolKoef = 1
                            bPrevozninaKoef = 1
                            'bMinPrevoznina = 0
                            PrevozninaPoKont = ugcena * Raster
                            VozarinskiStav = ugcena
                            AgitAneks = True
                        End If

                    End If


                    'If Microsoft.VisualBasic.Right(mBrojUg, 2) = "42" Then
                    '    NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                    '                                     BrOsovina, "P", Vlasnistvo, "1", _
                    '                                     mDatumKalk, StvMasa, Microsoft.VisualBasic.Left(NHM, 4), _
                    '                                     DuzinaKont, ugcena, ugtipcene, sqlVlasnistvoKola, ugretval)
                    '    If ugtipcene = 9 Then ' cena po utiju 
                    '        KolKoef = 1
                    '        bPrevozninaKoef = 1
                    '        'bMinPrevoznina = 0
                    '        Raster = 1
                    '        PrevozninaPoKont = ugcena
                    '        VozarinskiStav = ugcena
                    '        AgitAneks = True
                    '    End If

                    'End If


                    If Microsoft.VisualBasic.Right(mBrojUg, 2) = "22" Or _
                        Microsoft.VisualBasic.Right(mBrojUg, 2) = "42" Then         'cena po utiju, tabela kao raster    
                        NadjiAneksNovo(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, BrOsovina, mVrstaPrevoza, Vlasnistvo, "1", _
                                       mDatumKalk, StvMasa, Microsoft.VisualBasic.Left(NHM, 4), DuzinaKont, ugcena, ugtipcene, sqlVlasnistvoKola, ugretval)

                        If ugtipcene = 20 Then                                      'cena po utiju, tabela kao raster
                            KolKoef = 1
                            bPrevozninaKoef = 1
                            'bMinPrevoznina = 0
                            Raster = 1
                            PrevozninaPoKont = ugcena
                            VozarinskiStav = ugcena
                            If mBrojUg = "031442" Or mBrojUg = "031542" Or mBrojUg = "031542" Then
                                AgitAneks = True
                            End If
                        ElseIf ugtipcene = 21 Then                                      'cena po utiju, tabela kao raster, minprev = 0
                            KolKoef = 1
                            bPrevozninaKoef = 1
                            bMinPrevoznina = 0
                            Raster = 1
                            PrevozninaPoKont = ugcena
                            VozarinskiStav = ugcena
                            If mBrojUg = "031442" Or mBrojUg = "031542" Or mBrojUg = "031542" Then
                                AgitAneks = True
                            End If
                        ElseIf ugtipcene = 9 Then
                            KolKoef = 1
                            bPrevozninaKoef = 1
                            'bMinPrevoznina = 0
                            Raster = 1
                            PrevozninaPoKont = ugcena
                            VozarinskiStav = ugcena
                            AgitAneks = True
                        ElseIf (ugtipcene = 16 Or ugtipcene = 17) Then
                            KolKoef = 1
                            bPrevozninaKoef = 1
                            bNadjiRasterTEA(DuzinaKont, StvMasa, Raster)
                            PrevozninaPoKont = ugcena * Raster
                            VozarinskiStav = ugcena
                            If ugtipcene = 16 Then
                                AgitAneks = False
                            ElseIf ugtipcene = 17 Then
                                AgitAneks = True
                            End If
                        ElseIf (ugtipcene = 18 Or ugtipcene = 19) Then
                            KolKoef = 1
                            bPrevozninaKoef = 1
                            bNadjiRasterAGIT(DuzinaKont, StvMasa, Raster)
                            PrevozninaPoKont = ugcena * Raster
                            VozarinskiStav = ugcena
                            If ugtipcene = 18 Then
                                AgitAneks = False
                            ElseIf ugtipcene = 19 Then
                                AgitAneks = True
                            End If
                        End If
                    End If

                    If mDatumKalk < #1/15/2015# Then
                        bZaokruziNaDeseteNavise(PrevozninaPoKont)
                    Else
                        bZaokruziNaCeleNavise(PrevozninaPoKont)      'nova tarifa od 15.01.2015
                    End If

                    RMNHM = StvMasa
                    bZaokruziMasuNa100k(RMNHM)
                    NHMRed.Item("RacMasaNHM") = RMNHM
                    NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                    NHMRed.Item("UTIRaster") = Raster
                    PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaPoKont
                End If

                If (mBrojUg = "031022") Or (mBrojUg = "031122") Or (mBrojUg = "031222") Or (mBrojUg = "031322") Or (mBrojUg = "031422") Or (mBrojUg = "031522") Or (mBrojUg = "031522") Then
                    If Vlasnistvo = "Z" Then
                        If AgitAneks Then
                            KolaRed.Item("Naknada") = 0
                        Else
                            KolaRed.Item("Naknada") = 0 '36
                        End If
                    End If
                End If
                bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + StvMasa
            Next


            '================================= K+N 2013 ====================================
            'Osnovni ugovor CO 101344
            '?2014
            If mBrojUg = "101322" Then
                ugcena = 0
                ugtipcene = 0
                ugretval = ""
                PrevozninaPoKolima = 0

                Dim ugDodatak As Decimal
                Dim ugKoeficijent As Decimal
                Dim UTIKomb As String = ""

                If (dtNhm.Rows(0).Item("UTI") = "10") Then
                    UTIKomb = "10"
                ElseIf (dtNhm.Rows(0).Item("UTI") = "20") Then
                    UTIKomb = "20"
                ElseIf (dtNhm.Rows(0).Item("UTI") = "50") Then
                    UTIKomb = "50"
                End If

                If Not (UTIKomb = "") Then
                    NadjiAneks(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, mDatumKalk, _
                               Microsoft.VisualBasic.Left(NHM, 4), UTIKomb, ugcena, ugtipcene, ugretval)

                    If (ugretval = "") Then

                        PrevozninaPoKont = ugcena           'PrevozninaPoKolima = ugcena
                        bVozarinskiStavPoKolima = ugcena

                        MMAneks = True
                        bRacunskaMasaPoKolima = 0
                        For Each NHMRed In dtNhm.Rows
                            If IBK = NHMRed.Item("IndBrojKola") Then
                                RMNHM = NHMRed.Item("Masa")
                                bZaokruziMasuNa100k(RMNHM)
                                NHMRed.Item("RacMasaNHM") = RMNHM
                                NHMRed.Item("VozarinskiStavNHM") = ugcena
                                bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + RMNHM
                                '---
                                PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaPoKont
                            End If
                        Next

                    End If
                End If
            End If
            '=============================== end K+N 2013 ==================================

            '============================ Militzer & Munch ==================================
            '    aneks T389f  (za '08) T510(za '09) T171(2011) (MMAneks)

            If ((mBrojUg = "301022") Or (mBrojUg = "301023") Or (mBrojUg = "301024") Or _
                (mBrojUg = "301122") Or (mBrojUg = "301123") Or (mBrojUg = "301124") Or _
                (mBrojUg = "301222") Or (mBrojUg = "301223") Or (mBrojUg = "301224") Or _
                (mBrojUg = "301322") Or (mBrojUg = "301323") Or (mBrojUg = "301324") Or _
                (mBrojUg = "301422") Or (mBrojUg = "301423") Or (mBrojUg = "301424") Or _
                (mBrojUg = "301522") Or (mBrojUg = "301523") Or (mBrojUg = "301524") Or _
                (mBrojUg = "301622") Or (mBrojUg = "301623") Or (mBrojUg = "301624")) Then

                'Dim ugCena As Decimal
                'Dim ugTipCene As Integer
                'Dim ugRetVal As String = ""
                ugcena = 0
                ugtipcene = 0
                ugretval = ""
                Dim ugDodatak As Decimal
                Dim ugKoeficijent As Decimal
                Dim UTIKomb As String = ""

                If (mBrojUg = "301122") Or (mBrojUg = "301222") Or (mBrojUg = "301322") Or (mBrojUg = "301422") Or (mBrojUg = "301522") Or (mBrojUg = "301622") Then

                    If dtNhm.Rows.Count = 2 Then
                        If (dtNhm.Rows(0).Item("UTI") = "10") And (dtNhm.Rows(1).Item("UTI") = "10") Then ' 10 = LC/CL odgovara 20" !!! 18.5.2009 
                            UTIKomb = "71"
                        End If

                    ElseIf dtNhm.Rows.Count = 1 Then
                        If (dtNhm.Rows(0).Item("UTI") = "50") Then ' 50 = LC/CL odgovara 40" !!! 18.5.2009 
                            UTIKomb = "72"
                        End If
                    End If

                End If

                If (mBrojUg = "301623") Or (mBrojUg = "301624") Or _
                   (mBrojUg = "301523") Or (mBrojUg = "301524") Or _
                   (mBrojUg = "301123") Or (mBrojUg = "301124") Or _
                   (mBrojUg = "301223") Or (mBrojUg = "301224") Or _
                   (mBrojUg = "301323") Or (mBrojUg = "301324") Or _
                   (mBrojUg = "301423") Or (mBrojUg = "301424") Then
                    Dim Kont20PoKolima As Byte = 0
                    Dim Kont40PoKolima As Byte = 0
                    For Each NHMRed In dtNhm.Rows
                        If IBK = NHMRed.Item("IndBrojKola") Then
                            If NHMRed.Item("UTI") = "10" Then ' 10 LC/CL odgovara 20" !!! 18.5.2009 
                                Kont20PoKolima = Kont20PoKolima + 1
                            End If
                            If NHMRed.Item("UTI") = "50" Then ' 50 LC/CL odgovara 40" !!! 18.5.2009 
                                Kont40PoKolima = Kont40PoKolima + 1
                            End If
                        End If
                    Next
                    If Kont20PoKolima = 2 And Kont40PoKolima = 0 Then
                        UTIKomb = "71"
                    End If
                    If Kont20PoKolima = 0 And Kont40PoKolima = 1 Then
                        UTIKomb = "72"
                    End If

                End If

                If Not (UTIKomb = "") Then
                    NadjiAneks(mBrojUg, bVrstaSaobracaja, mStanica1, mStanica2, _
                               BrOsovina, mVrstaPrevoza, Vlasnistvo, Stitna, mDatumKalk, Microsoft.VisualBasic.Left(NHM, 4), UTIKomb, _
                               ugcena, ugtipcene, ugretval)

                    If (ugretval = "") Then

                        PrevozninaPoKolima = ugcena
                        bVozarinskiStavPoKolima = ugcena

                        MMAneks = True
                        bRacunskaMasaPoKolima = 0
                        For Each NHMRed In dtNhm.Rows
                            If IBK = NHMRed.Item("IndBrojKola") Then
                                RMNHM = NHMRed.Item("Masa")
                                bZaokruziMasuNa100k(RMNHM)
                                NHMRed.Item("RacMasaNHM") = RMNHM
                                NHMRed.Item("VozarinskiStavNHM") = ugcena
                                bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + RMNHM
                            End If
                        Next

                    End If
                End If

            End If
            '============================ end Militzer&Munch ===============================

            '================================ Kampakis =====================================
            ' Sve HDC !    za 2009. godinu !
            If ((mBrojUg = "290822") And (mDatumKalk >= #2/1/2008#) And (mDatumKalk <= #3/31/2009#)) Or _
               ((mBrojUg = "290922") And (mDatumKalk >= #4/1/2009#) And (mDatumKalk <= #3/31/2010#)) Then

                Dim UTIKombinacija As Byte = 0
                Dim Cena1 As Decimal = 0
                Dim Cena2 As Decimal = 0

                If (Microsoft.VisualBasic.Left((dtNhm.Rows(0).Item("NHM")), 4) = "9941") Then
                    If (mStanica1 = "11028" And mStanica2 = "12420") Or (mStanica2 = "11028" And mStanica1 = "12420") Then
                        If (dtNhm.Rows(0).Item("UTI") = "10") Then
                            Cena1 = 137
                        Else
                            Cena1 = 169
                        End If
                    End If

                    If (mStanica1 = "11028" And mStanica2 = "16050") Or (mStanica2 = "11028" And mStanica1 = "16050") Then
                        If (dtNhm.Rows(0).Item("UTI") = "10") Then
                            Cena1 = 251
                        Else
                            Cena1 = 302
                        End If
                    End If
                Else
                    If (mStanica1 = "11028" And mStanica2 = "12420") Or (mStanica2 = "11028" And mStanica1 = "12420") Then
                        If (dtNhm.Rows(0).Item("UTI") = "10") Then
                            Cena1 = 65
                        Else
                            Cena1 = 80
                        End If
                    End If
                    If (mStanica1 = "11028" And mStanica2 = "16050") Or (mStanica2 = "11028" And mStanica1 = "16050") Then
                        If (dtNhm.Rows(0).Item("UTI") = "10") Then
                            Cena1 = 110
                        Else
                            Cena1 = 212
                        End If
                    End If

                End If

                If Cena1 <> 0 Then
                    PrevozninaPoKolima = Cena1
                    bVozarinskiStavPoKolima = PrevozninaPoKolima
                    dtNhm.Rows(0).Item("VozarinskiStavNHM") = Cena1
                    dtNhm.Rows(0).Item("UTIRaster") = 1
                End If


                If PrevozninaPoKolima > 0 Then
                    KampakisAneks = True
                Else
                    KampakisAneks = False
                End If

            Else

            End If
            '=============================== end Kampakis ===================================


            '----------- test na minimalnu prevozninu -------------
            If ((mTarifa = "00") And (Microsoft.VisualBasic.Left(NHM, 4) = "9931")) And Not (KampakisAneks) Then

                'Dim TovPraMP As String
                'Dim VlasnMP As String
                bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                If TovPraMP = "" Then
                    TovPraMP = "PK"
                End If
                If VlasnMP = "" Then
                    VlasnMP = Vlasnistvo
                End If
                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                                     TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                ' Tarifa 2015
                'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, "36", bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                '                     "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                '                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            End If


            If Not (AgitAneks) And Not (MMAneks) And Not (KampakisAneks) Then
                If PrevozninaPoKolima <= bMinPrevoznina Then
                    PrevozninaPoKolima = bMinPrevoznina
                End If
            End If

            If AgitAneks And (ugtipcene <> 16 And ugtipcene <> 17) Then  'Tg.65
                If PrevozninaPoKolima <= bMinPrevoznina Then
                    If ((mStanica1 = "16517" And mStanica2 = "16516") Or _
                        (mStanica1 = "16516" And mStanica2 = "16517") Or _
                        (mStanica1 = "16517" And mStanica2 = "16509") Or _
                        (mStanica1 = "16509" And mStanica2 = "16517") Or _
                        (mStanica1 = "16517" And mStanica2 = "13201") Or _
                        (mStanica1 = "13201" And mStanica2 = "16517")) Then

                        If Microsoft.VisualBasic.Left(NHM, 4) = "9931" Then
                        Else
                            PrevozninaPoKolima = bMinPrevoznina
                        End If

                        'PrevozninaPoKolima = bMinPrevoznina
                    Else
                        '''''''''PrevozninaPoKolima = bMinPrevoznina
                    End If
                    'PrevozninaPoKolima = bMinPrevoznina

                End If

            End If

            If ugtipcene = 16 Then
                If PrevozninaPoKolima <= bMinPrevoznina Then
                    PrevozninaPoKolima = bMinPrevoznina
                End If
            ElseIf ugtipcene = 17 Then
                'ne važi minimalna prevoznina
            End If

            '----------- end test na minimalnu prevozninu -------------

            KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
            KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
            KolaRed.Item("Prevoznina") = PrevozninaPoKolima
            Prevoznina = Prevoznina + PrevozninaPoKolima
            bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

        Next

        If mTarifa = "36" Then
            Dim NaknadeRed As DataRow
            If dtNaknade.Rows.Count = 0 Then
                dtNaknade.NewRow()
                dtNaknade.Rows.Add(New Object() {"90", "00", 36, 17, 1, 0, "0", "R", "I"})
            Else
                For Each NaknadeRed In dtNaknade.Rows
                    Dim dtRow() As DataRow = dtNaknade.Select("Sifra = '90' AND IvicniBroj = '00'")

                    If dtRow.Length > 0 Then
                        'nista ne upisuje
                    Else
                        dtNaknade.NewRow()
                        dtNaknade.Rows.Add(New Object() {"90", "00", 36, 17, 1, 0, "0", "R", "I"})
                    End If
                Next

            End If

        End If

    End Sub

    Public Sub bNadjiPrevozninuGlavni()

        VrstaStanice() 'Da li je granicna stanica

        If mVrstaPrevoza = "V" Then
            Dim rvco As String
            NadjiBrutoMasuVoza(mBrojUg, mNajava, nmBMV, rvco)
            nmBMV = nmBMV / 1000
        End If

        If bVrstaPosiljke = "K" Then

            Dim KolaNhm As DataRow
            For Each KolaNhm In dtNhm.Rows
                _mNHM = KolaNhm.Item("NHM")
            Next

            If IzborSaobracaja = "1" Then          ' ----------------- L O K A L ------------------
            ElseIf IzborSaobracaja = "2" Then      ' ------------------ U V O Z -------------------
                If mTarifa = "36" Then
                    bValuta = "17"
                    If bKontejneri = False Then
                        mTabelaCena = "122"
                        bNadjiPrevozninu00T(mTabelaCena, mPrevoznina)
                    Else
                        mTabelaCena = "133"
                        bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
                    End If
                ElseIf mTarifa = "68" Then
                    bValuta = "17"
                    If Not (bKontejneri) Then
                        mTabelaCena = "680"
                        bNadjiPrevozninuTEA(mTabelaCena, mPrevoznina)
                    Else
                        mTabelaCena = "134"
                        bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
                    End If
                ElseIf mTarifa = "04" Then          ' Sava ekspres
                    bNadjiPrevozninuSava(mPrevoznina)
                ElseIf mTarifa = "46" Then          ' ekspres
                    ' bNadjiPrevozninuEkspres(mPrevoznina)
                ElseIf mTarifa = "45" Then          ' Interkontejner "po tarifi"
                    bNadjiPrevozninuICFT(mPrevoznina)
                ElseIf mTarifa = "97" Then          ' Interkontejner "po tarifi"
                    ' bNadjiPrevozninuIFr(mPrevoznina) ' Interfrigo ( nema )
                ElseIf mTarifa = "00" Then   ' Ugovori
                    Dim pv As Decimal
                    Dim por As String = ""
                    Dim xNaziv As String = ""
                    Dim xPovVrednost As String = ""

                    If mVrstaObracuna = "IC" Then   'proveriti
                        Util.sNadjiNaziv("TabNaziv", mBrojUg, "", "", 1, xNaziv, xPovVrednost)
                        mTabelaCena = xNaziv

                        If mBrojUg = "835745" Or mBrojUg = "835758" Or mBrojUg = "844517" Then 'AdriaCombi
                            mTabelaCena = "333"
                        End If

                        If mTabelaCena = 221 Then
                            mTabelaCena = "914"
                            bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina) 'isto kao i za TEA
                        Else
                            StavIcf(mBrojUg, mTabelaCena, mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "", "0", pv, por)
                            bRacunskaMasa = mMasaRobe
                            bVozarinskiStav = pv

                            ''''If mBrojUg = "835745" Then          ' Adria Kombi
                            ''''    bNadjiPrevozninuICF(mPrevoznina)
                            ''''End If

                            If mBrojUg = "844514" Then                       ' Adria Kombi
                                bNadjiPrevozninu844514(mPrevoznina)
                            ElseIf mBrojUg = "835758" Or mBrojUg = "844517" Then                   ' Adria Kombi
                                bNadjiPrevozninuICF(mPrevoznina)

                            ElseIf mBrojUg = "844516" Then                   ' Adria Kombi
                                bNadjiPrevozninu844516(mPrevoznina)
                            End If
                        End If
                    ElseIf mVrstaObracuna = "CO" Then
                        bNadjiPrevozninuCO()
                    ElseIf mVrstaObracuna = "RO" Then 'Komercijalne povlastice
                        If mBrojUg = "200379" Then 'Sartid
                            Dim kPrevoznina As Decimal
                            bNadjiPrevozninuUSS(mPrevoznina)
                        Else
                            Dim kPrevoznina As Decimal
                            Dim kPov As String
                            bNadjiPrevozninuROKP(kPrevoznina, kPov)
                            mPrevoznina = kPrevoznina
                        End If
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
                        bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina)
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
                ElseIf mTarifa = "04" Then          ' Sava ekspres
                    bNadjiPrevozninuSava(mPrevoznina)
                ElseIf mTarifa = "46" Then          ' ekspres
                    ' bNadjiPrevozninuEkspres(mPrevoznina)
                ElseIf mTarifa = "45" Then          ' Interkontejner po tarifi
                    bNadjiPrevozninuICFT(mPrevoznina)
                ElseIf mTarifa = "97" Then          ' Interfrigo
                    ' bNadjiPrevozninuIFr(mPrevoznina) ' Interfrigo ( nema )
                ElseIf mTarifa = "00" Then   ' Ugovori
                    Dim pv As Decimal
                    Dim por As String = ""
                    Dim xNaziv As String = ""
                    Dim xPovVrednost As String = ""

                    If mVrstaObracuna = "IC" Then   'proveriti
                        Util.sNadjiNaziv("TabNaziv", mBrojUg, "", "", 1, xNaziv, xPovVrednost)
                        mTabelaCena = xNaziv

                        If mBrojUg = "835745" Or mBrojUg = "835758" Or mBrojUg = "844517" Then 'AdriaCombi
                            mTabelaCena = "333"
                        End If

                        If mTabelaCena = 221 Then
                            mTabelaCena = "914"
                            bNadjiPrevozninuKontTEA(mTabelaCena, mPrevoznina) 'isto kao i za TEA
                        Else
                            StavIcf(mBrojUg, mTabelaCena, mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "", "0", pv, por)
                            bRacunskaMasa = mMasaRobe
                            bVozarinskiStav = pv

                            If mBrojUg = "844514" Then                       ' Adria Kombi
                                bNadjiPrevozninu844514(mPrevoznina)
                            ElseIf mBrojUg = "835745" Or mBrojUg = "835758" Or mBrojUg = "844517" Then                   ' Adria Kombi
                                bNadjiPrevozninuICF(mPrevoznina)
                            ElseIf mBrojUg = "844516" Then                   ' Adria Kombi
                                bNadjiPrevozninu844516(mPrevoznina)
                            End If
                        End If
                    ElseIf mVrstaObracuna = "CO" Then
                        bNadjiPrevozninuCO()
                    ElseIf mVrstaObracuna = "RO" Then
                        If mBrojUg = "200379" Then 'Sartid
                            Dim kPrevoznina As Decimal
                            bNadjiPrevozninuUSS(mPrevoznina)
                        Else
                            Dim kPrevoznina As Decimal
                            Dim kPov As String
                            bNadjiPrevozninuROKP(kPrevoznina, kPov)
                            mPrevoznina = kPrevoznina
                        End If
                    End If
                End If
            ElseIf IzborSaobracaja = "4" Then      ' --------------- T R A N Z I T ----------------

                If mTarifa = "00" Then 'Ugovori
                    Dim pv As Decimal
                    Dim por As String = ""
                    Dim xNaziv As String = ""
                    Dim xPovVrednost As String = ""

                    If mVrstaObracuna = "CO" Then
                        bNadjiPrevozninuCO()
                    ElseIf mVrstaObracuna = "IC" Then
                        If mBrojUg = "835753" Or mBrojUg = "955401" Or mBrojUg = "835771" Then ' Adria Kombi
                            bNadjiPrevozninu835753(mPrevoznina)
                        ElseIf mBrojUg = "836902" Then
                            bNadjiPrevozninu836902(mPrevoznina)
                        Else
                            bNadjiPrevozninuICF(mPrevoznina)
                        End If
                    ElseIf mVrstaObracuna = "RO" Then
                    End If
                ElseIf mTarifa = "38" Then
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
                End If
            End If
        Else
            bNadjiPrevozninuDenc(mPrevoznina)
        End If
        bZaokruziNaDeseteNavise(mPrevoznina)

        If mPrevoznina = 0 Then
            MsgBox("U bazi podataka nije pronadena cena za ovu pošiljku! Proverite podatke i ponovite postupak. ", MsgBoxStyle.Exclamation, "Poruka iz baze")
        End If

    End Sub
    Public Sub VrstaStanice()

        bVrstaStanice = "M"

        If ((mStanica1 = "23499" And mStanica2 = "23450") Or _
            (mStanica2 = "23499" And mStanica1 = "23450") Or _
            (mStanica1 = "22850" And mStanica2 = "22899") Or _
            (mStanica2 = "22850" And mStanica1 = "22899") Or _
            (mStanica1 = "21009" And mStanica2 = "21099") Or _
            (mStanica2 = "21009" And mStanica1 = "21099") Or _
            (mStanica1 = "11027" And mStanica2 = "11028") Or _
            (mStanica2 = "11027" And mStanica1 = "11028") Or _
            (mStanica1 = "16314" And mStanica2 = "16319") Or _
            (mStanica2 = "16314" And mStanica1 = "16319") Or _
            (mStanica1 = "16516" And mStanica2 = "16517") Or _
            (mStanica2 = "16516" And mStanica1 = "16517") Or _
            (mStanica1 = "15712" And mStanica2 = "15723") Or _
            (mStanica2 = "15712" And mStanica1 = "15723")) Then
            bVrstaStanice = "G"
        End If


        ''If IzborSaobracaja = "2" Then
        ''    Select Case mStanica2
        ''        Case "23450", "22850", "21009", "12499", "11027", "16314", "16516", "15712"
        ''            bVrstaStanice = "G"
        ''        Case Else
        ''            bVrstaStanice = "M"
        ''    End Select
        ''ElseIf IzborSaobracaja = "3" Then
        ''    Select Case mStanica1
        ''        Case "23450", "22850", "21009", "12499", "11027", "16314", "16516", "15712"
        ''            bVrstaStanice = "G"
        ''        Case Else
        ''            bVrstaStanice = "M"
        ''    End Select
        ''ElseIf IzborSaobracaja = "4" Then
        ''    bVrstaStanice = "M"
        ''End If

        If Lomljena = "D" Then
            bVrstaStanice = "M"
        End If

    End Sub

    Public Sub bNadjiBrutoMasu(ByRef BrutoMasa As Decimal, ByRef KoefPKola As Decimal)

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK As String
        Dim BrutoMasaKola As Decimal = 0
        Dim TaraKola As Decimal
        Dim MasaTemp As Decimal
        Dim VlasnikTemp As String
        Dim PV As String
        Dim SvaPrivatna As Boolean = False

        BrutoMasa = 0

        If Microsoft.VisualBasic.Left(mBrojUg, 4) = "8014" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "8114" Or _
           Microsoft.VisualBasic.Left(mBrojUg, 4) = "8015" Or Microsoft.VisualBasic.Left(mBrojUg, 4) = "8115" Then
            KoefPKola = 1
        Else
            KoefPKola = 0.7
        End If

        bProveri8606(_mNHM, bNHM8606, bNHMKao8606)

        ''If Microsoft.VisualBasic.Left(mBrojUg.ToString, 2) = "06" Then
        ''    KoefPKola = 0.75
        ''Else
        ''    KoefPKola = 0.8
        ''End If

        If dtKola.Rows.Count > 0 Then
            For Each KolaRed In dtKola.Rows    ' petlja po kolima
                IBK = KolaRed.Item("IndBrojKola")
                VlasnikTemp = KolaRed.Item("Vlasnik")

                TaraKola = KolaRed.Item("Tara")
                If (VlasnikTemp = "Z") Then
                    KoefPKola = 1
                End If

                If dtNhm.Rows.Count > 0 Then
                    Dim StvarnaMasaNaKolima As Decimal = 0
                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            StvarnaMasaNaKolima = StvarnaMasaNaKolima + MasaTemp
                        End If
                    Next

                    If bNHM8606 = True Or bNHMKao8606 = True Then
                        BrutoMasaKola = TaraKola
                    Else
                        BrutoMasaKola = StvarnaMasaNaKolima + TaraKola
                    End If

                End If
                BrutoMasa = BrutoMasa + BrutoMasaKola

            Next    ' petlja po kolima
        End If

        '---------------- Realizovana Bruto masa za najavu ----------------------
        Dim _rv As String = ""
        Dim tmp_KolaNajava As Int16 = 0
        Dim tmp_KolaReal As Int16 = 0
        Dim tmp_Bruto As Decimal = 0
        Dim tmp_Neto As Decimal = 0
        Dim tmp_Tara As Decimal = 0
        Dim tmp_Suma As Decimal = 0
        Dim tmp_SumaPrev As Decimal = 0
        Dim tmp_SumaNak As Decimal = 0
        Dim tmp_SumaNakCo As Decimal = 0
        Dim tmp_SumaNakCo82 As Decimal = 0

        Util.NajavaPregledKalk(mBrojUg, mNajava, mObrGodina, tmp_KolaReal, tmp_Neto, tmp_Tara, _
                               tmp_Suma, tmp_SumaPrev, tmp_SumaNak, tmp_SumaNakCo, tmp_SumaNakCo82, _
                               _rv)

        mSumaKola = tmp_KolaReal

        'ukupna bruto masa voza zajedno sa trenutnim tovarnim listom
        '(tmp_Neto + tmp_Tara): trenutna bruto masa voza u bazi
        ''07.03.2012
        ''If mCistUnos = "Ne" And AkcijaZaPreuzimanje = "Ne" And RecordAction = "N" Then
        ''    BrutoMasa = BrutoMasa + tmp_Neto + tmp_Tara
        ''Else
        ''    BrutoMasa = BrutoMasa + tmp_Neto + tmp_Tara
        ''End If

        If bNHM8606 = True Or bNHMKao8606 = True Then
            BrutoMasa = BrutoMasa + tmp_Tara
        Else
            BrutoMasa = BrutoMasa + tmp_Neto + tmp_Tara
        End If

        '---------------- trazenje vlasnistva kola za najavu --------------------------------------

        If Microsoft.VisualBasic.Left(mBrojUg.ToString, 4) = "1013" Or _
           Microsoft.VisualBasic.Left(mBrojUg.ToString, 4) = "1113" Or _
           Microsoft.VisualBasic.Left(mBrojUg.ToString, 4) = "1213" Then

            KoefPKola = 1
        Else
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            Dim sql_text1 As String = "SELECT SlogKalk.Najava, SlogKalk.Ugovor, SlogKola.Vlasnik " & _
                                      "FROM SlogKalk INNER JOIN " & _
                                      "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica " & _
                                      "WHERE (dbo.SlogKalk.ObrGodina = '" & mObrGodina & "') AND (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "')"

            Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
            Dim rdrRm As SqlClient.SqlDataReader
            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrRm.Read()
                If rdrRm.GetString(2) = "Z" Then
                    KoefPKola = 1
                    Exit Do
                End If
            Loop
            rdrRm.Close()
            OkpDbVeza.Close()

        End If
        '----------------------------------------------------------------------------------------------------------------------------

    End Sub
    Public Sub bNadjiPrevozninuSava(ByRef Prevoznina As Decimal)    ' prevoznina je nula
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        'Dim RedniBroj As Int32
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1
        Dim MasaTemp As Integer
        Dim Masa1R, Masa2R, Masa3R As Integer
        Dim Razred As String

        Dim VozarinskiStav As Decimal
        Dim PV As String


        Dim PrevozninaPoKolima As Decimal = 0
        Dim RacMasaPoKolima As Integer
        Dim Ka As Decimal = 1

        If bVrstaSaobracaja = 4 Then
            Ka = 10
        End If

        Prevoznina = 0

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

                If dtNhm.Rows.Count > 0 Then
                    Masa1R = 0
                    Masa2R = 0
                    Masa3R = 0

                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            MasaTemp = NHMRed.Item("Masa")
                            Razred = NHMRed.Item("R")
                            bZaokruziMasuNa100k(MasaTemp)
                            NHMRed.Item("RacMasaNHM") = MasaTemp

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

                    'bKorigujRacMasePoRazredima(Masa1R, Masa2R, Masa3R, BrOsovina, "25", Masa1R, Masa2R, Masa3R, TonskiStav)

                    For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM
                        If NHMRed.Item("IndBrojKola") = IBK Then

                            NHMRed.Item("VozarinskiStavNHM") = 0

                        End If
                    Next

                    RacMasaPoKolima = Masa1R + Masa2R + Masa3R
                    bRacunskaMasaPoKolima = RacMasaPoKolima

                    KolaRed.Item("Prevoznina") = 0
                    KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = 0

                End If
                Prevoznina = 0
                bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima

            Next    ' petlja po kolima

        Else
            ' nema ni kola ni prevoznine
        End If

    End Sub

    Public Sub bNadjiPrevozninuUSS(ByRef Prevoznina As Decimal)    ' US Steel

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow

        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna As String
        Dim BrOsovina As Byte
        Dim KolKoef As Decimal = 1
        Dim MasaTemp As Integer
        Dim Razred As String

        Dim VozarinskiStav As Decimal = 0
        Dim VozarinskiStav1 As Decimal = 0
        Dim VozarinskiStav2 As Decimal = 0
        Dim PV As String

        Dim PrevozninaPoKolima As Decimal = 0

        'novo
        Dim Smasa1 As Int32 = 0
        Dim Smasa2 As Int32 = 0
        Dim KolPrevKoef As Decimal = 1
        Dim Prev1 As Decimal = 0
        Dim Prev2 As Decimal = 0
        'end novo

        Dim SMasaKola As Decimal = 0
        Dim TaraKola As Decimal = 0


        bRacunskaMasa = 0
        Prevoznina = 0

        If dtNhm.Rows(0).Item("NHM") = "992100" Or dtNhm.Rows(0).Item("NHM") = "992200" Then
            bSvaTovarena = "PK"
        Else
            bSvaTovarena = "TK"
        End If

        USSNHM = dtNhm.Rows(0).Item("NHM")
        USSIBK = dtKola.Rows(0).Item("IndBrojKola")

        If bSvaTovarena = "TK" Then                ' tovarena

            If dtKola.Rows.Count > 0 Then

                '---------------- novo ------------------------------------------------
                For Each KolaRed In dtKola.Rows    ' petlja po kolima
                    IBK = KolaRed.Item("IndBrojKola")
                    TipKola = KolaRed.Item("Tip")
                    'Vlasnistvo = mVlasnik
                    Vlasnistvo = KolaRed.Item("Vlasnik")
                    TaraKola = KolaRed.Item("Tara")
                    bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

                    For Each NHMRed In dtNhm.Rows   '  petlja po robi
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            SMasaKola = NHMRed.Item("Masa")
                            If Vlasnistvo = "Z" Then
                                If NHMRed.Item("Masa") < 10000 Then
                                    Smasa1 = Smasa1 + 10000
                                Else
                                    Smasa1 = Smasa1 + NHMRed.Item("Masa")
                                End If
                                KolaRed.Item("RacunskaMasa") = Smasa1
                            Else
                                If NHMRed.Item("Masa") < 10000 Then
                                    Smasa2 = Smasa2 + 10000
                                Else
                                    Smasa2 = Smasa2 + NHMRed.Item("Masa")
                                End If
                                KolaRed.Item("RacunskaMasa") = Smasa2
                            End If
                            NHMRed.Item("RacMasaNHM") = NHMRed.Item("Masa")
                        End If
                        KolaRed.Item("Prevoznina") = 0     'PrevozninaPoKolima
                        KolaRed.Item("VozarinskiStav") = 0 'VozarinskiStav
                    Next
                    BMVozaPoTL = BMVozaPoTL + SMasaKola + TaraKola
                Next



                bNadjiVozarinskiStavUSS(VozarinskiStav)

                For Each KolaRed In dtKola.Rows    ' petlja po kolima
                    IBK = KolaRed.Item("IndBrojKola")
                    'Vlasnistvo = mVlasnik
                    Vlasnistvo = KolaRed.Item("Vlasnik")

                    For Each NHMRed In dtNhm.Rows
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            If Vlasnistvo = "Z" Then
                                KolPrevKoef = 1
                                VozarinskiStav1 = VozarinskiStav * KolPrevKoef
                            Else
                                KolPrevKoef = 0.8
                                VozarinskiStav2 = VozarinskiStav * KolPrevKoef
                                bZaokruziNaDeseteNavise(VozarinskiStav2)
                            End If
                        End If
                    Next
                Next

                'VozarinskiStav = VozarinskiStav * KolPrevKoef

                'If Vlasnistvo = "P" Then
                '    bZaokruziNaDeseteNavise(VozarinskiStav)
                'End If

                If mStanica1 = "13603" And mStanica2 = "13670" And Not (Vlasnistvo = "Z") Then      'UTL
                    KolPrevKoef = 1
                    If (mDatumKalk < ("3.8.2011")) Then
                        VozarinskiStav = 1.25
                        VozarinskiStav1 = 1.25
                        VozarinskiStav2 = 1.25
                    Else
                        VozarinskiStav = 1.28
                        VozarinskiStav1 = 1.28
                        VozarinskiStav2 = 1.28
                    End If
                End If

                bZaokruziMasuNa100k(Smasa1)
                bZaokruziMasuNa100k(Smasa2)

                Prev1 = Smasa1 * VozarinskiStav1 / 1000 'Z
                Prev2 = Smasa2 * VozarinskiStav2 / 1000 'P


                bZaokruziNaDeseteNavise(Prev1)
                bZaokruziNaDeseteNavise(Prev2)


                Dim TovPraMP As String
                Dim VlasnMP As String
                bPraznaKaoRobaTar2015(mDatumKalk, USSNHM, TovPraMP, VlasnMP)
                If TovPraMP = "" Then
                    TovPraMP = "TK"
                End If
                If VlasnMP = "" Then
                    VlasnMP = Vlasnistvo
                End If

                bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                                     TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

                ' tarifa 2015
                'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                '                     "TK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                '                     bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)




                'KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                'KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                'KolaRed.Item("VozarinskiStav") = VozarinskiStav

                bRacunskaMasaPoKolima = Smasa1 + Smasa2

                'For Each NHMRed In dtNhm.Rows
                '    If NHMRed.Item("IndBrojKola") = IBK Then
                '        NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                '        NHMRed.Item("RacMasaNHM") = bRacunskaMasaPoKolima
                '    End If
                'Next

                For Each KolaRed In dtKola.Rows    ' petlja po kolima
                    IBK = KolaRed.Item("IndBrojKola")
                    Vlasnistvo = KolaRed.Item("Vlasnik")
                    For Each NHMRed In dtNhm.Rows
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            If Vlasnistvo = "Z" Then
                                NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav1
                                NHMRed.Item("RacMasaNHM") = NHMRed.Item("Masa")
                            Else
                                NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav2
                                NHMRed.Item("RacMasaNHM") = NHMRed.Item("Masa")
                            End If
                        End If
                    Next
                Next

                Prevoznina = Prev1 + Prev2

                If Prevoznina <= bMinPrevoznina * dtKola.Rows.Count Then
                    Prevoznina = bMinPrevoznina * dtKola.Rows.Count
                End If
                '---------------------- end novo --------------------------------------


                ''----------------- staro -----------------------------------
                'For Each KolaRed In dtKola.Rows    ' petlja po kolima

                '    IBK = KolaRed.Item("IndBrojKola")
                '    Vrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                '    TipKola = KolaRed.Item("Tip")
                '    Vlasnistvo = KolaRed.Item("Vlasnik")
                '    BrOsovina = KolaRed.Item("Osovine")

                '    '$$$
                '    If Vrsta = "O" Then
                '        Vrsta = 1
                '    End If
                '    If Vrsta = "S" Then
                '        Vrsta = 2
                '    End If
                '    '$$$

                '    'Select Case TipKola
                '    '    Case "1"
                '    '        KolKoef = 1.0
                '    '    Case "2"
                '    '        KolKoef = 1.3
                '    '    Case "3"
                '    '        KolKoef = 0.8
                '    '    Case "4"
                '    '        KolKoef = 0.8
                '    '    Case "5"
                '    '        KolKoef = 0.8
                '    '    Case "6"
                '    '        KolKoef = 0.8
                '    '    Case "7"
                '    '        KolKoef = 0.3
                '    'End Select

                '    pubSerijaKola = KolaRed.Item("Serija") '## T kola
                '    pubIBK = Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) '## T kola
                '    bNadjiTipKolaKoef(TipKola, mTarifa, "00000", mDatumKalk, KolKoef, PV)

                '    If TipKola = "7" Then
                '        TovarenaPrazna = "PK"
                '    Else
                '        TovarenaPrazna = "TK"
                '    End If

                '    If dtNhm.Rows.Count > 0 Then
                '        bRacunskaMasaPoKolima = 0
                '        For Each NHMRed In dtNhm.Rows   '  petlja po robi
                '            If NHMRed.Item("IndBrojKola") = IBK Then
                '                MasaTemp = NHMRed.Item("Masa")
                '                NHMRed.Item("RacMasaNHM") = MasaTemp
                '                bRacunskaMasaPoKolima = bRacunskaMasaPoKolima + MasaTemp
                '            End If
                '        Next

                '        'Budimirovic+Sladjana: bZaokruziMasuNa100k(bRacunskaMasaPoKolima)

                '        If bRacunskaMasaPoKolima < 10000 Then
                '            bRacunskaMasaPoKolima = 10000
                '        End If


                '        bProveri8606(_mNHM, bNHM8606, bNHMKao8606)
                '        'If (bNHM8606 Or bNHMKao8606) Then
                '        '    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                '        '           "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                '        '           bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                '        'Else
                '        '    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                '        '           TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                '        '           bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                '        'End If

                '        bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
                '                             TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                '                             bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)


                '        PrevozninaPoKolima = 0

                '        'For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM
                '        '    If NHMRed.Item("IndBrojKola") = IBK Then

                '        '        NHMRed.Item("VozarinskiStavNHM") = 0

                '        '    End If
                '        'Next

                '        'KolaRed.Item("Prevoznina") = 0
                '        'KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                '        'KolaRed.Item("VozarinskiStav") = 0

                '    End If

                '    bRacunskaMasa = bRacunskaMasa + bRacunskaMasaPoKolima



                '    'Budimirovic+Sladjana
                '    bNadjiVozarinskiStavUSS(VozarinskiStav)
                '    Dim KolPrevKoef As Decimal = 1
                '    PV = ""
                '    bNadjiKolPrevKoef("200379", TipKola, "0", "0", "00", "00", "00", KolPrevKoef, PV)

                '    VozarinskiStav = VozarinskiStav * KolPrevKoef

                '    If Vlasnistvo = "P" Then
                '        bZaokruziNaDeseteNavise(VozarinskiStav)
                '    End If

                '    If mStanica1 = "13603" And mStanica2 = "13670" And Not (Vlasnistvo = "Z") Then
                '        KolPrevKoef = 1
                '        If (mDatumKalk < ("3.8.2011")) Then
                '            VozarinskiStav = 1.25
                '        Else
                '            VozarinskiStav = 1.28
                '        End If

                '    End If

                '    PrevozninaPoKolima = bRacunskaMasaPoKolima * VozarinskiStav / 1000

                '    bZaokruziNaDeseteNavise(PrevozninaPoKolima)

                '    If PrevozninaPoKolima <= bMinPrevoznina Then
                '        PrevozninaPoKolima = bMinPrevoznina
                '    End If

                '    KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                '    KolaRed.Item("RacunskaMasa") = bRacunskaMasaPoKolima
                '    KolaRed.Item("VozarinskiStav") = VozarinskiStav

                '    For Each NHMRed In dtNhm.Rows
                '        If NHMRed.Item("IndBrojKola") = IBK Then
                '            NHMRed.Item("VozarinskiStavNHM") = VozarinskiStav
                '            NHMRed.Item("RacMasaNHM") = bRacunskaMasaPoKolima
                '        End If
                '    Next

                '    'iskljuceno 10/10/2013 Mandic-Slavica: pr. 13603+326827
                '    'If (dtKola.Rows.Count < 6) Then
                '    '    Prevoznina = Prevoznina + PrevozninaPoKolima
                '    'End If

                '    Prevoznina = Prevoznina + PrevozninaPoKolima
                'Next
                ''----------------- end staro -----------------------------------

                ''ukupna racunska masa:




                'iskljuceno 10/10/2013 Mandic-Slavica: pr. 13603+326827
                'If (dtKola.Rows.Count >= 6) Then                     ' videti ako je jedan tovarni list ili ako je po najavi ?
                '    Prevoznina = bRacunskaMasa * VozarinskiStav / 1000
                '    bZaokruziNaDeseteNavise(Prevoznina)

                '    If Prevoznina <= dtKola.Rows.Count * bMinPrevoznina Then
                '        Prevoznina = dtKola.Rows.Count * bMinPrevoznina
                '    End If

                'End If

            End If

        ElseIf bSvaTovarena = "PK" Then    ' prazna

            bNadjiPrevozninu00T("122", Prevoznina)

        End If

    End Sub
    Public Sub bNadjiVozarinskiStavUSS(ByRef vsUSSteel As Decimal)    ' US Steel
        'Dim vsUSSteel As Decimal
        Dim stUSSteel As String
        Dim grUSSteel As String



        If IzborSaobracaja = "2" Then   'uvoz
            stUSSteel = Microsoft.VisualBasic.Right(mPrStanica, 5)
            grUSSteel = mStanica1
        Else                            'izvoz
            stUSSteel = Microsoft.VisualBasic.Right(mOtpStanica, 5)
            grUSSteel = mStanica2
        End If

        If (mDatumKalk < ("3.8.2011")) Then
            Select Case grUSSteel
                Case "23499"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 10.5
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 10.35
                    End If
                Case "22899"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 10.7
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 11.2
                    End If
                Case "21099"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 7.6
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 9
                    End If
                Case "15723"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 10.45
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 14.6
                    End If
                Case "11028"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 12.2
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 18
                    End If
                Case "12498"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 11.15
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 16.9
                    End If
                Case "16517"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 7.9
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 5.3
                    End If
                Case "16319"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 9.85
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 5.3
                    End If
            End Select
        ElseIf ((mDatumKalk >= ("3.8.2011")) And (mDatumKalk < ("1.5.2015"))) Then
            Select Case grUSSteel
                Case "23499"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 10.65
                        If (mDatumKalk >= ("15.9.2011")) And (mDatumKalk < ("3.10.2011")) Then
                            If ((mVrstaPrevoza = "V") And (Microsoft.VisualBasic.Mid(USSIBK, 3, 2) = "56")) Then
                                If ((Microsoft.VisualBasic.Left(USSNHM, 4) = "2704") And (mOtpUprava = "56") And (IzborSaobracaja = "2")) Then
                                    vsUSSteel = 10.65
                                End If
                                If ((Microsoft.VisualBasic.Left(USSNHM, 4) = "7204") And (mPrUprava = "56") And (IzborSaobracaja = "3")) Then
                                    vsUSSteel = 8.0
                                End If
                            End If
                        End If

                        If (mDatumKalk >= ("3.10.2011")) Then
                            If ((mVrstaPrevoza = "V") And (Microsoft.VisualBasic.Mid(USSIBK, 3, 2) = "56")) Then
                                If ((Microsoft.VisualBasic.Left(USSNHM, 4) = "2704") And (Microsoft.VisualBasic.Left(USSNHM, 4) = "2601") And (mOtpUprava = "56") And (IzborSaobracaja = "2")) Then
                                    vsUSSteel = 10.65
                                End If
                                If ((Microsoft.VisualBasic.Left(USSNHM, 4) = "7204") And (mPrUprava = "56") And (IzborSaobracaja = "3")) Then
                                    vsUSSteel = 8.0
                                End If
                            End If
                        End If

                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 10.5
                    End If
                Case "22899"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 11.0
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 11.4
                    End If
                Case "21099"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 7.8
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 9.25
                    End If
                Case "15723"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 10.75
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 15.0
                    End If
                Case "11028"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 12.55
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 18.3
                    End If
                Case "12498"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 11.5
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 17.2
                    End If
                Case "16517"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 8.1
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 5.4
                    End If
                Case "16319"
                    If stUSSteel = "13603" Then
                        vsUSSteel = 10.0
                    ElseIf stUSSteel = "16350" Then
                        vsUSSteel = 5.4
                    End If
            End Select
        ElseIf (mDatumKalk >= ("1.5.2015")) Then
            Select Case grUSSteel
                Case "23499"                        ' Subotica gr.
                    If stUSSteel = "13603" Then     ' Radinac                        

                        If ((Microsoft.VisualBasic.Left(USSNHM, 4) = "2701") Or (Microsoft.VisualBasic.Left(USSNHM, 4) = "2704")) Then
                            vsUSSteel = 8.2                       ' koks ?
                        Else
                            vsUSSteel = 8.6                       ' nije koks
                        End If

                        If (mVrstaPrevoza = "V" And BMVozaPoTL > 2200000) Then       ' dodati uslov za bruto
                            vsUSSteel = 7.5
                        End If

                    ElseIf stUSSteel = "16350" Then ' Sabac
                        'vsUSSteel = 10.5
                        vsUSSteel = 8.4
                    End If
                Case "22899"                        ' Kikinda gr.
                    If stUSSteel = "13603" Then     ' Radinac
                        vsUSSteel = 11.0
                    ElseIf stUSSteel = "16350" Then ' Sabac
                        vsUSSteel = 11.4
                    End If
                Case "21099"                        ' Vrsac gr.
                    If stUSSteel = "13603" Then     ' Radinac
                        'vsUSSteel = 7.8
                        vsUSSteel = 6.3
                    ElseIf stUSSteel = "16350" Then ' Sabac
                        vsUSSteel = 9.25
                    End If
                Case "15723"                        ' Prijepolje ter. gr.
                    If stUSSteel = "13603" Then     ' Radinac
                        'vsUSSteel = 10.75
                        vsUSSteel = 9.9
                    ElseIf stUSSteel = "16350" Then ' Sabac
                        vsUSSteel = 15.0
                    End If
                Case "11028"                        ' Presevo gr.    
                    If stUSSteel = "13603" Then     ' Radinac
                        'vsUSSteel = 12.55
                        vsUSSteel = 10
                    ElseIf stUSSteel = "16350" Then ' Sabac
                        vsUSSteel = 18.3
                    End If
                Case "12498"                        ' Dimitrovgrad gr.
                    If stUSSteel = "13603" Then     ' Radinac       
                        'vsUSSteel = 11.5
                        vsUSSteel = 9.2
                    ElseIf stUSSteel = "16350" Then ' Sabac
                        vsUSSteel = 17.2
                    End If
                Case "16517"                        ' Sid gr.
                    If stUSSteel = "13603" Then     ' Radinac
                        'vsUSSteel = 8.1
                        vsUSSteel = 6.5
                    ElseIf stUSSteel = "16350" Then ' Sabac
                        'vsUSSteel = 5.4
                        vsUSSteel = 4.4
                    End If
                Case "16319"                        ' Brasina gr.
                    If stUSSteel = "13603" Then     ' Radinac
                        'vsUSSteel = 10.0
                        vsUSSteel = 8.9
                    ElseIf stUSSteel = "16350" Then ' Sabac
                        vsUSSteel = 5.4
                    End If
            End Select



        End If


    End Sub
    Public Sub bNadjiVozarinskiStavAgit(ByRef vsAgit As Decimal)    ' Agit aneks

        vsAgit = 0

        If mBrojUg = "031022" Then
            If mStanica1 = "16517" Then
                If mStanica2 = "16050" Or mStanica2 = "16051" Then
                    vsAgit = 128
                ElseIf mStanica2 = "21001" Then
                    vsAgit = 140
                End If
            End If

            If mStanica2 = "16517" Then
                If mStanica1 = "16050" Or mStanica1 = "16051" Then
                    vsAgit = 128
                ElseIf mStanica1 = "21001" Then
                    vsAgit = 140
                End If
            End If
        ElseIf mBrojUg = "031122" Then
            If mStanica1 = "16517" Then
                If mStanica2 = "16050" Or mStanica2 = "16051" Then
                    vsAgit = 128
                ElseIf mStanica2 = "21001" Then
                    vsAgit = 140
                End If
            End If

            If mStanica2 = "16517" Then
                If mStanica1 = "16050" Or mStanica1 = "16051" Then
                    vsAgit = 128
                ElseIf mStanica1 = "21001" Then
                    vsAgit = 140
                End If
            End If
        End If


    End Sub
    Public Sub bNadjiVozarinskiStavKampakis(ByRef vsKampakis As Decimal)    ' Agit aneks

        vsKampakis = 0

        If mStanica1 = "11028" And mStanica2 = "12420" Then         ' Presevo - Pirot
            If mStanica2 = "12420" Then
                vsKampakis = 122
            ElseIf mStanica2 = "21001" Then
                vsKampakis = 133.2
            End If
        End If

        'If mStanica2 = "16517" Then
        '    If mStanica1 = "16050" Or mStanica1 = "16051" Then
        '        vsAgit = 122
        '    ElseIf mStanica1 = "21001" Then
        '        vsAgit = 133.2
        '    End If
        'End If


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


        '        bRacunskaMasaPoKolima = 0

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

        If mTarifa = "46" Then      ' Ekspres
            mTabelaCena = "801"
        Else
            mTabelaCena = "112"
        End If

        Dim Kdec = 0.1      ' koeficijent za tabelu ( cena je za 10kg )
        'End If

        bNadjiVozarinskiStav(mTabelaCena, mDatumKalk, RacMasaD, bTkm, "0", VozarinskiStav, PV)

        PrevozninaPoPosiljci = RacMasaD * VozarinskiStav * bTarDKoef * Kdec

        ' dodato za probu
        bVrstaStanice = "M"
        ' dodato za probu
        '"36"
        bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, "Z", _
               "TK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
               bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

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
    Public Sub bNadjiTipKolaKoef( _
                ByVal inTip As String, _
                ByVal inSifraTarife As String, _
                ByVal inUslov As String, _
                ByVal inDatumKalk As Date, _
                ByRef outKolKoef As Decimal, _
                ByRef outRetVal As String)

        outKolKoef = 1
        outRetVal = ""

        If DbVezaCene.State = ConnectionState.Closed Then
            DbVezaCene.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.bspNadjiKolKoef", DbVezaCene)
        spKomanda.CommandType = CommandType.StoredProcedure
        'spKomanda.CommandTimeout = 360

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

            'If DbVezaCene.State = ConnectionState.Closed Then
            '    DbVezaCene.Open()
            'End If

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
    Public Sub bNadjiPrevozninuICFT(ByRef Prevoznina As Decimal)          ' ICF po tarifi
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
        Dim PrevozninaZaUTI, PrevozninaPoKolima, RacunskaMasaPoKolima, VozarinskiStavPoKolima As Decimal
        Dim bABCD As Integer                   ' broj ukupno realizovanih vozova
        Dim BrutoMasa As Decimal
        Dim bPkolKoef As Decimal = 1

        'Util.sNadjiNaziv("TabNaziv", mBrojUg, "", "", 1, xNaziv, xPovVrednost)
        'mTabelaCena = xNaziv

        mTabelaCena = "914"

        PrevozninaPoKolima = 0
        RacunskaMasaPoKolima = 0
        VozarinskiStavPoKolima = 0


        For Each KolaRed In dtKola.Rows    ' petlja po kolima
            IBK = KolaRed.Item("IndBrojKola")
            Vlasnistvo = KolaRed.Item("Vlasnik")

            TovarenaPrazna = "TU"
            bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
            TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
            bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

            ' dok se ne doda u tabeli
            bMinPrevoznina = 120
            ' dok se ne doda u tabeli

            For Each NHMRed In dtNhm.Rows
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
                    RacunskaMasaPoKolima = RacunskaMasaPoKolima + MasaTemp
                    VozarinskiStavPoKolima = bVozarinskiStav
                End If
            Next

            bZaokruziNaCeleNavise(PrevozninaPoKolima)  ' ili na desete?

            If PrevozninaPoKolima <= bMinPrevoznina Then
                PrevozninaPoKolima = bMinPrevoznina
            End If

            Prevoznina = PrevozninaPoKolima
            dtKola.Rows(0).Item("Prevoznina") = Prevoznina
            dtKola.Rows(0).Item("RacunskaMasa") = RacunskaMasaPoKolima
            dtKola.Rows(0).Item("VozarinskiStav") = VozarinskiStavPoKolima

        Next

        'If (mTabelaCena = "914") Then               ' Formalno; pojedinacne, pa petlja po kolima
        '    IBK = dtKola.Rows(0).Item("IndBrojKola")
        '    Vlasnistvo = KolaRed.Item("Vlasnik")
        '    bMinPrevoznina = 0

        '    ' usaglasiti ulazne parametre
        '    TovarenaPrazna = "TU"
        '    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
        '    TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
        '    bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

        '    For Each NHMRed In dtNhm.Rows                                                ' petlja po robi za jedna kola
        '        If NHMRed.Item("IndBrojKola") = IBK Then
        '            MasaTemp = NHMRed.Item("Masa")
        '            DuzinaKontTemp = NHMRed.Item("UTI")
        '            bNadjiRasterCO(DuzinaKontTemp, MasaTemp, RasterTemp)
        '            IzStav = 0
        '            ' razvojiti Sopron i ne-Sopron u bazi
        '            StavIcfN(mBrojUg, "220", mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "0", "0", IzStav, PovVr)
        '            If IzStav = 0 Then
        '                StavIcfN(mBrojUg, "221", mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "0", "0", IzStav, PovVr)
        '            End If
        '            If (mTabelaCena = "220") Then                            ' cena po UTI-ju
        '                PrevozninaZaUTI = IzStav * RasterTemp

        '            ElseIf (mTabelaCena = "221") Then                     ' koeficijent na cenu po UTI-ju iz tarife (tab 914)
        '                bNadjiVozarinskiStavKontTEA("914", mDatumKalk, bTkm, StavPoTEA, PovVr)
        '                PrevozninaZaUTI = StavPoTEA * IzStav * RasterTemp
        '            End If


        '            bZaokruziMasuNa100k(MasaTemp)
        '            NHMRed.Item("RacMasaNHM") = MasaTemp
        '            NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStav

        '            PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaZaUTI
        '        End If
        '    Next

        '    bZaokruziNaCeleNavise(PrevozninaPoKolima)  ' ili na desete?

        '    If PrevozninaPoKolima <= bMinPrevoznina Then
        '        PrevozninaPoKolima = bMinPrevoznina
        '    End If

        '    Prevoznina = PrevozninaPoKolima
        '    dtKola.Rows(0).Item("Prevoznina") = Prevoznina
        '    dtKola.Rows(0).Item("RacunskaMasa") = 
        '    dtKola.Rows(0).Item("VozarinskiStav") = 

        'ElseIf ((mTabelaCena = "201") Or (mTabelaCena = "202")) Then       ' vozovi

        '    If mBrojUg = "993353" Then
        '        If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then 'shuttle
        '            mTabelaCena = "202"
        '        Else                                                          ' mix  
        '            mTabelaCena = "201"
        '        End If
        '    ElseIf mBrojUg = "993354" Then
        '        If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
        '            mTabelaCena = "202"
        '        Else
        '            mTabelaCena = "201"
        '        End If
        '    End If

        '    BrutoMasa = 0
        '    bNadjiBrutoMasu(BrutoMasa, bPkolKoef)
        '    bNadjiBrojRealizovanihVozova(mBrojUg, mStanica1, mStanica2, bABCD, PovVr)

        '    StavIcfN(mBrojUg, mTabelaCena, mDatumKalk, BrutoMasa, mStanica1, mStanica2, "00", "", "0", Prevoznina, PovVr)

        '    '----------- Upis racunske mase i vozarinskog stava po robi za ceo voz----------
        '    bVozarinskiStav = Prevoznina
        '    For Each KolaRed In dtKola.Rows    ' petlja po kolima
        '        IBK = KolaRed.Item("IndBrojKola")
        '        For Each NHMRed In dtNhm.Rows
        '            If NHMRed.Item("IndBrojKola") = IBK Then
        '                MasaTemp = NHMRed.Item("Masa")
        '                bZaokruziMasuNa100k(MasaTemp)
        '                NHMRed.Item("RacMasaNHM") = MasaTemp
        '                NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStav
        '            End If
        '        Next
        '    Next
        'ElseIf (mTabelaCena = "333") Then       ' Adria combi pojedinacne
        '    IBK = dtKola.Rows(0).Item("IndBrojKola")
        '    Vlasnistvo = dtKola.Rows(0).Item("Vlasnik")
        '    bMinPrevoznina = 0

        '    ' usaglasiti ulazne parametre
        '    TovarenaPrazna = "TU"
        '    bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, Vlasnistvo, _
        '    TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
        '    bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)

        '    For Each NHMRed In dtNhm.Rows                                                ' petlja po robi za jedna kola
        '        If NHMRed.Item("IndBrojKola") = IBK Then
        '            MasaTemp = NHMRed.Item("Masa")
        '            DuzinaKontTemp = NHMRed.Item("UTI")
        '            bNadjiRasterCO(DuzinaKontTemp, MasaTemp, RasterTemp)
        '            IzStav = 0

        '            ''' razvojiti Sopron i ne-Sopron u bazi
        '            ''StavIcfN(mBrojUg, "220", mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "0", "0", IzStav, PovVr)
        '            ''If IzStav = 0 Then
        '            ''    StavIcfN(mBrojUg, "221", mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "0", "0", IzStav, PovVr)
        '            ''End If
        '            ''If (mTabelaCena = "220") Then                            ' cena po UTI-ju
        '            ''    PrevozninaZaUTI = IzStav * RasterTemp

        '            ''ElseIf (mTabelaCena = "221") Then                     ' koeficijent na cenu po UTI-ju iz tarife (tab 914)
        '            ''    bNadjiVozarinskiStavKontTEA("914", mDatumKalk, bTkm, StavPoTEA, PovVr)
        '            ''    PrevozninaZaUTI = StavPoTEA * IzStav * RasterTemp
        '            ''End If

        '            If mBrojUg = "835745" Then 'AdriaCombi
        '                IzStav = 135 'cena po UTI
        '            ElseIf mBrojUg = "931817" Then 'Eurolog
        '                IzStav = 2772 'cena po vozu
        '            End If

        '            PrevozninaZaUTI = IzStav '* RasterTemp

        '            bZaokruziMasuNa100k(MasaTemp)
        '            NHMRed.Item("RacMasaNHM") = MasaTemp
        '            NHMRed.Item("VozarinskiStavNHM") = IzStav 'bVozarinskiStav

        '            If mBrojUg = "835745" Then 'AdriaCombi
        '                PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaZaUTI
        '            ElseIf mBrojUg = "931817" Then 'Eurolog
        '                PrevozninaPoKolima = 2772 'cena po vozu
        '            End If

        '        End If
        '    Next

        '    bZaokruziNaCeleNavise(PrevozninaPoKolima)  ' ili na desete?

        '    If PrevozninaPoKolima <= bMinPrevoznina Then
        '        PrevozninaPoKolima = bMinPrevoznina
        '    End If

        '    Prevoznina = PrevozninaPoKolima
        '    dtKola.Rows(0).Item("Prevoznina") = Prevoznina

        'End If
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

End Module


