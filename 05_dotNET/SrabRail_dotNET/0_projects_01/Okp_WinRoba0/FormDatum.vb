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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DatumIzvestaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn165 As System.Windows.Forms.Button
    Friend WithEvents btn140 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents cbSmer1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormDatum))
        Me.DatumIzvestaja = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn140 = New System.Windows.Forms.Button
        Me.btn165 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.cbSmer1 = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DatumIzvestaja
        '
        Me.DatumIzvestaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumIzvestaja.Location = New System.Drawing.Point(73, 107)
        Me.DatumIzvestaja.Name = "DatumIzvestaja"
        Me.DatumIzvestaja.Size = New System.Drawing.Size(240, 23)
        Me.DatumIzvestaja.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(121, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Izaberite datum za koji se pravi izvestaj"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn140
        '
        Me.btn140.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btn140.Image = CType(resources.GetObject("btn140.Image"), System.Drawing.Image)
        Me.btn140.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn140.Location = New System.Drawing.Point(264, 264)
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
        Me.btn165.Location = New System.Drawing.Point(264, 264)
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
        Me.PictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(376, 264)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 5
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbSmer1
        '
        Me.cbSmer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer1.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna"})
        Me.cbSmer1.Location = New System.Drawing.Point(72, 42)
        Me.cbSmer1.Name = "cbSmer1"
        Me.cbSmer1.Size = New System.Drawing.Size(240, 24)
        Me.cbSmer1.TabIndex = 46
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(232, 26)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(80, 13)
        Me.Label33.TabIndex = 47
        Me.Label33.Text = "Granicni prelaz"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DatumIzvestaja)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.cbSmer1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(96, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 160)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Parametri izvestaja] "
        '
        'FormDatum
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 342)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn165)
        Me.Controls.Add(Me.btn140)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDatum"
        Me.Text = "Izvestaj"
        Me.GroupBox1.ResumeLayout(False)
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

        StanicaUnosa = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)

        param1 = "4"
        param2 = Microsoft.VisualBasic.Right(cbSmer1.Text, (cbSmer1.Text.Length) - 4)
        param3 = DatumIzvestaja.Value

        FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5) & "') and {SlogKalk.IzEtiketa} > 0 and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.DatumIzlaza}= date('" & DatumIzvestaja.Text & "')"


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

        StanicaUnosa = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)

        param1 = "4"
        param2 = Microsoft.VisualBasic.Right(cbSmer1.Text, (cbSmer1.Text.Length) - 4)
        param3 = DatumIzvestaja.Value

        FIzv.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5) & "') and {SlogKalk.Saobracaj}=('" & "4" & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

        CRIzv.SetParameterValue(0, param1)
        CRIzv.SetParameterValue(1, param2)
        CRIzv.SetParameterValue(2, param3)

        FIzv.Show()

    End Sub

    Private Sub FormDatum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Stampa = "k140" Then
            btn140.Visible = True
            btn165.Visible = False
        Else
            btn140.Visible = False
            btn165.Visible = True
        End If
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub
End Class
