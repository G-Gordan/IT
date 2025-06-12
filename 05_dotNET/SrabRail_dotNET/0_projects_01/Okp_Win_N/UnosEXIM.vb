Imports System.Data.SqlClient

Public Class UnosExIm

    Inherits System.Windows.Forms.Form
    Public mBrojPokusaja As Int16 = 1
    Public _frK115 As Decimal = 0
    Public _frK115_2 As Decimal = 0
    Public Zs_Franko As Decimal = 0
    Public tmp_MMStanica As String
    Public SledeciCimIsteNajave As Boolean = False
    Public m_UpdateAllowed As String = "No"
    ''Public mNastavljaNajavu As Boolean = True


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
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
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
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents btnNajava As System.Windows.Forms.Button
    Friend WithEvents ToolBar2 As System.Windows.Forms.ToolBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbKolaNajava As System.Windows.Forms.ComboBox
    Friend WithEvents cbSmer1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbSmer2 As System.Windows.Forms.ComboBox
    Friend WithEvents tbKm2 As System.Windows.Forms.TextBox
    Friend WithEvents tbKm1 As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label5 As System.Windows.Forms.Label

    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents DatumOtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnUpis As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbRazlika As System.Windows.Forms.TextBox
    Friend WithEvents tbTL As System.Windows.Forms.TextBox
    Friend WithEvents tbPrevoznina As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbValuta As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents dgFinalNak As System.Windows.Forms.DataGrid
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tbNaknade As System.Windows.Forms.TextBox
    Friend WithEvents btnUnosNaknade As System.Windows.Forms.Button
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents dgError As System.Windows.Forms.DataGrid
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnIzjava As System.Windows.Forms.Button
    Friend WithEvents tbFrankoPrelaz As System.Windows.Forms.TextBox
    Friend WithEvents fxFranko As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents cbFrankoPrevoznina As System.Windows.Forms.CheckBox
    Friend WithEvents cbIncoterms As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cbPouzece As System.Windows.Forms.ComboBox
    Friend WithEvents cbIsporuka As System.Windows.Forms.ComboBox
    Friend WithEvents cbVrednost As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents fxIsporuka As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxPouzece As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbPlatilacNFR As System.Windows.Forms.TextBox
    Friend WithEvents tbPrimalac As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbPlatilacFRR As System.Windows.Forms.TextBox
    Friend WithEvents tbPosiljalac As System.Windows.Forms.TextBox
    Friend WithEvents fxVrednostRobe As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents comboIncoterms As System.Windows.Forms.ComboBox
    Friend WithEvents gbKolauVozu As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents tbKolauVozu As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents tbBlagajna As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents gb_Info As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_smasa As System.Windows.Forms.Label
    Friend WithEvents lbl_nhm As System.Windows.Forms.Label
    Friend WithEvents lbl_tara As System.Windows.Forms.Label
    Friend WithEvents lbl_ibk As System.Windows.Forms.Label
    Friend WithEvents L_SMasa As System.Windows.Forms.Label
    Friend WithEvents L_NHM As System.Windows.Forms.Label
    Friend WithEvents L_Tara As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnUic As System.Windows.Forms.Button
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNadjiNajavu As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cbVrstaSaobracaja As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cmbPrevPut As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbManipulativnaMestaIm As System.Windows.Forms.ComboBox
    Friend WithEvents cmbManipulativnaMestaEx As System.Windows.Forms.ComboBox
    Friend WithEvents cbNajava As System.Windows.Forms.ComboBox
    Friend WithEvents tbKolauNajavi As System.Windows.Forms.TextBox
    Friend WithEvents tbKolaRealizovano As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbFrankRacun As System.Windows.Forms.CheckBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents tbPrev1 As System.Windows.Forms.TextBox
    Friend WithEvents tbPrev2 As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents tbStanicaLom As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents tbBlagajnaK115 As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents lblTEA As System.Windows.Forms.Label
    Friend WithEvents tbTEA As System.Windows.Forms.TextBox
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents cmbFDP As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblEvraPoKolima As System.Windows.Forms.Label
    Friend WithEvents lbl_PkolaProdos As System.Windows.Forms.Label
    Friend WithEvents lbl_TipUti As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents cbRIV As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UnosExIm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbManipulativnaMestaEx = New System.Windows.Forms.ComboBox
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
        Me.cmbManipulativnaMestaIm = New System.Windows.Forms.ComboBox
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
        Me.Label52 = New System.Windows.Forms.Label
        Me.tbStanicaLom = New System.Windows.Forms.TextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.tbKm2 = New System.Windows.Forms.TextBox
        Me.tbKm1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cbZsPrevozniPut = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnUnosRobe = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.tbIzlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbUlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.Button9 = New System.Windows.Forms.Button
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.cbSmer1 = New System.Windows.Forms.ComboBox
        Me.btnNajava = New System.Windows.Forms.Button
        Me.ToolBar2 = New System.Windows.Forms.ToolBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbKolaNajava = New System.Windows.Forms.ComboBox
        Me.cbSmer2 = New System.Windows.Forms.ComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rb1 = New System.Windows.Forms.RadioButton
        Me.rb2 = New System.Windows.Forms.RadioButton
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.btnUpis = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tbTEA = New System.Windows.Forms.TextBox
        Me.lblTEA = New System.Windows.Forms.Label
        Me.Button16 = New System.Windows.Forms.Button
        Me.Button15 = New System.Windows.Forms.Button
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.tbBlagajnaK115 = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.tbPrev2 = New System.Windows.Forms.TextBox
        Me.tbPrev1 = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.tbBlagajna = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.tbNaknade = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.tbRazlika = New System.Windows.Forms.TextBox
        Me.tbTL = New System.Windows.Forms.TextBox
        Me.tbPrevoznina = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbValuta = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.dgFinalNak = New System.Windows.Forms.DataGrid
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.btnUic = New System.Windows.Forms.Button
        Me.btnUnosNaknade = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.dgError = New System.Windows.Forms.DataGrid
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.cbFrankRacun = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.fxFranko = New FlxMaskBox.FlexMaskEditBox
        Me.comboIncoterms = New System.Windows.Forms.ComboBox
        Me.cbIncoterms = New System.Windows.Forms.CheckBox
        Me.cbFrankoPrevoznina = New System.Windows.Forms.CheckBox
        Me.btnIzjava = New System.Windows.Forms.Button
        Me.tbFrankoPrelaz = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.cmbFDP = New System.Windows.Forms.ComboBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.fxPouzece = New FlxMaskBox.FlexMaskEditBox
        Me.fxIsporuka = New FlxMaskBox.FlexMaskEditBox
        Me.fxVrednostRobe = New FlxMaskBox.FlexMaskEditBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.cbPouzece = New System.Windows.Forms.ComboBox
        Me.cbIsporuka = New System.Windows.Forms.ComboBox
        Me.cbVrednost = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.tbPlatilacNFR = New System.Windows.Forms.TextBox
        Me.tbPrimalac = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Button17 = New System.Windows.Forms.Button
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.Button18 = New System.Windows.Forms.Button
        Me.tbPlatilacFRR = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.tbPosiljalac = New System.Windows.Forms.TextBox
        Me.gbKolauVozu = New System.Windows.Forms.GroupBox
        Me.tbKolauVozu = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Button14 = New System.Windows.Forms.Button
        Me.gb_Info = New System.Windows.Forms.GroupBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.lbl_TipUti = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.lbl_PkolaProdos = New System.Windows.Forms.Label
        Me.lblEvraPoKolima = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lbl_ibk = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.lbl_smasa = New System.Windows.Forms.Label
        Me.lbl_nhm = New System.Windows.Forms.Label
        Me.lbl_tara = New System.Windows.Forms.Label
        Me.L_SMasa = New System.Windows.Forms.Label
        Me.L_NHM = New System.Windows.Forms.Label
        Me.L_Tara = New System.Windows.Forms.Label
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.btnNadjiNajavu = New System.Windows.Forms.Button
        Me.tbKolaRealizovano = New System.Windows.Forms.TextBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.cbNajava = New System.Windows.Forms.ComboBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Button10 = New System.Windows.Forms.Button
        Me.Label41 = New System.Windows.Forms.Label
        Me.tbKolauNajavi = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.cmbPrevPut = New System.Windows.Forms.ComboBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.GroupBox16 = New System.Windows.Forms.GroupBox
        Me.cbVrstaSaobracaja = New System.Windows.Forms.ComboBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Button19 = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbRIV = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        CType(Me.dgFinalNak, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.gbKolauVozu.SuspendLayout()
        Me.gb_Info.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbManipulativnaMestaEx)
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
        Me.GroupBox1.Location = New System.Drawing.Point(10, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 229)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ OTPRAVLJANJE ] "
        '
        'cmbManipulativnaMestaEx
        '
        Me.cmbManipulativnaMestaEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbManipulativnaMestaEx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbManipulativnaMestaEx.Location = New System.Drawing.Point(13, 107)
        Me.cmbManipulativnaMestaEx.Name = "cmbManipulativnaMestaEx"
        Me.cmbManipulativnaMestaEx.Size = New System.Drawing.Size(192, 21)
        Me.cmbManipulativnaMestaEx.TabIndex = 19
        Me.cmbManipulativnaMestaEx.Visible = False
        '
        'Label18
        '
        Me.Label18.Enabled = False
        Me.Label18.Location = New System.Drawing.Point(10, 175)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 23)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Datum"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Location = New System.Drawing.Point(10, 147)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 16)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Broj"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(12, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(192, 15)
        Me.Label12.TabIndex = 8
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(16, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(176, 15)
        Me.Label11.TabIndex = 36
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnStanicaOtp
        '
        Me.btnStanicaOtp.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnStanicaOtp.Location = New System.Drawing.Point(12, 67)
        Me.btnStanicaOtp.Name = "btnStanicaOtp"
        Me.btnStanicaOtp.Size = New System.Drawing.Size(75, 24)
        Me.btnStanicaOtp.TabIndex = 7
        Me.btnStanicaOtp.Text = "Stanica"
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojOtp.Location = New System.Drawing.Point(105, 139)
        Me.tbBrojOtp.MaxLength = 6
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.TabIndex = 2
        Me.tbBrojOtp.Text = "0"
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaOtp.Location = New System.Drawing.Point(105, 67)
        Me.tbStanicaOtp.MaxLength = 7
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.TabIndex = 1
        Me.tbStanicaOtp.Text = ""
        '
        'tbUpravaOtp
        '
        Me.tbUpravaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUpravaOtp.Location = New System.Drawing.Point(105, 19)
        Me.tbUpravaOtp.MaxLength = 4
        Me.tbUpravaOtp.Name = "tbUpravaOtp"
        Me.tbUpravaOtp.TabIndex = 0
        Me.tbUpravaOtp.Text = ""
        '
        'btnUpravaOtp
        '
        Me.btnUpravaOtp.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnUpravaOtp.Location = New System.Drawing.Point(12, 19)
        Me.btnUpravaOtp.Name = "btnUpravaOtp"
        Me.btnUpravaOtp.Size = New System.Drawing.Size(75, 24)
        Me.btnUpravaOtp.TabIndex = 6
        Me.btnUpravaOtp.Text = "Operater"
        '
        'DatumOtp
        '
        Me.DatumOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOtp.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOtp.Location = New System.Drawing.Point(104, 179)
        Me.DatumOtp.Name = "DatumOtp"
        Me.DatumOtp.Size = New System.Drawing.Size(104, 23)
        Me.DatumOtp.TabIndex = 3
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbManipulativnaMestaIm)
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
        Me.GroupBox5.Location = New System.Drawing.Point(234, 98)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(216, 229)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = " [ PRISPECE ] "
        '
        'cmbManipulativnaMestaIm
        '
        Me.cmbManipulativnaMestaIm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbManipulativnaMestaIm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbManipulativnaMestaIm.Location = New System.Drawing.Point(8, 109)
        Me.cmbManipulativnaMestaIm.Name = "cmbManipulativnaMestaIm"
        Me.cmbManipulativnaMestaIm.Size = New System.Drawing.Size(192, 21)
        Me.cmbManipulativnaMestaIm.TabIndex = 19
        Me.cmbManipulativnaMestaIm.Visible = False
        '
        'Label17
        '
        Me.Label17.Enabled = False
        Me.Label17.Location = New System.Drawing.Point(10, 187)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 13)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "Datum izlaza"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label15
        '
        Me.Label15.Enabled = False
        Me.Label15.Location = New System.Drawing.Point(10, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 16)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Broj"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(96, 179)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(104, 23)
        Me.DateTimePicker2.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(8, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(192, 15)
        Me.Label13.TabIndex = 39
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(8, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(176, 15)
        Me.Label14.TabIndex = 38
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnStanicaPr
        '
        Me.btnStanicaPr.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnStanicaPr.Location = New System.Drawing.Point(8, 69)
        Me.btnStanicaPr.Name = "btnStanicaPr"
        Me.btnStanicaPr.Size = New System.Drawing.Size(75, 24)
        Me.btnStanicaPr.TabIndex = 33
        Me.btnStanicaPr.Text = "Stanica"
        '
        'tbBrojPr
        '
        Me.tbBrojPr.Enabled = False
        Me.tbBrojPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojPr.Location = New System.Drawing.Point(100, 141)
        Me.tbBrojPr.MaxLength = 6
        Me.tbBrojPr.Name = "tbBrojPr"
        Me.tbBrojPr.TabIndex = 2
        Me.tbBrojPr.Text = "0"
        '
        'tbStanicaPr
        '
        Me.tbStanicaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaPr.Location = New System.Drawing.Point(100, 69)
        Me.tbStanicaPr.MaxLength = 7
        Me.tbStanicaPr.Name = "tbStanicaPr"
        Me.tbStanicaPr.TabIndex = 1
        Me.tbStanicaPr.Text = ""
        '
        'tbUpravaPr
        '
        Me.tbUpravaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUpravaPr.Location = New System.Drawing.Point(100, 21)
        Me.tbUpravaPr.MaxLength = 4
        Me.tbUpravaPr.Name = "tbUpravaPr"
        Me.tbUpravaPr.TabIndex = 0
        Me.tbUpravaPr.Text = ""
        '
        'btnUpravaPr
        '
        Me.btnUpravaPr.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnUpravaPr.Location = New System.Drawing.Point(8, 21)
        Me.btnUpravaPr.Name = "btnUpravaPr"
        Me.btnUpravaPr.Size = New System.Drawing.Size(75, 24)
        Me.btnUpravaPr.TabIndex = 32
        Me.btnUpravaPr.Text = "Operater"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label52)
        Me.GroupBox2.Controls.Add(Me.tbStanicaLom)
        Me.GroupBox2.Controls.Add(Me.Label51)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.tbKm2)
        Me.GroupBox2.Controls.Add(Me.tbKm1)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cbZsPrevozniPut)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(456, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 118)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ PREVOZNI PUT ŽS ]"
        '
        'Label52
        '
        Me.Label52.Enabled = False
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Gray
        Me.Label52.Location = New System.Drawing.Point(179, 56)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(128, 16)
        Me.Label52.TabIndex = 47
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbStanicaLom
        '
        Me.tbStanicaLom.Enabled = False
        Me.tbStanicaLom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaLom.Location = New System.Drawing.Point(104, 52)
        Me.tbStanicaLom.MaxLength = 5
        Me.tbStanicaLom.Name = "tbStanicaLom"
        Me.tbStanicaLom.Size = New System.Drawing.Size(72, 22)
        Me.tbStanicaLom.TabIndex = 46
        Me.tbStanicaLom.Text = ""
        '
        'Label51
        '
        Me.Label51.Enabled = False
        Me.Label51.Location = New System.Drawing.Point(11, 57)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(80, 16)
        Me.Label51.TabIndex = 45
        Me.Label51.Text = "Preko stanice"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Location = New System.Drawing.Point(8, 83)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 21)
        Me.Button2.TabIndex = 44
        Me.Button2.Text = "Kilometri"
        Me.ToolTip1.SetToolTip(Me.Button2, "Izracunati kilometri po daljinaru")
        '
        'tbKm2
        '
        Me.tbKm2.Enabled = False
        Me.tbKm2.Location = New System.Drawing.Point(199, 83)
        Me.tbKm2.Name = "tbKm2"
        Me.tbKm2.Size = New System.Drawing.Size(73, 21)
        Me.tbKm2.TabIndex = 5
        Me.tbKm2.Text = ""
        '
        'tbKm1
        '
        Me.tbKm1.Location = New System.Drawing.Point(104, 83)
        Me.tbKm1.Name = "tbKm1"
        Me.tbKm1.Size = New System.Drawing.Size(73, 21)
        Me.tbKm1.TabIndex = 4
        Me.tbKm1.Text = ""
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(275, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 23)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "vpp"
        Me.ToolTip1.SetToolTip(Me.Button1, "Izbor vanrednog prevozni puta iz baze")
        Me.Button1.Visible = False
        '
        'cbZsPrevozniPut
        '
        Me.cbZsPrevozniPut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbZsPrevozniPut.Items.AddRange(New Object() {"1 - Redovan", "2 - Vanredan", "3 - Lomljen redovan", "4 - Lomljen vanredan"})
        Me.cbZsPrevozniPut.Location = New System.Drawing.Point(104, 22)
        Me.cbZsPrevozniPut.Name = "cbZsPrevozniPut"
        Me.cbZsPrevozniPut.Size = New System.Drawing.Size(168, 23)
        Me.cbZsPrevozniPut.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Prevozni put"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnUnosRobe
        '
        Me.btnUnosRobe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnosRobe.Image = CType(resources.GetObject("btnUnosRobe.Image"), System.Drawing.Image)
        Me.btnUnosRobe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUnosRobe.Location = New System.Drawing.Point(8, 10)
        Me.btnUnosRobe.Name = "btnUnosRobe"
        Me.btnUnosRobe.Size = New System.Drawing.Size(96, 65)
        Me.btnUnosRobe.TabIndex = 0
        Me.btnUnosRobe.Text = "Unos robe [ F12 ]"
        Me.btnUnosRobe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Button4)
        Me.GroupBox7.Controls.Add(Me.tbIzlaznaNalepnica)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.tbUlaznaNalepnica)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(816, 8)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(32, 40)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = " [ TRANZITNE NALEPNICE ]"
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button4.Location = New System.Drawing.Point(398, 21)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(22, 20)
        Me.Button4.TabIndex = 41
        Me.Button4.Text = "..."
        '
        'tbIzlaznaNalepnica
        '
        Me.tbIzlaznaNalepnica.Location = New System.Drawing.Point(232, 55)
        Me.tbIzlaznaNalepnica.MaxLength = 5
        Me.tbIzlaznaNalepnica.Name = "tbIzlaznaNalepnica"
        Me.tbIzlaznaNalepnica.Size = New System.Drawing.Size(152, 21)
        Me.tbIzlaznaNalepnica.TabIndex = 1
        Me.tbIzlaznaNalepnica.Text = ""
        Me.tbIzlaznaNalepnica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(19, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 23)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Izlazna tranzitna nalepnica"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbUlaznaNalepnica
        '
        Me.tbUlaznaNalepnica.BackColor = System.Drawing.Color.Yellow
        Me.tbUlaznaNalepnica.Location = New System.Drawing.Point(232, 21)
        Me.tbUlaznaNalepnica.MaxLength = 5
        Me.tbUlaznaNalepnica.Name = "tbUlaznaNalepnica"
        Me.tbUlaznaNalepnica.Size = New System.Drawing.Size(152, 21)
        Me.tbUlaznaNalepnica.TabIndex = 0
        Me.tbUlaznaNalepnica.Text = ""
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
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button6.Location = New System.Drawing.Point(768, 8)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(16, 16)
        Me.Button6.TabIndex = 42
        Me.Button6.Text = "..."
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem9, Me.MenuItem6, Me.MenuItem12})
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
        Me.MenuItem10.Text = "-"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 1
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        Me.MenuItem6.Text = "Pregled"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "-"
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
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(218, 78)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(96, 65)
        Me.Button9.TabIndex = 5
        Me.Button9.Text = "Otkaži"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolBar1
        '
        Me.ToolBar1.AutoSize = False
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(1008, 96)
        Me.ToolBar1.TabIndex = 39
        '
        'cbSmer1
        '
        Me.cbSmer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer1.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer1.Location = New System.Drawing.Point(6, 25)
        Me.cbSmer1.Name = "cbSmer1"
        Me.cbSmer1.Size = New System.Drawing.Size(200, 24)
        Me.cbSmer1.TabIndex = 1
        '
        'btnNajava
        '
        Me.btnNajava.Location = New System.Drawing.Point(712, 40)
        Me.btnNajava.Name = "btnNajava"
        Me.btnNajava.Size = New System.Drawing.Size(48, 20)
        Me.btnNajava.TabIndex = 43
        Me.btnNajava.Text = "Najava"
        Me.btnNajava.Visible = False
        '
        'ToolBar2
        '
        Me.ToolBar2.DropDownArrows = True
        Me.ToolBar2.Location = New System.Drawing.Point(0, 96)
        Me.ToolBar2.Name = "ToolBar2"
        Me.ToolBar2.ShowToolTips = True
        Me.ToolBar2.Size = New System.Drawing.Size(1008, 42)
        Me.ToolBar2.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(80, -8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 23)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Izbor kola iz najave"
        Me.Label2.Visible = False
        '
        'cbKolaNajava
        '
        Me.cbKolaNajava.Location = New System.Drawing.Point(96, 8)
        Me.cbKolaNajava.MaxLength = 12
        Me.cbKolaNajava.Name = "cbKolaNajava"
        Me.cbKolaNajava.Size = New System.Drawing.Size(48, 21)
        Me.cbKolaNajava.TabIndex = 3
        Me.cbKolaNajava.Visible = False
        '
        'cbSmer2
        '
        Me.cbSmer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer2.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer2.Location = New System.Drawing.Point(6, 60)
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
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(-16, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 23)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Najavljeno / realizovano"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 23)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = " / "
        Me.Label6.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.GroupBox3.Controls.Add(Me.rb1)
        Me.GroupBox3.Controls.Add(Me.rb2)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(221, 88)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " [ Vrsta posiljke ] "
        '
        'rb1
        '
        Me.rb1.Checked = True
        Me.rb1.Location = New System.Drawing.Point(8, 13)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(210, 24)
        Me.rb1.TabIndex = 0
        Me.rb1.TabStop = True
        Me.rb1.Text = "Kola sa pojedinacnim tovarnim listom"
        '
        'rb2
        '
        Me.rb2.Location = New System.Drawing.Point(8, 33)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(211, 24)
        Me.rb2.TabIndex = 1
        Me.rb2.Text = "Više tovarnih listova po jednim kolima"
        '
        'CheckBox1
        '
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(8, 55)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(170, 24)
        Me.CheckBox1.TabIndex = 44
        Me.CheckBox1.Text = "Cena po CIM-u (zbog upisa)"
        '
        'btnUpis
        '
        Me.btnUpis.BackColor = System.Drawing.SystemColors.Control
        Me.btnUpis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnUpis.Image = CType(resources.GetObject("btnUpis.Image"), System.Drawing.Image)
        Me.btnUpis.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpis.Location = New System.Drawing.Point(218, 10)
        Me.btnUpis.Name = "btnUpis"
        Me.btnUpis.Size = New System.Drawing.Size(96, 65)
        Me.btnUpis.TabIndex = 4
        Me.btnUpis.Text = "Upis u bazu"
        Me.btnUpis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.cbRIV)
        Me.Panel1.Controls.Add(Me.tbTEA)
        Me.Panel1.Controls.Add(Me.lblTEA)
        Me.Panel1.Controls.Add(Me.Button16)
        Me.Panel1.Controls.Add(Me.Button15)
        Me.Panel1.Controls.Add(Me.Label55)
        Me.Panel1.Controls.Add(Me.Label54)
        Me.Panel1.Controls.Add(Me.Label53)
        Me.Panel1.Controls.Add(Me.tbBlagajnaK115)
        Me.Panel1.Controls.Add(Me.Label50)
        Me.Panel1.Controls.Add(Me.tbPrev2)
        Me.Panel1.Controls.Add(Me.tbPrev1)
        Me.Panel1.Controls.Add(Me.Label49)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.tbBlagajna)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.tbNaknade)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.tbRazlika)
        Me.Panel1.Controls.Add(Me.tbTL)
        Me.Panel1.Controls.Add(Me.tbPrevoznina)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.tbValuta)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.GroupBox13)
        Me.Panel1.Controls.Add(Me.dgFinalNak)
        Me.Panel1.Location = New System.Drawing.Point(784, 103)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(210, 577)
        Me.Panel1.TabIndex = 56
        '
        'tbTEA
        '
        Me.tbTEA.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.tbTEA.Enabled = False
        Me.tbTEA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTEA.ForeColor = System.Drawing.Color.White
        Me.tbTEA.Location = New System.Drawing.Point(78, 288)
        Me.tbTEA.Name = "tbTEA"
        Me.tbTEA.Size = New System.Drawing.Size(120, 23)
        Me.tbTEA.TabIndex = 96
        Me.tbTEA.Text = "0"
        Me.tbTEA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbTEA.Visible = False
        '
        'lblTEA
        '
        Me.lblTEA.Enabled = False
        Me.lblTEA.Location = New System.Drawing.Point(3, 295)
        Me.lblTEA.Name = "lblTEA"
        Me.lblTEA.Size = New System.Drawing.Size(64, 13)
        Me.lblTEA.TabIndex = 95
        Me.lblTEA.Text = "Suma TEA"
        Me.lblTEA.Visible = False
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(16, 96)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(104, 23)
        Me.Button16.TabIndex = 94
        Me.Button16.Text = "cbNajava val"
        Me.Button16.Visible = False
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(32, 56)
        Me.Button15.Name = "Button15"
        Me.Button15.TabIndex = 93
        Me.Button15.Text = "Load"
        Me.Button15.Visible = False
        '
        'Label55
        '
        Me.Label55.Enabled = False
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(88, 432)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(104, 16)
        Me.Label55.TabIndex = 92
        Me.Label55.Text = "Kontrola prihoda"
        '
        'Label54
        '
        Me.Label54.Enabled = False
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(21, 520)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(37, 16)
        Me.Label54.TabIndex = 91
        Me.Label54.Text = "K115"
        Me.Label54.Visible = False
        '
        'Label53
        '
        Me.Label53.Enabled = False
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(21, 497)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(37, 16)
        Me.Label53.TabIndex = 90
        Me.Label53.Text = "K140"
        '
        'tbBlagajnaK115
        '
        Me.tbBlagajnaK115.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.tbBlagajnaK115.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBlagajnaK115.ForeColor = System.Drawing.Color.Black
        Me.tbBlagajnaK115.Location = New System.Drawing.Point(78, 517)
        Me.tbBlagajnaK115.Name = "tbBlagajnaK115"
        Me.tbBlagajnaK115.Size = New System.Drawing.Size(120, 22)
        Me.tbBlagajnaK115.TabIndex = 89
        Me.tbBlagajnaK115.Text = "0"
        Me.tbBlagajnaK115.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbBlagajnaK115.Visible = False
        '
        'Label50
        '
        Me.Label50.Enabled = False
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(3, 405)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(202, 25)
        Me.Label50.TabIndex = 88
        Me.Label50.Text = "CIM > RSD [ Dinar ]"
        '
        'tbPrev2
        '
        Me.tbPrev2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrev2.Location = New System.Drawing.Point(142, 240)
        Me.tbPrev2.Name = "tbPrev2"
        Me.tbPrev2.Size = New System.Drawing.Size(56, 20)
        Me.tbPrev2.TabIndex = 87
        Me.tbPrev2.Text = "0"
        Me.tbPrev2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbPrev2.Visible = False
        '
        'tbPrev1
        '
        Me.tbPrev1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrev1.Location = New System.Drawing.Point(78, 240)
        Me.tbPrev1.Name = "tbPrev1"
        Me.tbPrev1.Size = New System.Drawing.Size(56, 20)
        Me.tbPrev1.TabIndex = 86
        Me.tbPrev1.Text = "0"
        Me.tbPrev1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbPrev1.Visible = False
        '
        'Label49
        '
        Me.Label49.Enabled = False
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(3, 181)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(189, 27)
        Me.Label49.TabIndex = 85
        Me.Label49.Text = "ZS > EUR [ Euro ]"
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(8, 472)
        Me.TextBox4.MaxLength = 5
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(32, 22)
        Me.TextBox4.TabIndex = 78
        Me.TextBox4.Text = "RSD [ Dinar ]"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox4.Visible = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.Location = New System.Drawing.Point(1, 131)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(205, 45)
        Me.Button7.TabIndex = 76
        Me.Button7.Text = "Kalkulacija"
        '
        'tbBlagajna
        '
        Me.tbBlagajna.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.tbBlagajna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBlagajna.ForeColor = System.Drawing.Color.Black
        Me.tbBlagajna.Location = New System.Drawing.Point(78, 493)
        Me.tbBlagajna.Name = "tbBlagajna"
        Me.tbBlagajna.Size = New System.Drawing.Size(120, 22)
        Me.tbBlagajna.TabIndex = 36
        Me.tbBlagajna.Text = "0"
        Me.tbBlagajna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.Enabled = False
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(87, 477)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(97, 16)
        Me.Label35.TabIndex = 59
        Me.Label35.Text = "B L A G A J N A"
        '
        'tbNaknade
        '
        Me.tbNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNaknade.Location = New System.Drawing.Point(78, 262)
        Me.tbNaknade.Name = "tbNaknade"
        Me.tbNaknade.Size = New System.Drawing.Size(120, 23)
        Me.tbNaknade.TabIndex = 58
        Me.tbNaknade.Text = "0"
        Me.tbNaknade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(3, 270)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 13)
        Me.Label23.TabIndex = 57
        Me.Label23.Text = "Naknade"
        '
        'tbRazlika
        '
        Me.tbRazlika.BackColor = System.Drawing.Color.White
        Me.tbRazlika.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRazlika.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.tbRazlika.Location = New System.Drawing.Point(78, 544)
        Me.tbRazlika.Name = "tbRazlika"
        Me.tbRazlika.Size = New System.Drawing.Size(120, 22)
        Me.tbRazlika.TabIndex = 37
        Me.tbRazlika.Text = "0"
        Me.tbRazlika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTL
        '
        Me.tbTL.BackColor = System.Drawing.Color.Gray
        Me.tbTL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTL.ForeColor = System.Drawing.Color.White
        Me.tbTL.Location = New System.Drawing.Point(78, 450)
        Me.tbTL.Name = "tbTL"
        Me.tbTL.Size = New System.Drawing.Size(120, 22)
        Me.tbTL.TabIndex = 35
        Me.tbTL.Text = "0"
        Me.tbTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPrevoznina
        '
        Me.tbPrevoznina.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrevoznina.Location = New System.Drawing.Point(78, 215)
        Me.tbPrevoznina.Name = "tbPrevoznina"
        Me.tbPrevoznina.Size = New System.Drawing.Size(120, 23)
        Me.tbPrevoznina.TabIndex = 34
        Me.tbPrevoznina.Text = "0"
        Me.tbPrevoznina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Enabled = False
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 550)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 16)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Razlika"
        '
        'tbValuta
        '
        Me.tbValuta.Enabled = False
        Me.tbValuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValuta.Location = New System.Drawing.Point(8, 200)
        Me.tbValuta.MaxLength = 5
        Me.tbValuta.Name = "tbValuta"
        Me.tbValuta.Size = New System.Drawing.Size(40, 22)
        Me.tbValuta.TabIndex = 31
        Me.tbValuta.Text = "EUR [ Euro ]"
        Me.tbValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbValuta.Visible = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 223)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 17)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Prevoznina"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(205, 104)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 450)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 20)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Ukupno"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Silver
        Me.GroupBox13.Controls.Add(Me.ComboBox1)
        Me.GroupBox13.Controls.Add(Me.TextBox3)
        Me.GroupBox13.Controls.Add(Me.Label38)
        Me.GroupBox13.Controls.Add(Me.TextBox1)
        Me.GroupBox13.Controls.Add(Me.TextBox2)
        Me.GroupBox13.Controls.Add(Me.Label37)
        Me.GroupBox13.Controls.Add(Me.Label16)
        Me.GroupBox13.Location = New System.Drawing.Point(3, 314)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(195, 88)
        Me.GroupBox13.TabIndex = 84
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "[  C I M  ]"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"EUR Euro", "RSD Sr. Dinar", "CHF Sv. Franak", "USD Am. Dolar"})
        Me.ComboBox1.Location = New System.Drawing.Point(100, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(88, 21)
        Me.ComboBox1.TabIndex = 85
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(100, 55)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(88, 23)
        Me.TextBox3.TabIndex = 47
        Me.TextBox3.Text = "0"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox3, "F3 = Konverzija Dinari -> Euro")
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(121, 39)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(66, 19)
        Me.Label38.TabIndex = 46
        Me.Label38.Text = "UPUCENO"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(4, 55)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(88, 23)
        Me.TextBox1.TabIndex = 44
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(8, 16)
        Me.TextBox2.MaxLength = 5
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(24, 20)
        Me.TextBox2.TabIndex = 0
        Me.TextBox2.Text = "0"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox2.Visible = False
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(31, 39)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(58, 19)
        Me.Label37.TabIndex = 45
        Me.Label37.Text = "FRANKO"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(56, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 84
        Me.Label16.Text = "Valuta"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.dgFinalNak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgFinalNak.ForeColor = System.Drawing.Color.Black
        Me.dgFinalNak.GridLineColor = System.Drawing.Color.Black
        Me.dgFinalNak.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.dgFinalNak.HeaderBackColor = System.Drawing.Color.Silver
        Me.dgFinalNak.HeaderForeColor = System.Drawing.Color.Black
        Me.dgFinalNak.LinkColor = System.Drawing.Color.Navy
        Me.dgFinalNak.Location = New System.Drawing.Point(125, 392)
        Me.dgFinalNak.Name = "dgFinalNak"
        Me.dgFinalNak.ParentRowsBackColor = System.Drawing.Color.White
        Me.dgFinalNak.ParentRowsForeColor = System.Drawing.Color.Black
        Me.dgFinalNak.PreferredColumnWidth = 45
        Me.dgFinalNak.ReadOnly = True
        Me.dgFinalNak.SelectionBackColor = System.Drawing.Color.Navy
        Me.dgFinalNak.SelectionForeColor = System.Drawing.Color.White
        Me.dgFinalNak.Size = New System.Drawing.Size(72, 24)
        Me.dgFinalNak.TabIndex = 56
        Me.dgFinalNak.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Button13)
        Me.GroupBox6.Controls.Add(Me.Button11)
        Me.GroupBox6.Controls.Add(Me.btnUic)
        Me.GroupBox6.Controls.Add(Me.btnUnosNaknade)
        Me.GroupBox6.Controls.Add(Me.Button3)
        Me.GroupBox6.Controls.Add(Me.btnUnosRobe)
        Me.GroupBox6.Controls.Add(Me.btnUpis)
        Me.GroupBox6.Controls.Add(Me.Button9)
        Me.GroupBox6.Controls.Add(Me.Button12)
        Me.GroupBox6.Location = New System.Drawing.Point(456, 504)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(320, 175)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(120, 152)
        Me.Button13.Name = "Button13"
        Me.Button13.TabIndex = 91
        Me.Button13.Text = "Button13"
        Me.Button13.Visible = False
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(224, 152)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 16)
        Me.Button11.TabIndex = 90
        Me.Button11.Text = "Button11"
        Me.Button11.Visible = False
        '
        'btnUic
        '
        Me.btnUic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUic.Image = CType(resources.GetObject("btnUic.Image"), System.Drawing.Image)
        Me.btnUic.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUic.Location = New System.Drawing.Point(8, 78)
        Me.btnUic.Name = "btnUic"
        Me.btnUic.Size = New System.Drawing.Size(96, 65)
        Me.btnUic.TabIndex = 2
        Me.btnUic.Text = "Uic uprave [ F10 ]"
        Me.btnUic.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnUnosNaknade
        '
        Me.btnUnosNaknade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnosNaknade.Image = CType(resources.GetObject("btnUnosNaknade.Image"), System.Drawing.Image)
        Me.btnUnosNaknade.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUnosNaknade.Location = New System.Drawing.Point(113, 10)
        Me.btnUnosNaknade.Name = "btnUnosNaknade"
        Me.btnUnosNaknade.Size = New System.Drawing.Size(96, 65)
        Me.btnUnosNaknade.TabIndex = 1
        Me.btnUnosNaknade.Text = "Naknade  [ F11 ]"
        Me.btnUnosNaknade.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(113, 78)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 65)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Info               [ F9 ]"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button12
        '
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button12.Location = New System.Drawing.Point(8, 146)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(96, 24)
        Me.Button12.TabIndex = 89
        Me.Button12.Text = "KP - 511 "
        Me.ToolTip1.SetToolTip(Me.Button12, "Opis kontrolne primedbe")
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.Location = New System.Drawing.Point(96, 32)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(48, 34)
        Me.Button5.TabIndex = 64
        Me.Button5.Text = "Najava"
        Me.Button5.Visible = False
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.cbSmer1)
        Me.GroupBox10.Controls.Add(Me.cbSmer2)
        Me.GroupBox10.Controls.Add(Me.Label32)
        Me.GroupBox10.Controls.Add(Me.Label33)
        Me.GroupBox10.Location = New System.Drawing.Point(456, 5)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(210, 88)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "[ Izbor pravca ]"
        '
        'Label32
        '
        Me.Label32.Enabled = False
        Me.Label32.Location = New System.Drawing.Point(135, 46)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(72, 15)
        Me.Label32.TabIndex = 46
        Me.Label32.Text = "Izlazni prelaz"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label33
        '
        Me.Label33.Enabled = False
        Me.Label33.Location = New System.Drawing.Point(133, 13)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 13)
        Me.Label33.TabIndex = 47
        Me.Label33.Text = "Ulazni prelaz"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'dgError
        '
        Me.dgError.BackgroundColor = System.Drawing.Color.White
        Me.dgError.CaptionBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.dgError.CaptionText = ">>> PORUKE O GRESKAMA <<<"
        Me.dgError.DataMember = ""
        Me.dgError.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.dgError.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgError.Location = New System.Drawing.Point(11, 610)
        Me.dgError.Name = "dgError"
        Me.dgError.PreferredColumnWidth = 160
        Me.dgError.PreferredRowHeight = 10
        Me.dgError.Size = New System.Drawing.Size(437, 90)
        Me.dgError.TabIndex = 66
        Me.dgError.Visible = False
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "PomocGR.hlp"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Button5)
        Me.GroupBox11.Controls.Add(Me.Label2)
        Me.GroupBox11.Controls.Add(Me.cbKolaNajava)
        Me.GroupBox11.Controls.Add(Me.Label5)
        Me.GroupBox11.Controls.Add(Me.Label6)
        Me.GroupBox11.Location = New System.Drawing.Point(792, 16)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(16, 24)
        Me.GroupBox11.TabIndex = 68
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "GroupBox11"
        Me.GroupBox11.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBox7)
        Me.GroupBox4.Controls.Add(Me.TextBox8)
        Me.GroupBox4.Controls.Add(Me.TextBox6)
        Me.GroupBox4.Controls.Add(Me.TextBox5)
        Me.GroupBox4.Controls.Add(Me.Label46)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.cbFrankRacun)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.fxFranko)
        Me.GroupBox4.Controls.Add(Me.comboIncoterms)
        Me.GroupBox4.Controls.Add(Me.cbIncoterms)
        Me.GroupBox4.Controls.Add(Me.cbFrankoPrevoznina)
        Me.GroupBox4.Controls.Add(Me.btnIzjava)
        Me.GroupBox4.Controls.Add(Me.tbFrankoPrelaz)
        Me.GroupBox4.Controls.Add(Me.Label47)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.cmbFDP)
        Me.GroupBox4.Location = New System.Drawing.Point(456, 284)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(320, 220)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = " [ PLACANJE TROSKOVA ] "
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(229, 160)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(81, 22)
        Me.TextBox7.TabIndex = 59
        Me.TextBox7.Text = "0"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox7.Visible = False
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(229, 189)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(81, 22)
        Me.TextBox8.TabIndex = 60
        Me.TextBox8.Text = "0"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox8.Visible = False
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(136, 189)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(81, 22)
        Me.TextBox6.TabIndex = 57
        Me.TextBox6.Text = "0"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox6.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(136, 160)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(81, 22)
        Me.TextBox5.TabIndex = 56
        Me.TextBox5.Text = "0"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox5.Visible = False
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(33, 188)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(88, 24)
        Me.Label46.TabIndex = 55
        Me.Label46.Text = "Iznos franko po tovarnom listu"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label46.Visible = False
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(33, 167)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(80, 12)
        Me.Label39.TabIndex = 54
        Me.Label39.Text = "Iznos po K115"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label39.Visible = False
        '
        'cbFrankRacun
        '
        Me.cbFrankRacun.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbFrankRacun.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFrankRacun.Location = New System.Drawing.Point(8, 136)
        Me.cbFrankRacun.Name = "cbFrankRacun"
        Me.cbFrankRacun.Size = New System.Drawing.Size(128, 24)
        Me.cbFrankRacun.TabIndex = 53
        Me.cbFrankRacun.Text = "Frankaturni racun"
        Me.ToolTip1.SetToolTip(Me.cbFrankRacun, "Da li postoji frankaturni racun")
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(152, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 12)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Ukljucujuci"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'fxFranko
        '
        Me.fxFranko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fxFranko.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxFranko.Location = New System.Drawing.Point(224, 19)
        Me.fxFranko.Mask = "99 99 99 99 99"
        Me.fxFranko.Name = "fxFranko"
        Me.fxFranko.Size = New System.Drawing.Size(88, 22)
        Me.fxFranko.TabIndex = 0
        Me.fxFranko.ToolTip = "0 = zbirna naknada "
        '
        'comboIncoterms
        '
        Me.comboIncoterms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboIncoterms.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboIncoterms.Items.AddRange(New Object() {"EXW  sve placa primalac", "FCA  franko organizator prevoza", "CPT  franko do odredista", "CIP  franko osigurano do odredista", "DAF  placa posiljalac do granice", "DDU  placa posiljalac do mesta izdavanja", "DDP  placa posiljalac do mesta izdavanja"})
        Me.comboIncoterms.Location = New System.Drawing.Point(8, 100)
        Me.comboIncoterms.MaxLength = 3
        Me.comboIncoterms.Name = "comboIncoterms"
        Me.comboIncoterms.Size = New System.Drawing.Size(305, 23)
        Me.comboIncoterms.TabIndex = 52
        '
        'cbIncoterms
        '
        Me.cbIncoterms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIncoterms.Location = New System.Drawing.Point(8, 80)
        Me.cbIncoterms.Name = "cbIncoterms"
        Me.cbIncoterms.Size = New System.Drawing.Size(78, 24)
        Me.cbIncoterms.TabIndex = 51
        Me.cbIncoterms.Text = "Incoterms"
        '
        'cbFrankoPrevoznina
        '
        Me.cbFrankoPrevoznina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFrankoPrevoznina.Location = New System.Drawing.Point(8, 24)
        Me.cbFrankoPrevoznina.Name = "cbFrankoPrevoznina"
        Me.cbFrankoPrevoznina.Size = New System.Drawing.Size(130, 16)
        Me.cbFrankoPrevoznina.TabIndex = 50
        Me.cbFrankoPrevoznina.Text = "Franko prevoznina"
        '
        'btnIzjava
        '
        Me.btnIzjava.Enabled = False
        Me.btnIzjava.Location = New System.Drawing.Point(48, 58)
        Me.btnIzjava.Name = "btnIzjava"
        Me.btnIzjava.Size = New System.Drawing.Size(40, 21)
        Me.btnIzjava.TabIndex = 47
        Me.btnIzjava.Text = "Do"
        '
        'tbFrankoPrelaz
        '
        Me.tbFrankoPrelaz.Enabled = False
        Me.tbFrankoPrelaz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFrankoPrelaz.Location = New System.Drawing.Point(272, 57)
        Me.tbFrankoPrelaz.MaxLength = 4
        Me.tbFrankoPrelaz.Name = "tbFrankoPrelaz"
        Me.tbFrankoPrelaz.Size = New System.Drawing.Size(40, 22)
        Me.tbFrankoPrelaz.TabIndex = 1
        Me.tbFrankoPrelaz.Text = ""
        '
        'Label47
        '
        Me.Label47.Enabled = False
        Me.Label47.Location = New System.Drawing.Point(181, 146)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(42, 16)
        Me.Label47.TabIndex = 60
        Me.Label47.Text = "[ Euro ]"
        Me.Label47.Visible = False
        '
        'Label48
        '
        Me.Label48.Enabled = False
        Me.Label48.Location = New System.Drawing.Point(256, 145)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(54, 16)
        Me.Label48.TabIndex = 61
        Me.Label48.Text = "[ Dinara ]"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label48.Visible = False
        '
        'cmbFDP
        '
        Me.cmbFDP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFDP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cmbFDP.Location = New System.Drawing.Point(89, 57)
        Me.cmbFDP.Name = "cmbFDP"
        Me.cmbFDP.Size = New System.Drawing.Size(184, 23)
        Me.cmbFDP.TabIndex = 1
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.GroupBox8.Controls.Add(Me.fxPouzece)
        Me.GroupBox8.Controls.Add(Me.fxIsporuka)
        Me.GroupBox8.Controls.Add(Me.fxVrednostRobe)
        Me.GroupBox8.Controls.Add(Me.Label27)
        Me.GroupBox8.Controls.Add(Me.cbPouzece)
        Me.GroupBox8.Controls.Add(Me.cbIsporuka)
        Me.GroupBox8.Controls.Add(Me.cbVrednost)
        Me.GroupBox8.Controls.Add(Me.Label28)
        Me.GroupBox8.Controls.Add(Me.Label30)
        Me.GroupBox8.Controls.Add(Me.Label31)
        Me.GroupBox8.Controls.Add(Me.Label29)
        Me.GroupBox8.Controls.Add(Me.Label26)
        Me.GroupBox8.Location = New System.Drawing.Point(11, 329)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(221, 175)
        Me.GroupBox8.TabIndex = 70
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = " [ Roba ] "
        '
        'fxPouzece
        '
        Me.fxPouzece.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxPouzece.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxPouzece.Location = New System.Drawing.Point(8, 128)
        Me.fxPouzece.Mask = "#########9d##"
        Me.fxPouzece.Name = "fxPouzece"
        Me.fxPouzece.Size = New System.Drawing.Size(128, 20)
        Me.fxPouzece.TabIndex = 4
        Me.fxPouzece.Text = "0"
        Me.fxPouzece.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxIsporuka
        '
        Me.fxIsporuka.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxIsporuka.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxIsporuka.Location = New System.Drawing.Point(8, 87)
        Me.fxIsporuka.Mask = "#########9d##"
        Me.fxIsporuka.Name = "fxIsporuka"
        Me.fxIsporuka.Size = New System.Drawing.Size(128, 20)
        Me.fxIsporuka.TabIndex = 2
        Me.fxIsporuka.Text = "0"
        Me.fxIsporuka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fxVrednostRobe
        '
        Me.fxVrednostRobe.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxVrednostRobe.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxVrednostRobe.Location = New System.Drawing.Point(8, 34)
        Me.fxVrednostRobe.Mask = "#########9d##"
        Me.fxVrednostRobe.Name = "fxVrednostRobe"
        Me.fxVrednostRobe.Size = New System.Drawing.Size(128, 20)
        Me.fxVrednostRobe.TabIndex = 0
        Me.fxVrednostRobe.Text = "0"
        Me.fxVrednostRobe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(9, 108)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 23)
        Me.Label27.TabIndex = 70
        Me.Label27.Text = "Pouzece"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbPouzece
        '
        Me.cbPouzece.Items.AddRange(New Object() {"EUR Euro", "DIN Dinar", "CHF Sv.Franak", "USD Am.Dolar"})
        Me.cbPouzece.Location = New System.Drawing.Point(136, 127)
        Me.cbPouzece.Name = "cbPouzece"
        Me.cbPouzece.Size = New System.Drawing.Size(74, 21)
        Me.cbPouzece.TabIndex = 5
        '
        'cbIsporuka
        '
        Me.cbIsporuka.Items.AddRange(New Object() {"EUR Euro", "DIN Dinar", "CHF Sv.Franak", "USD Am.Dolar"})
        Me.cbIsporuka.Location = New System.Drawing.Point(136, 86)
        Me.cbIsporuka.Name = "cbIsporuka"
        Me.cbIsporuka.Size = New System.Drawing.Size(74, 21)
        Me.cbIsporuka.TabIndex = 3
        '
        'cbVrednost
        '
        Me.cbVrednost.Items.AddRange(New Object() {"EUR Euro", "DIN Dinar", "CHF Sv.Franak", "USD Am.Dolar"})
        Me.cbVrednost.Location = New System.Drawing.Point(136, 33)
        Me.cbVrednost.Name = "cbVrednost"
        Me.cbVrednost.Size = New System.Drawing.Size(74, 21)
        Me.cbVrednost.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(128, 14)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(90, 23)
        Me.Label28.TabIndex = 66
        Me.Label28.Text = "Valuta"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(10, 60)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(108, 24)
        Me.Label30.TabIndex = 65
        Me.Label30.Text = "Obezbedjenje uredne isporuke"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(128, 107)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(90, 23)
        Me.Label31.TabIndex = 68
        Me.Label31.Text = "Valuta"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(127, 66)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(90, 23)
        Me.Label29.TabIndex = 67
        Me.Label29.Text = "Valuta"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(13, 14)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 23)
        Me.Label26.TabIndex = 69
        Me.Label26.Text = "Vrednost robe"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox12.Controls.Add(Me.tbPlatilacNFR)
        Me.GroupBox12.Controls.Add(Me.tbPrimalac)
        Me.GroupBox12.Controls.Add(Me.Label24)
        Me.GroupBox12.Controls.Add(Me.Button17)
        Me.GroupBox12.Location = New System.Drawing.Point(234, 416)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(216, 88)
        Me.GroupBox12.TabIndex = 72
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "[ Primalac ]"
        '
        'tbPlatilacNFR
        '
        Me.tbPlatilacNFR.Location = New System.Drawing.Point(137, 49)
        Me.tbPlatilacNFR.MaxLength = 5
        Me.tbPlatilacNFR.Name = "tbPlatilacNFR"
        Me.tbPlatilacNFR.Size = New System.Drawing.Size(56, 20)
        Me.tbPlatilacNFR.TabIndex = 44
        Me.tbPlatilacNFR.Text = "0"
        Me.tbPlatilacNFR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPrimalac
        '
        Me.tbPrimalac.Location = New System.Drawing.Point(137, 14)
        Me.tbPrimalac.MaxLength = 5
        Me.tbPrimalac.Name = "tbPrimalac"
        Me.tbPrimalac.Size = New System.Drawing.Size(56, 20)
        Me.tbPrimalac.TabIndex = 0
        Me.tbPrimalac.Text = "0"
        Me.tbPrimalac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(5, 45)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(140, 27)
        Me.Label24.TabIndex = 45
        Me.Label24.Text = "Sifra korisnika koji je platio nefrankirane troskove"
        '
        'Button17
        '
        Me.Button17.Cursor = System.Windows.Forms.Cursors.Help
        Me.Button17.Location = New System.Drawing.Point(12, 16)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(104, 20)
        Me.Button17.TabIndex = 37
        Me.Button17.Text = "Sifra primaoca"
        Me.ToolTip1.SetToolTip(Me.Button17, "Izbor sifre primaoca")
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox9.Controls.Add(Me.Button18)
        Me.GroupBox9.Controls.Add(Me.tbPlatilacFRR)
        Me.GroupBox9.Controls.Add(Me.Label22)
        Me.GroupBox9.Controls.Add(Me.tbPosiljalac)
        Me.GroupBox9.Location = New System.Drawing.Point(234, 329)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(216, 88)
        Me.GroupBox9.TabIndex = 71
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "[ Posiljalac ]"
        '
        'Button18
        '
        Me.Button18.Cursor = System.Windows.Forms.Cursors.Help
        Me.Button18.Location = New System.Drawing.Point(11, 18)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(104, 20)
        Me.Button18.TabIndex = 46
        Me.Button18.Text = "Sifra posiljaoca"
        Me.ToolTip1.SetToolTip(Me.Button18, "Izbor sifre primaoca")
        '
        'tbPlatilacFRR
        '
        Me.tbPlatilacFRR.Location = New System.Drawing.Point(137, 53)
        Me.tbPlatilacFRR.MaxLength = 5
        Me.tbPlatilacFRR.Name = "tbPlatilacFRR"
        Me.tbPlatilacFRR.Size = New System.Drawing.Size(56, 20)
        Me.tbPlatilacFRR.TabIndex = 44
        Me.tbPlatilacFRR.Text = "0"
        Me.tbPlatilacFRR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(9, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(120, 27)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Sifra korisnika koji placa frankaturni racun"
        '
        'tbPosiljalac
        '
        Me.tbPosiljalac.Location = New System.Drawing.Point(137, 17)
        Me.tbPosiljalac.MaxLength = 5
        Me.tbPosiljalac.Name = "tbPosiljalac"
        Me.tbPosiljalac.Size = New System.Drawing.Size(56, 20)
        Me.tbPosiljalac.TabIndex = 0
        Me.tbPosiljalac.Text = "0"
        Me.tbPosiljalac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbKolauVozu
        '
        Me.gbKolauVozu.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.gbKolauVozu.Controls.Add(Me.tbKolauVozu)
        Me.gbKolauVozu.Controls.Add(Me.Label34)
        Me.gbKolauVozu.Controls.Add(Me.Button14)
        Me.gbKolauVozu.Location = New System.Drawing.Point(856, 5)
        Me.gbKolauVozu.Name = "gbKolauVozu"
        Me.gbKolauVozu.Size = New System.Drawing.Size(136, 89)
        Me.gbKolauVozu.TabIndex = 75
        Me.gbKolauVozu.TabStop = False
        Me.gbKolauVozu.Text = "[ Kola u vozu ]"
        '
        'tbKolauVozu
        '
        Me.tbKolauVozu.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.tbKolauVozu.Enabled = False
        Me.tbKolauVozu.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKolauVozu.Location = New System.Drawing.Point(88, 24)
        Me.tbKolauVozu.MaxLength = 5
        Me.tbKolauVozu.Name = "tbKolauVozu"
        Me.tbKolauVozu.Size = New System.Drawing.Size(32, 38)
        Me.tbKolauVozu.TabIndex = 0
        Me.tbKolauVozu.Text = "1"
        Me.tbKolauVozu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(8, 24)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 49)
        Me.Label34.TabIndex = 43
        Me.Label34.Text = "Redni broj kola po istom ugovoru - tarifi"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(48, 64)
        Me.Button14.Name = "Button14"
        Me.Button14.TabIndex = 45
        Me.Button14.Text = "katarina()"
        Me.Button14.Visible = False
        '
        'gb_Info
        '
        Me.gb_Info.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.gb_Info.Controls.Add(Me.PictureBox5)
        Me.gb_Info.Controls.Add(Me.PictureBox4)
        Me.gb_Info.Controls.Add(Me.PictureBox3)
        Me.gb_Info.Controls.Add(Me.lbl_TipUti)
        Me.gb_Info.Controls.Add(Me.PictureBox2)
        Me.gb_Info.Controls.Add(Me.lbl_PkolaProdos)
        Me.gb_Info.Controls.Add(Me.lblEvraPoKolima)
        Me.gb_Info.Controls.Add(Me.Label10)
        Me.gb_Info.Controls.Add(Me.lbl_ibk)
        Me.gb_Info.Controls.Add(Me.Label36)
        Me.gb_Info.Controls.Add(Me.lbl_smasa)
        Me.gb_Info.Controls.Add(Me.lbl_nhm)
        Me.gb_Info.Controls.Add(Me.lbl_tara)
        Me.gb_Info.Controls.Add(Me.L_SMasa)
        Me.gb_Info.Controls.Add(Me.L_NHM)
        Me.gb_Info.Controls.Add(Me.L_Tara)
        Me.gb_Info.Location = New System.Drawing.Point(11, 504)
        Me.gb_Info.Name = "gb_Info"
        Me.gb_Info.Size = New System.Drawing.Size(437, 99)
        Me.gb_Info.TabIndex = 83
        Me.gb_Info.TabStop = False
        Me.gb_Info.Text = " [ Preuzeto sa stanice ]"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(378, 62)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(31, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 98
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(336, 64)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(31, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 97
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(299, 61)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(31, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 96
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'lbl_TipUti
        '
        Me.lbl_TipUti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TipUti.Location = New System.Drawing.Point(402, 21)
        Me.lbl_TipUti.Name = "lbl_TipUti"
        Me.lbl_TipUti.Size = New System.Drawing.Size(30, 22)
        Me.lbl_TipUti.TabIndex = 95
        Me.lbl_TipUti.Text = "12"
        Me.lbl_TipUti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(11, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(85, 64)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 82
        Me.PictureBox2.TabStop = False
        '
        'lbl_PkolaProdos
        '
        Me.lbl_PkolaProdos.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbl_PkolaProdos.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_PkolaProdos.Location = New System.Drawing.Point(87, 17)
        Me.lbl_PkolaProdos.Name = "lbl_PkolaProdos"
        Me.lbl_PkolaProdos.Size = New System.Drawing.Size(40, 64)
        Me.lbl_PkolaProdos.TabIndex = 94
        Me.lbl_PkolaProdos.Text = "P"
        Me.lbl_PkolaProdos.Visible = False
        '
        'lblEvraPoKolima
        '
        Me.lblEvraPoKolima.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvraPoKolima.Location = New System.Drawing.Point(260, 62)
        Me.lblEvraPoKolima.Name = "lblEvraPoKolima"
        Me.lblEvraPoKolima.Size = New System.Drawing.Size(44, 23)
        Me.lblEvraPoKolima.TabIndex = 93
        Me.lblEvraPoKolima.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(133, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 23)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "Naknada po kolima :"
        '
        'lbl_ibk
        '
        Me.lbl_ibk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ibk.Location = New System.Drawing.Point(207, 24)
        Me.lbl_ibk.Name = "lbl_ibk"
        Me.lbl_ibk.Size = New System.Drawing.Size(91, 16)
        Me.lbl_ibk.TabIndex = 87
        Me.lbl_ibk.Text = "123456789012"
        Me.lbl_ibk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(133, 24)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(79, 16)
        Me.Label36.TabIndex = 91
        Me.Label36.Text = "Ind. br. kola:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_smasa
        '
        Me.lbl_smasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_smasa.Location = New System.Drawing.Point(207, 44)
        Me.lbl_smasa.Name = "lbl_smasa"
        Me.lbl_smasa.Size = New System.Drawing.Size(81, 17)
        Me.lbl_smasa.TabIndex = 90
        Me.lbl_smasa.Text = "123456"
        Me.lbl_smasa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_nhm
        '
        Me.lbl_nhm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nhm.Location = New System.Drawing.Point(352, 21)
        Me.lbl_nhm.Name = "lbl_nhm"
        Me.lbl_nhm.Size = New System.Drawing.Size(56, 22)
        Me.lbl_nhm.TabIndex = 89
        Me.lbl_nhm.Text = "123456"
        Me.lbl_nhm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_tara
        '
        Me.lbl_tara.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tara.Location = New System.Drawing.Point(352, 45)
        Me.lbl_tara.Name = "lbl_tara"
        Me.lbl_tara.Size = New System.Drawing.Size(56, 16)
        Me.lbl_tara.TabIndex = 88
        Me.lbl_tara.Text = "132456"
        Me.lbl_tara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'L_SMasa
        '
        Me.L_SMasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_SMasa.Location = New System.Drawing.Point(133, 44)
        Me.L_SMasa.Name = "L_SMasa"
        Me.L_SMasa.Size = New System.Drawing.Size(79, 17)
        Me.L_SMasa.TabIndex = 86
        Me.L_SMasa.Text = "Neto [kg]     :"
        '
        'L_NHM
        '
        Me.L_NHM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_NHM.Location = New System.Drawing.Point(300, 23)
        Me.L_NHM.Name = "L_NHM"
        Me.L_NHM.Size = New System.Drawing.Size(60, 17)
        Me.L_NHM.TabIndex = 85
        Me.L_NHM.Text = "NHM      :"
        Me.L_NHM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'L_Tara
        '
        Me.L_Tara.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Tara.Location = New System.Drawing.Point(300, 45)
        Me.L_Tara.Name = "L_Tara"
        Me.L_Tara.Size = New System.Drawing.Size(60, 16)
        Me.L_Tara.TabIndex = 84
        Me.L_Tara.Text = "Tara [kg]:"
        Me.L_Tara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.btnNadjiNajavu)
        Me.GroupBox14.Controls.Add(Me.tbKolaRealizovano)
        Me.GroupBox14.Controls.Add(Me.Button8)
        Me.GroupBox14.Controls.Add(Me.cbNajava)
        Me.GroupBox14.Controls.Add(Me.Label40)
        Me.GroupBox14.Controls.Add(Me.ComboBox2)
        Me.GroupBox14.Controls.Add(Me.Button10)
        Me.GroupBox14.Controls.Add(Me.Label41)
        Me.GroupBox14.Controls.Add(Me.tbKolauNajavi)
        Me.GroupBox14.Controls.Add(Me.Label42)
        Me.GroupBox14.Location = New System.Drawing.Point(234, 5)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(214, 88)
        Me.GroupBox14.TabIndex = 0
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = " [ NAJAVA ] "
        '
        'btnNadjiNajavu
        '
        Me.btnNadjiNajavu.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnNadjiNajavu.Image = CType(resources.GetObject("btnNadjiNajavu.Image"), System.Drawing.Image)
        Me.btnNadjiNajavu.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNadjiNajavu.Location = New System.Drawing.Point(141, 19)
        Me.btnNadjiNajavu.Name = "btnNadjiNajavu"
        Me.btnNadjiNajavu.Size = New System.Drawing.Size(67, 64)
        Me.btnNadjiNajavu.TabIndex = 67
        Me.btnNadjiNajavu.Text = "Nadji najavu"
        Me.btnNadjiNajavu.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNadjiNajavu.Visible = False
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
        'Button8
        '
        Me.Button8.Enabled = False
        Me.Button8.Location = New System.Drawing.Point(144, 56)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(24, 23)
        Me.Button8.TabIndex = 66
        Me.Button8.Text = "Button4"
        Me.Button8.Visible = False
        '
        'cbNajava
        '
        Me.cbNajava.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbNajava.Location = New System.Drawing.Point(8, 21)
        Me.cbNajava.MaxLength = 10
        Me.cbNajava.Name = "cbNajava"
        Me.cbNajava.Size = New System.Drawing.Size(128, 24)
        Me.cbNajava.TabIndex = 0
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(112, 8)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(24, 16)
        Me.Label40.TabIndex = 65
        Me.Label40.Text = "Broj"
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox2.Location = New System.Drawing.Point(144, 32)
        Me.ComboBox2.MaxLength = 12
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(48, 24)
        Me.ComboBox2.TabIndex = 3
        Me.ComboBox2.Visible = False
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.Location = New System.Drawing.Point(176, 56)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(32, 25)
        Me.Button10.TabIndex = 64
        Me.Button10.Text = "Popuni"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button10.Visible = False
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(144, 16)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(48, 16)
        Me.Label41.TabIndex = 47
        Me.Label41.Text = "Izbor kola iz najave"
        Me.Label41.Visible = False
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
        'Label42
        '
        Me.Label42.Enabled = False
        Me.Label42.Location = New System.Drawing.Point(9, 47)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(135, 16)
        Me.Label42.TabIndex = 50
        Me.Label42.Text = "Najavljeno    Realizovano"
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.ComboBox4)
        Me.GroupBox15.Controls.Add(Me.Label45)
        Me.GroupBox15.Controls.Add(Me.cmbPrevPut)
        Me.GroupBox15.Controls.Add(Me.Label43)
        Me.GroupBox15.Location = New System.Drawing.Point(456, 219)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(320, 64)
        Me.GroupBox15.TabIndex = 4
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "[ PREVOZNI PUT UIC ]"
        '
        'ComboBox4
        '
        Me.ComboBox4.Enabled = False
        Me.ComboBox4.Items.AddRange(New Object() {"EUR Euro", "DIN Dinar", "CHF Sv.Franak", "USD Am.Dolar"})
        Me.ComboBox4.Location = New System.Drawing.Point(248, 8)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(48, 21)
        Me.ComboBox4.TabIndex = 45
        Me.ComboBox4.Visible = False
        '
        'Label45
        '
        Me.Label45.Enabled = False
        Me.Label45.Location = New System.Drawing.Point(136, 16)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(108, 8)
        Me.Label45.TabIndex = 44
        Me.Label45.Text = "Izbor globalnog puta"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label45.Visible = False
        '
        'cmbPrevPut
        '
        Me.cmbPrevPut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrevPut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrevPut.Location = New System.Drawing.Point(10, 29)
        Me.cmbPrevPut.Name = "cmbPrevPut"
        Me.cmbPrevPut.Size = New System.Drawing.Size(286, 23)
        Me.cmbPrevPut.TabIndex = 43
        '
        'Label43
        '
        Me.Label43.Enabled = False
        Me.Label43.Location = New System.Drawing.Point(11, 13)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(116, 16)
        Me.Label43.TabIndex = 42
        Me.Label43.Text = "Izbor prevoznog puta"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.cbVrstaSaobracaja)
        Me.GroupBox16.Controls.Add(Me.Label44)
        Me.GroupBox16.Controls.Add(Me.Button19)
        Me.GroupBox16.Location = New System.Drawing.Point(669, 5)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(184, 89)
        Me.GroupBox16.TabIndex = 87
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "[ Vrsta saobracaja ]"
        '
        'cbVrstaSaobracaja
        '
        Me.cbVrstaSaobracaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVrstaSaobracaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVrstaSaobracaja.Items.AddRange(New Object() {"2 Uvoz", "4 Suvozemni tranzit", "5 Lucki tranzit (Otp.Uprava-Luka)", "6 Lucki tranzit (Luka-Otp.Uprava)", "7 Tranzit drum-zeleznica", "8 Tranzit zeleznica-drum"})
        Me.cbVrstaSaobracaja.Location = New System.Drawing.Point(7, 24)
        Me.cbVrstaSaobracaja.Name = "cbVrstaSaobracaja"
        Me.cbVrstaSaobracaja.Size = New System.Drawing.Size(169, 24)
        Me.cbVrstaSaobracaja.TabIndex = 43
        '
        'Label44
        '
        Me.Label44.Enabled = False
        Me.Label44.Location = New System.Drawing.Point(128, 8)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(32, 16)
        Me.Label44.TabIndex = 42
        Me.Label44.Text = "Izbor "
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(8, 48)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(32, 23)
        Me.Button19.TabIndex = 48
        Me.Button19.Text = "test"
        Me.Button19.Visible = False
        '
        'cbRIV
        '
        Me.cbRIV.Location = New System.Drawing.Point(4, 1)
        Me.cbRIV.Name = "cbRIV"
        Me.cbRIV.Size = New System.Drawing.Size(204, 24)
        Me.cbRIV.TabIndex = 97
        Me.cbRIV.Text = "Kola oslobodena od placanja RIV-a"
        '
        'UnosExIm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 693)
        Me.Controls.Add(Me.GroupBox16)
        Me.Controls.Add(Me.GroupBox15)
        Me.Controls.Add(Me.GroupBox14)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gb_Info)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.gbKolauVozu)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.dgError)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.ToolBar2)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.btnNajava)
        Me.Controls.Add(Me.Button6)
        Me.KeyPreview = True
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "UnosExIm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        CType(Me.dgFinalNak, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.gbKolauVozu.ResumeLayout(False)
        Me.gb_Info.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox16.ResumeLayout(False)
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
    Private Sub Unos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MasterAction = "Upd" Then
            MM_Count = 0
        End If

        Me.m_UpdateAllowed = "No"

        If (mTarifa = "68" Or kSifTar = 68) Or ((Microsoft.VisualBasic.Right(mBrojUg, 2) = "92" Or Microsoft.VisualBasic.Right(mBrojUg, 2) = "93") And mVrstaObracuna = "CO") Then
            lblTEA.Visible = True
            tbTEA.Visible = True
        Else
            lblTEA.Visible = False
            tbTEA.Visible = False
        End If

        Me.Button1.Visible = False
        tbRazlika.BackColor = System.Drawing.Color.White
        FormatErrGrid()
        Me.cmbManipulativnaMestaEx.Visible = False
        Me.cmbManipulativnaMestaIm.Visible = False
        '---------------------------------------------------
        lbl_ibk.Text = mIBK
        lbl_tara.Text = _mTara
        lbl_nhm.Text = _mNHM
        lbl_smasa.Text = _mSMasa

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

        lbl_TipUti.Text = _mTipUti & Chr(34) '" ft"

        tbUpravaOtp.Text = mOtpUprava
        tbStanicaOtp.Text = mOtpStanica
        tbBrojOtp.Text = mOtpBroj
        DatumOtp.Text = mOtpDatum

        tbUpravaPr.Text = mPrUprava
        tbStanicaPr.Text = mPrStanica
        Me.DateTimePicker2.Text = mPrDatum
        GroupBox7.Visible = False

        tbKolauNajavi.Visible = False
        tbKolaRealizovano.Visible = False
        cbZsPrevozniPut.SelectedIndex = 0

        Me.ComboBox1.Text = "EUR Euro"

        If IzborSaobracaja = 2 Then ' UVOZ
            cbFrankRacun.Visible = False
            Label53.Text = "K165"

            cbVrstaSaobracaja.Items.Clear()
            cbVrstaSaobracaja.Items.Add("2 Uvoz")
            cbVrstaSaobracaja.Items.Add("4 Suvozemni tranzit")
            cbVrstaSaobracaja.Items.Add("5 Lucki tranzit (Otp.Uprava - Luka)")
            cbVrstaSaobracaja.Items.Add("6 Lucki tranzit (Luka - Otp.Uprava)")
            cbVrstaSaobracaja.Items.Add("7 Tranzit (drum - zeleznica)")
            cbVrstaSaobracaja.Items.Add("8 Tranzit (zeleznica - drum)")
            cbVrstaSaobracaja.Text = "2 Uvoz"
            Me.cbSmer1.Visible = True
            Me.cbSmer1.Enabled = True
            Me.cbSmer1.Text = mStanica1
            cbSmer2.Visible = False

            Label32.Visible = False
            Label33.Visible = True
            Me.btnUpravaPr.Enabled = False
            Me.tbUpravaPr.Text = "0072"
            Me.tbUpravaPr.Enabled = False
            Me.Label14.Text = "ZS"
            Me.tbBrojPr.Enabled = True
            Label17.Text = "Datum prispeca"
            Label15.Enabled = True
            Label17.Enabled = True

            GroupBox10.Text = " [ Ulazni prelaz ] "

        ElseIf IzborSaobracaja = 3 Then ' IZVOZ
            cbFrankRacun.Visible = True
            Label53.Text = "K140"

            cbVrstaSaobracaja.Items.Clear()
            cbVrstaSaobracaja.Items.Add("3 Izvoz")
            cbVrstaSaobracaja.Items.Add("4 Suvozemni tranzit")
            cbVrstaSaobracaja.Items.Add("5 Lucki tranzit (Otp.Uprava - Luka)")
            cbVrstaSaobracaja.Items.Add("6 Lucki tranzit (Luka - Otp.Uprava)")
            cbVrstaSaobracaja.Items.Add("7 Tranzit (drum - zeleznica)")
            cbVrstaSaobracaja.Items.Add("8 Tranzit (zeleznica - drum)")
            cbVrstaSaobracaja.Text = "3 Izvoz"

            cbSmer1.Visible = False
            Label32.Visible = True
            Label33.Visible = False
            cbSmer2.Visible = True
            cbSmer2.Enabled = True
            Me.cbSmer2.Text = mStanica2

            'Me.cbSmer2.Text = StanicaUnosa

            mOtpUprava = "0072" 'mOtpUprava = "72"
            Me.tbUpravaOtp.Text = "0072"
            Me.tbStanicaOtp.Text = mOtpStanica '"72"
            '''Me.tbStanicaOtp.SelectionStart = 3
            Me.tbUpravaOtp.Enabled = False
            Label11.Text = "ZS"
            Me.tbBrojPr.Visible = False
            Label15.Visible = False
            Label17.Visible = True

            GroupBox10.Text = " [ Izlazni prelaz ] "

        ElseIf IzborSaobracaja = 1 Then ' LOKAL
            cbFrankRacun.Visible = False
            Label53.Text = "K140"

            cbVrstaSaobracaja.Items.Clear()
            cbVrstaSaobracaja.Items.Add("3 Izvoz")
            cbVrstaSaobracaja.Items.Add("4 Suvozemni tranzit")
            cbVrstaSaobracaja.Items.Add("5 Lucki tranzit (Otp.Uprava - Luka)")
            cbVrstaSaobracaja.Items.Add("6 Lucki tranzit (Luka - Otp.Uprava)")
            cbVrstaSaobracaja.Items.Add("7 Tranzit (drum - zeleznica)")
            cbVrstaSaobracaja.Items.Add("8 Tranzit (zeleznica - drum)")
            cbVrstaSaobracaja.Text = "3 Izvoz"

            Me.GroupBox10.Visible = False
            Me.tbUpravaOtp.Text = "0072"
            Me.tbUpravaPr.Text = "0072"
            Me.tbUpravaOtp.Enabled = False
            Me.tbUpravaPr.Enabled = False
            Label11.Text = "ZS"
            Label14.Text = "ZS"
            Me.tbBrojPr.Visible = True
            Me.tbBrojPr.Enabled = True
            Label15.Visible = True
            Label17.Visible = True
            Label17.Text = "Datum prispeca"
            GroupBox15.Enabled = False
            Me.cbIncoterms.Visible = False
            Me.comboIncoterms.Visible = False
            Me.btnUic.Enabled = False
        End If

        '---------------------------------------------------
        If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then
            If mVrstaPrevoza <> "P" Then
                Me.cbNajava.Enabled = True
                Me.tbKolaRealizovano.Visible = True
                Me.tbKolauNajavi.Visible = True
                Me.tbKolaRealizovano.Enabled = True
                Me.tbKolauNajavi.Enabled = True
                Me.cbNajava.Focus()
            Else
                Me.cbNajava.Enabled = False
                If IzborSaobracaja = 2 Then
                    Me.cbSmer1.Focus()
                ElseIf IzborSaobracaja = 3 Then
                    Me.cbSmer2.Focus()
                End If
            End If
        End If
        If mTarifa = "00" And mVrstaObracuna = "RO" Then
            Me.cbNajava.Enabled = False
            If IzborSaobracaja = 2 Then
                Me.cbSmer1.Focus()
            ElseIf IzborSaobracaja = 3 Then
                Me.cbSmer2.Focus()
            End If
        End If
        '---------------------------------------------------

        Me.gb_Info.Visible = True

        'na sta se odnosi: MasterAction = "Upd" Or RecordAction = "P"??

        'IZMENA PODATAKA U OKPWINROBA
        If MasterAction = "Upd" Then  ''kako moze izmena u bazi i preuzimanje: Or RecordAction = "P" Then
            'Me.gb_Info.Visible = False
            Me.cbSmer1.Text = mStanica1
            Me.tbUpravaOtp.Text = mOtpUprava
            Me.tbStanicaOtp.Text = mOtpStanica
            Me.tbBrojOtp.Text = mOtpBroj
            Me.DatumOtp.Value = mOtpDatum
            If IzborSaobracaja = "2" Then
                mDatumKalk = mPrDatum
            Else
                mDatumKalk = mOtpDatum
            End If

            Me.tbUpravaPr.Text = mPrUprava
            Me.tbStanicaPr.Text = mPrStanica

            Me.tbBrojPr.Text = mPrBroj

            If mVrstaPrevoza <> "P" Then
                cbNajava.Text = mNajava
            Else
                cbKolaNajava.Enabled = False
                cbNajava.Enabled = False
            End If

            tbStanicaLom.Text = LomStanica

            If mManipulativnoMesto <> "" Then
                If IzborSaobracaja = 2 Then
                    cmbManipulativnaMestaEx.Visible = False
                    cmbManipulativnaMestaIm.Visible = True

                    cmbManipulativnaMestaIm.Items.Clear()
                    cmbManipulativnaMestaIm.Items.Add(mManipulativnoMesto)
                    If cmbManipulativnaMestaIm.Items.Count > 0 Then
                        cmbManipulativnaMestaIm.SelectedIndex = 0
                    End If
                    Me.cmbManipulativnaMestaIm.Text = mManipulativnoMesto
                Else
                    cmbManipulativnaMestaIm.Visible = False
                    cmbManipulativnaMestaEx.Visible = True

                    cmbManipulativnaMestaEx.Items.Clear()
                    cmbManipulativnaMestaEx.Items.Add(mManipulativnoMesto)
                    If cmbManipulativnaMestaEx.Items.Count > 0 Then
                        cmbManipulativnaMestaEx.SelectedIndex = 0
                    End If
                End If
            End If

            If mSifraIzjave = 1 Then
                Me.cbFrankoPrevoznina.Checked = True
                Me.cbIncoterms.Checked = False
                Me.fxFranko.Text = ""

                If Len(upis_mFrNaknade) < 2 Then
                    Me.fxFranko.Text = upis_mFrNaknade
                Else
                    For abc As Int16 = 1 To Len(upis_mFrNaknade) Step 2
                        Me.fxFranko.Text = Me.fxFranko.Text & Microsoft.VisualBasic.Mid(upis_mFrNaknade, abc, 2)
                    Next
                End If
                Me.tbFrankoPrelaz.Text = mDoPrelaza 'in case of update
                Me.cmbFDP.Text = mDoPrelaza
            Else
                Me.cbFrankoPrevoznina.Checked = False
                Me.cbIncoterms.Checked = True

                If mIncoterms = "EXW" Then
                    Me.comboIncoterms.SelectedIndex = 0
                ElseIf mIncoterms = "FCA" Then
                    Me.comboIncoterms.SelectedIndex = 1
                ElseIf mIncoterms = "CPT" Then
                    Me.comboIncoterms.SelectedIndex = 2
                ElseIf mIncoterms = "CIP" Then
                    Me.comboIncoterms.SelectedIndex = 3
                ElseIf mIncoterms = "DAF" Then
                    Me.comboIncoterms.SelectedIndex = 4
                ElseIf mIncoterms = "DDU" Then
                    Me.comboIncoterms.SelectedIndex = 5
                ElseIf mIncoterms = "DDP" Then
                    Me.comboIncoterms.SelectedIndex = 6
                End If
            End If

            tbKm1.Text = bTkm
            Me.cmbPrevPut.Items.Clear()
            Me.cmbPrevPut.Items.Add(m_UicPrevozniPut)
            Me.cmbPrevPut.Text = m_UicPrevozniPut

            '--------------- clicked ----------------
            If IzborSaobracaja = "2" Then
                Me.tbUpravaOtp_Validating(Me, Nothing)
                Me.tbStanicaOtp_Validating(Me, Nothing)
                'Me.tbBrojOtp_Validating(Me, Nothing)
                Me.tbBrojPr_Leave(Me, Nothing)
                Me.DatumOtp_Validating(Me, Nothing)
                Me.tbStanicaPr_Validating(Me, Nothing)
                Me.tbBrojPr_Validating(Me, Nothing)

                Me.tbBrojPr_Leave(Me, Nothing)
                Me.DateTimePicker2_Validating(Me, Nothing)
                cmbManipulativnaMestaIm_Validating(Me, Nothing)
            Else
                Me.tbStanicaOtp_Validating(Me, Nothing)
                'Me.tbBrojOtp_Validating(Me, Nothing)
                Me.tbBrojPr_Leave(Me, Nothing)
                Me.DatumOtp_Validating(Me, Nothing)
                Me.tbUpravaPr_Validating(Me, Nothing)
                Me.tbStanicaPr_Validating(Me, Nothing)
                ''Me.tbBrojOtp_Leave(Me, Nothing)
                Me.DateTimePicker2_Validating(Me, Nothing)
                cmbManipulativnaMestaEx_Validating(Me, Nothing)
            End If

            Daljinar()

            Me.btnUnosRobe.Focus()

            If bValuta = "17" Then
                Me.ComboBox1.Text = "EUR Euro"
            ElseIf bValuta = "02" Then
                Me.ComboBox1.Text = "USD Am. Dolar"
            ElseIf bValuta = "85" Then
                Me.ComboBox1.Text = "CHF Sv.Franak"
            End If

            tbPrevoznina.Text = Format(mPrevoznina, "###,###,##0.00")
            tbNaknade.Text = Format(mSumaNak, "###,###,##0.00")
            TextBox1.Text = Format(mTL_franko, "###,###,##0.00")
            TextBox3.Text = Format(mTL_upuceno, "###,###,##0.00")
            tbTL.Text = Format(mSumaDinari, "###,###,##0.00")
            tbBlagajna.Text = Format(mBlagajna, "###,###,##0.00")
            tbRazlika.Text = Format(mRazlika, "###,###,##0.00")

        Else  'PREUZIMANJE PODATAKA IZ WINROBA
            If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then ' ugovor centralni obracun
                If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "01" Then
                    gbKolauVozu.Visible = True
                    tbKolauVozu.Text = "1"
                Else
                    gbKolauVozu.Visible = False
                End If

                If mVrstaPrevoza <> "P" Then ' grupa ili voz => moze da pozove najavu

                    Me.btnNajava.Enabled = True
                    Me.cbNajava.Enabled = True
                    Me.Label2.Enabled = True
                    Me.cbKolaNajava.Enabled = True
                    Me.GroupBox3.Enabled = True

                    Me.tbKolaRealizovano.Visible = True
                    Me.tbKolauNajavi.Visible = True
                    Me.tbKolaRealizovano.Enabled = True
                    Me.tbKolauNajavi.Enabled = True
                Else
                    Me.btnNajava.Enabled = False
                    Me.cbNajava.Enabled = False
                    Me.Label2.Enabled = False
                    Me.cbKolaNajava.Enabled = False
                    Me.GroupBox3.Enabled = True
                End If
            Else 'redovne tarife i ugovori KP
                Me.btnNajava.Enabled = False
                Me.cbNajava.Enabled = False
                Me.Label2.Enabled = False
                Me.cbKolaNajava.Enabled = False
                Me.GroupBox3.Enabled = True
            End If
            '--------------- clicked ----------------
            If AkcijaZaPreuzimanje = "Da" Then
                If IzborSaobracaja = "2" Then
                    Me.tbUpravaOtp_Validating(Me, Nothing)
                    Me.tbStanicaOtp_Validating(Me, Nothing)
                    'Me.tbBrojOtp_Validating(Me, Nothing)
                    '''Me.tbBrojPr_Leave(Me, Nothing)
                    Me.DatumOtp_Validating(Me, Nothing)
                    Me.tbStanicaPr_Validating(Me, Nothing)
                    If AkcijaZaPreuzimanje = "Da" Then

                    Else
                        Me.tbBrojPr_Validating(Me, Nothing)
                    End If

                    Me.tbBrojPr_Leave(Me, Nothing)
                    Me.DateTimePicker2_Validating(Me, Nothing)
                    cmbManipulativnaMestaIm_Validating(Me, Nothing)

                Else
                    Me.tbStanicaOtp_Validating(Me, Nothing)
                    'Me.tbBrojOtp_Validating(Me, Nothing)
                    Me.tbBrojPr_Leave(Me, Nothing)
                    Me.DatumOtp_Validating(Me, Nothing)
                    Me.tbUpravaPr_Validating(Me, Nothing)
                    Me.tbStanicaPr_Validating(Me, Nothing)
                    ''Me.tbBrojOtp_Leave(Me, Nothing)
                    Me.DateTimePicker2_Validating(Me, Nothing)
                    cmbManipulativnaMestaEx_Validating(Me, Nothing)
                End If
                Daljinar()

                If mVrstaPrevoza <> "P" And mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then
                    Me.cbNajava.Focus()
                Else
                    Me.tbBrojPr.Focus()
                End If

            End If

        End If

    End Sub

    Private Sub btnUnosRobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnosRobe.Click
        If cbRIV.Checked = True Then
            nmRIV = True
        Else
            nmRIV = False
        End If
        GroupBox4_Leave(Me, Nothing)

        If Me.rb1.Checked = True Then 'Or Me.rb3.Checked = True Then
            _TL_Kola = 1
        End If
        If Me.rb2.Checked = True Then
            _TL_Kola = 2
        End If

        If bVrstaPosiljke = "K" Then
            Dim GridKola As New kola
            GridKola.Show()
        ElseIf bVrstaPosiljke = "D" Or mTarifa = "46" Then
            Dim GridDencane As New Dencane
            GridDencane.Show()
        End If

    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        dtUic.Clear()
        dtUic2.Clear()
        dtUicEx.Clear()
        dtKorekcija.Clear()

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

        mOtpUprava = 0
        mOtpStanica = 0
        mOtpBroj = 0

        mNastavljaNajavu = False
        SledeciCimIsteNajave = False
        AkcijaZaPreuzimanje = AkcijaZaPreuzimanje

        Me.Dispose()

        'Close()
    End Sub
    Private Sub cbzsprelaz1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub GroupBox7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox7.Enter

    End Sub
    Private Sub cbNajava_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        '-------------------------------------------------- popunjava NHM ---------------------------------------------------
        en_Kola = cbKolaNajava.Items.GetEnumerator()
        dsNajavaNhm.Clear()

        Try
            Dim adNajavaNhm As New SqlDataAdapter("SELECT dbo.NajavaIC.NHM, dbo.NajavaIC.UTITip, dbo.NajavaKola.NetoMasa, dbo.NajavaKola.IBK as [IBK] " _
                                        & " FROM dbo.NajavaKola INNER JOIN dbo.NajavaIC ON dbo.NajavaKola.BrUgovora = dbo.NajavaIC.BrUgovora AND dbo.NajavaKola.KomBrojVoza = dbo.NajavaIC.KomBrVoza AND dbo.NajavaKola.KolaStavka = dbo.NajavaIC.KolaStavka " _
                                        & " WHERE (dbo.NajavaKola.IBK = '" & cbKolaNajava.Text & "') AND (dbo.NajavaKola.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaKola.KomBrojVoza = '" & mNajava & "')", DbVeza)

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
                                                  & " WHERE (BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaKola.KomBrojVoza = '" & mNajava & "') AND (dbo.NajavaKola.IBK = '" & cbKolaNajava.Text & "')", DbVeza)

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
    Private Sub cbSmer1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer1.GotFocus
        ''If mTarifa = "00" And mVrstaObracuna = "CO" Then ' ugovor centralni obracun
        ''    If mVrstaPrevoza <> "P" Then
        ''        If DbVeza.State = ConnectionState.Closed Then
        ''            OkpDbVeza.Open()
        ''        End If

        ''        Dim sql_text As String = "SELECT Stanica1, Stanica2 " & _
        ''                                 "FROM dbo.NajavaVoza " & _
        ''                                 "WHERE (BrUgovora = '" & mBrojUg & "') AND (KomBrojVoza = '" & mNajava & "') " & _
        ''                                 "GROUP BY Stanica1, Stanica2"

        ''        Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)
        ''        Dim rdrSmer As SqlClient.SqlDataReader

        ''        cbSmer1.Items.Clear()
        ''        cbSmer2.Items.Clear()
        ''        rdrSmer = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        ''        Do While rdrSmer.Read()
        ''            cbSmer1.Text = rdrSmer.GetString(0)
        ''            cbSmer1.Items.Add(rdrSmer.GetString(0))
        ''            cbSmer2.Text = rdrSmer.GetString(1)
        ''            cbSmer2.Items.Add(rdrSmer.GetString(1))
        ''        Loop
        ''        rdrSmer.Close()
        ''        OkpDbVeza.Close()
        ''    End If
        ''Else
        ''    'sifre prelaza
        ''End If
        '''cbSmer1.DroppedDown = True
    End Sub

    ''Private Sub cbNajava_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNajava.Leave
    ''    If MasterAction = "New" Then
    ''        mNajava = cbNajava.Text

    ''        If DbVeza.State = ConnectionState.Closed Then
    ''            DbVeza.Open()
    ''        End If

    ''        Dim sql_text As String = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK " & _
    ''                                 "FROM dbo.NajavaVoza INNER JOIN " & _
    ''                                      "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
    ''                                      "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza INNER JOIN " & _
    ''                                      "dbo.NajavaIC ON dbo.NajavaKola.BrUgovora = dbo.NajavaIC.BrUgovora AND dbo.NajavaKola.KomBrojVoza = dbo.NajavaIC.KomBrVoza AND " & _
    ''                                      "dbo.NajavaKola.KolaStavka = dbo.NajavaIC.KolaStavka " & _
    ''                                 "WHERE (dbo.NajavaKola.Realizovano = '0') AND (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
    ''                                 "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK"

    ''        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
    ''        Dim rdrIzNajave As SqlClient.SqlDataReader

    ''        tbKolauNajavi.Clear()
    ''        cbSmer1.Items.Clear()
    ''        cbSmer2.Items.Clear()
    ''        cbKolaNajava.Items.Clear()

    ''        Try
    ''            rdrIzNajave = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
    ''            Do While rdrIzNajave.Read()
    ''                tbKolauNajavi.Text = rdrIzNajave.GetInt16(0)
    ''                tbKolaRealizovano.Text = rdrIzNajave.GetInt16(1)
    ''                cbSmer1.Items.Add(rdrIzNajave.GetString(2))
    ''                cbSmer1.Text = rdrIzNajave.GetString(2)
    ''                cbSmer2.Items.Add(rdrIzNajave.GetString(3))
    ''                cbSmer2.Text = rdrIzNajave.GetString(3)
    ''                cbKolaNajava.Items.Add(rdrIzNajave.GetString(4))
    ''            Loop
    ''            rdrIzNajave.Close()
    ''            DbVeza.Close()
    ''            cbKolaNajava.Focus()
    ''        Catch ex As Exception
    ''            MsgBox(ex)
    ''        End Try

    ''        rdrIzNajave.Close()
    ''        DbVeza.Close()
    ''        cbKolaNajava.Focus()
    ''    End If
    ''End Sub

    Private Sub cbSmer2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer2.Leave
        If cbSmer2.Text = Nothing Then
            cbSmer2.Focus()
        End If

        ''If cbSmer2.Text = Nothing Or cbSmer2.Text = cbSmer1.Text Then
        ''    cbSmer2.Focus()
        ''Else
        ''    Daljinar()
        ''    If TipTranzita = "ulaz" Then
        ''        tbUpravaOtp.Focus()
        ''    Else
        ''        Me.tbIzlaznaNalepnica.Focus()
        ''    End If
        ''End If
    End Sub

    Private Sub Daljinar()
        Dim sql_text As String

        '---------------------------------------------------------------------------
        If IzborSaobracaja = "2" Then
            mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
            If Len(mManipulativnoMesto) = 5 Then
                tmp_MMStanica = mStanica2
                mStanica2 = mManipulativnoMesto
            End If
        ElseIf IzborSaobracaja = "3" Then
            mStanica1 = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
            If Len(mManipulativnoMesto) = 5 Then
                tmp_MMStanica = mStanica1
                mStanica1 = mManipulativnoMesto
            End If
        ElseIf IzborSaobracaja = "1" Then
            mStanica1 = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
        End If

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        If Int(mStanica1) < Int(mStanica2) Then
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                                     "FROM dbo.ZsDaljinar " & _
                                     "WHERE (Stanica1 = '" & mStanica1 & "') AND (Stanica2 = '" & mStanica2 & "')"

        Else
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                                     "FROM dbo.ZsDaljinar " & _
                                     "WHERE (Stanica1 = '" & mStanica2 & "') AND (Stanica2 = '" & mStanica1 & "')"

        End If

        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrDalj As SqlClient.SqlDataReader

        rdrDalj = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrDalj.Read()
            tbKm1.Text = rdrDalj.GetInt16(0)
            bTkm = tbKm1.Text
            sTkm = rdrDalj.GetInt16(1)
        Loop
        rdrDalj.Close()
        DbVeza.Close()

        If Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "3" Or Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "4" Then
            tbPrev1.Visible = True
            tbPrev2.Visible = True
        ElseIf Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "2" Then
            tbPrev1.Visible = False
            tbPrev2.Visible = False
        ElseIf Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "1" Then
            tbPrev1.Visible = False
            tbPrev2.Visible = False
        End If

    End Sub
    Private Sub cbSmer1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer1.LostFocus
        'Me.tbUlaznaNalepnica.Focus()
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

        '''Util.sNadjiNaziv("UicOperateri", Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 1, 2), Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2), "", 1, xNaziv, xPovVrednost)
        Util.sNadjiNaziv("UicOperateri", tbUpravaOtp.Text, "", "", 1, xNaziv, xPovVrednost)

        If xPovVrednost <> "" Then
            ErrorProvider1.SetError(tbUpravaOtp, "Nepostojeca uprava!")
            tbUpravaOtp.Focus()
        Else
            '''Label11.Text = xNaziv
            Label11.Text = Microsoft.VisualBasic.Mid(xNaziv, 3, Len(xNaziv))
            '''mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)
            mOtpUprava = Microsoft.VisualBasic.Left(xNaziv, 2)


            If mTarifa = "68" Then
                If Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "41" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "44" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "50" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "52" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "53" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "62" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "65" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "72" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "73" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "75" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "96" And _
                   Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2) <> "97" Then
                    'MessageBox.Show("Izabrana uprava nije propisana TEA tarifom!", "Greska u izboru uprave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    ' Da li se primenjuje TEA
                    Dim Msg As String
                    Dim Ans As MsgBoxResult

                    Msg = "Izabrana uprava nije propisana TEA tarifom! " & Chr(13)
                    Msg = Msg & " " & Chr(13)
                    Msg = Msg & "Ako postoje uslovi za primenu TEA tarife pritisnite [ Da ]" & Chr(13)
                    Msg = Msg & "u suprotnom, pritisnite [ Ne ]"""
                    Ans = MsgBox(Msg, vbYesNo + vbInformation, "TEA tarifa")

                    If Ans = vbYes Then 'Primenjuje TEA
                        mTarifa = "68"
                    Else
                        mTarifa = "36"
                    End If

                End If
            End If

            If Len(tbStanicaOtp.Text) = 7 Then

            Else
                '''tbStanicaOtp.Text = Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2)
                tbStanicaOtp.Text = mOtpUprava
                tbStanicaOtp.SelectionStart = 3
            End If
            nmNextOperater = tbUpravaOtp.Text
            ErrorProvider1.SetError(tbUpravaOtp, "")
        End If
    End Sub

    Private Sub tbStanicaOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaOtp.Validating
        If IzborSaobracaja = "3" And MasterAction = "Upd" Then
            MM_Count = MM_Count + 1
        End If

        If IzborSaobracaja = "3" And AkcijaZaPreuzimanje = "Da" Then
            MM_Count = MM_Count + 1
        End If


        If Len(tbStanicaOtp.Text) < 7 Then
            ErrorProvider1.SetError(tbStanicaOtp, "Neispravna sifra stanice!")
            tbStanicaOtp.Focus()
        Else
            Dim xNaziv As String = ""
            Dim xKB As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiStanicu("UicStanice", tbStanicaOtp.Text, "", "", mBrojPokusaja, xNaziv, xKB, xPovVrednost)
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
                mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)
                ErrorProvider1.SetError(tbStanicaOtp, "")
                If IzborSaobracaja = "3" And MM_Count > 1 Then
                    Nadzorna()
                End If
            End If

            'iskljuceno zbog operatera
            '''If Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) = Microsoft.VisualBasic.Right(tbUpravaOtp.Text, 2) Then
            '''    Util.sNadjiStanicu("UicStanice", tbStanicaOtp.Text, "", "", mBrojPokusaja, xNaziv, xKB, xPovVrednost)

            '''    If xPovVrednost <> "" Then
            '''        If mBrojPokusaja > 3 Then
            '''            mBrojPokusaja = 1
            '''            Label12.Text = "Nepostojeca sifra stanice"
            '''            mOtpStanica = tbStanicaOtp.Text
            '''            Me.tbStanicaOtp.BackColor = System.Drawing.Color.Red
            '''            ErrorProvider1.SetError(tbStanicaOtp, "")
            '''        Else
            '''            mBrojPokusaja = mBrojPokusaja + 1
            '''            ErrorProvider1.SetError(tbStanicaOtp, "Nepostojeca stanica!")
            '''            tbStanicaOtp.Focus()
            '''        End If
            '''    Else
            '''        mBrojPokusaja = 1
            '''        Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            '''        Label12.Text = xNaziv
            '''        mOtpStanica = tbStanicaOtp.Text
            '''        mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)
            '''        ErrorProvider1.SetError(tbStanicaOtp, "")
            '''        If IzborSaobracaja = "3" And MM_Count > 1 Then
            '''            Nadzorna()
            '''        End If
            '''    End If

            '''Else
            '''    ErrorProvider1.SetError(tbStanicaOtp, "Otpravna uprava i stanica nisu saglasne!")

            '''    If IzborSaobracaja = "2" Then
            '''        tbUpravaOtp.Focus()
            '''    Else
            '''        tbStanicaOtp.Focus()
            '''    End If

            '''End If
        End If
    End Sub

    Public Sub Katarina()
        Dim daPrevPut As SqlClient.SqlDataAdapter
        Dim dsPrevPut As New Data.DataSet
        Dim pomSifraPP As String
        Dim ZaCombo As String = ""

        Dim upit As String = ""
        Dim combo_linija1 As String = ""
        Dim objComm As SqlClient.SqlCommand

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        '---------------
        Dim ii As Int32 = 0
        Dim mSifraPrevPuta As String = ""
        Dim mSifra As String = ""
        Dim SamoJedanPut As String = "Da"

        cmbPrevPut.Items.Clear()
        dsPrevPut.Clear()

        If IzborSaobracaja = "2" Then
            upit = "SELECT * FROM UicPrevozniPutStavka WHERE (Uprava = '" & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & "')"
        Else
            upit = "SELECT * FROM UicPrevozniPutStavka WHERE (Uprava = '" & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & "')"
        End If

        'upit = "SELECT * FROM UicPrevozniPutStavka WHERE (Uprava = '" & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & "')"

        objComm = New SqlClient.SqlCommand(upit, OkpDbVeza)
        daPrevPut = New SqlClient.SqlDataAdapter(upit, OkpDbVeza)
        ii = daPrevPut.Fill(dsPrevPut)

        ZaCombo = ""

        Try
            pomSifraPP = dsPrevPut.Tables(0).Rows(0).Item("SifraPP")
            For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
                If dsPrevPut.Tables(0).Rows(kk).Item("SifraPP") <> pomSifraPP Then
                    If IzborSaobracaja = "2" Then
                        combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo
                    Else
                        combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
                    End If
                    'combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo
                    cmbPrevPut.Items.Add(combo_linija1)
                    ZaCombo = ""
                    SamoJedanPut = "Ne"
                Else

                End If

                mSifraPrevPuta = dsPrevPut.Tables(0).Rows(kk).Item("SifraPP")
                ZaCombo = ZaCombo & "  " & dsPrevPut.Tables(0).Rows(kk).Item("UpravaPut")
                pomSifraPP = dsPrevPut.Tables(0).Rows(kk).Item("SifraPP")

                If kk = dsPrevPut.Tables(0).Rows.Count - 1 Then
                    If IzborSaobracaja = "2" Then
                        combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo
                    Else
                        combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
                    End If
                    cmbPrevPut.Items.Add(combo_linija1)
                    SamoJedanPut = "Ne"
                End If
            Next

            If SamoJedanPut = "Da" Then
                If IzborSaobracaja = "2" Then
                    cmbPrevPut.Items.Add(mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo)
                Else
                    cmbPrevPut.Items.Add(mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo)
                End If
                'cmbPrevPut.Items.Add(mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo)
            End If

        Catch ex As Exception
            MsgBox("Nama podataka za upravu " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2))
        End Try

        OkpDbVeza.Close()

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

        '''Util.sNadjiNaziv("UicOperateri", Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 1, 2), Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2), "", 1, xNaziv, xPovVrednost)
        Util.sNadjiNaziv("UicOperateri", tbUpravaPr.Text, "", "", 1, xNaziv, xPovVrednost)

        If xPovVrednost <> "" Then
            If tbUpravaOtp.Text <> tbUpravaPr.Text Then
                ErrorProvider1.SetError(tbUpravaPr, "Nepostojeca uprava!")
            Else
                ErrorProvider1.SetError(tbUpravaPr, "Otpravna i uputna uprava moraju biti razlicite!")
            End If
            tbUpravaPr.Focus()
        Else
            '''Label14.Text = xNaziv
            Label14.Text = Microsoft.VisualBasic.Mid(xNaziv, 3, Len(xNaziv))
            '''mPrUprava = Microsoft.VisualBasic.Mid(tbStanicaPr.Text, 1, 2)
            mPrUprava = Microsoft.VisualBasic.Left(xNaziv, 2)
            If mTarifa = "68" Then
                If Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "41" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "44" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "50" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "52" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "53" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "62" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "65" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "72" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "73" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "75" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "96" And _
                   Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2) <> "97" Then
                    'MessageBox.Show("Izabrana uprava nije propisana TEA tarifom!", "Greska u izboru uprave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    ' Da li se primenjuje TEA
                    Dim Msg As String
                    Dim Ans As MsgBoxResult

                    Msg = "Izabrana uprava nije propisana TEA tarifom! " & Chr(13)
                    Msg = Msg & " " & Chr(13)
                    Msg = Msg & "Ako postoje uslovi za primenu TEA tarife pritisnite [ Da ]" & Chr(13)
                    Msg = Msg & "u suprotnom, pritisnite [ Ne ]"""
                    Ans = MsgBox(Msg, vbYesNo + vbInformation, "TEA tarifa")

                    If Ans = vbYes Then 'Primenjuje TEA
                        mTarifa = "68"
                    Else
                        mTarifa = "36"
                    End If

                End If
            End If
            If Len(tbStanicaPr.Text) = 7 Then

            Else
                '''tbStanicaPr.Text = Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2)
                tbStanicaPr.Text = mPrUprava
                tbStanicaPr.SelectionStart = 3
            End If
            nmNextOperater = tbUpravaPr.Text

            ErrorProvider1.SetError(tbUpravaPr, "")
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
        If IzborSaobracaja = "2" And MasterAction = "Upd" Then
            MM_Count = MM_Count + 1
        End If
        If IzborSaobracaja = "2" And AkcijaZaPreuzimanje = "Da" Then
            MM_Count = MM_Count + 1
        End If

        If Len(tbStanicaPr.Text) < 7 Then
            ErrorProvider1.SetError(tbStanicaPr, "Neispravna sifra stanice!")
            tbStanicaPr.Focus()
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
                mPrUprava = Microsoft.VisualBasic.Mid(tbStanicaPr.Text, 1, 2)
                ErrorProvider1.SetError(tbStanicaPr, "")

                If IzborSaobracaja = "2" And MM_Count > 1 Then
                    Nadzorna()
                End If
            End If

            'zbog operatera
            '''If Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) = Microsoft.VisualBasic.Right(tbUpravaPr.Text, 2) Then
            '''    Util.sNadjiNaziv("UicStanice", tbStanicaPr.Text, "", "", mBrojPokusaja, xNaziv, xPovVrednost)

            '''    If xPovVrednost <> "" Then
            '''        If mBrojPokusaja > 3 Then
            '''            mBrojPokusaja = 1
            '''            Label13.Text = "Nepostojeca sifra stanice"
            '''            mPrStanica = tbStanicaPr.Text
            '''            Me.tbStanicaPr.BackColor = System.Drawing.Color.Red
            '''            ErrorProvider1.SetError(tbStanicaPr, "")
            '''        Else
            '''            mBrojPokusaja = mBrojPokusaja + 1
            '''            ErrorProvider1.SetError(tbStanicaPr, "Nepostojeca stanica!")
            '''            tbStanicaPr.Focus()
            '''        End If
            '''    Else
            '''        mBrojPokusaja = 1
            '''        Me.tbStanicaPr.BackColor = System.Drawing.Color.White
            '''        Label13.Text = xNaziv
            '''        mPrStanica = tbStanicaPr.Text
            '''        mPrUprava = Microsoft.VisualBasic.Mid(tbStanicaPr.Text, 1, 2)
            '''        ErrorProvider1.SetError(tbStanicaPr, "")

            '''        If IzborSaobracaja = "2" And MM_Count > 1 Then
            '''            Nadzorna()
            '''        End If
            '''    End If

            '''Else
            '''    ErrorProvider1.SetError(tbStanicaPr, "Uputna uprava i stanica nisu saglasne!")
            '''    If IzborSaobracaja = "2" Then
            '''        tbStanicaPr.Focus()
            '''    Else
            '''        tbUpravaPr.Focus()
            '''    End If

            '''End If
        End If
    End Sub

    Private Sub DateTimePicker1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatumOtp.Leave
        mDatumKalk = DatumOtp.Value
        If IzborSaobracaja = "2" Then
            Me.tbStanicaPr.Focus()
            If Len(tbStanicaPr.Text) = 7 Then

            Else
                Me.tbStanicaPr.Text = "72"
                tbStanicaPr.SelectionStart = 3
            End If

        ElseIf IzborSaobracaja = "3" Then
            Me.tbUpravaPr.Focus()
        ElseIf IzborSaobracaja = "1" Then
            Me.tbStanicaPr.Focus()
        End If

    End Sub

    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.Leave
        If IzborSaobracaja = "1" Then
            cbFrankoPrevoznina.Focus()

        Else
            cmbPrevPut.Focus()
        End If

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

    Private Sub rb3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        '-------------------------

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
        Dim errText13 As String

        '-------------------------------- Kontrola forme --------------------------------------------
        dtError.Clear()

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

        If Me.tbStanicaPr.Text = Nothing Then
            errText10 = "Uputna stanica"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText10, "Prazno polje!"})
        End If

        If Len(Me.tbStanicaPr.Text) > 0 And Len(Me.tbStanicaPr.Text) < 7 Then
            errText10 = "Uputna stanica"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText10, "Nepotpuna sifra stanice!"})
        End If

        If IzborSaobracaja = "2" Then
            If CType(Me.tbBrojPr.Text, Int32) = 0 Then
                errText10 = "Uputna stanica"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText10, "Broj prispeca ne moze da bude nula!"})
            End If
        End If

        If bVrstaPosiljke = "K" Then
            If dtKola.Rows.Count = 0 Or dtNhm.Rows.Count = 0 Then
                errText11 = "Unos kola i robe"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText11, "Niste uneli podatke o kolima i robi!"})
            End If
        End If

        If dtUic.Rows.Count = 0 Then
            errText12 = "Unos strane uprave"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText12, "Niste uneli podatke o upravama!"})
        End If
        If Me.DatumOtp.Value > Me.DateTimePicker2.Value Then
            errText13 = "Datumi"
            dtError.NewRow()
            dtError.Rows.Add(New Object() {errText13, "Datumi nisu ispravni!"})
        End If


        If dtError.Rows.Count = 0 Then
            dgError.Visible = False
        Else
            dgError.Visible = True
        End If

        '--------------------------------- kontrola na greske i upis ------------------------------------------

        If dtError.Rows.Count = 0 Then ' nema gresaka
            'Kada upise kola iz najave u WinRoba, izmeni i u NajaviKola i NajaviVoza podatak o realizovanim kolima
            'Ako je unos voza zavrsen prekontrolise ukupnu bruto masu voza i izmeni je ukoliko prelazi propisani iznos

            Dim slogTrans As SqlTransaction
            Dim rv As String
            Dim drKola As DataRow
            Dim drNhm As DataRow
            Dim drDencane As DataRow
            Dim drNaknade As DataRow
            Dim drUic As DataRow
            Dim drK211 As DataRow

            Dim mopRecID As Int32
            Dim _prazanString As String = " "
            Dim mZsPrevozniPut As Int32 = 1
            mPrikazKalkulacije = "N"

            If Microsoft.VisualBasic.Left(Me.cbZsPrevozniPut.Text, 1) = "1" Then
                mZsPrevozniPut = 1
            ElseIf Microsoft.VisualBasic.Left(Me.cbZsPrevozniPut.Text, 1) = "2" Then
                mZsPrevozniPut = Int(mIzlaz1)
            ElseIf Microsoft.VisualBasic.Left(Me.cbZsPrevozniPut.Text, 1) = "3" Then
                mZsPrevozniPut = 3
            ElseIf Microsoft.VisualBasic.Left(Me.cbZsPrevozniPut.Text, 1) = "4" Then
                mZsPrevozniPut = 4
            End If

            mVrstaSaobracaja = Microsoft.VisualBasic.Left(Me.cbVrstaSaobracaja.Text, 1)

            '------------------------------------ Izjava o placanju ----------------------------------------------
            mSifraIzjave = 0
            If cbFrankoPrevoznina.Checked Then
                mSifraIzjave = 1
                mDoPrelaza = Me.tbFrankoPrelaz.Text
                mDoPrelaza = "0" & Microsoft.VisualBasic.Left(Me.cmbFDP.Text, 3)

                mIzjava2Deo = Me.tbFrankoPrelaz.Text
                mIzjava2Deo = "0" & Microsoft.VisualBasic.Left(Me.cmbFDP.Text, 3)
            End If
            If cbIncoterms.Checked Then
                mSifraIzjave = 2
            End If
            If cbFrankoPrevoznina.Checked = False And cbIncoterms.Checked = False Then
                mSifraIzjave = 2
            End If

            'Vraca manipulativno mesto
            If IzborSaobracaja = "2" Then
                If Len(mManipulativnoMesto) = 5 Then
                    mStanica2 = tmp_MMStanica
                End If
            ElseIf IzborSaobracaja = "3" Then
                If Len(mManipulativnoMesto) = 5 Then
                    mStanica1 = tmp_MMStanica
                End If
            End If
            '----------------------------------------- pristupa bazi ---------------------------------------------
            Try
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                End If
                slogTrans = OkpDbVeza.BeginTransaction()

                '--------------------------------------- Upis u SlogKalk ---------------------------------------------
                If MasterAction = "New" Then
                    mAkcija = "New"
                Else
                    mAkcija = "Upd"
                End If

                '----------------------------------- upis prevoznine samo na prvim kolima kompletenog voza !!! --------------------
                If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "01" Then
                    If mVrstaObracuna = "CO" Then
                        If mTabelaCena = "210" Or mTabelaCena = "211" Then
                            If CType(tbKolauVozu.Text, Int16) > 1 Then
                                mPrevoznina = 0    'prevoznina se upisuje samo na prvim kolima
                            End If
                        End If
                    End If
                Else
                    If mBrojUg = "844516" Or mBrojUg = "101206" Then
                        If CType(tbKolaRealizovano.Text, Int16) > 0 Then
                            mPrevoznina = 0        'prevoznina se upisuje samo na prvim kolima
                        End If
                    End If
                End If
                '-------------------------------------------------------------------------------------------------------------------


                '--------------------------------------------------------------------------------------------------
                Cursor.Current = New Cursor("MyWait.cur")
                'Dim moperror As Int32
                'izmenjeno franko do prelaza : Me.tbFrankoPrelaz.Text -> "0" & microsoft.VisualBasic.Left(cmbfdp.Text,3) 4.3.2009.
                'nova verzija upisa-zbog fxMask
                '! umesto upis_u_din upisuje mSumaDinari za UVOZ

                If IzborSaobracaja = 2 Then
                    Upis.UpisSlogKalkUI(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
                            tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, mObrGodina, mObrMesec, mStanica1, mUlEtiketa, _
                            Today(), _prazanString, mIzEtiketa, Today(), tbUpravaPr.Text, tbStanicaPr.Text, _
                            mPrispece, DateTimePicker2.Text, msBrojVoza, mSatVoza, mNajava, CType(mNajavaKola, Integer), "0", 0, _
                            mTarifa, mBrojUg, tbPosiljalac.Text, tbPlatilacFRR.Text, tbPrimalac.Text, tbPlatilacNFR.Text, _
                            bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, CType(mVrstaSaobracaja, Integer), mVrPrevoza, dtKola.Rows.Count, nmBrTelegram, mZsPrevozniPut, _
                            bTkm, sTkm, mSifraIzjave, mFrRacun, 0, 0, 0, 0, upis_mFrNaknade, "0" & Microsoft.VisualBasic.Left(cmbFDP.Text, 3), Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), _
                            Microsoft.VisualBasic.Mid(Me.cbIsporuka.Text, 1, 3), Me.fxIsporuka.Text, Microsoft.VisualBasic.Mid(Me.cbPouzece.Text, 1, 3), _
                            Me.fxPouzece.Text, Microsoft.VisualBasic.Mid(Me.cbVrednost.Text, 1, 3), Me.fxVrednostRobe.Text, _
                            bValuta, upis_f_suma, upis_u_suma, 0, mSumaDinari, upis_f_prev, upis_u_prev, upis_f_nak, upis_u_nak, _
                            upis_f_prev_din, upis_u_prev_din, upis_f_nak_din, upis_u_nak_din, _
                            mSumaNakCo82, mSumaNakCo, 0, (mTL_upuceno - upis_u_suma), 0, mRazlika, 0, mSifraK211, mUserID, Today(), _
                            mCarStanica, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
                            mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, _
                            UpdRecID, UpdStanicaRecID, _
                            mopRecID, rv)
                    ' (CDec(TextBox3.Text) - upis_u_suma)
                ElseIf IzborSaobracaja = 3 Then
                    Upis.UpisSlogKalkUI(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
                            tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, mObrGodina, mObrMesec, _prazanString, mUlEtiketa, _
                            Today(), mStanica2, mIzEtiketa, Today(), tbUpravaPr.Text, tbStanicaPr.Text, _
                            mPrispece, DateTimePicker2.Text, msBrojVoza, mSatVoza, mNajava, CType(mNajavaKola, Integer), "0", 0, _
                            mTarifa, mBrojUg, tbPosiljalac.Text, tbPlatilacFRR.Text, tbPrimalac.Text, tbPlatilacNFR.Text, _
                            bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, CType(mVrstaSaobracaja, Integer), mVrPrevoza, dtKola.Rows.Count, nmBrTelegram, mZsPrevozniPut, _
                            bTkm, sTkm, mSifraIzjave, mFrRacun, CDec(TextBox5.Text), _frK115, CDec(TextBox6.Text), _frK115_2, upis_mFrNaknade, "0" & Microsoft.VisualBasic.Left(cmbFDP.Text, 3), Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), _
                            Microsoft.VisualBasic.Mid(Me.cbIsporuka.Text, 1, 3), Me.fxIsporuka.Text, Microsoft.VisualBasic.Mid(Me.cbPouzece.Text, 1, 3), _
                            Me.fxPouzece.Text, Microsoft.VisualBasic.Mid(Me.cbVrednost.Text, 1, 3), Me.fxVrednostRobe.Text, _
                            bValuta, upis_f_suma, upis_u_suma, mSumaDinari, 0, upis_f_prev, upis_u_prev, upis_f_nak, upis_u_nak, _
                            upis_f_prev_din, upis_u_prev_din, upis_f_nak_din, upis_u_nak_din, _
                            mSumaNakCo82, mSumaNakCo, (mTL_franko - upis_f_suma), 0, mRazlika, 0, mBlagajnaK115, mSifraK211, mUserID, Today(), _
                            mCarStanica, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
                            mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, _
                            UpdRecID, UpdStanicaRecID, _
                            mopRecID, rv)
                End If

                ''upis_u_din IZMENJENO ZBOG IZNOSA KOD STRANIH UPRAVA

                If rv <> "" Then Throw New Exception(rv)

                If mManipulativnoMesto <> "" Then
                    mAkcija = MM_Action
                    'If AkcijaZaPreuzimanje = "Da" Then
                    '    mAkcija = MM_Action
                    'End If

                    If IzborSaobracaja = 2 Then
                        Upis.UpisSlogKalkMM(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                            mManipulativnoMesto, "", _
                                            rv)

                    ElseIf IzborSaobracaja = 3 Then
                        Upis.UpisSlogKalkMM(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                            "", mManipulativnoMesto, _
                                            rv)

                    End If

                    If rv <> "" Then Throw New Exception(rv)

                End If

                If dtK211.Rows.Count > 0 Then
                    Dim rbK211 As Int16 = 1
                    For Each drK211 In dtK211.Rows
                        If MasterAction = "New" Then
                            mAkcija = "New"
                        Else
                            If drK211("Action") = "I" Then
                                mAkcija = "New"
                            ElseIf drK211("Action") = "U" Then
                                mAkcija = "Upd"
                            ElseIf drK211("Action") = "D" Then
                                mAkcija = "Del"
                            End If
                        End If
                        Upis.UpisSlogK211(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                          rbK211, drK211("Sifra"), rv)

                        rbK211 = rbK211 + 1
                    Next
                    If rv <> "" Then Throw New Exception(rv)
                End If
                '- ----------------------------------- End Upis u SlogKalk -----------------------------------------


                '--------------------------------------- Upis u SlogKola -------------------------------------------  
                If bVrstaPosiljke = "K" Then
                    Dim rbKola As Int16 = 1
                    Dim rbRoba As Int16 = 1
                    Dim rbStanicaK As String = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)

                    If dtKola.Rows.Count > 0 Then
                        For Each drKola In dtKola.Rows

                            If MasterAction = "New" Then
                                mAkcija = "New"
                            Else
                                If drKola("Action") = "I" Then
                                    mAkcija = "New"
                                ElseIf drKola("Action") = "U" Then
                                    mAkcija = "Upd"
                                    mopRecID = UpdRecID
                                    rbStanicaK = UpdStanicaRecID
                                ElseIf drKola("Action") = "D" Then
                                    mAkcija = "Del"
                                End If
                            End If

                            If mAkcija = "New" Or mAkcija = "Upd" Then
                                Upis.UpisSlogKolaUI(slogTrans, mAkcija, mopRecID, rbStanicaK, tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, rbKola, _
                                             drKola("IndBrojKola"), drKola("KB"), drKola("Uprava"), drKola("Vlasnik"), drKola("Serija"), _
                                             drKola("Osovine"), drKola("Tara"), drKola("GrTov"), drKola("Stitna"), drKola("Tip"), drKola("Prevoznina"), _
                                             drKola("Naknada"), drKola("ICF"), rv)
                            Else


                            End If

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
                                            mopRecID = UpdRecID
                                            rbStanicaK = UpdStanicaRecID
                                        ElseIf drNhm("Action") = "D" Then
                                            mAkcija = "Del"
                                        End If
                                    End If

                                    If mAkcija = "New" Or mAkcija = "Upd" Then
                                        Upis.UpisSlogRobaUI(slogTrans, mAkcija, mopRecID, rbStanicaK, tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, _
                                                     rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
                                                     drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
                                                     drNhm("UTIBuletin"), drNhm("UTIPlombe"), drNhm("RacMasaNHM"), drNhm("VozarinskiStavNHM"), rv)
                                    ElseIf mAkcija = "Del" Then
                                        Dim nRV As Int32 = 0
                                        Upis.BrisanjeSlogRobaUI2(slogTrans, mAkcija, mopRecID, rbStanicaK, rbKola, rbRoba, rv)
                                    End If

                                    rbRoba = rbRoba + 1
                                End If
                            Next

                            '------------------------------- End Upis u SlogRoba -----------------------------------------  
                            rbKola = rbKola + 1
                            rbRoba = 1
                        Next
                        If rv <> "" Then Throw New Exception(rv)
                    End If
                    '--------------------------------------- End Upis u SlogRoba -----------------------------------------  

                Else
                    '--------------------------------------- Upis u SlogDencane ------------------------------------------
                    Dim rbDencane As Int16 = 1
                    Dim rbStanicaD As String = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)

                    For Each drDencane In dtDencane.Rows
                        If MasterAction = "New" Then
                            mAkcija = "New"
                        Else
                            If drDencane("Action") = "I" Then
                                mAkcija = "New"
                            ElseIf drDencane("Action") = "U" Then
                                mAkcija = "Upd"
                                mopRecID = UpdRecID
                                rbStanicaD = UpdStanicaRecID
                            ElseIf drDencane("Action") = "D" Then
                                mAkcija = "Del"
                            End If
                        End If

                        Upis.UpisSlogDencaneUI(slogTrans, mAkcija, mopRecID, rbStanicaD, _
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
                Dim rbStanicaN As String = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)

                If dtNaknade.Rows.Count > 0 Then
                    For Each drNaknade In dtNaknade.Rows
                        If MasterAction = "New" Then
                            mAkcija = "New"
                        Else
                            If drNaknade("Action") = "I" Then
                                mAkcija = "New"
                            ElseIf drNaknade("Action") = "U" Then
                                mAkcija = "Upd"
                                mopRecID = UpdRecID
                                rbStanicaN = UpdStanicaRecID
                            ElseIf drNaknade("Action") = "D" Then
                                mAkcija = "Del"
                            End If
                        End If

                        Upis.UpisSlogNaknadaUI(slogTrans, mAkcija, mopRecID, rbStanicaN, tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, _
                                        rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
                                        drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

                        rbNaknade = rbNaknade + 1
                    Next
                End If
                '--------------------------------------- End Upis u SlogNaknada --------------------------------------


                '------------------------------------------ Upis u SlogUic -------------------------------------------
                Dim rbUic As Int16 = 1
                Dim rbStanicaU As String = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)

                If dtUic.Rows.Count > 0 Then
                    For Each drUic In dtUic.Rows
                        If MasterAction = "New" Then
                            mAkcija = "New"
                        Else
                            If drUic("Action") = "I" Then
                                mAkcija = "New"
                            ElseIf drUic("Action") = "U" Then
                                mAkcija = "Upd"
                                mopRecID = UpdRecID
                                rbStanicaU = UpdStanicaRecID
                            ElseIf drUic("Action") = "D" Then
                                mAkcija = "Del"
                            End If
                        End If

                        Microsoft.VisualBasic.Left(cmbPrevPut.Text, 2)

                        If IzborSaobracaja = "2" Then
                            Upis.UpisSlogUicUI(slogTrans, mAkcija, mopRecID, rbStanicaU, tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, _
                                             rbUic, drUic("Uprava"), drUic("SifraGS"), Microsoft.VisualBasic.Left(cmbPrevPut.Text, 2), drUic("Ulaz"), drUic("Izlaz"), drUic("Valuta"), drUic("PF"), drUic("PU"), _
                                             drUic("Nak1"), drUic("Iznos1"), drUic("Nak2"), drUic("Iznos2"), drUic("Nak3"), drUic("Iznos3"), drUic("NF"), drUic("NU"), 0, drUic("DU"), drUic("ValPredujam"), drUic("Predujam"), _
                                             drUic("TLVal"), drUic("TLFranko"), drUic("TLUpuceno"), drUic("TLUpucenoDin"), drUic("Operater"), rv)

                        Else
                            Upis.UpisSlogUicUI(slogTrans, mAkcija, mopRecID, rbStanicaU, tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, _
                                             rbUic, drUic("Uprava"), drUic("SifraGS"), Microsoft.VisualBasic.Left(cmbPrevPut.Text, 2), drUic("Ulaz"), drUic("Izlaz"), drUic("Valuta"), drUic("PF"), drUic("PU"), _
                                             drUic("Nak1"), drUic("Iznos1"), drUic("Nak2"), drUic("Iznos2"), drUic("Nak3"), drUic("Iznos3"), drUic("NF"), drUic("NU"), drUic("DU"), 0, drUic("ValPredujam"), drUic("Predujam"), _
                                             drUic("TLVal"), drUic("TLFranko"), drUic("TLUpuceno"), 0, drUic("Operater"), rv)

                        End If
                        rbUic = rbUic + 1

                    Next
                End If
                '----------------------------------------- End Upis u SlogUic -----------------------------------------

                'PROVERI I IZBACI
                If rv = "" Then
                    slogTrans.Commit()
                Else
                    MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    slogTrans.Rollback()
                End If
                ' ------------------------------------- END upisa u Slog* -----------------------------------------


                ' -- 2.  REKAPITULACIJA ZA NAJAVE - SAMO CO  ======================================================
                If (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") And _
                    mVrstaPrevoza <> "P" And MasterAction = "New" Then

                    If OkpDbVeza.State = ConnectionState.Closed Then
                        OkpDbVeza.Open()
                    End If
                    'slogTrans = OkpDbVeza.BeginTransaction()
                    Try
                        If RecordAction <> "N" Then  ' Ako je azuriranje OkpWinRoba -  ne radi izmene u NajavaVoza,NajavaKola (vec postoji)
                            Dim KolaRed As DataRow
                            Dim _mIbk As String
                            rv = ""

                            For Each KolaRed In dtKola.Rows
                                _mIbk = KolaRed.Item("IndBrojKola")
                                If rb2.Checked = False Then
                                    Upis.NajavaUpd(slogTrans, mBrojUg, mNajava, _mIbk, rv)
                                    tbKolaRealizovano.Text = (CDec(tbKolaRealizovano.Text) + 1).ToString
                                End If
                            Next
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
                End If


                ' = UNOS SLEDECEG CIM-a ============================================================================

                ''' - Ostaje na istoj najavi za CO -----------------------------------------------------------------

                mManipulativnoMesto = ""

                If (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") And _
                    mVrstaPrevoza <> "P" And MasterAction = "New" Then

                    Dim Msg As String
                    Dim Ans As MsgBoxResult

                    If tbKolaRealizovano.Text = tbKolauNajavi.Text Then 'NAJAVA JE REALIZOVANA
                        Msg = "Najava br. " & mNajava & " je realizovana! " & Chr(13)
                        Ans = MsgBox(Msg, vbYes + vbInformation, "Poruka iz baze")

                        mNastavljaNajavu = False
                        SledeciCimIsteNajave = False
                        dtKola.Clear()
                        dtNhm.Clear()
                        dtNaknade.Clear()
                        dtUic.Clear()
                        dtUic2.Clear()

                        mPrevoznina = 0
                        LomPrev1 = 0
                        LomPrev2 = 0
                        mSumaNak = 0
                        mSumaNakRo = 0
                        upis_u_suma = 0
                        upis_f_suma = 0
                        mBlagajna = 0
                        mBlagajnaK115 = 0
                        mSumaDinari = 0

                        tbUpravaOtp.Text = ""
                        tbStanicaOtp.Text = ""
                        tbBrojOtp.Text = ""
                        tbUpravaPr.Text = ""
                        tbStanicaPr.Text = ""
                        tbBrojPr.Text = ""
                        tbKm1.Text = ""
                        cmbPrevPut.SelectedIndex = -1
                        cbFrankoPrevoznina.Checked = False
                        cbIncoterms.Checked = False
                        Me.ComboBox1.SelectedIndex = 0
                        tbPrev1.Text = 0
                        tbPrev2.Text = 0

                        tbValuta.Text = 17
                        tbPrevoznina.Text = 1
                        tbNaknade.Text = 0
                        tbTL.Text = 0
                        tbBlagajna.Text = 0
                        tbBlagajnaK115.Text = 0
                        tbRazlika.Text = 0
                        TextBox1.Text = 0
                        TextBox3.Text = 0

                        mOtpUprava = 0
                        mOtpStanica = 0
                        mOtpBroj = 0

                        mPrUprava = 0
                        mPrStanica = 0
                        Me.Dispose()

                    Else 'IZBOR: NASTAVLJA ILI PREKIDA RAD SA NAJAVOM
                        Msg = "Podaci su upisani u bazu! " & Chr(13)
                        Msg = Msg & " " & Chr(13)
                        Msg = Msg & "Ako nastavljate preuzimanje podataka po najavi br. " & mNajava & "  pritisnite [ Da ]" & Chr(13)
                        Msg = Msg & "u suprotnom, pritisnite [ Ne ]"""
                        Ans = MsgBox(Msg, vbYesNo + vbInformation, "Unos sledeceg dokumenta")

                        If Ans = vbNo Then 'PREKIDA RAD SA NAJAVOM
                            mNastavljaNajavu = False
                            SledeciCimIsteNajave = False

                            dtKola.Clear()
                            dtNhm.Clear()
                            dtNaknade.Clear()
                            dtUic.Clear()
                            dtUic2.Clear()

                            mPrevoznina = 0
                            LomPrev1 = 0
                            LomPrev2 = 0
                            mSumaNak = 0
                            mSumaNakRo = 0
                            upis_u_suma = 0
                            upis_f_suma = 0
                            mBlagajna = 0
                            mBlagajnaK115 = 0
                            mSumaDinari = 0

                            tbUpravaOtp.Text = ""
                            tbStanicaOtp.Text = ""
                            tbBrojOtp.Text = ""
                            tbUpravaPr.Text = ""
                            tbStanicaPr.Text = ""
                            tbBrojPr.Text = ""
                            tbKm1.Text = ""
                            cmbPrevPut.SelectedIndex = -1
                            cbFrankoPrevoznina.Checked = False
                            cbIncoterms.Checked = False
                            Me.ComboBox1.SelectedIndex = 0
                            tbPrev1.Text = 0
                            tbPrev2.Text = 0

                            tbValuta.Text = 17
                            tbPrevoznina.Text = 1
                            tbNaknade.Text = 0
                            tbTL.Text = 0
                            tbBlagajna.Text = 0
                            tbBlagajnaK115.Text = 0
                            tbRazlika.Text = 0
                            TextBox1.Text = 0
                            TextBox3.Text = 0

                            mOtpUprava = 0
                            mOtpStanica = 0
                            mOtpBroj = 0

                            mPrUprava = 0
                            mPrStanica = 0
                            Me.Dispose()
                        Else           ' NASTAVLJA RAD SA NAJAVOM
                            mNastavljaNajavu = True
                            SledeciCimIsteNajave = True
                            dtKola.Clear()
                            dtNhm.Clear()
                            dtNaknade.Clear()

                            mPrevoznina = 0
                            LomPrev1 = 0
                            LomPrev2 = 0
                            mSumaNak = 0
                            mSumaNakRo = 0
                            upis_u_suma = 0
                            upis_f_suma = 0
                            mBlagajna = 0
                            mBlagajnaK115 = 0
                            mSumaDinari = 0

                            tbPrevoznina.Text = 0
                            tbNaknade.Text = 0
                            tbTL.Text = 0
                            tbBlagajna.Text = 0
                            tbBlagajnaK115.Text = 0
                            tbRazlika.Text = 0
                            TextBox1.Text = 0
                            TextBox3.Text = 0

                        End If
                    End If
                Else               'NE RADI PO NAJAVI
                    mNastavljaNajavu = False
                    SledeciCimIsteNajave = False
                    dtKola.Clear()
                    dtDencane.Clear()
                    dtNhm.Clear()
                    dtNaknade.Clear()
                    dtUic.Clear()
                    dtUic2.Clear()

                    mPrevoznina = 0
                    LomPrev1 = 0
                    LomPrev2 = 0
                    mSumaNak = 0
                    mSumaNakRo = 0
                    upis_u_suma = 0
                    upis_f_suma = 0
                    mBlagajna = 0
                    mBlagajnaK115 = 0
                    mSumaDinari = 0

                    tbUpravaOtp.Text = ""
                    tbStanicaOtp.Text = ""
                    tbBrojOtp.Text = ""
                    tbUpravaPr.Text = ""
                    tbStanicaPr.Text = ""
                    tbBrojPr.Text = ""
                    tbKm1.Text = ""
                    cmbPrevPut.SelectedIndex = -1
                    cbFrankoPrevoznina.Checked = False
                    cbIncoterms.Checked = False
                    Me.ComboBox1.SelectedIndex = 0
                    tbPrev1.Text = 0
                    tbPrev2.Text = 0

                    tbValuta.Text = 17
                    tbPrevoznina.Text = 1
                    tbNaknade.Text = 0
                    tbTL.Text = 0
                    tbBlagajna.Text = 0
                    tbBlagajnaK115.Text = 0
                    tbRazlika.Text = 0
                    TextBox1.Text = 0
                    TextBox3.Text = 0

                    mOtpUprava = 0
                    mOtpStanica = 0
                    mOtpBroj = 0

                    mPrUprava = 0
                    mPrStanica = 0
                    Me.Dispose()

                End If
                ' - END Ostaje na istoj najavi za CO -------------------------------------------------------------

            Catch ex As Exception
                rv = ex.Message

                Dim Msg As String
                Dim Ans As MsgBoxResult

                If Microsoft.VisualBasic.Mid(rv, 1, 34) = "Violation of UNIQUE KEY constraint" Then
                    Msg = "Takav broj otpravljanja vec postoji u bazi podataka! " & Chr(13)
                    Msg = Msg & " " & Chr(13)
                    Msg = Msg & "Ako zelite da izmenite broj otpravljanja pritisnite [ Da ]" & Chr(13)
                    Msg = Msg & "u suprotnom, pritisnite [ Ne ]"""

                    Ans = MsgBox(Msg, vbYesNo + vbInformation, "Poruka: OkpWinRoba 200")

                    If Ans = vbNo Then 'Ne menja otpravljanje
                        m_UpdateAllowed = "No"
                    Else
                        m_UpdateAllowed = "Yes"
                    End If

                    'MessageBox.Show("Takav broj otpravljanja vec postoji u bazi podataka. Proverite ispravnost podataka.", "Nedozvoljeni upis podataka", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(rv.ToString, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch sqlex As SqlException
                ''MsgBox(sqlex.Message)
                Dim Msg As String
                Dim Ans As MsgBoxResult

                If sqlex.Number = 2627 Then
                    Msg = "Takav broj otpravljanja vec postoji u bazi podataka! " & Chr(13)
                    Msg = Msg & " " & Chr(13)
                    Msg = Msg & "Ako zelite da izmenite broj otpravljanja pritisnite [ Da ]" & Chr(13)
                    Msg = Msg & "u suprotnom, pritisnite [ Ne ]"""

                    Ans = MsgBox(Msg, vbYesNo + vbInformation, "Poruka: OkpWinRoba 200")

                    If Ans = vbNo Then 'Ne menja otpravljanje
                        m_UpdateAllowed = "No"
                    Else
                        m_UpdateAllowed = "Yes"
                    End If

                    'MessageBox.Show("Takav broj otpravljanja vec postoji u bazi podataka. Proverite ispravnost podataka.", "Nedozvoljeni upis podataka", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(sqlex.Message.ToString, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
                OkpDbVeza.Close()
                Me.tbBrojOtp.Focus()

            End Try
        Else
            ''PORUKE O GRESKAMA

        End If
    End Sub

    Private Sub UnosTrz_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'If SledeciCimIsteNajave = False Then

        If mPrikazKalkulacije = "D" Then
            If _OpenForm = "Roba" Then
                If bVrstaPosiljke = "K" Then
                    lbl_ibk.Text = mIBK
                    lbl_tara.Text = _mTara
                    lbl_nhm.Text = _mNHM
                    lbl_smasa.Text = _mSMasa
                    Me.lblEvraPoKolima.Text = _mNakPoKolima
                    lbl_TipUti.Text = _mTipUti & Chr(34)

                    If mPkola = True Then
                        lbl_PkolaProdos.Visible = True
                    Else
                        lbl_PkolaProdos.Visible = False
                    End If

                    If dtNhm.Rows.Count > 0 Then
                        If Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9922" Or Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9931" Then
                            If RTrim(fxFranko.Text) = "0" Or Len(RTrim(fxFranko.Text)) > 1 Then
                                Me.btnUnosNaknade.Focus()
                            Else
                                Me.btnUic.Focus()
                            End If
                        Else
                            Me.btnUnosNaknade.Focus()
                        End If
                    End If

                    '-------------------------------------------------------
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
                    '-------------------------------------------------------

                Else
                    Me.btnUnosNaknade.Focus()
                End If
            ElseIf _OpenForm = "Naknade" Then
                If bVrstaPosiljke = "K" Then
                    If dtNhm.Rows.Count > 0 Then
                        If Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9922" Or Microsoft.VisualBasic.Mid(dtNhm.Rows(0).Item(1), 1, 4) = "9931" Then
                            Me.btnUic.Focus()
                        Else
                            Me.btnUic.Focus()
                        End If
                    End If
                Else
                    Me.btnUic.Focus()
                End If
            ElseIf _OpenForm = "Uic" Then
                If IzborSaobracaja = "2" Then
                    Izjava() 'PROVERITI
                Else
                    Izjava_Ex() 'PROVERITI
                End If
                Me.Button3.Focus()

            ElseIf _OpenForm = "Info" Then
                If IzborSaobracaja = "2" Then
                    Me.TextBox3.Focus()
                Else
                    Me.TextBox1.Focus()
                End If
                'Me.tbBlagajna.Focus()
            Else
                tbTL.Focus()
            End If

            If bValuta = 17 Then
                tbValuta.Text = "EUR [ Euro ]" '"EUR"
            ElseIf bValuta = 72 Then
                tbValuta.Text = "RSD [ Dinar ]" '"DIN"
            ElseIf bValuta = 85 Then
                tbValuta.Text = "CHF [ Franak ]" '"CHF"
            ElseIf bValuta = 2 Then
                tbValuta.Text = "USD [ Dolar ]" '"USD"
            End If

            '--- Euro ---
            If Microsoft.VisualBasic.Left(Me.cbZsPrevozniPut.Text, 1) = "3" Or Microsoft.VisualBasic.Left(Me.cbZsPrevozniPut.Text, 1) = "4" Then
                tbPrev1.Visible = True
                tbPrev2.Visible = True

                tbPrev1.Text = Format(LomPrev1, "###,###,##0.00")
                tbPrev2.Text = Format(LomPrev2, "###,###,##0.00")
                tbPrevoznina.Text = Format(LomPrev1 + LomPrev2, "###,###,##0.00") '.ToString !! 
            Else
                tbPrev1.Visible = False
                tbPrev2.Visible = False
                tbPrevoznina.Text = Format(mPrevoznina, "###,###,##0.00") '.ToString !! 

                If IzborSaobracaja = "2" Then
                    tbTEA.Text = Format(upis_u_suma, "###,###,##0.00")
                ElseIf IzborSaobracaja = "3" Then
                    tbTEA.Text = Format(upis_f_suma, "###,###,##0.00")
                End If
            End If

            If mVrstaObracuna = "CO" Then
                tbNaknade.Text = Format(mSumaNak - mSumaNakRo, "###,###,##0.00")
            Else
                tbNaknade.Text = Format(mSumaNak, "###,###,##0.00")
            End If

            tbTL.Text = Format(mSumaDinari, "###,###,##0.00")

            If cbFrankRacun.Checked = True Then
                tbRazlika.Text = Format(mBlagajna - mSumaDinari, "###,###,##0.00")
            Else
                tbRazlika.Text = Format((mBlagajna + mBlagajnaK115) - mSumaDinari, "###,###,##0.00")
            End If
        End If

        'Else
        ''' proveriti Me.tbBrojOtp.Focus()

        'End If

    End Sub

    Private Sub tbTL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbTL.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbTL_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbTL.LostFocus
        tbTL.Text = Format(mSumaDinari, "###,###,##0.00")
    End Sub

    Private Sub btnStanicaOtp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStanicaOtp.Click
        If IzborSaobracaja = "3" Then
            helpUprava = "72"
        Else
            helpUprava = Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2)
        End If

        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UIC"
        helpUic.ShowDialog()
        ErrorProvider1.SetError(tbStanicaOtp, "")
        Me.tbStanicaOtp.Text = mIzlaz1
        Label12.Text = mIzlaz2
        mOtpStanica = tbStanicaOtp.Text
        mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)
        tbBrojOtp.Focus()

    End Sub

    Private Sub btnStanicaPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStanicaPr.Click

        'helpUprava = Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2)
        If IzborSaobracaja = "2" Then
            helpUprava = "72"
        Else
            helpUprava = Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2)
        End If

        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UIC"
        helpUic.ShowDialog()
        'Me.tbStanicaPr.Text = mIzlaz1
        ErrorProvider1.SetError(tbStanicaPr, "")
        Me.tbStanicaPr.Text = mIzlaz1

        Label13.Text = mIzlaz2
        mPrStanica = tbStanicaPr.Text
        mPrUprava = Microsoft.VisualBasic.Mid(tbStanicaPr.Text, 1, 2)
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
        mOtpDatum = DatumOtp.Value.ToShortDateString

        'mOtpDatum = DatumOtp.Value javljao gresku win7

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        LoadNajava()
        Me.tbUlaznaNalepnica.Focus()

    End Sub
    Private Sub Button5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.LostFocus
        tbUlaznaNalepnica.Focus()
    End Sub

    Private Sub tbUlaznaNalepnica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUlaznaNalepnica.Validating
        If tbUlaznaNalepnica.Text = Nothing Then
            tbUlaznaNalepnica.Focus()

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
                Else
                    ErrorProvider1.SetError(tbBrojOtp, "Neispravan unos!")
                    tbBrojOtp.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnosNaknade.Click
        If mVrstaObracuna = "CO" Or mVrstaObracuna = "IC" Then
            If mVrstaPrevoza <> "P" Then
                mNak_BrojKola = tbKolauNajavi.Text
            End If
        Else
            mNak_BrojKola = dtKola.Rows.Count
        End If

        Dim GridNaknade As New naknade
        GridNaknade.ShowDialog()

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
        ElseIf mm = "Unos robe" Then
            Dim GridKola As New kola
            GridKola.Show()
        ElseIf mm = "Unos strane uprave" Then
            Dim GridUic As New _Uic
            GridUic.Show()
        ElseIf mm = "Datumi" Then
            Dim GridUic As New _Uic
            Me.DatumOtp.Focus()
        End If
        '-------------------------------------
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace)

    End Sub

    Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim helpNalepnica As New hlpForm1
        helpNalepnica.Text = "Izmena redosleda tranzitnih nalepnica"
        helpNalepnica.ShowDialog()

    End Sub

    Private Sub tbStanicaPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.Leave
        If IzborSaobracaja = "2" Then
            If Len(tbStanicaPr.Text) < 7 Then
                ErrorProvider1.SetError(tbStanicaPr, "Neispravna sifra stanice!")
                tbStanicaPr.Focus()
            Else
                ErrorProvider1.SetError(tbStanicaPr, "")
                ''Daljinar()
            End If
        End If

    End Sub
    Private Sub UnosExIm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnUnosRobe_Click(Me, Nothing)
        ElseIf e.KeyCode = Keys.F11 Then
            Button4_Click(Me, Nothing)
        ElseIf e.KeyCode = Keys.F10 Then
            btnUic_Click(Me, Nothing)
        ElseIf e.KeyCode = Keys.F9 Then
            Button3_Click(Me, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            Dim t_IznosDin2Eur As Decimal
            Din2Eur(CDec(TextBox3.Text), t_IznosDin2Eur)
            TextBox3.Text = Format(t_IznosDin2Eur, "###,###,##0.00")

        End If

    End Sub

    Private Sub tbStanicaOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaOtp.Leave
        If IzborSaobracaja = "3" Then
            If Len(tbStanicaOtp.Text) < 7 Then
                ErrorProvider1.SetError(tbStanicaOtp, "Neispravna sifra stanice!")
                tbStanicaOtp.Focus()
            Else
                ErrorProvider1.SetError(tbStanicaOtp, "")
                ''''Daljinar()
            End If
        End If
        mOtpStanica = tbStanicaOtp.Text
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
    Private Sub cmbfdp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbFDP.KeyPress
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
            Me.tbFrankoPrelaz.Text = ""
            Me.cmbFDP.SelectedIndex = -1
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
            Me.fxFranko.Focus()
        End If
    End Sub

    Private Sub cbFrankoPrevoznina_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFrankoPrevoznina.Leave
        'Me.btnUnosRobe.Focus()

    End Sub

    Private Sub cbIncoterms_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIncoterms.Leave
        'Me.btnUnosRobe.Focus()

    End Sub

    Private Sub cbIncoterms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbIncoterms.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbFrankoPrelaz_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbFrankoPrelaz.Leave
        'If IzborSaobracaja = "3" Then
        'Me.cbFrankRacun.Focus()
        'Else
        Me.btnUnosRobe.Focus()
        'End If


    End Sub
    Private Sub cmbfdp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFDP.Leave
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
        If comboIncoterms.Text = Nothing Then
            comboIncoterms.Focus()
        Else
            '    If IzborSaobracaja = "3" Then
            '        Me.cbFrankRacun.Focus()
            '    Else
            '        Me.btnUnosRobe.Focus()
            '    End If

        End If

    End Sub

    Private Sub UnosExIm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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
                    Label11.Text = mIzlaz2
                    tbStanicaOtp.Focus()
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
            Label11.Text = mIzlaz2
            tbStanicaOtp.Focus()
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

    Private Sub Button7_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button7_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub btnUpis_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.GotFocus
        Me.btnUpis.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub btnUpis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.Leave
        Me.btnUpis.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub DatumOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DatumOtp.Validating
        Dim mRetVal As String
        Dim mRecID As Int32
        Dim mStanicaRecID As String

        mOtpDatum = Me.DatumOtp.Value.ToShortDateString

        mMesec = mOtpDatum.Month.ToString
        mDan = mOtpDatum.Day.ToString
        mGodina = mOtpDatum.Year.ToString

        If mNastavljaNajavu = True Then
            NadjiTLZaIstuNajavuUI(tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, mOtpDatum, _
                                  mRecID, mStanicaRecID, mPrUprava, mPrStanica, _
                                  mRetVal)
            If mRetVal = "" Then
                mDatumKalk = mOtpDatum 'DatumOtp.Value
                mOtpDatum = DatumOtp.Text
                tbUpravaPr.Focus()
            Else
                'ako je "Upd" ne treba da javlja poruku o istom kljucu vec samo o ostalima iz baze
                If RecordAction = "N" And UpdUprava = tbUpravaOtp.Text And UpdStanica = tbStanicaOtp.Text And UpdBroj = tbBrojOtp.Text And UpdDatum = mOtpDatum Then
                    tbUpravaPr.Focus()
                Else
                    If m_UpdateAllowed = "Yes" Then
                        btnUpis.Focus()
                    Else
                        MessageBox.Show("Takav broj otpravljanja ne postoji! ", "Poruka: WinRoba 100", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        tbBrojOtp.Focus()
                    End If

                    ''MessageBox.Show("Takav broj otpravljanja ne postoji! ", "Poruka: WinRoba 100", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ''tbBrojOtp.Focus()
                End If
            End If
        Else

            NadjiTL1(tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, mOtpDatum, mRecID, mStanicaRecID, mRetVal)

            If mRetVal = "" Then
                mDatumKalk = mOtpDatum 'DatumOtp.Value
                'mOtpDatum = DatumOtp.Text javljao gresku win7
                mOtpDatum = DatumOtp.Value.ToShortDateString()
                tbUpravaPr.Focus()
            Else
                'ako je "Upd" ne treba da javlja poruku o istom kljucu vec samo o ostalima iz baze
                mDatumKalk = mOtpDatum
                If RecordAction = "N" And UpdUprava = tbUpravaOtp.Text And UpdStanica = tbStanicaOtp.Text And UpdBroj = tbBrojOtp.Text And UpdDatum = mOtpDatum Then
                    tbUpravaPr.Focus()
                Else
                    MessageBox.Show("Takav broj otpravljanja je vec unet! ", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tbBrojOtp.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub btnUic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUic.Click
        GroupBox4_Leave(Me, Nothing)

        Me.Button3.Enabled = True
        '------------------------------------------
        If cbFrankoPrevoznina.Checked Then
            mSifraIzjave = 1
        End If
        If cbIncoterms.Checked Then
            mSifraIzjave = 2
            mIncoterms = Microsoft.VisualBasic.Left(comboIncoterms.Text, 3)
        End If
        If cbFrankoPrevoznina.Checked = False And cbIncoterms.Checked = False Then
            mSifraIzjave = 3
        End If
        '------------------------------------------

        If Me.cmbPrevPut.Text = "" Then
            MessageBox.Show("Niste izabrali prevozni put!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbPrevPut.Focus()
        Else
            If bVrstaPosiljke = "K" Then
                If dtKola.Rows.Count = 0 Then
                    MessageBox.Show("Niste uneli podatke o kolima!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    btnUnosRobe.Focus()
                Else
                    '------------------------
                    Dim tmpUicPut As String = ""
                    m_UicPrevozniPut = ""

                    tmpUicPut = Microsoft.VisualBasic.Right(cmbPrevPut.Text, Len(cmbPrevPut.Text) - 5)

                    For ii As Int16 = 1 To Len(tmpUicPut)
                        If Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1) <> " " Then
                            m_UicPrevozniPut = m_UicPrevozniPut & Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1)
                        End If
                    Next
                    '------------------------
                    mPrevoznina = CDec(tbPrevoznina.Text)

                    Dim UicTroskovi As New _Uic
                    UicTroskovi.Show()
                End If
            Else
                If dtDencane.Rows.Count = 0 Then
                    MessageBox.Show("Niste uneli podatke o dencanim posiljkama!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    btnUnosRobe.Focus()
                Else
                    '------------------------
                    Dim tmpUicPut As String = ""
                    m_UicPrevozniPut = ""

                    tmpUicPut = Microsoft.VisualBasic.Right(cmbPrevPut.Text, Len(cmbPrevPut.Text) - 5)

                    For ii As Int16 = 1 To Len(tmpUicPut)
                        If Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1) <> " " Then
                            m_UicPrevozniPut = m_UicPrevozniPut & Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1)
                        End If
                    Next
                    '------------------------
                    mPrevoznina = CDec(tbPrevoznina.Text)

                    Dim UicTroskovi As New _Uic
                    UicTroskovi.Show()

                End If
            End If
        End If
    End Sub
    Private Sub cmbPrevPut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.LostFocus
        Me.cbFrankoPrevoznina.Focus()
    End Sub

    Private Sub cmbPrevPut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPrevPut.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cmbPrevPut_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.Leave
        If cmbPrevPut.Text = Nothing Then
            cmbPrevPut.Focus()
        End If

    End Sub

    Private Sub cbSmer1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer1.Leave
        If cbSmer1.Text = Nothing Then
            cbSmer1.Focus()
        End If
    End Sub

    Private Sub cmbPrevPut_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbPrevPut.Validating

        Dim tmpUicPut As String = ""
        m_UicPrevozniPut = ""

        tmpUicPut = Microsoft.VisualBasic.Right(cmbPrevPut.Text, Len(cmbPrevPut.Text) - 5)

        For ii As Int16 = 1 To Len(tmpUicPut)
            If Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1) <> " " Then
                m_UicPrevozniPut = m_UicPrevozniPut & Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1)
            End If
        Next

        If IzborSaobracaja = "2" Then
            If Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "55" Then
                If Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "1" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "53" Then
                If Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "2" And Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "3" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "52" Then
                If Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "4" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "65" Then
                If Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "5" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "62" Then
                If Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "6" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "44" Then
                If Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "7" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "50" Then
                If Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "7" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "78" Then
                If Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "8" And Microsoft.VisualBasic.Left(cbSmer1.Text, 2) <> "10" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            End If
        Else
            If Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "55" Then
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "1" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "53" Then
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "2" And Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "3" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "52" Then
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "4" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "65" Then
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "5" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "62" Then
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "6" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "44" Then
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "7" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "50" Then
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "7" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            ElseIf Microsoft.VisualBasic.Right(m_UicPrevozniPut, 2) = "78" Then
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "8" And Microsoft.VisualBasic.Left(cbSmer2.Text, 2) <> "10" Then
                    ErrorProvider1.SetError(cmbPrevPut, "Prevozni put i granicni prelaz nisu saglasni!")
                    cmbPrevPut.Focus()
                Else
                    ErrorProvider1.SetError(cmbPrevPut, "")
                End If
            End If
        End If

        '---------------- popuniti combobox za franko do prelaza ------------------

        Button19_Click(Me, Nothing)

    End Sub
    Private Sub btnUic_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUic.GotFocus
        Me.btnUic.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub btnUic_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUic.Leave
        Me.btnUic.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub tbBrojPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojPr.Validating

        If tbBrojPr.Text = "0" Then
            ErrorProvider1.SetError(tbBrojPr, "Broj prispeca ne moze da bude nula!")
            tbBrojPr.Focus()
        Else
            If tbBrojPr.Text = Nothing Then
                ErrorProvider1.SetError(tbBrojPr, "Neispravan broj prispeca!")
                tbBrojPr.Focus()
            Else
                If IsNumeric(tbBrojPr.Text) = True Then

                    '---------------kontrola duplih prispeca za uvoz i unutrasnji
                    If IzborSaobracaja = "1" Or IzborSaobracaja = "2" Then
                        Dim mRetVal As String
                        Dim mRecID As Int32
                        Dim mStanicaRecID As String
                        If IzborSaobracaja = "1" Then
                            NadjiTLpr1(tbStanicaPr.Text, tbBrojPr.Text, mObrGodina, mRecID, mStanicaRecID, mRetVal)
                        Else
                            NadjiTLpr2(tbStanicaPr.Text, tbBrojPr.Text, mObrGodina, mRecID, mStanicaRecID, mRetVal)
                        End If


                        If mRetVal = "" Then
                            Me.DateTimePicker2.Focus()
                        Else
                            'ako je "Upd" ne treba da javlja poruku o istom kljucu vec samo o ostalima iz baze
                            If (RecordAction = "N" Or RecordAction = "P") And (UpdStanicaPr = tbStanicaPr.Text And UpdBrojPr = tbBrojPr.Text) Then
                                Me.DateTimePicker2.Focus()
                            Else
                                MessageBox.Show("Takav broj prispeca je vec unet! ", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                tbBrojPr.Focus()
                            End If
                        End If

                    Else
                        Me.DateTimePicker2.Focus()
                    End If

                    ErrorProvider1.SetError(tbBrojPr, "")
                    '------------------------------------------------------------
                Else
                    ErrorProvider1.SetError(tbBrojPr, "Neispravan unos!")
                    tbBrojPr.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub tbBrojPr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojPr.LostFocus
        If tbBrojPr.Text = Nothing Then
            mPrispece = 0
        Else
            mPrispece = tbBrojPr.Text
        End If
    End Sub
    Private Sub cmbPrevPut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.Click
        Katarina()

    End Sub

    Private Sub cmbPrevPut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.GotFocus
        Katarina()
        cmbPrevPut.DroppedDown = True
    End Sub


    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If cbRIV.Checked = True Then
            nmRIV = True
        Else
            nmRIV = False
        End If

        If MasterAction = "Upd" Then 'Or RecordAction = "P" Then 'dodato: Or RecordAction = "P"
            If IzborSaobracaja = "2" Then
                mDatumKalk = mPrDatum
            Else
                mDatumKalk = mOtpDatum
            End If
        End If

        If bVrstaPosiljke = "K" Then
            If dtKola.Rows.Count > 0 And dtNhm.Rows.Count > 0 Then
                'mDatumKalk = DatumOtp.Value
                mOtpDatum = DatumOtp.Text

                mPrUprava = Microsoft.VisualBasic.Mid(tbStanicaPr.Text, 1, 2)
                mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)

                '---------------------------
                UskladiNaknadePoKolima()     'postavi na nulu pa proverava
                '---------------------------
                UskladiNaknadeZaNaftu()      'NOVO 7.6.2011 !!!
                '---------------------------

                If Lomljena = "D" Then
                    Dim Lom_Stanica1 As String = mStanica1
                    Dim Lom_Stanica2 As String = mStanica2
                    Dim Lom_btkm As Integer = bTkm

                    mStanica2 = LomStanica
                    bTkm = Lom_btkm1

                    bNadjiPrevozninuGlavni()
                    LomPrev1 = mPrevoznina

                    mStanica1 = LomStanica
                    mStanica2 = Lom_Stanica2
                    bTkm = Lom_btkm2

                    bNadjiPrevozninuGlavni()
                    LomPrev2 = mPrevoznina

                    mStanica1 = Lom_Stanica1
                    mStanica2 = Lom_Stanica2
                    bTkm = Lom_btkm
                Else
                    bNadjiPrevozninuGlavni()
                End If

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
        Else
            If Lomljena = "D" Then
                Dim Lom_Stanica1 As String = mStanica1
                Dim Lom_Stanica2 As String = mStanica2
                Dim Lom_btkm As Integer = bTkm

                mStanica2 = LomStanica
                bTkm = Lom_btkm1

                bNadjiPrevozninuGlavni()
                LomPrev1 = mPrevoznina

                mStanica1 = LomStanica
                mStanica2 = Lom_Stanica2
                bTkm = Lom_btkm2

                bNadjiPrevozninuGlavni()
                LomPrev2 = mPrevoznina

                mStanica1 = Lom_Stanica1
                mStanica2 = Lom_Stanica2
                bTkm = Lom_btkm
            Else
                bNadjiPrevozninuGlavni()
            End If
            mPrikazKalkulacije = "D"
            _OpenForm = "Roba"
            Me.UnosTrz_Activated(Me, Nothing)
            btnUpis.Focus()

        End If



    End Sub

    Public Sub Nadzorna()
        Dim daPrevPut As SqlClient.SqlDataAdapter
        Dim dsPrevPut As New Data.DataSet
        Dim pomSifraPP As String
        Dim ZaCombo As String = ""
        Dim upit As String = ""
        Dim combo_linija1 As String = ""
        Dim objComm As SqlClient.SqlCommand

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim ii As Int32 = 0
        Dim mSifraPrevPuta As String = ""
        Dim mSifra As String = ""
        Dim SamoJedanPut As String = "Da"
        If IzborSaobracaja = "2" Then
            Me.cmbManipulativnaMestaIm.Items.Clear()
        Else
            Me.cmbManipulativnaMestaEx.Items.Clear()
        End If

        dsPrevPut.Clear()
        If IzborSaobracaja = "2" Then
            upit = "SELECT SifraStanice, Naziv FROM ZsStanice WHERE NadzornaStanicaSifra = '" & Microsoft.VisualBasic.Right(mPrStanica, 5) & "'"
        Else
            upit = "SELECT SifraStanice, Naziv FROM ZsStanice WHERE NadzornaStanicaSifra = '" & Microsoft.VisualBasic.Right(mOtpStanica, 5) & "'"
        End If

        objComm = New SqlClient.SqlCommand(upit, OkpDbVeza)
        daPrevPut = New SqlClient.SqlDataAdapter(upit, OkpDbVeza)
        ii = daPrevPut.Fill(dsPrevPut)
        ZaCombo = ""
        Try
            If ii > 0 Then
                For kk As Int16 = 0 To ii - 1
                    combo_linija1 = dsPrevPut.Tables(0).Rows(kk).Item("SifraStanice") & " - " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv")
                    If IzborSaobracaja = "2" Then
                        cmbManipulativnaMestaIm.Items.Add(combo_linija1)
                    Else
                        cmbManipulativnaMestaEx.Items.Add(combo_linija1)
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ii > 0 Then
            If IzborSaobracaja = "2" Then
                cmbManipulativnaMestaIm.Visible = True
                cmbManipulativnaMestaIm.Focus()
            Else
                cmbManipulativnaMestaEx.Visible = True
                cmbManipulativnaMestaEx.Focus()
            End If
        Else
            If IzborSaobracaja = "2" Then
                cmbManipulativnaMestaIm.Visible = False
            Else
                cmbManipulativnaMestaEx.Visible = False
            End If
        End If
        OkpDbVeza.Close()
    End Sub

    Private Sub cmbManipulativnaMestaIm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbManipulativnaMestaIm.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cmbManipulativnaMestaIm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbManipulativnaMestaIm.Leave
        tbBrojPr.Focus()

    End Sub

    Private Sub Button11_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cmbManipulativnaMestaIm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbManipulativnaMestaIm.Validating
        mManipulativnoMesto = Microsoft.VisualBasic.Mid(cmbManipulativnaMestaIm.Text, 3, 5)
        If Len(mManipulativnoMesto) = 7 Then
            tmp_MMStanica = mStanica2
            mStanica1 = mManipulativnoMesto
        End If
    End Sub

    Private Sub cmbManipulativnaMestaEx_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbManipulativnaMestaEx.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub cmbManipulativnaMestaEx_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbManipulativnaMestaEx.Leave

        tbBrojOtp.Focus()
    End Sub

    Private Sub cmbManipulativnaMestaEx_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbManipulativnaMestaEx.Validating
        mManipulativnoMesto = Microsoft.VisualBasic.Mid(cmbManipulativnaMestaEx.Text, 3, 5)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        mPrevoznina = CDec(tbPrevoznina.Text)
        '------------------------------------------
        If cbFrankoPrevoznina.Checked Then
            mSifraIzjave = 1
        End If
        If cbIncoterms.Checked Then
            mSifraIzjave = 2
            mIncoterms = Microsoft.VisualBasic.Left(comboIncoterms.Text, 3)
        End If
        If cbFrankoPrevoznina.Checked = False And cbIncoterms.Checked = False Then
            mSifraIzjave = 3
        End If
        '------------------------------------------

        If IzborSaobracaja = "2" Then
            Dim InfoPanel As New Info_Uvoz ' Info
            InfoPanel.ShowDialog()
        Else
            Dim InfoPanel As New Info_Izvoz ' Info
            InfoPanel.ShowDialog()
        End If

        ''Dim InfoPanel As New Info_Uvoz ' Info
        ''InfoPanel.ShowDialog()
    End Sub
    Private Sub GroupBox4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox4.Leave

        mUkljucujuci(0) = Microsoft.VisualBasic.Trim(Microsoft.VisualBasic.Mid(Me.fxFranko.Text, 1, 2))
        mUkljucujuci(1) = Microsoft.VisualBasic.Trim(Microsoft.VisualBasic.Mid(Me.fxFranko.Text, 4, 2))
        mUkljucujuci(2) = Microsoft.VisualBasic.Trim(Microsoft.VisualBasic.Mid(Me.fxFranko.Text, 7, 2))
        mUkljucujuci(3) = Microsoft.VisualBasic.Trim(Microsoft.VisualBasic.Mid(Me.fxFranko.Text, 10, 2))
        mUkljucujuci(4) = Microsoft.VisualBasic.Trim(Microsoft.VisualBasic.Mid(Me.fxFranko.Text, 13, 2))
        upis_mFrNaknade = mUkljucujuci(0) & mUkljucujuci(1) & mUkljucujuci(2) & mUkljucujuci(3) & mUkljucujuci(4)
        'Me.fxFranko.Text()
        'mUkljucujuci = Microsoft.VisualBasic.Trim(Me.fxFranko.Text)
        mDoPrelaza = Me.tbFrankoPrelaz.Text
        mDoPrelaza = "0" & Microsoft.VisualBasic.Left(Me.cmbFDP.Text, 3)

        If cbFrankoPrevoznina.Checked Then
            mSifraIzjave = 1
        End If
        If cbIncoterms.Checked Then
            mSifraIzjave = 2
            mIncoterms = Microsoft.VisualBasic.Left(comboIncoterms.Text, 3)
        End If
        If cbFrankoPrevoznina.Checked = False And cbIncoterms.Checked = False Then
            mSifraIzjave = 3
        End If

    End Sub
    Private Sub tbFrankoPrelaz_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbFrankoPrelaz.Validating
        If Len(tbFrankoPrelaz.Text) < 4 Then
            If Len(tbFrankoPrelaz.Text) = 0 Then
                ErrorProvider1.SetError(tbFrankoPrelaz, "")
                btnUnosRobe.Focus()
            ElseIf Len(tbFrankoPrelaz.Text) = 1 Or Len(tbFrankoPrelaz.Text) = 2 Then
                ErrorProvider1.SetError(tbFrankoPrelaz, "Neispravna sifra prelaza!")
                tbFrankoPrelaz.Focus()
            ElseIf Len(tbFrankoPrelaz.Text) = 3 Then
                tbFrankoPrelaz.Text = "0" & tbFrankoPrelaz.Text
                ErrorProvider1.SetError(tbFrankoPrelaz, "")
                btnUnosRobe.Focus()
            End If
        Else
            ErrorProvider1.SetError(tbFrankoPrelaz, "")
            btnUnosRobe.Focus()
        End If
    End Sub
    Private Sub cmbfdp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbFDP.Validating
        ErrorProvider1.SetError(cmbFDP, "")
        btnUnosRobe.Focus()
    End Sub

    Private Sub comboIncoterms_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboIncoterms.GotFocus
        comboIncoterms.DroppedDown = True
    End Sub

    Private Sub cbNajava_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tbKolauNajavi.Text = "0"
        tbKolaRealizovano.Text = "0"
    End Sub

    Private Sub cbNajava_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
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

            sql_text = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK " & _
                       "FROM dbo.NajavaVoza INNER JOIN " & _
                       "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
                       "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza " & _
                       "WHERE (dbo.NajavaKola.Realizovano = '0') AND (dbo.NajavaVoza.VrSao = '" & IzborSaobracaja & "') AND (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
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

                    cbKolaNajava.Items.Add(rdrIzNajave.GetString(4))
                Loop
                rdrIzNajave.Close()
                OkpDbVeza.Close()

            Catch ex As Exception
                MsgBox(ex)
            End Try

            rdrIzNajave.Close()
            OkpDbVeza.Close()

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

        '--------------------------------------------------------------------------------------------------------------------------------
        '   2. slucaj: izmena postojeceg sloga u bazi
        If MasterAction = "Upd" Then
            mMakis = "NN"

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

                ''If tbKolauNajavi.Text = "" And tbKolaRealizovano.Text = "" Then
                ''    MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ''    If cbNajava.Text = "0" Then
                ''        Me.btnNadjiNajavu.Focus()
                ''    Else
                ''        cbNajava.Focus()
                ''    End If
                ''ElseIf tbKolauNajavi.Text = "0" And tbKolaRealizovano.Text = "0" Then
                ''    MessageBox.Show("Najava broj: " & mNajava & " ne postoji u bazi podataka. Proverite podatke. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ''    If cbNajava.Text = "0" Then
                ''        Me.btnNadjiNajavu.Focus()
                ''    Else
                ''        cbNajava.Focus()
                ''    End If
                ''Else
                ''    If tbKolauNajavi.Text = tbKolaRealizovano.Text Then
                ''        MessageBox.Show("Najava broj: " & mNajava & " je realizovana. Unesite drugi broj najave. ", "Podaci o najavi broj :  " & mNajava, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ''        tbKolaRealizovano.Text = "0"
                ''        tbKolauNajavi.Text = "0"
                ''        cbNajava.Focus()
                ''    End If
                ''End If
            End If
        End If

        '--------------------------------------------------------------------------------------------------------------------------------
        ' 3. slucaj: unos novog sloga sa preuzimanjem

        If MasterAction = "New" And RecordAction = "P" Then
            Dim sql_NajavaVoza As String = ""

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            sql_NajavaVoza = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano " & _
                             "FROM dbo.NajavaKola INNER JOIN dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                             "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                             "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
                             "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano"

            Dim sql_comm As New SqlClient.SqlCommand(sql_NajavaVoza, OkpDbVeza)
            Dim rdrNajavaVoza As SqlClient.SqlDataReader

            tbKolauNajavi.Text = "0"
            cbKolaNajava.Items.Clear()

            Try
                rdrNajavaVoza = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdrNajavaVoza.Read()
                    tbKolauNajavi.Text = rdrNajavaVoza.GetInt16(0)
                    tbKolaRealizovano.Text = rdrNajavaVoza.GetInt16(1)
                Loop
                rdrNajavaVoza.Close()
                OkpDbVeza.Close()
                '''''''''Me.Button6.Focus()
            Catch ex As Exception
                MsgBox(ex)
            End Try

            '------------------------------------------------------------------------------------------------------
            If mRucnaNajava = "D" Then
                tbKolauNajavi.Visible = True
                tbKolaRealizovano.Visible = True
                tbKolauNajavi.Enabled = True
                tbKolaRealizovano.Enabled = True
                tbKolauNajavi.Text = mNajavaKola
                tbKolaRealizovano.Text = mNajavaKolaReal

                Me.tbKolauNajavi.Focus()
            Else
                tbKolauNajavi.Visible = True
                tbKolaRealizovano.Visible = True
                tbKolauNajavi.Enabled = False ' !!
                tbKolaRealizovano.Enabled = False '!!

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
                    Else
                        If IzborSaobracaja = "3" Then
                            Me.cbSmer2.Focus()
                        Else
                            Me.cbSmer1.Focus()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cbNajava_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNajava.Leave
        cbNajava.Text = cbNajava.Text.ToUpper()
        mMakis = "NN"
        If mRucnaNajava = "D" Then
            Me.tbKolauNajavi.Visible = True
            Me.tbKolauNajavi.Enabled = True
            Me.tbKolaRealizovano.Enabled = True
            Me.tbKolaRealizovano.Visible = True
            Me.tbKolauNajavi.Focus()
        Else
            If AkcijaZaPreuzimanje = "Ne" Then
                If IzborSaobracaja = "2" Then
                    Me.cbSmer1.Focus()
                ElseIf IzborSaobracaja = "2" Then
                    Me.cbSmer2.Focus()
                End If
                'Me.tbKolauNajavi.Focus()
            Else
                Button7.Focus()
            End If
        End If

    End Sub

    Private Sub cbNajava_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNajava.GotFocus
        tbKolauNajavi.Text = "0"
        tbKolaRealizovano.Text = "0"
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

    Private Sub btnNadjiNajavu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNadjiNajavu.Click
        mNajava = cbNajava.Text

        '   1. slucaj: unos novog sloga bez preuzimanja
        If MasterAction = "New" And RecordAction <> "P" Then
            Dim sql_text As String = ""

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

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

                    cbKolaNajava.Items.Add(rdrIzNajave.GetString(4))
                Loop
                rdrIzNajave.Close()
                OkpDbVeza.Close()

            Catch ex As Exception
                MsgBox(ex)
            End Try

            rdrIzNajave.Close()
            OkpDbVeza.Close()

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

        '   2. slucaj: izmena postojeceg sloga u bazi
        If MasterAction = "Upd" Then
            mMakis = "NN"
            Me.Button6.Focus()
        End If

        '  3. slucaj: unos novog sloga sa preuzimanjem
        If MasterAction = "New" And RecordAction = "P" Then

            Dim sql_NajavaVoza As String = ""

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            sql_NajavaVoza = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano " & _
                             "FROM   dbo.NajavaKola INNER JOIN " & _
                                    "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                                    "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                             "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
                             "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano"

            Dim sql_comm As New SqlClient.SqlCommand(sql_NajavaVoza, OkpDbVeza)
            Dim rdrNajavaVoza As SqlClient.SqlDataReader

            tbKolauNajavi.Text = "0"
            cbKolaNajava.Items.Clear()

            Try
                rdrNajavaVoza = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdrNajavaVoza.Read()
                    tbKolauNajavi.Text = rdrNajavaVoza.GetInt16(0)
                    tbKolaRealizovano.Text = rdrNajavaVoza.GetInt16(1)
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

            sql_NajavaInfo = "SELECT ObrMesec, MAX(tlPrevFr), SUM(tlPrevFR) " & _
                             "FROM dbo.SlogKalk " & _
                             "WHERE (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') " & _
                             "GROUP BY ObrMesec " & _
                             "ORDER BY MAX(tlPrevFr) DESC"

            Dim sql_commInfo As New SqlClient.SqlCommand(sql_NajavaInfo, OkpDbVeza)
            Dim rdrNajavaInfo As SqlClient.SqlDataReader

            Try
                rdrNajavaInfo = sql_commInfo.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdrNajavaInfo.Read()
                    Info_ObrMesec = rdrNajavaInfo.GetString(0)
                    'Info_ObrIzvos = rdrNajavaInfo.GetDecimal(1)
                    Info_ObrIzvos = rdrNajavaInfo.GetDecimal(2)
                Loop
                rdrNajavaInfo.Close()
                OkpDbVeza.Close()
            Catch ex As Exception
                MsgBox(ex)
            End Try

            '------------------------------------------------------------------------------------------------------
            If mRucnaNajava = "D" Then
                tbKolauNajavi.Visible = True
                tbKolaRealizovano.Visible = True
                tbKolauNajavi.Enabled = True
                tbKolaRealizovano.Enabled = True
                tbKolauNajavi.Text = mNajavaKola
                tbKolaRealizovano.Text = mNajavaKolaReal

                Me.tbKolauNajavi.Focus()
            Else
                tbKolauNajavi.Visible = True
                tbKolaRealizovano.Visible = True
                tbKolauNajavi.Enabled = True
                tbKolaRealizovano.Enabled = True

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
        End If
    End Sub

    Private Sub tbBlagajna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBlagajna.LostFocus
        mBlagajna = CDec(tbBlagajna.Text)
        tbBlagajna.Text = Format(mBlagajna, "###,###,##0.00")

        'tbBlagajna.Text = Format(mBlagajna, "###.###.##0,00")
        'tbBlagajna.Text = Format(mBlagajna, "###,###,##0.00")

        If cbFrankRacun.Checked = True Then
            Me.tbBlagajnaK115.Focus()
        Else
            mRazlika = mBlagajna - mSumaDinari
            tbRazlika.Text = Format(mRazlika, "###,###,##0.00")

            'tbRazlika.Text = Format(mBlagajna - mSumaDinari, "###,###,##0.00")

            'tbRazlika.Text = Format(mBlagajna - mSumaDinari, "###g###g##0d00")
            'tbRazlika.Text = Format(mBlagajna - mSumaDinari, "###.###.##0,00")

            If mRazlika < 0 Then
                tbRazlika.BackColor = System.Drawing.Color.Red
            ElseIf mRazlika = 0 Then
                tbRazlika.BackColor = System.Drawing.Color.Green
            ElseIf mRazlika > 0 Then
                tbRazlika.BackColor = System.Drawing.Color.Yellow
            End If
            btnUpis.Focus()

        End If

    End Sub

    Private Sub tbBlagajna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBlagajna.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbFrankRacun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFrankRacun.Click
        If Me.cbFrankRacun.Checked = True Then
            Label39.Visible = True
            Label46.Visible = True
            Label47.Visible = True
            Label48.Visible = True
            TextBox5.Visible = True
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            Label54.Visible = True
            tbBlagajnaK115.Visible = True
            TextBox5.Focus()

        Else
            Label39.Visible = False
            Label46.Visible = False
            Label47.Visible = False
            Label48.Visible = False
            TextBox5.Visible = False
            TextBox6.Visible = False
            TextBox7.Visible = False
            TextBox8.Visible = False
            Label54.Visible = False
            tbBlagajnaK115.Visible = False

        End If
    End Sub

    Private Sub cbFrankRacun_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbFrankRacun.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub TextBox5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox5.Validating
        Dim strRetVal As String = ""
        Dim mOutKurs As Decimal = 0

        NadjiKurs("17", "1", mPrDatum, mOutKurs, strRetVal)

        _frK115 = mOutKurs * CDec(TextBox5.Text)
        TextBox7.Text = Format(_frK115, "###,###,##0.00")

    End Sub

    Private Sub TextBox6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox6.Validating
        Dim strRetVal As String = ""
        Dim mOutKurs As Decimal = 0

        NadjiKurs("17", "1", mPrDatum, mOutKurs, strRetVal)

        _frK115_2 = mOutKurs * CDec(TextBox6.Text)
        TextBox8.Text = Format(_frK115_2, "###,###,##0.00")

    End Sub

    Private Sub TextBox6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.Leave
        Zs_Franko = CDec(Me.TextBox5.Text) + CDec(Me.TextBox6.Text)
        TextBox1.Text = Format(Zs_Franko, "###,###,##0.00")

        btnUnosRobe.Focus()
    End Sub

    Private Sub Button3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.GotFocus
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub Button3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Leave
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub cbZsPrevozniPut_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbZsPrevozniPut.Leave

        If Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "3" Or Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "4" Then
            tbPrev1.Visible = True
            tbPrev2.Visible = True

            Lomljena = "D"
            tbStanicaLom.Visible = True
            tbStanicaLom.Enabled = True
            tbKm2.Enabled = True
            tbKm2.Visible = True
            tbStanicaLom.Focus()

        ElseIf Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "2" Then
            tbPrev1.Visible = False
            tbPrev2.Visible = False

            Lomljena = "N"
            tbStanicaLom.Visible = False
            tbStanicaLom.Enabled = False
            tbKm2.Visible = False
            Me.Button1.Visible = True
            Button1.Focus()

        ElseIf Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "1" Then
            tbPrev1.Visible = False
            tbPrev2.Visible = False

            Lomljena = "N"
            tbStanicaLom.Visible = False
            tbStanicaLom.Enabled = False
            tbKm2.Visible = False

        End If

    End Sub

    Private Sub cbZsPrevozniPut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbZsPrevozniPut.GotFocus
        cbZsPrevozniPut.DroppedDown = True

    End Sub

    Private Sub cbZsPrevozniPut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbZsPrevozniPut.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbStanicaLom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaLom.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbKm2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbKm2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbKm2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbKm2.Leave
        Me.cmbPrevPut.Focus()
    End Sub

    Private Sub tbStanicaLom_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaLom.Leave
        tbKm1.Focus()
    End Sub

    Private Sub tbStanicaLom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaLom.Validating
        If Len(tbStanicaLom.Text) < 5 Then
            ErrorProvider1.SetError(tbStanicaLom, "Neispravna sifra stanice!")
        Else
            Dim xNaziv As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiNaziv("UicStanice", "72" & tbStanicaLom.Text, "", "", 1, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                ErrorProvider1.SetError(tbStanicaLom, "Nepostojeca stanica!")
                tbStanicaLom.Focus()
            Else
                Label52.Text = xNaziv
                LomStanica = tbStanicaLom.Text
                ErrorProvider1.SetError(tbStanicaLom, "")

                DaljinarLom()

                Lom_btkm1 = CInt(tbKm1.Text)
                Lom_btkm2 = CInt(tbKm2.Text)
            End If
        End If
    End Sub
    Private Sub DaljinarLom()
        Dim sql_text As String

        Dim mStanicaLom As String 'string 5


        '---------------------------------------------------------------------------
        If IzborSaobracaja = "1" Then
            mStanica1 = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
        ElseIf IzborSaobracaja = "2" Then
            'If Microsoft.VisualBasic.Mid(cbZsPrevozniPut.Text, 5, 5) = "3" Then
            '    mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            '    mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
            'ElseIf Microsoft.VisualBasic.Mid(cbZsPrevozniPut.Text, 5, 5) = "1" Then
            '    mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            '    mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
            'End If

            mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
            'tbStanicaLom.Text
        ElseIf IzborSaobracaja = "3" Then
            mStanica1 = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
            'tbStanicaLom.Text
        End If

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        'izmena 1.2.2011 za izvoz
        If IzborSaobracaja = "3" Then
            If Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "3" Then 'lomljen redovan
                If mManipulativnoMesto = "" Then
                    mStanicaLom = mStanica1
                Else
                    mStanicaLom = mManipulativnoMesto
                    'If IzborSaobracaja = 2 Then
                    '    mStanicaLom = mManipulativnoMesto
                    'Else
                    '    mStanicaLom = mStanica2
                    'End If
                End If
            Else
                mStanicaLom = mStanica1
            End If
            'end izmena 1.2.2011
        Else
            mStanicaLom = mStanica1
        End If


        'If Int(mStanica1) < Int(tbStanicaLom.Text) Then
        If Int(mStanicaLom) < Int(tbStanicaLom.Text) Then
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                       "FROM dbo.ZsDaljinar " & _
                       "WHERE (Stanica1 = '" & mStanicaLom & "') AND (Stanica2 = '" & tbStanicaLom.Text & "')"
            '"WHERE (Stanica1 = '" & mStanica1 & "') AND (Stanica2 = '" & tbStanicaLom.Text & "')"
        Else
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                       "FROM dbo.ZsDaljinar " & _
                       "WHERE (Stanica1 = '" & tbStanicaLom.Text & "') AND (Stanica2 = '" & mStanicaLom & "')"
            '"WHERE (Stanica1 = '" & tbStanicaLom.Text & "') AND (Stanica2 = '" & mStanica1 & "')"
        End If

        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrDalj As SqlClient.SqlDataReader

        rdrDalj = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrDalj.Read()
            tbKm1.Text = rdrDalj.GetInt16(0)
            'bTkm = tbKm1.Text
            'sTkm = rdrDalj.GetInt16(1)

        Loop
        rdrDalj.Close()
        DbVeza.Close()

        '2.deo
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        'izmena 1.2.2011
        If IzborSaobracaja = "2" Then
            If Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "3" Then 'lomljen redovan
                If mManipulativnoMesto = "" Then
                    mStanicaLom = mStanica2
                Else
                    mStanicaLom = mManipulativnoMesto
                    'If IzborSaobracaja = 2 Then
                    '    mStanicaLom = mManipulativnoMesto
                    'Else
                    '    mStanicaLom = mStanica2
                    'End If
                End If
            Else
                mStanicaLom = mStanica2
            End If
        Else
            mStanicaLom = mStanica2
        End If
        'end izmena 1.2.2011

        'If Int(tbStanicaLom.Text) < Int(mStanica2) Then
        If Int(tbStanicaLom.Text) < Int(mStanicaLom) Then
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                       "FROM dbo.ZsDaljinar " & _
                       "WHERE (Stanica1 = '" & tbStanicaLom.Text & "') AND (Stanica2 = '" & mStanicaLom & "')"
            '"WHERE (Stanica1 = '" & tbStanicaLom.Text & "') AND (Stanica2 = '" & mStanica2 & "')"

        Else
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                       "FROM dbo.ZsDaljinar " & _
                       "WHERE (Stanica1 = '" & mStanicaLom & "') AND (Stanica2 = '" & tbStanicaLom.Text & "')"
            '"WHERE (Stanica1 = '" & mStanica2 & "') AND (Stanica2 = '" & tbStanicaLom.Text & "')"

        End If

        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrDalj1 As SqlClient.SqlDataReader

        rdrDalj1 = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrDalj1.Read()
            tbKm2.Text = rdrDalj1.GetInt16(0)
            'bTkm = tbKm1.Text
            'sTkm = rdrDalj.GetInt16(1)

        Loop
        rdrDalj1.Close()
        DbVeza.Close()


    End Sub
    Private Sub cbZsPrevozniPut_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbZsPrevozniPut.SelectedValueChanged
        tbStanicaLom.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim helpNak As New HelpForm
        helpNak.Text = "help Naknade"
        upit = "VPP"
        helpNak.ShowDialog()
        Me.tbKm1.Text = mIzlaz2
        bTkm = Me.tbKm1.Text
        sTkm = CInt(mIzlaz3)

        Me.tbKm1.Focus()

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim frmK211 As New FormK211
        frmK211.ShowDialog()
    End Sub

    Private Sub tbKm1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbKm1.Leave
        bTkm = Me.tbKm1.Text

        If Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "1" Or Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "2" Then
            cmbPrevPut.Focus()
        ElseIf Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "3" Then
            tbKm2.Focus()
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        tbTL.Text = Format(mSumaDinari, "###,###,##0.00")
        tbRazlika.Text = Format(mSumaDinari - mPrevoznina - mSumaNak, "###,###,##0.00")
        tbPrevoznina.Text = Format(mPrevoznina, "###,###,##0.00") '.ToString !! 

    End Sub

    Private Sub tbBlagajnaK115_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBlagajnaK115.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbBlagajnaK115_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBlagajnaK115.LostFocus

        'mBlagajnaK115 = CDec(tbBlagajnaK115.Text)
        'tbBlagajna.Text = Format(mBlagajnaK115, "###,###,##0.00")
        'tbRazlika.Text = Format((mBlagajna + mBlagajnaK115) - mSumaDinari, "###,###,##0.00")

        'If tbRazlika.Text < 0 Then
        '    tbRazlika.BackColor = System.Drawing.Color.Red
        'ElseIf tbRazlika.Text = 0 Then
        '    tbRazlika.BackColor = System.Drawing.Color.Green
        'ElseIf tbRazlika.Text > 0 Then
        '    tbRazlika.BackColor = System.Drawing.Color.Yellow
        'End If

        'btnUpis.Focus()

        mBlagajnaK115 = CDec(tbBlagajnaK115.Text)
        tbBlagajnaK115.Text = Format(mBlagajnaK115, "###,###,##0.00")
        'tbRazlika.Text = Format((mBlagajna + mBlagajnaK115) - mSumaDinari, "###,###,##0.00")
        mRazlika = (mBlagajna + mBlagajnaK115) - mSumaDinari
        tbRazlika.Text = Format(mRazlika, "###,###,##0.00")

        'If CDec(tbRazlika.Text) < 0 Then
        '    tbRazlika.BackColor = System.Drawing.Color.Red
        'ElseIf CDec(tbRazlika.Text) = 0 Then
        '    tbRazlika.BackColor = System.Drawing.Color.Green
        'ElseIf CDec(tbRazlika.Text) > 0 Then
        '    tbRazlika.BackColor = System.Drawing.Color.Yellow
        'End If

        If mRazlika < 0 Then
            tbRazlika.BackColor = System.Drawing.Color.Red
        ElseIf mRazlika = 0 Then
            tbRazlika.BackColor = System.Drawing.Color.Green
        ElseIf mRazlika > 0 Then
            tbRazlika.BackColor = System.Drawing.Color.Yellow
        End If

        btnUpis.Focus()

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        mBlagajnaK115 = CDec(tbBlagajnaK115.Text)
        tbBlagajnaK115.Text = Format(mBlagajnaK115, "###.###.##0,00")
        'tbRazlika.Text = Format((mBlagajna + mBlagajnaK115) - mSumaDinari, "###,###,##0.00")
        tbRazlika.Text = Format((mBlagajna + mBlagajnaK115) - mSumaDinari, "###.###.##0,00")

        If CDec(tbRazlika.Text) < 0 Then
            tbRazlika.BackColor = System.Drawing.Color.Red
        ElseIf CDec(tbRazlika.Text) = 0 Then
            tbRazlika.BackColor = System.Drawing.Color.Green
        ElseIf CDec(tbRazlika.Text) > 0 Then
            tbRazlika.BackColor = System.Drawing.Color.Yellow
        End If

        btnUpis.Focus()

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Katarina()

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        mTL_franko = CDec(Me.TextBox1.Text)
        TextBox1.Text = Format(mTL_franko, "###,###,##0.00")
        tbBlagajna.Focus()
    End Sub

    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        mTL_upuceno = CDec(Me.TextBox3.Text)
        TextBox3.Text = Format(mTL_upuceno, "###,###,##0.00")
        tbBlagajna.Focus()
    End Sub

    Private Sub tbStanicaOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaOtp.GotFocus
        If mOtpStanica <> "" Then
            Me.tbStanicaOtp.Text = mOtpStanica
        Else
            If IzborSaobracaja = "1" Or IzborSaobracaja = "3" Then
                Me.tbStanicaOtp.Text = "72"
                Me.tbStanicaOtp.SelectionStart = 3
            End If
        End If
    End Sub


    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Me.Button1.Visible = False
        tbRazlika.BackColor = System.Drawing.Color.White
        FormatErrGrid()
        Me.cmbManipulativnaMestaEx.Visible = False
        Me.cmbManipulativnaMestaIm.Visible = False
        '---------------------------------------------------
        lbl_ibk.Text = mIBK
        lbl_tara.Text = _mTara
        lbl_nhm.Text = _mNHM
        lbl_smasa.Text = _mSMasa

        tbUpravaOtp.Text = mOtpUprava
        tbStanicaOtp.Text = mOtpStanica
        tbBrojOtp.Text = mOtpBroj
        DatumOtp.Text = mOtpDatum

        tbUpravaPr.Text = mPrUprava
        tbStanicaPr.Text = mPrStanica
        GroupBox7.Visible = False

        tbKolauNajavi.Visible = False
        tbKolaRealizovano.Visible = False
        cbZsPrevozniPut.SelectedIndex = 0

        Me.ComboBox1.Text = "EUR Euro"

        If IzborSaobracaja = 2 Then ' UVOZ
            cbFrankRacun.Visible = False
            Label53.Text = "K165"

            cbVrstaSaobracaja.Items.Clear()
            cbVrstaSaobracaja.Items.Add("2 Uvoz")
            cbVrstaSaobracaja.Items.Add("4 Suvozemni tranzit")
            cbVrstaSaobracaja.Items.Add("5 Lucki tranzit (Otp.Uprava - Luka)")
            cbVrstaSaobracaja.Items.Add("6 Lucki tranzit (Luka - Otp.Uprava)")
            cbVrstaSaobracaja.Items.Add("7 Tranzit (drum - zeleznica)")
            cbVrstaSaobracaja.Items.Add("8 Tranzit (zeleznica - drum)")
            cbVrstaSaobracaja.Text = "2 Uvoz"
            Me.cbSmer1.Visible = True
            Me.cbSmer1.Enabled = True
            Me.cbSmer1.Text = mStanica1
            cbSmer2.Visible = False

            Label32.Visible = False
            Label33.Visible = True
            Me.btnUpravaPr.Enabled = False
            Me.tbUpravaPr.Text = "0072"
            Me.tbUpravaPr.Enabled = False
            Me.Label14.Text = "ZS"
            Me.tbBrojPr.Enabled = True
            Label17.Text = "Datum ulaska"
            Label15.Enabled = True
            Label17.Enabled = True

            GroupBox10.Text = " [ Ulazni prelaz ] "

        ElseIf IzborSaobracaja = 3 Then ' IZVOZ
            cbFrankRacun.Visible = True
            Label53.Text = "K140"

            cbVrstaSaobracaja.Items.Clear()
            cbVrstaSaobracaja.Items.Add("3 Izvoz")
            cbVrstaSaobracaja.Items.Add("4 Suvozemni tranzit")
            cbVrstaSaobracaja.Items.Add("5 Lucki tranzit (Otp.Uprava - Luka)")
            cbVrstaSaobracaja.Items.Add("6 Lucki tranzit (Luka - Otp.Uprava)")
            cbVrstaSaobracaja.Items.Add("7 Tranzit (drum - zeleznica)")
            cbVrstaSaobracaja.Items.Add("8 Tranzit (zeleznica - drum)")
            cbVrstaSaobracaja.Text = "3 Izvoz"

            cbSmer1.Visible = False
            Label32.Visible = True
            Label33.Visible = False
            cbSmer2.Visible = True
            cbSmer2.Enabled = True
            Me.cbSmer2.Text = mStanica2

            'Me.cbSmer2.Text = StanicaUnosa

            Me.tbUpravaOtp.Text = "0072"
            '''Me.tbStanicaOtp.Text = "72"
            '''Me.tbStanicaOtp.SelectionStart = 3
            Me.tbUpravaOtp.Enabled = False
            Label11.Text = "ZS"
            Me.tbBrojPr.Visible = False
            Label15.Visible = False
            Label17.Visible = True

            GroupBox10.Text = " [ Izlazni prelaz ] "

        End If

        'dodati uslov ako je azuriranje!
        ''VRATITI popravljeno
        ''Daljinar()
        ''Katarina()
        ''cmbPrevPut.SelectedIndex = 0

        ''cmbPrevPut_Validating(Me, Nothing)
        '---------------------------------------------------

        If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then
            If mVrstaPrevoza <> "P" Then
                Me.cbNajava.Enabled = True
                Me.tbKolaRealizovano.Visible = True
                Me.tbKolauNajavi.Visible = True
                Me.tbKolaRealizovano.Enabled = True
                Me.tbKolauNajavi.Enabled = True
                Me.cbNajava.Focus()
            Else
                Me.cbNajava.Enabled = False
                If IzborSaobracaja = 2 Then
                    Me.cbSmer1.Focus()
                ElseIf IzborSaobracaja = 3 Then
                    Me.cbSmer2.Focus()
                End If
            End If
        End If

        Me.gb_Info.Visible = True
        If MasterAction = "Upd" Then 'Or RecordAction = "P" Then 'dodato: Or RecordAction = "P"
            Me.gb_Info.Visible = False
            Me.cbSmer1.Text = mStanica1
            Me.tbUpravaOtp.Text = mOtpUprava
            Me.tbStanicaOtp.Text = mOtpStanica
            Me.tbBrojOtp.Text = mOtpBroj
            Me.DatumOtp.Value = mOtpDatum
            Me.tbUpravaPr.Text = mPrUprava
            Me.tbStanicaPr.Text = mPrStanica

            If mVrstaPrevoza <> "P" Then
                cbNajava.Text = mNajava
            Else
                cbKolaNajava.Enabled = False
                cbNajava.Enabled = False
            End If

            tbStanicaLom.Text = LomStanica
            If mManipulativnoMesto <> "" Then
                If IzborSaobracaja = 2 Then
                    cmbManipulativnaMestaIm.Visible = True
                    cmbManipulativnaMestaIm.Text = mManipulativnoMesto
                Else
                    cmbManipulativnaMestaIm.Visible = False
                    cmbManipulativnaMestaEx.Text = mManipulativnoMesto
                End If
            End If
            If mSifraIzjave = 1 Then
                Me.cbFrankoPrevoznina.Checked = True
                Me.cbIncoterms.Checked = False
                Me.fxFranko.Text = ""
                ''Me.fxFranko.Text = mUkljucujuci
                If Len(upis_mFrNaknade) < 2 Then
                    Me.fxFranko.Text = upis_mFrNaknade
                Else
                    For abc As Int16 = 1 To Len(upis_mFrNaknade) Step 2
                        Me.fxFranko.Text = Me.fxFranko.Text & Microsoft.VisualBasic.Mid(upis_mFrNaknade, abc, 2)
                    Next
                End If
                Me.tbFrankoPrelaz.Text = mDoPrelaza
                Me.cmbFDP.Text = mDoPrelaza

            Else
                Me.cbFrankoPrevoznina.Checked = False
                Me.cbIncoterms.Checked = True

                If mIncoterms = "EXW" Then
                    Me.comboIncoterms.SelectedIndex = 0
                ElseIf mIncoterms = "FCA" Then
                    Me.comboIncoterms.SelectedIndex = 1
                ElseIf mIncoterms = "CPT" Then
                    Me.comboIncoterms.SelectedIndex = 2
                ElseIf mIncoterms = "CIP" Then
                    Me.comboIncoterms.SelectedIndex = 3
                ElseIf mIncoterms = "DAF" Then
                    Me.comboIncoterms.SelectedIndex = 4
                ElseIf mIncoterms = "DDU" Then
                    Me.comboIncoterms.SelectedIndex = 5
                ElseIf mIncoterms = "DDP" Then
                    Me.comboIncoterms.SelectedIndex = 6
                End If
            End If
        Else
            If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then ' ugovor centralni obracun
                If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "01" Then
                    gbKolauVozu.Visible = True
                    tbKolauVozu.Text = "1"
                Else
                    gbKolauVozu.Visible = False
                End If

                If mVrstaPrevoza <> "P" Then ' grupa ili voz => moze da pozove najavu

                    Me.btnNajava.Enabled = True
                    Me.cbNajava.Enabled = True
                    Me.Label2.Enabled = True
                    Me.cbKolaNajava.Enabled = True
                    Me.GroupBox3.Enabled = True

                    Me.tbKolaRealizovano.Visible = True
                    Me.tbKolauNajavi.Visible = True
                    Me.tbKolaRealizovano.Enabled = True
                    Me.tbKolauNajavi.Enabled = True

                    ''PRIVREMENO - ZBOG TESTA!!!
                    ''If OkpDbVeza.State = ConnectionState.Closed Then
                    ''    OkpDbVeza.Open()
                    ''End If

                    ''Dim sql_text As String = "SELECT dbo.NajavaVoza.KomBrojVoza " & _
                    ''                         "FROM dbo.NajavaKola INNER JOIN " & _
                    ''                         "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                    ''                         "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                    ''                         "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') " & _
                    ''                         "GROUP BY dbo.NajavaVoza.KomBrojVoza "

                    ''Dim sql_comm As New SqlClient.SqlCommand(sql_text, OkpDbVeza)
                    ''Dim rdrUg As SqlClient.SqlDataReader
                    ''Dim combo_linija As String = ""

                    ''cbNajava.Items.Clear()
                    ''rdrUg = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                    ''Do While rdrUg.Read()
                    ''    combo_linija = rdrUg.GetString(0)
                    ''    cbNajava.Items.Add(combo_linija)
                    ''Loop

                    ''If cbNajava.Items.Count = 0 Then
                    ''    Me.GroupBox11.Enabled = True
                    ''    Me.cbNajava.Enabled = True
                    ''    Me.cbKolaNajava.Enabled = False
                    ''    Me.Button5.Enabled = False
                    ''    Me.Label2.Enabled = False
                    ''    Me.cbKolaNajava.Enabled = False
                    ''    Me.GroupBox3.Enabled = True
                    ''    Me.cbNajava.Focus()
                    ''End If
                    ''rdrUg.Close()
                    ''OkpDbVeza.Close()

                Else
                    Me.btnNajava.Enabled = False
                    Me.cbNajava.Enabled = False
                    Me.Label2.Enabled = False
                    Me.cbKolaNajava.Enabled = False
                    Me.GroupBox3.Enabled = True
                End If
            Else
                Me.btnNajava.Enabled = False
                Me.cbNajava.Enabled = False
                Me.Label2.Enabled = False
                Me.cbKolaNajava.Enabled = False
                Me.GroupBox3.Enabled = True
            End If
        End If

    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        mNajava = cbNajava.Text

        '   1. slucaj: unos novog sloga bez preuzimanja
        If MasterAction = "New" And RecordAction <> "P" Then
            Dim sql_text As String = ""

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            sql_text = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano, dbo.NajavaVoza.Stanica1, dbo.NajavaVoza.Stanica2, dbo.NajavaKola.IBK " & _
                       "FROM dbo.NajavaVoza INNER JOIN " & _
                       "dbo.NajavaKola ON dbo.NajavaVoza.BrUgovora = dbo.NajavaKola.BrUgovora AND " & _
                       "dbo.NajavaVoza.KomBrojVoza = dbo.NajavaKola.KomBrojVoza " & _
                       "WHERE (dbo.NajavaKola.Realizovano = '0') AND (dbo.NajavaVoza.VrSao = '" & IzborSaobracaja & "') AND (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
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

                    cbKolaNajava.Items.Add(rdrIzNajave.GetString(4))
                Loop
                rdrIzNajave.Close()
                OkpDbVeza.Close()

            Catch ex As Exception
                MsgBox(ex)
            End Try

            rdrIzNajave.Close()
            OkpDbVeza.Close()

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

        '   2. slucaj: izmena postojeceg sloga u bazi
        If MasterAction = "Upd" Then
            mMakis = "NN"

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
        End If

        '  3. slucaj: unos novog sloga sa preuzimanjem
        If MasterAction = "New" And RecordAction = "P" Then


            Dim sql_NajavaVoza As String = ""

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            sql_NajavaVoza = "SELECT dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano " & _
                             "FROM   dbo.NajavaKola INNER JOIN " & _
                                    "dbo.NajavaVoza ON dbo.NajavaKola.BrUgovora = dbo.NajavaVoza.BrUgovora AND " & _
                                    "dbo.NajavaKola.KomBrojVoza = dbo.NajavaVoza.KomBrojVoza " & _
                             "WHERE (dbo.NajavaVoza.BrUgovora = '" & mBrojUg & "') AND (dbo.NajavaVoza.KomBrojVoza = '" & mNajava & "') " & _
                             "GROUP BY dbo.NajavaVoza.SumaKola, dbo.NajavaVoza.Realizovano"

            Dim sql_comm As New SqlClient.SqlCommand(sql_NajavaVoza, OkpDbVeza)
            Dim rdrNajavaVoza As SqlClient.SqlDataReader

            tbKolauNajavi.Text = "0"
            cbKolaNajava.Items.Clear()

            Try
                rdrNajavaVoza = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdrNajavaVoza.Read()
                    tbKolauNajavi.Text = rdrNajavaVoza.GetInt16(0)
                    tbKolaRealizovano.Text = rdrNajavaVoza.GetInt16(1)
                Loop
                rdrNajavaVoza.Close()
                OkpDbVeza.Close()
                '''''''''Me.Button6.Focus()
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

            sql_NajavaInfo = "SELECT ObrMesec, MAX(tlPrevFr), SUM(tlPrevFR) " & _
                             "FROM dbo.SlogKalk " & _
                             "WHERE (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') " & _
                             "GROUP BY ObrMesec " & _
                             "ORDER BY MAX(tlPrevFr) DESC"

            Dim sql_commInfo As New SqlClient.SqlCommand(sql_NajavaInfo, OkpDbVeza)
            Dim rdrNajavaInfo As SqlClient.SqlDataReader

            Try
                rdrNajavaInfo = sql_commInfo.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdrNajavaInfo.Read()
                    Info_ObrMesec = rdrNajavaInfo.GetString(0)
                    'Info_ObrIzvos = rdrNajavaInfo.GetDecimal(1)
                    Info_ObrIzvos = rdrNajavaInfo.GetDecimal(2)
                Loop
                rdrNajavaInfo.Close()
                OkpDbVeza.Close()
            Catch ex As Exception
                MsgBox(ex)
            End Try

            '------------------------------------------------------------------------------------------------------
            If mRucnaNajava = "D" Then
                tbKolauNajavi.Visible = True
                tbKolaRealizovano.Visible = True
                tbKolauNajavi.Enabled = True
                tbKolaRealizovano.Enabled = True
                tbKolauNajavi.Text = mNajavaKola
                tbKolaRealizovano.Text = mNajavaKolaReal

                Me.tbKolauNajavi.Focus()
            Else
                tbKolauNajavi.Visible = True
                tbKolaRealizovano.Visible = True
                tbKolauNajavi.Enabled = False ' !!
                tbKolaRealizovano.Enabled = False '!!

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
                    Else
                        If IzborSaobracaja = "3" Then
                            Me.cbSmer2.Focus()
                        Else
                            Me.cbSmer1.Focus()
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub DateTimePicker2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker2.Validating
        If IzborSaobracaja = "2" Then
            mPrDatum = Me.DateTimePicker2.Value.ToShortDateString
        End If

        ''mMesec = mOtpDatum.Month.ToString
        ''mDan = mOtpDatum.Day.ToString
        ''mGodina = mOtpDatum.Year.ToString

    End Sub

    Private Sub UnosExIm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        If RecordAction = "P" Then
            Dim formPreuzmi As New UpdateForm
            formPreuzmi.Text = ":: PREUZIMANJE PODATAKA SA GRANICNOG PRELAZA! ::"
            formPreuzmi.ShowDialog()
        ElseIf RecordAction = "N" Then
            Dim formPreuzmi As New UpdateForm
            formPreuzmi.Text = ":: IZMENA POSTOJECIH PODATAKA U BAZI! ::"
            formPreuzmi.ShowDialog()
        End If

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Daljinar()

    End Sub

    Private Sub tbBrojOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.Leave
        If IzborSaobracaja = "3" Then
            Daljinar()
        End If

    End Sub

    Private Sub tbBrojPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojPr.Leave
        If IzborSaobracaja = "1" Or IzborSaobracaja = "2" Then
            Daljinar()

        End If
    End Sub
    Private Sub tbPrevoznina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrevoznina.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrevoznina_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPrevoznina.Leave
        Me.btnUic.Focus()

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "Sifre korisnika"
        upit = "Primalac"
        helpUic.ShowDialog()

        Me.tbPrimalac.Text = mIzlaz1
        'Label12.Text = mIzlaz2
        btnUpis.Focus()
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "Sifre korisnika"
        upit = "Posiljalac"
        helpUic.ShowDialog()

        Me.tbPosiljalac.Text = mIzlaz1
        'Label12.Text = mIzlaz2
        btnUpis.Focus()
    End Sub

    Private Sub tbStanicaPr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.GotFocus
        If IzborSaobracaja = "1" Then
            Me.tbStanicaPr.Text = "72"
            Me.tbStanicaPr.SelectionStart = 3
        End If

    End Sub

    Private Sub cbVrstaSaobracaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbVrstaSaobracaja.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbVrstaSaobracaja_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbVrstaSaobracaja.Validating
        Me.btnUnosRobe.Focus()

    End Sub

    Private Sub tbPrev1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrev1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrev2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrev2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrev2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPrev2.LostFocus
        LomPrev2 = CDec(Me.tbPrev2.Text)
        tbPrev2.Text = Format(LomPrev2, "###,###,##0.00")
        tbPrevoznina.Text = Format(LomPrev1 + LomPrev2, "###,###,##0.00")
        Me.Button3.Focus()

    End Sub

    Private Sub tbPrev1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPrev1.LostFocus
        LomPrev1 = CDec(Me.tbPrev1.Text)
        tbPrev1.Text = Format(LomPrev1, "###,###,##0.00")
        tbPrev2.Focus()

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        'm_UicPrevozniPut = "80815572"

        Dim daPrevPut As SqlClient.SqlDataAdapter
        Dim dsPrevPut As New Data.DataSet
        Dim upit As String = ""
        Dim combo_linija1 As String = ""
        Dim objComm As SqlClient.SqlCommand
        Dim ii As Int32 = 0
        Dim nm_UicPrevozniPut As String

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Me.cmbFDP.Items.Clear()
        nm_UicPrevozniPut = m_UicPrevozniPut & "72"

        Dim nm_FrDoPrelaza, mUpr1, mUpr2 As String

        cmbFDP.Items.Add(" ")

        For kk As Int16 = 0 To Len(m_UicPrevozniPut) / 2 - 1
            dsPrevPut.Clear()
            nm_FrDoPrelaza = Microsoft.VisualBasic.Mid(nm_UicPrevozniPut, 2 * kk + 1, 4)
            mUpr1 = Microsoft.VisualBasic.Left(nm_FrDoPrelaza, 2)
            mUpr2 = Microsoft.VisualBasic.Right(nm_FrDoPrelaza, 2)

            upit = "SELECT SifraPrelaza, Naziv " & _
                   "FROM   UicPrelazi " & _
                   "WHERE  (Uprava1 = '" & mUpr1 & "') AND (Uprava2 = '" & mUpr2 & "') AND (LEFT(SifraPrelaza, 1) = '0')"

            objComm = New SqlClient.SqlCommand(upit, DbVeza)
            daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)
            ii = daPrevPut.Fill(dsPrevPut)

            For jj As Int16 = 0 To ii - 1
                combo_linija1 = Microsoft.VisualBasic.Right(dsPrevPut.Tables(0).Rows(jj).Item("SifraPrelaza"), 3) & " - " & dsPrevPut.Tables(0).Rows(jj).Item("Naziv")
                If mUpr2 = "72" Then
                    cmbFDP.Items.Insert(1, combo_linija1)
                Else
                    cmbFDP.Items.Add(combo_linija1)
                End If

            Next

        Next


    End Sub

    Private Sub cmbManipulativnaMestaIm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbManipulativnaMestaIm.Click
        Nadzorna()

    End Sub
  
End Class
