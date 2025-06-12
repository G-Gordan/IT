Imports System.Data.SqlClient
Public Class FormUpdateCimGr
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
    Friend WithEvents cbSmer1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbSmer2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents tbUlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbIzlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents tbPolaznaCarina As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbCarinjenje As System.Windows.Forms.TextBox
    Friend WithEvents tbsBrojVoza As System.Windows.Forms.TextBox
    Friend WithEvents tbsSatVoza As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnUnosRobe As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnUpis As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents DatumIzl As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbsBrojVoza2 As System.Windows.Forms.TextBox
    Friend WithEvents tbsSatVoza2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents DatumUl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbBlagajna As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCarinarnica As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormUpdateCimGr))
        Me.cbSmer1 = New System.Windows.Forms.ComboBox
        Me.cbSmer2 = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.tbUlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbIzlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.tbPolaznaCarina = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.tbCarinjenje = New System.Windows.Forms.TextBox
        Me.tbsBrojVoza = New System.Windows.Forms.TextBox
        Me.tbsSatVoza = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnUnosRobe = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.Button10 = New System.Windows.Forms.Button
        Me.btnUpis = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.tbsBrojVoza2 = New System.Windows.Forms.TextBox
        Me.tbsSatVoza2 = New System.Windows.Forms.NumericUpDown
        Me.DatumIzl = New System.Windows.Forms.DateTimePicker
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.DatumUl = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnCarinarnica = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbBlagajna = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.tbsSatVoza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.tbsSatVoza2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbSmer1
        '
        Me.cbSmer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbSmer1.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer1.Location = New System.Drawing.Point(160, 22)
        Me.cbSmer1.Name = "cbSmer1"
        Me.cbSmer1.Size = New System.Drawing.Size(210, 24)
        Me.cbSmer1.TabIndex = 0
        '
        'cbSmer2
        '
        Me.cbSmer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbSmer2.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer2.Location = New System.Drawing.Point(160, 22)
        Me.cbSmer2.Name = "cbSmer2"
        Me.cbSmer2.Size = New System.Drawing.Size(210, 24)
        Me.cbSmer2.TabIndex = 0
        '
        'Label33
        '
        Me.Label33.Enabled = False
        Me.Label33.Location = New System.Drawing.Point(16, 32)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 13)
        Me.Label33.TabIndex = 47
        Me.Label33.Text = "Ulazni prelaz"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbUlaznaNalepnica
        '
        Me.tbUlaznaNalepnica.BackColor = System.Drawing.Color.White
        Me.tbUlaznaNalepnica.Cursor = System.Windows.Forms.Cursors.Default
        Me.tbUlaznaNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUlaznaNalepnica.ForeColor = System.Drawing.Color.Black
        Me.tbUlaznaNalepnica.Location = New System.Drawing.Point(160, 58)
        Me.tbUlaznaNalepnica.MaxLength = 5
        Me.tbUlaznaNalepnica.Name = "tbUlaznaNalepnica"
        Me.tbUlaznaNalepnica.Size = New System.Drawing.Size(124, 22)
        Me.tbUlaznaNalepnica.TabIndex = 1
        Me.tbUlaznaNalepnica.Text = ""
        Me.tbUlaznaNalepnica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 23)
        Me.Label1.TabIndex = 225
        Me.Label1.Text = "Ulazna tranzitna nalepnica"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbIzlaznaNalepnica
        '
        Me.tbIzlaznaNalepnica.BackColor = System.Drawing.Color.White
        Me.tbIzlaznaNalepnica.Cursor = System.Windows.Forms.Cursors.Default
        Me.tbIzlaznaNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIzlaznaNalepnica.ForeColor = System.Drawing.Color.Black
        Me.tbIzlaznaNalepnica.Location = New System.Drawing.Point(160, 58)
        Me.tbIzlaznaNalepnica.MaxLength = 5
        Me.tbIzlaznaNalepnica.Name = "tbIzlaznaNalepnica"
        Me.tbIzlaznaNalepnica.Size = New System.Drawing.Size(124, 22)
        Me.tbIzlaznaNalepnica.TabIndex = 1
        Me.tbIzlaznaNalepnica.Text = ""
        Me.tbIzlaznaNalepnica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPolaznaCarina
        '
        Me.tbPolaznaCarina.BackColor = System.Drawing.Color.White
        Me.tbPolaznaCarina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPolaznaCarina.Location = New System.Drawing.Point(160, 184)
        Me.tbPolaznaCarina.MaxLength = 5
        Me.tbPolaznaCarina.Name = "tbPolaznaCarina"
        Me.tbPolaznaCarina.Size = New System.Drawing.Size(124, 22)
        Me.tbPolaznaCarina.TabIndex = 6
        Me.tbPolaznaCarina.Text = ""
        Me.tbPolaznaCarina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(16, 189)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 16)
        Me.Label16.TabIndex = 316
        Me.Label16.Text = "Polazna carinarnica"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbCarinjenje
        '
        Me.tbCarinjenje.BackColor = System.Drawing.Color.White
        Me.tbCarinjenje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarinjenje.Location = New System.Drawing.Point(160, 184)
        Me.tbCarinjenje.MaxLength = 5
        Me.tbCarinjenje.Name = "tbCarinjenje"
        Me.tbCarinjenje.Size = New System.Drawing.Size(124, 22)
        Me.tbCarinjenje.TabIndex = 5
        Me.tbCarinjenje.Text = ""
        Me.tbCarinjenje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbsBrojVoza
        '
        Me.tbsBrojVoza.BackColor = System.Drawing.Color.White
        Me.tbsBrojVoza.Cursor = System.Windows.Forms.Cursors.Default
        Me.tbsBrojVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbsBrojVoza.Location = New System.Drawing.Point(160, 89)
        Me.tbsBrojVoza.MaxLength = 5
        Me.tbsBrojVoza.Name = "tbsBrojVoza"
        Me.tbsBrojVoza.Size = New System.Drawing.Size(124, 22)
        Me.tbsBrojVoza.TabIndex = 2
        Me.tbsBrojVoza.Text = ""
        Me.tbsBrojVoza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbsSatVoza
        '
        Me.tbsSatVoza.BackColor = System.Drawing.Color.White
        Me.tbsSatVoza.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbsSatVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbsSatVoza.Location = New System.Drawing.Point(315, 89)
        Me.tbsSatVoza.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.tbsSatVoza.Name = "tbsSatVoza"
        Me.tbsSatVoza.Size = New System.Drawing.Size(55, 22)
        Me.tbsSatVoza.TabIndex = 3
        Me.tbsSatVoza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(291, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 16)
        Me.Label7.TabIndex = 320
        Me.Label7.Text = " / "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 321
        Me.Label3.Text = "Broj voza / sat voza"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnUnosRobe
        '
        Me.btnUnosRobe.BackColor = System.Drawing.SystemColors.Control
        Me.btnUnosRobe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUnosRobe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnosRobe.Image = CType(resources.GetObject("btnUnosRobe.Image"), System.Drawing.Image)
        Me.btnUnosRobe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUnosRobe.Location = New System.Drawing.Point(624, 345)
        Me.btnUnosRobe.Name = "btnUnosRobe"
        Me.btnUnosRobe.Size = New System.Drawing.Size(110, 88)
        Me.btnUnosRobe.TabIndex = 4
        Me.btnUnosRobe.Text = "Izmena podataka o kolima i robi"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(32, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 325
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(112, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(776, 40)
        Me.Label5.TabIndex = 326
        Me.Label5.Text = "Izmena podataka na tovarnom listu"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.tbUgovor)
        Me.GroupBox4.Controls.Add(Me.Button10)
        Me.GroupBox4.Location = New System.Drawing.Point(114, 336)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(384, 104)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = " [ T A R I F A ] "
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.Black
        Me.ComboBox1.Items.AddRange(New Object() {"1. Spt 38", "2. Tea 9291", "3. Ugovor"})
        Me.ComboBox1.Location = New System.Drawing.Point(160, 21)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(210, 24)
        Me.ComboBox1.TabIndex = 237
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 338
        Me.Label4.Text = "Izbor tarife"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbUgovor
        '
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(160, 61)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(210, 22)
        Me.tbUgovor.TabIndex = 239
        Me.tbUgovor.Text = ""
        Me.tbUgovor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(16, 62)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(64, 26)
        Me.Button10.TabIndex = 337
        Me.Button10.Text = "Ugovor"
        '
        'btnUpis
        '
        Me.btnUpis.BackColor = System.Drawing.Color.PapayaWhip
        Me.btnUpis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpis.Image = CType(resources.GetObject("btnUpis.Image"), System.Drawing.Image)
        Me.btnUpis.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpis.Location = New System.Drawing.Point(624, 456)
        Me.btnUpis.Name = "btnUpis"
        Me.btnUpis.Size = New System.Drawing.Size(112, 80)
        Me.btnUpis.TabIndex = 3
        Me.btnUpis.Text = "Upis izmena"
        Me.btnUpis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button12.Location = New System.Drawing.Point(784, 456)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(112, 80)
        Me.Button12.TabIndex = 6
        Me.Button12.Text = "  Izlaz"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbsBrojVoza2
        '
        Me.tbsBrojVoza2.BackColor = System.Drawing.Color.White
        Me.tbsBrojVoza2.Cursor = System.Windows.Forms.Cursors.Default
        Me.tbsBrojVoza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbsBrojVoza2.Location = New System.Drawing.Point(160, 91)
        Me.tbsBrojVoza2.MaxLength = 5
        Me.tbsBrojVoza2.Name = "tbsBrojVoza2"
        Me.tbsBrojVoza2.Size = New System.Drawing.Size(124, 22)
        Me.tbsBrojVoza2.TabIndex = 2
        Me.tbsBrojVoza2.Text = ""
        Me.tbsBrojVoza2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbsSatVoza2
        '
        Me.tbsSatVoza2.BackColor = System.Drawing.Color.White
        Me.tbsSatVoza2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbsSatVoza2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbsSatVoza2.Location = New System.Drawing.Point(315, 91)
        Me.tbsSatVoza2.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.tbsSatVoza2.Name = "tbsSatVoza2"
        Me.tbsSatVoza2.Size = New System.Drawing.Size(55, 22)
        Me.tbsSatVoza2.TabIndex = 3
        Me.tbsSatVoza2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DatumIzl
        '
        Me.DatumIzl.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.DatumIzl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DatumIzl.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumIzl.Location = New System.Drawing.Point(160, 121)
        Me.DatumIzl.Name = "DatumIzl"
        Me.DatumIzl.Size = New System.Drawing.Size(124, 22)
        Me.DatumIzl.TabIndex = 4
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.TextBox1)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.DatumUl)
        Me.GroupBox6.Controls.Add(Me.tbUlaznaNalepnica)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.cbSmer1)
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.tbsBrojVoza)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.tbsSatVoza)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.tbPolaznaCarina)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Location = New System.Drawing.Point(114, 104)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(384, 224)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = " [ U L A Z ]"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(16, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 327
        Me.Label6.Text = "Broj prispeca"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(160, 152)
        Me.TextBox1.MaxLength = 6
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(124, 22)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(16, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 16)
        Me.Label11.TabIndex = 325
        Me.Label11.Text = "Datum ulaza"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'DatumUl
        '
        Me.DatumUl.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.DatumUl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DatumUl.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumUl.Location = New System.Drawing.Point(160, 121)
        Me.DatumUl.Name = "DatumUl"
        Me.DatumUl.Size = New System.Drawing.Size(124, 22)
        Me.DatumUl.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCarinarnica)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.cbSmer2)
        Me.GroupBox2.Controls.Add(Me.tbIzlaznaNalepnica)
        Me.GroupBox2.Controls.Add(Me.tbsBrojVoza2)
        Me.GroupBox2.Controls.Add(Me.tbsSatVoza2)
        Me.GroupBox2.Controls.Add(Me.DatumIzl)
        Me.GroupBox2.Controls.Add(Me.tbCarinjenje)
        Me.GroupBox2.Location = New System.Drawing.Point(512, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(384, 224)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ I Z L A Z ]"
        '
        'btnCarinarnica
        '
        Me.btnCarinarnica.BackColor = System.Drawing.Color.White
        Me.btnCarinarnica.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCarinarnica.Image = CType(resources.GetObject("btnCarinarnica.Image"), System.Drawing.Image)
        Me.btnCarinarnica.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCarinarnica.Location = New System.Drawing.Point(296, 184)
        Me.btnCarinarnica.Name = "btnCarinarnica"
        Me.btnCarinarnica.Size = New System.Drawing.Size(20, 20)
        Me.btnCarinarnica.TabIndex = 328
        Me.btnCarinarnica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(293, 92)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(16, 16)
        Me.Label19.TabIndex = 327
        Me.Label19.Text = " / "
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(16, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 16)
        Me.Label15.TabIndex = 326
        Me.Label15.Text = "Broj voza / sat voza"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(16, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 16)
        Me.Label12.TabIndex = 325
        Me.Label12.Text = "Datum izlaza"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 23)
        Me.Label13.TabIndex = 225
        Me.Label13.Text = "Izlazna tranzitna nalepnica"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label14
        '
        Me.Label14.Enabled = False
        Me.Label14.Location = New System.Drawing.Point(16, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "Izlazni prelaz"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(16, 189)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 16)
        Me.Label18.TabIndex = 316
        Me.Label18.Text = "Carinarnica"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(784, 345)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 88)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Izmena podataka o naknadama za sporedne usluge"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbBlagajna)
        Me.GroupBox1.Location = New System.Drawing.Point(115, 449)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 56)
        Me.GroupBox1.TabIndex = 327
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ P R E V O Z N I N A ] "
        Me.GroupBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 13)
        Me.Label2.TabIndex = 338
        Me.Label2.Text = "Izracunata prevoznina"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbBlagajna
        '
        Me.tbBlagajna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbBlagajna.Location = New System.Drawing.Point(160, 18)
        Me.tbBlagajna.MaxLength = 12
        Me.tbBlagajna.Name = "tbBlagajna"
        Me.tbBlagajna.Size = New System.Drawing.Size(210, 22)
        Me.tbBlagajna.TabIndex = 239
        Me.tbBlagajna.Text = ""
        Me.tbBlagajna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label8.Location = New System.Drawing.Point(112, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(776, 40)
        Me.Label8.TabIndex = 328
        '
        'FormUpdateCimGr
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(914, 600)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.btnUpis)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnUnosRobe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUpdateCimGr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ": : :  Izmena  : : :"
        CType(Me.tbsSatVoza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.tbsSatVoza2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnUnosRobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnosRobe.Click
        mTarifa = Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2)
        mBrojUg = Me.tbUgovor.Text

        If bVrstaPosiljke = "K" Then
            Dim GridKola As New kola
            GridKola.Show()
        Else
            Dim GridDencane As New Dencane
            GridDencane.Show()
        End If

    End Sub

    Private Sub FormUpdateCimGr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _OpenForm = "IzvozUpd"
        Init_UpdTarifa()
        Init_UpdForma()

        Me.Text = Me.Text & " [ unet u stanici: " & UpdStanicaRecID & " ]"
        Label8.Text = "Ovaj dokument je unet u stanici:  " + nmNazivOtpSt

        Me.tbsBrojVoza.Text = msBrojVoza
        Me.tbsSatVoza.Text = mSatVoza

        If IzborSaobracaja = "3" Then
            tbsBrojVoza2.Focus()
        ElseIf IzborSaobracaja = "2" Then
            tbsBrojVoza2.Focus()
        End If

    End Sub
    Private Sub Init_UpdTarifa()
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim sql_trz1 As String = "SELECT dbo.ZsTarifa.SifraTarife, dbo.ZsTarifa.Opis FROM dbo.ZsTarifa " & _
                                 "WHERE (dbo.ZsTarifa.SifraVS = '" & IzborSaobracaja & "')"

        Dim sql_commTrz1 As New SqlClient.SqlCommand(sql_trz1, DbVeza)
        Dim rdrTar As SqlClient.SqlDataReader
        Dim combo_linija1 As String = ""
        ComboBox1.Items.Clear()
        rdrTar = sql_commTrz1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrTar.Read()
            combo_linija1 = rdrTar.GetString(0) & " - " & rdrTar.GetString(1)
            ComboBox1.Items.Add(combo_linija1)
        Loop
        rdrTar.Close()
        DbVeza.Close()

        Me.tbUgovor.Text = mBrojUg
        If mBrojUg <> Nothing And Len(Trim(mBrojUg)) = 6 Then
            ComboBox1.SelectedIndex = 0
        Else

        End If
    End Sub
    Private Sub Init_UpdForma()
        mDinaraPoTL = 0
        If IzborSaobracaja = "4" Then
            Me.Label6.Visible = False
            Me.TextBox1.Visible = False

            If TipTranzita = "ulaz" Then
                Me.Text = " :: Tranzit ULAZ :: "
                tbUlaznaNalepnica.Enabled = True
                tbIzlaznaNalepnica.Enabled = False

                PostaviPrelaz(Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mIzPrelaz)

                Me.cbSmer1.Text = mStanica1
                Me.cbSmer1.Enabled = False
                Me.cbSmer2.Text = mStanica2
                Me.cbSmer2.Enabled = True

                Me.Label11.Text = "Datum ulaza"

            Else
                Me.Text = " :: Tranzit IZLAZ :: "
                PostaviPrelaz(mUlPrelaz, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5))

                Me.cbSmer1.Text = mStanica1
                Me.cbSmer1.Enabled = False
                Me.cbSmer2.Text = mStanica2
                Me.cbSmer2.Enabled = False
                tbUlaznaNalepnica.Enabled = True
                tbIzlaznaNalepnica.Enabled = True
                btnUnosRobe.Visible = False
            End If
            tbUlaznaNalepnica.Text = mUlEtiketa
            tbIzlaznaNalepnica.Text = mIzEtiketa
        ElseIf IzborSaobracaja = "2" Then
            Me.Text = " :: U V O Z :: "
            PostaviPrelaz(UpdStanicaRecID, "")
            Me.cbSmer1.Enabled = False
            Me.cbSmer1.Text = mStanica1 'UpdStanicaRecID 'StanicaUnosa
            Me.cbSmer2.Enabled = False
            tbUlaznaNalepnica.Enabled = False
            tbIzlaznaNalepnica.Enabled = False
            Me.tbCarinjenje.Enabled = True
            Me.tbsSatVoza2.Enabled = False
            Me.tbsBrojVoza2.Enabled = False
            Me.DatumIzl.Enabled = False
            Me.Label11.Visible = True

            If GranicnaStanica = "D" Then
                Me.Label11.Text = "Datum ulaza"
                Me.Label6.Visible = False
                Me.TextBox1.Visible = False
            Else
                Me.Label11.Text = "Datum prispeca"
                Me.Label6.Visible = True
                Me.TextBox1.Visible = True

                Me.GroupBox1.Visible = True

                'F R A N K O
                Me.GroupBox1.Text = "UPUCENI IZNOS PO TOVARNOM LISTU"
                Label2.Text = "Iznos u dinarima"
                tbBlagajna.Text = Format(mDinaraPoTL, "###,###,##0.00")
                Me.GroupBox6.Visible = True
                Me.GroupBox2.Text = " [ Prispece ] "
                Me.Label1.Visible = False
                Me.tbUlaznaNalepnica.Visible = False
                Me.Label16.Visible = False
                Me.tbPolaznaCarina.Visible = False
                Me.Label12.Enabled = False
                Me.Label13.Enabled = False
                Me.Label15.Enabled = False
                Label5.Text = "Registrovanje posiljke u uputnoj stanici"
            End If

        ElseIf IzborSaobracaja = "3" Then
            Me.Text = " :: I Z V O Z :: "
            PostaviPrelaz("", mIzPrelaz)
            Me.cbSmer1.Enabled = False
            Me.cbSmer2.Text = mStanica2 ' UpdStanicaRecID 'StanicaUnosa
            Me.cbSmer2.Enabled = True
            tbUlaznaNalepnica.Enabled = False
            tbIzlaznaNalepnica.Visible = False
            Me.tbCarinjenje.Enabled = True
            Me.tbsSatVoza2.Enabled = True
            Me.tbsBrojVoza2.Enabled = True
            Me.DatumIzl.Enabled = True

            GroupBox6.Enabled = True

            Me.Label13.Visible = False
            Me.Label6.Visible = False
            Me.TextBox1.Visible = False
            Me.Label1.Visible = False
            Me.tbIzlaznaNalepnica.Visible = False
            Me.tbUlaznaNalepnica.Visible = False

            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = Microsoft.VisualBasic.Right(mOtpStanica, 5) Then
                Me.cbSmer2.Enabled = True
            Else
                GroupBox6.Enabled = False 'True
                GroupBox6.Text = "[ Otpravljanje ] "
            End If

            'mTarifa = izSifraTarife
            'mBrojUg = izUgovor
            If mTarifa = "00" Then
                Me.ComboBox1.SelectedIndex = 0
            ElseIf mTarifa = "36" Then
                Me.ComboBox1.SelectedIndex = 2
            ElseIf mTarifa = "68" Then
                Me.ComboBox1.SelectedIndex = 5
            End If

            tbUgovor.Text = mBrojUg
            Label5.Text = "Registrovanje posiljke na izlaznom granicnom prelazu"
            Me.tbsBrojVoza2.Focus()
            Me.DatumUl.Text = UpdDatum
            Label11.Text = "Datum otpravljanja"
            Label33.Visible = False
            cbSmer1.Visible = False
            Label3.Visible = False
            Me.tbsSatVoza.Visible = False
            Label7.Visible = False
            Me.tbsBrojVoza.Visible = False
        End If

        Me.tbPolaznaCarina.Text = mCarStanica
        Me.tbCarinjenje.Text = mCarStanica2

        mAkcija = "Upd"
        mObrMesec = Today.Month
        mObrGodina = Today.Year

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        _OpenForm = "IzvozUpdNO"
        Close()

    End Sub

    Private Sub btnUpis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpis.Click
        _OpenForm = "IzvozUpd"

        If Me.ComboBox1.Text = Nothing Then
            Me.ComboBox1.Focus()
        Else
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            mTarifa = Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2)
            mBrojUg = Me.tbUgovor.Text

            If IzborSaobracaja = "4" Then
                UpdTranzita()
                Cursor.Current = System.Windows.Forms.Cursors.Default

                If TipTranzita = "ulaz" Then
                    Me.ComboBox1.Focus()
                Else
                    Close()
                End If
            Else
                UpdExIm()
                Cursor.Current = System.Windows.Forms.Cursors.Default

                'Me.ComboBox1.Focus()
                'MessageBox.Show("Uspesan upis", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.Close()

        End If

    End Sub

    Private Sub cbSmer1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbSmer2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUlaznaNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUlaznaNalepnica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbIzlaznaNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbIzlaznaNalepnica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbsBrojVoza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsBrojVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbsSatVoza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsSatVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbsSatVoza2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsSatVoza2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbsBrojVoza2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsBrojVoza2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPolaznaCarina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPolaznaCarina.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbCarinjenje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbCarinjenje.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DatumUl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumUl.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DatumIzl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumIzl.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUgovor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.Leave
        Me.btnUnosRobe.Focus()

    End Sub
    Private Sub UpdTranzita()

        Dim slogTrans As SqlTransaction
        Dim rv As String
        Dim drKola As DataRow
        Dim drNhm As DataRow
        Dim drDencane As DataRow
        Dim drNaknade As DataRow
        Dim mopRecID As Int32 = 0
        Dim mUkljucujuci As String = ""
        Dim mDoPrelaza As String = ""
        Dim mValUrIsp, mValPouz, mValVR As String
        Dim mPos1, mPos2, mPri1, mPri2 As Int32

        If TipTranzita = "ulaz" Then
            mUlEtiketa = CType(tbUlaznaNalepnica.Text, Int32)
            If RecordAction = "N" Then
                mIzEtiketa = CType(tbIzlaznaNalepnica.Text, Int32)
            Else
                mIzEtiketa = 0
            End If
        Else
            mUlEtiketa = CType(tbUlaznaNalepnica.Text, Int32)
            mIzEtiketa = CType(tbIzlaznaNalepnica.Text, Int32)
        End If

        '---------------------------------- Pristupa bazi -----------------------------------
        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If
            slogTrans = DbVeza.BeginTransaction()
            mAkcija = "Upd"

            If Me.tbsBrojVoza2.Text = Nothing Then
                Me.tbsBrojVoza2.Text = "0"
            End If
            If tbsSatVoza2.Text = Nothing Then
                tbsSatVoza2.Text = "0"
            End If
            ''UpdUprava = otUprava
            ''UpdStanica = otStanica
            ''UpdBroj = otBroj
            ''UpdDatum = otDatum

            ''''''''
            mDinaraPoTL = 0
            Upis.UpdSlogKalk(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), mUlEtiketa, _
                             DatumUl.Text, 0, Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5), mIzEtiketa, DatumIzl.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, _
                             CType(Me.tbsBrojVoza2.Text, Int32), tbsSatVoza2.Text, mTarifa, mBrojUg, dtKola.Rows.Count, _
                             Me.tbPolaznaCarina.Text, Me.tbCarinjenje.Text, mDinaraPoTL, rv)

            ''Upis.UpdSlogKalk(slogTrans, mAkcija, UpdRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), mUlEtiketa, _
            ''                 DatumUl.Text, 0, Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5), mIzEtiketa, DatumIzl.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, _
            ''                 CType(Me.tbsBrojVoza2.Text, Int32), tbsSatVoza2.Text, mTarifa, mBrojUg, dtKola.Rows.Count, _
            ''                 Me.tbPolaznaCarina.Text, Me.tbCarinjenje.Text, mDinaraPoTL, rv)
            '''''''''ne
            'Upis.UpdSlogKalk1(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), 0, _
            '                  DatumUl.Text, mPrispece, Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5), 0, DatumIzl.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, _
            '                  CType(Me.tbsBrojVoza2.Text, Int32), tbsSatVoza2.Text, mTarifa, mBrojUg, dtKola.Rows.Count, _
            '                  Me.tbPolaznaCarina.Text, Me.tbCarinjenje.Text, rv)

            '''''''''ne
            'Upis.UpdSlogKalkNew(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), 0, _
            '                     DatumUl.Text, mPrispece, mRBB, Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5), 0, DatumIzl.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, _
            '                     CType(Me.tbsBrojVoza2.Text, Int32), tbsSatVoza2.Text, mTarifa, mBrojUg, dtKola.Rows.Count, _
            '                     Me.tbPolaznaCarina.Text, Me.tbCarinjenje.Text, mDinaraPoTL, rv)



            If rv <> "" Then Throw New Exception(rv)
            '-- End Upis u SlogKalk -----------------------------------------

            '-- 2. Upis u SlogKola ---------------------------------------------  
            If bVrstaPosiljke = "K" Then
                Dim rbKola As Int16 = 1
                Dim rbRoba As Int16 = 1

                
                If TipTranzita = "ulaz" Then
                    If dtKola.Rows.Count > 0 Then
                        For Each drKola In dtKola.Rows

                            If MasterAction = "New" Then
                                mAkcija = "New"
                            Else
                                If drKola("Action") = "I" Then
                                    mAkcija = "New"
                                ElseIf drKola("Action") = "U" Then
                                    mAkcija = "Upd"
                                ElseIf drKola("Action") = "D" Then
                                    mAkcija = "Del"
                                End If
                            End If



                            Upis.UpisSlogKola(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), UpdUprava, UpdStanica, UpdBroj, UpdDatum, rbKola, _
                                         drKola("IndBrojKola"), drKola("KB"), drKola("Uprava"), drKola("Vlasnik"), drKola("Serija"), _
                                         drKola("Osovine"), drKola("Tara"), drKola("GrTov"), drKola("Stitna"), drKola("Tip"), drKola("Prevoznina"), _
                                         drKola("Naknada"), drKola("ICF"), rv)
                            '-- 2.1. Upis u SlogRoba ---------------------------------------------  
                            For Each drNhm In dtNhm.Rows
                                If drNhm("IndBrojKola") = drKola("IndBrojKola") Then
                                    If MasterAction = "New" Then
                                        mAkcija = "New"
                                    Else
                                        If drNhm("Action") = "I" Then
                                            mAkcija = "New"
                                        ElseIf drNhm("Action") = "U" Then
                                            mAkcija = "Upd"
                                        ElseIf drNhm("Action") = "D" Then
                                            mAkcija = "Del"
                                        End If
                                    End If

                                    Upis.UpisSlogRobaDec(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), UpdUprava, UpdStanica, UpdBroj, UpdDatum, _
                                                        rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("MasaDec"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
                                                        drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
                                                        drNhm("UTIBuletin"), drNhm("UTIPlombe"), rv)

                                    rbRoba = rbRoba + 1
                                End If
                            Next
                            '-- End Upis u SlogRoba -----------------------------------------  
                            rbKola = rbKola + 1
                            rbRoba = 1
                        Next
                    End If
                    '-- End Upis u SlogRoba -----------------------------------------  
                End If
                
                If rv <> "" Then Throw New Exception(rv)
            Else
                '-- 2d. Upis u SlogDencane ------------------------------------------
                Dim rbDencane As Int16 = 1
                For Each drDencane In dtDencane.Rows
                    If MasterAction = "New" Then
                        mAkcija = "New"
                    Else
                        If drDencane("Action") = "I" Then
                            mAkcija = "New"
                        ElseIf drDencane("Action") = "U" Then
                            mAkcija = "Upd"
                        ElseIf drDencane("Action") = "D" Then
                            mAkcija = "Del"
                        End If
                    End If

                    Upis.UpisSlogDencane(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                UpdUprava, UpdStanica, UpdBroj, UpdDatum, _
                                rbDencane, drDencane("SMasa"), drDencane("RMasa"), _
                                drDencane("Tarifa"), drDencane("Tip"), drDencane("Komada"), _
                                drDencane("Iznos"), drDencane("Valuta"), rv)

                    rbDencane = rbDencane + 1
                Next
                If rv <> "" Then Throw New Exception(rv)
            End If

            '-- 3. Upis u SlogNaknada ------------------------------------------
            Dim rbNaknade As Int16 = 1
            If dtNaknade.Rows.Count > 0 Then
                For Each drNaknade In dtNaknade.Rows
                    If MasterAction = "New" Then
                        mAkcija = "New"
                    Else
                        If drNaknade("Action") = "I" Then
                            mAkcija = "New"
                        ElseIf drNaknade("Action") = "U" Then
                            mAkcija = "Upd"
                        ElseIf drNaknade("Action") = "D" Then
                            mAkcija = "Del"
                        End If
                    End If

                    Upis.UpisSlogNaknada(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), UpdUprava, UpdStanica, UpdBroj, UpdDatum, _
                          rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
                          drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

                    rbNaknade = rbNaknade + 1
                Next
            End If
            '-- End Upis u SlogNaknada --------------------------------------

            If rv = "" Then
                slogTrans.Commit()
                Me.Text = " ::: Uspesan upis! :::"
            Else
                MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                slogTrans.Rollback()
            End If
            '-- Zavrsetak upisa u Slog*

            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()

            Me.ComboBox1.Focus()
        Catch ex As Exception
            rv = ex.Message
            MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch sqlex As SqlException
            MsgBox(sqlex.Message)
        Finally
            DbVeza.Close()
        End Try

    End Sub
    Private Sub UpdExIm()

        Dim slogTrans As SqlTransaction
        Dim rv As String
        Dim drKola As DataRow
        Dim drNhm As DataRow
        Dim drDencane As DataRow
        Dim drNaknade As DataRow
        Dim mopRecID As Int32 = 0
        Dim mUkljucujuci As String = ""
        Dim mDoPrelaza As String = ""
        Dim mValUrIsp, mValPouz, mValVR As String
        Dim mPos1, mPos2, mPri1, mPri2 As Int32

        '---------------------------------- Pristupa bazi -----------------------------------
        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If
            slogTrans = DbVeza.BeginTransaction()
            mAkcija = "Upd"

            If Me.tbsBrojVoza2.Text = Nothing Then
                Me.tbsBrojVoza2.Text = "0"
            End If
            If tbsSatVoza2.Text = Nothing Then
                tbsSatVoza2.Text = "0"
            End If
            ''UpdUprava = otUprava
            ''UpdStanica = otStanica
            ''UpdBroj = otBroj
            ''UpdDatum = otDatum

            'Dim obrStanicaUnosa As String = StanicaUnosa
            'StanicaUnosa = UpdStanicaRecID

            ''''integralna verzija za sve stanice DODATI: tlRealizovan = '99999' !!!!

            If GranicnaStanica = "N" Then
                If Me.TextBox1.Text = Nothing Then
                    mPrispece = 0
                Else
                    mPrispece = CType(TextBox1.Text, Int32)
                End If

                If IzborSaobracaja = "2" Then
                    mDinaraPoTL = CDec(tbBlagajna.Text)
                End If
            Else
                mPrispece = 0
            End If

            If GranicnaStanica = "N" And IzborSaobracaja = "2" Then
                Upis.UpdSlogKalkNew(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), 0, _
                                 DatumUl.Text, mPrispece, mRBB, Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5), 0, DatumIzl.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, _
                                 CType(Me.tbsBrojVoza2.Text, Int32), tbsSatVoza2.Text, mTarifa, mBrojUg, dtKola.Rows.Count, _
                                 Me.tbPolaznaCarina.Text, Me.tbCarinjenje.Text, mDinaraPoTL, rv)

                'Upis.UpdSlogKalk(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), 0, _
                ' DatumUl.Text, mPrispece, Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5), 0, DatumIzl.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, _
                ' CType(Me.tbsBrojVoza2.Text, Int32), tbsSatVoza2.Text, mTarifa, mBrojUg, dtKola.Rows.Count, _
                ' Me.tbPolaznaCarina.Text, Me.tbCarinjenje.Text, mDinaraPoTL, rv)
            Else
                Upis.UpdSlogKalk1(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), 0, _
                                 DatumUl.Text, mPrispece, Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5), 0, DatumIzl.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, _
                                 CType(Me.tbsBrojVoza2.Text, Int32), tbsSatVoza2.Text, mTarifa, mBrojUg, dtKola.Rows.Count, _
                                 Me.tbPolaznaCarina.Text, Me.tbCarinjenje.Text, rv)
            End If

            If rv <> "" Then Throw New Exception(rv)
            '-- End Upis u SlogKalk -----------------------------------------

            '-- 2. Upis u SlogKola ---------------------------------------------  
            If bVrstaPosiljke = "K" Then
                Dim rbKola As Int16 = 1
                Dim rbRoba As Int16 = 1

                If dtKola.Rows.Count > 0 Then
                    For Each drKola In dtKola.Rows

                        'pravio grešku u Dimitrovgradu!
                        'If InitNumKola > dtKola.Rows.Count Then
                        '    mAkcija = "Del"
                        'ElseIf InitNumKola < dtKola.Rows.Count Then
                        '    mAkcija = "New"
                        'ElseIf InitNumKola = dtKola.Rows.Count Then
                        '    mAkcija = "Upd"
                        'End If

                        If drKola("Action") = "I" Then
                            mAkcija = "New"
                        ElseIf drKola("Action") = "U" Then
                            mAkcija = "Upd"
                        ElseIf drKola("Action") = "D" Then
                            mAkcija = "Del"
                        End If

                        'Upis.UpisSlogKola(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, UpdUprava, UpdStanica, UpdBroj, UpdDatum, rbKola, _
                        '             drKola("IndBrojKola"), drKola("KB"), drKola("Uprava"), drKola("Vlasnik"), drKola("Serija"), _
                        '             drKola("Osovine"), drKola("Tara"), drKola("GrTov"), drKola("Stitna"), drKola("Tip"), drKola("Prevoznina"), _
                        '             drKola("Naknada"), drKola("ICF"), rv)

                        Upis.eUpisSlogKola(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, rbKola, _
                                     drKola("IndBrojKola"), drKola("KB"), drKola("Uprava"), drKola("Vlasnik"), drKola("Serija"), _
                                     drKola("Osovine"), drKola("Tara"), drKola("GrTov"), drKola("Stitna"), drKola("Tip"), drKola("Prevoznina"), _
                                     drKola("Naknada"), drKola("ICF"), rv)

                        If rv <> "" Then Throw New Exception(rv)

                        '-- 2.1. Upis u SlogRoba ---------------------------------------------  
                        For Each drNhm In dtNhm.Rows
                            If drNhm("IndBrojKola") = drKola("IndBrojKola") Then

                                'If InitNumRoba > dtNhm.Rows.Count Then
                                '    mAkcija = "Del"
                                'ElseIf InitNumRoba < dtNhm.Rows.Count Then
                                '    mAkcija = "New"
                                'ElseIf InitNumRoba = dtNhm.Rows.Count Then
                                '    mAkcija = "Upd"
                                'End If

                                If drNhm("Action") = "I" Then
                                    mAkcija = "New"
                                ElseIf drNhm("Action") = "U" Then
                                    mAkcija = "Upd"
                                ElseIf drNhm("Action") = "D" Then
                                    mAkcija = "Del"
                                End If

                                'Upis.UpisSlogRobaDec(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, UpdUprava, UpdStanica, UpdBroj, UpdDatum, _
                                '                    rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("MasaDec"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
                                '                    drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
                                '                    drNhm("UTIBuletin"), drNhm("UTIPlombe"), rv)

                                Upis.eUpisSlogRobaDec(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, _
                                                    rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("MasaDec"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
                                                    drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
                                                    drNhm("UTIBuletin"), drNhm("UTIPlombe"), rv)

                                rbRoba = rbRoba + 1
                            End If
                        Next
                        '-- End Upis u SlogRoba -----------------------------------------  
                        rbKola = rbKola + 1
                        rbRoba = 1
                    Next
                End If
                '-- End Upis u SlogRoba -----------------------------------------  
                If rv <> "" Then Throw New Exception(rv)
            Else
                '-- 2d. Upis u SlogDencane ------------------------------------------
                Dim rbDencane As Int16 = 1

                For Each drDencane In dtDencane.Rows

                    If MasterAction = "New" Then
                        mAkcija = "New"
                    Else
                        If drDencane("Action") = "I" Then
                            mAkcija = "New"
                        ElseIf drDencane("Action") = "U" Then
                            mAkcija = "Upd"
                        ElseIf drDencane("Action") = "D" Then
                            mAkcija = "Del"
                        End If
                    End If

                    'Upis.UpisSlogDencane(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, _
                    '            UpdUprava, UpdStanica, UpdBroj, UpdDatum, _
                    '            rbDencane, drDencane("SMasa"), drDencane("RMasa"), _
                    '            drDencane("Tarifa"), drDencane("Tip"), drDencane("Komada"), _
                    '            drDencane("Iznos"), drDencane("Valuta"), rv)
                    Upis.eUpisSlogDencane(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, _
                                          rbDencane, drDencane("SMasa"), drDencane("RMasa"), _
                                          drDencane("Tarifa"), drDencane("Tip"), drDencane("Komada"), _
                                          drDencane("Iznos"), drDencane("Valuta"), rv)


                    rbDencane = rbDencane + 1
                Next

                If rv <> "" Then Throw New Exception(rv)
            End If

            '-- 3. Upis u SlogNaknada ------------------------------------------
            Dim rbNaknade As Int16 = 1
            If dtNaknade.Rows.Count > 0 Then
                mopRecID = UpdRecID
                'UpdStanicaRecID = UpdStanicaRecID

                For Each drNaknade In dtNaknade.Rows
                    If InitNumNak > dtNaknade.Rows.Count Then
                        mAkcija = "Del"
                    ElseIf InitNumNak < dtNaknade.Rows.Count Then
                        mAkcija = "New"
                    ElseIf InitNumNak = dtNaknade.Rows.Count Then
                        mAkcija = "Upd"
                    End If

                    ''If MasterAction = "New" Then
                    ''    mAkcija = "New"
                    ''Else
                    ''    If drNaknade("Action") = "I" Then
                    ''        mAkcija = "New"
                    ''    ElseIf drNaknade("Action") = "U" Then
                    ''        mAkcija = "Upd"
                    ''    ElseIf drNaknade("Action") = "D" Then
                    ''        mAkcija = "Del"
                    ''    End If
                    ''End If

                    'Upis.UpisSlogNaknada(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, UpdUprava, UpdStanica, UpdBroj, UpdDatum, _
                    '      rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
                    '      drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)
                    Upis.eUpisSlogNaknada(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, _
                          rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
                          drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

                    rbNaknade = rbNaknade + 1
                Next
            End If
            '-- End Upis u SlogNaknada --------------------------------------


            If rv = "" Then
                slogTrans.Commit()
                'Me.Text = " ::: Uspesan upis! :::"
                _OpenForm = "IzvozUpd"
            Else
                _OpenForm = "IzvozUpdErr"
                MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                slogTrans.Rollback()
            End If
            '-- Zavrsetak upisa u Slog*

            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()

            Me.ComboBox1.Focus()
        Catch ex As Exception
            _OpenForm = "IzvozUpdErr"
            rv = ex.Message
            MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch sqlex As SqlException
            _OpenForm = "IzvozUpdErr"
            MsgBox(sqlex.Message)
        Finally
            DbVeza.Close()
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim GridNaknade As New naknade
        GridNaknade.ShowDialog()
    End Sub

    Private Sub tbsBrojVoza2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsBrojVoza2.TextChanged

    End Sub

    Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        If ComboBox1.Text = Nothing Then
            ComboBox1.Focus()
        Else
            If Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2) <> "00" Then
                Me.tbUgovor.Text = ""
            End If
        End If

    End Sub

    
    Private Sub FormUpdateCimGr_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '''''If GranicnaStanica = "N" Then
        '''''    If mPrikazKalkulacije = "D" Then
        '''''        Me.GroupBox1.Visible = True
        '''''        tbBlagajna.Text = Format(mPrevoznina, "###,###,##0.00")
        '''''    End If
        '''''End If

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnCarinarnica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarinarnica.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "help carinarnice"
        upit = "CARINA"
        helpUic.ShowDialog()

        Me.tbCarinjenje.Text = mIzlaz1

    End Sub

    Private Sub tbCarinjenje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCarinjenje.LostFocus
        Me.btnUpis.Focus()

    End Sub
End Class
