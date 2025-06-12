Imports System.Data.SqlClient
Module Upis 
    Friend Sub UpisSlogKalkLokal(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                            ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, ByVal _DatumPr As DateTime, _
                            ByVal _BrojVoza As Int32, ByVal _SatVoza As String, ByVal _Tarifa As String, ByVal _Ugovor As String, _
                            ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                            ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, _
                            ByVal _FrNaknade As String, ByVal _PouzeceVal As String, ByVal _Pouzece As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, _
                            ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                            ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

       
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spUpisSlogKalkLokal", OkpDbVeza)

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
        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))
        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))
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
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))
        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))

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
    Friend Sub bbUpisSlogKalkLokal(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                            ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, ByVal _DatumPr As DateTime, _
                            ByVal _BrojVoza As Int32, ByVal _SatVoza As String, ByVal _Tarifa As String, ByVal _IzborTarife As String, ByVal _Ugovor As String, _
                            ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                            ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, ByVal _NarPosiljka As String, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, _
                            ByVal _FrNaknade As String, ByVal _PouzeceVal As String, ByVal _Pouzece As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, _
                            ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                            ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _UpdRecID As Int32, ByVal _UpdStanicaRecID As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spbbUpisSlogKalkLokal", OkpDbVeza)

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
        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))
        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inIzborTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzborTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Najava2", DataRowVersion.Current, _IzborTarife))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))
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
        Dim inNarPosiljka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNarPosiljka", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "NarPos", DataRowVersion.Current, _NarPosiljka))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))
        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))

        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        '--------------------------------------------------------------------------------------------------------
        Dim inUpdRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUpdRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _UpdRecID))
        Dim inUpdStanicaRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUpdStanicaRecID", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _UpdStanicaRecID))
        '--------------------------------------------------------------------------------------------------------



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
    'Friend Sub bbbUpisSlogKalkLokal(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
    'Friend Sub b3UpisSlogKalkLokal(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
    'Friend Sub b4UpisSlogKalkLokal(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
    'Friend Sub b5UpisSlogKalkLokal(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
    'Friend Sub b7UpisSlogKalkLokal(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
    Friend Sub b8UpisSlogKalkLokal(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                                ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                                ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                                ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, ByVal _DatumPr As DateTime, _
                                ByVal _BrojVoza As Int32, ByVal _SatVoza As String, ByVal _NajavaVoza As String, ByVal _Tarifa As String, ByVal _IzborTarife As String, _
                                ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                                ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                                ByVal _VrSao As String, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, ByVal _NarPosiljka As String, _
                                ByVal _PrevozniPutZS As Int32, ByVal _StanicaVia As String, _
                                ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, _
                                ByVal _IznosPoIzjavi As Decimal, _
                                ByVal _FrRacun As String, _
                                ByVal _FrNaknade As String, ByVal _PouzeceVal As String, ByVal _Pouzece As Decimal, _
                                ByVal _tlValuta As String, _
                                ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, _
                                ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, _
                                ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                                ByVal _TLSumaFRDin As Decimal, ByVal _TLSumaUPDin As Decimal, _
                                ByVal _TLPrevFRDin As Decimal, ByVal _TLPrevUPDin As Decimal, _
                                ByVal _TLNakFRDin As Decimal, ByVal _TLNakUPDin As Decimal, _
                                ByVal _RSumaFR As Decimal, ByVal _RSumaUP As Decimal, _
                                ByVal _RPrevFR As Decimal, ByVal _RPrevUP As Decimal, _
                                ByVal _RNakFR As Decimal, ByVal _RNakUP As Decimal, _
                                ByVal _RSumaFRDin As Decimal, ByVal _RSumaUPDin As Decimal, _
                                ByVal _RPrevFRDin As Decimal, ByVal _RPrevUPDin As Decimal, _
                                ByVal _RNakFRDin As Decimal, ByVal _RNakUPDin As Decimal, _
                                ByVal _TLNakCo82 As Decimal, _
                                ByVal _VrednostRobe As Decimal, _
                                ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                                ByVal _UpdRecID As Int32, ByVal _UpdStanicaRecID As String, _
                                ByRef opRecID As Int32, ByRef opPovVrednost As String)


        'tlSumaFr
        'tlSumaUp
        'tlPrevFr
        'tlPrevUp
        'tlNakFr
        'tlNakUp
        'tlSumaFrDin
        'tlSumaUpDin
        'tlPrevFrDin
        'tlPrevUpDin
        'tlNakFrDin
        'tlNakUpDin
        'rSumaFr
        'rSumaUp
        'rPrevFr
        'rPrevUp
        'rNakFr
        'rNakUp
        'rSumaFrDin
        'rSumaUpDin
        'rPrevFrDin
        'rPrevUpDin
        'rNakFrDin
        'rNakUpDin

        'tlNakCo82                  zbog upisa PDV-a za CO



        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spbbbUpisSlogKalkLokal", OkpDbVeza)
        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spb3UpisSlogKalkLokal", OkpDbVeza)
        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spb4UpisSlogKalkLokal", OkpDbVeza)
        ' za "New" se UserID upisuje u Referent1, a za "Upd" u Referent2

        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("roba1708.spb5UpisSlogKalkLokal", OkpDbVeza)
        ' - biæe dodati:
        '       Predujam   >>> SlogKalk.VrednostRobe        DODAT
        '       TrosUGotFr >>> SlogKalk.RnakFr
        '       TrosUGotUp >>> SlogKalk.RnakUp
        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("roba1708.spb7UpisSlogKalkLokal", OkpDbVeza)
        ' - dodat:
        '       IznosPoIzjavi
        ' 14.05.13 - pri Upd iskljucena izmena datuma prvog unosa, koji ostaje isti, a datum poslednje izmene se upisuje u DatumIzlaza  

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("roba1708.spb8UpisSlogKalkLokal", OkpDbVeza)
        ' - dodat:
        '       NajavaVoza         Char(10) 
        ' 28.01.15 

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
        Dim inPrUprava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "PrUprava", DataRowVersion.Current, _tbUpravaPr))
        Dim inPrStanica As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "PrStanica", DataRowVersion.Current, _tbStanicaPr))
        Dim inPrBroj As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrBroj", DataRowVersion.Current, _tbBrojPr))
        Dim inPrDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "PrDatum", DataRowVersion.Current, _DatumPr))
        Dim inBrojVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inBrojVoza", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "BrojVoza", DataRowVersion.Current, _BrojVoza))
        Dim inSatVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSatVoza", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "SatVoza", DataRowVersion.Current, _SatVoza))
        Dim inNajavaVoza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaVoza", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "NajavaVoza", DataRowVersion.Current, _NajavaVoza))
        Dim inSifraTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraTarife", DataRowVersion.Current, _Tarifa))
        Dim inIzborTarife As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzborTarife", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Najava2", DataRowVersion.Current, _IzborTarife))
        Dim inUgovor As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, _Ugovor))
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
        Dim inNarPosiljka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNarPosiljka", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "NarPos", DataRowVersion.Current, _NarPosiljka))
        Dim inPrevozniPutZs As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPrevozniPutZs", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrevozniPutZs", DataRowVersion.Current, _PrevozniPutZS))
        Dim inStanicaVia As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaVia", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "StanicaRee", DataRowVersion.Current, _StanicaVia))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inIznosPoIzjavi As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIznosPoIzjavi", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "IznosPoIzjavi", DataRowVersion.Current, _IznosPoIzjavi))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))
        Dim inTLSumaFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFrDin", DataRowVersion.Current, _TLSumaFRDin))
        Dim inTLSumaUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUpDin", DataRowVersion.Current, _TLSumaUPDin))
        Dim inTLPrevFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFrDin", DataRowVersion.Current, _TLPrevFRDin))
        Dim inTLPrevUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUpDin", DataRowVersion.Current, _TLPrevUPDin))
        Dim inTLNakFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFrDin", DataRowVersion.Current, _TLNakFRDin))
        Dim inTLNakUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUpDin", DataRowVersion.Current, _TLNakUPDin))
        Dim inRSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaFr", DataRowVersion.Current, _RSumaFR))
        Dim inRSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaUp", DataRowVersion.Current, _RSumaUP))
        Dim inRPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rPrevFr", DataRowVersion.Current, _RPrevFR))
        Dim inRPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rPrevUp", DataRowVersion.Current, _RPrevUP))
        Dim inRNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rNakFr", DataRowVersion.Current, _RNakFR))
        Dim inRNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rNakUp", DataRowVersion.Current, _RNakUP))
        Dim inRSumaFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRSumaFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaFrDin", DataRowVersion.Current, _RSumaFRDin))
        Dim inRSumaUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRSumaUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaUpDin", DataRowVersion.Current, _RSumaUPDin))
        Dim inRPrevFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRPrevFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rPrevFrDin", DataRowVersion.Current, _RPrevFRDin))
        Dim inRPrevUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRPrevUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rPrevUpDin", DataRowVersion.Current, _RPrevUPDin))
        Dim inRNakFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRNakFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rNakFrDin", DataRowVersion.Current, _RNakFRDin))
        Dim inRNakUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRNakUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rNakUpDin", DataRowVersion.Current, _RNakUPDin))

        Dim inTLNakCo82 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakCo82", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakCo82", DataRowVersion.Current, _TLNakCo82))
        Dim inVrednostRobe As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobe", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "VrednostRobe", DataRowVersion.Current, _VrednostRobe))

        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))

        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        '--------------------------------------------------------------------------------------------------------
        Dim inUpdRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUpdRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _UpdRecID))
        Dim inUpdStanicaRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUpdStanicaRecID", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _UpdStanicaRecID))
        '--------------------------------------------------------------------------------------------------------



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




        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim uspUpisSlogKola As New SqlClient.SqlCommand("dbo.spUpisSlogKola", OkpDbVeza) 'roba

        Dim uspUpisSlogKola As New SqlClient.SqlCommand("roba1708.spbUpisSlogKola", OkpDbVeza) 'roba

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

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogRoba As New SqlClient.SqlCommand("dbo.spUpisSlogRoba", OkpDbVeza) 'roba
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

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogDencane As New SqlClient.SqlCommand("dbo.spUpisSlogDencane", OkpDbVeza) 'roba
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

    Friend Sub UpisSlogNaknada(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, ByVal _NaknadeStavka As Int16, _
                               ByVal _SifraNaknade As String, ByVal _IvicniBroj As String, ByVal _Iznos As Decimal, ByVal _Valuta As String, ByVal _Kolicina As Int32, ByVal _DanCas As Int32, ByVal _Placanje As String, ByVal _Vrsta As String, _
                               ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogNaknade As New SqlClient.SqlCommand("dbo.spUpisSlogNaknade", OkpDbVeza)
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

        Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "Iznos", DataRowVersion.Current, _Iznos))
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

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogRoba As New SqlClient.SqlCommand("dbo.spUpisSlogRobaDec", OkpDbVeza) 'roba

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
    Friend Sub UpdSlogKalk(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _RecID As Int32, ByVal _StanicaUnosa As String, _
                           ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                           ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                           ByVal _BrojVoza As Int32, ByVal _SatVoza As String, ByVal _BrojVoza2 As Int32, ByVal _SatVoza2 As String, _
                           ByVal _Tarifa As String, ByVal _Ugovor As String, _
                           ByVal _UkupnoKola As Int32, ByVal _CarStanica As String, ByVal _CarStanicaStart As String, _
                           ByRef opPovVrednost As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("eSpUpdSlogKalk", DbVeza)
        uspUpisSlogKalk.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, _RecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inZsUlPrelaz As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsUlPrelaz", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "ZsUlPrelaz", DataRowVersion.Current, _UlazniPrelaz))
        Dim inUlEtiketa As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUlEtiketa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UlEtiketa", DataRowVersion.Current, _UlaznaNalepnica))
        Dim inDatumUlaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inDatumUlaza", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumUlaza", DataRowVersion.Current, _DatumUlaza))
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
    Friend Sub UpisSlogUTL(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                           ByVal _R1 As String, ByVal _R2 As String, ByVal _R4 As String, ByVal _R5 As String, ByVal _R6 As String, ByVal _R7 As String, _
                           ByVal _R8 As String, ByVal _R9 As String, ByVal _R10 As String, ByVal _R10KB As String, ByVal _R11 As Int32, ByVal _R12a As String, _
                           ByVal _R12b As String, ByVal _R13a As String, ByVal _R13b As Int32, ByVal _R14a As String, ByVal _R14b As String, ByVal _R15 As String, _
                           ByVal _R15a As String, ByVal _R16 As String, ByVal _R17 As Int32, ByVal _R18 As String, ByVal _R19 As String, ByVal _R20a As Int32, _
                           ByVal _R20b As Int32, ByVal _R21_1 As String, ByVal _R22_1 As String, ByVal _R21_2 As String, ByVal _R22_2 As String, _
                           ByVal _R21_3 As String, ByVal _R22_3 As String, ByVal _R21_4 As String, ByVal _R22_4 As String, ByVal _R23_1 As Decimal, _
                           ByVal _R23_2 As Decimal, ByVal _R23_3 As Decimal, ByVal _R23_4 As Decimal, ByVal _R24_1 As Int32, ByVal _R24_2 As Int32, ByVal _R24_3 As Int32, _
                           ByVal _R24_4 As Int32, ByVal _R24Suma As Int32, ByVal _R25TIP_1 As String, ByVal _R25TIP_2 As String, ByVal _R25TIP_3 As String, ByVal _R25TIP_4 As String, _
                           ByVal _R25KOL_1 As Int32, ByVal _R25KOL_2 As Int32, ByVal _R25KOL_3 As Int32, ByVal _R25KOL_4 As Int32, ByVal _R25Suma As Int32, ByVal _R26_1 As Int32, _
                           ByVal _R26_2 As Int32, ByVal _R26_3 As Int32, ByVal _R26_4 As Int32, ByVal _R26Suma As Int32, ByVal _R27 As String, ByVal _R28 As String, ByVal _R29 As String, _
                           ByVal _R30a As String, ByVal _R30b As String, ByVal _R31a As String, ByVal _R32b As String, ByVal _R32 As String, ByVal _R32a As String, ByVal _R33a As String, _
                           ByVal _R33b As Int32, ByVal _R34 As String, ByVal _R35 As String, ByVal _R36 As Int32, ByVal _R37 As String, ByVal _RID As String, ByVal _R41Suma As Int32, ByVal _R42_1 As String, _
                           ByVal _R42_2 As String, ByVal _R42_3 As String, ByVal _R42_4 As String, ByVal _R42_5 As String, ByVal _R43_1 As String, _
                           ByVal _R43_2 As String, ByVal _R43_3 As String, ByVal _R43_4 As String, ByVal _R43_5 As String, ByVal _R44 As String, _
                           ByVal _R44n As String, ByVal _R44i As Decimal, ByVal _R45a As String, ByVal _R45b As String, ByVal _R46 As String, ByVal _R47 As Decimal, ByVal _R48a As String, _
                           ByVal _R48b As String, ByVal _R49 As Decimal, ByVal _R50 As Decimal, ByVal _R51 As Decimal, ByVal _R53 As Int32, ByVal _R54_1 As String, _
                           ByVal _R54_2 As String, ByVal _R54_3 As String, ByVal _R55_1 As Decimal, ByVal _R55_2 As Decimal, ByVal _R55_3 As Decimal, ByVal _R56_1 As Decimal, _
                           ByVal _R56_2 As Decimal, ByVal _R56_3 As Decimal, ByVal _R57_1 As Int32, ByVal _R57_2 As Int32, ByVal _R57_3 As Int32, ByVal _R58 As String, ByVal _R59 As String, _
                           ByVal _R60 As String, ByVal _R61F As Decimal, ByVal _R61U As Decimal, _
                           ByVal _R64F_1 As Decimal, ByVal _R64F_2 As Decimal, ByVal _R64F_3 As Decimal, ByVal _R64F_4 As Decimal, ByVal _R64F_5 As Decimal, ByVal _R64F_6 As Decimal, _
                           ByVal _R62A_1 As String, ByVal _R62A_2 As String, ByVal _R62A_3 As String, ByVal _R62A_4 As String, ByVal _R62A_5 As String, ByVal _R63A As String, _
                           ByVal _R62B_1 As String, ByVal _R62B_2 As String, ByVal _R62B_3 As String, ByVal _R62B_4 As String, ByVal _R62B_5 As String, ByVal _R63B As String, _
                           ByVal _R62C_1 As String, ByVal _R62C_2 As String, ByVal _R62C_3 As String, ByVal _R62C_4 As String, ByVal _R62C_5 As String, ByVal _R63C As String, _
                           ByVal _R64U_1 As Decimal, ByVal _R64U_2 As Decimal, ByVal _R64U_3 As Decimal, ByVal _R64U_4 As Decimal, ByVal _R64U_5 As Decimal, ByVal _R64U_6 As Decimal, _
                           ByVal _R65F As Decimal, ByVal _R65U As Decimal, ByVal _R66a As String, ByVal _R66b As Int32, _
                           ByRef opPovVrednost As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogUTL As New SqlClient.SqlCommand("dbo.spUpisSlogUTL", OkpDbVeza)

        uspUpisSlogUTL.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inR1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R1", DataRowVersion.Current, _R1))
        Dim inR2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR2", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R2", DataRowVersion.Current, _R2))
        Dim inR4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR4", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R4", DataRowVersion.Current, _R4))
        Dim inR5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR5", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R5", DataRowVersion.Current, _R5))
        Dim inR6 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR6", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R6", DataRowVersion.Current, _R6))
        Dim inR7 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR7", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R7", DataRowVersion.Current, _R7))
        Dim inR8 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR8", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R8", DataRowVersion.Current, _R8))
        Dim inR9 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR9", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "R9", DataRowVersion.Current, _R9))
        Dim inR10 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR10", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R1O", DataRowVersion.Current, _R10))
        Dim inR10KB As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR10KB", SqlDbType.Char, 25, ParameterDirection.Input, False, 0, 0, "R10KB", DataRowVersion.Current, _R10KB))
        Dim inR11 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR11", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R11", DataRowVersion.Current, _R11))
        Dim inR12a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR12a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R12a", DataRowVersion.Current, _R12a))
        Dim inR12b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR12b", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R12b", DataRowVersion.Current, _R12b))
        Dim inR13a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR13a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R13a", DataRowVersion.Current, _R13a))
        Dim inR13b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR13b", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R13b", DataRowVersion.Current, _R13b))
        Dim inR14a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR14a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R14a", DataRowVersion.Current, _R14a))
        Dim inR14b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR14b", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R14b", DataRowVersion.Current, _R14b))
        Dim inR15 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR15", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R15", DataRowVersion.Current, _R15))
        Dim inR15a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR15a", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R15a", DataRowVersion.Current, _R15a))
        Dim inR16 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR16", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R16", DataRowVersion.Current, _R16))
        Dim inR17 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR17", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R17", DataRowVersion.Current, _R17))
        Dim inR18 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR18", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R18", DataRowVersion.Current, _R18))
        Dim inR19 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR19", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R19", DataRowVersion.Current, _R19))
        Dim inR20a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR20a ", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R20a", DataRowVersion.Current, _R20a))
        Dim inR20b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR20b ", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R20b", DataRowVersion.Current, _R20b))
        Dim inR21_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR21_1", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R21_1", DataRowVersion.Current, _R21_1))
        Dim inR22_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR22_1", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "R22_1", DataRowVersion.Current, _R22_1))
        Dim inR21_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR21_2", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R21_2", DataRowVersion.Current, _R21_2))
        Dim inR22_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR22_2", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "R22_2", DataRowVersion.Current, _R22_2))
        Dim inR21_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR21_3", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R21_3", DataRowVersion.Current, _R21_3))
        Dim inR22_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR22_3", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "R22_3", DataRowVersion.Current, _R22_3))
        Dim inR21_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR21_4", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R21_4", DataRowVersion.Current, _R21_4))
        Dim inR22_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR22_4", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "R22_4", DataRowVersion.Current, _R22_4))
        Dim inR23_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR23_1", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "R23_1", DataRowVersion.Current, _R23_1))
        Dim inR23_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR23_2", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "R23_2", DataRowVersion.Current, _R23_2))
        Dim inR23_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR23_3", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "R23_3", DataRowVersion.Current, _R23_3))
        Dim inR23_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR23_4", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "R23_4", DataRowVersion.Current, _R23_4))
        Dim inR24_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24_1", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24_1", DataRowVersion.Current, _R24_1))
        Dim inR24_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24_2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24_2", DataRowVersion.Current, _R24_2))
        Dim inR24_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24_3", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24_3", DataRowVersion.Current, _R24_3))
        Dim inR24_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24_4", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24_4", DataRowVersion.Current, _R24_4))
        Dim inR24Suma As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24Suma", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24Suma", DataRowVersion.Current, _R24Suma))
        Dim inR25TIP_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25TIP_1", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R25TIP_1", DataRowVersion.Current, _R25TIP_1))
        Dim inR25TIP_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25TIP_2", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R25TIP_2", DataRowVersion.Current, _R25TIP_2))
        Dim inR25TIP_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25TIP_3", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R25TIP_3", DataRowVersion.Current, _R25TIP_3))
        Dim inR25TIP_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25TIP_4", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R25TIP_4", DataRowVersion.Current, _R25TIP_4))
        Dim inR25KOL_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25KOL_1", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25KOL_1", DataRowVersion.Current, _R25KOL_1))
        Dim inR25KOL_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25KOL_2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25KOL_2", DataRowVersion.Current, _R25KOL_2))
        Dim inR25KOL_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25KOL_3", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25KOL_3", DataRowVersion.Current, _R25KOL_3))
        Dim inR25KOL_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25KOL_4", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25KOL_4", DataRowVersion.Current, _R25KOL_4))
        Dim inR25Suma As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25Suma", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25Suma", DataRowVersion.Current, _R25Suma))
        Dim inR26_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26_1", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26_1", DataRowVersion.Current, _R26_1))
        Dim inR26_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26_2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26_2", DataRowVersion.Current, _R26_2))
        Dim inR26_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26_3", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26_3", DataRowVersion.Current, _R26_3))
        Dim inR26_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26_4", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26_4", DataRowVersion.Current, _R26_4))
        Dim inR26Suma As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26Suma", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26Suma", DataRowVersion.Current, _R26Suma))
        Dim inR27 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR27", SqlDbType.VarChar, 400, ParameterDirection.Input, False, 0, 0, "R27", DataRowVersion.Current, _R27))
        Dim inR28 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR28", SqlDbType.VarChar, 12, ParameterDirection.Input, False, 0, 0, "R28", DataRowVersion.Current, _R28))
        Dim inR29 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR29", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R29", DataRowVersion.Current, _R29))
        Dim inR30a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR30a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R30a", DataRowVersion.Current, _R30a))
        Dim inR30b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR30b", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R30b", DataRowVersion.Current, _R30b))
        Dim inR31a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR31a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R31a", DataRowVersion.Current, _R31a))
        Dim inR32b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR32b", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R32b", DataRowVersion.Current, _R32b))
        Dim inR32 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR32", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R32", DataRowVersion.Current, _R32))
        Dim inR32a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR32a", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R32a", DataRowVersion.Current, _R32a))
        Dim inR33a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR33a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R33a", DataRowVersion.Current, _R33a))
        Dim inR33b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR33b", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R33b", DataRowVersion.Current, _R33b))
        Dim inR34 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR34", SqlDbType.VarChar, 400, ParameterDirection.Input, False, 0, 0, "R34", DataRowVersion.Current, _R34))
        Dim inR35 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR35", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R35", DataRowVersion.Current, _R35))
        Dim inR36 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR36", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R36", DataRowVersion.Current, _R36))
        Dim inR37 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR37", SqlDbType.VarChar, 500, ParameterDirection.Input, False, 0, 0, "R37", DataRowVersion.Current, _R37))
        Dim inRID As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inRID", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "RID", DataRowVersion.Current, _RID))
        Dim inR41Suma As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR41Suma", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R41Suma", DataRowVersion.Current, _R41Suma))
        Dim inR42_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_1", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_1", DataRowVersion.Current, _R42_1))
        Dim inR42_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_2", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_2", DataRowVersion.Current, _R42_2))
        Dim inR42_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_3", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_3", DataRowVersion.Current, _R42_3))
        Dim inR42_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_4", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_4", DataRowVersion.Current, _R42_4))
        Dim inR42_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_5", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_5", DataRowVersion.Current, _R42_5))
        Dim inR43_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_1", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_1", DataRowVersion.Current, _R43_1))
        Dim inR43_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_2", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_2", DataRowVersion.Current, _R43_2))
        Dim inR43_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_3", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_3", DataRowVersion.Current, _R43_3))
        Dim inR43_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_4", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_4", DataRowVersion.Current, _R43_4))
        Dim inR43_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_5", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_5", DataRowVersion.Current, _R43_5))
        Dim inR44 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR44", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R44", DataRowVersion.Current, _R44))
        Dim inR44n As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR44n", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "R44n", DataRowVersion.Current, _R44n))
        Dim inR44i As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR44i", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R44i", DataRowVersion.Current, _R44i))
        Dim inR45a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR45a", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R45a", DataRowVersion.Current, _R45a))
        Dim inR45b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR45b", SqlDbType.VarChar, 30, ParameterDirection.Input, False, 0, 0, "R45b", DataRowVersion.Current, _R45b))
        Dim inR46 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR46", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "R46", DataRowVersion.Current, _R46))
        Dim inR47 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR47", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R47", DataRowVersion.Current, _R47))
        Dim inR48a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR48a", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R48a", DataRowVersion.Current, _R48a))
        Dim inR48b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR48b", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R48b", DataRowVersion.Current, _R48b))
        Dim inR49 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR49", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R49", DataRowVersion.Current, _R49))
        Dim inR50 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR50", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R50", DataRowVersion.Current, _R50))
        Dim inR51 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR51", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R51", DataRowVersion.Current, _R51))
        Dim inR53 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR53", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R53", DataRowVersion.Current, _R53))
        Dim inR54_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR54_1", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R54_1", DataRowVersion.Current, _R54_1))
        Dim inR54_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR54_2", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R54_2", DataRowVersion.Current, _R54_2))
        Dim inR54_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR54_3", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R54_3", DataRowVersion.Current, _R54_3))
        Dim inR55_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR55_1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R55_1", DataRowVersion.Current, _R55_1))
        Dim inR55_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR55_2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R55_2", DataRowVersion.Current, _R55_2))
        Dim inR55_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR55_3", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R55_3", DataRowVersion.Current, _R55_3))
        Dim inR56_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR56_1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R56_1", DataRowVersion.Current, _R56_1))
        Dim inR56_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR56_2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R56_2", DataRowVersion.Current, _R56_2))
        Dim inR56_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR56_3", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R56_3", DataRowVersion.Current, _R56_3))
        Dim inR57_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR57_1", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R57_1", DataRowVersion.Current, _R57_1))
        Dim inR57_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR57_2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R57_2", DataRowVersion.Current, _R57_2))
        Dim inR57_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR57_3", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R57_3", DataRowVersion.Current, _R57_3))
        Dim inR58 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR58", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R58", DataRowVersion.Current, _R58))
        Dim inR59 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR59", SqlDbType.VarChar, 2, ParameterDirection.Input, False, 0, 0, "R59", DataRowVersion.Current, _R59))
        Dim inR60 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR60", SqlDbType.VarChar, 12, ParameterDirection.Input, False, 0, 0, "R60", DataRowVersion.Current, _R60))

        Dim inR61F As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR61F", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R61F", DataRowVersion.Current, _R61F))
        Dim inR61U As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR61U", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R61U", DataRowVersion.Current, _R61U))

        Dim inR64F_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_1", DataRowVersion.Current, _R64F_1))
        Dim inR64F_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_2", DataRowVersion.Current, _R64F_2))
        Dim inR64F_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_3", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_3", DataRowVersion.Current, _R64F_3))
        Dim inR64F_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_4", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_4", DataRowVersion.Current, _R64F_4))
        Dim inR64F_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_5", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_5", DataRowVersion.Current, _R64F_5))
        Dim inR64F_6 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_6", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_6", DataRowVersion.Current, _R64F_6))

        Dim inR62A_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_1", DataRowVersion.Current, _R62A_1))
        Dim inR62A_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_2", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_2", DataRowVersion.Current, _R62A_2))
        Dim inR62A_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_3", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_3", DataRowVersion.Current, _R62A_3))
        Dim inR62A_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_4", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_4", DataRowVersion.Current, _R62A_4))
        Dim inR62A_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_5", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_5", DataRowVersion.Current, _R62A_5))
        Dim inR63A As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR63A", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R63A", DataRowVersion.Current, _R63A))

        Dim inR62B_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_1", DataRowVersion.Current, _R62B_1))
        Dim inR62B_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_2", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_1", DataRowVersion.Current, _R62B_2))
        Dim inR62B_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_3", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_2", DataRowVersion.Current, _R62B_3))
        Dim inR62B_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_4", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_3", DataRowVersion.Current, _R62B_4))
        Dim inR62B_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_5", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_4", DataRowVersion.Current, _R62B_5))
        Dim inR63B As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR63B", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R63B", DataRowVersion.Current, _R63B))

        Dim inR62C_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_1", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_1", DataRowVersion.Current, _R62C_1))
        Dim inR62C_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_2", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_2", DataRowVersion.Current, _R62C_2))
        Dim inR62C_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_3", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_3", DataRowVersion.Current, _R62C_3))
        Dim inR62C_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_4", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_4", DataRowVersion.Current, _R62C_4))
        Dim inR62C_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_5", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_5", DataRowVersion.Current, _R62C_5))
        Dim inR63C As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR63C", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R63C", DataRowVersion.Current, _R63C))

        Dim inR64U_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_1", DataRowVersion.Current, _R64U_1))
        Dim inR64U_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_2", DataRowVersion.Current, _R64U_2))
        Dim inR64U_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_3", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_3", DataRowVersion.Current, _R64U_3))
        Dim inR64U_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_4", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_4", DataRowVersion.Current, _R64U_4))
        Dim inR64U_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_5", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_5", DataRowVersion.Current, _R64U_5))
        Dim inR64U_6 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_6", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_6", DataRowVersion.Current, _R64U_6))

        Dim inR65F As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR65F", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R65F", DataRowVersion.Current, _R65F))
        Dim inR65U As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR65U", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R65U", DataRowVersion.Current, _R65U))

        Dim inR66a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR66a", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R66a", DataRowVersion.Current, _R66a))
        Dim inR66b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR66b", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R66b", DataRowVersion.Current, _R66b))

        uspUpisSlogUTL.Transaction = ipTrans

        Try
            uspUpisSlogUTL.ExecuteNonQuery()
            If uspUpisSlogUTL.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogUTL!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogUTL.Dispose()
        End Try

    End Sub
    'Friend Sub UpisSlogUTLOWR(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
    '                       ByVal _R1 As String, ByVal _R2 As String, ByVal _R4 As String, ByVal _R5 As String, ByVal _R6 As String, ByVal _R7 As String, _
    '                       ByVal _R8 As String, ByVal _R9 As String, ByVal _R10 As String, ByVal _R10KB As String, ByVal _R11 As Int32, ByVal _R12a As String, _
    '                       ByVal _R12b As String, ByVal _R13a As String, ByVal _R13b As Int32, ByVal _R14a As String, ByVal _R14b As String, ByVal _R15 As String, _
    '                       ByVal _R15a As String, ByVal _R16 As String, ByVal _R17 As Int32, ByVal _R18 As String, ByVal _R19 As String, ByVal _R20a As Int32, _
    '                       ByVal _R20b As Int32, ByVal _R21_1 As String, ByVal _R22_1 As String, ByVal _R21_2 As String, ByVal _R22_2 As String, _
    '                       ByVal _R21_3 As String, ByVal _R22_3 As String, ByVal _R21_4 As String, ByVal _R22_4 As String, ByVal _R23_1 As Decimal, _
    '                       ByVal _R23_2 As Decimal, ByVal _R23_3 As Decimal, ByVal _R23_4 As Decimal, ByVal _R24_1 As Int32, ByVal _R24_2 As Int32, ByVal _R24_3 As Int32, _
    '                       ByVal _R24_4 As Int32, ByVal _R24Suma As Int32, ByVal _R25TIP_1 As String, ByVal _R25TIP_2 As String, ByVal _R25TIP_3 As String, ByVal _R25TIP_4 As String, _
    '                       ByVal _R25KOL_1 As Int32, ByVal _R25KOL_2 As Int32, ByVal _R25KOL_3 As Int32, ByVal _R25KOL_4 As Int32, ByVal _R25Suma As Int32, ByVal _R26_1 As Int32, _
    '                       ByVal _R26_2 As Int32, ByVal _R26_3 As Int32, ByVal _R26_4 As Int32, ByVal _R26Suma As Int32, ByVal _R27 As String, ByVal _R28 As String, ByVal _R29 As String, _
    '                       ByVal _R30a As String, ByVal _R30b As String, ByVal _R31a As String, ByVal _R32b As String, ByVal _R32 As String, ByVal _R32a As String, ByVal _R33a As String, _
    '                       ByVal _R33b As Int32, ByVal _R34 As String, ByVal _R35 As String, ByVal _R36 As Int32, ByVal _R37 As String, ByVal _RID As String, ByVal _R41Suma As Int32, ByVal _R42_1 As String, _
    '                       ByVal _R42_2 As String, ByVal _R42_3 As String, ByVal _R42_4 As String, ByVal _R42_5 As String, ByVal _R43_1 As String, _
    '                       ByVal _R43_2 As String, ByVal _R43_3 As String, ByVal _R43_4 As String, ByVal _R43_5 As String, ByVal _R44 As String, _
    '                       ByVal _R44n As String, ByVal _R44i As Decimal, ByVal _R45a As String, ByVal _R45b As String, ByVal _R46 As String, ByVal _R47 As Decimal, ByVal _R48a As String, _
    '                       ByVal _R48b As String, ByVal _R49 As Decimal, ByVal _R50 As Decimal, ByVal _R51 As Decimal, ByVal _R53 As Int32, ByVal _R54_1 As String, _
    '                       ByVal _R54_2 As String, ByVal _R54_3 As String, ByVal _R55_1 As Decimal, ByVal _R55_2 As Decimal, ByVal _R55_3 As Decimal, ByVal _R56_1 As Decimal, _
    '                       ByVal _R56_2 As Decimal, ByVal _R56_3 As Decimal, ByVal _R57_1 As Int32, ByVal _R57_2 As Int32, ByVal _R57_3 As Int32, ByVal _R58 As String, ByVal _R59 As String, _
    '                       ByVal _R60 As String, ByVal _R61F As Decimal, ByVal _R61U As Decimal, _
    '                       ByVal _R64F_1 As Decimal, ByVal _R64F_2 As Decimal, ByVal _R64F_3 As Decimal, ByVal _R64F_4 As Decimal, ByVal _R64F_5 As Decimal, ByVal _R64F_6 As Decimal, _
    '                       ByVal _R62A_1 As String, ByVal _R62A_2 As String, ByVal _R62A_3 As String, ByVal _R62A_4 As String, ByVal _R62A_5 As String, ByVal _R63A As String, _
    '                       ByVal _R62B_1 As String, ByVal _R62B_2 As String, ByVal _R62B_3 As String, ByVal _R62B_4 As String, ByVal _R62B_5 As String, ByVal _R63B As String, _
    '                       ByVal _R62C_1 As String, ByVal _R62C_2 As String, ByVal _R62C_3 As String, ByVal _R62C_4 As String, ByVal _R62C_5 As String, ByVal _R63C As String, _
    '                       ByVal _R64U_1 As Decimal, ByVal _R64U_2 As Decimal, ByVal _R64U_3 As Decimal, ByVal _R64U_4 As Decimal, ByVal _R64U_5 As Decimal, ByVal _R64U_6 As Decimal, _
    '                       ByVal _R65F As Decimal, ByVal _R65U As Decimal, ByVal _R66a As String, ByVal _R66b As Int32, _
    '                       ByRef opPovVrednost As String)


    '    If OkpDbVeza.State = ConnectionState.Closed Then
    '        OkpDbVeza.Open()
    '    End If

    '    Dim uspUpisSlogUTL As New SqlClient.SqlCommand("dbo.spUpisSlogUTL", OkpDbVeza)

    '    uspUpisSlogUTL.CommandType = CommandType.StoredProcedure

    '    Dim RetVal As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
    '    Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
    '    Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
    '    Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
    '    Dim inR1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R1", DataRowVersion.Current, _R1))
    '    Dim inR2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR2", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R2", DataRowVersion.Current, _R2))
    '    Dim inR4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR4", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R4", DataRowVersion.Current, _R4))
    '    Dim inR5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR5", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R5", DataRowVersion.Current, _R5))
    '    Dim inR6 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR6", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R6", DataRowVersion.Current, _R6))
    '    Dim inR7 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR7", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R7", DataRowVersion.Current, _R7))
    '    Dim inR8 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR8", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R8", DataRowVersion.Current, _R8))
    '    Dim inR9 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR9", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "R9", DataRowVersion.Current, _R9))
    '    Dim inR10 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR10", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R1O", DataRowVersion.Current, _R10))
    '    Dim inR10KB As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR10KB", SqlDbType.Char, 25, ParameterDirection.Input, False, 0, 0, "R10KB", DataRowVersion.Current, _R10KB))
    '    Dim inR11 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR11", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R11", DataRowVersion.Current, _R11))
    '    Dim inR12a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR12a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R12a", DataRowVersion.Current, _R12a))
    '    Dim inR12b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR12b", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R12b", DataRowVersion.Current, _R12b))
    '    Dim inR13a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR13a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R13a", DataRowVersion.Current, _R13a))
    '    Dim inR13b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR13b", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R13b", DataRowVersion.Current, _R13b))
    '    Dim inR14a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR14a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R14a", DataRowVersion.Current, _R14a))
    '    Dim inR14b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR14b", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R14b", DataRowVersion.Current, _R14b))
    '    Dim inR15 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR15", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R15", DataRowVersion.Current, _R15))
    '    Dim inR15a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR15a", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R15a", DataRowVersion.Current, _R15a))
    '    Dim inR16 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR16", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R16", DataRowVersion.Current, _R16))
    '    Dim inR17 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR17", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R17", DataRowVersion.Current, _R17))
    '    Dim inR18 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR18", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R18", DataRowVersion.Current, _R18))
    '    Dim inR19 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR19", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R19", DataRowVersion.Current, _R19))
    '    Dim inR20a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR20a ", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R20a", DataRowVersion.Current, _R20a))
    '    Dim inR20b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR20b ", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R20b", DataRowVersion.Current, _R20b))
    '    Dim inR21_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR21_1", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R21_1", DataRowVersion.Current, _R21_1))
    '    Dim inR22_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR22_1", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "R22_1", DataRowVersion.Current, _R22_1))
    '    Dim inR21_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR21_2", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R21_2", DataRowVersion.Current, _R21_2))
    '    Dim inR22_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR22_2", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "R22_2", DataRowVersion.Current, _R22_2))
    '    Dim inR21_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR21_3", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R21_3", DataRowVersion.Current, _R21_3))
    '    Dim inR22_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR22_3", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "R22_3", DataRowVersion.Current, _R22_3))
    '    Dim inR21_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR21_4", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R21_4", DataRowVersion.Current, _R21_4))
    '    Dim inR22_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR22_4", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "R22_4", DataRowVersion.Current, _R22_4))
    '    Dim inR23_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR23_1", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "R23_1", DataRowVersion.Current, _R23_1))
    '    Dim inR23_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR23_2", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "R23_2", DataRowVersion.Current, _R23_2))
    '    Dim inR23_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR23_3", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "R23_3", DataRowVersion.Current, _R23_3))
    '    Dim inR23_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR23_4", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "R23_4", DataRowVersion.Current, _R23_4))
    '    Dim inR24_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24_1", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24_1", DataRowVersion.Current, _R24_1))
    '    Dim inR24_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24_2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24_2", DataRowVersion.Current, _R24_2))
    '    Dim inR24_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24_3", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24_3", DataRowVersion.Current, _R24_3))
    '    Dim inR24_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24_4", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24_4", DataRowVersion.Current, _R24_4))
    '    Dim inR24Suma As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR24Suma", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R24Suma", DataRowVersion.Current, _R24Suma))
    '    Dim inR25TIP_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25TIP_1", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R25TIP_1", DataRowVersion.Current, _R25TIP_1))
    '    Dim inR25TIP_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25TIP_2", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R25TIP_2", DataRowVersion.Current, _R25TIP_2))
    '    Dim inR25TIP_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25TIP_3", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R25TIP_3", DataRowVersion.Current, _R25TIP_3))
    '    Dim inR25TIP_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25TIP_4", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R25TIP_4", DataRowVersion.Current, _R25TIP_4))
    '    Dim inR25KOL_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25KOL_1", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25KOL_1", DataRowVersion.Current, _R25KOL_1))
    '    Dim inR25KOL_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25KOL_2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25KOL_2", DataRowVersion.Current, _R25KOL_2))
    '    Dim inR25KOL_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25KOL_3", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25KOL_3", DataRowVersion.Current, _R25KOL_3))
    '    Dim inR25KOL_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25KOL_4", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25KOL_4", DataRowVersion.Current, _R25KOL_4))
    '    Dim inR25Suma As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR25Suma", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R25Suma", DataRowVersion.Current, _R25Suma))
    '    Dim inR26_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26_1", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26_1", DataRowVersion.Current, _R26_1))
    '    Dim inR26_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26_2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26_2", DataRowVersion.Current, _R26_2))
    '    Dim inR26_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26_3", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26_3", DataRowVersion.Current, _R26_3))
    '    Dim inR26_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26_4", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26_4", DataRowVersion.Current, _R26_4))
    '    Dim inR26Suma As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR26Suma", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R26Suma", DataRowVersion.Current, _R26Suma))
    '    Dim inR27 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR27", SqlDbType.VarChar, 400, ParameterDirection.Input, False, 0, 0, "R27", DataRowVersion.Current, _R27))
    '    Dim inR28 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR28", SqlDbType.VarChar, 12, ParameterDirection.Input, False, 0, 0, "R28", DataRowVersion.Current, _R28))
    '    Dim inR29 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR29", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R29", DataRowVersion.Current, _R29))
    '    Dim inR30a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR30a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R30a", DataRowVersion.Current, _R30a))
    '    Dim inR30b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR30b", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R30b", DataRowVersion.Current, _R30b))
    '    Dim inR31a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR31a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R31a", DataRowVersion.Current, _R31a))
    '    Dim inR32b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR32b", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R32b", DataRowVersion.Current, _R32b))
    '    Dim inR32 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR32", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "R32", DataRowVersion.Current, _R32))
    '    Dim inR32a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR32a", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R32a", DataRowVersion.Current, _R32a))
    '    Dim inR33a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR33a", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "R33a", DataRowVersion.Current, _R33a))
    '    Dim inR33b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR33b", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R33b", DataRowVersion.Current, _R33b))
    '    Dim inR34 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR34", SqlDbType.VarChar, 400, ParameterDirection.Input, False, 0, 0, "R34", DataRowVersion.Current, _R34))
    '    Dim inR35 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR35", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 0, 0, "R35", DataRowVersion.Current, _R35))
    '    Dim inR36 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR36", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R36", DataRowVersion.Current, _R36))
    '    Dim inR37 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR37", SqlDbType.VarChar, 500, ParameterDirection.Input, False, 0, 0, "R37", DataRowVersion.Current, _R37))
    '    Dim inRID As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inRID", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "RID", DataRowVersion.Current, _RID))
    '    Dim inR41Suma As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR41Suma", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R41Suma", DataRowVersion.Current, _R41Suma))
    '    Dim inR42_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_1", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_1", DataRowVersion.Current, _R42_1))
    '    Dim inR42_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_2", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_2", DataRowVersion.Current, _R42_2))
    '    Dim inR42_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_3", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_3", DataRowVersion.Current, _R42_3))
    '    Dim inR42_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_4", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_4", DataRowVersion.Current, _R42_4))
    '    Dim inR42_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR42_5", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "R42_5", DataRowVersion.Current, _R42_5))
    '    Dim inR43_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_1", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_1", DataRowVersion.Current, _R43_1))
    '    Dim inR43_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_2", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_2", DataRowVersion.Current, _R43_2))
    '    Dim inR43_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_3", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_3", DataRowVersion.Current, _R43_3))
    '    Dim inR43_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_4", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_4", DataRowVersion.Current, _R43_4))
    '    Dim inR43_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR43_5", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "R43_5", DataRowVersion.Current, _R43_5))
    '    Dim inR44 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR44", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R44", DataRowVersion.Current, _R44))
    '    Dim inR44n As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR44n", SqlDbType.VarChar, 8, ParameterDirection.Input, False, 0, 0, "R44n", DataRowVersion.Current, _R44n))
    '    Dim inR44i As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR44i", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R44i", DataRowVersion.Current, _R44i))
    '    Dim inR45a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR45a", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R45a", DataRowVersion.Current, _R45a))
    '    Dim inR45b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR45b", SqlDbType.VarChar, 30, ParameterDirection.Input, False, 0, 0, "R45b", DataRowVersion.Current, _R45b))
    '    Dim inR46 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR46", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "R46", DataRowVersion.Current, _R46))
    '    Dim inR47 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR47", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R47", DataRowVersion.Current, _R47))
    '    Dim inR48a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR48a", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R48a", DataRowVersion.Current, _R48a))
    '    Dim inR48b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR48b", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "R48b", DataRowVersion.Current, _R48b))
    '    Dim inR49 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR49", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R49", DataRowVersion.Current, _R49))
    '    Dim inR50 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR50", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R50", DataRowVersion.Current, _R50))
    '    Dim inR51 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR51", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R51", DataRowVersion.Current, _R51))
    '    Dim inR53 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR53", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R53", DataRowVersion.Current, _R53))
    '    Dim inR54_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR54_1", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R54_1", DataRowVersion.Current, _R54_1))
    '    Dim inR54_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR54_2", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R54_2", DataRowVersion.Current, _R54_2))
    '    Dim inR54_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR54_3", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R54_3", DataRowVersion.Current, _R54_3))
    '    Dim inR55_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR55_1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R55_1", DataRowVersion.Current, _R55_1))
    '    Dim inR55_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR55_2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R55_2", DataRowVersion.Current, _R55_2))
    '    Dim inR55_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR55_3", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R55_3", DataRowVersion.Current, _R55_3))
    '    Dim inR56_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR56_1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R56_1", DataRowVersion.Current, _R56_1))
    '    Dim inR56_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR56_2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R56_2", DataRowVersion.Current, _R56_2))
    '    Dim inR56_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR56_3", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R56_3", DataRowVersion.Current, _R56_3))
    '    Dim inR57_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR57_1", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R57_1", DataRowVersion.Current, _R57_1))
    '    Dim inR57_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR57_2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R57_2", DataRowVersion.Current, _R57_2))
    '    Dim inR57_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR57_3", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R57_3", DataRowVersion.Current, _R57_3))
    '    Dim inR58 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR58", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R58", DataRowVersion.Current, _R58))
    '    Dim inR59 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR59", SqlDbType.VarChar, 2, ParameterDirection.Input, False, 0, 0, "R59", DataRowVersion.Current, _R59))
    '    Dim inR60 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR60", SqlDbType.VarChar, 12, ParameterDirection.Input, False, 0, 0, "R60", DataRowVersion.Current, _R60))

    '    Dim inR61F As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR61F", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R61F", DataRowVersion.Current, _R61F))
    '    Dim inR61U As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR61U", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R61U", DataRowVersion.Current, _R61U))

    '    Dim inR64F_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_1", DataRowVersion.Current, _R64F_1))
    '    Dim inR64F_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_2", DataRowVersion.Current, _R64F_2))
    '    Dim inR64F_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_3", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_3", DataRowVersion.Current, _R64F_3))
    '    Dim inR64F_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_4", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_4", DataRowVersion.Current, _R64F_4))
    '    Dim inR64F_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_5", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_5", DataRowVersion.Current, _R64F_5))
    '    Dim inR64F_6 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64F_6", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64F_6", DataRowVersion.Current, _R64F_6))

    '    Dim inR62A_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_1", DataRowVersion.Current, _R62A_1))
    '    Dim inR62A_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_2", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_2", DataRowVersion.Current, _R62A_2))
    '    Dim inR62A_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_3", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_3", DataRowVersion.Current, _R62A_3))
    '    Dim inR62A_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_4", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_4", DataRowVersion.Current, _R62A_4))
    '    Dim inR62A_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62A_5", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62A_5", DataRowVersion.Current, _R62A_5))
    '    Dim inR63A As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR63A", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R63A", DataRowVersion.Current, _R63A))

    '    Dim inR62B_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_1", DataRowVersion.Current, _R62B_1))
    '    Dim inR62B_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_2", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_1", DataRowVersion.Current, _R62B_2))
    '    Dim inR62B_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_3", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_2", DataRowVersion.Current, _R62B_3))
    '    Dim inR62B_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_4", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_3", DataRowVersion.Current, _R62B_4))
    '    Dim inR62B_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62B_5", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R62B_4", DataRowVersion.Current, _R62B_5))
    '    Dim inR63B As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR63B", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "R63B", DataRowVersion.Current, _R63B))

    '    Dim inR62C_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_1", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_1", DataRowVersion.Current, _R62C_1))
    '    Dim inR62C_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_2", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_2", DataRowVersion.Current, _R62C_2))
    '    Dim inR62C_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_3", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_3", DataRowVersion.Current, _R62C_3))
    '    Dim inR62C_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_4", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_4", DataRowVersion.Current, _R62C_4))
    '    Dim inR62C_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR62C_5", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R62C_5", DataRowVersion.Current, _R62C_5))
    '    Dim inR63C As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR63C", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "R63C", DataRowVersion.Current, _R63C))

    '    Dim inR64U_1 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_1", DataRowVersion.Current, _R64U_1))
    '    Dim inR64U_2 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_2", DataRowVersion.Current, _R64U_2))
    '    Dim inR64U_3 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_3", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_3", DataRowVersion.Current, _R64U_3))
    '    Dim inR64U_4 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_4", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_4", DataRowVersion.Current, _R64U_4))
    '    Dim inR64U_5 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_5", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_5", DataRowVersion.Current, _R64U_5))
    '    Dim inR64U_6 As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR64U_6", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R64U_6", DataRowVersion.Current, _R64U_6))

    '    Dim inR65F As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR65F", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R65F", DataRowVersion.Current, _R65F))
    '    Dim inR65U As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR65U", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "R65U", DataRowVersion.Current, _R65U))

    '    Dim inR66a As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR66a", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "R66a", DataRowVersion.Current, _R66a))
    '    Dim inR66b As SqlClient.SqlParameter = uspUpisSlogUTL.Parameters.Add(New SqlClient.SqlParameter("@inR66b", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "R66b", DataRowVersion.Current, _R66b))

    '    uspUpisSlogUTL.Transaction = ipTrans

    '    Try
    '        uspUpisSlogUTL.ExecuteNonQuery()
    '        If uspUpisSlogUTL.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogUTL!"
    '    Catch SQLExp As SqlException
    '        opPovVrednost = SQLExp.Message      'Greska - SQL greska
    '    Catch Exp As Exception
    '        opPovVrednost = Err.Description     'Greska - bilo koja
    '    Finally
    '        uspUpisSlogUTL.Dispose()
    '    End Try

    'End Sub
    Friend Sub UpisSlogRobaUI(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                               ByVal _mKolaStavka As Int16, ByVal _mRobaStavka As Int16, ByVal _NHM As String, ByVal _R As String, _
                               ByVal _SMasa As Int32, ByVal _RID As Int16, ByVal _UtiTip As String, ByVal _UtiIB As String, _
                               ByVal _UtiTara As Int32, ByVal _UtiRaster As Decimal, ByVal _UtiNHM As String, _
                               ByVal _UtiPredajniList As String, ByVal _UtiBrPlombe As String, _
                               ByVal _RacMasa As Int32, ByVal _VozStav As Decimal, _
                               ByVal _Poreklo As Int16, _
                               ByRef opPovVrednost As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim uspUpisSlogRoba As New SqlClient.SqlCommand("dbo.spUpisSlogRobaUI", OkpDbVeza) 'roba

        Dim uspUpisSlogRoba As New SqlClient.SqlCommand("dbo.spUpisSlogRobaLokal", OkpDbVeza) 'roba
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

        '! OkpWinRoba+ , WinRoba-
        Dim inRacMasa As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRacMasa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RMasa", DataRowVersion.Current, _RacMasa))
        Dim inVozStav As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inVozStav", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VozStav", DataRowVersion.Current, _VozStav))
        Dim inPoreklo As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inPoreklo", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Poreklo", DataRowVersion.Current, _Poreklo))
        uspUpisSlogRoba.Transaction = ipTrans

        Try
            uspUpisSlogRoba.ExecuteNonQuery()
            If uspUpisSlogRoba.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogRoba!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogRoba.Dispose()
        End Try

    End Sub
    Public Sub BrisanjeSlogRobaUI2(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, _
                                  ByVal _StanicaUnosa As String, ByVal _mKolaStavka As Int16, _
                                  ByVal _mRobaStavka As Int16, _
                                  ByRef opPovVrednost As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogRoba As New SqlClient.SqlCommand("dbo.spBrisanjeSlogRobaUI2", OkpDbVeza)
        uspUpisSlogRoba.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inKolaStavka As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inKolaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "KolaStavka", DataRowVersion.Current, _mKolaStavka))
        Dim inRobaStavka As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRobaStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RobaStavka", DataRowVersion.Current, _mRobaStavka))

        uspUpisSlogRoba.Transaction = ipTrans

        Try
            uspUpisSlogRoba.ExecuteNonQuery()
            If uspUpisSlogRoba.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogKola!"

        Catch ex As Exception
            opPovVrednost = Err.Description
        Catch sqlexp As Exception
            opPovVrednost = sqlexp.Message
        Finally
            uspUpisSlogRoba.Dispose()
        End Try
    End Sub
    Friend Sub UpisSlogKalkMM(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                            ByVal _PodStanica1 As String, ByVal _PodStanica2 As String, _
                            ByRef opPovVrednost As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKalkMM As New SqlClient.SqlCommand("dbo.spUpisSlogKalkMM", OkpDbVeza)

        uspUpisSlogKalkMM.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalkMM.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKalkMM.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogKalkMM.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalkMM.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inPodStanica1 As SqlClient.SqlParameter = uspUpisSlogKalkMM.Parameters.Add(New SqlClient.SqlParameter("@inPodStanica1", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "PodStanica1", DataRowVersion.Current, _PodStanica1))
        Dim inPodStanica2 As SqlClient.SqlParameter = uspUpisSlogKalkMM.Parameters.Add(New SqlClient.SqlParameter("@inPodStanica2", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "PodStanica2", DataRowVersion.Current, _PodStanica2))

        uspUpisSlogKalkMM.Transaction = ipTrans

        Try
            uspUpisSlogKalkMM.ExecuteNonQuery()
            If uspUpisSlogKalkMM.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogPS!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalkMM.Dispose()
        End Try


    End Sub
    Friend Sub bUpisSlogKalkPDV(ByVal inTrans As SqlTransaction, ByVal inmAkcija As String, ByVal inRecID As Int32, ByVal inStanicaUnosa As String, _
                            ByVal inPDV1 As Decimal, ByVal inPDV2 As Decimal, _
                            ByRef outPovVrednost As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKalkPDV As New SqlClient.SqlCommand("radnik.bUpisSlogKalkPDV", OkpDbVeza)

        uspUpisSlogKalkPDV.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKalkPDV.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim ulAkcija As SqlClient.SqlParameter = uspUpisSlogKalkPDV.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim ulopRecID As SqlClient.SqlParameter = uspUpisSlogKalkPDV.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, inRecID))
        Dim ulStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKalkPDV.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, inStanicaUnosa))
        Dim ulPodStanica1 As SqlClient.SqlParameter = uspUpisSlogKalkPDV.Parameters.Add(New SqlClient.SqlParameter("@inPDV1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PDV1", DataRowVersion.Current, inPDV1))
        Dim ulPodStanica2 As SqlClient.SqlParameter = uspUpisSlogKalkPDV.Parameters.Add(New SqlClient.SqlParameter("@inPDV2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PDV2", DataRowVersion.Current, inPDV2))

        uspUpisSlogKalkPDV.Transaction = inTrans

        Try
            uspUpisSlogKalkPDV.ExecuteNonQuery()
            If uspUpisSlogKalkPDV.Parameters("@RETURN_VALUE").Value = 0 Then outPovVrednost = "Ništa nije upisano u SlogPDV!"
        Catch SQLExp As SqlException
            outPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            outPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalkPDV.Dispose()
        End Try


    End Sub
    Friend Sub UpisSlogK211(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                            ByVal _mStavka As Int16, ByVal _mSifraK211 As Int32, _
                            ByRef opPovVrednost As String)

        'ByVal _mSifraK211 As string staro

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim uspUpisSlogKola As New SqlClient.SqlCommand("dbo.spUpisSlogK211", OkpDbVeza)

        Dim uspUpisSlogKola As New SqlClient.SqlCommand("roba1708.spUpisSlogK211b", OkpDbVeza)

        uspUpisSlogKola.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inStavkaK211 As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Stavka", DataRowVersion.Current, _mStavka))
        Dim inSifraK211 As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inSifraK211", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraK211", DataRowVersion.Current, _mSifraK211))
        'stara verzija polje je bio char(2)
        'Dim inSifraK211 As SqlClient.SqlParameter = uspUpisSlogKola.Parameters.Add(New SqlClient.SqlParameter("@inSifraK211", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraK211", DataRowVersion.Current, _mSifraK211))

        uspUpisSlogKola.Transaction = ipTrans

        Try
            uspUpisSlogKola.ExecuteNonQuery()
            If uspUpisSlogKola.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogK211!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKola.Dispose()
        End Try

    End Sub
    Friend Sub UpisK211(ByVal ipTrans As SqlTransaction, ByVal ulSifraK211 As Int32, ByVal ulStavka As Int32, _
                           ByVal ulNazivSrpski As String, ByVal ulNazivNemacki As String, ByVal ulRubrikaCIM As String, ByVal ulVrstaSaobr As String, ByRef opPovVrednost As String)
        opPovVrednost = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim uspUpisSlogDencane As New SqlClient.SqlCommand("spUpisKP211", OkpDbVeza)
        Dim uspUpisSifreKP As New SqlClient.SqlCommand("roba1708.bspUpisSifreKPLokal", OkpDbVeza)
        uspUpisSifreKP.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSifreKP.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        Dim inSif211 As SqlClient.SqlParameter = uspUpisSifreKP.Parameters.Add(New SqlClient.SqlParameter("@inSifraK211", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraK211", DataRowVersion.Current, ulSifraK211))
        Dim inStavka As SqlClient.SqlParameter = uspUpisSifreKP.Parameters.Add(New SqlClient.SqlParameter("@inStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Stavka", DataRowVersion.Current, ulStavka))
        Dim inNazSrp As SqlClient.SqlParameter = uspUpisSifreKP.Parameters.Add(New SqlClient.SqlParameter("@inNazivSrpski", SqlDbType.Char, 100, ParameterDirection.Input, False, 0, 0, "NazivSrpski", DataRowVersion.Current, ulNazivSrpski))
        Dim inNazNem As SqlClient.SqlParameter = uspUpisSifreKP.Parameters.Add(New SqlClient.SqlParameter("@inNazivNemacki", SqlDbType.Char, 100, ParameterDirection.Input, False, 0, 0, "NazivNemacki", DataRowVersion.Current, ulNazivNemacki))
        Dim inRubCIM As SqlClient.SqlParameter = uspUpisSifreKP.Parameters.Add(New SqlClient.SqlParameter("@inRubrikaCIM", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "RubrikaCIM", DataRowVersion.Current, ulRubrikaCIM))
        Dim inVrstaSaobr As SqlClient.SqlParameter = uspUpisSifreKP.Parameters.Add(New SqlClient.SqlParameter("@inVrstaSaobr", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "VrstaSaobracaja", DataRowVersion.Current, ulVrstaSaobr))
        uspUpisSifreKP.Transaction = ipTrans

        Try
            uspUpisSifreKP.ExecuteNonQuery()
            If uspUpisSifreKP.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u Sifarnik KP!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSifreKP.Dispose()
        End Try


    End Sub
    Friend Sub UpisSlogNaknada72(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, ByVal _NaknadeStavka As Int16, _
                                   ByVal _SifraNaknade As String, ByVal _IvicniBroj As String, ByVal _Iznos As Decimal, ByVal _Valuta As String, ByVal _Kolicina As Int32, ByVal _DanCas As Int32, ByVal _Placanje As String, ByVal _Vrsta As String, _
                                   ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogNaknade As New SqlClient.SqlCommand("roba1708.bspUpisSlogNaknade72", OkpDbVeza)
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

        Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "Iznos", DataRowVersion.Current, _Iznos))
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
    Friend Sub UpdateMesecUnosa(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _Saobracaj As String, ByVal _Mesec As String, ByVal _Godina As String, ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisRMesec As New SqlClient.SqlCommand("spUpdateMesecUnosa", OkpDbVeza)
        uspUpisRMesec.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisRMesec.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisRMesec.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisRMesec.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _Saobracaj))
        Dim inUlNalepnica As SqlClient.SqlParameter = uspUpisRMesec.Parameters.Add(New SqlClient.SqlParameter("@inMesec", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Mesec", DataRowVersion.Current, _Mesec))
        Dim inIzNalepnica As SqlClient.SqlParameter = uspUpisRMesec.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Godina", DataRowVersion.Current, _Godina))

        uspUpisRMesec.Transaction = ipTrans

        Try
            uspUpisRMesec.ExecuteNonQuery()
            If uspUpisRMesec.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u tabelu RacMesec!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisRMesec.Dispose()
        End Try
    End Sub
End Module
