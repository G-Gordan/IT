Imports System.Data.SqlClient
Public Class OtpIzmena
    Inherits System.Windows.Forms.Form
    Public eZemlja As String
    Public eStanica As String
    Public eOperater As String
    Public eCimBroj As String
    Public eCimID As Int32
    Public nmFindSecond As String = "0"


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
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbBrojOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbUpravaOtp As System.Windows.Forms.TextBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbECim As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbKB1 As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents tbKB2 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(OtpIzmena))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.tbBrojOtp = New System.Windows.Forms.TextBox
        Me.tbStanicaOtp = New System.Windows.Forms.TextBox
        Me.tbUpravaOtp = New System.Windows.Forms.TextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.tbECim = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button6 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label11 = New System.Windows.Forms.Label
        Me.tbKB1 = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.tbKB2 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbKB2)
        Me.GroupBox1.Controls.Add(Me.tbKB1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.tbBrojOtp)
        Me.GroupBox1.Controls.Add(Me.tbStanicaOtp)
        Me.GroupBox1.Controls.Add(Me.tbUpravaOtp)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 464)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 184)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ CIM  - podaci o otpravljanju ] "
        '
        'Label7
        '
        Me.Label7.Enabled = False
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(136, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "[ 5 ]"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label6
        '
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(136, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "[ 2+5 ]"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label5
        '
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(136, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "[ 4 ]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(8, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Sifra otpravne stanice"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Sifra operatera"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Location = New System.Drawing.Point(8, 144)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 16)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Broj otpravljanja"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojOtp.Location = New System.Drawing.Point(136, 136)
        Me.tbBrojOtp.MaxLength = 5
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.Size = New System.Drawing.Size(88, 22)
        Me.tbBrojOtp.TabIndex = 2
        Me.tbBrojOtp.Text = ""
        Me.tbBrojOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbBrojOtp, "5+1")
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaOtp.Location = New System.Drawing.Point(136, 88)
        Me.tbStanicaOtp.MaxLength = 7
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.Size = New System.Drawing.Size(88, 22)
        Me.tbStanicaOtp.TabIndex = 1
        Me.tbStanicaOtp.Text = ""
        Me.tbStanicaOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbStanicaOtp, "2+5+1")
        '
        'tbUpravaOtp
        '
        Me.tbUpravaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUpravaOtp.Location = New System.Drawing.Point(136, 44)
        Me.tbUpravaOtp.MaxLength = 4
        Me.tbUpravaOtp.Name = "tbUpravaOtp"
        Me.tbUpravaOtp.Size = New System.Drawing.Size(88, 22)
        Me.tbUpravaOtp.TabIndex = 0
        Me.tbUpravaOtp.Text = ""
        Me.tbUpravaOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbUpravaOtp, "4 ")
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(247, 14)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(824, 658)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(77, 64)
        Me.btnPrihvati.TabIndex = 2
        Me.btnPrihvati.Text = "Izaberi"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(931, 658)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(77, 64)
        Me.btnOtkazi.TabIndex = 3
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(214, 658)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(77, 64)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Pronadji"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 128)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(288, 328)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.White
        Me.DataGrid1.BackColor = System.Drawing.Color.White
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.Black
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.FlatMode = True
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DataGrid1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.DataGrid1.GridLineColor = System.Drawing.Color.DarkGray
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver
        Me.DataGrid1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.White
        Me.DataGrid1.LinkColor = System.Drawing.Color.DarkGreen
        Me.DataGrid1.Location = New System.Drawing.Point(296, 128)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.DarkOliveGreen
        Me.DataGrid1.SelectionForeColor = System.Drawing.Color.White
        Me.DataGrid1.Size = New System.Drawing.Size(712, 520)
        Me.DataGrid1.TabIndex = 11
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridLineColor = System.Drawing.Color.DarkGray
        Me.DataGridTableStyle1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Supergrid"
        Me.DataGridTableStyle1.ReadOnly = True
        Me.DataGridTableStyle1.SelectionBackColor = System.Drawing.Color.DarkOliveGreen
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.Location = New System.Drawing.Point(360, 664)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 40)
        Me.Button2.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.Button2, "Prikazi")
        Me.Button2.Visible = False
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.Location = New System.Drawing.Point(312, 664)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(40, 40)
        Me.Button4.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.Button4, "Prikazi")
        Me.Button4.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.Location = New System.Drawing.Point(576, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 25)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Prikazi"
        Me.ToolTip1.SetToolTip(Me.Button1, "Prikazi")
        '
        'tbECim
        '
        Me.tbECim.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbECim.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbECim.Location = New System.Drawing.Point(447, 17)
        Me.tbECim.MaxLength = 2
        Me.tbECim.Name = "tbECim"
        Me.tbECim.Size = New System.Drawing.Size(104, 24)
        Me.tbECim.TabIndex = 0
        Me.tbECim.Text = ""
        Me.tbECim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbECim, "Šifra uprave")
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(64, Byte), CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(48, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 50)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Baza elektronskih tovarnih listova"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"1. Sifra otpravne zemlje   ", "2. Sifra otpravne stanice   "})
        Me.ComboBox1.Location = New System.Drawing.Point(216, 17)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(222, 24)
        Me.ComboBox1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Pretrazivanje podataka:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Enabled = False
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(40, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(216, 50)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Formirana na onovu sporazuma o razmeni elektronskih tovarnih listova izmedu RCA /" & _
        " RCH i ŽS 2013."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(96, 3)
        Me.TextBox1.MaxLength = 12
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(112, 23)
        Me.TextBox1.TabIndex = 26
        Me.TextBox1.Text = ""
        '
        'Label9
        '
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Broj vagona"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.Location = New System.Drawing.Point(216, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(64, 24)
        Me.Button5.TabIndex = 28
        Me.Button5.Text = "Prikazi"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Location = New System.Drawing.Point(296, 96)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(712, 32)
        Me.Panel1.TabIndex = 29
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.Location = New System.Drawing.Point(508, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(64, 24)
        Me.Button6.TabIndex = 31
        Me.Button6.Text = "Prikazi"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(384, 3)
        Me.TextBox2.MaxLength = 6
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(112, 23)
        Me.TextBox2.TabIndex = 30
        Me.TextBox2.Text = ""
        '
        'Label10
        '
        Me.Label10.Enabled = False
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(328, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 16)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "CIM No"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.ComboBox1)
        Me.Panel2.Controls.Add(Me.tbECim)
        Me.Panel2.Location = New System.Drawing.Point(296, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(712, 56)
        Me.Panel2.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.Enabled = False
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(453, -1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 16)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "[]"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label11.Visible = False
        '
        'tbKB1
        '
        Me.tbKB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKB1.Location = New System.Drawing.Point(224, 88)
        Me.tbKB1.MaxLength = 1
        Me.tbKB1.Name = "tbKB1"
        Me.tbKB1.Size = New System.Drawing.Size(16, 22)
        Me.tbKB1.TabIndex = 14
        Me.tbKB1.Text = ""
        Me.tbKB1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbKB1, "2+5+1")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'tbKB2
        '
        Me.tbKB2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKB2.Location = New System.Drawing.Point(224, 136)
        Me.tbKB2.MaxLength = 1
        Me.tbKB2.Name = "tbKB2"
        Me.tbKB2.Size = New System.Drawing.Size(16, 22)
        Me.tbKB2.TabIndex = 15
        Me.tbKB2.Text = ""
        Me.tbKB2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbKB2, "2+5+1")
        '
        'OtpIzmena
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1018, 732)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OtpIzmena"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preuzimanje elektronskog tovarnog lista"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub tbUpravaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUpravaOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
        'Me.PictureBox2.Visible = False
        'Me.tbStanicaOtp.Text = Microsoft.VisualBasic.Right(Me.tbUpravaOtp.Text, 2)
        'Me.tbStanicaOtp.SelectionStart = 3
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

    Private Sub DatumOtp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim mRetVal As String

        NadjieCim(Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2), Microsoft.VisualBasic.Right(tbStanicaOtp.Text, 5) & tbKB1.Text, _
                  tbUpravaOtp.Text, tbBrojOtp.Text & tbKB2.Text, UpdRecID, _
                  mRetVal)

        'NadjieCim(Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2), Microsoft.VisualBasic.Right(tbStanicaOtp.Text, 6), _
        '  tbUpravaOtp.Text, tbBrojOtp.Text, UpdRecID, _
        '  mRetVal)

        If mRetVal = "" Then
            Me.PictureBox2.Visible = True
            '========
            eZemlja = Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2)
            eStanica = Microsoft.VisualBasic.Right(tbStanicaOtp.Text, 6)
            eOperater = tbUpravaOtp.Text
            eCimBroj = tbBrojOtp.Text
            eCimID = UpdRecID
            btnPrihvati_Click(Me, Nothing)

        Else
            MessageBox.Show("Ne postoji takav podatak!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tbUpravaOtp.Focus()
        End If

    End Sub

    Private Sub DatumOtp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Button3.Focus()

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub DateTimePicker2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        btnPrihvati.Focus()
    End Sub

    Private Sub OtpIzmena_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbUpravaOtp.Text = mOtpUprava
        tbStanicaOtp.Text = mOtpStanica
        tbBrojOtp.Text = mOtpBroj
        ComboBox1.SelectedIndex = 0
        tbECim.Focus()

        'DatumOtp.Text = mOtpDatum
    End Sub

    Private Sub tbBrojOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojOtp.Validating
        If IsNumeric(tbBrojOtp.Text) = True Then
            Dim tmp_kbotp As String
            Dim tmp_brotp As String = Microsoft.VisualBasic.Right("00000" & tbBrojOtp.Text.ToString, 5)

            b5Modul(tmp_brotp, tmp_kbotp)

            tbKB2.Text = tmp_kbotp
            ErrorProvider1.SetError(tbKB2, "")
            Me.Button3.Focus()
        Else
            ErrorProvider1.SetError(tbKB2, "Neispravan unos!")
            tbBrojOtp.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dsNajave1 As New DataSet("dsNajave1")
        Dim string1 As String = ""
        Dim ii As Int32 = 0

        If nmFindSecond = "0" Then
            string1 = "SELECT ecim.XML_FILES.COUNTRY AS Zemlja, ecim.XML_FILES.STATION AS Stanica, ecim.XML_FILES.OPERATER AS Operater, " & _
                      "ecim.XML_FILES.CONSIGNMENT_NOTE AS Broj, ecim.XML_NODES.NODE_VALUE AS Vagon, ecim.XML_NODES.ID_FILE as ID " & _
                      "FROM ecim.XML_NODES INNER JOIN " & _
                      "ecim.XML_FILES ON ecim.XML_NODES.ID_FILE = ecim.XML_FILES.ID_FILE FULL OUTER JOIN " & _
                      "ecim.NODE_ATTRIBUTES ON ecim.XML_NODES.ID_NODE = ecim.NODE_ATTRIBUTES.ID_NODE " & _
                      "WHERE (ecim.XML_FILES.IMPORTED = '0') AND (ecim.XML_NODES.NODE_NAME = 'wg_nr') AND (ecim.XML_FILES.COUNTRY = '" & Microsoft.VisualBasic.Left(tbECim.Text, 2) & "') AND (ecim.XML_FILES.STATION = '" & Microsoft.VisualBasic.Right(tbECim.Text, 6) & "') " & _
                      "ORDER BY ecim.XML_FILES.COUNTRY, ecim.XML_FILES.STATION, ecim.XML_FILES.CONSIGNMENT_NOTE"

        ElseIf nmFindSecond = "1" Then
            string1 = "SELECT ecim.XML_FILES.COUNTRY AS Zemlja, ecim.XML_FILES.STATION AS Stanica, ecim.XML_FILES.OPERATER AS Operater, " & _
                      "ecim.XML_FILES.CONSIGNMENT_NOTE AS Broj, ecim.XML_NODES.NODE_VALUE AS Vagon, ecim.XML_NODES.ID_FILE as ID " & _
                      "FROM ecim.XML_NODES INNER JOIN " & _
                      "ecim.XML_FILES ON ecim.XML_NODES.ID_FILE = ecim.XML_FILES.ID_FILE FULL OUTER JOIN " & _
                      "ecim.NODE_ATTRIBUTES ON ecim.XML_NODES.ID_NODE = ecim.NODE_ATTRIBUTES.ID_NODE " & _
                      "WHERE (ecim.XML_FILES.IMPORTED = '0') AND (ecim.XML_NODES.NODE_NAME = 'wg_nr') AND (ecim.XML_FILES.COUNTRY = '" & Microsoft.VisualBasic.Left(tbECim.Text, 2) & "') AND (ecim.XML_FILES.STATION = '" & Microsoft.VisualBasic.Right(tbECim.Text, 6) & "') " & _
                      "AND (ecim.XML_NODES.NODE_VALUE = '" & TextBox1.Text & "') " & _
                      "ORDER BY ecim.XML_FILES.COUNTRY, ecim.XML_FILES.STATION, ecim.XML_FILES.CONSIGNMENT_NOTE"
        ElseIf nmFindSecond = "2" Then
            string1 = "SELECT ecim.XML_FILES.COUNTRY AS Zemlja, ecim.XML_FILES.STATION AS Stanica, ecim.XML_FILES.OPERATER AS Operater, " & _
                      "ecim.XML_FILES.CONSIGNMENT_NOTE AS Broj, ecim.XML_NODES.NODE_VALUE AS Vagon, ecim.XML_NODES.ID_FILE as ID " & _
                      "FROM ecim.XML_NODES INNER JOIN " & _
                      "ecim.XML_FILES ON ecim.XML_NODES.ID_FILE = ecim.XML_FILES.ID_FILE FULL OUTER JOIN " & _
                      "ecim.NODE_ATTRIBUTES ON ecim.XML_NODES.ID_NODE = ecim.NODE_ATTRIBUTES.ID_NODE " & _
                      "WHERE (ecim.XML_FILES.IMPORTED = '0') AND (ecim.XML_NODES.NODE_NAME = 'wg_nr') AND (ecim.XML_FILES.COUNTRY = '" & Microsoft.VisualBasic.Left(tbECim.Text, 2) & "') AND (ecim.XML_FILES.STATION = '" & Microsoft.VisualBasic.Right(tbECim.Text, 6) & "') " & _
                      "AND (ecim.XML_FILES.CONSIGNMENT_NOTE = '" & TextBox2.Text & "') " & _
                      "ORDER BY ecim.XML_FILES.COUNTRY, ecim.XML_FILES.STATION, ecim.XML_FILES.CONSIGNMENT_NOTE"
        End If

        '------------------ Format kolona ----------------------
        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing
        Dim _dataSet As DataSet
        _dataSet = Nothing

        Try
            If eCimVeza.State = ConnectionState.Closed Then
                eCimVeza.Open()
            End If

            dataAdapter = New SqlDataAdapter(string1, eCimVeza)
            _dataSet = New DataSet

            ii = dataAdapter.Fill(_dataSet, "SuperGrid")

            eCimVeza.Close()

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        Dim tableStyle As DataGridTableStyle
        tableStyle = New DataGridTableStyle
        tableStyle.MappingName = "SuperGrid"

        If ii = 0 Then
            MsgBox("Nedostupni podaci iz baze!", MsgBoxStyle.Information, "Poruka iz baze")
            Me.Close()
        Else
            DataGrid1.TableStyles.Clear()
            DataGrid1.TableStyles.Add(tableStyle)
            Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
            DataGrid1.ReadOnly = True
            DataGrid1.CaptionText = "Elektronski tovarni listovi iz stanice : " & Me.tbECim.Text
            DataGrid1.DataSource = _dataSet.Tables("SuperGrid")

            AutoSizeTable()
        End If

    End Sub
    Public Sub AutoSizeTable()

        Dim numCols As Integer
        numCols = CType(DataGrid1.DataSource, DataTable).Columns.Count
        Dim i As Integer
        i = 0
        Do While (i < numCols)
            AutoSizeCol(i)
            i = (i + 1)
        Loop
    End Sub
    Public Sub AutoSizeCol(ByVal col As Integer)
        Dim width As Single
        width = 0
        Dim numRows As Integer
        numRows = CType(DataGrid1.DataSource, DataTable).Rows.Count
        Dim g As Graphics
        g = Graphics.FromHwnd(DataGrid1.Handle)
        Dim sf As StringFormat
        sf = New StringFormat(StringFormat.GenericTypographic)
        Dim size As SizeF
        Dim i As Integer
        i = 0

        Do While (i < numRows)
            size = g.MeasureString(DataGrid1(i, col).ToString, DataGrid1.Font, 500, sf)
            If (size.Width > width) Then
                width = size.Width + 45
            End If
            i = (i + 1)

        Loop
        g.Dispose()
        DataGrid1.TableStyles("SuperGrid").GridColumnStyles(col).Width = CType(width, Integer)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim dsNajave1 As New DataSet("dsNajave1")
        Dim string1 As String = ""
        Dim ii As Int32 = 0

        If nmFindSecond = "0" Then
            string1 = "SELECT ecim.XML_FILES.COUNTRY AS Zemlja, ecim.XML_FILES.STATION AS Stanica, ecim.XML_FILES.OPERATER AS Operater, " & _
                      "ecim.XML_FILES.CONSIGNMENT_NOTE AS Broj, ecim.XML_NODES.NODE_VALUE AS Vagon, ecim.XML_NODES.ID_FILE as ID, ecim.XML_FILES.FTP_DATE as [Datum razmene]" & _
                      "FROM ecim.XML_NODES INNER JOIN " & _
                      "ecim.XML_FILES ON ecim.XML_NODES.ID_FILE = ecim.XML_FILES.ID_FILE FULL OUTER JOIN " & _
                      "ecim.NODE_ATTRIBUTES ON ecim.XML_NODES.ID_NODE = ecim.NODE_ATTRIBUTES.ID_NODE " & _
                      "WHERE (ecim.XML_FILES.IMPORTED = '0') AND (ecim.XML_NODES.NODE_NAME = 'wg_nr') AND (ecim.XML_FILES.COUNTRY = '" & tbECim.Text & "') AND (ecim.XML_FILES.FTP_DATE > CONVERT(DATETIME, '2013-09-09 00:00:00', 102)) " & _
                      "ORDER BY ecim.XML_FILES.FTP_DATE DESC, ecim.XML_FILES.COUNTRY, ecim.XML_FILES.STATION, ecim.XML_FILES.CONSIGNMENT_NOTE"
        ElseIf nmFindSecond = "1" Then
            string1 = "SELECT ecim.XML_FILES.COUNTRY AS Zemlja, ecim.XML_FILES.STATION AS Stanica, ecim.XML_FILES.OPERATER AS Operater, " & _
                      "ecim.XML_FILES.CONSIGNMENT_NOTE AS Broj, ecim.XML_NODES.NODE_VALUE AS Vagon, ecim.XML_NODES.ID_FILE as ID, ecim.XML_FILES.FTP_DATE as [Datum razmene]" & _
                      "FROM ecim.XML_NODES INNER JOIN " & _
                      "ecim.XML_FILES ON ecim.XML_NODES.ID_FILE = ecim.XML_FILES.ID_FILE FULL OUTER JOIN " & _
                      "ecim.NODE_ATTRIBUTES ON ecim.XML_NODES.ID_NODE = ecim.NODE_ATTRIBUTES.ID_NODE " & _
                      "WHERE (ecim.XML_FILES.IMPORTED = '0') AND (ecim.XML_NODES.NODE_NAME = 'wg_nr') AND (ecim.XML_FILES.COUNTRY = '" & tbECim.Text & "') AND (ecim.XML_NODES.NODE_VALUE = '" & TextBox1.Text & "') AND (ecim.XML_FILES.FTP_DATE > CONVERT(DATETIME, '2013-09-09 00:00:00', 102)) " & _
                      "ORDER BY ecim.XML_FILES.FTP_DATE DESC, ecim.XML_FILES.COUNTRY, ecim.XML_FILES.STATION, ecim.XML_FILES.CONSIGNMENT_NOTE"
        ElseIf nmFindSecond = "2" Then
            string1 = "SELECT ecim.XML_FILES.COUNTRY AS Zemlja, ecim.XML_FILES.STATION AS Stanica, ecim.XML_FILES.OPERATER AS Operater, " & _
                      "ecim.XML_FILES.CONSIGNMENT_NOTE AS Broj, ecim.XML_NODES.NODE_VALUE AS Vagon, ecim.XML_NODES.ID_FILE as ID, ecim.XML_FILES.FTP_DATE as [Datum razmene]" & _
                      "FROM ecim.XML_NODES INNER JOIN " & _
                      "ecim.XML_FILES ON ecim.XML_NODES.ID_FILE = ecim.XML_FILES.ID_FILE FULL OUTER JOIN " & _
                      "ecim.NODE_ATTRIBUTES ON ecim.XML_NODES.ID_NODE = ecim.NODE_ATTRIBUTES.ID_NODE " & _
                      "WHERE (ecim.XML_FILES.IMPORTED = '0') AND (ecim.XML_NODES.NODE_NAME = 'wg_nr') AND (ecim.XML_FILES.COUNTRY = '" & tbECim.Text & "') AND (ecim.XML_FILES.CONSIGNMENT_NOTE = '" & TextBox2.Text & "') AND (ecim.XML_FILES.FTP_DATE > CONVERT(DATETIME, '2013-09-09 00:00:00', 102)) " & _
                      "ORDER BY ecim.XML_FILES.FTP_DATE DESC, ecim.XML_FILES.COUNTRY, ecim.XML_FILES.STATION, ecim.XML_FILES.CONSIGNMENT_NOTE"
        End If


        '------------------ Format kolona ----------------------
        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing
        Dim _dataSet As DataSet
        _dataSet = Nothing

        Try
            If eCimVeza.State = ConnectionState.Closed Then
                eCimVeza.Open()
            End If

            dataAdapter = New SqlDataAdapter(string1, eCimVeza)
            _dataSet = New DataSet

            ii = dataAdapter.Fill(_dataSet, "SuperGrid")

            eCimVeza.Close()

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        Dim tableStyle As DataGridTableStyle
        tableStyle = New DataGridTableStyle
        tableStyle.MappingName = "SuperGrid"

        If ii = 0 Then
            MsgBox("Nedostupni podaci iz baze!", MsgBoxStyle.Information, "Poruka iz baze")
            Me.Close()
        Else
            DataGrid1.TableStyles.Clear()
            DataGrid1.TableStyles.Add(tableStyle)
            Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
            DataGrid1.ReadOnly = True
            DataGrid1.CaptionText = "Elektronski tovarni listovi iz zemlje : " & Me.tbECim.Text
            DataGrid1.DataSource = _dataSet.Tables("SuperGrid")

            AutoSizeTable()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        nmFindSecond = "0"
        If Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "1" Then
            Button4_Click(Me, Nothing)
        ElseIf Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "2" Then
            Button2_Click(Me, Nothing)
        Else
            Me.ComboBox1.Focus()
        End If
    End Sub

    Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        If Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "1" Then
            Me.tbECim.Text = ""
            Me.tbECim.MaxLength = 2
            Me.Label11.Visible = True
            Me.Label11.Text = "[ 2 ]"
            tbECim.Focus()
        ElseIf Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "2" Then
            Me.tbECim.Text = ""
            Me.tbECim.MaxLength = 8
            Me.Label11.Visible = True
            Me.Label11.Text = "[ 2+5+1 ]"
            tbECim.Focus()
        Else
            Me.Label11.Visible = False
            Me.ComboBox1.Focus()

        End If

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbECim_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbECim.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        Dim string2 As String = ""

        eZemlja = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
        eStanica = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
        eOperater = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
        eCimBroj = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)
        eCimID = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5)

    End Sub
    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim mRetVal As String
        Try
            DownloadCim(eCimID)


            If mRetVal = "" Then
                RecordAction = "I"
                eRazmena = "Da"

                If IzborSaobracaja = "4" Then

                    If DbVeza.State = ConnectionState.Closed Then
                        DbVeza.Open()
                    End If

                    Dim sql_text As String = "SELECT UlaznaNalepnica " & _
                                             "FROM dbo.ZsTrzNalepnice " & _
                                             "WHERE (dbo.ZsTrzNalepnice.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

                    Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
                    Dim rdrTrz As SqlClient.SqlDataReader

                    rdrTrz = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                    Do While rdrTrz.Read()
                        mUlEtiketa = rdrTrz.GetInt32(0) + 1
                    Loop
                    rdrTrz.Close()
                    DbVeza.Close()
                    '-----------------

                    TipTranzita = "ulaz"
                    mIzEtiketa = 0

                    Dim fCim As New FormCim
                    IzborSaobracaja = "4"
                    bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
                    fCim.Text = ":: CIM - Tranzit ULAZ ::"
                    fCim.ShowDialog()
                Else

                    Dim fCim As New FormCim
                    IzborSaobracaja = "2"
                    bVrstaSaobracaja = CType(IzborSaobracaja, Integer)
                    fCim.Text = ":: CIM - U V O Z ::"
                    fCim.ShowDialog()
                End If
            Else
                MessageBox.Show("Ne postoji mogucnost prikaza podataka!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Greska prilikom preuzimanja podataka. Pokusajte ponovo.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tbUpravaOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaOtp.Leave
        Me.tbStanicaOtp.Text = Microsoft.VisualBasic.Right(Me.tbUpravaOtp.Text, 2)
        Me.tbStanicaOtp.SelectionStart = 3
    End Sub

    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        Dim string2 As String = ""

        eZemlja = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
        eStanica = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
        eOperater = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
        eCimBroj = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)
        eCimID = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5)

        btnPrihvati_Click(Me, Nothing)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        nmFindSecond = "1"

        If Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "1" Then
            Button4_Click(Me, Nothing)
        ElseIf Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "2" Then
            Button2_Click(Me, Nothing)
        Else
            Me.ComboBox1.Focus()
        End If

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        nmFindSecond = "2"

        If Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "1" Then
            Button4_Click(Me, Nothing)
        ElseIf Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "2" Then
            Button2_Click(Me, Nothing)
        Else
            Me.ComboBox1.Focus()
        End If

    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        tbECim.Focus()

    End Sub

    Private Sub tbStanicaOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaOtp.Validating
        If IsNumeric(tbStanicaOtp.Text) = True Then
            Dim tmp_kbotp As String
            Dim tmp_stotp As String = Microsoft.VisualBasic.Right(tbStanicaOtp.Text, 5)

            b5Modul(tmp_stotp, tmp_kbotp)

            tbKB1.Text = tmp_kbotp
            ErrorProvider1.SetError(tbKB1, "")
            Me.tbBrojOtp.Focus()

        Else
            ErrorProvider1.SetError(tbKB1, "Neispravan unos!")
            tbStanicaOtp.Focus()
        End If
    End Sub

    Private Sub tbBrojOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.Leave
        tbBrojOtp.Text = Microsoft.VisualBasic.Right("00000" & tbBrojOtp.Text.ToString, 5)
    End Sub
End Class
