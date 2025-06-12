Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection

Public Class EIStart
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
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EIStart))
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Racunski mesec i godina"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(195, 43)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(72, 21)
        Me.NumericUpDown1.TabIndex = 0
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown2.Location = New System.Drawing.Point(299, 43)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {2006, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(72, 21)
        Me.NumericUpDown2.TabIndex = 1
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown2.Value = New Decimal(New Integer() {2006, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Izbor tarife"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Vrsta posiljke"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"1. Spt 38", "2. Tea 9291", "3. Ugovor"})
        Me.ComboBox1.Location = New System.Drawing.Point(195, 75)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(176, 23)
        Me.ComboBox1.TabIndex = 2
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox2.Items.AddRange(New Object() {"1. Pojedinacna posiljka", "2. Grupa kola", "3. Voz", "4. Pojedinacna posiljka - rucni unos"})
        Me.ComboBox2.Location = New System.Drawing.Point(195, 143)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(176, 23)
        Me.ComboBox2.TabIndex = 4
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(193, 179)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(77, 64)
        Me.btnPrihvati.TabIndex = 5
        Me.btnPrihvati.Text = "Prihvati"
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(294, 179)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(77, 64)
        Me.btnOtkazi.TabIndex = 6
        Me.btnOtkazi.Text = "Otkazi"
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Enabled = False
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox3.Items.AddRange(New Object() {"100600 Proodos", "050600 Fersed Skopje", "060600 TCL", "080600 TT Cargo"})
        Me.ComboBox3.Location = New System.Drawing.Point(195, 109)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(176, 23)
        Me.ComboBox3.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 23)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Izbor speditera"
        '
        'EIStart
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(400, 254)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EIStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uvoz Start!"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub EIStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        '----------------------------------------------------------'
        Dim sql_text As String = "SELECT dbo.Ugovori.BrojUgovora, dbo.Komitent.Naziv FROM dbo.Komitent INNER JOIN " & _
                                           "dbo.Ugovori ON dbo.Komitent.Sifra = dbo.Ugovori.SifraKorisnika"

        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrUg As SqlClient.SqlDataReader
        Dim combo_linija As String = ""
        ComboBox3.Items.Clear()
        rdrUg = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrUg.Read()
            combo_linija = rdrUg.GetString(0) & " " & rdrUg.GetString(1)
            ComboBox3.Items.Add(combo_linija)
        Loop
        rdrUg.Close()

        '----------------------------------------------------------'

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        'Try

        Dim sql_text1 As String = "SELECT dbo.ZsTarifa.SifraTarife, dbo.ZsTarifa.Naziv FROM dbo.ZsTarifa " & _
                                  "WHERE (dbo.ZsTarifa.SifraVS = 2)"

        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, DbVeza)
        Dim rdrTar As SqlClient.SqlDataReader
        Dim combo_linija1 As String = ""
        ComboBox1.Items.Clear()
        rdrTar = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrTar.Read()
            combo_linija1 = rdrTar.GetString(0) & " " & rdrTar.GetString(1)
            ComboBox1.Items.Add(combo_linija1)
        Loop
        rdrTar.Close()

        'Catch ex As Exception

        'End Try

        '----------------------------------------------------------'

        'Dim sql_text1 As String = "SELECT Mesec, Godina FROM RacMesec " & _
        '                         "WHERE (VSaob = '" & IzborSaobracaja & "')"
        'Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, DbVeza)
        'Dim rdrRm As SqlClient.SqlDataReader
        'rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        'Do While rdrRm.Read()
        '    Me.NumericUpDown1.Text = rdrRm.GetString(0)
        '    Me.NumericUpDown2.Text = rdrRm.GetString(1)
        'Loop
        'rdrUg.Close()
        'rdrRm.Close()
        '----------------------------------------------------------'

        DbVeza.Close()
    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        mBrojUg = Microsoft.VisualBasic.Left(ComboBox3.Text, 6)
        Dim form2 As New UnosEI
        IzborSaobracaja = "2"
        form2.Text = ComboBox1.SelectedItem
        form2.ShowDialog()
        Close()
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        mTarifa = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)

        If mTarifa = "00" Then 'Ugovor
            Label4.Enabled = True
            ComboBox3.Enabled = True
            ComboBox3.Focus()
        Else
            ComboBox3.Text = " "
            Label4.Enabled = False
            ComboBox3.Enabled = False
        End If

    End Sub
    Private Sub NumericUpDown1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumericUpDown1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub NumericUpDown2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumericUpDown2.KeyPress
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

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        mTarifa = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)
    End Sub

    Private Sub ComboBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.Leave
        If ComboBox3.Text = "" Then
            ComboBox3.Focus()
        End If
    End Sub
End Class
