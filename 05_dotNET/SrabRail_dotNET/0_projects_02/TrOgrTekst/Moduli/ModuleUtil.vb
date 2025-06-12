Imports System.Data.SqlClient

Module ModuleUtil

    'Public WebVeza As New SqlConnection(SQL_CONNECTION_STRING)

    'Public Sub sNadjiNaziv(ByVal ipTabela As String, ByVal ipSifra1 As String, ByVal ipSifra2 As String, ByVal ipSifra3 As String, ByRef opNaziv As String, ByRef opPovVrednost As String)
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
            Dim uspKomanda As New SqlClient.SqlCommand(sqlText, WebVeza)
            Try
                If WebVeza.State = ConnectionState.Closed Then
                    WebVeza.Open()
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
                If closeConn Then WebVeza.Close()
                uspKomanda.Dispose()
            End Try
        End If
    End Sub

End Module
