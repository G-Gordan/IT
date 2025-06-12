Imports System.Data.SqlClient
Public Class Kalkulacija
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
    Friend WithEvents tbValuta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbPrevoznina As System.Windows.Forms.TextBox
    Friend WithEvents tbTL As System.Windows.Forms.TextBox
    Friend WithEvents tbRazlika As System.Windows.Forms.TextBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Kalkulacija))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbValuta = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.tbPrevoznina = New System.Windows.Forms.TextBox
        Me.tbTL = New System.Windows.Forms.TextBox
        Me.tbRazlika = New System.Windows.Forms.TextBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(208, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Prevoznina"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(208, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Valuta"
        '
        'tbValuta
        '
        Me.tbValuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbValuta.Location = New System.Drawing.Point(494, 56)
        Me.tbValuta.MaxLength = 2
        Me.tbValuta.Name = "tbValuta"
        Me.tbValuta.Size = New System.Drawing.Size(48, 20)
        Me.tbValuta.TabIndex = 3
        Me.tbValuta.Text = "Euro"
        Me.tbValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(208, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 23)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Iznos po tovarnom listu"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(208, 324)
        Me.Label5.Name = "Label5"
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Razlika"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(208, 112)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(336, 168)
        Me.DataGrid1.TabIndex = 9
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 227)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(439, 366)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(102, 64)
        Me.btnPrihvati.TabIndex = 16
        Me.btnPrihvati.Text = "Prihvati"
        '
        'tbPrevoznina
        '
        Me.tbPrevoznina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevoznina.Location = New System.Drawing.Point(441, 84)
        Me.tbPrevoznina.Name = "tbPrevoznina"
        Me.tbPrevoznina.TabIndex = 17
        Me.tbPrevoznina.Text = "0"
        Me.tbPrevoznina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTL
        '
        Me.tbTL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbTL.Location = New System.Drawing.Point(440, 288)
        Me.tbTL.Name = "tbTL"
        Me.tbTL.TabIndex = 18
        Me.tbTL.Text = "0"
        Me.tbTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbRazlika
        '
        Me.tbRazlika.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbRazlika.Location = New System.Drawing.Point(440, 320)
        Me.tbRazlika.Name = "tbRazlika"
        Me.tbRazlika.TabIndex = 19
        Me.tbRazlika.Text = "0"
        Me.tbRazlika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Kalkulacija
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 454)
        Me.Controls.Add(Me.tbRazlika)
        Me.Controls.Add(Me.tbTL)
        Me.Controls.Add(Me.tbPrevoznina)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbValuta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Kalkulacija"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        bNadjiPrevozninuGlavni()


        'Close()
        'Upis cene za voz kod ICF-a:
        'Primer iz db.ZaImport
        'pre upisa novog reda ispitati da li postoji redni broj 1 u slogu kola
        'za taj broj najave inace upsuje samo naknadu za koriscenje zel.kola
        'Select Case dbo.tempSlog2.stavka
        'FROM  dbo.tempSlog1 INNER JOIN
        '      dbo.tempSlog2 ON dbo.tempSlog1.kljuc = dbo.tempSlog2.kljuc
        'WHERE (dbo.tempSlog1.najava = '1') AND (dbo.tempSlog2.stavka = 1)
    End Sub
    Public Sub StavIcf(ByVal ulazUg As String, ByVal TabC As String, ByVal DatumUg As Date, ByVal MasaUg As Int32, ByVal Sta1 As String, ByVal Sta2 As String, _
                                   ByVal Uprava1 As String, ByVal TipKola1 As Char, ByVal Razred1 As Char, ByRef izlazStav As Decimal, _
                                   ByRef izlazRetVal As String)

        izlazRetVal = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("uspIzrStavR", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim mUgovor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipUgovor", SqlDbType.Char, 6))
        mUgovor.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipUgovor").Value = ulazUg

        Dim mTabC As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipTabC", SqlDbType.Char, 3))
        mTabC.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipTabC").Value = TabC

        Dim mDatum As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipDatum", SqlDbType.DateTime))
        mDatum.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipDatum").Value = DatumUg

        Dim mMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipMasa", SqlDbType.Int))
        mMasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipMasa").Value = MasaUg

        Dim tStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipSt1", SqlDbType.Char, 5))
        tStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipSt1").Value = Sta1

        Dim tStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipSt2", SqlDbType.Char, 5))
        tStanica2.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipSt2").Value = Sta2

        Dim mUprava1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipUprava", SqlDbType.Char, 2))
        mUprava1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipUprava").Value = Uprava1

        Dim mTipKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipTipK", SqlDbType.Char, 1))
        mTipKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipTipK").Value = TipKola1

        Dim mRazred As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipRaz", SqlDbType.Char, 1))
        mRazred.Direction = ParameterDirection.Input
        spKomanda.Parameters("@ipRaz").Value = Razred1

        Dim mIzlazStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upStav", SqlDbType.Money)) 'Decimal
        mIzlazStav.Direction = ParameterDirection.Output
        mIzlazStav.Size = 8 '9
        mIzlazStav.Precision = 19 '18
        mIzlazStav.Scale = 2

        Dim PovratnaVrednost As SqlClient.SqlParameter
        PovratnaVrednost = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@upProv", SqlDbType.Int))
        PovratnaVrednost.Direction = ParameterDirection.ReturnValue

        Try
            spKomanda.ExecuteScalar()
            Dim Pom As Int16 = spKomanda.Parameters("@upProv").Value
            If Pom <> 0 Then
                izlazRetVal = " Neuspesan upit!"
            End If

            izlazStav = spKomanda.Parameters("@upStav").Value
            'tbPrevoznina.Text = Format(izlazStav.ToString, "###,###,##0.00")
            tbPrevoznina.Text = izlazStav.ToString
        Catch SQLexp As SqlException
            izlazRetVal = SQLexp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            izlazRetVal = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub


    Private Sub Kalkulacija_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pv As Decimal
        Dim por As String = ""

        '--------------------------------------
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""
        sNadjiNaziv("TabNaziv", mBrojUg, "", "", xNaziv, xPovVrednost)
        mTabelaCena = xNaziv
        'kada ima vise tabela za isti ugovor, napraviti niz i izabrati prema uslovu ili sl.
        '--------------------------------------

        If mBrojUg = "993353" Then
            If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
                mTabelaCena = "202"
            Else
                mTabelaCena = "201"
            End If
        ElseIf mBrojUg = "993354" Then
            If Microsoft.VisualBasic.Left(mNajava.ToString, 1) = "8" Then
                mTabelaCena = "202"
            Else
                mTabelaCena = "201"
            End If
        End If
        StavIcf(mBrojUg, mTabelaCena, mDatumKalk, mMasaRobe, mStanica1, mStanica2, "00", "", "0", pv, por)
        'pv=cena za voz ali je na kraju unosa voza potrebno izracunati bruto masu voza zbog korekcije cene
        'upisuje se cena samo kod prvih kola u vozu 

        tbRazlika.Text = Format(tbTL.Text - tbPrevoznina.Text, "###,###,##0.00")
        btnPrihvati.Focus()

        mPrevoznina = tbPrevoznina.Text

    End Sub
End Class
