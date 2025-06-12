'Inherits System.Windows.Forms.Form
'Imports System
'Imports System.Data
Imports System.Data.SqlClient

Public Class Form2
    
    ' odavle

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Konekcija As SqlConnection
        Konekcija = New SqlConnection '("Data Source=localhost; Initial Catalog=TEST; Integrated Security=SSPI;")
        Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
        Konekcija.Open()

        Try

            'PUNI ŠIFRU LOKOMOTIVE
            Dim SQLKomandaLok As SqlCommand
            Dim upitLok As String
            upitLok = "SELECT sifralok FROM EVbaza.dbo.Lokomotive"
            SQLKomandaLok = New SqlCommand(upitLok, Konekcija)
            Dim CitacLok As SqlDataReader
            CitacLok = SQLKomandaLok.ExecuteReader()
            While CitacLok.Read()
                Dim sakupljacLok = CitacLok.GetString(0) 'oznaka lokomotive
                CBLoko.Items.Add(sakupljacLok)
            End While
            CitacLok.Close()


            'PUNI ŠIFRU POLAZNE I DOLAZNE STANICE
            Dim SQLKomandaSStn As SqlCommand
            Dim upitSStn As String
            upitSStn = "SELECT sifrastan FROM EVbaza.dbo.Stanice ORDER BY sifrastan"
            SQLKomandaSStn = New SqlCommand(upitSStn, Konekcija)
            Dim CitacSStn As SqlDataReader
            CitacSStn = SQLKomandaSStn.ExecuteReader()
            While CitacSStn.Read()
                Dim sakupljacSStn = CitacSStn.GetInt32(0) 'sifra stanice
                CBPolStanSif.Items.Add(sakupljacSStn)
                CBDolStanSif.Items.Add(sakupljacSStn)
            End While
            'CBPolStanSif.SelectedIndex = 0
            'CBDolStanSif.SelectedIndex = 0
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
                CBPolStanNaz.Items.Add(sakupljacIStn)
                CBDolStanNaz.Items.Add(sakupljacIStn)
            End While
            'CBPolStanNaz.SelectedIndex = 0
            'CBDolStanNaz.SelectedIndex = 0
            CitacIStn.Close()


            'PUNI ŠIFRU + IME RADA
            Dim SQLKomandaSNRada As SqlCommand
            Dim upitSNRada As String
            upitSNRada = "SELECT sifrada+' - '+nazsifrada FROM EVbaza.dbo.SifreRada"
            SQLKomandaSNRada = New SqlCommand(upitSNRada, Konekcija)
            Dim CitacSNRada As SqlDataReader
            CitacSNRada = SQLKomandaSNRada.ExecuteReader()
            While CitacSNRada.Read()
                Dim sakupljacSNRada = CitacSNRada.GetString(0) 'sifra i naziv vrste rada
                CBSNazRadaLok.Items.Add(sakupljacSNRada)
            End While
            CBSNazRadaLok.SelectedIndex = 0
            CitacSNRada.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Konekcija.Dispose()
        End Try


        Dim DAstanice As New SqlDataAdapter
        Dim DSstanice As New DataSet("UnosTemp")
        Dim BSstanice As New BindingSource

        Dim SQLKomandaUnos As SqlCommand
        Dim upitDGVunos As String

        upitDGVunos = "SELECT * FROM EVbaza.dbo.UnosTemp"
        SQLKomandaUnos = New SqlCommand(upitDGVunos, Konekcija)

        DAstanice.SelectCommand = SQLKomandaUnos
        DAstanice.Fill(DSstanice)
        BSstanice.DataSource = DSstanice
        DGVunos.DataSource = BSstanice
        DAstanice.Update(DSstanice)


        Konekcija.Close()

    End Sub





    ' kad se izabe da postavi drugo

    'Private Sub CBPolStanSif_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPolStanSif.SelectedIndexChanged

    '    Dim Konekcija As SqlConnection
    '    Konekcija = New SqlConnection
    '    Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
    '    Konekcija.Open()

    '    ' kad odabere šifu polazne stanice prikaže se ime polazne stanice
    '    Dim CBPolStanSifInd As Integer
    '    Dim CBprihvatStr As String
    '    CBprihvatStr = CBPolStanSif.SelectedItem
    '    CBPolStanSifInd = Convert.ToInt32(CBprihvatStr)
    '    'MessageBox.Show(CBPolStanSifInd)
    '    Dim SQLKomandaPSI As SqlCommand
    '    Dim upitPSI As String
    '    upitPSI = "SELECT imestanice FROM EVbaza.dbo.Stanice WHERE (sifrastan = ' " & CBPolStanSifInd & " ') "
    '    SQLKomandaPSI = New SqlCommand(upitPSI, Konekcija)
    '    Dim CitacPSI As SqlDataReader
    '    'CitacPSI = SQLKomandaPSI.ExecuteReader(CommandBehavior.CloseConnection)
    '    CitacPSI = SQLKomandaPSI.ExecuteReader()
    '    Dim sakupljacPSI As String = ""
    '    While CitacPSI.Read()
    '        sakupljacPSI = CitacPSI.GetString(0) 'ime polazne stanice
    '        'MessageBox.Show("PETLJA 1")
    '    End While
    '    Dim index As Integer
    '    index = CBPolStanNaz.FindStringExact(sakupljacPSI)

    '    'MessageBox.Show(sakupljacPSI)

    '    CBPolStanNaz.SelectedIndex = index
    '    CitacPSI.Close()
    '    'CitacPSI.Dispose()
    '    Konekcija.Close()
    '    'Konekcija.Dispose()

    'End Sub

    'Private Sub CBPolStanNaz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPolStanNaz.SelectedIndexChanged
    '    'MessageBox.Show("pocetak funkcije PolStanNaz")
    '    Dim Konekcija As SqlConnection
    '    Konekcija = New SqlConnection
    '    Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
    '    Konekcija.Open()

    '    ' kad odabere ime polazne stanice prikaže se šifra polazne stanice

    '    Dim CBprihvatStr As String
    '    CBprihvatStr = CBPolStanNaz.SelectedItem
    '    'MessageBox.Show("CBprihvatSrt je tip: " & TypeName(CBprihvatStr) & " a vrednost: " & CBprihvatStr)

    '    'Dim CBPolStanSifNaz As String
    '    'CBPolStanSifNaz = Convert.ToChar(CBprihvatStr)
    '    'MessageBox.Show(CBPolStanSifNaz)

    '    Dim SQLKomandaPSS As SqlCommand
    '    Dim upitPSS As String
    '    upitPSS = "SELECT sifrastan FROM EVbaza.dbo.Stanice WHERE (imestanice = ' " & CBprihvatStr & " ') "
    '    SQLKomandaPSS = New SqlCommand(upitPSS, Konekcija)
    '    Dim CitacPSS As SqlDataReader
    '    CitacPSS = SQLKomandaPSS.ExecuteReader()
    '    Dim sakupljacPSS As String = ""
    '    'MessageBox.Show("ispred druge petlje")
    '    While CitacPSS.Read()
    '        sakupljacPSS = CitacPSS.GetInt32(0) 'šifra polazne stanice
    '        MessageBox.Show("U PETLJI 2 polazna stanica")
    '        'MessageBox.Show(CitacPSS.GetInt32(0))
    '    End While
    '    'MessageBox.Show("iza druge petlje polazna stanica")
    '    'Dim index As Integer
    '    'index = CBDolStanSif.FindStringExact(sakupljacPSS)
    '    'MessageBox.Show(sakupljacPSS)

    '    'CBPolStanNaz.SelectedIndex = index
    '    CitacPSS.Close()

    '    Konekcija.Close()

    'End Sub

    'Private Sub CBDolStanSif_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBDolStanSif.SelectedIndexChanged


    '    Dim Konekcija As SqlConnection
    '    Konekcija = New SqlConnection
    '    Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
    '    Konekcija.Open()

    '    ' kad odabere šifu dolazne stanice prikaže se ime dolazne stanice
    '    Dim CBDolStanSifInd As Integer
    '    Dim CBprihvatStr As String
    '    CBprihvatStr = CBDolStanSif.SelectedItem
    '    CBDolStanSifInd = Convert.ToInt32(CBprihvatStr)
    '    'MessageBox.Show(CBDolStanSifInd)
    '    Dim SQLKomandaDSI As SqlCommand
    '    Dim upitDSI As String
    '    upitDSI = "SELECT imestanice FROM EVbaza.dbo.Stanice WHERE (sifrastan = ' " & CBDolStanSifInd & " ') "
    '    SQLKomandaDSI = New SqlCommand(upitDSI, Konekcija)
    '    Dim CitacDSI As SqlDataReader
    '    'CitacDSI = SQLKomandaPSI.ExecuteReader(CommandBehavior.CloseConnection)
    '    CitacDSI = SQLKomandaDSI.ExecuteReader()
    '    Dim sakupljacDSI As String = ""
    '    While CitacDSI.Read()
    '        sakupljacDSI = CitacDSI.GetString(0) 'ime dolazne stanice
    '        'MessageBox.Show("PETLJA 1 dolazna stanica")
    '    End While
    '    Dim index As Integer
    '    index = CBDolStanNaz.FindStringExact(sakupljacDSI)

    '    'MessageBox.Show(sakupljacDSI)

    '    CBDolStanNaz.SelectedIndex = index
    '    CitacDSI.Close()
    '    'CitacDSI.Dispose()
    '    Konekcija.Close()
    '    'Konekcija.Dispose()


    'End Sub

    'Private Sub CBDolStanNaz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBDolStanNaz.SelectedIndexChanged


    '    Dim Konekcija As SqlConnection
    '    Konekcija = New SqlConnection
    '    Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
    '    Konekcija.Open()

    '    ' kad odabere ime dolazne stanice prikaže sešifra dolazne stanice
    '    'Dim CBDolStanSifInd As Integer
    '    Dim CBprihvatStr As String
    '    CBprihvatStr = CBDolStanNaz.SelectedItem
    '    'CBDolStanSifInd = Convert.ToInt32(CBprihvatStr)
    '    'MessageBox.Show(CBDolStanSifInd)
    '    Dim SQLKomandaDSI As SqlCommand
    '    Dim upitDSI As String
    '    upitDSI = "SELECT sifrastan FROM EVbaza.dbo.Stanice WHERE ( imestanice = ' " & CBprihvatStr & " ') "
    '    SQLKomandaDSI = New SqlCommand(upitDSI, Konekcija)
    '    Dim CitacDSI As SqlDataReader
    '    'CitacDSI = SQLKomandaPSI.ExecuteReader(CommandBehavior.CloseConnection)
    '    CitacDSI = SQLKomandaDSI.ExecuteReader()
    '    Dim sakupljacDSI As String = ""
    '    While CitacDSI.Read()
    '        sakupljacDSI = CitacDSI.GetString(0) 'ime dolazne stanice
    '        'MessageBox.Show("PETLJA 1 dolazna stanica")
    '    End While
    '    'Dim index As Integer
    '    'index = CBDolStanNaz.FindStringExact(sakupljacDSI)

    '    'MessageBox.Show(sakupljacDSI)

    '    'CBDolStanNaz.SelectedIndex = index
    '    CitacDSI.Close()
    '    'CitacDSI.Dispose()
    '    Konekcija.Close()
    '    'Konekcija.Dispose()




    'End Sub



    'CBPolStanSif.SelectedIndex = 0
    'CBDolStanSif.SelectedIndex = 0
    'CBPolStanNaz.SelectedIndex = 0
    'CBDolStanNaz.SelectedIndex = 0
    'CBSNazRadaLok.SelectedIndex = 0



    Private Sub ButUnos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButUnos.Click
        Dim Konekcija As SqlConnection
        Konekcija = New SqlConnection '("Data Source=localhost; Initial Catalog=TEST; Integrated Security=SSPI;")
        Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
        Konekcija.Open()


        'Dim vremePoRedVoz As Integer
        'vremePoRedVoz = TextBox12.Text * 60 + TextBox5.Text

        'Dim polVreme As Integer
        'polVreme = TextBox10.Text * 60 + TextBox9.Text

        'Dim dolVreme As Integer
        'dolVreme = TextBox23.Text * 60 + TextBox22.Text

        'Dim sifRada As String
        'Dim izrazsifrad As String = CBSNazRadaLok.Text
        'Dim duzizrazsr As Integer = izrazsifrad.Length
        'Dim brsifrada As String = izrazsifrad.Substring(0, 2)
        'Dim imeRada As String = izrazsifrad.Substring(5, duzizrazsr - 5)

        Dim upitTempUnos As String
        upitTempUnos = "INSET INTO EVbaza.dbo.UnosTemp (brvozredvoz, vrporedvoz, pvreme, pstsif, pstime, dvreme, dstsif, dstime, predjkm, tezinabruto, sifradalok, nazradalok) &_"
                                "VALUES (' " & CBBrVRedV.Text & " ',' " & vremePoRedVoz & " ',' " & polVreme & " ',' "& CBPolStanSif.Text &" ',' " & CBPolStanNaz.Text & " ',' "& & dolVreme & " ',' "& CBDolStanSif.Text &" ',' " & CBDolStanNaz &" ', &_
                                " ' "& TBPredjKm.Text &" ',' "& TBTezBruto.Text &" ',' "& sifRada &" ',' "& imeRada" ')"


    End Sub
End Class

'dovle

'Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'Dim EVConnection As SqlConnection
'Dim EVCommand As SqlCommand
'Dim strSQL As String
'Dim EVDataReader As SqlDataReader

'EVConnection(New SqlConnection("Data Source=localhost\sqlexpress; Database=EV2017"))
'EVConnection = New SqlConnectin
'EVConnection.ConnectionString="server=localhost;database=EV2017"
'Try
'EVConnection.Open()
'Catch ex As Exception
'MsgBox(ex.Message)
'End Try

'strSQL = "SELECT * FROM Lokomotive"
'EVCommand = New SqlCommand(strSQL, EVConnection)
'EVDataReader = EVCommand.ExecuteReader()

'End Sub


'End Class