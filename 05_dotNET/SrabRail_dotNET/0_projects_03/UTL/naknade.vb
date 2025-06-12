Imports System.Data.SqlClient
Public Class naknade

    Inherits System.Windows.Forms.Form

    Dim dsNaknade As DataSet
    Public nmHelpFormIK As Boolean = False

    'Friend bSifraNaknade As String
    'Friend bIvicniBroj As String
    'Dim bPodBroj As String

    'Dim bTarifa As String
    Dim bStavkaNak As Integer
    'Dim bDatum As DateTime = Today
    'Dim bNazivNaknade As String = ""

    'Dim bIznos1 As Decimal
    'Dim bIznos2 As Decimal
    'Dim bIznos3 As Decimal
    'Dim bMinimum As Decimal
    'Dim bRetVal As String = ""
    Dim bNakRetVal As String = ""

    Dim bKolicina As Integer = 1
    Dim bDanCas As Integer
    Dim bIznosNakn As Decimal = 0
    Public dvNaknada As New DataView(dtNaknade)


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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnStanicaPr As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzmeniNak As System.Windows.Forms.Button
    Friend WithEvents btnBrisiNak As System.Windows.Forms.Button
    Friend WithEvents btnDodajNak As System.Windows.Forms.Button
    Friend WithEvents tbValutaNak As System.Windows.Forms.TextBox
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents dgNaknade As System.Windows.Forms.DataGrid
    Friend WithEvents tbSifraNaknade As System.Windows.Forms.TextBox
    Friend WithEvents tbIvicniBroj As System.Windows.Forms.TextBox
    Friend WithEvents nudKolicina As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudDanCas As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbSifPlacanja As System.Windows.Forms.ComboBox
    Friend WithEvents dtPickDatumNaknade As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNazivNaknade As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbObracun As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnIndKol As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents fxIznosNak1 As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxIznosNak As System.Windows.Forms.TextBox
    Friend WithEvents Button2Nak As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ButtonFilter62 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(naknade))
        Me.tbSifraNaknade = New System.Windows.Forms.TextBox
        Me.tbIvicniBroj = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.nudKolicina = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.nudDanCas = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbSifPlacanja = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgNaknade = New System.Windows.Forms.DataGrid
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnStanicaPr = New System.Windows.Forms.Button
        Me.lblNazivNaknade = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.dtPickDatumNaknade = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2Nak = New System.Windows.Forms.Button
        Me.fxIznosNak = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.btnIndKol = New System.Windows.Forms.Button
        Me.fxIznosNak1 = New FlxMaskBox.FlexMaskEditBox
        Me.cbObracun = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbValutaNak = New System.Windows.Forms.TextBox
        Me.btnDodajNak = New System.Windows.Forms.Button
        Me.btnBrisiNak = New System.Windows.Forms.Button
        Me.btnIzmeniNak = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.ButtonFilter62 = New System.Windows.Forms.Button
        CType(Me.nudKolicina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDanCas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgNaknade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbSifraNaknade
        '
        Me.tbSifraNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSifraNaknade.Location = New System.Drawing.Point(136, 81)
        Me.tbSifraNaknade.MaxLength = 2
        Me.tbSifraNaknade.Name = "tbSifraNaknade"
        Me.tbSifraNaknade.Size = New System.Drawing.Size(48, 23)
        Me.tbSifraNaknade.TabIndex = 0
        Me.tbSifraNaknade.Text = ""
        Me.tbSifraNaknade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbIvicniBroj
        '
        Me.tbIvicniBroj.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIvicniBroj.Location = New System.Drawing.Point(184, 81)
        Me.tbIvicniBroj.MaxLength = 2
        Me.tbIvicniBroj.Name = "tbIvicniBroj"
        Me.tbIvicniBroj.Size = New System.Drawing.Size(48, 23)
        Me.tbIvicniBroj.TabIndex = 1
        Me.tbIvicniBroj.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kolicina"
        '
        'nudKolicina
        '
        Me.nudKolicina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudKolicina.Location = New System.Drawing.Point(136, 160)
        Me.nudKolicina.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudKolicina.Name = "nudKolicina"
        Me.nudKolicina.Size = New System.Drawing.Size(56, 22)
        Me.nudKolicina.TabIndex = 3
        Me.nudKolicina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudKolicina.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(240, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Dan / Cas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'nudDanCas
        '
        Me.nudDanCas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDanCas.Location = New System.Drawing.Point(320, 160)
        Me.nudDanCas.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudDanCas.Name = "nudDanCas"
        Me.nudDanCas.Size = New System.Drawing.Size(56, 22)
        Me.nudDanCas.TabIndex = 9
        Me.nudDanCas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(576, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Šifra placanja"
        Me.Label5.Visible = False
        '
        'cbSifPlacanja
        '
        Me.cbSifPlacanja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSifPlacanja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbSifPlacanja.Items.AddRange(New Object() {"1 = Ulazni prelaz", "2 = Izlazni prelaz"})
        Me.cbSifPlacanja.Location = New System.Drawing.Point(592, 168)
        Me.cbSifPlacanja.Name = "cbSifPlacanja"
        Me.cbSifPlacanja.Size = New System.Drawing.Size(72, 23)
        Me.cbSifPlacanja.TabIndex = 2
        Me.cbSifPlacanja.Visible = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(246, 205)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Valuta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Iznos"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgNaknade
        '
        Me.dgNaknade.CaptionText = "L i s t a   n a k n a d a"
        Me.dgNaknade.DataMember = ""
        Me.dgNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgNaknade.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgNaknade.Location = New System.Drawing.Point(16, 232)
        Me.dgNaknade.Name = "dgNaknade"
        Me.dgNaknade.Size = New System.Drawing.Size(728, 216)
        Me.dgNaknade.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(304, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 23)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "..."
        '
        'btnStanicaPr
        '
        Me.btnStanicaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnStanicaPr.Location = New System.Drawing.Point(24, 81)
        Me.btnStanicaPr.Name = "btnStanicaPr"
        Me.btnStanicaPr.Size = New System.Drawing.Size(75, 24)
        Me.btnStanicaPr.TabIndex = 34
        Me.btnStanicaPr.Text = "Naknada"
        '
        'lblNazivNaknade
        '
        Me.lblNazivNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblNazivNaknade.ForeColor = System.Drawing.Color.Gray
        Me.lblNazivNaknade.Location = New System.Drawing.Point(384, 81)
        Me.lblNazivNaknade.Name = "lblNazivNaknade"
        Me.lblNazivNaknade.Size = New System.Drawing.Size(360, 23)
        Me.lblNazivNaknade.TabIndex = 35
        '
        'Label18
        '
        Me.Label18.Enabled = False
        Me.Label18.Location = New System.Drawing.Point(32, 456)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 23)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "Datum naknade"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label18.Visible = False
        '
        'dtPickDatumNaknade
        '
        Me.dtPickDatumNaknade.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtPickDatumNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.dtPickDatumNaknade.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtPickDatumNaknade.Location = New System.Drawing.Point(32, 480)
        Me.dtPickDatumNaknade.Name = "dtPickDatumNaknade"
        Me.dtPickDatumNaknade.Size = New System.Drawing.Size(112, 21)
        Me.dtPickDatumNaknade.TabIndex = 51
        Me.dtPickDatumNaknade.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2Nak)
        Me.GroupBox1.Controls.Add(Me.fxIznosNak)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnIndKol)
        Me.GroupBox1.Controls.Add(Me.fxIznosNak1)
        Me.GroupBox1.Controls.Add(Me.cbObracun)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbValutaNak)
        Me.GroupBox1.Controls.Add(Me.btnDodajNak)
        Me.GroupBox1.Controls.Add(Me.btnBrisiNak)
        Me.GroupBox1.Controls.Add(Me.btnIzmeniNak)
        Me.GroupBox1.Controls.Add(Me.dgNaknade)
        Me.GroupBox1.Controls.Add(Me.tbIvicniBroj)
        Me.GroupBox1.Controls.Add(Me.tbSifraNaknade)
        Me.GroupBox1.Controls.Add(Me.dtPickDatumNaknade)
        Me.GroupBox1.Controls.Add(Me.lblNazivNaknade)
        Me.GroupBox1.Controls.Add(Me.btnStanicaPr)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbSifPlacanja)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.nudDanCas)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.nudKolicina)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(205, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 512)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Naknade ] "
        '
        'Button2Nak
        '
        Me.Button2Nak.Location = New System.Drawing.Point(488, 40)
        Me.Button2Nak.Name = "Button2Nak"
        Me.Button2Nak.Size = New System.Drawing.Size(104, 23)
        Me.Button2Nak.TabIndex = 401
        Me.Button2Nak.Text = "2 naknade"
        Me.Button2Nak.Visible = False
        '
        'fxIznosNak
        '
        Me.fxIznosNak.BackColor = System.Drawing.Color.White
        Me.fxIznosNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxIznosNak.ForeColor = System.Drawing.Color.Black
        Me.fxIznosNak.Location = New System.Drawing.Point(136, 200)
        Me.fxIznosNak.Name = "fxIznosNak"
        Me.fxIznosNak.Size = New System.Drawing.Size(96, 22)
        Me.fxIznosNak.TabIndex = 4
        Me.fxIznosNak.Text = "0"
        Me.fxIznosNak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 48)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ Naknada zavisi od broja kola ]"
        Me.GroupBox2.Visible = False
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(224, 20)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(112, 24)
        Me.RadioButton3.TabIndex = 61
        Me.RadioButton3.Text = "11 i vise kola"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(120, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton2.TabIndex = 60
        Me.RadioButton2.Text = "6-10 kola"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(25, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(72, 24)
        Me.RadioButton1.TabIndex = 59
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "1-5 kola"
        '
        'btnIndKol
        '
        Me.btnIndKol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIndKol.Location = New System.Drawing.Point(248, 81)
        Me.btnIndKol.Name = "btnIndKol"
        Me.btnIndKol.Size = New System.Drawing.Size(40, 23)
        Me.btnIndKol.TabIndex = 58
        Me.btnIndKol.Text = "->"
        '
        'fxIznosNak1
        '
        Me.fxIznosNak1.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxIznosNak1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxIznosNak1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxIznosNak1.Location = New System.Drawing.Point(424, 136)
        Me.fxIznosNak1.Mask = "#########9d##"
        Me.fxIznosNak1.Name = "fxIznosNak1"
        Me.fxIznosNak1.Size = New System.Drawing.Size(88, 23)
        Me.fxIznosNak1.TabIndex = 400
        Me.fxIznosNak1.Text = "0"
        Me.fxIznosNak1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.fxIznosNak1.Visible = False
        '
        'cbObracun
        '
        Me.cbObracun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObracun.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbObracun.Items.AddRange(New Object() {"1 = Naplaceno na blagajni", "2 = Centralni obracun"})
        Me.cbObracun.Location = New System.Drawing.Point(136, 119)
        Me.cbObracun.Name = "cbObracun"
        Me.cbObracun.Size = New System.Drawing.Size(240, 24)
        Me.cbObracun.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Vrsta obracuna"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbValutaNak
        '
        Me.tbValutaNak.Enabled = False
        Me.tbValutaNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValutaNak.Location = New System.Drawing.Point(320, 197)
        Me.tbValutaNak.Name = "tbValutaNak"
        Me.tbValutaNak.Size = New System.Drawing.Size(56, 22)
        Me.tbValutaNak.TabIndex = 5
        Me.tbValutaNak.Text = ""
        Me.tbValutaNak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDodajNak
        '
        Me.btnDodajNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodajNak.Image = CType(resources.GetObject("btnDodajNak.Image"), System.Drawing.Image)
        Me.btnDodajNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodajNak.Location = New System.Drawing.Point(312, 456)
        Me.btnDodajNak.Name = "btnDodajNak"
        Me.btnDodajNak.Size = New System.Drawing.Size(62, 48)
        Me.btnDodajNak.TabIndex = 6
        Me.btnDodajNak.Text = "Dodaj"
        Me.btnDodajNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnBrisiNak
        '
        Me.btnBrisiNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiNak.Image = CType(resources.GetObject("btnBrisiNak.Image"), System.Drawing.Image)
        Me.btnBrisiNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiNak.Location = New System.Drawing.Point(400, 456)
        Me.btnBrisiNak.Name = "btnBrisiNak"
        Me.btnBrisiNak.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiNak.TabIndex = 8
        Me.btnBrisiNak.Text = "Brisi"
        Me.btnBrisiNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnIzmeniNak
        '
        Me.btnIzmeniNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIzmeniNak.Image = CType(resources.GetObject("btnIzmeniNak.Image"), System.Drawing.Image)
        Me.btnIzmeniNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIzmeniNak.Location = New System.Drawing.Point(320, 456)
        Me.btnIzmeniNak.Name = "btnIzmeniNak"
        Me.btnIzmeniNak.Size = New System.Drawing.Size(62, 48)
        Me.btnIzmeniNak.TabIndex = 7
        Me.btnIzmeniNak.Text = "Izmeni"
        Me.btnIzmeniNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIzmeniNak.Visible = False
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(875, 615)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 2
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(771, 615)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 1
        Me.btnPrihvati.Text = "Prihvati  [ F12 ]"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(48, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(96, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(208, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(600, 53)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Naknade za sporedne usluge"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(48, 152)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Nak_validating"
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(48, 120)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Load"
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(48, 192)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(112, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "IB_Validating"
        Me.Button4.Visible = False
        '
        'ButtonFilter62
        '
        Me.ButtonFilter62.Enabled = False
        Me.ButtonFilter62.Location = New System.Drawing.Point(64, 280)
        Me.ButtonFilter62.Name = "ButtonFilter62"
        Me.ButtonFilter62.TabIndex = 8
        Me.ButtonFilter62.Text = "FILTER62"
        Me.ButtonFilter62.Visible = False
        '
        'naknade
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.ButtonFilter62)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "naknade"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ": Naknade za sporedne usluge :"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.nudKolicina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDanCas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgNaknade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FormatNakGrid()
        'Col1.AutoIncrement = True
        'Col1.ReadOnly = True
        If dsNaknade Is Nothing Then
            dgNaknade.DataSource = dtNaknade
        Else
            dgNaknade.DataSource = dsNaknade.Tables(0)

            'dvNaknada.RowFilter = "Action LIKE 'U'"
            'dgNaknade.DataSource = dvNaknada
            'dgNaknade.Refresh()
        End If
    End Sub
    Private Sub tbSifraNaknade_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSifraNaknade.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub tbIvicniBroj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbIvicniBroj.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            bIvicniBroj = tbIvicniBroj.Text
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub nudKolicina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudKolicina.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub nudDanCas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudDanCas.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub dtPickDatumNaknade_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtPickDatumNaknade.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub tbValutaNak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbValutaNak.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub cbSifPlacanja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSifPlacanja.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub tbIznosNak_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub tbIvicniBroj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbIvicniBroj.Validating

        'Me.Button4_Click(Me, Nothing)     'DODATI U KONACNOJ VERZIJI


        Dim temp_mTarifa As String = mTarifa
        Dim mTarifaTemp As String = mTarifa

        Dim NepostojeciIB As Boolean = False

        If IsNumeric(tbIvicniBroj.Text) = True Then

            If Len(tbIvicniBroj.Text) < 2 Then
                tbIvicniBroj.Text = "0" & tbIvicniBroj.Text
            End If

            bIvicniBroj = tbIvicniBroj.Text
            bNakRetVal = ""
            'bValuta = ""

            If tbSifraNaknade.Text <> "35" And tbSifraNaknade.Text <> "36" Then
                If IzborSaobracaja = "2" Or IzborSaobracaja = "3" Then
                    If mTarifa = "00" Then
                        mTarifa = "36"
                    Else
                        mTarifa = mTarifa
                    End If
                ElseIf IzborSaobracaja = "1" Then
                    mTarifaTemp = mTarifa
                    mTarifa = "36"
                End If

                Dim bSaobracaj, bVrstaSaobracajaT As Integer

                If bValuta = "72" Then
                    bSaobracaj = 1
                ElseIf bValuta = "17" Then
                    If bbDatum < #1/15/2015# Then
                        bSaobracaj = 2
                    Else
                        bSaobracaj = 0
                    End If
                End If

                Dim VALUTA As String

                bNadjiSveIzZSNaknada(bSifraNaknade, bIvicniBroj, bSaobracaj, mTarifa, bbDatum, _
                                     VALUTA, bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bNakRetVal)

                If bNakRetVal <> "" Then
                    NepostojeciIB = True
                End If

                If mTarifa = "68" Then
                    If bIznos1 = 0 Then
                        bNadjiSveIzZSNaknada(bSifraNaknade, bIvicniBroj, bSaobracaj, "36", bbDatum, _
                                             bValuta, bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bNakRetVal)
                    End If
                End If
                '---------------------------------- Podbroj ---------------------------------
                If Val(bPodBroj) > 0 And Val(bPodBroj) < 9 Then
                    ''vazece
                    bVrstaSaobracajaT = bVrstaSaobracaja    ' zbog upita koji u Help formi ima parametar bVrstaSaobracaja
                    bVrstaSaobracaja = bSaobracaj

                    Dim helpNakPodbroj As New NakHelpForm
                    helpNakPodbroj.Text = "help - Izbor naknade"
                    helpNakPodbroj.ShowDialog()
                    bNazivNaknade = mIzlaz2
                    bIznos1 = mIzlaz3

                    bVrstaSaobracaja = bVrstaSaobracajaT    ' zbog upita koji u Help formi ima parametar bVrstaSaobracaja

                    'problem: enter odmah zatvori formu
                    'Dim helpNak As New HelpForm
                    'helpNak.Text = "help Naknade"
                    'upit = "NAK2"
                    'helpNak.ShowDialog()
                    'bNazivNaknade = mIzlaz2
                    'bIznos1 = mIzlaz3
                    'Me.cbObracun.Focus()

                    'Button2Nak_Click(Me, Nothing)

                End If
                '----------------------------------------------------------------------------
                mTarifa = mTarifaTemp
            Else                ' koloseci
                Dim tmp_MMStanica1, tmp_MMStanica2, ind_Stanica As String

                If Len(mManipulativnoMesto1) = 5 Then
                    tmp_MMStanica1 = mStanica1
                    mStanica1 = mManipulativnoMesto1
                End If
                If Len(mManipulativnoMesto2) = 5 Then
                    tmp_MMStanica2 = mStanica2
                    mStanica2 = mManipulativnoMesto2
                End If

                If tbSifraNaknade.Text = "35" Then
                    ind_Stanica = "72" & mStanica2
                ElseIf tbSifraNaknade.Text = "36" Then
                    ind_Stanica = "72" & mStanica1
                End If

                If bVrstaSaobracaja = 0 Then
                    bValuta = "72"
                Else
                    bValuta = "17"
                End If


                'If IzborSaobracaja = "2" Then
                '    ind_Stanica = "72" & mStanica2
                '    bValuta = "17"
                'ElseIf IzborSaobracaja = "3" Then
                '    ind_Stanica = "72" & mStanica1
                '    bValuta = "17"
                'End If
                bIznos1 = 0


                If bNakRetVal <> "" Then
                    NepostojeciIB = True
                End If

                Dim bUkupnoKoloseka As Integer = 0
                Dim bRetVal As String
                bDupliKoloseci = False
                bNadjiDupleSifreKoloseka(ind_Stanica, bIvicniBroj, bUkupnoKoloseka, bRetVal)

                If bUkupnoKoloseka > 1 Then
                    bDupliKoloseci = True
                    If nmHelpFormIK = False Then
                        Me.btnIndKol_Click(Me, Nothing)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Dim helpNak As New HelpForm
                    'helpNak.Text = "help Naknade"
                    'upit = "INDKOL"
                    'helpNak.ShowDialog()

                    'Me.tbIvicniBroj.Text = mIzlaz1
                    'Me.lblNazivNaknade.Text = bIzlazNazivKoloseka
                    ''Me.fxIznosNak.Text = CDec(mIzlaz2)

                    'Me.fxIznosNak.Focus()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    bNazivNaknade = lblNazivNaknade.Text
                    bIznos1 = bIzlazCena1
                    bIznos2 = bIzlazCena2
                    bIznos3 = bIzlazCena3
                Else
                    bDupliKoloseci = False
                    If bVrstaSaobracaja = 0 Then
                        bNadjiIndKolDin(ind_Stanica, bIvicniBroj, bbDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bNakRetVal)
                        'uzeti jednu od tri vrednosti
                        bIznos1 = bIznos1 * bKoefZaKoloseke
                        bZaokruziNaDeseteNanize(bIznos1)
                        bIznos2 = bIznos2 * bKoefZaKoloseke
                        bZaokruziNaDeseteNanize(bIznos2)
                        bIznos3 = bIznos3 * bKoefZaKoloseke
                        bZaokruziNaDeseteNanize(bIznos3)
                    Else
                        bNadjiIndKol(ind_Stanica, bIvicniBroj, bbDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bNakRetVal)
                        'uzeti jednu od tri vrednosti bez mnozenja
                    End If
                End If

            End If

            lblNazivNaknade.Text = bNazivNaknade

            If Me.GroupBox2.Visible = True Then
                If Me.RadioButton1.Checked = True Then
                    fxIznosNak.Text = bIznos1
                End If
                If Me.RadioButton2.Checked = True Then
                    fxIznosNak.Text = bIznos2
                End If
                If Me.RadioButton3.Checked = True Then
                    fxIznosNak.Text = bIznos3
                End If
            Else
                fxIznosNak.Text = bIznos1
            End If
            '''            fxIznosNak.Text = bIznos1

            mTarifa = temp_mTarifa

            If Not (bNakRetVal = "") Then
                tbSifraNaknade.Focus()
            End If

            ErrorProvider1.SetError(tbIvicniBroj, "")
            'Me.cbObracun.Focus()
            Me.nudKolicina.Focus()
        Else
            ErrorProvider1.SetError(tbIvicniBroj, "Neispravan unos!")
            Me.tbIvicniBroj.Focus()
        End If

        If NepostojeciIB Then
            ErrorProvider1.SetError(tbIvicniBroj, "Neispravna sifra naknade / ivicni broj!")
            MessageBox.Show("Neispravna sifra naknade / ivicni broj!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'jos(dodati)
            Me.tbSifraNaknade.Focus()
            NepostojeciIB = False
        End If


        If Not ((bSifraNaknade = "43" And bIvicniBroj = "01") Or (bSifraNaknade = "43" And bIvicniBroj = "02")) Then
            Me.nudKolicina.Value = dtKola.Rows.Count
            nudKolicina.Text = dtKola.Rows.Count
        Else
            Me.nudKolicina.Value = 1
            nudKolicina.Text = 1
        End If

        mTarifa = mTarifaTemp


    End Sub
    'Private Sub bNadjiSveIzZSNaknada( _
    '                            ByVal inSifraNaknade As String, _
    '                            ByVal inIvicniBroj As String, _
    '                            ByVal inVrstaSaobracaja As Integer, _
    '                            ByVal inTarifa As String, _
    '                            ByVal inDatum As DateTime, _
    '                            ByRef outSifraValute As String, _
    '                            ByRef outNazivNaknade As String, _
    '                            ByRef outPodBroj As String, _
    '                            ByRef outIznos1 As Decimal, _
    '                            ByRef outIznos2 As Decimal, _
    '                            ByRef outIznos3 As Decimal, _
    '                            ByRef outMinimum As Decimal, _
    '                            ByRef outRetVal As String)

    '    If DbVeza.State = ConnectionState.Closed Then
    '        DbVeza.Open()
    '    End If

    '    Dim spKomanda As New SqlClient.SqlCommand("bspNadjiSveIzZSNaknade", DbVeza)
    '    spKomanda.CommandType = CommandType.StoredProcedure

    '    Dim ulSifraNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifra", SqlDbType.Char, 2))
    '    ulSifraNaknade.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inSifra").Value = inSifraNaknade

    '    Dim ulIvicniBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIvicniBroj", SqlDbType.Char, 2))
    '    ulIvicniBroj.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inIvicniBroj").Value = inIvicniBroj

    '    Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaSaobracaja", SqlDbType.Int))
    '    ulVrstaSaobracaja.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inVrstaSaobracaja").Value = inVrstaSaobracaja

    '    Dim ulTarifa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTarifa", SqlDbType.Char, 2))
    '    ulTarifa.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inTarifa").Value = inTarifa

    '    Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
    '    ulDatum.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inDatum").Value = inDatum

    '    Dim izlSifraValute As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraValute", SqlDbType.Char, 2))
    '    izlSifraValute.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outSifraValute").Value = outSifraValute

    '    Dim izlNazivNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivNaknade", SqlDbType.VarChar, 50))
    '    izlNazivNaknade.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outNazivNaknade").Value = outNazivNaknade

    '    Dim izlPodBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPodBroj", SqlDbType.Char, 1))
    '    izlPodBroj.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outPodBroj").Value = outPodBroj

    '    Dim izlIznos1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos1", SqlDbType.Decimal))
    '    izlIznos1.Size = 9
    '    izlIznos1.Precision = 10
    '    izlIznos1.Scale = 2
    '    izlIznos1.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outIznos1").Value = outIznos1

    '    Dim izlIznos2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos2", SqlDbType.Decimal))
    '    izlIznos2.Size = 9
    '    izlIznos2.Precision = 10
    '    izlIznos2.Scale = 2
    '    izlIznos2.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outIznos2").Value = outIznos2

    '    Dim izlIznos3 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos3", SqlDbType.Decimal))
    '    izlIznos3.Size = 9
    '    izlIznos3.Precision = 10
    '    izlIznos3.Scale = 2
    '    izlIznos3.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outIznos3").Value = outIznos3

    '    Dim izlMinimum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinimum", SqlDbType.Decimal))
    '    izlMinimum.Size = 9
    '    izlMinimum.Precision = 10
    '    izlMinimum.Scale = 2
    '    izlMinimum.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outMinimum").Value = outMinimum

    '    Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar))
    '    izlRetVal.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outRetVal").Value = outRetVal

    '    Try

    '        spKomanda.ExecuteScalar()

    '        'Dim Pom As Int16 = spKomanda.Parameters("@PovrVrednost").Value
    '        'Pom = spKomanda.Parameters("@PovrVrednost").Value
    '        'If Pom <> 0 Then outRetVal = " Neuspesan upit!" 'Pom = spKomanda.Parameters("@PovrVrednost").Value

    '        outNazivNaknade = spKomanda.Parameters("@outNazivNaknade").Value
    '        outSifraValute = spKomanda.Parameters("@outSifraValute").Value
    '        outPodBroj = spKomanda.Parameters("@outPodBroj").Value
    '        outIznos1 = spKomanda.Parameters("@outIznos1").Value
    '        outIznos2 = spKomanda.Parameters("@outIznos2").Value
    '        outIznos3 = spKomanda.Parameters("@outIznos3").Value
    '        outMinimum = spKomanda.Parameters("@outMinimum").Value
    '        outRetVal = spKomanda.Parameters("@outRetVal").Value

    '    Catch SQLExp As SqlException
    '        outRetVal = SQLExp.Message & " SQL greska u programu!"
    '    Catch Exp As Exception
    '        outRetVal = Err.Description & " Greska u programu!"
    '    Finally

    '        DbVeza.Close()
    '        spKomanda.Dispose()

    '    End Try

    'End Sub

    Private Sub naknade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Button3_Click(Me, Nothing)

        ''FormatNakGrid()
        ''tbSifraNaknade.Focus()

        ''bVrstaSaobracaja = IzborSaobracaja
        ''nudKolicina.Text = bKolicina
        ''nudDanCas.Text = bDanCas
        ''Me.cbSifPlacanja.Text = "1 = Naplaceno na blagajni"
        ''If mTarifa = "38" Then
        ''    tbValutaNak.Text = "85"
        ''Else
        ''    tbValutaNak.Text = "17"
        ''End If

        ''If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then
        ''    Me.cbSifPlacanja.Enabled = True
        ''    Me.cbSifPlacanja.SelectedIndex = 1 '.Text = "2 = Centralni obracun"
        ''Else
        ''    Me.cbSifPlacanja.Enabled = False
        ''    Me.cbSifPlacanja.SelectedIndex = 0
        ''End If
    End Sub

    Private Sub nudKolicina_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nudKolicina.Validating
        bKolicina = nudKolicina.Text
        bDanCas = nudDanCas.Text
        bNadjiIznosNaknade(bSifraNaknade, bIvicniBroj, bKolicina, bDanCas, bValuta, bIznos1, bIznos2, bIznos3, bIznosNakn)
        'tbIznosNak.Text = bIznosNakn
        fxIznosNak.Text = bIznosNakn
    End Sub

    Private Sub nudDanCas_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nudDanCas.Validating
        bKolicina = nudKolicina.Text
        bDanCas = nudDanCas.Text
        bNadjiIznosNaknade(bSifraNaknade, bIvicniBroj, bKolicina, bDanCas, bValuta, bIznos1, bIznos2, bIznos3, bIznosNakn)
        'tbIznosNak.Text = bIznosNakn
        fxIznosNak.Text = bIznosNakn
        btnDodajNak.Focus()
    End Sub

    Private Sub btnDodajNak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajNak.Click
        Dim nSifraNaknade As String
        Dim nIvBrojNaknade As String
        Dim nIznos As Decimal = 0
        Dim nValuta As String
        Dim nKolicina As Int32 = 0
        Dim nDanCas As Int32 = 0

        Dim nVrstaObracuna As String = ""
        Dim RBNaknade As Int16

        nSifraNaknade = tbSifraNaknade.Text
        nIvBrojNaknade = Me.tbIvicniBroj.Text

        'nIznos = bIznosNakn
        'fxIznosNak.Text = bIznosNakn
        nValuta = bValuta
        nKolicina = Me.nudKolicina.Value
        nDanCas = Me.nudDanCas.Value
        'nPlacanje = Microsoft.VisualBasic.Mid(cbSifPlacanja.Text.ToString, 1, 1)


        If Microsoft.VisualBasic.Mid(cbObracun.Text.ToString, 1, 1) = "2" Then
            nVrstaObracuna = "C"
        Else
            nVrstaObracuna = "R"
        End If

        Dim dtRow As DataRow = dtNaknade.NewRow

        dtNaknade.Rows.Add(New Object() {nSifraNaknade, nIvBrojNaknade, fxIznosNak.Text, nValuta, nKolicina, nDanCas, "0", nVrstaObracuna, "I"})
        dgNaknade.Refresh()
        RBNaknade = dtNaknade.Rows.Count
        bNazivNaknadeArr(RBNaknade - 1) = bNazivNaknade
        Me.tbSifraNaknade.Clear()
        Me.tbIvicniBroj.Clear()
        'Me.nudKolicina.Value = 1
        'nudKolicina.Text = 1

        If Not (nSifraNaknade = "43" And nIvBrojNaknade = "1") Or (nSifraNaknade = "43" And nIvBrojNaknade = "1") Then
            Me.nudKolicina.Value = dtKola.Rows.Count
            nudKolicina.Text = dtKola.Rows.Count
        Else
            Me.nudKolicina.Value = 1
            nudKolicina.Text = 1
        End If


        Me.nudDanCas.Value = 0
        Me.cbSifPlacanja.Text = ""
        'Me.tbIznosNak.Text = 0 
        Me.fxIznosNak.Text = 0
        'Me.tbValutaNak.Clear()
        Me.GroupBox2.Visible = False
        Me.lblNazivNaknade.Text = ""

        bDupliKoloseci = False

        tbSifraNaknade.Focus()

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click

        Dim Nak_Red As DataRow
        'Dim mSumaNakR As Decimal = 0
        mSumaNak = 0
        mSumaNakCo = 0
        mSumaNakRo = 0
        mSumaNakCo82 = 0
        _OpenForm = "Naknade"

        If dtNaknade.Rows.Count > 0 Then
            '_OpenForm = "Naknade"
            mPrikazKalkulacije = "D"

            For Each Nak_Red In dtNaknade.Rows
                If Nak_Red.Item("Obracun") = "C" Then
                    If Nak_Red.Item("Sifra") = "82" And Nak_Red.Item("IvicniBroj") = "16" Then
                        Nak_Red.Item("Iznos") = 0
                        mSumaNakCo82 = mSumaNakCo82 + Nak_Red.Item("Iznos")
                    Else
                        mSumaNakCo = mSumaNakCo + Nak_Red.Item("Iznos")
                    End If
                Else
                    mSumaNakRo = mSumaNakRo + Nak_Red.Item("Iznos")
                End If

            Next
            mSumaNak = mSumaNakRo + mSumaNakCo82 + mSumaNakCo
            If dtNaknade.Rows.Count > 4 Then
                MessageBox.Show("Smanjiti broj naknada tako da sve budu vidljive na glavnoj formi!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                tbSifraNaknade.Focus()
            Else
                Me.Close()
            End If
        Else
            mSumaNak = 0
            '    MessageBox.Show("Niste uneli sve potrebne podatke!", "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    tbSifraNaknade.Focus()
            Close()

        End If


        bOsveziNizNazivaNaknada()


    End Sub

    Private Sub btnIzmeniNak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzmeniNak.Click
        Me.btnDodajNak.Visible = True
        Me.btnIzmeniNak.Visible = False

        Dim row As Data.DataRow

        row = CType(dgNaknade.DataSource, DataTable).Rows(dgNaknade.CurrentCell.RowNumber)

        row("Sifra") = Me.tbSifraNaknade.Text
        row("IvicniBroj") = Me.tbIvicniBroj.Text
        'row("Iznos") = tbIznosNak.Text
        row("Iznos") = fxIznosNak.Text
        If bVrstaSaobracaja = 0 Then
            tbValutaNak.Text = "72"
        Else
            tbValutaNak.Text = "17"
        End If

        row("Valuta") = tbValutaNak.Text
        row("Kolicina") = Me.nudKolicina.Text
        row("DanCas") = Me.nudDanCas.Text

        'If Microsoft.VisualBasic.Mid(cbSifPlacanja.Text.ToString, 1, 1) = "1" Then
        '    row("Placanje") = "1"
        'Else
        '    row("Placanje") = "2"
        'End If

        row("Placanje") = "0"

        If Microsoft.VisualBasic.Mid(cbObracun.Text.ToString, 1, 1) = "1" Then
            row("Obracun") = "R"
        Else
            row("Obracun") = "C"
        End If

        If MasterAction = "New" Then
            row("Action") = "I"
        Else
            row("Action") = "U"
        End If

        dgNaknade.Refresh()
        Me.tbSifraNaknade.Clear()
        Me.tbIvicniBroj.Clear()
        Me.cbSifPlacanja.Text = " "
        Me.cbObracun.Text = " "
        Me.nudKolicina.Text = 1
        Me.nudDanCas.Text = 0
        'Me.tbIznosNak.Text = 0
        Me.fxIznosNak.Text = 0
        Me.tbValutaNak.Clear()
        Me.lblNazivNaknade.Text = ""
        Me.GroupBox2.Visible = False

        Me.tbSifraNaknade.Focus()

    End Sub

    Private Sub btnBrisiNak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiNak.Click
        If MasterAction = "New" Then
            Try
                CType(dgNaknade.DataSource, DataTable).Rows(dgNaknade.CurrentCell.RowNumber).Delete()
            Catch ex As Exception
                MsgBox(ex, MsgBoxStyle.Critical)
            Finally

                Me.tbSifraNaknade.Clear()
                'Me.tbIznosNak.Text = 0
                Me.fxIznosNak.Text = 0
                Me.tbValutaNak.Clear()
                Me.nudDanCas.Text = 0
                Me.nudKolicina.Text = 1
                Me.cbSifPlacanja.Text = ""
                Me.cbObracun.Text = ""
                Me.lblNazivNaknade.Text = ""
                Me.tbIvicniBroj.Clear()
                Me.GroupBox2.Visible = False
                bNazivNaknadeArr(dgNaknade.CurrentCell.RowNumber) = ""
                Me.tbSifraNaknade.Focus()
            End Try
        Else
            Try
                Dim rowNak As Data.DataRow

                rowNak = CType(dgNaknade.DataSource, DataTable).Rows(dgNaknade.CurrentCell.RowNumber)
                rowNak = dtNaknade.Rows(dgNaknade.CurrentCell.RowNumber)
                rowNak("Action") = "D"

                dvNaknada.RowFilter = "Action LIKE 'U'"
                dgNaknade.DataSource = dvNaknada
                dgNaknade.Refresh()

            Catch ex As Exception
            Finally
                dgNaknade.Refresh()

                Me.tbSifraNaknade.Clear()
                tbIvicniBroj.Clear()
                'Me.tbIznosNak.Text = 0
                Me.fxIznosNak.Text = 0
                Me.tbValutaNak.Clear()
                Me.nudDanCas.Text = 0
                Me.nudKolicina.Text = 1
                Me.cbSifPlacanja.Text = ""
                Me.cbObracun.Text = ""

                Me.lblNazivNaknade.Text = ""
                Me.tbIvicniBroj.Clear()
                Me.GroupBox2.Visible = False

                Me.tbSifraNaknade.Focus()
                Me.btnIzmeniNak.Visible = False
                Me.btnDodajNak.Visible = True

            End Try
        End If

    End Sub

    Private Sub dgNaknade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgNaknade.Click

        Me.btnDodajNak.Visible = False
        Me.btnIzmeniNak.Visible = True

        Dim _obracunTmp As String

        Me.btnDodajNak.Visible = False
        Me.btnIzmeniNak.Visible = True


        'Try
        '    Dim currRow As Data.DataRow

        '    currRow = CType(dgNaknade.DataSource, DataTable).Rows(dgNaknade.CurrentCell.RowNumber)
        '    currRow = dtNaknade.Rows(dgNaknade.CurrentCell.RowNumber)
        '    tbSifraNaknade.Text = currRow(0, DataRowVersion.Current).ToString()
        '    tbIvicniBroj.Text = currRow(1, DataRowVersion.Current).ToString()
        '    'tbIznosNak.Text = currRow(2, DataRowVersion.Current).ToString()
        '    fxIznosNak.Text = currRow(2, DataRowVersion.Current).ToString()
        '    tbValutaNak.Text = currRow(3, DataRowVersion.Current).ToString()
        '    nudKolicina.Value = currRow(4, DataRowVersion.Current).ToString()
        '    nudDanCas.Value = currRow(5, DataRowVersion.Current).ToString()
        '    cbSifPlacanja.Text = currRow(6, DataRowVersion.Current).ToString()
        '    _obracunTmp = currRow(6, DataRowVersion.Current).ToString()

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        Dim currRow As DataRow
        currRow = CType(dgNaknade.DataSource, DataTable).Rows(dgNaknade.CurrentCell.RowNumber)

        tbSifraNaknade.Text = currRow(0, DataRowVersion.Current).ToString()
        tbIvicniBroj.Text = currRow(1, DataRowVersion.Current).ToString()
        'tbIznosNak.Text = currRow(2, DataRowVersion.Current).ToString()
        fxIznosNak.Text = currRow(2, DataRowVersion.Current).ToString()
        tbValutaNak.Text = currRow(3, DataRowVersion.Current).ToString()
        nudKolicina.Value = currRow(4, DataRowVersion.Current).ToString()
        nudDanCas.Value = currRow(5, DataRowVersion.Current).ToString()
        cbSifPlacanja.Text = currRow(6, DataRowVersion.Current).ToString()
        _obracunTmp = currRow(6, DataRowVersion.Current).ToString()

        Me.tbSifraNaknade.Focus()

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        dtNaknade.Clear()
        For k As Integer = 0 To 10
            bNazivNaknadeArr(k) = ""
        Next k
        Close()

    End Sub

    Private Sub gbObracun_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub cbSifPlacanja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSifPlacanja.GotFocus
        Me.cbSifPlacanja.DroppedDown = True

    End Sub

    Private Sub gbObracun_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'tbIznosNak.Focus()
        fxIznosNak.Focus()

    End Sub
    Private Sub cbObracun_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbObracun.GotFocus
        Me.cbObracun.DroppedDown = True
    End Sub

    Private Sub cbObracun_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbObracun.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub naknade_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnPrihvati_Click(Me, Nothing)
        End If
    End Sub

    Private Sub tbSifraNaknade_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbSifraNaknade.Validating

        'Me.Button2_Click(Me, Nothing)    'DODATI U KONACNOJ VERZIJI

        'If Me.tbSifraNaknade.Text = Nothing Then
        '    If dtNaknade.Rows.Count = 0 Then
        '        'Me.tbSifraNaknade.Focus()
        '        'ErrorProvider1.SetError(tbIvicniBroj, "Zatvorite formu izborom dugmeta Otkazi(Cancel)")
        '        Me.btnPrihvati.Focus()
        '    Else
        '        Me.btnPrihvati.Focus()
        '    End If
        'Else
        '    If IsNumeric(tbSifraNaknade.Text) = True Then
        '        If tbSifraNaknade.Text = "35" Or tbSifraNaknade.Text = "36" Then
        '            Me.btnIndKol.Visible = True
        '            Me.Button1.Visible = False
        '        Else
        '            Me.btnIndKol.Visible = False
        '            Me.Button1.Visible = True
        '        End If
        '        If tbSifraNaknade.Text = "35" Or tbSifraNaknade.Text = "36" Or tbSifraNaknade.Text = "40" Or tbSifraNaknade.Text = "42" Then
        '            Me.GroupBox2.Visible = True
        '        Else
        '            Me.GroupBox2.Visible = False
        '        End If

        '        bSifraNaknade = tbSifraNaknade.Text
        '        ErrorProvider1.SetError(tbIvicniBroj, "")
        '    Else
        '        ErrorProvider1.SetError(tbIvicniBroj, "Neispravan unos!")
        '        Me.tbSifraNaknade.Focus()
        '    End If
        'End If
        If Me.tbSifraNaknade.Text = Nothing Then
            If dtNaknade.Rows.Count = 0 Then
                'Me.tbSifraNaknade.Focus()
                'ErrorProvider1.SetError(tbIvicniBroj, "Zatvorite formu izborom dugmeta Otkazi(Cancel)")
                Me.btnPrihvati.Focus()
            Else
                Me.btnPrihvati.Focus()
            End If
        Else
            If IsNumeric(tbSifraNaknade.Text) = True Then
                If tbSifraNaknade.Text = "35" Or tbSifraNaknade.Text = "36" Then
                    Me.btnIndKol.Visible = True
                    Me.Button1.Visible = False
                Else
                    Me.btnIndKol.Visible = False
                    Me.Button1.Visible = True
                End If
                If tbSifraNaknade.Text = "35" Or tbSifraNaknade.Text = "36" Or tbSifraNaknade.Text = "40" Or tbSifraNaknade.Text = "42" Or tbSifraNaknade.Text = "46" Then
                    Me.GroupBox2.Visible = True

                    If mNak_BrojKola < 6 Then
                        Me.RadioButton1.Checked = True
                    ElseIf mNak_BrojKola >= 6 And mNak_BrojKola < 11 Then
                        Me.RadioButton2.Checked = True
                    ElseIf mNak_BrojKola >= 11 Then
                        Me.RadioButton3.Checked = True
                    End If
                Else
                    Me.GroupBox2.Visible = False
                End If

                bSifraNaknade = tbSifraNaknade.Text
                ErrorProvider1.SetError(tbIvicniBroj, "")

                If Not (bDupliKoloseci) Then
                    Me.tbIvicniBroj.Focus()
                End If
            Else
                ErrorProvider1.SetError(tbIvicniBroj, "Neispravan unos!")
                Me.tbSifraNaknade.Focus()
            End If
            End If

    End Sub

    Private Sub btnStanicaPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStanicaPr.Click
        Dim helpNak As New HelpForm
        helpNak.Text = "help Naknade"
        upit = "NAK"
        helpNak.ShowDialog()
        Me.tbSifraNaknade.Text = mIzlaz1
        Me.tbIvicniBroj.Text = mIzlaz2
        Me.tbIvicniBroj.Focus()
    End Sub
    Private Sub fxIznosNak_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fxIznosNak1.Validating
        If IsNumeric(fxIznosNak.Text) = True Then
            ErrorProvider1.SetError(fxIznosNak, "")
        Else
            ErrorProvider1.SetError(fxIznosNak, "Neispravan unos!")
            fxIznosNak.Focus()
        End If
    End Sub

    Private Sub fxIznosNak_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxIznosNak1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnDodajNak_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDodajNak.GotFocus
        Me.btnDodajNak.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnDodajNak_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDodajNak.Leave
        Me.btnDodajNak.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnPrihvati_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrihvati.GotFocus
        Me.btnPrihvati.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnPrihvati_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrihvati.Leave
        Me.btnPrihvati.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnIzmeniNak_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIzmeniNak.GotFocus
        Me.btnIzmeniNak.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnIzmeniNak_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIzmeniNak.Leave
        Me.btnIzmeniNak.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If IsNumeric(tbIvicniBroj.Text) = True Then

            bSifraNaknade = tbSifraNaknade.Text

            If Len(tbIvicniBroj.Text) < 2 Then
                tbIvicniBroj.Text = "0" & tbIvicniBroj.Text
            End If

            bIvicniBroj = tbIvicniBroj.Text
            bNakRetVal = ""
            'bValuta = ""
            Dim bSaobracaj As Integer
            If bValuta = "72" Then
                bSaobracaj = 1
            ElseIf bValuta = "17" Then
                bSaobracaj = 2
            End If

            Dim VALUTA As String

            bNadjiSveIzZSNaknada(bSifraNaknade, bIvicniBroj, bSaobracaj, mTarifa, bbDatum, _
                                 VALUTA, bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bNakRetVal)


            If (((bSifraNaknade = "35") Or (bSifraNaknade = "36")) And ((bVrstaSaobracaja = 0) Or (mTarifa = "72"))) Then
                bIznos1 = bIznos1 * bKoefZaKoloseke
                bZaokruziNaDeseteNanize(bIznos1)
                bIznos2 = bIznos2 * bKoefZaKoloseke
                bZaokruziNaDeseteNanize(bIznos2)
                bIznos3 = bIznos3 * bKoefZaKoloseke
                bZaokruziNaDeseteNanize(bIznos3)
            End If


            '---------------------------------- Podbroj ---------------------------------
            If CType(bPodBroj, Int16) > 0 And CType(bPodBroj, Int16) < 9 Then
                Dim helpNakPodbroj As New HelpForm

                helpNakPodbroj.Text = "help Naknade"
                upit = "NAKPB"
                helpNakPodbroj.ShowDialog()
                bNazivNaknade = mIzlaz2
                bIznos1 = mIzlaz3
            End If
            '----------------------------------------------------------------------------

            lblNazivNaknade.Text = bNazivNaknade
            fxIznosNak.Text = bIznos1

            If Not (bNakRetVal = "") Then
                tbSifraNaknade.Focus()
            End If

            ErrorProvider1.SetError(tbIvicniBroj, "")
            Me.cbObracun.Focus()
        Else
            ErrorProvider1.SetError(tbIvicniBroj, "Neispravan unos!")
            Me.tbIvicniBroj.Focus()

        End If
    End Sub
    Private Sub bNadjiIznosNaknade(ByVal inSifraNaknade As String, _
                                   ByVal inIvicniBroj As String, _
                                   ByVal inKolicina As Integer, _
                                   ByVal inDanCas As Integer, _
                                   ByVal inValuta As String, _
                                   ByVal inIznos1 As Decimal, _
                                   ByVal inIznos2 As Decimal, _
                                   ByVal inIznos3 As Decimal, _
                                   ByRef outIznosNakn As Decimal)

        outIznosNakn = 0

        If Me.GroupBox2.Visible = True Then
            If Me.RadioButton1.Checked = True Then
                outIznosNakn = inIznos1 * inKolicina
            End If
            If Me.RadioButton2.Checked = True Then
                outIznosNakn = inIznos2 * inKolicina
            End If
            If Me.RadioButton3.Checked = True Then
                outIznosNakn = inIznos3 * inKolicina
            End If
        Else
            outIznosNakn = inIznos1 * inKolicina
        End If

        ''outIznosNakn = inIznos1 * inKolicina

        If inDanCas <> 0 Then
            outIznosNakn = inDanCas * outIznosNakn
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ' tbSifraNaknade Validating 

        '''''''If IsNumeric(tbIvicniBroj.Text) = True Then

        '''''''    '   bSifraNaknade = tbSifraNaknade.Text

        '''''''    If Len(tbIvicniBroj.Text) < 2 Then
        '''''''        tbIvicniBroj.Text = "0" & tbIvicniBroj.Text
        '''''''    End If

        '''''''    bIvicniBroj = tbIvicniBroj.Text
        '''''''    bRetVal = ""
        '''''''    'bValuta = ""

        '''''''    Dim bSaobracaj As Integer
        '''''''    If bValuta = "72" Then
        '''''''        bSaobracaj = 1
        '''''''    ElseIf bValuta = "17" Then
        '''''''        bSaobracaj = 2
        '''''''    End If

        '''''''    Dim VALUTA As String

        '''''''    bNadjiSveIzZSNaknada(bSifraNaknade, bIvicniBroj, bSaobracaj, mTarifa, bDatum, _
        '''''''                         VALUTA, bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bRetVal)

        '''''''    If (((bSifraNaknade = "35") Or (bSifraNaknade = "36")) And ((bVrstaSaobracaja = 0) Or (mTarifa = "72"))) Then
        '''''''        bIznos1 = bIznos1 * 0.8475
        '''''''        bZaokruziNaDeseteNanize(bIznos1)
        '''''''        bIznos2 = bIznos2 * 0.8475
        '''''''        bZaokruziNaDeseteNanize(bIznos2)
        '''''''        bIznos3 = bIznos3 * 0.8475
        '''''''        bZaokruziNaDeseteNanize(bIznos3)
        '''''''    End If

        '''''''    '---------------------------------- Podbroj ---------------------------------
        '''''''    If Val(bPodBroj) > 0 And Val(bPodBroj) < 9 Then

        '''''''        Dim helpNakPodbroj As New NakHelpForm
        '''''''        helpNakPodbroj.Text = "help - Izbor naknade"
        '''''''        helpNakPodbroj.ShowDialog()
        '''''''        bNazivNaknade = mIzlaz2
        '''''''        bIznos1 = mIzlaz3
        '''''''    End If
        '''''''    '----------------------------------------------------------------------------

        '''''''    lblNazivNaknade.Text = bNazivNaknade
        '''''''    fxIznosNak.Text = bIznos1

        '''''''    If Not (bRetVal = "") Then
        '''''''        tbSifraNaknade.Focus()
        '''''''    End If

        '''''''    ErrorProvider1.SetError(tbIvicniBroj, "")
        '''''''    Me.cbObracun.Focus()
        '''''''Else
        '''''''    ErrorProvider1.SetError(tbIvicniBroj, "Neispravan unos!")
        '''''''    Me.tbIvicniBroj.Focus()
        '''''''End If

        If Me.tbSifraNaknade.Text = Nothing Then
            If dtNaknade.Rows.Count = 0 Then
                'Me.tbSifraNaknade.Focus()
                'ErrorProvider1.SetError(tbIvicniBroj, "Zatvorite formu izborom dugmeta Otkazi(Cancel)")
                Me.btnPrihvati.Focus()
            Else
                Me.btnPrihvati.Focus()
            End If
        Else
            If IsNumeric(tbSifraNaknade.Text) = True Then
                If tbSifraNaknade.Text = "35" Or tbSifraNaknade.Text = "36" Then
                    Me.btnIndKol.Visible = True
                    Me.Button1.Visible = False
                Else
                    Me.btnIndKol.Visible = False
                    Me.Button1.Visible = True
                End If
                If tbSifraNaknade.Text = "35" Or tbSifraNaknade.Text = "36" Or tbSifraNaknade.Text = "40" Or tbSifraNaknade.Text = "42" Then
                    Me.GroupBox2.Visible = True

                    If mNak_BrojKola < 6 Then
                        Me.RadioButton1.Checked = True
                    ElseIf mNak_BrojKola >= 6 And mNak_BrojKola < 11 Then
                        Me.RadioButton2.Checked = True
                    ElseIf mNak_BrojKola >= 11 Then
                        Me.RadioButton3.Checked = True
                    End If
                Else
                    Me.GroupBox2.Visible = False
                End If

                bSifraNaknade = tbSifraNaknade.Text
                ErrorProvider1.SetError(tbIvicniBroj, "")

                Me.tbIvicniBroj.Focus()

            Else
                ErrorProvider1.SetError(tbIvicniBroj, "Neispravan unos!")
                Me.tbSifraNaknade.Focus()
            End If
        End If

    End Sub
    'Private Sub bNadjiIndKol(ByVal inStanica As String, ByVal inIvicniBroj As String, ByVal inDatum As DateTime, _
    '                         ByRef outNazivNaknade As String, ByRef outIznos1 As Decimal, ByRef outIznos2 As Decimal, ByRef outIznos3 As Decimal, _
    '                         ByRef outRetVal As String)

    '    If DbVeza.State = ConnectionState.Closed Then
    '        DbVeza.Open()
    '    End If

    '    Dim spKomanda As New SqlClient.SqlCommand("spNadjiIndKol", DbVeza)
    '    spKomanda.CommandType = CommandType.StoredProcedure

    '    Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 7))
    '    ulStanica.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inStanica").Value = inStanica

    '    Dim ulIvicniBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIvicniBroj", SqlDbType.Char, 2))
    '    ulIvicniBroj.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inIvicniBroj").Value = inIvicniBroj

    '    Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
    '    ulDatum.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inDatum").Value = inDatum

    '    Dim izlNazivNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivNaknade", SqlDbType.VarChar, 50))
    '    izlNazivNaknade.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outNazivNaknade").Value = outNazivNaknade

    '    Dim izlIznos1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos1", SqlDbType.Decimal))
    '    izlIznos1.Size = 9
    '    izlIznos1.Precision = 10
    '    izlIznos1.Scale = 2
    '    izlIznos1.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outIznos1").Value = outIznos1

    '    Dim izlIznos2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos2", SqlDbType.Decimal))
    '    izlIznos2.Size = 9
    '    izlIznos2.Precision = 10
    '    izlIznos2.Scale = 2
    '    izlIznos2.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outIznos2").Value = outIznos2

    '    Dim izlIznos3 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos3", SqlDbType.Decimal))
    '    izlIznos3.Size = 9
    '    izlIznos3.Precision = 10
    '    izlIznos3.Scale = 2
    '    izlIznos3.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outIznos3").Value = outIznos3

    '    Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar))
    '    izlRetVal.Direction = ParameterDirection.Output
    '    spKomanda.Parameters("@outRetVal").Value = outRetVal

    '    Try

    '        spKomanda.ExecuteScalar()

    '        outNazivNaknade = spKomanda.Parameters("@outNazivNaknade").Value
    '        outIznos1 = spKomanda.Parameters("@outIznos1").Value
    '        outIznos2 = spKomanda.Parameters("@outIznos2").Value
    '        outIznos3 = spKomanda.Parameters("@outIznos3").Value
    '        outRetVal = spKomanda.Parameters("@outRetVal").Value

    '    Catch SQLExp As SqlException
    '        outRetVal = SQLExp.Message & " SQL greska: Ind.Koloseci!"
    '    Catch Exp As Exception
    '        outRetVal = Err.Description & " VB greska: Ind.Koloseci!"
    '    Finally

    '        DbVeza.Close()
    '        spKomanda.Dispose()

    '    End Try

    'End Sub

    Private Sub btnIndKol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIndKol.Click
        nmHelpFormIK = True

        ''Dim ind_Stanica As String
        ''If IzborSaobracaja = "2" Then
        ''    ind_Stanica = "72" & mStanica2
        ''ElseIf IzborSaobracaja = "3" Then
        ''    ind_Stanica = "72" & mStanica1
        ''End If
        ''bNadjiIndKol(ind_Stanica, bIvicniBroj, bDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bRetVal)

        Dim helpNak As New HelpForm
        helpNak.Text = "help Naknade"
        upit = "INDKOL"
        helpNak.ShowDialog()

        Me.tbIvicniBroj.Text = mIzlaz1
        Me.lblNazivNaknade.Text = bIzlazNazivKoloseka
        'Me.fxIznosNak.Text = CDec(mIzlaz2)

        'nm: 01/10/2013
        bIznos1 = bIzlazCena1
        bIznos2 = bIzlazCena2
        bIznos3 = bIzlazCena3

        If Me.RadioButton1.Checked = True Then
            Me.fxIznosNak.Text = CDec(bIznos1)
        End If
        If Me.RadioButton2.Checked = True Then
            Me.fxIznosNak.Text = CDec(bIznos2)
        End If
        If Me.RadioButton3.Checked = True Then
            Me.fxIznosNak.Text = CDec(bIznos3)
        End If

        Me.nudKolicina.Focus()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim KolaRed As DataRow

        bbDatum = mDatumKalk

        FormatNakGrid()

        'dvNaknada.RowFilter = "Sifra <> '62'"
        'dgNaknade.DataSource = dvNaknada
        'dgNaknade.Refresh()



        tbSifraNaknade.Focus()

        nudKolicina.Text = bKolicina
        nudDanCas.Text = bDanCas

        mNak_BrojKola = dtKola.Rows.Count

        Me.cbSifPlacanja.Text = "1 = Naplaceno na blagajni"
        If bVrstaSaobracaja = 0 Then
            tbValutaNak.Text = "72"
        Else
            tbValutaNak.Text = "17"
        End If

        If mNak_BrojKola < 6 Then
            Me.RadioButton1.Checked = True
        ElseIf mNak_BrojKola >= 6 And mNak_BrojKola < 11 Then
            Me.RadioButton2.Checked = True
        ElseIf mNak_BrojKola >= 11 Then
            Me.RadioButton3.Checked = True
        End If

        If mVrstaObracuna = "RO" Then
            If mVrstaPrevoza = "P" Then
                Me.RadioButton1.Checked = True
            End If
            If mVrstaPrevoza = "G" Then
                Me.RadioButton2.Checked = True
            End If
            If mVrstaPrevoza = "V" Then
                Me.RadioButton3.Checked = True
            End If
        End If

        If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then
            Me.cbObracun.Enabled = True
            Me.cbObracun.SelectedIndex = 1 '.Text = "2 = Centralni obracun"
        Else
            Me.cbObracun.Enabled = False
            Me.cbObracun.SelectedIndex = 0
        End If

        nudKolicina.Text = dtKola.Rows.Count


    End Sub

    Private Sub GroupBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.LostFocus
        Me.tbSifraNaknade.Focus()

    End Sub

    Private Sub GroupBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GroupBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        Me.tbIvicniBroj.Focus()

    End Sub

    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        Me.tbIvicniBroj.Focus()
    End Sub

    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        Me.tbIvicniBroj.Focus()
    End Sub

    Private Sub fxIznosNak_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxIznosNak.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub Button2Nak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2Nak.Click
        Dim helpNak As New HelpForm
        helpNak.Text = "help Naknade"
        upit = "NAK2"
        helpNak.ShowDialog()
        bNazivNaknade = mIzlaz2
        bIznos1 = mIzlaz3
        Me.cbObracun.Focus()

    End Sub
    Private Sub bNadjiIndKolDin(ByVal inStanica As String, ByVal inIvicniBroj As String, ByVal inDatum As DateTime, _
                             ByRef outNazivNaknade As String, ByRef outIznos1 As Decimal, ByRef outIznos2 As Decimal, ByRef outIznos3 As Decimal, _
                             ByRef outRetVal As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("spNadjiIndKolDin", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica").Value = inStanica

        Dim ulIvicniBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIvicniBroj", SqlDbType.Char, 2))
        ulIvicniBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inIvicniBroj").Value = inIvicniBroj

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = inDatum

        Dim izlNazivNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivNaknade", SqlDbType.VarChar, 50))
        izlNazivNaknade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNazivNaknade").Value = outNazivNaknade

        Dim izlIznos1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos1", SqlDbType.Decimal))
        izlIznos1.Size = 9
        izlIznos1.Precision = 10
        izlIznos1.Scale = 2
        izlIznos1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznos1").Value = outIznos1

        Dim izlIznos2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos2", SqlDbType.Decimal))
        izlIznos2.Size = 9
        izlIznos2.Precision = 10
        izlIznos2.Scale = 2
        izlIznos2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznos2").Value = outIznos2

        Dim izlIznos3 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznos3", SqlDbType.Decimal))
        izlIznos3.Size = 9
        izlIznos3.Precision = 10
        izlIznos3.Scale = 2
        izlIznos3.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outIznos3").Value = outIznos3

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try

            spKomanda.ExecuteScalar()

            outNazivNaknade = spKomanda.Parameters("@outNazivNaknade").Value
            outIznos1 = spKomanda.Parameters("@outIznos1").Value
            outIznos2 = spKomanda.Parameters("@outIznos2").Value
            outIznos3 = spKomanda.Parameters("@outIznos3").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska: Ind.Koloseci!"
        Catch Exp As Exception
            outRetVal = Err.Description & " VB greska: Ind.Koloseci!"
        Finally

            DbVeza.Close()
            spKomanda.Dispose()

        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' tbIvicniBroj Validating
        Dim temp_mTarifa As String = mTarifa
        Dim mTarifaTemp As String = mTarifa

        Dim NepostojeciIB As Boolean = False

        If IsNumeric(tbIvicniBroj.Text) = True Then

            If Len(tbIvicniBroj.Text) < 2 Then
                tbIvicniBroj.Text = "0" & tbIvicniBroj.Text
            End If

            bIvicniBroj = tbIvicniBroj.Text
            bNakRetVal = ""
            'bValuta = ""

            If tbSifraNaknade.Text <> "35" And tbSifraNaknade.Text <> "36" Then
                If IzborSaobracaja = "2" Or IzborSaobracaja = "3" Then
                    If mTarifa = "00" Then
                        mTarifa = "36"
                    Else
                        mTarifa = mTarifa
                    End If
                ElseIf IzborSaobracaja = "1" Then
                    mTarifaTemp = mTarifa
                    mTarifa = "36"
                End If

                Dim bSaobracaj, bVrstaSaobracajaT As Integer

                If bValuta = "72" Then
                    bSaobracaj = 1
                ElseIf bValuta = "17" Then
                    bSaobracaj = 2
                End If
                Dim VALUTA As String
                bNadjiSveIzZSNaknada(bSifraNaknade, bIvicniBroj, bSaobracaj, mTarifa, bbDatum, _
                                     VALUTA, bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bNakRetVal)



                If bNakRetVal <> "" Then
                    NepostojeciIB = True
                End If


                If mTarifa = "68" Then
                    If bIznos1 = 0 Then
                        bNadjiSveIzZSNaknada(bSifraNaknade, bIvicniBroj, bSaobracaj, "36", bbDatum, _
                                             bValuta, bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bNakRetVal)
                    End If
                End If
                '---------------------------------- Podbroj ---------------------------------
                If Val(bPodBroj) > 0 And Val(bPodBroj) < 9 Then
                    ''vazece
                    bVrstaSaobracajaT = bVrstaSaobracaja    ' zbog upita koji u Help formi ima parametar bVrstaSaobracaja
                    bVrstaSaobracaja = bSaobracaj

                    Dim helpNakPodbroj As New NakHelpForm
                    helpNakPodbroj.Text = "help - Izbor naknade"
                    helpNakPodbroj.ShowDialog()
                    bNazivNaknade = mIzlaz2
                    bIznos1 = mIzlaz3

                    bVrstaSaobracaja = bVrstaSaobracajaT    ' zbog upita koji u Help formi ima parametar bVrstaSaobracaja

                    'problem: enter odmah zatvori formu
                    'Dim helpNak As New HelpForm
                    'helpNak.Text = "help Naknade"
                    'upit = "NAK2"
                    'helpNak.ShowDialog()
                    'bNazivNaknade = mIzlaz2
                    'bIznos1 = mIzlaz3
                    'Me.cbObracun.Focus()

                    'Button2Nak_Click(Me, Nothing)

                End If
                '----------------------------------------------------------------------------
                mTarifa = mTarifaTemp
            Else                ' koloseci
                Dim tmp_MMStanica1, tmp_MMStanica2, ind_Stanica As String

                If Len(mManipulativnoMesto1) = 5 Then
                    tmp_MMStanica1 = mStanica1
                    mStanica1 = mManipulativnoMesto1
                End If
                If Len(mManipulativnoMesto2) = 5 Then
                    tmp_MMStanica2 = mStanica2
                    mStanica2 = mManipulativnoMesto2
                End If

                If tbSifraNaknade.Text = "35" Then
                    ind_Stanica = "72" & mStanica2
                ElseIf tbSifraNaknade.Text = "36" Then
                    ind_Stanica = "72" & mStanica1
                End If

                If bVrstaSaobracaja = 0 Then
                    bValuta = "72"
                Else
                    bValuta = "17"
                End If


                'If IzborSaobracaja = "2" Then
                '    ind_Stanica = "72" & mStanica2
                '    bValuta = "17"
                'ElseIf IzborSaobracaja = "3" Then
                '    ind_Stanica = "72" & mStanica1
                '    bValuta = "17"
                'End If
                bIznos1 = 0


                If bNakRetVal <> "" Then
                    NepostojeciIB = True
                End If

                Dim bUkupnoKoloseka As Integer = 0
                Dim bRetVal As String

                bNadjiDupleSifreKoloseka(ind_Stanica, bIvicniBroj, bUkupnoKoloseka, bRetVal)

                If bUkupnoKoloseka > 1 Then
                    Me.btnIndKol_Click(Me, Nothing)
                    bIznos1 = bIzlazCena1
                    bIznos2 = bIzlazCena2
                    bIznos3 = bIzlazCena3
                Else
                    If bVrstaSaobracaja = 0 Then
                        bNadjiIndKolDin(ind_Stanica, bIvicniBroj, bbDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bNakRetVal)
                        'uzeti jednu od tri vrednosti
                        bIznos1 = bIznos1 * bKoefZaKoloseke
                        bZaokruziNaDeseteNanize(bIznos1)
                        bIznos2 = bIznos2 * bKoefZaKoloseke
                        bZaokruziNaDeseteNanize(bIznos2)
                        bIznos3 = bIznos3 * bKoefZaKoloseke
                        bZaokruziNaDeseteNanize(bIznos3)
                    Else
                        bNadjiIndKol(ind_Stanica, bIvicniBroj, bbDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bNakRetVal)
                        'uzeti jednu od tri vrednosti bez mnozenja
                    End If
                End If

            End If

            lblNazivNaknade.Text = bNazivNaknade

            If Me.GroupBox2.Visible = True Then
                If Me.RadioButton1.Checked = True Then
                    fxIznosNak.Text = bIznos1
                End If
                If Me.RadioButton2.Checked = True Then
                    fxIznosNak.Text = bIznos2
                End If
                If Me.RadioButton3.Checked = True Then
                    fxIznosNak.Text = bIznos3
                End If
            Else
                fxIznosNak.Text = bIznos1
            End If
            '''            fxIznosNak.Text = bIznos1

            mTarifa = temp_mTarifa

            If Not (bNakRetVal = "") Then
                tbSifraNaknade.Focus()
            End If

            ErrorProvider1.SetError(tbIvicniBroj, "")
            'Me.cbObracun.Focus()
            Me.nudKolicina.Focus()
        Else
            ErrorProvider1.SetError(tbIvicniBroj, "Neispravan unos!")
            Me.tbIvicniBroj.Focus()
        End If

        If NepostojeciIB Then
            ErrorProvider1.SetError(tbIvicniBroj, "Neispravna sifra naknade / ivicni broj!")
            MessageBox.Show("Neispravna sifra naknade / ivicni broj!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'jos(dodati)
            Me.tbSifraNaknade.Focus()
            NepostojeciIB = False
        End If


        If Not ((bSifraNaknade = "43" And bIvicniBroj = "01") Or (bSifraNaknade = "43" And bIvicniBroj = "02")) Then
            Me.nudKolicina.Value = dtKola.Rows.Count
            nudKolicina.Text = dtKola.Rows.Count
        Else
            Me.nudKolicina.Value = 1
            nudKolicina.Text = 1
        End If

        mTarifa = mTarifaTemp

    End Sub
    'Private Sub bOsveziNizNazivaNaknada()
    '    Dim Nak_Red As DataRow
    '    Dim k As Int16
    '    For k = 0 To 10
    '        bNazivNaknadeArr(k) = ""
    '    Next k
    '    k = 0
    '    If dtNaknade.Rows.Count > 0 Then
    '        For Each Nak_Red In dtNaknade.Rows
    '            If ((Nak_Red.Item("Sifra") <> "35") Or (Nak_Red.Item("Sifra") <> "36") Or (Nak_Red.Item("Sifra") <> "62")) Then
    '                bNadjiSveIzZSNaknada(Nak_Red.Item("Sifra"), Nak_Red.Item("IvicniBroj"), "1", mTarifa, bDatum, _
    '                                                     "72", bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bRetVal)
    '            End If
    '            If Nak_Red.Item("Sifra") = "35" Then
    '                bNadjiIndKol("72" + mStanica2, Nak_Red.Item("IvicniBroj"), bDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bRetVal)
    '            End If

    '            If Nak_Red.Item("Sifra") = "36" Then
    '                bNadjiIndKol("72" + mStanica1, Nak_Red.Item("IvicniBroj"), bDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bRetVal)
    '            End If
    '            bNazivNaknadeArr(k) = bNazivNaknade
    '            k = k + 1
    '        Next
    '    End If
    'End Sub
    'Private Sub bOsveziIznoseNaknada()
    '    Dim Nak_Red As DataRow

    '    If dtNaknade.Rows.Count > 0 Then
    '        For Each Nak_Red In dtNaknade.Rows
    '            If ((Nak_Red.Item("Sifra") <> "35") Or (Nak_Red.Item("Sifra") <> "36") Or (Nak_Red.Item("Sifra") <> "62")) Then
    '                bNadjiSveIzZSNaknada(Nak_Red.Item("Sifra"), Nak_Red.Item("IvicniBroj"), "1", mTarifa, bbDatum, _
    '                                                     "72", bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bNakRetVal)
    '            End If
    '            If Nak_Red.Item("Sifra") = "35" Then
    '                bNadjiIndKol("72" + mStanica2, Nak_Red.Item("IvicniBroj"), bbDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bNakRetVal)
    '            End If

    '            If Nak_Red.Item("Sifra") = "36" Then
    '                bNadjiIndKol("72" + mStanica1, Nak_Red.Item("IvicniBroj"), bbDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bNakRetVal)
    '            End If
    '            'Nak_Red.Item("Iznos") = 

    '        Next
    '    End If
    'End Sub

    Private Sub ButtonFilter62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFilter62.Click
        'dvNaknada.RowFilter = "Sifra <> '62'"
        'dgNaknade.DataSource = dvNaknada
        'dgNaknade.Refresh()
    End Sub

    Private Sub tbSifraNaknade_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbSifraNaknade.GotFocus
        Me.tbSifraNaknade.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbSifraNaknade.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbSifraNaknade_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbSifraNaknade.LostFocus
        Me.tbSifraNaknade.BackColor = System.Drawing.Color.White
        Me.tbSifraNaknade.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbIvicniBroj_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbIvicniBroj.GotFocus
        Me.tbIvicniBroj.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbIvicniBroj.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbIvicniBroj_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbIvicniBroj.LostFocus
        Me.tbIvicniBroj.BackColor = System.Drawing.Color.White
        Me.tbIvicniBroj.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub bNadjiDupleSifreKoloseka(ByVal inStanica As String, ByVal inSifraKoloseka As Integer, _
                ByRef outUkupnoKoloseka As Integer, ByRef outRetVal As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("roba1708.bspNadjiDupleSifreKoloseka", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 7))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica").Value = inStanica

        Dim ulSifraKoloseka As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraKoloseka", SqlDbType.Int))
        ulSifraKoloseka.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraKoloseka").Value = inSifraKoloseka

        Dim izlUkupnoKoloseka As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUkupnoKoloseka", SqlDbType.Int))
        izlUkupnoKoloseka.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUkupnoKoloseka").Value = outUkupnoKoloseka

        Try

            spKomanda.ExecuteScalar()

            outUkupnoKoloseka = spKomanda.Parameters("@outUkupnoKoloseka").Value
            'outIznos1 = spKomanda.Parameters("@outIznos1").Value
            'outIznos2 = spKomanda.Parameters("@outIznos2").Value
            'outIznos3 = spKomanda.Parameters("@outIznos3").Value
            'outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska: Ind.Koloseci!"
        Catch Exp As Exception
            outRetVal = Err.Description & " VB greska: Ind.Koloseci!"
        Finally

            DbVeza.Close()
            spKomanda.Dispose()

        End Try

    End Sub

    'Private Sub btnIndKol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnIndKol.KeyPress
    '    Dim helpNak As New HelpForm
    '    helpNak.Text = "help Naknade"
    '    upit = "INDKOL"
    '    helpNak.ShowDialog()
    '    Me.tbIvicniBroj.Text = mIzlaz1
    '    Me.fxIznosNak.Text = CDec(mIzlaz2)

    '    'Me.tbIvicniBroj.Focus()
    '    Me.fxIznosNak.Focus()

    'End Sub

End Class
