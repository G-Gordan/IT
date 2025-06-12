Imports System.Data.SqlClient
Public Class JCI
    Inherits System.Windows.Forms.Form
    Dim Carina As DataSet
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
    Friend WithEvents tbCarVal As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbCarinjenje As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents tbCarSifDoc As System.Windows.Forms.TextBox
    Friend WithEvents tbCarBrDoc As System.Windows.Forms.TextBox
    Friend WithEvents tbCarGodDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCarZemlja As System.Windows.Forms.Button
    Friend WithEvents tbCarZemlja As System.Windows.Forms.TextBox
    Friend WithEvents tbCarPrSediste As System.Windows.Forms.TextBox
    Friend WithEvents tbCarPrNaziv As System.Windows.Forms.TextBox
    Friend WithEvents tbPIB As System.Windows.Forms.TextBox
    Friend WithEvents fxFaktura As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnValuta As System.Windows.Forms.Button
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents btnCarStanica As System.Windows.Forms.Button
    Friend WithEvents gbStanica As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbKnjiga As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgCarina As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(JCI))
        Me.btnValuta = New System.Windows.Forms.Button
        Me.tbCarVal = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.btnCarStanica = New System.Windows.Forms.Button
        Me.tbCarinjenje = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnCarZemlja = New System.Windows.Forms.Button
        Me.tbCarZemlja = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbCarPrSediste = New System.Windows.Forms.TextBox
        Me.tbCarPrNaziv = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbPIB = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbCarSifDoc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbCarBrDoc = New System.Windows.Forms.TextBox
        Me.tbCarGodDoc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.fxFaktura = New FlxMaskBox.FlexMaskEditBox
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.gbStanica = New System.Windows.Forms.GroupBox
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbKnjiga = New System.Windows.Forms.TextBox
        Me.dgCarina = New System.Windows.Forms.DataGrid
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbStanica.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgCarina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnValuta
        '
        Me.btnValuta.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnValuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnValuta.Location = New System.Drawing.Point(252, 67)
        Me.btnValuta.Name = "btnValuta"
        Me.btnValuta.Size = New System.Drawing.Size(64, 23)
        Me.btnValuta.TabIndex = 1
        Me.btnValuta.Text = "Valuta"
        '
        'tbCarVal
        '
        Me.tbCarVal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCarVal.Enabled = False
        Me.tbCarVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarVal.Location = New System.Drawing.Point(324, 67)
        Me.tbCarVal.MaxLength = 5
        Me.tbCarVal.Name = "tbCarVal"
        Me.tbCarVal.Size = New System.Drawing.Size(64, 23)
        Me.tbCarVal.TabIndex = 4
        Me.tbCarVal.Text = ""
        Me.tbCarVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label24.Location = New System.Drawing.Point(12, 67)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(97, 20)
        Me.Label24.TabIndex = 50
        Me.Label24.Text = "Iznos iz fakture"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCarStanica
        '
        Me.btnCarStanica.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnCarStanica.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnCarStanica.Location = New System.Drawing.Point(24, 28)
        Me.btnCarStanica.Name = "btnCarStanica"
        Me.btnCarStanica.Size = New System.Drawing.Size(72, 23)
        Me.btnCarStanica.TabIndex = 0
        Me.btnCarStanica.Text = "Sifra"
        '
        'tbCarinjenje
        '
        Me.tbCarinjenje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarinjenje.Location = New System.Drawing.Point(112, 28)
        Me.tbCarinjenje.MaxLength = 5
        Me.tbCarinjenje.Name = "tbCarinjenje"
        Me.tbCarinjenje.Size = New System.Drawing.Size(115, 23)
        Me.tbCarinjenje.TabIndex = 2
        Me.tbCarinjenje.Text = ""
        Me.tbCarinjenje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCarZemlja)
        Me.GroupBox3.Controls.Add(Me.tbCarZemlja)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.tbCarPrSediste)
        Me.GroupBox3.Controls.Add(Me.tbCarPrNaziv)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.tbPIB)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(40, 257)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(392, 192)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "[ Primalac ] "
        '
        'btnCarZemlja
        '
        Me.btnCarZemlja.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnCarZemlja.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnCarZemlja.Location = New System.Drawing.Point(24, 152)
        Me.btnCarZemlja.Name = "btnCarZemlja"
        Me.btnCarZemlja.Size = New System.Drawing.Size(80, 23)
        Me.btnCarZemlja.TabIndex = 2
        Me.btnCarZemlja.Text = "Zemlja"
        '
        'tbCarZemlja
        '
        Me.tbCarZemlja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCarZemlja.Enabled = False
        Me.tbCarZemlja.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarZemlja.Location = New System.Drawing.Point(128, 152)
        Me.tbCarZemlja.MaxLength = 10
        Me.tbCarZemlja.Name = "tbCarZemlja"
        Me.tbCarZemlja.Size = New System.Drawing.Size(64, 23)
        Me.tbCarZemlja.TabIndex = 3
        Me.tbCarZemlja.Text = ""
        Me.tbCarZemlja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Sediste i adresa"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbCarPrSediste
        '
        Me.tbCarPrSediste.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCarPrSediste.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarPrSediste.Location = New System.Drawing.Point(128, 112)
        Me.tbCarPrSediste.MaxLength = 30
        Me.tbCarPrSediste.Name = "tbCarPrSediste"
        Me.tbCarPrSediste.Size = New System.Drawing.Size(248, 23)
        Me.tbCarPrSediste.TabIndex = 1
        Me.tbCarPrSediste.Text = ""
        '
        'tbCarPrNaziv
        '
        Me.tbCarPrNaziv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbCarPrNaziv.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarPrNaziv.Location = New System.Drawing.Point(128, 71)
        Me.tbCarPrNaziv.MaxLength = 30
        Me.tbCarPrNaziv.Name = "tbCarPrNaziv"
        Me.tbCarPrNaziv.Size = New System.Drawing.Size(248, 23)
        Me.tbCarPrNaziv.TabIndex = 0
        Me.tbCarPrNaziv.Text = ""
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Naziv"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbPIB
        '
        Me.tbPIB.Enabled = False
        Me.tbPIB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPIB.Location = New System.Drawing.Point(128, 32)
        Me.tbPIB.MaxLength = 10
        Me.tbPIB.Name = "tbPIB"
        Me.tbPIB.Size = New System.Drawing.Size(128, 23)
        Me.tbPIB.TabIndex = 62
        Me.tbPIB.Text = ""
        Me.tbPIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "PIB"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbCarSifDoc
        '
        Me.tbCarSifDoc.Enabled = False
        Me.tbCarSifDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarSifDoc.Location = New System.Drawing.Point(21, 32)
        Me.tbCarSifDoc.MaxLength = 5
        Me.tbCarSifDoc.Name = "tbCarSifDoc"
        Me.tbCarSifDoc.Size = New System.Drawing.Size(208, 23)
        Me.tbCarSifDoc.TabIndex = 3
        Me.tbCarSifDoc.Text = "(O05)"
        Me.tbCarSifDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Broj fakture"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbCarBrDoc
        '
        Me.tbCarBrDoc.Enabled = False
        Me.tbCarBrDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarBrDoc.Location = New System.Drawing.Point(112, 104)
        Me.tbCarBrDoc.MaxLength = 10
        Me.tbCarBrDoc.Name = "tbCarBrDoc"
        Me.tbCarBrDoc.Size = New System.Drawing.Size(117, 23)
        Me.tbCarBrDoc.TabIndex = 2
        Me.tbCarBrDoc.Text = ""
        Me.tbCarBrDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbCarGodDoc
        '
        Me.tbCarGodDoc.Enabled = False
        Me.tbCarGodDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarGodDoc.Location = New System.Drawing.Point(112, 144)
        Me.tbCarGodDoc.MaxLength = 4
        Me.tbCarGodDoc.Name = "tbCarGodDoc"
        Me.tbCarGodDoc.Size = New System.Drawing.Size(117, 23)
        Me.tbCarGodDoc.TabIndex = 3
        Me.tbCarGodDoc.Text = ""
        Me.tbCarGodDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Godina"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbCarSifDoc)
        Me.GroupBox2.Controls.Add(Me.tbCarGodDoc)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.tbCarBrDoc)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.fxFaktura)
        Me.GroupBox2.Controls.Add(Me.btnValuta)
        Me.GroupBox2.Controls.Add(Me.tbCarVal)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(440, 257)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 192)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ Prilozene isprave i dodatne informacije ]"
        '
        'fxFaktura
        '
        Me.fxFaktura.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxFaktura.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxFaktura.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxFaktura.Location = New System.Drawing.Point(112, 67)
        Me.fxFaktura.Mask = "#########9d##"
        Me.fxFaktura.Name = "fxFaktura"
        Me.fxFaktura.Size = New System.Drawing.Size(117, 23)
        Me.fxFaktura.TabIndex = 0
        Me.fxFaktura.Text = "0.00"
        Me.fxFaktura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(760, 456)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 5
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(656, 456)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 4
        Me.btnPrihvati.Text = "Prihvati  [ F12 ]"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(334, 49)
        Me.Label1.TabIndex = 1
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(40, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(392, 208)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 68
        Me.PictureBox1.TabStop = False
        '
        'gbStanica
        '
        Me.gbStanica.Controls.Add(Me.btnCarStanica)
        Me.gbStanica.Controls.Add(Me.tbCarinjenje)
        Me.gbStanica.Controls.Add(Me.Label1)
        Me.gbStanica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbStanica.Location = New System.Drawing.Point(440, 136)
        Me.gbStanica.Name = "gbStanica"
        Me.gbStanica.Size = New System.Drawing.Size(408, 120)
        Me.gbStanica.TabIndex = 1
        Me.gbStanica.TabStop = False
        Me.gbStanica.Text = " [ Odredišna carinarnica ] "
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.SystemColors.Control
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ListBox2.ForeColor = System.Drawing.Color.DimGray
        Me.ListBox2.ItemHeight = 16
        Me.ListBox2.Items.AddRange(New Object() {"" & Microsoft.VisualBasic.ChrW(9) & "    Popunjavanje podataka potrebnih za obavljanje", " procedure elektronskog podnosenja carinske deklaracije JCI."})
        Me.ListBox2.Location = New System.Drawing.Point(49, 8)
        Me.ListBox2.MultiColumn = True
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(378, 32)
        Me.ListBox2.TabIndex = 71
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbKnjiga)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(440, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 93)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Broj popisne knjige] "
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 16)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Broj"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbKnjiga
        '
        Me.tbKnjiga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbKnjiga.Location = New System.Drawing.Point(112, 27)
        Me.tbKnjiga.MaxLength = 5
        Me.tbKnjiga.Name = "tbKnjiga"
        Me.tbKnjiga.Size = New System.Drawing.Size(115, 23)
        Me.tbKnjiga.TabIndex = 3
        Me.tbKnjiga.Text = "0"
        Me.tbKnjiga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgCarina
        '
        Me.dgCarina.BackgroundColor = System.Drawing.Color.White
        Me.dgCarina.CaptionBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.dgCarina.CaptionText = "PORUKE O GRESKAMA"
        Me.dgCarina.DataMember = ""
        Me.dgCarina.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgCarina.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.dgCarina.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCarina.Location = New System.Drawing.Point(0, 530)
        Me.dgCarina.Name = "dgCarina"
        Me.dgCarina.PreferredColumnWidth = 300
        Me.dgCarina.PreferredRowHeight = 10
        Me.dgCarina.Size = New System.Drawing.Size(946, 88)
        Me.dgCarina.TabIndex = 72
        Me.dgCarina.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'JCI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(946, 618)
        Me.Controls.Add(Me.dgCarina)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbStanica)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "JCI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "eJCI > JP Zeleznice Srbije - PIB br. 103859991"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.gbStanica.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgCarina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim _Kontrola_Carina As Int16 = 0
        Dim _Poruka As String = ""

        '-------------------------------------------- Kontrola forme ----------------------------------------
        If Me.tbKnjiga.Text = Nothing Then
            _Poruka = "Nije unet broj iz popisne knjige; " & Chr(13)
        End If
        If Me.tbCarinjenje.Text = Nothing Then
            _Poruka = _Poruka & "Nije uneta sifra carinarnice; " & Chr(13)
        End If
        If Me.tbCarPrNaziv.Text = Nothing Then
            _Poruka = _Poruka & "Nije unet naziv primaoca; " & Chr(13)
        Else
            If Len(tbCarPrNaziv.Text) < 5 Then
                _Poruka = _Poruka & "Naziv primaoca ne moze biti kraci od 5 karaktera; " & Chr(13)
            End If
        End If
        If Me.tbCarPrSediste.Text = Nothing Then
            _Poruka = _Poruka & "Nije uneto sediste primaoca; " & Chr(13)
        Else
            If Len(tbCarPrSediste.Text) < 5 Then
                _Poruka = _Poruka & "Sediste primaoca ne moze biti krace od 5 karaktera; " & Chr(13)
            End If

        End If
        If Me.tbCarZemlja.Text = Nothing Then
            _Poruka = _Poruka & "Nije izabrana zemlja primaoca; " & Chr(13)
        End If
        If Len(tbCarSifDoc.Text) < 5 Then
            _Poruka = _Poruka & "Nije regularno obavljen unos; " & Chr(13)
        End If
        If CType(fxFaktura.Text, Decimal) > 1.0 Then
            If Me.tbCarBrDoc.Text = Nothing Then
                _Poruka = _Poruka & "Nije unet broj fakture; " & Chr(13)
            End If
            If Me.tbCarVal.Text = Nothing Then
                _Poruka = _Poruka & "Nije izabrana valuta fakture; " & Chr(13)
            End If
            If tbCarGodDoc.Text = Nothing Then
                _Poruka = _Poruka & "Nije uneta godina fakture; " & Chr(13)
            Else
                If IsNumeric(tbCarGodDoc.Text) = True Then
                    If CType(tbCarGodDoc.Text, Int32) < 2006 Then
                        _Poruka = _Poruka & "Nije uneta ispravna godina fakture; " & Chr(13)
                    End If
                Else
                    _Poruka = _Poruka & "Neispravan unos godine fakture; " & Chr(13)
                End If
            End If
        Else
            If CType(fxFaktura.Text, Decimal) = 0 Then
                _Poruka = _Poruka & "Iznos po fakturi ne moze da bude nula!; " & Chr(13)
            End If
        End If

        ''''''''''''''
        'If CType(fxFaktura.Text, Decimal) = 1.0 Then
        '    mCarDoc = "(O01)/(F01) NEMA FAKTURE"
        'ElseIf CType(fxFaktura.Text, Decimal) > 1.0 Then
        '    mCarDoc = "(O01)/(F01)(" & tbCarBrDoc.Text & " ) (" & tbCarGodDoc.Text & " )"
        'End If
        ''''''''''''''

        If _Poruka = Nothing Then
            mCarKnjiga = tbKnjiga.Text
            mCarDoc = tbCarSifDoc.Text
            mCarStanica = tbCarinjenje.Text
            mCarValuta = tbCarVal.Text
            mCarFaktura = fxFaktura.Text
            mCarBrDoc = tbCarBrDoc.Text
            mCarPrPIB = tbPIB.Text
            mCarPrNaziv = tbCarPrNaziv.Text
            mCarPrSediste = tbCarPrSediste.Text
            mCarPrZemlja = tbCarZemlja.Text
            Me.Close()
        Else
            MsgBox(_Poruka, MsgBoxStyle.Critical, "Poruka o greskama")
            tbKnjiga.Focus()
        End If
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        mCarKnjiga = " "
        mCarDoc = " "
        mCarStanica = " "
        mCarValuta = " "
        mCarFaktura = 0
        mCarPrPIB = " "
        'mCarPrNaziv = " "
        mCarPrSediste = " "
        mCarPrZemlja = " "
        Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim helpCarDoc As New HelpForm
        helpCarDoc.Text = "help dokumenti"
        upit = "CARDOC"
        helpCarDoc.ShowDialog()
        Me.tbCarSifDoc.Text = mIzlaz1
        'Label1.Text = mIzlaz2
        tbCarBrDoc.Focus()
    End Sub

    Private Sub JCI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatCarinaGrid()

        '------------- load ----------------
        tbKnjiga.Text = mCarKnjiga
        tbCarSifDoc.Text = mCarDoc
        tbCarinjenje.Text = mCarStanica
        tbCarVal.Text = mCarValuta
        fxFaktura.Text = mCarFaktura
        tbCarBrDoc.Text = mCarBrDoc
        tbPIB.Text = mCarPrPIB
        tbCarPrNaziv.Text = mCarPrNaziv
        tbCarPrSediste.Text = mCarPrSediste
        If IzborSaobracaja = "2" Then
            mCarPrZemlja = "RS"
            tbCarZemlja.Text = mCarPrZemlja
        Else
            tbCarZemlja.Text = mCarPrZemlja
        End If

        '-----------------------------------
        tbCarGodDoc.Text = Today.Year

        If IzborSaobracaja = 2 Then ' Uvoz
            gbStanica.Enabled = True
            tbPIB.Text = "000913006"
        ElseIf IzborSaobracaja = 4 Then ' Tranzit
            gbStanica.Enabled = False
            tbPIB.Text = "000912000"

            '------------------ trazi carinsku sifru izlaznog prelaza -----------------------
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            Dim asql_trz1 As String = "SELECT dbo.ZsPrelazi.SifraCarina " _
                                   & "FROM dbo.ZsPrelazi " _
                                   & "WHERE (dbo.ZsPrelazi.SifraPrelaza = '" & mStanica2 & "') "

            Dim asql_commpr1 As New SqlClient.SqlCommand(asql_trz1, DbVeza)
            Dim ardrPrelaz1 As SqlClient.SqlDataReader
            Dim acombo_linija1 As String = ""

            Try
                ardrPrelaz1 = asql_commpr1.ExecuteReader(CommandBehavior.CloseConnection)
                Do While ardrPrelaz1.Read()
                    acombo_linija1 = ardrPrelaz1.GetString(0)
                Loop
                ardrPrelaz1.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Catch exsql As SqlException
                MsgBox(exsql.ToString)
            Finally
                tbCarinjenje.Text = acombo_linija1
            End Try
            DbVeza.Close()


            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            Dim asql_trz2 As String = "SELECT dbo.ZsCarinarnice.Naziv " _
                                   & "FROM dbo.ZsCarinarnice " _
                                   & "WHERE (dbo.ZsCarinarnice.Sifra = '" & acombo_linija1 & "') "

            Dim asql_commTrz2 As New SqlClient.SqlCommand(asql_trz2, DbVeza)
            Dim ardrPrelaz2 As SqlClient.SqlDataReader
            Dim acombo_linija2 As String = ""

            Try
                ardrPrelaz2 = asql_commTrz2.ExecuteReader(CommandBehavior.CloseConnection)
                Do While ardrPrelaz2.Read()
                    acombo_linija2 = ardrPrelaz2.GetString(0)
                Loop
                ardrPrelaz2.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Catch exsql As SqlException
                MsgBox(exsql.ToString)
            Finally
                Label1.Text = acombo_linija2
            End Try
            DbVeza.Close()
            '--------------------------------------------------------------------------------
        End If
        'tbKnjiga.Focus()
    End Sub
    Private Sub tbCarBrDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbCarBrDoc.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbCarGodDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbCarGodDoc.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub tbCarSifDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbCarSifDoc.Validating
        'If Me.tbCarSifDoc.Text = Nothing Then
        '    If dtCarina.Rows.Count > 0 Then
        '        Me.btnPrihvati.Focus()
        '    Else
        '        Me.tbCarSifDoc.Focus()
        '    End If
        'End If
    End Sub
    Private Sub tbCarVal_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        mCarFaktura = fxFaktura.Text
    End Sub

    Private Sub btncarZemlja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarZemlja.Click
        EventsActived = True
        'Dim helpCarDoc As New HelpForm
        'helpCarDoc.Text = "help dokumenti"
        upit = "CARZEM"
        'helpCarDoc.ShowDialog()
        'Me.tbCarZemlja.Text = mIzlaz1
        'Me.fxFaktura.Focus()
    End Sub

    Private Sub fxFaktura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxFaktura.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub fxFaktura_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fxFaktura.Validating
        If CType(fxFaktura.Text, Decimal) = 1.0 Then
            Label3.Enabled = False
            Label4.Enabled = False
            Me.tbCarBrDoc.Enabled = False
            Me.tbCarGodDoc.Enabled = False
            Me.tbCarVal.Text = "EUR"
            Me.tbCarBrDoc.Text = Nothing
            Me.tbCarGodDoc.Text = Nothing
            tbCarSifDoc.Text = "(O05)/(F01) NEMA FAKTURE"
            mCarDoc = tbCarSifDoc.Text
            ErrorProvider1.SetError(fxFaktura, "")
            btnPrihvati.Focus()
        ElseIf CType(fxFaktura.Text, Decimal) > 1.0 Then
            ErrorProvider1.SetError(fxFaktura, "")
            Label3.Enabled = True
            Label4.Enabled = True
            Me.tbCarBrDoc.Enabled = True
            Me.tbCarGodDoc.Enabled = True
            Me.tbCarVal.Text = "EUR"
            Me.tbCarBrDoc.Focus()
        ElseIf CType(fxFaktura.Text, Decimal) = 0 Then
            ErrorProvider1.SetError(fxFaktura, "Iznos po fakturi ne moze da bude nula!")
            fxFaktura.Focus()
        End If
    End Sub

    Private Sub tbCarGodDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbCarGodDoc.Validating
        If tbCarGodDoc.Text = Nothing Then
            ErrorProvider1.SetError(tbCarGodDoc, "Neispravan unos!")
            tbCarGodDoc.Focus()
        Else
            If IsNumeric(tbCarGodDoc.Text) = True And CType(tbCarGodDoc.Text, Int32) > 2005 Then
                If CType(fxFaktura.Text, Decimal) > 1.0 Then
                    tbCarSifDoc.Text = "(O05)/(F01)(" & tbCarBrDoc.Text & " ) (" & tbCarGodDoc.Text & " )"
                    ErrorProvider1.SetError(tbCarGodDoc, "")
                    Me.btnPrihvati.Focus()
                End If
            Else
                ErrorProvider1.SetError(tbCarGodDoc, "Neispravan unos!")
                tbCarGodDoc.Focus()
            End If
        End If
    End Sub

    Private Sub tbKnjiga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbKnjiga.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbCarPrNaziv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbCarPrNaziv.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbCarPrSediste_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbCarPrSediste.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbKnjiga_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbKnjiga.Validating
        If tbKnjiga.Text = Nothing Then
            ErrorProvider1.SetError(tbKnjiga, "Unesite broj iz popisne knjige!")
            tbKnjiga.Focus()
        Else
            ErrorProvider1.SetError(tbKnjiga, "")
        End If
    End Sub
    Private Sub tbKnjiga_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbKnjiga.KeyUp
        'If e.KeyCode = Keys.F1 Then
        '    Help.ShowPopup(tbKnjiga, "Unesite broj iz popisne knjige", New Point(GroupBox1.Right, Me.GroupBox1.Bottom))
        'End If
    End Sub
    Private Sub tbCarBrDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbCarBrDoc.Validating
        'If CType(fxFaktura.Text, Decimal) > 1 Then
        '    If tbCarBrDoc.Text = Nothing Then
        '        ErrorProvider1.SetError(tbCarBrDoc, "Obavezan unos broja fakture!")
        '        tbCarBrDoc.Focus()
        '    Else
        '        ErrorProvider1.SetError(tbCarBrDoc, "")
        '    End If
        'End If
    End Sub
    Private Sub tbCarinjenje_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbCarinjenje.Validating
        'If IzborSaobracaja = 2 Then
        '    If IsNumeric(tbCarinjenje.Text) = True Then
        '        ErrorProvider1.SetError(tbCarinjenje, "")
        '    Else
        '        ErrorProvider1.SetError(tbCarinjenje, "Neispravan unos!")
        '        tbCarinjenje.Focus()
        '    End If
        'End If
    End Sub

    Private Sub tbCarPrNaziv_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbCarPrNaziv.Validating
        If tbCarPrNaziv.Text = Nothing Then
            ErrorProvider1.SetError(tbCarPrNaziv, "Obavezan unos naziva primaoca!")
            tbCarPrNaziv.Focus()
        Else
            If Len(tbCarPrNaziv.Text) < 5 Then
                ErrorProvider1.SetError(tbCarPrNaziv, "Naziv primaoca ne moze biti kraci od 5 karaktera!")
                tbCarPrNaziv.Focus()
            Else
                ErrorProvider1.SetError(tbCarPrNaziv, "")
            End If

        End If
    End Sub

    Private Sub tbCarPrSediste_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbCarPrSediste.Validating
        If tbCarPrSediste.Text = Nothing Then
            ErrorProvider1.SetError(tbCarPrSediste, "Obavezan unos sedista i adrese primaoca!")
            tbCarPrSediste.Focus()
        Else
            If Len(tbCarPrSediste.Text) < 5 Then
                ErrorProvider1.SetError(tbCarPrSediste, "Sediste primaoca ne moze biti krace od 5 karaktera!")
                tbCarPrSediste.Focus()
            Else
                ErrorProvider1.SetError(tbCarPrSediste, "")
                If IzborSaobracaja = "2" Then
                    fxFaktura.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub dgError_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgCarina.MouseUp
        Dim hitInfoCar As System.Windows.Forms.DataGrid.HitTestInfo
        Dim mc As String

        hitInfoCar = dgCarina.HitTest(e.X, e.Y)

        'Me.Label2.Text = String.Empty
        'Me.Label3.Text = String.Format("Row: {0}", hitInfo.Row)
        'Me.label4.Text = String.Format("Column: {0}", hitInfo.Column)
        'Me.label5.Text = String.Format("Type: {0}", hitInfo.Type.ToString())

        If hitInfoCar.Type = System.Windows.Forms.DataGrid.HitTestType.Cell Then
            Dim selCell As Object
            selCell = dgCarina.Item(hitInfoCar.Row, hitInfoCar.Column)
            If Not selCell Is Nothing Then
                mc = selCell.ToString()
            End If
        End If

        '------------- Akcija ----------------
        If mc = "Broj popisne knjige" Then
            tbKnjiga.Focus()
        ElseIf mc = "Sifra odredisne carinarnice" Then
            Me.tbCarinjenje.Focus()
        ElseIf mc = "Naziv primaoca" Then
            Me.tbCarPrNaziv.Focus()
        ElseIf mc = "Sediste i naziv primaoca" Then
            Me.tbCarPrSediste.Focus()
        ElseIf mc = "Zemlja primaoca" Then
            Me.tbCarZemlja.Focus()
        ElseIf mc = "Iznos iz fakture" Then
            Me.fxFaktura.Focus()
        ElseIf mc = "Broj fakture" Then
            Me.tbCarBrDoc.Focus()
        ElseIf mc = "Valuta fakture" Then
            Me.tbCarVal.Focus()
        ElseIf mc = "Godina fakture" Then
            Me.tbCarGodDoc.Focus()
        End If
        '-------------------------------------

    End Sub
    Private Sub FormatCarinaGrid()
        If Carina Is Nothing Then
            dgCarina.DataSource = dtCarina
        Else
            dgCarina.DataSource = Carina.Tables(0)
        End If
    End Sub

    Private Sub JCI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnPrihvati_Click(Me, Nothing)
        End If
    End Sub

    Private Sub JCI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If EventsActived = True Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                EventsActived = False
                If upit = "CARINA" Then
                    Dim helpCar As New HelpForm
                    helpCar.Text = "help carinarnice"
                    upit = "CARINA"
                    helpCar.ShowDialog()
                    Me.tbCarinjenje.Text = mIzlaz1
                    Label1.Text = mIzlaz2
                    tbCarPrNaziv.Focus()
                ElseIf upit = "CARZEM" Then
                    Dim helpCarDoc As New HelpForm
                    helpCarDoc.Text = "help dokumenti"
                    upit = "CARZEM"
                    helpCarDoc.ShowDialog()
                    Me.tbCarZemlja.Text = mIzlaz1
                    Me.fxFaktura.Focus()
                ElseIf upit = "CARVAL" Then
                    Dim helpCarVal As New HelpForm
                    helpCarVal.Text = "help Valute"
                    upit = "CARVAL"
                    helpCarVal.ShowDialog()
                    Me.tbCarVal.Text = mIzlaz1
                    Me.tbCarBrDoc.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub btnCarStanica_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCarStanica.MouseUp
        If EventsActived = True Then
            EventsActived = False

            Dim helpUic As New HelpForm
            helpUic.Text = "help carinarnice"
            upit = "CARINA"
            helpUic.ShowDialog()
            Me.tbCarinjenje.Text = mIzlaz1
            Label1.Text = mIzlaz2
            tbCarPrNaziv.Focus()
        End If
    End Sub

    Private Sub btnCarZemlja_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCarZemlja.MouseUp
        If EventsActived = True Then
            EventsActived = False

            Dim helpCarDoc As New HelpForm
            helpCarDoc.Text = "help dokumenti"
            upit = "CARZEM"
            helpCarDoc.ShowDialog()
            Me.tbCarZemlja.Text = mIzlaz1
            Me.fxFaktura.Focus()
        End If

    End Sub

    Private Sub btnValuta_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnValuta.MouseUp
        If EventsActived = True Then
            EventsActived = False

            Dim helpCarVal As New HelpForm
            helpCarVal.Text = "help Valute"
            upit = "CARVAL"
            helpCarVal.ShowDialog()

            Me.tbCarVal.Text = mIzlaz1
            Me.tbCarBrDoc.Focus()
        End If
    End Sub

    Private Sub btnValuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValuta.Click
        EventsActived = True
        upit = "CARVAL"
    End Sub

    Private Sub btnCarStanica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarStanica.Click
        EventsActived = True
        upit = "CARINA"
    End Sub
End Class
