Imports System.Data.SqlClient
Module Upis
    Friend Sub UpisKomCoKorek(ByVal Sifra As Integer, ByVal Ugovor As String, ByVal Saobracaj As String, ByVal Mesec As String, ByVal Godina As String, ByVal Posiljka As String, ByVal Poj As Decimal, ByVal Gr As Decimal, ByVal Voz As Decimal, ByVal PPov As Decimal, ByVal PSmanj As Decimal, ByVal PStim As Decimal, ByVal GPov As Decimal, ByVal GSmanj As Decimal, ByVal GStim As Decimal, ByVal VPov As Decimal, ByVal VSmanj As Decimal, ByVal VStim As Decimal, ByVal BrKor As String, ByVal Ukupno As Decimal, ByRef opPovVrednost As Integer)

        Dim UpisKomCoKorek As New SqlClient.SqlCommand("spUpisKomCoKorek", OkpDbVeza)
        UpisKomCoKorek.CommandType = CommandType.StoredProcedure

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
        'Dim outRetVal As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim izlRetVal As SqlClient.SqlParameter = UpisKomCoKorek.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Int))
        izlRetVal.Direction = ParameterDirection.Output
        UpisKomCoKorek.Parameters("@outRetVal").Value = opPovVrednost
        Try
            UpisKomCoKorek.ExecuteScalar()

            opPovVrednost = UpisKomCoKorek.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            UpisKomCoKorek.Dispose()
        End Try

    End Sub

End Module
