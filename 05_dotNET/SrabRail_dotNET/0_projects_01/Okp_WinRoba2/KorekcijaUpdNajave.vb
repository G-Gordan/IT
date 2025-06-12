imports System.Data.SqlClient
Imports System.Data
Public Class KorekcijaUpdNajave
    Inherits System.Windows.Forms.Form
    Public suma_tara As Int32 = 0
    Public suma_neto As Int32 = 0
    Public suma_bruto As Int32 = 0


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
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbNajava As System.Windows.Forms.TextBox
    Friend WithEvents btnFormirajVoz As System.Windows.Forms.Button
    Friend WithEvents btnUpisUBazu As System.Windows.Forms.Button
    Friend WithEvents dgKorekcija As System.Windows.Forms.DataGrid
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KorekcijaUpdNajave))
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbNajava = New System.Windows.Forms.TextBox
        Me.dgKorekcija = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.btnFormirajVoz = New System.Windows.Forms.Button
        Me.btnUpisUBazu = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnOtkazi = New System.Windows.Forms.Button
        CType(Me.dgKorekcija, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(160, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Broj ugovora"
        '
        'tbUgovor
        '
        Me.tbUgovor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(160, 40)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(96, 23)
        Me.tbUgovor.TabIndex = 1
        Me.tbUgovor.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Broj najave"
        '
        'tbNajava
        '
        Me.tbNajava.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNajava.Location = New System.Drawing.Point(8, 40)
        Me.tbNajava.MaxLength = 10
        Me.tbNajava.Name = "tbNajava"
        Me.tbNajava.Size = New System.Drawing.Size(136, 23)
        Me.tbNajava.TabIndex = 0
        Me.tbNajava.Text = ""
        '
        'dgKorekcija
        '
        Me.dgKorekcija.DataMember = ""
        Me.dgKorekcija.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorekcija.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKorekcija.Location = New System.Drawing.Point(8, 96)
        Me.dgKorekcija.Name = "dgKorekcija"
        Me.dgKorekcija.PreferredColumnWidth = 90
        Me.dgKorekcija.Size = New System.Drawing.Size(992, 616)
        Me.dgKorekcija.TabIndex = 39
        Me.dgKorekcija.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgKorekcija
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'btnFormirajVoz
        '
        Me.btnFormirajVoz.BackColor = System.Drawing.SystemColors.Control
        Me.btnFormirajVoz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnFormirajVoz.Image = CType(resources.GetObject("btnFormirajVoz.Image"), System.Drawing.Image)
        Me.btnFormirajVoz.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFormirajVoz.Location = New System.Drawing.Point(376, 16)
        Me.btnFormirajVoz.Name = "btnFormirajVoz"
        Me.btnFormirajVoz.Size = New System.Drawing.Size(96, 56)
        Me.btnFormirajVoz.TabIndex = 2
        Me.btnFormirajVoz.Text = "Pronadi najavu"
        Me.btnFormirajVoz.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnUpisUBazu
        '
        Me.btnUpisUBazu.Image = CType(resources.GetObject("btnUpisUBazu.Image"), System.Drawing.Image)
        Me.btnUpisUBazu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpisUBazu.Location = New System.Drawing.Point(800, 24)
        Me.btnUpisUBazu.Name = "btnUpisUBazu"
        Me.btnUpisUBazu.Size = New System.Drawing.Size(96, 56)
        Me.btnUpisUBazu.TabIndex = 4
        Me.btnUpisUBazu.Text = "Izmena u bazi"
        Me.btnUpisUBazu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(272, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Godina"
        '
        'TextBox5
        '
        Me.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(272, 40)
        Me.TextBox5.MaxLength = 4
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(69, 23)
        Me.TextBox5.TabIndex = 43
        Me.TextBox5.Text = "2008"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.tbNajava)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.tbUgovor)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextBox5)
        Me.GroupBox2.Controls.Add(Me.btnFormirajVoz)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(488, 80)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Postojeci podaci "
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.TextBox8)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.TextBox7)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(512, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(392, 80)
        Me.GroupBox3.TabIndex = 50
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Novi podaci "
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(176, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 16)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Broj ugovora"
        '
        'TextBox8
        '
        Me.TextBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(176, 32)
        Me.TextBox8.MaxLength = 6
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(96, 23)
        Me.TextBox8.TabIndex = 40
        Me.TextBox8.Text = ""
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Broj najave"
        '
        'TextBox7
        '
        Me.TextBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(10, 32)
        Me.TextBox7.MaxLength = 10
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(136, 23)
        Me.TextBox7.TabIndex = 38
        Me.TextBox7.Text = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(272, 16)
        Me.Label3.TabIndex = 42
        Me.Label3.Visible = False
        '
        'btnOtkazi
        '
        Me.btnOtkazi.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(912, 8)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 80)
        Me.btnOtkazi.TabIndex = 51
        Me.btnOtkazi.Text = "Izlaz"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'KorekcijaUpdNajave
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 712)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnUpisUBazu)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgKorekcija)
        Me.Name = "KorekcijaUpdNajave"
        Me.Text = "KorekcijaUpdNajave"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgKorekcija, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim dsUpdKorekcija As DataSet
    Private Sub tbNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub tbNajava_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNajava.Validated
        If tbNajava.Text = "" Then
            MessageBox.Show("Neispravan broj najave!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tbNajava.Focus()
        End If
    End Sub
    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub btnFormirajVoz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormirajVoz.Click
        'ok
        Dim _nRbr As Int32 = 1

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim sql_text1 As String

        sql_text1 = "SELECT SlogKalk.ObrMesec, SlogKalk.ObrGodina, SlogKalk.Ugovor, SlogKalk.Najava, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM, SlogRoba.SMasa, " & _
                    "SlogKalk.RecID, SlogRoba.KolaStavka AS ks, SlogRoba.RobaStavka AS rs " & _
                    "FROM SlogKalk INNER JOIN " & _
                    "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN " & _
                    "SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka " & _
                    "WHERE (dbo.SlogKalk.Najava = '" & tbNajava.Text & "') AND (dbo.SlogKalk.ObrGodina = '" & TextBox5.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & "') "


        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)

        Do While rdrRm.Read()

            dtUpdKorekcija.NewRow()
            dtUpdKorekcija.Rows.Add(New Object() {_nRbr, rdrRm.GetString(0), rdrRm.GetString(1), rdrRm.GetString(2), rdrRm.GetString(3), rdrRm.GetString(4), _
                                                  rdrRm.GetInt32(5), rdrRm.GetString(6), rdrRm.GetInt32(7), rdrRm.GetInt32(8), rdrRm.GetInt32(9), rdrRm.GetInt32(10)})

            _nRbr = _nRbr + 1
        Loop

        rdrRm.Close()
        OkpDbVeza.Close()
        dgKorekcija.Refresh()

    End Sub
    Private Sub KorekcijaUpdNajave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatGrid()
        dtUpdKorekcija.Clear()
        TextBox5.Text = Today.Year.ToString
        tbNajava.Focus()


    End Sub
    Private Sub FormatGrid()

        If dsUpdKorekcija Is Nothing Then
            dgKorekcija.DataSource = dtUpdKorekcija
        Else
            If mNajava Is Nothing Then
            Else
                dgKorekcija.DataSource = dtUpdKorekcija
            End If
            dgKorekcija.DataSource = dsUpdKorekcija.Tables(0)
        End If

    End Sub
    Private Sub btnUpisUBazu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpisUBazu.Click
        If Len(TextBox7.Text) = 0 Or Len(TextBox8.Text) = 0 Then
            MessageBox.Show("Nepostojeci podaci o najavi i ugovoru!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()

        Else
            Dim _UKK As Int32
            Dim _recID As Int32
            Dim _recRBR As Int32

            Dim KorekcijaRed As DataRow
            Dim sql_Kalk As String
            Dim sql_Kola As String
            Dim sql_Roba As String

            Dim slogTrans As SqlTransaction

            _UKK = dtUpdKorekcija.Rows.Count

            If _UKK > 0 Then

                Dim myCommandKalk As SqlCommand
                Dim myCommandKola As SqlCommand
                Dim myCommandRoba As SqlCommand

                Dim ra As Int32
                Dim rv As String
                Dim _UpisiTL As Int16 = 0

                Dim _IBK As String
                Dim _Ugovor As String = TextBox8.Text
                Dim _Najava As String = RTrim(TextBox7.Text)
                Dim _Tara As Int32 = 0
                Dim _NHM As String
                Dim _Neto As Int32 = 0
                Dim _KolaRb As Int32 = 0
                Dim _RobaRb As Int32 = 0

                For Each KorekcijaRed In dtUpdKorekcija.Rows
                    If OkpDbVeza.State = ConnectionState.Closed Then
                        OkpDbVeza.Open()
                    End If

                    _recID = KorekcijaRed.Item("RecID")
                    _recRBR = KorekcijaRed.Item("RBR")
                    _IBK = Int(KorekcijaRed.Item("IBK"))
                    _Tara = Int(KorekcijaRed.Item("Tara"))
                    _NHM = KorekcijaRed.Item("NHM")
                    _Neto = Int(KorekcijaRed.Item("Masa"))
                    _KolaRb = Int(KorekcijaRed.Item("KS"))
                    _RobaRb = Int(KorekcijaRed.Item("RS"))

                    sql_Kalk = "UPDATE SlogKalk " & _
                               "SET Ugovor = '" & _Ugovor & "' , Najava = '" & RTrim(_Najava) & "', " & _
                               "Referent2 = '" & mUserID & "'  " & _
                               "WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"

                    sql_Kola = "UPDATE SlogKola " & _
                               "SET Tara = " & _Tara & " " & _
                               "WHERE (dbo.SlogKola.RecID = " & _recID & ") AND (dbo.SlogKola.KolaStavka = " & _KolaRb & ")"

                    sql_Roba = "UPDATE SlogRoba " & _
                               "SET SMasa = " & _Neto & " " & _
                               "WHERE (dbo.SlogRoba.RecID = " & _recID & ") AND (dbo.SlogRoba.KolaStavka = " & _KolaRb & ") AND (dbo.SlogRoba.RobaStavka = " & _RobaRb & ")"

                    myCommandKalk = New SqlCommand(sql_Kalk, OkpDbVeza)
                    myCommandKola = New SqlCommand(sql_Kola, OkpDbVeza)
                    myCommandRoba = New SqlCommand(sql_Roba, OkpDbVeza)

                    Try
                        ra = myCommandKalk.ExecuteNonQuery()
                        ra = myCommandKola.ExecuteNonQuery()
                        ra = myCommandRoba.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    OkpDbVeza.Close()
                Next

                MessageBox.Show("Podaci za najavu broj  " & tbNajava.Text & " su upisani u bazu podataka. ", "Beograd Ranzirna", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dtUpdKorekcija.Clear()
                TextBox7.Text = ""
                TextBox8.Text = ""
                Close()

            Else
                MessageBox.Show("Nepostojeci podaci !", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If

    End Sub
    Private Sub tbCeoVoz_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox8_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox8.Validating

        If TextBox8.Text = Nothing Then
            ErrorProvider1.SetError(TextBox8, "Neispravan unos!")
            TextBox8.Focus()
        Else
            ErrorProvider1.SetError(TextBox8, "")
            If IsNumeric(TextBox8.Text) = True Then
                Dim mRetVal As String
                Dim ug_mNazivKomitenta As String
                Dim ug_mPrimalac As String
                Dim ug_mSuma As Int32
                Dim ug_mVrstaObracuna As String

                NadjiUgovor2(TextBox8.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, ug_mSuma, mRetVal)

                If mRetVal = "" Then
                    ErrorProvider1.SetError(TextBox8, "")
                    Label3.Visible = True
                    Label3.Text = ug_mNazivKomitenta
                    btnUpisUBazu.Focus()

                Else
                    ErrorProvider1.SetError(TextBox8, "Takav ugovor ne postoji u bazi podataka!")
                    TextBox8.Focus()
                End If

            Else
                ErrorProvider1.SetError(TextBox8, "Neispravan unos!")
                TextBox8.Focus()

            End If
        End If

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        dtUpdKorekcija.Clear()
        Close()

    End Sub
End Class
