imports System.Data.SqlClient
Imports System.Data
Public Class KorekcijaPoNajavi
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbNajava As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnFormirajVoz As System.Windows.Forms.Button
    Friend WithEvents btnUpisUBazu As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents dgKorekcija As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KorekcijaPoNajavi))
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbNajava = New System.Windows.Forms.TextBox
        Me.dgKorekcija = New System.Windows.Forms.DataGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnFormirajVoz = New System.Windows.Forms.Button
        Me.btnUpisUBazu = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.dgKorekcija, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(168, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Broj ugovora"
        '
        'tbUgovor
        '
        Me.tbUgovor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(168, 17)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(136, 23)
        Me.tbUgovor.TabIndex = 1
        Me.tbUgovor.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Broj najave"
        '
        'tbNajava
        '
        Me.tbNajava.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNajava.Location = New System.Drawing.Point(8, 17)
        Me.tbNajava.MaxLength = 10
        Me.tbNajava.Name = "tbNajava"
        Me.tbNajava.Size = New System.Drawing.Size(136, 23)
        Me.tbNajava.TabIndex = 0
        Me.tbNajava.Text = ""
        '
        'dgKorekcija
        '
        Me.dgKorekcija.DataMember = ""
        Me.dgKorekcija.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorekcija.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKorekcija.Location = New System.Drawing.Point(8, 44)
        Me.dgKorekcija.Name = "dgKorekcija"
        Me.dgKorekcija.PreferredColumnWidth = 90
        Me.dgKorekcija.Size = New System.Drawing.Size(992, 548)
        Me.dgKorekcija.TabIndex = 39
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 595)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 82)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(400, 43)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.TabIndex = 34
        Me.TextBox4.Text = ""
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(280, 44)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.TabIndex = 33
        Me.TextBox3.Text = ""
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(152, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.TabIndex = 32
        Me.TextBox2.Text = ""
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(16, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.TabIndex = 31
        Me.TextBox1.Text = ""
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Bruto masa voza "
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label4.Location = New System.Drawing.Point(192, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Suma tara "
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label5.Location = New System.Drawing.Point(312, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Suma neto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label6.Location = New System.Drawing.Point(432, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Prevoznina"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(534, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 64)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "Refresh"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnFormirajVoz
        '
        Me.btnFormirajVoz.BackColor = System.Drawing.SystemColors.Control
        Me.btnFormirajVoz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnFormirajVoz.Image = CType(resources.GetObject("btnFormirajVoz.Image"), System.Drawing.Image)
        Me.btnFormirajVoz.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFormirajVoz.Location = New System.Drawing.Point(768, 595)
        Me.btnFormirajVoz.Name = "btnFormirajVoz"
        Me.btnFormirajVoz.Size = New System.Drawing.Size(96, 77)
        Me.btnFormirajVoz.TabIndex = 2
        Me.btnFormirajVoz.Text = "Ucitaj najavu"
        Me.btnFormirajVoz.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnUpisUBazu
        '
        Me.btnUpisUBazu.Image = CType(resources.GetObject("btnUpisUBazu.Image"), System.Drawing.Image)
        Me.btnUpisUBazu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpisUBazu.Location = New System.Drawing.Point(788, 595)
        Me.btnUpisUBazu.Name = "btnUpisUBazu"
        Me.btnUpisUBazu.Size = New System.Drawing.Size(96, 77)
        Me.btnUpisUBazu.TabIndex = 4
        Me.btnUpisUBazu.Text = "Upis u bazu"
        Me.btnUpisUBazu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpisUBazu.Visible = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(903, 595)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(96, 77)
        Me.Button9.TabIndex = 3
        Me.Button9.Text = "Otkaži"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(346, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Godina"
        '
        'TextBox5
        '
        Me.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(347, 17)
        Me.TextBox5.MaxLength = 4
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(69, 23)
        Me.TextBox5.TabIndex = 43
        Me.TextBox5.Text = "2008"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(688, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 24)
        Me.Button2.TabIndex = 44
        Me.Button2.Text = "Cena za ceo voz"
        '
        'KorekcijaPoNajavi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 706)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.tbUgovor)
        Me.Controls.Add(Me.tbNajava)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnFormirajVoz)
        Me.Controls.Add(Me.btnUpisUBazu)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgKorekcija)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "KorekcijaPoNajavi"
        Me.Text = "KorekcijaPoNajavi"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgKorekcija, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim dsKorekcija As DataSet
    Private Sub tbNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub tbNajava_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNajava.Validated
        'mDatumKalk = dtDatum.Value
        If tbNajava.Text = "" Then
            MessageBox.Show("Neispravan broj najave!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tbNajava.Focus()
        End If
    End Sub
    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub btnFormirajVoz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormirajVoz.Click

        Dim _nRbr As Int32 = 1
        Dim _nIBK As String
        Dim _nIzlaz As Int32
        Dim suma_tara As Int32 = 0
        Dim suma_neto As Int32 = 0
        Dim suma_bruto As Int32 = 0
        Dim suma_prevoznina As Decimal = 0 ' Int32 = 0

        'mNajava = tbNajava.Text
        'mBrojUg = tbUgovor.Text

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'izmenjeno 9.3.2009.
        'umesto Nakco82 - slogroba.nhm

        Dim sql_text1 As String
        If IzborSaobracaja = "4" Then
            sql_text1 = "SELECT TOP 100 PERCENT dbo.SlogKalk.NajavaKola AS Najavljeno, dbo.SlogKalk.ObrMesec AS Mesec, dbo.SlogKalk.OtpBroj AS BrojOtp,  " & _
                          "dbo.SlogKalk.Najava2 AS [Iz Makisa], dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlPrevFr AS Prevoznina,  " & _
                          "dbo.SlogNaknada.Iznos AS Naknade, dbo.SlogRoba.NHM , dbo.SlogKola.Naknada AS [Nak. po kolima],  " & _
                          "dbo.SlogKalk.RecID AS RecID, dbo.SlogNaknada.NaknadeStavka as [Rbr. Naknade], dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, " & _
                          "dbo.SlogRoba.KolaStavka, dbo.SlogRoba.RobaStavka " & _
                          "FROM dbo.SlogKalk INNER JOIN  " & _
                          "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN  " & _
                          "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND  " & _
                          "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka FULL OUTER JOIN  " & _
                          "dbo.SlogNaknada ON dbo.SlogKalk.RecID = dbo.SlogNaknada.RecID AND dbo.SlogKalk.Stanica = dbo.SlogNaknada.Stanica  " & _
                          "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
                          "ORDER BY dbo.SlogKalk.OtpBroj "

        ElseIf IzborSaobracaja = "3" Then
            sql_text1 = "SELECT TOP 100 PERCENT dbo.SlogKalk.NajavaKola AS Najavljeno, dbo.SlogKalk.ObrMesec AS Mesec, dbo.SlogKalk.OtpBroj AS BrojOtp,  " & _
                          "dbo.SlogKalk.Najava2 AS [Iz Makisa], dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlPrevUp AS Prevoznina,  " & _
                          "dbo.SlogNaknada.Iznos AS Naknade, dbo.SlogRoba.NHM , dbo.SlogKola.Naknada AS [Nak. po kolima],  " & _
                          "dbo.SlogKalk.RecID AS RecID, dbo.SlogNaknada.NaknadeStavka as [Rbr. Naknade], dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, " & _
                          "dbo.SlogRoba.KolaStavka, dbo.SlogRoba.RobaStavka " & _
                          "FROM dbo.SlogKalk INNER JOIN  " & _
                          "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN  " & _
                          "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND  " & _
                          "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka FULL OUTER JOIN  " & _
                          "dbo.SlogNaknada ON dbo.SlogKalk.RecID = dbo.SlogNaknada.RecID AND dbo.SlogKalk.Stanica = dbo.SlogNaknada.Stanica  " & _
                          "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
                          "ORDER BY dbo.SlogKalk.OtpBroj "

        End If

        '''''slucaj kada je bio je samo tranzit
        '''''Dim sql_text1 As String = "SELECT TOP 100 PERCENT dbo.SlogKalk.NajavaKola AS Najavljeno, dbo.SlogKalk.ObrMesec AS Mesec, dbo.SlogKalk.OtpBroj AS BrojOtp,  " & _
        '''''              "dbo.SlogKalk.Najava2 AS [Iz Makisa], dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlPrevFr AS Prevoznina,  " & _
        '''''              "dbo.SlogNaknada.Iznos AS Naknade, dbo.SlogRoba.NHM , dbo.SlogKola.Naknada AS [Nak. po kolima],  " & _
        '''''              "dbo.SlogKalk.RecID AS RecID, dbo.SlogNaknada.NaknadeStavka as [Rbr. Naknade], dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, " & _
        '''''              "dbo.SlogRoba.KolaStavka, dbo.SlogRoba.RobaStavka " & _
        '''''              "FROM dbo.SlogKalk INNER JOIN  " & _
        '''''              "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN  " & _
        '''''              "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND  " & _
        '''''              "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka FULL OUTER JOIN  " & _
        '''''              "dbo.SlogNaknada ON dbo.SlogKalk.RecID = dbo.SlogNaknada.RecID AND dbo.SlogKalk.Stanica = dbo.SlogNaknada.Stanica  " & _
        '''''              "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
        '''''              "ORDER BY dbo.SlogKalk.OtpBroj "


        ''''Dim sql_text1 As String = "SELECT TOP 100 PERCENT dbo.SlogKalk.NajavaKola AS Najavljeno, dbo.SlogKalk.ObrMesec AS Mesec, dbo.SlogKalk.IzEtiketa AS Nalepnica,  " & _
        ''''              "dbo.SlogKalk.Najava2 AS [Iz Makisa], dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlPrevFr AS Prevoznina,  " & _
        ''''              "dbo.SlogNaknada.Iznos AS Naknade, dbo.SlogRoba.NHM , dbo.SlogKola.Naknada AS [Nak. po kolima],  " & _
        ''''              "dbo.SlogKalk.RecID AS RecID, dbo.SlogNaknada.NaknadeStavka as [Rbr. Naknade], dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj  " & _
        ''''              "FROM dbo.SlogKalk INNER JOIN  " & _
        ''''              "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN  " & _
        ''''              "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND  " & _
        ''''              "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka FULL OUTER JOIN  " & _
        ''''              "dbo.SlogNaknada ON dbo.SlogKalk.RecID = dbo.SlogNaknada.RecID AND dbo.SlogKalk.Stanica = dbo.SlogNaknada.Stanica  " & _
        ''''              "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
        ''''              "ORDER BY dbo.SlogKalk.IzEtiketa "

        '''Dim sql_text1 As String = "SELECT TOP 100 PERCENT dbo.SlogKalk.NajavaKola AS Najavljeno, dbo.SlogKalk.ObrMesec AS Mesec, dbo.SlogKalk.IzEtiketa AS Nalepnica,  " & _
        '''              "dbo.SlogKalk.Najava2 AS [Iz Makisa], dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlPrevFr AS Prevoznina,  " & _
        '''              "dbo.SlogNaknada.Iznos AS Naknade, dbo.SlogKalk.tlNakCo82 AS [Nak. za CO], dbo.SlogKola.Naknada AS [Nak. za Zel. kola],  " & _
        '''              "dbo.SlogKalk.RecID AS RecID, dbo.SlogNaknada.NaknadeStavka as [Rbr. Naknade], dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj  " & _
        '''              "FROM dbo.SlogKalk INNER JOIN  " & _
        '''              "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN  " & _
        '''              "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND  " & _
        '''              "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka FULL OUTER JOIN  " & _
        '''              "dbo.SlogNaknada ON dbo.SlogKalk.RecID = dbo.SlogNaknada.RecID AND dbo.SlogKalk.Stanica = dbo.SlogNaknada.Stanica  " & _
        '''              "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
        '''              "ORDER BY dbo.SlogKalk.IzEtiketa "


        Dim myDecimal As Decimal = 0
        Dim nm_Nak As Decimal = 0

        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)

        Do While rdrRm.Read()

            suma_tara = suma_tara + rdrRm.GetInt32(5)
            suma_neto = suma_neto + rdrRm.GetInt32(6)
            suma_prevoznina = suma_prevoznina + rdrRm.GetDecimal(7)

            If IsDBNull(rdrRm.Item(8)) Then
                nm_Nak = 0
            Else
                nm_Nak = rdrRm.Item(8)
            End If

            dtKorekcija.NewRow()
            'novo 08.08.2010
            dtKorekcija.Rows.Add(New Object() {_nRbr, rdrRm.GetInt32(0), rdrRm.GetString(1), rdrRm.GetInt32(2), rdrRm.GetString(3), rdrRm.GetString(4), rdrRm.GetInt32(5), rdrRm.GetInt32(6), rdrRm.GetDecimal(7), nm_Nak, rdrRm.GetString(9), rdrRm.GetDecimal(10), rdrRm.GetInt32(11), rdrRm.GetInt32(15), rdrRm.GetInt32(16)})
            '''dtKorekcija.Rows.Add(New Object() {_nRbr, rdrRm.GetInt32(0), rdrRm.GetString(1), rdrRm.GetInt32(2), rdrRm.GetString(3), rdrRm.GetString(4), rdrRm.GetInt32(5), rdrRm.GetInt32(6), rdrRm.GetDecimal(7), nm_Nak, rdrRm.GetString(9), rdrRm.GetDecimal(10), rdrRm.GetInt32(11)})

            _nRbr = _nRbr + 1
        Loop

        rdrRm.Close()
        OkpDbVeza.Close()
        dgKorekcija.Refresh()

        Me.btnFormirajVoz.Visible = False
        Me.btnUpisUBazu.Visible = True
        Me.btnUpisUBazu.Focus()

        suma_bruto = suma_tara + suma_neto

        GroupBox1.Visible = True
        ''Label6.Visible = True
        TextBox4.Visible = True

        TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        TextBox2.Text = Math.Round(suma_tara / 1000, 1).ToString
        TextBox3.Text = Math.Round(suma_neto / 1000, 1).ToString

        '08.08.2010: jedan TL ili vise tl nije zavrseno!!!!!!!!!!!!!
        TextBox4.Text = Math.Round(suma_prevoznina, 2).ToString()
    End Sub

    Private Sub KorekcijaPoNajavi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatGrid()
        dtKorekcija.Clear()
        TextBox5.Text = Today.Year.ToString

    End Sub
    Private Sub FormatGrid()
        'Col1.AutoIncrement = True
        'Col1.ReadOnly = True

        If dsKorekcija Is Nothing Then
            dgKorekcija.DataSource = dtKorekcija
        Else
            If mNajava Is Nothing Then
            Else
                dgKorekcija.DataSource = dtKorekcija
            End If
            dgKorekcija.DataSource = dsKorekcija.Tables(0)
        End If

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        dtKorekcija.Clear()
        Me.btnFormirajVoz.Visible = True
        Me.btnUpisUBazu.Visible = False

        Close()

    End Sub

    Private Sub btnUpisUBazu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpisUBazu.Click

        Dim _UKK As Int32
        Dim _recID As Int32
        Dim _recRBR As Int32
        Dim KorekcijaRed As DataRow
        Dim sql_Kalk As String
        Dim sql_Kola As String
        Dim sql_Roba As String
        Dim sql_Naknada As String
        Dim m_Naknade As Decimal ' = 12
        Dim m_Prevoznina As Decimal

        m_Prevoznina = mPrevoznina
        'Dim m_Prevoznina As Decimal = Int(mPrevoznina)

        Dim slogTrans As SqlTransaction

        _UKK = dtKorekcija.Rows.Count

        If _UKK > 0 Then

            Dim myCommandKalk As SqlCommand
            Dim myCommandKola As SqlCommand
            Dim myCommandRoba As SqlCommand
            Dim myCommandNakn As SqlCommand

            Dim ra As Int32
            Dim rv As String
            Dim _UpisiTL As Int16 = 0

            Dim _Prev As Decimal = 0
            Dim _Nak As Decimal = 0
            Dim _NakZaCo As Decimal = 0
            Dim _IzMakisa As String = "0"
            Dim _IBK As String
            Dim _Tara As Int32 = 0
            Dim _NakZaZKola As Decimal = 0
            Dim _Neto As Int32 = 0
            Dim _KolaRb As Int32 = 0
            Dim _RobaRb As Int32 = 0


            'Update SlogKalk
            For Each KorekcijaRed In dtKorekcija.Rows
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                End If

                _recID = KorekcijaRed.Item("RecID")
                _recRBR = KorekcijaRed.Item("RBR")
                _Prev = KorekcijaRed.Item("Prevoznina")
                _Nak = KorekcijaRed.Item("Naknada")
                '''''_NakZaCo = KorekcijaRed.Item("NakZaCO")
                ''_NakZaCo = KorekcijaRed.Item("NHM")

                '---
                _IzMakisa = KorekcijaRed.Item("Makis") 'Novo
                '---

                _IBK = Int(KorekcijaRed.Item("IBK"))
                _Tara = Int(KorekcijaRed.Item("Tara"))
                _NakZaZKola = Int(KorekcijaRed.Item("NakPoKolima"))

                _Neto = Int(KorekcijaRed.Item("Masa"))
                _KolaRb = Int(KorekcijaRed.Item("KolaRb"))
                _RobaRb = Int(KorekcijaRed.Item("RobaRb"))

                _Prev = CDec(_Prev)

                sql_Kalk = "UPDATE SlogKalk " & _
                           "SET Najava2 = '" & _IzMakisa & "', tlPrevFR = " & _Prev & ", tlNakCo = " & _Nak & "  " & _
                           "WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"

                sql_Kola = "UPDATE SlogKola " & _
                           "SET Naknada = " & _NakZaZKola & " , Tara = " & _Tara & " " & _
                           "WHERE (dbo.SlogKola.RecID = " & _recID & ") AND (dbo.SlogKola.KolaStavka = " & _KolaRb & ")"

                'izmenjeno 08.08.2010:    "WHERE (dbo.SlogKola.RecID = " & _recID & ") AND (dbo.SlogKola.IBK = " & _IBK & ")"
                '"WHERE (dbo.SlogKola.RecID = " & _recID & ") AND (dbo.SlogKola.KolaStavka = " & _recRBR & ")"
                ' iskljucena izmena broja kola "SET  IBK = " & _IBK & ", Naknada = " & _NakZaZKola & " , Tara = " & _Tara & " " & _


                '08.08.2010: azuriranje kada je jedan tovarni list!!!!!!!!!!!!!!!!!!
                sql_Roba = "UPDATE SlogRoba " & _
                           "SET SMASA = " & _Neto & " " & _
                           "WHERE (dbo.SlogRoba.RecID = " & _recID & ") AND (dbo.SlogRoba.KolaStavka = " & _KolaRb & ") AND (dbo.SlogRoba.RobaStavka = " & _RobaRb & ")"

                'izmenjeno 08.08.2010:   "WHERE (dbo.SlogRoba.RecID = " & _recID & ")"



                '"WHERE (dbo.SlogRoba.RecID = " & _recID & ") AND (dbo.SlogRoba.KolaStavka = " & _recRBR & ")"

                sql_Naknada = "UPDATE SlogNaknada " & _
                              "SET  Iznos = " & _Nak & " " & _
                              "WHERE ( dbo.SlogNaknada.RecID = " & _recID & ")"

                myCommandKalk = New SqlCommand(sql_Kalk, OkpDbVeza)
                myCommandKola = New SqlCommand(sql_Kola, OkpDbVeza)
                myCommandRoba = New SqlCommand(sql_Roba, OkpDbVeza)
                myCommandNakn = New SqlCommand(sql_Naknada, OkpDbVeza)

                Try
                    ra = myCommandKalk.ExecuteNonQuery()
                    ra = myCommandKola.ExecuteNonQuery()
                    ra = myCommandRoba.ExecuteNonQuery()
                    ra = myCommandNakn.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                OkpDbVeza.Close()
            Next

            MessageBox.Show("Podaci za najavu broj  " & tbNajava.Text & " su upisani u bazu podataka. ", "Beograd Ranzirna", MessageBoxButtons.OK, MessageBoxIcon.Information)

            dtKorekcija.Clear()
            tbNajava.Text = ""
            tbUgovor.Text = ""
            Me.btnUpisUBazu.Visible = False
            Me.btnFormirajVoz.Visible = True
            Me.GroupBox1.Visible = False
            Close()

            'tbNajava.Focus()
        Else
            MessageBox.Show("Nepostojeci podaci !", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim suma_tara As Int32 = 0
        Dim suma_neto As Int32 = 0
        Dim suma_bruto As Int32 = 0



        suma_tara = dtKorekcija.Compute("SUM(Tara)", String.Empty)
        suma_neto = dtKorekcija.Compute("SUM(Masa)", String.Empty)
        suma_bruto = suma_tara + suma_neto

        TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        TextBox2.Text = Math.Round(suma_tara / 1000, 1).ToString
        TextBox3.Text = Math.Round(suma_neto / 1000, 1).ToString



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim KorekcijaRed As DataRow
        Dim _RBR As Int32
        Dim _Prev As Decimal = 0
        Dim _BrojTL As Integer = 0

        For Each KorekcijaRed In dtKorekcija.Rows
            _RBR = KorekcijaRed.Item("RBR")
            If _RBR = 1 Then
                _Prev = KorekcijaRed.Item("Prevoznina")
                _BrojTL = KorekcijaRed.Item("BrojOtp")
            End If
            If _BrojTL = KorekcijaRed.Item("BrojOtp") Then
                KorekcijaRed.Item("Prevoznina") = _Prev
            End If
            'KorekcijaRed.Item("Prevoznina") = _Prev
        Next


        ''==========================================
        'For Each KorekcijaRed In dtKorekcija.Rows
        '    _RBR = KorekcijaRed.Item("RBR")
        '    _Prev = KorekcijaRed.Item("Prevoznina")




        'Next
        ''==========================================


    End Sub
End Class
