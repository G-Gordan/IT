imports System.Data.SqlClient
Imports System.Data
Public Class KorekcijaPoNajavi
    Inherits System.Windows.Forms.Form
    Public suma_tara As Int32 = 0
    Public suma_neto As Int32 = 0
    Public suma_bruto As Int32 = 0
    Public suma_prevoznina As Decimal = 0
    Public nmDatum96 As Date
    Public _Prelaz1 As String = ""
    Public _Prelaz2 As String = ""
    Public _PrimeniUgovor96 As Boolean = False

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbNajava As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnFormirajVoz As System.Windows.Forms.Button
    Friend WithEvents btnUpisUBazu As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents dgKorekcija As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbCeoVoz As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KorekcijaPoNajavi))
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbNajava = New System.Windows.Forms.TextBox
        Me.dgKorekcija = New System.Windows.Forms.DataGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnFormirajVoz = New System.Windows.Forms.Button
        Me.btnUpisUBazu = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.tbCeoVoz = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        CType(Me.dgKorekcija, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(168, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Broj ugovora"
        '
        'tbUgovor
        '
        Me.tbUgovor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(168, 24)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(136, 23)
        Me.tbUgovor.TabIndex = 1
        Me.tbUgovor.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Broj najave"
        '
        'tbNajava
        '
        Me.tbNajava.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNajava.Location = New System.Drawing.Point(8, 24)
        Me.tbNajava.MaxLength = 10
        Me.tbNajava.Name = "tbNajava"
        Me.tbNajava.Size = New System.Drawing.Size(136, 23)
        Me.tbNajava.TabIndex = 0
        Me.tbNajava.Text = ""
        '
        'dgKorekcija
        '
        Me.dgKorekcija.AlternatingBackColor = System.Drawing.Color.GhostWhite
        Me.dgKorekcija.BackColor = System.Drawing.Color.Ivory
        Me.dgKorekcija.BackgroundColor = System.Drawing.Color.Ivory
        Me.dgKorekcija.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgKorekcija.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.dgKorekcija.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgKorekcija.CaptionForeColor = System.Drawing.Color.White
        Me.dgKorekcija.CaptionVisible = False
        Me.dgKorekcija.DataMember = ""
        Me.dgKorekcija.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgKorekcija.FlatMode = True
        Me.dgKorekcija.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgKorekcija.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgKorekcija.GridLineColor = System.Drawing.Color.RoyalBlue
        Me.dgKorekcija.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.dgKorekcija.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgKorekcija.HeaderForeColor = System.Drawing.Color.Lavender
        Me.dgKorekcija.LinkColor = System.Drawing.Color.Teal
        Me.dgKorekcija.Location = New System.Drawing.Point(0, 0)
        Me.dgKorekcija.Name = "dgKorekcija"
        Me.dgKorekcija.ParentRowsBackColor = System.Drawing.Color.Lavender
        Me.dgKorekcija.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.dgKorekcija.PreferredColumnWidth = 90
        Me.dgKorekcija.SelectionBackColor = System.Drawing.Color.Teal
        Me.dgKorekcija.SelectionForeColor = System.Drawing.Color.PaleGreen
        Me.dgKorekcija.Size = New System.Drawing.Size(1248, 546)
        Me.dgKorekcija.TabIndex = 39
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 56)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.White
        Me.TextBox4.Location = New System.Drawing.Point(392, 24)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.TabIndex = 34
        Me.TextBox4.Text = "5478"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(272, 24)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.TabIndex = 33
        Me.TextBox3.Text = ""
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(144, 24)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.TabIndex = 32
        Me.TextBox2.Text = ""
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(8, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.TabIndex = 31
        Me.TextBox1.Text = ""
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Bruto masa voza "
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label4.Location = New System.Drawing.Point(184, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Suma tara "
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label5.Location = New System.Drawing.Point(304, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Suma neto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label6.Location = New System.Drawing.Point(424, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Prevoznina"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(496, 24)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(24, 22)
        Me.TextBox6.TabIndex = 42
        Me.TextBox6.Text = ""
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox6.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(536, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 33)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "Refresh"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnFormirajVoz
        '
        Me.btnFormirajVoz.BackColor = System.Drawing.Color.Ivory
        Me.btnFormirajVoz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnFormirajVoz.Image = CType(resources.GetObject("btnFormirajVoz.Image"), System.Drawing.Image)
        Me.btnFormirajVoz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFormirajVoz.Location = New System.Drawing.Point(448, 8)
        Me.btnFormirajVoz.Name = "btnFormirajVoz"
        Me.btnFormirajVoz.Size = New System.Drawing.Size(120, 40)
        Me.btnFormirajVoz.TabIndex = 2
        Me.btnFormirajVoz.Text = "Prikazi najavu"
        Me.btnFormirajVoz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnUpisUBazu
        '
        Me.btnUpisUBazu.BackColor = System.Drawing.Color.Bisque
        Me.btnUpisUBazu.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnUpisUBazu.Image = CType(resources.GetObject("btnUpisUBazu.Image"), System.Drawing.Image)
        Me.btnUpisUBazu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpisUBazu.Location = New System.Drawing.Point(1020, 0)
        Me.btnUpisUBazu.Name = "btnUpisUBazu"
        Me.btnUpisUBazu.Size = New System.Drawing.Size(112, 96)
        Me.btnUpisUBazu.TabIndex = 4
        Me.btnUpisUBazu.Text = "Upis u bazu"
        Me.btnUpisUBazu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpisUBazu.Visible = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Ivory
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(1132, 0)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(112, 96)
        Me.Button9.TabIndex = 3
        Me.Button9.Text = "Otkaži"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button9.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(336, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Godina"
        '
        'TextBox5
        '
        Me.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(336, 24)
        Me.TextBox5.MaxLength = 4
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(69, 23)
        Me.TextBox5.TabIndex = 43
        Me.TextBox5.Text = "2008"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(528, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 24)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Cena za ceo voz"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCeoVoz
        '
        Me.tbCeoVoz.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.tbCeoVoz.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCeoVoz.ForeColor = System.Drawing.Color.White
        Me.tbCeoVoz.Location = New System.Drawing.Point(392, 11)
        Me.tbCeoVoz.Name = "tbCeoVoz"
        Me.tbCeoVoz.TabIndex = 5
        Me.tbCeoVoz.Text = ""
        Me.tbCeoVoz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(504, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 23)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "€"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(1200, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 32)
        Me.Button3.TabIndex = 47
        Me.Button3.Text = "Ucitaj najavu DS"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(1152, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(40, 32)
        Me.Button4.TabIndex = 48
        Me.Button4.Text = "Proveri smer Sever-Jug"
        Me.Button4.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Azure
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TextBox5)
        Me.Panel1.Controls.Add(Me.tbUgovor)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.tbNajava)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.btnFormirajVoz)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1248, 56)
        Me.Panel1.TabIndex = 50
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RadioButton3)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Location = New System.Drawing.Point(616, 1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(368, 47)
        Me.GroupBox3.TabIndex = 50
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Vrsta saobracaja"
        '
        'RadioButton3
        '
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(288, 13)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(64, 24)
        Me.RadioButton3.TabIndex = 51
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Tranzit"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(208, 13)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(64, 24)
        Me.RadioButton2.TabIndex = 50
        Me.RadioButton2.Text = "Izvoz"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(128, 13)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(64, 24)
        Me.RadioButton1.TabIndex = 49
        Me.RadioButton1.Text = "Uvoz"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Azure
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.btnUpisUBazu)
        Me.Panel2.Controls.Add(Me.Button9)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 602)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1248, 100)
        Me.Panel2.TabIndex = 51
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(688, 96)
        Me.Panel4.TabIndex = 41
        Me.Panel4.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.tbCeoVoz)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(664, 40)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label9.Location = New System.Drawing.Point(255, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 16)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Cena za ceo voz:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Azure
        Me.Panel3.Controls.Add(Me.dgKorekcija)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1248, 546)
        Me.Panel3.TabIndex = 52
        '
        'KorekcijaPoNajavi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1248, 702)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "KorekcijaPoNajavi"
        Me.Text = "KorekcijaPoNajavi"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgKorekcija, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim dsKorekcija As DataSet
    Private Sub tbNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub tbNajava_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNajava.Validated
        'mDatumKalk = dtDatum.Value
        If tbNajava.Text = "" Then
            MessageBox.Show("Neispravan broj najave!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tbNajava.Focus()
        End If
    End Sub
    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub btnFormirajVoz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormirajVoz.Click

        Dim _nRbr As Int32 = 1
        Dim _nIBK As String
        Dim _nIzlaz As Int32
        suma_tara = 0
        suma_neto = 0
        suma_bruto = 0
        suma_prevoznina = 0 ' Int32 = 0

        'mNajava = tbNajava.Text
        'mBrojUg = tbUgovor.Text

        If IzborSaobracaja = "1" Then
            If Me.RadioButton1.Checked = True Then
                IzborSaobracaja = "2"
            ElseIf Me.RadioButton2.Checked = True Then
                IzborSaobracaja = "3"
            ElseIf Me.RadioButton3.Checked = True Then
                IzborSaobracaja = "4"
            End If
        End If

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        mBrojUg = Me.tbUgovor.Text

        'izmenjeno 9.3.2009.
        'umesto Nakco82 - slogroba.nhm

        Dim sql_text1 As String
        Dim sql_text1_order As String
        If IzborSaobracaja = "4" Then

            If mBrojUg = "981444" Or mBrojUg = "101344" Or mBrojUg = "101345" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "33" Or mBrojUg = "981544" Then
                sql_text1_order = "ORDER BY dbo.SlogKola.IBK "
            Else
                sql_text1_order = "ORDER BY dbo.SlogKalk.OtpBroj "
            End If

            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "96" Then
                sql_text1 = "SELECT TOP 100 PERCENT dbo.SlogKalk.NajavaKola AS Najavljeno, dbo.SlogKalk.ObrMesec AS Mesec, dbo.SlogKalk.OtpBroj AS BrojOtp,  " & _
                            "' ', dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlPrevFr AS Prevoznina,  " & _
                            "dbo.SlogNaknada.Iznos AS Naknade, dbo.SlogRoba.NHM , dbo.SlogRoba.UtiNHM, dbo.SlogKola.Naknada AS [Nak. po kolima],  " & _
                            "dbo.SlogKalk.RecID AS RecID, dbo.SlogNaknada.NaknadeStavka as [Rbr. Naknade], dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, " & _
                            "dbo.SlogRoba.KolaStavka, dbo.SlogRoba.RobaStavka, dbo.SlogKalk.DatumUlaza, dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.ZsIzPrelaz " & _
                            "FROM dbo.SlogKalk INNER JOIN  " & _
                            "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN  " & _
                            "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND  " & _
                            "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka FULL OUTER JOIN  " & _
                            "dbo.SlogNaknada ON dbo.SlogKalk.RecID = dbo.SlogNaknada.RecID AND dbo.SlogKalk.Stanica = dbo.SlogNaknada.Stanica  " & _
                            "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
                            sql_text1_order & " , mesec"

                '                            "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
            Else
                sql_text1 = "SELECT TOP 100 PERCENT dbo.SlogKalk.NajavaKola AS Najavljeno, dbo.SlogKalk.ObrMesec AS Mesec, dbo.SlogKalk.OtpBroj AS BrojOtp,  " & _
                            "dbo.SlogKalk.Najava2 AS [Iz Makisa], dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlPrevFr AS Prevoznina,  " & _
                            "dbo.SlogNaknada.Iznos AS Naknade, dbo.SlogRoba.NHM , dbo.SlogRoba.UtiNHM, dbo.SlogKola.Naknada AS [Nak. po kolima],  " & _
                            "dbo.SlogKalk.RecID AS RecID, dbo.SlogNaknada.NaknadeStavka as [Rbr. Naknade], dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, " & _
                            "dbo.SlogRoba.KolaStavka, dbo.SlogRoba.RobaStavka " & _
                            "FROM dbo.SlogKalk INNER JOIN  " & _
                            "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN  " & _
                            "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND  " & _
                            "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka FULL OUTER JOIN  " & _
                            "dbo.SlogNaknada ON dbo.SlogKalk.RecID = dbo.SlogNaknada.RecID AND dbo.SlogKalk.Stanica = dbo.SlogNaknada.Stanica  " & _
                            "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
                            sql_text1_order

                '"WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _

            End If

        ElseIf IzborSaobracaja = "3" Then
            sql_text1 = "SELECT TOP 100 PERCENT dbo.SlogKalk.NajavaKola AS Najavljeno, dbo.SlogKalk.ObrMesec AS Mesec, dbo.SlogKalk.OtpBroj AS BrojOtp,  " & _
                        "dbo.SlogKalk.Najava2 AS [Iz Makisa], dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlPrevUp AS Prevoznina,  " & _
                        "dbo.SlogNaknada.Iznos AS Naknade, dbo.SlogRoba.NHM , dbo.SlogRoba.UtiNHM, dbo.SlogKola.Naknada AS [Nak. po kolima],  " & _
                        "dbo.SlogKalk.RecID AS RecID, dbo.SlogNaknada.NaknadeStavka as [Rbr. Naknade], dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, " & _
                        "dbo.SlogRoba.KolaStavka, dbo.SlogRoba.RobaStavka " & _
                        "FROM dbo.SlogKalk INNER JOIN  " & _
                        "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN  " & _
                        "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND  " & _
                        "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka FULL OUTER JOIN  " & _
                        "dbo.SlogNaknada ON dbo.SlogKalk.RecID = dbo.SlogNaknada.RecID AND dbo.SlogKalk.Stanica = dbo.SlogNaknada.Stanica  " & _
                        "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
                        "ORDER BY dbo.SlogKalk.OtpBroj "

            '"WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
        End If

        Dim myDecimal As Decimal = 0
        Dim nm_Nak As Decimal = 0
        Dim nm_UtiNHM As String = ""
        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)

        'Dim adSlogKola As New SqlDataAdapter(sql_text1, OkpDbVeza)
        'Dim ii1 As Int32 = adSlogKola.Fill(dsDSKorekcija)

        Do While rdrRm.Read()
            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "96" Then
                _Prelaz1 = rdrRm.Item(19)
                _Prelaz2 = rdrRm.Item(20)
            End If

            '''suma_tara = suma_tara + rdrRm.GetInt32(5)
            '''suma_neto = suma_neto + rdrRm.GetInt32(6)
            If IsDBNull(rdrRm.Item(8)) Then
                suma_prevoznina = suma_prevoznina
            Else
                suma_prevoznina = suma_prevoznina + rdrRm.GetDecimal(7) 'rdrRm.GetDecimal(7)
            End If

            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "96" Then
                nmDatum96 = rdrRm.Item(18) 'datum ulaza
            End If

            If IsDBNull(rdrRm.Item(8)) Then
                nm_Nak = 0
            Else
                nm_Nak = rdrRm.Item(8)
            End If

            If IsDBNull(rdrRm.Item(10)) Then
                nm_UtiNHM = ""
            Else
                nm_UtiNHM = rdrRm.Item(10)
            End If


            dtKorekcija.NewRow()
            dtKorekcija.Rows.Add(New Object() {_nRbr, rdrRm.GetInt32(0), rdrRm.GetString(1), rdrRm.GetInt32(2), rdrRm.GetString(3), _
                                               rdrRm.GetString(4), rdrRm.GetInt32(5), rdrRm.GetInt32(6), rdrRm.GetDecimal(7), nm_Nak, _
                                               rdrRm.GetString(9), nm_UtiNHM, rdrRm.GetDecimal(11), rdrRm.GetInt32(12), rdrRm.GetInt32(16), rdrRm.GetInt32(17)})

            _nRbr = _nRbr + 1
        Loop

        'dgKorekcija.TableStyles(0).GridColumnStyles(3).HeaderText = "S-J"

        rdrRm.Close()
        OkpDbVeza.Close()

        If _nRbr = 1 Then
            MsgBox("Ne postoji takav podatak! ", MsgBoxStyle.Exclamation, "Poruka iz baze")
            tbNajava.Focus()
            Exit Sub
        End If

        ''-------------- setovanje scheme -------------------------
        'Dim tableStyle As DataGridTableStyle
        'tableStyle = New DataGridTableStyle
        'tableStyle.MappingName = "SuperGrid"

        'dgKorekcija.TableStyles.Clear()
        'dgKorekcija.TableStyles.Add(tableStyle)
        'dgKorekcija.ReadOnly = True
        ''dgKorekcija.DataSource = _dataSet.Tables("SuperGrid")

        'dgKorekcija.DataSource = dsKorekcija.Tables("SuperGrid")

        'AutoSizeTable()
        ''---------------------------------------------------------

        dgKorekcija.Refresh()

        Me.btnFormirajVoz.Visible = False
        'Me.btnUpisUBazu.Visible = True
        Me.btnUpisUBazu.Focus()


        '===================================================== sabiranje suma ==============================================================
        If Microsoft.VisualBasic.Right(mBrojUg, 2) = "33" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "44" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "45" Then 'Ako je kontejnerski voz:
            Me.Button3_Click(Me, Nothing)
        ElseIf Microsoft.VisualBasic.Right(mBrojUg, 2) = "96" Then 'Ako je voz Jug-Sever

            Me.Button4_Click(Me, Nothing)


            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            suma_tara = 0
            Dim sql_textTARA As String

            sql_textTARA = "SELECT SlogKalk.ObrGodina AS Expr1, SlogKalk.Najava AS Expr2,  MAX(DISTINCT SlogKola.Tara) AS Expr3 " & _
                           "FROM SlogKalk INNER JOIN  SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica " & _
                           "GROUP BY SlogKalk.ObrGodina, SlogKalk.Najava, SlogKalk.Ugovor, SlogKola.IBK " & _
                           "HAVING (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

            'sql_textTARA = "SELECT SlogKalk.ObrGodina AS Expr1, SlogKalk.Najava AS Expr2,  MAX(DISTINCT SlogKola.Tara) AS Expr3 " & _
            '                           "FROM SlogKalk INNER JOIN  SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica " & _
            '                           "GROUP BY SlogKalk.ObrGodina, SlogKalk.Najava, SlogKalk.Ugovor, SlogKola.IBK " & _
            '                           "HAVING (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

            Dim sql_comm1TARA As New SqlClient.SqlCommand(sql_textTARA, OkpDbVeza)
            Dim rdrRmTARA As SqlClient.SqlDataReader
            rdrRmTARA = sql_comm1TARA.ExecuteReader(CommandBehavior.CloseConnection)

            Do While rdrRmTARA.Read()
                'suma_tara = rdrRmTARA.GetInt32(0)
                suma_tara = suma_tara + rdrRmTARA.GetInt32(2)
            Loop

            rdrRmTARA.Close()
            OkpDbVeza.Close()

        Else
            'If Microsoft.VisualBasic.Right(mBrojUg, 2) = "96" Then 'Ako je voz Jug-Sever:
            '    Me.Button4_Click(Me, Nothing)
            'End If


            '--------- novo 1-------------
            'If OkpDbVeza.State = ConnectionState.Closed Then
            '    OkpDbVeza.Open()
            'End If
            'suma_neto = 0

            'Dim sql_textNETO As String

            'sql_textNETO = "SELECT SlogKalk.ObrGodina AS Expr1, SlogKalk.Najava AS Expr2, SUM(SlogRoba.SMasa) AS Expr3 " & _
            '               "FROM SlogKalk INNER JOIN SlogRoba ON SlogKalk.RecID = SlogRoba.RecID " & _
            '               "GROUP BY SlogKalk.ObrGodina, SlogKalk.Najava, SlogKalk.Ugovor " & _
            '               "HAVING (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

            ''sql_textNETO = "SELECT SUM(dbo.SlogRoba.SMasa) AS SUMA " & _
            ''               "FROM dbo.SlogKalk INNER JOIN dbo.SlogRoba ON dbo.SlogKalk.RecID = dbo.SlogRoba.RecID " & _
            ''               "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

            'Dim sql_comm1NETO As New SqlClient.SqlCommand(sql_textNETO, OkpDbVeza)
            'Dim rdrRmNETO As SqlClient.SqlDataReader
            'rdrRmNETO = sql_comm1NETO.ExecuteReader(CommandBehavior.CloseConnection)

            'Do While rdrRmNETO.Read()
            '    'suma_neto = rdrRmNETO.GetInt32(0)
            '    suma_neto = rdrRmNETO.GetInt32(2)
            'Loop

            'rdrRmNETO.Close()
            'OkpDbVeza.Close()
            '------- end novo 1 -----------

            '--------- novo 2-------------
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            suma_tara = 0
            Dim sql_textTARA As String

            sql_textTARA = "SELECT SlogKalk.ObrGodina AS Expr1, SlogKalk.Najava AS Expr2,  MAX(DISTINCT SlogKola.Tara) AS Expr3 " & _
                           "FROM SlogKalk INNER JOIN  SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica " & _
                           "GROUP BY SlogKalk.ObrGodina, SlogKalk.Najava, SlogKalk.Ugovor, SlogKola.IBK " & _
                           "HAVING (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

            'sql_textTARA = "SELECT SlogKalk.ObrGodina AS Expr1, SlogKalk.Najava AS Expr2,  MAX(DISTINCT SlogKola.Tara) AS Expr3 " & _
            '               "FROM SlogKalk INNER JOIN  SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica " & _
            '               "GROUP BY SlogKalk.ObrGodina, SlogKalk.Najava, SlogKalk.Ugovor, SlogKola.IBK " & _
            '               "HAVING (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "


            Dim sql_comm1TARA As New SqlClient.SqlCommand(sql_textTARA, OkpDbVeza)
            Dim rdrRmTARA As SqlClient.SqlDataReader
            rdrRmTARA = sql_comm1TARA.ExecuteReader(CommandBehavior.CloseConnection)

            Do While rdrRmTARA.Read()
                'suma_tara = rdrRmTARA.GetInt32(0)
                suma_tara = suma_tara + rdrRmTARA.GetInt32(2)
            Loop

            rdrRmTARA.Close()
            OkpDbVeza.Close()
            '------- end novo 2 -----------
            '--------- novo 3-------------
            'If OkpDbVeza.State = ConnectionState.Closed Then
            '    OkpDbVeza.Open()
            'End If

            'suma_prevoznina = 0
            'Dim sql_textPREV As String

            'sql_textPREV = "SELECT  SUM(dbo.SlogKalk.tlPrevFr) AS SUMA " & _
            '               "FROM dbo.SlogKalk " & _
            '               "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

            'Dim sql_comm1PREV As New SqlClient.SqlCommand(sql_textPREV, OkpDbVeza)
            'Dim rdrRmPREV As SqlClient.SqlDataReader
            'rdrRmPREV = sql_comm1PREV.ExecuteReader(CommandBehavior.CloseConnection)

            'Do While rdrRmPREV.Read()
            '    suma_prevoznina = rdrRmPREV.GetDecimal(0)
            'Loop

            'rdrRmPREV.Close()
            'OkpDbVeza.Close()
            ''------- end novo 3 -----------

            'suma_bruto = suma_tara + suma_neto


        End If


        'NETO
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        suma_neto = 0

        Dim sql_textNETO As String

        sql_textNETO = "SELECT SlogKalk.ObrGodina AS Expr1, SlogKalk.Najava AS Expr2, SUM(SlogRoba.SMasa) AS Expr3 " & _
                       "FROM SlogKalk INNER JOIN SlogRoba ON SlogKalk.RecID = SlogRoba.RecID " & _
                       "GROUP BY SlogKalk.ObrGodina, SlogKalk.Najava, SlogKalk.Ugovor " & _
                       "HAVING (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

        'sql_textNETO = "SELECT SlogKalk.ObrGodina AS Expr1, SlogKalk.Najava AS Expr2, SUM(SlogRoba.SMasa) AS Expr3 " & _
        '               "FROM SlogKalk INNER JOIN SlogRoba ON SlogKalk.RecID = SlogRoba.RecID " & _
        '               "GROUP BY SlogKalk.ObrGodina, SlogKalk.Najava, SlogKalk.Ugovor " & _
        '               "HAVING (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

        Dim sql_comm1NETO As New SqlClient.SqlCommand(sql_textNETO, OkpDbVeza)
        Dim rdrRmNETO As SqlClient.SqlDataReader
        rdrRmNETO = sql_comm1NETO.ExecuteReader(CommandBehavior.CloseConnection)

        Do While rdrRmNETO.Read()
            suma_neto = suma_neto + rdrRmNETO.GetInt32(2)
        Loop

        rdrRmNETO.Close()
        OkpDbVeza.Close()

        'PREVOZNINA
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        suma_prevoznina = 0
        Dim sql_textPREV As String

        sql_textPREV = "SELECT  SUM(dbo.SlogKalk.tlPrevFr) AS SUMA " & _
                               "FROM dbo.SlogKalk " & _
                               "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

        'sql_textPREV = "SELECT  SUM(dbo.SlogKalk.tlPrevFr) AS SUMA " & _
        '               "FROM dbo.SlogKalk " & _
        '               "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

        Dim sql_comm1PREV As New SqlClient.SqlCommand(sql_textPREV, OkpDbVeza)
        Dim rdrRmPREV As SqlClient.SqlDataReader
        rdrRmPREV = sql_comm1PREV.ExecuteReader(CommandBehavior.CloseConnection)

        Do While rdrRmPREV.Read()
            suma_prevoznina = rdrRmPREV.GetDecimal(0)
        Loop

        rdrRmPREV.Close()
        OkpDbVeza.Close()
        '------- end novo 3 -----------



        ''If Microsoft.VisualBasic.Right(mBrojUg, 2) = "96" Then 'Ako je voz Jug-Sever:
        ''    Me.Button4_Click(Me, Nothing)
        ''End If


        ''--------- novo 1-------------
        'If OkpDbVeza.State = ConnectionState.Closed Then
        '    OkpDbVeza.Open()
        'End If
        'suma_neto = 0

        'Dim sql_textNETO As String

        'sql_textNETO = "SELECT SlogKalk.ObrGodina AS Expr1, SlogKalk.Najava AS Expr2, SUM(SlogRoba.SMasa) AS Expr3 " & _
        '               "FROM SlogKalk INNER JOIN SlogRoba ON SlogKalk.RecID = SlogRoba.RecID " & _
        '               "GROUP BY SlogKalk.ObrGodina, SlogKalk.Najava, SlogKalk.Ugovor " & _
        '               "HAVING (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

        ''sql_textNETO = "SELECT SUM(dbo.SlogRoba.SMasa) AS SUMA " & _
        ''               "FROM dbo.SlogKalk INNER JOIN dbo.SlogRoba ON dbo.SlogKalk.RecID = dbo.SlogRoba.RecID " & _
        ''               "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

        'Dim sql_comm1NETO As New SqlClient.SqlCommand(sql_textNETO, OkpDbVeza)
        'Dim rdrRmNETO As SqlClient.SqlDataReader
        'rdrRmNETO = sql_comm1NETO.ExecuteReader(CommandBehavior.CloseConnection)

        'Do While rdrRmNETO.Read()
        '    'suma_neto = rdrRmNETO.GetInt32(0)
        '    suma_neto = rdrRmNETO.GetInt32(2)
        'Loop

        'rdrRmNETO.Close()
        'OkpDbVeza.Close()
        ''------- end novo 1 -----------

        ''--------- novo 2-------------
        'If OkpDbVeza.State = ConnectionState.Closed Then
        '    OkpDbVeza.Open()
        'End If

        'suma_tara = 0
        'Dim sql_textTARA As String

        'sql_textTARA = "SELECT SlogKalk.ObrGodina AS Expr1, SlogKalk.Najava AS Expr2,  MAX(DISTINCT SlogKola.Tara) AS Expr3 " & _
        '               "FROM SlogKalk INNER JOIN  SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica " & _
        '               "GROUP BY SlogKalk.ObrGodina, SlogKalk.Najava, SlogKalk.Ugovor, SlogKola.IBK " & _
        '               "HAVING (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

        ''sql_textTARA = "SELECT SUM(dbo.SlogKola.Tara) AS SUMA " & _
        ''               "FROM dbo.SlogKalk INNER JOIN dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica " & _
        ''               "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

        'Dim sql_comm1TARA As New SqlClient.SqlCommand(sql_textTARA, OkpDbVeza)
        'Dim rdrRmTARA As SqlClient.SqlDataReader
        'rdrRmTARA = sql_comm1TARA.ExecuteReader(CommandBehavior.CloseConnection)

        'Do While rdrRmTARA.Read()
        '    'suma_tara = rdrRmTARA.GetInt32(0)
        '    suma_tara = suma_tara + rdrRmTARA.GetInt32(2)
        'Loop

        'rdrRmTARA.Close()
        'OkpDbVeza.Close()
        ''------- end novo 2 -----------
        ''--------- novo 3-------------
        'If OkpDbVeza.State = ConnectionState.Closed Then
        '    OkpDbVeza.Open()
        'End If

        'suma_prevoznina = 0
        'Dim sql_textPREV As String

        'sql_textPREV = "SELECT  SUM(dbo.SlogKalk.tlPrevFr) AS SUMA " & _
        '               "FROM dbo.SlogKalk " & _
        '               "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "

        'Dim sql_comm1PREV As New SqlClient.SqlCommand(sql_textPREV, OkpDbVeza)
        'Dim rdrRmPREV As SqlClient.SqlDataReader
        'rdrRmPREV = sql_comm1PREV.ExecuteReader(CommandBehavior.CloseConnection)

        'Do While rdrRmPREV.Read()
        '    suma_prevoznina = rdrRmPREV.GetDecimal(0)
        'Loop

        'rdrRmPREV.Close()
        'OkpDbVeza.Close()
        ''------- end novo 3 -----------

        suma_bruto = suma_tara + suma_neto

        GroupBox1.Visible = True
        TextBox4.Visible = True

        TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        TextBox2.Text = Math.Round(suma_tara / 1000, 1).ToString
        TextBox3.Text = Math.Round(suma_neto / 1000, 1).ToString

        TextBox4.Text = Math.Round(suma_prevoznina, 2).ToString()

        If Microsoft.VisualBasic.Right(Me.tbUgovor.Text, 2) = "96" Then
            If _PrimeniUgovor96 = True Then
                PrimeniUgovor96()
            Else
                PrimeniPovlasticu96()
            End If
        End If

        TextBox4.Text = Math.Round(suma_prevoznina, 2).ToString()
        '=================================================== end sabiranje suma ==============================================================

        Panel4.Visible = True
        Me.btnUpisUBazu.Visible = True
        Me.btnUpisUBazu.Visible = True
        Me.Button9.Visible = True
        btnUpisUBazu.Focus()

    End Sub
    Private Sub KorekcijaPoNajavi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatGrid()

        If IzborSaobracaja = "1" Then
            Me.GroupBox3.Visible = True
        Else
            Me.GroupBox3.Visible = False
        End If

        dtKorekcija.Clear()
        TextBox5.Text = Today.Year.ToString
        tbNajava.Focus()


    End Sub
    Private Sub FormatGrid()
        'Col1.AutoIncrement = True
        'Col1.ReadOnly = True

        If dsKorekcija Is Nothing Then
            dgKorekcija.DataSource = dtKorekcija
        Else
            If mNajava Is Nothing Then
            Else
                dgKorekcija.DataSource = dtKorekcija
            End If
            dgKorekcija.DataSource = dsKorekcija.Tables(0)
        End If

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        dtKorekcija.Clear()
        Me.btnFormirajVoz.Visible = True
        Me.btnUpisUBazu.Visible = False

        Close()

    End Sub

    Private Sub btnUpisUBazu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpisUBazu.Click

        Dim _UKK As Int32
        Dim _recID As Int32
        Dim _recRBR As Int32
        Dim KorekcijaRed As DataRow
        Dim sql_Kalk As String
        Dim sql_Kola As String
        Dim sql_Roba As String
        Dim sql_Naknada As String
        Dim m_Naknade As Decimal ' = 12
        Dim m_Prevoznina As Decimal

        m_Prevoznina = mPrevoznina
        'Dim m_Prevoznina As Decimal = Int(mPrevoznina)

        Dim slogTrans As SqlTransaction

        _UKK = dtKorekcija.Rows.Count

        If _UKK > 0 Then

            Dim myCommandKalk As SqlCommand
            Dim myCommandKola As SqlCommand
            Dim myCommandRoba As SqlCommand
            Dim myCommandNakn As SqlCommand

            Dim ra As Int32
            Dim rv As String
            Dim _UpisiTL As Int16 = 0

            Dim _Prev As Decimal = 0
            Dim _Nak As Decimal = 0
            Dim _NakZaCo As Decimal = 0
            Dim _IzMakisa As String = "0"
            Dim _IBK As String
            Dim _Tara As Int32 = 0
            Dim _NakZaZKola As Decimal = 0
            Dim _Neto As Int32 = 0
            Dim _NajavljenoKola As Int32 = 0
            Dim _KolaRb As Int32 = 0
            Dim _RobaRb As Int32 = 0



            'Update SlogKalk
            For Each KorekcijaRed In dtKorekcija.Rows
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                End If

                _recID = KorekcijaRed.Item("RecID")
                _recRBR = KorekcijaRed.Item("RBR")
                _Prev = KorekcijaRed.Item("Prevoznina")
                _Nak = KorekcijaRed.Item("Naknada")
                '''''_NakZaCo = KorekcijaRed.Item("NakZaCO")
                ''_NakZaCo = KorekcijaRed.Item("NHM")
                _NajavljenoKola = KorekcijaRed.Item("Najavljeno") 'Novo
                '---
                _IzMakisa = KorekcijaRed.Item("Makis") 'Novo
                '---

                _IBK = Int(KorekcijaRed.Item("IBK"))
                _Tara = Int(KorekcijaRed.Item("Tara"))
                '_NakZaZKola = Int(KorekcijaRed.Item("NakPoKolima"))
                _NakZaZKola = KorekcijaRed.Item("NakPoKolima")

                _Neto = Int(KorekcijaRed.Item("Masa"))
                _KolaRb = Int(KorekcijaRed.Item("KolaRb"))
                _RobaRb = Int(KorekcijaRed.Item("RobaRb"))

                _Prev = CDec(_Prev)

                If RTrim(Microsoft.VisualBasic.Right(tbUgovor.Text, 2)) = "96" Then
                    sql_Kalk = "UPDATE SlogKalk " & _
                               "SET NajavaKola = " & _NajavljenoKola & ", Najava2 = '0', tlPrevFR = " & _Prev & ", tlNakCo = " & _Nak & ", Referent2 = '" & mUserID & "'  " & _
                               "WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"
                Else
                    sql_Kalk = "UPDATE SlogKalk " & _
                               "SET NajavaKola = " & _NajavljenoKola & ", Najava2 = '" & _IzMakisa & "', tlPrevFR = " & _Prev & ", tlNakCo = " & _Nak & ", Referent2 = '" & mUserID & "'  " & _
                               "WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"
                End If

                sql_Kola = "UPDATE SlogKola " & _
                           "SET Naknada = " & _NakZaZKola & " , Tara = " & _Tara & " " & _
                           "WHERE (dbo.SlogKola.RecID = " & _recID & ") AND (dbo.SlogKola.KolaStavka = " & _KolaRb & ")"

                sql_Roba = "UPDATE SlogRoba " & _
                           "SET SMASA = " & _Neto & " " & _
                           "WHERE (dbo.SlogRoba.RecID = " & _recID & ") AND (dbo.SlogRoba.KolaStavka = " & _KolaRb & ") AND (dbo.SlogRoba.RobaStavka = " & _RobaRb & ")"

                sql_Naknada = "UPDATE SlogNaknada " & _
                              "SET  Iznos = " & _Nak & " " & _
                              "WHERE ( dbo.SlogNaknada.RecID = " & _recID & ")"

                myCommandKalk = New SqlCommand(sql_Kalk, OkpDbVeza)
                myCommandKola = New SqlCommand(sql_Kola, OkpDbVeza)
                myCommandRoba = New SqlCommand(sql_Roba, OkpDbVeza)
                myCommandNakn = New SqlCommand(sql_Naknada, OkpDbVeza)

                Try
                    ra = myCommandKalk.ExecuteNonQuery()
                    ra = myCommandKola.ExecuteNonQuery()
                    ra = myCommandRoba.ExecuteNonQuery()
                    ra = myCommandNakn.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                OkpDbVeza.Close()
            Next

            MessageBox.Show("Podaci za najavu broj  " & tbNajava.Text & " su upisani u bazu podataka. ", "Beograd Ranzirna", MessageBoxButtons.OK, MessageBoxIcon.Information)

            dtKorekcija.Clear()
            tbNajava.Text = ""
            tbUgovor.Text = ""
            Me.btnUpisUBazu.Visible = False
            Me.btnFormirajVoz.Visible = True
            Me.GroupBox1.Visible = False
            Close()

            'tbNajava.Focus()
        Else
            MessageBox.Show("Nepostojeci podaci !", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim suma_tara As Int32 = 0
        Dim suma_neto As Int32 = 0
        Dim suma_bruto As Int32 = 0
        Dim suma_prev As Decimal = 0

        suma_tara = dtKorekcija.Compute("SUM(Tara)", String.Empty)
        suma_neto = dtKorekcija.Compute("SUM(Masa)", String.Empty)
        suma_prev = dtKorekcija.Compute("SUM(Prevoznina)", String.Empty)
        suma_bruto = suma_tara + suma_neto

        TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        TextBox2.Text = Math.Round(suma_tara / 1000, 1).ToString
        TextBox3.Text = Math.Round(suma_neto / 1000, 1).ToString
        TextBox4.Text = suma_prev.ToString

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim KorekcijaRed As DataRow
        Dim _RBR As Int32
        Dim _Prev As Decimal = 0
        Dim _BrojTL As Integer = 0

        _Prev = CDec(tbCeoVoz.Text)


        For Each KorekcijaRed In dtKorekcija.Rows
            _RBR = KorekcijaRed.Item("RBR")
            If _RBR = 1 Then
                _BrojTL = KorekcijaRed.Item("BrojOtp")
            End If
            If _BrojTL = KorekcijaRed.Item("BrojOtp") Then
                KorekcijaRed.Item("Prevoznina") = _Prev
            Else
                KorekcijaRed.Item("Prevoznina") = 0
            End If
        Next


        Me.Button1_Click(Me, Nothing)
        Me.btnUpisUBazu.Focus()

    End Sub

    Private Sub tbCeoVoz_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbCeoVoz.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'test dataseta 27,01,2012
        Dim ii1 As Int32 = 0
        Dim mBrojOtp As Int32
        Dim nmIBK As String
        Dim nmTara As Int32 = 0
        Dim nmSumaTara As Int32 = 0

        dsDSKorekcija.Clear()
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim sql_text1 As String
        Dim sql_text1_order As String
        If IzborSaobracaja = "4" Then
            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "33" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "44" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "45" Then
                'sql_text1_order = "ORDER BY dbo.SlogKalk.OtpBroj "
                sql_text1_order = "ORDER BY dbo.SlogKola.IBK "
            Else
                'sql_text1_order = "ORDER BY dbo.SlogKola.IBK "
                sql_text1_order = "ORDER BY dbo.SlogKalk.OtpBroj "
            End If

            sql_text1 = "SELECT TOP 100 PERCENT dbo.SlogKalk.NajavaKola AS Najavljeno, dbo.SlogKalk.ObrMesec AS Mesec, dbo.SlogKalk.OtpBroj AS BrojOtp,  " & _
                          "dbo.SlogKalk.Najava2 AS [Iz Makisa], dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlPrevFr AS Prevoznina,  " & _
                          "dbo.SlogNaknada.Iznos AS Naknade, dbo.SlogRoba.NHM , dbo.SlogKola.Naknada AS [Nak. po kolima],  " & _
                          "dbo.SlogKalk.RecID AS RecID, dbo.SlogNaknada.NaknadeStavka as [Rbr. Naknade], dbo.SlogNaknada.SifraNaknade, dbo.SlogNaknada.IvicniBroj, " & _
                          "dbo.SlogRoba.KolaStavka, dbo.SlogRoba.RobaStavka " & _
                          "FROM dbo.SlogKalk INNER JOIN  " & _
                          "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN  " & _
                          "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND  " & _
                          "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka FULL OUTER JOIN  " & _
                          "dbo.SlogNaknada ON dbo.SlogKalk.RecID = dbo.SlogNaknada.RecID AND dbo.SlogKalk.Stanica = dbo.SlogNaknada.Stanica  " & _
                          "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') " & _
                          sql_text1_order

        End If

        Try


            Dim adSlogKola As New SqlDataAdapter(sql_text1, OkpDbVeza)
            ii1 = adSlogKola.Fill(dsDSKorekcija)


            For jj As Int16 = 0 To dsDSKorekcija.Tables(0).Rows.Count - 1

                mBrojOtp = dsDSKorekcija.Tables(0).Rows(jj).Item(2)
                nmIBK = dsDSKorekcija.Tables(0).Rows(jj).Item(4) 'prva kola;sledi ispitivanje da li su sledeca kola ista
                nmTara = dsDSKorekcija.Tables(0).Rows(jj).Item(5)
                nmSumaTara = nmSumaTara + nmTara

                If jj < dsDSKorekcija.Tables(0).Rows.Count - 1 Then
                    If nmIBK = dsDSKorekcija.Tables(0).Rows(jj + 1).Item(4) Then
                        'If jj = dsDSKorekcija.Tables(0).Rows.Count - 1 Then

                        'Else
                        '    nmSumaTara = nmSumaTara - dsDSKorekcija.Tables(0).Rows(jj + 1).Item(5)
                        'End If
                        nmSumaTara = nmSumaTara - dsDSKorekcija.Tables(0).Rows(jj + 1).Item(5)
                    End If
                Else
                    If nmIBK = dsDSKorekcija.Tables(0).Rows(jj - 1).Item(4) Then
                        'nmSumaTara = nmSumaTara - dsDSKorekcija.Tables(0).Rows(jj).Item(5)
                    End If
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        suma_tara = nmSumaTara '+ +suma_neto

        'TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        'Me.TextBox2.Text = Math.Round(nmSumaTara / 1000, 1).ToString()
        'TextBox3.Text = Math.Round(suma_neto / 1000, 1).ToString


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim KorekcijaRed As DataRow
        Dim _IBK As String = ""
        Dim _NHM As String = ""
        Dim _SqlString As String = ""
        Dim _ii1 As Int32 = 0
        Dim nmAlert As Int32 = 0

        'procedura:
        'uzima RecID, trazi u bazi da li je prvi po sortu na datum izlaza isao tovaren Sever-Jug za isti ugovor(left,4)
        'ako jeste popunjava celiju u koloni Makis sa "D"
        'kad zavrsi ceo grid, ako su svi redovi koloni Makis="D" dodeljuje cenu tamo gde je iznos > 0: za Dimitrovgrad 4510 (ili Preševo 4634)

        ' i da su svi vagoni u Jug-Sever tovareni a ne prazni!


        For Each KorekcijaRed In dtKorekcija.Rows
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            _IBK = Int(KorekcijaRed.Item("IBK"))

            'verzija #1: samo taj ugovor
            '_SqlString = "SELECT SlogKola.IBK, SlogKalk.DatumIzlaza, SlogRoba.NHM, SlogKalk.ZsUlPrelaz, SlogKalk.ZsIzPrelaz " & _
            '             "FROM SlogKalk INNER JOIN " & _
            '             "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN " & _
            '             "SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka " & _
            '             "WHERE (SlogKola.IBK = '" & _IBK & "') AND (SlogRoba.NHM <> '992100') AND (SlogRoba.NHM <> '992200') AND " & _
            '             "(SlogKalk.ZsUlPrelaz = '16517' OR SlogKalk.ZsUlPrelaz = '23499') AND (SlogKalk.ZsIzPrelaz = '12498' OR SlogKalk.ZsIzPrelaz = '11028') " & _
            '             "AND (left(SlogKalk.Ugovor,4)='" & Microsoft.VisualBasic.Left(tbUgovor.Text, 2) & "12" & "' or left(SlogKalk.Ugovor,4)='" & Microsoft.VisualBasic.Left(tbUgovor.Text, 2) & "13" & "' ) " & _
            '             "ORDER BY SlogKalk.DatumIzlaza DESC"

            'verzija #2: sva tri ugovora medjusobno: m.stjepanovic email 20/09/2013
            '_SqlString = "SELECT TOP 100 PERCENT dbo.SlogKola.IBK, dbo.SlogKalk.DatumIzlaza, dbo.SlogRoba.NHM, dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.ZsIzPrelaz " & _
            '             "FROM dbo.SlogKalk INNER JOIN dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
            '             "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
            '             "WHERE  (dbo.SlogKola.IBK = '" & _IBK & "') AND (dbo.SlogRoba.NHM <> '992100') AND (dbo.SlogRoba.NHM <> '992200') AND (dbo.SlogKalk.ZsUlPrelaz = '16517' OR " & _
            '             "dbo.SlogKalk.ZsUlPrelaz = '23499') AND (dbo.SlogKalk.ZsIzPrelaz = '12498' OR dbo.SlogKalk.ZsIzPrelaz = '11028') AND (LEFT(dbo.SlogKalk.Ugovor, 4) = '1013' OR " & _
            '             "LEFT(dbo.SlogKalk.Ugovor, 4) = '1113' OR LEFT(dbo.SlogKalk.Ugovor, 4) = '1213') " & _
            '             "ORDER BY dbo.SlogKalk.DatumIzlaza DESC"



            'verzija #3: FW: Objašnjenje  clana 8,  tacke 2.3,  Ugovora ZS CO  801400 i Ugovora ZS CO 811400 - Marko Stjepanovic email 4/8/2014
            _SqlString = "SELECT TOP 100 PERCENT dbo.SlogKola.IBK, dbo.SlogKalk.DatumIzlaza, dbo.SlogRoba.NHM, dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.ZsIzPrelaz " & _
                         "FROM dbo.SlogKalk INNER JOIN dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                         "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
                         "WHERE  (dbo.SlogKola.IBK = '" & _IBK & "') AND (dbo.SlogRoba.NHM <> '992100') AND (dbo.SlogRoba.NHM <> '992200') AND (dbo.SlogKalk.ZsUlPrelaz = '16517' OR " & _
                         "dbo.SlogKalk.ZsUlPrelaz = '23499') AND (dbo.SlogKalk.ZsIzPrelaz = '12498' OR dbo.SlogKalk.ZsIzPrelaz = '11028') AND (dbo.SlogKalk.DatumIzlaza > CONVERT(DATETIME, '" & nmDatum96.Year.ToString & "-" & nmDatum96.Month.ToString & "-" & nmDatum96.Day.ToString & " 00:00:00'" & " , 102) - 45)" & _
                         "ORDER BY dbo.SlogKalk.DatumIzlaza DESC"


            Try

                Dim sql_comm1 As New SqlClient.SqlCommand(_SqlString, OkpDbVeza)
                Dim rdrRm As SqlClient.SqlDataReader
                rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)

                Do While rdrRm.Read()

                    If IsDBNull(rdrRm.Item(0)) Then
                        KorekcijaRed.Item("Makis") = "N" 'ako ga nema ili su prazna kola
                    Else
                        If Microsoft.VisualBasic.Left(rdrRm.Item(2), 4) <> "9921" And Microsoft.VisualBasic.Left(rdrRm.Item(2), 4) <> "9922" Then
                            KorekcijaRed.Item("Makis") = "D" 'ima ga

                            '''' komentarisala 27.4.'15 '''
                            KorekcijaRed.Item("NakPoKolima") = 0 'ima ga
                            'KorekcijaRed.Item("NakPoKolima") = KorekcijaRed.Item("NakPoKolima") - 60 'ima ga

                            '''' komentarisala 27.4.'15 '''
                            nmAlert = nmAlert + 1
                            Exit Do
                        Else
                            KorekcijaRed.Item("Makis") = "N"
                        End If
                    End If
                Loop
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            OkpDbVeza.Close()
        Next

        If nmAlert <> dtKorekcija.Rows.Count Then
            Dim Str_Najava As String = "Izabrani voz ne ispunjava uslov iz clana 8 stav 2.1 Ugovora ŽS CO " & Microsoft.VisualBasic.Left(mBrojUg, 4) & "00! " & Chr(13)
            Str_Najava = Str_Najava & "Primeniti cenu iz stava 2.2 istog clana." & Chr(13)
            Str_Najava = Str_Najava & " " & Chr(13)
            Str_Najava = Str_Najava & "Objasnjenje:  " & Chr(13)
            Str_Najava = Str_Najava & "#1  U koloni 'Makis' sa 'D' su oznacena kola koja zadovoljavaju kriterijum iz ugovora. " & Chr(13)
            Str_Najava = Str_Najava & "#2  Program obracunava u polju 'NakPoKolima' -60 EUR u skladu sa clanom 8, stav 2.3  ugovora " & Chr(13)

            MessageBox.Show(Str_Najava, "Podaci o vozu ", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _PrimeniUgovor96 = True

        Else
            _PrimeniUgovor96 = False

        End If

    End Sub
    Private Sub PrimeniUgovor96()

        If _Prelaz1 = "12498" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            suma_prevoznina = 6078
        ElseIf _Prelaz1 = "11028" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            suma_prevoznina = 6202
        End If

        If _Prelaz1 = "12498" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            If suma_bruto <= 1200000 Then
                suma_prevoznina = suma_prevoznina * 1
            ElseIf suma_bruto > 1200000 And suma_bruto <= 1300000 Then
                suma_prevoznina = suma_prevoznina * 1.083
            ElseIf suma_bruto > 1300000 And suma_bruto <= 1400000 Then
                suma_prevoznina = suma_prevoznina * 1.166
            ElseIf suma_bruto > 1400000 And suma_bruto <= 1500000 Then
                suma_prevoznina = suma_prevoznina * 1.25
            ElseIf suma_bruto > 1500000 And suma_bruto <= 1600000 Then
                suma_prevoznina = suma_prevoznina * 1.33
            End If
        ElseIf _Prelaz1 = "11028" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            If suma_bruto <= 1200000 Then
                suma_prevoznina = suma_prevoznina * 1
            ElseIf suma_bruto > 1200000 And suma_bruto <= 1300000 Then
                suma_prevoznina = suma_prevoznina * 1.12
            ElseIf suma_bruto > 1300000 And suma_bruto <= 1400000 Then
                suma_prevoznina = suma_prevoznina * 1.21
            ElseIf suma_bruto > 1400000 And suma_bruto <= 1500000 Then
                suma_prevoznina = suma_prevoznina * 1.29
            ElseIf suma_bruto > 1500000 And suma_bruto <= 1600000 Then
                suma_prevoznina = suma_prevoznina * 1.38
            End If
        End If

        bZaokruziNaCeleNavise(suma_prevoznina)

        Koriguj96()

    End Sub
    Private Sub PrimeniPovlasticu96()

        If _Prelaz1 = "12498" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            suma_prevoznina = 4744
        ElseIf _Prelaz1 = "11028" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            suma_prevoznina = 4874
        End If

        If _Prelaz1 = "12498" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            If suma_bruto <= 1200000 Then
                suma_prevoznina = suma_prevoznina * 1
            ElseIf suma_bruto > 1200000 And suma_bruto <= 1300000 Then
                suma_prevoznina = suma_prevoznina * 1.083
            ElseIf suma_bruto > 1300000 And suma_bruto <= 1400000 Then
                suma_prevoznina = suma_prevoznina * 1.166
            ElseIf suma_bruto > 1400000 And suma_bruto <= 1500000 Then
                suma_prevoznina = suma_prevoznina * 1.25
            ElseIf suma_bruto > 1500000 And suma_bruto <= 1600000 Then
                suma_prevoznina = suma_prevoznina * 1.33
            End If
        ElseIf _Prelaz1 = "11028" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            If suma_bruto <= 1200000 Then
                suma_prevoznina = suma_prevoznina * 1
            ElseIf suma_bruto > 1200000 And suma_bruto <= 1300000 Then
                suma_prevoznina = suma_prevoznina * 1.12
            ElseIf suma_bruto > 1300000 And suma_bruto <= 1400000 Then
                suma_prevoznina = suma_prevoznina * 1.21
            ElseIf suma_bruto > 1400000 And suma_bruto <= 1500000 Then
                suma_prevoznina = suma_prevoznina * 1.29
            ElseIf suma_bruto > 1500000 And suma_bruto <= 1600000 Then
                suma_prevoznina = suma_prevoznina * 1.38
            End If
        End If

        bZaokruziNaCeleNavise(suma_prevoznina)

        Koriguj96Minus60()

    End Sub

    Private Sub tbUgovor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUgovor.Validating
        Me.btnFormirajVoz.Focus()

    End Sub
    'Public Sub AutoSizeTable()

    '    Dim numCols As Integer
    '    numCols = CType(dgKorekcija.DataSource, DataTable).Columns.Count
    '    Dim i As Integer
    '    i = 0
    '    Do While (i < numCols)
    '        AutoSizeCol(i)
    '        i = (i + 1)
    '    Loop
    'End Sub
    'Public Sub AutoSizeCol(ByVal col As Integer)
    '    Dim width As Single
    '    width = 0
    '    Dim numRows As Integer
    '    numRows = CType(dgKorekcija.DataSource, DataTable).Rows.Count
    '    Dim g As Graphics
    '    g = Graphics.FromHwnd(dgKorekcija.Handle)
    '    Dim sf As StringFormat
    '    sf = New StringFormat(StringFormat.GenericTypographic)
    '    Dim size As SizeF
    '    Dim i As Integer
    '    i = 0

    '    Do While (i < numRows)
    '        size = g.MeasureString(dgKorekcija(i, col).ToString, dgKorekcija.Font, 500, sf)
    '        If (size.Width > width) Then
    '            width = size.Width + 20  'BILO JE 10
    '        End If
    '        i = (i + 1)

    '    Loop
    '    g.Dispose()
    '    dgKorekcija.TableStyles("SuperGrid").GridColumnStyles(col).Width = CType(width, Integer)
    'End Sub

    Private Sub Koriguj96()
        Dim KorekcijaRed As DataRow
        Dim _RBR As Int32
        'Dim _Prev As Decimal = 0
        Dim _BrojTL As Integer = 0

        '_Prev = CDec(TextBox4.Text)

        TextBox4.Text = Math.Round(suma_prevoznina, 2).ToString()

        For Each KorekcijaRed In dtKorekcija.Rows
            If KorekcijaRed.Item("Prevoznina") > 2000 Then
                KorekcijaRed.Item("Prevoznina") = Math.Round(suma_prevoznina, 2)
                'KorekcijaRed.Item("NakPoKolima") = -60
            End If
            '''  ubacila 27.4.'15  ''''
            If KorekcijaRed.Item("NakPoKolima") = -60 Then
                KorekcijaRed.Item("NakPoKolima") = 0
            End If
            ''' ubacila 27.4.'15  ''''
        Next

        Me.Button1_Click(Me, Nothing)
        Me.btnUpisUBazu.Focus()
    End Sub
    Private Sub Koriguj96Minus60()
        Dim KorekcijaRed As DataRow
        Dim _RBR As Int32
        'Dim _Prev As Decimal = 0
        Dim _BrojTL As Integer = 0

        '_Prev = CDec(TextBox4.Text)
        TextBox4.Text = Math.Round(suma_prevoznina, 2).ToString()

        For Each KorekcijaRed In dtKorekcija.Rows
            If KorekcijaRed.Item("Prevoznina") > 2000 Then
                KorekcijaRed.Item("Prevoznina") = Math.Round(suma_prevoznina, 2)
            End If
            If KorekcijaRed.Item("NakPoKolima") = -60 Then
                KorekcijaRed.Item("NakPoKolima") = 0
            End If
        Next

        Me.Button1_Click(Me, Nothing)
        Me.btnUpisUBazu.Focus()
    End Sub

    Private Sub bKorigujZbogVeceBM()

        If _Prelaz1 = "12498" And _Prelaz2 = "23499" Then
            suma_prevoznina = 6900
        ElseIf _Prelaz1 = "12498" And _Prelaz2 = "16517" Then
            suma_prevoznina = 6728
        End If

        If _Prelaz1 = "12498" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            If suma_bruto <= 1200000 Then
                suma_prevoznina = suma_prevoznina * 1
            ElseIf suma_bruto > 1200000 And suma_bruto <= 1300000 Then
                suma_prevoznina = suma_prevoznina * 1.083
            ElseIf suma_bruto > 1300000 And suma_bruto <= 1400000 Then
                suma_prevoznina = suma_prevoznina * 1.166
            ElseIf suma_bruto > 1400000 And suma_bruto <= 1500000 Then
                suma_prevoznina = suma_prevoznina * 1.25
            ElseIf suma_bruto > 1500000 And suma_bruto <= 1600000 Then
                suma_prevoznina = suma_prevoznina * 1.33
            End If
        ElseIf _Prelaz1 = "11028" And (_Prelaz2 = "23499" Or _Prelaz2 = "16517") Then
            If suma_bruto <= 1160000 Then
                suma_prevoznina = suma_prevoznina * 1
            ElseIf suma_bruto > 1160000 And suma_bruto <= 1300000 Then
                suma_prevoznina = suma_prevoznina * 1.12
            ElseIf suma_bruto > 1300000 And suma_bruto <= 1400000 Then
                suma_prevoznina = suma_prevoznina * 1.21
            ElseIf suma_bruto > 1400000 And suma_bruto <= 1500000 Then
                suma_prevoznina = suma_prevoznina * 1.29
            ElseIf suma_bruto > 1500000 And suma_bruto <= 1600000 Then
                suma_prevoznina = suma_prevoznina * 1.38
            End If
        End If

        bZaokruziNaCeleNavise(suma_prevoznina)

        Koriguj96()

    End Sub
End Class
