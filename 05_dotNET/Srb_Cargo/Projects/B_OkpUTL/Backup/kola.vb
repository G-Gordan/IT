Imports System.Data.SqlClient
Public Class kola
    Inherits System.Windows.Forms.Form
    Public GridIBK As String = ""
    Public dvKola As New DataView(dtKola)
    Public dvNhm As New DataView(dtNhm)
    ''''''Public mBrojPokusaja As Int16 = 1
    Public mkBrojPokusaja As Int16 = 1
    Public mTaraZbogP As Int32 = 0


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
    Friend WithEvents tbUprava As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents tbMasaDec As System.Windows.Forms.TextBox
    Friend WithEvents chbLokomotiva As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chbNarocitaPosiljka As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chbKolaSaNarocitomPosiljkom As System.Windows.Forms.CheckBox
    Friend WithEvents cb35Posto As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbNepokrivenaMasa As System.Windows.Forms.TextBox
    Friend WithEvents chbPorekloRobe As System.Windows.Forms.CheckBox
    Friend WithEvents lblKontBroj As System.Windows.Forms.Label
    Friend WithEvents lblKB As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(kola))
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbRbrKola = New System.Windows.Forms.TextBox
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbUprava = New System.Windows.Forms.TextBox
        Me.tbVlasnik = New System.Windows.Forms.TextBox
        Me.lblKB = New System.Windows.Forms.Label
        Me.lblKontBroj = New System.Windows.Forms.Label
        Me.chbKolaSaNarocitomPosiljkom = New System.Windows.Forms.CheckBox
        Me.chbLokomotiva = New System.Windows.Forms.CheckBox
        Me.tbMasaDec = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.gbUti = New System.Windows.Forms.GroupBox
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
        Me.cbTipUti = New System.Windows.Forms.ComboBox
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
        Me.fxIBK = New FlxMaskBox.FlexMaskEditBox
        Me.fxGranTov = New FlxMaskBox.FlexMaskEditBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.tbKolaNaknada = New System.Windows.Forms.TextBox
        Me.btnBrisiRobu = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.tbRazred = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.tbRazredRid = New System.Windows.Forms.TextBox
        Me.tbNHM = New System.Windows.Forms.TextBox
        Me.btnDodajKola = New System.Windows.Forms.Button
        Me.btnIzmeniKola = New System.Windows.Forms.Button
        Me.btnDodajRobu = New System.Windows.Forms.Button
        Me.btnIzmeniRobu = New System.Windows.Forms.Button
        Me.tbMasa = New System.Windows.Forms.TextBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.chbPorekloRobe = New System.Windows.Forms.CheckBox
        Me.dgKola = New System.Windows.Forms.DataGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgRoba = New System.Windows.Forms.DataGrid
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.tbSumaKola = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.chbNarocitaPosiljka = New System.Windows.Forms.CheckBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cb35Posto = New System.Windows.Forms.CheckBox
        Me.tbNepokrivenaMasa = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.gbUti.SuspendLayout()
        CType(Me.dgKola, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgRoba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Ukupno unetih kola"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbRbrKola
        '
        Me.tbRbrKola.Enabled = False
        Me.tbRbrKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbRbrKola.Location = New System.Drawing.Point(160, 16)
        Me.tbRbrKola.MaxLength = 2
        Me.tbRbrKola.Name = "tbRbrKola"
        Me.tbRbrKola.Size = New System.Drawing.Size(32, 23)
        Me.tbRbrKola.TabIndex = 4
        Me.tbRbrKola.Text = ""
        Me.tbRbrKola.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.GroupBox1.Controls.Add(Me.lblKB)
        Me.GroupBox1.Controls.Add(Me.lblKontBroj)
        Me.GroupBox1.Controls.Add(Me.chbKolaSaNarocitomPosiljkom)
        Me.GroupBox1.Controls.Add(Me.chbLokomotiva)
        Me.GroupBox1.Controls.Add(Me.tbMasaDec)
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
        Me.GroupBox1.Controls.Add(Me.fxIBK)
        Me.GroupBox1.Controls.Add(Me.fxGranTov)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.tbKolaNaknada)
        Me.GroupBox1.Controls.Add(Me.btnBrisiRobu)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.tbRazred)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.tbRazredRid)
        Me.GroupBox1.Controls.Add(Me.tbNHM)
        Me.GroupBox1.Controls.Add(Me.btnDodajKola)
        Me.GroupBox1.Controls.Add(Me.btnIzmeniKola)
        Me.GroupBox1.Controls.Add(Me.btnDodajRobu)
        Me.GroupBox1.Controls.Add(Me.btnIzmeniRobu)
        Me.GroupBox1.Controls.Add(Me.tbMasa)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 576)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'tbUprava
        '
        Me.tbUprava.Enabled = False
        Me.tbUprava.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUprava.Location = New System.Drawing.Point(277, 43)
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
        Me.tbVlasnik.Location = New System.Drawing.Point(278, 21)
        Me.tbVlasnik.MaxLength = 1
        Me.tbVlasnik.Name = "tbVlasnik"
        Me.tbVlasnik.Size = New System.Drawing.Size(24, 20)
        Me.tbVlasnik.TabIndex = 37
        Me.tbVlasnik.Text = ""
        Me.tbVlasnik.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblKB
        '
        Me.lblKB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblKB.Location = New System.Drawing.Point(256, 23)
        Me.lblKB.Name = "lblKB"
        Me.lblKB.Size = New System.Drawing.Size(24, 23)
        Me.lblKB.TabIndex = 504
        Me.lblKB.Text = "[  ]"
        Me.lblKB.Visible = False
        '
        'lblKontBroj
        '
        Me.lblKontBroj.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblKontBroj.Location = New System.Drawing.Point(240, 48)
        Me.lblKontBroj.Name = "lblKontBroj"
        Me.lblKontBroj.Size = New System.Drawing.Size(14, 23)
        Me.lblKontBroj.TabIndex = 503
        Me.lblKontBroj.Visible = False
        '
        'chbKolaSaNarocitomPosiljkom
        '
        Me.chbKolaSaNarocitomPosiljkom.ContextMenu = Me.ContextMenu1
        Me.chbKolaSaNarocitomPosiljkom.Cursor = System.Windows.Forms.Cursors.Help
        Me.chbKolaSaNarocitomPosiljkom.Enabled = False
        Me.chbKolaSaNarocitomPosiljkom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chbKolaSaNarocitomPosiljkom.Location = New System.Drawing.Point(272, 128)
        Me.chbKolaSaNarocitomPosiljkom.Name = "chbKolaSaNarocitomPosiljkom"
        Me.chbKolaSaNarocitomPosiljkom.Size = New System.Drawing.Size(128, 32)
        Me.chbKolaSaNarocitomPosiljkom.TabIndex = 502
        Me.chbKolaSaNarocitomPosiljkom.Text = "Kola sa naroèitom pošiljkom"
        Me.chbKolaSaNarocitomPosiljkom.Visible = False
        '
        'chbLokomotiva
        '
        Me.chbLokomotiva.Location = New System.Drawing.Point(13, 46)
        Me.chbLokomotiva.Name = "chbLokomotiva"
        Me.chbLokomotiva.Size = New System.Drawing.Size(96, 23)
        Me.chbLokomotiva.TabIndex = 501
        Me.chbLokomotiva.Text = "Lokomotiva"
        '
        'tbMasaDec
        '
        Me.tbMasaDec.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbMasaDec.Location = New System.Drawing.Point(149, 231)
        Me.tbMasaDec.Name = "tbMasaDec"
        Me.tbMasaDec.TabIndex = 5
        Me.tbMasaDec.Text = ""
        Me.tbMasaDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(5, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 24)
        Me.Button3.TabIndex = 50
        Me.Button3.Text = "Individualni broj kola"
        '
        'gbUti
        '
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
        Me.gbUti.Controls.Add(Me.cbTipUti)
        Me.gbUti.Controls.Add(Me.Label3)
        Me.gbUti.Location = New System.Drawing.Point(8, 314)
        Me.gbUti.Name = "gbUti"
        Me.gbUti.Size = New System.Drawing.Size(392, 200)
        Me.gbUti.TabIndex = 7
        Me.gbUti.TabStop = False
        Me.gbUti.Text = "[ UTI ] "
        '
        'tbUtiPlombe
        '
        Me.tbUtiPlombe.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUtiPlombe.Location = New System.Drawing.Point(140, 164)
        Me.tbUtiPlombe.MaxLength = 12
        Me.tbUtiPlombe.Name = "tbUtiPlombe"
        Me.tbUtiPlombe.Size = New System.Drawing.Size(232, 23)
        Me.tbUtiPlombe.TabIndex = 5
        Me.tbUtiPlombe.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 164)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 23)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Broj plombe"
        '
        'tbPredajniList
        '
        Me.tbPredajniList.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPredajniList.Location = New System.Drawing.Point(140, 136)
        Me.tbPredajniList.MaxLength = 10
        Me.tbPredajniList.Name = "tbPredajniList"
        Me.tbPredajniList.Size = New System.Drawing.Size(232, 23)
        Me.tbPredajniList.TabIndex = 4
        Me.tbPredajniList.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 23)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Predajni list br."
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Help
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Location = New System.Drawing.Point(16, 109)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 20)
        Me.Button2.TabIndex = 53
        Me.Button2.Text = "NHM"
        '
        'tbUtiNHM
        '
        Me.tbUtiNHM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUtiNHM.Location = New System.Drawing.Point(140, 108)
        Me.tbUtiNHM.MaxLength = 6
        Me.tbUtiNHM.Name = "tbUtiNHM"
        Me.tbUtiNHM.Size = New System.Drawing.Size(106, 23)
        Me.tbUtiNHM.TabIndex = 3
        Me.tbUtiNHM.Text = ""
        Me.tbUtiNHM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(259, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 23)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "[ kg ]"
        '
        'tbUtiTara
        '
        Me.tbUtiTara.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUtiTara.Location = New System.Drawing.Point(140, 80)
        Me.tbUtiTara.MaxLength = 5
        Me.tbUtiTara.Name = "tbUtiTara"
        Me.tbUtiTara.Size = New System.Drawing.Size(104, 23)
        Me.tbUtiTara.TabIndex = 2
        Me.tbUtiTara.Text = "0"
        Me.tbUtiTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tara kontenera"
        '
        'tbUtiIB
        '
        Me.tbUtiIB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbUtiIB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUtiIB.Location = New System.Drawing.Point(140, 50)
        Me.tbUtiIB.MaxLength = 11
        Me.tbUtiIB.Name = "tbUtiIB"
        Me.tbUtiIB.Size = New System.Drawing.Size(232, 23)
        Me.tbUtiIB.TabIndex = 1
        Me.tbUtiIB.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Individualni broj"
        '
        'cbTipUti
        '
        Me.cbTipUti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipUti.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbTipUti.Items.AddRange(New Object() {"10  20'   6.15  ", "20   -      6.16 -  7.82", "30  30'   7.83 -  9.15", "40  35'   9.16 - 10.90", "50  40'  10.91- 13.75", "70          Poluprikolice"})
        Me.cbTipUti.Location = New System.Drawing.Point(140, 18)
        Me.cbTipUti.Name = "cbTipUti"
        Me.cbTipUti.Size = New System.Drawing.Size(232, 24)
        Me.cbTipUti.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tip"
        '
        'tbVrsta
        '
        Me.tbVrsta.Enabled = False
        Me.tbVrsta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbVrsta.Location = New System.Drawing.Point(303, 21)
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
        Me.tbOsovine.Location = New System.Drawing.Point(375, 43)
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
        Me.tbSerija.Location = New System.Drawing.Point(327, 21)
        Me.tbSerija.MaxLength = 11
        Me.tbSerija.Name = "tbSerija"
        Me.tbSerija.Size = New System.Drawing.Size(72, 20)
        Me.tbSerija.TabIndex = 38
        Me.tbSerija.Text = ""
        Me.tbSerija.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(272, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(24, 23)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "[ t ]"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(272, 73)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 23)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "[ kg ]"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 103)
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
        Me.tbTara.MaxLength = 5
        Me.tbTara.Name = "tbTara"
        Me.tbTara.Size = New System.Drawing.Size(104, 23)
        Me.tbTara.TabIndex = 1
        Me.tbTara.Text = "0"
        Me.tbTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(9, 73)
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
        Me.fxGranTov.Text = "0"
        Me.fxGranTov.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(9, 136)
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
        Me.btnBrisiRobu.Location = New System.Drawing.Point(224, 520)
        Me.btnBrisiRobu.Name = "btnBrisiRobu"
        Me.btnBrisiRobu.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiRobu.TabIndex = 10
        Me.btnBrisiRobu.Text = "Brisi"
        Me.btnBrisiRobu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(12, 238)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 23)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Masa robe"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Help
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 261)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 20)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "NHM"
        '
        'tbRazred
        '
        Me.tbRazred.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbRazred.Enabled = False
        Me.tbRazred.Location = New System.Drawing.Point(276, 259)
        Me.tbRazred.Name = "tbRazred"
        Me.tbRazred.Size = New System.Drawing.Size(32, 21)
        Me.tbRazred.TabIndex = 47
        Me.tbRazred.Text = ""
        Me.tbRazred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(272, 230)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 23)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "[ kg ]"
        '
        'tbRazredRid
        '
        Me.tbRazredRid.Enabled = False
        Me.tbRazredRid.Location = New System.Drawing.Point(324, 259)
        Me.tbRazredRid.Name = "tbRazredRid"
        Me.tbRazredRid.Size = New System.Drawing.Size(32, 21)
        Me.tbRazredRid.TabIndex = 48
        Me.tbRazredRid.Text = ""
        Me.tbRazredRid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbNHM
        '
        Me.tbNHM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNHM.Location = New System.Drawing.Point(148, 259)
        Me.tbNHM.MaxLength = 6
        Me.tbNHM.Name = "tbNHM"
        Me.tbNHM.Size = New System.Drawing.Size(106, 23)
        Me.tbNHM.TabIndex = 6
        Me.tbNHM.Text = ""
        Me.tbNHM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDodajKola
        '
        Me.btnDodajKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodajKola.Image = CType(resources.GetObject("btnDodajKola.Image"), System.Drawing.Image)
        Me.btnDodajKola.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodajKola.Location = New System.Drawing.Point(148, 167)
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
        Me.btnIzmeniKola.Location = New System.Drawing.Point(148, 167)
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
        Me.btnDodajRobu.Location = New System.Drawing.Point(152, 520)
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
        Me.btnIzmeniRobu.Location = New System.Drawing.Point(152, 520)
        Me.btnIzmeniRobu.Name = "btnIzmeniRobu"
        Me.btnIzmeniRobu.Size = New System.Drawing.Size(62, 48)
        Me.btnIzmeniRobu.TabIndex = 9
        Me.btnIzmeniRobu.Text = "Izmeni"
        Me.btnIzmeniRobu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIzmeniRobu.Visible = False
        '
        'tbMasa
        '
        Me.tbMasa.BackColor = System.Drawing.Color.White
        Me.tbMasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbMasa.Location = New System.Drawing.Point(8, 520)
        Me.tbMasa.MaxLength = 5
        Me.tbMasa.Name = "tbMasa"
        Me.tbMasa.Size = New System.Drawing.Size(88, 23)
        Me.tbMasa.TabIndex = 500
        Me.tbMasa.Text = "0"
        Me.tbMasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbMasa.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"1 - vaganjem", "2 - preko jed. mase"})
        Me.ComboBox1.Location = New System.Drawing.Point(72, 544)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(64, 24)
        Me.ComboBox1.TabIndex = 53
        Me.ComboBox1.Visible = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 544)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 32)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Masa utvrdjena"
        Me.Label8.Visible = False
        '
        'chbPorekloRobe
        '
        Me.chbPorekloRobe.Checked = True
        Me.chbPorekloRobe.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPorekloRobe.ContextMenu = Me.ContextMenu1
        Me.chbPorekloRobe.Cursor = System.Windows.Forms.Cursors.Help
        Me.chbPorekloRobe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chbPorekloRobe.Location = New System.Drawing.Point(816, 8)
        Me.chbPorekloRobe.Name = "chbPorekloRobe"
        Me.chbPorekloRobe.Size = New System.Drawing.Size(160, 32)
        Me.chbPorekloRobe.TabIndex = 503
        Me.chbPorekloRobe.Text = "Roba domaæeg porekla"
        '
        'dgKola
        '
        Me.dgKola.AllowSorting = False
        Me.dgKola.CaptionText = "Kola"
        Me.dgKola.DataMember = ""
        Me.dgKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.dgKola.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKola.Location = New System.Drawing.Point(8, 16)
        Me.dgKola.Name = "dgKola"
        Me.dgKola.PreferredColumnWidth = 100
        Me.dgKola.Size = New System.Drawing.Size(536, 200)
        Me.dgKola.TabIndex = 24
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgRoba)
        Me.GroupBox2.Controls.Add(Me.dgKola)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(432, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(552, 504)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'dgRoba
        '
        Me.dgRoba.AllowSorting = False
        Me.dgRoba.CaptionText = "Roba na kolima"
        Me.dgRoba.DataMember = ""
        Me.dgRoba.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.dgRoba.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgRoba.Location = New System.Drawing.Point(8, 232)
        Me.dgRoba.Name = "dgRoba"
        Me.dgRoba.PreferredColumnWidth = 100
        Me.dgRoba.Size = New System.Drawing.Size(536, 264)
        Me.dgRoba.TabIndex = 45
        '
        'StatusBar1
        '
        Me.StatusBar1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.StatusBar1.Location = New System.Drawing.Point(0, 644)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(1016, 22)
        Me.StatusBar1.TabIndex = 19
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(792, 552)
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
        Me.btnOtkazi.Location = New System.Drawing.Point(896, 552)
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
        Me.tbSumaKola.Location = New System.Drawing.Point(216, 16)
        Me.tbSumaKola.MaxLength = 2
        Me.tbSumaKola.Name = "tbSumaKola"
        Me.tbSumaKola.Size = New System.Drawing.Size(26, 21)
        Me.tbSumaKola.TabIndex = 25
        Me.tbSumaKola.Text = ""
        Me.tbSumaKola.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(200, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(10, 23)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = " / "
        Me.Label18.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label9
        '
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(248, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 23)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Zbir stv. masa"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(344, 16)
        Me.TextBox1.MaxLength = 2
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(88, 22)
        Me.TextBox1.TabIndex = 39
        Me.TextBox1.Text = ""
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Enabled = False
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(432, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 23)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "kg"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AllowDrop = True
        Me.Label19.Enabled = False
        Me.Label19.Location = New System.Drawing.Point(128, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 16)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "Uveæanje"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label19.Visible = False
        '
        'Label20
        '
        Me.Label20.Enabled = False
        Me.Label20.Location = New System.Drawing.Point(232, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 16)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Ukupno kola"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label20.Visible = False
        '
        'chbNarocitaPosiljka
        '
        Me.chbNarocitaPosiljka.ContextMenu = Me.ContextMenu1
        Me.chbNarocitaPosiljka.Cursor = System.Windows.Forms.Cursors.Help
        Me.chbNarocitaPosiljka.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chbNarocitaPosiljka.Location = New System.Drawing.Point(8, 16)
        Me.chbNarocitaPosiljka.Name = "chbNarocitaPosiljka"
        Me.chbNarocitaPosiljka.Size = New System.Drawing.Size(120, 16)
        Me.chbNarocitaPosiljka.TabIndex = 9
        Me.chbNarocitaPosiljka.Text = "Naroèita pošiljka"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(184, 13)
        Me.TextBox2.MaxLength = 5
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(32, 23)
        Me.TextBox2.TabIndex = 42
        Me.TextBox2.Text = "0"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox2.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(304, 13)
        Me.TextBox3.MaxLength = 5
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(32, 23)
        Me.TextBox3.TabIndex = 44
        Me.TextBox3.Text = "0"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox3.Visible = False
        '
        'Label21
        '
        Me.Label21.AllowDrop = True
        Me.Label21.Enabled = False
        Me.Label21.Location = New System.Drawing.Point(216, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 16)
        Me.Label21.TabIndex = 45
        Me.Label21.Text = "[%]"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label21.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.chbNarocitaPosiljka)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(456, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(344, 40)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        '
        'cb35Posto
        '
        Me.cb35Posto.ContextMenu = Me.ContextMenu1
        Me.cb35Posto.Cursor = System.Windows.Forms.Cursors.Help
        Me.cb35Posto.Enabled = False
        Me.cb35Posto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cb35Posto.Location = New System.Drawing.Point(448, 592)
        Me.cb35Posto.Name = "cb35Posto"
        Me.cb35Posto.Size = New System.Drawing.Size(184, 16)
        Me.cb35Posto.TabIndex = 47
        Me.cb35Posto.Text = "Povlastica 35% za sva kola"
        Me.cb35Posto.Visible = False
        '
        'tbNepokrivenaMasa
        '
        Me.tbNepokrivenaMasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNepokrivenaMasa.Location = New System.Drawing.Point(584, 560)
        Me.tbNepokrivenaMasa.Name = "tbNepokrivenaMasa"
        Me.tbNepokrivenaMasa.Size = New System.Drawing.Size(96, 23)
        Me.tbNepokrivenaMasa.TabIndex = 48
        Me.tbNepokrivenaMasa.Text = ""
        Me.tbNepokrivenaMasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(448, 560)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 23)
        Me.Label22.TabIndex = 49
        Me.Label22.Text = "Nepokrivena masa"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'kola
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1016, 666)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.tbNepokrivenaMasa)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.tbSumaKola)
        Me.Controls.Add(Me.tbRbrKola)
        Me.Controls.Add(Me.chbPorekloRobe)
        Me.Controls.Add(Me.cb35Posto)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "kola"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ": Unos podataka o kolima i robi :"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.gbUti.ResumeLayout(False)
        CType(Me.dgKola, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgRoba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim nhm As DataSet
    Dim kola As DataSet
    Dim mUprava As String
    'Dim mICF As String = "NeNP" ' koristi se kao indikator za narocite posiljke po kolima za UTL
    Dim mICF As String = "N" ' koristi se kao indikator za narocite posiljke po kolima za UTL
    Dim mx_nhm As String
    Dim IBK_PreIzmene As String

    Private Sub kola_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatKolaGrid()
        FormatNhmGrid()

        tbNepokrivenaMasa.Text = bNepokrivenaMasa

        Me.tbRbrKola.Text = dtKola.Rows.Count

        If IzborSaobracaja = "1" And eWebRazmena = "Da" Then
            Kola_eValidating()
        End If

        Dim UkStvMasa As Decimal
        bNadjiZbirStvarnihMasa(UkStvMasa)
        If UkStvMasa > 0 Then
            TextBox1.Text = UkStvMasa
        End If


        If bNarocitaPosiljka = True Then
            chbNarocitaPosiljka.Checked = True
            Me.Label19.Enabled = True
            Me.Label19.Visible = True
            Me.Label20.Enabled = True
            Me.Label20.Visible = True
            Me.Label21.Enabled = True
            Me.Label21.Visible = True
            Me.TextBox2.Enabled = True
            Me.TextBox2.Visible = True
            Me.TextBox3.Enabled = True
            Me.TextBox3.Visible = True
            Me.TextBox2.Text = CInt(100 * (bNPKoef - 1))
            Me.TextBox3.Text = bNPUkupno
        End If

        Me.cbTipUti.Items.Clear()
        If bVrstaSaobracaja = 0 Then
            Me.cbTipUti.Items.Add("20 stopa")
            Me.cbTipUti.Items.Add("30 stopa")
            Me.cbTipUti.Items.Add("40 stopa")
        Else
            Me.cbTipUti.Items.Add("10    20 stopa                 -  6.15m")
            Me.cbTipUti.Items.Add("20           -                6.16 -  7.82m")
            Me.cbTipUti.Items.Add("30    30 stopa       7.83 -   9.15m")
            Me.cbTipUti.Items.Add("40    35 stopa       9.16 - 10.90m")
            Me.cbTipUti.Items.Add("50    40 stopa     10.91 - 13.75m")
            Me.cbTipUti.Items.Add("70           -               poluprikolice")
        End If

        If b35Posto Then
            Me.cb35Posto.Enabled = True
            Me.cb35Posto.Visible = True
            Me.cb35Posto.Checked = True
        Else
            Me.cb35Posto.Enabled = False
            Me.cb35Posto.Visible = False
            Me.cb35Posto.Checked = False
        End If


        If bTarifa72 = 91 Then
            Me.Label22.Visible = True
            Me.tbNepokrivenaMasa.Visible = True
            Me.tbNepokrivenaMasa.Text = bNepokrivenaMasa            
        Else
            Me.Label22.Visible = False
            Me.tbNepokrivenaMasa.Visible = False
            Me.tbNepokrivenaMasa.Text = ""
            bNepokrivenaMasa = 0
        End If


        '''''''''''fxIBK.Text = Microsoft.VisualBasic.Mid(mIBK, 1, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 3, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 5, 4) & " " & Microsoft.VisualBasic.Mid(mIBK, 9, 3) & " " & Microsoft.VisualBasic.Mid(mIBK, 12, 1)
        If _TL_Kola = 1 Then
            fxIBK.Focus()
        Else
            Dim currRowKola As DataRow
            currRowKola = CType(dgKola.DataSource, DataTable).Rows(dgKola.CurrentCell.RowNumber)
            mIBK = currRowKola(0, DataRowVersion.Current).ToString()
            tbMasa.Focus()
        End If


        If bPorekloRobe = 0 Then
            chbPorekloRobe.Checked = True
        Else
            chbPorekloRobe.Checked = False
        End If
        If bVrstaSaobracaja = 0 Then
            chbPorekloRobe.Visible = True
            chbPorekloRobe.Enabled = True
        Else
            chbPorekloRobe.Visible = False
            chbPorekloRobe.Enabled = False
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

            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            Dim uspKomanda As New SqlClient.SqlCommand("NadjiNhm", DbVeza)
            uspKomanda.CommandType = CommandType.StoredProcedure

            Dim upSifraRobe As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upSifraRobe", SqlDbType.Char, 6))
            upSifraRobe.Direction = ParameterDirection.Input
            uspKomanda.Parameters("@upSifraRobe").Value = tbNHM.Text

            Dim upTarifa As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@upTarifa", SqlDbType.Char, 2))
            upTarifa.Direction = ParameterDirection.Input
            uspKomanda.Parameters("@upTarifa").Value = mTarifa

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
                    StatusBar1.Text = uspKomanda.Parameters("@ipNazivRobe").Value
                    jci_NazivRobe = uspKomanda.Parameters("@ipNazivRobe").Value
                    jci_NHM = tbNHM.Text
                    ErrorProvider1.SetError(tbNHM, "")
                    mRazred = uspKomanda.Parameters("@ipRazredRobe").Value
                    If mRazred = "3" Then
                        mRazred = "2"
                    End If
                    mRazredRid = uspKomanda.Parameters("@ipRazredRid").Value
                    tbRazred.Text = mRazred
                    tbRazredRid.Text = mRazredRid

                    If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9931" Then
                        bKontejneri = True
                    Else
                        bKontejneri = False
                    End If

                    '---------------- popunjava kolonu TipKola u dgKola ------------------------
                    For Each KolaRed In dtKola.Rows
                        If mIBK = KolaRed.Item("IndBrojKola") Then
                            If KolaRed.Item("Vlasnik") = "Z" Then       ' zeleznicka
                                If KolaRed.Item("Vrsta") = "O" Then
                                    KolaRed.Item("Tip") = "1"
                                Else
                                    KolaRed.Item("Tip") = "2"
                                End If
                                If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9801" Then
                                    KolaRed.Item("Tip") = "8"
                                End If
                            Else                                        ' privatna
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
                        End If
                    Next
                    '---------------------------------------------------------------------------

                    'otvara tip uti
                    If Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9931" Then
                        gbUti.Enabled = True
                        'cbTipUti.Enabled = True
                        cbTipUti.Focus()
                        cbTipUti.DroppedDown = True

                        If (Microsoft.VisualBasic.Mid(tbNHM.Text, 1, 4) = "9931") And (bVrstaSaobracaja = 0) Then
                            cb35Posto.Enabled = True
                            cb35Posto.Visible = True
                        Else
                            cb35Posto.Enabled = False
                            cb35Posto.Visible = False
                        End If

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
                tbMasaDec.Focus()
            Else
                tbNHM.Focus()
            End If
        End If

    End Sub

    Private Sub cbTipUti_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipUti.Leave
        Me.cbTipUti.BackColor = System.Drawing.Color.White
        Me.cbTipUti.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub cbTipUti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbTipUti.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub fxIBK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fxIBK.Validating

        Dim bKontrolniBroj As Int16

        mIBK = Microsoft.VisualBasic.Mid(fxIBK.Text, 1, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 4, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 7, 4) & Microsoft.VisualBasic.Mid(fxIBK.Text, 12, 3) & Microsoft.VisualBasic.Mid(fxIBK.Text, 16, 1)

        If Me.chbLokomotiva.Checked = True Then
            ErrorProvider1.SetError(fxIBK, "")
            StatusBar1.Text = ""
            mkBrojPokusaja = 1
            mICF = "N"
            mIBK_KB = "N"

            If Len(mIBK) < 12 Then
                If dtKola.Rows.Count > 0 Then
                    If Len(mIBK) = 0 Then
                        ErrorProvider1.SetError(fxIBK, "")
                        Me.btnPrihvati.Focus()
                    End If
                Else
                    ErrorProvider1.SetError(fxIBK, "")
                    Me.tbTara.Focus()
                End If
            Else
                ErrorProvider1.SetError(fxIBK, "")
                lblKontBroj.Visible = False
                Me.tbTara.Focus()
            End If
        Else
            If Len(mIBK) < 12 Then
                If dtKola.Rows.Count > 0 Then
                    If Len(mIBK) = 0 Then
                        ErrorProvider1.SetError(fxIBK, "")
                        lblKontBroj.Visible = False
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


                Dim bUprava As String = ""
                Dim bTara As String = ""
                Dim bSerija As String = ""
                Dim bOsovine As String = ""
                Dim bVlasnik As String = ""
                Dim bVrsta As String = ""
                Dim bDatumOd1 As DateTime
                Dim bDatumDo1 As DateTime
                Dim bNasaoIKP1 As Boolean = False
                Dim bNasaoIKP2 As Boolean = False
                Dim bRIVDaNe As String = ""
                Dim bDatumOd2 As DateTime
                Dim Poruka As String

                'Dim bIBK1 As String = TextBox1.Text
                'Dim bDatum1 As DateTime = DateTimePicker1.Value               
                Dim bDatum1 As DateTime
                Dim bPV As String = ""

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
                    'Dim uspKomanda1 As New SqlClient.SqlCommand("nmNadjiIBK_T", OkpDbVeza)
                    Dim uspKomanda1 As New SqlClient.SqlCommand("nmNadjiIBK", OkpDbVeza)
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
                        bUprava = mUprava
                        bTara = tbTara.Text
                        bSerija = tbSerija.Text
                        bOsovine = tbOsovine.Text
                        bVlasnik = tbVlasnik.Text
                        bVrsta = tbVrsta.Text

                    Catch Exp As Exception
                        nmNasaoIKP = False
                    Finally
                        OkpDbVeza.Close()
                        uspKomanda1.Dispose()
                    End Try
                End If
                '------------------- end KB
                '--end novo ---------------------------------------------------------------------------------------------------------------------

                'upit u RIVkola

                If DbVeza.State = ConnectionState.Closed Then
                    DbVeza.Open()
                End If


                Dim uspKomanda2 As New SqlClient.SqlCommand("roba1708.bNadjiIBKIzRIVa", DbVeza)
                uspKomanda2.CommandType = CommandType.StoredProcedure


                Dim ulIBK2 As SqlClient.SqlParameter = uspKomanda2.Parameters.Add(New SqlClient.SqlParameter("@inIBK2", SqlDbType.Char, 12))
                ulIBK2.Direction = ParameterDirection.Input
                uspKomanda2.Parameters("@inIBK2").Value = mIBK

                Dim izlDatum2 As SqlClient.SqlParameter = uspKomanda2.Parameters.Add(New SqlClient.SqlParameter("@outDatumOd", SqlDbType.SmallDateTime, 4))
                izlDatum2.Direction = ParameterDirection.Output

                Dim izlRIV As SqlClient.SqlParameter = uspKomanda2.Parameters.Add(New SqlClient.SqlParameter("@outRIVDaNe", SqlDbType.Char, 1))
                izlRIV.Direction = ParameterDirection.Output

                'Dim ipVrsta1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
                'ipVrsta1.Direction = ParameterDirection.Output

                Dim izlPovratnaVrednost2 As SqlClient.SqlParameter = uspKomanda2.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
                izlPovratnaVrednost2.Direction = ParameterDirection.Output

                Try

                    uspKomanda2.ExecuteScalar()

                    bRIVDaNe = uspKomanda2.Parameters("@outRIVDaNe").Value
                    bDatumOd2 = uspKomanda2.Parameters("@outDatumOd").Value
                    bPV = uspKomanda2.Parameters("@outretVal").Value
                    If bPV = "" Then
                        bNasaoIKP2 = True
                    Else
                        bNasaoIKP2 = False
                    End If
                Catch sqlexp As Exception
                    Poruka = sqlexp.Message & " SQL greska u programu!"
                Catch Exp As Exception
                    bNasaoIKP2 = False
                Finally
                    DbVeza.Close()
                    uspKomanda2.Dispose()
                End Try


                'upit u RIVkola

                ' logika
                If bVlasnik = "Z" And bRIVDaNe = "D" Then
                    bVlasnik = "Z"
                ElseIf bVlasnik = "P" And bRIVDaNe = "N" Then
                    bVlasnik = "P"
                ElseIf bVlasnik = "Z" And bRIVDaNe = "N" Then
                    If bDatumOd1 < bDatumOd2 Then
                        bVlasnik = "P"
                    End If
                ElseIf bVlasnik = "P" And bRIVDaNe = "D" Then
                    If bDatumOd1 < bDatumOd2 Then
                        bVlasnik = "Z"
                    End If
                ElseIf bVlasnik = "" Then
                    nmNasaoIKP = False
                    ' pretraga iz tabele rezima
                End If

                ' logika

                ' upit u tabele rezima... :
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
                    'btnDodajKola.Focus()
                    tbTara.Focus()

                End If



                '----------- staro --------------------------------------
                'ErrorProvider1.SetError(fxIBK, "")
                'Dim rv As String = ""
                'Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & mIBK & "'")

                'If DbVeza.State = ConnectionState.Closed Then
                '    DbVeza.Open()
                'End If

                'Dim uspKomanda As New SqlClient.SqlCommand("dbo.spNadjiSveIzIBK", DbVeza)
                'uspKomanda.CommandType = CommandType.StoredProcedure

                'Dim upIBK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
                'upIBK.Direction = ParameterDirection.Input
                'uspKomanda.Parameters("@inIBK").Value = Microsoft.VisualBasic.Mid(fxIBK.Text, 1, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 4, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 7, 4) & Microsoft.VisualBasic.Mid(fxIBK.Text, 12, 3) & Microsoft.VisualBasic.Mid(fxIBK.Text, 16, 1)

                'Dim ipSkrUprava As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSkrUprava", SqlDbType.Char, 6))
                'ipSkrUprava.Direction = ParameterDirection.Output

                'Dim ipVlasnistvo As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVlasnistvo", SqlDbType.Char, 1))
                'ipVlasnistvo.Direction = ParameterDirection.Output

                'Dim ipRIV As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRIV", SqlDbType.Char, 1))
                'ipRIV.Direction = ParameterDirection.Output

                'Dim ipSerija As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSerija", SqlDbType.Char, 11))
                'ipSerija.Direction = ParameterDirection.Output

                'Dim ipBrojOsovina As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrojOsovina", SqlDbType.Int))
                'ipBrojOsovina.Direction = ParameterDirection.Output

                'Dim ipVrsta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
                'ipVrsta.Direction = ParameterDirection.Output

                'Dim ipKontrBroj As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBroj", SqlDbType.Int))
                'ipKontrBroj.Direction = ParameterDirection.Output

                'Dim ipKontrBrojOK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBrojOK", SqlDbType.Char, 1))
                'ipKontrBrojOK.Direction = ParameterDirection.Output

                'Dim ipKolaICFIzuzeta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolaICFIzuzeta", SqlDbType.Char, 1))
                'ipKolaICFIzuzeta.Direction = ParameterDirection.Output

                'Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.NVarChar, 100))
                'ipPovratnaVrednost.Direction = ParameterDirection.Output

                ''''''--------------------------------
                '''''Dim xxPovVr, xxTacanKB As String
                ''''''--------------------------------

                'Try
                '    uspKomanda.ExecuteScalar()

                '    mUprava = uspKomanda.Parameters("@outSkrUprava").Value
                '    tbUprava.Text = mUprava
                '    tbVlasnik.Text = uspKomanda.Parameters("@outVlasnistvo").Value  'izlazVlasnistvo =
                '    tbSerija.Text = uspKomanda.Parameters("@outSerija").Value 'izlazSerija = 
                '    tbOsovine.Text = uspKomanda.Parameters("@outBrojOsovina").Value 'izlazBrojOsovina = 

                '    bKontrolniBroj = uspKomanda.Parameters("@outKontrBroj").Value

                '    If uspKomanda.Parameters("@outVrsta").Value = "1" Then
                '        tbVrsta.Text = "O"
                '    Else
                '        tbVrsta.Text = "S"
                '    End If

                '    mICF = uspKomanda.Parameters("@outKolaICFIzuzeta").Value
                '    mIBK_KB = uspKomanda.Parameters("@outKontrBrojOK").Value

                '    '''''----------------------------------------------------------------
                '    ''''xxPovVr = uspKomanda.Parameters("@outPovratnaVrednost").Value
                '    ''''xxTacanKB = uspKomanda.Parameters("@outKontrBroj").Value
                '    '''''----------------------------------------------------------------

                '    If mIBK_KB = "D" Then
                '        ErrorProvider1.SetError(fxIBK, "")
                '        StatusBar1.Text = ""
                '        lblKontBroj.Visible = False

                '    Else
                '        If mBrojPokusaja > 3 Then
                '            mBrojPokusaja = 1
                '            ErrorProvider1.SetError(fxIBK, "")
                '            Dim KolaNotFound As New KolaExtra
                '            KolaNotFound.ShowDialog()
                '            tbVlasnik.Text = mVlasnik
                '            tbSerija.Text = mSerija
                '            tbVrsta.Text = mVrsta
                '            tbOsovine.Text = mOsovine
                '            Me.tbTara.Focus()
                '        Else
                '            mBrojPokusaja = mBrojPokusaja + 1
                '            ErrorProvider1.SetError(fxIBK, "Neispravan kontrolni broj!")
                '            'PlaySound(Application.StartupPath & "\Media\soundibk.wav", 0, SND_NODEFAULT Or SND_ASYNC Or SND_FILENAME)
                '            lblKontBroj.Visible = True
                '            lblKontBroj.Text = bKontrolniBroj

                '            fxIBK.Focus()
                '        End If
                '    End If
                'Catch Exp As Exception
                '    If fxIBK.Text = Nothing Then
                '        If dtKola.Rows.Count > 0 Then
                '            StatusBar1.Text = ""
                '            Me.fxIBK.BackColor = System.Drawing.Color.White
                '            Me.fxIBK.ForeColor = System.Drawing.Color.Black
                '            Me.btnPrihvati.Focus()
                '        Else
                '            rv = Err.Description & "??" 'Greska - bilo koja
                '            StatusBar1.Text = rv
                '            Me.fxIBK.Focus()
                '        End If
                '    Else
                '        rv = Err.Description & "??" 'Greska - bilo koja
                '        StatusBar1.Text = rv
                '        Me.fxIBK.Focus()
                '    End If
                'Finally
                '    DbVeza.Close()
                '    uspKomanda.Dispose()
                'End Try
                '------------- end staro --------------------------------------

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

        mIBK = Microsoft.VisualBasic.Mid(fxIBK.Text, 1, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 4, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 7, 4) & Microsoft.VisualBasic.Mid(fxIBK.Text, 12, 3) & Microsoft.VisualBasic.Mid(fxIBK.Text, 16, 1)
        GridIBK = mIBK

        If Me.chbLokomotiva.Checked = True Then
            tbUprava.Text = "ZS"
            tbVlasnik.Text = "Z"
            tbSerija.Text = "LOK"
            tbVrsta.Text = "O"
            tbOsovine.Text = 6
            Me.fxGranTov.Text = 0
            mUprava = tbUprava.Text
            mVlasnik = tbVlasnik.Text
            mSerija = tbSerija.Text
            mVrsta = tbVrsta.Text
            mOsovine = tbOsovine.Text
            mTara = tbTara.Text
            mTaraZbogP = tbTara.Text
            mGranTov = Me.fxGranTov.Text
        Else
            mUprava = tbUprava.Text
            mVlasnik = tbVlasnik.Text
            mSerija = tbSerija.Text
            mVrsta = tbVrsta.Text
            mOsovine = tbOsovine.Text
            mTara = tbTara.Text
            mTaraZbogP = tbTara.Text
            mGranTov = Me.fxGranTov.Text
        End If

        If Me.chbStitnaKola.Checked = True Then
            mStitna = "D"
        Else
            mStitna = "N"
        End If

        'naknada za koriscenje zeleznickih kola iz tabele obb kola!!!
        If mICF = "D" Then
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            Dim sql_text As String = "SELECT Iznos1 " & _
                                     "FROM dbo.ZsNaknade " & _
                                     "WHERE (Sifra = '90') AND (IvicniBroj = '00') AND (SifraVS = 4) "

            Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)
            Dim rdrIcf As SqlClient.SqlDataReader

            rdrIcf = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrIcf.Read()
                mNaknada = rdrIcf.GetDecimal(0)
                tbKolaNaknada.Text = mNaknada
            Loop
            rdrIcf.Close()
            OkpDbVeza.Close()
        End If
        If tbTara.Text = "" Then
            MsgBox("prazno")
        End If
        Try
            'Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & mIBK & "'")
            Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & GridIBK & "'")
            If dtRow.Length > 0 Then
                'StatusBar1.Text = "Kola: " & mIBK & " - su vec upisana."
                ErrorProvider1.SetError(fxIBK, "Kola su vec upisana!")
                fxIBK.Focus()
                fxIBK.SelectAll()
                Exit Try
            Else
                ErrorProvider1.SetError(fxIBK, "")
                dtKola.NewRow()
                'dtKola.Rows.Add(New Object() {mIBK, mUprava, mVlasnik, mSerija, mVrsta, mOsovine, mTara, mGranTov, mStitna, mTipKola, mPrevoznina, mNaknada, mICF, mIBK_KB, "I"})
                'dtKola.Rows.Add(New Object() {GridIBK, mUprava, mVlasnik, mSerija, mVrsta, mOsovine, mTara, mGranTov, mStitna, mTipKola, mPrevoznina, mNaknada, mICF, mIBK_KB, "I"})
                dtKola.Rows.Add(New Object() {GridIBK, mTara, mOsovine, mVlasnik, mSerija, mVrsta, mUprava, mGranTov, mStitna, mTipKola, mPrevoznina, mNaknada, mICF, mIBK_KB, "I"})
            End If
            dgKola.Refresh()
            Me.tbRbrKola.Text = dtKola.Rows.Count

            fxIBK.Clear()
            tbTara.Text = 0
            Me.chbStitnaKola.Checked = False
            Me.fxGranTov.Clear()


            If (CType(tbRbrKola.Text, Int32) > 1) Then
                Me.tbNHM.Text = mx_nhm
            End If

            tbMasaDec.Focus()
            'tbMasa.Focus()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

        Dim UkStvMasa As Decimal
        bNadjiZbirStvarnihMasa(UkStvMasa)
        If UkStvMasa > 0 Then
            TextBox1.Text = UkStvMasa
        End If

    End Sub

    Private Sub btnDodajRobu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajRobu.Click
        Dim SifraRobe As String
        Dim MasaRobeInt As Int32
        Dim MasaRobeDec As Decimal
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

        'Dim Poreklo As Int16



        StatusBar1.Text = ""

        SifraRobe = tbNHM.Text
        mx_nhm = tbNHM.Text

        '***
        'za koji slucaj ovo vazi!!!
        If Microsoft.VisualBasic.Mid(SifraRobe, 1, 4) = "9931" Then
            mTabelaCena = "386"
        ElseIf Microsoft.VisualBasic.Mid(SifraRobe, 1, 4) = "9941" Then
            mTabelaCena = "385"
        End If

        If Microsoft.VisualBasic.Mid(SifraRobe, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(SifraRobe, 1, 4) = "9922" Then
            If mTaraZbogP < tbMasaDec.Text Then
                MasaRobeDec = tbMasaDec.Text
                MasaRobeInt = tbMasa.Text
            Else
                MasaRobeDec = mTaraZbogP
                MasaRobeInt = mTaraZbogP
            End If
            ''MasaRobeDec = mTaraZbogP
            ''MasaRobeInt = mTaraZbogP

        Else
            MasaRobeDec = tbMasaDec.Text
            MasaRobeInt = tbMasa.Text
        End If

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

        'dtNhm.Rows.Add(New Object() {GridIBK, SifraRobe, MasaRobeDec, MasaRobeInt, Tr, TrRid, TipUti, UtiIB, UtiTara, UtiRaster, UtiNHM, UtiPredajniList, UtiBrPlombe, "I"})        


        dtNhm.Rows.Add(New Object() {GridIBK, SifraRobe, MasaRobeDec, TipUti, TrRid, UtiIB, Tr, UtiTara, UtiRaster, UtiNHM, UtiPredajniList, UtiBrPlombe, "I"})

        dtNhm.Rows((dtNhm.Rows.Count - 1)).Item(15) = bPorekloRobe

        tbNHM.Clear()
        tbMasa.Text = 0
        tbRazred.Clear()
        tbRazredRid.Clear()
        dgRoba.Refresh()

        tbMasaDec.Text = 0
        tbMasaDec.Focus()
        'tbMasa.Focus()

        Dim UkStvMasa As Decimal
        bNadjiZbirStvarnihMasa(UkStvMasa)
        If UkStvMasa > 0 Then
            TextBox1.Text = UkStvMasa
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
                tbMasaDec.Text = 0
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

                tbMasaDec.Focus()
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

        Dim UkStvMasa As Decimal
        bNadjiZbirStvarnihMasa(UkStvMasa)
        If UkStvMasa > 0 Then
            TextBox1.Text = UkStvMasa
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
            tbNHM.Text = dr(1, DataRowVersion.Current.Current).ToString()
            tbMasaDec.Text = dr(2, DataRowVersion.Current.Current).ToString()

            tbMasa.Text = dr(3, DataRowVersion.Current.Current).ToString()
            tbRazred.Text = dr(4, DataRowVersion.Current.Current).ToString()
            tbRazredRid.Text = dr(5, DataRowVersion.Current.Current).ToString()

            Select Case dr(6, DataRowVersion.Current.Current).ToString()
                Case Is = "10"
                    Me.cbTipUti.Text = Me.cbTipUti.Items.Item(0)
                Case Is = "20"
                    Me.cbTipUti.Text = Me.cbTipUti.Items.Item(1)
                Case Is = "30"
                    Me.cbTipUti.Text = Me.cbTipUti.Items.Item(2)
                Case Is = "40"
                    Me.cbTipUti.Text = Me.cbTipUti.Items.Item(3)
                Case Is = "50"
                    Me.cbTipUti.Text = Me.cbTipUti.Items.Item(4)
                Case Is = "70"
                    Me.cbTipUti.Text = Me.cbTipUti.Items.Item(5)
                Case Else
                    Me.cbTipUti.Text = ""
            End Select

            'Me.cbTipUti.Text = dr(5, DataRowVersion.Current.Current).ToString()

            Me.tbUtiIB.Text = dr(7, DataRowVersion.Current.Current).ToString()
            Me.tbUtiTara.Text = dr(8, DataRowVersion.Current.Current).ToString()
            Me.tbUtiNHM.Text = dr(10, DataRowVersion.Current.Current).ToString()
            Me.tbPredajniList.Text = dr(11, DataRowVersion.Current.Current).ToString()
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
        IBK_PreIzmene = currRowKola(0, DataRowVersion.Current).ToString()
        'KolaZaGrid = Trim(mIBK)

        mIBK = Microsoft.VisualBasic.Mid(mIBK, 1, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 3, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 5, 4) & " " & Microsoft.VisualBasic.Mid(mIBK, 9, 3) & " " & Microsoft.VisualBasic.Mid(mIBK, 12, 1)

        fxIBK.Text = mIBK

        'kCol1  IndBrojKola String
        'kCol2  Tara        Int32
        'kCol3  Osovine     Int16
        'kCol4  Vlasnik     String
        'kCol5  Serija      String
        'kCol6  Vrsta       String
        'kCol7  Uprava      String
        'kCol8  GrTov       Decimal
        'kCol9  Stitna      String
        'kCol10 Tip         String
        'kCol11 Prevoznina  Decimal
        'kCol12 Naknada     Decimal
        'kCol13 ICF         String
        'kCol14 KB          String
        'kCol15 Action      String



        'tbUprava.Text = currRowKola(1, DataRowVersion.Current).ToString()
        'tbVlasnik.Text = currRowKola(2, DataRowVersion.Current).ToString()
        'tbSerija.Text = currRowKola(3, DataRowVersion.Current).ToString()
        'tbVrsta.Text = currRowKola(4, DataRowVersion.Current).ToString()
        'tbOsovine.Text = currRowKola(5, DataRowVersion.Current).ToString()
        'tbTara.Text = currRowKola(6, DataRowVersion.Current).ToString()
        'fxGranTov.Text = currRowKola(7, DataRowVersion.Current).ToString()
        'If currRowKola(8, DataRowVersion.Current).ToString() = "D" Then
        '    Me.chbStitnaKola.Checked = True
        'Else
        '    Me.chbStitnaKola.Checked = False
        'End If

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



        If bNarocitaPosiljka Then
            'If currRowKola(13, DataRowVersion.Current).ToString() = "DaNP" Then
            If currRowKola(13, DataRowVersion.Current).ToString() = "D" Then
                chbKolaSaNarocitomPosiljkom.Enabled = True
                chbKolaSaNarocitomPosiljkom.Visible = True
                Me.chbKolaSaNarocitomPosiljkom.Checked = True
            Else
                Me.chbKolaSaNarocitomPosiljkom.Checked = False
            End If

        End If

        tbKolaNaknada.Text = currRowKola(11, DataRowVersion.Current).ToString()

        ' -----------------------------   NHM   -------------------------------------
        If dvNhm.Count > 0 Then
            dvNhm.RowFilter = "IndBrojKola='" & GridIBK & "'"
            dgRoba.DataSource = dvNhm
        Else
            fxIBK.Focus()
            Me.fxIBK.SelectAll()
        End If
        ' ----------------------------- end NHM -------------------------------------

    End Sub

    Private Sub btnBrisiKola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiKola.Click
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
                    dgKola.DataSource = dvKola 'nhm?
                    dgKola.Refresh()
                    '-----------------------------------------------------------------------


                    '------------------------ filtrira obrisane zapise u dgNhm -------------
                    '''Dim rowNhm As Data.DataRow
                    '''rowNhm = CType(dgRoba.DataSource, DataTable).Rows(dgRoba.CurrentCell.RowNumber)
                    '''rowNhm = dtNhm.Rows(dgRoba.CurrentCell.RowNumber)

                    '''Dim VrednostIBK As String = dgKola.Item(dgKola.CurrentCell.RowNumber, 0)

                    '''For Each row As DataRow In dtNhm.Select("IndBrojKola = '" & VrednostIBK & "'")
                    '''    '                        rowNhm = CType(dgRoba.DataSource, DataTable).Rows(dgRoba.CurrentCell.RowNumber)
                    '''    '                       rowNhm = dtNhm.Rows(dgRoba.CurrentCell.RowNumber)
                    '''    rowNhm("Action") = "D"
                    '''Next

                    '''dvNhm.RowFilter = "Action LIKE 'U'"
                    '''dgRoba.DataSource = dvNhm
                    '-----------------------------------------------------------------------

                    '-----------------------
                    Dim RobaRed As DataRow
                    For Each RobaRed In dtNhm.Rows
                        If RobaRed.Item("IndBrojKola") = IBK_PreIzmene Then
                            RobaRed.Item("Action") = "D"
                        End If
                    Next
                    dvNhm.RowFilter = "Action LIKE 'U'"
                    dgRoba.DataSource = dvNhm
                    dgRoba.Refresh()
                    '-----------------------
                Catch ex As Exception

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

        Dim UkStvMasa As Decimal
        bNadjiZbirStvarnihMasa(UkStvMasa)
        If UkStvMasa > 0 Then
            TextBox1.Text = UkStvMasa
        End If

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click

        Dim KolaRed, RobaRed As DataRow

        'vrati
        'mSumaKola = dtKola.Rows.Count
        'mMasaRobe = dtNhm.Rows(0).Item(2)
        'intercontainer kalkulacija - fKalkulacija()
        'uraditi proceduru NadjiVrstuStanice() - izlaz: bVrstaStanice!!!

        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'Cursor.Current = New Cursor("Wait07.cur")

        Dim Kontrola As Int16 = 0
        For Each KolaRed In dtKola.Rows
            Dim IBK As String = KolaRed.Item("IndBrojKola")
            If KolaRed.Item("Tip") = 0 Then
                Kontrola = Kontrola + 1
                MessageBox.Show("Proveriti tip kola     " & IBK, "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            For Each RobaRed In dtNhm.Rows
                If RobaRed.Item("IndBrojKola") = IBK Then

                End If
            Next                'roba
        Next                'kola

       
        If dtKola.Rows.Count > 0 And dtNhm.Rows.Count > 0 And (dtKola.Rows.Count <= dtNhm.Rows.Count) And Kontrola = 0 Then

            If eRazmena = "Da" Then
                eUskladiTipKola()
                eUskladiNhm()
            End If


            If IzborSaobracaja = 4 Then
                bVrstaStanice = "M"
            End If


            For Each KolaRed In dtKola.Rows
                If KolaRed.Item("Action") <> "D" Then
                    mIBK = KolaRed.Item("IndBrojKola")
                End If
            Next
            For Each RobaRed In dtNhm.Rows
                If RobaRed.Item("Action") <> "D" Then
                    mNHM = RobaRed.Item("NHM")
                End If
            Next
            mSumaRobe = dtNhm.Compute("SUM(Masa)", String.Empty)
            mSumaTara = dtKola.Compute("SUM(Tara)", String.Empty)
            mSumaBruto = mSumaRobe + mSumaTara

            ''Dim currRowKola As DataRow
            ''currRowKola = CType(dgKola.DataSource, DataTable).Rows(dgKola.CurrentCell.RowNumber)
            ''mIBK = currRowKola(0, DataRowVersion.Current).ToString()
            ''Dim currRowRoba As DataRow
            ''currRowRoba = CType(dgRoba.DataSource, DataTable).Rows(dgRoba.CurrentCell.RowNumber)
            ''mNHM = currRowRoba(1, DataRowVersion.Current).ToString()
            '--------

            'bNadjiPrevozninuGlavni()

            If Me.cb35Posto.Checked Then
                b35Posto = True
            Else
                b35Posto = False
            End If

            Cursor.Current = System.Windows.Forms.Cursors.Default

            mPrikazKalkulacije = "D"


            _OpenForm = "Roba"
            Close()


            bKorigujTipoveKola()

        Else
            Cursor.Current = System.Windows.Forms.Cursors.Default
            MessageBox.Show("Niste uneli sve potrebne podatke!", "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            'dr(0) = GridIBK
            'dr(1) = tbNHM.Text
            'dr(2) = tbMasaDec.Text
            'dr(3) = tbMasa.Text
            'dr(4) = tbRazred.Text
            'dr(5) = tbRazredRid.Text
            'dr(6) = Microsoft.VisualBasic.Mid(cbTipUti.SelectedItem, 1, 2)
            'dr(7) = tbUtiIB.Text
            'dr(8) = tbUtiTara.Text
            'dr(10) = tbUtiNHM.Text
            'dr(11) = tbPredajniList.Text
            'dr(12) = tbUtiPlombe.Text
            dr(0) = GridIBK
            dr(1) = tbNHM.Text
            'dr(2) = tbMasaDec.Text
            dr(2) = mMasaDec
            dr(6) = tbRazred.Text
            If tbRazredRid.Text = "" Then
                dr(4) = 0
            Else
                dr(4) = tbRazredRid.Text
            End If
            dr(4) = tbRazredRid.Text
            dr(3) = Microsoft.VisualBasic.Mid(cbTipUti.SelectedItem, 1, 2)
            dr(5) = tbUtiIB.Text
            dr(7) = tbUtiTara.Text
            dr(9) = tbUtiNHM.Text
            dr(10) = tbPredajniList.Text
            dr(11) = tbUtiPlombe.Text

            'If MasterAction = "New" Then
            '    dr(13) = "I"
            'Else
            '    dr(13) = "U"
            'End If

            If MasterAction = "New" Then
                dr(12) = "I"
            Else
                dr(12) = "U"
            End If

            dr(15) = bPorekloRobe

            btnDodajRobu.Focus()


            dgRoba.Refresh()
            tbNHM.Clear()
            tbMasa.Text = 0
            tbMasaDec.Text = 0
            Me.tbUtiTara.Text = 0
            Me.cbTipUti.SelectedIndex = -1
            tbRazred.Clear()
            tbRazredRid.Clear()

            tbMasaDec.Focus()
            'tbMasa.Focus()
        Catch ex As Exception
            MsgBox("Greska : " & ex.ToString)
        End Try

        Dim UkStvMasa As Decimal = 0
        bNadjiZbirStvarnihMasa(UkStvMasa)
        If UkStvMasa > 0 Then
            TextBox1.Text = UkStvMasa
        End If


    End Sub

    Private Sub tbMasa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbMasa.Validating
        If IsNumeric(tbMasa.Text) = True Then
            If CType(tbMasa.Text, Int32) = 0 Then
                If dtNhm.Rows.Count > 0 Then
                    fxIBK.Focus()
                Else
                    ErrorProvider1.SetError(tbMasa, "Obavezan unos mase robe!")
                    tbMasa.Focus()
                End If
            Else
                ErrorProvider1.SetError(tbMasa, "")
            End If
        Else
            ErrorProvider1.SetError(tbMasa, "Neispravan unos!")
            tbMasa.Focus()
        End If
    End Sub

    Private Sub btnIzmeniKola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzmeniKola.Click
        Me.btnDodajKola.Visible = True
        Me.btnIzmeniKola.Visible = False

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
        row("ICF") = tbKolaNaknada.Text

        '        ###############
        'narocite?
        '        ###############

        If MasterAction = "New" Then
            row("Action") = "I"
        Else
            row("Action") = "U"
        End If

        '-----------------------
        Dim RobaRed As DataRow
        For Each RobaRed In dtNhm.Rows
            If RobaRed.Item("IndBrojKola") = IBK_PreIzmene Then
                RobaRed.Item("IndBrojKola") = GridIBK
            End If
        Next
        dvNhm.RowFilter = "IndBrojKola='" & GridIBK & "'"
        dgRoba.DataSource = dvNhm
        dgRoba.Refresh()
        '-----------------------
        fxIBK.Clear()
        tbTara.Text = 0
        Me.chbStitnaKola.Checked = False
        Me.fxGranTov.Clear()
        Me.tbMasaDec.Focus()

        Dim UkStvMasa As Decimal
        bNadjiZbirStvarnihMasa(UkStvMasa)
        If UkStvMasa > 0 Then
            TextBox1.Text = UkStvMasa
        End If


    End Sub

    Private Sub tbMasa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMasa.GotFocus
        Me.tbMasa.BackColor = System.Drawing.Color.Gainsboro
        Me.tbMasa.ForeColor = System.Drawing.Color.Black

    End Sub

    Private Sub tbMasa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMasa.LostFocus
        tbMasa.BackColor = System.Drawing.Color.White
        tbMasa.ForeColor = System.Drawing.Color.Black
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
        '''''Dim NarocitaPos As New NarPos
        '''''NarocitaPos.Show()

    End Sub
    Private Sub kola_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            If dtKola.Rows.Count > 0 And dtNhm.Rows.Count > 0 Then
                If IzborSaobracaja = 4 Then
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
        Me.fxIBK.BackColor = System.Drawing.Color.RoyalBlue
        Me.fxIBK.ForeColor = System.Drawing.Color.White

    End Sub

    Private Sub fxIBK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxIBK.LostFocus
        Me.fxIBK.BackColor = System.Drawing.Color.White
        Me.fxIBK.ForeColor = System.Drawing.Color.Black

    End Sub

    Private Sub tbTara_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbTara.GotFocus
        Me.tbTara.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbTara.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbTara_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbTara.LostFocus
        Me.tbTara.BackColor = System.Drawing.Color.White
        Me.tbTara.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbNHM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNHM.GotFocus

        If (dtNhm.Rows.Count > 0) Then
            Me.tbNHM.Text = mx_nhm
        End If

        Me.tbNHM.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbNHM.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbNHM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNHM.LostFocus
        Me.tbNHM.BackColor = System.Drawing.Color.White
        Me.tbNHM.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub cbTipUti_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipUti.GotFocus
        Me.cbTipUti.BackColor = System.Drawing.Color.RoyalBlue
        Me.cbTipUti.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiIB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiIB.GotFocus
        Me.tbUtiIB.BackColor = System.Drawing.Color.RoyalBlue
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
        Me.tbUtiTara.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbUtiTara.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiTara_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiTara.LostFocus
        Me.tbUtiTara.BackColor = System.Drawing.Color.White
        Me.tbUtiTara.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiNHM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiNHM.GotFocus
        Me.tbUtiNHM.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbUtiNHM.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiNHM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiNHM.LostFocus
        Me.tbUtiNHM.BackColor = System.Drawing.Color.White
        Me.tbUtiNHM.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbPredajniList_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPredajniList.GotFocus
        Me.tbPredajniList.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbPredajniList.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbPredajniList_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPredajniList.LostFocus
        Me.tbPredajniList.BackColor = System.Drawing.Color.White
        Me.tbPredajniList.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUtiPlombe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUtiPlombe.GotFocus
        Me.tbUtiPlombe.BackColor = System.Drawing.Color.RoyalBlue
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

        If IzborSaobracaja = "3" Then
            If tbTara.Text = Nothing Then
                ErrorProvider1.SetError(tbTara, "Neispravan podatak!")
                tbTara.Focus()
            Else
                If CType(tbTara.Text, Int32) = 0 Then
                    ErrorProvider1.SetError(tbTara, "Obavezan unos tare kola!")
                    tbTara.Focus()
                Else
                    ErrorProvider1.SetError(tbTara, "")
                End If
            End If
        Else
            If tbTara.Text = Nothing Then
                ErrorProvider1.SetError(tbTara, "Neispravan podatak!")
                tbTara.Focus()
            Else
                btnDodajKola.Focus()
                ErrorProvider1.SetError(tbTara, "")
            End If
        End If

    End Sub

    Private Sub tbUtiTara_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUtiTara.Validating
        If IsNumeric(tbUtiTara.Text) = True Then
            ErrorProvider1.SetError(tbUtiTara, "")
        Else
            ErrorProvider1.SetError(tbUtiTara, "Neispravan unos!")
            tbUtiTara.Focus()

        End If
    End Sub

    Private Sub tbUtiNHM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUtiNHM.Validating
        If IsNumeric(tbNHM.Text) = True Then
            ErrorProvider1.SetError(tbUtiNHM, "")
        Else
            ErrorProvider1.SetError(tbUtiNHM, "Neispravan unos!")
            tbUtiNHM.Focus()
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
        Me.fxGranTov.BackColor = System.Drawing.Color.White
        Me.fxGranTov.ForeColor = System.Drawing.Color.Black
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
    Private Sub tbMasaDec_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMasaDec.LostFocus
        Dim MasaRobe As Int32

        tbMasaDec.BackColor = System.Drawing.Color.White
        tbMasaDec.ForeColor = System.Drawing.Color.Black

        If IsNumeric(tbMasaDec.Text) = Nothing Then
            Me.tbMasaDec.Focus()

        Else
            mMasaDec = CDec(tbMasaDec.Text)
            tbMasaDec.Text = Format(mMasaDec, "###,##0.00")

            MasaRobe = (Int(mMasaDec + 0.99) * 10) / 10
            tbMasa.Text = MasaRobe

        End If


    End Sub

    Private Sub tbMasaDec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbMasaDec.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbMasaDec_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMasaDec.GotFocus
        Me.tbMasaDec.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbMasaDec.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbMasaDec_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMasaDec.Leave
        If tbMasaDec.Text = "0" Then
            If dtNhm.Rows.Count > 0 Then
                Me.fxIBK.Focus()
            Else
                If dtKola.Rows.Count > 0 Then
                    Me.tbMasaDec.Focus()
                Else
                    Me.fxIBK.Focus()
                    Me.fxIBK.SelectAll()
                End If
            End If
        Else

        End If

    End Sub

    Private Sub tbMasaDec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbMasaDec.Validating

        If IsNumeric(tbMasaDec.Text) = True Then
            If (CType(tbMasaDec.Text, Decimal) >= 70000) Then
                ErrorProvider1.SetError(tbMasaDec, "Velika masa!")
                tbMasaDec.BackColor = System.Drawing.Color.Red
            End If

            If (CType(tbMasaDec.Text, Decimal) = 0) Then
                If dtNhm.Rows.Count > 0 Then
                    fxIBK.Focus()
                Else
                    ErrorProvider1.SetError(tbMasaDec, "Obavezan unos mase robe!")
                    tbMasaDec.Focus()
                End If
            Else
                If (CType(tbMasaDec.Text, Decimal) < 70000) Then
                    ErrorProvider1.SetError(tbMasaDec, "")
                    'tbMasaDec.BackColor = System.Drawing.Color.Gray
                End If
            End If
        Else
            ErrorProvider1.SetError(tbMasaDec, "Neispravan unos!")
            tbMasaDec.Focus()
        End If

    End Sub

    Private Sub chbLokomotiva_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chbLokomotiva.MouseUp
        If Me.chbLokomotiva.Checked = True Then
            Me.chbStitnaKola.Enabled = False
            Me.fxIBK.Focus()
        Else
            Me.fxIBK.Focus()
        End If
    End Sub

    Private Sub chbStitnaKola_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chbStitnaKola.MouseUp
        If Me.chbStitnaKola.Checked = True Then
            Me.chbLokomotiva.Enabled = False
            Me.fxIBK.Focus()
        Else
            Me.fxIBK.Focus()
        End If

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub tbSumaKola_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSumaKola.TextChanged

    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub chbNarocitaPosiljka_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbNarocitaPosiljka.Click
        If chbNarocitaPosiljka.Checked = True Then
            bNarocitaPosiljka = True
            Me.Label19.Enabled = True
            Me.Label19.Visible = True
            Me.Label21.Enabled = True
            Me.Label21.Visible = True
            Me.TextBox2.Enabled = True
            Me.TextBox2.Visible = True
            If bTarifa72 = 0 Then
                Me.chbKolaSaNarocitomPosiljkom.Checked = True
                Me.chbKolaSaNarocitomPosiljkom.Enabled = True
                Me.chbKolaSaNarocitomPosiljkom.Visible = True
            Else
                Me.Label20.Enabled = True
                Me.Label20.Visible = True
                Me.TextBox3.Enabled = True
                Me.TextBox3.Visible = True
            End If

        Else
            bNarocitaPosiljka = False
            Me.Label19.Enabled = False
            Me.Label19.Visible = False
            Me.Label20.Enabled = False
            Me.Label20.Visible = False
            Me.Label21.Enabled = False
            Me.Label21.Visible = False
            Me.TextBox2.Enabled = False
            Me.TextBox2.Visible = False
            Me.TextBox3.Enabled = False
            Me.TextBox3.Visible = False
            Me.TextBox3.Text = 0
            bNPUkupno = 0
            Me.TextBox2.Text = 0
            bNPKoef = 1

            Me.chbKolaSaNarocitomPosiljkom.Checked = False
            Me.chbKolaSaNarocitomPosiljkom.Enabled = False
            Me.chbKolaSaNarocitomPosiljkom.Visible = False
        End If
        Me.chbNarocitaPosiljka.Focus()
    End Sub

    Private Sub chbNarocitaPosiljka_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chbNarocitaPosiljka.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub chbNarocitaPosiljka_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles chbNarocitaPosiljka.Validating
        If chbNarocitaPosiljka.Checked = True Then
            TextBox2.Focus()
        Else

        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        Dim a As Decimal
        bNPKoef = 1 + CType(TextBox2.Text, Decimal) / 100
        TextBox3.Focus()
    End Sub

    Private Sub TextBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox3.Validating
        bNPUkupno = CInt(TextBox3.Text)
    End Sub

    Private Sub tbKolaNaknada_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbKolaNaknada.Validating
        If bNarocitaPosiljka Then
            chbKolaSaNarocitomPosiljkom.Focus()
        End If
    End Sub

    Private Sub chbKolaSaNarocitomPosiljkom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles chbKolaSaNarocitomPosiljkom.Validating
        If chbKolaSaNarocitomPosiljkom.Checked = True Then
            'mICF = "DaNP"
            mICF = "D"
        Else            
            'mICF = "NeNP"
            mICF = "N"
        End If

        btnDodajKola.Focus()
    End Sub

    Private Sub fxGranTov_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fxGranTov.Validating
        If bNarocitaPosiljka Then
            chbKolaSaNarocitomPosiljkom.Focus()
        End If
    End Sub
    Private Sub chbKolaSaNarocitomPosiljkom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chbKolaSaNarocitomPosiljkom.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cb35Posto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cb35Posto.Validating
        If cb35Posto.Checked Then
            b35Posto = True
        Else
            b35Posto = False
        End If

    End Sub
    Private Sub tbNepokrivenaMasa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNepokrivenaMasa.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbNepokrivenaMasa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbNepokrivenaMasa.Validating

        bNepokrivenaMasa = CDec(tbNepokrivenaMasa.Text)

    End Sub
    Private Sub chbPorekloRobe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chbPorekloRobe.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub chbPorekloRobe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles chbPorekloRobe.Validating
        If chbPorekloRobe.Checked Then
            bPorekloRobe = 0
            bVrstaSaobracaja = 0
        Else
            bPorekloRobe = 1
            bVrstaSaobracaja = 1
        End If
        'btnDodajRobu.Focus()
    End Sub

    Private Sub chbPorekloRobe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbPorekloRobe.Click
        If chbPorekloRobe.Checked Then
            bPorekloRobe = 0
            bVrstaSaobracaja = 0
        Else
            bPorekloRobe = 1
            bVrstaSaobracaja = 1
        End If
        'btnDodajRobu.Focus()
    End Sub

    Private Sub fxGranTov_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxGranTov.GotFocus
        Me.fxGranTov.BackColor = System.Drawing.Color.RoyalBlue
        Me.fxGranTov.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub fxGranTov_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxGranTov.LostFocus
        Me.fxGranTov.BackColor = System.Drawing.Color.White
        Me.fxGranTov.ForeColor = System.Drawing.Color.Black

    End Sub
    Private Sub bKorigujTipoveKola()

        Dim KolaRed As DataRow
        Dim NHMRed As DataRow


        For Each KolaRed In dtKola.Rows

            For Each NHMRed In dtNhm.Rows   '  opet petlja po robi - za upis voz.stavova NHM
                If (KolaRed.Item("IndBrojKola") = NHMRed.Item("IndBrojKola")) Then

                    If KolaRed.Item("Vlasnik") = "Z" Then       ' zeleznicka
                        If KolaRed.Item("Vrsta") = "O" Then
                            KolaRed.Item("Tip") = "1"
                        Else
                            KolaRed.Item("Tip") = "2"
                        End If
                        If Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9801" Then
                            KolaRed.Item("Tip") = "8"
                        End If
                    Else                                        ' privatna
                        If KolaRed.Item("Vrsta") = "O" Then
                            If Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9922" Then
                                KolaRed.Item("Tip") = "7"
                            Else
                                KolaRed.Item("Tip") = "3"
                            End If
                        Else
                            If Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(NHMRed.Item("NHM"), 1, 4) = "9922" Then
                                KolaRed.Item("Tip") = "7"
                            Else
                                KolaRed.Item("Tip") = "4"
                            End If
                        End If
                    End If
                End If

            Next
        Next

    End Sub

End Class
