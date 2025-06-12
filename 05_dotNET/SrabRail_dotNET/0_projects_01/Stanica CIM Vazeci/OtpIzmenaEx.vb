Imports System.Data.SqlClient
Public Class OtpIzmenaEx
    Inherits System.Windows.Forms.Form
    Public eZemlja As String
    Public eStanica As String
    Public eOperater As String
    Public eCimBroj As String
    Public eCimID As Int32


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
    Friend WithEvents tbStanica As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(OtpIzmenaEx))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
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
        Me.tbStanica = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.tbBrojOtp)
        Me.GroupBox1.Controls.Add(Me.tbStanicaOtp)
        Me.GroupBox1.Controls.Add(Me.tbUpravaOtp)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(32, 536)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(136, 72)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ CIM  - podaci o otpravljanju ] "
        Me.GroupBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(24, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Sifra otpravne stanice"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(24, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Sifra operatera"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Location = New System.Drawing.Point(24, 135)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 16)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Broj otpravljanja"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojOtp.Location = New System.Drawing.Point(168, 128)
        Me.tbBrojOtp.MaxLength = 6
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.TabIndex = 2
        Me.tbBrojOtp.Text = ""
        Me.tbBrojOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbBrojOtp, "5+1")
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaOtp.Location = New System.Drawing.Point(168, 80)
        Me.tbStanicaOtp.MaxLength = 8
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.TabIndex = 1
        Me.tbStanicaOtp.Text = "72"
        Me.tbStanicaOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbStanicaOtp, "2+5")
        '
        'tbUpravaOtp
        '
        Me.tbUpravaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUpravaOtp.Location = New System.Drawing.Point(168, 32)
        Me.tbUpravaOtp.MaxLength = 4
        Me.tbUpravaOtp.Name = "tbUpravaOtp"
        Me.tbUpravaOtp.TabIndex = 0
        Me.tbUpravaOtp.Text = "0072"
        Me.tbUpravaOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbUpravaOtp, "4 ")
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(278, 126)
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
        Me.btnPrihvati.Location = New System.Drawing.Point(744, 536)
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
        Me.btnOtkazi.Location = New System.Drawing.Point(848, 536)
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
        Me.Button3.Location = New System.Drawing.Point(248, 536)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(77, 64)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Pronadji"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 60)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 465)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.White
        Me.DataGrid1.BackColor = System.Drawing.Color.White
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.Black
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.FlatMode = True
        Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.DataGrid1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.DataGrid1.GridLineColor = System.Drawing.Color.DarkGray
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver
        Me.DataGrid1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.White
        Me.DataGrid1.LinkColor = System.Drawing.Color.DarkGreen
        Me.DataGrid1.Location = New System.Drawing.Point(344, 60)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.DarkOliveGreen
        Me.DataGrid1.SelectionForeColor = System.Drawing.Color.White
        Me.DataGrid1.Size = New System.Drawing.Size(584, 465)
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
        Me.Button2.Location = New System.Drawing.Point(944, 112)
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
        Me.Button4.Location = New System.Drawing.Point(944, 64)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(40, 40)
        Me.Button4.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.Button4, "Prikazi")
        Me.Button4.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.Location = New System.Drawing.Point(600, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 24)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Pronadji"
        Me.ToolTip1.SetToolTip(Me.Button1, "Prikazi")
        '
        'tbECim
        '
        Me.tbECim.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tbECim.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbECim.Location = New System.Drawing.Point(912, 16)
        Me.tbECim.MaxLength = 1
        Me.tbECim.Name = "tbECim"
        Me.tbECim.Size = New System.Drawing.Size(48, 24)
        Me.tbECim.TabIndex = 6
        Me.tbECim.Text = ""
        Me.tbECim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbECim, "2+5+1")
        Me.tbECim.Visible = False
        '
        'tbStanica
        '
        Me.tbStanica.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanica.Location = New System.Drawing.Point(504, 32)
        Me.tbStanica.MaxLength = 5
        Me.tbStanica.Name = "tbStanica"
        Me.tbStanica.Size = New System.Drawing.Size(93, 24)
        Me.tbStanica.TabIndex = 0
        Me.tbStanica.Text = ""
        Me.tbStanica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbStanica, "sifra otpravne stanice")
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(336, 53)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Baza tovarnih listova u izvozu"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"1. Sifra otpravne zemlje", "2. Sifra otpravne stanice"})
        Me.ComboBox1.Location = New System.Drawing.Point(760, 16)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(136, 24)
        Me.ComboBox1.TabIndex = 7
        Me.ComboBox1.Visible = False
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(349, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Tovarni listovi iz stanice: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'OtpIzmenaEx
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(994, 624)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbECim)
        Me.Controls.Add(Me.tbStanica)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OtpIzmenaEx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preuzimanje elektronskog tovarnog lista"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
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

        NadjieCim(Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2), Microsoft.VisualBasic.Right(tbStanicaOtp.Text, 6), _
                  tbUpravaOtp.Text, tbBrojOtp.Text, UpdRecID, _
                  mRetVal)

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

    Private Sub OtpIzmenaEx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbUpravaOtp.Text = mOtpUprava
        tbStanicaOtp.Text = mOtpStanica
        tbBrojOtp.Text = mOtpBroj
        'DatumOtp.Text = mOtpDatum
    End Sub

    Private Sub tbBrojOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojOtp.Validating
        If Len(tbBrojOtp.Text) < 6 Then
            For dd As Int16 = 1 To 6 - Len(tbBrojOtp.Text)
                tbBrojOtp.Text = "0" & tbBrojOtp.Text
            Next
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dsNajave1 As New DataSet("dsNajave1")
        Dim string1 As String = ""
        Dim ii As Int32 = 0

        ''string1 = "SELECT ecim.XML_FILES.COUNTRY AS Zemlja, ecim.XML_FILES.STATION AS Stanica, ecim.XML_FILES.OPERATER AS Operater, " & _
        ''          "ecim.XML_FILES.CONSIGNMENT_NOTE AS Broj, ecim.XML_NODES.NODE_VALUE AS Vagon, ecim.XML_NODES.ID_FILE as ID " & _
        ''          "FROM ecim.XML_NODES INNER JOIN " & _
        ''          "ecim.XML_FILES ON ecim.XML_NODES.ID_FILE = ecim.XML_FILES.ID_FILE FULL OUTER JOIN " & _
        ''          "ecim.NODE_ATTRIBUTES ON ecim.XML_NODES.ID_NODE = ecim.NODE_ATTRIBUTES.ID_NODE " & _
        ''          "WHERE (ecim.XML_FILES.IMPORTED = '0') AND (ecim.XML_NODES.NODE_NAME = 'wg_nr') AND (ecim.XML_FILES.COUNTRY = '" & Microsoft.VisualBasic.Left(tbECim.Text, 2) & "') AND (ecim.XML_FILES.STATION = '" & Microsoft.VisualBasic.Right(tbECim.Text, 6) & "') " & _
        ''          "ORDER BY ecim.XML_FILES.COUNTRY, ecim.XML_FILES.STATION, ecim.XML_FILES.CONSIGNMENT_NOTE"



        '========kako izabrati
        string1 = "SELECT OtpStanica as Stanica, OtpBroj as [CIM broj], OtpDatum as [Datum otpravljanja], PrUprava as [Za upravu] " & _
                  "FROM SlogKalk " & _
                  "WHERE (OtpStanica = '72" & tbStanica.Text & "') AND (ZsIzPrelaz = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') AND (tlRealizovan IS NULL) " & _
                  "AND (Stanica <> '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

        'string1 = "SELECT Stanica as Stanica, OtpBroj as [CIM broj], OtpDatum as [Datum otpravljanja], PrUprava as [Za upravu] " & _
        '          "FROM SlogKalk " & _
        '          "WHERE (Stanica = '" & tbStanica.Text & "') AND (ZsIzPrelaz = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') AND (tlRealizovan IS NULL)"





        ''        Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)

        '------------------ Format kolona ----------------------
        Dim dataAdapter As SqlDataAdapter
        dataAdapter = Nothing
        Dim _dataSet As DataSet
        _dataSet = Nothing

        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            dataAdapter = New SqlDataAdapter(string1, DbVeza)
            _dataSet = New DataSet

            ii = dataAdapter.Fill(_dataSet, "SuperGrid")

            DbVeza.Close()

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        Dim tableStyle As DataGridTableStyle
        tableStyle = New DataGridTableStyle
        tableStyle.MappingName = "SuperGrid"

        If ii = 0 Then
            MsgBox("Ne postoje podaci za preuzimanje!", MsgBoxStyle.Information, "Poruka iz baze")
            Me.Close()
        Else
            DataGrid1.TableStyles.Clear()
            DataGrid1.TableStyles.Add(tableStyle)
            Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
            DataGrid1.ReadOnly = True
            DataGrid1.CaptionText = "Spisak tovarnih listova u izvozu preko granicnog prelaza " & RTrim(Microsoft.VisualBasic.Mid(StanicaUnosa, 11, 16)) & " Granica"
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
                width = size.Width + 75
            End If
            i = (i + 1)

        Loop
        g.Dispose()
        DataGrid1.TableStyles("SuperGrid").GridColumnStyles(col).Width = CType(width, Integer)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button2_Click(Me, Nothing)
    End Sub

    Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        If Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "1" Then
            Me.tbECim.Text = ""
            Me.tbECim.MaxLength = 2
        ElseIf Microsoft.VisualBasic.Left(ComboBox1.Text, 1) = "2" Then
            Me.tbECim.Text = ""
            Me.tbECim.MaxLength = 8
        Else
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

        mOtpUprava = "0072"
        mOtpStanica = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
        'mOtpStanica = "72" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
        mOtpBroj = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
        mOtpDatum = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

    End Sub
    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim mRetVal As String
        Dim mRecID As Int32
        Dim mStanicaRecID As String
        Dim izSifraTarife As String
        Dim izUgovor As String
        IzborSaobracaja = "3"

        '==============================================================================================================
        Util.eNadjiTovarniListUI(mOtpUprava, mOtpStanica, mOtpBroj, mOtpDatum, mRecID, mStanicaRecID, _
                                 mUlPrelaz, mIzPrelaz, msBrojVoza, mSatVoza, msBrojVoza2, mSatVoza2, _
                                 mDatumUlaza, mDatumIzlaza, izSifraTarife, izUgovor, mCarStanica, mCarStanica2, _
                                 mRetVal)


        If mRetVal = "" Then
            UpdRecID = mRecID
            UpdStanicaRecID = mStanicaRecID
            UpdUprava = mOtpUprava
            UpdStanica = mOtpStanica
            UpdBroj = mOtpBroj
            UpdDatum = mOtpDatum

            mTarifa = izSifraTarife
            mBrojUg = izUgovor


            Dim form2 As New FormUpdateCimGr
            form2.ShowDialog()
            Close()

        Else
            MessageBox.Show("Ne postoji mogucnost prikaza podataka!" & mRetVal, "Poruka iz baze: 5284", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub tbUpravaOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaOtp.Leave
        Me.tbStanicaOtp.Text = Microsoft.VisualBasic.Right(Me.tbUpravaOtp.Text, 2)
        Me.tbStanicaOtp.SelectionStart = 3
    End Sub

    Private Sub tbStanica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
End Class
