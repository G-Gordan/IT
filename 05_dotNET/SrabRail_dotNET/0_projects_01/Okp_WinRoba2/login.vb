Public Class login
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
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents tbUser As System.Windows.Forms.TextBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents tbPass As System.Windows.Forms.TextBox
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(login))
        Me.lblUser = New System.Windows.Forms.Label
        Me.tbUser = New System.Windows.Forms.TextBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.lblPass = New System.Windows.Forms.Label
        Me.tbPass = New System.Windows.Forms.TextBox
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.SuspendLayout()
        '
        'lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(183, 42)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(80, 23)
        Me.lblUser.TabIndex = 0
        Me.lblUser.Text = "Korisnicko ime"
        '
        'tbUser
        '
        Me.tbUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUser.Location = New System.Drawing.Point(280, 40)
        Me.tbUser.MaxLength = 4
        Me.tbUser.Name = "tbUser"
        Me.tbUser.TabIndex = 0
        Me.tbUser.Text = ""
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(179, 198)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 56)
        Me.btnPrihvati.TabIndex = 2
        Me.btnPrihvati.Text = "Prihvati"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPass
        '
        Me.lblPass.Location = New System.Drawing.Point(184, 94)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(72, 23)
        Me.lblPass.TabIndex = 3
        Me.lblPass.Text = "Lozinka"
        '
        'tbPass
        '
        Me.tbPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPass.Location = New System.Drawing.Point(280, 88)
        Me.tbPass.MaxLength = 6
        Me.tbPass.Name = "tbPass"
        Me.tbPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.tbPass.TabIndex = 1
        Me.tbPass.Text = ""
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(296, 198)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 56)
        Me.btnOtkazi.TabIndex = 3
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(18, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 48)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Pristup nije dozvoljen!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(148, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(67, 151)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar1.Location = New System.Drawing.Point(0, 270)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(432, 16)
        Me.StatusBar1.TabIndex = 9
        Me.StatusBar1.Text = "StatusBar1"
        '
        'login
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 286)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.tbPass)
        Me.Controls.Add(Me.tbUser)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.lblUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prijavljivanje na sistem"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""
        Util.Lozinka(tbUser.Text, tbPass.Text, "", 1, xNaziv, xPovVrednost)

        If xPovVrednost <> "" Then
            Label1.Visible = True
            Me.PictureBox2.Visible = True
            tbUser.Focus()
        Else
            Label1.Visible = False
            Me.PictureBox2.Visible = False
            mUserID = tbUser.Text

            Dim form2s As New Form1
            form2s.Text = Microsoft.VisualBasic.Mid(StanicaUnosa, 11, 25)
            form2s.ShowDialog()

            Close()

        End If
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub tbUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUser.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPass.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim opPovVrednost As String = ""
        'Microsoft.VisualBasic.Mid(SQL_CONNECTION_STRING, 1, 20) & " ..."
        Try
            sUcitajINI(opPovVrednost)
            If opPovVrednost = "" Then
                StatusBar1.Text = "  ID=" & Microsoft.VisualBasic.Mid(StanicaUnosa, 11, 12)
                'StatusBar1.Text = Microsoft.VisualBasic.Mid(SQL_CONNECTION_STRING, 1, 8) & " ;  ID=" & Microsoft.VisualBasic.Mid(StanicaUnosa, 11, 12)
                'StatusBar1.Text = Microsoft.VisualBasic.Mid(SQL_CONNECTION_STRING, 1, 16) & " ;  ID=" & Microsoft.VisualBasic.Mid(StanicaUnosa, 11, 12)
            Else
                MsgBox(opPovVrednost, MsgBoxStyle.Critical, "Greška")
            End If
        Catch
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Greška")
        End Try

    End Sub
End Class
