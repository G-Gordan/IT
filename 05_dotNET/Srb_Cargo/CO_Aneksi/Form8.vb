Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Form8
    Inherits System.Windows.Forms.Form
    Private _podaci171 As DataTable
    Public n As Integer = 0

    Dim Ugpom1 As String
    Dim Ugpom As String
    Dim i As Integer
    Dim k As Integer
    Dim IDpom1 As String
    Dim IDpom2 As String

    Dim IDpom As String
    Dim Stavpom As String
    Dim NHMpom As String
    Protected Const GetAllradeSqlString As String = "SELECT RecID, Stavka, NHM FROM CoAneksiNHM"
    '-----------------------------------------------------------------------------
    'Kada se obrazac ucita pozvati "RefreshData()". Ovaj metod ucitava celu tabelu
    '"Podaci171" u novi objekat "DataTable" i postavlja svojstvo "Authors".
    'Svojstvo "Authors" je kreirano iza ovog metoda.
    '-----------------------------------------------------------------------------
    Public Sub RefreshData()
        'Uspostavljanje veze.
        Dim connection As New SqlConnection(ConnectionString)
        SqlConnection1.Open()

        'Pravljenje i popunjavanje.
        Dim table As New DataTable
        Dim adapter As New SqlDataAdapter(GetAllradeSqlString, _
                           SqlConnection1)
        Dim dataset As New DataSet
        adapter.Fill(table)
        adapter.Dispose()

        'Zatvaranje veze.
        SqlConnection1.Close()

        'Vezivanje.
        Authors = table
    End Sub

    'Svojstvo "Authors" je odgovorno za podesavanje polja "_podaci211", ali i za 
    'uspostavljanje vezivanja podataka. (Property = svojstvo.)
    '-------------------------------------------------------------------------
    Public Property Authors() As DataTable
        Get
            Return _podaci171
        End Get
        Set(ByVal Value As DataTable)

            'Postavite.
            _podaci171 = Value

            'Azurirajte vezivanje.
            UpdateBindings()

            'Pocetna pozicija na nuli. Ovo zato da bi bio prikazan prvi zapis.
            AuthorIndex = 0

            'Osluskivanje izmena podataka.Kada je bilo izmena aktivira se 
            'dogadjaj "ColumnChanged".
            AddHandler _podaci171.ColumnChanged, _
            New DataColumnChangeEventHandler(AddressOf ColumnChanged)

            'Resetovanje vrednosti "IsDirty". Onemogucava taster "Save" da
            'Bude dostupan. Ovo je prvi zapis i nije bilo izmena.
            IsDirty = False

        End Set
    End Property

    '"DATAGRID" ima ugradjeno ovo ponasanje!!!
    '#########################################
    'Poziva i menja "IsDirty", daje mu vrednost True!
    '------------------------------------------------
    Protected Sub ColumnChanged(ByVal sender As Object, _
                  ByVal e As DataColumnChangeEventArgs)
        'Prihvatanje izmene.
        e.Row.AcceptChanges()
        IsDirty = True
        'menuSave.Enabled = True

    End Sub

    Protected Sub RowChanged(ByVal sender As Object, _
        ByVal e As DataRowChangeEventArgs)

        ' flag it as dirty...
        IsDirty = True

    End Sub

    'Preko ovog svojstva mozemo da kontrolisemo vezivanje podataka.
    'Prvo uklanjamo postojeca vezivanja podataka, a zatim dodajemo nova, 
    'koja povezuju "Text" svojstva svake kontrole sa odgovarajucim kolonama
    'objekta "_podaci211" tipa "DataTable".
    '----------------------------------------------------------------------
    Protected Sub UpdateBindings()
        txtRecIDD.Enabled = False

        'Uklanjanje vezivanja.
        txtRecIDD.DataBindings.Clear()
        txtStavkaa.DataBindings.Clear()
        txtNHMM.DataBindings.Clear()

        'Imamo li novi red?
        If Not _podaci171 Is Nothing Then

            'Vezujemo podatke za polja za unos teksta.
            txtRecIDD.DataBindings.Add("Text", _podaci171, "RecID")
            txtStavkaa.DataBindings.Add("Text", _podaci171, "Stavka")
            txtNHMM.DataBindings.Add("Text", _podaci171, "NHM")

        End If
        txtRecIDD.Visible = False
        txtUgovorr.Visible = False
        txtStavkaa.Visible = False
        txtNHMM.Visible = False

    End Sub
    '-----------------------------------------------------------------
    '"AuthorCount" vraca broj objekata "DataRow" u okviru "DataTable".
    'Ako nema na raspolaganju "DataTable" vraca vrednost nula.
    '-----------------------------------------------------------------
    Public ReadOnly Property AuthorCount() As Integer
        Get
            If Not _podaci171 Is Nothing Then
                Return _podaci171.Rows.Count
            End If
            Return 0
        End Get
    End Property

    'Ovo svojstvo omogucava pristup proceduri za upravljanje vezivanjem.
    '"AuthorBindingContext". Ime moze da bude i drugacije, ovo je bukvalno prepisano.
    '--------------------------------------------------------------------------------
    Public ReadOnly Property AuthorBindingContext() As CurrencyManager
        Get
            If Not _podaci171 Is Nothing Then
                Return CType(BindingContext(_podaci171), CurrencyManager)
            Else
                Return Nothing
            End If
        End Get
    End Property


    '######################################################################
    '======================================================================
    'Svojstvo "AutorIndex" je odgovorno za rad sa vezivanjem podataka, koja
    'omogucuju prikazivanje razlicitih zapisa. Odnosi se na dugmad.
    '"AutorIndex" je odgovoran za prikazivanje dugmadi.
    'Na primer da se ne prikaze dugme "Sledeci" ako je na obrascu poslednji 
    'zapis ili "Predhodni" ako je na obrascu prvi zapis.
    '----------------------------------------------------------------------
    Public Property AuthorIndex() As Integer
        Get
            If Not AuthorBindingContext Is Nothing Then
                Return AuthorBindingContext.Position
            End If
        End Get
        Set(ByVal Value As Integer)

            'Da li smo nesto ucitali?
            If _podaci171 Is Nothing Then
                btnPrvi.Enabled = False
                btnPredhodni.Enabled = False
                btnSledeci.Enabled = False
                btnPoslednji.Enabled = False
                'lblPosition.Text = ""
                Return
            End If

            'Sredjivanje tastera.
            Dim enableBack As Boolean = False
            If Value > 0 Then
                enableBack = True
            End If
            Dim enableForward As Boolean = False
            If Value < AuthorCount - 1 Then
                enableForward = True
            End If
            btnPrvi.Enabled = enableBack
            btnPredhodni.Enabled = enableBack
            btnSledeci.Enabled = enableForward
            btnPoslednji.Enabled = enableForward


            'Uzimanje procedure za upravljanje vezivanjem
            Dim manager As CurrencyManager = AuthorBindingContext
            If Not manager Is Nothing Then

                'Da li se u stvari nesto promenilo?
                If manager.Position <> Value Then
                    manager.Position = Value
                End If
            End If

            'Pozicija. Pod navodnicima, u ovom slucaju su nula (0) i jedan (1),
            'zagrade moraju biti velike (viticaste) inace nece biti korektna poruka
            'kada se pokrene program.
            '----------------------------------------------------------------------
            'lblPosition.Text = _
            'String.Format("{0}  od ukupno  {1}", Value + 1, AuthorCount)

        End Set
    End Property


    'Kada je vrsena neka izmena u zapisu bice omogucen taster "Save".
    'Nece biti bledo ispisano ime tastera! 
    '---------------------------------------------------------------
    Public Property IsDirty() As Boolean
        Get
            Return btnPotvrdi.Enabled
        End Get
        Set(ByVal Value As Boolean)
            btnPotvrdi.Enabled = Value
        End Set
    End Property

    Private Function CheckSave() As Boolean   'Da li treba da sacuvamo izmene?
        If IsDirty = False Then               '------------------------------- 
            Return True
        End If

        'Pitati korisnika!
        'Pitanje je namerno ignorisano da se ne bi korisnik mnogo angazovao oko 
        'nepotrebnih operacija.
        '----------------------------------------------------------------------
        'Dim result As DialogResult = _
        'MsgBox("Da li je potrebno sacuvati izmene unete u ovaj slog?", _
        'MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
        'If result = DialogResult.Yes Then
        '    SaveChanges()
        'Else
        '    IsDirty = False
        'End If
        btnPotvrdi.Enabled = True
        'Vracanje.
        Return True

    End Function
    Public Sub SaveChanges()
        If _podaci171 Is Nothing Then
            Return
        End If
        'Uspostavljanje veze.
        Dim connection As New SqlConnection(ConnectionString)
        SqlConnection1.Open()
        'Pravljenje adaptera.
        Dim adapter As New SqlDataAdapter(GetAllradeSqlString, _
                            SqlConnection1)
        Dim builder As New SqlCommandBuilder(adapter)
        adapter.Update(_podaci171)
        adapter.Dispose()
        'Zatvaranje veze.
        SqlConnection1.Close()
        'Indikator.
        IsDirty = False
    End Sub

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
    Friend WithEvents txtRecID As System.Windows.Forms.TextBox
    Friend WithEvents txtStavka As System.Windows.Forms.TextBox
    Friend WithEvents txtNHM As System.Windows.Forms.TextBox
    Friend WithEvents txtRecIDD As System.Windows.Forms.TextBox
    Friend WithEvents txtStavkaa As System.Windows.Forms.TextBox
    Friend WithEvents txtNHMM As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUgovorr As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBrUgg As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnPredhodni As System.Windows.Forms.Button
    Friend WithEvents btnSledeci As System.Windows.Forms.Button
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents btnPotvrdi As System.Windows.Forms.Button
    Friend WithEvents btnPrvi As System.Windows.Forms.Button
    Friend WithEvents btnPoslednji As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form8))
        Me.txtRecID = New System.Windows.Forms.TextBox
        Me.txtStavka = New System.Windows.Forms.TextBox
        Me.txtNHM = New System.Windows.Forms.TextBox
        Me.txtRecIDD = New System.Windows.Forms.TextBox
        Me.txtStavkaa = New System.Windows.Forms.TextBox
        Me.txtNHMM = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUgovorr = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBrUgg = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnPredhodni = New System.Windows.Forms.Button
        Me.btnSledeci = New System.Windows.Forms.Button
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.btnPotvrdi = New System.Windows.Forms.Button
        Me.btnPrvi = New System.Windows.Forms.Button
        Me.btnPoslednji = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtRecID
        '
        Me.txtRecID.Enabled = False
        Me.txtRecID.Location = New System.Drawing.Point(16, 368)
        Me.txtRecID.Name = "txtRecID"
        Me.txtRecID.Size = New System.Drawing.Size(72, 20)
        Me.txtRecID.TabIndex = 55
        Me.txtRecID.Text = ""
        '
        'txtStavka
        '
        Me.txtStavka.Enabled = False
        Me.txtStavka.Location = New System.Drawing.Point(96, 368)
        Me.txtStavka.Name = "txtStavka"
        Me.txtStavka.Size = New System.Drawing.Size(80, 20)
        Me.txtStavka.TabIndex = 56
        Me.txtStavka.Text = ""
        '
        'txtNHM
        '
        Me.txtNHM.Enabled = False
        Me.txtNHM.Location = New System.Drawing.Point(184, 368)
        Me.txtNHM.Name = "txtNHM"
        Me.txtNHM.Size = New System.Drawing.Size(80, 20)
        Me.txtNHM.TabIndex = 57
        Me.txtNHM.Text = ""
        '
        'txtRecIDD
        '
        Me.txtRecIDD.Enabled = False
        Me.txtRecIDD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecIDD.Location = New System.Drawing.Point(200, 144)
        Me.txtRecIDD.Name = "txtRecIDD"
        Me.txtRecIDD.Size = New System.Drawing.Size(96, 23)
        Me.txtRecIDD.TabIndex = 1
        Me.txtRecIDD.Text = ""
        Me.txtRecIDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStavkaa
        '
        Me.txtStavkaa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStavkaa.Location = New System.Drawing.Point(200, 224)
        Me.txtStavkaa.Name = "txtStavkaa"
        Me.txtStavkaa.Size = New System.Drawing.Size(96, 23)
        Me.txtStavkaa.TabIndex = 3
        Me.txtStavkaa.Text = ""
        Me.txtStavkaa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNHMM
        '
        Me.txtNHMM.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNHMM.Location = New System.Drawing.Point(200, 264)
        Me.txtNHMM.Name = "txtNHMM"
        Me.txtNHMM.Size = New System.Drawing.Size(96, 23)
        Me.txtNHMM.TabIndex = 4
        Me.txtNHMM.Text = ""
        Me.txtNHMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Redni broj zapisa"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 224)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 24)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Redni broj stavke u zapisu"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 264)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "NHM pozicija zapisa"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUgovorr
        '
        Me.txtUgovorr.Enabled = False
        Me.txtUgovorr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUgovorr.Location = New System.Drawing.Point(200, 184)
        Me.txtUgovorr.Name = "txtUgovorr"
        Me.txtUgovorr.Size = New System.Drawing.Size(96, 23)
        Me.txtUgovorr.TabIndex = 2
        Me.txtUgovorr.Text = ""
        Me.txtUgovorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 24)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Broj ugovora"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(480, 24)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Ukucajte broj ugovora za koji želite da vidite podatke u tabeli pozicija."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBrUgg
        '
        Me.txtBrUgg.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.txtBrUgg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrUgg.Location = New System.Drawing.Point(512, 96)
        Me.txtBrUgg.Name = "txtBrUgg"
        Me.txtBrUgg.Size = New System.Drawing.Size(88, 23)
        Me.txtBrUgg.TabIndex = 0
        Me.txtBrUgg.Text = ""
        Me.txtBrUgg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(512, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 48)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "IZLAZ"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPredhodni
        '
        Me.btnPredhodni.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(192, Byte))
        Me.btnPredhodni.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPredhodni.ForeColor = System.Drawing.Color.Red
        Me.btnPredhodni.Image = CType(resources.GetObject("btnPredhodni.Image"), System.Drawing.Image)
        Me.btnPredhodni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPredhodni.Location = New System.Drawing.Point(168, 312)
        Me.btnPredhodni.Name = "btnPredhodni"
        Me.btnPredhodni.Size = New System.Drawing.Size(128, 24)
        Me.btnPredhodni.TabIndex = 59
        Me.btnPredhodni.Text = "PREDHODNI"
        Me.btnPredhodni.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSledeci
        '
        Me.btnSledeci.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me.btnSledeci.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSledeci.ForeColor = System.Drawing.Color.Maroon
        Me.btnSledeci.Image = CType(resources.GetObject("btnSledeci.Image"), System.Drawing.Image)
        Me.btnSledeci.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSledeci.Location = New System.Drawing.Point(320, 312)
        Me.btnSledeci.Name = "btnSledeci"
        Me.btnSledeci.Size = New System.Drawing.Size(120, 24)
        Me.btnSledeci.TabIndex = 60
        Me.btnSledeci.Text = "SLEDECI"
        Me.btnSledeci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=BGNEM11214XWSC;packet size=4096;integrated security=SSPI;data sour" & _
        "ce=""(local)"";persist security info=False;initial catalog=OkpWinRoba"
        '
        'btnPotvrdi
        '
        Me.btnPotvrdi.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.btnPotvrdi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPotvrdi.ForeColor = System.Drawing.Color.Yellow
        Me.btnPotvrdi.Location = New System.Drawing.Point(488, 208)
        Me.btnPotvrdi.Name = "btnPotvrdi"
        Me.btnPotvrdi.Size = New System.Drawing.Size(112, 24)
        Me.btnPotvrdi.TabIndex = 61
        Me.btnPotvrdi.Text = "Prihvati"
        '
        'btnPrvi
        '
        Me.btnPrvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrvi.Image = CType(resources.GetObject("btnPrvi.Image"), System.Drawing.Image)
        Me.btnPrvi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrvi.Location = New System.Drawing.Point(24, 312)
        Me.btnPrvi.Name = "btnPrvi"
        Me.btnPrvi.Size = New System.Drawing.Size(120, 24)
        Me.btnPrvi.TabIndex = 62
        Me.btnPrvi.Text = "Prvi"
        '
        'btnPoslednji
        '
        Me.btnPoslednji.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPoslednji.Image = CType(resources.GetObject("btnPoslednji.Image"), System.Drawing.Image)
        Me.btnPoslednji.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPoslednji.Location = New System.Drawing.Point(472, 312)
        Me.btnPoslednji.Name = "btnPoslednji"
        Me.btnPoslednji.Size = New System.Drawing.Size(128, 24)
        Me.btnPoslednji.TabIndex = 63
        Me.btnPoslednji.Text = "Poslednji"
        '
        'Form8
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 414)
        Me.Controls.Add(Me.btnPoslednji)
        Me.Controls.Add(Me.btnPrvi)
        Me.Controls.Add(Me.btnPotvrdi)
        Me.Controls.Add(Me.btnSledeci)
        Me.Controls.Add(Me.btnPredhodni)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtBrUgg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUgovorr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNHMM)
        Me.Controls.Add(Me.txtStavkaa)
        Me.Controls.Add(Me.txtRecIDD)
        Me.Controls.Add(Me.txtNHM)
        Me.Controls.Add(Me.txtStavka)
        Me.Controls.Add(Me.txtRecID)
        Me.Name = "Form8"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UNOS DODATNIH POZICIJA "
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub

    Private Sub txtBrUgg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBrUgg.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))

            If txtBrUgg.Text = "" Then
                MessageBox.Show("Nije unet isptavan broj ugovora! Ne može da bude ni blanko! - Unesite ponovo broj ugovora!")
            Else
                Ugpom1 = txtBrUgg.Text

                Dim intCounter1 As Integer
                Dim str1SQL As String
                Dim objCommand1 As SqlClient.SqlCommand
                Dim objDAA As SqlClient.SqlDataAdapter
                Dim objDSS As New Data.DataSet

                Ugpom = 0
                i = 0

                '-------------------------------------------------------------------------------------------
                'Poziva tabelu "CoAneksi" pretrazuje je i uparuje unet broj ugovora sa brojevima ugovora u 
                'odgovarajucem polju tabele. Ako ne upari podatke vraca korisnika na ponovni unos broja
                'ugovora. Ako greskom ne unese broj ugovora a pritisne <Enter> takodje ga vraca na ponovni
                'unos.
                '-------------------------------------------------------------------------------------------
                str1SQL = "SELECT * FROM CoAneksi"
                objCommand1 = New SqlClient.SqlCommand(str1SQL, New SqlClient.SqlConnection(ConnectionString))
                objCommand1.Connection.Open()
                objDAA = New SqlClient.SqlDataAdapter(str1SQL, ConnectionString)
                objDAA.Fill(objDSS)

                With objDSS.Tables(0)
                    For intCounter1 = 0 To .Rows.Count - 1
                        Ugpom = .Rows(intCounter1).Item("Ugovor")
                        If Ugpom = Ugpom1 Then
                            txtUgovorr.Text = Ugpom
                            IDpom1 = .Rows(intCounter1).Item("RecID")
                            i = 1
                            Exit For
                        End If
                    Next
                End With
                '-------------------------------------------------------------------------------------------
                If i = 0 Or txtBrUgg.Text = "" Then
                    MessageBox.Show("Nije unet isptavan broj ugovora! Ne može da bude ni blanko! - Unesite ponovo broj ugovora!")
                End If
            End If
            txtBrUgg.Focus()
        End If

        n = 0
        If i = 1 Then
            Dim intCounter2 As Integer
            Dim str2SQL As String
            Dim objCommand2 As SqlClient.SqlCommand
            Dim objDAA2 As SqlClient.SqlDataAdapter
            Dim objDSS2 As New Data.DataSet

            str2SQL = "SELECT * FROM CoAneksiNHM"
            objCommand2 = New SqlClient.SqlCommand(str2SQL, New SqlClient.SqlConnection(ConnectionString))
            objCommand2.Connection.Open()
            objDAA2 = New SqlClient.SqlDataAdapter(str2SQL, ConnectionString)
            objDAA2.Fill(objDSS2)


            With objDSS2.Tables(0)
                For intCounter2 = 0 To .Rows.Count - 1
                    IDpom2 = .Rows(intCounter2).Item("RecID")
                    n += 1
                    If IDpom2 = IDpom1 Then
                        Stavpom = .Rows(intCounter2).Item("Stavka")
                        NHMpom = .Rows(intCounter2).Item("NHM")
                        Exit For
                    End If
                Next
            End With

            txtRecIDD.Visible = True
            txtUgovorr.Visible = True
            txtStavkaa.Visible = True
            txtNHMM.Visible = True

            txtRecIDD.Text = IDpom2
            txtStavkaa.Text = Stavpom
            txtNHMM.Text = NHMpom

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub btnPredhodni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPredhodni.Click
        If AuthorIndex <> 0 Then
            If CheckSave() = True Then
                AuthorIndex -= 1
            End If
        End If
    End Sub

    Private Sub btnSledeci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSledeci.Click
        If AuthorIndex = 0 Then
            AuthorIndex = n - 1
        End If
        If AuthorIndex < AuthorCount - 1 Then

            If CheckSave() = True Then
                AuthorIndex += 1
            End If
        End If
    End Sub

    Private Sub btnPrvi_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrvi.Click
        If CheckSave() = True Then
            AuthorIndex = 0
        End If
    End Sub

    Private Sub btnPoslednji_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPoslednji.Click
        If CheckSave() = True Then
            AuthorIndex = AuthorCount - 1
        End If
    End Sub
End Class
