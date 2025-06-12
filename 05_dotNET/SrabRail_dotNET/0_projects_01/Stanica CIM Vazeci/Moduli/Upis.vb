Imports System.Data.SqlClient
Module Upis 
    Friend Sub UpisSlogKalkIzvozSt(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, _
                            ByVal _DatumOtp As DateTime, ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, _
                            ByVal _DatumPr As DateTime, ByVal _BrojVoza As Int32, ByVal _SatVoza As String, _
                            ByVal _Najava As String, ByVal _NajavaKola As Int16, ByVal _Tarifa As String, _
                            ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, _
                            ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                            ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, _
                            ByVal _FrNaknade As String, ByVal _FrDoPrelaza As String, ByVal _Incoterms As String, _
                            ByVal _IsporukaVal As String, ByVal _Isporuka As Decimal, ByVal _PouzeceVal As String, _
                            ByVal _Pouzece As Decimal, ByVal _VrednostRobeVal As String, ByVal _VrednostRobe As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, _
                            ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, _
                            ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                            ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _CarStanica As String, ByVal _CarStanicaStart As String, ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, _
                            ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, _
                            ByVal _CarDatum As Date, ByVal _CarAgent As String, _
                            ByVal _CarXml As String, ByVal _Server As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("espUpisSlogKalkIzvoz", DbVeza)
        '''''Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spUpisSlogKalkIzvoz", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        'recid
        'stanica
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inObrGodina As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "ObrGodina", DataRowVersion.Current, _mObrGodina))
        Dim inObrMesec As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "ObrMesec", DataRowVersion.Current, _mObrMesec))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))
        
        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))

        '--- razlika u popunjavanju datuma izlaza za granicu i mrezu -----------------------------------------------
        ' staro: Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        If GranicnaStanica = "D" Then
            Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, Today()))
        Else
            Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, Today.AddDays(-10)))
        End If
        ' ----------------------------------------------------------------------------------------------------------

        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))

        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inNajava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava", DataRowVersion.Current, _Najava))
        Dim inNajavaKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola", DataRowVersion.Current, _NajavaKola))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))

        'novo
        Dim inPosiljalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPosiljalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Posiljalac", DataRowVersion.Current, _Posiljalac))
        Dim inPlatilacFRR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacFRR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacFRR", DataRowVersion.Current, _PlatilacFRR))
        Dim inPrimalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrimalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Primalac", DataRowVersion.Current, _Primalac))
        Dim inPlatilacNFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacNFR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacNFR", DataRowVersion.Current, _PlatilacNFR))

        Dim inVrPos As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPos", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPos", DataRowVersion.Current, _VrPos))
        Dim inPrevoz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrevoz", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Prevoz", DataRowVersion.Current, _Prevoz))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, _Saobracaj))
        Dim inVrSao As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrSao", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "VrSao", DataRowVersion.Current, _VrSao))
        Dim inVrPrevoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPrevoza", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPrevoza", DataRowVersion.Current, _VrPrevoza))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))

        'novo
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inFrDoPrelaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrDoPrelaza", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "FrDoPrelaza", DataRowVersion.Current, _FrDoPrelaza))
        Dim inIncoterms As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIncoterms", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Incoterms", DataRowVersion.Current, _Incoterms))
        Dim inIsporukaVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporukaVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "IsporukaVal", DataRowVersion.Current, _IsporukaVal))
        Dim inIsporuka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporuka", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Isporuka", DataRowVersion.Current, _Isporuka))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim inVrednostRobeVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobeVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "VrednostRobeVal", DataRowVersion.Current, _VrednostRobeVal))
        Dim inVrednostRobe As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobe", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VrednostRobe", DataRowVersion.Current, _VrednostRobe))

        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        '
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        '
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        '
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))

        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))
        '--------------------------------------------------------------------------------------------------------
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        Dim inCarPrimalacPIB As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacPIB", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarPrimalacPIB", DataRowVersion.Current, _CarPrimalacPIB))
        Dim inCarPrimalacNaziv As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacNaziv", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacNaziv", DataRowVersion.Current, _CarPrimalacNaziv))
        Dim inCarPrimalacSediste As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacSediste", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacSediste", DataRowVersion.Current, _CarPrimalacSediste))
        Dim inCarPrimalacZemlja As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacZemlja", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarPrimalacZemlja", DataRowVersion.Current, _CarPrimalacZemlja))
        Dim inCarValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarValuta", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarValuta", DataRowVersion.Current, _CarValuta))
        Dim inCarFaktura As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarFaktura", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 2, "CarFaktura", DataRowVersion.Current, _CarFaktura))
        Dim inCarBrFakture As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarBrFakture", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "CarBrojFakture", DataRowVersion.Current, _CarBrojFakture))
        Dim inCarDokumenti As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDokumenti", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "CarDokumenti", DataRowVersion.Current, _CarDokumenti))
        Dim inCarKnjiga As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarKnjiga", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarKnjiga", DataRowVersion.Current, _CarKnjiga))
        Dim inCarDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "CarDatum", DataRowVersion.Current, _CarDatum))
        Dim inCarAgent As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarAgent", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarAgent", DataRowVersion.Current, _CarAgent))
        Dim inCarXml As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarXml", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "CarXml", DataRowVersion.Current, _CarXml))
        Dim inServer As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inServer", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Server", DataRowVersion.Current, _Server))
        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub

    Friend Sub UpisSlogKalkIzvoz(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, _
                            ByVal _DatumOtp As DateTime, ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, _
                            ByVal _DatumPr As DateTime, ByVal _BrojVoza As Int32, ByVal _SatVoza As String, _
                            ByVal _Najava As String, ByVal _NajavaKola As Int16, ByVal _Tarifa As String, _
                            ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, _
                            ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                            ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, _
                            ByVal _FrNaknade As String, ByVal _FrDoPrelaza As String, ByVal _Incoterms As String, _
                            ByVal _IsporukaVal As String, ByVal _Isporuka As Decimal, ByVal _PouzeceVal As String, _
                            ByVal _Pouzece As Decimal, ByVal _VrednostRobeVal As String, ByVal _VrednostRobe As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, _
                            ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, _
                            ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                            ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _CarStanica As String, ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, _
                            ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, _
                            ByVal _CarDatum As Date, ByVal _CarAgent As String, _
                            ByVal _CarXml As String, ByVal _Server As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("espUpisSlogKalkIzvoz", DbVeza)
        '''''Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spUpisSlogKalkIzvoz", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        'recid
        'stanica
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inObrGodina As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "ObrGodina", DataRowVersion.Current, _mObrGodina))
        Dim inObrMesec As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "ObrMesec", DataRowVersion.Current, _mObrMesec))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))
        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))
        Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))

        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inNajava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava", DataRowVersion.Current, _Najava))
        Dim inNajavaKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola", DataRowVersion.Current, _NajavaKola))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))

        'novo
        Dim inPosiljalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPosiljalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Posiljalac", DataRowVersion.Current, _Posiljalac))
        Dim inPlatilacFRR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacFRR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacFRR", DataRowVersion.Current, _PlatilacFRR))
        Dim inPrimalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrimalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Primalac", DataRowVersion.Current, _Primalac))
        Dim inPlatilacNFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacNFR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacNFR", DataRowVersion.Current, _PlatilacNFR))

        Dim inVrPos As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPos", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPos", DataRowVersion.Current, _VrPos))
        Dim inPrevoz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrevoz", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Prevoz", DataRowVersion.Current, _Prevoz))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, _Saobracaj))
        Dim inVrSao As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrSao", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "VrSao", DataRowVersion.Current, _VrSao))
        Dim inVrPrevoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPrevoza", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPrevoza", DataRowVersion.Current, _VrPrevoza))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))

        'novo
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inFrDoPrelaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrDoPrelaza", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "FrDoPrelaza", DataRowVersion.Current, _FrDoPrelaza))
        Dim inIncoterms As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIncoterms", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Incoterms", DataRowVersion.Current, _Incoterms))
        Dim inIsporukaVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporukaVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "IsporukaVal", DataRowVersion.Current, _IsporukaVal))
        Dim inIsporuka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporuka", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Isporuka", DataRowVersion.Current, _Isporuka))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim inVrednostRobeVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobeVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "VrednostRobeVal", DataRowVersion.Current, _VrednostRobeVal))
        Dim inVrednostRobe As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobe", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VrednostRobe", DataRowVersion.Current, _VrednostRobe))

        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        '
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        '
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        '
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))

        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))
        '--------------------------------------------------------------------------------------------------------
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarPrimalacPIB As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacPIB", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarPrimalacPIB", DataRowVersion.Current, _CarPrimalacPIB))
        Dim inCarPrimalacNaziv As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacNaziv", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacNaziv", DataRowVersion.Current, _CarPrimalacNaziv))
        Dim inCarPrimalacSediste As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacSediste", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacSediste", DataRowVersion.Current, _CarPrimalacSediste))
        Dim inCarPrimalacZemlja As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacZemlja", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarPrimalacZemlja", DataRowVersion.Current, _CarPrimalacZemlja))
        Dim inCarValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarValuta", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarValuta", DataRowVersion.Current, _CarValuta))
        Dim inCarFaktura As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarFaktura", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 2, "CarFaktura", DataRowVersion.Current, _CarFaktura))
        Dim inCarBrFakture As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarBrFakture", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "CarBrojFakture", DataRowVersion.Current, _CarBrojFakture))
        Dim inCarDokumenti As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDokumenti", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "CarDokumenti", DataRowVersion.Current, _CarDokumenti))
        Dim inCarKnjiga As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarKnjiga", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarKnjiga", DataRowVersion.Current, _CarKnjiga))
        Dim inCarDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "CarDatum", DataRowVersion.Current, _CarDatum))
        Dim inCarAgent As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarAgent", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarAgent", DataRowVersion.Current, _CarAgent))
        Dim inCarXml As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarXml", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "CarXml", DataRowVersion.Current, _CarXml))
        Dim inServer As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inServer", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Server", DataRowVersion.Current, _Server))
        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub

    Friend Sub UpisSlogKalk(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, _
                            ByVal _DatumOtp As DateTime, ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, _
                            ByVal _DatumPr As DateTime, ByVal _BrojVoza As Int32, ByVal _SatVoza As String, _
                            ByVal _Najava As String, ByVal _NajavaKola As Int16, ByVal _Tarifa As String, _
                            ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, _
                            ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                            ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, _
                            ByVal _FrNaknade As String, ByVal _FrDoPrelaza As String, ByVal _Incoterms As String, _
                            ByVal _IsporukaVal As String, ByVal _Isporuka As Decimal, ByVal _PouzeceVal As String, _
                            ByVal _Pouzece As Decimal, ByVal _VrednostRobeVal As String, ByVal _VrednostRobe As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, _
                            ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, _
                            ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                            ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _CarStanica As String, ByVal _CarStanicaStart As String, ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, _
                            ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, _
                            ByVal _CarDatum As Date, ByVal _CarAgent As String, _
                            ByVal _CarXml As String, ByVal _Server As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpisSlogKalk", DbVeza)
        ''Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spUpisSlogKalk", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        'recid
        'stanica
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inObrGodina As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "ObrGodina", DataRowVersion.Current, _mObrGodina))
        Dim inObrMesec As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "ObrMesec", DataRowVersion.Current, _mObrMesec))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))
        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))
        Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))

        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inNajava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava", DataRowVersion.Current, _Najava))
        Dim inNajavaKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola", DataRowVersion.Current, _NajavaKola))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))

        'novo
        Dim inPosiljalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPosiljalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Posiljalac", DataRowVersion.Current, _Posiljalac))
        Dim inPlatilacFRR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacFRR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacFRR", DataRowVersion.Current, _PlatilacFRR))
        Dim inPrimalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrimalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Primalac", DataRowVersion.Current, _Primalac))
        Dim inPlatilacNFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacNFR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacNFR", DataRowVersion.Current, _PlatilacNFR))

        Dim inVrPos As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPos", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPos", DataRowVersion.Current, _VrPos))
        Dim inPrevoz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrevoz", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Prevoz", DataRowVersion.Current, _Prevoz))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, _Saobracaj))
        Dim inVrSao As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrSao", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "VrSao", DataRowVersion.Current, _VrSao))
        Dim inVrPrevoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPrevoza", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPrevoza", DataRowVersion.Current, _VrPrevoza))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))

        'novo
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inFrDoPrelaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrDoPrelaza", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "FrDoPrelaza", DataRowVersion.Current, _FrDoPrelaza))
        Dim inIncoterms As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIncoterms", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Incoterms", DataRowVersion.Current, _Incoterms))
        Dim inIsporukaVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporukaVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "IsporukaVal", DataRowVersion.Current, _IsporukaVal))
        Dim inIsporuka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporuka", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Isporuka", DataRowVersion.Current, _Isporuka))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim inVrednostRobeVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobeVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "VrednostRobeVal", DataRowVersion.Current, _VrednostRobeVal))
        Dim inVrednostRobe As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobe", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VrednostRobe", DataRowVersion.Current, _VrednostRobe))

        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        '
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        '
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        '
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))

        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))
        '--------------------------------------------------------------------------------------------------------
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        Dim inCarPrimalacPIB As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacPIB", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarPrimalacPIB", DataRowVersion.Current, _CarPrimalacPIB))
        Dim inCarPrimalacNaziv As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacNaziv", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacNaziv", DataRowVersion.Current, _CarPrimalacNaziv))
        Dim inCarPrimalacSediste As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacSediste", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacSediste", DataRowVersion.Current, _CarPrimalacSediste))
        Dim inCarPrimalacZemlja As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacZemlja", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarPrimalacZemlja", DataRowVersion.Current, _CarPrimalacZemlja))
        Dim inCarValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarValuta", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarValuta", DataRowVersion.Current, _CarValuta))
        Dim inCarFaktura As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarFaktura", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 2, "CarFaktura", DataRowVersion.Current, _CarFaktura))
        Dim inCarBrFakture As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarBrFakture", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "CarBrojFakture", DataRowVersion.Current, _CarBrojFakture))
        Dim inCarDokumenti As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDokumenti", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "CarDokumenti", DataRowVersion.Current, _CarDokumenti))
        Dim inCarKnjiga As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarKnjiga", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarKnjiga", DataRowVersion.Current, _CarKnjiga))
        Dim inCarDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "CarDatum", DataRowVersion.Current, _CarDatum))
        Dim inCarAgent As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarAgent", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarAgent", DataRowVersion.Current, _CarAgent))
        Dim inCarXml As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarXml", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "CarXml", DataRowVersion.Current, _CarXml))
        Dim inServer As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inServer", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Server", DataRowVersion.Current, _Server))
        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub
    Friend Sub UpisSlogKola(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, ByVal _mKolaStavka As Int16, _
                            ByVal _IBK As String, ByVal _IBKOK As String, ByVal _Uprava As String, ByVal _Vlasnik As String, _
                            ByVal _Serija As String, ByVal _Osovine As Int16, ByVal _Tara As Int32, ByVal _GranTov As Int32, _
                            ByVal _Stitna As String, ByVal _TipKola As String, ByVal _Prevoznina As Decimal, ByVal _Naknada As Decimal, _
                            ByVal _ICF As String, _
                            ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKola As New SqlClient.SqlCommand("dbo.spUpisSlogKola", DbVeza) 'roba

        uspUpisSlogKola.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inKolaStavka As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inKolaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "KolaStavka", DataRowVersion.Current, _mKolaStavka))

        Dim inIBK As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "IBK", DataRowVersion.Current, _IBK))
        Dim inIBKOK As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inIBKOK", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Kontrola", DataRowVersion.Current, _IBKOK))
        Dim inUprava As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inUprava", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Uprava", DataRowVersion.Current, _Uprava))
        Dim inVlasnik As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inVlasnik", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Vlasnik", DataRowVersion.Current, _Vlasnik))
        Dim inSerija As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inSerija", SqlDbType.Char, 11, ParameterDirection.Input, False, 0, 0, "Serija", DataRowVersion.Current, _Serija))
        Dim inOsovine As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inOsovine", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Osovine", DataRowVersion.Current, _Osovine))
        Dim inTara As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inTara", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Tara", DataRowVersion.Current, _Tara))
        Dim inGranTov As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inGranTov", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "GranTov", DataRowVersion.Current, _GranTov))
        Dim inStitna As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inStitna", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Stitna", DataRowVersion.Current, _Stitna))
        Dim inTipKola As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inTipKola", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "TipKola", DataRowVersion.Current, _TipKola))
        Dim inPrevoznina As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inPrevoznina", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Prevoznina", DataRowVersion.Current, _Prevoznina))
        Dim inNaknada As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inNaknada", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Naknada", DataRowVersion.Current, _Naknada))
        Dim inICF As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inICF", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "ICF", DataRowVersion.Current, _ICF))

        uspUpisSlogKola.Transaction = ipTrans

        Try
            uspUpisSlogKola.ExecuteNonQuery()
            If uspUpisSlogKola.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogKola!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKola.Dispose()
        End Try

    End Sub
    Friend Sub eUpisSlogKola(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _mKolaStavka As Int16, _
                        ByVal _IBK As String, ByVal _IBKOK As String, ByVal _Uprava As String, ByVal _Vlasnik As String, _
                        ByVal _Serija As String, ByVal _Osovine As Int16, ByVal _Tara As Int32, ByVal _GranTov As Int32, _
                        ByVal _Stitna As String, ByVal _TipKola As String, ByVal _Prevoznina As Decimal, ByVal _Naknada As Decimal, _
                        ByVal _ICF As String, _
                        ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKola As New SqlClient.SqlCommand("dbo.espUpisSlogKola", DbVeza) 'roba

        uspUpisSlogKola.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inKolaStavka As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inKolaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "KolaStavka", DataRowVersion.Current, _mKolaStavka))

        Dim inIBK As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "IBK", DataRowVersion.Current, _IBK))
        Dim inIBKOK As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inIBKOK", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Kontrola", DataRowVersion.Current, _IBKOK))
        Dim inUprava As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inUprava", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Uprava", DataRowVersion.Current, _Uprava))
        Dim inVlasnik As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inVlasnik", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Vlasnik", DataRowVersion.Current, _Vlasnik))
        Dim inSerija As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inSerija", SqlDbType.Char, 11, ParameterDirection.Input, False, 0, 0, "Serija", DataRowVersion.Current, _Serija))
        Dim inOsovine As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inOsovine", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Osovine", DataRowVersion.Current, _Osovine))
        Dim inTara As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inTara", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Tara", DataRowVersion.Current, _Tara))
        Dim inGranTov As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inGranTov", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "GranTov", DataRowVersion.Current, _GranTov))
        Dim inStitna As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inStitna", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Stitna", DataRowVersion.Current, _Stitna))
        Dim inTipKola As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inTipKola", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "TipKola", DataRowVersion.Current, _TipKola))
        Dim inPrevoznina As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inPrevoznina", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Prevoznina", DataRowVersion.Current, _Prevoznina))
        Dim inNaknada As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inNaknada", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Naknada", DataRowVersion.Current, _Naknada))
        Dim inICF As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inICF", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "ICF", DataRowVersion.Current, _ICF))

        uspUpisSlogKola.Transaction = ipTrans

        Try
            uspUpisSlogKola.ExecuteNonQuery()
            If uspUpisSlogKola.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogKola!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKola.Dispose()
        End Try

    End Sub

    Friend Sub UpisSlogRoba(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                            ByVal _mKolaStavka As Int16, ByVal _mRobaStavka As Int16, ByVal _NHM As String, ByVal _R As String, _
                            ByVal _SMasa As Int32, ByVal _RID As Int16, ByVal _UtiTip As String, ByVal _UtiIB As String, _
                            ByVal _UtiTara As Int32, ByVal _UtiRaster As Decimal, ByVal _UtiNHM As String, _
                            ByVal _UtiPredajniList As String, ByVal _UtiBrPlombe As String, _
                            ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogRoba As New SqlClient.SqlCommand("dbo.spUpisSlogRoba", DbVeza) 'roba
        uspUpisSlogRoba.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inKolaStavka As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inKolaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "KolaStavka", DataRowVersion.Current, _mKolaStavka))
        Dim inRobaStavka As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRobaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RobaStavka", DataRowVersion.Current, _mRobaStavka))
        Dim inNHM As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inNHM", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "NHM", DataRowVersion.Current, _NHM))
        Dim inR As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inR", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "NHMRazred", DataRowVersion.Current, _R))
        Dim inSMasa As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inSMasa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SMasa", DataRowVersion.Current, _SMasa))
        Dim inRID As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRID", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "RID", DataRowVersion.Current, _RID))
        Dim inUtiTip As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiTip", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "UtiTip", DataRowVersion.Current, _UtiTip))
        Dim inUtiIB As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiIB", SqlDbType.Char, 11, ParameterDirection.Input, False, 0, 0, "UtiIB", DataRowVersion.Current, _UtiIB))
        Dim inUtiTara As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiTara", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UtiTara", DataRowVersion.Current, _UtiTara))
        Dim inUtiRaster As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiRaster", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "UtiRaster", DataRowVersion.Current, _UtiRaster))
        Dim inUtiNHM As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiNHM", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "UtiNHM", DataRowVersion.Current, _UtiNHM))
        Dim inUtiPredajniList As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiPredajniList", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "UtiPredajniList", DataRowVersion.Current, _UtiPredajniList))
        Dim inUtiBrPlombe As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiBrPlombe", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "UtiBrPlombe", DataRowVersion.Current, _UtiBrPlombe))

        'nastaviti do kraja

        uspUpisSlogRoba.Transaction = ipTrans

        Try
            uspUpisSlogRoba.ExecuteNonQuery()
            If uspUpisSlogRoba.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogKola!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogRoba.Dispose()
        End Try

    End Sub
    Friend Sub UpisSlogDencane(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, _
                            ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, _
                            ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, ByVal _DencanoStavka As Int32, _
                            ByVal _Tarife As Int32, ByVal _StvMasa As Int32, ByVal _RacMasa As Int32, _
                            ByVal _Tip As Int32, ByVal _Komada As Int32, _
                            ByVal _Iznos As Decimal, ByVal _Valuta As String, _
                            ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogDencane As New SqlClient.SqlCommand("dbo.spUpisSlogDencane", DbVeza) 'roba
        uspUpisSlogDencane.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inDencanoStavka As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inDencanoStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "DencanoStavka", DataRowVersion.Current, _DencanoStavka))

        Dim inTarife As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inTarife", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Tarife", DataRowVersion.Current, _Tarife))
        Dim inStvMasa As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inStvMasa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "StvMasa", DataRowVersion.Current, _StvMasa))
        Dim inRacMasa As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inRacMasa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RacMasa", DataRowVersion.Current, _RacMasa))
        Dim inTip As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inTip", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Tip", DataRowVersion.Current, _Tip))
        Dim inKomada As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inKomada", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Komada", DataRowVersion.Current, _Komada))
        Dim inIznos As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "Iznos", DataRowVersion.Current, _Iznos))
        Dim inValuta As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Valuta", DataRowVersion.Current, _Valuta))

        uspUpisSlogDencane.Transaction = ipTrans

        Try
            uspUpisSlogDencane.ExecuteNonQuery()
            If uspUpisSlogDencane.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogDencane!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogDencane.Dispose()
        End Try

    End Sub
    Friend Sub eUpisSlogDencane(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, _
                                ByVal _StanicaUnosa As String, ByVal _DencanoStavka As Int32, _
                                ByVal _Tarife As Int32, ByVal _StvMasa As Int32, ByVal _RacMasa As Int32, _
                                ByVal _Tip As Int32, ByVal _Komada As Int32, _
                                ByVal _Iznos As Decimal, ByVal _Valuta As String, _
                                ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogDencane As New SqlClient.SqlCommand("dbo.espUpisSlogDencane", DbVeza) 'roba
        uspUpisSlogDencane.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inDencanoStavka As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inDencanoStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "DencanoStavka", DataRowVersion.Current, _DencanoStavka))

        Dim inTarife As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inTarife", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Tarife", DataRowVersion.Current, _Tarife))
        Dim inStvMasa As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inStvMasa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "StvMasa", DataRowVersion.Current, _StvMasa))
        Dim inRacMasa As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inRacMasa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RacMasa", DataRowVersion.Current, _RacMasa))
        Dim inTip As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inTip", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Tip", DataRowVersion.Current, _Tip))
        Dim inKomada As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inKomada", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Komada", DataRowVersion.Current, _Komada))
        Dim inIznos As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "Iznos", DataRowVersion.Current, _Iznos))
        Dim inValuta As SqlClient.SqlParameter = uspUpisSlogDencane.Parameters.Add(New SqlClient.SqlParameter("@inValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Valuta", DataRowVersion.Current, _Valuta))

        uspUpisSlogDencane.Transaction = ipTrans

        Try
            uspUpisSlogDencane.ExecuteNonQuery()
            If uspUpisSlogDencane.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogDencane!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogDencane.Dispose()
        End Try

    End Sub


    Friend Sub eUpisSlogNaknada(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _NaknadeStavka As Int16, _
                               ByVal _SifraNaknade As String, ByVal _IvicniBroj As String, ByVal _Iznos As Decimal, ByVal _Valuta As String, ByVal _Kolicina As Int32, ByVal _DanCas As Int32, ByVal _Placanje As String, ByVal _Vrsta As String, _
                               ByRef opPovVrednost As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogNaknade As New SqlClient.SqlCommand("dbo.espUpisSlogNaknade", DbVeza)
        uspUpisSlogNaknade.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inNaknadeStavka As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inNaknadeStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NaknadeStavka", DataRowVersion.Current, _NaknadeStavka))
        Dim inSifraNaknade As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inSifraNaknade", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraNaknade", DataRowVersion.Current, _SifraNaknade))
        Dim inIvicniBroj As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIvicniBroj", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "IvicniBroj", DataRowVersion.Current, _IvicniBroj))

        Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Iznos", DataRowVersion.Current, _Iznos))
        'Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "Iznos", DataRowVersion.Current, _Iznos))

        'Dim inPojedinacna As SqlClient.SqlParameter = uspUpisCena.Parameters.Add(New SqlClient.SqlParameter("@inPojedinacna", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pojedinacna", DataRowVersion.Current, CenaPojedinacna))

        '        Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal))  'Decimal
        'inIznos.Direction = ParameterDirection.Input
        'inIznos.Size = 9
        'inIznos.Precision = 12
        'inIznos.Scale = 2

        Dim inValuta As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Valuta", DataRowVersion.Current, _Valuta))
        Dim inKolicina As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inKolicina", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Kolicina", DataRowVersion.Current, _Kolicina))
        Dim inDanCas As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inDanCas", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "DanCas", DataRowVersion.Current, _DanCas))
        Dim inPlacanje As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inPlacanje", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Placanje", DataRowVersion.Current, _Placanje))
        Dim inVrsta As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inVrsta", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Vrsta", DataRowVersion.Current, _Vrsta))

        uspUpisSlogNaknade.Transaction = ipTrans

        Try
            uspUpisSlogNaknade.ExecuteNonQuery()
            If uspUpisSlogNaknade.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogNaknade!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogNaknade.Dispose()
        End Try

    End Sub

    Friend Sub UpisSlogNaknada(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, ByVal _NaknadeStavka As Int16, _
                               ByVal _SifraNaknade As String, ByVal _IvicniBroj As String, ByVal _Iznos As Decimal, ByVal _Valuta As String, ByVal _Kolicina As Int32, ByVal _DanCas As Int32, ByVal _Placanje As String, ByVal _Vrsta As String, _
                               ByRef opPovVrednost As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogNaknade As New SqlClient.SqlCommand("dbo.spUpisSlogNaknade", DbVeza)
        uspUpisSlogNaknade.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inNaknadeStavka As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inNaknadeStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NaknadeStavka", DataRowVersion.Current, _NaknadeStavka))
        Dim inSifraNaknade As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inSifraNaknade", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraNaknade", DataRowVersion.Current, _SifraNaknade))
        Dim inIvicniBroj As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIvicniBroj", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "IvicniBroj", DataRowVersion.Current, _IvicniBroj))

        Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Iznos", DataRowVersion.Current, _Iznos))
        'Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "Iznos", DataRowVersion.Current, _Iznos))

        'Dim inPojedinacna As SqlClient.SqlParameter = uspUpisCena.Parameters.Add(New SqlClient.SqlParameter("@inPojedinacna", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pojedinacna", DataRowVersion.Current, CenaPojedinacna))

        '        Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal))  'Decimal
        'inIznos.Direction = ParameterDirection.Input
        'inIznos.Size = 9
        'inIznos.Precision = 12
        'inIznos.Scale = 2

        Dim inValuta As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Valuta", DataRowVersion.Current, _Valuta))
        Dim inKolicina As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inKolicina", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Kolicina", DataRowVersion.Current, _Kolicina))
        Dim inDanCas As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inDanCas", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "DanCas", DataRowVersion.Current, _DanCas))
        Dim inPlacanje As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inPlacanje", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Placanje", DataRowVersion.Current, _Placanje))
        Dim inVrsta As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inVrsta", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Vrsta", DataRowVersion.Current, _Vrsta))

        uspUpisSlogNaknade.Transaction = ipTrans

        Try
            uspUpisSlogNaknade.ExecuteNonQuery()
            If uspUpisSlogNaknade.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogNaknade!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogNaknade.Dispose()
        End Try

    End Sub
    Friend Sub UpisTrzNalepnice(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, ByVal _UlNalepnica As Int32, ByVal _IzNalepnica As Int32, ByRef opPovVrednost As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisTrzNalepnice As New SqlClient.SqlCommand("dbo.spUpisTrzNalepnice", DbVeza)
        uspUpisTrzNalepnice.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inUlNalepnica As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@inUlNalepnica", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlaznaNalepnica", DataRowVersion.Current, _UlNalepnica))
        Dim inIzNalepnica As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@inIzNalepnica", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzlaznaNalepnica", DataRowVersion.Current, _IzNalepnica))

        uspUpisTrzNalepnice.Transaction = ipTrans

        Try
            uspUpisTrzNalepnice.ExecuteNonQuery()
            If uspUpisTrzNalepnice.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u ZsTrzNalepnice!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisTrzNalepnice.Dispose()
        End Try
    End Sub
    Friend Sub UpdateTrzNalepnice(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, ByVal _UlNalepnica As Int32, ByVal _IzNalepnica As Int32, ByRef opPovVrednost As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisTrzNalepnice As New SqlClient.SqlCommand("spUpdateNalepnice", DbVeza)
        uspUpisTrzNalepnice.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inUlNalepnica As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@inUlaz", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlaznaNalepnica", DataRowVersion.Current, _UlNalepnica))
        Dim inIzNalepnica As SqlClient.SqlParameter = uspUpisTrzNalepnice.Parameters.Add(New SqlClient.SqlParameter("@inIzlaz", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzlaznaNalepnica", DataRowVersion.Current, _IzNalepnica))

        uspUpisTrzNalepnice.Transaction = ipTrans

        Try
            uspUpisTrzNalepnice.ExecuteNonQuery()
            If uspUpisTrzNalepnice.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u ZsTrzNalepnice!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisTrzNalepnice.Dispose()
        End Try
    End Sub
    Friend Sub UpdateTrz(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, _
                         ByVal _RecID As Int32, ByVal _StanicaUnosa As String, _
                         ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                         ByVal _BrojVoza2 As Int32, ByVal _SatVoza2 As String, ByVal _Najava2 As String, _
                         ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpdateTrz As New SqlClient.SqlCommand("spUpdateTrz", DbVeza)
        uspUpdateTrz.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        'recid
        'stanica

        Dim inRecID As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _RecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inIzlazniPrelaz As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@inIzlazniPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))
        Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza2", DataRowVersion.Current, _BrojVoza2))
        Dim inSatVoza As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza2", DataRowVersion.Current, _SatVoza2))
        Dim inNajava As SqlClient.SqlParameter = uspUpdateTrz.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava", DataRowVersion.Current, _Najava2))
        '--------------------------------------------------------------------------------------------------------
        uspUpdateTrz.Transaction = ipTrans
        Try
            uspUpdateTrz.ExecuteNonQuery()

            If uspUpdateTrz.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            End If
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpdateTrz.Dispose()
        End Try

    End Sub

    Friend Sub UpisDolazecegVoza(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal mAkcija2 As String, _
                                 ByVal _tb1 As String, ByRef opPovVrednost As String)

        Dim uspUpisVoz As New SqlClient.SqlCommand("dbo.spPreuzmiVoz", DbVeza)
        uspUpisVoz.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisVoz.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisVoz.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        Dim inAkcija2 As SqlClient.SqlParameter = uspUpisVoz.Parameters.Add(New SqlClient.SqlParameter("@inAkcija2", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija2))
        Dim inRed As SqlClient.SqlParameter = uspUpisVoz.Parameters.Add(New SqlClient.SqlParameter("@inRed", SqlDbType.Char, 262, ParameterDirection.Input, False, 0, 0, "IndBrojKola", DataRowVersion.Current, _tb1))

        uspUpisVoz.Transaction = ipTrans

        Try
            uspUpisVoz.ExecuteNonQuery()
            If uspUpisVoz.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogKola!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisVoz.Dispose()
        End Try

    End Sub

    Friend Sub UpisVoza2Sql(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal mAkcija2 As String, _
                                 ByVal _tb1 As String, ByRef opPovVrednost As String)

        Dim uspUpisVoz As New SqlClient.SqlCommand("dbo.spPreuzmiVoz", DbVeza)
        uspUpisVoz.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisVoz.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisVoz.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        Dim inAkcija2 As SqlClient.SqlParameter = uspUpisVoz.Parameters.Add(New SqlClient.SqlParameter("@inAkcija2", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija2))
        Dim inRed As SqlClient.SqlParameter = uspUpisVoz.Parameters.Add(New SqlClient.SqlParameter("@inRed", SqlDbType.Char, 262, ParameterDirection.Input, False, 0, 0, "IndBrojKola", DataRowVersion.Current, _tb1))

        uspUpisVoz.Transaction = ipTrans

        Try
            uspUpisVoz.ExecuteNonQuery()
            If uspUpisVoz.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogKola!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisVoz.Dispose()
        End Try

    End Sub
    Friend Sub VozUSql(ByVal ipTrans As SqlTransaction, ByRef opPovVrednost As String)

        Dim uspUpisVoz As New SqlClient.SqlCommand("radnik.P1_676", DbVeza)
        uspUpisVoz.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisVoz.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        uspUpisVoz.Transaction = ipTrans

        Try
            uspUpisVoz.ExecuteNonQuery()
            If uspUpisVoz.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogKola!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisVoz.Dispose()
        End Try
    End Sub
    Friend Sub UpisSlogRobaDec(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                                ByVal _mKolaStavka As Int16, ByVal _mRobaStavka As Int16, ByVal _NHM As String, ByVal _R As String, _
                                ByVal _SMasaDec As Decimal, ByVal _SMasa As Int32, ByVal _RID As Int16, ByVal _UtiTip As String, ByVal _UtiIB As String, _
                                ByVal _UtiTara As Int32, ByVal _UtiRaster As Decimal, ByVal _UtiNHM As String, _
                                ByVal _UtiPredajniList As String, ByVal _UtiBrPlombe As String, _
                                ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogRoba As New SqlClient.SqlCommand("dbo.spUpisSlogRobaDec", DbVeza) 'roba
        uspUpisSlogRoba.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inKolaStavka As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inKolaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "KolaStavka", DataRowVersion.Current, _mKolaStavka))
        Dim inRobaStavka As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRobaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RobaStavka", DataRowVersion.Current, _mRobaStavka))
        Dim inNHM As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inNHM", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "NHM", DataRowVersion.Current, _NHM))
        Dim inR As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inR", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "NHMRazred", DataRowVersion.Current, _R))
        Dim inSMasaDec As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inSMasaDec", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "SMasaDec", DataRowVersion.Current, _SMasaDec))
        Dim inSMasa As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inSMasa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SMasa", DataRowVersion.Current, _SMasa))
        Dim inRID As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRID", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "RID", DataRowVersion.Current, _RID))
        Dim inUtiTip As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiTip", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "UtiTip", DataRowVersion.Current, _UtiTip))
        Dim inUtiIB As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiIB", SqlDbType.Char, 11, ParameterDirection.Input, False, 0, 0, "UtiIB", DataRowVersion.Current, _UtiIB))
        Dim inUtiTara As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiTara", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UtiTara", DataRowVersion.Current, _UtiTara))
        Dim inUtiRaster As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiRaster", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "UtiRaster", DataRowVersion.Current, _UtiRaster))
        Dim inUtiNHM As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiNHM", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "UtiNHM", DataRowVersion.Current, _UtiNHM))
        Dim inUtiPredajniList As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiPredajniList", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "UtiPredajniList", DataRowVersion.Current, _UtiPredajniList))
        Dim inUtiBrPlombe As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiBrPlombe", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "UtiBrPlombe", DataRowVersion.Current, _UtiBrPlombe))

        'nastaviti do kraja

        uspUpisSlogRoba.Transaction = ipTrans

        Try
            uspUpisSlogRoba.ExecuteNonQuery()
            If uspUpisSlogRoba.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogKola!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogRoba.Dispose()
        End Try

    End Sub
    Friend Sub eUpisSlogRobaDec(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                                ByVal _mKolaStavka As Int16, ByVal _mRobaStavka As Int16, ByVal _NHM As String, ByVal _R As String, _
                                ByVal _SMasaDec As Decimal, ByVal _SMasa As Int32, ByVal _RID As Int16, ByVal _UtiTip As String, ByVal _UtiIB As String, _
                                ByVal _UtiTara As Int32, ByVal _UtiRaster As Decimal, ByVal _UtiNHM As String, _
                                ByVal _UtiPredajniList As String, ByVal _UtiBrPlombe As String, _
                                ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If


        If _mKolaStavka = 14 Then
            MsgBox("stop")
        End If

        Dim uspUpisSlogRoba As New SqlClient.SqlCommand("dbo.espUpisSlogRobaDec", DbVeza) 'roba
        uspUpisSlogRoba.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inKolaStavka As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inKolaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "KolaStavka", DataRowVersion.Current, _mKolaStavka))
        Dim inRobaStavka As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRobaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RobaStavka", DataRowVersion.Current, _mRobaStavka))
        Dim inNHM As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inNHM", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "NHM", DataRowVersion.Current, _NHM))
        Dim inR As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inR", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "NHMRazred", DataRowVersion.Current, _R))
        Dim inSMasaDec As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inSMasaDec", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "SMasaDec", DataRowVersion.Current, _SMasaDec))
        Dim inSMasa As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inSMasa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SMasa", DataRowVersion.Current, _SMasa))
        Dim inRID As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRID", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "RID", DataRowVersion.Current, _RID))
        Dim inUtiTip As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiTip", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "UtiTip", DataRowVersion.Current, _UtiTip))
        Dim inUtiIB As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiIB", SqlDbType.Char, 11, ParameterDirection.Input, False, 0, 0, "UtiIB", DataRowVersion.Current, _UtiIB))
        Dim inUtiTara As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiTara", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UtiTara", DataRowVersion.Current, _UtiTara))
        Dim inUtiRaster As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiRaster", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "UtiRaster", DataRowVersion.Current, _UtiRaster))
        Dim inUtiNHM As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiNHM", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "UtiNHM", DataRowVersion.Current, _UtiNHM))
        Dim inUtiPredajniList As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiPredajniList", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "UtiPredajniList", DataRowVersion.Current, _UtiPredajniList))
        Dim inUtiBrPlombe As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inUtiBrPlombe", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "UtiBrPlombe", DataRowVersion.Current, _UtiBrPlombe))

        'nastaviti do kraja

        uspUpisSlogRoba.Transaction = ipTrans

        Try
            uspUpisSlogRoba.ExecuteNonQuery()
            'If uspUpisSlogRoba.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogRoba!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogRoba.Dispose()
        End Try

    End Sub

    Friend Sub UpdSlogKalk(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _RecID As Int32, ByVal _StanicaUnosa As String, _
                           ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, ByVal _BrojPrispeca As Int32, _
                           ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                           ByVal _BrojVoza As Int32, ByVal _SatVoza As String, ByVal _BrojVoza2 As Int32, ByVal _SatVoza2 As String, _
                           ByVal _Tarifa As String, ByVal _Ugovor As String, _
                           ByVal _UkupnoKola As Int32, ByVal _CarStanica As String, ByVal _CarStanicaStart As String, ByVal _TLSumaUPDin As Decimal, _
                           ByRef opPovVrednost As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If


        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpdSlogKalkEx3New", DbVeza)
        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpdSlogKalkEx2", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, _RecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumUlaza))
        'Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))
        Dim inPrispece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrispece", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _BrojPrispeca))
        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))
        Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))
        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inBrojVoza2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza2", DataRowVersion.Current, _BrojVoza2))
        Dim inSatVoza2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza2", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza2", DataRowVersion.Current, _SatVoza2))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        Dim inTLSumaUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUpDin", DataRowVersion.Current, _TLSumaUPDin))
        '--------------------------------------------------------------------------------------------------------

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                ''opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub
    Friend Sub UpdSlogKalkNew(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _RecID As Int32, ByVal _StanicaUnosa As String, _
                       ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, ByVal _BrojPrispeca As Int32, _
                       ByVal _PrRbb As Int32, ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                       ByVal _BrojVoza As Int32, ByVal _SatVoza As String, ByVal _BrojVoza2 As Int32, ByVal _SatVoza2 As String, _
                       ByVal _Tarifa As String, ByVal _Ugovor As String, _
                       ByVal _UkupnoKola As Int32, ByVal _CarStanica As String, ByVal _CarStanicaStart As String, ByVal _TLSumaUPDin As Decimal, _
                       ByRef opPovVrednost As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If


        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpdSlogKalkEx2New", DbVeza)
        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpdSlogKalkEx2", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, _RecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumUlaza))
        'Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))
        Dim inRbb As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrRbb", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrRbb", DataRowVersion.Current, _PrRbb))
        Dim inPrispece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrispece", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _BrojPrispeca))
        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))
        Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))
        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inBrojVoza2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza2", DataRowVersion.Current, _BrojVoza2))
        Dim inSatVoza2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza2", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza2", DataRowVersion.Current, _SatVoza2))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        Dim inTLSumaUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUpDin", DataRowVersion.Current, _TLSumaUPDin))
        '--------------------------------------------------------------------------------------------------------

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                ''opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub

    Friend Sub UpdSlogKalk1(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _RecID As Int32, ByVal _StanicaUnosa As String, _
                            ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, ByVal _BrojPrispeca As Int32, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                            ByVal _BrojVoza As Int32, ByVal _SatVoza As String, ByVal _BrojVoza2 As Int32, ByVal _SatVoza2 As String, _
                            ByVal _Tarifa As String, ByVal _Ugovor As String, _
                            ByVal _UkupnoKola As Int32, ByVal _CarStanica As String, ByVal _CarStanicaStart As String, _
                            ByRef opPovVrednost As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpdSlogKalkEx1", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, _RecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))
        Dim inPrispece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrispece", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _BrojPrispeca))
        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))
        Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))
        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inBrojVoza2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza2", DataRowVersion.Current, _BrojVoza2))
        Dim inSatVoza2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza2", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza2", DataRowVersion.Current, _SatVoza2))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        '--------------------------------------------------------------------------------------------------------

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                ''opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub

    Friend Sub UpisSlogKalkPlus(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal mopRecID As Int32, ByVal Stanica As String, ByVal mCarPost As String, _
                                ByVal Polje1 As String, ByVal Polje2 As String, ByVal Polje3 As String, ByVal Polje4 As String, ByVal Polje5 As Int32, _
                                ByVal Polje6 As Int32, ByVal Polje7 As Int32, ByVal Polje8 As String, ByVal Polje9 As String, ByVal Polje10 As Int16, ByVal Polje11 As Date, _
                                ByRef opPovVrednost As String)
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalkPlus As New SqlClient.SqlCommand("SpUpisSlogKalkPlus", DbVeza)
        uspUpisSlogKalkPlus.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inStanica As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, Stanica))
        Dim inCarPost As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inCarPost", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "CarPOst", DataRowVersion.Current, mCarPost))
        Dim inPolje1 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje1", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Polje1", DataRowVersion.Current, Polje1))
        Dim inPolje2 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje2", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Polje2", DataRowVersion.Current, Polje2))
        Dim inPolje3 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje3", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Polje3", DataRowVersion.Current, Polje3))
        Dim inPolje4 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje4", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Polje4", DataRowVersion.Current, Polje4))
        Dim inPolje5 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje5", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Polje5", DataRowVersion.Current, Polje5))
        Dim inPolje6 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje6", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Polje6", DataRowVersion.Current, Polje6))
        Dim inPolje7 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje7", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Polje7", DataRowVersion.Current, Polje7))
        Dim inPolje8 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje8", SqlDbType.VarChar, 30, ParameterDirection.Input, False, 0, 0, "Polje8", DataRowVersion.Current, Polje8))
        Dim inPolje9 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje9", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "Polje9", DataRowVersion.Current, Polje9))
        Dim inPolje10 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje10", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "Polje10", DataRowVersion.Current, Polje10))
        Dim inPolje11 As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inPolje11", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, False, 0, 0, "Polje11", DataRowVersion.Current, Polje11))
        Dim inRecID As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mopRecID))

        'Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))
        'Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        'Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        'Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalkPlus.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        ''--------------------------------------------------------------------------------------------------------

        uspUpisSlogKalkPlus.Transaction = ipTrans

        Try
            uspUpisSlogKalkPlus.ExecuteNonQuery()
            If uspUpisSlogKalkPlus.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                ''opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalkPlus.Dispose()
        End Try

    End Sub

    Friend Sub UpisSlogKalk2(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, _
                            ByVal _DatumOtp As DateTime, ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, _
                            ByVal _DatumPr As DateTime, ByVal _BrojVoza As Int32, ByVal _SatVoza As String, _
                            ByVal _Najava As String, ByVal _NajavaKola As Int16, ByVal _Tarifa As String, _
                            ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, _
                            ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                            ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, _
                            ByVal _FrNaknade As String, ByVal _FrDoPrelaza As String, ByVal _Incoterms As String, _
                            ByVal _IsporukaVal As String, ByVal _Isporuka As Decimal, ByVal _PouzeceVal As String, _
                            ByVal _Pouzece As Decimal, ByVal _VrednostRobeVal As String, ByVal _VrednostRobe As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, ByVal _TLSumaUpDin As Decimal, _
                            ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, _
                            ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                            ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _CarStanica As String, ByVal _CarStanicaStart As String, ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, _
                            ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, _
                            ByVal _CarDatum As Date, ByVal _CarAgent As String, _
                            ByVal _CarXml As String, ByVal _Server As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpisSlogKalk2", DbVeza)
        ''Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spUpisSlogKalk", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        'recid
        'stanica
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inObrGodina As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "ObrGodina", DataRowVersion.Current, _mObrGodina))
        Dim inObrMesec As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "ObrMesec", DataRowVersion.Current, _mObrMesec))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))
        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))
        Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))

        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inNajava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava", DataRowVersion.Current, _Najava))
        Dim inNajavaKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola", DataRowVersion.Current, _NajavaKola))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))

        'novo
        Dim inPosiljalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPosiljalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Posiljalac", DataRowVersion.Current, _Posiljalac))
        Dim inPlatilacFRR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacFRR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacFRR", DataRowVersion.Current, _PlatilacFRR))
        Dim inPrimalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrimalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Primalac", DataRowVersion.Current, _Primalac))
        Dim inPlatilacNFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacNFR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacNFR", DataRowVersion.Current, _PlatilacNFR))

        Dim inVrPos As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPos", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPos", DataRowVersion.Current, _VrPos))
        Dim inPrevoz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrevoz", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Prevoz", DataRowVersion.Current, _Prevoz))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, _Saobracaj))
        Dim inVrSao As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrSao", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "VrSao", DataRowVersion.Current, _VrSao))
        Dim inVrPrevoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPrevoza", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPrevoza", DataRowVersion.Current, _VrPrevoza))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))

        'novo
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inFrDoPrelaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrDoPrelaza", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "FrDoPrelaza", DataRowVersion.Current, _FrDoPrelaza))
        Dim inIncoterms As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIncoterms", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Incoterms", DataRowVersion.Current, _Incoterms))
        Dim inIsporukaVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporukaVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "IsporukaVal", DataRowVersion.Current, _IsporukaVal))
        Dim inIsporuka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporuka", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Isporuka", DataRowVersion.Current, _Isporuka))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim inVrednostRobeVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobeVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "VrednostRobeVal", DataRowVersion.Current, _VrednostRobeVal))
        Dim inVrednostRobe As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobe", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VrednostRobe", DataRowVersion.Current, _VrednostRobe))

        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        '
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLSumaUPdin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUpDin", DataRowVersion.Current, _TLSumaUpDin))

        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        '
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        '
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))

        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))
        '--------------------------------------------------------------------------------------------------------
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        Dim inCarPrimalacPIB As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacPIB", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarPrimalacPIB", DataRowVersion.Current, _CarPrimalacPIB))
        Dim inCarPrimalacNaziv As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacNaziv", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacNaziv", DataRowVersion.Current, _CarPrimalacNaziv))
        Dim inCarPrimalacSediste As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacSediste", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacSediste", DataRowVersion.Current, _CarPrimalacSediste))
        Dim inCarPrimalacZemlja As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacZemlja", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarPrimalacZemlja", DataRowVersion.Current, _CarPrimalacZemlja))
        Dim inCarValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarValuta", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarValuta", DataRowVersion.Current, _CarValuta))
        Dim inCarFaktura As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarFaktura", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 2, "CarFaktura", DataRowVersion.Current, _CarFaktura))
        Dim inCarBrFakture As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarBrFakture", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "CarBrojFakture", DataRowVersion.Current, _CarBrojFakture))
        Dim inCarDokumenti As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDokumenti", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "CarDokumenti", DataRowVersion.Current, _CarDokumenti))
        Dim inCarKnjiga As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarKnjiga", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarKnjiga", DataRowVersion.Current, _CarKnjiga))
        Dim inCarDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "CarDatum", DataRowVersion.Current, _CarDatum))
        Dim inCarAgent As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarAgent", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarAgent", DataRowVersion.Current, _CarAgent))
        Dim inCarXml As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarXml", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "CarXml", DataRowVersion.Current, _CarXml))
        Dim inServer As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inServer", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Server", DataRowVersion.Current, _Server))
        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub
    Friend Sub UpisSlogKalk2New(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, _
                            ByVal _DatumOtp As DateTime, ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _PrRbb As Int32, ByVal _tbBrojPr As Int32, _
                            ByVal _DatumPr As DateTime, ByVal _BrojVoza As Int32, ByVal _SatVoza As String, _
                            ByVal _Najava As String, ByVal _NajavaKola As Int16, ByVal _Tarifa As String, _
                            ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, _
                            ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                            ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, _
                            ByVal _FrNaknade As String, ByVal _FrDoPrelaza As String, ByVal _Incoterms As String, _
                            ByVal _IsporukaVal As String, ByVal _Isporuka As Decimal, ByVal _PouzeceVal As String, _
                            ByVal _Pouzece As Decimal, ByVal _VrednostRobeVal As String, ByVal _VrednostRobe As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, ByVal _TLSumaUpDin As Decimal, _
                            ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, _
                            ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                            ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _CarStanica As String, ByVal _CarStanicaStart As String, ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, _
                            ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, _
                            ByVal _CarDatum As Date, ByVal _CarAgent As String, _
                            ByVal _CarXml As String, ByVal _Server As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpisSlogKalk2New", DbVeza)
        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpisSlogKalk2", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        'recid
        'stanica
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inObrGodina As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "ObrGodina", DataRowVersion.Current, _mObrGodina))
        Dim inObrMesec As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "ObrMesec", DataRowVersion.Current, _mObrMesec))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))
        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))
        Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrRbb As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrRbb", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrRbb", DataRowVersion.Current, _PrRbb))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))

        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inNajava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava", DataRowVersion.Current, _Najava))
        Dim inNajavaKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola", DataRowVersion.Current, _NajavaKola))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))

        'novo
        Dim inPosiljalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPosiljalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Posiljalac", DataRowVersion.Current, _Posiljalac))
        Dim inPlatilacFRR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacFRR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacFRR", DataRowVersion.Current, _PlatilacFRR))
        Dim inPrimalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrimalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Primalac", DataRowVersion.Current, _Primalac))
        Dim inPlatilacNFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacNFR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacNFR", DataRowVersion.Current, _PlatilacNFR))

        Dim inVrPos As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPos", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPos", DataRowVersion.Current, _VrPos))
        Dim inPrevoz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrevoz", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Prevoz", DataRowVersion.Current, _Prevoz))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, _Saobracaj))
        Dim inVrSao As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrSao", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "VrSao", DataRowVersion.Current, _VrSao))
        Dim inVrPrevoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPrevoza", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPrevoza", DataRowVersion.Current, _VrPrevoza))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))

        'novo
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inFrDoPrelaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrDoPrelaza", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "FrDoPrelaza", DataRowVersion.Current, _FrDoPrelaza))
        Dim inIncoterms As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIncoterms", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Incoterms", DataRowVersion.Current, _Incoterms))
        Dim inIsporukaVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporukaVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "IsporukaVal", DataRowVersion.Current, _IsporukaVal))
        Dim inIsporuka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporuka", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Isporuka", DataRowVersion.Current, _Isporuka))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim inVrednostRobeVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobeVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "VrednostRobeVal", DataRowVersion.Current, _VrednostRobeVal))
        Dim inVrednostRobe As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobe", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VrednostRobe", DataRowVersion.Current, _VrednostRobe))

        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        '
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLSumaUPdin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUpDin", DataRowVersion.Current, _TLSumaUpDin))

        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        '
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        '
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))

        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))
        '--------------------------------------------------------------------------------------------------------
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        Dim inCarPrimalacPIB As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacPIB", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarPrimalacPIB", DataRowVersion.Current, _CarPrimalacPIB))
        Dim inCarPrimalacNaziv As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacNaziv", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacNaziv", DataRowVersion.Current, _CarPrimalacNaziv))
        Dim inCarPrimalacSediste As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacSediste", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacSediste", DataRowVersion.Current, _CarPrimalacSediste))
        Dim inCarPrimalacZemlja As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacZemlja", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarPrimalacZemlja", DataRowVersion.Current, _CarPrimalacZemlja))
        Dim inCarValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarValuta", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarValuta", DataRowVersion.Current, _CarValuta))
        Dim inCarFaktura As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarFaktura", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 2, "CarFaktura", DataRowVersion.Current, _CarFaktura))
        Dim inCarBrFakture As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarBrFakture", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "CarBrojFakture", DataRowVersion.Current, _CarBrojFakture))
        Dim inCarDokumenti As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDokumenti", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "CarDokumenti", DataRowVersion.Current, _CarDokumenti))
        Dim inCarKnjiga As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarKnjiga", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarKnjiga", DataRowVersion.Current, _CarKnjiga))
        Dim inCarDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "CarDatum", DataRowVersion.Current, _CarDatum))
        Dim inCarAgent As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarAgent", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarAgent", DataRowVersion.Current, _CarAgent))
        Dim inCarXml As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarXml", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "CarXml", DataRowVersion.Current, _CarXml))
        Dim inServer As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inServer", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Server", DataRowVersion.Current, _Server))
        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub

    Friend Sub UpisSlogKalkIzvozSt2(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, _
                            ByVal _DatumOtp As DateTime, ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, _
                            ByVal _DatumPr As DateTime, ByVal _BrojVoza As Int32, ByVal _SatVoza As String, _
                            ByVal _Najava As String, ByVal _NajavaKola As Int16, ByVal _Tarifa As String, _
                            ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, _
                            ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                            ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, _
                            ByVal _FrNaknade As String, ByVal _FrDoPrelaza As String, ByVal _Incoterms As String, _
                            ByVal _IsporukaVal As String, ByVal _Isporuka As Decimal, ByVal _PouzeceVal As String, _
                            ByVal _Pouzece As Decimal, ByVal _VrednostRobeVal As String, ByVal _VrednostRobe As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, ByVal _TLSumaFRDin As Decimal, _
                            ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, _
                            ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                            ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _CarStanica As String, ByVal _CarStanicaStart As String, ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, _
                            ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, _
                            ByVal _CarDatum As Date, ByVal _CarAgent As String, _
                            ByVal _CarXml As String, ByVal _Server As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("espUpisSlogKalkIzvoz2", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        'recid
        'stanica
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inObrGodina As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "ObrGodina", DataRowVersion.Current, _mObrGodina))
        Dim inObrMesec As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "ObrMesec", DataRowVersion.Current, _mObrMesec))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))

        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))

        '--- razlika u popunjavanju datuma izlaza za granicu i mrezu -----------------------------------------------
        ' staro: Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        If GranicnaStanica = "D" Then
            Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, Today()))
        Else
            Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, Today.AddDays(-10)))
        End If
        ' ----------------------------------------------------------------------------------------------------------

        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))

        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inNajava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava", DataRowVersion.Current, _Najava))
        Dim inNajavaKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola", DataRowVersion.Current, _NajavaKola))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))

        'novo
        Dim inPosiljalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPosiljalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Posiljalac", DataRowVersion.Current, _Posiljalac))
        Dim inPlatilacFRR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacFRR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacFRR", DataRowVersion.Current, _PlatilacFRR))
        Dim inPrimalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrimalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Primalac", DataRowVersion.Current, _Primalac))
        Dim inPlatilacNFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacNFR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacNFR", DataRowVersion.Current, _PlatilacNFR))

        Dim inVrPos As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPos", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPos", DataRowVersion.Current, _VrPos))
        Dim inPrevoz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrevoz", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Prevoz", DataRowVersion.Current, _Prevoz))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, _Saobracaj))
        Dim inVrSao As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrSao", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "VrSao", DataRowVersion.Current, _VrSao))
        Dim inVrPrevoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPrevoza", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPrevoza", DataRowVersion.Current, _VrPrevoza))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))

        'novo
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inFrDoPrelaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrDoPrelaza", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "FrDoPrelaza", DataRowVersion.Current, _FrDoPrelaza))
        Dim inIncoterms As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIncoterms", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Incoterms", DataRowVersion.Current, _Incoterms))
        Dim inIsporukaVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporukaVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "IsporukaVal", DataRowVersion.Current, _IsporukaVal))
        Dim inIsporuka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporuka", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Isporuka", DataRowVersion.Current, _Isporuka))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim inVrednostRobeVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobeVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "VrednostRobeVal", DataRowVersion.Current, _VrednostRobeVal))
        Dim inVrednostRobe As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobe", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VrednostRobe", DataRowVersion.Current, _VrednostRobe))

        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        Dim inTLSumaFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFrDin", DataRowVersion.Current, _TLSumaFRDin))
        '
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        '
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        '
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))

        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))
        '--------------------------------------------------------------------------------------------------------
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        Dim inCarPrimalacPIB As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacPIB", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarPrimalacPIB", DataRowVersion.Current, _CarPrimalacPIB))
        Dim inCarPrimalacNaziv As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacNaziv", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacNaziv", DataRowVersion.Current, _CarPrimalacNaziv))
        Dim inCarPrimalacSediste As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacSediste", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacSediste", DataRowVersion.Current, _CarPrimalacSediste))
        Dim inCarPrimalacZemlja As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacZemlja", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarPrimalacZemlja", DataRowVersion.Current, _CarPrimalacZemlja))
        Dim inCarValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarValuta", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarValuta", DataRowVersion.Current, _CarValuta))
        Dim inCarFaktura As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarFaktura", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 2, "CarFaktura", DataRowVersion.Current, _CarFaktura))
        Dim inCarBrFakture As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarBrFakture", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "CarBrojFakture", DataRowVersion.Current, _CarBrojFakture))
        Dim inCarDokumenti As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDokumenti", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "CarDokumenti", DataRowVersion.Current, _CarDokumenti))
        Dim inCarKnjiga As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarKnjiga", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarKnjiga", DataRowVersion.Current, _CarKnjiga))
        Dim inCarDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "CarDatum", DataRowVersion.Current, _CarDatum))
        Dim inCarAgent As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarAgent", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarAgent", DataRowVersion.Current, _CarAgent))
        Dim inCarXml As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarXml", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "CarXml", DataRowVersion.Current, _CarXml))
        Dim inServer As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inServer", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Server", DataRowVersion.Current, _Server))
        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub
    Friend Sub UpisSlogKalkIzvozSt2New(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _OtpRbb As Int32, ByVal _tbBrojOtp As Int32, _
                            ByVal _DatumOtp As DateTime, ByVal _mObrGodina As String, ByVal _mObrMesec As String, ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, _
                            ByVal _DatumPr As DateTime, ByVal _BrojVoza As Int32, ByVal _SatVoza As String, ByVal _Najava As String, ByVal _NajavaKola As Int16, ByVal _Tarifa As String, _
                            ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, ByVal _FrNaknade As String, ByVal _FrDoPrelaza As String, ByVal _Incoterms As String, _
                            ByVal _IsporukaVal As String, ByVal _Isporuka As Decimal, ByVal _PouzeceVal As String, ByVal _Pouzece As Decimal, ByVal _VrednostRobeVal As String, ByVal _VrednostRobe As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, ByVal _TLSumaFRDin As Decimal, ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, _
                            ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, ByVal _Referent1 As String, ByVal _DatumObrade As Date, ByVal _CarStanica As String, ByVal _CarStanicaStart As String, _
                            ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, ByVal _CarDatum As Date, ByVal _CarAgent As String, ByVal _CarXml As String, ByVal _Server As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("espUpisSlogKalkIzvoz2New", DbVeza)
        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("espUpisSlogKalkIzvoz2", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        'recid
        'stanica
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inRbb As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpRbb", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpRbb", DataRowVersion.Current, _OtpRbb))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inObrGodina As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "ObrGodina", DataRowVersion.Current, _mObrGodina))
        Dim inObrMesec As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "ObrMesec", DataRowVersion.Current, _mObrMesec))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))

        Dim inZsIzPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsIzPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsIzPrelaz", DataRowVersion.Current, _IzlazniPrelaz))
        Dim inIzEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "IzEtiketa", DataRowVersion.Current, _IzlaznaNalepnica))

        '--- razlika u popunjavanju datuma izlaza za granicu i mrezu -----------------------------------------------
        ' staro: Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, _DatumIzlaza))
        If GranicnaStanica = "D" Then
            Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, Today()))
        Else
            Dim inDatumIzlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumIzlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumIzlaza", DataRowVersion.Current, Today.AddDays(-10)))
        End If
        ' ----------------------------------------------------------------------------------------------------------

        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))

        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inNajava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava", DataRowVersion.Current, _Najava))
        Dim inNajavaKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola", DataRowVersion.Current, _NajavaKola))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))

        'novo
        Dim inPosiljalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPosiljalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Posiljalac", DataRowVersion.Current, _Posiljalac))
        Dim inPlatilacFRR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacFRR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacFRR", DataRowVersion.Current, _PlatilacFRR))
        Dim inPrimalac As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrimalac", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Primalac", DataRowVersion.Current, _Primalac))
        Dim inPlatilacNFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPlatilacNFR", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PlatilacNFR", DataRowVersion.Current, _PlatilacNFR))

        Dim inVrPos As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPos", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPos", DataRowVersion.Current, _VrPos))
        Dim inPrevoz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrevoz", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Prevoz", DataRowVersion.Current, _Prevoz))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, _Saobracaj))
        Dim inVrSao As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrSao", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "VrSao", DataRowVersion.Current, _VrSao))
        Dim inVrPrevoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrPrevoza", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrPrevoza", DataRowVersion.Current, _VrPrevoza))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))

        'novo
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inFrDoPrelaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrDoPrelaza", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "FrDoPrelaza", DataRowVersion.Current, _FrDoPrelaza))
        Dim inIncoterms As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIncoterms", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Incoterms", DataRowVersion.Current, _Incoterms))
        Dim inIsporukaVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporukaVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "IsporukaVal", DataRowVersion.Current, _IsporukaVal))
        Dim inIsporuka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporuka", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Isporuka", DataRowVersion.Current, _Isporuka))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim inVrednostRobeVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobeVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "VrednostRobeVal", DataRowVersion.Current, _VrednostRobeVal))
        Dim inVrednostRobe As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobe", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VrednostRobe", DataRowVersion.Current, _VrednostRobe))

        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        Dim inTLSumaFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFrDin", DataRowVersion.Current, _TLSumaFRDin))
        '
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        '
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        '
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))

        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))
        '--------------------------------------------------------------------------------------------------------
        Dim inCarStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica", DataRowVersion.Current, _CarStanica))
        Dim inCarStanicaStart As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarStanicaStart", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarStanica2", DataRowVersion.Current, _CarStanicaStart))
        Dim inCarPrimalacPIB As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacPIB", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarPrimalacPIB", DataRowVersion.Current, _CarPrimalacPIB))
        Dim inCarPrimalacNaziv As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacNaziv", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacNaziv", DataRowVersion.Current, _CarPrimalacNaziv))
        Dim inCarPrimalacSediste As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacSediste", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarPrimalacSediste", DataRowVersion.Current, _CarPrimalacSediste))
        Dim inCarPrimalacZemlja As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarPrimalacZemlja", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarPrimalacZemlja", DataRowVersion.Current, _CarPrimalacZemlja))
        Dim inCarValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarValuta", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "CarValuta", DataRowVersion.Current, _CarValuta))
        Dim inCarFaktura As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarFaktura", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 2, "CarFaktura", DataRowVersion.Current, _CarFaktura))
        Dim inCarBrFakture As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarBrFakture", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "CarBrojFakture", DataRowVersion.Current, _CarBrojFakture))
        Dim inCarDokumenti As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDokumenti", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "CarDokumenti", DataRowVersion.Current, _CarDokumenti))
        Dim inCarKnjiga As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarKnjiga", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "CarKnjiga", DataRowVersion.Current, _CarKnjiga))
        Dim inCarDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "CarDatum", DataRowVersion.Current, _CarDatum))
        Dim inCarAgent As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarAgent", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "CarAgent", DataRowVersion.Current, _CarAgent))
        Dim inCarXml As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inCarXml", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "CarXml", DataRowVersion.Current, _CarXml))
        Dim inServer As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inServer", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Server", DataRowVersion.Current, _Server))
        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub

    Friend Sub UpisSlogGP(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                          ByVal _Stavka As Int16, ByVal _Uprava1 As String, ByVal _Uprava2 As String, ByVal _Prelaz As String, _
                          ByRef opPovVrednost As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKola As New SqlClient.SqlCommand("dbo.spUpisSlogGP", DbVeza)
        'Dim uspUpisSlogKola As New SqlClient.SqlCommand("dbo.spUpisSlogKola", DbVeza) 'roba

        uspUpisSlogKola.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inStavka As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Stavka", DataRowVersion.Current, _Stavka))

        Dim inUp1 As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inUp1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Uprava1", DataRowVersion.Current, _Uprava1))
        Dim inUp2 As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inUp2", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Uprava2", DataRowVersion.Current, _Uprava2))
        Dim inPr As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inPr", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Prelaz", DataRowVersion.Current, _Prelaz))

        uspUpisSlogKola.Transaction = ipTrans

        Try
            uspUpisSlogKola.ExecuteNonQuery()
            If uspUpisSlogKola.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogGP!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKola.Dispose()
        End Try

    End Sub

End Module
