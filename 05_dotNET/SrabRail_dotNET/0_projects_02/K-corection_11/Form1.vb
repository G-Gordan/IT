Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient.SqlConnection


Imports System.Data.OleDb
Imports System.Data


Public Class Form1
    Inherits System.Windows.Forms.Form
    'Public Const ConnectionString As String = "Server=10.0.4.31;DataBase=OkpWinRoba;User=Radnik;Password=roba2006"
    Public Saobracaj As String
    Public Mesec As String
    Public Godina As String
    Public Ugovor As String
    Public Naziv As String = ""
    Public Sifra As Int16
    Friend WithEvents DataGrid3 As System.Windows.Forms.DataGrid
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DataGrid4 As System.Windows.Forms.DataGrid
    Public RecId As Int16

    Dim UgovorK As String
    Dim MesecK As String
    Dim GodinaK As String
    Dim SaobracajK As String

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
    Friend WithEvents dgKorUv As System.Windows.Forms.DataGrid
    Friend WithEvents dgKorTr As System.Windows.Forms.DataGrid
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dgKorIzv As System.Windows.Forms.DataGrid
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents btnUpisi As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DefinitivniObračunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UizuveštajŠpedicijaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents UvozToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IzvozToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TranzitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BrisanjeTabelaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents R22ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
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
        Me.dgKorUv = New System.Windows.Forms.DataGrid
        Me.dgKorTr = New System.Windows.Forms.DataGrid
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.btnUpisi = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.M1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.M1ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.M2ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DefinitivniObračunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UvozToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IzvozToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TranzitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UizuveštajŠpedicijaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.R22ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BrisanjeTabelaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.DataGrid3 = New System.Windows.Forms.DataGrid
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.DataGrid4 = New System.Windows.Forms.DataGrid
        CType(Me.dgKorekc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgKorIzv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgKorUv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgKorTr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(366, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Korekcije  - rekapitulacija"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Osnovni ugovor:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Godina/Mesec:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(224, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Šifra i naziv špedicije:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(139, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Procenat:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(139, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 23)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Valuta:"
        '
        'tbUg
        '
        Me.tbUg.BackColor = System.Drawing.Color.Coral
        Me.tbUg.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.tbUg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUg.Location = New System.Drawing.Point(130, 32)
        Me.tbUg.MaxLength = 4
        Me.tbUg.Name = "tbUg"
        Me.tbUg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbUg.Size = New System.Drawing.Size(48, 22)
        Me.tbUg.TabIndex = 0
        Me.tbUg.UseWaitCursor = True
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(130, 56)
        Me.TextBox2.MaxLength = 4
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox2.Size = New System.Drawing.Size(48, 22)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(217, 116)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox4.Size = New System.Drawing.Size(72, 22)
        Me.TextBox4.TabIndex = 113
        Me.TextBox4.Text = "0.0"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(178, 56)
        Me.TextBox3.MaxLength = 2
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox3.Size = New System.Drawing.Size(24, 22)
        Me.TextBox3.TabIndex = 2
        '
        'dgKorekc
        '
        Me.dgKorekc.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgKorekc.DataMember = ""
        Me.dgKorekc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorekc.HeaderFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorekc.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKorekc.Location = New System.Drawing.Point(21, 170)
        Me.dgKorekc.Name = "dgKorekc"
        Me.dgKorekc.PreferredColumnWidth = 95
        Me.dgKorekc.PreferredRowHeight = 20
        Me.dgKorekc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgKorekc.Size = New System.Drawing.Size(518, 132)
        Me.dgKorekc.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(223, 93)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(3)
        Me.Label7.Size = New System.Drawing.Size(409, 26)
        Me.Label7.TabIndex = 12
        '
        'ComboBox1
        '
        Me.ComboBox1.Items.AddRange(New Object() {"Eur", "RSD"})
        Me.ComboBox1.Location = New System.Drawing.Point(217, 140)
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
        Me.Label8.Location = New System.Drawing.Point(178, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 22)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "**"
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(124, 92)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vrsta saobracaja"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(6, 68)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "Tranzit"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(6, 45)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Uvoz"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(6, 23)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(80, 24)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "Izvoz"
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(21, 308)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 95
        Me.DataGrid1.PreferredRowHeight = 20
        Me.DataGrid1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGrid1.Size = New System.Drawing.Size(518, 132)
        Me.DataGrid1.TabIndex = 17
        '
        'DataGrid2
        '
        Me.DataGrid2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(21, 446)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.PreferredColumnWidth = 95
        Me.DataGrid2.PreferredRowHeight = 20
        Me.DataGrid2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGrid2.Size = New System.Drawing.Size(518, 136)
        Me.DataGrid2.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Coral
        Me.Label9.Location = New System.Drawing.Point(32, 173)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 20)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "I Z V O Z "
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Coral
        Me.Label10.Location = New System.Drawing.Point(32, 308)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 20)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "U V O Z "
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Coral
        Me.Label11.Location = New System.Drawing.Point(32, 450)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 20)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "T R A N Z I T"
        '
        'dgKorIzv
        '
        Me.dgKorIzv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgKorIzv.DataMember = ""
        Me.dgKorIzv.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorIzv.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKorIzv.Location = New System.Drawing.Point(563, 199)
        Me.dgKorIzv.Name = "dgKorIzv"
        Me.dgKorIzv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgKorIzv.Size = New System.Drawing.Size(306, 103)
        Me.dgKorIzv.TabIndex = 22
        Me.dgKorIzv.Visible = False
        '
        'btnDodaj
        '
        Me.btnDodaj.Location = New System.Drawing.Point(926, 175)
        Me.btnDodaj.Name = "btnDodaj"
        Me.btnDodaj.Size = New System.Drawing.Size(75, 23)
        Me.btnDodaj.TabIndex = 12
        Me.btnDodaj.Text = "Dodaj"
        Me.ToolTip1.SetToolTip(Me.btnDodaj, "Proveri vrstu saobracaja")
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(639, 109)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox1.Size = New System.Drawing.Size(88, 22)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "0.0"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(727, 109)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox5.Size = New System.Drawing.Size(88, 22)
        Me.TextBox5.TabIndex = 4
        Me.TextBox5.Text = "0.0"
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(815, 109)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox6.Size = New System.Drawing.Size(88, 22)
        Me.TextBox6.TabIndex = 5
        Me.TextBox6.Text = "0.0"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(565, 133)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 23)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Smanjenje"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(639, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 16)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Pojedinacno"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(735, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Grupa"
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(639, 133)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox7.Size = New System.Drawing.Size(88, 22)
        Me.TextBox7.TabIndex = 6
        Me.TextBox7.Text = "0.0"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(815, 93)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Voz"
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(727, 133)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox8.Size = New System.Drawing.Size(88, 22)
        Me.TextBox8.TabIndex = 7
        Me.TextBox8.Text = "0.0"
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(815, 133)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox9.Size = New System.Drawing.Size(88, 22)
        Me.TextBox9.TabIndex = 8
        Me.TextBox9.Text = "0.0"
        '
        'TextBox10
        '
        Me.TextBox10.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(639, 157)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox10.Size = New System.Drawing.Size(88, 22)
        Me.TextBox10.TabIndex = 9
        Me.TextBox10.Text = "0.0"
        '
        'TextBox11
        '
        Me.TextBox11.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(727, 157)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox11.Size = New System.Drawing.Size(88, 22)
        Me.TextBox11.TabIndex = 10
        Me.TextBox11.Text = "0.0"
        '
        'TextBox12
        '
        Me.TextBox12.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(815, 157)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox12.Size = New System.Drawing.Size(88, 22)
        Me.TextBox12.TabIndex = 11
        Me.TextBox12.Text = "0.0"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(565, 108)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 23)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Povecanje"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(565, 156)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 23)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Stimulacija"
        '
        'dgKorUv
        '
        Me.dgKorUv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgKorUv.DataMember = ""
        Me.dgKorUv.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorUv.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKorUv.Location = New System.Drawing.Point(563, 328)
        Me.dgKorUv.Name = "dgKorUv"
        Me.dgKorUv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgKorUv.Size = New System.Drawing.Size(306, 112)
        Me.dgKorUv.TabIndex = 36
        Me.dgKorUv.Visible = False
        '
        'dgKorTr
        '
        Me.dgKorTr.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgKorTr.DataMember = ""
        Me.dgKorTr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorTr.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKorTr.Location = New System.Drawing.Point(563, 470)
        Me.dgKorTr.Name = "dgKorTr"
        Me.dgKorTr.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgKorTr.Size = New System.Drawing.Size(306, 112)
        Me.dgKorTr.TabIndex = 37
        Me.dgKorTr.Visible = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Coral
        Me.Label18.Location = New System.Drawing.Point(567, 202)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(160, 19)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Izmena izvoz"
        Me.Label18.Visible = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label19.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Coral
        Me.Label19.Location = New System.Drawing.Point(567, 328)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(160, 23)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Izmena uvoz"
        Me.Label19.Visible = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Coral
        Me.Label20.Location = New System.Drawing.Point(567, 470)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(160, 23)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "Izmena tranzit"
        Me.Label20.Visible = False
        '
        'btnUpisi
        '
        Me.btnUpisi.Location = New System.Drawing.Point(886, 65)
        Me.btnUpisi.Name = "btnUpisi"
        Me.btnUpisi.Size = New System.Drawing.Size(130, 25)
        Me.btnUpisi.TabIndex = 116
        Me.btnUpisi.Text = "Štampaj"
        Me.btnUpisi.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Coral
        Me.Label21.Location = New System.Drawing.Point(638, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 22)
        Me.Label21.TabIndex = 117
        Me.Label21.Text = "Label21"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem, Me.ToolStripMenuItem1, Me.BrisanjeTabelaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1016, 24)
        Me.MenuStrip1.TabIndex = 118
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem
        '
        Me.ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop
        Me.ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M1ToolStripMenuItem})
        Me.ToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem.ForeColor = System.Drawing.Color.Coral
        Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
        Me.ToolStripMenuItem.Size = New System.Drawing.Size(115, 20)
        Me.ToolStripMenuItem.Text = "Unos nove korekcije"
        '
        'M1ToolStripMenuItem
        '
        Me.M1ToolStripMenuItem.Name = "M1ToolStripMenuItem"
        Me.M1ToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.M1ToolStripMenuItem.Text = "Unos novog ugovora"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Desktop
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M1ToolStripMenuItem1, Me.M2ToolStripMenuItem1, Me.DefinitivniObračunToolStripMenuItem, Me.UizuveštajŠpedicijaToolStripMenuItem, Me.R22ToolStripMenuItem})
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Coral
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(101, 20)
        Me.ToolStripMenuItem1.Text = "Štampa izveštaja"
        '
        'M1ToolStripMenuItem1
        '
        Me.M1ToolStripMenuItem1.Name = "M1ToolStripMenuItem1"
        Me.M1ToolStripMenuItem1.Size = New System.Drawing.Size(174, 22)
        Me.M1ToolStripMenuItem1.Text = "M-1"
        '
        'M2ToolStripMenuItem1
        '
        Me.M2ToolStripMenuItem1.Name = "M2ToolStripMenuItem1"
        Me.M2ToolStripMenuItem1.Size = New System.Drawing.Size(174, 22)
        Me.M2ToolStripMenuItem1.Text = "M-2"
        '
        'DefinitivniObračunToolStripMenuItem
        '
        Me.DefinitivniObračunToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UvozToolStripMenuItem, Me.IzvozToolStripMenuItem, Me.TranzitToolStripMenuItem})
        Me.DefinitivniObračunToolStripMenuItem.Name = "DefinitivniObračunToolStripMenuItem"
        Me.DefinitivniObračunToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.DefinitivniObračunToolStripMenuItem.Text = "Definitivni obracun"
        '
        'UvozToolStripMenuItem
        '
        Me.UvozToolStripMenuItem.Name = "UvozToolStripMenuItem"
        Me.UvozToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.UvozToolStripMenuItem.Text = "Izvoz"
        '
        'IzvozToolStripMenuItem
        '
        Me.IzvozToolStripMenuItem.Name = "IzvozToolStripMenuItem"
        Me.IzvozToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.IzvozToolStripMenuItem.Text = "Uvoz"
        '
        'TranzitToolStripMenuItem
        '
        Me.TranzitToolStripMenuItem.Name = "TranzitToolStripMenuItem"
        Me.TranzitToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.TranzitToolStripMenuItem.Text = "Tranzit"
        '
        'UizuveštajŠpedicijaToolStripMenuItem
        '
        Me.UizuveštajŠpedicijaToolStripMenuItem.Name = "UizuveštajŠpedicijaToolStripMenuItem"
        Me.UizuveštajŠpedicijaToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.UizuveštajŠpedicijaToolStripMenuItem.Text = "Izvestaj spedicija"
        '
        'R22ToolStripMenuItem
        '
        Me.R22ToolStripMenuItem.Name = "R22ToolStripMenuItem"
        Me.R22ToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.R22ToolStripMenuItem.Text = "R_22"
        '
        'BrisanjeTabelaToolStripMenuItem
        '
        Me.BrisanjeTabelaToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop
        Me.BrisanjeTabelaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem})
        Me.BrisanjeTabelaToolStripMenuItem.ForeColor = System.Drawing.Color.Coral
        Me.BrisanjeTabelaToolStripMenuItem.Name = "BrisanjeTabelaToolStripMenuItem"
        Me.BrisanjeTabelaToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.BrisanjeTabelaToolStripMenuItem.Text = "Brisanje tabela"
        '
        'IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem
        '
        Me.IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem.Name = "IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem"
        Me.IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem.Text = "Izbrisi korekcije iz prethodnog  meseca"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Coral
        Me.Button1.Location = New System.Drawing.Point(208, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 23)
        Me.Button1.TabIndex = 119
        Me.Button1.Text = "Poništi"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Coral
        Me.Button2.Location = New System.Drawing.Point(886, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(130, 40)
        Me.Button2.TabIndex = 120
        Me.Button2.Text = "Izbriši korekcije iz prethodnog meseca"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(926, 404)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 66)
        Me.Button3.TabIndex = 121
        Me.Button3.Text = "Poništi unete korekcije"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGrid3
        '
        Me.DataGrid3.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid3.DataMember = ""
        Me.DataGrid3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid3.Location = New System.Drawing.Point(21, 590)
        Me.DataGrid3.Name = "DataGrid3"
        Me.DataGrid3.PreferredColumnWidth = 95
        Me.DataGrid3.PreferredRowHeight = 20
        Me.DataGrid3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGrid3.Size = New System.Drawing.Size(518, 136)
        Me.DataGrid3.TabIndex = 122
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label22.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Coral
        Me.Label22.Location = New System.Drawing.Point(32, 590)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(170, 20)
        Me.Label22.TabIndex = 123
        Me.Label22.Text = "U N U T R A Š N J I "
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label23.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Coral
        Me.Label23.Location = New System.Drawing.Point(567, 614)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(160, 23)
        Me.Label23.TabIndex = 125
        Me.Label23.Text = "Izmena unutrašnji"
        Me.Label23.Visible = False
        '
        'DataGrid4
        '
        Me.DataGrid4.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid4.DataMember = ""
        Me.DataGrid4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid4.Location = New System.Drawing.Point(563, 614)
        Me.DataGrid4.Name = "DataGrid4"
        Me.DataGrid4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGrid4.Size = New System.Drawing.Size(306, 112)
        Me.DataGrid4.TabIndex = 124
        Me.DataGrid4.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.Desktop
        Me.ClientSize = New System.Drawing.Size(1016, 738)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.DataGrid4)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.DataGrid3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.btnUpisi)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dgKorTr)
        Me.Controls.Add(Me.dgKorUv)
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
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dodaj"
        CType(Me.dgKorekc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgKorIzv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgKorUv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgKorTr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim IzmIzv As DataSet
    Dim IzmUv As DataSet
    Dim IzmTr As DataSet
    Dim IzmUn As DataSet

    Dim Ugovor1 As String
    
    Dim Posiljka As String
    Dim Poj As Decimal
    Dim Gr As Decimal
    Dim Voz As Decimal
    Dim BrKor As Int16

    Dim PPov As Decimal = 0.0
    Dim PSmanj As Decimal = 0.0
    Dim PStim As Decimal = 0.0
    Dim GPov As Decimal = 0.0
    Dim GSmanj As Decimal = 0.0
    Dim GStim As Decimal = 0.0
    Dim VPov As Decimal = 0.0
    Dim VSmanj As Decimal = 0.0
    Dim VStim As Decimal = 0.0

    Dim tlPrevFr As Decimal = 0.0
    Dim tlPrevUp As Decimal = 0.0
    Dim tlNakFr As Decimal = 0.0
    Dim tlNakUp As Decimal = 0.0
    Dim tlNakCo As Decimal = 0.0

    Dim PPovU As Decimal = 0.0
    Dim PSmanjU As Decimal = 0.0
    Dim PStimU As Decimal = 0.0
    Dim GPovU As Decimal = 0.0
    Dim GSmanjU As Decimal = 0.0
    Dim GStimU As Decimal = 0.0
    Dim VPovU As Decimal = 0.0
    Dim VSmanjU As Decimal = 0.0
    Dim VStimU As Decimal = 0.0

    Dim PPovT As Decimal = 0.0
    Dim PSmanjT As Decimal = 0.0
    Dim PStimT As Decimal = 0.0
    Dim GPovT As Decimal = 0.0
    Dim GSmanjT As Decimal = 0.0
    Dim GStimT As Decimal = 0.0
    Dim VPovT As Decimal = 0.0
    Dim VSmanjT As Decimal = 0.0
    Dim VStimT As Decimal = 0.0

    Dim PPovUn As Decimal = 0.0
    Dim PSmanjUn As Decimal = 0.0
    Dim PStimUn As Decimal = 0.0
    Dim GPovUn As Decimal = 0.0
    Dim GSmanjUn As Decimal = 0.0
    Dim GStimUn As Decimal = 0.0
    Dim VPovUn As Decimal = 0.0
    Dim VSmanjUn As Decimal = 0.0
    Dim VStimUn As Decimal = 0.0

    Dim dtKorIzv As DataTable = New DataTable("KorIzv")
    Dim Pojj As DataColumn = dtKorIzv.Columns.Add("Voz", Type.GetType("System.Decimal"))
    Dim Grr As DataColumn = dtKorIzv.Columns.Add("Grupa", Type.GetType("System.Decimal"))
    Dim Vozz As DataColumn = dtKorIzv.Columns.Add("Pojedinacno", Type.GetType("System.Decimal"))

    Dim dtKorUv As DataTable = New DataTable("KorUzv")
    Dim Pojjj As DataColumn = dtKorUv.Columns.Add("Voz", Type.GetType("System.Decimal"))
    Dim Grrr As DataColumn = dtKorUv.Columns.Add("Grupa", Type.GetType("System.Decimal"))
    Dim Vozzz As DataColumn = dtKorUv.Columns.Add("Pojedinacno", Type.GetType("System.Decimal"))

    Public dtKorTr As DataTable = New DataTable("KorTr")
    Dim Poojj As DataColumn = dtKorTr.Columns.Add("Voz", Type.GetType("System.Decimal"))
    Dim Grrrr As DataColumn = dtKorTr.Columns.Add("Grupa", Type.GetType("System.Decimal"))
    Dim Vozzzz As DataColumn = dtKorTr.Columns.Add("Pojedinacno", Type.GetType("System.Decimal"))

    Public dtKorUn As DataTable = New DataTable("KorUn")
    Dim PoojjU As DataColumn = dtKorUn.Columns.Add("Voz", Type.GetType("System.Decimal"))
    Dim GrrrrU As DataColumn = dtKorUn.Columns.Add("Grupa", Type.GetType("System.Decimal"))
    Dim VozzzzU As DataColumn = dtKorUn.Columns.Add("Pojedinacno", Type.GetType("System.Decimal"))

    Public dsBKorek As New Data.DataSet
    Public dsIzv As New Data.DataSet
    Public dsUv As New Data.DataSet
    Public dsTr As New Data.DataSet
    Public dsUn As New Data.DataSet
    Public dsKK As New Data.DataSet

    Private Sub tbUg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUg.GotFocus
        dsUv.Clear()
        dsTr.Clear()
        dsUn.Clear()
        dsBKorek.Clear()
        dsIzv.Clear()
        Label18.Visible = False
        dgKorIzv.Visible = False
        Label19.Visible = False
        dgKorUv.Visible = False
        Label20.Visible = False
        dgKorTr.Visible = False
        tbUg.Clear()
        tbUg.Focus()
    End Sub

    Private Sub tbUg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUg.Leave
        Dim i As Int16 = 0
        Dim Upit1 As String
        Dim intCounter1 As Integer
        Dim daKorek As SqlClient.SqlDataAdapter
        Dim objComm1 As SqlClient.SqlCommand
        Dim dsKorek As New Data.DataSet
        Ugovor = tbUg.Text

        Upit1 = "SELECT dbo.Komitent.Sifra, dbo.Komitent.Naziv, dbo.Ugovori.BrojUgovora " & _
                "FROM dbo.Ugovori INNER JOIN " & _
                "dbo.Komitent ON dbo.Ugovori.SifraKorisnika = dbo.Komitent.Sifra " & _
                "WHERE left(dbo.Ugovori.BrojUgovora,4)='" & Ugovor & "' AND dbo.Ugovori.VrstaObracuna = 'co'"
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
            If Sifra = 1 Then
                Label7.Text = ""
            Else
                Label7.Text = Sifra.ToString + "  -  " + Naziv.ToString
            End If
        End With
    End Sub

    Private Sub tbUg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUg.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "tbUg" Then
                TextBox2.Focus()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox2" Then
                TextBox3.Focus()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.Leave

        Dim rv As String = ""

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
        ' izvoz

        Ugovor = tbUg.Text
        Godina = TextBox2.Text
        Mesec = TextBox3.Text

        If Sifra = 2 And Godina = 2012 Then
            Label7.Text = Sifra.ToString + "  -  " + "Prodos"
        Else
            Label7.Text = Sifra.ToString + "  -  " + Naziv.ToString
        End If

        'SlogKalk1(Ugovor, Mesec, Godina, rv)

        Saobracaj = "3"
        Posiljka = "P"
        UpisKomCoKorek(RecId, Sifra, Ugovor, Saobracaj, Mesec, Godina, Posiljka, Poj, Gr, Voz, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, BrKor, Ukupno, rv)

        Dim Upit3 As String
        'Dim intCounter3 As Integer
        Dim objDSS As New Data.DataSet
        Dim daIzv As SqlClient.SqlDataAdapter
        Dim objComm3 As SqlClient.SqlCommand

        Upit3 = "SELECT   SUM(Ukupno) AS Ukupno, SUM(Voz) AS Voz, SUM(Grupa) AS Grupa, SUM(Pojedinacna) AS Pojedinacna, Ugovor AS Ugovor  " & _
                "FROM     dbo.KomitentiCoKorekcije " & _
                "GROUP BY Ugovor, Saobracaj " & _
                "HAVING      (Saobracaj = '3') " & _
                "ORDER BY Ugovor"
        'Upit3 = "SELECT     SUM(Ukupno) AS Ukupno, SUM(Voz) AS Voz, SUM(Grupa) AS Grupa, SUM(Pojedinacna) AS Pojedinacna, Ugovor AS Ugovor, Saobracaj AS Saobracaj " & _
        '"FROM(dbo.KomitentiCoKorekcije) " & _
        '"GROUP BY Ugovor, Saobracaj " & _
        '"HAVING      (Saobracaj = '3') " & _
        '"ORDER BY Ugovor"
        '        SELECT     SUM(Ukupno) AS Ukupno, SUM(Voz) AS Voz, SUM(Grupa) AS Grupa, SUM(Pojedinacna) AS Pojedinacna, Ugovor AS Ugovor, 
        '                      Saobracaj AS Saobracaj
        'FROM         dbo.KomitentiCoKorekcije
        'GROUP BY Ugovor, Saobracaj
        'HAVING      (Saobracaj = 2)


        objComm3 = New SqlClient.SqlCommand(Upit3, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daIzv = New SqlClient.SqlDataAdapter(Upit3, OkpDbVeza)
        daIzv.Fill(dsIzv)
        'With dsIzv.Tables(0)
        '    For intCounter3 = 0 To .Rows.Count - 1
        '        Ugovor1 = .Rows(intCounter3).Item("Ugovor")
        '    Next

        If Saobracaj = "3" Then
            dgKorekc.DataSource = dsIzv.Tables(0)
        End If
        'End With
        'kraj izvoz


        ' za uvoz
        Saobracaj = "2"

        UpisKomCoKorek(RecId, Sifra, Ugovor, Saobracaj, Mesec, Godina, Posiljka, Poj, Gr, Voz, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, BrKor, Ukupno, rv)

        Dim Upit2 As String
        Dim daUv As SqlClient.SqlDataAdapter
        Dim objComm2 As SqlClient.SqlCommand

        Upit2 = "SELECT   SUM(Ukupno) AS Ukupno, SUM(Voz) AS Voz, SUM(Grupa) AS Grupa, SUM(Pojedinacna) AS Pojedinacna, Ugovor AS Ugovor " & _
                "FROM     dbo.KomitentiCoKorekcije " & _
                "GROUP BY Ugovor, Saobracaj " & _
                "HAVING      (Saobracaj = '2') " & _
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
        'za uvoz kraj


        'za tr
        Saobracaj = "4"

        UpisKomCoKorek(RecId, Sifra, Ugovor, Saobracaj, Mesec, Godina, Posiljka, Poj, Gr, Voz, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, BrKor, Ukupno, rv)

        Dim Upit4 As String
        'Dim intCounter4 As Integer
        Dim daTr As SqlClient.SqlDataAdapter
        Dim objComm4 As SqlClient.SqlCommand

        Upit4 = "SELECT   SUM(Ukupno) AS Ukupno, SUM(Voz) AS Voz, SUM(Grupa) AS Grupa, SUM(Pojedinacna) AS Pojedinacna, Ugovor AS Ugovor " & _
                "FROM     dbo.KomitentiCoKorekcije " & _
                "GROUP BY Ugovor, Saobracaj " & _
                "HAVING      (Saobracaj = '4') " & _
                "ORDER BY Ugovor"

        objComm4 = New SqlClient.SqlCommand(Upit4, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daTr = New SqlClient.SqlDataAdapter(Upit4, OkpDbVeza)
        daTr.Fill(dsTr)
        If Saobracaj = "4" Then
            DataGrid2.DataSource = dsTr.Tables(0)
        End If
        'za tr kraj

        'za unut
        Saobracaj = "1"

        UpisKomCoKorek(RecId, Sifra, Ugovor, Saobracaj, Mesec, Godina, Posiljka, Poj, Gr, Voz, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, BrKor, Ukupno, rv)

        Dim Upit5 As String
        'Dim intCounter4 As Integer
        Dim daUn As SqlClient.SqlDataAdapter
        Dim objComm5 As SqlClient.SqlCommand

        Upit5 = "SELECT   SUM(Ukupno) AS Ukupno, SUM(Voz) AS Voz, SUM(Grupa) AS Grupa, SUM(Pojedinacna) AS Pojedinacna, Ugovor AS Ugovor " & _
                "FROM     dbo.KomitentiCoKorekcije " & _
                "GROUP BY Ugovor, Saobracaj " & _
                "HAVING      (Saobracaj = '1') " & _
                "ORDER BY Ugovor"

        objComm5 = New SqlClient.SqlCommand(Upit5, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daUn = New SqlClient.SqlDataAdapter(Upit5, OkpDbVeza)
        daUn.Fill(dsUn)
        If Saobracaj = "1" Then
            DataGrid3.DataSource = dsUn.Tables(0)
        End If
        'za unut kraj

        RadioButton1.Checked = True
        'RadioButton1.Focus()
        TextBox1.Focus()

    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        If TextBox1.Text = "" Then
            TextBox1.Text = 0.0
        End If
        Dim a As Decimal
        a = TextBox1.Text
        a = CDec(a)
        TextBox1.Text = Format(a, "###,##0.00")

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox1" Then
                TextBox5.Focus()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.Text = 0.0
        End If
        Dim a As Decimal
        a = TextBox1.Text
        a = CDec(a)
        TextBox1.Text = Format(a, "###,##0.00")

    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox3" Then
                TextBox1.Focus()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox5" Then
                TextBox6.Focus()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        If TextBox5.Text = "" Then
            TextBox5.Text = 0.0
        End If
        GPov = TextBox5.Text
        GPov = CDec(GPov)
        TextBox5.Text = Format(GPov, "###,##0.00")
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox6" Then
                TextBox7.Focus()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        If TextBox6.Text = "" Then
            TextBox6.Text = 0.0
        End If
        VPov = TextBox6.Text
        VPov = CDec(VPov)
        TextBox6.Text = Format(VPov, "###,##0.00")
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox7" Then
                TextBox8.Focus()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        PSmanj = TextBox7.Text
        PSmanj = CDec(PSmanj)
        TextBox7.Text = Format(PSmanj, "###,##0.00")
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox8" Then
                TextBox9.Focus()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.LostFocus
        If TextBox8.Text = "" Then
            TextBox8.Text = 0.0
        End If
        GSmanj = TextBox8.Text
        GSmanj = CDec(GSmanj)
        TextBox8.Text = Format(GSmanj, "###,##0.00")
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox9" Then
                TextBox10.Focus()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.LostFocus
        If TextBox9.Text = "" Then
            TextBox9.Text = 0.0
        End If
        VSmanj = TextBox9.Text
        VSmanj = CDec(VSmanj)
        TextBox9.Text = Format(VSmanj, "###,##0.00")
        btnDodaj.Focus()
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox10" Then
                TextBox11.Focus()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.LostFocus
        If TextBox11.Text = "" Then
            TextBox11.Text = 0.0
        End If
        PStim = TextBox10.Text
        PStim = CDec(PStim)
        TextBox10.Text = Format(PStim, "###,##0.00")
    End Sub

    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox11" Then
                TextBox12.Focus()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox11.LostFocus
        If TextBox11.Text = "" Then
            TextBox11.Text = 0.0
        End If
        GStim = TextBox11.Text
        GStim = CDec(GStim)
        TextBox11.Text = Format(GStim, "###,##0.00")
    End Sub

    Private Sub TextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox12.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "TextBox12" Then
                btnDodaj.Focus()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox12.LostFocus
        If TextBox12.Text = "" Then
            TextBox12.Text = 0.0
        End If
        VStim = TextBox12.Text
        VStim = CDec(VStim)
        TextBox12.Text = Format(VStim, "###,##0.00")
        btnDodaj.Focus()
    End Sub

    Private Sub btnDodaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodaj.Click
        Dim rv As String = ""
        If RadioButton1.Checked = True Then
            Saobracaj = "3"
            TextBox1.TabIndex = 0
            'TextBox1.Text = 0.0

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

            dtKorIzv.Rows.Add(TextBox6.Text, TextBox5.Text, TextBox1.Text)
            dtKorIzv.Rows.Add(TextBox9.Text, TextBox8.Text, TextBox7.Text)
            dtKorIzv.Rows.Add(TextBox12.Text, TextBox11.Text, TextBox10.Text)
            dgKorIzv.DataSource = dtKorIzv

            dgKorIzv.Visible = True
            Label18.Visible = True
            RadioButton2.Focus()
            UpdKomCoKorek(Ugovor, Saobracaj, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, rv)

        ElseIf RadioButton2.Checked = True Then
            Saobracaj = "2"
            TextBox1.TabIndex = 0
            'TextBox1.Text = 0.0
            PPovU = CDec(TextBox1.Text)
            GPovU = CDec(TextBox5.Text)
            VPovU = CDec(TextBox6.Text)

            PSmanjU = CDec(TextBox7.Text)
            GSmanjU = CDec(TextBox8.Text)
            VSmanjU = CDec(TextBox9.Text)

            PStimU = CDec(TextBox10.Text)
            GStimU = CDec(TextBox11.Text)
            VStimU = CDec(TextBox12.Text)

            dtKorUv.Rows.Add(TextBox6.Text, TextBox5.Text, TextBox1.Text)
            dtKorUv.Rows.Add(TextBox9.Text, TextBox8.Text, TextBox7.Text)
            dtKorUv.Rows.Add(TextBox12.Text, TextBox11.Text, TextBox10.Text)
            dgKorUv.DataSource = dtKorUv

            dgKorUv.Visible = True
            Label19.Visible = True
            RadioButton3.Focus()
            UpdKomCoKorek(Ugovor, Saobracaj, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, rv)

        ElseIf RadioButton3.Checked = True Then
            Saobracaj = "4"
            TextBox1.TabIndex = 0
            'TextBox1.Text = 0.0
            PPovT = CDec(TextBox1.Text)
            GPovT = CDec(TextBox5.Text)
            VPovT = CDec(TextBox6.Text)
            'rowDataGrid3 = dtKorIzv.Rows(0)
            PSmanjT = CDec(TextBox7.Text)
            GSmanjT = CDec(TextBox8.Text)
            VSmanjT = CDec(TextBox9.Text)
            'rowDataGrid3 = dtKorIzv.Rows(1)
            PStimT = CDec(TextBox10.Text)
            GStimT = CDec(TextBox11.Text)
            VStimT = CDec(TextBox12.Text)

            dtKorTr.Rows.Add(TextBox6.Text, TextBox5.Text, TextBox1.Text)
            dtKorTr.Rows.Add(TextBox9.Text, TextBox8.Text, TextBox7.Text)
            dtKorTr.Rows.Add(TextBox12.Text, TextBox11.Text, TextBox10.Text)
            dgKorTr.DataSource = dtKorTr

            dgKorTr.Visible = True
            Label20.Visible = True
            UpdKomCoKorek(Ugovor, Saobracaj, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, rv)

        End If
        If Saobracaj = "2" Then
            PPov = PPovU
            PSmanj = PSmanjU
            GPov = GPovU
            GSmanj = GSmanjU
            VPov = VPovU
            VSmanj = VSmanjU
        ElseIf Saobracaj = "4" Then
            PPov = PPovT
            PSmanj = PSmanjT
            GPov = GPovT
            GSmanj = GSmanjT
            VPov = VPovT
            VSmanj = VSmanjT
        End If

        UpdKomCoKorek(Ugovor, Saobracaj, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, rv)
       
        Dim Upit1 As String
        Dim intCounter1 As Integer
        Dim daKK As SqlClient.SqlDataAdapter
        Dim objComm1 As SqlClient.SqlCommand
        'Ugovor = tbUg.Text
        Upit1 = "SELECT    * " & _
        "FROM    dbo.KomitentiNovaCoKor " & _
        "WHERE   (Ugovor ='" & Ugovor & "' and Godina='" & Godina & "'  and Mesec  = '" & Mesec & "') "

        objComm1 = New SqlClient.SqlCommand(Upit1, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daKK = New SqlClient.SqlDataAdapter(Upit1, OkpDbVeza)
        daKK.Fill(dsKK)

        With dsKK.Tables(0)

            'I = 0
            For intCounter1 = 0 To .Rows.Count - 1
                UgovorK = .Rows(intCounter1).Item("Ugovor")
                MesecK = .Rows(intCounter1).Item("Mesec")
                GodinaK = .Rows(intCounter1).Item("Godina")
                SaobracajK = .Rows(intCounter1).Item("Saobracaj")
                Exit For
            Next
        End With

        If (UgovorK = tbUg.Text And MesecK = TextBox3.Text And GodinaK = TextBox2.Text And SaobracajK = Saobracaj) Then
            MsgBox("Podaci za ovaj ugovor već su uneti!")
            BrKor = BrKor - 1
            Label21.Text = BrKor.ToString
        Else
            NovaKomCoKorek(Ugovor, Saobracaj, Mesec, Godina, PPov, PSmanj, PStim, GPov, GSmanj, GStim, VPov, VSmanj, VStim, rv)
            UpdSlogKalk11(tlPrevFr, tlPrevUp, tlNakFr, tlNakUp, tlNakCo, rv)


        End If


        TextBox1.Text = 0.0
        TextBox5.Text = 0.0
        TextBox6.Text = 0.0
        TextBox7.Text = 0.0
        TextBox8.Text = 0.0
        TextBox9.Text = 0.0
        TextBox10.Text = 0.0
        TextBox11.Text = 0.0
        TextBox12.Text = 0.0

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
        Dim Upitt As String
        Dim intCounter1 As Integer
        Dim I As Int16
        Dim daBKorek As SqlClient.SqlDataAdapter
        Dim objComm1 As SqlClient.SqlCommand

        Upitt = "Select BrojKorekcije FROM dbo.KomitentiCoKorekcije " & _
                "GROUP BY BrojKorekcije " & _
                "HAVING(BrojKorekcije = MAX(BrojKorekcije))"
        objComm1 = New SqlClient.SqlCommand(Upitt, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daBKorek = New SqlClient.SqlDataAdapter(Upitt, OkpDbVeza)
        daBKorek.Fill(dsBKorek)
        With dsBKorek.Tables(0)
            I = 0
            For intCounter1 = 0 To .Rows.Count - 1
                BrKor = .Rows(intCounter1).Item("BrojKorekcije")
                Exit For
            Next
            BrKor = BrKor + 1
            Label21.Text = BrKor.ToString
        End With
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

    Private Sub btnUpisi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpisi.Click

        Dim FIzv As New Form2
        Dim CRConec As New ConnectionInfo
        Dim CRIzv As New M1        'The report you created.

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String
        Dim param2 As String
        Dim param3 As Decimal
        Dim param4 As Decimal

        param1 = Godina
        param2 = Mesec
        param3 = Saobracaj
        param4 = Ugovor

        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{KomitentiCoKorekcije.Godina}='" & Godina & "' and {KomitentiCoKorekcije.Mesec}= '" & Mesec & "' and {KomitentiCoKorekcije.Saobracaj}= '3' " ' and {left(KomitentiCoKorekcije.Ugovor,4)} = '" & Ugovor & " ' "" & Saobracaj & "

            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            CRIzv.SetParameterValue(2, param3)
            'CRIzv.SetParameterValue(3, param4)

        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        FIzv.Show()

    End Sub

    Private Sub RadioButton1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RadioButton1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            If sender.name = "RadioButton1" Then
                TextBox1.Focus()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub M1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M1ToolStripMenuItem.Click
        tbUg.Clear()
        'TextBox2.Clear()
        'TextBox3.Clear()

        ''tbug_gotfocus
        dsUv.Clear()
        dsTr.Clear()
        dsBKorek.Clear()
        dsIzv.Clear()
        dtKorIzv.Rows.Clear()
        'Label7.Visible = True
        Label7.Text = ""
        'Label19.Visible = False
        dtKorTr.Rows.Clear()
        dtKorUv.Rows.Clear()
        'Label20.Visible = False

        tbUg.Focus()
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        ToolTip1.SetToolTip(btnUpisi, "Ispis izveštaja")
        ToolTip1.SetToolTip(btnDodaj, "Dodaj unete podatke u data grid")
    End Sub

    Private Sub M1ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M1ToolStripMenuItem1.Click
        Dim FIzv As New Form2
        Dim CRConec As New ConnectionInfo
        Dim CRIzv As New M1        'The report you created.

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String
        Dim param2 As String
        Dim param3 As Decimal
        Dim param4 As Decimal

        param1 = Godina
        param2 = Mesec
        param3 = Saobracaj
        param4 = Ugovor

        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{KomitentiCoKorekcije.Godina}='" & Godina & "' and {KomitentiCoKorekcije.Mesec}= '" & Mesec & "' and {KomitentiCoKorekcije.Saobracaj}= '3' " ' and {left(KomitentiCoKorekcije.Ugovor,4)} = '" & Ugovor & " ' "" & Saobracaj & "

            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            CRIzv.SetParameterValue(2, param3)
            'CRIzv.SetParameterValue(3, param4)

        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        FIzv.Show()
    End Sub

    'Private Sub DefinitivniObracunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefinitivniObračunToolStripMenuItem.Click

    'End Sub

    Private Sub IzvestajSpedicijaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UizuveštajŠpedicijaToolStripMenuItem.Click
        Dim FIzv As New Form2
        Dim CRConec As New ConnectionInfo
        Dim CRIzv As New IzvestajSpedicija2       'The report you created.

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        'Dim param1 As String
        'Dim param2 As String
        'Dim param3 As String

        'param1 = Godina
        'param2 = Mesec
        'param3 = Ugovor

        'Try
        '    'FIzv.CrystalReportViewer1.SelectionFormula = "{DefinitivniObracun.Mesec}= '" & Mesec & "' and {DefinitivniObracun.Godina}= '" & Godina & "'  and {Ugovor4.Ugov}= '" & Ugovor & "' " 'and {DefinitivniObracun.Saobrcaj}= '""' "

        '    'CRIzv.SetParameterValue(0, param2)
        '    'CRIzv.SetParameterValue(1, param1)
        '    'CRIzv.SetParameterValue(2, param3)


        'Catch Excep As Exception
        '    MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try
        FIzv.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tbUg.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        dsUv.Clear()
        dsTr.Clear()
        dsBKorek.Clear()
        dsIzv.Clear()
        tbUg.Focus()

        dtKorIzv.Rows.Clear()
        dtKorUv.Rows.Clear()
        dtKorTr.Rows.Clear()

    End Sub

    Private Sub M2ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M2ToolStripMenuItem1.Click
        Dim FIzv As New Form2
        Dim CRConec As New ConnectionInfo
        Dim CRIzv As New IzvestajSpedicija1       'The report you created.

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        'Dim param1 As String
        'Dim param2 As String
        'Dim param3 As String

        'param1 = Godina
        'param2 = Mesec
        'param3 = Ugovor

        'Try
        '    'FIzv.CrystalReportViewer1.SelectionFormula = "{DefinitivniObracun.Mesec}= '" & Mesec & "' and {DefinitivniObracun.Godina}= '" & Godina & "'  and {Ugovor4.Ugov}= '" & Ugovor & "' " 'and {DefinitivniObracun.Saobrcaj}= '""' "

        '    CRIzv.SetParameterValue(0, param2)
        '    CRIzv.SetParameterValue(1, param1)
        '    CRIzv.SetParameterValue(2, param3)


        'Catch Excep As Exception
        '    MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try
        FIzv.Show()
    End Sub

    Private Sub UvozToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UvozToolStripMenuItem.Click
        Dim FIzv As New Form2
        Dim CRConec As New ConnectionInfo
        Dim CRIzv As New DefinitivniObracun        'The report you created.

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String
        Dim param2 As String
        Dim param3 As String

        Ugovor = tbUg.Text
        Godina = TextBox2.Text
        Mesec = TextBox3.Text

        param1 = Godina
        param2 = Mesec
        param3 = "3"

        Try
            'FIzv.CrystalReportViewer1.SelectionFormula = "{DefinitivniObracun.Mesec}= '" & Mesec & "' and {DefinitivniObracun.Godina}= '" & Godina & "' and {DefinitivniObracun.Saobrcaj}= '""' "

            CRIzv.SetParameterValue(0, param2)
            CRIzv.SetParameterValue(1, param1)
            CRIzv.SetParameterValue(2, param3)
            'CRIzv.SetParameterValue(3, param4)

        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        FIzv.Show()
    End Sub

    Private Sub IzvozToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IzvozToolStripMenuItem.Click
        Dim FIzv As New Form2
        Dim CRConec As New ConnectionInfo
        Dim CRIzv As New DefinitivniObracun        'The report you created.

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String
        Dim param2 As String
        Dim param3 As String

        Ugovor = tbUg.Text
        Godina = TextBox2.Text
        Mesec = TextBox3.Text

        param1 = Godina
        param2 = Mesec
        param3 = "2"

        Try
            'FIzv.CrystalReportViewer1.SelectionFormula = "{DefinitivniObracun.Saobrcaj}= '""' "
            'FIzv.CrystalReportViewer1.SelectionFormula = "{DefinitivniObracun.Mesec}= '" & Mesec & "' and {DefinitivniObracun.Godina}= '" & Godina & "' and {DefinitivniObracun.Saobrcaj}= '""' "

            CRIzv.SetParameterValue(0, param2)
            CRIzv.SetParameterValue(1, param1)
            CRIzv.SetParameterValue(2, param3)
            'CRIzv.SetParameterValue(3, param4)

        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        FIzv.Show()
    End Sub

    Private Sub TranzitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranzitToolStripMenuItem.Click
        Dim FIzv As New Form2
        Dim CRConec As New ConnectionInfo
        Dim CRIzv As New DefinitivniObracun        'The report you created.

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String
        Dim param2 As String
        Dim param3 As String

        Ugovor = tbUg.Text
        Godina = TextBox2.Text
        Mesec = TextBox3.Text

        param1 = Godina
        param2 = Mesec
        param3 = "4"


        Try
            'FIzv.CrystalReportViewer1.SelectionFormula = "{DefinitivniObracun.Mesec}= '" & Mesec & "' and {DefinitivniObracun.Godina}= '" & Godina & "' and {DefinitivniObracun.Saobrcaj}= '""' "

            CRIzv.SetParameterValue(0, param2)
            CRIzv.SetParameterValue(1, param1)
            CRIzv.SetParameterValue(2, param3)
            'CRIzv.SetParameterValue(3, param4)

        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        FIzv.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        BrisiKomCoKorek(Mesec, Godina)
    End Sub

    Private Sub IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IzbrisiKorekcijeIzPrethodnogMesecaToolStripMenuItem.Click
        BrisiKomCoKorek(Mesec, Godina)
    End Sub

    Private Sub R22ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R22ToolStripMenuItem.Click
        Dim FIzv As New Form2
        Dim CRConec As New ConnectionInfo
        Dim CRIzv As New Prijava_2Report1       'The report you created.

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String
        Dim param2 As String
        'Dim param3 As String

        param1 = Godina
        param2 = Mesec
        'param3 = "3"

        Try
            'FIzv.CrystalReportViewer1.SelectionFormula = "{DefinitivniObracun.Mesec}= '" & Mesec & "' and {DefinitivniObracun.Godina}= '" & Godina & "' and {DefinitivniObracun.Saobrcaj}= '""' "

            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            'CRIzv.SetParameterValue(2, param3)
            'CRIzv.SetParameterValue(3, param4)

        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        FIzv.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        dtKorIzv.Rows.Clear()
        dtKorUv.Rows.Clear()
        dtKorTr.Rows.Clear()
        RadioButton1.Checked = True
        TextBox1.Focus()
    End Sub

End Class
