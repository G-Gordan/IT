Imports System.Data.SqlClient
Public Class PosPrimIzmena
    Inherits System.Windows.Forms.Form
    Dim UpdRecID As Integer = 0
    Dim updPosiljalac As Integer = 0
    Dim updPrimalac As Integer = 0

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
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbBrojOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaOtp As System.Windows.Forms.TextBox
    Friend WithEvents DatumOtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbPrimN As System.Windows.Forms.TextBox
    Friend WithEvents tbPosN As System.Windows.Forms.TextBox
    Friend WithEvents LabelPrimSt As System.Windows.Forms.Label
    Friend WithEvents LabelPosStari As System.Windows.Forms.Label
    Friend WithEvents LabelSifraPosS As System.Windows.Forms.Label
    Friend WithEvents LabelSifraPrimS As System.Windows.Forms.Label
    Friend WithEvents LabelUpSt As System.Windows.Forms.Label
    Friend WithEvents LabelBrPr As System.Windows.Forms.Label
    Friend WithEvents LabelDatPr As System.Windows.Forms.Label
    Friend WithEvents LabelNazivPosS As System.Windows.Forms.Label
    Friend WithEvents LabelNazivPrimS As System.Windows.Forms.Label
    Friend WithEvents LabelNazivPosN As System.Windows.Forms.Label
    Friend WithEvents LabelNazivPrimN As System.Windows.Forms.Label
    Friend WithEvents LabelUpS As System.Windows.Forms.Label
    Friend WithEvents LabelBrP As System.Windows.Forms.Label
    Friend WithEvents LabelDatP As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelDatO As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.tbBrojOtp = New System.Windows.Forms.TextBox
        Me.tbStanicaOtp = New System.Windows.Forms.TextBox
        Me.DatumOtp = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.LabelDatO = New System.Windows.Forms.Label
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.LabelNazivPrimN = New System.Windows.Forms.Label
        Me.LabelNazivPosN = New System.Windows.Forms.Label
        Me.LabelNazivPrimS = New System.Windows.Forms.Label
        Me.LabelNazivPosS = New System.Windows.Forms.Label
        Me.LabelDatP = New System.Windows.Forms.Label
        Me.LabelBrP = New System.Windows.Forms.Label
        Me.LabelUpS = New System.Windows.Forms.Label
        Me.LabelDatPr = New System.Windows.Forms.Label
        Me.LabelBrPr = New System.Windows.Forms.Label
        Me.LabelUpSt = New System.Windows.Forms.Label
        Me.LabelSifraPrimS = New System.Windows.Forms.Label
        Me.LabelSifraPosS = New System.Windows.Forms.Label
        Me.tbPrimN = New System.Windows.Forms.TextBox
        Me.tbPosN = New System.Windows.Forms.TextBox
        Me.LabelPrimSt = New System.Windows.Forms.Label
        Me.LabelPosStari = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(117, 400)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 40)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Pronadji"
        '
        'Label8
        '
        Me.Label8.Enabled = False
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(36, 448)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(208, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Racunski mesec: "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label8.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.tbBrojOtp)
        Me.GroupBox1.Controls.Add(Me.tbStanicaOtp)
        Me.GroupBox1.Controls.Add(Me.DatumOtp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LabelDatO)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 229)
        Me.GroupBox1.TabIndex = 9
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
        Me.tbStanicaOtp.MaxLength = 5
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.TabIndex = 1
        Me.tbStanicaOtp.Text = ""
        '
        'DatumOtp
        '
        Me.DatumOtp.Enabled = False
        Me.DatumOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOtp.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOtp.Location = New System.Drawing.Point(105, 200)
        Me.DatumOtp.Name = "DatumOtp"
        Me.DatumOtp.Size = New System.Drawing.Size(100, 24)
        Me.DatumOtp.TabIndex = 3
        Me.DatumOtp.Visible = False
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
        'LabelDatO
        '
        Me.LabelDatO.Enabled = False
        Me.LabelDatO.Location = New System.Drawing.Point(104, 168)
        Me.LabelDatO.Name = "LabelDatO"
        Me.LabelDatO.Size = New System.Drawing.Size(80, 23)
        Me.LabelDatO.TabIndex = 15
        Me.LabelDatO.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(528, 400)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(77, 64)
        Me.btnOtkazi.TabIndex = 13
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(432, 400)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(77, 64)
        Me.btnPrihvati.TabIndex = 12
        Me.btnPrihvati.Text = "Izmeni"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.LabelNazivPrimN)
        Me.GroupBox2.Controls.Add(Me.LabelNazivPosN)
        Me.GroupBox2.Controls.Add(Me.LabelNazivPrimS)
        Me.GroupBox2.Controls.Add(Me.LabelNazivPosS)
        Me.GroupBox2.Controls.Add(Me.LabelDatP)
        Me.GroupBox2.Controls.Add(Me.LabelBrP)
        Me.GroupBox2.Controls.Add(Me.LabelUpS)
        Me.GroupBox2.Controls.Add(Me.LabelDatPr)
        Me.GroupBox2.Controls.Add(Me.LabelBrPr)
        Me.GroupBox2.Controls.Add(Me.LabelUpSt)
        Me.GroupBox2.Controls.Add(Me.LabelSifraPrimS)
        Me.GroupBox2.Controls.Add(Me.LabelSifraPosS)
        Me.GroupBox2.Controls.Add(Me.tbPrimN)
        Me.GroupBox2.Controls.Add(Me.tbPosN)
        Me.GroupBox2.Controls.Add(Me.LabelPrimSt)
        Me.GroupBox2.Controls.Add(Me.LabelPosStari)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(264, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(488, 376)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ IZMENA ]"
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(16, 336)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Novi primalac"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(16, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Novi posiljalac"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label1.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(8, 328)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 24)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Novi primalac"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(8, 264)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 24)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Novi posiljalac"
        '
        'LabelNazivPrimN
        '
        Me.LabelNazivPrimN.Enabled = False
        Me.LabelNazivPrimN.Location = New System.Drawing.Point(176, 336)
        Me.LabelNazivPrimN.Name = "LabelNazivPrimN"
        Me.LabelNazivPrimN.Size = New System.Drawing.Size(296, 16)
        Me.LabelNazivPrimN.TabIndex = 29
        Me.LabelNazivPrimN.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelNazivPosN
        '
        Me.LabelNazivPosN.Enabled = False
        Me.LabelNazivPosN.Location = New System.Drawing.Point(176, 272)
        Me.LabelNazivPosN.Name = "LabelNazivPosN"
        Me.LabelNazivPosN.Size = New System.Drawing.Size(296, 16)
        Me.LabelNazivPosN.TabIndex = 28
        Me.LabelNazivPosN.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelNazivPrimS
        '
        Me.LabelNazivPrimS.Enabled = False
        Me.LabelNazivPrimS.Location = New System.Drawing.Point(176, 216)
        Me.LabelNazivPrimS.Name = "LabelNazivPrimS"
        Me.LabelNazivPrimS.Size = New System.Drawing.Size(296, 16)
        Me.LabelNazivPrimS.TabIndex = 27
        Me.LabelNazivPrimS.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelNazivPosS
        '
        Me.LabelNazivPosS.Enabled = False
        Me.LabelNazivPosS.Location = New System.Drawing.Point(176, 168)
        Me.LabelNazivPosS.Name = "LabelNazivPosS"
        Me.LabelNazivPosS.Size = New System.Drawing.Size(296, 16)
        Me.LabelNazivPosS.TabIndex = 26
        Me.LabelNazivPosS.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelDatP
        '
        Me.LabelDatP.Enabled = False
        Me.LabelDatP.Location = New System.Drawing.Point(160, 96)
        Me.LabelDatP.Name = "LabelDatP"
        Me.LabelDatP.Size = New System.Drawing.Size(88, 16)
        Me.LabelDatP.TabIndex = 25
        Me.LabelDatP.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelBrP
        '
        Me.LabelBrP.Enabled = False
        Me.LabelBrP.Location = New System.Drawing.Point(160, 64)
        Me.LabelBrP.Name = "LabelBrP"
        Me.LabelBrP.Size = New System.Drawing.Size(88, 16)
        Me.LabelBrP.TabIndex = 24
        Me.LabelBrP.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelUpS
        '
        Me.LabelUpS.Enabled = False
        Me.LabelUpS.Location = New System.Drawing.Point(160, 32)
        Me.LabelUpS.Name = "LabelUpS"
        Me.LabelUpS.Size = New System.Drawing.Size(88, 16)
        Me.LabelUpS.TabIndex = 23
        Me.LabelUpS.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelDatPr
        '
        Me.LabelDatPr.Enabled = False
        Me.LabelDatPr.Location = New System.Drawing.Point(16, 96)
        Me.LabelDatPr.Name = "LabelDatPr"
        Me.LabelDatPr.Size = New System.Drawing.Size(96, 16)
        Me.LabelDatPr.TabIndex = 22
        Me.LabelDatPr.Text = "Datum prispeca"
        Me.LabelDatPr.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelBrPr
        '
        Me.LabelBrPr.Enabled = False
        Me.LabelBrPr.Location = New System.Drawing.Point(16, 64)
        Me.LabelBrPr.Name = "LabelBrPr"
        Me.LabelBrPr.Size = New System.Drawing.Size(88, 16)
        Me.LabelBrPr.TabIndex = 21
        Me.LabelBrPr.Text = "Broj prispeca"
        Me.LabelBrPr.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelUpSt
        '
        Me.LabelUpSt.Enabled = False
        Me.LabelUpSt.Location = New System.Drawing.Point(16, 32)
        Me.LabelUpSt.Name = "LabelUpSt"
        Me.LabelUpSt.Size = New System.Drawing.Size(88, 16)
        Me.LabelUpSt.TabIndex = 20
        Me.LabelUpSt.Text = "Uputna stanica"
        Me.LabelUpSt.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelSifraPrimS
        '
        Me.LabelSifraPrimS.Enabled = False
        Me.LabelSifraPrimS.Location = New System.Drawing.Point(112, 216)
        Me.LabelSifraPrimS.Name = "LabelSifraPrimS"
        Me.LabelSifraPrimS.Size = New System.Drawing.Size(56, 16)
        Me.LabelSifraPrimS.TabIndex = 19
        Me.LabelSifraPrimS.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelSifraPosS
        '
        Me.LabelSifraPosS.Enabled = False
        Me.LabelSifraPosS.Location = New System.Drawing.Point(112, 168)
        Me.LabelSifraPosS.Name = "LabelSifraPosS"
        Me.LabelSifraPosS.Size = New System.Drawing.Size(56, 16)
        Me.LabelSifraPosS.TabIndex = 18
        Me.LabelSifraPosS.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbPrimN
        '
        Me.tbPrimN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrimN.Location = New System.Drawing.Point(112, 328)
        Me.tbPrimN.MaxLength = 6
        Me.tbPrimN.Name = "tbPrimN"
        Me.tbPrimN.Size = New System.Drawing.Size(56, 24)
        Me.tbPrimN.TabIndex = 16
        Me.tbPrimN.Text = ""
        '
        'tbPosN
        '
        Me.tbPosN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPosN.Location = New System.Drawing.Point(112, 264)
        Me.tbPosN.MaxLength = 6
        Me.tbPosN.Name = "tbPosN"
        Me.tbPosN.Size = New System.Drawing.Size(56, 24)
        Me.tbPosN.TabIndex = 14
        Me.tbPosN.Text = ""
        '
        'LabelPrimSt
        '
        Me.LabelPrimSt.Enabled = False
        Me.LabelPrimSt.Location = New System.Drawing.Point(16, 216)
        Me.LabelPrimSt.Name = "LabelPrimSt"
        Me.LabelPrimSt.Size = New System.Drawing.Size(72, 16)
        Me.LabelPrimSt.TabIndex = 13
        Me.LabelPrimSt.Text = "Primalac"
        Me.LabelPrimSt.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LabelPosStari
        '
        Me.LabelPosStari.Enabled = False
        Me.LabelPosStari.Location = New System.Drawing.Point(16, 168)
        Me.LabelPosStari.Name = "LabelPosStari"
        Me.LabelPosStari.Size = New System.Drawing.Size(72, 16)
        Me.LabelPosStari.TabIndex = 11
        Me.LabelPosStari.Text = "Posiljalac"
        Me.LabelPosStari.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'PosPrimIzmena
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(760, 494)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PosPrimIzmena"
        Me.Text = "Izmena posiljaoca i primaoca"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        DatumOtp.Value = Today
        tbStanicaOtp.Text = ""
        tbBrojOtp.Text = ""
        Label8.Text = ""
        LabelUpS.Text = ""
        LabelBrP.Text = ""
        LabelDatP.Text = ""
        LabelSifraPosS.Text = ""
        LabelNazivPosS.Text = ""
        LabelSifraPrimS.Text = ""
        LabelNazivPrimS.Text = ""
        tbPosN.Text = ""
        LabelNazivPosN.Text = ""
        tbPrimN.Text = ""
        LabelNazivPrimN.Text = ""

        Close()
    End Sub

    

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim mRetVal As String = ""
        Dim AdmSaobracaj As String = ""
        mOtpUprava = "0072"
        mOtpStanica = "72" & tbStanicaOtp.Text
        mOtpBroj = tbBrojOtp.Text
        'mOtpDatum = DatumOtp.Value.ToShortDateString

        Dim _OtpDatum As Date
        Dim _PrStanica As String
        Dim _PrBroj As Integer
        Dim _PrDatum As Date   
        Dim _ObrMesec As String
        Dim _ObrGodina As String
        Dim _StanicaID As String
        Dim _Saobracaj As String
        Dim _RetVal As String
        Dim _RetValInt As Int32

        'bNadjiPosIPrimIzTLAdm(mOtpStanica, mOtpBroj, mOtpDatum, _
        '                        _PrStanica, _PrBroj, _PrDatum, updPosiljalac, updPrimalac, _
        '                        _ObrMesec, _ObrGodina, UpdRecID, _StanicaID, _Saobracaj, _RetVal)

        bNadjiPosIPrimIzTLAdm2(mOtpStanica, mOtpBroj, _
                                _OtpDatum, _PrStanica, _PrBroj, _PrDatum, updPosiljalac, updPrimalac, _
                                _ObrMesec, _ObrGodina, UpdRecID, _StanicaID, _Saobracaj, _RetValInt, _RetVal)



        Dim xNazivPos As String = ""
        Dim xNazivPrim As String = ""
        Dim xMesto As String = ""
        Dim xZemlja As String = ""
        Dim xAdresa As String = ""
        Dim xPovVrednost As String = ""

        If _RetValInt = 1 Then
            Util.sNadjiKorisnika(CStr(updPosiljalac), xNazivPos, xMesto, xZemlja, xAdresa, xPovVrednost)
            Util.sNadjiKorisnika(CStr(updPrimalac), xNazivPrim, xMesto, xZemlja, xAdresa, xPovVrednost)

            Me.Label8.Visible = True
            Label8.Visible = True
            Label18.Visible = True
            Label8.Text = " Racunski mesec:" & "  " & _ObrMesec & " / " & _ObrGodina
            GroupBox2.Visible = True

            'DatumOtp.Visible = True
            'Me.DatumOtp.Value = mOtpDatum
            btnPrihvati.Visible = True
            LabelUpS.Text = Microsoft.VisualBasic.Right(_PrStanica, 5)
            LabelBrP.Text = _PrBroj
            LabelDatP.Text = _PrDatum
            LabelDatO.Text = _OtpDatum
            LabelSifraPosS.Text = CStr(updPosiljalac)
            LabelSifraPrimS.Text = CStr(updPrimalac)
            tbPosN.Text = CStr(updPosiljalac)
            tbPrimN.Text = CStr(updPrimalac)
            LabelNazivPosS.Text = xNazivPos
            LabelNazivPrimS.Text = xNazivPrim
            LabelNazivPosN.Text = xNazivPos
            LabelNazivPrimN.Text = xNazivPrim

            tbPosN.Focus()


        ElseIf _RetValInt = 0 Then
            Me.Label8.Visible = False
            MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tbBrojOtp.Focus()
        ElseIf _RetValInt > 1 Then
            Me.Label8.Visible = False
            MessageBox.Show("Postoji vise takvih otpravljanja!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tbBrojOtp.Focus()
        End If

    End Sub
    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click

        Dim slogTrans As SqlTransaction

        'Dim updPosiljalac As Integer
        'Dim updPrimalac As Integer

        Dim mRetVal As String


        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        slogTrans = OkpDbVeza.BeginTransaction()


        bUpdatePosIPrimUBazi(slogTrans, UpdRecID, updPosiljalac, updPrimalac, mRetVal)

        If mRetVal = "" Then
            slogTrans.Commit()

            'DatumOtp.Value = Today

            tbStanicaOtp.Text = ""
            tbBrojOtp.Text = ""
            Label8.Text = ""
            LabelUpS.Text = ""
            LabelBrP.Text = ""
            LabelDatP.Text = ""
            LabelDatO.Text = ""
            LabelSifraPosS.Text = ""
            LabelNazivPosS.Text = ""
            LabelSifraPrimS.Text = ""
            LabelNazivPrimS.Text = ""
            tbPosN.Text = ""
            LabelNazivPosN.Text = ""
            tbPrimN.Text = ""
            LabelNazivPrimN.Text = ""


            tbStanicaOtp.Focus()
        Else
            MessageBox.Show("Neuspesna promena!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            slogTrans.Rollback()
        End If

        'Me.PictureBox2.Visible = True
        OkpDbVeza.Close()
        'tb1.Clear()
        'tbPrStanicaStara.Clear()
        'tbPrBrojStari.Clear()
        'tbPrStanicaNova.Clear()
        'tbPrBrojNovi.Clear()

        Me.tbStanicaOtp.Focus()

        'GroupBox2.Visible = False
        'Label18.Visible = False
        'DatumOtp.Visible = False
        'btnPrihvati.Visible = False
        'tbStanicaOtp.Text = ""
        'tbBrojOtp.Text = ""

        'GroupBox3.Visible = False

    End Sub
  

    Private Sub tbStanicaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaOtp.KeyPress
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

    Private Sub DatumOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DatumOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DatumOtp.Validating
        Button3.Focus()
    End Sub

    Private Sub tbPosN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPosN.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrimN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrimN.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPosN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbPosN.Validating
        Dim zNaziv As String = ""
        Dim zMesto As String = ""
        Dim zZemlja As String = ""
        Dim zAdresa As String = ""
        Dim zPovVrednost As String = ""

        If (tbPosN.Text <> "" And tbPosN.Text <> "0") Then
            Util.sNadjiKorisnika(CInt(tbPosN.Text), zNaziv, zMesto, zZemlja, zAdresa, zPovVrednost)
        Else
            updPosiljalac = 0
        End If


        If zPovVrednost <> "" Then
            zNaziv = "Nepostojeci korisnik!"
            LabelNazivPosN.Text = zNaziv
            tbPosN.Focus()
        Else
            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            LabelNazivPosN.Text = zNaziv
            updPosiljalac = CInt(tbPosN.Text)
            Me.tbPrimN.Focus()
        End If

        'If (tbPosN.Text = "") Or (tbPosN.Text = "0") Then
        '    mPosiljalac = 0
        'Else
        '    'updPosiljalac = tbPosN.Text
        'End If

    End Sub

    Private Sub tbPrimN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbPrimN.Validating
        Dim xNaziv As String = ""
        Dim xMesto As String = ""
        Dim xZemlja As String = ""
        Dim xAdresa As String = ""
        Dim xPovVrednost As String = ""

        If (tbPrimN.Text <> "" And tbPrimN.Text <> "0") Then
            Util.sNadjiKorisnika(CInt(tbPrimN.Text), xNaziv, xMesto, xZemlja, xAdresa, xPovVrednost)
        Else
            updPrimalac = 0
        End If

        If xPovVrednost <> "" Then
            xNaziv = "Nepostojeci korisnik!"
            LabelNazivPrimN.Text = xNaziv
            tbPrimN.Focus()
        Else
            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            LabelNazivPrimN.Text = xNaziv
            updPrimalac = CInt(tbPrimN.Text)            
            btnPrihvati.Focus()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim helpUic As New HelpForm

        Dim yNaziv As String = ""
        Dim yMesto As String = ""
        Dim yZemlja As String = ""
        Dim yAdresa As String = ""
        Dim yPovVrednost As String = ""

        helpUic.Text = "     Pošiljalac"
        upit = "Posiljalac"
        helpUic.ShowDialog()
        'mIzlaz5   sifra
        'mIzlaz2   naziv 
        'mIzlaz1   land+Mesto
        'mIzlaz4   adresa

       
        Util.sNadjiKorisnika(mIzlaz5, yNaziv, yMesto, yZemlja, yAdresa, yPovVrednost)

        If yPovVrednost <> "" Then
            yNaziv = "Nepostojeci korisnik!"
            LabelNazivPosN.Text = yNaziv
            tbPosN.Focus()
        Else
            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            Me.LabelNazivPosN.Text = yNaziv
            tbPosN.Text = CType(mIzlaz5, Integer)
            updPosiljalac = mIzlaz5
            Me.Button2.Focus()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim helpUic As New HelpForm

        Dim xNaziv As String = ""
        Dim xMesto As String = ""
        Dim xZemlja As String = ""
        Dim xAdresa As String = ""
        Dim xPovVrednost As String = ""

        helpUic.Text = "     Primalac"
        upit = "Primalac"
        helpUic.ShowDialog()
      
        Util.sNadjiKorisnika(mIzlaz5, xNaziv, xMesto, xZemlja, xAdresa, xPovVrednost)

        If xPovVrednost <> "" Then
            LabelNazivPrimN.Text = "Nepostojeci korisnik!"
            tbPrimN.Focus()
        Else
            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            LabelNazivPrimN.Text = xNaziv
            tbPrimN.Text = CType(mIzlaz5, Integer)
            updPrimalac = mIzlaz5
            Me.btnPrihvati.Focus()
        End If
      
    End Sub
End Class
