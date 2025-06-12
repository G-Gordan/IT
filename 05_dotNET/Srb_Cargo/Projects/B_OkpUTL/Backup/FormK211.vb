Imports System.Data.SqlClient
Public Class FormK211
    Inherits System.Windows.Forms.Form
    Dim dsK211 As DataSet
    Public K211_sifra As Int32
    ''Public K211_sifra As String
    Public K211_naziv As String
    Public dvK211 As New DataView(dtK211)

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
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnBrisiRobu As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormK211))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnBrisiRobu = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.DataGrid1.BackColor = System.Drawing.Color.DarkGray
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.White
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy
        Me.DataGrid1.CaptionText = "Spisak kontrolnih primedbi"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DataGrid1.ForeColor = System.Drawing.Color.Black
        Me.DataGrid1.GridLineColor = System.Drawing.Color.Black
        Me.DataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.Black
        Me.DataGrid1.LinkColor = System.Drawing.Color.Navy
        Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White
        Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy
        Me.DataGrid1.SelectionForeColor = System.Drawing.Color.White
        Me.DataGrid1.Size = New System.Drawing.Size(976, 400)
        Me.DataGrid1.TabIndex = 0
        '
        'DataGrid2
        '
        Me.DataGrid2.AlternatingBackColor = System.Drawing.Color.Silver
        Me.DataGrid2.BackColor = System.Drawing.Color.White
        Me.DataGrid2.CaptionBackColor = System.Drawing.Color.Maroon
        Me.DataGrid2.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DataGrid2.CaptionForeColor = System.Drawing.Color.White
        Me.DataGrid2.CaptionText = "Izabrane greske"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.DataGrid2.ForeColor = System.Drawing.Color.Black
        Me.DataGrid2.GridLineColor = System.Drawing.Color.Silver
        Me.DataGrid2.HeaderBackColor = System.Drawing.Color.Silver
        Me.DataGrid2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.DataGrid2.HeaderForeColor = System.Drawing.Color.Black
        Me.DataGrid2.LinkColor = System.Drawing.Color.Maroon
        Me.DataGrid2.Location = New System.Drawing.Point(8, 424)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ParentRowsBackColor = System.Drawing.Color.Silver
        Me.DataGrid2.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DataGrid2.PreferredColumnWidth = 300
        Me.DataGrid2.SelectionBackColor = System.Drawing.Color.Maroon
        Me.DataGrid2.SelectionForeColor = System.Drawing.Color.White
        Me.DataGrid2.Size = New System.Drawing.Size(976, 128)
        Me.DataGrid2.TabIndex = 1
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(896, 564)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 7
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(784, 564)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 6
        Me.btnPrihvati.Text = "Prihvati  [ F12 ]"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnBrisiRobu
        '
        Me.btnBrisiRobu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiRobu.Image = CType(resources.GetObject("btnBrisiRobu.Image"), System.Drawing.Image)
        Me.btnBrisiRobu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiRobu.Location = New System.Drawing.Point(10, 560)
        Me.btnBrisiRobu.Name = "btnBrisiRobu"
        Me.btnBrisiRobu.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiRobu.TabIndex = 11
        Me.btnBrisiRobu.Text = "Brisi"
        Me.btnBrisiRobu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBrisiRobu.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(320, 560)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 72)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(144, 560)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 48)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Brisi sve"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'FormK211
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(994, 640)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnBrisiRobu)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.DataGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormK211"
        Me.Text = "Kontrolne primedbe"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FormatK211Grid()
        If dsK211 Is Nothing Then
            Me.DataGrid2.DataSource = dtK211
        Else
            Me.DataGrid2.DataSource.DataSource = dsK211.Tables(0)
        End If

    End Sub
    Private Sub FormK211_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatK211Grid()

        Dim ii As Int32 = 0 'Broj ucitanih slogova
        Dim dsPomocniBroj As New DataSet("ds")   'DataSet
        Dim strUpit As String

        'strUpit = "SELECT * FROM ZsKontrolnePrimedbe"

        strUpit = "SELECT * FROM ZsKontrolnePrimedbe WHERE VrstaSaobracaja = 1"

        Me.DataGrid1.CaptionText = "Spisak kontrolnih primedbi"

        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing
        Dim _dataSet As DataSet
        _dataSet = Nothing

        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            dataAdapter = New SqlDataAdapter(strUpit, OkpDbVeza)
            _dataSet = New DataSet

            dataAdapter.Fill(_dataSet, "SuperGrid")
            Dim tableStyle As DataGridTableStyle
            tableStyle = New DataGridTableStyle
            tableStyle.MappingName = "SuperGrid"

            DataGrid1.TableStyles.Clear()
            DataGrid1.TableStyles.Add(tableStyle)
            DataGrid1.DataSource = _dataSet.Tables("SuperGrid")

            AutoSizeTable()

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally

        End Try
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
    Public Sub AutoSizeTable2()

        Dim numCols As Integer
        numCols = CType(DataGrid2.DataSource, DataTable).Columns.Count
        Dim i As Integer
        i = 0
        Do While (i < numCols)
            AutoSizeCol2(i)
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
    Public Sub AutoSizeCol2(ByVal col As Integer)
        Dim width As Single
        width = 0
        Dim numRows As Integer
        numRows = CType(DataGrid2.DataSource, DataTable).Rows.Count
        Dim g As Graphics
        g = Graphics.FromHwnd(DataGrid2.Handle)
        Dim sf As StringFormat
        sf = New StringFormat(StringFormat.GenericTypographic)
        Dim size As SizeF
        Dim i As Integer
        i = 0

        Do While (i < numRows)
            size = g.MeasureString(DataGrid2(i, col).ToString, DataGrid2.Font, 500, sf)
            If (size.Width > width) Then
                width = size.Width + 40 'bilo 20
            End If
            i = (i + 1)

        Loop
        g.Dispose()
        DataGrid2.TableStyles("SuperGrid").GridColumnStyles(col).Width = CType(width, Integer)
    End Sub

    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim pt = New Point(e.X, e.Y)
        Dim hit As DataGrid.HitTestInfo = DataGrid1.HitTest(pt)

        If hit.Type = DataGrid.HitTestType.Cell Then
            DataGrid1.CurrentCell = New DataGridCell(hit.Row, hit.Column)
            DataGrid1.Select(hit.Row)
        End If

    End Sub
    Private Sub DataGrid2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid2.MouseUp
        Dim pt = New Point(e.X, e.Y)
        Dim hit As DataGrid.HitTestInfo = DataGrid2.HitTest(pt)

        If hit.Type = DataGrid.HitTestType.Cell Then
            DataGrid2.CurrentCell = New DataGridCell(hit.Row, hit.Column)
            DataGrid2.Select(hit.Row)
        End If

    End Sub


    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        Dim currRowKola As DataRow

        currRowKola = CType(DataGrid1.DataSource, DataTable).Rows(DataGrid1.CurrentCell.RowNumber)

        K211_sifra = currRowKola(0, DataRowVersion.Current) '.ToString()
        K211_naziv = currRowKola(2, DataRowVersion.Current).ToString()

        Dim dtRow As DataRow = dtK211.NewRow
        dtK211.Rows.Add(New Object() {K211_sifra, K211_naziv, "I"})
        Me.DataGrid2.Refresh()


    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CType(DataGrid2.DataSource, DataTable).Rows(DataGrid2.CurrentCell.RowNumber).Delete()

    End Sub
    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        'zbog ranije verzije char(2)
        ''Dim K211_Red As DataRow
        ''Dim mSumaK211 As String = ""
        ''If dtK211.Rows.Count > 0 Then
        ''    For Each K211_Red In dtK211.Rows
        ''        mSumaK211 = mSumaK211 + K211_Red.Item("Sifra")
        ''    Next
        ''End If
        ''mSifraK211 = mSumaK211
        _OpenForm = "K211"
        Close()

    End Sub


    Private Sub btnBrisiRobu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiRobu.Click
        If MasterAction = "New" Then
            Try
                CType(DataGrid2.DataSource, DataTable).Rows(DataGrid2.CurrentCell.RowNumber).Delete()
            Catch ex As Exception
                MsgBox(ex, MsgBoxStyle.Critical)
            End Try
        Else
            Try
                Dim rowNak As Data.DataRow

                rowNak = CType(DataGrid2.DataSource, DataTable).Rows(DataGrid2.CurrentCell.RowNumber)
                rowNak = dtK211.Rows(DataGrid2.CurrentCell.RowNumber)
                rowNak("Action") = "D"

                dvK211.RowFilter = "Action LIKE 'U'"
                DataGrid2.DataSource = dvK211
                DataGrid2.Refresh()

            Catch ex As Exception
                MsgBox(ex, MsgBoxStyle.Critical)
            End Try

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FormatK211Grid()

        Dim ii As Int32 = 0 'Broj ucitanih slogova
        Dim dsPomocniBroj As New DataSet("ds")   'DataSet
        Dim strUpit As String

        strUpit = "SELECT * FROM ZsKontrolnePrimedbe"
        Me.DataGrid1.CaptionText = "Spisak kontrolnih primedbi"

        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing
        Dim _dataSet As DataSet
        _dataSet = Nothing

        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            dataAdapter = New SqlDataAdapter(strUpit, OkpDbVeza)
            _dataSet = New DataSet
            'ii = dataAdapter.Fill(_dataSet)
            dataAdapter.Fill(_dataSet, "SuperGrid")
            'DataGrid1.DataSource = _dataSet.Tables(0)
            Dim tableStyle As DataGridTableStyle
            tableStyle = New DataGridTableStyle
            tableStyle.MappingName = "SuperGrid"

            DataGrid1.TableStyles.Clear()
            DataGrid1.TableStyles.Add(tableStyle)
            DataGrid1.DataSource = _dataSet.Tables("SuperGrid")

            AutoSizeTable()

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        dtK211.Clear()
        Close()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dtK211.Clear()
        Me.DataGrid2.Refresh()
    End Sub
End Class
