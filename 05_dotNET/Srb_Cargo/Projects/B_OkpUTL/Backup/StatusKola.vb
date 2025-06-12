Public Class StatusKola
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVlasnistvo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblVlasnistvo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Individualni broj kola"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(152, 17)
        Me.TextBox1.MaxLength = 12
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(88, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker1.Location = New System.Drawing.Point(152, 48)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Datum"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(80, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Prikaži"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(232, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Zatvori"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Vlasništvo"
        '
        'lblVlasnistvo
        '
        Me.lblVlasnistvo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblVlasnistvo.Location = New System.Drawing.Point(152, 84)
        Me.lblVlasnistvo.Name = "lblVlasnistvo"
        Me.lblVlasnistvo.Size = New System.Drawing.Size(112, 23)
        Me.lblVlasnistvo.TabIndex = 7
        '
        'StatusKola
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(392, 186)
        Me.Controls.Add(Me.lblVlasnistvo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StatusKola"
        Me.Text = "Provera statusa vlasništva kola"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim bUprava As String = ""
        Dim bTara As String = ""
        Dim bSerija As String = ""
        Dim bOsovine As String = ""
        Dim bVlasnik As String = ""
        Dim bVrsta As String = ""
        Dim bDatumOd1 As DateTime
        Dim bDatumDo1 As DateTime
        Dim bNasaoIKP1 As Boolean = False
        Dim bNasaoIKP2 As Boolean = False
        Dim bRIVDaNe As String = ""
        Dim bDatumOd2 As DateTime
        Dim Poruka As String

        Dim bIBK1 As String = TextBox1.Text
        Dim bDatum1 As DateTime = DateTimePicker1.Value
        Dim bPV As String = ""


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim uspKomanda1 As New SqlClient.SqlCommand("nmNadjiIBK_T", OkpDbVeza)
        Dim uspKomanda1 As New SqlClient.SqlCommand("roba1708.nmbNadjiIBK", OkpDbVeza)
        uspKomanda1.CommandType = CommandType.StoredProcedure

        Dim ulIBK1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
        ulIBK1.Direction = ParameterDirection.Input
        uspKomanda1.Parameters("@inIBK").Value = bIBK1

        Dim ulDatum As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@inDatum", SqlDbType.DateTime, 8))
        ulDatum.Direction = ParameterDirection.Input
        uspKomanda1.Parameters("@inDatum").Value = bDatum1

        Dim ulSkrUprava1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outUprava", SqlDbType.Char, 6))
        ulSkrUprava1.Direction = ParameterDirection.Output

        Dim ulTara1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outTara", SqlDbType.Int))
        ulTara1.Direction = ParameterDirection.Output

        Dim ulSerija1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outSerija", SqlDbType.Char, 11))
        ulSerija1.Direction = ParameterDirection.Output

        Dim ulBrojOsovina1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outOsovine", SqlDbType.Int))
        ulBrojOsovina1.Direction = ParameterDirection.Output

        Dim ulVlasnistvo1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVlasnik", SqlDbType.Char, 1))
        ulVlasnistvo1.Direction = ParameterDirection.Output

        Dim ulVrsta1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
        ulVrsta1.Direction = ParameterDirection.Output

        Dim izlDatumOd As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outDatumOd", SqlDbType.DateTime, 8))
        izlDatumOd.Direction = ParameterDirection.Output

        Dim izlDatumDo As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outDatumDo", SqlDbType.DateTime, 8))
        izlDatumDo.Direction = ParameterDirection.Output

        Dim izlPovratnaVrednost1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlPovratnaVrednost1.Direction = ParameterDirection.Output

        Try

            uspKomanda1.ExecuteScalar()

            bUprava = uspKomanda1.Parameters("@outUprava").Value
            'tbUprava.Text = mUprava
            bTara = uspKomanda1.Parameters("@outTara").Value
            bSerija = uspKomanda1.Parameters("@outSerija").Value
            bOsovine = uspKomanda1.Parameters("@outOsovine").Value
            bVlasnik = uspKomanda1.Parameters("@outVlasnik").Value
            If uspKomanda1.Parameters("@outVrsta").Value = "1" Then
                bVrsta = "O"
            Else
                bVrsta = "S"
            End If
            bDatumOd1 = uspKomanda1.Parameters("@outDatumOd").Value
            bDatumDo1 = uspKomanda1.Parameters("@outDatumDo").Value
            bNasaoIKP1 = True
        Catch sqlexp As Exception
            Poruka = sqlexp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bNasaoIKP1 = False
        Finally
            OkpDbVeza.Close()
            uspKomanda1.Dispose()
        End Try


        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If


        Dim uspKomanda2 As New SqlClient.SqlCommand("roba1708.bNadjiIBKIzRIVa", DbVeza)
        uspKomanda2.CommandType = CommandType.StoredProcedure


        Dim ulIBK2 As SqlClient.SqlParameter = uspKomanda2.Parameters.Add(New SqlClient.SqlParameter("@inIBK2", SqlDbType.Char, 12))
        ulIBK2.Direction = ParameterDirection.Input
        uspKomanda2.Parameters("@inIBK2").Value = bIBK1

        Dim izlDatum2 As SqlClient.SqlParameter = uspKomanda2.Parameters.Add(New SqlClient.SqlParameter("@outDatumOd", SqlDbType.SmallDateTime, 4))
        izlDatum2.Direction = ParameterDirection.Output

        Dim izlRIV As SqlClient.SqlParameter = uspKomanda2.Parameters.Add(New SqlClient.SqlParameter("@outRIVDaNe", SqlDbType.Char, 1))
        izlRIV.Direction = ParameterDirection.Output

        'Dim ipVrsta1 As SqlClient.SqlParameter = uspKomanda1.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
        'ipVrsta1.Direction = ParameterDirection.Output

        Dim izlPovratnaVrednost2 As SqlClient.SqlParameter = uspKomanda2.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlPovratnaVrednost2.Direction = ParameterDirection.Output

        Try

            uspKomanda2.ExecuteScalar()

            bRIVDaNe = uspKomanda2.Parameters("@outRIVDaNe").Value
            bDatumOd2 = uspKomanda2.Parameters("@outDatumOd").Value
            bPV = uspKomanda2.Parameters("@outretVal").Value
            If bPV = "" Then
                bNasaoIKP2 = True
            Else
                bNasaoIKP2 = False
            End If
        Catch sqlexp As Exception
            Poruka = sqlexp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            bNasaoIKP2 = False
        Finally
            DbVeza.Close()
            uspKomanda2.Dispose()
        End Try

        If bVlasnik = "Z" And brivdane = "D" Then
            bVlasnik = "Z"
        ElseIf bVlasnik = "P" And bRIVDaNe = "N" Then
            bVlasnik = "P"
        ElseIf bVlasnik = "Z" And bRIVDaNe = "N" Then
            If bDatumOd1 < bDatumOd2 Then
                bVlasnik = "P"
            End If
        ElseIf bVlasnik = "P" And bRIVDaNe = "D" Then
            If bDatumOd1 < bDatumOd2 Then
                bVlasnik = "Z"
            End If
        ElseIf bVlasnik = "" Then
            ' pretraga iz tabele rezima

            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            'Dim uspKomanda As New SqlClient.SqlCommand("spNadjiSveIzIBK", DbVeza)
            Dim uspKomanda As New SqlClient.SqlCommand("roba1708.spNadjiSveIzIBKb", DbVeza)
            uspKomanda.CommandType = CommandType.StoredProcedure

            Dim upIBK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@inIBK", SqlDbType.Char, 12))
            upIBK.Direction = ParameterDirection.Input
            uspKomanda.Parameters("@inIBK").Value = bIBK1

            Dim ipSkrUprava As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSkrUprava", SqlDbType.Char, 6))
            ipSkrUprava.Direction = ParameterDirection.Output

            Dim ipVlasnistvo As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVlasnistvo", SqlDbType.Char, 1))
            ipVlasnistvo.Direction = ParameterDirection.Output

            Dim ipRIV As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRIV", SqlDbType.Char, 1))
            ipRIV.Direction = ParameterDirection.Output

            Dim ipSerija As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSerija", SqlDbType.Char, 11))
            ipSerija.Direction = ParameterDirection.Output

            Dim ipBrojOsovina As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outBrojOsovina", SqlDbType.Int))
            ipBrojOsovina.Direction = ParameterDirection.Output

            Dim ipVrsta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVrsta", SqlDbType.Char, 1))
            ipVrsta.Direction = ParameterDirection.Output

            Dim ipKontrBroj As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBroj", SqlDbType.Int))
            ipKontrBroj.Direction = ParameterDirection.Output

            Dim ipKontrBrojOK As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKontrBrojOK", SqlDbType.Char, 1))
            ipKontrBrojOK.Direction = ParameterDirection.Output

            Dim ipKolaICFIzuzeta As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outKolaICFIzuzeta", SqlDbType.Char, 1))
            ipKolaICFIzuzeta.Direction = ParameterDirection.Output

            Dim ipPovratnaVrednost As SqlClient.SqlParameter = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.NVarChar, 100))
            ipPovratnaVrednost.Direction = ParameterDirection.Output

            Try
                uspKomanda.ExecuteScalar()
                bUprava = uspKomanda.Parameters("@outSkrUprava").Value
                'tbUprava.Text = mUprava
                'tbVlasnik.Text = uspKomanda.Parameters("@outVlasnistvo").Value
                bVlasnik = uspKomanda.Parameters("@outVlasnistvo").Value
                'tbSerija.Text = uspKomanda.Parameters("@outSerija").Value
                bSerija = uspKomanda.Parameters("@outSerija").Value
                'tbOsovine.Text = uspKomanda.Parameters("@outBrojOsovina").Value
                bOsovine = uspKomanda.Parameters("@outBrojOsovina").Value
                If uspKomanda.Parameters("@outVrsta").Value = "1" Then
                    'tbVrsta.Text = "O"
                    bVrsta = "O"
                Else
                    'tbVrsta.Text = "S"
                    bVrsta = "P"
                End If
                'mICF = uspKomanda.Parameters("@outKolaICFIzuzeta").Value
                mIBK_KB = uspKomanda.Parameters("@outKontrBrojOK").Value
                bPV = uspKomanda.Parameters("@outPovratnaVrednost").Value
                'If mIBK_KB = "D" Then
                '    ErrorProvider1.SetError(fxIBK, "")
                '    StatusBar1.Text = ""
                'Else
                '    If mkBrojPokusaja > 3 Then
                '        mkBrojPokusaja = 1
                '        ErrorProvider1.SetError(Button3, "")
                '        Dim KolaNotFound As New KolaExtra
                '        KolaNotFound.ShowDialog()

                '        tbVlasnik.Text = mVlasnik
                '        tbSerija.Text = mSerija
                '        tbVrsta.Text = mVrsta
                '        tbOsovine.Text = mOsovine

                '        Me.tbTara.SelectAll()
                '        Me.tbTara.Focus()
                '    Else
                '        mkBrojPokusaja = mkBrojPokusaja + 1
                '        ErrorProvider1.SetError(Button3, "Neispravan kontrolni broj!")
                '        fxIBK.Focus()
                '    End If
                'End If
            Catch sqlexp As Exception
                Poruka = sqlexp.Message & " SQL greska u programu!"
            Catch Exp As Exception
                'If fxIBK.Text = Nothing Then
                '    If dtKola.Rows.Count > 0 Then
                '        StatusBar1.Text = ""
                '        Me.fxIBK.BackColor = System.Drawing.Color.White
                '        Me.fxIBK.ForeColor = System.Drawing.Color.Black
                '        Me.btnPrihvati.Focus()
                '    Else
                '        rv = Err.Description & "??"
                '        StatusBar1.Text = rv
                '        Me.fxIBK.Focus()
                '    End If
                'Else
                '    rv = Err.Description & "??"
                '    StatusBar1.Text = rv
                '    Me.fxIBK.Focus()
                'End If
            Finally
                DbVeza.Close()
                uspKomanda.Dispose()
            End Try

        End If

        lblVlasnistvo.Text = ""
        If bVlasnik = "Z" Then
            lblVlasnistvo.Text = "ŽELEZNIÈKA"
        ElseIf bVlasnik = "P" Then
            lblVlasnistvo.Text = "PRIVATNA"
        End If

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
End Class
