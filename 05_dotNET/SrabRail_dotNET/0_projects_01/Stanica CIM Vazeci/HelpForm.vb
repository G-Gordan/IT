Imports System.Data.SqlClient
Public Class HelpForm
    Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(HelpForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(9, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Brown
        Me.Label1.Location = New System.Drawing.Point(72, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(416, 43)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Pogled u bazu podataka"
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.Silver
        Me.DataGrid1.BackColor = System.Drawing.Color.White
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Brown
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DataGrid1.ForeColor = System.Drawing.Color.Black
        Me.DataGrid1.GridLineColor = System.Drawing.Color.Silver
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver
        Me.DataGrid1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.Black
        Me.DataGrid1.LinkColor = System.Drawing.Color.Maroon
        Me.DataGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(800, 526)
        Me.DataGrid1.TabIndex = 4
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "SuperGrid"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 37)
        Me.Button1.TabIndex = 5
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HelpForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(800, 526)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HelpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Help"
        Me.TopMost = True
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ii As Int32 = 0 'Broj ucitanih slogova
        Dim dsPomocniBroj As New DataSet("ds")   'DataSet
        Dim strUpit As String

        If upit = "NHM" Then
            strUpit = "SELECT NHMSifra, KratkiNaziv From NHMPozicije"
            'strUpit = "SELECT NHMSifra, NHMCarina, Naziv, IP_U, IP_I, IP_T From NHMPozicije"
            Me.DataGrid1.CaptionText = "     NHM pozicije"
        ElseIf upit = "UIC" Then
            strUpit = "SELECT SifraStanice, KB, Naziv From UicStanice WHERE (_SifraUprave = '" & helpUprava & "')"
            Me.DataGrid1.CaptionText = "     UIC stanice"
        ElseIf upit = "UICPREL" Then
            strUpit = "SELECT Uprava1 as U1, Uprava2 as U2, SifraPrelaza as Prelaz, Naziv " _
                    & "FROM UicPrelazi " _
                    & "WHERE (Uprava1 > '00') AND (Uprava2 > '00') AND (LEFT(SifraPrelaza, 1) = '0')"
            Me.DataGrid1.CaptionText = "     UIC prelazi"
        ElseIf upit = "R7" Then
            strUpit = "SELECT Sifra, Opis From CimR7 "
            Me.DataGrid1.CaptionText = "     Izjave posiljaoca: ukoliko je potrebno dopuni izjavu"
        ElseIf upit = "R9" Then
            strUpit = "SELECT Sifra, Opis From CimR9 "
            Me.DataGrid1.CaptionText = "     Prilozi"
        ElseIf upit = "R13" Then
            strUpit = "SELECT Sifra, Opis From CimR13 "
            Me.DataGrid1.CaptionText = "     Komercijalni uslovi: upisi tekst"
        ElseIf upit = "R55" Then
            strUpit = "SELECT Sifra, Opis From CimR55 "
            Me.DataGrid1.CaptionText = "     Produzenje roka isporuke"
        ElseIf upit = "R56" Then
            strUpit = "SELECT Sifra, Opis From CimR56 "
            Me.DataGrid1.CaptionText = "     Izjave prevoznika"
        ElseIf upit = "Posiljalac" Then
            'strUpit = "SELECT Komitent.Sifra, Komitent.Naziv, Komitent.Zemlja + '-' + Komitent.Mesto + ' ' + Komitent.Adresa " _
            strUpit = "SELECT Komitent.Sifra, Komitent.Naziv, Komitent.Land, Komitent.Mesto, Komitent.Adresa " _
                    & "FROM Komitent FULL OUTER JOIN " _
                    & "Ugovori ON Komitent.Sifra = Ugovori.SifraKorisnika " _
                    & "GROUP BY Komitent.Naziv, Komitent.Land, Komitent.Mesto, Komitent.Adresa, Komitent.Sifra " _
                    & "ORDER BY Komitent.Sifra"
            Me.DataGrid1.CaptionText = "     Posiljalac"
        ElseIf upit = "Primalac" Then
            'strUpit = "SELECT Komitent.Sifra, Komitent.Naziv, Komitent.Zemlja + '-' + Komitent.Mesto + ' ' + Komitent.Adresa " _
            strUpit = "SELECT Komitent.Sifra, Komitent.Naziv, Komitent.Land, Komitent.Mesto, Komitent.Adresa " _
                    & "FROM Komitent FULL OUTER JOIN " _
                    & "Ugovori ON Komitent.Sifra = Ugovori.SifraKorisnika " _
                    & "GROUP BY Komitent.Naziv, Komitent.Land, Komitent.Mesto, Komitent.Adresa, Komitent.Sifra " _
                    & "ORDER BY Komitent.Sifra"
            Me.DataGrid1.CaptionText = "     Primalac"
        ElseIf upit = "Ugovori" Then
            strUpit = "SELECT Ugovori.BrojUgovora AS Ugovor, Ugovori.VrstaObracuna AS Vrsta, Komitent.Naziv AS Komitent " _
                    & "FROM Ugovori INNER JOIN " _
                    & "Komitent ON Ugovori.SifraKorisnika = Komitent.Sifra " _
                    & "WHERE (LEFT(RIGHT(Ugovori.BrojUgovora, 4), 2) = '08' OR " _
                    & "LEFT(RIGHT(Ugovori.BrojUgovora, 4), 2) = '09') AND (Ugovori.VrstaObracuna = 'CO') OR " _
                    & "(Ugovori.VrstaObracuna = 'RO') " _
                    & "ORDER BY Ugovori.BrojUgovora"
            Me.DataGrid1.CaptionText = "     Ugovori"
        ElseIf upit = "SifreKorisnika" Then
            strUpit = "SELECT Komitent.Sifra, Komitent.Naziv, Komitent.Zemlja + '-' + Komitent.Mesto + ' ' + Komitent.Adresa " _
                    & "FROM Komitent FULL OUTER JOIN " _
                    & "Ugovori ON Komitent.Sifra = Ugovori.SifraKorisnika " _
                    & "GROUP BY Komitent.Naziv, Komitent.Zemlja + '-' + Komitent.Mesto + ' ' + Komitent.Adresa, Komitent.Sifra " _
                    & "ORDER BY Komitent.Sifra"
            Me.DataGrid1.CaptionText = "     Korisnièke šifre"
        ElseIf upit = "UPR1" Then
            strUpit = "SELECT SifraOperatera, Oznaka, Naziv, Zemlja, SifraUprave FROM dbo.UicOperateri WHERE SifraOperatera <> '0000'"
            'strUpit = "SELECT Operater, SifraUprave, Oznaka, Naziv FROM dbo.UicOperateri"
            Me.DataGrid1.CaptionText = "     UIC uprave"
        ElseIf upit = "UPR2" Then
            strUpit = "SELECT Operater, SifraUprave, Oznaka, Naziv " _
                    & "FROM dbo.UicOperateri"
            Me.DataGrid1.CaptionText = "     UIC uprave"

        ElseIf upit = "CARDOC" Then
            strUpit = "SELECT * From dbo.ZsCarDokumenti"
            Me.DataGrid1.CaptionText = "     Carina - dokumenti"
        ElseIf upit = "CARZEM" Then
            strUpit = "SELECT * From dbo.ZsCarZemlje"
            Me.DataGrid1.CaptionText = "Carina - zemlje"
        ElseIf upit = "NAK" Then
            If mTarifa = "00" Then
                If IzborSaobracaja = 4 Then
                    strUpit = "SELECT Sifra, IvicniBroj, Naziv " _
                            & "FROM dbo.ZsNaknade " _
                            & "WHERE (SifraVS = '" & IzborSaobracaja & "')" & " AND (Tarifa = '38')"
                Else
                    strUpit = "SELECT Sifra, IvicniBroj, Naziv " _
                            & "FROM dbo.ZsNaknade " _
                            & "WHERE (SifraVS = '" & IzborSaobracaja & "')" & " AND (Tarifa = '36')"
                End If
            Else
                strUpit = "SELECT Sifra, IvicniBroj, Naziv " _
                        & "FROM dbo.ZsNaknade " _
                        & "WHERE (SifraVS = '" & IzborSaobracaja & "')" & " AND (Tarifa = '" & mTarifa & "')"
            End If
            Me.DataGrid1.CaptionText = "Naknade za sporedne usluge"
        ElseIf upit = "CARINA" Then
            strUpit = "SELECT Sifra, Naziv From ZsCarinarnice "
            Me.DataGrid1.CaptionText = "     Carinarnice"
        ElseIf upit = "CARVAL" Then
            strUpit = "SELECT Sifra, Naziv From ZsCarValute "
            Me.DataGrid1.CaptionText = "Valute"

            'ElseIf upit = "Primalac" Then
            '    strUpit = "SELECT Sifra, Naziv, Mesto, Zemlja FROM Komitent WHERE (Sifra > 0)"
            '    Me.DataGrid1.CaptionText = "Korisnici"
            'ElseIf upit = "Posiljalac" Then
            '    strUpit = "SELECT Sifra, Naziv, Mesto, Zemlja FROM Komitent WHERE (Sifra > 0)"
            '    Me.DataGrid1.CaptionText = "Korisnici"
        ElseIf upit = "NAKPB" Then
            If mTarifa = "00" Then
                strUpit = "SELECT Naziv, Iznos1 From ZsNaknade " _
                        & "WHERE (Sifra = '" & bSifraNaknade & "')" & " AND (IvicniBroj = '" & bIvicniBroj & "')" _
                        & " AND (SifraVS = '" & bVrstaSaobracaja & "')" & " AND (Tarifa = '36')"
            Else
                strUpit = "SELECT Naziv, Iznos1 From ZsNaknade " _
                        & "WHERE (Sifra = '" & bSifraNaknade & "')" & " AND (IvicniBroj = '" & bIvicniBroj & "')" _
                        & " AND (SifraVS = '" & bVrstaSaobracaja & "')" & " AND (Tarifa = '" & mTarifa & "')"
            End If

            Me.DataGrid1.CaptionText = "Naknade za sporedne usluge"
        ElseIf upit = "NAJ" Then
            strUpit = "SELECT * From NajavaVoza"
            Me.DataGrid1.CaptionText = "Najave za vozove i grupe kola"
        ElseIf upit = "K140" Then

            mMesec = Today.Month.ToString
            mDan = Today.Day.ToString
            mGodina = Today.Year.ToString

            strUpit = "SELECT SlogKalk.UlEtiketa AS UlBR, SlogKalk.OtpUprava AS UPR, SlogKalk.OtpStanica AS STA, SlogKalk.OtpBroj AS BR, " _
                    & "SlogKalk.OtpDatum AS DATUM, dbo.SlogKalk.PrUprava AS PR_UPR, SlogKola.IBK AS KOLA " _
                    & "FROM SlogKalk INNER JOIN " _
                    & "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica " _
                    & "WHERE (dbo.SlogKalk.OtpDatum = " & "'" & mMesec & "." & mDan & "." & mGodina & "') AND (dbo.SlogKalk.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') " _
                    & "ORDER BY SlogKalk.UlEtiketa"

            Me.DataGrid1.CaptionText = "K140trz - Dnevni racun ulaznih tranzitnih posiljaka - trenutno stanje"
        ElseIf upit = "K165" Then

            mMesec = Today.Month.ToString
            mDan = Today.Day.ToString
            mGodina = Today.Year.ToString

            strUpit = "SELECT SlogKalk.IzEtiketa as Izlaz, SlogKalk.OtpUprava as OUpr, SlogKalk.OtpStanica as OStanica, SlogKalk.OtpBroj as OBroj, " _
                    & "SlogKalk.OtpDatum as ODatum, SlogKalk.PrStanica as PStanica, SlogKola.IBK as Kola,  " _
                    & "SlogKalk.BrojVoza AS Trasa, SlogKalk.SatVoza AS Sat, SlogKalk.Ugovor AS Ugovor, SlogKalk.ZsUlPrelaz AS Ulaz, SlogKalk.UlEtiketa " _
                    & "FROM SlogKalk INNER JOIN " _
                    & "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica " _
                    & "WHERE (dbo.SlogKalk.OtpDatum = " & "'" & mMesec & "." & mDan & "." & mGodina & "') AND (dbo.SlogKalk.ZsUlPrelaz <> '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') " _
                    & "ORDER BY SlogKalk.IzEtiketa"

            Me.DataGrid1.CaptionText = "K165trz - Dnevni racun izlaznih tranzitnih posiljaka - trenutno stanje"
        ElseIf upit = "INDKOL" Then
            If IzborSaobracaja = "2" Then
                strUpit = "SELECT SifraKoloseka, Firma, Iznos1Eur, VaziOd, VaziDo " _
                       & " FROM ZsIndKoloseci " _
                       & " WHERE (SifraStanice = '72" & mStanica2 & "')"
            ElseIf IzborSaobracaja = "1" Then
                If bValuta = "72" Then
                    strUpit = "SELECT SifraKoloseka, Firma, Iznos1Din, VaziOd, VaziDo " _
                            & "FROM ZsIndKoloseci " _
                            & "WHERE (SifraStanice = '72" & mStanica1 & "')"

                Else
                    strUpit = "SELECT SifraKoloseka, Firma, Iznos1Eur, VaziOd, VaziDo " _
                            & "FROM ZsIndKoloseci " _
                            & "WHERE (SifraStanice = '72" & mStanica1 & "')"

                End If
            Else

                strUpit = "SELECT SifraKoloseka, Firma, Iznos1Eur, VaziOd, VaziDo " _
                                       & " FROM ZsIndKoloseci " _
                                       & " WHERE (SifraStanice = '72" & mStanica1 & "')"
            End If
            'DODATI U UPIT DATUM! ... AND ('3/1/2007' BETWEEN VaziOd AND VaziDo)"
            Me.DataGrid1.CaptionText = "Industrijski koloseci"
        End If

        '------------------ Format kolona ----------------------
        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing
        Dim _dataSet As DataSet
        _dataSet = Nothing

        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            dataAdapter = New SqlDataAdapter(strUpit, DbVeza)
            _dataSet = New DataSet
            ii = dataAdapter.Fill(_dataSet, "SuperGrid")
            DbVeza.Close()

        Catch ex As Exception
            MsgBox(ex.ToString())

            'MessageBox.Show("Baza nije otvorena!", "Informacija o pristupu bazi", _
            '           MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

        Dim tableStyle As DataGridTableStyle
        tableStyle = New DataGridTableStyle
        tableStyle.MappingName = "SuperGrid"

        If ii = 0 Then
            MsgBox("Nedostupni podaci iz baze!", MsgBoxStyle.Information, "Poruka iz baze")
            Me.Close()
        Else
            DataGrid1.TableStyles.Clear()
            DataGrid1.TableStyles.Add(tableStyle)
            '''''''''''''''''''''''''''''''DataGrid1.ReadOnly = True
            DataGrid1.ReadOnly = False
            DataGrid1.DataSource = _dataSet.Tables("SuperGrid")

            AutoSizeTable()
        End If


    End Sub

    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        If upit = "NHM" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
            'mIzlaz3 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'razred
        ElseIf upit = "UIC" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'naziv
            mIzlaz3 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'kb
        ElseIf upit = "UICPREL" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'sifra
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'naziv
        ElseIf upit = "R7" Then
            ''If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) < 10 Then
            ''    mizlazObject = "0" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
            ''Else
            ''    mizlazObject = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
            ''End If


            If RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) < 10 Then
                mizlazObject = " " & RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
            Else
                mizlazObject = RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) & ". " & RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1))
            End If

        ElseIf upit = "R9" Then
            ''If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) < 10 Then
            ''    mizlazObject = "0" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
            ''Else
            ''    mizlazObject = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
            ''End If

            If RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) < 10 Then
                mizlazObject = "   " & RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
            Else
                If RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) >= 10 And RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) < 9999 Then
                    mizlazObject = " " & RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) & ". " & RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1))
                Else
                    mizlazObject = RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) & ". " & RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1))
                End If
            End If

        ElseIf upit = "R13" Then
            mizlazObject = " " & RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
        ElseIf upit = "R55" Then
            mizlazObject = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
        ElseIf upit = "R56" Then
            mizlazObject = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
        ElseIf upit = "CARINA" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
        ElseIf upit = "CARDOC" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
        ElseIf upit = "Primalac" Then
            mIzlaz5 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv 
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) + DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'land+Mesto
            mIzlaz4 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4) 'adresa

            'mIzlaz5 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
            'mIzlaz4 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
        ElseIf upit = "Posiljalac" Then
            mIzlaz5 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv 
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) + DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'land+Mesto
            mIzlaz4 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4) 'adresa
        ElseIf upit = "SifreKorisnika" Then
            mIzlaz5 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
        ElseIf upit = "Ugovori" Then
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra 
        ElseIf upit = "CARZEM" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
        ElseIf upit = "CARVAL" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
        ElseIf upit = "UPR1" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
            mIzlaz3 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
        ElseIf upit = "UPR2" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) + DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'sifra
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'naziv
        ElseIf upit = "NAKPB" Then
            mIzlaz3 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'iznos
            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
        ElseIf upit = "NAK" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
        ElseIf upit = "NAJ" Then
            'strUpit = "SELECT * From NajavaVoza"
        ElseIf upit = "INDKOL" Then
            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'iznos
        End If
        Close()
    End Sub
    'Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        If upit = "NHM" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
    '            'mIzlaz3 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'razred
    '        ElseIf upit = "UIC" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'naziv
    '            mIzlaz3 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'kb
    '        ElseIf upit = "UICPREL" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'sifra
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'naziv
    '        ElseIf upit = "R7" Then
    '            If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) < 10 Then
    '                mizlazObject = "0" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
    '            Else
    '                mizlazObject = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
    '            End If
    '        ElseIf upit = "R9" Then
    '            If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) < 10 Then
    '                mizlazObject = "0" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
    '            Else
    '                mizlazObject = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
    '            End If
    '        ElseIf upit = "R13" Then
    '            mizlazObject = " " & RTrim(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)) & ". " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
    '        ElseIf upit = "R55" Then
    '            mizlazObject = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) + ". " + DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
    '        ElseIf upit = "R56" Then
    '            mizlazObject = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) + ". " + DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
    '        ElseIf upit = "CARINA" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
    '        ElseIf upit = "CARDOC" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
    '            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
    '        ElseIf upit = "Primalac" Then
    '            mIzlaz5 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
    '            mIzlaz4 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
    '        ElseIf upit = "Posiljalac" Then
    '            mIzlaz5 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
    '            mIzlaz4 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
    '        ElseIf upit = "Ugovori" Then
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra 
    '        ElseIf upit = "SifreKorisnika" Then
    '            mIzlaz5 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
    '        ElseIf upit = "CARZEM" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
    '            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
    '        ElseIf upit = "CARVAL" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
    '            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
    '        ElseIf upit = "UPR1" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
    '            mIzlaz3 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
    '            'mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) + DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'sifra
    '            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'naziv

    '        ElseIf upit = "UPR2" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) + DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'sifra
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'naziv
    '        ElseIf upit = "NAKPB" Then
    '            mIzlaz3 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'iznos
    '            'mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
    '        ElseIf upit = "NAK" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) 'naziv
    '        ElseIf upit = "NAJ" Then
    '            'strUpit = "SELECT * From NajavaVoza"
    '        ElseIf upit = "INDKOL" Then
    '            mIzlaz1 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) 'sifra
    '            mIzlaz2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'iznos
    '        End If

    '        Me.Close()
    '        e.Handled = True
    '    End If
    'End Sub
    Public Sub AutoSizeTable()

        Dim numCols As Integer
        numCols = CType(DataGrid1.DataSource, DataTable).Columns.Count
        Dim i As Integer
        i = 0
        Do While (i < numCols)
            AutoSizeCol(i)
            i = (i + 1)
        Loop
    End Sub
    Public Sub AutoSizeCol(ByVal col As Integer)
        Dim width As Single
        width = 0
        Dim numRows As Integer
        numRows = CType(DataGrid1.DataSource, DataTable).Rows.Count
        Dim g As Graphics
        g = Graphics.FromHwnd(DataGrid1.Handle)
        Dim sf As StringFormat
        sf = New StringFormat(StringFormat.GenericTypographic)
        Dim size As SizeF
        Dim i As Integer
        i = 0

        Do While (i < numRows)
            size = g.MeasureString(DataGrid1(i, col).ToString, DataGrid1.Font, 500, sf)
            If (size.Width > width) Then
                width = size.Width + 20  'BILO JE 10
            End If
            i = (i + 1)

        Loop
        g.Dispose()
        DataGrid1.TableStyles("SuperGrid").GridColumnStyles(col).Width = CType(width, Integer)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mIzlaz1 = ""
        mIzlaz2 = ""
        mIzlaz3 = 0
        mIzlaz4 = ""
        mIzlaz5 = 0
        mizlazObject = ""

        Me.Close()

    End Sub

End Class
