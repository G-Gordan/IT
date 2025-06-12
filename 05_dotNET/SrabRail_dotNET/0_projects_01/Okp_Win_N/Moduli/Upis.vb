Imports System.Data.SqlClient
Module Upis 
    Friend Sub UpisSlogKalkUI(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, _
                            ByVal _DatumOtp As DateTime, ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, _
                            ByVal _DatumPr As DateTime, ByVal _BrojVoza As Int32, ByVal _SatVoza As String, _
                            ByVal _Najava As String, ByVal _NajavaKola As Int16, ByVal _Najava2 As String, ByVal _NajavaKola2 As Int16, _
                            ByVal _Tarifa As String, ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, _
                            ByVal _Primalac As Int32, ByVal _PlatilacNFR As Int32, _
                            ByVal _VrPos As String, ByVal _Prevoz As String, ByVal _Saobracaj As String, _
                            ByVal _VrSao As Int16, ByVal _VrPrevoza As String, ByVal _UkupnoKola As Int32, ByVal _NarPos As String, ByVal _ZsPrevozniPut As Int32, _
                            ByVal _Tkm As Int32, ByVal _Skm As Int32, ByVal _Izjava As Int16, ByVal _FrRacun As String, _
                            ByVal _K115_e As Decimal, ByVal _K115_d As Decimal, ByVal _FrankoPoCIM_e As Decimal, ByVal _FrankoPoCIM_d As Decimal, _
                            ByVal _FrNaknade As String, ByVal _FrDoPrelaza As String, ByVal _Incoterms As String, _
                            ByVal _IsporukaVal As String, ByVal _Isporuka As Decimal, ByVal _PouzeceVal As String, _
                            ByVal _Pouzece As Decimal, ByVal _VrednostRobeVal As String, ByVal _VrednostRobe As Decimal, _
                            ByVal _tlValuta As String, ByVal _TLSumaFR As Decimal, ByVal _TLSumaUP As Decimal, _
                            ByVal _TLSumaFRDin As Decimal, ByVal _TLSumaUPDin As Decimal, _
                            ByVal _TLPrevFR As Decimal, ByVal _TLPrevUP As Decimal, ByVal _TLNakFR As Decimal, ByVal _TLNakUP As Decimal, _
                            ByVal _TLPrevFRDin As Decimal, ByVal _TLPrevUPDin As Decimal, ByVal _TLNakFRDin As Decimal, ByVal _TLNakUPDin As Decimal, _
                            ByVal _TLNakCo82 As Decimal, ByVal _TLNakCo As Decimal, _
                            ByVal _rSumaFR As Decimal, ByVal _rSumaUP As Decimal, ByVal _rSumaFRDin As Decimal, ByVal _rSumaUPDin As Decimal, ByVal _rK115_d As Decimal, _
                            ByVal _SifraK211 As String, ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _CarStanica As String, ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, _
                            ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, _
                            ByVal _CarDatum As Date, ByVal _CarAgent As String, _
                            ByVal _CarXml As String, ByVal _Server As String, _
                            ByVal _UpdRecID As Int32, ByVal _UpdStanicaRecID As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

        'ByRef opRecID As Int32, ByRef opError As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spUpisSlogKalkUI2", OkpDbVeza)
        'Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spUpisSlogKalkUI", OkpDbVeza)
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

        '---novo
        Dim inNajava2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava2", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava2", DataRowVersion.Current, _Najava2))
        Dim inNajavaKola2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola2", DataRowVersion.Current, _NajavaKola2))
        '---end novo

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
        Dim inNarPos As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNarPos", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "NarPos", DataRowVersion.Current, _NarPos))
        Dim inUkupnoKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUKK", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "UkupnoKola", DataRowVersion.Current, _UkupnoKola))
        Dim inZsPrevozniPut As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inZsPrevozniPut", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "PrevozniPutZs", DataRowVersion.Current, _ZsPrevozniPut))
        Dim inTkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@intkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "TkmZS", DataRowVersion.Current, _Tkm))
        Dim inSkm As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inskm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SkmZS", DataRowVersion.Current, _Skm))
        Dim inIzjava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIzjava", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "SifraIzjave", DataRowVersion.Current, _Izjava))
        Dim inFrRacun As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrRacun", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "FrRacun", DataRowVersion.Current, _FrRacun))
        Dim inK115_e As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inK115_e", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "K115_e", DataRowVersion.Current, _K115_e))
        Dim inK115_d As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inK115_d", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "K115_d", DataRowVersion.Current, _K115_d))
        Dim inFrankoPoCIM_e As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrankoPoCIM_e", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "FrankoPoCIM_e", DataRowVersion.Current, _FrankoPoCIM_e))
        Dim inFrankoPoCIM_d As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrankoPoCIM_d", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "FrankoPoCIM_d", DataRowVersion.Current, _FrankoPoCIM_d))
        Dim inFrNaknade As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrNaknade", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "FrNaknade", DataRowVersion.Current, _FrNaknade))
        Dim inFrDoPrelaza As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inFrDoPrelaza", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "FrDoPrelaza", DataRowVersion.Current, _FrDoPrelaza))
        Dim inIncoterms As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIncoterms", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Incoterms", DataRowVersion.Current, _Incoterms))
        Dim inIsporukaVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporukaVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "IsporukaVal", DataRowVersion.Current, _IsporukaVal))
        Dim inIsporuka As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inIsporuka", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Isporuka", DataRowVersion.Current, _Isporuka))
        Dim inPouzeceVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzeceVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "PouzeceVal", DataRowVersion.Current, _PouzeceVal))
        Dim inPouzece As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inPouzece", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pouzece", DataRowVersion.Current, _Pouzece))
        Dim inVrednostRobeVal As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobeVal", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "VrednostRobeVal", DataRowVersion.Current, _VrednostRobeVal))
        Dim inVrednostRobe As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inVrednostRobe", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VrednostRobe", DataRowVersion.Current, _VrednostRobe))
        Dim intlValuta As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _tlValuta))
        '--------------------------------------------------------------------------------------------------------
        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFr", DataRowVersion.Current, _TLSumaFR))
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLSumaFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaFrDin", DataRowVersion.Current, _TLSumaFRDin))
        Dim inTLSumaUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUpDin", DataRowVersion.Current, _TLSumaUPDin))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))
        Dim inTLPrevFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlPrevFrDin", DataRowVersion.Current, _TLPrevFRDin))
        Dim inTLPrevUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlPrevUpDin", DataRowVersion.Current, _TLPrevUPDin))
        Dim inTLNakFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlNakFrDin", DataRowVersion.Current, _TLNakFRDin))
        Dim inTLNakUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlNakUpDin", DataRowVersion.Current, _TLNakUPDin))
        '--------------------------------------------------------------------------------------------------------
        Dim inTLNakCo82 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakCo82", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakCo82", DataRowVersion.Current, _TLNakCo82))
        Dim inTLNakCo As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakCo", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakCo", DataRowVersion.Current, _TLNakCo))

        Dim inrSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inrSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaFr", DataRowVersion.Current, _rSumaFR))
        Dim inrSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inrSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaUp", DataRowVersion.Current, _rSumaUP))
        Dim inrSumaFRDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inrSumaFRDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaFrDin", DataRowVersion.Current, _rSumaFRDin))
        Dim inrSumaUPDin As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inrSumaUPDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaUpDin", DataRowVersion.Current, _rSumaUPDin))

        Dim inrK115_d As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inrK115_d", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rK115_d", DataRowVersion.Current, _rK115_d))
        Dim inSifraK211 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraK211", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "SifraK211", DataRowVersion.Current, _SifraK211))
        Dim inReferent1 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inReferent1", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Referent1", DataRowVersion.Current, _Referent1))
        Dim inObradaDatum As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inObradaDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "DatumObrade", DataRowVersion.Current, _DatumObrade))
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

        Dim inUpdRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUpdRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _UpdRecID))
        Dim inUpdStanicaRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inUpdStanicaRecID", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _UpdStanicaRecID))

        '--------------------------------------------------------------------------------------------------------
        Dim oppRecID As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@oppRecID", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))
        '        Dim opperror As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@myError", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            '           opError = uspUpisSlogKalk.Parameters("@@myError").Value
            '           If opError = 2627 Then
            '           MessageBox.Show("Dupli slog", "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '           End If

            'If SQLExp.Number = 2627 Then
            '    MessageBox.Show("Dupli slog", "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub
    Friend Sub UpisSlogKalkMakis(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
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
                            ByVal _TLNakCo82 As Decimal, ByVal _TLNakCo As Decimal, _
                            ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _CarStanica As String, ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, _
                            ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, _
                            ByVal _CarDatum As Date, ByVal _CarAgent As String, _
                            ByVal _CarXml As String, ByVal _Server As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)
        'ByRef opRecID As Int32, ByRef opError As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spUpisSlogKalkMakis", OkpDbVeza)
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
        Dim inNajava As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava2", DataRowVersion.Current, _Najava))
        Dim inNajavaKola As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola2", DataRowVersion.Current, _NajavaKola))
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

        Dim inTLSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaFr", DataRowVersion.Current, _TLSumaFR))
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaUp", DataRowVersion.Current, _TLSumaUP))

        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rPrevFr", DataRowVersion.Current, _TLPrevFR))
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rPrevUp", DataRowVersion.Current, _TLPrevUP))

        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rNakFr", DataRowVersion.Current, _TLNakFR))
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rNakUp", DataRowVersion.Current, _TLNakUP))

        Dim inTLNakCo82 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakCo82", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rNakFr", DataRowVersion.Current, _TLNakCo82))
        Dim inTLNakCo As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakCo", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "rNakFr", DataRowVersion.Current, _TLNakCo))

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
        '        Dim opperror As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@myError", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            '           opError = uspUpisSlogKalk.Parameters("@@myError").Value
            '           If opError = 2627 Then
            '           MessageBox.Show("Dupli slog", "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '           End If

            'If SQLExp.Number = 2627 Then
            '    MessageBox.Show("Dupli slog", "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
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

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKola As New SqlClient.SqlCommand("dbo.spUpisSlogKola", OkpDbVeza)

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
                            ByVal _RacMasa As Int32, ByVal _VozStav As Decimal, _
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

        '! OkpWinRoba+ , WinRoba-
        Dim inRacMasa As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inRacMasa", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RMasa", DataRowVersion.Current, _RacMasa))
        Dim inVozStav As SqlClient.SqlParameter = uspUpisSlogRoba.Parameters.Add(New SqlClient.SqlParameter("@inVozStav", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VozStav", DataRowVersion.Current, _VozStav))

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

    Friend Sub UpisSlogNaknada(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                               ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                               ByVal _NaknadeStavka As Int16, ByVal _SifraNaknade As String, ByVal _IvicniBroj As String, ByVal _Iznos As Decimal, _
                               ByVal _Valuta As String, ByVal _Kolicina As Int32, ByVal _DanCas As Int32, ByVal _Placanje As String, ByVal _Vrsta As String, _
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

        Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Iznos", DataRowVersion.Current, _Iznos))
        'Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "Iznos", DataRowVersion.Current, _Iznos))

        'Dim inPojedinacna As SqlClient.SqlParameter = uspUpisCena.Parameters.Add(New SqlClient.SqlParameter("@inPojedinacna", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pojedinacna", DataRowVersion.Current, CenaPojedinacna))

        'Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal))  'Decimal
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
    Friend Sub NajavaUpd(ByVal ipTrans As SqlTransaction, ByVal _mBrojUg As String, _
                         ByVal _mNajava As String, ByVal _mIBK As String, _
                         ByRef opPovVrednost As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspNajavaUpd As New SqlClient.SqlCommand("dbo.spNajavaUpd_Novo", OkpDbVeza)
        'Dim uspNajavaUpd As New SqlClient.SqlCommand("dbo.spNajavaUpd", OkpDbVeza)


        uspNajavaUpd.CommandType = CommandType.StoredProcedure


        Dim RetVal As SqlClient.SqlParameter = uspNajavaUpd.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inUgovor As SqlClient.SqlParameter = uspNajavaUpd.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "BrUgovora", DataRowVersion.Current, _mBrojUg))
        Dim inNajava As SqlClient.SqlParameter = uspNajavaUpd.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "KomBrojVoza", DataRowVersion.Current, _mNajava))
        Dim inIBK As SqlClient.SqlParameter = uspNajavaUpd.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "IBK", DataRowVersion.Current, _mIBK))

        uspNajavaUpd.Transaction = ipTrans

        Try

            uspNajavaUpd.ExecuteNonQuery()
            If uspNajavaUpd.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Bez izmene najave u bazi podataka."

            '''If mRucnaNajava = "N" Then
            '''    If uspNajavaUpd.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Bez izmene najave u bazi podataka."
            '''End If

            'dodato
            'If opPovVrednost = "Updated!" Then
            '    MsgBox(opPovVrednost)
            'Else
            '    MsgBox(opPovVrednost)
            'End If

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspNajavaUpd.Dispose()
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
    Friend Sub UpdateMesecPrint(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _Saobracaj As String, ByVal _Mesec As String, ByVal _Godina As String, ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisRMesec As New SqlClient.SqlCommand("spUpdateRMesec", OkpDbVeza)
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

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpdateTrz As New SqlClient.SqlCommand("spUpdateTrz", OkpDbVeza)
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
    Friend Sub UpisSlogUicUI(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                           ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                           ByVal _UicStavka As Int16, ByVal _Uprava As String, ByVal _SifraGS As String, ByVal _SifraPP As String, ByVal _Ulaz As String, ByVal _Izlaz As String, _
                           ByVal _Valuta As String, ByVal _PrevFR As Decimal, ByVal _PrevUP As Decimal, _
                           ByVal _Nak1 As String, ByVal _Iznos1 As Decimal, ByVal _Nak2 As String, ByVal _Iznos2 As Decimal, ByVal _Nak3 As String, ByVal _Iznos3 As Decimal, _
                           ByVal _NaknadeFR As Decimal, ByVal _NaknadeUP As Decimal, ByVal _SumaDinFR As Decimal, ByVal _SumaDinUP As Decimal, _
                           ByVal _ValPredujam As String, ByVal _Predujam As Decimal, _
                           ByVal _TLVal As String, ByVal _TLFranko As Decimal, ByVal _TLUpuceno As Decimal, ByVal _TLUpucenoDin As Decimal, ByVal _Operater As String, _
                           ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogUic As New SqlClient.SqlCommand("dbo.spUpisSlogUicUI2", OkpDbVeza)
        'Dim uspUpisSlogUic As New SqlClient.SqlCommand("dbo.spUpisSlogUicUI", OkpDbVeza)
        uspUpisSlogUic.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, mAkcija))

        Dim inopRecID As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RecID", DataRowVersion.Current, _opRecID))
        Dim inStanicaUnosa As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, _StanicaUnosa))
        Dim inOtpUprava As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inOtpUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "OtpUprava", DataRowVersion.Current, _tbUpravaOtp))
        Dim inOtpStanica As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inOtpStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "OtpStanica", DataRowVersion.Current, _tbStanicaOtp))
        Dim inOtpBroj As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, _tbBrojOtp))
        Dim inOtpDatum As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inOtpDatum", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "OtpDatum", DataRowVersion.Current, _DatumOtp))
        Dim inUicStavka As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inUicStavka", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "StavkaUIC", DataRowVersion.Current, _UicStavka))

        Dim inUprava As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inUprava", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Uprava", DataRowVersion.Current, _Uprava))
        Dim inSifraGS As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inSifraGS", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "SifraGS", DataRowVersion.Current, _SifraGS))
        Dim inSifraPP As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inSifraPP", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "SifraPP", DataRowVersion.Current, _SifraPP))
        Dim inUlaz As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inUlaz", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "UlPrelaz", DataRowVersion.Current, _Ulaz))
        Dim inIzlaz As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inIzlaz", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "IzPrelaz", DataRowVersion.Current, _Izlaz))
        Dim inValuta As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inValuta", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Valuta", DataRowVersion.Current, _Valuta))
        Dim inPrevFR As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inPrevozninaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PrevFR", DataRowVersion.Current, _PrevFR))
        Dim inPrevUP As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inPrevozninaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PrevUP", DataRowVersion.Current, _PrevUP))

        Dim inNak1 As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inNak1", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Nak1", DataRowVersion.Current, _Nak1))
        Dim inIznos1 As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inIznos1", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Iznos1", DataRowVersion.Current, _Iznos1))
        Dim inNak2 As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inNak2", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Nak2", DataRowVersion.Current, _Nak2))
        Dim inIznos2 As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inIznos2", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Iznos2", DataRowVersion.Current, _Iznos2))
        Dim inNak3 As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inNak3", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Nak3", DataRowVersion.Current, _Nak3))
        Dim inIznos3 As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inIznos3", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Iznos3", DataRowVersion.Current, _Iznos3))
        Dim inNakFR As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inNaknadeFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "NaknadeFR", DataRowVersion.Current, _NaknadeFR))
        Dim inNakUP As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inNaknadeUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "NaknadeUP", DataRowVersion.Current, _NaknadeUP))
        Dim inSumaDinFr As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inSumaDinFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "SumaDinFR", DataRowVersion.Current, _SumaDinFR))
        Dim inSumaDinUP As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inSumaDinUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "SumaDinUP", DataRowVersion.Current, _SumaDinUP))
        Dim inValPred As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inValutaPred", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "PredujamVal", DataRowVersion.Current, _ValPredujam))
        Dim inPredujam As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inPredujam", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Predujam", DataRowVersion.Current, _Predujam))
        Dim inValutaTL As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inValutaTL", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "tlValuta", DataRowVersion.Current, _TLVal))
        Dim inFranko As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inTLFranko", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlFranko", DataRowVersion.Current, _TLFranko))
        Dim inUpuceno As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inTLUpuceno", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlUpuceno", DataRowVersion.Current, _TLUpuceno))

        Dim inUpucenoDin As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inTLUpucenoDin", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlUpucenoDin", DataRowVersion.Current, _TLUpucenoDin))
        Dim inOperater As SqlClient.SqlParameter = uspUpisSlogUic.Parameters.Add(New SqlClient.SqlParameter("@inOperater", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Operater", DataRowVersion.Current, _Operater))
        uspUpisSlogUic.Transaction = ipTrans

        Try
            uspUpisSlogUic.ExecuteNonQuery()
            If uspUpisSlogUic.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogUic!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogUic.Dispose()
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
            If uspUpisSlogKalkMM.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u SlogKola!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalkMM.Dispose()
        End Try


    End Sub
    Friend Sub UpisSlogKalk(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _StanicaUnosa As String, _
                            ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, _
                            ByVal _DatumOtp As DateTime, ByVal _mObrGodina As String, ByVal _mObrMesec As String, _
                            ByVal _UlazniPrelaz As String, ByVal _UlaznaNalepnica As Int32, ByVal _DatumUlaza As Date, _
                            ByVal _IzlazniPrelaz As String, ByVal _IzlaznaNalepnica As Int32, ByVal _DatumIzlaza As Date, _
                            ByVal _tbUpravaPr As String, ByVal _tbStanicaPr As String, ByVal _tbBrojPr As Int32, _
                            ByVal _DatumPr As DateTime, ByVal _BrojVoza As Int32, ByVal _SatVoza As String, _
                            ByVal _Najava As String, ByVal _NajavaKola As Int16, ByVal _Najava2 As String, ByVal _NajavaKola2 As Int16, _
                            ByVal _Tarifa As String, ByVal _Ugovor As String, ByVal _Posiljalac As Int32, ByVal _PlatilacFRR As Int32, _
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
                            ByVal _TLNakCo82 As Decimal, ByVal _TLNakCo As Decimal, ByVal _rSumaFR As Decimal, _
                            ByVal _SifraK211 As String, ByVal _Referent1 As String, ByVal _DatumObrade As Date, _
                            ByVal _CarStanica As String, ByVal _CarPrimalacPIB As String, ByVal _CarPrimalacNaziv As String, _
                            ByVal _CarPrimalacSediste As String, ByVal _CarPrimalacZemlja As String, ByVal _CarValuta As String, _
                            ByVal _CarFaktura As Decimal, ByVal _CarBrojFakture As String, ByVal _CarDokumenti As String, ByVal _CarKnjiga As String, _
                            ByVal _CarDatum As Date, ByVal _CarAgent As String, _
                            ByVal _CarXml As String, ByVal _Server As String, _
                            ByRef opRecID As Int32, ByRef opPovVrednost As String)

        'ByRef opRecID As Int32, ByRef opError As Int32, ByRef opPovVrednost As String)

        'ByVal _Ugovor As String, 
        'ByRef opRecID As Int32, ByRef opPovVrednost As String)

        ' nije samo upis, vec je i azuriranje i brisanje:
        ' mAkcija = "New"   - upis
        ' mAkcija = "Upd"   - azuriranje
        ' mAkcija = "Del"   - brisanje

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKalk As New SqlClient.SqlCommand("spUpisSlogKalk", OkpDbVeza)
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

        '---novo
        Dim inNajava2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajava2", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "Najava2", DataRowVersion.Current, _Najava2))
        Dim inNajavaKola2 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inNajavaKola2", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "NajavaKola2", DataRowVersion.Current, _NajavaKola2))
        '---end novo

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
        Dim inTLSumaUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLSumaUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlSumaUp", DataRowVersion.Current, _TLSumaUP))
        Dim inTLPrevFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevFr", DataRowVersion.Current, _TLPrevFR))
        Dim inTLPrevUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLPrevUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlPrevUp", DataRowVersion.Current, _TLPrevUP))
        Dim inTLNakFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakFR))
        Dim inTLNakUP As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakUP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakUp", DataRowVersion.Current, _TLNakUP))
        Dim inTLNakCo82 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakCo82", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakCo82))
        Dim inTLNakCo As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inTLNakCo", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 12, 2, "tlNakFr", DataRowVersion.Current, _TLNakCo))
        Dim inrSumaFR As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inrSumaFR", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "rSumaFr", DataRowVersion.Current, _rSumaFR))
        Dim inSifraK211 As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@inSifraK211", SqlDbType.VarChar, 20, ParameterDirection.Input, False, 0, 0, "SifraK211", DataRowVersion.Current, _SifraK211))
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
        '        Dim opperror As SqlClient.SqlParameter = uspUpisSlogKalk.Parameters.Add(New SqlClient.SqlParameter("@myError", SqlDbType.Int, 4, ParameterDirection.Output, False, 0, 0, "", DataRowVersion.Current, 0))

        uspUpisSlogKalk.Transaction = ipTrans

        Try
            uspUpisSlogKalk.ExecuteNonQuery()
            If uspUpisSlogKalk.Parameters("@RETURN_VALUE").Value = 0 Then
                opPovVrednost = "Ništa nije upisano u SlogKalk!"
            Else
                opRecID = uspUpisSlogKalk.Parameters("@oppRecID").Value
            End If

        Catch SQLExp As SqlException
            '           opError = uspUpisSlogKalk.Parameters("@@myError").Value
            '           If opError = 2627 Then
            '           MessageBox.Show("Dupli slog", "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '           End If

            'If SQLExp.Number = 2627 Then
            '    MessageBox.Show("Dupli slog", "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisSlogKalk.Dispose()
        End Try

    End Sub
    Friend Sub UpisSlogK211(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                            ByVal _mStavka As Int16, ByVal _mSifraK211 As Int32, _
                            ByRef opPovVrednost As String)

        'ByVal _mSifraK211 As string staro

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKola As New SqlClient.SqlCommand("dbo.spUpisSlogK211", OkpDbVeza)

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
    Public Sub BrisanjeSlogRobaUI(ByVal ipTrans As SqlTransaction, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                                  ByVal _mKolaStavka As Int16, ByVal _mRobaStavka As Int16, _
                                  ByRef _mRetVal As Int32)

        ''ByVal mAkcija As String, 
        _mRetVal = 0

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.spBrisanjeSlogRobaUI", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        ''Dim inAkcija As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.Char, 3))
        ''inAkcija.Direction = ParameterDirection.Input
        ''spKomanda.Parameters("@inAkcija").Value = mAkcija

        Dim inRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int, 4))
        inRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRecID").Value = _opRecID

        Dim inStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanicaUnosa", SqlDbType.Char, 5))
        inStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanicaUnosa").Value = _StanicaUnosa

        Dim inKolaStavka As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inKolaStavka", SqlDbType.Int, 4))
        inKolaStavka.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inKolaStavka").Value = _mKolaStavka

        Dim inRobaStavka As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRobaStavka", SqlDbType.Int, 4))
        inRobaStavka.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRobaStavka").Value = _mRobaStavka

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@RetVal", SqlDbType.Int, 4))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@RetVal").Value = _mRetVal

        spKomanda.Transaction = ipTrans

        Try
            spKomanda.ExecuteNonQuery()
            _mRetVal = spKomanda.Parameters("@RetVal").Value

            ''spKomanda.ExecuteScalar()
            ''If spKomanda.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije obrisano!"
        Catch ex As Exception
            _mRetVal = ex.Message

            ''_mRetVal = Err.Description & " Greska u programu!"
        Catch sqlexp As Exception
            _mRetVal = sqlexp.Message

            ''_mRetVal = sqlexp.Message & " SQL greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Friend Sub UpisSlogKolaUI(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, ByVal _mKolaStavka As Int16, _
                            ByVal _IBK As String, ByVal _IBKOK As String, ByVal _Uprava As String, ByVal _Vlasnik As String, _
                            ByVal _Serija As String, ByVal _Osovine As Int16, ByVal _Tara As Int32, ByVal _GranTov As Int32, _
                            ByVal _Stitna As String, ByVal _TipKola As String, ByVal _Prevoznina As Decimal, ByVal _Naknada As Decimal, _
                            ByVal _ICF As String, _
                            ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogKola As New SqlClient.SqlCommand("dbo.spUpisSlogKolaUI", OkpDbVeza)

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
    Friend Sub UpisSlogRobaUI(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                            ByVal _mKolaStavka As Int16, ByVal _mRobaStavka As Int16, ByVal _NHM As String, ByVal _R As String, _
                            ByVal _SMasa As Int32, ByVal _RID As Int16, ByVal _UtiTip As String, ByVal _UtiIB As String, _
                            ByVal _UtiTara As Int32, ByVal _UtiRaster As Decimal, ByVal _UtiNHM As String, _
                            ByVal _UtiPredajniList As String, ByVal _UtiBrPlombe As String, _
                            ByVal _RacMasa As Int32, ByVal _VozStav As Decimal, _
                            ByRef opPovVrednost As String)


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogRoba As New SqlClient.SqlCommand("dbo.spUpisSlogRobaUI", OkpDbVeza) 'roba
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
    Friend Sub UpisSlogDencaneUI(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, _
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

        Dim uspUpisSlogDencane As New SqlClient.SqlCommand("dbo.spUpisSlogDencaneUI", OkpDbVeza) 'roba
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

    Friend Sub UpisSlogNaknadaUI(ByVal ipTrans As SqlTransaction, ByVal mAkcija As String, ByVal _opRecID As Int32, ByVal _StanicaUnosa As String, _
                               ByVal _tbUpravaOtp As String, ByVal _tbStanicaOtp As String, ByVal _tbBrojOtp As Int32, ByVal _DatumOtp As DateTime, _
                               ByVal _NaknadeStavka As Int16, ByVal _SifraNaknade As String, ByVal _IvicniBroj As String, ByVal _Iznos As Decimal, _
                               ByVal _Valuta As String, ByVal _Kolicina As Int32, ByVal _DanCas As Int32, ByVal _Placanje As String, ByVal _Vrsta As String, _
                               ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpisSlogNaknade As New SqlClient.SqlCommand("dbo.spUpisSlogNaknadeUI", OkpDbVeza)
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

        'Dim inIznos As SqlClient.SqlParameter = uspUpisSlogNaknade.Parameters.Add(New SqlClient.SqlParameter("@inIznos", SqlDbType.Decimal))  'Decimal
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
    Friend Sub KorigujNajaveUI2(ByVal ipTrans As SqlTransaction, ByVal _mNajava As String, _
                                ByVal _mBrojUg As String, ByVal _mObrGodina As String, _
                                ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspNajave As New SqlClient.SqlCommand("spUpdateNajavaVoza", OkpDbVeza)
        uspNajave.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspNajave.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inNajava As SqlClient.SqlParameter = uspNajave.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "KomBrojVoza", DataRowVersion.Current, _mNajava))
        Dim inBrojUg As SqlClient.SqlParameter = uspNajave.Parameters.Add(New SqlClient.SqlParameter("@inBrojUg", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "BrUgovora", DataRowVersion.Current, _mBrojUg))
        Dim inObrGodina As SqlClient.SqlParameter = uspNajave.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "RacGodina", DataRowVersion.Current, _mObrGodina))

        uspNajave.Transaction = ipTrans

        Try
            uspNajave.ExecuteNonQuery()
            If uspNajave.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u NajaveVoza!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspNajave.Dispose()
        End Try
    End Sub
    Friend Sub KorigujNajaveUI1(ByVal ipTrans As SqlTransaction, ByVal _mNajava As String, ByVal _mBrojUg As String, _
                                ByVal _mObrGodina As String, ByVal _mIBK As String, _
                                ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspNajave As New SqlClient.SqlCommand("spUpdateNajavaKola", OkpDbVeza)
        uspNajave.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspNajave.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inNajava As SqlClient.SqlParameter = uspNajave.Parameters.Add(New SqlClient.SqlParameter("@inNajava", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "KomBrojVoza", DataRowVersion.Current, _mNajava))
        Dim inBrojUg As SqlClient.SqlParameter = uspNajave.Parameters.Add(New SqlClient.SqlParameter("@inBrojUg", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "BrUgovora", DataRowVersion.Current, _mBrojUg))
        Dim inObrGodina As SqlClient.SqlParameter = uspNajave.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "RacGodina", DataRowVersion.Current, _mObrGodina))
        Dim inIBK As SqlClient.SqlParameter = uspNajave.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12, ParameterDirection.Input, False, 0, 0, "IBK", DataRowVersion.Current, _mIBK))

        uspNajave.Transaction = ipTrans

        Try
            uspNajave.ExecuteNonQuery()
            If uspNajave.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u NajaveVoza!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspNajave.Dispose()
        End Try
    End Sub

End Module
