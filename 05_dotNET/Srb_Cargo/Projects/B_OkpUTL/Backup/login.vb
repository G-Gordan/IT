Imports System.IO
Imports System.Threading
Public Class login
    Inherits System.Windows.Forms.Form
    Private _Ping As String
    Private MachineName As String = "10.0.4.31"
    Dim psi As ProcessStartInfo
    Public ReadOnly Property Ping() As String
        Get
            _Ping = Pinger()
            Return _Ping
        End Get
    End Property
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(216, 24)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(80, 23)
        Me.lblUser.TabIndex = 0
        Me.lblUser.Text = "Korisnicko ime"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbUser
        '
        Me.tbUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUser.Location = New System.Drawing.Point(312, 24)
        Me.tbUser.MaxLength = 4
        Me.tbUser.Name = "tbUser"
        Me.tbUser.TabIndex = 0
        Me.tbUser.Text = ""
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(232, 160)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(77, 56)
        Me.btnPrihvati.TabIndex = 2
        Me.btnPrihvati.Text = "Prihvati"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPass
        '
        Me.lblPass.Location = New System.Drawing.Point(216, 80)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(72, 23)
        Me.lblPass.TabIndex = 3
        Me.lblPass.Text = "Lozinka"
        Me.lblPass.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbPass
        '
        Me.tbPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPass.Location = New System.Drawing.Point(312, 80)
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
        Me.btnOtkazi.Location = New System.Drawing.Point(336, 160)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(80, 56)
        Me.btnOtkazi.TabIndex = 3
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Pristup nije dozvoljen!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(9, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(191, 144)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(16, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(191, 18)
        Me.Label2.TabIndex = 10
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 231)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(422, 25)
        Me.Panel1.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(191, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'login
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(422, 256)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.tbPass)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.tbUser)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prijavljivanje na sistem - Kontrola Prihoda UTL"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim xNaziv As String = ""
        'Dim xGrupa As String = ""
        Dim xPovVrednost As String = ""

        '''Util.sNadjiNaziv("UserTab", tbUser.Text, tbPass.Text, "", 1, xNaziv, xPovVrednost)
        'Util.Lozinka(tbUser.Text, tbPass.Text, "", 1, xNaziv, xPovVrednost)
        Util.Lozinka2(tbUser.Text, tbPass.Text, "", 1, xNaziv, bUserIDGrupa, xPovVrednost)

        If xPovVrednost <> "" Then
            Label1.Visible = True
            Me.PictureBox2.Visible = True
            tbUser.Focus()

        Else
            Label1.Visible = False
            Me.PictureBox2.Visible = False
            If Microsoft.VisualBasic.Left(bUserIDGrupa, 5) = "Admin" Then
                bAdmin = True
            Else
                bAdmin = False
            End If
            If xNaziv = "un77" Then
                bAdmin77 = True
            Else
                bAdmin77 = False
            End If
            mUserID = tbUser.Text
            Dim form2s As New Form1
            form2s.Text = "Kontrola Prihoda - unutrasnji saobracaj" 'Microsoft.VisualBasic.Right(StanicaUnosa, Len(StanicaUnosa) - 10)
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

        Dim returnedValue As String = Pinger()
        Dim opPovVrednost As String = ""

        Try
            sUcitajINI(opPovVrednost)
            'sUcitajINIHCD(opPovVrednost)
            'sUcitajINIHCDLokalSQL(opPovVrednost)
            If opPovVrednost = "" Then
                Dim mStatus As String = Microsoft.VisualBasic.Mid(SQL_CONNECTION_STRING, 9, 5)
                If mStatus = "local" Then
                    Label2.Text = "Lokalni server : " & RTrim(returnedValue)
                Else
                    Label2.Text = "Glavni server : " & RTrim(returnedValue)
                End If
                Label3.Text = RTrim(Microsoft.VisualBasic.Mid(StanicaUnosa, 11, 12))
            Else
                MsgBox(opPovVrednost, MsgBoxStyle.Critical, "Greška")
            End If
        Catch
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Greška")
        End Try

    End Sub
    Private Function Pinger() As String
        Try
            psi = New ProcessStartInfo("ping.exe", " -n 1 -w 1000 " & MachineName)
            'psi = New ProcessStartInfo("ping.exe", " -n 1 -w 1000 " & MachineName)
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = True

            Dim pExec As New Process
            pExec = Process.Start(psi)
            Dim output As StreamReader = pExec.StandardOutput
            pExec.WaitForExit()

            If pExec.HasExited Then
                Dim line As String
                line = LCase(output.ReadToEnd())

                If InStr(LCase(line), "reply") > 0 = True Then
                    Return " Online!"
                ElseIf InStr(LCase(line), "host") > 0 = True Then
                    Return " Nepoznata adresa"
                ElseIf InStr(LCase(line), "timed") > 0 = True Then
                    Return " Veza u prekidu"
                End If

            End If

            output.Close()
            pExec.Close()
            psi = Nothing
            pExec = Nothing
            output = Nothing

        Catch
            Return Err.Description
        End Try
    End Function

End Class
