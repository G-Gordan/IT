Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection
Imports System.IO
Public Class Form1
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Železnicka uprava"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Broj transportnog ogranicenja ŽS"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Broj telegrama"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(288, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Od"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(296, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Broj transportnog ogranicenja železnicke uprave"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Razlog uvodjenja"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 23)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Usputne pošiljke"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Items.AddRange(New Object() {"00  - sve uprave", "10  - Finska", "20  - Rusija", "21  - Belorusija", "22  - Ukrajina", "23  - Moldavija", "24  - Litvanija", "25  - Letonija", "26  - Estonija", "27  - Kazahstan", "28  - Gruzija", "29  - Uzbekistan", "30  - S.Koreja", "31  - Mongolija", "32  - Vijetnam", "33  - Kina", "34  -" & Microsoft.VisualBasic.ChrW(9), "35  -", "36  -", "37  -", "39  -", "41  - Albanija", "42  - Japan", "43  - Madjarska", "0043 - GySEV", "44  - Republika Srpska", "45  -", "46  -", "47  -", "48  -", "49  -", "50  - Bosna i Hercegovina", "51  - Poljska", "52  - Bugarska", "53  - Rumunija", "54  - Ceska", "55  - Madjarska", "56  - Slovacka", "57  - Azerbeidzan", "58  - Jermenija", "59  - Kirgistan", "60  - Irska", "61  - Koreja", "62  - Crna Gora", "63  -", "64  - Nord-Milano", "65  - Makedonija", "66  - Tadzikistan", "67  - Turkmenistan", "68  - Ahaus-Alster", "69  -", "70  - Velika Britanija", "71  - Spanija", "72  - Srbija", "73  - Grcka", "74  - Svedska", "75  - Turska", "76  - Norveska", "77  -", "78  - Hrvatska", "79  - Slovenija", "80  - Nemacka", "81  - Austrija", "82  - Luksemburg", "83  - Italija", "84  - Holandija", "85  - Svajcarska", "86  - Danska", "87  - Francuska", "88  - Belgija", "90  - Egipat", "91  - Tunis", "92  - Alzir", "93  - Maroko", "94  - Portugal", "95  - Izrael", "96  - Irak", "97  - Sirija", "98  - Liban", "99  - Iran"})
        Me.ComboBox1.Location = New System.Drawing.Point(64, 64)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(528, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(256, 104)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(72, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(136, 144)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(120, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = ""
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(328, 184)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(120, 20)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.Text = ""
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Location = New System.Drawing.Point(56, 248)
        Me.ComboBox2.MaxDropDownItems = 12
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(544, 21)
        Me.ComboBox2.TabIndex = 6
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Items.AddRange(New Object() {"biæe prevezene", "zaustaviti i staviti imaocu prava na raspolaganje"})
        Me.ComboBox3.Location = New System.Drawing.Point(56, 312)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(544, 21)
        Me.ComboBox3.TabIndex = 7
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(56, 352)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(720, 192)
        Me.RichTextBox1.TabIndex = 8
        Me.RichTextBox1.Text = ""
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(56, 560)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 23)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Važi od "
        '
        'CheckBox1
        '
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(56, 584)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.TabIndex = 10
        Me.CheckBox1.Text = "Do opoziva"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label9.Location = New System.Drawing.Point(56, 616)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 23)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Važi do"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(488, 592)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Upiši u bazu"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(624, 592)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 32)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Otkaži"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker1.Location = New System.Drawing.Point(328, 144)
        Me.DateTimePicker1.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker1.MinDate = New Date(1996, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(120, 20)
        Me.DateTimePicker1.TabIndex = 4
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(160, 560)
        Me.DateTimePicker2.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker2.MinDate = New Date(1996, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker2.TabIndex = 9
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker3.Location = New System.Drawing.Point(160, 616)
        Me.DateTimePicker3.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker3.MinDate = New Date(1996, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker3.TabIndex = 11
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(352, 104)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(96, 20)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(328, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 23)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "  /"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem3})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        Me.MenuItem1.Text = "Izmena"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Izmena TO"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4})
        Me.MenuItem3.Text = "Brisanje"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 0
        Me.MenuItem4.Text = "Obriši"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(952, 665)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DateTimePicker3)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transportna ogranicenja"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        Dim intCounter2 As Integer
        Dim str2SQL As String
        Dim objCommand2 As SqlClient.SqlCommand
        Dim objDAA2 As SqlClient.SqlDataAdapter
        Dim objDSS2 As New Data.DataSet
        Dim UspPos As String
        ComboBox3.Items.Clear()

        str2SQL = "SELECT UsputnePosiljke FROM  UspPos "

        objCommand2 = New SqlClient.SqlCommand(str2SQL, WebVeza)
        objCommand2.Connection.Open()
        objDAA2 = New SqlClient.SqlDataAdapter(str2SQL, WebVeza)
        objDAA2.Fill(objDSS2)

        Dim combo_linija1 As String = ""

        With objDSS2.Tables(0)
            For intCounter2 = 0 To .Rows.Count - 1
                UspPos = .Rows(intCounter2).Item("UsputnePosiljke")
                combo_linija1 = UspPos
                ComboBox3.Text = combo_linija1
                ComboBox3.Items.Add(combo_linija1)
            Next
        End With
        objCommand2.Connection.Close()
        ComboBox3.DroppedDown = True
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
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

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.Leave
        Dim intCounter1 As Integer
        Dim str1SQL As String
        Dim objCommand1 As SqlClient.SqlCommand
        Dim objDAA As SqlClient.SqlDataAdapter
        Dim objDSS As New Data.DataSet
        Dim RazOgr As String

        ComboBox2.Items.Clear()

        str1SQL = "SELECT RazlogOgranicenja FROM  RazlOgr "

        objCommand1 = New SqlClient.SqlCommand(str1SQL, WebVeza)
        objCommand1.Connection.Open()
        objDAA = New SqlClient.SqlDataAdapter(str1SQL, WebVeza)
        objDAA.Fill(objDSS)

        Dim combo_linija1 As String = ""
        With objDSS.Tables(0)
            For intCounter1 = 0 To .Rows.Count - 1
                RazOgr = .Rows(intCounter1).Item("RazlogOgranicenja")
                combo_linija1 = RazOgr
                ComboBox2.Text = combo_linija1
                ComboBox2.Items.Add(combo_linija1)
            Next
        End With
        objCommand1.Connection.Close()
        ComboBox2.DroppedDown = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim slogTrans As SqlTransaction
        Dim rv As String

        If CheckBox1.Checked = True Then
            DoOpoziva = "D"
        Else : DoOpoziva = "N"
        End If

        broj1 = TextBox1.Text & "" & TextBox3.Text
        broj = TextBox1.Text & "/" & TextBox3.Text
        Uprava = Microsoft.VisualBasic.Left(ComboBox1.Text, 4)
        BrTrOgrZS = broj
        BrTel = TextBox2.Text
        TelDat = DateTimePicker1.Text
        BrTrOgrUprave = TextBox4.Text
        Razlog = ComboBox2.Text
        UspPos = ComboBox3.Text
        VaziOd = DateTimePicker2.Text
        VaziDo = DateTimePicker3.Text
        NazivFile = broj1

        Try
            If WebVeza.State = ConnectionState.Closed Then
                WebVeza.Open()
            End If
            slogTrans = WebVeza.BeginTransaction()

            If TrOgrPostoji = "N" Then
                UpisOgr(slogTrans, "New", Uprava, BrTrOgrZS, BrTel, TelDat, BrTrOgrUprave, Razlog, UspPos, VaziOd, DoOpoziva, VaziDo, NazivFile, rv)
            Else
                makcija = "Upd"
                UpisOgr(slogTrans, "Upd", Uprava, BrTrOgrZS, BrTel, TelDat, BrTrOgrUprave, Razlog, UspPos, VaziOd, DoOpoziva, VaziDo, NazivFile, rv)
            End If
            If rv <> "" Then Throw New Exception(rv)

            If makcija = "Upd" Then
                System.IO.File.Delete(ToFile & "\" & broj1 & ".rtf")
                RichTextBox1.SaveFile(ClientPath & "" & broj1 & ".rtf")
                System.IO.File.Copy(ClientPath & "" & broj1 & ".rtf", ToFile & "\" & broj1 & ".rtf")
            Else

                '2.12.2011
                'GetFileSize(FromFile, mFileSize1)
                '2.12.2011
                Try
                    RichTextBox1.SaveFile(ClientPath & "" & broj1 & ".rtf")
                    'System.IO.File.Copy(ClientPath & "" & broj1 & ".rtf", ToFile & "\" & broj1 & ".rtf")
                    'System.IO.File.Copy(ClientPath & "" & broj1 & ".rtf", "z:" & broj1 & ".rtf")
                    System.IO.File.Copy(ClientPath & "" & broj1 & ".rtf", ToFile & "\" & broj1 & ".rtf")
                Catch ex As Exception
                    rv = "Greska"
                End Try
                If rv <> "" Then Throw New Exception(rv)

            End If

            Dim xRedniBroj As Int16 = 0

        Catch ex As Exception
            rv = ex.Message
        Catch sqlex As SqlException
            MsgBox(sqlex.Message)
        Finally
            If rv = "" Then
                slogTrans.Commit()
            Else
                slogTrans.Rollback()
            End If
            WebVeza.Close()

        End Try
        If rv <> "" Then
            MsgBox(rv, MsgBoxStyle.Exclamation, "Greška u upisu")
        Else
            MsgBox("Uspešan upis u bazu", MsgBoxStyle.Information, "Inserted")

        End If

        CheckBox1.Checked = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        DateTimePicker3.Text = ""
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        RichTextBox1.Text = ""
        ComboBox1.Focus()
        System.IO.File.Delete(ClientPath & "\" & broj1 & ".rtf")

    End Sub

    Private Sub CheckBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CheckBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        CheckBox1.Checked = True
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        DateTimePicker3.Text = ""
        'ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        RichTextBox1.Text = ""
        TextBox1.Focus()

    End Sub

    Private Sub DateTimePicker1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox3.Validating
        Dim sqlText As String = ""
        Dim BrojPom As String = ""
        Dim i As Integer
        broj = TextBox1.Text & "/" & TextBox3.Text

        Dim intCounter1 As Integer
        Dim str1SQL As String
        Dim objCommand1 As SqlClient.SqlCommand
        Dim objDAA As SqlClient.SqlDataAdapter
        Dim objDSS As New Data.DataSet

        BrojPom = 0
        i = 0

        sqlText = " SELECT BrTrOgrZS  FROM  TrOgr " & _
          " WHERE   BrTrOgrZS = '" & broj & "' "
        objCommand1 = New SqlClient.SqlCommand(sqlText, WebVeza)
        objCommand1.Connection.Open()
        objDAA = New SqlClient.SqlDataAdapter(sqlText, WebVeza)
        objDAA.Fill(objDSS)

        With objDSS.Tables(0)
            For intCounter1 = 0 To .Rows.Count - 1
                BrojPom = .Rows(intCounter1).Item("BrTrOgrZS")
                BrojPom = BrojPom.Trim
                If broj = BrojPom Then
                    i = 1
                    Exit For
                End If
            Next
        End With
        'If mAkcija = "New" Or mAkcija = "" Then
        If broj = BrojPom.ToString Then
            MessageBox.Show("Takav ugovor vec postoji! Unesite novi broj ugovora!")
            TrOgrPostoji = "D"
        Else
            TrOgrPostoji = "N"
            'TextBox1.Clear()
            'TextBox1.Focus()
            ' End If
        End If

        Dim sqlComm As New SqlClient.SqlCommand(sqlText, WebVeza)
        Try
            If WebVeza.State = ConnectionState.Closed Then
                WebVeza.Open()
            End If

            Dim rdr As SqlDataReader = sqlComm.ExecuteReader(CommandBehavior.CloseConnection)

            If TextBox1.Text <> "" Then
                ErrorProvider1.SetError(TextBox1, "")
                If rdr.Read() Then
                    TrOgrPostoji = "D"
                    ErrorProvider1.SetError(TextBox1, "")
                    rdr.Close()
                Else
                    rdr.Close()
                    TextBox2.Focus()      ' zahtev
                End If
            Else
                ErrorProvider1.SetError(TextBox1, "Morate uneti broj transportnog ogranièenja!")
                TextBox1.SelectAll()
                TextBox1.Focus()
            End If
        Catch eSQL As SqlException
            MsgBox(eSQL.Message)

        Catch ex As Exception
            MsgBox(Err.Description)

        Finally
            WebVeza.Close()
            sqlComm.Dispose()
        End Try
        'TextBox1.Focus()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intCounter3 As Integer
        Dim Upit3 As String
        Dim objCommand3 As SqlClient.SqlCommand
        Dim objDAA3 As SqlClient.SqlDataAdapter
        Dim objDSS3 As New Data.DataSet
        Dim RazOgr As String

        Upit3 = "SELECT * FROM  Server "

        objCommand3 = New SqlClient.SqlCommand(Upit3, WebVeza)
        objCommand3.Connection.Open()
        objDAA3 = New SqlClient.SqlDataAdapter(Upit3, WebVeza)
        objDAA3.Fill(objDSS3)

        With objDSS3.Tables(0)
            For intCounter3 = 0 To .Rows.Count - 1
                ToFile = .Rows(intCounter3).Item("Path")
            Next
        End With
        objCommand3.Connection.Close()

    End Sub

    Private Sub TextBox3_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Dim slogTrans As SqlTransaction
        'Dim UserId As String
        'Dim DatumUnosa As Date
        Dim rv As String

        Dim intCounter4 As Integer
        Dim Upit4 As String
        Dim objCommand4 As SqlClient.SqlCommand
        Dim objDAA4 As SqlClient.SqlDataAdapter
        Dim objDSS4 As New Data.DataSet
        Dim RazOgr As String
        Dim broj2 As String

        broj1 = TextBox1.Text & "" & TextBox3.Text
        broj2 = TextBox1.Text & "/" & TextBox3.Text

        Upit4 = "SELECT * FROM  TrOgr " & _
                "WHERE BrTrOgrZS  = '" & broj2 & "' "

        objCommand4 = New SqlClient.SqlCommand(Upit4, WebVeza)
        objCommand4.Connection.Open()
        objDAA4 = New SqlClient.SqlDataAdapter(Upit4, WebVeza)
        objDAA4.Fill(objDSS4)

        With objDSS4.Tables(0)
            For intCounter4 = 0 To .Rows.Count - 1
                Uprava = .Rows(intCounter4).Item("Uprava")
                BrTrOgrZS = .Rows(intCounter4).Item("BrTrOgrZS")
                BrTel = .Rows(intCounter4).Item("BrTel")
                BrTrOgrUprave = .Rows(intCounter4).Item("BrTrOgrUprave")
                Razlog = .Rows(intCounter4).Item("Razlog")
                UspPos = .Rows(intCounter4).Item("UspPos")
                VaziOd = .Rows(intCounter4).Item("VaziOd")
                DoOpoziva = .Rows(intCounter4).Item("DoOpoziva")
                VaziDo = .Rows(intCounter4).Item("VaziDo")
            Next
        End With

        ComboBox1.Items.Add(Uprava)
        ComboBox1.Text = Uprava
        'TextBox1.Text = BrTrOgrZS
        TextBox2.Text = BrTel
        TextBox4.Text = BrTrOgrUprave
        ComboBox2.Items.Add(Razlog)
        ComboBox2.Text = Razlog
        ComboBox3.Items.Add(UspPos)
        ComboBox3.Text = UspPos
        DateTimePicker1.Text = VaziOd
        If DoOpoziva = "D " Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        DateTimePicker2.Text = VaziDo
        NazivFile = broj1
        RichTextBox1.LoadFile(ToFile & "\" & broj1 & ".rtf") ''"z:" & broj1 & ".rtf")     'ToFile & "/" & broj1 & ".rtf")
        'If Not DataGrid1.DataSource Is Nothing Then
        objCommand4.Connection.Close()

        'broj = TextBox1.Text
        'BrTel = txtTeleg.Text
        '''''
        'UpisOgr(SlogTrans, mAkcija, Broj, Tip, Tacka1, Tacka4, Tacka5_1, VaziOd, DoOpoziva, VaziDo, Tacka7, Ukinuto, UserId, DatumUnosa, rv)
        ''''
        '    OVDE()
        ''''
    End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'System.IO.File.Copy("d:/roba/11109.rtf", "//10.1.1.23/zskargo/to/11109.rtf")
    '    System.IO.File.Copy("d:/roba/11109.rtf", "//10.0.80.33/mreza/11109.rtf")
    'End Sub

    Private Sub DateTimePicker3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker3.Validating
        If DateTimePicker3.Value < DateTimePicker2.Value Then   'VaziDo < VaziOd Then
            MsgBox("Datum važenja mora biti veci od važenja uvodjenja ogranicenja.")
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click

        Dim slogTrans As SqlTransaction
        Dim rv As String

        Dim intCounter5 As Integer
        Dim Upit5 As String
        Dim objCommand5 As SqlClient.SqlCommand
        Dim objDAA5 As SqlClient.SqlDataAdapter
        Dim objDSS5 As New Data.DataSet
        Dim RazOgr As String
        Dim broj2 As String

        broj1 = TextBox1.Text & "" & TextBox3.Text
        broj2 = TextBox1.Text & "/" & TextBox3.Text

        Upit5 = "SELECT * FROM  TrOgr " & _
                "WHERE BrTrOgrZS  = '" & broj2 & "' "

        TrOgrPostoji = "D"
        objCommand5 = New SqlClient.SqlCommand(Upit5, WebVeza)
        objCommand5.Connection.Open()
        objDAA5 = New SqlClient.SqlDataAdapter(Upit5, WebVeza)
        objDAA5.Fill(objDSS5)
        Try
            With objDSS5.Tables(0)
                'For intCounter5 = 0 To .Rows.Count - 1
                Uprava = .Rows(intCounter5).Item("Uprava")
                BrTrOgrZS = .Rows(intCounter5).Item("BrTrOgrZS")
                BrTel = .Rows(intCounter5).Item("BrTel")
                BrTrOgrUprave = .Rows(intCounter5).Item("BrTrOgrUprave")
                Razlog = .Rows(intCounter5).Item("Razlog")
                UspPos = .Rows(intCounter5).Item("UspPos")
                VaziOd = .Rows(intCounter5).Item("VaziOd")
                DoOpoziva = .Rows(intCounter5).Item("DoOpoziva")
                VaziDo = .Rows(intCounter5).Item("VaziDo")
                NazivFile = .Rows(intCounter5).Item("NazivFile")
                'Next
            End With

            Try

                If WebVeza.State = ConnectionState.Closed Then
                    WebVeza.Open()
                End If

                slogTrans = WebVeza.BeginTransaction()
                'If BrTrOgrZS <> "" Then
                If TrOgrPostoji = "D" Then
                    'Else : TrOgrPostoji = "N"
                    'End If
                    makcija = "Del"
                    UpisOgr(slogTrans, "Del", Uprava, BrTrOgrZS, BrTel, TelDat, BrTrOgrUprave, Razlog, UspPos, VaziOd, DoOpoziva, VaziDo, NazivFile, rv)
                End If
                If rv <> "" Then Throw New Exception(rv)
                If makcija = "Del" Then
                    Try
                        System.IO.File.Delete(ToFile & "\" & broj1 & ".rtf")
                    Catch ex As Exception
                        rv = "Greska"
                    End Try
                    If rv <> "" Then Throw New Exception(rv)
                End If
            Catch ex As Exception
                rv = ex.Message
            Catch sqlex As SqlException
                MsgBox(sqlex.Message)
            Finally
                If rv = "" Then
                    slogTrans.Commit()
                Else
                    slogTrans.Rollback()
                End If
                WebVeza.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show("Uneti podaci ne odgovaraju onima u bazi.", "Grška!")
            rv = "Transportno ogranicenje sa tim brojem ne postoji."

        Finally
        End Try

        If rv <> "" Then
            MsgBox(rv, MsgBoxStyle.Exclamation, "Ništa nije obrisano!")
        Else
            MsgBox("Uspešno izvršeno brisanje!", MsgBoxStyle.Information, "Deleted")
        End If

        objCommand5.Connection.Close()

    End Sub

End Class
