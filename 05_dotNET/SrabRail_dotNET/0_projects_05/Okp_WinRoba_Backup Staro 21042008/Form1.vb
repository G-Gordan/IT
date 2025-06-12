Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
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
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents ToolBar2 As System.Windows.Forms.ToolBar
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
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem45 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem44 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem46 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem47 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem48 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem50 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem51 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem52 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem53 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem54 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem58 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem60 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem61 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem62 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem65 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem66 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem69 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem70 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem73 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem74 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem75 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem76 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem77 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem78 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem80 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem81 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem55 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem56 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem79 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem71 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem57 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem72 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem82 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem83 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem84 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem67 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem49 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem68 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem85 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem63 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem86 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem87 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem88 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem43 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
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
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem63 = New System.Windows.Forms.MenuItem
        Me.MenuItem61 = New System.Windows.Forms.MenuItem
        Me.MenuItem62 = New System.Windows.Forms.MenuItem
        Me.MenuItem73 = New System.Windows.Forms.MenuItem
        Me.MenuItem72 = New System.Windows.Forms.MenuItem
        Me.MenuItem82 = New System.Windows.Forms.MenuItem
        Me.MenuItem83 = New System.Windows.Forms.MenuItem
        Me.MenuItem84 = New System.Windows.Forms.MenuItem
        Me.MenuItem60 = New System.Windows.Forms.MenuItem
        Me.MenuItem86 = New System.Windows.Forms.MenuItem
        Me.MenuItem47 = New System.Windows.Forms.MenuItem
        Me.MenuItem50 = New System.Windows.Forms.MenuItem
        Me.MenuItem71 = New System.Windows.Forms.MenuItem
        Me.MenuItem51 = New System.Windows.Forms.MenuItem
        Me.MenuItem58 = New System.Windows.Forms.MenuItem
        Me.MenuItem55 = New System.Windows.Forms.MenuItem
        Me.MenuItem87 = New System.Windows.Forms.MenuItem
        Me.MenuItem56 = New System.Windows.Forms.MenuItem
        Me.MenuItem85 = New System.Windows.Forms.MenuItem
        Me.MenuItem88 = New System.Windows.Forms.MenuItem
        Me.MenuItem46 = New System.Windows.Forms.MenuItem
        Me.MenuItem68 = New System.Windows.Forms.MenuItem
        Me.MenuItem79 = New System.Windows.Forms.MenuItem
        Me.MenuItem65 = New System.Windows.Forms.MenuItem
        Me.MenuItem67 = New System.Windows.Forms.MenuItem
        Me.MenuItem57 = New System.Windows.Forms.MenuItem
        Me.MenuItem48 = New System.Windows.Forms.MenuItem
        Me.MenuItem44 = New System.Windows.Forms.MenuItem
        Me.MenuItem49 = New System.Windows.Forms.MenuItem
        Me.MenuItem66 = New System.Windows.Forms.MenuItem
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
        Me.MenuItem53 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.MenuItem42 = New System.Windows.Forms.MenuItem
        Me.MenuItem54 = New System.Windows.Forms.MenuItem
        Me.MenuItem69 = New System.Windows.Forms.MenuItem
        Me.MenuItem70 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem40 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.MenuItem37 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.ToolBar2 = New System.Windows.Forms.ToolBar
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Button9 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem74, Me.MenuItem13, Me.MenuItem18, Me.MenuItem12})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem9, Me.MenuItem2, Me.MenuItem3, Me.MenuItem80, Me.MenuItem7, Me.MenuItem8, Me.MenuItem81, Me.MenuItem14, Me.MenuItem4, Me.MenuItem5})
        Me.MenuItem1.Text = "Unos"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 0
        Me.MenuItem9.Text = "Unutrasnji saobracaj"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "Uvoz"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "Izvoz"
        '
        'MenuItem80
        '
        Me.MenuItem80.Index = 3
        Me.MenuItem80.Text = "-"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 4
        Me.MenuItem7.Text = "Tranzit"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 5
        Me.MenuItem8.Text = "-"
        '
        'MenuItem81
        '
        Me.MenuItem81.Index = 6
        Me.MenuItem81.Text = "Beograd Ranzirna - Granica"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 7
        Me.MenuItem14.Text = "Zaostala kola iz Beograd Ranzirne "
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 8
        Me.MenuItem4.Text = "-"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 9
        Me.MenuItem5.Text = "Izlaz iz programa"
        '
        'MenuItem74
        '
        Me.MenuItem74.Index = 1
        Me.MenuItem74.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem75, Me.MenuItem78, Me.MenuItem76, Me.MenuItem77})
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
        Me.MenuItem78.Text = "Relacija : Granica - Beograd Ranzirna"
        '
        'MenuItem76
        '
        Me.MenuItem76.Index = 2
        Me.MenuItem76.Text = "-"
        '
        'MenuItem77
        '
        Me.MenuItem77.Index = 3
        Me.MenuItem77.Text = "Relacija : Beograd Ranzirna - Granica"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 2
        Me.MenuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem63, Me.MenuItem61, Me.MenuItem62, Me.MenuItem73, Me.MenuItem72, Me.MenuItem60, Me.MenuItem86, Me.MenuItem47, Me.MenuItem55, Me.MenuItem87, Me.MenuItem56, Me.MenuItem85, Me.MenuItem88, Me.MenuItem46, Me.MenuItem68, Me.MenuItem79, Me.MenuItem65, Me.MenuItem67, Me.MenuItem57, Me.MenuItem48, Me.MenuItem44, Me.MenuItem49, Me.MenuItem66, Me.MenuItem43, Me.MenuItem15, Me.MenuItem16})
        Me.MenuItem13.Text = "Stampa"
        '
        'MenuItem63
        '
        Me.MenuItem63.Enabled = False
        Me.MenuItem63.Index = 0
        Me.MenuItem63.Text = "[ PROODOS, SCHENKER, EXPRESS ]"
        '
        'MenuItem61
        '
        Me.MenuItem61.Index = 1
        Me.MenuItem61.Text = "Prodos - direktni vozovi i vozovi do Beograd Ranzirne"
        '
        'MenuItem62
        '
        Me.MenuItem62.Index = 2
        Me.MenuItem62.Text = "Prodos - vozovi od Beograd Ranzirne"
        '
        'MenuItem73
        '
        Me.MenuItem73.Index = 3
        Me.MenuItem73.Text = "Prodos - kontejnerski vozovi"
        '
        'MenuItem72
        '
        Me.MenuItem72.Index = 4
        Me.MenuItem72.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem82, Me.MenuItem83, Me.MenuItem84})
        Me.MenuItem72.Text = "Prodos - Rekapitulacija za vozove "
        '
        'MenuItem82
        '
        Me.MenuItem82.Index = 0
        Me.MenuItem82.Text = "Direktni vozovi i vozovi do Beograd Ranzirne"
        '
        'MenuItem83
        '
        Me.MenuItem83.Index = 1
        Me.MenuItem83.Text = "Vozovi od Beograd Ranzirne"
        '
        'MenuItem84
        '
        Me.MenuItem84.Index = 2
        Me.MenuItem84.Text = "Kontejnerski vozovi"
        '
        'MenuItem60
        '
        Me.MenuItem60.Index = 5
        Me.MenuItem60.Text = "-"
        '
        'MenuItem86
        '
        Me.MenuItem86.Enabled = False
        Me.MenuItem86.Index = 6
        Me.MenuItem86.Text = "[ ICF, ADRIACOMBI, EUROLOG ]"
        '
        'MenuItem47
        '
        Me.MenuItem47.Index = 7
        Me.MenuItem47.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem50, Me.MenuItem71, Me.MenuItem51, Me.MenuItem58})
        Me.MenuItem47.Text = "Model izvestaja Intercontainer"
        '
        'MenuItem50
        '
        Me.MenuItem50.Index = 0
        Me.MenuItem50.Text = "Intercontainer"
        '
        'MenuItem71
        '
        Me.MenuItem71.Index = 1
        Me.MenuItem71.Text = "-"
        '
        'MenuItem51
        '
        Me.MenuItem51.Index = 2
        Me.MenuItem51.Text = "Adria combi"
        '
        'MenuItem58
        '
        Me.MenuItem58.Index = 3
        Me.MenuItem58.Text = "Eurolog"
        '
        'MenuItem55
        '
        Me.MenuItem55.Index = 8
        Me.MenuItem55.Text = "-"
        '
        'MenuItem87
        '
        Me.MenuItem87.Enabled = False
        Me.MenuItem87.Index = 9
        Me.MenuItem87.Text = "[ TEA 929100, SPT38 ]"
        '
        'MenuItem56
        '
        Me.MenuItem56.Index = 10
        Me.MenuItem56.Text = "Redovne tarife"
        '
        'MenuItem85
        '
        Me.MenuItem85.Index = 11
        Me.MenuItem85.Text = "-"
        '
        'MenuItem88
        '
        Me.MenuItem88.Enabled = False
        Me.MenuItem88.Index = 12
        Me.MenuItem88.Text = "[ OSTALI UGOVORI ]"
        '
        'MenuItem46
        '
        Me.MenuItem46.Index = 13
        Me.MenuItem46.Text = "Izbor pojedinacnog ugovora"
        '
        'MenuItem68
        '
        Me.MenuItem68.Index = 14
        Me.MenuItem68.Text = "Svi ugovori"
        '
        'MenuItem79
        '
        Me.MenuItem79.Index = 15
        Me.MenuItem79.Text = "-"
        '
        'MenuItem65
        '
        Me.MenuItem65.Index = 16
        Me.MenuItem65.Text = "Lista B"
        '
        'MenuItem67
        '
        Me.MenuItem67.Index = 17
        Me.MenuItem67.Text = "Kontrolna lista"
        '
        'MenuItem57
        '
        Me.MenuItem57.Index = 18
        Me.MenuItem57.Text = "-"
        '
        'MenuItem48
        '
        Me.MenuItem48.Index = 19
        Me.MenuItem48.Text = "Spedicije za mesec"
        '
        'MenuItem44
        '
        Me.MenuItem44.Index = 20
        Me.MenuItem44.Text = "-"
        '
        'MenuItem49
        '
        Me.MenuItem49.Index = 21
        Me.MenuItem49.Text = "Pregled ispravnosti podataka"
        '
        'MenuItem66
        '
        Me.MenuItem66.Index = 22
        Me.MenuItem66.Text = "-"
        '
        'MenuItem43
        '
        Me.MenuItem43.Enabled = False
        Me.MenuItem43.Index = 23
        Me.MenuItem43.Text = "[ PREGLED RADA GRANICNIH PRELAZA ]"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 24
        Me.MenuItem15.Text = "K140trz"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 25
        Me.MenuItem16.Text = "K165trz"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 3
        Me.MenuItem18.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem29, Me.MenuItem45, Me.MenuItem6, Me.MenuItem19, Me.MenuItem52, Me.MenuItem53, Me.MenuItem20, Me.MenuItem42, Me.MenuItem54, Me.MenuItem69, Me.MenuItem70})
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
        'MenuItem53
        '
        Me.MenuItem53.Index = 5
        Me.MenuItem53.Text = "-"
        '
        'MenuItem20
        '
        Me.MenuItem20.Enabled = False
        Me.MenuItem20.Index = 6
        Me.MenuItem20.Text = "[ Tranzit ]"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 7
        Me.MenuItem42.Text = "Najave do Beograd Ranzirne "
        '
        'MenuItem54
        '
        Me.MenuItem54.Index = 8
        Me.MenuItem54.Text = "Najave od Beograd Ranzirne "
        '
        'MenuItem69
        '
        Me.MenuItem69.Index = 9
        Me.MenuItem69.Text = "-"
        '
        'MenuItem70
        '
        Me.MenuItem70.Index = 10
        Me.MenuItem70.Text = "Trazenje kola u najavama"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 4
        Me.MenuItem12.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem40, Me.MenuItem39, Me.MenuItem37, Me.MenuItem10, Me.MenuItem11})
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
        'MenuItem10
        '
        Me.MenuItem10.Index = 3
        Me.MenuItem10.Text = "-"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 4
        Me.MenuItem11.Text = "Server"
        '
        'ToolBar1
        '
        Me.ToolBar1.AutoSize = False
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(912, 82)
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
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 623)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(912, 22)
        Me.StatusBar1.TabIndex = 4
        Me.StatusBar1.Text = "Tovarni list"
        '
        'ToolBar2
        '
        Me.ToolBar2.DropDownArrows = True
        Me.ToolBar2.Location = New System.Drawing.Point(0, 82)
        Me.ToolBar2.Name = "ToolBar2"
        Me.ToolBar2.ShowToolTips = True
        Me.ToolBar2.Size = New System.Drawing.Size(912, 42)
        Me.ToolBar2.TabIndex = 9
        '
        'Button3
        '
        Me.Button3.Enabled = False
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
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 85)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1200, 736)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
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
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.Location = New System.Drawing.Point(631, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(89, 76)
        Me.Button6.TabIndex = 7
        Me.Button6.Text = "Kraj"
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
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(912, 645)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ToolBar2)
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
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
            ZaostalaKola = "Ne"
            AkcijaZaPreuzimanje = "Ne"
            Dim form2a As New TrzStart
            IzborSaobracaja = "2"

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
            AkcijaZaPreuzimanje = "Ne"
            Dim form2a As New TrzStart
            IzborSaobracaja = "3"
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
        AkcijaZaPreuzimanje = "Ne"
        RecordAction = "N"
        Dim FormUpd As New UpdateForm

        FormUpd.Text = ":: Izmena u bazi podataka ::"
        FormUpd.ShowDialog()


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim form2 As New TrzStart 'unutrasnji!
        IzborSaobracaja = "1"
        bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
        form2.Text = ":: Unutrasnji saobracaj ::"
        form2.ShowDialog()
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


        'Dim FIzv As New CRForm
        'Dim CRIzv As New CrystalReport1
        'FIzv.CrystalReportViewer1.ReportSource = CRIzv

        '' KOD ZA PRIJAVLJIVANJE NA BAZU 
        'Dim CRConec As New ConnectionInfo
        'CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        'CRConec.ServerName = "10.0.4.31"
        'CRConec.DatabaseName = "WinRoba"
        'CRConec.UserID = "Radnik"
        'CRConec.Password = "roba2006"

        'FIzv.Show()

        'Dim FIzv As New FormK140
        'Dim CRIzv As New K140trzPrispece
        'FIzv.CrystalReportViewer1.ReportSource = CRIzv

        ''Dim CRConec As New ConnectionInfo
        ''CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        ''CRConec.ServerName = "10.0.4.31"
        ''CRConec.DatabaseName = "WinRoba"
        ''CRConec.UserID = "Radnik"
        ''CRConec.Password = "roba2006"


        'Dim param1 As String 'parametar koji se odnosi na vrstu saobracaja
        'Dim param2 As String 'parametar koji se odnosi na ulaznu stanicu
        'Dim param3 As Date   'parametar koji se odnosi na datum prispeca


        'param1 = IzborSaobracaja
        'param2 = StanicaUnosa
        'param3 = txtPrDatum.Text

        'FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Left(txtUlStanica.Text, 5) & "') and {SlogKalk.Saobracaj}=('" & txtSaobracaj.Text & "') and {SlogKalk.PrDatum}= date('" & txtPrDatum.Text & "')"

        'CRIzv.SetParameterValue(0, param1)
        'CRIzv.SetParameterValue(1, param2)
        'CRIzv.SetParameterValue(2, param3)

        'FIzv.Show()

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
        Me.MenuItem11.Text = Microsoft.VisualBasic.Mid(SQL_CONNECTION_STRING, 1, 20) & " ..."

        '-------------------- postavljanje racunskog meseca za tranzit - opsti slucaj ---------------------
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If


        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
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
        AkcijaZaPreuzimanje = "Da"
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

    Private Sub MenuItem46_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem46.Click
        ' co4_parametar.rpt  +

        Dim FIzv As New CRMultiForm
        Dim CRIzv As New CO4_parametar_p2

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        '---------------

        Dim param1 As String 'parametar koji se odnosi na racunski mesec
        Dim param2 As String 'parametar koji se odnosi na racunski mesec

        param1 = "16"
        param2 = CrRacunskiMesec

        'FIzv.CrystalReportViewer1.SelectionFormula = "Left({SlogKalk.Ugovor},2)= '" & param1 & "' and {SlogKalk.ObrMesec} = '" & param2 & "'"
        FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ObrMesec} = '" & param2 & "' and Left({SlogKalk.Ugovor},2)= '" & param1 & "'"


        CRIzv.SetParameterValue(0, param2)
        CRIzv.SetParameterValue(1, param1)
        '---------------

        FIzv.Show()

    End Sub

    Private Sub MenuItem47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem47.Click

    End Sub

    Private Sub MenuItem50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem50.Click
        ' ic.rpt +
    End Sub

    Private Sub MenuItem51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem51.Click
        'ic_adriacombi_8.rpt +
    End Sub

    Private Sub MenuItem48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem48.Click
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
        ZaostalaKola = "Ne"
        'Korekcija vozova iz Makisa

        VozoviMakis = "Izmena"
        Dim FormMakisIzmena As New Makis
        FormMakisIzmena.Text = "Korekcija unetih podataka o vozu na relaciji Beograd Ranzirna - Granica"
        FormMakisIzmena.ShowDialog()

    End Sub

    Private Sub MenuItem81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem81.Click
        VozoviMakis = "Novi"
        Dim FormMakis As New Makis
        FormMakis.Text = "Kalkulacija za vozove na relaciji Beograd Ranzirna - Granica"
        FormMakis.ShowDialog()
    End Sub

    Private Sub MenuItem78_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem78.Click
        Dim FormKorekcija As New KorekcijaPoNajavi
        FormKorekcija.Text = "Korekcija unetih podataka o vozu na relaciji Granica - Beograd Ranzirna"
        FormKorekcija.ShowDialog()
    End Sub

    Private Sub MenuItem56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem56.Click
        ' TranzitPoTarifi.rpt +
    End Sub

    Private Sub MenuItem61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem61.Click
        ' prodos_n1       pn1okpco4 +

        Dim FIzv As New CRMultiForm
        Dim CRIzv As New prodos_n1_par2  'oliver

        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        '---------------

        Dim param1 As String 'parametar koji se odnosi na racunski mesec
        Dim param2 As String 'parametar koji se odnosi na racunski mesec

        param1 = "10"
        param2 = CrRacunskiMesec

        FIzv.CrystalReportViewer1.SelectionFormula = "Left({SlogKalk.Ugovor},2)= '" & param1 & "' and {SlogKalk.ObrMesec} = '" & param2 & "'"

        CRIzv.SetParameterValue(0, param1)
        CRIzv.SetParameterValue(1, param2)
        '---------------

        FIzv.Show()
    End Sub

    Private Sub MenuItem62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem62.Click
        ' prodos_n2       pn2okpco4 +

        Dim FIzv As New CRMultiForm
        Dim CRIzv As New prodos_n2
        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        FIzv.Refresh()
        FIzv.Show()
    End Sub

    Private Sub MenuItem73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem73.Click
        ' prodos_100722 +
    End Sub

    Private Sub MenuItem82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem82.Click
        ' voz_prodos_1          okpcovoz +
    End Sub

    Private Sub MenuItem83_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem83.Click
        ' voz_prodos_2          okpcovoz222 +
    End Sub

    Private Sub MenuItem84_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem84.Click
        ' voz_prodos_100722 +/-
    End Sub

    Private Sub MenuItem58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem58.Click
        ' ic_eurolog_9.rpt 
    End Sub

    Private Sub MenuItem65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem65.Click
        ' ListaB.rpt +
    End Sub

    Private Sub MenuItem67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem67.Click
        ' KontrolaTranzit.rpt
    End Sub

    Private Sub MenuItem49_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem49.Click
        ' TranzitProvera.rpt +
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

    Private Sub MenuItem68_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem68.Click

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

    
End Class
