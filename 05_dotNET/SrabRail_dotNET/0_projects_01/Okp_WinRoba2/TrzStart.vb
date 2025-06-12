Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection
Imports System.Windows.Forms.MessageBoxOptions


Public Class TrzStart
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FlexMaskEditBox1 As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbKolska As System.Windows.Forms.RadioButton
    Friend WithEvents rbDencana As System.Windows.Forms.RadioButton
    Friend WithEvents gbSaobracaj As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbsSatVoza As System.Windows.Forms.TextBox
    Friend WithEvents tbsBrojVoza As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbkBrojVoza As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbCORO As System.Windows.Forms.CheckBox
    Friend WithEvents cbRucnaNajava As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TrzStart))
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.gbSaobracaj = New System.Windows.Forms.GroupBox
        Me.rbKolska = New System.Windows.Forms.RadioButton
        Me.rbDencana = New System.Windows.Forms.RadioButton
        Me.FlexMaskEditBox1 = New FlxMaskBox.FlexMaskEditBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbkBrojVoza = New System.Windows.Forms.TextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.tbsSatVoza = New System.Windows.Forms.TextBox
        Me.tbsBrojVoza = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cbCORO = New System.Windows.Forms.CheckBox
        Me.cbRucnaNajava = New System.Windows.Forms.CheckBox
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSaobracaj.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mesec"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(16, 35)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(88, 22)
        Me.NumericUpDown1.TabIndex = 0
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown2.Location = New System.Drawing.Point(160, 35)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {2006, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(96, 22)
        Me.NumericUpDown2.TabIndex = 1
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown2.Value = New Decimal(New Integer() {2006, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(160, 213)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Izbor tarife"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(160, 392)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Vrsta posiljke"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"1. Spt 38", "2. Tea 9291", "3. Ugovor"})
        Me.ComboBox1.Location = New System.Drawing.Point(152, 229)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(272, 24)
        Me.ComboBox1.TabIndex = 2
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox2.Items.AddRange(New Object() {"1. Pojedinacna posiljka", "2. Grupa kola", "3. Voz", "4. Pojedinacna posiljka - rucni unos"})
        Me.ComboBox2.Location = New System.Drawing.Point(152, 408)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(277, 24)
        Me.ComboBox2.TabIndex = 4
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(248, 464)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(77, 64)
        Me.btnPrihvati.TabIndex = 5
        Me.btnPrihvati.Text = "Prihvati"
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(349, 464)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(77, 64)
        Me.btnOtkazi.TabIndex = 6
        Me.btnOtkazi.Text = "Otkazi"
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Enabled = False
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox3.Items.AddRange(New Object() {"100600 Proodos", "050600 Fersed Skopje", "060600 TCL", "080600 TT Cargo"})
        Me.ComboBox3.Location = New System.Drawing.Point(8, 424)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(72, 23)
        Me.ComboBox3.TabIndex = 3
        Me.ComboBox3.Visible = False
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(160, 264)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 23)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Izbor ugovora"
        '
        'gbSaobracaj
        '
        Me.gbSaobracaj.Controls.Add(Me.rbKolska)
        Me.gbSaobracaj.Controls.Add(Me.rbDencana)
        Me.gbSaobracaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbSaobracaj.Location = New System.Drawing.Point(152, 152)
        Me.gbSaobracaj.Name = "gbSaobracaj"
        Me.gbSaobracaj.Size = New System.Drawing.Size(272, 53)
        Me.gbSaobracaj.TabIndex = 6
        Me.gbSaobracaj.TabStop = False
        Me.gbSaobracaj.Text = " [ Vrsta posiljke ] "
        '
        'rbKolska
        '
        Me.rbKolska.Checked = True
        Me.rbKolska.Location = New System.Drawing.Point(18, 20)
        Me.rbKolska.Name = "rbKolska"
        Me.rbKolska.TabIndex = 26
        Me.rbKolska.TabStop = True
        Me.rbKolska.Text = "Kolska"
        '
        'rbDencana
        '
        Me.rbDencana.Location = New System.Drawing.Point(162, 20)
        Me.rbDencana.Name = "rbDencana"
        Me.rbDencana.Size = New System.Drawing.Size(86, 24)
        Me.rbDencana.TabIndex = 27
        Me.rbDencana.Text = "Dencana"
        '
        'FlexMaskEditBox1
        '
        Me.FlexMaskEditBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FlexMaskEditBox1.Location = New System.Drawing.Point(8, 496)
        Me.FlexMaskEditBox1.Mask = "99 99 9999 999 9"
        Me.FlexMaskEditBox1.Name = "FlexMaskEditBox1"
        Me.FlexMaskEditBox1.Size = New System.Drawing.Size(56, 20)
        Me.FlexMaskEditBox1.TabIndex = 15
        Me.FlexMaskEditBox1.Visible = False
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 472)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Individualni broj kola"
        Me.Label13.Visible = False
        '
        'tbUgovor
        '
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(152, 280)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(272, 22)
        Me.tbUgovor.TabIndex = 3
        Me.tbUgovor.Text = ""
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(152, 309)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(266, 16)
        Me.Label5.TabIndex = 25
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label7)
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox8.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(152, 16)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(272, 80)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = " [ Obracunski period ] "
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(183, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Godina"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 23)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Komercijalni broj voza"
        '
        'tbkBrojVoza
        '
        Me.tbkBrojVoza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbkBrojVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbkBrojVoza.Location = New System.Drawing.Point(120, 64)
        Me.tbkBrojVoza.MaxLength = 10
        Me.tbkBrojVoza.Name = "tbkBrojVoza"
        Me.tbkBrojVoza.Size = New System.Drawing.Size(96, 22)
        Me.tbkBrojVoza.TabIndex = 1
        Me.tbkBrojVoza.Text = "0"
        Me.tbkBrojVoza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(-88, 32)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 62
        Me.PictureBox2.TabStop = False
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(32, 96)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 23)
        Me.Label22.TabIndex = 61
        Me.Label22.Text = "Sat voza"
        '
        'tbsSatVoza
        '
        Me.tbsSatVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbsSatVoza.Location = New System.Drawing.Point(120, 96)
        Me.tbsSatVoza.MaxLength = 5
        Me.tbsSatVoza.Name = "tbsSatVoza"
        Me.tbsSatVoza.Size = New System.Drawing.Size(96, 22)
        Me.tbsSatVoza.TabIndex = 2
        Me.tbsSatVoza.Text = "00"
        Me.tbsSatVoza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbsBrojVoza
        '
        Me.tbsBrojVoza.BackColor = System.Drawing.Color.White
        Me.tbsBrojVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbsBrojVoza.Location = New System.Drawing.Point(158, 20)
        Me.tbsBrojVoza.MaxLength = 5
        Me.tbsBrojVoza.Name = "tbsBrojVoza"
        Me.tbsBrojVoza.Size = New System.Drawing.Size(96, 23)
        Me.tbsBrojVoza.TabIndex = 0
        Me.tbsBrojVoza.Text = "0"
        Me.tbsBrojVoza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbkBrojVoza)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.tbsSatVoza)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 264)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(80, 64)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbsBrojVoza)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(152, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 53)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ Saobracajni broj voza ]  "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 48)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'cbCORO
        '
        Me.cbCORO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbCORO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCORO.ForeColor = System.Drawing.Color.Red
        Me.cbCORO.Location = New System.Drawing.Point(152, 328)
        Me.cbCORO.Name = "cbCORO"
        Me.cbCORO.Size = New System.Drawing.Size(160, 24)
        Me.cbCORO.TabIndex = 28
        Me.cbCORO.Text = "Centralni obracun"
        Me.cbCORO.Visible = False
        '
        'cbRucnaNajava
        '
        Me.cbRucnaNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRucnaNajava.Location = New System.Drawing.Point(152, 352)
        Me.cbRucnaNajava.Name = "cbRucnaNajava"
        Me.cbRucnaNajava.Size = New System.Drawing.Size(160, 24)
        Me.cbRucnaNajava.TabIndex = 29
        Me.cbRucnaNajava.Text = "Najava nije uneta u bazu"
        '
        'TrzStart
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 544)
        Me.Controls.Add(Me.cbRucnaNajava)
        Me.Controls.Add(Me.cbCORO)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbUgovor)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.FlexMaskEditBox1)
        Me.Controls.Add(Me.gbSaobracaj)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TrzStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tranzit"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSaobracaj.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim SifreKorisnika As New ArrayList
    Dim VrstaObracuna As New ArrayList
    Private Sub TrzStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '---------------- Inicijalizacija --------------------
        Me.NumericUpDown1.Text = Today.Month
        Me.NumericUpDown2.Text = Today.Year
        Me.tbsBrojVoza.Text = msBrojVoza
        Me.tbsSatVoza.Text = mSatVoza
        Me.ComboBox1.Text = mTarifa
        If mBrojUg = "000000" Then
            Me.tbUgovor.Clear()
        Else
            Me.tbUgovor.Text = mBrojUg
        End If
        If IzborSaobracaja <> "4" Then
            cbRucnaNajava.Visible = False
        End If
        '---------------- End Inicijalizacija --------------------

        mAkcija = "New"

        'mObrMesec = Today.Month
        'mObrGodina = Today.Year

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

        '-------------------- postavljanje racunskog meseca ---------------------
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim sql_text1 As String = "SELECT MesecUnosa, GodinaUnosa FROM RacMesec " & _
                                  "WHERE (VSaob = '" & IzborSaobracaja & "')"
        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrRm.Read()
            Me.NumericUpDown1.Text = rdrRm.GetString(0)
            Me.NumericUpDown2.Text = rdrRm.GetString(1)
        Loop
        rdrRm.Close()

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim _KontrolaTrzStart As Int16 = 0

        If Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "1" Then
            mVrstaPrevoza = "P"
        ElseIf Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "2" Then
            mVrstaPrevoza = "G"
        ElseIf Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "3" Then
            mVrstaPrevoza = "V"
        End If

        mObrMesec = NumericUpDown1.Value
        mObrGodina = NumericUpDown2.Value

        '''If Not IsNumeric(tbsBrojVoza.FormattedText) Then Throw New System.Exception("Šifra otpravne uprave neispravna !")
        '-------------------------------------------------------------
        If Me.cbCORO.Visible = True Then
            If Me.cbCORO.Checked = True Then
                mVrstaObracuna = "CO"
            Else
                mVrstaObracuna = "RO"
            End If
        End If

        If Me.cbRucnaNajava.Checked = True Then
            mRucnaNajava = "D"
        Else
            mRucnaNajava = "N"
        End If

        If CType(tbsBrojVoza.Text, Int32) > 0 Then
            _KontrolaTrzStart = 1
        Else
            _KontrolaTrzStart = 0
        End If

        If Microsoft.VisualBasic.Left(ComboBox1.Text, 2) = "00" Then
            If tbUgovor.Text = Nothing Then
                _KontrolaTrzStart = 0
            Else
                _KontrolaTrzStart = 1
            End If
        Else
            If ComboBox2.Text = Nothing Then
                _KontrolaTrzStart = 0
            Else
                _KontrolaTrzStart = 1
            End If
        End If
        '--------------------------------------------------------------

        If _KontrolaTrzStart = 0 Then
            MessageBox.Show("Niste uneli sve potrebne podatke. Ponovite unos.", "Kontrola unosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbsBrojVoza.Focus()

        Else
            msBrojVoza = CType(tbsBrojVoza.Text, Int32)
            mNajava = tbkBrojVoza.Text
            mSatVoza = tbsSatVoza.Text

            'If tbUgovor.Text.Empty.ToString = "" Then

            If tbUgovor.Text = "" Then
                mBrojUg = "000000"
            Else
                mBrojUg = tbUgovor.Text
            End If

            Me.Dispose()

            If Me.rbKolska.Checked = True Then
                bVrstaPosiljke = "K"
            Else
                bVrstaPosiljke = "D"
            End If

            If IzborSaobracaja = "1" Or IzborSaobracaja = "2" Or IzborSaobracaja = "3" Then
                Dim form2 As New UnosExIm 'unosei

                If mTarifa = "00" Then
                    form2.Text = "Ugovor: " & mBrojUg & "  ¦   Racunski mesec : " & mObrMesec & " / " & mObrGodina
                Else
                    form2.Text = ComboBox1.SelectedItem & "  ¦  Racunski mesec : " & mObrMesec & " / " & mObrGodina
                End If
                form2.ShowDialog()
                Close()
            ElseIf IzborSaobracaja = "4" Then
                Dim form2 As New UnosTrz

                If mTarifa = "00" Then
                    form2.Text = "Ugovor: " & mBrojUg
                Else
                    form2.Text = ComboBox1.SelectedItem
                End If
                form2.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        mTarifa = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)
        If mTarifa = "00" Then 'Ugovor
            ComboBox2.Text = ""
            Label4.Enabled = True
            tbUgovor.Enabled = True
        Else
            tbUgovor.Text = " "
            Label4.Enabled = False
            tbUgovor.Enabled = False
            ComboBox2.Enabled = True
            ComboBox2.Focus()
        End If
    End Sub
    Private Sub NumericUpDown1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumericUpDown1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub NumericUpDown2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumericUpDown2.KeyPress
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

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
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

    Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        mTarifa = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)
        If ComboBox1.Text = Nothing Then
            ErrorProvider1.SetError(ComboBox1, "Obavezan izbor tarife!")
            ComboBox1.Focus()
        Else
            ErrorProvider1.SetError(ComboBox1, "")
        End If
    End Sub

    Private Sub ComboBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.Leave
        If ComboBox3.Text = Nothing Then
        Else
            mSifraKorisnika = SifreKorisnika.ToArray.GetValue(ComboBox3.SelectedIndex)
            mVrstaObracuna = VrstaObracuna.ToArray.GetValue(ComboBox3.SelectedIndex)
        End If
    End Sub
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        mObrGodina = NumericUpDown2.Value
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        mObrMesec = NumericUpDown1.Value

    End Sub

    Private Sub ComboBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox3.Validating
        If ComboBox3.Text = Nothing Then
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUgovor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUgovor.Validating
        If IsNumeric(tbUgovor.Text) = True Then
            If tbUgovor.Text = Nothing Then
                ComboBox1.Focus()
            Else
                Dim mRetVal As String
                Dim ug_mNazivKomitenta As String
                Dim ug_mPrimalac As String
                Dim ug_mSuma As Int32
                Dim ug_mVrstaObracuna As String

                ' 11.5.2011 NadjiUgovor(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, mRetVal)
                NadjiUgovor2(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, ug_mSuma, mRetVal)

                If mRetVal = "" Then
                    _Kontrola_NemaUgovora = 0
                    _temp_mBrojUg = ""

                    mPrimalac = ug_mPrimalac
                    mVrstaObracuna = ug_mVrstaObracuna
                    'Label5.Text = ug_mNazivKomitenta
                    mSifraKorisnika = ug_mPrimalac
                    mVrstaObracuna = ug_mVrstaObracuna

                    If ug_mSuma > 1 Then
                        Me.cbCORO.Visible = True
                        cbCORO.Focus()
                    Else
                        Label5.Text = ug_mNazivKomitenta
                        Me.cbCORO.Visible = False
                    End If

                    '---------
                    If mTarifa = "00" Then
                        If mVrstaObracuna = "RO" Or ug_mSuma > 1 Then
                            ComboBox2.Items.Clear()
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.Items.Add("2. Grupa kola")
                            ComboBox2.Items.Add("3. Kompletni vozovi")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        Else
                            ComboBox2.Items.Clear()
                            If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "01" Or _
                                   Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "04" Or _
                                   Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "05" Or _
                                   Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "06" Or _
                                   Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "96" Or _
                                   Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "97" Or _
                                   Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "73" Then
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "92" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "93" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "22" Then ''''

                                If Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "922" Then '
                                    If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                                       Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                                       Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then
                                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                        ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                        ComboBox2.SelectedIndex = 0
                                        Me.btnPrihvati.Focus()
                                    Else
                                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                        ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                        ComboBox2.SelectedIndex = 0
                                        Me.btnPrihvati.Focus()
                                    End If

                                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "822" Then '
                                    If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                                        Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                                        Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

                                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                        ComboBox2.Items.Add("3. Kompletni vozovi")
                                        ComboBox2.SelectedText = "3. Kompletni vozovi"
                                        ComboBox2.SelectedIndex = 0
                                        Me.btnPrihvati.Focus()
                                    Else
                                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                        ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                        ComboBox2.SelectedIndex = 0
                                        Me.btnPrihvati.Focus()
                                    End If
                                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "122" Then '
                                    If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                                        Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                                        Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

                                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                        ComboBox2.Items.Add("3. Kompletni vozovi")
                                        ComboBox2.SelectedText = "3. Kompletni vozovi"
                                        ComboBox2.SelectedIndex = 0
                                        Me.btnPrihvati.Focus()
                                    Else
                                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                        ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                        ComboBox2.SelectedIndex = 0
                                        Me.btnPrihvati.Focus()
                                    End If
                                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "222" Then '
                                    If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                                        Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                                        Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

                                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                        ComboBox2.Items.Add("3. Kompletni vozovi")
                                        ComboBox2.SelectedText = "3. Kompletni vozovi"
                                        ComboBox2.SelectedIndex = 0
                                        Me.btnPrihvati.Focus()
                                    Else
                                        If tbUgovor.Text = "031222" Then
                                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                            ComboBox2.Items.Add("2. Grupa kola")
                                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                            ComboBox2.SelectedIndex = 0
                                            Me.btnPrihvati.Focus()
                                        Else
                                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                            ComboBox2.SelectedIndex = 0
                                            Me.btnPrihvati.Focus()

                                        End If
                                    End If
                                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "322" Then '
                                    If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                                        Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                                        Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

                                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                        ComboBox2.Items.Add("3. Kompletni vozovi")
                                        ComboBox2.SelectedText = "3. Kompletni vozovi"
                                        ComboBox2.SelectedIndex = 0
                                        Me.btnPrihvati.Focus()
                                    Else
                                        If tbUgovor.Text = "031322" Then
                                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                            ComboBox2.Items.Add("2. Grupa kola")
                                            ComboBox2.SelectedIndex = 0
                                            Me.btnPrihvati.Focus()
                                        Else
                                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                            ComboBox2.SelectedIndex = 0
                                            Me.btnPrihvati.Focus()

                                        End If
                                    End If
                                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "422" Then '
                                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                    ComboBox2.Items.Add("2. Grupa kola")
                                    ComboBox2.SelectedIndex = 0
                                    Me.btnPrihvati.Focus()
                                End If
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "33" Or Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "44" Or _
                                   Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "66" Then
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "02" Then
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedText = "2. Grupa kola"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "67" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedIndex = 1
                                ComboBox2.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "42" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedIndex = 0
                                ComboBox2.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "68" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            End If

                            If tbUgovor.Text = "081522" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedText = "2. Grupa kola"
                                ComboBox2.SelectedIndex = 1
                            End If

                            If tbUgovor.Text = "300899" Or tbUgovor.Text = "300888" Or _
                               tbUgovor.Text = "300999" Or tbUgovor.Text = "301599" Or _
                               tbUgovor.Text = "301199" Or tbUgovor.Text = "301299" Or _
                               tbUgovor.Text = "301399" Or tbUgovor.Text = "301499" Then

                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            End If
                            If tbUgovor.Text = "011470" Or tbUgovor.Text = "011471" Or tbUgovor.Text = "011472" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                            End If
                            If tbUgovor.Text = "011570" Or tbUgovor.Text = "011571" Or tbUgovor.Text = "011572" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                            End If
                            If tbUgovor.Text = "844514" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            End If

                            If tbUgovor.Text = "844517" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            End If

                            If tbUgovor.Text = "835745" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            End If

                            If tbUgovor.Text = "835758" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            End If

                            If tbUgovor.Text = "301522" Or "301622" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            End If

                            If tbUgovor.Text = "835753" Or tbUgovor.Text = "955401" Or tbUgovor.Text = "836902" Or tbUgovor.Text = "835771" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                            End If

                            If tbUgovor.Text = "300823" Or tbUgovor.Text = "300923" Or tbUgovor.Text = "301523" Or _
                               tbUgovor.Text = "301623" Or _
                               tbUgovor.Text = "301123" Or tbUgovor.Text = "301198" Or tbUgovor.Text = "301223" Or _
                               tbUgovor.Text = "301323" Or tbUgovor.Text = "301298" Or tbUgovor.Text = "301398" Or _
                               tbUgovor.Text = "301423" Or tbUgovor.Text = "301498" Or tbUgovor.Text = "301598" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedText = "2. Grupa kola"
                                ComboBox2.SelectedIndex = 0
                            End If

                            If tbUgovor.Text = "300824" Or tbUgovor.Text = "300924" Or tbUgovor.Text = "301024" Or _
                               tbUgovor.Text = "301124" Or tbUgovor.Text = "301224" Or tbUgovor.Text = "301324" Or tbUgovor.Text = "301324" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                            End If
                            'prodos 2014?
                            If tbUgovor.Text = "101322" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                            End If
                            If tbUgovor.Text = "101333" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedText = "2. Grupa kola"
                                ComboBox2.SelectedIndex = 0
                            End If
                            If tbUgovor.Text = "101344" Or tbUgovor.Text = "101345" Then
                                ComboBox2.Items.Clear()
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                            End If
                            'Intercontainer , Adria Combi
                            If mSifraKorisnika = 43 Then
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf mSifraKorisnika = 18 Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            ElseIf mSifraKorisnika = 82 Then 'Adria Combi
                                ComboBox2.Text = "1. Pojedinacna posiljka"
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                            End If
                        End If
                    End If
                    ErrorProvider1.SetError(tbUgovor, "")
                Else
                    _Kontrola_NemaUgovora = 1
                    ErrorProvider1.SetError(tbUgovor, "")
                    MessageBox.Show("Takav ugovor ne postoji u bazi podataka! Primenite redovnu tarifu.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation)
                    Label5.Text = " "

                    _temp_mBrojUg = tbUgovor.Text ' proveriti kako radi do kraja

                    ComboBox1.Focus()
                End If
            End If
        Else
            ErrorProvider1.SetError(tbUgovor, "Neispravan unos!")
            tbUgovor.Focus()
        End If
    End Sub
    Private Sub tbUgovor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.Leave
        Me.btnPrihvati.Focus()
    End Sub

    Private Sub rbDencana_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbDencana.CheckedChanged
        If rbDencana.Checked = True Then
            ComboBox1.Items.Clear()
            If IzborSaobracaja = 4 Then
                ComboBox1.Items.Add("38 - Redovna tarifa")
            Else
                ComboBox1.Items.Add("36 - Redovna tarifa")
                ComboBox1.Items.Add("46 - Ekspresna tarifa")
            End If
            ComboBox1.Items.Add("68 - Tea tarifa")
        Else
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

        End If
    End Sub

    Private Sub rbDencana_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbDencana.Leave
        ComboBox1.Focus()

    End Sub

    Private Sub gbSaobracaj_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbSaobracaj.Leave
        ComboBox1.Focus()
    End Sub


    Private Sub rbDencana_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbDencana.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub rbKolska_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbKolska.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub tbBrojVoza_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsBrojVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbSatVoza_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsSatVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbkBrojVoza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbkBrojVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbsBrojVoza_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbsBrojVoza.Validating
        If IsNumeric(tbsBrojVoza.Text) = True Then
            If tbsBrojVoza.Text = "" Then
                tbsBrojVoza.Text = "0"
            End If
            If CType(tbsBrojVoza.Text, Int32) = 0 Then
                ErrorProvider1.SetError(tbsBrojVoza, "Obavezan unos saobracajnog broja voza!")
                tbsBrojVoza.Focus()
            Else
                ErrorProvider1.SetError(tbsBrojVoza, "")
            End If
        Else
            ErrorProvider1.SetError(tbsBrojVoza, "Tekst - neispravan unos!")
            tbsBrojVoza.Focus()
        End If
    End Sub

    Private Sub ComboBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox2.Validating
        If ComboBox2.Text = Nothing Then
            ErrorProvider1.SetError(ComboBox2, "Obavezan izbor vrste posiljke!")
            ComboBox2.Focus()
        Else
            ErrorProvider1.SetError(ComboBox2, "")
            If Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "1" Then
                mVrstaPrevoza = "P"
            ElseIf Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "2" Then
                mVrstaPrevoza = "G"
            ElseIf Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "3" Then
                mVrstaPrevoza = "V"
            End If
        End If
    End Sub

    Private Sub tbsSatVoza_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbsSatVoza.Validating
        If CType(tbsSatVoza.Text, Int16) > 23 Then
            ErrorProvider1.SetError(tbsSatVoza, "Sat voza je manji od 24")
            tbsSatVoza.Focus()
        Else
            ErrorProvider1.SetError(tbsSatVoza, "")
        End If
    End Sub

    Private Sub ComboBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Click
        Dim aa As String = "1"

        If mTarifa = "00" Then
            If mVrstaObracuna = "RO" Then
                ComboBox2.Items.Clear()
                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                ComboBox2.Items.Add("2. Grupa kola")
                ComboBox2.Items.Add("3. Kompletni vozovi")
            Else
                ComboBox2.Items.Clear()
                If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Then
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.Text = "1. Pojedinacna posiljka"
                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "01" Or _
                       Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "05" Or _
                       Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "06" Or _
                       Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "96" Or _
                       Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "97" Or _
                       Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "73" Then

                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.Text = "3. Kompletni vozovi"
                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "02" Then
                    ComboBox2.Items.Add("2. Grupa kola")
                    ComboBox2.Text = "2. Grupa kola"
                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "22" Then ''''
                    If Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "922" Then '
                        If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                           Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                           Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        Else
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        End If

                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "822" Then '
                        If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                            Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                            Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.Items.Add("3. Kompletni vozovi")
                            ComboBox2.SelectedText = "3. Kompletni vozovi"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        Else
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        End If
                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "222" Then '
                        If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                            Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                            Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.Items.Add("3. Kompletni vozovi")
                            ComboBox2.SelectedText = "3. Kompletni vozovi"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        Else
                            If tbUgovor.Text = "031222" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            Else
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()

                            End If
                        End If
                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "322" Then '
                        If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                            Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                            Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.Items.Add("3. Kompletni vozovi")
                            ComboBox2.SelectedText = "3. Kompletni vozovi"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        Else
                            If tbUgovor.Text = "031322" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            Else
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()

                            End If
                        End If
                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "422" Then '
                        If Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "10" Or _
                            Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "11" Or _
                            Microsoft.VisualBasic.Left(tbUgovor.Text, 2) = "12" Then

                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.Items.Add("2. Grupa kola")
                            'ComboBox2.SelectedText = "3. Kompletni vozovi"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        Else
                            If tbUgovor.Text = "031422" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()
                            Else
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                                Me.btnPrihvati.Focus()

                            End If
                        End If
                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "522" Then
                        If tbUgovor.Text = "031522" Then
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.Items.Add("2. Grupa kola")
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        Else
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        End If
                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 3) = "622" Then
                        If tbUgovor.Text = "031622" Or tbUgovor.Text = "081622" Then
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.Items.Add("2. Grupa kola")
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        Else
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0
                            Me.btnPrihvati.Focus()
                        End If
                    End If
                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "33" Or Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "44" Or _
                       Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "66" Then
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.SelectedText = "3. Kompletni vozovi"
                    ComboBox2.SelectedIndex = 0
                    Me.btnPrihvati.Focus()
                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.Text = "1. Pojedinacna posiljka"
                    ComboBox2.SelectedIndex = 0
                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "67" Then
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Then
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.Text = "1. Pojedinacna posiljka"
                End If
                If tbUgovor.Text = "081522" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.Items.Add("2. Grupa kola")
                    ComboBox2.SelectedText = "2. Grupa kola"
                    ComboBox2.SelectedIndex = 1
                End If
                If tbUgovor.Text = "300899" Or tbUgovor.Text = "300888" Or _
                   tbUgovor.Text = "300999" Or tbUgovor.Text = "301599" Or _
                   tbUgovor.Text = "301199" Or tbUgovor.Text = "301299" Or tbUgovor.Text = "301399" Or _
                   tbUgovor.Text = "301499" Then

                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.Items.Add("2. Grupa kola")
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                    ComboBox2.SelectedIndex = 0
                ElseIf tbUgovor.Text = "844514" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                    ComboBox2.SelectedIndex = 0
                ElseIf tbUgovor.Text = "844516" Or tbUgovor.Text = "8355753" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.SelectedText = "3. Kompletni vozovi"
                    ComboBox2.SelectedIndex = 0
                End If

                If tbUgovor.Text = "300823" Or tbUgovor.Text = "300923" Or tbUgovor.Text = "301523" Or tbUgovor.Text = "301623" Or _
                   tbUgovor.Text = "301223" Or tbUgovor.Text = "301323" Or tbUgovor.Text = "301423" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("2. Grupa kola")
                    ComboBox2.SelectedText = "2. Grupa kola"
                    ComboBox2.SelectedIndex = 0
                End If
                If tbUgovor.Text = "101070" Or tbUgovor.Text = "111070" Or tbUgovor.Text = "121070" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("2. Grupa kola")
                    ComboBox2.SelectedText = "2. Grupa kola"
                    ComboBox2.SelectedIndex = 0
                End If
                If tbUgovor.Text = "300824" Or tbUgovor.Text = "300924" Or tbUgovor.Text = "301524" Or tbUgovor.Text = "301624" Or _
                   tbUgovor.Text = "301224" Or tbUgovor.Text = "301324" Or tbUgovor.Text = "301424" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.SelectedText = "3. Kompletni vozovi"
                    ComboBox2.SelectedIndex = 0
                End If
                If tbUgovor.Text = "011470" Or tbUgovor.Text = "011471" Or tbUgovor.Text = "011472" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.SelectedText = "3. Kompletni vozovi"
                    ComboBox2.SelectedIndex = 0
                End If
                'prodos 2014?
                If tbUgovor.Text = "101322" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                    ComboBox2.SelectedIndex = 0
                End If
                If tbUgovor.Text = "101333" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("2. Grupa kola")
                    ComboBox2.SelectedText = "2. Grupa kola"
                    ComboBox2.SelectedIndex = 0
                End If
                If tbUgovor.Text = "101344" Or tbUgovor.Text = "101345" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.SelectedText = "3. Kompletni vozovi"
                    ComboBox2.SelectedIndex = 0
                End If
                If tbUgovor.Text = "600301" And cbCORO.Checked Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.SelectedText = "3. Kompletni vozovi"
                    ComboBox2.SelectedIndex = 0
                End If
                If tbUgovor.Text = "401655" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.SelectedText = "3. Kompletni vozovi"
                    ComboBox2.SelectedIndex = 0
                End If
                If tbUgovor.Text = "251655" Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.SelectedText = "3. Kompletni vozovi"
                    ComboBox2.SelectedIndex = 0
                End If
                If tbUgovor.Text = "600302" And cbCORO.Checked Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add("2. Grupa kola")
                    ComboBox2.SelectedText = "2. Grupa kola"
                    ComboBox2.SelectedIndex = 0
                End If
                'za Intercontainer
                If mSifraKorisnika = 43 Then
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                    ComboBox2.Text = "3. Kompletni vozovi"
                ElseIf mSifraKorisnika = 18 Then
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.Text = "1. Pojedinacna posiljka"
                ElseIf mSifraKorisnika = 82 Then
                    ComboBox2.Text = "1. Pojedinacna posiljka"
                    ComboBox2.Items.Add("1. Pojedinacna posiljka")
                    ComboBox2.Items.Add("2. Grupa kola")
                    ComboBox2.Items.Add("3. Kompletni vozovi")
                End If
            End If
        Else
            ComboBox2.Items.Clear()
            If rbDencana.Checked = True Then
                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                ComboBox2.SelectedIndex = 0
            Else
                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                ComboBox2.Items.Add("2. Grupa kola")
                ComboBox2.Items.Add("3. Kompletni vozovi")
            End If
        End If
        ComboBox2.DroppedDown = True

    End Sub

    
End Class
