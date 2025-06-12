
Imports System.Data.SqlClient

Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' odavle
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
                ComboBox3.Items.Add(sakupljacSStn)
            End While
            ComboBox3.SelectedIndex = 0
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
                ComboBox4.Items.Add(sakupljacIStn)
            End While
            ComboBox4.SelectedIndex = 0
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
                ComboBox1.Items.Add(sakupljacSNRada)
            End While
            ComboBox1.SelectedIndex = 0
            CitacSNRada.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Konekcija.Dispose()
        End Try

        Konekcija.Close()

    End Sub


    'Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged

    '    'MessageBox.Show("pocetak funkcije PolStanNaz")
    '    Dim Konekcija As SqlConnection
    '    Konekcija = New SqlConnection
    '    Konekcija.ConnectionString = "Data Source=localhost; Initial Catalog=EVbaza; Integrated Security=SSPI"
    '    Konekcija.Open()

    '    Dim DAstanice As New SqlDataAdapter
    '    Dim DSstanice As New DataTable
    '    Dim BSstanice As New BindingSource

    '    ' kad odabere ime polazne stanice prikaže se šifra polazne stanice
    '    Try
    '        Dim CBprihvatStr As String
    '        CBprihvatStr = ComboBox4.SelectedItem
    '        'MessageBox.Show("CBprihvatSrt je tip: " & TypeName(CBprihvatStr) & " a vrednost: " & CBprihvatStr)

    '        'Dim CBPolStanSifNaz As String
    '        'CBPolStanSifNaz = Convert.ToString(CBprihvatStr)
    '        ''MessageBox.Show(CBPolStanSifNaz)

    '        Dim SQLKomandaPSS As SqlCommand
    '        Dim upitPSS As String

    '        upitPSS = "SELECT * FROM EVbaza.dbo.Stanice"

    '        'upitPSS = "SELECT sifrastan FROM EVbaza.dbo.Stanice WHERE (imestanice = ' " & CBprihvatStr & " ') "
    '        SQLKomandaPSS = New SqlCommand(upitPSS, Konekcija)
    '        'MessageBox.Show(upitPSS)
    '        ''Dim SifSt As Int32
    '        ''SifSt = SQLKomandaPSS.ExecuteScalar
    '        ''MessageBox.Show(SifSt)

    '        DAstanice.SelectCommand = SQLKomandaPSS
    '        DAstanice.Fill(DSstanice)


    '        'Dim CitacPSS As SqlDataReader
    '        'CitacPSS = SQLKomandaPSS.ExecuteReader()
    '        'Dim sakupljacPSS As String = ""
    '        ''MessageBox.Show("ispred druge petlje")
    '        'While CitacPSS.Read()
    '        '    sakupljacPSS = CitacPSS.GetString(0) 'šifra polazne stanice
    '        '    MessageBox.Show("U PETLJI 2 polazna stanica")
    '        'End While
    '        ''MessageBox.Show("iza druge petlje polazna stanica")

    '        'Dim index As Integer
    '        'index = ComboBox3.FindStringExact(sakupljacPSS)
    '        ''MessageBox.Show(sakupljacPSS)

    '        ''CBPolStanNaz.SelectedIndex = index
    '        'CitacPSS.Close()
    '        ''CitacPSS.Dispose()

    '        Konekcija.Close()

    '    Catch ex As SqlException
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        Konekcija.Dispose()
    '    End Try


    'End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim zbir As Integer
        zbir = TextBox1.Text * 60 + TextBox2.Text
        TextBox3.Text = zbir
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

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
        Dim izrazsifrad As String = ComboBox1.Text
        Dim duzizrazsr As Integer = izrazsifrad.Length
        Dim brsifRada As String = Microsoft.VisualBasic.Left(ComboBox1.Text, 2) 'izrazsifrad.Substring(0, 2)
        Dim imeRada As String = izrazsifrad.Substring(5, duzizrazsr - 5)
        Label10.Text = brsifRada
        Label6.Text = imeRada

        'Dim upitTempUnos As String
        'upitTempUnos = "INSET INTO EVbaza.dbo.UnosTemp (brvozredvoz, vrporedvoz, pvreme, pstsif, pstime, dvreme, dstsif, dstime, predjkm, tezinabruto, sifradalok, nazradalok) "
        '                        "VALUES (' " & CBBrVRedV.Text & " ',' " & vremePoRedVoz & " ',' " & polVreme & " ',' "& CBPolStanSif.Text &" ',' " & CBPolStanNaz.Text & " ',' "& & dolVreme & " ',' "& CBDolStanSif.Text &" ',' " & CBDolStanNaz &" ', &_
        '                        " ' "& TBPredjKm.Text &" ',' "& TBTezBruto.Text &" ',' "& sifRada &" ',' "& imeRada" ')"

    End Sub
End Class