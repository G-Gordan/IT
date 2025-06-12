Imports System.Data.SqlClient
Public Class UpdCar1
    Inherits System.Windows.Forms.Form
    Public otRecID As Int32

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
    Friend WithEvents gbOstalo As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbTranzit As System.Windows.Forms.GroupBox
    Friend WithEvents cbSmer1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents tbUlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents tbJCI As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents tbUpravaOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbBrojOtp As System.Windows.Forms.TextBox
    Friend WithEvents DatumOtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbGodina As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UpdCar1))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.gbOstalo = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbUpravaOtp = New System.Windows.Forms.TextBox
        Me.DatumOtp = New System.Windows.Forms.DateTimePicker
        Me.tbBrojOtp = New System.Windows.Forms.TextBox
        Me.tbStanicaOtp = New System.Windows.Forms.TextBox
        Me.gbTranzit = New System.Windows.Forms.GroupBox
        Me.tbGodina = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.cbSmer1 = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.tbUlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.tbJCI = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.gbOstalo.SuspendLayout()
        Me.gbTranzit.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'gbOstalo
        '
        Me.gbOstalo.Controls.Add(Me.Button1)
        Me.gbOstalo.Controls.Add(Me.Label5)
        Me.gbOstalo.Controls.Add(Me.Label4)
        Me.gbOstalo.Controls.Add(Me.Label3)
        Me.gbOstalo.Controls.Add(Me.Label2)
        Me.gbOstalo.Controls.Add(Me.tbUpravaOtp)
        Me.gbOstalo.Controls.Add(Me.DatumOtp)
        Me.gbOstalo.Controls.Add(Me.tbBrojOtp)
        Me.gbOstalo.Controls.Add(Me.tbStanicaOtp)
        Me.gbOstalo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOstalo.Location = New System.Drawing.Point(424, 16)
        Me.gbOstalo.Name = "gbOstalo"
        Me.gbOstalo.Size = New System.Drawing.Size(240, 256)
        Me.gbOstalo.TabIndex = 3
        Me.gbOstalo.TabStop = False
        Me.gbOstalo.Text = " [ UVOZ ] "
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(136, 192)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 48)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Pronadji"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 18)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Datum"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Broj"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Stanica"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 22)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Operater"
        '
        'tbUpravaOtp
        '
        Me.tbUpravaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUpravaOtp.Location = New System.Drawing.Point(112, 28)
        Me.tbUpravaOtp.MaxLength = 4
        Me.tbUpravaOtp.Name = "tbUpravaOtp"
        Me.tbUpravaOtp.Size = New System.Drawing.Size(112, 23)
        Me.tbUpravaOtp.TabIndex = 0
        Me.tbUpravaOtp.Text = ""
        '
        'DatumOtp
        '
        Me.DatumOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOtp.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOtp.Location = New System.Drawing.Point(112, 152)
        Me.DatumOtp.Name = "DatumOtp"
        Me.DatumOtp.Size = New System.Drawing.Size(112, 22)
        Me.DatumOtp.TabIndex = 3
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojOtp.Location = New System.Drawing.Point(112, 112)
        Me.tbBrojOtp.MaxLength = 6
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.Size = New System.Drawing.Size(112, 22)
        Me.tbBrojOtp.TabIndex = 2
        Me.tbBrojOtp.Text = ""
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaOtp.Location = New System.Drawing.Point(112, 72)
        Me.tbStanicaOtp.MaxLength = 7
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.Size = New System.Drawing.Size(112, 22)
        Me.tbStanicaOtp.TabIndex = 1
        Me.tbStanicaOtp.Text = ""
        '
        'gbTranzit
        '
        Me.gbTranzit.Controls.Add(Me.tbGodina)
        Me.gbTranzit.Controls.Add(Me.Label16)
        Me.gbTranzit.Controls.Add(Me.btnPrihvati)
        Me.gbTranzit.Controls.Add(Me.cbSmer1)
        Me.gbTranzit.Controls.Add(Me.Label11)
        Me.gbTranzit.Controls.Add(Me.Label22)
        Me.gbTranzit.Controls.Add(Me.tbUlaznaNalepnica)
        Me.gbTranzit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTranzit.Location = New System.Drawing.Point(96, 16)
        Me.gbTranzit.Name = "gbTranzit"
        Me.gbTranzit.Size = New System.Drawing.Size(318, 256)
        Me.gbTranzit.TabIndex = 0
        Me.gbTranzit.TabStop = False
        Me.gbTranzit.Text = "[ TRANZIT ]"
        '
        'tbGodina
        '
        Me.tbGodina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGodina.Location = New System.Drawing.Point(144, 33)
        Me.tbGodina.MaxLength = 4
        Me.tbGodina.Name = "tbGodina"
        Me.tbGodina.Size = New System.Drawing.Size(89, 22)
        Me.tbGodina.TabIndex = 17
        Me.tbGodina.Text = ""
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 15)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Godina"
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(213, 192)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 48)
        Me.btnPrihvati.TabIndex = 6
        Me.btnPrihvati.Text = "Pronadji"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbSmer1
        '
        Me.cbSmer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer1.Enabled = False
        Me.cbSmer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer1.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer1.Location = New System.Drawing.Point(144, 80)
        Me.cbSmer1.Name = "cbSmer1"
        Me.cbSmer1.Size = New System.Drawing.Size(160, 24)
        Me.cbSmer1.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 24)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Broj ulazne nalepnice"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(8, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 15)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "Granicni prelaz"
        '
        'tbUlaznaNalepnica
        '
        Me.tbUlaznaNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUlaznaNalepnica.Location = New System.Drawing.Point(144, 129)
        Me.tbUlaznaNalepnica.MaxLength = 5
        Me.tbUlaznaNalepnica.Name = "tbUlaznaNalepnica"
        Me.tbUlaznaNalepnica.Size = New System.Drawing.Size(160, 22)
        Me.tbUlaznaNalepnica.TabIndex = 2
        Me.tbUlaznaNalepnica.Text = ""
        '
        'tbJCI
        '
        Me.tbJCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbJCI.Location = New System.Drawing.Point(84, 39)
        Me.tbJCI.MaxLength = 18
        Me.tbJCI.Name = "tbJCI"
        Me.tbJCI.Size = New System.Drawing.Size(144, 23)
        Me.tbJCI.TabIndex = 25
        Me.tbJCI.Text = ""
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker1.Location = New System.Drawing.Point(246, 40)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(144, 22)
        Me.DateTimePicker1.TabIndex = 26
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(398, 40)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(144, 22)
        Me.DateTimePicker2.TabIndex = 27
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbJCI)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(96, 275)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 146)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ JCI ]"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(452, 76)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 59)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Upis u bazu"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(398, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 21)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Rok carinjenja"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(246, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 21)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Datum od"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 21)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "MRN broj"
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(573, 447)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 2
        Me.btnOtkazi.Text = "Kraj rada"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UpdCar1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(674, 528)
        Me.Controls.Add(Me.gbTranzit)
        Me.Controls.Add(Me.gbOstalo)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdCar1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unos podataka za JCI"
        Me.gbOstalo.ResumeLayout(False)
        Me.gbTranzit.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub UpdCar1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cbSmer1.Text = StanicaUnosa
        Me.tbGodina.Text = Now.Today.Year.ToString
        Me.GroupBox1.Enabled = False

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim otUprava As String
        Dim otStanica As String
        Dim otBroj As Int32
        Dim otDatum As Date
        Dim ulNalepnica As Int32
        Dim izNalepnica As Int32
        Dim ulIBK As String
        Dim otBrojVoza As String
        'Dim otRecID As Int32
        Dim mRetVal As String

        mObrGodina = Me.tbGodina.Text

        NadjiUlazniTranzit2(tbUlaznaNalepnica.Text, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mObrGodina, otUprava, otStanica, otBroj, otDatum, izNalepnica, ulIBK, otBrojVoza, otRecID, mRetVal)

        If mRetVal = "" Then
            ErrorProvider1.SetError(tbUlaznaNalepnica, "")
            Me.GroupBox1.Enabled = True
            Me.tbJCI.Focus()

        Else
            Me.GroupBox1.Enabled = False
            ErrorProvider1.SetError(tbUlaznaNalepnica, "Ne postoji takav podatak!")
            Me.tbUlaznaNalepnica.Focus()
        End If

    End Sub

    Private Sub tbUlaznaNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUlaznaNalepnica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbJCI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbJCI.KeyPress
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

    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim slogTrans As SqlTransaction
        Dim updJCI As String
        Dim updDatum1, updDatum2 As Date
        Dim mRetVal As String

        updJCI = tbJCI.Text
        updDatum1 = Me.DateTimePicker1.Value.ToShortDateString
        updDatum2 = Me.DateTimePicker2.Value.ToShortDateString

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        slogTrans = DbVeza.BeginTransaction()


        If updDatum1 >= updDatum2 Then
            MsgBox("Datumi nisu uskladjeni! Datum roka carinjenja mora biti veci od dana prijavljivanja Carini.")
            mRetVal = "Greska"
        Else
            UpdateJCI(slogTrans, otRecID, updJCI, updDatum1, updDatum2, mRetVal)
        End If


        If mRetVal = "" Then
            Me.GroupBox1.Enabled = False
            slogTrans.Commit()
        Else
            MessageBox.Show("Neuspesan upis u bazu!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            slogTrans.Rollback()
        End If

        DbVeza.Close()
        Me.tbJCI.Focus()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mRetVal As String

        mOtpUprava = tbUpravaOtp.Text
        mOtpStanica = tbStanicaOtp.Text
        mOtpBroj = tbBrojOtp.Text
        mOtpDatum = DatumOtp.Value.ToShortDateString
        UpdRecID = 0

        NadjiTLuBazi(mOtpUprava, mOtpStanica, mOtpBroj, mOtpDatum, UpdRecID, UpdStanicaRecID, _
                     mRetVal)

        otRecID = UpdRecID

        If mRetVal = "" Then
            ErrorProvider1.SetError(tbUpravaOtp, "")
            Me.GroupBox1.Enabled = True
            Me.tbJCI.Focus()
        Else
            Me.GroupBox1.Enabled = False
            ErrorProvider1.SetError(tbUpravaOtp, "Ne postoji takav podatak!")
            tbUpravaOtp.Focus()
        End If

    End Sub

    Private Sub tbUpravaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUpravaOtp.KeyPress
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

    Private Sub tbUpravaOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaOtp.Leave
        tbStanicaOtp.Text = Microsoft.VisualBasic.Right(tbUpravaOtp.Text, 2)
        tbStanicaOtp.SelectionStart = 3
    End Sub

    Private Sub DateTimePicker2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker2.Validating
        If Me.DateTimePicker1.Value >= Me.DateTimePicker2.Value Then
            MsgBox("Datumi nisu uskladjeni! Datum roka carinjenja mora biti veci od dana prijavljivanja Carini.")
            Me.DateTimePicker2.Focus()

        End If
    End Sub
End Class
