Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Form6
    Inherits System.Windows.Forms.Form
    Public rade11 As String
    Protected Const GetAllrade1SqlString As String = "SELECT RecID, Stavka, NHM FROM CoAneksiNHM"

    Dim Saobracajj As String
    Dim Osovinee As String
    Dim VrstaPrevozaa As String
    Dim DatumOdd As String
    Dim DatumDoo As String
    Dim TipCenee As String
    Dim NPTipp As String
    Dim VlasnistvoKolaa As String
    Dim VrstaKolaa As String

    Dim RecIDpom As Integer
    Dim Ugovorpom As Integer
    Dim Ugovorpom1 As Integer
    Dim i As Integer
    Dim Stanicapom As String
    Dim Stanicapom1 As String
    Dim Stanicapom2 As String
  

    Dim NHMpom As String
    Dim NHMpom1 As String
    Dim NHMpom2 As String

    Dim Stavkapom As Integer
    Dim RecIDParm As Integer
    Dim UgovorParm As String
    Dim SaobracajParm As String
    Dim StanicaOdParm As String
    Dim StanicaDoParm As String
    Dim OsovineParm As Integer
    Dim VrstaPrevozaParm As String
    Dim VlasnistvoKolaParm As String
    Dim VrstaKolaParm As String
    Dim DatumOdParm As DateTime
    Dim DatumDoParm As DateTime
    Dim UslovZaStavParm As Integer
    Dim IznosParm As Decimal
    Dim TipCeneParm As Integer
    Dim NPParm As String
    Dim NPTipParm As Integer
    Dim NPIznosParm As Decimal
    Dim UserIDParm As String
    Public Sub RefreshData()
        Dim connection1 As New SqlConnection(ConnectionString)
        SqlConnection1.Open()
        Dim adapter1 As New SqlDataAdapter(rade11, _
                           SqlConnection1)
        Dim dataset1 As New DataSet
        adapter1.Fill(dataset1)
        SqlConnection1.Close()
        Dim table1 As DataTable = dataset1.Tables(0)
        AddHandler table1.ColumnChanged, _
          New DataColumnChangeEventHandler(AddressOf ColumnChanged)
        datagrid1.DataSource = table1
    End Sub
    Public Sub SaveData()
        Dim table As DataTable = CType(datagrid1.DataSource, _
           DataTable)
        Dim changedRows As New ArrayList
        Dim row As DataRow

        For Each row In table.Rows
            If row.RowState <> DataRowState.Unchanged Then
                changedRows.Add(row)
            End If
        Next
        If changedRows.Count = 0 Then
            Return
        End If
        Dim connection As New SqlConnection(ConnectionString)
        Dim adapter As New SqlDataAdapter(rade11, _
           SqlConnection1)
        Dim builder As New SqlCommandBuilder(adapter)
        Dim rows() As DataRow = CType(changedRows.ToArray(GetType(DataRow)), DataRow())
        adapter.Update(rows)
        ''adapter.Dispose()
        menuSave.Enabled = False
    End Sub

    Protected Sub ColumnChanged(ByVal sender As Object, _
ByVal e As DataColumnChangeEventArgs)
        'menuSave.Enabled = True
    End Sub
    '====================================================================
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbVrstaKola As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVlasnistvoKola As System.Windows.Forms.ComboBox
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNPIznos As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbNPTip As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNP As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTipCene As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtIznos As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtUslovZaStav As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbVrstaPrevoza As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOsovine As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStanicaDo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStanicaOd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbSaobracaj As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRecID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtStavka As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtNHM As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnPotvrdi As System.Windows.Forms.Button
    Friend WithEvents btnNE As System.Windows.Forms.Button
    Friend WithEvents datagrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents menuMain As System.Windows.Forms.MainMenu
    Friend WithEvents menuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents menuSave As System.Windows.Forms.MenuItem
    Friend WithEvents btnBrise As System.Windows.Forms.Button
    Friend WithEvents btnDodaj As System.Windows.Forms.Button
    Friend WithEvents btnDodajPoziciju As System.Windows.Forms.Button
    Friend WithEvents cbUslovZaStav As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form6))
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbVrstaKola = New System.Windows.Forms.ComboBox
        Me.cmbVlasnistvoKola = New System.Windows.Forms.ComboBox
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtNPIznos = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmbNPTip = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtNP = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbTipCene = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtIznos = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtUslovZaStav = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbVrstaPrevoza = New System.Windows.Forms.ComboBox
        Me.cmbOsovine = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtStanicaDo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtStanicaOd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbSaobracaj = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUgovor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRecID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtStavka = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtNHM = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.btnPotvrdi = New System.Windows.Forms.Button
        Me.btnNE = New System.Windows.Forms.Button
        Me.datagrid1 = New System.Windows.Forms.DataGrid
        Me.menuMain = New System.Windows.Forms.MainMenu
        Me.menuRefresh = New System.Windows.Forms.MenuItem
        Me.menuSave = New System.Windows.Forms.MenuItem
        Me.btnBrise = New System.Windows.Forms.Button
        Me.btnDodaj = New System.Windows.Forms.Button
        Me.btnDodajPoziciju = New System.Windows.Forms.Button
        Me.cbUslovZaStav = New System.Windows.Forms.ComboBox
        CType(Me.datagrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Maroon
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(792, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 64)
        Me.Button1.TabIndex = 77
        Me.Button1.Text = "Povratak na predhodni ekran"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmbVrstaKola
        '
        Me.cmbVrstaKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVrstaKola.Items.AddRange(New Object() {"1 - Svi", "R - Redovno", "S - Stitna"})
        Me.cmbVrstaKola.Location = New System.Drawing.Point(40, 192)
        Me.cmbVrstaKola.Name = "cmbVrstaKola"
        Me.cmbVrstaKola.Size = New System.Drawing.Size(136, 25)
        Me.cmbVrstaKola.TabIndex = 8
        '
        'cmbVlasnistvoKola
        '
        Me.cmbVlasnistvoKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVlasnistvoKola.Items.AddRange(New Object() {"1 - Sva", "Z - Zeleznicka", "P - privatna"})
        Me.cmbVlasnistvoKola.Location = New System.Drawing.Point(544, 136)
        Me.cmbVlasnistvoKola.Name = "cmbVlasnistvoKola"
        Me.cmbVlasnistvoKola.Size = New System.Drawing.Size(144, 25)
        Me.cmbVlasnistvoKola.TabIndex = 7
        '
        'txtUserID
        '
        Me.txtUserID.Enabled = False
        Me.txtUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Location = New System.Drawing.Point(584, 304)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(104, 23)
        Me.txtUserID.TabIndex = 17
        Me.txtUserID.Text = ""
        Me.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(584, 280)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 24)
        Me.Label18.TabIndex = 74
        Me.Label18.Text = "Korisnik"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtNPIznos
        '
        Me.txtNPIznos.Enabled = False
        Me.txtNPIznos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNPIznos.Location = New System.Drawing.Point(408, 304)
        Me.txtNPIznos.Name = "txtNPIznos"
        Me.txtNPIznos.Size = New System.Drawing.Size(96, 23)
        Me.txtNPIznos.TabIndex = 16
        Me.txtNPIznos.Text = ""
        Me.txtNPIznos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(408, 280)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 24)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "NP novcani iznos"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmbNPTip
        '
        Me.cmbNPTip.Enabled = False
        Me.cmbNPTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNPTip.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cmbNPTip.Location = New System.Drawing.Point(152, 304)
        Me.cmbNPTip.Name = "cmbNPTip"
        Me.cmbNPTip.Size = New System.Drawing.Size(192, 25)
        Me.cmbNPTip.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(152, 280)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 24)
        Me.Label16.TabIndex = 72
        Me.Label16.Text = "Nacin racunanja"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtNP
        '
        Me.txtNP.Enabled = False
        Me.txtNP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNP.Location = New System.Drawing.Point(40, 304)
        Me.txtNP.MaxLength = 2
        Me.txtNP.Name = "txtNP"
        Me.txtNP.Size = New System.Drawing.Size(56, 23)
        Me.txtNP.TabIndex = 14
        Me.txtNP.Text = ""
        Me.txtNP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(40, 280)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 24)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "Broj narocite pošiljke"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmbTipCene
        '
        Me.cmbTipCene.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipCene.Items.AddRange(New Object() {"1     Procenat na tarifu", "2     Cena po toni", "3     Cena po tonskom stavu", "4     Cena po kolima", "5     Cena po vozu", "6     Cena po NTKM", "7     Dodatak na cenu zbog NP"})
        Me.cmbTipCene.Location = New System.Drawing.Point(408, 248)
        Me.cmbTipCene.Name = "cmbTipCene"
        Me.cmbTipCene.Size = New System.Drawing.Size(280, 25)
        Me.cmbTipCene.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(408, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "Tip cene"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtIznos
        '
        Me.txtIznos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIznos.Location = New System.Drawing.Point(240, 248)
        Me.txtIznos.Name = "txtIznos"
        Me.txtIznos.Size = New System.Drawing.Size(104, 23)
        Me.txtIznos.TabIndex = 12
        Me.txtIznos.Text = ""
        Me.txtIznos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(240, 224)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 24)
        Me.Label13.TabIndex = 69
        Me.Label13.Text = "Novcani iznos"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtUslovZaStav
        '
        Me.txtUslovZaStav.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUslovZaStav.Location = New System.Drawing.Point(40, 536)
        Me.txtUslovZaStav.MaxLength = 2
        Me.txtUslovZaStav.Name = "txtUslovZaStav"
        Me.txtUslovZaStav.Size = New System.Drawing.Size(72, 23)
        Me.txtUslovZaStav.TabIndex = 11
        Me.txtUslovZaStav.Text = ""
        Me.txtUslovZaStav.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(40, 224)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 24)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Uslov za tonski stav"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmbVrstaPrevoza
        '
        Me.cmbVrstaPrevoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVrstaPrevoza.Items.AddRange(New Object() {"P - pojedinacna posiljka ", "G - grupa kola", "V - voz"})
        Me.cmbVrstaPrevoza.Location = New System.Drawing.Point(280, 136)
        Me.cmbVrstaPrevoza.Name = "cmbVrstaPrevoza"
        Me.cmbVrstaPrevoza.Size = New System.Drawing.Size(248, 25)
        Me.cmbVrstaPrevoza.TabIndex = 6
        '
        'cmbOsovine
        '
        Me.cmbOsovine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOsovine.Items.AddRange(New Object() {"1 - vazi za sve slucajeve", "2", "4", "6", "8", "10"})
        Me.cmbOsovine.Location = New System.Drawing.Point(40, 136)
        Me.cmbOsovine.Name = "cmbOsovine"
        Me.cmbOsovine.Size = New System.Drawing.Size(232, 25)
        Me.cmbOsovine.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(472, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 24)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Datum važenja DO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(248, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 24)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Datum važenja OD"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(472, 192)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(216, 23)
        Me.DateTimePicker2.TabIndex = 10
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(248, 192)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(216, 23)
        Me.DateTimePicker1.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(40, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 24)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Vrsta kola"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(544, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 24)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Vlasništvo kola"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(280, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 24)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Vrsta prevoza"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(40, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 24)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Broj osovina"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtStanicaDo
        '
        Me.txtStanicaDo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStanicaDo.Location = New System.Drawing.Point(608, 80)
        Me.txtStanicaDo.MaxLength = 6
        Me.txtStanicaDo.Name = "txtStanicaDo"
        Me.txtStanicaDo.Size = New System.Drawing.Size(80, 23)
        Me.txtStanicaDo.TabIndex = 4
        Me.txtStanicaDo.Text = ""
        Me.txtStanicaDo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(608, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 24)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Uputna stanica"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtStanicaOd
        '
        Me.txtStanicaOd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStanicaOd.Location = New System.Drawing.Point(496, 80)
        Me.txtStanicaOd.MaxLength = 6
        Me.txtStanicaOd.Name = "txtStanicaOd"
        Me.txtStanicaOd.Size = New System.Drawing.Size(80, 23)
        Me.txtStanicaOd.TabIndex = 3
        Me.txtStanicaOd.Text = ""
        Me.txtStanicaOd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(496, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 24)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Otpravna stanica"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmbSaobracaj
        '
        Me.cmbSaobracaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSaobracaj.Items.AddRange(New Object() {"1 - unutrasnji", "2 - uvoz", "3 - izvoz", "4 - tranzit"})
        Me.cmbSaobracaj.Location = New System.Drawing.Point(240, 80)
        Me.cmbSaobracaj.Name = "cmbSaobracaj"
        Me.cmbSaobracaj.Size = New System.Drawing.Size(208, 25)
        Me.cmbSaobracaj.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(240, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Vrsta saobracaja"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtUgovor
        '
        Me.txtUgovor.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.txtUgovor.Enabled = False
        Me.txtUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUgovor.ForeColor = System.Drawing.Color.Black
        Me.txtUgovor.Location = New System.Drawing.Point(128, 80)
        Me.txtUgovor.Name = "txtUgovor"
        Me.txtUgovor.Size = New System.Drawing.Size(104, 23)
        Me.txtUgovor.TabIndex = 1
        Me.txtUgovor.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(128, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Broj ugovora"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtRecID
        '
        Me.txtRecID.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.txtRecID.Enabled = False
        Me.txtRecID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecID.ForeColor = System.Drawing.Color.Black
        Me.txtRecID.Location = New System.Drawing.Point(40, 80)
        Me.txtRecID.Name = "txtRecID"
        Me.txtRecID.Size = New System.Drawing.Size(72, 23)
        Me.txtRecID.TabIndex = 0
        Me.txtRecID.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 24)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Redni broj"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnPrihvati
        '
        Me.btnPrihvati.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrihvati.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(792, 288)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(120, 40)
        Me.btnPrihvati.TabIndex = 18
        Me.btnPrihvati.Text = "Prihvati"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(40, 24)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(648, 24)
        Me.Label19.TabIndex = 78
        Me.Label19.Text = "Podaci koji se odnose na aneks ugovora"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=BGNEM11216XWSB;packet size=4096;user id=radnik;password=roba2006;d" & _
        "ata source=""10.0.4.31"";persist security info=False;initial catalog=OkpWinRoba"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(40, 352)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(872, 24)
        Me.Label20.TabIndex = 79
        Me.Label20.Text = "Podaci koji se odnose na stavove i pozicije za traženi ugovor"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStavka
        '
        Me.txtStavka.Enabled = False
        Me.txtStavka.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStavka.Location = New System.Drawing.Point(40, 416)
        Me.txtStavka.MaxLength = 2
        Me.txtStavka.Name = "txtStavka"
        Me.txtStavka.Size = New System.Drawing.Size(48, 23)
        Me.txtStavka.TabIndex = 19
        Me.txtStavka.Text = ""
        Me.txtStavka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(40, 392)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 24)
        Me.Label21.TabIndex = 81
        Me.Label21.Text = "Stavka"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(112, 392)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 24)
        Me.Label22.TabIndex = 82
        Me.Label22.Text = "Pozicija robe (NHM)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtNHM
        '
        Me.txtNHM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNHM.Location = New System.Drawing.Point(112, 416)
        Me.txtNHM.MaxLength = 6
        Me.txtNHM.Name = "txtNHM"
        Me.txtNHM.Size = New System.Drawing.Size(96, 23)
        Me.txtNHM.TabIndex = 20
        Me.txtNHM.Text = ""
        Me.txtNHM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(232, 384)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(360, 88)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "Ako želite da dodate novu poziciju aneksu kliknite na dugme  ""DODAVANJE POZICIJE""" & _
        " posle unosa pozicije kliknite na dugme  ""DODAJ"" ako želite da promenite pozicij" & _
        "u kliknite na dugme  ""POTVRDI  PROMENU"" ako želite da brišete poziciju pritisnit" & _
        "e dugme  ""POTVRDI  BRISANJE"". Kada ste završili rad kliknite na dugme  ""IZLAZ""."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPotvrdi
        '
        Me.btnPotvrdi.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.btnPotvrdi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPotvrdi.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.btnPotvrdi.Image = CType(resources.GetObject("btnPotvrdi.Image"), System.Drawing.Image)
        Me.btnPotvrdi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPotvrdi.Location = New System.Drawing.Point(360, 488)
        Me.btnPotvrdi.Name = "btnPotvrdi"
        Me.btnPotvrdi.Size = New System.Drawing.Size(104, 56)
        Me.btnPotvrdi.TabIndex = 23
        Me.btnPotvrdi.Text = "POTVRDI PROMENU"
        Me.btnPotvrdi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnNE
        '
        Me.btnNE.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.btnNE.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNE.Image = CType(resources.GetObject("btnNE.Image"), System.Drawing.Image)
        Me.btnNE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNE.Location = New System.Drawing.Point(488, 560)
        Me.btnNE.Name = "btnNE"
        Me.btnNE.Size = New System.Drawing.Size(104, 56)
        Me.btnNE.TabIndex = 87
        Me.btnNE.Text = "IZLAZ"
        Me.btnNE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'datagrid1
        '
        Me.datagrid1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.datagrid1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.datagrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.datagrid1.CaptionBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.datagrid1.CaptionForeColor = System.Drawing.Color.Navy
        Me.datagrid1.CaptionText = "Prikaz unetih stavki i pozicija za uneti aneks"
        Me.datagrid1.DataMember = ""
        Me.datagrid1.GridLineColor = System.Drawing.Color.Red
        Me.datagrid1.HeaderBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(0, Byte))
        Me.datagrid1.HeaderForeColor = System.Drawing.Color.Yellow
        Me.datagrid1.Location = New System.Drawing.Point(624, 400)
        Me.datagrid1.Name = "datagrid1"
        Me.datagrid1.ParentRowsBackColor = System.Drawing.Color.Green
        Me.datagrid1.SelectionBackColor = System.Drawing.Color.Purple
        Me.datagrid1.Size = New System.Drawing.Size(288, 224)
        Me.datagrid1.TabIndex = 88
        '
        'menuMain
        '
        Me.menuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuRefresh, Me.menuSave})
        '
        'menuRefresh
        '
        Me.menuRefresh.Index = 0
        Me.menuRefresh.Text = "     &Osveži"
        '
        'menuSave
        '
        Me.menuSave.Index = 1
        Me.menuSave.Text = "     &Sacuvaj"
        '
        'btnBrise
        '
        Me.btnBrise.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.btnBrise.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrise.ForeColor = System.Drawing.Color.Red
        Me.btnBrise.Image = CType(resources.GetObject("btnBrise.Image"), System.Drawing.Image)
        Me.btnBrise.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrise.Location = New System.Drawing.Point(488, 488)
        Me.btnBrise.Name = "btnBrise"
        Me.btnBrise.Size = New System.Drawing.Size(104, 56)
        Me.btnBrise.TabIndex = 24
        Me.btnBrise.Text = "POTVRDI BRISANJE"
        Me.btnBrise.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnDodaj
        '
        Me.btnDodaj.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.btnDodaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDodaj.ForeColor = System.Drawing.Color.Green
        Me.btnDodaj.Image = CType(resources.GetObject("btnDodaj.Image"), System.Drawing.Image)
        Me.btnDodaj.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodaj.Location = New System.Drawing.Point(232, 560)
        Me.btnDodaj.Name = "btnDodaj"
        Me.btnDodaj.Size = New System.Drawing.Size(104, 56)
        Me.btnDodaj.TabIndex = 22
        Me.btnDodaj.Text = "DODAJ"
        Me.btnDodaj.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnDodajPoziciju
        '
        Me.btnDodajPoziciju.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.btnDodajPoziciju.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDodajPoziciju.ForeColor = System.Drawing.Color.Green
        Me.btnDodajPoziciju.Location = New System.Drawing.Point(232, 488)
        Me.btnDodajPoziciju.Name = "btnDodajPoziciju"
        Me.btnDodajPoziciju.Size = New System.Drawing.Size(104, 56)
        Me.btnDodajPoziciju.TabIndex = 21
        Me.btnDodajPoziciju.Text = "DODAVANJE POZICIJE"
        '
        'cbUslovZaStav
        '
        Me.cbUslovZaStav.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUslovZaStav.Items.AddRange(New Object() {" 1   - Svi stavovi", "10 t", "15 t", "20 t", "25 t", "30 t", "35 t", "40 t", "45 t"})
        Me.cbUslovZaStav.Location = New System.Drawing.Point(40, 248)
        Me.cbUslovZaStav.Name = "cbUslovZaStav"
        Me.cbUslovZaStav.Size = New System.Drawing.Size(176, 25)
        Me.cbUslovZaStav.TabIndex = 89
        '
        'Form6
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.ClientSize = New System.Drawing.Size(928, 638)
        Me.Controls.Add(Me.cbUslovZaStav)
        Me.Controls.Add(Me.btnDodajPoziciju)
        Me.Controls.Add(Me.btnDodaj)
        Me.Controls.Add(Me.btnBrise)
        Me.Controls.Add(Me.datagrid1)
        Me.Controls.Add(Me.btnNE)
        Me.Controls.Add(Me.btnPotvrdi)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtNHM)
        Me.Controls.Add(Me.txtStavka)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.txtNPIznos)
        Me.Controls.Add(Me.txtNP)
        Me.Controls.Add(Me.txtIznos)
        Me.Controls.Add(Me.txtUslovZaStav)
        Me.Controls.Add(Me.txtStanicaDo)
        Me.Controls.Add(Me.txtStanicaOd)
        Me.Controls.Add(Me.txtUgovor)
        Me.Controls.Add(Me.txtRecID)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.cmbVrstaKola)
        Me.Controls.Add(Me.cmbVlasnistvoKola)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmbNPTip)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbTipCene)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmbVrstaPrevoza)
        Me.Controls.Add(Me.cmbOsovine)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbSaobracaj)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Menu = Me.menuMain
        Me.Name = "Form6"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Izmena izabranog aneksa"
        CType(Me.datagrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Function PromenaPodatak(ByVal connnectionString As String, _
                                         ByVal RecID As String, _
                                         ByVal Ugovor As String, _
                                         ByVal Saobracaj As String, _
                                         ByVal StanicaOd As String, _
                                         ByVal StanicaDo As String, _
                                         ByVal Osovine As Integer, _
                                         ByVal VrstaPrevoza As String, _
                                         ByVal VlasnistvoKola As String, _
                                         ByVal VrstaKola As String, _
                                         ByVal DatumOd As DateTime, _
                                         ByVal DatumDo As DateTime, _
                                         ByVal UslovZaStav As Integer, _
                                         ByVal Iznos As Decimal, _
                                         ByVal TipCene As Integer, _
                                         ByVal NP As String, _
                                         ByVal NPTip As Integer, _
                                         ByVal NPIznos As Decimal, _
                                         ByVal UserID As String) As DataRow
        Dim connection As New SqlConnection(ConnectionString)
        Dim result As DataRow
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Try
            command = New SqlCommand("uspPromCoAneksi", connection)
            command.CommandType = CommandType.StoredProcedure

            Dim RecIDParm As SqlParameter = _
                             command.Parameters.Add("@RecID", SqlDbType.Int)
            RecIDParm.Direction = ParameterDirection.Input
            RecIDParm.Value = RecID

            Dim UgovorParm As SqlParameter = _
                             command.Parameters.Add("@Ugovor", SqlDbType.Char, 6)
            UgovorParm.Direction = ParameterDirection.Input
            UgovorParm.Value = Ugovor

            Dim SaobracajParm As SqlParameter = _
                             command.Parameters.Add("@Saobracaj", SqlDbType.Char, 1)
            SaobracajParm.Direction = ParameterDirection.Input
            SaobracajParm.Value = Saobracaj

            Dim StanicaOdParm As SqlParameter = _
                             command.Parameters.Add("@StanicaOd", SqlDbType.Char, 5)
            StanicaOdParm.Direction = ParameterDirection.Input
            StanicaOdParm.Value = StanicaOd

            Dim StanicaDoParm As SqlParameter = _
                             command.Parameters.Add("@StanicaDo", SqlDbType.Char, 5)
            StanicaDoParm.Direction = ParameterDirection.Input
            StanicaDoParm.Value = StanicaDo

            Dim OsovineParm As SqlParameter = _
                 command.Parameters.Add("@Osovine", SqlDbType.Int)
            OsovineParm.Direction = ParameterDirection.Input
            OsovineParm.Value = Osovine

            Dim VrstaPrevozaParm As SqlParameter = _
                 command.Parameters.Add("@VrstaPrevoza", SqlDbType.Char, 1)
            VrstaPrevozaParm.Direction = ParameterDirection.Input
            VrstaPrevozaParm.Value = VrstaPrevoza

            Dim VlasnistvoKolaParm As SqlParameter = _
                 command.Parameters.Add("@VlasnistvoKola", SqlDbType.Char, 1)
            VlasnistvoKolaParm.Direction = ParameterDirection.Input
            VlasnistvoKolaParm.Value = VlasnistvoKola

            Dim VrstaKolaParm As SqlParameter = _
                 command.Parameters.Add("@VrstaKola", SqlDbType.Char, 1)
            VrstaKolaParm.Direction = ParameterDirection.Input
            VrstaKolaParm.Value = VrstaKola

            Dim DatumOdParm As SqlParameter = _
                 command.Parameters.Add("@DatumOd", SqlDbType.DateTime)
            DatumOdParm.Direction = ParameterDirection.Input
            DatumOdParm.Value = DatumOd

            Dim DatumDoParm As SqlParameter = _
                 command.Parameters.Add("@DatumDo", SqlDbType.DateTime)
            DatumDoParm.Direction = ParameterDirection.Input
            DatumDoParm.Value = DatumDo

            Dim UslovZaStavParm As SqlParameter = _
                 command.Parameters.Add("@UslovZaStav", SqlDbType.Int)
            UslovZaStavParm.Direction = ParameterDirection.Input
            UslovZaStavParm.Value = UslovZaStav

            Dim IznosParm As SqlParameter = _
                 command.Parameters.Add("@Iznos", SqlDbType.Decimal)
            IznosParm.Direction = ParameterDirection.Input
            IznosParm.Value = Iznos

            Dim TipCeneParm As SqlParameter = _
                 command.Parameters.Add("@TipCene", SqlDbType.Int)
            TipCeneParm.Direction = ParameterDirection.Input
            TipCeneParm.Value = TipCene

            Dim NPParm As SqlParameter = _
                 command.Parameters.Add("@NP", SqlDbType.Char, 10)
            NPParm.Direction = ParameterDirection.Input
            NPParm.Value = NP

            Dim NPTipParm As SqlParameter = _
                 command.Parameters.Add("@NPTip", SqlDbType.Int)
            NPTipParm.Direction = ParameterDirection.Input
            NPTipParm.Value = NPTip

            Dim NPIznosParm As SqlParameter = _
                 command.Parameters.Add("@NPIznos", SqlDbType.Decimal)
            NPIznosParm.Direction = ParameterDirection.Input
            NPIznosParm.Value = NPIznos

            Dim UserIDParm As SqlParameter = _
                 command.Parameters.Add("@UserID", SqlDbType.Char, 4)
            UserIDParm.Direction = ParameterDirection.Input
            UserIDParm.Value = UserID

            Dim datatable As New DataTable
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datatable)
            result = GetRowFromTable(datatable)


        Catch ex As Exception
            MsgBox(ex.ToString)


        Finally
            If Not adapter Is Nothing Then
                adapter.Dispose()
            End If
            If Not command Is Nothing Then
                command.Dispose()
            End If
        End Try
        Return result
    End Function

    Public Function PromPodatakNHM(ByVal connnectionString As String, _
                                     ByVal RecID As Integer, _
                                     ByVal Stavka As Integer, _
                                     ByVal NHM As String) As DataRow
        Dim connection As New SqlConnection(ConnectionString)
        Dim result As DataRow
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Try
            command = New SqlCommand("promCoAneksiNHM", connection)
            command.CommandType = CommandType.StoredProcedure

            Dim RecIDParm As SqlParameter = _
                             command.Parameters.Add("@RecID", SqlDbType.Int)
            RecIDParm.Direction = ParameterDirection.Input
            RecIDParm.Value = RecID

            Dim StavkaParm As SqlParameter = _
                             command.Parameters.Add("@Stavka", SqlDbType.Int)
            StavkaParm.Direction = ParameterDirection.Input
            StavkaParm.Value = Stavka

            Dim NHMParm As SqlParameter = _
                             command.Parameters.Add("@NHM", SqlDbType.Char, 6)
            NHMParm.Direction = ParameterDirection.Input
            NHMParm.Value = NHM


            Dim datatable As New DataTable
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datatable)
            result = GetRowFromTable(datatable)


        Catch ex As Exception
            MsgBox(ex.ToString)


        Finally
            If Not adapter Is Nothing Then
                adapter.Dispose()
            End If
            If Not command Is Nothing Then
                command.Dispose()
            End If
        End Try
        Return result
    End Function

    Public Function BrisePodatakNHM(ByVal connnectionString As String, _
                                         ByVal RecID As Integer, _
                                         ByVal Stavka As Integer) As DataRow
        'ByVal NHM As String) As DataRow
        Dim connection As New SqlConnection(ConnectionString)
        Dim result As DataRow
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Try
            command = New SqlCommand("briseCoAneksiNHM", connection)
            command.CommandType = CommandType.StoredProcedure

            Dim RecIDParm As SqlParameter = _
                             command.Parameters.Add("@RecID", SqlDbType.Int)
            RecIDParm.Direction = ParameterDirection.Input
            RecIDParm.Value = RecID

            Dim StavkaParm As SqlParameter = _
                             command.Parameters.Add("@Stavka", SqlDbType.Int)
            StavkaParm.Direction = ParameterDirection.Input
            StavkaParm.Value = Stavka

            'Dim NHMParm As SqlParameter = _
            '                 command.Parameters.Add("@NHM", SqlDbType.Char, 6)
            'NHMParm.Direction = ParameterDirection.Input
            'NHMParm.Value = NHM


            Dim datatable As New DataTable
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datatable)
            result = GetRowFromTable(datatable)


        Catch ex As Exception
            MsgBox(ex.ToString)


        Finally
            If Not adapter Is Nothing Then
                adapter.Dispose()
            End If
            If Not command Is Nothing Then
                command.Dispose()
            End If
        End Try
        Return result
    End Function

    Public Function UnosPodatakNHM(ByVal connnectionString As String, _
                                            ByVal RecID As Integer, _
                                            ByVal Stavka As Integer, _
                                            ByVal NHM As String) As DataRow
        Dim connection As New SqlConnection(ConnectionString)
        Dim result As DataRow
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Try
            command = New SqlCommand("uspAzurCoAneksiNHM", connection)
            command.CommandType = CommandType.StoredProcedure

            Dim RecIDParm As SqlParameter = _
                             command.Parameters.Add("@RecID", SqlDbType.Int)
            RecIDParm.Direction = ParameterDirection.Input
            RecIDParm.Value = RecID

            Dim StavkaParm As SqlParameter = _
                             command.Parameters.Add("@Stavka", SqlDbType.Int)
            StavkaParm.Direction = ParameterDirection.Input
            StavkaParm.Value = Stavka

            Dim NHMParm As SqlParameter = _
                             command.Parameters.Add("@NHM", SqlDbType.Char, 6)
            NHMParm.Direction = ParameterDirection.Input
            NHMParm.Value = NHM


            Dim datatable As New DataTable
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datatable)
            result = GetRowFromTable(datatable)


        Catch ex As Exception
            MsgBox(ex.ToString)


        Finally
            If Not adapter Is Nothing Then
                adapter.Dispose()
            End If
            If Not command Is Nothing Then
                command.Dispose()
            End If
        End Try
        Return result
    End Function

    '######################################
    'Metod za vracanje prvog reda u tabelu.
    '--------------------------------------
    '======================================
    Protected Shared Function GetRowFromTable(ByVal table As DataTable) As DataRow
        If table Is Nothing OrElse table.Rows.Count = 0 Then
            Return Nothing
        Else
            Return table.Rows(0)
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub


    Private Sub txtUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))

            If txtUgovor.Text = "" Then
                MessageBox.Show("Nije unet isptavan broj ugovora! Ne može da bude ni blanko! - Unesite ponovo broj ugovora!")
            Else
                Ugovorpom1 = txtUgovor.Text

                Dim intCounter1 As Integer
                Dim str1SQL As String
                Dim objCommand1 As SqlClient.SqlCommand
                Dim objDAA As SqlClient.SqlDataAdapter
                Dim objDSS As New Data.DataSet

                Ugovorpom = 0
                i = 0

                '-------------------------------------------------------------------------------------------
                'Poziva tabelu "Ugovori" pretrazuje je i uparuje unet broj ugovora sa brojevima ugovora u 
                'odgovarajucem polju tabele. Ako ne upari podatke vraca korisnika na ponovni unos broja
                'ugovora. Ako greskom ne unese broj ugovora a pritisne <Enter> takodje ga vraca na pnovni
                'unos.
                '-------------------------------------------------------------------------------------------
                str1SQL = "SELECT * FROM Ugovori"
                objCommand1 = New SqlClient.SqlCommand(str1SQL, New SqlClient.SqlConnection(ConnectionString))
                objCommand1.Connection.Open()
                objDAA = New SqlClient.SqlDataAdapter(str1SQL, ConnectionString)
                objDAA.Fill(objDSS)

                With objDSS.Tables(0)
                    For intCounter1 = 0 To .Rows.Count - 1
                        Ugovorpom = .Rows(intCounter1).Item("BrojUgovora")
                        If Ugovorpom = Ugovorpom1 Then
                            i = 1
                            Exit For
                        End If
                    Next
                End With
                '-------------------------------------------------------------------------------------------
                If i = 0 Or txtUgovor.Text = "" Then
                    MessageBox.Show("Nije unet isptavan broj ugovora! Ne može da bude ni blanko! - Unesite ponovo broj ugovora!")
                End If
            End If
            txtUgovor.Focus()
        End If
    End Sub

    Private Sub txtUserID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserID.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If txtUserID.Text = "" Then
                MessageBox.Show("Nije uneta šifra korisnika! Ne može da bude blanko! - Unesite šifru korisnika!")
            End If
            txtUserID.Focus()
        End If
    End Sub

    Private Sub txtUslovZaStav_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUslovZaStav.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If txtUslovZaStav.Text = "" Then
                MessageBox.Show("Nije unet uslov za stav! Ne može da bude blanko! - Unesite uslov za stav!")
            End If
            txtUslovZaStav.Focus()
        End If
    End Sub

    Private Sub txtStanicaOd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStanicaOd.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))

            If txtStanicaOd.Text = "" Then
                MessageBox.Show("Nije uneta ispravna sifra stanice! Ne može da bude blanko! - Unesite ispravnu sifru stanice!")
            Else
                Stanicapom = txtStanicaOd.Text

                Dim intCounter1 As Integer
                Dim str1SQL As String
                Dim objCommand1 As SqlClient.SqlCommand
                Dim objDAA As SqlClient.SqlDataAdapter
                Dim objDSS As New Data.DataSet

                i = 0

                '-------------------------------------------------------------------------------------------
                'Poziva tabelu "ZsStanice" pretrazuje je i uparuje unet broj stanice sa sifrom stanice u 
                'odgovarajucem polju tabele. Ako ne upari podatke vraca korisnika na ponovni unos sifre
                'stanice. Ako greskom ne unese sifru stanice a pritisne <Enter> takodje ga vraca na pnovni
                'unos.
                '-------------------------------------------------------------------------------------------
                str1SQL = "SELECT * FROM ZsStanice"
                objCommand1 = New SqlClient.SqlCommand(str1SQL, New SqlClient.SqlConnection(ConnectionString))
                objCommand1.Connection.Open()
                objDAA = New SqlClient.SqlDataAdapter(str1SQL, ConnectionString)
                objDAA.Fill(objDSS)

                With objDSS.Tables(0)
                    For intCounter1 = 0 To .Rows.Count - 1
                        Stanicapom1 = .Rows(intCounter1).Item("SifraStanice")
                        Stanicapom2 = Microsoft.VisualBasic.Right(Stanicapom1, 5)
                        If Stanicapom2 = Stanicapom Then
                            i = 1
                            Exit For
                        End If
                    Next
                End With
                '-------------------------------------------------------------------------------------------
                If i = 0 Or txtStanicaOd.Text = "" Then
                    MessageBox.Show("Nije uneta isptavana sifra stanice! Ne može da bude ni blanko! - Unesite ponovo sifru stanice!")
                End If
            End If
            txtStanicaOd.Focus()
        End If
    End Sub

    Private Sub txtStanicaDo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStanicaDo.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))

            If txtStanicaDo.Text = "" Then
                MessageBox.Show("Nije uneta ispravna sifra stanice! Ne može da bude blanko! - Unesite ispravnu sifru stanice!")
            Else
                Stanicapom = txtStanicaDo.Text

                Dim intCounter1 As Integer
                Dim str1SQL As String
                Dim objCommand1 As SqlClient.SqlCommand
                Dim objDAA As SqlClient.SqlDataAdapter
                Dim objDSS As New Data.DataSet

                i = 0

                '-------------------------------------------------------------------------------------------
                'Poziva tabelu "ZsStanice" pretrazuje je i uparuje unet broj stanice sa sifrom stanice u 
                'odgovarajucem polju tabele. Ako ne upari podatke vraca korisnika na ponovni unos sifre
                'stanice. Ako greskom ne unese sifru stanice a pritisne <Enter> takodje ga vraca na pnovni
                'unos.
                '-------------------------------------------------------------------------------------------
                str1SQL = "SELECT * FROM ZsStanice"
                objCommand1 = New SqlClient.SqlCommand(str1SQL, New SqlClient.SqlConnection(ConnectionString))
                objCommand1.Connection.Open()
                objDAA = New SqlClient.SqlDataAdapter(str1SQL, ConnectionString)
                objDAA.Fill(objDSS)

                With objDSS.Tables(0)
                    For intCounter1 = 0 To .Rows.Count - 1
                        Stanicapom1 = .Rows(intCounter1).Item("SifraStanice")
                        Stanicapom2 = Microsoft.VisualBasic.Right(Stanicapom1, 5)
                        If Stanicapom2 = Stanicapom Then
                            i = 1
                            Exit For
                        End If
                    Next
                End With
                '-------------------------------------------------------------------------------------------
                If i = 0 Or txtStanicaDo.Text = "" Then
                    MessageBox.Show("Nije uneta isptavana sifra stanice! Ne može da bude ni blanko! - Unesite ponovo sifru stanice!")
                End If
            End If
            txtStanicaDo.Focus()
        End If
    End Sub

    Private Sub txtRecID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecID.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            txtRecID.Focus()
            Dim intCounter1 As Integer
            Dim str1SQL As String
            Dim objCommand1 As SqlClient.SqlCommand
            Dim objDAA As SqlClient.SqlDataAdapter
            Dim objDSS As New Data.DataSet

            RecIDpom = 0

            '-------------------------------------------------------------------------------------------
            'Poziva tabelu u koju se unose podaci i preuzima polje "RecID". Vrednost polja uvecava
            'za jedan (1) i novu vrednost dodeljuje polju "txtRecID". Na ovaj nacin korisnik ne mora da
            'unosi ovaj podatak, vec samo potvrdi dodeljenu vrednost sa ENTER i prelazi na sledece polje. 
            '-------------------------------------------------------------------------------------------
            str1SQL = "SELECT * FROM CoAneksi"
            objCommand1 = New SqlClient.SqlCommand(str1SQL, New SqlClient.SqlConnection(ConnectionString))
            objCommand1.Connection.Open()
            objDAA = New SqlClient.SqlDataAdapter(str1SQL, ConnectionString)
            objDAA.Fill(objDSS)

            With objDSS.Tables(0)
                For intCounter1 = 0 To .Rows.Count - 1
                    RecIDpom = .Rows(intCounter1).Item("RecID")
                Next
            End With
            '-------------------------------------------------------------------------------------------
            RecIDpom = RecIDpom + 1
            txtRecID.Text = RecIDpom
            If txtRecID.Text = "" Then
                MessageBox.Show("Nije unet redni broj sloga! Ne može da bude blanko! - Unesite broj sloga!")
            End If
        End If
    End Sub

    Private Sub txtNPIznos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNPIznos.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If txtNPIznos.Text = "" Then
                MessageBox.Show("Nije unet novcani iznos! Ne može da bude blanko! - Unesite novcani iznos!")
            End If
            txtNPIznos.Focus()
        End If
    End Sub

    Private Sub txtNP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNP.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If txtNP.Text = "" Then
                MessageBox.Show("Nije unet broj narocite pošiljke! Ne može da bude blanko! - Unesite broj!")
            End If
            txtNP.Focus()
        End If
    End Sub

    Private Sub txtIznos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIznos.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If txtIznos.Text = "" Then
                MessageBox.Show("Nije unet novcani iznos! Ne može da bude blanko! - Unesite novcani iznos!")
            End If
            txtIznos.Focus()
        End If
    End Sub

    Private Sub cmbNPTip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNPTip.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cmbNPTip.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            cmbNPTip.Focus()
        End If
    End Sub

    Private Sub cmbOsovine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbOsovine.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cmbOsovine.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            cmbOsovine.Focus()
        End If
    End Sub

    Private Sub cmbSaobracaj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSaobracaj.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cmbSaobracaj.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            cmbSaobracaj.Focus()
        End If
    End Sub

    Private Sub cmbTipCene_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipCene.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cmbTipCene.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            cmbTipCene.Focus()
        End If
    End Sub

    Private Sub cmbVlasnistvoKola_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbVlasnistvoKola.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cmbVlasnistvoKola.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            cmbVlasnistvoKola.Focus()
        End If
    End Sub

    Private Sub cmbVrstaKola_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbVrstaKola.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cmbVrstaKola.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            cmbVrstaKola.Focus()
        End If
    End Sub

    Private Sub cmbVrstaPrevoza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbVrstaPrevoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cmbVrstaPrevoza.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            cmbVrstaPrevoza.Focus()
        End If
    End Sub
    Private Sub cbUslovZaStav_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbUslovZaStav.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cbUslovZaStav.Text = "" Then
                MessageBox.Show("Nije unet stav! Ne može da bude blanko! - Unesite tonski stav!")
            End If

        End If
    End Sub
    Private Sub DateTimePicker1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If DateTimePicker1.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            DateTimePicker1.Focus()
        End If
    End Sub

    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If DateTimePicker2.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            DateTimePicker2.Focus()
        End If
    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim RecID As Integer
        Dim Ugovor As String
        Dim Saobracaj As String
        Dim StanicaOd As String
        Dim StanicaDo As String
        Dim Osovine As Integer
        Dim VrstaPrevoza As String
        Dim VlasnistvoKola As String
        Dim VrstaKola As String
        Dim DatumOd As DateTime
        Dim DatumDo As DateTime
        Dim UslovZaStav As Integer
        Dim Iznos As Decimal
        Dim TipCene As Integer
        Dim NP As String
        Dim NPTip As Integer
        Dim NPIznos As Decimal
        Dim UserID As String

        Ugovor = txtUgovor.Text
        Saobracajj = cmbSaobracaj.Text
        Saobracaj = Microsoft.VisualBasic.Left(Saobracajj, 1)
        StanicaOd = txtStanicaOd.Text
        StanicaDo = txtStanicaDo.Text
        Osovinee = cmbOsovine.Text
        Osovine = Microsoft.VisualBasic.Left(Osovinee, 1)
        VrstaPrevozaa = cmbVrstaPrevoza.Text
        VrstaPrevoza = Microsoft.VisualBasic.Left(VrstaPrevozaa, 1)
        VlasnistvoKolaa = cmbVlasnistvoKola.Text
        VlasnistvoKola = Microsoft.VisualBasic.Left(VlasnistvoKolaa, 1)
        VrstaKolaa = cmbVrstaKola.Text
        VrstaKola = Microsoft.VisualBasic.Left(VrstaKolaa, 1)
        DatumOdd = DateTimePicker1.Text
        DatumOd = DatumOdd
        DatumDoo = DateTimePicker2.Text
        DatumDo = DatumDoo
        UslovZaStav = Microsoft.VisualBasic.Left(Me.cbUslovZaStav.Text, 2) 'txtUslovZaStav.Text
        Iznos = CDbl(txtIznos.Text)
        TipCenee = cmbTipCene.Text
        TipCene = Microsoft.VisualBasic.Left(TipCenee, 1)


        'Dodeljuje vrednost u cetiri zadlja polja. Za sada su to nule!
        'Polja su osencena i korisnik ne moze da im pristupi da bi 
        'menjao podatke.
        '-------------------------------------------------------------
        txtNP.Text = 0
        cmbNPTip.Text = 0
        txtNPIznos.Text = 0
        txtUserID.Text = 0
        NP = txtNP.Text
        NPTipp = cmbNPTip.Text
        NPIznos = CDbl(txtNPIznos.Text)
        UserID = txtUserID.Text
        RecID = txtRecID.Text

        'txtRecID.Text = ""
        'txtUgovor.Text = ""
        'cmbSaobracaj.Text = Nothing
        Saobracajj = ""
        'txtStanicaOd.Text = ""
        'txtStanicaDo.Text = ""
        'cmbOsovine.Text = Nothing
        Osovinee = ""
        'cmbVrstaPrevoza.Text = Nothing
        VrstaPrevozaa = ""
        'cmbVlasnistvoKola.Text = Nothing
        'cmbVrstaKola.Text = Nothing
        DatumOdd = ""
        DatumDoo = ""
        'txtUslovZaStav.Text = ""
        'txtIznos.Text = ""
        'cmbTipCene.Text = Nothing
        TipCenee = ""
        txtNP.Text = ""
        cmbNPTip.Text = ""
        NPTipp = ""
        txtNPIznos.Text = ""
        txtUserID.Text = ""

        '-------------------------------------------------------------------------------------------
        'Poziva proceduru za azuriranje tabele. U ovom slucaju se radi o UPDATE.
        'Izmena se radu u tabeli "CoAneksi".
        '-------------------------------------------------------------------------------------------

        Dim PrCoAneksii As DataRow = PromenaPodatak(ConnectionString, RecID, Ugovor, Saobracaj, StanicaOd, StanicaDo, Osovine, _
                                                                 VrstaPrevoza, VlasnistvoKola, VrstaKola, DatumOd, DatumDo, _
                                                                 UslovZaStav, Iznos, TipCene, NP, NPTip, NPIznos, UserID)


        txtNP.Text = 0
        cmbNPTip.Text = 0
        txtNPIznos.Text = 0
        txtUserID.Text = 0

        txtNP.Enabled = False
        cmbNPTip.Enabled = False
        txtNPIznos.Enabled = False
        txtUserID.Enabled = False

        txtUgovor.Enabled = False
        cmbSaobracaj.Enabled = False
        txtStanicaOd.Enabled = False
        txtStanicaDo.Enabled = False
        cmbOsovine.Enabled = False
        cmbVrstaPrevoza.Enabled = False
        cmbVlasnistvoKola.Enabled = False
        cmbVrstaKola.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        cbUslovZaStav.Enabled = False
        txtIznos.Enabled = False
        cmbTipCene.Enabled = False

        btnPrihvati.Enabled = False
        'MessageBox.Show(UserID)



    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtRecID.Text = PPRecID

        rade11 = "SELECT RecID, Stavka, NHM FROM CoAneksiNHM WHERE RecID = '" & txtRecID.Text & "'"
        RefreshData()

        txtUgovor.Text = PPUgovor
        cmbSaobracaj.Text = PPSaobracaj
        Saobracajj = ""
        txtStanicaOd.Text = PPStanicaOd
        txtStanicaDo.Text = PPStanicaDo
        cmbOsovine.Text = PPOsovine
        Osovinee = ""
        cmbVrstaPrevoza.Text = PPVrstaPrevoza
        VrstaPrevozaa = ""
        cmbVlasnistvoKola.Text = PPVlasnistvoKola
        cmbVrstaKola.Text = PPVrstaKola
        DateTimePicker1.Text = PPDatumOd
        DateTimePicker2.Text = PPDatumDo
        DatumOdd = ""
        DatumDoo = ""
        cbUslovZaStav.Text = PPUslovZaStav
        txtIznos.Text = PPIznos
        cmbTipCene.Text = PPTipCene
        TipCenee = ""
        txtNP.Text = PPNT
        cmbNPTip.Text = PPNPTip
        NPTipp = ""
        txtNPIznos.Text = PPNPIznos
        txtUserID.Text = PPUserID
    End Sub
    Private Sub datagrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles datagrid1.DoubleClick
        txtStavka.Text = datagrid1.Item(datagrid1.CurrentCell.RowNumber, 1)
        txtNHM.Text = datagrid1.Item(datagrid1.CurrentCell.RowNumber, 2)
    End Sub
    Private Sub menuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRefresh.Click
        RefreshData()
    End Sub

    Private Sub menuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSave.Click
        SaveData()
    End Sub

    Private Sub btnPotvrdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPotvrdi.Click
        Dim RecID As Integer
        Dim Stavka As Integer
        Dim NHM As String


        RecID = txtRecID.Text
        Stavka = txtStavka.Text
        NHM = txtNHM.Text

        Dim CoAneksiNHMM As DataRow = PromPodatakNHM(ConnectionString, RecID, Stavka, NHM)
        RefreshData()
        txtStavka.Text = ""
        txtNHM.Text = ""

    End Sub

    Private Sub txtStavka_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStavka.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If txtStavka.Text = "" Then
                MessageBox.Show("Nije uneta stavka! Ne može da bude blanko! - Unesite stavku!")
            End If
            txtStavka.Focus()
        End If
    End Sub

    Private Sub txtNHM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNHM.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))

            If txtNHM.Text = "" Then
                MessageBox.Show("Nije uneta ispravna sifra pozicije! Ne može da bude blanko! - Unesite ispravnu sifru pozicije!")
            Else
                NHMpom = txtNHM.Text

                Dim intCounter3 As Integer
                Dim str3SQL As String
                Dim objCommand3 As SqlClient.SqlCommand
                Dim objDAA3 As SqlClient.SqlDataAdapter
                Dim objDSS3 As New Data.DataSet

                i = 0

                '-------------------------------------------------------------------------------------------
                'Poziva tabelu "NHMPozicije" pretrazuje je i uparuje unet broj pozicije sa sifrom pozicije u 
                'odgovarajucem polju tabele. Ako ne upari podatke vraca korisnika na ponovni unos sifre
                'pozicije. Ako greskom ne unese sifru pozicije a pritisne <Enter> takodje ga vraca na pnovni
                'unos.
                '-------------------------------------------------------------------------------------------
                str3SQL = "SELECT * FROM NHMPozicije"
                objCommand3 = New SqlClient.SqlCommand(str3SQL, New SqlClient.SqlConnection(ConnectionString))
                objCommand3.Connection.Open()
                objDAA3 = New SqlClient.SqlDataAdapter(str3SQL, ConnectionString)
                objDAA3.Fill(objDSS3)

                With objDSS3.Tables(0)
                    For intCounter3 = 0 To .Rows.Count - 1
                        NHMpom1 = .Rows(intCounter3).Item("NHMSifra")
                        NHMpom2 = Microsoft.VisualBasic.Left(NHMpom1, 4)
                        If NHMpom2 = NHMpom Then
                            i = 1
                            Exit For
                        End If
                    Next
                End With
                '-------------------------------------------------------------------------------------------
                If i = 0 Or txtNHM.Text = "" Then
                    MessageBox.Show("Nije uneta isptavana sifra pozicije! Ne može da bude ni blanko! - Unesite ponovo sifru pozicije!")
                End If
            End If
            txtNHM.Focus()
        End If
    End Sub

    Private Sub btnNE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNE.Click
        Me.Dispose()
    End Sub

    Private Sub btnBrise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrise.Click
        Dim RecID As Integer
        Dim Stavka As Integer
        Dim NHM As String


        RecID = txtRecID.Text
        Stavka = txtStavka.Text

        Dim CoAneksiNHM1 As DataRow = BrisePodatakNHM(ConnectionString, RecID, Stavka)
        RefreshData()
        txtStavka.Text = ""
        txtNHM.Text = ""
        'btnDA.Enabled = False

    End Sub

    Private Sub btnDodaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodaj.Click
        Dim RecID As Integer
        Dim Stavka As Integer
        Dim NHM As String


        RecID = txtRecID.Text
        Stavka = txtStavka.Text
        NHM = txtNHM.Text

        Dim CoAneksiNHMM As DataRow = UnosPodatakNHM(ConnectionString, RecID, Stavka, NHM)
        RefreshData()
        txtStavka.Text = ""
        txtNHM.Text = ""
        'btnDA.Enabled = False

        txtStavka.Focus()
    End Sub

    Private Sub btnDodajPoziciju_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajPoziciju.Click
        Dim RecID As Integer
        Dim Stavka As Integer
        Dim NHM As String
        Dim Stavpom As Integer
        Dim RecIDpom1 As Integer

        RecIDpom1 = txtRecID.Text

        Dim intCounter2 As Integer
        Dim str2SQL As String
        Dim objCommand2 As SqlClient.SqlCommand
        Dim objDAA2 As SqlClient.SqlDataAdapter
        Dim objDSS2 As New Data.DataSet

        RecIDpom = 0

        '-------------------------------------------------------------------------------------------
        'Poziva tabelu u koju se unose podaci za pozicije i uparuje sa poljem "RecID".
        'Kada upari sa ovim poljem uzima polje "Stavka". Kada zavrsi tada uveca Stavk-u za jedan tako 
        'da korisnik ne mora da unosi ovaj podatak da ne bi pogresio. 
        '-------------------------------------------------------------------------------------------
        str2SQL = "SELECT * FROM CoAneksiNHM"
        objCommand2 = New SqlClient.SqlCommand(str2SQL, New SqlClient.SqlConnection(ConnectionString))
        objCommand2.Connection.Open()
        objDAA2 = New SqlClient.SqlDataAdapter(str2SQL, ConnectionString)
        objDAA2.Fill(objDSS2)

        With objDSS2.Tables(0)
            For intCounter2 = 0 To .Rows.Count - 1
                RecIDpom = .Rows(intCounter2).Item("RecID")
                If RecIDpom = RecIDpom1 Then
                    Stavpom = .Rows(intCounter2).Item("Stavka")
                End If
            Next
        End With
        '-------------------------------------------------------------------------------------------

        txtStavka.Text = Stavpom + 1
        txtNHM.Focus()

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
