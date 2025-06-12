Imports System.Data.SqlClient
Public Class Form2

    Inherits System.Windows.Forms.Form
    Public SQL_CONNECTION_STRING As String = ""
    Public OKPSQL_CONNECTION_STRING As String = ""
    Public CENE_CONNECTION_STRING As String = ""
    Public ZSSQL_CONNECTION_STRING As String = ""
    Public DbVeza As New SqlConnection
    Public OkpDbVeza As New SqlConnection
    Public DbVezaCene As New SqlConnection
    Public ZsDbVeza As New SqlConnection
    Public cnWinRoba As New SqlConnection
    Public StanicaUnosa As String = ""
    Public CarinskiAgent As String = ""
    Public PrikazKalkulacije As String = ""

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents tbUser As System.Windows.Forms.TextBox
    Friend WithEvents tbPass As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.tbUser = New System.Windows.Forms.TextBox
        Me.tbPass = New System.Windows.Forms.TextBox
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblPass = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(148, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(64, 144)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 9
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(200, 200)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 56)
        Me.btnPrihvati.TabIndex = 2
        Me.btnPrihvati.Text = "Prihvati"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(328, 200)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 56)
        Me.btnOtkazi.TabIndex = 3
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbUser
        '
        Me.tbUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUser.Location = New System.Drawing.Point(312, 48)
        Me.tbUser.MaxLength = 4
        Me.tbUser.Name = "tbUser"
        Me.tbUser.TabIndex = 0
        Me.tbUser.Text = ""
        '
        'tbPass
        '
        Me.tbPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPass.Location = New System.Drawing.Point(312, 104)
        Me.tbPass.MaxLength = 6
        Me.tbPass.Name = "tbPass"
        Me.tbPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.tbPass.TabIndex = 1
        Me.tbPass.Text = ""
        '
        'lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(192, 56)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(80, 23)
        Me.lblUser.TabIndex = 14
        Me.lblUser.Text = "Korisnicko ime"
        '
        'lblPass
        '
        Me.lblPass.Location = New System.Drawing.Point(208, 112)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(72, 23)
        Me.lblPass.TabIndex = 15
        Me.lblPass.Text = "Lozinka"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(16, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 48)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Pristup nije dozvoljen!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 264)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(440, 22)
        Me.StatusBar1.TabIndex = 17
        Me.StatusBar1.Text = "StatusBar1"
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=BGNEM11214XWSC;user id=radnik;password=roba2006;data source=""10.0." & _
        "4.31"";persist security info=False;initial catalog=OkpWinRoba"
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 286)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.tbPass)
        Me.Controls.Add(Me.tbUser)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Sub sUcitajINI(ByRef opPovVrednost As String)
        'INI datoteka mora biti u istom direktorijumu gde je i aplikacija

        opPovVrednost = ""
        Dim linijaText As String = ""
        Dim ii As Int16 = 0
        Dim parNaziv As String = ""
        Dim parVrednost As String = ""
        Try
            FileOpen(1, "Roba.ini", OpenMode.Input)
            Do Until EOF(1)
                parNaziv = ""
                parVrednost = ""
                linijaText = LineInput(1)
                ii = linijaText.IndexOf("=")
                parNaziv = linijaText.Substring(0, ii)
                parVrednost = linijaText.Substring(ii + 1)
                Select Case parNaziv
                    Case "SQL_CONNECTION_STRING"
                        SQL_CONNECTION_STRING = parVrednost
                    Case "CENE_CONNECTION_STRING"
                        CENE_CONNECTION_STRING = parVrednost
                    Case "ZSSQL_CONNECTION_STRING"
                        ZSSQL_CONNECTION_STRING = parVrednost
                    Case "OKPSQL_CONNECTION_STRING"
                        OKPSQL_CONNECTION_STRING = parVrednost
                    Case "STANICA"
                        StanicaUnosa = parVrednost
                    Case "AGENT"
                        CarinskiAgent = parVrednost
                    Case "WHITE"
                        PrikazKalkulacije = parVrednost
                    Case Else
                        opPovVrednost = "Parametar: " & parNaziv & " iz INI datoteke - NE POSTOJI !"
                End Select
                linijaText = ""
            Loop
            If SQL_CONNECTION_STRING <> "" And CENE_CONNECTION_STRING <> "" Then
                Dim connRoba As New SqlConnection(SQL_CONNECTION_STRING)
                Dim OkpconnRoba As New SqlConnection(OKPSQL_CONNECTION_STRING)
                Dim connCene As New SqlConnection(CENE_CONNECTION_STRING)
                DbVeza = connRoba
                OkpDbVeza = OkpconnRoba
                cnWinRoba = connRoba
                DbVezaCene = connCene
            End If
            If ZSSQL_CONNECTION_STRING <> "" Then
                Dim ZsconnRoba As New SqlConnection(ZSSQL_CONNECTION_STRING)
                ZsDbVeza = ZsconnRoba
            End If
        Catch ex As Exception
            opPovVrednost = "Greška u otvaranju INI datoteke !" & vbCrLf & Err.Description
        Finally
            FileClose(1)
        End Try
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim opPovVrednost As String = ""
        'Microsoft.VisualBasic.Mid(SQL_CONNECTION_STRING, 1, 20) & " ..."
        Try
            sUcitajINI(opPovVrednost)
            If opPovVrednost = "" Then
                StatusBar1.Text = "  ID=" & Microsoft.VisualBasic.Mid(StanicaUnosa, 11, 12)
                'StatusBar1.Text = Microsoft.VisualBasic.Mid(SQL_CONNECTION_STRING, 1, 16) & " ;  ID=" & Microsoft.VisualBasic.Mid(StanicaUnosa, 11, 12)


            Else
                MsgBox(opPovVrednost, MsgBoxStyle.Critical, "Greška")
            End If
        Catch
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Greška")
        End Try


    End Sub
    Public Sub sNadjiNaziv(ByVal ipTabela As String, ByVal ipSifra1 As String, _
                           ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                           ByRef opGrupa As String, ByRef opCount As Int16, ByRef opNaziv As String, _
                           ByRef opPovVrednost As String)


        'ipTabela=Tabela koja se koristi
        'ipSifra1=Sifra1 iz te tabele
        'ipSifra2=Sifra2 iz te tabele(ako je ima)
        'ipSifra3=Sifra3 iz te tabele(ako je ima)
        'broj neuspesnih pokusaja
        'opNaziv=povratna vrednost naziva
        'opPovVrednost=povratna vrednost 

        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True

        Select Case ipTabela
            ''Case "UicUprave"
            ''    sqlText = "SELECT Oznaka FROM UicUprave WHERE SifraUprave = '" & ipSifra1 & "'"
            ''Case "UicOperateri"
            ''    sqlText = "SELECT Oznaka FROM UicOperateri WHERE Operater = '" & ipSifra1 & "' AND SifraUprave = '" & ipSifra2 & "'"
            ''Case "UicStanice"
            ''    sqlText = "SELECT Naziv FROM UicStanice WHERE SifraStanice = '" & ipSifra1 & "'"
            ''Case "NHMPozicije"
            ''    sqlText = "SELECT Naziv FROM NHMPozicije WHERE NHMPozicije.NHMSifra = '" & ipSifra1 & "'"
            ''Case "Tarife"
            ''    sqlText = "SELECT Naziv WHERE Oznaka = '" & ipSifra1 & "'"
            ''Case "TabNaziv"
            ''    sqlText = "SELECT SifTab FROM TabNaziv WHERE Ugovor = '" & ipSifra1 & "'"
            Case "UserTab"
                'sqlText = "SELECT UserID, Lozinka FROM UserTab WHERE UserID = '" & ipSifra1 & "' AND Lozinka = '" & ipSifra2 & "'"
                sqlText = "SELECT Grupa, UserID, Lozinka, Stanica FROM UserTab WHERE UserID = '" & ipSifra1 & "' AND Lozinka = '" & ipSifra2 & "' AND Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "'"
                ''Case "Ugovori"
                ''    sqlText = " SELECT  dbo.Komitent.Naziv, dbo.Komitent.Mesto " _
                ''            & " FROM    dbo.Cena_UgovorKP INNER JOIN " _
                ''            & " dbo.Ugovori ON dbo.Cena_UgovorKP.BrojUgovora = dbo.Ugovori.BrojUgovora INNER JOIN " _
                ''            & " dbo.Komitent ON dbo.Ugovori.SifraKorisnika = dbo.Komitent.Sifra " _
                ''            & " WHERE dbo.Ugovori.BrojUgovora = '" & ipSifra1 & "'"
                ''Case "Komitent"
                ''    sqlText = "SELECT Naziv From Komitent WHERE Sifra = '" & ipSifra1 & "'"
                ''Case "UNalepnica"
                ''sqlText = "SELECT UlEtiketa From dbo.SlogKalk WHERE UlEtiketa = '" & ipSifra1 & "' AND ZsUlPrelaz = '" & ipSifra2 & "'"
            Case Else
                opPovVrednost = "Data Table: " & ipTabela & " - NE POSTOJI !!! , Greska u Programu"
        End Select

        If opPovVrednost = "" Then
            Dim uspKomanda As New SqlClient.SqlCommand(sqlText, OkpDbVeza)
            Try
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                Else
                    closeConn = False
                End If
                opNaziv = uspKomanda.ExecuteScalar()
                If opNaziv = Nothing Then opPovVrednost = "Ne postoji takav podatak!" ' SLOG NE POSTOJI !!!
                'Catch SQLExp As SqlException
                '    opPovVrednost = SQLExp.Message & "??"  'Greska - SQL greska
            Catch Exp As Exception
                opPovVrednost = Err.Description & " ?"  'Greska - bilo koja"
            Finally
                If closeConn Then OkpDbVeza.Close()
                uspKomanda.Dispose()
            End Try
        End If
    End Sub
    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim xNaziv As String = ""
        Dim xGrupa As String = ""
        Dim xPovVrednost As String = ""

        sNadjiNaziv("UserTab", tbUser.Text, tbPass.Text, "", xGrupa, 1, xNaziv, xPovVrednost)

        If xPovVrednost <> "" Then
            Label1.Visible = True
            Me.PictureBox2.Visible = True
            tbUser.Focus()


        Else
            If Microsoft.VisualBasic.Left(xNaziv, 13) <> "Administrator" Then
                Label1.Visible = True
                Me.PictureBox2.Visible = True
                tbUser.Focus()
            Else
                Label1.Visible = False
                Me.PictureBox2.Visible = False
                mUserID = tbUser.Text

                Dim FormUnos As New Form7
                FormUnos.ShowDialog()
                Close()

            End If
        End If

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()
    End Sub


    Private Sub tbUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUser.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPass.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))

        End If
    End Sub
End Class
