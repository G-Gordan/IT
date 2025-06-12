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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbSmer1 As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents gbOstalo As System.Windows.Forms.GroupBox
    Friend WithEvents gbTranzit As System.Windows.Forms.GroupBox
    Friend WithEvents gbPosiljka As System.Windows.Forms.GroupBox
    Friend WithEvents gbSaobracaj As System.Windows.Forms.GroupBox
    Friend WithEvents tbNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cb_Tip As System.Windows.Forms.ComboBox
    Friend WithEvents btnPreuzmi As System.Windows.Forms.Button
    Friend WithEvents rbIzMakisa As System.Windows.Forms.RadioButton
    Friend WithEvents rbZaMakis As System.Windows.Forms.RadioButton
    Friend WithEvents lblSmer As System.Windows.Forms.Label
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbGodina As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnKB As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
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
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.btnKB = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.gbTranzit = New System.Windows.Forms.GroupBox
        Me.tbGodina = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblSmer = New System.Windows.Forms.Label
        Me.rbZaMakis = New System.Windows.Forms.RadioButton
        Me.rbIzMakisa = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.cb_Tip = New System.Windows.Forms.ComboBox
        Me.cbSmer1 = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.tbNalepnica = New System.Windows.Forms.TextBox
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
        Me.gbSaobracaj = New System.Windows.Forms.GroupBox
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.RadioButton7 = New System.Windows.Forms.RadioButton
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.btnPreuzmi = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.LblKomitent = New System.Windows.Forms.Label
        Me.gbTarifa = New System.Windows.Forms.GroupBox
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.gbOstalo.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbTranzit.SuspendLayout()
        Me.gbPosiljka.SuspendLayout()
        Me.gbSaobracaj.SuspendLayout()
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
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(112, 28)
        Me.TextBox1.MaxLength = 4
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 23)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        Me.ToolTip1.SetToolTip(Me.TextBox1, "Sifra operatera - 4 cifre")
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 22)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Operater"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Stanica"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 18)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Broj"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 18)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Datum"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(112, 72)
        Me.TextBox2.MaxLength = 7
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(128, 22)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = ""
        Me.ToolTip1.SetToolTip(Me.TextBox2, "Sifra uprave+sifra stanice bez kontrolnog broja")
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(112, 112)
        Me.TextBox3.MaxLength = 6
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(64, 22)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = ""
        Me.ToolTip1.SetToolTip(Me.TextBox3, "Broj otpravljanja sa kontrolnim brojem")
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(456, 480)
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
        Me.btnOtkazi.Location = New System.Drawing.Point(580, 480)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 6
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(32, 56)
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
        Me.DatumOtpUpd.Location = New System.Drawing.Point(112, 152)
        Me.DatumOtpUpd.Name = "DatumOtpUpd"
        Me.DatumOtpUpd.Size = New System.Drawing.Size(128, 22)
        Me.DatumOtpUpd.TabIndex = 3
        '
        'gbOstalo
        '
        Me.gbOstalo.Controls.Add(Me.TextBox6)
        Me.gbOstalo.Controls.Add(Me.Label20)
        Me.gbOstalo.Controls.Add(Me.btnKB)
        Me.gbOstalo.Controls.Add(Me.Label19)
        Me.gbOstalo.Controls.Add(Me.Label18)
        Me.gbOstalo.Controls.Add(Me.Label17)
        Me.gbOstalo.Controls.Add(Me.Label5)
        Me.gbOstalo.Controls.Add(Me.Label4)
        Me.gbOstalo.Controls.Add(Me.Label3)
        Me.gbOstalo.Controls.Add(Me.Label2)
        Me.gbOstalo.Controls.Add(Me.TextBox1)
        Me.gbOstalo.Controls.Add(Me.DatumOtpUpd)
        Me.gbOstalo.Controls.Add(Me.TextBox3)
        Me.gbOstalo.Controls.Add(Me.TextBox2)
        Me.gbOstalo.Enabled = False
        Me.gbOstalo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOstalo.Location = New System.Drawing.Point(354, 216)
        Me.gbOstalo.Name = "gbOstalo"
        Me.gbOstalo.Size = New System.Drawing.Size(318, 208)
        Me.gbOstalo.TabIndex = 3
        Me.gbOstalo.TabStop = False
        Me.gbOstalo.Text = " [ Otpravljanje ] "
        '
        'TextBox6
        '
        Me.TextBox6.Enabled = False
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(216, 112)
        Me.TextBox6.MaxLength = 1
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(24, 22)
        Me.TextBox6.TabIndex = 10
        Me.TextBox6.Text = ""
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox6, "Broj otpravljanja sa kontrolnim brojem")
        Me.TextBox6.Visible = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Gray
        Me.Label20.Location = New System.Drawing.Point(217, 98)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(24, 18)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "[kb]"
        '
        'btnKB
        '
        Me.btnKB.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnKB.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnKB.Image = CType(resources.GetObject("btnKB.Image"), System.Drawing.Image)
        Me.btnKB.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnKB.Location = New System.Drawing.Point(192, 112)
        Me.btnKB.Name = "btnKB"
        Me.btnKB.Size = New System.Drawing.Size(24, 22)
        Me.btnKB.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.btnKB, "Dobijanje kontrolnog broja")
        Me.btnKB.Visible = False
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Gray
        Me.Label19.Location = New System.Drawing.Point(267, 115)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 18)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "[ 5+1 ]"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Gray
        Me.Label18.Location = New System.Drawing.Point(267, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 18)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "[ 2+5 ]"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Gray
        Me.Label17.Location = New System.Drawing.Point(267, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 18)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "[   4    ]"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(112, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(416, 64)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Mozete izmeniti samo podatke koji su uneti u vasoj stanici"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Controls.Add(Me.ComboBox2)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(464, 8)
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
        'gbTranzit
        '
        Me.gbTranzit.Controls.Add(Me.tbGodina)
        Me.gbTranzit.Controls.Add(Me.Label16)
        Me.gbTranzit.Controls.Add(Me.lblSmer)
        Me.gbTranzit.Controls.Add(Me.rbZaMakis)
        Me.gbTranzit.Controls.Add(Me.rbIzMakisa)
        Me.gbTranzit.Controls.Add(Me.Label6)
        Me.gbTranzit.Controls.Add(Me.cb_Tip)
        Me.gbTranzit.Controls.Add(Me.cbSmer1)
        Me.gbTranzit.Controls.Add(Me.Label11)
        Me.gbTranzit.Controls.Add(Me.Label12)
        Me.gbTranzit.Controls.Add(Me.tbNalepnica)
        Me.gbTranzit.Enabled = False
        Me.gbTranzit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTranzit.Location = New System.Drawing.Point(24, 216)
        Me.gbTranzit.Name = "gbTranzit"
        Me.gbTranzit.Size = New System.Drawing.Size(318, 208)
        Me.gbTranzit.TabIndex = 2
        Me.gbTranzit.TabStop = False
        Me.gbTranzit.Text = "[ Tranzitna nalepnica ]"
        '
        'tbGodina
        '
        Me.tbGodina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGodina.Location = New System.Drawing.Point(112, 26)
        Me.tbGodina.MaxLength = 4
        Me.tbGodina.Name = "tbGodina"
        Me.tbGodina.Size = New System.Drawing.Size(89, 22)
        Me.tbGodina.TabIndex = 15
        Me.tbGodina.Text = ""
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 23)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Godina"
        '
        'lblSmer
        '
        Me.lblSmer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSmer.Location = New System.Drawing.Point(23, 199)
        Me.lblSmer.Name = "lblSmer"
        Me.lblSmer.Size = New System.Drawing.Size(79, 16)
        Me.lblSmer.TabIndex = 13
        Me.lblSmer.Text = "Izbor smera :"
        Me.lblSmer.Visible = False
        '
        'rbZaMakis
        '
        Me.rbZaMakis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbZaMakis.Location = New System.Drawing.Point(216, 196)
        Me.rbZaMakis.Name = "rbZaMakis"
        Me.rbZaMakis.Size = New System.Drawing.Size(96, 24)
        Me.rbZaMakis.TabIndex = 12
        Me.rbZaMakis.Text = "RadioButton8"
        Me.rbZaMakis.Visible = False
        '
        'rbIzMakisa
        '
        Me.rbIzMakisa.Checked = True
        Me.rbIzMakisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIzMakisa.Location = New System.Drawing.Point(112, 196)
        Me.rbIzMakisa.Name = "rbIzMakisa"
        Me.rbIzMakisa.Size = New System.Drawing.Size(96, 24)
        Me.rbIzMakisa.TabIndex = 11
        Me.rbIzMakisa.TabStop = True
        Me.rbIzMakisa.Text = "RadioButton8"
        Me.rbIzMakisa.Visible = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 23)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Tip nalepnice"
        '
        'cb_Tip
        '
        Me.cb_Tip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Tip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Tip.Items.AddRange(New Object() {"1 - Ulazna nalepnica", "2 - Izlazna nalepnica"})
        Me.cb_Tip.Location = New System.Drawing.Point(112, 66)
        Me.cb_Tip.Name = "cb_Tip"
        Me.cb_Tip.Size = New System.Drawing.Size(192, 24)
        Me.cb_Tip.TabIndex = 0
        '
        'cbSmer1
        '
        Me.cbSmer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer1.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer1.Location = New System.Drawing.Point(112, 112)
        Me.cbSmer1.Name = "cbSmer1"
        Me.cbSmer1.Size = New System.Drawing.Size(192, 24)
        Me.cbSmer1.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 21)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Broj"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 15)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Stanica"
        '
        'tbNalepnica
        '
        Me.tbNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNalepnica.Location = New System.Drawing.Point(112, 152)
        Me.tbNalepnica.MaxLength = 5
        Me.tbNalepnica.Name = "tbNalepnica"
        Me.tbNalepnica.Size = New System.Drawing.Size(192, 22)
        Me.tbNalepnica.TabIndex = 2
        Me.tbNalepnica.Text = ""
        '
        'tbUgovor
        '
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(17, 80)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(112, 23)
        Me.tbUgovor.TabIndex = 14
        Me.tbUgovor.Text = ""
        '
        'cbRucnaNajava
        '
        Me.cbRucnaNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRucnaNajava.Location = New System.Drawing.Point(137, 80)
        Me.cbRucnaNajava.Name = "cbRucnaNajava"
        Me.cbRucnaNajava.Size = New System.Drawing.Size(160, 24)
        Me.cbRucnaNajava.TabIndex = 15
        Me.cbRucnaNajava.Text = "Najava nije uneta u bazu"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(56, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 24)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Broj ugovora"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(504, 8)
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
        Me.gbPosiljka.Location = New System.Drawing.Point(448, 568)
        Me.gbPosiljka.Name = "gbPosiljka"
        Me.gbPosiljka.Size = New System.Drawing.Size(24, 24)
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
        'gbSaobracaj
        '
        Me.gbSaobracaj.Controls.Add(Me.RadioButton6)
        Me.gbSaobracaj.Controls.Add(Me.RadioButton7)
        Me.gbSaobracaj.Controls.Add(Me.RadioButton5)
        Me.gbSaobracaj.Controls.Add(Me.RadioButton4)
        Me.gbSaobracaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSaobracaj.Location = New System.Drawing.Point(24, 136)
        Me.gbSaobracaj.Name = "gbSaobracaj"
        Me.gbSaobracaj.Size = New System.Drawing.Size(648, 73)
        Me.gbSaobracaj.TabIndex = 0
        Me.gbSaobracaj.TabStop = False
        Me.gbSaobracaj.Text = "[ Vrsta saobracaja ]"
        '
        'RadioButton6
        '
        Me.RadioButton6.Location = New System.Drawing.Point(336, 33)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.TabIndex = 2
        Me.RadioButton6.Text = "Izvoz"
        '
        'RadioButton7
        '
        Me.RadioButton7.Enabled = False
        Me.RadioButton7.Location = New System.Drawing.Point(488, 33)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.TabIndex = 3
        Me.RadioButton7.Text = "Lokal"
        '
        'RadioButton5
        '
        Me.RadioButton5.Location = New System.Drawing.Point(200, 33)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.TabIndex = 1
        Me.RadioButton5.Text = "Uvoz"
        '
        'RadioButton4
        '
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(72, 33)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.TabIndex = 0
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Tranzit"
        '
        'btnPreuzmi
        '
        Me.btnPreuzmi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPreuzmi.Image = CType(resources.GetObject("btnPreuzmi.Image"), System.Drawing.Image)
        Me.btnPreuzmi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPreuzmi.Location = New System.Drawing.Point(544, 552)
        Me.btnPreuzmi.Name = "btnPreuzmi"
        Me.btnPreuzmi.Size = New System.Drawing.Size(36, 32)
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
        Me.LblKomitent.Location = New System.Drawing.Point(24, 432)
        Me.LblKomitent.Name = "LblKomitent"
        Me.LblKomitent.Size = New System.Drawing.Size(568, 32)
        Me.LblKomitent.TabIndex = 17
        '
        'gbTarifa
        '
        Me.gbTarifa.Controls.Add(Me.gbVrP)
        Me.gbTarifa.Controls.Add(Me.ComboBox1)
        Me.gbTarifa.Controls.Add(Me.cbRucnaNajava)
        Me.gbTarifa.Controls.Add(Me.tbUgovor)
        Me.gbTarifa.Controls.Add(Me.Label13)
        Me.gbTarifa.Controls.Add(Me.Label10)
        Me.gbTarifa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTarifa.Location = New System.Drawing.Point(648, 8)
        Me.gbTarifa.Name = "gbTarifa"
        Me.gbTarifa.Size = New System.Drawing.Size(56, 48)
        Me.gbTarifa.TabIndex = 18
        Me.gbTarifa.TabStop = False
        Me.gbTarifa.Text = " [ T a r i f a ] "
        Me.gbTarifa.Visible = False
        '
        'gbVrP
        '
        Me.gbVrP.Controls.Add(Me.rbV)
        Me.gbVrP.Controls.Add(Me.rbG)
        Me.gbVrP.Controls.Add(Me.rbP)
        Me.gbVrP.Location = New System.Drawing.Point(0, 112)
        Me.gbVrP.Name = "gbVrP"
        Me.gbVrP.Size = New System.Drawing.Size(318, 96)
        Me.gbVrP.TabIndex = 16
        Me.gbVrP.TabStop = False
        Me.gbVrP.Text = " [ Vrsta posiljke ] "
        Me.gbVrP.Visible = False
        '
        'rbV
        '
        Me.rbV.Location = New System.Drawing.Point(80, 66)
        Me.rbV.Name = "rbV"
        Me.rbV.Size = New System.Drawing.Size(160, 24)
        Me.rbV.TabIndex = 4
        Me.rbV.Text = "Marsrutni voz"
        '
        'rbG
        '
        Me.rbG.Location = New System.Drawing.Point(80, 43)
        Me.rbG.Name = "rbG"
        Me.rbG.TabIndex = 3
        Me.rbG.Text = "Grupa kola"
        '
        'rbP
        '
        Me.rbP.Checked = True
        Me.rbP.Location = New System.Drawing.Point(80, 19)
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
        Me.cb22.Location = New System.Drawing.Point(448, 552)
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
        Me.gbProdos.ForeColor = System.Drawing.Color.Red
        Me.gbProdos.Location = New System.Drawing.Point(472, 544)
        Me.gbProdos.Name = "gbProdos"
        Me.gbProdos.Size = New System.Drawing.Size(40, 32)
        Me.gbProdos.TabIndex = 19
        Me.gbProdos.TabStop = False
        Me.gbProdos.Text = " [ UNOS VAN REDOVNOG RACUNSKOG MESECA ]"
        Me.gbProdos.Visible = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(216, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Godina"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown2.Location = New System.Drawing.Point(168, 35)
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
        Me.NumericUpDown1.Location = New System.Drawing.Point(584, 552)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(88, 22)
        Me.NumericUpDown1.TabIndex = 1
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown1.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumericUpDown1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(504, 568)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 16)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Help
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Button2.Location = New System.Drawing.Point(8, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 22)
        Me.Button2.TabIndex = 34
        Me.ToolTip1.SetToolTip(Me.Button2, "Dobijanje kontrolnog broja")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 464)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 120)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ OBJASNJENJE ] "
        Me.GroupBox1.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Control
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.Items.AddRange(New Object() {"Koristi se u slucaju kada na tovarnom listu nije upisan ", "kontrolni broj, ili ako zelite da proverite kontrolni broj. ", "Pristiskom na dugme sa strelicom, u polju sa desne strane ", "se pokazuje kontrolni broj, koji je informativnog karaktera. ", "", "Za pretrazivanje baze merodavan je podatak iz polja ""Broj"".", ""})
        Me.ListBox1.Location = New System.Drawing.Point(48, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(344, 91)
        Me.ListBox1.TabIndex = 22
        '
        'UpdateForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(698, 590)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gbProdos)
        Me.Controls.Add(Me.gbTarifa)
        Me.Controls.Add(Me.LblKomitent)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.gbSaobracaj)
        Me.Controls.Add(Me.gbPosiljka)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbTranzit)
        Me.Controls.Add(Me.gbOstalo)
        Me.Controls.Add(Me.btnPreuzmi)
        Me.Controls.Add(Me.cb22)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Izmena unetih podataka"
        Me.gbOstalo.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.gbTranzit.ResumeLayout(False)
        Me.gbPosiljka.ResumeLayout(False)
        Me.gbSaobracaj.ResumeLayout(False)
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
        'mObrGodina = Now.Today.Year.ToString
        mObrGodina = Me.tbGodina.Text

        If RecordAction = "N" Then   ' 1. ================== Azuriranje u WinRoba ==========================
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

            If Me.gbTranzit.Enabled = True Then ' ---------- Tranzit
                Dim otUprava As String
                Dim otStanica As String
                Dim otBroj As Int32
                Dim otDatum As Date
                IzborSaobracaja = "4"

                If Microsoft.VisualBasic.Mid(cb_Tip.Text, 1, 1) = "1" Then
                    TipTranzita = "ulaz"
                Else
                    TipTranzita = "izlaz"
                End If

                eNadjiTovarniListTrz(Microsoft.VisualBasic.Mid(cb_Tip.Text, 1, 1), Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), tbNalepnica.Text, mObrGodina, _
                                    mRecID, mStanicaRecID, mObrMesec, otUprava, otStanica, otBroj, otDatum, izPrUprava, izPrStanica, _
                                    izZsPrelaz, izNalepnica, msBrojVoza, mSatVoza, msBrojVoza2, mSatVoza2, mDatumUlaza, mDatumIzlaza, izSifraTarife, izUgovor, mCarStanica, mCarStanica2, _
                                    mRetVal)

                If Microsoft.VisualBasic.Mid(cb_Tip.Text, 1, 1) = "1" Then
                    mUlPrelaz = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
                    mIzPrelaz = izZsPrelaz
                    mUlEtiketa = tbNalepnica.Text
                    mIzEtiketa = izNalepnica
                Else
                    mUlPrelaz = izZsPrelaz
                    mIzPrelaz = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
                    mUlEtiketa = izNalepnica
                    mIzEtiketa = tbNalepnica.Text
                End If

                UpdRecID = mrecid
                UpdUprava = otUprava
                UpdStanica = otStanica
                UpdStanicaRecID = mStanicaRecID
                UpdBroj = otBroj
                UpdDatum = otDatum
                izZsUlPrelaz = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
                mTarifa = izSifraTarife
                mBrojUg = izUgovor
            Else       ' ---------- Uvoz, Izvoz
                Label5.Enabled = False
                Me.DatumOtpUpd.Enabled = False
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

                eNadjiTovarniListUI(mOtpUprava, mOtpStanica, mOtpBroj, mOtpDatum, mRecID, mStanicaRecID, _
                                    mUlPrelaz, mIzPrelaz, msBrojVoza, mSatVoza, msBrojVoza2, mSatVoza2, _
                                    mDatumUlaza, mDatumIzlaza, izSifraTarife, izUgovor, mCarStanica, mCarStanica2, _
                                    mRetVal)


                UpdRecID = mrecid
                UpdStanicaRecID = mStanicaRecID
                UpdUprava = mOtpUprava
                UpdStanica = mOtpStanica
                UpdBroj = mOtpBroj
                UpdDatum = mOtpDatum


                'zbog kontrole duplih prispeca
                mPrispece = 0
                mPrUprava = izPrUprava
                mPrStanica = izPrStanica
                'IzborSaobracaja = izSaobracaj
                mNajava = izNajava
                mTarifa = izSifraTarife
                mBrojUg = izUgovor
            End If


            If mRetVal = "" Then
                btnPreuzmi_Click(Me, Nothing)
            Else
                MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        ElseIf RecordAction = "D" Then ' 2. =================== Brisanje u WinRoba ========================

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

            If Me.gbTranzit.Enabled = True Then
                Dim otUprava As String
                Dim otStanica As String
                Dim otBroj As Int32
                Dim otDatum As Date

                NadjiTovarniListTrz4Del(Microsoft.VisualBasic.Mid(cb_Tip.Text, 1, 1), _
                                        Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), tbNalepnica.Text, mObrGodina, _
                                        mRecID, mStanicaRecID, _
                                        mRetVal)

            Else
                Dim nm_LomStanica As String

                mOtpUprava = TextBox1.Text
                mOtpStanica = TextBox2.Text
                mOtpBroj = TextBox3.Text

                mOtpDatum = Me.DatumOtpUpd.Value.ToShortDateString
                mMesec = mOtpDatum.Month.ToString
                mDan = mOtpDatum.Day.ToString
                mGodina = mOtpDatum.Year.ToString

                NadjiTovarniListDel(mOtpUprava, mOtpStanica, mOtpBroj, mOtpDatum, _
                                    mRecID, mStanicaRecID, _
                                    mRetVal)

            End If

            If mRetVal = "" Then
                If mStanicaRecID = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) Then
                    Dim Msg As String
                    Dim Ans As MsgBoxResult

                    Msg = "Izabrani tovarni list ce biti izbrisan iz baze podataka! " & Chr(13)
                    Msg = Msg & "Da li ste sigurni?"

                    Ans = MsgBox(Msg, vbYesNo + vbInformation, "Brisanje podataka!")
                    If Ans = vbNo Then
                        Close()
                    Else
                        Dim bRetVal As Int32 = 0
                        If Me.gbTranzit.Enabled = True Then
                            BrisiTL(mrecid, mstanicarecid, bRetVal)
                        Else
                            BrisiTLUI(mrecid, mstanicarecid, bRetVal)
                        End If

                        If bRetVal > 0 Then
                            MessageBox.Show("Izabrani tovarni list je izbrisan iz baze podataka. ", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Izabrani tovarni list nije izbrisan. Obratite se administratoru.", "Poruka o gresci", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        Close()
                    End If

                Else
                    MessageBox.Show("Podatak nije unet u stanici " & Microsoft.VisualBasic.Right(StanicaUnosa, Len(StanicaUnosa) - 10) & ".  Brisanje nije dozvoljeno.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Nepostojeci podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ''ElseIf RecordAction = "P" Then  ' 3. ==================== Preuzimanje iz WinRoba ========================

            ''    MasterAction = "New"

            ''    Dim izPrUprava As String
            ''    Dim izPrStanica As String
            ''    Dim izPrDatum As Date
            ''    Dim izSaobracaj As String
            ''    Dim izZsPrelaz As String
            ''    Dim izZsUlPrelaz As String
            ''    Dim izZsIzPrelaz As String
            ''    Dim izNalepnica As Int32
            ''    Dim izNajava As String
            ''    Dim izNajava2 As String
            ''    Dim izSifraTarife As String
            ''    Dim izUgovor As String
            ''    Dim mDatum As Date
            ''    Dim mRetVal As String
            ''    Dim mRecID As Int32
            ''    Dim mStanicaRecID As String

            ''    If Me.gbTranzit.Enabled = True Then ' -------------------------- T R A N Z I T ----------------------
            ''        Dim otUprava As String
            ''        Dim otStanica As String
            ''        Dim otBroj As Int32
            ''        Dim otDatum As Date

            ''        NadjiTovarniListTrzGranica(Microsoft.VisualBasic.Mid(cb_Tip.Text, 1, 1), Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), tbNalepnica.Text, mObrGodina, _
            ''                                     mRecID, mStanicaRecID, otUprava, otStanica, otBroj, otDatum, izPrUprava, izPrStanica, izPrDatum, _
            ''                                     izSaobracaj, izZsPrelaz, izNalepnica, izNajava, izSifraTarife, izUgovor, _
            ''                                     mSumaIznos, mPrevoznina, mSumaNak, _
            ''                                     mRetVal)

            ''        If Microsoft.VisualBasic.Mid(cb_Tip.Text, 1, 1) = "1" Then
            ''            izZsUlPrelaz = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            ''            izZsIzPrelaz = izZsPrelaz
            ''            mUlEtiketa = tbNalepnica.Text
            ''            mIzEtiketa = izNalepnica
            ''        Else
            ''            izZsulPrelaz = izZsPrelaz
            ''            izZsIzPrelaz = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            ''            mUlEtiketa = izNalepnica
            ''            mIzEtiketa = tbNalepnica.Text
            ''        End If
            ''        mNajava = mNajava

            ''    Else                                ' -------------------------- U V O Z / I Z V O Z ----------------------
            ''        Label5.Enabled = False
            ''        Me.DatumOtpUpd.Enabled = False

            ''        mOtpUprava = TextBox1.Text
            ''        mOtpStanica = TextBox2.Text
            ''        mOtpBroj = TextBox3.Text

            ''        ' START novo 28.4: tlgrid
            ''        '''mOtpDatum = Me.DatumOtpUpd.Value.ToShortDateString
            ''        '''mMesec = mOtpDatum.Month.ToString
            ''        '''mDan = mOtpDatum.Day.ToString
            ''        '''mGodina = mOtpDatum.Year.ToString

            ''        '==========================
            ''        Button1_Click(Me, Nothing)
            ''        '==========================
            ''        Label5.Enabled = True
            ''        DatumOtpUpd.Enabled = True

            ''        DatumOtpUpd.Value = mOtpDatum

            ''        NadjiTovarniListGranicaUI(mOtpUprava, mOtpStanica, mOtpBroj, mOtpDatum, _
            ''                                  mRecID, mStanicaRecID, izPrUprava, izPrStanica, _
            ''                                  izSaobracaj, izZsUlPrelaz, izZsIzPrelaz, _
            ''                                  izNajava, izSifraTarife, izUgovor, _
            ''                                  mRetVal)

            ''        'unutar ovoga je popunjavanje tovarnog lista: IzmenaTL()

            ''        mPrUprava = izPrUprava
            ''        mPrStanica = izPrStanica
            ''        IzborSaobracaja = izSaobracaj

            ''        If iznajava <> "" Then
            ''            mNajava = izNajava
            ''        End If

            ''        mTarifa = izSifraTarife
            ''        mBrojUg = izUgovor

            ''        '-------------------------------------- Primenjene tarife -------------------------------------------
            ''        If DbVeza.State = ConnectionState.Closed Then
            ''            DbVeza.Open()
            ''        End If

            ''        Dim sql_trz1 As String = "SELECT dbo.ZsTarifa.SifraTarife, dbo.ZsTarifa.Opis FROM dbo.ZsTarifa " & _
            ''                                 "WHERE (dbo.ZsTarifa.SifraVS = '" & IzborSaobracaja & "')"

            ''        Dim sql_commTrz1 As New SqlClient.SqlCommand(sql_trz1, DbVeza)
            ''        Dim rdrTar As SqlClient.SqlDataReader
            ''        Dim combo_linija1 As String = ""
            ''        ComboBox1.Items.Clear()
            ''        rdrTar = sql_commTrz1.ExecuteReader(CommandBehavior.CloseConnection)
            ''        Do While rdrTar.Read()
            ''            combo_linija1 = rdrTar.GetString(0) & " - " & rdrTar.GetString(1)
            ''            ComboBox1.Items.Add(combo_linija1)
            ''        Loop
            ''        rdrTar.Close()
            ''        DbVeza.Close()

            ''    End If

            ''    PostaviPrelaz(izZsUlPrelaz, izZsIzPrelaz)

            ''    If mRetVal = "" Then
            ''        '--------------- prikaz tarife ----------------
            ''        gbTarifa.Visible = True
            ''        tbUgovor.Text = mBrojUg
            ''        If IzborSaobracaja = "4" Then
            ''            Me.Label13.Visible = False
            ''            Me.ComboBox1.Visible = False
            ''            tbUgovor.Focus()
            ''            tbUgovor.SelectionStart = 4
            ''        Else
            ''            Me.Label13.Visible = True
            ''            Me.ComboBox1.Visible = True
            ''            If tbUgovor.Text <> Nothing Then
            ''                Me.ComboBox1.SelectedIndex = 0
            ''            Else
            ''                If mTarifa = "36" Then
            ''                    Me.ComboBox1.SelectedIndex = 2
            ''                ElseIf mTarifa = "68" Then
            ''                    Me.ComboBox1.SelectedIndex = 5
            ''                Else
            ''                    Me.ComboBox1.SelectedIndex = -1
            ''                End If
            ''            End If
            ''            Me.ComboBox1.Focus()
            ''        End If

            ''        Me.btnPrihvati.Visible = False
            ''        Me.btnPreuzmi.Visible = True
            ''    Else
            ''        MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ''    End If

        End If
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
            Me.RadioButton4.Checked = True
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
            Me.RadioButton5.Checked = True
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
            Me.RadioButton6.Checked = True
        End If
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
    Private Sub RadioButton4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadioButton4.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub RadioButton5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadioButton5.KeyPress
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

    Private Sub gbSaobracaj_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbSaobracaj.Leave
        If Me.RadioButton4.Checked = True Then
            gbTranzit.Enabled = True
            gbOstalo.Enabled = False
            cb_Tip.Focus()
            
        Else
            gbOstalo.Enabled = True
            gbTranzit.Enabled = False
            Me.cb_Tip.SelectedIndex = -1
            Me.cbSmer1.SelectedIndex = -1
            Me.tbNalepnica.TabIndex = 0
            Me.tbUgovor.Text = ""

            If bVrstaSaobracaja = 2 Then
                TextBox1.Focus()
            ElseIf bVrstaSaobracaja = 3 Then
                TextBox1.Text = "0072"
                TextBox2.Text = "72"
                TextBox2.SelectionStart = 3
                TextBox2.Focus()
            End If
        End If
    End Sub

    Private Sub gbPosiljka_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbPosiljka.Leave
        If Me.RadioButton4.Checked = True Then
            gbTranzit.Enabled = True
            gbOstalo.Enabled = False
            cb_Tip.Focus()
        Else
            gbOstalo.Enabled = True
            gbTranzit.Enabled = False
            TextBox1.Focus()
        End If
    End Sub

    Private Sub cbSmer1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNalepnica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbSmer1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer1.Leave
        If cbSmer1.Text = Nothing Then
            cbSmer1.Focus()
        End If

    End Sub
    Private Sub RadioButton6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadioButton6.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub RadioButton7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadioButton7.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub UpdateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label5.Enabled = True
        Me.DatumOtpUpd.Enabled = True
        Me.tbGodina.Text = Now.Today.Year.ToString
        Me.cbSmer1.Text = StanicaUnosa
        Me.cbSmer1.Enabled = True

        If CarinskiAgent = "PROODOS" Then
            Me.gbProdos.Visible = True
            Me.NumericUpDown1.Text = mObrMesec
            Me.NumericUpDown2.Text = mObrGodina
        Else
            Me.gbProdos.Visible = False
        End If

        If GranicnaStanica = "D" Then
            Me.RadioButton4.Enabled = True
            Me.RadioButton5.Checked = True
            Me.RadioButton6.Enabled = True
        Else
            Label7.Text = "Preuzimanje podataka sa granicnog prelaza"
            Me.RadioButton4.Enabled = False
            Me.RadioButton6.Checked = True
            Me.RadioButton6.Enabled = True

            btnKB.Visible = True
            TextBox6.Visible = True
            Me.GroupBox1.Visible = True

            Me.TextBox1.Focus()
        End If

        Me.btnPrihvati.Visible = True
        Me.btnPreuzmi.Visible = False

        ''If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
        ''    Me.RadioButton4.Checked = True
        ''ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
        ''    Me.RadioButton5.Checked = True
        ''ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
        ''    Me.RadioButton6.Checked = True
        ''End If

        If RecordAction = "N" Then
            btnPrihvati.Text = "Prihvati"
            'Label7.Text = "Izmena podataka na tovarnom listu."
            Label5.Enabled = False
            Me.DatumOtpUpd.Enabled = False
        Else
            btnPrihvati.Text = "Brisi"
            Label7.Text = "Brisanje tovarnog lista iz baze podataka"
        End If

    End Sub
    Private Sub cb_Tip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cb_Tip.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub cb_Tip_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_Tip.Leave
        If cb_Tip.Text = Nothing Then
            cb_Tip.Focus()
        End If

    End Sub

    Private Sub btnPreuzmi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreuzmi.Click

        If mTarifa = "46" Then
            bVrstaPosiljke = "D"
        End If

        If Me.RadioButton4.Checked = True Then
            IzborSaobracaja = "4"
        End If
        If Me.RadioButton5.Checked = True Then
            IzborSaobracaja = "2"
        End If
        If Me.RadioButton6.Checked = True Then
            IzborSaobracaja = "3"
        End If
        If Me.RadioButton7.Checked = True Then
            IzborSaobracaja = "1"
        End If


        Me.Dispose()
        Me.Close()

        Dim form2 As New FormUpdateCimGr
        form2.ShowDialog()
        Close()

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

    Private Sub rbIzMakisa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbIzMakisa.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub rbZaMakis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbZaMakis.KeyPress
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
        'provera postojanja ugovora

        If IsNumeric(tbUgovor.Text) = True Then
            If tbUgovor.Text = Nothing Then
                If IzborSaobracaja = "4" Then
                    tbUgovor.Focus()
                Else
                    Me.ComboBox1.SelectedIndex = 0
                    Me.ComboBox1.Focus()
                End If
            Else
                Dim mRetVal As String
                Dim ug_mNazivKomitenta As String
                Dim ug_mPrimalac As String
                Dim ug_mVrstaObracuna As String

                '''NadjiUgovor(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, mRetVal)

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
                    mPrimalac = ug_mPrimalac
                    mVrstaObracuna = ug_mVrstaObracuna
                    LblKomitent.Text = ug_mNazivKomitenta
                    mSifraKorisnika = ug_mPrimalac
                    ''''''''''''''btnPreuzmi.Focus()

                Else
                    '_Kontrola_NemaUgovora = 1
                    ErrorProvider1.SetError(tbUgovor, "")
                    MessageBox.Show("Takav ugovor ne postoji u bazi podataka!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation)
                    LblKomitent.Text = ""

                    '_temp_mBrojUg = tbUgovor.Text ' proveriti kako radi do kraja

                    tbUgovor.Focus()
                End If
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
                btnPreuzmi.Focus()
                mTarifa = Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 2)
                mVrstaObracuna = "RO"

            End If
            ErrorProvider1.SetError(ComboBox1, "")
        End If
    End Sub

    Private Sub RadioButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.Click
        gbTranzit.Enabled = False
        gbOstalo.Enabled = True
        bVrstaSaobracaja = 2

        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""

        TextBox1.Focus()

    End Sub

    Private Sub RadioButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton6.Click
        gbTranzit.Enabled = False
        gbOstalo.Enabled = True
        TextBox1.Text = "0072"
        TextBox2.Text = "72"
        bVrstaSaobracaja = 3
        TextBox1.Focus()

    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        TextBox2.Text = Microsoft.VisualBasic.Right(TextBox1.Text, 2)
        TextBox2.SelectionStart = 3

    End Sub

    Private Sub RadioButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton7.Click
        gbTranzit.Enabled = False
        gbOstalo.Enabled = True
        bVrstaSaobracaja = 1
        TextBox1.Focus()
    End Sub

    Private Sub RadioButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.Click
        gbTranzit.Enabled = True
        gbOstalo.Enabled = False
        Me.cbSmer1.Text = StanicaUnosa
        cb_Tip.Focus()

    End Sub

    Private Sub tbUgovor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.Leave
        If mVrstaObracuna = "RO" Then
            Me.gbVrP.Visible = True
        Else
            If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "22" Then
                If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                   Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                   Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

                    Me.gbVrP.Visible = True
                    Me.rbG.Enabled = False
                Else
                    Me.gbVrP.Visible = False
                End If
            Else
                If tbUgovor.Text = "300899" Or mBrojUg = "300888" Then
                    Me.gbVrP.Visible = True
                Else
                    If tbUgovor.Text = "844514" Or tbUgovor.Text = "844516" Then
                        Me.gbVrP.Visible = True
                    Else
                        Me.gbVrP.Visible = False
                    End If
                End If

                If tbUgovor.Text = "300823" Then
                    Me.gbVrP.Visible = True
                    Me.rbP.Enabled = False
                    Me.rbG.Enabled = True
                    Me.rbG.Checked = True
                    Me.rbV.Enabled = False
                    mVrstaPrevoza = "G"
                End If
                If tbUgovor.Text = "300824" Then
                    Me.gbVrP.Visible = True
                    Me.rbP.Enabled = False
                    Me.rbG.Enabled = False
                    Me.rbV.Enabled = True
                    Me.rbV.Checked = True
                    mVrstaPrevoza = "V"
                End If

            End If
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

    Private Sub tbNalepnica_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNalepnica.Leave
        Me.btnPrihvati.Focus()

    End Sub

    Private Sub tbUgovor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.GotFocus
        Me.tbUgovor.SelectionStart = 6

    End Sub


    Private Sub btnUpravaPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKB.Click

        If Len(TextBox3.Text) < 6 Then
            Dim tmp_kbotp As String
            Dim tmp_brojotp As String

            tmp_brojotp = TextBox3.Text.ToString
            b5Modul(tmp_brojotp, tmp_kbotp)
            TextBox6.Text = tmp_kbotp
            ErrorProvider1.SetError(TextBox6, "")
            Me.btnPrihvati.Focus()
        Else
            TextBox6.Text = ""
            ErrorProvider1.SetError(TextBox6, "Broj otpravljanja ima 6 cifara!")
            TextBox3.Focus()

        End If

    End Sub

    Private Sub TextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.Leave
        btnPrihvati.Focus()

    End Sub
End Class
