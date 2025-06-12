Imports System.Data.SqlClient
Imports System.Data.OleDb
Module DbKonekcija
    '-------
    Public SQL_CONNECTION_STRING As String = ""
    Public OKPSQL_CONNECTION_STRING As String = ""
    Public Const OKP_CONNECTION_STRING As String = "Server=10.0.4.31;DataBase=OkpWinRoba;User=Radnik;Password=roba2006"
    Public OkpDbVeza As New SqlConnection(OKP_CONNECTION_STRING)
    'Public DbVeza As New SqlConnection
    'Public OkpDbVeza As New SqlConnection


    'Public Sub sUcitajINI(ByRef opPovVrednost As String)
    '    'INI datoteka mora biti u istom direktorijumu gde je i aplikacija

    '    opPovVrednost = ""
    '    Dim linijaText As String = ""
    '    Dim ii As Int16 = 0
    '    Dim parNaziv As String = ""
    '    Dim parVrednost As String = ""
    '    Try
    '        FileOpen(1, "Roba.ini", OpenMode.Input)
    '        Do Until EOF(1)
    '            parNaziv = ""
    '            parVrednost = ""
    '            linijaText = LineInput(1)
    '            ii = linijaText.IndexOf("=")
    '            parNaziv = linijaText.Substring(0, ii)
    '            parVrednost = linijaText.Substring(ii + 1)
    '            Select Case parNaziv
    '                Case "SQL_CONNECTION_STRING"
    '                    SQL_CONNECTION_STRING = parVrednost
    '                Case "OKPSQL_CONNECTION_STRING"
    '                    OKPSQL_CONNECTION_STRING = parVrednost
    '                Case Else
    '                    opPovVrednost = "Parametar: " & parNaziv & " iz INI datoteke - NE POSTOJI !"
    '            End Select
    '            linijaText = ""
    '        Loop
    '        If SQL_CONNECTION_STRING <> "" Then
    '            Dim connRoba As New SqlConnection(SQL_CONNECTION_STRING)
    '            Dim OkpconnRoba As New SqlConnection(OKPSQL_CONNECTION_STRING)
    '            DbVeza = connRoba
    '            OkpDbVeza = OkpconnRoba

    '        End If
    '    Catch ex As Exception
    '        opPovVrednost = "Greška u otvaranju INI datoteke !" & vbCrLf & Err.Description
    '    Finally
    '        FileClose(1)
    '    End Try
    'End Sub
End Module
