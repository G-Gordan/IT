Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Form3
    Inherits System.Windows.Forms.Form
    'Public Const ConnectionString As String = SqlConnection1
    '    "integrated security=sspi;initial catalog=OkpWinRoba"

    Public stringUpit As String
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

    Dim StavkaParm As Integer
    Dim NHMParm As String

    '==============================================================
    'Sklonjen je prikaz tabele u DataGrid-u. Nije potreban ptrikaz.
    '==============================================================
    Public Sub RefreshData()
        Dim connection1 As New SqlConnection(ConnectionString)
        'Ovde je deklarisana "connection" ali je neophodno otvoriti
        '"SqlConnection1" koji je upotrebljen kao veza. Pogledati 
        '"Form1[Design]*". Takodje zatvoriti "SqlConnection1".
        '----------------------------------------------------------
        Try
            SqlConnection1.Open()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try


        Dim adapter1 As New SqlDataAdapter(stringUpit, _
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
        Dim adapter As New SqlDataAdapter(stringUpit, _
           SqlConnection1)
        Dim builder As New SqlCommandBuilder(adapter)
        Dim rows() As DataRow = CType(changedRows.ToArray(GetType(DataRow)), DataRow())
        adapter.Update(rows)
        ''adapter.Dispose()
        'menuSave.Enabled = False
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
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents btnPrikaz As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRecID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbSaobracaj As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtStanicaOd As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStanicaDo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbOsovine As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVrstaPrevoza As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtUslovZaStav As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtIznos As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbTipCene As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNP As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbNPTip As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNPIznos As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents cmbVlasnistvoKola As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVrstaKola As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtStavka As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtNHM As System.Windows.Forms.TextBox
    Friend WithEvents datagrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnDA As System.Windows.Forms.Button
    Friend WithEvents btnNE As System.Windows.Forms.Button
    Friend WithEvents btnPotvrdi As System.Windows.Forms.Button
    Friend WithEvents cbUslovZaStav As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form3))
        Me.Button1 = New System.Windows.Forms.Button
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.btnPrikaz = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRecID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUgovor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbSaobracaj = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtStanicaOd = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtStanicaDo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbOsovine = New System.Windows.Forms.ComboBox
        Me.cmbVrstaPrevoza = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtUslovZaStav = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtIznos = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbTipCene = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtNP = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbNPTip = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtNPIznos = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.cmbVlasnistvoKola = New System.Windows.Forms.ComboBox
        Me.cmbVrstaKola = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtStavka = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtNHM = New System.Windows.Forms.TextBox
        Me.datagrid1 = New System.Windows.Forms.DataGrid
        Me.Label23 = New System.Windows.Forms.Label
        Me.btnDA = New System.Windows.Forms.Button
        Me.btnNE = New System.Windows.Forms.Button
        Me.btnPotvrdi = New System.Windows.Forms.Button
        Me.cbUslovZaStav = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        CType(Me.datagrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(832, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 32)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "IZLAZ"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.Visible = False
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=BGNEM11216XWSB;packet size=4096;user id=radnik;password=roba2006;d" & _
        "ata source=""10.0.4.31"";persist security info=False;initial catalog=OkpWinRoba"
        '
        'btnPrikaz
        '
        Me.btnPrikaz.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.btnPrikaz.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrikaz.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.btnPrikaz.Location = New System.Drawing.Point(880, 16)
        Me.btnPrikaz.Name = "btnPrikaz"
        Me.btnPrikaz.Size = New System.Drawing.Size(32, 32)
        Me.btnPrikaz.TabIndex = 51
        Me.btnPrikaz.Text = "Tabela CoAneksi"
        Me.btnPrikaz.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(600, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 24)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Redni broj"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtRecID
        '
        Me.txtRecID.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.txtRecID.Enabled = False
        Me.txtRecID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecID.Location = New System.Drawing.Point(688, 8)
        Me.txtRecID.Name = "txtRecID"
        Me.txtRecID.Size = New System.Drawing.Size(72, 23)
        Me.txtRecID.TabIndex = 0
        Me.txtRecID.Text = ""
        Me.txtRecID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(304, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Broj ugovora"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtUgovor
        '
        Me.txtUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUgovor.Location = New System.Drawing.Point(288, 27)
        Me.txtUgovor.MaxLength = 6
        Me.txtUgovor.Name = "txtUgovor"
        Me.txtUgovor.Size = New System.Drawing.Size(104, 23)
        Me.txtUgovor.TabIndex = 1
        Me.txtUgovor.Text = ""
        Me.txtUgovor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(440, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Vrsta saobracaja"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cmbSaobracaj
        '
        Me.cmbSaobracaj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSaobracaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSaobracaj.Items.AddRange(New Object() {"1 - unutrasnji", "2 - uvoz", "3 - izvoz", "4 - tranzit"})
        Me.cmbSaobracaj.Location = New System.Drawing.Point(288, 74)
        Me.cmbSaobracaj.Name = "cmbSaobracaj"
        Me.cmbSaobracaj.Size = New System.Drawing.Size(248, 24)
        Me.cmbSaobracaj.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(560, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Od stanice"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtStanicaOd
        '
        Me.txtStanicaOd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStanicaOd.Location = New System.Drawing.Point(576, 75)
        Me.txtStanicaOd.MaxLength = 5
        Me.txtStanicaOd.Name = "txtStanicaOd"
        Me.txtStanicaOd.Size = New System.Drawing.Size(104, 23)
        Me.txtStanicaOd.TabIndex = 3
        Me.txtStanicaOd.Text = ""
        Me.txtStanicaOd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(728, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 24)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Do stanice"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtStanicaDo
        '
        Me.txtStanicaDo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStanicaDo.Location = New System.Drawing.Point(720, 75)
        Me.txtStanicaDo.MaxLength = 5
        Me.txtStanicaDo.Name = "txtStanicaDo"
        Me.txtStanicaDo.Size = New System.Drawing.Size(104, 23)
        Me.txtStanicaDo.TabIndex = 4
        Me.txtStanicaDo.Text = ""
        Me.txtStanicaDo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(176, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Broj osovina"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(448, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 24)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Vrsta prevoza"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(736, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 24)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Vlasništvo kola"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(168, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 24)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Vrsta kola"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(288, 192)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(248, 23)
        Me.DateTimePicker1.TabIndex = 9
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(576, 192)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(248, 23)
        Me.DateTimePicker2.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(416, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 24)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Datum važenja OD"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(720, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 24)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Datum važenja DO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cmbOsovine
        '
        Me.cmbOsovine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOsovine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOsovine.Items.AddRange(New Object() {"1 - vazi za sve slucajeve", "2", "4", "6", "8", "10"})
        Me.cmbOsovine.Location = New System.Drawing.Point(24, 144)
        Me.cmbOsovine.Name = "cmbOsovine"
        Me.cmbOsovine.Size = New System.Drawing.Size(232, 24)
        Me.cmbOsovine.TabIndex = 5
        '
        'cmbVrstaPrevoza
        '
        Me.cmbVrstaPrevoza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVrstaPrevoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVrstaPrevoza.Items.AddRange(New Object() {"P - pojedinacna posiljka ", "G - grupa kola", "V - voz"})
        Me.cmbVrstaPrevoza.Location = New System.Drawing.Point(288, 144)
        Me.cmbVrstaPrevoza.Name = "cmbVrstaPrevoza"
        Me.cmbVrstaPrevoza.Size = New System.Drawing.Size(248, 24)
        Me.cmbVrstaPrevoza.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(144, 218)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 24)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Uslov za tonski stav"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtUslovZaStav
        '
        Me.txtUslovZaStav.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUslovZaStav.Location = New System.Drawing.Point(880, 296)
        Me.txtUslovZaStav.MaxLength = 2
        Me.txtUslovZaStav.Name = "txtUslovZaStav"
        Me.txtUslovZaStav.Size = New System.Drawing.Size(24, 23)
        Me.txtUslovZaStav.TabIndex = 111
        Me.txtUslovZaStav.Text = ""
        Me.txtUslovZaStav.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUslovZaStav.Visible = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(432, 218)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 24)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Novcani iznos"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtIznos
        '
        Me.txtIznos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIznos.Location = New System.Drawing.Point(376, 244)
        Me.txtIznos.Name = "txtIznos"
        Me.txtIznos.Size = New System.Drawing.Size(160, 23)
        Me.txtIznos.TabIndex = 12
        Me.txtIznos.Text = ""
        Me.txtIznos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(768, 219)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 23)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Tip cene"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cmbTipCene
        '
        Me.cmbTipCene.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipCene.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipCene.Items.AddRange(New Object() {"1     Procenat na tarifu", "2     Cena po toni", "3     Cena po tonskom stavu", "4     Cena po kolima", "5     Cena po vozu", "6     Cena po NTKM", "7     Dodatak na cenu zbog NP"})
        Me.cmbTipCene.Location = New System.Drawing.Point(576, 243)
        Me.cmbTipCene.Name = "cmbTipCene"
        Me.cmbTipCene.Size = New System.Drawing.Size(248, 24)
        Me.cmbTipCene.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(552, 368)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 24)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Broj narocite pošiljke"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label15.Visible = False
        '
        'txtNP
        '
        Me.txtNP.Enabled = False
        Me.txtNP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNP.Location = New System.Drawing.Point(552, 392)
        Me.txtNP.Name = "txtNP"
        Me.txtNP.Size = New System.Drawing.Size(56, 23)
        Me.txtNP.TabIndex = 14
        Me.txtNP.Text = ""
        Me.txtNP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNP.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(664, 368)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 24)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Nacin racunanja"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label16.Visible = False
        '
        'cmbNPTip
        '
        Me.cmbNPTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNPTip.Enabled = False
        Me.cmbNPTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNPTip.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cmbNPTip.Location = New System.Drawing.Point(664, 384)
        Me.cmbNPTip.Name = "cmbNPTip"
        Me.cmbNPTip.Size = New System.Drawing.Size(192, 25)
        Me.cmbNPTip.TabIndex = 15
        Me.cmbNPTip.Visible = False
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(584, 320)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 24)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "NP novcani iznos"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label17.Visible = False
        '
        'txtNPIznos
        '
        Me.txtNPIznos.Enabled = False
        Me.txtNPIznos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNPIznos.Location = New System.Drawing.Point(584, 344)
        Me.txtNPIznos.Name = "txtNPIznos"
        Me.txtNPIznos.Size = New System.Drawing.Size(96, 23)
        Me.txtNPIznos.TabIndex = 16
        Me.txtNPIznos.Text = ""
        Me.txtNPIznos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNPIznos.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(728, 320)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 24)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Korisnik"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label18.Visible = False
        '
        'txtUserID
        '
        Me.txtUserID.Enabled = False
        Me.txtUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Location = New System.Drawing.Point(728, 344)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(104, 23)
        Me.txtUserID.TabIndex = 17
        Me.txtUserID.Text = ""
        Me.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUserID.Visible = False
        '
        'btnPrihvati
        '
        Me.btnPrihvati.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrihvati.ForeColor = System.Drawing.Color.Black
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(360, 328)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 72)
        Me.btnPrihvati.TabIndex = 20
        Me.btnPrihvati.Text = "Prihvati"
        '
        'cmbVlasnistvoKola
        '
        Me.cmbVlasnistvoKola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVlasnistvoKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVlasnistvoKola.Items.AddRange(New Object() {"1 - Sva", "Z - Zeleznicka", "P - privatna"})
        Me.cmbVlasnistvoKola.Location = New System.Drawing.Point(576, 144)
        Me.cmbVlasnistvoKola.Name = "cmbVlasnistvoKola"
        Me.cmbVlasnistvoKola.Size = New System.Drawing.Size(248, 24)
        Me.cmbVlasnistvoKola.TabIndex = 7
        '
        'cmbVrstaKola
        '
        Me.cmbVrstaKola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVrstaKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVrstaKola.Items.AddRange(New Object() {"1 - Svi tipovi", "R - Redovno", "S - Stitna"})
        Me.cmbVrstaKola.Location = New System.Drawing.Point(24, 192)
        Me.cmbVrstaKola.Name = "cmbVrstaKola"
        Me.cmbVrstaKola.Size = New System.Drawing.Size(232, 24)
        Me.cmbVrstaKola.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 24)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(240, 80)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Unos podataka iz aneksa ugovora "
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label20.Location = New System.Drawing.Point(24, 328)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 72)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "Unos NHM pozicija"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(168, 352)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 24)
        Me.Label21.TabIndex = 65
        Me.Label21.Text = "Stavka"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtStavka
        '
        Me.txtStavka.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStavka.Location = New System.Drawing.Point(168, 376)
        Me.txtStavka.MaxLength = 2
        Me.txtStavka.Name = "txtStavka"
        Me.txtStavka.Size = New System.Drawing.Size(48, 23)
        Me.txtStavka.TabIndex = 18
        Me.txtStavka.Text = ""
        Me.txtStavka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(232, 352)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 24)
        Me.Label22.TabIndex = 67
        Me.Label22.Text = "Pozicija robe (NHM)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtNHM
        '
        Me.txtNHM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNHM.Location = New System.Drawing.Point(232, 376)
        Me.txtNHM.MaxLength = 4
        Me.txtNHM.Name = "txtNHM"
        Me.txtNHM.Size = New System.Drawing.Size(96, 23)
        Me.txtNHM.TabIndex = 19
        Me.txtNHM.Text = ""
        Me.txtNHM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'datagrid1
        '
        Me.datagrid1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.datagrid1.CaptionBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.datagrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.datagrid1.CaptionText = "NHM pozicije"
        Me.datagrid1.DataMember = ""
        Me.datagrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datagrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.datagrid1.Location = New System.Drawing.Point(24, 456)
        Me.datagrid1.Name = "datagrid1"
        Me.datagrid1.Size = New System.Drawing.Size(304, 208)
        Me.datagrid1.TabIndex = 68
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Enabled = False
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(664, 464)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(208, 96)
        Me.Label23.TabIndex = 69
        Me.Label23.Text = "Da li ima još stavki i pozicija za unos uz ovaj aneks?  Ako ima pritisnite dugme " & _
        "   ""DA"", a ako nema pritisnite dugme     ""NE""!"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label23.Visible = False
        '
        'btnDA
        '
        Me.btnDA.BackColor = System.Drawing.SystemColors.Control
        Me.btnDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDA.ForeColor = System.Drawing.Color.Black
        Me.btnDA.Location = New System.Drawing.Point(360, 456)
        Me.btnDA.Name = "btnDA"
        Me.btnDA.Size = New System.Drawing.Size(88, 72)
        Me.btnDA.TabIndex = 21
        Me.btnDA.Text = "Unos sledece robe"
        '
        'btnNE
        '
        Me.btnNE.BackColor = System.Drawing.SystemColors.Control
        Me.btnNE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNE.ForeColor = System.Drawing.Color.Black
        Me.btnNE.Location = New System.Drawing.Point(504, 592)
        Me.btnNE.Name = "btnNE"
        Me.btnNE.Size = New System.Drawing.Size(88, 72)
        Me.btnNE.TabIndex = 71
        Me.btnNE.Text = "Kraj unosa aneksa"
        '
        'btnPotvrdi
        '
        Me.btnPotvrdi.BackColor = System.Drawing.SystemColors.Control
        Me.btnPotvrdi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPotvrdi.ForeColor = System.Drawing.Color.Black
        Me.btnPotvrdi.Image = CType(resources.GetObject("btnPotvrdi.Image"), System.Drawing.Image)
        Me.btnPotvrdi.Location = New System.Drawing.Point(360, 592)
        Me.btnPotvrdi.Name = "btnPotvrdi"
        Me.btnPotvrdi.Size = New System.Drawing.Size(88, 72)
        Me.btnPotvrdi.TabIndex = 22
        Me.btnPotvrdi.Text = "POTVRDI"
        Me.btnPotvrdi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbUslovZaStav
        '
        Me.cbUslovZaStav.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUslovZaStav.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUslovZaStav.Items.AddRange(New Object() {" 1   - Svi stavovi", "10 t", "15 t", "20 t", "25 t", "30 t", "35 t", "40 t", "45 t"})
        Me.cbUslovZaStav.Location = New System.Drawing.Point(24, 242)
        Me.cbUslovZaStav.Name = "cbUslovZaStav"
        Me.cbUslovZaStav.Size = New System.Drawing.Size(232, 24)
        Me.cbUslovZaStav.TabIndex = 11
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(736, 592)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 72)
        Me.Button2.TabIndex = 112
        Me.Button2.Text = "Izlaz"
        Me.Button2.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(24, 305)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 4)
        Me.Panel1.TabIndex = 113
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Location = New System.Drawing.Point(24, 416)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 4)
        Me.Panel2.TabIndex = 114
        '
        'Form3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.ClientSize = New System.Drawing.Size(912, 685)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cbUslovZaStav)
        Me.Controls.Add(Me.btnPotvrdi)
        Me.Controls.Add(Me.btnNE)
        Me.Controls.Add(Me.btnDA)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.datagrid1)
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
        Me.Controls.Add(Me.cmbVrstaKola)
        Me.Controls.Add(Me.cmbVlasnistvoKola)
        Me.Controls.Add(Me.btnPrihvati)
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
        Me.Controls.Add(Me.btnPrikaz)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unos novog aneksa"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.datagrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Function UnosPodatak(ByVal connnectionString As String, _
                                         ByVal RecID As Integer, _
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
            command = New SqlCommand("uspAzurCoAneksi", connection)
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

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'RefreshData()
        txtRecID.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub btnPrikaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrikaz.Click
        Dim Nova41 As New Form4
        Nova41.Show()
    End Sub


    Private Sub btnDruga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Nova51 As New Form5
        Nova51.Show()
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
            'unosi ovaj podatak, ve' samo potvrdi dodeljenu vrednost sa ENTER i prelazi na sledece polje. 
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

    Private Sub txtUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))

            If txtUgovor.Text = "" Then
                MessageBox.Show("Nije unet ispravan broj ugovora. Unesite ponovo broj ugovora.")
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
                    MessageBox.Show("Nije unet ispravan broj ugovora. Unesite ponovo broj ugovora.")
                End If
            End If
            txtUgovor.Focus()
        End If
    End Sub

    Private Sub txtUserID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserID.KeyPress
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

        Dim Stavka As Integer
        Dim NHM As String

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
        UserID = mUserID

        Stavka = txtStavka.Text
        NHM = txtNHM.Text



        '-------------------------------------------------------------------------------------------
        'Poziva tabelu u koju se unose podaci i preuzima polje "RecID". Vrednost polja uvecava
        'za jedan (1) i novu vrednost dodeljuje polju "txtRecID". Na ovaj nacin korisnik ne mora da
        'unosi ovaj podatak, vec samo potvrdi dodeljenu vrednost sa ENTER i prelazi na sledece polje. 
        'Nije potrebno da potvrdjuje, polje je osenceno i nepristupacno za korisnika.
        '-------------------------------------------------------------------------------------------
        Dim intCounter1 As Integer
        Dim str1SQL As String
        Dim objCommand1 As SqlClient.SqlCommand
        Dim objDAA As SqlClient.SqlDataAdapter
        Dim objDSS As New Data.DataSet

        RecIDpom = 0

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
        RecID = txtRecID.Text



        Dim CoAneksii As DataRow = UnosPodatak(ConnectionString, RecID, Ugovor, Saobracaj, StanicaOd, StanicaDo, Osovine, _
                                                                 VrstaPrevoza, VlasnistvoKola, VrstaKola, DatumOd, DatumDo, _
                                                                 UslovZaStav, Iznos, TipCene, NP, NPTip, NPIznos, UserID)

        stringUpit = "SELECT RecID, Stavka, NHM FROM CoAneksiNHM WHERE RecID = '" & txtRecID.Text & "'"
        Dim CoAneksiNHMM As DataRow = UnosPodatakNHM(ConnectionString, RecID, Stavka, NHM)
        RefreshData()

        'datagrid.Visible = True
        'RefreshData()
        txtNP.Text = 0
        cmbNPTip.Text = 0
        txtNPIznos.Text = 0
        txtUserID.Text = 0

        txtNP.Enabled = False
        cmbNPTip.Enabled = False
        txtNPIznos.Enabled = False
        txtUserID.Enabled = False
        txtRecID.Enabled = False
        'txtUgovor.Focus()

        txtUgovor.Enabled = False
        cmbSaobracaj.Enabled = False
        txtStanicaOd.Enabled = False
        txtStanicaDo.Enabled = False
        cmbOsovine.Enabled = False
        cmbVrstaPrevoza.Enabled = False
        cmbVlasnistvoKola.Enabled = False
        cmbVrstaKola.Enabled = False
        Me.cbUslovZaStav.Enabled = False
        txtUslovZaStav.Enabled = False
        txtIznos.Enabled = False
        cmbTipCene.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False

        'btnPrihvati.Enabled = False
        btnPrihvati.Visible = False 'nesa

        btnDA.Focus()
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

    Private Sub cmbTipCene_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipCene.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cmbTipCene.Text = "" Then
                MessageBox.Show("Nije unet šifra vrste kola! Ne može da bude blanko! - Unesite šifru vrste kola!")
            End If
            cmbTipCene.Focus()
        End If
        txtStavka.Text = 1
        txtStavka.Enabled = False
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

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtRecID.Text = ""
        txtUgovor.Text = ""
        cmbSaobracaj.Text = ""
        Saobracajj = ""
        txtStanicaOd.Text = ""
        txtStanicaDo.Text = ""
        cmbOsovine.Text = ""
        Osovinee = ""
        cmbVrstaPrevoza.Text = ""
        VrstaPrevozaa = ""
        cmbVlasnistvoKola.Text = ""
        cmbVrstaKola.Text = ""
        DatumOdd = ""
        DatumDoo = ""
        txtUslovZaStav.Text = ""
        txtIznos.Text = ""
        cmbTipCene.Text = ""
        TipCenee = ""
        txtNP.Text = ""
        cmbNPTip.Text = ""
        NPTipp = ""
        txtNPIznos.Text = ""
        txtUserID.Text = ""
        txtStavka.Text = ""
        txtNHM.Text = ""

        txtUgovor.Focus()

    End Sub

    Private Sub cmbVlasnistvoKola_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbVlasnistvoKola.KeyPress
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
                'Poziva tabelu "ZsStanice" pretrazuje je i uparuje unet broj stanice sa sifrom stanice u 
                'odgovarajucem polju tabele. Ako ne upari podatke vraca korisnika na ponovni unos sifre
                'stanice. Ako greskom ne unese sifru stanice a pritisne <Enter> takodje ga vraca na pnovni
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

    Private Sub txtStavka_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStavka.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            'Stavkapom = txtStavka.Text
            If txtStavka.Text = "" Then
                MessageBox.Show("Nije uneta korektna šifra za stavku! Ne može da bude ni blanko! - Unesite korektnu šifru za stavku!")
            End If
            txtStavka.Focus()
        End If
    End Sub

    Private Sub menuKorekcije_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Nova66 As New Form6
        Nova66.Show()
    End Sub

    'Private Sub menuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRefresh.Click
    '    RefreshData()
    'End Sub

    'Private Sub menuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSave.Click
    '    SaveData()
    'End Sub


    Private Sub btnDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDA.Click

        btnPrihvati.Enabled = False
        txtStavka.Focus()
        txtStavka.Text = ""
        txtNHM.Text = ""

        Dim intCounter4 As Integer
        Dim str4SQL As String
        Dim objCommand4 As SqlClient.SqlCommand
        Dim objDAA4 As SqlClient.SqlDataAdapter
        Dim objDSS4 As New Data.DataSet

        '-------------------------------------------------------------------------------------------
        'Poziva tabelu "CoAneksiNHM" pretrazuje je i odredjuje sledeci broj za polje "Stavka". 
        '-------------------------------------------------------------------------------------------
        str4SQL = "SELECT * FROM CoAneksiNHM"
        objCommand4 = New SqlClient.SqlCommand(str4SQL, New SqlClient.SqlConnection(ConnectionString))
        objCommand4.Connection.Open()
        objDAA4 = New SqlClient.SqlDataAdapter(str4SQL, ConnectionString)
        objDAA4.Fill(objDSS4)

        With objDSS4.Tables(0)
            For intCounter4 = 0 To .Rows.Count - 1
                Stavkapom = .Rows(intCounter4).Item("Stavka")
            Next
        End With
        Stavkapom += 1
        txtStavka.Text = Stavkapom
        btnDA.Enabled = False
        btnDA.Visible = False
        txtNHM.Focus()
    End Sub

    Private Sub btnPotvrdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPotvrdi.Click
        If Me.txtNHM.Text = "" Then
            Me.txtNHM.Focus()

        Else
            Dim RecID As Integer
            Dim Stavka As Integer
            Dim NHM As String

            RecID = txtRecID.Text
            Stavka = txtStavka.Text
            NHM = txtNHM.Text

            stringUpit = "SELECT RecID, Stavka, NHM FROM CoAneksiNHM WHERE RecID = '" & txtRecID.Text & "'"
            Dim CoAneksiNHMM As DataRow = UnosPodatakNHM(ConnectionString, RecID, Stavka, NHM)
            RefreshData()

            txtStavka.Text = ""
            txtNHM.Text = ""
            'btnDA.Enabled = False
            Dim intCounter4 As Integer
            Dim str4SQL As String
            Dim objCommand4 As SqlClient.SqlCommand
            Dim objDAA4 As SqlClient.SqlDataAdapter
            Dim objDSS4 As New Data.DataSet

            '-------------------------------------------------------------------------------------------
            'Poziva tabelu "CoAneksiNHM" pretrazuje je i odredjuje sledeci broj za polje "Stavka". 
            '-------------------------------------------------------------------------------------------
            str4SQL = "SELECT * FROM CoAneksiNHM"
            objCommand4 = New SqlClient.SqlCommand(str4SQL, New SqlClient.SqlConnection(ConnectionString))
            objCommand4.Connection.Open()
            objDAA4 = New SqlClient.SqlDataAdapter(str4SQL, ConnectionString)
            objDAA4.Fill(objDSS4)

            With objDSS4.Tables(0)
                For intCounter4 = 0 To .Rows.Count - 1
                    Stavkapom = .Rows(intCounter4).Item("Stavka")
                Next
            End With
            Stavkapom += 1
            txtStavka.Text = Stavkapom
            txtNHM.Focus()
        End If
    End Sub

    Private Sub btnNE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNE.Click

        txtUgovor.Enabled = True
        cmbSaobracaj.Enabled = True
        txtStanicaOd.Enabled = True
        txtStanicaDo.Enabled = True
        cmbOsovine.Enabled = True
        cmbVrstaPrevoza.Enabled = True
        cmbVlasnistvoKola.Enabled = True
        cmbVrstaKola.Enabled = True
        txtUslovZaStav.Enabled = True
        txtIznos.Enabled = True
        cmbTipCene.Enabled = True
        Me.cbUslovZaStav.Enabled = True
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True

        datagrid1.DataSource = Nothing
        txtRecID.Text = ""
        txtUgovor.Text = ""
        cmbSaobracaj.Text = Nothing

        Saobracajj = ""
        txtStanicaOd.Text = ""
        txtStanicaDo.Text = ""
        cmbOsovine.Text = Nothing
        Osovinee = ""
        cmbVrstaPrevoza.Text = Nothing
        VrstaPrevozaa = ""
        cmbVlasnistvoKola.Text = Nothing
        cmbVrstaKola.Text = Nothing
        DatumOdd = ""
        DatumDoo = ""
        txtUslovZaStav.Text = ""
        txtIznos.Text = ""
        cmbTipCene.Text = Nothing
        Me.cbUslovZaStav.Text = Nothing
        TipCenee = ""
        txtNP.Text = ""
        cmbNPTip.Text = Nothing
        NPTipp = ""
        txtNPIznos.Text = ""
        txtUserID.Text = ""
        txtStavka.Text = ""
        txtNHM.Text = ""

        btnDA.Visible = True
        btnDA.Enabled = True
        btnPrihvati.Visible = True
        btnPrihvati.Enabled = True
        Button2.Visible = True

        txtUgovor.Focus()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub

    'Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
    '    Dim Nova41 As New Form4
    '    Nova41.Show()
    'End Sub

    Private Sub cbUslovZaStav_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbUslovZaStav.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            If cbUslovZaStav.Text = "" Then
                MessageBox.Show("Nije unet stav! Ne može da bude blanko! - Unesite tonski stav!")
            End If

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()

    End Sub
End Class
