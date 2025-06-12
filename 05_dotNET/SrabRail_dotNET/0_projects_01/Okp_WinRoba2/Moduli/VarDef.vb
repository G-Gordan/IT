Module VarDef       'Promenljive i funkcije vezane za kreiranje carinskog XML fajla

    'Carinski aplikacioni parametri
    Friend cCarinaApplParProcitani As Boolean = False
    Friend cCarinaDir As String = ""
    Friend cCarinaDirZaSlanje As String = ""
    Friend cCarinaDirPoslato As String = ""
    Friend cCarinaDirGreska As String = ""
    Friend cCarinaFTPHost As String = ""
    Friend cCarinaFTPUser As String = ""
    Friend cCarinaFTPPassword As String = ""
    Friend cCarinaFTPDir As String = ""
    Friend cCarinaFTPFileName As String = ""

    Friend dt As New DataTable("dt")
    Friend dcRedosledXML As DataColumn = dt.Columns.Add("RedosledXML", Type.GetType("System.Byte"))
    Friend dcSekcijaNaziv As DataColumn = dt.Columns.Add("SekcijaNaziv", Type.GetType("System.String"))
    Friend dcIteracija As DataColumn = dt.Columns.Add("Iteracija", Type.GetType("System.Byte"))
    Friend dcPoljeRedBr As DataColumn = dt.Columns.Add("PoljeRedBr", Type.GetType("System.Int16"))
    Friend dcPoljeNaziv As DataColumn = dt.Columns.Add("PoljeNaziv", Type.GetType("System.String"))
    Friend dcVrednost As DataColumn = dt.Columns.Add("Vrednost", Type.GetType("System.String"))

    'FUNKCIJE koje kreiraju Pocetak, Kraj i NULL XML sintaksu
    Friend Function fXML(ByVal ipNaziv As String, ByVal ipTip As String) As String
        Dim rv As String = ""
        Select Case ipTip
            Case "P"
                rv = "<" & Trim(ipNaziv) & ">"
            Case "K"
                rv = "</" & Trim(ipNaziv) & ">"
            Case "N"
                rv = "<" & Trim(ipNaziv) & " />"
        End Select
        Return rv
    End Function
End Module