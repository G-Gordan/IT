Imports System.Data.SqlClient
public Module CheckValid
    ' "povVrednost..." + " !" ==> SLOG NIJE PRONADjEN
    ' "povVrednost..." + " ?" ==> SQL greska
    ' "povVrednost..." + "??" ==> bilo koja druga greska
    ' "povVrednost..." + " ." ==> SLOG PRONADjEN
    public Function fcvKorisnikL(ByVal ipKorisnikL As String) As String
        Dim povVrednost As String = ""

        If Trim(ipKorisnikL) = "" Then
            povVrednost = "Nedozvoljena vrednost za polje Korisnik !"
        Else
            Dim sqlComm As New SqlClient.SqlCommand("SELECT @oppKorisnikL = KorisnikL FROM Korisnici WHERE KorisnikL = @ippKorisnikL", cnRoba)

            Dim ippKorisnikL As SqlClient.SqlParameter
            ippKorisnikL = sqlComm.Parameters.Add(New SqlClient.SqlParameter("@ippKorisnikL", SqlDbType.NVarChar, 10))
            ippKorisnikL.Direction = ParameterDirection.Input
            sqlComm.Parameters("@ippKorisnikL").Value = ipKorisnikL

            Dim oppKorisnikL As SqlClient.SqlParameter = sqlComm.Parameters.Add(New SqlClient.SqlParameter("@oppKorisnikL", SqlDbType.NVarChar, 10))
            oppKorisnikL.Direction = ParameterDirection.Output

            Try
                cnRoba.Open()
                sqlComm.ExecuteScalar()
                If IsDBNull(sqlComm.Parameters("@oppKorisnikL").Value) Then
                    povVrednost = "Korisnik: """ & ipKorisnikL & """ - NE POSTOJI !"
                Else
                    povVrednost = sqlComm.Parameters("@oppKorisnikL").Value & "."
                End If
            Catch SQLExp As SqlException
                povVrednost = SQLExp.Message & " ?"  'Greska - SQL greska
            Catch Exp As Exception
                povVrednost = Err.Description & "??" 'Greska - bilo koja
            Finally
                cnRoba.Close()
                sqlComm.Dispose()
            End Try
        End If
        Return povVrednost
    End Function
    public Function fcvKorGrupa(ByVal ipKorGrupa As String) As String
        Dim povVrednost As String = ""

        Dim sqlComm As New SqlClient.SqlCommand("SELECT @oppKorGrupa = KorGrupa FROM KorGrupe WHERE KorGrupa = @ippKorGrupa", cnRoba)

        Dim ippKorGrupa As SqlClient.SqlParameter
        ippKorGrupa = sqlComm.Parameters.Add(New SqlClient.SqlParameter("@ippKorGrupa", SqlDbType.NVarChar, 20))
        ippKorGrupa.Direction = ParameterDirection.Input
        sqlComm.Parameters("@ippKorGrupa").Value = ipKorGrupa

        Dim oppKorGrupa As SqlClient.SqlParameter = sqlComm.Parameters.Add(New SqlClient.SqlParameter("@oppKorGrupa", SqlDbType.NVarChar, 20))
        oppKorGrupa.Direction = ParameterDirection.Output

        Try
            cnRoba.Open()
            sqlComm.ExecuteScalar()
            If IsDBNull(sqlComm.Parameters("@oppKorGrupa").Value) Then
                povVrednost = "Korisnicka Grupa: """ & ipKorGrupa & """ - NE POSTOJI !"
            Else
                povVrednost = sqlComm.Parameters("@oppKorGrupa").Value & "."
            End If
        Catch SQLExp As SqlException
            povVrednost = SQLExp.Message & " ?"  'Greska - SQL greska
        Catch Exp As Exception
            povVrednost = Err.Description & "??" 'Greska - bilo koja
        Finally
            cnRoba.Close()
            sqlComm.Dispose()
        End Try
        Return povVrednost
    End Function
End Module
