Imports System.Data.SqlClient
Public Class FormR57
    Inherits System.Windows.Forms.Form
    'Dim r57_mUprava1 As String
    'Dim r57_mUprava2 As String
    Dim _ForNum As Int16 = 0
    Dim NizUic(57, 2) As String

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents rtb57a As System.Windows.Forms.ListBox
    Friend WithEvents rtb57c As System.Windows.Forms.ListBox
    Friend WithEvents cbR57 As System.Windows.Forms.ComboBox
    Friend WithEvents rtb57b As System.Windows.Forms.ListBox
    Friend WithEvents rtb57b2 As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormR57))
        Me.rtb57a = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.rtb57b = New System.Windows.Forms.ListBox
        Me.rtb57b2 = New System.Windows.Forms.ListBox
        Me.cbR57 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.rtb57c = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'rtb57a
        '
        Me.rtb57a.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtb57a.ItemHeight = 16
        Me.rtb57a.Location = New System.Drawing.Point(152, 104)
        Me.rtb57a.Name = "rtb57a"
        Me.rtb57a.Size = New System.Drawing.Size(120, 116)
        Me.rtb57a.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "start"
        '
        'rtb57b
        '
        Me.rtb57b.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtb57b.ItemHeight = 16
        Me.rtb57b.Location = New System.Drawing.Point(272, 104)
        Me.rtb57b.Name = "rtb57b"
        Me.rtb57b.Size = New System.Drawing.Size(131, 116)
        Me.rtb57b.TabIndex = 3
        '
        'rtb57b2
        '
        Me.rtb57b2.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.rtb57b2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtb57b2.ItemHeight = 16
        Me.rtb57b2.Location = New System.Drawing.Point(400, 104)
        Me.rtb57b2.Name = "rtb57b2"
        Me.rtb57b2.Size = New System.Drawing.Size(139, 116)
        Me.rtb57b2.TabIndex = 5
        '
        'cbR57
        '
        Me.cbR57.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.cbR57.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbR57.Location = New System.Drawing.Point(152, 220)
        Me.cbR57.Name = "cbR57"
        Me.cbR57.Size = New System.Drawing.Size(392, 24)
        Me.cbR57.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(32, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Izlazni prelaz"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(32, 168)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 21)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Button2"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(105, 70)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(144, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(376, 23)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Granièni prelazi izmedju uprava na prevoznom putu"
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(368, 344)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 48)
        Me.btnOtkazi.TabIndex = 15
        Me.btnOtkazi.Text = "Izlaz"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'rtb57c
        '
        Me.rtb57c.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.rtb57c.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtb57c.ItemHeight = 16
        Me.rtb57c.Location = New System.Drawing.Point(539, 104)
        Me.rtb57c.Name = "rtb57c"
        Me.rtb57c.Size = New System.Drawing.Size(40, 116)
        Me.rtb57c.TabIndex = 16
        '
        'FormR57
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(616, 406)
        Me.Controls.Add(Me.rtb57c)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbR57)
        Me.Controls.Add(Me.rtb57b2)
        Me.Controls.Add(Me.rtb57b)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rtb57a)
        Me.Name = "FormR57"
        Me.Text = "Rubrika 57 CIM - Ostali prevoznici"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FormR57_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'popunjava R57a
        PopuniR57()

        'dodeli odgovarajuci prelaz za susednu upravu
        Dim r57_Object As Object
        r57_Object = m_UicPrevozniPut

        'popuniti ListBox1
        'Me.ListBox1.Items.Add(r57_Object)

        _ForNum = 0
        Me.rtb57b.Items.Add("550711")

        If rtb57a.Items.Count > 1 Then
            r57_mUprava1 = Me.rtb57a.Items.Item(_ForNum)
            r57_mUprava2 = Me.rtb57a.Items.Item(_ForNum + 1)
            cbR57_Validating(Me, Nothing)
            Me.cbR57.DroppedDown = True
        Else
            Me.rtb57b2.Items.Add("55100170")
        End If
    End Sub
    Private Sub cbR57_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbR57.Leave

        Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))
        Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))

        _ForNum = _ForNum + 1

        If _ForNum < Me.rtb57a.Items.Count - 1 Then
            Me.cbR57.Enabled = True
            r57_mUprava1 = Me.rtb57a.Items.Item(_ForNum)
            r57_mUprava2 = Me.rtb57a.Items.Item(_ForNum + 1)
            'Else
            '    Me.ComboBox2.Enabled = False
        ElseIf _ForNum = Me.rtb57a.Items.Count - 1 Then
            Me.cbR57.Enabled = False
        End If

        'Button2.Focus()
    End Sub
    Private Sub cbR57_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbR57.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cbR57_Validating(Me, Nothing)
    End Sub
    Private Sub cbR57_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbR57.GotFocus
        Me.cbR57.DroppedDown = True

    End Sub

    Private Sub cbR57_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbR57.Validating
        Dim daPrevPut As SqlClient.SqlDataAdapter
        Dim dsPrevPut As New Data.DataSet
        Dim pomSifraPP As String
        Dim upit As String = ""
        Dim objComm As SqlClient.SqlCommand

        If _ForNum < Me.rtb57a.Items.Count - 1 Then
            upit = ""
        End If

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        '---------------
        Dim ii As Int32 = 0

        cbR57.Items.Clear()
        dsPrevPut.Clear()

        upit = "SELECT SifraPrelaza, Naziv " _
             & "FROM UicPrelazi " _
             & "WHERE Uprava1 = '" & Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & "' AND Uprava2 = '" & Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & "' AND LEFT(SifraPrelaza, 1) = '0'"

        Try
            objComm = New SqlClient.SqlCommand(upit, DbVeza)
            daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)
            ii = daPrevPut.Fill(dsPrevPut)
            For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
                Me.cbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
            Next

        Catch ex As Exception
            MsgBox("Nema podataka!")
        Finally
            DbVeza.Close()
            Me.cbR57.Focus()
        End Try
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub
    Private Sub PopuniR57()

        Dim ki, kj As Int16
        Dim i_Pronasao As Int16 = 0
        Dim mUprava123 As String = "81"
        Dim mNizUic As String

        Me.rtb57a.Items.Clear()

        InitNizUic()

        mNizUic = m_UicPrevozniPut
        mNizUic = Microsoft.VisualBasic.Trim(mNizUic)

        For kj = 1 To Len(mNizUic) Step 4
            For ki = 0 To 56
                If Microsoft.VisualBasic.Right(NizUic(ki, 0), 2) = Microsoft.VisualBasic.Mid(mNizUic, kj, 2) Then
                    i_Pronasao = 1
                    Me.rtb57a.Items.Add(NizUic(ki, 0) & " - " & NizUic(ki, 1))
                    Me.rtb57c.Items.Add("1")

                    Exit For
                End If
            Next
        Next

    End Sub
    Private Sub InitNizUic()

        NizUic(0, 0) = "0010"
        NizUic(0, 1) = "VR         "
        NizUic(1, 0) = "2120"
        NizUic(1, 1) = "RZD        "
        NizUic(2, 0) = "0021"
        NizUic(2, 1) = "BC         "
        NizUic(3, 0) = "0022"
        NizUic(3, 1) = "UZ         "
        NizUic(4, 0) = "0023"
        NizUic(4, 1) = "CFM        "
        NizUic(5, 0) = "0024"
        NizUic(5, 1) = "LG         "
        NizUic(6, 0) = "0025"
        NizUic(6, 1) = "LDZ        "
        NizUic(7, 0) = "0026"
        NizUic(7, 1) = "EVR        "
        NizUic(8, 0) = "0027"
        NizUic(8, 1) = "KTZ        "
        NizUic(9, 0) = "0028"
        NizUic(9, 1) = "GR         "
        NizUic(10, 0) = "0029"
        NizUic(10, 1) = "UTI        "
        NizUic(11, 0) = "0041"
        NizUic(11, 1) = "HSH        "
        NizUic(12, 0) = "0044"
        NizUic(12, 1) = "ZRS        "
        NizUic(13, 0) = "0050"
        NizUic(13, 1) = "ZFBH       "
        NizUic(14, 0) = "2151"
        NizUic(14, 1) = "PKP CARGO  "
        NizUic(15, 0) = "2152"
        NizUic(15, 1) = "BDZ        "
        NizUic(16, 0) = "2153"
        NizUic(16, 1) = "CFR Marfa  "
        NizUic(17, 0) = "2154"
        NizUic(17, 1) = "CD Cargo   "
        NizUic(18, 0) = "2155"
        NizUic(18, 1) = "MAV Cargo  "
        NizUic(19, 0) = "2156"
        NizUic(19, 1) = "ZSSK Cargo "
        NizUic(20, 0) = "0057"
        NizUic(20, 1) = "AZ         "
        NizUic(21, 0) = "0058"
        NizUic(21, 1) = "ARM        "
        NizUic(22, 0) = "0059"
        NizUic(22, 1) = "KRG        "
        NizUic(23, 0) = "0060"
        NizUic(23, 1) = "CIE        "
        NizUic(24, 0) = "0062"
        NizUic(24, 1) = "ZCG        "
        NizUic(25, 0) = "0065"
        NizUic(25, 1) = "CFARYM     "
        NizUic(26, 0) = "0066"
        NizUic(26, 1) = "TDZ        "
        NizUic(27, 0) = "0067"
        NizUic(27, 1) = "TRK        "
        NizUic(28, 0) = "0068"
        NizUic(28, 1) = "AAE        "
        NizUic(29, 0) = "2370"
        NizUic(29, 1) = "UK-F       "
        NizUic(30, 0) = "1071"
        NizUic(30, 1) = "Renfe      "
        NizUic(31, 0) = "0072"
        NizUic(31, 1) = "ZS         "
        NizUic(32, 0) = "0073"
        NizUic(32, 1) = "OSE        "
        NizUic(33, 0) = "2174"
        NizUic(33, 1) = "Green Cargo"
        NizUic(34, 0) = "0075"
        NizUic(34, 1) = "TCDD       "
        NizUic(35, 0) = "2176"
        NizUic(35, 1) = "CargoNET AS"
        NizUic(36, 0) = "2178"
        NizUic(36, 1) = "HZ Cargo   "
        NizUic(37, 0) = "0079"
        NizUic(37, 1) = "SZ         "
        NizUic(38, 0) = "2180"
        NizUic(38, 1) = "Railion Deu"
        NizUic(39, 0) = "2181"
        NizUic(39, 1) = "RCA        "
        NizUic(40, 0) = "2182"
        NizUic(40, 1) = "ELC        "
        NizUic(41, 0) = "0083"
        NizUic(41, 1) = "FS         "
        NizUic(42, 0) = "2184"
        NizUic(42, 1) = "Railion Ned"
        NizUic(43, 0) = "2185"
        NizUic(43, 1) = "SBB Cargo  "
        NizUic(44, 0) = "2186"
        NizUic(44, 1) = "Railion Den"
        NizUic(45, 0) = "0087"
        NizUic(45, 1) = "SNCF       "
        NizUic(46, 0) = "0088"
        NizUic(46, 1) = "SNCB       "
        NizUic(47, 0) = "0090"
        NizUic(47, 1) = "ENR        "
        NizUic(48, 0) = "0091"
        NizUic(48, 1) = "SNCFT      "
        NizUic(49, 0) = "0092"
        NizUic(49, 1) = "SNTF       "
        NizUic(50, 0) = "0093"
        NizUic(50, 1) = "ONCFM      "
        NizUic(51, 0) = "0094"
        NizUic(51, 1) = "CP         "
        NizUic(52, 0) = "0095"
        NizUic(52, 1) = "IR         "
        NizUic(53, 0) = "0096"
        NizUic(53, 1) = "RAI        "
        NizUic(54, 0) = "0097"
        NizUic(54, 1) = "CFS        "
        NizUic(55, 0) = "0098"
        NizUic(55, 1) = "CEL        "
        NizUic(56, 0) = "0099"
        NizUic(56, 1) = "IRR        "

    End Sub

End Class
