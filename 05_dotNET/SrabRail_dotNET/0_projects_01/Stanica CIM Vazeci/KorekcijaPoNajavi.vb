imports System.Data.SqlClient
Imports System.Data
Public Class KorekcijaPoNajavi
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFormirajVoz As System.Windows.Forms.Button
    Friend WithEvents btnUpisUBazu As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents dgKorekcija As System.Windows.Forms.DataGrid
    Friend WithEvents DatumIzvestaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbBrojVoza As System.Windows.Forms.TextBox
    Friend WithEvents tbSatVoza As System.Windows.Forms.TextBox
    Friend WithEvents tbStanica As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KorekcijaPoNajavi))
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbSatVoza = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbBrojVoza = New System.Windows.Forms.TextBox
        Me.dgKorekcija = New System.Windows.Forms.DataGrid
        Me.btnFormirajVoz = New System.Windows.Forms.Button
        Me.btnUpisUBazu = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.DatumIzvestaja = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbStanica = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.dgKorekcija, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(168, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Sat voza"
        '
        'tbSatVoza
        '
        Me.tbSatVoza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbSatVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSatVoza.Location = New System.Drawing.Point(168, 17)
        Me.tbSatVoza.MaxLength = 6
        Me.tbSatVoza.Name = "tbSatVoza"
        Me.tbSatVoza.Size = New System.Drawing.Size(136, 23)
        Me.tbSatVoza.TabIndex = 1
        Me.tbSatVoza.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Trasa voza"
        '
        'tbBrojVoza
        '
        Me.tbBrojVoza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbBrojVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojVoza.Location = New System.Drawing.Point(8, 17)
        Me.tbBrojVoza.MaxLength = 5
        Me.tbBrojVoza.Name = "tbBrojVoza"
        Me.tbBrojVoza.Size = New System.Drawing.Size(136, 23)
        Me.tbBrojVoza.TabIndex = 0
        Me.tbBrojVoza.Text = ""
        '
        'dgKorekcija
        '
        Me.dgKorekcija.CaptionText = "Posiljke u vozu"
        Me.dgKorekcija.DataMember = ""
        Me.dgKorekcija.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgKorekcija.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgKorekcija.Location = New System.Drawing.Point(8, 44)
        Me.dgKorekcija.Name = "dgKorekcija"
        Me.dgKorekcija.PreferredColumnWidth = 90
        Me.dgKorekcija.Size = New System.Drawing.Size(680, 548)
        Me.dgKorekcija.TabIndex = 39
        '
        'btnFormirajVoz
        '
        Me.btnFormirajVoz.BackColor = System.Drawing.SystemColors.Control
        Me.btnFormirajVoz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnFormirajVoz.Image = CType(resources.GetObject("btnFormirajVoz.Image"), System.Drawing.Image)
        Me.btnFormirajVoz.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFormirajVoz.Location = New System.Drawing.Point(464, 603)
        Me.btnFormirajVoz.Name = "btnFormirajVoz"
        Me.btnFormirajVoz.Size = New System.Drawing.Size(96, 77)
        Me.btnFormirajVoz.TabIndex = 3
        Me.btnFormirajVoz.Text = "Pronadji voz"
        Me.btnFormirajVoz.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnUpisUBazu
        '
        Me.btnUpisUBazu.Image = CType(resources.GetObject("btnUpisUBazu.Image"), System.Drawing.Image)
        Me.btnUpisUBazu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpisUBazu.Location = New System.Drawing.Point(464, 603)
        Me.btnUpisUBazu.Name = "btnUpisUBazu"
        Me.btnUpisUBazu.Size = New System.Drawing.Size(96, 77)
        Me.btnUpisUBazu.TabIndex = 4
        Me.btnUpisUBazu.Text = "Upis u bazu"
        Me.btnUpisUBazu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpisUBazu.Visible = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(591, 603)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(96, 77)
        Me.Button9.TabIndex = 5
        Me.Button9.Text = "Otkaži"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'DatumIzvestaja
        '
        Me.DatumIzvestaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DatumIzvestaja.Location = New System.Drawing.Point(384, 17)
        Me.DatumIzvestaja.Name = "DatumIzvestaja"
        Me.DatumIzvestaja.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(384, -3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 23)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Izaberite datum"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbStanica
        '
        Me.tbStanica.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanica.Location = New System.Drawing.Point(608, 17)
        Me.tbStanica.MaxLength = 5
        Me.tbStanica.Name = "tbStanica"
        Me.tbStanica.TabIndex = 47
        Me.tbStanica.Text = "TextBox1"
        Me.tbStanica.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(11, 634)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 46)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Isti rok carinjenja za sve posiljke"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 605)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.TabIndex = 49
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 586)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 23)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Rok carinjenja"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KorekcijaPoNajavi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(698, 686)
        Me.Controls.Add(Me.dgKorekcija)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbStanica)
        Me.Controls.Add(Me.DatumIzvestaja)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbSatVoza)
        Me.Controls.Add(Me.tbBrojVoza)
        Me.Controls.Add(Me.btnFormirajVoz)
        Me.Controls.Add(Me.btnUpisUBazu)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "KorekcijaPoNajavi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datum carinjenja"
        Me.TopMost = True
        CType(Me.dgKorekcija, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim dsKorekcija As DataSet
    Private Sub tbNajava_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub tbUgovor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSatVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub btnFormirajVoz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormirajVoz.Click

        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim _col0 As String
        Dim _col1 As Int32
        Dim _col3 As String
        Dim _col4 As Date
        Dim _col5 As Date
        Dim _col6 As Int32
        Dim _col7 As String



        Dim sql_text1 As String = "SELECT Saobracaj, UlEtiketa AS TrzMarkica, OtpStanica AS [Stanica Otp.], OtpBroj AS [Broj Otp.], CarJCI AS [Broj JCI], CarDatum AS [Od datuma], " & _
                            "CarRokCarinjenja AS [Rok carinjenja], RecID, Stanica " & _
                            "FROM SlogKalk " & _
                            "WHERE (dbo.SlogKalk.DatumUlaza = " & "'" & DatumIzvestaja.Value.Month.ToString & "." & DatumIzvestaja.Value.Day.ToString & "." & DatumIzvestaja.Value.Year.ToString & "') " & " AND (BrojVoza = " & CType(tbBrojVoza.Text, Int32) & ") AND (SatVoza = '" & tbSatVoza.Text & "') AND (Stanica = '" & tbStanica.Text & "') " & _
                            "ORDER BY UlEtiketa, OtpStanica, OtpBroj"


        ''mDatumVoza = DatumUlaza.Value.ToShortDateString


        '"WHERE (dbo.SlogKalk.DatumUlaza = " & "'" & Today.Month.ToString & "." & Today.Day.ToString & "." & Today.Year.ToString & "') " & " AND (BrojVoza = " & CType(tbBrojVoza.Text, Int32) & ") AND (SatVoza = '" & tbSatVoza.Text & "') AND (Stanica = '" & tbStanica.Text & "') " & _
        ''"ORDER BY UlEtiketa, OtpStanica, OtpBroj"


        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, DbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)

        Do While rdrRm.Read()

            _col0 = rdrRm.Item(0)
            If _col0 = "4" Then
                _col0 = "Tranzit"
            Else
                _col0 = "Uvoz"
            End If
            If IsDBNull(rdrRm.Item(1)) Then
                _col1 = 0
            Else
                _col1 = rdrRm.Item(1)
            End If
            If IsDBNull(rdrRm.Item(4)) Then
                _col3 = "0"
            Else
                _col3 = rdrRm.Item(4)
            End If
            If IsDBNull(rdrRm.Item(5)) Then
                _col4 = Today()
            Else
                _col4 = rdrRm.Item(5)
            End If
            If IsDBNull(rdrRm.Item(6)) Then
                _col5 = Today()
            Else
                _col5 = rdrRm.Item(6)
            End If
            If IsDBNull(rdrRm.Item(7)) Then
                _col6 = 0
            Else
                _col6 = rdrRm.Item(7)
            End If
            If IsDBNull(rdrRm.Item(8)) Then
                _col7 = "0"
            Else
                _col7 = rdrRm.Item(8)
            End If

            dtKorekcija.NewRow()
            dtKorekcija.Rows.Add(New Object() {_col0, _col1, rdrRm.GetString(2), rdrRm.GetInt32(3), _col3, _col4, _col5, rdrRm.GetInt32(7), rdrRm.GetString(8)})

        Loop

        rdrRm.Close()
        DbVeza.Close()
        dgKorekcija.Refresh()

        Me.btnFormirajVoz.Visible = False
        Me.btnUpisUBazu.Visible = True
        Me.btnUpisUBazu.Focus()
        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub KorekcijaPoNajavi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatGrid()
        dtKorekcija.Clear()
        Me.tbStanica.Text = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)



    End Sub
    Private Sub FormatGrid()
        'Col1.AutoIncrement = True
        'Col1.ReadOnly = True

        If dsKorekcija Is Nothing Then
            dgKorekcija.DataSource = dtKorekcija
        Else
            If mNajava Is Nothing Then
            Else
                dgKorekcija.DataSource = dtKorekcija
            End If
            dgKorekcija.DataSource = dsKorekcija.Tables(0)
        End If

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        dtKorekcija.Clear()
        Me.btnFormirajVoz.Visible = True
        Me.btnUpisUBazu.Visible = False

        Close()

    End Sub

    Private Sub btnUpisUBazu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpisUBazu.Click
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Dim _UKK As Int32
        Dim _recID As Int32
        Dim _Stanica As Int32
        Dim KorekcijaRed As DataRow
        Dim sql_Kalk As String
        Dim slogTrans As SqlTransaction

        _UKK = dtKorekcija.Rows.Count

        If _UKK > 0 Then

            Dim myCommandKalk As SqlCommand
            Dim ra As Int32
            Dim _CarJCI As String
            Dim _Datum1 As Date
            Dim _Datum2 As Date

            For Each KorekcijaRed In dtKorekcija.Rows
                If DbVeza.State = ConnectionState.Closed Then
                    DbVeza.Open()
                End If

                _recID = KorekcijaRed.Item("RecID")
                _Stanica = KorekcijaRed.Item("Stanica")
                _CarJCI = KorekcijaRed.Item("JCI")
                _Datum1 = KorekcijaRed.Item("DatumOd")
                _Datum2 = KorekcijaRed.Item("RokCarinjenja")


                If _Datum1 >= _Datum2 Then
                    MsgBox("Datumi nisu uskladjeni! Datum roka carinjenja mora biti veci od dana prijavljivanja Carini.")
                    Exit For
                End If

                sql_Kalk = "UPDATE SlogKalk " & _
                           "SET CarJCI = '" & _CarJCI & "' ," & _
                           "CarDatum = " & "'" & _Datum1.Month.ToString & "." & _Datum1.Day.ToString & "." & _Datum1.Year.ToString & "' , " & _
                           "CarRokCarinjenja = " & "'" & _Datum2.Month.ToString & "." & _Datum2.Day.ToString & "." & _Datum2.Year.ToString & "'  " & _
                           "WHERE ( dbo.SlogKalk.RecID = " & _recID & ") AND ( dbo.SlogKalk.Stanica = '" & _Stanica & "' )"

                myCommandKalk = New SqlCommand(sql_Kalk, DbVeza)

                Try
                    ra = myCommandKalk.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "Greska pri upisu u bazu", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                DbVeza.Close()
            Next

            Cursor.Current = System.Windows.Forms.Cursors.Default
            dtKorekcija.Clear()
            Me.btnUpisUBazu.Visible = False
            Me.btnFormirajVoz.Visible = True
            Close()

        Else
            MessageBox.Show("Nepostojeci podaci !", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DatumIzvestaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumIzvestaja.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim KorekcijaRed As DataRow
        Dim _corr As Date = Me.DateTimePicker1.Value.ToShortDateString

        For Each KorekcijaRed In dtKorekcija.Rows
            KorekcijaRed.Item("RokCarinjenja") = _corr
        Next
    End Sub
End Class
