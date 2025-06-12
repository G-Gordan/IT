Imports System.Data.SqlClient

Public Class UnosTrz

    Inherits System.Windows.Forms.Form
    Public mBrojPokusaja As Int16 = 1
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
    Friend WithEvents tbBrojOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbUpravaOtp As System.Windows.Forms.TextBox
    Friend WithEvents btnUpravaOtp As System.Windows.Forms.Button
    Friend WithEvents btnStanicaOtp As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStanicaPr As System.Windows.Forms.Button
    Friend WithEvents tbBrojPr As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaPr As System.Windows.Forms.TextBox
    Friend WithEvents tbUpravaPr As System.Windows.Forms.TextBox
    Friend WithEvents btnUpravaPr As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbZsPrevozniPut As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbUlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbIzlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents btnUnosRobe As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzjava As System.Windows.Forms.Button
    Friend WithEvents tbFrankoPrelaz As System.Windows.Forms.TextBox
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents ToolBar2 As System.Windows.Forms.ToolBar
    Friend WithEvents cbNajava As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbKolaNajava As System.Windows.Forms.ComboBox
    Friend WithEvents cbSmer1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbSmer2 As System.Windows.Forms.ComboBox
    Friend WithEvents tbKm2 As System.Windows.Forms.TextBox
    Friend WithEvents tbKm1 As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbKolauNajavi As System.Windows.Forms.TextBox
    Friend WithEvents tbKolaRealizovano As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents rb3 As System.Windows.Forms.RadioButton
    Friend WithEvents DatumOtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnUpis As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbTL As System.Windows.Forms.TextBox
    Friend WithEvents tbPrevoznina As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbValuta As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents dgFinalNak As System.Windows.Forms.DataGrid
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tbNaknade As System.Windows.Forms.TextBox
    Friend WithEvents btnUnosNaknade As System.Windows.Forms.Button
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents dgError As System.Windows.Forms.DataGrid
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fxFranko As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents cbFrankoPrevoznina As System.Windows.Forms.CheckBox
    Friend WithEvents cbIncoterms As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents fxVrednostRobe As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cbVrednost As System.Windows.Forms.ComboBox
    Friend WithEvents fxIsporuka As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxPouzece As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents cbIsporuka As System.Windows.Forms.ComboBox
    Friend WithEvents cbPouzece As System.Windows.Forms.ComboBox
    Friend WithEvents tbPlatilacFRR As System.Windows.Forms.TextBox
    Friend WithEvents tbPosiljalac As System.Windows.Forms.TextBox
    Friend WithEvents tbPlatilacNFR As System.Windows.Forms.TextBox
    Friend WithEvents tbPrimalac As System.Windows.Forms.TextBox
    Friend WithEvents comboIncoterms As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents tbKolauVozu As System.Windows.Forms.TextBox
    Friend WithEvents gbKolauVozu As System.Windows.Forms.GroupBox
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents fxPrevoznina As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxNaknade As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxTL As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblMakis As System.Windows.Forms.Label
    Friend WithEvents tbMakis As System.Windows.Forms.TextBox
    Friend WithEvents btnNadjiNajavu As System.Windows.Forms.Button
    Friend WithEvents lbl_smasa As System.Windows.Forms.Label
    Friend WithEvents lbl_nhm As System.Windows.Forms.Label
    Friend WithEvents lbl_tara As System.Windows.Forms.Label
    Friend WithEvents lbl_ibk As System.Windows.Forms.Label
    Friend WithEvents L_SMasa As System.Windows.Forms.Label
    Friend WithEvents L_NHM As System.Windows.Forms.Label
    Friend WithEvents L_Tara As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents l_Kola As System.Windows.Forms.Label
    Friend WithEvents gb_Info As System.Windows.Forms.GroupBox
    Friend WithEvents lblBlagajna As System.Windows.Forms.Label
    Friend WithEvents fxBlagajna As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxRazlika As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents lbl_PkolaProdos As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lblEvraPoKolima As System.Windows.Forms.Label
    Friend WithEvents btnSastavvoza As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UnosTrz))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnStanicaOtp = New System.Windows.Forms.Button
        Me.tbBrojOtp = New System.Windows.Forms.TextBox
        Me.tbStanicaOtp = New System.Windows.Forms.TextBox
        Me.tbUpravaOtp = New System.Windows.Forms.TextBox
        Me.btnUpravaOtp = New System.Windows.Forms.Button
        Me.DatumOtp = New System.Windows.Forms.DateTimePicker
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnStanicaPr = New System.Windows.Forms.Button
        Me.tbBrojPr = New System.Windows.Forms.TextBox
        Me.tbStanicaPr = New System.Windows.Forms.TextBox
        Me.tbUpravaPr = New System.Windows.Forms.TextBox
        Me.btnUpravaPr = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.tbKm2 = New System.Windows.Forms.TextBox
        Me.tbKm1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cbZsPrevozniPut = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnUnosRobe = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.tbMakis = New System.Windows.Forms.TextBox
        Me.lblMakis = New System.Windows.Forms.Label
        Me.tbIzlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbUlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.Button9 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.fxFranko = New FlxMaskBox.FlexMaskEditBox
        Me.comboIncoterms = New System.Windows.Forms.ComboBox
        Me.cbIncoterms = New System.Windows.Forms.CheckBox
        Me.cbFrankoPrevoznina = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnIzjava = New System.Windows.Forms.Button
        Me.tbFrankoPrelaz = New System.Windows.Forms.TextBox
        Me.tbPrevoznina = New System.Windows.Forms.TextBox
        Me.tbNaknade = New System.Windows.Forms.TextBox
        Me.tbTL = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.cbSmer1 = New System.Windows.Forms.ComboBox
        Me.ToolBar2 = New System.Windows.Forms.ToolBar
        Me.cbNajava = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbKolaNajava = New System.Windows.Forms.ComboBox
        Me.cbSmer2 = New System.Windows.Forms.ComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbKolauNajavi = New System.Windows.Forms.TextBox
        Me.tbKolaRealizovano = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rb3 = New System.Windows.Forms.RadioButton
        Me.rb1 = New System.Windows.Forms.RadioButton
        Me.rb2 = New System.Windows.Forms.RadioButton
        Me.btnUpis = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.fxRazlika = New FlxMaskBox.FlexMaskEditBox
        Me.fxBlagajna = New FlxMaskBox.FlexMaskEditBox
        Me.lblBlagajna = New System.Windows.Forms.Label
        Me.fxTL = New FlxMaskBox.FlexMaskEditBox
        Me.fxNaknade = New FlxMaskBox.FlexMaskEditBox
        Me.fxPrevoznina = New FlxMaskBox.FlexMaskEditBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.dgFinalNak = New System.Windows.Forms.DataGrid
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbValuta = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btnSastavvoza = New System.Windows.Forms.Button
        Me.btnUnosNaknade = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.dgError = New System.Windows.Forms.DataGrid
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.btnNadjiNajavu = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.tbPlatilacFRR = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.tbPosiljalac = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.tbPlatilacNFR = New System.Windows.Forms.TextBox
        Me.tbPrimalac = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.cbPouzece = New System.Windows.Forms.ComboBox
        Me.cbIsporuka = New System.Windows.Forms.ComboBox
        Me.fxPouzece = New FlxMaskBox.FlexMaskEditBox
        Me.fxIsporuka = New FlxMaskBox.FlexMaskEditBox
        Me.cbVrednost = New System.Windows.Forms.ComboBox
        Me.fxVrednostRobe = New FlxMaskBox.FlexMaskEditBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.gbKolauVozu = New System.Windows.Forms.GroupBox
        Me.tbKolauVozu = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.gb_Info = New System.Windows.Forms.GroupBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.lbl_smasa = New System.Windows.Forms.Label
        Me.lblEvraPoKolima = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.lbl_PkolaProdos = New System.Windows.Forms.Label
        Me.lbl_nhm = New System.Windows.Forms.Label
        Me.lbl_tara = New System.Windows.Forms.Label
        Me.lbl_ibk = New System.Windows.Forms.Label
        Me.L_SMasa = New System.Windows.Forms.Label
        Me.L_NHM = New System.Windows.Forms.Label
        Me.L_Tara = New System.Windows.Forms.Label
        Me.l_Kola = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgFinalNak, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.gbKolauVozu.SuspendLayout()
        Me.gb_Info.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.btnStanicaOtp)
        Me.GroupBox1.Controls.Add(Me.tbBrojOtp)
        Me.GroupBox1.Controls.Add(Me.tbStanicaOtp)
        Me.GroupBox1.Controls.Add(Me.tbUpravaOtp)
        Me.GroupBox1.Controls.Add(Me.btnUpravaOtp)
        Me.GroupBox1.Controls.Add(Me.DatumOtp)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 193)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ OTPRAVLJANJE ] "
        '
        'Label18
        '
        Me.Label18.Enabled = False
        Me.Label18.Location = New System.Drawing.Point(21, 152)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 23)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "Datum"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Location = New System.Drawing.Point(22, 120)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 23)
        Me.Label19.TabIndex = 49
        Me.Label19.Text = "Broj"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(12, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(192, 15)
        Me.Label12.TabIndex = 37
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(16, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(176, 15)
        Me.Label11.TabIndex = 36
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnStanicaOtp
        '
        Me.btnStanicaOtp.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnStanicaOtp.Location = New System.Drawing.Point(12, 70)
        Me.btnStanicaOtp.Name = "btnStanicaOtp"
        Me.btnStanicaOtp.Size = New System.Drawing.Size(75, 24)
        Me.btnStanicaOtp.TabIndex = 5
        Me.btnStanicaOtp.Text = "Stanica"
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojOtp.Location = New System.Drawing.Point(98, 120)
        Me.tbBrojOtp.MaxLength = 6
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.TabIndex = 2
        Me.tbBrojOtp.Text = ""
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaOtp.Location = New System.Drawing.Point(98, 70)
        Me.tbStanicaOtp.MaxLength = 7
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.TabIndex = 1
        Me.tbStanicaOtp.Text = ""
        '
        'tbUpravaOtp
        '
        Me.tbUpravaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUpravaOtp.Location = New System.Drawing.Point(98, 24)
        Me.tbUpravaOtp.MaxLength = 4
        Me.tbUpravaOtp.Name = "tbUpravaOtp"
        Me.tbUpravaOtp.TabIndex = 0
        Me.tbUpravaOtp.Text = ""
        '
        'btnUpravaOtp
        '
        Me.btnUpravaOtp.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnUpravaOtp.Location = New System.Drawing.Point(12, 24)
        Me.btnUpravaOtp.Name = "btnUpravaOtp"
        Me.btnUpravaOtp.Size = New System.Drawing.Size(75, 24)
        Me.btnUpravaOtp.TabIndex = 4
        Me.btnUpravaOtp.Text = "Operater"
        '
        'DatumOtp
        '
        Me.DatumOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOtp.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOtp.Location = New System.Drawing.Point(98, 157)
        Me.DatumOtp.Name = "DatumOtp"
        Me.DatumOtp.Size = New System.Drawing.Size(100, 22)
        Me.DatumOtp.TabIndex = 3
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.btnStanicaPr)
        Me.GroupBox5.Controls.Add(Me.tbBrojPr)
        Me.GroupBox5.Controls.Add(Me.tbStanicaPr)
        Me.GroupBox5.Controls.Add(Me.tbUpravaPr)
        Me.GroupBox5.Controls.Add(Me.btnUpravaPr)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(234, 192)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(216, 193)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = " [ PRISPECE ] "
        '
        'Label17
        '
        Me.Label17.Enabled = False
        Me.Label17.Location = New System.Drawing.Point(13, 149)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 23)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "Datum izlaza"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label15
        '
        Me.Label15.Enabled = False
        Me.Label15.Location = New System.Drawing.Point(24, 116)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 23)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Broj"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label15.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(95, 154)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(100, 22)
        Me.DateTimePicker2.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(12, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(192, 15)
        Me.Label13.TabIndex = 39
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(16, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(176, 15)
        Me.Label14.TabIndex = 38
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnStanicaPr
        '
        Me.btnStanicaPr.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnStanicaPr.Location = New System.Drawing.Point(11, 70)
        Me.btnStanicaPr.Name = "btnStanicaPr"
        Me.btnStanicaPr.Size = New System.Drawing.Size(75, 24)
        Me.btnStanicaPr.TabIndex = 33
        Me.btnStanicaPr.Text = "Stanica"
        '
        'tbBrojPr
        '
        Me.tbBrojPr.Enabled = False
        Me.tbBrojPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojPr.Location = New System.Drawing.Point(95, 120)
        Me.tbBrojPr.MaxLength = 6
        Me.tbBrojPr.Name = "tbBrojPr"
        Me.tbBrojPr.TabIndex = 2
        Me.tbBrojPr.Text = ""
        Me.tbBrojPr.Visible = False
        '
        'tbStanicaPr
        '
        Me.tbStanicaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaPr.Location = New System.Drawing.Point(95, 70)
        Me.tbStanicaPr.MaxLength = 7
        Me.tbStanicaPr.Name = "tbStanicaPr"
        Me.tbStanicaPr.TabIndex = 1
        Me.tbStanicaPr.Text = ""
        '
        'tbUpravaPr
        '
        Me.tbUpravaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUpravaPr.Location = New System.Drawing.Point(95, 24)
        Me.tbUpravaPr.MaxLength = 4
        Me.tbUpravaPr.Name = "tbUpravaPr"
        Me.tbUpravaPr.TabIndex = 0
        Me.tbUpravaPr.Text = ""
        '
        'btnUpravaPr
        '
        Me.btnUpravaPr.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnUpravaPr.Location = New System.Drawing.Point(11, 24)
        Me.btnUpravaPr.Name = "btnUpravaPr"
        Me.btnUpravaPr.Size = New System.Drawing.Size(75, 24)
        Me.btnUpravaPr.TabIndex = 32
        Me.btnUpravaPr.Text = "Operater"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.tbKm2)
        Me.GroupBox2.Controls.Add(Me.tbKm1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cbZsPrevozniPut)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(456, 99)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 91)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ PREVOZNI PUT ŽS ]"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Location = New System.Drawing.Point(280, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 20)
        Me.Button2.TabIndex = 44
        Me.Button2.Text = "..."
        '
        'tbKm2
        '
        Me.tbKm2.Enabled = False
        Me.tbKm2.Location = New System.Drawing.Point(199, 56)
        Me.tbKm2.Name = "tbKm2"
        Me.tbKm2.Size = New System.Drawing.Size(73, 21)
        Me.tbKm2.TabIndex = 5
        Me.tbKm2.Text = ""
        '
        'tbKm1
        '
        Me.tbKm1.Location = New System.Drawing.Point(104, 56)
        Me.tbKm1.Name = "tbKm1"
        Me.tbKm1.Size = New System.Drawing.Size(73, 21)
        Me.tbKm1.TabIndex = 4
        Me.tbKm1.Text = ""
        '
        'Label10
        '
        Me.Label10.Enabled = False
        Me.Label10.Location = New System.Drawing.Point(22, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 22)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Kilometri"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(280, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 20)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "..."
        '
        'cbZsPrevozniPut
        '
        Me.cbZsPrevozniPut.Enabled = False
        Me.cbZsPrevozniPut.Items.AddRange(New Object() {"Redovan", "Vanredan", "Lomljen redovan", "Lomljen vanredan"})
        Me.cbZsPrevozniPut.Location = New System.Drawing.Point(104, 24)
        Me.cbZsPrevozniPut.Name = "cbZsPrevozniPut"
        Me.cbZsPrevozniPut.Size = New System.Drawing.Size(168, 23)
        Me.cbZsPrevozniPut.TabIndex = 2
        Me.cbZsPrevozniPut.Text = "Redovan"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 23)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Prevozni put"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnUnosRobe
        '
        Me.btnUnosRobe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnosRobe.Image = CType(resources.GetObject("btnUnosRobe.Image"), System.Drawing.Image)
        Me.btnUnosRobe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUnosRobe.Location = New System.Drawing.Point(8, 9)
        Me.btnUnosRobe.Name = "btnUnosRobe"
        Me.btnUnosRobe.Size = New System.Drawing.Size(96, 77)
        Me.btnUnosRobe.TabIndex = 11
        Me.btnUnosRobe.Text = "Unos robe    [ F12 ]"
        Me.btnUnosRobe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.tbMakis)
        Me.GroupBox7.Controls.Add(Me.lblMakis)
        Me.GroupBox7.Controls.Add(Me.tbIzlaznaNalepnica)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.tbUlaznaNalepnica)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(10, 99)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(440, 91)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = " [ TRANZITNE NALEPNICE ]"
        '
        'tbMakis
        '
        Me.tbMakis.BackColor = System.Drawing.Color.Red
        Me.tbMakis.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbMakis.ForeColor = System.Drawing.Color.White
        Me.tbMakis.Location = New System.Drawing.Point(320, 55)
        Me.tbMakis.MaxLength = 5
        Me.tbMakis.Name = "tbMakis"
        Me.tbMakis.TabIndex = 39
        Me.tbMakis.Text = "0"
        Me.tbMakis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbMakis.Visible = False
        '
        'lblMakis
        '
        Me.lblMakis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblMakis.ForeColor = System.Drawing.Color.Red
        Me.lblMakis.Location = New System.Drawing.Point(320, 20)
        Me.lblMakis.Name = "lblMakis"
        Me.lblMakis.Size = New System.Drawing.Size(96, 32)
        Me.lblMakis.TabIndex = 38
        Me.lblMakis.Text = "Beograd Ranzirna"
        Me.lblMakis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMakis.Visible = False
        '
        'tbIzlaznaNalepnica
        '
        Me.tbIzlaznaNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIzlaznaNalepnica.Location = New System.Drawing.Point(184, 55)
        Me.tbIzlaznaNalepnica.MaxLength = 5
        Me.tbIzlaznaNalepnica.Name = "tbIzlaznaNalepnica"
        Me.tbIzlaznaNalepnica.Size = New System.Drawing.Size(112, 22)
        Me.tbIzlaznaNalepnica.TabIndex = 1
        Me.tbIzlaznaNalepnica.Text = "0"
        Me.tbIzlaznaNalepnica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(19, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(157, 23)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Izlazna tranzitna nalepnica"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbUlaznaNalepnica
        '
        Me.tbUlaznaNalepnica.BackColor = System.Drawing.Color.Yellow
        Me.tbUlaznaNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUlaznaNalepnica.Location = New System.Drawing.Point(184, 21)
        Me.tbUlaznaNalepnica.MaxLength = 5
        Me.tbUlaznaNalepnica.Name = "tbUlaznaNalepnica"
        Me.tbUlaznaNalepnica.Size = New System.Drawing.Size(112, 22)
        Me.tbUlaznaNalepnica.TabIndex = 0
        Me.tbUlaznaNalepnica.Text = "0"
        Me.tbUlaznaNalepnica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(19, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 23)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Ulazna tranzitna nalepnica"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem9, Me.MenuItem6, Me.MenuItem12, Me.MenuItem14})
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 0
        Me.MenuItem9.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem10})
        Me.MenuItem9.Text = "Odrzavanje"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 0
        Me.MenuItem10.Text = "Izmena racunskog meseca"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 1
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem7, Me.MenuItem8, Me.MenuItem1, Me.MenuItem2})
        Me.MenuItem6.Text = "Pregled"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 0
        Me.MenuItem7.Text = "K140trz trenutno stanje"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 1
        Me.MenuItem8.Text = "K165trz trenutno stanje"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 2
        Me.MenuItem1.Text = "-"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 3
        Me.MenuItem2.Text = "Obracunske liste za korisnike"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 2
        Me.MenuItem12.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem11})
        Me.MenuItem12.Text = "Pomoc"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 0
        Me.MenuItem11.Text = "Pomoc u radu sa programom"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 3
        Me.MenuItem14.Text = ""
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(216, 90)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(96, 77)
        Me.Button9.TabIndex = 16
        Me.Button9.Text = "  Otkaži"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.fxFranko)
        Me.GroupBox4.Controls.Add(Me.comboIncoterms)
        Me.GroupBox4.Controls.Add(Me.cbIncoterms)
        Me.GroupBox4.Controls.Add(Me.cbFrankoPrevoznina)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.btnIzjava)
        Me.GroupBox4.Controls.Add(Me.tbFrankoPrelaz)
        Me.GroupBox4.Controls.Add(Me.tbPrevoznina)
        Me.GroupBox4.Controls.Add(Me.tbNaknade)
        Me.GroupBox4.Controls.Add(Me.tbTL)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(455, 192)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(321, 193)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = " [ PLACANJE TROSKOVA ]"
        '
        'fxFranko
        '
        Me.fxFranko.Enabled = False
        Me.fxFranko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxFranko.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxFranko.Location = New System.Drawing.Point(92, 59)
        Me.fxFranko.Mask = "99 99"
        Me.fxFranko.Name = "fxFranko"
        Me.fxFranko.Size = New System.Drawing.Size(60, 22)
        Me.fxFranko.TabIndex = 0
        '
        'comboIncoterms
        '
        Me.comboIncoterms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboIncoterms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboIncoterms.Items.AddRange(New Object() {"EXW - sve placa primalac", "FCA - franko organizator prevoza", "CPT - franko do odredista", "CIP - franko osigurano do odredista", "DAF - placa posiljalac do granice", "DDU - placa posiljalac do mesta izdavanja", "DDP - placa posiljalac do mesta izdavanja"})
        Me.comboIncoterms.Location = New System.Drawing.Point(92, 117)
        Me.comboIncoterms.MaxLength = 3
        Me.comboIncoterms.Name = "comboIncoterms"
        Me.comboIncoterms.Size = New System.Drawing.Size(216, 24)
        Me.comboIncoterms.TabIndex = 46
        '
        'cbIncoterms
        '
        Me.cbIncoterms.Location = New System.Drawing.Point(8, 120)
        Me.cbIncoterms.Name = "cbIncoterms"
        Me.cbIncoterms.Size = New System.Drawing.Size(80, 24)
        Me.cbIncoterms.TabIndex = 45
        Me.cbIncoterms.Text = "Incoterms"
        '
        'cbFrankoPrevoznina
        '
        Me.cbFrankoPrevoznina.Location = New System.Drawing.Point(8, 50)
        Me.cbFrankoPrevoznina.Name = "cbFrankoPrevoznina"
        Me.cbFrankoPrevoznina.Size = New System.Drawing.Size(88, 32)
        Me.cbFrankoPrevoznina.TabIndex = 44
        Me.cbFrankoPrevoznina.Text = "Franko prevoznina"
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(90, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 22)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Ukljucujuci"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnIzjava
        '
        Me.btnIzjava.Enabled = False
        Me.btnIzjava.Location = New System.Drawing.Point(248, 24)
        Me.btnIzjava.Name = "btnIzjava"
        Me.btnIzjava.Size = New System.Drawing.Size(60, 24)
        Me.btnIzjava.TabIndex = 34
        Me.btnIzjava.Text = "Do "
        '
        'tbFrankoPrelaz
        '
        Me.tbFrankoPrelaz.Location = New System.Drawing.Point(246, 59)
        Me.tbFrankoPrelaz.MaxLength = 4
        Me.tbFrankoPrelaz.Name = "tbFrankoPrelaz"
        Me.tbFrankoPrelaz.Size = New System.Drawing.Size(60, 21)
        Me.tbFrankoPrelaz.TabIndex = 1
        Me.tbFrankoPrelaz.Text = ""
        '
        'tbPrevoznina
        '
        Me.tbPrevoznina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrevoznina.Location = New System.Drawing.Point(16, 152)
        Me.tbPrevoznina.Name = "tbPrevoznina"
        Me.tbPrevoznina.TabIndex = 34
        Me.tbPrevoznina.Text = "0"
        Me.tbPrevoznina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbPrevoznina.Visible = False
        '
        'tbNaknade
        '
        Me.tbNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNaknade.Location = New System.Drawing.Point(120, 152)
        Me.tbNaknade.Name = "tbNaknade"
        Me.tbNaknade.TabIndex = 58
        Me.tbNaknade.Text = "0"
        Me.tbNaknade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbNaknade.Visible = False
        '
        'tbTL
        '
        Me.tbTL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTL.Location = New System.Drawing.Point(224, 152)
        Me.tbTL.Name = "tbTL"
        Me.tbTL.TabIndex = 35
        Me.tbTL.Text = "0"
        Me.tbTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbTL.Visible = False
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(8, 90)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 77)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Info"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 657)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(982, 23)
        Me.ProgressBar1.TabIndex = 59
        '
        'ToolBar1
        '
        Me.ToolBar1.AutoSize = False
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(1000, 96)
        Me.ToolBar1.TabIndex = 39
        '
        'cbSmer1
        '
        Me.cbSmer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer1.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer1.Location = New System.Drawing.Point(8, 22)
        Me.cbSmer1.Name = "cbSmer1"
        Me.cbSmer1.Size = New System.Drawing.Size(200, 24)
        Me.cbSmer1.TabIndex = 1
        '
        'ToolBar2
        '
        Me.ToolBar2.DropDownArrows = True
        Me.ToolBar2.Location = New System.Drawing.Point(0, 96)
        Me.ToolBar2.Name = "ToolBar2"
        Me.ToolBar2.ShowToolTips = True
        Me.ToolBar2.Size = New System.Drawing.Size(1000, 42)
        Me.ToolBar2.TabIndex = 45
        '
        'cbNajava
        '
        Me.cbNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbNajava.Location = New System.Drawing.Point(8, 21)
        Me.cbNajava.MaxLength = 10
        Me.cbNajava.Name = "cbNajava"
        Me.cbNajava.Size = New System.Drawing.Size(128, 24)
        Me.cbNajava.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(144, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Izbor kola iz najave"
        Me.Label2.Visible = False
        '
        'cbKolaNajava
        '
        Me.cbKolaNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbKolaNajava.Location = New System.Drawing.Point(144, 32)
        Me.cbKolaNajava.MaxLength = 12
        Me.cbKolaNajava.Name = "cbKolaNajava"
        Me.cbKolaNajava.Size = New System.Drawing.Size(48, 24)
        Me.cbKolaNajava.TabIndex = 3
        Me.cbKolaNajava.Visible = False
        '
        'cbSmer2
        '
        Me.cbSmer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer2.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer2.Location = New System.Drawing.Point(8, 60)
        Me.cbSmer2.Name = "cbSmer2"
        Me.cbSmer2.Size = New System.Drawing.Size(200, 24)
        Me.cbSmer2.TabIndex = 2
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(9, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 16)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Najavljeno    Realizovano"
        '
        'tbKolauNajavi
        '
        Me.tbKolauNajavi.Enabled = False
        Me.tbKolauNajavi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKolauNajavi.Location = New System.Drawing.Point(8, 60)
        Me.tbKolauNajavi.MaxLength = 2
        Me.tbKolauNajavi.Name = "tbKolauNajavi"
        Me.tbKolauNajavi.Size = New System.Drawing.Size(56, 23)
        Me.tbKolauNajavi.TabIndex = 51
        Me.tbKolauNajavi.Text = "0"
        Me.tbKolauNajavi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbKolaRealizovano
        '
        Me.tbKolaRealizovano.Enabled = False
        Me.tbKolaRealizovano.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKolaRealizovano.Location = New System.Drawing.Point(73, 60)
        Me.tbKolaRealizovano.MaxLength = 2
        Me.tbKolaRealizovano.Name = "tbKolaRealizovano"
        Me.tbKolaRealizovano.Size = New System.Drawing.Size(61, 23)
        Me.tbKolaRealizovano.TabIndex = 53
        Me.tbKolaRealizovano.Text = "0"
        Me.tbKolaRealizovano.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.GroupBox3.Controls.Add(Me.rb3)
        Me.GroupBox3.Controls.Add(Me.rb1)
        Me.GroupBox3.Controls.Add(Me.rb2)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(221, 88)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " [ Vrsta posiljke ] "
        '
        'rb3
        '
        Me.rb3.Location = New System.Drawing.Point(8, 72)
        Me.rb3.Name = "rb3"
        Me.rb3.Size = New System.Drawing.Size(180, 16)
        Me.rb3.TabIndex = 2
        Me.rb3.Text = "Jedan tovarni list za vise kola"
        Me.rb3.Visible = False
        '
        'rb1
        '
        Me.rb1.Checked = True
        Me.rb1.Location = New System.Drawing.Point(5, 22)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(210, 24)
        Me.rb1.TabIndex = 0
        Me.rb1.TabStop = True
        Me.rb1.Text = "Kola sa pojedinacnim tovarnim listom"
        '
        'rb2
        '
        Me.rb2.Location = New System.Drawing.Point(4, 48)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(212, 24)
        Me.rb2.TabIndex = 1
        Me.rb2.Text = "Više tovarnih listova na istim kolima"
        '
        'btnUpis
        '
        Me.btnUpis.BackColor = System.Drawing.SystemColors.Control
        Me.btnUpis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnUpis.Image = CType(resources.GetObject("btnUpis.Image"), System.Drawing.Image)
        Me.btnUpis.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpis.Location = New System.Drawing.Point(216, 8)
        Me.btnUpis.Name = "btnUpis"
        Me.btnUpis.Size = New System.Drawing.Size(96, 77)
        Me.btnUpis.TabIndex = 15
        Me.btnUpis.Text = "Upis u bazu"
        Me.btnUpis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.fxRazlika)
        Me.Panel1.Controls.Add(Me.fxBlagajna)
        Me.Panel1.Controls.Add(Me.lblBlagajna)
        Me.Panel1.Controls.Add(Me.fxTL)
        Me.Panel1.Controls.Add(Me.fxNaknade)
        Me.Panel1.Controls.Add(Me.fxPrevoznina)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.dgFinalNak)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.tbValuta)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Location = New System.Drawing.Point(784, 103)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(210, 456)
        Me.Panel1.TabIndex = 56
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(205, 128)
        Me.PictureBox1.TabIndex = 76
        Me.PictureBox1.TabStop = False
        '
        'fxRazlika
        '
        Me.fxRazlika.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxRazlika.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxRazlika.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxRazlika.Location = New System.Drawing.Point(96, 422)
        Me.fxRazlika.Mask = "999999d99"
        Me.fxRazlika.Name = "fxRazlika"
        Me.fxRazlika.TabIndex = 82
        Me.fxRazlika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxBlagajna
        '
        Me.fxBlagajna.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxBlagajna.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxBlagajna.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxBlagajna.Location = New System.Drawing.Point(96, 391)
        Me.fxBlagajna.Mask = "999999d99"
        Me.fxBlagajna.Name = "fxBlagajna"
        Me.fxBlagajna.TabIndex = 81
        Me.fxBlagajna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBlagajna
        '
        Me.lblBlagajna.Location = New System.Drawing.Point(8, 391)
        Me.lblBlagajna.Name = "lblBlagajna"
        Me.lblBlagajna.Size = New System.Drawing.Size(64, 23)
        Me.lblBlagajna.TabIndex = 80
        Me.lblBlagajna.Text = "Blagajna"
        Me.lblBlagajna.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblBlagajna.Visible = False
        '
        'fxTL
        '
        Me.fxTL.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxTL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxTL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxTL.Location = New System.Drawing.Point(96, 357)
        Me.fxTL.Mask = "999999d99"
        Me.fxTL.Name = "fxTL"
        Me.fxTL.TabIndex = 79
        Me.fxTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxNaknade
        '
        Me.fxNaknade.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxNaknade.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxNaknade.Location = New System.Drawing.Point(96, 225)
        Me.fxNaknade.Mask = "999999d99"
        Me.fxNaknade.Name = "fxNaknade"
        Me.fxNaknade.TabIndex = 78
        Me.fxNaknade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxPrevoznina
        '
        Me.fxPrevoznina.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxPrevoznina.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxPrevoznina.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxPrevoznina.Location = New System.Drawing.Point(96, 197)
        Me.fxPrevoznina.Mask = """999999d99"""
        Me.fxPrevoznina.Name = "fxPrevoznina"
        Me.fxPrevoznina.TabIndex = 77
        Me.fxPrevoznina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(8, 232)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 18)
        Me.Label23.TabIndex = 57
        Me.Label23.Text = "Naknade"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgFinalNak
        '
        Me.dgFinalNak.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.dgFinalNak.BackColor = System.Drawing.Color.DarkGray
        Me.dgFinalNak.CaptionBackColor = System.Drawing.Color.White
        Me.dgFinalNak.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dgFinalNak.CaptionForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.dgFinalNak.CaptionText = "Naknade"
        Me.dgFinalNak.DataMember = ""
        Me.dgFinalNak.ForeColor = System.Drawing.Color.Black
        Me.dgFinalNak.GridLineColor = System.Drawing.Color.Black
        Me.dgFinalNak.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.dgFinalNak.HeaderBackColor = System.Drawing.Color.Silver
        Me.dgFinalNak.HeaderForeColor = System.Drawing.Color.Black
        Me.dgFinalNak.LinkColor = System.Drawing.Color.Navy
        Me.dgFinalNak.Location = New System.Drawing.Point(6, 254)
        Me.dgFinalNak.Name = "dgFinalNak"
        Me.dgFinalNak.ParentRowsBackColor = System.Drawing.Color.White
        Me.dgFinalNak.ParentRowsForeColor = System.Drawing.Color.Black
        Me.dgFinalNak.PreferredColumnWidth = 50
        Me.dgFinalNak.SelectionBackColor = System.Drawing.Color.Navy
        Me.dgFinalNak.SelectionForeColor = System.Drawing.Color.White
        Me.dgFinalNak.Size = New System.Drawing.Size(192, 98)
        Me.dgFinalNak.TabIndex = 56
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 423)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 23)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Razlika"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label7.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 365)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 16)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Ukupno"
        '
        'tbValuta
        '
        Me.tbValuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValuta.Location = New System.Drawing.Point(96, 166)
        Me.tbValuta.MaxLength = 5
        Me.tbValuta.Name = "tbValuta"
        Me.tbValuta.TabIndex = 31
        Me.tbValuta.Text = "Euro"
        Me.tbValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(9, 174)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 23)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Valuta"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(8, 206)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 23)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Prevoznina"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Black
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.Location = New System.Drawing.Point(0, 129)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(205, 32)
        Me.Button6.TabIndex = 75
        Me.Button6.Text = "Kalkulacija"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnSastavvoza)
        Me.GroupBox6.Controls.Add(Me.btnUnosNaknade)
        Me.GroupBox6.Controls.Add(Me.btnUnosRobe)
        Me.GroupBox6.Controls.Add(Me.btnUpis)
        Me.GroupBox6.Controls.Add(Me.Button9)
        Me.GroupBox6.Controls.Add(Me.Button3)
        Me.GroupBox6.Location = New System.Drawing.Point(456, 386)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(320, 173)
        Me.GroupBox6.TabIndex = 57
        Me.GroupBox6.TabStop = False
        '
        'btnSastavvoza
        '
        Me.btnSastavvoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSastavvoza.Image = CType(resources.GetObject("btnSastavvoza.Image"), System.Drawing.Image)
        Me.btnSastavvoza.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSastavvoza.Location = New System.Drawing.Point(110, 90)
        Me.btnSastavvoza.Name = "btnSastavvoza"
        Me.btnSastavvoza.Size = New System.Drawing.Size(98, 77)
        Me.btnSastavvoza.TabIndex = 17
        Me.btnSastavvoza.Text = "Sastav voza     "
        Me.btnSastavvoza.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSastavvoza.Visible = False
        '
        'btnUnosNaknade
        '
        Me.btnUnosNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnosNaknade.Image = CType(resources.GetObject("btnUnosNaknade.Image"), System.Drawing.Image)
        Me.btnUnosNaknade.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUnosNaknade.Location = New System.Drawing.Point(110, 9)
        Me.btnUnosNaknade.Name = "btnUnosNaknade"
        Me.btnUnosNaknade.Size = New System.Drawing.Size(98, 77)
        Me.btnUnosNaknade.TabIndex = 13
        Me.btnUnosNaknade.Text = "Naknade      [ F11 ]"
        Me.btnUnosNaknade.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(192, 24)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(24, 56)
        Me.Button5.TabIndex = 64
        Me.Button5.Text = "Popuni"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Visible = False
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.cbSmer1)
        Me.GroupBox10.Controls.Add(Me.cbSmer2)
        Me.GroupBox10.Controls.Add(Me.Label32)
        Me.GroupBox10.Controls.Add(Me.Label33)
        Me.GroupBox10.Location = New System.Drawing.Point(559, 3)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(216, 88)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "[ Izbor pravca ]"
        '
        'Label32
        '
        Me.Label32.Enabled = False
        Me.Label32.Location = New System.Drawing.Point(139, 39)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(72, 22)
        Me.Label32.TabIndex = 44
        Me.Label32.Text = "Izlazni prelaz"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label33
        '
        Me.Label33.Enabled = False
        Me.Label33.Location = New System.Drawing.Point(138, 10)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 13)
        Me.Label33.TabIndex = 45
        Me.Label33.Text = "Ulazni prelaz"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'dgError
        '
        Me.dgError.BackgroundColor = System.Drawing.Color.White
        Me.dgError.CaptionBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.dgError.CaptionText = ">>> P O R U K E    O    G R E S K A M A <<<"
        Me.dgError.DataMember = ""
        Me.dgError.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.dgError.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgError.Location = New System.Drawing.Point(565, 560)
        Me.dgError.Name = "dgError"
        Me.dgError.PreferredColumnWidth = 185
        Me.dgError.PreferredRowHeight = 10
        Me.dgError.Size = New System.Drawing.Size(428, 144)
        Me.dgError.TabIndex = 66
        Me.dgError.Visible = False
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "D:\.NET\source\Gr_WinRoba\bin\cimv00.hlp"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Button7)
        Me.GroupBox11.Controls.Add(Me.btnNadjiNajavu)
        Me.GroupBox11.Controls.Add(Me.tbKolaRealizovano)
        Me.GroupBox11.Controls.Add(Me.Button4)
        Me.GroupBox11.Controls.Add(Me.cbNajava)
        Me.GroupBox11.Controls.Add(Me.Label6)
        Me.GroupBox11.Controls.Add(Me.cbKolaNajava)
        Me.GroupBox11.Controls.Add(Me.Button5)
        Me.GroupBox11.Controls.Add(Me.Label2)
        Me.GroupBox11.Controls.Add(Me.tbKolauNajavi)
        Me.GroupBox11.Controls.Add(Me.Label5)
        Me.GroupBox11.Location = New System.Drawing.Point(237, 3)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(315, 88)
        Me.GroupBox11.TabIndex = 0
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = " [ NAJAVA ] "
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(152, 16)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(48, 23)
        Me.Button7.TabIndex = 68
        Me.Button7.Text = "Button7"
        Me.Button7.Visible = False
        '
        'btnNadjiNajavu
        '
        Me.btnNadjiNajavu.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnNadjiNajavu.Image = CType(resources.GetObject("btnNadjiNajavu.Image"), System.Drawing.Image)
        Me.btnNadjiNajavu.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNadjiNajavu.Location = New System.Drawing.Point(224, 16)
        Me.btnNadjiNajavu.Name = "btnNadjiNajavu"
        Me.btnNadjiNajavu.Size = New System.Drawing.Size(80, 64)
        Me.btnNadjiNajavu.TabIndex = 67
        Me.btnNadjiNajavu.Text = "Nadji najavu"
        Me.btnNadjiNajavu.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(144, 56)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(24, 23)
        Me.Button4.TabIndex = 66
        Me.Button4.Text = "Button4"
        Me.Button4.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(112, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 16)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Broj"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.GroupBox8.Controls.Add(Me.tbPlatilacFRR)
        Me.GroupBox8.Controls.Add(Me.Label21)
        Me.GroupBox8.Controls.Add(Me.tbPosiljalac)
        Me.GroupBox8.Controls.Add(Me.Label22)
        Me.GroupBox8.Location = New System.Drawing.Point(234, 386)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(216, 88)
        Me.GroupBox8.TabIndex = 69
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "[ Posiljalac ]"
        '
        'tbPlatilacFRR
        '
        Me.tbPlatilacFRR.Location = New System.Drawing.Point(142, 53)
        Me.tbPlatilacFRR.MaxLength = 5
        Me.tbPlatilacFRR.Name = "tbPlatilacFRR"
        Me.tbPlatilacFRR.Size = New System.Drawing.Size(48, 20)
        Me.tbPlatilacFRR.TabIndex = 44
        Me.tbPlatilacFRR.Text = "0"
        Me.tbPlatilacFRR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(9, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 22)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Sifra korisnika"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbPosiljalac
        '
        Me.tbPosiljalac.Location = New System.Drawing.Point(142, 15)
        Me.tbPosiljalac.MaxLength = 5
        Me.tbPosiljalac.Name = "tbPosiljalac"
        Me.tbPosiljalac.Size = New System.Drawing.Size(48, 20)
        Me.tbPosiljalac.TabIndex = 0
        Me.tbPosiljalac.Text = "0"
        Me.tbPosiljalac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(10, 45)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(125, 38)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Sifra korisnika koji placa frankaturni racun"
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.GroupBox12.Controls.Add(Me.tbPlatilacNFR)
        Me.GroupBox12.Controls.Add(Me.tbPrimalac)
        Me.GroupBox12.Controls.Add(Me.Label24)
        Me.GroupBox12.Controls.Add(Me.Label25)
        Me.GroupBox12.Location = New System.Drawing.Point(234, 474)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(216, 85)
        Me.GroupBox12.TabIndex = 70
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "[ Primalac ]"
        '
        'tbPlatilacNFR
        '
        Me.tbPlatilacNFR.Location = New System.Drawing.Point(141, 53)
        Me.tbPlatilacNFR.MaxLength = 5
        Me.tbPlatilacNFR.Name = "tbPlatilacNFR"
        Me.tbPlatilacNFR.Size = New System.Drawing.Size(48, 20)
        Me.tbPlatilacNFR.TabIndex = 44
        Me.tbPlatilacNFR.Text = "0"
        Me.tbPlatilacNFR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPrimalac
        '
        Me.tbPrimalac.Location = New System.Drawing.Point(141, 14)
        Me.tbPrimalac.MaxLength = 5
        Me.tbPrimalac.Name = "tbPrimalac"
        Me.tbPrimalac.Size = New System.Drawing.Size(48, 20)
        Me.tbPrimalac.TabIndex = 0
        Me.tbPrimalac.Text = "0"
        Me.tbPrimalac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(9, 45)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(140, 37)
        Me.Label24.TabIndex = 45
        Me.Label24.Text = "Sifra korisnika koji je platio nefrankirane troskove"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(10, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 22)
        Me.Label25.TabIndex = 43
        Me.Label25.Text = "Sifra primaoca"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.GroupBox13.Controls.Add(Me.cbPouzece)
        Me.GroupBox13.Controls.Add(Me.cbIsporuka)
        Me.GroupBox13.Controls.Add(Me.fxPouzece)
        Me.GroupBox13.Controls.Add(Me.fxIsporuka)
        Me.GroupBox13.Controls.Add(Me.cbVrednost)
        Me.GroupBox13.Controls.Add(Me.fxVrednostRobe)
        Me.GroupBox13.Controls.Add(Me.Label27)
        Me.GroupBox13.Controls.Add(Me.Label26)
        Me.GroupBox13.Controls.Add(Me.Label30)
        Me.GroupBox13.Controls.Add(Me.Label28)
        Me.GroupBox13.Controls.Add(Me.Label31)
        Me.GroupBox13.Controls.Add(Me.Label29)
        Me.GroupBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(10, 385)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(222, 173)
        Me.GroupBox13.TabIndex = 71
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = " [ Roba ] "
        '
        'cbPouzece
        '
        Me.cbPouzece.Items.AddRange(New Object() {"EUR Euro", "DIN Dinar", "CHF Sv.Franak", "USD Am.Dolar"})
        Me.cbPouzece.Location = New System.Drawing.Point(136, 137)
        Me.cbPouzece.Name = "cbPouzece"
        Me.cbPouzece.Size = New System.Drawing.Size(74, 23)
        Me.cbPouzece.TabIndex = 5
        '
        'cbIsporuka
        '
        Me.cbIsporuka.Items.AddRange(New Object() {"EUR Euro", "DIN Dinar", "CHF Sv.Franak", "USD Am.Dolar"})
        Me.cbIsporuka.Location = New System.Drawing.Point(136, 96)
        Me.cbIsporuka.Name = "cbIsporuka"
        Me.cbIsporuka.Size = New System.Drawing.Size(74, 23)
        Me.cbIsporuka.TabIndex = 3
        '
        'fxPouzece
        '
        Me.fxPouzece.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxPouzece.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxPouzece.Location = New System.Drawing.Point(7, 138)
        Me.fxPouzece.Mask = "#########9d##"
        Me.fxPouzece.Name = "fxPouzece"
        Me.fxPouzece.Size = New System.Drawing.Size(128, 21)
        Me.fxPouzece.TabIndex = 4
        Me.fxPouzece.Text = "0"
        Me.fxPouzece.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxIsporuka
        '
        Me.fxIsporuka.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxIsporuka.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxIsporuka.Location = New System.Drawing.Point(7, 97)
        Me.fxIsporuka.Mask = "#########9d##"
        Me.fxIsporuka.Name = "fxIsporuka"
        Me.fxIsporuka.Size = New System.Drawing.Size(128, 21)
        Me.fxIsporuka.TabIndex = 2
        Me.fxIsporuka.Text = "0"
        Me.fxIsporuka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbVrednost
        '
        Me.cbVrednost.Items.AddRange(New Object() {"EUR Euro", "DIN Dinar", "CHF Sv.Franak", "USD Am.Dolar"})
        Me.cbVrednost.Location = New System.Drawing.Point(136, 36)
        Me.cbVrednost.Name = "cbVrednost"
        Me.cbVrednost.Size = New System.Drawing.Size(74, 23)
        Me.cbVrednost.TabIndex = 1
        '
        'fxVrednostRobe
        '
        Me.fxVrednostRobe.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxVrednostRobe.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxVrednostRobe.Location = New System.Drawing.Point(7, 37)
        Me.fxVrednostRobe.Mask = "#########9d##"
        Me.fxVrednostRobe.Name = "fxVrednostRobe"
        Me.fxVrednostRobe.Size = New System.Drawing.Size(128, 21)
        Me.fxVrednostRobe.TabIndex = 0
        Me.fxVrednostRobe.Text = "0"
        Me.fxVrednostRobe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(13, 118)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 23)
        Me.Label27.TabIndex = 52
        Me.Label27.Text = "Pouzece"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(1, 17)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(104, 23)
        Me.Label26.TabIndex = 50
        Me.Label26.Text = "Vrednost robe"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(15, 69)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(120, 24)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "Obezbedjenje uredne isporuke"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(128, 17)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(90, 23)
        Me.Label28.TabIndex = 54
        Me.Label28.Text = "Valuta"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(128, 117)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(90, 23)
        Me.Label31.TabIndex = 56
        Me.Label31.Text = "Valuta"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(128, 75)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(90, 23)
        Me.Label29.TabIndex = 55
        Me.Label29.Text = "Valuta"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbKolauVozu
        '
        Me.gbKolauVozu.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.gbKolauVozu.Controls.Add(Me.tbKolauVozu)
        Me.gbKolauVozu.Controls.Add(Me.Label34)
        Me.gbKolauVozu.Location = New System.Drawing.Point(784, 2)
        Me.gbKolauVozu.Name = "gbKolauVozu"
        Me.gbKolauVozu.Size = New System.Drawing.Size(208, 88)
        Me.gbKolauVozu.TabIndex = 74
        Me.gbKolauVozu.TabStop = False
        Me.gbKolauVozu.Text = "[ Kola u vozu ]"
        '
        'tbKolauVozu
        '
        Me.tbKolauVozu.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.tbKolauVozu.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKolauVozu.Location = New System.Drawing.Point(128, 25)
        Me.tbKolauVozu.MaxLength = 5
        Me.tbKolauVozu.Name = "tbKolauVozu"
        Me.tbKolauVozu.Size = New System.Drawing.Size(56, 38)
        Me.tbKolauVozu.TabIndex = 0
        Me.tbKolauVozu.Text = "1"
        Me.tbKolauVozu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(13, 36)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(112, 24)
        Me.Label34.TabIndex = 43
        Me.Label34.Text = "Redni broj kola po istom ugovoru-tarifi"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'gb_Info
        '
        Me.gb_Info.Controls.Add(Me.PictureBox5)
        Me.gb_Info.Controls.Add(Me.PictureBox4)
        Me.gb_Info.Controls.Add(Me.PictureBox3)
        Me.gb_Info.Controls.Add(Me.lbl_smasa)
        Me.gb_Info.Controls.Add(Me.lblEvraPoKolima)
        Me.gb_Info.Controls.Add(Me.Label35)
        Me.gb_Info.Controls.Add(Me.PictureBox2)
        Me.gb_Info.Controls.Add(Me.lbl_PkolaProdos)
        Me.gb_Info.Controls.Add(Me.lbl_nhm)
        Me.gb_Info.Controls.Add(Me.lbl_tara)
        Me.gb_Info.Controls.Add(Me.lbl_ibk)
        Me.gb_Info.Controls.Add(Me.L_SMasa)
        Me.gb_Info.Controls.Add(Me.L_NHM)
        Me.gb_Info.Controls.Add(Me.L_Tara)
        Me.gb_Info.Controls.Add(Me.l_Kola)
        Me.gb_Info.Location = New System.Drawing.Point(10, 556)
        Me.gb_Info.Name = "gb_Info"
        Me.gb_Info.Size = New System.Drawing.Size(550, 99)
        Me.gb_Info.TabIndex = 82
        Me.gb_Info.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(438, 61)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(31, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 99
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(397, 62)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(31, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 98
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(362, 59)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(31, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 97
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'lbl_smasa
        '
        Me.lbl_smasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_smasa.Location = New System.Drawing.Point(253, 38)
        Me.lbl_smasa.Name = "lbl_smasa"
        Me.lbl_smasa.Size = New System.Drawing.Size(88, 23)
        Me.lbl_smasa.TabIndex = 90
        Me.lbl_smasa.Text = "123456"
        Me.lbl_smasa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvraPoKolima
        '
        Me.lblEvraPoKolima.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvraPoKolima.Location = New System.Drawing.Point(253, 61)
        Me.lblEvraPoKolima.Name = "lblEvraPoKolima"
        Me.lblEvraPoKolima.Size = New System.Drawing.Size(81, 23)
        Me.lblEvraPoKolima.TabIndex = 92
        Me.lblEvraPoKolima.Text = "132456"
        Me.lblEvraPoKolima.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(132, 64)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(125, 23)
        Me.Label35.TabIndex = 91
        Me.Label35.Text = "Naknada po kolima :"
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(5, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(86, 72)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 82
        Me.PictureBox2.TabStop = False
        '
        'lbl_PkolaProdos
        '
        Me.lbl_PkolaProdos.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbl_PkolaProdos.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_PkolaProdos.Location = New System.Drawing.Point(83, 24)
        Me.lbl_PkolaProdos.Name = "lbl_PkolaProdos"
        Me.lbl_PkolaProdos.Size = New System.Drawing.Size(40, 64)
        Me.lbl_PkolaProdos.TabIndex = 83
        Me.lbl_PkolaProdos.Text = "P"
        Me.lbl_PkolaProdos.Visible = False
        '
        'lbl_nhm
        '
        Me.lbl_nhm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nhm.Location = New System.Drawing.Point(422, 17)
        Me.lbl_nhm.Name = "lbl_nhm"
        Me.lbl_nhm.Size = New System.Drawing.Size(82, 23)
        Me.lbl_nhm.TabIndex = 89
        Me.lbl_nhm.Text = "123456"
        Me.lbl_nhm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_tara
        '
        Me.lbl_tara.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tara.Location = New System.Drawing.Point(422, 38)
        Me.lbl_tara.Name = "lbl_tara"
        Me.lbl_tara.Size = New System.Drawing.Size(81, 23)
        Me.lbl_tara.TabIndex = 88
        Me.lbl_tara.Text = "132456"
        Me.lbl_tara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_ibk
        '
        Me.lbl_ibk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ibk.Location = New System.Drawing.Point(253, 17)
        Me.lbl_ibk.Name = "lbl_ibk"
        Me.lbl_ibk.Size = New System.Drawing.Size(104, 23)
        Me.lbl_ibk.TabIndex = 87
        Me.lbl_ibk.Text = "123456789012"
        Me.lbl_ibk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'L_SMasa
        '
        Me.L_SMasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_SMasa.Location = New System.Drawing.Point(131, 40)
        Me.L_SMasa.Name = "L_SMasa"
        Me.L_SMasa.Size = New System.Drawing.Size(129, 23)
        Me.L_SMasa.TabIndex = 86
        Me.L_SMasa.Text = "Stvarna masa [kg]     :"
        '
        'L_NHM
        '
        Me.L_NHM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_NHM.Location = New System.Drawing.Point(360, 16)
        Me.L_NHM.Name = "L_NHM"
        Me.L_NHM.Size = New System.Drawing.Size(64, 23)
        Me.L_NHM.TabIndex = 85
        Me.L_NHM.Text = "NHM       :"
        Me.L_NHM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'L_Tara
        '
        Me.L_Tara.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Tara.Location = New System.Drawing.Point(361, 40)
        Me.L_Tara.Name = "L_Tara"
        Me.L_Tara.Size = New System.Drawing.Size(63, 23)
        Me.L_Tara.TabIndex = 84
        Me.L_Tara.Text = "Tara [kg] :"
        '
        'l_Kola
        '
        Me.l_Kola.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_Kola.Location = New System.Drawing.Point(131, 16)
        Me.l_Kola.Name = "l_Kola"
        Me.l_Kola.Size = New System.Drawing.Size(125, 23)
        Me.l_Kola.TabIndex = 83
        Me.l_Kola.Text = "Individualni broj kola:"
        Me.l_Kola.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UnosTrz
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1000, 669)
        Me.Controls.Add(Me.dgError)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.gbKolauVozu)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolBar2)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.gb_Info)
        Me.KeyPreview = True
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "UnosTrz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgFinalNak, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.gbKolauVozu.ResumeLayout(False)
        Me.gb_Info.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim ds1 As New DataSet("ds1")
    Dim ds2 As New DataSet("ds2")

    Dim dsNajavaNhm As New DataSet("dsNajavaNhm")
    Dim dsNajavaKola As New DataSet("dsNajavaKola")

    Dim mUprava
    Dim mVlasnik
    Dim mSerija
    Dim mOsovine
    Dim mVrsta
    Dim mICF
    Dim mTara
    Dim mNHM
    Dim mNetoMasa
    Dim mBrutoMasa
    Dim err As DataSet
    Dim ctrlKolaIzNajave As String = "No"
    Private Sub Unos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_ibk.Text = mIBK
        lbl_tara.Text = _mTara
        lbl_nhm.Text = _mNHM
        lbl_smasa.Text = _mSMasa
        Me.lblEvraPoKolima.Text = _mNakPoKolima

        '--------------------------------------------------------
        If Microsoft.VisualBasic.Left(_nmNakVER, 1) = "1" Then
            Me.PictureBox3.Visible = True
        Else
            Me.PictureBox3.Visible = False
        End If

        If Microsoft.VisualBasic.Mid(_nmNakVER, 2, 1) = "1" Then
            Me.PictureBox4.Visible = True
        Else
            Me.PictureBox4.Visible = False
        End If

        If Microsoft.VisualBasic.Right(_nmNakVER, 1) = "1" Then
            Me.PictureBox5.Visible = True
        Else
            Me.PictureBox5.Visible = False
        End If
        '--------------------------------------------------------

        tbKolauNajavi.Visible = False
        tbKolaRealizovano.Visible = False

        FormatErrGrid()

        If TipTranzita = "ulaz" Then
            Me.cbSmer1.Enabled = True
            Me.cbSmer2.Enabled = True
            Me.tbUlaznaNalepnica.BackColor = System.Drawing.Color.Yellow
            Me.tbIzlaznaNalepnica.BackColor = System.Drawing.Color.White
            Me.Label17.Text = "Datum ulaza"

            If mVrstaPrevoza <> "P" Then
                If RecordAction = "P" Then
                    btnNadjiNajavu.Visible = True
                Else
                    btnNadjiNajavu.Visible = False
                End If
            Else
                btnNadjiNajavu.Visible = False
                ctrlKolaIzNajave = "Yes"
            End If

            If mTarifa <> "00" Or mBrojUg = "929100" Then
                lblBlagajna.Visible = True
                fxBlagajna.Visible = True
                Label7.Visible = True
                fxRazlika.Visible = True
            Else
                lblBlagajna.Visible = False
                fxBlagajna.Visible = False
                Label7.Visible = False
                fxRazlika.Visible = False

            End If
        Else
            Me.tbIzlaznaNalepnica.Text = mIzEtiketa + 1
            Me.Label17.Text = "Datum izlaza"
            Me.cbSmer1.Enabled = True
            Me.cbSmer2.Text = StanicaUnosa
            Me.cbSmer2.Enabled = False
            Me.tbIzlaznaNalepnica.Enabled = True
            Me.tbUlaznaNalepnica.BackColor = System.Drawing.Color.White
            Me.tbIzlaznaNalepnica.BackColor = System.Drawing.Color.Yellow
        End If

        ' 1. Izmena OKP ili preuzimanje sa granice 

        If MasterAction = "Upd" Or RecordAction = "P" Then

            gb_Info.Visible = True

            Dim ug_mVrstaObracuna As String
            Dim ug_mNazivKomitenta As String
            Dim ug_mPrimalac As String
            Dim mRetVal As String


            'zasto ovo ovde? 11.5.2011
            ''NadjiUgovor(mBrojUg, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, mRetVal)
            ''mVrstaObracuna = ug_mVrstaObracuna

            '---------------------------------------- postavljanje racunskog meseca ------------------------------------------
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            Dim sql_text1 As String = "SELECT MesecUnosa, GodinaUnosa FROM RacMesec " & _
                                      "WHERE (VSaob = '" & IzborSaobracaja & "')"
            Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
            Dim rdrRm As SqlClient.SqlDataReader
            rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrRm.Read()
                mObrMesec = rdrRm.GetString(0)
                mObrGodina = rdrRm.GetString(1)
            Loop
            rdrRm.Close()
            OkpDbVeza.Close()
            '----------------------------------------------------------------------------------------------------------------------------

            Me.tbUpravaOtp.Text = mOtpUprava
            Me.tbStanicaOtp.Text = mOtpStanica
            Me.tbBrojOtp.Text = mOtpBroj
            Me.DatumOtp.Value = mOtpDatum
            Me.tbUpravaPr.Text = mPrUprava
            Me.tbStanicaPr.Text = mPrStanica
            Me.tbUlaznaNalepnica.Text = mUlEtiketa
            Me.tbIzlaznaNalepnica.Text = mIzEtiketa

            '=========
            Dim Nak_Red As DataRow
            mSumaNak = 0
            mSumaNakCo = 0
            mSumaNakRo = 0
            mSumaNakCo82 = 0

            If dtNaknade.Rows.Count > 0 Then
                For Each Nak_Red In dtNaknade.Rows
                    If Nak_Red.Item("Obracun") = "C" Then
                        mSumaNakCo = mSumaNakCo + Nak_Red.Item("Iznos")
                    Else
                        mSumaNakRo = mSumaNakRo + Nak_Red.Item("Iznos")
                    End If
                Next
                mSumaNak = mSumaNakRo + mSumaNakCo82 + mSumaNakCo
            Else
                mSumaNak = 0
            End If
            '=========

            '------- Iznosi --------
            With fxPrevoznina
                .PromptChar = " "
                .Mask = "999999d##"
                .Text = mPrevoznina
            End With
            With fxNaknade
                .PromptChar = " "
                .Mask = "999999d##"
                .Text = mSumaNak
            End With
            With fxTL
                .PromptChar = " "
                .Mask = "999999d##"
                .Text = mSumaIznos
            End With
            fxTL.Text = CDec(fxPrevoznina.Text) + CDec(fxNaknade.Text)
            '----------------------
            dgFinalNak.DataSource = dtNaknade
            dgFinalNak.Show()
            '===============

            Me.cbSmer1.Text = mStanica1
            Me.cbSmer2.Text = mStanica2

            Daljinar()

            Me.GroupBox11.Enabled = True

            'If mVrstaObracuna = "CO" Or mVrstaObracuna = "IC" Then
            '    cbNajava.Enabled = True
            'Else
            '    cbNajava.Enabled = False
            'End If

            'cbNajava.Text = mNajava
            'cbKolaNajava.Enabled = False

            'tbKolauNajavi.Enabled = False
            'tbKolaRealizovano.Enabled = False

            'Button5.Enabled = False

            If mVrstaObracuna = "CO" Or mVrstaObracuna = "IC" Then 'novo 11.5.2011

                cbNajava.Enabled = True
                cbNajava.Text = mNajava
                cbKolaNajava.Enabled = False
                tbKolauNajavi.Enabled = False
                tbKolaRealizovano.Enabled = False
                Button5.Enabled = False

                If mVrstaPrevoza = "P" Then
                    Me.Button6.Focus()
                Else
                    Dim sql_text As String = ""

                    If OkpDbVeza.State = ConnectionState.Closed Then
                        OkpDbVeza.Open()
                    End If

                    sql_text = "SELECT SumaKola, Realizovano " & _
                               "FROM dbo.NajavaVoza " & _
                               "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "')"

                    Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)
                    Dim rdrIzNajave As SqlClient.SqlDataReader
                    Dim _cbStanica1 As String
                    Dim _cbStanica2 As String

                    tbKolauNajavi.Clear()
                    cbKolaNajava.Items.Clear()

                    Try
                        rdrIzNajave = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                        Do While rdrIzNajave.Read()
                            tbKolauNajavi.Text = rdrIzNajave.GetInt16(0)
                            tbKolaRealizovano.Text = rdrIzNajave.GetInt16(1)
                        Loop

                        If mRucnaNajava = "D" Then
                            tbKolauNajavi.Text = mNajavaKola
                            tbKolaRealizovano.Text = mNajavaKolaReal
                        End If

                        rdrIzNajave.Close()
                        OkpDbVeza.Close()
                        cbKolaNajava.Focus()

                    Catch ex As Exception
                        MsgBox(ex)
                    End Try
                    ' -----------------------end
                    If mVrstaObracuna = "CO" Or mVrstaObracuna = "IC" Then
                        Me.cbNajava.Focus()
                    End If

                End If
            Else
                Me.Button6.Focus()
            End If


        Else   ' ------------------------------------- Novi unos u Okp -----------------------------------------
            gb_Info.Visible = True

            If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then ' ugovor centralni obracun
                If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "01" Then
                    gbKolauVozu.Visible = True
                    tbKolauVozu.Text = "1"
                ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "53" Then
                    gbKolauVozu.Visible = True
                    tbKolauVozu.Text = "1"
                ElseIf Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "54" Then
                    gbKolauVozu.Visible = True
                    tbKolauVozu.Text = "1"
                Else
                    gbKolauVozu.Visible = False
                End If

                '-------------------------------- NAJAVA ----------------------------------
                If mVrstaPrevoza <> "P" Then ' grupa ili voz => moze da pozove najavu

                    Me.cbNajava.Enabled = True
                    Me.Label2.Enabled = True
                    Me.cbKolaNajava.Enabled = True

                    Me.tbKolaRealizovano.Visible = True
                    Me.tbKolauNajavi.Visible = True
                    Me.tbKolaRealizovano.Enabled = True
                    Me.tbKolauNajavi.Enabled = True

                    Me.GroupBox3.Enabled() = True
                    Me.GroupBox11.Enabled = True

                    If OkpDbVeza.State = ConnectionState.Closed Then
                        OkpDbVeza.Open()
                    End If

                    Dim sql_text As String = "SELECT dbo.NajavaVoza.KomBrojVoza " & _
                                             "FROM dbo.NajavaKola INNER JOIN " & _
                                             "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                                             "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                                             "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "')  AND (dbo.NajavaVoza.SumaKola - dbo.NajavaVoza.Realizovano > '0' ) " & _
                                             "GROUP BY dbo.NajavaVoza.KomBrojVoza "

                    Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)
                    Dim rdrUg As SqlClient.SqlDataReader
                    Dim combo_linija As String = ""

                    cbNajava.Items.Clear()
                    rdrUg = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                    Do While rdrUg.Read()
                        combo_linija = rdrUg.GetString(0)
                        cbNajava.Items.Add(combo_linija)
                    Loop


                    If cbNajava.Items.Count = 0 Then
                        Me.GroupBox11.Enabled = True
                        Me.cbNajava.Enabled = True
                        Me.cbKolaNajava.Enabled = False
                        Me.Button5.Enabled = False
                        Me.Label2.Enabled = False
                        Me.cbKolaNajava.Enabled = False
                        Me.GroupBox3.Enabled = True
                        Me.cbNajava.Focus()
                    End If

                    rdrUg.Close()
                    OkpDbVeza.Close()
                    Me.cbNajava.Focus()

                Else
                    Me.GroupBox11.Enabled = False
                    Me.cbNajava.Enabled = False
                    Me.Label2.Enabled = False
                    Me.cbKolaNajava.Enabled = False
                    Me.GroupBox3.Enabled = True
                End If
            Else
                Me.GroupBox11.Enabled = False
                Me.cbNajava.Enabled = False
                Me.Label2.Enabled = False
                Me.cbKolaNajava.Enabled = False
                Me.GroupBox3.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnUnosRobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnosRobe.Click
       

        mDatumKalk = DatumOtp.Value
        mOtpDatum = DatumOtp.Text

        mPrUprava = Microsoft.VisualBasic.Mid(tbStanicaPr.Text, 1, 2)
        mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)

        If MasterAction = "Upd" Then

        Else
            If Me.rb1.Checked = True Or Me.rb3.Checked = True Then
                '    dtKola.Clear()
                '    dtNhm.Clear()
                '    dtNaknade.Clear()
                _TL_Kola = 1
            End If
            If Me.rb2.Checked = True Then
                '    dtNhm.Clear()
                '    dtNaknade.Clear()
                _TL_Kola = 2
            End If

        End If

        If bVrstaPosiljke = "K" Then
            Dim GridKola As New kola
            GridKola.Show()
        Else
            Dim GridDencane As New Dencane
            GridDencane.Show()
        End If

    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        AkcijaZaPreuzimanje = "Ne"
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()

        mPrikazKalkulacije = "N"
        mCarKnjiga = " "
        mCarDoc = " "
        mCarStanica = " "
        mCarValuta = " "
        mCarFaktura = 0
        mCarPrPIB = " "
        mCarPrNaziv = " "
        mCarPrSediste = " "
        mCarPrZemlja = " "

        mIBK = ""
        _mTara = ""
        _mNHM = ""
        _mSMasa = 0

        Close()

    End Sub
    Private Sub cbzsprelaz1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub cbNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbKolaNajava_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbKolaNajava.GotFocus
        cbKolaNajava.DroppedDown = True
    End Sub

    Public Sub NadjiTipKola( _
             ByVal inVrsta As Char, _
             ByVal inTovarena As String, _
             ByVal inVlasnistvo As Char, _
             ByRef outTip As Char, _
             ByRef outKolKoef As Decimal)

        'obicna(1) ili specijalna(2)
        'tovarena(TK) ili prazna(PK)
        'zeleznicka(Z),privatna(P), u zakupu(I)

        Dim p1 As Integer
        Dim p2 As Integer
        Dim p3 As Integer
        Dim p123 As Integer

        ' u NajaviKola trazi se O ili S a ne 1 ili 2 kao u zsKolaSerija
        If inVrsta = "O" Then p1 = 1 ' obicna
        If inVrsta = "S" Then p1 = 2 ' specijalna

        If inTovarena = "TK" Then p2 = 1 ' tovarena
        If inTovarena = "PK" Then p2 = 2 ' prazna

        If inVlasnistvo = "Z" Then p3 = 1 ' zeleznicka" Then
        If inVlasnistvo = "P" Then p3 = 2 ' privatna" Then
        If inVlasnistvo = "I" Then p3 = 2 ' iznajmljena ( u zakupu )

        p123 = p1 * 100 + p2 * 10 + p3

        outTip = "1"
        outKolKoef = 1

        Select Case p123
            Case 111
                outKolKoef = 1.0
                outTip = "1"
            Case 211
                outKolKoef = 1.3
                outTip = "2"
            Case 112
                outKolKoef = 0.8
                outTip = "3"
            Case 212
                outKolKoef = 0.7  '*** proveriti!!!
                outTip = "4"
            Case 113
                outKolKoef = 0.8
                outTip = "5"
            Case 213
                outKolKoef = 0.8
                outTip = "6"
            Case 121, 221, 122, 222, 123, 223
                outKolKoef = 0.3
                outTip = "7"
        End Select

    End Sub
    Private Sub LoadNajava()
        Dim en_Kola As IEnumerator
        Dim IBK
        Dim ii1 As Int32

        dtKola.Clear()
        dtNhm.Clear()

        Daljinar()

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        '-------------------------------------------------- popunjava NHM ---------------------------------------------------
        en_Kola = cbKolaNajava.Items.GetEnumerator()
        dsNajavaNhm.Clear()

        Try
            Dim adNajavaNhm As New SqlDataAdapter("SELECT dbo.NajavaKola.BrutoMasa, dbo.NajavaKola.NetoMasa, dbo.NajavaKola.NHM, dbo.NajavaKola.IBK as [IBK] " _
                                         & " FROM dbo.NajavaKola " _
                                         & " WHERE (dbo.NajavaKola.IBK = '" & cbKolaNajava.Text & "') AND (dbo.NajavaKola.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaKola.KomBrojVoza = '" & mNajava & "')", OkpDbVeza)

            'Dim adNajavaNhm As New SqlDataAdapter("SELECT dbo.NajavaIC.NHM, dbo.NajavaIC.UTITip, dbo.NajavaKola.NetoMasa, dbo.NajavaKola.IBK as [IBK] " _
            '                            & " FROM dbo.NajavaKola INNER JOIN dbo.NajavaIC ON dbo.NajavaKola.BrUgovora = dbo.NajavaIC.BrUgovora AND dbo.NajavaKola.KomBrojVoza = dbo.NajavaIC.KomBrVoza AND dbo.NajavaKola.KolaStavka = dbo.NajavaIC.KolaStavka " _
            '                            & " WHERE (dbo.NajavaKola.IBK = '" & cbKolaNajava.Text & "') AND (dbo.NajavaKola.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaKola.KomBrojVoza = '" & mNajava & "')", OkpDbVeza)

            ii1 = adNajavaNhm.Fill(dsNajavaNhm)

            If dsNajavaNhm.Tables(0).Rows.Count > 0 Then
                For k As Int16 = 0 To dsNajavaNhm.Tables(0).Rows.Count - 1
                    Dim drNHM As DataRow = dtNhm.NewRow

                    'novo 5.2. home
                    NadjiNhmZaNajave(dsNajavaNhm.Tables(0).Rows(k).Item(2), mRazred, mRazredRid)

                    '5.2. staro-posao
                    'drNHM.ItemArray() = New Object() {dsNajavaNhm.Tables(0).Rows(k).Item(3), dsNajavaNhm.Tables(0).Rows(k).Item(2), dsNajavaNhm.Tables(0).Rows(k).Item(1), "0", "0", "0", "0", 0, 0, "0", "0", "0", "I"}

                    drNHM.ItemArray() = New Object() {dsNajavaNhm.Tables(0).Rows(k).Item(3), dsNajavaNhm.Tables(0).Rows(k).Item(2), dsNajavaNhm.Tables(0).Rows(k).Item(1), mRazred, mRazredRid, "0", "0", 0, 0, "0", "0", "0", "I"}


                    'drNHM.ItemArray() = New Object() {dsNajavaNhm.Tables(0).Rows(k).Item(3), dsNajavaNhm.Tables(0).Rows(k).Item(2), (dsNajavaNhm.Tables(0).Rows(k).Item(0) - dsNajavaNhm.Tables(0).Rows(k).Item(1)), "0", "0", "0", "0", 0, 0, "0", "0", "0", "I"}

                    'If Microsoft.VisualBasic.Mid(dsNajavaNhm.Tables(0).Rows(k).Item(0), 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(dsNajavaNhm.Tables(0).Rows(k).Item(0), 1, 4) = "9931" Then
                    '    drNHM.ItemArray() = New Object() {dsNajavaNhm.Tables(0).Rows(k).Item(3), dsNajavaNhm.Tables(0).Rows(k).Item(0), dsNajavaNhm.Tables(0).Rows(k).Item(2), "1", "", "", dsNajavaNhm.Tables(0).Rows(k).Item(1), 0, 0, "", "", "", "I"}
                    'Else
                    '    drNHM.ItemArray() = New Object() {dsNajavaNhm.Tables(0).Rows(k).Item(3), dsNajavaNhm.Tables(0).Rows(k).Item(0), dsNajavaNhm.Tables(0).Rows(k).Item(2), "0", "0", "0", "0", 0, 0, "0", "0", "0", "I"}
                    'End If

                    dtNhm.Rows.Add(drNHM)
                Next k
            Else
                MessageBox.Show("Nema tog podataka!", "informacija o pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Greska u pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try


        '-------------------------------------------------- popunjava KOLA ---------------------------------------------------
        dsNajavaKola.Clear()

        Try
            '***
            'u WinRoba.NajavaKola prosiriti polje za upravu na 4 cifre i stanicu na 7
            'Dim adNajavaKola As New SqlDataAdapter(" SELECT OtpUprava, OtpStanica, OtpDatum, OtpBroj, PrUprava, PrStanica, IBK, Vlasnik, Serija, Vrsta, Osovine, Tara, NHM, ICF " _
            Dim adNajavaKola As New SqlDataAdapter(" SELECT OtpUprava, OtpStanica, OtpDatum, OtpBroj, PrUprava, PrStanica, IBK, Vlasnik, Serija, Vrsta, Osovine, BrutoMasa-NetoMasa, NHM, ICF " _
                                                 & " FROM  dbo.NajavaKola " _
                                                 & " WHERE (BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaKola.KomBrojVoza = '" & mNajava & "') AND (dbo.NajavaKola.IBK = '" & cbKolaNajava.Text & "')", OkpDbVeza)

            ii1 = adNajavaKola.Fill(dsNajavaKola)
            If dsNajavaKola.Tables(0).Rows.Count > 0 Then

                tbUpravaOtp.Text = dsNajavaKola.Tables(0).Rows(0).Item(0)
                tbStanicaOtp.Text = dsNajavaKola.Tables(0).Rows(0).Item(1)
                DatumOtp.Text = dsNajavaKola.Tables(0).Rows(0).Item(2)
                tbBrojOtp.Text = dsNajavaKola.Tables(0).Rows(0).Item(3)
                tbUpravaPr.Text = dsNajavaKola.Tables(0).Rows(0).Item(4)
                tbStanicaPr.Text = dsNajavaKola.Tables(0).Rows(0).Item(5)

                mVlasnik = dsNajavaKola.Tables(0).Rows(0).Item(7)
                mSerija = dsNajavaKola.Tables(0).Rows(0).Item(8)
                mVrsta = dsNajavaKola.Tables(0).Rows(0).Item(9)
                mOsovine = dsNajavaKola.Tables(0).Rows(0).Item(10)
                mTara = dsNajavaKola.Tables(0).Rows(0).Item(11)
                mNHM = dsNajavaKola.Tables(0).Rows(0).Item(12)
                mICF = dsNajavaKola.Tables(0).Rows(0).Item(13)
                mIBK_KB = "D"

                '------------------------ dobijanje tipa kola ----------------------------
                Dim outTip
                Dim outKolKoef
                Dim mTovarena As String
                'Dim s As String
                's = mNHM
                If (mNHM.Substring(0, 4) = "9921") Or (mNHM.Substring(0, 4) = "9922") Then
                    mTovarena = "PK"
                Else
                    mTovarena = "TK"
                End If

                NadjiTipKola(mVrsta, mTovarena, mVlasnik, outTip, outKolKoef)
                '--------------------------------------------------------------------------

                tbUpravaOtp_Validating(Me, Nothing)
                tbStanicaOtp_Validating(Me, Nothing)
                tbUpravaPr_Validating(Me, Nothing)
                tbStanicaPr_Validating(Me, Nothing)

                Dim drKola As DataRow = dtKola.NewRow
                drKola.ItemArray() = New Object() {cbKolaNajava.Text, "ZS", mVlasnik, mSerija, mVrsta, mOsovine, mTara, 0, "N", outTip, 0, 0, mICF, mIBK_KB, "I"}
                dtKola.Rows.Add(drKola)

                'proveriti sta ovo radi i da li treba
                'If Not bCO Then
                '    Dim drNHM As DataRow = dtNhm.NewRow
                '    drNHM.ItemArray() = New Object() _
                '        {IBK, mNHM, mNetoMasa, "1", "", ""}
                '    dtNhm.Rows.Add(drNHM)
                'End If
            Else
                MessageBox.Show("Nema tog podataka!", "informacija o pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Greska u pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub LoadNajavaKontenerskiVoz()
        Dim en_Kola As IEnumerator
        Dim IBK
        Dim ii1 As Int32

        dtKola.Clear()
        dtNhm.Clear()

        Daljinar()

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        '-------------------------------------------------- popunjava NHM ---------------------------------------------------
        en_Kola = cbKolaNajava.Items.GetEnumerator()
        dsNajavaNhm.Clear()

        Try
            Dim adNajavaNhm As New SqlDataAdapter("SELECT dbo.NajavaIC.NHM, dbo.NajavaIC.UTITip, dbo.NajavaKola.NetoMasa, dbo.NajavaKola.IBK as [IBK] " _
                                        & " FROM dbo.NajavaKola INNER JOIN dbo.NajavaIC ON dbo.NajavaKola.BrUgovora = dbo.NajavaIC.BrUgovora AND dbo.NajavaKola.KomBrojVoza = dbo.NajavaIC.KomBrVoza AND dbo.NajavaKola.KolaStavka = dbo.NajavaIC.KolaStavka " _
                                        & " WHERE (dbo.NajavaKola.IBK = '" & cbKolaNajava.Text & "') AND (dbo.NajavaKola.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaKola.KomBrojVoza = '" & mNajava & "')", OkpDbVeza)


            ii1 = adNajavaNhm.Fill(dsNajavaNhm)

            If dsNajavaNhm.Tables(0).Rows.Count > 0 Then
                For k As Int16 = 0 To dsNajavaNhm.Tables(0).Rows.Count - 1
                    Dim drNHM As DataRow = dtNhm.NewRow

                    If Microsoft.VisualBasic.Mid(dsNajavaNhm.Tables(0).Rows(k).Item(0), 1, 4) = "9941" Or Microsoft.VisualBasic.Mid(dsNajavaNhm.Tables(0).Rows(k).Item(0), 1, 4) = "9931" Then
                        drNHM.ItemArray() = New Object() {dsNajavaNhm.Tables(0).Rows(k).Item(3), dsNajavaNhm.Tables(0).Rows(k).Item(0), dsNajavaNhm.Tables(0).Rows(k).Item(2), "1", "", "", dsNajavaNhm.Tables(0).Rows(k).Item(1), 0, 0, "", "", "", "I"}
                    Else
                        drNHM.ItemArray() = New Object() {dsNajavaNhm.Tables(0).Rows(k).Item(3), dsNajavaNhm.Tables(0).Rows(k).Item(0), dsNajavaNhm.Tables(0).Rows(k).Item(2), "", "", "", dsNajavaNhm.Tables(0).Rows(k).Item(1), 0, 0, "", "", "", "I"}
                    End If

                    dtNhm.Rows.Add(drNHM)
                Next k
            Else
                MessageBox.Show("Nema tog podataka!", "informacija o pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Greska u pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try


        '-------------------------------------------------- popunjava KOLA ---------------------------------------------------
        dsNajavaKola.Clear()

        Try
            '***
            'u WinRoba.NajavaKola prosiriti polje za upravu na 4 cifre i stanicu na 7

            Dim adNajavaKola As New SqlDataAdapter(" SELECT OtpUprava, OtpStanica, OtpDatum, OtpBroj, PrUprava, PrStanica, IBK, Vlasnik, Serija, Vrsta, Osovine, Tara, NHM, ICF " _
                                                 & " FROM  dbo.NajavaKola " _
                                                  & " WHERE (BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaKola.KomBrojVoza = '" & mNajava & "') AND (dbo.NajavaKola.IBK = '" & cbKolaNajava.Text & "')", OkpDbVeza)

            ii1 = adNajavaKola.Fill(dsNajavaKola)
            If dsNajavaKola.Tables(0).Rows.Count > 0 Then

                tbUpravaOtp.Text = dsNajavaKola.Tables(0).Rows(0).Item(0)
                tbStanicaOtp.Text = dsNajavaKola.Tables(0).Rows(0).Item(1)
                DatumOtp.Text = dsNajavaKola.Tables(0).Rows(0).Item(2)
                tbBrojOtp.Text = dsNajavaKola.Tables(0).Rows(0).Item(3)
                tbUpravaPr.Text = dsNajavaKola.Tables(0).Rows(0).Item(4)
                tbStanicaPr.Text = dsNajavaKola.Tables(0).Rows(0).Item(5)

                mVlasnik = dsNajavaKola.Tables(0).Rows(0).Item(7)
                mSerija = dsNajavaKola.Tables(0).Rows(0).Item(8)
                mVrsta = dsNajavaKola.Tables(0).Rows(0).Item(9)
                mOsovine = dsNajavaKola.Tables(0).Rows(0).Item(10)
                mTara = dsNajavaKola.Tables(0).Rows(0).Item(11)
                mNHM = dsNajavaKola.Tables(0).Rows(0).Item(12)
                mICF = dsNajavaKola.Tables(0).Rows(0).Item(13)
                mIBK_KB = "D"

                '------------------------ dobijanje tipa kola ----------------------------
                Dim outTip
                Dim outKolKoef
                Dim mTovarena As String
                'Dim s As String
                's = mNHM
                If (mNHM.Substring(0, 4) = "9921") Or (mNHM.Substring(0, 4) = "9922") Then
                    mTovarena = "PK"
                Else
                    mTovarena = "TK"
                End If

                NadjiTipKola(mVrsta, mTovarena, mVlasnik, outTip, outKolKoef)
                '--------------------------------------------------------------------------

                tbUpravaOtp_Validating(Me, Nothing)
                tbStanicaOtp_Validating(Me, Nothing)
                tbUpravaPr_Validating(Me, Nothing)
                tbStanicaPr_Validating(Me, Nothing)

                Dim drKola As DataRow = dtKola.NewRow
                drKola.ItemArray() = New Object() {cbKolaNajava.Text, "ZS", mVlasnik, mSerija, mVrsta, mOsovine, mTara, 0, "N", outTip, 0, 0, mICF, mIBK_KB, "I"}
                dtKola.Rows.Add(drKola)

                'proveriti sta ovo radi i da li treba
                'If Not bCO Then
                '    Dim drNHM As DataRow = dtNhm.NewRow
                '    drNHM.ItemArray() = New Object() _
                '        {IBK, mNHM, mNetoMasa, "1", "", ""}
                '    dtNhm.Rows.Add(drNHM)
                'End If
            Else
                MessageBox.Show("Nema tog podataka!", "informacija o pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Greska u pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub LoadDataKola() 'za brisanje

        Dim IBK
        Dim en As IEnumerator
        Dim bCO As Boolean
        Dim rdrCoUg As SqlClient.SqlDataReader

        mBrojVoza = Trim(cbNajava.SelectedItem)

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        '------------------------ ispituje ima li najave u tabeli NajavaVoza --------------------------------------
        Try
            Dim sql_text As String = "SELECT DISTINCT RacMesec FROM dbo.NajavaVoza " & _
                                     "WHERE (dbo.NajavaVoza.KomBrojVoza = '" & mBrojVoza & "')"

            Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)

            rdrCoUg = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
            bCO = rdrCoUg.HasRows
            rdrCoUg.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Greska u pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        'ispituje ima li najave u tabeli NajavaIC
        'Try
        '    Dim sql_text As String = "SELECT DISTINCT NHM FROM dbo.NajavaIC " & _
        '                             "WHERE (dbo.NajavaIC.KomBrVoza = '" & mBrojVoza & "')"

        '    Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)

        '    rdrUg = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        '    bIC = rdrUg.HasRows
        '    rdrUg.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Greska u pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End Try


        '-------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------
        If bCO Then

            ' ------------------------------------------ popunjava NHM ---------------------------------------------------
            en = cbKolaNajava.Items.GetEnumerator()
            While en.MoveNext()
                IBK = en.Current
                ds2.Clear()
                Dim ii1 As Int32
                Try
                    Dim ad1 As New SqlDataAdapter(" SELECT dbo.NajavaIC.UTI, dbo.NajavaIC.NHM as NHMIC, dbo.NajavaIC.UTITip, dbo.NajavaIC.MasaKontejnera, dbo.NajavaKola.IBK as [IBK] " _
                                                & " FROM  dbo.NajavaIC INNER JOIN dbo.NajavaKola ON (dbo.NajavaKola.KomBrojVoza=dbo.NajavaIC.KomBrVoza AND dbo.NajavaKola.BrUgovora=dbo.NajavaIC.BrUgovora AND dbo.NajavaKola.KolaStavka=dbo.NajavaIC.KolaStavka) " _
                                                & " WHERE (dbo.NajavaIC.KomBrVoza = '" & mBrojVoza & "') AND (dbo.NajavaKola.IBK = '" & IBK & "')", DbVeza)

                    ii1 = ad1.Fill(ds2)
                    If ds2.Tables(0).Rows.Count > 0 Then

                        For k As Int16 = 0 To ds2.Tables(0).Rows.Count - 1

                            '"NHM", Type.GetType("System.String"))
                            '"Masa", Type.GetType("System.Int32"))
                            '"R", Type.GetType("System.String"))
                            '"RID", Type.GetType("System.String"))
                            '"UTI", Type.GetType("System.String"))

                            Dim drNHM As DataRow = dtNhm.NewRow
                            drNHM.ItemArray() = New Object() _
                                {k + 1, ds2.Tables(0).Rows(k).Item(4), ds2.Tables(0).Rows(k).Item(1), ds2.Tables(0).Rows(k).Item(3), "1", "", ds2.Tables(0).Rows(k).Item(0)}

                            ' koriscenje privremene liste sa podacima sa svih kola
                            tempNHM.Add(drNHM)
                            'dtNhm.Rows.Add(drNHM)

                        Next k

                    Else
                        MessageBox.Show("Nema tog podataka!", "informacija o pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Greska u pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try

            End While

        End If

        ' KOLA ----------------------------------------------------------------------------

        en = cbKolaNajava.Items.GetEnumerator()
        While en.MoveNext()
            IBK = en.Current

            ds1.Clear()

            Dim ii1 As Int32

            Try

                Dim ad1 As New SqlDataAdapter(" SELECT dbo.NajavaKola.OtpUprava, dbo.NajavaKola.OtpStanica, dbo.NajavaKola.OtpDatum, dbo.NajavaKola.OtpBroj, " _
                                            & "dbo.NajavaKola.PrUprava, dbo.NajavaKola.PrStanica, dbo.NajavaKola.BrutoMasa, dbo.NajavaKola.NetoMasa, dbo.NajavaKola.NHM, dbo.NajavaKola.Vlasnik, dbo.NajavaKola.Vrsta, dbo.NajavaKola.Serija, dbo.NajavaKola.Osovine, dbo.NajavaKola.ICF " _
                                            & " FROM  dbo.NajavaKola " _
                                            & " WHERE (dbo.NajavaKola.KomBrojVoza = '" & mBrojVoza & "') AND (dbo.NajavaKola.IBK = '" & IBK & "')", DbVeza)

                '& " WHERE (dbo.NajavaKola.IBK = '" & IBK & "')", DbVeza)


                '& " WHERE (dbo.NajavaKola.KomBrojVoza = '" & mBrojVoza & "') AND (dbo.NajavaKola.IBK = '" & IBK & "')", DbVeza)

                '& " WHERE (dbo.NajavaIC.KomBrVoza = '" & mBrojVoza & "') AND (dbo.NajavaKola.IBK = '" & IBK & "')", DbVeza)
                '"WHERE (dbo.NajavaIC.KomBrVoza = '" & mBrojVoza & "')"


                ii1 = ad1.Fill(ds1)

                If ds1.Tables(0).Rows.Count > 0 Then

                    tbUpravaOtp.Text = ds1.Tables(0).Rows(0).Item(0)
                    tbStanicaOtp.Text = ds1.Tables(0).Rows(0).Item(1)
                    DatumOtp.Text = ds1.Tables(0).Rows(0).Item(2)
                    tbBrojOtp.Text = ds1.Tables(0).Rows(0).Item(3)

                    tbUpravaPr.Text = ds1.Tables(0).Rows(0).Item(4)
                    tbStanicaPr.Text = ds1.Tables(0).Rows(0).Item(5)

                    'bruto-neto masa
                    mBrutoMasa = ds1.Tables(0).Rows(0).Item(6)
                    mNetoMasa = ds1.Tables(0).Rows(0).Item(7)
                    mTara = mBrutoMasa - mNetoMasa
                    mNHM = ds1.Tables(0).Rows(0).Item(8)

                    mVlasnik = ds1.Tables(0).Rows(0).Item(9)
                    mVrsta = ds1.Tables(0).Rows(0).Item(10)
                    mSerija = ds1.Tables(0).Rows(0).Item(11)
                    mOsovine = ds1.Tables(0).Rows(0).Item(12)
                    mICF = ds1.Tables(0).Rows(0).Item(13)

                    Dim outTip
                    Dim outKolKoef
                    Dim mTovarena
                    Dim s As String
                    s = mNHM
                    If (s.Substring(0, 4) = "9921") Or (s.Substring(0, 4) = "9922") Then
                        mTovarena = "PK"
                    Else
                        mTovarena = "TK"
                    End If

                    NadjiTipKola(mVrsta, mTovarena, mVlasnik, outTip, outKolKoef)

                    tbUpravaOtp_Validating(Me, Nothing)
                    tbStanicaOtp_Validating(Me, Nothing)

                    tbUpravaPr_Validating(Me, Nothing)
                    tbStanicaPr_Validating(Me, Nothing)

                    'IndBrojKola", Type.GetType("System.String"))
                    'Uprava", Type.GetType("System.String"))
                    'Vlasnik", Type.GetType("System.String"))
                    'Serija", Type.GetType("System.String"))
                    'Vrsta", Type.GetType("System.String"))
                    'Osovine", Type.GetType("System.Int16"))
                    'Tara", Type.GetType("System.Int32"))
                    'GrTov", Type.GetType("System.Decimal"))
                    'Stitna", Type.GetType("System.String"))
                    'Tip", Type.GetType("System.String"))
                    'Prevoznina", Type.GetType("System.Decimal"))
                    'Naknada", Type.GetType("System.Decimal"))
                    'ICF", Type.GetType("System.String"))

                    Dim drKola As DataRow = dtKola.NewRow
                    drKola.ItemArray() = New Object() _
                        {IBK, ds1.Tables(0).Rows(0).Item(0), mVlasnik, mSerija, mVrsta, mOsovine, mTara, 0, "", outTip, 0, 0, mICF}
                    dtKola.Rows.Add(drKola)

                    If Not bCO Then
                        Dim drNHM As DataRow = dtNhm.NewRow
                        drNHM.ItemArray() = New Object() _
                            {IBK, mNHM, mNetoMasa, "1", "", ""}
                        dtNhm.Rows.Add(drNHM)
                    End If

                Else
                    MessageBox.Show("Nema tog podataka!", "informacija o pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Greska u pristupu bazi podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

        End While

    End Sub

    Private Sub cbKolaNajava_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbKolaNajava.Leave
        Button5.Focus()
    End Sub

    Private Sub cbSmer2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub cbKolaNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbKolaNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub cbNajava_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNajava.Leave
        cbNajava.Text = cbNajava.Text.ToUpper()
        If Microsoft.VisualBasic.Mid(cbNajava.Text, 1, 1) = "X" Then
            mMakis = "IZ"
            lblMakis.Visible = True
            tbMakis.Visible = True
            tbMakis.Focus()
        ElseIf Microsoft.VisualBasic.Mid(cbNajava.Text, 2, 1) = "X" Then
            mMakis = "ZA"
            lblMakis.Visible = False
            tbMakis.Visible = False
            Button6.Focus()
        Else
            If mRucnaNajava = "D" Then
                mMakis = "NN"
                lblMakis.Visible = False
                tbMakis.Visible = False
                Me.tbKolauNajavi.Visible = True
                Me.tbKolauNajavi.Enabled = True
                Me.tbKolaRealizovano.Enabled = True
                Me.tbKolaRealizovano.Visible = True
                Me.tbKolauNajavi.Focus()
            Else
                mMakis = "NN"
                lblMakis.Visible = False
                tbMakis.Visible = False
                If AkcijaZaPreuzimanje = "Ne" Then
                    Me.tbKolauNajavi.Focus()
                Else
                    Button6.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub cbSmer2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer2.Leave
        If cbSmer2.Text = Nothing Or cbSmer2.Text = cbSmer1.Text Then
            cbSmer2.Focus()
        Else
            Daljinar()

            If TipTranzita = "ulaz" Then
                'tbUpravaOtp.Focus()
                Me.tbUlaznaNalepnica_Validating(Me, Nothing)
                Me.tbUlaznaNalepnica.Focus()
            Else
                Me.tbIzlaznaNalepnica.Focus()
            End If
        End If
    End Sub
    Private Sub Daljinar()
        Dim sql_text As String

        '---------------------------------------------------------------------------
        If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then
            If mVrstaPrevoza <> "P" Then ' grupa ili voz => moze da pozove najavu
                mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
                mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
            Else
                mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
                mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
            End If
        Else
            mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
        End If
        '----------------------------------------------------------------------------

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        If Int(mStanica1) < Int(mStanica2) Then
            If IzborSaobracaja = "4" Then
                sql_text = "SELECT StvarniKm, TarifskiKm " & _
                                         "FROM dbo.ZsDaljinar " & _
                                         "WHERE (Stanica1 = '" & mStanica1 & "') AND (Stanica2 = '" & mStanica2 & "')"
            Else
                sql_text = "SELECT TarifskiKm, StvarniKm " & _
                                         "FROM dbo.ZsDaljinar " & _
                                         "WHERE (Stanica1 = '" & mStanica1 & "') AND (Stanica2 = '" & mStanica2 & "')"
            End If
        Else
            If IzborSaobracaja = "4" Then
                sql_text = "SELECT StvarniKm, TarifskiKm  " & _
                                                     "FROM dbo.ZsDaljinar " & _
                                                     "WHERE (Stanica1 = '" & mStanica2 & "') AND (Stanica2 = '" & mStanica1 & "')"

            Else
                sql_text = "SELECT TarifskiKm, StvarniKm " & _
                                                     "FROM dbo.ZsDaljinar " & _
                                                     "WHERE (Stanica1 = '" & mStanica2 & "') AND (Stanica2 = '" & mStanica1 & "')"
            End If
        End If

        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrDalj As SqlClient.SqlDataReader

        rdrDalj = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrDalj.Read()
            tbKm1.Text = rdrDalj.GetInt16(0)

            If IzborSaobracaja = "4" Then
                sTkm = tbKm1.Text
                bTkm = rdrDalj.GetInt16(0)
            Else
                bTkm = tbKm1.Text
                sTkm = rdrDalj.GetInt16(1)
            End If

        Loop
        rdrDalj.Close()
        DbVeza.Close()

    End Sub
    Private Sub cbSmer1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub tbUlaznaNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUlaznaNalepnica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbIzlaznaNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbIzlaznaNalepnica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbIzlaznaNalepnica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbIzlaznaNalepnica.Validating
        If tbIzlaznaNalepnica.Text = Nothing Then
            tbIzlaznaNalepnica.Focus()
        Else
            tbUpravaOtp.Focus()
        End If
    End Sub

    Private Sub tbUpravaOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUpravaOtp.Validating
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""

        ''Util.sNadjiNaziv("UicOperateri", Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 1, 2), Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2), "", 1, xNaziv, xPovVrednost)
        Util.sNadjiNaziv("UicOperateri", tbUpravaOtp.Text, "", "", 1, xNaziv, xPovVrednost)

        If xPovVrednost <> "" Then
            ErrorProvider1.SetError(tbUpravaOtp, "Nepostojeca uprava!")
            tbUpravaOtp.Focus()
        Else
            'Label11.Text = xNaziv
            'mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)

            '''Label11.Text = xNaziv
            Label11.Text = Microsoft.VisualBasic.Mid(xNaziv, 3, Len(xNaziv))
            '''mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)
            mOtpUprava = Microsoft.VisualBasic.Left(xNaziv, 2)

            If Len(tbStanicaOtp.Text) = 7 Then

            Else
                ''tbStanicaOtp.Text = Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2)
                tbStanicaOtp.Text = mOtpUprava
                tbStanicaOtp.SelectionStart = 3
            End If
            ErrorProvider1.SetError(tbUpravaOtp, "")
        End If
        If Microsoft.VisualBasic.Right(tbUpravaOtp.Text, 2) = "72" Then
            ErrorProvider1.SetError(tbUpravaOtp, "Otpravna uprava ne moze biti ZS !")
            tbUpravaOtp.Focus()
        Else
            ErrorProvider1.SetError(tbUpravaOtp, "")
        End If

    End Sub

    Private Sub tbStanicaOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaOtp.Validating
        If Len(tbStanicaOtp.Text) < 7 Then
            ErrorProvider1.SetError(tbStanicaOtp, "Neispravna sifra stanice!")
        Else
            Dim xNaziv As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiNaziv("UicStanice", tbStanicaOtp.Text, "", "", mBrojPokusaja, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                If mBrojPokusaja > 3 Then
                    mBrojPokusaja = 1
                    Label12.Text = "Nepostojeca sifra stanice"
                    mOtpStanica = tbStanicaOtp.Text
                    Me.tbStanicaOtp.BackColor = System.Drawing.Color.Red
                    ErrorProvider1.SetError(tbStanicaOtp, "")
                Else
                    mBrojPokusaja = mBrojPokusaja + 1
                    ErrorProvider1.SetError(tbStanicaOtp, "Nepostojeca stanica!")
                    tbStanicaOtp.Focus()
                End If
            Else
                mBrojPokusaja = 1
                Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
                Label12.Text = xNaziv
                mOtpStanica = tbStanicaOtp.Text
                ErrorProvider1.SetError(tbStanicaOtp, "")
                mOtpUprava = Microsoft.VisualBasic.Mid(mOtpStanica, 1, 2)
            End If
        End If
    End Sub

    Private Sub tbStanicaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUpravaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUpravaOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUpravaPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUpravaPr.Validating
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""

        ''Util.sNadjiNaziv("UicOperateri", Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 1, 2), Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2), "", 1, xNaziv, xPovVrednost)
        Util.sNadjiNaziv("UicOperateri", tbUpravaPr.Text, "", "", 1, xNaziv, xPovVrednost)
        If xPovVrednost <> "" Then
            If tbUpravaOtp.Text <> tbUpravaPr.Text Then
                ErrorProvider1.SetError(tbUpravaPr, "Nepostojeca uprava!")
            Else
                ErrorProvider1.SetError(tbUpravaPr, "Otpravna i uputna uprava moraju biti razlicite!")
            End If
            tbUpravaPr.Focus()
        Else
            ''Label14.Text = xNaziv
            ''mPrUprava = Microsoft.VisualBasic.Mid(tbStanicaPr.Text, 1, 2)

            '''Label14.Text = xNaziv
            Label14.Text = Microsoft.VisualBasic.Mid(xNaziv, 3, Len(xNaziv))
            '''mPrUprava = Microsoft.VisualBasic.Mid(tbStanicaPr.Text, 1, 2)
            mPrUprava = Microsoft.VisualBasic.Left(xNaziv, 2)
            If Len(tbStanicaPr.Text) = 7 Then

            Else
                '''tbStanicaPr.Text = Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2)
                tbStanicaPr.Text = mPrUprava
                tbStanicaPr.SelectionStart = 3
            End If
            ErrorProvider1.SetError(tbUpravaPr, "")
            'mPrUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)
        End If

        If Microsoft.VisualBasic.Right(tbUpravaPr.Text, 2) = Microsoft.VisualBasic.Right(tbUpravaOtp.Text, 2) Then
            ErrorProvider1.SetError(tbUpravaPr, "Otpravna i uputna uprava moraju biti razlicite!")
            tbUpravaPr.Focus()
        Else
            '            ErrorProvider1.SetError(tbUpravaPr, "")

            If Microsoft.VisualBasic.Right(tbUpravaPr.Text, 2) = "72" Then
                ErrorProvider1.SetError(tbUpravaPr, "Uputna uprava ne moze biti ZS !")
                tbUpravaPr.Focus()
            Else
                ErrorProvider1.SetError(tbUpravaPr, "")
            End If
        End If


    End Sub

    Private Sub tbUpravaPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUpravaPr.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbStanicaPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaPr.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbStanicaPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaPr.Validating
        If Len(tbStanicaPr.Text) < 7 Then
            ErrorProvider1.SetError(tbStanicaPr, "Neispravna sifra stanice!")
        Else
            Dim xNaziv As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiNaziv("UicStanice", tbStanicaPr.Text, "", "", mBrojPokusaja, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                If mBrojPokusaja > 3 Then
                    mBrojPokusaja = 1
                    Label13.Text = "Nepostojeca sifra stanice"
                    mPrStanica = tbStanicaPr.Text
                    Me.tbStanicaPr.BackColor = System.Drawing.Color.Red
                    ErrorProvider1.SetError(tbStanicaPr, "")
                Else
                    mBrojPokusaja = mBrojPokusaja + 1
                    ErrorProvider1.SetError(tbStanicaPr, "Nepostojeca stanica!")
                    tbStanicaPr.Focus()
                End If
            Else
                mBrojPokusaja = 1
                Me.tbStanicaPr.BackColor = System.Drawing.Color.White
                Label13.Text = xNaziv
                mPrStanica = tbStanicaPr.Text
                ErrorProvider1.SetError(tbStanicaPr, "")
                mPrUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatumOtp.Leave
        'HN
        'mDatumKalk = DatumOtp.Value
        'tbUpravaPr.Focus()
    End Sub

    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.Leave
        'btnUnosRobe.Focus()
        cbFrankoPrevoznina.Focus()

    End Sub

    Private Sub tbBrojOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbBrojPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojPr.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbKm1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbKm1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnKalkulacija_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub GroupBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GroupBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub rb1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rb1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub rb2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rb2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub rb3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rb3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub btnUpis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpis.Click

        '-- kontrola Stvarne mase!
        Dim rowNhm As DataRow
        Dim nmCtrlSM As Boolean = True

        For Each rowNhm In dtNhm.Rows
            If rowNhm.Item("Masa") = 0 Then
                nmCtrlSM = False
                Exit For
            End If
        Next
        If nmCtrlSM = False Then
            MessageBox.Show("Stvarna masa robe ne može da bude nula! Ispravite podatke o robi. ", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        '-----------------------------

        Dim mUkljucujuci As String = ""
        Dim mDoPrelaza As String = ""
        Dim mIncoterms As String = ""
        Dim mIzjava2Deo As String = ""

        Dim errText1 As String
        Dim errText2 As String
        Dim errText3 As String
        Dim errText4 As String
        Dim errText5 As String
        Dim errText6 As String
        Dim errText7 As String
        Dim errText8 As String
        Dim errText9 As String
        Dim errText10 As String
        Dim errText11 As String
        Dim errText12 As String
        Dim errText20 As String
        '-------------------------------- Kontrola forme --------------------------------------------
        dtError.Clear()

        If mNemaTare = "1" Then
            errText20 = "Tara kola"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText20, "Nije upisana tara kola"})
        End If

        If cbSmer2.Text = Nothing Then
            errText1 = "Izlazni granicni prelaz"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText1, "Prazno polje!"})
        End If
        If Me.tbUlaznaNalepnica.Text = Nothing Or Me.tbUlaznaNalepnica.Text = 0 Then
            errText3 = "Ulazna tranzitna nalepnica"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText3, "Prazno polje!"})
        End If
        If Me.tbIzlaznaNalepnica.Text = Nothing Or Me.tbIzlaznaNalepnica.Text = 0 Then
            errText4 = "Izlazna tranzitna nalepnica"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText4, "Prazno polje!"})
        End If
        If Me.tbKm1.Text = Nothing Then 'Or CType(tbKm1.Text, Integer) = 0 Then
            errText5 = "Tarifski kilometri"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText5, "Prazno polje!"})
        End If
        If Me.tbUpravaOtp.Text = Nothing Then
            errText6 = "Otpravna uprava - operater"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText6, "Prazno polje!"})
        ElseIf Len(Me.tbUpravaOtp.Text) > 0 And Len(Me.tbUpravaOtp.Text) < 4 Then
            errText6 = "Otpravna uprava - operater"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText6, "Nepotpuna sifra operatera!"})
        End If

        If Microsoft.VisualBasic.Right(Me.tbUpravaOtp.Text, 2) = "72" Then
            errText6 = "Otpravna uprava - operater"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText6, "Pogresna sifra uprave - ZS ?"})
        End If

        If Me.tbStanicaOtp.Text = Nothing Then
            errText7 = "Otpravna stanica"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText7, "Prazno polje!"})
        ElseIf Len(Me.tbStanicaOtp.Text) > 0 And Len(Me.tbStanicaOtp.Text) < 7 Then
            errText7 = "Otpravna stanica"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText7, "Nepotpuna sifra stanice!"})
        End If

        If Me.tbBrojOtp.Text = Nothing Then
            errText8 = "Broj otpravljanja"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText8, "Prazno polje!"})
        ElseIf CType(Me.tbBrojOtp.Text, Int32) = 0 Then
            errText8 = "Broj otpravljanja"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText8, "Broj otpravljanja ne moze da bude nula!"})
        End If

        If Me.tbUpravaPr.Text = Nothing Then
            errText9 = "Uputna uprava - operater"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText9, "Prazno polje!"})
        ElseIf Len(Me.tbUpravaPr.Text) > 0 And Len(Me.tbUpravaPr.Text) < 4 Then
            errText9 = "Uputna uprava - operater"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText9, "Nepotpuna sifra operatera!"})
        End If

        If Microsoft.VisualBasic.Right(Me.tbUpravaPr.Text, 2) = "72" Then
            errText6 = "Uputna uprava - operater"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText6, "Pogresna sifra uprave - ZS ?"})
        End If

        If Microsoft.VisualBasic.Right(Me.tbUpravaPr.Text, 2) = Microsoft.VisualBasic.Right(Me.tbUpravaOtp.Text, 2) Then
            errText6 = "Uputna uprava - operater"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText6, "Iste sifre za otpravnu i uputnu upravu!"})
        End If

        If Me.tbStanicaPr.Text = Nothing Then
            errText10 = "Uputna stanica"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText10, "Prazno polje!"})
        ElseIf Len(Me.tbStanicaPr.Text) > 0 And Len(Me.tbStanicaPr.Text) < 7 Then
            errText10 = "Uputna stanica"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText10, "Nepotpuna sifra stanice!"})
        End If

        If bVrstaPosiljke = "K" Then
            If dtKola.Rows.Count = 0 Or dtNhm.Rows.Count = 0 Then
                errText11 = "Unos kola i robe"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText11, "Niste uneli podatke o kolima i robi!"})
            End If
        End If

        If dtError.Rows.Count = 0 Then
            dgError.Visible = False
        Else
            dgError.Visible = True
        End If

        '------------------------------------------------ kontrola na greske i upis ------------------------------------------

        If dtError.Rows.Count = 0 Then ' nema gresaka

            Dim slogTrans As SqlTransaction
            Dim rv As String
            Dim drKola As DataRow
            Dim drNhm As DataRow
            Dim drDencane As DataRow
            Dim drNaknade As DataRow
            Dim mopRecID As Int32
            Dim MestoUnosa As String = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)

            Me.ProgressBar1.Visible = True
            Me.ProgressBar1.Value = 1

            mUlEtiketa = tbUlaznaNalepnica.Text
            mIzEtiketa = tbIzlaznaNalepnica.Text

            mPrikazKalkulacije = "N"

            '-------------------- broj kola po najavi -----------------
            If mVrstaPrevoza <> "P" Then ' grupa ili voz 
                mNajavaKola = tbKolauNajavi.Text
            End If

            '-------------------- Izjava -----------------------
            mSifraIzjave = 0
            If cbFrankoPrevoznina.Checked Then
                mSifraIzjave = 1
                mUkljucujuci = Me.fxFranko.Text
                mDoPrelaza = Me.tbFrankoPrelaz.Text
                mIzjava2Deo = Me.tbFrankoPrelaz.Text
            End If
            If cbIncoterms.Checked Then
                mSifraIzjave = 2
            End If

            '---------------------------------- Pristupa bazi -----------------------------------------------------
            Try
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                End If
                slogTrans = OkpDbVeza.BeginTransaction()

                '--------------------------------------- Upis u SlogKalk ---------------------------------------------
                If MasterAction = "New" Then
                    mAkcija = "New"
                    MestoUnosa = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)
                Else
                    mAkcija = "Upd"
                End If

                If mVrstaPrevoza = "V" Then
                    If mAkcija = "Upd" Then
                        If mMakis = "IZ" Then
                            If CDec(tbKolaRealizovano.Text) > 0 Then
                                fxPrevoznina.Text = 0 'prevoznina se upisuje samo na prvim kolima-ok
                            End If
                        Else
                            'prevoznina se ne menja! - nije zavrseno!!
                        End If
                    Else
                        If UpisPoKolima = False Then ' redovan upis cena za vozove - na prvim kolima
                            If CDec(tbKolaRealizovano.Text) > 0 Then

                                If Info_ObrMesec <> mObrMesec Then

                                    If Info_ObrIzvos <> mPrevoznina Then
                                        fxPrevoznina.Text = Math.Abs(Info_ObrIzvos - mPrevoznina) '3.4.2013: nov nacin inicijalizovanja Info_ObrIzvos i Info_ObrMesec
                                    Else
                                        fxPrevoznina.Text = 0
                                    End If

                                Else
                                    fxPrevoznina.Text = 0
                                End If
                            Else

                            End If
                        Else  ' cena za vozove koja se upisuje na svakom pojedinacnom tovarnom listu
                            fxPrevoznina.Text = mPrevoznina
                        End If
                    End If
                End If

                Cursor.Current = New Cursor("MyWait.cur")
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 9

                If mMakis = "IZ" Then
                    Upis.UpisSlogKalkMakis(slogTrans, mAkcija, MestoUnosa, tbUpravaOtp.Text, _
                        tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, mObrGodina, mObrMesec, mStanica1, tbUlaznaNalepnica.Text, _
                        Today(), mStanica2, tbIzlaznaNalepnica.Text, Today(), tbUpravaPr.Text, tbStanicaPr.Text, _
                        mPrispece, DateTimePicker2.Text, msBrojVoza, mSatVoza, mNajava, CType(mNajavaKola, Integer), _
                        mTarifa, mBrojUg, tbPosiljalac.Text, tbPlatilacFRR.Text, tbPrimalac.Text, tbPlatilacNFR.Text, _
                        bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, mVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, _
                        bTkm, sTkm, mSifraIzjave, mFrRacun, fxFranko.Text, Me.tbFrankoPrelaz.Text, Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), _
                        Microsoft.VisualBasic.Mid(Me.cbIsporuka.Text, 1, 3), Me.fxIsporuka.Text, Microsoft.VisualBasic.Mid(Me.cbPouzece.Text, 1, 3), _
                        Me.fxPouzece.Text, Microsoft.VisualBasic.Mid(Me.cbVrednost.Text, 1, 3), Me.fxVrednostRobe.Text, _
                        bValuta, (CDec(fxPrevoznina.Text) + CDec(fxNaknade.Text)), 0, CDec(fxPrevoznina.Text), 0, CDec(fxNaknade.Text), 0, mSumaNakCo82, mSumaNakCo, mUserID, Today(), _
                        mCarStanica, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
                        mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, _
                        mopRecID, rv)
                Else
                    'kod izmene: mnajava je prazan string - ispraviti

                    Upis.UpisSlogKalk(slogTrans, mAkcija, MestoUnosa, tbUpravaOtp.Text, _
                        tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, mObrGodina, mObrMesec, mStanica1, tbUlaznaNalepnica.Text, _
                        Today(), mStanica2, tbIzlaznaNalepnica.Text, Today(), tbUpravaPr.Text, tbStanicaPr.Text, _
                        mPrispece, DateTimePicker2.Text, msBrojVoza, mSatVoza, mNajava, CType(mNajavaKola, Integer), "0", 0, _
                        mTarifa, mBrojUg, tbPosiljalac.Text, tbPlatilacFRR.Text, tbPrimalac.Text, tbPlatilacNFR.Text, _
                        bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, mVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, _
                        bTkm, sTkm, mSifraIzjave, mFrRacun, fxFranko.Text, Me.tbFrankoPrelaz.Text, Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), _
                        Microsoft.VisualBasic.Mid(Me.cbIsporuka.Text, 1, 3), Me.fxIsporuka.Text, Microsoft.VisualBasic.Mid(Me.cbPouzece.Text, 1, 3), _
                        Me.fxPouzece.Text, Microsoft.VisualBasic.Mid(Me.cbVrednost.Text, 1, 3), Me.fxVrednostRobe.Text, _
                        bValuta, (CDec(fxPrevoznina.Text) + CDec(fxNaknade.Text)), 0, CDec(fxPrevoznina.Text), 0, CDec(fxNaknade.Text), 0, mSumaNakCo82, mSumaNakCo, _
                        (CDec(fxBlagajna.Text) - CDec(fxTL.Text)), mSifraK211, mUserID, Today(), _
                        mCarStanica, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
                        mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, _
                        mopRecID, rv)

                End If

                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 30

                If MasterAction = "Upd" Then
                    'mopRecID = ForUpdRecID
                    mopRecID = UpdRecID
                    MestoUnosa = UpdStanicaRecID
                End If

                If rv <> "" Then Throw New Exception(rv)

                '--------------------------------------- End Upis u SlogKalk -----------------------------------------


                '--------------------------------------- Upis u SlogKola ---------------------------------------------  
                If bVrstaPosiljke = "K" Then
                    Dim rbKola As Int16 = 1
                    Dim rbRoba As Int16 = 1

                    If dtKola.Rows.Count > 0 Then

                        For Each drKola In dtKola.Rows
                            If MasterAction = "New" Then
                                mAkcija = "New"
                            Else
                                If drKola("Action") = "I" Then
                                    mAkcija = "New"
                                ElseIf drKola("Action") = "U" Then
                                    mAkcija = "Upd"
                                ElseIf drKola("Action") = "D" Then
                                    mAkcija = "Del"
                                End If
                            End If

                            Upis.UpisSlogKola(slogTrans, mAkcija, mopRecID, MestoUnosa, tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, rbKola, _
                                         drKola("IndBrojKola"), drKola("KB"), drKola("Uprava"), drKola("Vlasnik"), drKola("Serija"), _
                                         drKola("Osovine"), drKola("Tara"), drKola("GrTov"), drKola("Stitna"), drKola("Tip"), drKola("Prevoznina"), _
                                         drKola("Naknada"), drKola("ICF"), rv)

                            '------------------------------- Upis u SlogRoba ---------------------------------------------  
                            For Each drNhm In dtNhm.Rows
                                If drNhm("IndBrojKola") = drKola("IndBrojKola") Then
                                    If MasterAction = "New" Then
                                        mAkcija = "New"
                                    Else
                                        If drNhm("Action") = "I" Then
                                            mAkcija = "New"
                                        ElseIf drNhm("Action") = "U" Then
                                            mAkcija = "Upd"
                                        ElseIf drNhm("Action") = "D" Then
                                            mAkcija = "Del"
                                        End If
                                    End If

                                    Upis.UpisSlogRoba(slogTrans, mAkcija, mopRecID, MestoUnosa, tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, _
                                                 rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
                                                 drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
                                                 drNhm("UTIBuletin"), drNhm("UTIPlombe"), drNhm("RacMasaNHM"), drNhm("VozarinskiStavNHM"), rv)

                                    rbRoba = rbRoba + 1
                                End If
                            Next

                            '------------------------------- End Upis u SlogRoba -----------------------------------------  
                            rbKola = rbKola + 1
                            rbRoba = 1
                        Next
                    Else
                        Throw New Exception(rv)
                    End If
                    '--------------------------------------- End Upis u SlogRoba -----------------------------------------  
                    If rv <> "" Then Throw New Exception(rv)
                    Me.ProgressBar1.Value = Me.ProgressBar1.Value + 30
                Else
                    '--------------------------------------- Upis u SlogDencane ------------------------------------------
                    Dim rbDencane As Int16 = 1
                    For Each drDencane In dtDencane.Rows
                        If MasterAction = "New" Then
                            mAkcija = "New"
                        Else
                            If drDencane("Action") = "I" Then
                                mAkcija = "New"
                            ElseIf drDencane("Action") = "U" Then
                                mAkcija = "Upd"
                            ElseIf drDencane("Action") = "D" Then
                                mAkcija = "Del"
                            End If
                        End If

                        Upis.UpisSlogDencane(slogTrans, mAkcija, mopRecID, MestoUnosa, _
                                    tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, _
                                    rbDencane, drDencane("SMasa"), drDencane("RMasa"), _
                                    drDencane("Tarifa"), drDencane("Tip"), drDencane("Komada"), _
                                    drDencane("Iznos"), drDencane("Valuta"), rv)

                        rbDencane = rbDencane + 1

                    Next
                    If rv <> "" Then Throw New Exception(rv)
                End If
                '--------------------------------------- Upis u SlogNaknada ------------------------------------------
                Dim rbNaknade As Int16 = 1
                If dtNaknade.Rows.Count > 0 Then
                    For Each drNaknade In dtNaknade.Rows
                        If MasterAction = "New" Then
                            mAkcija = "New"
                        Else
                            If drNaknade("Action") = "I" Then
                                mAkcija = "New"
                            ElseIf drNaknade("Action") = "U" Then
                                mAkcija = "Upd"
                            ElseIf drNaknade("Action") = "D" Then
                                mAkcija = "Del"
                            End If
                        End If

                        Upis.UpisSlogNaknada(slogTrans, mAkcija, mopRecID, MestoUnosa, tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, _
                                        rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
                                        drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

                        rbNaknade = rbNaknade + 1
                    Next
                End If
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 10
                '--------------------------------------- End Upis u SlogNaknada -----------------------------------

                If rv = "" Then
                    slogTrans.Commit()
                Else
                    MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    slogTrans.Rollback()
                End If
                ' ------------------------------------- END upisa u Slog* -----------------------------------------


                ' ================================  REKAPITULACIJA ZA VOZOVE  =====================================
                If mVrstaPrevoza <> "P" Then ' grupa ili voz => moze da pozove najavu

                    If OkpDbVeza.State = ConnectionState.Closed Then
                        OkpDbVeza.Open()
                    End If

                    slogTrans = OkpDbVeza.BeginTransaction()

                    Try
                        If RecordAction <> "N" Then  ' Ako je azuriranje OkpWinRoba -  ne radi izmene u NajavaVoza,NajavaKola (vec postoji)
                            Dim KolaRed As DataRow
                            Dim _mIbk As String
                            rv = ""

                            For Each KolaRed In dtKola.Rows
                                _mIbk = KolaRed.Item("IndBrojKola")

                                ' Update podataka u najavi 
                                'Upis.NajavaUpd(slogTrans, mBrojUg, mNajava, _mIbk, rv)

                                ' Ako je vise tovarnih listova po istim kolima ne treba da uvecava
                                ' broj realizovanih kola po najavi
                                ' Ako je cekirano rb2: "Više tovarnih listova po jednim kolima" => ne uvecava

                                If rb2.Checked = False Then
                                    Upis.NajavaUpd(slogTrans, mBrojUg, mNajava, _mIbk, rv)
                                    tbKolaRealizovano.Text = (CDec(tbKolaRealizovano.Text) + 1).ToString
                                End If

                            Next
                        Else
                            If mMakis = "IZ" Then  '*** da li je IZ ili ZA !
                                Dim KolaRed As DataRow
                                Dim _mIbk As String
                                rv = ""
                                For Each KolaRed In dtKola.Rows
                                    _mIbk = KolaRed.Item("IndBrojKola")
                                    ' Update podataka u najavi 
                                    If rb2.Checked = False Then
                                        Upis.NajavaUpd(slogTrans, mBrojUg, mNajava, _mIbk, rv)
                                        tbKolaRealizovano.Text = (CDec(tbKolaRealizovano.Text) + 1).ToString
                                    End If
                                Next
                            End If
                        End If

                        Me.ProgressBar1.Value = Me.ProgressBar1.Value + 5

                        If rv = "" Then
                            slogTrans.Commit()
                        Else
                            'MsgBox(rv)
                            slogTrans.Rollback()
                        End If

                        '------------------------ KOREKCIJA CENE ZBOG PROMENE BMV --------------------------------
                        Dim rv1 As String

                        If mVrstaPrevoza = "V" Then
                            'URADITI KOREKCIJU CENA ZA VOZOVE IZ MAKISA
                            'DA LI VAZI ZA SVE VOZOVE -  DIREKTNE, DO RANZIRNE, OD RANZIRNE?

                            ''Info_ObrMesec
                            ''Info_ObrIzvos

                            If Info_ObrMesec = mObrMesec Then
                                If Info_ObrIzvos <> mPrevoznina Then 'Radi samo ako je promenjena cena

                                    'PROODOS P KOLA -60 EURA
                                    If mBrojUg <> "481101" Then
                                        CoUpdatePrevoznine(mBrojUg, mNajava, mObrGodina, mPrevoznina, rv1)
                                    End If

                                End If
                            End If

                        End If
                        '-----------------------------------------------------------------------------------------

                        '---------------------------------- PRIKAZ PODATAKA O VOZU -------------------------------
                        Dim _rv As String = ""
                        Dim tmp_KolaNajava As Int16 = 0
                        Dim tmp_KolaReal As Int16 = 0
                        Dim tmp_Bruto As Decimal = 0
                        Dim tmp_Neto As Decimal = 0
                        Dim tmp_Tara As Decimal = 0
                        Dim tmp_Suma As Decimal = 0
                        Dim tmp_SumaPrev As Decimal = 0
                        Dim tmp_SumaNak As Decimal = 0
                        Dim tmp_SumaNakCo As Decimal = 0
                        Dim tmp_SumaNakCo82 As Decimal = 0

                        Util.NajavaPregledKalk(mBrojUg, mNajava, mObrGodina, tmp_KolaReal, tmp_Neto, tmp_Tara, _
                                               tmp_Suma, tmp_SumaPrev, tmp_SumaNak, tmp_SumaNakCo, tmp_SumaNakCo82, _
                                               _rv)
                        Me.ProgressBar1.Value = Me.ProgressBar1.Value + 15

                        Dim Str_Najava As String = ""
                        If mBrojUg <> "480701" Then
                            If tbKolaRealizovano.Text = tbKolauNajavi.Text Then
                                Str_Najava = "Broj kola  po najavi                       :  " & tbKolauNajavi.Text & Chr(13)
                                Str_Najava = Str_Najava & "Ukupna bruto masa voza              :  " & ((tmp_Neto + tmp_Tara) / 1000).ToString & "  [ t ] " & Chr(13)
                                Str_Najava = Str_Najava & "Izracunata prevoznina po vozu    :  " & (tmp_SumaPrev).ToString & Chr(13)
                                Str_Najava = Str_Najava & "Ukupan iznos naknada po vozu    :  " & (tmp_SumaNak).ToString & Chr(13)

                                'Str_Najava = Str_Najava & "Ukupni prevozni troskovi po vozu :  " & (tmp_Suma).ToString & Chr(13)

                                MessageBox.Show(Str_Najava, "Najava broj :  " & mNajava & "  je realizovana!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                mNajava = "0"
                                mNajavaKola = "0"
                                mNajavaKolaReal = "0"
                            Else
                                Str_Najava = "Broj kola  po najavi                   :  " & tbKolauNajavi.Text & Chr(13)
                                Str_Najava = Str_Najava & "Trenutno realizovano kola        :  " & tbKolaRealizovano.Text & Chr(13)
                                Str_Najava = Str_Najava & "Trenutna bruto masa voza       :  " & ((tmp_Neto + tmp_Tara) / 1000).ToString & "  [ t ] " & Chr(13)
                                Str_Najava = Str_Najava & "Izracunata prevoznina po vozu:  " & (tmp_SumaPrev).ToString & Chr(13)
                                Str_Najava = Str_Najava & "Ukupan iznos naknada po vozu:  " & (tmp_SumaNak).ToString & Chr(13)

                                MessageBox.Show(Str_Najava, "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                mNajava = cbNajava.Text
                                mNajavaKola = Me.tbKolauNajavi.Text
                                mNajavaKolaReal = Me.tbKolaRealizovano.Text
                            End If
                        End If
                    Catch ex As Exception
                        rv = ex.Message
                        Cursor.Current = System.Windows.Forms.Cursors.Default
                        MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Catch sqlex As SqlException
                        MsgBox(sqlex.Message)

                    Finally
                        OkpDbVeza.Close()

                    End Try
                    '---------------------------------------------------------------------------------------------
                End If
                ' =============================== END REKAPITULACIJA ZA VOZOVE ===================================

                '---------------------------------- Priprema za sledeci unos -------------------------------------
                dtKola.Clear()
                dtNhm.Clear()
                dtNaknade.Clear()

                tbValuta.Text = " "
                fxPrevoznina.Text = 0.0
                fxNaknade.Text = 0.0
                fxTL.Text = 0.0
                tbMakis.Text = "0"
                mPrevoznina = 0

                tbKolauVozu.Text = "1"
                mUlEtiketa = 0
                mIzEtiketa = 0

                mIBK = ""
                _mTara = ""
                _mNHM = ""
                _mSMasa = 0

                Me.Dispose()
                '----------------------------------- END Priprema za sledeci unos ---------------------------------

            Catch ex As Exception
                Me.ProgressBar1.Visible = False
                Me.ProgressBar1.Value = 1
                rv = ex.Message
                Cursor.Current = System.Windows.Forms.Cursors.Default
                If Microsoft.VisualBasic.Mid(rv, 1, 34) = "Violation of UNIQUE KEY constraint" Then
                    MessageBox.Show("Takav broj otpravljanja vec postoji u bazi podataka. Proverite ispravnost podataka.", "Nedozvoljeni upis podataka", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(rv.ToString, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                'MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Catch sqlex As SqlException
                Me.ProgressBar1.Visible = False
                Me.ProgressBar1.Value = 1

                If sqlex.Number = 2627 Then
                    MessageBox.Show("Takav broj otpravljanja vec postoji u bazi podataka. Proverite ispravnost podataka.", "Nedozvoljeni upis podataka", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(sqlex.Message.ToString, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                '***
                'MsgBox(GetFirstSqlErrorMsg(sqlex))
            Finally
                OkpDbVeza.Close()
            End Try
        Else
            'ima gresaka, vraca se nazad
        End If
    End Sub

    Private Sub UnosTrz_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        dgError.Visible = False
        If mPrikazKalkulacije = "D" Then

            If _OpenForm = "Roba" Then
                lbl_ibk.Text = mIBK
                lbl_tara.Text = _mTara
                lbl_nhm.Text = _mNHM
                lbl_smasa.Text = _mSMasa
                Me.lblEvraPoKolima.Text = _mNakPoKolima

                If mPkola = True Then
                    lbl_PkolaProdos.Visible = True
                Else
                    lbl_PkolaProdos.Visible = False
                End If
                '--------------------------------------------------------
                If Microsoft.VisualBasic.Left(_nmNakVER, 1) = "1" Then
                    Me.PictureBox3.Visible = True
                Else
                    Me.PictureBox3.Visible = False
                End If

                If Microsoft.VisualBasic.Mid(_nmNakVER, 2, 1) = "1" Then
                    Me.PictureBox4.Visible = True
                Else
                    Me.PictureBox4.Visible = False
                End If

                If Microsoft.VisualBasic.Right(_nmNakVER, 1) = "1" Then
                    Me.PictureBox5.Visible = True
                Else
                    Me.PictureBox5.Visible = False
                End If
                '--------------------------------------------------------

                Me.btnUpis.Focus()

                'If TipTranzita = "ulaz" Then

                '    lbl_ibk.Text = mIBK
                '    lbl_tara.Text = _mTara
                '    lbl_nhm.Text = _mNHM
                '    lbl_smasa.Text = _mSMasa
                '    Me.lblEvraPoKolima.Text = _mNakPoKolima

                '    If Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9922" Or Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9931" Then
                '        Me.btnUpis.Focus()
                '    End If
                'Else
                '    Me.btnUpis.Focus()
                'End If

                'MsgBox("U bazi podataka nije pronadena cena za ovu pošiljku! Proverite podatke.", MsgBoxStyle.Exclamation, "Poruka iz baze")

            ElseIf _OpenForm = "Naknade" Then
                If Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9922" Or Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9931" Then
                    Me.btnUpis.Focus()
                Else
                    tbTL.Focus()
                End If
            End If

            If bValuta = 17 Then
                tbValuta.Text = "EUR"
            ElseIf bValuta = 72 Then
                tbValuta.Text = "DIN"
            ElseIf bValuta = 85 Then
                tbValuta.Text = "CHF"
            ElseIf bValuta = 2 Then
                tbValuta.Text = "USD"
            End If

            Dim mPrevozninaRazlika As Decimal = 0

            '================
            '=========
            Dim Nak_Red As DataRow
            mSumaNak = 0
            mSumaNakCo = 0
            mSumaNakRo = 0
            mSumaNakCo82 = 0

            If dtNaknade.Rows.Count > 0 Then
                For Each Nak_Red In dtNaknade.Rows
                    If Nak_Red.Item("Obracun") = "C" Then
                        mSumaNakCo = mSumaNakCo + Nak_Red.Item("Iznos")
                    Else
                        mSumaNakRo = mSumaNakRo + Nak_Red.Item("Iznos")
                    End If
                Next
                mSumaNak = mSumaNakRo + mSumaNakCo82 + mSumaNakCo
            Else
                mSumaNak = 0
            End If
            '=========
            '================


            '------- Prikaz/upis prevoznine --------
            With fxPrevoznina
                .PromptChar = " "
                .Mask = "999999d99"
                If mVrstaPrevoza = "V" Then

                    If CDec(tbKolaRealizovano.Text) > 0 Then

                        If UpisPoKolima = False Then

                            '---------- Korekcija cene zbog zaostalih kola i promenjene BMV -----------------
                            If Info_ObrMesec <> mObrMesec Then
                                'novo:3.4.2013: 
                                'Info_ObrMesec je Min Info_ObrMesec
                                'Info_ObrIzvos je Sum(Info_ObrIzvos)
                                If Info_ObrIzvos <> mPrevoznina Then
                                    mPrevozninaRazlika = Info_ObrIzvos - mPrevoznina
                                    .Text = Format(mPrevozninaRazlika, "###,###,##0.00")
                                Else
                                    .Text = 0
                                End If

                            Else
                                .Text = 0 'Korekciju cene za isti mesec radi posle upisa
                            End If
                            '---------- end Korekcija cene zbog zaostalih kola i promenjene BMV -----------------

                        Else
                            .Text = Format(mPrevoznina, "###,###,##0.00")
                        End If

                    Else
                        .Text = Format(mPrevoznina, "###,###,##0.00")
                    End If

                Else
                    .Text = Format(mPrevoznina, "###,###,##0.00")
                End If
            End With
            '------- end Prikaz/upis prevoznine --------


            With fxNaknade
                .PromptChar = " "
                .Mask = "999999d99"
                '''''''''''''''''.Text = mSumaNak '.ToString
                .Text = Format(mSumaNak, "###,###,##0.00") '.ToString !! !!!!!!!!!!!!!!!!!!!!!!!!!1
            End With
            dgFinalNak.DataSource = dtNaknade
            dgFinalNak.Show()

            With fxTL
                .PromptChar = " "
                .Mask = "999999d99"
                '''''''''''''''''.Text = mSumaIznos '.ToString
                .Text = Format(mSumaIznos, "###,###,##0.00") '.ToString !! !!!!!!!!!!!!!!!!!!!!!!!!!1
            End With
            fxTL.Text = CDec(fxPrevoznina.Text) + CDec(fxNaknade.Text)
            '----------------------

        End If

        lbl_tara.Text = _mTara

        If upit = "UPR1" Then
            Me.tbUpravaOtp.Text = mIzlaz1
            Me.tbStanicaOtp.Text = mIzlaz1add
            Label11.Text = mIzlaz2
        End If

    End Sub

    Private Sub tbTL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbTL.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbTL_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbTL.LostFocus
        btnUpis.Focus()

    End Sub

    Private Sub btnStanicaOtp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStanicaOtp.Click
        helpUprava = Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2)
        'helpUprava = Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2)
        'EventsActived = True

        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UIC"
        helpUic.ShowDialog()
        ErrorProvider1.SetError(tbStanicaOtp, "")
        Me.tbStanicaOtp.Text = mIzlaz1
        Label12.Text = mIzlaz2
        tbBrojOtp.Focus()

    End Sub

    Private Sub btnStanicaPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStanicaPr.Click
        helpUprava = Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2)
        'helpUprava = Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2)

        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UIC"
        helpUic.ShowDialog()
        ErrorProvider1.SetError(tbStanicaPr, "")
        Me.tbStanicaPr.Text = mIzlaz1

        Label13.Text = mIzlaz2
        Me.DateTimePicker2.Focus()
    End Sub

    Private Sub btnUpravaOtp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpravaOtp.Click
        Me.tbStanicaOtp.Clear()

        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UPR1"
        helpUic.ShowDialog()
        Me.tbUpravaOtp.Text = mIzlaz1
        Me.tbStanicaOtp.Text = mIzlaz1add
        Label11.Text = mIzlaz2


        tbStanicaOtp.Focus()
    End Sub

    Private Sub btnUpravaPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpravaPr.Click
        Me.tbStanicaPr.Clear()

        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UPR2"
        helpUic.ShowDialog()
        Me.tbUpravaPr.Text = mIzlaz1
        Me.tbStanicaPr.Text = mIzlaz1add
        Label14.Text = mIzlaz2

        'Me.tbUpravaPr.Text = mIzlaz1
        'Label14.Text = mIzlaz2

        tbStanicaPr.Focus()

    End Sub

    Private Sub tbBrojOtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.LostFocus
        If tbBrojOtp.Text = Nothing Then
            mOtpBroj = 0
        Else
            mOtpBroj = tbBrojOtp.Text
        End If
    End Sub

    Private Sub DatumOtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.LostFocus
        mOtpDatum = DatumOtp.Text

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'If Microsoft.VisualBasic.Right(mBrojUg, 2) = "22" Or mBrojUg = "993353" Or mBrojUg = "993354" Then
        '    LoadNajavaKontenerskiVoz() 'Proodos 100722, ICF vozovi
        'Else
        '    LoadNajava()
        'End If

        'Me.tbUlaznaNalepnica.Focus()


        ''Dim sql_NajavaVoza As String = ""

        ''If OkpDbVeza.State = ConnectionState.Closed Then
        ''    OkpDbVeza.Open()
        ''End If
        ''sql_NajavaVoza = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano " & _
        ''                        "FROM dbo.NajavaKola INNER JOIN " & _
        ''                        "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
        ''                        "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
        ''                        "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
        ''                        "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano"


        ''Dim sql_comm As New SqlClient.SqlCommand(sql_NajavaVoza, OkpDbVeza)
        ''Dim rdrNajavaVoza As SqlClient.SqlDataReader

        ''tbKolauNajavi.Text = "0" 'Clear()
        ''cbKolaNajava.Items.Clear()

        ''Try
        ''    rdrNajavaVoza = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        ''    Do While rdrNajavaVoza.Read()
        ''        tbKolauNajavi.Text = rdrNajavaVoza.GetInt16(0)
        ''        tbKolaRealizovano.Text = rdrNajavaVoza.GetInt16(1)
        ''    Loop
        ''    rdrNajavaVoza.Close()
        ''    OkpDbVeza.Close()
        ''    Me.Button6.Focus()
        ''Catch ex As Exception
        ''    MsgBox(ex)
        ''End Try


    End Sub

    Private Sub UnosTrz_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnUnosRobe_Click(Me, Nothing)
        ElseIf e.KeyCode = Keys.F11 Then
            Button4_Click(Me, Nothing)
        End If
    End Sub


    Private Sub Button5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.LostFocus
        tbUlaznaNalepnica.Focus()
    End Sub

    Private Sub tbUlaznaNalepnica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUlaznaNalepnica.Validating

        If tbUlaznaNalepnica.Text = Nothing Then
            ErrorProvider1.SetError(tbUlaznaNalepnica, "Unesite broj tranzitne nalepnice")
            tbUlaznaNalepnica.Focus()
        Else
            If IsNumeric(tbUlaznaNalepnica.Text) Then
                If CType(tbUlaznaNalepnica.Text, Int32) = 0 Then
                    ErrorProvider1.SetError(tbUlaznaNalepnica, "Nula - neispravan broj tranzitne nalepnice!")
                    tbUlaznaNalepnica.Focus()
                Else
                    If TipTranzita = "ulaz" Then
                        Dim xNaziv As String = ""
                        Dim xPovVrednost As String = ""

                        Util.sNadjiNalepnicu(tbUlaznaNalepnica.Text, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mObrGodina, mObrMesec, xNaziv, xPovVrednost)

                        If xPovVrednost <> "" Then
                            ErrorProvider1.SetError(tbUlaznaNalepnica, "")
                        Else
                            ErrorProvider1.SetError(tbUlaznaNalepnica, "Nalepnica sa tim brojem je uneta!")
                            tbUlaznaNalepnica.Focus()
                        End If
                    End If
                End If
            Else
                ErrorProvider1.SetError(tbUlaznaNalepnica, "Tekst -neispravan broj tranzitne nalepnice!")
                tbUlaznaNalepnica.Focus()
            End If
        End If
    End Sub

    Private Sub tbBrojOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojOtp.Validating

        If tbBrojOtp.Text = "0" Then
            ErrorProvider1.SetError(tbBrojOtp, "Broj otpravljanja ne moze da bude nula!")
            tbBrojOtp.Focus()
        Else
            If tbBrojOtp.Text = Nothing Then
                ErrorProvider1.SetError(tbBrojOtp, "Neispravan broj otpravljanja!")
                tbBrojOtp.Focus()
            Else
                If IsNumeric(tbBrojOtp.Text) = True Then
                    ErrorProvider1.SetError(tbBrojOtp, "")
                    ''PRIVREMENO STOPIRANO: KontrolaDuplihOtpravljanja()
                    KontrolaDuplihOtpravljanja()
                Else
                    ErrorProvider1.SetError(tbBrojOtp, "Neispravan unos!")
                    tbBrojOtp.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnosNaknade.Click
        Dim GridNaknade As New naknade
        GridNaknade.Show()
    End Sub
    Private Sub tbCarinjenje_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbCarVal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbFaktura_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub FormatErrGrid()
        If err Is Nothing Then
            dgError.DataSource = dtError
        Else
            dgError.DataSource = err.Tables(0)
        End If
    End Sub

    Private Sub dgError_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgError.MouseUp
        Dim hitInfo As System.Windows.Forms.DataGrid.HitTestInfo
        Dim mm As String

        hitInfo = dgError.HitTest(e.X, e.Y)

        'Me.Label2.Text = String.Empty
        'Me.Label3.Text = String.Format("Row: {0}", hitInfo.Row)
        'Me.label4.Text = String.Format("Column: {0}", hitInfo.Column)
        'Me.label5.Text = String.Format("Type: {0}", hitInfo.Type.ToString())

        If hitInfo.Type = System.Windows.Forms.DataGrid.HitTestType.Cell Then
            Dim selCell As Object
            selCell = dgError.Item(hitInfo.Row, hitInfo.Column)
            If Not selCell Is Nothing Then
                mm = selCell.ToString()
            End If
        End If

        '------------- Akcija ----------------
        If mm = "Izlazni granicni prelaz" Then
            cbSmer2.Focus()
        ElseIf mm = "Ulazna tranzitna nalepnica" Then
            Me.tbUlaznaNalepnica.Focus()
        ElseIf mm = "Izlazna tranzitna nalepnica" Then
            Me.tbIzlaznaNalepnica.Focus()
        ElseIf mm = "Tarifski kilometri" Then
            Me.tbKm1.Focus()
        ElseIf mm = "Otpravna uprava - operater" Then
            Me.tbUpravaOtp.Focus()
        ElseIf mm = "Otpravna stanica" Then
            Me.tbStanicaOtp.Focus()
        ElseIf mm = "Broj otpravljanja" Then
            Me.tbBrojOtp.Focus()
        ElseIf mm = "Uputna uprava - operater" Then
            Me.tbUpravaPr.Focus()
        ElseIf mm = "Uputna stanica" Then
            Me.tbStanicaPr.Focus()
        ElseIf mm = "Unos robe" Or mm = "Tara kola" Then
            Dim GridKola As New kola
            GridKola.Show()

        End If
        '-------------------------------------
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace)

    End Sub
    Private Sub cbSmer1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer1.Leave
        If cbSmer1.Text = Nothing Or cbSmer1.Text = cbSmer2.Text Then
            cbSmer1.Focus()
        End If
    End Sub

    Private Sub tbStanicaOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaOtp.Leave
        If Len(tbStanicaOtp.Text) < 7 Then
            ErrorProvider1.SetError(tbStanicaOtp, "Neispravna sifra stanice!")
            tbStanicaOtp.Focus()
        Else
            ErrorProvider1.SetError(tbStanicaOtp, "")
        End If

    End Sub

    Private Sub tbStanicaPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.Leave
        If Len(tbStanicaPr.Text) < 7 Then
            ErrorProvider1.SetError(tbStanicaPr, "Neispravna sifra stanice!")
            tbStanicaPr.Focus()
        Else
            ErrorProvider1.SetError(tbStanicaPr, "")
            Daljinar()
        End If
    End Sub
    Private Sub tbIncoterms_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub fxFranko_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fxFranko.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbFrankoPrelaz_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbFrankoPrelaz.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbFrankoPrevoznina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFrankoPrevoznina.Click

        If cbFrankoPrevoznina.Checked = True Then
            cbIncoterms.Checked = False
            fxFranko.Text = ""
            Me.fxFranko.Enabled = True
            Me.comboIncoterms.SelectedIndex = -1
            Me.comboIncoterms.Text = ""
            Me.comboIncoterms.Enabled = False
            fxFranko.Focus()
        Else
            cbIncoterms.Enabled = True
            Me.fxFranko.Enabled = False
            Me.cbIncoterms.Focus()
        End If
    End Sub

    Private Sub cbIncoterms_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIncoterms.Click
        If cbIncoterms.Checked = True Then
            Me.cbFrankoPrevoznina.Checked = False
            comboIncoterms.Enabled = True
            fxFranko.Text = ""
            Me.fxFranko.Enabled = False
            Me.comboIncoterms.Focus()
        Else
            Me.comboIncoterms.SelectedIndex = -1
            Me.comboIncoterms.Text = ""
            comboIncoterms.Enabled = False
        End If
    End Sub

    Private Sub cbFrankoPrevoznina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbFrankoPrevoznina.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbFrankoPrevoznina_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFrankoPrevoznina.Leave
        Me.btnUnosRobe.Focus()
    End Sub

    Private Sub cbIncoterms_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIncoterms.Leave
        Me.btnUnosRobe.Focus()

    End Sub

    Private Sub cbIncoterms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbIncoterms.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbFrankoPrelaz_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbFrankoPrelaz.Leave
        Me.btnUnosRobe.Focus()

    End Sub
    Private Sub tbIncoterms_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.btnUnosRobe.Focus()
    End Sub
    Private Sub comboIncoterms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles comboIncoterms.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub comboIncoterms_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboIncoterms.Leave
        Me.btnUnosRobe.Focus()

    End Sub
    Private Function GetFirstSqlErrorMsg(ByVal Ex As System.Data.SqlClient.SqlException) As String
        '-- SQLException has an Errors collection (of SQLError objects)
        If Ex.Errors.Count > 0 Then '= 2627 Then
            With Ex.Errors(0)
                '-- Check out the docs for System.Data.SqlClient.SqlError
                Return "SQL Error #" & .Number.ToString & vbCrLf & .Message
                'Return "Greska! Dupli slogovi"
            End With
        End If
    End Function

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "K140"
        helpUic.ShowDialog()

    End Sub

    Private Sub UnosTrz_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If EventsActived = True Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                EventsActived = False
                If upit = "UPR1" Then
                    Dim helpUic As New HelpForm
                    helpUic.Text = "help UIC"
                    upit = "UPR1"
                    helpUic.ShowDialog()
                    Me.tbUpravaOtp.Text = mIzlaz1
                    Me.tbStanicaOtp.Text = mIzlaz1add
                    Label11.Text = mIzlaz2
                    tbStanicaOtp.Focus()
                ElseIf upit = "UPR2" Then
                    Dim helpUic As New HelpForm
                    helpUic.Text = "help UIC"
                    upit = "UPR2"
                    helpUic.ShowDialog()
                    Me.tbUpravaPr.Text = mIzlaz1
                    Me.tbStanicaPr.Text = mIzlaz1add
                    Label14.Text = mIzlaz2
                    tbStanicaPr.Focus()
                ElseIf upit = "UIC" Then
                    Dim helpUic As New HelpForm
                    helpUic.Text = "help UIC"
                    upit = "UIC"
                    helpUic.ShowDialog()

                    Me.tbStanicaOtp.Text = mIzlaz1
                    Label12.Text = mIzlaz2
                    tbBrojOtp.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub btnUpravaOtp_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnUpravaOtp.MouseUp
        If EventsActived = True Then
            EventsActived = False

            Dim helpUic As New HelpForm
            helpUic.Text = "help UIC"
            upit = "UPR1"
            helpUic.ShowDialog()
            Me.tbUpravaOtp.Text = mIzlaz1
            Me.tbStanicaOtp.Text = mIzlaz1add
            Label11.Text = mIzlaz2
            tbStanicaOtp.Focus()
        End If
    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        Dim RMesec As New RacunskiMesec
        RMesec.ShowDialog()
    End Sub

    Private Sub btnUpravaPr_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnUpravaPr.MouseUp
        If EventsActived = True Then
            EventsActived = False
            Dim helpUic As New HelpForm
            helpUic.Text = "help UIC"
            upit = "UPR2"
            helpUic.ShowDialog()
            Me.tbUpravaPr.Text = mIzlaz1
            Me.tbStanicaPr.Text = mIzlaz1add
            Label14.Text = mIzlaz2
            tbStanicaPr.Focus()
        End If
    End Sub

    Private Sub btnUnosRobe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnosRobe.GotFocus
        Me.btnUnosRobe.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnUnosRobe_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnosRobe.Leave
        Me.btnUnosRobe.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnUnosNaknade_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnosNaknade.GotFocus
        Me.btnUnosNaknade.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnUnosNaknade_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnosNaknade.Leave
        Me.btnUnosNaknade.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub btnUpis_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.GotFocus
        Me.btnUpis.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnUpis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.Leave
        Me.btnUpis.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "K165"
        helpUic.ShowDialog()
    End Sub
    Private Sub DatumOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DatumOtp.Validating
        Dim mRetVal As String
        Dim mRecID As Int32
        Dim mStanicaRecID As String

        mOtpDatum = Me.DatumOtp.Value.ToShortDateString
        mMesec = mOtpDatum.Month.ToString
        mDan = mOtpDatum.Day.ToString
        mGodina = mOtpDatum.Year.ToString

        NadjiTL1(tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, mOtpDatum, mRecID, mStanicaRecID, mRetVal)

        If mRetVal = "" Then
            mDatumKalk = mOtpDatum 'DatumOtp.Value
            mOtpDatum = DatumOtp.Text
            tbUpravaPr.Focus()
        Else
            'ako je "Upd" ne treba da javlja poruku o istom kljucu vec samo o ostalima iz baze

            If RecordAction = "N" And UpdUprava = tbUpravaOtp.Text And UpdStanica = tbStanicaOtp.Text And UpdBroj = tbBrojOtp.Text And UpdDatum = mOtpDatum Then
                tbUpravaPr.Focus()
            Else
                MessageBox.Show("Takav broj otpravljanja je vec unet! ", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tbBrojOtp.Focus()
            End If
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If dtKola.Rows.Count > 0 And dtNhm.Rows.Count > 0 Then
            

            mDatumKalk = DatumOtp.Value
            mOtpDatum = DatumOtp.Text

            mPrUprava = Microsoft.VisualBasic.Mid(tbStanicaPr.Text, 1, 2)
            mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)

            If bVrstaSaobracaja = 4 Then
                bVrstaStanice = "M"
            End If

            If mMakis = "ZA" Then
                _PraviPrelaz = mStanica2
                mStanica2 = "16201"
            ElseIf mMakis = "IZ" Then
                _PraviPrelaz = mStanica1
                mStanica1 = "16201"
            End If

            '---------------------------
            UskladiNaknadePoKolima()     'postavi na nulu pa proverava
            '---------------------------
            UskladiNaknadeZaNaftu()      'NOVO 7.6.2011 !!!
            '---------------------------
            bNadjiPrevozninuGlavni()

            If mMakis = "ZA" Then
                mStanica2 = _PraviPrelaz
            ElseIf mMakis = "IZ" Then
                mStanica1 = _PraviPrelaz
            End If
            mPrikazKalkulacije = "D"
            _OpenForm = "Roba"
            Me.UnosTrz_Activated(Me, Nothing)
            btnUpis.Focus()
        Else
            MessageBox.Show("Niste uneli sve podatke o kolima i robi!", "Greska u unosu podataka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MasterAction = "New" Then
            Dim sql_text As String = ""

            mNajava = cbNajava.Text

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            If Microsoft.VisualBasic.Right(mBrojUg, 2) = "22" Or mBrojUg = "993353" Or mBrojUg = "993354" Then
                sql_text = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK " & _
                              "FROM dbo.NajavaVoza INNER JOIN " & _
                              "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
                              "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza INNER JOIN " & _
                              "dbo.NajavaIC ON dbo.NajavaKola.BrUgovora = dbo.NajavaIC.BrUgovora AND dbo.NajavaKola.KomBrojVoza = dbo.NajavaIC.KomBrVoza AND " & _
                              "dbo.NajavaKola.KolaStavka = dbo.NajavaIC.KolaStavka " & _
                              "WHERE (dbo.NajavaKola.Realizovano = '0') AND (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
                              "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK"
            Else
                sql_text = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK " & _
                              "FROM dbo.NajavaVoza INNER JOIN " & _
                              "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
                              "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza INNER JOIN " & _
                              "WHERE (dbo.NajavaKola.Realizovano = '0') AND (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
                              "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK"
            End If

            Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)
            Dim rdrIzNajave As SqlClient.SqlDataReader
            Dim _cbStanica1 As String
            Dim _cbStanica2 As String

            tbKolauNajavi.Clear()
            'cbSmer1.Items.Clear()
            'cbSmer2.Items.Clear()
            cbKolaNajava.Items.Clear()

            Try
                rdrIzNajave = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdrIzNajave.Read()
                    tbKolauNajavi.Text = rdrIzNajave.GetInt16(0)
                    tbKolaRealizovano.Text = rdrIzNajave.GetInt16(1)

                    _cbStanica1 = rdrIzNajave.GetString(2)
                    _cbStanica2 = rdrIzNajave.GetString(3)
                    'cbSmer1.Items.Add(rdrIzNajave.GetString(2))
                    'cbSmer1.Text = rdrIzNajave.GetString(2)
                    'cbSmer2.Items.Add(rdrIzNajave.GetString(3))
                    'cbSmer2.Text = rdrIzNajave.GetString(3)

                    cbKolaNajava.Items.Add(rdrIzNajave.GetString(4))
                Loop
                rdrIzNajave.Close()
                OkpDbVeza.Close()
                cbKolaNajava.Focus()

            Catch ex As Exception
                MsgBox(ex.ToString)

            Finally

            End Try

            rdrIzNajave.Close()
            OkpDbVeza.Close()
            cbKolaNajava.Focus()
        End If

    End Sub

    Private Sub tbPrevoznina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrevoznina.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbNaknade_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNaknade.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub Button6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.GotFocus
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub Button6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Leave
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub UnosTrz_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        ' ne ide na Form1 vec na UpdateForm!

        If RecordAction = "P" Then

            Dim formPreuzmi As New UpdateForm

            formPreuzmi.Text = ":: PREUZIMANJE PODATAKA SA GRANICNOG PRELAZA! ::"
            formPreuzmi.ShowDialog()
        End If

    End Sub

    Private Sub tbPrevoznina_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPrevoznina.LostFocus
        tbNaknade.Focus()

    End Sub

    Private Sub tbNaknade_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNaknade.LostFocus
        tbTL.Text = Val(tbPrevoznina.Text) + Val(tbNaknade.Text)

        'tbTL.Text = Format((Val(tbPrevoznina.Text) + Val(tbNaknade.Text)), "###,###,##0.00")
        tbTL.Focus()

    End Sub

    Private Sub fxPrevoznina_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxPrevoznina.Leave
        fxTL.Text = CDec(fxPrevoznina.Text) + CDec(fxNaknade.Text)
        fxNaknade.Focus()

    End Sub

    Private Sub fxNaknade_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxNaknade.Leave
        fxTL.Text = CDec(fxPrevoznina.Text) + CDec(fxNaknade.Text)
        fxTL.Focus()

    End Sub

    Private Sub fxTL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxTL.Leave

        If mTarifa <> "00" Then
            fxBlagajna.Focus()
        Else
            btnUpis.Focus()
        End If

    End Sub

    Private Sub cbNajava_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbNajava.Validating
        mNajava = cbNajava.Text

        '   1. slucaj: unos novog sloga bez preuzimanja
        If MasterAction = "New" And RecordAction <> "P" Then
            Dim sql_text As String = ""
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            '=========================================================================
            If mRucnaNajava = "D" Then
                tbKolauNajavi.Visible = True
                tbKolaRealizovano.Visible = True
                tbKolauNajavi.Enabled = True
                tbKolaRealizovano.Enabled = True

                tbKolauNajavi.Text = mNajavaKola
                tbKolaRealizovano.Text = mNajavaKolaReal

                Me.tbKolauNajavi.Focus()
            Else
                sql_text = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK " & _
                           "FROM dbo.NajavaVoza INNER JOIN " & _
                           "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
                           "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza " & _
                           "WHERE (dbo.NajavaKola.Realizovano = '0') AND (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
                           "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK"


                Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)
                Dim rdrIzNajave As SqlClient.SqlDataReader
                Dim _cbStanica1 As String
                Dim _cbStanica2 As String


                tbKolauNajavi.Text = "0" 'Clear()
                tbKolaRealizovano.Text = "0"
                cbKolaNajava.Items.Clear()

                Try
                    rdrIzNajave = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                    Do While rdrIzNajave.Read()
                        tbKolauNajavi.Text = rdrIzNajave.GetInt16(0)
                        tbKolaRealizovano.Text = rdrIzNajave.GetInt16(1)

                        ''_cbStanica1 = rdrIzNajave.GetString(2)
                        ''_cbStanica2 = rdrIzNajave.GetString(3)

                        cbKolaNajava.Items.Add(rdrIzNajave.GetString(4))
                    Loop
                    rdrIzNajave.Close()
                    OkpDbVeza.Close()
                    cbKolaNajava.Focus()

                Catch ex As Exception
                    MsgBox(ex)
                End Try

                '--------------------------------------------------------------
                If tbKolauNajavi.Text = "" And tbKolaRealizovano.Text = "" Then
                    MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    If cbNajava.Text = "0" Then
                        Me.btnNadjiNajavu.Focus()
                    Else
                        cbNajava.Focus()
                    End If
                ElseIf tbKolauNajavi.Text = "0" And tbKolaRealizovano.Text = "0" Then
                    MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    If cbNajava.Text = "0" Then
                        Me.btnNadjiNajavu.Focus()
                    Else
                        cbNajava.Focus()
                    End If
                Else
                    If tbKolauNajavi.Text = tbKolaRealizovano.Text Then
                        MessageBox.Show("Najava broj: " & mNajava & " je realizovana. Unesite drugi broj najave. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        tbKolaRealizovano.Text = "0"
                        tbKolauNajavi.Text = "0"
                        cbNajava.Focus()
                    End If
                End If

            End If
            '=============

            'sql_text = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK " & _
            '           "FROM dbo.NajavaVoza INNER JOIN " & _
            '           "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
            '           "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza " & _
            '           "WHERE (dbo.NajavaKola.Realizovano = '0') AND (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
            '           "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK"


            'Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)
            'Dim rdrIzNajave As SqlClient.SqlDataReader
            'Dim _cbStanica1 As String
            'Dim _cbStanica2 As String


            'tbKolauNajavi.Text = "0" 'Clear()
            'tbKolaRealizovano.Text = "0"
            'cbKolaNajava.Items.Clear()

            'Try
            '    rdrIzNajave = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
            '    Do While rdrIzNajave.Read()
            '        tbKolauNajavi.Text = rdrIzNajave.GetInt16(0)
            '        tbKolaRealizovano.Text = rdrIzNajave.GetInt16(1)

            '        ''_cbStanica1 = rdrIzNajave.GetString(2)
            '        ''_cbStanica2 = rdrIzNajave.GetString(3)

            '        cbKolaNajava.Items.Add(rdrIzNajave.GetString(4))
            '    Loop
            '    rdrIzNajave.Close()
            '    OkpDbVeza.Close()
            '    cbKolaNajava.Focus()

            'Catch ex As Exception
            '    MsgBox(ex)
            'End Try

            ''--------------------------------------------------------------
            'If tbKolauNajavi.Text = "" And tbKolaRealizovano.Text = "" Then
            '    MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    If cbNajava.Text = "0" Then
            '        Me.btnNadjiNajavu.Focus()
            '    Else
            '        cbNajava.Focus()
            '    End If
            'ElseIf tbKolauNajavi.Text = "0" And tbKolaRealizovano.Text = "0" Then
            '    MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    If cbNajava.Text = "0" Then
            '        Me.btnNadjiNajavu.Focus()
            '    Else
            '        cbNajava.Focus()
            '    End If
            'Else
            '    If tbKolauNajavi.Text = tbKolaRealizovano.Text Then
            '        MessageBox.Show("Najava broj: " & mNajava & " je realizovana. Unesite drugi broj najave. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        tbKolaRealizovano.Text = "0"
            '        tbKolauNajavi.Text = "0"
            '        cbNajava.Focus()
            '    End If
            'End If
            '---------------------------------------------------------------

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            Dim sql_NajavaInfo As String = ""

            Info_ObrMesec = ""
            Info_ObrIzvos = 0

            ''IZMENA 1.7.2008: dbo.SlogKalk.tlPrevFR > 0 zbog umanjenja za prodosova P kola (-60), to ne racuna u cenu za voz
            'sql_NajavaInfo = "SELECT ObrMesec, MAX(tlPrevFr), SUM(tlPrevFR) " & _
            '                 "FROM dbo.SlogKalk " & _
            '                 "WHERE (dbo.SlogKalk.ObrGodina = '" & mObrGodina & "') AND (dbo.SlogKalk.tlPrevFR > 0 ) AND (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') " & _
            '                 "GROUP BY ObrMesec " & _
            '                 "ORDER BY MAX(tlPrevFr) DESC"

            'novo: 3.4.2013
            sql_NajavaInfo = "SELECT TOP 100 PERCENT MIN(ObrMesec) AS mm, SUM(tlPrevFr) AS ms " & _
                             "FROM dbo.SlogKalk " & _
                             "WHERE (dbo.SlogKalk.ObrGodina = '" & mObrGodina & "') AND (dbo.SlogKalk.tlPrevFR > 0 ) AND (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') "

            Dim sql_commInfo As New SqlClient.SqlCommand(sql_NajavaInfo, OkpDbVeza)
            Dim rdrNajavaInfo As SqlClient.SqlDataReader

            Try
                rdrNajavaInfo = sql_commInfo.ExecuteReader(CommandBehavior.CloseConnection)

                Do While rdrNajavaInfo.Read()
                    'novo 3.4.2013
                    'Info_ObrMesec = rdrNajavaInfo.GetString(0)
                    'Info_ObrIzvos = rdrNajavaInfo.GetDecimal(1)

                    'novo 12.6.2013
                    If IsDBNull(rdrNajavaInfo.GetString(0)) Then
                        Info_ObrMesec = mObrMesec
                    Else
                        Info_ObrMesec = rdrNajavaInfo.GetString(0)
                    End If
                    If IsDBNull(rdrNajavaInfo.GetDecimal(1)) Then
                        Info_ObrIzvos = 0
                    Else
                        Info_ObrIzvos = rdrNajavaInfo.GetDecimal(1)
                    End If

                Loop
                'MsgBox(Info_ObrMesec)
                rdrNajavaInfo.Close()
                OkpDbVeza.Close()

            Catch ex As Exception
                Info_ObrMesec = mObrMesec
                Info_ObrIzvos = 0
                'MsgBox(ex)
            End Try

            'rdrIzNajave.Close()
            OkpDbVeza.Close()
            cbKolaNajava.Focus()
        End If
        '-----------------------------------------------------------------------------------

        '   2. slucaj: izmena postojeceg sloga u bazi
        If MasterAction = "Upd" Then

            If Microsoft.VisualBasic.Mid(mNajava, 1, 1) = "X" Then
                mMakis = "IZ"
            ElseIf Microsoft.VisualBasic.Mid(mNajava, 2, 1) = "X" Then
                mMakis = "ZA"
            Else
                mMakis = "NN"
            End If

            If mMakis = "IZ" Then  ' trazi najavu za voz koji ide iz Makisa

                Dim sql_NajavaVoza As String = ""

                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                End If

                sql_NajavaVoza = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano " & _
                                             "FROM dbo.NajavaKola INNER JOIN " & _
                                             "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                                             "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                                             "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
                                             "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano"

                Dim sql_comm As New SqlClient.SqlCommand(sql_NajavaVoza, OkpDbVeza)
                Dim rdrNajavaVoza As SqlClient.SqlDataReader

                tbKolauNajavi.Text = "0" 'Clear()
                tbKolaRealizovano.Text = "0"

                cbKolaNajava.Items.Clear()
                Try
                    rdrNajavaVoza = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                    Do While rdrNajavaVoza.Read()
                        tbKolauNajavi.Text = rdrNajavaVoza.GetInt16(0)
                        tbKolaRealizovano.Text = rdrNajavaVoza.GetInt16(1)
                    Loop
                    rdrNajavaVoza.Close()
                    OkpDbVeza.Close()
                    If Microsoft.VisualBasic.Mid(cbNajava.Text, 1, 1) = "X" Then
                        tbMakis.Focus()
                    Else
                        Me.Button6.Focus()
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString, "Greska kod preuzimanja najave")
                End Try

                If mRucnaNajava = "D" Then
                    tbKolauNajavi.Visible = True
                    tbKolaRealizovano.Visible = True
                    tbKolauNajavi.Enabled = True
                    tbKolaRealizovano.Enabled = True

                Else

                    '***
                    'proveriti kola u najavi-visible

                    If tbKolauNajavi.Text = "" And tbKolaRealizovano.Text = "" Then
                        MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        If cbNajava.Text = "0" Then
                            Me.btnNadjiNajavu.Focus()
                        Else
                            cbNajava.Focus()
                        End If
                    ElseIf tbKolauNajavi.Text = "0" And tbKolaRealizovano.Text = "0" Then
                        MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        If cbNajava.Text = "0" Then
                            Me.btnNadjiNajavu.Focus()
                        Else
                            cbNajava.Focus()
                        End If
                    Else
                        If tbKolauNajavi.Text = tbKolaRealizovano.Text Then
                            MessageBox.Show("Najava broj: " & mNajava & " je realizovana. Unesite drugi broj najave. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            tbKolaRealizovano.Text = "0"
                            tbKolauNajavi.Text = "0"
                            cbNajava.Focus()
                        End If
                    End If

                End If
            Else
                Me.Button6.Focus()
            End If

        End If


        '  3. slucaj: unos novog sloga sa preuzimanjem
        If MasterAction = "New" And RecordAction = "P" Then

            'TRAŽI NAJAVU U NAJAVAVOZA I VRACA: SUMAKOLA, REALIZOVANO, SUMABRUTOMASA, SUMANETOMASA
            ''''''''' Trebalo bi da trazi u slogkalk koliko kola itd.
            '1. trazi unetu najavu voza
            '
            Dim sql_NajavaVoza As String = ""
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            sql_NajavaVoza = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaKola.IBK " & _
                             "FROM dbo.NajavaKola INNER JOIN " & _
                             "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                             "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                             "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "')"

            Dim sql_comm As New SqlClient.SqlCommand(sql_NajavaVoza, OkpDbVeza)
            Dim rdrNajavaVoza As SqlClient.SqlDataReader

            tbKolauNajavi.Text = "0" 'Clear()
            cbKolaNajava.Items.Clear()

            Try
                rdrNajavaVoza = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdrNajavaVoza.Read()
                    tbKolauNajavi.Text = rdrNajavaVoza.GetInt16(0)
                    tbKolaRealizovano.Text = rdrNajavaVoza.GetInt16(1)

                    If mVrstaPrevoza <> "P" And mVrstaObracuna = "CO" Then
                        If mIBK = rdrNajavaVoza.GetString(2) Then
                            ctrlKolaIzNajave = "Ok"
                            Exit Do
                        End If
                    Else
                        ctrlKolaIzNajave = "Ok"
                    End If
                Loop
                rdrNajavaVoza.Close()
                OkpDbVeza.Close()
                Me.Button6.Focus()
            Catch ex As Exception
                MsgBox(ex)
            End Try

            '-------------------- Obracunski mesec u kome je fakturisan iznos  ----------------
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            Dim sql_NajavaInfo As String = ""

            Info_ObrMesec = ""
            Info_ObrIzvos = 0

            ''IZMENA 1.7.2008: dbo.SlogKalk.tlPrevFR > 0 zbog umanjenja za prodosova P kola (-60), to ne racuna u cenu za voz
            'sql_NajavaInfo = "SELECT ObrMesec, MAX(tlPrevFr), SUM(tlPrevFR) " & _
            '                 "FROM dbo.SlogKalk " & _
            '                 "WHERE (dbo.SlogKalk.ObrGodina = '" & mObrGodina & "') AND (dbo.SlogKalk.tlPrevFR > 0 ) AND (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') " & _
            '                 "GROUP BY ObrMesec " & _
            '                 "ORDER BY MAX(tlPrevFr) DESC"

            'novo: 3.4.2013
            sql_NajavaInfo = "SELECT TOP 100 PERCENT MIN(ObrMesec) AS mm, SUM(tlPrevFr) AS ms " & _
                             "FROM dbo.SlogKalk " & _
                             "WHERE (dbo.SlogKalk.ObrGodina = '" & mObrGodina & "') AND (dbo.SlogKalk.tlPrevFR > 0 ) AND (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') "

            Dim sql_commInfo As New SqlClient.SqlCommand(sql_NajavaInfo, OkpDbVeza)
            Dim rdrNajavaInfo As SqlClient.SqlDataReader

            Try
                rdrNajavaInfo = sql_commInfo.ExecuteReader(CommandBehavior.CloseConnection)

                Do While rdrNajavaInfo.Read()
                    'novo 3.4.2013
                    If IsDBNull(rdrNajavaInfo.GetString(0)) Then
                        Info_ObrMesec = mObrMesec
                    Else
                        Info_ObrMesec = rdrNajavaInfo.GetString(0)
                    End If
                    If IsDBNull(rdrNajavaInfo.GetDecimal(1)) Then
                        Info_ObrIzvos = 0
                    Else
                        Info_ObrIzvos = rdrNajavaInfo.GetDecimal(1)
                    End If

                    'Info_ObrMesec = rdrNajavaInfo.GetString(0)
                    'Info_ObrIzvos = rdrNajavaInfo.GetDecimal(1)

                    'Info_ObrMesec = rdrNajavaInfo.GetString(0)
                    'Info_ObrIzvos = rdrNajavaInfo.GetDecimal(2)
                Loop
                'MsgBox(Info_ObrMesec)
                rdrNajavaInfo.Close()
                OkpDbVeza.Close()

            Catch ex As Exception
                'MsgBox(ex.ToString)
                Info_ObrIzvos = 0
            End Try

            '------------------------------------
            If mRucnaNajava = "D" Then
                'If tbKolauNajavi.Text = tbKolaRealizovano.Text And (tbKolauNajavi.Text <> "0" And tbKolaRealizovano.Text <> "0") Then
                '    MessageBox.Show("Najava broj: " & mNajava & " je realizovana. Unesite drugi broj najave. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    tbKolaRealizovano.Text = "0"
                '    tbKolauNajavi.Text = "0"
                '    cbNajava.Focus()
                'Else
                tbKolauNajavi.Visible = True
                tbKolaRealizovano.Visible = True
                tbKolauNajavi.Enabled = True
                tbKolaRealizovano.Enabled = True

                tbKolauNajavi.Text = mNajavaKola
                tbKolaRealizovano.Text = mNajavaKolaReal

                Me.tbKolauNajavi.Focus()
                'End If

            Else
                'test
                tbKolauNajavi.Visible = True
                tbKolaRealizovano.Visible = True
                tbKolauNajavi.Enabled = True
                tbKolaRealizovano.Enabled = True
                'end test
                If tbKolauNajavi.Text = "" And tbKolaRealizovano.Text = "" Then
                    MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    If cbNajava.Text = "0" Then
                        Me.btnNadjiNajavu.Focus()
                    Else
                        cbNajava.Focus()
                    End If
                ElseIf tbKolauNajavi.Text = "0" And tbKolaRealizovano.Text = "0" Then
                    MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    If cbNajava.Text = "0" Then
                        Me.btnNadjiNajavu.Focus()
                    Else
                        cbNajava.Focus()
                    End If
                Else
                    If tbKolauNajavi.Text = tbKolaRealizovano.Text Then
                        'ako je kont.voz sa 2 uti na 1 kolima
                        If Microsoft.VisualBasic.Right(mBrojUg, 4) <> "1133" Then
                            MessageBox.Show("Najava broj: " & mNajava & " je realizovana. Unesite drugi broj najave. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            tbKolaRealizovano.Text = "0"
                            tbKolauNajavi.Text = "0"
                            cbNajava.Focus()
                        End If

                        'MessageBox.Show("Najava broj: " & mNajava & " je realizovana. Unesite drugi broj najave. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'tbKolaRealizovano.Text = "0"
                        'tbKolauNajavi.Text = "0"
                        'cbNajava.Focus()

                    End If
                End If
                If ctrlKolaIzNajave = "No" Then
                    MessageBox.Show("Kola   : " & mIBK & "  ne postoje u spisku najavljenih kola. Ispravite individualni broj kola.", "Neispravan broj kola", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btnUnosRobe_Click(Me, Nothing)

                End If
            End If
        End If

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub btnNadjiNajavu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNadjiNajavu.Click

        Dim sql_text As String = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        If mVrstaPrevoza <> "P" And RecordAction = "P" Then  'voz/grupa, preuzimanje sa granice
            sql_text = "SELECT   TOP 1 KomBrojVoza " & _
                             "FROM dbo.NajavaKola " & _
                             "WHERE (dbo.NajavaKola.Realizovano = '0') AND (dbo.NajavaKola.IBK = '" & mIBK & "')  " & _
                             "ORDER BY KomBrojVoza"

        End If

        Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)
        Dim rdrIzNajave As SqlClient.SqlDataReader

        Try
            rdrIzNajave = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrIzNajave.Read()
                cbNajava.Text = rdrIzNajave.GetString(0)
            Loop
            If Microsoft.VisualBasic.Mid(cbNajava.Text, 1, 1) = "X" Then
                mMakis = "IZ"
            ElseIf Microsoft.VisualBasic.Mid(cbNajava.Text, 2, 1) = "X" Then
                mMakis = "ZA"
            Else
                mMakis = "NN"
            End If

            rdrIzNajave.Close()
            OkpDbVeza.Close()

            cbNajava.Focus()

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub tbMakis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbMakis.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbMakis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMakis.Leave
        Button6.Focus()

    End Sub

    Private Sub tbKolauNajavi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbKolauNajavi.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbKolaRealizovano_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbKolaRealizovano.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbKolaRealizovano_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbKolaRealizovano.Leave
        Button6.Focus()

    End Sub

    Private Sub dgError_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgError.MouseDown
        dgError.Visible = False
    End Sub

    Private Sub fxBlagajna_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxBlagajna.Leave
        fxRazlika.Text = CDec(fxBlagajna.Text) - CDec(fxTL.Text)
        fxRazlika.Focus()

    End Sub

    Private Sub fxRazlika_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fxRazlika.Leave
        btnUpis.Focus()

    End Sub

    Private Sub cbNajava_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNajava.GotFocus
        tbKolauNajavi.Text = "0"
        tbKolaRealizovano.Text = "0"
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim sql_NajavaInfo As String = ""
        Dim Info_ObrMesec As String = ""
        Dim Info_ObrIzvos As Decimal = 0

        ''sql_NajavaInfo = "SELECT dbo.SlogKalk.ObrMesec, MAX(dbo.SlogKalk.tlPrevFr) " & _
        ''                        "FROM dbo.SlogKalk " & _
        ''                        "WHERE (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') " & _
        ''                        "GROUP BY dbo.SlogKalk.ObrMesec"
        sql_NajavaInfo = "SELECT dbo.SlogKalk.ObrMesec, dbo.SlogKalk.tlPrevFr " & _
                                "FROM dbo.SlogKalk " & _
                                "WHERE (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') " & _
                                "ORDER BY dbo.SlogKalk.tlPrevFr"

        Dim sql_commInfo As New SqlClient.SqlCommand(sql_NajavaInfo, OkpDbVeza)
        Dim rdrNajavaInfo As SqlClient.SqlDataReader

        Try
            rdrNajavaInfo = sql_commInfo.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrNajavaInfo.Read()
                Info_ObrMesec = rdrNajavaInfo.GetString(0)
                Info_ObrIzvos = rdrNajavaInfo.GetDecimal(1)

            Loop

            rdrNajavaInfo.Close()
            OkpDbVeza.Close()

        Catch ex As Exception
            MsgBox(ex)
        End Try


    End Sub
    Private Sub KontrolaDuplihOtpravljanja()
        Dim mRetVal As String
        Dim mRecID As Int32
        Dim mStanicaRecID As String
        Dim Msg As String
        Dim mObrGodinaIzBaze As String = ""


        NadjiDuplaOtp(tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, mRecID, mStanicaRecID, mObrGodinaIzBaze, mRetVal)

        ' NadjiDuplaOtp(tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, mRecID, mStanicaRecID, mRetVal)


        If mRetVal = "" Then
            mDatumKalk = mOtpDatum 'DatumOtp.Value
            mOtpDatum = DatumOtp.Text
            DatumOtp.Focus()
        Else
            'ako je "Upd" ne treba da javlja poruku o istom kljucu vec samo o ostalima iz baze
            'novi podatak

            If RecordAction = "N" And UpdUprava = tbUpravaOtp.Text And UpdStanica = tbStanicaOtp.Text And UpdBroj = tbBrojOtp.Text And UpdDatum = mOtpDatum Then
                'izmena u bazi
                tbUpravaPr.Focus()
            Else

                If RecordAction = "P" And mRetVal <> "" Then                 'preuzimanje
                    'tbUpravaPr.Focus()

                    If mObrGodina = mObrGodinaIzBaze Then
                        Msg = "Takav broj otpravljanja vec postoji u bazi podataka! " & Chr(13)
                        Msg = Msg & "[Ista sifra uprave, stanice i broja otpravljanja; razlika u datumu otpravljanja ]" & Chr(13)
                        Msg = Msg & "Pre daljeg rada, proverite da li je potrebno da unosite takav dokument u bazu!" & Chr(13)
                        MsgBox(Msg, MsgBoxStyle.Question, "Upozorenje iz baze")

                    Else
                        tbUpravaPr.Focus()
                    End If

                    'Msg = "Takav broj otpravljanja vec postoji u bazi podataka! " & Chr(13)
                    'Msg = Msg & "Pre daljeg rada, proverite da li je potrebno da unosite takav dokument u bazu!" & Chr(13)
                    'MsgBox(Msg, MsgBoxStyle.Question, "Upozorenje iz baze")

                Else                                                       'izmena u bazi 
                    tbUpravaPr.Focus()

                    'Msg = "Takav broj otpravljanja vec postoji u bazi podataka! " & Chr(13)
                    'Msg = Msg & "Pre daljeg rada, proverite da li je potrebno da unosite takav dokument u bazu!" & Chr(13)
                    'MsgBox(Msg, MsgBoxStyle.Question, "Upozorenje iz baze")
                End If
            End If

            'If RecordAction = "N" And UpdUprava = tbUpravaOtp.Text And UpdStanica = tbStanicaOtp.Text And UpdBroj = tbBrojOtp.Text And UpdDatum = mOtpDatum Then
            '    tbUpravaPr.Focus()
            'Else
            '    If RecordAction = "P" And mRecID > 0 Then
            '        Msg = "Takav broj otpravljanja vec postoji u bazi podataka! " & Chr(13)
            '        Msg = Msg & "Pre daljeg rada, proverite da li je potrebno da unosite takav dokument u bazu!" & Chr(13)
            '        MsgBox(Msg, MsgBoxStyle.Question, "Upozorenje iz baze")
            '    Else
            '        tbUpravaPr.Focus()
            '    End If
            'End If
        End If

    End Sub

    Private Sub cbRIV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
