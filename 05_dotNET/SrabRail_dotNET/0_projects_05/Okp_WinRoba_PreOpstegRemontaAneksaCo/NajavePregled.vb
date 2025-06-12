Imports System.Data.SqlClient
Public Class NajavePregled
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NajavePregled))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.btnOtkazi = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Maroon
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Verdana", 16.0!)
        Me.DataGrid1.CaptionText = "Najava"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 110
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(744, 592)
        Me.DataGrid1.TabIndex = 0
        '
        'DataGrid2
        '
        Me.DataGrid2.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid2.CaptionBackColor = System.Drawing.Color.Maroon
        Me.DataGrid2.CaptionFont = New System.Drawing.Font("Verdana", 14.0!)
        Me.DataGrid2.CaptionText = "Nerealizovana kola"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(760, 8)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.PreferredColumnWidth = 180
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.Size = New System.Drawing.Size(224, 592)
        Me.DataGrid2.TabIndex = 1
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(896, 612)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 7
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'NajavePregled
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1014, 684)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.DataGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NajavePregled"
        Me.Text = "NajavePregled"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub NajavePregled_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ii1 As Int32 = 0
        Dim dsNajave1 As New DataSet("dsNajave1")
        Dim string1 As String = ""

        If mPregledUnosa = "T" Then 'tranzit
            string1 = "SELECT TOP 100 PERCENT dbo.NajavaVoza.BrUgovora AS UGOVOR, dbo.NajavaVoza.KomBrojVoza AS NAJAVA, dbo.ZsStanice.Naziv AS [UL.PRELAZ], " & _
                      "ZsStanice_1.Naziv AS [IZ.PRELAZ], dbo.NajavaVoza.SumaKola AS NAJAVLJENO, COUNT(dbo.NajavaKola.Realizovano) AS NEREALIZOVANO,  " & _
                      "dbo.NajavaVoza.RacGodina " & _
                      "FROM dbo.NajavaVoza INNER JOIN  " & _
                      "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND  " & _
                      "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza FULL OUTER JOIN  " & _
                      "dbo.ZsStanice ZsStanice_1 ON dbo.NajavaVoza.Stanica2 = ZsStanice_1.SifraStanice FULL OUTER JOIN  " & _
                      "dbo.ZsStanice ON dbo.NajavaVoza.Stanica1 = dbo.ZsStanice.SifraStanice  " & _
                      "WHERE (dbo.NajavaVoza.SumaKola <> dbo.NajavaVoza.Realizovano) AND (dbo.NajavaKola.Realizovano = '0')  " & _
                      "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.ZsStanice.Naziv, ZsStanice_1.Naziv, dbo.NajavaVoza.BrUgovora,  " & _
                      "dbo.NajavaVoza.KomBrojVoza, dbo.NajavaVoza.RacGodina " & _
                      "ORDER BY dbo.NajavaVoza.RacGodina DESC, dbo.NajavaVoza.BrUgovora, dbo.NajavaVoza.KomBrojVoza"

            DataGrid1.CaptionText = "Najave vozova"
            DataGrid2.CaptionText = "Nerealizovana kola"
        ElseIf mPregledUnosa = "BR" Then '0d Makiša
            string1 = "SELECT TOP 100 PERCENT dbo.NajavaVoza.BrUgovora AS UGOVOR, dbo.NajavaVoza.KomBrojVoza AS NAJAVA, dbo.NajavaVoza.SumaKola AS NAJAVLJENO, " & _
                      "COUNT(dbo.NajavaKola.Realizovano) AS NEREALIZOVANO " & _
                      "FROM dbo.NajavaVoza INNER JOIN " & _
                      "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
                      "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza " & _
                      "WHERE (LEFT(dbo.NajavaVoza.KomBrojVoza, 1) = 'X') AND (dbo.NajavaVoza.SumaKola <> dbo.NajavaVoza.Realizovano) AND " & _
                      "(dbo.NajavaKola.Realizovano = '0') " & _
                      "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.BrUgovora, dbo.NajavaVoza.KomBrojVoza, " & _
                      "dbo.NajavaVoza.RacGodina " & _
                      "HAVING (dbo.NajavaVoza.RacGodina = '" & mObrGodina & "') " & _
                      "ORDER BY dbo.NajavaVoza.BrUgovora, dbo.NajavaVoza.KomBrojVoza"

            DataGrid1.CaptionText = "Najave vozova"
            DataGrid2.CaptionText = "Nerealizovana kola"
        ElseIf mPregledUnosa = "UV" Then
            string1 = "SELECT BrUgovora, KomBrojVoza, SumaKola, Realizovano " & _
                      "FROM NajavaVoza " & _
                      "WHERE (VrSao = 2) "
            DataGrid1.CaptionText = "Najave vozova"
            DataGrid2.CaptionText = "Nerealizovana kola"
        ElseIf mPregledUnosa = "IZ" Then
            string1 = "SELECT BrUgovora, KomBrojVoza, SumaKola, Realizovano " & _
                      "FROM NajavaVoza " & _
                      "WHERE (VrSao = 3) "
            DataGrid1.CaptionText = "Najave vozova"
            DataGrid2.CaptionText = "Nerealizovana kola"

        Else 'Makiš
            string1 = "SELECT Ugovor, Najava, NajavaKola " & _
                      "FROM dbo.SlogKalk " & _
                      "WHERE (SUBSTRING(dbo.SlogKalk.Najava, 2, 1) = 'X') " & _
                      "GROUP BY dbo.SlogKalk.Najava, dbo.SlogKalk.Ugovor, dbo.SlogKalk.NajavaKola, dbo.SlogKalk.ObrGodina " & _
                      "HAVING (ObrGodina = '" & mObrGodina & "') "

            DataGrid1.CaptionText = "Najave vozova do Beograd Ranzirne"
            DataGrid2.CaptionText = "Realizacija kola"

        End If

        Dim ad1 As New SqlDataAdapter(string1, OkpDbVeza)

        ii1 = ad1.Fill(dsNajave1)

        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            DataGrid1.DataSource = dsNajave1.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try


    End Sub
    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        dsNajave2.Clear()
        mBrojUg = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
        mNajava = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
        Dim ii2 As Int32 = 0
        Dim string2 As String = ""

        If mPregledUnosa = "T" Or mPregledUnosa = "BR" Then
            string2 = "SELECT  IBK AS [ ] " & _
                           "FROM     dbo.NajavaKola " & _
                           "WHERE  (BrUgovora = '" & mBrojUg & "') AND (KomBrojVoza = '" & mNajava & "') AND (Realizovano = '0')"

            DataGrid1.Width = 744
            DataGrid2.Width = 224
            DataGrid2.Left = 760
        ElseIf mPregledUnosa = "UV" Or mPregledUnosa = "IZ" Then
            string2 = "SELECT  IBK AS [ ] " & _
                      "FROM  dbo.NajavaKola " & _
                      "WHERE (BrUgovora = '" & mBrojUg & "') AND (KomBrojVoza = '" & mNajava & "') AND (Realizovano = '0')"

            DataGrid1.Width = 744
            DataGrid2.Width = 224
            DataGrid2.Left = 760


        Else

            string2 = "SELECT  dbo.SlogKola.IBK,  dbo.SlogKalk.Najava2 " & _
                            "FROM     dbo.NajavaVoza INNER JOIN " & _
                                          "dbo.SlogKalk ON dbo.NajavaVoza.BrUgovora = dbo.SlogKalk.Ugovor AND dbo.NajavaVoza.KomBrojVoza = dbo.SlogKalk.Najava INNER JOIN " & _
                                          "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                                          "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
                                         "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza " & _
                            "WHERE  (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
                            "GROUP BY dbo.NajavaVoza.BrUgovora, dbo.NajavaVoza.KomBrojVoza, dbo.NajavaVoza.SumaKola, dbo.SlogKola.IBK, dbo.SlogKalk.Najava2, " & _
                                         "dbo.NajavaKola.Realizovano "
            DataGrid1.Width = 500
            DataGrid2.Width = 480
            DataGrid2.Left = 520


        End If

        Dim ad2 As New SqlDataAdapter(string2, OkpDbVeza)

        '        ii2 = ad2.Fill(dsNajave2)

        Try
            ii2 = ad2.Fill(dsNajave2)
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            DataGrid2.DataSource = dsNajave2.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub
End Class
