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
    Friend WithEvents DatumIzvestaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn165 As System.Windows.Forms.Button
    Friend WithEvents btn140 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnK165m As System.Windows.Forms.Button
    Friend WithEvents btn140mRadinac As System.Windows.Forms.Button
    Friend WithEvents btn165mRadinac As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormDatum))
        Me.DatumIzvestaja = New System.Windows.Forms.DateTimePicker
        Me.btn140 = New System.Windows.Forms.Button
        Me.btn165 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnK165m = New System.Windows.Forms.Button
        Me.btn165mRadinac = New System.Windows.Forms.Button
        Me.btn140mRadinac = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DatumIzvestaja
        '
        Me.DatumIzvestaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DatumIzvestaja.Location = New System.Drawing.Point(216, 192)
        Me.DatumIzvestaja.Name = "DatumIzvestaja"
        Me.DatumIzvestaja.Size = New System.Drawing.Size(240, 23)
        Me.DatumIzvestaja.TabIndex = 0
        '
        'btn140
        '
        Me.btn140.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btn140.Image = CType(resources.GetObject("btn140.Image"), System.Drawing.Image)
        Me.btn140.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn140.Location = New System.Drawing.Point(248, 248)
        Me.btn140.Name = "btn140"
        Me.btn140.Size = New System.Drawing.Size(88, 64)
        Me.btn140.TabIndex = 2
        Me.btn140.Text = "Prihvati "
        Me.btn140.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn165
        '
        Me.btn165.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btn165.Image = CType(resources.GetObject("btn165.Image"), System.Drawing.Image)
        Me.btn165.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn165.Location = New System.Drawing.Point(248, 248)
        Me.btn165.Name = "btn165"
        Me.btn165.Size = New System.Drawing.Size(88, 64)
        Me.btn165.TabIndex = 3
        Me.btn165.Text = "Prihvati "
        Me.btn165.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(136, 136)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(368, 248)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 5
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(216, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Izaberite datum za koji se pravi izvestaj"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnK165m
        '
        Me.btnK165m.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnK165m.Image = CType(resources.GetObject("btnK165m.Image"), System.Drawing.Image)
        Me.btnK165m.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnK165m.Location = New System.Drawing.Point(232, 248)
        Me.btnK165m.Name = "btnK165m"
        Me.btnK165m.Size = New System.Drawing.Size(88, 64)
        Me.btnK165m.TabIndex = 6
        Me.btnK165m.Text = "Prihvati"
        Me.btnK165m.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn165mRadinac
        '
        Me.btn165mRadinac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btn165mRadinac.Image = CType(resources.GetObject("btn165mRadinac.Image"), System.Drawing.Image)
        Me.btn165mRadinac.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn165mRadinac.Location = New System.Drawing.Point(216, 248)
        Me.btn165mRadinac.Name = "btn165mRadinac"
        Me.btn165mRadinac.Size = New System.Drawing.Size(88, 64)
        Me.btn165mRadinac.TabIndex = 7
        Me.btn165mRadinac.Text = "Prihvati"
        Me.btn165mRadinac.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn140mRadinac
        '
        Me.btn140mRadinac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btn140mRadinac.Image = CType(resources.GetObject("btn140mRadinac.Image"), System.Drawing.Image)
        Me.btn140mRadinac.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn140mRadinac.Location = New System.Drawing.Point(192, 248)
        Me.btn140mRadinac.Name = "btn140mRadinac"
        Me.btn140mRadinac.Size = New System.Drawing.Size(88, 64)
        Me.btn140mRadinac.TabIndex = 8
        Me.btn140mRadinac.Text = "Prihvati "
        Me.btn140mRadinac.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'FormDatum
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(478, 332)
        Me.Controls.Add(Me.btn140mRadinac)
        Me.Controls.Add(Me.btn165mRadinac)
        Me.Controls.Add(Me.btnK165m)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn165)
        Me.Controls.Add(Me.btn140)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DatumIzvestaja)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDatum"
        Me.Text = "Izvestaj"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btn165_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn165.Click
        Dim FIzv As New FormK165
        Dim CRIzv As New K165Otpravljanje
        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "WinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String 'parametar koji se odnosi na vrstu saobracaja
        Dim param2 As String 'parametar koji se odnosi na ulaznu stanicu
        Dim param3 As Date   'parametar koji se odnosi na datum prispeca

        param1 = "4"
        param2 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
        param3 = DatumIzvestaja.Value

        '1. verzija   FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')"
        '2. verzija   FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Stanica}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')"
        '3. verzija   FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Stanica}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.DatumIzlaza}= date('" & DatumIzvestaja.Text & "')"

        FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.IzEtiketa} > 0 and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.DatumIzlaza}= date('" & DatumIzvestaja.Text & "')"

        CRIzv.SetParameterValue(0, param1)
        CRIzv.SetParameterValue(1, param2)
        CRIzv.SetParameterValue(2, param3)

        FIzv.Show()
    End Sub

    Private Sub btn140_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn140.Click
        Dim FIzv As New FormK140
        Dim CRIzv As New K140trzPrispece
        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "WinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String 'parametar koji se odnosi na vrstu saobracaja
        Dim param2 As String 'parametar koji se odnosi na ulaznu stanicu
        Dim param3 As Date   'parametar koji se odnosi na datum prispeca

        param1 = "4"
        param2 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
        param3 = DatumIzvestaja.Value

        '1.verzija     FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')"
        '2. verzija    FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Stanica}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')"

        FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Stanica}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

        CRIzv.SetParameterValue(0, param1)
        CRIzv.SetParameterValue(1, param2)
        CRIzv.SetParameterValue(2, param3)

        FIzv.Show()

    End Sub

    Private Sub FormDatum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btn140.Visible = False
        btn165.Visible = False
        btnK165m.Visible = False
        btn140mRadinac.Visible = False
        btn165mRadinac.Visible = False

        If GranicnaStanica = "N" Then
            If Stampa = "k165mRadinac" Then
                btn140.Visible = False
                btn165.Visible = False
                btnK165m.Visible = False
                btn140mRadinac.Visible = False
                btn165mRadinac.Visible = True
            ElseIf Stampa = "k140mRadinac" Then
                btn140.Visible = False
                btn165.Visible = False
                btnK165m.Visible = False
                btn140mRadinac.Visible = True
                btn165mRadinac.Visible = False
            Else 'test!!
                btn140.Visible = False
                btn165.Visible = False
                btnK165m.Visible = True
                btn140mRadinac.Visible = False
                btn165mRadinac.Visible = False
            End If
        Else
            If Stampa = "k140" Then
                btn140.Visible = True
                btn165.Visible = False
                btnK165m.Visible = False
                btn140mRadinac.Visible = False
                btn165mRadinac.Visible = False
            ElseIf Stampa = "k165" Then
                btn140.Visible = False
                btn165.Visible = True
                btnK165m.Visible = False
                btn140mRadinac.Visible = False
                btn165mRadinac.Visible = False
            ElseIf Stampa = "k165m" Then
                btn140.Visible = False
                btn165.Visible = False
                btnK165m.Visible = True
                btn140mRadinac.Visible = False
                btn165mRadinac.Visible = False
            Else
                btn140.Visible = False
                btn165.Visible = False
                btnK165m.Visible = True
                btn140mRadinac.Visible = False
                btn165mRadinac.Visible = False
            End If

        End If


        'If Stampa = "k140" Then
        '    btn165.Visible = False
        '    btnK165m.Visible = False
        '    btn140.Visible = True
        'Else
        '    If Stampa = "k165" Then
        '        btn140.Visible = False
        '        btnK165m.Visible = False
        '        btn165.Visible = True
        '    ElseIf Stampa = "k165mRadinac" Then
        '        btn140.Visible = False
        '        btn165.Visible = False
        '        btnK165m.Visible = False
        '    ElseIf Stampa = "k140mRadinac" Then
        '        btn140.Visible = False
        '        btn165.Visible = False
        '        btnK165m.Visible = False
        '    Else
        '        btn140.Visible = False
        '        btn165.Visible = False
        '        btnK165m.Visible = True
        '    End If
        'End If

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub btnK165m_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnK165m.Click
        If Stampa = "k165m" Then
            Dim FIzv As New FormK165
            Dim CRIzv As New K165m
            FIzv.CrystalReportViewer1.ReportSource = CRIzv

            Dim CRConec As New ConnectionInfo
            CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            CRConec.ServerName = "10.0.4.31"
            CRConec.DatabaseName = "WinRoba"
            CRConec.UserID = "Radnik"
            CRConec.Password = "roba2006"

            Dim param1 As String 'parametar koji se odnosi na vrstu saobracaja
            Dim param2 As String 'parametar koji se odnosi na ulaznu stanicu
            Dim param3 As Date   'parametar koji se odnosi na datum izlaza

            param1 = "3"
            param2 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
            param3 = DatumIzvestaja.Value

            FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "3" & "') and {ZsTarifa.SifraVS}= 3 and {SlogKalk.DatumIzlaza}= date('" & DatumIzvestaja.Text & "')"

            CRIzv.SetParameterValue(0, param1)
            CRIzv.SetParameterValue(1, param2)
            CRIzv.SetParameterValue(2, param3)

            FIzv.Show()
        Else
            mMesec = Me.DatumIzvestaja.Value.Month.ToString
            mDan = Me.DatumIzvestaja.Value.Day.ToString
            mGodina = Me.DatumIzvestaja.Value.Year.ToString
            Dim Form2p As New FormGrid
            Form2p.ShowDialog()

            'If Stampa = "grUlazniVozovi" Or Stampa = "grIzlazniVozovi" Then
            '    Dim Form2p As New FormGrid
            '    Form2p.ShowDialog()
            'Else
            '    Dim Form2p As New FormGrid
            '    Form2p.ShowDialog()
            'End If

        End If


    End Sub

    Private Sub btn165mRadinac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn165mRadinac.Click
        Dim FIzv As New FormK165
        Dim CRIzv As New Radinac_K165m ' K165m
        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "WinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String 'parametar koji se odnosi na vrstu saobracaja
        Dim param2 As String 'parametar koji se odnosi na ulaznu stanicu
        Dim param3 As Date   'parametar koji se odnosi na datum izlaza
        Dim param4 As Int32    'parametar koji se odnosi na blagajnu

        param1 = "2"
        param2 = "72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)
        param3 = DatumIzvestaja.Value
        param4 = mRBB

        FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.PrStanica}=('72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "2" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')  AND {SlogKalk.PrRbb}=(" & mRBB & ") "
        'FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.OtpStanica}=('72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "3" & "') and {SlogKalk.OtpDatum}= date('" & DatumIzvestaja.Text & "') AND {SlogKalk.OtpRbb}=(" & mRBB & ") "

        CRIzv.SetParameterValue(0, param1)
        CRIzv.SetParameterValue(1, param2)
        CRIzv.SetParameterValue(2, param3)
        CRIzv.SetParameterValue(3, param4)

        FIzv.Show()

        ''If Stampa = "k165mRadinac" Then
        ''    Dim FIzv As New FormK165
        ''    Dim CRIzv As New Radinac_K165m ' K165m
        ''    FIzv.CrystalReportViewer1.ReportSource = CRIzv

        ''    Dim CRConec As New ConnectionInfo
        ''    CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        ''    CRConec.ServerName = "10.0.4.31"
        ''    CRConec.DatabaseName = "WinRoba"
        ''    CRConec.UserID = "Radnik"
        ''    CRConec.Password = "roba2006"

        ''    Dim param1 As String 'parametar koji se odnosi na vrstu saobracaja
        ''    Dim param2 As String 'parametar koji se odnosi na ulaznu stanicu
        ''    Dim param3 As Date   'parametar koji se odnosi na datum izlaza

        ''    param1 = "2"
        ''    param2 = "72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)
        ''    param3 = DatumIzvestaja.Value

        ''    FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.PrStanica}=('72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "2" & "') and {SlogKalk.PrDatum}= date('" & DatumIzvestaja.Text & "')"

        ''    CRIzv.SetParameterValue(0, param1)
        ''    CRIzv.SetParameterValue(1, param2)
        ''    CRIzv.SetParameterValue(2, param3)

        ''    FIzv.Show()
        ''Else
        ''    mMesec = Me.DatumIzvestaja.Value.Month.ToString
        ''    mDan = Me.DatumIzvestaja.Value.Day.ToString
        ''    mGodina = Me.DatumIzvestaja.Value.Year.ToString
        ''    Dim Form2p As New FormGrid
        ''    Form2p.ShowDialog()

        ''    'If Stampa = "grUlazniVozovi" Or Stampa = "grIzlazniVozovi" Then
        ''    '    Dim Form2p As New FormGrid
        ''    '    Form2p.ShowDialog()
        ''    'Else
        ''    '    Dim Form2p As New FormGrid
        ''    '    Form2p.ShowDialog()
        ''    'End If

        ''End If

    End Sub

    Private Sub btn140mRadinac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn140mRadinac.Click
        Dim FIzv As New FormK165
        Dim CRIzv As New Radinac_K140m ' K140m
        FIzv.CrystalReportViewer1.ReportSource = CRIzv

        Dim CRConec As New ConnectionInfo
        CRConec = FIzv.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        CRConec.ServerName = "10.0.4.31"
        CRConec.DatabaseName = "WinRoba"
        CRConec.UserID = "Radnik"
        CRConec.Password = "roba2006"

        Dim param1 As String 'parametar koji se odnosi na vrstu saobracaja
        Dim param2 As String 'parametar koji se odnosi na ulaznu stanicu
        Dim param3 As Date   'parametar koji se odnosi na datum izlaza
        Dim param4 As Int32    'parametar koji se odnosi na blagajnu

        param1 = "3"
        param2 = "72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)
        param3 = DatumIzvestaja.Value
        param4 = mRBB

        FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Stanica}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') AND {SlogKalk.OtpStanica}=('72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "3" & "') and {SlogKalk.OtpDatum}= date('" & DatumIzvestaja.Text & "') AND {SlogKalk.OtpRbb}=(" & mRBB & ") "
        'FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.OtpStanica}=('72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "3" & "') and {SlogKalk.OtpDatum}= date('" & DatumIzvestaja.Text & "') AND {SlogKalk.OtpRbb}=(" & mRBB & ") "

        CRIzv.SetParameterValue(0, param1)
        CRIzv.SetParameterValue(1, param2)
        CRIzv.SetParameterValue(2, param3)
        CRIzv.SetParameterValue(3, param4)

        FIzv.Show()
    End Sub
End Class
