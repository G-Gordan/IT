Imports System.Data.SqlClient
Module Util
    Public tempIznos8216 As Decimal = 15
    Dim dsSlogKola As New DataSet("dsSlogKola")
    Dim dsSlogNHM As New DataSet("dsSlogNHM")
    Dim dsSlogNak As New DataSet("dsSlogNak")
    Dim dsSlogK211 As New DataSet("dsSlogK211")
    Dim dsSlogUic As New DataSet("dsSlogUic")
    Public Sub NadjiUlazniTranzit(ByVal _UlaznaNalepnica As Int32, ByVal _UlazniPrelaz As String, ByRef _otUprava As String, _
                                  ByRef _otStanica As String, ByRef _otBroj As Int32, ByRef _otDatum As Date, _
                                  ByRef _IzlaznaNalepnica As Int32, ByRef _IBK As String, ByRef _BrojVoza As String, _
                                  ByRef _RecID As Int32, ByRef _mRetVal As String)

        _mRetVal = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiUlazniTranzit", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inUlaznaNalepnica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUlaznaNalepnica", SqlDbType.Int, 4))
        inUlaznaNalepnica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUlaznaNalepnica").Value = _UlaznaNalepnica

        Dim inUlazniPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUlazniPrelaz", SqlDbType.Char, 5))
        inUlazniPrelaz.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUlazniPrelaz").Value = _UlazniPrelaz

        Dim outUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUprava", SqlDbType.Char, 4))
        outUprava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUprava").Value = _otUprava

        Dim outStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanica", SqlDbType.Char, 7))
        outStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanica").Value = _otStanica

        Dim outBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBroj", SqlDbType.Int, 4))
        outBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBroj").Value = _otBroj

        Dim outDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outDatum", SqlDbType.DateTime, 8))
        outDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outDatum").Value = _otDatum

        Dim outIzlaznaNalepnica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIzlaznaNalepnica", SqlDbType.Int, 4))
        outIzlaznaNalepnica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIzlaznaNalepnica").Value = _IzlaznaNalepnica

        Dim outIBK As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIBK", SqlDbType.Char, 12))
        outIBK.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIBK").Value = _IBK

        Dim outBrojVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrojVoza", SqlDbType.Char, 10))
        outBrojVoza.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBrojVoza").Value = _BrojVoza

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = _mRetVal

        Dim oppRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        Try
            spKomanda.ExecuteScalar()

            _otUprava = spKomanda.Parameters("@outUprava").Value
            _otStanica = spKomanda.Parameters("@outStanica").Value
            _otBroj = spKomanda.Parameters("@outBroj").Value
            _otDatum = spKomanda.Parameters("@outDatum").Value
            _IzlaznaNalepnica = spKomanda.Parameters("@outIzlaznaNalepnica").Value
            _IBK = spKomanda.Parameters("@outIBK").Value
            _BrojVoza = spKomanda.Parameters("@outBrojVoza").Value
            _RecID = spKomanda.Parameters("@oppRecID").Value
            _mRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch ex As Exception
            _mRetVal = Err.Description & " Greska u programu!"
        Catch sqlexp As Exception
            _mRetVal = sqlexp.Message & " SQL greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub

    Public Sub NadjiUgovor(ByVal _Ugovor As String, ByRef _NazivKomitenta As String, ByRef _Primalac As Int32, ByRef _VrstaObracuna As String, _
                           ByRef outRetVal As String)

        outRetVal = ""


        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiUgovor", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        inUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _Ugovor

        Dim outNaziv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNaziv", SqlDbType.VarChar, 30))
        outNaziv.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNaziv").Value = _NazivKomitenta

        Dim outSifra As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifra", SqlDbType.Int, 4))
        outSifra.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifra").Value = _Primalac

        Dim outVrstaObr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrstaObr", SqlDbType.Char, 2))
        outVrstaObr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVrstaObr").Value = _VrstaObracuna

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()
            _NazivKomitenta = spKomanda.Parameters("@outNaziv").Value
            _Primalac = spKomanda.Parameters("@outSifra").Value
            _VrstaObracuna = spKomanda.Parameters("@outVrstaObr").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch sqlexp As Exception
            outRetVal = sqlexp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally

            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub NadjiUgovor2(ByVal _Ugovor As String, ByRef _NazivKomitenta As String, ByRef _Primalac As Int32, ByRef _VrstaObracuna As String, _
                            ByRef _SumaUg As Int32, ByRef outRetVal As String)

        outRetVal = ""


        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiUgovor2", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        inUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _Ugovor

        Dim outNaziv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNaziv", SqlDbType.VarChar, 30))
        outNaziv.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNaziv").Value = _NazivKomitenta

        Dim outSifra As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifra", SqlDbType.Int, 4))
        outSifra.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifra").Value = _Primalac

        Dim outVrstaObr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrstaObr", SqlDbType.Char, 2))
        outVrstaObr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVrstaObr").Value = _VrstaObracuna

        Dim outSumaug As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSumaUg", SqlDbType.Int, 4))
        outSumaug.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSumaUg").Value = _SumaUg

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()
            _NazivKomitenta = spKomanda.Parameters("@outNaziv").Value
            _Primalac = spKomanda.Parameters("@outSifra").Value
            _VrstaObracuna = spKomanda.Parameters("@outVrstaObr").Value
            _SumaUg = spKomanda.Parameters("@outSumaUg").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch sqlexp As Exception
            outRetVal = sqlexp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally

            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub


    Public Sub NadjiTovarniList(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                                ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef outOM As String, ByRef outOG As String, _
                                ByRef bPrUprava As String, ByRef bPrStanica As String, _
                                ByRef bPrBroj As Int32, ByRef mPrDatum As Date, ByRef updTkm As Int32, ByRef bSaobracaj As String, ByRef bZsUlPrelaz As String, ByRef bZsIzPrelaz As String, ByRef bNajava As String, _
                                ByRef bLomSt As String, ByRef bIOP As Int32, ByRef bIOPFrNaknade As String, ByRef bIOPFrDoPrelaza As String, ByRef bIOPIncoterms As String, _
                                ByRef bSifraTarife As String, ByRef bUgovor As String, ByRef bNarPos As String, ByRef bValutaTL As String, _
                                ByRef bPrevozninaFR As Decimal, ByRef bPrevozninaUP As Decimal, ByRef bNaknadeFR As Decimal, ByRef bNaknadeUP As Decimal, _
                                ByRef bBlagFR As Decimal, ByRef bBlagUP As Decimal, ByRef bTLDinFR As Decimal, ByRef bTLDinUP As Decimal, _
                                ByRef bBlagFRDin As Decimal, ByRef bBlagUPDin As Decimal, ByRef bBlagK115Din As Decimal, ByRef bRazlikaFRDin As Decimal, ByRef bRazlikaUPDin As Decimal, _
                                ByRef bRetVal As String)


        bRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL2", OkpDbVeza)
        'Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL3", OkpDbVeza)

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL4", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulazUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = bDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim exOM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOM", SqlDbType.Char, 2))
        exOM.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOM").Value = outOM

        Dim exOG As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOG", SqlDbType.Char, 4))
        exOG.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOG").Value = outOG

        Dim exPrUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrUprava", SqlDbType.Char, 4))
        exPrUprava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrUprava").Value = bPrUprava

        Dim exPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        exPrStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = bPrStanica

        Dim exPrBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrBroj", SqlDbType.Int, 4))
        exPrBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrBroj").Value = bPrBroj

        Dim exPrDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrDatum", SqlDbType.DateTime))
        exPrDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrDatum").Value = mPrDatum

        Dim exTkm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTkm", SqlDbType.Int, 4))
        exTkm.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTkm").Value = updTkm

        '' --- Dodatak za manipulativno mesto - testirati!
        ''Dim exMM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMM", SqlDbType.Char, 5))
        ''exMM.Direction = ParameterDirection.Output
        ''spKomanda.Parameters("@outMM").Value = bMM
        '' --- end testirati!

        Dim exPrSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSaobracaj", SqlDbType.Char, 1))
        exPrSaobracaj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSaobracaj").Value = bSaobracaj

        Dim exZsUlPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outZsUlPrelaz", SqlDbType.Char, 5))
        exZsUlPrelaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outZsUlPrelaz").Value = bZsUlPrelaz

        Dim exZsIzPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outZsIzPrelaz", SqlDbType.Char, 5))
        exZsIzPrelaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outZsIzPrelaz").Value = bZsIzPrelaz

        Dim exNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNajava", SqlDbType.Char, 10))
        exNajava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNajava").Value = bNajava

        Dim exLomSt As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outLomSt", SqlDbType.Char, 5))
        exLomSt.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outLomSt").Value = bLomSt

        Dim exIOP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIOP", SqlDbType.SmallInt))
        exIOP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIOP").Value = bIOP

        Dim exIOPFrNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIOPFrNaknade", SqlDbType.VarChar, 10))
        exIOPFrNaknade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIOPFrNaknade").Value = bIOPFrNaknade

        Dim exIOPFrDoPrelaza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIOPFrDoPrelaza", SqlDbType.Char, 4))
        exIOPFrDoPrelaza.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIOPFrDoPrelaza").Value = bIOPFrDoPrelaza

        Dim exIOPIncoterms As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIOPIncoterms", SqlDbType.Char, 3))
        exIOPIncoterms.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIOPIncoterms").Value = bIOPIncoterms

        Dim exSifraTarife As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife", SqlDbType.Char, 2))
        exSifraTarife.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife").Value = bSifraTarife

        Dim exUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        exUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor

        Dim exNarPos As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNarPos", SqlDbType.Char, 10))
        exNarPos.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNarPos").Value = bNarPos


        Dim exValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outValuta", SqlDbType.Char, 2))
        exValuta.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outValuta").Value = bValutaTL

        '---------------------------------------------------------------------------------------------------------
        Dim izlPrevozninaFR As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevozninaFR", SqlDbType.Decimal))
        izlPrevozninaFR.Size = 9
        izlPrevozninaFR.Precision = 12
        izlPrevozninaFR.Scale = 2
        izlPrevozninaFR.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrevozninaFR").Value = bPrevozninaFR

        Dim izlPrevozninaUP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevozninaUP", SqlDbType.Decimal))
        izlPrevozninaUP.Size = 9
        izlPrevozninaUP.Precision = 12
        izlPrevozninaUP.Scale = 2
        izlPrevozninaUP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrevozninaUP").Value = bPrevozninaUP

        Dim izlNaknadeFR As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNaknadeFR", SqlDbType.Decimal))
        izlNaknadeFR.Size = 9
        izlNaknadeFR.Precision = 12
        izlNaknadeFR.Scale = 2
        izlNaknadeFR.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNaknadeFR").Value = bNaknadeFR

        Dim izlNaknadeUP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNaknadeUP", SqlDbType.Decimal))
        izlNaknadeUP.Size = 9
        izlNaknadeUP.Precision = 12
        izlNaknadeUP.Scale = 2
        izlNaknadeUP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNaknadeUP").Value = bNaknadeUP

        Dim izlBlagFR As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBlagFR", SqlDbType.Decimal))
        izlBlagFR.Size = 9
        izlBlagFR.Precision = 12
        izlBlagFR.Scale = 2
        izlBlagFR.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBlagFR").Value = bBlagFR

        Dim izlBlagUP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBlagUP", SqlDbType.Decimal))
        izlBlagUP.Size = 9
        izlBlagUP.Precision = 12
        izlBlagUP.Scale = 2
        izlBlagUP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBlagUP").Value = bBlagUP

        Dim izlTLDinFR As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTLDinFR", SqlDbType.Decimal))
        izlTLDinFR.Size = 9
        izlTLDinFR.Precision = 12
        izlTLDinFR.Scale = 2
        izlTLDinFR.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTLDinFR").Value = bTLDinFR

        Dim izlTLDinUP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTLDinUP", SqlDbType.Decimal))
        izlTLDinUP.Size = 9
        izlTLDinUP.Precision = 12
        izlTLDinUP.Scale = 2
        izlTLDinUP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTLDinUP").Value = bTLDinUP

        Dim izlBlagFRDin As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBlagFRDin", SqlDbType.Decimal))
        izlBlagFRDin.Size = 9
        izlBlagFRDin.Precision = 12
        izlBlagFRDin.Scale = 2
        izlBlagFRDin.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBlagFRDin").Value = bBlagFRDin

        Dim izlBlagUPDin As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBlagUPDin", SqlDbType.Decimal))
        izlBlagUPDin.Size = 9
        izlBlagUPDin.Precision = 12
        izlBlagUPDin.Scale = 2
        izlBlagUPDin.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBlagUPDin").Value = bBlagUPDin

        Dim izlBlagK115Din As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBlagK115Din", SqlDbType.Decimal))
        izlBlagK115Din.Size = 9
        izlBlagK115Din.Precision = 12
        izlBlagK115Din.Scale = 2
        izlBlagK115Din.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBlagK115Din").Value = bBlagK115Din

        Dim izlRazlikaFRDin As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRazlikaFRDin", SqlDbType.Decimal))
        izlRazlikaFRDin.Size = 9
        izlRazlikaFRDin.Precision = 12
        izlRazlikaFRDin.Scale = 2
        izlRazlikaFRDin.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRazlikaFRDin").Value = bRazlikaFRDin

        Dim izlRazlikaUPDin As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRazlikaUPDin", SqlDbType.Decimal))
        izlRazlikaUPDin.Size = 9
        izlRazlikaUPDin.Precision = 12
        izlRazlikaUPDin.Scale = 2
        izlRazlikaUPDin.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRazlikaUPDin").Value = bRazlikaUPDin

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            outOM = spKomanda.Parameters("@outOM").Value
            outOG = spKomanda.Parameters("@outOG").Value

            bPrUprava = spKomanda.Parameters("@outPrUprava").Value
            bRecID = spKomanda.Parameters("@outRecID").Value
            UpdRecID = bRecID
            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdStanicaRecID = bStanicaRecID

            bPrStanica = spKomanda.Parameters("@outPrStanica").Value
            bPrBroj = spKomanda.Parameters("@outPrBroj").Value
            mPrDatum = spKomanda.Parameters("@outPrDatum").Value
            updTkm = spKomanda.Parameters("@outTkm").Value

            '''mManipulativnoMesto = spKomanda.Parameters("@outMM").Value
            bSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
            IzborSaobracaja = bSaobracaj
            bZsUlPrelaz = spKomanda.Parameters("@outZsUlPrelaz").Value
            bZsIzPrelaz = spKomanda.Parameters("@outZsIzPrelaz").Value

            '''LomStanica = spKomanda.Parameters("@outLomSt").Value

            bIOP = spKomanda.Parameters("@outIOP").Value
            mSifraIzjave = bIOP
            bIOPFrNaknade = spKomanda.Parameters("@outIOPFrNaknade").Value
            upis_mFrNaknade = bIOPFrNaknade
            bIOPFrDoPrelaza = spKomanda.Parameters("@outIOPFrDoPrelaza").Value
            mDoPrelaza = bIOPFrDoPrelaza
            bIOPIncoterms = spKomanda.Parameters("@outIOPIncoterms").Value
            mIncoterms = bIOPIncoterms
            bNajava = spKomanda.Parameters("@outNajava").Value
            bSifraTarife = spKomanda.Parameters("@outSifraTarife").Value
            bUgovor = spKomanda.Parameters("@outUgovor").Value
            bNarPos = spKomanda.Parameters("@outNarPos").Value

            '-------------------------- iznosi ---------------------------
            bValutaTL = spKomanda.Parameters("@outValuta").Value
            bPrevozninaFR = spKomanda.Parameters("@outPrevozninaFR").Value
            bPrevozninaUP = spKomanda.Parameters("@outPrevozninaUP").Value
            bNaknadeFR = spKomanda.Parameters("@outNaknadeFR").Value
            bNaknadeUP = spKomanda.Parameters("@outNaknadeUP").Value
            bBlagFR = spKomanda.Parameters("@outBlagFR").Value
            bBlagUP = spKomanda.Parameters("@outBlagUP").Value
            bTLDinFR = spKomanda.Parameters("@outTLDinFR").Value
            bTLDinUP = spKomanda.Parameters("@outTLDinUP").Value
            bBlagFRDin = spKomanda.Parameters("@outBlagFRDin").Value
            bBlagUPDin = spKomanda.Parameters("@outBlagUPDin").Value
            bBlagK115Din = spKomanda.Parameters("@outBlagK115Din").Value
            bRazlikaFRDin = spKomanda.Parameters("@outRazlikaFRDin").Value
            bRazlikaUPDin = spKomanda.Parameters("@outRazlikaUPDin").Value
            '-------------------------------------------------------------

            'popunjava 5 gridova
            Dim ug_mNazivKomitenta As String
            Dim ug_mPrimalac As String
            Dim ug_mVrstaObracuna As String
            Dim mizlaz As String

            If Microsoft.VisualBasic.Trim(bUgovor) <> "" Then
                NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)
            End If

            IzmenaTLUI()

            ''mManipulativnoMesto = spKomanda.Parameters("@outMM").Value

            Dim mm_Stanica1, mm_Stanica2 As String


            NadjiManipulativnoMesto(bRecID, mm_Stanica1, mm_Stanica2, bRetVal)


        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub NadjiTovarniListGranica(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                                       ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef bPrUprava As String, ByRef bPrStanica As String, ByRef bSaobracaj As String, _
                                       ByRef bZsUlPrelaz As String, ByRef bZsIzPrelaz As String, ByRef bNajava As String, _
                                       ByRef bSifraTarife As String, ByRef bUgovor As String, _
                                       ByRef bRetVal As String)

        bRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL2", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulazUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = bDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim exPrUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrUprava", SqlDbType.Char, 4))
        exPrUprava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrUprava").Value = bPrUprava

        Dim exPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        exPrStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = bPrStanica

        Dim exPrSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSaobracaj", SqlDbType.Char, 1))
        exPrSaobracaj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSaobracaj").Value = bSaobracaj

        Dim exZsUlPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outZsUlPrelaz", SqlDbType.Char, 5))
        exZsUlPrelaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outZsUlPrelaz").Value = bZsUlPrelaz

        Dim exZsIzPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outZsIzPrelaz", SqlDbType.Char, 5))
        exZsIzPrelaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outZsIzPrelaz").Value = bZsIzPrelaz

        Dim exNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNajava", SqlDbType.Char, 10))
        exNajava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNajava").Value = bNajava

        Dim exSifraTarife As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife", SqlDbType.Char, 2))
        exSifraTarife.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife").Value = bSifraTarife

        Dim exUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        exUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            bPrUprava = spKomanda.Parameters("@outPrUprava").Value

            '***
            'ovde inicijallizovati sve izlazne promenljive: 

            'mObrMesec = spKomanda.Parameters("@outObrMesec").Value
            'mObrGodina = spKomanda.Parameters("@outObrGodina").Value
            'mStanica1 = spKomanda.Parameters("@outStanica1").Value
            'mUlEtiketa = spKomanda.Parameters("@outUlEtiketa").Value
            'mDatumUlaza = spKomanda.Parameters("@outDatumUlaza").Value
            'mStanica2 = spKomanda.Parameters("@outStanica2").Value
            'mIzEtiketa = spKomanda.Parameters("@outIzEtiketa").Value
            'mDatumIzlaza = spKomanda.Parameters("@outDatumIzlaza").Value
            'mPrUprava = spKomanda.Parameters("@outPrUprava").Value

            bRecID = spKomanda.Parameters("@outRecID").Value
            UpdRecID = bRecID

            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdStanicaRecID = bStanicaRecID

            bPrStanica = spKomanda.Parameters("@outPrStanica").Value
            bSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
            bZsUlPrelaz = spKomanda.Parameters("@outZsUlPrelaz").Value
            bZsIzPrelaz = spKomanda.Parameters("@outZsIzPrelaz").Value

            'PostaviPrelaz(bZsUlPrelaz, bZsIzPrelaz)

            bNajava = spKomanda.Parameters("@outNajava").Value
            bSifraTarife = spKomanda.Parameters("@outSifraTarife").Value
            bUgovor = spKomanda.Parameters("@outUgovor").Value

            'popunjava 3 grida
            Dim ug_mNazivKomitenta As String
            Dim ug_mPrimalac As String
            Dim ug_mVrstaObracuna As String
            Dim mizlaz As String

            NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)

            '---------------- popunjava 3 grida -----------------
            IzmenaTLGranica()
            '----------------------------------------------------------

            'mPrispece = spKomanda.Parameters("@outPrispece").Value
            'mPrDatum = spKomanda.Parameters("@outPrDatum").Value
            'mBrojVoza = spKomanda.Parameters("@outBrojVoza").Value
            'mSatVoza = spKomanda.Parameters("@outSatVoza").Value
            'mNajava = spKomanda.Parameters("@outNajava").Value
            'mNajavaKola = spKomanda.Parameters("@outNajavaKola").Value
            'mTarifa = spKomanda.Parameters("@outTarifa").Value

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub


    Public Sub sNadjiNaziv(ByVal ipTabela As String, ByVal ipSifra1 As String, ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                           ByRef opCount As Int16, ByRef opNaziv As String, _
                           ByRef opPovVrednost As String)


        'ipTabela=Tabela koja se koristi
        'ipSifra1=Sifra1 iz te tabele
        'ipSifra2=Sifra2 iz te tabele(ako je ima)
        'ipSifra3=Sifra3 iz te tabele(ako je ima)
        'broj neuspesnih pokusaja
        'opNaziv=povratna vrednost naziva
        'opPovVrednost=povratna vrednost 

        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True

        Select Case ipTabela
            Case "UicUprave"
                sqlText = "SELECT Oznaka FROM UicUprave WHERE SifraUprave = '" & ipSifra1 & "'"
            Case "NazivTabele"
                sqlText = "SELECT SifTab FROM SifTabCen WHERE Ugovor = '" & ipSifra1 & "'"
            Case "UicOperateri"
                '''sqlText = "SELECT Oznaka FROM UicOperateri WHERE Operater = '" & ipSifra1 & "' AND SifraUprave = '" & ipSifra2 & "'"
                sqlText = "SELECT SifraUprave + Oznaka  FROM UicOperateri WHERE SifraOperatera = '" & ipSifra1 & "'"
            Case "UicOperater"
                sqlText = "SELECT Oznaka FROM UicOperateri WHERE SifraOperatera = '" & ipSifra2 & "'"
            Case "UicStanice"
                sqlText = "SELECT Naziv FROM UicStanice WHERE SifraStanice = '" & ipSifra1 & "'"
            Case "UicPrelaz"
                sqlText = "SELECT Naziv FROM UicPrelazi WHERE Uprava1 = '" & ipSifra1 & "' AND Uprava2 = '" & ipSifra3 & "' AND SifraPrelaza = '" & ipSifra2 & "'"
                'sqlText = "SELECT Naziv FROM UicPrelazi WHERE Uprava1 = '" & ipSifra1 & "' AND SifraPrelaza = '" & ipSifra2 & "'"
            Case "UicPrelaziDist"
                sqlText = "SELECT Prelaz FROM UicPrelaziDist WHERE Uprava1 = '" & ipSifra1 & "' AND Uprava2 = '" & ipSifra2 & "'"
            Case "ZsStanice"
                sqlText = "SELECT SifraStanice, Naziv FROM ZsStanice WHERE NadzornaStanicaSifra  = '" & ipSifra1 & "'"
            Case "NHMPozicije"
                sqlText = "SELECT Naziv FROM NHMPozicije WHERE NHMPozicije.NHMSifra = '" & ipSifra1 & "'"
            Case "Tarife"
                sqlText = "SELECT Naziv WHERE Oznaka = '" & ipSifra1 & "'"
            Case "TabNaziv"
                sqlText = "SELECT SifTab FROM TabNaziv WHERE Ugovor = '" & ipSifra1 & "'"
            Case "UserTab"
                sqlText = "SELECT UserID, Lozinka, Stanica FROM UserTab WHERE UserID = '" & ipSifra1 & "' AND Lozinka = '" & ipSifra2 & "' AND Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "'"
            Case "Ugovori"
                sqlText = " SELECT  dbo.Komitent.Naziv, dbo.Komitent.Mesto " _
                        & " FROM    dbo.Cena_UgovorKP INNER JOIN " _
                        & " dbo.Ugovori ON dbo.Cena_UgovorKP.BrojUgovora = dbo.Ugovori.BrojUgovora INNER JOIN " _
                        & " dbo.Komitent ON dbo.Ugovori.SifraKorisnika = dbo.Komitent.Sifra " _
                        & " WHERE dbo.Ugovori.BrojUgovora = '" & ipSifra1 & "'"
            Case "Komitent"
                sqlText = "SELECT Naziv From Komitent WHERE Sifra = '" & ipSifra1 & "'"
            Case "UNalepnica"
                sqlText = "SELECT UlEtiketa From dbo.SlogKalk WHERE UlEtiketa = '" & ipSifra1 & "' AND ZsUlPrelaz = '" & ipSifra2 & "'"
            Case "TaraKola"
                sqlText = "SELECT Tara From dbo.IBK Where IBK = '" & ipSifra1 & "'"
            Case Else
                opPovVrednost = "Data Table: " & ipTabela & " - NE POSTOJI !!! , Greska u Programu"
        End Select

        If opPovVrednost = "" Then
            Dim uspKomanda As New SqlClient.SqlCommand(sqlText, DbVeza)
            Try
                If DbVeza.State = ConnectionState.Closed Then
                    DbVeza.Open()
                Else
                    closeConn = False
                End If
                opNaziv = uspKomanda.ExecuteScalar()
                If opNaziv = Nothing Then opPovVrednost = "Ne postoji takav podatak!" ' SLOG NE POSTOJI !!!
            Catch SQLExp As SqlException
                opPovVrednost = SQLExp.Message & "??"  'Greska - SQL greska
            Catch Exp As Exception
                opPovVrednost = Err.Description & " ?"  'Greska - bilo koja"
            Finally
                If closeConn Then DbVeza.Close()
                uspKomanda.Dispose()
            End Try
        End If
    End Sub
    Public Sub sNadjiStanicu(ByVal ipTabela As String, ByVal ipSifra1 As String, ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                             ByRef opCount As Int16, ByRef opNaziv As String, ByRef opKB As String, _
                             ByRef opPovVrednost As String)


        'ipTabela=Tabela koja se koristi
        'ipSifra1=Sifra1 iz te tabele
        'ipSifra2=Sifra2 iz te tabele(ako je ima)
        'ipSifra3=Sifra3 iz te tabele(ako je ima)
        'broj neuspesnih pokusaja
        'opNaziv=povratna vrednost naziva
        'opPovVrednost=povratna vrednost 

        opNaziv = ""
        opKB = ""
        opPovVrednost = "Ne postoji takav podatak!"

        Dim closeConn As Boolean = True


        '-------------------- naziv i KB
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim sqltext As String = "SELECT Naziv, KB FROM UicStanice " & _
                                "WHERE (SifraStanice = '" & ipSifra1 & "')"

        Dim sql_comm1 As New SqlClient.SqlCommand(sqltext, DbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrRm.Read()
            opNaziv = rdrRm.GetString(0)
            opKB = rdrRm.GetString(1)
            opPovVrednost = ""
        Loop
        rdrRm.Close()
        '-------------------- naziv i KB end


        ''If opPovVrednost = "" Then
        ''    Dim uspKomanda As New SqlClient.SqlCommand(sqlText, DbVeza)
        ''    Try
        ''        If DbVeza.State = ConnectionState.Closed Then
        ''            DbVeza.Open()
        ''        Else
        ''            closeConn = False
        ''        End If
        ''        opNaziv = uspKomanda.ExecuteScalar()
        ''        If opNaziv = Nothing Then opPovVrednost = "Ne postoji takav podatak!" ' SLOG NE POSTOJI !!!
        ''    Catch SQLExp As SqlException
        ''        opPovVrednost = SQLExp.Message & "??"  'Greska - SQL greska
        ''    Catch Exp As Exception
        ''        opPovVrednost = Err.Description & " ?"  'Greska - bilo koja"
        ''    Finally
        ''        If closeConn Then DbVeza.Close()
        ''        uspKomanda.Dispose()
        ''    End Try
        ''End If
    End Sub

    Public Sub Lozinka(ByVal ipSifra1 As String, ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                       ByRef opCount As Int16, ByRef opNaziv As String, _
                       ByRef opPovVrednost As String)


        'ipTabela=Tabela koja se koristi
        'ipSifra1=Sifra1 iz te tabele
        'ipSifra2=Sifra2 iz te tabele(ako je ima)
        'ipSifra3=Sifra3 iz te tabele(ako je ima)
        'broj neuspesnih pokusaja
        'opNaziv=povratna vrednost naziva
        'opPovVrednost=povratna vrednost 

        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True

        sqlText = "SELECT UserID, Lozinka, Stanica FROM UserTab WHERE UserID = '" & ipSifra1 & "' AND Lozinka = '" & ipSifra2 & "' AND Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "'"

        If opPovVrednost = "" Then
            Dim uspKomanda As New SqlClient.SqlCommand(sqlText, OkpDbVeza)
            Try
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                Else
                    closeConn = False
                End If
                opNaziv = uspKomanda.ExecuteScalar()
                If opNaziv = Nothing Then opPovVrednost = "Ne postoji takav podatak!" ' SLOG NE POSTOJI !!!
            Catch SQLExp As SqlException
                opPovVrednost = SQLExp.Message & "??"  'Greska - SQL greska
            Catch Exp As Exception
                opPovVrednost = Err.Description & " ?"  'Greska - bilo koja"
            Finally
                If closeConn Then OkpDbVeza.Close()
                uspKomanda.Dispose()
            End Try
        End If
    End Sub
    Public Sub sNadjiNalepnicu(ByVal ipSifra1 As Int32, ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                               ByVal ipSifra4 As String, ByRef opNaziv As String, _
                               ByRef opPovVrednost As String)

        'opNaziv=povratna vrednost naziva
        'opPovVrednost=povratna vrednost 

        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True

        sqlText = "SELECT UlEtiketa From dbo.SlogKalk " _
                & "WHERE UlEtiketa = " & ipSifra1 _
                & " AND ZsUlPrelaz = '" & ipSifra2 & "'" _
                & " AND ObrGodina = '" & ipSifra3 & "'" _
                & " AND ObrMesec = '" & ipSifra4 & "'"

        If opPovVrednost = "" Then
            Dim uspKomanda As New SqlClient.SqlCommand(sqlText, OkpDbVeza)
            Try
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                Else
                    closeConn = False
                End If
                opNaziv = uspKomanda.ExecuteScalar()
                If opNaziv = Nothing Then opPovVrednost = "Ne postoji takav podatak!" ' SLOG NE POSTOJI !!!
            Catch SQLExp As SqlException
                opPovVrednost = SQLExp.Message & "??"  'Greska - SQL greska
            Catch Exp As Exception
                opPovVrednost = Err.Description & " ?"  'Greska - bilo koja"
            Finally
                If closeConn Then OkpDbVeza.Close()
                uspKomanda.Dispose()
            End Try
        End If
    End Sub
    Public Sub PostaviPrelaz(ByVal bZsUlPrelaz As String, ByVal bZsIzPrelaz As String)
        Select Case bZsUlPrelaz
            Case "23499"
                mStanica1 = "1 - 23499 Subotica"
            Case "22899"
                mStanica1 = "2 - 22899 Kikinda"
            Case "21099"
                mStanica1 = "3 - 21099 Vrsac"
            Case "12498"
                mStanica1 = "4 - 12498 Dimitrovgrad"
            Case "11028"
                mStanica1 = "5 - 11028 Presevo"
            Case "15723"
                mStanica1 = "6 - 15723 Prijepolje Teretna"
            Case "16319"
                mStanica1 = "7 - 16319 Brasina"
            Case "16517"
                mStanica1 = "8 - 16517 Sid"
            Case "16201"
                mStanica1 = "9 - 16201 Beograd Ranzirna"
            Case "25471"
                mStanica1 = "10- 25471 Bogojevo"
        End Select
        Select Case bZsIzPrelaz
            Case "23499"
                mStanica2 = "1 - 23499 Subotica"
            Case "22899"
                mStanica2 = "2 - 22899 Kikinda"
            Case "21099"
                mStanica2 = "3 - 21099 Vrsac"
            Case "12498"
                mStanica2 = "4 - 12498 Dimitrovgrad"
            Case "11028"
                mStanica2 = "5 - 11028 Presevo"
            Case "15723"
                mStanica2 = "6 - 15723 Prijepolje Teretna"
            Case "16319"
                mStanica2 = "7 - 16319 Brasina"
            Case "16517"
                mStanica2 = "8 - 16517 Sid"
            Case "16201"
                mStanica2 = "9 - 16201 Beograd Ranzirna"
            Case "25471"
                mStanica2 = "10- 25471 Bogojevo"
        End Select
    End Sub
    Public Sub IzmenaTL()

        Dim mStavkaKola
        Dim IBK
        Dim ii1 As Int32 = 0
        Dim ii2 As Int32 = 0

        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        dsSlogKola.Clear()
        dsSlogNHM.Clear()

        Try
            '-------------------------------------- popunjava Grid Kola ---------------------------------------------------
            Dim adSlogKola As New SqlDataAdapter(" SELECT dbo.SlogKola.KolaStavka, dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogKola.Uprava, dbo.SlogKola.Vlasnik, dbo.SlogKola.Serija, dbo.SlogKola.Osovine, " _
                                & " dbo.SlogKola.GranTov, dbo.SlogKola.Stitna, dbo.SlogKola.TipKola, dbo.SlogKola.Naknada, dbo.SlogKola.Kontrola,  " _
                                & " dbo.SlogKalk.UkupnoKola, dbo.SlogRoba.NHM, dbo.SlogRoba.NHMRazred, dbo.SlogRoba.SMasa, dbo.SlogRoba.RMasa, dbo.SlogRoba.RID,   " _
                                & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav, dbo.SlogRoba.UtiNHM  " _
                                & " FROM dbo.SlogKola INNER JOIN  " _
                                & " dbo.SlogKalk ON dbo.SlogKola.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogKola.OtpStanica = dbo.SlogKalk.OtpStanica AND   " _
                                & " dbo.SlogKola.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogKola.OtpDatum = dbo.SlogKalk.OtpDatum INNER JOIN  " _
                                & " dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND   " _
                                & " dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka  " _
                                & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

            ii1 = adSlogKola.Fill(dsSlogKola)

            For k As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                mStavkaKola = dsSlogKola.Tables(0).Rows(k).Item(0)
                IBK = dsSlogKola.Tables(0).Rows(k).Item(1)


                Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & IBK & "'")
                If dtRow.Length > 0 Then
                    'Kola su vec upisana!
                Else
                    Dim drKola As DataRow = dtKola.NewRow

                    ''drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(4), "O", _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(5), dsSlogKola.Tables(0).Rows(k).Item(6), dsSlogKola.Tables(0).Rows(k).Item(7), dsSlogKola.Tables(0).Rows(k).Item(8), _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(9), 0, dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), dsSlogKola.Tables(0).Rows(k).Item(19), "U"}

                    drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(6), _
                                         dsSlogKola.Tables(0).Rows(k).Item(4), dsSlogKola.Tables(0).Rows(k).Item(5), _
                                         "O", dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(7), _
                                         dsSlogKola.Tables(0).Rows(k).Item(8), dsSlogKola.Tables(0).Rows(k).Item(9), 0, _
                                         dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), _
                                         dsSlogKola.Tables(0).Rows(k).Item(19), "U"}
                    dtKola.Rows.Add(drKola)
                End If
            Next

            Dim KolaRed As DataRow
            For Each KolaRed In dtKola.Rows
                mIBK = KolaRed.Item("IndBrojKola")
                _mTara = KolaRed.Item("Tara")
            Next
            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------
            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                Dim drNHM As DataRow = dtNhm.NewRow

                ''drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), _
                ''                                  dsSlogKola.Tables(0).Rows(jj).Item(15), _
                ''                                  dsSlogKola.Tables(0).Rows(jj).Item(18), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                ''                                  "", dsSlogKola.Tables(0).Rows(jj).Item(14), 0, 0, "", "", "", "U", _
                ''                                  dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20)}
                'ako je dbnull!!
                'If IsDBNull(spKomanda.Parameters("@outStanica1").Value) Then
                '    mManipulativnoMesto = ""
                'Else
                '    mManipulativnoMesto = spKomanda.Parameters("@outStanica1").Value
                '    MM_Count = 0
                'End If

                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(21), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(18), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                  "", 0, 0, "", "", "U", _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20)}

                dtNhm.Rows.Add(drNHM)
            Next
            Dim KolaNhm As DataRow
            For Each KolaNhm In dtNhm.Rows
                _mNHM = KolaNhm.Item("NHM")
                _mSMasa = KolaNhm.Item("Masa")
                _mTipUti = KolaNhm.Item("UTI")
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        '-------------------------------------- popunjava Grid Naknade ---------------------------------------------------
        dsSlogNak.Clear()

        Try
            Dim adSlogNak As New SqlDataAdapter(" SELECT dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, dbo.SlogNaknada.Iznos, dbo.SlogNaknada.Valuta, dbo.SlogNaknada.Kolicina, " _
                                              & " dbo.SlogNaknada.DanCas, dbo.SlogNaknada.Placanje, dbo.SlogNaknada.Vrsta " _
                                              & " FROM dbo.SlogNaknada INNER JOIN " _
                                              & " dbo.SlogKalk ON dbo.SlogNaknada.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogNaknada.OtpStanica = dbo.SlogKalk.OtpStanica AND " _
                                              & " dbo.SlogNaknada.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogNaknada.OtpDatum = dbo.SlogKalk.OtpDatum " _
                                              & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

            ii2 = adSlogNak.Fill(dsSlogNak)

            For k As Int16 = 0 To dsSlogNak.Tables(0).Rows.Count - 1
                Dim drNaknade As DataRow = dtNaknade.NewRow
                drNaknade.ItemArray() = New Object() {dsSlogNak.Tables(0).Rows(k).Item(0), dsSlogNak.Tables(0).Rows(k).Item(1), dsSlogNak.Tables(0).Rows(k).Item(2), _
                                                      dsSlogNak.Tables(0).Rows(k).Item(3), dsSlogNak.Tables(0).Rows(k).Item(4), dsSlogNak.Tables(0).Rows(k).Item(5), _
                                                      dsSlogNak.Tables(0).Rows(k).Item(6), dsSlogNak.Tables(0).Rows(k).Item(7), "U"}
                dtNaknade.Rows.Add(drNaknade)
            Next

        Catch sqlex As SqlException

            Dim aa As String
            aa = sqlex.Message

        End Try

    End Sub
    Public Sub IzmenaTLGranica()

        Dim mStavkaKola
        Dim IBK
        Dim ii1 As Int32 = 0
        Dim ii2 As Int32 = 0
        Dim tmp_VrstaKola = "O"

        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        dsSlogKola.Clear()
        dsSlogNHM.Clear()

        Try
            '-------------------------------------- popunjava Grid Kola ---------------------------------------------------
            Dim adSlogKola As New SqlDataAdapter(" SELECT dbo.SlogKola.KolaStavka, dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogKola.Uprava, dbo.SlogKola.Vlasnik, dbo.SlogKola.Serija, dbo.SlogKola.Osovine, " _
                                       & " dbo.SlogKola.GranTov, dbo.SlogKola.Stitna, dbo.SlogKola.TipKola, dbo.SlogKola.Naknada, dbo.SlogKola.Kontrola,  " _
                                       & " dbo.SlogKalk.UkupnoKola, dbo.SlogRoba.NHM, dbo.SlogRoba.NHMRazred, dbo.SlogRoba.SMasa, dbo.SlogRoba.RMasa, dbo.SlogRoba.RID,   " _
                                       & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav, dbo.SlogRoba.UtiNHM  " _
                                       & " FROM dbo.SlogKola INNER JOIN  " _
                                       & " dbo.SlogKalk ON dbo.SlogKola.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogKola.OtpStanica = dbo.SlogKalk.OtpStanica AND   " _
                                       & " dbo.SlogKola.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogKola.OtpDatum = dbo.SlogKalk.OtpDatum INNER JOIN  " _
                                       & " dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND   " _
                                       & " dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka  " _
                                       & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", DbVeza)

            ii1 = adSlogKola.Fill(dsSlogKola)

            For k As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                mStavkaKola = dsSlogKola.Tables(0).Rows(k).Item(0)
                IBK = dsSlogKola.Tables(0).Rows(k).Item(1)

                If Microsoft.VisualBasic.Mid(dsSlogKola.Tables(0).Rows(k).Item(13), 1, 4) <> "9921" And _
                    Microsoft.VisualBasic.Mid(dsSlogKola.Tables(0).Rows(k).Item(13), 1, 4) <> "9922" And _
                    Microsoft.VisualBasic.Mid(dsSlogKola.Tables(0).Rows(k).Item(13), 1, 4) <> "9931" Then

                    tempNhm8216 = "T"
                Else
                    tempNhm8216 = "P"
                End If

                Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & IBK & "'")
                If dtRow.Length > 0 Then
                    'Kola su vec upisana!
                Else

                    Dim drKola As DataRow = dtKola.NewRow

                    Dim mNaknadaZaZelKola As Int32 = 0

                    'Naknada za koriscenje zeleznickih kola: IC, Adriacombi,Eurolog
                    'dsSlogKola.Tables(0).Rows(k).Item(10)

                    If Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "03" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "04" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "05" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "06" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "13" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "14" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "15" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "16" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "23" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "24" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "25" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "26" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "27" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "29" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "33" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "34" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "35" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "36" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "37" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "39" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "43" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "44" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "45" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "46" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "47" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "48" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "49" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "83" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "84" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "85" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "86" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "87" Or _
                       Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "88" Or Left(dsSlogKola.Tables(0).Rows(k).Item(1), 2) = "89" Then

                        If IzborSaobracaja = "4" Then
                            If mBrojUg = "101001" Then
                                mNaknadaZaZelKola = -60
                            ElseIf mBrojUg = "101096" Then
                                mNaknadaZaZelKola = -60
                            ElseIf mBrojUg = "101101" Then
                                mNaknadaZaZelKola = -60
                            ElseIf mBrojUg = "101196" Then
                                mNaknadaZaZelKola = -60
                            ElseIf mBrojUg = "101201" Then
                                mNaknadaZaZelKola = -60
                            ElseIf mBrojUg = "101296" Then
                                mNaknadaZaZelKola = -60
                            ElseIf mBrojUg = "101301" Then
                                mNaknadaZaZelKola = -60
                            ElseIf mBrojUg = "101396" Then
                                mNaknadaZaZelKola = -60
                            Else
                                mNaknadaZaZelKola = 0
                            End If
                        Else
                            mNaknadaZaZelKola = 0
                        End If

                    Else ' Naknada za zeleznicka kola
                        If mBrojUg = "835745" Then      'Adriacombi
                            mNaknadaZaZelKola = 40
                        ElseIf mBrojUg = "835753" Or mBrojUg = "835758" Or mBrojUg = "844517" Or mBrojUg = "955401" Then 'Adriacombi
                            mNaknadaZaZelKola = 36
                        ElseIf mBrojUg = "836902" Then  'Eurolog
                            If dsSlogKola.Tables(0).Rows(k).Item(6) > 4 Then
                                mNaknadaZaZelKola = 52
                            Else
                                mNaknadaZaZelKola = 26
                            End If
                        ElseIf (mBrojUg = "100822" Or mBrojUg = "110822" Or mBrojUg = "120822") Then  'Proodos kont.voz
                            If mStanica1 = "11028" Or mStanica2 = "11028" Then
                                mNaknadaZaZelKola = 36
                            End If
                            If mStanica1 = "12498" Or mStanica2 = "12498" Then
                                mNaknadaZaZelKola = 39
                            End If
                        ElseIf (mBrojUg = "101133" Or mBrojUg = "111122" Or mBrojUg = "121122" Or mBrojUg = "101233" Or mBrojUg = "111222" Or mBrojUg = "121222") Then  'Proodos kont.voz
                            If mStanica1 = "11028" Or mStanica2 = "11028" Then
                                mNaknadaZaZelKola = 36
                            End If
                            If mStanica1 = "12498" Or mStanica2 = "12498" Then
                                mNaknadaZaZelKola = 39
                            End If
                        ElseIf (mBrojUg = "101333" Or mBrojUg = "111322" Or mBrojUg = "121322" Or mBrojUg = "101333" Or mBrojUg = "111322" Or mBrojUg = "121322") Then  'Proodos kont.voz
                            If mStanica1 = "11028" Or mStanica2 = "11028" Then
                                mNaknadaZaZelKola = 39
                            End If
                            If mStanica1 = "12498" Or mStanica2 = "12498" Then
                                mNaknadaZaZelKola = 42
                            End If
                        ElseIf mBrojUg = "993353" Or mBrojUg = "993354" Then 'Intercontainer
                            If Microsoft.VisualBasic.Mid(IBK, 3, 2) = "81" Then
                                mNaknadaZaZelKola = 0
                            Else
                                mNaknadaZaZelKola = 36
                            End If
                        End If
                    End If

                    '-----------------izmena 27.4.2010

                    If dsSlogKola.Tables(0).Rows(k).Item(9) = 2 Then
                        tmp_VrstaKola = "S"
                    Else
                        tmp_VrstaKola = "O"
                    End If

                    drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(6), _
                                                       dsSlogKola.Tables(0).Rows(k).Item(4), dsSlogKola.Tables(0).Rows(k).Item(5), _
                                                       tmp_VrstaKola, dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(7), _
                                                       dsSlogKola.Tables(0).Rows(k).Item(8), dsSlogKola.Tables(0).Rows(k).Item(9), 0, _
                                                       mNaknadaZaZelKola, dsSlogKola.Tables(0).Rows(k).Item(11), _
                                                       dsSlogKola.Tables(0).Rows(k).Item(19), "U"}

                    '-----------------stara verzija
                    'drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(6), _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(4), dsSlogKola.Tables(0).Rows(k).Item(5), _
                    '                                   "O", dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(7), _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(8), dsSlogKola.Tables(0).Rows(k).Item(9), 0, _
                    '                                   mNaknadaZaZelKola, dsSlogKola.Tables(0).Rows(k).Item(11), _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(19), "U"}

                    dtKola.Rows.Add(drKola)
                End If
            Next

            'Kontrola postojanja podatka o tari kola
            mNemaTare = "0"
            Dim KolaRed As DataRow

            Dim xNaziv As String = "0"
            Dim xPovVrednost As String = ""

            For Each KolaRed In dtKola.Rows
                mIBK = KolaRed.Item("IndBrojKola")
                If KolaRed.Item("Tara") = 0 Then
                    '------------------------- preuzeti taru iz dbo.IBK! -----------------------
                    Util.sNadjiNaziv("TaraKola", mIBK, "", "", 1, xNaziv, xPovVrednost)
                    If CType(xNaziv, Int32) = 0 Then
                        mNemaTare = "1"
                        _mTara = "0"
                    Else
                        KolaRed.Item("Tara") = CType(xNaziv, Int32)
                        mNemaTare = "0"
                        _mTara = xNaziv
                    End If
                    '---------------------------------------------------------------------------------
                End If
            Next

            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------
            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1
                Dim drNHM As DataRow = dtNhm.NewRow
                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(21), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(18), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                  "", 0, 0, "", "", "U", _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20)}
                dtNhm.Rows.Add(drNHM)
            Next


            Dim KolaNhm As DataRow
            For Each KolaNhm In dtNhm.Rows
                _mNHM = KolaNhm.Item("NHM")
                _mSMasa = KolaNhm.Item("Masa")
                _mTipUti = KolaNhm.Item("UTI")
            Next


        Catch ex As Exception
            MsgBox(ex)
        End Try

        '-------------------------------------- popunjava Grid Naknade ---------------------------------------------------
        dsSlogNak.Clear()

        Try
            Dim adSlogNak As New SqlDataAdapter(" SELECT dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, dbo.SlogNaknada.Iznos, dbo.SlogNaknada.Valuta, dbo.SlogNaknada.Kolicina, " _
                                              & " dbo.SlogNaknada.DanCas, dbo.SlogNaknada.Placanje, dbo.SlogNaknada.Vrsta " _
                                              & " FROM dbo.SlogNaknada INNER JOIN " _
                                              & " dbo.SlogKalk ON dbo.SlogNaknada.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogNaknada.OtpStanica = dbo.SlogKalk.OtpStanica AND " _
                                              & " dbo.SlogNaknada.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogNaknada.OtpDatum = dbo.SlogKalk.OtpDatum " _
                                              & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", DbVeza)

            ii2 = adSlogNak.Fill(dsSlogNak)

            For k As Int16 = 0 To dsSlogNak.Tables(0).Rows.Count - 1
                Dim drNaknade As DataRow = dtNaknade.NewRow
                drNaknade.ItemArray() = New Object() {dsSlogNak.Tables(0).Rows(k).Item(0), dsSlogNak.Tables(0).Rows(k).Item(1), dsSlogNak.Tables(0).Rows(k).Item(2), _
                                                      "17", dsSlogNak.Tables(0).Rows(k).Item(4), dsSlogNak.Tables(0).Rows(k).Item(5), _
                                                      dsSlogNak.Tables(0).Rows(k).Item(6), dsSlogNak.Tables(0).Rows(k).Item(7), "I"}
                'dsSlogNak.Tables(0).Rows(k).Item(3)="17"
                dtNaknade.Rows.Add(drNaknade)

                'fito, veterinarski i radioloski pregled za ug. 100901, èl.12: ako je naplacen pregled, dodaje se i 9.5 eura
                If (dsSlogNak.Tables(0).Rows(k).Item(0) = "45" And dsSlogNak.Tables(0).Rows(k).Item(1) = "01") And _
                    (dsSlogNak.Tables(0).Rows(k).Item(2) = 15 Or dsSlogNak.Tables(0).Rows(k).Item(2) = 12) Then

                    Dim drNaknadeFito As DataRow = dtNaknade.NewRow
                    drNaknadeFito.ItemArray() = New Object() {dsSlogNak.Tables(0).Rows(k).Item(0), dsSlogNak.Tables(0).Rows(k).Item(1), 9.5, _
                                                          "17", dsSlogNak.Tables(0).Rows(k).Item(4), dsSlogNak.Tables(0).Rows(k).Item(5), _
                                                          dsSlogNak.Tables(0).Rows(k).Item(6), dsSlogNak.Tables(0).Rows(k).Item(7), "I"}
                    'dsSlogNak.Tables(0).Rows(k).Item(3)="17"
                    dtNaknade.Rows.Add(drNaknadeFito)
                End If
            Next

            '-- Novo 21/09/2013 : ukljucivanje tabele IKP ------------------------------------------------------------------------------------
            Dim KolaRed As DataRow
            For Each KolaRed In dtKola.Rows
                mIBK = KolaRed.Item("IndBrojKola")

                Dim rv As String = ""
                Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & mIBK & "'")
                'Dim nmNasaoIKP As Boolean = False
                Dim rv1 As String = ""

                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                End If

                Dim uspKomanda1 As New SqlClient.SqlCommand("nmNadjiIBK", OkpDbVeza)
                uspKomanda1.CommandType = CommandType.StoredProcedure

                Dim upIBK1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
                upIBK1.Direction = ParameterDirection.Input
                uspKomanda1.Parameters("@inIBK").Value = mIBK

                Dim ipSkrUprava1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outUprava", SqlDbType.Char, 6))
                ipSkrUprava1.Direction = ParameterDirection.Output

                Dim ipTara1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outTara", SqlDbType.Int))
                ipTara1.Direction = ParameterDirection.Output

                Dim ipSerija1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outSerija", SqlDbType.Char, 11))
                ipSerija1.Direction = ParameterDirection.Output

                Dim ipBrojOsovina1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outOsovine", SqlDbType.Int))
                ipBrojOsovina1.Direction = ParameterDirection.Output

                Dim ipVlasnistvo1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVlasnik", SqlDbType.Char, 1))
                ipVlasnistvo1.Direction = ParameterDirection.Output

                Dim ipVrsta1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
                ipVrsta1.Direction = ParameterDirection.Output

                Dim ipPovratnaVrednost1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
                ipPovratnaVrednost1.Direction = ParameterDirection.Output

                Try
                    uspKomanda1.ExecuteScalar()
                    If IsDBNull(uspKomanda1.Parameters("@outUprava").Value) Then

                    Else
                        KolaRed.Item("Uprava") = uspKomanda1.Parameters("@outUprava").Value
                        KolaRed.Item("Tara") = uspKomanda1.Parameters("@outTara").Value
                        KolaRed.Item("Serija") = uspKomanda1.Parameters("@outSerija").Value
                        KolaRed.Item("Osovine") = uspKomanda1.Parameters("@outOsovine").Value
                        KolaRed.Item("Vlasnik") = uspKomanda1.Parameters("@outVlasnik").Value
                        If uspKomanda1.Parameters("@outVrsta").Value = "1" Then
                            KolaRed.Item("Vrsta") = "O"
                        Else
                            KolaRed.Item("Vrsta") = "S"
                        End If
                        '------- dodeljuje KB = D, jer dolazi iz IKP
                        KolaRed.Item("KB") = "D"
                        KolaRed.Item("ICF") = "N"
                    End If

                Catch Exp As Exception
                    'nmNasaoIKP = False
                Finally
                    OkpDbVeza.Close()
                    uspKomanda1.Dispose()
                End Try
                '--end novo ---------------------------------------------------------------------------------------------------------------------

            Next

        Catch sqlex As SqlException

            'Dim aa As String
            'aa = sqlex.Message

        End Try

    End Sub
    Public Sub BrisiTL(ByVal _RecID As Int32, ByVal _Stanica As String, _
                       ByRef _mRetVal As Int32)

        _mRetVal = 0
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.spBrisanjeTL", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ippRecID", SqlDbType.Int, 4))
        inRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ippRecID").Value = _RecID

        Dim inStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ippStanica", SqlDbType.Char, 5))
        inStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ippStanica").Value = _Stanica

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@RetVal", SqlDbType.Int, 4))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@RetVal").Value = _mRetVal

        Try
            spKomanda.ExecuteScalar()
            _mRetVal = spKomanda.Parameters("@RetVal").Value

            'If _mRetVal > 0 Then
            '    MsgBox("Obrisao")
            'End If

        Catch ex As Exception
            _mRetVal = Err.Description & " Greska u programu!"
        Catch sqlexp As Exception
            _mRetVal = sqlexp.Message & " SQL greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub NadjiTLTrz(ByVal exStanica As String, ByVal exNalepnica As Int32, _
                          ByRef bRecID As Int32, ByRef bRetVal As String)

        bRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL1", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica").Value = exStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNalepnica", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNalepnica").Value = exNalepnica

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID
        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()
            bRecID = spKomanda.Parameters("@outRecID").Value
            If bRecID > 0 Then
                bRetVal = "Takav podatak vec postoji!"
            Else
                bRetVal = ""
            End If

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try


    End Sub
    Public Sub fordelete_NajavaPregled(ByVal _mBrojUg As String, ByVal _mNajava As String, _
                                       ByRef _KolaNajava As Int16, ByRef _KolaReal As Int16, _
                                       ByRef _BrutoMasa As Decimal, ByRef _NetoMasa As Decimal, ByVal _Tara As Decimal, _
                                       ByRef _rv As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'xx
        'Dodati proceduru:
        'trazi podatke u najava*
        'trazi podatke u slog*
        'prikaze na ekranu


        Dim sql_NajavaVoza As String = "SELECT SUM(DISTINCT dbo.NajavaVoza.SumaKola) AS suma, COUNT(dbo.NajavaVoza.Realizovano) AS [real], SUM(dbo.NajavaKola.BrutoMasa) AS Bruto, " & _
                                                          "SUM(dbo.NajavaKola.NetoMasa) AS Neto, SUM(dbo.NajavaKola.BrutoMasa - dbo.NajavaKola.NetoMasa) AS tara " & _
                                                          "FROM dbo.NajavaKola INNER JOIN " & _
                                                          "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                                                          "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                                                          "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
                                                          "GROUP BY dbo.NajavaKola.Realizovano " & _
                                                          "HAVING (dbo.NajavaKola.Realizovano = '1')"

        Dim sql_comm As New SqlClient.SqlCommand(sql_NajavaVoza, OkpDbVeza)
        Dim rdrNajavaVoza As SqlClient.SqlDataReader
        rdrNajavaVoza = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrNajavaVoza.Read()
            _KolaNajava = rdrNajavaVoza.GetInt16(0)
            _KolaReal = rdrNajavaVoza.GetInt16(1)
            _BrutoMasa = rdrNajavaVoza.GetDecimal(2)
            _NetoMasa = rdrNajavaVoza.GetDecimal(3)
            _Tara = rdrNajavaVoza.GetDecimal(4)
        Loop
        rdrNajavaVoza.Close()
        OkpDbVeza.Close()
    End Sub
    Public Sub NadjiTL1(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, _
                        ByVal bDatum As Date, ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                        ByRef bRetVal As String)

        bRetVal = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL1", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulazUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = bDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()
            bRecID = spKomanda.Parameters("@outRecID").Value
            If bRecID > 0 Then
                bRetVal = "Takav podatak vec postoji!"
            Else
                bRetVal = ""
            End If

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    'Public Sub NadjiDuplaOtp(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, _
    '                         ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef bRetVal As String)

    Public Sub NadjiDuplaOtp(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, _
                             ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef bObrGodina As String, ByRef bRetVal As String)

        bRetVal = ""
        OkpDbVeza.Close()

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomandaNew As New SqlClient.SqlCommand("dbo.NadjiDO2", OkpDbVeza)
        'Dim spKomandaNew As New SqlClient.SqlCommand("dbo.NadjiDO", OkpDbVeza)
        spKomandaNew.CommandType = CommandType.StoredProcedure

        Dim ulazUprava As SqlClient.SqlParameter = spKomandaNew.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulazUprava.Direction = ParameterDirection.Input
        spKomandaNew.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomandaNew.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomandaNew.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomandaNew.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomandaNew.Parameters("@inOtpBroj").Value = bOtpBroj

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomandaNew.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomandaNew.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomandaNew.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomandaNew.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim exObrGodina As SqlClient.SqlParameter = spKomandaNew.Parameters.Add(New SqlClient.SqlParameter("@outObrGodina", SqlDbType.Char, 4))
        exObrGodina.Direction = ParameterDirection.Output
        spKomandaNew.Parameters("@outObrGodina").Value = bObrGodina

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomandaNew.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomandaNew.Parameters("@outRetVal").Value = bRetVal

        Try
            'spKomandaNew.ExecuteScalar()
            Dim nmRetVal As String = ""

            spKomandaNew.ExecuteReader()

            bRecID = spKomandaNew.Parameters("@outRecID").Value
            bObrGodina = spKomandaNew.Parameters("@outObrGodina").Value
            bRetVal = spKomandaNew.Parameters("@outRetVal").Value

            'If bObrGodina <> "2015" Then
            '    nmRetVal = "Found"
            'Else
            '    nmRetVal = ""
            'End If

            ''If bRetVal = "NotFound" Then 'nema podatka u bazi
            ''    nmRetVal = nmRetVal & ""
            ''Else
            ''    nmRetVal = nmRetVal & "Found"
            ''End If

            'bRetVal = nmRetVal & bRetVal

            'bRecID = spKomandaNew.Parameters("@outRecID").Value
            'bObrGodina = spKomandaNew.Parameters("@outObrGodina").Value

            If bRecID > 0 Then
                bRetVal = "Takav podatak vec postoji!"
            Else
                bRetVal = ""
            End If

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomandaNew.Dispose()
        End Try

    End Sub

    Public Sub NadjiTovarniListTrz(ByVal inTipStanice As String, ByVal inStanica As String, ByVal inNalepnica As Int32, ByVal inObrGodina As String, ByVal inObrMesec As String, _
                                   ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef exObrM As String, _
                                   ByRef exOtpUprava As String, ByRef exOtpStanica As String, ByRef exOtpBroj As Int32, ByRef exOtpDatum As Date, _
                                   ByRef exPrUprava As String, ByRef exPrStanica As String, ByRef exPrDatum As Date, ByRef bSaobracaj As String, _
                                   ByRef bZsIzPrelaz As String, ByRef bZsIzNalepnica As Int32, ByRef bNajava As String, ByRef bNajava2 As String, _
                                   ByRef bSifraTarife As String, ByRef bUgovor As String, _
                                   ByRef bSumaIznos As Decimal, ByRef bPrevoznina As Decimal, ByRef bNaknade As Decimal, _
                                   ByRef bRetVal As String)

        bRetVal = ""
        bRecID = 0
        bStanicaRecID = "0"

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTLTrzNew", OkpDbVeza)
        'Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTLTrz", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulTip As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTipStanice", SqlDbType.Char, 1))
        ulTip.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTipStanice").Value = inTipStanice

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica").Value = inStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNalepnica", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNalepnica").Value = inNalepnica

        Dim ulObrGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4))
        ulObrGodina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inObrGodina").Value = inObrGodina

        Dim ulObrMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2))
        ulObrMesec.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inObrMesec").Value = inObrMesec


        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        izRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim izStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        izStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim izObrM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outObrM", SqlDbType.Char, 2))
        izObrM.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outObrM").Value = exObrM

        Dim izOtpUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpUprava", SqlDbType.Char, 4))
        izOtpUprava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpUprava").Value = exOtpUprava

        Dim izOtpStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpStanica", SqlDbType.Char, 7))
        izOtpStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpStanica").Value = exOtpStanica

        Dim izOtpBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpBroj", SqlDbType.Int))
        izOtpBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpBroj").Value = exOtpBroj

        Dim izOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpDatum", SqlDbType.DateTime))
        izOtpDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpDatum").Value = exOtpDatum

        Dim izPrUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrUprava", SqlDbType.Char, 4))
        izPrUprava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrUprava").Value = exPrUprava

        Dim izPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        izPrStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = exPrStanica

        Dim izPrDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrDatum", SqlDbType.DateTime))
        izPrDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrDatum").Value = exPrDatum

        Dim exPrSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSaobracaj", SqlDbType.Char, 1))
        exPrSaobracaj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSaobracaj").Value = bSaobracaj

        Dim exZsIzPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outZsPrelaz", SqlDbType.Char, 5))
        exZsIzPrelaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outZsPrelaz").Value = bZsIzPrelaz

        Dim izNalepnica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNalepnica", SqlDbType.Int))
        izNalepnica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNalepnica").Value = bZsIzNalepnica

        Dim izNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNajava", SqlDbType.Char, 10))
        izNajava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNajava").Value = bNajava

        Dim izNajava2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNajava2", SqlDbType.Char, 10))
        izNajava2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNajava2").Value = bNajava2

        Dim izSifraTarife As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife", SqlDbType.Char, 2))
        izSifraTarife.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife").Value = bSifraTarife

        Dim izUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        izUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor

        '---------------------------------------------------------------------------------------------------------
        Dim izTlSumaFr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTlSumaFr", SqlDbType.Money)) 'Decimal
        izTlSumaFr.Direction = ParameterDirection.Output
        izTlSumaFr.Size = 9 ''8 '9
        izTlSumaFr.Precision = 12 ''19 '18
        izTlSumaFr.Scale = 2

        Dim izTlPrevFr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTlPrevFr", SqlDbType.Money)) 'Decimal
        izTlPrevFr.Direction = ParameterDirection.Output
        izTlPrevFr.Size = 9 ''8 '9
        izTlPrevFr.Precision = 12 ''19 '18
        izTlPrevFr.Scale = 2

        Dim izTlNakFr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTlNakFr", SqlDbType.Money)) 'Decimal
        izTlNakFr.Direction = ParameterDirection.Output
        izTlNakFr.Size = 9 ''8 '9
        izTlNakFr.Precision = 12 ''19 '18
        izTlNakFr.Scale = 2

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            bRecID = spKomanda.Parameters("@outRecID").Value
            UpdRecID = bRecID
            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdStanicaRecID = bStanicaRecID

            '------------------------ inicijalizovanje izlaznih promenljivih ------------------------------
            If bRecID = 0 And bStanicaRecID = "Nista" Then
                bRetVal = "Ne postoji takav podatak!"
            Else
                exObrM = spKomanda.Parameters("@outObrM").Value
                exOtpUprava = spKomanda.Parameters("@outOtpUprava").Value
                exOtpStanica = spKomanda.Parameters("@outOtpStanica").Value
                exOtpBroj = spKomanda.Parameters("@outOtpBroj").Value
                exOtpDatum = spKomanda.Parameters("@outOtpDatum").Value
                exPrUprava = spKomanda.Parameters("@outPrUprava").Value
                exPrStanica = spKomanda.Parameters("@outPrStanica").Value
                exPrDatum = spKomanda.Parameters("@outPrDatum").Value
                bSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
                bZsIzPrelaz = spKomanda.Parameters("@outZsPrelaz").Value
                bZsIzNalepnica = spKomanda.Parameters("@outNalepnica").Value
                bNajava = spKomanda.Parameters("@outNajava").Value
                bNajava2 = spKomanda.Parameters("@outNajava2").Value
                bSifraTarife = spKomanda.Parameters("@outSifraTarife").Value
                bUgovor = spKomanda.Parameters("@outUgovor").Value

                mOtpUprava = spKomanda.Parameters("@outOtpUprava").Value
                mOtpStanica = spKomanda.Parameters("@outOtpStanica").Value
                mOtpBroj = spKomanda.Parameters("@outOtpBroj").Value
                mOtpDatum = spKomanda.Parameters("@outOtpDatum").Value
                mPrUprava = spKomanda.Parameters("@outPrUprava").Value
                mPrStanica = spKomanda.Parameters("@outPrStanica").Value
                mPrDatum = spKomanda.Parameters("@outPrDatum").Value
                bZsIzPrelaz = spKomanda.Parameters("@outZsPrelaz").Value
                bZsIzNalepnica = spKomanda.Parameters("@outNalepnica").Value
                mNajava = spKomanda.Parameters("@outNajava").Value
                mNajava2 = spKomanda.Parameters("@outNajava2").Value
                mTarifa = spKomanda.Parameters("@outSifraTarife").Value
                mBrojUg = spKomanda.Parameters("@outUgovor").Value
                mUlEtiketa = inNalepnica
                mIzEtiketa = bZsIzNalepnica

                mSumaIznos = spKomanda.Parameters("@outTlSumaFr").Value
                mPrevoznina = spKomanda.Parameters("@outTlPrevFr").Value
                mSumaNak = spKomanda.Parameters("@outTlNakFr").Value

                '------------------------------- popunjava 3 grida --------------------------------------------
                Dim ug_mNazivKomitenta As String
                Dim ug_mPrimalac As String
                Dim ug_mVrstaObracuna As String
                Dim mizlaz As String

                'NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)

                NadjiUgovor(mBrojUg, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)
                mNazivKomitenta = ug_mNazivKomitenta

                IzmenaTL()
            End If
            '----------------------------------------------------------------------------------------------------------

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Public Sub NadjiTovarniListTrzGranica(ByVal inTipStanice As String, ByVal inStanica As String, ByVal inNalepnica As Int32, ByVal inObrGodina As String, ByVal inObrMesec As String, _
                                              ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                                              ByRef exOtpUprava As String, ByRef exOtpStanica As String, ByRef exOtpBroj As Int32, ByRef exOtpDatum As Date, _
                                              ByRef exPrUprava As String, ByRef exPrStanica As String, ByRef exPrDatum As Date, ByRef bSaobracaj As String, _
                                              ByRef bZsIzPrelaz As String, ByRef bZsIzNalepnica As Int32, ByRef bNajava As String, _
                                              ByRef bSifraTarife As String, ByRef bUgovor As String, _
                                              ByRef bSumaIznos As Decimal, ByRef bPrevoznina As Decimal, ByRef bNaknade As Decimal, _
                                              ByRef bRetVal As String)

        bRetVal = ""
        bRecID = 0
        bStanicaRecID = "0"

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTLTrz", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulTip As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTipStanice", SqlDbType.Char, 1))
        ulTip.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTipStanice").Value = inTipStanice

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica").Value = inStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNalepnica", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNalepnica").Value = inNalepnica

        Dim ulObrGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4))
        ulObrGodina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inObrGodina").Value = inObrGodina

        Dim ulObrMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2))
        ulObrMesec.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inObrMesec").Value = inObrMesec


        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        izRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim izStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        izStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim izOtpUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpUprava", SqlDbType.Char, 4))
        izOtpUprava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpUprava").Value = exOtpUprava

        Dim izOtpStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpStanica", SqlDbType.Char, 7))
        izOtpStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpStanica").Value = exOtpStanica

        Dim izOtpBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpBroj", SqlDbType.Int))
        izOtpBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpBroj").Value = exOtpBroj

        Dim izOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpDatum", SqlDbType.DateTime))
        izOtpDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpDatum").Value = exOtpDatum

        Dim izPrUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrUprava", SqlDbType.Char, 4))
        izPrUprava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrUprava").Value = exPrUprava

        Dim izPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        izPrStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = exPrStanica

        Dim izPrDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrDatum", SqlDbType.DateTime))
        izPrDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrDatum").Value = exPrDatum

        Dim exPrSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSaobracaj", SqlDbType.Char, 1))
        exPrSaobracaj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSaobracaj").Value = bSaobracaj

        Dim exZsIzPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outZsPrelaz", SqlDbType.Char, 5))
        exZsIzPrelaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outZsPrelaz").Value = bZsIzPrelaz

        Dim izNalepnica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNalepnica", SqlDbType.Int))
        izNalepnica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNalepnica").Value = bZsIzNalepnica

        Dim izNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNajava", SqlDbType.Char, 10))
        izNajava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNajava").Value = bNajava
        '-----------
        ''Dim izNajava2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNajava2", SqlDbType.Char, 10))
        ''izNajava2.Direction = ParameterDirection.Output
        ''spKomanda.Parameters("@outNajava2").Value = bNajava2
        '-----------
        Dim izSifraTarife As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife", SqlDbType.Char, 2))
        izSifraTarife.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife").Value = bSifraTarife

        Dim izUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        izUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor
        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            bRecID = spKomanda.Parameters("@outRecID").Value
            UpdRecID = bRecID
            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdStanicaRecID = bStanicaRecID

            'exOtpUprava = spKomanda.Parameters("@outOtpUprava").Value
            'exOtpStanica = spKomanda.Parameters("@outOtpStanica").Value
            'exOtpBroj = spKomanda.Parameters("@outOtpBroj").Value
            'exOtpDatum = spKomanda.Parameters("@outOtpDatum").Value
            'exPrUprava = spKomanda.Parameters("@outPrUprava").Value
            'exPrStanica = spKomanda.Parameters("@outPrStanica").Value
            'exPrDatum = spKomanda.Parameters("@outPrDatum").Value
            bSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
            'bZsIzPrelaz = spKomanda.Parameters("@outZsIzPrelaz").Value
            'bZsIzNalepnica = spKomanda.Parameters("@outIzNalepnica").Value
            'bNajava = spKomanda.Parameters("@outNajava").Value
            'bSifraTarife = spKomanda.Parameters("@outSifraTarife").Value
            'bUgovor = spKomanda.Parameters("@outUgovor").Value


            '------------------------ inicijalizovanje izlaznih promenljivih ------------------------------
            If bRecID = 0 And bStanicaRecID = "Nista" Then
                bRetVal = "Ne postoji takav podatak!"
            Else
                mOtpUprava = spKomanda.Parameters("@outOtpUprava").Value
                mOtpStanica = spKomanda.Parameters("@outOtpStanica").Value
                mOtpBroj = spKomanda.Parameters("@outOtpBroj").Value
                mOtpDatum = spKomanda.Parameters("@outOtpDatum").Value
                mPrUprava = spKomanda.Parameters("@outPrUprava").Value
                mPrStanica = spKomanda.Parameters("@outPrStanica").Value
                mPrDatum = spKomanda.Parameters("@outPrDatum").Value

                'bZsIzPrelaz = spKomanda.Parameters("@outZsIzPrelaz").Value
                'bZsIzNalepnica = spKomanda.Parameters("@outIzNalepnica").Value

                '''mNajava = spKomanda.Parameters("@outNajava").Value


                'mNajava = spKomanda.Parameters("@outNajava").Value


                'mNajava = spKomanda.Parameters("@outNajava").Value
                'Else

                mNajava = mNajava

                mTarifa = spKomanda.Parameters("@outSifraTarife").Value
                mBrojUg = spKomanda.Parameters("@outUgovor").Value

                If inTipStanice = "1" Then      ' Ulazna nalepnica
                    bZsIzPrelaz = spKomanda.Parameters("@outZsPrelaz").Value

                    bZsIzNalepnica = spKomanda.Parameters("@outNalepnica").Value
                    mUlEtiketa = inNalepnica

                    mIzEtiketa = bZsIzNalepnica
                Else                                   ' Izlazna nalepnica
                    bZsIzPrelaz = spKomanda.Parameters("@outZsPrelaz").Value

                    bZsIzNalepnica = spKomanda.Parameters("@outNalepnica").Value
                    mUlEtiketa = bZsIzNalepnica

                    mIzEtiketa = inNalepnica
                End If


                '------------------------------- popunjava 3 grida --------------------------------------------
                Dim ug_mNazivKomitenta As String
                Dim ug_mPrimalac As String
                Dim ug_mVrstaObracuna As String
                Dim mizlaz As String

                'NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)
                NadjiUgovor(mBrojUg, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)

                IzmenaTLGranica()

            End If

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub NadjiNhmZaNajave(ByVal _Nhm As String, ByRef _NhmRazred As String, ByRef _RidRazred As Int16)

        Dim rv As String = ""
        Dim KolaRed As DataRow

        mRazred = "1"
        mRazredRid = 0

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspKomanda As New SqlClient.SqlCommand("spNadjiNhmZaNajave", DbVeza)
        uspKomanda.CommandType = CommandType.StoredProcedure

        Dim upSifraRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upSifraRobe", SqlDbType.Char, 6))
        upSifraRobe.Direction = ParameterDirection.Input
        uspKomanda.Parameters("@upSifraRobe").Value = _Nhm

        Dim upTarifa As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upTarifa", SqlDbType.Char, 2))
        upTarifa.Direction = ParameterDirection.Input
        uspKomanda.Parameters("@upTarifa").Value = "32"

        Dim ipRazredRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRobe", SqlDbType.Char, 1))
        ipRazredRobe.Direction = ParameterDirection.Output

        Dim ipRazredRid As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRid", SqlDbType.Int, 2))
        ipRazredRid.Direction = ParameterDirection.Output

        Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipPovratnaVrednost", SqlDbType.NVarChar, 50))
        ipPovratnaVrednost.Direction = ParameterDirection.Output

        Try
            uspKomanda.ExecuteScalar()
            If uspKomanda.Parameters("@ipPovratnaVrednost").Value = "" Then 'OK
                mRazred = uspKomanda.Parameters("@ipRazredRobe").Value
                mRazredRid = uspKomanda.Parameters("@ipRazredRid").Value
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            DbVeza.Close()
            uspKomanda.Dispose()
        End Try

        'If IsNumeric(tbNHM.Text) = True Then

        '    Dim rv As String = ""
        '    Dim KolaRed As DataRow

        '    If DbVeza.State = ConnectionState.Closed Then
        '        DbVeza.Open()
        '    End If

        '    Dim uspKomanda As New SqlClient.SqlCommand("NadjiNhm", DbVeza)
        '    uspKomanda.CommandType = CommandType.StoredProcedure

        '    Dim upSifraRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upSifraRobe", SqlDbType.Char, 6))
        '    upSifraRobe.Direction = ParameterDirection.Input
        '    uspKomanda.Parameters("@upSifraRobe").Value = tbNHM.Text

        '    Dim upTarifa As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upTarifa", SqlDbType.Char, 2))
        '    upTarifa.Direction = ParameterDirection.Input
        '    uspKomanda.Parameters("@upTarifa").Value = mTarifa

        '    Dim ipNazivRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipNazivRobe", SqlDbType.Char, 100))
        '    ipNazivRobe.Direction = ParameterDirection.Output

        '    Dim ipRazredRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRobe", SqlDbType.Char, 1))
        '    ipRazredRobe.Direction = ParameterDirection.Output

        '    Dim ipRazredRid As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRid", SqlDbType.Int, 2))
        '    ipRazredRid.Direction = ParameterDirection.Output

        '    Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipPovratnaVrednost", SqlDbType.NVarChar, 100))
        '    ipPovratnaVrednost.Direction = ParameterDirection.Output

        '    Try
        '        uspKomanda.ExecuteScalar()
        '        If uspKomanda.Parameters("@ipPovratnaVrednost").Value = "" Then 'OK
        '            StatusBar1.Text = uspKomanda.Parameters("@ipNazivRobe").Value
        '            ErrorProvider1.SetError(tbNHM, "")
        '            mRazred = uspKomanda.Parameters("@ipRazredRobe").Value
        '            mRazredRid = uspKomanda.Parameters("@ipRazredRid").Value
        '            tbRazred.Text = mRazred
        '            tbRazredRid.Text = mRazredRid

        '            If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9931" Then
        '                bKontejneri = True
        '            Else
        '                bKontejneri = False
        '            End If

        '            '---------------- popunjava kolonu TipKola u dgKola ------------------------
        '            For Each KolaRed In dtKola.Rows
        '                If mIBK = KolaRed.Item("IndBrojKola") Then
        '                    If KolaRed.Item("Vlasnik") = "Z" Then
        '                        If KolaRed.Item("Vrsta") = "O" Then
        '                            KolaRed.Item("Tip") = "1"
        '                        Else
        '                            KolaRed.Item("Tip") = "2"
        '                        End If
        '                    Else
        '                        If KolaRed.Item("Vrsta") = "O" Then
        '                            If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9922" Then
        '                                KolaRed.Item("Tip") = "7"
        '                            Else
        '                                KolaRed.Item("Tip") = "3"
        '                            End If
        '                        Else
        '                            If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9922" Then
        '                                KolaRed.Item("Tip") = "7"
        '                            Else
        '                                KolaRed.Item("Tip") = "4"
        '                            End If
        '                        End If
        '                    End If
        '                End If
        '            Next
        '            '---------------------------------------------------------------------------

        '            'otvara tip uti
        '            If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9931" Then
        '                gbUti.Enabled = True
        '                'cbTipUti.Enabled = True
        '                cbTipUti.Focus()
        '                cbTipUti.DroppedDown = True
        '            Else
        '                gbUti.Enabled = False
        '                btnDodajRobu.Focus()
        '            End If
        '            ' ----------------------------------------

        '        Else 'nije ok
        '            StatusBar1.Text = ""
        '            rv = uspKomanda.Parameters("@ipPovratnaVrednost").Value
        '            ErrorProvider1.SetError(tbNHM, rv)
        '            tbNHM.Focus()
        '        End If
        '    Catch SQLExp As SqlException
        '        rv = SQLExp.Message & " ?"  'Greska - SQL greska
        '        StatusBar1.Text = rv
        '        tbNHM.Focus()

        '    Catch Exp As Exception
        '        rv = Err.Description & "??" 'Greska - bilo koja
        '        StatusBar1.Text = rv
        '        tbNHM.Focus()
        '    Finally
        '        DbVeza.Close()
        '        uspKomanda.Dispose()
        '    End Try

        'Else
        '    ErrorProvider1.SetError(tbNHM, "Neispravan unos!")
        '    If tbNHM.Text = Nothing Then
        '        tbMasa.Focus()
        '    Else
        '        tbNHM.Focus()
        '    End If
        'End If

    End Sub
    Public Sub NajavaPregled(ByVal _mBrojUg As String, ByVal _mNajava As String, _
                             ByRef _KolaNajava As Int16, ByRef _KolaReal As Int16, _
                             ByRef _BrutoMasa As Decimal, ByRef _NetoMasa As Decimal, ByVal _TaraMasa As Decimal, _
                             ByRef _rv As String)



        _rv = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.okpNajavaPregled", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        ulUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _mBrojUg

        Dim ulNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10))
        ulNajava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNajava").Value = _mNajava

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exKolaNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolaNajava", SqlDbType.Int, 4))
        exKolaNajava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKolaNajava").Value = _KolaNajava

        Dim exKolaReal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolaReal", SqlDbType.Int, 4))
        exKolaReal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKolaNajava").Value = _KolaReal

        Dim exBrutoMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrutoMasa", SqlDbType.Decimal))
        exBrutoMasa.Size = 5
        exBrutoMasa.Precision = 5
        exBrutoMasa.Scale = 0
        exBrutoMasa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBrutoMasa").Value = _BrutoMasa

        Dim exNetoMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNetoMasa", SqlDbType.Decimal))
        exNetoMasa.Size = 5
        exNetoMasa.Precision = 5
        exNetoMasa.Scale = 0
        exNetoMasa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNetoMasa").Value = _NetoMasa

        Dim exTaraMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTaraMasa", SqlDbType.Decimal))
        exTaraMasa.Size = 5
        exTaraMasa.Precision = 5
        exTaraMasa.Scale = 0
        exTaraMasa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTaraMasa").Value = _TaraMasa

        '---------------------------------------------------------------------------------------------------------
        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = _rv

        Try
            spKomanda.ExecuteScalar()

            _KolaNajava = spKomanda.Parameters("@outKolaNajava").Value
            _KolaReal = spKomanda.Parameters("@outKolaReal").Value
            _BrutoMasa = spKomanda.Parameters("@outBrutoMasa").Value
            _NetoMasa = spKomanda.Parameters("@outNetoMasa").Value
            _TaraMasa = spKomanda.Parameters("@outTaraMasa").Value

        Catch SQLExp As SqlException
            _rv = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            _rv = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Public Sub NajavaPregledKalk(ByVal _mBrojUg As String, ByVal _mNajava As String, ByVal _mObrGodina As String, _
                                 ByRef _KolaReal As Int16, ByRef _NetoMasa As Decimal, ByRef _TaraMasa As Decimal, _
                                 ByRef _SumaPoTL As Decimal, ByRef _SumaPrevoznine As Decimal, ByVal _SumaNakCo As Decimal, _
                                 ByRef _SumaNakCo82 As Decimal, ByRef _SumaNakFr As Decimal, _
                                 ByRef _rv As String)


        _rv = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.okpNajavaPregledKalk", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        ulUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _mBrojUg

        Dim ulNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10))
        ulNajava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNajava").Value = _mNajava

        Dim ulGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4))
        ulGodina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inGodina").Value = _mObrGodina

        '-------------------------------------- Izlazne promenljive ----------------------------------------------

        Dim exKolaReal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolaReal", SqlDbType.Int, 4))
        exKolaReal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKolaReal").Value = _KolaReal

        Dim exNetoMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNetoMasa", SqlDbType.Decimal))
        exNetoMasa.Size = 5
        exNetoMasa.Precision = 8
        exNetoMasa.Scale = 0
        exNetoMasa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNetoMasa").Value = _NetoMasa

        Dim exTaraMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTaraMasa", SqlDbType.Decimal))
        exTaraMasa.Size = 5
        exTaraMasa.Precision = 8
        exTaraMasa.Scale = 0
        exTaraMasa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTaraMasa").Value = _TaraMasa

        Dim izTlSumaFr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTlSumaFr", SqlDbType.Decimal)) 'Decimal
        izTlSumaFr.Direction = ParameterDirection.Output
        izTlSumaFr.Size = 9
        izTlSumaFr.Precision = 12
        izTlSumaFr.Scale = 2
        spKomanda.Parameters("@outTlSumaFr").Value = _SumaPoTL

        Dim izTlPrevFr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTlPrevFr", SqlDbType.Decimal))  'Decimal
        izTlPrevFr.Direction = ParameterDirection.Output
        izTlPrevFr.Size = 9
        izTlPrevFr.Precision = 12
        izTlPrevFr.Scale = 2
        spKomanda.Parameters("@outTlPrevFr").Value = _SumaPrevoznine

        Dim izTlNakCo As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTlNakCo", SqlDbType.Decimal))  'Decimal
        izTlNakCo.Direction = ParameterDirection.Output
        izTlNakCo.Size = 9
        izTlNakCo.Precision = 12
        izTlNakCo.Scale = 2
        spKomanda.Parameters("@outTlNakCo").Value = _SumaNakCo

        Dim izTlNakCo82 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTlNakCo82", SqlDbType.Decimal))  'Decimal
        izTlNakCo82.Direction = ParameterDirection.Output
        izTlNakCo82.Size = 9
        izTlNakCo82.Precision = 12
        izTlNakCo82.Scale = 2
        spKomanda.Parameters("@outTlNakCo82").Value = _SumaNakCo82

        Dim izTlNakFr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTlNakFr", SqlDbType.Decimal))  'Decimal
        izTlNakFr.Direction = ParameterDirection.Output
        izTlNakFr.Size = 9
        izTlNakFr.Precision = 12
        izTlNakFr.Scale = 2
        spKomanda.Parameters("@outTlNakFr").Value = _SumaNakFr

        '---------------------------------------------------------------------------------------------------------
        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = _rv

        Try
            spKomanda.ExecuteScalar()

            _KolaReal = spKomanda.Parameters("@outKolaReal").Value
            _NetoMasa = spKomanda.Parameters("@outNetoMasa").Value
            _TaraMasa = spKomanda.Parameters("@outTaraMasa").Value
            _SumaPoTL = spKomanda.Parameters("@outTlSumaFr").Value
            _SumaPrevoznine = spKomanda.Parameters("@outTlPrevFr").Value
            _SumaNakCo = spKomanda.Parameters("@outTlNakCo").Value
            _SumaNakCo82 = spKomanda.Parameters("@outTlNakCo82").Value
            _SumaNakFr = spKomanda.Parameters("@outTlNakFr").Value

        Catch SQLExp As SqlException
            _rv = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            _rv = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub CoVozoviProcenatZaBM(ByVal _BrojUg As String, ByVal _Stanica1 As String, ByVal _Stanica2 As String, _
                                    ByVal _tempBM As Integer, ByRef _ProcenatBM As Decimal, ByRef _rv As String)


        _rv = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.okpProcenatZaBM", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        ulUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _BrojUg

        Dim ulStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica1", SqlDbType.Char, 5))
        ulStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica1").Value = _Stanica1

        Dim ulStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica2", SqlDbType.Char, 5))
        ulStanica2.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica2").Value = _Stanica2

        Dim ulMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inMasa", SqlDbType.Int, 4))
        ulMasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inMasa").Value = _tempBM

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izProcenat As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outProcenat", SqlDbType.Decimal)) 'Decimal
        izProcenat.Direction = ParameterDirection.Output
        izProcenat.Size = 5
        izProcenat.Precision = 9
        izProcenat.Scale = 2
        spKomanda.Parameters("@outProcenat").Value = _ProcenatBM

        '---------------------------------------------------------------------------------------------------------
        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = _rv

        Try
            spKomanda.ExecuteScalar()

            _ProcenatBM = spKomanda.Parameters("@outProcenat").Value

        Catch SQLExp As SqlException
            _rv = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            _rv = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try


    End Sub
    Public Sub CoUpdatePrevoznine(ByVal _BrojUg As String, ByVal _Najava As String, ByVal _ObrGodina As String, _
                                  ByVal _Prevoznina As Decimal, ByRef _rv As String)

        _rv = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.okpUpdateBMVoza", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        ulUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _BrojUg

        Dim ulNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10))
        ulNajava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNajava").Value = _Najava

        Dim ulGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4))
        ulGodina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inGodina").Value = _ObrGodina

        Dim ulPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrevoznina", SqlDbType.Decimal, 5))
        ulPrevoznina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrevoznina").Value = _Prevoznina

        '----------------------------------------------------------------------------------------------------------------------------
        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = _rv

        Try
            spKomanda.ExecuteScalar()
        Catch SQLExp As SqlException
            _rv = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            _rv = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub NadjiIzlazniVoz(ByVal _Ugovor As String, ByRef _NazivKomitenta As String, ByRef _Primalac As Int32, ByRef _VrstaObracuna As String, _
                               ByRef outRetVal As String)

        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiUgovor", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        inUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _Ugovor

        Dim outNaziv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNaziv", SqlDbType.VarChar, 30))
        outNaziv.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNaziv").Value = _NazivKomitenta

        Dim outSifra As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifra", SqlDbType.Int, 4))
        outSifra.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifra").Value = _Primalac

        Dim outVrstaObr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrstaObr", SqlDbType.Char, 2))
        outVrstaObr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVrstaObr").Value = _VrstaObracuna

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()
            _NazivKomitenta = spKomanda.Parameters("@outNaziv").Value
            _Primalac = spKomanda.Parameters("@outSifra").Value
            _VrstaObracuna = spKomanda.Parameters("@outVrstaObr").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch sqlexp As Exception
            outRetVal = sqlexp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub IzjavaZs()
        Dim i_TotalNak As String = ""
        Dim i_Pronasao As Int32 = 0

        Dim NaknadaRed As DataRow
        Dim f_prev As Decimal = 0
        Dim u_prev As Decimal = 0
        Dim f_nak As Decimal = 0
        Dim u_nak As Decimal = 0
        Dim u_din As Decimal = 0
        Dim suma_nak As Decimal = 0

        If dtNaknade.Rows.Count > 0 Then
            For Each NaknadaRed In dtNaknade.Rows

                '1. franko prevoznina
                '   ukljucivo naknade
                '   do prelaza - ima ili nema podatka
                '                ako je   711: sve naknade ZS su upucene
                '                ako nema    : franko su one naknade koje su jednake navedenoj naknadi u izjavi,
                '                              ostale naknade su upucene

                '2. Incoterms


                If mDoPrelaza.Trim.Length = 0 Then ' dodato zbog preuzimanja
                    mDoPrelaza = ""
                End If

                If mDoPrelaza = "0" Then ' dodato zbog preuzimanja
                    mDoPrelaza = ""
                End If

                If mSifraIzjave = 1 Then                           ' ----------------- FRANKO OK
                    If mDoPrelaza = "" Or mDoPrelaza = "    " Then ' ----------------- ZA CEO PREVOZNI PUT
                        f_prev = mPrevoznina
                        u_prev = 0

                        If Microsoft.VisualBasic.Trim(upis_mFrNaknade) = "0" Then
                            f_nak = u_nak + NaknadaRed.Item("Iznos")
                            u_nak = 0
                        ElseIf Microsoft.VisualBasic.Trim(upis_mFrNaknade) = "" Then
                            f_nak = 0
                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        Else
                            i_Pronasao = -1
                            i_TotalNak = NaknadaRed.Item("Sifra")
                            For ii As Int16 = 0 To 4
                                If mUkljucujuci(ii) = i_TotalNak Then
                                    i_Pronasao = 1
                                    Exit For
                                End If
                            Next

                            If i_Pronasao >= 0 Then
                                f_nak = f_nak + NaknadaRed.Item("Iznos")
                            Else
                                u_nak = u_nak + NaknadaRed.Item("Iznos")
                            End If

                        End If
                    Else                                         ' ----------------- DO GRANICNOG PRELAZA mDoPrelaza => Sve je upuceno
                        f_prev = 0
                        u_prev = mPrevoznina

                        u_nak = u_nak + NaknadaRed.Item("Iznos")
                        f_nak = 0

                    End If
                ElseIf mSifraIzjave = 2 Then    ' ---------------- INCOTERMS
                    If mIncoterms = "EXW" Then
                        f_prev = 0
                        u_prev = mPrevoznina
                        f_nak = 0
                        u_nak = u_nak + NaknadaRed.Item("Iznos")
                    ElseIf mIncoterms = "FCA" Then
                        If NaknadaRed.Item("Sifra") = "40" Or NaknadaRed.Item("Sifra") = "46" Or _
                           NaknadaRed.Item("Sifra") = "45" Or _
                           NaknadaRed.Item("Sifra") = "60" Or NaknadaRed.Item("Sifra") = "61" Then

                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                        Else
                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        End If
                        f_prev = 0
                        u_prev = mPrevoznina
                    ElseIf mIncoterms = "CPT" Then
                        If NaknadaRed.Item("Sifra") = "41" Or NaknadaRed.Item("Sifra") = "42" Or _
                           NaknadaRed.Item("Sifra") = "46" Or NaknadaRed.Item("Sifra") = "45" Or _
                           NaknadaRed.Item("Sifra") = "60" Or NaknadaRed.Item("Sifra") = "61" Then

                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        Else
                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                        End If
                        f_prev = mPrevoznina
                        u_prev = 0

                    ElseIf mIncoterms = "CIP" Then
                        If NaknadaRed.Item("Sifra") = "41" Or NaknadaRed.Item("Sifra") = "42" Or _
                           NaknadaRed.Item("Sifra") = "46" Or NaknadaRed.Item("Sifra") = "45" Or _
                           NaknadaRed.Item("Sifra") = "60" Or NaknadaRed.Item("Sifra") = "61" Then

                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        Else
                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                        End If
                        f_prev = 0
                        u_prev = mPrevoznina

                    ElseIf mIncoterms = "DAF" Then 'do mesta upisanog u box
                        f_prev = mPrevoznina
                        u_prev = 0
                        f_nak = f_nak + NaknadaRed.Item("Iznos")
                        u_nak = 0

                    ElseIf mIncoterms = "DDU" Then
                        If NaknadaRed.Item("Sifra") = "42" Or _
                           NaknadaRed.Item("Sifra") = "46" Or NaknadaRed.Item("Sifra") = "45" Or _
                           NaknadaRed.Item("Sifra") = "60" Or NaknadaRed.Item("Sifra") = "61" Then

                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        Else
                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                        End If
                        f_prev = mPrevoznina
                        u_prev = 0
                    ElseIf mIncoterms = "DDP" Then
                        f_prev = mPrevoznina
                        u_prev = 0
                        f_nak = f_nak + NaknadaRed.Item("Iznos")
                        u_nak = 0

                    End If

                ElseIf mSifraIzjave = 3 Then    ' ---------------- Sve upuceno
                    f_prev = 0
                    u_prev = mPrevoznina
                    u_nak = u_nak + NaknadaRed.Item("Iznos")
                    f_nak = 0
                End If
            Next
        Else
            If mDoPrelaza.Trim.Length = 0 Then  ' dodato zbog preuzimanja
                mDoPrelaza = ""
            End If

            If mDoPrelaza = "0" Then ' dodato zbog preuzimanja
                mDoPrelaza = ""
            End If

            If mSifraIzjave = 1 Then        ' FRANKO prevoznina
                If mDoPrelaza = "" Then
                    u_prev = 0
                    f_prev = mPrevoznina 'testirati
                Else
                    f_prev = 0
                    u_prev = mPrevoznina
                End If
            ElseIf mSifraIzjave = 2 Then    ' INCOTERMS
                If mIncoterms = "EXW" Then
                    f_prev = 0
                    u_prev = mPrevoznina
                ElseIf mIncoterms = "FCA" Then
                    f_prev = 0
                    u_prev = mPrevoznina
                ElseIf mIncoterms = "CPT" Then
                    f_prev = mPrevoznina
                    u_prev = 0
                ElseIf mIncoterms = "CIP" Then
                    f_prev = 0
                    u_prev = mPrevoznina
                ElseIf mIncoterms = "DAF" Then 'do mesta upisanog u box
                    f_prev = mPrevoznina
                    u_prev = 0
                ElseIf mIncoterms = "DDU" Then
                    f_prev = mPrevoznina
                    u_prev = 0
                ElseIf mIncoterms = "DDP" Then
                    f_prev = mPrevoznina
                    u_prev = 0
                End If
            ElseIf mSifraIzjave = 3 Then    ' ---------------- Sve upuceno
                f_prev = 0
                u_prev = mPrevoznina
                u_nak = 0
                f_nak = 0
            End If
        End If

        Dim mOutKurs As Decimal = 0
        Dim strRetVal As String = ""

        If IzborSaobracaja = "2" Then
            NadjiKurs(bValuta, "1", mPrDatum, mOutKurs, strRetVal)
            If mBrojUg = "200379" Then 'Sartid
                NadjiKurs(bValuta, "3", mPrDatum, mOutKurs, strRetVal)
            ElseIf mBrojUg = "517902" Then  'NIS
                NadjiKurs(bValuta, "3", mPrDatum, mOutKurs, strRetVal)
            ElseIf mBrojUg = "517903" Then  'NIS
                NadjiKurs(bValuta, "3", mPrDatum, mOutKurs, strRetVal)
            End If
        ElseIf IzborSaobracaja = "3" Then
            NadjiKurs(bValuta, "1", mOtpDatum, mOutKurs, strRetVal)
            If mBrojUg = "200379" Then 'Sartid
                NadjiKurs(bValuta, "3", mOtpDatum, mOutKurs, strRetVal)
            ElseIf mBrojUg = "517902" Then  'NIS
                NadjiKurs(bValuta, "3", mOtpDatum, mOutKurs, strRetVal)
            ElseIf mBrojUg = "517903" Then  'NIS
                NadjiKurs(bValuta, "3", mOtpDatum, mOutKurs, strRetVal)
            End If
            end if


            Dim zaokruziIznos As Decimal = 0

            If mTarifa = "68" Or kSifTar = 68 Or (Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" And mVrstaObracuna = "CO") Then 'TEA na 1e
                zaokruziIznos = u_prev + u_nak
                bZaokruziNaCeleNavise(zaokruziIznos)
            Else
                zaokruziIznos = u_prev + u_nak
            End If

            upis_u_suma = zaokruziIznos

            If zaokruziIznos > 0 Then
                u_din = zaokruziIznos * mOutKurs
                bZaokruziNaDeseteNavise(u_din)
            End If

            dtUic2.Rows.Add(New Object() {f_prev, f_nak, f_prev + f_nak, "72", bValuta, _
                                          u_prev, u_nak, u_prev + u_nak, u_din})

            upis_f_prev = f_prev
            upis_u_prev = u_prev
            upis_f_nak = f_nak
            upis_u_nak = u_nak

            upis_f_suma = f_prev + f_nak

            upis_f_prev_din = f_prev * mOutKurs
            bZaokruziNaDeseteNavise(upis_f_prev_din)
            upis_u_prev_din = u_prev * mOutKurs
            bZaokruziNaDeseteNavise(upis_u_prev_din)
            upis_f_nak_din = f_nak * mOutKurs
            bZaokruziNaDeseteNavise(upis_f_nak_din)
            upis_u_nak_din = u_nak * mOutKurs
            bZaokruziNaDeseteNavise(upis_u_nak_din)

            upis_u_din = u_din 'TLSUMAUPDIN - UPUCENO DINARI, UVOZ

    End Sub

    Public Sub Izjava()
        Dim UpravaRed As DataRow
        Dim i_Prevoznina As Decimal = 0
        Dim suma_Nak As Decimal = 0
        Dim i_TotalNak As String = ""
        Dim i_Pronasao As Int32 = 0

        'mSifraIzjave 1,2
        'mUkljucujuci - pr. 42
        'mDoPrelaza - pr. 711


        Dim i_Granica As Decimal = 10
        For Each UpravaRed In dtUic.Rows
            If UpravaRed.Item("Izlaz") = mDoPrelaza Then
                i_Granica = UpravaRed.Item("rbr")
            End If
        Next

        For Each UpravaRed In dtUic.Rows

            UpravaRed.Item("PF") = 0
            UpravaRed.Item("PU") = 0
            UpravaRed.Item("NF") = 0
            UpravaRed.Item("NU") = 0
            UpravaRed.Item("DU") = 0

            If mSifraIzjave = 1 Then ' ------------------------ F R A N K O prevoznina ----------------------------
                i_Prevoznina = UpravaRed.Item("Prevoznina")
                'novo 11.5.2010
                ''''UpravaRed.Item("PF") = i_Prevoznina ' prevoznina franko
                ''''UpravaRed.Item("PU") = 0            ' prevoznina upuceno = 0 

                If UpravaRed.Item("rbr") <= i_Granica Then  ' F R A N K O do granicnog prelaza
                    'novo 11.5.2010
                    UpravaRed.Item("PF") = i_Prevoznina ' prevoznina franko
                    UpravaRed.Item("PU") = 0            ' prevoznina upuceno = 0 

                    If upis_mFrNaknade <> "" Then              ' F R A N K O naknade do granicnog prelaza
                        ''If Microsoft.VisualBasic.Left(mUkljucujuci, 1) = "0" Then

                        If Microsoft.VisualBasic.Trim(upis_mFrNaknade) = "0" Then
                            UpravaRed.Item("NF") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")
                            UpravaRed.Item("NU") = 0
                        Else
                            ''i_TotalNak = UpravaRed.Item("Nak1")
                            ''i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)

                            '=============== new ==============
                            i_Pronasao = -1
                            i_TotalNak = UpravaRed.Item("Nak1")
                            For ii As Int16 = 0 To 4
                                If mUkljucujuci(ii) = i_TotalNak Then
                                    i_Pronasao = 1
                                    Exit For
                                End If
                            Next
                            '============= end new ============

                            If i_Pronasao >= 0 Then
                                UpravaRed.Item("NF") = UpravaRed.Item("Iznos1")
                                UpravaRed.Item("NU") = UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                            Else
                                'i_TotalNak = UpravaRed.Item("Nak2")
                                'i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)
                                '=============== new ==============
                                i_Pronasao = -1
                                i_TotalNak = UpravaRed.Item("Nak2")
                                For ii As Int16 = 0 To 4
                                    If mUkljucujuci(ii) = i_TotalNak Then
                                        i_Pronasao = 1
                                        Exit For
                                    End If
                                Next
                                '============= end new ============

                                If i_Pronasao >= 0 Then
                                    UpravaRed.Item("NF") = UpravaRed.Item("Iznos2")
                                    UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos3")

                                Else
                                    'i_TotalNak = UpravaRed.Item("Nak3")
                                    'i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)
                                    '=============== new ==============
                                    i_Pronasao = -1
                                    i_TotalNak = UpravaRed.Item("Nak3")
                                    For ii As Int16 = 0 To 4
                                        If mUkljucujuci(ii) = i_TotalNak Then
                                            i_Pronasao = 1
                                            Exit For
                                        End If
                                    Next
                                    '============= end new ============

                                    If i_Pronasao >= 0 Then
                                        UpravaRed.Item("NF") = UpravaRed.Item("Iznos3")
                                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2")
                                    Else
                                        UpravaRed.Item("NF") = 0
                                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")
                                    End If
                                End If
                            End If
                        End If
                    Else
                        UpravaRed.Item("NF") = 0
                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")
                    End If
                Else ' --------------------------------------- U P U C E N O --------------------------------------
                    'novo 11.5.2010
                    UpravaRed.Item("PF") = 0            ' prevoznina upuceno = 0 
                    UpravaRed.Item("PU") = i_Prevoznina ' prevoznina franko

                    UpravaRed.Item("NF") = 0
                    UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                End If

            ElseIf mSifraIzjave = 2 Then ' ------------------------------------- I N C O T E R M S -------------------------------------
                i_Prevoznina = UpravaRed.Item("Prevoznina")
                suma_Nak = suma_Nak + UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                If mIncoterms = "EXW" Then
                    UpravaRed.Item("PF") = 0
                    UpravaRed.Item("PU") = i_Prevoznina
                    UpravaRed.Item("NF") = 0
                    UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                ElseIf mIncoterms = "FCA" Then
                    UpravaRed.Item("PF") = 0
                    UpravaRed.Item("PU") = i_Prevoznina

                ElseIf mIncoterms = "CPT" Then
                    UpravaRed.Item("PU") = 0
                    UpravaRed.Item("PF") = i_Prevoznina

                    If UpravaRed.Item("Nak1") = "41" Or UpravaRed.Item("Nak1") = "42" Or _
                       UpravaRed.Item("Nak1") = "46" Or UpravaRed.Item("Nak1") = "45" Or _
                       UpravaRed.Item("Nak1") = "60" Or UpravaRed.Item("Nak1") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1")

                    End If
                    If UpravaRed.Item("Nak2") = "41" Or UpravaRed.Item("Nak2") = "42" Or _
                       UpravaRed.Item("Nak2") = "46" Or UpravaRed.Item("Nak2") = "45" Or _
                       UpravaRed.Item("Nak2") = "60" Or UpravaRed.Item("Nak2") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("NU") + UpravaRed.Item("Iznos2")

                    End If
                    If UpravaRed.Item("Nak3") = "41" Or UpravaRed.Item("Nak3") = "42" Or _
                       UpravaRed.Item("Nak3") = "46" Or UpravaRed.Item("Nak3") = "45" Or _
                       UpravaRed.Item("Nak3") = "60" Or UpravaRed.Item("Nak3") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("NU") + UpravaRed.Item("Iznos3")
                    End If

                    UpravaRed.Item("NF") = suma_Nak - UpravaRed.Item("NU")

                ElseIf mIncoterms = "CIP" Then
                    UpravaRed.Item("PU") = 0
                    UpravaRed.Item("PF") = i_Prevoznina

                    If UpravaRed.Item("Nak1") = "41" Or UpravaRed.Item("Nak1") = "42" Or _
                       UpravaRed.Item("Nak1") = "46" Or UpravaRed.Item("Nak1") = "45" Or _
                       UpravaRed.Item("Nak1") = "60" Or UpravaRed.Item("Nak1") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1")

                    End If
                    If UpravaRed.Item("Nak2") = "41" Or UpravaRed.Item("Nak2") = "42" Or _
                       UpravaRed.Item("Nak2") = "46" Or UpravaRed.Item("Nak2") = "45" Or _
                       UpravaRed.Item("Nak2") = "60" Or UpravaRed.Item("Nak2") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("NU") + UpravaRed.Item("Iznos2")

                    End If
                    If UpravaRed.Item("Nak3") = "41" Or UpravaRed.Item("Nak3") = "42" Or _
                       UpravaRed.Item("Nak3") = "46" Or UpravaRed.Item("Nak3") = "45" Or _
                       UpravaRed.Item("Nak3") = "60" Or UpravaRed.Item("Nak3") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("NU") + UpravaRed.Item("Iznos3")
                    End If

                    UpravaRed.Item("NF") = suma_Nak - UpravaRed.Item("NU")

                ElseIf mIncoterms = "DAF" Then

                ElseIf mIncoterms = "DDU" Then

                ElseIf mIncoterms = "DDP" Then
                    UpravaRed.Item("PU") = 0
                    UpravaRed.Item("PF") = i_Prevoznina
                    UpravaRed.Item("NU") = 0
                    UpravaRed.Item("NF") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                End If

            ElseIf mSifraIzjave = 3 Then                     'Sve je upuceno
                i_Prevoznina = UpravaRed.Item("Prevoznina")
                UpravaRed.Item("PF") = 0
                UpravaRed.Item("PU") = i_Prevoznina
                UpravaRed.Item("NF") = 0
                UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

            End If

        Next
    End Sub
    Public Sub NadjiKurs(ByVal inValuta As String, ByVal inVrsta As String, ByVal inDatum As Date, _
                         ByRef outKurs As Decimal, ByRef outRetVal As String)


        outRetVal = ""

        Dim spKomanda As New SqlClient.SqlCommand("NadjiKurs", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        'popraviti u bazi ZsKursevi.Valuta char(10) u char(2)!!
        Dim ulValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inValuta", SqlDbType.Char, 2))
        ulValuta.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inValuta").Value = inValuta

        Dim ulVrsta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrsta", SqlDbType.Char, 1))
        ulVrsta.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrsta").Value = inVrsta

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = inDatum

        Dim izlKurs As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKurs", SqlDbType.Decimal))
        izlKurs.Size = 9
        izlKurs.Precision = 10
        izlKurs.Scale = 4
        izlKurs.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outKurs").Value = outKurs

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            spKomanda.ExecuteScalar()

            outKurs = spKomanda.Parameters("@outkurs").Value
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
    Public Sub NadjiTovarniListGranicaUI(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, _
                                         ByVal bDatum As Date, ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                                         ByRef bPrUprava As String, ByRef bPrStanica As String, ByRef bSaobracaj As String, _
                                         ByRef bZsUlPrelaz As String, ByRef bZsIzPrelaz As String, ByRef bNajava As String, _
                                         ByRef bSifraTarife As String, ByRef bUgovor As String, _
                                         ByRef bRetVal As String)

        bRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL2UI", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulazUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = bDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim exPrUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrUprava", SqlDbType.Char, 4))
        exPrUprava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrUprava").Value = bPrUprava

        Dim exPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        exPrStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = bPrStanica

        Dim exPrSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSaobracaj", SqlDbType.Char, 1))
        exPrSaobracaj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSaobracaj").Value = bSaobracaj

        Dim exZsUlPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outZsUlPrelaz", SqlDbType.Char, 5))
        exZsUlPrelaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outZsUlPrelaz").Value = bZsUlPrelaz

        Dim exZsIzPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outZsIzPrelaz", SqlDbType.Char, 5))
        exZsIzPrelaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outZsIzPrelaz").Value = bZsIzPrelaz

        Dim exNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNajava", SqlDbType.Char, 10))
        exNajava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNajava").Value = bNajava

        Dim exSifraTarife As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife", SqlDbType.Char, 2))
        exSifraTarife.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife").Value = bSifraTarife

        Dim exUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        exUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            bRecID = spKomanda.Parameters("@outRecID").Value
            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdRecID = bRecID
            UpdStanicaRecID = bStanicaRecID

            bPrUprava = spKomanda.Parameters("@outPrUprava").Value
            bPrStanica = spKomanda.Parameters("@outPrStanica").Value
            bSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
            bZsUlPrelaz = spKomanda.Parameters("@outZsUlPrelaz").Value
            bZsIzPrelaz = spKomanda.Parameters("@outZsIzPrelaz").Value

            bNajava = spKomanda.Parameters("@outNajava").Value
            bSifraTarife = spKomanda.Parameters("@outSifraTarife").Value
            bUgovor = spKomanda.Parameters("@outUgovor").Value

            'popunjava 3 grida
            Dim ug_mNazivKomitenta As String
            Dim ug_mPrimalac As String
            Dim ug_mVrstaObracuna As String
            Dim mizlaz As String


            If Microsoft.VisualBasic.Trim(bUgovor) <> "" Then
                NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)
            End If

            '---------------- popunjava 3 grida -----------------------
            IzmenaTLGranica()
            '----------------------------------------------------------

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub IzmenaTLUI()

        Dim mStavkaKola
        Dim IBK
        Dim ii1 As Int32 = 0
        Dim ii2 As Int32 = 0

        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        dtUic.Clear()
        dtK211.Clear()

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        dsSlogKola.Clear()
        dsSlogNHM.Clear()

        Try
            '-------------------------------------- popunjava Grid Kola ---------------------------------------------------
            Dim adSlogKola As New SqlDataAdapter("SELECT dbo.SlogKola.KolaStavka, dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogKola.Uprava,  " _
                                & " dbo.SlogKola.Vlasnik, dbo.SlogKola.Serija, dbo.SlogKola.Osovine, dbo.SlogKola.GranTov, dbo.SlogKola.Stitna, " _
                                & " dbo.SlogKola.TipKola, dbo.SlogKola.Naknada, dbo.SlogKola.Kontrola, dbo.SlogKalk.UkupnoKola, dbo.SlogRoba.NHM, " _
                                & " dbo.SlogRoba.NHMRazred, dbo.SlogRoba.SMasa, dbo.SlogRoba.RMasa, dbo.SlogRoba.RID, " _
                                & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav, dbo.SlogRoba.UtiNHM  " _
                                & " FROM dbo.SlogKola INNER JOIN  " _
                                & " dbo.SlogKalk ON dbo.SlogKola.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogKola.OtpStanica = dbo.SlogKalk.OtpStanica AND   " _
                                & " dbo.SlogKola.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogKola.OtpDatum = dbo.SlogKalk.OtpDatum INNER JOIN  " _
                                & " dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND   " _
                                & " dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka  " _
                                & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

            ii1 = adSlogKola.Fill(dsSlogKola)

            For k As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                mStavkaKola = dsSlogKola.Tables(0).Rows(k).Item(0)
                IBK = dsSlogKola.Tables(0).Rows(k).Item(1)


                Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & IBK & "'")
                If dtRow.Length > 0 Then
                    'Kola su vec upisana!
                Else
                    Dim drKola As DataRow = dtKola.NewRow

                    drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(6), _
                                                       dsSlogKola.Tables(0).Rows(k).Item(4), dsSlogKola.Tables(0).Rows(k).Item(5), _
                                                       "O", dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(7), _
                                                       dsSlogKola.Tables(0).Rows(k).Item(8), dsSlogKola.Tables(0).Rows(k).Item(9), 0, _
                                                       dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), _
                                                       dsSlogKola.Tables(0).Rows(k).Item(19), "U"}

                    ''drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(3), _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(4), "O", dsSlogKola.Tables(0).Rows(k).Item(5), _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(6), dsSlogKola.Tables(0).Rows(k).Item(7), _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(8), dsSlogKola.Tables(0).Rows(k).Item(9), 0, _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(19), "U"}

                    dtKola.Rows.Add(drKola)
                End If
            Next

            Dim KolaRed As DataRow
            For Each KolaRed In dtKola.Rows
                mIBK = KolaRed.Item("IndBrojKola")
                _mTara = KolaRed.Item("Tara")
            Next

            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------
            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                Dim drNHM As DataRow = dtNhm.NewRow
                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(21), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(18), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                  "", 0, 0, "", "", "U", _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20)}

                dtNhm.Rows.Add(drNHM)

            Next
            Dim KolaNhm As DataRow
            For Each KolaNhm In dtNhm.Rows
                _mNHM = KolaNhm.Item("NHM")
                _mSMasa = KolaNhm.Item("Masa")
                _mTipUti = KolaNhm.Item("UTI")
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        '-------------------------------------- popunjava Grid Naknade ---------------------------------------------------
        dsSlogNak.Clear()
        Try
            Dim adSlogNak As New SqlDataAdapter(" SELECT dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, dbo.SlogNaknada.Iznos, dbo.SlogNaknada.Valuta, dbo.SlogNaknada.Kolicina, " _
                                              & " dbo.SlogNaknada.DanCas, dbo.SlogNaknada.Placanje, dbo.SlogNaknada.Vrsta " _
                                              & " FROM dbo.SlogNaknada INNER JOIN " _
                                              & " dbo.SlogKalk ON dbo.SlogNaknada.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogNaknada.OtpStanica = dbo.SlogKalk.OtpStanica AND " _
                                              & " dbo.SlogNaknada.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogNaknada.OtpDatum = dbo.SlogKalk.OtpDatum " _
                                              & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

            ii2 = adSlogNak.Fill(dsSlogNak)

            For k As Int16 = 0 To dsSlogNak.Tables(0).Rows.Count - 1
                Dim drNaknade As DataRow = dtNaknade.NewRow
                drNaknade.ItemArray() = New Object() {dsSlogNak.Tables(0).Rows(k).Item(0), dsSlogNak.Tables(0).Rows(k).Item(1), dsSlogNak.Tables(0).Rows(k).Item(2), _
                                                      dsSlogNak.Tables(0).Rows(k).Item(3), dsSlogNak.Tables(0).Rows(k).Item(4), dsSlogNak.Tables(0).Rows(k).Item(5), _
                                                      dsSlogNak.Tables(0).Rows(k).Item(6), dsSlogNak.Tables(0).Rows(k).Item(7), "U"}
                dtNaknade.Rows.Add(drNaknade)
            Next

        Catch sqlex As SqlException

            Dim aa As String
            aa = sqlex.Message

        End Try

        '-------------------------------------- popunjava Grid K211 ---------------------------------------------------

        dsSlogK211.Clear()
        Try
            Dim adSlogK211 As New SqlDataAdapter(" SELECT dbo.SlogK211.SifraK211, dbo.ZsKontrolnePrimedbe.NazivSrpski " _
                                           & " FROM dbo.SlogK211 INNER JOIN " _
                                           & " dbo.ZsKontrolnePrimedbe ON dbo.SlogK211.SifraK211 = dbo.ZsKontrolnePrimedbe.SifraK211 " _
                                           & " WHERE  (dbo.SlogK211.RecID = '" & UpdRecID & "') AND (dbo.SlogK211.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

            ii2 = adSlogK211.Fill(dsSlogK211)

            For k As Int16 = 0 To dsSlogK211.Tables(0).Rows.Count - 1
                Dim drK211 As DataRow = dtK211.NewRow
                drK211.ItemArray() = New Object() {dsSlogK211.Tables(0).Rows(k).Item(0), dsSlogK211.Tables(0).Rows(k).Item(1), "U"}
                dtK211.Rows.Add(drK211)
            Next

        Catch sqlex As SqlException
            Dim aa As String
            aa = sqlex.Message
        End Try


        '-------------------------------------- popunjava Grid UIC ---------------------------------------------------
        dsSlogUic.Clear()
        Try

            Dim adSlogUic As New SqlDataAdapter(" SELECT dbo.SlogUic.Uprava, dbo.SlogUic.UlPrelaz, dbo.SlogUic.IzPrelaz, dbo.SlogUic.Valuta, (dbo.SlogUic.PrevFR+dbo.SlogUic.PrevUP), " _
                                              & " dbo.SlogUic.Nak1, dbo.SlogUic.Iznos1, dbo.SlogUic.Nak2, dbo.SlogUic.Iznos2, dbo.SlogUic.Nak3, dbo.SlogUic.Iznos3, " _
                                              & " dbo.SlogUic.SifraGS, dbo.SlogUic.PredujamVal, dbo.SlogUic.Predujam, dbo.SlogUic.tlValuta, dbo.SlogUic.tlFranko, dbo.SlogUic.tlUpuceno, " _
                                              & " dbo.SlogUic.StavkaUIC, dbo.SlogUic.SifraPP, dbo.SlogUic.tlUpucenoDin, dbo.SlogUic.Operater " _
                                              & " FROM SlogUIC " _
                                              & " WHERE  (dbo.SlogUic.RecID = '" & UpdRecID & "') AND (dbo.SlogUic.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

            Dim tmp_pp As String = ""
            m_UicPrevozniPut = ""
            ii2 = adSlogUic.Fill(dsSlogUic)

            For k As Int16 = 0 To dsSlogUic.Tables(0).Rows.Count - 1
                Dim drUic As DataRow = dtUic.NewRow
                drUic.ItemArray() = New Object() {dsSlogUic.Tables(0).Rows(k).Item(0), dsSlogUic.Tables(0).Rows(k).Item(20), dsSlogUic.Tables(0).Rows(k).Item(1), dsSlogUic.Tables(0).Rows(k).Item(2), dsSlogUic.Tables(0).Rows(k).Item(3), dsSlogUic.Tables(0).Rows(k).Item(4), _
                                                  dsSlogUic.Tables(0).Rows(k).Item(5), dsSlogUic.Tables(0).Rows(k).Item(6), dsSlogUic.Tables(0).Rows(k).Item(7), dsSlogUic.Tables(0).Rows(k).Item(8), dsSlogUic.Tables(0).Rows(k).Item(9), dsSlogUic.Tables(0).Rows(k).Item(10), _
                                                  dsSlogUic.Tables(0).Rows(k).Item(11), dsSlogUic.Tables(0).Rows(k).Item(12), dsSlogUic.Tables(0).Rows(k).Item(13), dsSlogUic.Tables(0).Rows(k).Item(14), dsSlogUic.Tables(0).Rows(k).Item(15), dsSlogUic.Tables(0).Rows(k).Item(16), _
                                                  "U", dsSlogUic.Tables(0).Rows(k).Item(17), dsSlogUic.Tables(0).Rows(k).Item(19), 0, 0, 0, 0, 0}
                dtUic.Rows.Add(drUic)

                tmp_pp = dsSlogUic.Tables(0).Rows(k).Item(18)
                m_UicPrevozniPut = m_UicPrevozniPut & dsSlogUic.Tables(0).Rows(k).Item(0)
            Next

            '--------------- okrenuti smer zbog izvoza ----------------
            If IzborSaobracaja = "3" Then
                Dim aString As String = ""
                Dim aString1 As String = ""
                Dim ii As Int16 = 0

                For ii = (Len(m_UicPrevozniPut) / 2) To 1 Step -1
                    aString = aString & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2)
                Next

                For ii = 1 To (Len(m_UicPrevozniPut) / 2)
                    aString1 = aString1 & " " & Microsoft.VisualBasic.Mid(aString, 2 * ii - 1, 2)
                Next

                m_UicPrevozniPut = aString1

            Else
                Dim aString1 As String = ""
                Dim ii As Int16 = 0

                For ii = 1 To (Len(m_UicPrevozniPut) / 2)
                    aString1 = aString1 & " " & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2)
                Next

                m_UicPrevozniPut = aString1

            End If

            m_UicPrevozniPut = tmp_pp & " > " & m_UicPrevozniPut

        Catch sqlex As SqlException
            Dim aa As String
            aa = sqlex.Message
        End Try


    End Sub
    Public Sub BrisiTLUI(ByVal _RecID As Int32, ByVal _Stanica As String, _
                       ByRef _mRetVal As Int32)

        _mRetVal = 0
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.spBrisanjeTLUI", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ippRecID", SqlDbType.Int, 4))
        inRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ippRecID").Value = _RecID

        Dim inStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ippStanica", SqlDbType.Char, 5))
        inStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ippStanica").Value = _Stanica

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@RetVal", SqlDbType.Int, 4))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@RetVal").Value = _mRetVal

        Try
            spKomanda.ExecuteScalar()
            _mRetVal = spKomanda.Parameters("@RetVal").Value

            'If _mRetVal > 0 Then
            '    MsgBox("Obrisao")
            'End If

        Catch ex As Exception
            _mRetVal = Err.Description & " Greska u programu!"
        Catch sqlexp As Exception
            _mRetVal = sqlexp.Message & " SQL greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub Izjava_Ex()
        Dim UpravaRed As DataRow
        Dim i_Prevoznina As Decimal = 0
        Dim suma_Nak As Decimal = 0
        Dim i_TotalNak As String = ""
        Dim i_Pronasao As Int32 = 0

        'mSifraIzjave 1,2
        'mUkljucujuci - pr. 42
        'mDoPrelaza - pr. 711

        'dodati ako nista nije cekirano!
        Dim i_Granica As Decimal = 10  'bilo 0 pre izmene cmbfdp!!!!!!!!!!!!!!!!!!!!!!!!!!!! 4.3.2009
        For Each UpravaRed In dtUic.Rows
            If UpravaRed.Item("Ulaz") = mDoPrelaza Then
                i_Granica = UpravaRed.Item("rbr")
            End If
        Next

        For Each UpravaRed In dtUic.Rows

            UpravaRed.Item("PF") = 0
            UpravaRed.Item("PU") = 0
            UpravaRed.Item("NF") = 0
            UpravaRed.Item("NU") = 0
            UpravaRed.Item("DU") = 0

            If mSifraIzjave = 1 Then ' ------------------------ F R A N K O prevoznina ----------------------------
                i_Prevoznina = UpravaRed.Item("Prevoznina")

                If UpravaRed.Item("rbr") < i_Granica Then  ' F R A N K O do granicnog prelaza bilo <=

                    UpravaRed.Item("PF") = i_Prevoznina ' prevoznina franko
                    UpravaRed.Item("PU") = 0            ' prevoznina upuceno = 0 

                    If upis_mFrNaknade <> "" Then              ' F R A N K O naknade do granicnog prelaza
                        ''If Microsoft.VisualBasic.Left(mUkljucujuci, 1) = "0" Then
                        ''If Microsoft.VisualBasic.Trim(mUkljucujuci) = "0" Then

                        If Microsoft.VisualBasic.Trim(upis_mFrNaknade) = "0" Then
                            UpravaRed.Item("NF") = 0
                            UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")
                        Else
                            i_Pronasao = -1
                            i_TotalNak = UpravaRed.Item("Nak1")
                            For ii As Int16 = 0 To 4
                                If mUkljucujuci(ii) = i_TotalNak Then
                                    i_Pronasao = 1
                                    Exit For
                                End If
                            Next
                            If i_Pronasao >= 0 Then
                                UpravaRed.Item("NF") = UpravaRed.Item("Iznos1")
                                UpravaRed.Item("NU") = UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")
                            Else
                                i_Pronasao = -1
                                i_TotalNak = UpravaRed.Item("Nak2")
                                For ii As Int16 = 0 To 4
                                    If mUkljucujuci(ii) = i_TotalNak Then
                                        i_Pronasao = 1
                                        Exit For
                                    End If
                                Next
                                If i_Pronasao >= 0 Then
                                    UpravaRed.Item("NF") = UpravaRed.Item("Iznos2")
                                    UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos3")

                                Else
                                    i_Pronasao = -1
                                    i_TotalNak = UpravaRed.Item("Nak2")
                                    For ii As Int16 = 0 To 4
                                        If mUkljucujuci(ii) = i_TotalNak Then
                                            i_Pronasao = 1
                                            Exit For
                                        End If
                                    Next
                                    If i_Pronasao >= 0 Then
                                        UpravaRed.Item("NF") = UpravaRed.Item("Iznos3")
                                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2")
                                    Else
                                        UpravaRed.Item("NF") = 0
                                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")
                                    End If
                                End If
                            End If
                            '---------------------------------
                        End If
                    Else
                        UpravaRed.Item("NF") = 0
                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")
                    End If
                Else ' --------------------------------------- U P U C E N O --------------------------------------
                    UpravaRed.Item("PF") = 0
                    UpravaRed.Item("PU") = i_Prevoznina

                    UpravaRed.Item("NF") = 0
                    UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                End If

            ElseIf mSifraIzjave = 2 Then ' ------------------------------------- I N C O T E R M S -------------------------------------
                i_Prevoznina = UpravaRed.Item("Prevoznina")
                suma_Nak = suma_Nak + UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                If mIncoterms = "EXW" Then
                    UpravaRed.Item("PF") = 0
                    UpravaRed.Item("PU") = i_Prevoznina
                    UpravaRed.Item("NF") = 0
                    UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                ElseIf mIncoterms = "FCA" Then
                    UpravaRed.Item("PF") = 0
                    UpravaRed.Item("PU") = i_Prevoznina

                ElseIf mIncoterms = "CPT" Then
                    UpravaRed.Item("PU") = 0
                    UpravaRed.Item("PF") = i_Prevoznina

                    If UpravaRed.Item("Nak1") = "41" Or UpravaRed.Item("Nak1") = "42" Or _
                       UpravaRed.Item("Nak1") = "46" Or UpravaRed.Item("Nak1") = "45" Or _
                       UpravaRed.Item("Nak1") = "60" Or UpravaRed.Item("Nak1") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1")

                    End If
                    If UpravaRed.Item("Nak2") = "41" Or UpravaRed.Item("Nak2") = "42" Or _
                       UpravaRed.Item("Nak2") = "46" Or UpravaRed.Item("Nak2") = "45" Or _
                       UpravaRed.Item("Nak2") = "60" Or UpravaRed.Item("Nak2") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("NU") + UpravaRed.Item("Iznos2")

                    End If
                    If UpravaRed.Item("Nak3") = "41" Or UpravaRed.Item("Nak3") = "42" Or _
                       UpravaRed.Item("Nak3") = "46" Or UpravaRed.Item("Nak3") = "45" Or _
                       UpravaRed.Item("Nak3") = "60" Or UpravaRed.Item("Nak3") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("NU") + UpravaRed.Item("Iznos3")
                    End If

                    UpravaRed.Item("NF") = suma_Nak - UpravaRed.Item("NU")

                ElseIf mIncoterms = "CIP" Then
                    UpravaRed.Item("PU") = 0
                    UpravaRed.Item("PF") = i_Prevoznina

                    If UpravaRed.Item("Nak1") = "41" Or UpravaRed.Item("Nak1") = "42" Or _
                       UpravaRed.Item("Nak1") = "46" Or UpravaRed.Item("Nak1") = "45" Or _
                       UpravaRed.Item("Nak1") = "60" Or UpravaRed.Item("Nak1") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("Iznos1")

                    End If
                    If UpravaRed.Item("Nak2") = "41" Or UpravaRed.Item("Nak2") = "42" Or _
                       UpravaRed.Item("Nak2") = "46" Or UpravaRed.Item("Nak2") = "45" Or _
                       UpravaRed.Item("Nak2") = "60" Or UpravaRed.Item("Nak2") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("NU") + UpravaRed.Item("Iznos2")

                    End If
                    If UpravaRed.Item("Nak3") = "41" Or UpravaRed.Item("Nak3") = "42" Or _
                       UpravaRed.Item("Nak3") = "46" Or UpravaRed.Item("Nak3") = "45" Or _
                       UpravaRed.Item("Nak3") = "60" Or UpravaRed.Item("Nak3") = "61" Then

                        UpravaRed.Item("NU") = UpravaRed.Item("NU") + UpravaRed.Item("Iznos3")
                    End If

                    UpravaRed.Item("NF") = suma_Nak - UpravaRed.Item("NU")

                ElseIf mIncoterms = "DAF" Then

                ElseIf mIncoterms = "DDU" Then

                ElseIf mIncoterms = "DDP" Then
                    UpravaRed.Item("PU") = 0
                    UpravaRed.Item("PF") = i_Prevoznina
                    UpravaRed.Item("NU") = 0
                    UpravaRed.Item("NF") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                End If

            ElseIf mSifraIzjave = 3 Then                     'Sve je upuceno
                i_Prevoznina = UpravaRed.Item("Prevoznina")
                UpravaRed.Item("PF") = 0
                UpravaRed.Item("PU") = i_Prevoznina
                UpravaRed.Item("NF") = 0
                UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

            End If

        Next
    End Sub
    Public Sub IzjavaZs_Ex()
        Dim i_TotalNak As String = ""
        Dim i_Pronasao As Int32 = -1

        Dim NaknadaRed As DataRow
        Dim f_prev As Decimal = 0
        Dim u_prev As Decimal = 0
        Dim f_nak As Decimal = 0
        Dim u_nak As Decimal = 0
        Dim u_din As Decimal = 0
        Dim suma_nak As Decimal = 0

        If dtNaknade.Rows.Count > 0 Then
            For Each NaknadaRed In dtNaknade.Rows
                '1. franko prevoznina
                '   ukljucivo naknade
                '   do prelaza - ima ili nema podatka
                '                ako je   711: sve naknade ZS su upucene
                '                ako nema    : franko su one naknade koje su jednake navedenoj naknadi u izjavi,
                '                              ostale naknade su upucene

                '2. Incoterms

                If mSifraIzjave = 1 Then        ' ----------------- FRANKO OK
                    If mDoPrelaza = "" Then
                        f_prev = mPrevoznina
                        u_prev = 0

                        If Microsoft.VisualBasic.Trim(upis_mFrNaknade) = "0" Then
                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                            u_nak = 0
                        ElseIf Microsoft.VisualBasic.Trim(upis_mFrNaknade) = "" Then
                            f_nak = 0
                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        Else
                            i_Pronasao = -1
                            i_TotalNak = NaknadaRed.Item("Sifra")
                            For ii As Int16 = 0 To 4
                                If mUkljucujuci(ii) = i_TotalNak Then
                                    i_Pronasao = 1
                                    Exit For
                                End If
                            Next

                            If i_Pronasao >= 0 Then
                                f_nak = f_nak + NaknadaRed.Item("Iznos")
                            Else
                                u_nak = u_nak + NaknadaRed.Item("Iznos")
                            End If

                        End If
                    Else
                        f_prev = mPrevoznina
                        u_prev = 0

                        If Microsoft.VisualBasic.Trim(upis_mFrNaknade) = "0" Then
                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                            u_nak = 0
                        Else
                            i_Pronasao = -1
                            i_TotalNak = NaknadaRed.Item("Sifra")
                            For ii As Int16 = 0 To 4
                                If mUkljucujuci(ii) = i_TotalNak Then
                                    i_Pronasao = 1
                                    Exit For
                                End If
                            Next

                            If i_Pronasao >= 0 Then
                                f_nak = f_nak + NaknadaRed.Item("Iznos")
                            Else
                                u_nak = u_nak + NaknadaRed.Item("Iznos")
                            End If
                        End If

                    End If
                ElseIf mSifraIzjave = 2 Then    ' ---------------- INCOTERMS
                    If mIncoterms = "EXW" Then
                        f_prev = 0
                        u_prev = mPrevoznina
                        f_nak = 0
                        u_nak = u_nak + NaknadaRed.Item("Iznos")
                    ElseIf mIncoterms = "FCA" Then
                        If NaknadaRed.Item("Sifra") = "40" Or NaknadaRed.Item("Sifra") = "46" Or _
                           NaknadaRed.Item("Sifra") = "45" Or _
                           NaknadaRed.Item("Sifra") = "60" Or NaknadaRed.Item("Sifra") = "61" Then

                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                        Else
                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        End If
                        f_prev = 0
                        u_prev = mPrevoznina
                    ElseIf mIncoterms = "CPT" Then
                        If NaknadaRed.Item("Sifra") = "41" Or NaknadaRed.Item("Sifra") = "42" Or _
                           NaknadaRed.Item("Sifra") = "46" Or NaknadaRed.Item("Sifra") = "45" Or _
                           NaknadaRed.Item("Sifra") = "60" Or NaknadaRed.Item("Sifra") = "61" Then

                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        Else
                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                        End If
                        f_prev = mPrevoznina
                        u_prev = 0

                    ElseIf mIncoterms = "CIP" Then
                        If NaknadaRed.Item("Sifra") = "41" Or NaknadaRed.Item("Sifra") = "42" Or _
                           NaknadaRed.Item("Sifra") = "46" Or NaknadaRed.Item("Sifra") = "45" Or _
                           NaknadaRed.Item("Sifra") = "60" Or NaknadaRed.Item("Sifra") = "61" Then

                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        Else
                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                        End If
                        f_prev = 0
                        u_prev = mPrevoznina

                    ElseIf mIncoterms = "DAF" Then 'do mesta upisanog u box
                        f_prev = mPrevoznina
                        u_prev = 0
                        f_nak = f_nak + NaknadaRed.Item("Iznos")
                        u_nak = 0

                    ElseIf mIncoterms = "DDU" Then
                        If NaknadaRed.Item("Sifra") = "42" Or _
                           NaknadaRed.Item("Sifra") = "46" Or NaknadaRed.Item("Sifra") = "45" Or _
                           NaknadaRed.Item("Sifra") = "60" Or NaknadaRed.Item("Sifra") = "61" Then

                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        Else
                            f_nak = f_nak + NaknadaRed.Item("Iznos")
                        End If
                        f_prev = mPrevoznina
                        u_prev = 0
                    ElseIf mIncoterms = "DDP" Then
                        f_prev = mPrevoznina
                        u_prev = 0
                        f_nak = f_nak + NaknadaRed.Item("Iznos")
                        u_nak = 0
                    End If
                ElseIf mSifraIzjave = 3 Then    ' ---------------- Sve upuceno
                    f_prev = 0
                    u_prev = mPrevoznina
                    u_nak = u_nak + NaknadaRed.Item("Iznos")
                    f_nak = 0
                End If
            Next
        Else
            f_nak = 0
            u_nak = 0

            If mSifraIzjave = 1 Then        ' FRANKO prevoznina
                u_prev = 0
                f_prev = mPrevoznina
            ElseIf mSifraIzjave = 2 Then    ' INCOTERMS
                If mIncoterms = "EXW" Then
                    f_prev = 0
                    u_prev = mPrevoznina
                ElseIf mIncoterms = "FCA" Then
                    f_prev = 0
                    u_prev = mPrevoznina
                ElseIf mIncoterms = "CPT" Then
                    f_prev = mPrevoznina
                    u_prev = 0
                ElseIf mIncoterms = "CIP" Then
                    f_prev = 0
                    u_prev = mPrevoznina
                ElseIf mIncoterms = "DAF" Then 'do mesta upisanog u box
                    f_prev = mPrevoznina
                    u_prev = 0
                ElseIf mIncoterms = "DDU" Then
                    f_prev = mPrevoznina
                    u_prev = 0
                ElseIf mIncoterms = "DDP" Then
                    f_prev = mPrevoznina
                    u_prev = 0
                End If
            End If
        End If

        Dim mOutKurs As Decimal = 0
        Dim strRetVal As String = ""

        'NadjiKurs(bValuta, "1", mOtpDatum, mOutKurs, strRetVal)
        'If mBrojUg = "200379" Then 'Sartid
        '    NadjiKurs(bValuta, "3", mOtpDatum, mOutKurs, strRetVal)
        'End If

        If IzborSaobracaja = "2" Then
            NadjiKurs(bValuta, "1", mPrDatum, mOutKurs, strRetVal)
            If mBrojUg = "200379" Then 'Sartid
                NadjiKurs(bValuta, "3", mPrDatum, mOutKurs, strRetVal)
            ElseIf mBrojUg = "517902" Then  'NIS
                NadjiKurs(bValuta, "3", mPrDatum, mOutKurs, strRetVal)
            ElseIf mBrojUg = "517903" Then  'NIS
                NadjiKurs(bValuta, "3", mPrDatum, mOutKurs, strRetVal)
            End If
        ElseIf IzborSaobracaja = "3" Then
            NadjiKurs(bValuta, "1", mOtpDatum, mOutKurs, strRetVal)
            If mBrojUg = "200379" Then 'Sartid
                NadjiKurs(bValuta, "3", mOtpDatum, mOutKurs, strRetVal)
            ElseIf mBrojUg = "517902" Then  'NIS
                NadjiKurs(bValuta, "3", mOtpDatum, mOutKurs, strRetVal)
            ElseIf mBrojUg = "517903" Then  'NIS
                NadjiKurs(bValuta, "3", mOtpDatum, mOutKurs, strRetVal)
            End If
        End If


        '--------------- zaokruzivanje za TEA tarifu -------------------
        Dim zaokruziIznos As Decimal = 0

        If (mTarifa = "68" Or kSifTar = 68) Or (Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" And mVrstaObracuna = "CO") Then
            zaokruziIznos = f_prev + f_nak
            upis_f_suma = zaokruziIznos

            'bZaokruziNaDeseteNavise(u_din)

            '''''zaokruziIznos = dtUicEx.Compute("SUM(FSuma)", String.Empty)
            '''''bZaokruziNaCeleNavise(zaokruziIznos)
            '''''upis_f_suma = zaokruziIznos

        Else
            zaokruziIznos = f_prev + f_nak
            upis_f_suma = zaokruziIznos

        End If
        '---------------- end zaokruzivanje za TEA tarifu -------------------


        ''''''''''upis_f_suma = zaokruziIznos


        If zaokruziIznos > 0 Then
            u_din = zaokruziIznos * mOutKurs
            bZaokruziNaDeseteNavise(u_din)

        End If

        'Pretumbati Uic2 u UicEx
        dtUicEx.Rows.Add(New Object() {f_prev, f_nak, f_prev + f_nak, "72", bValuta, _
                                       u_prev, u_nak, u_prev + u_nak, u_din})

        Dim UpravaRed As DataRow
        For Each UpravaRed In dtUic2.Rows
            dtUicEx.Rows.Add(New Object() {UpravaRed.Item("FPrev"), UpravaRed.Item("FNak"), UpravaRed.Item("FSuma"), _
                                           UpravaRed.Item("Uprava"), UpravaRed.Item("Valuta"), _
                                           UpravaRed.Item("UPrev"), UpravaRed.Item("UNak"), UpravaRed.Item("USuma"), _
                                           UpravaRed.Item("UDinari")})
        Next

        upis_f_prev = f_prev
        upis_u_prev = u_prev
        upis_f_nak = f_nak
        upis_u_nak = u_nak

        upis_f_prev_din = f_prev * mOutKurs
        bZaokruziNaDeseteNavise(upis_f_prev_din)
        upis_u_prev_din = u_prev * mOutKurs
        bZaokruziNaDeseteNavise(upis_u_prev_din)
        upis_f_nak_din = f_nak * mOutKurs
        bZaokruziNaDeseteNavise(upis_f_nak_din)
        upis_u_nak_din = u_nak * mOutKurs
        bZaokruziNaDeseteNavise(upis_u_nak_din)

        upis_u_din = u_din 'TLSUMAFRDIN - FRANKO DINARI, IZVOZ


    End Sub
    Public Sub IzjavaZs_CO()

        Dim NaknadaRed As DataRow
        Dim f_prev As Decimal = 0
        Dim u_prev As Decimal = 0
        Dim f_nak As Decimal = 0
        Dim u_nak As Decimal = 0
        Dim u_din As Decimal = 0
        Dim suma_nak As Decimal = 0

        f_prev = mPrevoznina
        u_prev = 0

        If dtNaknade.Rows.Count > 0 Then
            For Each NaknadaRed In dtNaknade.Rows
                If NaknadaRed.Item("Obracun") = "R" Then
                    u_nak = u_nak + NaknadaRed.Item("Iznos")
                Else
                    f_nak = f_nak + NaknadaRed.Item("Iznos")
                End If
            Next
        End If

        Dim mOutKurs As Decimal = 0.0
        Dim strRetVal As String = ""

        NadjiKurs(bValuta, "1", mPrDatum, mOutKurs, strRetVal)

        Dim zaokruziIznos As Decimal = 0
        zaokruziIznos = u_nak

        upis_f_suma = f_prev + f_nak
        upis_u_suma = zaokruziIznos

        If zaokruziIznos > 0 Then
            u_din = zaokruziIznos * mOutKurs
            bZaokruziNaDeseteNavise(u_din)
        End If

        dtUic2.Rows.Add(New Object() {f_prev, f_nak, f_prev + f_nak, "72", bValuta, _
                                      u_prev, u_nak, u_prev + u_nak, u_din})

        upis_f_prev = f_prev
        upis_u_prev = u_prev
        upis_f_nak = f_nak
        upis_u_nak = u_nak

        upis_f_prev_din = f_prev * mOutKurs
        bZaokruziNaDeseteNavise(upis_f_prev_din)

        upis_u_prev_din = u_prev * mOutKurs
        bZaokruziNaDeseteNavise(upis_u_prev_din)

        upis_f_nak_din = f_nak * mOutKurs
        bZaokruziNaDeseteNavise(upis_f_nak_din)

        upis_u_nak_din = u_nak * mOutKurs
        bZaokruziNaDeseteNavise(upis_u_nak_din)

        upis_u_din = u_din 'TLSUMAUPDIN - UPUCENO DINARI, UVOZ

    End Sub
    Public Sub IzjavaZs_Ex_CO()

        Dim NaknadaRed As DataRow
        Dim f_prev As Decimal = 0
        Dim u_prev As Decimal = 0
        Dim f_nak As Decimal = 0
        Dim u_nak As Decimal = 0
        Dim u_din As Decimal = 0
        Dim suma_nak As Decimal = 0

        f_prev = 0
        u_prev = mPrevoznina

        If dtNaknade.Rows.Count > 0 Then
            For Each NaknadaRed In dtNaknade.Rows
                If NaknadaRed.Item("Obracun") = "R" Then
                    f_nak = f_nak + NaknadaRed.Item("Iznos")
                Else
                    u_nak = u_nak + NaknadaRed.Item("Iznos")
                End If
            Next
        End If

        Dim mOutKurs As Decimal = 0
        Dim strRetVal As String = ""

        NadjiKurs(bValuta, "1", mOtpDatum, mOutKurs, strRetVal)

        Dim zaokruziIznos As Decimal = 0
        zaokruziIznos = f_nak

        upis_f_suma = zaokruziIznos
        upis_u_suma = u_prev + u_nak

        'zbog CO 310892
        If (mTarifa = "68" Or kSifTar = 68) Then
            zaokruziIznos = u_prev + u_nak
            bZaokruziNaCeleNavise(zaokruziIznos)
            upis_f_suma = zaokruziIznos 'f_suma jer je tako kod TEA tarife - franko 

        Else
            If (Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" And mVrstaObracuna = "CO") Or _
               (Microsoft.VisualBasic.Right(mBrojUg, 2) = "93" And mVrstaObracuna = "CO") Then

                zaokruziIznos = u_prev + u_nak
                bZaokruziNaCeleNavise(zaokruziIznos)
                upis_f_suma = zaokruziIznos 'f_suma jer je tako kod TEA tarife - franko 
            Else
                zaokruziIznos = f_prev + f_nak
                upis_f_suma = zaokruziIznos
            End If
        End If
        'end 

        u_din = zaokruziIznos * mOutKurs
        bZaokruziNaDeseteNavise(u_din)

        If zaokruziIznos > 0 Then
            If (Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" And mVrstaObracuna = "CO") Or _
               (Microsoft.VisualBasic.Right(mBrojUg, 2) = "93" And mVrstaObracuna = "CO") Then

                'novo!
                u_din = (f_prev + f_nak) * mOutKurs                '' da li je dobro-zašto f_prev?: u_din = (f_prev + f_nak) * mOutKurs
                '''''''''''''''''u_din = (u_prev + u_nak) * mOutKurs

                bZaokruziNaDeseteNavise(u_din)
                'end novo
            Else
                u_din = zaokruziIznos * mOutKurs
                bZaokruziNaDeseteNavise(u_din)
            End If
        End If

        'Pretumbati Uic2 u UicEx
        dtUicEx.Rows.Add(New Object() {f_prev, f_nak, f_prev + f_nak, "72", bValuta, _
                                       u_prev, u_nak, u_prev + u_nak, u_din})

        Dim UpravaRed As DataRow
        For Each UpravaRed In dtUic2.Rows
            dtUicEx.Rows.Add(New Object() {UpravaRed.Item("FPrev"), UpravaRed.Item("FNak"), UpravaRed.Item("FSuma"), _
                                           UpravaRed.Item("Uprava"), UpravaRed.Item("Valuta"), _
                                           UpravaRed.Item("UPrev"), UpravaRed.Item("UNak"), UpravaRed.Item("USuma"), _
                                           UpravaRed.Item("UDinari")})
        Next

        upis_f_prev = f_prev
        upis_u_prev = u_prev
        upis_f_nak = f_nak
        upis_u_nak = u_nak

        upis_f_prev_din = f_prev * mOutKurs
        bZaokruziNaDeseteNavise(upis_f_prev_din)

        upis_u_prev_din = u_prev * mOutKurs
        bZaokruziNaDeseteNavise(upis_u_prev_din)

        upis_f_nak_din = f_nak * mOutKurs
        bZaokruziNaDeseteNavise(upis_f_nak_din)

        upis_u_nak_din = u_nak * mOutKurs
        bZaokruziNaDeseteNavise(upis_u_nak_din)

        upis_u_din = u_din

    End Sub
    Public Sub NadjiTovarniListDel(ByVal exOtpUprava As String, ByVal bOtpStanica As String, _
                                   ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                                   ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                                   ByRef bRetVal As String)

        bRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL2Del", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulazUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = bDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID


        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            bRecID = spKomanda.Parameters("@outRecID").Value
            UpdRecID = bRecID
            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdStanicaRecID = bStanicaRecID

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub Din2Eur(ByVal inDinariTL As Decimal, ByRef outEurTL As Decimal)
        Dim mOutKurs As Decimal = 0
        Dim strRetVal As String = ""

        If mBrojUg = "200379" Then 'Sartid
            NadjiKurs("17", "3", mOtpDatum, mOutKurs, strRetVal)
        Else
            NadjiKurs("17", "1", mOtpDatum, mOutKurs, strRetVal)
        End If

        outEurTL = inDinariTL / mOutKurs
        bZaokruziNaDeseteNavise(outEurTL)
    End Sub
    Public Sub NadjiTLZaIstuNajavuUI(ByVal exOtpUprava As String, ByVal bOtpStanica As String, _
                                     ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                                     ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                                     ByRef bPrUprava As String, ByRef bPrStanica As String, _
                                     ByRef bRetVal As String)

        bRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL2NajavaUI", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulazUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = bDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim exPrUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrUprava", SqlDbType.Char, 4))
        exPrUprava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrUprava").Value = bPrUprava

        Dim exPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        exPrStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = bPrStanica
        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            bRecID = spKomanda.Parameters("@outRecID").Value
            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdRecID = bRecID
            UpdStanicaRecID = bStanicaRecID

            bPrUprava = spKomanda.Parameters("@outPrUprava").Value
            bPrStanica = spKomanda.Parameters("@outPrStanica").Value

            'popunjava 3 grida

            '---------------- popunjava 3 grida -----------------------
            IzmenaTLGranica()
            '----------------------------------------------------------

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub NadjiTovarniListDelUI(ByVal exOtpUprava As String, ByVal bOtpStanica As String, _
                                     ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                                     ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef bNajava As String, ByRef bUgovor As String, _
                                     ByRef bRetVal As String)

        bRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL2DelUI", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulazUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = bDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim exNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNajava", SqlDbType.Char, 10))
        exNajava.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNajava").Value = bNajava

        Dim exUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        exUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            bRecID = spKomanda.Parameters("@outRecID").Value
            UpdRecID = bRecID
            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdStanicaRecID = bStanicaRecID

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub UskladiTipKola()
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim tmp_PraznaKola As String
        Dim tmp_Lokomotiva As String

        For Each KolaRed In dtKola.Rows
            tmp_PraznaKola = "No"
            tmp_Lokomotiva = "No"

            mIBK = KolaRed.Item("IndBrojKola")

            For Each NHMRed In dtNhm.Rows
                If mIBK = NHMRed.Item("IndBrojKola") Then
                    If Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9922" Then
                        tmp_PraznaKola = "Yes"
                    Else
                        tmp_PraznaKola = "No"
                    End If
                    If Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "8601" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "8602" Then
                        tmp_Lokomotiva = "Yes"
                    End If


                    If KolaRed.Item("Vlasnik") = "Z" Then
                        If KolaRed.Item("Vrsta") = "O" Then
                            KolaRed.Item("Tip") = "1"
                        Else
                            KolaRed.Item("Tip") = "2"
                        End If
                    Else
                        If KolaRed.Item("Vrsta") = "O" Then
                            If tmp_PraznaKola = "Yes" Then
                                KolaRed.Item("Tip") = "7"
                            Else
                                KolaRed.Item("Tip") = "3"
                            End If
                        Else
                            If tmp_PraznaKola = "Yes" Then
                                KolaRed.Item("Tip") = "7"
                            Else
                                KolaRed.Item("Tip") = "4"
                            End If
                        End If
                    End If
                    If tmp_Lokomotiva = "Yes" Then
                        KolaRed.Item("Tip") = "1"
                    End If

                End If
            Next
        Next

    End Sub

    Public Sub Kola_Validating()
        Dim KolaRed As DataRow

        'If DbVeza.State = ConnectionState.Closed Then
        '    DbVeza.Open()
        'End If

        For Each KolaRed In dtKola.Rows
            mIBK = KolaRed.Item("IndBrojKola")

            Dim rv As String = ""
            Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & mIBK & "'")
            Dim nmNasaoIKP As Boolean = False

            ''-- Novo 09/09/2013 : ukljucivanje tabele IKP ------------------------------------------------------------------------------------
            If nmNasaoIKP = False Then
                If DbVeza.State = ConnectionState.Closed Then
                    DbVeza.Open()
                End If

                Dim uspKomanda As New SqlClient.SqlCommand("spNadjiSveIzIBK", DbVeza)
                uspKomanda.CommandType = CommandType.StoredProcedure

                Dim upIBK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
                upIBK.Direction = ParameterDirection.Input
                uspKomanda.Parameters("@inIBK").Value = mIBK

                Dim ipSkrUprava As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSkrUprava", SqlDbType.Char, 6))
                ipSkrUprava.Direction = ParameterDirection.Output

                Dim ipVlasnistvo As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVlasnistvo", SqlDbType.Char, 1))
                ipVlasnistvo.Direction = ParameterDirection.Output

                Dim ipRIV As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRIV", SqlDbType.Char, 1))
                ipRIV.Direction = ParameterDirection.Output

                Dim ipSerija As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSerija", SqlDbType.Char, 11))
                ipSerija.Direction = ParameterDirection.Output

                Dim ipBrojOsovina As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrojOsovina", SqlDbType.Int))
                ipBrojOsovina.Direction = ParameterDirection.Output

                Dim ipVrsta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
                ipVrsta.Direction = ParameterDirection.Output

                Dim ipKontrBroj As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBroj", SqlDbType.Int))
                ipKontrBroj.Direction = ParameterDirection.Output

                Dim ipKontrBrojOK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBrojOK", SqlDbType.Char, 1))
                ipKontrBrojOK.Direction = ParameterDirection.Output

                Dim ipKolaICFIzuzeta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolaICFIzuzeta", SqlDbType.Char, 1))
                ipKolaICFIzuzeta.Direction = ParameterDirection.Output

                Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.NVarChar, 100))
                ipPovratnaVrednost.Direction = ParameterDirection.Output

                Try
                    uspKomanda.ExecuteScalar()

                    If Len(Trim(uspKomanda.Parameters("@outVlasnistvo").Value)) > 0 Then
                        KolaRed.Item("Vlasnik") = uspKomanda.Parameters("@outVlasnistvo").Value
                    Else
                        KolaRed.Item("Vlasnik") = "Z"
                    End If

                    If Len(Trim(uspKomanda.Parameters("@outSerija").Value)) > 0 Then
                        KolaRed.Item("Serija") = uspKomanda.Parameters("@outSerija").Value
                    End If

                    If uspKomanda.Parameters("@outBrojOsovina").Value > 0 Then
                        KolaRed.Item("Osovine") = uspKomanda.Parameters("@outBrojOsovina").Value
                    End If

                    If uspKomanda.Parameters("@outVrsta").Value = "1" Then
                        KolaRed.Item("Vrsta") = "O"
                    Else
                        KolaRed.Item("Vrsta") = "S"
                    End If
                Finally
                    DbVeza.Close()
                    uspKomanda.Dispose()
                End Try

                ''''    ubacila 24.4   ''''
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                End If

                Dim nmKBOK As Boolean = True

                If nmKBOK = True Then
                    Dim uspKomanda1 As New SqlClient.SqlCommand("nmNadjiIBK_T", OkpDbVeza)
                    'Dim uspKomanda1 As New SqlClient.SqlCommand("nmNadjiIBK", OkpDbVeza)
                    uspKomanda1.CommandType = CommandType.StoredProcedure

                    Dim upIBK1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
                    upIBK1.Direction = ParameterDirection.Input
                    uspKomanda1.Parameters("@inIBK").Value = mIBK

                    Dim upDatum As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime, 8))
                    upDatum.Direction = ParameterDirection.Input
                    uspKomanda1.Parameters("@inDatum").Value = mDatumKalk

                    Dim ipSkrUprava1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outUprava", SqlDbType.Char, 6))
                    ipSkrUprava1.Direction = ParameterDirection.Output

                    Dim ipTara1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outTara", SqlDbType.Int))
                    ipTara1.Direction = ParameterDirection.Output

                    Dim ipSerija1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outSerija", SqlDbType.Char, 11))
                    ipSerija1.Direction = ParameterDirection.Output

                    Dim ipBrojOsovina1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outOsovine", SqlDbType.Int))
                    ipBrojOsovina1.Direction = ParameterDirection.Output

                    Dim ipVlasnistvo1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVlasnik", SqlDbType.Char, 1))
                    ipVlasnistvo1.Direction = ParameterDirection.Output

                    Dim ipVrsta1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
                    ipVrsta1.Direction = ParameterDirection.Output

                    Dim ipPovratnaVrednost1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
                    ipPovratnaVrednost1.Direction = ParameterDirection.Output

                    Try
                        uspKomanda1.ExecuteScalar()

                        mVlasnik = uspKomanda1.Parameters("@outVlasnik").Value

                        ' proba 5.8.2015
                        KolaRed.Item("Vlasnik") = mVlasnik
                        ' proba 5.8.2015

                        nmNasaoIKP = True
                    Catch Exp As Exception
                        nmNasaoIKP = False
                    Finally
                        OkpDbVeza.Close()
                        uspKomanda1.Dispose()
                    End Try
                End If
                ''''    ubacila 24.4   ''''
            End If
        Next

    End Sub

    Public Sub NadjiTLpr1(ByVal bPrStanica As String, ByVal bPrBroj As Int32, _
                        ByVal bObrGodina As String, ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                        ByRef bRetVal As String)

        bRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTLpr1", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrStanica").Value = bPrStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrBroj").Value = bPrBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inGodina").Value = bObrGodina

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()
            bRecID = spKomanda.Parameters("@outRecID").Value
            If bRecID > 0 Then
                bRetVal = "Takav podatak vec postoji!"
            Else
                bRetVal = ""
            End If

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try



    End Sub
    Public Sub NadjiTLpr2(ByVal bPrStanica As String, ByVal bPrBroj As Int32, _
                        ByVal bObrGodina As String, ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                        ByRef bRetVal As String)

        bRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTLpr2", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrStanica").Value = bPrStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrBroj").Value = bPrBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inGodina").Value = bObrGodina

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()
            bRecID = spKomanda.Parameters("@outRecID").Value
            If bRecID > 0 Then
                bRetVal = "Takav podatak vec postoji!"
            Else
                bRetVal = ""
            End If

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Public Sub UskladiNaknadeFito()
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim NaknadeRed As DataRow

        If Microsoft.VisualBasic.Left(mBrojUg, 2) = "11" Or _
           Microsoft.VisualBasic.Left(mBrojUg, 2) = "12" Or _
           Microsoft.VisualBasic.Left(mBrojUg, 2) = "80" Or _
           Microsoft.VisualBasic.Left(mBrojUg, 2) = "81" Then

            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "01" Then
                '-----direktni voz
                For Each NHMRed In dtNhm.Rows
                    If Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "0502" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "0504" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "0505" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "0506" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "0507" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "0508" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "0510" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "0511" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1501" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1502" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1503" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1504" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1506" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1516" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1517" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1518" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1521" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1522" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 2) = "16" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1702" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1901" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1902" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1904" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "1905" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2102" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2103" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2104" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2105" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2106" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2202" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2301" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2309" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2501" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2835" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2936" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "2937" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3001" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3002" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3003" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3004" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3101" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3105" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3307" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3501" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3502" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3503" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3504" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3507" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3808" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "3917" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4101" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4102" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4103" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4104" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4105" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4106" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4107" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4112" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4113" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4115" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4301" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "4302" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "5003" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "5101" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "5102" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "5103" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "5105" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "6701" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9503" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9508" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9601" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9602" Or _
                    Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9705" Then

                        If NHMRed.Item("NHM") = "170290" Or NHMRed.Item("NHM") = "170410" Or _
                           NHMRed.Item("NHM") = "190120" Or NHMRed.Item("NHM") = "190540" Or _
                           NHMRed.Item("NHM") = "283539" Or NHMRed.Item("NHM") = "391721" Or _
                           NHMRed.Item("NHM") = "391723" Or NHMRed.Item("NHM") = "391732" Or _
                           NHMRed.Item("NHM") = "391740" Or NHMRed.Item("NHM") = "480439" Or _
                           NHMRed.Item("NHM") = "681099" Or NHMRed.Item("NHM") = "721391" Then
                        Else
                            Dim dtRow() As DataRow = dtNaknade.Select("Sifra = '45' AND IvicniBroj = '01'")
                            If dtRow.Length > 0 Then
                                'nista ne upisuje
                            Else
                                dtNaknade.NewRow()
                                'If mBrojUg = "100801" Then
                                '    dtNaknade.Rows.Add(New Object() {"45", "01", 10, 17, 1, 0, "0", "C", "I"})
                                'ElseIf mBrojUg = "100901" Then
                                '    dtNaknade.Rows.Add(New Object() {"45", "01", 15, 17, 1, 0, "0", "C", "I"})
                                'ElseIf mBrojUg = "101001" Then
                                '    dtNaknade.Rows.Add(New Object() {"45", "01", 15, 17, 1, 0, "0", "C", "I"})
                                'ElseIf mBrojUg = "101101" Or mBrojUg = "111101" Or mBrojUg = "121101" Then
                                '    dtNaknade.Rows.Add(New Object() {"45", "01", 9.5, 17, 1, 0, "0", "C", "I"})
                                'ElseIf mBrojUg = "101201" Or mBrojUg = "111201" Or mBrojUg = "121201" Then
                                '    dtNaknade.Rows.Add(New Object() {"45", "01", 9.5, 17, 1, 0, "0", "C", "I"})
                                'ElseIf mBrojUg = "101301" Or mBrojUg = "111301" Or mBrojUg = "121301" Then
                                '    dtNaknade.Rows.Add(New Object() {"45", "01", 9.5, 17, 1, 0, "0", "C", "I"})
                                'End If

                                dtNaknade.Rows.Add(New Object() {"45", "01", 9.5, 17, 1, 0, "0", "C", "I"})
                            End If
                        End If
                    End If
                Next
            End If

            '-----kontejnerski voz
            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "44" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "45" Then '801433, 811433?
                For Each NHMRed In dtNhm.Rows
                    If Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "0502" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "0504" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "0505" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "0506" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "0507" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "0508" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "0510" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "0511" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1501" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1502" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1503" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1504" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1506" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1516" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1517" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1518" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1521" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1522" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 2) = "16" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1702" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1901" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1902" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1904" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "1905" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2102" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2103" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2104" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2105" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2106" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2202" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2301" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2309" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2501" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2835" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2936" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "2937" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3001" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3002" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3003" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3004" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3101" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3105" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3307" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3501" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3502" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3503" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3504" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3507" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3808" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "3917" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4101" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4102" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4103" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4104" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4105" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4106" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4107" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4112" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4113" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4115" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4301" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "4302" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "5003" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "5101" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "5102" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "5103" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "5105" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "6701" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "9503" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "9508" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "9601" Or Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "9602" Or _
                       Microsoft.VisualBasic.Mid(NHMRed.Item("UTINHM"), 1, 4) = "9705" Then

                        If NHMRed.Item("UTINHM") = "170290" Or NHMRed.Item("UTINHM") = "170410" Or _
                           NHMRed.Item("UTINHM") = "190120" Or NHMRed.Item("UTINHM") = "190540" Or _
                           NHMRed.Item("UTINHM") = "283539" Or NHMRed.Item("UTINHM") = "391721" Or _
                           NHMRed.Item("UTINHM") = "391723" Or NHMRed.Item("UTINHM") = "391732" Or _
                           NHMRed.Item("UTINHM") = "391740" Or NHMRed.Item("UTINHM") = "480439" Or _
                           NHMRed.Item("UTINHM") = "681099" Or NHMRed.Item("UTINHM") = "721391" Then
                        Else
                            Dim dtRow() As DataRow = dtNaknade.Select("Sifra = '45' AND IvicniBroj = '01'")
                            If dtRow.Length > 0 Then
                                'nista ne upisuje
                            Else
                                dtNaknade.NewRow()
                                If mBrojUg = "101344" Or mBrojUg = "101345" Or mBrojUg = "981444" Then
                                    dtNaknade.Rows.Add(New Object() {"45", "01", 9.5, 17, 1, 0, "0", "C", "I"})
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        End If
    End Sub
    Public Sub UskladiNaknadePrekoracenje()
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim NaknadeRed As DataRow
        Dim PrekIznos As Decimal = 0

        For Each NHMRed In dtNhm.Rows
            PrekIznos = PrekIznos + Int(((NHMRed.Item("Masa") / 1000) * 0.5 + 0.099) * 10) / 10
        Next

        dtNaknade.NewRow()
        dtNaknade.Rows.Add(New Object() {"88", "01", PrekIznos, 17, 1, 0, "0", "C", "I"})

    End Sub

    Public Sub UskladiNaknadePoKolima()

        If mVrstaObracuna = "IC" Then
            Dim KolaRed As DataRow
            For Each KolaRed In dtKola.Rows
                KolaRed.Item("Naknada") = 0
                If KolaRed.Item("Vlasnik") = "Z" Then
                    If mBrojUg = "835745" Then          'Adriacombi
                        KolaRed.Item("Naknada") = 40
                    ElseIf mBrojUg = "835753" Or mBrojUg = "835758" Or mBrojUg = "844517" Or mBrojUg = "835771" Or mBrojUg = "955401" Then      'Adriacombi
                        KolaRed.Item("Naknada") = 36
                    ElseIf mBrojUg = "836902" Then      'Capo Nord Iris 
                        If KolaRed.Item("Osovine") > 4 Then
                            KolaRed.Item("Naknada") = 52
                        Else
                            KolaRed.Item("Naknada") = 26
                        End If
                    ElseIf mBrojUg = "844514" Then      'Adriacombi uvoz
                        If mPrStanica = "7225201" Or mPrStanica = "7216050" Or mPrStanica = "7215460" Or _
                           mPrStanica = "7216501" Or mPrStanica = "7216871" Or mPrStanica = "7224004" Or _
                           mPrStanica = "7213670" Or mPrStanica = "7216509" Or mPrStanica = "7223450" Or _
                           mPrStanica = "7216203" Or mPrStanica = "7216350" Or mPrStanica = "7216516" Then
                            KolaRed.Item("Naknada") = 26
                        ElseIf mPrStanica = "7216204" Or mPrStanica = "7213201" Or mPrStanica = "7216005" Or _
                               mPrStanica = "7214305" Or mPrStanica = "7213060" Or mPrStanica = "7222503" Or _
                               mPrStanica = "7222850" Or mPrStanica = "7213251" Or mPrStanica = "7212204" Or _
                               mPrStanica = "7221001" Or mPrStanica = "7216550" Or mPrStanica = "7213804" Or _
                               mPrStanica = "7215151" Or mPrStanica = "7215251" Or mPrStanica = "7223306" Or _
                               mPrStanica = "7221009" Or mPrStanica = "7222550" Then
                            KolaRed.Item("Naknada") = 32
                        ElseIf mPrStanica = "7223404" Or mPrStanica = "7213350" Or mPrStanica = "7211050" Or _
                               mPrStanica = "7216310" Or mPrStanica = "7212551" Or mPrStanica = "7215708" Or _
                               mPrStanica = "7211021" Or mPrStanica = "7214060" Then
                            KolaRed.Item("Naknada") = 36
                        ElseIf mPrStanica = "7213250" Or mPrStanica = "7212420" Then
                            KolaRed.Item("Naknada") = 52
                        End If
                    Else                            'Intercontainer
                        If Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) = "81" Then
                            KolaRed.Item("Naknada") = 0
                        Else
                            KolaRed.Item("Naknada") = 36
                        End If
                    End If
                End If
            Next

        ElseIf mVrstaObracuna = "CO" Then
            If IzborSaobracaja = "4" Then
                Dim KolaRed As DataRow
                Dim temp_Ibk As String
                For Each KolaRed In dtKola.Rows
                    KolaRed.Item("Naknada") = 0

                    '---------- naknada za P kola
                    If Left(KolaRed.Item("IndBrojKola"), 2) = "03" Or Left(KolaRed.Item("IndBrojKola"), 2) = "04" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "05" Or Left(KolaRed.Item("IndBrojKola"), 2) = "06" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "13" Or Left(KolaRed.Item("IndBrojKola"), 2) = "14" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "15" Or Left(KolaRed.Item("IndBrojKola"), 2) = "16" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "23" Or Left(KolaRed.Item("IndBrojKola"), 2) = "24" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "25" Or Left(KolaRed.Item("IndBrojKola"), 2) = "26" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "27" Or Left(KolaRed.Item("IndBrojKola"), 2) = "29" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "33" Or Left(KolaRed.Item("IndBrojKola"), 2) = "34" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "35" Or Left(KolaRed.Item("IndBrojKola"), 2) = "36" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "37" Or Left(KolaRed.Item("IndBrojKola"), 2) = "39" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "43" Or Left(KolaRed.Item("IndBrojKola"), 2) = "44" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "45" Or Left(KolaRed.Item("IndBrojKola"), 2) = "46" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "47" Or Left(KolaRed.Item("IndBrojKola"), 2) = "48" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "49" Or Left(KolaRed.Item("IndBrojKola"), 2) = "83" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "84" Or Left(KolaRed.Item("IndBrojKola"), 2) = "85" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "86" Or Left(KolaRed.Item("IndBrojKola"), 2) = "87" Or _
                       Left(KolaRed.Item("IndBrojKola"), 2) = "88" Or Left(KolaRed.Item("IndBrojKola"), 2) = "89" Then

                        If mBrojUg = "101001" Or mBrojUg = "101096" Or _
                           mBrojUg = "101101" Or mBrojUg = "101196" Or _
                           mBrojUg = "101201" Or mBrojUg = "101296" Or _
                           mBrojUg = "101301" Or mBrojUg = "101396" Or _
                           mBrojUg = "111301" Or mBrojUg = "111396" Or _
                           mBrojUg = "121301" Or mBrojUg = "121396" Or _
                           mBrojUg = "801401" Or mBrojUg = "801496" Or _
                           mBrojUg = "811401" Or mBrojUg = "811496" Or _
                           mBrojUg = "801501" Or mBrojUg = "801596" Or _
                           mBrojUg = "811501" Or mBrojUg = "811596" Then

                            KolaRed.Item("Naknada") = -60

                        End If
                    End If

                    '---------- naknada za upotrebu zeleznickih kola
                    If KolaRed.Item("Vlasnik") = "Z" Then
                        If mBrojUg = "061433" Or mBrojUg = "801433" Or mBrojUg = "811433" Or mBrojUg = "981444" Or _
                           mBrojUg = "061533" Or mBrojUg = "111533" Or mBrojUg = "121533" Or _
                           mBrojUg = "801533" Or mBrojUg = "811533" Or mBrojUg = "981544" Or mBrojUg = "961533" Then

                            If mBrojUg = "121533" And _
                               (Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3180" Or _
                                Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3181" Or _
                                Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3780" Or _
                                Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3368" Or _
                                Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3356" Or _
                                Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4950" Or Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4951" Or _
                                Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4952" Or Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4953" Or _
                                Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4954" Or Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4960" Or _
                                Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4961" Or _
                                Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4962" Or Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4964") Then

                                'Tg RCA 29.12.2014, Tg RCA 16.01.2015 email 'oslobodena od RIV najamnine
                                'Email Djaja, 27.3.2015

                                KolaRed.Item("Naknada") = 0

                            Else
                                If mBrojUg = "961533" Then
                                    If KolaRed.Item("Osovine") < 6 Then
                                        KolaRed.Item("Naknada") = 36
                                    Else
                                        KolaRed.Item("Naknada") = 52
                                    End If
                                Else
                                    If mStanica1 = "11028" Or mStanica2 = "11028" Then
                                        KolaRed.Item("Naknada") = 39
                                    End If
                                    If mStanica1 = "12498" Or mStanica2 = "12498" Then
                                        KolaRed.Item("Naknada") = 42
                                    End If
                                End If
                            End If
                        Else
                            KolaRed.Item("Naknada") = 0
                        End If

                    End If


                    'staro pre 12/3/2015
                    'If KolaRed.Item("Vlasnik") = "Z" Then
                    '    'If mBrojUg = "101133" Or mBrojUg = "111133" Or mBrojUg = "121133" Or _
                    '    '   mBrojUg = "101233" Or mBrojUg = "111233" Or mBrojUg = "121233" Or _
                    '    '   mBrojUg = "101333" Or mBrojUg = "111333" Or mBrojUg = "121333" Or _
                    '    '   mBrojUg = "811433" Or mBrojUg = "101345" Or mBrojUg = "061333" Or _
                    '    '   mBrojUg = "061433" Or mBrojUg = "981444" Or mBrojUg = "801433" Or _
                    '    '   mBrojUg = "061533" Or mBrojUg = "981544" Or mBrojUg = "801533" Or _
                    '    '   mBrojUg = "811533" Or mBrojUg = "111533" Or mBrojUg = "121533" Then

                    '    If mBrojUg = "061433" Or mBrojUg = "801433" Or mBrojUg = "811433" Or mBrojUg = "981444" Or _
                    '       mBrojUg = "061533" Or mBrojUg = "111533" Or mBrojUg = "121533" Or _
                    '       mBrojUg = "801533" Or mBrojUg = "811533" Or mBrojUg = "981544" Then

                    '        If mBrojUg = "121533" And _
                    '          (Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3180" Or _
                    '           Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3181" Or _
                    '           Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3780" Or _
                    '           Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3356" Or _
                    '           Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3368" Or _
                    '           Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3356" Or _
                    '           Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4950" Or Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4951" Or _
                    '           Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4952" Or Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4953" Or _
                    '           Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4954" Or Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4960" Or _
                    '           Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4962" Or Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 5, 4) = "4964") Then

                    '            ' 4950, 4951, 4952, 4953, 4954, 4960, 4961, 4962 i 4964 
                    '            'Tg RCA 29.12.2014 email
                    '            'Tg RCA 16.01.2015 email
                    '            'oslobodena od RIV najamnine
                    '            KolaRed.Item("Naknada") = 0 'email D.Stevanovic 28/01/2014 RCA

                    '        Else
                    '            'nisu oslobodena od RIV najamnine
                    '            If Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 7) = "3143455" Then
                    '                If mStanica1 = "11028" Or mStanica2 = "11028" Then
                    '                    KolaRed.Item("Naknada") = 0
                    '                End If
                    '                If mStanica1 = "12498" Or mStanica2 = "12498" Then
                    '                    KolaRed.Item("Naknada") = 0
                    '                End If
                    '            Else
                    '                If mStanica1 = "11028" Or mStanica2 = "11028" Then
                    '                    KolaRed.Item("Naknada") = 39
                    '                End If
                    '                If mStanica1 = "12498" Or mStanica2 = "12498" Then
                    '                    KolaRed.Item("Naknada") = 42
                    '                End If
                    '            End If
                    '        End If

                    '    Else
                    '        KolaRed.Item("Naknada") = 0
                    '    End If

                    'End If

                    ''-------------------------------------------------------------------------------
                    'If Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3181" Or _
                    '    Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3780" Or _
                    '    Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3356" Or _
                    '    Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3180" Or _
                    '    Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "3368" Then

                    '    'Microsoft.VisualBasic.Left(KolaRed.Item("IndBrojKola"), 4) = "2181" Or _

                    '    If mBrojUg = "061433" Or mBrojUg = "981444" Or mBrojUg = "801433" Or mBrojUg = "811433" Or _
                    '       mBrojUg = "061533" Or mBrojUg = "981544" Or mBrojUg = "801433" Or mBrojUg = "811533" Then
                    '        KolaRed.Item("Naknada") = 0 'email D.Stevanovic 28/01/2014 RCA
                    '    End If

                    '    'If mBrojUg = "061422" Then
                    '    '    KolaRed.Item("Naknada") = 0 'email P.Mikasinovic 10/12/2014 RCA
                    '    'End If

                    'End If
                    ''-------------------------------------------------------------------------------
                Next
            ElseIf IzborSaobracaja = "2" Or IzborSaobracaja = "3" Then
                Dim KolaRed As DataRow
                Dim temp_Ibk As String
                For Each KolaRed In dtKola.Rows
                    KolaRed.Item("Naknada") = 0

                    '----- naknada za zeleznicka kola
                    If KolaRed.Item("Vlasnik") = "Z" Then
                        If mBrojUg = "091122" Then   'PANSPED
                            KolaRed.Item("Naknada") = 36
                        ElseIf mBrojUg = "091133" Then   'PANSPED
                            KolaRed.Item("Naknada") = 20
                        ElseIf mBrojUg = "101322" Then
                            KolaRed.Item("Naknada") = 36
                        ElseIf mBrojUg = "101333" Then
                            KolaRed.Item("Naknada") = 20
                        End If
                    End If
                Next
            End If

        End If

        Dim KolaRed2 As DataRow
        For Each KolaRed2 In dtKola.Rows
            _mNakPoKolima = KolaRed2.Item("Naknada")

            If Left(KolaRed2.Item("IndBrojKola"), 2) = "03" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "04" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "05" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "06" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "13" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "14" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "15" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "16" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "23" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "24" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "25" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "26" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "27" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "29" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "33" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "34" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "35" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "36" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "37" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "39" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "43" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "44" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "45" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "46" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "47" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "48" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "49" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "83" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "84" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "85" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "86" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "87" Or _
               Left(KolaRed2.Item("IndBrojKola"), 2) = "88" Or Left(KolaRed2.Item("IndBrojKola"), 2) = "89" Then

                mPkola = True
            Else
                mPkola = False
            End If
        Next
    End Sub
    Public Sub Kola_eValidating()
        Dim KolaRed As DataRow

        For Each KolaRed In dtKola.Rows
            mIBK = KolaRed.Item("IndBrojKola")

            Dim rv As String = ""
            Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & mIBK & "'")

            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            Dim uspKomanda As New SqlClient.SqlCommand("spNadjiSveIzIBK", DbVeza)
            uspKomanda.CommandType = CommandType.StoredProcedure

            Dim upIBK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
            upIBK.Direction = ParameterDirection.Input
            uspKomanda.Parameters("@inIBK").Value = mIBK

            Dim ipSkrUprava As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSkrUprava", SqlDbType.Char, 6))
            ipSkrUprava.Direction = ParameterDirection.Output

            Dim ipVlasnistvo As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVlasnistvo", SqlDbType.Char, 1))
            ipVlasnistvo.Direction = ParameterDirection.Output

            Dim ipRIV As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRIV", SqlDbType.Char, 1))
            ipRIV.Direction = ParameterDirection.Output

            Dim ipSerija As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSerija", SqlDbType.Char, 11))
            ipSerija.Direction = ParameterDirection.Output

            Dim ipBrojOsovina As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrojOsovina", SqlDbType.Int))
            ipBrojOsovina.Direction = ParameterDirection.Output

            Dim ipVrsta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
            ipVrsta.Direction = ParameterDirection.Output

            Dim ipKontrBroj As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBroj", SqlDbType.Int))
            ipKontrBroj.Direction = ParameterDirection.Output

            Dim ipKontrBrojOK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBrojOK", SqlDbType.Char, 1))
            ipKontrBrojOK.Direction = ParameterDirection.Output

            Dim ipKolaICFIzuzeta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolaICFIzuzeta", SqlDbType.Char, 1))
            ipKolaICFIzuzeta.Direction = ParameterDirection.Output

            Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.NVarChar, 100))
            ipPovratnaVrednost.Direction = ParameterDirection.Output

            Try
                uspKomanda.ExecuteScalar()

                KolaRed.Item("Vlasnik") = uspKomanda.Parameters("@outVlasnistvo").Value
                KolaRed.Item("Uprava") = uspKomanda.Parameters("@outSkrUprava").Value
                If Len(Trim(uspKomanda.Parameters("@outSerija").Value)) > 0 Then
                    KolaRed.Item("Serija") = uspKomanda.Parameters("@outSerija").Value
                End If
                If uspKomanda.Parameters("@outBrojOsovina").Value > 0 Then
                    KolaRed.Item("Osovine") = uspKomanda.Parameters("@outBrojOsovina").Value
                End If
                If uspKomanda.Parameters("@outVrsta").Value = "1" Then
                    KolaRed.Item("Vrsta") = "O"
                Else
                    KolaRed.Item("Vrsta") = "S"
                End If
            Finally
                DbVeza.Close()
                uspKomanda.Dispose()
            End Try
        Next
    End Sub
    Public Sub NadjiManipulativnoMesto(ByVal bRecID As Int32, ByRef bStanica1 As String, ByRef bStanica2 As String, _
                                       ByRef bRetVal As String)


        bRetVal = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiMM", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int))
        ulRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRecID").Value = bRecID

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanica1", SqlDbType.Char, 40))
        exStanica1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanica1").Value = bStanica1

        Dim exStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanica2", SqlDbType.Char, 40))
        exStanica2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanica2").Value = bStanica2

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()
            If IzborSaobracaja = "2" Then
                If IsDBNull(spKomanda.Parameters("@outStanica1").Value) Then
                    mManipulativnoMesto = ""
                Else
                    mManipulativnoMesto = spKomanda.Parameters("@outStanica1").Value
                    MM_Count = 0
                End If

            ElseIf IzborSaobracaja = "3" Then
                If IsDBNull(spKomanda.Parameters("@outStanica2").Value) Then
                    mManipulativnoMesto = ""
                Else
                    mManipulativnoMesto = spKomanda.Parameters("@outStanica2").Value
                    MM_Count = 0
                End If

            End If

            If Len(mManipulativnoMesto) = 0 Then
                'akcija treba da bude Insert za tabelu SlogKalkPS
                MM_Action = "New"
            Else
                MM_Action = "Upd"
            End If


        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub NadjiBrutoMasuVoza(ByVal _mBrojUg As String, ByVal _mNajava As String, _
                                  ByRef _BrutoMasaVoza As Decimal, ByRef _rv As String)

        _rv = ""

        '---------------------------------------------------------------------------
        Dim KolaRed As DataRow
        Dim NHMRed As DataRow
        Dim mBrutoMasaTmp As Int32 = 0
        _BrutoMasaVoza = 0

        If mCistUnos = "Da" Or AkcijaZaPreuzimanje = "Da" Then
            For Each KolaRed In dtKola.Rows
                mBrutoMasaTmp = mBrutoMasaTmp + KolaRed.Item("Tara")
            Next
            For Each NHMRed In dtNhm.Rows
                mBrutoMasaTmp = mBrutoMasaTmp + NHMRed.Item("Masa")
            Next
        Else
            mBrutoMasaTmp = 0
        End If
        '---------------------------------------------------------------------------

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiBrutoMasuVoza", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        ulUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _mBrojUg

        Dim ulNajava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10))
        ulNajava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inNajava").Value = _mNajava

        Dim exBrutoMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrutoMasa", SqlDbType.Decimal))
        exBrutoMasa.Size = 5
        exBrutoMasa.Precision = 8
        exBrutoMasa.Scale = 0
        exBrutoMasa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBrutoMasa").Value = _BrutoMasaVoza

        '---------------------------------------------------------------------------------------------------------
        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = _rv

        Try
            spKomanda.ExecuteScalar()
            _BrutoMasaVoza = spKomanda.Parameters("@outBrutoMasa").Value
            _BrutoMasaVoza = _BrutoMasaVoza + mBrutoMasaTmp
        Catch SQLExp As SqlException
            _rv = SQLExp.Message & " Greska - Bruto masa voza!"
        Catch Exp As Exception
            _rv = Err.Description & " Greska - Bruto masa voza!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub UskladiNaknadeZaNaftu() 'i RID od 2012!!

        If mVrstaObracuna = "CO" And IzborSaobracaja = "4" Then
            Dim KolaRed As DataRow
            Dim NHMRed As DataRow
            Dim temp_Ibk, NHMTemp As String
            Dim bDodatakZaNaftu As Decimal

            Dim nmDodataNaknadaZaNaftu As Boolean = False
            For Each KolaRed In dtKola.Rows
                temp_Ibk = KolaRed.Item("IndBrojKola")
                nmDodataNaknadaZaNaftu = False

                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = temp_Ibk Then

                        NHMTemp = NHMRed.Item("NHM")

                        If Microsoft.VisualBasic.Right(mBrojUg, 4) = "1333" Or Microsoft.VisualBasic.Right(mBrojUg, 4) = "1344" Or Microsoft.VisualBasic.Right(mBrojUg, 4) = "1345" Or _
                           Microsoft.VisualBasic.Right(mBrojUg, 4) = "1433" Or Microsoft.VisualBasic.Right(mBrojUg, 4) = "1444" Or Microsoft.VisualBasic.Right(mBrojUg, 4) = "1445" Or _
                           Microsoft.VisualBasic.Right(mBrojUg, 4) = "1533" Or Microsoft.VisualBasic.Right(mBrojUg, 4) = "1544" Or Microsoft.VisualBasic.Right(mBrojUg, 4) = "1545" Then                            'rid u kontejneru
                            bNadjiNaftu(NHMRed.Item("UTINHM"), bTkm, bDodatakZaNaftu) 'i RID od 2012!!
                        Else
                            bNadjiNaftu(NHMRed.Item("NHM"), bTkm, bDodatakZaNaftu) 'i RID od 2012!!
                        End If

                        If IsDBNull(KolaRed.Item("Naknada")) Then
                            KolaRed.Item("Naknada") = bDodatakZaNaftu
                        Else
                            If KolaRed.Item("Naknada") > 0 Then
                                If nmDodataNaknadaZaNaftu = True Then
                                    KolaRed.Item("Naknada") = KolaRed.Item("Naknada")
                                Else
                                    KolaRed.Item("Naknada") = KolaRed.Item("Naknada") + bDodatakZaNaftu
                                End If
                            ElseIf KolaRed.Item("Naknada") < 0 Then
                                If nmDodataNaknadaZaNaftu = True Then
                                    KolaRed.Item("Naknada") = KolaRed.Item("Naknada")
                                Else
                                    KolaRed.Item("Naknada") = KolaRed.Item("Naknada") + bDodatakZaNaftu
                                End If
                            ElseIf KolaRed.Item("Naknada") = 0 Then
                                KolaRed.Item("Naknada") = KolaRed.Item("Naknada") + bDodatakZaNaftu
                            End If
                        End If

                        If bDodatakZaNaftu > 0 Then
                            nmDodataNaknadaZaNaftu = True
                        Else
                            nmDodataNaknadaZaNaftu = False
                        End If

                    End If
                Next
            Next
        End If

        Dim KolaRed2 As DataRow
        For Each KolaRed2 In dtKola.Rows
            _mNakPoKolima = KolaRed2.Item("Naknada")
        Next
    End Sub
    Public Sub bProveri8606(ByVal ulNHM As String, ByRef izl8606 As Boolean, ByRef izlKao8606 As Boolean)
        izl8606 = False
        izlKao8606 = False

        If (CInt(_mNHM) = 860400 Or CInt(_mNHM) = 860500 Or CInt(_mNHM) = 860600) Or _
           (CInt(_mNHM) >= 992110 And CInt(_mNHM) <= 992140) Or (CInt(_mNHM) >= 992210 And CInt(_mNHM) <= 992240) Then

            izl8606 = True
            izlKao8606 = True

        End If

        'If Microsoft.VisualBasic.Left(ulNHM, 4) = "8606" Then
        '    izl8606 = True
        '    izlKao8606 = False
        'End If

        'If ulNHM = "992110" Or ulNHM = "992120" Or ulNHM = "992130" Or ulNHM = "992140" Or _
        '   ulNHM = "992210" Or ulNHM = "992220" Or ulNHM = "992230" Or ulNHM = "992240" Or _
        '   ulNHM = "860400" Or ulNHM = "860500" Then
        '    izl8606 = False
        '    izlKao8606 = True
        'End If

    End Sub
End Module
