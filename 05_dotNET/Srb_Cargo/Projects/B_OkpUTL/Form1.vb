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
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem49 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem50 As System.Windows.Forms.MenuItem
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem35 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem45 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem36 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem38 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem41 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem43 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem44 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem47 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem48 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem51 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem46 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem52 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem53 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem54 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem50 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem49 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.MenuItem35 = New System.Windows.Forms.MenuItem
        Me.MenuItem36 = New System.Windows.Forms.MenuItem
        Me.MenuItem38 = New System.Windows.Forms.MenuItem
        Me.MenuItem41 = New System.Windows.Forms.MenuItem
        Me.MenuItem42 = New System.Windows.Forms.MenuItem
        Me.MenuItem43 = New System.Windows.Forms.MenuItem
        Me.MenuItem44 = New System.Windows.Forms.MenuItem
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.MenuItem46 = New System.Windows.Forms.MenuItem
        Me.MenuItem52 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem45 = New System.Windows.Forms.MenuItem
        Me.MenuItem32 = New System.Windows.Forms.MenuItem
        Me.MenuItem33 = New System.Windows.Forms.MenuItem
        Me.MenuItem34 = New System.Windows.Forms.MenuItem
        Me.MenuItem53 = New System.Windows.Forms.MenuItem
        Me.MenuItem48 = New System.Windows.Forms.MenuItem
        Me.MenuItem51 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem47 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem40 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.MenuItem37 = New System.Windows.Forms.MenuItem
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.MenuItem54 = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem27, Me.MenuItem6, Me.MenuItem8, Me.MenuItem48, Me.MenuItem13, Me.MenuItem12})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem9, Me.MenuItem4, Me.MenuItem5})
        Me.MenuItem1.Text = "Unos"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 0
        Me.MenuItem9.Text = "Unutrašnji saobraæaj"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 1
        Me.MenuItem4.Text = "-"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.Text = "Izlaz iz programa"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 1
        Me.MenuItem27.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem29, Me.MenuItem10, Me.MenuItem50})
        Me.MenuItem27.Text = "Izmena"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 0
        Me.MenuItem29.Text = "Izmena podataka na tovarnom listu"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 1
        Me.MenuItem10.Text = "-"
        '
        'MenuItem50
        '
        Me.MenuItem50.Index = 2
        Me.MenuItem50.Text = "Brisanje tovarnog lista iz baze podataka"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem49, Me.MenuItem3, Me.MenuItem2, Me.MenuItem31, Me.MenuItem46, Me.MenuItem52})
        Me.MenuItem6.Text = "Pregled"
        '
        'MenuItem49
        '
        Me.MenuItem49.Index = 0
        Me.MenuItem49.Text = "-"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem14, Me.MenuItem11})
        Me.MenuItem3.Text = "Dnevni unos"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 0
        Me.MenuItem14.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem19, Me.MenuItem20, Me.MenuItem21, Me.MenuItem22, Me.MenuItem28})
        Me.MenuItem14.Text = "Dnevni materijal"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 0
        Me.MenuItem19.Text = "Po otpravnoj stanici"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 1
        Me.MenuItem20.Text = "Po broju otpravljanja"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 2
        Me.MenuItem21.Text = "Po uputnoj stanici"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 3
        Me.MenuItem22.Text = "Po broju prispeca"
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 4
        Me.MenuItem28.Text = "Po ugovoru"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 1
        Me.MenuItem11.Text = "Ukupno po referentima"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 2
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem16, Me.MenuItem15, Me.MenuItem17, Me.MenuItem35, Me.MenuItem36})
        Me.MenuItem2.Text = "Mesecni unos"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 0
        Me.MenuItem16.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem23, Me.MenuItem24, Me.MenuItem25, Me.MenuItem26, Me.MenuItem30})
        Me.MenuItem16.Text = "Mesecni materijal za tekuci obracunski mesec"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 0
        Me.MenuItem23.Text = "Po otpravnoj stanici"
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 1
        Me.MenuItem24.Text = "Po broju otpravljanja"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 2
        Me.MenuItem25.Text = "Po uputnoj stanici"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 3
        Me.MenuItem26.Text = "Po broju prispeca"
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 4
        Me.MenuItem30.Text = "Po ugovoru"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 1
        Me.MenuItem15.Text = "Ukupno po referentima i danu unosa za tekuci obracunski mesec"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 2
        Me.MenuItem17.Text = "Ukupno po referentima za tekuci obracunski mesec"
        '
        'MenuItem35
        '
        Me.MenuItem35.Index = 3
        Me.MenuItem35.Text = "Izmena meseca za pregled"
        Me.MenuItem35.Visible = False
        '
        'MenuItem36
        '
        Me.MenuItem36.Index = 4
        Me.MenuItem36.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem38, Me.MenuItem41, Me.MenuItem42, Me.MenuItem43, Me.MenuItem44})
        Me.MenuItem36.Text = "Mesecni materijal za"
        Me.MenuItem36.Visible = False
        '
        'MenuItem38
        '
        Me.MenuItem38.Index = 0
        Me.MenuItem38.Text = "Po otpravnoj stanici"
        '
        'MenuItem41
        '
        Me.MenuItem41.Index = 1
        Me.MenuItem41.Text = "Po broju otpravljanja"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 2
        Me.MenuItem42.Text = "Po uputnoj stanici "
        '
        'MenuItem43
        '
        Me.MenuItem43.Index = 3
        Me.MenuItem43.Text = "Po broju prispeca"
        '
        'MenuItem44
        '
        Me.MenuItem44.Index = 4
        Me.MenuItem44.Text = "Po ugovoru"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 3
        Me.MenuItem31.Text = "Spec. 77"
        Me.MenuItem31.Visible = False
        '
        'MenuItem46
        '
        Me.MenuItem46.Index = 4
        Me.MenuItem46.Text = "Pregled aneneksa sa NHM pozicijama"
        '
        'MenuItem52
        '
        Me.MenuItem52.Index = 5
        Me.MenuItem52.Text = "Pregled kretanja kola u bazi"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 3
        Me.MenuItem8.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem7, Me.MenuItem18, Me.MenuItem45, Me.MenuItem32, Me.MenuItem33, Me.MenuItem34, Me.MenuItem53, Me.MenuItem54})
        Me.MenuItem8.Text = "Odrzavanje admin."
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 0
        Me.MenuItem7.Text = "Izmena racunskog meseca"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 1
        Me.MenuItem18.Text = "Izmena podataka o otpravljanju"
        '
        'MenuItem45
        '
        Me.MenuItem45.Index = 2
        Me.MenuItem45.Text = "Izmena podataka o prispecu"
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 3
        Me.MenuItem32.Text = "Dodavanje opisa kontrolnih primedbi"
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 4
        Me.MenuItem33.Text = "Dvostruka otpravljanja"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 5
        Me.MenuItem34.Text = "Dvostruka prispeca"
        '
        'MenuItem53
        '
        Me.MenuItem53.Index = 6
        Me.MenuItem53.Text = "Pregled po najavi i korekcija"
        '
        'MenuItem48
        '
        Me.MenuItem48.Index = 4
        Me.MenuItem48.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem51})
        Me.MenuItem48.Text = "Odrzavanje"
        '
        'MenuItem51
        '
        Me.MenuItem51.Index = 0
        Me.MenuItem51.Text = "Izmena posiljaoca i primaoca"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 5
        Me.MenuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem47})
        Me.MenuItem13.Text = "Stampa"
        '
        'MenuItem47
        '
        Me.MenuItem47.Index = 0
        Me.MenuItem47.Text = "Unos za vremenski period"
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
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 569)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(1008, 8)
        Me.StatusBar1.TabIndex = 11
        Me.StatusBar1.Text = "Tovarni list"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(11, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 56)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Unutrašnji"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1200, 550)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
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
        Me.Button5.Location = New System.Drawing.Point(560, 5)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(80, 56)
        Me.Button5.TabIndex = 7
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
        Me.Button6.Location = New System.Drawing.Point(801, 5)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(71, 56)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "Kraj"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(640, 5)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(80, 56)
        Me.Button8.TabIndex = 8
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
        Me.Button9.Location = New System.Drawing.Point(1104, 16)
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
        Me.Button10.Location = New System.Drawing.Point(1136, 16)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(27, 28)
        Me.Button10.TabIndex = 8
        Me.Button10.Text = "Transfer  ŽS ULAZ"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button10.Visible = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Enabled = False
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button12.Location = New System.Drawing.Point(721, 5)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(80, 56)
        Me.Button12.TabIndex = 9
        Me.Button12.Text = "Web -> ZS"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Enabled = False
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button7.Location = New System.Drawing.Point(334, 5)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(72, 56)
        Me.Button7.TabIndex = 1
        Me.Button7.Text = "Tranzit IZLAZ"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Enabled = False
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(253, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 56)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Tranzit ULAZ"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(172, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 56)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Izvoz"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(91, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 56)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Uvoz"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button11.Location = New System.Drawing.Point(486, 5)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(74, 56)
        Me.Button11.TabIndex = 6
        Me.Button11.Text = "Preuzimanje"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.SystemColors.Control
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.Enabled = False
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button13.Location = New System.Drawing.Point(406, 5)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(80, 56)
        Me.Button13.TabIndex = 5
        Me.Button13.Text = "Prikazi eTL"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'MenuItem54
        '
        Me.MenuItem54.Index = 7
        Me.MenuItem54.Text = "Provera statusa vlasništva kola"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(69, Byte), CType(68, Byte), CType(162, Byte))
        Me.ClientSize = New System.Drawing.Size(1008, 577)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ToolBar1)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Roba"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RecordAction = "N"

        Dim FormUpd As New UpdateForm
        FormUpd.Text = ":: Izmena u bazi podataka ::"
        FormUpd.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'PlaySound(Application.StartupPath & "\Media\tada.wav", 0, SND_NODEFAULT Or SND_ASYNC Or SND_FILENAME)
        MasterAction = "New"
        RecordAction = ""
        eRazmena = "Ne"
        IzborSaobracaja = "1"
        'bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()

        Dim FormUtl As New FormUTL
        FormUtl.Text = ":: Unutrasnji tovarni list ::"
        FormUtl.ShowDialog()

    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Dim FormUpd As New UpdateForm
        ''FormUpd.ShowDialog()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Close()

    End Sub

    Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''        Dim helpNalepnica As New hlpForm1
        ''      helpNalepnica.Text = "Izmena redosleda tranzitnih nalepnica"
        ''    helpNalepnica.ShowDialog()

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

        If bAdmin Then
            MenuItem7.Visible = True    ' izmena racunskog meseca
            MenuItem8.Visible = True    ' odrzavanje
            MenuItem35.Visible = True
            MenuItem13.Enabled = True
            'If Not (_OpenForm = "MesecGodina") Then
            '    bPostaviObracunskiMesec(bPregledObrMesec, bPregledObrGodina)
            'End If
            MenuItem36.Text = "Mesecni materijal za  " & bPregledObrMesec & "." & bPregledObrGodina & ".g."
            MenuItem31.Visible = True
            MenuItem47.Enabled = True
            MenuItem36.Visible = True
        Else
            MenuItem7.Visible = False
            MenuItem8.Visible = False
            MenuItem35.Visible = False
            MenuItem36.Visible = False
            MenuItem13.Enabled = False
            MenuItem47.Enabled = False
        End If

        If bAdmin77 Then
            MenuItem31.Visible = True
        Else
            MenuItem31.Visible = False
        End If


        'If _OpenForm = "MesecGodina" Then
        '    MenuItem35.Text = "Mesecni materijal za  " & bPregledObrMesec & "." & bPregledObrGodina & ".g."
        'End If


    End Sub

    'Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
    '    eWebRazmena = "Da"
    '    IzborSaobracaja = "1"

    '    Dim Preuzimanje As New web2zs
    '    Preuzimanje.ShowDialog()

    '    ''Dim FormUtl As New FormUTL
    '    ''FormUtl.Text = ":: unutasnji tovarni list ::"
    '    ''FormUtl.ShowDialog()
    'End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        RecordAction = "P"

        Dim FormUpd As New UpdateForm
        FormUpd.Text = ":: Prezimanje elektronskog tovarnog lista ::"
        FormUpd.ShowDialog()
    End Sub


    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        mCistUnos = "Ne"
        AkcijaZaPreuzimanje = "Da"
        MM_Action = "New"
        RecordAction = "P"
        Dim formPreuzmi As New UpdateForm

        formPreuzmi.Text = ":: Preuzimanje ::"
        formPreuzmi.ShowDialog()

    End Sub
    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        mPregledUnosa = "M"
        Dim FormPregledMaterijala As New FormPregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        mPregledUnosa = "D"  'dnevni

        'Dim FormPregledMaterijala As New FormPregledTL
        'FormPregledMaterijala.ShowDialog()

        Dim Form2 As New FormGrid
        Form2.ShowDialog()
    End Sub

    Private Sub Button3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.GotFocus
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        ' dnevno po referentima
        DatumPrikaza = "Dnevni"

        'mPregledUnosa = "D"
        Dim Form2 As New FormGrid
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Click
        ' dnevni materijal
        'DatumPrikaza = "Dnevni"

        'Dim FormPregledMaterijala As New PregledTL
        'FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        ' mesecno po referentima
        DatumPrikaza = "Mesecni"

        Dim Form2 As New FormGrid
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        ' mesecni materijal po danu unosa
        DatumPrikaza = "Mesecni"
        bPregledTekucegMeseca = True
        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        ' mesecno po referentima sve
        DatumPrikaza = "MesecniSve"

        Dim Form2 As New FormGrid
        Form2.ShowDialog()
    End Sub

    Private Sub MenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem19.Click
        bOrder = 1
        DatumPrikaza = "Dnevni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()

    End Sub

    Private Sub MenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem20.Click
        bOrder = 2
        DatumPrikaza = "Dnevni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem21.Click
        bOrder = 3
        DatumPrikaza = "Dnevni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem22.Click
        bOrder = 4
        DatumPrikaza = "Dnevni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem23.Click
        bOrder = 1
        DatumPrikaza = "Mesecni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Click
        bOrder = 2
        DatumPrikaza = "Mesecni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem25_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem25.Click
        bOrder = 3
        DatumPrikaza = "Mesecni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem26_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem26.Click
        bOrder = 4
        DatumPrikaza = "Mesecni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem28.Click
        bOrder = 5
        DatumPrikaza = "Dnevni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem30.Click
        bOrder = 5
        DatumPrikaza = "Mesecni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()

    End Sub

    Private Sub MenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem18.Click
        Dim FormOI As New OtpIzmena
        FormOI.ShowDialog()
    End Sub

    Private Sub MenuItem31_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem31.Click
        bOrder = 77
        DatumPrikaza = "Mesecni"

        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()

    End Sub

    Private Sub MenuItem32_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem32.Click
        Dim FormKP As New KontrolPrim
        FormKP.ShowDialog()
    End Sub

    Private Sub MenuItem33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem33.Click
        Dim Pregled As New FormGrid
        bVrstaPregledGrida = "DOtpr"
        Pregled.ShowDialog()
    End Sub
    Private Sub MenuItem34_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem34.Click
        Dim Pregled As New FormGrid
        bVrstaPregledGrida = "DPris"
        Pregled.ShowDialog()
    End Sub

    Private Sub MenuItem35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem35.Click
        Dim Pregled As New FormPregledTL
        Pregled.ShowDialog()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bPostaviObracunskiMesec(bPregledObrMesec, bPregledObrGodina)
        bPregledObrMesec = bPregledObrMesec
        bPregledObrGodina = bPregledObrGodina
        MenuItem36.Text = "Mesecni materijal za  " & bPregledObrMesec & "." & bPregledObrGodina & ".g."
    End Sub

    Private Sub MenuItem45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pregled As New FormPregledTL
        Pregled.ShowDialog()
    End Sub

    Private Sub MenuItem45_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem45.Click
        Dim FormPI As New PrIzmena
        FormPI.ShowDialog()
    End Sub

    Private Sub MenuItem38_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem38.Click
        bOrder = 1
        DatumPrikaza = "Mesecni"
        bPregledTekucegMeseca = False
        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem41.Click
        bOrder = 2
        DatumPrikaza = "Mesecni"
        bPregledTekucegMeseca = False
        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem42_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem42.Click
        bOrder = 3
        DatumPrikaza = "Mesecni"
        bPregledTekucegMeseca = False
        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem43_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem43.Click
        bOrder = 4
        DatumPrikaza = "Mesecni"
        bPregledTekucegMeseca = False
        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem44_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem44.Click
        bOrder = 5
        DatumPrikaza = "Mesecni"
        bPregledTekucegMeseca = False
        Dim FormPregledMaterijala As New PregledTL
        FormPregledMaterijala.ShowDialog()
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        Dim Pregled As New RacunskiMesec
        Pregled.ShowDialog()
    End Sub

    Private Sub MenuItem46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim DatOdDo As New DatumOdDo
        'DatOdDo.ShowDialog()
    End Sub

    Private Sub MenuItem47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem47.Click
        Dim DatOdDo As New DatumOdDo
        DatOdDo.ShowDialog()
    End Sub

    Private Sub MenuItem46_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FormPP As New PosPrimIzmena
        FormPP.ShowDialog()
    End Sub

    Private Sub MenuItem51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem51.Click
        Dim FormPP As New PosPrimIzmena
        FormPP.ShowDialog()
    End Sub

    Private Sub MenuItem46_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem46.Click

        Dim Form2 As New PregledNHMGrid
        'Form2.Text = "Pregled unetih NHM pozicija u aneksima ugovora po CO"
        Form2.Text = "Pregled aneksa ugovora po CO sa NHM pozicijama"
        Form2.ShowDialog()

    End Sub

    Private Sub MenuItem52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem52.Click
        mPregledUnosa = "IBK"  'Trazenje kola prema saobracanju

        Dim Form2p As New PregledParametri
        Form2p.ShowDialog()
    End Sub

    
    Private Sub MenuItem53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem53.Click
        mPregledUnosa = "Najava"  'trazenje TL prema najavi
        Dim Form2ppp As New PregledPoNajaviParametri
        Form2ppp.ShowDialog()
    End Sub

    Private Sub MenuItem54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem54.Click      
        Dim FormStatusKola As New StatusKola
        FormStatusKola.ShowDialog()
    End Sub
End Class
