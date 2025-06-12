Imports System.Data.SqlClient
Public Class kola
    Inherits System.Windows.Forms.Form
    Public GridIBK As String = ""
    Public dvKola As New DataView(dtKola)
    Public dvNhm As New DataView(dtNhm)
    Public mkBrojPokusaja As Int16 = 1
    Public LocalUPD_IBK As String
    Public tmp_nhm As String
    Public tmp_nhm_ok As String = "Yes"
    Public tmp_masa As String
    Public tmp_FromKola As Boolean = False 'true

#Region " Windows Form Designer generated code "

    Dim mTara

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
    Friend WithEvents tbRbrKola As System.Windows.Forms.TextBox
    Friend WithEvents chbNarocitaPosiljka As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgKola As System.Windows.Forms.DataGrid
    Friend WithEvents dgRoba As System.Windows.Forms.DataGrid
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnDodajKola As System.Windows.Forms.Button
    Friend WithEvents btnBrisiKola As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbTipUti As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents fxIBK As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbTara As System.Windows.Forms.TextBox
    Friend WithEvents chbStitnaKola As System.Windows.Forms.CheckBox
    Friend WithEvents tbKolaNaknada As System.Windows.Forms.TextBox
    Friend WithEvents tbNHM As System.Windows.Forms.TextBox
    Friend WithEvents tbMasa As System.Windows.Forms.TextBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents tbSumaKola As System.Windows.Forms.TextBox
    Friend WithEvents fxGranTov As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents btnDodajRobu As System.Windows.Forms.Button
    Friend WithEvents btnBrisiRobu As System.Windows.Forms.Button
    Friend WithEvents tbRazred As System.Windows.Forms.TextBox
    Friend WithEvents tbRazredRid As System.Windows.Forms.TextBox
    Friend WithEvents tbVlasnik As System.Windows.Forms.TextBox
    Friend WithEvents tbOsovine As System.Windows.Forms.TextBox
    Friend WithEvents tbVrsta As System.Windows.Forms.TextBox
    Friend WithEvents tbSerija As System.Windows.Forms.TextBox
    Friend WithEvents btnIzmeniKola As System.Windows.Forms.Button
    Friend WithEvents btnIzmeniRobu As System.Windows.Forms.Button
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbUtiIB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbUtiTara As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbPredajniList As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbUti As System.Windows.Forms.GroupBox
    Friend WithEvents tbUtiNHM As System.Windows.Forms.TextBox
    Friend WithEvents tbUtiPlombe As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents tbUprava As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbPrekoracenje As System.Windows.Forms.CheckBox
    Friend WithEvents lblKB As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblZSNP As System.Windows.Forms.Label
    Friend WithEvents lblNPUvecanje As System.Windows.Forms.Label
    Friend WithEvents lblNPUkupno As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(kola))
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbRbrKola = New System.Windows.Forms.TextBox
        Me.chbNarocitaPosiljka = New System.Windows.Forms.CheckBox
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbUprava = New System.Windows.Forms.TextBox
        Me.tbVlasnik = New System.Windows.Forms.TextBox
        Me.fxIBK = New FlxMaskBox.FlexMaskEditBox
        Me.lblKB = New System.Windows.Forms.Label
        Me.cbPrekoracenje = New System.Windows.Forms.CheckBox
        Me.tbRazredRid = New System.Windows.Forms.TextBox
        Me.tbRazred = New System.Windows.Forms.TextBox
        Me.tbNHM = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.gbUti = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbTipUti = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.tbUtiPlombe = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbPredajniList = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.tbUtiNHM = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbUtiTara = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbUtiIB = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbVrsta = New System.Windows.Forms.TextBox
        Me.tbOsovine = New System.Windows.Forms.TextBox
        Me.tbSerija = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.tbTara = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.chbStitnaKola = New System.Windows.Forms.CheckBox
        Me.btnBrisiKola = New System.Windows.Forms.Button
        Me.fxGranTov = New FlxMaskBox.FlexMaskEditBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.tbKolaNaknada = New System.Windows.Forms.TextBox
        Me.btnBrisiRobu = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbMasa = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnDodajKola = New System.Windows.Forms.Button
        Me.btnIzmeniKola = New System.Windows.Forms.Button
        Me.btnDodajRobu = New System.Windows.Forms.Button
        Me.btnIzmeniRobu = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.lblNPUvecanje = New System.Windows.Forms.Label
        Me.lblNPUkupno = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblZSNP = New System.Windows.Forms.Label
        Me.dgKola = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dgRoba = New System.Windows.Forms.DataGrid
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.tbSumaKola = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        Me.gbUti.SuspendLayout()
        CType(Me.dgKola, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgRoba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Ukupno unetih kola"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbRbrKola
        '
        Me.tbRbrKola.Enabled = False
        Me.tbRbrKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbRbrKola.Location = New System.Drawing.Point(160, 34)
        Me.tbRbrKola.MaxLength = 2
        Me.tbRbrKola.Name = "tbRbrKola"
        Me.tbRbrKola.Size = New System.Drawing.Size(32, 32)
        Me.tbRbrKola.TabIndex = 4
        Me.tbRbrKola.Text = ""
        Me.tbRbrKola.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNarocitaPosiljka
        '
        Me.chbNarocitaPosiljka.ContextMenu = Me.ContextMenu1
        Me.chbNarocitaPosiljka.Cursor = System.Windows.Forms.Cursors.Help
        Me.chbNarocitaPosiljka.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chbNarocitaPosiljka.ForeColor = System.Drawing.Color.Maroon
        Me.chbNarocitaPosiljka.Location = New System.Drawing.Point(432, 40)
        Me.chbNarocitaPosiljka.Name = "chbNarocitaPosiljka"
        Me.chbNarocitaPosiljka.Size = New System.Drawing.Size(136, 24)
        Me.chbNarocitaPosiljka.TabIndex = 9
        Me.chbNarocitaPosiljka.Text = "Narocita pošiljka"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Unesite podatke o narocitoj posiljci"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbUprava)
        Me.GroupBox1.Controls.Add(Me.tbVlasnik)
        Me.GroupBox1.Controls.Add(Me.fxIBK)
        Me.GroupBox1.Controls.Add(Me.lblKB)
        Me.GroupBox1.Controls.Add(Me.cbPrekoracenje)
        Me.GroupBox1.Controls.Add(Me.tbRazredRid)
        Me.GroupBox1.Controls.Add(Me.tbRazred)
        Me.GroupBox1.Controls.Add(Me.tbNHM)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.gbUti)
        Me.GroupBox1.Controls.Add(Me.tbVrsta)
        Me.GroupBox1.Controls.Add(Me.tbOsovine)
        Me.GroupBox1.Controls.Add(Me.tbSerija)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.tbTara)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.chbStitnaKola)
        Me.GroupBox1.Controls.Add(Me.btnBrisiKola)
        Me.GroupBox1.Controls.Add(Me.fxGranTov)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.tbKolaNaknada)
        Me.GroupBox1.Controls.Add(Me.btnBrisiRobu)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tbMasa)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.btnDodajKola)
        Me.GroupBox1.Controls.Add(Me.btnIzmeniKola)
        Me.GroupBox1.Controls.Add(Me.btnDodajRobu)
        Me.GroupBox1.Controls.Add(Me.btnIzmeniRobu)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 632)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'tbUprava
        '
        Me.tbUprava.Enabled = False
        Me.tbUprava.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUprava.Location = New System.Drawing.Point(280, 43)
        Me.tbUprava.MaxLength = 14
        Me.tbUprava.Name = "tbUprava"
        Me.tbUprava.Size = New System.Drawing.Size(97, 20)
        Me.tbUprava.TabIndex = 51
        Me.tbUprava.Text = ""
        Me.tbUprava.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbVlasnik
        '
        Me.tbVlasnik.Enabled = False
        Me.tbVlasnik.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbVlasnik.Location = New System.Drawing.Point(280, 21)
        Me.tbVlasnik.MaxLength = 1
        Me.tbVlasnik.Name = "tbVlasnik"
        Me.tbVlasnik.Size = New System.Drawing.Size(24, 20)
        Me.tbVlasnik.TabIndex = 37
        Me.tbVlasnik.Text = ""
        Me.tbVlasnik.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxIBK
        '
        Me.fxIBK.BackColor = System.Drawing.Color.White
        Me.fxIBK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxIBK.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxIBK.Location = New System.Drawing.Point(148, 21)
        Me.fxIBK.Mask = "99 99 9999 999 9"
        Me.fxIBK.Name = "fxIBK"
        Me.fxIBK.Size = New System.Drawing.Size(106, 23)
        Me.fxIBK.TabIndex = 0
        '
        'lblKB
        '
        Me.lblKB.Location = New System.Drawing.Point(256, 24)
        Me.lblKB.Name = "lblKB"
        Me.lblKB.Size = New System.Drawing.Size(24, 23)
        Me.lblKB.TabIndex = 53
        Me.lblKB.Text = "[  ]"
        Me.lblKB.Visible = False
        '
        'cbPrekoracenje
        '
        Me.cbPrekoracenje.Cursor = System.Windows.Forms.Cursors.NoMove2D
        Me.cbPrekoracenje.ForeColor = System.Drawing.Color.DarkRed
        Me.cbPrekoracenje.Location = New System.Drawing.Point(304, 238)
        Me.cbPrekoracenje.Name = "cbPrekoracenje"
        Me.cbPrekoracenje.Size = New System.Drawing.Size(96, 24)
        Me.cbPrekoracenje.TabIndex = 52
        Me.cbPrekoracenje.Text = "prekoracenje"
        '
        'tbRazredRid
        '
        Me.tbRazredRid.Enabled = False
        Me.tbRazredRid.Location = New System.Drawing.Point(324, 270)
        Me.tbRazredRid.Name = "tbRazredRid"
        Me.tbRazredRid.Size = New System.Drawing.Size(32, 21)
        Me.tbRazredRid.TabIndex = 48
        Me.tbRazredRid.Text = ""
        Me.tbRazredRid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbRazred
        '
        Me.tbRazred.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbRazred.Enabled = False
        Me.tbRazred.Location = New System.Drawing.Point(276, 270)
        Me.tbRazred.Name = "tbRazred"
        Me.tbRazred.Size = New System.Drawing.Size(32, 21)
        Me.tbRazred.TabIndex = 47
        Me.tbRazred.Text = ""
        Me.tbRazred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbNHM
        '
        Me.tbNHM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNHM.Location = New System.Drawing.Point(148, 270)
        Me.tbNHM.MaxLength = 6
        Me.tbNHM.Name = "tbNHM"
        Me.tbNHM.Size = New System.Drawing.Size(106, 23)
        Me.tbNHM.TabIndex = 6
        Me.tbNHM.Text = ""
        Me.tbNHM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(4, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 24)
        Me.Button3.TabIndex = 50
        Me.Button3.Text = "Individualni broj kola"
        '
        'gbUti
        '
        Me.gbUti.Controls.Add(Me.Label9)
        Me.gbUti.Controls.Add(Me.cbTipUti)
        Me.gbUti.Controls.Add(Me.Label8)
        Me.gbUti.Controls.Add(Me.Button4)
        Me.gbUti.Controls.Add(Me.tbUtiPlombe)
        Me.gbUti.Controls.Add(Me.Label7)
        Me.gbUti.Controls.Add(Me.tbPredajniList)
        Me.gbUti.Controls.Add(Me.Label6)
        Me.gbUti.Controls.Add(Me.Button2)
        Me.gbUti.Controls.Add(Me.tbUtiNHM)
        Me.gbUti.Controls.Add(Me.Label5)
        Me.gbUti.Controls.Add(Me.tbUtiTara)
        Me.gbUti.Controls.Add(Me.Label4)
        Me.gbUti.Controls.Add(Me.tbUtiIB)
        Me.gbUti.Controls.Add(Me.Label1)
        Me.gbUti.Controls.Add(Me.Label3)
        Me.gbUti.Location = New System.Drawing.Point(5, 296)
        Me.gbUti.Name = "gbUti"
        Me.gbUti.Size = New System.Drawing.Size(400, 208)
        Me.gbUti.TabIndex = 7
        Me.gbUti.TabStop = False
        Me.gbUti.Text = "[ UTI ] "
        '
        'Label9
        '
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label9.Location = New System.Drawing.Point(137, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 16)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "  LC"
        '
        'cbTipUti
        '
        Me.cbTipUti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipUti.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbTipUti.Items.AddRange(New Object() {" ", " ", " ", " ", " ", " "})
        Me.cbTipUti.Location = New System.Drawing.Point(140, 34)
        Me.cbTipUti.Name = "cbTipUti"
        Me.cbTipUti.Size = New System.Drawing.Size(232, 24)
        Me.cbTipUti.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Enabled = False
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(137, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 15)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "  CL       ""          metri"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(304, 88)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(56, 40)
        Me.Button4.TabIndex = 54
        Me.Button4.Text = "Button4"
        Me.Button4.Visible = False
        '
        'tbUtiPlombe
        '
        Me.tbUtiPlombe.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUtiPlombe.Location = New System.Drawing.Point(140, 176)
        Me.tbUtiPlombe.MaxLength = 12
        Me.tbUtiPlombe.Name = "tbUtiPlombe"
        Me.tbUtiPlombe.Size = New System.Drawing.Size(232, 23)
        Me.tbUtiPlombe.TabIndex = 15
        Me.tbUtiPlombe.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 176)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 23)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Broj plombe"
        '
        'tbPredajniList
        '
        Me.tbPredajniList.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPredajniList.Location = New System.Drawing.Point(140, 144)
        Me.tbPredajniList.MaxLength = 10
        Me.tbPredajniList.Name = "tbPredajniList"
        Me.tbPredajniList.Size = New System.Drawing.Size(232, 23)
        Me.tbPredajniList.TabIndex = 14
        Me.tbPredajniList.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 23)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Predajni list br."
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Help
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Location = New System.Drawing.Point(16, 120)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 20)
        Me.Button2.TabIndex = 53
        Me.Button2.Text = "NHM"
        '
        'tbUtiNHM
        '
        Me.tbUtiNHM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUtiNHM.Location = New System.Drawing.Point(140, 120)
        Me.tbUtiNHM.MaxLength = 6
        Me.tbUtiNHM.Name = "tbUtiNHM"
        Me.tbUtiNHM.Size = New System.Drawing.Size(106, 23)
        Me.tbUtiNHM.TabIndex = 2
        Me.tbUtiNHM.Text = ""
        Me.tbUtiNHM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(256, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 23)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "[ kg ]"
        '
        'tbUtiTara
        '
        Me.tbUtiTara.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUtiTara.Location = New System.Drawing.Point(140, 88)
        Me.tbUtiTara.MaxLength = 5
        Me.tbUtiTara.Name = "tbUtiTara"
        Me.tbUtiTara.Size = New System.Drawing.Size(104, 23)
        Me.tbUtiTara.TabIndex = 12
        Me.tbUtiTara.Text = "0"
        Me.tbUtiTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tara kontenera"
        '
        'tbUtiIB
        '
        Me.tbUtiIB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbUtiIB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUtiIB.Location = New System.Drawing.Point(140, 64)
        Me.tbUtiIB.MaxLength = 11
        Me.tbUtiIB.Name = "tbUtiIB"
        Me.tbUtiIB.Size = New System.Drawing.Size(232, 23)
        Me.tbUtiIB.TabIndex = 11
        Me.tbUtiIB.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Individualni broj"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tip"
        '
        'tbVrsta
        '
        Me.tbVrsta.Enabled = False
        Me.tbVrsta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbVrsta.Location = New System.Drawing.Point(304, 21)
        Me.tbVrsta.MaxLength = 1
        Me.tbVrsta.Name = "tbVrsta"
        Me.tbVrsta.Size = New System.Drawing.Size(24, 20)
        Me.tbVrsta.TabIndex = 40
        Me.tbVrsta.Text = ""
        Me.tbVrsta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbOsovine
        '
        Me.tbOsovine.Enabled = False
        Me.tbOsovine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbOsovine.Location = New System.Drawing.Point(376, 43)
        Me.tbOsovine.MaxLength = 2
        Me.tbOsovine.Name = "tbOsovine"
        Me.tbOsovine.Size = New System.Drawing.Size(24, 20)
        Me.tbOsovine.TabIndex = 39
        Me.tbOsovine.Text = ""
        Me.tbOsovine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbSerija
        '
        Me.tbSerija.Enabled = False
        Me.tbSerija.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSerija.Location = New System.Drawing.Point(328, 21)
        Me.tbSerija.MaxLength = 11
        Me.tbSerija.Name = "tbSerija"
        Me.tbSerija.Size = New System.Drawing.Size(72, 20)
        Me.tbSerija.TabIndex = 38
        Me.tbSerija.Text = ""
        Me.tbSerija.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(269, 107)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(24, 23)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "[ t ]"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(270, 77)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 23)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "[ kg ]"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(4, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 23)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Granica tovarenja"
        '
        'tbTara
        '
        Me.tbTara.BackColor = System.Drawing.Color.White
        Me.tbTara.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbTara.Location = New System.Drawing.Point(148, 73)
        Me.tbTara.MaxLength = 6
        Me.tbTara.Name = "tbTara"
        Me.tbTara.Size = New System.Drawing.Size(104, 23)
        Me.tbTara.TabIndex = 1
        Me.tbTara.Text = "0"
        Me.tbTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(4, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 23)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Tara kola"
        '
        'chbStitnaKola
        '
        Me.chbStitnaKola.Location = New System.Drawing.Point(148, 46)
        Me.chbStitnaKola.Name = "chbStitnaKola"
        Me.chbStitnaKola.Size = New System.Drawing.Size(96, 23)
        Me.chbStitnaKola.TabIndex = 19
        Me.chbStitnaKola.Text = "Štitna kola"
        '
        'btnBrisiKola
        '
        Me.btnBrisiKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiKola.Image = CType(resources.GetObject("btnBrisiKola.Image"), System.Drawing.Image)
        Me.btnBrisiKola.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiKola.Location = New System.Drawing.Point(222, 167)
        Me.btnBrisiKola.Name = "btnBrisiKola"
        Me.btnBrisiKola.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiKola.TabIndex = 41
        Me.btnBrisiKola.Text = "Brisi"
        Me.btnBrisiKola.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'fxGranTov
        '
        Me.fxGranTov.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxGranTov.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxGranTov.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxGranTov.Location = New System.Drawing.Point(148, 104)
        Me.fxGranTov.Mask = "999d99"
        Me.fxGranTov.Name = "fxGranTov"
        Me.fxGranTov.Size = New System.Drawing.Size(104, 23)
        Me.fxGranTov.TabIndex = 2
        Me.fxGranTov.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(4, 136)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 23)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Naknada za žel. kola"
        '
        'tbKolaNaknada
        '
        Me.tbKolaNaknada.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbKolaNaknada.Location = New System.Drawing.Point(148, 136)
        Me.tbKolaNaknada.Name = "tbKolaNaknada"
        Me.tbKolaNaknada.Size = New System.Drawing.Size(104, 23)
        Me.tbKolaNaknada.TabIndex = 27
        Me.tbKolaNaknada.Text = "0"
        Me.tbKolaNaknada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnBrisiRobu
        '
        Me.btnBrisiRobu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiRobu.Image = CType(resources.GetObject("btnBrisiRobu.Image"), System.Drawing.Image)
        Me.btnBrisiRobu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiRobu.Location = New System.Drawing.Point(224, 568)
        Me.btnBrisiRobu.Name = "btnBrisiRobu"
        Me.btnBrisiRobu.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiRobu.TabIndex = 10
        Me.btnBrisiRobu.Text = "Brisi"
        Me.btnBrisiRobu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(4, 246)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 23)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Masa robe"
        '
        'tbMasa
        '
        Me.tbMasa.BackColor = System.Drawing.Color.White
        Me.tbMasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbMasa.Location = New System.Drawing.Point(148, 238)
        Me.tbMasa.MaxLength = 6
        Me.tbMasa.Name = "tbMasa"
        Me.tbMasa.Size = New System.Drawing.Size(106, 23)
        Me.tbMasa.TabIndex = 5
        Me.tbMasa.Text = "0"
        Me.tbMasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Help
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(4, 270)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 20)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "NHM"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(257, 241)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 23)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "[ kg ]"
        '
        'btnDodajKola
        '
        Me.btnDodajKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodajKola.Image = CType(resources.GetObject("btnDodajKola.Image"), System.Drawing.Image)
        Me.btnDodajKola.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodajKola.Location = New System.Drawing.Point(150, 167)
        Me.btnDodajKola.Name = "btnDodajKola"
        Me.btnDodajKola.Size = New System.Drawing.Size(62, 48)
        Me.btnDodajKola.TabIndex = 3
        Me.btnDodajKola.Text = "Dodaj"
        Me.btnDodajKola.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnIzmeniKola
        '
        Me.btnIzmeniKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIzmeniKola.Image = CType(resources.GetObject("btnIzmeniKola.Image"), System.Drawing.Image)
        Me.btnIzmeniKola.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIzmeniKola.Location = New System.Drawing.Point(150, 167)
        Me.btnIzmeniKola.Name = "btnIzmeniKola"
        Me.btnIzmeniKola.Size = New System.Drawing.Size(62, 48)
        Me.btnIzmeniKola.TabIndex = 4
        Me.btnIzmeniKola.Text = "Izmeni"
        Me.btnIzmeniKola.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIzmeniKola.Visible = False
        '
        'btnDodajRobu
        '
        Me.btnDodajRobu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodajRobu.Image = CType(resources.GetObject("btnDodajRobu.Image"), System.Drawing.Image)
        Me.btnDodajRobu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodajRobu.Location = New System.Drawing.Point(144, 568)
        Me.btnDodajRobu.Name = "btnDodajRobu"
        Me.btnDodajRobu.Size = New System.Drawing.Size(62, 48)
        Me.btnDodajRobu.TabIndex = 8
        Me.btnDodajRobu.Text = "Dodaj"
        Me.btnDodajRobu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnIzmeniRobu
        '
        Me.btnIzmeniRobu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIzmeniRobu.Image = CType(resources.GetObject("btnIzmeniRobu.Image"), System.Drawing.Image)
        Me.btnIzmeniRobu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIzmeniRobu.Location = New System.Drawing.Point(152, 568)
        Me.btnIzmeniRobu.Name = "btnIzmeniRobu"
        Me.btnIzmeniRobu.Size = New System.Drawing.Size(62, 48)
        Me.btnIzmeniRobu.TabIndex = 9
        Me.btnIzmeniRobu.Text = "Izmeni"
        Me.btnIzmeniRobu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIzmeniRobu.Visible = False
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(304, 167)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(62, 48)
        Me.Button5.TabIndex = 38
        Me.Button5.Text = "Kontrola "
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblNPUvecanje
        '
        Me.lblNPUvecanje.Location = New System.Drawing.Point(201, 6)
        Me.lblNPUvecanje.Name = "lblNPUvecanje"
        Me.lblNPUvecanje.Size = New System.Drawing.Size(40, 18)
        Me.lblNPUvecanje.TabIndex = 50
        '
        'lblNPUkupno
        '
        Me.lblNPUkupno.Location = New System.Drawing.Point(356, 6)
        Me.lblNPUkupno.Name = "lblNPUkupno"
        Me.lblNPUkupno.Size = New System.Drawing.Size(24, 18)
        Me.lblNPUkupno.TabIndex = 50
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(136, 6)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 18)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "Uvecanje :"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(248, 6)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 18)
        Me.Label22.TabIndex = 50
        Me.Label22.Text = "Ukupno kola u NP :"
        '
        'lblZSNP
        '
        Me.lblZSNP.Location = New System.Drawing.Point(80, 6)
        Me.lblZSNP.Name = "lblZSNP"
        Me.lblZSNP.Size = New System.Drawing.Size(40, 18)
        Me.lblZSNP.TabIndex = 50
        Me.lblZSNP.Text = "123"
        '
        'dgKola
        '
        Me.dgKola.CaptionText = "Kola"
        Me.dgKola.DataMember = ""
        Me.dgKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.dgKola.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKola.Location = New System.Drawing.Point(8, 16)
        Me.dgKola.Name = "dgKola"
        Me.dgKola.PreferredColumnWidth = 100
        Me.dgKola.Size = New System.Drawing.Size(536, 200)
        Me.dgKola.TabIndex = 24
        Me.dgKola.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgKola
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "SuperGrid"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.dgRoba)
        Me.GroupBox2.Controls.Add(Me.dgKola)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(432, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(552, 568)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label13.Location = New System.Drawing.Point(173, 237)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(167, 51)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "VETERINARSKI PREGLED RADIOLOSKI PREGLED EKOLOSKI PREGLED"
        Me.Label13.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(114, 233)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 48
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(58, 235)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 47
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(13, 232)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'dgRoba
        '
        Me.dgRoba.CaptionText = "Roba na kolima"
        Me.dgRoba.DataMember = ""
        Me.dgRoba.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.dgRoba.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgRoba.Location = New System.Drawing.Point(8, 301)
        Me.dgRoba.Name = "dgRoba"
        Me.dgRoba.PreferredColumnWidth = 100
        Me.dgRoba.Size = New System.Drawing.Size(536, 264)
        Me.dgRoba.TabIndex = 45
        '
        'StatusBar1
        '
        Me.StatusBar1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.StatusBar1.Location = New System.Drawing.Point(0, 708)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(1008, 22)
        Me.StatusBar1.TabIndex = 19
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(792, 640)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 1
        Me.btnPrihvati.Text = "Prihvati  [ F12 ]"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(896, 640)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 2
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbSumaKola
        '
        Me.tbSumaKola.Enabled = False
        Me.tbSumaKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaKola.Location = New System.Drawing.Point(288, 42)
        Me.tbSumaKola.MaxLength = 2
        Me.tbSumaKola.Name = "tbSumaKola"
        Me.tbSumaKola.Size = New System.Drawing.Size(32, 21)
        Me.tbSumaKola.TabIndex = 25
        Me.tbSumaKola.Text = ""
        Me.tbSumaKola.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(272, 42)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 23)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = " / "
        Me.Label18.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.IndianRed
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 32)
        Me.Panel1.TabIndex = 38
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(8, 2)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(312, 23)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Unos podataka o kolima i robi"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(8, 6)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 18)
        Me.Label20.TabIndex = 39
        Me.Label20.Text = "Broj ŽS NP :"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.lblZSNP)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.lblNPUvecanje)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.lblNPUkupno)
        Me.Panel2.Location = New System.Drawing.Point(569, 39)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(415, 27)
        Me.Panel2.TabIndex = 39
        Me.Panel2.Visible = False
        '
        'kola
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbSumaKola)
        Me.Controls.Add(Me.tbRbrKola)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chbNarocitaPosiljka)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label18)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "kola"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.gbUti.ResumeLayout(False)
        CType(Me.dgKola, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgRoba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim nhm As DataSet
    Dim kola As DataSet
    Dim mUprava As String
    Dim mICF As String
    Private Sub kola_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatKolaGrid()
        FormatNhmGrid()
        Me.tbRbrKola.Text = dtKola.Rows.Count
        If Len(nmBrTelegram) > 1 Then
            Me.chbNarocitaPosiljka.Checked = True
        Else
            Me.chbNarocitaPosiljka.Checked = False
        End If

        If nmNarPos = True Then
            Me.chbNarocitaPosiljka.Checked = True
        Else
            Me.chbNarocitaPosiljka.Checked = False
        End If

        'SirinaKolona1()

        '''''''''''fxIBK.Text = Microsoft.VisualBasic.Mid(mIBK, 1, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 3, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 5, 4) & " " & Microsoft.VisualBasic.Mid(mIBK, 9, 3) & " " & Microsoft.VisualBasic.Mid(mIBK, 12, 1)
        If _TL_Kola = 1 Then
            fxIBK.Focus()
        Else
            Dim currRowKola As DataRow
            currRowKola = CType(dgKola.DataSource, DataTable).Rows(dgKola.CurrentCell.RowNumber)
            mIBK = currRowKola(0, DataRowVersion.Current).ToString()
            tbMasa.Focus()
        End If

    End Sub
    Private Sub FormatNhmGrid()
        'Col1.AutoIncrement = True
        'Col1.ReadOnly = True
        If nhm Is Nothing Then
            dgRoba.DataSource = dtNhm
        Else
            If mNajava Is Nothing Then
            Else
                dgRoba.DataSource = dtNhm
            End If
            dgRoba.DataSource = nhm.Tables(0)
        End If
    End Sub
    Private Sub FormatKolaGrid()
        'Col1.AutoIncrement = True
        'Col1.ReadOnly = True

        If kola Is Nothing Then
            dgKola.DataSource = dtKola
        Else
            If mNajava Is Nothing Then
            Else
                dgKola.DataSource = dtKola
            End If
            dgKola.DataSource = kola.Tables(0)
        End If

        ''Dim tableStyle As DataGridTableStyle
        ''tableStyle = New DataGridTableStyle
        ''tableStyle.MappingName = "SuperGrid"

        ''dgKola.TableStyles.Clear()
        ''dgKola.TableStyles.Add(tableStyle)
        ''dgKola.DataSource = kola.Tables("SuperGrid")

        ''AutoSizeTable()

    End Sub

    Private Sub tbTara_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbTara.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxIBK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxIBK.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxGranTov_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxGranTov.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnDodajKola_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnDodajKola.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbMasa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbMasa.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbNHM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNHM.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbNHM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbNHM.Validating
        If IsNumeric(tbNHM.Text) = True Then
            Dim rv As String = ""
            Dim KolaRed As DataRow
            'Dim nmVER As String = ""

            '1.7.2008. zbor tarifskog razreda u TEA tarifi
            Dim tempTarifa92 As String = "00"
            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" And mVrstaObracuna = "CO" Then
                tempTarifa92 = "68"
            Else
                tempTarifa92 = mTarifa
            End If

            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            Dim uspKomanda As New SqlClient.SqlCommand("NadjiNhmVER", DbVeza)
            'Dim uspKomanda As New SqlClient.SqlCommand("NadjiNhm", DbVeza)
            uspKomanda.CommandType = CommandType.StoredProcedure

            Dim upSifraRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upSifraRobe", SqlDbType.Char, 6))
            upSifraRobe.Direction = ParameterDirection.Input
            uspKomanda.Parameters("@upSifraRobe").Value = tbNHM.Text

            Dim upTarifa As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upTarifa", SqlDbType.Char, 2))
            upTarifa.Direction = ParameterDirection.Input
            uspKomanda.Parameters("@upTarifa").Value = tempTarifa92 'mTarifa

            Dim ipNazivRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipNazivRobe", SqlDbType.Char, 100))
            ipNazivRobe.Direction = ParameterDirection.Output

            Dim ipRazredRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRobe", SqlDbType.Char, 1))
            ipRazredRobe.Direction = ParameterDirection.Output

            Dim ipRazredRid As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRid", SqlDbType.Int, 2))
            ipRazredRid.Direction = ParameterDirection.Output

            Dim ipNhmVER As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipVER", SqlDbType.Char, 3))
            ipNhmVER.Direction = ParameterDirection.Output

            Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipPovratnaVrednost", SqlDbType.NVarChar, 100))
            ipPovratnaVrednost.Direction = ParameterDirection.Output

            Try
                uspKomanda.ExecuteScalar()
                If uspKomanda.Parameters("@ipPovratnaVrednost").Value = "" Then 'OK
                    StatusBar1.Text = uspKomanda.Parameters("@ipNazivRobe").Value
                    ErrorProvider1.SetError(tbNHM, "")
                    mRazred = uspKomanda.Parameters("@ipRazredRobe").Value
                    mRazredRid = uspKomanda.Parameters("@ipRazredRid").Value
                    _nmNakVER = uspKomanda.Parameters("@ipVER").Value
                    tbRazred.Text = mRazred
                    tbRazredRid.Text = mRazredRid

                    Label13.Text = ""

                    If Microsoft.VisualBasic.Left(_nmNakVER, 1) = "1" Then
                        Label13.Text = "VETERINARSKI PREGLED "
                        Label13.Visible = True
                        Me.PictureBox1.Visible = True
                    Else
                        Me.PictureBox1.Visible = False
                    End If

                    If Microsoft.VisualBasic.Mid(_nmNakVER, 2, 1) = "1" Then
                        Label13.Text = Label13.Text & "EKOLOSKI PREGLED "
                        Label13.Visible = True
                        Me.PictureBox2.Visible = True
                    Else
                        Me.PictureBox2.Visible = False
                    End If

                    If Microsoft.VisualBasic.Right(_nmNakVER, 1) = "1" Then
                        Label13.Text = Label13.Text & "RADIOLOSKI PREGLED "
                        Label13.Visible = True
                        Me.PictureBox3.Visible = True
                    Else
                        Me.PictureBox3.Visible = False
                    End If



                    If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9931" Then
                        bKontejneri = True
                    Else
                        bKontejneri = False
                    End If

                    '---------------- popunjava kolonu TipKola u dgKola ------------------------
                    For Each KolaRed In dtKola.Rows
                        If mIBK = KolaRed.Item("IndBrojKola") Then
                            If KolaRed.Item("Vlasnik") = "Z" Then
                                If KolaRed.Item("Vrsta") = "O" Then
                                    KolaRed.Item("Tip") = "1"
                                Else
                                    KolaRed.Item("Tip") = "2"
                                End If
                            Else
                                If KolaRed.Item("Vrsta") = "O" Then
                                    If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9922" Then
                                        KolaRed.Item("Tip") = "7"
                                    Else
                                        KolaRed.Item("Tip") = "3"
                                    End If
                                Else
                                    If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9922" Then
                                        KolaRed.Item("Tip") = "7"
                                    Else
                                        KolaRed.Item("Tip") = "4"
                                    End If
                                End If

                            End If
                            If Microsoft.VisualBasic.Left(tbNHM.Text, 4) = "8604" Or Microsoft.VisualBasic.Left(tbNHM.Text, 4) = "8605" Or Microsoft.VisualBasic.Left(tbNHM.Text, 4) = "8606" Then
                                KolaRed.Item("Tip") = "1"
                            End If

                        End If
                    Next
                    '---------------------------------------------------------------------------

                    'otvara tip uti
                    If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9931" Then
                        If mBrojUg = "844514" Then
                            cbTipUti.MaxDropDownItems = 5
                            cbTipUti.Items(0) = "20  20    do 6.15"
                            cbTipUti.Items(1) = "25   -      6.16 do 7.82"
                            cbTipUti.Items(2) = "30  30    7.83 do 9.15"
                            cbTipUti.Items(3) = "40  40    9.16 do 13.75"
                            cbTipUti.Items(4) = "70   -      poluprikolice"
                        Else
                            cbTipUti.MaxDropDownItems = 6
                            cbTipUti.Items(0) = "10  20    do 6.15"
                            cbTipUti.Items(1) = "20   -      6.16 do 7.82"
                            cbTipUti.Items(2) = "30  30    7.83 do 9.15"
                            cbTipUti.Items(3) = "40  35    9.16 do 10.90"
                            cbTipUti.Items(4) = "50  40   10.91 do 10.90"
                            cbTipUti.Items(5) = "70   -    poluprikolice"
                        End If

                        gbUti.Enabled = True
                        'cbTipUti.Enabled = True
                        cbTipUti.Focus()
                        cbTipUti.DroppedDown = True
                    Else
                        gbUti.Enabled = False
                        btnDodajRobu.Focus()
                    End If
                    ' ----------------------------------------

                Else 'nije ok
                    StatusBar1.Text = ""
                    rv = uspKomanda.Parameters("@ipPovratnaVrednost").Value
                    ErrorProvider1.SetError(tbNHM, rv)
                    tbNHM.Focus()
                End If

            Catch SQLExp As SqlException
                rv = SQLExp.Message & " ?"  'Greska - SQL greska
                StatusBar1.Text = rv
                tbNHM.Focus()

            Catch Exp As Exception
                rv = Err.Description & "??" 'Greska - bilo koja
                StatusBar1.Text = rv
                tbNHM.Focus()
            Finally
                DbVeza.Close()
                uspKomanda.Dispose()
            End Try

        Else
            ErrorProvider1.SetError(tbNHM, "Neispravan unos!")
            If tbNHM.Text = Nothing Then
                tbMasa.Focus()
            Else
                tbNHM.Focus()
            End If
        End If

    End Sub

    Private Sub cbTipUti_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipUti.Leave

        If cbTipUti.Text = Nothing Then
            cbTipUti.Focus()
        Else
            Me.cbTipUti.BackColor = System.Drawing.Color.White
            Me.cbTipUti.ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    Private Sub cbTipUti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbTipUti.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxIBK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fxIBK.Validating
        mIBK = Microsoft.VisualBasic.Mid(fxIBK.Text, 1, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 4, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 7, 4) & Microsoft.VisualBasic.Mid(fxIBK.Text, 12, 3) & Microsoft.VisualBasic.Mid(fxIBK.Text, 16, 1)

        If Len(mIBK) < 12 Then
            If dtKola.Rows.Count > 0 Then
                If Len(mIBK) = 0 Then
                    ErrorProvider1.SetError(fxIBK, "")
                    Me.btnPrihvati.Focus()
                End If
            Else
                ErrorProvider1.SetError(fxIBK, "Nepotpun broj kola!")
                fxIBK.Focus()
            End If
        Else
            '-- Novo 09/09/2013 : ukljucivanje tabele IKP ------------------------------------------------------------------------------------
            '1. prvo ispita KB
            '2. ako je ok, traži IBK u IKP
            '3. ako ne nadje traži iz procedure

            Dim rv1 As String = ""
            Dim nmNasaoIKP As Boolean = False
            Dim nmKBOK As Boolean = False
            mICF = "N"

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            '---------------dodati kontrolu IBK!!!
            Dim Broj1 As Int32 = 0
            Dim Broj2 As Int32 = 0
            Dim xSuma1 As Int32 = 0
            Dim xSuma2 As Int32 = 0

            Try
                If Len(mIBK) > 0 Then
                    For ii As Int32 = 1 To 11 Step 2
                        Broj1 = Microsoft.VisualBasic.Mid(mIBK, ii, 1)
                        Broj1 = Broj1 * 2
                        If Broj1 >= 10 Then
                            Broj2 = CInt(Microsoft.VisualBasic.Left(CStr(Broj1), 1)) + CInt(Microsoft.VisualBasic.Right(CStr(Broj1), 1))
                        Else
                            Broj2 = Broj1
                        End If
                        xSuma1 = xSuma1 + Broj2
                    Next

                    For ii As Int32 = 2 To 10 Step 2
                        Broj1 = Microsoft.VisualBasic.Mid(mIBK, ii, 1)
                        xSuma2 = xSuma2 + Broj1
                    Next

                    If Int((xSuma1 + xSuma2 + 10) / 10) * 10 - (xSuma1 + xSuma2) > 9 Then
                        lblKB.Text = "0"
                    Else
                        lblKB.Text = CStr((Int((xSuma1 + xSuma2 + 10) / 10) * 10 - (xSuma1 + xSuma2)))
                    End If

                    If Microsoft.VisualBasic.Right(mIBK, 1) <> lblKB.Text Then
                        nmKBOK = False
                        mIBK_KB = "N"
                        lblKB.Visible = True
                        Me.ErrorProvider1.SetError(Button3, "Neispravan kontrolni broj!")
                        fxIBK.Focus()
                    Else
                        nmKBOK = True
                        mIBK_KB = "D"

                        lblKB.Visible = False
                        Me.ErrorProvider1.SetError(Button3, "")
                    End If
                End If
            Catch ex As Exception
                nmKBOK = False
                MsgBox("Neispravan podatak, unesite broj kola!", MsgBoxStyle.Critical, "Greska ibk")
                fxIBK.Focus()
            End Try

            If nmKBOK = True Then
                Dim uspKomanda1 As New SqlClient.SqlCommand("nmNadjiIBK_T", OkpDbVeza)
                'Dim uspKomanda1 As New SqlClient.SqlCommand("nmNadjiIBK", OkpDbVeza)
                uspKomanda1.CommandType = CommandType.StoredProcedure

                Dim upIBK1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
                upIBK1.Direction = ParameterDirection.Input
                uspKomanda1.Parameters("@inIBK").Value = mIBK

                Dim upDatum As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime, 8))
                upDatum.Direction = ParameterDirection.Input
                uspKomanda1.Parameters("@inDatum").Value = mDatumKalk

                Dim ipSkrUprava1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outUprava", SqlDbType.Char, 6))
                ipSkrUprava1.Direction = ParameterDirection.Output

                Dim ipTara1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outTara", SqlDbType.Int))
                ipTara1.Direction = ParameterDirection.Output

                Dim ipSerija1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outSerija", SqlDbType.Char, 11))
                ipSerija1.Direction = ParameterDirection.Output

                Dim ipBrojOsovina1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outOsovine", SqlDbType.Int))
                ipBrojOsovina1.Direction = ParameterDirection.Output

                Dim ipVlasnistvo1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVlasnik", SqlDbType.Char, 1))
                ipVlasnistvo1.Direction = ParameterDirection.Output

                Dim ipVrsta1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
                ipVrsta1.Direction = ParameterDirection.Output

                Dim ipPovratnaVrednost1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
                ipPovratnaVrednost1.Direction = ParameterDirection.Output

                Try
                    uspKomanda1.ExecuteScalar()
                    mUprava = uspKomanda1.Parameters("@outUprava").Value
                    tbUprava.Text = mUprava
                    tbTara.Text = uspKomanda1.Parameters("@outTara").Value
                    tbSerija.Text = uspKomanda1.Parameters("@outSerija").Value
                    tbOsovine.Text = uspKomanda1.Parameters("@outOsovine").Value
                    tbVlasnik.Text = uspKomanda1.Parameters("@outVlasnik").Value
                    If uspKomanda1.Parameters("@outVrsta").Value = "1" Then
                        tbVrsta.Text = "O"
                    Else
                        tbVrsta.Text = "S"
                    End If
                    nmNasaoIKP = True
                Catch Exp As Exception
                    nmNasaoIKP = False
                Finally
                    OkpDbVeza.Close()
                    uspKomanda1.Dispose()
                End Try
            End If
            '------------------- end KB
            '--end novo ---------------------------------------------------------------------------------------------------------------------

            If nmNasaoIKP = False Then
                ErrorProvider1.SetError(fxIBK, "")
                Dim rv As String = ""
                Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & mIBK & "'")

                If DbVeza.State = ConnectionState.Closed Then
                    DbVeza.Open()
                End If

                Dim uspKomanda As New SqlClient.SqlCommand("spNadjiSveIzIBK", DbVeza)
                uspKomanda.CommandType = CommandType.StoredProcedure

                Dim upIBK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
                upIBK.Direction = ParameterDirection.Input
                uspKomanda.Parameters("@inIBK").Value = Microsoft.VisualBasic.Mid(fxIBK.Text, 1, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 4, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 7, 4) & Microsoft.VisualBasic.Mid(fxIBK.Text, 12, 3) & Microsoft.VisualBasic.Mid(fxIBK.Text, 16, 1)

                Dim ipSkrUprava As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSkrUprava", SqlDbType.Char, 6))
                ipSkrUprava.Direction = ParameterDirection.Output

                Dim ipVlasnistvo As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVlasnistvo", SqlDbType.Char, 1))
                ipVlasnistvo.Direction = ParameterDirection.Output

                Dim ipRIV As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRIV", SqlDbType.Char, 1))
                ipRIV.Direction = ParameterDirection.Output

                Dim ipSerija As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSerija", SqlDbType.Char, 11))
                ipSerija.Direction = ParameterDirection.Output

                Dim ipBrojOsovina As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrojOsovina", SqlDbType.Int))
                ipBrojOsovina.Direction = ParameterDirection.Output

                Dim ipVrsta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
                ipVrsta.Direction = ParameterDirection.Output

                Dim ipKontrBroj As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBroj", SqlDbType.Int))
                ipKontrBroj.Direction = ParameterDirection.Output

                Dim ipKontrBrojOK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBrojOK", SqlDbType.Char, 1))
                ipKontrBrojOK.Direction = ParameterDirection.Output

                Dim ipKolaICFIzuzeta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolaICFIzuzeta", SqlDbType.Char, 1))
                ipKolaICFIzuzeta.Direction = ParameterDirection.Output

                Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.NVarChar, 100))
                ipPovratnaVrednost.Direction = ParameterDirection.Output

                Try
                    uspKomanda.ExecuteScalar()
                    mUprava = uspKomanda.Parameters("@outSkrUprava").Value
                    tbUprava.Text = mUprava
                    tbVlasnik.Text = uspKomanda.Parameters("@outVlasnistvo").Value
                    tbSerija.Text = uspKomanda.Parameters("@outSerija").Value
                    tbOsovine.Text = uspKomanda.Parameters("@outBrojOsovina").Value
                    If uspKomanda.Parameters("@outVrsta").Value = "1" Then
                        tbVrsta.Text = "O"
                    Else
                        tbVrsta.Text = "S"
                    End If
                    mICF = uspKomanda.Parameters("@outKolaICFIzuzeta").Value
                    mIBK_KB = uspKomanda.Parameters("@outKontrBrojOK").Value
                    If mIBK_KB = "D" Then
                        ErrorProvider1.SetError(fxIBK, "")
                        StatusBar1.Text = ""
                    Else
                        If mkBrojPokusaja > 3 Then
                            mkBrojPokusaja = 1
                            ErrorProvider1.SetError(Button3, "")
                            Dim KolaNotFound As New KolaExtra
                            KolaNotFound.ShowDialog()

                            tbVlasnik.Text = mVlasnik
                            tbSerija.Text = mSerija
                            tbVrsta.Text = mVrsta
                            tbOsovine.Text = mOsovine

                            Me.tbTara.SelectAll()
                            Me.tbTara.Focus()
                        Else
                            mkBrojPokusaja = mkBrojPokusaja + 1
                            ErrorProvider1.SetError(Button3, "Neispravan kontrolni broj!")
                            fxIBK.Focus()
                        End If
                    End If
                Catch Exp As Exception
                    If fxIBK.Text = Nothing Then
                        If dtKola.Rows.Count > 0 Then
                            StatusBar1.Text = ""
                            Me.fxIBK.BackColor = System.Drawing.Color.White
                            Me.fxIBK.ForeColor = System.Drawing.Color.Black
                            Me.btnPrihvati.Focus()
                        Else
                            rv = Err.Description & "??"
                            StatusBar1.Text = rv
                            Me.fxIBK.Focus()
                        End If
                    Else
                        rv = Err.Description & "??"
                        StatusBar1.Text = rv
                        Me.fxIBK.Focus()
                    End If
                Finally
                    DbVeza.Close()
                    uspKomanda.Dispose()
                End Try
            Else
                btnDodajKola.Focus()

            End If
        End If
    End Sub

    Private Sub btnDodajKola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajKola.Click

        'Dim mVlasnik As String
        'Dim mSerija As String
        'Dim mVrsta As String
        'Dim mOsovine As Int16
        Dim mTara As Int32
        Dim mGranTov As Decimal
        Dim mStitna As String
        Dim mTipKola As String = "0" 'nakon unosa robe
        Dim mPrevoznina As Decimal = "0" 'nakon kalkulacije
        Dim mNaknada As Decimal = "0" 'nakon kalkulacije
        mkBrojPokusaja = 1

        mIBK = Microsoft.VisualBasic.Mid(fxIBK.Text, 1, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 4, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 7, 4) & Microsoft.VisualBasic.Mid(fxIBK.Text, 12, 3) & Microsoft.VisualBasic.Mid(fxIBK.Text, 16, 1)
        GridIBK = mIBK
        mUprava = tbUprava.Text
        mVlasnik = tbVlasnik.Text
        mSerija = tbSerija.Text
        mVrsta = tbVrsta.Text
        mOsovine = tbOsovine.Text
        mTara = tbTara.Text
        mGranTov = Me.fxGranTov.Text

        If Me.chbStitnaKola.Checked = True Then
            mStitna = "D"
        Else
            mStitna = "N"
        End If

        'naknada za koriscenje zeleznickih kola iz tabele obb kola!!!
        If mICF = "D" Then
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            Dim sql_text As String = "SELECT Iznos1 " & _
                                     "FROM dbo.ZsNaknade " & _
                                     "WHERE (Sifra = '90') AND (IvicniBroj = '00') AND (SifraVS = 4) "

            Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
            Dim rdrIcf As SqlClient.SqlDataReader

            rdrIcf = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrIcf.Read()
                mNaknada = rdrIcf.GetDecimal(0)
                tbKolaNaknada.Text = mNaknada
            Loop
            rdrIcf.Close()
            DbVeza.Close()
        End If

        If mBrojUg = "835745" Then ' Adriacombi
            If mVlasnik = "Z" Then
                tbKolaNaknada.Text = 40 '36
                mNaknada = 40 '36
            End If
        ElseIf mBrojUg = "835753" Or mBrojUg = "955401" Then ' Adriacombi
            If mVlasnik = "Z" Then
                tbKolaNaknada.Text = 36
                mNaknada = 36
            End If

        ElseIf mBrojUg = "993353" Then ' Intercontainer
            If mVlasnik = "Z" Then
                If Microsoft.VisualBasic.Mid(mIBK, 3, 2) = "81" Then
                    tbKolaNaknada.Text = 0
                    mNaknada = 0
                Else
                    tbKolaNaknada.Text = 36
                    mNaknada = 36
                End If
            End If
        ElseIf mBrojUg = "993354" Then ' Intercontainer
            If mVlasnik = "Z" Then
                If Microsoft.VisualBasic.Mid(mIBK, 3, 2) = "81" Then
                    tbKolaNaknada.Text = 0
                    mNaknada = 0
                Else
                    tbKolaNaknada.Text = 36
                    mNaknada = 36
                End If
            End If
        ElseIf mBrojUg = "100901" Then ' Proodos
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "100996" Then ' Proodos
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "100997" Then ' Proodos
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "101001" Then ' Proodos        '#$#
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "101101" Then ' Proodos        '#$#
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "101201" Then ' Proodos        '#$#
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "101301" Then ' Proodos        '#$#
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "101096" Then ' Proodos        '#$#
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "101196" Then ' Proodos        '#$#
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "101296" Then ' Proodos        '#$#
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        ElseIf mBrojUg = "101396" Then ' Proodos        '#$#
            If IzborSaobracaja = "4" Then
                If mVlasnik = "P" Then
                    tbKolaNaknada.Text = -60
                    mNaknada = -60
                End If
            End If
        End If

        Try
            Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & GridIBK & "'")
            If dtRow.Length > 0 Then
                ErrorProvider1.SetError(fxIBK, "Kola su vec upisana!")
                fxIBK.Focus()
                fxIBK.SelectAll()
                Exit Try
            Else
                ErrorProvider1.SetError(fxIBK, "")
                dtKola.NewRow()
                dtKola.Rows.Add(New Object() {GridIBK, mTara, mOsovine, mVlasnik, mSerija, mVrsta, mUprava, mGranTov, mStitna, mTipKola, mPrevoznina, mNaknada, mICF, mIBK_KB, "I"})
            End If
            dgKola.Refresh()
            Me.tbRbrKola.Text = dtKola.Rows.Count

            fxIBK.Clear()
            'tbTara.Text = 0
            Me.chbStitnaKola.Checked = False
            'Me.fxGranTov.Clear()
            tmp_FromKola = True

            tbMasa.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDodajRobu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajRobu.Click
        Dim ctrlDodaj As Boolean = False
        If tbMasa.Text = 0 Or Len(tbMasa.Text) = 0 Or Len(tbNHM.Text) = 0 Or Len(tbNHM.Text) < 6 Then
            ctrlDodaj = True
        End If
        If Microsoft.VisualBasic.Left(tbNHM.Text, 4) = "9931" Or Microsoft.VisualBasic.Left(tbNHM.Text, 4) = "9941" Then
            If Microsoft.VisualBasic.Left(tbUtiNHM.Text, 4) = "9921" Or Microsoft.VisualBasic.Left(tbUtiNHM.Text, 4) = "9922" Then
                ctrlDodaj = True
            End If
        End If

        If ctrlDodaj = False Then
            If (Microsoft.VisualBasic.Left(Me.tbNHM.Text, 4) = "9941" Or Microsoft.VisualBasic.Left(Me.tbNHM.Text, 4) = "9931") And cbTipUti.Text = Nothing Then
                MsgBox("Neispravan unos tipa kontejnera!", MsgBoxStyle.Critical)
                cbTipUti.Focus()

            Else
                Dim SifraRobe As String
                Dim MasaRobe As Int32
                Dim Tr As String
                Dim TrRid As String
                Dim TipUti As String

                '------------ verzija za stanice otvara polja za unos
                Dim UtiIB As String = ""
                Dim UtiTara As Int32 = 0
                Dim UtiRaster As Decimal = 0
                Dim UtiNaknada As Decimal = 0
                Dim UtiNHM As String = ""
                Dim UtiPredajniList As String = ""
                Dim UtiBrPlombe As String = ""
                '-----------------------------------------------------
                StatusBar1.Text = ""

                SifraRobe = tbNHM.Text

                '***
                'za koji slucaj ovo vazi!!!
                If Microsoft.VisualBasic.Mid(SifraRobe, 1, 4) = "9931" Then
                    mTabelaCena = "386"
                ElseIf Microsoft.VisualBasic.Mid(SifraRobe, 1, 4) = "9941" Then
                    mTabelaCena = "385"
                End If

                MasaRobe = tbMasa.Text
                Tr = tbRazred.Text
                If Microsoft.VisualBasic.Mid(SifraRobe, 1, 4) = "9931" Or Microsoft.VisualBasic.Mid(SifraRobe, 1, 4) = "9941" Then
                    TipUti = Microsoft.VisualBasic.Mid(cbTipUti.SelectedItem, 1, 2)
                    UtiIB = Me.tbUtiIB.Text
                    UtiTara = tbUtiTara.Text
                    UtiNHM = tbUtiNHM.Text
                    UtiPredajniList = Me.tbPredajniList.Text
                    UtiBrPlombe = Me.tbUtiPlombe.Text
                Else
                    TipUti = ""
                    UtiIB = ""
                    UtiTara = 0
                    UtiNHM = ""
                    UtiPredajniList = ""
                    UtiBrPlombe = ""
                End If
                TrRid = tbRazredRid.Text

                Dim dtRow As DataRow = dtNhm.NewRow

                dtNhm.Rows.Add(New Object() {GridIBK, SifraRobe, UtiNHM, MasaRobe, Tr, TipUti, TrRid, UtiIB, UtiTara, UtiRaster, UtiPredajniList, UtiBrPlombe, "I"})
                'dtNhm.Rows.Add(New Object() {GridIBK, SifraRobe, MasaRobe, TipUti, TrRid, Tr, UtiIB, UtiTara, UtiRaster, UtiNHM, UtiPredajniList, UtiBrPlombe, "I"})

                tmp_nhm = tbNHM.Text
                tmp_masa = tbMasa.Text
                tmp_FromKola = False

                tbNHM.Clear()
                tbMasa.Text = 0

                tbRazred.Clear()
                tbRazredRid.Clear()
                dgRoba.Refresh()

                tbMasa.Focus()

            End If

        Else
            tbMasa.Focus()

        End If


    End Sub

    Private Sub btnBrisiRobu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiRobu.Click

        If MasterAction = "New" Then
            Try
                CType(dgRoba.DataSource, DataTable).Rows(dgRoba.CurrentCell.RowNumber).Delete()
            Catch ex As Exception
                MsgBox(ex, MsgBoxStyle.Critical)
            Finally
                tbNHM.Clear()
                tbMasa.Text = 0
                tbRazred.Clear()
                tbRazredRid.Clear()
                Me.btnIzmeniRobu.Visible = False
                Me.btnDodajRobu.Visible = True
                Me.tbUtiIB.Clear()
                Me.tbUtiTara.Clear()
                Me.tbUtiNHM.Clear()
                Me.tbPredajniList.Clear()
                Me.tbUtiPlombe.Clear()

                tbMasa.Focus()
            End Try
        Else
            Try
                Dim rowNhm As Data.DataRow

                rowNhm = CType(dgRoba.DataSource, DataTable).Rows(dgRoba.CurrentCell.RowNumber)
                rowNhm = dtNhm.Rows(dgRoba.CurrentCell.RowNumber)
                rowNhm("Action") = "D"

                dvNhm.RowFilter = "Action LIKE 'U'"
                dgRoba.DataSource = dvNhm
                dgRoba.Refresh()

            Catch ex As Exception
            Finally
                dgRoba.Refresh()
                tbNHM.Clear()
                tbMasa.Text = 0
                tbTara.Clear()
                tbRazred.Clear()
                tbRazredRid.Clear()
                Me.btnIzmeniRobu.Visible = False
                Me.btnDodajRobu.Visible = True
            End Try
        End If
    End Sub

    Private Sub dgRoba_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRoba.Click

        Me.btnDodajRobu.Visible = False
        Me.btnIzmeniRobu.Visible = True

        Try
            Dim currRowNhm As DataRow
            Dim bm As BindingManagerBase = dgRoba.BindingContext(dgRoba.DataSource, dgRoba.DataMember)
            Dim dr As DataRow = CType(bm.Current, DataRowView).Row
            GridIBK = dr(0, DataRowVersion.Current.Current).ToString()
            mIBK = GridIBK
            tbNHM.Text = dr(1, DataRowVersion.Current.Current).ToString()
            tbUtiNHM.Text = dr(2, DataRowVersion.Current.Current).ToString()
            tbMasa.Text = dr(3, DataRowVersion.Current.Current).ToString()
            tbRazred.Text = dr(4, DataRowVersion.Current.Current).ToString()
            Me.cbTipUti.Text = dr(5, DataRowVersion.Current.Current).ToString()
            tbRazredRid.Text = dr(6, DataRowVersion.Current.Current).ToString()

            tbMasa.Focus()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub fxIBK_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxIBK.Leave
        If fxIBK.Text = "" Then
            If dtKola.Rows.Count > 0 Then
                Me.fxIBK.BackColor = System.Drawing.Color.White
                Me.fxIBK.ForeColor = System.Drawing.Color.Black
                btnPrihvati.Focus()
            Else
                fxIBK.Focus()
            End If
        Else
            Me.fxIBK.BackColor = System.Drawing.Color.White
            Me.fxIBK.ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    Private Sub dgKola_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgKola.Click

        Me.btnDodajKola.Visible = False
        Me.btnIzmeniKola.Visible = True

        Dim KolaZaGrid As String

        Dim currRowKola As DataRow
        currRowKola = CType(dgKola.DataSource, DataTable).Rows(dgKola.CurrentCell.RowNumber)

        mIBK = currRowKola(0, DataRowVersion.Current).ToString()
        GridIBK = mIBK
        'KolaZaGrid = Trim(mIBK)

        mIBK = Microsoft.VisualBasic.Mid(mIBK, 1, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 3, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 5, 4) & " " & Microsoft.VisualBasic.Mid(mIBK, 9, 3) & " " & Microsoft.VisualBasic.Mid(mIBK, 12, 1)
        LocalUPD_IBK = Microsoft.VisualBasic.Mid(mIBK, 1, 2) & Microsoft.VisualBasic.Mid(mIBK, 4, 2) & Microsoft.VisualBasic.Mid(mIBK, 7, 4) & Microsoft.VisualBasic.Mid(mIBK, 12, 3) & Microsoft.VisualBasic.Mid(mIBK, 16, 1)
        fxIBK.Text = mIBK

        tbUprava.Text = currRowKola(6, DataRowVersion.Current).ToString()
        tbVlasnik.Text = currRowKola(3, DataRowVersion.Current).ToString()
        tbSerija.Text = currRowKola(4, DataRowVersion.Current).ToString()
        tbVrsta.Text = currRowKola(5, DataRowVersion.Current).ToString()
        tbOsovine.Text = currRowKola(2, DataRowVersion.Current).ToString()
        tbTara.Text = currRowKola(1, DataRowVersion.Current).ToString()
        fxGranTov.Text = currRowKola(7, DataRowVersion.Current).ToString()

        If currRowKola(8, DataRowVersion.Current).ToString() = "D" Then
            Me.chbStitnaKola.Checked = True
        Else
            Me.chbStitnaKola.Checked = False
        End If
        tbKolaNaknada.Text = currRowKola(11, DataRowVersion.Current).ToString()

        ' -----------------------------   NHM   -------------------------------------
        If dvNhm.Count > 0 Then
            'dvNhm.RowFilter = "IndBrojKola='" & KolaZaGrid & "'"
            dvNhm.RowFilter = "IndBrojKola='" & GridIBK & "'"
            dgRoba.DataSource = dvNhm
        Else
            fxIBK.Focus()
            Me.fxIBK.SelectAll()
        End If
        ' ----------------------------- end NHM -------------------------------------

    End Sub

    Private Sub btnBrisiKola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiKola.Click
        mkBrojPokusaja = 1
        If MasterAction = "New" Then
            If dtKola.Rows.Count > 0 Then
                Try
                    Dim VrednostIBK As String = dgKola.Item(dgKola.CurrentCell.RowNumber, 0)
                    Dim dr() As DataRow

                    dr = dtKola.Select("IndBrojKola = '" & VrednostIBK & "'")
                    dtKola.Rows.Remove(dr(0))

                    For Each row As DataRow In dtNhm.Select("IndBrojKola = '" & VrednostIBK & "'")
                        dtNhm.Rows.Remove(row)
                    Next
                Catch ex As Exception
                    ex.ToString()
                Finally
                    dgRoba.Refresh()
                    fxIBK.Clear()
                    tbTara.Text = 0
                    Me.chbStitnaKola.Checked = False
                    Me.fxGranTov.Clear()
                    Me.btnIzmeniKola.Visible = False
                    Me.btnDodajKola.Visible = True
                End Try
            End If
        Else 'azuriranje baze
            If dtKola.Rows.Count > 0 Then
                Try
                    '------------------------ filtrira obrisane zapise u dgKola -------------
                    Dim rowKola As Data.DataRow

                    rowKola = CType(dgKola.DataSource, DataTable).Rows(dgKola.CurrentCell.RowNumber)
                    rowKola = dtKola.Rows(dgKola.CurrentCell.RowNumber)
                    rowKola("Action") = "D"

                    dvKola.RowFilter = "Action LIKE 'U'"
                    dgKola.DataSource = dvNhm
                    dgKola.Refresh()

                    Dim VrednostIBK As String = dgKola.Item(dgKola.CurrentCell.RowNumber, 0)

                    '-----------------------------------------------------------------------


                    '------------------------ filtrira obrisane zapise u dgNhm -------------
                    Dim rowNhm As DataRow
                    For Each rowNhm In dtNhm.Rows
                        If rowNhm.Item("IndBrojKola") = VrednostIBK Then
                            rowNhm.Item("Action") = "D"
                        End If
                    Next

                    dvNhm.RowFilter = "Action LIKE 'U'"
                    dgRoba.DataSource = dvNhm
                    '-----------------------------------------------------------------------

                Catch ex As Exception
                    MsgBox(ex.ToString)

                Finally
                    dgRoba.Refresh()
                    fxIBK.Clear()
                    tbTara.Clear()
                    Me.chbStitnaKola.Checked = False
                    Me.fxGranTov.Clear()
                    Me.btnIzmeniKola.Visible = False
                    Me.btnDodajKola.Visible = True
                End Try
            End If
        End If
    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        'vrati
        'mSumaKola = dtKola.Rows.Count
        'mMasaRobe = dtNhm.Rows(0).Item(2)
        'intercontainer kalkulacija - fKalkulacija()
        'uraditi proceduru NadjiVrstuStanice() - izlaz: bVrstaStanice!!!

        'kontrola broja cifara
        Dim KolaRed As DataRow
        Dim Msg As String
        Dim Ans As MsgBoxResult
        Dim nmCheckLenIbk As Boolean = False

        For Each KolaRed In dtKola.Rows
            If Len(RTrim(KolaRed.Item("IndBrojKola"))) < 12 Then
                nmCheckLenIbk = True
                Exit For
            End If
        Next

        If nmCheckLenIbk = True Then
            Msg = "Kontrola unetih podataka" & Chr(13)
            Msg = " " & Chr(13)
            Msg = "U tabeli ""Kola"" nalaze se kola sa individualnim brojem koji ima manje od 12 cifara." & Chr(13)
            Msg = Msg & "Da li ostajete pri unetim podacima?"

            Ans = MsgBox(Msg, vbYesNo + vbInformation, "Kontrola unosa")

            If Ans = vbNo Then
                Exit Sub
            End If
        End If

        If dtKola.Rows.Count > 0 And (IzborSaobracaja = "2" Or IzborSaobracaja = "3" Or (IzborSaobracaja = "4" And mVrstaObracuna = "CO")) Then
            Kola_Validating()
            tbVlasnik.Text = mVlasnik
            KolaRed.Item("Vlasnik") = tbVlasnik.Text
            KontrolaNHM()

        End If
        If Me.chbNarocitaPosiljka.Checked = True Then
            nmNarPos = True
        Else
            nmNarPos = False
        End If

        '---------------------------
        UskladiTipKola()
        '---------------------------
        UskladiNaknadeFito()         'dodaje slog u SlogNaknade 
        '---------------------------
        UskladiNaknadePoKolima()     'postavi na nulu pa proverava
        '---------------------------
        UskladiNaknadeZaNaftu()      '2014 ok
        '---------------------------
        If Me.cbPrekoracenje.Checked = True Then
            UskladiNaknadePrekoracenje()
        End If
        '---------------------------

        mNemaTare = "0"
        'Dim KolaRed As DataRow
        For Each KolaRed In dtKola.Rows
            If KolaRed.Item("Tara") = 0 Then
                mNemaTare = "1"
            Else
                _mTara = KolaRed.Item("Tara")
            End If
            mIBK = KolaRed.Item("IndBrojKola")
        Next

        _mSMasa = 0
        Dim rowNhm As DataRow
        Dim ctrlTipUti As Boolean = True

        For Each rowNhm In dtNhm.Rows
            _mSMasa = _mSMasa + rowNhm.Item("Masa")
            _mNHM = rowNhm.Item("NHM")

            If Microsoft.VisualBasic.Left(rowNhm.Item("NHM"), 4) = "9941" Or Microsoft.VisualBasic.Left(rowNhm.Item("NHM"), 4) = "9931" Then
                If rowNhm.Item("UTI") = "0" Or rowNhm.Item("UTI") = "" Then
                    ctrlTipUti = False
                Else
                    'ctrlTipUti = True
                    _mTipUti = rowNhm.Item("UTI")

                    If ctrlTipUti <> False Then
                        ctrlTipUti = True
                    End If
                End If
            End If
        Next

        If dtKola.Rows.Count > 0 And dtNhm.Rows.Count > 0 And ctrlTipUti = True And tmp_nhm_ok = "Yes" And mNemaTare = "0" Then

            If bVrstaSaobracaja = 4 Then
                bVrstaStanice = "M"
            End If

            If mMakis = "ZA" Then
                _PraviPrelaz = mStanica2
                mStanica2 = "16201"
            ElseIf mMakis = "IZ" Then
                _PraviPrelaz = mStanica1
                mStanica1 = "16201"
            End If

            If Lomljena = "D" Then
                Dim Lom_Stanica1 As String = mStanica1
                Dim Lom_Stanica2 As String = mStanica2
                Dim Lom_btkm As Integer = bTkm

                mStanica2 = LomStanica
                bTkm = Lom_btkm1

                bNadjiPrevozninuGlavni()
                LomPrev1 = mPrevoznina

                mStanica1 = LomStanica
                mStanica2 = Lom_Stanica2
                bTkm = Lom_btkm2

                bNadjiPrevozninuGlavni()
                LomPrev2 = mPrevoznina

                mStanica1 = Lom_Stanica1
                mStanica2 = Lom_Stanica2
                bTkm = Lom_btkm
            Else
                bNadjiPrevozninuGlavni()
            End If

            If mMakis = "ZA" Then
                mStanica2 = _PraviPrelaz
            ElseIf mMakis = "IZ" Then
                mStanica1 = _PraviPrelaz
            End If

            mPrikazKalkulacije = "D"
            _OpenForm = "Roba"
            Close()
        Else
            If ctrlTipUti = False Then
                MessageBox.Show("Neispravni podaci o tipu kontejnera!", "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If tmp_nhm_ok = "No" Then
                    MessageBox.Show("NHM pozicija: " & tmp_nhm & "  ne postoji u bazi podataka!", "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    If mNemaTare = "1" Then
                        MessageBox.Show("Nedostaju podaci o tari kola! Ispravite podatke.", "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        MessageBox.Show("Niste uneli sve potrebne podatke!", "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            End If

            Me.fxIBK.Focus()

        End If
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        dtKola.Clear()
        dtNhm.Clear()
        Close()

    End Sub

    Private Sub btnIzmeniRobu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzmeniRobu.Click
        Me.btnDodajRobu.Visible = True
        Me.btnIzmeniRobu.Visible = False

        Try

            Dim Row As DataRow
            Dim bm As BindingManagerBase = dgRoba.BindingContext(dgRoba.DataSource, dgRoba.DataMember)
            Dim dr As DataRow = CType(bm.Current, DataRowView).Row

            GridIBK = dr(0, DataRowVersion.Current.Current).ToString()
            dr(0) = GridIBK
            dr(1) = tbNHM.Text
            dr(2) = tbUtiNHM.Text
            dr(3) = tbMasa.Text
            dr(4) = tbRazred.Text
            dr(5) = Microsoft.VisualBasic.Mid(cbTipUti.SelectedItem, 1, 2)
            dr(6) = tbRazredRid.Text
            dr(7) = tbUtiIB.Text
            dr(8) = tbUtiTara.Text
            dr(10) = tbPredajniList.Text
            dr(11) = tbUtiPlombe.Text

            If MasterAction = "New" Then
                dr(12) = "I"
            Else
                dr(12) = "U"
            End If

            dgRoba.Refresh()
            tbNHM.Clear()
            tbMasa.Text = 0
            Me.tbUtiTara.Text = 0
            tbRazred.Clear()
            tbRazredRid.Clear()
            tbMasa.Focus()

        Catch ex As Exception
            MsgBox("Greska : " & ex.ToString)
        End Try
    End Sub

    Private Sub tbMasa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbMasa.Validating
        If IsNumeric(tbMasa.Text) = True Then
            If CType(tbMasa.Text, Int32) = 0 Then
                If dtNhm.Rows.Count > 0 Then
                    fxIBK.Focus()
                    Label13.Text = ""
                    PictureBox1.Visible = False
                    PictureBox2.Visible = False
                    PictureBox3.Visible = False

                    tbMasa.BackColor = System.Drawing.Color.White
                    tbMasa.ForeColor = System.Drawing.Color.Black
                Else
                    ErrorProvider1.SetError(tbMasa, "Obavezan unos mase robe!")
                    tbMasa.Focus()
                End If
            Else
                If CDec(tbMasa.Text) > 50000 Then
                    Me.tbMasa.BackColor = System.Drawing.Color.Red
                    Me.tbMasa.ForeColor = System.Drawing.Color.Black
                    ErrorProvider1.SetError(tbMasa, "Proverite ispravnost podatka o masi robe!")
                Else
                    Me.tbMasa.BackColor = System.Drawing.Color.White
                    Me.tbMasa.ForeColor = System.Drawing.Color.Black
                    ErrorProvider1.SetError(tbMasa, "")
                End If
            End If
        Else
            ErrorProvider1.SetError(tbMasa, "Neispravan unos!")
            tbMasa.Focus()
        End If
    End Sub

    Private Sub btnIzmeniKola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzmeniKola.Click
        Me.btnDodajKola.Visible = True
        Me.btnIzmeniKola.Visible = False
        mkBrojPokusaja = 1

        Dim mStitna As String
        Dim row As Data.DataRow
        row = CType(dgKola.DataSource, DataTable).Rows(dgKola.CurrentCell.RowNumber)
        'row = dtKola.Rows(0)

        mIBK = Microsoft.VisualBasic.Mid(fxIBK.Text, 1, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 4, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 7, 4) & Microsoft.VisualBasic.Mid(fxIBK.Text, 12, 3) & Microsoft.VisualBasic.Mid(fxIBK.Text, 16, 1)
        GridIBK = mIBK

        'row("IndBrojKola") = mIBK
        row("IndBrojKola") = GridIBK
        row("Uprava") = tbUprava.Text
        row("Vlasnik") = tbVlasnik.Text
        row("Serija") = tbSerija.Text
        row("Vrsta") = tbVrsta.Text
        row("Osovine") = tbOsovine.Text
        row("Tara") = tbTara.Text
        row("GrTov") = fxGranTov.Text

        If Me.chbStitnaKola.Checked = True Then
            mStitna = "D"
        Else
            mStitna = "N"
        End If

        row("Stitna") = mStitna
        'row("ICF") = tbKolaNaknada.Text
        row("Naknada") = tbKolaNaknada.Text

        If MasterAction = "New" Then
            row("Action") = "I"
        Else
            row("Action") = "U"
        End If

        If dtNhm.Rows.Count > 0 Then
            Dim rowNhm As DataRow
            For Each rowNhm In dtNhm.Rows
                If rowNhm.Item("IndBrojKola") = LocalUPD_IBK Then
                    rowNhm.Item("IndBrojKola") = GridIBK
                    rowNhm.Item("Action") = "U"

                    dvNhm.RowFilter = "IndBrojKola='" & GridIBK & "'"
                    dgRoba.DataSource = dvNhm

                    Me.dgRoba.Refresh()

                End If
            Next
        End If

        '-----------------------
        fxIBK.Clear()
        tbTara.Text = 0
        Me.chbStitnaKola.Checked = False
        Me.fxGranTov.Clear()
    End Sub

    Private Sub tbMasa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMasa.GotFocus
        Me.tbMasa.BackColor = System.Drawing.Color.Gainsboro
        Me.tbMasa.ForeColor = System.Drawing.Color.Black

        'za vise unosa prikazuje istu masu i nhm 
        If dtKola.Rows.Count > 1 Then
            If tmp_FromKola = True Then
                tbMasa.Text = tmp_masa
            End If
        End If


    End Sub

    Private Sub tbMasa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMasa.LostFocus
        'tbMasa.BackColor = System.Drawing.Color.White
        'tbMasa.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbMasa_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMasa.Leave
        If tbMasa.Text = "0" Then
            'stitna kola mogu da budu sa masom 0
            If dtNhm.Rows.Count > 0 Then
                Me.fxIBK.Focus()
                'btnPrihvati.Focus()
            Else
                If dtKola.Rows.Count > 0 Then
                    'Me.fxIBK.Focus()
                    Me.tbMasa.Focus()
                    'Me.fxIBK.SelectAll()
                Else
                    Me.fxIBK.Focus()
                    Me.fxIBK.SelectAll()
                    'tbMasa.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim NarocitaPos As New NarPos
        NarocitaPos.Show()

    End Sub
    Private Sub kola_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            If dtKola.Rows.Count > 0 And dtNhm.Rows.Count > 0 Then
                If bVrstaSaobracaja = 4 Then
                    bVrstaStanice = "M"
                End If

                'bNadjiSveIzZSKoefPos(bVrstaSaobracaja, mTarifa, bVrstaPosiljke, bVrstaStanice, bVlasnistvo, bTovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetVal)
                bNadjiPrevozninuGlavni()

                mPrikazKalkulacije = "D"
                _OpenForm = "Roba"
                Close()
            Else
                MessageBox.Show("Niste uneli sve potrebne podatke!", "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.fxIBK.Focus()
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim helpNhm As New HelpForm
        helpNhm.Text = "help Nhm"
        upit = "NHM"
        helpNhm.ShowDialog()
        Me.tbNHM.Text = mIzlaz1
        ErrorProvider1.SetError(tbNHM, "")
        tbNHM.Focus()
    End Sub

    Private Sub tbUtiIB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUtiIB.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUtiTara_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUtiTara.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUtiNHM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUtiNHM.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPredajniList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPredajniList.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUtiPlombe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUtiPlombe.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxIBK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxIBK.GotFocus
        Me.fxIBK.BackColor = System.Drawing.Color.Gainsboro
        Me.fxIBK.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub fxIBK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxIBK.LostFocus
        Me.fxIBK.BackColor = System.Drawing.Color.White
        Me.fxIBK.ForeColor = System.Drawing.Color.Black

    End Sub

    Private Sub tbTara_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbTara.GotFocus
        Me.tbTara.SelectAll()
        Me.tbTara.BackColor = System.Drawing.Color.Gainsboro
        Me.tbTara.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbTara_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbTara.LostFocus
        Me.tbTara.BackColor = System.Drawing.Color.White
        Me.tbTara.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbNHM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNHM.GotFocus
        Me.tbNHM.BackColor = System.Drawing.Color.Gainsboro
        Me.tbNHM.ForeColor = System.Drawing.Color.Black
        tbNHM.Text = tmp_nhm
    End Sub

    Private Sub tbNHM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNHM.LostFocus
        Me.tbNHM.BackColor = System.Drawing.Color.White
        Me.tbNHM.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub cbTipUti_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipUti.GotFocus
        Me.cbTipUti.BackColor = System.Drawing.Color.Gainsboro
        Me.cbTipUti.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiIB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiIB.GotFocus
        Me.tbUtiIB.BackColor = System.Drawing.Color.Gainsboro
        Me.tbUtiIB.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiIB_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiIB.Leave
        Me.tbUtiIB.BackColor = System.Drawing.Color.White
        Me.tbUtiIB.ForeColor = System.Drawing.Color.Black
        If tbUtiIB.Text = "" Then
            btnDodajRobu.Focus()
        End If
    End Sub

    Private Sub tbUtiTara_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiTara.GotFocus
        Me.tbUtiTara.BackColor = System.Drawing.Color.Gainsboro
        Me.tbUtiTara.ForeColor = System.Drawing.Color.Black
    End Sub
    Private Sub tbUtiNHM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiNHM.GotFocus
        Me.tbUtiNHM.BackColor = System.Drawing.Color.Gainsboro
        Me.tbUtiNHM.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiNHM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiNHM.LostFocus
        Me.tbUtiNHM.BackColor = System.Drawing.Color.White
        Me.tbUtiNHM.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbPredajniList_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPredajniList.GotFocus
        Me.tbPredajniList.BackColor = System.Drawing.Color.Gainsboro
        Me.tbPredajniList.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbPredajniList_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPredajniList.LostFocus
        Me.tbPredajniList.BackColor = System.Drawing.Color.White
        Me.tbPredajniList.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiPlombe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiPlombe.GotFocus
        Me.tbUtiPlombe.BackColor = System.Drawing.Color.Gainsboro
        Me.tbUtiPlombe.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiPlombe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiPlombe.LostFocus
        Me.tbUtiPlombe.BackColor = System.Drawing.Color.White
        Me.tbUtiPlombe.ForeColor = System.Drawing.Color.Black
        btnDodajRobu.Focus()
    End Sub

    Private Sub tbUtiPlombe_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiPlombe.Leave
        Me.tbUtiPlombe.BackColor = System.Drawing.Color.White
        Me.tbUtiPlombe.ForeColor = System.Drawing.Color.Black
        btnDodajRobu.Focus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim helpNhm As New HelpForm
        helpNhm.Text = "help Nhm"
        upit = "NHM"
        helpNhm.ShowDialog()
        Me.tbUtiNHM.Text = mIzlaz1
        tbPredajniList.Focus()

    End Sub

    Private Sub tbTara_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbTara.Validating
        If CType(tbTara.Text, Int32) = 0 Then
            ErrorProvider1.SetError(tbTara, "Obavezan unos tare kola!")
            tbTara.Focus()
        Else
            ErrorProvider1.SetError(tbTara, "")
        End If
    End Sub

    Private Sub tbUtiTara_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUtiTara.Validating
        ''If IsNumeric(tbUtiTara.Text) = True Then
        ''    ErrorProvider1.SetError(tbUtiTara, "")
        ''Else
        ''    ErrorProvider1.SetError(tbUtiTara, "Neispravan unos!")
        ''    tbUtiTara.Focus()
        ''End If

        If CType(tbUtiTara.Text, Int32) = 0 Then
            ErrorProvider1.SetError(tbUtiTara, "Obavezan unos tare kontejnera!")
            tbUtiTara.Focus()
        Else
            ErrorProvider1.SetError(tbUtiTara, "")
        End If

    End Sub

    Private Sub tbUtiNHM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUtiNHM.Validating

        If Microsoft.VisualBasic.Left(tbNHM.Text, 4) = "9931" Then
            If Microsoft.VisualBasic.Left(tbUtiNHM.Text, 4) = "9921" Or Microsoft.VisualBasic.Left(tbUtiNHM.Text, 4) = "9922" Then
                tbUtiNHM.Focus()
            Else
                btnDodajRobu.Focus()
            End If

        Else
            If Microsoft.VisualBasic.Left(tbUtiNHM.Text, 4) <> "9921" And Microsoft.VisualBasic.Left(tbUtiNHM.Text, 4) <> "9922" Then
                If IsNumeric(tbUtiNHM.Text) = True Then

                    '-------------------------------------- old -------------------------------------------------------------------------------
                    Dim rv As String = ""
                    Dim KolaRed As DataRow

                    '1.7.2008. zbor tarifskog razreda u TEA tarifi
                    Dim tempTarifa92 As String = "00"
                    If Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" And mVrstaObracuna = "CO" Then
                        tempTarifa92 = "68"
                    Else
                        tempTarifa92 = mTarifa
                    End If

                    If DbVeza.State = ConnectionState.Closed Then
                        DbVeza.Open()
                    End If

                    Dim uspKomanda As New SqlClient.SqlCommand("NadjiNhmVER", DbVeza)
                    'Dim uspKomanda As New SqlClient.SqlCommand("NadjiNhm", DbVeza)
                    uspKomanda.CommandType = CommandType.StoredProcedure

                    Dim upSifraRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upSifraRobe", SqlDbType.Char, 6))
                    upSifraRobe.Direction = ParameterDirection.Input
                    uspKomanda.Parameters("@upSifraRobe").Value = tbUtiNHM.Text

                    Dim upTarifa As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upTarifa", SqlDbType.Char, 2))
                    upTarifa.Direction = ParameterDirection.Input
                    uspKomanda.Parameters("@upTarifa").Value = tempTarifa92 'mTarifa

                    Dim ipNazivRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipNazivRobe", SqlDbType.Char, 100))
                    ipNazivRobe.Direction = ParameterDirection.Output

                    Dim ipRazredRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRobe", SqlDbType.Char, 1))
                    ipRazredRobe.Direction = ParameterDirection.Output

                    Dim ipRazredRid As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRid", SqlDbType.Int, 2))
                    ipRazredRid.Direction = ParameterDirection.Output

                    Dim ipNhmVER As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipVER", SqlDbType.Char, 3))
                    ipNhmVER.Direction = ParameterDirection.Output

                    Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipPovratnaVrednost", SqlDbType.NVarChar, 100))
                    ipPovratnaVrednost.Direction = ParameterDirection.Output

                    Try
                        uspKomanda.ExecuteScalar()
                        If uspKomanda.Parameters("@ipPovratnaVrednost").Value = "" Then 'OK
                            StatusBar1.Text = uspKomanda.Parameters("@ipNazivRobe").Value
                            ErrorProvider1.SetError(tbNHM, "")
                            mRazred = uspKomanda.Parameters("@ipRazredRobe").Value
                            mRazredRid = uspKomanda.Parameters("@ipRazredRid").Value
                            _nmNakVER = uspKomanda.Parameters("@ipVER").Value
                            tbRazred.Text = mRazred
                            tbRazredRid.Text = mRazredRid

                            Label13.Text = ""

                            If Microsoft.VisualBasic.Left(_nmNakVER, 1) = "1" Then
                                Label13.Text = "VETERINARSKI PREGLED "
                                Label13.Visible = True
                                Me.PictureBox1.Visible = True
                            Else
                                Me.PictureBox1.Visible = False
                            End If

                            If Microsoft.VisualBasic.Mid(_nmNakVER, 2, 1) = "1" Then
                                Label13.Text = Label13.Text & "EKOLOSKI PREGLED "
                                Label13.Visible = True
                                Me.PictureBox2.Visible = True
                            Else
                                Me.PictureBox2.Visible = False
                            End If

                            If Microsoft.VisualBasic.Right(_nmNakVER, 1) = "1" Then
                                Label13.Text = Label13.Text & "RADIOLOSKI PREGLED "
                                Label13.Visible = True
                                Me.PictureBox3.Visible = True
                            Else
                                Me.PictureBox3.Visible = False
                            End If



                            'If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9931" Then
                            '    bKontejneri = True
                            'Else
                            '    bKontejneri = False
                            'End If

                            '---------------- popunjava kolonu TipKola u dgKola ------------------------
                            For Each KolaRed In dtKola.Rows
                                If mIBK = KolaRed.Item("IndBrojKola") Then
                                    If KolaRed.Item("Vlasnik") = "Z" Then
                                        If KolaRed.Item("Vrsta") = "O" Then
                                            KolaRed.Item("Tip") = "1"
                                        Else
                                            KolaRed.Item("Tip") = "2"
                                        End If
                                    Else
                                        If KolaRed.Item("Vrsta") = "O" Then
                                            If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9922" Then
                                                KolaRed.Item("Tip") = "7"
                                            Else
                                                KolaRed.Item("Tip") = "3"
                                            End If
                                        Else
                                            If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9922" Then
                                                KolaRed.Item("Tip") = "7"
                                            Else
                                                KolaRed.Item("Tip") = "4"
                                            End If
                                        End If

                                    End If
                                    If Microsoft.VisualBasic.Left(tbNHM.Text, 4) = "8604" Or Microsoft.VisualBasic.Left(tbNHM.Text, 4) = "8605" Or Microsoft.VisualBasic.Left(tbNHM.Text, 4) = "8606" Then
                                        KolaRed.Item("Tip") = "1"
                                    End If

                                End If
                            Next
                            '---------------------------------------------------------------------------

                            'otvara tip uti
                            'If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9931" Then
                            '    gbUti.Enabled = True
                            '    'cbTipUti.Enabled = True
                            '    cbTipUti.Focus()
                            '    cbTipUti.DroppedDown = True
                            'Else
                            '    gbUti.Enabled = False
                            '    btnDodajRobu.Focus()
                            'End If
                            ' ----------------------------------------
                            btnDodajRobu.Focus()

                        Else 'nije ok
                            StatusBar1.Text = ""
                            rv = uspKomanda.Parameters("@ipPovratnaVrednost").Value
                            ErrorProvider1.SetError(tbNHM, rv)
                            tbNHM.Focus()
                        End If

                    Catch SQLExp As SqlException
                        rv = SQLExp.Message & " ?"  'Greska - SQL greska
                        StatusBar1.Text = rv
                        tbNHM.Focus()

                    Catch Exp As Exception
                        rv = Err.Description & "??" 'Greska - bilo koja
                        StatusBar1.Text = rv
                        tbNHM.Focus()
                    Finally
                        DbVeza.Close()
                        uspKomanda.Dispose()
                    End Try

                    ''------------------------------------------------------------------------------------------------------------------------
                    ''1.7.2008. zbor tarifskog razreda u TEA tarifi
                    'Dim tempTarifa92 As String = "00"
                    'If Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" And mVrstaObracuna = "CO" Then
                    '    tempTarifa92 = "68"
                    'Else
                    '    tempTarifa92 = mTarifa
                    'End If

                    'If DbVeza.State = ConnectionState.Closed Then
                    '    DbVeza.Open()
                    'End If

                    'Dim uspKomanda As New SqlClient.SqlCommand("NadjiNhm", DbVeza)
                    'uspKomanda.CommandType = CommandType.StoredProcedure

                    'Dim upSifraRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upSifraRobe", SqlDbType.Char, 6))
                    'upSifraRobe.Direction = ParameterDirection.Input
                    'uspKomanda.Parameters("@upSifraRobe").Value = tbUtiNHM.Text

                    'Dim upTarifa As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upTarifa", SqlDbType.Char, 2))
                    'upTarifa.Direction = ParameterDirection.Input
                    'uspKomanda.Parameters("@upTarifa").Value = tempTarifa92 'mTarifa

                    'Dim ipNazivRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipNazivRobe", SqlDbType.Char, 100))
                    'ipNazivRobe.Direction = ParameterDirection.Output

                    'Dim ipRazredRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRobe", SqlDbType.Char, 1))
                    'ipRazredRobe.Direction = ParameterDirection.Output

                    'Dim ipRazredRid As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRid", SqlDbType.Int, 2))
                    'ipRazredRid.Direction = ParameterDirection.Output

                    'Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipPovratnaVrednost", SqlDbType.NVarChar, 100))
                    'ipPovratnaVrednost.Direction = ParameterDirection.Output

                    'Try
                    '    uspKomanda.ExecuteScalar()
                    '    If uspKomanda.Parameters("@ipPovratnaVrednost").Value = "" Then 'OK
                    '        StatusBar1.Text = uspKomanda.Parameters("@ipNazivRobe").Value
                    '        ErrorProvider1.SetError(tbUtiNHM, "")
                    '        If btnDodajRobu.Visible = True Then
                    '            btnDodajRobu.Focus()
                    '        Else
                    '            btnIzmeniRobu.Focus()
                    '        End If

                    '    Else
                    '        StatusBar1.Text = ""
                    '        rv = uspKomanda.Parameters("@ipPovratnaVrednost").Value
                    '        ErrorProvider1.SetError(tbUtiNHM, rv)
                    '        tbUtiNHM.Focus()
                    '    End If

                    'Catch SQLExp As SqlException
                    '    rv = SQLExp.Message & " ?"  'Greska - SQL greska
                    '    StatusBar1.Text = rv
                    '    tbUtiNHM.Focus()

                    'Catch Exp As Exception
                    '    rv = Err.Description & "??" 'Greska - bilo koja
                    '    StatusBar1.Text = rv
                    '    tbUtiNHM.Focus()
                    'Finally
                    '    DbVeza.Close()
                    '    uspKomanda.Dispose()
                    'End Try

                Else
                    ErrorProvider1.SetError(tbUtiNHM, "Neispravan unos!")
                    If tbUtiNHM.Text = Nothing Then
                        tbNHM.Focus()
                    End If
                End If

            Else
                ErrorProvider1.SetError(tbUtiNHM, "Neispravan unos!")
                tbUtiNHM.Focus()

            End If

        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim KolaNotFound As New KolaExtra
        KolaNotFound.ShowDialog()

        tbVlasnik.Text = mVlasnik
        tbSerija.Text = mSerija
        tbVrsta.Text = mVrsta
        tbOsovine.Text = mOsovine
        Me.tbTara.Focus()
    End Sub
    'Format dgKola i dgRoba za kasnije
    'Public Sub AutoSizeDgKola()

    '    Dim numCols As Integer
    '    numCols = CType(dgKola.DataSource, DataTable).Columns.Count
    '    Dim i As Integer
    '    i = 0
    '    Do While (i < numCols)
    '        AutoSizeColDgKola(i)
    '        i = (i + 1)
    '    Loop
    'End Sub
    'Public Sub AutoSizeColDgKola(ByVal col As Integer)
    '    Dim width As Single
    '    width = 0
    '    Dim numRows As Integer
    '    numRows = CType(dgKola.DataSource, DataTable).Rows.Count
    '    Dim g As Graphics
    '    g = Graphics.FromHwnd(dgKola.Handle)
    '    Dim sf As StringFormat
    '    sf = New StringFormat(StringFormat.GenericTypographic)
    '    Dim size As SizeF
    '    Dim i As Integer
    '    i = 0

    '    Do While (i < numRows)
    '        size = g.MeasureString(dgKola(i, col).ToString, dgKola.Font, 500, sf)
    '        If (size.Width > width) Then
    '            width = size.Width + 20  'BILO JE 10
    '        End If
    '        i = (i + 1)

    '    Loop
    '    g.Dispose()
    '    dgKola.TableStyles("SuperGrid").GridColumnStyles(col).Width = CType(width, Integer)
    'End Sub
    'Public Sub AutoSizeDgRoba()

    '    Dim numCols As Integer
    '    numCols = CType(dgRoba.DataSource, DataTable).Columns.Count
    '    Dim i As Integer
    '    i = 0
    '    Do While (i < numCols)
    '        AutoSizeColDgRoba(i)
    '        i = (i + 1)
    '    Loop
    'End Sub
    'Public Sub AutoSizeColDgRoba(ByVal col As Integer)
    '    Dim width As Single
    '    width = 0
    '    Dim numRows As Integer
    '    numRows = CType(dgRoba.DataSource, DataTable).Rows.Count
    '    Dim g As Graphics
    '    g = Graphics.FromHwnd(dgRoba.Handle)
    '    Dim sf As StringFormat
    '    sf = New StringFormat(StringFormat.GenericTypographic)
    '    Dim size As SizeF
    '    Dim i As Integer
    '    i = 0

    '    Do While (i < numRows)
    '        size = g.MeasureString(dgRoba(i, col).ToString, dgRoba.Font, 500, sf)
    '        If (size.Width > width) Then
    '            width = size.Width + 20  'BILO JE 10
    '        End If
    '        i = (i + 1)

    '    Loop
    '    g.Dispose()
    '    dgRoba.TableStyles("SuperGrid").GridColumnStyles(col).Width = CType(width, Integer)
    'End Sub

    Private Sub btnDodajKola_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDodajKola.GotFocus
        Me.btnDodajKola.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnDodajKola_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDodajKola.Leave
        Me.btnDodajKola.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnDodajRobu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDodajRobu.GotFocus
        Me.btnDodajRobu.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnDodajRobu_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDodajRobu.Leave
        Me.btnDodajRobu.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnPrihvati_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrihvati.GotFocus
        Me.btnPrihvati.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnPrihvati_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrihvati.Leave
        Me.btnPrihvati.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnIzmeniKola_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIzmeniKola.GotFocus
        Me.btnIzmeniKola.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnIzmeniKola_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIzmeniKola.Leave
        Me.btnIzmeniKola.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnIzmeniRobu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIzmeniRobu.GotFocus
        Me.btnIzmeniRobu.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnIzmeniRobu_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIzmeniRobu.Leave
        Me.btnIzmeniRobu.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub tbUtiTara_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiTara.Leave
        Me.tbUtiTara.BackColor = System.Drawing.Color.White
        Me.tbUtiTara.ForeColor = System.Drawing.Color.Black
        btnDodajRobu.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Kola_Validating()
        KontrolaNHM()

    End Sub
    Public Sub KontrolaNHM()

        Dim rv As String = ""
        Dim RobaRed As DataRow

        '1.7.2008. zbor tarifskog razreda u TEA tarifi
        Dim tempTarifa92 As String = "00"
        If Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" And mVrstaObracuna = "CO" Then
            tempTarifa92 = "68"
        Else
            tempTarifa92 = mTarifa
        End If

        tmp_nhm_ok = "Yes"
        For Each RobaRed In dtNhm.Rows
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            Dim uspKomanda As New SqlClient.SqlCommand("NadjiNhm", DbVeza)
            uspKomanda.CommandType = CommandType.StoredProcedure

            Dim upSifraRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upSifraRobe", SqlDbType.Char, 6))
            upSifraRobe.Direction = ParameterDirection.Input

            'tmp_nhm_ok = "Yes"
            'For Each RobaRed In dtNhm.Rows
            'tmp_nhm = RobaRed.Item("NHM")

            uspKomanda.Parameters("@upSifraRobe").Value() = RobaRed.Item("NHM") 'tmp_nhm

            Dim upTarifa As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upTarifa", SqlDbType.Char, 2))
            upTarifa.Direction = ParameterDirection.Input
            uspKomanda.Parameters("@upTarifa").Value = tempTarifa92 'mTarifa

            Dim ipNazivRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipNazivRobe", SqlDbType.Char, 100))
            ipNazivRobe.Direction = ParameterDirection.Output

            Dim ipRazredRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRobe", SqlDbType.Char, 1))
            ipRazredRobe.Direction = ParameterDirection.Output

            Dim ipRazredRid As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRazredRid", SqlDbType.Int, 2))
            ipRazredRid.Direction = ParameterDirection.Output

            Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipPovratnaVrednost", SqlDbType.NVarChar, 100))
            ipPovratnaVrednost.Direction = ParameterDirection.Output

            Try
                uspKomanda.ExecuteScalar()

                If uspKomanda.Parameters("@ipPovratnaVrednost").Value = "" Then 'OK
                    mRazred = uspKomanda.Parameters("@ipRazredRobe").Value
                    RobaRed.Item("R") = mRazred
                    'For Each RobaRed In dtNhm.Rows
                    '    RobaRed.Item("R") = mRazred
                    'Next
                Else 'nije ok
                    tmp_nhm_ok = "No"
                    tmp_nhm = RobaRed.Item("NHM")
                    'StatusBar1.Text = "Nije uspostavljena veza sa bazom."
                End If
            Catch SQLExp As SqlException
                rv = SQLExp.Message
                StatusBar1.Text = "Nije uspostavljena veza sa bazom: " & rv

            Catch Exp As Exception
                rv = Err.Description
                StatusBar1.Text = "Nije uspostavljena veza sa bazom: " & rv
                tbNHM.Focus()
            Finally
                DbVeza.Close()
                uspKomanda.Dispose()
            End Try
        Next

    End Sub

    Private Sub chbNarocitaPosiljka_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbNarocitaPosiljka.Click
        If chbNarocitaPosiljka.Checked Then
            Dim NarocitaPos As New NarPos
            NarocitaPos.ShowDialog()

            'Me.Panel2.Visible = True

            'Me.lblZSNP.Text = nmBrTelegram
            'Me.lblNPUvecanje.Text = CStr(bNPKoef * 100 - 100) + " %"
            'Me.lblNPUkupno.Text = bNPUkupno

        Else
            Me.Panel2.Visible = False

            nmNarPos = False
            nmBrTelegram = ""
            bNPUkupno = 1
            bNPKoef = 1
            bNPDodatak = 0
        End If

    End Sub

    Private Sub cbTipUti_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTipUti.Validating
        If cbTipUti.Text = Nothing Then
            cbTipUti.Focus()
        End If
    End Sub

    Private Sub cbTipUti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipUti.LostFocus
        If cbTipUti.Text = Nothing Then
            cbTipUti.Focus()
        End If
    End Sub


    Private Sub kola_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Len(nmBrTelegram) > 0 Then
            Me.Panel2.Visible = True
            Me.chbNarocitaPosiljka.Checked = True

            Me.lblZSNP.Text = nmBrTelegram
            Me.lblNPUvecanje.Text = CStr(bNPKoef * 100 - 100) + " %"
            Me.lblNPUkupno.Text = bNPUkupno
        Else
            Me.Panel2.Visible = False
            Me.chbNarocitaPosiljka.Checked = False
            nmNarPos = False
            nmBrTelegram = ""
            bNPUkupno = 1
            bNPKoef = 1
            bNPDodatak = 0
        End If

    End Sub

    Private Sub dgKola_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgKola.CurrentCellChanged
        tbVlasnik.Text = dgKola.Item(dgKola.CurrentRowIndex, 5)
    End Sub
End Class
