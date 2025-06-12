Imports System.Data.SqlClient
Public Class MakisZaostalaKola_1
    Inherits System.Windows.Forms.Form
    Dim dsNajave2 As New DataSet("dsNajave2")
    Public _NajavaKola2 As Int32

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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MakisZaostalaKola_1))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Button9 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 16)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.PreferredColumnWidth = 110
        Me.DataGrid1.Size = New System.Drawing.Size(968, 464)
        Me.DataGrid1.TabIndex = 0
        '
        'DataGrid2
        '
        Me.DataGrid2.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DataGrid2.CaptionText = "Tovarni list "
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(16, 488)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.PreferredColumnWidth = 110
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.Size = New System.Drawing.Size(968, 112)
        Me.DataGrid2.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.ForeColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(16, 624)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "TextBox1"
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.ForeColor = System.Drawing.Color.Red
        Me.TextBox2.Location = New System.Drawing.Point(16, 648)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "TextBox2"
        Me.TextBox2.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Location = New System.Drawing.Point(552, 608)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.TabIndex = 4
        Me.TextBox3.Text = "TEXTBOX3"
        Me.TextBox3.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(752, 608)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 77)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Izmena u bazi"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(552, 632)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.TabIndex = 6
        Me.TextBox4.Text = "TextBox4"
        Me.TextBox4.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(552, 656)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.TabIndex = 7
        Me.TextBox5.Text = "TextBox5"
        Me.TextBox5.Visible = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(880, 608)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(96, 77)
        Me.Button9.TabIndex = 8
        Me.Button9.Text = "Otkaži"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'MakisZaostalaKola_1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(992, 696)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "MakisZaostalaKola_1"
        Me.Text = "MakisZaostalaKola_1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MakisZaostalaKola_1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ii1 As Int32 = 0
        Dim dsNajave1 As New DataSet("dsNajave1")
        Dim string1 As String = ""

        string1 = "SELECT dbo.NajavaKola.IBK AS [Individualni broj kola], dbo.NajavaVoza.BrUgovora AS [Ugovor] , dbo.NajavaVoza.KomBrojVoza AS [Najava voza], dbo.NajavaVoza.SumaKola AS [Najavljeni broj kola], dbo.NajavaVoza.Realizovano AS [Realizovani broj kola] " & _
                  "FROM   dbo.NajavaKola INNER JOIN " & _
                         "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                         "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                  "WHERE (dbo.NajavaKola.Realizovano = '0') AND (LEFT(dbo.NajavaVoza.KomBrojVoza, 1) = 'X')"

        DataGrid1.CaptionText = "Nerealizovana kola po najavama iz Beograd Ranzirne"

        Dim ad1 As New SqlDataAdapter(string1, OkpDbVeza)
        ii1 = ad1.Fill(dsNajave1)

        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
                End If
            DataGrid1.DataSource = dsNajave1.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        dsNajave2.Clear()

        TextBox1.Text = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) 'Najava
        _NajavaKola2 = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) 'Kola po najavi

        Dim ii2 As Int32 = 0
        Dim string2 As String = ""
        Dim _IBK As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)

        string2 = "SELECT dbo.SlogKola.IBK AS [Individualni broj kola], dbo.SlogKalk.Ugovor, dbo.SlogKalk.ZsUlPrelaz AS [Ulazni prelaz], dbo.SlogKalk.UlEtiketa AS [Ulazna etiketa], dbo.SlogKalk.ZsIzPrelaz AS [Izlazni prelaz], dbo.SlogKalk.IzEtiketa AS [Izlazna etiketa], " & _
                         "dbo.SlogKalk.Najava AS [Voz do Makisa], dbo.SlogKalk.ObrMesec2 AS [Obracunski mesec], dbo.SlogKalk.ObrGodina2 AS [Godina], SlogKalk.RecID " & _
                  "FROM   dbo.SlogKalk INNER JOIN " & _
                         "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica " & _
                  "WHERE (SUBSTRING(dbo.SlogKalk.Najava,2,1) = 'X') AND (dbo.SlogKalk.Najava2 = '0') AND (dbo.SlogKola.IBK = '" & _IBK & "')"

        Dim ad2 As New SqlDataAdapter(string2, OkpDbVeza)

        Try
            ii2 = ad2.Fill(dsNajave2)
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            DataGrid2.DataSource = dsNajave2.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        mNajava = TextBox1.Text
        mNajava = mNajava.ToUpper
        mBrojUg = DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 1)

        '------------------------------------ Update ---------------------------------------

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim myCommand As SqlCommand
        Dim myCommand3 As SqlCommand
        Dim myCommand4 As SqlCommand
        Dim ra As Int32
        Dim ra3 As Int32
        Dim ra4 As Int32
        Dim _recID As Int32 = DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 9)
        Dim _ibk As String = DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 0)
        Dim sql_text2 As String
        Dim sql_text3 As String
        Dim sql_text4 As String

        sql_text2 = "UPDATE SlogKalk " & _
                    "SET Najava2 = '" & mNajava & "', NajavaKola2 = " & _NajavaKola2 & ", ObrGodina2 = '" & mObrGodina & "', ObrMesec2 = '" & mObrMesec & "',  rPrevFr = 0, rNakFr = 12" & " " & _
                    "WHERE (dbo.SlogKalk.RecID = " & _recID & ")"

        myCommand = New SqlCommand(sql_text2, OkpDbVeza)

        Try
            ra = myCommand.ExecuteNonQuery()

            sql_text3 = "UPDATE NajavaKola " & _
                        "SET Realizovano = '1' " & _
                        "WHERE (dbo.NajavaKola.IBK = '" & _ibk & "') AND (dbo.NajavaKola.KomBrojVoza = '" & mNajava & "') AND (dbo.NajavaKola.BrUgovora = '" & mBrojUg & "')"

            myCommand3 = New SqlCommand(sql_text3, OkpDbVeza)
            ra3 = myCommand3.ExecuteNonQuery()

            sql_text4 = "UPDATE NajavaVoza " & _
                        "SET Realizovano = Realizovano + 1 " & _
                        "WHERE (dbo.NajavaVoza.SumaKola <> dbo.NajavaVoza.Realizovano) AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') AND (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "')"

            myCommand4 = New SqlCommand(sql_text4, OkpDbVeza)
            ra4 = myCommand4.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        OkpDbVeza.Close()
        Close()

        '-----------------------------------------------------------------------------------'

        VozoviMakis = "Izmena"
        Dim FormMakisIzmena As New MakisNew  ' Makis
        FormMakisIzmena.Text = "Korekcija unetih podataka o vozu na relaciji Beograd Ranzirna - Granica"
        FormMakisIzmena.ShowDialog()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Close()

    End Sub
End Class
