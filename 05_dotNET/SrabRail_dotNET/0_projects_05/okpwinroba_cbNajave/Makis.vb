Imports System.Data.SqlClient
Imports System.Data
Public Class Makis
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
    Friend WithEvents tbNajava As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgNajava As System.Windows.Forms.DataGrid
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dtDatum As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents btnUpisUBazu As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents btnFormirajVoz As System.Windows.Forms.Button
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Makis))
        Me.tbNajava = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgNajava = New System.Windows.Forms.DataGrid
        Me.btnFormirajVoz = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.dtDatum = New System.Windows.Forms.DateTimePicker
        Me.Button9 = New System.Windows.Forms.Button
        Me.btnUpisUBazu = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgNajava, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbNajava
        '
        Me.tbNajava.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNajava.Location = New System.Drawing.Point(27, 20)
        Me.tbNajava.MaxLength = 10
        Me.tbNajava.Name = "tbNajava"
        Me.tbNajava.Size = New System.Drawing.Size(136, 23)
        Me.tbNajava.TabIndex = 0
        Me.tbNajava.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(27, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Broj najave"
        '
        'dgNajava
        '
        Me.dgNajava.DataMember = ""
        Me.dgNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgNajava.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgNajava.Location = New System.Drawing.Point(24, 48)
        Me.dgNajava.Name = "dgNajava"
        Me.dgNajava.PreferredColumnWidth = 100
        Me.dgNajava.Size = New System.Drawing.Size(872, 528)
        Me.dgNajava.TabIndex = 6
        '
        'btnFormirajVoz
        '
        Me.btnFormirajVoz.BackColor = System.Drawing.SystemColors.Control
        Me.btnFormirajVoz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnFormirajVoz.Image = CType(resources.GetObject("btnFormirajVoz.Image"), System.Drawing.Image)
        Me.btnFormirajVoz.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFormirajVoz.Location = New System.Drawing.Point(672, 587)
        Me.btnFormirajVoz.Name = "btnFormirajVoz"
        Me.btnFormirajVoz.Size = New System.Drawing.Size(96, 77)
        Me.btnFormirajVoz.TabIndex = 2
        Me.btnFormirajVoz.Text = "Formiraj voz"
        Me.btnFormirajVoz.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(816, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 40)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "Poziv procedure"
        Me.Button3.Visible = False
        '
        'dtDatum
        '
        Me.dtDatum.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtDatum.Location = New System.Drawing.Point(360, 20)
        Me.dtDatum.Name = "dtDatum"
        Me.dtDatum.Size = New System.Drawing.Size(152, 23)
        Me.dtDatum.TabIndex = 20
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(799, 587)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(96, 77)
        Me.Button9.TabIndex = 4
        Me.Button9.Text = "Otkaži"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnUpisUBazu
        '
        Me.btnUpisUBazu.Image = CType(resources.GetObject("btnUpisUBazu.Image"), System.Drawing.Image)
        Me.btnUpisUBazu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpisUBazu.Location = New System.Drawing.Point(689, 587)
        Me.btnUpisUBazu.Name = "btnUpisUBazu"
        Me.btnUpisUBazu.Size = New System.Drawing.Size(96, 77)
        Me.btnUpisUBazu.TabIndex = 3
        Me.btnUpisUBazu.Text = "Upis u bazu"
        Me.btnUpisUBazu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpisUBazu.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Bruto masa voza "
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label4.Location = New System.Drawing.Point(176, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Suma tara "
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label5.Location = New System.Drawing.Point(304, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Suma neto"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label6.Location = New System.Drawing.Point(432, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Prevoznina"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 582)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 82)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(536, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 64)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "Refresh"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(416, 40)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.TabIndex = 34
        Me.TextBox4.Text = ""
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(280, 44)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.TabIndex = 33
        Me.TextBox3.Text = ""
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(152, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.TabIndex = 32
        Me.TextBox2.Text = ""
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(24, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.TabIndex = 31
        Me.TextBox1.Text = ""
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbUgovor
        '
        Me.tbUgovor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(192, 20)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(136, 23)
        Me.tbUgovor.TabIndex = 1
        Me.tbUgovor.Text = "100801"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(192, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Broj ugovora"
        '
        'Makis
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(912, 666)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbUgovor)
        Me.Controls.Add(Me.btnFormirajVoz)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnUpisUBazu)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.dtDatum)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.dgNajava)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbNajava)
        Me.Name = "Makis"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgNajava, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim dsNajava As DataSet
    Dim dsNajava1 As DataSet


    Private Sub Makis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mDatumKalk = dtDatum.Value
        FormatGrid()
        dtMakis.Clear()
        dtMakis1.Clear()

        If ZaostalaKola = "Da" Then
            Label2.Visible = True
            tbUgovor.Visible = True
            tbNajava.Text = mNajava
            tbUgovor.Text = mBrojUg
            btnFormirajVoz.Focus() '_Click(Me, Nothing)

        Else
            If VozoviMakis = "Novi" Then
                Label2.Visible = False
                tbUgovor.Visible = False
            Else 'VozoviMakis = "Izmena"
                Label2.Visible = True
                tbUgovor.Visible = True
            End If
            tbNajava.Focus()

        End If

    End Sub
    Private Sub FormatGrid()
        'Col1.AutoIncrement = True
        'Col1.ReadOnly = True
        If VozoviMakis = "Novi" Then

            If dsNajava Is Nothing Then
                dgNajava.DataSource = dtMakis
            Else
                If mNajava Is Nothing Then
                Else
                    dgNajava.DataSource = dtMakis
                End If
                dgNajava.DataSource = dsNajava.Tables(0)
            End If

        Else

            If dsNajava1 Is Nothing Then
                dgNajava.DataSource = dtMakis1
            Else
                If mNajava Is Nothing Then
                Else
                    dgNajava.DataSource = dtMakis1
                End If
                dgNajava.DataSource = dsNajava1.Tables(0)
            End If

        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim NajavaRed As DataRow
        Dim _ibk As String
        Dim sql_text1 As String = ""
        Dim suma_tara As Int32 = 0
        Dim suma_neto As Int32 = 0
        Dim suma_bruto As Int32 = 0
        Dim _UKK_Real As Int32 = 0
        Dim _UKK As Int32 = 0

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        Dim _t_ As Int32

        For Each NajavaRed In dtMakis.Rows

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            _ibk = NajavaRed.Item("IBK")

            sql_text1 = "SELECT dbo.SlogKalk.RecID, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.Najava, dbo.SlogKalk.PrUprava " & _
                        "FROM   dbo.SlogKalk INNER JOIN " & _
                               "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                               "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND " & _
                               "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
                        "WHERE (dbo.SlogKola.IBK = '" & _ibk & "') AND (SUBSTRING(dbo.SlogKalk.Najava, 2, 1) = 'X') AND (dbo.SlogKalk.Najava2 = '0')"

            Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
            Dim rdrRm As SqlClient.SqlDataReader

            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)

            Do While rdrRm.Read()

                NajavaRed.Item("RecID") = rdrRm.GetInt32(0)
                NajavaRed.Item("Tara") = rdrRm.GetInt32(1)
                NajavaRed.Item("Masa") = rdrRm.GetInt32(2)
                NajavaRed.Item("DoMakisa") = rdrRm.GetString(3)
                suma_tara = suma_tara + NajavaRed.Item("Tara")
                suma_neto = suma_neto + NajavaRed.Item("Masa")
                mPrUprava = Microsoft.VisualBasic.Right(rdrRm.GetString(4), 2)

            Loop

            If NajavaRed.Item("Masa") > 0 Then
                NajavaRed.Item("Real") = "1"
                _UKK_Real = _UKK_Real + 1
            End If

            rdrRm.Close()
            OkpDbVeza.Close()
        Next

        dgNajava.Refresh()

        _UKK = dtMakis.Rows.Count

        suma_bruto = suma_tara + suma_neto

        GroupBox1.Visible = True
        GroupBox1.Text = "  [  " & _UKK_Real.ToString & " / " & _UKK.ToString & "  ]  "

        TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        TextBox2.Text = Math.Round(suma_neto / 1000, 1).ToString
        TextBox3.Text = Math.Round(suma_tara / 1000, 1).ToString


        '--------------------------------------- kalkulacija
        _PraviPrelaz = mStanica1
        mStanica1 = "16201"
        mBrojUg = "100801"
        mOtpUprava = "00"

        mBrutoMasaPoPosiljci = suma_bruto
        bNadjiPrevozninu01COMakis(mPrevoznina)
        mStanica1 = _PraviPrelaz

        'TextBox4.Text = mPrevoznina.ToString
        TextBox4.Text = Math.Round(mPrevoznina, 2).ToString()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Close()
    End Sub

    Private Sub btnUpisUBazu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpisUBazu.Click

        If VozoviMakis = "Novi" Then
            Dim _UKK As Int32
            Dim _recID As Int32
            Dim NajavaRed1 As DataRow
            Dim sql_text2 As String
            Dim m_Naknade As Decimal = 12
            'Dim m_Prevoznina As Decimal = Int(mPrevoznina)
            Dim m_Prevoznina As Decimal = mPrevoznina

            Dim slogTrans As SqlTransaction

            _UKK = dtMakis.Rows.Count

            If _UKK > 0 Then

                Dim myCommand As SqlCommand
                Dim ra As Int32
                Dim rv As String
                Dim _UpisiTL As Int16 = 0

                For Each NajavaRed1 In dtMakis.Rows
                    If OkpDbVeza.State = ConnectionState.Closed Then
                        OkpDbVeza.Open()
                    End If

                    _recID = NajavaRed1.Item("RecID")

                    If _UpisiTL = 1 Then
                        m_Prevoznina = 0
                    Else
                        m_Prevoznina = TextBox4.Text
                    End If

                    sql_text2 = "UPDATE SlogKalk " & _
                                "SET Najava2 = '" & tbNajava.Text & "', NajavaKola2 = " & _UKK & ", " & _
                                   " ObrGodina2  = " & mObrGodina & ", ObrMesec2 = " & mObrMesec & ", " & _
                                   " rSumaFR = " & (m_Prevoznina + m_Naknade) & ", rPrevFR = " & m_Prevoznina & ", " & _
                                   " rNakFR = " & m_Naknade & " " & _
                                " WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"

                    myCommand = New SqlCommand(sql_text2, OkpDbVeza)

                    Try
                        ra = myCommand.ExecuteNonQuery()
                        If ra = 1 Then
                            _UpisiTL = 1
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    OkpDbVeza.Close()
                Next

                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                End If

                Dim NajavaRed2 As DataRow
                Dim _ibk As String

                slogTrans = OkpDbVeza.BeginTransaction()

                For Each NajavaRed2 In dtMakis.Rows
                    _ibk = NajavaRed2.Item("IBK")
                    If NajavaRed2.Item("Real") = "1" Then
                        Upis.NajavaUpd(slogTrans, mBrojUg, tbNajava.Text, _ibk, rv)
                    End If
                Next

                slogTrans.Commit()

                MessageBox.Show("Podaci o vozu po najavi br.  " & tbNajava.Text & " su upisani u bazu podataka. ", "Beograd Ranzirna", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dtMakis.Clear()
                tbNajava.Text = ""
                Me.btnUpisUBazu.Visible = False
                Me.btnFormirajVoz.Visible = True
                Me.GroupBox1.Visible = False
                Close()

            Else
                MessageBox.Show("Nepostojeci podaci !", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else  'KOREKCIJA

            Dim _UKK As Int32
            Dim _recID As Int32
            Dim NajavaRed1 As DataRow
            Dim sql_text2 As String
            Dim m_Naknade As Decimal = 12
            'Dim m_Prevoznina As Decimal = Int(mPrevoznina)
            Dim m_Prevoznina As Decimal = mPrevoznina

            Dim slogTrans As SqlTransaction

            _UKK = dtMakis1.Rows.Count

            If _UKK > 0 Then

                Dim myCommand As SqlCommand
                Dim ra As Int32
                Dim rv As String
                Dim _UpisiTL As Int16 = 0
                Dim _Suma As Decimal = 0
                Dim _Prev As Decimal = 0
                Dim _Nak As Decimal = 0

                For Each NajavaRed1 In dtMakis1.Rows
                    If OkpDbVeza.State = ConnectionState.Closed Then
                        OkpDbVeza.Open()
                    End If

                    _recID = NajavaRed1.Item("RecID")
                    _Prev = NajavaRed1.Item("Prevoznina")
                    _Nak = NajavaRed1.Item("Naknada")

                    sql_text2 = "UPDATE SlogKalk " & _
                                "SET rPrevFR = " & _Prev & ", rNakFR = " & _Nak & " " & _
                                "WHERE ( dbo.SlogKalk.RecID = " & _recID & ")"

                    myCommand = New SqlCommand(sql_text2, OkpDbVeza)

                    Try
                        ra = myCommand.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    OkpDbVeza.Close()
                Next

                MessageBox.Show("Podaci o vozu po najavi br.  " & tbNajava.Text & " su upisani u bazu podataka. ", "Beograd Ranzirna", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dtMakis1.Clear()
                tbNajava.Text = ""
                tbUgovor.Text = ""
                Me.btnUpisUBazu.Visible = False
                Me.btnFormirajVoz.Visible = True
                Me.GroupBox1.Visible = False
                Close()

            Else
                MessageBox.Show("Nepostojeci podaci !", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If


    End Sub

    Private Sub tbNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbNajava_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNajava.Validated
        mDatumKalk = dtDatum.Value
    End Sub

    Private Sub btnFormirajVoz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormirajVoz.Click

        If VozoviMakis = "Novi" Then

            Dim _nRbr As Int32
            Dim _nIBK As String
            Dim _nIzlaz As String = ""

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            Dim sql_text1 As String = "SELECT dbo.NajavaKola.KolaStavka, dbo.NajavaKola.IBK " & _
               "FROM   dbo.NajavaKola INNER JOIN " & _
                      "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                      "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
               "WHERE (dbo.NajavaKola.KomBrojVoza = '" & tbNajava.Text & "') AND (dbo.NajavaKola.BrUgovora = '100801')"

            Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
            Dim rdrRm As SqlClient.SqlDataReader
            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrRm.Read()
                _nRbr = rdrRm.GetInt32(0)
                _nIBK = rdrRm.GetString(1)
                ''_nIzlaz = rdrRm.GetString(2)
                mStanica2 = _nIzlaz
                dtMakis.NewRow()
                dtMakis.Rows.Add(New Object() {_nRbr, _nIBK, _nIzlaz, "0", "", 0, 0, 0})
            Loop

            rdrRm.Close()
            OkpDbVeza.Close()
            dgNajava.Refresh()

            Me.btnFormirajVoz.Visible = False
            Me.btnUpisUBazu.Visible = True
            Me.btnUpisUBazu.Focus()

            Button3_Click(Me, Nothing)

        Else  'KOREKCIJA

            Dim _nRbr As Int32 = 1
            Dim _nIBK As String
            Dim _nIzlaz As Int32
            Dim suma_tara As Int32 = 0
            Dim suma_neto As Int32 = 0
            Dim suma_bruto As Int32 = 0

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            Dim sql_text1 As String = "SELECT SlogKalk.NajavaKola2 AS [Ukupno kola],  " & _
                                             "SlogKalk.ObrMesec2 AS Mesec, SlogKalk.IzEtiketa AS Nalepnica, SlogKola.IBK, SlogKola.Tara, SlogRoba.SMasa, SlogKalk.rPrevFr AS Prevoznina, " & _
                                             "SlogKalk.rNakFr AS Naknade, SlogKalk.RecID AS RecID " & _
                                      "FROM  SlogKalk INNER JOIN " & _
                                            "SlogKola ON SlogKalk.RecID = SlogKola.RecID AND SlogKalk.Stanica = SlogKola.Stanica INNER JOIN " & _
                                            "SlogRoba ON SlogKola.RecID = SlogRoba.RecID AND SlogKola.Stanica = SlogRoba.Stanica AND SlogKola.KolaStavka = SlogRoba.KolaStavka " & _
                                      "WHERE (dbo.SlogKalk.Najava2 = '" & tbNajava.Text & "') AND (dbo.SlogKalk.Ugovor = '" & tbUgovor.Text & " ') " & _
                                      "ORDER BY SlogKalk.IzEtiketa "

            Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
            Dim rdrRm As SqlClient.SqlDataReader
            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrRm.Read()

                suma_tara = suma_tara + rdrRm.GetInt32(4)
                suma_neto = suma_neto + rdrRm.GetInt32(5)

                dtMakis1.NewRow()
                dtMakis1.Rows.Add(New Object() {_nRbr, rdrRm.GetString(1), rdrRm.GetInt32(2), rdrRm.GetString(3), rdrRm.GetInt32(4), rdrRm.GetInt32(5), rdrRm.GetDecimal(6), rdrRm.GetDecimal(7), rdrRm.GetInt32(8)})
                _nrbr = _nrbr + 1
            Loop

            rdrRm.Close()
            OkpDbVeza.Close()
            dgNajava.Refresh()

            Me.btnFormirajVoz.Visible = False
            Me.btnUpisUBazu.Visible = True
            Me.btnUpisUBazu.Focus()

            suma_bruto = suma_tara + suma_neto

            GroupBox1.Visible = True
            Label6.Visible = False
            TextBox4.Visible = False

            TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
            TextBox2.Text = Math.Round(suma_tara / 1000, 1).ToString
            TextBox3.Text = Math.Round(suma_neto / 1000, 1).ToString

            'Button3_Click(Me, Nothing)

        End If


    End Sub

    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim suma_tara As Int32 = 0
        Dim suma_neto As Int32 = 0
        Dim suma_bruto As Int32 = 0

        If VozoviMakis = "Novi" Then
            suma_tara = dtMakis.Compute("SUM(Tara)", String.Empty)
            suma_neto = dtMakis.Compute("SUM(Masa)", String.Empty)
        Else
            suma_tara = dtMakis1.Compute("SUM(Tara)", String.Empty)
            suma_neto = dtMakis1.Compute("SUM(Masa)", String.Empty)
        End If
        suma_bruto = suma_tara + suma_neto

        TextBox1.Text = Math.Round(suma_bruto / 1000, 1).ToString
        TextBox2.Text = Math.Round(suma_tara / 1000, 1).ToString
        TextBox3.Text = Math.Round(suma_neto / 1000, 1).ToString
    End Sub
End Class
