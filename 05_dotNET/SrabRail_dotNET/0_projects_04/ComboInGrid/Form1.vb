Imports System.Data.SqlClient
Public Class Form1
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 64)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(504, 320)
        Me.DataGrid1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(544, 288)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 88)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(544, 240)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "TextBox1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(920, 470)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable("Names")
        dt.Columns.Add("Name")
        dt.Columns.Add("State")
        dt.LoadDataRow(New Object() {"Ken Tucker", "EUR"}, True)
        dt.LoadDataRow(New Object() {"Cor Ligthert", "EUR"}, True)
        dt.LoadDataRow(New Object() {"Terry Burns", "EUR"}, True)
        dt.LoadDataRow(New Object() {"Armin Zignler", "EUR"}, True)
        dt.LoadDataRow(New Object() {"Herfried K. Wagner", "EUR"}, True)
        dt.LoadDataRow(New Object() {"Jay B Harlow", "EUR"}, True)

        'above only to build a sample datatable
        dt.DefaultView.AllowNew = False
        DataGrid1.DataSource = dt.DefaultView

        Dim ts As New DataGridTableStyle
        ts.MappingName = "Names"

        Dim textCol As New DataGridTextBoxColumn

        textCol.MappingName = "Name"
        textCol.HeaderText = "Name"
        textCol.Width = 120
        ts.GridColumnStyles.Add(textCol)

        Dim cmbTxtCol As New DataGridComboBoxColumn
        cmbTxtCol.MappingName = "State"
        cmbTxtCol.HeaderText = "States"
        cmbTxtCol.Width = 100

        ts.GridColumnStyles.Add(cmbTxtCol)
        ts.PreferredRowHeight = (cmbTxtCol.ColumnComboBox.Height + 3)

        '------------------------------------------
        Dim SQL_CONNECTION_STRING As String = _
            "Server=(local);" & _
            "DataBase=OkpWinRoba;" & _
            "Integrated Security=SSPI"
        Dim cnRoba As New SqlConnection(SQL_CONNECTION_STRING)

        cnRoba.Open()
        'Dim sql_trz1 As String = "SELECT dbo.ZsTarifa.SifraTarife, dbo.ZsTarifa.Opis FROM dbo.ZsTarifa " & _
        '                                       "WHERE (dbo.ZsTarifa.SifraVS = '" & IzborSaobracaja & "')"

        Dim sql_trz1 As String = "SELECT Oznaka, Sifra  FROM ZsValute"

        Dim sql_commTrz1 As New SqlClient.SqlCommand(sql_trz1, cnRoba)
        Dim rdrTar As SqlClient.SqlDataReader
        Dim combo_linija1 As String = ""
        cmbTxtCol.ColumnComboBox.Items.Clear()
        rdrTar = sql_commTrz1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrTar.Read()
            combo_linija1 = rdrTar.GetString(0)
            cmbTxtCol.ColumnComboBox.Items.Add(combo_linija1)
        Loop
        rdrTar.Close()
        cnRoba.Close()
        cmbTxtCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList


        '------------------------------------------

        'cmbTxtCol.ColumnComboBox.Items.Add("Austria")
        'cmbTxtCol.ColumnComboBox.Items.Add("Germany")
        'cmbTxtCol.ColumnComboBox.Items.Add("Netherlands")
        'cmbTxtCol.ColumnComboBox.Items.Add("United Kingdom")
        'cmbTxtCol.ColumnComboBox.Items.Add("Florida")
        'cmbTxtCol.ColumnComboBox.Items.Add("NewYork")
        'cmbTxtCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList



        DataGrid1.TableStyles.Add(ts)

    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        Dim currRow As DataRow
        currRow = CType(DataGrid1.DataSource, DataTable).Rows(DataGrid1.CurrentCell.RowNumber)

        Me.TextBox1.Text = currRow(1, DataRowVersion.Current).ToString()
    End Sub
End Class
