Imports System.Data.SqlClient
Public Class MakisNaknade
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents tbNajava As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnUpisUBazu As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MakisNaknade))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.tbNajava = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnUpisUBazu = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbUgovor)
        Me.GroupBox1.Controls.Add(Me.tbNajava)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(24, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 176)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Izaberite najavu i kola ]  "
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(152, 112)
        Me.TextBox1.MaxLength = 12
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(152, 23)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Broj kola"
        '
        'tbUgovor
        '
        Me.tbUgovor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(152, 72)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(152, 23)
        Me.tbUgovor.TabIndex = 1
        Me.tbUgovor.Text = "101101"
        '
        'tbNajava
        '
        Me.tbNajava.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNajava.Location = New System.Drawing.Point(152, 32)
        Me.tbNajava.MaxLength = 10
        Me.tbNajava.Name = "tbNajava"
        Me.tbNajava.Size = New System.Drawing.Size(152, 23)
        Me.tbNajava.TabIndex = 0
        Me.tbNajava.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 16)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Broj ugovora"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Broj najave"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(328, 109)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(336, 400)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(81, 77)
        Me.btnOtkazi.TabIndex = 3
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(144, 400)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(81, 77)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Pronadji"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'btnUpisUBazu
        '
        Me.btnUpisUBazu.Enabled = False
        Me.btnUpisUBazu.Image = CType(resources.GetObject("btnUpisUBazu.Image"), System.Drawing.Image)
        Me.btnUpisUBazu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpisUBazu.Location = New System.Drawing.Point(240, 400)
        Me.btnUpisUBazu.Name = "btnUpisUBazu"
        Me.btnUpisUBazu.Size = New System.Drawing.Size(81, 77)
        Me.btnUpisUBazu.TabIndex = 2
        Me.btnUpisUBazu.Text = "Upis u bazu"
        Me.btnUpisUBazu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpisUBazu.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(264, 14)
        Me.TextBox2.MaxLength = 10
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(32, 23)
        Me.TextBox2.TabIndex = 10
        Me.TextBox2.Text = "18"
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(16, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Naknada za ranziranje po zahtevu speditera"
        '
        'Label6
        '
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(312, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "[ Eur ]"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 312)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(392, 48)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(272, 40)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Troskovi na ime operacija vezanih za formiranje vozova u stanici Beograd Ranzirna" & _
        ""
        '
        'MakisNaknade
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(442, 504)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnUpisUBazu)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MakisNaknade"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Izmena broja otpravljanja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim mRetVal As String

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim sql_text1 As String = "SELECT SlogKalk.RecID, SlogKalk.Stanica, SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj, SlogKalk.OtpDatum " & _
                                  "FROM SlogKalk INNER JOIN " & _
                                  "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica " & _
                                  "WHERE (SlogKalk.Najava2 = '" & tbNajava.Text & "') AND (SlogKalk.Ugovor = '" & tbUgovor.Text & "') AND (SlogKola.IBK = '" & TextBox1.Text & "')"

        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrRm.Read()

            UpdRecID = rdrRm.GetInt32(0)
            UpdStanicaRecID = rdrRm.GetString(1)
            mOtpUprava = rdrRm.GetString(2)
            mOtpStanica = rdrRm.GetString(3)
            mOtpBroj = rdrRm.GetInt32(4)
            mOtpDatum = rdrRm.GetDateTime(5)

        Loop

        If UpdRecID = 0 Then
            MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.PictureBox2.Visible = False
            btnUpisUBazu.Visible = False
            Me.tbNajava.Focus()
        Else
            Me.PictureBox2.Visible = True
            btnUpisUBazu.Visible = True
            btnUpisUBazu.Enabled = True
            OkpDbVeza.Close()

            Me.btnUpisUBazu.Focus()
        End If

    End Sub

    Private Sub DatumOtp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Button3.Focus()

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub OtpIzmena_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbNajava.Text = ""
        tbUgovor.Text = ""
        TextBox1.Text = ""

    End Sub

    Private Sub tbNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Me.Button3.Focus()

    End Sub

    Private Sub btnUpisUBazu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpisUBazu.Click

        Dim slogTrans As SqlTransaction
        Dim rv As String

        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            slogTrans = OkpDbVeza.BeginTransaction()

            mAkcija = "New"

            Upis.UpisSlogNaknadaUI(slogTrans, mAkcija, UpdRecID, UpdStanicaRecID, mOtpUprava, mOtpStanica, mOtpBroj, mOtpDatum, _
                                   1, "91", "0", 16, "17", 1, 0, "9", "C", rv)

        Catch ex As Exception
            MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If rv = "" Then
            slogTrans.Commit()
        Else
            If Microsoft.VisualBasic.Left(rv, 20) = "Violation of PRIMARY" Then
                MessageBox.Show("Takav podatak je vec unet!", "Poruka iz baze - greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(rv, "Poruka iz baze - greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            slogTrans.Rollback()
        End If

        OkpDbVeza.Close()

        Me.PictureBox2.Visible = False
        btnUpisUBazu.Visible = False

        Me.TextBox1.Focus()
    End Sub

   
End Class
