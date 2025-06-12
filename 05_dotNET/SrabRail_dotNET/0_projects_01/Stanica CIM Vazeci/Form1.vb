Imports System.IO
Imports System.IO.File
Imports System.Data.SqlClient
'Imports CrystalDecisions.Shared
Public Class Form1
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem35 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem36 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem38 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem41 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem43 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem44 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem45 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem46 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem47 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem48 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem49 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem50 As System.Windows.Forms.MenuItem
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents MenuItem51 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem52 As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents MenuItem53 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem54 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem44 = New System.Windows.Forms.MenuItem
        Me.MenuItem45 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem50 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.MenuItem46 = New System.Windows.Forms.MenuItem
        Me.MenuItem47 = New System.Windows.Forms.MenuItem
        Me.MenuItem48 = New System.Windows.Forms.MenuItem
        Me.MenuItem49 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem42 = New System.Windows.Forms.MenuItem
        Me.MenuItem41 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem43 = New System.Windows.Forms.MenuItem
        Me.MenuItem52 = New System.Windows.Forms.MenuItem
        Me.MenuItem51 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.MenuItem32 = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem38 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.MenuItem36 = New System.Windows.Forms.MenuItem
        Me.MenuItem33 = New System.Windows.Forms.MenuItem
        Me.MenuItem34 = New System.Windows.Forms.MenuItem
        Me.MenuItem53 = New System.Windows.Forms.MenuItem
        Me.MenuItem35 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem40 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.MenuItem37 = New System.Windows.Forms.MenuItem
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Button14 = New System.Windows.Forms.Button
        Me.MenuItem54 = New System.Windows.Forms.MenuItem
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem27, Me.MenuItem6, Me.MenuItem8, Me.MenuItem13, Me.MenuItem18, Me.MenuItem12})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem7, Me.MenuItem9, Me.MenuItem4, Me.MenuItem5})
        Me.MenuItem1.Text = "Unos"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Uvoz"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Izvoz"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 2
        Me.MenuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem44, Me.MenuItem45})
        Me.MenuItem7.Text = "Tranzit"
        '
        'MenuItem44
        '
        Me.MenuItem44.Index = 0
        Me.MenuItem44.Text = "Ulaz"
        '
        'MenuItem45
        '
        Me.MenuItem45.Index = 1
        Me.MenuItem45.Text = "Izlaz"
        '
        'MenuItem9
        '
        Me.MenuItem9.Enabled = False
        Me.MenuItem9.Index = 3
        Me.MenuItem9.Text = "Unutrašnji saobracaj"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 4
        Me.MenuItem4.Text = "-"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 5
        Me.MenuItem5.Text = "Izlaz iz programa"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 1
        Me.MenuItem27.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem28, Me.MenuItem29, Me.MenuItem10, Me.MenuItem50})
        Me.MenuItem27.Text = "Izmena"
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 0
        Me.MenuItem28.Text = "Izmena tranzitnih markica na tovarnom listu"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 1
        Me.MenuItem29.Text = "Izmena podataka na tovarnom listu"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 2
        Me.MenuItem10.Text = "-"
        '
        'MenuItem50
        '
        Me.MenuItem50.Index = 3
        Me.MenuItem50.Text = "Brisanje tovarnog lista iz baze podataka"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem26, Me.MenuItem46, Me.MenuItem49, Me.MenuItem11})
        Me.MenuItem6.Text = "Pregled"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 0
        Me.MenuItem26.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem14, Me.MenuItem17})
        Me.MenuItem26.Text = "Dnevni unos tovarnih listova"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 0
        Me.MenuItem14.Text = "Ulazne posiljke"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 1
        Me.MenuItem17.Text = "Izlazne posiljke"
        '
        'MenuItem46
        '
        Me.MenuItem46.Index = 1
        Me.MenuItem46.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem47, Me.MenuItem48})
        Me.MenuItem46.Text = "Dnevni unos vozova"
        '
        'MenuItem47
        '
        Me.MenuItem47.Index = 0
        Me.MenuItem47.Text = "Ulazni vozovi"
        '
        'MenuItem48
        '
        Me.MenuItem48.Index = 1
        Me.MenuItem48.Text = "Izlazni vozovi"
        '
        'MenuItem49
        '
        Me.MenuItem49.Index = 2
        Me.MenuItem49.Text = "-"
        '
        'MenuItem11
        '
        Me.MenuItem11.Enabled = False
        Me.MenuItem11.Index = 3
        Me.MenuItem11.Text = "Ugovori po telegramima "
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 3
        Me.MenuItem8.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem25, Me.MenuItem22})
        Me.MenuItem8.Text = "Odrzavanje"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 0
        Me.MenuItem25.Text = "Izmena redosleda tranzitnih nalepnica za stanicu"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 1
        Me.MenuItem22.Text = "-"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 4
        Me.MenuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem15, Me.MenuItem16, Me.MenuItem42, Me.MenuItem41, Me.MenuItem19, Me.MenuItem43, Me.MenuItem52, Me.MenuItem51, Me.MenuItem20, Me.MenuItem21, Me.MenuItem24, Me.MenuItem54})
        Me.MenuItem13.Text = "Stampa"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 0
        Me.MenuItem15.Text = "K140trz - Dnevni racun ulaznih posiljaka u tranzitu"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 1
        Me.MenuItem16.Text = "K165trz - Dnevni racun izlaznih posiljaka u tranzitu"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 2
        Me.MenuItem42.Text = "K165m  -  Dnevni racun izlaznih pošiljaka u izvozu"
        '
        'MenuItem41
        '
        Me.MenuItem41.Index = 3
        Me.MenuItem41.Text = "-"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 4
        Me.MenuItem19.Text = "K200     -  Spisak prelaza"
        '
        'MenuItem43
        '
        Me.MenuItem43.Index = 5
        Me.MenuItem43.Text = "-"
        '
        'MenuItem52
        '
        Me.MenuItem52.Index = 6
        Me.MenuItem52.Text = "K-140m - Dnevni racun otpravljanja stvari"
        '
        'MenuItem51
        '
        Me.MenuItem51.Index = 7
        Me.MenuItem51.Text = "K-165m - Dnevni  racun prispeca stvari"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 8
        Me.MenuItem20.Text = "-"
        '
        'MenuItem21
        '
        Me.MenuItem21.Enabled = False
        Me.MenuItem21.Index = 9
        Me.MenuItem21.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem31, Me.MenuItem32})
        Me.MenuItem21.Text = "Tovarni list"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 0
        Me.MenuItem31.Text = "CIM"
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 1
        Me.MenuItem32.Text = "K-501"
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 10
        Me.MenuItem24.Text = "Specifikacija vagona i tovarnih listova za Carinu"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 5
        Me.MenuItem18.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem38, Me.MenuItem23, Me.MenuItem30, Me.MenuItem36, Me.MenuItem33, Me.MenuItem34, Me.MenuItem53, Me.MenuItem35})
        Me.MenuItem18.Text = "Carina"
        '
        'MenuItem38
        '
        Me.MenuItem38.Enabled = False
        Me.MenuItem38.Index = 0
        Me.MenuItem38.Text = "::: Azuriranje podataka iz Carine :::"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 1
        Me.MenuItem23.Text = "     Po pojedinacnom tovarnom listu"
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 2
        Me.MenuItem30.Text = "     Po vozu"
        '
        'MenuItem36
        '
        Me.MenuItem36.Index = 3
        Me.MenuItem36.Text = "     Po specifikaciji vagona i tovarnih listova"
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 4
        Me.MenuItem33.Text = "-"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 5
        Me.MenuItem34.Text = "Formiranje elektronske deklaracije JCI"
        '
        'MenuItem53
        '
        Me.MenuItem53.Index = 6
        Me.MenuItem53.Text = "Evidencija o transportnim postupcima"
        '
        'MenuItem35
        '
        Me.MenuItem35.Enabled = False
        Me.MenuItem35.Index = 7
        Me.MenuItem35.Text = "Pregled carinskih deklaracija za voz"
        Me.MenuItem35.Visible = False
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 6
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
        Me.ToolBar1.Size = New System.Drawing.Size(1008, 64)
        Me.ToolBar1.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(168, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 56)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Uvoz"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(248, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 56)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Izvoz"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 679)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(1008, 22)
        Me.StatusBar1.TabIndex = 11
        Me.StatusBar1.Text = "Tovarni list"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Enabled = False
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(568, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 56)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Unutrašnji"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(8, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 56)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Tranzit ULAZ"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1008, 615)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(728, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(80, 56)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Izmena"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.Location = New System.Drawing.Point(888, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 56)
        Me.Button6.TabIndex = 9
        Me.Button6.Text = "Kraj"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button7.Location = New System.Drawing.Point(88, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(80, 56)
        Me.Button7.TabIndex = 1
        Me.Button7.Text = "Tranzit IZLAZ"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(808, 4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(80, 56)
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
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Enabled = False
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(1080, 8)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(27, 28)
        Me.Button9.TabIndex = 7
        Me.Button9.Text = "Transfer  ŽS IZLAZ"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button9.Visible = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.SystemColors.Control
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Enabled = False
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button10.Location = New System.Drawing.Point(1104, 8)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(27, 28)
        Me.Button10.TabIndex = 8
        Me.Button10.Text = "Transfer  ŽS ULAZ"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button10.Visible = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button11.Location = New System.Drawing.Point(408, 4)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(80, 56)
        Me.Button11.TabIndex = 7
        Me.Button11.Text = "eCIM"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Enabled = False
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button12.Location = New System.Drawing.Point(648, 4)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(80, 56)
        Me.Button12.TabIndex = 8
        Me.Button12.Text = "Web -> ZS"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.SystemColors.Control
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button13.Location = New System.Drawing.Point(328, 4)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(80, 56)
        Me.Button13.TabIndex = 13
        Me.Button13.Text = " I Z V O Z  Preuzimanje"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 535)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 144)
        Me.Panel1.TabIndex = 15
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
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(64, Byte), CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(144, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(400, 23)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "INFO panel - izmene u radu sa programom"
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
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.SystemColors.Control
        Me.Button14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button14.Enabled = False
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button14.Image = CType(resources.GetObject("Button14.Image"), System.Drawing.Image)
        Me.Button14.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button14.Location = New System.Drawing.Point(488, 4)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(80, 56)
        Me.Button14.TabIndex = 16
        Me.Button14.Text = "NCTS"
        '
        'MenuItem54
        '
        Me.MenuItem54.Index = 11
        Me.MenuItem54.Text = "Evidencija o transportnim postupcima za Carinu"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(91, Byte), CType(132, Byte), CType(89, Byte))
        Me.ClientSize = New System.Drawing.Size(1008, 701)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.StatusBar1)
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
        MasterAction = "New"
        eRazmena = "Ne"
        RecordAction = "I"
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        Dim fCim As New FormCim
        IzborSaobracaja = "2"
        bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
        fCim.Text = ":: CIM - U V O Z ::"
        fCim.ShowDialog()

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        eRazmena = "Ne"
        MasterAction = "New"
        RecordAction = "I"
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        Dim fCim As New FormCim
        IzborSaobracaja = "3"
        bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
        fCim.Text = ":: CIM - I Z V O Z ::"
        fCim.ShowDialog()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MasterAction = "New"
        '-----------------
        RecordAction = "I"

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim sql_text As String = "SELECT UlaznaNalepnica " & _
                                 "FROM dbo.ZsTrzNalepnice " & _
                                 "WHERE (dbo.ZsTrzNalepnice.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrTrz As SqlClient.SqlDataReader

        rdrTrz = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrTrz.Read()
            mUlEtiketa = rdrTrz.GetInt32(0) + 1
        Loop
        rdrTrz.Close()
        DbVeza.Close()
        '-----------------

        eRazmena = "Ne"
        TipTranzita = "ulaz"
        mIzEtiketa = 0
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        Dim fCim As New FormCim
        IzborSaobracaja = "4"
        bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
        fCim.Text = ":: CIM - Tranzit ULAZ ::"
        fCim.ShowDialog()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RecordAction = "N"

        Dim FormUpd As New UpdateForm
        FormUpd.Text = ":: Izmena u bazi podataka ::"
        FormUpd.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        eRazmena = "Ne"
        ''Dim form2a As New TrzStart
        IzborSaobracaja = "1"
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        mUlEtiketa = 0
        mIzEtiketa = 0

        bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
        ''form2a.Text = ":: Unutrasnji saobracaj ::"
        ''form2a.ShowDialog()
    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Dim FormUpd As New UpdateForm
        ''FormUpd.ShowDialog()

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
        eRazmena = "Ne"
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
        form2b.Text = ":: Tranzit IZLAZ ::"
        form2b.ShowDialog()

    End Sub

    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        Stampa = "k140"
        Dim FormaZaCR As New FormDatum
        FormaZaCR.ShowDialog()

    End Sub

    Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''        Dim helpNalepnica As New hlpForm1
        ''      helpNalepnica.Text = "Izmena redosleda tranzitnih nalepnica"
        ''    helpNalepnica.ShowDialog()

    End Sub

    

    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        Stampa = "k165"
        Dim FormaZaCR As New FormDatum
        FormaZaCR.ShowDialog()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        RecordAction = "D"

        Dim formDel As New UpdateForm
        formDel.Text = ":: Brisanje ::"
        formDel.ShowDialog()
    End Sub

    Private Sub MenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Dim helpUic As New HelpForm
        ''helpUic.Text = "help K140trz"
        upit = "K140"
        ''helpUic.ShowDialog()

    End Sub
    Private Sub MenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Dim helpUic As New HelpForm
        ''helpUic.Text = "help K165trz"
        upit = "K165"
        ''helpUic.ShowDialog()

    End Sub

    Private Sub MenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem40.Click
        'Help.ShowHelp(Me, HelpProvider1.HelpNamespace)
    End Sub

    Private Sub MenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem37.Click
        Dim AboutUs As New About
        AboutUs.Text = Date.Today
        AboutUs.ShowDialog()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '========== ucitava info
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        'Dim sql_trz3 As String = "SELECT Text FROM InfoPanel WHERE ( Text='2')"
        'Dim sql_trz3 As String = "SELECT Text FROM InfoPanel WHERE ( Datum < '" & Date.Today.AddDays(-10) & "')"
        Dim sql_trz3 As String = "SELECT Text, Datum FROM InfoPanel ORDER BY Datum DESC"

        Dim sql_commTrz3 As New SqlClient.SqlCommand(sql_trz3, DbVeza)
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
        DbVeza.Close()
        '==============================

        Me.MenuItem25.Text = Me.MenuItem25.Text & " " & Microsoft.VisualBasic.Mid(StanicaUnosa, 10, Len(StanicaUnosa))

        'If GranicnaStanica = "D" Then
        '    Me.Button2.Visible = True
        'Else
        '    Me.Button2.Visible = False
        'End If

        If GranicnaStanica = "N" Then
            Me.MenuItem6.Enabled = False

            Me.Button4.Enabled = False
            Me.Button7.Enabled = False
            Me.MenuItem7.Enabled = False
            Me.MenuItem8.Enabled = False
            Me.MenuItem28.Enabled = False

            Me.MenuItem15.Enabled = False
            Me.MenuItem16.Enabled = False
            Me.MenuItem19.Enabled = False

            Me.MenuItem42.Visible = False
            Me.MenuItem51.Visible = True
            Me.MenuItem52.Visible = True

            Me.Button5.Text = "Preuzimanje [ U V O Z ]"
        Else
            Me.MenuItem6.Enabled = True

            Me.Button4.Enabled = True
            Me.Button7.Enabled = True
            Me.MenuItem7.Enabled = True
            Me.MenuItem8.Enabled = True
            Me.MenuItem28.Enabled = True

            Me.MenuItem15.Enabled = True
            Me.MenuItem16.Enabled = True
            Me.MenuItem19.Enabled = True

            Me.MenuItem42.Visible = True
            Me.MenuItem51.Visible = False
            Me.MenuItem52.Visible = False

            Me.Button5.Text = "Izmena"
        End If

        If eCimDa = "D" Then
            If GranicnaStanica = "D" Then
                Me.Button11.Enabled = True
                Me.Button13.Enabled = True
            Else
                Me.Button11.Enabled = False
                Me.Button13.Enabled = False
            End If
        Else
            Me.Button11.Enabled = False
            Me.Button13.Enabled = False
        End If
    End Sub

    Private Sub MenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem19.Click
        StampaId = "K200"

        Dim FormaZaCR As New FormK200
        FormaZaCR.ShowDialog()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        ''     Dim IzlazniVoz As New FormTransfer1
        ''   IzlazniVoz.Text = "Slanje podataka susednoj upravi"
        '' IzlazniVoz.ShowDialog()

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        ''        Dim UlazniVoz As New FormTransfer2
        ''      UlazniVoz.Text = "Preuzimanje podataka od susedne uprave"
        ''    UlazniVoz.ShowDialog()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        eRazmena = "Da"

        Dim Preuzimanje As New OtpIzmena
        Preuzimanje.ShowDialog()
    End Sub

    Private Sub MenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem23.Click
        Dim fCarina As New UpdCar1
        fCarina.Text = ":: Unos brojeva MRN ::"
        fCarina.ShowDialog()

    End Sub

    Private Sub MenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem34.Click
        'Dim frmXMLCarina As New frmCarinaXML
        'frmXMLCarina.ShowDialog()
        'frmXMLCarina.Dispose()
    End Sub

    Private Sub MenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem36.Click
        Dim fCarina As New UpdCarina
        fCarina.Text = ":: Unos brojeva MRN ::"
        fCarina.ShowDialog()
    End Sub
    Private Sub MenuItem44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem44.Click
        Button4_Click(Me, Nothing)
    End Sub

    Private Sub MenuItem45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem45.Click
        Button7_Click(Me, Nothing)
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Button1_Click(Me, Nothing)
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Button2_Click(Me, Nothing)
    End Sub

    Private Sub MenuItem25_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem25.Click
        Dim TrzNalepnice As New Nalepnice
        TrzNalepnice.ShowDialog()
    End Sub

    Private Sub MenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Click
        StampaId = "CarSpec"
        Dim FormaZaCR As New FormK200
        FormaZaCR.ShowDialog()
    End Sub

    Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Click
        ''mPregledUnosa = "D"  'dnevni
        Stampa = "grUlaz"
        Dim Form2 As New FormDatum
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem42.Click
        Stampa = "k165m"
        Dim FormaZaCR As New FormDatum
        FormaZaCR.ShowDialog()
    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        Stampa = "grIzlaz"
        Dim Form2 As New FormDatum
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem28.Click
        Dim FormaUpdTrz As New UpdTrzNalepnice
        FormaUpdTrz.ShowDialog()

    End Sub


    Private Sub MenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem30.Click
        Dim FormKorekcija As New KorekcijaPoNajavi
        FormKorekcija.Text = "Azuriranje podataka o roku carinjenja"
        FormKorekcija.ShowDialog()
    End Sub


    Private Sub MenuItem47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem47.Click
        Stampa = "grUlazniVozovi"
        Dim Form2 As New FormDatum
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem48.Click
        Stampa = "grIzlazniVozovi"
        Dim Form2 As New FormDatum
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        Close()

    End Sub

    Private Sub MenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem29.Click
        RecordAction = "N"

        Dim FormUpd As New UpdateForm
        FormUpd.Text = ":: Izmena u bazi podataka ::"
        FormUpd.ShowDialog()
    End Sub

    Private Sub MenuItem50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem50.Click
        RecordAction = "D"

        Dim formDel As New UpdateForm
        formDel.Text = ":: Brisanje ::"
        formDel.ShowDialog()
    End Sub
    ''Private Sub MenuItem2_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MenuItem2.DrawItem
    ''    Dim Ic As New Icon("d:\Icon200.ico")
    ''    DrawItems(e, MenuItem2, Nothing)
    ''End Sub

    ''Private Sub MenuItem2_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles MenuItem2.MeasureItem
    ''    MeasureItems(e, MenuItem2)
    ''    e.ItemWidth = 150
    ''End Sub

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        eRazmena = "Ne"
        eWebRazmena = "Ne"
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        '''''eWebRazmena = "Da"
        '''''IzborSaobracaja = "1"

        '''''Dim Preuzimanje As New web2zs
        '''''Preuzimanje.ShowDialog()


        ''Dim FormUtl As New FormUTL
        ''FormUtl.Text = ":: unutasnji tovarni list ::"
        ''FormUtl.ShowDialog()
    End Sub


    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        eRazmena = "Da"

        Dim PreuzimanjeEx As New OtpIzmenaEx
        PreuzimanjeEx.ShowDialog()
    End Sub

    Private Sub MenuItem51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem51.Click
        Stampa = "k165mRadinac"
        Dim FormaZaCR As New FormDatum
        FormaZaCR.ShowDialog()
    End Sub

    Private Sub MenuItem52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem52.Click
        Stampa = "k140mRadinac"
        Dim FormaZaCR As New FormDatum
        FormaZaCR.ShowDialog()
    End Sub

    Private Sub MenuItem54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem54.Click
        StampaId = "CarSpec"
        Dim FormaZaCR As New FormK200
        FormaZaCR.ShowDialog()
    End Sub
End Class
