Imports System.Data.SqlClient
Module Upis
    Friend Sub UpisKomCoKorek(ByVal RecId As Integer, ByVal Sifra As Integer, ByVal Ugovor As String, ByVal Saobracaj As String, ByVal Mesec As String, ByVal Godina As String, ByVal Posiljka As String, ByVal Poj As Decimal, ByVal Gr As Decimal, ByVal Voz As Decimal, ByVal PPov As Decimal, ByVal PSmanj As Decimal, ByVal PStim As Decimal, ByVal GPov As Decimal, ByVal GSmanj As Decimal, ByVal GStim As Decimal, ByVal VPov As Decimal, ByVal VSmanj As Decimal, ByVal VStim As Decimal, ByVal BrKor As String, ByVal Ukupno As Decimal, ByRef outPovVred As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim UpisKomCoKorek As New SqlClient.SqlCommand("roba214kp.spUpisKomCoKorek5", OkpDbVeza)
        UpisKomCoKorek.CommandType = CommandType.StoredProcedure

        Dim inRecId As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inRecId", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, RecId))
        Dim inSifra As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inSifra", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, Sifra))
        Dim inUgovor As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, Ugovor))
        Dim inSaob As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inSaob", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saob", DataRowVersion.Current, Saobracaj))
        Dim inMesec As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Mesec", DataRowVersion.Current, Mesec))
        Dim inGodina As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Godina", DataRowVersion.Current, Godina))
        Dim inPosiljka As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPosiljka", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Posiljka", DataRowVersion.Current, Posiljka))
        Dim inPojed As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPojed", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pojed", DataRowVersion.Current, Poj))
        Dim inGrupa As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGrupa", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Grupa", DataRowVersion.Current, Gr))
        Dim inVoz As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVoz", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Voz", DataRowVersion.Current, Voz))
        Dim inPPov As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PPov", DataRowVersion.Current, PPov))
        Dim inPSmanj As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PSmanj", DataRowVersion.Current, PSmanj))
        Dim inPStim As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PStim", DataRowVersion.Current, PStim))
        Dim inGPov As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GPov", DataRowVersion.Current, GPov))
        Dim inGSmanj As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GSmanj", DataRowVersion.Current, GSmanj))
        Dim inGStim As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GStim", DataRowVersion.Current, GStim))
        Dim inVPov As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VPov", DataRowVersion.Current, VPov))
        Dim inVSmanj As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VSmanj", DataRowVersion.Current, VSmanj))
        Dim inVStim As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VStim", DataRowVersion.Current, VStim))
        Dim inBrKor As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inBrKor", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "BrKor", DataRowVersion.Current, BrKor))
        Dim inUkupno As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inUkupno", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Ukupno", DataRowVersion.Current, Ukupno))
        Dim izlPovVred As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 50, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        Try
            UpisKomCoKorek.ExecuteNonQuery()
            'If UpisKomCoKorek.Parameters("@RETURN_VALUE").Value = 0 Then outPovVred = "Ništa nije upisano!"
        Catch SQLExp As SqlException
            outPovVred = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            outPovVred = Err.Description     'Greska - bilo koja
        Finally
            UpisKomCoKorek.Dispose()
        End Try
    End Sub

    Friend Sub UpdKomCoKorek(ByVal Ugovor As String, ByVal Saobracaj As String, ByVal PPov As Decimal, ByVal PSmanj As Decimal, ByVal PStim As Decimal, ByVal GPov As Decimal, ByVal GSmanj As Decimal, ByVal GStim As Decimal, ByVal VPov As Decimal, ByVal VSmanj As Decimal, ByVal VStim As Decimal, ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim UpdKomCoKorek As New SqlClient.SqlCommand("spUpdKomCoKorek", OkpDbVeza)
        UpdKomCoKorek.CommandType = CommandType.StoredProcedure

        Dim inUgovor As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, Ugovor))
        Dim inSaob As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inSaob", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, Saobracaj))
        Dim inPPov As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PPov", DataRowVersion.Current, PPov))
        Dim inPSmanj As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PSmanj", DataRowVersion.Current, PSmanj))
        Dim inPStim As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PStim", DataRowVersion.Current, PStim))
        Dim inGPov As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GPov", DataRowVersion.Current, GPov))
        Dim inGSmanj As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GSmanj", DataRowVersion.Current, GSmanj))
        Dim inGStim As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GStim", DataRowVersion.Current, GStim))
        Dim inVPov As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VPov", DataRowVersion.Current, VPov))
        Dim inVSmanj As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VSmanj", DataRowVersion.Current, VSmanj))
        Dim inVStim As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VStim", DataRowVersion.Current, VStim))
        Dim outRetVal As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        'Dim izlRetVal As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Int))
        outRetVal.Direction = ParameterDirection.Output
        UpdKomCoKorek.Parameters("@outRetVal").Value = opPovVrednost
        Try
            UpdKomCoKorek.ExecuteScalar()

            opPovVrednost = UpdKomCoKorek.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            UpdKomCoKorek.Dispose()
        End Try
        OkpDbVeza.Close()
    End Sub

    'Friend Sub UpdSlogKalk11(ByVal Ugovor As String, ByVal Saobracaj As String, ByVal PPov As Decimal, ByVal PSmanj As Decimal, ByVal PStim As Decimal, ByVal GPov As Decimal, ByVal GSmanj As Decimal, ByVal GStim As Decimal, ByVal VPov As Decimal, ByVal VSmanj As Decimal, ByVal VStim As Decimal, ByRef opPovVrednost As String)
    Friend Sub UpdSlogKalk11(ByVal tlPrevUp As Decimal, ByVal tlPrevFr As Decimal, ByVal tlNakFr As Decimal, ByVal tlNakUp As Decimal, ByVal tlNakCo As Decimal, ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim UpdSlogKalk11 As New SqlClient.SqlCommand("spUpdSlogKalk11", OkpDbVeza)
        UpdSlogKalk11.CommandType = CommandType.StoredProcedure
        Dim intlPrevUp As SqlClient.SqlParameter = UpdSlogKalk11.Parameters.Add(New SqlClient.SqlParameter("@intlPrevUp", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlPrevUp", DataRowVersion.Current, tlPrevUp))
        Dim intlPrevFr As SqlClient.SqlParameter = UpdSlogKalk11.Parameters.Add(New SqlClient.SqlParameter("@intlPrevFr", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlPrevUp", DataRowVersion.Current, tlPrevFr))
        Dim intlNakFr As SqlClient.SqlParameter = UpdSlogKalk11.Parameters.Add(New SqlClient.SqlParameter("@intlNakFr", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlNakFr", DataRowVersion.Current, tlNakFr))
        Dim intlNakUp As SqlClient.SqlParameter = UpdSlogKalk11.Parameters.Add(New SqlClient.SqlParameter("@intlNakUp", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlNakUp", DataRowVersion.Current, tlNakUp))
        Dim intlNakCo As SqlClient.SqlParameter = UpdSlogKalk11.Parameters.Add(New SqlClient.SqlParameter("@intlNakCo", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "tlNakCo", DataRowVersion.Current, tlNakCo))

        'Dim inUgovor As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, Ugovor))
        'Dim inSaob As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inSaob", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, Saobracaj))
        'Dim inPPov As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PPov", DataRowVersion.Current, PPov))
        'Dim inPSmanj As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PSmanj", DataRowVersion.Current, PSmanj))
        'Dim inPStim As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PStim", DataRowVersion.Current, PStim))
        'Dim inGPov As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GPov", DataRowVersion.Current, GPov))
        'Dim inGSmanj As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GSmanj", DataRowVersion.Current, GSmanj))
        'Dim inGStim As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GStim", DataRowVersion.Current, GStim))
        'Dim inVPov As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VPov", DataRowVersion.Current, VPov))
        'Dim inVSmanj As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VSmanj", DataRowVersion.Current, VSmanj))
        'Dim inVStim As SqlClient.SqlParameter = UpdKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VStim", DataRowVersion.Current, VStim))
        Dim outRetVal As SqlClient.SqlParameter = UpdSlogKalk11.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        'Dim izlRetVal As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Int))
        outRetVal.Direction = ParameterDirection.Output
        UpdSlogKalk11.Parameters("@outRetVal").Value = opPovVrednost
        Try
            UpdSlogKalk11.ExecuteScalar()

            opPovVrednost = UpdSlogKalk11.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            UpdSlogKalk11.Dispose()
        End Try
        OkpDbVeza.Close()
    End Sub

    Friend Sub NovaKomCoKorek(ByVal Ugovor As String, ByVal Saobracaj As String, ByVal Mesec As String, ByVal Godina As String, ByVal PPov As Decimal, ByVal PSmanj As Decimal, ByVal PStim As Decimal, ByVal GPov As Decimal, ByVal GSmanj As Decimal, ByVal GStim As Decimal, ByVal VPov As Decimal, ByVal VSmanj As Decimal, ByVal VStim As Decimal, ByRef opPovVrednost As String)

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim NovaKomCoKorek As New SqlClient.SqlCommand("spNovaKomCoKorek", OkpDbVeza)
        NovaKomCoKorek.CommandType = CommandType.StoredProcedure

        Dim inUgovor As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, Ugovor))
        Dim inSaob As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inSaob", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, Saobracaj))
        Dim inMesec As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Mesec", DataRowVersion.Current, Mesec))
        Dim inGodina As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Godina", DataRowVersion.Current, Godina))
        Dim inPPov As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PPov", DataRowVersion.Current, PPov))
        Dim inPSmanj As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PSmanj", DataRowVersion.Current, PSmanj))
        Dim inPStim As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PStim", DataRowVersion.Current, PStim))
        Dim inGPov As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GPov", DataRowVersion.Current, GPov))
        Dim inGSmanj As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GSmanj", DataRowVersion.Current, GSmanj))
        Dim inGStim As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GStim", DataRowVersion.Current, GStim))
        Dim inVPov As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VPov", DataRowVersion.Current, VPov))
        Dim inVSmanj As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VSmanj", DataRowVersion.Current, VSmanj))
        Dim inVStim As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VStim", DataRowVersion.Current, VStim))
        Dim outRetVal As SqlClient.SqlParameter = NovaKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        'Dim izlRetVal As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Int))
        outRetVal.Direction = ParameterDirection.Output
        NovaKomCoKorek.Parameters("@outRetVal").Value = opPovVrednost
        Try
            NovaKomCoKorek.ExecuteScalar()

            opPovVrednost = NovaKomCoKorek.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            NovaKomCoKorek.Dispose()
        End Try
        OkpDbVeza.Close()
    End Sub

    Friend Sub BrisiKomCoKorek(ByVal Mesec As String, ByVal Godina As String)

        'BrisiKomCoKorek(ByVal Ugovor As String, ByVal Saobracaj As String, ByVal Mesec As String, ByVal Godina As String, ByVal PPov As Decimal, ByVal PSmanj As Decimal, ByVal PStim As Decimal, ByVal GPov As Decimal, ByVal GSmanj As Decimal, ByVal GStim As Decimal, ByVal VPov As Decimal, ByVal VSmanj As Decimal, ByVal VStim As Decimal, ByRef opPovVrednost As String)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim BrisiKomCoKorek As New SqlClient.SqlCommand("spNovaKomCoKorekB", OkpDbVeza)
        BrisiKomCoKorek.CommandType = CommandType.StoredProcedure

        'Dim inUgovor As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inUgovor", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "Ugovor", DataRowVersion.Current, Ugovor))
        'Dim inSaob As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inSaob", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, Saobracaj))
        Dim inMesec As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Mesec", DataRowVersion.Current, Mesec))
        Dim inGodina As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Godina", DataRowVersion.Current, Godina))
        'Dim inPPov As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PPov", DataRowVersion.Current, PPov))
        'Dim inPSmanj As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PSmanj", DataRowVersion.Current, PSmanj))
        'Dim inPStim As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inPStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PStim", DataRowVersion.Current, PStim))
        'Dim inGPov As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GPov", DataRowVersion.Current, GPov))
        'Dim inGSmanj As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GSmanj", DataRowVersion.Current, GSmanj))
        'Dim inGStim As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inGStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "GStim", DataRowVersion.Current, GStim))
        'Dim inVPov As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVPov", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VPov", DataRowVersion.Current, VPov))
        'Dim inVSmanj As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVSmanj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VSmanj", DataRowVersion.Current, VSmanj))
        'Dim inVStim As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@inVStim", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VStim", DataRowVersion.Current, VStim))
        'Dim outRetVal As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        'Dim outRetVal As SqlClient.SqlParameter = BrisiKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Char, 30, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        ''Dim izlRetVal As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Int))
        'outRetVal.Direction = ParameterDirection.Output
        'BrisiKomCoKorek.Parameters("@outRetVal").Value = opPovVrednost
        Try
            BrisiKomCoKorek.ExecuteScalar()

            'opPovVrednost = BrisiKomCoKorek.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            '    opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            '    opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            BrisiKomCoKorek.Dispose()
        End Try
        OkpDbVeza.Close()
    End Sub

End Module



