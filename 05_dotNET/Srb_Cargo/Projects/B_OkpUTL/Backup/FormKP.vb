Imports System.Data.SqlClient
Public Class KontrolPrim
    Inherits System.Windows.Forms.Form
    Public Const ConnectionString As String = _
        "Server=10.0.4.31;DataBase=OkpWinRoba;User=Radnik;Password=roba2006"

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txtK211 As System.Windows.Forms.TextBox
    Friend WithEvents txtStavka As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSifraKP As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtK211 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.txtStavka = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSifraKP = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtK211
        '
        Me.txtK211.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtK211.Location = New System.Drawing.Point(144, 16)
        Me.txtK211.Name = "txtK211"
        Me.txtK211.Size = New System.Drawing.Size(80, 22)
        Me.txtK211.TabIndex = 1
        Me.txtK211.Text = ""
        Me.txtK211.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(256, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Stavka:"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Naziv (srpski):"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Naziv (nemacki):"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Rubrika CIM:"
        Me.Label5.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(144, 128)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(520, 22)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = ""
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(144, 168)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(520, 22)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = ""
        Me.TextBox3.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(144, 208)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(40, 22)
        Me.TextBox4.TabIndex = 4
        Me.TextBox4.Text = ""
        Me.TextBox4.Visible = False
        '
        'txtStavka
        '
        Me.txtStavka.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.txtStavka.Location = New System.Drawing.Point(344, 64)
        Me.txtStavka.Name = "txtStavka"
        Me.txtStavka.Size = New System.Drawing.Size(72, 22)
        Me.txtStavka.TabIndex = 9
        Me.txtStavka.Text = ""
        Me.txtStavka.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(408, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 56)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Upis u bazu"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Location = New System.Drawing.Point(544, 240)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 56)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Kraj rada"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Šifra kont. pr. :"
        '
        'lblSifraKP
        '
        Me.lblSifraKP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblSifraKP.Location = New System.Drawing.Point(136, 64)
        Me.lblSifraKP.Name = "lblSifraKP"
        Me.lblSifraKP.Size = New System.Drawing.Size(112, 24)
        Me.lblSifraKP.TabIndex = 12
        '
        'KontrolPrim
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(696, 326)
        Me.Controls.Add(Me.lblSifraKP)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtStavka)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtK211)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "KontrolPrim"
        Me.Text = "FormKP"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub KontrolPrim_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intCounter1 As Integer
        Dim str1SQL As String
        Dim objCommand1 As SqlClient.SqlCommand
        Dim objDAA As SqlClient.SqlDataAdapter
        Dim objDSS As New Data.DataSet
        Dim pomSifra As String
        Dim pomStavka As Int32


        If txtK211.Text = "" Then
            str1SQL = "SELECT * FROM ZsKontrolnePrimedbe "

            objCommand1 = New SqlClient.SqlCommand(str1SQL, New SqlClient.SqlConnection(ConnectionString))
            objCommand1.Connection.Open()
            objDAA = New SqlClient.SqlDataAdapter(str1SQL, ConnectionString)
            objDAA.Fill(objDSS)

            With objDSS.Tables(0)
                For intCounter1 = 0 To .Rows.Count - 1
                    pomSifra = .Rows(intCounter1).Item("SifraK211")
                    pomStavka = .Rows(intCounter1).Item("Stavka")
                    pomSrp = .Rows(intCounter1).Item("NazivSrpski")

                Next
            End With
            'pomSifra = 99
            pomSifra = pomSifra + 1
            txtK211.Text = pomSifra
            lblSifraKP.Text = txtK211.Text
            txtStavka.Text = 1
            txtK211.Enabled = True
            txtStavka.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim slogTrans As SqlTransaction
        Dim SifraK211 As Int32 = 0 ' String
        Dim Stavka As Int32
        Dim NazivSrpski As String
        Dim NazivNemacki As String
        Dim RubrikaCIM As String
        Dim VrstaSaobr As String
        Dim rv As String

        Try
            'Cursor.Current = New Cursor("MyWait.cur")

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            slogTrans = OkpDbVeza.BeginTransaction()

            SifraK211 = txtK211.Text
            'Stavka = txtStavka.Text
            Stavka = 1
            NazivSrpski = TextBox2.Text
            'NazivNemacki = TextBox3.Text
            NazivNemacki = ""
            'RubrikaCIM = TextBox4.Text
            RubrikaCIM = ""
            VrstaSaobr = "1"

            Upis.UpisK211(slogTrans, SifraK211, Stavka, NazivSrpski, NazivNemacki, RubrikaCIM, VrstaSaobr, rv)

            If rv <> "" Then Throw New Exception(rv)

            If rv = "" Then
                slogTrans.Commit()
            Else
                MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                slogTrans.Rollback()
            End If

        Catch ex As Exception
            rv = ex.Message
            MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch sqlex As SqlException
            MsgBox(sqlex.Message)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
            OkpDbVeza.Close()
            Close()

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
    Private Sub txtK211_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtK211.Validating

        Dim intCounter2 As Integer
        Dim str1SQL1 As String
        Dim objCommand2 As SqlClient.SqlCommand
        Dim objDAA1 As SqlClient.SqlDataAdapter
        Dim objDSS1 As New Data.DataSet
        Dim pomSifra As Int32 ' String
        Dim pomStavka As Int32

        mSifraK211 = txtK211.Text

        If txtK211.Text = mSifraK211 Then
            str1SQL1 = "SELECT * FROM ZsKontrolnePrimedbe " _
                    & " WHERE (SifraK211 = " & CType(txtK211.Text, Int32) & ")"
            ''str1SQL1 = "SELECT * FROM ZsKontrolnePrimedbe " _
            ''        & " WHERE (SifraK211 = '" & mSifraK211 & "')"

            objCommand2 = New SqlClient.SqlCommand(str1SQL1, New SqlClient.SqlConnection(ConnectionString))
            objCommand2.Connection.Open()
            objDAA1 = New SqlClient.SqlDataAdapter(str1SQL1, ConnectionString)
            objDAA1.Fill(objDSS1)

            With objDSS1.Tables(0)
                For intCounter2 = 0 To .Rows.Count - 1
                    pomSifra = .Rows(intCounter2).Item("SifraK211")
                    pomStavka = .Rows(intCounter2).Item("Stavka")
                    pomSrp = .Rows(intCounter2).Item("NazivSrpski")

                Next
            End With
            If pomSifra = 0 Then
                Me.TextBox2.Text = ""
                Me.TextBox3.Text = ""
                'Me.txtK211.Focus()
            Else
                mSifraK211 = txtK211.Text
                TextBox2.Text = pomSrp
            End If

            'TextBox2.Text = pomSrp
        End If
    End Sub

    Private Sub txtK211_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtK211.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

End Class
