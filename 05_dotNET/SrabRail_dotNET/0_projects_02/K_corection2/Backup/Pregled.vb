Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Public Class Pregled
    Inherits System.Windows.Forms.Form
    Dim UpitP As String

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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents btIzmena As System.Windows.Forms.Button
    Friend WithEvents btBrisi As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.btIzmena = New System.Windows.Forms.Button
        Me.btBrisi = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(152, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(152, 80)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Unesi šifru stanice:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Unesi broj prispe:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(296, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Prikaži"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(0, 128)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(1040, 144)
        Me.DataGrid1.TabIndex = 4
        '
        'btIzmena
        '
        Me.btIzmena.Location = New System.Drawing.Point(648, 304)
        Me.btIzmena.Name = "btIzmena"
        Me.btIzmena.Size = New System.Drawing.Size(64, 32)
        Me.btIzmena.TabIndex = 5
        Me.btIzmena.Text = "Izmeni"
        '
        'btBrisi
        '
        Me.btBrisi.Location = New System.Drawing.Point(760, 304)
        Me.btBrisi.Name = "btBrisi"
        Me.btBrisi.Size = New System.Drawing.Size(56, 32)
        Me.btBrisi.TabIndex = 6
        Me.btBrisi.Text = "Obrisi"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(856, 304)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 32)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Otkaži"
        '
        'Pregled
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(952, 438)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btBrisi)
        Me.Controls.Add(Me.btIzmena)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Pregled"
        Me.Text = "Pregled"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim Nak As Decimal
    Dim TruGot As Decimal
    Dim Uk As Decimal
    Dim PovVrednost As String
    Dim M As Decimal
    Dim V As Decimal
    Dim PZORazl As Decimal
    Dim CPRazl As Decimal
    Dim Preduj As Decimal
    Dim Kor As String
    Dim Manjak As Decimal = 0
    Dim Visak As Decimal = 0
    Dim ManjakN As Decimal = 0
    Dim VisakN As Decimal = 0
    Dim BrPred As String
    Dim RedBr As String
    Dim dsPregled As New Data.DataSet

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim intCounterP As Integer
        Dim daPregled As SqlClient.SqlDataAdapter
        Dim objCommP As SqlClient.SqlCommand

        dsPregled.Clear()
        Dim ii1 As Int32 'Broj ucitanih slogova
        OtpStan = TextBox1.Text
        OtpBroj = TextBox2.Text
        UpitP = "select  Stanica, OtpBroj, BrPred, Visak, VisakN, RazlVisak, Manjak, ManjakN, RazlManj, PZO, CP, Naknade, TruGot, Pred, Uk FROM dbo.KorekcijaIzv " & _
                "where Korisnik = '" & User & "' and Stanica = '" & OtpStan & "' and OtpBroj = '" & OtpBroj & "'  "
        objCommP = New SqlClient.SqlCommand(UpitP, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        daPregled = New SqlClient.SqlDataAdapter(UpitP, OkpDbVeza)
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        Try
            ii1 = daPregled.Fill(dsPregled)

            With dsPregled.Tables(0)
                For intCounterP = 0 To .Rows.Count - 1
                    'PrStan = .Rows(intCounterP).Item("Stanica")
                    'PrBroj = .Rows(intCounterP).Item("PrBroj")
                    If TextBox1.Text = Trim(OtpStan) And TextBox2.Text = OtpBroj Then
                        DataGrid1.DataSource = dsPregled.Tables(0)
                        Exit For
                    End If
                Next
            End With

            If DataGrid1.DataSource Is Nothing Then
                MsgBox("Zadati paramatri ne odgovaraju podacima u bazi.")
            End If

        Catch ex As Exception
            MessageBox.Show("Baza nije otvorena!", "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        OkpDbVeza.Close()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        Button1.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PregledAddList.Clear()
        PregledRemoveList.Clear()
        Me.Close()
    End Sub

    Private Sub btBrisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrisi.Click

        Dim ManjakN As Decimal
        Dim Manjak As Decimal
        Dim VisakN As Decimal
        Dim Visak As Decimal
        Dim RedBR As Int16
        Dim BrPred As String
        Dim Stanica As String
        Dim BrKP As String

        Dim Nak As Decimal
        Dim TruGot As Decimal
        Dim Uk As Decimal
        Dim PovVrednost As String
        Dim M As Decimal
        Dim V As Decimal
        Dim PZORazl As Decimal
        Dim CPRazl As Decimal
        Dim Preduj As Decimal
        Dim Kor As String

        Korisnik = User
        Stanica = TextBox1.Text
        OtpBroj = TextBox2.Text
        BrPred = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
        If (BrPred = "    ") Then BrPred = "1"
        BrisiKorekcija1(Korisnik, RedBR, Stanica, OtpBroj, BrPred, Visak, VisakN, V, Manjak, ManjakN, M, PZORazl, CPRazl, Nak, TruGot, Preduj, Uk, PovVrednost)
        dsPregled.Clear()

    End Sub

    Private Sub btIzmena_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIzmena.Click
        Dim mStitna As String
        Dim row As Data.DataRow

        row = CType(DataGrid1.DataSource, DataTable).Rows(DataGrid1.CurrentCell.RowNumber)

        Stanica = TextBox1.Text
        OtpBroj = TextBox2.Text

        row("Stanica") = Stanica
        row("OtpBroj") = TextBox2.Text
        BrPred = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
        Visak = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)
        VisakN = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
        V = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5)
        Manjak = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6)
        ManjakN = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7)
        M = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7)
        PZORazl = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8)
        CPRazl = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 9)
        Nak = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 10)
        TruGot = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 11)
        Preduj = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 12)
        Uk = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 13)

        If RecID = TextBox1.Text Then
        Else : row = CType(DataGrid1.DataSource, DataTable).Rows(DataGrid1.CurrentCell.RowNumber)
        End If

        Stanica = TextBox1.Text
        OtpBroj = TextBox2.Text
        Korisnik = User
        RedBr = 1

        Dim UpdKorekcija As DataRow = UpdateKorekcija(Korisnik, RedBr, Stanica, OtpBroj, BrPred, Visak, VisakN, V, Manjak, ManjakN, M, PZORazl, CPRazl, Nak, TruGot, Preduj, Uk, PovVrednost)
        If PovVrednost = "" Then
            MessageBox.Show("Izmena je izvršena.")
        End If
        Me.Close()

    End Sub

End Class
