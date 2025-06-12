Imports System.Data.SqlClient
Module Module1
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

End Module
