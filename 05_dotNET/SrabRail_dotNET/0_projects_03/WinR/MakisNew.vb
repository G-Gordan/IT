Imports System.Data.SqlClient
Imports System.Data
Public Class MakisNew

    Inherits System.Windows.Forms.Form
    Dim _RedniBrojZabrisanje As Int32 = 0
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
    Friend WithEvents tbNajava As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dtDatum As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents btnUpisUBazu As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents btnFormirajVoz As System.Windows.Forms.Button
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbKpN As System.Windows.Forms.TextBox
    Friend WithEvents btnBrisiKola As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgNajava As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MakisNew))
        Me.tbNajava = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnFormirajVoz = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.dtDatum = New System.Windows.Forms.DateTimePicker
        Me.Button9 = New System.Windows.Forms.Button
        Me.btnUpisUBazu = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbKpN = New System.Windows.Forms.TextBox
        Me.btnBrisiKola = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgNajava = New System.Windows.Forms.DataGrid
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgNajava, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbNajava
        '
        Me.tbNajava.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNajava.Location = New System.Drawing.Point(24, 32)
        Me.tbNajava.MaxLength = 10
        Me.tbNajava.Name = "tbNajava"
        Me.tbNajava.Size = New System.Drawing.Size(93, 23)
        Me.tbNajava.TabIndex = 0
        Me.tbNajava.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Broj najave"
        '
        'btnFormirajVoz
        '
        Me.btnFormirajVoz.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btnFormirajVoz.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnFormirajVoz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnFormirajVoz.Image = CType(resources.GetObject("btnFormirajVoz.Image"), System.Drawing.Image)
        Me.btnFormirajVoz.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFormirajVoz.Location = New System.Drawing.Point(740, 0)
        Me.btnFormirajVoz.Name = "btnFormirajVoz"
        Me.btnFormirajVoz.Size = New System.Drawing.Size(96, 96)
        Me.btnFormirajVoz.TabIndex = 0
        Me.btnFormirajVoz.Text = "Formiraj voz"
        Me.btnFormirajVoz.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(680, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 40)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "Poziv procedure"
        Me.Button3.Visible = False
        '
        'dtDatum
        '
        Me.dtDatum.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtDatum.Location = New System.Drawing.Point(264, 32)
        Me.dtDatum.Name = "dtDatum"
        Me.dtDatum.Size = New System.Drawing.Size(152, 23)
        Me.dtDatum.TabIndex = 20
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(836, 0)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(96, 96)
        Me.Button9.TabIndex = 4
        Me.Button9.Text = "Izlaz"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnUpisUBazu
        '
        Me.btnUpisUBazu.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btnUpisUBazu.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnUpisUBazu.Image = CType(resources.GetObject("btnUpisUBazu.Image"), System.Drawing.Image)
        Me.btnUpisUBazu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpisUBazu.Location = New System.Drawing.Point(932, 0)
        Me.btnUpisUBazu.Name = "btnUpisUBazu"
        Me.btnUpisUBazu.Size = New System.Drawing.Size(96, 96)
        Me.btnUpisUBazu.TabIndex = 3
        Me.btnUpisUBazu.Text = "Upis u bazu"
        Me.btnUpisUBazu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpisUBazu.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Bruto masa voza "
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Suma tara "
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label5.Location = New System.Drawing.Point(150, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Suma neto"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label6.Location = New System.Drawing.Point(142, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Prevoznina"
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
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 88)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(126, 59)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.TabIndex = 34
        Me.TextBox4.Text = ""
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(126, 22)
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
        Me.TextBox2.Location = New System.Drawing.Point(14, 22)
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
        Me.TextBox1.Location = New System.Drawing.Point(13, 60)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.TabIndex = 31
        Me.TextBox1.Text = ""
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(644, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 96)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "Refresh"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbUgovor
        '
        Me.tbUgovor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(144, 32)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(88, 23)
        Me.tbUgovor.TabIndex = 1
        Me.tbUgovor.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(144, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Broj ugovora"
        '
        'Label7
        '
        Me.Label7.Enabled = False
        Me.Label7.Location = New System.Drawing.Point(456, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 16)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Broj kola po najavi: "
        Me.Label7.Visible = False
        '
        'tbKpN
        '
        Me.tbKpN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbKpN.Enabled = False
        Me.tbKpN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKpN.Location = New System.Drawing.Point(456, 32)
        Me.tbKpN.MaxLength = 10
        Me.tbKpN.Name = "tbKpN"
        Me.tbKpN.Size = New System.Drawing.Size(96, 23)
        Me.tbKpN.TabIndex = 36
        Me.tbKpN.Text = ""
        Me.tbKpN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbKpN.Visible = False
        '
        'btnBrisiKola
        '
        Me.btnBrisiKola.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btnBrisiKola.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnBrisiKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiKola.Image = CType(resources.GetObject("btnBrisiKola.Image"), System.Drawing.Image)
        Me.btnBrisiKola.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiKola.Location = New System.Drawing.Point(1028, 0)
        Me.btnBrisiKola.Name = "btnBrisiKola"
        Me.btnBrisiKola.Size = New System.Drawing.Size(96, 96)
        Me.btnBrisiKola.TabIndex = 42
        Me.btnBrisiKola.Text = "Brisi kola iz voza"
        Me.btnBrisiKola.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(920, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 32)
        Me.Button2.TabIndex = 43
        Me.Button2.Text = "Fill ListBox"
        Me.Button2.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(856, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(48, 43)
        Me.ListBox1.TabIndex = 44
        Me.ListBox1.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1040, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(40, 32)
        Me.Button4.TabIndex = 45
        Me.Button4.Text = "Uporedjivanje"
        Me.Button4.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Azure
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.tbNajava)
        Me.Panel1.Controls.Add(Me.tbUgovor)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.tbKpN)
        Me.Panel1.Controls.Add(Me.dtDatum)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1128, 72)
        Me.Panel1.TabIndex = 46
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnFormirajVoz)
        Me.Panel2.Controls.Add(Me.Button9)
        Me.Panel2.Controls.Add(Me.btnUpisUBazu)
        Me.Panel2.Controls.Add(Me.btnBrisiKola)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 566)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1128, 100)
        Me.Panel2.TabIndex = 47
        '
        'dgNajava
        '
        Me.dgNajava.AlternatingBackColor = System.Drawing.Color.GhostWhite
        Me.dgNajava.BackColor = System.Drawing.Color.GhostWhite
        Me.dgNajava.BackgroundColor = System.Drawing.Color.Lavender
        Me.dgNajava.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgNajava.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.dgNajava.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgNajava.CaptionForeColor = System.Drawing.Color.White
        Me.dgNajava.CaptionVisible = False
        Me.dgNajava.DataMember = ""
        Me.dgNajava.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgNajava.FlatMode = True
        Me.dgNajava.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgNajava.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgNajava.GridLineColor = System.Drawing.Color.RoyalBlue
        Me.dgNajava.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.dgNajava.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgNajava.HeaderForeColor = System.Drawing.Color.Lavender
        Me.dgNajava.LinkColor = System.Drawing.Color.Teal
        Me.dgNajava.Location = New System.Drawing.Point(0, 72)
        Me.dgNajava.Name = "dgNajava"
        Me.dgNajava.ParentRowsBackColor = System.Drawing.Color.Lavender
        Me.dgNajava.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.dgNajava.PreferredColumnWidth = 120
        Me.dgNajava.SelectionBackColor = System.Drawing.Color.Teal
        Me.dgNajava.SelectionForeColor = System.Drawing.Color.PaleGreen
        Me.dgNajava.Size = New System.Drawing.Size(1128, 494)
        Me.dgNajava.TabIndex = 49
        '
        'MakisNew
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1128, 666)
        Me.Controls.Add(Me.dgNajava)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MakisNew"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgNajava, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim dsNajava As DataSet
    Dim dsNajava1 As DataSet



    Private Sub MakisNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mDatumKalk = dtDatum.Value
        FormatGrid()
        dtMakis.Clear()
        dtMakis1.Clear()

        If ZaostalaKola = "Da" Then
            Label2.Visible = True
            tbUgovor.Visible = True
            tbNajava.Text = mNajava
            tbUgovor.Text = mBrojUg
            btnFormirajVoz.Focus() '_Click(Me, Nothing)

        Else
            If VozoviMakis = "Novi" Then
                Label2.Visible = False
                tbUgovor.Visible = True
            Else 'VozoviMakis = "Izmena"
                Label2.Visible = True
                tbUgovor.Visible = True
            End If
            tbNajava.Focus()

        End If

    End Sub
    Private Sub FormatGrid()
        'Col1.AutoIncrement = True
        'Col1.ReadOnly = True
        If VozoviMakis = "Novi" Then

            If dsNajava Is Nothing Then
                dgNajava.DataSource = dtMakis
            Else
                If mNajava Is Nothing Then
                Else
                    dgNajava.DataSource = dtMakis
                End If
                dgNajava.DataSource = dsNajava.Tables(0)
            End If

        Else

            If dsNajava1 Is Nothing Then
                dgNajava.DataSource = dtMakis1
            Else
                If mNajava Is Nothing Then
                Else
                    dgNajava.DataSource = dtMakis1
                End If
                dgNajava.DataSource = dsNajava1.Tables(0)
            End If

        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim NajavaRed As DataRow
        Dim _ibk As String
        Dim sql_text1 As String = ""
        Dim suma_tara As Int32 = 0
        Dim suma_neto As Int32 = 0
        Dim suma_bruto As Int32 = 0
        Dim _UKK_Real As Int32 = 0
        Dim _UKK As Int32 = 0

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        Dim _t_ As Int32

        For Each NajavaRed In dtMakis.Rows

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            _ibk = NajavaRed.Item("IBK")

            sql_text1 = "SELECT dbo.SlogKalk.RecID, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.Najava, dbo.SlogKalk.PrUprava " & _
                        "FROM dbo.SlogKalk INNER JOIN " & _
                        "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                        "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND " & _
                        "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
                        "WHERE (dbo.SlogKalk.ObrGodina = '" & mObrGodina & "') AND (dbo.SlogKola.IBK = '" & _ibk & "') AND (SUBSTRING(dbo.SlogKalk.Najava, 2, 1) = 'X') AND (dbo.SlogKalk.Najava2 = '0')"

            Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
            Dim rdrRm As SqlClient.SqlDataReader

            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)

            Do While rdrRm.Read()

                NajavaRed.Item("RecID") = rdrRm.GetInt32(0)
                NajavaRed.Item("Tara") = rdrRm.GetInt32(1)
                NajavaRed.Item("Masa") = rdrRm.GetInt32(2)
                NajavaRed.Item("DoMakisa") = rdrRm.GetString(3)
                suma_tara = suma_tara + NajavaRed.Item("Tara")
                suma_neto = suma_neto + NajavaRed.Item("Masa")
                mPrUprava = Microsoft.VisualBasic.Right(rdrRm.GetString(4), 2)

            Loop

            If NajavaRed.Item("Masa") > 0 Then
                NajavaRed.Item("Real") = "1"
                _UKK_Real = _UKK_Real + 1
            End If

            rdrRm.Close()
            OkpDbVeza.Close()
        Next

        dgNajava.Refresh()

        _UKK = dtMakis.Rows.Count

        suma_bruto = suma_tara + suma_neto

        GroupBox1.Visible = True
        GroupBox1.Text = "  [  " & _UKK_Real.ToString & " / " & _UKK.ToString & "  ]  "

        TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        TextBox2.Text = Math.Round(suma_neto / 1000, 1).ToString
        TextBox3.Text = Math.Round(suma_tara / 1000, 1).ToString


        '--------------------------------------- kalkulacija
        _PraviPrelaz = mStanica1
        mStanica1 = "16201"

        mBrojUg = tbUgovor.Text
        mOtpUprava = "00"

        mBrutoMasaPoPosiljci = suma_bruto
        bNadjiPrevozninu01COMakis(mPrevoznina)
        mStanica1 = _PraviPrelaz

        'TextBox4.Text = mPrevoznina.ToString
        TextBox4.Text = Math.Round(mPrevoznina, 2).ToString()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Close()
    End Sub

    Private Sub btnUpisUBazu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpisUBazu.Click

        If VozoviMakis = "Novi" Then
            Dim _ibk15e As String = "x"

            Dim _UKK As Int32
            Dim _recID As Int32
            Dim NajavaRed1 As DataRow
            Dim sql_text2 As String
            Dim m_Naknade As Decimal
            Dim m_NaknadeNula As Decimal = 0
            Dim m_Prevoznina As Decimal = mPrevoznina
            Dim slogTrans As SqlTransaction

            If tbUgovor.Text = "100801" Then
                m_Naknade = 12
            ElseIf tbUgovor.Text = "100901" Then
                m_Naknade = 13
            ElseIf tbUgovor.Text = "101001" Then    '#$#
                m_Naknade = 15
            ElseIf tbUgovor.Text = "101101" Then    '#$#
                m_Naknade = 15
            ElseIf tbUgovor.Text = "101201" Then    '#$#
                m_Naknade = 16
            ElseIf tbUgovor.Text = "101301" Then        '#$#
                m_Naknade = 17
            End If

            If tbUgovor.Text = "801401" Or tbUgovor.Text = "811401" Then  '#$#
                m_Naknade = 18
            End If
            If tbUgovor.Text = "801501" Or tbUgovor.Text = "811501" Then  '#$#
                m_Naknade = 18
            End If

            _UKK = Me.tbKpN.Text 'dtMakis.Rows.Count

            If _UKK > 0 Then

                Dim myCommand As SqlCommand
                Dim ra As Int32
                Dim rv As String
                Dim _UpisiTL As Int16 = 0

                For Each NajavaRed1 In dtMakis.Rows
                    If OkpDbVeza.State = ConnectionState.Closed Then
                        OkpDbVeza.Open()
                    End If

                    _recID = NajavaRed1.Item("RecID")

                    If _UpisiTL = 1 Then
                        m_Prevoznina = 0
                    Else
                        m_Prevoznina = TextBox4.Text
                    End If

                    If _ibk15e = NajavaRed1.Item("IBK") Then
                        sql_text2 = "UPDATE SlogKalk " & _
                                " SET Najava2 = '" & tbNajava.Text & "', NajavaKola2 = " & _UKK & ", " & _
                                " ObrGodina2  = " & mObrGodina & ", ObrMesec2 = " & mObrMesec & ", " & _
                                " rSumaFR = " & (m_Prevoznina + m_Naknade) & ", rPrevFR = " & m_Prevoznina & ", " & _
                                " rNakFR = " & m_NaknadeNula & ", " & _
                                " Referent2 = '" & mUserID & "'  " & _
                                " WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"
                    Else

                        sql_text2 = "UPDATE SlogKalk " & _
                                " SET Najava2 = '" & tbNajava.Text & "', NajavaKola2 = " & _UKK & ", " & _
                                " ObrGodina2  = " & mObrGodina & ", ObrMesec2 = " & mObrMesec & ", " & _
                                " rSumaFR = " & (m_Prevoznina + m_Naknade) & ", rPrevFR = " & m_Prevoznina & ", " & _
                                " rNakFR = " & m_Naknade & ", " & _
                                " Referent2 = '" & mUserID & "'  " & _
                                " WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"
                    End If
                    ''zbog nule
                    ''sql_text2 = "UPDATE SlogKalk " & _
                    ''            " SET Najava2 = '" & tbNajava.Text & "', NajavaKola2 = " & _UKK & ", " & _
                    ''            " ObrGodina2  = " & mObrGodina & ", ObrMesec2 = " & mObrMesec & ", " & _
                    ''            " rSumaFR = " & (m_Prevoznina + m_Naknade) & ", rPrevFR = " & m_Prevoznina & ", " & _
                    ''            " rNakFR = " & m_Naknade & " " & _
                    ''            " WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"

                    myCommand = New SqlCommand(sql_text2, OkpDbVeza)

                    Try
                        If NajavaRed1.Item("Real") = "1" Then
                            ra = myCommand.ExecuteNonQuery()
                            If ra = 1 Then
                                _UpisiTL = 1
                            End If
                        End If

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    OkpDbVeza.Close()


                    _ibk15e = NajavaRed1.Item("IBK")
                Next

                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                End If

                Dim NajavaRed2 As DataRow
                Dim _ibk As String

                slogTrans = OkpDbVeza.BeginTransaction()

                For Each NajavaRed2 In dtMakis.Rows
                    _ibk = NajavaRed2.Item("IBK")
                    If NajavaRed2.Item("Real") = "1" Then
                        Upis.NajavaUpd(slogTrans, mBrojUg, tbNajava.Text, _ibk, rv)
                    End If
                Next

                slogTrans.Commit()

                MessageBox.Show("Podaci o vozu po najavi br.  " & tbNajava.Text & " su upisani u bazu podataka. ", "Beograd Ranzirna", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dtMakis.Clear()
                tbNajava.Text = ""
                Me.btnUpisUBazu.Visible = False
                Me.btnFormirajVoz.Visible = True
                Me.GroupBox1.Visible = False
                Close()

            Else
                MessageBox.Show("Nepostojeci podaci !", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else  'KOREKCIJA

            Dim _UKK As Int32
            Dim _recID As Int32
            Dim NajavaRed1 As DataRow
            Dim sql_text2 As String
            Dim m_Naknade As Decimal
            Dim m_Prevoznina As Decimal = mPrevoznina
            Dim slogTrans As SqlTransaction

            If tbUgovor.Text = "100801" Then
                m_Naknade = 12
            ElseIf tbUgovor.Text = "100901" Then
                m_Naknade = 13
            ElseIf tbUgovor.Text = "101001" Then        '#$#
                m_Naknade = 15
            ElseIf tbUgovor.Text = "101101" Then        '#$#
                m_Naknade = 15
            ElseIf tbUgovor.Text = "101201" Then    '#$#
                m_Naknade = 16
            ElseIf tbUgovor.Text = "101301" Then        '#$#
                m_Naknade = 17
            End If
            If tbUgovor.Text = "801501" Or tbUgovor.Text = "811501" Then  '#$#
                m_Naknade = 18
            End If

            _UKK = Me.tbKpN.Text   'dtMakis1.Rows.Count

            If _UKK > 0 Then

                Dim myCommand As SqlCommand
                Dim ra As Int32
                Dim rv As String
                Dim _UpisiTL As Int16 = 0
                Dim _Suma As Decimal = 0
                Dim _Prev As Decimal = 0
                Dim _Nak As Decimal = 0
                Dim _ZeroMonth As String = "0"
                Dim _Zero As Decimal = 0
                Dim ctrl_err As String = "Yes"

                For Each NajavaRed1 In dtMakis1.Rows
                    If OkpDbVeza.State = ConnectionState.Closed Then
                        OkpDbVeza.Open()
                    End If

                    _recID = NajavaRed1.Item("RecID")
                    _Prev = NajavaRed1.Item("Prevoznina")
                    _Nak = NajavaRed1.Item("Naknada")

                    If NajavaRed1.Item("Mesec") = "0" Then '----------- brisanje iz voza 

                        sql_text2 = "UPDATE SlogKalk " & _
                                    "SET Najava2 = '" & _ZeroMonth & "'  , " & _
                                    "rSumaFR = " & (_Zero + _Zero) & ", rPrevFR = " & _Zero & ", " & _
                                    "rNakFR = " & _Zero & ", " & _
                                    "Referent2 = '" & mUserID & "'  " & _
                                    "WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"

                    Else                                         '----------- obican update


                        sql_text2 = "UPDATE SlogKalk " & _
                                    "SET rSumaFR = " & (_Prev + _Nak) & ", rPrevFR = " & _Prev & ", " & _
                                    "rNakFR = " & _Nak & ", " & _
                                    "Referent2 = '" & mUserID & "'  " & _
                                    "WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"
                    End If

                    myCommand = New SqlCommand(sql_text2, OkpDbVeza)

                    Try
                        ra = myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                        ctrl_err = "No"
                        MsgBox(ex.ToString)
                    End Try
                    OkpDbVeza.Close()

                Next
                If ctrl_err = "Yes" Then
                    MessageBox.Show("Podaci o vozu po najavi br.  " & tbNajava.Text & " su upisani u bazu podataka. ", "Beograd Ranzirna", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Podaci o vozu po najavi br.  " & tbNajava.Text & " nisu upisani u bazu podataka! ", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


                dtMakis1.Clear()
                tbNajava.Text = ""
                tbUgovor.Text = ""
                Me.btnUpisUBazu.Visible = False
                Me.btnFormirajVoz.Visible = True
                Me.GroupBox1.Visible = False
                Close()

            Else
                MessageBox.Show("Nepostojeci podaci !", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If


    End Sub

    Private Sub tbNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbNajava_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNajava.Validated
        mDatumKalk = dtDatum.Value
    End Sub

    Private Sub btnFormirajVoz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormirajVoz.Click

        If VozoviMakis = "Novi" Then

            Dim suma_neto As Int32 = 0
            Dim suma_tara As Int32 = 0
            Dim suma_bruto As Int32 = 0
            Dim _nRbr As Int32 = 1
            Dim _nNajavljenoKola As Int16 = 0
            Dim _nIBK As String
            Dim _nIzlaz As String = ""
            Dim _nNajava As String = ""
            Dim _nTara As Int32 = 0
            Dim _nNeto As Int32 = 0
            Dim _nRecID As Int32 = 0
            Dim _UKK As Int32 = 0

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            mObrGodina = dtDatum.Value.Year


            '======================== MakisNew!
            Dim sql_text1 As String = "SELECT TOP 100 PERCENT dbo.NajavaVoza.SumaKola, dbo.SlogKola.IBK, dbo.SlogKalk.ZsIzPrelaz, dbo.SlogKalk.Najava, dbo.SlogKola.Tara, " & _
                                      "dbo.SlogRoba.SMasa, dbo.SlogKalk.RecID " & _
                                      "FROM dbo.SlogKola INNER JOIN " & _
                                      "dbo.SlogKalk ON dbo.SlogKola.RecID = dbo.SlogKalk.RecID AND dbo.SlogKola.Stanica = dbo.SlogKalk.Stanica INNER JOIN " & _
                                      "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND " & _
                                      "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka INNER JOIN " & _
                                      "dbo.NajavaKola INNER JOIN " & _
                                      "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza ON " & _
                                      "dbo.SlogKola.IBK = dbo.NajavaKola.IBK " & _
                                      "WHERE (dbo.NajavaKola.KomBrojVoza = '" & tbNajava.Text & "') AND (dbo.NajavaKola.BrUgovora = '" & tbUgovor.Text & "') AND " & _
                                      "(dbo.SlogKalk.ObrGodina2 = '" & mObrGodina & "') AND (dbo.SlogKalk.Najava2 = '0') AND (RIGHT(LEFT(dbo.SlogKalk.Najava, 2), 1) = 'X') " & _
                                      "ORDER BY dbo.SlogKola.IBK "

            Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
            Dim rdrRm As SqlClient.SqlDataReader
            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)


            Do While rdrRm.Read()

                _nNajavljenoKola = rdrRm.GetInt16(0)
                _nIBK = rdrRm.GetString(1)
                _nIzlaz = rdrRm.GetString(2)
                _nNajava = rdrRm.GetString(3)
                _nTara = rdrRm.GetInt32(4)
                _nNeto = rdrRm.GetInt32(5)
                _nRecID = rdrRm.GetInt32(6)

                mStanica2 = _nIzlaz

                suma_tara = suma_tara + _nTara
                suma_neto = suma_neto + _nNeto

                dtMakis.NewRow()
                dtMakis.Rows.Add(New Object() {_nRbr, _nIBK, _nIzlaz, "", _nNajava, _nTara, _nNeto, _nRecID})
                _nRbr = _nRbr + 1
            Loop

            rdrRm.Close()
            OkpDbVeza.Close()
            dgNajava.Refresh()

            Me.btnFormirajVoz.Visible = False
            Me.btnUpisUBazu.Visible = True
            Me.btnUpisUBazu.Focus()

            suma_bruto = suma_tara + suma_neto

            GroupBox1.Visible = True

            TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
            TextBox2.Text = Math.Round(suma_neto / 1000, 1).ToString
            TextBox3.Text = Math.Round(suma_tara / 1000, 1).ToString

            '--------------------------------------- kalkulacija
            _PraviPrelaz = mStanica1
            mStanica1 = "16201"

            mBrojUg = tbUgovor.Text
            mOtpUprava = "00"

            mBrutoMasaPoPosiljci = suma_bruto

            '* * *
            bNadjiPrevozninu01COMakis(mPrevoznina)
            '* * *

            mStanica1 = _PraviPrelaz

            TextBox4.Text = Math.Round(mPrevoznina, 2).ToString()


            Button2_Click(Me, Nothing)
            Button4_Click(Me, Nothing)

            Fix15eur()

        Else  'KOREKCIJA

            Dim _nRbr As Int32 = 1
            Dim _nIBK As String
            Dim _nIzlaz As Int32
            Dim suma_tara As Int32 = 0
            Dim suma_neto As Int32 = 0
            Dim suma_bruto As Int32 = 0
            Dim _najavljenoKola As Int32 = 0

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            Dim sql_text1 As String = "SELECT SlogKalk.NajavaKola2 AS [Ukupno kola],  " & _
                                      "SlogKalk.ObrMesec2 AS Mesec, SlogKalk.OtpBroj AS OtpBroj, SlogKola.IBK, SlogKola.Tara, SlogRoba.SMasa, SlogKalk.rPrevFr AS Prevoznina, " & _
                                      "SlogKalk.rNakFr AS Naknade, SlogKalk.RecID AS RecID " & _
                                      "FROM  SlogKalk INNER JOIN " & _
                                      "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN " & _
                                      "SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka " & _
                                      "WHERE (dbo.SlogKalk.Najava2 = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & " ') " & _
                                      "ORDER BY SlogKola.IBK "
            '"ORDER BY SlogKola.IBK "
            '"ORDER BY SlogKalk.OtpBroj "

            '''Dim sql_text1 As String = "SELECT SlogKalk.NajavaKola2 AS [Ukupno kola],  " & _
            '''                          "SlogKalk.ObrMesec2 AS Mesec, SlogKalk.IzEtiketa AS Nalepnica, SlogKola.IBK, SlogKola.Tara, SlogRoba.SMasa, SlogKalk.rPrevFr AS Prevoznina, " & _
            '''                          "SlogKalk.rNakFr AS Naknade, SlogKalk.RecID AS RecID " & _
            '''                          "FROM  SlogKalk INNER JOIN " & _
            '''                          "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN " & _
            '''                          "SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka " & _
            '''                          "WHERE (dbo.SlogKalk.Najava2 = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & " ') " & _
            '''                          "ORDER BY SlogKalk.IzEtiketa "


            Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
            Dim rdrRm As SqlClient.SqlDataReader
            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrRm.Read()

                _najavljenoKola = rdrRm.GetInt32(0)
                suma_tara = suma_tara + rdrRm.GetInt32(4)
                suma_neto = suma_neto + rdrRm.GetInt32(5)

                dtMakis1.NewRow()
                dtMakis1.Rows.Add(New Object() {_nRbr, rdrRm.GetString(1), rdrRm.GetInt32(2), rdrRm.GetString(3), rdrRm.GetInt32(4), rdrRm.GetInt32(5), rdrRm.GetDecimal(6), rdrRm.GetDecimal(7), rdrRm.GetInt32(8)})
                _nrbr = _nrbr + 1
            Loop

            Me.tbKpN.Text = _najavljenoKola

            rdrRm.Close()
            OkpDbVeza.Close()
            dgNajava.Refresh()

            Me.btnFormirajVoz.Visible = False
            Me.btnUpisUBazu.Visible = True
            Me.btnUpisUBazu.Focus()

            suma_bruto = suma_tara + suma_neto

            GroupBox1.Visible = True
            Label6.Visible = False
            TextBox4.Visible = False

            TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
            TextBox2.Text = Math.Round(suma_tara / 1000, 1).ToString
            TextBox3.Text = Math.Round(suma_neto / 1000, 1).ToString


            'Fix15eur()


        End If


    End Sub

    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim suma_tara As Int32 = 0
        Dim suma_neto As Int32 = 0
        Dim suma_bruto As Int32 = 0

        If VozoviMakis = "Novi" Then
            suma_tara = dtMakis.Compute("SUM(Tara)", String.Empty)
            suma_neto = dtMakis.Compute("SUM(Masa)", String.Empty)
        Else
            'If NajavaRed1.Item("Mesec") = "Brisati" Then

            'End If

            ''suma_tara = dtMakis1.Compute("SUM(Tara)", String.Empty)
            ''suma_neto = dtMakis1.Compute("SUM(Masa)", String.Empty)

            If IsDBNull(dtMakis1.Compute("SUM(Tara)", "Mesec = 0")) = True Then
                suma_tara = dtMakis1.Compute("SUM(Tara)", String.Empty)
            Else
                suma_tara = dtMakis1.Compute("SUM(Tara)", String.Empty) - dtMakis1.Compute("SUM(Tara)", "Mesec = 10")
            End If
            If IsDBNull(dtMakis1.Compute("SUM(Masa)", "Mesec = 0")) = True Then
                suma_neto = dtMakis1.Compute("SUM(Masa)", String.Empty)
            Else
                suma_neto = dtMakis1.Compute("SUM(Masa)", String.Empty) - dtMakis1.Compute("SUM(Masa)", "Mesec = 10")
            End If

            ''suma_tara = dtMakis1.Compute("SUM(Tara)", String.Empty) - dtMakis1.Compute("SUM(Tara)", "Mesec = 10")
            ''suma_neto = dtMakis1.Compute("SUM(Tara)", String.Empty) - dtMakis1.Compute("SUM(Masa)", "Mesec = 10")

        End If

        suma_bruto = suma_tara + suma_neto

        TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        TextBox2.Text = Math.Round(suma_tara / 1000, 1).ToString
        TextBox3.Text = Math.Round(suma_neto / 1000, 1).ToString
    End Sub

    Private Sub FormirajNajavu()

        Dim NajavaRed As DataRow
        Dim _ibk As String
        Dim sql_text1 As String = ""
        Dim suma_tara As Int32 = 0
        Dim suma_neto As Int32 = 0
        Dim suma_bruto As Int32 = 0
        Dim _UKK_Real As Int32 = 0
        Dim _UKK As Int32 = 0

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        Dim _t_ As Int32


        For Each NajavaRed In dtMakis.Rows

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            _ibk = NajavaRed.Item("IBK")

            sql_text1 = "SELECT dbo.SlogKalk.RecID, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.Najava, dbo.SlogKalk.PrUprava " & _
                        "FROM dbo.SlogKalk INNER JOIN " & _
                        "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                        "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND " & _
                        "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
                        "WHERE (dbo.SlogKalk.ObrGodina = '" & mObrGodina & "') AND (dbo.SlogKola.IBK = '" & _ibk & "') AND (SUBSTRING(dbo.SlogKalk.Najava, 2, 1) = 'X') AND (dbo.SlogKalk.Najava2 = '0')"

            Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
            Dim rdrRm As SqlClient.SqlDataReader

            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)

            Do While rdrRm.Read()

                NajavaRed.Item("RecID") = rdrRm.GetInt32(0)
                NajavaRed.Item("Tara") = rdrRm.GetInt32(1)
                NajavaRed.Item("Masa") = rdrRm.GetInt32(2)
                NajavaRed.Item("DoMakisa") = rdrRm.GetString(3)
                suma_tara = suma_tara + NajavaRed.Item("Tara")
                suma_neto = suma_neto + NajavaRed.Item("Masa")
                mPrUprava = Microsoft.VisualBasic.Right(rdrRm.GetString(4), 2)

            Loop

            If NajavaRed.Item("Masa") > 0 Then
                NajavaRed.Item("Real") = "1"
                _UKK_Real = _UKK_Real + 1
            End If

            rdrRm.Close()
            OkpDbVeza.Close()
        Next

        dgNajava.Refresh()

        _UKK = dtMakis.Rows.Count

        suma_bruto = suma_tara + suma_neto

        GroupBox1.Visible = True
        GroupBox1.Text = "  [  " & _UKK_Real.ToString & " / " & _UKK.ToString & "  ]  "

        TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        TextBox2.Text = Math.Round(suma_neto / 1000, 1).ToString
        TextBox3.Text = Math.Round(suma_tara / 1000, 1).ToString


        '--------------------------------------- kalkulacija
        _PraviPrelaz = mStanica1
        mStanica1 = "16201"

        mBrojUg = tbUgovor.Text
        mOtpUprava = "00"

        mBrutoMasaPoPosiljci = suma_bruto
        bNadjiPrevozninu01COMakis(mPrevoznina)
        mStanica1 = _PraviPrelaz

        'TextBox4.Text = mPrevoznina.ToString
        TextBox4.Text = Math.Round(mPrevoznina, 2).ToString()

    End Sub

    Private Sub btnBrisiKola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiKola.Click

        Dim Msg As String
        Dim Ans As MsgBoxResult

        Msg = "Izabrana kola ce biti izbrisana! " & Chr(13)
        Msg = Msg & "Da li ste sigurni?"

        Ans = MsgBox(Msg, vbYesNo + vbInformation, "Brisanje podataka!")
        If Ans = vbNo Then

        Else
            Dim NajavaRed As DataRow
            Dim dr() As DataRow
            Dim _nRbr As Int32 = 1

            If VozoviMakis = "Novi" Then
                Try
                    dr = dtMakis.Select("RBR = " & _RedniBrojZabrisanje)
                    dtMakis.Rows.Remove(dr(0))
                    For Each NajavaRed In dtMakis.Rows
                        NajavaRed.Item("RBR") = _nRbr
                        _nRbr = _nRbr + 1
                    Next

                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try
            Else
                For Each NajavaRed In dtMakis1.Rows
                    If NajavaRed.Item("RBR") = _RedniBrojZabrisanje Then
                        NajavaRed.Item("Mesec") = "0"
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub dgNajava_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgNajava.Click
        Dim currRowKola As DataRow

        currRowKola = CType(dgNajava.DataSource, DataTable).Rows(dgNajava.CurrentCell.RowNumber)

        _RedniBrojZabrisanje = currRowKola(0, DataRowVersion.Current).ToString()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim _nRbr As Int32
        Dim _nIBK As String
        Dim _nIzlaz As String = ""

        Me.ListBox1.Items.Clear()

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim sql_text1 As String = "SELECT dbo.NajavaKola.KolaStavka, dbo.NajavaKola.IBK " & _
                                  "FROM dbo.NajavaKola INNER JOIN " & _
                                  "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                                  "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                                  "WHERE (dbo.NajavaVoza.RacGodina = '" & mObrGodina & "') AND (dbo.NajavaKola.KomBrojVoza = '" & tbNajava.Text & "') AND (dbo.NajavaKola.BrUgovora = '" & tbUgovor.Text & "') " & _
                                  "ORDER BY dbo.NajavaKola.IBK "

        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrRm.Read()
            _nRbr = rdrRm.GetInt32(0)
            _nIBK = rdrRm.GetString(1)
            Me.ListBox1.Items.Add(_nIBK)
        Loop

        Me.tbKpN.Text = Me.ListBox1.Items.Count

        rdrRm.Close()
        OkpDbVeza.Close()
        dgNajava.Refresh()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim NajavaRed As DataRow
        Dim ctrl_ibk As String
        Dim ctrl_nasao As String = "N"

        For ii As Int16 = 0 To Me.ListBox1.Items.Count - 1
            ctrl_ibk = Me.ListBox1.Items.Item(ii)
            ctrl_nasao = "N"
            For Each NajavaRed In dtMakis.Rows
                If ctrl_ibk = NajavaRed.Item("IBK") Then
                    NajavaRed.Item("Real") = "1"
                    ctrl_nasao = "D"
                End If
            Next
            If ctrl_nasao = "N" Then
                dtMakis.NewRow()
                dtMakis.Rows.Add(New Object() {90 + ii, ctrl_ibk, "0", "0", "0", 0, 0, 0})
            End If
        Next

        Dim _nRbr As Int32 = 1
        For Each NajavaRed In dtMakis.Rows
            NajavaRed.Item("RBR") = _nRbr
            _nRbr = _nRbr + 1
        Next
    End Sub

    Private Sub dtDatum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtDatum.Leave
        mDatumKalk = Me.dtDatum.Value
    End Sub


    Private Sub Fix15eur()

        Dim KolaRed As DataRow
        Dim _ibk As String = "x"

        For Each KolaRed In dtMakis1.Rows
            If _ibk = KolaRed.Item("IBK") Then
                KolaRed.Item("Naknada") = 0
            Else
                KolaRed.Item("Naknada") = 18 '2014
            End If
            _ibk = KolaRed.Item("IBK")
        Next

    End Sub

    Private Sub tbUgovor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUgovor.Validating
        btnFormirajVoz.Focus()

    End Sub
End Class
