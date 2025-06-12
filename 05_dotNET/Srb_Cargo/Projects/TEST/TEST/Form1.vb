Imports System.Data.SqlClient

'Public Class Form1

'    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Dim Konekcija As SqlConnection
'        Konekcija = New SqlConnection '("Data Source=localhost; Initial Catalog=TEST; Integrated Security=SSPI;")
'        Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=TESTbaza; Integrated Security=SSPI"
'        Konekcija.Open()

'        'Try
'        'Konekcija.Open()
'        'MessageBox.Show("Konekcija OK")
'        'Konekcija.Close()
'        ' Catch ex As Exception
'        'MsgBox(ex.Message)
'        'Finally
'        'Konekcija.Dispose()
'        'End Try

'        'Dim a As Integer
'        Dim upit As String
'        upit = "select SifraLok from TESTbaza.dbo.LokSif"

'        Dim SQLKomanda As SqlCommand
'        SQLKomanda = New SqlCommand(upit, Konekcija)

'        Dim Citac As SqlDataReader

'        Citac = SQLKomanda.ExecuteReader()

'        'Dim sakupljac As String
'        While Citac.Read()

'            Dim sakupljac = Citac.GetString(0) '"SifraLok"
'            'Dim sakupljac = Citac.Item(0)
'            'a = Citac.GetString("SifraLok")
'            ComboBox1.Items.Add(sakupljac)
'            'sakupljac = ""

'        End While
'        Citac.Close()
'        Konekcija.Close()
'    End Sub
'End Class

Public Class Form1

    ' odavle
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Konekcija As SqlConnection
        Konekcija = New SqlConnection '("Data Source=localhost; Initial Catalog=TEST; Integrated Security=SSPI;")
        Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
        Konekcija.Open()

        Try

            'PUNI ŠIFRU POLAZNE I DOLAZNE STANICE
            Dim SQLKomandaSStn As SqlCommand
            Dim upitSStn As String
            upitSStn = "SELECT sifrastan FROM EVbaza.dbo.Stanice ORDER BY sifrastan"
            SQLKomandaSStn = New SqlCommand(upitSStn, Konekcija)
            Dim CitacSStn As SqlDataReader
            CitacSStn = SQLKomandaSStn.ExecuteReader()
            While CitacSStn.Read()
                Dim sakupljacSStn = CitacSStn.GetInt32(0) 'sifra stanice
                ComboBox1.Items.Add(sakupljacSStn)
            End While
            ComboBox1.SelectedIndex = 0
            CitacSStn.Close()

            'PUNI IME POLAZNE I DOLAZNE STANICE
            Dim SQLKomandaIStn As SqlCommand
            Dim upitIStn As String
            upitIStn = "SELECT imestanice FROM EVbaza.dbo.Stanice ORDER BY imestanice"
            SQLKomandaIStn = New SqlCommand(upitIStn, Konekcija)
            Dim CitacIStn As SqlDataReader
            CitacIStn = SQLKomandaIStn.ExecuteReader()
            While CitacIStn.Read()
                Dim sakupljacIStn = CitacIStn.GetString(0) 'ime stanice
                ComboBox2.Items.Add(sakupljacIStn)
            End While
            ComboBox2.SelectedIndex = 0
            CitacIStn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Konekcija.Dispose()
        End Try

        Konekcija.Close()

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim Konekcija As SqlConnection
        Konekcija = New SqlConnection
        Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
        Konekcija.Open()

        ' kad odabere šifu polazne stanice prikaže se ime polazne stanice
        Dim CBPolStanSifInd As Integer
        Dim CBprihvatStr As String
        CBprihvatStr = ComboBox1.SelectedItem
        CBPolStanSifInd = Convert.ToInt32(CBprihvatStr)
        'MessageBox.Show(CBPolStanSifInd)
        Dim SQLKomandaPSI As SqlCommand
        Dim upitPSI As String
        upitPSI = "SELECT imestanice FROM EVbaza.dbo.Stanice WHERE (sifrastan = ' " & CBPolStanSifInd & " ') "
        SQLKomandaPSI = New SqlCommand(upitPSI, Konekcija)
        Dim CitacPSI As SqlDataReader
        'CitacPSI = SQLKomandaPSI.ExecuteReader(CommandBehavior.CloseConnection)
        CitacPSI = SQLKomandaPSI.ExecuteReader()
        Dim sakupljacPSI As String = ""
        While CitacPSI.Read()
            sakupljacPSI = CitacPSI.GetString(0) 'ime polazne stanice
            'MessageBox.Show("PETLJA 1")
        End While
        Dim index As Integer
        index = ComboBox2.FindStringExact(sakupljacPSI)

        'MessageBox.Show(sakupljacPSI)

        ComboBox2.SelectedIndex = index
        CitacPSI.Close()
        'CitacPSI.Dispose()
        Konekcija.Close()
        'Konekcija.Dispose()

    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        'MessageBox.Show("pocetak funkcije PolStanNaz")
        Dim Konekcija As SqlConnection
        Konekcija = New SqlConnection
        Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
        Konekcija.Open()

        ' kad odabere ime polazne stanice prikaže se šifra polazne stanice

        Dim CBprihvatStr As String
        CBprihvatStr = ComboBox2.SelectedItem
        'MessageBox.Show("CBprihvatSrt je tip: " & TypeName(CBprihvatStr) & " a vrednost: " & CBprihvatStr)

        Dim CBPolStanSifNaz As String
        CBPolStanSifNaz = Convert.ToString(CBprihvatStr)
        'MessageBox.Show(CBPolStanSifNaz)

        Dim SQLKomandaPSS As SqlCommand
        Dim upitPSS As String
        upitPSS = "SELECT sifrastan FROM EVbaza.dbo.Stanice WHERE (imestanice = ' " & CBPolStanSifNaz & " ') "
        SQLKomandaPSS = New SqlCommand(upitPSS, Konekcija)
        'MessageBox.Show(upitPSS)
        'Dim SifSt As Int32
        'SifSt = SQLKomandaPSS.ExecuteScalar
        'MessageBox.Show(SifSt)

        Dim CitacPSS As SqlDataReader
        CitacPSS = SQLKomandaPSS.ExecuteReader()
        Dim sakupljacPSS As String = ""
        'MessageBox.Show("ispred druge petlje")
        While CitacPSS.Read()
            sakupljacPSS = CitacPSS.GetString(0) 'šifra polazne stanice
            MessageBox.Show("U PETLJI 2 polazna stanica")
        End While
        'MessageBox.Show("iza druge petlje polazna stanica")

        Dim index As Integer
        index = ComboBox1.FindStringExact(sakupljacPSS)
        'MessageBox.Show(sakupljacPSS)

        'CBPolStanNaz.SelectedIndex = index
        CitacPSS.Close()
        'CitacPSS.Dispose()

        Konekcija.Close()

    End Sub


End Class




''MessageBox.Show("pocetak funkcije PolStanNaz")
'Dim Konekcija As SqlConnection
'        Konekcija = New SqlConnection
'        Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
'        Konekcija.Open()

'' kad odabere ime polazne stanice prikaže se šifra polazne stanice

'Dim CBprihvatStr As String
'        CBprihvatStr = ComboBox2.SelectedItem
''MessageBox.Show("CBprihvatSrt je tip: " & TypeName(CBprihvatStr) & " a vrednost: " & CBprihvatStr)

''Dim CBPolStanSifNaz As String
''CBPolStanSifNaz = Convert.ToChar(CBprihvatStr)
''MessageBox.Show(CBPolStanSifNaz)

'Dim SQLKomandaPSS As SqlCommand
'Dim upitPSS As String
'        upitPSS = "SELECT sifrastan FROM EVbaza.dbo.Stanice WHERE (imestanice = ' " & CBprihvatStr & " ') "
'        SQLKomandaPSS = New SqlCommand(upitPSS, Konekcija)
'Dim CitacPSS As SqlDataReader
'        CitacPSS = SQLKomandaPSS.ExecuteReader()
'Dim sakupljacPSS As String '= ""
''MessageBox.Show("ispred druge petlje")
'        While CitacPSS.Read

'            sakupljacPSS = CitacPSS.GetInt32(0) 'šifra polazne stanice
'            MessageBox.Show("U PETLJI 2 polazna stanica")
'        End While
''MessageBox.Show("iza druge petlje polazna stanica")

'Dim index As Integer
'        index = ComboBox1.FindStringExact(sakupljacPSS)
''MessageBox.Show(sakupljacPSS)

''CBPolStanNaz.SelectedIndex = index
'        CitacPSS.Close()

'        Konekcija.Close()


