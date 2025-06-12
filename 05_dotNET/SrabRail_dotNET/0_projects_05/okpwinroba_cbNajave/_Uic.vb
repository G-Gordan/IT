Imports System.Data.SqlClient
Public Class _Uic
    Inherits System.Windows.Forms.Form
    Dim dsUic As DataSet
    Public dvUic As New DataView(dtUic)
    Public _rbrValuta As Decimal
    Public _ZajednickiPrelaz As String = ""
    Public tmp_Prelaz1 As String = "New"
    Public t_UicUprava As String = ""
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgUic As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDodajNak As System.Windows.Forms.Button
    Friend WithEvents btnBrisiNak As System.Windows.Forms.Button
    Friend WithEvents btnIzmeniNak As System.Windows.Forms.Button
    Friend WithEvents tbGS As System.Windows.Forms.TextBox
    Friend WithEvents cbUicVal As System.Windows.Forms.ComboBox
    Friend WithEvents cbTLVal As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents fxUicPrevoznina As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxUicFranko As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxUicUpuceno As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents tbPrelaz1 As System.Windows.Forms.TextBox
    Friend WithEvents tbPrelaz2 As System.Windows.Forms.TextBox
    Friend WithEvents btnValute As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents fxUicNak3 As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxUicNak2 As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxUicNak1 As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents tbNak3 As System.Windows.Forms.TextBox
    Friend WithEvents tbNak2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbNak1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fxUicNaknade As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblUprava As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents cbPrecica As System.Windows.Forms.CheckBox
    Friend WithEvents lblDin As System.Windows.Forms.Label
    Friend WithEvents tbtlUpucenoDin As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(_Uic))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbPrecica = New System.Windows.Forms.CheckBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.fxUicPrevoznina = New FlxMaskBox.FlexMaskEditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbUicVal = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.fxUicNak1 = New FlxMaskBox.FlexMaskEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbNak1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbNak3 = New System.Windows.Forms.TextBox
        Me.tbNak2 = New System.Windows.Forms.TextBox
        Me.fxUicNak3 = New FlxMaskBox.FlexMaskEditBox
        Me.fxUicNak2 = New FlxMaskBox.FlexMaskEditBox
        Me.fxUicNaknade = New FlxMaskBox.FlexMaskEditBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnValute = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbPrelaz2 = New System.Windows.Forms.TextBox
        Me.tbPrelaz1 = New System.Windows.Forms.TextBox
        Me.btnBrisiNak = New System.Windows.Forms.Button
        Me.btnIzmeniNak = New System.Windows.Forms.Button
        Me.tbGS = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.lblDin = New System.Windows.Forms.Label
        Me.fxUicUpuceno = New FlxMaskBox.FlexMaskEditBox
        Me.fxUicFranko = New FlxMaskBox.FlexMaskEditBox
        Me.cbTLVal = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgUic = New System.Windows.Forms.DataGrid
        Me.btnDodajNak = New System.Windows.Forms.Button
        Me.lblUprava = New System.Windows.Forms.Label
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.tbtlUpucenoDin = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        CType(Me.dgUic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbPrecica)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnValute)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tbPrelaz2)
        Me.GroupBox1.Controls.Add(Me.tbPrelaz1)
        Me.GroupBox1.Controls.Add(Me.btnBrisiNak)
        Me.GroupBox1.Controls.Add(Me.btnIzmeniNak)
        Me.GroupBox1.Controls.Add(Me.tbGS)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.GroupBox13)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dgUic)
        Me.GroupBox1.Controls.Add(Me.btnDodajNak)
        Me.GroupBox1.Controls.Add(Me.lblUprava)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(24, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(976, 592)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ UIC uprave na prevoznom putu ]"
        '
        'cbPrecica
        '
        Me.cbPrecica.Location = New System.Drawing.Point(16, 183)
        Me.cbPrecica.Name = "cbPrecica"
        Me.cbPrecica.Size = New System.Drawing.Size(256, 24)
        Me.cbPrecica.TabIndex = 113
        Me.cbPrecica.Text = "Precica - samo sifre granicnih prelaza"
        Me.ToolTip1.SetToolTip(Me.cbPrecica, "Clic - ako unosite samo sifre prelaza a svi iznosi za strane uprave su nule")
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.Location = New System.Drawing.Point(17, 256)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(56, 24)
        Me.Button6.TabIndex = 112
        Me.ToolTip1.SetToolTip(Me.Button6, "Izbor izlaznog prelaza")
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.Location = New System.Drawing.Point(17, 212)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(56, 24)
        Me.Button5.TabIndex = 111
        Me.ToolTip1.SetToolTip(Me.Button5, "Izbor ulaznog prelaza")
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(80, 272)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 13)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 110
        Me.PictureBox4.TabStop = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(128, 136)
        Me.Button4.Name = "Button4"
        Me.Button4.TabIndex = 109
        Me.Button4.Text = "validating"
        Me.Button4.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(112, 64)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 40)
        Me.Button3.TabIndex = 108
        Me.Button3.Text = "load"
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(456, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 23)
        Me.Button2.TabIndex = 107
        Me.Button2.Text = "Button2"
        Me.Button2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(14, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(218, 158)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 105
        Me.PictureBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.GroupBox3.Controls.Add(Me.fxUicPrevoznina)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cbUicVal)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.fxUicNak1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.tbNak1)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.tbNak3)
        Me.GroupBox3.Controls.Add(Me.tbNak2)
        Me.GroupBox3.Controls.Add(Me.fxUicNak3)
        Me.GroupBox3.Controls.Add(Me.fxUicNak2)
        Me.GroupBox3.Controls.Add(Me.fxUicNaknade)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(502, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(464, 175)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " [ Izracunato za upravu ] "
        '
        'fxUicPrevoznina
        '
        Me.fxUicPrevoznina.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxUicPrevoznina.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxUicPrevoznina.Location = New System.Drawing.Point(224, 42)
        Me.fxUicPrevoznina.Mask = "999999d##"
        Me.fxUicPrevoznina.Name = "fxUicPrevoznina"
        Me.fxUicPrevoznina.TabIndex = 1
        Me.fxUicPrevoznina.Text = "0"
        Me.fxUicPrevoznina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(240, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Prevoznina"
        '
        'cbUicVal
        '
        Me.cbUicVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUicVal.Items.AddRange(New Object() {"17 EUR", "02 USD", "85 CHF", "72 RSD"})
        Me.cbUicVal.Location = New System.Drawing.Point(24, 40)
        Me.cbUicVal.Name = "cbUicVal"
        Me.cbUicVal.Size = New System.Drawing.Size(96, 23)
        Me.cbUicVal.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(80, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Valuta"
        '
        'fxUicNak1
        '
        Me.fxUicNak1.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxUicNak1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxUicNak1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxUicNak1.Location = New System.Drawing.Point(224, 84)
        Me.fxUicNak1.Mask = "999999d99"
        Me.fxUicNak1.Name = "fxUicNak1"
        Me.fxUicNak1.TabIndex = 3
        Me.fxUicNak1.Text = "0"
        Me.fxUicNak1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(176, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "Sifra"
        '
        'tbNak1
        '
        Me.tbNak1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak1.Location = New System.Drawing.Point(168, 84)
        Me.tbNak1.MaxLength = 2
        Me.tbNak1.Name = "tbNak1"
        Me.tbNak1.Size = New System.Drawing.Size(48, 21)
        Me.tbNak1.TabIndex = 2
        Me.tbNak1.Text = ""
        Me.tbNak1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(248, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Naknade"
        '
        'tbNak3
        '
        Me.tbNak3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak3.Location = New System.Drawing.Point(168, 141)
        Me.tbNak3.MaxLength = 2
        Me.tbNak3.Name = "tbNak3"
        Me.tbNak3.Size = New System.Drawing.Size(48, 21)
        Me.tbNak3.TabIndex = 6
        Me.tbNak3.Text = ""
        Me.tbNak3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak2
        '
        Me.tbNak2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak2.Location = New System.Drawing.Point(168, 112)
        Me.tbNak2.MaxLength = 2
        Me.tbNak2.Name = "tbNak2"
        Me.tbNak2.Size = New System.Drawing.Size(48, 21)
        Me.tbNak2.TabIndex = 4
        Me.tbNak2.Text = ""
        Me.tbNak2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxUicNak3
        '
        Me.fxUicNak3.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxUicNak3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxUicNak3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxUicNak3.Location = New System.Drawing.Point(224, 141)
        Me.fxUicNak3.Mask = "999999d99"
        Me.fxUicNak3.Name = "fxUicNak3"
        Me.fxUicNak3.TabIndex = 7
        Me.fxUicNak3.Text = "0"
        Me.fxUicNak3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxUicNak2
        '
        Me.fxUicNak2.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxUicNak2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxUicNak2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxUicNak2.Location = New System.Drawing.Point(224, 112)
        Me.fxUicNak2.Mask = "999999d99"
        Me.fxUicNak2.Name = "fxUicNak2"
        Me.fxUicNak2.TabIndex = 5
        Me.fxUicNak2.Text = "0"
        Me.fxUicNak2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxUicNaknade
        '
        Me.fxUicNaknade.Enabled = False
        Me.fxUicNaknade.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxUicNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxUicNaknade.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxUicNaknade.Location = New System.Drawing.Point(336, 141)
        Me.fxUicNaknade.Mask = "999999d99"
        Me.fxUicNaknade.Name = "fxUicNaknade"
        Me.fxUicNaknade.TabIndex = 2
        Me.fxUicNaknade.Text = "0"
        Me.fxUicNaknade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(364, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 19)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Suma"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(432, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 40)
        Me.Button1.TabIndex = 104
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'btnValute
        '
        Me.btnValute.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnValute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnValute.Image = CType(resources.GetObject("btnValute.Image"), System.Drawing.Image)
        Me.btnValute.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnValute.Location = New System.Drawing.Point(176, 536)
        Me.btnValute.Name = "btnValute"
        Me.btnValute.Size = New System.Drawing.Size(62, 48)
        Me.btnValute.TabIndex = 6
        Me.btnValute.Text = "Valuta"
        Me.btnValute.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnValute, "Unos vise valuta za istu upravu")
        Me.btnValute.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(80, 212)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 13)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 102
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(168, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(320, 16)
        Me.Label9.TabIndex = 101
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(440, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Granicni prelaz"
        Me.Label8.Visible = False
        '
        'tbPrelaz2
        '
        Me.tbPrelaz2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrelaz2.Location = New System.Drawing.Point(80, 256)
        Me.tbPrelaz2.MaxLength = 4
        Me.tbPrelaz2.Name = "tbPrelaz2"
        Me.tbPrelaz2.Size = New System.Drawing.Size(72, 24)
        Me.tbPrelaz2.TabIndex = 1
        Me.tbPrelaz2.Text = ""
        Me.tbPrelaz2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPrelaz1
        '
        Me.tbPrelaz1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrelaz1.Location = New System.Drawing.Point(80, 212)
        Me.tbPrelaz1.MaxLength = 4
        Me.tbPrelaz1.Name = "tbPrelaz1"
        Me.tbPrelaz1.Size = New System.Drawing.Size(72, 24)
        Me.tbPrelaz1.TabIndex = 0
        Me.tbPrelaz1.Text = ""
        Me.tbPrelaz1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnBrisiNak
        '
        Me.btnBrisiNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiNak.Image = CType(resources.GetObject("btnBrisiNak.Image"), System.Drawing.Image)
        Me.btnBrisiNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiNak.Location = New System.Drawing.Point(96, 536)
        Me.btnBrisiNak.Name = "btnBrisiNak"
        Me.btnBrisiNak.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiNak.TabIndex = 5
        Me.btnBrisiNak.Text = "Brisi"
        Me.btnBrisiNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnIzmeniNak
        '
        Me.btnIzmeniNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIzmeniNak.Image = CType(resources.GetObject("btnIzmeniNak.Image"), System.Drawing.Image)
        Me.btnIzmeniNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIzmeniNak.Location = New System.Drawing.Point(16, 536)
        Me.btnIzmeniNak.Name = "btnIzmeniNak"
        Me.btnIzmeniNak.Size = New System.Drawing.Size(62, 48)
        Me.btnIzmeniNak.TabIndex = 4
        Me.btnIzmeniNak.Text = "Izmeni"
        Me.btnIzmeniNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbGS
        '
        Me.tbGS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbGS.Location = New System.Drawing.Point(448, 96)
        Me.tbGS.MaxLength = 2
        Me.tbGS.Name = "tbGS"
        Me.tbGS.Size = New System.Drawing.Size(40, 21)
        Me.tbGS.TabIndex = 91
        Me.tbGS.Text = ""
        Me.tbGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbGS.Visible = False
        '
        'Label7
        '
        Me.Label7.Enabled = False
        Me.Label7.Location = New System.Drawing.Point(456, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 16)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "Globalni stav"
        Me.Label7.Visible = False
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Silver
        Me.GroupBox13.Controls.Add(Me.tbtlUpucenoDin)
        Me.GroupBox13.Controls.Add(Me.lblDin)
        Me.GroupBox13.Controls.Add(Me.fxUicUpuceno)
        Me.GroupBox13.Controls.Add(Me.fxUicFranko)
        Me.GroupBox13.Controls.Add(Me.cbTLVal)
        Me.GroupBox13.Controls.Add(Me.Label38)
        Me.GroupBox13.Controls.Add(Me.Label36)
        Me.GroupBox13.Controls.Add(Me.Label37)
        Me.GroupBox13.Location = New System.Drawing.Point(502, 192)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(464, 104)
        Me.GroupBox13.TabIndex = 3
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "[ Zaracunato po CIM - u ]"
        '
        'lblDin
        '
        Me.lblDin.Enabled = False
        Me.lblDin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblDin.Location = New System.Drawing.Point(207, 67)
        Me.lblDin.Name = "lblDin"
        Me.lblDin.Size = New System.Drawing.Size(120, 24)
        Me.lblDin.TabIndex = 47
        Me.lblDin.Text = "Preracunato u dinare"
        Me.lblDin.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblDin.Visible = False
        '
        'fxUicUpuceno
        '
        Me.fxUicUpuceno.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxUicUpuceno.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxUicUpuceno.Location = New System.Drawing.Point(336, 40)
        Me.fxUicUpuceno.Mask = "999999d99"
        Me.fxUicUpuceno.Name = "fxUicUpuceno"
        Me.fxUicUpuceno.TabIndex = 2
        Me.fxUicUpuceno.Text = "0"
        Me.fxUicUpuceno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxUicFranko
        '
        Me.fxUicFranko.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxUicFranko.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxUicFranko.Location = New System.Drawing.Point(224, 40)
        Me.fxUicFranko.Mask = "999999d99"
        Me.fxUicFranko.Name = "fxUicFranko"
        Me.fxUicFranko.TabIndex = 1
        Me.fxUicFranko.Text = "0"
        Me.fxUicFranko.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbTLVal
        '
        Me.cbTLVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTLVal.Items.AddRange(New Object() {"17 EUR", "02 USD", "85 CHF", "72 RSD"})
        Me.cbTLVal.Location = New System.Drawing.Point(24, 38)
        Me.cbTLVal.Name = "cbTLVal"
        Me.cbTLVal.Size = New System.Drawing.Size(96, 23)
        Me.cbTLVal.TabIndex = 0
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(360, 25)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(56, 19)
        Me.Label38.TabIndex = 46
        Me.Label38.Text = "Upuceno"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(80, 20)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(40, 16)
        Me.Label36.TabIndex = 43
        Me.Label36.Text = "Valuta"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(255, 25)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(48, 19)
        Me.Label37.TabIndex = 45
        Me.Label37.Text = "Franko"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(168, 217)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 16)
        Me.Label1.TabIndex = 42
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgUic
        '
        Me.dgUic.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dgUic.CaptionText = "Uprave na prevoznom putu"
        Me.dgUic.DataMember = ""
        Me.dgUic.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUic.Location = New System.Drawing.Point(14, 304)
        Me.dgUic.Name = "dgUic"
        Me.dgUic.Size = New System.Drawing.Size(952, 224)
        Me.dgUic.TabIndex = 4
        '
        'btnDodajNak
        '
        Me.btnDodajNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodajNak.Image = CType(resources.GetObject("btnDodajNak.Image"), System.Drawing.Image)
        Me.btnDodajNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodajNak.Location = New System.Drawing.Point(14, 536)
        Me.btnDodajNak.Name = "btnDodajNak"
        Me.btnDodajNak.Size = New System.Drawing.Size(62, 48)
        Me.btnDodajNak.TabIndex = 5
        Me.btnDodajNak.Text = "Dodaj"
        Me.btnDodajNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblUprava
        '
        Me.lblUprava.Enabled = False
        Me.lblUprava.Font = New System.Drawing.Font("Microsoft Sans Serif", 100.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblUprava.ForeColor = System.Drawing.Color.Silver
        Me.lblUprava.Location = New System.Drawing.Point(240, 24)
        Me.lblUprava.Name = "lblUprava"
        Me.lblUprava.Size = New System.Drawing.Size(216, 158)
        Me.lblUprava.TabIndex = 106
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(912, 614)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 72)
        Me.btnOtkazi.TabIndex = 2
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(808, 614)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(90, 72)
        Me.btnPrihvati.TabIndex = 1
        Me.btnPrihvati.Text = "Prihvati"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'tbtlUpucenoDin
        '
        Me.tbtlUpucenoDin.Location = New System.Drawing.Point(336, 71)
        Me.tbtlUpucenoDin.Name = "tbtlUpucenoDin"
        Me.tbtlUpucenoDin.TabIndex = 49
        Me.tbtlUpucenoDin.Text = "0"
        Me.tbtlUpucenoDin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbtlUpucenoDin.Visible = False
        '
        '_Uic
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1028, 696)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "_Uic"
        Me.Text = "Uic uprave"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        CType(Me.dgUic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub _Uic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button3_Click(Me, Nothing)

    End Sub
    Private Sub FormatUicGrid()
        If dsUic Is Nothing Then
            dgUic.DataSource = dtUic
        Else
            dgUic.DataSource = dsUic.Tables(0)

            'dvNaknada.RowFilter = "Action LIKE 'U'"
            'dgNaknade.DataSource = dvNaknada
            'dgNaknade.Refresh()
        End If
    End Sub

    Private Sub btnDodajNak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajNak.Click
        Me.btnValute.Visible = False
        Me.btnBrisiNak.Visible = True
        Me.btnDodajNak.Visible = False
        Me.btnIzmeniNak.Visible = True

        Dim dtRow As DataRow = dtUic.NewRow

        dtUic.Rows.Add(New Object() {lblUprava.Text, tbPrelaz1.Text, tbPrelaz2.Text, _
                                     Microsoft.VisualBasic.Mid(cbUicVal.Text.ToString, 1, 3), fxUicPrevoznina.Text, tbNak1.Text, fxUicNak1.Text, tbNak2.Text, fxUicNak2.Text, tbNak3.Text, fxUicNak3.Text, tbGS.Text, "0", 0, _
                                     Microsoft.VisualBasic.Mid(cbTLVal.Text.ToString, 1, 3), fxUicFranko.Text, fxUicUpuceno.Text, "I", _rbrValuta})

        dgUic.Refresh()

        'dvUic = dtUic.DefaultView
        'dvUic.Sort = "rbr"

        dtUic.DefaultView.Sort = "rbr ASC"
        dgUic.Refresh()
    End Sub

    Private Sub btnBrisiNak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiNak.Click
        If MasterAction = "New" Then
            Try
                CType(dgUic.DataSource, DataTable).Rows(dgUic.CurrentCell.RowNumber).Delete()
            Catch ex As Exception
                MsgBox(ex, MsgBoxStyle.Critical)
            Finally
                'brisanje svih kontrola

                'Me.cbPrelaz1.Focus()
            End Try
        Else
            Try
                Dim rowuic As Data.DataRow

                rowuic = CType(dgUic.DataSource, DataTable).Rows(dgUic.CurrentCell.RowNumber)
                rowuic = dtUic.Rows(dgUic.CurrentCell.RowNumber)
                rowuic("Action") = "D"

                dvUic.RowFilter = "Action LIKE 'U'"
                dgUic.DataSource = dvUic
                dgUic.Refresh()

            Catch ex As Exception
            Finally
                dgUic.Refresh()

            End Try
        End If
    End Sub
    Private Sub btnIzmeniNak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzmeniNak.Click

        Dim row As Data.DataRow

        row = CType(dgUic.DataSource, DataTable).Rows(dgUic.CurrentCell.RowNumber)

        row("Uprava") = Me.lblUprava.Text
        row("Ulaz") = tbPrelaz1.Text
        row("Izlaz") = tbPrelaz2.Text
        row("Valuta") = Microsoft.VisualBasic.Mid(cbUicVal.Text.ToString, 1, 3)
        row("Prevoznina") = fxUicPrevoznina.Text
        row("Nak1") = Me.tbNak1.Text
        row("Iznos1") = fxUicNak1.Text
        row("Nak2") = Me.tbNak2.Text
        row("Iznos2") = fxUicNak2.Text
        row("Nak3") = Me.tbNak3.Text
        row("Iznos3") = fxUicNak3.Text
        row("SifraGS") = Me.tbGS.Text

        row("ValPredujam") = "0"
        row("Predujam") = 0

        row("TLVal") = Microsoft.VisualBasic.Mid(cbTLVal.Text.ToString, 1, 3)
        row("TLFranko") = fxUicFranko.Text
        row("TLUpuceno") = fxUicUpuceno.Text

        row("TLUpucenoDin") = Me.tbtlUpucenoDin.Text

        If MasterAction = "New" Then
            row("Action") = "I"
        Else
            row("Action") = "U"
        End If

        dgUic.Refresh()

        'If IzborSaobracaja = "2" Then
        '    _ZajednickiPrelaz = tbPrelaz2.Text
        'Else
        '    _ZajednickiPrelaz = tbPrelaz1.Text
        'End If

        _ZajednickiPrelaz = tbPrelaz2.Text

        Me.lblUprava.Text = ""
        tbPrelaz1.Text = ""
        tbPrelaz2.Text = ""
        fxUicPrevoznina.Text = ""
        tbNak1.Text = ""
        fxUicNak1.Text = ""
        tbNak2.Text = ""
        fxUicNak2.Text = ""
        tbNak3.Text = ""
        fxUicNak3.Text = ""
        tbGS.Text = ""
        ''cbTLVal.SelectedIndex = -1
        fxUicFranko.Text = ""
        fxUicUpuceno.Text = ""
        Label1.Text = ""
        Label9.Text = ""
        lblDin.Visible = False
        Me.tbtlUpucenoDin.Visible = False

        '----------------------------------- ide na sledeci red i popunjava polja --------------------------------
        Dim BrojReda As Int32 = 0
        BrojReda = dgUic.CurrentCell.RowNumber

        BrojReda = BrojReda + 1

        If BrojReda <= (dtUic.Rows.Count - 1) Then
            dgUic.CurrentCell = New DataGridCell(BrojReda, 0) ' ide na sledeci red !

            Dim currRow As DataRow
            currRow = CType(dgUic.DataSource, DataTable).Rows(dgUic.CurrentCell.RowNumber)

            lblUprava.Text = currRow(0, DataRowVersion.Current).ToString()
            tbPrelaz1.Text = currRow(1, DataRowVersion.Current).ToString()
            tbPrelaz2.Text = currRow(2, DataRowVersion.Current).ToString()
            cbUicVal.Text = currRow(3, DataRowVersion.Current).ToString()
            fxUicPrevoznina.Text = currRow(4, DataRowVersion.Current).ToString()
            tbNak1.Text = currRow(5, DataRowVersion.Current).ToString()
            fxUicNak1.Text = currRow(6, DataRowVersion.Current).ToString()
            tbNak2.Text = currRow(7, DataRowVersion.Current).ToString()
            fxUicNak2.Text = currRow(8, DataRowVersion.Current).ToString()
            tbNak3.Text = currRow(9, DataRowVersion.Current).ToString()
            fxUicNak3.Text = currRow(10, DataRowVersion.Current).ToString()
            tbGS.Text = currRow(11, DataRowVersion.Current).ToString()
            cbTLVal.Text = currRow(14, DataRowVersion.Current).ToString()
            fxUicFranko.Text = currRow(15, DataRowVersion.Current).ToString()
            fxUicUpuceno.Text = currRow(16, DataRowVersion.Current).ToString()

            dgUic_Click_2(Me, Nothing)

        Else
            Me.btnPrihvati.Focus()
        End If


    End Sub

    Private Sub dgUic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUic.Click
        Me.btnDodajNak.Visible = False
        Me.btnIzmeniNak.Visible = True
        Me.btnBrisiNak.Visible = True
        Me.btnValute.Visible = True

        Dim currRow As DataRow
        currRow = CType(dgUic.DataSource, DataTable).Rows(dgUic.CurrentCell.RowNumber)

        lblUprava.Text = currRow(0, DataRowVersion.Current).ToString()
        tbPrelaz1.Text = currRow(1, DataRowVersion.Current).ToString()
        tbPrelaz2.Text = currRow(2, DataRowVersion.Current).ToString()
        cbUicVal.Text = currRow(3, DataRowVersion.Current).ToString()
        fxUicPrevoznina.Text = currRow(4, DataRowVersion.Current).ToString()
        tbNak1.Text = currRow(5, DataRowVersion.Current).ToString()
        fxUicNak1.Text = currRow(6, DataRowVersion.Current).ToString()
        tbNak2.Text = currRow(7, DataRowVersion.Current).ToString()
        fxUicNak2.Text = currRow(8, DataRowVersion.Current).ToString()
        tbNak3.Text = currRow(9, DataRowVersion.Current).ToString()
        fxUicNak3.Text = currRow(10, DataRowVersion.Current).ToString()
        tbGS.Text = currRow(11, DataRowVersion.Current).ToString()
        cbTLVal.Text = currRow(14, DataRowVersion.Current).ToString()
        fxUicFranko.Text = currRow(15, DataRowVersion.Current).ToString()
        fxUicUpuceno.Text = currRow(16, DataRowVersion.Current).ToString()
        'din

        tbtlUpucenoDin.Text = currRow(19, DataRowVersion.Current).ToString()

        lblDin.Visible = False
        Me.tbtlUpucenoDin.Visible = False
        If CDec(tbtlUpucenoDin.Text) > 0 Then
            If IzborSaobracaja = "2" Then
                lblDin.Visible = True
                Me.tbtlUpucenoDin.Visible = True
            End If
        End If

        _rbrValuta = currRow(18, DataRowVersion.Current) + 0.1

        Dim BrojReda As Int32
        BrojReda = dgUic.CurrentCell.RowNumber
        t_UicUprava = lblUprava.Text

        Label1.Text = ""
        Label9.Text = ""

        If BrojReda = 0 Then
            If IzborSaobracaja = "2" Then
                tbPrelaz1.Enabled = False
            Else
                tbPrelaz2.Enabled = False
            End If

        ElseIf BrojReda > 0 And BrojReda < dtUic.Rows.Count Then
            ''tbPrelaz1.Enabled = True

            If IzborSaobracaja = "2" Then
                tbPrelaz1.Enabled = True
            Else
                tbPrelaz2.Enabled = True
            End If

        ElseIf BrojReda = dtUic.Rows.Count Then
            ''tbPrelaz1.Enabled = True
            If IzborSaobracaja = "2" Then
                tbPrelaz1.Enabled = True
            Else
                tbPrelaz2.Enabled = True
            End If

        End If
        If IzborSaobracaja = "2" Then
            tbPrelaz2.Focus()
        Else
            tbPrelaz1.Focus()
        End If

        ''tbPrelaz2.Focus()

    End Sub
    Private Sub dgUic_Click_2(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUic.Click
        Me.btnDodajNak.Visible = False
        Me.btnIzmeniNak.Visible = True
        Me.btnBrisiNak.Visible = True
        Me.btnValute.Visible = True

        Dim currRow As DataRow
        currRow = CType(dgUic.DataSource, DataTable).Rows(dgUic.CurrentCell.RowNumber)

        lblUprava.Text = currRow(0, DataRowVersion.Current).ToString()
        tbPrelaz1.Text = _ZajednickiPrelaz
        tbPrelaz2.Text = currRow(2, DataRowVersion.Current).ToString()
        cbUicVal.Text = currRow(3, DataRowVersion.Current).ToString()
        fxUicPrevoznina.Text = currRow(4, DataRowVersion.Current).ToString()
        tbNak1.Text = currRow(5, DataRowVersion.Current).ToString()
        fxUicNak1.Text = currRow(6, DataRowVersion.Current).ToString()
        tbNak2.Text = currRow(7, DataRowVersion.Current).ToString()
        fxUicNak2.Text = currRow(8, DataRowVersion.Current).ToString()
        tbNak3.Text = currRow(9, DataRowVersion.Current).ToString()
        fxUicNak3.Text = currRow(10, DataRowVersion.Current).ToString()
        tbGS.Text = currRow(11, DataRowVersion.Current).ToString()
        cbTLVal.Text = currRow(14, DataRowVersion.Current).ToString()
        fxUicFranko.Text = currRow(15, DataRowVersion.Current).ToString()
        fxUicUpuceno.Text = currRow(16, DataRowVersion.Current).ToString()

        _rbrValuta = currRow(18, DataRowVersion.Current) + 0.1

        Dim BrojReda As Int32
        BrojReda = dgUic.CurrentCell.RowNumber
        t_UicUprava = lblUprava.Text

        Label1.Text = ""
        Label9.Text = ""

        If BrojReda = 0 Then
            tbPrelaz1.Enabled = False
        ElseIf BrojReda > 0 And BrojReda < dtUic.Rows.Count Then
            tbPrelaz1.Enabled = True
        ElseIf BrojReda = dtUic.Rows.Count Then
            tbPrelaz1.Enabled = True
            tbPrelaz2.Enabled = False ' True
        End If

        ''If BrojReda + 1 = dtUic.Rows.Count Then
        ''    cbUicVal.Focus()
        ''Else
        ''    tbPrelaz2.Focus()
        ''End If

        tbPrelaz2.Focus()



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValute.Click
        Me.btnIzmeniNak.Visible = False
        Me.btnBrisiNak.Visible = False
        Me.btnValute.Visible = False
        Me.btnDodajNak.Visible = True

        cbUicVal.Focus()
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        dtUic.Clear()
        m_UicPrevozniPut = ""
        Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Get the DefaultViewManager of a DataTable.
        Dim myDataView As DataView
        myDataView = dtUic.DefaultView
        ' By default, the first column sorted ascending.
        myDataView.Sort = "rbr"
    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        mPrikazKalkulacije = "D"
        _OpenForm = "Uic"
        Close()

        If IzborSaobracaja = "2" Then
            Izjava()
        Else
            Izjava_Ex()
        End If

        If IzborSaobracaja = "2" Then
            Dim InfoPanel As New Info_Uvoz ' Info
            InfoPanel.ShowDialog()
        Else
            Dim InfoPanel As New Info_Izvoz ' Info
            InfoPanel.ShowDialog()
        End If
        
    End Sub

    Private Sub tbPrelaz1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrelaz1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrelaz2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrelaz2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbUicVal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbUicVal.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxUicPrevoznina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxUicPrevoznina.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbNak1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNak1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbNak2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNak2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbNak3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNak3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxUicNak1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxUicNak1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxUicNak2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxUicNak2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxUicNak3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxUicNak3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbTLVal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbTLVal.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxUicFranko_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxUicFranko.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub fxUicUpuceno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxUicUpuceno.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbNak1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNak1.Leave
        If Me.tbNak1.Text = "" Then
            cbTLVal.Focus()
        End If
    End Sub

    Private Sub tbNak2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNak2.Leave
        If Me.tbNak2.Text = "" Then
            cbTLVal.Focus()
        End If
    End Sub

    Private Sub tbNak3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNak3.Leave
        If Me.tbNak3.Text = "" Then
            cbTLVal.Focus()
        End If
    End Sub

    Private Sub tbPrelaz2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbPrelaz2.Validating

        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""

        If Len(tbPrelaz2.Text) = 0 Then
            If IzborSaobracaja = "3" Then
                Dim BrojReda As Int32 = 0
                BrojReda = dgUic.CurrentCell.RowNumber
                If BrojReda = (dtUic.Rows.Count - 1) Then
                    tbPrelaz2.Enabled = False
                    ErrorProvider1.SetError(tbPrelaz2, "")
                    If Me.cbPrecica.Checked = True Then
                        Me.btnIzmeniNak.Focus()
                    Else
                        cbUicVal.Focus()
                    End If
                End If
                'ErrorProvider1.SetError(tbPrelaz2, "")
                'cbUicVal.Focus()
            End If
        ElseIf Len(tbPrelaz2.Text) = 1 Or Len(tbPrelaz2.Text) = 2 Then
            ErrorProvider1.SetError(tbPrelaz2, "Neispravna sifra prelaza!")
            tbPrelaz2.Focus()
        ElseIf Len(tbPrelaz2.Text) = 3 Or Len(tbPrelaz2.Text) = 4 Then
            If Len(tbPrelaz2.Text) = 3 Then
                tbPrelaz2.Text = "0" & tbPrelaz2.Text
            End If

            Util.sNadjiNaziv("UicPrelaz", t_UicUprava, tbPrelaz2.Text, "", 1, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                ErrorProvider1.SetError(tbPrelaz2, "Nepostojeci prelaz!")
                tbPrelaz2.Focus()
            Else
                Label9.Text = xNaziv
                ErrorProvider1.SetError(tbPrelaz2, "")
                If Me.cbPrecica.Checked = True Then
                    Me.btnIzmeniNak.Focus()
                Else
                    cbUicVal.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cbTLVal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTLVal.Leave
        If cbTLVal.Text = Nothing Then
            cbTLVal.Focus()
        End If
    End Sub

    Private Sub cbUicVal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUicVal.Leave
        If cbUicVal.Text = Nothing Then
            cbUicVal.Focus()
        End If
    End Sub

    Private Sub tbPrelaz1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbPrelaz1.Validating
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""
        Dim BrojReda As Int32

        If Len(tbPrelaz1.Text) < 3 Then

            BrojReda = dgUic.CurrentCell.RowNumber
            If BrojReda > 1 Then
                ErrorProvider1.SetError(tbPrelaz1, "Neispravna sifra prelaza!")
            Else
                ErrorProvider1.SetError(tbPrelaz1, "")
            End If

        Else
            If Len(tbPrelaz1.Text) = 3 Then
                tbPrelaz1.Text = "0" & tbPrelaz1.Text
            End If

            Util.sNadjiNaziv("UicPrelaz", t_UicUprava, tbPrelaz1.Text, "", 1, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                ErrorProvider1.SetError(tbStanicaOtp, "Nepostojeca stanica!")
                tbStanicaOtp.Focus()
            Else
                Label1.Text = xNaziv
                Me.tbPrelaz1.BackColor = System.Drawing.Color.White
                ErrorProvider1.SetError(tbPrelaz1, "")
            End If
        End If
    End Sub

    Private Sub btnIzmeniNak_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIzmeniNak.GotFocus
        Me.btnIzmeniNak.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnIzmeniNak_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIzmeniNak.Leave
        Me.btnIzmeniNak.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnPrihvati_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrihvati.GotFocus
        Me.btnPrihvati.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnPrihvati_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrihvati.Leave
        Me.btnPrihvati.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dtUic.Clear()

        If dtUic.Rows.Count = 0 Then
            Dim dtRow As DataRow = dtUic.NewRow
            Dim ii As Int16 = 0

            If IzborSaobracaja = "2" Then
                For ii = 1 To (Len(m_UicPrevozniPut) / 2)
                    dtUic.Rows.Add(New Object() {Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2), "", "", "", 0, "", 0, "", 0, "", 0, "", "0", 0, "", 0, 0, "I", ii})
                Next
            Else
                '''m_UicPrevozniPut = Microsoft.VisualBasic.Right(m_UicPrevozniPut, Len(m_UicPrevozniPut) - 2)
                Dim aString As String = ""
                For ii = (Len(m_UicPrevozniPut) / 2) To 1 Step -1
                    aString = aString & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2)
                Next

                m_UicPrevozniPut = aString

                For ii = 1 To (Len(m_UicPrevozniPut) / 2)
                    dtUic.Rows.Add(New Object() {Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2), "", "", "", 0, "", 0, "", 0, "", 0, "", "0", 0, "", 0, 0, "I", ii})
                Next

            End If
            tmp_Prelaz1 = "Upd"
        End If

        dgUic.CurrentCell = New DataGridCell(0, 0)
        Dim currRow As DataRow
        currRow = CType(dgUic.DataSource, DataTable).Rows(dgUic.CurrentCell.RowNumber)
        dgUic_Click(Me, Nothing)

        tbPrelaz1.Enabled = False
        dvUic.Sort = "rbr"
        dgUic.Refresh()
        cbUicVal.SelectedIndex = 0
        cbTLVal.SelectedIndex = 0
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.btnDodajNak.Visible = False
        FormatUicGrid()

        If dtUic.Rows.Count = 0 Then
            Dim dtRow As DataRow = dtUic.NewRow
            Dim ii As Int16 = 0

            If IzborSaobracaja = "2" Then
                For ii = 1 To (Len(m_UicPrevozniPut) / 2)
                    dtUic.Rows.Add(New Object() {Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2), "", "", "", 0, "", 0, "", 0, "", 0, "", "0", 0, "", 0, 0, "I", ii, 0})
                Next
            Else
                ''OKRENUTI SMER U IZVOZU!!
                Dim aString As String = ""
                For ii = (Len(m_UicPrevozniPut) / 2) To 1 Step -1
                    aString = aString & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2)
                Next

                m_UicPrevozniPut = aString

                For ii = 1 To (Len(m_UicPrevozniPut) / 2)
                    dtUic.Rows.Add(New Object() {Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ii - 1, 2), "", "", "", 0, "", 0, "", 0, "", 0, "", "0", 0, "", 0, 0, "I", ii, 0})
                Next

            End If
            tmp_Prelaz1 = "Upd"
        End If

        dgUic.CurrentCell = New DataGridCell(0, 0)
        Dim currRow As DataRow
        currRow = CType(dgUic.DataSource, DataTable).Rows(dgUic.CurrentCell.RowNumber)
        dgUic_Click(Me, Nothing)

        dvUic.Sort = "rbr"
        dgUic.Refresh()
        cbUicVal.SelectedIndex = 0
        cbTLVal.SelectedIndex = 0

        If IzborSaobracaja = "2" Then
            tbPrelaz1.Enabled = False
        Else
            Dim IzvozPrelaz As String = ""
            If IzborSaobracaja = "3" Then
                IzvozPrelaz = mStanica2
            End If

            Select Case IzvozPrelaz
                Case "23499"
                    tbPrelaz1.Text = "0711"
                Case "22899"
                    tbPrelaz1.Text = "0660"
                Case "21099"
                    tbPrelaz1.Text = "0661"
                Case "12498"
                    tbPrelaz1.Text = "0620"
                Case "11028"
                    tbPrelaz1.Text = "0676"
                Case "15723"
                    tbPrelaz1.Text = "0671"
                Case "16319"
                    tbPrelaz1.Text = "0591"
                Case "16517"
                    tbPrelaz1.Text = "0501"
            End Select
            tbPrelaz1.Enabled = False
            tbPrelaz2.Enabled = True
            tbPrelaz2.Focus()
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""

        If Len(tbPrelaz2.Text) = 0 Or Len(tbPrelaz2.Text) = 1 Or Len(tbPrelaz2.Text) = 2 Then
            ErrorProvider1.SetError(tbPrelaz2, "Neispravna sifra prelaza!")
            tbPrelaz2.Focus()
        ElseIf Len(tbPrelaz2.Text) = 3 Or Len(tbPrelaz2.Text) = 4 Then
            If Len(tbPrelaz2.Text) = 3 Then
                tbPrelaz2.Text = "0" & tbPrelaz2.Text
            End If

            Util.sNadjiNaziv("UicPrelaz", t_UicUprava, tbPrelaz2.Text, "", 1, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                ErrorProvider1.SetError(tbPrelaz2, "Nepostojeci prelaz!")
                tbPrelaz2.Focus()
            Else
                Label9.Text = xNaziv
                ErrorProvider1.SetError(tbPrelaz2, "")
                cbUicVal.Focus()
            End If

        End If

    End Sub

    Private Sub tbPrelaz2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPrelaz2.GotFocus
        If IzborSaobracaja = "3" Then
            Dim BrojReda As Int32 = 0
            BrojReda = dgUic.CurrentCell.RowNumber
            If BrojReda = (dtUic.Rows.Count - 1) Then
                tbPrelaz2.Enabled = False
                cbUicVal.Focus()
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        mUicPrelaz = lblUprava.Text
        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC GRANICNI PRELAZ"
        upit = "UIC_GR"
        helpUic.ShowDialog()
        Me.tbPrelaz2.Text = mIzlaz1
        Label9.Text = mIzlaz2
        cbUicVal.Focus()
    End Sub

    Private Sub cbPrecica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPrecica.Click
        Me.tbPrelaz2.Focus()

    End Sub

    Private Sub fxUicUpuceno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fxUicUpuceno.Validating
        Dim mOutKurs As Decimal = 0
        mOutKurs = 0
        Dim strRetVal As String = ""
        Dim tmp_SumaUpDin As Decimal = 0
        If CDec(fxUicUpuceno.Text) > 0 Then
            If IzborSaobracaja = "2" Then
                lblDin.Visible = True
                Me.tbtlUpucenoDin.Visible = True
                NadjiKurs(Microsoft.VisualBasic.Mid(cbTLVal.Text.ToString, 1, 2), "1", mPrDatum, mOutKurs, strRetVal)
                tmp_SumaUpDin = CDec(Me.fxUicUpuceno.Text) * mOutKurs
                bZaokruziNaDeseteNavise(tmp_SumaUpDin)
                Me.tbtlUpucenoDin.Text = CDec(tmp_SumaUpDin)

            End If

        End If

    End Sub

    Private Sub cbUicVal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUicVal.GotFocus
        Me.cbUicVal.Items.Add(lblUprava.Text)
    End Sub

    Private Sub cbTLVal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTLVal.GotFocus
        Me.cbTLVal.Items.Add(lblUprava.Text)
    End Sub
End Class
