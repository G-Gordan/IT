Imports System.Data.SqlClient

Module Util

    Dim dsSlogKola As New DataSet("dsSlogKola")
    Dim dsSlogNHM As New DataSet("dsSlogNHM")
    Dim dsSlogNak As New DataSet("dsSlogNak")
    Dim dsCimXml As New DataSet("dsCimXml")
    Dim dsWeb2Zs As New DataSet("dsWeb2Zs")

    Dim dsSlogK211 As New DataSet("dsSlogK211")

    Public Sub NadjiUlazniTranzit2(ByVal _UlaznaNalepnica As Int32, ByVal _UlazniPrelaz As String, ByVal _Godina As String, _
                                  ByRef _otUprava As String, ByRef _otStanica As String, ByRef _otBroj As Int32, ByRef _otDatum As Date, _
                                  ByRef _IzlaznaNalepnica As Int32, ByRef _IBK As String, ByRef _BrojVoza As String, _
                                  ByRef _RecID As Int32, ByRef _mRetVal As String)

        _mRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiUlazniTranzit2", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inUlaznaNalepnica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUlaznaNalepnica", SqlDbType.Int, 4))
        inUlaznaNalepnica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUlaznaNalepnica").Value = _UlaznaNalepnica

        Dim inUlazniPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUlazniPrelaz", SqlDbType.Char, 5))
        inUlazniPrelaz.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUlazniPrelaz").Value = _UlazniPrelaz

        Dim inGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4))
        inGodina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inGodina").Value = _Godina

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
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub

    Public Sub NadjiUgovor(ByVal _Ugovor As String, ByRef _NazivKomitenta As String, ByRef _Primalac As Int32, _
                           ByRef _VrstaObracuna As String, ByRef _AdresaKomitenta As String, _
                           ByRef _GradKomitenta As String, ByRef _ZemljaKomitenta As String, _
                           ByRef outRetVal As String)

        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.eNadjiUgovor", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        inUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _Ugovor

        Dim outNaziv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNaziv", SqlDbType.VarChar, 50))
        outNaziv.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNaziv").Value = _NazivKomitenta

        Dim outAdresa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAdresa", SqlDbType.VarChar, 50))
        outAdresa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outAdresa").Value = _AdresaKomitenta

        Dim outGrad As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrad", SqlDbType.VarChar, 35))
        outGrad.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outGrad").Value = _GradKomitenta

        Dim outZemlja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outLand", SqlDbType.Char, 2))
        outZemlja.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outLand").Value = _ZemljaKomitenta

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
            _AdresaKomitenta = spKomanda.Parameters("@outAdresa").Value
            _GradKomitenta = spKomanda.Parameters("@outGrad").Value
            _ZemljaKomitenta = spKomanda.Parameters("@outLand").Value
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
    'Public Sub NadjiUgovorP(ByVal _Ugovor As String, ByRef _NazivKomitenta As String, ByRef _Primalac As Int32, _
    '                   ByRef _VrstaObracuna As String, ByRef _AdresaKomitenta As String, _
    '                   ByRef _GradKomitenta As String, ByRef _ZemljaKomitenta As String, _
    '                   ByRef outRetVal As String)

    '    outRetVal = ""

    '    If DbVeza.State = ConnectionState.Closed Then
    '        DbVeza.Open()
    '    End If

    '    'Dim spKomanda As New SqlClient.SqlCommand("dbo.eNadjiUgovor", DbVeza)
    '    Dim spKomanda As New SqlClient.SqlCommand("roba1708.bPNadjiUgovor", DbVeza)
    '    spKomanda.CommandType = CommandType.StoredProcedure

    '    Dim inUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
    '    inUgovor.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inUgovor").Value = _Ugovor

    '    Dim outNaziv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNaziv", SqlDbType.VarChar, 50))
    '    outNaziv.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outNaziv").Value = _NazivKomitenta

    '    Dim outAdresa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAdresa", SqlDbType.VarChar, 50))
    '    outAdresa.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outAdresa").Value = _AdresaKomitenta

    '    Dim outGrad As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrad", SqlDbType.VarChar, 35))
    '    outGrad.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outGrad").Value = _GradKomitenta

    '    Dim outZemlja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outLand", SqlDbType.Char, 2))
    '    outZemlja.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outLand").Value = _ZemljaKomitenta

    '    Dim outSifra As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifra", SqlDbType.Int, 4))
    '    outSifra.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outSifra").Value = _Primalac

    '    Dim outVrstaObr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrstaObr", SqlDbType.Char, 2))
    '    outVrstaObr.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outVrstaObr").Value = _VrstaObracuna

    '    Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
    '    izlRetVal.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outRetVal").Value = outRetVal

    '    Try
    '        spKomanda.ExecuteScalar()
    '        _NazivKomitenta = spKomanda.Parameters("@outNaziv").Value
    '        _AdresaKomitenta = spKomanda.Parameters("@outAdresa").Value
    '        _GradKomitenta = spKomanda.Parameters("@outGrad").Value
    '        _ZemljaKomitenta = spKomanda.Parameters("@outLand").Value
    '        _Primalac = spKomanda.Parameters("@outSifra").Value
    '        _VrstaObracuna = spKomanda.Parameters("@outVrstaObr").Value
    '        outRetVal = spKomanda.Parameters("@outRetVal").Value

    '    Catch sqlexp As Exception
    '        outRetVal = sqlexp.Message & " SQL greska u programu!"
    '    Catch Exp As Exception
    '        outRetVal = Err.Description & " Greska u programu!"
    '    Finally
    '        DbVeza.Close()
    '        spKomanda.Dispose()
    '    End Try

    'End Sub
    'Public Sub NadjiUgovorPP(ByVal _Ugovor As String, ByRef _NazivKomitenta As String, ByRef _Primalac As Int32, _
    '                       ByRef _VrstaObracuna As String, ByRef _AdresaKomitenta As String, _
    '                       ByRef _GradKomitenta As String, ByRef _ZemljaKomitenta As String, _
    '                       ByRef outRetVal As String)

    '    outRetVal = ""

    '    If DbVeza.State = ConnectionState.Closed Then
    '        DbVeza.Open()
    '    End If

    '    'Dim spKomanda As New SqlClient.SqlCommand("dbo.eNadjiUgovor", DbVeza)
    '    Dim spKomanda As New SqlClient.SqlCommand("roba1708.bPPNadjiUgovor", DbVeza)
    '    spKomanda.CommandType = CommandType.StoredProcedure

    '    Dim inUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
    '    inUgovor.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inUgovor").Value = _Ugovor

    '    Dim outNaziv As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNaziv", SqlDbType.VarChar, 50))
    '    outNaziv.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outNaziv").Value = _NazivKomitenta

    '    Dim outAdresa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAdresa", SqlDbType.VarChar, 50))
    '    outAdresa.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outAdresa").Value = _AdresaKomitenta

    '    Dim outGrad As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrad", SqlDbType.VarChar, 35))
    '    outGrad.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outGrad").Value = _GradKomitenta

    '    Dim outZemlja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outLand", SqlDbType.Char, 2))
    '    outZemlja.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outLand").Value = _ZemljaKomitenta

    '    Dim outSifra As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifra", SqlDbType.Int, 4))
    '    outSifra.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outSifra").Value = _Primalac

    '    Dim outVrstaObr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrstaObr", SqlDbType.Char, 2))
    '    outVrstaObr.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outVrstaObr").Value = _VrstaObracuna

    '    Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
    '    izlRetVal.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outRetVal").Value = outRetVal

    '    Try
    '        spKomanda.ExecuteScalar()
    '        _NazivKomitenta = spKomanda.Parameters("@outNaziv").Value
    '        _AdresaKomitenta = spKomanda.Parameters("@outAdresa").Value
    '        _GradKomitenta = spKomanda.Parameters("@outGrad").Value
    '        _ZemljaKomitenta = spKomanda.Parameters("@outLand").Value
    '        _Primalac = spKomanda.Parameters("@outSifra").Value
    '        _VrstaObracuna = spKomanda.Parameters("@outVrstaObr").Value
    '        outRetVal = spKomanda.Parameters("@outRetVal").Value

    '    Catch sqlexp As Exception
    '        outRetVal = sqlexp.Message & " SQL greska u programu!"
    '    Catch Exp As Exception
    '        outRetVal = Err.Description & " Greska u programu!"
    '    Finally
    '        DbVeza.Close()
    '        spKomanda.Dispose()
    '    End Try

    'End Sub
    Public Sub bNadjiPiPPIzUgovoraKP(ByVal _Ugovor As String, _
                        ByRef _NazivKomitentaP As String, ByRef _PrimalacP As Int32, _
                        ByRef _VrstaObracunaP As String, ByRef _AdresaKomitentaP As String, _
                        ByRef _GradKomitentaP As String, ByRef _ZemljaKomitentaP As String, _
                        ByRef _NazivKomitentaPP As String, ByRef _PrimalacPP As Int32, _
                        ByRef _VrstaObracunaPP As String, ByRef _AdresaKomitentaPP As String, _
                        ByRef _GradKomitentaPP As String, ByRef _ZemljaKomitentaPP As String, _
                        ByRef outRetVal As String)

        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("dbo.eNadjiUgovor", DbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bNadjiPiPPIzUgovoraKP", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6))
        inUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUgovor").Value = _Ugovor

        Dim outNazivP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivP", SqlDbType.VarChar, 50))
        outNazivP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNazivP").Value = _NazivKomitentaP

        Dim outAdresaP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAdresaP", SqlDbType.VarChar, 50))
        outAdresaP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outAdresaP").Value = _AdresaKomitentaP

        Dim outGradP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGradP", SqlDbType.VarChar, 35))
        outGradP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outGradP").Value = _GradKomitentaP

        Dim outZemljaP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outLandP", SqlDbType.Char, 2))
        outZemljaP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outLandP").Value = _ZemljaKomitentaP

        Dim outSifraP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraP", SqlDbType.Int, 4))
        outSifraP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraP").Value = _PrimalacP

        Dim outVrstaObrP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrstaObrP", SqlDbType.Char, 2))
        outVrstaObrP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVrstaObrP").Value = _VrstaObracunaP

        Dim outNazivPP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivPP", SqlDbType.VarChar, 50))
        outNazivPP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNazivPP").Value = _NazivKomitentaPP

        Dim outAdresaPP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAdresaPP", SqlDbType.VarChar, 50))
        outAdresaPP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outAdresaPP").Value = _AdresaKomitentaPP

        Dim outGradPP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGradPP", SqlDbType.VarChar, 35))
        outGradPP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outGradPP").Value = _GradKomitentaPP

        Dim outZemljaPP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outLandPP", SqlDbType.Char, 2))
        outZemljaPP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outLandPP").Value = _ZemljaKomitentaPP

        Dim outSifraPP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraPP", SqlDbType.Int, 4))
        outSifraPP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraPP").Value = _PrimalacPP

        Dim outVrstaObrPP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrstaObrPP", SqlDbType.Char, 2))
        outVrstaObrPP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVrstaObrPP").Value = _VrstaObracunaPP

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()
            _NazivKomitentaP = spKomanda.Parameters("@outNazivP").Value
            _AdresaKomitentaP = spKomanda.Parameters("@outAdresaP").Value
            _GradKomitentaP = spKomanda.Parameters("@outGradP").Value
            _ZemljaKomitentaP = spKomanda.Parameters("@outLandP").Value
            _PrimalacP = spKomanda.Parameters("@outSifraP").Value
            _VrstaObracunaP = spKomanda.Parameters("@outVrstaObrP").Value
            _NazivKomitentaPP = spKomanda.Parameters("@outNazivPP").Value
            _AdresaKomitentaPP = spKomanda.Parameters("@outAdresaPP").Value
            _GradKomitentaPP = spKomanda.Parameters("@outGradPP").Value
            _ZemljaKomitentaPP = spKomanda.Parameters("@outLandPP").Value
            _PrimalacPP = spKomanda.Parameters("@outSifraPP").Value
            _VrstaObracunaPP = spKomanda.Parameters("@outVrstaObrPP").Value
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

    Public Sub NadjiTovarniList(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, ByRef bOtpDatum As Date, _
                               ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef bPrUprava As String, ByRef bPrStanica As String, _
                               ByRef bPrBroj As Int32, ByRef mPrDatum As Date, ByRef updTkm As Int32, ByRef updPrevozniPutZS As Int32, ByRef updStanicaVia As String, ByRef bSaobracaj As String, ByRef bVrSao As String, ByRef bZsUlPrelaz As String, ByRef bZsIzPrelaz As String, ByRef bNajava As String, _
                               ByRef bLomSt As String, ByRef bIOP As Int32, ByRef outIznosPoIzjavi As Decimal, ByRef bIOPFrNaknade As String, ByRef bIOPFrDoPrelaza As String, ByRef bIOPIncoterms As String, _
                               ByRef bSifraTarife As String, ByRef bSifraTarife72 As String, ByRef bUgovor As String, ByRef outPosiljalacIzBaze As Int32, ByRef outPrimalacIzBaze As Int32, ByRef bPrevoz As String, ByRef bValutaTL As String, _
                               ByRef bPrevFRDin As Decimal, ByRef bPrevUPDin As Decimal, ByRef bNaknadeFR As Decimal, ByRef bNaknadeUP As Decimal, _
                               ByRef bBlagFR As Decimal, ByRef bBlagUP As Decimal, ByRef bTLDinFR As Decimal, ByRef bTLDinUP As Decimal, _
                               ByRef bBlagFRDin As Decimal, ByRef bBlagUPDin As Decimal, ByRef bBlagK115Din As Decimal, ByRef bRazlikaFRDin As Decimal, ByRef bRazlikaUPDin As Decimal, _
                               ByRef outVrednostRobe As Decimal, ByRef outNarocitaPosiljka As String, _
                               ByRef bRetVal As String)


        bRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("roba1708.bNadjiTL222", OkpDbVeza)
        'Dim spKomanda As New SqlClient.SqlCommand("roba1708.spb4NadjiTL", OkpDbVeza
        ' u donjoj sp su ul. parametri samo stanica i broj otpravljanja
        'Dim spKomanda As New SqlClient.SqlCommand("roba1708.spb5ProbaNadjiTL", OkpDbVeza)
        'Dim spKomanda As New SqlClient.SqlCommand("roba1708.spb5NadjiTLLokal", OkpDbVeza)
        'Dim spKomanda As New SqlClient.SqlCommand("roba1708.spb6NadjiTLLokal", OkpDbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.spb7NadjiTLLokal", OkpDbVeza)        

        spKomanda.CommandType = CommandType.StoredProcedure


        ' sp "roba1708.spb5ProbaNadjiTL" - samo za lokal


        Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulazUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = "72" & bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        'Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        'ulDatum.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inDatum").Value = bDatum

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

        Dim exVrSao As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrSao", SqlDbType.Char, 1))
        exVrSao.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVrSao").Value = bVrSao

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

        Dim izlIznosPoIzjavi As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznosPoIzjavi", SqlDbType.Decimal))
        izlIznosPoIzjavi.Size = 9
        izlIznosPoIzjavi.Precision = 12
        izlIznosPoIzjavi.Scale = 2
        izlIznosPoIzjavi.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznosPoIzjavi").Value = outIznosPoIzjavi

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

        Dim exSifraTarife72 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife72", SqlDbType.Char, 2))
        exSifraTarife72.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife72").Value = bSifraTarife72



        Dim exUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        exUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor

        Dim exPosiljalacIzBaze As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPosiljalac", SqlDbType.Int))
        exPosiljalacIzBaze.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPosiljalac").Value = outPosiljalacIzBaze

        Dim exPrimalacIzBaze As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrimalac", SqlDbType.Int))
        exPrimalacIzBaze.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPosiljalac").Value = outPrimalacIzBaze


        Dim exPrevoz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevoz", SqlDbType.Char, 1))
        exPrevoz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrevoz").Value = bPrevoz

        Dim exValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outValuta", SqlDbType.Char, 2))
        exValuta.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outValuta").Value = bValutaTL

        '---------------------------------------------------------------------------------------------------------
        Dim izlPrevozninaFR As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevFRDin", SqlDbType.Decimal))
        izlPrevozninaFR.Size = 9
        izlPrevozninaFR.Precision = 12
        izlPrevozninaFR.Scale = 2
        izlPrevozninaFR.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrevFRDin").Value = bPrevFRDin

        Dim izlPrevozninaUP As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevUPDin", SqlDbType.Decimal))
        izlPrevozninaUP.Size = 9
        izlPrevozninaUP.Precision = 12
        izlPrevozninaUP.Scale = 2
        izlPrevozninaUP.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrevUPDin").Value = bPrevUPDin

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

        Dim izlVrednostRobe As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrednostRobe", SqlDbType.Decimal))
        izlVrednostRobe.Size = 9
        izlVrednostRobe.Precision = 12
        izlVrednostRobe.Scale = 2
        izlVrednostRobe.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVrednostRobe").Value = outVrednostRobe

        '---------------------------------------------------------------------------------------------------------

        Dim exPrevozniPutZS As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevozniPutZS", SqlDbType.Int, 4))
        exPrevozniPutZS.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrevozniPutZS").Value = updPrevozniPutZS

        Dim exStanicaVia As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaVia", SqlDbType.Char, 5))
        exStanicaVia.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaVia").Value = updStanicaVia

        Dim exOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpDatum", SqlDbType.DateTime))
        exOtpDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpDatum").Value = bOtpDatum

        '---------------------------------------------------------------------------------------------------------

        Dim izlNarocitaPosiljka As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNarocitaPosiljka", SqlDbType.Char, 10))
        izlNarocitaPosiljka.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNarocitaPosiljka").Value = outNarocitaPosiljka



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

            bOtpDatum = spKomanda.Parameters("@outOtpDatum").Value

            bPrStanica = spKomanda.Parameters("@outPrStanica").Value
            bPrBroj = spKomanda.Parameters("@outPrBroj").Value
            mPrDatum = spKomanda.Parameters("@outPrDatum").Value
            updTkm = spKomanda.Parameters("@outTkm").Value

            updPrevozniPutZS = spKomanda.Parameters("@outPrevozniPutZS").Value
            updStanicaVia = spKomanda.Parameters("@outLomSt").Value
            '''mManipulativnoMesto = spKomanda.Parameters("@outMM").Value
            bSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
            IzborSaobracaja = bSaobracaj
            bVrSao = spKomanda.Parameters("@outVrSao").Value
            'bZsUlPrelaz = spKomanda.Parameters("@outZsUlPrelaz").Value
            'bZsIzPrelaz = spKomanda.Parameters("@outZsIzPrelaz").Value

            '''LomStanica = spKomanda.Parameters("@outLomSt").Value

            bIOP = spKomanda.Parameters("@outIOP").Value
            mSifraIzjave = bIOP
            outIznosPoIzjavi = spKomanda.Parameters("@outIznosPoIzjavi").Value
            bIOPFrNaknade = spKomanda.Parameters("@outIOPFrNaknade").Value
            upis_mFrNaknade = bIOPFrNaknade
            'bIOPFrDoPrelaza = spKomanda.Parameters("@outIOPFrDoPrelaza").Value
            'mDoPrelaza = bIOPFrDoPrelaza
            'bIOPIncoterms = spKomanda.Parameters("@outIOPIncoterms").Value
            'mIncoterms = bIOPIncoterms

            bNajava = spKomanda.Parameters("@outNajava").Value
            bSifraTarife = spKomanda.Parameters("@outSifraTarife").Value
            bSifraTarife72 = spKomanda.Parameters("@outSifraTarife72").Value
            bUgovor = spKomanda.Parameters("@outUgovor").Value
            outPosiljalacIzBaze = spKomanda.Parameters("@outPosiljalac").Value
            outPrimalacIzBaze = spKomanda.Parameters("@outPrimalac").Value
            bPrevoz = spKomanda.Parameters("@outPrevoz").Value

            '-------------------------- iznosi ---------------------------
            bValutaTL = spKomanda.Parameters("@outValuta").Value
            bPrevFRDin = spKomanda.Parameters("@outPrevFRDin").Value
            bPrevUPDin = spKomanda.Parameters("@outPrevUPDin").Value
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

            outVrednostRobe = spKomanda.Parameters("@outVrednostRobe").Value
            outNarocitaPosiljka = spKomanda.Parameters("@outNarocitaPosiljka").Value


            'popunjava 5 gridova
            Dim ug_mNazivKomitenta As String
            Dim ug_mPrimalac As String
            Dim ug_mVrstaObracuna As String
            Dim mizlaz As String

            Dim ug_mAdresaKomitenta As String
            Dim ug_mGradKomitenta As String
            Dim ug_mZemljaKomitenta As String
            Dim mRetVal As String


            If Microsoft.VisualBasic.Trim(bUgovor) <> "" Then
                'NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)
                NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, ug_mAdresaKomitenta, ug_mGradKomitenta, ug_mZemljaKomitenta, mRetVal)
            End If

            mVrstaObracuna = ug_mVrstaObracuna

            IzmenaTLUI()

            ''mManipulativnoMesto = spKomanda.Parameters("@outMM").Value

            'Dim mm_Stanica1, mm_Stanica2 As String


            'NadjiManipulativnoMesto(bRecID, mm_Stanica1, mm_Stanica2, bRetVal)


        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

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
    Public Sub Lozinka2(ByVal ipSifra1 As String, ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                      ByRef opCount As Int16, ByRef opUserID As String, ByRef opGrupa As String, _
                      ByRef opPovVrednost As String)


        'ipTabela=Tabela koja se koristi
        'ipSifra1=Sifra1 iz te tabele
        'ipSifra2=Sifra2 iz te tabele(ako je ima)
        'ipSifra3=Sifra3 iz te tabele(ako je ima)
        'broj neuspesnih pokusaja
        'opNaziv=povratna vrednost naziva
        'opPovVrednost=povratna vrednost 

        opUserID = ""
        opPovVrednost = ""
        opGrupa = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True



        '''Dim sqltext As String = "Select Naziv,Mesto,Zemlja,Adresa FROM Komitent " & _
        '''                                "WHERE (Sifra = '" & ulSifraKorisnika & "')"

        '''Dim sql_comm1 As New SqlClient.SqlCommand(sqltext, OkpDbVeza)
        '''Dim rdrRm As SqlClient.SqlDataReader
        '''Try
        '''    rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        '''    Do While rdrRm.Read()
        '''        izlNaziv = rdrRm.GetString(0)
        '''        izlMesto = rdrRm.GetString(1)
        '''        izlZemlja = rdrRm.GetString(2)
        '''        izlAdresa = rdrRm.GetString(3)
        '''        izlPovVrednost = ""
        '''    Loop
        '''    rdrRm.Close()

        '''Catch ex As Exception
        '''    MsgBox(ex.ToString())

        '''End Try

        '''If ulSifraKorisnika = "0" Or ulSifraKorisnika = "" Then
        '''    izlNaziv = ""
        '''    izlMesto = ""
        '''    izlZemlja = ""
        '''    izlAdresa = ""
        '''    izlPovVrednost = ""
        '''End If

        sqlText = "SELECT UserID, Lozinka, Grupa, Stanica FROM UserTab WHERE UserID = '" & ipSifra1 & "' AND Lozinka = '" & ipSifra2 & "' AND Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "'"
        Dim sql_comm As New SqlClient.SqlCommand(sqlText, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        'If opPovVrednost = "" Then

        'Dim uspKomanda As New SqlClient.SqlCommand(sqlText, OkpDbVeza)
        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            Else
                closeConn = False
            End If

            rdrRm = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrRm.Read()
                opUserID = rdrRm.GetString(0)
                'izlLozinka = rdrRm.GetString(1)
                opGrupa = rdrRm.GetString(2)
                'izlStanica = rdrRm.GetString(3)
                opPovVrednost = ""
            Loop
            rdrRm.Close()
            If opUserID = Nothing Then opPovVrednost = "Ne postoji takav podatak!" ' SLOG NE POSTOJI !!!
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message & "??"  'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description & " ?"  'Greska - bilo koja"
        Finally
            If closeConn Then OkpDbVeza.Close()
            'uspKomanda.Dispose()
        End Try

        'End If
    End Sub

    Public Sub sNadjiNaziv(ByVal ipTabela As String, ByVal ipSifra1 As String, _
                           ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
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
            Case "UicUpraveCIM"
                'sqlText = "SELECT Oznaka FROM UicUprave WHERE SifraUprave = '" & ipSifra1 & "'"
                sqlText = "SELECT UicStanice.Naziv, UicStanice.KB, UicUprave.NazivE " & _
                          "FROM UicStanice INNER JOIN " & _
                          "UicUprave ON UicStanice._SifraUprave = UicUprave.SifraUprave " & _
                          "WHERE (UicStanice.SifraStanice = '" & ipSifra1 & "')"
            Case "NazivTabele"
                sqlText = "SELECT SifTab FROM SifTabCen WHERE Ugovor = '" & ipSifra1 & "'"
            Case "TrasaCar"
                sqlText = "SELECT BrojVoza FROM Carina_TraseVozova WHERE BrojVoza = '" & ipSifra1 & "'"
            Case "UicOperateri"
                sqlText = "SELECT SifraUprave + Oznaka  FROM UicOperateri WHERE SifraOperatera = '" & ipSifra1 & "'"
                '''''''''sqlText = "SELECT Oznaka FROM UicOperateri WHERE Operater = '" & ipSifra1 & "' AND SifraUprave = '" & ipSifra2 & "'"
            Case "UicStanice"
                sqlText = "SELECT Naziv FROM UicStanice WHERE SifraStanice = '" & ipSifra1 & "'"
                'sqlText = "SELECT Naziv FROM UicStanice WHERE SifraStanice = '" & ipSifra1 & "'"
            Case "NHMPozicije"
                sqlText = "SELECT Naziv FROM NHMPozicije WHERE NHMPozicije.NHMSifra = '" & ipSifra1 & "'"
            Case "Tarife"
                sqlText = "SELECT Naziv WHERE Oznaka = '" & ipSifra1 & "'"
            Case "TabNaziv"
                sqlText = "SELECT SifTab FROM TabNaziv WHERE Ugovor = '" & ipSifra1 & "'"
            Case "UserTab"
                'sqlText = "SELECT UserID, Lozinka FROM UserTab WHERE UserID = '" & ipSifra1 & "' AND Lozinka = '" & ipSifra2 & "'"
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
                         ByRef opCount As Int16, ByRef opNaziv As String, ByRef opKB As String, ByRef opZemlja As String, _
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
        opZemlja = ""
        opPovVrednost = "Ne postoji takav podatak!"

        Dim closeConn As Boolean = True


        '-------------------- naziv i KB
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim sqltext As String = "Select Naziv " & _
                                "FROM ZsStanice " & _
                                "WHERE (SifraStanice = '72" & ipSifra1 & "')"

        Dim sql_comm1 As New SqlClient.SqlCommand(sqltext, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        Try
            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrRm.Read()
                opNaziv = rdrRm.GetString(0)
                opKB = ""
                opZemlja = ""
                opPovVrednost = ""
            Loop
            rdrRm.Close()

        Catch ex As Exception
            MsgBox(ex.ToString())

        End Try

    End Sub

    Public Sub FillGrid()
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()

        'Dim drKola As DataRow
        'Dim drNhm As DataRow
        Dim ii1 As Int32 = 0
        Dim IBK

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        dsSlogKola.Clear()
        dsSlogNHM.Clear()

        Try
            '-------------------------------------- popunjava Grid Kola ---------------------------------------------------
            Dim adSlogKola As New SqlDataAdapter(" SELECT IBK7 AS Expr1, Tara11 AS Expr2, GranTov12 AS Expr12, netopotl13 AS Expr3, NHM14 AS Expr4, UtiIB135 AS Expr5, UtiTip136 AS Expr6, UtiMasa137 AS Expr7, " _
                                  & " UtiBrutoMasa138 AS Expr8, UtiNHM139 AS Expr9, UtiPredajniList140 AS Expr10, UtiIB241 AS Expr11, UtiTip242 AS Expr12, UtiMasa243 AS Expr13, " _
                                  & " UtiBrutoMasa244 AS Expr14, UtiNHM245 AS Expr15, UtiPredajniList246 AS Expr16, UtiIB347 AS Expr17, UtiTip348 AS Expr18, UtiMasa349 AS Expr19, " _
                                  & " UtiBrutoMasa350 AS Expr20, UtiNHM351 AS Expr21, UtiPredajniList352 AS Expr22, OtpBroj29 " _
                                  & " FROM radnik.S1_676 " _
                                  & " WHERE (OtpBroj29 = '" & eOtpBroj & "')", DbVeza)


            ii1 = adSlogKola.Fill(dsSlogKola)

            For k As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1
                Dim _eUprava As String
                Dim _eVlasnik As String
                Dim _eSerija As String
                Dim _eOsovine As Int32 = 2
                Dim _eVrsta As String
                Dim _eICF As String
                Dim eIBK_kb As String

                Dim _eRetVal As String = ""

                IBK = dsSlogKola.Tables(0).Rows(k).Item(0)
                IBK_parameters(IBK, _eUprava, _eVlasnik, _eSerija, _eOsovine, _eVrsta, _eICF, eIBK_kb, _eRetVal)


                Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & IBK & "'")
                If dtRow.Length > 0 Then
                    'Kola su vec upisana!
                Else
                    Dim drKola As DataRow = dtKola.NewRow

                    drKola.ItemArray() = New Object() {IBK, _eUprava, _eVlasnik, _eSerija, _eVrsta, _
                                                       _eOsovine, dsSlogKola.Tables(0).Rows(k).Item(1), dsSlogKola.Tables(0).Rows(k).Item(2), "0", _
                                                       "1", 0, 0, _eICF, eIBK_kb, "I"}
                    dtKola.Rows.Add(drKola)
                End If

            Next

            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------
            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1
                If IBK = dsSlogKola.Tables(0).Rows(jj).Item(0) Then
                    Dim drNHM As DataRow = dtNhm.NewRow

                    drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(0), dsSlogKola.Tables(0).Rows(jj).Item(4), _
                                                      dsSlogKola.Tables(0).Rows(jj).Item(3), 1, "0", _
                                                      dsSlogKola.Tables(0).Rows(jj).Item(6), dsSlogKola.Tables(0).Rows(jj).Item(5), _
                                                      dsSlogKola.Tables(0).Rows(jj).Item(7), 0, dsSlogKola.Tables(0).Rows(jj).Item(9), _
                                                      dsSlogKola.Tables(0).Rows(jj).Item(10), "", "I"}
                    dtNhm.Rows.Add(drNHM)

                    If dsSlogKola.Tables(0).Rows(jj).Item(11) <> "00000000000" Then

                        drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(0), dsSlogKola.Tables(0).Rows(jj).Item(4), _
                                                          dsSlogKola.Tables(0).Rows(jj).Item(3), 1, "0", _
                                                          dsSlogKola.Tables(0).Rows(jj).Item(12), dsSlogKola.Tables(0).Rows(jj).Item(11), _
                                                          dsSlogKola.Tables(0).Rows(jj).Item(13), 0, dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                          dsSlogKola.Tables(0).Rows(jj).Item(16), "", "I"}
                        dtNhm.Rows.Add(drNHM)


                        If dsSlogKola.Tables(0).Rows(jj).Item(17) <> "00000000000" Then
                            drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(0), dsSlogKola.Tables(0).Rows(jj).Item(4), _
                                                              dsSlogKola.Tables(0).Rows(jj).Item(3), 1, "0", _
                                                              dsSlogKola.Tables(0).Rows(jj).Item(18), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                              dsSlogKola.Tables(0).Rows(jj).Item(19), 0, dsSlogKola.Tables(0).Rows(jj).Item(21), _
                                                              dsSlogKola.Tables(0).Rows(jj).Item(22), "", "I"}
                            dtNhm.Rows.Add(drNHM)
                        End If

                    End If
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Public Sub IzmenaTL()

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
            Dim adSlogKola As New SqlDataAdapter(" SELECT dbo.SlogKola.KolaStavka, dbo.SlogKola.IBK, dbo.SlogKola.Uprava, dbo.SlogKola.Vlasnik, dbo.SlogKola.Serija, dbo.SlogKola.Osovine, " _
                                & " dbo.SlogKola.Tara, dbo.SlogKola.GranTov, dbo.SlogKola.Stitna, dbo.SlogKola.TipKola, dbo.SlogKola.Naknada, dbo.SlogKola.Kontrola,  " _
                                & " dbo.SlogKalk.UkupnoKola, dbo.SlogRoba.NHM, dbo.SlogRoba.NHMRazred, dbo.SlogRoba.SMasa, dbo.SlogRoba.RMasa, dbo.SlogRoba.RID,   " _
                                & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.SMasaDec " _
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
                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(20), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(18), "", 0, 0, "", "", "", "U"}

                '''drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                '''                                  dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                '''                                  dsSlogKola.Tables(0).Rows(jj).Item(18), "", 0, 0, "", "", "", "U"}


                dtNhm.Rows.Add(drNHM)

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

            '& " WHERE  (dbo.SlogKalk.OtpUprava = '" & mOtpUprava & "') AND (dbo.SlogKalk.OtpStanica = '" & mOtpStanica & "') AND (dbo.SlogKalk.OtpBroj = '" & mOtpBroj & "') AND (dbo.SlogKalk.OtpDatum = '" & mMesec & "." & mDan & "." & mGodina & "')", DbVeza)

            'ovo vrati ako ne radi sa recid-om!!!
            'Dim adSlogNak As New SqlDataAdapter(" SELECT dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, dbo.SlogNaknada.Iznos, dbo.SlogNaknada.Valuta, dbo.SlogNaknada.Kolicina, " _
            '                                  & " dbo.SlogNaknada.DanCas, dbo.SlogNaknada.Placanje, dbo.SlogNaknada.Vrsta " _
            '                                  & " FROM dbo.SlogNaknada INNER JOIN " _
            '                                  & " dbo.SlogKalk ON dbo.SlogNaknada.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogNaknada.OtpStanica = dbo.SlogKalk.OtpStanica AND " _
            '                                  & " dbo.SlogNaknada.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogNaknada.OtpDatum = dbo.SlogKalk.OtpDatum " _
            '                                  & " WHERE  (dbo.SlogKalk.OtpUprava = '" & mOtpUprava & "') AND (dbo.SlogKalk.OtpStanica = '" & mOtpStanica & "') AND (dbo.SlogKalk.OtpBroj = '" & mOtpBroj & "') AND (dbo.SlogKalk.OtpDatum = '" & mMesec & "." & mDan & "." & mGodina & "')", DbVeza)


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
    Public Sub BrisiTL(ByVal _RecID As Int32, ByVal _Stanica As String, _
                       ByRef _mRetVal As Int32)

        _mRetVal = 0
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.wrspBrisanjeTL", DbVeza)
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
        Catch ex As Exception
            _mRetVal = Err.Description & " Greska u programu!"
        Catch sqlexp As Exception
            _mRetVal = sqlexp.Message & " SQL greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
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

    Public Sub Sql2Txt676(ByVal m_DatumIzlaza As Date, ByVal m_SatVoza As String, ByVal m_BrojVoza As Int32, _
                          ByVal m_wagonlistnumber6 As String, ByRef m_mRetVal As String)

        m_mRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.Pxxx_676", DbVeza) ' testiranje
        'Dim spKomanda As New SqlClient.SqlCommand("radnik.P_676", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inBrojVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@BrojVoza", SqlDbType.Int, 4))
        inBrojVoza.Direction = ParameterDirection.Input
        spKomanda.Parameters("@BrojVoza").Value = m_BrojVoza

        Dim inSatVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@SatVoza1", SqlDbType.Char, 5))
        inSatVoza.Direction = ParameterDirection.Input
        spKomanda.Parameters("@SatVoza1").Value = m_SatVoza

        Dim inDatumVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@DatumIzlaza", SqlDbType.DateTime, 8))
        inDatumVoza.Direction = ParameterDirection.Input
        spKomanda.Parameters("@DatumIzlaza").Value = m_DatumIzlaza

        Dim inKol65 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@wagonlistnumber6", SqlDbType.Char, 4))
        inKol65.Direction = ParameterDirection.Input
        spKomanda.Parameters("@wagonlistnumber6").Value = m_wagonlistnumber6

        ''Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        ''izlRetVal.Direction = ParameterDirection.ReturnValue
        ''spKomanda.Parameters("@outRetVal").Value = m_mRetVal

        Try
            spKomanda.ExecuteScalar()

            ''m_mRetVal = spKomanda.Parameters("@outRetVal").Value
            m_mRetVal = "ok"

        Catch ex As Exception
            m_mRetVal = Err.Description & " Greska u programu!"
        Catch sqlexp As Exception
            m_mRetVal = sqlexp.Message & " SQL greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub NadjiIzlazniVoz(ByVal m_Stanica As String, ByVal m_DatumIzlaza As Date, _
                               ByVal m_SatVoza As String, ByVal m_BrojVoza As Int32, _
                               ByRef outRetVal As String)

        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiIzlazniVoz", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5))
        inStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica").Value = m_Stanica

        Dim inDatumVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime))
        inDatumVoza.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatumIzlaza").Value = m_DatumIzlaza

        Dim inSat As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSat", SqlDbType.Char, 2))
        inSat.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSat").Value = m_SatVoza

        Dim inBrojVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4))
        inBrojVoza.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojVoza").Value = m_BrojVoza

        ''Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        ''izlRetVal.Direction = ParameterDirection.Output
        ''spKomanda.Parameters("@outRetVal").Value = outRetVal

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()
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
    Public Sub IBK_parameters(ByVal eIbk As String, ByRef eUprava As String, ByRef eVlasnik As String, _
                              ByRef eSerija As String, ByRef eOsovine As Int32, _
                              ByRef eVrsta As String, ByRef eICF As String, _
                              ByRef eIBK_KB As String, _
                              ByRef outRetVal As String)

        Dim rv As String = ""
        ''Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & mIBK & "'")

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspKomanda As New SqlClient.SqlCommand("spNadjiSveIzIBK", DbVeza)
        uspKomanda.CommandType = CommandType.StoredProcedure

        Dim upIBK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
        upIBK.Direction = ParameterDirection.Input
        uspKomanda.Parameters("@inIBK").Value = eIbk

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
            eUprava = uspKomanda.Parameters("@outSkrUprava").Value
            eVlasnik = uspKomanda.Parameters("@outVlasnistvo").Value
            eSerija = uspKomanda.Parameters("@outSerija").Value
            eOsovine = uspKomanda.Parameters("@outBrojOsovina").Value
            If uspKomanda.Parameters("@outVrsta").Value = "1" Then
                eVrsta = "O"
            Else
                eVrsta = "S"
            End If
            eICF = uspKomanda.Parameters("@outKolaICFIzuzeta").Value
            eIBK_KB = uspKomanda.Parameters("@outKontrBrojOK").Value

        Catch Exp As Exception
            rv = Err.Description & "??"
        Finally
            DbVeza.Close()
            uspKomanda.Dispose()
        End Try
    End Sub
    Public Sub sNadjiIzlaznuNalepnicu(ByVal ipSifra1 As Int32, ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                               ByVal ipSifra4 As String, ByRef opNaziv As String, _
                               ByRef opPovVrednost As String)

        'opNaziv=povratna vrednost naziva
        'opPovVrednost=povratna vrednost 

        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True

        sqlText = "SELECT IzEtiketa From dbo.SlogKalk " _
                & "WHERE IzEtiketa = " & ipSifra1 _
                & " AND ZsIzPrelaz = '" & ipSifra2 & "'" _
                & " AND ObrGodina = '" & ipSifra3 & "'" _
          '      & " AND ObrMesec = '" & ipSifra4 & "'"

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
    Public Sub UpdateJCI(ByVal ipTrans As SqlTransaction, ByVal inRecId As Int32, ByVal exJci As String, ByVal bDatum1 As Date, ByVal bDatum2 As Date, _
                         ByRef bRetVal As String)

        bRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.UpdateJCI", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        Dim ulRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4))
        ulRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRecID").Value = inRecId

        Dim ulJCI As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inJCI", SqlDbType.Char, 12))
        ulJCI.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inJCI").Value = exJci

        Dim ulDatum1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum1", SqlDbType.DateTime))
        ulDatum1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum1").Value = bDatum1

        Dim ulDatum2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum2", SqlDbType.DateTime))
        ulDatum2.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum2").Value = bDatum2

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        'Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        'izlRetVal.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outRetVal").Value = bRetVal

        spKomanda.Transaction = ipTrans

        Try
            'spKomanda.ExecuteScalar()
            'bRetVal = spKomanda.Parameters("@outRetVal").Value
            spKomanda.ExecuteNonQuery()
            If spKomanda.Parameters("@RETURN_VALUE").Value = 0 Then bRetVal = "Ništa nije upisano u bazu!"
        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            'OkpDbVeza.Close()

            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub NadjiTLuBazi(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                            ByRef bRecId As Int32, ByRef bStanicaId As String, _
                            ByRef bRetVal As String)

        bRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiUvozJCI", DbVeza)
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
        Dim exRecId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecId

        Dim exStanicaId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaID", SqlDbType.Char, 5))
        exStanicaId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaID").Value = bStanicaId

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()
            UpdRecID = spKomanda.Parameters("@outRecID").Value
            UpdStanicaRecID = spKomanda.Parameters("@outStanicaID").Value
            bRetVal = spKomanda.Parameters("@outRetVal").Value
        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub NadjieCim(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpOperater As String, ByVal bOtpBroj As String, ByRef bRecId As Int32, _
                         ByRef bRetVal As String)

        bRetVal = ""
        If eCimVeza.State = ConnectionState.Closed Then
            eCimVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.Nadji_eCim", eCimVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.NVarChar, 2))
        ulazUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.VarChar, 6))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulOperater As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpOperater", SqlDbType.VarChar, 4))
        ulOperater.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpOperater").Value = bOtpOperater

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.VarChar, 6))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        '-------------------------------------- Izlazne promenljive ----------------------------------------------

        Dim exRecId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecId

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            UpdRecID = spKomanda.Parameters("@outRecID").Value
            bRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            eCimVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Public Sub NadjiTrasu(ByVal exStanica As String, ByVal _Trasa As Int32, ByVal _SatVoza As String, ByVal _Datum As Date, ByRef bRecId As Int32, _
                          ByRef bRetVal As String)

        bRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTrasuJCI", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulazStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5))
        ulazStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica").Value = exStanica

        Dim ulTrasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTrasa", SqlDbType.Int, 4))
        ulTrasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTrasa").Value = _Trasa

        Dim ulSat As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSat", SqlDbType.Char, 5))
        ulSat.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSat").Value = _SatVoza

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = _Datum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecId

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()
            UpdRecID = spKomanda.Parameters("@outRecID").Value
            bRetVal = spKomanda.Parameters("@outRetVal").Value
        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub UpdateJCIVoz(ByVal ipTrans As SqlTransaction, ByVal inTrasa As Int32, ByVal inSat As String, ByVal inDatum As Date, _
                            ByVal exJci As String, ByVal bDatum1 As Date, ByVal bDatum2 As Date, _
                            ByRef bRetVal As String)

        bRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.UpdateJCIVoz", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        Dim ulTrasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTrasa", SqlDbType.Int, 4))
        ulTrasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTrasa").Value = inTrasa

        Dim ulSat As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSat", SqlDbType.Char, 5))
        ulSat.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSat").Value = inSat

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = inDatum

        Dim ulJCI As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inJCI", SqlDbType.Char, 12))
        ulJCI.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inJCI").Value = exJci

        Dim ulDatum1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum1", SqlDbType.DateTime))
        ulDatum1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum1").Value = bDatum1

        Dim ulDatum2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum2", SqlDbType.DateTime))
        ulDatum2.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum2").Value = bDatum2

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        'Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        'izlRetVal.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outRetVal").Value = bRetVal

        spKomanda.Transaction = ipTrans

        Try
            'spKomanda.ExecuteScalar()
            'bRetVal = spKomanda.Parameters("@outRetVal").Value
            spKomanda.ExecuteNonQuery()
            If spKomanda.Parameters("@RETURN_VALUE").Value = 0 Then bRetVal = "Ništa nije upisano u bazu!"
        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally

            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub NadjiTovarniListTrz(ByVal inTipStanice As String, ByVal inStanica As String, ByVal inNalepnica As Int32, ByVal inObrGodina As String, _
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

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.wrNadjiTLTrz", DbVeza)
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

                '''''proveri
                ''''NadjiUgovor(mBrojUg, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)
                ''''mNazivKomitenta = ug_mNazivKomitenta

                IzmenaTL()
            End If
            '----------------------------------------------------------------------------------------------------------

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub BrisiTLUI(ByVal _RecID As Int32, ByVal _Stanica As String, _
                           ByRef _mRetVal As Int32)

        _mRetVal = 0
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.wrspBrisanjeTLUI", DbVeza)
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
        Catch ex As Exception
            _mRetVal = Err.Description & " Greska u programu!"
        Catch sqlexp As Exception
            _mRetVal = sqlexp.Message & " SQL greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub NadjiTovarniListDel(ByVal exOtpUprava As String, ByVal bOtpStanica As String, _
                               ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                               ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                               ByRef bRetVal As String)

        bRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.wrNadjiTL2Del", DbVeza)
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
                                & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav, dbo.SlogRoba.PaleteR, dbo.SlogKola.Prevoznina  " _
                                & " FROM dbo.SlogKola INNER JOIN  " _
                                & " dbo.SlogKalk ON dbo.SlogKola.OtpUprava = dbo.SlogKalk.OtpUprava AND dbo.SlogKola.OtpStanica = dbo.SlogKalk.OtpStanica AND   " _
                                & " dbo.SlogKola.OtpBroj = dbo.SlogKalk.OtpBroj AND dbo.SlogKola.OtpDatum = dbo.SlogKalk.OtpDatum INNER JOIN  " _
                                & " dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND   " _
                                & " dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka  " _
                                & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)


            ' dodato u gornji SELECT - dbo.SlogRoba.PaleteR kao Item(21)        22.01.2013.  
            ' dodato u gornji SELECT - dbo.SlogKola.Prevoznina kao Item(22) za donji drKola        22.01.2013.  

            ii1 = adSlogKola.Fill(dsSlogKola)

            For k As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                mStavkaKola = dsSlogKola.Tables(0).Rows(k).Item(0)
                IBK = dsSlogKola.Tables(0).Rows(k).Item(1)


                Dim bTip As Integer = dsSlogKola.Tables(0).Rows(k).Item(9)
                Dim bVrsta As Char = "O"
                If (bTip = 2) Or (bTip = 4) Or (bTip = 6) Then
                    bVrsta = "S"
                Else
                    bVrsta = "O"
                End If

                Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & IBK & "'")
                If dtRow.Length > 0 Then
                    'Kola su vec upisana!
                Else
                    Dim drKola As DataRow = dtKola.NewRow
                    drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(6), _
                                                                          dsSlogKola.Tables(0).Rows(k).Item(4), dsSlogKola.Tables(0).Rows(k).Item(5), _
                                                                          bVrsta, dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(7), _
                                                                          dsSlogKola.Tables(0).Rows(k).Item(8), dsSlogKola.Tables(0).Rows(k).Item(9), _
                                                                          dsSlogKola.Tables(0).Rows(k).Item(22), _
                                                                          dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), _
                                                                          dsSlogKola.Tables(0).Rows(k).Item(19), "U"}

                    'drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(6), _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(4), dsSlogKola.Tables(0).Rows(k).Item(5), _
                    '                                   "O", dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(7), _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(8), dsSlogKola.Tables(0).Rows(k).Item(9), 0, _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(19), "U"}

                    ''drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(3), _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(4), "O", dsSlogKola.Tables(0).Rows(k).Item(5), _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(6), dsSlogKola.Tables(0).Rows(k).Item(7), _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(8), dsSlogKola.Tables(0).Rows(k).Item(9), 0, _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), _
                    ''                                   dsSlogKola.Tables(0).Rows(k).Item(19), "U"}

                    dtKola.Rows.Add(drKola)
                End If
            Next


            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------
            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                Dim drNHM As DataRow = dtNhm.NewRow
                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(18), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                  "", dsSlogKola.Tables(0).Rows(jj).Item(14), 0, 0, "", "", "", "U", _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20), dsSlogKola.Tables(0).Rows(jj).Item(21)}
                ' dodato - dsSlogKola.Tables(0).Rows(jj).Item(21)       22.01.2013.

                bVozarinskiStavPoKolima = dsSlogKola.Tables(0).Rows(0).Item(20)

                If jj = 0 Then      ' nhm prve robe na prvim kolima
                    Dim tmpNHM As String = dsSlogKola.Tables(0).Rows(jj).Item(13)
                    'Dim NHM4 As String
                    NHM4 = Microsoft.VisualBasic.Mid(tmpNHM, 1, 4)

                    If NHM4 = "9941" Or NHM4 = "9931" Then
                        bKontejneri = True
                    Else
                        bKontejneri = False
                    End If
                End If

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

            bUkupnoIzBaze = 0



            For k As Int16 = 0 To dsSlogNak.Tables(0).Rows.Count - 1
                Dim drNaknade As DataRow = dtNaknade.NewRow
                drNaknade.ItemArray() = New Object() {dsSlogNak.Tables(0).Rows(k).Item(0), dsSlogNak.Tables(0).Rows(k).Item(1), dsSlogNak.Tables(0).Rows(k).Item(2), _
                                                      dsSlogNak.Tables(0).Rows(k).Item(3), dsSlogNak.Tables(0).Rows(k).Item(4), dsSlogNak.Tables(0).Rows(k).Item(5), _
                                                      dsSlogNak.Tables(0).Rows(k).Item(6), dsSlogNak.Tables(0).Rows(k).Item(7), "U"}
                'If dsSlogNak.Tables(0).Rows(k).Item(0) <> "62" Then
                '    dtNaknade.Rows.Add(drNaknade)
                'Else
                '    ImaPDV = True
                'End If
                dtNaknade.Rows.Add(drNaknade)
                'If dsSlogNak.Tables(0).Rows(k).Item(0) = "62" Then
                '    ImaPDV = True
                'End If



                bUkupnoIzBaze = bUkupnoIzBaze + 1
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

            bUkupnoK211IzBaze = dsSlogK211.Tables(0).Rows.Count()

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
        'dsSlogUic.Clear()
        'Try

        '    Dim adSlogUic As New SqlDataAdapter(" SELECT dbo.SlogUic.Uprava, dbo.SlogUic.UlPrelaz, dbo.SlogUic.IzPrelaz, dbo.SlogUic.Valuta, (dbo.SlogUic.PrevFR+dbo.SlogUic.PrevUP), " _
        '                                      & " dbo.SlogUic.Nak1, dbo.SlogUic.Iznos1, dbo.SlogUic.Nak2, dbo.SlogUic.Iznos2, dbo.SlogUic.Nak3, dbo.SlogUic.Iznos3, " _
        '                                      & " dbo.SlogUic.SifraGS, dbo.SlogUic.PredujamVal, dbo.SlogUic.Predujam, dbo.SlogUic.tlValuta, dbo.SlogUic.tlFranko, dbo.SlogUic.tlUpuceno, " _
        '                                      & " dbo.SlogUic.StavkaUIC, dbo.SlogUic.SifraPP, dbo.SlogUic.tlUpucenoDin " _
        '                                      & " FROM SlogUIC " _
        '                                      & " WHERE  (dbo.SlogUic.RecID = '" & UpdRecID & "') AND (dbo.SlogUic.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

        '    Dim tmp_pp As String = ""
        '    m_UicPrevozniPut = ""
        '    ii2 = adSlogUic.Fill(dsSlogUic)

        '    For k As Int16 = 0 To dsSlogUic.Tables(0).Rows.Count - 1
        '        Dim drUic As DataRow = dtUic.NewRow
        '        drUic.ItemArray() = New Object() {dsSlogUic.Tables(0).Rows(k).Item(0), dsSlogUic.Tables(0).Rows(k).Item(1), dsSlogUic.Tables(0).Rows(k).Item(2), dsSlogUic.Tables(0).Rows(k).Item(3), dsSlogUic.Tables(0).Rows(k).Item(4), _
        '                                          dsSlogUic.Tables(0).Rows(k).Item(5), dsSlogUic.Tables(0).Rows(k).Item(6), dsSlogUic.Tables(0).Rows(k).Item(7), dsSlogUic.Tables(0).Rows(k).Item(8), dsSlogUic.Tables(0).Rows(k).Item(9), dsSlogUic.Tables(0).Rows(k).Item(10), _
        '                                          dsSlogUic.Tables(0).Rows(k).Item(11), dsSlogUic.Tables(0).Rows(k).Item(12), dsSlogUic.Tables(0).Rows(k).Item(13), dsSlogUic.Tables(0).Rows(k).Item(14), dsSlogUic.Tables(0).Rows(k).Item(15), dsSlogUic.Tables(0).Rows(k).Item(16), _
        '                                          "U", dsSlogUic.Tables(0).Rows(k).Item(17), dsSlogUic.Tables(0).Rows(k).Item(19)}
        '        dtUic.Rows.Add(drUic)

        '        tmp_pp = dsSlogUic.Tables(0).Rows(k).Item(18)
        '        m_UicPrevozniPut = m_UicPrevozniPut & dsSlogUic.Tables(0).Rows(k).Item(0)
        '    Next

        '    '--------------- okrenuti smer zbog izvoza ----------------
        '    If IzborSaobracaja = "3" Then
        '        Dim aString As String = ""
        '        Dim aString1 As String = ""
        '        Dim ii As Int16 = 0

        '        For ii = (Len(m_UicPrevozniPut) / 2) To 1 Step -1
        '            aString = aString & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2)
        '        Next

        '        For ii = 1 To (Len(m_UicPrevozniPut) / 2)
        '            aString1 = aString1 & " " & Microsoft.VisualBasic.Mid(aString, 2 * ii - 1, 2)
        '        Next

        '        m_UicPrevozniPut = aString1

        '    Else
        '        Dim aString1 As String = ""
        '        Dim ii As Int16 = 0

        '        For ii = 1 To (Len(m_UicPrevozniPut) / 2)
        '            aString1 = aString1 & " " & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2)
        '        Next

        '        m_UicPrevozniPut = aString1

        '    End If

        '    m_UicPrevozniPut = tmp_pp & " > " & m_UicPrevozniPut

        'Catch sqlex As SqlException
        '    Dim aa As String
        '    aa = sqlex.Message
        'End Try


    End Sub
    Public Sub IzmenaTLWR()

        Dim mStavkaKola
        Dim IBK
        Dim ii1 As Int32 = 0
        Dim ii2 As Int32 = 0

        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        'dtUic.Clear()

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        dsSlogKola.Clear()
        dsSlogNHM.Clear()

        Try
            '====================================================================================================================
            '-------------------------------------- popunjava Grid Kola ---------------------------------------------------
            Dim adSlogKola As New SqlDataAdapter(" SELECT dbo.SlogKola.KolaStavka, dbo.SlogKola.IBK, dbo.SlogKola.Uprava, dbo.SlogKola.Vlasnik, dbo.SlogKola.Serija, dbo.SlogKola.Osovine, " _
                                & " dbo.SlogKola.Tara, dbo.SlogKola.GranTov, dbo.SlogKola.Stitna, dbo.SlogKola.TipKola, dbo.SlogKola.Naknada, dbo.SlogKola.Kontrola,  " _
                                & " dbo.SlogKalk.UkupnoKola, dbo.SlogRoba.NHM, dbo.SlogRoba.NHMRazred, dbo.SlogRoba.SMasa, dbo.SlogRoba.RMasa, dbo.SlogRoba.RID,   " _
                                & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF " _
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


                Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & IBK & "'")
                If dtRow.Length > 0 Then
                    'Kola su vec upisana!
                Else
                    Dim drKola As DataRow = dtKola.NewRow
                    '###############################################################################
                    'drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(4), "O", _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(5), dsSlogKola.Tables(0).Rows(k).Item(6), dsSlogKola.Tables(0).Rows(k).Item(7), dsSlogKola.Tables(0).Rows(k).Item(8), _
                    '                                   dsSlogKola.Tables(0).Rows(k).Item(9), 0, dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), dsSlogKola.Tables(0).Rows(k).Item(19), "U"}
                    '###############################################################################

                    drKola.ItemArray() = New Object() {IBK, dsSlogKola.Tables(0).Rows(k).Item(2), dsSlogKola.Tables(0).Rows(k).Item(6), _
                                                                          dsSlogKola.Tables(0).Rows(k).Item(4), dsSlogKola.Tables(0).Rows(k).Item(5), _
                                                                          "O", dsSlogKola.Tables(0).Rows(k).Item(3), dsSlogKola.Tables(0).Rows(k).Item(7), _
                                                                          dsSlogKola.Tables(0).Rows(k).Item(8), dsSlogKola.Tables(0).Rows(k).Item(9), 0, _
                                                                          dsSlogKola.Tables(0).Rows(k).Item(10), dsSlogKola.Tables(0).Rows(k).Item(11), _
                                                                          dsSlogKola.Tables(0).Rows(k).Item(19), "U"}

                    dtKola.Rows.Add(drKola)
                End If
            Next

            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------
            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1
                Dim drNHM As DataRow = dtNhm.NewRow
                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(15), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(18), "", 0, 0, "", "", "", "U"}

                dtNhm.Rows.Add(drNHM)

            Next

            '====================================================================================================================

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
                                              & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", DbVeza)

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
    Public Sub IzmenaTLWR1()

        Dim mStavkaKola
        Dim IBK
        Dim ii1 As Int32 = 0
        Dim ii2 As Int32 = 0

        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        dtUic.Clear()
        dtK211.Clear()

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        dsSlogKola.Clear()
        dsSlogNHM.Clear()

        Try
            '-------------------------------------- popunjava Grid Kola ---------------------------------------------------
            Dim adSlogKola As New SqlDataAdapter("SELECT dbo.SlogKola.KolaStavka, dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogKola.Uprava,  " _
                                & " dbo.SlogKola.Vlasnik, dbo.SlogKola.Serija, dbo.SlogKola.Osovine, dbo.SlogKola.GranTov, dbo.SlogKola.Stitna, " _
                                & " dbo.SlogKola.TipKola, dbo.SlogKola.Naknada, dbo.SlogKola.Kontrola, dbo.SlogKalk.UkupnoKola, dbo.SlogRoba.NHM, " _
                                & " dbo.SlogRoba.NHMRazred, dbo.SlogRoba.SMasa, dbo.SlogRoba.RMasa, dbo.SlogRoba.RID, " _
                                & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav  " _
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



            '----------------------------------------- popunjava Grid Roba ---------------------------------------------------
            For jj As Int16 = 0 To dsSlogKola.Tables(0).Rows.Count - 1

                Dim drNHM As DataRow = dtNhm.NewRow
                drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(18), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                  "", dsSlogKola.Tables(0).Rows(jj).Item(14), 0, 0, "", "", "", "U", _
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
                                              & " WHERE  (dbo.SlogKalk.RecID = '" & UpdRecID & "') AND (dbo.SlogKalk.Stanica = '" & UpdStanicaRecID & "')", DbVeza)

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

        'dsSlogK211.Clear()
        'Try
        '    Dim adSlogK211 As New SqlDataAdapter(" SELECT dbo.SlogK211.SifraK211, dbo.ZsKontrolnePrimedbe.NazivSrpski " _
        '                                   & " FROM dbo.SlogK211 INNER JOIN " _
        '                                   & " dbo.ZsKontrolnePrimedbe ON dbo.SlogK211.SifraK211 = dbo.ZsKontrolnePrimedbe.SifraK211 " _
        '                                   & " WHERE  (dbo.SlogK211.RecID = '" & UpdRecID & "') AND (dbo.SlogK211.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

        '    ii2 = adSlogK211.Fill(dsSlogK211)

        '    For k As Int16 = 0 To dsSlogK211.Tables(0).Rows.Count - 1
        '        Dim drK211 As DataRow = dtK211.NewRow
        '        drK211.ItemArray() = New Object() {dsSlogK211.Tables(0).Rows(k).Item(0), dsSlogK211.Tables(0).Rows(k).Item(1), "U"}
        '        dtK211.Rows.Add(drK211)
        '    Next

        'Catch sqlex As SqlException
        '    Dim aa As String
        '    aa = sqlex.Message
        'End Try


        '-------------------------------------- popunjava Grid UIC ---------------------------------------------------
        'dsSlogUic.Clear()
        'Try

        '    Dim adSlogUic As New SqlDataAdapter(" SELECT dbo.SlogUic.Uprava, dbo.SlogUic.UlPrelaz, dbo.SlogUic.IzPrelaz, dbo.SlogUic.Valuta, (dbo.SlogUic.PrevFR+dbo.SlogUic.PrevUP), " _
        '                                      & " dbo.SlogUic.Nak1, dbo.SlogUic.Iznos1, dbo.SlogUic.Nak2, dbo.SlogUic.Iznos2, dbo.SlogUic.Nak3, dbo.SlogUic.Iznos3, " _
        '                                      & " dbo.SlogUic.SifraGS, dbo.SlogUic.PredujamVal, dbo.SlogUic.Predujam, dbo.SlogUic.tlValuta, dbo.SlogUic.tlFranko, dbo.SlogUic.tlUpuceno, " _
        '                                      & " dbo.SlogUic.StavkaUIC, dbo.SlogUic.SifraPP, dbo.SlogUic.tlUpucenoDin " _
        '                                      & " FROM SlogUIC " _
        '                                      & " WHERE  (dbo.SlogUic.RecID = '" & UpdRecID & "') AND (dbo.SlogUic.Stanica = '" & UpdStanicaRecID & "')", OkpDbVeza)

        '    Dim tmp_pp As String = ""
        '    m_UicPrevozniPut = ""
        '    ii2 = adSlogUic.Fill(dsSlogUic)

        '    For k As Int16 = 0 To dsSlogUic.Tables(0).Rows.Count - 1
        '        Dim drUic As DataRow = dtUic.NewRow
        '        drUic.ItemArray() = New Object() {dsSlogUic.Tables(0).Rows(k).Item(0), dsSlogUic.Tables(0).Rows(k).Item(1), dsSlogUic.Tables(0).Rows(k).Item(2), dsSlogUic.Tables(0).Rows(k).Item(3), dsSlogUic.Tables(0).Rows(k).Item(4), _
        '                                          dsSlogUic.Tables(0).Rows(k).Item(5), dsSlogUic.Tables(0).Rows(k).Item(6), dsSlogUic.Tables(0).Rows(k).Item(7), dsSlogUic.Tables(0).Rows(k).Item(8), dsSlogUic.Tables(0).Rows(k).Item(9), dsSlogUic.Tables(0).Rows(k).Item(10), _
        '                                          dsSlogUic.Tables(0).Rows(k).Item(11), dsSlogUic.Tables(0).Rows(k).Item(12), dsSlogUic.Tables(0).Rows(k).Item(13), dsSlogUic.Tables(0).Rows(k).Item(14), dsSlogUic.Tables(0).Rows(k).Item(15), dsSlogUic.Tables(0).Rows(k).Item(16), _
        '                                          "U", dsSlogUic.Tables(0).Rows(k).Item(17), dsSlogUic.Tables(0).Rows(k).Item(19)}
        '        dtUic.Rows.Add(drUic)

        '        tmp_pp = dsSlogUic.Tables(0).Rows(k).Item(18)
        '        m_UicPrevozniPut = m_UicPrevozniPut & dsSlogUic.Tables(0).Rows(k).Item(0)
        '    Next

        '    '--------------- okrenuti smer zbog izvoza ----------------
        '    If IzborSaobracaja = "3" Then
        '        Dim aString As String = ""
        '        Dim aString1 As String = ""
        '        Dim ii As Int16 = 0

        '        For ii = (Len(m_UicPrevozniPut) / 2) To 1 Step -1
        '            aString = aString & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2)
        '        Next

        '        For ii = 1 To (Len(m_UicPrevozniPut) / 2)
        '            aString1 = aString1 & " " & Microsoft.VisualBasic.Mid(aString, 2 * ii - 1, 2)
        '        Next

        '        m_UicPrevozniPut = aString1

        '    Else
        '        Dim aString1 As String = ""
        '        Dim ii As Int16 = 0

        '        For ii = 1 To (Len(m_UicPrevozniPut) / 2)
        '            aString1 = aString1 & " " & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2)
        '        Next

        '        m_UicPrevozniPut = aString1

        '    End If

        '    m_UicPrevozniPut = tmp_pp & " > " & m_UicPrevozniPut

        'Catch sqlex As SqlException
        '    Dim aa As String
        '    aa = sqlex.Message
        'End Try

        If DbVeza.State = ConnectionState.Open Then
            DbVeza.Close()
        End If

    End Sub
    'Public Sub DownloadWebTL(ByVal web_tl As String)
    '    Dim ii1 As Int32 = 0
    '    Dim web26dt As String

    '    dtKola.Clear()
    '    dtNhm.Clear()


    '    If DbVeza.State = ConnectionState.Closed Then
    '        DbVeza.Open()
    '    End If

    '    dsWeb2Zs.Clear()

    '    Try
    '        Dim adWeb2ZS As New SqlDataAdapter("SELECT euTL.CtrNum, euTL.Datum, euTL.R4, euTL.R5, euTL.R6, euTL.R10, euTL.R11, ZsStanice.SifraStanice, euTL.R12, euTL.R14, euTL.R15, euTL.R16, " _
    '                                   & "euTL.R17, euTL.SumaKola, euTL.R21_1, euTL.R22_1, euTL.R21_2, euTL.R22_2, euTL.R21_3, euTL.R22_3, euTL.R21_4, euTL.R22_4, euTL.R27, " _
    '                                   & "ZsStanice_1.SifraStanice AS us, euTL.R30, euTL.R34, euTL.RID, euTL.R37, euTL.R41, euTL.R44, euTL.R44n, euTL.R44i, euTL.R49, euTL.R50, " _
    '                                   & "euDL.IBK, euDL.Serija, euDL.Osovine, euDL.GrTov, euDL.Tara, euDL.Neto, euDL.NHM, euDL.UTI1ID, euDL.UTI1Neto, euDL.UTI1Tip, euDL.UTI2ID, " _
    '                                   & "euDL.UTI2Neto, euDL.UTI2Tip, euDL.BrPlombi, euTL.Preuzeto " _
    '                                   & "FROM euTL FULL JOIN " _
    '                                   & "euDL ON euTL.RecID = euDL.RecID INNER JOIN " _
    '                                   & "ZsStanice ON euTL.R12 = ZsStanice.Naziv INNER JOIN " _
    '                                   & "ZsStanice ZsStanice_1 ON euTL.R30 = ZsStanice_1.Naziv " _
    '                                   & "WHERE (euTL.CtrNum = '" & web_tl & "') AND (euTL.Preuzeto = '0')", DbVeza)

    '        ii1 = adWeb2ZS.Fill(dsWeb2Zs)

    '        For k As Int16 = 0 To dsWeb2Zs.Tables(0).Rows.Count - 1
    '            web02 = dsWeb2Zs.Tables(0).Rows(k).Item(2)
    '            web03 = dsWeb2Zs.Tables(0).Rows(k).Item(3)
    '            web04 = dsWeb2Zs.Tables(0).Rows(k).Item(4)
    '            web05 = dsWeb2Zs.Tables(0).Rows(k).Item(5)
    '            web06 = dsWeb2Zs.Tables(0).Rows(k).Item(6)
    '            web07 = dsWeb2Zs.Tables(0).Rows(k).Item(7) ' sifra st1
    '            web08 = dsWeb2Zs.Tables(0).Rows(k).Item(8)
    '            web09 = dsWeb2Zs.Tables(0).Rows(k).Item(9)
    '            web10 = dsWeb2Zs.Tables(0).Rows(k).Item(10)

    '            web11 = dsWeb2Zs.Tables(0).Rows(k).Item(11)
    '            web12 = dsWeb2Zs.Tables(0).Rows(k).Item(12)

    '            webSumaKola = dsWeb2Zs.Tables(0).Rows(k).Item(13)
    '            '''web14 = dsWeb2Zs.Tables(0).Rows(k).Item(14)

    '            web22 = dsWeb2Zs.Tables(0).Rows(k).Item(22)
    '            web23 = dsWeb2Zs.Tables(0).Rows(k).Item(23)
    '            web24 = dsWeb2Zs.Tables(0).Rows(k).Item(24)
    '            web25 = dsWeb2Zs.Tables(0).Rows(k).Item(25) 'R3 izjava
    '            web26 = dsWeb2Zs.Tables(0).Rows(k).Item(26)
    '            If web26 = "D" Then
    '                web26dt = "1"
    '            Else
    '                web26dt = "0"
    '            End If

    '            web28 = dsWeb2Zs.Tables(0).Rows(k).Item(28)
    '            web29 = dsWeb2Zs.Tables(0).Rows(k).Item(29)
    '            If web29 = "2" Then
    '                web30 = dsWeb2Zs.Tables(0).Rows(k).Item(30)

    '            End If


    '            web32 = dsWeb2Zs.Tables(0).Rows(k).Item(32)
    '            web33 = dsWeb2Zs.Tables(0).Rows(k).Item(33)
    '            web27 = dsWeb2Zs.Tables(0).Rows(k).Item(27)



    '            '------- Ako nema kola u dtKola...

    '            Dim drKola As DataRow = dtKola.NewRow
    '            Dim drRoba As DataRow = dtNhm.NewRow

    '            web_IBK = dsWeb2Zs.Tables(0).Rows(k).Item(34)

    '            drKola.ItemArray() = New Object() {web_IBK, "ZS", "Z", dsWeb2Zs.Tables(0).Rows(k).Item(35), "O", _
    '                                               dsWeb2Zs.Tables(0).Rows(k).Item(36), dsWeb2Zs.Tables(0).Rows(k).Item(38), 0, _
    '                                               "O", "1", 0, 0, "IC", "D", "I"}
    '            dtKola.Rows.Add(drKola)


    '            drRoba.ItemArray() = New Object() {web_IBK, dsWeb2Zs.Tables(0).Rows(k).Item(40), dsWeb2Zs.Tables(0).Rows(k).Item(39), _
    '                                               dsWeb2Zs.Tables(0).Rows(k).Item(39), "0", web26dt, dsWeb2Zs.Tables(0).Rows(k).Item(43), _
    '                                               dsWeb2Zs.Tables(0).Rows(k).Item(41), dsWeb2Zs.Tables(0).Rows(k).Item(42), 0, "", "", _
    '                                               dsWeb2Zs.Tables(0).Rows(k).Item(47), "I"}
    '            dtNhm.Rows.Add(drRoba)

    '            If Microsoft.VisualBasic.Left(dsWeb2Zs.Tables(0).Rows(k).Item(40), 4) = "9941" Or _
    '               Microsoft.VisualBasic.Left(dsWeb2Zs.Tables(0).Rows(k).Item(40), 4) = "9931" Then

    '                If dsWeb2Zs.Tables(0).Rows(k).Item(44) <> Nothing Then
    '                    Dim drRoba2 As DataRow = dtNhm.NewRow
    '                    drRoba2.ItemArray() = New Object() {web_IBK, dsWeb2Zs.Tables(0).Rows(k).Item(40), dsWeb2Zs.Tables(0).Rows(k).Item(39), _
    '                                                       dsWeb2Zs.Tables(0).Rows(k).Item(39), "0", web26dt, dsWeb2Zs.Tables(0).Rows(k).Item(46), _
    '                                                       dsWeb2Zs.Tables(0).Rows(k).Item(44), dsWeb2Zs.Tables(0).Rows(k).Item(45), 0, "", "", _
    '                                                       dsWeb2Zs.Tables(0).Rows(k).Item(47), "I"}
    '                    dtNhm.Rows.Add(drRoba2)

    '                End If

    '            End If

    '        Next

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try



    'End Sub
    'Public Sub DownloadCim(ByVal m_Cim As Int32)

    '    Dim ii1 As Int32 = 0
    '    Dim ii2 As Int32 = 0
    '    Dim xml_zeroStr As String = "0"
    '    Dim xml_zeroNum As Int32 = 0
    '    Dim xml_Srbija As String = "Ne"

    '    Dim eNODE_VALUE, eNODE_NAME, eATTR_NAME, eATTR_VALUE, eLoop_NODE_NAME, eLoop_ATTR_VALUE As String
    '    Dim eID_NODE As Int32
    '    Dim xml_RedniBrojKola As Int16 = 0

    '    ClearVar4Download()

    '    dtKola.Clear()
    '    dtNhm.Clear()
    '    dtNaknade.Clear()

    '    If eCimVeza.State = ConnectionState.Closed Then
    '        eCimVeza.Open()
    '    End If

    '    dsCimXml.Clear()

    '    xml_R57a2 = ""
    '    xml_R57b1a = ""
    '    xml_R57b2a = ""

    '    ''''''''''''dsSlogNHM.Clear() verovatno ne treba !!


    '    Try
    '        '-------------------------------------- popunjava Grid Kola ---------------------------------------------------

    '        '0 - ecim.XML_NODES.NODE_NAME           versandbhf
    '        '1 - ecim.XML_NODES.NODE_VALUE
    '        '2 - ecim.XML_NODES.ID_NODE             534
    '        '3 - ecim.NODE_ATTRIBUTES.ATTR_NAME
    '        '4 - ecim.NODE_ATTRIBUTES.ATTR_VALUE
    '        '5 - ecim.XML_NODES.ID_PARENT  

    '        Dim str_TempVar As String
    '        Dim adCimXml As New SqlDataAdapter("SELECT TOP 100 PERCENT ecim.XML_NODES.NODE_NAME, ecim.XML_NODES.NODE_VALUE, ecim.XML_NODES.ID_NODE, " _
    '                                         & "ecim.NODE_ATTRIBUTES.ATTR_NAME, ecim.NODE_ATTRIBUTES.ATTR_VALUE, ecim.XML_NODES.ID_PARENT " _
    '                                         & "FROM ecim.XML_NODES INNER JOIN " _
    '                                         & "ecim.XML_FILES ON ecim.XML_NODES.ID_FILE = ecim.XML_FILES.ID_FILE FULL OUTER JOIN " _
    '                                         & "ecim.NODE_ATTRIBUTES ON ecim.XML_NODES.ID_NODE = ecim.NODE_ATTRIBUTES.ID_NODE " _
    '                                         & "WHERE (ecim.XML_NODES.ID_FILE = " & m_Cim & ") AND (ecim.XML_FILES.IMPORTED = '0') " _
    '                                         & "ORDER BY ecim.XML_NODES.ID_NODE", eCimVeza)
    '        ii1 = adCimXml.Fill(dsCimXml)

    '        For k As Int16 = 0 To dsCimXml.Tables(0).Rows.Count - 1

    '            eNODE_NAME = dsCimXml.Tables(0).Rows(k).Item(0)         'pr. versandbhf 

    '            If eNODE_NAME <> "xml" And eNODE_NAME <> "frachtbriefe" And eNODE_NAME <> "frachtbrief" _
    '               And eNODE_NAME <> "sendungskopf" And eNODE_NAME <> "sendungsart" Then

    '                eNODE_VALUE = dsCimXml.Tables(0).Rows(k).Item(1)        'pr. ""

    '                If IsDBNull(dsCimXml.Tables(0).Rows(k).Item(3)) Then
    '                    eATTR_NAME = ""
    '                Else
    '                    eATTR_NAME = dsCimXml.Tables(0).Rows(k).Item(3)
    '                End If

    '                If eATTR_NAME = "value" Then
    '                    eATTR_VALUE = dsCimXml.Tables(0).Rows(k).Item(4)    'pr. absender (pošiljalac)
    '                Else
    '                    eATTR_VALUE = ""
    '                End If

    '                If eNODE_VALUE <> Nothing Then
    '                    If dsCimXml.Tables(0).Rows(k).Item(5) = eID_NODE Then
    '                        If eLoop_NODE_NAME = "versandbhf" Then 'R62. Otpravljanje - OK
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "vw"
    '                                    xml_ZemljaOtp = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "bhfnr"
    '                                    xml_StanicaOtp = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "bhfname"
    '                                    xml_NazivStaniceOtp = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "evu"
    '                                    xml_OperaterOtp = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "versandnr"
    '                                    xml_BrojCimOtp = dsCimXml.Tables(0).Rows(k).Item(1)
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "beteiligungsart" Then
    '                            If eLoop_ATTR_VALUE = "absender" Then 'R1. Pošiljalac - OK
    '                                Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                    Case "kundennr"
    '                                        xml_R2 = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    Case "name"
    '                                        xml_R1a = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    Case "strasse"
    '                                        xml_R1b = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    Case "plz"
    '                                        xml_R1c = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    Case "ort"
    '                                        If Len(xml_R1c) = 0 Then
    '                                            xml_R1c = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                        Else
    '                                            xml_R1c = xml_R1c & "-" & dsCimXml.Tables(0).Rows(k).Item(1)
    '                                        End If
    '                                    Case "tel"
    '                                        xml_R1d = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                End Select
    '                            ElseIf eLoop_ATTR_VALUE = "empfaenger" Then 'R4. Primalac - OK
    '                                Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                    Case "kundennr"
    '                                        xml_R5 = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    Case "name"
    '                                        xml_R4a = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    Case "strasse"
    '                                        xml_R4b = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    Case "plz"
    '                                        xml_R4c = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    Case "ort"
    '                                        If Len(xml_R4c) = 0 Then
    '                                            xml_R4c = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                        Else
    '                                            xml_R4c = xml_R4c & "-" & dsCimXml.Tables(0).Rows(k).Item(1)
    '                                        End If
    '                                    Case "tel"
    '                                End Select
    '                            End If
    '                        ElseIf eLoop_NODE_NAME = "ablieferungsstelle" Then 'R10. & R11. Mesto izdavanja - OK
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "bhfnr"
    '                                    xml_R10a = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "bhfname"
    '                                    xml_R10b = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "ablieferungsort_name"
    '                                    xml_R10c = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "ablieferungsort_code"
    '                                    xml_R10d = dsCimXml.Tables(0).Rows(k).Item(1)
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "empfangsbhf" Then 'R12. Stanica u mestu izdavanja - OK
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "vw"
    '                                    xml_R12 = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    xml_ZemljaPr = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    If xml_ZemljaPr = "72" Then
    '                                        IzborSaobracaja = "2"
    '                                    Else
    '                                        IzborSaobracaja = "4"
    '                                    End If
    '                                    If xml_ZemljaPr = "72" Or xml_ZemljaPr = "73" Or xml_ZemljaPr = "62" Or _
    '                                       xml_ZemljaPr = "63" Or xml_ZemljaPr = "44" Or xml_ZemljaPr = "50" Or _
    '                                       xml_ZemljaPr = "75" Then

    '                                        xml_ZemljaPr = "00" & xml_ZemljaPr
    '                                    ElseIf xml_ZemljaPr = "52" Or xml_ZemljaPr = "53" Then
    '                                        xml_ZemljaPr = "21" & xml_ZemljaPr
    '                                    Else
    '                                        xml_ZemljaPr = "00" & xml_ZemljaPr
    '                                    End If
    '                                Case "bhfnr"
    '                                    xml_R12 = xml_R12 & " " & dsCimXml.Tables(0).Rows(k).Item(1) & " "
    '                                    xml_StanicaPr = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "bhfname"
    '                                    xml_R12 = xml_R12 & " " & dsCimXml.Tables(0).Rows(k).Item(1)
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "uebernahmestelle" Then 'R16. Preuzimanje na prevoz - OK
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "vw"
    '                                    xml_R16a = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "bhfnr"
    '                                    xml_R16a = xml_R16a & dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "bhfname"
    '                                    xml_R16b = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "uebernahmezeitpunkt" '23.03.2009 00
    '                                    xml_R16c = Microsoft.VisualBasic.Left(dsCimXml.Tables(0).Rows(k).Item(1), 2)
    '                                    xml_R16d = Microsoft.VisualBasic.Mid(dsCimXml.Tables(0).Rows(k).Item(1), 4, 2)
    '                                    xml_R16god = Microsoft.VisualBasic.Mid(dsCimXml.Tables(0).Rows(k).Item(1), 7, 4)
    '                                    xml_R16e = Microsoft.VisualBasic.Right(dsCimXml.Tables(0).Rows(k).Item(1), 2)
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "grenzpunkt" Then 'R20. Izjava o plaæanju gr.prelaz - OK 
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "code"
    '                                    xml_R20c = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "code_bezeichnung"
    '                                    xml_R20d = dsCimXml.Tables(0).Rows(k).Item(1)
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "nebengebuehr" Then 'R20. Izjava o plaæanju naknade!!!!
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "nbgcode"
    '                                    If Len(dsCimXml.Tables(0).Rows(k).Item(1)) < 2 Then
    '                                        xml_R20f = xml_R20f & "0" & dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    Else
    '                                        xml_R20f = xml_R20f & dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    End If
    '                            End Select

    '                        ElseIf eLoop_NODE_NAME = "leitungsweg" Then 'R50. Prevozni put - OK
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "leitungsweg_code"
    '                                    xml_R50 = xml_R50 & "  " & dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    If Microsoft.VisualBasic.Left(dsCimXml.Tables(0).Rows(k).Item(1), 2) = "72" Then
    '                                        xml_R57_izlaz = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    End If
    '                                Case "leitungsweg_bezeichnung"
    '                                    xml_R50 = xml_R50 & " " & dsCimXml.Tables(0).Rows(k).Item(1) & " "
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "andere_befoerderer" Then 'R57 Ostali prevoznici ...
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "an_bef_evu" '4
    '                                    xml_R57a1 = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "an_bef_name" '35
    '                                    str_TempVar = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    If Len(str_TempVar) < 35 Then
    '                                        str_TempVar = str_TempVar.PadRight(35, " "c)
    '                                    End If

    '                                    xml_R57a2 = xml_R57a2 & " " & xml_R57a1 & "-" & str_TempVar
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "str_v_bahnhof" Then 'R57 Ostali prevoznici od (prelaz 6)
    '                            tmp_prelaz = 6
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "str_v_bhfnr"
    '                                    xml_R57b1 = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "str_v_bhfname"
    '                                    str_TempVar = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    If Len(str_TempVar) < 40 Then
    '                                        str_TempVar = str_TempVar.PadRight(40, " "c)
    '                                    End If
    '                                    xml_R57b1a = xml_R57b1a & " " & xml_R57b1 & "-" & str_TempVar
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "str_v_grenzpunkt" Then 'R57 Ostali prevoznici od (prelaz 3)
    '                            tmp_prelaz = 3
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "str_v_code"
    '                                    xml_R57b1 = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    xml_R57b1 = xml_R57b1.PadLeft(6, " "c)
    '                                Case "str_v_bezeichnung"
    '                                    str_TempVar = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    If Len(str_TempVar) < 40 Then
    '                                        str_TempVar = str_TempVar.PadRight(40, " "c)
    '                                    End If
    '                                    xml_R57b1a = xml_R57b1a & " " & xml_R57b1 & "-" & str_TempVar
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "str_b_bahnhof" Then 'R57 Ostali prevoznici od 
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "str_b_bhfnr"
    '                                    xml_R57b2 = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                Case "str_b_bhfname"
    '                                    str_TempVar = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    If Len(str_TempVar) < 40 Then
    '                                        str_TempVar = str_TempVar.PadRight(40, " "c)
    '                                    End If
    '                                    xml_R57b2a = xml_R57b2a & " " & xml_R57b2 & "-" & str_TempVar
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "str_b_grenzpunkt" Then 'R57 Ostali prevoznici od 
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "str_b_code"
    '                                    xml_R57b2 = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    xml_R57b2 = xml_R57b2.PadLeft(6, " "c)

    '                                    If xml_R57a1 = "0072" Then
    '                                        xml_R57_izlaz = "72" & Microsoft.VisualBasic.Right(dsCimXml.Tables(0).Rows(k).Item(1), 2)
    '                                    End If
    '                                Case "str_b_bezeichnung"
    '                                    str_TempVar = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    If Len(str_TempVar) < 40 Then
    '                                        str_TempVar = str_TempVar.PadRight(40, " "c)
    '                                    End If
    '                                    xml_R57b2a = xml_R57b2a & " " & xml_R57b2 & "-" & str_TempVar
    '                            End Select

    '                        ElseIf eLoop_NODE_NAME = "wagen" Then 'R18. Kola - OK 
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "wg_nr"
    '                                    Dim drKola As DataRow = dtKola.NewRow

    '                                    xml_RedniBrojKola = xml_RedniBrojKola + 1

    '                                    xml_IBK = dsCimXml.Tables(0).Rows(k).Item(1)

    '                                    drKola.ItemArray() = New Object() {xml_IBK, "2", "3", "4", "5", 6, 7, 8, xml_zeroStr, "10", xml_zeroNum, xml_zeroNum, xml_zeroStr, "14", "I"}
    '                                    dtKola.Rows.Add(drKola)
    '                                Case "wg_eigengewicht_kg" 'tara
    '                                    xml_tara = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    dtKola.Rows(xml_RedniBrojKola - 1).Item(6) = xml_tara
    '                                Case "wg_anz_achsen" ' osovine
    '                                    xml_osovine = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    dtKola.Rows(xml_RedniBrojKola - 1).Item(5) = xml_osovine
    '                                Case "lastgrenze" ' granica tovarenja
    '                                    xml_GrTov = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    dtKola.Rows(xml_RedniBrojKola - 1).Item(7) = xml_GrTov
    '                            End Select
    '                        ElseIf eLoop_NODE_NAME = "ladegut" Then 'R24. R25. NHM / Masa - OK 
    '                            Select Case dsCimXml.Tables(0).Rows(k).Item(0)
    '                                Case "nhm"
    '                                    Dim drRoba As DataRow = dtNhm.NewRow
    '                                    Dim currRow As DataRow

    '                                    xml_Nhm = dsCimXml.Tables(0).Rows(k).Item(1)

    '                                    currRow = dtKola.Rows(xml_RedniBrojKola - 1)
    '                                    xml_IBK = currRow(0, DataRowVersion.Current).ToString()

    '                                    drRoba.ItemArray() = New Object() {xml_IBK, xml_Nhm, 3, 4, "5", "6", xml_zeroStr, xml_zeroStr, xml_zeroNum, xml_zeroNum, xml_zeroStr, xml_zeroStr, xml_zeroStr, "I"}
    '                                    dtNhm.Rows.Add(drRoba)

    '                                Case "bruttogewicht_kg" 'neto
    '                                    xml_netoDec = dsCimXml.Tables(0).Rows(k).Item(1)
    '                                    xml_netoInt = (Int(xml_netoDec + 0.99) * 10) / 10

    '                                    dtNhm.Rows(xml_RedniBrojKola - 1).Item(2) = xml_netoDec
    '                                    dtNhm.Rows(xml_RedniBrojKola - 1).Item(3) = xml_netoInt

    '                            End Select
    '                        End If
    '                    End If
    '                ElseIf eNODE_VALUE = Nothing And eATTR_NAME <> "value" Then
    '                    eID_NODE = dsCimXml.Tables(0).Rows(k).Item(2)
    '                    eLoop_NODE_NAME = dsCimXml.Tables(0).Rows(k).Item(0)
    '                ElseIf eNODE_VALUE = Nothing And eATTR_NAME = "value" Then
    '                    eID_NODE = eID_NODE
    '                    eLoop_NODE_NAME = dsCimXml.Tables(0).Rows(k).Item(0)
    '                    eLoop_ATTR_VALUE = dsCimXml.Tables(0).Rows(k).Item(4)

    '                    ' ----------------  R20. izjava o placanju  ------------------
    '                    If eLoop_NODE_NAME = "frankaturcode_id" Then 'R20. Izjava o plaæanju Franko prevoznina - jos naknade i gr.prelaz!!!!
    '                        xml_R20a = dsCimXml.Tables(0).Rows(k).Item(4)
    '                    ElseIf eLoop_NODE_NAME = "incoterm" Then 'R20. Izjava o plaæanju Incoterm - OK
    '                        xml_R20b = dsCimXml.Tables(0).Rows(k).Item(4)
    '                    End If

    '                End If

    '                ' ----------------  R29. Mesto i datum ispostavljanja  ------------------
    '                If eNODE_NAME = "ausstellungsort" Then
    '                    xml_R29a = dsCimXml.Tables(0).Rows(k).Item(1)
    '                ElseIf eNODE_NAME = "ausstellungsdatum" Then
    '                    xml_R29b = dsCimXml.Tables(0).Rows(k).Item(1)
    '                End If

    '            End If

    '        Next



    '    Catch ex As Exception
    '        MsgBox(ex)
    '    End Try

    'End Sub

    Public Sub NadjiTovarniListTrz4Del(ByVal inTipStanice As String, ByVal inStanica As String, ByVal inNalepnica As Int32, ByVal inObrGodina As String, _
                                       ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                                       ByRef bRetVal As String)

        bRetVal = ""
        bRecID = 0
        bStanicaRecID = "0"

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.wrNadjiTLTrz4Del", DbVeza)
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

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        izRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim izStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        izStanicaRecID.Direction = ParameterDirection.Output
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

            '------------------------ inicijalizovanje izlaznih promenljivih ------------------------------
            If bRecID = 0 And bStanicaRecID = "Nista" Then
                bRetVal = "Ne postoji takav podatak!"
            End If
            '----------------------------------------------------------------------------------------------------------
        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub eNadjiTovarniListTrz(ByVal inTipStanice As String, ByVal inStanica As String, ByVal inNalepnica As Int32, ByVal inObrGodina As String, _
                                    ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                                    ByRef exObrMesec As String, ByRef exOtpUprava As String, ByRef exOtpStanica As String, ByRef exOtpBroj As Int32, ByRef exOtpDatum As Date, _
                                    ByRef exPrUprava As String, ByRef exPrStanica As String, _
                                    ByRef bZsIzPrelaz As String, ByRef bZsIzNalepnica As Int32, _
                                    ByRef bBrojVoza As Int32, ByRef bSatVoza As String, _
                                    ByRef bBrojVoza2 As Int32, ByRef bSatVoza2 As String, _
                                    ByRef DatumUl As Date, ByRef DatumIzl As Date, _
                                    ByRef bSifraTarife As String, ByRef bUgovor As String, _
                                    ByRef bCarinaUlaz As String, ByRef bCarinaIzlaz As String, _
                                    ByRef bRetVal As String)

        'ne treba
        'ByRef exPrDatum As Date, ByRef bSaobracaj As String, _
        'ByRef bNajava As String, ByRef bNajava2 As String, _
        'ByRef bSumaIznos As Decimal, ByRef bPrevoznina As Decimal, ByRef bNaknade As Decimal, _

        bRetVal = ""
        bRecID = 0
        bStanicaRecID = "0"

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.eNadjiTLTrz1", DbVeza)
        'Dim spKomanda As New SqlClient.SqlCommand("dbo.wrNadjiTLTrz", DbVeza)
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

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        izRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim izStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        izStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim izObrMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outObrMesec", SqlDbType.Char, 2))
        izObrMesec.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outObrMesec").Value = exObrMesec

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

        Dim exZsIzPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outZsPrelaz", SqlDbType.Char, 5))
        exZsIzPrelaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outZsPrelaz").Value = bZsIzPrelaz

        Dim izNalepnica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNalepnica", SqlDbType.Int))
        izNalepnica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNalepnica").Value = bZsIzNalepnica

        Dim izBrojVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrojVoza", SqlDbType.Int))
        izBrojVoza.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBrojVoza").Value = bBrojVoza

        Dim izSatVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSatVoza", SqlDbType.Char, 5))
        izSatVoza.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSatVoza").Value = bSatVoza

        Dim izBrojVoza2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrojVoza2", SqlDbType.Int))
        izBrojVoza2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBrojVoza2").Value = bBrojVoza2

        Dim izSatVoza2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSatVoza2", SqlDbType.Char, 5))
        izSatVoza2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSatVoza2").Value = bSatVoza2

        Dim izDatumUl As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outDatumUl", SqlDbType.DateTime))
        izDatumUl.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outDatumUl").Value = DatumUl

        Dim izDatumIz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outDatumIzl", SqlDbType.DateTime))
        izDatumIz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outDatumIzl").Value = DatumIzl

        Dim izSifraTarife As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife", SqlDbType.Char, 2))
        izSifraTarife.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife").Value = bSifraTarife

        Dim izUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        izUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor

        Dim izCarinaUlaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outCarinaUlaz", SqlDbType.Char, 5))
        izCarinaUlaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outCarinaUlaz").Value = bCarinaUlaz

        Dim izCarinaIzlaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outCarinaIzlaz", SqlDbType.Char, 5))
        izCarinaIzlaz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outCarinaIzlaz").Value = bCarinaIzlaz


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
                exObrMesec = spKomanda.Parameters("@outObrMesec").Value
                exOtpUprava = spKomanda.Parameters("@outOtpUprava").Value
                exOtpStanica = spKomanda.Parameters("@outOtpStanica").Value
                exOtpBroj = spKomanda.Parameters("@outOtpBroj").Value
                exOtpDatum = spKomanda.Parameters("@outOtpDatum").Value

                mObrMesec = exObrMesec
                mOtpUprava = exOtpUprava
                mOtpStanica = exOtpStanica
                mOtpBroj = exOtpBroj
                mOtpDatum = exOtpDatum

                mPrUprava = spKomanda.Parameters("@outPrUprava").Value
                mPrStanica = spKomanda.Parameters("@outPrStanica").Value

                bZsIzPrelaz = spKomanda.Parameters("@outZsPrelaz").Value
                bZsIzNalepnica = spKomanda.Parameters("@outNalepnica").Value

                msBrojVoza = spKomanda.Parameters("@outBrojVoza").Value
                mSatVoza = spKomanda.Parameters("@outSatVoza").Value

                If IsDBNull(spKomanda.Parameters("@outBrojVoza2").Value) Then
                    msBrojVoza2 = 0
                Else
                    msBrojVoza2 = spKomanda.Parameters("@outBrojVoza2").Value
                End If

                If IsDBNull(spKomanda.Parameters("@outSatVoza2").Value) Then
                    mSatVoza2 = ""
                Else
                    mSatVoza2 = spKomanda.Parameters("@outSatVoza2").Value
                End If

                mDatumUlaza = spKomanda.Parameters("@outDatumUl").Value
                mDatumIzlaza = spKomanda.Parameters("@outDatumIzl").Value
                mTarifa = spKomanda.Parameters("@outSifraTarife").Value

                mBrojUg = spKomanda.Parameters("@outUgovor").Value
                mCarStanica = spKomanda.Parameters("@outCarinaUlaz").Value

                If IsDBNull(spKomanda.Parameters("@outCarinaIzlaz").Value) Then
                    mCarStanica2 = ""
                Else
                    mCarStanica2 = spKomanda.Parameters("@outCarinaIzlaz").Value
                End If

                '------------------------------- popunjava 3 grida --------------------------------------------
                IzmenaTL()

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
    Public Sub UpdTrzNalepnica(ByVal ipTrans As SqlTransaction, ByVal inGodina As String, ByVal inTip As String, _
                               ByVal inPrelaz As String, ByVal inBrojStari As Int32, ByVal inBroj As Int32, _
                               ByRef bRetVal As String)

        bRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.UpdTrzNalepnice", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        Dim ulGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4))
        ulGodina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inGodina").Value = inGodina

        Dim ulTip As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTip", SqlDbType.Char, 1))
        ulTip.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTip").Value = inTip

        Dim ulPrelaz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrelaz", SqlDbType.Char, 5))
        ulPrelaz.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrelaz").Value = inPrelaz

        Dim upBrojStari As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojStari", SqlDbType.Int))
        upBrojStari.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojStari").Value = inBrojStari

        Dim upBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBroj", SqlDbType.Int))
        upBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBroj").Value = inBroj

        spKomanda.Transaction = ipTrans

        Try

            spKomanda.ExecuteNonQuery()
            If spKomanda.Parameters("@RETURN_VALUE").Value = 0 Then bRetVal = "Ništa nije upisano u bazu!"
        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub eNadjiTovarniListUI(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                                   ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef bBrojVoza As Int32, ByRef bSatVoza As String, _
                                   ByRef bSifraTarife As String, ByRef bUgovor As String, _
                                   ByRef bRetVal As String)

        bRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("dbo.eNadjiTLUI", DbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("dbo.eNadjiUTL", DbVeza)
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

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpDatum").Value = bDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim izBrojVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrojVoza", SqlDbType.Int))
        izBrojVoza.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outBrojVoza").Value = bBrojVoza

        Dim izSatVoza As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSatVoza", SqlDbType.Char, 5))
        izSatVoza.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSatVoza").Value = bSatVoza

        Dim exSifraTarife As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife", SqlDbType.Char, 2))
        exSifraTarife.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife").Value = bSifraTarife

        Dim exUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        exUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            bRecID = spKomanda.Parameters("@outRecID").Value
            UpdRecID = bRecID
            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdStanicaRecID = bStanicaRecID

            If bRecID = 0 And bStanicaRecID = "Nista" Then
                bRetVal = "Ne postoji takav podatak!"
            Else
                If IsDBNull(spKomanda.Parameters("@outBrojVoza").Value) Then
                    msBrojVoza = 0
                Else
                    msBrojVoza = spKomanda.Parameters("@outBrojVoza").Value
                End If

                If IsDBNull(spKomanda.Parameters("@outSatVoza").Value) Then
                    mSatVoza = 0
                Else
                    mSatVoza = spKomanda.Parameters("@outSatVoza").Value
                End If

                mTarifa = spKomanda.Parameters("@outSifraTarife").Value
                bSifraTarife = mTarifa
                mBrojUg = spKomanda.Parameters("@outUgovor").Value
                bUgovor = mBrojUg

                'popunjava 5 gridova
                IzmenaTLUI()


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
    Public Sub eNadjiTovarniListUTLWR(ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, ByVal bOtpDatum As Date, _
                                   ByRef bRecID As Int32, ByRef bStanicaRecID As String, ByRef bPrStanica As Int32, ByRef bPrBroj As String, ByRef bPrDatum As Date, _
                                   ByRef bSifraTarife As String, ByRef bSifraTarife72 As String, ByRef bUgovor As String, ByRef bPrevoz As String, _
                                   ByRef bRetVal As String)

        bRetVal = ""

        'If OkpDbVeza.State = ConnectionState.Closed Then
        '    OkpDbVeza.Open()
        'End If

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.eNadjiUTLWR", DbVeza)
        'Dim spKomanda As New SqlClient.SqlCommand("dbo.eNadjiUTLOKP", OkpDbVeza)
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

        Dim ulOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime))
        ulOtpDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpDatum").Value = bOtpDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = bRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID

        Dim izStanicaPr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        izStanicaPr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = bPrStanica

        Dim izBrojPr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrBroj", SqlDbType.Int))
        izBrojPr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrBroj").Value = bPrBroj

        Dim outPrDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrDatum", SqlDbType.DateTime))
        outPrDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrDatum").Value = bPrDatum

        Dim exSifraTarife As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife", SqlDbType.Char, 2))
        exSifraTarife.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife").Value = bSifraTarife

        Dim exSifraTarife72 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraTarife72", SqlDbType.Char, 2))
        exSifraTarife72.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraTarife").Value = bSifraTarife72


        Dim exUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUgovor", SqlDbType.Char, 6))
        exUgovor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUgovor").Value = bUgovor

        Dim izPrevoz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevoz", SqlDbType.Char, 1))
        izPrevoz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrevoz").Value = bPrevoz

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = bRetVal

        Try
            spKomanda.ExecuteScalar()

            bRecID = spKomanda.Parameters("@outRecID").Value
            UpdRecID = bRecID
            bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            UpdStanicaRecID = bStanicaRecID

            If bRecID = 0 And bStanicaRecID = "Nista" Then
                bRetVal = "Ne postoji takav podatak!"
            Else
                ''If IsDBNull(spKomanda.Parameters("@outBrojVoza").Value) Then
                ''    msBrojVoza = 0
                ''Else
                ''    msBrojVoza = spKomanda.Parameters("@outBrojVoza").Value
                ''End If
                ''   b
                ''If IsDBNull(spKomanda.Parameters("@outSatVoza").Value) Then
                ''    mSatVoza = 0
                ''Else
                ''    mSatVoza = spKomanda.Parameters("@outSatVoza").Value
                ''End If



                bPrStanica = spKomanda.Parameters("@outPrStanica").Value
                bPrBroj = spKomanda.Parameters("@outPrBroj").Value
                bPrDatum = spKomanda.Parameters("@outPrDatum").Value
                mTarifa = spKomanda.Parameters("@outSifraTarife").Value
                bSifraTarife = mTarifa
                bSifraTarife72 = spKomanda.Parameters("@outSifraTarife72").Value
                mBrojUg = spKomanda.Parameters("@outUgovor").Value
                bUgovor = mBrojUg
                bPrevoz = spKomanda.Parameters("@outPrevoz").Value

                'popunjava 5 gridova
                'IzmenaTLUI()
                'IzmenaTLWR()
                IzmenaTLWR1()
            End If

        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            'OkpDbVeza.Close()
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub ClearVar4Download()

        xml_ZemljaOtp = ""
        xml_StanicaOtp = ""
        xml_NazivStaniceOtp = ""
        xml_OperaterOtp = ""
        xml_ZemljaPr = ""
        xml_StanicaPr = ""
        xml_NazivStanicePr = ""
        xml_BrojCimOtp = 0
        xml_tara = 0
        xml_netoInt = 0
        xml_osovine = 0
        xml_GrTov = 0
        xml_netoDec = 0
        xml_R16a = ""
        xml_R16b = ""
        xml_R16c = ""
        xml_R16d = ""
        xml_R16e = ""
        xml_R10a = ""
        xml_R50 = ""
        xml_R57a = ""
        xml_R57b = ""
        xml_R2 = ""
        xml_R1a = ""
        xml_R1b = ""
        xml_R1c = ""
        xml_R1d = ""
        xml_R5 = ""
        xml_R4a = ""
        xml_R4b = ""
        xml_R4c = ""
        xml_R4d = ""
        xml_IBK = ""
        xml_Nhm = ""
        xml_R57_ulaz = ""
        xml_R57_izlaz = ""

    End Sub
    Public Sub Kola_eValidating()
        Dim KolaRed As DataRow

        'If DbVeza.State = ConnectionState.Closed Then
        '    DbVeza.Open()
        'End If

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
    Public Sub eUskladiTipKola()
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
                    If Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "8606" Then
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
    Public Sub eUskladiNhm()

        Dim NHMRed As DataRow

        For Each NHMRed In dtNhm.Rows

            Dim rv As String = ""

            '1.7.2008. zbor tarifskog razreda u TEA tarifi
            Dim tempTarifa92 As String = "00"
            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" And mVrstaObracuna = "CO" Then
                tempTarifa92 = "68"
            Else
                tempTarifa92 = mTarifa
            End If

            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            Dim uspKomanda As New SqlClient.SqlCommand("NadjiNhm", DbVeza)
            uspKomanda.CommandType = CommandType.StoredProcedure

            Dim upSifraRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upSifraRobe", SqlDbType.Char, 6))
            upSifraRobe.Direction = ParameterDirection.Input
            uspKomanda.Parameters("@upSifraRobe").Value = NHMRed.Item("NHM")

            Dim upTarifa As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upTarifa", SqlDbType.Char, 2))
            upTarifa.Direction = ParameterDirection.Input
            uspKomanda.Parameters("@upTarifa").Value = tempTarifa92 'mTarifa

            Dim ipNazivRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipNazivRobe", SqlDbType.Char, 100))
            ipNazivRobe.Direction = ParameterDirection.Output

            Dim ipRazredRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRobe", SqlDbType.Char, 1))
            ipRazredRobe.Direction = ParameterDirection.Output

            Dim ipRazredRid As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRid", SqlDbType.Int, 2))
            ipRazredRid.Direction = ParameterDirection.Output

            Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipPovratnaVrednost", SqlDbType.NVarChar, 100))
            ipPovratnaVrednost.Direction = ParameterDirection.Output

            Try
                uspKomanda.ExecuteScalar()
                If uspKomanda.Parameters("@ipPovratnaVrednost").Value = "" Then 'OK

                    NHMRed.Item("R") = uspKomanda.Parameters("@ipRazredRobe").Value
                    NHMRed.Item("RID") = uspKomanda.Parameters("@ipRazredRid").Value

                Else 'nije ok
                End If

            Catch SQLExp As SqlException
                'rv = SQLExp.Message & " ?"  'Greska - SQL greska
                'StatusBar1.Text = rv
                'tbNHM.Focus()

            Catch Exp As Exception
                'rv = Err.Description & "??" 'Greska - bilo koja
                'StatusBar1.Text = rv
                'tbNHM.Focus()
            Finally
                DbVeza.Close()
                uspKomanda.Dispose()
            End Try
        Next
    End Sub
    Public Sub NadjiKurs(ByVal inValuta As String, ByVal inVrsta As String, ByVal inDatum As Date, _
                         ByRef outKurs As Decimal, ByRef outRetVal As String)

        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        'veza je pri unosu naknada otvorena

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

        If mVrstaObracuna = "CO" Then
            outKurs = 1
        End If


        If mBrojUg = "078700" Or mBrojUg = "078701" Or mBrojUg = "078702" Or mBrojUg = "078711" Then
            'outKurs = 120.1223         ' HCD   kurs od 16.07.2017.
            'outKurs = 120.183          ' HCD   kurs od 01.08.2017.
            outKurs = 119.4067          ' HCD   kurs od 16.08.2017.
        End If

    End Sub

    Public Sub sNadjiKorisnika(ByVal ulSifraKorisnika As String, _
                         ByRef izlNaziv As String, ByRef izlMesto As String, ByRef izlZemlja As String, ByRef izlAdresa As String, _
                         ByRef izlPovVrednost As String)

        izlNaziv = ""
        izlMesto = ""
        izlZemlja = ""
        izlAdresa = ""
        izlPovVrednost = "Ne postoji takav podatak!"

        Dim closeConn As Boolean = True

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim sqltext As String = "Select Naziv,Mesto,Zemlja,Adresa FROM Komitent " & _
                                "WHERE (Sifra = '" & ulSifraKorisnika & "')"

        Dim sql_comm1 As New SqlClient.SqlCommand(sqltext, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        Try
            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrRm.Read()
                izlNaziv = rdrRm.GetString(0)
                izlMesto = rdrRm.GetString(1)
                izlZemlja = rdrRm.GetString(2)
                izlAdresa = rdrRm.GetString(3)
                izlPovVrednost = ""
            Loop
            rdrRm.Close()

        Catch ex As Exception
            MsgBox(ex.ToString())

        End Try

        If ulSifraKorisnika = "0" Or ulSifraKorisnika = "" Then
            izlNaziv = ""
            izlMesto = ""
            izlZemlja = ""
            izlAdresa = ""
            izlPovVrednost = ""
        End If

    End Sub
    Public Sub UskladiNaknadePoKolima()

        If mVrstaObracuna = "IC" Then
            Dim KolaRed As DataRow
            For Each KolaRed In dtKola.Rows
                KolaRed.Item("Naknada") = 0
                If KolaRed.Item("Vlasnik") = "Z" Then
                    If mBrojUg = "835745" Then          'Adriacombi
                        KolaRed.Item("Naknada") = 40
                    ElseIf mBrojUg = "835753" Then      'Adriacombi
                        KolaRed.Item("Naknada") = 36
                    ElseIf mBrojUg = "931817" Then      'Eurolog
                        If KolaRed.Item("Osovine") = 4 Then
                            KolaRed.Item("Naknada") = 26
                        ElseIf KolaRed.Item("Osovine") = 6 Then
                            KolaRed.Item("Naknada") = 52
                        Else
                            KolaRed.Item("Naknada") = 52 'nedefinisano 2011
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
                    ''----- naknada za P kola
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

                        'Proodos 
                        If mBrojUg = "101001" Or mBrojUg = "101096" Or _
                           mBrojUg = "101101" Or mBrojUg = "101196" Then
                            KolaRed.Item("Naknada") = -60
                        End If


                    End If

                    '----- naknada za zeleznicka kola
                    If KolaRed.Item("Vlasnik") = "Z" Then

                        If Microsoft.VisualBasic.Right(mBrojUg, 4) = "1133" And Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) <> "81" Then
                            KolaRed.Item("Naknada") = 36 'CO 061133, Tg.774 + i svi ostali-Mandiæ 27.6.2011
                        End If

                        'If mBrojUg = "061133" And Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) <> "81" Then
                        '    KolaRed.Item("Naknada") = 36 'CO 061133, Tg.774
                        'End If

                        If (mBrojUg = "101133" Or mBrojUg = "111133" Or mBrojUg = "121133") And Microsoft.VisualBasic.Mid(KolaRed.Item("IndBrojKola"), 3, 2) <> "81" Then  'Proodos kont.voz
                            If mStanica1 = "11028" Or mStanica2 = "11028" Then
                                KolaRed.Item("Naknada") = 36
                            End If
                            If mStanica1 = "12498" Or mStanica2 = "12498" Then
                                KolaRed.Item("Naknada") = 39
                            End If
                        End If

                    End If
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

            'Dim ug_mNazivKomitenta As String
            'Dim ug_mPrimalac As String
            'Dim ug_mVrstaObracuna As String
            'Dim mizlaz As String

            'If Microsoft.VisualBasic.Trim(bUgovor) <> "" Then
            '    NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, mVrstaObracuna, mizlaz)
            'End If


            Dim mRetVal As String
            Dim ug_mNazivKomitenta As String
            Dim ug_mAdresaKomitenta As String
            Dim ug_mGradKomitenta As String
            Dim ug_mZemljaKomitenta As String
            Dim ug_mPrimalac As String
            Dim ug_mVrstaObracuna As String



            If Microsoft.VisualBasic.Trim(bUgovor) <> "" Then
                NadjiUgovor(bUgovor, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, ug_mAdresaKomitenta, ug_mGradKomitenta, ug_mZemljaKomitenta, mRetVal)
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
                                       & " dbo.SlogRoba.UtiTip, dbo.SlogKola.ICF, dbo.SlogRoba.VozStav  " _
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
                            Else
                                mNaknadaZaZelKola = 0
                            End If
                        Else
                            mNaknadaZaZelKola = 0
                        End If

                    Else ' Naknada za zeleznicka kola

                        If mBrojUg = "835745" Then      'Adriacombi
                            mNaknadaZaZelKola = 40
                        ElseIf mBrojUg = "835753" Then  'Adriacombi
                            mNaknadaZaZelKola = 36
                        ElseIf mBrojUg = "931817" Then  'Eurolog
                            If dsSlogKola.Tables(0).Rows(k).Item(6) = 4 Then
                                mNaknadaZaZelKola = 26
                            ElseIf dsSlogKola.Tables(0).Rows(k).Item(6) = 6 Then
                                mNaknadaZaZelKola = 52
                            Else
                                mNaknadaZaZelKola = 52 'nedefinisano ugovorom 2011.
                            End If

                        ElseIf (mBrojUg = "100822" Or mBrojUg = "110822" Or mBrojUg = "120822") Then  'Proodos kont.voz
                            If mStanica1 = "11028" Or mStanica2 = "11028" Then
                                mNaknadaZaZelKola = 36
                            End If
                            If mStanica1 = "12498" Or mStanica2 = "12498" Then
                                mNaknadaZaZelKola = 39
                            End If
                        ElseIf (mBrojUg = "101133" Or mBrojUg = "111122" Or mBrojUg = "121122") Then  'Proodos kont.voz
                            If mStanica1 = "11028" Or mStanica2 = "11028" Then
                                mNaknadaZaZelKola = 36
                            End If
                            If mStanica1 = "12498" Or mStanica2 = "12498" Then
                                mNaknadaZaZelKola = 39
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
                                                  dsSlogKola.Tables(0).Rows(jj).Item(15), _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(18), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                                                  "", dsSlogKola.Tables(0).Rows(jj).Item(14), 0, 0, "", "", "", "U", _
                                                  dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20)}


                ''drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(1), dsSlogKola.Tables(0).Rows(jj).Item(13), dsSlogKola.Tables(0).Rows(jj).Item(15), _
                ''                                                 dsSlogKola.Tables(0).Rows(jj).Item(14), dsSlogKola.Tables(0).Rows(jj).Item(17), _
                ''                                                 dsSlogKola.Tables(0).Rows(jj).Item(18), "", 0, 0, "", "", "", "I", _
                ''                                                 dsSlogKola.Tables(0).Rows(jj).Item(16), dsSlogKola.Tables(0).Rows(jj).Item(20)}

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
        Catch sqlex As SqlException

            'Dim aa As String
            'aa = sqlex.Message

        End Try

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

            If IsDBNull(spKomanda.Parameters("@outStanica1").Value) Then
                mManipulativnoMesto1 = ""
            Else
                mManipulativnoMesto1 = spKomanda.Parameters("@outStanica1").Value
                MM_Count = 0
            End If


            If IsDBNull(spKomanda.Parameters("@outStanica2").Value) Then
                mManipulativnoMesto2 = ""
            Else
                mManipulativnoMesto2 = spKomanda.Parameters("@outStanica2").Value
                MM_Count = 0
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
    'Public Sub bInitZaUnutrasnji()

    '    ' inicijalizacija (uglavnom postavljanje na nulu) promenljivih (najvise je onih koje su nepotrebne za unutrasnji saobracaj)


    '    mUlPrelaz = ""
    '    mIzPrelaz = ""
    '    mUlEtiketa = 0
    '    mIzEtiketa = 0
    '    mDatumUlaza = Today
    '    mDatumIzlaza = Today

    '    mBrojVoza = "0"
    '    msBrojVoza = "0"
    '    msBrojVoza2 = "0"
    '    mSatVoza = "00"
    '    mSatVoza2 = "00"
    '    mNajava = "0"
    '    mNajavaKola = "0"


    'End Sub
    'Public Sub bbNadjiTovarniListDel(ByVal exOtpUprava As String, ByVal bOtpStanica As String, _
    '                                  ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
    '                                  ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
    '                                  ByRef bRetVal As String)

    '    bRetVal = ""

    '    If OkpDbVeza.State = ConnectionState.Closed Then
    '        OkpDbVeza.Open()
    '    End If

    '    Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTL2Del", OkpDbVeza)

    '    spKomanda.CommandType = CommandType.StoredProcedure

    '    Dim ulazUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
    '    ulazUprava.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inOtpUprava").Value = exOtpUprava

    '    Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
    '    ulStanica.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

    '    Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
    '    ulBroj.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

    '    Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
    '    ulDatum.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inDatum").Value = bDatum

    '    '-------------------------------------- Izlazne promenljive ----------------------------------------------
    '    Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
    '    exRecID.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outRecID").Value = bRecID

    '    Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
    '    exStanicaRecID.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outStanicaRecID").Value = bStanicaRecID


    '    '---------------------------------------------------------------------------------------------------------

    '    Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
    '    izlRetVal.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outRetVal").Value = bRetVal

    '    Try
    '        spKomanda.ExecuteScalar()

    '        bRecID = spKomanda.Parameters("@outRecID").Value
    '        UpdRecID = bRecID
    '        bStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
    '        UpdStanicaRecID = bStanicaRecID

    '    Catch SQLExp As SqlException
    '        bRetVal = SQLExp.Message & " SQL greska u programu!"
    '    Catch Exp As Exception
    '        bRetVal = Err.Description & " Greska u programu!"
    '    Finally
    '        OkpDbVeza.Close()
    '        spKomanda.Dispose()
    '    End Try

    'End Sub

    Public Sub bbNadjiTovarniListLokalDel(ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, _
                                      ByRef outRecID As Int32, ByRef outStanicaRecID As String, _
                                      ByRef outRM As String, ByRef outRG As String, ByRef outRetVal As String)

        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        ' u donjoj sp je ukljuceno Saobracaj = 1

        Dim spKomanda As New SqlClient.SqlCommand("bNadjiTL5LokalDelNew", OkpDbVeza)
        'Dim spKomanda As New SqlClient.SqlCommand("roba1708.bNadjiTL5LokalDel", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure


        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = bOtpStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = bOtpBroj

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim exRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        exRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = outRecID

        Dim exStanicaRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaRecID", SqlDbType.Char, 5))
        exStanicaRecID.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaRecID").Value = outStanicaRecID

        Dim exRM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRMesec", SqlDbType.Char, 2))
        exRM.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRMesec").Value = outRM

        Dim exRG As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRGodina", SqlDbType.Char, 4))
        exRG.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRGodina").Value = outRG
        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()

            outRecID = spKomanda.Parameters("@outRecID").Value
            outStanicaRecID = spKomanda.Parameters("@outStanicaRecID").Value
            outRM = spKomanda.Parameters("@outRMesec").Value
            outRG = spKomanda.Parameters("@outRGodina").Value

            'UpdRecID = outRecID
            'UpdStanicaRecID = outStanicaRecID

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub bbBrisiTLLokal(ByVal _RecID As Int32, ByVal _Stanica As String, _
                      ByRef _mRetVal As Int32)

        _mRetVal = 0
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("dbo.spBrisanjeTLUI", OkpDbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bBrisanjeTLLokal", OkpDbVeza)

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

    Public Sub DaLiVaziPDV(ByRef outVaziPDV As Boolean)

        'Dim Nak_Red As DataRow
        'If dtNaknade.Rows.Count > 0 Then
        '    For Each Nak_Red In dtNaknade.Rows
        '        If Nak_Red.Item("Sifra") = "62" And (Nak_Red.Item("IvicniBroj") = "1" Or Nak_Red.Item("IvicniBroj") = "2") Then
        '            outVaziPDV = True
        '        Else
        '            outVaziPDV = False
        '        End If
        '    Next
        'End If
    End Sub
    Public Sub bOsveziNizNazivaNaknada()
        Dim Nak_Red As DataRow
        Dim k As Int16
        Dim bRetValLok As String = ""

        For k = 0 To 10
            bNazivNaknadeArr(k) = ""
        Next k
        k = 0
        If dtNaknade.Rows.Count > 0 Then
            For Each Nak_Red In dtNaknade.Rows
                If ((Nak_Red.Item("Sifra") <> "35") Or (Nak_Red.Item("Sifra") <> "36") Or (Nak_Red.Item("Sifra") <> "62")) Then
                    bNadjiSveIzZSNaknada(Nak_Red.Item("Sifra"), Nak_Red.Item("IvicniBroj"), "1", mTarifa, mOtpDatum, _
                                                         "72", bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bRetValLok)
                End If
                If Nak_Red.Item("Sifra") = "35" Then
                    bNadjiIndKol("72" + mStanica2, Nak_Red.Item("IvicniBroj"), bbDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bRetValLok)
                End If

                If Nak_Red.Item("Sifra") = "36" Then
                    bNadjiIndKol("72" + mStanica1, Nak_Red.Item("IvicniBroj"), bbDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bRetValLok)
                End If

                If (Nak_Red.Item("Sifra") = "10" And Nak_Red.Item("IvicniBroj") = "03") Or _
                    (Nak_Red.Item("Sifra") = "50" And Nak_Red.Item("IvicniBroj") = "01") Or _
                    (Nak_Red.Item("Sifra") = "54" And Nak_Red.Item("IvicniBroj") = "01") Then
                    bNazivNaknadeArr(k) = ""
                Else
                    bNazivNaknadeArr(k) = bNazivNaknade
                End If

                k = k + 1
            Next
        End If
    End Sub
    Public Sub bNadjiIndKol(ByVal inStanica As String, ByVal inIvicniBroj As String, ByVal inDatum As DateTime, _
                         ByRef outNazivNaknade As String, ByRef outIznos1 As Decimal, ByRef outIznos2 As Decimal, ByRef outIznos3 As Decimal, _
                         ByRef outRetVal As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("spNadjiIndKol", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica").Value = inStanica

        Dim ulIvicniBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIvicniBroj", SqlDbType.Char, 2))
        ulIvicniBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inIvicniBroj").Value = inIvicniBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = inDatum

        Dim izlNazivNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivNaknade", SqlDbType.VarChar, 50))
        izlNazivNaknade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNazivNaknade").Value = outNazivNaknade

        Dim izlIznos1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos1", SqlDbType.Decimal))
        izlIznos1.Size = 9
        izlIznos1.Precision = 10
        izlIznos1.Scale = 2
        izlIznos1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznos1").Value = outIznos1

        Dim izlIznos2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos2", SqlDbType.Decimal))
        izlIznos2.Size = 9
        izlIznos2.Precision = 10
        izlIznos2.Scale = 2
        izlIznos2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznos2").Value = outIznos2

        Dim izlIznos3 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos3", SqlDbType.Decimal))
        izlIznos3.Size = 9
        izlIznos3.Precision = 10
        izlIznos3.Scale = 2
        izlIznos3.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznos3").Value = outIznos3

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try

            spKomanda.ExecuteScalar()

            outNazivNaknade = spKomanda.Parameters("@outNazivNaknade").Value
            outIznos1 = spKomanda.Parameters("@outIznos1").Value
            outIznos2 = spKomanda.Parameters("@outIznos2").Value
            outIznos3 = spKomanda.Parameters("@outIznos3").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska: Ind.Koloseci!"
        Catch Exp As Exception
            outRetVal = Err.Description & " VB greska: Ind.Koloseci!"
        Finally

            DbVeza.Close()
            spKomanda.Dispose()

        End Try

    End Sub
    Public Sub bNadjiSveIzZSNaknada( _
                                ByVal inSifraNaknade As String, _
                                ByVal inIvicniBroj As String, _
                                ByVal inVrstaSaobracaja As Integer, _
                                ByVal inTarifa As String, _
                                ByVal inDatum As DateTime, _
                                ByRef outSifraValute As String, _
                                ByRef outNazivNaknade As String, _
                                ByRef outPodBroj As String, _
                                ByRef outIznos1 As Decimal, _
                                ByRef outIznos2 As Decimal, _
                                ByRef outIznos3 As Decimal, _
                                ByRef outMinimum As Decimal, _
                                ByRef outRetVal As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("bspNadjiSveIzZSNaknade", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulSifraNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifra", SqlDbType.Char, 2))
        ulSifraNaknade.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifra").Value = inSifraNaknade

        Dim ulIvicniBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIvicniBroj", SqlDbType.Char, 2))
        ulIvicniBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inIvicniBroj").Value = inIvicniBroj

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaSaobracaja", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaSaobracaja").Value = inVrstaSaobracaja

        Dim ulTarifa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTarifa", SqlDbType.Char, 2))
        ulTarifa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTarifa").Value = inTarifa

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = inDatum

        Dim izlSifraValute As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraValute", SqlDbType.Char, 2))
        izlSifraValute.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraValute").Value = outSifraValute

        Dim izlNazivNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivNaknade", SqlDbType.VarChar, 50))
        izlNazivNaknade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNazivNaknade").Value = outNazivNaknade

        Dim izlPodBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPodBroj", SqlDbType.Char, 1))
        izlPodBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPodBroj").Value = outPodBroj

        Dim izlIznos1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos1", SqlDbType.Decimal))
        izlIznos1.Size = 9
        izlIznos1.Precision = 10
        izlIznos1.Scale = 2
        izlIznos1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznos1").Value = outIznos1

        Dim izlIznos2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos2", SqlDbType.Decimal))
        izlIznos2.Size = 9
        izlIznos2.Precision = 10
        izlIznos2.Scale = 2
        izlIznos2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznos2").Value = outIznos2

        Dim izlIznos3 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos3", SqlDbType.Decimal))
        izlIznos3.Size = 9
        izlIznos3.Precision = 10
        izlIznos3.Scale = 2
        izlIznos3.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznos3").Value = outIznos3

        Dim izlMinimum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinimum", SqlDbType.Decimal))
        izlMinimum.Size = 9
        izlMinimum.Precision = 10
        izlMinimum.Scale = 2
        izlMinimum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinimum").Value = outMinimum

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try

            spKomanda.ExecuteScalar()

            'Dim Pom As Int16 = spKomanda.Parameters("@PovrVrednost").Value
            'Pom = spKomanda.Parameters("@PovrVrednost").Value
            'If Pom <> 0 Then outRetVal = " Neuspesan upit!" 'Pom = spKomanda.Parameters("@PovrVrednost").Value

            outNazivNaknade = spKomanda.Parameters("@outNazivNaknade").Value
            outSifraValute = spKomanda.Parameters("@outSifraValute").Value
            outPodBroj = spKomanda.Parameters("@outPodBroj").Value
            outIznos1 = spKomanda.Parameters("@outIznos1").Value
            outIznos2 = spKomanda.Parameters("@outIznos2").Value
            outIznos3 = spKomanda.Parameters("@outIznos3").Value
            outMinimum = spKomanda.Parameters("@outMinimum").Value
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
    Public Sub bNadjiPDVIzSloga(ByVal inRecID As Int32, ByRef outPDV1 As Decimal, ByRef outPDV2 As Decimal, _
                                            ByRef outRetVal As String)

        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.bNadjiPDV", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int))
        ulRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRecID").Value = inRecID

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izlPDV1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPDV1", SqlDbType.Decimal, 9))
        izlPDV1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPDV1").Precision = 12
        spKomanda.Parameters("@outPDV1").Scale = 2
        spKomanda.Parameters("@outPDV1").Value = outPDV1


        Dim izlPDV2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPDV2", SqlDbType.Decimal, 9))
        izlPDV2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPDV2").Precision = 12
        spKomanda.Parameters("@outPDV2").Scale = 2
        spKomanda.Parameters("@outPDV2").Value = outPDV2

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()

            outPDV1 = spKomanda.Parameters("@outPDV1").Value
            outPDV2 = spKomanda.Parameters("@outPDV2").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

        If outRetVal <> "" Then
            outPDV1 = 0
            outPDV2 = 0
        End If

    End Sub
    Public Sub NadjiTLpr(ByVal bPrStanica As String, ByVal bPrBroj As Int32, _
                        ByVal bObrGodina As String, ByRef bRecID As Int32, ByRef bStanicaRecID As String, _
                        ByRef bRetVal As String)

        bRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTLpr", OkpDbVeza)
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
    Public Sub bPostaviObracunskiMesec(ByRef outObrMesec As String, ByRef outObrGodina As String)
        'Dim qObrMesec As String
        'Dim qObrGodina As String

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        '---------------------------------------- postavljanje racunskog meseca ------------------------------------------

        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
            IzborSaobracaja = "4"
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
            IzborSaobracaja = "2"
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
            IzborSaobracaja = "3"
        Else
            IzborSaobracaja = "1"
        End If

        Dim sql_text1 As String = "SELECT MesecUnosa, GodinaUnosa FROM RacMesec " & _
                                  "WHERE (VSaob = '" & IzborSaobracaja & "')"
        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrRm.Read()
            outObrMesec = rdrRm.GetString(0)
            outObrGodina = rdrRm.GetString(1)
        Loop
        rdrRm.Close()
        OkpDbVeza.Close()
    End Sub
    Public Sub bNadjiTLUBaziPoOtpAdm(ByVal inOtpStanica As String, ByVal inOtpBroj As Int32, _
                                ByRef outOtpDatum As Date, _
                                ByRef outPrStanica As String, ByRef outPrBroj As Int32, ByRef outPrDatum As Date, _
                                ByRef outObrMesec As String, ByRef outObrGodina As String, _
                                ByRef outRecID As Int32, ByRef outStanicaID As String, ByRef outSaobracaj As String, _
                                ByRef outRetVal As String)

        outRetVal = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTLuBazi", OkpDbVeza)

        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bNadjiUTLUBaziPoOtpAdm", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulOtpStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulOtpStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = inOtpStanica

        Dim ulOtpBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulOtpBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = inOtpBroj


        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izlOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpDatum", SqlDbType.DateTime))
        izlOtpDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpDatum").Value = outOtpDatum

        Dim izlPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        izlPrStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = outPrStanica

        Dim izlPrBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrBroj", SqlDbType.Int))
        izlPrBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrBroj").Value = outPrBroj

        Dim izlPrDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrDatum", SqlDbType.DateTime))
        izlPrDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrDatum").Value = outPrDatum

        Dim izlRacMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRacMesec", SqlDbType.Char, 2))
        izlRacMesec.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRacMesec").Value = outObrMesec

        Dim izlRacGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRacGodina", SqlDbType.Char, 4))
        izlRacGodina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRacGodina").Value = outObrGodina

        Dim izlRecId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        izlRecId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = outRecID

        Dim izlStanicaId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaID", SqlDbType.Char, 5))
        izlStanicaId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaID").Value = outStanicaID

        Dim izlSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSaobracaj", SqlDbType.Char, 1))
        izlSaobracaj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSaobracaj").Value = outSaobracaj

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()

            outOtpDatum = spKomanda.Parameters("@outOtpDatum").Value
            outPrStanica = spKomanda.Parameters("@outPrStanica").Value
            outPrBroj = spKomanda.Parameters("@outPrBroj").Value
            outPrDatum = spKomanda.Parameters("@outPrDatum").Value
            outObrMesec = spKomanda.Parameters("@outRacMesec").Value
            outObrGodina = spKomanda.Parameters("@outRacGodina").Value
            outRecID = spKomanda.Parameters("@outRecID").Value
            outStanicaID = spKomanda.Parameters("@outStanicaID").Value
            outSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
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
    Public Sub bNadjiTLUBaziPoPrAdm(ByVal inPrStanica As String, ByVal inPrBroj As Int32, _
                                   ByRef outPrDatum As Date, _
                                   ByRef outOtpStanica As String, ByRef outOtpBroj As Int32, ByRef outOtpDatum As Date, _
                                   ByRef outObrMesec As String, ByRef outObrGodina As String, _
                                   ByRef outRecID As Int32, ByRef outStanicaID As String, ByRef outSaobracaj As String, _
                                   ByRef outRetVal As String)

        outRetVal = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("dbo.NadjiTLuBazi", OkpDbVeza)

        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bNadjiUTLUBaziPoPrAdm", OkpDbVeza)

        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7))
        ulPrStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrStanica").Value = inPrStanica

        Dim ulPrBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int))
        ulPrBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrBroj").Value = inPrBroj


        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izlPrDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrDatum", SqlDbType.DateTime))
        izlPrDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrDatum").Value = outPrDatum

        Dim izlOtpStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpStanica", SqlDbType.Char, 7))
        izlOtpStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpStanica").Value = outOtpStanica

        Dim izlOtpBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpBroj", SqlDbType.Int))
        izlOtpBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpBroj").Value = outOtpBroj

        Dim izlOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpDatum", SqlDbType.DateTime))
        izlOtpDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpDatum").Value = outOtpDatum

        Dim izlRacMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRacMesec", SqlDbType.Char, 2))
        izlRacMesec.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRacMesec").Value = outObrMesec

        Dim izlRacGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRacGodina", SqlDbType.Char, 4))
        izlRacGodina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRacGodina").Value = outObrGodina

        Dim izlRecId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        izlRecId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = outRecID

        Dim izlStanicaId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaID", SqlDbType.Char, 5))
        izlStanicaId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaID").Value = outStanicaID

        Dim izlSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSaobracaj", SqlDbType.Char, 1))
        izlSaobracaj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSaobracaj").Value = outSaobracaj

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()

            outPrDatum = spKomanda.Parameters("@outPrDatum").Value
            outOtpStanica = spKomanda.Parameters("@outOtpStanica").Value
            outOtpBroj = spKomanda.Parameters("@outOtpBroj").Value
            outOtpDatum = spKomanda.Parameters("@outOtpDatum").Value
            outObrMesec = spKomanda.Parameters("@outRacMesec").Value
            outObrGodina = spKomanda.Parameters("@outRacGodina").Value
            outRecID = spKomanda.Parameters("@outRecID").Value
            outStanicaID = spKomanda.Parameters("@outStanicaID").Value
            outSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
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

    Public Sub UpdateOtpravljanjeuBazi(ByVal ipTrans As SqlTransaction, ByVal exOtpUprava As String, ByVal bOtpStanica As String, ByVal bOtpBroj As Int32, ByVal bDatum As Date, _
                            ByVal upOtpUprava As String, ByVal upOtpStanica As String, ByVal upOtpBroj As Int32, ByVal upOtpDatum As Date, _
                            ByRef bRetVal As String)

        bRetVal = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("dbo.UpdateTLuBazi", OkpDbVeza)
        'Dim spKomanda As New SqlClient.SqlCommand("roba1708.bUpdateOtpravljanjeUBazi", OkpDbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bUpdateOtpravljanjeUBazi2", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        Dim ulUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4))
        ulUprava.Direction = ParameterDirection.Input
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

        Dim upUprava As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUpOtpUprava", SqlDbType.Char, 4))
        upUprava.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUpOtpUprava").Value = upOtpUprava

        Dim upStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUpOtpStanica", SqlDbType.Char, 7))
        upStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUpOtpStanica").Value = upOtpStanica

        Dim upBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUpOtpBroj", SqlDbType.Int))
        upBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUpOtpBroj").Value = upOtpBroj

        Dim upDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUpDatum", SqlDbType.DateTime))
        upDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUpDatum").Value = upOtpDatum

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        'Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        'izlRetVal.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outRetVal").Value = bRetVal

        spKomanda.Transaction = ipTrans

        Try
            'spKomanda.ExecuteScalar()
            'bRetVal = spKomanda.Parameters("@outRetVal").Value
            spKomanda.ExecuteNonQuery()
            If spKomanda.Parameters("@RETURN_VALUE").Value = 0 Then bRetVal = "Ništa nije upisano u bazu!"
        Catch SQLExp As SqlException
            bRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bRetVal = Err.Description & " Greska u programu!"
        Finally
            spKomanda.Dispose()
            'OkpDbVeza.Close()
        End Try

    End Sub
    Public Sub bNadjiObrMesecIzSlogaKalk(ByVal inRecID As Int32, ByRef outObrMesec As String, ByRef outObrGodina As String, _
                                                ByRef outRetVal As String)


        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bNadjiObrMesecIGodinuIzSlogaKalk", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int))
        ulRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRecID").Value = inRecID

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izlObrMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outObrMesec", SqlDbType.Char, 2))
        izlObrMesec.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outObrMesec").Value = outObrMesec

        Dim izlObrGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outObrGodina", SqlDbType.Char, 4))
        izlObrGodina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outObrGodina").Value = outObrGodina

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()

            outObrMesec = spKomanda.Parameters("@outObrMesec").Value
            outObrGodina = spKomanda.Parameters("@outObrGodina").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

        If outRetVal <> "" Then
            outObrMesec = ""
            outObrGodina = ""
        End If


    End Sub
    'Declare Function PlaySound Lib "winmm.dll" Alias "PlaySoundA" (ByVal lpszName As String, ByVal hModule As Integer, ByVal dwFlags As Integer) As Integer

    'Public Sub bPronadjiNaknadu72(ByVal inRecID As Int32, ByVal inStavka As Int32, ByRef outNasao As Boolean)

    '    Dim bLokRetVal As String = ""

    '    'bRetVal = ""

    '    If OkpDbVeza.State = ConnectionState.Closed Then
    '        OkpDbVeza.Open()
    '    End If

    '    Dim spKomanda As New SqlClient.SqlCommand("roba1708.bNadjiNaknadu72", OkpDbVeza)
    '    spKomanda.CommandType = CommandType.StoredProcedure

    '    Dim ulRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int))
    '    ulRecID.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inRecID").Value = inRecID

    '    Dim ulStavka As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inNaknadeStavka", SqlDbType.Int))
    '    ulStavka.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inNaknadeStavka").Value = inRecID


    '    '-------------------------------------- Izlazne promenljive ----------------------------------------------
    '    'Dim izlObrMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outObrMesec", SqlDbType.Char, 2))
    '    'izlObrMesec.Direction = ParameterDirection.Output
    '    'spKomanda.Parameters("@outObrMesec").Value = outObrMesec

    '    'Dim izlObrGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outObrGodina", SqlDbType.Char, 4))
    '    'izlObrGodina.Direction = ParameterDirection.Output
    '    'spKomanda.Parameters("@outObrGodina").Value = outObrGodina

    '    '---------------------------------------------------------------------------------------------------------

    '    Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
    '    izlRetVal.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outRetVal").Value = bRetVal

    '    Try
    '        spKomanda.ExecuteScalar()

    '        'outObrMesec = spKomanda.Parameters("@outObrMesec").Value
    '        'outObrGodina = spKomanda.Parameters("@outObrGodina").Value
    '        bRetVal = spKomanda.Parameters("@outRetVal").Value

    '    Catch SQLExp As SqlException
    '        bRetVal = SQLExp.Message & " SQL greska u programu!"
    '    Catch Exp As Exception
    '        bRetVal = Err.Description & " Greska u programu!"
    '    Finally
    '        OkpDbVeza.Close()
    '        spKomanda.Dispose()
    '    End Try

    '    'If bRetVal <> "" Then
    '    '    outObrMesec = ""
    '    '    outObrGodina = ""
    '    'End If

    'End Sub
    Public Sub UpdatePrispeceUBazi(ByVal ipTrans As SqlTransaction, ByVal inRecID As Int32, ByVal inPrStanica As String, ByVal inPrBroj As Int32, ByVal inPrDatum As Date, _
                                ByRef outRetVal As String)

        outRetVal = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bUpdatePrispeceUBazi", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        Dim ulRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int))
        ulRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRecID").Value = inRecID

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrStanica").Value = inPrStanica

        Dim ulBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int))
        ulBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrBroj").Value = inPrBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrDatum").Value = inPrDatum


        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        'Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        'izlRetVal.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outRetVal").Value = bRetVal

        spKomanda.Transaction = ipTrans

        Try
            'spKomanda.ExecuteScalar()
            'bRetVal = spKomanda.Parameters("@outRetVal").Value
            spKomanda.ExecuteNonQuery()
            If spKomanda.Parameters("@RETURN_VALUE").Value = 0 Then outRetVal = "Ništa nije upisano u bazu!"
        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            spKomanda.Dispose()
            'OkpDbVeza.Close()
        End Try

    End Sub
    Public Sub bProveri8606(ByVal ulNHM As String, _
                            ByRef izl8606 As Boolean, _
                            ByRef izlKao8606 As Boolean)
        izl8606 = False
        izlKao8606 = False


        If Microsoft.VisualBasic.Left(ulNHM, 4) = "8606" Then
            izl8606 = True
            izlKao8606 = False
        End If

        If ulNHM = "992110" Or ulNHM = "992120" Or ulNHM = "992130" Or ulNHM = "992140" Or _
            ulNHM = "992210" Or ulNHM = "992220" Or ulNHM = "992230" Or ulNHM = "992240" Or _
            Microsoft.VisualBasic.Left(ulNHM, 4) = "8601" Or Microsoft.VisualBasic.Left(ulNHM, 4) = "8602" Or _
            Microsoft.VisualBasic.Left(ulNHM, 4) = "8603" Or Microsoft.VisualBasic.Left(ulNHM, 4) = "8604" Or _
            Microsoft.VisualBasic.Left(ulNHM, 4) = "8605" Then
            izl8606 = False
            izlKao8606 = True
        End If


    End Sub
    Public Sub bUpdatePosIPrimUBazi(ByVal ipTrans As SqlTransaction, ByVal inRecID As Int32, ByVal inPosiljalac As Int32, ByVal inPrimalac As Int32, ByRef outRetVal As String)

        outRetVal = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("roba1708.bUpdatePrispeceUBazi", OkpDbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bUpdatePosIPrimUBazi", OkpDbVeza)

        spKomanda.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        Dim ulRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int))
        ulRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRecID").Value = inRecID

        Dim ulPosiljalac As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPosiljalac", SqlDbType.Int))
        ulPosiljalac.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPosiljalac").Value = inPosiljalac

        Dim ulPrimalac As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrimalac", SqlDbType.Int))
        ulPrimalac.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrimalac").Value = inPrimalac


        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        'Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        'izlRetVal.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outRetVal").Value = bRetVal

        spKomanda.Transaction = ipTrans

        Try
            'spKomanda.ExecuteScalar()
            'bRetVal = spKomanda.Parameters("@outRetVal").Value
            spKomanda.ExecuteNonQuery()
            If spKomanda.Parameters("@RETURN_VALUE").Value = 0 Then outRetVal = "Ništa nije upisano u bazu!"
        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            spKomanda.Dispose()
            'OkpDbVeza.Close()
        End Try

    End Sub
    Public Sub bNadjiPosIPrimIzTLAdm(ByVal inOtpStanica As String, ByVal inOtpBroj As Int32, ByVal inOtpDatum As Date, _
                                    ByRef outPrStanica As String, ByRef outPrBroj As Int32, ByRef outPrDatum As Date, _
                                    ByRef outPosiljalac As Int32, ByRef outPrimalac As Int32, _
                                    ByRef outObrMesec As String, ByRef outObrGodina As String, _
                                    ByRef outRecID As Int32, ByRef outStanicaID As String, ByRef outSaobracaj As String, _
                                    ByRef outRetVal As String)

        outRetVal = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bNadjiPosIPrimIzTLAdm", OkpDbVeza)

        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulOtpStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulOtpStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = inOtpStanica

        Dim ulOtpBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulOtpBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = inOtpBroj

        Dim ulOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime))
        ulOtpDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpDatum").Value = inOtpDatum


        '-------------------------------------- Izlazne promenljive ----------------------------------------------

        Dim izlPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        izlPrStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = outPrStanica

        Dim izlPrBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrBroj", SqlDbType.Int))
        izlPrBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrBroj").Value = outPrBroj

        Dim izlPrDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrDatum", SqlDbType.DateTime))
        izlPrDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrDatum").Value = outPrDatum

        Dim izlPosiljalac As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPosiljalac", SqlDbType.Int))
        izlPosiljalac.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPosiljalac").Value = outPosiljalac

        Dim izlPrimalac As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrimalac", SqlDbType.Int))
        izlPrimalac.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrimalac").Value = outPrimalac

        Dim izlRacMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRacMesec", SqlDbType.Char, 2))
        izlRacMesec.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRacMesec").Value = outObrMesec

        Dim izlRacGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRacGodina", SqlDbType.Char, 4))
        izlRacGodina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRacGodina").Value = outObrGodina

        Dim izlRecId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        izlRecId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = outRecID

        Dim izlStanicaId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaID", SqlDbType.Char, 5))
        izlStanicaId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaID").Value = outStanicaID

        Dim izlSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSaobracaj", SqlDbType.Char, 1))
        izlSaobracaj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSaobracaj").Value = outSaobracaj

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()

            outPrStanica = spKomanda.Parameters("@outPrStanica").Value
            outPrBroj = spKomanda.Parameters("@outPrBroj").Value
            outPrDatum = spKomanda.Parameters("@outPrDatum").Value
            outPosiljalac = spKomanda.Parameters("@outPosiljalac").Value
            outPrimalac = spKomanda.Parameters("@outPrimalac").Value
            outObrMesec = spKomanda.Parameters("@outRacMesec").Value
            outObrGodina = spKomanda.Parameters("@outRacGodina").Value
            outRecID = spKomanda.Parameters("@outRecID").Value
            outStanicaID = spKomanda.Parameters("@outStanicaID").Value
            outSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
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
    Public Sub bNadjiPosIPrimIzTLAdm2(ByVal inOtpStanica As String, ByVal inOtpBroj As Int32, ByRef outOtpDatum As Date, _
                                      ByRef outPrStanica As String, ByRef outPrBroj As Int32, ByRef outPrDatum As Date, _
                                      ByRef outPosiljalac As Int32, ByRef outPrimalac As Int32, _
                                      ByRef outObrMesec As String, ByRef outObrGodina As String, _
                                      ByRef outRecID As Int32, ByRef outStanicaID As String, ByRef outSaobracaj As String, _
                                      ByRef outRetVal As Int32, ByRef outRetValStr As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bNadjiPosIPrimIzTLAdm2", OkpDbVeza)

        outRetVal = 0
        outRetValStr = ""

        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulOtpStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7))
        ulOtpStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpStanica").Value = inOtpStanica

        Dim ulOtpBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int))
        ulOtpBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOtpBroj").Value = inOtpBroj

        'Dim ulOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime))
        'ulOtpDatum.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inOtpDatum").Value = inOtpDatum

        Dim izlOtpDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOtpDatum", SqlDbType.DateTime))
        izlOtpDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOtpDatum").Value = outOtpDatum


        '-------------------------------------- Izlazne promenljive ----------------------------------------------

        Dim izlPrStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrStanica", SqlDbType.Char, 7))
        izlPrStanica.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrStanica").Value = outPrStanica

        Dim izlPrBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrBroj", SqlDbType.Int))
        izlPrBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrBroj").Value = outPrBroj

        Dim izlPrDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrDatum", SqlDbType.DateTime))
        izlPrDatum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrDatum").Value = outPrDatum

        Dim izlPosiljalac As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPosiljalac", SqlDbType.Int))
        izlPosiljalac.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPosiljalac").Value = outPosiljalac

        Dim izlPrimalac As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrimalac", SqlDbType.Int))
        izlPrimalac.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrimalac").Value = outPrimalac

        Dim izlRacMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRacMesec", SqlDbType.Char, 2))
        izlRacMesec.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRacMesec").Value = outObrMesec

        Dim izlRacGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRacGodina", SqlDbType.Char, 4))
        izlRacGodina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRacGodina").Value = outObrGodina

        Dim izlRecId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRecID", SqlDbType.Int, 4))
        izlRecId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRecID").Value = outRecID

        Dim izlStanicaId As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStanicaID", SqlDbType.Char, 5))
        izlStanicaId.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStanicaID").Value = outStanicaID

        Dim izlSaobracaj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSaobracaj", SqlDbType.Char, 1))
        izlSaobracaj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSaobracaj").Value = outSaobracaj

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Int, 4))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()

            outOtpDatum = spKomanda.Parameters("@outOtpdatum").Value
            outPrStanica = spKomanda.Parameters("@outPrStanica").Value
            outPrBroj = spKomanda.Parameters("@outPrBroj").Value
            outPrDatum = spKomanda.Parameters("@outPrDatum").Value
            outPosiljalac = spKomanda.Parameters("@outPosiljalac").Value
            outPrimalac = spKomanda.Parameters("@outPrimalac").Value
            outObrMesec = spKomanda.Parameters("@outRacMesec").Value
            outObrGodina = spKomanda.Parameters("@outRacGodina").Value
            outRecID = spKomanda.Parameters("@outRecID").Value
            outStanicaID = spKomanda.Parameters("@outStanicaID").Value
            outSaobracaj = spKomanda.Parameters("@outSaobracaj").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetValStr = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetValStr = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Public Sub bKorigujCO72(ByVal inRecID As Int32, ByRef outTLFranko As Decimal, ByRef outTLUpuceno As Decimal, _
                                ByRef outTLSumaFr As Decimal, ByRef outTLSumaUp As Decimal, _
                                ByRef outRetVal As String)

        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bKorigujCOIznose72", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int))
        ulRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRecID").Value = inRecID

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izlazFr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevFr", SqlDbType.Decimal, 9))
        izlazFr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrevFr").Precision = 12
        spKomanda.Parameters("@outPrevFr").Scale = 2
        spKomanda.Parameters("@outPrevFr").Value = outTLFranko


        Dim izlazUp As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPrevUp", SqlDbType.Decimal, 9))
        izlazUp.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPrevUp").Precision = 12
        spKomanda.Parameters("@outPrevUp").Scale = 2
        spKomanda.Parameters("@outPrevUp").Value = outTLUpuceno

        Dim izlazSumaFr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSumaFr", SqlDbType.Decimal, 9))
        izlazSumaFr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSumaFr").Precision = 12
        spKomanda.Parameters("@outSumaFr").Scale = 2
        spKomanda.Parameters("@outSumaFr").Value = outTLFranko


        Dim izlazSumaUp As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSumaUp", SqlDbType.Decimal, 9))
        izlazSumaUp.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSumaUp").Precision = 12
        spKomanda.Parameters("@outSumaUp").Scale = 2
        spKomanda.Parameters("@outSumaUp").Value = outTLUpuceno


        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()

            outTLFranko = spKomanda.Parameters("@outPrevFr").Value
            outTLUpuceno = spKomanda.Parameters("@outPrevUp").Value
            outTLSumaFr = spKomanda.Parameters("@outSumaFr").Value
            outTLSumaUp = spKomanda.Parameters("@outSumaUp").Value

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
