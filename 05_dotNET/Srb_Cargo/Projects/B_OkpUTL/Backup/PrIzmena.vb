Imports System.Data.SqlClient
Public Class PrIzmena
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbBrojOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaOtp As System.Windows.Forms.TextBox
    Friend WithEvents DatumOtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents tbPrStanicaStara As System.Windows.Forms.TextBox
    Friend WithEvents PrDatumStari As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbPrBrojNovi As System.Windows.Forms.TextBox
    Friend WithEvents tbPrStanicaNova As System.Windows.Forms.TextBox
    Friend WithEvents PrDatumNovi As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPronadji As System.Windows.Forms.Button
    Friend WithEvents tbPrBrojStari As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.tbBrojOtp = New System.Windows.Forms.TextBox
        Me.tbStanicaOtp = New System.Windows.Forms.TextBox
        Me.DatumOtp = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbPrBrojStari = New System.Windows.Forms.TextBox
        Me.tbPrStanicaStara = New System.Windows.Forms.TextBox
        Me.PrDatumStari = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbPrBrojNovi = New System.Windows.Forms.TextBox
        Me.tbPrStanicaNova = New System.Windows.Forms.TextBox
        Me.PrDatumNovi = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnPronadji = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.tbBrojOtp)
        Me.GroupBox1.Controls.Add(Me.tbStanicaOtp)
        Me.GroupBox1.Controls.Add(Me.DatumOtp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(32, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 229)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ OTPRAVLJANJE ] "
        '
        'Label18
        '
        Me.Label18.Enabled = False
        Me.Label18.Location = New System.Drawing.Point(26, 168)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 23)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Datum"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Location = New System.Drawing.Point(33, 136)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 16)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Broj"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojOtp.Location = New System.Drawing.Point(105, 128)
        Me.tbBrojOtp.MaxLength = 5
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.TabIndex = 2
        Me.tbBrojOtp.Text = "0"
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaOtp.Location = New System.Drawing.Point(105, 80)
        Me.tbStanicaOtp.MaxLength = 7
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.TabIndex = 1
        Me.tbStanicaOtp.Text = ""
        '
        'DatumOtp
        '
        Me.DatumOtp.Enabled = False
        Me.DatumOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOtp.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOtp.Location = New System.Drawing.Point(105, 168)
        Me.DatumOtp.Name = "DatumOtp"
        Me.DatumOtp.Size = New System.Drawing.Size(100, 24)
        Me.DatumOtp.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(24, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Stanica"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.tbPrBrojStari)
        Me.GroupBox2.Controls.Add(Me.tbPrStanicaStara)
        Me.GroupBox2.Controls.Add(Me.PrDatumStari)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(296, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 229)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ STARO PRISPECE ] "
        Me.GroupBox2.Visible = False
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(26, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Datum"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(33, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Broj"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbPrBrojStari
        '
        Me.tbPrBrojStari.Enabled = False
        Me.tbPrBrojStari.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrBrojStari.Location = New System.Drawing.Point(105, 128)
        Me.tbPrBrojStari.MaxLength = 5
        Me.tbPrBrojStari.Name = "tbPrBrojStari"
        Me.tbPrBrojStari.TabIndex = 2
        Me.tbPrBrojStari.Text = "0"
        '
        'tbPrStanicaStara
        '
        Me.tbPrStanicaStara.Enabled = False
        Me.tbPrStanicaStara.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrStanicaStara.Location = New System.Drawing.Point(105, 80)
        Me.tbPrStanicaStara.MaxLength = 7
        Me.tbPrStanicaStara.Name = "tbPrStanicaStara"
        Me.tbPrStanicaStara.TabIndex = 1
        Me.tbPrStanicaStara.Text = ""
        '
        'PrDatumStari
        '
        Me.PrDatumStari.Enabled = False
        Me.PrDatumStari.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrDatumStari.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.PrDatumStari.Location = New System.Drawing.Point(105, 168)
        Me.PrDatumStari.Name = "PrDatumStari"
        Me.PrDatumStari.Size = New System.Drawing.Size(100, 24)
        Me.PrDatumStari.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(24, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Stanica"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.tbPrBrojNovi)
        Me.GroupBox3.Controls.Add(Me.tbPrStanicaNova)
        Me.GroupBox3.Controls.Add(Me.PrDatumNovi)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(568, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(221, 229)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "[ NOVO PRISPECE ] "
        Me.GroupBox3.Visible = False
        '
        'Label5
        '
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(26, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Datum"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label6
        '
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(33, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Broj"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbPrBrojNovi
        '
        Me.tbPrBrojNovi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrBrojNovi.Location = New System.Drawing.Point(105, 128)
        Me.tbPrBrojNovi.MaxLength = 5
        Me.tbPrBrojNovi.Name = "tbPrBrojNovi"
        Me.tbPrBrojNovi.TabIndex = 2
        Me.tbPrBrojNovi.Text = "0"
        '
        'tbPrStanicaNova
        '
        Me.tbPrStanicaNova.Enabled = False
        Me.tbPrStanicaNova.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrStanicaNova.Location = New System.Drawing.Point(105, 80)
        Me.tbPrStanicaNova.MaxLength = 7
        Me.tbPrStanicaNova.Name = "tbPrStanicaNova"
        Me.tbPrStanicaNova.TabIndex = 1
        Me.tbPrStanicaNova.Text = ""
        '
        'PrDatumNovi
        '
        Me.PrDatumNovi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrDatumNovi.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.PrDatumNovi.Location = New System.Drawing.Point(105, 168)
        Me.PrDatumNovi.Name = "PrDatumNovi"
        Me.PrDatumNovi.Size = New System.Drawing.Size(100, 24)
        Me.PrDatumNovi.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Enabled = False
        Me.Label7.Location = New System.Drawing.Point(24, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Stanica"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnPronadji
        '
        Me.btnPronadji.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPronadji.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPronadji.Location = New System.Drawing.Point(88, 296)
        Me.btnPronadji.Name = "btnPronadji"
        Me.btnPronadji.Size = New System.Drawing.Size(112, 40)
        Me.btnPronadji.TabIndex = 4
        Me.btnPronadji.Text = "Pronadji"
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(448, 296)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(77, 64)
        Me.btnPrihvati.TabIndex = 5
        Me.btnPrihvati.Text = "Izmeni"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrihvati.Visible = False
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(568, 296)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(77, 64)
        Me.btnOtkazi.TabIndex = 8
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label8
        '
        Me.Label8.Enabled = False
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(32, 352)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(208, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Racunski mesec: "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label8.Visible = False
        '
        'PrIzmena
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(824, 382)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.btnPronadji)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PrIzmena"
        Me.Text = "Izmena prispeca"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        mOtpStanica = ""
        mOtpBroj = 0
        Close()
    End Sub

    Private Sub PrIzmena_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupBox2.Visible = False
        Label18.Visible = False
        DatumOtp.Visible = False
        btnPrihvati.Visible = False
        tbStanicaOtp.Text = mOtpStanica
        tbBrojOtp.Text = mOtpBroj
        DatumOtp.Text = mOtpDatum

    End Sub

    Private Sub btnOtkazi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnOtkazi.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnPrihvati_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnPrihvati.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DatumOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub PrDatumNovi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrDatumNovi.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub PrDatumStari_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrDatumStari.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbBrojOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrBorojStari_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrBrojStari.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrBrojNovi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrBrojNovi.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrStanicaNova_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrStanicaNova.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrStanicaStara_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrStanicaStara.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbStanicaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnPronadji_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPronadji.Click
        Dim mRetVal As String = ""
        Dim AdmSaobracaj As String = ""
        mOtpUprava = "0072"
        mOtpStanica = "72" & tbStanicaOtp.Text
        mOtpBroj = tbBrojOtp.Text
        mOtpDatum = DatumOtp.Value.ToShortDateString

        'NadjiTLuBazi(mOtpUprava, mOtpStanica, mOtpBroj, mOtpDatum, _
        '             UpdRecID, UpdStanicaRecID, _
        '             mRetVal)

        bNadjiTLUBaziPoOtpAdm(mOtpStanica, mOtpBroj, mOtpDatum, mPrStanica, mPrispece, mPrDatum, _
                            mObrMesec, mObrGodina, UpdRecID, UpdStanicaRecID, AdmSaobracaj, _
                            mRetVal)

        If mRetVal = "" And AdmSaobracaj = "1" Then
            Me.Label8.Visible = True
            Label8.Visible = True
            Label18.Visible = True
            Label8.Text = " Racunski mesec:" & "  " & mObrMesec & " / " & mObrGodina
            GroupBox2.Visible = True
            GroupBox3.Visible = True
            DatumOtp.Visible = True
            Me.DatumOtp.Value = mOtpDatum
            Me.tbPrStanicaStara.Text = Microsoft.VisualBasic.Right(mPrStanica, 5)
            Me.tbPrStanicaNova.Text = Microsoft.VisualBasic.Right(mPrStanica, 5)
            Me.tbPrBrojStari.Text = mPrispece
            Me.tbPrBrojNovi.Text = mPrispece
            Me.PrDatumStari.Value = mPrDatum
            Me.PrDatumNovi.Value = mPrDatum
            btnPrihvati.Visible = True
            'tb2.Text = Microsoft.VisualBasic.Right(mOtpStanica, 5)
            'tb3.Text = mOtpBroj
            'Me.DateTimePicker2.Text = mOtpDatum

            tbPrStanicaNova.Focus()
        Else
            Me.Label8.Visible = False
            MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'tbUpravaOtp.Focus()
        End If

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        'IzmenaDuplihOtpravljanja.sql
        Dim slogTrans As SqlTransaction

        Dim updPrStanica As String
        Dim updPrBroj As Integer
        Dim updPrDatum As Date
        Dim mRetVal As String

        Dim _PrDatum As Date
        Dim _OtpStanica As String
        Dim _OtpBroj As Integer
        Dim _OtpDatum As Date
        Dim _ObrMesec As String
        Dim _ObrGodina As String
        Dim _RecID As Integer
        Dim _StanicaID As String
        Dim _Saobracaj As String
        Dim _RetVal As String

        updPrStanica = "72" & tbPrStanicaNova.Text
        updPrBroj = tbPrBrojNovi.Text
        updPrDatum = Me.PrDatumNovi.Value.ToShortDateString

        


        bNadjiTLUBaziPoPrAdm(updPrStanica, updPrBroj, _PrDatum, _OtpStanica, _OtpBroj, _OtpDatum, _ObrMesec, _ObrGodina, _RecID, _StanicaID, _Saobracaj, _RetVal)

        If _RetVal <> "" Then

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            slogTrans = OkpDbVeza.BeginTransaction()

            UpdatePrispeceUBazi(slogTrans, UpdRecID, updPrStanica, updPrBroj, updPrDatum, mRetVal)


            If mRetVal = "" Then
                slogTrans.Commit()
            Else
                MessageBox.Show("Takvo otpravljanje vec postoji u bazi!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                slogTrans.Rollback()
            End If

            'Me.PictureBox2.Visible = True
            OkpDbVeza.Close()
            'tb1.Clear()
            tbPrStanicaStara.Clear()
            tbPrBrojStari.Clear()
            tbPrStanicaNova.Clear()
            tbPrBrojNovi.Clear()

            Me.tbStanicaOtp.Focus()

            GroupBox2.Visible = False
            Label18.Visible = False
            DatumOtp.Visible = False
            btnPrihvati.Visible = False
            tbStanicaOtp.Text = ""
            tbBrojOtp.Text = ""

            GroupBox3.Visible = False

        Else
            MessageBox.Show("Takvo prispece vec postoji u bazi!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            slogTrans.Rollback()
        End If


    End Sub

    Private Sub PrDatumNovi_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PrDatumNovi.Validating
        btnPrihvati.Focus()
    End Sub
End Class
