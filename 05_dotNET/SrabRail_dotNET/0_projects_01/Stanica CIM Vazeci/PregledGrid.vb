Imports System.Data.SqlClient
Imports System.Data

Public Class FormGrid
    Inherits System.Windows.Forms.Form
    Dim sql_UpitPregled As String

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
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormGrid))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.DataGrid1.BackColor = System.Drawing.Color.DarkGray
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Navy
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Verdana", 16.0!)
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGrid1.CaptionText = "        Pogled u bazu podataka"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid1.ForeColor = System.Drawing.Color.Navy
        Me.DataGrid1.GridLineColor = System.Drawing.Color.Black
        Me.DataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.Black
        Me.DataGrid1.LinkColor = System.Drawing.Color.Navy
        Me.DataGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White
        Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DataGrid1.ParentRowsVisible = False
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy
        Me.DataGrid1.SelectionForeColor = System.Drawing.Color.White
        Me.DataGrid1.Size = New System.Drawing.Size(1024, 342)
        Me.DataGrid1.TabIndex = 0
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.White
        Me.DataGridTableStyle1.BackColor = System.Drawing.Color.White
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.DataGridTableStyle1.GridLineColor = System.Drawing.Color.White
        Me.DataGridTableStyle1.HeaderBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "SuperGrid"
        Me.DataGridTableStyle1.ReadOnly = True
        Me.DataGridTableStyle1.SelectionBackColor = System.Drawing.Color.Red
        Me.DataGridTableStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        '
        'btnOtkazi
        '
        Me.btnOtkazi.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.Location = New System.Drawing.Point(980, 2)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(40, 31)
        Me.btnOtkazi.TabIndex = 5
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(4, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormGrid
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 342)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.DataGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormGrid"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim qObrMesec As String
        Dim qObrGodina As String

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        '''---------------------------------------- postavljanje racunskog meseca ------------------------------------------

        ''If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
        ''    IzborSaobracaja = "4"
        ''ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
        ''    IzborSaobracaja = "2"
        ''ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
        ''    IzborSaobracaja = "3"
        ''Else
        ''    IzborSaobracaja = "1"
        ''End If

        '----------------------------------------------------------------------------------------------------------------------------
        Button1.Visible = False

        DataGrid1.CaptionText = "Dnevni unos za dan: " & mDan & "." & mMesec & "." & mGodina & "."

        If Stampa = "grUlaz" Then
            sql_UpitPregled = "SELECT TOP 100 PERCENT dbo.SlogKalk.OtpUprava, dbo.SlogKalk.OtpStanica, dbo.SlogKalk.OtpBroj, dbo.SlogKalk.OtpDatum, " & _
                              "dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.UlEtiketa, dbo.SlogKalk.ZsIzPrelaz, dbo.SlogKalk.IzEtiketa, " & _
                              "dbo.SlogKalk.PrUprava, dbo.SlogKalk.PrStanica, dbo.SlogKalk.BrojVoza, dbo.SlogKalk.SatVoza, dbo.SlogKalk.SifraTarife, " & _
                              "dbo.SlogKalk.Ugovor, dbo.SlogKola.IBK " & _
                              "FROM dbo.SlogKalk INNER JOIN " & _
                              "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica " & _
                              "WHERE (dbo.SlogKalk.ZsUlPrelaz = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') AND (dbo.SlogKalk.DatumObrade = " & "'" & mMesec & "." & mDan & "." & mGodina & "') " & _
                              "ORDER BY dbo.SlogKalk.BrojVoza, dbo.SlogKalk.SatVoza "

        ElseIf Stampa = "grIzlaz" Then
            sql_UpitPregled = "SELECT TOP 100 PERCENT dbo.SlogKalk.OtpUprava, dbo.SlogKalk.OtpStanica, dbo.SlogKalk.OtpBroj, dbo.SlogKalk.OtpDatum, " & _
                              "dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.UlEtiketa, dbo.SlogKalk.ZsIzPrelaz, dbo.SlogKalk.IzEtiketa, " & _
                              "dbo.SlogKalk.PrUprava, dbo.SlogKalk.PrStanica, dbo.SlogKalk.BrojVoza2, dbo.SlogKalk.SatVoza2, dbo.SlogKalk.SifraTarife, " & _
                              "dbo.SlogKalk.Ugovor, dbo.SlogKola.IBK " & _
                              "FROM dbo.SlogKalk INNER JOIN " & _
                              "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica " & _
                              "WHERE (dbo.SlogKalk.ZsIzPrelaz = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') AND (dbo.SlogKalk.DatumObrade = " & "'" & mMesec & "." & mDan & "." & mGodina & "') " & _
                              "ORDER BY dbo.SlogKalk.BrojVoza2, dbo.SlogKalk.SatVoza2 "

        ElseIf Stampa = "grUlazniVozovi" Then
            sql_UpitPregled = "SELECT BrojVoza AS Trasa, SatVoza AS Sat, COUNT(*) AS [Suma kola] " & _
                              "FROM SlogKalk " & _
                              "WHERE (dbo.SlogKalk.ZsUlPrelaz = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') " & _
                              "GROUP BY DatumUlaza, SatVoza, BrojVoza " & _
                              "HAVING (dbo.SlogKalk.DatumUlaza = " & "'" & mMesec & "." & mDan & "." & mGodina & "') " & _
                              "ORDER BY SatVoza, BrojVoza "

        ElseIf Stampa = "grIzlazniVozovi" Then
            sql_UpitPregled = "SELECT BrojVoza2 AS Trasa, SatVoza2 AS Sat, COUNT(*) AS [Suma kola] " & _
                              "FROM SlogKalk " & _
                              "WHERE (dbo.SlogKalk.ZsIzPrelaz = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') " & _
                              "GROUP BY DatumIzlaza, SatVoza2, BrojVoza2 " & _
                              "HAVING (dbo.SlogKalk.DatumIzlaza = " & "'" & mMesec & "." & mDan & "." & mGodina & "') " & _
                              "ORDER BY SatVoza2, BrojVoza2 "

        End If


        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing

        Dim _dataSet As DataSet
        _dataSet = Nothing
        Try
            dataAdapter = New SqlDataAdapter(sql_UpitPregled, DbVeza)
            _dataSet = New DataSet
            dataAdapter.Fill(_dataSet, "SuperGrid")
            DbVeza.Close()

        Catch ex As Exception
            MessageBox.Show(((((("Problem sa pristupom bazi-" & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(10) & "   connection:  + OkpDbVeza") _
                            + "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            query: ") _
                            + sql_UpitPregled) _
                            + "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10)) _
                            + ex.ToString))
            Me.Close()
            Return
        End Try

        Dim tableStyle As DataGridTableStyle
        tableStyle = New DataGridTableStyle
        tableStyle.MappingName = "SuperGrid"

        DataGrid1.TableStyles.Clear()
        DataGrid1.TableStyles.Add(tableStyle)
        DataGrid1.DataSource = _dataSet.Tables("SuperGrid")

    End Sub
    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.Close()
            e.Handled = True
        End If
    End Sub
    Public Sub AutoSizeTable()

        Dim numCols As Integer
        numCols = CType(DataGrid1.DataSource, DataTable).Columns.Count
        Dim i As Integer
        i = 0
        Do While (i < numCols)
            AutoSizeCol(i)
            i = (i + 1)
        Loop
    End Sub
    Public Sub AutoSizeCol(ByVal col As Integer)
        Dim width As Single
        width = 0
        Dim numRows As Integer
        numRows = CType(DataGrid1.DataSource, DataTable).Rows.Count
        Dim g As Graphics
        g = Graphics.FromHwnd(DataGrid1.Handle)
        Dim sf As StringFormat
        sf = New StringFormat(StringFormat.GenericTypographic)
        Dim size As SizeF
        Dim i As Integer
        i = 0

        Do While (i < numRows)
            size = g.MeasureString(DataGrid1(i, col).ToString, DataGrid1.Font, 500, sf)
            If (size.Width > width) Then
                width = size.Width + 40 'bilo 20
            End If
            i = (i + 1)

        Loop
        g.Dispose()
        DataGrid1.TableStyles("SuperGrid").GridColumnStyles(col).Width = CType(width, Integer)
    End Sub

    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim pt = New Point(e.X, e.Y)
        Dim hit As DataGrid.HitTestInfo = DataGrid1.HitTest(pt)

        If hit.Type = DataGrid.HitTestType.Cell Then
            DataGrid1.CurrentCell = New DataGridCell(hit.Row, hit.Column)
            DataGrid1.Select(hit.Row)
        End If

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()

    End Sub
End Class
