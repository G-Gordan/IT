Imports System
Imports System.Globalization
Imports System.Threading
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class UpdateForm
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DatumOtpUpd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents gbOstalo As System.Windows.Forms.GroupBox
    Friend WithEvents gbPosiljka As System.Windows.Forms.GroupBox
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnPreuzmi As System.Windows.Forms.Button
    Friend WithEvents cbRucnaNajava As System.Windows.Forms.CheckBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents LblKomitent As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents gbTarifa As System.Windows.Forms.GroupBox
    Friend WithEvents cb22 As System.Windows.Forms.CheckBox
    Friend WithEvents rbP As System.Windows.Forms.RadioButton
    Friend WithEvents rbG As System.Windows.Forms.RadioButton
    Friend WithEvents rbV As System.Windows.Forms.RadioButton
    Friend WithEvents gbVrP As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbProdos As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbCORO As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UpdateForm))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.DatumOtpUpd = New System.Windows.Forms.DateTimePicker
        Me.gbOstalo = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.cbRucnaNajava = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbPosiljka = New System.Windows.Forms.GroupBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.btnPreuzmi = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.LblKomitent = New System.Windows.Forms.Label
        Me.gbTarifa = New System.Windows.Forms.GroupBox
        Me.cbCORO = New System.Windows.Forms.CheckBox
        Me.gbVrP = New System.Windows.Forms.GroupBox
        Me.rbV = New System.Windows.Forms.RadioButton
        Me.rbG = New System.Windows.Forms.RadioButton
        Me.rbP = New System.Windows.Forms.RadioButton
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cb22 = New System.Windows.Forms.CheckBox
        Me.gbProdos = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.Label14 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.gbOstalo.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbPosiljka.SuspendLayout()
        Me.gbTarifa.SuspendLayout()
        Me.gbVrP.SuspendLayout()
        Me.gbProdos.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(168, 28)
        Me.TextBox1.MaxLength = 4
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 23)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "0072"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 22)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Operater"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Stanica"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 18)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Broj"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 18)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Datum"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(168, 72)
        Me.TextBox2.MaxLength = 7
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(128, 22)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = ""
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(168, 112)
        Me.TextBox3.MaxLength = 6
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(128, 22)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = ""
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(392, 536)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 4
        Me.btnPrihvati.Text = "Prihvati  "
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(520, 536)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 6
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(40, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'DatumOtpUpd
        '
        Me.DatumOtpUpd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOtpUpd.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOtpUpd.Location = New System.Drawing.Point(168, 152)
        Me.DatumOtpUpd.Name = "DatumOtpUpd"
        Me.DatumOtpUpd.Size = New System.Drawing.Size(128, 22)
        Me.DatumOtpUpd.TabIndex = 4
        '
        'gbOstalo
        '
        Me.gbOstalo.Controls.Add(Me.TextBox1)
        Me.gbOstalo.Controls.Add(Me.Label5)
        Me.gbOstalo.Controls.Add(Me.Label4)
        Me.gbOstalo.Controls.Add(Me.Label3)
        Me.gbOstalo.Controls.Add(Me.Label2)
        Me.gbOstalo.Controls.Add(Me.DatumOtpUpd)
        Me.gbOstalo.Controls.Add(Me.TextBox3)
        Me.gbOstalo.Controls.Add(Me.TextBox2)
        Me.gbOstalo.Controls.Add(Me.Label17)
        Me.gbOstalo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOstalo.Location = New System.Drawing.Point(272, 32)
        Me.gbOstalo.Name = "gbOstalo"
        Me.gbOstalo.Size = New System.Drawing.Size(336, 208)
        Me.gbOstalo.TabIndex = 3
        Me.gbOstalo.TabStop = False
        Me.gbOstalo.Text = " [ Otpravljanje ] "
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(168, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(128, 16)
        Me.Label17.TabIndex = 1
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(96, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 24)
        Me.Label7.TabIndex = 15
        Me.Label7.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Controls.Add(Me.ComboBox2)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(24, 32)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Posiljka "
        Me.GroupBox3.Visible = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Vrsta"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(144, 59)
        Me.TextBox4.MaxLength = 10
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(208, 22)
        Me.TextBox4.TabIndex = 1
        Me.TextBox4.Text = ""
        Me.TextBox4.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox2.Items.AddRange(New Object() {"1 - Pojedinacna posiljka", "2 - Grupa kola", "3 - Marsrutni voz"})
        Me.ComboBox2.Location = New System.Drawing.Point(144, 24)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(208, 24)
        Me.ComboBox2.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Broj grupe/voza"
        Me.Label8.Visible = False
        '
        'tbUgovor
        '
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(17, 72)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(112, 23)
        Me.tbUgovor.TabIndex = 14
        Me.tbUgovor.Text = ""
        '
        'cbRucnaNajava
        '
        Me.cbRucnaNajava.Enabled = False
        Me.cbRucnaNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRucnaNajava.Location = New System.Drawing.Point(137, 84)
        Me.cbRucnaNajava.Name = "cbRucnaNajava"
        Me.cbRucnaNajava.Size = New System.Drawing.Size(160, 24)
        Me.cbRucnaNajava.TabIndex = 15
        Me.cbRucnaNajava.Text = "Najava nije uneta u bazu"
        Me.cbRucnaNajava.Visible = False
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(56, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 24)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Broj ugovora"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 32)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "inOtpravljanje-outReciD"
        Me.Label1.Visible = False
        '
        'gbPosiljka
        '
        Me.gbPosiljka.Controls.Add(Me.TextBox7)
        Me.gbPosiljka.Controls.Add(Me.TextBox5)
        Me.gbPosiljka.Controls.Add(Me.RadioButton3)
        Me.gbPosiljka.Controls.Add(Me.RadioButton2)
        Me.gbPosiljka.Controls.Add(Me.RadioButton1)
        Me.gbPosiljka.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPosiljka.Location = New System.Drawing.Point(96, 584)
        Me.gbPosiljka.Name = "gbPosiljka"
        Me.gbPosiljka.Size = New System.Drawing.Size(72, 24)
        Me.gbPosiljka.TabIndex = 1
        Me.gbPosiljka.TabStop = False
        Me.gbPosiljka.Text = "[ Vrsta posiljke ]"
        Me.gbPosiljka.Visible = False
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(120, 111)
        Me.TextBox7.MaxLength = 10
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(104, 22)
        Me.TextBox7.TabIndex = 4
        Me.TextBox7.Text = ""
        Me.TextBox7.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(120, 74)
        Me.TextBox5.MaxLength = 10
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(104, 22)
        Me.TextBox5.TabIndex = 2
        Me.TextBox5.Text = ""
        Me.TextBox5.Visible = False
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(16, 111)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.Text = "Voz"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(16, 74)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Grupa kola "
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(16, 38)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Pojedinacna "
        '
        'btnPreuzmi
        '
        Me.btnPreuzmi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPreuzmi.Image = CType(resources.GetObject("btnPreuzmi.Image"), System.Drawing.Image)
        Me.btnPreuzmi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPreuzmi.Location = New System.Drawing.Point(408, 536)
        Me.btnPreuzmi.Name = "btnPreuzmi"
        Me.btnPreuzmi.Size = New System.Drawing.Size(88, 64)
        Me.btnPreuzmi.TabIndex = 5
        Me.btnPreuzmi.Text = "Preuzmi"
        Me.btnPreuzmi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'LblKomitent
        '
        Me.LblKomitent.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblKomitent.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.LblKomitent.Location = New System.Drawing.Point(24, 480)
        Me.LblKomitent.Name = "LblKomitent"
        Me.LblKomitent.Size = New System.Drawing.Size(584, 32)
        Me.LblKomitent.TabIndex = 17
        Me.LblKomitent.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'gbTarifa
        '
        Me.gbTarifa.Controls.Add(Me.cbCORO)
        Me.gbTarifa.Controls.Add(Me.gbVrP)
        Me.gbTarifa.Controls.Add(Me.ComboBox1)
        Me.gbTarifa.Controls.Add(Me.cbRucnaNajava)
        Me.gbTarifa.Controls.Add(Me.tbUgovor)
        Me.gbTarifa.Controls.Add(Me.Label13)
        Me.gbTarifa.Controls.Add(Me.Label10)
        Me.gbTarifa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTarifa.Location = New System.Drawing.Point(272, 248)
        Me.gbTarifa.Name = "gbTarifa"
        Me.gbTarifa.Size = New System.Drawing.Size(336, 208)
        Me.gbTarifa.TabIndex = 18
        Me.gbTarifa.TabStop = False
        Me.gbTarifa.Text = " [ T a r i f a ] "
        Me.gbTarifa.Visible = False
        '
        'cbCORO
        '
        Me.cbCORO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbCORO.Enabled = False
        Me.cbCORO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCORO.ForeColor = System.Drawing.Color.Red
        Me.cbCORO.Location = New System.Drawing.Point(138, 64)
        Me.cbCORO.Name = "cbCORO"
        Me.cbCORO.Size = New System.Drawing.Size(166, 24)
        Me.cbCORO.TabIndex = 17
        Me.cbCORO.Text = "Centralni obracun"
        Me.cbCORO.Visible = False
        '
        'gbVrP
        '
        Me.gbVrP.Controls.Add(Me.rbV)
        Me.gbVrP.Controls.Add(Me.rbG)
        Me.gbVrP.Controls.Add(Me.rbP)
        Me.gbVrP.Location = New System.Drawing.Point(0, 112)
        Me.gbVrP.Name = "gbVrP"
        Me.gbVrP.Size = New System.Drawing.Size(336, 96)
        Me.gbVrP.TabIndex = 16
        Me.gbVrP.TabStop = False
        Me.gbVrP.Text = " [ Vrsta posiljke ] "
        Me.gbVrP.Visible = False
        '
        'rbV
        '
        Me.rbV.Location = New System.Drawing.Point(24, 66)
        Me.rbV.Name = "rbV"
        Me.rbV.Size = New System.Drawing.Size(160, 24)
        Me.rbV.TabIndex = 4
        Me.rbV.Text = "Marsrutni voz"
        '
        'rbG
        '
        Me.rbG.Location = New System.Drawing.Point(24, 43)
        Me.rbG.Name = "rbG"
        Me.rbG.TabIndex = 3
        Me.rbG.Text = "Grupa kola"
        '
        'rbP
        '
        Me.rbP.Checked = True
        Me.rbP.Location = New System.Drawing.Point(24, 19)
        Me.rbP.Name = "rbP"
        Me.rbP.Size = New System.Drawing.Size(160, 24)
        Me.rbP.TabIndex = 2
        Me.rbP.TabStop = True
        Me.rbP.Text = "Pojedinacna posiljka"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"1. Spt 38", "2. Tea 9291", "3. Ugovor"})
        Me.ComboBox1.Location = New System.Drawing.Point(16, 27)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(280, 24)
        Me.ComboBox1.TabIndex = 11
        Me.ComboBox1.Visible = False
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(200, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 18)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Izaberite tarifu"
        Me.Label13.Visible = False
        '
        'cb22
        '
        Me.cb22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb22.Location = New System.Drawing.Point(96, 552)
        Me.cb22.Name = "cb22"
        Me.cb22.Size = New System.Drawing.Size(16, 32)
        Me.cb22.TabIndex = 16
        Me.cb22.Text = "Pojedinacna posiljka"
        Me.cb22.Visible = False
        '
        'gbProdos
        '
        Me.gbProdos.Controls.Add(Me.Label15)
        Me.gbProdos.Controls.Add(Me.NumericUpDown2)
        Me.gbProdos.Controls.Add(Me.Label14)
        Me.gbProdos.Controls.Add(Me.NumericUpDown1)
        Me.gbProdos.ForeColor = System.Drawing.Color.Red
        Me.gbProdos.Location = New System.Drawing.Point(8, 520)
        Me.gbProdos.Name = "gbProdos"
        Me.gbProdos.Size = New System.Drawing.Size(296, 88)
        Me.gbProdos.TabIndex = 19
        Me.gbProdos.TabStop = False
        Me.gbProdos.Text = " [ UNOS VAN REDOVNOG RACUNSKOG MESECA ]"
        Me.gbProdos.Visible = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(190, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Godina"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown2.Location = New System.Drawing.Point(144, 35)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {2006, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(96, 22)
        Me.NumericUpDown2.TabIndex = 3
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown2.Value = New Decimal(New Integer() {2008, 0, 0, 0})
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(55, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 16)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Mesec"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(8, 35)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(96, 22)
        Me.NumericUpDown1.TabIndex = 1
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown1.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(328, 536)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 64)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.TextBox8)
        Me.GroupBox1.Controls.Add(Me.TextBox9)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(768, 416)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(240, 208)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Prispeæe] "
        Me.GroupBox1.Visible = False
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(112, 28)
        Me.TextBox6.MaxLength = 4
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(112, 23)
        Me.TextBox6.TabIndex = 0
        Me.TextBox6.Text = ""
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 18)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Datum"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 18)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Broj"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 14)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Stanica"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(18, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 22)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Operater"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker1.Location = New System.Drawing.Point(112, 152)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(112, 22)
        Me.DateTimePicker1.TabIndex = 3
        Me.DateTimePicker1.Value = New Date(2011, 9, 1, 11, 31, 58, 378)
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(112, 112)
        Me.TextBox8.MaxLength = 6
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(112, 22)
        Me.TextBox8.TabIndex = 2
        Me.TextBox8.Text = ""
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(112, 72)
        Me.TextBox9.MaxLength = 7
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(112, 22)
        Me.TextBox9.TabIndex = 1
        Me.TextBox9.Text = ""
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(112, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 16)
        Me.Label18.TabIndex = 7
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DimGray
        Me.Label19.Location = New System.Drawing.Point(32, 120)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(200, 104)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Izmena podataka u tovarnom listu"
        '
        'UpdateForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(626, 612)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gbProdos)
        Me.Controls.Add(Me.gbTarifa)
        Me.Controls.Add(Me.LblKomitent)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.gbPosiljka)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbOstalo)
        Me.Controls.Add(Me.btnPreuzmi)
        Me.Controls.Add(Me.cb22)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Izmena unetih podataka"
        Me.gbOstalo.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.gbPosiljka.ResumeLayout(False)
        Me.gbTarifa.ResumeLayout(False)
        Me.gbVrP.ResumeLayout(False)
        Me.gbProdos.ResumeLayout(False)
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click

        If CarinskiAgent = "PROODOS" Then
            mObrMesec = Me.NumericUpDown1.Text
            mObrGodina = Me.NumericUpDown2.Text
        Else

        End If
        mObrGodina = mObrGodina

        If RecordAction = "N" Then   ' 1. ================== Azuriranje u OkpWinRoba ==========================

            MasterAction = "Upd"

            Dim izPrUprava As String
            Dim izPrStanica As String
            Dim izPrDatum As Date
            Dim izSaobracaj As String
            Dim izZsUlPrelaz As String
            Dim izZsIzPrelaz As String
            Dim izNalepnica As Int32
            Dim izNajava As String = "0"
            Dim izNajava2 As String = "0"
            Dim izSifraTarife As String
            Dim izUgovor As String
            Dim mDatum As Date
            Dim mRetVal As String
            Dim mRecID As Int32
            Dim mStanicaRecID As String
            Dim izZsPrelaz As String



            If IzborSaobracaja = "1" Then
              

                Label5.Enabled = False
                Me.DatumOtpUpd.Enabled = True


                Dim nm_LomStanica As String
                'Dim updbTkm As Int32 = 0

                ''Dim x_mPrDatum As Date

                Dim updPrevFr, updPrevUp, updNakFr, updNakUp, updBlagFr, updBlagUp, updTlDinFr, updTlDinUp, _
                    updBlagFrDin, updBlagUpDin, updBlagK115Din, updRazlikaFrDin, updRazlikaUpDin As Decimal

                mOtpUprava = TextBox1.Text
                mOtpStanica = TextBox2.Text
                mOtpBroj = TextBox3.Text

                mOtpDatum = Me.DatumOtpUpd.Value.ToShortDateString
                mMesec = mOtpDatum.Month.ToString
                mDan = mOtpDatum.Day.ToString
                mGodina = mOtpDatum.Year.ToString

            
                '==========================
                Button1_Click(Me, Nothing)
                '==========================
                Label5.Enabled = True
                DatumOtpUpd.Enabled = True
                DatumOtpUpd.Value = mOtpDatum
                '============================

                bGreska = 0
                NadjiTovarniList(mOtpUprava, mOtpStanica, mOtpBroj, bDatumOtpIzSloga, _
                                 mRecID, mStanicaRecID, izPrUprava, izPrStanica, _
                                 mPrBroj, mPrDatum, updbTkm, bPrevozniPutZS, bStanicaVia, IzborSaobracaja, bVrstaSaobracaja, izZsUlPrelaz, izZsIzPrelaz, izNajava, _
                                 nm_LomStanica, mSifraIzjave, bIznosPoIzjavi, upis_mFrNaknade, mDoPrelaza, mIncoterms, _
                                 izSifraTarife, bTarifa72, izUgovor, mPosiljalac, mPrimalac, mVrstaPrevoza, bValuta, updPrevFr, updPrevUp, updNakFr, updNakUp, _
                                 updBlagFr, updBlagUp, updTlDinFr, updTlDinUp, updBlagFrDin, updBlagUpDin, _
                                 updBlagK115Din, updRazlikaFrDin, updRazlikaUpDin, bbPredujam, bNarocitaPosiljkaChar, _
                                 mRetVal)
                ' ovde se popunjavaju i svi ostali gridovi
                If mRetVal <> "" Then
                    bGreska = 1
                End If

                If Microsoft.VisualBasic.Left(bNarocitaPosiljkaChar, 4) = "True" Then
                    bNarocitaPosiljka = True
                End If


                Dim updSumaFr As Decimal = 0
                Dim updSumaUp As Decimal = 0

                If mVrstaObracuna = "CO" Then

                    bKorigujCO72(mrecid, updPrevFr, updPrevUp, updSumaFr, updSumaUp, mRetVal)

                End If

                mOtpDatum = bDatumOtpIzSloga

                bPrevozninaLevo = updPrevFr
                bPrevozninaDesno = updPrevUp

                If mSifraIzjave = 0 Then
                    mPrevoznina = bPrevozninaDesno
                Else
                    mPrevoznina = bPrevozninaLevo
                End If

                If mVrstaObracuna = "CO" Then
                    bSumaLevo = updSumaFr
                    bSumaDesno = updSumaUp
                Else
                    bSumaLevo = updTlDinFr
                    bSumaDesno = updTlDinUp
                End If



                bBlagFranko = updBlagFrDin
                bBlagUpuceno = updBlagUpDin
                bRazlikaFr = updRazlikaFrDin
                bRazlikaUp = updRazlikaUpDin

                UpdRecID = mrecid
                UpdStanicaRecID = mStanicaRecID
                UpdUprava = mOtpUprava
                UpdStanica = mOtpStanica
                UpdBroj = mOtpBroj
                UpdDatum = mOtpDatum

                'zbog kontrole duplih prispeca
                UpdStanicaPr = izPrStanica
                UpdBrojPr = mPrBroj
                mPrispece = mPrBroj '**

                'end

                mPrUprava = izPrUprava
                mPrStanica = izPrStanica
                'IzborSaobracaja = izSaobracaj
                mNajava = izNajava
                mTarifa = izSifraTarife
                mBrojUg = izUgovor
                bTkm = updbTkm

                Dim bbRetVal As String = ""
                'NadjiManipulativnoMesto(mrecid, mManipulativnoMesto1, mManipulativnoMesto2, mretval)
                NadjiManipulativnoMesto(mrecid, mManipulativnoMesto1, mManipulativnoMesto2, bbRetVal)
                mManipulativnoMesto1 = Microsoft.VisualBasic.Mid(mManipulativnoMesto1, 3, 38)
                mManipulativnoMesto2 = Microsoft.VisualBasic.Mid(mManipulativnoMesto2, 3, 38)

                bManipulativnoMesto1IzSloga = mManipulativnoMesto1
                bManipulativnoMesto2IzSloga = mManipulativnoMesto2

                bNadjiPDVIzSloga(mrecid, bPDV1IzSloga, bPDV2IzSloga, mretval)


                If bPDV1IzSloga = 0 And bPDV2IzSloga = 0 Then
                    ImaPDV = False
                Else
                    ImaPDV = True
                End If



                tmp_pdv_f = bPDV1IzSloga
                tmp_pdv_u = bPDV2IzSloga

                bNadjiObrMesecIzSlogaKalk(mrecid, bObrMesecIzSlogaKalk, bObrGodinaIzSlogaKalk, mretval)

                '23/9/2013
                If ((bObrMesecIzSlogaKalk = "1 " Or bObrMesecIzSlogaKalk = "2 ") And bObrGodinaIzSlogaKalk = "2013") Then
                    MessageBox.Show("Ovom verzijom programa se ne moze obradjivati materijal iz trazenog obracunskog meseca! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    bGreska = bGreska + 1
                End If

                If IzborSaobracaja = "2" Then
                    If (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then       '0206
                        mPrevoznina = updPrevFr
                        mSumaNak = updNakFr
                    Else
                        mPrevoznina = updPrevUp
                        mSumaNak = updNakUp
                    End If

                    mTL_upuceno = updBlagUp
                    mSumaDinari = updTlDinUp
                    mBlagajna = updBlagUpDin
                    mRazlika = updRazlikaUpDin

                ElseIf IzborSaobracaja = "3" Then
                    If (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then       '0206
                        mPrevoznina = updPrevUp
                        mSumaNak = updNakUp
                    Else
                        mPrevoznina = updPrevFr
                        mSumaNak = updNakFr
                    End If

                    mTL_franko = updBlagFr
                    mSumaDinari = updTlDinFr
                    mBlagajna = updBlagFrDin
                    mRazlika = updRazlikaFrDin
                End If
            End If

            If mRetVal = "" Then
                '--------------- prikaz tarife ----------------
                gbTarifa.Visible = True
                tbUgovor.Text = mBrojUg
                If IzborSaobracaja = "4" Then
                    Me.Label13.Visible = False 'True    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>False
                    Me.ComboBox1.Visible = False 'True  '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>False
                    tbUgovor.Focus()
                Else
                    Me.Label13.Visible = True
                    Me.ComboBox1.Visible = True
                    '------------------------------------------------------------------------------------------
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
                    '------------------------------------------------------------------------------------------
                    Me.ComboBox1.Focus()
                End If

                If IzborSaobracaja = "4" Then
                    tbUgovor.SelectionStart = 4
                Else
                    Me.Label13.Visible = True
                    Me.ComboBox1.Visible = True

                    If mTarifa = "00" Then
                        Me.ComboBox1.SelectedIndex = 0
                    ElseIf mTarifa = "36" Then
                        Me.ComboBox1.SelectedIndex = 1
                    Else
                        Me.ComboBox1.SelectedIndex = -1
                    End If
                    Me.ComboBox1.Focus()
                End If
                '-----------------------------------------------
                Me.btnPrihvati.Visible = False
                Me.btnPreuzmi.Visible = True
            Else
                MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        ElseIf RecordAction = "D" Then ' 2. =================== Brisanje u OkpWinRoba ========================

            MasterAction = "Del"

            Dim izPrUprava As String
            Dim izPrStanica As String
            Dim izPrDatum As Date
            Dim izSaobracaj As String
            Dim izZsUlPrelaz As String
            Dim izZsIzPrelaz As String
            Dim izNalepnica As Int32
            Dim izNajava As String
            Dim izNajava2 As String
            Dim izSifraTarife As String
            Dim izUgovor As String
            Dim mDatum As Date
            Dim mRetVal As String
            Dim mRecID As Int32
            Dim mStanicaRecID As String

            Dim nmObrMesec As String = ""
            Dim nmObrGodina As String = ""
            Dim nmGreskaDel As Boolean = False
            If IzborSaobracaja = "1" Then

                Dim nm_LomStanica As String


                mOtpUprava = TextBox1.Text
                mOtpStanica = TextBox2.Text
                mOtpBroj = TextBox3.Text

                mOtpDatum = Me.DatumOtpUpd.Value.ToShortDateString
                mMesec = mOtpDatum.Month.ToString
                mDan = mOtpDatum.Day.ToString
                mGodina = mOtpDatum.Year.ToString

                mRecID = 0
                mStanicaRecID = ""
                bbNadjiTovarniListLokalDel("72" & mOtpStanica, mOtpBroj, mRecID, mStanicaRecID, nmObrMesec, nmObrGodina, mRetVal)

                UpdRecID = mRecID
                UpdStanicaRecID = mStanicaRecID

            End If

            If mRetVal = "" And mStanicaRecID = "00005" And (bGreska = 0) Then
                'nmGreskaDel = False                                     '************************** 20.01.2017, pa vraæeno
                If CInt(nmObrGodina) = CInt(bPregledObrGodina) Then
                    If CInt(nmObrMesec) = CInt(bPregledObrMesec) Then
                        nmGreskaDel = False
                    Else
                        nmGreskaDel = True
                    End If
                Else
                    nmGreskaDel = True
                End If

                If nmGreskaDel = False Then
                    Dim Msg As String
                    Dim Ans As MsgBoxResult

                    Msg = "Izabrani tovarni list ce biti izbrisan iz baze podataka! " & Chr(13)
                    Msg = Msg & "Da li ste sigurni?"

                    Ans = MsgBox(Msg, vbYesNo + vbInformation, "Brisanje podataka!")
                    If Ans = vbNo Then
                        Close()
                    Else
                        Dim bRetValInt As Int32 = 0

                        If IzborSaobracaja = "1" Then
                            bbBrisiTLLokal(mRecID, mStanicaRecID, bRetValInt)
                        End If

                        If bRetValInt > 0 Then
                            MessageBox.Show("Izabrani tovarni list je izbrisan iz baze podataka", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Izabrani tovarni list nije izbrisan. Obratite se administratoru.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        Close()
                    End If
                Else
                    MessageBox.Show("Nije dozvoljeno brisanje ovog tovarnog lista! Obratite se administratoru.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Close()
                End If

            Else
                MessageBox.Show("Nepostojeci podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        ElseIf RecordAction = "P" Then  ' 3. ==================== Preuzimanje iz WinRoba ========================
            ''Dim temp_mObrGodina As String
            MasterAction = "New"
            Label19.Text = "Preuzimanje tovarnog lista sa stanice"
            Dim mDatum As Date
            Dim mRetVal As String
            Dim mRecID As Int32
            Dim mStanicaRecID As String

            If IzborSaobracaja = "1" Then ' -------------------------- U T L ----------------------
                Dim otUprava As String
                Dim otStanica As String
                Dim otBroj As Int32
                Dim otDatum As Date

                mOtpUprava = TextBox1.Text
                mOtpStanica = TextBox2.Text
                mOtpBroj = TextBox3.Text
                mOtpDatum = Me.DatumOtpUpd.Value.ToShortDateString
                mMesec = mOtpDatum.Month.ToString
                mDan = mOtpDatum.Day.ToString
                mGodina = mOtpDatum.Year.ToString

                eNadjiTovarniListUTLWR(mOtpUprava, "72" & mOtpStanica, mOtpBroj, mOtpDatum, _
                                   mRecID, mStanicaRecID, mPrStanica, mPrBroj, mPrDatum, _
                                   mTarifa, bTarifa72, mBrojUg, mVrstaPrevoza, _
                                   mRetVal)

                Label5.Enabled = True
                Me.DatumOtpUpd.Enabled = True




                mOtpUprava = TextBox1.Text
                mOtpStanica = TextBox2.Text
                mOtpBroj = TextBox3.Text

                ' START novo 28.4: tlgrid
                '''mOtpDatum = Me.DatumOtpUpd.Value.ToShortDateString
                '''mMesec = mOtpDatum.Month.ToString
                '''mDan = mOtpDatum.Day.ToString
                '''mGodina = mOtpDatum.Year.ToString

                '==========================
                Button1_Click(Me, Nothing)
                '==========================
                Label5.Enabled = True
                DatumOtpUpd.Enabled = True

                DatumOtpUpd.Value = mOtpDatum



            End If

            '-------------------------------------- Primenjene tarife -------------------------------------------
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
            '==============

            If mRetVal = "" Then
                '--------------- prikaz tarife ----------------
                gbTarifa.Visible = True
                tbUgovor.Text = mBrojUg
                If IzborSaobracaja = "4" Then
                    Me.Label13.Visible = True '>>>>>>>>>>>>>>>>>>>>>>>>>>>False
                    Me.ComboBox1.Visible = True '>>>>>>>>>>>>>>>>>>>>>>>>>>>False

                    If Len(Trim(mBrojUg)) = 0 Then
                        Me.ComboBox1.SelectedIndex = 2
                        ComboBox1.Focus()
                    Else
                        Me.ComboBox1.SelectedIndex = 0
                        tbUgovor.Focus()
                        tbUgovor.SelectionStart = 4
                    End If
                Else
                    Me.Label13.Visible = True
                    Me.ComboBox1.Visible = True

                    If mBrojUg <> "" And tbUgovor.Text <> "      " Then
                        Me.ComboBox1.SelectedIndex = 0
                    Else
                        If mTarifa = "36" Then
                            Me.ComboBox1.SelectedIndex = 1
                        Else
                            Me.ComboBox1.SelectedIndex = -1
                        End If
                    End If
                    Me.ComboBox1.Focus()
                End If

                Me.btnPrihvati.Visible = False
                Me.btnPreuzmi.Visible = True
            Else
                MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If

        If bGreska > 0 Then
            MessageBox.Show("Greska! Obratite se administratoru!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AkcijaZaPreuzimanje = "Ne"
            Close()
        End If

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        AkcijaZaPreuzimanje = "Ne"
        Close()

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        If Microsoft.VisualBasic.Mid(ComboBox2.Text, 1, 1) <> "1" Then
            Label8.Visible = True
            TextBox4.Visible = True
            TextBox4.Focus()
            'GroupBox1.Enabled = False
        Else
            Label8.Visible = False
            TextBox4.Visible = False
            'GroupBox1.Enabled = True

        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub DatumOtp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumOtpUpd.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub RadioButton4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub RadioButton5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub RadioButton1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadioButton1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub RadioButton2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadioButton2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub RadioButton3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadioButton3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub gbSaobracaj_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.RadioButton4.Checked = True Then
        '    If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
        '        gbTranzit.Enabled = True
        '        gbOstalo.Enabled = False
        '        cb_Tip.Focus()
        '    Else
        '        MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End If
        'Else
        '    gbOstalo.Enabled = True
        '    gbTranzit.Enabled = False
        '    Me.cb_Tip.SelectedIndex = -1
        '    Me.cbSmer1.SelectedIndex = -1
        '    Me.tbNalepnica.TabIndex = 0
        '    Me.tbUgovor.Text = ""

        '    If bVrstaSaobracaja = 2 Then
        '        TextBox1.Focus()
        '    ElseIf bVrstaSaobracaja = 3 Then
        '        TextBox1.Text = "0072"
        '        TextBox2.Text = "72"
        '        TextBox2.SelectionStart = 3
        '        TextBox2.Focus()
        '    End If
        'End If
    End Sub

    Private Sub gbPosiljka_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbPosiljka.Leave
        'If Me.RadioButton4.Checked = True Then
        '    gbTranzit.Enabled = True
        '    gbOstalo.Enabled = False
        '    cb_Tip.Focus()
        'Else
        '    gbOstalo.Enabled = True
        '    gbTranzit.Enabled = False
        '    TextBox1.Focus()
        'End If
    End Sub

    Private Sub cbSmer1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    'Private Sub cbSmer1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cbSmer1.Text = Nothing Then
    '        cbSmer1.Focus()
    '    End If

    'End Sub
    Private Sub RadioButton6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub RadioButton7_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub UpdateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label5.Enabled = True
        Me.DatumOtpUpd.Enabled = True


        'NumericUpDown3.Text = "2011" 'mObrGodina


        If CarinskiAgent = "PROODOS" Then
            Me.gbProdos.Visible = True
            Me.NumericUpDown1.Text = mObrMesec
            Me.NumericUpDown2.Text = mObrGodina
        Else
            Me.gbProdos.Visible = False
        End If

        Me.btnPrihvati.Visible = True
        Me.btnPreuzmi.Visible = False

        'If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
        '    Me.RadioButton4.Checked = True
        'ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
        '    Me.RadioButton5.Checked = True
        'ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
        '    Me.RadioButton6.Checked = True
        'End If

        If RecordAction = "N" Then
            btnPrihvati.Text = "Prihvati"
            Label19.Text = "Izmena podataka u tovarnom listu"

            Label5.Enabled = False
            Label5.Visible = False
            Me.DatumOtpUpd.Enabled = False
            Me.DatumOtpUpd.Visible = False

        ElseIf RecordAction = "D" Then
            btnPrihvati.Text = "Brisi"
            Label19.Text = "Brisanje tovarnog lista iz baze podataka"

            Label5.Enabled = False
            Label5.Visible = False
            Me.DatumOtpUpd.Enabled = False
            Me.DatumOtpUpd.Visible = False

        Else
            btnPrihvati.Text = "Trazi"
            Label19.Text = "Preuzimanje podataka unetih na stanicama"

            If AkcijaZaPreuzimanje = "Da" Then
                '    'cb_Tip.Text = tmpAkcija_TipNalepnice
                '    'cbSmer1.Text = tmpAkcija_Stanica
                '    'tbNalepnica.Text = tmpAkcija_Nalepnica + 1

                '    If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
                '        cb_Tip.Text = tmpAkcija_TipNalepnice
                '        cbSmer1.Text = tmpAkcija_Stanica
                '        tbNalepnica.Text = tmpAkcija_Nalepnica + 1

                '        gbTranzit.Enabled = True
                '        gbTranzit.Focus()
                '        gbSaobracaj.Enabled = True
                '        Me.gbPosiljka.Enabled = False
                '        tbNalepnica.Focus()
                '    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
                '        Label5.Enabled = False
                '        Me.DatumOtpUpd.Enabled = False

                '        gbTranzit.Enabled = False
                '        gbOstalo.Enabled = True
                '        bVrstaSaobracaja = 2
                '        TextBox1.Focus()
                '    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
                '        Label5.Enabled = False
                '        Me.DatumOtpUpd.Enabled = False

                '        gbTranzit.Enabled = False
                '        gbOstalo.Enabled = True
                '        bVrstaSaobracaja = 3
                '        TextBox1.Focus()
                '    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
                '        gbTranzit.Enabled = True
                '        gbTranzit.Focus()
                '        gbSaobracaj.Enabled = True
                '        Me.gbPosiljka.Enabled = False
                '        tbNalepnica.Focus()
                '    End If
            Else
                '    If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
                '        gbTranzit.Enabled = True
                '        gbTranzit.Focus()
                '        Me.gbPosiljka.Enabled = False
                '        gbSaobracaj.Enabled = False
                '        cb_Tip.Text = tmpAkcija_TipNalepnice
                '        cbSmer1.Text = tmpAkcija_Stanica
                '        tbNalepnica.Text = tmpAkcija_Nalepnica + 1
                '        tbNalepnica.Focus()
                '    End If

            End If
        End If
    End Sub

    Private Sub cb_Tip_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    'Private Sub cb_Tip_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cb_Tip.Text = Nothing Then
    '        cb_Tip.Focus()
    '    End If

    'End Sub

    Private Sub btnPreuzmi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreuzmi.Click

        If CarinskiAgent = "PROODOS" Then
            mObrMesec = Me.NumericUpDown1.Text
            mObrGodina = Me.NumericUpDown2.Text
        End If

        If mTarifa = "46" Then
            bVrstaPosiljke = "D"
        End If

        ''''''AkcijaZaPreuzimanje = "Da" '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        mBrojUg = tbUgovor.Text
        If mBrojUg <> "" Then
            mTarifa = "00"
        End If

        'If Me.cbRucnaNajava.Checked = True Then
        '    mRucnaNajava = "D"
        'Else
        '    mRucnaNajava = "N"
        'End If

        If Me.cbCORO.Visible = True Then
            If Me.cbCORO.Checked = True Then
                mVrstaObracuna = "CO"
            Else
                mVrstaObracuna = "RO"
            End If
        End If

        If (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then                        '0206
            If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "00" Or _
                Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "69" Or _
                Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "11" Then
                mVrstaPrevoza = "P"
            ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "01" Or Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "73" Or _
                Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "96" Or Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "97" Then
                mVrstaPrevoza = "V"
            ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "33" Then 'kontejnerski voz
                mVrstaPrevoza = "V"

                ''If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                ''   Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                ''   Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Or _
                ''   Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "03" Then
                ''    mVrstaPrevoza = "V"

                ''    ''''If rbP.Checked = True Then
                ''    ''''    mVrstaPrevoza = "P"
                ''    ''''End If
                ''    ''''If rbV.Checked = True Then
                ''    ''''    mVrstaPrevoza = "V"
                ''    ''''End If

                ''Else
                ''    mVrstaPrevoza = "P"
                ''End If

            ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "02" Then
                mVrstaPrevoza = "G"
            Else
                mVrstaPrevoza = "P"
            End If

            If mBrojUg = "101005" Or mBrojUg = "101105" Then
                mVrstaPrevoza = "V"
            End If

            If mBrojUg = "300899" Or mBrojUg = "300888" Or _
               mBrojUg = "300999" Or mBrojUg = "301099" Or _
               tbUgovor.Text = "301199" Then

                If rbP.Checked = True Then
                    mVrstaPrevoza = "P"
                End If
                If Me.rbG.Checked = True Then
                    mVrstaPrevoza = "G"
                End If
                If Me.rbV.Checked = True Then
                    mVrstaPrevoza = "V"
                End If
            End If

            If mBrojUg = "301122" Then
                mVrstaPrevoza = "P"
            End If
            If mBrojUg = "301023" Or mBrojUg = "301123" Then
                mVrstaPrevoza = "G"
            End If
            If mBrojUg = "301024" Or mBrojUg = "301124" Then
                mVrstaPrevoza = "V"
            End If


        ElseIf mVrstaObracuna = "IC" Then
            If Microsoft.VisualBasic.Mid(mBrojUg, 1, 2) = "99" Then  '! dodati za Alpe-Adria ug. 87...
                If mBrojUg = "993353" Or mBrojUg = "993354" Then
                    mVrstaPrevoza = "V"
                Else
                    mVrstaPrevoza = "P"
                End If
            End If
            If mBrojUg = "931817" Then
                mVrstaPrevoza = "V"
            End If
            If mBrojUg = "835745" Then
                mVrstaPrevoza = "P"
            End If

        ElseIf mVrstaObracuna = "RO" Then
            If rbP.Checked = True Then
                mVrstaPrevoza = "P"
            End If
            If Me.rbG.Checked = True Then
                mVrstaPrevoza = "G"
            End If
            If Me.rbV.Checked = True Then
                mVrstaPrevoza = "V"
            End If
        End If

        'If Me.RadioButton4.Checked = True Then
        '    IzborSaobracaja = "4"
        'End If
        'If Me.RadioButton5.Checked = True Then
        '    IzborSaobracaja = "2"
        'End If
        'If Me.RadioButton6.Checked = True Then
        '    IzborSaobracaja = "3"
        'End If
        'If Me.RadioButton7.Checked = True Then
        '    IzborSaobracaja = "1"
        'End If

        ' --------------------------------- Naknada za obavljanje centralnog obracuna --------------------------------
        If RecordAction = "P" Then ' Preuzimanje iz WinRoba
            '-------------------------------- naknade sumarno -------------------------------
            Dim Nak_Red As DataRow
            Dim mSumaNakR As Decimal = 0
            mSumaNak = 0
            mSumaNakCo = 0
            mSumaNakCo82 = 0

            If dtNaknade.Rows.Count > 0 Then
                _OpenForm = "Naknade"
                mPrikazKalkulacije = "D"
                For Each Nak_Red In dtNaknade.Rows
                    If Nak_Red.Item("Obracun") = "C" Then
                        If Nak_Red.Item("Sifra") = "82" And Nak_Red.Item("IvicniBroj") = "16" Then
                            'mSumaNakCo82 = mSumaNakCo82 + Nak_Red.Item("Iznos")
                            Nak_Red.Item("Iznos") = 0
                        Else
                            mSumaNakCo = mSumaNakCo + Nak_Red.Item("Iznos")
                        End If
                    Else
                        mSumaNakR = mSumaNakR + Nak_Red.Item("Iznos")
                    End If
                Next
                mSumaNak = mSumaNakR + mSumaNakCo82 + mSumaNakCo
            End If
            '-------------------------------- end naknade sumarno -------------------------------
        Else

        End If

        'If Me.rbIzMakisa.Visible = True Then
        '    If Me.rbIzMakisa.Checked = True Then
        '        mMakis = "ZA"
        '    Else
        '        mMakis = "IZ"
        '        mNajava = mNajava2
        '    End If
        'End If
        ' ---------------------------------------------------------------------------------------------------------------------------

        ''''''''''''''''''' zašto? AkcijaZaPreuzimanje = "Ne"

        If AkcijaZaPreuzimanje = "Da" Then
            AkcijaZaPreuzimanje = "Da"
        Else
            AkcijaZaPreuzimanje = "Ne"
        End If

        '----------- korekcija naknada -------------
        UskladiNaknadePoKolima()
        '----------- korekcija naknada -------------

        Me.Dispose()
        Me.Close()

        If IzborSaobracaja = "1" Then
            Dim form2 As New FormUTL
            If RecordAction = "P" Then
                form2.Text = "UTL - Preuzimanje sa granice " & " Racunski mesec : " & mObrMesec & " / " & mObrGodina
            ElseIf RecordAction = "N" Then
                form2.Text = "UTL - Izmena podataka u bazi"
            End If

            form2.ShowDialog()
            Close()

        End If

    End Sub

    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub UpdateForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Me.Close()

    End Sub

    Private Sub rbIzMakisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub rbZaMakis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub cbRucnaNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbRucnaNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbUgovor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUgovor.Validating

        'provera postojanja ugovora - novo
        If tbUgovor.Text = Nothing Then
            If IzborSaobracaja = "4" Then
                If Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2) = "00" Then
                    Me.ComboBox1.Focus() 'tbUgovor.Focus()
                Else
                    btnPreuzmi.Focus()
                End If
            Else
                Me.ComboBox1.SelectedIndex = 0
                Me.ComboBox1.Focus()
            End If
        Else
            If IsNumeric(tbUgovor.Text) = True Then
                Dim mRetVal As String
                Dim ug_mNazivKomitenta As String
                Dim ug_mPrimalac As String
                Dim ug_mSuma As Int32
                Dim ug_mVrstaObracuna As String

                '''''''''!!!!!!!!NadjiUgovor(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, mRetVal)

                NadjiUgovor2(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, ug_mSuma, mRetVal)


                '========= zbog istog broja ugovora =============
                'SELECT COUNT(*) AS ug
                'FROM Ugovori
                'GROUP BY BrojUgovora
                'HAVING (COUNT(*) > 1) AND (BrojUgovora = '111101')


                If IzborSaobracaja = "4" Then
                    If tbUgovor.Text = "000038" Then
                        mTarifa = "38"
                    ElseIf tbUgovor.Text = "929100" Then
                        mTarifa = "68"
                    Else
                        mTarifa = "00"
                    End If
                Else
                    mTarifa = "00" 'Microsoft.VisualBasic.Right(tbUgovor.Text, 2)
                End If

                If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Or Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Or Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
                    cbRucnaNajava.Enabled = False
                Else
                    cbRucnaNajava.Enabled = True
                End If

                If mRetVal = "" Then
                    '_Kontrola_NemaUgovora = 0
                    _temp_mBrojUg = ""

                    mBrojUg = tbUgovor.Text '!!!
                    If MasterAction = "New" Then
                        mPrimalac = ug_mPrimalac
                    End If
                    mVrstaObracuna = ug_mVrstaObracuna
                    'LblKomitent.Text = ug_mNazivKomitenta
                    mSifraKorisnika = ug_mPrimalac
                    '------------ zbog istog broja ugovora za CO i RO!
                    'If mBrojUg = "800901" Or mBrojUg = "800902" Or mBrojUg = "830901" Then
                    If ug_mSuma > 1 Then
                        Me.cbCORO.Visible = True
                        cbCORO.Focus()
                    Else
                        LblKomitent.Text = ug_mNazivKomitenta
                        Me.cbCORO.Visible = False

                        gbVrP.Focus()

                        Select Case mVrstaPrevoza
                            Case "P"
                                rbP.Checked = True
                            Case "G"
                                rbG.Checked = True
                            Case "V"
                                rbV.Checked = True
                        End Select

                        btnPreuzmi.Focus()
                    End If
                    '--------------------------------------------------


                Else
                    '_Kontrola_NemaUgovora = 1
                    ErrorProvider1.SetError(tbUgovor, "")
                    MessageBox.Show("Takav ugovor ne postoji u bazi podataka!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation)
                    LblKomitent.Text = ""

                    '_temp_mBrojUg = tbUgovor.Text ' proveriti kako radi do kraja

                    tbUgovor.Focus()
                End If

            Else
                If IzborSaobracaja = "4" Then
                    ErrorProvider1.SetError(tbUgovor, "Neispravan unos!")
                    tbUgovor.Focus()
                Else
                    ErrorProvider1.SetError(tbUgovor, "")
                    Me.ComboBox1.SelectedIndex = 0
                    Me.ComboBox1.Focus()
                End If
            End If
        End If


        '''''provera postojanja ugovora - staro

        ''''If IsNumeric(tbUgovor.Text) = True Then

        ''''    If tbUgovor.Text = Nothing Then
        ''''        If IzborSaobracaja = "4" Then
        ''''            If Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2) = "00" Then
        ''''                tbUgovor.Focus()
        ''''            Else
        ''''                btnPreuzmi.Focus()

        ''''            End If

        ''''        Else
        ''''            Me.ComboBox1.SelectedIndex = 0
        ''''            Me.ComboBox1.Focus()
        ''''        End If
        ''''    Else
        ''''        Dim mRetVal As String
        ''''        Dim ug_mNazivKomitenta As String
        ''''        Dim ug_mPrimalac As String
        ''''        Dim ug_mVrstaObracuna As String

        ''''        NadjiUgovor(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, mRetVal)

        ''''        If IzborSaobracaja = "4" Then
        ''''            If tbUgovor.Text = "000038" Then
        ''''                mTarifa = "38"
        ''''            ElseIf tbUgovor.Text = "929100" Then
        ''''                mTarifa = "68"
        ''''            Else
        ''''                mTarifa = "00"
        ''''            End If
        ''''        Else
        ''''            mTarifa = "00" 'Microsoft.VisualBasic.Right(tbUgovor.Text, 2)
        ''''        End If

        ''''        If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Or Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Or Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
        ''''            cbRucnaNajava.Enabled = False
        ''''        Else
        ''''            cbRucnaNajava.Enabled = True
        ''''        End If

        ''''        If mRetVal = "" Then
        ''''            '_Kontrola_NemaUgovora = 0
        ''''            _temp_mBrojUg = ""

        ''''            mBrojUg = tbUgovor.Text '!!!
        ''''            mPrimalac = ug_mPrimalac
        ''''            mVrstaObracuna = ug_mVrstaObracuna
        ''''            LblKomitent.Text = ug_mNazivKomitenta
        ''''            mSifraKorisnika = ug_mPrimalac
        ''''            ''''''''''''''btnPreuzmi.Focus()

        ''''        Else
        ''''            '_Kontrola_NemaUgovora = 1
        ''''            ErrorProvider1.SetError(tbUgovor, "")
        ''''            MessageBox.Show("Takav ugovor ne postoji u bazi podataka!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation)
        ''''            LblKomitent.Text = ""

        ''''            '_temp_mBrojUg = tbUgovor.Text ' proveriti kako radi do kraja

        ''''            tbUgovor.Focus()
        ''''        End If
        ''''    End If

        ''''Else
        ''''    If IzborSaobracaja = "4" Then
        ''''        ErrorProvider1.SetError(tbUgovor, "Neispravan unos!")
        ''''        tbUgovor.Focus()
        ''''    Else
        ''''        ErrorProvider1.SetError(tbUgovor, "")
        ''''        Me.ComboBox1.SelectedIndex = 0
        ''''        Me.ComboBox1.Focus()
        ''''    End If
        ''''End If

    End Sub

    Private Sub ComboBox1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        If Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2) = "00" Then
            tbUgovor.Focus()
        Else
            tbUgovor.Text = ""
            mBrojUg = ""
            mTarifa = Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2)
            btnPreuzmi.Focus()
        End If
    End Sub

    Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        If ComboBox1.Text = Nothing Then
            ErrorProvider1.SetError(ComboBox1, "Obavezan izbor tarife!")
            ComboBox1.Focus()
        Else
            If Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2) = "00" Then
                cbRucnaNajava.Visible = True
                tbUgovor.Enabled = True
                mTarifa = "00"

                tbUgovor.Focus()
            Else
                Me.gbVrP.Visible = True
                Me.rbG.Enabled = True
                tbUgovor.Text = ""
                tbUgovor.Enabled = False
                cbRucnaNajava.Visible = False
                ComboBox1.Visible = False
                rbP.Enabled = False
                rbG.Enabled = False
                rbV.Enabled = False
                mTarifa = Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2)
                mVrstaObracuna = "RO"

                ' mPrimalac = 0                 ukinuto zbog vracanja korisnika iz baze
                LblKomitent.Text = ""

                'mSifraKorisnika = 0            ukinuto zbog vracanja korisnika iz baze

                btnPreuzmi.Focus()
            End If
            ErrorProvider1.SetError(ComboBox1, "")
        End If
    End Sub

    'Private Sub RadioButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
    '        gbTranzit.Enabled = False
    '        gbOstalo.Enabled = True
    '        bVrstaSaobracaja = 2
    '        TextBox1.Focus()
    '    Else
    '        MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        gbTranzit.Enabled = False
    '        gbOstalo.Enabled = False
    '    End If

    'End Sub

    'Private Sub RadioButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
    '        gbTranzit.Enabled = False
    '        gbOstalo.Enabled = True
    '        bVrstaSaobracaja = 3
    '        TextBox1.Focus()
    '    Else
    '        MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        gbTranzit.Enabled = False
    '        gbOstalo.Enabled = False

    '    End If

    'End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        TextBox2.Text = Microsoft.VisualBasic.Right(TextBox1.Text, 2)
        TextBox2.SelectionStart = 3

    End Sub

    'Private Sub RadioButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    gbTranzit.Enabled = False
    '    gbOstalo.Enabled = True
    '    bVrstaSaobracaja = 1
    '    TextBox1.Focus()
    'End Sub

    'Private Sub RadioButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
    '        gbTranzit.Enabled = True
    '        gbOstalo.Enabled = False
    '        cb_Tip.Focus()
    '    Else
    '        MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        gbTranzit.Enabled = False
    '        gbOstalo.Enabled = False
    '    End If

    'End Sub

    Private Sub tbUgovor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.Leave
        If mVrstaObracuna = "RO" Then
            Me.gbVrP.Visible = True
        Else
            Me.gbVrP.Visible = True
            If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "01" Then
                Me.gbVrP.Visible = False
                mVrstaPrevoza = "V"
            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "96" Then
                Me.gbVrP.Visible = False
                mVrstaPrevoza = "V"
            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "33" Then
                Me.gbVrP.Visible = False
                mVrstaPrevoza = "V"
            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "97" Then
                Me.gbVrP.Visible = False
                mVrstaPrevoza = "V"
            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "73" Then
                Me.gbVrP.Visible = False
                mVrstaPrevoza = "V"
            End If
            If tbUgovor.Text = "101005" Or mBrojUg = "101105" Then
                Me.gbVrP.Visible = False
                mVrstaPrevoza = "V"
            End If

            ''If tbUgovor.Text = "300899" Or mBrojUg = "300888" Then
            ''    Me.gbVrP.Visible = True
            ''Else
            ''    If tbUgovor.Text = "844514" Or tbUgovor.Text = "844516" Then
            ''        Me.gbVrP.Visible = True
            ''    Else
            ''        Me.gbVrP.Visible = False
            ''    End If
            ''End If

            If tbUgovor.Text = "301122" Then
                Me.gbVrP.Visible = True
                Me.rbP.Enabled = True
                Me.rbP.Checked = True
                Me.rbG.Enabled = False
                Me.rbV.Enabled = False
                mVrstaPrevoza = "P"
            End If
            If tbUgovor.Text = "301023" Or tbUgovor.Text = "301123" Then
                Me.gbVrP.Visible = True
                Me.rbP.Enabled = False
                Me.rbG.Enabled = True
                Me.rbG.Checked = True
                Me.rbV.Enabled = False
                mVrstaPrevoza = "G"
            End If
            If tbUgovor.Text = "101070" Or tbUgovor.Text = "111070" Or tbUgovor.Text = "121070" Then
                Me.gbVrP.Visible = True
                Me.rbP.Enabled = False
                Me.rbG.Enabled = True
                Me.rbG.Checked = True
                Me.rbV.Enabled = False
                mVrstaPrevoza = "G"
            End If
            If tbUgovor.Text = "301024" Or tbUgovor.Text = "301124" Then
                Me.gbVrP.Visible = True
                Me.rbP.Enabled = False
                Me.rbG.Enabled = False
                Me.rbV.Enabled = True
                Me.rbV.Checked = True
                mVrstaPrevoza = "V"
            End If


            '============================
            ''If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "22" Then

            ''    If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
            ''       Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
            ''       Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

            ''        Me.gbVrP.Visible = True
            ''        Me.rbG.Enabled = False
            ''    Else
            ''        Me.gbVrP.Visible = False
            ''    End If
            ''Else
            ''    If tbUgovor.Text = "300899" Or mBrojUg = "300888" Then
            ''        Me.gbVrP.Visible = True
            ''    Else
            ''        If tbUgovor.Text = "844514" Or tbUgovor.Text = "844516" Then
            ''            Me.gbVrP.Visible = True
            ''        Else
            ''            Me.gbVrP.Visible = False
            ''        End If
            ''    End If

            ''    If tbUgovor.Text = "300823" Then
            ''        Me.gbVrP.Visible = True
            ''        Me.rbP.Enabled = False
            ''        Me.rbG.Enabled = True
            ''        Me.rbG.Checked = True
            ''        Me.rbV.Enabled = False
            ''        mVrstaPrevoza = "G"
            ''    End If
            ''    If tbUgovor.Text = "300824" Then
            ''        Me.gbVrP.Visible = True
            ''        Me.rbP.Enabled = False
            ''        Me.rbG.Enabled = False
            ''        Me.rbV.Enabled = True
            ''        Me.rbV.Checked = True
            ''        mVrstaPrevoza = "V"
            ''    End If

            ''End If
        End If
    End Sub

    Private Sub cb22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb22.Click
        If Me.cb22.Checked = True Then
            mVrstaPrevoza = "P"
        Else
            mVrstaPrevoza = "V"
        End If
    End Sub

    Private Sub cbRucnaNajava_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRucnaNajava.Leave
        btnPreuzmi.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim form2 As New TLGrid
        form2.ShowDialog()
        form2.Dispose()

    End Sub

    Private Sub tbNalepnica_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnPrihvati.Focus()

    End Sub

    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""
        Util.sNadjiNaziv("UicOperateri", TextBox1.Text, "", "", 1, xNaziv, xPovVrednost)

        If xPovVrednost <> "" Then
            ErrorProvider1.SetError(TextBox1, "Nepostojeca uprava!")
            TextBox1.Focus()
        Else
            Label17.Text = Microsoft.VisualBasic.Mid(xNaziv, 3, Len(xNaziv))
            TextBox2.Text = Microsoft.VisualBasic.Left(xNaziv, 2)
            TextBox2.SelectionStart = 1
        End If

    End Sub

    Private Sub cbCORO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCORO.Click
        btnPreuzmi.Focus()
    End Sub

    Private Sub gbProdos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbProdos.Enter

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
