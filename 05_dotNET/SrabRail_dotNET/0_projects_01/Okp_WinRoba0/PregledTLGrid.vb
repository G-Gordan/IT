Imports System.Data.SqlClient
Imports System.Data

Public Class FormGrid
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
        Me.DataGrid1.CaptionText = "Pogled u bazu podataka"
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
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(872, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 31)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Suma"
        Me.Button1.Visible = False
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

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        '---------------------------------------- postavljanje racunskog meseca ------------------------------------------

        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
            IzborSaobracaja = "4"
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
            IzborSaobracaja = "2"
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
            IzborSaobracaja = "3"
        Else
            IzborSaobracaja = "1"
        End If

        Dim sql_text1 As String = "SELECT MesecUnosa, GodinaUnosa FROM RacMesec " & _
                                  "WHERE (VSaob = '" & IzborSaobracaja & "')"
        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrRm.Read()
            qObrMesec = rdrRm.GetString(0)
            qObrGodina = rdrRm.GetString(1)
        Loop
        rdrRm.Close()
        OkpDbVeza.Close()
        '----------------------------------------------------------------------------------------------------------------------------
        Button1.Visible = False

        If mPregledUnosa = "M" Then
            If Val(mBrojUg) > 0 Then
                DataGrid1.CaptionText = DataGrid1.CaptionText & "  -  Ug. " & mBrojUg
            End If
            If mBrojUg <> "" And mNajava <> "" Then
                Button1.Visible = True
            Else
                Button1.Visible = False
            End If
        ElseIf mPregledUnosa = "TK" Then
            DataGrid1.CaptionText = "Trazenje kola br. " & mIBK & "  u bazi podataka"

            sql_UpitPregled = "SELECT SlogKalk.ObrMesec as MESEC, SlogKalk.OtpUprava as UPRAVA, SlogKalk.OtpStanica AS STANICA, SlogKalk.OtpBroj AS BROJ, NajavaKola.BrUgovora AS UGOVOR, SlogKalk.Najava AS VOZ, " & _
                              "SlogKalk.Najava2 as MAKIS, SlogKalk.ZsUlPrelaz as ULAZ, SlogKalk.ZsIzPrelaz as IZLAZ " & _
                              "FROM SlogKola INNER JOIN " & _
                              "NajavaKola ON SlogKola.IBK = NajavaKola.IBK INNER JOIN " & _
                              "SlogKalk ON SlogKola.RecID = SlogKalk.RecID AND SlogKola.Stanica = SlogKalk.Stanica " & _
                              "GROUP BY NajavaKola.IBK, SlogKalk.ObrMesec, NajavaKola.BrUgovora, SlogKalk.ZsUlPrelaz, SlogKalk.ZsIzPrelaz, SlogKalk.Najava, SlogKalk.Najava2, " & _
                              "SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj " & _
                              "HAVING (NajavaKola.IBK = '" & mIBK & "')"
        ElseIf mPregledUnosa = "TKN" Then
            DataGrid1.CaptionText = "Trazenje kola br. " & mIBK & "  u najavama vozova"

            sql_UpitPregled = "SELECT dbo.NajavaVoza.BrUgovora AS UGOVOR, dbo.NajavaVoza.KomBrojVoza AS NAJAVA, dbo.NajavaVoza.SumaKola AS [NAJAVLJENO KOLA] " & _
                              "FROM dbo.NajavaVoza INNER JOIN " & _
                              "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
                              "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza " & _
                              "WHERE (NajavaKola.IBK = '" & mIBK & "')"

        ElseIf mPregledUnosa = "D" Then
            DataGrid1.CaptionText = "Dnevni unos"
            If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
                sql_UpitPregled = "SELECT TOP 100 PERCENT dbo.UserTab.Naziv AS REFERENT, COUNT(dbo.UserTab.Naziv) AS [OBRADJENO] " & _
                                  "FROM dbo.SlogKalk INNER JOIN " & _
                                  "dbo.UserTab ON dbo.SlogKalk.Referent1 = dbo.UserTab.UserID " & _
                                  "WHERE (dbo.SlogKalk.Saobracaj = '4') AND (dbo.SlogKalk.DatumObrade = " & "'" & Today.Month.ToString & "." & Today.Day.ToString & "." & Today.Year.ToString & "') " & _
                                  "GROUP BY dbo.SlogKalk.Referent1, dbo.SlogKalk.DatumObrade, dbo.UserTab.Naziv "
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
                sql_UpitPregled = "SELECT TOP 100 PERCENT dbo.UserTab.Naziv AS REFERENT, COUNT(dbo.UserTab.Naziv) AS [OBRADJENO] " & _
                                  "FROM dbo.SlogKalk INNER JOIN " & _
                                  "dbo.UserTab ON dbo.SlogKalk.Referent1 = dbo.UserTab.UserID " & _
                                  "WHERE (dbo.SlogKalk.Saobracaj = '2') AND (dbo.SlogKalk.DatumObrade = " & "'" & Today.Month.ToString & "." & Today.Day.ToString & "." & Today.Year.ToString & "') " & _
                                  "GROUP BY dbo.SlogKalk.Referent1, dbo.SlogKalk.DatumObrade, dbo.UserTab.Naziv "

            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
                sql_UpitPregled = "SELECT TOP 100 PERCENT dbo.UserTab.Naziv AS REFERENT, COUNT(dbo.UserTab.Naziv) AS [OBRADJENO] " & _
                  "FROM    dbo.SlogKalk INNER JOIN " & _
                  "dbo.UserTab ON dbo.SlogKalk.Referent1 = dbo.UserTab.UserID " & _
                  "WHERE (dbo.SlogKalk.Saobracaj = '3') AND (dbo.SlogKalk.DatumObrade = " & "'" & Today.Month.ToString & "." & Today.Day.ToString & "." & Today.Year.ToString & "') " & _
                  "GROUP BY dbo.SlogKalk.Referent1, dbo.SlogKalk.DatumObrade, dbo.UserTab.Naziv "

            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "9" Then
                sql_UpitPregled = "SELECT TOP 100 PERCENT dbo.UserTab.Naziv AS REFERENT, COUNT(dbo.UserTab.Naziv) AS [OBRADJENO] " & _
                  "FROM    dbo.SlogKalk INNER JOIN " & _
                  "dbo.UserTab ON dbo.SlogKalk.Referent1 = dbo.UserTab.UserID " & _
                  "WHERE (dbo.SlogKalk.DatumObrade = " & "'" & Today.Month.ToString & "." & Today.Day.ToString & "." & Today.Year.ToString & "') " & _
                  "GROUP BY dbo.SlogKalk.Referent1, dbo.SlogKalk.DatumObrade, dbo.UserTab.Naziv "
            End If
        ElseIf mPregledUnosa = "X" Then

            DataGrid1.CaptionText = "Pregled najava vozova"

            sql_UpitPregled = "SELECT TOP 100 PERCENT dbo.SlogKalk.Ugovor, dbo.SlogKalk.Najava, SUM(dbo.SlogKalk.tlSumaFr) AS Iznos, dbo.SlogKalk.NajavaKola AS [Najavljeno kola], COUNT(*) AS [Realizovano kola], " & _
                                        "(SUM(dbo.SlogKola.Tara) + SUM(dbo.SlogRoba.SMasa))/1000 AS [Bruto masa], SUM(dbo.SlogKola.Tara)/1000 AS Tara, SUM(dbo.SlogRoba.SMasa)/1000 " & _
                                        "AS [Masa robe] " & _
                                        "FROM dbo.SlogKalk INNER JOIN " & _
                                        "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                                        "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND " & _
                                        "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
                                        "WHERE (dbo.SlogKalk.Najava > '0') AND (dbo.SlogKalk.ObrGodina = '" & qObrGodina & "') AND (dbo.SlogKalk.ObrMesec = '" & qObrMesec & "') " & _
                                        "GROUP BY dbo.SlogKalk.Najava, dbo.SlogKalk.Ugovor,dbo.SlogKalk.NajavaKola " & _
                                        "ORDER BY dbo.SlogKalk.Ugovor, dbo.SlogKalk.Najava"


        End If

        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing

        Dim _dataSet As DataSet
        _dataSet = Nothing
        Try
            dataAdapter = New SqlDataAdapter(sql_UpitPregled, OkpDbVeza)
            _dataSet = New DataSet
            If mPregledUnosa = "M" Or mPregledUnosa = "X" Or mPregledUnosa = "TK" Or mPregledUnosa = "TKN" Then
                dataAdapter.Fill(_dataSet, "SuperGrid")
            Else
                dataAdapter.Fill(_dataSet)
            End If
            '            dataAdapter.Fill(_dataSet, "SuperGrid")
            OkpDbVeza.Close() 'connection.Close()
        Catch ex As Exception
            MessageBox.Show(((((("Problem sa pristupom bazi-" & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(10) & "   connection:  + OkpDbVeza") _
                            + "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            query: ") _
                            + sql_UpitPregled) _
                            + "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10)) _
                            + ex.ToString))
            Me.Close()
            Return
        End Try
        'Dim tableStyle As DataGridTableStyle
        'tableStyle = New DataGridTableStyle
        'tableStyle.MappingName = "SuperGrid"

        If mPregledUnosa = "M" Or mPregledUnosa = "X" Or mPregledUnosa = "TK" Or mPregledUnosa = "TKN" Then
            Dim tableStyle As DataGridTableStyle
            tableStyle = New DataGridTableStyle
            tableStyle.MappingName = "SuperGrid"

            DataGrid1.TableStyles.Clear()
            DataGrid1.TableStyles.Add(tableStyle)
            DataGrid1.DataSource = _dataSet.Tables("SuperGrid")

            AutoSizeTable()
        ElseIf mPregledUnosa = "D" Then
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()

            Me.DataGrid1.AlternatingBackColor = System.Drawing.SystemColors.Window
            Me.DataGrid1.BackgroundColor = System.Drawing.SystemColors.Control
            Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Maroon
            Me.DataGrid1.CaptionFont = New System.Drawing.Font("Verdana", 16.0!)
            Me.DataGrid1.CaptionText = "Dnevni unos"
            Me.DataGrid1.DataMember = ""
            Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DataGrid1.GridLineColor = System.Drawing.SystemColors.Control
            Me.DataGrid1.HeaderBackColor = System.Drawing.SystemColors.Control
            Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid1.LinkColor = System.Drawing.SystemColors.HotTrack
            Me.DataGrid1.Location = New System.Drawing.Point(0, 1)
            'Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
            Me.DataGrid1.Name = "DataGrid1"
            Me.DataGrid1.PreferredColumnWidth = 250
            Me.DataGrid1.ReadOnly = True
            Me.DataGrid1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
            Me.DataGrid1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.DataGrid1.Size = New System.Drawing.Size(1024, 650)
            Me.DataGrid1.TabIndex = 0
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            DataGrid1.DataSource = _dataSet.Tables(0)
            'ElseIf mPregledUnosa = "X" Then
            '    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            '    Me.SuspendLayout()

            '    Me.DataGrid1.AlternatingBackColor = System.Drawing.SystemColors.Window
            '    Me.DataGrid1.BackgroundColor = System.Drawing.SystemColors.Control
            '    Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
            '    Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Maroon
            '    Me.DataGrid1.CaptionFont = New System.Drawing.Font("Verdana", 16.0!)
            '    Me.DataGrid1.CaptionText = "Pregled najava vozova"
            '    Me.DataGrid1.DataMember = ""
            '    Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            '    Me.DataGrid1.GridLineColor = System.Drawing.SystemColors.Control
            '    Me.DataGrid1.HeaderBackColor = System.Drawing.SystemColors.Control
            '    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            '    Me.DataGrid1.LinkColor = System.Drawing.SystemColors.HotTrack
            '    Me.DataGrid1.Location = New System.Drawing.Point(0, 1)
            '    'Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
            '    Me.DataGrid1.Name = "DataGrid1"
            '    Me.DataGrid1.PreferredColumnWidth = 80
            '    Me.DataGrid1.ReadOnly = True
            '    Me.DataGrid1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
            '    Me.DataGrid1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText
            '    Me.DataGrid1.Size = New System.Drawing.Size(1024, 768)
            '    Me.DataGrid1.TabIndex = 0
            '    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            '    Me.ResumeLayout(False)
            '    DataGrid1.DataSource = _dataSet.Tables(0)
        End If

        'DataGrid1.TableStyles.Clear()
        'DataGrid1.TableStyles.Add(tableStyle)
        'DataGrid1.DataSource = _dataSet.Tables("SuperGrid")

        '        AutoSizeTable()

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
        '---------------------------------------- Suma po najavi ------------------------------------------
        IzborSaobracaja = "4"
        Dim sql_text1 As String

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        If Microsoft.VisualBasic.Mid(mNajava, 1, 1) = "X" Then
            sql_text1 = "SELECT TOP 100 PERCENT COUNT(dbo.SlogKalk.UkupnoKola) AS Kola, (SUM(dbo.SlogKola.Tara) / 1000 + SUM(dbo.SlogRoba.SMasa) / 1000) AS Bruto, " & _
                                              "SUM(dbo.SlogKola.Tara) / 1000 AS Tara, SUM(dbo.SlogRoba.SMasa) / 1000 AS Neto, SUM(dbo.SlogKalk.rSumaFr) AS Iznos, " & _
                                              "SUM(dbo.SlogKalk.rPrevFr) AS Prevoznina, SUM(dbo.SlogKalk.rNakFr) AS Naknade, dbo.SlogKalk.NajavaKola2 " & _
                                              "FROM dbo.SlogKalk INNER JOIN " & _
                                              "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                                              "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND " & _
                                              "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
                                              "WHERE (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava2 = '" & mNajava & "') " & _
                                              "GROUP BY dbo.SlogKalk.Najava, dbo.SlogKalk.Ugovor, dbo.SlogKalk.NajavaKola2 "

        Else
            sql_text1 = "SELECT TOP 100 PERCENT COUNT(dbo.SlogKalk.UkupnoKola) AS Kola, (SUM(dbo.SlogKola.Tara) / 1000 + SUM(dbo.SlogRoba.SMasa) / 1000) AS Bruto, " & _
                                              "SUM(dbo.SlogKola.Tara) / 1000 AS Tara, SUM(dbo.SlogRoba.SMasa) / 1000 AS Neto, SUM(dbo.SlogKalk.tlSumaFr) AS Iznos, " & _
                                              "SUM(dbo.SlogKalk.tlPrevFr) AS Prevoznina, SUM(dbo.SlogKalk.tlNakFr) AS Naknade, SUM(dbo.SlogKalk.tlNakCo82) AS CO, dbo.SlogKalk.NajavaKola " & _
                                              "FROM dbo.SlogKalk INNER JOIN " & _
                                              "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                                              "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND " & _
                                              "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
                                              "WHERE (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') " & _
                                              "GROUP BY dbo.SlogKalk.Najava, dbo.SlogKalk.Ugovor, dbo.SlogKalk.NajavaKola "

        End If

        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        Dim Str_Najava As String = ""
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrRm.Read()
            If Microsoft.VisualBasic.Mid(mNajava, 1, 1) = "X" Then
                Str_Najava = "Broj kola  po najavi             " & rdrRm.GetInt32(7).ToString & Chr(13)
                Str_Najava = Str_Najava & "Realizovano kola                 " & rdrRm.GetInt32(0).ToString & Chr(13)
                Str_Najava = Str_Najava & "Ukupna bruto masa voza    " & rdrRm.GetInt32(1).ToString & Chr(13)
                Str_Najava = Str_Najava & "Ukupna tara                        " & rdrRm.GetInt32(2).ToString & Chr(13)
                Str_Najava = Str_Najava & "Ukupna neto masa              " & rdrRm.GetInt32(3).ToString & Chr(13)
                Str_Najava = Str_Najava & "Ukupni prevozni troskovi     " & rdrRm.GetDecimal(4).ToString & Chr(13)
                Str_Najava = Str_Najava & "Prevoznina za voz               " & rdrRm.GetDecimal(5).ToString & Chr(13)
                Str_Najava = Str_Najava & "Naknade za sp. usluge        " & rdrRm.GetDecimal(6).ToString & Chr(13)
                'Str_Najava = Str_Najava & "Naknade cent. obracun       " & rdrRm.GetDecimal(6).ToString & Chr(13)
            Else
                Str_Najava = "Broj kola  po najavi             " & rdrRm.GetInt32(8).ToString & Chr(13)
                Str_Najava = Str_Najava & "Realizovano kola                 " & rdrRm.GetInt32(0).ToString & Chr(13)
                Str_Najava = Str_Najava & "Ukupna bruto masa voza    " & rdrRm.GetInt32(1).ToString & Chr(13)
                Str_Najava = Str_Najava & "Ukupna tara                        " & rdrRm.GetInt32(2).ToString & Chr(13)
                Str_Najava = Str_Najava & "Ukupna neto masa              " & rdrRm.GetInt32(3).ToString & Chr(13)
                Str_Najava = Str_Najava & "Ukupni prevozni troskovi     " & rdrRm.GetDecimal(4).ToString & Chr(13)
                Str_Najava = Str_Najava & "Prevoznina za voz               " & rdrRm.GetDecimal(5).ToString & Chr(13)
                Str_Najava = Str_Najava & "Naknade za sp. usluge        " & rdrRm.GetDecimal(6).ToString & Chr(13)
                Str_Najava = Str_Najava & "Naknade cent. obracun       " & rdrRm.GetDecimal(7).ToString & Chr(13)
            End If
            
            MessageBox.Show(Str_Najava, "Podaci o najavi", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Loop
        rdrRm.Close()
        OkpDbVeza.Close()
        '----------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
