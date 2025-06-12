Imports System.Data.SqlClient
Public Class uic
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbNHM As System.Windows.Forms.TextBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents tbUpravaUic As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbPrelaz1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbPrelaz2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbValutaUic As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbPrevUic As System.Windows.Forms.TextBox
    Friend WithEvents tbNakUic As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbNakUicIb As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnIzmeniUic As System.Windows.Forms.Button
    Friend WithEvents btnDodajUic As System.Windows.Forms.Button
    Friend WithEvents btnBrisiUic As System.Windows.Forms.Button
    Friend WithEvents btnIzmeniNak As System.Windows.Forms.Button
    Friend WithEvents btnDodajNak As System.Windows.Forms.Button
    Friend WithEvents btnBrisiNak As System.Windows.Forms.Button
    Friend WithEvents dgUic As System.Windows.Forms.DataGrid
    Friend WithEvents dgUicNak As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(uic))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.tbPrevUic = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbValutaUic = New System.Windows.Forms.ComboBox
        Me.cbPrelaz2 = New System.Windows.Forms.ComboBox
        Me.cbPrelaz1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnIzmeniUic = New System.Windows.Forms.Button
        Me.tbUpravaUic = New System.Windows.Forms.TextBox
        Me.dgUic = New System.Windows.Forms.DataGrid
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnDodajUic = New System.Windows.Forms.Button
        Me.btnBrisiUic = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.tbNakUicIb = New System.Windows.Forms.TextBox
        Me.btnIzmeniNak = New System.Windows.Forms.Button
        Me.btnDodajNak = New System.Windows.Forms.Button
        Me.btnBrisiNak = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgUicNak = New System.Windows.Forms.DataGrid
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbNHM = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbNakUic = New System.Windows.Forms.TextBox
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgUic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgUicNak, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbPrevUic)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbValutaUic)
        Me.GroupBox1.Controls.Add(Me.cbPrelaz2)
        Me.GroupBox1.Controls.Add(Me.cbPrelaz1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnIzmeniUic)
        Me.GroupBox1.Controls.Add(Me.tbUpravaUic)
        Me.GroupBox1.Controls.Add(Me.dgUic)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btnDodajUic)
        Me.GroupBox1.Controls.Add(Me.btnBrisiUic)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 449)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ Prevoznina ]"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.ComboBox1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.DataGrid1)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 126)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(432, 64)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " [ Blagajna ]"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(313, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Upuceno"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(84, 30)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(80, 23)
        Me.ComboBox1.TabIndex = 51
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(84, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 23)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Valuta"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(256, 300)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 48)
        Me.Button2.TabIndex = 49
        Me.Button2.Text = "Izmeni"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(104, 300)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(62, 48)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Dodaj"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(176, 300)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(62, 48)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Brisi"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionText = "Naknade za sporedne usluge"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 136)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(336, 160)
        Me.DataGrid1.TabIndex = 45
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(192, 32)
        Me.TextBox3.MaxLength = 6
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(104, 21)
        Me.TextBox3.TabIndex = 1
        Me.TextBox3.Text = "1234567890,00"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(192, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 23)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Franko"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(312, 32)
        Me.TextBox4.MaxLength = 5
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(104, 21)
        Me.TextBox4.TabIndex = 0
        Me.TextBox4.Text = ""
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPrevUic
        '
        Me.tbPrevUic.Location = New System.Drawing.Point(96, 101)
        Me.tbPrevUic.Name = "tbPrevUic"
        Me.tbPrevUic.Size = New System.Drawing.Size(104, 21)
        Me.tbPrevUic.TabIndex = 47
        Me.tbPrevUic.Text = "1234567890,00"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Prevoznina"
        '
        'cbValutaUic
        '
        Me.cbValutaUic.Location = New System.Drawing.Point(208, 100)
        Me.cbValutaUic.Name = "cbValutaUic"
        Me.cbValutaUic.Size = New System.Drawing.Size(64, 23)
        Me.cbValutaUic.TabIndex = 45
        '
        'cbPrelaz2
        '
        Me.cbPrelaz2.Location = New System.Drawing.Point(96, 73)
        Me.cbPrelaz2.Name = "cbPrelaz2"
        Me.cbPrelaz2.Size = New System.Drawing.Size(176, 23)
        Me.cbPrelaz2.TabIndex = 44
        '
        'cbPrelaz1
        '
        Me.cbPrelaz1.Location = New System.Drawing.Point(96, 46)
        Me.cbPrelaz1.Name = "cbPrelaz1"
        Me.cbPrelaz1.Size = New System.Drawing.Size(176, 23)
        Me.cbPrelaz1.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Stanica1"
        '
        'btnIzmeniUic
        '
        Me.btnIzmeniUic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIzmeniUic.Image = CType(resources.GetObject("btnIzmeniUic.Image"), System.Drawing.Image)
        Me.btnIzmeniUic.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIzmeniUic.Location = New System.Drawing.Point(278, 392)
        Me.btnIzmeniUic.Name = "btnIzmeniUic"
        Me.btnIzmeniUic.Size = New System.Drawing.Size(62, 48)
        Me.btnIzmeniUic.TabIndex = 41
        Me.btnIzmeniUic.Text = "Izmeni"
        Me.btnIzmeniUic.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIzmeniUic.Visible = False
        '
        'tbUpravaUic
        '
        Me.tbUpravaUic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUpravaUic.Location = New System.Drawing.Point(96, 21)
        Me.tbUpravaUic.MaxLength = 2
        Me.tbUpravaUic.Name = "tbUpravaUic"
        Me.tbUpravaUic.Size = New System.Drawing.Size(48, 21)
        Me.tbUpravaUic.TabIndex = 37
        Me.tbUpravaUic.Text = ""
        Me.tbUpravaUic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgUic
        '
        Me.dgUic.CaptionText = "Uprave na prevoznom putu"
        Me.dgUic.DataMember = ""
        Me.dgUic.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUic.Location = New System.Drawing.Point(8, 200)
        Me.dgUic.Name = "dgUic"
        Me.dgUic.Size = New System.Drawing.Size(440, 184)
        Me.dgUic.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 23)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Stanica2"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 23)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Uprava"
        '
        'btnDodajUic
        '
        Me.btnDodajUic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodajUic.Image = CType(resources.GetObject("btnDodajUic.Image"), System.Drawing.Image)
        Me.btnDodajUic.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodajUic.Location = New System.Drawing.Point(197, 392)
        Me.btnDodajUic.Name = "btnDodajUic"
        Me.btnDodajUic.Size = New System.Drawing.Size(64, 48)
        Me.btnDodajUic.TabIndex = 2
        Me.btnDodajUic.Text = "Dodaj"
        Me.btnDodajUic.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnBrisiUic
        '
        Me.btnBrisiUic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiUic.Image = CType(resources.GetObject("btnBrisiUic.Image"), System.Drawing.Image)
        Me.btnBrisiUic.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiUic.Location = New System.Drawing.Point(208, 392)
        Me.btnBrisiUic.Name = "btnBrisiUic"
        Me.btnBrisiUic.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiUic.TabIndex = 3
        Me.btnBrisiUic.Text = "Brisi"
        Me.btnBrisiUic.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbNakUicIb)
        Me.GroupBox2.Controls.Add(Me.btnIzmeniNak)
        Me.GroupBox2.Controls.Add(Me.btnDodajNak)
        Me.GroupBox2.Controls.Add(Me.btnBrisiNak)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dgUicNak)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.tbNHM)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.tbNakUic)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(472, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 320)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ Naknada ]"
        '
        'tbNakUicIb
        '
        Me.tbNakUicIb.Location = New System.Drawing.Point(157, 20)
        Me.tbNakUicIb.MaxLength = 2
        Me.tbNakUicIb.Name = "tbNakUicIb"
        Me.tbNakUicIb.Size = New System.Drawing.Size(51, 21)
        Me.tbNakUicIb.TabIndex = 50
        Me.tbNakUicIb.Text = ""
        Me.tbNakUicIb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnIzmeniNak
        '
        Me.btnIzmeniNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIzmeniNak.Image = CType(resources.GetObject("btnIzmeniNak.Image"), System.Drawing.Image)
        Me.btnIzmeniNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIzmeniNak.Location = New System.Drawing.Point(206, 263)
        Me.btnIzmeniNak.Name = "btnIzmeniNak"
        Me.btnIzmeniNak.Size = New System.Drawing.Size(62, 48)
        Me.btnIzmeniNak.TabIndex = 49
        Me.btnIzmeniNak.Text = "Izmeni"
        Me.btnIzmeniNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIzmeniNak.Visible = False
        '
        'btnDodajNak
        '
        Me.btnDodajNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodajNak.Image = CType(resources.GetObject("btnDodajNak.Image"), System.Drawing.Image)
        Me.btnDodajNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDodajNak.Location = New System.Drawing.Point(128, 263)
        Me.btnDodajNak.Name = "btnDodajNak"
        Me.btnDodajNak.Size = New System.Drawing.Size(62, 48)
        Me.btnDodajNak.TabIndex = 3
        Me.btnDodajNak.Text = "Dodaj"
        Me.btnDodajNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnBrisiNak
        '
        Me.btnBrisiNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnBrisiNak.Image = CType(resources.GetObject("btnBrisiNak.Image"), System.Drawing.Image)
        Me.btnBrisiNak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrisiNak.Location = New System.Drawing.Point(136, 263)
        Me.btnBrisiNak.Name = "btnBrisiNak"
        Me.btnBrisiNak.Size = New System.Drawing.Size(62, 48)
        Me.btnBrisiNak.TabIndex = 4
        Me.btnBrisiNak.Text = "Brisi"
        Me.btnBrisiNak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(17, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 19)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Iznos"
        '
        'dgUicNak
        '
        Me.dgUicNak.CaptionText = "Naknade za sporedne usluge"
        Me.dgUicNak.DataMember = ""
        Me.dgUicNak.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUicNak.Location = New System.Drawing.Point(8, 72)
        Me.dgUicNak.Name = "dgUicNak"
        Me.dgUicNak.Size = New System.Drawing.Size(296, 184)
        Me.dgUicNak.TabIndex = 45
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(400, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 23)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "NHM/UTI*"
        '
        'tbNHM
        '
        Me.tbNHM.Location = New System.Drawing.Point(96, 45)
        Me.tbNHM.MaxLength = 6
        Me.tbNHM.Name = "tbNHM"
        Me.tbNHM.Size = New System.Drawing.Size(112, 21)
        Me.tbNHM.TabIndex = 1
        Me.tbNHM.Text = ""
        Me.tbNHM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(17, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 23)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Sifra"
        '
        'tbNakUic
        '
        Me.tbNakUic.Location = New System.Drawing.Point(97, 20)
        Me.tbNakUic.MaxLength = 2
        Me.tbNakUic.Name = "tbNakUic"
        Me.tbNakUic.Size = New System.Drawing.Size(55, 21)
        Me.tbNakUic.TabIndex = 0
        Me.tbNakUic.Text = ""
        Me.tbNakUic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(590, 479)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(90, 72)
        Me.btnPrihvati.TabIndex = 3
        Me.btnPrihvati.Text = "Prihvati"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(694, 479)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 72)
        Me.btnOtkazi.TabIndex = 4
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(672, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(105, 70)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'uic
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "uic"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ": Unos podataka o stranim upravama :"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgUic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgUicNak, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim dsUic As DataSet
    Dim dsUicNak As DataSet
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim GridNaknade As New naknade
        GridNaknade.Show()
    End Sub
    Private Sub uic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatUicNakGrid()
        FormatUicGrid()
    End Sub
    Private Sub FormatUicGrid()
        If dsUic Is Nothing Then
            dgUic.DataSource = dtUic
        Else
            dgUic.DataSource = dsUic.Tables(0)
        End If
    End Sub
    Private Sub FormatUicNakGrid()
        If dsUicNak Is Nothing Then
            dgUicNak.DataSource = dtUicNak
        Else
            dgUicNak.DataSource = dsUicNak.Tables(0)
        End If
    End Sub

    Private Sub btnDodajUic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajUic.Click
        'Dim mIBK As String
        'Dim mVlasnik As String
        'Dim mSerija As String
        'Dim mVrsta As String
        'Dim mOsovine As Int16
        'Dim mTara As Int32
        'Dim mGranTov As Decimal
        'Dim mStitna As String
        'Dim mTipKola As String = "0" 'nakon unosa robe
        'Dim mPrevoznina As Decimal = "0" 'nakon kalkulacije
        'Dim mNaknada As Decimal = "0" 'nakon kalkulacije

        'mIBK = Microsoft.VisualBasic.Mid(fxIBK.Text, 1, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 4, 2) & Microsoft.VisualBasic.Mid(fxIBK.Text, 7, 4) & Microsoft.VisualBasic.Mid(fxIBK.Text, 12, 3) & Microsoft.VisualBasic.Mid(fxIBK.Text, 16, 1)
        'mVlasnik = tbVlasnik.Text
        'mSerija = tbSerija.Text
        'mVrsta = tbVrsta.Text
        'mOsovine = tbOsovine.Text
        'mTara = tbTara.Text
        'mGranTov = Me.fxGranTov.Text
        'If Me.chbStitnaKola.Checked = True Then
        '    mStitna = "D"
        'Else
        '    mStitna = "N"
        'End If

        ''naknada za zeleznicka kola
        'If mICF = "D" Then
        '    If DbVeza.State = ConnectionState.Closed Then
        '        DbVeza.Open()
        '    End If

        '    Dim sql_text As String = "SELECT Iznos1 " & _
        '                             "FROM dbo.ZsNaknade " & _
        '                             "WHERE (SifraNaknade = '90') AND (IvicniBroj = '00') AND (SifraVS = 4) "

        '    Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        '    Dim rdrIcf As SqlClient.SqlDataReader

        '    rdrIcf = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        '    Do While rdrIcf.Read()
        '        mNaknada = rdrIcf.GetDecimal(0)
        '        tbKolaNaknada.Text = mNaknada
        '    Loop
        '    rdrIcf.Close()
        '    DbVeza.Close()
        'End If

        'Try
        '    Dim dtRow() As DataRow = dtKola.Select("IndBrojKola = '" & mIBK & "'")
        '    If dtRow.Length > 0 Then
        '        StatusBar1.Text = "Kola: " & mIBK & " - su vec upisana."
        '        fxIBK.Focus()
        '        fxIBK.SelectAll()
        '        Exit Try
        '    Else

        '        dtKola.NewRow()
        '        dtKola.Rows.Add(New Object() {mIBK, mUprava, mVlasnik, mSerija, mVrsta, mOsovine, mTara, mGranTov, mStitna, mTipKola, mPrevoznina, mNaknada, mICF})
        '    End If
        '    dgKola.Refresh()

        '    fxIBK.Clear()
        '    tbTara.Clear()
        '    Me.chbStitnaKola.Checked = False
        '    Me.fxGranTov.Clear()

        '    tbMasa.Focus()

        'Catch ex As Exception

        'End Try


        ''Dim dtRow As DataRow = dtKola.NewRow
        ''dtKola.Rows.Add(New Object() {mIBK, mUprava, mVlasnik, mSerija, mVrsta, mOsovine, mTara, mGranTov, mStitna, mTipKola, mPrevoznina, mNaknada, mICF})

    End Sub

    Private Sub btnDodajRobu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodajNak.Click
        'Dim SifraRobe As String
        'Dim MasaRobe As Int32
        'Dim Tr As String
        'Dim TrRid As String
        'Dim TipUti As String

        'SifraRobe = tbNHM.Text
        'MasaRobe = tbMasa.Text
        'Tr = tbRazred.Text
        'TrRid = tbRazredRid.Text
        'TipUti = Microsoft.VisualBasic.Left(cbTipUti.SelectedText.ToString, 6)

        'Dim dtRow As DataRow = dtNhm.NewRow
        'dtNhm.Rows.Add(New Object() {SifraRobe, MasaRobe, Tr, TrRid, TipUti})

        'dgRoba.Refresh()
        'tbNHM.Clear()
        'tbMasa.Clear()
        'tbRazred.Clear()
        'tbRazredRid.Clear()
        'tbMasa.Focus()
    End Sub

    Private Sub btnBrisiRobu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiNak.Click
        'If dtNhm.Rows.Count > 0 Then
        '    Dim currRow As DataRow
        '    CType(dgRoba.DataSource, DataTable).Rows(dgRoba.CurrentCell.RowNumber).Delete()
        '    tbMasa.Focus()
        'End If
    End Sub

    Private Sub dgRoba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgUicNak.Click
        'Me.btnDodajRobu.Visible = False
        'Me.btnIzmeniRobu.Visible = True

        'Dim currRow As DataRow
        'currRow = CType(dgRoba.DataSource, DataTable).Rows(dgRoba.CurrentCell.RowNumber)

        'tbNHM.Text = currRow(0, DataRowVersion.Current).ToString()
        'tbMasa.Text = currRow(1, DataRowVersion.Current).ToString()
        'tbRazred.Text = currRow(2, DataRowVersion.Current).ToString()
        'tbRazredRid.Text = currRow(3, DataRowVersion.Current).ToString()
        'Me.cbTipUti.Text() = currRow(4, DataRowVersion.Current).ToString()

    End Sub
    Private Sub dgKola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgUic.Click
        'Me.btnDodajUic.Visible = False
        'Me.btnIzmeniUic.Visible = True

        'Dim currRow As DataRow
        'currRow = CType(dgKola.DataSource, DataTable).Rows(dgKola.CurrentCell.RowNumber)

        'mIBK = currRow(0, DataRowVersion.Current).ToString()
        'mIBK = Microsoft.VisualBasic.Mid(mIBK, 1, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 3, 2) & " " & Microsoft.VisualBasic.Mid(mIBK, 5, 4) & " " & Microsoft.VisualBasic.Mid(mIBK, 9, 3) & " " & Microsoft.VisualBasic.Mid(mIBK, 12, 1)

    End Sub

    Private Sub btnBrisiuic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrisiUic.Click
        'If dtKola.Rows.Count > 0 Then
        '    Dim currRow As DataRow
        '    CType(dgKola.DataSource, DataTable).Rows(dgKola.CurrentCell.RowNumber).Delete()
        '    fxIBK.Focus()
        'End If

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        'mMasaRobe = dtNhm.Rows(0).Item(1)
        'Close()

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub btnIzmeniRobu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzmeniNak.Click
        Me.btnDodajNak.Visible = True
        Me.btnDodajNak.Visible = False
    End Sub

    Private Sub btnIzmeniuic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzmeniUic.Click
        Me.btnDodajUic.Visible = True
        Me.btnIzmeniUic.Visible = False

    End Sub

    Private Sub StatusBar1_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs)

    End Sub
End Class
