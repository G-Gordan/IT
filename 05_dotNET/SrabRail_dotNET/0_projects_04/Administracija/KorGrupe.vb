Imports System.Data.SqlClient
Module KorGrupe
    Friend ds As New DataSet("KorGrupe")
    Friend dt As DataTable = New DataTable("KorGrupe")

    Friend Akcija As String = ""
    Friend dwClosed As Integer = 0  ' Dialog Window: 0 - CANCEL, ESC, CLOSE ; 1 - OK

    'Polja za formu
    Friend f_KorGrupa As String = ""
    Friend f_Napomena As String = ""
    Friend f_ts As String = ""

    Friend Sub subKorGrupeMan(ByRef GreskaOpisTrans As String)
        Dim rv As Int16
        Dim VBGreskaOpisTrans As String = ""
        Dim SQLGreskaOpisTrans As String = ""

        Dim uspKorGrupeMan As New SqlClient.SqlCommand("uspKorGrupeMan", cnRoba)
        uspKorGrupeMan.CommandType = CommandType.StoredProcedure

        ' Definisanje Parametara za Uskladistenu Proceduru
        Dim RetVal As SqlClient.SqlParameter
        RetVal = uspKorGrupeMan.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5))
        RetVal.Direction = ParameterDirection.ReturnValue

        Dim ipAkcija As SqlClient.SqlParameter
        ipAkcija = uspKorGrupeMan.Parameters.Add(New SqlClient.SqlParameter("@ipAkcija", SqlDbType.Char, 6))
        ipAkcija.Direction = ParameterDirection.Input
        uspKorGrupeMan.Parameters("@ipAkcija").Value = Akcija

        Dim ipKorGrupa As SqlClient.SqlParameter
        ipKorGrupa = uspKorGrupeMan.Parameters.Add(New SqlClient.SqlParameter("@ipKorGrupa", SqlDbType.NChar, 10))
        ipKorGrupa.Direction = ParameterDirection.Input
        uspKorGrupeMan.Parameters("@ipKorGrupa").Value = f_KorGrupa

        Dim ipNapomena As SqlClient.SqlParameter
        ipNapomena = uspKorGrupeMan.Parameters.Add(New SqlClient.SqlParameter("@ipNapomena", SqlDbType.NVarChar, 3000))
        ipNapomena.Direction = ParameterDirection.Input
        uspKorGrupeMan.Parameters("@ipNapomena").Value = f_Napomena

        Dim ipTStamp As SqlClient.SqlParameter
        ipTStamp = uspKorGrupeMan.Parameters.Add(New SqlClient.SqlParameter("@ipTStamp", SqlDbType.Char, 19))
        ipTStamp.Direction = ParameterDirection.Input
        uspKorGrupeMan.Parameters("@ipTStamp").Value = ts()

        Dim ipKorisnik As SqlClient.SqlParameter
        ipKorisnik = uspKorGrupeMan.Parameters.Add(New SqlClient.SqlParameter("@ipKorisnik", SqlDbType.Char, 10))
        ipKorisnik.Direction = ParameterDirection.Input
        uspKorGrupeMan.Parameters("@ipKorisnik").Value = gv_Korisnik

        cnRoba.Open()
        Try
            uspKorGrupeMan.ExecuteNonQuery()
            cnRoba.BeginTransaction.Commit()
        Catch SQLExp As SqlException
            cnRoba.BeginTransaction.Rollback()
            VBGreskaOpisTrans = SQLExp.Message & vbCrLf
        Catch Exp As Exception
            cnRoba.BeginTransaction.Rollback()
            VBGreskaOpisTrans = Err.Description & vbCrLf
        Finally
            cnRoba.Close()
            uspKorGrupeMan.Dispose()
        End Try
        rv = uspKorGrupeMan.Parameters("@RETURN_VALUE").Value
        If rv > 0 Then
            VBGreskaOpisTrans = VBGreskaOpisTrans & "GREŠKA_TRANSAKCIJE_BROJ_" & rv.ToString() & vbCrLf
        End If
        GreskaOpisTrans = VBGreskaOpisTrans
    End Sub
End Module
