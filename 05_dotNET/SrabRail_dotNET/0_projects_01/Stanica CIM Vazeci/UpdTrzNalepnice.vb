Imports System.Data.SqlClient
Public Class UpdTrzNalepnice
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
    Friend WithEvents gbTranzit As System.Windows.Forms.GroupBox
    Friend WithEvents tbGodina As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cb_Tip As System.Windows.Forms.ComboBox
    Friend WithEvents cbSmer1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbIzmeni As System.Windows.Forms.TextBox
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UpdTrzNalepnice))
        Me.gbTranzit = New System.Windows.Forms.GroupBox
        Me.tbGodina = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cb_Tip = New System.Windows.Forms.ComboBox
        Me.cbSmer1 = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.tbNalepnica = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbIzmeni = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.gbTranzit.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTranzit
        '
        Me.gbTranzit.Controls.Add(Me.tbGodina)
        Me.gbTranzit.Controls.Add(Me.Label16)
        Me.gbTranzit.Controls.Add(Me.Label6)
        Me.gbTranzit.Controls.Add(Me.cb_Tip)
        Me.gbTranzit.Controls.Add(Me.cbSmer1)
        Me.gbTranzit.Controls.Add(Me.Label11)
        Me.gbTranzit.Controls.Add(Me.Label12)
        Me.gbTranzit.Controls.Add(Me.tbNalepnica)
        Me.gbTranzit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTranzit.Location = New System.Drawing.Point(16, 123)
        Me.gbTranzit.Name = "gbTranzit"
        Me.gbTranzit.Size = New System.Drawing.Size(318, 205)
        Me.gbTranzit.TabIndex = 0
        Me.gbTranzit.TabStop = False
        Me.gbTranzit.Text = "[ Tranzitna nalepnica ]"
        '
        'tbGodina
        '
        Me.tbGodina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGodina.Location = New System.Drawing.Point(112, 26)
        Me.tbGodina.MaxLength = 4
        Me.tbGodina.Name = "tbGodina"
        Me.tbGodina.Size = New System.Drawing.Size(89, 22)
        Me.tbGodina.TabIndex = 15
        Me.tbGodina.Text = ""
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 23)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Godina"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 23)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Tip nalepnice"
        '
        'cb_Tip
        '
        Me.cb_Tip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Tip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Tip.Items.AddRange(New Object() {"1 - Ulazna nalepnica", "2 - Izlazna nalepnica"})
        Me.cb_Tip.Location = New System.Drawing.Point(112, 66)
        Me.cb_Tip.Name = "cb_Tip"
        Me.cb_Tip.Size = New System.Drawing.Size(192, 24)
        Me.cb_Tip.TabIndex = 0
        '
        'cbSmer1
        '
        Me.cbSmer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer1.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer1.Location = New System.Drawing.Point(112, 112)
        Me.cbSmer1.Name = "cbSmer1"
        Me.cbSmer1.Size = New System.Drawing.Size(192, 24)
        Me.cbSmer1.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 21)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Broj"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 15)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Stanica"
        '
        'tbNalepnica
        '
        Me.tbNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNalepnica.Location = New System.Drawing.Point(112, 152)
        Me.tbNalepnica.MaxLength = 5
        Me.tbNalepnica.Name = "tbNalepnica"
        Me.tbNalepnica.Size = New System.Drawing.Size(192, 22)
        Me.tbNalepnica.TabIndex = 2
        Me.tbNalepnica.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbIzmeni)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(384, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 205)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Izmena ]"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 21)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Izmenjen broj"
        '
        'tbIzmeni
        '
        Me.tbIzmeni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIzmeni.Location = New System.Drawing.Point(16, 152)
        Me.tbIzmeni.MaxLength = 5
        Me.tbIzmeni.Name = "tbIzmeni"
        Me.tbIzmeni.Size = New System.Drawing.Size(192, 22)
        Me.tbIzmeni.TabIndex = 2
        Me.tbIzmeni.Text = ""
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(262, 352)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 72)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Pronadji"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(440, 352)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 72)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Izmeni"
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(544, 352)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(72, 72)
        Me.btnOtkazi.TabIndex = 4
        Me.btnOtkazi.Text = "Izlaz"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(96, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(264, 40)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Izmena brojeva tranzitnih nalepnica"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UpdTrzNalepnice
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(632, 438)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbTranzit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdTrzNalepnice"
        Me.Text = "Izmena brojeva tranzitnih nalepnica"
        Me.gbTranzit.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub UpdTrzNalepnice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tbGodina.Text = Now.Today.Year.ToString
        Me.cbSmer1.Enabled = False
        Me.cbSmer1.Text = StanicaUnosa
    End Sub

    Private Sub cb_Tip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cb_Tip.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub cbSmer1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNalepnica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub tbIzmeni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbIzmeni.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        mObrGodina = Me.tbGodina.Text
        Dim mRetVal As String
        Dim mRecID As Int32
        Dim mStanicaRecID As String
        Dim izZsPrelaz As String
        Dim otUprava As String
        Dim otStanica As String
        Dim otBroj As Int32
        Dim otDatum As Date
        Dim izNalepnica As Int32
        Dim izPrUprava As String
        Dim izPrStanica As String
        Dim izSifraTarife As String
        Dim izUgovor As String

        eNadjiTovarniListTrz(Microsoft.VisualBasic.Mid(cb_Tip.Text, 1, 1), Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), tbNalepnica.Text, mObrGodina, _
                              mRecID, mStanicaRecID, mObrMesec, otUprava, otStanica, otBroj, otDatum, izPrUprava, izPrStanica, _
                              izZsPrelaz, izNalepnica, msBrojVoza, mSatVoza, msBrojVoza2, mSatVoza2, mDatumUlaza, mDatumIzlaza, izSifraTarife, izUgovor, mCarStanica, mCarStanica2, _
                              mRetVal)

        If mRetVal = "" Then
            ''If Microsoft.VisualBasic.Mid(cb_Tip.Text, 1, 1) = "1" Then
            ''    mUlPrelaz = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            ''    mIzPrelaz = izZsPrelaz
            ''    mUlEtiketa = tbNalepnica.Text
            ''    mIzEtiketa = izNalepnica
            ''Else
            ''    mUlPrelaz = izZsPrelaz
            ''    mIzPrelaz = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            ''    mUlEtiketa = izNalepnica
            ''    mIzEtiketa = tbNalepnica.Text
            ''End If
            GroupBox1.Enabled = True
            Me.tbIzmeni.Focus()

            ''If mStanicaRecID = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) Then

            ''Else
            ''    MessageBox.Show("Podatak nije unet u stanici " & Microsoft.VisualBasic.Right(StanicaUnosa, Len(StanicaUnosa) - 10) & ".  Izmena nije dozvoljena.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ''End If
        Else
            MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tbNalepnica.Focus()

        End If

    End Sub

    Private Sub tbNalepnica_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNalepnica.Leave
        Button3.Focus()

    End Sub

    Private Sub tbIzmeni_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbIzmeni.Leave
        Me.Button1.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Update markice

        Dim slogTrans As SqlTransaction
        Dim updOtpUprava As String
        Dim updOtpStanica As String
        Dim updOtpBroj As String
        Dim updOtpDatum As Date
        Dim mRetVal As String

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        slogTrans = DbVeza.BeginTransaction()

        UpdTrzNalepnica(slogTrans, mObrGodina, Microsoft.VisualBasic.Mid(cb_Tip.Text, 1, 1), _
                        Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5), CType(Me.tbNalepnica.Text, Int32), CType(tbIzmeni.Text, Int32), _
                        mRetVal)

        If mRetVal = "" Then
            slogTrans.Commit()
        Else
            MessageBox.Show("Izmena nije uradjena!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            slogTrans.Rollback()
        End If

        'na kraju
        GroupBox1.Enabled = False
        Me.tbIzmeni.Text = ""
        Me.tbNalepnica.Text = ""
        Me.tbNalepnica.Focus()
    End Sub

    Private Sub tbNalepnica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbNalepnica.Validating
        If tbNalepnica.Text = "0" Then
            ErrorProvider1.SetError(tbNalepnica, "Broj tranzitne nalepnice ne moze da bude nula!")
            tbNalepnica.Focus()
        Else
            If tbNalepnica.Text = Nothing Then
                ErrorProvider1.SetError(tbNalepnica, "Neispravan broj tranzitne nalepnice!")
                tbNalepnica.Focus()
            Else
                If IsNumeric(tbNalepnica.Text) = True Then
                    ErrorProvider1.SetError(tbNalepnica, "")
                Else
                    ErrorProvider1.SetError(tbNalepnica, "Neispravan broj tranzitne nalepnice!")
                    tbNalepnica.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub tbIzmeni_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbIzmeni.Validating
        If tbIzmeni.Text = "0" Then
            ErrorProvider1.SetError(tbIzmeni, "Broj tranzitne nalepnice ne moze da bude nula!")
            tbIzmeni.Focus()
        Else
            If tbIzmeni.Text = Nothing Then
                ErrorProvider1.SetError(tbIzmeni, "Neispravan broj tranzitne nalepnice!")
                tbIzmeni.Focus()
            Else
                If IsNumeric(tbIzmeni.Text) = True Then
                    ErrorProvider1.SetError(tbIzmeni, "")
                Else
                    ErrorProvider1.SetError(tbIzmeni, "Neispravan broj tranzitne nalepnice!")
                    tbIzmeni.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub
End Class
