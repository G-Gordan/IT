Imports System.Data.SqlClient

Public Class Form1
    Inherits System.Windows.Forms.Form
    'Public Const ConnectionString As String = "Server=10.0.4.31;DataBase=OkpWinRoba;User=Radnik;Password=roba2006"
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgKorekc As System.Windows.Forms.DataGrid
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbUg As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnDodaj As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DataGrid4 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid5 As System.Windows.Forms.DataGrid
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbRedBr As System.Windows.Forms.TextBox
    Friend WithEvents dgKorIzv As System.Windows.Forms.DataGrid
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbUg = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.dgKorekc = New System.Windows.Forms.DataGrid
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.dgKorIzv = New System.Windows.Forms.DataGrid
        Me.btnDodaj = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.DataGrid4 = New System.Windows.Forms.DataGrid
        Me.DataGrid5 = New System.Windows.Forms.DataGrid
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.tbRedBr = New System.Windows.Forms.TextBox
        CType(Me.dgKorekc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgKorIzv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(320, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Korekcije  - rekapitulacija"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Osnovni ugovor:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Godina/Mesec:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(272, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Šifra i naziv špedicije:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(656, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Procenat:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(656, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Valuta:"
        '
        'tbUg
        '
        Me.tbUg.BackColor = System.Drawing.Color.Coral
        Me.tbUg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUg.Location = New System.Drawing.Point(136, 16)
        Me.tbUg.Name = "tbUg"
        Me.tbUg.Size = New System.Drawing.Size(48, 22)
        Me.tbUg.TabIndex = 0
        Me.tbUg.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(136, 40)
        Me.TextBox2.MaxLength = 4
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(48, 22)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = ""
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(760, 32)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(72, 22)
        Me.TextBox4.TabIndex = 113
        Me.TextBox4.Text = "0.0"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(184, 40)
        Me.TextBox3.MaxLength = 2
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(24, 22)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = ""
        '
        'dgKorekc
        '
        Me.dgKorekc.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgKorekc.DataMember = ""
        Me.dgKorekc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorekc.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKorekc.Location = New System.Drawing.Point(16, 192)
        Me.dgKorekc.Name = "dgKorekc"
        Me.dgKorekc.PreferredColumnWidth = 95
        Me.dgKorekc.PreferredRowHeight = 20
        Me.dgKorekc.Size = New System.Drawing.Size(656, 144)
        Me.dgKorekc.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(272, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(368, 32)
        Me.Label7.TabIndex = 12
        '
        'ComboBox1
        '
        Me.ComboBox1.Items.AddRange(New Object() {"Eur", "RSD"})
        Me.ComboBox1.Location = New System.Drawing.Point(760, 56)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(72, 24)
        Me.ComboBox1.TabIndex = 14
        Me.ComboBox1.Text = "Eur"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Coral
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(184, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 22)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "**"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(456, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 120)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vrsta saobracaja"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(104, 88)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton3.TabIndex = 24
        Me.RadioButton3.Text = "Tranzit"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(104, 64)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton2.TabIndex = 23
        Me.RadioButton2.Text = "Uvoz"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(104, 40)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton1.TabIndex = 22
        Me.RadioButton1.Text = "Izvoz"
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(16, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 24)
        Me.CheckBox1.TabIndex = 19
        Me.CheckBox1.Text = "Izvoz"
        '
        'CheckBox2
        '
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(16, 64)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(64, 24)
        Me.CheckBox2.TabIndex = 20
        Me.CheckBox2.Text = "Uvoz"
        '
        'CheckBox3
        '
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(16, 88)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(72, 24)
        Me.CheckBox3.TabIndex = 21
        Me.CheckBox3.Text = "Tranzit"
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 376)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 95
        Me.DataGrid1.PreferredRowHeight = 20
        Me.DataGrid1.Size = New System.Drawing.Size(656, 144)
        Me.DataGrid1.TabIndex = 17
        '
        'DataGrid2
        '
        Me.DataGrid2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(16, 552)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.PreferredColumnWidth = 95
        Me.DataGrid2.PreferredRowHeight = 20
        Me.DataGrid2.Size = New System.Drawing.Size(656, 168)
        Me.DataGrid2.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Location = New System.Drawing.Point(16, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "I Z V O Z "
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label10.Location = New System.Drawing.Point(24, 352)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 24)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "U V O Z "
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label11.Location = New System.Drawing.Point(16, 528)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(160, 23)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "T R A N Z I T"
        '
        'dgKorIzv
        '
        Me.dgKorIzv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgKorIzv.DataMember = ""
        Me.dgKorIzv.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorIzv.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKorIzv.Location = New System.Drawing.Point(672, 224)
        Me.dgKorIzv.Name = "dgKorIzv"
        Me.dgKorIzv.Size = New System.Drawing.Size(336, 112)
        Me.dgKorIzv.TabIndex = 22
        Me.dgKorIzv.Visible = False
        '
        'btnDodaj
        '
        Me.btnDodaj.Location = New System.Drawing.Point(912, 352)
        Me.btnDodaj.Name = "btnDodaj"
        Me.btnDodaj.TabIndex = 12
        Me.btnDodaj.Text = "Dodaj"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(744, 128)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(88, 22)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "0.0"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(832, 128)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(88, 22)
        Me.TextBox5.TabIndex = 4
        Me.TextBox5.Text = "0.0"
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(920, 128)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(88, 22)
        Me.TextBox6.TabIndex = 5
        Me.TextBox6.Text = "0.0"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(672, 152)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 23)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Smanjenje"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(744, 112)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 16)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Pojedinacno"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(840, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Grupa"
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(744, 152)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(88, 22)
        Me.TextBox7.TabIndex = 6
        Me.TextBox7.Text = "0.0"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(920, 112)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Voz"
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(832, 152)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(88, 22)
        Me.TextBox8.TabIndex = 7
        Me.TextBox8.Text = "0.0"
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(920, 152)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(88, 22)
        Me.TextBox9.TabIndex = 8
        Me.TextBox9.Text = "0.0"
        '
        'TextBox10
        '
        Me.TextBox10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(744, 176)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(88, 22)
        Me.TextBox10.TabIndex = 9
        Me.TextBox10.Text = "0.0"
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(832, 176)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(88, 22)
        Me.TextBox11.TabIndex = 10
        Me.TextBox11.Text = "0.0"
        '
        'TextBox12
        '
        Me.TextBox12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(920, 176)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(88, 22)
        Me.TextBox12.TabIndex = 11
        Me.TextBox12.Text = "0.0"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(672, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 23)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Povecanje"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(672, 176)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 23)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Stimulacija"
        '
        'DataGrid4
        '
        Me.DataGrid4.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid4.DataMember = ""
        Me.DataGrid4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid4.Location = New System.Drawing.Point(672, 400)
        Me.DataGrid4.Name = "DataGrid4"
        Me.DataGrid4.Size = New System.Drawing.Size(336, 120)
        Me.DataGrid4.TabIndex = 36
        Me.DataGrid4.Visible = False
        '
        'DataGrid5
        '
        Me.DataGrid5.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid5.DataMember = ""
        Me.DataGrid5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid5.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid5.Location = New System.Drawing.Point(672, 576)
        Me.DataGrid5.Name = "DataGrid5"
        Me.DataGrid5.Size = New System.Drawing.Size(336, 144)
        Me.DataGrid5.TabIndex = 37
        Me.DataGrid5.Visible = False
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(672, 200)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(160, 23)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Izmena izvoz"
        Me.Label18.Visible = False
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(672, 376)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(160, 23)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Izmena uvoz"
        Me.Label19.Visible = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(672, 552)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(160, 23)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "Izmena tranzit"
        Me.Label20.Visible = False
        '
        'tbRedBr
        '
        Me.tbRedBr.Location = New System.Drawing.Point(712, 104)
        Me.tbRedBr.Name = "tbRedBr"
        Me.tbRedBr.Size = New System.Drawing.Size(16, 22)
        Me.tbRedBr.TabIndex = 114
        Me.tbRedBr.Text = "0"
        Me.tbRedBr.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.Desktop
        Me.ClientSize = New System.Drawing.Size(1016, 733)
        Me.Controls.Add(Me.tbRedBr)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.DataGrid5)
        Me.Controls.Add(Me.DataGrid4)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.TextBox11)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnDodaj)
        Me.Controls.Add(Me.dgKorIzv)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgKorekc)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.tbUg)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dodaj"
        CType(Me.dgKorekc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgKorIzv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim IzmIzv As DataSet
    Dim IzmUv As DataSet
    Dim IzmTr As DataSet


    Private Sub tbUg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUg.Leave
        Dim i As Int16 = 0
        Dim Naziv As String
        Dim Upit1 As String
        Dim intCounter1 As Integer
        Dim daKorek As SqlClient.SqlDataAdapter
        Dim dsKorek As New Data.DataSet
        Dim objComm1 As SqlClient.SqlCommand

        Upit1 = "SELECT dbo.Komitent.Sifra, dbo.Komitent.Naziv, dbo.Ugovori.BrojUgovora " & _
                "FROM dbo.Ugovori INNER JOIN " & _
                "dbo.Komitent ON dbo.Ugovori.SifraKorisnika = dbo.Komitent.Sifra " & _
                "WHERE left(dbo.Ugovori.BrojUgovora,4)='" & tbUg.Text & "'"
        objComm1 = New SqlClient.SqlCommand(Upit1, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daKorek = New SqlClient.SqlDataAdapter(Upit1, OkpDbVeza)
        daKorek.Fill(dsKorek)
        With dsKorek.Tables(0)
            i = 0
            For intCounter1 = 0 To .Rows.Count - 1
                Sifra = .Rows(intCounter1).Item("Sifra")
                Naziv = .Rows(intCounter1).Item("Naziv")
                Exit For

            Next
            Label7.Text = Sifra.ToString + "  -  " + Naziv.ToString
        End With
    End Sub

    Private Sub tbUg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUg.KeyPress
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

    Private Sub TextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.Leave
        Dim Saob As String
        If CheckBox1.Checked = True Then
            Saob = "3"
        ElseIf CheckBox2.Checked = True Then
            Saob = "2"
        ElseIf CheckBox3.Checked = False Then
            Saob = "4"
        End If
        Dim Ugovor As String
        Dim rv As String
        Dim PPov As Decimal
        Dim PSmanj As Decimal
        Dim PStim As Decimal
        Dim GPov As Decimal
        Dim GSmanj As Decimal
        Dim GStim As Decimal
        Dim VPov As Decimal
        Dim VSmanj As Decimal
        Dim VStim As Decimal
        Dim Ukupno As Decimal
        Dim BrKor As String

        ''' izvoz

        Ugovor = tbUg.Text
        Godina = TextBox2.Text
        Mesec = TextBox3.Text
        Saobracaj = "3"
        Posiljka = "P"
        BrKor = "55"
        UpisKomCoKorek(Sifra, Ugovor, Saobracaj, Mesec, Godina, Posiljka, Poj, Gr, Voz, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, BrKor, Ukupno, rv)

        Dim Upit3 As String
        Dim intCounter3 As Integer
        Dim daIzv As SqlClient.SqlDataAdapter
        Dim dsIzv As New Data.DataSet
        Dim objComm3 As SqlClient.SqlCommand

        Upit3 = "SELECT     Sifra, Ugovor, Pojedinacna, Grupa, Voz, Ukupno " & _
                "FROM         dbo.KomitentiCoKorekcije " & _
                "WHERE     (Saobracaj = 3) " & _
                "ORDER BY Ugovor"

        objComm3 = New SqlClient.SqlCommand(Upit3, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daIzv = New SqlClient.SqlDataAdapter(Upit3, OkpDbVeza)
        daIzv.Fill(dsIzv)
        If Saobracaj = "3" Then
            dgKorekc.DataSource = dsIzv.Tables(0)
        End If

        ''' kraj izvoz

        ''' za uvoz

        Saobracaj = "2"
        'Saob = "2"

        UpisKomCoKorek(Sifra, Ugovor, Saobracaj, Mesec, Godina, Posiljka, Poj, Gr, Voz, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, BrKor, Ukupno, rv)

        Dim Upit2 As String
        Dim intCounter2 As Integer
        Dim daUv As SqlClient.SqlDataAdapter
        Dim dsUv As New Data.DataSet
        Dim objComm2 As SqlClient.SqlCommand

        Upit2 = "SELECT     Sifra, Ugovor, Pojedinacna, Grupa, Voz, Ukupno " & _
        "FROM         dbo.KomitentiCoKorekcije " & _
        "WHERE     (Saobracaj = 2) " & _
        "ORDER BY Ugovor"

        objComm2 = New SqlClient.SqlCommand(Upit2, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daUv = New SqlClient.SqlDataAdapter(Upit2, OkpDbVeza)
        daUv.Fill(dsUv)
        If Saobracaj = "2" Then
            DataGrid1.DataSource = dsUv.Tables(0)
        End If
        ''' za uvoz kraj

        ''' za tr

        Saobracaj = "4"
        'Saob = "2"

        UpisKomCoKorek(Sifra, Ugovor, Saobracaj, Mesec, Godina, Posiljka, Poj, Gr, Voz, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, BrKor, Ukupno, rv)

        Dim Upit4 As String
        Dim intCounter4 As Integer
        Dim daTr As SqlClient.SqlDataAdapter
        Dim dsTr As New Data.DataSet
        Dim objComm4 As SqlClient.SqlCommand

        Upit2 = "SELECT     Ugovor, Pojedinacna, Grupa, Voz, Ukupno " & _
        "FROM         dbo.KomitentiCoKorekcije " & _
        "WHERE     (Saobracaj = 4) " & _
        "ORDER BY Ugovor"

        objComm4 = New SqlClient.SqlCommand(Upit4, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daTr = New SqlClient.SqlDataAdapter(Upit2, OkpDbVeza)
        daTr.Fill(dsTr)
        If Saobracaj = "4" Then
            DataGrid2.DataSource = dsTr.Tables(0)
        End If
        ''' za uvoz kraj

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        PPov = TextBox1.Text
        PPov = CDec(PPov)
        TextBox1.Text = Format(PPov, "###,##0.00")
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        GPov = TextBox5.Text
        GPov = CDec(GPov)
        TextBox5.Text = Format(GPov, "###,##0.00")
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        VPov = TextBox6.Text
        VPov = CDec(VPov)
        TextBox6.Text = Format(VPov, "###,##0.00")
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        PSmanj = TextBox7.Text
        PSmanj = CDec(PSmanj)
        TextBox7.Text = Format(PSmanj, "###,##0.00")
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.LostFocus
        GSmanj = TextBox8.Text
        GSmanj = CDec(GSmanj)
        TextBox8.Text = Format(GSmanj, "###,##0.00")
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.LostFocus
        VSmanj = TextBox9.Text
        VSmanj = CDec(VSmanj)
        TextBox9.Text = Format(VSmanj, "###,##0.00")
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.LostFocus
        PStim = TextBox10.Text
        PStim = CDec(PStim)
        TextBox10.Text = Format(PStim, "###,##0.00")
    End Sub

    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox11.LostFocus
        GStim = TextBox11.Text
        GStim = CDec(GStim)
        TextBox11.Text = Format(GStim, "###,##0.00")
    End Sub

    Private Sub TextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox12.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox12.LostFocus
        VStim = TextBox12.Text
        VStim = CDec(VStim)
        TextBox12.Text = Format(VStim, "###,##0.00")
        btnDodaj.Focus()
    End Sub

    Private Sub btnDodaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodaj.Click
        Dim RedBr As Int16
        Dim dtRow As DataRow = dtKorIzv.NewRow

        Dim rowKorIzv As Data.DataRow
        If RadioButton1.Checked = True Then
            TextBox1.TabIndex = 0
            PPov = CDec(TextBox1.Text)
            GPov = CDec(TextBox5.Text)
            VPov = CDec(TextBox6.Text)
            'rowDataGrid3 = dtKorIzv.Rows(0)
            PSmanj = CDec(TextBox7.Text)
            GSmanj = CDec(TextBox8.Text)
            VSmanj = CDec(TextBox9.Text)
            'rowDataGrid3 = dtKorIzv.Rows(1)
            PStim = CDec(TextBox10.Text)
            GStim = CDec(TextBox11.Text)
            VStim = CDec(TextBox12.Text)
            'rowDataGrid3 = dtKorIzv.Rows(2)
            Dim i As Int16
            'For i = 1 To 3 Step 1
            dtRow.ItemArray() = New Object() {PPov, GPov, VPov}
            dtKorIzv.Rows.Add(dtRow)
            KorIzvAddList.Add(dtRow)
            'rowKorIzv = CType(dgKorIzv.DataSource, DataTable).Rows(dgKorIzv.CurrentCell.RowNumber)
            'rowKorIzv = dtKorIzv.Rows(i)
            'Next
            'For i = 1 To 3 Step 1
            dtRow.ItemArray() = New Object() {PSmanj, GSmanj, VSmanj}
            'dtKorIzv.Rows.Add(dtRow)
            'KorIzvAddList.Add(dtRow)
            'Next
            'For i = 1 To 3 Step 1
            dtRow.ItemArray() = New Object() {PStim, GStim, VStim}
            'dtKorIzv.Rows.Add(dtRow)
            '' lista novih unetih redova (za update)
            'KorIzvAddList.Add(dtRow)
            'Next
            dgKorIzv.Refresh()
            i = i + 1

            dtKorIzv.Rows.Add(dtRow)
            KorIzvAddList.Add(dtRow)
            dgKorIzv.Visible = True
            Label18.Visible = True

        ElseIf RadioButton2.Checked = True Then
                TextBox1.TabIndex = 0
                PPov = CDec(TextBox1.Text)
                GPov = CDec(TextBox5.Text)
                VPov = CDec(TextBox6.Text)
                'rowDataGrid3 = dtKorIzv.Rows(0)
                PSmanj = CDec(TextBox7.Text)
                GSmanj = CDec(TextBox8.Text)
                VSmanj = CDec(TextBox9.Text)
                'rowDataGrid3 = dtKorIzv.Rows(1)
                PStim = CDec(TextBox10.Text)
                GStim = CDec(TextBox11.Text)
                VStim = CDec(TextBox12.Text)
                Dim i As Int16
                For i = 1 To 3 Step 1
                    'Dim dtRow As DataRow = dtKorIzv.NewRow
                    dtRow.ItemArray() = New Object() {PPov, GPov, VPov}
                    dtKorIzv.Rows.Add(dtRow)
                    'KorIzvAddList.Add(dtRow)
                    'rowKorIzv = CType(dgKorIzv.DataSource, DataTable).Rows(dgKorIzv.CurrentCell.RowNumber)
                    'rowKorIzv = dtKorIzv.Rows(i)
                    dtRow.ItemArray() = New Object() {PSmanj, GSmanj, VSmanj}
                    dtKorIzv.Rows.Add(dtRow)
                    KorIzvAddList.Add(dtRow)
                    dtRow.ItemArray() = New Object() {PStim, GStim, VStim}
                    dtKorIzv.Rows.Add(dtRow)
                    ' lista novih unetih redova (za update)
                    KorIzvAddList.Add(dtRow)
                    dgKorIzv.Refresh()
                    i = i + 1
                Next

        ElseIf RadioButton3.Checked = True Then
                TextBox1.TabIndex = 0
                PPov = CDec(TextBox1.Text)
                GPov = CDec(TextBox5.Text)
                VPov = CDec(TextBox6.Text)
                'rowDataGrid3 = dtKorIzv.Rows(0)
                PSmanj = CDec(TextBox7.Text)
                GSmanj = CDec(TextBox8.Text)
                VSmanj = CDec(TextBox9.Text)
                'rowDataGrid3 = dtKorIzv.Rows(1)
                PStim = CDec(TextBox10.Text)
                GStim = CDec(TextBox11.Text)
                VStim = CDec(TextBox12.Text)

                Dim i As Int16
                For i = 1 To 3 Step 1
                    'Dim dtRow As DataRow = dtKorIzv.NewRow
                    dtRow.ItemArray() = New Object() {PPov, GPov, VPov}
                    dtKorIzv.Rows.Add(dtRow)
                    'KorIzvAddList.Add(dtRow)
                    'rowKorIzv = CType(dgKorIzv.DataSource, DataTable).Rows(dgKorIzv.CurrentCell.RowNumber)
                    'rowKorIzv = dtKorIzv.Rows(i)
                    dtRow.ItemArray() = New Object() {PSmanj, GSmanj, VSmanj}
                    dtKorIzv.Rows.Add(dtRow)
                    KorIzvAddList.Add(dtRow)
                    dtRow.ItemArray() = New Object() {PStim, GStim, VStim}
                    dtKorIzv.Rows.Add(dtRow)
                    ' lista novih unetih redova (za update)
                    KorIzvAddList.Add(dtRow)
                    dgKorIzv.Refresh()
                    i = i + 1
                Next
        End If

    End Sub

    Public Sub setInDataKor(ByVal KorI As DataSet)
        IzmIzv = KorI
    End Sub

    Public Sub setInData(ByVal KorI As DataSet)
        IzmIzv = KorI
    End Sub

    Private Sub FormatGrid()
        If IzmIzv Is Nothing Then
            dgKorIzv.DataSource = dtKorIzv
        Else
            dgKorIzv.DataSource = IzmIzv.Tables(0)
            dtKorIzv = IzmIzv.Tables(0)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatGrid()
        If (dtKorIzv.Rows.Count > 0) Then
            tbRedBr.Text = dtKorIzv.Rows.Count + 1
        Else
            tbRedBr.Text = 1
        End If

    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        TextBox1.Focus()
    End Sub

    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        TextBox1.Focus()
    End Sub

    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        TextBox1.Focus()
    End Sub
End Class
