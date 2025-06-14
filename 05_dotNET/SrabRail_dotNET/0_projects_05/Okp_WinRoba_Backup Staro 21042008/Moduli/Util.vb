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

    Public Sub NadjiTovarniList(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                                ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef bPrUprava As String, ByRef bPrStanica As String, _
                                ByRef bPrBroj As Int32, ByRef mPrDatum As Date, ByRef updTkm As Int32, ByRef bSaobracaj As String, ByRef bZsUlPrelaz As String, ByRef bZsIzPrelaz As String, ByRef bNajava As String, _
                                ByRef bLomSt As String, ByRef bIOP As Int32, ByRef bIOPFrNaknade As String, ByRef bIOPFrDoPrelaza As String, ByRef bIOPIncoterms As String, _
                                ByRef bSifraTarife As String, ByRef bUgovor As String, ByRef bValutaTL As String, _
                                ByRef bPrevozninaFR As Decimal, ByRef bPrevozninaUP As Decimal, ByRef bNaknadeFR As Decimal, ByRef bNaknadeUP As Decimal, _
                                ByRef bBlagFR As Decimal, ByRef bBlagUP As Decimal, ByRef bTLDinFR As Decimal, ByRef bTLDinUP As Decimal, _
                                ByRef bBlagFRDin As Decimal, ByRef bBlagUPDin As Decimal, ByRef bBlagK115Din As Decimal, ByRef bRazlikaFRDin As Decimal, ByRef bRazlikaUPDin As Decimal, _
                                ByRef bRetVal As String)


        bRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL2", OkpDbVeza)
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
                sqlText = "SELECT Oznaka FROM UicOperateri WHERE Operater = '" & ipSifra1 & "' AND SifraUprave = '" & ipSifra2 & "'"
            Case "UicStanice"
                sqlText = "SELECT Naziv FROM UicStanice WHERE SifraStanice = '" & ipSifra1 & "'"
            Case "UicPrelaz"
                sqlText = "SELECT Naziv FROM UicPrelazi WHERE Uprava1 = '" & ipSifra1 & "' AND SifraPrelaza = '" & ipSifra2 & "'"
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
                                & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav  " _
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

                    drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(4), "O", _
                                                       dsSlogKola.Tables(0).Rows(k).Item(5), dsSlogKola.Tables(0).Rows(k).Item(6), dsSlogKola.Tables(0).Rows(k).Item(7), dsSlogKola.Tables(0).Rows(k).Item(8), _
                                                       dsSlogKola.Tables(0).Rows(k).Item(9), 0, dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), dsSlogKola.Tables(0).Rows(k).Item(19), "U"}
                    dtKola.Rows.Add(drKola)
                End If
            Next



            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------
            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                Dim drNHM As DataRow = dtNhm.NewRow
                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                                         dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                                         dsSlogKola.Tables(0).Rows(jj).Item(18), "", 0, 0, "", "", "", "U", _
                                                                         dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20)}

                dtNhm.Rows.Add(drNHM)

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
                                       & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav  " _
                                       & " FROM dbo.SlogKola INNER JOIN  " _
                                       & " dbo.SlogKalk ON dbo.SlogKola.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogKola.OtpStanica = dbo.SlogKalk.OtpStanica AND   " _
                                       & " dbo.SlogKola.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogKola.OtpDatum = dbo.SlogKalk.OtpDatum INNER JOIN  " _
                                       & " dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND   " _
                                       & " dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka  " _
                                       & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", DbVeza)

            '''Dim adSlogKola As New SqlDataAdapter(" SELECT dbo.SlogKola.KolaStavka, dbo.SlogKola.IBK, dbo.SlogKola.Uprava, dbo.SlogKola.Vlasnik, dbo.SlogKola.Serija, dbo.SlogKola.Osovine, " _
            '''                    & " dbo.SlogKola.Tara, dbo.SlogKola.GranTov, dbo.SlogKola.Stitna, dbo.SlogKola.TipKola, dbo.SlogKola.Naknada, dbo.SlogKola.Kontrola,  " _
            '''                    & " dbo.SlogKalk.UkupnoKola, dbo.SlogRoba.NHM, dbo.SlogRoba.NHMRazred, dbo.SlogRoba.SMasa, dbo.SlogRoba.RMasa, dbo.SlogRoba.RID,   " _
            '''                    & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav  " _
            '''                    & " FROM dbo.SlogKola INNER JOIN  " _
            '''                    & " dbo.SlogKalk ON dbo.SlogKola.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogKola.OtpStanica = dbo.SlogKalk.OtpStanica AND   " _
            '''                    & " dbo.SlogKola.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogKola.OtpDatum = dbo.SlogKalk.OtpDatum INNER JOIN  " _
            '''                    & " dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND   " _
            '''                    & " dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka  " _
            '''                    & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", DbVeza)


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

                    If mVrstaObracuna = "IC" Then
                        If dsSlogKola.Tables(0).Rows(k).Item(3) = "Z" Then
                            If mBrojUg = "835745" Then        'Adriacombi
                                mNaknadaZaZelKola = 26
                            ElseIf mBrojUg = "931817" Then  'Eurolog
                                mNaknadaZaZelKola = 26
                            ElseIf (mBrojUg = "100722" Or mBrojUg = "110722" Or mBrojUg = "120722") Then  'Proodos kont.voz
                                If mStanica1 = "11028" Or mStanica2 = "11028" Then
                                    mNaknadaZaZelKola = 36
                                End If
                                If mStanica1 = "12498" Or mStanica2 = "12498" Then
                                    mNaknadaZaZelKola = 39
                                End If
                            ElseIf (mBrojUg = "100822" Or mBrojUg = "110822" Or mBrojUg = "120822") Then  'Proodos kont.voz
                                If mStanica1 = "11028" Or mStanica2 = "11028" Then
                                    mNaknadaZaZelKola = 36
                                End If
                                If mStanica1 = "12498" Or mStanica2 = "12498" Then
                                    mNaknadaZaZelKola = 39
                                End If
                            Else  'Intercontainer
                                If Microsoft.VisualBasic.Mid(IBK, 3, 2) = "81" Then
                                    mNaknadaZaZelKola = 0
                                Else
                                    mNaknadaZaZelKola = 36
                                End If
                            End If
                        End If
                    End If

                    'drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(4), "O", _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(5), dsSlogKola.Tables(0).Rows(k).Item(6), dsSlogKola.Tables(0).Rows(k).Item(7), dsSlogKola.Tables(0).Rows(k).Item(8), _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(9), 0, mNaknadaZaZelKola, dsSlogKola.Tables(0).Rows(k).Item(11), dsSlogKola.Tables(0).Rows(k).Item(19), "I"}

                    drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(4), dsSlogKola.Tables(0).Rows(k).Item(5), "O", _
                                                       dsSlogKola.Tables(0).Rows(k).Item(6), dsSlogKola.Tables(0).Rows(k).Item(7), dsSlogKola.Tables(0).Rows(k).Item(8), _
                                                       dsSlogKola.Tables(0).Rows(k).Item(9), 0, mNaknadaZaZelKola, dsSlogKola.Tables(0).Rows(k).Item(11), dsSlogKola.Tables(0).Rows(k).Item(19), "I"}



                    ''''drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(6), dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(4), "O", _
                    ''''                                   dsSlogKola.Tables(0).Rows(k).Item(5), dsSlogKola.Tables(0).Rows(k).Item(7), dsSlogKola.Tables(0).Rows(k).Item(8), _
                    ''''                                   dsSlogKola.Tables(0).Rows(k).Item(9), 0, mNaknadaZaZelKola, dsSlogKola.Tables(0).Rows(k).Item(11), dsSlogKola.Tables(0).Rows(k).Item(19), "I"}



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
                    Else
                        KolaRed.Item("Tara") = CType(xNaziv, Int32)
                        mNemaTare = "0"
                        _mTara = xNaziv
                    End If
                    '---------------------------------------------------------------------------------
                End If
            Next

            ' $$$
            ' Dodeljivanje vrednosti naknade za poslove centralnog obracuna
            'Dim tempIznos8216 As Decimal = 15

            ''If tempNhm8216 = "T" Then
            ''    If Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "10" _
            ''       Or Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "11" _
            ''       Or Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "12" Then
            ''        tempIznos8216 = 15
            ''    End If
            ''Else
            ''    If Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "10" _
            ''       Or Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "11" _
            ''       Or Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "12" Then
            ''        tempIznos8216 = 5
            ''    End If
            ''End If

            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------


            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1
                Dim drNHM As DataRow = dtNhm.NewRow
                'drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                '                                                         dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                '                                                         dsSlogKola.Tables(0).Rows(jj).Item(18), "", 0, 0, "", "", "", "I"}


                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                                 dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                                 dsSlogKola.Tables(0).Rows(jj).Item(18), "", 0, 0, "", "", "", "I", _
                                                                 dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20)}


                dtNhm.Rows.Add(drNHM)
            Next

            Dim KolaNhm As DataRow
            For Each KolaNhm In dtNhm.Rows
                _mNHM = KolaNhm.Item("NHM")
                _mSMasa = KolaNhm.Item("Masa")
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
                                                      dsSlogNak.Tables(0).Rows(k).Item(3), dsSlogNak.Tables(0).Rows(k).Item(4), dsSlogNak.Tables(0).Rows(k).Item(5), _
                                                      dsSlogNak.Tables(0).Rows(k).Item(6), dsSlogNak.Tables(0).Rows(k).Item(7), "I"}
                dtNaknade.Rows.Add(drNaknade)
            Next
        Catch sqlex As SqlException

            Dim aa As String
            aa = sqlex.Message

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
    Public Sub NadjiTovarniListTrz(ByVal inTipStanice As String, ByVal inStanica As String, ByVal inNalepnica As Int32, _
                                   ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
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

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTLTrz", OkpDbVeza)
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
    Public Sub NadjiTovarniListTrzGranica(ByVal inTipStanice As String, ByVal inStanica As String, ByVal inNalepnica As Int32, _
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
            'bSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
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
                                    ByVal _tempBM As Decimal, ByRef _ProcenatBM As Decimal, ByRef _rv As String)



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

        Dim ulMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inMasa", SqlDbType.Char, 4))
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
    'Public Sub CoUpdatePrevoznine(ByVal _BrojUg As String, ByVal _Najava As String, ByVal _ObrGodina As String, _
    '                                           ByVal _ProcenatBM As Decimal, ByRef _rv As String)
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

            'If _rv = "Updated!" Then
            '    MsgBox("updated")
            'End If

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


                If mDoPrelaza.Trim().Length = 0 Then ' dodato zbog preuzimanja
                    mDoPrelaza = ""
                End If

                If mSifraIzjave = 1 Then        ' ----------------- FRANKO OK
                    If mDoPrelaza = "" Or mDoPrelaza = "    " Then
                        f_prev = mPrevoznina
                        u_prev = 0

                        ''If Microsoft.VisualBasic.Left(mUkljucujuci, 1) = "0" Then

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
                            'i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)

                            If i_Pronasao >= 0 Then
                                u_nak = u_nak + NaknadaRed.Item("Iznos")
                            Else
                                f_nak = f_nak + NaknadaRed.Item("Iznos")
                            End If

                        End If
                    Else
                        f_prev = 0
                        u_prev = mPrevoznina

                        If Microsoft.VisualBasic.Trim(upis_mFrNaknade) = "0" Then
                            f_nak = 0
                            u_nak = u_nak + NaknadaRed.Item("Iznos")
                        Else
                            'i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)

                            i_Pronasao = -1
                            i_TotalNak = NaknadaRed.Item("Sifra")
                            For ii As Int16 = 0 To 4
                                If mUkljucujuci(ii) = i_TotalNak Then
                                    i_Pronasao = 1
                                    Exit For
                                End If
                            Next

                            If i_Pronasao >= 0 Then
                                u_nak = u_nak + NaknadaRed.Item("Iznos")
                            Else
                                f_nak = f_nak + NaknadaRed.Item("Iznos")
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
            End If
        End If

        Dim mOutKurs As Decimal = 0
        Dim strRetVal As String = ""

        NadjiKurs(bValuta, "1", mPrDatum, mOutKurs, strRetVal)
        If mBrojUg = "200379" Then 'Sartid
            NadjiKurs(bValuta, "3", mPrDatum, mOutKurs, strRetVal)
        End If


        Dim zaokruziIznos As Decimal = 0
        If mTarifa = "68" Or kSifTar = 68 Then 'TEA na 1e
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
                UpravaRed.Item("PF") = i_Prevoznina ' prevoznina franko
                UpravaRed.Item("PU") = 0            ' prevoznina upuceno = 0 

                If UpravaRed.Item("rbr") <= i_Granica Then  ' F R A N K O do granicnog prelaza
                    If upis_mFrNaknade <> "" Then              ' F R A N K O naknade do granicnog prelaza
                        ''If Microsoft.VisualBasic.Left(mUkljucujuci, 1) = "0" Then

                        If Microsoft.VisualBasic.Trim(upis_mFrNaknade) = "0" Then
                            UpravaRed.Item("NF") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")
                            UpravaRed.Item("NU") = 0
                        Else
                            i_TotalNak = UpravaRed.Item("Nak1")
                            i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)
                            ''i_Pronasao = i_TotalNak.IndexOf(mUkljucujuci)

                            If i_Pronasao >= 0 Then
                                UpravaRed.Item("NF") = UpravaRed.Item("Iznos1")
                                UpravaRed.Item("NU") = UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                            Else
                                i_TotalNak = UpravaRed.Item("Nak2")
                                i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)
                                ''i_Pronasao = i_TotalNak.IndexOf(mUkljucujuci)

                                If i_Pronasao >= 0 Then
                                    UpravaRed.Item("NF") = UpravaRed.Item("Iznos2")
                                    UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos3")

                                Else
                                    i_TotalNak = UpravaRed.Item("Nak3")
                                    i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)
                                    ''i_Pronasao = i_TotalNak.IndexOf(mUkljucujuci)

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

            If Microsoft.VisualBasic.Trim(bUgovor) <> "" Then
                NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)
            End If

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
            Dim adSlogKola As New SqlDataAdapter(" SELECT dbo.SlogKola.KolaStavka, dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogKola.Uprava, dbo.SlogKola.Vlasnik, dbo.SlogKola.Serija, dbo.SlogKola.Osovine, " _
                                & " dbo.SlogKola.GranTov, dbo.SlogKola.Stitna, dbo.SlogKola.TipKola, dbo.SlogKola.Naknada, dbo.SlogKola.Kontrola,  " _
                                & " dbo.SlogKalk.UkupnoKola, dbo.SlogRoba.NHM, dbo.SlogRoba.NHMRazred, dbo.SlogRoba.SMasa, dbo.SlogRoba.RMasa, dbo.SlogRoba.RID,   " _
                                & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav  " _
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

                    drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(4), "O", _
                                                       dsSlogKola.Tables(0).Rows(k).Item(5), dsSlogKola.Tables(0).Rows(k).Item(6), dsSlogKola.Tables(0).Rows(k).Item(7), dsSlogKola.Tables(0).Rows(k).Item(8), _
                                                       dsSlogKola.Tables(0).Rows(k).Item(9), 0, dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), dsSlogKola.Tables(0).Rows(k).Item(19), "U"}
                    dtKola.Rows.Add(drKola)
                End If
            Next



            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------
            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                Dim drNHM As DataRow = dtNhm.NewRow
                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                                         dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                                         dsSlogKola.Tables(0).Rows(jj).Item(18), "", 0, 0, "", "", "", "U", _
                                                                         dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20)}

                dtNhm.Rows.Add(drNHM)

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
                                              & " dbo.SlogUic.StavkaUIC, dbo.SlogUic.SifraPP, dbo.SlogUic.tlUpucenoDin " _
                                              & " FROM SlogUIC " _
                                              & " WHERE  (dbo.SlogUic.RecID = '" & UpdRecID & "') AND (dbo.SlogUic.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

            Dim tmp_pp As String = ""
            m_UicPrevozniPut = ""
            ii2 = adSlogUic.Fill(dsSlogUic)

            For k As Int16 = 0 To dsSlogUic.Tables(0).Rows.Count - 1
                Dim drUic As DataRow = dtUic.NewRow
                drUic.ItemArray() = New Object() {dsSlogUic.Tables(0).Rows(k).Item(0), dsSlogUic.Tables(0).Rows(k).Item(1), dsSlogUic.Tables(0).Rows(k).Item(2), dsSlogUic.Tables(0).Rows(k).Item(3), dsSlogUic.Tables(0).Rows(k).Item(4), _
                                                  dsSlogUic.Tables(0).Rows(k).Item(5), dsSlogUic.Tables(0).Rows(k).Item(6), dsSlogUic.Tables(0).Rows(k).Item(7), dsSlogUic.Tables(0).Rows(k).Item(8), dsSlogUic.Tables(0).Rows(k).Item(9), dsSlogUic.Tables(0).Rows(k).Item(10), _
                                                  dsSlogUic.Tables(0).Rows(k).Item(11), dsSlogUic.Tables(0).Rows(k).Item(12), dsSlogUic.Tables(0).Rows(k).Item(13), dsSlogUic.Tables(0).Rows(k).Item(14), dsSlogUic.Tables(0).Rows(k).Item(15), dsSlogUic.Tables(0).Rows(k).Item(16), _
                                                  "U", dsSlogUic.Tables(0).Rows(k).Item(17), dsSlogUic.Tables(0).Rows(k).Item(19)}
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
        Dim i_Granica As Decimal = 0
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
                            i_TotalNak = UpravaRed.Item("Nak1")
                            i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)

                            If i_Pronasao >= 0 Then
                                UpravaRed.Item("NF") = UpravaRed.Item("Iznos1")
                                UpravaRed.Item("NU") = UpravaRed.Item("Iznos2") + UpravaRed.Item("Iznos3")

                            Else
                                i_TotalNak = UpravaRed.Item("Nak2")
                                i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)
                                ''i_Pronasao = i_TotalNak.IndexOf(mUkljucujuci)

                                If i_Pronasao >= 0 Then
                                    UpravaRed.Item("NF") = UpravaRed.Item("Iznos2")
                                    UpravaRed.Item("NU") = UpravaRed.Item("Iznos1") + UpravaRed.Item("Iznos3")

                                Else
                                    i_TotalNak = UpravaRed.Item("Nak3")
                                    i_Pronasao = Array.BinarySearch(mUkljucujuci, i_TotalNak)
                                    ''i_Pronasao = i_TotalNak.IndexOf(mUkljucujuci)

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

        NadjiKurs(bValuta, "1", mOtpDatum, mOutKurs, strRetVal)
        If mBrojUg = "200379" Then 'Sartid
            NadjiKurs(bValuta, "3", mOtpDatum, mOutKurs, strRetVal)
        End If

        Dim zaokruziIznos As Decimal = 0

        If mTarifa = "68" Or kSifTar = 68 Then
            zaokruziIznos = f_prev + f_nak
            bZaokruziNaCeleNavise(zaokruziIznos)
        Else
            zaokruziIznos = f_prev + f_nak
        End If

        upis_f_suma = zaokruziIznos

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
End Module
