Imports System.Data.SqlClient

Module ModuleUtil
    Public Sub sNadjiNaziv(ByVal ipTabela As String, ByVal ipSifra1 As String, _
                              ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                              ByRef opCount As Int16, ByRef opNaziv As String, _
                              ByRef opPovVrednost As String)

        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True

        Select Case ipTabela
            Case "GrPrel"
                sqlText = "SELECT SifraPrelaza FROM UicPrelazi WHERE   Uprava1 = '" & ipSifra1 & "' AND Uprava2 = '" & ipSifra2 & "'"
            Case "UicStanice"
                sqlText = "SELECT Naziv FROM UicStanice WHERE   _SifraStanice = '" & ipSifra1 & "' AND _SifraUprave = '" & ipSifra2 & "'"
            Case "UserTab"
                sqlText = "SELECT UserID, Lozinka FROM UserTab WHERE UserID = '" & ipSifra1 & "' AND Lozinka = '" & ipSifra2 & "'"
            Case "NHMPozicije"
                sqlText = "SELECT Naziv FROM NHMPozicije WHERE NHMPozicije.NHMSifra = '" & ipSifra1 & "'"
            Case Else
                opPovVrednost = "Data Table: " & ipTabela & " - NE POSTOJI !!! , Greska u Programu"
        End Select

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

    'Public Sub Update140(ByVal ipTrans As SqlTransaction, ByRef opPovVrednost As String)

    Public Sub Update140(ByVal ipTrans As SqlTransaction, ByVal Saobracaj As String, ByVal RacMesec As String, ByVal RacGodina As String, ByRef opPovVrednost As String)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpdate As New SqlClient.SqlCommand("spUpdate140", OkpDbVeza)

        uspUpdate.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpdate.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 15, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpdate.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, Saobracaj))
        Dim inRacMesec As SqlClient.SqlParameter = uspUpdate.Parameters.Add(New SqlClient.SqlParameter("@inRacMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "RacMesec", DataRowVersion.Current, RacMesec))
        Dim inRacGodina As SqlClient.SqlParameter = uspUpdate.Parameters.Add(New SqlClient.SqlParameter("@inRacGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "RacGodina", DataRowVersion.Current, RacGodina))
        'Dim inSmer As SqlClient.SqlParameter = uspUpdate.Parameters.Add(New SqlClient.SqlParameter("@inSmer", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Smer", DataRowVersion.Current, Smer))
        '--------------------------------------------------------------------------------------------------------
        uspUpdate.Transaction = ipTrans

        Try
            uspUpdate.ExecuteNonQuery()

            'If uspUpdate.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u ZsZal140!"

        Catch SQLExp As SqlException
            MsgBox(SQLExp)
            'opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            MsgBox("Ništa nije upisano u ZsZal140!")
            'opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpdate.Dispose()
        End Try

    End Sub

    Public Sub Update140Ned(ByVal ipTrans As SqlTransaction, ByVal Saobracaj As String, ByVal Mesec As String, ByVal Godina As String, ByRef opPovVrednost As String)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpdateNed As New SqlClient.SqlCommand("spUpdate140Ned", OkpDbVeza)

        uspUpdateNed.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 15, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, Saobracaj))
        'Dim inSmer As SqlClient.SqlParameter = uspUpdate.Parameters.Add(New SqlClient.SqlParameter("@inSmer", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Smer", DataRowVersion.Current, Smer))
        '--------------------------------------------------------------------------------------------------------
        Dim inMesec As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@inMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Mesec", DataRowVersion.Current, Mesec))
        Dim inGodina As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@inGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Godina", DataRowVersion.Current, Godina))


        uspUpdateNed.Transaction = ipTrans

        Try
            uspUpdateNed.ExecuteNonQuery()

            'If uspUpdate.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u ZsZal140!"

        Catch SQLExp As SqlException
            MsgBox(SQLExp)
            'opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            MsgBox("Ništa nije upisano u ZsZal140!")
            'opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpdateNed.Dispose()
        End Try

    End Sub

    Public Sub Update140Ned_K(ByVal ipTrans As SqlTransaction, ByVal Saobracaj As String, ByRef opPovVrednost As String)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpdateNed As New SqlClient.SqlCommand("spUpdate140Ned_K", OkpDbVeza)

        uspUpdateNed.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 15, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, Saobracaj))
        'Dim inMesec As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@inMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "Mesec", DataRowVersion.Current, Mesec))
        '--------------------------------------------------------------------------------------------------------
        uspUpdateNed.Transaction = ipTrans

        Try
            uspUpdateNed.ExecuteNonQuery()

            'If uspUpdate.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u ZsZal140!"

        Catch SQLExp As SqlException
            MsgBox(SQLExp)
            'opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            MsgBox("Ništa nije upisano u ZsZal140!")
            'opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpdateNed.Dispose()
        End Try

    End Sub

    Public Sub VanRaspUn140(ByVal ipTrans As SqlTransaction, ByVal Saobracaj As String, ByVal ObrMesec As String, ByVal ObrGodina As String, ByRef opPovVrednost As String)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspUpdateNed As New SqlClient.SqlCommand("spVanRaspUn140", OkpDbVeza)

        uspUpdateNed.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 15, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inSaobracaj As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, Saobracaj))
        Dim inObrMesec As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "ObrMesec", DataRowVersion.Current, ObrMesec))
        Dim inObrGodina As SqlClient.SqlParameter = uspUpdateNed.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "ObrGodina", DataRowVersion.Current, ObrGodina))

        '--------------------------------------------------------------------------------------------------------
        uspUpdateNed.Transaction = ipTrans

        Try
            uspUpdateNed.ExecuteNonQuery()

            'If uspUpdate.Parameters("@RETURN_VALUE").Value = 0 Then opPovVrednost = "Ništa nije upisano u ZsZal140!"

        Catch SQLExp As SqlException
            MsgBox(SQLExp)
            'opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            MsgBox("Nije izvršena procedura!")
            'opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpdateNed.Dispose()
        End Try

    End Sub

    Public Sub UpdateBlag(ByVal ipTrans As SqlTransaction, ByVal RacMesec As String, ByVal RacGodina As String, ByRef outRetVal As String)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim uspBlag As New SqlClient.SqlCommand("spBlag", OkpDbVeza)

        uspBlag.CommandType = CommandType.StoredProcedure

        'Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char, 50))
        'izlRetVal.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outRetVal").Value = outRetVal

        Dim izlRetVal As SqlClient.SqlParameter = uspBlag.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 30, ParameterDirection.Output, True, 0, 0, "", DataRowVersion.Current, ""))
        'Dim inSaobracaj As SqlClient.SqlParameter = uspBlag.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "Saobracaj", DataRowVersion.Current, Saobracaj))
        Dim inRacMesec As SqlClient.SqlParameter = uspBlag.Parameters.Add(New SqlClient.SqlParameter("@inRacMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "RacMesec", DataRowVersion.Current, RacMesec))
        Dim inRacGodina As SqlClient.SqlParameter = uspBlag.Parameters.Add(New SqlClient.SqlParameter("@inRacGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "RacGodina", DataRowVersion.Current, RacGodina))
        'Dim inSmer As SqlClient.SqlParameter = uspBlag.Parameters.Add(New SqlClient.SqlParameter("@inSmer", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "Smer", DataRowVersion.Current, Smer))
        '--------------------------------------------------------------------------------------------------------
        uspBlag.Transaction = ipTrans

        'If uspBlag.Parameters("@outRetVal").Value = 0 Then rv1 = "Blagajne za Novi Sad nisu ažurirane!"
        outRetVal = uspBlag.Parameters("@outRetVal").Value
        Try
            uspBlag.ExecuteNonQuery()


        Catch SQLExp As SqlException
            MsgBox(SQLExp)
            outRetVal = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            MsgBox("Blagajne nisu ažurirane!")
            outRetVal = Err.Description     'Greska - bilo koja
        Finally
            uspBlag.Dispose()
        End Try

    End Sub
End Module
