Imports System.Data.SqlClient
Public Class naknade
    Inherits System.Windows.Forms.Form

    Dim dsNaknade As DataSet
    'Friend bSifraNaknade As String
    'Friend bIvicniBroj As String
    Dim bPodBroj As String

    'Dim bTarifa As String
    Dim bStavkaNak As Integer
    Dim bDatum As DateTime = Today
    Dim bNazivNaknade As String = ""

    Dim bIznos1 As Decimal
    Dim bIznos2 As Decimal
    Dim bIznos3 As Decimal
    Dim bMinimum As Decimal
    Dim bRetVal As String = ""

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
    Friend WithEvents fxIznosNak As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnIndKol As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnIndKol = New System.Windows.Forms.Button
        Me.fxIznosNak = New FlxMaskBox.FlexMaskEditBox
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        CType(Me.nudKolicina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDanCas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgNaknade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbSifraNaknade
        '
        Me.tbSifraNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSifraNaknade.Location = New System.Drawing.Point(120, 96)
        Me.tbSifraNaknade.MaxLength = 2
        Me.tbSifraNaknade.Name = "tbSifraNaknade"
        Me.tbSifraNaknade.Size = New System.Drawing.Size(48, 22)
        Me.tbSifraNaknade.TabIndex = 0
        Me.tbSifraNaknade.Text = ""
        Me.tbSifraNaknade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbIvicniBroj
        '
        Me.tbIvicniBroj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIvicniBroj.Location = New System.Drawing.Point(168, 96)
        Me.tbIvicniBroj.MaxLength = 2
        Me.tbIvicniBroj.Name = "tbIvicniBroj"
        Me.tbIvicniBroj.Size = New System.Drawing.Size(48, 22)
        Me.tbIvicniBroj.TabIndex = 1
        Me.tbIvicniBroj.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kolicina"
        '
        'nudKolicina
        '
        Me.nudKolicina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudKolicina.Location = New System.Drawing.Point(120, 176)
        Me.nudKolicina.Name = "nudKolicina"
        Me.nudKolicina.Size = New System.Drawing.Size(56, 22)
        Me.nudKolicina.TabIndex = 3
        Me.nudKolicina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudKolicina.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(224, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Dan / Cas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'nudDanCas
        '
        Me.nudDanCas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDanCas.Location = New System.Drawing.Point(288, 176)
        Me.nudDanCas.Name = "nudDanCas"
        Me.nudDanCas.Size = New System.Drawing.Size(56, 22)
        Me.nudDanCas.TabIndex = 9
        Me.nudDanCas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(544, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "�ifra placanja"
        Me.Label5.Visible = False
        '
        'cbSifPlacanja
        '
        Me.cbSifPlacanja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSifPlacanja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbSifPlacanja.Items.AddRange(New Object() {"1 = Ulazni prelaz", "2 = Izlazni prelaz"})
        Me.cbSifPlacanja.Location = New System.Drawing.Point(544, 192)
        Me.cbSifPlacanja.Name = "cbSifPlacanja"
        Me.cbSifPlacanja.Size = New System.Drawing.Size(200, 23)
        Me.cbSifPlacanja.TabIndex = 2
        Me.cbSifPlacanja.Visible = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(229, 222)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Valuta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Iznos"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgNaknade
        '
        Me.dgNaknade.DataMember = ""
        Me.dgNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgNaknade.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgNaknade.Location = New System.Drawing.Point(16, 264)
        Me.dgNaknade.Name = "dgNaknade"
        Me.dgNaknade.Size = New System.Drawing.Size(728, 248)
        Me.dgNaknade.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(608, 120)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 20)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "..."
        Me.Button1.Visible = False
        '
        'btnStanicaPr
        '
        Me.btnStanicaPr.Location = New System.Drawing.Point(24, 96)
        Me.btnStanicaPr.Name = "btnStanicaPr"
        Me.btnStanicaPr.Size = New System.Drawing.Size(75, 24)
        Me.btnStanicaPr.TabIndex = 34
        Me.btnStanicaPr.Text = "Naknada"
        '
        'lblNazivNaknade
        '
        Me.lblNazivNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblNazivNaknade.ForeColor = System.Drawing.Color.Gray
        Me.lblNazivNaknade.Location = New System.Drawing.Point(288, 96)
        Me.lblNazivNaknade.Name = "lblNazivNaknade"
        Me.lblNazivNaknade.Size = New System.Drawing.Size(448, 23)
        Me.lblNazivNaknade.TabIndex = 35
        '
        'Label18
        '
        Me.Label18.Enabled = False
        Me.Label18.Location = New System.Drawing.Point(48, 528)
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
        Me.dtPickDatumNaknade.Location = New System.Drawing.Point(48, 552)
        Me.dtPickDatumNaknade.Name = "dtPickDatumNaknade"
        Me.dtPickDatumNaknade.Size = New System.Drawing.Size(112, 21)
        Me.dtPickDatumNaknade.TabIndex = 51
        Me.dtPickDatumNaknade.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnIndKol)
        Me.GroupBox1.Controls.Add(Me.fxIznosNak)
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
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(205, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 607)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Unos naknada ] "
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label9.Location = New System.Drawing.Point(694, 568)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "85 = CHF"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label8.Location = New System.Drawing.Point(694, 552)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "72 = RSD"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label4.Location = New System.Drawing.Point(654, 536)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Valuta:  17 = EUR "
        '
        'btnIndKol
        '
        Me.btnIndKol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIndKol.Location = New System.Drawing.Point(232, 96)
        Me.btnIndKol.Name = "btnIndKol"
        Me.btnIndKol.Size = New System.Drawing.Size(40, 23)
        Me.btnIndKol.TabIndex = 59
        Me.btnIndKol.Text = "->"
        Me.btnIndKol.Visible = False
        '
        'fxIznosNak
        '
        Me.fxIznosNak.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxIznosNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxIznosNak.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxIznosNak.Location = New System.Drawing.Point(120, 216)
        Me.fxIznosNak.Mask = "#########9d##"
        Me.fxIznosNak.Name = "fxIznosNak"
        Me.fxIznosNak.Size = New System.Drawing.Size(88, 22)
        Me.fxIznosNak.TabIndex = 4
        Me.fxIznosNak.Text = "0"
        Me.fxIznosNak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbObracun
        '
        Me.cbObracun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObracun.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbObracun.Items.AddRange(New Object() {"1 = Naplaceno na blagajni", "2 = Centralni obracun"})
        Me.cbObracun.Location = New System.Drawing.Point(120, 136)
        Me.cbObracun.Name = "cbObracun"
        Me.cbObracun.Size = New System.Drawing.Size(224, 24)
        Me.cbObracun.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 23)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Vrsta obracuna"
        '
        'tbValutaNak
        '
        Me.tbValutaNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValutaNak.Location = New System.Drawing.Point(288, 216)
        Me.tbValutaNak.Name = "tbValutaNak"
        Me.tbValutaNak.Size = New System.Drawing.Size(56, 22)
        Me.tbValutaNak.TabIndex = 5
        Me.tbValutaNak.Text = "17"
        Me.tbValutaNak.Visible = False
        '
        'btnDodajNak
        '
        Me.btnDodajNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodajNak.Image = CType(resources.GetObject("btnDodajNak.Image"), System.Drawing.Image)
        Me.btnDodajNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodajNak.Location = New System.Drawing.Point(312, 536)
        Me.btnDodajNak.Name = "btnDodajNak"
        Me.btnDodajNak.Size = New System.Drawing.Size(62, 48)
        Me.btnDodajNak.TabIndex = 6
        Me.btnDodajNak.Text = "Dodaj"
        Me.btnDodajNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnBrisiNak
        '
        Me.btnBrisiNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiNak.Image = CType(resources.GetObject("btnBrisiNak.Image"), System.Drawing.Image)
        Me.btnBrisiNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiNak.Location = New System.Drawing.Point(400, 536)
        Me.btnBrisiNak.Name = "btnBrisiNak"
        Me.btnBrisiNak.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiNak.TabIndex = 8
        Me.btnBrisiNak.Text = "Brisi"
        Me.btnBrisiNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnIzmeniNak
        '
        Me.btnIzmeniNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIzmeniNak.Image = CType(resources.GetObject("btnIzmeniNak.Image"), System.Drawing.Image)
        Me.btnIzmeniNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIzmeniNak.Location = New System.Drawing.Point(320, 536)
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
        Me.btnOtkazi.Location = New System.Drawing.Point(877, 640)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 2
        Me.btnOtkazi.Text = "Otka�i"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(768, 640)
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
        Me.PictureBox1.Location = New System.Drawing.Point(48, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(112, 104)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Location = New System.Drawing.Point(392, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 64)
        Me.GroupBox2.TabIndex = 63
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ Naknada zavisi od broja kola ]"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(232, 24)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(112, 24)
        Me.RadioButton3.TabIndex = 61
        Me.RadioButton3.Text = "11 i vise kola"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(128, 24)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton2.TabIndex = 60
        Me.RadioButton2.Text = "6-10 kola"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(25, 24)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(72, 24)
        Me.RadioButton1.TabIndex = 59
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "1-5 kola"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(16, 152)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(176, 64)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Naknade za sporedne usluge"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'naknade
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(984, 714)
        Me.Controls.Add(Me.Label10)
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
        If IsNumeric(tbIvicniBroj.Text) = True Then
            Dim _temptarifa As String = ""
            bSifraNaknade = tbSifraNaknade.Text

            If Len(tbIvicniBroj.Text) < 2 Then
                tbIvicniBroj.Text = "0" & tbIvicniBroj.Text
            End If

            bIvicniBroj = tbIvicniBroj.Text
            bVrstaSaobracaja = IzborSaobracaja
            bRetVal = ""
            ''''''''''''''bValuta = ""
            If IzborSaobracaja = "2" Or IzborSaobracaja = "3" Then
                If mTarifa = "36" Then
                    _temptarifa = "36"
                ElseIf mTarifa = "38" Then
                    _temptarifa = "68"
                ElseIf mTarifa = "00" Then
                    _temptarifa = "36"
                End If
            ElseIf IzborSaobracaja = "4" Then
                If mTarifa = "38" Then
                    _temptarifa = "38"
                ElseIf mTarifa = "38" Then
                    _temptarifa = "68"
                ElseIf mTarifa = "00" Then
                    _temptarifa = "38"
                End If
            ElseIf IzborSaobracaja = "1" Then
                If mTarifa = "36" Then
                    _temptarifa = "36"
                ElseIf mTarifa = "00" Then
                    _temptarifa = "36"
                End If
            End If
            If tbSifraNaknade.Text <> "35" And tbSifraNaknade.Text <> "36" Then
                bNadjiSveIzZSNaknada(bSifraNaknade, bIvicniBroj, bVrstaSaobracaja, _temptarifa, bDatum, _
                                     bValuta, bNazivNaknade, bPodBroj, bIznos1, bIznos2, bIznos3, bMinimum, bRetVal)

                '---------------------------------- Podbroj ---------------------------------
                If CType(bPodBroj, Int16) > 0 And CType(bPodBroj, Int16) <> 9 Then
                    Dim helpNakPodbroj As New HelpForm
                    helpNakPodbroj.Text = "help Naknade"
                    upit = "NAKPB"
                    helpNakPodbroj.ShowDialog()
                    bIznos1 = mIzlaz3
                    Me.nudKolicina.Focus()
                End If
            Else
                Dim ind_Stanica As String
                bIznos1 = 0
                If IzborSaobracaja = "2" Then
                    ind_Stanica = "72" & mStanica2
                    bValuta = "17"
                    bNadjiIndKol(ind_Stanica, bIvicniBroj, bDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bRetVal)
                ElseIf IzborSaobracaja = "3" Then
                    ind_Stanica = "72" & mStanica1
                    bValuta = "17"
                    bNadjiIndKol(ind_Stanica, bIvicniBroj, bDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bRetVal)
                ElseIf IzborSaobracaja = "1" Then
                    ind_Stanica = "72" & mStanica1
                    If bValuta = "72" Then
                        bNadjiIndKolDin(ind_Stanica, bIvicniBroj, bDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bRetVal)
                    ElseIf bValuta = "17" Then
                        bNadjiIndKol(ind_Stanica, bIvicniBroj, bDatum, bNazivNaknade, bIznos1, bIznos2, bIznos3, bRetVal)
                    End If
                End If
            End If

            lblNazivNaknade.Text = bNazivNaknade

            'tbIznosNak.Text = bIznos1
            'fxIznosNak.Text = bIznos1

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


            If Not (bRetVal = "") Then
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
        outIznosNakn = inIznos1 * inKolicina

        If inDanCas <> 0 Then
            outIznosNakn = inDanCas * outIznosNakn
        End If

    End Sub

    Private Sub bNadjiSveIzZSNaknada( _
                                ByVal inSifraNaknade As String, _
                                ByVal inIvicniBroj As String, _
                                ByVal inVrstaSaobracaja As Integer, _
                                ByVal inTarifa As String, _
                                ByVal inDatum As DateTime, _
                                ByRef outSifraValute As String, _
                                ByRef outNazivNaknade As String, _
                                ByRef outPodBroj As String, _
                                ByRef outIznos1 As Decimal, _
                                ByRef outIznos2 As Decimal, _
                                ByRef outIznos3 As Decimal, _
                                ByRef outMinimum As Decimal, _
                                ByRef outRetVal As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("bspNadjiSveIzZSNaknade", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulSifraNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifra", SqlDbType.Char, 2))
        ulSifraNaknade.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifra").Value = inSifraNaknade

        Dim ulIvicniBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIvicniBroj", SqlDbType.Char, 2))
        ulIvicniBroj.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inIvicniBroj").Value = inIvicniBroj

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVrstaSaobracaja", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVrstaSaobracaja").Value = inVrstaSaobracaja

        Dim ulTarifa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTarifa", SqlDbType.Char, 2))
        ulTarifa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTarifa").Value = inTarifa

        Dim ulDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime))
        ulDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatum").Value = inDatum

        Dim izlSifraValute As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraValute", SqlDbType.Char, 2))
        izlSifraValute.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraValute").Value = outSifraValute

        Dim izlNazivNaknade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivNaknade", SqlDbType.VarChar, 50))
        izlNazivNaknade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNazivNaknade").Value = outNazivNaknade

        Dim izlPodBroj As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPodBroj", SqlDbType.Char, 1))
        izlPodBroj.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPodBroj").Value = outPodBroj

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

        Dim izlMinimum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinimum", SqlDbType.Decimal))
        izlMinimum.Size = 9
        izlMinimum.Precision = 10
        izlMinimum.Scale = 2
        izlMinimum.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinimum").Value = outMinimum

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try

            spKomanda.ExecuteScalar()

            'Dim Pom As Int16 = spKomanda.Parameters("@PovrVrednost").Value
            'Pom = spKomanda.Parameters("@PovrVrednost").Value
            'If Pom <> 0 Then outRetVal = " Neuspesan upit!" 'Pom = spKomanda.Parameters("@PovrVrednost").Value

            outNazivNaknade = spKomanda.Parameters("@outNazivNaknade").Value
            outSifraValute = spKomanda.Parameters("@outSifraValute").Value
            outPodBroj = spKomanda.Parameters("@outPodBroj").Value
            outIznos1 = spKomanda.Parameters("@outIznos1").Value
            outIznos2 = spKomanda.Parameters("@outIznos2").Value
            outIznos3 = spKomanda.Parameters("@outIznos3").Value
            outMinimum = spKomanda.Parameters("@outMinimum").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally

            DbVeza.Close()
            spKomanda.Dispose()

        End Try

    End Sub

    Private Sub naknade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatNakGrid()
        tbSifraNaknade.Focus()
        nudKolicina.Text = bKolicina
        nudDanCas.Text = bDanCas
        Me.cbSifPlacanja.Text = "1 = Naplaceno na blagajni"
        If mTarifa = "38" Then
            tbValutaNak.Text = "85"
        Else
            tbValutaNak.Text = "17"
        End If

        If dtKola.Rows.Count < 6 Then
            If mVrstaPrevoza = "P" Then
                Me.RadioButton1.Checked = True
            ElseIf mVrstaPrevoza = "G" Then
                Me.RadioButton2.Checked = True
            ElseIf mVrstaPrevoza = "V" Then
                Me.RadioButton3.Checked = True
            End If
        ElseIf dtKola.Rows.Count >= 6 And dtKola.Rows.Count < 11 Then
            Me.RadioButton2.Checked = True
        ElseIf dtKola.Rows.Count >= 11 Then
            Me.RadioButton3.Checked = True
        End If

        If IzborSaobracaja = "1" Then
            tbValutaNak.Text = bValuta
            Me.cbObracun.Visible = False
            Me.Label1.Visible = False
        End If

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
    End Sub

    Private Sub btnDodajNak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajNak.Click
        Dim nSifraNaknade As String
        Dim nIvBrojNaknade As String
        Dim nIznos As Decimal = 0
        Dim nValuta As String
        Dim nKolicina As Int32 = 0
        Dim nDanCas As Int32 = 0

        Dim nVrstaObracuna As String = ""

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
        'mrA79a1, mrA79a2, mrA79a3 As String
        'mrA79b1, mrA79b2, mrA79b3 As Decimal
        If dtNaknade.Rows.Count = 1 Then
            mrA79a1 = nSifraNaknade
            mrA79b1 = fxIznosNak.Text
        ElseIf dtNaknade.Rows.Count = 2 Then
            mrA79a2 = nSifraNaknade
            mrA79b2 = fxIznosNak.Text
        ElseIf dtNaknade.Rows.Count = 3 Then
            mrA79a3 = nSifraNaknade
            mrA79b3 = fxIznosNak.Text
        ElseIf dtNaknade.Rows.Count = 4 Then

        End If

        Me.tbSifraNaknade.Clear()
        Me.tbIvicniBroj.Clear()
        Me.nudKolicina.Value = 1
        Me.nudDanCas.Value = 0
        Me.cbSifPlacanja.Text = ""
        'Me.tbIznosNak.Text = 0
        Me.fxIznosNak.Text = 0
        'Me.tbValutaNak.Clear()

        tbSifraNaknade.Focus()
    End Sub

    Private Sub dtPickDatumNaknade_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtPickDatumNaknade.ValueChanged

    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click

        If dtNaknade.Rows.Count > 0 Then
            _OpenForm = "Naknade"
            mSumaNak = dtNaknade.Compute("SUM(Iznos)", String.Empty).ToString

            Close()
        Else
            mSumaNak = 0
            MessageBox.Show("Niste uneli sve potrebne podatke!", "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tbSifraNaknade.Focus()

        End If
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

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        dtNaknade.Clear()
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
        If Me.tbSifraNaknade.Text = Nothing Then
            If dtNaknade.Rows.Count = 0 Then
                Me.tbSifraNaknade.Focus()
                ErrorProvider1.SetError(tbIvicniBroj, "Zatvorite formu izborom dugmeta Otkazi(Cancel)")
            Else
                Me.btnPrihvati.Focus()
            End If
        Else
            If IsNumeric(tbSifraNaknade.Text) = True Then
                If tbSifraNaknade.Text = "35" Or tbSifraNaknade.Text = "36" Then
                    Me.btnIndKol.Visible = True
                    Me.btnIndKol_Click(Me, Nothing)
                Else
                    Me.btnIndKol.Visible = False
                End If
                ErrorProvider1.SetError(tbIvicniBroj, "")
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
    Private Sub fxIznosNak_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fxIznosNak.Validating
        If IsNumeric(fxIznosNak.Text) = True Then
            ErrorProvider1.SetError(fxIznosNak, "")
        Else
            ErrorProvider1.SetError(fxIznosNak, "Neispravan unos!")
            fxIznosNak.Focus()
        End If

    End Sub

    Private Sub fxIznosNak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxIznosNak.KeyPress
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
    Private Sub bNadjiIndKol(ByVal inStanica As String, ByVal inIvicniBroj As String, ByVal inDatum As DateTime, _
                         ByRef outNazivNaknade As String, ByRef outIznos1 As Decimal, ByRef outIznos2 As Decimal, ByRef outIznos3 As Decimal, _
                         ByRef outRetVal As String)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("spNadjiIndKol", DbVeza)
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

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar))
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

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar))
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


    Private Sub btnIndKol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIndKol.Click
        Dim helpNak As New HelpForm
        helpNak.Text = "help Naknade"
        upit = "INDKOL"
        helpNak.ShowDialog()
        Me.tbIvicniBroj.Text = mIzlaz1
        Me.fxIznosNak.Text = CDec(mIzlaz2)

        Me.tbIvicniBroj.Focus()

    End Sub

    Private Sub fxIznosNak_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxIznosNak.Leave

    End Sub
End Class
