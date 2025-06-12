Imports System.Data.SqlClient
Public Class TrzIzlaz
    Inherits System.Windows.Forms.Form
    Public _ul_control As String = "D"


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
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents fxIBK As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents tbIzlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbUlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DatumIzlaza As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnUpis As System.Windows.Forms.Button
    Friend WithEvents btnTranzitIzlaz As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbBrojVoza As System.Windows.Forms.TextBox
    Friend WithEvents cbPrelaz As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbKomBroj As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbSat As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TrzIzlaz))
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.fxIBK = New FlxMaskBox.FlexMaskEditBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.tbSat = New System.Windows.Forms.TextBox
        Me.tbKomBroj = New System.Windows.Forms.TextBox
        Me.tbBrojVoza = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbIzlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.DatumIzlaza = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbUlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cbPrelaz = New System.Windows.Forms.ComboBox
        Me.btnTranzitIzlaz = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnUpis = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.Label15 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(632, 412)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(97, 80)
        Me.btnOtkazi.TabIndex = 4
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 191)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Kola"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fxIBK
        '
        Me.fxIBK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxIBK.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxIBK.Location = New System.Drawing.Point(89, 184)
        Me.fxIBK.Mask = "99 99 9999 999 9"
        Me.fxIBK.Name = "fxIBK"
        Me.fxIBK.Size = New System.Drawing.Size(112, 21)
        Me.fxIBK.TabIndex = 0
        Me.fxIBK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox7.Controls.Add(Me.tbSat)
        Me.GroupBox7.Controls.Add(Me.tbKomBroj)
        Me.GroupBox7.Controls.Add(Me.tbBrojVoza)
        Me.GroupBox7.Controls.Add(Me.Label9)
        Me.GroupBox7.Controls.Add(Me.tbIzlaznaNalepnica)
        Me.GroupBox7.Controls.Add(Me.DatumIzlaza)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(232, 264)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(496, 126)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = " [ Upis izlaznih podataka ]"
        '
        'tbSat
        '
        Me.tbSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSat.Location = New System.Drawing.Point(280, 83)
        Me.tbSat.MaxLength = 5
        Me.tbSat.Name = "tbSat"
        Me.tbSat.Size = New System.Drawing.Size(56, 21)
        Me.tbSat.TabIndex = 2
        Me.tbSat.Text = "00"
        Me.tbSat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbKomBroj
        '
        Me.tbKomBroj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKomBroj.Location = New System.Drawing.Point(384, 32)
        Me.tbKomBroj.MaxLength = 5
        Me.tbKomBroj.Name = "tbKomBroj"
        Me.tbKomBroj.Size = New System.Drawing.Size(40, 21)
        Me.tbKomBroj.TabIndex = 4
        Me.tbKomBroj.Text = ""
        Me.tbKomBroj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbKomBroj.Visible = False
        '
        'tbBrojVoza
        '
        Me.tbBrojVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojVoza.Location = New System.Drawing.Point(352, 83)
        Me.tbBrojVoza.MaxLength = 5
        Me.tbBrojVoza.Name = "tbBrojVoza"
        Me.tbBrojVoza.Size = New System.Drawing.Size(112, 21)
        Me.tbBrojVoza.TabIndex = 3
        Me.tbBrojVoza.Text = ""
        Me.tbBrojVoza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(376, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 23)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Trasa voza"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbIzlaznaNalepnica
        '
        Me.tbIzlaznaNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIzlaznaNalepnica.Location = New System.Drawing.Point(27, 40)
        Me.tbIzlaznaNalepnica.MaxLength = 5
        Me.tbIzlaznaNalepnica.Name = "tbIzlaznaNalepnica"
        Me.tbIzlaznaNalepnica.Size = New System.Drawing.Size(200, 21)
        Me.tbIzlaznaNalepnica.TabIndex = 0
        Me.tbIzlaznaNalepnica.Text = "0"
        Me.tbIzlaznaNalepnica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DatumIzlaza
        '
        Me.DatumIzlaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumIzlaza.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumIzlaza.Location = New System.Drawing.Point(27, 83)
        Me.DatumIzlaza.Name = "DatumIzlaza"
        Me.DatumIzlaza.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(82, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Datum izlaska"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(320, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 23)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Komercijalni broj voza"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Visible = False
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(280, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 23)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "Sat voza"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(53, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 23)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Izlazna tranzitna nalepnica"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbUlaznaNalepnica
        '
        Me.tbUlaznaNalepnica.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.tbUlaznaNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUlaznaNalepnica.ForeColor = System.Drawing.Color.Navy
        Me.tbUlaznaNalepnica.Location = New System.Drawing.Point(20, 80)
        Me.tbUlaznaNalepnica.MaxLength = 5
        Me.tbUlaznaNalepnica.Name = "tbUlaznaNalepnica"
        Me.tbUlaznaNalepnica.Size = New System.Drawing.Size(216, 22)
        Me.tbUlaznaNalepnica.TabIndex = 0
        Me.tbUlaznaNalepnica.Text = "0"
        Me.tbUlaznaNalepnica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 23)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Ulazna tranzitna nalepnica"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbUlaznaNalepnica)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cbPrelaz)
        Me.GroupBox1.Controls.Add(Me.btnTranzitIzlaz)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(232, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 246)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Preuzimanje podataka sa ulaza ]"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(164, 23)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Ulazni prelaz"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(146, 160)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 72)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Pronadji"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbPrelaz
        '
        Me.cbPrelaz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrelaz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbPrelaz.ForeColor = System.Drawing.Color.Navy
        Me.cbPrelaz.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbPrelaz.Location = New System.Drawing.Point(20, 128)
        Me.cbPrelaz.Name = "cbPrelaz"
        Me.cbPrelaz.Size = New System.Drawing.Size(216, 24)
        Me.cbPrelaz.TabIndex = 1
        '
        'btnTranzitIzlaz
        '
        Me.btnTranzitIzlaz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnTranzitIzlaz.Image = CType(resources.GetObject("btnTranzitIzlaz.Image"), System.Drawing.Image)
        Me.btnTranzitIzlaz.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTranzitIzlaz.Location = New System.Drawing.Point(20, 160)
        Me.btnTranzitIzlaz.Name = "btnTranzitIzlaz"
        Me.btnTranzitIzlaz.Size = New System.Drawing.Size(87, 72)
        Me.btnTranzitIzlaz.TabIndex = 5
        Me.btnTranzitIzlaz.Text = "CIM"
        Me.btnTranzitIzlaz.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTranzitIzlaz.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 23)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Operater"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(89, 52)
        Me.TextBox1.MaxLength = 4
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(112, 21)
        Me.TextBox1.TabIndex = 34
        Me.TextBox1.Text = ""
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.fxIBK)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(496, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(232, 246)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Otpravljanje ]"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(89, 151)
        Me.TextBox4.MaxLength = 5
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(112, 21)
        Me.TextBox4.TabIndex = 41
        Me.TextBox4.Text = ""
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 23)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Datum"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(89, 118)
        Me.TextBox3.MaxLength = 5
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(112, 21)
        Me.TextBox3.TabIndex = 39
        Me.TextBox3.Text = ""
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Broj"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(89, 85)
        Me.TextBox2.MaxLength = 7
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(112, 21)
        Me.TextBox2.TabIndex = 37
        Me.TextBox2.Text = ""
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 23)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Stanica"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnUpis
        '
        Me.btnUpis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnUpis.Image = CType(resources.GetObject("btnUpis.Image"), System.Drawing.Image)
        Me.btnUpis.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpis.Location = New System.Drawing.Point(520, 412)
        Me.btnUpis.Name = "btnUpis"
        Me.btnUpis.Size = New System.Drawing.Size(97, 80)
        Me.btnUpis.TabIndex = 3
        Me.btnUpis.Text = "Upis u bazu"
        Me.btnUpis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpis.Visible = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(24, 400)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 23)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Label12"
        Me.Label12.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(32, 440)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(232, 56)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "ISPRAVI dbo.NadjiUlazniTranzit  privremeno samo za 2008!"
        Me.Label15.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 140)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Goldenrod
        Me.Label10.Location = New System.Drawing.Point(12, 176)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(200, 40)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "I Z L A Z"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(20, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(130, 23)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Godina ulaska posiljke"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(172, 24)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {2010, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(64, 23)
        Me.NumericUpDown1.TabIndex = 42
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {2011, 0, 0, 0})
        '
        'TrzIzlaz
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(738, 501)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnUpis)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.btnOtkazi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TrzIzlaz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tranzit IZLAZ"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Me.Close()

    End Sub

    Private Sub tbIzlaznaNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbIzlaznaNalepnica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim otUprava As String
        Dim otStanica As String
        Dim otBroj As Int32
        Dim otDatum As Date
        Dim ulNalepnica As Int32
        Dim izNalepnica As Int32
        Dim ulIBK As String
        Dim otBrojVoza As String
        Dim otRecID As Int32
        Dim mRetVal As String

        UlazniTranzit = cbPrelaz.Text
        mObrGodina = Today.Year

        NadjiUlazniTranzit2(tbUlaznaNalepnica.Text, Microsoft.VisualBasic.Mid(cbPrelaz.Text, 5, 5), Me.NumericUpDown1.Text.ToString, otUprava, otStanica, otBroj, otDatum, izNalepnica, ulIBK, otBrojVoza, otRecID, mRetVal)
        'NadjiUlazniTranzit2(tbUlaznaNalepnica.Text, Microsoft.VisualBasic.Mid(cbPrelaz.Text, 5, 5), mObrGodina, otUprava, otStanica, otBroj, otDatum, izNalepnica, ulIBK, otBrojVoza, otRecID, mRetVal)

        If mRetVal = "" Then ' pronadjen dokument - preuzimanje podataka za azuriranje
            If izNalepnica > 0 Then
                _ul_control = "N"

                ErrorProvider1.SetError(tbUlaznaNalepnica, "Za ovaj dokument izlazna tranzitna nalepnica je vec uneta!")
                tbUlaznaNalepnica.Focus()
            Else
                _ul_control = "D"
                Me.GroupBox7.BackColor = System.Drawing.Color.Silver
                TextBox1.Text = otUprava
                TextBox2.Text = otStanica
                TextBox3.Text = otBroj
                TextBox4.Text = otDatum
                fxIBK.Text = ulIBK
                tbBrojVoza.Text = Trim(otBrojVoza)
                msBrojVoza = Trim(otBrojVoza)
                Me.tbIzlaznaNalepnica.Text = mIzEtiketa + 1

                Label12.Text = otRecID.ToString

                btnTranzitIzlaz.Visible = True
                btnUpis.Visible = True
                ErrorProvider1.SetError(tbUlaznaNalepnica, "")
                Me.tbIzlaznaNalepnica.Focus()
            End If
        Else
            'MessageBox.Show("Ne postoji takav podatak! Unesite podatke o tranzitnoj posiljci.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '===============
            Dim Msg As String
            Dim Ans As MsgBoxResult
            Msg = "Ne postoji takav podatak, ili je neodgovarajuci podatak o godini ulaska posiljke. " & Chr(13)
            Msg = Msg & "Izaberite jednu od dve mogucnosti: " & Chr(13)
            Msg = Msg & " " & Chr(13)
            Msg = Msg & "[ DA ] Promenite podatak za godinu ulaska posiljke" & Chr(13)
            Msg = Msg & "[ NE ] Unesite podatke o tranzitnoj posiljci" & Chr(13)

            Ans = MsgBox(Msg, vbYesNo + vbInformation, "Akcija")
            If Ans = vbNo Then
                btnTranzitIzlaz_Click(Me, Nothing)
            Else
                Me.NumericUpDown1.Focus()
            End If
            '===============



            '''            btnTranzitIzlaz_Click(Me, Nothing)

        End If

    End Sub

    Private Sub tbUlaznaNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUlaznaNalepnica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrelaz_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DatumIzlaza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumIzlaza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub btnTranzitIzlaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTranzitIzlaz.Click
        Me.Dispose()

        Dim form2c As New FormCim
        IzborSaobracaja = "4"
        TipTranzita = "izlaz"
        bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
        form2c.Text = "::: Tranzit IZLAZ :::"
        form2c.ShowDialog()
    End Sub

    Private Sub cbPrelaz_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbPrelaz.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnUpis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpis.Click
        'msBrojVoza2 u BrojVoza2
        '--------------------------------------
        '***
        Dim slogTrans As SqlTransaction
        Dim rv As String
        Dim _izl_control As String = "D"

        '----------------------- Kontrola izlazne nalepnice ----------------------------
        If tbIzlaznaNalepnica.Text = Nothing Then
            _izl_control = "N"
        Else
            If IsNumeric(tbIzlaznaNalepnica.Text) Then
                If CType(tbIzlaznaNalepnica.Text, Int32) = 0 Then
                    _izl_control = "N"
                Else
                    If TipTranzita = "izlaz" Then
                        Dim xNaziv As String = ""
                        Dim xPovVrednost As String = ""

                        Util.sNadjiIzlaznuNalepnicu(tbIzlaznaNalepnica.Text, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mObrGodina, mObrMesec, xNaziv, xPovVrednost)

                        If xPovVrednost <> "" Then
                            _izl_control = "D"
                        Else
                            _izl_control = "P"
                        End If

                        If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And CInt(tbIzlaznaNalepnica.Text) > 65001 And CInt(tbIzlaznaNalepnica.Text) <= 72000 Then

                            _izl_control = "D"

                        End If

                    End If
                End If
            Else
                _izl_control = "N"
            End If
        End If

        '----------------------- Kontrola ulazne nalepnice ----------------------------
        If _ul_control = "N" Then
            _izl_control = "U"
        End If

        If _izl_control = "D" Then

            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If
            slogTrans = DbVeza.BeginTransaction()

            Try


                Upis.UpdateTrz(slogTrans, "Upd", Val(Label12.Text), Microsoft.VisualBasic.Mid(cbPrelaz.Text, 5, 5), _
                               Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), Val(tbIzlaznaNalepnica.Text), DatumIzlaza.Text, tbBrojVoza.Text, tbSat.Text, _
                               tbKomBroj.Text, rv)

                If rv = "" Then
                    slogTrans.Commit()

                    '----- Azuriranje tranzitnih nalepnica ----------------------------------------
                    If DbVeza.State = ConnectionState.Closed Then
                        DbVeza.Open()
                    End If

                    slogTrans = DbVeza.BeginTransaction()
                    Try
                        Dim ulTrzNalepnica As Int32
                        Dim izTrzNalepnica As Int32
                        Dim _Stanica As String

                        rv = ""

                        Upis.UpisTrzNalepnice(slogTrans, "Upd", Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), 0, Val(tbIzlaznaNalepnica.Text), rv)

                        If rv = "" Then
                            slogTrans.Commit()
                            mIzEtiketa = mIzEtiketa + 1
                        Else
                            MsgBox(rv)
                            slogTrans.Rollback()
                        End If
                    Catch ex As Exception
                        rv = ex.Message
                        Cursor.Current = System.Windows.Forms.Cursors.Default
                        MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Catch sqlex As SqlException
                        MsgBox(sqlex.Message)
                    Finally
                        DbVeza.Close()
                    End Try

                    'End If
                    '---------------------------- END azuriranje tranzitnih nalepnica --------------------------------

                    ''Dim Msg As String
                    ''Dim Ans As MsgBoxResult
                    ''Msg = "Podaci su upisani u bazu! " & Chr(13)
                    ''Msg = Msg & " " & Chr(13)
                    ''Msg = Msg & "Da li nastavljate unos sledece izlazne posiljke?" & Chr(13)

                    ''Ans = MsgBox(Msg, vbYesNo + vbInformation, "Akcija")
                    ''If Ans = vbNo Then
                    ''    Me.tbUlaznaNalepnica.Text = "0"
                    ''    Me.cbPrelaz.SelectedIndex = -1
                    ''    Me.tbIzlaznaNalepnica.Text = "0"
                    ''    Me.tbSat.Text = "00"
                    ''    Me.tbBrojVoza.Text = " "
                    ''    Me.tbKomBroj.Text = " "

                    ''    Close()
                    ''Else
                    ''    Me.tbUlaznaNalepnica.Text = "0"
                    ''    Me.TextBox1.Text = ""
                    ''    Me.TextBox2.Text = ""
                    ''    Me.TextBox3.Text = ""
                    ''    Me.TextBox4.Text = ""
                    ''    Me.fxIBK.Text = ""

                    ''    Me.tbIzlaznaNalepnica.Text = Me.tbIzlaznaNalepnica.Text + 1
                    ''    Me.tbUlaznaNalepnica.Focus()
                    ''End If

                    Me.tbUlaznaNalepnica.Text = "0"
                    Me.tbIzlaznaNalepnica.Text = Me.tbIzlaznaNalepnica.Text + 1
                    Me.tbUlaznaNalepnica.Focus()
                Else
                    MsgBox(rv)
                    slogTrans.Rollback()
                End If
            Catch ex As Exception
                rv = ex.Message
                MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch sqlex As SqlException
                MsgBox(sqlex.Message)
            Finally
                DbVeza.Close()
            End Try

        ElseIf _izl_control = "P" Then
            MessageBox.Show("Nalepnica sa tim brojem je uneta!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf _izl_control = "N" Then
            MessageBox.Show("Neispravan broj nalepnice!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf _izl_control = "U" Then
            MessageBox.Show("Za ovaj dokument izlazna tranzitna nalepnica je vec uneta!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub tbBrojVoza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbKomBroj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbKomBroj.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnUpis_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.GotFocus
        Me.btnUpis.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnUpis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.Leave
        Me.btnUpis.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub tbSat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSat.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TrzIzlaz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.GroupBox7.BackColor = System.Drawing.SystemColors.Control
        mObrMesec = Today.Month
        mObrGodina = Today.Year
        Me.NumericUpDown1.Text = Today.Year.ToString

        'mIzEtiketa = 0
        ''-----------------
        'If DbVeza.State = ConnectionState.Closed Then
        '    DbVeza.Open()
        'End If

        'Dim sql_text As String = "SELECT IzlaznaNalepnica " & _
        '                         "FROM dbo.ZsTrzNalepnice " & _
        '                         "WHERE (dbo.ZsTrzNalepnice.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

        'Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        'Dim rdrTrz As SqlClient.SqlDataReader

        'rdrTrz = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        'Do While rdrTrz.Read()
        '    mIzEtiketa = rdrTrz.GetInt32(0) + 1
        'Loop
        'rdrTrz.Close()
        'DbVeza.Close()

    End Sub

    Private Sub cbPrelaz_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPrelaz.Leave
        If cbPrelaz.Text = Nothing Then
            cbPrelaz.Focus()
        End If
    End Sub

    Private Sub tbIzlaznaNalepnica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbIzlaznaNalepnica.Validating

        If tbIzlaznaNalepnica.Text = Nothing Then
            ErrorProvider1.SetError(tbIzlaznaNalepnica, "Unesite broj tranzitne nalepnice")
            tbIzlaznaNalepnica.Focus()
        Else
            If IsNumeric(tbIzlaznaNalepnica.Text) Then
                If CType(tbIzlaznaNalepnica.Text, Int32) = 0 Then
                    ErrorProvider1.SetError(tbIzlaznaNalepnica, "Neispravan broj tranzitne nalepnice!")
                    tbIzlaznaNalepnica.Focus()
                Else
                    If TipTranzita = "izlaz" Then
                        Dim xNaziv As String = ""
                        Dim xPovVrednost As String = ""

                        Util.sNadjiIzlaznuNalepnicu(tbIzlaznaNalepnica.Text, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mObrGodina, mObrMesec, xNaziv, xPovVrednost)

                        If xPovVrednost <> "" Then
                            ErrorProvider1.SetError(tbIzlaznaNalepnica, "")
                        Else
                            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And (CInt(tbIzlaznaNalepnica.Text) > 65001 And CInt(tbIzlaznaNalepnica.Text) <= 72000) Then

                                '===============
                                Dim Msg As String
                                Dim Ans As MsgBoxResult
                                Msg = "Za stanicu Subotica Granica odobreno je korišcenje sledecih izlaznih tranzitnih markica koje su vec upotrebljene:" & Chr(13)
                                Msg = Msg & " " & Chr(13)
                                Msg = Msg & " nalepnice bele boje od broja 65001 - 72000" & Chr(13)
                                Msg = Msg & " " & Chr(13)
                                Msg = Msg & "[ Ako ste uneli pogrešan broj tranzitne nalepnice ponovite unos. ]" & Chr(13)
                                Msg = Msg & " " & Chr(13)
                                Ans = MsgBox(Msg, MsgBoxStyle.Information, "Poruka iz baze")
                                '===============
                                'Msg = Msg & "2. nalepnice bele boje sa žutom crtom od broja 40001 - 47000" & Chr(13)

                            Else
                                ErrorProvider1.SetError(tbIzlaznaNalepnica, "Nalepnica sa tim brojem je uneta!")
                                tbIzlaznaNalepnica.Focus()
                            End If
                        End If
                    End If
                End If
            Else
                ErrorProvider1.SetError(tbIzlaznaNalepnica, "Neispravan broj tranzitne nalepnice!")
                tbIzlaznaNalepnica.Focus()
            End If
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If tbIzlaznaNalepnica.Text = Nothing Then
            ErrorProvider1.SetError(tbIzlaznaNalepnica, "Unesite broj tranzitne nalepnice")
            tbIzlaznaNalepnica.Focus()
        Else
            If IsNumeric(tbIzlaznaNalepnica.Text) Then
                If CType(tbIzlaznaNalepnica.Text, Int32) = 0 Then
                    ErrorProvider1.SetError(tbIzlaznaNalepnica, "Neispravan broj tranzitne nalepnice!")
                    tbIzlaznaNalepnica.Focus()
                Else
                    If TipTranzita = "izlaz" Then
                        Dim xNaziv As String = ""
                        Dim xPovVrednost As String = ""

                        Util.sNadjiIzlaznuNalepnicu(tbIzlaznaNalepnica.Text, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mObrGodina, mObrMesec, xNaziv, xPovVrednost)

                        If xPovVrednost <> "" Then
                            ErrorProvider1.SetError(tbIzlaznaNalepnica, "")
                        Else
                            ErrorProvider1.SetError(tbIzlaznaNalepnica, "Nalepnica sa tim brojem je uneta!")
                            tbIzlaznaNalepnica.Focus()
                        End If
                    End If
                End If
            Else
                ErrorProvider1.SetError(tbIzlaznaNalepnica, "Neispravan broj tranzitne nalepnice!")
                tbIzlaznaNalepnica.Focus()
            End If
        End If


    End Sub

    Private Sub tbBrojVoza_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojVoza.Validating
        If tbBrojVoza.Text = "0" Then
            ErrorProvider1.SetError(tbBrojVoza, "Broj voza moze da bude nula!")
            tbBrojVoza.Focus()
        Else
            If tbBrojVoza.Text = Nothing Then
                ErrorProvider1.SetError(tbBrojVoza, "Neispravan broj voza!")
                tbBrojVoza.Focus()
            Else
                If IsNumeric(tbBrojVoza.Text) = True Then
                    ErrorProvider1.SetError(tbBrojVoza, "")
                Else
                    ErrorProvider1.SetError(tbBrojVoza, "Neispravan broj voza!")
                    tbBrojVoza.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub tbSat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbSat.Validating
        If tbSat.Text = Nothing Then
            ErrorProvider1.SetError(tbSat, "Unesite sat voza!")
            tbSat.Focus()
        Else
            ErrorProvider1.SetError(tbSat, "")
        End If
    End Sub

    Private Sub tbUlaznaNalepnica_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUlaznaNalepnica.Leave
        If Me.tbUlaznaNalepnica.Text = Nothing Then
            Me.tbUlaznaNalepnica.Focus()
        Else
            If CType(Me.tbUlaznaNalepnica.Text, Int32) = 0 Then
                Me.tbUlaznaNalepnica.Focus()
            End If
        End If
    End Sub
End Class
