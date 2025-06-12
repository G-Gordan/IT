Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Form4
    Inherits System.Windows.Forms.Form
    'Public Const ConnectionString As String = _
    '    "integrated security=sspi;initial catalog=OkpWinRoba"

    Protected Const GetAllradeSqlString As String = "SELECT RecID, Ugovor, Saobracaj, StanicaOd, StanicaDo, Osovine, VrstaPrevoza, VlasnistvoKola, VrstaKola, DatumOd, DatumDo, UslovZaStav, Iznos, TipCene, NP, NPTip, NPIznos, UserID FROM CoAneksi"
    Public Sub RefreshData1()
        Dim connection As New SqlConnection(ConnectionString)
        'Ovde je deklarisana "connection" ali je neophodno otvoriti
        '"SqlConnection1" koji je upotrebljen kao veza. Pogledati 
        '"Form1[Design]*". Takodje zatvoriti "SqlConnection1".
        '----------------------------------------------------------
        SqlConnection2.Open()
        Dim adapter2 As New SqlDataAdapter(GetAllradeSqlString, _
                           SqlConnection2)
        Dim dataset2 As New DataSet
        adapter2.Fill(dataset2)
        SqlConnection2.Close()
        Dim table2 As DataTable = dataset2.Tables(0)
        AddHandler table2.ColumnChanged, _
          New DataColumnChangeEventHandler(AddressOf ColumnChanged)
        DataGrid1.DataSource = table2
    End Sub

    Public Sub SaveData1()
        Dim table2 As DataTable = CType(DataGrid1.DataSource, _
           DataTable)
        Dim changedRows As New ArrayList
        Dim row2 As DataRow

        For Each row2 In table2.Rows
            If row2.RowState <> DataRowState.Unchanged Then
                changedRows.Add(row2)
            End If
        Next
        If changedRows.Count = 0 Then
            Return
        End If
        Dim connection2 As New SqlConnection(ConnectionString)
        Dim adapter2 As New SqlDataAdapter(GetAllradeSqlString, _
           SqlConnection2)
        Dim builder As New SqlCommandBuilder(adapter2)
        Dim rows() As DataRow = CType(changedRows.ToArray(GetType(DataRow)), DataRow())
        adapter2.Update(rows)
        ''adapter.Dispose()
        menuSave.Enabled = False
    End Sub
    Protected Sub ColumnChanged(ByVal sender As Object, _
ByVal e As DataColumnChangeEventArgs)
        menuSave.Enabled = True
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
    Friend WithEvents menuMeni As System.Windows.Forms.MainMenu
    Friend WithEvents menuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents menuSave As System.Windows.Forms.MenuItem
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents btnIzlaz As System.Windows.Forms.Button
    Friend WithEvents SqlConnection2 As System.Data.SqlClient.SqlConnection
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.menuMeni = New System.Windows.Forms.MainMenu
        Me.menuRefresh = New System.Windows.Forms.MenuItem
        Me.menuSave = New System.Windows.Forms.MenuItem
        Me.SqlConnection2 = New System.Data.SqlClient.SqlConnection
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.btnIzlaz = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuMeni
        '
        Me.menuMeni.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuRefresh, Me.menuSave})
        '
        'menuRefresh
        '
        Me.menuRefresh.Index = 0
        Me.menuRefresh.Text = "Osveži"
        '
        'menuSave
        '
        Me.menuSave.Index = 1
        Me.menuSave.Text = "          Sacuvaj"
        '
        'SqlConnection2
        '
        Me.SqlConnection2.ConnectionString = "workstation id=BGNEM11214XWSC;packet size=4096;integrated security=SSPI;data sour" & _
        "ce=""(local)"";persist security info=False;initial catalog=OkpWinRoba"
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGrid1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.GridLineColor = System.Drawing.Color.Red
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.Yellow
        Me.DataGrid1.Location = New System.Drawing.Point(16, 88)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.Green
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.Purple
        Me.DataGrid1.Size = New System.Drawing.Size(984, 488)
        Me.DataGrid1.TabIndex = 0
        '
        'btnIzlaz
        '
        Me.btnIzlaz.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.btnIzlaz.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIzlaz.ForeColor = System.Drawing.Color.Blue
        Me.btnIzlaz.Location = New System.Drawing.Point(912, 24)
        Me.btnIzlaz.Name = "btnIzlaz"
        Me.btnIzlaz.Size = New System.Drawing.Size(88, 40)
        Me.btnIzlaz.TabIndex = 1
        Me.btnIzlaz.Text = "IZLAZ"
        '
        'Form4
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.ClientSize = New System.Drawing.Size(1016, 593)
        Me.Controls.Add(Me.btnIzlaz)
        Me.Controls.Add(Me.DataGrid1)
        Me.Menu = Me.menuMeni
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "                                                                      PRIKAZ PODA" & _
        "TAKA U TABELI ""CoAneksi"""
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshData1()
    End Sub

    Private Sub btnIzlaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzlaz.Click
        Me.Dispose()
    End Sub

    Private Sub menuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRefresh.Click
        RefreshData1()
    End Sub

    Private Sub menuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSave.Click
        SaveData1()
    End Sub

    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub
End Class
