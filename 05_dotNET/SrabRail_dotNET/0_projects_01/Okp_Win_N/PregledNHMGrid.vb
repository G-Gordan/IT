Imports System.Data.SqlClient
Imports System.Data
Public Class PregledNHMGrid
    Inherits System.Windows.Forms.Form
    Dim dsNajave2 As New DataSet("dsNajave2")

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PregledNHMGrid))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button5 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(954, 64)
        Me.Panel1.TabIndex = 1
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.Location = New System.Drawing.Point(272, 11)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(88, 40)
        Me.Button5.TabIndex = 39
        Me.Button5.Text = "Pronadji"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(136, 27)
        Me.TextBox1.MaxLength = 6
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(112, 23)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(36, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Broj ugovora CO"
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.GhostWhite
        Me.DataGrid1.BackColor = System.Drawing.Color.GhostWhite
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.Lavender
        Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
        Me.DataGrid1.CaptionText = "Pogled u bazu podataka"
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid1.FlatMode = True
        Me.DataGrid1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DataGrid1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.DataGrid1.GridLineColor = System.Drawing.Color.RoyalBlue
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.DataGrid1.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.Lavender
        Me.DataGrid1.LinkColor = System.Drawing.Color.Teal
        Me.DataGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.Lavender
        Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.DataGrid1.ParentRowsVisible = False
        Me.DataGrid1.PreferredColumnWidth = 175
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.Teal
        Me.DataGrid1.SelectionForeColor = System.Drawing.Color.PaleGreen
        Me.DataGrid1.Size = New System.Drawing.Size(950, 316)
        Me.DataGrid1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.DataGrid1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 64)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(954, 320)
        Me.Panel2.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.DataGrid2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 384)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(954, 288)
        Me.Panel3.TabIndex = 4
        '
        'DataGrid2
        '
        Me.DataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.DataGrid2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DataGrid2.BackgroundColor = System.Drawing.Color.LightGray
        Me.DataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGrid2.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.DataGrid2.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.DataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.DataGrid2.CaptionText = "Podaci iz telegrama"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid2.FlatMode = True
        Me.DataGrid2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DataGrid2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.DataGrid2.GridLineColor = System.Drawing.Color.Gainsboro
        Me.DataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGrid2.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.DataGrid2.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.DataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.DataGrid2.LinkColor = System.Drawing.Color.Teal
        Me.DataGrid2.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.DataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.DataGrid2.PreferredColumnWidth = 150
        Me.DataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.DataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.DataGrid2.Size = New System.Drawing.Size(950, 284)
        Me.DataGrid2.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(392, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 40)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "Izlaz"
        '
        'PregledNHMGrid
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(954, 672)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PregledNHMGrid"
        Me.Text = "PregledNHMGrid"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        dsNajave2.Clear()

        Dim nmIzborSaobracaja As String = ""

        If Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "1" Then
            nmIzborSaobracaja = " AND (dbo.CoAneksi.Saobracaj = '4') "
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "2" Then
            nmIzborSaobracaja = " AND (dbo.CoAneksi.Saobracaj = '2') "
        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 9, 1) = "3" Then
            nmIzborSaobracaja = " AND (dbo.CoAneksi.Saobracaj = '3') "
        Else
            nmIzborSaobracaja = " "
        End If

        Dim sql_UpitPregled As String = "SELECT CoAneksi.Ugovor, Komitent.Naziv, CoAneksi.Tg as [Telegram br], CoAneksiNhm.NHM, CoAneksi.DatumOd, CoAneksi.DatumDo, CoAneksi.Saobracaj " & _
                                        "FROM Komitent INNER JOIN Ugovori ON Komitent.Sifra = Ugovori.SifraKorisnika INNER JOIN CoAneksi INNER JOIN CoAneksiNhm ON CoAneksi.RecID = CoAneksiNhm.RecID ON Ugovori.BrojUgovora = CoAneksi.Ugovor " & _
                                        "GROUP BY CoAneksiNhm.NHM, CoAneksi.Tg, CoAneksi.Ugovor, CoAneksi.DatumOd, CoAneksi.DatumDo, Komitent.Naziv, Ugovori.VrstaObracuna, CoAneksi.Saobracaj " & _
                                        "HAVING (CoAneksi.Ugovor = '" & RTrim(TextBox1.Text) & "') AND (Ugovori.VrstaObracuna <> 'RO') " & nmIzborSaobracaja & _
                                        "ORDER BY CoAneksi.Ugovor, CoAneksi.Tg "

        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing

        Dim _dataSet As DataSet
        _dataSet = Nothing
        Try
            dataAdapter = New SqlDataAdapter(sql_UpitPregled, OkpDbVeza)
            _dataSet = New DataSet
            dataAdapter.Fill(_dataSet)

            OkpDbVeza.Close()
        Catch ex As Exception
            MessageBox.Show(((((("Problem sa pristupom bazi-" & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(10) & "   connection:  + OkpDbVeza") _
                            + "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "            query: ") _
                            + sql_UpitPregled) _
                            + "" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10)) _
                            + ex.ToString))
            Me.Close()
            Return
        End Try

        DataGrid1.DataSource = _dataSet.Tables(0)

    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        dsNajave2.Clear()

        Dim nmUg As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
        Dim nmTg As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
        Dim nmIzborSaobracaja2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6)

        Dim ii2 As Int32 = 0
        Dim string2 As String = "SELECT TOP 100 PERCENT CASE dbo.CoAneksi.VlasnistvoKola WHEN '1' THEN 'Sve vrste' ELSE dbo.CoAneksi.VlasnistvoKola END AS [Vlasnistvo], " & _
                                "dbo.CoAneksi.UslovZaStav, dbo.CoAneksi.BmvOd as [Bruto masa od], dbo.CoAneksi.BmvDo as [Bruto masa do], dbo.CoAneksi.Iznos AS Cena, RTRIM(dbo.CoAneksiTipCene.Opis) AS [Tip cene], dbo.CoAneksi.DatumOd AS [Vazi od], dbo.CoAneksi.DatumDo AS [Vazi do] " & _
                                "FROM dbo.CoAneksi INNER JOIN dbo.CoAneksiTipCene ON dbo.CoAneksi.TipCene = dbo.CoAneksiTipCene.Sifra " & _
                                "WHERE (dbo.CoAneksi.Ugovor = '" & nmUg & "') AND (dbo.CoAneksi.Saobracaj = '" & nmIzborSaobracaja2 & "') AND dbo.CoAneksi.Tg = '" & nmTg & "' " & _
                                "ORDER BY dbo.CoAneksi.Ugovor, dbo.CoAneksi.Tg "


        Dim ad2 As New SqlDataAdapter(string2, OkpDbVeza)

        Try
            ii2 = ad2.Fill(dsNajave2)
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            DataGrid2.DataSource = dsNajave2.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Informacija o pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()

    End Sub
End Class
