Public Class frmUnosKorisnici
    Inherits System.Windows.Forms.Form

    'Dim cbPrvaLinija As String = ""
    Dim cbKorGrupaDEFAULT As String = "Odaberite Grupu"

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
    Friend WithEvents lblKorGrupa As System.Windows.Forms.Label
    Friend WithEvents lblNapomena As System.Windows.Forms.Label
    Friend WithEvents txtNapomena As System.Windows.Forms.TextBox
    Friend WithEvents btnSacuvaj As System.Windows.Forms.Button
    Friend WithEvents txtKorisnikL As System.Windows.Forms.TextBox
    Friend WithEvents lblKorisnikL As System.Windows.Forms.Label
    Friend WithEvents lblLozinka As System.Windows.Forms.Label
    Friend WithEvents txtLozinka As System.Windows.Forms.TextBox
    Friend WithEvents txtPrezime As System.Windows.Forms.TextBox
    Friend WithEvents lblPrezime As System.Windows.Forms.Label
    Friend WithEvents txtIme As System.Windows.Forms.TextBox
    Friend WithEvents lblIme As System.Windows.Forms.Label
    Friend WithEvents lblPrivilegije As System.Windows.Forms.Label
    Friend WithEvents cbPrivilegije As System.Windows.Forms.ComboBox
    Friend WithEvents lbldAktiviranja As System.Windows.Forms.Label
    Friend WithEvents lbldPromeneLozinke As System.Windows.Forms.Label
    Friend WithEvents lblZadnjiLogin As System.Windows.Forms.Label
    Friend WithEvents lblLozinkaDana As System.Windows.Forms.Label
    Friend WithEvents tbLozinkaDana As System.Windows.Forms.TrackBar
    Friend WithEvents txtLozinkaDana As System.Windows.Forms.TextBox
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbKorGrupa As System.Windows.Forms.ComboBox
    Friend WithEvents dtpdAktiviranja As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpdPromeneLozinke As System.Windows.Forms.DateTimePicker
    Friend WithEvents txttsZadnjiLogin As System.Windows.Forms.TextBox
    Friend WithEvents lblAktivan As System.Windows.Forms.Label
    Friend WithEvents chkbAktivan As System.Windows.Forms.CheckBox
    Friend WithEvents btnPonisti As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblKorGrupa = New System.Windows.Forms.Label
        Me.lblNapomena = New System.Windows.Forms.Label
        Me.txtNapomena = New System.Windows.Forms.TextBox
        Me.btnSacuvaj = New System.Windows.Forms.Button
        Me.txtKorisnikL = New System.Windows.Forms.TextBox
        Me.lblKorisnikL = New System.Windows.Forms.Label
        Me.lblLozinka = New System.Windows.Forms.Label
        Me.txtLozinka = New System.Windows.Forms.TextBox
        Me.txtPrezime = New System.Windows.Forms.TextBox
        Me.lblPrezime = New System.Windows.Forms.Label
        Me.txtIme = New System.Windows.Forms.TextBox
        Me.lblIme = New System.Windows.Forms.Label
        Me.cbKorGrupa = New System.Windows.Forms.ComboBox
        Me.lblPrivilegije = New System.Windows.Forms.Label
        Me.cbPrivilegije = New System.Windows.Forms.ComboBox
        Me.lbldAktiviranja = New System.Windows.Forms.Label
        Me.dtpdAktiviranja = New System.Windows.Forms.DateTimePicker
        Me.lbldPromeneLozinke = New System.Windows.Forms.Label
        Me.dtpdPromeneLozinke = New System.Windows.Forms.DateTimePicker
        Me.lblZadnjiLogin = New System.Windows.Forms.Label
        Me.txttsZadnjiLogin = New System.Windows.Forms.TextBox
        Me.lblLozinkaDana = New System.Windows.Forms.Label
        Me.tbLozinkaDana = New System.Windows.Forms.TrackBar
        Me.txtLozinkaDana = New System.Windows.Forms.TextBox
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.lblAktivan = New System.Windows.Forms.Label
        Me.chkbAktivan = New System.Windows.Forms.CheckBox
        Me.btnPonisti = New System.Windows.Forms.Button
        CType(Me.tbLozinkaDana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblKorGrupa
        '
        Me.lblKorGrupa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblKorGrupa.Location = New System.Drawing.Point(8, 96)
        Me.lblKorGrupa.Name = "lblKorGrupa"
        Me.lblKorGrupa.Size = New System.Drawing.Size(104, 20)
        Me.lblKorGrupa.TabIndex = 0
        Me.lblKorGrupa.Text = "Korisnicka Grupa:"
        Me.lblKorGrupa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNapomena
        '
        Me.lblNapomena.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblNapomena.Location = New System.Drawing.Point(40, 272)
        Me.lblNapomena.Name = "lblNapomena"
        Me.lblNapomena.Size = New System.Drawing.Size(72, 20)
        Me.lblNapomena.TabIndex = 4
        Me.lblNapomena.Text = "Napomena:"
        Me.lblNapomena.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNapomena
        '
        Me.txtNapomena.Location = New System.Drawing.Point(120, 272)
        Me.txtNapomena.Multiline = True
        Me.txtNapomena.Name = "txtNapomena"
        Me.txtNapomena.Size = New System.Drawing.Size(400, 56)
        Me.txtNapomena.TabIndex = 5
        Me.txtNapomena.Text = ""
        '
        'btnSacuvaj
        '
        Me.btnSacuvaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSacuvaj.Location = New System.Drawing.Point(368, 336)
        Me.btnSacuvaj.Name = "btnSacuvaj"
        Me.btnSacuvaj.Size = New System.Drawing.Size(72, 24)
        Me.btnSacuvaj.TabIndex = 9
        Me.btnSacuvaj.Text = "Sacuvaj"
        '
        'txtKorisnikL
        '
        Me.txtKorisnikL.Location = New System.Drawing.Point(120, 24)
        Me.txtKorisnikL.MaxLength = 0
        Me.txtKorisnikL.Multiline = True
        Me.txtKorisnikL.Name = "txtKorisnikL"
        Me.txtKorisnikL.Size = New System.Drawing.Size(112, 20)
        Me.txtKorisnikL.TabIndex = 10
        Me.txtKorisnikL.Text = ""
        '
        'lblKorisnikL
        '
        Me.lblKorisnikL.Location = New System.Drawing.Point(56, 24)
        Me.lblKorisnikL.Name = "lblKorisnikL"
        Me.lblKorisnikL.Size = New System.Drawing.Size(56, 20)
        Me.lblKorisnikL.TabIndex = 11
        Me.lblKorisnikL.Text = "Korisnik:"
        Me.lblKorisnikL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLozinka
        '
        Me.lblLozinka.Location = New System.Drawing.Point(304, 24)
        Me.lblLozinka.Name = "lblLozinka"
        Me.lblLozinka.Size = New System.Drawing.Size(48, 20)
        Me.lblLozinka.TabIndex = 13
        Me.lblLozinka.Text = "Lozinka:"
        Me.lblLozinka.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLozinka
        '
        Me.txtLozinka.Location = New System.Drawing.Point(360, 24)
        Me.txtLozinka.MaxLength = 0
        Me.txtLozinka.Multiline = True
        Me.txtLozinka.Name = "txtLozinka"
        Me.txtLozinka.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtLozinka.Size = New System.Drawing.Size(112, 20)
        Me.txtLozinka.TabIndex = 12
        Me.txtLozinka.Text = ""
        '
        'txtPrezime
        '
        Me.txtPrezime.Location = New System.Drawing.Point(120, 64)
        Me.txtPrezime.MaxLength = 0
        Me.txtPrezime.Name = "txtPrezime"
        Me.txtPrezime.Size = New System.Drawing.Size(160, 20)
        Me.txtPrezime.TabIndex = 14
        Me.txtPrezime.Text = ""
        '
        'lblPrezime
        '
        Me.lblPrezime.Location = New System.Drawing.Point(56, 64)
        Me.lblPrezime.Name = "lblPrezime"
        Me.lblPrezime.Size = New System.Drawing.Size(56, 20)
        Me.lblPrezime.TabIndex = 15
        Me.lblPrezime.Text = "Prezime:"
        Me.lblPrezime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIme
        '
        Me.txtIme.Location = New System.Drawing.Point(360, 64)
        Me.txtIme.MaxLength = 0
        Me.txtIme.Name = "txtIme"
        Me.txtIme.Size = New System.Drawing.Size(160, 20)
        Me.txtIme.TabIndex = 16
        Me.txtIme.Text = ""
        '
        'lblIme
        '
        Me.lblIme.Location = New System.Drawing.Point(320, 64)
        Me.lblIme.Name = "lblIme"
        Me.lblIme.Size = New System.Drawing.Size(32, 20)
        Me.lblIme.TabIndex = 17
        Me.lblIme.Text = "Ime:"
        Me.lblIme.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbKorGrupa
        '
        Me.cbKorGrupa.Location = New System.Drawing.Point(120, 96)
        Me.cbKorGrupa.Name = "cbKorGrupa"
        Me.cbKorGrupa.Size = New System.Drawing.Size(160, 21)
        Me.cbKorGrupa.TabIndex = 18
        '
        'lblPrivilegije
        '
        Me.lblPrivilegije.Location = New System.Drawing.Point(288, 96)
        Me.lblPrivilegije.Name = "lblPrivilegije"
        Me.lblPrivilegije.Size = New System.Drawing.Size(64, 20)
        Me.lblPrivilegije.TabIndex = 19
        Me.lblPrivilegije.Text = "Privilegije:"
        Me.lblPrivilegije.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbPrivilegije
        '
        Me.cbPrivilegije.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.cbPrivilegije.Location = New System.Drawing.Point(360, 96)
        Me.cbPrivilegije.Name = "cbPrivilegije"
        Me.cbPrivilegije.Size = New System.Drawing.Size(32, 21)
        Me.cbPrivilegije.TabIndex = 20
        '
        'lbldAktiviranja
        '
        Me.lbldAktiviranja.Location = New System.Drawing.Point(200, 184)
        Me.lbldAktiviranja.Name = "lbldAktiviranja"
        Me.lbldAktiviranja.Size = New System.Drawing.Size(64, 20)
        Me.lbldAktiviranja.TabIndex = 21
        Me.lbldAktiviranja.Text = "Aktiviranja:"
        Me.lbldAktiviranja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpdAktiviranja
        '
        Me.dtpdAktiviranja.Enabled = False
        Me.dtpdAktiviranja.Location = New System.Drawing.Point(272, 184)
        Me.dtpdAktiviranja.Name = "dtpdAktiviranja"
        Me.dtpdAktiviranja.Size = New System.Drawing.Size(216, 20)
        Me.dtpdAktiviranja.TabIndex = 22
        '
        'lbldPromeneLozinke
        '
        Me.lbldPromeneLozinke.Location = New System.Drawing.Point(160, 208)
        Me.lbldPromeneLozinke.Name = "lbldPromeneLozinke"
        Me.lbldPromeneLozinke.Size = New System.Drawing.Size(100, 20)
        Me.lbldPromeneLozinke.TabIndex = 23
        Me.lbldPromeneLozinke.Text = "Promena Lozinke:"
        Me.lbldPromeneLozinke.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpdPromeneLozinke
        '
        Me.dtpdPromeneLozinke.Enabled = False
        Me.dtpdPromeneLozinke.Location = New System.Drawing.Point(272, 208)
        Me.dtpdPromeneLozinke.Name = "dtpdPromeneLozinke"
        Me.dtpdPromeneLozinke.Size = New System.Drawing.Size(216, 20)
        Me.dtpdPromeneLozinke.TabIndex = 24
        '
        'lblZadnjiLogin
        '
        Me.lblZadnjiLogin.Location = New System.Drawing.Point(184, 232)
        Me.lblZadnjiLogin.Name = "lblZadnjiLogin"
        Me.lblZadnjiLogin.Size = New System.Drawing.Size(80, 20)
        Me.lblZadnjiLogin.TabIndex = 25
        Me.lblZadnjiLogin.Text = "Zadnji Login:"
        Me.lblZadnjiLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txttsZadnjiLogin
        '
        Me.txttsZadnjiLogin.Enabled = False
        Me.txttsZadnjiLogin.Location = New System.Drawing.Point(272, 232)
        Me.txttsZadnjiLogin.Name = "txttsZadnjiLogin"
        Me.txttsZadnjiLogin.Size = New System.Drawing.Size(216, 20)
        Me.txttsZadnjiLogin.TabIndex = 26
        Me.txttsZadnjiLogin.Text = ""
        '
        'lblLozinkaDana
        '
        Me.lblLozinkaDana.Location = New System.Drawing.Point(32, 128)
        Me.lblLozinkaDana.Name = "lblLozinkaDana"
        Me.lblLozinkaDana.Size = New System.Drawing.Size(80, 20)
        Me.lblLozinkaDana.TabIndex = 27
        Me.lblLozinkaDana.Text = "Lozinka Dana:"
        Me.lblLozinkaDana.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbLozinkaDana
        '
        Me.tbLozinkaDana.Location = New System.Drawing.Point(152, 120)
        Me.tbLozinkaDana.Maximum = 999
        Me.tbLozinkaDana.Name = "tbLozinkaDana"
        Me.tbLozinkaDana.Size = New System.Drawing.Size(376, 42)
        Me.tbLozinkaDana.TabIndex = 28
        Me.tbLozinkaDana.Value = 1
        '
        'txtLozinkaDana
        '
        Me.txtLozinkaDana.Location = New System.Drawing.Point(120, 128)
        Me.txtLozinkaDana.MaxLength = 3
        Me.txtLozinkaDana.Name = "txtLozinkaDana"
        Me.txtLozinkaDana.Size = New System.Drawing.Size(32, 20)
        Me.txtLozinkaDana.TabIndex = 29
        Me.txtLozinkaDana.Text = ""
        '
        'gb1
        '
        Me.gb1.Location = New System.Drawing.Point(120, 168)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(400, 96)
        Me.gb1.TabIndex = 30
        Me.gb1.TabStop = False
        Me.gb1.Text = "Datumi"
        '
        'lblAktivan
        '
        Me.lblAktivan.Location = New System.Drawing.Point(448, 96)
        Me.lblAktivan.Name = "lblAktivan"
        Me.lblAktivan.Size = New System.Drawing.Size(48, 20)
        Me.lblAktivan.TabIndex = 31
        Me.lblAktivan.Text = "Aktivan:"
        Me.lblAktivan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkbAktivan
        '
        Me.chkbAktivan.Location = New System.Drawing.Point(504, 96)
        Me.chkbAktivan.Name = "chkbAktivan"
        Me.chkbAktivan.Size = New System.Drawing.Size(16, 16)
        Me.chkbAktivan.TabIndex = 32
        '
        'btnPonisti
        '
        Me.btnPonisti.Location = New System.Drawing.Point(448, 336)
        Me.btnPonisti.Name = "btnPonisti"
        Me.btnPonisti.TabIndex = 33
        Me.btnPonisti.Text = "Poništi"
        '
        'frmUnosKorisnici
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.ClientSize = New System.Drawing.Size(528, 365)
        Me.Controls.Add(Me.btnPonisti)
        Me.Controls.Add(Me.chkbAktivan)
        Me.Controls.Add(Me.lblAktivan)
        Me.Controls.Add(Me.txtLozinkaDana)
        Me.Controls.Add(Me.tbLozinkaDana)
        Me.Controls.Add(Me.lblLozinkaDana)
        Me.Controls.Add(Me.txttsZadnjiLogin)
        Me.Controls.Add(Me.lblZadnjiLogin)
        Me.Controls.Add(Me.dtpdPromeneLozinke)
        Me.Controls.Add(Me.lbldPromeneLozinke)
        Me.Controls.Add(Me.dtpdAktiviranja)
        Me.Controls.Add(Me.lbldAktiviranja)
        Me.Controls.Add(Me.cbPrivilegije)
        Me.Controls.Add(Me.lblPrivilegije)
        Me.Controls.Add(Me.cbKorGrupa)
        Me.Controls.Add(Me.lblIme)
        Me.Controls.Add(Me.txtIme)
        Me.Controls.Add(Me.lblPrezime)
        Me.Controls.Add(Me.txtPrezime)
        Me.Controls.Add(Me.lblLozinka)
        Me.Controls.Add(Me.txtLozinka)
        Me.Controls.Add(Me.lblKorisnikL)
        Me.Controls.Add(Me.txtKorisnikL)
        Me.Controls.Add(Me.btnSacuvaj)
        Me.Controls.Add(Me.txtNapomena)
        Me.Controls.Add(Me.lblNapomena)
        Me.Controls.Add(Me.lblKorGrupa)
        Me.Controls.Add(Me.gb1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUnosKorisnici"
        Me.Text = "Ažuriranje Korisnika"
        CType(Me.tbLozinkaDana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub subInit()
        txtKorisnikL.Text = ""
        txtLozinka.Text = ""
        txtPrezime.Text = ""
        txtIme.Text = ""
        cbKorGrupa.Text = cbKorGrupaDEFAULT
        cbPrivilegije.Text = 0
        dtpdAktiviranja.Text = "1.1.2000"
        dtpdPromeneLozinke.Text = "1.1.2000"
        txtLozinkaDana.Text = 0
        txttsZadnjiLogin.Text = "2000.01.01 00:00:00"
        chkbAktivan.Checked = True
        txtNapomena.Text = ""
    End Sub
    Private Sub subAssign()
        txtKorisnikL.Text = Korisnici.f_KorisnikL
        txtLozinka.Text = Korisnici.f_Lozinka
        txtPrezime.Text = Korisnici.f_Prezime
        txtIme.Text = Korisnici.f_Ime
        cbKorGrupa.Text = Korisnici.f_KorGrupa
        cbPrivilegije.Text = Korisnici.f_Privilegije
        dtpdAktiviranja.Text = Korisnici.f_dAktiviranja
        dtpdPromeneLozinke.Text = Korisnici.f_dPromeneLozinke
        txtLozinkaDana.Text = Korisnici.f_LozinkaDana
        txttsZadnjiLogin.Text = Korisnici.f_tsZadnjiLogin
        chkbAktivan.Text = Korisnici.f_Aktivan
        txtNapomena.Text = Korisnici.f_Napomena
    End Sub
    Private Sub subAssignSave(ByRef GreskaOpis As String)
        GreskaOpis = fProveriKorGrupa("Polje: Korisnicka Grupa", cbKorGrupa.Text)
        If GreskaOpis = "" Then
            If Trim(txtKorisnikL.Text) = "" Then
                GreskaOpis = "Korisnicko Ime je OBAVEZNO za unos !"
            Else
                Try
                    Korisnici.f_KorisnikL = txtKorisnikL.Text
                    Korisnici.f_Lozinka = txtLozinka.Text
                    Korisnici.f_Prezime = txtPrezime.Text
                    Korisnici.f_Ime = txtIme.Text
                    Korisnici.f_KorGrupa = cbKorGrupa.Text
                    Korisnici.f_Privilegije = cbPrivilegije.Text
                    Korisnici.f_dAktiviranja = dtpdAktiviranja.Text
                    Korisnici.f_dPromeneLozinke = dtpdPromeneLozinke.Text
                    Korisnici.f_LozinkaDana = txtLozinkaDana.Text
                    Korisnici.f_tsZadnjiLogin = txttsZadnjiLogin.Text
                    Korisnici.f_Aktivan = chkbAktivan.Text
                    Korisnici.f_Napomena = txtNapomena.Text
                Catch
                    GreskaOpis = Err.Description
                End Try
            End If
        End If
    End Sub
    Private Sub subEnableControls()
        Select Case Korisnici.Akcija
            Case "dodaj"
                subInit()
                txtKorisnikL.Enabled = True
                txtLozinka.Enabled = False
                txtPrezime.Enabled = True
                txtIme.Enabled = True
                cbKorGrupa.Enabled = True
                cbPrivilegije.Enabled = True
                dtpdAktiviranja.Enabled = False
                dtpdPromeneLozinke.Enabled = False
                txtLozinkaDana.Enabled = True
                txttsZadnjiLogin.Enabled = False
                chkbAktivan.Enabled = True
                txtNapomena.Enabled = True
            Case "izmeni"
                subAssign()
                txtKorisnikL.Enabled = False
                txtLozinka.Enabled = True
                txtPrezime.Enabled = True
                txtIme.Enabled = True
                cbKorGrupa.Enabled = True
                cbPrivilegije.Enabled = True
                dtpdAktiviranja.Enabled = False
                dtpdPromeneLozinke.Enabled = False
                txtLozinkaDana.Enabled = True
                txttsZadnjiLogin.Enabled = False
                chkbAktivan.Enabled = True
                txtNapomena.Enabled = True
            Case Else
                MsgBox("Nepoznata Akcija: " & Korisnici.Akcija & " !?!", MsgBoxStyle.Critical, "Greška u programu")
        End Select
    End Sub
    Private Sub frmUnos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Korisnici.dwClosed = 0  'Inicijalno se stavlja kao da ce se postupak OBUSTAVITI
        subPuniComboKorGrupa()
        subEnableControls()
    End Sub
    Private Sub frmUnos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Korisnici.Akcija = "dodaj" Then
            txtKorisnikL.Focus()
        Else 'Akcija = "izmeni"
            txtPrezime.Focus()
        End If
    End Sub
    Private Sub btnSacuvaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacuvaj.Click
        Dim GreskaOpis As String = ""
        subAssignSave(GreskaOpis)
        If Trim(GreskaOpis) <> "" Then
            MsgBox(GreskaOpis, MsgBoxStyle.Critical, "Greška u unosu")
            btnSacuvaj.Focus()
        Else
            subKorisniciMan(GreskaOpis)
            If Trim(GreskaOpis) <> "" Then
                MsgBox(GreskaOpis, MsgBoxStyle.Critical, "Transakcijska Greška")
                btnSacuvaj.Focus()
            Else
                Korisnici.dwClosed = 1
                Me.Close()
            End If
        End If
    End Sub
    Private Sub tbLozinkaDana_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbLozinkaDana.Scroll
        txtLozinkaDana.Text = tbLozinkaDana.Value
    End Sub
    Private Sub txtLozinkaDana_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLozinkaDana.TextChanged
        tbLozinkaDana.Value = txtLozinkaDana.Text
    End Sub
    Private Sub subPuniComboKorGrupa()
        Dim prviSlog As Boolean = True
        Dim sqlComm As New SqlClient.SqlCommand("SELECT KorGrupa FROM KorGrupe ORDER BY KorGrupa", cnRoba)
        Dim rdr As SqlClient.SqlDataReader
        cbKorGrupa.Items.Clear()
        cnRoba.Open()
        rdr = sqlComm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdr.Read()
            cbKorGrupa.Items.Add(rdr.GetString(0))
        Loop
        rdr.Close()
    End Sub
    Private Sub chkbAktivan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbAktivan.CheckedChanged
        If chkbAktivan.Checked Then
            Korisnici.f_Aktivan = "A"
        Else
            Korisnici.f_Aktivan = "N"
        End If
    End Sub
    Private Sub Key_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKorisnikL.KeyPress, txtPrezime.KeyPress, txtIme.KeyPress, cbKorGrupa.KeyPress, cbPrivilegije.KeyPress, chkbAktivan.KeyPress, txtLozinkaDana.KeyPress
        Dim poljeForme As String = sender.name
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Select Case poljeForme
                Case "txtKorisnikL"
                    txtPrezime.Focus()
                Case "txtLozinka"
                    txtPrezime.Focus()
                Case "txtPrezime"
                    txtIme.Focus()
                Case "txtIme"
                    cbKorGrupa.Focus()
                Case "cbKorGrupa"
                    cbPrivilegije.Focus()
                Case "cbPrivilegije"
                    txtLozinkaDana.Focus()
                Case "chkbAktivan"
                    txtLozinkaDana.Focus()
                Case "txtLozinkaDana"
                    btnSacuvaj.Focus()
            End Select
            e.Handled = True
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(27) Then
            e.Handled = True
            End
        End If
    End Sub
    Private Sub txtKorisnikL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtKorisnikL.Validating
        btnPonisti.CausesValidation = False
        Dim poruka As String = Trim(fcvKorisnikL(txtKorisnikL.Text))
        Dim oznaka As String = Microsoft.VisualBasic.Right(poruka, 1)
        If Korisnici.Akcija = "dodaj" Then
            If Trim(txtKorisnikL.Text) = "" Then
                MsgBox("Korisnicko Ime je OBAVEZNO za unos !", MsgBoxStyle.Critical, "Greška u unosu")
                e.Cancel = True
            End If
            If oznaka = "." Then
                MsgBox("Korisnik: " & txtKorisnikL.Text & " - VEC POSTOJI !", MsgBoxStyle.Critical, "Greška u unosu")
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub cbKorGrupa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbKorGrupa.Validating
        btnPonisti.CausesValidation = False
        Dim poruka As String = Trim(fcvKorGrupa(Trim(cbKorGrupa.Text)))
        Dim oznaka As String = Microsoft.VisualBasic.Right(poruka, 1)
        If oznaka <> "." Then
            MsgBox(poruka, MsgBoxStyle.Critical, "Greška u unosu")
            e.Cancel = True
        End If
    End Sub

    Private Sub btnPonisti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPonisti.Click
        Me.Close()
    End Sub
End Class