Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection
Imports CrystalDecisions.Shared

Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim Upit0 As String
    Dim Upit1 As String
    Dim Upit2 As String
    Dim Upit3 As String
    Dim UpitK As String

    Dim OtpUpr As String
    Dim OtpStan As String
    Dim BrOtp As Integer
    Dim Godina As String
    Dim Valuta As String
    Dim Tkm As Integer
    Dim Kurs As Decimal = 0
    Dim j As Int16 = 0
    Dim Ugovor As String
    Dim Vrsta As Int16 = 1
    Dim DatPr As Date
    Dim SifVal As Int16 = 17
    Dim Iznos As Decimal = 0
    Dim SifNak As Int16

    Dim DatumOd As Date
    Dim DatumDo As Date
    Dim kVrsta As Int16 = 1

    Dim ZaracTL As Decimal = 0
    Dim tlStari As Decimal = 0
    Dim FrPoTL As Decimal = 0
    Dim UpPoTL As Decimal = 0
    Dim SumFrPoTL As Decimal = 0
    Dim NakFr As Decimal = 0
    Dim PZO As Decimal = 0
    Dim CP As Decimal = 0
    Dim Rasp As Decimal = 0
    Dim Manjak As Decimal = 0
    Dim Visak As Decimal = 0
    Dim Pred As Decimal = 0
    Dim TrGot As Decimal = 0

    Dim tlNovi As Decimal = 0
    Dim RazlFr As Decimal = 0
    Dim RaspN As Decimal = 0
    Dim SpUslN As Decimal = 0
    Dim PZON As Decimal = 0
    Dim ManjakN As Decimal = 0
    Dim VisakN As Decimal = 0
    Dim ZaracTLN As Decimal = 0
    Dim PredN As Decimal = 0
    Dim CPN As Decimal = 0
    Dim TrGotN As Decimal = 0
    Dim Novi As Decimal = 0
    Dim Stari As Decimal = 0
    Dim RedBR As Int16
    Dim BrPred As String
    Dim PrBroj As String
    Dim Stanica As String
    Dim BrKP As String
    Dim UkBr As Int16 = 1
    Friend Novo As Decimal = 0

    Dim Nak As Decimal
    Dim TruGot As Decimal
    Dim Uk As Decimal
    Dim PovVrednost As String
    Dim M As Decimal
    Dim V As Decimal
    Dim PZORazl As Decimal
    Dim CPRazl As Decimal
    Dim Preduj As Decimal
    Dim Kor As String
    Dim RetVal As String = ""

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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox33 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox35 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox36 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox38 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBox39 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox41 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox42 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox44 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox45 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox47 As System.Windows.Forms.TextBox
    Friend WithEvents txtRMasa As System.Windows.Forms.TextBox
    Friend WithEvents txtTrGot As System.Windows.Forms.TextBox
    Friend WithEvents txtPred As System.Windows.Forms.TextBox
    Friend WithEvents txtKurs As System.Windows.Forms.TextBox
    Friend WithEvents txtManjak As System.Windows.Forms.TextBox
    Friend WithEvents txtVisak As System.Windows.Forms.TextBox
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents txtPZO As System.Windows.Forms.TextBox
    Friend WithEvents txtSpUsl As System.Windows.Forms.TextBox
    Friend WithEvents txtRasp As System.Windows.Forms.TextBox
    Friend WithEvents txtZaracTL As System.Windows.Forms.TextBox
    Friend WithEvents TextBox30 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox27 As System.Windows.Forms.TextBox
    Friend WithEvents txtNovo As System.Windows.Forms.TextBox
    Friend WithEvents TextBox50 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents textbox32 As System.Windows.Forms.TextBox
    Friend WithEvents textbox46 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtNakSpN As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TextBox29 As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents txtBrOtp As System.Windows.Forms.TextBox
    Friend WithEvents txtStanOtp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtKurs = New System.Windows.Forms.TextBox
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.txtBrOtp = New System.Windows.Forms.TextBox
        Me.txtStanOtp = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextBox17 = New System.Windows.Forms.TextBox
        Me.TextBox16 = New System.Windows.Forms.TextBox
        Me.TextBox15 = New System.Windows.Forms.TextBox
        Me.txtRMasa = New System.Windows.Forms.TextBox
        Me.TextBox13 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TextBox29 = New System.Windows.Forms.TextBox
        Me.TextBox19 = New System.Windows.Forms.TextBox
        Me.TextBox14 = New System.Windows.Forms.TextBox
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox47 = New System.Windows.Forms.TextBox
        Me.textbox46 = New System.Windows.Forms.TextBox
        Me.TextBox45 = New System.Windows.Forms.TextBox
        Me.TextBox44 = New System.Windows.Forms.TextBox
        Me.txtManjak = New System.Windows.Forms.TextBox
        Me.TextBox42 = New System.Windows.Forms.TextBox
        Me.TextBox41 = New System.Windows.Forms.TextBox
        Me.txtVisak = New System.Windows.Forms.TextBox
        Me.TextBox39 = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.TextBox38 = New System.Windows.Forms.TextBox
        Me.txtTrGot = New System.Windows.Forms.TextBox
        Me.TextBox36 = New System.Windows.Forms.TextBox
        Me.TextBox35 = New System.Windows.Forms.TextBox
        Me.txtPred = New System.Windows.Forms.TextBox
        Me.TextBox33 = New System.Windows.Forms.TextBox
        Me.textbox32 = New System.Windows.Forms.TextBox
        Me.txtCP = New System.Windows.Forms.TextBox
        Me.TextBox30 = New System.Windows.Forms.TextBox
        Me.txtPZO = New System.Windows.Forms.TextBox
        Me.TextBox27 = New System.Windows.Forms.TextBox
        Me.TextBox26 = New System.Windows.Forms.TextBox
        Me.txtSpUsl = New System.Windows.Forms.TextBox
        Me.txtNakSpN = New System.Windows.Forms.TextBox
        Me.TextBox23 = New System.Windows.Forms.TextBox
        Me.txtRasp = New System.Windows.Forms.TextBox
        Me.txtNovo = New System.Windows.Forms.TextBox
        Me.TextBox20 = New System.Windows.Forms.TextBox
        Me.txtZaracTL = New System.Windows.Forms.TextBox
        Me.TextBox50 = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TextBox18 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Štampa izveštaj"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Broj predmeta:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Location = New System.Drawing.Point(136, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txtKurs)
        Me.GroupBox1.Controls.Add(Me.TextBox11)
        Me.GroupBox1.Controls.Add(Me.TextBox10)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextBox9)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextBox8)
        Me.GroupBox1.Controls.Add(Me.TextBox7)
        Me.GroupBox1.Controls.Add(Me.txtBrOtp)
        Me.GroupBox1.Controls.Add(Me.txtStanOtp)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 232)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "IDENTIFIKACIONI PODACI"
        '
        'txtKurs
        '
        Me.txtKurs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtKurs.Location = New System.Drawing.Point(328, 192)
        Me.txtKurs.Name = "txtKurs"
        Me.txtKurs.Size = New System.Drawing.Size(100, 22)
        Me.txtKurs.TabIndex = 20
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(112, 192)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(100, 22)
        Me.TextBox11.TabIndex = 19
        '
        'TextBox10
        '
        Me.TextBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(224, 152)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(136, 22)
        Me.TextBox10.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.Location = New System.Drawing.Point(224, 192)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Kurs:"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 23)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Valuta"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 152)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(216, 23)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Franko/Upuceno po tovarnom listu:"
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(488, 112)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(100, 22)
        Me.TextBox9.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label9.Location = New System.Drawing.Point(408, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 24)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Iznos KP:"
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(296, 112)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(100, 22)
        Me.TextBox8.TabIndex = 12
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(104, 112)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(100, 22)
        Me.TextBox7.TabIndex = 6
        Me.TextBox7.Text = "0"
        '
        'txtBrOtp
        '
        Me.txtBrOtp.BackColor = System.Drawing.SystemColors.Control
        Me.txtBrOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtBrOtp.Location = New System.Drawing.Point(411, 69)
        Me.txtBrOtp.Name = "txtBrOtp"
        Me.txtBrOtp.Size = New System.Drawing.Size(100, 22)
        Me.txtBrOtp.TabIndex = 5
        '
        'txtStanOtp
        '
        Me.txtStanOtp.BackColor = System.Drawing.SystemColors.Control
        Me.txtStanOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtStanOtp.Location = New System.Drawing.Point(140, 72)
        Me.txtStanOtp.Name = "txtStanOtp"
        Me.txtStanOtp.Size = New System.Drawing.Size(100, 22)
        Me.txtStanOtp.TabIndex = 4
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(272, 32)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(96, 22)
        Me.TextBox3.TabIndex = 3
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(176, 32)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(90, 22)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "0072"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Broj KP:"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(216, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 23)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Godina:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(280, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 23)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Broj otpravljanja:"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 23)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Otpravna stanica:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Uputna uprava / Stanica:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.GroupBox2.Controls.Add(Me.TextBox17)
        Me.GroupBox2.Controls.Add(Me.TextBox16)
        Me.GroupBox2.Controls.Add(Me.TextBox15)
        Me.GroupBox2.Controls.Add(Me.txtRMasa)
        Me.GroupBox2.Controls.Add(Me.TextBox13)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(632, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 232)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OPIS          Novo stanje"
        '
        'TextBox17
        '
        Me.TextBox17.Location = New System.Drawing.Point(232, 200)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(100, 22)
        Me.TextBox17.TabIndex = 9
        Me.TextBox17.Text = "0"
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(232, 160)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(100, 22)
        Me.TextBox16.TabIndex = 8
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(232, 120)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(100, 22)
        Me.TextBox15.TabIndex = 7
        '
        'txtRMasa
        '
        Me.txtRMasa.Location = New System.Drawing.Point(232, 80)
        Me.txtRMasa.Name = "txtRMasa"
        Me.txtRMasa.Size = New System.Drawing.Size(100, 22)
        Me.txtRMasa.TabIndex = 6
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(232, 40)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(100, 22)
        Me.TextBox13.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 200)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 23)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Povlastica u %:"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 160)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 23)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Prevozni stav:"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 23)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Tarifski razred:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(208, 23)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Racunska težina:"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(208, 23)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Ukupno kilometarsko rastojanje:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(136, 200)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "OPIS"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Salmon
        Me.GroupBox3.Controls.Add(Me.TextBox29)
        Me.GroupBox3.Controls.Add(Me.TextBox19)
        Me.GroupBox3.Controls.Add(Me.TextBox14)
        Me.GroupBox3.Controls.Add(Me.TextBox12)
        Me.GroupBox3.Controls.Add(Me.TextBox6)
        Me.GroupBox3.Controls.Add(Me.TextBox5)
        Me.GroupBox3.Controls.Add(Me.TextBox47)
        Me.GroupBox3.Controls.Add(Me.textbox46)
        Me.GroupBox3.Controls.Add(Me.TextBox45)
        Me.GroupBox3.Controls.Add(Me.TextBox44)
        Me.GroupBox3.Controls.Add(Me.txtManjak)
        Me.GroupBox3.Controls.Add(Me.TextBox42)
        Me.GroupBox3.Controls.Add(Me.TextBox41)
        Me.GroupBox3.Controls.Add(Me.txtVisak)
        Me.GroupBox3.Controls.Add(Me.TextBox39)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.TextBox38)
        Me.GroupBox3.Controls.Add(Me.txtTrGot)
        Me.GroupBox3.Controls.Add(Me.TextBox36)
        Me.GroupBox3.Controls.Add(Me.TextBox35)
        Me.GroupBox3.Controls.Add(Me.txtPred)
        Me.GroupBox3.Controls.Add(Me.TextBox33)
        Me.GroupBox3.Controls.Add(Me.textbox32)
        Me.GroupBox3.Controls.Add(Me.txtCP)
        Me.GroupBox3.Controls.Add(Me.TextBox30)
        Me.GroupBox3.Controls.Add(Me.txtPZO)
        Me.GroupBox3.Controls.Add(Me.TextBox27)
        Me.GroupBox3.Controls.Add(Me.TextBox26)
        Me.GroupBox3.Controls.Add(Me.txtSpUsl)
        Me.GroupBox3.Controls.Add(Me.txtNakSpN)
        Me.GroupBox3.Controls.Add(Me.TextBox23)
        Me.GroupBox3.Controls.Add(Me.txtRasp)
        Me.GroupBox3.Controls.Add(Me.txtNovo)
        Me.GroupBox3.Controls.Add(Me.TextBox20)
        Me.GroupBox3.Controls.Add(Me.txtZaracTL)
        Me.GroupBox3.Controls.Add(Me.TextBox50)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(40, 280)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(816, 368)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = resources.GetString("GroupBox3.Text")
        '
        'TextBox29
        '
        Me.TextBox29.Location = New System.Drawing.Point(664, 120)
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New System.Drawing.Size(104, 22)
        Me.TextBox29.TabIndex = 45
        '
        'TextBox19
        '
        Me.TextBox19.BackColor = System.Drawing.Color.Salmon
        Me.TextBox19.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox19.Location = New System.Drawing.Point(16, 304)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(24, 19)
        Me.TextBox19.TabIndex = 44
        Me.TextBox19.Text = "5."
        Me.TextBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox14
        '
        Me.TextBox14.BackColor = System.Drawing.Color.Salmon
        Me.TextBox14.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox14.Location = New System.Drawing.Point(16, 272)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(24, 19)
        Me.TextBox14.TabIndex = 43
        Me.TextBox14.Text = "4."
        Me.TextBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox12
        '
        Me.TextBox12.BackColor = System.Drawing.Color.Salmon
        Me.TextBox12.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(16, 240)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(24, 19)
        Me.TextBox12.TabIndex = 42
        Me.TextBox12.Text = "3."
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.Salmon
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(16, 56)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(24, 19)
        Me.TextBox6.TabIndex = 41
        Me.TextBox6.Text = "2."
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.Salmon
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(16, 32)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(24, 19)
        Me.TextBox5.TabIndex = 40
        Me.TextBox5.Text = "1."
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox47
        '
        Me.TextBox47.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox47.Location = New System.Drawing.Point(664, 312)
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Size = New System.Drawing.Size(104, 22)
        Me.TextBox47.TabIndex = 37
        Me.TextBox47.Text = "0.00"
        '
        'textbox46
        '
        Me.textbox46.BackColor = System.Drawing.SystemColors.Window
        Me.textbox46.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.textbox46.Location = New System.Drawing.Point(480, 312)
        Me.textbox46.Name = "textbox46"
        Me.textbox46.Size = New System.Drawing.Size(100, 22)
        Me.textbox46.TabIndex = 27
        '
        'TextBox45
        '
        Me.TextBox45.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox45.Location = New System.Drawing.Point(288, 312)
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.Size = New System.Drawing.Size(104, 22)
        Me.TextBox45.TabIndex = 17
        Me.TextBox45.Text = "0.00"
        '
        'TextBox44
        '
        Me.TextBox44.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox44.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox44.Location = New System.Drawing.Point(664, 280)
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.Size = New System.Drawing.Size(104, 22)
        Me.TextBox44.TabIndex = 36
        Me.TextBox44.Text = "0.00"
        '
        'txtManjak
        '
        Me.txtManjak.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtManjak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtManjak.Location = New System.Drawing.Point(480, 280)
        Me.txtManjak.Name = "txtManjak"
        Me.txtManjak.Size = New System.Drawing.Size(100, 22)
        Me.txtManjak.TabIndex = 26
        '
        'TextBox42
        '
        Me.TextBox42.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox42.Location = New System.Drawing.Point(288, 280)
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.Size = New System.Drawing.Size(104, 22)
        Me.TextBox42.TabIndex = 16
        Me.TextBox42.Text = "0.00"
        '
        'TextBox41
        '
        Me.TextBox41.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox41.Location = New System.Drawing.Point(664, 248)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Size = New System.Drawing.Size(104, 22)
        Me.TextBox41.TabIndex = 35
        Me.TextBox41.Text = "0.00"
        '
        'txtVisak
        '
        Me.txtVisak.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtVisak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtVisak.Location = New System.Drawing.Point(480, 248)
        Me.txtVisak.Name = "txtVisak"
        Me.txtVisak.Size = New System.Drawing.Size(100, 22)
        Me.txtVisak.TabIndex = 25
        '
        'TextBox39
        '
        Me.TextBox39.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox39.Location = New System.Drawing.Point(288, 248)
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.Size = New System.Drawing.Size(104, 22)
        Me.TextBox39.TabIndex = 15
        Me.TextBox39.Text = "0.00"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label27.Location = New System.Drawing.Point(48, 304)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(192, 23)
        Me.Label27.TabIndex = 30
        Me.Label27.Text = "Pripada ukupno (2+3- 4):"
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label26.Location = New System.Drawing.Point(48, 272)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(192, 23)
        Me.Label26.TabIndex = 29
        Me.Label26.Text = "Manjak:"
        '
        'TextBox38
        '
        Me.TextBox38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox38.Location = New System.Drawing.Point(664, 216)
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New System.Drawing.Size(104, 22)
        Me.TextBox38.TabIndex = 34
        '
        'txtTrGot
        '
        Me.txtTrGot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtTrGot.Location = New System.Drawing.Point(480, 216)
        Me.txtTrGot.Name = "txtTrGot"
        Me.txtTrGot.Size = New System.Drawing.Size(100, 22)
        Me.txtTrGot.TabIndex = 24
        '
        'TextBox36
        '
        Me.TextBox36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox36.Location = New System.Drawing.Point(288, 216)
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New System.Drawing.Size(104, 22)
        Me.TextBox36.TabIndex = 14
        '
        'TextBox35
        '
        Me.TextBox35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox35.Location = New System.Drawing.Point(664, 184)
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New System.Drawing.Size(104, 22)
        Me.TextBox35.TabIndex = 33
        '
        'txtPred
        '
        Me.txtPred.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtPred.Location = New System.Drawing.Point(480, 184)
        Me.txtPred.Name = "txtPred"
        Me.txtPred.Size = New System.Drawing.Size(100, 22)
        Me.txtPred.TabIndex = 23
        '
        'TextBox33
        '
        Me.TextBox33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox33.Location = New System.Drawing.Point(288, 184)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New System.Drawing.Size(104, 22)
        Me.TextBox33.TabIndex = 13
        '
        'textbox32
        '
        Me.textbox32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.textbox32.Location = New System.Drawing.Point(664, 152)
        Me.textbox32.Name = "textbox32"
        Me.textbox32.Size = New System.Drawing.Size(104, 22)
        Me.textbox32.TabIndex = 32
        '
        'txtCP
        '
        Me.txtCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtCP.Location = New System.Drawing.Point(480, 152)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(100, 22)
        Me.txtCP.TabIndex = 22
        '
        'TextBox30
        '
        Me.TextBox30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox30.Location = New System.Drawing.Point(288, 152)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New System.Drawing.Size(104, 22)
        Me.TextBox30.TabIndex = 12
        '
        'txtPZO
        '
        Me.txtPZO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtPZO.Location = New System.Drawing.Point(480, 120)
        Me.txtPZO.Name = "txtPZO"
        Me.txtPZO.Size = New System.Drawing.Size(100, 22)
        Me.txtPZO.TabIndex = 21
        '
        'TextBox27
        '
        Me.TextBox27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox27.Location = New System.Drawing.Point(288, 120)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New System.Drawing.Size(104, 22)
        Me.TextBox27.TabIndex = 11
        '
        'TextBox26
        '
        Me.TextBox26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox26.Location = New System.Drawing.Point(664, 88)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(104, 22)
        Me.TextBox26.TabIndex = 30
        Me.TextBox26.Text = "0.00"
        '
        'txtSpUsl
        '
        Me.txtSpUsl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtSpUsl.Location = New System.Drawing.Point(480, 88)
        Me.txtSpUsl.Name = "txtSpUsl"
        Me.txtSpUsl.Size = New System.Drawing.Size(100, 22)
        Me.txtSpUsl.TabIndex = 20
        '
        'txtNakSpN
        '
        Me.txtNakSpN.BackColor = System.Drawing.SystemColors.Control
        Me.txtNakSpN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtNakSpN.Location = New System.Drawing.Point(288, 88)
        Me.txtNakSpN.Name = "txtNakSpN"
        Me.txtNakSpN.Size = New System.Drawing.Size(104, 22)
        Me.txtNakSpN.TabIndex = 8
        Me.txtNakSpN.Text = "0.00"
        '
        'TextBox23
        '
        Me.TextBox23.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox23.Location = New System.Drawing.Point(664, 56)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(104, 22)
        Me.TextBox23.TabIndex = 29
        Me.TextBox23.Text = "0.00"
        '
        'txtRasp
        '
        Me.txtRasp.BackColor = System.Drawing.SystemColors.Window
        Me.txtRasp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtRasp.Location = New System.Drawing.Point(480, 56)
        Me.txtRasp.Name = "txtRasp"
        Me.txtRasp.Size = New System.Drawing.Size(100, 22)
        Me.txtRasp.TabIndex = 19
        '
        'txtNovo
        '
        Me.txtNovo.BackColor = System.Drawing.SystemColors.Control
        Me.txtNovo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtNovo.Location = New System.Drawing.Point(288, 56)
        Me.txtNovo.Name = "txtNovo"
        Me.txtNovo.Size = New System.Drawing.Size(104, 22)
        Me.txtNovo.TabIndex = 7
        Me.txtNovo.Text = "0.00"
        '
        'TextBox20
        '
        Me.TextBox20.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox20.Location = New System.Drawing.Point(664, 24)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(104, 22)
        Me.TextBox20.TabIndex = 28
        Me.TextBox20.Text = "0.00"
        '
        'txtZaracTL
        '
        Me.txtZaracTL.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtZaracTL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtZaracTL.Location = New System.Drawing.Point(480, 24)
        Me.txtZaracTL.Name = "txtZaracTL"
        Me.txtZaracTL.Size = New System.Drawing.Size(100, 22)
        Me.txtZaracTL.TabIndex = 18
        '
        'TextBox50
        '
        Me.TextBox50.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox50.Location = New System.Drawing.Point(288, 24)
        Me.TextBox50.Name = "TextBox50"
        Me.TextBox50.Size = New System.Drawing.Size(104, 22)
        Me.TextBox50.TabIndex = 6
        Me.TextBox50.Text = "0.00"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label25.Location = New System.Drawing.Point(48, 240)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(192, 23)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "Višak:"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label24.Location = New System.Drawing.Point(72, 216)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(216, 23)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "e) Troškovi u gotovom: "
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label23.Location = New System.Drawing.Point(72, 184)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(216, 23)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "d) Predujam"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label22.Location = New System.Drawing.Point(72, 152)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(216, 23)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "c) Cista prevoznina:"
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label21.Location = New System.Drawing.Point(72, 120)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(216, 23)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "b) Pocetno-završne operacije:"
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label20.Location = New System.Drawing.Point(72, 88)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(216, 23)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "a) Naknade za sporedne usluge:"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label19.Location = New System.Drawing.Point(48, 56)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(168, 23)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Rasporedjeno (a do e):"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label18.Location = New System.Drawing.Point(48, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(208, 24)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Zaracunato u tovarnom listu:"
        '
        'TextBox18
        '
        Me.TextBox18.Location = New System.Drawing.Point(256, 24)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(100, 20)
        Me.TextBox18.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(904, 560)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 32)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Štampaj"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(904, 608)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 32)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Otkaži"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(8, 40)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(136, 40)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "Štampa rekapitulacije"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(904, 504)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 40)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "Nova korekcija"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button8)
        Me.GroupBox4.Controls.Add(Me.Button7)
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Location = New System.Drawing.Point(864, 296)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(152, 192)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Rekapitulacija"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(8, 152)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(136, 23)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = "Pregled i brisanje korekcija"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(8, 104)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(136, 23)
        Me.Button7.TabIndex = 15
        Me.Button7.Text = "Briši prethodne korekcije"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(516, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "I Z V O Z"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1028, 725)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button6)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub txtBrPr_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBrOtp.Validating
        BrPred = TextBox1.Text
        a = txtStanOtp.Text
        OtpStan = "72" & a
        BrOtp = txtBrOtp.Text
        Visak = 0
        Manjak = 0
        ' Nadji u SlogKalk
        Dim intCounter0 As Integer
        Dim daNadji As SqlClient.SqlDataAdapter
        Dim dsNadji As New Data.DataSet
        Dim objComm0 As SqlClient.SqlCommand
        'Dim rv As String

        Upit0 = "SELECT RecID, OtpUprava, OtpStanica, OtpBroj, PrUprava, PrStanica, PrBroj, PrDatum, ObrGodina, Ugovor, TkmZS, rSumaFrDin,  " & _
                "tlPrevUpDin, tlSumaFrDin, tlPrevFrDin, tlNakFrDin, tlValuta " & _
                "FROM SlogKalk " & _
                "WHERE OtpStanica='" & OtpStan & "' and OtpBroj='" & BrOtp & "'"
        objComm0 = New SqlClient.SqlCommand(Upit0, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daNadji = New SqlClient.SqlDataAdapter(Upit0, OkpDbVeza)
        daNadji.Fill(dsNadji)

        Try
            With dsNadji.Tables(0)
                RecID = .Rows(intCounter0).Item("RecID")
                PrUpr = .Rows(intCounter0).Item("PrUprava")
                PrStan = .Rows(intCounter0).Item("PrStanica")
                PrBroj = .Rows(intCounter0).Item("PrBroj")
                DatPr = .Rows(intCounter0).Item("PrDatum")
                Godina = .Rows(intCounter0).Item("ObrGodina")
                Ugovor = .Rows(intCounter0).Item("Ugovor")
                FrPoTL = .Rows(intCounter0).Item("tlPrevFrDin")
                UpPoTL = .Rows(intCounter0).Item("tlPrevUpDin")
                SumFrPoTL = .Rows(intCounter0).Item("tlSumaFrDin")
                Valuta = .Rows(intCounter0).Item("tlValuta")
                Tkm = .Rows(intCounter0).Item("TkmZS")
                NakFr = .Rows(intCounter0).Item("tlNakFrDin")
                RazlFr = .Rows(intCounter0).Item("rSumaFrDin")
            End With

        Catch ex As Exception
            MessageBox.Show("Uneti podaci ne odgovaraju onima u bazi.", "Prazna tabela!")


            txtStanOtp.Clear()
            txtBrOtp.Clear()
            txtVisak.Clear()
            txtManjak.Clear()
            'TextBox1.Clear()
            TextBox11.Clear()
            TextBox39.Text = 0
            TextBox42.Text = 0
            TextBox45.Text = 0
            TextBox23.Clear()
            TextBox9.Clear()
            TextBox29.Clear()
            textbox32.Clear()
            TextBox41.Clear()
            TextBox44.Clear()
            textbox46.Clear()
            TextBox47.Clear()
            TextBox20.Clear()
            TextBox23.Clear()
            TextBox26.Clear()
            TextBox35.Clear()
            TextBox38.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox10.Clear()
            TextBox8.Clear()
            TextBox13.Clear()
            TextBox15.Clear()
            TextBox16.Clear()
            TextBox50.Clear()
            txtNakSpN.Clear()
            TextBox27.Text = 0
            TextBox30.Text = 0
            TextBox33.Text = 0
            TextBox36.Text = 0
            txtKurs.Clear()
            txtRMasa.Clear()
            txtZaracTL.Clear()
            txtNovo.Clear()
            txtNovo.Text = 0
            txtRasp.Clear()
            txtSpUsl.Clear()
            txtPZO.Clear()
            txtCP.Clear()
            txtPred.Clear()
            txtTrGot.Clear()


        Finally
        End Try
       
            ' Nadji u ZSKursevi
            Dim intCounter3 As Integer
            Dim daNadjiK As SqlClient.SqlDataAdapter
            Dim dsNadjiK As New Data.DataSet
            Dim objComm3 As SqlClient.SqlCommand

            If Ugovor = "200379" Then
                Vrsta = 3
            Else
                Vrsta = 1
            End If

            TextBox11.Text = SifVal

            Dim MM As String
            Dim DD As String
            DD = Microsoft.VisualBasic.Left(DatPr, 2)
            MM = Microsoft.VisualBasic.Mid(DatPr, 4, 2)

            Dim dat As String
            dat = Trim(DatPr)

            Upit3 = "SELECT Sifra, DatumOd, DatumDo, Vrednost, Vrsta " & _
                    "FROM ZsKursevi " & _
            "WHERE Sifra='" & SifVal & "' "
            objComm3 = New SqlClient.SqlCommand(Upit3, OkpDbVeza)
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            daNadjiK = New SqlClient.SqlDataAdapter(Upit3, OkpDbVeza)
            daNadjiK.Fill(dsNadjiK)

            With dsNadjiK.Tables(0)
                For intCounter3 = 0 To .Rows.Count - 1
                    Kurs = .Rows(intCounter3).Item("Vrednost")
                    DatumOd = .Rows(intCounter3).Item("DatumOd")
                    DatumDo = .Rows(intCounter3).Item("DatumDo")
                    kVrsta = .Rows(intCounter3).Item("Vrsta")

                    If Vrsta = kVrsta And DatPr >= DatumOd And DatPr <= DatumDo Then
                        txtKurs.Text = Kurs
                        Exit For
                    End If
                Next
            End With

            'Nalazi u SlogNaknade 
            Dim intCounter2 As Integer
            Dim daNadjiNak As SqlClient.SqlDataAdapter
            Dim dsNadjiNak As New Data.DataSet
            Dim objComm2 As SqlClient.SqlCommand

            Upit2 = "SELECT SifraNaknade, Iznos, Valuta " & _
                    "FROM SlogNaknada " & _
                    "WHERE RecID='" & RecID & "' "
            objComm2 = New SqlClient.SqlCommand(Upit2, OkpDbVeza)
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            daNadjiNak = New SqlClient.SqlDataAdapter(Upit2, OkpDbVeza)
            daNadjiNak.Fill(dsNadjiNak)
            With dsNadjiNak.Tables(0)
                j = 0
                For intCounter2 = 0 To .Rows.Count - 1
                    SifNak = .Rows(intCounter2).Item("SifraNaknade")
                    Iznos = .Rows(intCounter2).Item("Iznos")
                    Valuta = .Rows(intCounter2).Item("Valuta")

                    If SifNak = 98 Then
                        txtPred.Text = Iznos * Kurs
                        j = 1
                        Exit For
                    ElseIf SifNak = 99 Then
                        txtTrGot.Text = Iznos * Kurs
                        j = 1
                        Exit For
                    End If
                Next
                If j = 0 Then
                    txtPred.Text = 0
                    txtTrGot.Text = 0
                End If
            End With

            TextBox2.Text = OtpUpr
            TextBox3.Text = OtpStan
            TextBox8.Text = Godina
            TextBox10.Text = SumFrPoTL + RazlFr
            TextBox11.Text = Valuta
            TextBox13.Text = Tkm
            txtNakSpN.Text = NakFr
            RaspN = UpPoTL + NakFr

            'TextBox50.Text = SumFrPoTL + RazlFr
            txtPred.Text = Pred
            TextBox33.Text = PredN
            txtTrGot.Text = TrGot
            TextBox36.Text = TrGotN

            txtZaracTL.Text = SumFrPoTL + RazlFr
            ZaracTL = txtZaracTL.Text
            'ZaracTLN = txtZaracTL.Text
            txtSpUsl.Text = NakFr
            PZO = FrPoTL * 0.18
            bZaokruziNaDeseteNavise(PZO)
            txtPZO.Text = PZO
            'txtRasp.Text = NakUp + PZO + CP
            Rasp = SumFrPoTL
            txtRasp.Text = Rasp
            'Rasp = txtRasp.Text
            tlStari = txtRasp.Text
            CP = Rasp - PZO - NakFr
            txtCP.Text = CP
            TextBox33.Text = PredN
            If txtRasp.Text - txtZaracTL.Text > 0 Then
                If RazlFr < 0 Then
                    Manjak = RazlFr * -1
                End If

            Else
                If RazlFr > 0 Then
                    Visak = RazlFr
                End If

            End If
            txtManjak.Text = Manjak
            txtVisak.Text = Visak

            'podaci iz sloga Roba
            Dim RMasa As Integer
            Dim kRMasa As Integer = 0
            Dim Razred As Int16
            Dim VozStav As Decimal
            Dim i As Int16 = 0

            Dim intCounter1 As Integer
            Dim daNadjiRoba As SqlClient.SqlDataAdapter
            Dim dsNadjiRoba As New Data.DataSet
            Dim objComm1 As SqlClient.SqlCommand

            Upit1 = "SELECT RMasa, NHMRazred, VozStav, RobaStavka " & _
                    "FROM SlogRoba " & _
                    "WHERE RecID='" & RecID & "' "
            objComm1 = New SqlClient.SqlCommand(Upit1, OkpDbVeza)
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            daNadjiRoba = New SqlClient.SqlDataAdapter(Upit1, OkpDbVeza)
            daNadjiRoba.Fill(dsNadjiRoba)
            With dsNadjiRoba.Tables(0)
                i = 0
                For intCounter1 = 0 To .Rows.Count - 1
                    RMasa = .Rows(intCounter1).Item("RMasa")
                    Razred = .Rows(intCounter1).Item("NHMRazred")
                    VozStav = .Rows(intCounter1).Item("VozStav")
                Next
                TextBox15.Text = Razred
                TextBox16.Text = VozStav

                kRMasa = kRMasa + RMasa
                txtRMasa.Text = RMasa

        End With
        If ZaracTL = 0.0 Then
            txtStanOtp.Focus()
        Else
            TextBox7.Focus()
        End If

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click

        Dim FIzv As New Form2
        Dim CRIzv As New kcizv ' kkkorekc3
        FIzv.CrystalReportViewer1.ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String 'parametar koji se odnosi na stanicu prispeæa
        Dim param2 As String 'parametar koji se odnosi na broj prispeæa
        Dim param3 As Decimal 'parametar koji se odnosi na korkciju (iznos u din)
        Dim param4 As Decimal 'parametar koji se odnosi na korkciju (iznos u din)
        Dim param5 As Decimal 'parametar koji se odnosi na korkciju (iznos u din)
        Dim param6 As String 'parametar koji se odnosi na broj predmeta
        Dim param7 As String 'parametar koji se odnosi na stanicu prispeæa
        Dim param8 As String 'parametar koji se odnosi na korisnika

        param1 = PrStan
        param2 = PrBroj
        param3 = CType(txtNovo.Text, Decimal)
        param4 = CType(txtNakSpN.Text, Decimal)
        param5 = CType(txtKurs.Text, Decimal)
        param6 = BrPred
        param7 = BrKP
        param8 = UkBr

        Try
            FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.PrStanica}=('" & PrStan & "') and {SlogKalk.PrBroj}= " & PrBroj & " and {SlogRoba.KolaStavka}= " & UkBr & ""
            'param1 = OtpStan
            'param2 = BrOtp
            'param3 = CType(txtNovo.Text, Decimal)
            'param4 = CType(txtNakSpN.Text, Decimal)
            'param5 = CType(txtKurs.Text, Decimal)
            'param6 = BrPred
            'param7 = BrKP
            'param8 = UkBr

            'Try
            '    FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.OtpStanica}=('" & OtpStan & "') and {SlogKalk.OtpBroj}= " & BrOtp & " and {SlogRoba.KolaStavka}= " & UkBr & ""

            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            CRIzv.SetParameterValue(2, param3)
            CRIzv.SetParameterValue(3, param4)
            CRIzv.SetParameterValue(4, param5)
            CRIzv.SetParameterValue(5, param6)
            CRIzv.SetParameterValue(6, param7)

            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'txtStanOtp.Clear()
        'txtBrOtp.Clear()
        txtVisak.Clear()
        txtManjak.Clear()
        'TextBox1.Clear()
        'TextBox11.Clear()
        TextBox39.Text = 0
        TextBox42.Text = 0
        TextBox45.Text = 0
        TextBox23.Clear()
        'TextBox9.Clear()
        TextBox29.Clear()
        textbox32.Clear()
        TextBox41.Clear()
        TextBox44.Clear()
        textbox46.Clear()
        TextBox47.Clear()
        TextBox20.Clear()
        TextBox23.Clear()
        TextBox26.Clear()
        TextBox35.Clear()
        TextBox38.Clear()
        'TextBox2.Clear()
        'TextBox3.Clear()
        TextBox10.Clear()
        TextBox8.Clear()
        TextBox13.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox50.Text = 0
        txtNakSpN.Text = 0
        TextBox27.Text = 0
        'TextBox7.Clear()
        TextBox30.Text = 0
        TextBox33.Text = 0
        TextBox36.Text = 0
        'txtKurs.Clear()
        txtRMasa.Clear()
        txtZaracTL.Clear()
        txtNovo.Clear()
        txtNovo.Text = 0
        txtRasp.Clear()
        txtSpUsl.Clear()
        txtPZO.Clear()
        txtCP.Clear()
        txtPred.Clear()
        txtTrGot.Clear()
        txtStanOtp.Focus()
    End Sub

    Private Sub txtBrPr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBrOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub txtStanPr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStanOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub txtNovo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNovo.KeyPress
        tlNovi = txtNovo.Text()
        If txtNovo.Text = "" Then
            tlNovi = 0
        End If
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub txtNovo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNovo.LostFocus
        tlNovi = txtNovo.Text
        If txtNovo.Text = "" Then
            tlNovi = 0
        End If
        tlNovi = CDec(tlNovi)
        txtNovo.Text = Format(tlNovi, "###,##0.00")
    End Sub

    Private Sub txtNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNovo.Click
        tlNovi = txtNovo.Text
        tlNovi = CDec(txtNovo.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Korisnik = mUserID
        Stanica = a
        RedBR = 1
        'UpisKorekcija(Korisnik, RedBR, Stanica, PrBroj, BrPred, Visak, VisakN, V, Manjak, ManjakN, M, PZORazl, CPRazl, Nak, TruGot, Preduj, Uk, PovVrednost)
        If PovVrednost > 0 Then
            MsgBox(PovVrednost)
        End If
        Dim FIzv As New Form2
        'Dim CRIzv As New korekcizv ' kkkorekc3
        Dim CRIzv As New kcizv
        FIzv.CrystalReportViewer1.ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String 'parametar koji se odnosi na stanicu prispeæa
        Dim param2 As String 'parametar koji se odnosi na broj prispeæa
        Dim param3 As Decimal 'parametar koji se odnosi na korkciju (iznos u din)
        Dim param4 As Decimal 'parametar koji se odnosi na korkciju (iznos u din)
        Dim param5 As Decimal 'parametar koji se odnosi na korkciju (iznos u din)
        Dim param6 As String 'parametar koji se odnosi na broj predmeta
        Dim param7 As String 'parametar koji se odnosi na stanicu prispeæa
        Dim param8 As String 'parametar koji se odnosi na korisnika
        Dim param9 As String 'parametar koji se odnosi na stanicu otp
        Dim param10 As String 'parametar koji se odnosi na br otp
        Dim param11 As Decimal 'parametar koji se odnosi na TlZarac (iznos u din)

        param1 = PrStan
        param2 = PrBroj
        param3 = CType(txtNovo.Text, Decimal)
        param4 = CType(txtNakSpN.Text, Decimal)
        param5 = CType(txtKurs.Text, Decimal)
        param6 = BrPred
        param7 = BrKP
        param8 = UkBr
        param9 = OtpStan
        param10 = BrOtp
        param11 = ZaracTLN

        Try
            'FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.PrStanica}=('" & PrStan & "') and {SlogKalk.PrBroj}= " & PrBroj & " and {SlogRoba.KolaStavka}= " & UkBr & " and {SlogKalk.OtpStanica}=('" & OtpStan & "')"
            FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.PrStanica}=('" & PrStan & "') and {SlogKalk.PrBroj}= " & PrBroj & " and {SlogRoba.KolaStavka}= " & UkBr & " and {SlogKalk.OtpStanica}=('" & OtpStan & "') and {SlogKalk.OtpBroj}=" & BrOtp & ""

            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            CRIzv.SetParameterValue(2, param3)
            CRIzv.SetParameterValue(3, param4)
            CRIzv.SetParameterValue(4, param5)
            CRIzv.SetParameterValue(5, param6)
            CRIzv.SetParameterValue(6, param7)
            CRIzv.SetParameterValue(7, param9)
            CRIzv.SetParameterValue(8, param10)
            CRIzv.SetParameterValue(9, param11)

            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub txtNakSpN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNakSpN.Validating
        TextBox39.Clear()
        TextBox42.Clear()
        ManjakN = 0
        VisakN = 0
        tlNovi = txtNovo.Text
        If txtNovo.Text = "" Then
            tlNovi = 0
        End If
        RaspN = tlNovi
        SpUslN = txtNakSpN.Text
        PZON = (tlNovi - SpUslN) * 0.18
        bZaokruziNaDeseteNavise(PZON)
        TextBox27.Text = PZON
        CPN = (tlNovi - SpUslN) * 0.82
        bZaokruziNaDeseteNavise(CPN)
        TextBox30.Text = CPN
        ZaracTLN = TextBox50.Text

        If tlNovi - ZaracTLN > 0 Then
            ManjakN = tlNovi - ZaracTLN
            'ManjakN = RaspN - UpPoTL + RazlUp
        Else
            VisakN = ZaracTLN - tlNovi
        End If
        If VisakN < 0 Then
            TextBox39.Text = VisakN * -1
        Else
            TextBox39.Text = VisakN
        End If
        If ManjakN < 0 Then
            TextBox42.Text = ManjakN * -1
        Else
            TextBox42.Text = ManjakN
        End If
        Novi = tlNovi + VisakN - ManjakN
        'TextBox45.Text = Novi
        TextBox45.Text = tlNovi + TextBox39.Text - TextBox42.Text
        TextBox23.Text = tlNovi - tlStari
        If Manjak <> 0 Then
            TextBox9.Text = Manjak
        Else : TextBox9.Text = Visak
        End If
        PZORazl = PZON - PZO
        TextBox29.Text = PZORazl
        CP = Rasp - PZO - NakFr
        CPRazl = CPN - CP
        textbox32.Text = CPRazl
        V = VisakN - Visak
        M = ManjakN - Manjak
        TextBox41.Text = V
        TextBox44.Text = M
        Stari = tlStari + Visak - Manjak
        textbox46.Text = Stari
        Uk = tlNovi - tlStari
        TextBox47.Text = Novi - Stari
        TextBox20.Text = ZaracTLN - ZaracTL
        TextBox23.Text = tlNovi - Rasp
        Nak = SpUslN - NakFr
        TextBox26.Text = Nak
        Preduj = PredN - Pred
        TextBox35.Text = Preduj
        TruGot = TrGotN - TrGot
        TextBox38.Text = TruGot

        ' dodavanje nula na kraju:
        ManjakN = TextBox42.Text
        ManjakN = CDec(ManjakN)
        TextBox42.Text = Format(ManjakN, "###,##0.00")

        Manjak = txtManjak.Text
        Manjak = CDec(Manjak)
        txtManjak.Text = Format(Manjak, "###,##0.00")

        VisakN = TextBox39.Text
        VisakN = CDec(VisakN)
        TextBox39.Text = Format(VisakN, "###,##0.00")

        Visak = txtVisak.Text
        Visak = CDec(Visak)
        txtVisak.Text = Format(Visak, "###,##0.00")

        Novi = TextBox45.Text
        Novi = CDec(Novi)
        TextBox45.Text = Format(Novi, "###,##0.00")

        CP = TextBox30.Text
        CP = CDec(CP)
        TextBox30.Text = Format(CP, "###,##0.00")

        PZON = TextBox27.Text
        PZON = CDec(PZON)
        TextBox27.Text = Format(PZON, "###,##0.00")

        CPN = txtCP.Text
        CPN = CDec(CPN)
        txtCP.Text = Format(CPN, "###,##0.00")

        PZO = txtPZO.Text
        PZO = CDec(PZO)
        txtPZO.Text = Format(PZO, "###,##0.00")

        Button1.Focus()
    End Sub

    Private Sub txtNakSpN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNakSpN.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub txtNakSpN_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNakSpN.LostFocus
        SpUslN = txtNakSpN.Text
        SpUslN = CDec(SpUslN)
        txtNakSpN.Text = Format(SpUslN, "###,##0.00")
    End Sub

    Private Sub TextBox50_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox50.LostFocus
        ZaracTLN = TextBox50.Text
        ZaracTLN = CDec(ZaracTLN)
        TextBox50.Text = Format(ZaracTLN, "###,##0.00")
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim RMasa As Integer
        Dim kRMasa As Integer
        Dim Razred As Int16
        Dim VozStav As Decimal
        Dim i As Int16 = 0

        RMasa = txtRMasa.Text
        Dim intCounter1 As Integer
        Dim daNadjiRoba As SqlClient.SqlDataAdapter
        Dim dsNadjiRoba As New Data.DataSet
        Dim objComm1 As SqlClient.SqlCommand

        Upit1 = "SELECT RMasa, NHMRazred, VozStav, RobaStavka " & _
                "FROM SlogRoba " & _
                "WHERE RecID='" & RecID & "' "
        objComm1 = New SqlClient.SqlCommand(Upit1, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daNadjiRoba = New SqlClient.SqlDataAdapter(Upit1, OkpDbVeza)
        daNadjiRoba.Fill(dsNadjiRoba)
        With dsNadjiRoba.Tables(0)
            i = 0
            For intCounter1 = 0 To .Rows.Count - 1
                kRMasa = .Rows(intCounter1).Item("RMasa")
                Razred = .Rows(intCounter1).Item("NHMRazred")
                VozStav = .Rows(intCounter1).Item("VozStav")

                If kRMasa = RMasa Then
                    i = 1
                    TextBox15.Text = Razred
                    TextBox16.Text = VozStav
                    Exit For
                End If
            Next
        End With
        txtNovo.Focus()
    End Sub

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        TextBox1.Focus()
        'txtStanPr.Focus()
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        txtStanOtp.Focus()
    End Sub

    Private Sub TextBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.Leave
        BrKP = TextBox7.Text
        TextBox50.Focus()
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''upis u bazu i izveštaj''
        'Korisnik = User
        'Stanica = a
        'RedBR = 1
        'UpisKorekcija(Korisnik, RedBR, Stanica, PrBroj, BrPred, Visak, VisakN, V, Manjak, ManjakN, M, PZORazl, CPRazl, Nak, TruGot, Preduj, Uk, PovVrednost)

        'If PovVrednost <> "" Then
        '    MsgBox(PovVrednost)
        'End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click


        Dim FIzv As New Form2
        Dim CRIzv As New RekIzv
        FIzv.CrystalReportViewer1.ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String 'parametar koji se odnosi na korisnika
        param1 = User

        Try
            'FIzv.CrystalReportViewer1.SelectionFormula = "{KorekcijaIzv.Korisnik}=('" & User & "')"
            FIzv.CrystalReportViewer1.SelectionFormula = "{KorekcijaIzv.Korisnik}=('" & User & " ')"

            CRIzv.SetParameterValue(0, param1)
            FIzv.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        txtBrOtp.Clear()
        txtVisak.Clear()
        txtManjak.Clear()
        TextBox1.Clear()
        TextBox11.Clear()
        TextBox39.Text = 0
        TextBox42.Text = 0
        TextBox45.Text = 0
        TextBox23.Clear()
        TextBox9.Clear()
        TextBox29.Clear()
        textbox32.Clear()
        TextBox41.Clear()
        TextBox44.Clear()
        textbox46.Clear()
        TextBox47.Clear()
        TextBox20.Clear()
        TextBox23.Clear()
        TextBox26.Clear()
        TextBox35.Clear()
        TextBox38.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox10.Clear()
        TextBox8.Clear()
        TextBox13.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox50.Text = 0
        txtNakSpN.Text = 0
        TextBox27.Text = 0
        TextBox30.Text = 0
        TextBox33.Text = 0
        TextBox36.Text = 0
        txtKurs.Clear()
        txtRMasa.Clear()
        txtZaracTL.Clear()
        txtNovo.Clear()
        txtNovo.Text = 0
        txtRasp.Clear()
        txtSpUsl.Clear()
        txtSpUsl.Text = 0
        txtPZO.Clear()
        txtCP.Clear()
        txtPred.Clear()
        txtTrGot.Clear()
        txtStanOtp.Clear()
        TextBox1.Focus()
        TextBox7.Text = 0
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim intCounterK As Integer
        Dim daKorisnik As SqlClient.SqlDataAdapter
        Dim dsKorisnik As New Data.DataSet
        Dim objCommK As SqlClient.SqlCommand
        ''
        Dim button As DialogResult
        button = MessageBox.Show _
        (" Da li ste sigurni da želite da izbrišete sve unete korekcije?", _
        "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If button = Windows.Forms.DialogResult.Yes Then

            UpitK = "Select * " & _
                    "FROM dbo.KorekcijaIzv "
            objCommK = New SqlClient.SqlCommand(UpitK, OkpDbVeza)
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            daKorisnik = New SqlClient.SqlDataAdapter(UpitK, OkpDbVeza)
            daKorisnik.Fill(dsKorisnik)
            With dsKorisnik.Tables(0)
                'i = 0
                For intCounterK = 0 To .Rows.Count - 1

                    Korisnik = .Rows(intCounterK).Item("Korisnik")
                    RedBR = .Rows(intCounterK).Item("RedBR")
                    Stanica = .Rows(intCounterK).Item("Stanica")
                    PrBroj = .Rows(intCounterK).Item("PrBroj")
                    BrPred = .Rows(intCounterK).Item("BrPred")
                    Visak = .Rows(intCounterK).Item("Visak")
                    VisakN = .Rows(intCounterK).Item("VisakN")
                    V = .Rows(intCounterK).Item("RazlVisak")
                    Manjak = .Rows(intCounterK).Item("Manjak")
                    ManjakN = .Rows(intCounterK).Item("Manjak")
                    M = .Rows(intCounterK).Item("RazlManj")
                    PZORazl = .Rows(intCounterK).Item("PZO")
                    CPRazl = .Rows(intCounterK).Item("CP")
                    Nak = .Rows(intCounterK).Item("Naknade")
                    Pred = .Rows(intCounterK).Item("Pred")
                    TruGot = .Rows(intCounterK).Item("TruGot")
                    Uk = .Rows(intCounterK).Item("Uk")

                    If Stanica = "" Or BrPred = "" Then
                        PovVrednost = "Podaci nisu potpuni. Brisanje nece biti izvršeno u potpunosti!"
                    End If
                    Korisnik = Microsoft.VisualBasic.Left(Korisnik, 4)
                    'Korisnik = LTrim(Korisnik)

                    If Korisnik = mUserID Then
                        'Stanica = 0
                        'Dim Brisi As DataRow = BrisiKorekcija(Korisnik)
                        Dim Brisi As DataRow = BrisiKorekcija(Korisnik, RetVal)
                        If RetVal <> "" Then
                            MsgBox(RetVal)
                        Else : MsgBox("Izbrisane su sve prethodne korekcije.")
                        End If
                    End If
                Next
            End With

            Me.Close()
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim Form1 As New Pregled
        'Form1.setInData(Pregl)
        Form1.ShowDialog()
    End Sub

    Private Sub TextBox50_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox50.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
End Class
