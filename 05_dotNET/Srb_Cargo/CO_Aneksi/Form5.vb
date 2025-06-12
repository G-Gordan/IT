Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Form5
    Inherits System.Windows.Forms.Form
    Public stringUpit As String
    'Public Const ConnectionString As String = _
    '    "integrated security=sspi;initial catalog=OkpWinRoba"
    Protected Const GetAllradeSqlString As String = "SELECT RecID, Stavka, NHM FROM CoAneksiNHM"
    Public Sub RefreshData1()
        Dim connection As New SqlConnection(ConnectionString)
        'Ovde je deklarisana "connection" ali je neophodno otvoriti
        '"SqlConnection1" koji je upotrebljen kao veza. Pogledati 
        '"Form1[Design]*". Takodje zatvoriti "SqlConnection1".
        '----------------------------------------------------------
        SqlConnection1.Open()
        Dim adapter2 As New SqlDataAdapter(GetAllradeSqlString, _
                           SqlConnection1)
        'Dim adapter2 As New SqlDataAdapter(GetAllradeSqlString, _
        '                   SqlConnection1)
        Dim dataset2 As New DataSet
        adapter2.Fill(dataset2)
        SqlConnection1.Close()
        Dim table2 As DataTable = dataset2.Tables(0)
        AddHandler table2.ColumnChanged, _
          New DataColumnChangeEventHandler(AddressOf ColumnChanged)
        datagrid.DataSource = table2
    End Sub

    Public Sub SaveData1()
        Dim table2 As DataTable = CType(datagrid.DataSource, _
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
           SqlConnection1)
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
    Friend WithEvents btnIzlaz As System.Windows.Forms.Button
    Friend WithEvents datagrid As System.Windows.Forms.DataGrid
    Friend WithEvents menuMain As System.Windows.Forms.MainMenu
    Friend WithEvents menuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents menuSave As System.Windows.Forms.MenuItem
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnIzlaz = New System.Windows.Forms.Button
        Me.datagrid = New System.Windows.Forms.DataGrid
        Me.menuMain = New System.Windows.Forms.MainMenu
        Me.menuRefresh = New System.Windows.Forms.MenuItem
        Me.menuSave = New System.Windows.Forms.MenuItem
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        CType(Me.datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnIzlaz
        '
        Me.btnIzlaz.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.btnIzlaz.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIzlaz.Location = New System.Drawing.Point(400, 376)
        Me.btnIzlaz.Name = "btnIzlaz"
        Me.btnIzlaz.Size = New System.Drawing.Size(72, 32)
        Me.btnIzlaz.TabIndex = 0
        Me.btnIzlaz.Text = "IZLAZ"
        '
        'datagrid
        '
        Me.datagrid.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.datagrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datagrid.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.datagrid.BackgroundColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.datagrid.CaptionBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.datagrid.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold)
        Me.datagrid.CaptionForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.datagrid.CaptionText = "        Prikaz i unos podataka u tabelu ""CoAnekciNHM"""
        Me.datagrid.DataMember = ""
        Me.datagrid.GridLineColor = System.Drawing.Color.Red
        Me.datagrid.HeaderBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(0, Byte))
        Me.datagrid.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datagrid.HeaderForeColor = System.Drawing.Color.Yellow
        Me.datagrid.Location = New System.Drawing.Point(24, 16)
        Me.datagrid.Name = "datagrid"
        Me.datagrid.ParentRowsBackColor = System.Drawing.Color.Green
        Me.datagrid.SelectionBackColor = System.Drawing.Color.Purple
        Me.datagrid.Size = New System.Drawing.Size(448, 344)
        Me.datagrid.TabIndex = 1
        '
        'menuMain
        '
        Me.menuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuRefresh, Me.menuSave})
        '
        'menuRefresh
        '
        Me.menuRefresh.Index = 0
        Me.menuRefresh.Text = "Osveži"
        '
        'menuSave
        '
        Me.menuSave.Index = 1
        Me.menuSave.Text = "    Sacuvaj"
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=BGNEM11214XWSC;packet size=4096;integrated security=SSPI;data sour" & _
        "ce=""(local)"";persist security info=False;initial catalog=OkpWinRoba"
        '
        'Form5
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.ClientSize = New System.Drawing.Size(496, 425)
        Me.Controls.Add(Me.datagrid)
        Me.Controls.Add(Me.btnIzlaz)
        Me.Menu = Me.menuMain
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "   PRIKAZ PODATAKA TABELE ""CoAneksiNHM"""
        CType(Me.datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnIzlaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzlaz.Click
        Me.Dispose()
    End Sub

    Private Sub menuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRefresh.Click
        RefreshData1()
    End Sub

    Private Sub menuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSave.Click
        SaveData1()
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshData1()
    End Sub

    Private Sub datagrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles datagrid.DoubleClick
        PPRecID = datagrid.Item(datagrid.CurrentCell.RowNumber, 0)
        PPStavka = datagrid.Item(datagrid.CurrentCell.RowNumber, 1)
        PPNHM = datagrid.Item(datagrid.CurrentCell.RowNumber, 2)

        Dim Nova8 As New Form8
        Nova8.Show()
    End Sub


End Class
