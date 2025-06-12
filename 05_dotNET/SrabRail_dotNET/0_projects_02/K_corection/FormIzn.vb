Imports CrystalDecisions.Shared
Public Class FormDatum
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
    Friend WithEvents btn140 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NoviIzn As System.Windows.Forms.TextBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormDatum))
        Me.btn140 = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.NoviIzn = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btn140
        '
        Me.btn140.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btn140.Image = CType(resources.GetObject("btn140.Image"), System.Drawing.Image)
        Me.btn140.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn140.Location = New System.Drawing.Point(120, 152)
        Me.btn140.Name = "btn140"
        Me.btn140.Size = New System.Drawing.Size(88, 64)
        Me.btn140.TabIndex = 2
        Me.btn140.Text = "Prihvati "
        Me.btn140.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(120, 152)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 2
        Me.btnPrihvati.Text = "Prihvati "
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(232, 152)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 3
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(120, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Unesite novo stanje:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NoviIzn
        '
        Me.NoviIzn.Location = New System.Drawing.Point(120, 112)
        Me.NoviIzn.Name = "NoviIzn"
        Me.NoviIzn.Size = New System.Drawing.Size(136, 20)
        Me.NoviIzn.TabIndex = 1
        Me.NoviIzn.Text = ""
        '
        'FormDatum
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(336, 230)
        Me.Controls.Add(Me.NoviIzn)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.btn140)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDatum"
        Me.Text = "Izvestaj"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btn165_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim FIzv As New Form2
        Dim CRIzv As New kkkorekc100
        FIzv.CrystalReportViewer1.ReportSource = CRIzv
        'Prijavljivanje na bazu
        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "OkpWinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"
        FIzv.Show()

        Dim param1 As String 'parametar koji se odnosi na stanicu prispeæa
        Dim param2 As String 'parametar koji se odnosi na broj prispeæa
        Dim param3 As Decimal 'parametar koji se odnosi na korkciju (iznos u din)

        'param1 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
        'param2 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
        'param3 = DatumIzvestaja.Value
        param1 = PrStan
        param2 = PrBroj
        param3 = NoviIzn.Text

        '1. verzija   FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')"
        '2. verzija   FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Stanica}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')"
        '3. verzija   FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Stanica}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.DatumIzlaza}= date('" & DatumIzvestaja.Text & "')"

        'FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.PrStanica}=PrStan and {SlogKalk.Prbroj} = Prbroj "

        CRIzv.SetParameterValue(0, param1)
        CRIzv.SetParameterValue(1, param2)
        'CRIzv.SetParameterValue(2, param3)

        FIzv.Show()
    End Sub

    'Private Sub btn140_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn140.Click
    '    Dim FIzv As New FormK140
    '    Dim CRIzv As New K140trzPrispece
    '    FIzv.CrystalReportViewer1.ReportSource = CRIzv

    '    Dim CRConec As New ConnectionInfo
    '    CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
    '    CRConec.ServerName = "10.0.4.31"
    '    CRConec.DatabaseName = "WinRoba"
    '    CRConec.UserID = "Radnik"
    '    CRConec.Password = "roba2006"


    '    Dim param1 As String 'parametar koji se odnosi na vrstu saobracaja
    '    Dim param2 As String 'parametar koji se odnosi na ulaznu stanicu
    '    Dim param3 As Date   'parametar koji se odnosi na datum prispeca


    '    param1 = "4"
    '    param2 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
    '    param3 = DatumIzvestaja.Value

    '    '1.verzija     FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')"
    '    '2. verzija    FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Stanica}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')"

    '    FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Stanica}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

    '    CRIzv.SetParameterValue(0, param1)
    '    CRIzv.SetParameterValue(1, param2)
    '    CRIzv.SetParameterValue(2, param3)

    '    FIzv.Show()

    'End Sub

    'Private Sub FormDatum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    If Stampa = "k140" Then
    '        btn140.Visible = True
    '        btn165.Visible = False
    '    Else
    '        btn140.Visible = False
    '        btn165.Visible = True
    '    End If
    'End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()
    End Sub

    Private Sub FormDatum_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        NoviIzn.Focus()
    End Sub

    Private Sub NoviIzn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NoviIzn.Click
        btnPrihvati.Focus()
    End Sub


    Private Sub NoviIzn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NoviIzn.LostFocus
        Dim NN As Decimal
        NN = NoviIzn.Text
        NN = CDec(NN)
        'MessageBox.Show(Novo)
        NoviIzn.Text = Format(NN, "###,##0.00")
    End Sub

    Private Sub NoviIzn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NoviIzn.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
End Class
