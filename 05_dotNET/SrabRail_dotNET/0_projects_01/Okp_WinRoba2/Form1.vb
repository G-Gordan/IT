Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class Form1

    Inherits System.Windows.Forms.Form
    'Public str As String
    'Public count As Integer
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ToolBar2 As System.Windows.Forms.ToolBar
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem45 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem52 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem53 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem54 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem69 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem70 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem74 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem75 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem76 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem77 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem78 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem80 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem81 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem43 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem80 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem81 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem74 = New System.Windows.Forms.MenuItem
        Me.MenuItem75 = New System.Windows.Forms.MenuItem
        Me.MenuItem78 = New System.Windows.Forms.MenuItem
        Me.MenuItem76 = New System.Windows.Forms.MenuItem
        Me.MenuItem77 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem43 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.MenuItem45 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.MenuItem52 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.MenuItem53 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.MenuItem42 = New System.Windows.Forms.MenuItem
        Me.MenuItem54 = New System.Windows.Forms.MenuItem
        Me.MenuItem69 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.MenuItem70 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem40 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.MenuItem37 = New System.Windows.Forms.MenuItem
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.ToolBar2 = New System.Windows.Forms.ToolBar
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Button9 = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem74, Me.MenuItem13, Me.MenuItem18, Me.MenuItem12})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem9, Me.MenuItem23, Me.MenuItem2, Me.MenuItem3, Me.MenuItem80, Me.MenuItem7, Me.MenuItem8, Me.MenuItem81, Me.MenuItem14, Me.MenuItem4, Me.MenuItem5})
        Me.MenuItem1.Text = "Unos"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 0
        Me.MenuItem9.Text = "Unutrasnji saobracaj"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 1
        Me.MenuItem23.Text = "-"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 2
        Me.MenuItem2.Text = "Uvoz"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 3
        Me.MenuItem3.Text = "Izvoz"
        '
        'MenuItem80
        '
        Me.MenuItem80.Index = 4
        Me.MenuItem80.Text = "-"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 5
        Me.MenuItem7.Text = "Tranzit"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 6
        Me.MenuItem8.Text = "-"
        '
        'MenuItem81
        '
        Me.MenuItem81.Index = 7
        Me.MenuItem81.Text = "Beograd Ranzirna - Granica"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 8
        Me.MenuItem14.Text = "Zaostala kola iz Beograd Ranzirne "
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 9
        Me.MenuItem4.Text = "-"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 10
        Me.MenuItem5.Text = "Izlaz iz programa"
        '
        'MenuItem74
        '
        Me.MenuItem74.Index = 1
        Me.MenuItem74.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem75, Me.MenuItem78, Me.MenuItem76, Me.MenuItem77, Me.MenuItem22, Me.MenuItem10, Me.MenuItem11, Me.MenuItem21, Me.MenuItem25})
        Me.MenuItem74.Text = "Korekcija"
        '
        'MenuItem75
        '
        Me.MenuItem75.Index = 0
        Me.MenuItem75.Text = "Direktni vozovi"
        '
        'MenuItem78
        '
        Me.MenuItem78.Index = 1
        Me.MenuItem78.Text = "Granica - Beograd Ranžirna"
        '
        'MenuItem76
        '
        Me.MenuItem76.Index = 2
        Me.MenuItem76.Text = "-"
        '
        'MenuItem77
        '
        Me.MenuItem77.Index = 3
        Me.MenuItem77.Text = "Beograd Ranžirna - Granica"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 4
        Me.MenuItem22.Text = "Beograd Ranžirna - Naknade za ranžiranje na zahtev špeditera"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 5
        Me.MenuItem10.Text = "-"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 6
        Me.MenuItem11.Text = "Vozovi Jug-Sever [ svi vozovi sa ugovorom ŽS CO ----96 ]"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 7
        Me.MenuItem21.Text = "-"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 8
        Me.MenuItem25.Text = "Izmena najave voza ili broja ugovora"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 2
        Me.MenuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem43, Me.MenuItem15, Me.MenuItem16})
        Me.MenuItem13.Text = "Stampa"
        '
        'MenuItem43
        '
        Me.MenuItem43.Enabled = False
        Me.MenuItem43.Index = 0
        Me.MenuItem43.Text = "[ PREGLED RADA GRANICNIH PRELAZA ]"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 1
        Me.MenuItem15.Text = "K140trz"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 2
        Me.MenuItem16.Text = "K165trz"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 3
        Me.MenuItem18.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem29, Me.MenuItem45, Me.MenuItem6, Me.MenuItem19, Me.MenuItem52, Me.MenuItem26, Me.MenuItem27, Me.MenuItem53, Me.MenuItem20, Me.MenuItem42, Me.MenuItem54, Me.MenuItem69, Me.MenuItem30, Me.MenuItem70, Me.MenuItem31})
        Me.MenuItem18.Text = "Pregled"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 0
        Me.MenuItem29.Text = "Mesecni materijal"
        '
        'MenuItem45
        '
        Me.MenuItem45.Index = 1
        Me.MenuItem45.Text = "Dnevni unos"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.Text = "-"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 3
        Me.MenuItem19.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem24, Me.MenuItem28, Me.MenuItem17})
        Me.MenuItem19.Text = "Nerealizovane najave vozova"
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 0
        Me.MenuItem24.Text = "Tranzit"
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 1
        Me.MenuItem28.Text = "Uvoz"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 2
        Me.MenuItem17.Text = "Izvoz"
        '
        'MenuItem52
        '
        Me.MenuItem52.Index = 4
        Me.MenuItem52.Text = "Pregled svih najava vozova"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 5
        Me.MenuItem26.Text = "Pregled po tovarnom listu"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 6
        Me.MenuItem27.Text = "Pregled NHM u aneksima ugovora za CO"
        '
        'MenuItem53
        '
        Me.MenuItem53.Index = 7
        Me.MenuItem53.Text = "-"
        '
        'MenuItem20
        '
        Me.MenuItem20.Enabled = False
        Me.MenuItem20.Index = 8
        Me.MenuItem20.Text = "[ Tranzit ]"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 9
        Me.MenuItem42.Text = "Najave do Beograd Ranzirne "
        '
        'MenuItem54
        '
        Me.MenuItem54.Index = 10
        Me.MenuItem54.Text = "Najave od Beograd Ranzirne "
        '
        'MenuItem69
        '
        Me.MenuItem69.Index = 11
        Me.MenuItem69.Text = "-"
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 12
        Me.MenuItem30.Text = "Pregled baze kola"
        '
        'MenuItem70
        '
        Me.MenuItem70.Index = 13
        Me.MenuItem70.Text = "Trazenje kola u najavama"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 4
        Me.MenuItem12.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem40, Me.MenuItem39, Me.MenuItem37})
        Me.MenuItem12.Text = "Pomoc"
        '
        'MenuItem40
        '
        Me.MenuItem40.Index = 0
        Me.MenuItem40.Text = "Pomoc u radu sa programom"
        '
        'MenuItem39
        '
        Me.MenuItem39.Index = 1
        Me.MenuItem39.Text = "-"
        '
        'MenuItem37
        '
        Me.MenuItem37.Index = 2
        Me.MenuItem37.Text = "O programu "
        '
        'ToolBar1
        '
        Me.ToolBar1.AutoSize = False
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(1344, 82)
        Me.ToolBar1.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(97, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 76)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Uvoz"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(186, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 76)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Izvoz"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolBar2
        '
        Me.ToolBar2.ButtonSize = New System.Drawing.Size(39, 1)
        Me.ToolBar2.DropDownArrows = True
        Me.ToolBar2.Location = New System.Drawing.Point(0, 82)
        Me.ToolBar2.Name = "ToolBar2"
        Me.ToolBar2.ShowToolTips = True
        Me.ToolBar2.Size = New System.Drawing.Size(1344, 7)
        Me.ToolBar2.TabIndex = 9
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(275, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(89, 76)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Unutrašnji"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(8, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(89, 76)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Tranzit"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(364, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(89, 76)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Izmena u bazi"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.Location = New System.Drawing.Point(631, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(89, 76)
        Me.Button6.TabIndex = 7
        Me.Button6.Text = "Izlaz iz programa"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button7.Location = New System.Drawing.Point(760, 8)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(72, 64)
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "Beograd Ranzirna - Granica"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.Visible = False
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(542, 3)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(89, 76)
        Me.Button8.TabIndex = 6
        Me.Button8.Text = "Brisanje"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "cimv00.hlp"
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(453, 3)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(89, 76)
        Me.Button9.TabIndex = 5
        Me.Button9.Text = "Preuzimanje sa granice"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 637)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(1344, 8)
        Me.StatusBar1.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 493)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1344, 144)
        Me.Panel1.TabIndex = 1601
        Me.Panel1.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(144, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Purple
        Me.Label2.Location = New System.Drawing.Point(144, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(400, 23)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "INFO panel - izmene u radu sa programom"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label1.Location = New System.Drawing.Point(144, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(816, 72)
        Me.Label1.TabIndex = 14
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(16, 8)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(120, 120)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1344, 404)
        Me.Panel2.TabIndex = 1603
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 14
        Me.MenuItem31.Text = "Pregled kretanja kola u bazi"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1344, 645)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ToolBar2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ToolBar1)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Roba"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
            mCistUnos = "Da"
            'mOtpDatum = Today()
            MM_Count = 10
            ZaostalaKola = "Ne"
            AkcijaZaPreuzimanje = "Ne"
            Dim form2a As New TrzStart
            IzborSaobracaja = "2"
            MM_Action = "New"

            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()
            mUlEtiketa = 0
            mIzEtiketa = 0

            bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
            form2a.Text = "Uvoz start! "
            form2a.ShowDialog()
        Else
            MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
            mCistUnos = "Da"
            mOtpDatum = Today()

            MM_Count = 10
            AkcijaZaPreuzimanje = "Ne"
            Dim form2a As New TrzStart
            IzborSaobracaja = "3"
            MM_Action = "New"

            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()
            mUlEtiketa = 0
            mIzEtiketa = 0

            bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
            form2a.Text = "Izvoz start! "
            form2a.ShowDialog()

        Else
            MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
            mCistUnos = "Da"
            AkcijaZaPreuzimanje = "Ne"
            TipTranzita = "ulaz"
            mIzEtiketa = 0
            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()

            Dim form2a As New TrzStart
            IzborSaobracaja = "4"
            bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
            form2a.Text = "Tranzit ULAZ"
            form2a.ShowDialog()
        Else
            MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        mCistUnos = "Ne"
        AkcijaZaPreuzimanje = "Ne"
        RecordAction = "N"
        Dim FormUpd As New UpdateForm

        FormUpd.Text = ":: Izmena u bazi podataka ::"
        FormUpd.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "5" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
            ZaostalaKola = "Ne"
            AkcijaZaPreuzimanje = "Ne"
            Dim form2a As New TrzStart
            IzborSaobracaja = "1"

            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()
            mUlEtiketa = 0
            mIzEtiketa = 0

            bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
            form2a.Text = "Lokal start! "
            form2a.ShowDialog()
        Else
            MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FormUpd As New UpdateForm
        FormUpd.ShowDialog()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Close()

    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'pronadji broj sledece ulazne tranzitne nalepnice
        'SELECT IzlaznaNalepnica, Stanica
        'FROM dbo.ZsTrzNalepnice
        'WHERE (Stanica = '23499')
        'mIzEtiketa=iz upita
        '-----------------
        TipTranzita = "izlaz"
        mUlEtiketa = 0
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim sql_text As String = "SELECT IzlaznaNalepnica " & _
                                 "FROM dbo.ZsTrzNalepnice " & _
                                 "WHERE (dbo.ZsTrzNalepnice.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrTrz As SqlClient.SqlDataReader

        rdrTrz = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrTrz.Read()
            mIzEtiketa = rdrTrz.GetInt32(0) '+ 1
        Loop
        rdrTrz.Close()
        DbVeza.Close()

        '-----------------
        Dim form2b As New TrzIzlaz
        IzborSaobracaja = "4"
        bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
        form2b.Text = "Tranzit IZLAZ"
        form2b.ShowDialog()

    End Sub

    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        Stampa = "k140"
        Dim FormaZaCR As New FormDatum
        FormaZaCR.ShowDialog()
    End Sub

    Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim helpNalepnica As New hlpForm1
        helpNalepnica.Text = "Izmena redosleda tranzitnih nalepnica"
        helpNalepnica.ShowDialog()

    End Sub

    Private Sub MenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frmXMLCarina As New frmCarinaXML
        'frmXMLCarina.ShowDialog()
        'frmXMLCarina.Dispose()
    End Sub

    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        Stampa = "k165"
        Dim FormaZaCR As New FormDatum
        FormaZaCR.ShowDialog()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        AkcijaZaPreuzimanje = "Ne"
        RecordAction = "D"
        Dim formDel As New UpdateForm

        formDel.Text = ":: Brisanje ::"
        formDel.ShowDialog()

    End Sub

    Private Sub MenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim helpUic As New HelpForm
        helpUic.Text = "help K140trz"
        upit = "K140"
        helpUic.ShowDialog()

    End Sub

    Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim RMesec As New RacunskiMesec
        SetMesec = "UNOS"
        IzborSaobracaja = "4"
        RMesec.Text = "PODESAVANJE MESECA ZA UNOS"
        RMesec.ShowDialog()

    End Sub

    Private Sub MenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim helpUic As New HelpForm
        helpUic.Text = "help K165trz"
        upit = "K165"
        helpUic.ShowDialog()

    End Sub

    Private Sub MenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem40.Click
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace)
    End Sub

    Private Sub MenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem37.Click
        Dim AboutUs As New About
        AboutUs.ShowDialog()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Label4.Text = ""
        'count = 1
        'Str = ":D test 12345678910"
        'Timer1.Enabled = True

        '========== ucitava info
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim sql_trz3 As String = "SELECT Text, Datum FROM InfoPanel ORDER BY Datum DESC"

        Dim sql_commTrz3 As New SqlClient.SqlCommand(sql_trz3, OkpDbVeza)
        Dim rdrTar3 As SqlClient.SqlDataReader

        rdrTar3 = sql_commTrz3.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrTar3.Read()
            If rdrTar3.GetDateTime(1) > Date.Today.AddDays(-7) Then
                Me.Panel1.Visible = True
                Label1.Text = rdrTar3.GetString(0)
                Label3.Text = rdrTar3.GetDateTime(1).ToShortDateString
                Exit Do
            Else
                Me.Panel1.Visible = False
                Exit Do
            End If
        Loop
        rdrTar3.Close()
        OkpDbVeza.Close()

        '-------------------- postavljanje racunskog meseca za tranzit - opsti slucaj ---------------------
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        nmNarPos = False

        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
            IzborSaobracaja = "4"
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
            IzborSaobracaja = "2"
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
            IzborSaobracaja = "3"
        Else
            IzborSaobracaja = "1"
        End If

        Dim sql_text1 As String = "SELECT MesecUnosa, GodinaUnosa FROM RacMesec " & _
                                  "WHERE (VSaob = '" & IzborSaobracaja & "')"
        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrRm.Read()
            mObrMesec = rdrRm.GetString(0)
            mObrGodina = rdrRm.GetString(1)
        Loop
        rdrRm.Close()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        mCistUnos = "Ne"
        AkcijaZaPreuzimanje = "Da"
        MM_Action = "New"
        RecordAction = "P"
        Dim formPreuzmi As New UpdateForm

        formPreuzmi.Text = ":: Preuzimanje podataka sa granicnog prelaza ::"
        formPreuzmi.ShowDialog()

    End Sub

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        mBrojUg = ""
        mNajava = ""
        mNazivKomitenta = ""
        MasterAction = "New"

        UpdRecID = 0
        UpdUprava = ""
        UpdStanica = ""
        UpdBroj = 0
        UpdDatum = Today()
        mNastavljaNajavu = False

        ' ------------------------- ne ide na Form1 vec na Update Form! 
        If AkcijaZaPreuzimanje = "Da" Then

            RecordAction = "P"
            Dim formPreuzmi As New UpdateForm

            formPreuzmi.Text = ":: Preuzimanje podataka sa granicnog prelaza ::"
            formPreuzmi.ShowDialog()
        Else
            AkcijaZaPreuzimanje = "Ne"
            ' ------------------------- ne ide na Form1 vec na UpdateForm!
            '            RecordAction = "P"
            '            Dim formPreuzmi As New UpdateForm

            '           formPreuzmi.Text = ":: Preuzimanje podataka sa granicnog prelaza ::"
            '           formPreuzmi.ShowDialog()

        End If
    End Sub

    Private Sub MenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem29.Click
        mPregledUnosa = "M"
        Dim FormPregledMaterijala As New FormPregledTL
        FormPregledMaterijala.ShowDialog()

    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        Close()

    End Sub

    Private Sub MenuItem46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'sql_UpitPregled = "SELECT Referent1, COUNT(*) " & _
        '                     "FROM dbo.SlogKalk " & _
        '                     "WHERE (Saobracaj = '"4"') " & " AND (DatumObrade = '"14/2/2007"') " & _
        '                     "ORDER BY ZsUlPrelaz, UlEtiketa, ZsIzPrelaz, IzEtiketa"

    End Sub

    Private Sub MenuItem45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem45.Click
        mPregledUnosa = "D"  'dnevni

        'Dim FormPregledMaterijala As New FormPregledTL
        'FormPregledMaterijala.ShowDialog()

        Dim Form2 As New FormGrid
        Form2.ShowDialog()


    End Sub

    Private Sub MenuItem46_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''' co4_parametar.rpt  +

        ''Dim FIzv As New CRMultiForm
        ''Dim CRIzv As New CO4_parametar_p2

        ''FIzv.CrystalReportViewer1.ReportSource = CRIzv

        ''Dim CRConec As New ConnectionInfo
        ''CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        ''CRConec.ServerName = "10.0.4.31"
        ''CRConec.DatabaseName = "OkpWinRoba"
        ''CRConec.UserID = "Radnik"
        ''CRConec.Password = "roba2006"

        '''---------------

        ''Dim param1 As String 'parametar koji se odnosi na racunski mesec
        ''Dim param2 As String 'parametar koji se odnosi na racunski mesec

        ''param1 = "16"
        ''param2 = CrRacunskiMesec


        ''FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ObrMesec} = '" & param2 & "' and Left({SlogKalk.Ugovor},2)= '" & param1 & "'"

        ''CRIzv.SetParameterValue(0, param2)
        ''CRIzv.SetParameterValue(1, param1)
        '''---------------

        ''FIzv.Show()

    End Sub

    Private Sub MenuItem47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub MenuItem48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' TranzitSpedicije.rpt +

    End Sub

    Private Sub MenuItem49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'co-okp.rpt 
    End Sub

    Private Sub MenuItem24_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Click
        mPregledUnosa = "T"
        Dim FormPregledNajava As New NajavePregled
        FormPregledNajava.ShowDialog()

    End Sub

    Private Sub MenuItem42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem42.Click
        mPregledUnosa = "M"  'Makis
        Dim FormPregledNajava As New NajavePregled
        FormPregledNajava.ShowDialog()

    End Sub

    Private Sub MenuItem52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem52.Click
        mPregledUnosa = "X"  'pregled svih najava sa iznosima

        Dim Form2 As New FormGrid
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem54.Click
        mPregledUnosa = "BR"
        Dim FormPregledNajava As New NajavePregled
        FormPregledNajava.ShowDialog()

    End Sub

    Private Sub MenuItem55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuItem75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem75.Click
        ZaostalaKola = "Ne"
        Dim FormKorekcija As New KorekcijaPoNajavi
        FormKorekcija.Text = "Korekcija unetih podataka o vozu/grupi kola"
        FormKorekcija.ShowDialog()

    End Sub

    Private Sub MenuItem77_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem77.Click
        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
            ZaostalaKola = "Ne"
            'Korekcija vozova iz Makisa

            VozoviMakis = "Izmena"
            Dim FormMakisIzmena As New MakisNew '''' Makis
            FormMakisIzmena.Text = "Korekcija unetih podataka o vozu na relaciji Beograd Ranzirna - Granica"
            FormMakisIzmena.ShowDialog()
        Else
            MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub MenuItem81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem81.Click
        VozoviMakis = "Novi"
        Dim FormMakis As New MakisNew
        ''''''''''''Dim FormMakis As New Makis
        FormMakis.Text = "Kalkulacija za vozove na relaciji Beograd Ranzirna - Granica"
        FormMakis.ShowDialog()
    End Sub

    Private Sub MenuItem78_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem78.Click
        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
            Dim FormKorekcija As New KorekcijaPoNajavi
            FormKorekcija.Text = "Korekcija unetih podataka o vozu na relaciji Granica - Beograd Ranzirna"
            FormKorekcija.ShowDialog()
        Else
            MessageBox.Show("Nemate ovlascenje da pristupite ovom delu programa!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub MenuItem64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CRMesec As New RacunskiMesec
        IzborSaobracaja = "4"
        SetMesec = "CR"
        CRMesec.Text = "PODESAVANJE MESECA ZA STAMPU"
        CRMesec.ShowDialog()
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        AkcijaZaPreuzimanje = "Ne"
        TipTranzita = "ulaz"
        mIzEtiketa = 0
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()

        Dim form2a As New TrzStart
        IzborSaobracaja = "4"
        bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
        form2a.Text = "Tranzit ULAZ"
        form2a.ShowDialog()

    End Sub

    Private Sub MenuItem70_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem70.Click
        mPregledUnosa = "TK"  'Trazenje kola u tabeli najava

        Dim Form2p As New PregledParametri
        Form2p.ShowDialog()

    End Sub

    Private Sub MenuItem68_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuItem14_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Click
        ZaostalaKola = "Da"

        Dim FormMakis As New MakisZaostalaKola_1
        FormMakis.Text = "Beograd Ranzirna - Zaostala kola"
        FormMakis.ShowDialog()
    End Sub

    Private Sub MenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem28.Click
        mPregledUnosa = "UV"
        Dim FormPregledNajava As New NajavePregled
        FormPregledNajava.ShowDialog()

    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        mPregledUnosa = "IZ"
        Dim FormPregledNajava As New NajavePregled
        FormPregledNajava.ShowDialog()

    End Sub


    Private Sub MenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem22.Click
        Dim FormMakis As New MakisNaknade
        FormMakis.Text = "Beograd Ranzirna - Naknade"
        FormMakis.ShowDialog()

    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        ZaostalaKola = "Ne"
        Dim FormKorekcija As New KorekcijaPoNajavi
        FormKorekcija.Text = "Korekcija unetih podataka o vozu JUG-SEVER"
        FormKorekcija.ShowDialog()
    End Sub

    'Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim rdrCoUg As SqlClient.SqlDataReader
    '    Dim bCO As Boolean
    '    If OkpDbVeza.State = ConnectionState.Closed Then
    '        OkpDbVeza.Open()
    '    End If

    '    '------------------------ ispituje ima li najave u tabeli NajavaVoza --------------------------------------
    '    Try
    '        Dim sql_text As String = "SELECT * into TempIzvozCO3g_mm01 FROM OPENROWSET('sqloledb', '10.0.4.39';'radnik2';'roba2012','SELECT * FROM OkpWinRoba.radnik2.TempIzvozCO3g_mm01' ) AS a"
    '        Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)

    '        rdrCoUg = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
    '        bCO = rdrCoUg.HasRows
    '        rdrCoUg.Close()
    '        OkpDbVeza.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Greska u pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try
    'End Sub

    Private Sub MenuItem25_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem25.Click
        Dim FormKorekcija As New KorekcijaUpdNajave
        FormKorekcija.Text = "Izmena najave voza ili broja ugovora"
        FormKorekcija.ShowDialog()
    End Sub

    Private Sub MenuItem26_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem26.Click

        Dim Form2 As New PregledtTLGrid
        Form2.Text = "Pregled po tovarnom listu"
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem27_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem27.Click
        Dim Form2 As New PregledNHMGrid
        Form2.Text = "Pregled unetih NHM pozicija u aneksima ugovora po CO"
        Form2.ShowDialog()
    End Sub
    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Label4.Text.Length = str.Length Then
    '        Timer1.Enabled = False
    '        Exit Sub
    '    End If
    '    Label4.Text = str.Substring(0, count)
    '    count = count + 1
    'End Sub

    Private Sub MenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem30.Click
        mPregledUnosa = "IKP"

        Dim Form2 As New FormGrid
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem31.Click
        mPregledUnosa = "IBK"  'Trazenje kola prema saobracanju

        Dim Form2p As New PregledParametri
        Form2p.ShowDialog()
    End Sub
End Class
