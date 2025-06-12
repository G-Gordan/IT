Imports System.Data.SqlClient
Imports System.Data
Public Class TLGrid
    Inherits System.Windows.Forms.Form
    Public mCim_Datum As Date


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
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TLGrid))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionText = "Izaberi CIM tovarni list"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 40)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 150
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(904, 208)
        Me.DataGrid1.TabIndex = 2
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "SuperGrid"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(712, 264)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 0
        Me.btnPrihvati.Text = "Prihvati  "
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(824, 264)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 1
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TLGrid
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(922, 344)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.DataGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TLGrid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Izbor Tovarnog lista iz baze"
        Me.TopMost = True
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TLGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        btnPrihvati.Focus()

        Dim sql_UpitPregled As String = "SELECT SlogKalk.OtpUprava AS Operater, SlogKalk.OtpStanica AS Stanica, SlogKalk.OtpBroj AS Broj, SlogKalk.OtpDatum AS Datum, " & _
                                        "SlogKalk.ObrGodina AS Godina, SlogKalk.ObrMesec AS Mes, SlogKola.IBK AS Kola, SlogRoba.SMasa AS Neto, SlogRoba.NHM AS NHM " & _
                                        "FROM SlogKalk INNER JOIN " & _
                                        "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN " & _
                                        "SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka " & _
                                        "WHERE (SlogKalk.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')  AND (SlogKalk.OtpUprava = '" & mOtpUprava & "') AND (SlogKalk.OtpStanica = '" & mOtpStanica & "') AND (SlogKalk.OtpBroj = " & mOtpBroj & " )"

        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing

        Dim _dataSet As DataSet
        _dataSet = Nothing

        Dim ii1 As Int16 = 0

        '-------------

        Try
            dataAdapter = New SqlDataAdapter(sql_UpitPregled, DbVeza)
            _dataSet = New DataSet
            dataAdapter.Fill(_dataSet, "SuperGrid")
            ii1 = dataAdapter.Fill(_dataSet)
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

        If ii1 = 0 Then
            'MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Else
            Me.WindowState = FormWindowState.Normal
            Me.SetDesktopLocation(10, 70)
            Dim tableStyle As DataGridTableStyle
            tableStyle = New DataGridTableStyle
            tableStyle.MappingName = "SuperGrid"

            DataGrid1.TableStyles.Clear()
            DataGrid1.TableStyles.Add(tableStyle)
            DataGrid1.DataSource = _dataSet.Tables("SuperGrid")

            AutoSizeTable()
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

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        mCim_Datum = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'sifra
        mOtpDatum = mCim_Datum
        Close()


    End Sub

    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        mCim_Datum = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'sifra
        mOtpDatum = mCim_Datum
        Close()

    End Sub
    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            mCim_Datum = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'sifra
            mOtpDatum = mCim_Datum
            Me.Close()
            e.Handled = True
        End If
    End Sub
End Class
