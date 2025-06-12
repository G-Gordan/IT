Imports System.Data.SqlClient

Module DbKonekcija
    '-------
    Public SQL_CONNECTION_STRING As String = ""
    Public OKPSQL_CONNECTION_STRING As String = ""
    Public CENE_CONNECTION_STRING As String = ""
    Public ZSSQL_CONNECTION_STRING As String = ""
    Public OkpDbVeza As New SqlConnection
    Public DbVeza As New SqlConnection
    Public DbVezaCene As New SqlConnection
    Public ZsDbVeza As New SqlConnection
    Public cnWinRoba As New SqlConnection
    Public eCimVeza As New SqlConnection
    Public StanicaUnosa As String = ""
    Public UlazniTranzit As String = ""
    Public BlagajnaUnosa As String = ""
    Public eCimDa As String = ""
    Public CarinskiAgent As String = ""
    Public PrikazKalkulacije As String = ""
    Public IpZaRazmenu As String = ""
    Public FolderXml As String = ""
    Public FolderFtp As String = ""

    Public Sub sUcitajINI(ByRef opPovVrednost As String)     
        'INI datoteka mora biti u istom direktorijumu gde je i aplikacija

        opPovVrednost = ""
        Dim linijaText As String = ""
        Dim ii As Int16 = 0
        Dim parNaziv As String = ""
        Dim parVrednost As String = ""
        Try
            FileOpen(1, "Roba.ini", OpenMode.Input)
            Do Until EOF(1)
                parNaziv = ""
                parVrednost = ""
                linijaText = LineInput(1)
                ii = linijaText.IndexOf("=")
                parNaziv = linijaText.Substring(0, ii)
                parVrednost = linijaText.Substring(ii + 1)
                Select Case parNaziv
                    Case "SQL_CONNECTION_STRING"
                        SQL_CONNECTION_STRING = parVrednost
                    Case "CENE_CONNECTION_STRING"
                        CENE_CONNECTION_STRING = parVrednost
                    Case "ZSSQL_CONNECTION_STRING"
                        ZSSQL_CONNECTION_STRING = parVrednost
                    Case "OKPSQL_CONNECTION_STRING"
                        OKPSQL_CONNECTION_STRING = parVrednost
                    Case "STANICA"
                        StanicaUnosa = parVrednost
                    Case "BLAGAJNA"
                        BlagajnaUnosa = parVrednost
                    Case "AGENT"
                        CarinskiAgent = parVrednost
                    Case "WHITE"
                        PrikazKalkulacije = parVrednost
                    Case "IP"
                        IpZaRazmenu = parVrednost
                    Case "FB"
                        FolderXml = parVrednost
                    Case "FTP"
                        FolderFtp = parVrednost
                    Case "ECIM"
                        eCimDa = parVrednost
                    Case Else
                        opPovVrednost = "Parametar: " & parNaziv & " iz INI datoteke - NE POSTOJI !"
                End Select
                linijaText = ""
            Loop
            If SQL_CONNECTION_STRING <> "" And CENE_CONNECTION_STRING <> "" Then
                Dim connRoba As New SqlConnection(SQL_CONNECTION_STRING)
                Dim OkpconnRoba As New SqlConnection(OKPSQL_CONNECTION_STRING)
                Dim connCene As New SqlConnection(CENE_CONNECTION_STRING)
                Dim eCimconnRoba As New SqlConnection(ZSSQL_CONNECTION_STRING)
                DbVeza = connRoba
                OkpDbVeza = OkpconnRoba
                cnWinRoba = connRoba
                DbVezaCene = connCene
                eCimVeza = eCimconnRoba
            End If
            If ZSSQL_CONNECTION_STRING <> "" Then
                Dim ZsconnRoba As New SqlConnection(ZSSQL_CONNECTION_STRING)
                ZsDbVeza = ZsconnRoba
            End If
        Catch ex As Exception
            opPovVrednost = "Greška u otvaranju INI datoteke !" & vbCrLf & Err.Description
        Finally
            FileClose(1)
        End Try
    End Sub
    Public Sub sUcitajINIHCD(ByRef opPovVrednost As String)
        'INI datoteka mora biti u istom direktorijumu gde je i aplikacija

        opPovVrednost = ""
        Dim linijaText As String = ""
        Dim ii As Int16 = 0
        Dim parNaziv As String = ""
        Dim parVrednost As String = ""
        Try
            'FileOpen(1, "Roba.ini", OpenMode.Input)
            'Do Until EOF(1)
            '    parNaziv = ""
            '    parVrednost = ""
            '    linijaText = LineInput(1)
            '    ii = linijaText.IndexOf("=")
            '    parNaziv = linijaText.Substring(0, ii)
            '    parVrednost = linijaText.Substring(ii + 1)
            '    Select Case parNaziv
            '        Case "SQL_CONNECTION_STRING"
            '            SQL_CONNECTION_STRING = parVrednost
            '        Case "CENE_CONNECTION_STRING"
            '            CENE_CONNECTION_STRING = parVrednost
            '        Case "ZSSQL_CONNECTION_STRING"
            '            ZSSQL_CONNECTION_STRING = parVrednost
            '        Case "OKPSQL_CONNECTION_STRING"
            '            OKPSQL_CONNECTION_STRING = parVrednost
            '        Case "STANICA"
            '            StanicaUnosa = parVrednost
            '        Case "BLAGAJNA"
            '            BlagajnaUnosa = parVrednost
            '        Case "AGENT"
            '            CarinskiAgent = parVrednost
            '        Case "WHITE"
            '            PrikazKalkulacije = parVrednost
            '        Case "IP"
            '            IpZaRazmenu = parVrednost
            '        Case "FB"
            '            FolderXml = parVrednost
            '        Case "FTP"
            '            FolderFtp = parVrednost
            '        Case "ECIM"
            '            eCimDa = parVrednost
            '        Case Else
            '            opPovVrednost = "Parametar: " & parNaziv & " iz INI datoteke - NE POSTOJI !"
            '    End Select
            '    linijaText = ""
            'Loop
            SQL_CONNECTION_STRING = "Server=10.0.4.31;DataBase=WinRoba;User=Radnik;Password=roba2006"
            OKPSQL_CONNECTION_STRING = "Server=10.0.4.31;DataBase=OkpWinRoba;User=Radnik;Password=roba2006"
            CENE_CONNECTION_STRING = "Server=10.0.4.31;DataBase=WinRobaCene;User=Radnik;Password=roba2006"
            ZSSQL_CONNECTION_STRING = "Server=10.0.4.31;DataBase=E-CIM;User=ecim;Password=ecim"
            StanicaUnosa = "1 - 00005 Okp Lokal"
            BlagajnaUnosa = ""
            CarinskiAgent = "0"
            PrikazKalkulacije = "D"
            IpZaRazmenu = ""
            FolderXml = ""
            FolderFtp = ""
            eCimDa = "N"

            'SQL_CONNECTION_STRING=Server=10.0.4.31;DataBase=WinRoba;User=Radnik;Password=roba2006
            'OKPSQL_CONNECTION_STRING=Server=10.0.4.31;DataBase=OkpWinRoba;User=Radnik;Password=roba2006
            'CENE_CONNECTION_STRING=Server=10.0.4.31;DataBase=WinRobaCene;User=Radnik;Password=roba2006
            'ZSSQL_CONNECTION_STRING=Server=10.0.4.31;DataBase=E-CIM;User=ecim;Password=ecim
            'STANICA=1 - 00005 Okp Lokal
            'BLAGAJNA=
            'AGENT = 0
            'WHITE = D
            'IP=c:\
            'FB=d:\Roba\FbXml\
            'FTP=\\10.0.80.45\FBXML\OUT\
            'ECIM = N




            If SQL_CONNECTION_STRING <> "" And CENE_CONNECTION_STRING <> "" Then
                Dim connRoba As New SqlConnection(SQL_CONNECTION_STRING)
                Dim OkpconnRoba As New SqlConnection(OKPSQL_CONNECTION_STRING)
                Dim connCene As New SqlConnection(CENE_CONNECTION_STRING)
                Dim eCimconnRoba As New SqlConnection(ZSSQL_CONNECTION_STRING)
                DbVeza = connRoba
                OkpDbVeza = OkpconnRoba
                cnWinRoba = connRoba
                DbVezaCene = connCene
                eCimVeza = eCimconnRoba
            End If
            If ZSSQL_CONNECTION_STRING <> "" Then
                Dim ZsconnRoba As New SqlConnection(ZSSQL_CONNECTION_STRING)
                ZsDbVeza = ZsconnRoba
            End If
        Catch ex As Exception
            opPovVrednost = "Greška u otvaranju INI datoteke !" & vbCrLf & Err.Description
        Finally
            FileClose(1)
        End Try
    End Sub
    Public Sub sUcitajINIHCDLokalSQL(ByRef opPovVrednost As String)
        'INI datoteka mora biti u istom direktorijumu gde je i aplikacija

        opPovVrednost = ""
        Dim linijaText As String = ""
        Dim ii As Int16 = 0
        Dim parNaziv As String = ""
        Dim parVrednost As String = ""
        Try
            'FileOpen(1, "Roba.ini", OpenMode.Input)
            'Do Until EOF(1)
            '    parNaziv = ""
            '    parVrednost = ""
            '    linijaText = LineInput(1)
            '    ii = linijaText.IndexOf("=")
            '    parNaziv = linijaText.Substring(0, ii)
            '    parVrednost = linijaText.Substring(ii + 1)
            '    Select Case parNaziv
            '        Case "SQL_CONNECTION_STRING"
            '            SQL_CONNECTION_STRING = parVrednost
            '        Case "CENE_CONNECTION_STRING"
            '            CENE_CONNECTION_STRING = parVrednost
            '        Case "ZSSQL_CONNECTION_STRING"
            '            ZSSQL_CONNECTION_STRING = parVrednost
            '        Case "OKPSQL_CONNECTION_STRING"
            '            OKPSQL_CONNECTION_STRING = parVrednost
            '        Case "STANICA"
            '            StanicaUnosa = parVrednost
            '        Case "BLAGAJNA"
            '            BlagajnaUnosa = parVrednost
            '        Case "AGENT"
            '            CarinskiAgent = parVrednost
            '        Case "WHITE"
            '            PrikazKalkulacije = parVrednost
            '        Case "IP"
            '            IpZaRazmenu = parVrednost
            '        Case "FB"
            '            FolderXml = parVrednost
            '        Case "FTP"
            '            FolderFtp = parVrednost
            '        Case "ECIM"
            '            eCimDa = parVrednost
            '        Case Else
            '            opPovVrednost = "Parametar: " & parNaziv & " iz INI datoteke - NE POSTOJI !"
            '    End Select
            '    linijaText = ""
            'Loop

            SQL_CONNECTION_STRING = "Server=(local);DataBase=WinRoba;Integrated Security=SSPI"
            OKPSQL_CONNECTION_STRING = "Server=(local);DataBase=OkpWinRoba;Integrated Security=SSPI"
            CENE_CONNECTION_STRING = "Server=(local);DataBase=WinRobaCene;Integrated Security=SSPI"
            ZSSQL_CONNECTION_STRING = "Server=(local);DataBase=WinRoba;Integrated Security=SSPI"
            StanicaUnosa = "1 - 00005 Okp Lokal"
            BlagajnaUnosa = ""
            CarinskiAgent = "0"
            PrikazKalkulacije = "D"
            IpZaRazmenu = ""
            FolderXml = ""
            FolderFtp = ""
            eCimDa = "N"

            'SQL_CONNECTION_STRING=Server=(local);DataBase=WinRoba;Integrated Security=SSPI
            'OKPSQL_CONNECTION_STRING=Server=(local);DataBase=OkpWinRoba;Integrated Security=SSPI
            'CENE_CONNECTION_STRING=Server=(local);DataBase=WinRobaCene;Integrated Security=SSPI
            'ZSSQL_CONNECTION_STRING=Server=(local);DataBase=WinRoba;Integrated Security=SSPI
            'STANICA=1 - 00005 Okp Lokal
            'BLAGAJNA=
            'AGENT = PROODOS
            'WHITE = D
            'IP=c:\
            'FB=d:\Roba\FbXml\
            'FTP=\\10.0.80.45\FBXML\OUT\
            'ECIM = N


            If SQL_CONNECTION_STRING <> "" And CENE_CONNECTION_STRING <> "" Then
                Dim connRoba As New SqlConnection(SQL_CONNECTION_STRING)
                Dim OkpconnRoba As New SqlConnection(OKPSQL_CONNECTION_STRING)
                Dim connCene As New SqlConnection(CENE_CONNECTION_STRING)
                Dim eCimconnRoba As New SqlConnection(ZSSQL_CONNECTION_STRING)
                DbVeza = connRoba
                OkpDbVeza = OkpconnRoba
                cnWinRoba = connRoba
                DbVezaCene = connCene
                eCimVeza = eCimconnRoba
            End If
            If ZSSQL_CONNECTION_STRING <> "" Then
                Dim ZsconnRoba As New SqlConnection(ZSSQL_CONNECTION_STRING)
                ZsDbVeza = ZsconnRoba
            End If
        Catch ex As Exception
            opPovVrednost = "Greška u otvaranju INI datoteke !" & vbCrLf & Err.Description
        Finally
            FileClose(1)
        End Try
    End Sub
End Module
