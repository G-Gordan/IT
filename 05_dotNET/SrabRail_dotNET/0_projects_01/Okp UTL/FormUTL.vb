Imports Microsoft.VisualBasic
Imports CrystalDecisions.Shared
Imports System.Xml.Serialization
Imports System.IO
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.Collections
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Globalization


Public Class FormUTL
    Inherits System.Windows.Forms.Form
    Public mBrojPokusaja As Int16 = 1
    Public ErrKontrola As String = "NO"
    Public tmpUgovor As String = ""
    Public _ForNum As Int16 = 0
    Public NumNizR50 As Int16 = 0
    Public SourceFile As String
    Public m_Tacka As String = "1"
    Public tmp_MMStanica1 As String
    Public tmp_MMStanica2 As String
    Dim str_R50, str_R50naziv As String
    Dim NizR50(10, 2) As String
    Dim BrojPrelazaUNizu As Int16 = 0
    Dim SkokNaVoz As String = "Da"
    '----
    Public r1, r2 As String
    Public r4, r5 As String
    Public r4_1, r4_2, r5_1, r5_2, r5_3, r5_4, r6, r7, r8, r9, r10, r10_kb, r11 As String
    Public r12_1, r12_2, r13_1, r13_2, r14_1, r14_2, r15, r15_1, r16, r17, r18, r19, r20_1, r20_2 As String
    Public r21_1, r21_2, r21_3, r21_4, r22_1, r22_2, r22_3, r22_4 As String
    Public r23_1, r23_2, r23_3, r23_4, r24_1, r24_2, r24_3, r24_4 As String
    Public r25t_1, r25t_2, r25t_3, r25t_4, r25k_1, r25k_2, r25k_3, r25k_4 As String
    Public r26_1, r26_2, r26_3, r26_4 As String
    Public r27, r28 As String
    Public rSumaTara, rSumaKola, rSumaOs As String ' Number?
    Public r29_1, r29_2, r30_1, r30_2, r31_1, r31_2, r32, r32_1, r33_1, r33_2 As String
    Public r34, r35, r36 As String
    Public rRID, r37 As String
    Public r42_1, r42_2, r42_3, r42_4, r42_5, r42_6, r43_1, r43_2, r43_3, r43_4, r43_5, r43_6 As String
    Public r44_1, r44_2, r44_3, r44_4, r44n1, r44n2, r44n3, r44n4, r44i, r45_1, r45_2, r41Suma, r46 As String
    Public r47, r48_1, r48_2 As String '?number
    Public r49, r50, r51, r52 As String '?number
    Public r53, r54_1, r54_2, r54_3 As String
    Public r55_1, r55_2, r55_3, r56_1, r56_2, r56_3, r57_1, r57_2, r57_3, r58, r59, r60 As String
    Public r61F, r61U As String '?number
    Public r64F_1, r64F_2, r64F_3, r64F_4, r64F_5, r64F_6 As String '?number
    Public r64U_1, r64U_2, r64U_3, r64U_4, r64U_5, r64U_6 As String '?number
    Public r62a_1, r62a_2, r62a_3, r62a_4, r62a_5, r62a_6, r62b_1, r62b_2, r62b_3, r62b_4, r62b_5, r62b_6 As String
    Public r62c_1, r62c_2, r62c_3, r62c_4, r62c_5, r62c_6 As String
    Public r65f, r65u As String '?NUMBER
    Public r66a, r66b As String
    Dim dsServer2Client As New DataSet("dsServer2Client")

    'Dim bPrevozninaLevo As Decimal = 0
    'Dim bPrevozninaDesno As Decimal = 0
    'Dim bSumaLevo As Decimal = 0
    'Dim bSumaDesno As Decimal = 0
    'Dim bSumaNaknadaLevo As Decimal = 0
    'Dim bSumaNaknadaDesno As Decimal = 0
    'Dim bRazlikaFr As Decimal = 0
    'Dim bRazlikaUp As Decimal = 0
    Public bShiftTab As Boolean = False

    Dim ug_mNazivKomitentaP As String = ""
    Dim ug_mAdresaKomitentaP As String = ""
    Dim ug_mGradKomitentaP As String = ""
    Dim ug_mZemljaKomitentaP As String = ""
    Dim ug_mPlatilac As Int32 = 0
    Dim ug_mVrstaObracunaP As String = ""

    Dim ug_mNazivKomitentaPP As String = ""
    Dim ug_mAdresaKomitentaPP As String = ""
    Dim ug_mGradKomitentaPP As String = ""
    Dim ug_mZemljaKomitentaPP As String = ""
    Dim ug_mPraviPlatilac As Int32 = 0
    Dim ug_mVrstaObracunaPP As String = ""


    'Const SND_ASYNC As Integer = &H1
    'Const SND_FILENAME As Integer = &H20000
    'Const SND_NODEFAULT As Integer = &H2

    'Public ExMMIndex As Integer = -1
    'Public ImMMIndex As Integer = -1
    '----

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
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents gbSaobracaj As System.Windows.Forms.GroupBox
    Friend WithEvents rbKolska As System.Windows.Forms.RadioButton
    Friend WithEvents rbDencana As System.Windows.Forms.RadioButton
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgError As System.Windows.Forms.DataGrid
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnStanicaOtp As System.Windows.Forms.Button
    Friend WithEvents tbBrojOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaOtp As System.Windows.Forms.TextBox
    Friend WithEvents DatumOtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnStanicaPr As System.Windows.Forms.Button
    Friend WithEvents tbBrojPr As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaPr As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btnUpis As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextBox28 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents tbCtrlNum As System.Windows.Forms.TextBox
    Friend WithEvents tbKolauVozu As System.Windows.Forms.TextBox
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents tbA79b3 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79a3 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79b2 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79a2 As System.Windows.Forms.TextBox
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents tbA79b1 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79a1 As System.Windows.Forms.TextBox
    Friend WithEvents btnUnosRobe As System.Windows.Forms.Button
    Friend WithEvents tb20a As System.Windows.Forms.TextBox
    Friend WithEvents tb20d As System.Windows.Forms.TextBox
    Friend WithEvents tb20c As System.Windows.Forms.TextBox
    Friend WithEvents tb20b As System.Windows.Forms.TextBox
    Friend WithEvents tbIBK As System.Windows.Forms.TextBox
    Friend WithEvents tbControl As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rtbR10 As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbR16 As System.Windows.Forms.RichTextBox
    Friend WithEvents cbR6 As System.Windows.Forms.CheckBox
    Friend WithEvents cbR5D As System.Windows.Forms.CheckBox
    Friend WithEvents cbR5O As System.Windows.Forms.CheckBox
    Friend WithEvents cbR5R As System.Windows.Forms.CheckBox
    Friend WithEvents cbR4D As System.Windows.Forms.CheckBox
    Friend WithEvents cbR4K As System.Windows.Forms.CheckBox
    Friend WithEvents tbR17 As System.Windows.Forms.TextBox
    Friend WithEvents tbR11 As System.Windows.Forms.TextBox
    Friend WithEvents tbR12Naziv As System.Windows.Forms.TextBox
    Friend WithEvents tbR12Sifra As System.Windows.Forms.TextBox
    Friend WithEvents tbR15 As System.Windows.Forms.TextBox
    Friend WithEvents tbR14Sifra As System.Windows.Forms.TextBox
    Friend WithEvents tbR14Naziv As System.Windows.Forms.TextBox
    Friend WithEvents rtbR27 As System.Windows.Forms.RichTextBox
    Friend WithEvents tbR30Naziv As System.Windows.Forms.TextBox
    Friend WithEvents tbR30Sifra As System.Windows.Forms.TextBox
    Friend WithEvents rtbR34 As System.Windows.Forms.RichTextBox
    Friend WithEvents cbRID As System.Windows.Forms.CheckBox
    Friend WithEvents tbR41Suma As System.Windows.Forms.TextBox
    Friend WithEvents tbR50 As System.Windows.Forms.TextBox
    Friend WithEvents tbR49 As System.Windows.Forms.TextBox
    Friend WithEvents btnKalk As System.Windows.Forms.Button
    Friend WithEvents tbR53 As System.Windows.Forms.TextBox
    Friend WithEvents tbR8 As System.Windows.Forms.TextBox
    Friend WithEvents tbR60 As System.Windows.Forms.TextBox
    Friend WithEvents tbR13_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR13_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR33_1 As System.Windows.Forms.TextBox
    Friend WithEvents rtb37 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbNak1F As System.Windows.Forms.TextBox
    Friend WithEvents tbNak2F As System.Windows.Forms.TextBox
    Friend WithEvents tbNak4F As System.Windows.Forms.TextBox
    Friend WithEvents tbNak3F As System.Windows.Forms.TextBox
    Friend WithEvents tbNak4U As System.Windows.Forms.TextBox
    Friend WithEvents tbNak3U As System.Windows.Forms.TextBox
    Friend WithEvents tbNak2U As System.Windows.Forms.TextBox
    Friend WithEvents tbNak1U As System.Windows.Forms.TextBox
    Friend WithEvents tbA79b4 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79a4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents tbPrevU As System.Windows.Forms.TextBox
    Friend WithEvents tbPrevF As System.Windows.Forms.TextBox
    Friend WithEvents tbSumaU As System.Windows.Forms.TextBox
    Friend WithEvents tbSumaF As System.Windows.Forms.TextBox
    Friend WithEvents tbPDVU As System.Windows.Forms.TextBox
    Friend WithEvents tbPDVF As System.Windows.Forms.TextBox
    Friend WithEvents tbPDV As System.Windows.Forms.TextBox
    Friend WithEvents tbPdvIznosF As System.Windows.Forms.TextBox
    Friend WithEvents tbPdvIznosU As System.Windows.Forms.TextBox
    Friend WithEvents cbPDV As System.Windows.Forms.CheckBox
    Friend WithEvents tbTug As System.Windows.Forms.TextBox
    Friend WithEvents tbPrevStav1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR54_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR57_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR21_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR23_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR24_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR25a_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR25b_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR26_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbSumaNeto As System.Windows.Forms.TextBox
    Friend WithEvents tbSumaOsovina As System.Windows.Forms.TextBox
    Friend WithEvents tbSumaKola As System.Windows.Forms.TextBox
    Friend WithEvents tbR2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR9 As System.Windows.Forms.TextBox
    Friend WithEvents tbR18 As System.Windows.Forms.TextBox
    Friend WithEvents tbR19 As System.Windows.Forms.TextBox
    Friend WithEvents tbR20a As System.Windows.Forms.TextBox
    Friend WithEvents tbR20b As System.Windows.Forms.TextBox
    Friend WithEvents tbR23_4 As System.Windows.Forms.TextBox
    Friend WithEvents tbR23_3 As System.Windows.Forms.TextBox
    Friend WithEvents tbR23_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR24_4 As System.Windows.Forms.TextBox
    Friend WithEvents tbR24_3 As System.Windows.Forms.TextBox
    Friend WithEvents tbR24_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR25a_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR25a_4 As System.Windows.Forms.TextBox
    Friend WithEvents tbR25a_3 As System.Windows.Forms.TextBox
    Friend WithEvents tbR25b_4 As System.Windows.Forms.TextBox
    Friend WithEvents tbR25b_3 As System.Windows.Forms.TextBox
    Friend WithEvents tbR25b_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR26_4 As System.Windows.Forms.TextBox
    Friend WithEvents tbR26_3 As System.Windows.Forms.TextBox
    Friend WithEvents tbR26_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR21_4 As System.Windows.Forms.TextBox
    Friend WithEvents tbIBK_4 As System.Windows.Forms.TextBox
    Friend WithEvents tbR21_3 As System.Windows.Forms.TextBox
    Friend WithEvents tbIBK_3 As System.Windows.Forms.TextBox
    Friend WithEvents tbR21_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbIBK_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR28 As System.Windows.Forms.TextBox
    Friend WithEvents tb15_1 As System.Windows.Forms.TextBox
    Friend WithEvents tbR31Sifra As System.Windows.Forms.TextBox
    Friend WithEvents tbR31naziv As System.Windows.Forms.TextBox
    Friend WithEvents tbR32a As System.Windows.Forms.TextBox
    Friend WithEvents tbR32b As System.Windows.Forms.TextBox
    Friend WithEvents tbR33_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR36 As System.Windows.Forms.TextBox
    Friend WithEvents tbR42a As System.Windows.Forms.TextBox
    Friend WithEvents tbR43a As System.Windows.Forms.TextBox
    Friend WithEvents tbR42b As System.Windows.Forms.TextBox
    Friend WithEvents tbR42c As System.Windows.Forms.TextBox
    Friend WithEvents tbR42d As System.Windows.Forms.TextBox
    Friend WithEvents tbR42e As System.Windows.Forms.TextBox
    Friend WithEvents tbR42f As System.Windows.Forms.TextBox
    Friend WithEvents tbR43b As System.Windows.Forms.TextBox
    Friend WithEvents tbR43c As System.Windows.Forms.TextBox
    Friend WithEvents tbR43d As System.Windows.Forms.TextBox
    Friend WithEvents tbR43e As System.Windows.Forms.TextBox
    Friend WithEvents tbR43f As System.Windows.Forms.TextBox
    Friend WithEvents tbR44Iznos As System.Windows.Forms.TextBox
    Friend WithEvents tbR45b As System.Windows.Forms.TextBox
    Friend WithEvents tbR45a As System.Windows.Forms.TextBox
    Friend WithEvents tbR46 As System.Windows.Forms.TextBox
    Friend WithEvents tbR47 As System.Windows.Forms.TextBox
    Friend WithEvents tbR48a As System.Windows.Forms.TextBox
    Friend WithEvents tbR48b As System.Windows.Forms.TextBox
    Friend WithEvents tbR51 As System.Windows.Forms.TextBox
    Friend WithEvents tbR54_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR54_3 As System.Windows.Forms.TextBox
    Friend WithEvents tbPrevStav3 As System.Windows.Forms.TextBox
    Friend WithEvents tbPrevStav2 As System.Windows.Forms.TextBox
    Friend WithEvents tb56c As System.Windows.Forms.TextBox
    Friend WithEvents tb56b As System.Windows.Forms.TextBox
    Friend WithEvents tb56a As System.Windows.Forms.TextBox
    Friend WithEvents tbR57_3 As System.Windows.Forms.TextBox
    Friend WithEvents tbR57_2 As System.Windows.Forms.TextBox
    Friend WithEvents tbR58 As System.Windows.Forms.TextBox
    Friend WithEvents tbR59 As System.Windows.Forms.TextBox
    Friend WithEvents tb62nd As System.Windows.Forms.TextBox
    Friend WithEvents tb62nc As System.Windows.Forms.TextBox
    Friend WithEvents tb62nb As System.Windows.Forms.TextBox
    Friend WithEvents tb62na As System.Windows.Forms.TextBox
    Friend WithEvents tb63a As System.Windows.Forms.TextBox
    Friend WithEvents tb63b As System.Windows.Forms.TextBox
    Friend WithEvents tbTugF As System.Windows.Forms.TextBox
    Friend WithEvents tbTugU As System.Windows.Forms.TextBox
    Friend WithEvents tbR7 As System.Windows.Forms.TextBox
    Friend WithEvents tbR68b As System.Windows.Forms.TextBox
    Friend WithEvents tbR35 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents rbTLPrint As System.Windows.Forms.RadioButton
    Friend WithEvents rbTLPreview As System.Windows.Forms.RadioButton
    Friend WithEvents rbDLPrint As System.Windows.Forms.RadioButton
    Friend WithEvents rbDLPreview As System.Windows.Forms.RadioButton
    Friend WithEvents cbStrana5 As System.Windows.Forms.CheckBox
    Friend WithEvents cbStrana4 As System.Windows.Forms.CheckBox
    Friend WithEvents cbStrana3 As System.Windows.Forms.CheckBox
    Friend WithEvents cbStrana2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbStrana1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbPoledjina5 As System.Windows.Forms.CheckBox
    Friend WithEvents cbPoledjina4 As System.Windows.Forms.CheckBox
    Friend WithEvents cbPoledjina2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbPoledjina1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbPoledjina3 As System.Windows.Forms.CheckBox
    Friend WithEvents cbR5E As System.Windows.Forms.CheckBox
    Friend WithEvents cmbManipulativnaMestaEx As System.Windows.Forms.ComboBox
    Friend WithEvents cmbManipulativnaMestaIm As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents FR_Stanica As System.Windows.Forms.TextBox
    Friend WithEvents UP_Stanica As System.Windows.Forms.TextBox
    Friend WithEvents FR_Razlika As System.Windows.Forms.TextBox
    Friend WithEvents UP_Razlika As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbStanicaLom As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents cbZsPrevozniPut As System.Windows.Forms.ComboBox
    Friend WithEvents tbPrev1 As System.Windows.Forms.Label
    Friend WithEvents tbPrev2 As System.Windows.Forms.Label
    Friend WithEvents tbR53_LP2 As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents btnSTV As System.Windows.Forms.Button
    Friend WithEvents lblFrankoRazlika As System.Windows.Forms.Label
    Friend WithEvents lblUpucenoRazlika As System.Windows.Forms.Label
    Friend WithEvents lblPrKurs As System.Windows.Forms.Label
    Friend WithEvents lblOtpKurs As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents gbDorKarta As System.Windows.Forms.GroupBox
    Friend WithEvents tbDKIznos As System.Windows.Forms.TextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents lblNajava As System.Windows.Forms.Label
    Friend WithEvents tbNajava As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormUTL))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button11 = New System.Windows.Forms.Button
        Me.btnUpis = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.tbBrojOtp = New System.Windows.Forms.TextBox
        Me.tbStanicaOtp = New System.Windows.Forms.TextBox
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.tbBrojPr = New System.Windows.Forms.TextBox
        Me.tbStanicaPr = New System.Windows.Forms.TextBox
        Me.ContextMenu2 = New System.Windows.Forms.ContextMenu
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.tbR47 = New System.Windows.Forms.TextBox
        Me.tbPrevU = New System.Windows.Forms.TextBox
        Me.tbR45b = New System.Windows.Forms.TextBox
        Me.tbR44Iznos = New System.Windows.Forms.TextBox
        Me.tbR41Suma = New System.Windows.Forms.TextBox
        Me.tbR32a = New System.Windows.Forms.TextBox
        Me.tbR31Sifra = New System.Windows.Forms.TextBox
        Me.tbR31naziv = New System.Windows.Forms.TextBox
        Me.tbR50 = New System.Windows.Forms.TextBox
        Me.tbR15 = New System.Windows.Forms.TextBox
        Me.tbR14Sifra = New System.Windows.Forms.TextBox
        Me.tbR14Naziv = New System.Windows.Forms.TextBox
        Me.tbR12Naziv = New System.Windows.Forms.TextBox
        Me.tbR12Sifra = New System.Windows.Forms.TextBox
        Me.tbCtrlNum = New System.Windows.Forms.TextBox
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.tbR49 = New System.Windows.Forms.TextBox
        Me.btnUnosRobe = New System.Windows.Forms.Button
        Me.tbR35 = New System.Windows.Forms.TextBox
        Me.tbR45a = New System.Windows.Forms.TextBox
        Me.tbR17 = New System.Windows.Forms.TextBox
        Me.tbR30Naziv = New System.Windows.Forms.TextBox
        Me.tbR30Sifra = New System.Windows.Forms.TextBox
        Me.tbR11 = New System.Windows.Forms.TextBox
        Me.tbR23_4 = New System.Windows.Forms.TextBox
        Me.tbR23_3 = New System.Windows.Forms.TextBox
        Me.tbR23_2 = New System.Windows.Forms.TextBox
        Me.tbR23_1 = New System.Windows.Forms.TextBox
        Me.tbR48a = New System.Windows.Forms.TextBox
        Me.tbR48b = New System.Windows.Forms.TextBox
        Me.tbR53 = New System.Windows.Forms.TextBox
        Me.tbR60 = New System.Windows.Forms.TextBox
        Me.tbR54_1 = New System.Windows.Forms.TextBox
        Me.tbR54_2 = New System.Windows.Forms.TextBox
        Me.tbR54_3 = New System.Windows.Forms.TextBox
        Me.tbPrevStav3 = New System.Windows.Forms.TextBox
        Me.tbPrevStav2 = New System.Windows.Forms.TextBox
        Me.tbPrevStav1 = New System.Windows.Forms.TextBox
        Me.tb56c = New System.Windows.Forms.TextBox
        Me.tb56b = New System.Windows.Forms.TextBox
        Me.tb56a = New System.Windows.Forms.TextBox
        Me.tbR57_3 = New System.Windows.Forms.TextBox
        Me.tbR57_2 = New System.Windows.Forms.TextBox
        Me.tbR57_1 = New System.Windows.Forms.TextBox
        Me.tbR28 = New System.Windows.Forms.TextBox
        Me.tbR51 = New System.Windows.Forms.TextBox
        Me.tbR9 = New System.Windows.Forms.TextBox
        Me.tbR32b = New System.Windows.Forms.TextBox
        Me.tb15_1 = New System.Windows.Forms.TextBox
        Me.tbR2 = New System.Windows.Forms.TextBox
        Me.tbR58 = New System.Windows.Forms.TextBox
        Me.tbR59 = New System.Windows.Forms.TextBox
        Me.tbR46 = New System.Windows.Forms.TextBox
        Me.btnKalk = New System.Windows.Forms.Button
        Me.Button18 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.tbR43a = New System.Windows.Forms.TextBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cmbManipulativnaMestaEx = New System.Windows.Forms.ComboBox
        Me.cmbManipulativnaMestaIm = New System.Windows.Forms.ComboBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.FR_Stanica = New System.Windows.Forms.TextBox
        Me.UP_Stanica = New System.Windows.Forms.TextBox
        Me.FR_Razlika = New System.Windows.Forms.TextBox
        Me.UP_Razlika = New System.Windows.Forms.TextBox
        Me.tbR53_LP2 = New System.Windows.Forms.TextBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.tbDKIznos = New System.Windows.Forms.TextBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.tbR24_4 = New System.Windows.Forms.TextBox
        Me.tbR24_3 = New System.Windows.Forms.TextBox
        Me.tbR24_2 = New System.Windows.Forms.TextBox
        Me.tbR24_1 = New System.Windows.Forms.TextBox
        Me.tbA79b4 = New System.Windows.Forms.TextBox
        Me.tbA79a4 = New System.Windows.Forms.TextBox
        Me.tbA79b3 = New System.Windows.Forms.TextBox
        Me.tbA79a3 = New System.Windows.Forms.TextBox
        Me.tbA79b2 = New System.Windows.Forms.TextBox
        Me.tbA79a2 = New System.Windows.Forms.TextBox
        Me.tbA79b1 = New System.Windows.Forms.TextBox
        Me.tbA79a1 = New System.Windows.Forms.TextBox
        Me.tb63a = New System.Windows.Forms.TextBox
        Me.tb62nd = New System.Windows.Forms.TextBox
        Me.tb62nc = New System.Windows.Forms.TextBox
        Me.tb62nb = New System.Windows.Forms.TextBox
        Me.tb62na = New System.Windows.Forms.TextBox
        Me.tbTug = New System.Windows.Forms.TextBox
        Me.tbSumaNeto = New System.Windows.Forms.TextBox
        Me.tbR25a_2 = New System.Windows.Forms.TextBox
        Me.tbR25a_1 = New System.Windows.Forms.TextBox
        Me.tbR36 = New System.Windows.Forms.TextBox
        Me.tbR33_2 = New System.Windows.Forms.TextBox
        Me.tbR33_1 = New System.Windows.Forms.TextBox
        Me.TextBox28 = New System.Windows.Forms.TextBox
        Me.tbR13_2 = New System.Windows.Forms.TextBox
        Me.tbR13_1 = New System.Windows.Forms.TextBox
        Me.TextBox23 = New System.Windows.Forms.TextBox
        Me.tbPrevF = New System.Windows.Forms.TextBox
        Me.tbSumaU = New System.Windows.Forms.TextBox
        Me.tbSumaF = New System.Windows.Forms.TextBox
        Me.tbR25a_4 = New System.Windows.Forms.TextBox
        Me.tbR25a_3 = New System.Windows.Forms.TextBox
        Me.tbR25b_4 = New System.Windows.Forms.TextBox
        Me.tbR25b_3 = New System.Windows.Forms.TextBox
        Me.tbR25b_2 = New System.Windows.Forms.TextBox
        Me.tbR25b_1 = New System.Windows.Forms.TextBox
        Me.tbR26_4 = New System.Windows.Forms.TextBox
        Me.tbR26_3 = New System.Windows.Forms.TextBox
        Me.tbR26_2 = New System.Windows.Forms.TextBox
        Me.tbR26_1 = New System.Windows.Forms.TextBox
        Me.tbNak1F = New System.Windows.Forms.TextBox
        Me.tbNak2F = New System.Windows.Forms.TextBox
        Me.tbNak4F = New System.Windows.Forms.TextBox
        Me.tbNak3F = New System.Windows.Forms.TextBox
        Me.tbTugF = New System.Windows.Forms.TextBox
        Me.tbTugU = New System.Windows.Forms.TextBox
        Me.tbNak4U = New System.Windows.Forms.TextBox
        Me.tbNak3U = New System.Windows.Forms.TextBox
        Me.tbNak2U = New System.Windows.Forms.TextBox
        Me.tbNak1U = New System.Windows.Forms.TextBox
        Me.tbR8 = New System.Windows.Forms.TextBox
        Me.tbR20a = New System.Windows.Forms.TextBox
        Me.tbR20b = New System.Windows.Forms.TextBox
        Me.tbR7 = New System.Windows.Forms.TextBox
        Me.tbSumaOsovina = New System.Windows.Forms.TextBox
        Me.tbSumaKola = New System.Windows.Forms.TextBox
        Me.tbR18 = New System.Windows.Forms.TextBox
        Me.tbR19 = New System.Windows.Forms.TextBox
        Me.tbR68b = New System.Windows.Forms.TextBox
        Me.gbSaobracaj = New System.Windows.Forms.GroupBox
        Me.rbDencana = New System.Windows.Forms.RadioButton
        Me.rbKolska = New System.Windows.Forms.RadioButton
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbNajava = New System.Windows.Forms.TextBox
        Me.lblNajava = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Button10 = New System.Windows.Forms.Button
        Me.dgError = New System.Windows.Forms.DataGrid
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.DatumOtp = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnStanicaOtp = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnStanicaPr = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbR21_1 = New System.Windows.Forms.TextBox
        Me.CheckBox6 = New System.Windows.Forms.CheckBox
        Me.CheckBox7 = New System.Windows.Forms.CheckBox
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.cbR6 = New System.Windows.Forms.CheckBox
        Me.cbR5D = New System.Windows.Forms.CheckBox
        Me.cbR5O = New System.Windows.Forms.CheckBox
        Me.cbR5R = New System.Windows.Forms.CheckBox
        Me.cbR4D = New System.Windows.Forms.CheckBox
        Me.cbRID = New System.Windows.Forms.CheckBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.tbKolauVozu = New System.Windows.Forms.TextBox
        Me.rtbR34 = New System.Windows.Forms.RichTextBox
        Me.rtbR27 = New System.Windows.Forms.RichTextBox
        Me.rtb37 = New System.Windows.Forms.RichTextBox
        Me.tb20a = New System.Windows.Forms.TextBox
        Me.tb20d = New System.Windows.Forms.TextBox
        Me.tb20c = New System.Windows.Forms.TextBox
        Me.tb20b = New System.Windows.Forms.TextBox
        Me.cbR4K = New System.Windows.Forms.CheckBox
        Me.tbIBK = New System.Windows.Forms.TextBox
        Me.tbControl = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gbDorKarta = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.tbPrev2 = New System.Windows.Forms.Label
        Me.tbPrev1 = New System.Windows.Forms.Label
        Me.tbStanicaLom = New System.Windows.Forms.TextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.cbZsPrevozniPut = New System.Windows.Forms.ComboBox
        Me.cbR5E = New System.Windows.Forms.CheckBox
        Me.tbIBK_4 = New System.Windows.Forms.TextBox
        Me.tbIBK_3 = New System.Windows.Forms.TextBox
        Me.tbIBK_2 = New System.Windows.Forms.TextBox
        Me.tbR43f = New System.Windows.Forms.TextBox
        Me.tbR43e = New System.Windows.Forms.TextBox
        Me.tbR43d = New System.Windows.Forms.TextBox
        Me.tbR43c = New System.Windows.Forms.TextBox
        Me.tbR43b = New System.Windows.Forms.TextBox
        Me.tbR42f = New System.Windows.Forms.TextBox
        Me.tbR42e = New System.Windows.Forms.TextBox
        Me.tbR42d = New System.Windows.Forms.TextBox
        Me.tbR42c = New System.Windows.Forms.TextBox
        Me.tbR42b = New System.Windows.Forms.TextBox
        Me.tbR42a = New System.Windows.Forms.TextBox
        Me.tbPdvIznosU = New System.Windows.Forms.TextBox
        Me.tbPdvIznosF = New System.Windows.Forms.TextBox
        Me.tb63b = New System.Windows.Forms.TextBox
        Me.tbPDV = New System.Windows.Forms.TextBox
        Me.tbPDVU = New System.Windows.Forms.TextBox
        Me.tbPDVF = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.rtbR16 = New System.Windows.Forms.RichTextBox
        Me.rtbR10 = New System.Windows.Forms.RichTextBox
        Me.tbR21_4 = New System.Windows.Forms.TextBox
        Me.tbR21_3 = New System.Windows.Forms.TextBox
        Me.tbR21_2 = New System.Windows.Forms.TextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cbPDV = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbTLPreview = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbStrana5 = New System.Windows.Forms.CheckBox
        Me.cbStrana4 = New System.Windows.Forms.CheckBox
        Me.cbStrana3 = New System.Windows.Forms.CheckBox
        Me.cbStrana2 = New System.Windows.Forms.CheckBox
        Me.cbStrana1 = New System.Windows.Forms.CheckBox
        Me.rbTLPrint = New System.Windows.Forms.RadioButton
        Me.Label23 = New System.Windows.Forms.Label
        Me.cbPoledjina5 = New System.Windows.Forms.CheckBox
        Me.cbPoledjina4 = New System.Windows.Forms.CheckBox
        Me.cbPoledjina2 = New System.Windows.Forms.CheckBox
        Me.cbPoledjina1 = New System.Windows.Forms.CheckBox
        Me.cbPoledjina3 = New System.Windows.Forms.CheckBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbDLPreview = New System.Windows.Forms.RadioButton
        Me.rbDLPrint = New System.Windows.Forms.RadioButton
        Me.Label27 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.lblUpucenoRazlika = New System.Windows.Forms.Label
        Me.lblFrankoRazlika = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.btnSTV = New System.Windows.Forms.Button
        Me.lblOtpKurs = New System.Windows.Forms.Label
        Me.lblPrKurs = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.gbSaobracaj.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbDorKarta.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button11.Location = New System.Drawing.Point(855, 597)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(72, 56)
        Me.Button11.TabIndex = 447
        Me.Button11.Text = "Kontrola"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Button11, "Kontrola ispravnosti dokumenta")
        '
        'btnUpis
        '
        Me.btnUpis.BackColor = System.Drawing.Color.PapayaWhip
        Me.btnUpis.Image = CType(resources.GetObject("btnUpis.Image"), System.Drawing.Image)
        Me.btnUpis.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpis.Location = New System.Drawing.Point(927, 597)
        Me.btnUpis.Name = "btnUpis"
        Me.btnUpis.Size = New System.Drawing.Size(72, 56)
        Me.btnUpis.TabIndex = 246
        Me.btnUpis.Text = "  Upis"
        Me.btnUpis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnUpis, "Upis u bazu")
        '
        'Button12
        '
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button12.Location = New System.Drawing.Point(927, 653)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(72, 56)
        Me.Button12.TabIndex = 249
        Me.Button12.Text = "  Izlaz"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Button12, "Povratak u osnovni meni")
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(944, 544)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 24)
        Me.Button3.TabIndex = 313
        Me.Button3.Text = "Stampa tovarnog lista"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Button3, "Stampa tovarnog lista")
        Me.Button3.Visible = False
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.BackColor = System.Drawing.Color.White
        Me.tbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojOtp.Location = New System.Drawing.Point(8, 84)
        Me.tbBrojOtp.MaxLength = 5
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.Size = New System.Drawing.Size(56, 22)
        Me.tbBrojOtp.TabIndex = 1
        Me.tbBrojOtp.Text = ""
        Me.tbBrojOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbBrojOtp, "Broj otpravljanja")
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
        Me.tbStanicaOtp.ContextMenu = Me.ContextMenu1
        Me.tbStanicaOtp.Cursor = System.Windows.Forms.Cursors.Help
        Me.tbStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaOtp.Location = New System.Drawing.Point(8, 25)
        Me.tbStanicaOtp.MaxLength = 5
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.Size = New System.Drawing.Size(56, 22)
        Me.tbStanicaOtp.TabIndex = 0
        Me.tbStanicaOtp.Text = ""
        Me.tbStanicaOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbStanicaOtp, "Otpravna stanica")
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Izaberi stanicu otpravljanja"
        '
        'tbBrojPr
        '
        Me.tbBrojPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojPr.Location = New System.Drawing.Point(8, 86)
        Me.tbBrojPr.MaxLength = 5
        Me.tbBrojPr.Name = "tbBrojPr"
        Me.tbBrojPr.Size = New System.Drawing.Size(56, 22)
        Me.tbBrojPr.TabIndex = 1
        Me.tbBrojPr.Text = ""
        Me.tbBrojPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbBrojPr, "Broj prispeca")
        '
        'tbStanicaPr
        '
        Me.tbStanicaPr.ContextMenu = Me.ContextMenu2
        Me.tbStanicaPr.Cursor = System.Windows.Forms.Cursors.Help
        Me.tbStanicaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaPr.Location = New System.Drawing.Point(8, 27)
        Me.tbStanicaPr.MaxLength = 5
        Me.tbStanicaPr.Name = "tbStanicaPr"
        Me.tbStanicaPr.Size = New System.Drawing.Size(56, 22)
        Me.tbStanicaPr.TabIndex = 0
        Me.tbStanicaPr.Text = ""
        Me.tbStanicaPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbStanicaPr, "Stanica prispeca")
        '
        'ContextMenu2
        '
        Me.ContextMenu2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Izaberi stanicu prispeca"
        '
        'tbR47
        '
        Me.tbR47.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR47.Location = New System.Drawing.Point(8, 695)
        Me.tbR47.MaxLength = 18
        Me.tbR47.Name = "tbR47"
        Me.tbR47.Size = New System.Drawing.Size(96, 20)
        Me.tbR47.TabIndex = 377
        Me.tbR47.Text = "0"
        Me.tbR47.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR47, "Pouzece")
        '
        'tbPrevU
        '
        Me.tbPrevU.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPrevU.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevU.Location = New System.Drawing.Point(636, 774)
        Me.tbPrevU.MaxLength = 18
        Me.tbPrevU.Name = "tbPrevU"
        Me.tbPrevU.Size = New System.Drawing.Size(96, 22)
        Me.tbPrevU.TabIndex = 375
        Me.tbPrevU.Text = "0"
        Me.tbPrevU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbPrevU, "Pouzece")
        '
        'tbR45b
        '
        Me.tbR45b.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR45b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR45b.Location = New System.Drawing.Point(258, 612)
        Me.tbR45b.Name = "tbR45b"
        Me.tbR45b.Size = New System.Drawing.Size(200, 20)
        Me.tbR45b.TabIndex = 365
        Me.tbR45b.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR45b, "Datum ispostavljanja tovarnog lista")
        '
        'tbR44Iznos
        '
        Me.tbR44Iznos.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR44Iznos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR44Iznos.Location = New System.Drawing.Point(524, 656)
        Me.tbR44Iznos.MaxLength = 18
        Me.tbR44Iznos.Name = "tbR44Iznos"
        Me.tbR44Iznos.Size = New System.Drawing.Size(80, 20)
        Me.tbR44Iznos.TabIndex = 364
        Me.tbR44Iznos.Text = "0"
        Me.tbR44Iznos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR44Iznos, "Pouzece")
        '
        'tbR41Suma
        '
        Me.tbR41Suma.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR41Suma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR41Suma.Location = New System.Drawing.Point(524, 611)
        Me.tbR41Suma.MaxLength = 12
        Me.tbR41Suma.Name = "tbR41Suma"
        Me.tbR41Suma.Size = New System.Drawing.Size(80, 20)
        Me.tbR41Suma.TabIndex = 363
        Me.tbR41Suma.Text = "0"
        Me.tbR41Suma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR41Suma, "Pouzece")
        '
        'tbR32a
        '
        Me.tbR32a.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR32a.Location = New System.Drawing.Point(356, 403)
        Me.tbR32a.Name = "tbR32a"
        Me.tbR32a.Size = New System.Drawing.Size(224, 20)
        Me.tbR32a.TabIndex = 362
        Me.tbR32a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR32a, "Naziv uputne stanice")
        '
        'tbR31Sifra
        '
        Me.tbR31Sifra.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR31Sifra.Location = New System.Drawing.Point(356, 374)
        Me.tbR31Sifra.MaxLength = 8
        Me.tbR31Sifra.Name = "tbR31Sifra"
        Me.tbR31Sifra.Size = New System.Drawing.Size(74, 20)
        Me.tbR31Sifra.TabIndex = 361
        Me.tbR31Sifra.Text = ""
        Me.tbR31Sifra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR31Sifra, "Šifra stanice koja se nalazi u mestu izdavanja")
        '
        'tbR31naziv
        '
        Me.tbR31naziv.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR31naziv.Location = New System.Drawing.Point(444, 374)
        Me.tbR31naziv.Name = "tbR31naziv"
        Me.tbR31naziv.Size = New System.Drawing.Size(168, 20)
        Me.tbR31naziv.TabIndex = 360
        Me.tbR31naziv.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR31naziv, "Naziv uputne stanice")
        '
        'tbR50
        '
        Me.tbR50.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR50.Location = New System.Drawing.Point(524, 688)
        Me.tbR50.MaxLength = 12
        Me.tbR50.Name = "tbR50"
        Me.tbR50.Size = New System.Drawing.Size(80, 20)
        Me.tbR50.TabIndex = 359
        Me.tbR50.Text = ""
        Me.tbR50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR50, "Predujam")
        '
        'tbR15
        '
        Me.tbR15.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR15.Location = New System.Drawing.Point(356, 132)
        Me.tbR15.Name = "tbR15"
        Me.tbR15.Size = New System.Drawing.Size(224, 20)
        Me.tbR15.TabIndex = 356
        Me.tbR15.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR15, "Naziv mesta utovara")
        '
        'tbR14Sifra
        '
        Me.tbR14Sifra.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR14Sifra.Location = New System.Drawing.Point(356, 102)
        Me.tbR14Sifra.MaxLength = 8
        Me.tbR14Sifra.Name = "tbR14Sifra"
        Me.tbR14Sifra.Size = New System.Drawing.Size(74, 20)
        Me.tbR14Sifra.TabIndex = 355
        Me.tbR14Sifra.Text = ""
        Me.tbR14Sifra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR14Sifra, "Šifra manipulativnog mesta")
        '
        'tbR14Naziv
        '
        Me.tbR14Naziv.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR14Naziv.Location = New System.Drawing.Point(443, 102)
        Me.tbR14Naziv.Name = "tbR14Naziv"
        Me.tbR14Naziv.Size = New System.Drawing.Size(168, 20)
        Me.tbR14Naziv.TabIndex = 354
        Me.tbR14Naziv.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR14Naziv, "Naziv manipulativnog mesta")
        '
        'tbR12Naziv
        '
        Me.tbR12Naziv.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR12Naziv.Location = New System.Drawing.Point(443, 72)
        Me.tbR12Naziv.Name = "tbR12Naziv"
        Me.tbR12Naziv.Size = New System.Drawing.Size(168, 20)
        Me.tbR12Naziv.TabIndex = 353
        Me.tbR12Naziv.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR12Naziv, "Naziv otpravne stanice")
        '
        'tbR12Sifra
        '
        Me.tbR12Sifra.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR12Sifra.Location = New System.Drawing.Point(356, 72)
        Me.tbR12Sifra.MaxLength = 8
        Me.tbR12Sifra.Name = "tbR12Sifra"
        Me.tbR12Sifra.Size = New System.Drawing.Size(74, 20)
        Me.tbR12Sifra.TabIndex = 352
        Me.tbR12Sifra.Text = ""
        Me.tbR12Sifra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR12Sifra, "Šifra otpravne stanice")
        '
        'tbCtrlNum
        '
        Me.tbCtrlNum.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbCtrlNum.Cursor = System.Windows.Forms.Cursors.Help
        Me.tbCtrlNum.Enabled = False
        Me.tbCtrlNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCtrlNum.Location = New System.Drawing.Point(259, 130)
        Me.tbCtrlNum.Name = "tbCtrlNum"
        Me.tbCtrlNum.Size = New System.Drawing.Size(88, 18)
        Me.tbCtrlNum.TabIndex = 341
        Me.tbCtrlNum.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbCtrlNum, "Kontrolni broj dobijen nakon elektronskog prijavljivanja tovarnog lista")
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.White
        Me.Button15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button15.Location = New System.Drawing.Point(329, 163)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(20, 22)
        Me.Button15.TabIndex = 228
        Me.Button15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button15, "Izaberi korisnièku šifru onoga koji plaæa nefrankirane (upuæene) troškove")
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button14.Image = CType(resources.GetObject("Button14.Image"), System.Drawing.Image)
        Me.Button14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button14.Location = New System.Drawing.Point(329, 70)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(20, 22)
        Me.Button14.TabIndex = 227
        Me.Button14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button14, "Izaberi korisnièku šifru onoga koji plaæa frankirane troškove")
        '
        'tbR49
        '
        Me.tbR49.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR49.Location = New System.Drawing.Point(360, 688)
        Me.tbR49.MaxLength = 12
        Me.tbR49.Name = "tbR49"
        Me.tbR49.Size = New System.Drawing.Size(80, 20)
        Me.tbR49.TabIndex = 187
        Me.tbR49.Text = "0"
        Me.tbR49.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR49, "Pouzece")
        '
        'btnUnosRobe
        '
        Me.btnUnosRobe.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.btnUnosRobe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUnosRobe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnUnosRobe.ForeColor = System.Drawing.Color.Green
        Me.btnUnosRobe.Image = CType(resources.GetObject("btnUnosRobe.Image"), System.Drawing.Image)
        Me.btnUnosRobe.Location = New System.Drawing.Point(486, 237)
        Me.btnUnosRobe.Name = "btnUnosRobe"
        Me.btnUnosRobe.Size = New System.Drawing.Size(32, 72)
        Me.btnUnosRobe.TabIndex = 185
        Me.btnUnosRobe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnUnosRobe, "Unos podataka o robi i kolima")
        '
        'tbR35
        '
        Me.tbR35.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR35.Location = New System.Drawing.Point(267, 436)
        Me.tbR35.MaxLength = 100
        Me.tbR35.Multiline = True
        Me.tbR35.Name = "tbR35"
        Me.tbR35.Size = New System.Drawing.Size(104, 50)
        Me.tbR35.TabIndex = 126
        Me.tbR35.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR35, "Opis prevoznog puta")
        '
        'tbR45a
        '
        Me.tbR45a.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR45a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR45a.Location = New System.Drawing.Point(186, 612)
        Me.tbR45a.MaxLength = 10
        Me.tbR45a.Name = "tbR45a"
        Me.tbR45a.Size = New System.Drawing.Size(64, 20)
        Me.tbR45a.TabIndex = 113
        Me.tbR45a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR45a, "Datum ispostavljanja tovarnog lista")
        '
        'tbR17
        '
        Me.tbR17.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR17.Location = New System.Drawing.Point(260, 165)
        Me.tbR17.Name = "tbR17"
        Me.tbR17.Size = New System.Drawing.Size(61, 20)
        Me.tbR17.TabIndex = 28
        Me.tbR17.Text = "0"
        Me.tbR17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR17, "Korisnicka sifra primaoca")
        '
        'tbR30Naziv
        '
        Me.tbR30Naziv.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR30Naziv.Location = New System.Drawing.Point(88, 384)
        Me.tbR30Naziv.Name = "tbR30Naziv"
        Me.tbR30Naziv.Size = New System.Drawing.Size(256, 20)
        Me.tbR30Naziv.TabIndex = 23
        Me.tbR30Naziv.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR30Naziv, "Naziv uputne stanice")
        '
        'tbR30Sifra
        '
        Me.tbR30Sifra.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR30Sifra.Location = New System.Drawing.Point(8, 384)
        Me.tbR30Sifra.MaxLength = 8
        Me.tbR30Sifra.Name = "tbR30Sifra"
        Me.tbR30Sifra.Size = New System.Drawing.Size(74, 20)
        Me.tbR30Sifra.TabIndex = 15
        Me.tbR30Sifra.Text = ""
        Me.tbR30Sifra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR30Sifra, "Šifra uputne stanice")
        '
        'tbR11
        '
        Me.tbR11.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR11.Cursor = System.Windows.Forms.Cursors.Help
        Me.tbR11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR11.Location = New System.Drawing.Point(260, 73)
        Me.tbR11.Name = "tbR11"
        Me.tbR11.Size = New System.Drawing.Size(61, 20)
        Me.tbR11.TabIndex = 3
        Me.tbR11.Text = "0"
        Me.tbR11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR11, "Korisnicka sifra posiljaoca")
        '
        'tbR23_4
        '
        Me.tbR23_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR23_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR23_4.Location = New System.Drawing.Point(527, 294)
        Me.tbR23_4.Name = "tbR23_4"
        Me.tbR23_4.Size = New System.Drawing.Size(41, 20)
        Me.tbR23_4.TabIndex = 410
        Me.tbR23_4.Text = ""
        Me.tbR23_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR23_4, "Datum ispostavljanja tovarnog lista")
        '
        'tbR23_3
        '
        Me.tbR23_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR23_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR23_3.Location = New System.Drawing.Point(527, 278)
        Me.tbR23_3.Name = "tbR23_3"
        Me.tbR23_3.Size = New System.Drawing.Size(41, 20)
        Me.tbR23_3.TabIndex = 409
        Me.tbR23_3.Text = ""
        Me.tbR23_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR23_3, "Datum ispostavljanja tovarnog lista")
        '
        'tbR23_2
        '
        Me.tbR23_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR23_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR23_2.Location = New System.Drawing.Point(527, 262)
        Me.tbR23_2.Name = "tbR23_2"
        Me.tbR23_2.Size = New System.Drawing.Size(41, 20)
        Me.tbR23_2.TabIndex = 408
        Me.tbR23_2.Text = ""
        Me.tbR23_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR23_2, "Datum ispostavljanja tovarnog lista")
        '
        'tbR23_1
        '
        Me.tbR23_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR23_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR23_1.Location = New System.Drawing.Point(527, 246)
        Me.tbR23_1.Name = "tbR23_1"
        Me.tbR23_1.Size = New System.Drawing.Size(41, 20)
        Me.tbR23_1.TabIndex = 407
        Me.tbR23_1.Text = ""
        Me.tbR23_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR23_1, "Datum ispostavljanja tovarnog lista")
        '
        'tbR48a
        '
        Me.tbR48a.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR48a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR48a.Location = New System.Drawing.Point(176, 695)
        Me.tbR48a.MaxLength = 15
        Me.tbR48a.Name = "tbR48a"
        Me.tbR48a.Size = New System.Drawing.Size(96, 20)
        Me.tbR48a.TabIndex = 411
        Me.tbR48a.Text = "0"
        Me.tbR48a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR48a, "Pouzece")
        '
        'tbR48b
        '
        Me.tbR48b.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR48b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR48b.Location = New System.Drawing.Point(175, 716)
        Me.tbR48b.MaxLength = 12
        Me.tbR48b.Name = "tbR48b"
        Me.tbR48b.Size = New System.Drawing.Size(96, 20)
        Me.tbR48b.TabIndex = 412
        Me.tbR48b.Text = "0"
        Me.tbR48b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR48b, "Pouzece")
        '
        'tbR53
        '
        Me.tbR53.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR53.Location = New System.Drawing.Point(287, 725)
        Me.tbR53.MaxLength = 4
        Me.tbR53.Name = "tbR53"
        Me.tbR53.ReadOnly = True
        Me.tbR53.Size = New System.Drawing.Size(32, 20)
        Me.tbR53.TabIndex = 413
        Me.tbR53.Text = ""
        Me.tbR53.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR53, "Pouzece")
        '
        'tbR60
        '
        Me.tbR60.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR60.Location = New System.Drawing.Point(286, 754)
        Me.tbR60.MaxLength = 12
        Me.tbR60.Name = "tbR60"
        Me.tbR60.Size = New System.Drawing.Size(72, 20)
        Me.tbR60.TabIndex = 414
        Me.tbR60.Text = "0"
        Me.tbR60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR60, "Pouzece")
        '
        'tbR54_1
        '
        Me.tbR54_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR54_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR54_1.Location = New System.Drawing.Point(368, 725)
        Me.tbR54_1.MaxLength = 4
        Me.tbR54_1.Name = "tbR54_1"
        Me.tbR54_1.Size = New System.Drawing.Size(24, 20)
        Me.tbR54_1.TabIndex = 415
        Me.tbR54_1.Text = "0"
        Me.tbR54_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR54_1, "Pouzece")
        '
        'tbR54_2
        '
        Me.tbR54_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR54_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR54_2.Location = New System.Drawing.Point(368, 741)
        Me.tbR54_2.MaxLength = 4
        Me.tbR54_2.Name = "tbR54_2"
        Me.tbR54_2.Size = New System.Drawing.Size(24, 20)
        Me.tbR54_2.TabIndex = 416
        Me.tbR54_2.Text = "0"
        Me.tbR54_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR54_2, "Pouzece")
        '
        'tbR54_3
        '
        Me.tbR54_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR54_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR54_3.Location = New System.Drawing.Point(368, 756)
        Me.tbR54_3.MaxLength = 4
        Me.tbR54_3.Name = "tbR54_3"
        Me.tbR54_3.Size = New System.Drawing.Size(24, 20)
        Me.tbR54_3.TabIndex = 417
        Me.tbR54_3.Text = "0"
        Me.tbR54_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR54_3, "Pouzece")
        '
        'tbPrevStav3
        '
        Me.tbPrevStav3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPrevStav3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevStav3.Location = New System.Drawing.Point(404, 756)
        Me.tbPrevStav3.MaxLength = 4
        Me.tbPrevStav3.Name = "tbPrevStav3"
        Me.tbPrevStav3.Size = New System.Drawing.Size(52, 20)
        Me.tbPrevStav3.TabIndex = 420
        Me.tbPrevStav3.Text = "0"
        Me.tbPrevStav3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbPrevStav3, "Pouzece")
        '
        'tbPrevStav2
        '
        Me.tbPrevStav2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPrevStav2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevStav2.Location = New System.Drawing.Point(404, 740)
        Me.tbPrevStav2.MaxLength = 4
        Me.tbPrevStav2.Name = "tbPrevStav2"
        Me.tbPrevStav2.Size = New System.Drawing.Size(52, 20)
        Me.tbPrevStav2.TabIndex = 419
        Me.tbPrevStav2.Text = "0"
        Me.tbPrevStav2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbPrevStav2, "Pouzece")
        '
        'tbPrevStav1
        '
        Me.tbPrevStav1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPrevStav1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevStav1.Location = New System.Drawing.Point(404, 724)
        Me.tbPrevStav1.MaxLength = 4
        Me.tbPrevStav1.Name = "tbPrevStav1"
        Me.tbPrevStav1.Size = New System.Drawing.Size(52, 20)
        Me.tbPrevStav1.TabIndex = 418
        Me.tbPrevStav1.Text = "0"
        Me.tbPrevStav1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbPrevStav1, "Pouzece")
        '
        'tb56c
        '
        Me.tb56c.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb56c.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb56c.Location = New System.Drawing.Point(475, 756)
        Me.tb56c.MaxLength = 4
        Me.tb56c.Name = "tb56c"
        Me.tb56c.Size = New System.Drawing.Size(32, 20)
        Me.tb56c.TabIndex = 423
        Me.tb56c.Text = "0"
        Me.tb56c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb56c, "Pouzece")
        '
        'tb56b
        '
        Me.tb56b.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb56b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb56b.Location = New System.Drawing.Point(475, 740)
        Me.tb56b.MaxLength = 4
        Me.tb56b.Name = "tb56b"
        Me.tb56b.Size = New System.Drawing.Size(32, 20)
        Me.tb56b.TabIndex = 422
        Me.tb56b.Text = "0"
        Me.tb56b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb56b, "Pouzece")
        '
        'tb56a
        '
        Me.tb56a.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb56a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb56a.Location = New System.Drawing.Point(475, 724)
        Me.tb56a.MaxLength = 4
        Me.tb56a.Name = "tb56a"
        Me.tb56a.Size = New System.Drawing.Size(32, 20)
        Me.tb56a.TabIndex = 421
        Me.tb56a.Text = "0"
        Me.tb56a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb56a, "Pouzece")
        '
        'tbR57_3
        '
        Me.tbR57_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR57_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR57_3.Location = New System.Drawing.Point(520, 756)
        Me.tbR57_3.MaxLength = 4
        Me.tbR57_3.Name = "tbR57_3"
        Me.tbR57_3.Size = New System.Drawing.Size(96, 20)
        Me.tbR57_3.TabIndex = 426
        Me.tbR57_3.Text = "0"
        Me.tbR57_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR57_3, "Pouzece")
        '
        'tbR57_2
        '
        Me.tbR57_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR57_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR57_2.Location = New System.Drawing.Point(520, 740)
        Me.tbR57_2.MaxLength = 4
        Me.tbR57_2.Name = "tbR57_2"
        Me.tbR57_2.Size = New System.Drawing.Size(96, 20)
        Me.tbR57_2.TabIndex = 425
        Me.tbR57_2.Text = "0"
        Me.tbR57_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR57_2, "Pouzece")
        '
        'tbR57_1
        '
        Me.tbR57_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR57_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR57_1.Location = New System.Drawing.Point(520, 724)
        Me.tbR57_1.MaxLength = 4
        Me.tbR57_1.Name = "tbR57_1"
        Me.tbR57_1.Size = New System.Drawing.Size(96, 20)
        Me.tbR57_1.TabIndex = 424
        Me.tbR57_1.Text = "0"
        Me.tbR57_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR57_1, "Pouzece")
        '
        'tbR28
        '
        Me.tbR28.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR28.Location = New System.Drawing.Point(356, 338)
        Me.tbR28.Name = "tbR28"
        Me.tbR28.Size = New System.Drawing.Size(119, 20)
        Me.tbR28.TabIndex = 446
        Me.tbR28.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR28, "Datum ispostavljanja tovarnog lista")
        '
        'tbR51
        '
        Me.tbR51.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR51.Location = New System.Drawing.Point(636, 692)
        Me.tbR51.MaxLength = 18
        Me.tbR51.Name = "tbR51"
        Me.tbR51.Size = New System.Drawing.Size(96, 20)
        Me.tbR51.TabIndex = 454
        Me.tbR51.Text = "0"
        Me.tbR51.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR51, "Pouzece")
        '
        'tbR9
        '
        Me.tbR9.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR9.Location = New System.Drawing.Point(5, 98)
        Me.tbR9.MaxLength = 100
        Me.tbR9.Multiline = True
        Me.tbR9.Name = "tbR9"
        Me.tbR9.Size = New System.Drawing.Size(48, 264)
        Me.tbR9.TabIndex = 455
        Me.tbR9.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR9, "Podatak o stvarnom prevoznom putu uz korišæenje šifara koje važe za granice")
        '
        'tbR32b
        '
        Me.tbR32b.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR32b.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR32b.Location = New System.Drawing.Point(595, 407)
        Me.tbR32b.MaxLength = 4
        Me.tbR32b.Name = "tbR32b"
        Me.tbR32b.Size = New System.Drawing.Size(24, 18)
        Me.tbR32b.TabIndex = 458
        Me.tbR32b.Text = "0"
        Me.tbR32b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR32b, "Pouzece")
        '
        'tb15_1
        '
        Me.tb15_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb15_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb15_1.Location = New System.Drawing.Point(592, 135)
        Me.tb15_1.MaxLength = 4
        Me.tb15_1.Name = "tb15_1"
        Me.tb15_1.Size = New System.Drawing.Size(24, 18)
        Me.tb15_1.TabIndex = 459
        Me.tb15_1.Text = "0"
        Me.tb15_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb15_1, "Pouzece")
        '
        'tbR2
        '
        Me.tbR2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR2.Location = New System.Drawing.Point(5, 39)
        Me.tbR2.MaxLength = 4
        Me.tbR2.Name = "tbR2"
        Me.tbR2.Size = New System.Drawing.Size(48, 18)
        Me.tbR2.TabIndex = 460
        Me.tbR2.Text = "0"
        Me.tbR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR2, "Pouzece")
        '
        'tbR58
        '
        Me.tbR58.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR58.Location = New System.Drawing.Point(144, 754)
        Me.tbR58.MaxLength = 20
        Me.tbR58.Name = "tbR58"
        Me.tbR58.Size = New System.Drawing.Size(104, 20)
        Me.tbR58.TabIndex = 461
        Me.tbR58.Text = "0"
        Me.tbR58.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR58, "Pouzece")
        '
        'tbR59
        '
        Me.tbR59.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR59.Location = New System.Drawing.Point(256, 754)
        Me.tbR59.MaxLength = 4
        Me.tbR59.Name = "tbR59"
        Me.tbR59.Size = New System.Drawing.Size(24, 20)
        Me.tbR59.TabIndex = 462
        Me.tbR59.Text = "0"
        Me.tbR59.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR59, "Pouzece")
        '
        'tbR46
        '
        Me.tbR46.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR46.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR46.Location = New System.Drawing.Point(636, 616)
        Me.tbR46.MaxLength = 100
        Me.tbR46.Multiline = True
        Me.tbR46.Name = "tbR46"
        Me.tbR46.Size = New System.Drawing.Size(96, 64)
        Me.tbR46.TabIndex = 463
        Me.tbR46.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR46, "Podatak o stvarnom prevoznom putu uz korišæenje šifara koje važe za granice")
        '
        'btnKalk
        '
        Me.btnKalk.BackColor = System.Drawing.Color.PapayaWhip
        Me.btnKalk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKalk.Location = New System.Drawing.Point(783, 597)
        Me.btnKalk.Name = "btnKalk"
        Me.btnKalk.Size = New System.Drawing.Size(72, 56)
        Me.btnKalk.TabIndex = 448
        Me.btnKalk.Text = "Kalkulacija"
        Me.ToolTip1.SetToolTip(Me.btnKalk, "Kalkulacija prevoznih troskova")
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.Button18.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button18.Image = CType(resources.GetObject("Button18.Image"), System.Drawing.Image)
        Me.Button18.Location = New System.Drawing.Point(160, 793)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(40, 82)
        Me.Button18.TabIndex = 296
        Me.Button18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.Button18, "Izbor naknada za sporedne usluge")
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(944, 568)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 24)
        Me.Button2.TabIndex = 451
        Me.Button2.Text = "Stampa dodatnog lista"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Button2, "Stampa dodatnog lista")
        Me.Button2.Visible = False
        '
        'tbR43a
        '
        Me.tbR43a.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR43a.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR43a.Location = New System.Drawing.Point(707, 506)
        Me.tbR43a.MaxLength = 2
        Me.tbR43a.Name = "tbR43a"
        Me.tbR43a.Size = New System.Drawing.Size(24, 18)
        Me.tbR43a.TabIndex = 472
        Me.tbR43a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR43a, "Sifra tarife za posebne slucajeve")
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(315, 104)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 371
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "Kontrolni broj dobijen nakon elektronskog prijavljivanja tovarnog lista")
        '
        'cmbManipulativnaMestaEx
        '
        Me.cmbManipulativnaMestaEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbManipulativnaMestaEx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbManipulativnaMestaEx.Location = New System.Drawing.Point(8, 51)
        Me.cmbManipulativnaMestaEx.Name = "cmbManipulativnaMestaEx"
        Me.cmbManipulativnaMestaEx.Size = New System.Drawing.Size(208, 21)
        Me.cmbManipulativnaMestaEx.TabIndex = 230
        Me.ToolTip1.SetToolTip(Me.cmbManipulativnaMestaEx, "Izbor manipulativnog mesta")
        Me.cmbManipulativnaMestaEx.Visible = False
        '
        'cmbManipulativnaMestaIm
        '
        Me.cmbManipulativnaMestaIm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbManipulativnaMestaIm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbManipulativnaMestaIm.Location = New System.Drawing.Point(8, 53)
        Me.cmbManipulativnaMestaIm.Name = "cmbManipulativnaMestaIm"
        Me.cmbManipulativnaMestaIm.Size = New System.Drawing.Size(208, 21)
        Me.cmbManipulativnaMestaIm.TabIndex = 232
        Me.ToolTip1.SetToolTip(Me.cmbManipulativnaMestaIm, "Izbor manipulativnog mesta")
        Me.cmbManipulativnaMestaIm.Visible = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Enabled = False
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(594, 435)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(25, 50)
        Me.Button5.TabIndex = 485
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button5, "Izbor prevoznog puta")
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Button1.Location = New System.Drawing.Point(306, 1008)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 486
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button1, "Povratak na pocetak tovarnog lista")
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Button4.Location = New System.Drawing.Point(296, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(24, 24)
        Me.Button4.TabIndex = 487
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button4, "Skok na kraj tovarnog lista")
        '
        'FR_Stanica
        '
        Me.FR_Stanica.BackColor = System.Drawing.Color.White
        Me.FR_Stanica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.FR_Stanica.ForeColor = System.Drawing.Color.Black
        Me.FR_Stanica.Location = New System.Drawing.Point(4, 40)
        Me.FR_Stanica.MaxLength = 18
        Me.FR_Stanica.Name = "FR_Stanica"
        Me.FR_Stanica.Size = New System.Drawing.Size(104, 21)
        Me.FR_Stanica.TabIndex = 300
        Me.FR_Stanica.Text = "0"
        Me.FR_Stanica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.FR_Stanica, "Franko iznos naplacen na stanici")
        '
        'UP_Stanica
        '
        Me.UP_Stanica.BackColor = System.Drawing.Color.White
        Me.UP_Stanica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.UP_Stanica.ForeColor = System.Drawing.Color.Black
        Me.UP_Stanica.Location = New System.Drawing.Point(110, 40)
        Me.UP_Stanica.MaxLength = 18
        Me.UP_Stanica.Name = "UP_Stanica"
        Me.UP_Stanica.Size = New System.Drawing.Size(104, 21)
        Me.UP_Stanica.TabIndex = 489
        Me.UP_Stanica.Text = "0"
        Me.UP_Stanica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.UP_Stanica, "Upucan iznos naplacen na stanici")
        '
        'FR_Razlika
        '
        Me.FR_Razlika.BackColor = System.Drawing.Color.White
        Me.FR_Razlika.Enabled = False
        Me.FR_Razlika.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.FR_Razlika.ForeColor = System.Drawing.Color.Black
        Me.FR_Razlika.Location = New System.Drawing.Point(4, 104)
        Me.FR_Razlika.MaxLength = 18
        Me.FR_Razlika.Name = "FR_Razlika"
        Me.FR_Razlika.ReadOnly = True
        Me.FR_Razlika.Size = New System.Drawing.Size(104, 21)
        Me.FR_Razlika.TabIndex = 4900
        Me.FR_Razlika.Text = "0"
        Me.FR_Razlika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.FR_Razlika, "Franko iznos naplacen na stanici")
        Me.FR_Razlika.Visible = False
        '
        'UP_Razlika
        '
        Me.UP_Razlika.BackColor = System.Drawing.Color.White
        Me.UP_Razlika.Enabled = False
        Me.UP_Razlika.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.UP_Razlika.Location = New System.Drawing.Point(110, 104)
        Me.UP_Razlika.MaxLength = 18
        Me.UP_Razlika.Name = "UP_Razlika"
        Me.UP_Razlika.Size = New System.Drawing.Size(104, 21)
        Me.UP_Razlika.TabIndex = 491
        Me.UP_Razlika.Text = "0"
        Me.UP_Razlika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.UP_Razlika, "Franko iznos naplacen na stanici")
        Me.UP_Razlika.Visible = False
        '
        'tbR53_LP2
        '
        Me.tbR53_LP2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR53_LP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR53_LP2.Location = New System.Drawing.Point(326, 725)
        Me.tbR53_LP2.MaxLength = 4
        Me.tbR53_LP2.Name = "tbR53_LP2"
        Me.tbR53_LP2.ReadOnly = True
        Me.tbR53_LP2.Size = New System.Drawing.Size(32, 20)
        Me.tbR53_LP2.TabIndex = 494
        Me.tbR53_LP2.Text = ""
        Me.tbR53_LP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR53_LP2, "Pouzece")
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(784, 656)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 56)
        Me.Button6.TabIndex = 457
        Me.Button6.Text = "KP - 511 "
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button6, "Opis kontrolne primedbe")
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(784, 544)
        Me.TextBox3.MaxLength = 18
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(72, 21)
        Me.TextBox3.TabIndex = 491
        Me.TextBox3.Text = "0"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox3, "Franko iznos naplacen na stanici")
        Me.TextBox3.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.Enabled = False
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(784, 576)
        Me.TextBox4.MaxLength = 18
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(72, 21)
        Me.TextBox4.TabIndex = 492
        Me.TextBox4.Text = "0"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox4, "Franko iznos naplacen na stanici")
        Me.TextBox4.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.TextBox5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(636, 29)
        Me.TextBox5.MaxLength = 18
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(96, 22)
        Me.TextBox5.TabIndex = 376
        Me.TextBox5.Text = "0"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox5, "Pouzece")
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.TextBox6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(8, 30)
        Me.TextBox6.MaxLength = 18
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(96, 22)
        Me.TextBox6.TabIndex = 377
        Me.TextBox6.Text = "0"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox6, "Pouzece")
        '
        'tbDKIznos
        '
        Me.tbDKIznos.BackColor = System.Drawing.Color.White
        Me.tbDKIznos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbDKIznos.Location = New System.Drawing.Point(5, 24)
        Me.tbDKIznos.MaxLength = 18
        Me.tbDKIznos.Name = "tbDKIznos"
        Me.tbDKIznos.Size = New System.Drawing.Size(96, 22)
        Me.tbDKIznos.TabIndex = 376
        Me.tbDKIznos.Text = "0"
        Me.tbDKIznos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbDKIznos, "Pouzece")
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.Location = New System.Drawing.Point(264, 96)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(20, 22)
        Me.Button7.TabIndex = 497
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button7, "Platilac je pošiljalac")
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.Location = New System.Drawing.Point(264, 192)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(20, 22)
        Me.Button8.TabIndex = 498
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button8, "Platilac je primalac")
        '
        'tbR24_4
        '
        Me.tbR24_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR24_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR24_4.Location = New System.Drawing.Point(584, 294)
        Me.tbR24_4.Name = "tbR24_4"
        Me.tbR24_4.Size = New System.Drawing.Size(56, 20)
        Me.tbR24_4.TabIndex = 388
        Me.tbR24_4.Text = ""
        Me.tbR24_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR24_3
        '
        Me.tbR24_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR24_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR24_3.Location = New System.Drawing.Point(584, 278)
        Me.tbR24_3.Name = "tbR24_3"
        Me.tbR24_3.Size = New System.Drawing.Size(56, 20)
        Me.tbR24_3.TabIndex = 387
        Me.tbR24_3.Text = ""
        Me.tbR24_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR24_2
        '
        Me.tbR24_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR24_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR24_2.Location = New System.Drawing.Point(584, 262)
        Me.tbR24_2.Name = "tbR24_2"
        Me.tbR24_2.Size = New System.Drawing.Size(56, 18)
        Me.tbR24_2.TabIndex = 386
        Me.tbR24_2.Text = ""
        Me.tbR24_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR24_1
        '
        Me.tbR24_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR24_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR24_1.Location = New System.Drawing.Point(584, 246)
        Me.tbR24_1.Name = "tbR24_1"
        Me.tbR24_1.Size = New System.Drawing.Size(56, 20)
        Me.tbR24_1.TabIndex = 385
        Me.tbR24_1.Text = ""
        Me.tbR24_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbA79b4
        '
        Me.tbA79b4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbA79b4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b4.Location = New System.Drawing.Point(244, 841)
        Me.tbA79b4.MaxLength = 6
        Me.tbA79b4.Name = "tbA79b4"
        Me.tbA79b4.Size = New System.Drawing.Size(41, 20)
        Me.tbA79b4.TabIndex = 370
        Me.tbA79b4.Text = ""
        Me.tbA79b4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbA79a4
        '
        Me.tbA79a4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbA79a4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a4.Location = New System.Drawing.Point(204, 841)
        Me.tbA79a4.MaxLength = 2
        Me.tbA79a4.Name = "tbA79a4"
        Me.tbA79a4.Size = New System.Drawing.Size(40, 20)
        Me.tbA79a4.TabIndex = 369
        Me.tbA79a4.Text = ""
        Me.tbA79a4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbA79b3
        '
        Me.tbA79b3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbA79b3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b3.Location = New System.Drawing.Point(244, 825)
        Me.tbA79b3.MaxLength = 6
        Me.tbA79b3.Name = "tbA79b3"
        Me.tbA79b3.Size = New System.Drawing.Size(41, 20)
        Me.tbA79b3.TabIndex = 275
        Me.tbA79b3.Text = ""
        Me.tbA79b3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbA79a3
        '
        Me.tbA79a3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbA79a3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a3.Location = New System.Drawing.Point(204, 825)
        Me.tbA79a3.MaxLength = 2
        Me.tbA79a3.Name = "tbA79a3"
        Me.tbA79a3.Size = New System.Drawing.Size(40, 20)
        Me.tbA79a3.TabIndex = 274
        Me.tbA79a3.Text = ""
        Me.tbA79a3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbA79b2
        '
        Me.tbA79b2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbA79b2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b2.Location = New System.Drawing.Point(244, 809)
        Me.tbA79b2.MaxLength = 6
        Me.tbA79b2.Name = "tbA79b2"
        Me.tbA79b2.Size = New System.Drawing.Size(41, 20)
        Me.tbA79b2.TabIndex = 273
        Me.tbA79b2.Text = ""
        Me.tbA79b2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbA79a2
        '
        Me.tbA79a2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbA79a2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a2.Location = New System.Drawing.Point(204, 809)
        Me.tbA79a2.MaxLength = 2
        Me.tbA79a2.Name = "tbA79a2"
        Me.tbA79a2.Size = New System.Drawing.Size(40, 20)
        Me.tbA79a2.TabIndex = 272
        Me.tbA79a2.Text = ""
        Me.tbA79a2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbA79b1
        '
        Me.tbA79b1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbA79b1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b1.Location = New System.Drawing.Point(244, 793)
        Me.tbA79b1.MaxLength = 6
        Me.tbA79b1.Name = "tbA79b1"
        Me.tbA79b1.Size = New System.Drawing.Size(41, 20)
        Me.tbA79b1.TabIndex = 214
        Me.tbA79b1.Text = ""
        Me.tbA79b1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbA79a1
        '
        Me.tbA79a1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbA79a1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a1.Location = New System.Drawing.Point(204, 793)
        Me.tbA79a1.MaxLength = 2
        Me.tbA79a1.Name = "tbA79a1"
        Me.tbA79a1.Size = New System.Drawing.Size(40, 20)
        Me.tbA79a1.TabIndex = 213
        Me.tbA79a1.Text = ""
        Me.tbA79a1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb63a
        '
        Me.tb63a.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb63a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb63a.Location = New System.Drawing.Point(204, 880)
        Me.tb63a.MaxLength = 6
        Me.tb63a.Name = "tb63a"
        Me.tb63a.Size = New System.Drawing.Size(40, 20)
        Me.tb63a.TabIndex = 427
        Me.tb63a.Text = ""
        Me.tb63a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb62nd
        '
        Me.tb62nd.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb62nd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb62nd.Location = New System.Drawing.Point(288, 841)
        Me.tb62nd.MaxLength = 40
        Me.tb62nd.Name = "tb62nd"
        Me.tb62nd.Size = New System.Drawing.Size(243, 20)
        Me.tb62nd.TabIndex = 431
        Me.tb62nd.Text = ""
        '
        'tb62nc
        '
        Me.tb62nc.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb62nc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb62nc.Location = New System.Drawing.Point(288, 825)
        Me.tb62nc.MaxLength = 40
        Me.tb62nc.Name = "tb62nc"
        Me.tb62nc.Size = New System.Drawing.Size(243, 20)
        Me.tb62nc.TabIndex = 430
        Me.tb62nc.Text = ""
        '
        'tb62nb
        '
        Me.tb62nb.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb62nb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb62nb.Location = New System.Drawing.Point(288, 809)
        Me.tb62nb.MaxLength = 40
        Me.tb62nb.Name = "tb62nb"
        Me.tb62nb.Size = New System.Drawing.Size(243, 20)
        Me.tb62nb.TabIndex = 429
        Me.tb62nb.Text = ""
        '
        'tb62na
        '
        Me.tb62na.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb62na.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb62na.Location = New System.Drawing.Point(288, 793)
        Me.tb62na.MaxLength = 40
        Me.tb62na.Name = "tb62na"
        Me.tb62na.Size = New System.Drawing.Size(243, 20)
        Me.tb62na.TabIndex = 428
        Me.tb62na.Text = ""
        '
        'tbTug
        '
        Me.tbTug.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbTug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbTug.Location = New System.Drawing.Point(288, 880)
        Me.tbTug.MaxLength = 40
        Me.tbTug.Name = "tbTug"
        Me.tbTug.Size = New System.Drawing.Size(243, 20)
        Me.tbTug.TabIndex = 432
        Me.tbTug.Text = ""
        '
        'tbSumaNeto
        '
        Me.tbSumaNeto.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbSumaNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaNeto.Location = New System.Drawing.Point(584, 313)
        Me.tbSumaNeto.Name = "tbSumaNeto"
        Me.tbSumaNeto.Size = New System.Drawing.Size(56, 20)
        Me.tbSumaNeto.TabIndex = 448
        Me.tbSumaNeto.Text = ""
        Me.tbSumaNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR25a_2
        '
        Me.tbR25a_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR25a_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25a_2.Location = New System.Drawing.Point(645, 262)
        Me.tbR25a_2.Name = "tbR25a_2"
        Me.tbR25a_2.Size = New System.Drawing.Size(16, 20)
        Me.tbR25a_2.TabIndex = 390
        Me.tbR25a_2.Text = ""
        Me.tbR25a_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR25a_1
        '
        Me.tbR25a_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR25a_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25a_1.Location = New System.Drawing.Point(645, 246)
        Me.tbR25a_1.Name = "tbR25a_1"
        Me.tbR25a_1.Size = New System.Drawing.Size(16, 20)
        Me.tbR25a_1.TabIndex = 389
        Me.tbR25a_1.Text = ""
        Me.tbR25a_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR36
        '
        Me.tbR36.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR36.Location = New System.Drawing.Point(660, 456)
        Me.tbR36.Name = "tbR36"
        Me.tbR36.Size = New System.Drawing.Size(72, 20)
        Me.tbR36.TabIndex = 384
        Me.tbR36.Text = ""
        Me.tbR36.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR33_2
        '
        Me.tbR33_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR33_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR33_2.Location = New System.Drawing.Point(660, 405)
        Me.tbR33_2.Name = "tbR33_2"
        Me.tbR33_2.Size = New System.Drawing.Size(72, 20)
        Me.tbR33_2.TabIndex = 383
        Me.tbR33_2.Text = ""
        Me.tbR33_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR33_1
        '
        Me.tbR33_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR33_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR33_1.Location = New System.Drawing.Point(660, 376)
        Me.tbR33_1.Name = "tbR33_1"
        Me.tbR33_1.Size = New System.Drawing.Size(72, 20)
        Me.tbR33_1.TabIndex = 382
        Me.tbR33_1.Text = ""
        Me.tbR33_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox28
        '
        Me.TextBox28.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.TextBox28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox28.Location = New System.Drawing.Point(660, 344)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(72, 20)
        Me.TextBox28.TabIndex = 381
        Me.TextBox28.Text = ""
        '
        'tbR13_2
        '
        Me.tbR13_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR13_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR13_2.Location = New System.Drawing.Point(660, 134)
        Me.tbR13_2.Name = "tbR13_2"
        Me.tbR13_2.Size = New System.Drawing.Size(72, 20)
        Me.tbR13_2.TabIndex = 380
        Me.tbR13_2.Text = ""
        Me.tbR13_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR13_1
        '
        Me.tbR13_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR13_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR13_1.Location = New System.Drawing.Point(660, 104)
        Me.tbR13_1.Name = "tbR13_1"
        Me.tbR13_1.Size = New System.Drawing.Size(72, 20)
        Me.tbR13_1.TabIndex = 379
        Me.tbR13_1.Text = ""
        Me.tbR13_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox23
        '
        Me.TextBox23.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.TextBox23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox23.Location = New System.Drawing.Point(660, 73)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(72, 20)
        Me.TextBox23.TabIndex = 378
        Me.TextBox23.Text = ""
        '
        'tbPrevF
        '
        Me.tbPrevF.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPrevF.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevF.Location = New System.Drawing.Point(8, 774)
        Me.tbPrevF.MaxLength = 18
        Me.tbPrevF.Name = "tbPrevF"
        Me.tbPrevF.Size = New System.Drawing.Size(96, 22)
        Me.tbPrevF.TabIndex = 376
        Me.tbPrevF.Text = "0"
        Me.tbPrevF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbSumaU
        '
        Me.tbSumaU.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbSumaU.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaU.Location = New System.Drawing.Point(636, 903)
        Me.tbSumaU.MaxLength = 18
        Me.tbSumaU.Name = "tbSumaU"
        Me.tbSumaU.Size = New System.Drawing.Size(96, 22)
        Me.tbSumaU.TabIndex = 374
        Me.tbSumaU.Text = "0"
        Me.tbSumaU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbSumaF
        '
        Me.tbSumaF.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbSumaF.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaF.Location = New System.Drawing.Point(8, 903)
        Me.tbSumaF.MaxLength = 18
        Me.tbSumaF.Name = "tbSumaF"
        Me.tbSumaF.Size = New System.Drawing.Size(96, 22)
        Me.tbSumaF.TabIndex = 373
        Me.tbSumaF.Text = "0"
        Me.tbSumaF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR25a_4
        '
        Me.tbR25a_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR25a_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25a_4.Location = New System.Drawing.Point(645, 294)
        Me.tbR25a_4.Name = "tbR25a_4"
        Me.tbR25a_4.Size = New System.Drawing.Size(16, 20)
        Me.tbR25a_4.TabIndex = 398
        Me.tbR25a_4.Text = ""
        Me.tbR25a_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR25a_3
        '
        Me.tbR25a_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR25a_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25a_3.Location = New System.Drawing.Point(645, 278)
        Me.tbR25a_3.Name = "tbR25a_3"
        Me.tbR25a_3.Size = New System.Drawing.Size(16, 20)
        Me.tbR25a_3.TabIndex = 397
        Me.tbR25a_3.Text = ""
        Me.tbR25a_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR25b_4
        '
        Me.tbR25b_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR25b_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25b_4.Location = New System.Drawing.Point(669, 294)
        Me.tbR25b_4.Name = "tbR25b_4"
        Me.tbR25b_4.Size = New System.Drawing.Size(25, 20)
        Me.tbR25b_4.TabIndex = 402
        Me.tbR25b_4.Text = ""
        Me.tbR25b_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR25b_3
        '
        Me.tbR25b_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR25b_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25b_3.Location = New System.Drawing.Point(669, 278)
        Me.tbR25b_3.Name = "tbR25b_3"
        Me.tbR25b_3.Size = New System.Drawing.Size(25, 20)
        Me.tbR25b_3.TabIndex = 401
        Me.tbR25b_3.Text = ""
        Me.tbR25b_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR25b_2
        '
        Me.tbR25b_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR25b_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25b_2.Location = New System.Drawing.Point(669, 262)
        Me.tbR25b_2.Name = "tbR25b_2"
        Me.tbR25b_2.Size = New System.Drawing.Size(25, 20)
        Me.tbR25b_2.TabIndex = 400
        Me.tbR25b_2.Text = ""
        Me.tbR25b_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR25b_1
        '
        Me.tbR25b_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR25b_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25b_1.Location = New System.Drawing.Point(669, 246)
        Me.tbR25b_1.Name = "tbR25b_1"
        Me.tbR25b_1.Size = New System.Drawing.Size(25, 20)
        Me.tbR25b_1.TabIndex = 399
        Me.tbR25b_1.Text = ""
        Me.tbR25b_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR26_4
        '
        Me.tbR26_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR26_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR26_4.Location = New System.Drawing.Point(707, 294)
        Me.tbR26_4.Name = "tbR26_4"
        Me.tbR26_4.Size = New System.Drawing.Size(25, 20)
        Me.tbR26_4.TabIndex = 406
        Me.tbR26_4.Text = ""
        Me.tbR26_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR26_3
        '
        Me.tbR26_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR26_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR26_3.Location = New System.Drawing.Point(707, 278)
        Me.tbR26_3.Name = "tbR26_3"
        Me.tbR26_3.Size = New System.Drawing.Size(25, 20)
        Me.tbR26_3.TabIndex = 405
        Me.tbR26_3.Text = ""
        Me.tbR26_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR26_2
        '
        Me.tbR26_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR26_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR26_2.Location = New System.Drawing.Point(707, 262)
        Me.tbR26_2.Name = "tbR26_2"
        Me.tbR26_2.Size = New System.Drawing.Size(25, 18)
        Me.tbR26_2.TabIndex = 404
        Me.tbR26_2.Text = ""
        Me.tbR26_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR26_1
        '
        Me.tbR26_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR26_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR26_1.Location = New System.Drawing.Point(707, 246)
        Me.tbR26_1.Name = "tbR26_1"
        Me.tbR26_1.Size = New System.Drawing.Size(25, 20)
        Me.tbR26_1.TabIndex = 403
        Me.tbR26_1.Text = ""
        Me.tbR26_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak1F
        '
        Me.tbNak1F.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbNak1F.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak1F.Location = New System.Drawing.Point(8, 793)
        Me.tbNak1F.MaxLength = 18
        Me.tbNak1F.Name = "tbNak1F"
        Me.tbNak1F.Size = New System.Drawing.Size(96, 22)
        Me.tbNak1F.TabIndex = 433
        Me.tbNak1F.Text = "0"
        Me.tbNak1F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak2F
        '
        Me.tbNak2F.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbNak2F.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak2F.Location = New System.Drawing.Point(8, 809)
        Me.tbNak2F.MaxLength = 18
        Me.tbNak2F.Name = "tbNak2F"
        Me.tbNak2F.Size = New System.Drawing.Size(96, 22)
        Me.tbNak2F.TabIndex = 434
        Me.tbNak2F.Text = "0"
        Me.tbNak2F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak4F
        '
        Me.tbNak4F.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbNak4F.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak4F.Location = New System.Drawing.Point(8, 841)
        Me.tbNak4F.MaxLength = 18
        Me.tbNak4F.Name = "tbNak4F"
        Me.tbNak4F.Size = New System.Drawing.Size(96, 22)
        Me.tbNak4F.TabIndex = 436
        Me.tbNak4F.Text = "0"
        Me.tbNak4F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak3F
        '
        Me.tbNak3F.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbNak3F.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak3F.Location = New System.Drawing.Point(8, 825)
        Me.tbNak3F.MaxLength = 18
        Me.tbNak3F.Name = "tbNak3F"
        Me.tbNak3F.Size = New System.Drawing.Size(96, 22)
        Me.tbNak3F.TabIndex = 435
        Me.tbNak3F.Text = "0"
        Me.tbNak3F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTugF
        '
        Me.tbTugF.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbTugF.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbTugF.Location = New System.Drawing.Point(8, 880)
        Me.tbTugF.MaxLength = 18
        Me.tbTugF.Name = "tbTugF"
        Me.tbTugF.Size = New System.Drawing.Size(96, 22)
        Me.tbTugF.TabIndex = 437
        Me.tbTugF.Text = "0"
        Me.tbTugF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTugU
        '
        Me.tbTugU.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbTugU.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbTugU.Location = New System.Drawing.Point(636, 880)
        Me.tbTugU.MaxLength = 18
        Me.tbTugU.Name = "tbTugU"
        Me.tbTugU.Size = New System.Drawing.Size(96, 22)
        Me.tbTugU.TabIndex = 442
        Me.tbTugU.Text = "0"
        Me.tbTugU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak4U
        '
        Me.tbNak4U.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbNak4U.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak4U.Location = New System.Drawing.Point(636, 841)
        Me.tbNak4U.MaxLength = 18
        Me.tbNak4U.Name = "tbNak4U"
        Me.tbNak4U.Size = New System.Drawing.Size(96, 22)
        Me.tbNak4U.TabIndex = 441
        Me.tbNak4U.Text = "0"
        Me.tbNak4U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak3U
        '
        Me.tbNak3U.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbNak3U.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak3U.Location = New System.Drawing.Point(636, 825)
        Me.tbNak3U.MaxLength = 18
        Me.tbNak3U.Name = "tbNak3U"
        Me.tbNak3U.Size = New System.Drawing.Size(96, 22)
        Me.tbNak3U.TabIndex = 440
        Me.tbNak3U.Text = "0"
        Me.tbNak3U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak2U
        '
        Me.tbNak2U.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbNak2U.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak2U.Location = New System.Drawing.Point(636, 809)
        Me.tbNak2U.MaxLength = 18
        Me.tbNak2U.Name = "tbNak2U"
        Me.tbNak2U.Size = New System.Drawing.Size(96, 22)
        Me.tbNak2U.TabIndex = 439
        Me.tbNak2U.Text = "0"
        Me.tbNak2U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak1U
        '
        Me.tbNak1U.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbNak1U.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak1U.Location = New System.Drawing.Point(636, 793)
        Me.tbNak1U.MaxLength = 18
        Me.tbNak1U.Name = "tbNak1U"
        Me.tbNak1U.Size = New System.Drawing.Size(96, 22)
        Me.tbNak1U.TabIndex = 438
        Me.tbNak1U.Text = "0"
        Me.tbNak1U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR8
        '
        Me.tbR8.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR8.Location = New System.Drawing.Point(716, 40)
        Me.tbR8.Name = "tbR8"
        Me.tbR8.Size = New System.Drawing.Size(16, 18)
        Me.tbR8.TabIndex = 443
        Me.tbR8.Text = ""
        Me.tbR8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR20a
        '
        Me.tbR20a.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR20a.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR20a.Location = New System.Drawing.Point(691, 184)
        Me.tbR20a.Name = "tbR20a"
        Me.tbR20a.Size = New System.Drawing.Size(41, 18)
        Me.tbR20a.TabIndex = 444
        Me.tbR20a.Text = ""
        '
        'tbR20b
        '
        Me.tbR20b.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR20b.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR20b.Location = New System.Drawing.Point(691, 200)
        Me.tbR20b.Name = "tbR20b"
        Me.tbR20b.Size = New System.Drawing.Size(41, 18)
        Me.tbR20b.TabIndex = 445
        Me.tbR20b.Text = ""
        '
        'tbR7
        '
        Me.tbR7.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR7.Location = New System.Drawing.Point(716, 11)
        Me.tbR7.Name = "tbR7"
        Me.tbR7.Size = New System.Drawing.Size(16, 18)
        Me.tbR7.TabIndex = 447
        Me.tbR7.Text = ""
        '
        'tbSumaOsovina
        '
        Me.tbSumaOsovina.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbSumaOsovina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaOsovina.Location = New System.Drawing.Point(707, 313)
        Me.tbSumaOsovina.Name = "tbSumaOsovina"
        Me.tbSumaOsovina.Size = New System.Drawing.Size(25, 20)
        Me.tbSumaOsovina.TabIndex = 450
        Me.tbSumaOsovina.Text = ""
        Me.tbSumaOsovina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbSumaKola
        '
        Me.tbSumaKola.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbSumaKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaKola.Location = New System.Drawing.Point(669, 313)
        Me.tbSumaKola.Name = "tbSumaKola"
        Me.tbSumaKola.Size = New System.Drawing.Size(25, 20)
        Me.tbSumaKola.TabIndex = 449
        Me.tbSumaKola.Text = ""
        Me.tbSumaKola.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR18
        '
        Me.tbR18.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR18.Location = New System.Drawing.Point(356, 176)
        Me.tbR18.MaxLength = 100
        Me.tbR18.Multiline = True
        Me.tbR18.Name = "tbR18"
        Me.tbR18.Size = New System.Drawing.Size(128, 48)
        Me.tbR18.TabIndex = 451
        Me.tbR18.Text = ""
        '
        'tbR19
        '
        Me.tbR19.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR19.Location = New System.Drawing.Point(493, 176)
        Me.tbR19.MaxLength = 100
        Me.tbR19.Multiline = True
        Me.tbR19.Name = "tbR19"
        Me.tbR19.Size = New System.Drawing.Size(122, 48)
        Me.tbR19.TabIndex = 452
        Me.tbR19.Text = ""
        '
        'tbR68b
        '
        Me.tbR68b.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR68b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR68b.Location = New System.Drawing.Point(400, 1008)
        Me.tbR68b.MaxLength = 20
        Me.tbR68b.Name = "tbR68b"
        Me.tbR68b.Size = New System.Drawing.Size(120, 20)
        Me.tbR68b.TabIndex = 453
        Me.tbR68b.Text = "0"
        Me.tbR68b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbSaobracaj
        '
        Me.gbSaobracaj.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gbSaobracaj.Controls.Add(Me.rbDencana)
        Me.gbSaobracaj.Controls.Add(Me.rbKolska)
        Me.gbSaobracaj.Location = New System.Drawing.Point(920, 544)
        Me.gbSaobracaj.Name = "gbSaobracaj"
        Me.gbSaobracaj.Size = New System.Drawing.Size(24, 24)
        Me.gbSaobracaj.TabIndex = 235
        Me.gbSaobracaj.TabStop = False
        Me.gbSaobracaj.Text = " [ POSILJKA ]  "
        Me.gbSaobracaj.Visible = False
        '
        'rbDencana
        '
        Me.rbDencana.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.rbDencana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDencana.Location = New System.Drawing.Point(5, 47)
        Me.rbDencana.Name = "rbDencana"
        Me.rbDencana.Size = New System.Drawing.Size(84, 24)
        Me.rbDencana.TabIndex = 27
        Me.rbDencana.Text = "D e n c a n a "
        Me.rbDencana.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'rbKolska
        '
        Me.rbKolska.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.rbKolska.Checked = True
        Me.rbKolska.Location = New System.Drawing.Point(24, 16)
        Me.rbKolska.Name = "rbKolska"
        Me.rbKolska.Size = New System.Drawing.Size(86, 21)
        Me.rbKolska.TabIndex = 26
        Me.rbKolska.TabStop = True
        Me.rbKolska.Text = "K o l s k a "
        Me.rbKolska.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.Black
        Me.ComboBox1.Items.AddRange(New Object() {"1. Spt 36", "2. Ugovor"})
        Me.ComboBox1.Location = New System.Drawing.Point(6, 60)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(210, 23)
        Me.ComboBox1.TabIndex = 1
        '
        'tbUgovor
        '
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.ForeColor = System.Drawing.SystemColors.Highlight
        Me.tbUgovor.Location = New System.Drawing.Point(6, 132)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(58, 23)
        Me.tbUgovor.TabIndex = 3
        Me.tbUgovor.Text = ""
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.Items.AddRange(New Object() {"1. Pojedinacna", "2. Grupa kola", "3. Voz"})
        Me.ComboBox2.Location = New System.Drawing.Point(112, 132)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(104, 23)
        Me.ComboBox2.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(74, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 26)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "Naèin prevoza"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.tbNajava)
        Me.GroupBox1.Controls.Add(Me.lblNajava)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.ComboBox4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ComboBox3)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbUgovor)
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Location = New System.Drawing.Point(780, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(220, 168)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'tbNajava
        '
        Me.tbNajava.Location = New System.Drawing.Point(115, 109)
        Me.tbNajava.MaxLength = 10
        Me.tbNajava.Name = "tbNajava"
        Me.tbNajava.TabIndex = 344
        Me.tbNajava.Text = ""
        '
        'lblNajava
        '
        Me.lblNajava.Enabled = False
        Me.lblNajava.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblNajava.Location = New System.Drawing.Point(80, 115)
        Me.lblNajava.Name = "lblNajava"
        Me.lblNajava.Size = New System.Drawing.Size(40, 17)
        Me.lblNajava.TabIndex = 343
        Me.lblNajava.Text = "Najava"
        '
        'Label7
        '
        Me.Label7.Enabled = False
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 341
        Me.Label7.Text = "Tarifa"
        '
        'ComboBox4
        '
        Me.ComboBox4.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.ForeColor = System.Drawing.Color.Black
        Me.ComboBox4.Items.AddRange(New Object() {"0 Unutrasnji saobracaj", "1 Uvoz reekspedicija", "2 Izvoz reekspedicija", "3 Lucki uvoz - nedozvoljeno", "4 Lucki izvoz - nedozvoljeno", "5 Recni uvoz", "6 Recni izvoz", "8 Uvoz zeleznica-drum", "9 Izvoz zeleznica-drum"})
        Me.ComboBox4.Location = New System.Drawing.Point(5, 22)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(210, 23)
        Me.ComboBox4.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 16)
        Me.Label6.TabIndex = 340
        Me.Label6.Text = "Vrsta saobracaja"
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.ForeColor = System.Drawing.Color.Black
        Me.ComboBox3.Items.AddRange(New Object() {"Pojedinacne posiljke (00) ", "Grupa kola - cl.59, t.4 (49) ", "Marsrutni voz - cl.57, t.1 (46)", "P9 Uputnica za besplatan prevoz", "SPT49 - Prevoz za potrebe ZS", "NP - Narocite posiljke", "Mes. vojni transport - cl.45, t.4 (39)", "Mes. vojni transport - cl.45, t.6 (40) ", "Tov. prib. vlasnistvo kor. prevoza - cl.52, t.9 (43)", "Poseban voz - cl.58, t.5(48) ", "Besplatan prevoz (99)", "Doracunska karta", "Prevoz po smernicama za TK37 (37)"})
        Me.ComboBox3.Location = New System.Drawing.Point(6, 84)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(210, 23)
        Me.ComboBox3.TabIndex = 2
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(7, 111)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(56, 20)
        Me.Button10.TabIndex = 337
        Me.Button10.Text = "Ugovor"
        '
        'dgError
        '
        Me.dgError.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.dgError.BackColor = System.Drawing.Color.DarkGray
        Me.dgError.CaptionBackColor = System.Drawing.Color.White
        Me.dgError.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dgError.CaptionForeColor = System.Drawing.Color.Navy
        Me.dgError.DataMember = ""
        Me.dgError.ForeColor = System.Drawing.Color.Black
        Me.dgError.GridLineColor = System.Drawing.Color.Black
        Me.dgError.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.dgError.HeaderBackColor = System.Drawing.Color.Silver
        Me.dgError.HeaderForeColor = System.Drawing.Color.Black
        Me.dgError.LinkColor = System.Drawing.Color.Navy
        Me.dgError.Location = New System.Drawing.Point(928, 568)
        Me.dgError.Name = "dgError"
        Me.dgError.ParentRowsBackColor = System.Drawing.Color.White
        Me.dgError.ParentRowsForeColor = System.Drawing.Color.Black
        Me.dgError.PreferredColumnWidth = 230
        Me.dgError.ReadOnly = True
        Me.dgError.SelectionBackColor = System.Drawing.Color.Navy
        Me.dgError.SelectionForeColor = System.Drawing.Color.White
        Me.dgError.Size = New System.Drawing.Size(16, 24)
        Me.dgError.TabIndex = 245
        Me.dgError.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox4.Controls.Add(Me.cmbManipulativnaMestaEx)
        Me.GroupBox4.Controls.Add(Me.DatumOtp)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.tbBrojOtp)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.tbStanicaOtp)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.Controls.Add(Me.btnStanicaOtp)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(780, 200)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(220, 112)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = " [ OTPRAVLJANJE ] "
        '
        'DatumOtp
        '
        Me.DatumOtp.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.DatumOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOtp.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOtp.Location = New System.Drawing.Point(92, 84)
        Me.DatumOtp.Name = "DatumOtp"
        Me.DatumOtp.Size = New System.Drawing.Size(124, 22)
        Me.DatumOtp.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.Enabled = False
        Me.Label17.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label17.Location = New System.Drawing.Point(93, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 11)
        Me.Label17.TabIndex = 229
        Me.Label17.Text = "Datum"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label15
        '
        Me.Label15.Enabled = False
        Me.Label15.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 11)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Broj"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label10
        '
        Me.Label10.Enabled = False
        Me.Label10.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 11)
        Me.Label10.TabIndex = 227
        Me.Label10.Text = "Stanica"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(67, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 24)
        Me.Label12.TabIndex = 37
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(72, 84)
        Me.TextBox1.MaxLength = 1
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(15, 22)
        Me.TextBox1.TabIndex = 51
        Me.TextBox1.Text = ""
        Me.TextBox1.Visible = False
        '
        'btnStanicaOtp
        '
        Me.btnStanicaOtp.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnStanicaOtp.Location = New System.Drawing.Point(192, 8)
        Me.btnStanicaOtp.Name = "btnStanicaOtp"
        Me.btnStanicaOtp.Size = New System.Drawing.Size(24, 22)
        Me.btnStanicaOtp.TabIndex = 6
        Me.btnStanicaOtp.Text = "..."
        Me.btnStanicaOtp.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox5.Controls.Add(Me.cmbManipulativnaMestaIm)
        Me.GroupBox5.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox5.Controls.Add(Me.tbBrojPr)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.tbStanicaPr)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.btnStanicaPr)
        Me.GroupBox5.Controls.Add(Me.TextBox2)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(780, 312)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(220, 112)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = " [ PRISPECE ] "
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(92, 86)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(124, 22)
        Me.DateTimePicker2.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.Enabled = False
        Me.Label20.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label20.Location = New System.Drawing.Point(95, 77)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(34, 11)
        Me.Label20.TabIndex = 231
        Me.Label20.Text = "Datum"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label21
        '
        Me.Label21.Enabled = False
        Me.Label21.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 77)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 11)
        Me.Label21.TabIndex = 230
        Me.Label21.Text = "Broj"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label18
        '
        Me.Label18.Enabled = False
        Me.Label18.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label18.Location = New System.Drawing.Point(8, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 11)
        Me.Label18.TabIndex = 229
        Me.Label18.Text = "Stanica"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label13
        '
        Me.Label13.Enabled = False
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(67, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 24)
        Me.Label13.TabIndex = 39
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnStanicaPr
        '
        Me.btnStanicaPr.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnStanicaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnStanicaPr.Location = New System.Drawing.Point(192, 8)
        Me.btnStanicaPr.Name = "btnStanicaPr"
        Me.btnStanicaPr.Size = New System.Drawing.Size(24, 22)
        Me.btnStanicaPr.TabIndex = 33
        Me.btnStanicaPr.Text = "..."
        Me.btnStanicaPr.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(72, 88)
        Me.TextBox2.MaxLength = 1
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(15, 22)
        Me.TextBox2.TabIndex = 52
        Me.TextBox2.Text = ""
        Me.TextBox2.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(254, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 372
        Me.Label3.Text = "Kontrolni broj"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbR21_1
        '
        Me.tbR21_1.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR21_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR21_1.Location = New System.Drawing.Point(353, 239)
        Me.tbR21_1.MaxLength = 12
        Me.tbR21_1.Name = "tbR21_1"
        Me.tbR21_1.Size = New System.Drawing.Size(32, 20)
        Me.tbR21_1.TabIndex = 368
        Me.tbR21_1.Text = ""
        Me.tbR21_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox6
        '
        Me.CheckBox6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.CheckBox6.Location = New System.Drawing.Point(379, 975)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(16, 16)
        Me.CheckBox6.TabIndex = 366
        '
        'CheckBox7
        '
        Me.CheckBox7.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.CheckBox7.Checked = True
        Me.CheckBox7.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox7.Location = New System.Drawing.Point(605, 346)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(16, 17)
        Me.CheckBox7.TabIndex = 358
        '
        'CheckBox5
        '
        Me.CheckBox5.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.CheckBox5.Location = New System.Drawing.Point(521, 341)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(16, 17)
        Me.CheckBox5.TabIndex = 357
        '
        'cbR6
        '
        Me.cbR6.BackColor = System.Drawing.Color.Transparent
        Me.cbR6.Location = New System.Drawing.Point(640, 43)
        Me.cbR6.Name = "cbR6"
        Me.cbR6.Size = New System.Drawing.Size(16, 17)
        Me.cbR6.TabIndex = 351
        '
        'cbR5D
        '
        Me.cbR5D.BackColor = System.Drawing.Color.Transparent
        Me.cbR5D.Location = New System.Drawing.Point(569, 22)
        Me.cbR5D.Name = "cbR5D"
        Me.cbR5D.Size = New System.Drawing.Size(16, 17)
        Me.cbR5D.TabIndex = 350
        '
        'cbR5O
        '
        Me.cbR5O.BackColor = System.Drawing.Color.Transparent
        Me.cbR5O.Location = New System.Drawing.Point(480, 42)
        Me.cbR5O.Name = "cbR5O"
        Me.cbR5O.Size = New System.Drawing.Size(16, 17)
        Me.cbR5O.TabIndex = 349
        '
        'cbR5R
        '
        Me.cbR5R.BackColor = System.Drawing.Color.Transparent
        Me.cbR5R.Checked = True
        Me.cbR5R.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbR5R.Location = New System.Drawing.Point(480, 24)
        Me.cbR5R.Name = "cbR5R"
        Me.cbR5R.Size = New System.Drawing.Size(16, 17)
        Me.cbR5R.TabIndex = 348
        '
        'cbR4D
        '
        Me.cbR4D.BackColor = System.Drawing.Color.Transparent
        Me.cbR4D.Location = New System.Drawing.Point(393, 42)
        Me.cbR4D.Name = "cbR4D"
        Me.cbR4D.Size = New System.Drawing.Size(16, 17)
        Me.cbR4D.TabIndex = 347
        '
        'cbRID
        '
        Me.cbRID.BackColor = System.Drawing.Color.White
        Me.cbRID.Location = New System.Drawing.Point(488, 489)
        Me.cbRID.Name = "cbRID"
        Me.cbRID.Size = New System.Drawing.Size(16, 16)
        Me.cbRID.TabIndex = 346
        '
        'CheckBox4
        '
        Me.CheckBox4.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.CheckBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.CheckBox4.Location = New System.Drawing.Point(420, 659)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(104, 16)
        Me.CheckBox4.TabIndex = 345
        Me.CheckBox4.Text = " 4 Franko iznos"
        '
        'CheckBox3
        '
        Me.CheckBox3.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.CheckBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(296, 659)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(136, 16)
        Me.CheckBox3.TabIndex = 344
        Me.CheckBox3.Text = " 3 Franko prevoznina"
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(16, 659)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(176, 21)
        Me.CheckBox2.TabIndex = 343
        Me.CheckBox2.Text = " 2 Franko prevoznina ukljucivo"
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(16, 637)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(152, 16)
        Me.CheckBox1.TabIndex = 342
        Me.CheckBox1.Text = " 1 Franko svi troskovi"
        '
        'tbKolauVozu
        '
        Me.tbKolauVozu.BackColor = System.Drawing.Color.White
        Me.tbKolauVozu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbKolauVozu.Enabled = False
        Me.tbKolauVozu.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKolauVozu.Location = New System.Drawing.Point(444, 240)
        Me.tbKolauVozu.MaxLength = 4
        Me.tbKolauVozu.Name = "tbKolauVozu"
        Me.tbKolauVozu.Size = New System.Drawing.Size(24, 11)
        Me.tbKolauVozu.TabIndex = 53
        Me.tbKolauVozu.Text = ""
        Me.tbKolauVozu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rtbR34
        '
        Me.rtbR34.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.rtbR34.Location = New System.Drawing.Point(8, 436)
        Me.rtbR34.Name = "rtbR34"
        Me.rtbR34.Size = New System.Drawing.Size(250, 50)
        Me.rtbR34.TabIndex = 319
        Me.rtbR34.Text = ""
        '
        'rtbR27
        '
        Me.rtbR27.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.rtbR27.Location = New System.Drawing.Point(56, 258)
        Me.rtbR27.Name = "rtbR27"
        Me.rtbR27.Size = New System.Drawing.Size(288, 104)
        Me.rtbR27.TabIndex = 301
        Me.rtbR27.Text = ""
        '
        'rtb37
        '
        Me.rtb37.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.rtb37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtb37.Location = New System.Drawing.Point(8, 506)
        Me.rtb37.Name = "rtb37"
        Me.rtb37.Size = New System.Drawing.Size(608, 94)
        Me.rtb37.TabIndex = 300
        Me.rtb37.Text = ""
        '
        'tb20a
        '
        Me.tb20a.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tb20a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20a.Location = New System.Drawing.Point(192, 656)
        Me.tb20a.MaxLength = 2
        Me.tb20a.Name = "tb20a"
        Me.tb20a.Size = New System.Drawing.Size(24, 20)
        Me.tb20a.TabIndex = 40
        Me.tb20a.Text = ""
        '
        'tb20d
        '
        Me.tb20d.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tb20d.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20d.Location = New System.Drawing.Point(264, 656)
        Me.tb20d.MaxLength = 2
        Me.tb20d.Name = "tb20d"
        Me.tb20d.Size = New System.Drawing.Size(24, 20)
        Me.tb20d.TabIndex = 43
        Me.tb20d.Text = ""
        '
        'tb20c
        '
        Me.tb20c.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tb20c.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20c.Location = New System.Drawing.Point(240, 656)
        Me.tb20c.MaxLength = 2
        Me.tb20c.Name = "tb20c"
        Me.tb20c.Size = New System.Drawing.Size(24, 20)
        Me.tb20c.TabIndex = 42
        Me.tb20c.Text = ""
        '
        'tb20b
        '
        Me.tb20b.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tb20b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20b.Location = New System.Drawing.Point(216, 656)
        Me.tb20b.MaxLength = 2
        Me.tb20b.Name = "tb20b"
        Me.tb20b.Size = New System.Drawing.Size(24, 20)
        Me.tb20b.TabIndex = 41
        Me.tb20b.Text = ""
        '
        'cbR4K
        '
        Me.cbR4K.BackColor = System.Drawing.Color.Transparent
        Me.cbR4K.Checked = True
        Me.cbR4K.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbR4K.Location = New System.Drawing.Point(393, 24)
        Me.cbR4K.Name = "cbR4K"
        Me.cbR4K.Size = New System.Drawing.Size(16, 17)
        Me.cbR4K.TabIndex = 38
        '
        'tbIBK
        '
        Me.tbIBK.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbIBK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIBK.Location = New System.Drawing.Point(386, 239)
        Me.tbIBK.MaxLength = 12
        Me.tbIBK.Name = "tbIBK"
        Me.tbIBK.Size = New System.Drawing.Size(94, 20)
        Me.tbIBK.TabIndex = 36
        Me.tbIBK.Text = ""
        Me.tbIBK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbControl
        '
        Me.tbControl.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbControl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbControl.Enabled = False
        Me.tbControl.ForeColor = System.Drawing.Color.Silver
        Me.tbControl.Location = New System.Drawing.Point(16, 1016)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.Size = New System.Drawing.Size(128, 13)
        Me.tbControl.TabIndex = 0
        Me.tbControl.Text = "UTL 4 OKP"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.PapayaWhip
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.gbDorKarta)
        Me.Panel1.Controls.Add(Me.GroupBox7)
        Me.Panel1.Controls.Add(Me.tbR53_LP2)
        Me.Panel1.Controls.Add(Me.tbPrev2)
        Me.Panel1.Controls.Add(Me.tbPrev1)
        Me.Panel1.Controls.Add(Me.tbStanicaLom)
        Me.Panel1.Controls.Add(Me.Label51)
        Me.Panel1.Controls.Add(Me.cbZsPrevozniPut)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.tbCtrlNum)
        Me.Panel1.Controls.Add(Me.tbIBK)
        Me.Panel1.Controls.Add(Me.cbR5E)
        Me.Panel1.Controls.Add(Me.tbIBK_4)
        Me.Panel1.Controls.Add(Me.tbIBK_3)
        Me.Panel1.Controls.Add(Me.tbIBK_2)
        Me.Panel1.Controls.Add(Me.tbR43f)
        Me.Panel1.Controls.Add(Me.tbR43e)
        Me.Panel1.Controls.Add(Me.tbR43d)
        Me.Panel1.Controls.Add(Me.tbR43c)
        Me.Panel1.Controls.Add(Me.tbR43b)
        Me.Panel1.Controls.Add(Me.tbR42f)
        Me.Panel1.Controls.Add(Me.tbR42e)
        Me.Panel1.Controls.Add(Me.tbR42d)
        Me.Panel1.Controls.Add(Me.tbR42c)
        Me.Panel1.Controls.Add(Me.tbR42b)
        Me.Panel1.Controls.Add(Me.tbR43a)
        Me.Panel1.Controls.Add(Me.tbR42a)
        Me.Panel1.Controls.Add(Me.tbPdvIznosU)
        Me.Panel1.Controls.Add(Me.tbPdvIznosF)
        Me.Panel1.Controls.Add(Me.tb63b)
        Me.Panel1.Controls.Add(Me.tbPDV)
        Me.Panel1.Controls.Add(Me.tbPDVU)
        Me.Panel1.Controls.Add(Me.tbPDVF)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.tbR46)
        Me.Panel1.Controls.Add(Me.tbR59)
        Me.Panel1.Controls.Add(Me.tbR58)
        Me.Panel1.Controls.Add(Me.tbR2)
        Me.Panel1.Controls.Add(Me.tb15_1)
        Me.Panel1.Controls.Add(Me.tbR32b)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.rtbR16)
        Me.Panel1.Controls.Add(Me.rtbR10)
        Me.Panel1.Controls.Add(Me.tbR9)
        Me.Panel1.Controls.Add(Me.tbR51)
        Me.Panel1.Controls.Add(Me.tbR68b)
        Me.Panel1.Controls.Add(Me.tbR19)
        Me.Panel1.Controls.Add(Me.tbR18)
        Me.Panel1.Controls.Add(Me.tbSumaOsovina)
        Me.Panel1.Controls.Add(Me.tbSumaKola)
        Me.Panel1.Controls.Add(Me.tbSumaNeto)
        Me.Panel1.Controls.Add(Me.tbR7)
        Me.Panel1.Controls.Add(Me.tbR28)
        Me.Panel1.Controls.Add(Me.tbR20b)
        Me.Panel1.Controls.Add(Me.tbR20a)
        Me.Panel1.Controls.Add(Me.tbR8)
        Me.Panel1.Controls.Add(Me.tbTugU)
        Me.Panel1.Controls.Add(Me.tbNak4U)
        Me.Panel1.Controls.Add(Me.tbNak3U)
        Me.Panel1.Controls.Add(Me.tbNak2U)
        Me.Panel1.Controls.Add(Me.tbNak1U)
        Me.Panel1.Controls.Add(Me.tbTugF)
        Me.Panel1.Controls.Add(Me.tbNak4F)
        Me.Panel1.Controls.Add(Me.tbNak3F)
        Me.Panel1.Controls.Add(Me.tbNak2F)
        Me.Panel1.Controls.Add(Me.tbNak1F)
        Me.Panel1.Controls.Add(Me.tbTug)
        Me.Panel1.Controls.Add(Me.tb62nd)
        Me.Panel1.Controls.Add(Me.tb62nc)
        Me.Panel1.Controls.Add(Me.tb62nb)
        Me.Panel1.Controls.Add(Me.tb62na)
        Me.Panel1.Controls.Add(Me.tb63a)
        Me.Panel1.Controls.Add(Me.tbR57_3)
        Me.Panel1.Controls.Add(Me.tbR57_2)
        Me.Panel1.Controls.Add(Me.tbR57_1)
        Me.Panel1.Controls.Add(Me.tb56c)
        Me.Panel1.Controls.Add(Me.tb56b)
        Me.Panel1.Controls.Add(Me.tb56a)
        Me.Panel1.Controls.Add(Me.tbPrevStav3)
        Me.Panel1.Controls.Add(Me.tbPrevStav2)
        Me.Panel1.Controls.Add(Me.tbPrevStav1)
        Me.Panel1.Controls.Add(Me.tbR54_3)
        Me.Panel1.Controls.Add(Me.tbR54_2)
        Me.Panel1.Controls.Add(Me.tbR54_1)
        Me.Panel1.Controls.Add(Me.tbR60)
        Me.Panel1.Controls.Add(Me.tbR53)
        Me.Panel1.Controls.Add(Me.tbR48b)
        Me.Panel1.Controls.Add(Me.tbR48a)
        Me.Panel1.Controls.Add(Me.tbR23_4)
        Me.Panel1.Controls.Add(Me.tbR23_3)
        Me.Panel1.Controls.Add(Me.tbR23_2)
        Me.Panel1.Controls.Add(Me.tbR23_1)
        Me.Panel1.Controls.Add(Me.tbR26_4)
        Me.Panel1.Controls.Add(Me.tbR26_3)
        Me.Panel1.Controls.Add(Me.tbR26_2)
        Me.Panel1.Controls.Add(Me.tbR26_1)
        Me.Panel1.Controls.Add(Me.tbR25b_4)
        Me.Panel1.Controls.Add(Me.tbR25b_3)
        Me.Panel1.Controls.Add(Me.tbR25b_2)
        Me.Panel1.Controls.Add(Me.tbR25b_1)
        Me.Panel1.Controls.Add(Me.tbR25a_4)
        Me.Panel1.Controls.Add(Me.tbR25a_3)
        Me.Panel1.Controls.Add(Me.tbR21_4)
        Me.Panel1.Controls.Add(Me.tbR21_3)
        Me.Panel1.Controls.Add(Me.tbR21_2)
        Me.Panel1.Controls.Add(Me.tbR25a_2)
        Me.Panel1.Controls.Add(Me.tbR25a_1)
        Me.Panel1.Controls.Add(Me.tbR24_4)
        Me.Panel1.Controls.Add(Me.tbR24_3)
        Me.Panel1.Controls.Add(Me.tbR24_2)
        Me.Panel1.Controls.Add(Me.tbR24_1)
        Me.Panel1.Controls.Add(Me.tbR36)
        Me.Panel1.Controls.Add(Me.tbR33_2)
        Me.Panel1.Controls.Add(Me.tbR33_1)
        Me.Panel1.Controls.Add(Me.TextBox28)
        Me.Panel1.Controls.Add(Me.tbR13_2)
        Me.Panel1.Controls.Add(Me.tbR13_1)
        Me.Panel1.Controls.Add(Me.TextBox23)
        Me.Panel1.Controls.Add(Me.tbR47)
        Me.Panel1.Controls.Add(Me.tbPrevF)
        Me.Panel1.Controls.Add(Me.tbPrevU)
        Me.Panel1.Controls.Add(Me.tbSumaU)
        Me.Panel1.Controls.Add(Me.tbSumaF)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.tbA79b4)
        Me.Panel1.Controls.Add(Me.tbA79a4)
        Me.Panel1.Controls.Add(Me.tbR21_1)
        Me.Panel1.Controls.Add(Me.CheckBox6)
        Me.Panel1.Controls.Add(Me.tbR45b)
        Me.Panel1.Controls.Add(Me.tbR44Iznos)
        Me.Panel1.Controls.Add(Me.tbR41Suma)
        Me.Panel1.Controls.Add(Me.tbR32a)
        Me.Panel1.Controls.Add(Me.tbR31Sifra)
        Me.Panel1.Controls.Add(Me.tbR31naziv)
        Me.Panel1.Controls.Add(Me.tbR50)
        Me.Panel1.Controls.Add(Me.CheckBox7)
        Me.Panel1.Controls.Add(Me.CheckBox5)
        Me.Panel1.Controls.Add(Me.tbR15)
        Me.Panel1.Controls.Add(Me.tbR14Sifra)
        Me.Panel1.Controls.Add(Me.tbR14Naziv)
        Me.Panel1.Controls.Add(Me.tbR12Naziv)
        Me.Panel1.Controls.Add(Me.tbR12Sifra)
        Me.Panel1.Controls.Add(Me.cbR6)
        Me.Panel1.Controls.Add(Me.cbR5D)
        Me.Panel1.Controls.Add(Me.cbR5O)
        Me.Panel1.Controls.Add(Me.cbR5R)
        Me.Panel1.Controls.Add(Me.cbR4D)
        Me.Panel1.Controls.Add(Me.cbRID)
        Me.Panel1.Controls.Add(Me.CheckBox4)
        Me.Panel1.Controls.Add(Me.CheckBox3)
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.tbKolauVozu)
        Me.Panel1.Controls.Add(Me.rtbR34)
        Me.Panel1.Controls.Add(Me.rtbR27)
        Me.Panel1.Controls.Add(Me.rtb37)
        Me.Panel1.Controls.Add(Me.Button18)
        Me.Panel1.Controls.Add(Me.tbA79b3)
        Me.Panel1.Controls.Add(Me.tbA79a3)
        Me.Panel1.Controls.Add(Me.tbA79b2)
        Me.Panel1.Controls.Add(Me.tbA79a2)
        Me.Panel1.Controls.Add(Me.Button15)
        Me.Panel1.Controls.Add(Me.Button14)
        Me.Panel1.Controls.Add(Me.tbA79b1)
        Me.Panel1.Controls.Add(Me.tbA79a1)
        Me.Panel1.Controls.Add(Me.tbR49)
        Me.Panel1.Controls.Add(Me.btnUnosRobe)
        Me.Panel1.Controls.Add(Me.tbR35)
        Me.Panel1.Controls.Add(Me.tbR45a)
        Me.Panel1.Controls.Add(Me.tb20a)
        Me.Panel1.Controls.Add(Me.tb20d)
        Me.Panel1.Controls.Add(Me.tb20c)
        Me.Panel1.Controls.Add(Me.tb20b)
        Me.Panel1.Controls.Add(Me.cbR4K)
        Me.Panel1.Controls.Add(Me.tbR17)
        Me.Panel1.Controls.Add(Me.tbR30Naziv)
        Me.Panel1.Controls.Add(Me.tbR30Sifra)
        Me.Panel1.Controls.Add(Me.tbR11)
        Me.Panel1.Controls.Add(Me.tbControl)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Panel1.Location = New System.Drawing.Point(9, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(768, 704)
        Me.Panel1.TabIndex = 6
        '
        'gbDorKarta
        '
        Me.gbDorKarta.Controls.Add(Me.Label29)
        Me.gbDorKarta.Controls.Add(Me.tbDKIznos)
        Me.gbDorKarta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbDorKarta.Location = New System.Drawing.Point(630, 720)
        Me.gbDorKarta.Name = "gbDorKarta"
        Me.gbDorKarta.Size = New System.Drawing.Size(104, 48)
        Me.gbDorKarta.TabIndex = 496
        Me.gbDorKarta.TabStop = False
        Me.gbDorKarta.Text = "Doraèunska karta"
        Me.gbDorKarta.Visible = False
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(8, 10)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(32, 14)
        Me.Label29.TabIndex = 377
        Me.Label29.Text = "Iznos"
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.BackColor = System.Drawing.Color.Red
        Me.GroupBox7.Controls.Add(Me.TextBox6)
        Me.GroupBox7.Controls.Add(Me.Label31)
        Me.GroupBox7.Controls.Add(Me.TextBox5)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(100, 11012)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(104, 56)
        Me.GroupBox7.TabIndex = 495
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = " [ Dorac. karta ] "
        '
        'Label31
        '
        Me.Label31.Enabled = False
        Me.Label31.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label31.Location = New System.Drawing.Point(24, 16)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(80, 11)
        Me.Label31.TabIndex = 229
        Me.Label31.Text = "Iznos po dor. karti"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbPrev2
        '
        Me.tbPrev2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPrev2.Enabled = False
        Me.tbPrev2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrev2.Location = New System.Drawing.Point(208, 779)
        Me.tbPrev2.Name = "tbPrev2"
        Me.tbPrev2.Size = New System.Drawing.Size(59, 11)
        Me.tbPrev2.TabIndex = 493
        Me.tbPrev2.Text = "LP2"
        Me.tbPrev2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.tbPrev2.Visible = False
        '
        'tbPrev1
        '
        Me.tbPrev1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPrev1.Enabled = False
        Me.tbPrev1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrev1.Location = New System.Drawing.Point(133, 779)
        Me.tbPrev1.Name = "tbPrev1"
        Me.tbPrev1.Size = New System.Drawing.Size(59, 11)
        Me.tbPrev1.TabIndex = 492
        Me.tbPrev1.Text = "LP1"
        Me.tbPrev1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.tbPrev1.Visible = False
        '
        'tbStanicaLom
        '
        Me.tbStanicaLom.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbStanicaLom.Enabled = False
        Me.tbStanicaLom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaLom.Location = New System.Drawing.Point(519, 463)
        Me.tbStanicaLom.MaxLength = 5
        Me.tbStanicaLom.Name = "tbStanicaLom"
        Me.tbStanicaLom.Size = New System.Drawing.Size(72, 20)
        Me.tbStanicaLom.TabIndex = 490
        Me.tbStanicaLom.Text = ""
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.Label51.Enabled = False
        Me.Label51.Location = New System.Drawing.Point(424, 464)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(80, 16)
        Me.Label51.TabIndex = 489
        Me.Label51.Text = "Preko stanice"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label51.Visible = False
        '
        'cbZsPrevozniPut
        '
        Me.cbZsPrevozniPut.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.cbZsPrevozniPut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbZsPrevozniPut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbZsPrevozniPut.Items.AddRange(New Object() {"1 - Redovan", "2 - Vanredan", "3 - Lomljen redovan", "4 - Lomljen vanredan"})
        Me.cbZsPrevozniPut.Location = New System.Drawing.Point(424, 432)
        Me.cbZsPrevozniPut.Name = "cbZsPrevozniPut"
        Me.cbZsPrevozniPut.Size = New System.Drawing.Size(168, 21)
        Me.cbZsPrevozniPut.TabIndex = 488
        '
        'cbR5E
        '
        Me.cbR5E.BackColor = System.Drawing.Color.Transparent
        Me.cbR5E.Location = New System.Drawing.Point(568, 42)
        Me.cbR5E.Name = "cbR5E"
        Me.cbR5E.Size = New System.Drawing.Size(16, 17)
        Me.cbR5E.TabIndex = 483
        '
        'tbIBK_4
        '
        Me.tbIBK_4.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbIBK_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIBK_4.Location = New System.Drawing.Point(386, 290)
        Me.tbIBK_4.MaxLength = 12
        Me.tbIBK_4.Name = "tbIBK_4"
        Me.tbIBK_4.Size = New System.Drawing.Size(94, 18)
        Me.tbIBK_4.TabIndex = 395
        Me.tbIBK_4.Text = ""
        Me.tbIBK_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbIBK_3
        '
        Me.tbIBK_3.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbIBK_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIBK_3.Location = New System.Drawing.Point(386, 274)
        Me.tbIBK_3.MaxLength = 12
        Me.tbIBK_3.Name = "tbIBK_3"
        Me.tbIBK_3.Size = New System.Drawing.Size(94, 18)
        Me.tbIBK_3.TabIndex = 393
        Me.tbIBK_3.Text = ""
        Me.tbIBK_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbIBK_2
        '
        Me.tbIBK_2.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbIBK_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIBK_2.Location = New System.Drawing.Point(386, 258)
        Me.tbIBK_2.MaxLength = 12
        Me.tbIBK_2.Name = "tbIBK_2"
        Me.tbIBK_2.Size = New System.Drawing.Size(94, 18)
        Me.tbIBK_2.TabIndex = 391
        Me.tbIBK_2.Text = ""
        Me.tbIBK_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR43f
        '
        Me.tbR43f.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR43f.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR43f.Location = New System.Drawing.Point(707, 583)
        Me.tbR43f.MaxLength = 2
        Me.tbR43f.Name = "tbR43f"
        Me.tbR43f.Size = New System.Drawing.Size(24, 18)
        Me.tbR43f.TabIndex = 482
        Me.tbR43f.Text = ""
        '
        'tbR43e
        '
        Me.tbR43e.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR43e.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR43e.Location = New System.Drawing.Point(707, 568)
        Me.tbR43e.MaxLength = 2
        Me.tbR43e.Name = "tbR43e"
        Me.tbR43e.Size = New System.Drawing.Size(24, 18)
        Me.tbR43e.TabIndex = 481
        Me.tbR43e.Text = ""
        '
        'tbR43d
        '
        Me.tbR43d.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR43d.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR43d.Location = New System.Drawing.Point(707, 552)
        Me.tbR43d.MaxLength = 2
        Me.tbR43d.Name = "tbR43d"
        Me.tbR43d.Size = New System.Drawing.Size(24, 18)
        Me.tbR43d.TabIndex = 480
        Me.tbR43d.Text = ""
        '
        'tbR43c
        '
        Me.tbR43c.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR43c.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR43c.Location = New System.Drawing.Point(707, 538)
        Me.tbR43c.MaxLength = 2
        Me.tbR43c.Name = "tbR43c"
        Me.tbR43c.Size = New System.Drawing.Size(24, 18)
        Me.tbR43c.TabIndex = 479
        Me.tbR43c.Text = ""
        '
        'tbR43b
        '
        Me.tbR43b.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR43b.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR43b.Location = New System.Drawing.Point(707, 522)
        Me.tbR43b.MaxLength = 2
        Me.tbR43b.Name = "tbR43b"
        Me.tbR43b.Size = New System.Drawing.Size(24, 18)
        Me.tbR43b.TabIndex = 478
        Me.tbR43b.Text = ""
        '
        'tbR42f
        '
        Me.tbR42f.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR42f.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR42f.Location = New System.Drawing.Point(636, 583)
        Me.tbR42f.MaxLength = 6
        Me.tbR42f.Name = "tbR42f"
        Me.tbR42f.Size = New System.Drawing.Size(56, 18)
        Me.tbR42f.TabIndex = 477
        Me.tbR42f.Text = ""
        Me.tbR42f.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR42e
        '
        Me.tbR42e.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR42e.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR42e.Location = New System.Drawing.Point(636, 568)
        Me.tbR42e.MaxLength = 6
        Me.tbR42e.Name = "tbR42e"
        Me.tbR42e.Size = New System.Drawing.Size(56, 18)
        Me.tbR42e.TabIndex = 476
        Me.tbR42e.Text = ""
        Me.tbR42e.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR42d
        '
        Me.tbR42d.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR42d.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR42d.Location = New System.Drawing.Point(636, 552)
        Me.tbR42d.MaxLength = 6
        Me.tbR42d.Name = "tbR42d"
        Me.tbR42d.Size = New System.Drawing.Size(56, 18)
        Me.tbR42d.TabIndex = 475
        Me.tbR42d.Text = ""
        Me.tbR42d.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR42c
        '
        Me.tbR42c.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR42c.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR42c.Location = New System.Drawing.Point(636, 536)
        Me.tbR42c.MaxLength = 6
        Me.tbR42c.Name = "tbR42c"
        Me.tbR42c.Size = New System.Drawing.Size(56, 18)
        Me.tbR42c.TabIndex = 474
        Me.tbR42c.Text = ""
        Me.tbR42c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR42b
        '
        Me.tbR42b.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR42b.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR42b.Location = New System.Drawing.Point(636, 522)
        Me.tbR42b.MaxLength = 6
        Me.tbR42b.Name = "tbR42b"
        Me.tbR42b.Size = New System.Drawing.Size(56, 18)
        Me.tbR42b.TabIndex = 473
        Me.tbR42b.Text = ""
        Me.tbR42b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR42a
        '
        Me.tbR42a.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbR42a.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR42a.Location = New System.Drawing.Point(636, 506)
        Me.tbR42a.MaxLength = 6
        Me.tbR42a.Name = "tbR42a"
        Me.tbR42a.Size = New System.Drawing.Size(56, 18)
        Me.tbR42a.TabIndex = 471
        Me.tbR42a.Text = ""
        Me.tbR42a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPdvIznosU
        '
        Me.tbPdvIznosU.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPdvIznosU.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPdvIznosU.Location = New System.Drawing.Point(636, 857)
        Me.tbPdvIznosU.MaxLength = 18
        Me.tbPdvIznosU.Name = "tbPdvIznosU"
        Me.tbPdvIznosU.Size = New System.Drawing.Size(96, 22)
        Me.tbPdvIznosU.TabIndex = 470
        Me.tbPdvIznosU.Text = "0"
        Me.tbPdvIznosU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPdvIznosF
        '
        Me.tbPdvIznosF.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPdvIznosF.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPdvIznosF.Location = New System.Drawing.Point(8, 857)
        Me.tbPdvIznosF.MaxLength = 18
        Me.tbPdvIznosF.Name = "tbPdvIznosF"
        Me.tbPdvIznosF.Size = New System.Drawing.Size(96, 22)
        Me.tbPdvIznosF.TabIndex = 469
        Me.tbPdvIznosF.Text = "0"
        Me.tbPdvIznosF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb63b
        '
        Me.tb63b.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tb63b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb63b.Location = New System.Drawing.Point(244, 880)
        Me.tb63b.MaxLength = 6
        Me.tb63b.Name = "tb63b"
        Me.tb63b.Size = New System.Drawing.Size(41, 20)
        Me.tb63b.TabIndex = 468
        Me.tb63b.Text = ""
        Me.tb63b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPDV
        '
        Me.tbPDV.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPDV.Location = New System.Drawing.Point(288, 857)
        Me.tbPDV.MaxLength = 40
        Me.tbPDV.Name = "tbPDV"
        Me.tbPDV.Size = New System.Drawing.Size(243, 20)
        Me.tbPDV.TabIndex = 467
        Me.tbPDV.Text = ""
        '
        'tbPDVU
        '
        Me.tbPDVU.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPDVU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPDVU.Location = New System.Drawing.Point(244, 857)
        Me.tbPDVU.MaxLength = 6
        Me.tbPDVU.Name = "tbPDVU"
        Me.tbPDVU.Size = New System.Drawing.Size(41, 20)
        Me.tbPDVU.TabIndex = 466
        Me.tbPDVU.Text = ""
        Me.tbPDVU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPDVF
        '
        Me.tbPDVF.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.tbPDVF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPDVF.Location = New System.Drawing.Point(204, 857)
        Me.tbPDVF.MaxLength = 2
        Me.tbPDVF.Name = "tbPDVF"
        Me.tbPDVF.Size = New System.Drawing.Size(40, 20)
        Me.tbPDVF.TabIndex = 465
        Me.tbPDVF.Text = ""
        Me.tbPDVF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(220, Byte), CType(255, Byte))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(328, 984)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 37)
        Me.Label4.TabIndex = 464
        Me.Label4.Text = "1"
        '
        'rtbR16
        '
        Me.rtbR16.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.rtbR16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtbR16.Location = New System.Drawing.Point(56, 165)
        Me.rtbR16.Name = "rtbR16"
        Me.rtbR16.ReadOnly = True
        Me.rtbR16.Size = New System.Drawing.Size(192, 80)
        Me.rtbR16.TabIndex = 457
        Me.rtbR16.Text = ""
        '
        'rtbR10
        '
        Me.rtbR10.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.rtbR10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtbR10.Location = New System.Drawing.Point(56, 72)
        Me.rtbR10.Name = "rtbR10"
        Me.rtbR10.ReadOnly = True
        Me.rtbR10.Size = New System.Drawing.Size(192, 80)
        Me.rtbR10.TabIndex = 0
        Me.rtbR10.Text = ""
        '
        'tbR21_4
        '
        Me.tbR21_4.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR21_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR21_4.Location = New System.Drawing.Point(353, 289)
        Me.tbR21_4.MaxLength = 12
        Me.tbR21_4.Name = "tbR21_4"
        Me.tbR21_4.Size = New System.Drawing.Size(32, 20)
        Me.tbR21_4.TabIndex = 396
        Me.tbR21_4.Text = ""
        Me.tbR21_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR21_3
        '
        Me.tbR21_3.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR21_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR21_3.Location = New System.Drawing.Point(353, 274)
        Me.tbR21_3.MaxLength = 12
        Me.tbR21_3.Name = "tbR21_3"
        Me.tbR21_3.Size = New System.Drawing.Size(32, 20)
        Me.tbR21_3.TabIndex = 394
        Me.tbR21_3.Text = ""
        Me.tbR21_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR21_2
        '
        Me.tbR21_2.BackColor = System.Drawing.Color.FromArgb(CType(235, Byte), CType(235, Byte), CType(235, Byte))
        Me.tbR21_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR21_2.Location = New System.Drawing.Point(353, 258)
        Me.tbR21_2.MaxLength = 12
        Me.tbR21_2.Name = "tbR21_2"
        Me.tbR21_2.Size = New System.Drawing.Size(32, 20)
        Me.tbR21_2.TabIndex = 392
        Me.tbR21_2.Text = ""
        Me.tbR21_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox8.Controls.Add(Me.cbPDV)
        Me.GroupBox8.Location = New System.Drawing.Point(780, -4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(220, 36)
        Me.GroupBox8.TabIndex = 449
        Me.GroupBox8.TabStop = False
        '
        'cbPDV
        '
        Me.cbPDV.Checked = True
        Me.cbPDV.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPDV.Location = New System.Drawing.Point(16, 9)
        Me.cbPDV.Name = "cbPDV"
        Me.cbPDV.Size = New System.Drawing.Size(176, 24)
        Me.cbPDV.TabIndex = 0
        Me.cbPDV.Text = "Posiljka podleze PDV-u"
        Me.cbPDV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Silver
        Me.GroupBox2.Controls.Add(Me.rbTLPreview)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbStrana5)
        Me.GroupBox2.Controls.Add(Me.cbStrana4)
        Me.GroupBox2.Controls.Add(Me.cbStrana3)
        Me.GroupBox2.Controls.Add(Me.cbStrana2)
        Me.GroupBox2.Controls.Add(Me.cbStrana1)
        Me.GroupBox2.Controls.Add(Me.rbTLPrint)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.cbPoledjina5)
        Me.GroupBox2.Controls.Add(Me.cbPoledjina4)
        Me.GroupBox2.Controls.Add(Me.cbPoledjina2)
        Me.GroupBox2.Controls.Add(Me.cbPoledjina1)
        Me.GroupBox2.Controls.Add(Me.cbPoledjina3)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(984, 544)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(16, 16)
        Me.GroupBox2.TabIndex = 452
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Stampa tovarnog lista "
        Me.GroupBox2.Visible = False
        '
        'rbTLPreview
        '
        Me.rbTLPreview.Checked = True
        Me.rbTLPreview.Location = New System.Drawing.Point(92, 83)
        Me.rbTLPreview.Name = "rbTLPreview"
        Me.rbTLPreview.Size = New System.Drawing.Size(124, 24)
        Me.rbTLPreview.TabIndex = 23
        Me.rbTLPreview.TabStop = True
        Me.rbTLPreview.Text = "Pregled pre stampe"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(188, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 16)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "5"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(164, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 16)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "4"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(140, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "3"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(116, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "2"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(92, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "1"
        '
        'cbStrana5
        '
        Me.cbStrana5.Checked = True
        Me.cbStrana5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbStrana5.Location = New System.Drawing.Point(188, 25)
        Me.cbStrana5.Name = "cbStrana5"
        Me.cbStrana5.Size = New System.Drawing.Size(16, 24)
        Me.cbStrana5.TabIndex = 11
        '
        'cbStrana4
        '
        Me.cbStrana4.Checked = True
        Me.cbStrana4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbStrana4.Location = New System.Drawing.Point(164, 25)
        Me.cbStrana4.Name = "cbStrana4"
        Me.cbStrana4.Size = New System.Drawing.Size(16, 24)
        Me.cbStrana4.TabIndex = 9
        '
        'cbStrana3
        '
        Me.cbStrana3.Checked = True
        Me.cbStrana3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbStrana3.Location = New System.Drawing.Point(140, 25)
        Me.cbStrana3.Name = "cbStrana3"
        Me.cbStrana3.Size = New System.Drawing.Size(16, 24)
        Me.cbStrana3.TabIndex = 7
        '
        'cbStrana2
        '
        Me.cbStrana2.Checked = True
        Me.cbStrana2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbStrana2.Location = New System.Drawing.Point(116, 25)
        Me.cbStrana2.Name = "cbStrana2"
        Me.cbStrana2.Size = New System.Drawing.Size(16, 24)
        Me.cbStrana2.TabIndex = 5
        '
        'cbStrana1
        '
        Me.cbStrana1.Checked = True
        Me.cbStrana1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbStrana1.Enabled = False
        Me.cbStrana1.Location = New System.Drawing.Point(92, 25)
        Me.cbStrana1.Name = "cbStrana1"
        Me.cbStrana1.Size = New System.Drawing.Size(16, 24)
        Me.cbStrana1.TabIndex = 2
        '
        'rbTLPrint
        '
        Me.rbTLPrint.Location = New System.Drawing.Point(92, 66)
        Me.rbTLPrint.Name = "rbTLPrint"
        Me.rbTLPrint.Size = New System.Drawing.Size(112, 24)
        Me.rbTLPrint.TabIndex = 22
        Me.rbTLPrint.Text = "Direktna stampa"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(16, 75)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(54, 16)
        Me.Label23.TabIndex = 21
        Me.Label23.Text = "Izbor"
        '
        'cbPoledjina5
        '
        Me.cbPoledjina5.Location = New System.Drawing.Point(188, 43)
        Me.cbPoledjina5.Name = "cbPoledjina5"
        Me.cbPoledjina5.Size = New System.Drawing.Size(16, 24)
        Me.cbPoledjina5.TabIndex = 18
        '
        'cbPoledjina4
        '
        Me.cbPoledjina4.Location = New System.Drawing.Point(164, 43)
        Me.cbPoledjina4.Name = "cbPoledjina4"
        Me.cbPoledjina4.Size = New System.Drawing.Size(16, 24)
        Me.cbPoledjina4.TabIndex = 17
        '
        'cbPoledjina2
        '
        Me.cbPoledjina2.Location = New System.Drawing.Point(116, 43)
        Me.cbPoledjina2.Name = "cbPoledjina2"
        Me.cbPoledjina2.Size = New System.Drawing.Size(16, 24)
        Me.cbPoledjina2.TabIndex = 16
        '
        'cbPoledjina1
        '
        Me.cbPoledjina1.Location = New System.Drawing.Point(92, 43)
        Me.cbPoledjina1.Name = "cbPoledjina1"
        Me.cbPoledjina1.Size = New System.Drawing.Size(16, 24)
        Me.cbPoledjina1.TabIndex = 15
        '
        'cbPoledjina3
        '
        Me.cbPoledjina3.Checked = True
        Me.cbPoledjina3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPoledjina3.Location = New System.Drawing.Point(140, 43)
        Me.cbPoledjina3.Name = "cbPoledjina3"
        Me.cbPoledjina3.Size = New System.Drawing.Size(16, 24)
        Me.cbPoledjina3.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 16)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Poledjina"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Strana"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Silver
        Me.GroupBox3.Controls.Add(Me.rbDLPreview)
        Me.GroupBox3.Controls.Add(Me.rbDLPrint)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Location = New System.Drawing.Point(976, 568)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(16, 16)
        Me.GroupBox3.TabIndex = 453
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Stampa dodatnog lista "
        Me.GroupBox3.Visible = False
        '
        'rbDLPreview
        '
        Me.rbDLPreview.Checked = True
        Me.rbDLPreview.Location = New System.Drawing.Point(92, 29)
        Me.rbDLPreview.Name = "rbDLPreview"
        Me.rbDLPreview.Size = New System.Drawing.Size(124, 24)
        Me.rbDLPreview.TabIndex = 23
        Me.rbDLPreview.TabStop = True
        Me.rbDLPreview.Text = "Pregled pre stampe"
        '
        'rbDLPrint
        '
        Me.rbDLPrint.Location = New System.Drawing.Point(92, 12)
        Me.rbDLPrint.Name = "rbDLPrint"
        Me.rbDLPrint.Size = New System.Drawing.Size(112, 24)
        Me.rbDLPrint.TabIndex = 22
        Me.rbDLPrint.Text = "Direktna stampa"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(16, 29)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(54, 16)
        Me.Label27.TabIndex = 21
        Me.Label27.Text = "Izbor"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.GroupBox6.Controls.Add(Me.lblUpucenoRazlika)
        Me.GroupBox6.Controls.Add(Me.lblFrankoRazlika)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.FR_Stanica)
        Me.GroupBox6.Controls.Add(Me.FR_Razlika)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.UP_Stanica)
        Me.GroupBox6.Controls.Add(Me.UP_Razlika)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(780, 424)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(220, 112)
        Me.GroupBox6.TabIndex = 454
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = " [ NAPLACENO NA BLAGAJNI ] "
        '
        'lblUpucenoRazlika
        '
        Me.lblUpucenoRazlika.BackColor = System.Drawing.Color.White
        Me.lblUpucenoRazlika.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUpucenoRazlika.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblUpucenoRazlika.Location = New System.Drawing.Point(110, 80)
        Me.lblUpucenoRazlika.Name = "lblUpucenoRazlika"
        Me.lblUpucenoRazlika.Size = New System.Drawing.Size(104, 19)
        Me.lblUpucenoRazlika.TabIndex = 4902
        Me.lblUpucenoRazlika.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblFrankoRazlika
        '
        Me.lblFrankoRazlika.BackColor = System.Drawing.Color.White
        Me.lblFrankoRazlika.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFrankoRazlika.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblFrankoRazlika.Location = New System.Drawing.Point(4, 80)
        Me.lblFrankoRazlika.Name = "lblFrankoRazlika"
        Me.lblFrankoRazlika.Size = New System.Drawing.Size(104, 19)
        Me.lblFrankoRazlika.TabIndex = 4901
        Me.lblFrankoRazlika.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label22
        '
        Me.Label22.Enabled = False
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label22.Location = New System.Drawing.Point(124, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 19)
        Me.Label22.TabIndex = 492
        Me.Label22.Text = "U p u c e n o"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label19.Location = New System.Drawing.Point(80, 61)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 16)
        Me.Label19.TabIndex = 491
        Me.Label19.Text = "R a z l i k a"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label24
        '
        Me.Label24.Enabled = False
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label24.Location = New System.Drawing.Point(10, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 19)
        Me.Label24.TabIndex = 227
        Me.Label24.Text = "F r a n k o"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label25
        '
        Me.Label25.Enabled = False
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(792, 560)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 19)
        Me.Label25.TabIndex = 458
        Me.Label25.Text = "Kurs"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label25.Visible = False
        '
        'btnSTV
        '
        Me.btnSTV.Location = New System.Drawing.Point(872, 656)
        Me.btnSTV.Name = "btnSTV"
        Me.btnSTV.Size = New System.Drawing.Size(40, 23)
        Me.btnSTV.TabIndex = 493
        Me.btnSTV.Text = "STV"
        Me.btnSTV.Visible = False
        '
        'lblOtpKurs
        '
        Me.lblOtpKurs.BackColor = System.Drawing.Color.White
        Me.lblOtpKurs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOtpKurs.Enabled = False
        Me.lblOtpKurs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblOtpKurs.ForeColor = System.Drawing.Color.Black
        Me.lblOtpKurs.Location = New System.Drawing.Point(896, 552)
        Me.lblOtpKurs.Name = "lblOtpKurs"
        Me.lblOtpKurs.Size = New System.Drawing.Size(72, 16)
        Me.lblOtpKurs.TabIndex = 494
        Me.lblOtpKurs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblOtpKurs.Visible = False
        '
        'lblPrKurs
        '
        Me.lblPrKurs.BackColor = System.Drawing.Color.White
        Me.lblPrKurs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrKurs.Enabled = False
        Me.lblPrKurs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblPrKurs.ForeColor = System.Drawing.Color.Black
        Me.lblPrKurs.Location = New System.Drawing.Point(896, 576)
        Me.lblPrKurs.Name = "lblPrKurs"
        Me.lblPrKurs.Size = New System.Drawing.Size(72, 16)
        Me.lblPrKurs.TabIndex = 495
        Me.lblPrKurs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblPrKurs.Visible = False
        '
        'Label26
        '
        Me.Label26.Enabled = False
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(832, 551)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 19)
        Me.Label26.TabIndex = 496
        Me.Label26.Text = "dat. otp."
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label26.Visible = False
        '
        'Label28
        '
        Me.Label28.Enabled = False
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(833, 573)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(48, 19)
        Me.Label28.TabIndex = 497
        Me.Label28.Text = "dat. pr."
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label28.Visible = False
        '
        'FormUTL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(886, 383)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.lblPrKurs)
        Me.Controls.Add(Me.lblOtpKurs)
        Me.Controls.Add(Me.btnSTV)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgError)
        Me.Controls.Add(Me.btnKalk)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnUpis)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbSaobracaj)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUTL"
        Me.Text = "UTL"
        Me.gbSaobracaj.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gbDorKarta.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim err As DataSet
    Dim NizUic(57, 2) As String
    Dim mUgovorZaUporedjenje As String
    ''Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    ''    FormatErrGrid()
    ''    Me.tbKolauVozu.Text = "1"

    ''    Me.tbsBrojVoza.Text = msBrojVoza
    ''    Me.tbsSatVoza.Text = mSatVoza
    ''    Me.ComboBox1.Text = mTarifa
    ''    If mBrojUg = "000000" Then
    ''        Me.tbUgovor.Clear()
    ''    Else
    ''        Me.tbUgovor.Text = mBrojUg
    ''    End If

    ''    tbsSatVoza.Text = Today.Now.Hour.ToString
    ''    If Len(tbsSatVoza.Text) = 1 Then
    ''        Me.tbsSatVoza.Text = "0" & Me.tbsSatVoza.Text
    ''    End If

    ''    If IzborSaobracaja = "2" Then
    ''        Me.RadioButton2.Checked = True
    ''    ElseIf IzborSaobracaja = "3" Then
    ''        Me.RadioButton3.Checked = True
    ''    ElseIf IzborSaobracaja = "4" Then
    ''        Me.RadioButton1.Checked = True
    ''    End If
    ''    If Me.rbKolska.Checked = True Then
    ''        bVrstaPosiljke = "K"
    ''    Else
    ''        bVrstaPosiljke = "D"
    ''    End If

    ''    Init_Tarifa()

    ''    ' !!! ===================================== da li se preuzima eCIM ===========================================

    ''    If eRazmena = "Ne" Then                     ' Obièan unos
    ''        If RecordAction = "I" Then 'Insert
    ''            Init_Forma()

    ''        ElseIf RecordAction = "N" Then ' Izmena
    ''            'popuniti polja na formi vrednostima iz baze
    ''            Dim drKola, drNhm As DataRow
    ''            For Each drKola In dtKola.Rows
    ''                mIBK = drKola.Item("IndBrojKola")
    ''            Next
    ''            For Each drNhm In dtNhm.Rows
    ''                mNHM = drNhm.Item("NHM")
    ''            Next
    ''            mSumaRobe = dtNhm.Compute("SUM(Masa)", String.Empty)

    ''            Me.tbIBK.Text = mIBK
    ''            Me.tb24.Text = mNHM
    ''            Me.tb25.Text = mSumaRobe.ToString

    ''            If IzborSaobracaja = "4" Then
    ''                If TipTranzita = "ulaz" Then
    ''                    cbSmer1.Text = mUlPrelaz
    ''                    cbSmer2.Text = mIzPrelaz
    ''                    tbUlaznaNalepnica.Text = mUlEtiketa
    ''                    tbIzlaznaNalepnica.Text = mIzEtiketa
    ''                Else
    ''                    cbSmer1.Text = mIzPrelaz
    ''                    cbSmer2.Text = mUlPrelaz
    ''                    tbUlaznaNalepnica.Text = mIzEtiketa
    ''                    tbIzlaznaNalepnica.Text = mUlEtiketa
    ''                End If
    ''            ElseIf IzborSaobracaja = "2" Then

    ''            ElseIf IzborSaobracaja = "3" Then

    ''            End If

    ''            Me.tbUpravaOtp.Text = mOtpUprava
    ''            Me.tbStanicaOtp.Text = mOtpStanica
    ''            Me.tbBrojOtp.Text = mOtpBroj
    ''            Me.DatumOtp.Value = mOtpDatum
    ''            Me.tbUpravaPr.Text = mPrUprava
    ''            Me.tbStanicaPr.Text = mPrStanica

    ''            PostaviPrelaz(mUlPrelaz, mIzPrelaz)

    ''            Me.cbSmer1.Text = mStanica1
    ''            Me.cbSmer2.Text = mStanica2

    ''            Me.tbUlaznaNalepnica.Text = mUlEtiketa
    ''            Me.tbIzlaznaNalepnica.Text = mIzEtiketa

    ''            '-- podaci o korisniku
    ''            If mTarifa = "00" Then 'ugovor
    ''                Dim mRetVal As String
    ''                Dim ug_mNazivKomitenta As String
    ''                Dim ug_mAdresaKomitenta As String
    ''                Dim ug_mGradKomitenta As String
    ''                Dim ug_mZemljaKomitenta As String
    ''                Dim ug_mPrimalac As String
    ''                Dim ug_mVrstaObracuna As String
    ''                tbUgovor.Text = mBrojUg

    ''                NadjiUgovor(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, ug_mAdresaKomitenta, ug_mGradKomitenta, ug_mZemljaKomitenta, mRetVal)

    ''                If mRetVal = "" Then
    ''                    mPrimalac = ug_mPrimalac
    ''                    mSifraKorisnika = ug_mPrimalac
    ''                    mVrstaObracuna = ug_mVrstaObracuna

    ''                    Me.tb1a.Text = ug_mNazivKomitenta
    ''                    Me.tb1b.Text = ug_mAdresaKomitenta
    ''                    Me.tb1b1.Text = ug_mGradKomitenta
    ''                    Me.tb1b2.Text = ug_mZemljaKomitenta
    ''                    Me.tb2.Text = ug_mPrimalac
    ''                    Me.tb14b.Text = tbUgovor.Text
    ''                    Me.tbA75.Text = tbUgovor.Text

    ''                    '---------
    ''                    If mTarifa = "00" Then
    ''                        ComboBox2.Items.Clear()
    ''                        If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Then
    ''                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
    ''                            ComboBox2.SelectedIndex = 0
    ''                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "01" Then
    ''                            ComboBox2.Items.Add("3. Kompletni vozovi")
    ''                            ComboBox2.SelectedText = "3. Kompletni vozovi"
    ''                            ComboBox2.SelectedIndex = 0
    ''                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "02" Then
    ''                            ComboBox2.Items.Add("2. Grupa kola")
    ''                            ComboBox2.SelectedText = "2. Grupa kola"
    ''                            ComboBox2.SelectedIndex = 0
    ''                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
    ''                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
    ''                            ComboBox2.SelectedIndex = 0
    ''                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "67" Then
    ''                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                            ComboBox2.Items.Add("3. Kompletni vozovi")
    ''                            ComboBox2.SelectedIndex = 1
    ''                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Then
    ''                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
    ''                            ComboBox2.SelectedIndex = 0
    ''                        Else
    ''                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                            ComboBox2.Items.Add("2. Grupa kola")
    ''                            ComboBox2.Items.Add("3. Kompletni vozovi")
    ''                            ComboBox2.SelectedIndex = 0
    ''                        End If

    ''                        'za Intercontainer
    ''                        If mSifraKorisnika = 43 Then
    ''                            ComboBox2.Items.Add("3. Kompletni vozovi")
    ''                            ComboBox2.SelectedText = "3. Kompletni vozovi"
    ''                            ComboBox2.SelectedIndex = 0
    ''                        ElseIf mSifraKorisnika = 18 Then
    ''                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
    ''                            ComboBox2.SelectedIndex = 0
    ''                        End If
    ''                    End If
    ''                    '---------
    ''                End If
    ''                Me.ComboBox1.SelectedIndex = 0
    ''            Else
    ''                Me.ComboBox1.SelectedIndex = 1
    ''            End If
    ''            '-- end podaci o korisniku
    ''        End If
    ''    Else                                        ' preuzimanje eCIM.xml

    ''        ''eInit_NewCim89()
    ''        eInit_Forma()

    ''        DownloadValues()

    ''        Dim drKola, drNhm As DataRow
    ''        For Each drKola In dtKola.Rows
    ''            mIBK = drKola.Item("IndBrojKola")
    ''        Next
    ''        For Each drNhm In dtNhm.Rows
    ''            mNHM = drNhm.Item("NHM")
    ''        Next
    ''        mSumaRobe = dtNhm.Compute("SUM(Masa)", String.Empty)
    ''        mSumaTara = dtKola.Compute("SUM(Tara)", String.Empty)
    ''        mSumaBruto = mSumaRobe + mSumaTara

    ''        Me.tbA70a1.Text = "72"
    ''        Me.tbA70a2.Text = "72"

    ''        If IzborSaobracaja = "2" Then
    ''            Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
    ''            Me.tbA70b2.Text = Microsoft.VisualBasic.Right(Me.tbStanicaPr.Text, 5)
    ''        ElseIf IzborSaobracaja = "4" Then
    ''            Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
    ''            Me.tbA70b2.Text = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
    ''        End If


    ''        Me.tbIBK.Text = mIBK
    ''        Me.tb24.Text = mNHM
    ''        Me.tbA72d.Text = mNHM
    ''        Me.tb25.Text = mSumaRobe.ToString
    ''        Me.lblTaraValue.Text = mSumaTara.ToString
    ''        Me.lblBrutoValue.Text = mSumaBruto.ToString

    ''        If IzborSaobracaja = "4" Then
    ''            '''''''''''''''''''''tbUlaznaNalepnica.Text = mUlEtiketa
    ''            cbSmer1.Enabled = True
    ''        ElseIf IzborSaobracaja = "2" Then
    ''            cbSmer2.SelectedIndex = -1
    ''            cbSmer2.Enabled = False
    ''        End If

    ''    End If
    ''    ' !!! ===================================== end da li se preuzima eCIM ===========================================





    ''End Sub

    ''Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
    ''    If dgError.Visible = True Then
    ''        dgError.Visible = False
    ''    Else
    ''        dgError.Visible = True
    ''        dgError.Left = 780
    ''        dgError.Top = 1
    ''        dgError.Width = 245
    ''        dgError.Height = 600
    ''        dgError.CaptionText = "Kontrola podataka"

    ''        Dim errText1, errText2, errText3, errText4, errText5, errText6, errText7, errText8 As String
    ''        Dim errText9, errText10, errText11, errText12, errText13, errText14, errText15 As String
    ''        dtError.Clear()

    ''        ' ----------- kontrola 
    ''        If eCimDa = "D" Then
    ''            If IzborSaobracaja = "3" Then
    ''                If Me.tb4a.Text = Nothing Then
    ''                    errText14 = "Primalac"
    ''                    dtError.NewRow()
    ''                    dtError.Rows.Add(New Object() {errText14})
    ''                End If
    ''                If Me.tb1a.Text = Nothing Then
    ''                    errText14 = "Posiljalac"
    ''                    dtError.NewRow()
    ''                    dtError.Rows.Add(New Object() {errText14})
    ''                End If
    ''            End If
    ''        End If

    ''        If Me.tbA76.Text = Nothing Then 'Or CType(tbKm1.Text, Integer) = 0 Then
    ''            errText5 = "Tarifski kilometri"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText5})
    ''        End If
    ''        If Me.tbUpravaOtp.Text = Nothing Then
    ''            errText6 = "Otpravna uprava - operater"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText6})
    ''        ElseIf Len(Me.tbUpravaOtp.Text) > 0 And Len(Me.tbUpravaOtp.Text) < 4 Then
    ''            errText6 = "Otpravna uprava - operater"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText6})
    ''        End If
    ''        If Me.tbStanicaOtp.Text = Nothing Then
    ''            errText7 = "Otpravna stanica"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText7})
    ''        ElseIf Len(Me.tbStanicaOtp.Text) > 0 And Len(Me.tbStanicaOtp.Text) < 7 Then
    ''            errText7 = "Otpravna stanica"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText7})
    ''        End If
    ''        If Me.tbBrojOtp.Text = Nothing Then
    ''            errText8 = "Broj otpravljanja"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText8})
    ''        ElseIf CType(Me.tbBrojOtp.Text, Int32) = 0 Then
    ''            errText8 = "Broj otpravljanja"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText8})
    ''        End If
    ''        If Me.tbUpravaPr.Text = Nothing Then
    ''            errText9 = "Uputna uprava - operater"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText9})
    ''        ElseIf Len(Me.tbUpravaPr.Text) > 0 And Len(Me.tbUpravaPr.Text) < 4 Then
    ''            errText9 = "Uputna uprava - operater"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText9})
    ''        End If
    ''        If Me.tbStanicaPr.Text = Nothing Then
    ''            errText10 = "Uputna stanica"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText10})
    ''        ElseIf Len(Me.tbStanicaPr.Text) > 0 And Len(Me.tbStanicaPr.Text) < 7 Then
    ''            errText10 = "Uputna stanica"
    ''            dtError.NewRow()
    ''            dtError.Rows.Add(New Object() {errText10})
    ''        End If
    ''        If bVrstaPosiljke = "K" Then
    ''            If dtKola.Rows.Count = 0 Then
    ''                errText11 = "Unos robe"
    ''                dtError.NewRow()
    ''                dtError.Rows.Add(New Object() {errText11})
    ''            End If
    ''        End If
    ''        If Me.tbCarinjenje.Text = Nothing Then
    ''            If IzborSaobracaja = "2" Then
    ''                If Microsoft.VisualBasic.Mid(tb24.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tb24.Text, 1, 4) = "9922" Then

    ''                Else
    ''                    errText12 = "Odredisna carinarnica"
    ''                    dtError.NewRow()
    ''                    dtError.Rows.Add(New Object() {errText12})
    ''                End If
    ''            ElseIf IzborSaobracaja = "4" Then
    ''                errText12 = "Odredisna carinarnica"
    ''                dtError.NewRow()
    ''                dtError.Rows.Add(New Object() {errText12})
    ''            ElseIf IzborSaobracaja = "3" Then

    ''            End If
    ''        End If

    ''        If IzborSaobracaja = 3 And eCimDa = "D" Then
    ''            If Me.tb16c.Text = Nothing Then
    ''                errText13 = "Preuzimanje na prevoz"
    ''                dtError.NewRow()
    ''                dtError.Rows.Add(New Object() {errText13})
    ''            End If
    ''        End If

    ''        If dtError.Rows.Count = 0 Then
    ''            dgError.Visible = False
    ''            ErrKontrola = "OK"
    ''        Else
    ''            dgError.Visible = True
    ''            ErrKontrola = "NO"
    ''        End If
    ''    End If

    ''End Sub
    ''Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Dim GridNaknade As New naknade
    ''    GridNaknade.Show()
    ''End Sub

    ''Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
    ''    mTarifa = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)
    ''    If mTarifa = "00" Then 'Ugovor
    ''        ComboBox2.Text = ""
    ''        Button10.Visible = True
    ''        tbUgovor.Enabled = True
    ''    Else
    ''        tbUgovor.Text = " "
    ''        Button10.Visible = False
    ''        tbUgovor.Enabled = False
    ''        ComboBox2.Enabled = True
    ''        ComboBox2.Focus()
    ''    End If
    ''End Sub

    ''Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
    ''    mTarifa = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)
    ''    If mTarifa = "00" Then
    ''        tb14a.Text = "1"
    ''    Else
    ''        tb14a.Text = "2"
    ''        Me.tbA75.Text = "0000" & mTarifa
    ''        Me.tb14b.Text = Me.tbA75.Text
    ''    End If

    ''    If ComboBox1.Text = Nothing Then
    ''        ''ErrorProvider1.SetError(ComboBox1, "Obavezan izbor tarife!")
    ''        ComboBox1.Focus()
    ''    Else
    ''        ''ErrorProvider1.SetError(ComboBox1, "")
    ''        If IzborSaobracaja = "2" Then
    ''            Me.Text = ":: CIM - U V O Z ::"
    ''        ElseIf IzborSaobracaja = "3" Then
    ''            Me.Text = ":: CIM - I Z V O Z ::"
    ''        ElseIf IzborSaobracaja = "4" Then
    ''            Me.Text = ":: CIM - T R A N Z I T ::"
    ''        End If

    ''    End If
    ''End Sub
    ''Private Sub ComboBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox2.Validating
    ''    If ComboBox2.Text = Nothing Then
    ''        ErrorProvider1.SetError(Label5, "Obavezan izbor vrste posiljke!")
    ''        ComboBox2.Focus()
    ''    Else
    ''        ErrorProvider1.SetError(Label5, "")
    ''        If Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "1" Then
    ''            mVrstaPrevoza = "P"
    ''        ElseIf Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "2" Then
    ''            mVrstaPrevoza = "G"
    ''        ElseIf Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "3" Then
    ''            mVrstaPrevoza = "V"
    ''        End If
    ''    End If
    ''End Sub

    ''Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub ComboBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.GotFocus
    ''    If mTarifa = "00" Then
    ''        ComboBox2.Items.Clear()
    ''        If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Then
    ''            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''            ComboBox2.Text = "1. Pojedinacna posiljka"
    ''            Me.GroupBox3.Focus()
    ''        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "01" Then
    ''            ComboBox2.Items.Add("3. Kompletni vozovi")
    ''            ComboBox2.Text = "3. Kompletni vozovi"
    ''            Me.GroupBox3.Focus()
    ''        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "02" Then
    ''            ComboBox2.Items.Add("2. Grupa kola")
    ''            ComboBox2.Text = "2. Grupa kola"
    ''            Me.GroupBox3.Focus()
    ''        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
    ''            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''            ComboBox2.Text = "1. Pojedinacna posiljka"
    ''            ComboBox2.SelectedIndex = 0
    ''            Me.GroupBox3.Focus()
    ''        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "67" Then
    ''            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''            ComboBox2.Items.Add("3. Kompletni vozovi")

    ''        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Then
    ''            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''            ComboBox2.Text = "1. Pojedinacna posiljka"
    ''            Me.GroupBox3.Focus()
    ''        Else
    ''            ComboBox2.Items.Clear()
    ''            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''            ComboBox2.Items.Add("2. Grupa kola")
    ''            ComboBox2.Items.Add("3. Kompletni vozovi")
    ''        End If

    ''        'za Intercontainer
    ''        If mSifraKorisnika = 43 Then
    ''            ComboBox2.Items.Add("3. Kompletni vozovi")
    ''            ComboBox2.Text = "3. Kompletni vozovi"
    ''            Me.GroupBox3.Focus()
    ''        ElseIf mSifraKorisnika = 18 Then
    ''            ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''            ComboBox2.Text = "1. Pojedinacna posiljka"
    ''            Me.GroupBox3.Focus()
    ''        End If
    ''    Else
    ''        ComboBox2.Items.Clear()
    ''        ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''        ComboBox2.Items.Add("2. Grupa kola")
    ''        ComboBox2.Items.Add("3. Kompletni vozovi")
    ''    End If

    ''End Sub

    ''Private Sub tbUgovor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUgovor.Validating
    ''    If IsNumeric(tbUgovor.Text) = True Then
    ''        If tbUgovor.Text = Nothing Then
    ''            ComboBox1.Focus()
    ''        Else
    ''            Dim mRetVal As String
    ''            Dim ug_mNazivKomitenta As String
    ''            Dim ug_mAdresaKomitenta As String
    ''            Dim ug_mGradKomitenta As String
    ''            Dim ug_mZemljaKomitenta As String
    ''            Dim ug_mPrimalac As String
    ''            Dim ug_mVrstaObracuna As String

    ''            NadjiUgovor(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, ug_mAdresaKomitenta, ug_mGradKomitenta, ug_mZemljaKomitenta, mRetVal)

    ''            If mRetVal = "" Then
    ''                _Kontrola_NemaUgovora = 0
    ''                _temp_mBrojUg = ""
    ''                mBrojUg = Me.tbUgovor.Text

    ''                mPrimalac = ug_mPrimalac
    ''                mSifraKorisnika = ug_mPrimalac
    ''                mVrstaObracuna = ug_mVrstaObracuna

    ''                If eRazmena = "Da" Then

    ''                Else
    ''                    Me.tb1a.Text = ug_mNazivKomitenta
    ''                    Me.tb1b.Text = ug_mAdresaKomitenta
    ''                    Me.tb1b1.Text = ug_mGradKomitenta
    ''                    Me.tb1b2.Text = ug_mZemljaKomitenta
    ''                    Me.tb2.Text = ug_mPrimalac
    ''                    Me.tb14b.Text = tbUgovor.Text
    ''                    Me.tbA75.Text = tbUgovor.Text
    ''                End If


    ''                '---------
    ''                If mTarifa = "00" Then
    ''                    ComboBox2.Items.Clear()
    ''                    If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Then
    ''                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                        ComboBox2.SelectedText = "1. Pojedinacna posiljka"
    ''                        ComboBox2.SelectedIndex = 0

    ''                        'Me.GroupBox3.Focus()
    ''                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "01" Then
    ''                        ComboBox2.Items.Add("3. Kompletni vozovi")
    ''                        ComboBox2.SelectedText = "3. Kompletni vozovi"
    ''                        ComboBox2.SelectedIndex = 0
    ''                        'Me.GroupBox3.Focus()
    ''                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "02" Then
    ''                        ComboBox2.Items.Add("2. Grupa kola")
    ''                        ComboBox2.SelectedText = "2. Grupa kola"
    ''                        ComboBox2.SelectedIndex = 0
    ''                        'Me.GroupBox3.Focus()
    ''                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
    ''                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                        ComboBox2.SelectedText = "1. Pojedinacna posiljka"
    ''                        ComboBox2.SelectedIndex = 0
    ''                        'Me.GroupBox3.Focus()
    ''                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "67" Then
    ''                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                        ComboBox2.Items.Add("3. Kompletni vozovi")
    ''                        ComboBox2.SelectedIndex = 1
    ''                        'ComboBox2.DroppedDown = True

    ''                        'ComboBox2.Focus()
    ''                    ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Then
    ''                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                        ComboBox2.SelectedText = "1. Pojedinacna posiljka"
    ''                        ComboBox2.SelectedIndex = 0
    ''                        'Me.GroupBox3.Focus()
    ''                    Else
    ''                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                        ComboBox2.Items.Add("2. Grupa kola")
    ''                        ComboBox2.Items.Add("3. Kompletni vozovi")
    ''                        ComboBox2.SelectedIndex = 0
    ''                    End If

    ''                    'za Intercontainer
    ''                    If mSifraKorisnika = 43 Then
    ''                        ComboBox2.Items.Add("3. Kompletni vozovi")
    ''                        ComboBox2.SelectedText = "3. Kompletni vozovi"
    ''                        ComboBox2.SelectedIndex = 0
    ''                        'Me.GroupBox3.Focus()
    ''                    ElseIf mSifraKorisnika = 18 Then
    ''                        ComboBox2.Items.Add("1. Pojedinacna posiljka")
    ''                        ComboBox2.SelectedText = "1. Pojedinacna posiljka"
    ''                        ComboBox2.SelectedIndex = 0
    ''                        'Me.GroupBox3.Focus()
    ''                    End If
    ''                    If IzborSaobracaja = "4" Then
    ''                        Me.cbSmer1.Focus()
    ''                    Else
    ''                        If IzborSaobracaja = "2" Then
    ''                            Me.cbSmer1.Focus()
    ''                        Else
    ''                            Me.cbSmer2.Focus()
    ''                        End If
    ''                    End If
    ''                End If
    ''                ErrorProvider1.SetError(tbUgovor, "")

    ''                If TipTranzita = "izlaz" Then
    ''                    Me.tbUlaznaNalepnica.Focus()

    ''                End If
    ''                '---------
    ''            Else
    ''                _Kontrola_NemaUgovora = 1
    ''                ErrorProvider1.SetError(tbUgovor, "")
    ''                'MessageBox.Show(mRetVal, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation)
    ''                MessageBox.Show("Takav ugovor ne postoji u bazi podataka! Primenite redovnu tarifu.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation)
    ''                Label5.Text = " "

    ''                _temp_mBrojUg = tbUgovor.Text ' proveriti kako radi do kraja

    ''                ComboBox1.Focus()
    ''            End If
    ''        End If
    ''    Else
    ''        ErrorProvider1.SetError(tbUgovor, "Neispravan unos!")
    ''        tbUgovor.Focus()
    ''    End If

    ''End Sub

    ''Private Sub tbsBrojVoza_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If

    ''End Sub

    ''Private Sub tbsBrojVoza_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    ''    If IsNumeric(tbsBrojVoza.Text) = True Then
    ''        If tbsBrojVoza.Text = "" Then
    ''            tbsBrojVoza.Text = "0"
    ''        End If
    ''        If CType(tbsBrojVoza.Text, Int32) = 0 Then
    ''            ErrorProvider1.SetError(tbsBrojVoza, "Obavezan unos saobracajnog broja voza!")
    ''            tbsBrojVoza.Focus()
    ''        Else
    ''            ErrorProvider1.SetError(tbsBrojVoza, "")
    ''        End If
    ''    Else
    ''        ErrorProvider1.SetError(tbsBrojVoza, "Neispravan unos!")
    ''        tbsBrojVoza.Focus()
    ''    End If
    ''End Sub

    ''Private Sub tbsSatVoza_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbsSatVoza_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    ''    If CType(tbsSatVoza.Text, Int16) > 23 Then
    ''        ErrorProvider1.SetError(tbsSatVoza, "Sat voza je manji od 24")
    ''        tbsSatVoza.Focus()
    ''    Else
    ''        ErrorProvider1.SetError(tbsSatVoza, "")
    ''    End If
    ''End Sub
    ''Private Sub rbKolska_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbKolska.MouseUp
    ''    If Me.rbKolska.Checked = True Then
    ''        bVrstaPosiljke = "K"
    ''    Else
    ''        bVrstaPosiljke = "D"
    ''    End If
    ''End Sub

    ''Private Sub rbDencana_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbDencana.MouseUp
    ''    If Me.rbKolska.Checked = True Then
    ''        bVrstaPosiljke = "K"
    ''    Else
    ''        bVrstaPosiljke = "D"
    ''    End If
    ''End Sub

    ''Private Sub cbCIM_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''    If Me.cbCIM.Checked = True Then
    ''        Me.cbCUV.Checked = False
    ''    Else
    ''        Me.cbCUV.Checked = True
    ''    End If
    ''End Sub

    ''Private Sub cbCUV_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''    If Me.cbCUV.Checked = True Then
    ''        Me.cbCIM.Checked = False
    ''    Else
    ''        Me.cbCIM.Checked = True
    ''    End If

    ''End Sub

    ''Private Sub cbSmer1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer1.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub cbSmer2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer2.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbUlaznaNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUlaznaNalepnica.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbIzlaznaNalepnica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbIzlaznaNalepnica.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbUlaznaNalepnica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUlaznaNalepnica.Validating
    ''    If tbUlaznaNalepnica.Text = Nothing Then
    ''        ErrorProvider1.SetError(tbUlaznaNalepnica, "Unesite broj tranzitne nalepnice")
    ''        tbUlaznaNalepnica.Focus()
    ''    Else
    ''        If IsNumeric(tbUlaznaNalepnica.Text) Then
    ''            If CType(tbUlaznaNalepnica.Text, Int32) = 0 Then
    ''                ErrorProvider1.SetError(tbUlaznaNalepnica, "Neispravan broj tranzitne nalepnice!")
    ''                tbUlaznaNalepnica.Focus()
    ''            Else
    ''                ''If TipTranzita = "ulaz" Then
    ''                ''    Dim xNaziv As String = ""
    ''                ''    Dim xPovVrednost As String = ""

    ''                ''    Util.sNadjiNalepnicu(tbUlaznaNalepnica.Text, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mObrGodina, mObrMesec, xNaziv, xPovVrednost)

    ''                ''    If xPovVrednost <> "" Then
    ''                ''        ErrorProvider1.SetError(tbUlaznaNalepnica, "")
    ''                ''    Else
    ''                ''        ErrorProvider1.SetError(tbUlaznaNalepnica, "Nalepnica sa tim brojem je uneta!")
    ''                ''        tbUlaznaNalepnica.Focus()
    ''                ''    End If
    ''                ''End If
    ''                ''Ispitati kod upisa u bazu
    ''            End If
    ''        Else
    ''            ErrorProvider1.SetError(tbUlaznaNalepnica, "Neispravan broj tranzitne nalepnice!")
    ''            tbUlaznaNalepnica.Focus()
    ''        End If
    ''    End If

    ''End Sub

    ''Private Sub tbIzlaznaNalepnica_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbIzlaznaNalepnica.Validated
    ''    If tbIzlaznaNalepnica.Text = Nothing Then
    ''        tbIzlaznaNalepnica.Focus()
    ''    Else
    ''        Me.tbUpravaOtp.Focus()
    ''    End If
    ''End Sub

    ''Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "     Primalac"
    ''    upit = "Primalac"
    ''    helpUic.ShowDialog()
    ''    Me.tb4a.Text = mIzlaz2
    ''    Me.tb4b.Text = mIzlaz4
    ''    Me.tb4b1.Text = Microsoft.VisualBasic.Mid(mIzlaz1, 3, Len(mIzlaz1))
    ''    Me.tb4b2.Text = Microsoft.VisualBasic.Left(mIzlaz1, 2)
    ''    Me.tb5.Text = CType(mIzlaz5, Integer)

    ''End Sub

    ''Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "     Pošiljalac"
    ''    upit = "Posiljalac"
    ''    helpUic.ShowDialog()
    ''    Me.tb1a.Text = mIzlaz2
    ''    Me.tb1b.Text = mIzlaz4
    ''    Me.tb1b1.Text = Microsoft.VisualBasic.Mid(mIzlaz1, 3, Len(mIzlaz1))
    ''    Me.tb1b2.Text = Microsoft.VisualBasic.Left(mIzlaz1, 2)
    ''    Me.tb2.Text = CType(mIzlaz5, Integer)


    ''End Sub

    ''Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "     Korisnièke šifre"
    ''    upit = "SifreKorisnika"
    ''    helpUic.ShowDialog()
    ''    Me.tb3.Text = CType(mIzlaz5, Integer)
    ''End Sub

    ''Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "     Korisnièke šifre"
    ''    upit = "SifreKorisnika"
    ''    helpUic.ShowDialog()
    ''    Me.tb6.Text = CType(mIzlaz5, Integer)

    ''End Sub

    ''Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    'upit
    ''    'SELECT UicStanice.SifraStanice, UicStanice.Naziv, UicUprave.NazivE
    ''    'FROM   UicStanice INNER JOIN
    ''    '       UicUprave ON UicStanice._SifraUprave = UicUprave.SifraUprave
    ''    'WHERE  (UicStanice.SifraStanice = '5106870')

    ''End Sub

    ''Private Sub tbUpravaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUpravaOtp.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbStanicaOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaOtp.Leave
    ''    Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
    ''    Me.tbStanicaOtp.ForeColor = System.Drawing.Color.Black

    ''    If Len(tbStanicaOtp.Text) < 7 Then
    ''        ErrorProvider1.SetError(Me.TextBox1, "Neispravna sifra stanice!")
    ''        tbStanicaOtp.Focus()
    ''    Else
    ''        ErrorProvider1.SetError(Me.TextBox1, "")
    ''    End If

    ''End Sub

    ''Private Sub tbUpravaOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUpravaOtp.Validating
    ''    Dim xNaziv As String = ""
    ''    Dim xPovVrednost As String = ""

    ''    Util.sNadjiNaziv("UicOperateri", tbUpravaOtp.Text, "", "", 1, xNaziv, xPovVrednost)
    ''    '
    ''    '''       Util.sNadjiNaziv("UicOperateri", Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 1, 2), Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2), "", 1, xNaziv, xPovVrednost)

    ''    If xPovVrednost <> "" Then
    ''        ErrorProvider1.SetError(tbUpravaOtp, "Nepostojeca uprava!")
    ''        tbUpravaOtp.Focus()
    ''    Else
    ''        Label11.Text = Microsoft.VisualBasic.Mid(xNaziv, 3, Len(xNaziv))
    ''        ''mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)
    ''        mOtpUprava = Microsoft.VisualBasic.Left(xNaziv, 2)

    ''        If Len(tbStanicaOtp.Text) = 7 Then

    ''        Else

    ''            tbStanicaOtp.Text = mOtpUprava 'Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2)
    ''            tbStanicaOtp.SelectionStart = 3
    ''        End If
    ''        ErrorProvider1.SetError(tbUpravaOtp, "")
    ''    End If

    ''End Sub

    Private Sub tbStanicaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    ''Private Sub tbBrojOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojOtp.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbBrojOtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.LostFocus
    ''    If tbBrojOtp.Text = Nothing Then
    ''        mOtpBroj = 0
    ''    Else
    ''        mOtpBroj = tbBrojOtp.Text
    ''        If IzborSaobracaja <> "3" Then
    ''            TB58a1.Text = Me.tbUpravaOtp.Text
    ''            TB58a2.Text = Me.Label11.Text
    ''        End If
    ''    End If
    ''End Sub

    ''Private Sub tbBrojOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojOtp.Validating
    ''    If tbBrojOtp.Text = "0" Then
    ''        ErrorProvider1.SetError(Label15, "Broj otpravljanja ne moze da bude nula!")
    ''        tbBrojOtp.Focus()
    ''    Else
    ''        If tbBrojOtp.Text = Nothing Then
    ''            ErrorProvider1.SetError(Label15, "Neispravan broj otpravljanja!")
    ''            tbBrojOtp.Focus()
    ''        Else
    ''            If IsNumeric(tbBrojOtp.Text) = True Then
    ''                ErrorProvider1.SetError(Label15, "")
    ''            Else
    ''                ErrorProvider1.SetError(Label15, "Neispravan unos!")
    ''                tbBrojOtp.Focus()
    ''            End If
    ''        End If
    ''    End If

    ''End Sub

    Private Sub DatumOtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.LostFocus
        mOtpDatum = DatumOtp.Text
    End Sub

    Private Sub DatumOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DatumOtp.Validating
        Dim mRetVal As String
        Dim mRecID As Int32
        Dim mStanicaRecID As String
        Dim strOtpBroj As String = CType(tbBrojOtp.Text, String) '& CType(kbBrojOtp.Text, String)

        mOtpDatum = Me.DatumOtp.Value.ToShortDateString
        mMesec = mOtpDatum.Month.ToString
        mDan = mOtpDatum.Day.ToString
        mGodina = mOtpDatum.Year.ToString
        mDatumKalk = DatumOtp.Value

        'NadjiTL1("0072", "72" + tbStanicaOtp.Text, CType(strOtpBroj, Int32), mOtpDatum, mRecID, mStanicaRecID, mRetVal)
        ''NadjiTL1(tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, mOtpDatum, mRecID, mStanicaRecID, mRetVal)
 

        If mRetVal = "" Then    'ne postoji

            If bVrstaSaobracaja <> 0 Then
                bNadjiIPrikaziKurseve(bValuta)
            Else
                If mBrojUg = "200379" Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then         ' 25.07.2016 za sada; treba ukljuciti da li su cene u RSD ili EURThen
                    bNadjiIPrikaziKurseve("17")
                End If
            End If
            mOtpDatum = DatumOtp.Text

            If IzborSaobracaja = "1" Then
                Me.tbStanicaPr.Focus()
            End If
            ErrorProvider1.SetError(tbBrojOtp, "")
        Else
            If Not (RecordAction = "N") Then
                ErrorProvider1.SetError(tbBrojOtp, "Takav podatak je vec unet!")
                tbBrojOtp.Focus()
            End If

        End If

        If mOtpDatum > Today Then
            ErrorProvider1.SetError(Label17, "Neispravan datum!")
            DatumOtp.Focus()
        Else
            ErrorProvider1.SetError(Label17, "")
        End If


    End Sub

    Private Sub tbStanicaPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaPr.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            'MsgBox("enter")
            e.Handled = True
            SendKeys.Send(Chr(9))
            bShiftTab = False
        ElseIf e.KeyChar() = Microsoft.VisualBasic.ChrW(121) Then
            'MsgBox("f10")
            bShiftTab = True
        Else
            'MsgBox("else")
            bShiftTab = False
        End If

    End Sub

    Private Sub tbStanicaPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.Leave
        Me.tbStanicaPr.BackColor = System.Drawing.Color.White
        Me.tbStanicaPr.ForeColor = System.Drawing.Color.Black

        If Len(tbStanicaPr.Text) < 5 Then
            ErrorProvider1.SetError(Me.Label18, "Neispravna sifra stanice!")
            If bShiftTab Then
                tbStanicaOtp.Focus()
            Else
                tbStanicaPr.Focus()
            End If
        Else
            If tbStanicaPr.Text = tbStanicaOtp.Text Then
                'ErrorProvider1.SetError(Me.Label18, "Neispravan izbor stanice!")
                'tbStanicaPr.Focus()
            Else
                ErrorProvider1.SetError(Me.Label18, "")
                'MsgBox("u leave")
                'Daljinar()
            End If
        End If
    End Sub
    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DateTimePicker2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.Leave
        Me.DateTimePicker2.BackColor = System.Drawing.Color.White
        'btnUnosRobe.Focus()
        tbR11.Focus()
    End Sub

    ''Private Sub FormUTL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    ''    If e.KeyCode = Keys.F12 Then
    ''        ''btnUnosRobe_Click(Me, Nothing)
    ''        tbR68b.Focus()

    ''    ElseIf e.KeyCode = Keys.F11 Then
    ''        ''Button4_Click(Me, Nothing)
    ''        tbR2.Focus()

    ''    ElseIf e.KeyCode = Keys.F10 Then
    ''        'Button7_Click(Me, Nothing)
    ''    End If
    ''End Sub


    ''Private Sub FormUTL_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    ''    If dtKola.Rows.Count = 1 Then
    ''        tbIBK.Text = mIBK
    ''        Me.tb25.Text = mSumaRobe
    ''        Me.lblTaraValue.Text = mSumaTara.ToString
    ''        Me.lblBrutoValue.Text = mSumaBruto.ToString


    ''        Me.tb24.Text = mNHM
    ''        Me.tbA72d.Text = mNHM

    ''        Me.rtb21.Text = " 1 vagon - " & jci_NazivRobe
    ''        rtb21.Text = rtb21.Text + Environment.NewLine

    ''        Me.tbA74d1.Text = bRacunskaMasa 'mSumaRobe 'treba racunska
    ''    ElseIf dtKola.Rows.Count > 1 Then
    ''        tbIBK.Text = "Vidi spisak kola"
    ''        Me.tb25.Text = mSumaRobe
    ''        Me.lblTaraValue.Text = mSumaTara.ToString
    ''        Me.lblBrutoValue.Text = mSumaBruto.ToString

    ''        Me.tb24.Text = mNHM
    ''        Me.tbA72d.Text = mNHM
    ''        Me.rtb21.Text = dtKola.Rows.Count.ToString & " vagona - " & jci_NazivRobe
    ''        rtb21.Text = rtb21.Text + Environment.NewLine
    ''        'DODATI U R21: bruto, tara, neto

    ''        Me.tbA74d1.Text = bRacunskaMasa 'mSumaRobe 'treba racunska
    ''    End If
    ''    combo73A.SelectedIndex = 0

    ''    If dtKola.Rows.Count = 0 Then
    ''        tbIBK.Text = ""
    ''    End If

    ''    If dtNaknade.Rows.Count = 1 Then
    ''        tbA79a1.Text = mrA79a1
    ''        tbA79b1.Text = mrA79b1
    ''        tbA79a2.Text = ""
    ''        tbA79b2.Text = ""
    ''        tbA79a3.Text = ""
    ''        tbA79b3.Text = ""
    ''    ElseIf dtNaknade.Rows.Count = 2 Then
    ''        tbA79a1.Text = mrA79a1
    ''        tbA79b1.Text = mrA79b1
    ''        tbA79a2.Text = mrA79a2
    ''        tbA79b2.Text = mrA79b2
    ''        tbA79a3.Text = ""
    ''        tbA79b3.Text = ""
    ''    ElseIf dtNaknade.Rows.Count >= 3 Then
    ''        tbA79a1.Text = mrA79a1
    ''        tbA79b1.Text = mrA79b1
    ''        tbA79a2.Text = mrA79a2
    ''        tbA79b2.Text = mrA79b2
    ''        tbA79a3.Text = mrA79a3
    ''        tbA79b3.Text = mrA79b3
    ''    End If

    ''    If PrikazKalkulacije = "D" Then
    ''        tbPrevoznina.Text = Format(mPrevoznina, "###,###,##0.00")
    ''    Else
    ''        tbPrevoznina.Text = ""
    ''    End If

    ''    If _OpenForm = "Roba" Then
    ''        If IzborSaobracaja = "3" And eCimDa = "D" Then
    ''            Me.tb16c.Focus()
    ''        Else
    ''            If IzborSaobracaja = "2" Then
    ''                If Microsoft.VisualBasic.Mid(tb24.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tb24.Text, 1, 4) = "9922" Then
    ''                    Me.btnUpis.Focus()
    ''                Else
    ''                    Me.tbCarinjenje.Focus()
    ''                End If
    ''            Else
    ''                Me.btnUpis.Focus()
    ''            End If

    ''        End If
    ''    ElseIf _OpenForm = "Naknade" Then
    ''    ElseIf _OpenForm = "Upis" Then
    ''        Me.btnUpis.Focus()
    ''    End If

    ''End Sub

    ''Private Sub Button16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    'Dim helpUic As New HelpForm
    ''    'helpUic.Text = "UIC"
    ''    'upit = "Posiljalac"
    ''    'helpUic.ShowDialog()
    ''    'Me.tb1a.Text = mIzlaz2
    ''    'Me.tb1b.Text = mIzlaz4
    ''    'Me.tb2.Text = CType(mIzlaz5, Integer)
    ''End Sub

    ''Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "help carinarnice"
    ''    upit = "CARINA"
    ''    helpUic.ShowDialog()

    ''    Me.tbCarinjenje.Text = mIzlaz1
    ''    Me.lblCarinarnica.Text = mIzlaz2

    ''    '''If IzborSaobracaja = "3" Then
    ''    tb51a.Text = lblCarinarnica.Text
    ''    tb51b.Text = "72"
    ''    tb51c.Text = tbCarinjenje.Text

    ''    '''End If

    ''End Sub

    ''Private Sub cbFrankoPrevoznina_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbFrankoPrevoznina.MouseUp
    ''    If Me.cbFrankoPrevoznina.Checked = True Then
    ''        Me.comboIncoterms.Enabled = False
    ''        Me.cbIncoterms.Checked = False
    ''        Me.comboIncoterms.SelectedIndex = -1
    ''        tb20a.Focus()
    ''    Else
    ''        Me.cbIncoterms.Checked = True
    ''        Me.comboIncoterms.Enabled = True
    ''        Me.comboIncoterms.Focus()
    ''    End If

    ''End Sub

    ''Private Sub cbIncoterms_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''    If Me.cbIncoterms.Checked = True Then
    ''        Me.comboIncoterms.Enabled = True
    ''        Me.cbFrankoPrevoznina.Checked = False
    ''        Me.comboIncoterms.Focus()
    ''    Else
    ''        Me.comboIncoterms.SelectedIndex = -1
    ''        Me.comboIncoterms.Enabled = False
    ''        Me.cbFrankoPrevoznina.Checked = True
    ''        tb20a.Focus()
    ''    End If

    ''End Sub

    Private Sub tb20a_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20a.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb20b_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20b.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb20c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20c.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb20d_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20d.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub


    ''Private Sub tb16c_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb16d_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb16e_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb20a_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb20a.Validating
    ''    If tb20a.Text = Nothing Then

    ''    Else
    ''        Me.tb49b.Text = tb20a.Text
    ''        Me.tb49a.Text = "11"
    ''    End If

    ''End Sub

    ''Private Sub tb20b_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb20b.Validating
    ''    Me.tb49c.Text = tb20b.Text
    ''    Me.tb49a.Text = "11"
    ''End Sub

    ''Private Sub tb20a_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb20a.Leave
    ''    If Len(tb20a.Text) = 0 Then
    ''        Me.tb20f.Focus()
    ''    End If
    ''End Sub

    ''Private Sub tb20b_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb20b.Leave
    ''    If Len(tb20b.Text) = 0 Then
    ''        Me.tb20f.Focus()
    ''    End If

    ''End Sub

    ''Private Sub cbSmer1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer1.Leave
    ''    Me.tbA70a1.Text = "72"
    ''    Me.tbA70a2.Text = "72"

    ''    ''Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)


    ''End Sub

    ''Private Sub cbSmer2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer2.Leave
    ''    ''Me.tbA70b2.Text = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
    ''    If cbSmer2.Text = Nothing Then
    ''        cbSmer2.Focus()

    ''    Else
    ''        If cbSmer2.Text = cbSmer1.Text Then
    ''            cbSmer2.Focus()
    ''        Else
    ''            If IzborSaobracaja = "4" Then
    ''                If TipTranzita = "izlaz" Then
    ''                    Me.tbUlaznaNalepnica.Focus()
    ''                Else
    ''                    Me.tbUpravaOtp.Focus()
    ''                End If
    ''            ElseIf IzborSaobracaja = "3" Then
    ''            ElseIf IzborSaobracaja = "4" Then
    ''            End If
    ''        End If
    ''    End If

    ''End Sub

    ''Private Sub tb20f_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.btnCarinarnica.Focus()

    ''End Sub

    ''Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
    ''    Dim GridNaknade As New naknade
    ''    GridNaknade.ShowDialog()

    ''End Sub

    ''Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Dim helpUic As New HelpForm
    ''    upit = "R55"
    ''    helpUic.ShowDialog()
    ''    Me.rtb55.AppendText(mizlazObject)
    ''    rtb55.Text = rtb55.Text + Environment.NewLine
    ''End Sub

    ''Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Dim helpUic As New HelpForm
    ''    upit = "R7"
    ''    helpUic.ShowDialog()
    ''    Me.rtb7.AppendText(mizlazObject)
    ''    rtb7.Text = rtb7.Text + Environment.NewLine
    ''End Sub
    ''Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Dim helpUic As New HelpForm
    ''    upit = "R56"
    ''    helpUic.ShowDialog()
    ''    Me.rtb56.AppendText(mizlazObject)
    ''    rtb56.Text = rtb56.Text + Environment.NewLine
    ''End Sub

    ''''Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
    ''''    For i As Integer = 0 To 9
    ''''        For j As Integer = 0 To 1
    ''''            If NizR50(i, j) = Nothing Then
    ''''                NumNizR50 = i
    ''''                Exit For
    ''''            End If
    ''''        Next
    ''''        If NumNizR50 > 0 Then
    ''''            Exit For
    ''''        End If
    ''''    Next
    ''''    MsgBox("broj elemenata=" & NumNizR50.ToString)

    ''''End Sub

    ''Public Sub Katarina()
    ''    Dim daPrevPut As SqlClient.SqlDataAdapter
    ''    Dim dsPrevPut As New Data.DataSet
    ''    Dim pomSifraPP As String
    ''    Dim ZaCombo As String = ""

    ''    Dim upit As String = ""
    ''    Dim combo_linija1 As String = ""
    ''    Dim objComm As SqlClient.SqlCommand

    ''    If OkpDbVeza.State = ConnectionState.Closed Then
    ''        OkpDbVeza.Open()
    ''    End If
    ''    '---------------
    ''    Dim ii As Int32 = 0
    ''    Dim mSifraPrevPuta As String = ""
    ''    Dim mSifra As String = ""
    ''    Dim SamoJedanPut As String = "Da"

    ''    cmbPrevPut.Items.Clear()
    ''    dsPrevPut.Clear()

    ''    If IzborSaobracaja = "2" Then
    ''        upit = "SELECT * FROM UicPrevozniPutStavka WHERE (Uprava = '" & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & "')"
    ''    Else
    ''        upit = "SELECT * FROM UicPrevozniPutStavka WHERE (Uprava = '" & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & "')"
    ''    End If

    ''    'upit = "SELECT * FROM UicPrevozniPutStavka WHERE (Uprava = '" & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & "')"

    ''    objComm = New SqlClient.SqlCommand(upit, OkpDbVeza)
    ''    daPrevPut = New SqlClient.SqlDataAdapter(upit, OkpDbVeza)
    ''    ii = daPrevPut.Fill(dsPrevPut)

    ''    ZaCombo = ""

    ''    Try
    ''        pomSifraPP = dsPrevPut.Tables(0).Rows(0).Item("SifraPP")
    ''        For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
    ''            If dsPrevPut.Tables(0).Rows(kk).Item("SifraPP") <> pomSifraPP Then
    ''                If IzborSaobracaja = "2" Then
    ''                    combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo
    ''                Else
    ''                    'combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
    ''                    combo_linija1 = Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
    ''                End If
    ''                'combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo
    ''                cmbPrevPut.Items.Add(combo_linija1)
    ''                ZaCombo = ""
    ''                SamoJedanPut = "Ne"
    ''            Else

    ''            End If

    ''            mSifraPrevPuta = dsPrevPut.Tables(0).Rows(kk).Item("SifraPP")
    ''            ZaCombo = ZaCombo & "  " & dsPrevPut.Tables(0).Rows(kk).Item("UpravaPut")
    ''            pomSifraPP = dsPrevPut.Tables(0).Rows(kk).Item("SifraPP")

    ''            If kk = dsPrevPut.Tables(0).Rows.Count - 1 Then
    ''                If IzborSaobracaja = "2" Then
    ''                    combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo
    ''                Else
    ''                    'combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
    ''                    combo_linija1 = Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
    ''                End If
    ''                cmbPrevPut.Items.Add(combo_linija1)
    ''                SamoJedanPut = "Ne"
    ''            End If
    ''        Next

    ''        If SamoJedanPut = "Da" Then
    ''            If IzborSaobracaja = "2" Then
    ''                cmbPrevPut.Items.Add(mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo)
    ''            Else
    ''                'cmbPrevPut.Items.Add(mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo)
    ''                cmbPrevPut.Items.Add(Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo)
    ''            End If
    ''        End If

    ''    Catch ex As Exception
    ''        MsgBox("Nama podataka za upravu " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2))
    ''    End Try

    ''    OkpDbVeza.Close()

    ''End Sub
    ''Private Sub cmbPrevPut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.GotFocus
    ''    Katarina()
    ''    cmbPrevPut.DroppedDown = True
    ''End Sub

    ''Private Sub cmbPrevPut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPrevPut.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub cmbPrevPut_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.Leave
    ''    If cmbPrevPut.Text = Nothing Then
    ''        cmbPrevPut.Focus()
    ''    Else
    ''        Me.tbsBrojVoza.Focus()

    ''        ''''' Me.cbR57.Focus()
    ''    End If
    ''End Sub
    ''Private Sub cmbPrevPut_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbPrevPut.Validating
    ''    Dim tmpUicPut As String = ""
    ''    m_UicPrevozniPut = ""

    ''    Me.rtb57a.Items.Clear()
    ''    Me.rtb57b.Items.Clear()
    ''    Me.rtb57b2.Items.Clear()
    ''    Me.rtb57c.Items.Clear()

    ''    'tmpUicPut = Microsoft.VisualBasic.Right(cmbPrevPut.Text, Len(cmbPrevPut.Text) - 5)
    ''    tmpUicPut = cmbPrevPut.Text

    ''    For ii As Int16 = 1 To Len(tmpUicPut)
    ''        If Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1) <> " " Then
    ''            m_UicPrevozniPut = m_UicPrevozniPut & Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1)
    ''        End If
    ''    Next

    ''    If IzborSaobracaja = "3" And eCimDa = "D" Then

    ''        '--------------- okrenuti smer zbog izvoza
    ''        Dim aString As String = ""
    ''        Dim aString1 As String = ""
    ''        Dim ijk As Int16 = 0

    ''        For ijk = (Len(m_UicPrevozniPut) / 2) To 1 Step -1
    ''            aString = aString & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ijk - 1, 2)
    ''        Next

    ''        For ijk = 1 To (Len(m_UicPrevozniPut) / 2)
    ''            aString1 = aString1 & "  " & Microsoft.VisualBasic.Mid(aString, 2 * ijk - 1, 2)
    ''        Next

    ''        m_UicPrevozniPut = Microsoft.VisualBasic.LTrim(aString1)
    ''        '----------------------------------------

    ''        If Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "55" Then
    ''            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "1" Then
    ''                ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
    ''                cmbPrevPut.Focus()
    ''            Else
    ''                ErrorProvider1.SetError(lblPP, "")
    ''            End If
    ''        ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "53" Then
    ''            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "2" And Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "3" Then
    ''                ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
    ''                cmbPrevPut.Focus()
    ''            Else
    ''                ErrorProvider1.SetError(lblPP, "")
    ''            End If
    ''        ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "52" Then
    ''            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "4" Then
    ''                ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
    ''                cmbPrevPut.Focus()
    ''            Else
    ''                ErrorProvider1.SetError(lblPP, "")
    ''            End If
    ''        ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "65" Then
    ''            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "5" Then
    ''                ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
    ''                cmbPrevPut.Focus()
    ''            Else
    ''                ErrorProvider1.SetError(lblPP, "")
    ''            End If
    ''        ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "62" Then
    ''            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "6" Then
    ''                ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
    ''                cmbPrevPut.Focus()
    ''            Else
    ''                ErrorProvider1.SetError(lblPP, "")
    ''            End If
    ''        ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "44" Then
    ''            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "7" Then
    ''                ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
    ''                cmbPrevPut.Focus()
    ''            Else
    ''                ErrorProvider1.SetError(lblPP, "")
    ''            End If
    ''        ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "50" Then
    ''            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "7" Then
    ''                ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
    ''                cmbPrevPut.Focus()
    ''            Else
    ''                ErrorProvider1.SetError(lblPP, "")
    ''            End If
    ''        ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "78" Then
    ''            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "8" And Microsoft.VisualBasic.Left(cbSmer2.Text, 2) <> "10" Then
    ''                ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
    ''                cmbPrevPut.Focus()
    ''            Else
    ''                ErrorProvider1.SetError(lblPP, "")
    ''            End If
    ''        End If

    ''        '''Me.tbsBrojVoza.Focus() 'izvuceno

    ''        If Len(m_UicPrevozniPut) = 2 Then
    ''            Me.tbsBrojVoza.Focus()
    ''        Else
    ''            PopuniR57a()
    ''            R57_Init()

    ''            '''Me.tbsBrojVoza.Focus()
    ''        End If

    ''    End If


    ''End Sub




    ''Private Sub dgError_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgError.MouseUp
    ''    Dim hitInfo As System.Windows.Forms.DataGrid.HitTestInfo
    ''    Dim mm As String

    ''    hitInfo = dgError.HitTest(e.X, e.Y)

    ''    If hitInfo.Type = System.Windows.Forms.DataGrid.HitTestType.Cell Then
    ''        Dim selCell As Object
    ''        selCell = dgError.Item(hitInfo.Row, hitInfo.Column)
    ''        If Not selCell Is Nothing Then
    ''            mm = selCell.ToString()
    ''        End If
    ''    End If
    ''    Me.dgError.Visible = False

    ''    '------------- Akcija ----------------
    ''    If mm = "Izlazni granicni prelaz" Then
    ''        cbSmer2.Focus()
    ''    ElseIf mm = "Ulazna tranzitna nalepnica" Then
    ''        Me.tbUlaznaNalepnica.Focus()
    ''    ElseIf mm = "Izlazna tranzitna nalepnica" Then
    ''        Me.tbIzlaznaNalepnica.Focus()
    ''    ElseIf mm = "Tarifski kilometri" Then
    ''        Me.tbA76.Focus()
    ''    ElseIf mm = "Otpravna uprava - operater" Then
    ''        Me.tbUpravaOtp.Focus()
    ''    ElseIf mm = "Otpravna stanica" Then
    ''        Me.tbStanicaOtp.Focus()
    ''    ElseIf mm = "Broj otpravljanja" Then
    ''        Me.tbBrojOtp.Focus()
    ''    ElseIf mm = "Uputna uprava - operater" Then
    ''        Me.tbUpravaPr.Focus()
    ''    ElseIf mm = "Uputna stanica" Then
    ''        Me.tbStanicaPr.Focus()
    ''    ElseIf mm = "Odredisna carinarnica" Then
    ''        Me.tbCarinjenje.Focus()
    ''    ElseIf mm = "Preuzimanje na prevoz" Then
    ''        Me.tbCarinjenje.Focus()
    ''    ElseIf mm = "Posiljalac" Then
    ''        Me.tb1a.Focus()
    ''    ElseIf mm = "Primalac" Then
    ''        Me.tb4a.Focus()
    ''    ElseIf mm = "Unos robe" Then
    ''        Dim GridKola As New kola
    ''        GridKola.Show()
    ''    End If
    ''    '-------------------------------------
    ''End Sub

    ''Private Sub btnStanicaOtp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStanicaOtp.Click
    ''    helpUprava = Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2)
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "help UIC"
    ''    upit = "UIC"
    ''    helpUic.ShowDialog()
    ''    Me.tbStanicaOtp.Text = mIzlaz1
    ''    Label12.Text = mIzlaz2
    ''    tbStanicaPr.Focus()
    ''End Sub

    ''Private Sub btnUpravaPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpravaPr.Click
    ''    Me.tbStanicaPr.Clear()
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "help UIC"
    ''    upit = "UPR1"
    ''    helpUic.ShowDialog()
    ''    ErrorProvider1.SetError(TextBox1, "")
    ''    Me.tbUpravaPr.Text = mIzlaz1
    ''    Label14.Text = mIzlaz2
    ''    Me.TextBox1.Text = mIzlaz3
    ''    tbBrojOtp.Focus()
    ''End Sub

    ''Private Sub btnStanicaPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStanicaPr.Click
    ''    helpUprava = Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2)
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "help UIC"
    ''    upit = "UIC"
    ''    helpUic.ShowDialog()
    ''    ErrorProvider1.SetError(TextBox2, "")
    ''    Me.tbStanicaPr.Text = mIzlaz1
    ''    Label13.Text = mIzlaz2
    ''    Me.TextBox2.Text = mIzlaz3
    ''    Me.DateTimePicker2.Focus()
    ''End Sub


    ''Private Sub cmbPrevPut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.Click
    ''    Katarina()
    ''End Sub
    ''Private Sub InitNizUic()

    ''    NizUic(0, 0) = "0010"
    ''    NizUic(0, 1) = "VR         "
    ''    NizUic(1, 0) = "2120"
    ''    NizUic(1, 1) = "RZD        "
    ''    NizUic(2, 0) = "0021"
    ''    NizUic(2, 1) = "BC         "
    ''    NizUic(3, 0) = "0022"
    ''    NizUic(3, 1) = "UZ         "
    ''    NizUic(4, 0) = "0023"
    ''    NizUic(4, 1) = "CFM        "
    ''    NizUic(5, 0) = "0024"
    ''    NizUic(5, 1) = "LG         "
    ''    NizUic(6, 0) = "0025"
    ''    NizUic(6, 1) = "LDZ        "
    ''    NizUic(7, 0) = "0026"
    ''    NizUic(7, 1) = "EVR        "
    ''    NizUic(8, 0) = "0027"
    ''    NizUic(8, 1) = "KTZ        "
    ''    NizUic(9, 0) = "0028"
    ''    NizUic(9, 1) = "GR         "
    ''    NizUic(10, 0) = "0029"
    ''    NizUic(10, 1) = "UTI        "
    ''    NizUic(11, 0) = "0041"
    ''    NizUic(11, 1) = "HSH        "
    ''    NizUic(12, 0) = "0044"
    ''    NizUic(12, 1) = "ZRS        "
    ''    NizUic(13, 0) = "0050"
    ''    NizUic(13, 1) = "ZFBH       "
    ''    NizUic(14, 0) = "2151"
    ''    NizUic(14, 1) = "PKP CARGO  "
    ''    NizUic(15, 0) = "2152"
    ''    NizUic(15, 1) = "BDZ        "
    ''    NizUic(16, 0) = "2153"
    ''    NizUic(16, 1) = "CFR Marfa  "
    ''    NizUic(17, 0) = "2154"
    ''    NizUic(17, 1) = "CD Cargo   "
    ''    NizUic(18, 0) = "2155"
    ''    NizUic(18, 1) = "MAV Cargo  "
    ''    NizUic(19, 0) = "2156"
    ''    NizUic(19, 1) = "ZSSK Cargo "
    ''    NizUic(20, 0) = "0057"
    ''    NizUic(20, 1) = "AZ         "
    ''    NizUic(21, 0) = "0058"
    ''    NizUic(21, 1) = "ARM        "
    ''    NizUic(22, 0) = "0059"
    ''    NizUic(22, 1) = "KRG        "
    ''    NizUic(23, 0) = "0060"
    ''    NizUic(23, 1) = "CIE        "
    ''    NizUic(24, 0) = "0062"
    ''    NizUic(24, 1) = "ZCG        "
    ''    NizUic(25, 0) = "0065"
    ''    NizUic(25, 1) = "CFARYM     "
    ''    NizUic(26, 0) = "0066"
    ''    NizUic(26, 1) = "TDZ        "
    ''    NizUic(27, 0) = "0067"
    ''    NizUic(27, 1) = "TRK        "
    ''    NizUic(28, 0) = "0068"
    ''    NizUic(28, 1) = "AAE        "
    ''    NizUic(29, 0) = "2370"
    ''    NizUic(29, 1) = "UK-F       "
    ''    NizUic(30, 0) = "1071"
    ''    NizUic(30, 1) = "Renfe      "
    ''    NizUic(31, 0) = "0072"
    ''    NizUic(31, 1) = "ZS         "
    ''    NizUic(32, 0) = "0073"
    ''    NizUic(32, 1) = "OSE        "
    ''    NizUic(33, 0) = "2174"
    ''    NizUic(33, 1) = "Green Cargo"
    ''    NizUic(34, 0) = "0075"
    ''    NizUic(34, 1) = "TCDD       "
    ''    NizUic(35, 0) = "2176"
    ''    NizUic(35, 1) = "CargoNET AS"
    ''    NizUic(36, 0) = "2178"
    ''    NizUic(36, 1) = "HZ Cargo   "
    ''    NizUic(37, 0) = "0079"
    ''    NizUic(37, 1) = "SZ         "
    ''    NizUic(38, 0) = "2180"
    ''    NizUic(38, 1) = "Railion Deu"
    ''    NizUic(39, 0) = "2181"
    ''    NizUic(39, 1) = "RCA        "
    ''    NizUic(40, 0) = "2182"
    ''    NizUic(40, 1) = "ELC        "
    ''    NizUic(41, 0) = "0083"
    ''    NizUic(41, 1) = "FS         "
    ''    NizUic(42, 0) = "2184"
    ''    NizUic(42, 1) = "Railion Ned"
    ''    NizUic(43, 0) = "2185"
    ''    NizUic(43, 1) = "SBB Cargo  "
    ''    NizUic(44, 0) = "2186"
    ''    NizUic(44, 1) = "Railion Den"
    ''    NizUic(45, 0) = "0087"
    ''    NizUic(45, 1) = "SNCF       "
    ''    NizUic(46, 0) = "0088"
    ''    NizUic(46, 1) = "SNCB       "
    ''    NizUic(47, 0) = "0090"
    ''    NizUic(47, 1) = "ENR        "
    ''    NizUic(48, 0) = "0091"
    ''    NizUic(48, 1) = "SNCFT      "
    ''    NizUic(49, 0) = "0092"
    ''    NizUic(49, 1) = "SNTF       "
    ''    NizUic(50, 0) = "0093"
    ''    NizUic(50, 1) = "ONCFM      "
    ''    NizUic(51, 0) = "0094"
    ''    NizUic(51, 1) = "CP         "
    ''    NizUic(52, 0) = "0095"
    ''    NizUic(52, 1) = "IR         "
    ''    NizUic(53, 0) = "0096"
    ''    NizUic(53, 1) = "RAI        "
    ''    NizUic(54, 0) = "0097"
    ''    NizUic(54, 1) = "CFS        "
    ''    NizUic(55, 0) = "0098"
    ''    NizUic(55, 1) = "CEL        "
    ''    NizUic(56, 0) = "0099"
    ''    NizUic(56, 1) = "IRR        "

    ''End Sub
    ''Private Sub PopuniR57a()

    ''    Dim ki, kj As Int16
    ''    Dim i_Pronasao As Int16 = 0
    ''    'Dim mUprava123 As String = "81"
    ''    Dim mNizUic As String

    ''    Me.rtb57a.Items.Clear()
    ''    Me.rtb57c.Items.Clear()

    ''    InitNizUic()

    ''    mNizUic = m_UicPrevozniPut
    ''    mNizUic = Microsoft.VisualBasic.Trim(mNizUic)

    ''    For kj = 1 To Len(mNizUic) Step 4
    ''        For ki = 0 To 56
    ''            If Microsoft.VisualBasic.Right(NizUic(ki, 0), 2) = Microsoft.VisualBasic.Mid(mNizUic, kj, 2) Then
    ''                i_Pronasao = 1
    ''                Me.rtb57a.Items.Add(NizUic(ki, 0) & " - " & NizUic(ki, 1))
    ''                Me.rtb57c.Items.Add("1")

    ''                Exit For
    ''            End If
    ''        Next
    ''    Next

    ''End Sub

    ''Private Sub Button17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Dim helpUic As New HelpForm
    ''    upit = "R9"
    ''    helpUic.ShowDialog()
    ''    Me.rtb9.AppendText(mizlazObject)
    ''    rtb9.Text = rtb9.Text + Environment.NewLine
    ''End Sub
    ''Private Sub tbBrojPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojPr.Leave
    ''    Me.tbBrojPr.BackColor = System.Drawing.Color.White
    ''    Me.tbBrojPr.ForeColor = System.Drawing.Color.Black
    ''    Me.tb59b.Text = Me.tbBrojPr.Text
    ''End Sub

    ''Private Sub tb49h_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    ''    If Me.tb49h.Text <> Nothing Then
    ''        Me.tb49a.Text = "14"
    ''    End If

    ''End Sub

    ''Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.tb20f.Clear()
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "help UIC"
    ''    upit = "UICPREL"
    ''    helpUic.ShowDialog()
    ''    Me.tb20f.Text = mIzlaz1 & " " & mIzlaz2
    ''    Me.btnUpis.Focus()

    ''End Sub

    ''Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
    ''    If IzborSaobracaja = "3" Then
    ''        Me.tbStanicaOtp.Focus()
    ''        Me.tbStanicaOtp.SelectionStart = 3
    ''    ElseIf IzborSaobracaja = "4" Then
    ''        Me.cbSmer2.Focus()
    ''    ElseIf IzborSaobracaja = "2" Then
    ''        Me.tbUpravaOtp.Focus()

    ''    End If
    ''End Sub

    ''Private Sub tb20f_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    ''    Me.tb49h.Text = Microsoft.VisualBasic.Left(tb20f.Text, 4)
    ''    Me.tb49a.Text = "14"
    ''End Sub

    ''Private Sub btnUpis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpis.Click

    ''    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
    ''    Button11_Click(Me, Nothing)

    ''    If ErrKontrola = "OK" Then
    ''        _OpenForm = "Upis"
    ''        mCarStanica = Me.tbCarinjenje.Text
    ''        mCarStanicaStart = Me.tbPolaznaCarina.Text

    ''        eInit_NewCim89()

    ''        If IzborSaobracaja = "4" Then
    ''            UpisTranzita()
    ''            Cursor.Current = System.Windows.Forms.Cursors.Default

    ''            If TipTranzita = "ulaz" Then
    ''                Me.ComboBox1.Focus()
    ''            Else
    ''                Close()
    ''            End If
    ''        Else
    ''            UpisExIm()
    ''            Cursor.Current = System.Windows.Forms.Cursors.Default

    ''            Me.ComboBox1.Focus()
    ''        End If
    ''    Else
    ''        Cursor.Current = System.Windows.Forms.Cursors.Default
    ''        dgError.Focus()
    ''    End If

    ''End Sub

    ''Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
    ''    dtKola.Clear()
    ''    dtNhm.Clear()
    ''    dtNaknade.Clear()

    ''    eInit_NewCim89()

    ''    mPrikazKalkulacije = "N"
    ''    mCarKnjiga = " "
    ''    mCarDoc = " "
    ''    mCarStanica = " "
    ''    mCarValuta = " "
    ''    mCarFaktura = 0
    ''    mCarPrPIB = " "
    ''    mCarPrNaziv = " "
    ''    mCarPrSediste = " "
    ''    mCarPrZemlja = " "

    ''    Close()

    ''End Sub
    ''Private Sub UpisTranzita()

    ''    Dim slogTrans As SqlTransaction
    ''    Dim rv As String
    ''    Dim drKola As DataRow
    ''    Dim drNhm As DataRow
    ''    Dim drDencane As DataRow
    ''    Dim drNaknade As DataRow
    ''    Dim mopRecID As Int32 = 0
    ''    Dim mUkljucujuci As String = ""
    ''    Dim mDoPrelaza As String = ""
    ''    Dim mValUrIsp, mValPouz, mValVR As String
    ''    Dim mPos1, mPos2, mPri1, mPri2 As Int32

    ''    If TipTranzita = "ulaz" Then
    ''        mUlEtiketa = CType(tbUlaznaNalepnica.Text, Int32)
    ''        If RecordAction = "N" Then
    ''            mIzEtiketa = CType(tbIzlaznaNalepnica.Text, Int32)
    ''        Else
    ''            mIzEtiketa = 0
    ''        End If
    ''    Else
    ''        mUlEtiketa = CType(tbUlaznaNalepnica.Text, Int32)
    ''        mIzEtiketa = CType(tbIzlaznaNalepnica.Text, Int32)
    ''    End If

    ''    mPrikazKalkulacije = "N"

    ''    '-------------------- Izjava -----------------------
    ''    mSifraIzjave = 0
    ''    If cbFrankoPrevoznina.Checked Then
    ''        mSifraIzjave = 1
    ''        mUkljucujuci = RTrim(tb20a.Text & tb20b.Text & tb20c.Text)
    ''        mDoPrelaza = Microsoft.VisualBasic.Left(Me.tb20f.Text, 4)
    ''    End If
    ''    If cbIncoterms.Checked Then
    ''        mSifraIzjave = 2
    ''    End If

    ''    '-- Kontrola pre upisa
    ''    If Me.cbVal26.Text = Nothing Then
    ''        mValVR = ""
    ''    Else
    ''        mValVR = Me.cbVal26.Text
    ''    End If
    ''    If Me.cbVal27.Text = Nothing Then
    ''        mValUrIsp = ""
    ''    Else
    ''        mValUrIsp = Me.cbVal27.Text
    ''    End If
    ''    If Me.cbVal28.Text = Nothing Then
    ''        mValPouz = ""
    ''    Else
    ''        mValPouz = Me.cbVal28.Text
    ''    End If

    ''    If Me.tb2.Text = Nothing Then
    ''        mPri1 = 0
    ''    Else
    ''        mPri1 = Me.tb2.Text
    ''    End If
    ''    If Me.tb3.Text = Nothing Then
    ''        mPri2 = 0
    ''    Else
    ''        mPri2 = Me.tb3.Text
    ''    End If
    ''    If Me.tb5.Text = Nothing Then
    ''        mPos1 = 0
    ''    Else
    ''        mPos1 = Me.tb5.Text
    ''    End If
    ''    If Me.tb6.Text = Nothing Then
    ''        mPos2 = 0
    ''    Else
    ''        mPos2 = Me.tb5.Text
    ''    End If

    ''    If kbBrojPr.Text = Nothing Then
    ''        kbBrojPr.Text = 0
    ''    End If

    ''    Dim strOtpBroj As String = CType(tbBrojOtp.Text, String) & CType(kbBrojOtp.Text, String)
    ''    Dim strPrBroj As String = CType(tbBrojPr.Text, String) & CType(kbBrojPr.Text, String)

    ''    '---------------------------------- Pristupa bazi -----------------------------------
    ''    Try
    ''        If DbVeza.State = ConnectionState.Closed Then
    ''            DbVeza.Open()
    ''        End If
    ''        slogTrans = DbVeza.BeginTransaction()

    ''        ' -- 1. Upis u SlogKalk ---------------------------------------------
    ''        If MasterAction = "New" Then
    ''            mAkcija = "New"
    ''        Else
    ''            mAkcija = "Upd"
    ''        End If

    ''        ' upis na prvim kolima kompletenog voza !!! 
    ''        If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "01" Then
    ''            If mVrstaObracuna = "CO" Then
    ''                If mTabelaCena = "210" Or mTabelaCena = "211" Then
    ''                    If CType(tbKolauVozu.Text, Int16) > 1 Then
    ''                        mPrevoznina = 0    'prevoznina se upisuje samo na prvim kolima
    ''                    End If
    ''                End If
    ''            End If
    ''        End If
    ''        If mBrojUg = "9933553" Or mBrojUg = "993354" Then
    ''            If CType(tbKolauVozu.Text, Int16) > 1 Then
    ''                mPrevoznina = 0    'prevoznina se upisuje samo na prvim kolima
    ''            End If
    ''        End If

    ''        Upis.UpisSlogKalk(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
    ''                tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, mObrGodina, mObrMesec, mStanica1, mUlEtiketa, _
    ''                Today(), mStanica2, mIzEtiketa, Today(), tbUpravaPr.Text, tbStanicaPr.Text, _
    ''                CType(strPrBroj, Int32), DateTimePicker2.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, mNajava, CType(mNajavaKola, Integer), _
    ''                mTarifa, mBrojUg, mPos1, mPos2, mPri1, mPri2, bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, _
    ''                mVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bTkm, sTkm, mSifraIzjave, mFrRacun, mUkljucujuci, _
    ''                mDoPrelaza, Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), mValUrIsp, CType(Me.tb27.Text, Decimal), _
    ''                mValPouz, CType(Me.tb28.Text, Decimal), mValVR, CType(Me.tb26.Text, Decimal), _
    ''                bValuta, (mPrevoznina + mSumaNak), 0, mPrevoznina, 0, mSumaNak, 0, mUserID, Today(), _
    ''                 mCarStanica, mCarStanicaStart, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
    ''                mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, _
    ''                mopRecID, rv)

    ''        If rv <> "" Then Throw New Exception(rv)
    ''        '-- End Upis u SlogKalk -----------------------------------------

    ''        '-- 2. Upis u SlogKola ---------------------------------------------  
    ''        If bVrstaPosiljke = "K" Then
    ''            Dim rbKola As Int16 = 1
    ''            Dim rbRoba As Int16 = 1

    ''            If dtKola.Rows.Count > 0 Then
    ''                For Each drKola In dtKola.Rows

    ''                    If MasterAction = "New" Then
    ''                        mAkcija = "New"
    ''                    Else
    ''                        If drKola("Action") = "I" Then
    ''                            mAkcija = "New"
    ''                        ElseIf drKola("Action") = "U" Then
    ''                            mAkcija = "Upd"
    ''                        ElseIf drKola("Action") = "D" Then
    ''                            mAkcija = "Del"
    ''                        End If
    ''                    End If

    ''                    Upis.UpisSlogKola(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, rbKola, _
    ''                                 drKola("IndBrojKola"), drKola("KB"), drKola("Uprava"), drKola("Vlasnik"), drKola("Serija"), _
    ''                                 drKola("Osovine"), drKola("Tara"), drKola("GrTov"), drKola("Stitna"), drKola("Tip"), drKola("Prevoznina"), _
    ''                                 drKola("Naknada"), drKola("ICF"), rv)
    ''                    '-- 2.1. Upis u SlogRoba ---------------------------------------------  
    ''                    For Each drNhm In dtNhm.Rows
    ''                        If drNhm("IndBrojKola") = drKola("IndBrojKola") Then
    ''                            If MasterAction = "New" Then
    ''                                mAkcija = "New"
    ''                            Else
    ''                                If drNhm("Action") = "I" Then
    ''                                    mAkcija = "New"
    ''                                ElseIf drNhm("Action") = "U" Then
    ''                                    mAkcija = "Upd"
    ''                                ElseIf drNhm("Action") = "D" Then
    ''                                    mAkcija = "Del"
    ''                                End If
    ''                            End If

    ''                            Upis.UpisSlogRobaDec(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
    ''                                                rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("MasaDec"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
    ''                                                drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
    ''                                                drNhm("UTIBuletin"), drNhm("UTIPlombe"), rv)

    ''                            rbRoba = rbRoba + 1
    ''                        End If
    ''                    Next
    ''                    '-- End Upis u SlogRoba -----------------------------------------  
    ''                    rbKola = rbKola + 1
    ''                    rbRoba = 1
    ''                Next
    ''            End If
    ''            '-- End Upis u SlogRoba -----------------------------------------  
    ''            If rv <> "" Then Throw New Exception(rv)
    ''        Else
    ''            '-- 2d. Upis u SlogDencane ------------------------------------------
    ''            Dim rbDencane As Int16 = 1
    ''            For Each drDencane In dtDencane.Rows
    ''                If MasterAction = "New" Then
    ''                    mAkcija = "New"
    ''                Else
    ''                    If drDencane("Action") = "I" Then
    ''                        mAkcija = "New"
    ''                    ElseIf drDencane("Action") = "U" Then
    ''                        mAkcija = "Upd"
    ''                    ElseIf drDencane("Action") = "D" Then
    ''                        mAkcija = "Del"
    ''                    End If
    ''                End If

    ''                Upis.UpisSlogDencane(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
    ''                            tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
    ''                            rbDencane, drDencane("SMasa"), drDencane("RMasa"), _
    ''                            drDencane("Tarifa"), drDencane("Tip"), drDencane("Komada"), _
    ''                            drDencane("Iznos"), drDencane("Valuta"), rv)

    ''                rbDencane = rbDencane + 1
    ''            Next
    ''            If rv <> "" Then Throw New Exception(rv)
    ''        End If
    ''        '-- 3. Upis u SlogNaknada ------------------------------------------
    ''        Dim rbNaknade As Int16 = 1
    ''        If dtNaknade.Rows.Count > 0 Then
    ''            For Each drNaknade In dtNaknade.Rows
    ''                If MasterAction = "New" Then
    ''                    mAkcija = "New"
    ''                Else
    ''                    If drNaknade("Action") = "I" Then
    ''                        mAkcija = "New"
    ''                    ElseIf drNaknade("Action") = "U" Then
    ''                        mAkcija = "Upd"
    ''                    ElseIf drNaknade("Action") = "D" Then
    ''                        mAkcija = "Del"
    ''                    End If
    ''                End If

    ''                Upis.UpisSlogNaknada(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
    ''                      rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
    ''                     drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

    ''                rbNaknade = rbNaknade + 1
    ''            Next
    ''        End If
    ''        '-- End Upis u SlogNaknada --------------------------------------

    ''        If rv = "" Then
    ''            slogTrans.Commit()
    ''            Me.Text = " ::: Uspesan upis! :::"
    ''        Else
    ''            MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
    ''            slogTrans.Rollback()
    ''        End If
    ''        '-- Zavrsetak upisa u Slog*

    ''        '-- Azuriranje tranzitnih nalepnica ----------------------------------------
    ''        'If TipTranzita = "ulaz" Then

    ''        If DbVeza.State = ConnectionState.Closed Then
    ''            DbVeza.Open()
    ''        End If
    ''        slogTrans = DbVeza.BeginTransaction()

    ''        Try
    ''            Dim ulTrzNalepnica As Int32
    ''            Dim izTrzNalepnica As Int32
    ''            Dim _Stanica As String

    ''            rv = ""

    ''            mAkcija = "Upd"

    ''            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = mStanica1 Then 'ulaz
    ''                ulTrzNalepnica = mUlEtiketa
    ''                izTrzNalepnica = mIzEtiketa
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = mStanica2 Then 'izlaz
    ''                izTrzNalepnica = mIzEtiketa
    ''                ulTrzNalepnica = mUlEtiketa
    ''            End If

    ''            If TipTranzita = "ulaz" Then
    ''                Upis.UpisTrzNalepnice(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), ulTrzNalepnica, 0, rv)
    ''            Else
    ''                Upis.UpisTrzNalepnice(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), 0, izTrzNalepnica, rv)
    ''            End If

    ''            If rv = "" Then
    ''                slogTrans.Commit()
    ''                '''ne pravi xml za tranzit do daljnjeg
    ''            Else
    ''                MsgBox(rv)
    ''                slogTrans.Rollback()
    ''            End If
    ''        Catch ex As Exception
    ''            rv = ex.Message
    ''            MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''        Catch sqlex As SqlException
    ''            MsgBox(sqlex.Message)
    ''        Finally
    ''            DbVeza.Close()
    ''        End Try
    ''        'End If
    ''        '-- END azuriranje tranzitnih nalepnica --------------------------------

    ''        '-- Ovde dolazi deo za podnosenje eJCI, sada iskljuceno
    ''        '-- End

    ''        '-- Priprema za sledeci unos ------------------------------------------------------------------

    ''        'mUlEtiketa = 0
    ''        'mIzEtiketa = 0

    ''        Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
    ''        Me.tbStanicaPr.BackColor = System.Drawing.Color.White

    ''        '-- Zbog upisivanja prevoznine
    ''        If Microsoft.VisualBasic.Right(Me.tbUgovor.Text, 2) = "01" Or Me.tbUgovor.Text = "993353" Or Me.tbUgovor.Text = "993354" Then
    ''            If tmpUgovor = Me.tbUgovor.Text Or CType(tbKolauVozu.Text, Int16) = 1 Then
    ''                'vazno: prethodni upis u bazu za vozove-prevoznina samo na prvim kolima voza!!
    ''                tbKolauVozu.Text = CType(tbKolauVozu.Text, Int16) + 1
    ''                'Me.ComboBox1.Focus()
    ''            End If
    ''        End If

    ''        If TipTranzita = "ulaz" Then
    ''            Me.tbUlaznaNalepnica.Text = CType(Me.tbUlaznaNalepnica.Text, Int32) + 1
    ''        Else
    ''            Me.tbIzlaznaNalepnica.Text = CType(Me.tbIzlaznaNalepnica.Text, Int32) + 1
    ''        End If

    ''        dtKola.Clear()
    ''        dtNhm.Clear()
    ''        dtNaknade.Clear()
    ''        ClearDoc()

    ''        tmpUgovor = Me.tbUgovor.Text
    ''        Me.ComboBox1.Focus()
    ''    Catch ex As Exception
    ''        rv = ex.Message
    ''        MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''    Catch sqlex As SqlException
    ''        MsgBox(sqlex.Message)
    ''    Finally
    ''        DbVeza.Close()
    ''    End Try

    ''End Sub
    ''Private Sub UpisExIm()
    ''    Dim slogTrans As SqlTransaction
    ''    Dim rv As String
    ''    Dim drKola As DataRow
    ''    Dim drNhm As DataRow
    ''    Dim drDencane As DataRow
    ''    Dim drNaknade As DataRow
    ''    Dim mopRecID As Int32 = 0
    ''    Dim mUkljucujuci As String = ""
    ''    Dim mDoPrelaza As String = ""
    ''    Dim mValUrIsp, mValPouz, mValVR As String
    ''    Dim mPos1, mPos2, mPri1, mPri2 As Int32
    ''    Dim _prazanString As String = " "

    ''    mPrikazKalkulacije = "N"
    ''    mIzEtiketa = 0
    ''    mUlEtiketa = 0
    ''    If Me.tbBrojPr.Text = Nothing Then
    ''        mPrispece = 0
    ''    Else
    ''        mPrispece = CType(tbBrojPr.Text, Int32)
    ''    End If

    ''    '-------------------- Izjava -----------------------
    ''    mSifraIzjave = 0
    ''    If cbFrankoPrevoznina.Checked Then
    ''        mSifraIzjave = 1
    ''        mUkljucujuci = RTrim(tb20a.Text & tb20b.Text & tb20c.Text)
    ''        mDoPrelaza = Microsoft.VisualBasic.Left(Me.tb20f.Text, 4)
    ''    End If
    ''    If cbIncoterms.Checked Then
    ''        mSifraIzjave = 2
    ''    End If

    ''    If mTarifa = "36" Then
    ''        mBrojUg = ""
    ''    End If

    ''    '-- Kontrola pre upisa
    ''    If Me.cbVal26.Text = Nothing Then
    ''        mValVR = ""
    ''    Else
    ''        mValVR = Me.cbVal26.Text
    ''    End If
    ''    If Me.cbVal27.Text = Nothing Then
    ''        mValUrIsp = ""
    ''    Else
    ''        mValUrIsp = Me.cbVal27.Text
    ''    End If
    ''    If Me.cbVal28.Text = Nothing Then
    ''        mValPouz = ""
    ''    Else
    ''        mValPouz = Me.cbVal28.Text
    ''    End If

    ''    If Me.tb2.Text = Nothing Then
    ''        mPri1 = 0
    ''    Else
    ''        mPri1 = Me.tb2.Text
    ''    End If
    ''    If Me.tb3.Text = Nothing Then
    ''        mPri2 = 0
    ''    Else
    ''        mPri2 = Me.tb3.Text
    ''    End If
    ''    If Me.tb5.Text = Nothing Then
    ''        mPos1 = 0
    ''    Else
    ''        mPos1 = Me.tb5.Text
    ''    End If
    ''    If Me.tb6.Text = Nothing Then
    ''        mPos2 = 0
    ''    Else
    ''        mPos2 = Me.tb5.Text
    ''    End If

    ''    If kbBrojPr.Text = Nothing Then
    ''        kbBrojPr.Text = 0
    ''    End If

    ''    Dim strOtpBroj As String = CType(tbBrojOtp.Text, String) & CType(kbBrojOtp.Text, String)
    ''    Dim strPrBroj As String = CType(tbBrojPr.Text, String) & CType(kbBrojPr.Text, String)

    ''    '------------------------- pristupa bazi -----------------------------------------------------
    ''    Try
    ''        If DbVeza.State = ConnectionState.Closed Then
    ''            DbVeza.Open()
    ''        End If
    ''        slogTrans = DbVeza.BeginTransaction()

    ''        '--------------------------------------- Upis u SlogKalk ---------------------------------------------
    ''        If MasterAction = "New" Then
    ''            mAkcija = "New"
    ''        Else
    ''            mAkcija = "Upd"
    ''        End If
    ''        '----------------------------------- upis na prvim kolima kompletenog voza !!! --------------------
    ''        If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "01" Then
    ''            If mVrstaObracuna = "CO" Then
    ''                If mTabelaCena = "210" Or mTabelaCena = "211" Then
    ''                    If CType(tbKolauVozu.Text, Int16) > 1 Then
    ''                        mPrevoznina = 0    'prevoznina se upisuje samo na prvim kolima
    ''                    End If
    ''                End If
    ''            End If
    ''        End If
    ''        '--------------------------------------------------------------------------------------------------

    ''        If IzborSaobracaja = 2 Then
    ''            Upis.UpisSlogKalk(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
    ''                    tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, mObrGodina, mObrMesec, mStanica1, mUlEtiketa, _
    ''                    Today(), _prazanString, mIzEtiketa, Today(), tbUpravaPr.Text, tbStanicaPr.Text, _
    ''                    CType(strPrBroj, Int32), DateTimePicker2.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, mNajava, 0, _
    ''                    mTarifa, mBrojUg, mPos1, mPos2, mPri1, mPri2, bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, _
    ''                    mVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bTkm, sTkm, mSifraIzjave, mFrRacun, mUkljucujuci, _
    ''                    mDoPrelaza, Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), mValUrIsp, CType(Me.tb27.Text, Decimal), _
    ''                    mValPouz, CType(Me.tb28.Text, Decimal), mValVR, CType(Me.tb26.Text, Decimal), _
    ''                    bValuta, (mPrevoznina + mSumaNak), 0, mPrevoznina, 0, mSumaNak, 0, mUserID, Today(), _
    ''                    mCarStanica, mCarStanicaStart, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
    ''                    mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, _
    ''                    mopRecID, rv)
    ''        ElseIf IzborSaobracaja = 3 Then
    ''            Upis.UpisSlogKalkIzvoz(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
    ''                    tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, mObrGodina, mObrMesec, "0", mUlEtiketa, _
    ''                    Today(), mStanica2, mIzEtiketa, Today(), tbUpravaPr.Text, tbStanicaPr.Text, _
    ''                    CType(strPrBroj, Int32), DateTimePicker2.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, mNajava, 0, _
    ''                    mTarifa, mBrojUg, mPos1, mPos2, mPri1, mPri2, bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, _
    ''                    mVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bTkm, sTkm, mSifraIzjave, mFrRacun, mUkljucujuci, _
    ''                    mDoPrelaza, Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), mValUrIsp, CType(Me.tb27.Text, Decimal), _
    ''                    mValPouz, CType(Me.tb28.Text, Decimal), mValVR, CType(Me.tb26.Text, Decimal), _
    ''                    bValuta, (mPrevoznina + mSumaNak), 0, mPrevoznina, 0, mSumaNak, 0, mUserID, Today(), _
    ''                    mCarStanica, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
    ''                    mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, _
    ''                    mopRecID, rv)
    ''        End If
    ''        If rv <> "" Then Throw New Exception(rv)
    ''        '-- End Upis u SlogKalk -----------------------------------------

    ''        '-- 2. Upis u SlogKola -------------------------------------------  
    ''        If bVrstaPosiljke = "K" Then
    ''            Dim rbKola As Int16 = 1
    ''            Dim rbRoba As Int16 = 1

    ''            If dtKola.Rows.Count > 0 Then
    ''                For Each drKola In dtKola.Rows

    ''                    If MasterAction = "New" Then
    ''                        mAkcija = "New"
    ''                    Else
    ''                        If drKola("Action") = "I" Then
    ''                            mAkcija = "New"
    ''                        ElseIf drKola("Action") = "U" Then
    ''                            mAkcija = "Upd"
    ''                        ElseIf drKola("Action") = "D" Then
    ''                            mAkcija = "Del"
    ''                        End If
    ''                    End If


    ''                    Upis.UpisSlogKola(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, rbKola, _
    ''                                 drKola("IndBrojKola"), drKola("KB"), drKola("Uprava"), drKola("Vlasnik"), drKola("Serija"), _
    ''                                 drKola("Osovine"), drKola("Tara"), drKola("GrTov"), drKola("Stitna"), drKola("Tip"), drKola("Prevoznina"), _
    ''                                 drKola("Naknada"), drKola("ICF"), rv)

    ''                    '-- 2.1 Upis u SlogRoba ---------------------------------------------  
    ''                    For Each drNhm In dtNhm.Rows
    ''                        If drNhm("IndBrojKola") = drKola("IndBrojKola") Then
    ''                            If MasterAction = "New" Then
    ''                                mAkcija = "New"
    ''                            Else
    ''                                If drNhm("Action") = "I" Then
    ''                                    mAkcija = "New"
    ''                                ElseIf drNhm("Action") = "U" Then
    ''                                    mAkcija = "Upd"
    ''                                ElseIf drNhm("Action") = "D" Then
    ''                                    mAkcija = "Del"
    ''                                End If
    ''                            End If

    ''                            Upis.UpisSlogRobaDec(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
    ''                                         rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("MasaDec"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
    ''                                         drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
    ''                                         drNhm("UTIBuletin"), drNhm("UTIPlombe"), rv)

    ''                            rbRoba = rbRoba + 1
    ''                        End If
    ''                    Next
    ''                    '-- End Upis u SlogRoba -----------------------------------------  
    ''                    rbKola = rbKola + 1
    ''                    rbRoba = 1
    ''                Next
    ''            End If
    ''            If rv <> "" Then Throw New Exception(rv)
    ''        Else
    ''            '-- 2d. Upis u SlogDencane ------------------------------------------
    ''            Dim rbDencane As Int16 = 1
    ''            For Each drDencane In dtDencane.Rows
    ''                If MasterAction = "New" Then
    ''                    mAkcija = "New"
    ''                Else
    ''                    If drDencane("Action") = "I" Then
    ''                        mAkcija = "New"
    ''                    ElseIf drDencane("Action") = "U" Then
    ''                        mAkcija = "Upd"
    ''                    ElseIf drDencane("Action") = "D" Then
    ''                        mAkcija = "Del"
    ''                    End If
    ''                End If

    ''                Upis.UpisSlogDencane(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
    ''                            tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
    ''                            rbDencane, drDencane("SMasa"), drDencane("RMasa"), _
    ''                            drDencane("Tarifa"), drDencane("Tip"), drDencane("Komada"), _
    ''                            drDencane("Iznos"), drDencane("Valuta"), rv)

    ''                rbDencane = rbDencane + 1
    ''            Next
    ''            If rv <> "" Then Throw New Exception(rv)
    ''        End If

    ''        '-- 3. Upis u SlogNaknada ------------------------------------------
    ''        Dim rbNaknade As Int16 = 1
    ''        If dtNaknade.Rows.Count > 0 Then
    ''            For Each drNaknade In dtNaknade.Rows
    ''                If MasterAction = "New" Then
    ''                    mAkcija = "New"
    ''                Else
    ''                    If drNaknade("Action") = "I" Then
    ''                        mAkcija = "New"
    ''                    ElseIf drNaknade("Action") = "U" Then
    ''                        mAkcija = "Upd"
    ''                    ElseIf drNaknade("Action") = "D" Then
    ''                        mAkcija = "Del"
    ''                    End If
    ''                End If

    ''                Upis.UpisSlogNaknada(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
    ''                                rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
    ''                                drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

    ''                rbNaknade = rbNaknade + 1
    ''            Next
    ''        End If
    ''        '-- End Upis u SlogNaknada --------------------------------------

    ''        If rv = "" Then
    ''            slogTrans.Commit()
    ''            Me.Text = " ::: Uspesan upis! :::"

    ''            If IzborSaobracaja = "3" And eCimDa = "D" Then
    ''                KreirajFbXml()
    ''            End If

    ''        Else
    ''            MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
    ''            slogTrans.Rollback()
    ''        End If
    ''        '-- Zavrsetak upisa u Slog*

    ''        'bilo eJCI
    ''        'end

    ''        '-- 2. Obrisati prethodni unos sem broja voza --------------------------------------------------------
    ''        mUlEtiketa = 0
    ''        mIzEtiketa = 0

    ''        If Microsoft.VisualBasic.Left(Me.ComboBox2.Text, 1) = "3" Then
    ''            If tmpUgovor = Me.tbUgovor.Text Then
    ''                'vazno: prethodni upis u bazu za vozove-prevoznina samo na prvim kolima voza!!
    ''                tbKolauVozu.Text = CType(tbKolauVozu.Text, Int16) + 1
    ''            Else
    ''                tbKolauVozu.Text = 1
    ''            End If
    ''        Else
    ''            tbKolauVozu.Text = 1
    ''        End If
    ''        dtKola.Clear()
    ''        dtNhm.Clear()
    ''        dtNaknade.Clear()
    ''        ClearDoc()

    ''        tmpUgovor = Me.tbUgovor.Text
    ''        Me.ComboBox1.Focus()
    ''    Catch ex As Exception
    ''        rv = ex.Message
    ''        MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''    Catch sqlex As SqlException
    ''        MsgBox(sqlex.Message)
    ''    Finally
    ''        DbVeza.Close()
    ''    End Try

    ''End Sub

    ''Private Sub tbUgovor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.Leave
    ''    mUgovorZaUporedjenje = Me.tbUgovor.Text

    ''End Sub
    ''Private Sub ClearDoc()

    ''    tbKolauVozu.Text = "1"
    ''    'tbUgovor.Text = ""
    ''    'Me.ComboBox1.SelectedIndex = -1
    ''    'Me.ComboBox2.SelectedIndex = -1

    ''    Me.tbBrojOtp.Text = ""
    ''    Me.kbBrojOtp.Text = ""

    ''    If IzborSaobracaja = "3" Then

    ''    Else
    ''        Me.tb1a.Text = ""
    ''        Me.tb1b.Text = ""
    ''        Me.tb1b1.Text = ""
    ''        Me.tb1b2.Text = ""
    ''        Me.tb4a.Text = ""
    ''        Me.tb4b.Text = ""
    ''        Me.tb4b1.Text = ""
    ''        Me.tb4b2.Text = ""

    ''        Me.tb12.Text = ""
    ''        Me.tb10a.Text = ""
    ''        Me.tb10b.Text = ""
    ''        Me.tb13.Text = ""
    ''        Me.tb14a.Text = ""
    ''        Me.tb14b.Text = ""
    ''        Me.tb15.Text = ""
    ''        Me.tb16a.Text = ""
    ''        Me.tb16b.Text = ""
    ''        Me.tb17.Text = ""
    ''        Me.tbCarinjenje.Text = ""
    ''        Me.lblCarinarnica.Text = ""

    ''    End If

    ''    'Me.tbPolaznaCarina.Text = ""

    ''    Me.rtb9.Text = ""
    ''    Me.rtb21.Text = ""
    ''    Me.tb51a.Text = ""
    ''    Me.tb51b.Text = ""
    ''    Me.tb51c.Text = ""
    ''    Me.rtb55.Text = ""
    ''    Me.rtb57a.Text = ""
    ''    Me.rtb57b.Text = ""
    ''    Me.rtb57c.Text = ""
    ''    Me.tb29a.Text = ""
    ''    Me.tb29b.Text = ""
    ''    Me.tb52a.Text = ""
    ''    Me.tb52b.Text = ""
    ''    Me.tb52c.Text = ""
    ''    Me.tb52d.Text = ""
    ''    Me.tb52e.Text = ""
    ''    Me.TB58a1.Text = ""
    ''    Me.TB58a2.Text = ""
    ''    Me.tb59a.Text = ""
    ''    Me.tb59b.Text = ""
    ''    Me.tbIBK.Text = ""
    ''    Me.tb24.Text = ""
    ''    Me.tb25.Text = ""

    ''    Me.tbA70a1.Text = ""
    ''    Me.tbA70b1.Text = ""
    ''    Me.tbA70a2.Text = ""
    ''    Me.tbA70b2.Text = ""
    ''    Me.tbA72d.Text = ""
    ''    Me.combo73A.SelectedIndex = 0
    ''    Me.tbA74d1.Text = ""
    ''    Me.tbA75.Text = ""
    ''    Me.tbA76.Text = ""
    ''    Me.tbA77.Text = ""
    ''    Me.tbA78.Text = ""

    ''    Me.tbA79a1.Text = ""
    ''    Me.tbA79b1.Text = ""
    ''    Me.tbA79a2.Text = ""
    ''    Me.tbA79b2.Text = ""
    ''    Me.tbA79a3.Text = ""
    ''    Me.tbA79b3.Text = ""


    ''    Me.tbCarinjenje.Text = ""

    ''End Sub
    ''Private Sub KreirajFbXml()

    ''    Dim Doc As New XmlDocument
    ''    Dim newAtt As XmlAttribute
    ''    Dim TempNode As XmlElement
    ''    Dim fb_godina As String = Today.Year().ToString

    ''    Dim RcaFbStr1_1 As String = "ZS"

    ''    Dim RcaFbStr1_2 As String = "0_" '"0_ZS_"
    ''    Dim RcaFbStr1_2_1 As String = Me.tbUpravaOtp.Text & "_"
    ''    Dim RcaFbStr1_2_2 As String = Today.Now.Year & Today.Now.Month & Today.Now.Day & "_"
    ''    Dim RcaFbStr1_2_3 As String = Today.Now.Hour & Today.Now.Minute & "_"  '& "_EVU_WLV_OUT_" iskljuceno zbog MAVC
    ''    Dim RcaFbStr1_2_4 As String = Me.tbBrojOtp.Text.ToString & Me.kbBrojOtp.Text.ToString & ".xml"
    ''    RcaFbStr1_2 = RcaFbStr1_2 & RcaFbStr1_2_1 & RcaFbStr1_2_2 & RcaFbStr1_2_3 & RcaFbStr1_2_4
    ''    SourceFile = RcaFbStr1_2

    ''    Dim RcaFbStr1_3 As String = "fb0413"
    ''    Dim RcaFbStr1_4 As String = "fb0413.xsd"

    ''    Dim RcaFbStr2_1 As String = "O"
    ''    Dim RcaFbStr2_2 As String = Today.Now.Year & Today.Now.Month & Today.Now.Day & Today.Now.Hour & Today.Now.Minute & Today.Now.Second & Today.Now.Millisecond


    ''    Dim tempMonth As String = Today.Now.Month
    ''    If Len(tempMonth) = 1 Then
    ''        tempMonth = "0" & tempMonth
    ''    End If
    ''    Dim tempDay As String = Today.Now.Day
    ''    If Len(tempDay) = 1 Then
    ''        tempDay = "0" & tempDay
    ''    End If
    ''    Dim tempYear As String = Today.Now.Year


    ''    Dim tempHour As String = Today.Now.Hour
    ''    If Len(tempHour) = 1 Then
    ''        tempHour = "0" & tempHour
    ''    End If
    ''    Dim tempMinute As String = Today.Now.Minute
    ''    If Len(tempMinute) = 1 Then
    ''        tempMinute = "0" & tempMinute
    ''    End If
    ''    Dim tempSeconds As String = Today.Now.Second
    ''    If Len(tempSeconds) = 1 Then
    ''        tempSeconds = "0" & tempSeconds
    ''    End If

    ''    'Ispravka!!! treba da bude: time="01.12.2008 13:31:33" ok
    ''    Dim RcaFbStr2_3 As String = tempDay & "." & tempMonth & "." & tempYear & " " & tempHour & ":" & tempMinute & ":" & tempSeconds

    ''    Dim RcaFbStr3_1a As String = "CIM"
    ''    Dim RcaFbStr3_1b As String = "0"
    ''    Dim RcaFbStr3_1c As String = "1"

    ''    Dim RcaFbStr3_2a As String = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2) '"72" -otpravljanje
    ''    Dim RcaFbStr3_2b As String = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5) & Me.TextBox1.Text  '"234500"
    ''    Dim RcaFbStr3_2c As String = RTrim(Me.tb16a.Text) ' "SUBOTICA"
    ''    Dim RcaFbStr3_2d As String = Me.tbUpravaOtp.Text '"0072"
    ''    Dim RcaFbStr3_2e As Int32 = Me.tbBrojOtp.Text & Me.kbBrojOtp.Text '524322

    ''    Dim RcaFbStr3_3a As String = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2) ' "72" preuzimanje na prevoz
    ''    Dim RcaFbStr3_3b As String = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5) & Me.TextBox1.Text ' "234500"
    ''    Dim RcaFbStr3_3c As String = RTrim(Me.tb16a.Text)
    ''    Dim RcaFbStr3_3d As String = Me.tbUpravaOtp.Text '"0072"
    ''    Dim RcaFbStr3_3e As String = Me.tb16d.Text & "." & _
    ''                                 Me.tb16c.Text & "." & _
    ''                                 fb_godina & " " & _
    ''                                 Me.tb16e.Text
    ''    'dan-mesec-godina-cas "11.04.2008 00"  '[ P16. PREUZIMANJE NA PREVOZ ]

    ''    Dim RcaFbStr3_4a As String = Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) '"81"
    ''    Dim RcaFbStr3_4b As String = Microsoft.VisualBasic.Right(Me.tbStanicaPr.Text, 5) & Me.TextBox2.Text '"037143"
    ''    Dim RcaFbStr3_4c As String = RTrim(Me.tb10a.Text) '"FRANTSCHACH-ST.GERTR"

    ''    Dim RcaFbStr3_6a As String = "absender"
    ''    Dim RcaFbStr3_6b As Int32 = Me.tb2.Text '100078
    ''    Dim RcaFbStr3_6c As String = RTrim(Me.tb1a.Text) 'naziv
    ''    Dim RcaFbStr3_6d As String = RTrim(Me.tb1b.Text) 'adresa
    ''    Dim RcaFbStr3_6e As String = " " 'postcode ne do daljnjeg
    ''    Dim RcaFbStr3_6f As String = RTrim(Me.tb1b1.Text) 'grad
    ''    Dim RcaFbStr3_6g As String = Me.tb1b2.Text 'zemlja

    ''    Dim RcaFbStr3_7a As String = "empfaenger"
    ''    Dim RcaFbStr3_7b As Int32 = Me.tb2.Text '100078
    ''    Dim RcaFbStr3_7c As String = RTrim(Me.tb4a.Text) 'naziv
    ''    Dim RcaFbStr3_7d As String = RTrim(Me.tb4b.Text) 'adresa
    ''    Dim RcaFbStr3_7e As String = " " 'postcode ne do daljnjeg
    ''    Dim RcaFbStr3_7f As String = RTrim(Me.tb4b1.Text) 'grad
    ''    Dim RcaFbStr3_7g As String = Me.tb4b2.Text 'zemlja

    ''    Dim RcaFbStr3_13b As String = Me.tb14b.Text '"000036"
    ''    Dim RcaFbStr4_8a As String = Me.tb24.Text '"992200" ' [ NHM ]
    ''    Dim RcaFbStr4_8b As String = RTrim(jci_NazivRobe) '"KOLA KORISN.PREVOZA VISEOSOVNA,PRAZNA" ' [ NHM NAZIV ]

    ''    'trazi broj granicnih prelaza
    ''    For i As Integer = 0 To 9
    ''        For j As Integer = 0 To 1
    ''            If NizR50(i, j) = Nothing Then
    ''                NumNizR50 = i
    ''                Exit For
    ''            End If
    ''        Next
    ''        If NumNizR50 > 0 Then
    ''            Exit For
    ''        End If
    ''    Next

    ''    'so far so good
    ''    'podaci po kolima!
    ''    ''''''Dim RcaFbStr4_2 As Int32 = 30000 ' [ BRUTO MASA ]
    ''    ''''''Dim RcaFbStr4_3 As Int32 = 30000 ' [ TARA KOLA ]
    ''    ''''''Dim RcaFbStr4_5 As Int32 = 4 ' [ BROJ OSOVINA ]
    ''    ''''''Dim RcaFbStr4_7 As Decimal = 25.0 ' [ GRANICA TOVARENJA ]
    ''    ''''''Dim RcaFbStr4_8c As Int32 = 30000 ' [ STVARNA MASA ]
    ''    ''''''Dim RcaFbStr5_4 As Int32 = 30000 ' [ RACUNSKA MASA ]

    ''    '+========================================================= 1. frachtbriefe ===============================================================
    ''    Dim dec As XmlDeclaration = Doc.CreateXmlDeclaration("1.0", "ISO-8859-1", "yes")
    ''    Doc.AppendChild(dec)

    ''    Dim DocRoot As XmlElement = Doc.CreateElement("frachtbriefe")
    ''    newAtt = Doc.CreateAttribute("absender")
    ''    newAtt.Value = RcaFbStr1_1
    ''    DocRoot.Attributes.Append(newAtt)

    ''    newAtt = Doc.CreateAttribute("original_filename")
    ''    newAtt.Value = RcaFbStr1_2
    ''    DocRoot.Attributes.Append(newAtt)

    ''    newAtt = Doc.CreateAttribute("version_xsd")
    ''    newAtt.Value = RcaFbStr1_3
    ''    DocRoot.Attributes.Append(newAtt)

    ''    newAtt = Doc.CreateAttribute("xsi:noNamespaceSchemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
    ''    newAtt.Value = RcaFbStr1_4
    ''    DocRoot.SetAttributeNode(newAtt)

    ''    Doc.AppendChild(DocRoot)

    ''    '+========================================================= 2. frachtbrief ===============================================================
    ''    Dim frachtbrief As XmlNode = Doc.CreateElement("frachtbrief")
    ''    newAtt = Doc.CreateAttribute("osu_kennzeichen")
    ''    newAtt.Value = RcaFbStr2_1
    ''    frachtbrief.Attributes.Append(newAtt)

    ''    newAtt = Doc.CreateAttribute("referenznummer")
    ''    newAtt.Value = RcaFbStr2_2
    ''    frachtbrief.Attributes.Append(newAtt)

    ''    newAtt = Doc.CreateAttribute("time")
    ''    newAtt.Value = RcaFbStr2_3
    ''    frachtbrief.Attributes.Append(newAtt)

    ''    DocRoot.AppendChild(frachtbrief)

    ''    '========================================================= 3. sendungskopf ===============================================================
    ''    Dim sendungskopf As XmlNode = Doc.CreateElement("sendungskopf")
    ''    frachtbrief.AppendChild(sendungskopf)

    ''    '+- 3_1a. sendungsart
    ''    Dim sendungsart As XmlNode = Doc.CreateElement("sendungsart")
    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = RcaFbStr3_1a
    ''    sendungsart.Attributes.Append(newAtt)

    ''    sendungskopf.AppendChild(sendungsart)

    ''    '+- 3_1b. retourfrachtbrief
    ''    Dim retourfrachtbrief As XmlNode = Doc.CreateElement("retourfrachtbrief")

    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = RcaFbStr3_1b
    ''    retourfrachtbrief.Attributes.Append(newAtt)

    ''    sendungskopf.AppendChild(retourfrachtbrief)

    ''    '+- 3_1c. originalfrachtbrief
    ''    Dim originalfrachtbrief As XmlNode = Doc.CreateElement("originalfrachtbrief")
    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = RcaFbStr3_1c
    ''    originalfrachtbrief.Attributes.Append(newAtt)

    ''    sendungskopf.AppendChild(originalfrachtbrief)

    ''    '+----------------- 3_2. versandbhf [ P82. OTPRAVLJANJE ]
    ''    Dim versandbhf As XmlNode = Doc.CreateElement("versandbhf")
    ''    sendungskopf.AppendChild(versandbhf)

    ''    '+------- 3_2a. vw
    ''    Dim vw As XmlNode = Doc.CreateElement("vw")
    ''    vw.InnerText = RcaFbStr3_2a
    ''    versandbhf.AppendChild(vw)

    ''    '+------- 3_2b. bhfnr
    ''    Dim bhfnr As XmlNode = Doc.CreateElement("bhfnr")
    ''    bhfnr.InnerText = RcaFbStr3_2b
    ''    versandbhf.AppendChild(bhfnr)

    ''    '+------- 3_2c. bhfnr
    ''    Dim bhfname As XmlNode = Doc.CreateElement("bhfname")
    ''    bhfname.InnerText = RcaFbStr3_2c
    ''    versandbhf.AppendChild(bhfname)

    ''    '+------- 3_2d. evu
    ''    Dim evu As XmlNode = Doc.CreateElement("evu")
    ''    evu.InnerText = RcaFbStr3_2d
    ''    versandbhf.AppendChild(evu)

    ''    '+------- 3_2e. versandnr
    ''    Dim versandnr As XmlNode = Doc.CreateElement("versandnr")
    ''    versandnr.InnerText = RcaFbStr3_2e.ToString
    ''    versandbhf.AppendChild(versandnr)

    ''    '+----------------- 3_3. uebernahmestelle [P16. PREUZIMANJE NA PREVOZ]
    ''    Dim uebernahmestelle As XmlNode = Doc.CreateElement("uebernahmestelle")
    ''    sendungskopf.AppendChild(uebernahmestelle)

    ''    '+------- 3_3a. vw
    ''    vw = Doc.CreateElement("vw")
    ''    vw.InnerText = RcaFbStr3_3a
    ''    uebernahmestelle.AppendChild(vw)

    ''    '+------- 3_3b. bhfnr
    ''    bhfnr = Doc.CreateElement("bhfnr")
    ''    bhfnr.InnerText = RcaFbStr3_3b
    ''    uebernahmestelle.AppendChild(bhfnr)

    ''    '+------- 3_3c. bhfnr
    ''    bhfname = Doc.CreateElement("bhfname")
    ''    bhfname.InnerText = RcaFbStr3_3c
    ''    uebernahmestelle.AppendChild(bhfname)

    ''    '+------- 3_3d. evu
    ''    evu = Doc.CreateElement("uebernahmeort_name")
    ''    evu.InnerText = RcaFbStr3_3c
    ''    uebernahmestelle.AppendChild(evu)

    ''    '+------- 3_3e. versandnr
    ''    versandnr = Doc.CreateElement("uebernahmezeitpunkt")
    ''    versandnr.InnerText = RcaFbStr3_3e
    ''    uebernahmestelle.AppendChild(versandnr)

    ''    '+----------------- 3_4. empfangsbhf [P12. UPUTNA STANICA]
    ''    Dim empfangsbhf As XmlNode = Doc.CreateElement("empfangsbhf")
    ''    sendungskopf.AppendChild(empfangsbhf)

    ''    '+------- 3_4a. vw
    ''    vw = Doc.CreateElement("vw")
    ''    vw.InnerText = RcaFbStr3_4a
    ''    empfangsbhf.AppendChild(vw)

    ''    '+------- 3_4b. bhfnr
    ''    bhfnr = Doc.CreateElement("bhfnr")
    ''    bhfnr.InnerText = RcaFbStr3_4b
    ''    empfangsbhf.AppendChild(bhfnr)

    ''    '+------- 3_4c. bhfnr
    ''    bhfname = Doc.CreateElement("bhfname")
    ''    bhfname.InnerText = RcaFbStr3_4c
    ''    empfangsbhf.AppendChild(bhfname)

    ''    '+----------------- 3_5. ablieferungsstelle [P10. Mesto izdavanja]
    ''    Dim ablieferungsstelle As XmlNode = Doc.CreateElement("ablieferungsstelle")
    ''    sendungskopf.AppendChild(ablieferungsstelle)

    ''    '+------- 3_5a. vw
    ''    vw = Doc.CreateElement("vw")
    ''    vw.InnerText = RcaFbStr3_4a
    ''    ablieferungsstelle.AppendChild(vw)

    ''    '+------- 3_5b. bhfnr
    ''    bhfnr = Doc.CreateElement("bhfnr")
    ''    bhfnr.InnerText = RcaFbStr3_4b
    ''    ablieferungsstelle.AppendChild(bhfnr)

    ''    '+------- 3_5c. bhfnr
    ''    bhfname = Doc.CreateElement("bhfname")
    ''    bhfname.InnerText = RcaFbStr3_4c
    ''    ablieferungsstelle.AppendChild(bhfname)

    ''    '+------- 3_5d. evu : OPTIONAL
    ''    ''evu = Doc.CreateElement("bhfrpc")
    ''    ''evu.InnerText = "001" 'RcaFbStr3_3d
    ''    ''ablieferungsstelle.AppendChild(evu)

    ''    '+------- 3_5e. versandnr
    ''    versandnr = Doc.CreateElement("ablieferungsort_name")
    ''    versandnr.InnerText = RcaFbStr3_4c
    ''    ablieferungsstelle.AppendChild(versandnr)

    ''    '----------------- 3_6. kunde [P1. POSILJALAC]
    ''    Dim kunde As XmlNode = Doc.CreateElement("kunde")
    ''    sendungskopf.AppendChild(kunde)

    ''    '+------ 3_6a. beteiligungsart
    ''    Dim beteiligungsart As XmlNode = Doc.CreateElement("beteiligungsart")
    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = "absender"
    ''    beteiligungsart.Attributes.Append(newAtt)
    ''    kunde.AppendChild(beteiligungsart)

    ''    '+------- 3_6b. kundennr
    ''    Dim kundennr As XmlNode = Doc.CreateElement("kundennr")
    ''    If RcaFbStr3_6b > 0 Then
    ''        kundennr.InnerText = RcaFbStr3_6b.ToString
    ''        kunde.AppendChild(kundennr)
    ''    End If

    ''    '+------- 3_6c. name
    ''    Dim name As XmlNode = Doc.CreateElement("name")
    ''    name.InnerText = RcaFbStr3_6c
    ''    kunde.AppendChild(name)

    ''    '+------- 3_6d. strasse 
    ''    Dim strasse As XmlNode = Doc.CreateElement("strasse")
    ''    If RcaFbStr3_6d <> Nothing Then
    ''        strasse.InnerText = RcaFbStr3_6d
    ''        kunde.AppendChild(strasse)
    ''    End If

    ''    '+------- 3_6e. plz 'iskljucen postanski broj
    ''    'Dim plz As XmlNode = Doc.CreateElement("plz")
    ''    'plz.InnerText = RcaFbStr3_6e
    ''    'kunde.AppendChild(plz)

    ''    '+------- 3_6f. plz
    ''    Dim ort As XmlNode = Doc.CreateElement("ort")
    ''    If RcaFbStr3_6f <> Nothing Then
    ''        ort.InnerText = RcaFbStr3_6f
    ''        kunde.AppendChild(ort)
    ''    End If

    ''    '+------- 3_6g. land
    ''    Dim land As XmlNode = Doc.CreateElement("land")
    ''    If RcaFbStr3_6g <> Nothing Then
    ''        land.InnerText = RcaFbStr3_6g
    ''        kunde.AppendChild(land)
    ''    End If

    ''    '+----------------- 3_7. kunde [P4. PRIMALAC]
    ''    kunde = Doc.CreateElement("kunde")
    ''    sendungskopf.AppendChild(kunde)

    ''    '+------- 3_7a. beteiligungsart
    ''    beteiligungsart = Doc.CreateElement("beteiligungsart")
    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = "empfaenger"
    ''    beteiligungsart.Attributes.Append(newAtt)
    ''    kunde.AppendChild(beteiligungsart)

    ''    If RcaFbStr3_7b > 0 Then
    ''        '------- 3_7b. kundennr
    ''        kundennr = Doc.CreateElement("kundennr")
    ''        kundennr.InnerText = RcaFbStr3_7b.ToString
    ''        kunde.AppendChild(kundennr)
    ''    End If

    ''    '------- 3_7c. name
    ''    name = Doc.CreateElement("name")
    ''    name.InnerText = RcaFbStr3_7c
    ''    kunde.AppendChild(name)

    ''    '''------- 3_7c2. name2 ISKLJUCENO DO DALJNJEG
    ''    ''Dim name2 As XmlNode = Doc.CreateElement("name2")
    ''    ''name2.InnerText = RcaFbStr3_7c
    ''    ''kunde.AppendChild(name2)

    ''    If RcaFbStr3_7d <> Nothing Then
    ''        '------- 3_7d. strasse
    ''        strasse = Doc.CreateElement("strasse")
    ''        strasse.InnerText = RcaFbStr3_7d
    ''        kunde.AppendChild(strasse)
    ''    End If

    ''    '''------- 3_7e. plz ISKLJUCENO DO DALJNJEG
    ''    ''plz = Doc.CreateElement("plz")
    ''    ''plz.InnerText = RcaFbStr3_7e
    ''    ''kunde.AppendChild(plz)

    ''    If RcaFbStr3_7f <> Nothing Then
    ''        '------- 3_7f. ort
    ''        ort = Doc.CreateElement("ort")
    ''        ort.InnerText = RcaFbStr3_7f
    ''        kunde.AppendChild(ort)
    ''    End If

    ''    If RcaFbStr3_7f <> Nothing Then
    ''        '------- 3_7g. land
    ''        land = Doc.CreateElement("land")
    ''        land.InnerText = RcaFbStr3_7g
    ''        kunde.AppendChild(land)
    ''    End If

    ''    '+----------------- 3_8. ausstellungsort [P29. MESTO ISPOSTAVLJANJA]
    ''    Dim ausstellungsort As XmlNode = Doc.CreateElement("ausstellungsort")
    ''    ausstellungsort.InnerText = RTrim(Me.tb29a.Text) '"SUBOTICA"
    ''    sendungskopf.AppendChild(ausstellungsort)

    ''    '+----------------- 3_9. ausstellungdatum [P29. DATUM ISPOSTAVLJANJA]
    ''    Dim ausstellungsdatum As XmlNode = Doc.CreateElement("ausstellungsdatum")
    ''    ausstellungsdatum.InnerText = Me.tb29b_1.Text & Me.tb29b_2.Text & Me.tb29b_3.Text '"11.04.2008"
    ''    sendungskopf.AppendChild(ausstellungsdatum)

    ''    '+----------------- 3_10. frankaturcode [P20. IZJAVA O PLACANJU ]
    ''    Dim frankaturcode As XmlNode = Doc.CreateElement("frankaturcode")
    ''    sendungskopf.AppendChild(frankaturcode)

    ''    '+------- 3_10a. frankaturcode_id
    ''    Dim frankaturcode_id As XmlNode = Doc.CreateElement("frankaturcode_id")
    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = Me.tb49a.Text '"16"
    ''    frankaturcode_id.Attributes.Append(newAtt)
    ''    frankaturcode.AppendChild(frankaturcode_id)

    ''    '+------- 3_10b. frankaturcode_id
    ''    ' 16 = ako je franko do prelaza


    ''    ' ok* ----------------- 3_11. erklaerungen [P7. IZJAVA POSILJAOCA ] PROVERITI DUZINU ZBOG VISE REDOVA
    ''    If Me.rtb7.Text <> Nothing Then
    ''        Dim erklaerungen As XmlNode = Doc.CreateElement("erklaerungen")
    ''        sendungskopf.AppendChild(erklaerungen)

    ''        '+------- 3_11a. erklaerungen_code
    ''        Dim erklaerungen_code As XmlNode = Doc.CreateElement("erklaerungen_code")
    ''        newAtt = Doc.CreateAttribute("value")
    ''        newAtt.Value = Microsoft.VisualBasic.Left(Me.rtb7.Text, 2) '"16"
    ''        erklaerungen_code.Attributes.Append(newAtt)
    ''        erklaerungen.AppendChild(erklaerungen_code)

    ''        '+------- 3_11b. erklaerungen_text
    ''        bhfnr = Doc.CreateElement("erklaerungen_text")
    ''        bhfnr.InnerText = RTrim(Microsoft.VisualBasic.Mid(Me.rtb7.Text, 5, 100)) '"JP ZELEZNICE SRBIJE 11000 Beograd, Nemanjina 6. PIB 103859991"
    ''        erklaerungen.AppendChild(bhfnr)
    ''    End If

    ''    ' OMG ---------------- 3_12. kommerz_bed [P13. KOMERCIJALNI USLOVI ] 
    ''    If Me.tb13.Text <> Nothing Then
    ''        Dim kommerz_bed As XmlNode = Doc.CreateElement("kommerz_bed")
    ''        sendungskopf.AppendChild(kommerz_bed)

    ''        '+------ 3_12a. kommerz_bed_code
    ''        Dim kommerz_bed_code As XmlNode = Doc.CreateElement("kommerz_bed_code")
    ''        newAtt = Doc.CreateAttribute("value")
    ''        newAtt.Value = "5"
    ''        kommerz_bed_code.Attributes.Append(newAtt)
    ''        kommerz_bed.AppendChild(kommerz_bed_code)

    ''        '+------ 3_12b. kommerz_bed_text
    ''        bhfnr = Doc.CreateElement("kommerz_bed_text")
    ''        bhfnr.InnerText = Microsoft.VisualBasic.Mid(Me.tb13.Text, 5, 100) '"16" "Frachtzahler MAV Strecke ist Fa. RAABERSPED Kft, Budapest ABEK Konto Nr08-275 JELS20 : TWA  via Subotica-Kelebia-Sopron"
    ''        kommerz_bed.AppendChild(bhfnr)
    ''    End If

    ''    ' ok ---------------- 3_13. tarif [P14. BROJ UGOVORA ILI TARIFE ]
    ''    Dim tarif As XmlNode = Doc.CreateElement("tarif")
    ''    sendungskopf.AppendChild(tarif)

    ''    '+------ 3_13a. tarif_kz
    ''    Dim tarif_kz As XmlNode = Doc.CreateElement("tarif_kz")
    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = Me.tb14a.Text '1=ugovor, 2=tarifa
    ''    tarif_kz.Attributes.Append(newAtt)
    ''    tarif.AppendChild(tarif_kz)

    ''    '+------ 3_13b. tarif_nr
    ''    bhfnr = Doc.CreateElement("vertrag_nr")
    ''    bhfnr.InnerText = RcaFbStr3_13b
    ''    tarif.AppendChild(bhfnr)

    ''    ' ok ----------------- 3_14. zolldaten 
    ''    Dim zolldaten As XmlNode = Doc.CreateElement("zolldaten")
    ''    sendungskopf.AppendChild(zolldaten)

    ''    '+------ 3_14a. vgvv tarif [P58b. POJEDNOSTAVLJENI POSTUPAK OTPREME ]
    ''    Dim vgvv As XmlNode = Doc.CreateElement("vgvv")
    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = "0"
    ''    vgvv.Attributes.Append(newAtt)
    ''    zolldaten.AppendChild(vgvv)


    ''    'OK ----------------- 3_15. leitungsweg [P50. PREVOZNI PUT ]
    ''    Dim ijk As Int16 = 1
    ''    Dim leitungsweg As XmlNode

    ''    'ŽS
    ''    leitungsweg = Doc.CreateElement("leitungsweg")
    ''    sendungskopf.AppendChild(leitungsweg)
    ''    '+------ 3_15a. leitungsweg_code
    ''    vw = Doc.CreateElement("leitungsweg_code")
    ''    vw.InnerText = "72" & Microsoft.VisualBasic.Mid(Me.rtb57b.Items(0), 5, 2)
    ''    leitungsweg.AppendChild(vw)
    ''    '+------ 3_15b. leitungsweg_bezeichnung
    ''    bhfnr = Doc.CreateElement("leitungsweg_bezeichnung")
    ''    bhfnr.InnerText = Microsoft.VisualBasic.Mid(Me.cbSmer2.Text, 11, Len(Me.cbSmer2.Text))
    ''    leitungsweg.AppendChild(bhfnr)

    ''    If NumNizR50 > 0 Then
    ''        If NizR50(0, 0) <> Nothing Then
    ''            For ijk = 0 To NumNizR50 - 1
    ''                leitungsweg = Doc.CreateElement("leitungsweg")
    ''                sendungskopf.AppendChild(leitungsweg)
    ''                '+------ 3_15a. leitungsweg_code
    ''                vw = Doc.CreateElement("leitungsweg_code")
    ''                vw.InnerText = NizR50(ijk, 0)
    ''                leitungsweg.AppendChild(vw)
    ''                '+------ 3_15b. leitungsweg_bezeichnung
    ''                bhfnr = Doc.CreateElement("leitungsweg_bezeichnung")
    ''                bhfnr.InnerText = NizR50(ijk, 1)
    ''                leitungsweg.AppendChild(bhfnr)
    ''            Next
    ''        End If
    ''    End If


    ''    ' ok* ----------------- 3_16. dokument [P9. PRILOZI ] - > Loop PROVERITI DUZINU ZBOG VISE REDOVA
    ''    If Me.rtb9.Text <> Nothing Then
    ''        Dim dokument As XmlNode = Doc.CreateElement("dokument")
    ''        sendungskopf.AppendChild(dokument)

    ''        '+------ 3_16a. dokument_typid
    ''        Dim dokument_typid As XmlNode = Doc.CreateElement("dokument_typid")
    ''        newAtt = Doc.CreateAttribute("value")
    ''        newAtt.Value = Microsoft.VisualBasic.Left(Me.rtb9.Text, 2) '"9999"
    ''        dokument_typid.Attributes.Append(newAtt)
    ''        dokument.AppendChild(dokument_typid)

    ''        '+------ 3_16b. dokument_text
    ''        bhfnr = Doc.CreateElement("dokument_text")
    ''        bhfnr.InnerText = RTrim(Microsoft.VisualBasic.Mid(Me.rtb9.Text, 5, 40)) '"Clan 24 stav 1, tacka 9 zakona"
    ''        dokument.AppendChild(bhfnr)

    ''    End If


    ''    'OK ----------------- 3_17. Andere_befoerderer [P57. OSTALI PREVOZNICI ]
    ''    Dim andere_befoerderer, strecke_von, str_v_bahnhof, strecke_bis, str_b_grenzpunkt, an_bef_eigenschaft As XmlNode
    ''    Dim str_v_grenzpunkt, str_b_bahnhof As XmlNode

    ''    'ŽS
    ''    andere_befoerderer = Doc.CreateElement("andere_befoerderer")
    ''    sendungskopf.AppendChild(andere_befoerderer)
    ''    '+------- 3_17a. an_bef_evu
    ''    vw = Doc.CreateElement("an_bef_evu")
    ''    vw.InnerText = RcaFbStr3_3d
    ''    andere_befoerderer.AppendChild(vw)
    ''    '+------- 3_17b. strecke_von
    ''    strecke_von = Doc.CreateElement("strecke_von")
    ''    andere_befoerderer.AppendChild(strecke_von)
    ''    '+---------------- 3_17b1. str_v_bahnhof
    ''    str_v_bahnhof = Doc.CreateElement("str_v_bahnhof")
    ''    strecke_von.AppendChild(str_v_bahnhof)

    ''    vw = Doc.CreateElement("str_v_vw")
    ''    vw.InnerText = "72"
    ''    str_v_bahnhof.AppendChild(vw)

    ''    vw = Doc.CreateElement("str_v_bhfnr")
    ''    vw.InnerText = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5) & Me.TextBox1.Text
    ''    str_v_bahnhof.AppendChild(vw)

    ''    vw = Doc.CreateElement("str_v_bhfname")
    ''    vw.InnerText = RTrim(Me.Label12.Text)
    ''    str_v_bahnhof.AppendChild(vw)
    ''    '+------- 3_17c. strecke_bis
    ''    strecke_bis = Doc.CreateElement("strecke_bis")
    ''    andere_befoerderer.AppendChild(strecke_bis)
    ''    '+---------------- 3_17c1. str_b_grenzpunkt
    ''    str_b_grenzpunkt = Doc.CreateElement("str_b_grenzpunkt")
    ''    strecke_bis.AppendChild(str_b_grenzpunkt)

    ''    vw = Doc.CreateElement("str_b_vw")
    ''    vw.InnerText = "72"
    ''    str_b_grenzpunkt.AppendChild(vw)

    ''    vw = Doc.CreateElement("str_b_code")
    ''    vw.InnerText = "711"
    ''    str_b_grenzpunkt.AppendChild(vw)

    ''    vw = Doc.CreateElement("str_b_bezeichnung")
    ''    vw.InnerText = "SUBOTICA GR."
    ''    str_b_grenzpunkt.AppendChild(vw)
    ''    '+------- 3_17d. an_bef_eigenschaft
    ''    an_bef_eigenschaft = Doc.CreateElement("an_bef_eigenschaft")
    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = "1"
    ''    an_bef_eigenschaft.Attributes.Append(newAtt)
    ''    andere_befoerderer.AppendChild(an_bef_eigenschaft)

    ''    For ijk = 0 To Me.rtb57a.Items.Count - 1
    ''        If ijk = Me.rtb57a.Items.Count - 1 Then ' --------------------------- Uputna uprava
    ''            andere_befoerderer = Doc.CreateElement("andere_befoerderer")
    ''            sendungskopf.AppendChild(andere_befoerderer)

    ''            '+------- 3_18a. an_bef_evu
    ''            vw = Doc.CreateElement("an_bef_evu")
    ''            vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57a.Items(ijk), 4)
    ''            andere_befoerderer.AppendChild(vw)

    ''            '+------- 3_18b. strecke_von
    ''            strecke_von = Doc.CreateElement("strecke_von")
    ''            andere_befoerderer.AppendChild(strecke_von)

    ''            '+---------------- 3_18b1. str_v_bahnhof
    ''            str_v_grenzpunkt = Doc.CreateElement("str_v_grenzpunkt")
    ''            strecke_von.AppendChild(str_v_grenzpunkt)

    ''            vw = Doc.CreateElement("str_v_vw")
    ''            vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57b.Items(ijk), 2)
    ''            str_v_grenzpunkt.AppendChild(vw)

    ''            vw = Doc.CreateElement("str_v_code")
    ''            vw.InnerText = Microsoft.VisualBasic.Mid(Me.rtb57b.Items(ijk), 4, 3)
    ''            str_v_grenzpunkt.AppendChild(vw)

    ''            'Opciono
    ''            '''vw = Doc.CreateElement("str_v_bezeichnung")
    ''            '''vw.InnerText = "SOPRON"
    ''            '''str_v_grenzpunkt.AppendChild(vw)

    ''            '+------- 3_18c. strecke_bis
    ''            strecke_bis = Doc.CreateElement("strecke_bis")
    ''            andere_befoerderer.AppendChild(strecke_bis)

    ''            '+---------------- 3_18c1. str_b_bahnhof
    ''            str_b_bahnhof = Doc.CreateElement("str_b_bahnhof")
    ''            strecke_bis.AppendChild(str_b_bahnhof)

    ''            vw = Doc.CreateElement("str_b_vw")
    ''            vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57b2.Items(ijk), 2)
    ''            str_b_bahnhof.AppendChild(vw)

    ''            vw = Doc.CreateElement("str_b_bhfnr")
    ''            vw.InnerText = Microsoft.VisualBasic.Mid(Me.rtb57b2.Items(ijk), 3, 6)
    ''            str_b_bahnhof.AppendChild(vw)

    ''            'Opciono
    ''            vw = Doc.CreateElement("str_b_bhfname")
    ''            vw.InnerText = RTrim(Me.Label13.Text) 'naziv uputne stanice
    ''            str_b_bahnhof.AppendChild(vw)

    ''            '+------- 3_18d. an_bef_eigenschaft
    ''            an_bef_eigenschaft = Doc.CreateElement("an_bef_eigenschaft")
    ''            newAtt = Doc.CreateAttribute("value")
    ''            newAtt.Value = "1"
    ''            an_bef_eigenschaft.Attributes.Append(newAtt)
    ''            andere_befoerderer.AppendChild(an_bef_eigenschaft)

    ''        Else ' ---------------------------------------------------------------Prolazna uprava

    ''            andere_befoerderer = Doc.CreateElement("andere_befoerderer")
    ''            sendungskopf.AppendChild(andere_befoerderer)

    ''            '+------- 3_18a. an_bef_evu
    ''            vw = Doc.CreateElement("an_bef_evu")
    ''            vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57a.Items(ijk), 4)
    ''            andere_befoerderer.AppendChild(vw)

    ''            '+------- 3_18b. strecke_von
    ''            strecke_von = Doc.CreateElement("strecke_von")
    ''            andere_befoerderer.AppendChild(strecke_von)

    ''            '+---------------- 3_18b1. str_v_grenzpunkt
    ''            str_v_grenzpunkt = Doc.CreateElement("str_v_grenzpunkt")
    ''            strecke_von.AppendChild(str_v_grenzpunkt)

    ''            vw = Doc.CreateElement("str_v_vw")
    ''            vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57b.Items(ijk), 2)
    ''            str_v_grenzpunkt.AppendChild(vw)

    ''            vw = Doc.CreateElement("str_v_code")
    ''            vw.InnerText = Microsoft.VisualBasic.Mid(Me.rtb57b.Items(ijk), 4, 3)
    ''            str_v_grenzpunkt.AppendChild(vw)

    ''            'Opciono - dodati iz niza prelaza Rubrika 50!
    ''            '''vw = Doc.CreateElement("str_v_bezeichnung")
    ''            '''vw.InnerText = "KELEBIA"
    ''            '''str_v_grenzpunkt.AppendChild(vw)

    ''            '+------- 3_18c. strecke_bis
    ''            strecke_bis = Doc.CreateElement("strecke_bis")
    ''            andere_befoerderer.AppendChild(strecke_bis)

    ''            '+---------------- 3_18c1. str_b_bahnhof
    ''            str_b_grenzpunkt = Doc.CreateElement("str_b_grenzpunkt")
    ''            strecke_bis.AppendChild(str_b_grenzpunkt)

    ''            vw = Doc.CreateElement("str_b_vw")
    ''            vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57b2.Items(ijk), 2)
    ''            str_b_grenzpunkt.AppendChild(vw)

    ''            vw = Doc.CreateElement("str_b_code")
    ''            vw.InnerText = Microsoft.VisualBasic.Mid(Me.rtb57b2.Items(ijk), 4, 3)
    ''            str_b_grenzpunkt.AppendChild(vw)

    ''            'Opciono - dodati iz niza prelaza Rubrika 50!
    ''            '''vw = Doc.CreateElement("str_b_bezeichnung")
    ''            '''vw.InnerText = "SOPRON"
    ''            '''str_b_bahnhof.AppendChild(vw)

    ''            '+------- 3_18d. an_bef_eigenschaft
    ''            an_bef_eigenschaft = Doc.CreateElement("an_bef_eigenschaft")
    ''            newAtt = Doc.CreateAttribute("value")
    ''            newAtt.Value = "1"
    ''            an_bef_eigenschaft.Attributes.Append(newAtt)
    ''            andere_befoerderer.AppendChild(an_bef_eigenschaft)

    ''        End If
    ''    Next

    ''    ' OK --------------------------------------------------------- 4. Wagen
    ''    Dim fb_Kola As String
    ''    Dim fb_Osovine, fb_Tara As Int32
    ''    Dim fb_Neto As Decimal
    ''    Dim wagen As XmlNode
    ''    Dim KolaRed As DataRow
    ''    Dim NhmRed As DataRow

    ''    For Each KolaRed In dtKola.Rows
    ''        fb_Kola = KolaRed.Item("IndBrojKola")
    ''        fb_Osovine = KolaRed.Item("Osovine")
    ''        fb_Tara = KolaRed.Item("Tara")
    ''        fb_Neto = 0

    ''        For Each NhmRed In dtNhm.Rows
    ''            If NhmRed.Item("IndBrojKola") = fb_Kola Then
    ''                fb_Neto = fb_Neto + NhmRed.Item("MasaDec")
    ''            End If
    ''        Next
    ''        fb_Neto = Decimal.Round(fb_Neto, 1)

    ''        wagen = Doc.CreateElement("wagen")
    ''        frachtbrief.AppendChild(wagen)
    ''        '+------- 4_1. wg_nr
    ''        vw = Doc.CreateElement("wg_nr")
    ''        vw.InnerText = fb_Kola
    ''        wagen.AppendChild(vw)
    ''        '+------- 4_2. wg_gesamtgewicht_kg - BRUTO
    ''        vw = Doc.CreateElement("wg_gesamtgewicht_kg")
    ''        vw.InnerText = (fb_Tara + CType(fb_Neto, Int32)).ToString
    ''        wagen.AppendChild(vw)
    ''        '+------- 4_3. wg_eigengewicht_kg  - TARA
    ''        vw = Doc.CreateElement("wg_eigengewicht_kg")
    ''        vw.InnerText = fb_Tara.ToString
    ''        wagen.AppendChild(vw)
    ''        '+------- 4_5. wg_anz_achsen       - OSOVINE
    ''        vw = Doc.CreateElement("wg_anz_achsen")
    ''        vw.InnerText = fb_Osovine.ToString
    ''        wagen.AppendChild(vw)
    ''        '+------- 4_8. ladegut    - ROBA
    ''        Dim ladegut As XmlNode = Doc.CreateElement("ladegut")
    ''        wagen.AppendChild(ladegut)
    ''        '+------- 4_8a. nhm
    ''        vw = Doc.CreateElement("nhm")
    ''        vw.InnerText = RcaFbStr4_8a
    ''        ladegut.AppendChild(vw)
    ''        '+------ 4_8a. nhm_bezeichnung
    ''        vw = Doc.CreateElement("nhm_bezeichnung")
    ''        vw.InnerText = RcaFbStr4_8b
    ''        ladegut.AppendChild(vw)
    ''        '+------- 4_8a. bruttogewicht_kg  - NETO
    ''        vw = Doc.CreateElement("bruttogewicht_kg")
    ''        vw.InnerText = fb_Neto.ToString
    ''        ladegut.AppendChild(vw)
    ''    Next


    ''    '  ----------------------------------------------------------- 4. Fba

    ''    Dim fba As XmlNode = Doc.CreateElement("fba")
    ''    frachtbrief.AppendChild(fba)

    ''    '+------- 5_1. verwaltung_von - Otpravna uprava
    ''    vw = Doc.CreateElement("verwaltung_von")
    ''    vw.InnerText = "72"
    ''    fba.AppendChild(vw)

    ''    '+------- 5_2. verwaltung_bis - Uputna uprava
    ''    vw = Doc.CreateElement("verwaltung_bis")
    ''    vw.InnerText = Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2)
    ''    fba.AppendChild(vw)

    ''    '+------- 5_3. strecke
    ''    Dim strecke As XmlNode = Doc.CreateElement("strecke")
    ''    fba.AppendChild(strecke)

    ''    '+------- 5_3b. eintrittsbahnhof 
    ''    Dim eintrittsbahnhof As XmlNode = Doc.CreateElement("eintrittsbahnhof")
    ''    strecke.AppendChild(eintrittsbahnhof)

    ''    '+------- 5_3b1. vw
    ''    vw = Doc.CreateElement("vw")
    ''    vw.InnerText = "72"
    ''    eintrittsbahnhof.AppendChild(vw)

    ''    '+------- 5_3b2. vw
    ''    vw = Doc.CreateElement("bhfnr")
    ''    vw.InnerText = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5) & Me.TextBox1.Text
    ''    eintrittsbahnhof.AppendChild(vw)

    ''    '+------- 5_3b. austrittsbahnhof 
    ''    Dim austrittsbahnhof As XmlNode = Doc.CreateElement("austrittsbahnhof")
    ''    strecke.AppendChild(austrittsbahnhof)

    ''    '+------- 5_3b1. vw
    ''    vw = Doc.CreateElement("vw")
    ''    vw.InnerText = Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2)
    ''    austrittsbahnhof.AppendChild(vw)

    ''    '+------- 5_3b2. vw
    ''    vw = Doc.CreateElement("bhfnr")
    ''    vw.InnerText = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5) & Me.TextBox2.Text
    ''    austrittsbahnhof.AppendChild(vw)

    ''    '+------- 5_4. fba_tarif
    ''    Dim fba_tarif As XmlNode = Doc.CreateElement("fba_tarif")
    ''    fba.AppendChild(fba_tarif)

    ''    '+------- 5_4a nhm
    ''    vw = Doc.CreateElement("nhm")
    ''    vw.InnerText = Me.tb24.Text
    ''    fba_tarif.AppendChild(vw)

    ''    '+------- 5_4b tarif_nr
    ''    vw = Doc.CreateElement("tarif_nr")
    ''    vw.InnerText = RcaFbStr3_13b
    ''    fba_tarif.AppendChild(vw)

    ''    '+------- 5_4c frachtpflicht_kg()  [ P74. RACUNSKA MASA ]
    ''    vw = Doc.CreateElement("frachtpflicht_kg")
    ''    vw.InnerText = tbA74d1.Text
    ''    fba_tarif.AppendChild(vw)

    ''    '+------- 5_4d frachtkosten
    ''    Dim frachtkosten As XmlNode = Doc.CreateElement("frachtkosten")
    ''    fba_tarif.AppendChild(frachtkosten)

    ''    Dim waehrung As XmlNode = Doc.CreateElement("waehrung")
    ''    newAtt = Doc.CreateAttribute("value")
    ''    newAtt.Value = "EUR"
    ''    waehrung.Attributes.Append(newAtt)
    ''    frachtkosten.AppendChild(waehrung)

    ''    '========== 5b. fba [ P79. NAKNADE ZA SPOREDNE USLUGE ]
    ''    If Me.tbA79a1.Text <> Nothing Then
    ''        fba = Doc.CreateElement("fba")
    ''        frachtbrief.AppendChild(fba)
    ''        '+------- 5b_1. verwaltung_von
    ''        vw = Doc.CreateElement("verwaltung_von")
    ''        vw.InnerText = "72"
    ''        fba.AppendChild(vw)
    ''        '+------- 5b_2. verwaltung_bis
    ''        vw = Doc.CreateElement("verwaltung_bis")
    ''        vw.InnerText = "72"
    ''        fba.AppendChild(vw)
    ''        '------- 5b_3. fba_nebengebuehr  [ P79. NAKNADE ZA SPOREDNE USLUGE ] #1
    ''        Dim fba_nebengebuehr As XmlNode = Doc.CreateElement("fba_nebengebuehr")
    ''        fba.AppendChild(fba_nebengebuehr)
    ''        '+------- 5_3a. nbgcode 
    ''        vw = Doc.CreateElement("nbgcode")
    ''        vw.InnerText = Me.tbA79a1.Text
    ''        fba_nebengebuehr.AppendChild(vw)

    ''        '+------- 5_3b. nbgkosten 
    ''        Dim nbgkosten As XmlNode = Doc.CreateElement("nbgkosten")
    ''        fba_nebengebuehr.AppendChild(nbgkosten)

    ''        '+------- 5_3b_1. frankiert 
    ''        vw = Doc.CreateElement("frankiert")
    ''        vw.InnerText = Me.tbA79b1.Text
    ''        nbgkosten.AppendChild(vw)

    ''        '+------- 5_3b_2. waehrung 
    ''        waehrung = Doc.CreateElement("waehrung")
    ''        newAtt = Doc.CreateAttribute("value")
    ''        newAtt.Value = "EUR"
    ''        waehrung.Attributes.Append(newAtt)
    ''        nbgkosten.AppendChild(waehrung)

    ''        If Me.tbA79a2.Text <> Nothing Then
    ''            '#2
    ''            '+------- 5b_3. fba_nebengebuehr  [ P79. NAKNADE ZA SPOREDNE USLUGE ]
    ''            fba_nebengebuehr = Doc.CreateElement("fba_nebengebuehr")
    ''            fba.AppendChild(fba_nebengebuehr)

    ''            '+------- 5_3a. nbgcode 
    ''            vw = Doc.CreateElement("nbgcode")
    ''            vw.InnerText = Me.tbA79a2.Text
    ''            fba_nebengebuehr.AppendChild(vw)

    ''            '+------- 5_3b. nbgkosten 
    ''            nbgkosten = Doc.CreateElement("nbgkosten")
    ''            fba_nebengebuehr.AppendChild(nbgkosten)

    ''            '+------- 5_3b_1. frankiert 
    ''            vw = Doc.CreateElement("frankiert")
    ''            vw.InnerText = Me.tbA79b2.Text
    ''            nbgkosten.AppendChild(vw)

    ''            '+------- 5_3b_2. waehrung 
    ''            waehrung = Doc.CreateElement("waehrung")
    ''            newAtt = Doc.CreateAttribute("value")
    ''            newAtt.Value = "EUR"
    ''            waehrung.Attributes.Append(newAtt)
    ''            nbgkosten.AppendChild(waehrung)

    ''            If Me.tbA79a3.Text <> Nothing Then
    ''                '#3
    ''                '+------- 5b_3. fba_nebengebuehr  [ P79. NAKNADE ZA SPOREDNE USLUGE ]
    ''                fba_nebengebuehr = Doc.CreateElement("fba_nebengebuehr")
    ''                fba.AppendChild(fba_nebengebuehr)

    ''                '+------- 5_3a. nbgcode 
    ''                vw = Doc.CreateElement("nbgcode")
    ''                vw.InnerText = Me.tbA79a3.Text
    ''                fba_nebengebuehr.AppendChild(vw)

    ''                '+------- 5_3b. nbgkosten 
    ''                nbgkosten = Doc.CreateElement("nbgkosten")
    ''                fba_nebengebuehr.AppendChild(nbgkosten)

    ''                '+------- 5_3b_1. frankiert 
    ''                vw = Doc.CreateElement("frankiert")
    ''                vw.InnerText = Me.tbA79b3.Text
    ''                nbgkosten.AppendChild(vw)

    ''                '+------- 5_3b_2. waehrung 
    ''                waehrung = Doc.CreateElement("waehrung")
    ''                newAtt = Doc.CreateAttribute("value")
    ''                newAtt.Value = "EUR"
    ''                waehrung.Attributes.Append(newAtt)
    ''                nbgkosten.AppendChild(waehrung)
    ''            End If
    ''        End If
    ''    End If

    ''    '========== Formira xml
    ''    Doc.Save(FolderXml & RcaFbStr1_2)

    ''    '========== Salje xml
    ''    PosaljiXml()  '''iskljuciti kada radi na lokalnom racunaru!!

    ''End Sub


    ''Private Sub R57_Init()
    ''    _ForNum = 0

    ''    Me.rtb57b.Items.Add("550711")

    ''    If rtb57a.Items.Count > 1 Then
    ''        r57_mUprava1 = Me.rtb57a.Items.Item(_ForNum)
    ''        r57_mUprava2 = Me.rtb57a.Items.Item(_ForNum + 1)
    ''        R57_FillCombo()
    ''        'cbR57_Validating(Me, Nothing)
    ''        Me.cbR57.DroppedDown = True
    ''    Else
    ''        'Me.rtb57b2.Items.Add("55100170")
    ''    End If

    ''End Sub

    ''Private Sub cbR57_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    ''    Dim daPrevPut As SqlClient.SqlDataAdapter
    ''    Dim dsPrevPut As New Data.DataSet
    ''    Dim pomSifraPP As String
    ''    Dim upit As String = ""
    ''    Dim objComm As SqlClient.SqlCommand

    ''    If _ForNum < Me.rtb57a.Items.Count - 1 Then
    ''        upit = ""
    ''    End If

    ''    If DbVeza.State = ConnectionState.Closed Then
    ''        DbVeza.Open()
    ''    End If
    ''    '---------------
    ''    Dim ii As Int32 = 0

    ''    cbR57.Items.Clear()
    ''    dsPrevPut.Clear()

    ''    upit = "SELECT SifraPrelaza, Naziv " _
    ''         & "FROM UicPrelazi " _
    ''         & "WHERE Uprava1 = '" & Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & "' AND Uprava2 = '" & Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & "' AND LEFT(SifraPrelaza, 1) = '0'"

    ''    Try
    ''        objComm = New SqlClient.SqlCommand(upit, DbVeza)
    ''        daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)
    ''        ii = daPrevPut.Fill(dsPrevPut)
    ''        For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
    ''            Me.cbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
    ''        Next

    ''    Catch ex As Exception
    ''        MsgBox("Nema podataka!")
    ''    Finally
    ''        DbVeza.Close()
    ''        Me.cbR57.Focus()
    ''    End Try

    ''End Sub

    ''Private Sub cbR57_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.cbR57.DroppedDown = True
    ''End Sub

    ''Private Sub cbR57_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub cbR57_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ''    Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))
    ''    Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))

    ''    str_R50 = Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & Microsoft.VisualBasic.Mid(Me.cbR57.Text, 3, 2)
    ''    str_R50naziv = Microsoft.VisualBasic.Mid(Me.cbR57.Text, 5, Len(Me.cbR57.Text) - 4)

    ''    'tb50.Text = tb50.Text & str_R50 & " " & RTrim(str_R50naziv) & " - "

    ''    NizR50(_ForNum, 0) = str_R50
    ''    NizR50(_ForNum, 1) = RTrim(str_R50naziv)

    ''    tb50.Text = tb50.Text & NizR50(_ForNum, 0) & " " & NizR50(_ForNum, 1) & " - "

    ''    '!?!?!?!?!?!?!?!?!?!
    ''    'ako je susedna uprava-niz je null i len je error

    ''    _ForNum = _ForNum + 1
    ''    BrojPrelazaUNizu = _ForNum

    ''    If _ForNum < Me.rtb57a.Items.Count - 1 Then
    ''        'Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))
    ''        'Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))

    ''        Me.cbR57.Enabled = True
    ''        r57_mUprava1 = Me.rtb57a.Items.Item(_ForNum)
    ''        r57_mUprava2 = Me.rtb57a.Items.Item(_ForNum + 1)
    ''        SkokNaVoz = "Ne"
    ''    ElseIf _ForNum = Me.rtb57a.Items.Count - 1 Then
    ''        Me.rtb57b2.Items.Add(tbStanicaPr.Text & Me.TextBox2.Text) 'uputna stanica
    ''        tb50.Text = Microsoft.VisualBasic.Left(tb50.Text, Len(tb50.Text) - 3)

    ''        Me.cbR57.SelectedIndex = -1
    ''        Me.cbR57.Enabled = False
    ''        SkokNaVoz = "Da" 'Treba da skoèi na tbsbrojvoza

    ''        '''Me.btnUpis.Focus()

    ''    End If
    ''End Sub
    ''Private Sub R57_FillCombo()
    ''    Dim daPrevPut As SqlClient.SqlDataAdapter
    ''    Dim dsPrevPut As New Data.DataSet
    ''    Dim pomSifraPP As String
    ''    Dim upit As String = ""
    ''    Dim objComm As SqlClient.SqlCommand

    ''    If _ForNum < Me.rtb57a.Items.Count - 1 Then
    ''        upit = ""
    ''    End If

    ''    If DbVeza.State = ConnectionState.Closed Then
    ''        DbVeza.Open()
    ''    End If
    ''    '---------------
    ''    Dim ii As Int32 = 0

    ''    cbR57.Items.Clear()
    ''    dsPrevPut.Clear()

    ''    upit = "SELECT SifraPrelaza, Naziv " _
    ''         & "FROM UicPrelazi " _
    ''         & "WHERE Uprava1 = '" & Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & "' AND Uprava2 = '" & Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & "' AND LEFT(SifraPrelaza, 1) = '0'"

    ''    Try
    ''        objComm = New SqlClient.SqlCommand(upit, DbVeza)
    ''        daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)
    ''        ii = daPrevPut.Fill(dsPrevPut)
    ''        For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
    ''            Me.cbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
    ''        Next

    ''    Catch ex As Exception
    ''        MsgBox("Nema podataka!")
    ''    Finally
    ''        DbVeza.Close()
    ''        Me.cbR57.Focus()
    ''    End Try

    ''End Sub
    ''Private Sub PosaljiXml()
    ''    Dim SentBytes, RecBytes As Int32
    ''    Dim FromFile As String = FolderXml & SourceFile
    ''    Dim ToFile As String = FolderFtp & SourceFile
    ''    Dim mFileSize1, mFileSize2 As Long

    ''    GetFileSize(FromFile, mFileSize1)
    ''    If System.IO.File.Exists(FromFile) = True Then
    ''        System.IO.File.Copy(FromFile, ToFile)

    ''        GetFileSize(ToFile, mFileSize2)
    ''        If mFileSize1 = mFileSize2 Then
    ''            MessageBox.Show("Uspesan transfer podataka!", "Poruka sa FTP Servera", MessageBoxButtons.OK)
    ''            System.IO.File.Delete(FromFile)
    ''        Else
    ''            MsgBox("Neuspešan transfer e-Cim XML : " & mFileSize1.ToString & " -> " & mFileSize2.ToString)
    ''        End If

    ''    End If
    ''End Sub
    ''Private Sub GetFileSize(ByVal MyFilePath As String, ByRef MyFileSize As Long)
    ''    Dim MyFile As New FileInfo(MyFilePath)
    ''    MyFileSize = MyFile.Length

    ''End Sub
    ''Private Sub tb16e_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

    ''    ''If tb16e.Text = Nothing Then
    ''    ''    tb16e.Focus()
    ''    ''Else
    ''    ''    If IsNumeric(tb16e.Text) = True Then
    ''    ''        If CType(Me.tb16e.Text, Int16) > 23 Then
    ''    ''            Me.tb16e.Focus()
    ''    ''        Else
    ''    ''            If Len(m_UicPrevozniPut) = 2 Then
    ''    ''                Me.btnUpis.Focus()
    ''    ''            Else
    ''    ''                '-- da li samo u slucaju 2155
    ''    ''                If IzborSaobracaja = "3" Then
    ''    ''                    If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then

    ''    ''                    End If
    ''    ''                Else
    ''    ''                    PopuniR57a()
    ''    ''                    R57_Init()
    ''    ''                End If
    ''    ''                '-- end da li samo u slucaju 2155
    ''    ''                '''''PopuniR57a()
    ''    ''                '''''R57_Init()

    ''    ''                Me.btnUpis.Focus()
    ''    ''            End If
    ''    ''        End If
    ''    ''    Else
    ''    ''        Me.tb16e.Focus()
    ''    ''    End If
    ''    ''End If

    ''    '''''''''''''
    ''    If IsNumeric(tb16e.Text) = True Then
    ''        If CType(Me.tb16e.Text, Int16) >= 0 And CType(Me.tb16e.Text, Int16) < 24 Then
    ''            If Len(tb16e.Text) = 1 Then
    ''                Me.tb16e.Text = "0" & Me.tb16e.Text
    ''            End If
    ''            If Len(m_UicPrevozniPut) = 2 Then
    ''                If IzborSaobracaja = "3" And eCimDa = "D" Then
    ''                    If Me.tb4a.Text = Nothing Then
    ''                        Me.tb4a.Focus()
    ''                    Else
    ''                        Me.btnUpis.Focus()
    ''                    End If
    ''                Else
    ''                    Me.btnUpis.Focus()
    ''                End If
    ''            Else
    ''                If IzborSaobracaja = "3" And eCimDa = "D" Then
    ''                    If Me.tb4a.Text = Nothing Then
    ''                        Me.tb4a.Focus()
    ''                    Else
    ''                        Me.btnUpis.Focus()
    ''                    End If
    ''                Else
    ''                    Me.btnUpis.Focus()
    ''                End If
    ''                ''If IzborSaobracaja = "3" And eCimDa = "D" Then
    ''                ''    If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then
    ''                ''        ''Me.btnUpis.Focus()
    ''                ''    Else
    ''                ''        PopuniR57a()
    ''                ''        R57_Init()
    ''                ''    End If
    ''                ''End If

    ''            End If

    ''            ''If IzborSaobracaja = "3" And eCimDa = "D" Then
    ''            ''    Me.cbR57.Focus()
    ''            ''Else
    ''            ''    Me.btnUpis.Focus()
    ''            ''End If
    ''        Else
    ''            Me.tb16e.Focus()
    ''        End If
    ''    Else
    ''        Me.tb16e.Focus()
    ''    End If

    ''End Sub

    ''Private Sub tb16c_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    ''    If IsNumeric(tb16c.Text) = True Then
    ''        If CType(Me.tb16c.Text, Int16) > 0 And CType(Me.tb16c.Text, Int16) < 13 Then
    ''            If Len(Me.tb16c.Text) = 1 Then
    ''                Me.tb16c.Text = "0" & Me.tb16c.Text
    ''            End If
    ''            Me.tb16d.Focus()
    ''        Else
    ''            Me.tb16c.Focus()
    ''        End If
    ''    Else
    ''        Me.tb16c.Focus()
    ''    End If
    ''End Sub

    ''Private Sub tb16d_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    ''    If IsNumeric(tb16d.Text) = True Then
    ''        If CType(Me.tb16d.Text, Int16) > 0 And CType(Me.tb16d.Text, Int16) < 32 Then
    ''            If Len(Me.tb16d.Text) = 1 Then
    ''                Me.tb16d.Text = "0" & Me.tb16d.Text
    ''            End If
    ''            Me.tb16e.Focus()
    ''        Else
    ''            Me.tb16d.Focus()
    ''        End If
    ''    Else
    ''        Me.tb16d.Focus()
    ''    End If
    ''End Sub

    ''Private Sub ComboBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.ComboBox5.Width = 25
    ''    Me.tb4b2.Text = Microsoft.VisualBasic.Left(Me.ComboBox5.Text, 2)
    ''    Me.btnUpis.Focus()
    ''End Sub

    ''Private Sub ComboBox5_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''    Me.ComboBox5.Width = 150
    ''End Sub

    ''Private Sub ComboBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub ComboBox6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.ComboBox6.Width = 25
    ''    Me.tb1b2.Text = Microsoft.VisualBasic.Left(Me.ComboBox6.Text, 2)
    ''    Me.btnUpis.Focus()
    ''End Sub

    ''Private Sub ComboBox6_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''    Me.ComboBox6.Width = 150
    ''End Sub

    ''Private Sub ComboBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If

    ''End Sub

    ''Private Sub tbUgovor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.GotFocus
    ''    Me.tbUgovor.SelectionStart = 0
    ''    Me.tbUgovor.SelectionLength = Len(tbUgovor.Text)

    ''End Sub
    ''Private Sub Init_Tarifa()
    ''    If DbVeza.State = ConnectionState.Closed Then
    ''        DbVeza.Open()
    ''    End If

    ''    Dim sql_trz1 As String = "SELECT dbo.ZsTarifa.SifraTarife, dbo.ZsTarifa.Opis FROM dbo.ZsTarifa " & _
    ''                             "WHERE (dbo.ZsTarifa.SifraVS = '" & IzborSaobracaja & "')"

    ''    Dim sql_commTrz1 As New SqlClient.SqlCommand(sql_trz1, DbVeza)
    ''    Dim rdrTar As SqlClient.SqlDataReader
    ''    Dim combo_linija1 As String = ""
    ''    ComboBox1.Items.Clear()
    ''    rdrTar = sql_commTrz1.ExecuteReader(CommandBehavior.CloseConnection)
    ''    Do While rdrTar.Read()
    ''        combo_linija1 = rdrTar.GetString(0) & " - " & rdrTar.GetString(1)
    ''        ComboBox1.Items.Add(combo_linija1)
    ''    Loop
    ''    rdrTar.Close()
    ''    DbVeza.Close()
    ''End Sub
    ''Private Sub Init_Forma()

    ''    If IzborSaobracaja = "4" Then
    ''        Me.TB58a1.Text = ""
    ''        Me.TB58a2.Text = ""
    ''        Me.GroupBox3.Enabled = True
    ''        Me.tbBrojPr.Enabled = False
    ''        Me.gbPrevozniPut.Visible = False
    ''        If TipTranzita = "ulaz" Then
    ''            tbUlaznaNalepnica.Enabled = True
    ''            tbIzlaznaNalepnica.Enabled = False

    ''            Me.cbSmer1.Enabled = False
    ''            Me.cbSmer1.Text = StanicaUnosa
    ''            Me.cbSmer2.Enabled = True

    ''            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
    ''                Me.tbPolaznaCarina.Text = "25046"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
    ''                Me.tbPolaznaCarina.Text = "23035"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
    ''                Me.tbPolaznaCarina.Text = "13021"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
    ''                Me.tbPolaznaCarina.Text = "15288"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
    ''                Me.tbPolaznaCarina.Text = "14125"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
    ''                Me.tbPolaznaCarina.Text = "42153"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
    ''                Me.tbPolaznaCarina.Text = "21083"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
    ''                Me.tbPolaznaCarina.Text = "22136"
    ''            End If

    ''            '----------------- inicijalizacija tranzitnih nalepnica
    ''            If DbVeza.State = ConnectionState.Closed Then
    ''                DbVeza.Open()
    ''            End If

    ''            Dim sql_text As String = "SELECT UlaznaNalepnica " & _
    ''                                     "FROM dbo.ZsTrzNalepnice " & _
    ''                                     "WHERE (dbo.ZsTrzNalepnice.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

    ''            Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
    ''            Dim rdrTrz As SqlClient.SqlDataReader

    ''            rdrTrz = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
    ''            Do While rdrTrz.Read()
    ''                mUlEtiketa = rdrTrz.GetInt32(0) + 1
    ''            Loop
    ''            rdrTrz.Close()
    ''            DbVeza.Close()
    ''            tbUlaznaNalepnica.Text = mUlEtiketa
    ''            '-----------------
    ''        Else

    ''            Me.cbSmer1.Text = UlazniTranzit
    ''            Me.cbSmer2.Text = StanicaUnosa
    ''            Me.cbSmer1.Enabled = False
    ''            Me.cbSmer2.Enabled = False
    ''            tbUlaznaNalepnica.Enabled = True
    ''            tbIzlaznaNalepnica.Enabled = True

    ''            If Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "23499" Then
    ''                Me.tbPolaznaCarina.Text = "25046"
    ''            ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "21099" Then
    ''                Me.tbPolaznaCarina.Text = "23035"
    ''            ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "12498" Then
    ''                Me.tbPolaznaCarina.Text = "13021"
    ''            ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "11028" Then
    ''                Me.tbPolaznaCarina.Text = "15288"
    ''            ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "15723" Then
    ''                Me.tbPolaznaCarina.Text = "14125"
    ''            ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "16319" Then
    ''                Me.tbPolaznaCarina.Text = "42153"
    ''            ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "16517" Then
    ''                Me.tbPolaznaCarina.Text = "21083"
    ''            ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "25471" Then
    ''                Me.tbPolaznaCarina.Text = "22136"
    ''            End If

    ''            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
    ''                Me.tbCarinjenje.Text = "25046"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
    ''                Me.tbCarinjenje.Text = "23035"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
    ''                Me.tbCarinjenje.Text = "13021"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
    ''                Me.tbCarinjenje.Text = "15288"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
    ''                Me.tbCarinjenje.Text = "14125"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
    ''                Me.tbCarinjenje.Text = "42153"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
    ''                Me.tbCarinjenje.Text = "21083"
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
    ''                Me.tbCarinjenje.Text = "22136"
    ''            End If

    ''            '----------------- inicijalizacija tranzitnih nalepnica
    ''            If DbVeza.State = ConnectionState.Closed Then
    ''                DbVeza.Open()
    ''            End If

    ''            Dim sql_text As String = "SELECT IzlaznaNalepnica " & _
    ''                                     "FROM dbo.ZsTrzNalepnice " & _
    ''                                     "WHERE (dbo.ZsTrzNalepnice.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

    ''            Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
    ''            Dim rdrTrz As SqlClient.SqlDataReader

    ''            rdrTrz = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
    ''            Do While rdrTrz.Read()
    ''                mIzEtiketa = rdrTrz.GetInt32(0) '+ 1
    ''            Loop
    ''            rdrTrz.Close()
    ''            DbVeza.Close()
    ''            '----------------- 
    ''            tbIzlaznaNalepnica.Text = mIzEtiketa + 1
    ''        End If
    ''    ElseIf IzborSaobracaja = "2" Then
    ''        Me.TB58a1.Text = ""
    ''        Me.TB58a2.Text = ""
    ''        Me.gbPrevozniPut.Enabled = False
    ''        Me.cbSmer1.Enabled = False ''' True
    ''        Me.cbSmer1.Text = StanicaUnosa
    ''        Me.cbSmer2.Enabled = False

    ''        If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
    ''            Me.tbPolaznaCarina.Text = "25046"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
    ''            Me.tbPolaznaCarina.Text = "23035"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
    ''            Me.tbPolaznaCarina.Text = "13021"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
    ''            Me.tbPolaznaCarina.Text = "15288"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
    ''            Me.tbPolaznaCarina.Text = "14125"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
    ''            Me.tbPolaznaCarina.Text = "42153"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
    ''            Me.tbPolaznaCarina.Text = "21083"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
    ''            Me.tbPolaznaCarina.Text = "22136"
    ''        End If

    ''        Me.GroupBox3.Enabled = False
    ''        Me.tbBrojPr.Enabled = True
    ''        Me.tbUpravaPr.Text = "0072"
    ''        Me.Label14.Text = "ZS"
    ''    ElseIf IzborSaobracaja = "3" Then
    ''        Me.TB58a1.Text = "0072"
    ''        Me.TB58a2.Text = "ZELEZNICE SRBIJE, Nemanjina 6, Beograd, Serbia"
    ''        Me.tb13.Text = "13.1  " & RTrim(Microsoft.VisualBasic.Mid(StanicaUnosa, 11, Len(StanicaUnosa))) & " Gr"

    ''        Me.gbPrevozniPut.Enabled = True
    ''        Me.cbSmer1.Enabled = False
    ''        Me.cbSmer2.Text = StanicaUnosa
    ''        Me.cbSmer2.Enabled = False ''' True

    ''        Me.GroupBox3.Enabled = False
    ''        Me.tbBrojPr.Enabled = False
    ''        Me.tbUpravaOtp.Text = "0072"
    ''        Me.tbStanicaOtp.Text = "72"
    ''        Me.Label11.Text = "ZS"
    ''    End If

    ''    mAkcija = "New"
    ''    mObrMesec = Today.Month
    ''    mObrGodina = Today.Year

    ''End Sub
    ''Private Sub eInit_NewCim89()

    ''    'brisanje vrednosti promenljivih pre novog unosa
    ''    xml_ZemljaOtp = ""
    ''    xml_StanicaOtp = ""
    ''    xml_NazivStaniceOtp = ""
    ''    xml_OperaterOtp = ""
    ''    xml_ZemljaPr = ""
    ''    xml_StanicaPr = ""
    ''    xml_NazivStanicePr = ""
    ''    xml_BrojCimOtp = 0
    ''    xml_tara = 0
    ''    xml_netoInt = 0
    ''    xml_osovine = 0
    ''    xml_GrTov = 0
    ''    xml_netoDec = 0
    ''    xml_R16a = ""
    ''    xml_R16b = ""
    ''    xml_R16c = ""
    ''    xml_R16d = ""
    ''    xml_R16god = ""
    ''    xml_R16e = ""
    ''    xml_R20a = ""
    ''    xml_R20b = ""
    ''    xml_R20c = ""
    ''    xml_R20d = ""
    ''    xml_R20f = ""
    ''    xml_R10a = ""
    ''    xml_R10b = ""
    ''    xml_R10c = ""
    ''    xml_R10d = ""
    ''    xml_R12 = ""
    ''    xml_R29a = ""
    ''    xml_R29b = ""
    ''    xml_R50 = ""
    ''    xml_R57a = ""
    ''    xml_R57b = ""
    ''    xml_R57a1 = ""
    ''    xml_R57a2 = ""
    ''    xml_R57b1 = ""
    ''    xml_R57b1a = ""
    ''    xml_R57b2 = ""
    ''    xml_R57b2a = ""
    ''    xml_R2 = ""
    ''    xml_R1a = ""
    ''    xml_R1b = ""
    ''    xml_R1c = ""
    ''    xml_R1d = ""
    ''    xml_R5 = ""
    ''    xml_R4a = ""
    ''    xml_R4b = ""
    ''    xml_R4c = ""
    ''    xml_R4d = ""
    ''    xml_IBK = ""
    ''    xml_Nhm = ""
    ''    xml_R57_ulaz = ""
    ''    xml_R57_izlaz = ""

    ''End Sub
    ''Private Sub eInit_Forma()


    ''    If IzborSaobracaja = "4" Then
    ''        Me.TB58a1.Text = ""
    ''        Me.TB58a2.Text = ""
    ''        Me.GroupBox3.Enabled = True
    ''        Me.tbBrojPr.Enabled = False
    ''        Me.gbPrevozniPut.Visible = False

    ''        tbUlaznaNalepnica.Enabled = True
    ''        tbIzlaznaNalepnica.Enabled = False

    ''        Me.cbSmer1.Enabled = False
    ''        Me.cbSmer1.Text = StanicaUnosa
    ''        Me.cbSmer2.Enabled = True

    ''        If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
    ''            Me.tbPolaznaCarina.Text = "25046"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
    ''            Me.tbPolaznaCarina.Text = "23035"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
    ''            Me.tbPolaznaCarina.Text = "13021"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
    ''            Me.tbPolaznaCarina.Text = "15288"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
    ''            Me.tbPolaznaCarina.Text = "14125"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
    ''            Me.tbPolaznaCarina.Text = "42153"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
    ''            Me.tbPolaznaCarina.Text = "21083"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
    ''            Me.tbPolaznaCarina.Text = "22136"
    ''        End If

    ''        '----------------- inicijalizacija tranzitnih nalepnica
    ''        If DbVeza.State = ConnectionState.Closed Then
    ''            DbVeza.Open()
    ''        End If

    ''        Dim sql_text As String = "SELECT UlaznaNalepnica " & _
    ''                                 "FROM dbo.ZsTrzNalepnice " & _
    ''                                 "WHERE (dbo.ZsTrzNalepnice.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

    ''        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
    ''        Dim rdrTrz As SqlClient.SqlDataReader

    ''        rdrTrz = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
    ''        Do While rdrTrz.Read()
    ''            mUlEtiketa = rdrTrz.GetInt32(0) + 1
    ''        Loop
    ''        rdrTrz.Close()
    ''        DbVeza.Close()
    ''        tbUlaznaNalepnica.Text = mUlEtiketa

    ''    ElseIf IzborSaobracaja = "2" Then
    ''        Me.TB58a1.Text = ""
    ''        Me.TB58a2.Text = ""
    ''        Me.gbPrevozniPut.Enabled = False
    ''        Me.cbSmer1.Enabled = False
    ''        Me.cbSmer1.Text = StanicaUnosa
    ''        Me.cbSmer2.Enabled = False

    ''        If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
    ''            Me.tbPolaznaCarina.Text = "25046"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
    ''            Me.tbPolaznaCarina.Text = "23035"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
    ''            Me.tbPolaznaCarina.Text = "13021"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
    ''            Me.tbPolaznaCarina.Text = "15288"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
    ''            Me.tbPolaznaCarina.Text = "14125"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
    ''            Me.tbPolaznaCarina.Text = "42153"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
    ''            Me.tbPolaznaCarina.Text = "21083"
    ''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
    ''            Me.tbPolaznaCarina.Text = "22136"
    ''        End If

    ''        Me.GroupBox3.Enabled = False
    ''        Me.tbBrojPr.Enabled = True
    ''        Me.tbUpravaPr.Text = "0072"
    ''        Me.Label14.Text = "ZS"
    ''    End If

    ''    mAkcija = "New"
    ''    mObrMesec = Today.Month
    ''    mObrGodina = Today.Year

    ''End Sub

    ''Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
    ''    IzborSaobracaja = "4"
    ''    TipTranzita = "ulaz"
    ''    Me.Text = ":: CIM - Tranzit ULAZ ::"
    ''    Init_Tarifa()
    ''    Init_Forma()
    ''    Me.ComboBox1.Focus()

    ''End Sub

    ''Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
    ''    IzborSaobracaja = "2"
    ''    Me.Text = ":: CIM - U V O Z ::"
    ''    Init_Tarifa()
    ''    Init_Forma()
    ''    Me.ComboBox1.Focus()
    ''End Sub

    ''Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
    ''    IzborSaobracaja = "3"
    ''    Me.Text = ":: CIM - I Z V O Z ::"
    ''    Init_Tarifa()
    ''    Init_Forma()
    ''    Me.ComboBox1.Focus()
    ''End Sub

    ''Private Sub tbsBrojVoza_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbsBrojVoza.Validating
    ''    If tbsBrojVoza.Text Is Nothing Then
    ''        ErrorProvider1.SetError(PictureBox3, "Neispravan broj voza!")
    ''        ErrorProvider1.SetIconAlignment(PictureBox3, ErrorIconAlignment.TopLeft)
    ''        tbsBrojVoza.Focus()
    ''    Else
    ''        If IsNumeric(tbsBrojVoza.Text) = True Then
    ''            If CType(Me.tbsBrojVoza.Text, Int32) > 0 Then
    ''                ErrorProvider1.SetError(PictureBox3, "")
    ''                Me.tbsSatVoza.Focus()
    ''            Else
    ''                ErrorProvider1.SetError(PictureBox3, "Neispravan broj voza!")
    ''                ErrorProvider1.SetIconAlignment(PictureBox3, ErrorIconAlignment.TopLeft)
    ''                tbsBrojVoza.Focus()
    ''            End If
    ''        Else
    ''            ErrorProvider1.SetError(PictureBox3, "Neispravan broj voza!")
    ''            ErrorProvider1.SetIconAlignment(PictureBox3, ErrorIconAlignment.TopLeft)
    ''            tbsBrojVoza.Focus()
    ''        End If
    ''    End If
    ''End Sub

    ''Private Sub tb1a_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb1a.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb1a_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb1a.Leave
    ''    Me.tb1a.BackColor = System.Drawing.Color.DarkSeaGreen
    ''    tb1b.Focus()
    ''End Sub

    ''Private Sub tb1b_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb1b.Leave
    ''    Me.tb1b.BackColor = System.Drawing.Color.DarkSeaGreen
    ''    tb1b1.Focus()
    ''End Sub

    ''Private Sub tb1b1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb1b1.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb1b_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb1b.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb4a_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb4a.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb4a_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb4a.Leave
    ''    Me.tb4a.BackColor = System.Drawing.Color.DarkSeaGreen
    ''    tb4b.Focus()

    ''End Sub

    ''Private Sub tb4b_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb4b.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb4b_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb4b.Leave
    ''    Me.tb4b.BackColor = System.Drawing.Color.DarkSeaGreen
    ''    tb4b1.Focus()

    ''End Sub

    ''Private Sub tb4b1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb4b1.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub
    ''Private Sub btnUpis_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.GotFocus
    ''    Me.btnUpis.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.btnUpis.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub btnUpis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.Leave
    ''    Me.btnUpis.BackColor = System.Drawing.Color.PapayaWhip
    ''    Me.btnUpis.ForeColor = System.Drawing.Color.Black
    ''End Sub

    ''Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "     Ugovori"
    ''    upit = "Ugovori"
    ''    helpUic.ShowDialog()
    ''    Me.tbUgovor.Focus()
    ''    Me.tbUgovor.Text = mIzlaz2
    ''End Sub
    ''Private Sub tbsBrojVoza_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbsBrojVoza.GotFocus
    ''    Me.tbsBrojVoza.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbsBrojVoza.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub tbsBrojVoza_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbsBrojVoza.Leave
    ''    Me.tbsBrojVoza.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
    ''    Me.tbsBrojVoza.ForeColor = System.Drawing.Color.Black
    ''    Me.tbsSatVoza.Focus()

    ''End Sub

    ''Private Sub tbsSatVoza_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbsSatVoza.GotFocus
    ''    Me.tbsSatVoza.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbsSatVoza.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub tb16c_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.tb16c.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tb16d_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.tb16d.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tb16e_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.tb16e.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tb16c_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.tb16c.BackColor = System.Drawing.Color.DarkSeaGreen
    ''End Sub

    ''Private Sub tb16d_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.tb16d.BackColor = System.Drawing.Color.DarkSeaGreen
    ''End Sub
    ''Private Sub tb16e_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.tb16e.BackColor = System.Drawing.Color.DarkSeaGreen
    ''End Sub
    ''Private Sub tbsSatVoza_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbsSatVoza.Leave
    ''    Me.tbsSatVoza.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
    ''    Me.tbsSatVoza.ForeColor = System.Drawing.Color.Black

    ''    If CType(Me.tbsSatVoza.Text, Int32) > 24 Then
    ''        Me.tbsSatVoza.Focus()
    ''    Else
    ''        btnUnosRobe_Click(Me, Nothing)
    ''    End If
    ''End Sub
    ''Private Sub tb1a_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb1a.GotFocus
    ''    Me.tb1a.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tb1b_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb1b.GotFocus
    ''    Me.tb1b.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tb1b1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb1b1.GotFocus
    ''    Me.tb1b1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tb4a_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb4a.GotFocus
    ''    Me.tb4a.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tb4b_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb4b.GotFocus
    ''    Me.tb4b.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tb4b1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb4b1.GotFocus
    ''    Me.tb4b1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tb1b1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb1b1.Leave
    ''    Me.tb1b1.BackColor = System.Drawing.Color.DarkSeaGreen
    ''End Sub

    ''Private Sub tb4b1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb4b1.Leave
    ''    Me.tb4b1.BackColor = System.Drawing.Color.DarkSeaGreen
    ''End Sub

    ''Private Sub tbUpravaOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaOtp.GotFocus
    ''    Me.tbUpravaOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbUpravaOtp.ForeColor = System.Drawing.Color.White

    ''End Sub

    ''Private Sub tbUpravaOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaOtp.Leave
    ''    Me.tbUpravaOtp.BackColor = System.Drawing.Color.White
    ''    Me.tbUpravaOtp.ForeColor = System.Drawing.Color.Black
    ''End Sub

    ''Private Sub tbStanicaOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaOtp.GotFocus
    ''    Me.tbStanicaOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbStanicaOtp.ForeColor = System.Drawing.Color.White
    ''End Sub
    ''Private Sub tbBrojOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.GotFocus
    ''    Me.tbBrojOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbBrojOtp.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub tbBrojOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.Leave
    ''    Me.tbBrojOtp.BackColor = System.Drawing.Color.White
    ''    Me.tbBrojOtp.ForeColor = System.Drawing.Color.Black
    ''End Sub

    ''Private Sub DatumOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.GotFocus
    ''    Me.DatumOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.DatumOtp.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub DatumOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.Leave
    ''    Me.DatumOtp.BackColor = System.Drawing.Color.White
    ''    Me.DatumOtp.ForeColor = System.Drawing.Color.Black
    ''End Sub

    ''Private Sub tbUpravaPr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaPr.GotFocus
    ''    Me.tbUpravaPr.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbUpravaPr.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub tbUpravaPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaPr.Leave
    ''    Me.tbUpravaPr.BackColor = System.Drawing.Color.White
    ''    Me.tbUpravaPr.ForeColor = System.Drawing.Color.Black
    ''End Sub

    ''Private Sub tbStanicaPr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.GotFocus
    ''    Me.tbStanicaPr.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbStanicaPr.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub tbBrojPr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojPr.GotFocus
    ''    Me.tbBrojPr.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbBrojPr.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub DateTimePicker2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.GotFocus
    ''    Me.DateTimePicker2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''End Sub

    ''Private Sub tbUlaznaNalepnica_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUlaznaNalepnica.GotFocus
    ''    Me.tbUlaznaNalepnica.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbUlaznaNalepnica.ForeColor = System.Drawing.Color.White

    ''End Sub

    ''Private Sub tbUlaznaNalepnica_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUlaznaNalepnica.Leave
    ''    Me.tbUlaznaNalepnica.BackColor = System.Drawing.SystemColors.Control
    ''    Me.tbUlaznaNalepnica.ForeColor = System.Drawing.Color.Black
    ''End Sub

    ''Private Sub tbIzlaznaNalepnica_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbIzlaznaNalepnica.GotFocus
    ''    Me.tbIzlaznaNalepnica.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbIzlaznaNalepnica.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub tbIzlaznaNalepnica_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbIzlaznaNalepnica.Leave
    ''    Me.tbIzlaznaNalepnica.BackColor = System.Drawing.SystemColors.Control
    ''    Me.tbIzlaznaNalepnica.ForeColor = System.Drawing.Color.Black

    ''End Sub

    ''Private Sub tbCarinjenje_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbCarinjenje_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.tbCarinjenje.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
    ''    Me.tbCarinjenje.ForeColor = System.Drawing.Color.Black
    ''    Me.btnUpis.Focus()

    ''End Sub

    ''Private Sub tbCarinjenje_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.tbCarinjenje.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.tbCarinjenje.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub kbBrojOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles kbBrojOtp.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub kbBrojOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles kbBrojOtp.Leave
    ''    Me.kbBrojOtp.BackColor = System.Drawing.Color.White
    ''    Me.kbBrojOtp.ForeColor = System.Drawing.Color.Black
    ''End Sub

    ''Private Sub kbBrojOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles kbBrojOtp.GotFocus
    ''    Me.kbBrojOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    ''    Me.kbBrojOtp.ForeColor = System.Drawing.Color.White
    ''End Sub

    ''Private Sub kbBrojOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles kbBrojOtp.Validating
    ''    If kbBrojOtp.Text = Nothing Then
    ''        ErrorProvider1.SetError(Label15, "Unesite kontrolni broj")
    ''        kbBrojOtp.Focus()
    ''    Else
    ''        If IsNumeric(kbBrojOtp.Text) = True Then
    ''            ErrorProvider1.SetError(Label15, "")
    ''        Else
    ''            ErrorProvider1.SetError(Label15, "Neispravan unos kontrolnog broja!")
    ''            tbBrojOtp.Focus()
    ''        End If
    ''    End If
    ''End Sub
    ''Public Sub DownloadValues()

    ''    tbUpravaOtp.Text = xml_OperaterOtp
    ''    tbStanicaOtp.Text = xml_ZemljaOtp & Microsoft.VisualBasic.Left(xml_StanicaOtp, 5)
    ''    TextBox1.Text = Microsoft.VisualBasic.Right(xml_StanicaOtp, 1)
    ''    Me.tbBrojOtp.Text = Microsoft.VisualBasic.Left(xml_BrojCimOtp.ToString, Len(xml_BrojCimOtp.ToString) - 1)
    ''    kbBrojOtp.Text = Microsoft.VisualBasic.Right(xml_BrojCimOtp.ToString, 1)
    ''    Label12.Text = xml_NazivStaniceOtp

    ''    Me.DatumOtp.Text = xml_R16c & "." & xml_R16d & "." & xml_R16god

    ''    '''''tb17.Text = xml_R16c & "." & xml_R16d & "." & xml_R16a

    ''    tb16a.Text = xml_R16b
    ''    tb16c.Text = xml_R16c
    ''    tb16d.Text = xml_R16d
    ''    tb16e.Text = xml_R16e

    ''    If IzborSaobracaja = "2" Then
    ''        tbUpravaPr.Text = "0072"
    ''    Else
    ''        tbUpravaPr.Text = xml_ZemljaPr
    ''    End If

    ''    Me.tbStanicaPr.Text = Microsoft.VisualBasic.Right(xml_ZemljaPr, 2) & Microsoft.VisualBasic.Left(xml_StanicaPr, 5)
    ''    Me.tb17.Text = Me.tbStanicaOtp.Text
    ''    Me.TextBox2.Text = Microsoft.VisualBasic.Right(xml_StanicaPr, 1)
    ''    Me.Label13.Text = xml_NazivStanicePr

    ''    Me.tb2.Text = xml_R2
    ''    Me.tb1a.Text = xml_R1a
    ''    Me.tb1b.Text = xml_R1b
    ''    Me.tb1b1.Text = xml_R1c
    ''    Me.tb1c.Text = xml_R1d

    ''    Me.tb5.Text = xml_R5
    ''    Me.tb4a.Text = xml_R4a
    ''    Me.tb4b.Text = xml_R4b
    ''    Me.tb4b1.Text = xml_R4c
    ''    Me.tb4c.Text = xml_R4d

    ''    Me.tb50.Text = xml_R50

    ''    Me.rtb57a.Items.Clear()
    ''    Me.rtb57b.Items.Clear()
    ''    Me.rtb57b2.Items.Clear()
    ''    Me.rtb57c.Items.Clear()

    ''    Dim aa57 As Int16

    ''    For aa57 = 1 To Len(RTrim(xml_R57a2)) Step 41
    ''        Me.rtb57a.Items.Add(Microsoft.VisualBasic.Mid(xml_R57a2, aa57, 40))
    ''    Next
    ''    For aa57 = 1 To Len(RTrim(xml_R57b1a)) Step 48
    ''        Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(xml_R57b1a, aa57, 46))
    ''    Next
    ''    For aa57 = 1 To Len(RTrim(xml_R57b2a)) Step 48
    ''        Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(xml_R57b2a, aa57, 46))
    ''    Next
    ''    For aa57 = 1 To Me.rtb57a.Items.Count
    ''        Me.rtb57c.Items.Add(1)
    ''    Next

    ''    Select Case xml_R57_izlaz
    ''        Case "7211"
    ''            mStanica2 = "1 - 23499 Subotica"
    ''            tbCarinjenje.Text = "25046"
    ''        Case "7260"
    ''            mStanica2 = "2 - 22899 Kikinda"
    ''            tbCarinjenje.Text = "24015"
    ''        Case "7261"
    ''            mStanica2 = "3 - 21099 Vrsac"
    ''            tbCarinjenje.Text = "23035"
    ''        Case "7220"
    ''            mStanica2 = "4 - 12498 Dimitrovgrad"
    ''            tbCarinjenje.Text = "13021"
    ''        Case "7276"
    ''            mStanica2 = "5 - 11028 Presevo"
    ''            tbCarinjenje.Text = "15288"
    ''        Case "7271"
    ''            mStanica2 = "6 - 15723 Prijepolje Teretna"
    ''            tbCarinjenje.Text = "14443"
    ''        Case "7291"
    ''            mStanica2 = "7 - 16319 Brasina"
    ''            tbCarinjenje.Text = "42153"
    ''        Case "7201"
    ''            mStanica2 = "8 - 16517 Sid"
    ''            tbCarinjenje.Text = "21083"
    ''        Case "7202"
    ''            mStanica2 = "10 - 25471 Bogojevo"
    ''            tbCarinjenje.Text = "22292"
    ''    End Select
    ''    Me.cbSmer2.Text = mStanica2

    ''    tb29a.Text = xml_R29a
    ''    tb29b.Text = xml_R29b

    ''    tb10a.Text = xml_R10a & " " & xml_R10b
    ''    TextBox34.Text = xml_R10d
    ''    tb12.Text = xml_R12

    ''    tb52a.Text = xml_ZemljaOtp
    ''    tb52b.Text = Microsoft.VisualBasic.Left(xml_StanicaOtp, 5)
    ''    tb52c.Text = Microsoft.VisualBasic.Right(xml_StanicaOtp, 1)
    ''    tb52d.Text = xml_OperaterOtp
    ''    tb52e.Text = xml_BrojCimOtp

    ''    Me.tb49a.Text = xml_R20a

    ''    Daljinar()

    ''    If xml_R20b = "EXW" Or xml_R20b = "FCA" Or xml_R20b = "CPT" Or _
    ''       xml_R20b = "CIP" Or xml_R20b = "DAF" Or xml_R20b = "DDU" Or xml_R20b = "DDP" Then
    ''        Me.cbFrankoPrevoznina.Checked = False
    ''        Me.cbIncoterms.Checked = True
    ''        Me.cbIncoterms.Enabled = True
    ''        comboIncoterms.Enabled = True

    ''        If xml_R20b = "EXW" Then
    ''            comboIncoterms.SelectedIndex = 0
    ''        ElseIf xml_R20b = "FCA" Then
    ''            comboIncoterms.SelectedIndex = 1
    ''        ElseIf xml_R20b = "CPT" Then
    ''            comboIncoterms.SelectedIndex = 2
    ''        ElseIf xml_R20b = "CIP" Then
    ''            comboIncoterms.SelectedIndex = 3
    ''        ElseIf xml_R20b = "DAF" Then
    ''            comboIncoterms.SelectedIndex = 4
    ''        ElseIf xml_R20b = "DDU" Then
    ''            comboIncoterms.SelectedIndex = 5
    ''        ElseIf xml_R20b = "DDP" Then
    ''            comboIncoterms.SelectedIndex = 6
    ''        End If

    ''    Else
    ''        Me.cbIncoterms.Checked = False
    ''        Me.cbFrankoPrevoznina.Checked = True
    ''    End If

    ''    Me.tb49h.Text = xml_R20c
    ''    Me.tb20f.Text = xml_R20d

    ''    tb20a.Text = Microsoft.VisualBasic.Left(xml_R20f, 2)
    ''    tb20b.Text = Microsoft.VisualBasic.Mid(xml_R20f, 3, 2)
    ''    tb20c.Text = Microsoft.VisualBasic.Mid(xml_R20f, 5, 2)
    ''    tb20d.Text = Microsoft.VisualBasic.Mid(xml_R20f, 7, 2)
    ''    tb20e.Text = Microsoft.VisualBasic.Mid(xml_R20f, 9, 2)

    ''    tb49b.Text = Microsoft.VisualBasic.Left(xml_R20f, 2)
    ''    tb49c.Text = Microsoft.VisualBasic.Mid(xml_R20f, 3, 2)
    ''    tb49d.Text = Microsoft.VisualBasic.Mid(xml_R20f, 5, 2)
    ''    tb49e.Text = Microsoft.VisualBasic.Mid(xml_R20f, 7, 2)
    ''    tb49f.Text = Microsoft.VisualBasic.Mid(xml_R20f, 9, 2)



    ''    Kola_eValidating()
    ''    eUskladiTipKola()

    ''    If IzborSaobracaja = "4" Then
    ''        mTarifa = "00"
    ''    Else
    ''        mTarifa = "36"
    ''    End If
    ''    'da bi dodelio tarifski razred pre izbora tarife
    ''    eUskladiNhm()


    ''End Sub


    Private Sub FormUTL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'bbDatum = mDatumKalk            ' za naknade

        Dim intX As Int32 = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Int32 = Screen.PrimaryScreen.Bounds.Height
        Me.Location = New Point(0, 0)
        Me.Size = New Size(intX, intY) 'Size(intX, intY)

        If MasterAction = "Upd" Or AkcijaZaPreuzimanje = "Da" Then
            'bOsveziIzBazePriUpd()
            bPrikazIzSloga()
        Else
            If bVrstaSaobracaja <> 0 Then
                bNadjiIPrikaziKurseve(bValuta)
            Else
                Label25.Visible = False
                TextBox3.Visible = False
                TextBox4.Visible = False
                If mBrojUg = "200379" Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then ' 25.07.2016 za sada; treba ukljuciti da li su cene u RSD ili EUR
                    Label25.Visible = True
                    TextBox3.Visible = True
                    TextBox4.Visible = True
                    bNadjiIPrikaziKurseve("17")
                End If
            End If
        End If

        FormatErrGrid()

        If Not (MasterAction = "Upd") Then

            Me.ComboBox4.SelectedIndex = 0
            Me.ComboBox1.SelectedIndex = 0
            Me.ComboBox3.SelectedIndex = 0
            Me.ComboBox2.SelectedIndex = 0
            cbZsPrevozniPut.SelectedIndex = 0

            tb20a.Text = ""
            tb20b.Text = ""
            tb20c.Text = ""
            tb20d.Text = ""

        End If

        Me.cbPDV.Focus()
        btnUnosRobe.Text = dtKola.Rows.Count

    End Sub

    Private Sub btnUnosRobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnosRobe.Click
        If cbR4K.Checked = True Then
            bVrstaPosiljke = "K"
        Else
            bVrstaPosiljke = "D"
        End If

        If bVrstaPosiljke = "K" Then
            Dim GridKola As New kola
            GridKola.Show()

        Else
            Dim GridDencane As New Dencane
            GridDencane.Show()
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        _OpenForm = "Empty"
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        dtK211.Clear()
        ClearDoc()
        Close()

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "     Pošiljalac"
        upit = "Posiljalac"
        helpUic.ShowDialog()
        'mIzlaz5   sifra
        'mIzlaz2   naziv 
        'mIzlaz1   land+Mesto
        'mIzlaz4   adresa

        Dim xNaziv As String = ""
        Dim xMesto As String = ""
        Dim xZemlja As String = ""
        Dim xAdresa As String = ""
        Dim xPovVrednost As String = ""

        Util.sNadjiKorisnika(mIzlaz5, xNaziv, xMesto, xZemlja, xAdresa, xPovVrednost)

        If xPovVrednost <> "" Then
            rtbR10.Text = "Nepostojeci korisnik"
            tbR11.Focus()
        Else
            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            rtbR10.Text = xNaziv & vbCrLf & vbCrLf & xZemlja & vbCrLf & xMesto & vbCrLf & xAdresa
            Me.tbR17.Focus()
        End If

        Me.tbStanicaOtp.BackColor = System.Drawing.Color.White

        Me.tbR17.Focus()

        Me.tbR11.Text = CType(mIzlaz5, Integer)
        mPosiljalac = CType(mIzlaz5, Integer)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "     Primalac"
        upit = "Primalac"
        helpUic.ShowDialog()

        Dim xNaziv As String = ""
        Dim xMesto As String = ""
        Dim xZemlja As String = ""
        Dim xAdresa As String = ""
        Dim xPovVrednost As String = ""

        Util.sNadjiKorisnika(mIzlaz5, xNaziv, xMesto, xZemlja, xAdresa, xPovVrednost)

        If xPovVrednost <> "" Then
            rtbR16.Text = "Nepostojeci korisnik"
            tbR11.Focus()
        Else
            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            rtbR16.Text = xNaziv & vbCrLf & vbCrLf & xZemlja & vbCrLf & xMesto & vbCrLf & xAdresa
            Me.tbR17.Focus()
        End If
        Me.tbR17.Text = CType(mIzlaz5, Integer)
        mPrimalac = CType(mIzlaz5, Integer)

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        UTLNaknadeR44(0) = Microsoft.VisualBasic.Trim(tb20a.Text)
        UTLNaknadeR44(1) = Microsoft.VisualBasic.Trim(tb20b.Text)
        UTLNaknadeR44(2) = Microsoft.VisualBasic.Trim(tb20c.Text)
        UTLNaknadeR44(3) = Microsoft.VisualBasic.Trim(tb20d.Text)

        Dim GridNaknade As New naknade

        GridNaknade.ShowDialog()

    End Sub

    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox4.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating


        If Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 1) = "1" Then

            tbUgovor.Enabled = False
            mTarifa = "36"
            Me.tbR60.Text = " Spt36"
            tbUgovor.Text = ""
            lblNajava.Visible = False
            tbNajava.Text = ""
            mNajava = ""
            tbNajava.Visible = False
            Me.ComboBox2.Enabled = False
            Me.ComboBox3.Enabled = True
            'Me.ComboBox3.SelectedIndex = 0
            Me.ComboBox3.Focus()

        Else
            Me.ComboBox2.Enabled = True
            Me.ComboBox3.Enabled = False
            Me.ComboBox3.SelectedIndex = -1
            mTarifa = "00"

            tbUgovor.Enabled = True
            tbUgovor.Focus()
        End If

    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUgovor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUgovor.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox2.Validating
        If (Me.ComboBox2.SelectedIndex) = 0 Then
            mVrstaPrevoza = "P"
        ElseIf (Me.ComboBox2.SelectedIndex) = 1 Then
            mVrstaPrevoza = "G"
        ElseIf (Me.ComboBox2.SelectedIndex) = 2 Then
            mVrstaPrevoza = "V"
        End If

        If eWebRazmena = "Da" Then
            tbBrojOtp.Focus()
        Else
            Me.tbStanicaOtp.SelectAll()
            tbStanicaOtp.Focus()
        End If

    End Sub

    Private Sub tbBrojOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub


    Private Sub DatumOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.Leave
        Me.tbStanicaPr.SelectAll()
        Me.tbStanicaPr.Focus()

    End Sub

    Private Sub DatumOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnKalk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKalk.Click
        Dim strRetVal As String = ""

        Dim bVrstaKursa As String = ""

        If mBrojUg = "200379" Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then         ' 25.07.2016 za sada; treba ukljuciti da li su cene u RSD ili EUR
            bVrstaKursa = "3"
        Else
            bVrstaKursa = "1"
        End If

        If bValuta = "17" Then
            NadjiKurs("17", bVrstaKursa, mOtpDatum, bKursOt, strRetVal)
            NadjiKurs("17", bVrstaKursa, mPrDatum, bKursPr, strRetVal)
            'mOutKurs = bKursPr                                  ' za sada; dovesti u vezu sa izjavom o placanju
        Else
            bKursOt = 1
            bKursPr = 1
            'mOutKurs = 1
        End If


        If dtKola.Rows.Count > 0 And cbR4K.Checked = True Then          ' kolske
            mStanica1 = Me.tbStanicaOtp.Text
            mStanica2 = Me.tbStanicaPr.Text

            UTLNaknadeR44(0) = Microsoft.VisualBasic.Trim(tb20a.Text)
            UTLNaknadeR44(1) = Microsoft.VisualBasic.Trim(tb20b.Text)
            UTLNaknadeR44(2) = Microsoft.VisualBasic.Trim(tb20c.Text)
            UTLNaknadeR44(3) = Microsoft.VisualBasic.Trim(tb20d.Text)

            mSifraIzjave = "0"

            If Me.CheckBox1.Checked = True Then
                mSifraIzjave = "1"
            End If
            If Me.CheckBox2.Checked = True Then
                mSifraIzjave = "2"
            End If
            If Me.CheckBox3.Checked = True Then
                mSifraIzjave = "3"
            End If
            If Me.CheckBox4.Checked = True Then
                mSifraIzjave = "4"
            End If

            '============= prikaz naknada
            If IzborSaobracaja = "1" Then
                bNadjiPrevozninuGlavni()

                '================== konverzija EUR  -> RSD ==========================
                'Dim strRetVal As String = ""
                'Dim mOutKurs As Decimal = 0
                Dim mIznosDin As Decimal = 0

                If bValuta = "17" Then
                    Dim bKurs As Decimal
                    If bIzTBPrevoznina = True Then
                        mIznosDin = mPrevoznina
                    Else
                        If mSifraIzjave = "1" Then      ' franko svi troskovi
                            bKurs = bKursOt
                        ElseIf mSifraIzjave = "2" Then  ' franko prevoznina ukljucivo
                            bKurs = bKursOt
                        ElseIf mSifraIzjave = "3" Then  ' franko prevoznina
                            bKurs = bKursOt

                            'ElseIf mSifraIzjave = "4" Then  ' franko do iznosa

                        ElseIf mSifraIzjave = "0" Then  ' upuceno sve
                            bKurs = bKursPr
                        End If

                        mIznosDin = bKurs * bbPrevozninaUEvrima
                        bZaokruziNaDeseteNavise(mIznosDin)
                    End If
                    mPrevoznina = mIznosDin
                End If
                'bKursPr = mOutKurs
                '====================================================================
                If mSifraIzjave = "1" Then 'franko svi troskovi
                    'tbPrevF.Text = mPrevoznina
                    tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevU.Text = 0
                    bPrevozninaLevo = mPrevoznina
                    bPrevozninaDesno = 0
                ElseIf mSifraIzjave = "2" Then ' franko prevoznina ukljucivo
                    'tbPrevF.Text = mPrevoznina
                    tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevU.Text = 0
                    bPrevozninaLevo = mPrevoznina
                    bPrevozninaDesno = 0
                ElseIf mSifraIzjave = "3" Then 'franko prevoznina 
                    'tbPrevF.Text = mPrevoznina
                    tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevU.Text = 0
                    bPrevozninaLevo = mPrevoznina
                    bPrevozninaLevo = 0
                ElseIf mSifraIzjave = "4" Then 'franko do iznosa
                Else ' upuceno svi troskovi
                    'tbPrevU.Text = mPrevoznina
                    tbPrevU.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevF.Text = 0
                    bPrevozninaLevo = 0
                    bPrevozninaDesno = mPrevoznina
                End If

                '------------------------------------------------

                tbPrevStav1.Text = Format(bVozarinskiStavPoKolima, "###,###,##0.00")
                tbR54_1.Text = dtNhm.Rows(0).Item(4)
                tbR42a.Text = dtNhm.Rows(0).Item(1)
                tbR41Suma.Text = dtNhm.Compute("SUM(Masa)", String.Empty)

                Dim Rz1, Rz2, Rz3 As String
                Dim M1, M2, M3 As Decimal
0:              bNadjiRacunskuMasuPoPosiljciPoRazredima(Rz1, M1, Rz2, M2, Rz3, M3)

                If M1 > 0 Then
                    tbR54_1.Text = Rz1
                    tbR57_1.Text = Format(M1, "###,###,##0.00")
                End If
                If M2 > 0 Then
                    tbR54_1.Text = Rz2
                    tbR57_2.Text = Format(M2, "###,###,##0.00")
                End If
                If M3 > 0 Then
                    tbR54_1.Text = Rz3
                    tbR57_3.Text = Format(M3, "###,###,##0.00")
                End If

                'tbR21_1.Text = dtKola.Rows(0).Item(3)
                'Me.tbIBK.Text = dtKola.Rows(0).Item(0)
                'tbR23_1.Text = dtKola.Rows(0).Item(7)
                'tbR24_1.Text = dtKola.Rows(0).Item(6)
                'tbR25a_1.Text = dtKola.Rows(0).Item(2)
                'tbR25b_1.Text = dtKola.Rows.Count
                'tbR26_1.Text = dtKola.Rows(0).Item(5)


                ' zbog drugacije strukture dtKola:
                tbR21_1.Text = dtKola.Rows(0).Item(4)               ' serija
                Me.tbIBK.Text = dtKola.Rows(0).Item(0)              ' IBK
                tbR23_1.Text = dtKola.Rows(0).Item(7)               ' granica tovarenja
                tbR24_1.Text = dtKola.Rows(0).Item(1)               ' tara
                tbR25a_1.Text = dtKola.Rows(0).Item(9)              ' tip
                tbR25b_1.Text = dtKola.Rows.Count                   ' kolicina
                tbR26_1.Text = dtKola.Rows(0).Item(2)               ' broj osovina





                Me.tbSumaNeto.Text = tbR24_1.Text
                Me.tbSumaKola.Text = dtKola.Rows.Count
                Me.tbSumaOsovina.Text = tbR26_1.Text


                Dim i_TotalNak As String = ""
                Dim i_Pronasao As Int32 = 0
                Dim tmp_Naknada As Decimal
                'Dim tmp_pdv_f As Decimal
                'Dim tmp_pdv_u As Decimal
                Dim tmp_suma_f As Decimal
                Dim tmp_suma_u As Decimal
                Dim Nak_Red As DataRow
                Dim tmp_red As Int16 = 1

                If dtNaknade.Rows.Count > 0 Then
                    Dim bkurs As Decimal = 1
                    For Each Nak_Red In dtNaknade.Rows
                        If Nak_Red.Item("Sifra") <> "62" Then

                            i_TotalNak = Nak_Red.Item("Sifra")
                            i_Pronasao = 0

                            If mSifraIzjave = "1" Then 'franko svi troskovi
                                bkurs = bKursOt
                                If tmp_red = 1 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak1F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak1F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak1U.Text = 0
                                    tbA79a1.Text = Nak_Red.Item("Sifra")
                                    tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                    tb62na.Text = bNazivNaknadeArr(0)
                                ElseIf tmp_red = 2 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak2F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak2F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak2U.Text = 0
                                    tbA79a2.Text = Nak_Red.Item("Sifra")
                                    tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nb.Text = bNazivNaknadeArr(1)
                                ElseIf tmp_red = 3 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak3F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak3F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak3U.Text = 0
                                    tbA79a3.Text = Nak_Red.Item("Sifra")
                                    tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nc.Text = bNazivNaknadeArr(2)
                                ElseIf tmp_red = 4 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak4F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak4F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak4U.Text = 0
                                    tbA79a4.Text = Nak_Red.Item("Sifra")
                                    tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nd.Text = bNazivNaknadeArr(3)
                                End If

                            ElseIf mSifraIzjave = "2" Then ' franko prevoznina ukljucivo


                                For aa As Int16 = 0 To 3
                                    If UTLNaknadeR44(aa) = i_TotalNak Then
                                        i_Pronasao = 1
                                        Exit For
                                    End If
                                Next

                                If i_Pronasao = 1 Then
                                    bkurs = bKursOt
                                    If tmp_red = 1 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak1F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak1F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak1U.Text = 0
                                        tbA79a1.Text = Nak_Red.Item("Sifra")
                                        tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                        tb62na.Text = bNazivNaknadeArr(0)
                                    ElseIf tmp_red = 2 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak2F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak2F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak2U.Text = 0
                                        tbA79a2.Text = Nak_Red.Item("Sifra")
                                        tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nb.Text = bNazivNaknadeArr(1)
                                    ElseIf tmp_red = 3 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak3F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak3F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak3U.Text = 0
                                        tbA79a3.Text = Nak_Red.Item("Sifra")
                                        tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nc.Text = bNazivNaknadeArr(2)
                                    ElseIf tmp_red = 4 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak4F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak4F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak4U.Text = 0
                                        tbA79a4.Text = Nak_Red.Item("Sifra")
                                        tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nd.Text = bNazivNaknadeArr(3)
                                    End If
                                Else
                                    bKurs = bKursPr
                                    If tmp_red = 1 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak1U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak1F.Text = 0
                                        tbA79a1.Text = Nak_Red.Item("Sifra")
                                        tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                        tb62na.Text = bNazivNaknadeArr(0)
                                    ElseIf tmp_red = 2 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak2U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak2F.Text = 0
                                        tbA79a2.Text = Nak_Red.Item("Sifra")
                                        tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nb.Text = bNazivNaknadeArr(1)
                                    ElseIf tmp_red = 3 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak3U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak3F.Text = 0
                                        tbA79a3.Text = Nak_Red.Item("Sifra")
                                        tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nc.Text = bNazivNaknadeArr(2)
                                    ElseIf tmp_red = 4 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak4U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak4F.Text = 0
                                        tbA79a4.Text = Nak_Red.Item("Sifra")
                                        tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nd.Text = bNazivNaknadeArr(3)
                                    End If
                                End If

                            ElseIf mSifraIzjave = "3" Then 'franko prevoznina 

                                bKurs = bKursPr
                                If tmp_red = 1 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak1U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak1F.Text = 0
                                    tbA79a1.Text = Nak_Red.Item("Sifra")
                                    tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                    tb62na.Text = bNazivNaknadeArr(0)
                                ElseIf tmp_red = 2 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak2U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak2F.Text = 0
                                    tbA79a2.Text = Nak_Red.Item("Sifra")
                                    tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nb.Text = bNazivNaknadeArr(1)
                                ElseIf tmp_red = 3 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak3U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak3F.Text = 0
                                    tbA79a3.Text = Nak_Red.Item("Sifra")
                                    tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nc.Text = bNazivNaknadeArr(2)
                                ElseIf tmp_red = 4 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak4U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak4F.Text = 0
                                    tbA79a4.Text = Nak_Red.Item("Sifra")
                                    tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nd.Text = bNazivNaknadeArr(3)
                                End If
                            ElseIf mSifraIzjave = "4" Then ' franko do iznosa

                            Else ' upuceno svi troskovi
                                bKurs = bKursPr
                                If tmp_red = 1 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak1U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak1F.Text = 0
                                    tbA79a1.Text = Nak_Red.Item("Sifra")
                                    tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                    tb62na.Text = bNazivNaknadeArr(0)
                                ElseIf tmp_red = 2 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak2U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak2F.Text = 0
                                    tbA79a2.Text = Nak_Red.Item("Sifra")
                                    tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nb.Text = bNazivNaknadeArr(1)
                                ElseIf tmp_red = 3 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak3U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak3F.Text = 0
                                    tbA79a3.Text = Nak_Red.Item("Sifra")
                                    tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nc.Text = bNazivNaknadeArr(2)
                                ElseIf tmp_red = 4 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak4U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak4F.Text = 0
                                    tbA79a4.Text = Nak_Red.Item("Sifra")
                                    tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nd.Text = bNazivNaknadeArr(3)
                                End If
                            End If
                            tmp_red = tmp_red + 1
                        End If
                    Next
                End If

                '--- pdv 18%

                bNadjiPDVKoef(mDatumKalk, bPDVKoef, bPDVKoefString)
                Dim bPDV As Decimal = 0
                If Me.cbPDV.Checked = True Then
                    bPDV = bPDVKoef
                Else
                    bPDV = 0
                End If

                '''If Me.cbPDV.Checked = True Then

                '''    tmp_pdv_f = (CType(tbPrevF.Text, Decimal) + CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)) * PDVKoef
                '''    tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")

                '''    If CType(Me.tbPdvIznosF.Text, Decimal) > 0 Then
                '''        Me.tbPDVF.Text = "62.1"
                '''        Me.tbPDV.Text = "PDV 18%"
                '''    Else
                '''        Me.tbPDVF.Text = ""
                '''    End If

                '''    tmp_pdv_u = (CType(tbPrevU.Text, Decimal) + CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)) * PDVKoef
                '''    tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")

                '''    If CType(Me.tbPdvIznosU.Text, Decimal) > 0 Then
                '''        Me.tbPDVU.Text = "62.0"
                '''        Me.tbPDV.Text = "PDV 18%"
                '''    Else
                '''        Me.tbPDVU.Text = ""
                '''    End If
                '''    If Me.cbPDV.Checked = False Then
                '''        Me.tbPDV.Text = ""
                '''    End If

                '''    tmp_suma_f = CType(tbPrevF.Text, Decimal) + _
                '''                      CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal) + _
                '''                      CType(Me.tbPdvIznosF.Text, Decimal)
                '''    tbSumaF.Text = Format(tmp_suma_f, "###,###,##0.00")
                '''    tmp_suma_u = CType(tbPrevU.Text, Decimal) + _
                '''                      CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + _
                '''                      CType(Me.tbPdvIznosU.Text, Decimal)
                '''    tbSumaU.Text = Format(tmp_suma_u, "###,###,##0.00")


                '''    bSumaNaknadaLevo = CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)
                '''    bSumaNaknadaDesno = CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)

                '''Else

                '''End If
                If Not (bIzTBPrevoznina = True And bTarifa72 = 91) Then
                    tmp_pdv_f = (CType(tbPrevF.Text, Decimal) + CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)) * bPDV
                    tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")
                End If

                'If (bTarifa72 = 91) And mSifraIzjave = "0" Then
                '    If mSifraIzjave = "0" Then
                '        tmp_pdv_f = 0
                '        tmp_pdv_u = bPrevoznina91ZaPDV
                '        tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")
                '    Else
                '        tmp_pdv_f = bPrevoznina91ZaPDV

                '        tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")
                '    End If
                'End If

                If Not (mSifraIzjave = "0") And (bTarifa72 = 91) Then
                    tmp_pdv_f = bPrevoznina91ZaPDV * bPDV
                    tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")
                End If

                If CType(Me.tbPdvIznosF.Text, Decimal) > 0 Then
                    Me.tbPDVF.Text = "62.1"
                    Me.tbPDV.Text = bPDVKoefString
                Else
                    Me.tbPDVF.Text = ""
                End If

                If (tbR50.Text = Nothing) Or (tbR50.Text = "") Then
                    tbR50.Text = 0
                End If


                If Not (bIzTBPrevoznina = True And bTarifa72 = 91) Then
                    tmp_pdv_u = (CType(tbPrevU.Text, Decimal) + CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + CType(tbR50.Text, Decimal)) * bPDV
                    tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")
                End If

                If (mSifraIzjave = "0") And (bTarifa72 = 91) Then
                    tmp_pdv_u = bPrevoznina91ZaPDV * bPDV
                    tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")
                End If

                If CType(Me.tbPdvIznosU.Text, Decimal) > 0 Then
                    Me.tbPDVU.Text = "62.2"
                    Me.tbPDV.Text = "PDV " + bPDVKoefString
                Else
                    Me.tbPDVU.Text = ""
                End If
                If Me.cbPDV.Checked = False Then
                    Me.tbPDV.Text = ""
                End If

                Dim FPDV As Decimal = CType(Me.tbPdvIznosF.Text, Decimal)
                Dim UPDV As Decimal = CType(Me.tbPdvIznosU.Text, Decimal)

                ' dokomentarisano 23.1.2013
                If bTarifa72 = 91 Then                ' P9
                    If Not (bIzTBPrevoznina = True) Then
                        '''tbPrevF.Text = 0
                        '''tbPrevU.Text = 0
                    End If
                    bIznoseNaknadaUTLNaNulu()
                    '''FPDV = 0
                    '''UPDV = 0
                End If

                If bTarifa72 = 99 Then                ' besplatan prevoz, sve nula
                    tbPrevF.Text = 0
                    tbPrevU.Text = 0
                    bIznoseNaknadaUTLNaNulu()
                    bIznosePDVUTLNaNulu()
                End If

                tmp_suma_f = CType(tbPrevF.Text, Decimal) + _
                                  CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal) + _
                                  FPDV

                If bTarifa72 = 91 Then
                    tmp_suma_f = 0
                End If

                tbSumaF.Text = Format(tmp_suma_f, "###,###,##0.00")

                tmp_suma_u = CType(tbPrevU.Text, Decimal) + _
                                  CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + CType(tbR50.Text, Decimal) + _
                                  UPDV

                If bTarifa72 = 91 Then
                    tmp_suma_u = 0
                End If

                tbSumaU.Text = Format(tmp_suma_u, "###,###,##0.00")


                bSumaNaknadaLevo = CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)
                bSumaNaknadaDesno = CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)



                bSumaLevo = tmp_suma_f
                bSumaDesno = tmp_suma_u

            End If
            '============= end prikaz naknada


            '============= rekalkulacija razlika
            Dim mBlagajna As Decimal = CDec(FR_Stanica.Text)
            FR_Stanica.Text = Format(mBlagajna, "###,###,##0.00")

            Dim mRazlika As Decimal = CDec(FR_Stanica.Text)
            Dim mSumaDinari As Decimal = CDec(tbSumaF.Text)
            mRazlika = mBlagajna - mSumaDinari
            If bTarifa72 = 91 Then
                mRazlika = 0
            End If
            bRazlikaFr = mRazlika
            FR_Razlika.Text = Format(mRazlika, "###,###,##0.00")

            Dim mBlagajna2 As Decimal = CDec(UP_Stanica.Text)
            UP_Stanica.Text = Format(mBlagajna2, "###,###,##0.00")

            Dim mRazlika2 As Decimal = CDec(UP_Stanica.Text)
            Dim mSumaDinari2 As Decimal = CDec(tbSumaU.Text)
            mRazlika2 = mBlagajna2 - mSumaDinari2
            If bTarifa72 = 91 Then
                mRazlika2 = 0
            End If
            bRazlikaUp = mRazlika2
            UP_Razlika.Text = Format(mRazlika2, "###,###,##0.00")
            If (bRazlikaFr <= -250) Or (bRazlikaUp <= 250) Then
                Me.Button6.Focus()
            Else
                Me.btnUpis.Focus()
            End If
            '============= rekalkulacija razlika

        Else
            'If cbR4D.Checked = True Then            ' dencane
            '    bNadjiPrevozninuGlavni()
            'Else
            '    Try
            '        MsgBox("Niste uneli podatke o kolima!")
            '    Catch ex As Exception

            '    End Try

            'End If

        End If

        bOsveziIznoseLevoDesno()

    End Sub

    Private Sub Daljinar()
        Dim sql_text As String

        '---------------------------------------------------------------------------
        If IzborSaobracaja = "1" Then
            mStanica1 = Me.tbStanicaOtp.Text
            mStanica2 = Me.tbStanicaPr.Text

            If Len(mManipulativnoMesto1) = 5 Then
                tmp_MMStanica1 = mStanica1
                mStanica1 = mManipulativnoMesto1
            End If
            If Len(mManipulativnoMesto2) = 5 Then
                tmp_MMStanica2 = mStanica2
                mStanica2 = mManipulativnoMesto2
            End If
        End If

        '----------------------------------------------------------------------------
        If Len(mStanica1) > 0 And Len(mStanica2) > 0 Then
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            'If Int(mStanica1) < Int(mStanica2) Then
            '    sql_text = "SELECT TarifskiKm, StvarniKm " & _
            '                             "FROM dbo.ZsDaljinar " & _
            '                             "WHERE (Stanica1 = '" & mStanica1 & "') AND (Stanica2 = '" & mStanica2 & "')"

            'Else
            '    sql_text = "SELECT TarifskiKm, StvarniKm " & _
            '                             "FROM dbo.ZsDaljinar " & _
            '                             "WHERE (Stanica1 = '" & mStanica2 & "') AND (Stanica2 = '" & mStanica1 & "')"

            'End If

            If Int(mStanica1) < Int(mStanica2) Then
                sql_text = "SELECT TarifskiKm, StvarniKm,OpisPuta " & _
                                         "FROM dbo.ZsDaljinar " & _
                                         "WHERE (Stanica1 = '" & mStanica1 & "') AND (Stanica2 = '" & mStanica2 & "')"

            Else
                sql_text = "SELECT TarifskiKm, StvarniKm,OpisPuta  " & _
                                         "FROM dbo.ZsDaljinar " & _
                                         "WHERE (Stanica1 = '" & mStanica2 & "') AND (Stanica2 = '" & mStanica1 & "')"

            End If


            Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
            Dim rdrDalj As SqlClient.SqlDataReader
            Dim bOpisPuta As String

            rdrDalj = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdrDalj.Read()
                tbR53.Text = rdrDalj.GetInt16(0)
                bTkm = tbR53.Text
                bSkm = rdrDalj.GetInt16(1)
                If (rdrDalj.IsDBNull(2)) Then
                    bOpisPuta = ""
                Else
                    bOpisPuta = rdrDalj.GetString(2)
                End If
            Loop
            rdrDalj.Close()
            DbVeza.Close()

            If mStanica1 = mStanica2 Then
                bTkm = 0
                bSkm = 0
                tbR53.Text = "0"
                'bOpisPuta = rdrDalj.GetString(2)
            End If

            mStanica1 = Me.tbStanicaOtp.Text
            mStanica2 = Me.tbStanicaPr.Text

        Else
            bTkm = 0
            bSkm = 0
            tbR53.Text = "0"
        End If
    End Sub

    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked = True Then
            mSifraIzjave = 1
            Me.CheckBox2.Checked = False
            Me.CheckBox3.Checked = False
            Me.CheckBox4.Checked = False
        Else
            mSifraIzjave = 0
            Me.CheckBox2.Checked = False
            Me.CheckBox3.Checked = False
            Me.CheckBox4.Checked = False
        End If

    End Sub

    Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        If CheckBox2.Checked = True Then
            mSifraIzjave = 2
            Me.CheckBox1.Checked = False
            Me.CheckBox3.Checked = False
            Me.CheckBox4.Checked = False
        Else
            mSifraIzjave = 0
            Me.CheckBox1.Checked = False
            Me.CheckBox3.Checked = False
            Me.CheckBox4.Checked = False
        End If

    End Sub

    Private Sub CheckBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.Click
        If CheckBox3.Checked = True Then
            mSifraIzjave = 3
            Me.CheckBox2.Checked = False
            Me.CheckBox1.Checked = False
            Me.CheckBox4.Checked = False
        Else
            mSifraIzjave = 0
            Me.CheckBox2.Checked = False
            Me.CheckBox1.Checked = False
            Me.CheckBox4.Checked = False
        End If

    End Sub

    Private Sub CheckBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.Click
        If CheckBox4.Checked = True Then
            mSifraIzjave = 4
            Me.CheckBox2.Checked = False
            Me.CheckBox3.Checked = False
            Me.CheckBox1.Checked = False
            tbR44Iznos.Focus()
        Else
            mSifraIzjave = 0
            Me.CheckBox2.Checked = False
            Me.CheckBox3.Checked = False
            Me.CheckBox1.Checked = False
            Button18.Focus()
        End If

    End Sub

    Private Sub cbR4K_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbR4K.Click
        If cbR4K.Checked = True Then
            Me.cbR4D.Checked = False
        Else
            Me.cbR4D.Checked = True
        End If
    End Sub

    Private Sub cbR4D_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbR4D.Click
        If cbR4D.Checked = True Then
            Me.cbR4K.Checked = False
        Else
            Me.cbR4K.Checked = True
        End If
    End Sub


    Private Sub ComboBox4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox4.Validating
        tbR8.Text = Microsoft.VisualBasic.Left(Me.ComboBox4.Text, 1)
        bVrstaSaobracaja = tbR8.Text
        bVrstaSaobracajaTemp = bVrstaSaobracaja
        'If Microsoft.VisualBasic.Left(Me.ComboBox4.Text, 1) = "0" Then
        '    bValuta = "72"
        'Else
        '    bValuta = "17"
        'End If

        If bVrstaSaobracaja = 0 Then
            bValuta = "72"
            Label25.Visible = False
            Label26.Visible = False
            Label28.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            lblOtpKurs.Visible = False
            lblPrKurs.Visible = False
            If mBrojUg = "200379" Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then         ' 25.07.2016 za sada; treba ukljuciti da li su cene u RSD ili EUR
                Label25.Visible = True
                Label26.Visible = True
                Label28.Visible = True
                TextBox3.Visible = True
                TextBox4.Visible = True
                bNadjiIPrikaziKurseve("17")
            End If
        Else
            bValuta = "17"

            'If Not (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then
            '    bNadjiIPrikaziKurseve(bValuta)
            'End If
            If Not ((mVrstaObracuna = "CO") Or (mBrojUg = "625501") Or (mBrojUg = "048601")) Then
                bNadjiIPrikaziKurseve(bValuta)
            End If
        End If

        If (bVrstaSaobracaja = 3) Or (bVrstaSaobracaja = 4) Then
            MsgBox("Lucki uvoz i izvoz nisu dozvoljeni")
            ComboBox4.Focus()
        End If
    End Sub

    Private Sub tbBrojOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojOtp.Validating

        'Dim bStan1, bStan2 As String
        'Dim bBroj1, bBroj2 As Integer
        'Dim bDatum1, bDatum2 As Date
        'Dim bRmes, bRGod As String
        'Dim bRecID As Integer
        'Dim bStanID As String
        'Dim bSaob As Integer
        'Dim bRetValue As String = ""

        'bRecID = 0
        'bNadjiTLUBaziPoOtpAdm("72" & tbStanicaOtp.Text, tbBrojOtp.Text, bDatum1, bStan2, bBroj2, bDatum2, bRmes, bRGod, bRecID, bStanID, bSaob, bRetValue)
        'If bRecID <> 0 And MasterAction = "New" Then
        '    errText14 = "Ovakvo otpravljanje je vec uneto"
        '    dtError.NewRow()
        '    dtError.Rows.Add(New Object() {errText14})
        'End If

        'bRecID = 0
        'bNadjiTLUBaziPoPrAdm("72" & tbStanicaPr.Text, tbBrojPr.Text, bDatum2, bStan1, bBroj1, bDatum1, bRmes, bRGod, bRecID, bStanID, bSaob, bRetValue)
        'If bRecID <> 0 And MasterAction = "New" Then
        '    errText15 = "Ovakvo prispece je vec uneto"
        '    dtError.NewRow()
        '    dtError.Rows.Add(New Object() {errText15})
        'End If


        If tbBrojOtp.Text = "0" Then
            ErrorProvider1.SetError(Label15, "Broj otpravljanja ne moze da bude nula!")
            tbBrojOtp.Focus()
        Else
            If tbBrojOtp.Text = Nothing Then
                ErrorProvider1.SetError(Label15, "Neispravan broj otpravljanja!")
                tbBrojOtp.Focus()
            Else
                If IsNumeric(tbBrojOtp.Text) = True Then
                    Me.tbR13_2.Text = Me.tbBrojOtp.Text

                    ErrorProvider1.SetError(Label15, "")
                Else
                    ErrorProvider1.SetError(Label15, "Neispravan unos!")
                    tbBrojOtp.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        If dgError.Visible = True Then
            dgError.Visible = False
            GroupBox6.Visible = True
        Else

            dgError.Visible = True
            dgError.Left = 780
            dgError.Top = 1
            dgError.Width = 245
            dgError.Height = 600
            dgError.CaptionText = "Kontrola podataka"

            Dim errText1, errText2, errText3, errText4, errText5, errText6, errText7, errText8 As String
            Dim errText9, errText10, errText11, errText12, errText13, errText14, errText15 As String
            dtError.Clear()

            ' ----------- kontrola 
            'If Me.rtbR10.Text = Nothing Then
            '    errText14 = "Primalac"
            '    dtError.NewRow()
            '    dtError.Rows.Add(New Object() {errText14})
            'End If
            'If Me.rtbR16.Text = Nothing Then
            '    errText14 = "Posiljalac"
            '    dtError.NewRow()
            '    dtError.Rows.Add(New Object() {errText14})
            'End If
            If mTarifa = Nothing Or Len(mTarifa) < 2 Then
                errText9 = "Tarifa"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText9})
            End If
            'If Me.tbR53.Text = Nothing Then 'Or CType(tbKm1.Text, Integer) = 0 Then
            If ((bTkm <> 0) And (bSkm = 0)) Then
                errText5 = "Neispravno rastojanje"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText5})
            End If
            If Me.tbR12Sifra.Text = Nothing Then
                errText6 = "Otpravna stanica"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText6})
            End If
            If Me.tbBrojOtp.Text = Nothing Then
                errText8 = "Broj otpravljanja"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText8})
            ElseIf CType(Me.tbBrojOtp.Text, Int32) = 0 Then
                errText8 = "Broj otpravljanja"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText8})
            End If
            If Me.tbStanicaPr.Text = Nothing Then
                errText10 = "Uputna stanica"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText10})
            End If
            If cbR4K.Checked = True Then
                If (dtKola.Rows.Count = 0 Or dtNhm.Rows.Count = 0) And Not (bTarifa72 = 94) Then
                    errText11 = "Unos robe"
                    dtError.NewRow()
                    dtError.Rows.Add(New Object() {errText11})
                End If
            End If

            If bVrstaSaobracaja = 5 Then
                If Not (Me.tbStanicaOtp.Text = "13670" Or Me.tbStanicaOtp.Text = "14170" Or _
                    Me.tbStanicaOtp.Text = "16051" Or Me.tbStanicaOtp.Text = "16871" Or _
                    Me.tbStanicaOtp.Text = "21001" Or Me.tbStanicaOtp.Text = "23801" Or Me.tbStanicaOtp.Text = "16509" Or _
                    mManipulativnoMesto1 = "13670" Or mManipulativnoMesto1 = "14170" Or _
                    mManipulativnoMesto1 = "16051" Or mManipulativnoMesto1 = "16871" Or _
                    mManipulativnoMesto1 = "21001" Or mManipulativnoMesto1 = "23801" Or mManipulativnoMesto1 = "16509") Then
                    errText12 = "Otpravna stanica (m.m.) nije recna"
                    dtError.NewRow()
                    dtError.Rows.Add(New Object() {errText12})
                End If
            End If

            If bVrstaSaobracaja = 6 Then
                If Not (Me.tbStanicaPr.Text = "13670" Or Me.tbStanicaPr.Text = "14170" Or _
                    Me.tbStanicaPr.Text = "16051" Or Me.tbStanicaPr.Text = "16871" Or _
                    Me.tbStanicaPr.Text = "21001" Or Me.tbStanicaPr.Text = "23801" Or Me.tbStanicaPr.Text = "16509" Or _
                    mManipulativnoMesto2 = "13670" Or mManipulativnoMesto2 = "14170" Or _
                    mManipulativnoMesto2 = "16051" Or mManipulativnoMesto2 = "16871" Or _
                    mManipulativnoMesto2 = "21001" Or mManipulativnoMesto2 = "23801" Or mManipulativnoMesto2 = "16509") Then
                    errText13 = "Uputna stanica (m.m.) nije recna"
                    dtError.NewRow()
                    dtError.Rows.Add(New Object() {errText13})
                End If
            End If

            Dim bStan1, bStan2 As String
            Dim bBroj1, bBroj2 As Integer
            Dim bDatum1, bDatum2 As Date
            Dim bRmes, bRGod As String
            Dim bRecID As Integer
            Dim bStanID As String
            Dim bSaob As Integer
            Dim bRetValue As String = ""

            bRecID = 0
            bNadjiTLUBaziPoOtpAdm("72" & tbStanicaOtp.Text, tbBrojOtp.Text, bDatum1, bStan2, bBroj2, bDatum2, bRmes, bRGod, bRecID, bStanID, bSaob, bRetValue)
            If bRecID <> 0 And MasterAction = "New" Then
                errText14 = "Ovakvo otpravljanje je vec uneto"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText14})
            End If

            bRecID = 0
            bNadjiTLUBaziPoPrAdm("72" & tbStanicaPr.Text, tbBrojPr.Text, bDatum2, bStan1, bBroj1, bDatum1, bRmes, bRGod, bRecID, bStanID, bSaob, bRetValue)
            If bRecID <> 0 And MasterAction = "New" Then
                errText15 = "Ovakvo prispece je vec uneto"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText15})
            End If

            If dtError.Rows.Count = 0 Then
                dgError.Visible = False
                ErrKontrola = "OK"
            Else
                dgError.Visible = True
                ErrKontrola = "NO"
                GroupBox6.Visible = False
            End If
        End If

        If (tbStanicaOtp.Text = tbStanicaPr.Text) And (CType(tbR53.Text, Integer) = 0) Then
            MsgBox("Proveriti unos! Otpravna i uputna stanica su iste, a tarifski kilometri su nula! ")
        End If

    End Sub
    Private Sub FormatErrGrid()
        If err Is Nothing Then
            dgError.DataSource = dtError
        Else
            dgError.DataSource = err.Tables(0)
        End If
    End Sub

    Private Sub FormUTL_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        'If MasterAction = "Upd" Or AkcijaZaPreuzimanje = "Da" Then
        '    'bOsveziIzBazePriUpd()
        '    bPrikazIzSloga()
        'End If

        'If bVrstaSaobracaja <> 0 Then
        '    bNadjiIPrikaziKurseve(bValuta)
        'Else
        '    Label25.Visible = False
        '    TextBox3.Visible = False
        '    TextBox4.Visible = False
        '    If mBrojUg = "200379" Then
        '        Label25.Visible = True
        '        TextBox3.Visible = True
        '        TextBox4.Visible = True
        '        bNadjiIPrikaziKurseve("17")
        '    End If

        'End If



        '    Const SND_ASYNC As Integer = &H1
        '    Const SND_FILENAME As Integer = &H20000
        '    Const SND_NODEFAULT As Integer = &H2
        'Declare Function PlaySound Lib "winmm.dll" Alias "PlaySoundA" (ByVal lpszName As String, ByVal hModule As Integer, ByVal dwFlags As Integer) As Integer

        'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'PlaySound(Application.StartupPath & "\Media\tada.wav", 0, SND_NODEFAULT Or SND_ASYNC Or SND_FILENAME)
        'End Sub


        If _OpenForm = "Empty" Then        ' unos prvog ili novog TL (posle upisa u bazu)
            Me.cbPDV.Focus()

        ElseIf _OpenForm = "Roba" Or _OpenForm = "Dencane" Then 'posle unosa robe
            If _OpenForm = "Roba" Then

            End If
            btnUnosRobe.Text = dtKola.Rows.Count
            btnKalk_Click(Me, Nothing)
            Button4_Click(Me, Nothing)
            'Me.FR_Stanica.Focus()
            'Me.CheckBox1.Focus()

            Button18.Focus()
            'bOsveziRobuNaTL()

        ElseIf _OpenForm = "Naknade" Then 'posle unosa naknada

            bbDatum = mDatumKalk            ' iz FormLoad

            mStanica1 = Me.tbStanicaOtp.Text
            mStanica2 = Me.tbStanicaPr.Text
            bIzbrisiNaknadeNaTL()
            'btnKalk_Click(Me, Nothing)         iskljucena kalkulacija zbog rucnog unosa prevoznine
            bOsveziIznoseLevoDesno()
            Me.FR_Stanica.Focus()
            'Me.btnKalk.Focus()
            Me.FR_Razlika.Focus()
            ''If IzborSaobracaja = "1" Then
            ''    Dim i_TotalNak As String = ""
            ''    Dim i_Pronasao As Int32 = 0
            ''    Dim Nak_Red As DataRow
            ''    Dim tmp_red As Int16 = 1

            ''    If dtNaknade.Rows.Count > 0 Then

            ''        For Each Nak_Red In dtNaknade.Rows
            ''            i_TotalNak = Nak_Red.Item("Sifra")
            ''            i_Pronasao = Array.BinarySearch(UTLNaknadeR44, i_TotalNak)

            ''            If i_Pronasao >= 0 Then
            ''                If tmp_red = 1 Then
            ''                    tbNak1F.Text = Nak_Red.Item("Iznos")
            ''                ElseIf tmp_red = 2 Then
            ''                    tbNak2F.Text = Nak_Red.Item("Iznos")
            ''                ElseIf tmp_red = 3 Then
            ''                    tbNak3F.Text = Nak_Red.Item("Iznos")
            ''                ElseIf tmp_red = 4 Then
            ''                    tbNak4F.Text = Nak_Red.Item("Iznos")
            ''                End If
            ''            Else
            ''                If tmp_red = 1 Then
            ''                    tbNak1U.Text = Nak_Red.Item("Iznos")
            ''                ElseIf tmp_red = 2 Then
            ''                    tbNak2U.Text = Nak_Red.Item("Iznos")
            ''                ElseIf tmp_red = 3 Then
            ''                    tbNak3U.Text = Nak_Red.Item("Iznos")
            ''                ElseIf tmp_red = 4 Then
            ''                    tbNak4U.Text = Nak_Red.Item("Iznos")
            ''                End If
            ''            End If
            ''            tmp_red = tmp_red + 1

            ''        Next

            ''    End If
            ''End If

        ElseIf _OpenForm = "K211" Then 'posle K211
            bOsveziIznoseLevoDesno()
            Me.btnUpis.Focus()

        ElseIf _OpenForm = "VPP" Then 'posle VPP
            Me.tbR53_Validating(Me, Nothing)
        End If


        cmbManipulativnaMestaEx.SelectedIndex = ExMMIndex
        cmbManipulativnaMestaIm.SelectedIndex = ImMMIndex


        Dim Raz1, Raz2, Raz3 As String
        Dim UkRacMasa1, UkRacMasa2, UkRacMasa3 As Decimal

        bNadjiRacunskuMasuPoPosiljciPoRazredima(Raz1, UkRacMasa1, Raz2, UkRacMasa2, Raz3, UkRacMasa3)
        If UkRacMasa1 > 0 Then
            tbR54_1.Text = Raz1
            tbR57_1.Text = UkRacMasa1
        End If
        If UkRacMasa2 > 0 Then
            tbR54_2.Text = Raz2
            tbR57_2.Text = UkRacMasa2
        End If
        If UkRacMasa3 > 0 Then
            tbR54_3.Text = Raz3
            tbR57_3.Text = UkRacMasa3
        End If

        '' za testiranje - unos probnih komitenata u TL------------------------------------------------------
        'Dim xNaziv As String = ""
        'Dim xMesto As String = ""
        'Dim xZemlja As String = ""
        'Dim xAdresa As String = ""
        'Dim xPovVrednost As String = ""

        'Util.sNadjiKorisnika("888", xNaziv, xMesto, xZemlja, xAdresa, xPovVrednost)

        '' posiljalac
        'tbR11.Text = "888"
        'rtbR10.Text = xNaziv & vbCrLf & vbCrLf & xZemlja & vbCrLf & xMesto & vbCrLf & xAdresa

        '' primalac
        'tbR17.Text = "888"
        'rtbR16.Text = xNaziv & vbCrLf & vbCrLf & xZemlja & vbCrLf & xMesto & vbCrLf & xAdresa

        '' za testiranje - unos probnih komitenata u TL
        If bTarifa72 = 94 Then
            gbDorKarta.Visible = True
        Else
            gbDorKarta.Visible = False
        End If
    End Sub
    Private Sub tbUgovor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUgovor.Validating
        If IsNumeric(tbUgovor.Text) = True Then
            If tbUgovor.Text = Nothing Then
                mVrstaObracuna = "RO"
                If mVrstaSaobracaja <> 0 Then
                    bNadjiIPrikaziKurseve(bValuta)
                End If
                ComboBox1.Focus()
            Else
                Dim mRetVal As String
                Dim ug_mNazivKomitenta As String
                Dim ug_mAdresaKomitenta As String
                Dim ug_mGradKomitenta As String
                Dim ug_mZemljaKomitenta As String
                Dim ug_mKomitent As String
                'Dim ug_mPrimalac As String
                Dim ug_mVrstaObracuna As String

                NadjiUgovor(tbUgovor.Text, ug_mNazivKomitenta, ug_mKomitent, ug_mVrstaObracuna, ug_mAdresaKomitenta, ug_mGradKomitenta, ug_mZemljaKomitenta, mRetVal)

                If mRetVal = "" Then
                    mBrojUg = Me.tbUgovor.Text
                    If (ug_mVrstaObracuna = "CO") Or (ug_mVrstaObracuna = "CD") Or (tbUgovor.Text = "200379") Then
                        mPosiljalac = ug_mKomitent
                        mPrimalac = ug_mKomitent
                        mSifraKorisnikaP = ug_mKomitent
                        ug_mNazivKomitentaP = ug_mNazivKomitenta
                        ug_mAdresaKomitentaP = ug_mAdresaKomitenta
                        ug_mGradKomitentaP = ug_mGradKomitenta
                        ug_mZemljaKomitentaP = ug_mZemljaKomitenta
                        mSifraKorisnikaPP = ug_mKomitent                ' zato sto se za CO ne unosi PP
                        ug_mNazivKomitentaPP = ug_mNazivKomitenta       '           -"-
                        ug_mAdresaKomitentaPP = ug_mAdresaKomitenta     '           -"-
                        ug_mGradKomitentaPP = ug_mGradKomitenta         '           -"-
                        ug_mZemljaKomitentaPP = ug_mZemljaKomitenta     '           -"-
                        ug_mPraviPlatilac = ug_mKomitent                '           -"-
                    Else
                        _Kontrola_NemaUgovora = 0
                        _temp_mBrojUg = ""

                        bNadjiPiPPIzUgovoraKP(tbUgovor.Text, ug_mNazivKomitentaP, ug_mPlatilac, ug_mVrstaObracunaP, ug_mAdresaKomitentaP, ug_mGradKomitentaP, ug_mZemljaKomitentaP, _
                                            ug_mNazivKomitentaPP, ug_mPraviPlatilac, ug_mVrstaObracunaPP, ug_mAdresaKomitentaPP, ug_mGradKomitentaPP, ug_mZemljaKomitentaPP, mRetVal)

                        mPosiljalac = ug_mPlatilac
                        mPrimalac = ug_mPlatilac
                        mSifraKorisnikaP = ug_mPlatilac
                        mSifraKorisnikaPP = ug_mPraviPlatilac

                    End If

                    mVrstaObracuna = ug_mVrstaObracuna
                    ErrorProvider1.SetError(tbUgovor, "")
                    Me.tbR60.Text = "Ug. " & mBrojUg

                    Me.tbR11.Text = mSifraKorisnikaP.ToString
                    Me.tbR17.Text = mSifraKorisnikaP.ToString

                    rtbR10.Text = ug_mNazivKomitentaP & vbCrLf & vbCrLf & ug_mZemljaKomitentaP & vbCrLf & ug_mGradKomitentaP & vbCrLf & ug_mAdresaKomitentaP
                    rtbR16.Text = ug_mNazivKomitentaP & vbCrLf & vbCrLf & ug_mZemljaKomitentaP & vbCrLf & ug_mGradKomitentaP & vbCrLf & ug_mAdresaKomitentaP

                Else
                    _Kontrola_NemaUgovora = 1
                    ErrorProvider1.SetError(tbUgovor, "")
                    MessageBox.Show("Takav ugovor ne postoji u bazi podataka! Primenite redovnu tarifu.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation)
                    Label5.Text = " "
                    _temp_mBrojUg = tbUgovor.Text ' proveriti kako radi do kraja

                    ComboBox1.Focus()
                End If
                End If
        Else
            ErrorProvider1.SetError(tbUgovor, "Neispravan unos!")
            tbUgovor.Focus()
        End If
        If (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then
            GroupBox6.Visible = False
            GroupBox6.Enabled = False
        Else
            GroupBox6.Visible = True
            GroupBox6.Enabled = True
        End If
    End Sub


    Private Sub ComboBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.GotFocus
        Me.ComboBox2.DroppedDown = True
    End Sub
    Private Sub tbStanicaOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaOtp.Validating
        m_Tacka = "1"

        If Len(tbStanicaOtp.Text) < 5 Then
            ErrorProvider1.SetError(Label10, "Neispravna sifra stanice!")
            Me.tbStanicaOtp.SelectAll()
            Me.tbStanicaOtp.Focus()
        Else
            Dim xNaziv As String = ""
            Dim xKB As String = ""
            Dim xZemlja As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiStanicu("ZsStanice", tbStanicaOtp.Text, "", "", mBrojPokusaja, xNaziv, xKB, xZemlja, xPovVrednost)

            If xPovVrednost <> "" Then
                If mBrojPokusaja > 3 Then
                    mBrojPokusaja = 1
                    Label12.Text = "Nepostojeca sifra stanice"
                    mOtpStanica = tbStanicaOtp.Text
                    Me.tbStanicaOtp.BackColor = System.Drawing.Color.Red
                    ErrorProvider1.SetError(Label10, "")
                Else
                    mBrojPokusaja = mBrojPokusaja + 1
                    ErrorProvider1.SetError(Label10, "Nepostojeca stanica!")
                    Me.tbStanicaOtp.SelectAll()
                    tbStanicaOtp.Focus()
                End If
            Else
                mBrojPokusaja = 1
                Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
                Label12.Text = xNaziv
                tbR12Sifra.Text = tbStanicaOtp.Text
                tbR13_1.Text = tbStanicaOtp.Text
                tbR12Naziv.Text = xNaziv
                mOtpStanica = tbStanicaOtp.Text
                ErrorProvider1.SetError(tbStanicaOtp, "")

                Nadzorna()

            End If
            ErrorProvider1.SetError(Label10, "")
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
        If m_Tacka = "2" Then
            Me.cmbManipulativnaMestaIm.Items.Clear()
        Else
            Me.cmbManipulativnaMestaEx.Items.Clear()
        End If

        dsPrevPut.Clear()
        If m_Tacka = "2" Then
            upit = "SELECT Right(SifraStanice,5) as SifraStanice, Naziv FROM ZsStanice WHERE NadzornaStanicaSifra = '" & Microsoft.VisualBasic.Right(mPrStanica, 5) & "'"
        Else
            upit = "SELECT Right(SifraStanice,5) as SifraStanice, Naziv FROM ZsStanice WHERE NadzornaStanicaSifra = '" & Microsoft.VisualBasic.Right(mOtpStanica, 5) & "'"
        End If

        objComm = New SqlClient.SqlCommand(upit, OkpDbVeza)
        daPrevPut = New SqlClient.SqlDataAdapter(upit, OkpDbVeza)
        ii = daPrevPut.Fill(dsPrevPut)
        ZaCombo = ""
        Try
            If ii > 0 Then
                For kk As Int16 = 0 To ii - 1
                    combo_linija1 = dsPrevPut.Tables(0).Rows(kk).Item("SifraStanice") & " - " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv")
                    If m_Tacka = "2" Then
                        cmbManipulativnaMestaIm.Items.Add(combo_linija1)
                    Else
                        cmbManipulativnaMestaEx.Items.Add(combo_linija1)
                    End If
                Next
                If m_Tacka = "2" Then
                    cmbManipulativnaMestaIm.Items.Add("")
                Else
                    cmbManipulativnaMestaEx.Items.Add("")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ii > 0 Then
            If m_Tacka = "2" Then
                cmbManipulativnaMestaIm.Visible = True
                cmbManipulativnaMestaIm.Focus()
            Else
                cmbManipulativnaMestaEx.Visible = True
                cmbManipulativnaMestaEx.Focus()
            End If
        Else
            If m_Tacka = "2" Then
                cmbManipulativnaMestaIm.Visible = False
                Me.tbBrojPr.Focus()
            Else
                cmbManipulativnaMestaEx.Visible = False
                Me.tbBrojOtp.Focus()
            End If
        End If
        OkpDbVeza.Close()

        If cmbManipulativnaMestaEx.Items.Count > ExMMIndex Then
            cmbManipulativnaMestaEx.SelectedIndex = ExMMIndex
        End If

        If cmbManipulativnaMestaIm.Items.Count > ImMMIndex Then
            cmbManipulativnaMestaIm.SelectedIndex = ImMMIndex
        End If

    End Sub
    Private Sub tbStanicaPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaPr.Validating
        m_Tacka = "2"
        If Len(tbStanicaPr.Text) < 5 Then
            ErrorProvider1.SetError(Label18, "Neispravna sifra stanice!")
            Me.tbStanicaPr.SelectAll()
            If bShiftTab Then
                tbStanicaOtp.Focus()
            Else
                tbStanicaPr.Focus()
            End If
        Else
            Dim xNaziv As String = ""
            Dim xKB As String = ""
            Dim xZemlja As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiStanicu("ZsStanice", tbStanicaPr.Text, "", "", mBrojPokusaja, xNaziv, xKB, xZemlja, xPovVrednost)

            If xPovVrednost <> "" Then
                If mBrojPokusaja > 3 Then
                    mBrojPokusaja = 1
                    Label13.Text = "Nepostojeca sifra stanice"
                    mPrStanica = tbStanicaPr.Text
                    Me.tbStanicaPr.BackColor = System.Drawing.Color.Red
                    ErrorProvider1.SetError(Label18, "")
                Else
                    mBrojPokusaja = mBrojPokusaja + 1
                    ErrorProvider1.SetError(Label18, "Nepostojeca stanica!")
                    Me.tbStanicaPr.SelectAll()

                    'MsgBox("u validating")

                    If bShiftTab Then
                        tbStanicaOtp.Focus()
                    Else
                        tbStanicaPr.Focus()
                    End If

                End If
            Else
                'If tbStanicaPr.Text = tbStanicaOtp.Text Then
                '    ErrorProvider1.SetError(Me.TextBox2, "Neispravan izbor stanice!")
                '    Me.tbStanicaPr.SelectAll()
                '    tbStanicaPr.Focus()
                'Else
                '    mBrojPokusaja = 1
                '    Me.tbStanicaPr.BackColor = System.Drawing.Color.White      DOZVOLJAVA SE DA BUDU ISTE STANICE
                '    Label13.Text = xNaziv
                '    mPrStanica = tbStanicaPr.Text
                '    tbR30Sifra.Text = tbStanicaPr.Text
                '    tbR30Naziv.Text = xNaziv
                '    tbR33_1.Text = tbR30Sifra.Text

                '    ErrorProvider1.SetError(Label18, "")
                '    If m_Tacka = "2" Then
                '        Nadzorna()
                '    End If

                'End If
                mBrojPokusaja = 1
                Me.tbStanicaPr.BackColor = System.Drawing.Color.White
                Label13.Text = xNaziv
                mPrStanica = tbStanicaPr.Text
                tbR30Sifra.Text = tbStanicaPr.Text
                tbR30Naziv.Text = xNaziv
                tbR33_1.Text = tbR30Sifra.Text

                ErrorProvider1.SetError(Label18, "")
                If m_Tacka = "2" Then
                    Nadzorna()
                End If

            End If
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
        mManipulativnoMesto1 = Microsoft.VisualBasic.Left(cmbManipulativnaMestaEx.Text, 5)
        tbR14Sifra.Text = mManipulativnoMesto1
        If Len(mManipulativnoMesto1) = 0 Then
            tbR14Naziv.Text = ""
        Else
            tbR14Naziv.Text = Microsoft.VisualBasic.Right(cmbManipulativnaMestaEx.Text, Len(cmbManipulativnaMestaEx.Text) - 8)
        End If
        'Nadzorna()
        ExMMIndex = cmbManipulativnaMestaEx.SelectedIndex
        If cmbManipulativnaMestaEx.SelectedIndex = cmbManipulativnaMestaEx.Items.Count - 1 Then
            cmbManipulativnaMestaEx.SelectedIndex = -1
            ExMMIndex = -1
        End If
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
    Private Sub cmbManipulativnaMestaIm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbManipulativnaMestaIm.Validating
        mManipulativnoMesto2 = Microsoft.VisualBasic.Left(cmbManipulativnaMestaIm.Text, 5)
        tbR31Sifra.Text = mManipulativnoMesto2
        If Len(mManipulativnoMesto2) = 0 Then
            tbR31naziv.Text = ""
        Else
            tbR31naziv.Text = Microsoft.VisualBasic.Right(cmbManipulativnaMestaIm.Text, Len(cmbManipulativnaMestaIm.Text) - 8)
        End If

        ImMMIndex = cmbManipulativnaMestaIm.SelectedIndex
        If cmbManipulativnaMestaIm.SelectedIndex = cmbManipulativnaMestaIm.Items.Count - 1 Then
            cmbManipulativnaMestaEx.SelectedIndex = -1
            ImMMIndex = -1
        End If
        Daljinar()
    End Sub

    Private Sub tbBrojPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojPr.Leave
        Daljinar()
        tbR33_2.Text = tbBrojPr.Text
        DateTimePicker2.Focus()
        'btnUnosRobe.Focus()

    End Sub
    Private Sub tbBrojPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojPr.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click

        Dim helpUic As New HelpForm
        helpUic.Text = "help ZS"
        upit = "ZS"
        helpUic.ShowDialog()

        m_Tacka = "1"
        ErrorProvider1.SetError(Label10, "")
        Me.tbStanicaOtp.Text = Microsoft.VisualBasic.Mid(mIzlaz1, 3, 5)
        Label12.Text = mIzlaz2
        mOtpStanica = tbStanicaOtp.Text

        Nadzorna()

    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click

        Dim helpUic As New HelpForm
        helpUic.Text = "help ZS"
        upit = "ZS"
        helpUic.ShowDialog()

        m_Tacka = "2"
        ErrorProvider1.SetError(Label18, "")
        Me.tbStanicaPr.Text = Microsoft.VisualBasic.Mid(mIzlaz1, 3, 5)
        Label13.Text = mIzlaz2
        mPrStanica = tbStanicaPr.Text

        Nadzorna()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button1.Focus()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button4.Focus()
    End Sub

    Private Sub btnUpis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpis.Click
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Button11_Click(Me, Nothing)

        If ErrKontrola = "OK" Then
            _OpenForm = "Empty"

            ''eInit_NewCim89() brisanje pre novog unosa

            bPripremiZaUpisUBazu()

            UpisLokal()

            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.cbPDV.Focus()
        Else
            Cursor.Current = System.Windows.Forms.Cursors.Default
            dgError.Focus()
        End If

    End Sub
    Private Sub UpisLokal()

        Dim slogTrans As SqlTransaction
        Dim rv As String
        Dim drKola As DataRow
        Dim drNhm As DataRow
        Dim drDencane As DataRow
        Dim drNaknade As DataRow
        Dim mopRecID As Int32 = 0
        'Dim mUkljucujuci As String = ""
        Dim mDoPrelaza As String = ""
        Dim mValUrIsp, mValPouz, mValVR As String
        'Dim mPos1, mPos2, mPri1, mPri2 As Int32
        Dim mPos2, mPri2 As Int32
        Dim _prazanString As String = " "
        Dim strPrBroj As Int32

        mPrikazKalkulacije = "N"
        mIzEtiketa = 0
        mUlEtiketa = 0
        If Me.tbBrojPr.Text = Nothing Then
            mPrispece = 0
        Else
            mPrispece = CType(tbBrojPr.Text, Int32)
        End If

        'mObrMesec = Today.Month
        'mObrGodina = Today.Year

        If (DatumOtp.Value > Today) Or (DateTimePicker2.Value > Today) Or (DatumOtp.Value > DateTimePicker2.Value) Then
            MessageBox.Show("Pogrešan jedan ili više datuma!", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

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

        If mTarifa = "36" Then
            mBrojUg = ""
        End If

        '-- pristupa bazi -----------------
        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            slogTrans = OkpDbVeza.BeginTransaction()

            '--------------------------------------- Upis u SlogKalk ---------------------------------------------
            If MasterAction = "New" Then
                mAkcija = "New"
                UpdRecID = 0
                UpdStanicaRecID = 0
            Else
                mAkcija = "Upd"
            End If



            If mAkcija = "Upd" Then
                mObrMesec = bObrMesecIzSlogaKalk
                mObrGodina = bObrGodinaIzSlogaKalk
            End If

            ' da bi se razlikovalo od redovnog materijala
            If mUserID = "un77" Then
                mObrMesec = "77"
                mObrGodina = "1012"
            End If
            ' da bi se razlikovalo od redovnog materijala


            bVrstaSaobracaja = bVrstaSaobracajaTemp ' zbog domace-strane robe

            '--------------------------------------------------------------------------------------------------

            'Upis.bbUpisSlogKalkLokal(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, _
            '        CType(tbBrojOtp.Text, Int32), DatumOtp.Text, mObrGodina, mObrMesec, "0072", "72" & tbStanicaPr.Text, _
            '        mPrispece, DateTimePicker2.Text, 0, "0", mTarifa, bTarifa72, mBrojUg, _
            '        mPos1, mPos2, mPri1, mPri2, bVrstaPosiljke, mVrstaPrevoza, "1", _
            '        bVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bNarocitaPosiljka, bTkm, bSkm, mSifraIzjave, mFrRacun, mUkljucujuci, _
            '        "72", 0, bValuta, bSumaLevo, bSumaDesno, bPrevozninaLevo, bPrevozninaDesno, bSumaNaknadaLevo, bSumaNaknadaDesno, mUserID, Today(), _
            '        UpdRecID, UpdStanicaRecID, mopRecID, rv)


            'Upis.bbbUpisSlogKalkLokal(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, _

            'Upis.b3UpisSlogKalkLokal(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, _
            '        CType(tbBrojOtp.Text, Int32), DatumOtp.Text, mObrGodina, mObrMesec, "0072", "72" & tbStanicaPr.Text, _
            '        mPrispece, DateTimePicker2.Text, 0, "0", mTarifa, bTarifa72, mBrojUg, _
            '        mPosiljalac, mPos2, mPrimalac, mPri2, bVrstaPosiljke, mVrstaPrevoza, "1", _
            '        bVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bNarocitaPosiljka, bTkm, bSkm, mSifraIzjave, mFrRacun, mUkljucujuci, _
            '        "72", 0, bValuta, _
            '        0, 0, 0, 0, 0, 0, _
            '        tbSumaF.Text, tbSumaU.Text, bPrevozninaLevo, bPrevozninaDesno, bSumaNaknadaLevo, bSumaNaknadaDesno, _
            '        0, 0, 0, 0, 0, 0, _
            '        bBlagFranko - bSumaLevo, bBlagUpuceno - bSumaDesno, 0, 0, 0, 0, bCoPDV, _
            '        mUserID, Today(), _
            '        UpdRecID, UpdStanicaRecID, mopRecID, rv)
            If IsDBNull(bbPredujam) Then
                bbPredujam = 0
            End If
            If bTarifa72 = 94 Then
                bbPredujam = bDKIznos
            End If

            bUkljucujuciNiz(0) = tb20a.Text
            bUkljucujuciNiz(1) = tb20b.Text
            bUkljucujuciNiz(2) = tb20c.Text
            bUkljucujuciNiz(3) = tb20d.Text


            upis_mFrNaknade = bUkljucujuciNiz(0) & bUkljucujuciNiz(1) & bUkljucujuciNiz(2) & bUkljucujuciNiz(3)
            'If mAkcija = "New" Then
            '    bDatumObrade = Today()
            'Else
            '    bDatumObrade = bDatumObradeIzSloga
            'End If

            bDatumObrade = Today()

            'TimeOfDay()

            'If (Not (mVrstaObracuna = "CO")) Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "5255") Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "5248") Then
            '    Upis.b8UpisSlogKalkLokal(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, _
            '                        CType(tbBrojOtp.Text, Int32), DatumOtp.Text, mObrGodina, mObrMesec, "0072", "72" & tbStanicaPr.Text, _
            '                        mPrispece, DateTimePicker2.Text, 0, "0", mNajava, mTarifa, bTarifa72, mBrojUg, _
            '                        mPosiljalac, mPos2, mPrimalac, mPri2, bVrstaPosiljke, mVrstaPrevoza, "1", _
            '                        bVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bNarocitaPosiljka, _
            '                        bPrevozniPutZS, bStanicaVia, bTkm, bSkm, mSifraIzjave, bIznosPoIzjavi, mFrRacun, bUkljucujuci, _
            '                        "72", 0, bValuta, _
            '                        0, 0, 0, 0, 0, 0, _
            '                        tbSumaF.Text, tbSumaU.Text, bPrevozninaLevo, bPrevozninaDesno, bSumaNaknadaLevo, bSumaNaknadaDesno, _
            '                        0, 0, 0, 0, 0, 0, _
            '                        bBlagFranko - bSumaLevo, bBlagUpuceno - bSumaDesno, 0, 0, 0, 0, bCoPDV, bbPredujam, _
            '                        mUserID, bDatumObrade, _
            '                        UpdRecID, UpdStanicaRecID, mopRecID, rv)
            'Else
            '    Upis.b8UpisSlogKalkLokal(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, _
            '                        CType(tbBrojOtp.Text, Int32), DatumOtp.Text, mObrGodina, mObrMesec, "0072", "72" & tbStanicaPr.Text, _
            '                        mPrispece, DateTimePicker2.Text, 0, "0", mNajava, mTarifa, bTarifa72, mBrojUg, _
            '                        mPosiljalac, mPos2, mPrimalac, mPri2, bVrstaPosiljke, mVrstaPrevoza, "1", _
            '                        bVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bNarocitaPosiljka, _
            '                        bPrevozniPutZS, bStanicaVia, bTkm, bSkm, mSifraIzjave, bIznosPoIzjavi, mFrRacun, bUkljucujuci, _
            '                        "72", 0, bValuta, _
            '                        tbSumaF.Text, tbSumaU.Text, bPrevozninaLevo, bPrevozninaDesno, bSumaNaknadaLevo, bSumaNaknadaDesno, _
            '                        0, 0, 0, 0, 0, 0, _
            '                        0, 0, 0, 0, 0, 0, _
            '                        0, 0, 0, 0, 0, 0, bCoPDV, bbPredujam, _
            '                        mUserID, bDatumObrade, _
            '                        UpdRecID, UpdStanicaRecID, mopRecID, rv)

            'End If

            'If (mVrstaObracuna = "RO") Or (mVrstaObracuna = "CD") Then
            If Not (mVrstaObracuna = "CO") Then
                Dim bRazlikaFrDin As Decimal = 0
                Dim bRazlikaUpDin As Decimal = 0
                bRazlikaFrDin = bBlagFranko - bSumaLevo
                bRazlikaUpDin = bBlagUpuceno - bSumaDesno
                If (mVrstaObracuna = "CD") Then
                    bRazlikaFrDin = 0
                    bRazlikaUpDin = 0
                End If
                Upis.b8UpisSlogKalkLokal(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, _
                                    CType(tbBrojOtp.Text, Int32), DatumOtp.Text, mObrGodina, mObrMesec, "0072", "72" & tbStanicaPr.Text, _
                                    mPrispece, DateTimePicker2.Text, 0, "0", mNajava, mTarifa, bTarifa72, mBrojUg, _
                                    mPosiljalac, mPos2, mPrimalac, mPri2, bVrstaPosiljke, mVrstaPrevoza, "1", _
                                    bVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bNarocitaPosiljka, _
                                    bPrevozniPutZS, bStanicaVia, bTkm, bSkm, mSifraIzjave, bIznosPoIzjavi, mFrRacun, bUkljucujuci, _
                                    "72", 0, bValuta, _
                                    0, 0, 0, 0, 0, 0, _
                                    tbSumaF.Text, tbSumaU.Text, bPrevozninaLevo, bPrevozninaDesno, bSumaNaknadaLevo, bSumaNaknadaDesno, _
                                    0, 0, 0, 0, 0, 0, _
                                    bRazlikaFrDin, bRazlikaUpDin, 0, 0, 0, 0, bCoPDV, bbPredujam, _
                                    mUserID, bDatumObrade, _
                                    UpdRecID, UpdStanicaRecID, mopRecID, rv)
            ElseIf (mVrstaObracuna = "CO") Then
                Upis.b8UpisSlogKalkLokal(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, _
                                    CType(tbBrojOtp.Text, Int32), DatumOtp.Text, mObrGodina, mObrMesec, "0072", "72" & tbStanicaPr.Text, _
                                    mPrispece, DateTimePicker2.Text, 0, "0", mNajava, mTarifa, bTarifa72, mBrojUg, _
                                    mPosiljalac, mPos2, mPrimalac, mPri2, bVrstaPosiljke, mVrstaPrevoza, "1", _
                                    bVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bNarocitaPosiljka, _
                                    bPrevozniPutZS, bStanicaVia, bTkm, bSkm, mSifraIzjave, bIznosPoIzjavi, mFrRacun, bUkljucujuci, _
                                    "72", 0, bValuta, _
                                    tbSumaF.Text, tbSumaU.Text, bPrevozninaLevo, bPrevozninaDesno, bSumaNaknadaLevo, bSumaNaknadaDesno, _
                                    0, 0, 0, 0, 0, 0, _
                                    0, 0, 0, 0, 0, 0, _
                                    0, 0, 0, 0, 0, 0, bCoPDV, bbPredujam, _
                                    mUserID, bDatumObrade, _
                                    UpdRecID, UpdStanicaRecID, mopRecID, rv)

            End If

            If mAkcija = "Upd" Then

                mopRecID = UpdRecID

            End If


            If rv <> "" Then Throw New Exception(rv)
            '-- End Upis u SlogKalk -----------------------------------------

            '-- 2. Upis u SlogKola -------------------------------------------  
            If bVrstaPosiljke = "K" Then
                If Not (bTarifa72 = 94) Then            ' ako nije doracunska karta

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


                            Upis.UpisSlogKola(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, CType(tbBrojOtp.Text, Int32), DatumOtp.Text, rbKola, _
                                         drKola("IndBrojKola"), drKola("KB"), drKola("Uprava"), drKola("Vlasnik"), drKola("Serija"), _
                                         drKola("Osovine"), drKola("Tara"), drKola("GrTov"), drKola("Stitna"), drKola("Tip"), drKola("Prevoznina"), _
                                         drKola("Naknada"), drKola("ICF"), rv)

                            '-- 2.1 Upis u SlogRoba ---------------------------------------------  
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
                                    If mAkcija = "New" Or mAkcija = "Upd" Then
                                        Upis.UpisSlogRobaUI(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, tbBrojOtp.Text, DatumOtp.Text, _
                                                     rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
                                                     drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
                                                     drNhm("UTIBuletin"), drNhm("UTIPlombe"), drNhm("RacMasaNHM"), drNhm("VozarinskiStavNHM"), drNhm("PorekloRobe"), rv)

                                    ElseIf mAkcija = "Del" Then
                                        Dim nRV As Int32 = 0
                                        Upis.BrisanjeSlogRobaUI2(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), rbKola, rbRoba, rv)
                                    End If


                                    'Upis.UpisSlogRobaDec(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, CType(tbBrojOtp.Text, Int32), DatumOtp.Text, _
                                    '             rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("MasaDec"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
                                    '             drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
                                    '             drNhm("UTIBuletin"), drNhm("UTIPlombe"), rv)

                                    rbRoba = rbRoba + 1
                                End If
                            Next
                            '-- End Upis u SlogRoba -----------------------------------------  
                            rbKola = rbKola + 1
                            rbRoba = 1
                        Next
                    End If
                    If rv <> "" Then Throw New Exception(rv)

                End If              ' ako nije doracunska karta

            Else
                '-- 2d. Upis u SlogDencane ------------------------------------------
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

                    Upis.UpisSlogDencane(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                "0072", "72" & tbStanicaOtp.Text, CType(tbBrojOtp.Text, Int32), DatumOtp.Text, _
                                rbDencane, drDencane("SMasa"), drDencane("RMasa"), _
                                drDencane("Tarifa"), drDencane("Tip"), drDencane("Komada"), _
                                drDencane("Iznos"), drDencane("Valuta"), rv)

                    rbDencane = rbDencane + 1
                Next
                If rv <> "" Then Throw New Exception(rv)
            End If

            '-- 3. Upis u SlogNaknada ------------------------------------------
            Dim rbNaknade As Int16 = 1
            Dim i_TotalNak As String = ""
            Dim i_Pronasao As Int32 = 0
            Dim bUkupnoZaUpis As Integer = 0
            rbNaknade = 1

            For Each drNaknade In dtNaknade.Rows
                bUkupnoZaUpis = bUkupnoZaUpis + 1
            Next

            If bTarifa72 = 91 Then ' ako je P9 ne upisuje naknade u bazu! Mandic, 7/11/2013
                dtNaknade.Clear()
                dtNaknade.AcceptChanges()
            End If

            If (dtNaknade.Rows.Count > 0) Then
                For Each drNaknade In dtNaknade.Rows

                    If MasterAction = "New" Then
                        mAkcija = "New"
                    Else
                        'If drNaknade("Action") = "I" Then
                        '    mAkcija = "New"
                        'ElseIf drNaknade("Action") = "U" Then
                        '    mAkcija = "Upd"
                        'ElseIf drNaknade("Action") = "D" Then
                        '    mAkcija = "Del"
                        'End If
                        If bUkupnoIzBaze = bUkupnoZaUpis Then
                            mAkcija = "Upd"
                        ElseIf bUkupnoIzBaze < bUkupnoZaUpis Then
                            If rbNaknade <= bUkupnoIzBaze Then
                                mAkcija = "Upd"
                            Else
                                mAkcija = "New"
                            End If
                        ElseIf bUkupnoIzBaze > bUkupnoZaUpis Then
                            If rbNaknade <= bUkupnoZaUpis Then
                                mAkcija = "Upd"
                            Else
                                mAkcija = "Del"
                            End If
                        End If

                    End If


                    Dim strRetVal As String = ""
                    Dim bKurs As Decimal = 1

                    Dim bVrstaKursa As String = ""

                    If mBrojUg = "200379" Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then         ' 25.07.2016 za sada; treba ukljuciti da li su cene u RSD ili EUR
                        bVrstaKursa = "3"
                    Else
                        bVrstaKursa = "1"
                    End If


                    'If bValuta = "17" Then                     ranije je izracunato, a i zbog  "OkpDbVeza.Close()"
                    '    NadjiKurs("17", bVrstaKursa, mOtpDatum, bKursOt, strRetVal)
                    '    NadjiKurs("17", bVrstaKursa, mPrDatum, bKursPr, strRetVal)
                    'Else
                    '    bKursOt = 1
                    '    bKursPr = 1
                    'End If

                    For aa As Int16 = 0 To 3
                        If UTLNaknadeR44(aa) = i_TotalNak Then
                            i_Pronasao = 1
                            Exit For
                        End If
                    Next

                    If i_Pronasao = 1 Then
                        bKurs = bKursOt
                    Else
                        bKurs = bKursPr
                    End If

                    ' U P I S  I Z N O S A  U  E V R I M A  Z A  U V O Z -I Z V O Z

                    'If bValuta = "17" Then
                    '    drNaknade("Iznos") = bKurs * drNaknade("Iznos")
                    'End If


                    Upis.UpisSlogNaknada(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, CType(tbBrojOtp.Text, Int32), DatumOtp.Text, _
                                    rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
                                    drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

                    '''''If bValuta = "17" Then
                    '''''    drNaknade("Valuta") = "72"
                    '''''    drNaknade("Iznos") = bKurs * drNaknade("Iznos")
                    '''''    bZaokruziNaDeseteNavise(drNaknade("Iznos"))
                    '''''End If


                    '''''Dim bNasao72 As Boolean = False
                    '''''Dim bAkcija72 As String = ""

                    ''''''bPronadjiNaknadu72(mopRecID, rbNaknade, bNasao72)
                    ''''''If bNasao72 Then
                    ''''''    bAkcija72 = "Upd"
                    ''''''Else
                    ''''''    bAkcija72 = "New"
                    ''''''End If

                    '''''bAkcija72 = mAkcija

                    '''''Upis.UpisSlogNaknada72(slogTrans, bAkcija72, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), "0072", "72" & tbStanicaOtp.Text, CType(tbBrojOtp.Text, Int32), DatumOtp.Text, _
                    '''''                                    rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
                    '''''                                    drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

                    rbNaknade = rbNaknade + 1



                Next


            End If

            Dim drK211 As DataRow

            Dim Petlja As Int16 = 1

            If bUkupnoK211IzBaze > 0 Then
                For Petlja = 1 To bUkupnoK211IzBaze
                    Upis.UpisSlogK211(slogTrans, "Del", mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), Petlja, 0, rv)
                Next

            End If

            If dtK211.Rows.Count > 0 Then
                Dim rbK211 As Int16 = 1
                For Each drK211 In dtK211.Rows
                    If MasterAction = "New" Then
                        mAkcija = "New"
                    Else
                        mAkcija = "New"
                        'If drK211("Action") = "I" Then
                        '    mAkcija = "New"
                        'ElseIf drK211("Action") = "U" Then
                        '    mAkcija = "Upd"
                        'ElseIf drK211("Action") = "D" Then
                        '    mAkcija = "Del"
                        'End If
                    End If
                    ''stara verzija char(2)
                    ''Upis.UpisSlogK211(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                    ''                  rbK211, drK211("Sifra"), _
                    ''                  rv)

                    Upis.UpisSlogK211(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                       rbK211, drK211("Sifra"), _
                                       rv)


                    rbK211 = rbK211 + 1
                Next

            End If



            '-- End Upis u SlogNaknada --------------------------------------
            '-- 4. Upis u SlogMM --------------------------------------
            'If mManipulativnoMesto1 <> "" Or mManipulativnoMesto2 <> "" Then

            '    'mAkcija = MM_Action
            '    'If AkcijaZaPreuzimanje = "Da" Then
            '    '    mAkcija = MM_Action
            '    'End If

            '    Upis.UpisSlogKalkMM(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
            '                        mManipulativnoMesto1, mManipulativnoMesto2, _
            '                        rv)

            '    If rv <> "" Then Throw New Exception(rv)

            'End If


            If bManipulativnoMesto1IzSloga <> "" Or bManipulativnoMesto2IzSloga <> "" Then
                If mManipulativnoMesto1 <> "" Or mManipulativnoMesto2 <> "" Then
                    mAkcija = "Upd"
                End If
                If mManipulativnoMesto1 = "" And mManipulativnoMesto2 = "" Then
                    mAkcija = "Del"
                End If
            End If

            If bManipulativnoMesto1IzSloga = "" And bManipulativnoMesto2IzSloga = "" Then
                If mManipulativnoMesto1 <> "" Or mManipulativnoMesto2 <> "" Then
                    mAkcija = "New"
                End If
            End If

            If (bManipulativnoMesto1IzSloga <> "") Or (bManipulativnoMesto2IzSloga <> "") Or (mManipulativnoMesto1 <> "") Or (mManipulativnoMesto2 <> "") Then
                Upis.UpisSlogKalkMM(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                    mManipulativnoMesto1, mManipulativnoMesto2, _
                                    rv)
                If rv <> "" Then Throw New Exception(rv)
            End If

            '-- End Upis u SlogMM --------------------------------------


            '-- 5. Upis u SlogKalkPDV --------------------------------------


            If tmp_pdv_f > 0 Or tmp_pdv_u > 0 Or bPDV1IzSloga > 0 Or bPDV2IzSloga > 0 Then
                If (tmp_pdv_f > 0) Or (tmp_pdv_u > 0) Then
                    If (bPDV1IzSloga > 0) Or (bPDV2IzSloga > 0) Then
                        mAkcija = "Upd"
                    End If
                    If (bPDV1IzSloga = 0) And (bPDV2IzSloga = 0) Then
                        mAkcija = "New"
                    End If
                    bUpisSlogKalkPDV(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tmp_pdv_f, tmp_pdv_u, rv)
                End If
            End If

            If (tmp_pdv_f = 0) And (tmp_pdv_u = 0) Then

                If (bPDV1IzSloga > 0) Or (bPDV2IzSloga > 0) Then
                    mAkcija = "Del"
                    bUpisSlogKalkPDV(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tmp_pdv_f, tmp_pdv_u, rv)

                End If

            End If





            '-- End Upis u SlogKalkPDV --------------------------------------




            'preuzeti promenljive iz procedure za štampu - napraviti ih friend/public!!

            '================== prilagodjavanje promenljivih za upis u SlogUTL
            r1 = ""
            r2 = Me.tbR2.Text
            If Me.cbR4K.Checked = True Then
                r4 = "1"
            Else
                r4 = "2"
            End If

            If Me.cbR5R.Checked = True Then
                r5 = "1"
            End If
            If Me.cbR5O.Checked = True Then
                r5 = "2"
            End If
            If Me.cbR5D.Checked = True Then
                r5 = "3"
            End If
            If Me.cbR5E.Checked = True Then
                r5 = "4"
            End If

            If Me.cbR6.Checked = True Then
                r6 = "1"
            Else
                r6 = ""
            End If

            'nastavak-proveriti da li treba da se ponavlja, ako se odštampa promenljive su dodeljene i obratno ako se upiše
            r7 = Me.tbR7.Text
            r8 = Me.tbR8.Text
            r9 = Me.tbR9.Text

            r10 = Me.rtbR10.Text
            r10_kb = tbCtrlNum.Text
            If Me.tbR11.Text = Nothing Then
                r11 = 0
            Else
                r11 = Me.tbR11.Text
            End If

            r12_1 = Me.tbR12Sifra.Text
            r12_2 = Me.tbR12Naziv.Text
            r13_1 = tbR13_1.Text
            If Me.tbR13_2.Text = Nothing Then
                r13_2 = 0
            Else
                r13_2 = tbR13_2.Text
            End If

            r14_1 = tbR14Sifra.Text
            r14_2 = tbR14Naziv.Text
            r15 = Me.tbR15.Text
            r15_1 = Me.tb15_1.Text
            r16 = Me.rtbR16.Text
            If Me.tbR17.Text = Nothing Then
                r17 = 0
            Else
                r17 = Me.tbR17.Text
            End If

            r18 = Me.tbR18.Text
            r19 = Me.tbR19.Text
            If Me.tbR20a.Text = Nothing Then
                r20_1 = 0
            Else
                r20_1 = Me.tbR20a.Text
            End If
            If Me.tbR20b.Text = Nothing Then
                r20_2 = 0
            Else
                r20_2 = Me.tbR20b.Text
            End If

            r21_1 = tbR21_1.Text
            r21_2 = tbR21_2.Text
            r21_3 = tbR21_3.Text
            r21_4 = tbR21_4.Text
            r22_1 = tbIBK.Text
            r22_2 = tbIBK_2.Text
            r22_3 = tbIBK_3.Text
            r22_4 = tbIBK_4.Text

            If Me.tbR23_1.Text = Nothing Then
                r23_1 = 0
            Else
                r23_1 = tbR23_1.Text
            End If
            If Me.tbR23_2.Text = Nothing Then
                r23_2 = 0
            Else
                r23_2 = tbR23_2.Text
            End If
            If Me.tbR23_3.Text = Nothing Then
                r23_3 = 0
            Else
                r23_3 = tbR23_3.Text
            End If
            If Me.tbR23_4.Text = Nothing Then
                r23_4 = 0
            Else
                r23_4 = tbR23_4.Text
            End If

            If Me.tbR24_1.Text = Nothing Then
                r24_1 = 0
            Else
                r24_1 = tbR24_1.Text
            End If
            If Me.tbR24_2.Text = Nothing Then
                r24_2 = 0
            Else
                r24_2 = tbR24_2.Text
            End If
            If Me.tbR24_3.Text = Nothing Then
                r24_3 = 0
            Else
                r24_3 = tbR24_3.Text
            End If
            If Me.tbR24_4.Text = Nothing Then
                r24_4 = 0
            Else
                r24_4 = tbR24_4.Text
            End If

            r25t_1 = tbR25a_1.Text
            r25t_2 = tbR25a_2.Text
            r25t_3 = tbR25a_3.Text
            r25t_4 = tbR25a_4.Text

            If Me.tbR25b_1.Text = Nothing Then
                r25k_1 = 0
            Else
                r25k_1 = tbR25b_1.Text
            End If
            If Me.tbR25b_2.Text = Nothing Then
                r25k_2 = 0
            Else
                r25k_2 = tbR25b_2.Text
            End If
            If Me.tbR25b_3.Text = Nothing Then
                r25k_3 = 0
            Else
                r25k_3 = tbR25b_3.Text
            End If
            If Me.tbR25b_4.Text = Nothing Then
                r25k_4 = 0
            Else
                r25k_4 = tbR25b_4.Text
            End If

            If Me.tbR26_1.Text = Nothing Then
                r26_1 = 0
            Else
                r26_1 = tbR26_1.Text
            End If
            If Me.tbR26_2.Text = Nothing Then
                r26_2 = 0
            Else
                r26_2 = tbR26_2.Text
            End If
            If Me.tbR26_3.Text = Nothing Then
                r26_3 = 0
            Else
                r26_3 = tbR26_3.Text
            End If
            If Me.tbR26_4.Text = Nothing Then
                r26_4 = 0
            Else
                r26_4 = tbR26_4.Text
            End If


            r27 = rtbR27.Text
            r28 = tbR28.Text
            If Me.tbSumaNeto.Text = Nothing Then
                rSumaTara = 0
            Else
                rSumaTara = tbSumaNeto.Text
            End If
            If Me.tbSumaKola.Text = Nothing Then
                rSumaKola = 0
            Else
                rSumaKola = tbSumaKola.Text
            End If
            If Me.tbSumaOsovina.Text = Nothing Then
                rSumaOs = 0
            Else
                rSumaOs = tbSumaOsovina.Text
            End If

            If Me.CheckBox5.Checked = True Then
                r29_1 = "1"
            End If
            If Me.CheckBox7.Checked = True Then
                r29_1 = "2"
            End If

            r30_1 = Me.tbR30Sifra.Text
            r30_2 = Me.tbR30Naziv.Text
            r31_1 = Me.tbR31Sifra.Text
            r31_2 = Me.tbR31naziv.Text
            r32 = Me.tbR32a.Text
            r32_1 = Me.tbR32b.Text
            r33_1 = Me.tbR33_1.Text
            If Me.tbR36.Text = Nothing Then
                r33_2 = 0
            Else
                r33_2 = Me.tbR33_2.Text
            End If


            r34 = Me.rtbR34.Text
            r35 = Me.tbR35.Text
            If Me.tbR36.Text = Nothing Then
                r36 = 0
            Else
                r36 = Me.tbR36.Text
            End If


            If Me.cbRID.Checked = True Then
                rRID = "1"
            Else
                rRID = "0"
            End If

            r37 = Me.rtb37.Text

            r42_1 = Me.tbR42a.Text
            r42_2 = Me.tbR42b.Text
            r42_3 = Me.tbR42c.Text
            r42_4 = Me.tbR42d.Text
            r42_5 = Me.tbR42e.Text

            r43_1 = Me.tbR43a.Text
            r43_2 = Me.tbR43b.Text
            r43_3 = Me.tbR43c.Text
            r43_4 = Me.tbR43d.Text
            r43_5 = Me.tbR43e.Text

            If Me.CheckBox1.Checked = True Then
                r44_1 = "1"
            End If
            If Me.CheckBox2.Checked = True Then
                r44_1 = "2"
            End If
            If Me.CheckBox3.Checked = True Then
                r44_1 = "3"
            End If
            If Me.CheckBox4.Checked = True Then
                r44_1 = "4"
            End If
            If Me.CheckBox1.Checked = False And Me.CheckBox2.Checked = False And _
               Me.CheckBox3.Checked = False And Me.CheckBox4.Checked = False Then
                r44_1 = "0"
            End If

            r44n1 = Me.tb20a.Text
            r44n2 = Me.tb20b.Text
            r44n3 = Me.tb20c.Text
            r44n4 = Me.tb20d.Text

            If Me.tbR44Iznos.Text = Nothing Then
                r44i = 0
            Else
                r44i = Me.tbR44Iznos.Text
            End If

            r45_1 = Me.tbR45a.Text
            r45_2 = Me.tbR45b.Text

            If Me.tbR41Suma.Text = Nothing Then
                r41Suma = 0
            Else
                r41Suma = Me.tbR41Suma.Text
            End If

            r46 = Me.tbR46.Text
            If Me.tbR47.Text = Nothing Then
                r47 = 0
            Else
                r47 = Me.tbR47.Text
            End If

            r48_1 = Me.tbR48a.Text
            r48_2 = Me.tbR48b.Text
            If Me.tbR49.Text = Nothing Then
                r49 = 0
            Else
                r49 = Me.tbR49.Text
            End If
            If Me.tbR50.Text = Nothing Then
                r50 = 0
            Else
                r50 = Me.tbR50.Text
            End If
            If Me.tbR51.Text = Nothing Then
                r51 = 0
            Else
                r51 = Me.tbR51.Text
            End If

            If Me.tbR53.Text = Nothing Then
                r53 = 0
            Else
                r53 = Me.tbR53.Text
            End If

            If Me.tbR54_1.Text = Nothing Then
                r54_1 = 0
            Else
                r54_1 = Me.tbR54_1.Text
            End If
            If Me.tbR54_2.Text = Nothing Then
                r54_2 = 0
            Else
                r54_2 = Me.tbR54_2.Text
            End If
            If Me.tbR54_3.Text = Nothing Then
                r54_3 = 0
            Else
                r54_3 = Me.tbR54_3.Text
            End If

            If Me.tbPrevStav1.Text = Nothing Then
                r55_1 = 0
            Else
                r55_1 = Me.tbPrevStav1.Text
            End If
            If Me.tbPrevStav2.Text = Nothing Then
                r55_2 = 0
            Else
                r55_2 = Me.tbPrevStav2.Text
            End If
            If Me.tbPrevStav3.Text = Nothing Then
                r55_3 = 0
            Else
                r55_3 = Me.tbPrevStav3.Text
            End If

            If Me.tb56a.Text = Nothing Then
                r56_1 = 0
            Else
                r56_1 = Me.tb56a.Text
            End If
            If Me.tb56b.Text = Nothing Then
                r56_2 = 0
            Else
                r56_2 = Me.tb56b.Text
            End If
            If Me.tb56c.Text = Nothing Then
                r56_3 = 0
            Else
                r56_3 = Me.tb56c.Text
            End If

            If Me.tbR57_1.Text = Nothing Then
                r57_1 = 0
            Else
                r57_1 = Me.tbR57_1.Text
            End If
            If Me.tbR57_2.Text = Nothing Then
                r57_2 = 0
            Else
                r57_2 = Me.tbR57_2.Text
            End If
            If Me.tbR57_3.Text = Nothing Then
                r57_3 = 0
            Else
                r57_3 = Me.tbR57_3.Text
            End If

            r58 = Me.tbR58.Text
            r59 = Me.tbR59.Text
            r60 = Me.tbR60.Text

            If Me.tbPrevF.Text = Nothing Then
                r61F = 0
            Else
                r61F = Me.tbPrevF.Text
            End If
            If Me.tbPrevU.Text = Nothing Then
                r61U = 0
            Else
                r61U = Me.tbPrevU.Text
            End If

            If Me.tbNak1F.Text = Nothing Then
                r64F_1 = 0
            Else
                r64F_1 = Me.tbNak1F.Text
            End If
            If Me.tbNak2F.Text = Nothing Then
                r64F_2 = 0
            Else
                r64F_2 = Me.tbNak2F.Text
            End If
            If Me.tbNak3F.Text = Nothing Then
                r64F_3 = 0
            Else
                r64F_3 = Me.tbNak3F.Text
            End If
            If Me.tbNak4F.Text = Nothing Then
                r64F_4 = 0
            Else
                r64F_4 = Me.tbNak4F.Text
            End If
            If Me.tbPdvIznosF.Text = Nothing Then
                r64F_5 = 0
            Else
                r64F_5 = Me.tbPdvIznosF.Text
            End If
            If Me.tbTugF.Text = Nothing Then
                r64F_6 = 0
            Else
                r64F_6 = Me.tbTugF.Text
            End If

            r62a_1 = tbA79a1.Text
            r62a_2 = tbA79a2.Text
            r62a_3 = tbA79a3.Text
            r62a_4 = tbA79a4.Text
            r62a_5 = tbPDVF.Text
            r62a_6 = tb63a.Text

            r62b_1 = tbA79b1.Text
            r62b_2 = tbA79b2.Text
            r62b_3 = tbA79b3.Text
            r62b_4 = tbA79b4.Text
            r62b_5 = tbPDVU.Text
            r62b_6 = tb63b.Text

            r62c_1 = tb62na.Text
            r62c_2 = tb62nb.Text
            r62c_3 = tb62nc.Text
            r62c_4 = tb62nd.Text
            r62c_5 = tbPDV.Text
            r62c_6 = tbTug.Text

            If Me.tbNak1U.Text = Nothing Then
                r64U_1 = 0
            Else
                r64U_1 = Me.tbNak1U.Text
            End If
            If Me.tbNak2U.Text = Nothing Then
                r64U_2 = 0
            Else
                r64U_2 = Me.tbNak2U.Text
            End If
            If Me.tbNak3U.Text = Nothing Then
                r64U_3 = 0
            Else
                r64U_3 = Me.tbNak3U.Text
            End If
            If Me.tbNak4U.Text = Nothing Then
                r64U_4 = 0
            Else
                r64U_4 = Me.tbNak4U.Text
            End If
            If Me.tbPdvIznosU.Text = Nothing Then
                r64U_5 = 0
            Else
                r64U_5 = Me.tbPdvIznosU.Text
            End If
            If Me.tbTugU.Text = Nothing Then
                r64U_6 = 0
            Else
                r64U_6 = Me.tbTugU.Text
            End If

            If Me.tbSumaF.Text = Nothing Then
                r65f = 0
            Else
                r65f = Me.tbSumaF.Text
            End If
            If Me.tbSumaU.Text = Nothing Then
                r65u = 0
            Else
                r65u = Me.tbSumaU.Text
            End If

            If Me.CheckBox6.Checked = True Then
                r66a = "x"
            Else
                r66a = " "
            End If
            r66b = tbR68b.Text

            '=============== end ====

            'Upis.UpisSlogUTLOWR(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
            '                 r1, r2, r4, r5, r6, r7, r8, r9, r10, r10_kb, CType(r11, Int32), r12_1, r12_2, r13_1, CType(r13_2, Int32), _
            '                 r14_1, r14_2, r15, r15_1, r16, r17, r18, r19, CType(r20_1, Int32), CType(r20_2, Int32), r21_1, r22_1, r21_2, r22_2, _
            '                 r21_3, r22_3, r21_4, r22_4, CDec(r23_1), CDec(r23_2), CDec(r23_3), CDec(r23_4), _
            '                 CType(r24_1, Int32), CType(r24_2, Int32), CType(r24_3, Int32), CType(r24_4, Int32), CType(rSumaTara, Int32), _
            '                 r25t_1, r25t_2, r25t_3, r25t_4, CType(r25k_1, Int32), CType(r25k_2, Int32), CType(r25k_3, Int32), CType(r25k_4, Int32), CType(rSumaKola, Int32), _
            '                 CType(r26_1, Int32), CType(r26_2, Int32), CType(r26_3, Int32), CType(r26_4, Int32), CType(rSumaOs, Int32), r27, r28, r29_1, r30_1, r30_2, r31_1, r31_2, r32, r32_1, _
            '                 r33_1, CType(r33_2, Int32), r34, r35, CType(r36, Int32), r37, rRID, CType(r41Suma, Int32), r42_1, r42_2, r42_3, r42_4, r42_5, _
            '                 r43_1, r43_2, r43_3, r43_4, r43_5, r44_1, r44n1 & r44n1 & r44n1 & r44n1, _
            '                 CDec(r44i), r45_1, r45_2, r46, CDec(r47), r48_1, r48_2, CDec(r49), CDec(r50), CDec(r51), CType(r53, Int32), r54_1, r54_2, r54_3, _
            '                 CDec(r55_1), CDec(r55_2), CDec(r55_3), CDec(r56_1), CDec(r56_2), CDec(r56_3), CType(r57_1, Int32), CType(r57_2, Int32), CType(r57_3, Int32), _
            '                 r58, r59, r60, CDec(r61F), CDec(r61U), _
            '                 CDec(r64F_1), CDec(r64F_2), CDec(r64F_3), CDec(r64F_4), CDec(r64F_5), CDec(r64F_6), _
            '                 r62a_1, r62a_2, r62a_3, r62a_4, r62a_5, r62a_6, _
            '                 r62b_1, r62b_2, r62b_3, r62b_4, r62b_5, r62b_6, _
            '                 r62c_1, r62c_2, r62c_3, r62c_4, r62c_5, r62c_6, _
            '                 CDec(r64U_1), CDec(r64U_2), CDec(r64U_3), CDec(r64U_4), CDec(r64U_5), CDec(r64U_6), _
            '                 CDec(r65f), CDec(r65u), r66a, r66b, _
            '                 rv)


            If rv <> "" Then Throw New Exception(rv)

            'proveriti da li da ide na #100
            If rv = "" Then
                slogTrans.Commit()
                Me.Text = " ::: Uspesan upis! :::"
            Else
                MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                slogTrans.Rollback()
            End If

            ClearDoc() ' brise polja pre novog unosa

        Catch ex As Exception
            rv = ex.Message
            MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch sqlex As SqlException
            MsgBox(sqlex.Message)
        Finally
            '#100


            OkpDbVeza.Close()
        End Try

    End Sub
    Private Sub ClearDoc()
        ' Resetovanje podataka na tovarnom listu

        'tbR8.Text = ""                  ' vrsta saobracaja

        rtbR10.Text = ""                ' posiljalac
        tbR11.Text = 0                  ' posiljalac sifra

        rtbR16.Text = ""                ' primalac
        tbR17.Text = 0                  ' primalac sifra

        'tbR12Sifra.Text = ""            ' otpravna stanica sifra
        'tbR12Naziv.Text = ""            ' otpravna stanica naziv
        'tbR13_1.Text = ""               ' otpravna stanica sifra
        tbR13_2.Text = ""               ' broj otpravljanja

        tbR14Sifra.Text = ""            ' manipulativno mesto u otpravljanju
        tbR14Naziv.Text = ""
        ExMMIndex = -1
        mManipulativnoMesto1 = ""

        'tbR30Sifra.Text = ""            ' uputna stanica sifra
        'tbR30Naziv.Text = ""            ' uputna stanica naziv
        'tbR33_1.Text = ""               ' uputna stanica sifra
        tbR33_2.Text = ""               ' broj prispeca

        tbR31Sifra.Text = ""            ' manipulativno mesto u prispecu
        tbR31naziv.Text = ""        
        ImMMIndex = -1
        mManipulativnoMesto2 = ""

        tbR21_1.Text = ""               ' slovna oznaka kola
        tbR21_2.Text = ""
        tbR21_3.Text = ""
        tbR21_4.Text = ""

        tbIBK.Text = ""                 ' IBK
        tbIBK_2.Text = ""
        tbIBK_3.Text = ""
        tbIBK_4.Text = ""

        tbR23_1.Text = ""               ' granica tovarenja
        tbR23_2.Text = ""
        tbR23_3.Text = ""
        tbR23_4.Text = ""

        tbR24_1.Text = ""               ' sopstvena masa kola
        tbR24_2.Text = ""
        tbR24_3.Text = ""
        tbR24_4.Text = ""
        tbSumaNeto.Text = ""

        tbR25a_1.Text = ""              ' tip kola
        tbR25a_2.Text = ""
        tbR25a_3.Text = ""
        tbR25a_4.Text = ""

        tbR25b_1.Text = ""              ' kolicina kola po tipovima
        tbR25b_2.Text = ""
        tbR25b_3.Text = ""
        tbR25b_4.Text = ""
        tbSumaKola.Text = ""            ' ukupno kola

        tbR26_1.Text = ""               ' osovine
        tbR26_2.Text = ""
        tbR26_3.Text = ""
        tbR26_4.Text = ""
        tbSumaOsovina.Text = ""         ' ukupno osovina

        tbR35.Text = ""                 ' prevozni put
        cbZsPrevozniPut.Text = ""
        cbZsPrevozniPut.SelectedIndex = -1
        tbStanicaLom.Text = ""

        rtbR27.Text = ""                ' izjave

        rtb37.Text = ""

        tbR42a.Text = ""
        tbR42b.Text = ""
        tbR42c.Text = ""
        tbR42d.Text = ""
        tbR42e.Text = ""
        tbR42f.Text = ""

        tbR43a.Text = ""
        tbR43b.Text = ""
        tbR43c.Text = ""
        tbR43d.Text = ""
        tbR43e.Text = ""
        tbR43f.Text = ""

        tbR41Suma.Text = ""             ' ukupna mase iz rtb37

        CheckBox1.Checked = False                   ' izjave
        CheckBox2.Checked = False
        tb20a.Text = ""
        tb20b.Text = ""
        tb20c.Text = ""
        tb20d.Text = ""
        CheckBox3.Checked = False
        CheckBox4.Checked = False

        tbR49.Text = ""                 ' pouzece
        tbR50.Text = ""                 ' predujam
        tbR47.Text = ""
        tbR51.Text = ""

        tbR48a.Text = ""                ' frankaturni racun
        tbR48b.Text = ""

        tbR58.Text = ""
        tbR59.Text = ""

        tbR53.Text = ""                 ' tkm
        tbR53_LP2.Text = ""             ' tkm lomlj.

        tbR60.Text = ""

        tbR54_1.Text = ""               ' tar. razredi
        tbR54_2.Text = ""
        tbR54_3.Text = ""

        tbPrevStav1.Text = ""
        tbPrevStav2.Text = ""
        tbPrevStav3.Text = ""

        tbR57_1.Text = ""               ' rac. mase
        tbR57_2.Text = ""
        tbR57_3.Text = ""

        tbPrevF.Text = 0               ' franko strana
        tbNak1F.Text = 0
        tbNak2F.Text = 0
        tbNak3F.Text = 0
        tbNak4F.Text = 0

        tbPdvIznosF.Text = 0           ' franko
        tbTugF.Text = 0                ' trosak u gotovom franko

        tbPrev1.Text = 0               ' lomlj.
        tbPrev2.Text = 0

        tbA79a1.Text = ""               ' naknada 1
        tbA79b1.Text = ""
        tb62na.Text = ""

        tbA79a2.Text = ""               ' naknada 2
        tbA79b2.Text = ""
        tb62nb.Text = ""

        tbA79a3.Text = ""               ' naknada 3
        tbA79b3.Text = ""
        tb62nc.Text = ""

        tbA79a4.Text = ""               ' naknada 4
        tbA79b4.Text = ""
        tb62nd.Text = ""

        tbPDVF.Text = ""                ' PDV
        tbPDVU.Text = ""
        tbPDV.Text = ""

        tb63a.Text = ""                 ' trosak u gotovu
        tb63b.Text = ""
        tbTug.Text = ""

        tbSumaF.Text = 0               ' SUMA FRANKO

        tbPrevU.Text = 0               ' upuceno strana
        tbNak1U.Text = 0
        tbNak2U.Text = 0
        tbNak3U.Text = 0
        tbNak4U.Text = 0

        tbPdvIznosU.Text = 0           ' upuceno
        tbTugU.Text = 0                ' trosak u gotovom upuceno

        tbSumaU.Text = 0               ' SUMA UPUCENO

        ' Resetovanje promenljivih
        Me.tbBrojOtp.Text = ""
        Me.tbBrojPr.Text = ""

        mPosiljalac = 0
        mPrimalac = 0

        bBlagFranko = 0
        bBlagUpuceno = 0
        bRazlikaFr = 0
        bRazlikaUp = 0
        b35Posto = False                ' popust za prazne kontejnere

        bNarocitaPosiljka = False

        Me.FR_Stanica.Text = 0
        Me.UP_Stanica.Text = 0
        Me.FR_Razlika.Text = 0
        Me.UP_Razlika.Text = 0

        ' Zadrzani podaci sa pretodnog tovarnog lista i promenljive
        '   - PO ZAHTEVU:
        '   Vrsta saobracaja            tbR8        ComboBox4           bVrstaSaobracaja        
        '   tarifa                      ComboBox1( spt36, Ugovori )   
        '                               ComboBox3 (1..9)
        '   otpravna stanica            tbR13_1     tbStanicaOtp        mOtpStanica
        '   datum otpravljanja          DatumOtp
        '   uputna stanica              tbR33_1     tbStanicaPr         mPrStanica
        '   datum prispeca              DateTimePicker2

        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()
        dtK211.Clear()

        btnUnosRobe.Text = ""

        lblFrankoRazlika.Text = ""
        lblUpucenoRazlika.Text = ""

        bDKIznos = 0
        tbDKIznos.Text = 0
        gbDorKarta.Visible = False
        bTarifa72 = 0
        bbPredujam = 0


        bNepokrivenaMasa = 0
        bPrevozninaKoef = 1
        bVrstaSaobracaja = 0

        ExMMIndex = -1
        ImMMIndex = -1

        bPDV1IzSloga = 0
        bPDV2IzSloga = 0

        mVrstaObracuna = "RO"

    End Sub
    Public Sub DownloadeUTL()
        Dim ss1 As Int32 = 0

        If RecordAction = "P" Then
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If
        ElseIf RecordAction = "N" Then
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
        End If


        dsServer2Client.Clear()

        Try


            If RecordAction = "P" Then
                Dim adServer2Client As New SqlDataAdapter("SELECT RecID, R2, R4, R5, R6, R7, R8, R9, R10, R10KB, R11, R12a, R12b, " _
                            & "R13a, R13b, R14a, R14b, r15, R15a, r16, r17, r18, r19, R20a, R20b, R27, R28, R29, " _
                            & "R30a, R30b, R31a, R32b, R32, R32a, R33a, R33b, R34, R35, R36, R37, RID, R41Suma, " _
                            & "R42_1, R42_2, R42_3, R42_4, R42_5, R42_6, R43_1, R43_2, R43_3, R43_4, R43_5, R43_6, " _
                            & "R44, R44n, R44i, R45a, R45b, R46, R47, R48a, R48b, R49, R50, " _
                            & "R51, R53, R54_1, R54_2, R54_3, R55_1, R55_2, R55_3, R56_1, R56_2, R56_3, R57_1, R57_2, R57_3, R58, R59, R60, " _
                            & "R61F, R61U, R64F_1, R64F_2, R64F_3, R64F_4, R64F_5, R64F_6, R62A_1, " _
                            & "R62A_2, R62A_3, R62A_4, R62A_5, R63A, R62B_1, R62B_2, R62B_3, R62B_4, R62B_5, R63B, R62C_1, R62C_2, R62C_3, R62C_4, R62C_5, R63C, " _
                            & "R64U_1, R64U_2, R64U_3, R64U_4, R64U_5, R64U_6, R65F, R65U, R66a, R66b " _
                            & "FROM SlogUTL " _
                            & "WHERE (RecID = " & UpdRecID & ")", DbVeza)
                ss1 = adServer2Client.Fill(dsServer2Client)

            ElseIf RecordAction = "N" Then
                Dim adServer2Client As New SqlDataAdapter("SELECT RecID, R2, R4, R5, R6, R7, R8, R9, R10, R10KB, R11, R12a, R12b, " _
                            & "R13a, R13b, R14a, R14b, r15, R15a, r16, r17, r18, r19, R20a, R20b, R27, R28, R29, " _
                            & "R30a, R30b, R31a, R32b, R32, R32a, R33a, R33b, R34, R35, R36, R37, RID, R41Suma, " _
                            & "R42_1, R42_2, R42_3, R42_4, R42_5, R42_6, R43_1, R43_2, R43_3, R43_4, R43_5, R43_6, " _
                            & "R44, R44n, R44i, R45a, R45b, R46, R47, R48a, R48b, R49, R50, " _
                            & "R51, R53, R54_1, R54_2, R54_3, R55_1, R55_2, R55_3, R56_1, R56_2, R56_3, R57_1, R57_2, R57_3, R58, R59, R60, " _
                            & "R61F, R61U, R64F_1, R64F_2, R64F_3, R64F_4, R64F_5, R64F_6, R62A_1, " _
                            & "R62A_2, R62A_3, R62A_4, R62A_5, R63A, R62B_1, R62B_2, R62B_3, R62B_4, R62B_5, R63B, R62C_1, R62C_2, R62C_3, R62C_4, R62C_5, R63C, " _
                            & "R64U_1, R64U_2, R64U_3, R64U_4, R64U_5, R64U_6, R65F, R65U, R66a, R66b " _
                            & "FROM SlogUTL " _
                            & "WHERE (RecID = " & UpdRecID & ")", OkpDbVeza)
                ss1 = adServer2Client.Fill(dsServer2Client)

            End If

            For k As Int16 = 0 To dsServer2Client.Tables(0).Rows.Count - 1

                tbR2.Text = dsServer2Client.Tables(0).Rows(k).Item(1)

                If dsServer2Client.Tables(0).Rows(k).Item(2) = "1" Then
                    cbR4K.Checked = True
                    cbR4D.Checked = False
                Else
                    cbR4K.Checked = False
                    cbR4D.Checked = True
                End If

                If dsServer2Client.Tables(0).Rows(k).Item(3) = "1" Then
                    cbR5R.Checked = True
                    cbR5O.Checked = False
                    cbR5D.Checked = False
                    cbR5E.Checked = False
                ElseIf dsServer2Client.Tables(0).Rows(k).Item(3) = "2" Then
                    cbR5R.Checked = False
                    cbR5O.Checked = True
                    cbR5D.Checked = False
                    cbR5E.Checked = False
                ElseIf dsServer2Client.Tables(0).Rows(k).Item(3) = "3" Then
                    cbR5R.Checked = False
                    cbR5O.Checked = False
                    cbR5D.Checked = True
                    cbR5E.Checked = False
                ElseIf dsServer2Client.Tables(0).Rows(k).Item(3) = "4" Then
                    cbR5R.Checked = False
                    cbR5O.Checked = False
                    cbR5D.Checked = False
                    cbR5E.Checked = True
                End If

                If dsServer2Client.Tables(0).Rows(k).Item(4) = "1" Then
                    cbR6.Checked = True
                End If

                tbR7.Text = dsServer2Client.Tables(0).Rows(k).Item(5)
                tbR8.Text = dsServer2Client.Tables(0).Rows(k).Item(6)
                tbR9.Text = dsServer2Client.Tables(0).Rows(k).Item(7)
                rtbR10.Text = dsServer2Client.Tables(0).Rows(k).Item(8)
                tbCtrlNum.Text = dsServer2Client.Tables(0).Rows(k).Item(9)
                tbR11.Text = dsServer2Client.Tables(0).Rows(k).Item(10)
                tbR12Sifra.Text = dsServer2Client.Tables(0).Rows(k).Item(11)
                tbR12Naziv.Text = dsServer2Client.Tables(0).Rows(k).Item(12)
                '-------------------------------------------------------------
                tbR13_1.Text = dsServer2Client.Tables(0).Rows(k).Item(13)
                tbR13_2.Text = dsServer2Client.Tables(0).Rows(k).Item(14)
                tbR14Sifra.Text = dsServer2Client.Tables(0).Rows(k).Item(15)
                tbR14Naziv.Text = dsServer2Client.Tables(0).Rows(k).Item(16)
                tbR15.Text = dsServer2Client.Tables(0).Rows(k).Item(17)
                tb15_1.Text = dsServer2Client.Tables(0).Rows(k).Item(18)
                rtbR16.Text = dsServer2Client.Tables(0).Rows(k).Item(19)
                tbR17.Text = dsServer2Client.Tables(0).Rows(k).Item(20)
                tbR18.Text = dsServer2Client.Tables(0).Rows(k).Item(21)
                tbR19.Text = dsServer2Client.Tables(0).Rows(k).Item(22)
                tbR20a.Text = dsServer2Client.Tables(0).Rows(k).Item(23)
                tbR20b.Text = dsServer2Client.Tables(0).Rows(k).Item(24)
                rtbR27.Text = dsServer2Client.Tables(0).Rows(k).Item(25)
                tbR28.Text = dsServer2Client.Tables(0).Rows(k).Item(26)
                If dsServer2Client.Tables(0).Rows(k).Item(27) = "1" Then
                    CheckBox5.Checked = True
                    CheckBox7.Checked = False
                Else
                    CheckBox5.Checked = False
                    CheckBox7.Checked = True
                End If
                '-------------------------------------------------------------
                tbR30Sifra.Text = dsServer2Client.Tables(0).Rows(k).Item(28)
                tbR30Naziv.Text = dsServer2Client.Tables(0).Rows(k).Item(29)
                tbR31Sifra.Text = dsServer2Client.Tables(0).Rows(k).Item(30)
                tbR31naziv.Text = dsServer2Client.Tables(0).Rows(k).Item(31)
                tbR32a.Text = dsServer2Client.Tables(0).Rows(k).Item(32)
                tbR32b.Text = dsServer2Client.Tables(0).Rows(k).Item(33)
                tbR33_1.Text = dsServer2Client.Tables(0).Rows(k).Item(34)
                tbStanicaPr.Text = tbR33_1.Text
                tbR33_2.Text = dsServer2Client.Tables(0).Rows(k).Item(35)
                rtbR34.Text = dsServer2Client.Tables(0).Rows(k).Item(36)
                tbR35.Text = dsServer2Client.Tables(0).Rows(k).Item(37)
                tbR36.Text = dsServer2Client.Tables(0).Rows(k).Item(38)
                rtb37.Text = dsServer2Client.Tables(0).Rows(k).Item(39)
                If dsServer2Client.Tables(0).Rows(k).Item(40) = "1" Then
                    cbRID.Checked = True
                Else
                    cbRID.Checked = False
                End If
                tbR41Suma.Text = dsServer2Client.Tables(0).Rows(k).Item(41)
                '-------------------------------------------------------------
                tbR42a.Text = dsServer2Client.Tables(0).Rows(k).Item(42)
                tbR42b.Text = dsServer2Client.Tables(0).Rows(k).Item(43)
                tbR42c.Text = dsServer2Client.Tables(0).Rows(k).Item(44)
                tbR42d.Text = dsServer2Client.Tables(0).Rows(k).Item(45)
                tbR42e.Text = dsServer2Client.Tables(0).Rows(k).Item(46)
                tbR42f.Text = "" 'dsServer2Client.Tables(0).Rows(k).Item(47)
                tbR43a.Text = dsServer2Client.Tables(0).Rows(k).Item(48)
                tbR43b.Text = dsServer2Client.Tables(0).Rows(k).Item(49)
                tbR43c.Text = dsServer2Client.Tables(0).Rows(k).Item(50)
                tbR43d.Text = dsServer2Client.Tables(0).Rows(k).Item(51)
                tbR43e.Text = dsServer2Client.Tables(0).Rows(k).Item(52)
                tbR43f.Text = "" 'dsServer2Client.Tables(0).Rows(k).Item(53)
                '-------------------------------------------------------------
                If dsServer2Client.Tables(0).Rows(k).Item(54) = "1" Then
                    CheckBox1.Checked = True
                    CheckBox2.Checked = False
                    CheckBox3.Checked = False
                    CheckBox4.Checked = False
                ElseIf dsServer2Client.Tables(0).Rows(k).Item(54) = "2" Then
                    CheckBox1.Checked = False
                    CheckBox2.Checked = True
                    CheckBox3.Checked = False
                    CheckBox4.Checked = False
                ElseIf dsServer2Client.Tables(0).Rows(k).Item(54) = "3" Then
                    CheckBox1.Checked = False
                    CheckBox2.Checked = False
                    CheckBox3.Checked = True
                    CheckBox4.Checked = False
                ElseIf dsServer2Client.Tables(0).Rows(k).Item(54) = "4" Then
                    CheckBox1.Checked = False
                    CheckBox2.Checked = False
                    CheckBox3.Checked = False
                    CheckBox4.Checked = True
                End If
                If Len(dsServer2Client.Tables(0).Rows(k).Item(55)) = 0 Then
                    tb20a.Text = ""
                    tb20b.Text = ""
                    tb20c.Text = ""
                    tb20d.Text = ""
                ElseIf Len(dsServer2Client.Tables(0).Rows(k).Item(55)) = 2 Then
                    tb20a.Text = dsServer2Client.Tables(0).Rows(k).Item(55)
                    tb20b.Text = ""
                    tb20c.Text = ""
                    tb20d.Text = ""
                ElseIf Len(dsServer2Client.Tables(0).Rows(k).Item(55)) = 4 Then
                    tb20a.Text = Microsoft.VisualBasic.Left(dsServer2Client.Tables(0).Rows(k).Item(55), 2)
                    tb20b.Text = Microsoft.VisualBasic.Mid(dsServer2Client.Tables(0).Rows(k).Item(55), 3, 2)
                    tb20c.Text = ""
                    tb20d.Text = ""
                ElseIf Len(dsServer2Client.Tables(0).Rows(k).Item(55)) = 6 Then
                    tb20a.Text = Microsoft.VisualBasic.Left(dsServer2Client.Tables(0).Rows(k).Item(55), 2)
                    tb20b.Text = Microsoft.VisualBasic.Mid(dsServer2Client.Tables(0).Rows(k).Item(55), 3, 2)
                    tb20c.Text = Microsoft.VisualBasic.Mid(dsServer2Client.Tables(0).Rows(k).Item(55), 5, 2)
                    tb20d.Text = ""
                ElseIf Len(dsServer2Client.Tables(0).Rows(k).Item(55)) = 8 Then
                    tb20a.Text = Microsoft.VisualBasic.Left(dsServer2Client.Tables(0).Rows(k).Item(55), 2)
                    tb20b.Text = Microsoft.VisualBasic.Mid(dsServer2Client.Tables(0).Rows(k).Item(55), 3, 2)
                    tb20c.Text = Microsoft.VisualBasic.Mid(dsServer2Client.Tables(0).Rows(k).Item(55), 5, 2)
                    tb20d.Text = Microsoft.VisualBasic.Mid(dsServer2Client.Tables(0).Rows(k).Item(55), 7, 2)
                End If
                tbR44Iznos.Text = dsServer2Client.Tables(0).Rows(k).Item(56)
                tbR45a.Text = dsServer2Client.Tables(0).Rows(k).Item(57)
                tbR45b.Text = dsServer2Client.Tables(0).Rows(k).Item(58)
                tbR46.Text = dsServer2Client.Tables(0).Rows(k).Item(59)
                tbR47.Text = dsServer2Client.Tables(0).Rows(k).Item(60)
                tbR48a.Text = dsServer2Client.Tables(0).Rows(k).Item(61)
                tbR48b.Text = dsServer2Client.Tables(0).Rows(k).Item(62)
                tbR49.Text = dsServer2Client.Tables(0).Rows(k).Item(63)
                tbR50.Text = dsServer2Client.Tables(0).Rows(k).Item(64)
                '-------------------------------------------------------------
                tbR51.Text = dsServer2Client.Tables(0).Rows(k).Item(65)
                tbR53.Text = dsServer2Client.Tables(0).Rows(k).Item(66)
                tbR54_1.Text = dsServer2Client.Tables(0).Rows(k).Item(67)
                tbR54_2.Text = dsServer2Client.Tables(0).Rows(k).Item(68)
                tbR54_3.Text = dsServer2Client.Tables(0).Rows(k).Item(69)
                tbPrevStav1.Text = dsServer2Client.Tables(0).Rows(k).Item(70)
                tbPrevStav2.Text = dsServer2Client.Tables(0).Rows(k).Item(71)
                tbPrevStav3.Text = dsServer2Client.Tables(0).Rows(k).Item(72)
                tb56a.Text = dsServer2Client.Tables(0).Rows(k).Item(73)
                tb56b.Text = dsServer2Client.Tables(0).Rows(k).Item(74)
                tb56c.Text = dsServer2Client.Tables(0).Rows(k).Item(75)
                tbR57_1.Text = dsServer2Client.Tables(0).Rows(k).Item(76)
                tbR57_2.Text = dsServer2Client.Tables(0).Rows(k).Item(77)
                tbR57_3.Text = dsServer2Client.Tables(0).Rows(k).Item(78)
                tbR58.Text = dsServer2Client.Tables(0).Rows(k).Item(79)
                tbR59.Text = dsServer2Client.Tables(0).Rows(k).Item(80)
                tbR60.Text = dsServer2Client.Tables(0).Rows(k).Item(81)
                '-------------------------------------------------------------
                tbPrevF.Text = dsServer2Client.Tables(0).Rows(k).Item(82)
                tbPrevU.Text = dsServer2Client.Tables(0).Rows(k).Item(83)
                tbNak1F.Text = dsServer2Client.Tables(0).Rows(k).Item(84)
                tbNak2F.Text = dsServer2Client.Tables(0).Rows(k).Item(85)
                tbNak3F.Text = dsServer2Client.Tables(0).Rows(k).Item(86)
                tbNak4F.Text = dsServer2Client.Tables(0).Rows(k).Item(87)
                tbPdvIznosF.Text = dsServer2Client.Tables(0).Rows(k).Item(88)
                tbTugF.Text = dsServer2Client.Tables(0).Rows(k).Item(89)
                tbA79a1.Text = dsServer2Client.Tables(0).Rows(k).Item(90)
                tbA79a2.Text = dsServer2Client.Tables(0).Rows(k).Item(91)
                tbA79a3.Text = dsServer2Client.Tables(0).Rows(k).Item(92)
                tbA79a4.Text = dsServer2Client.Tables(0).Rows(k).Item(93)
                tbPDVF.Text = dsServer2Client.Tables(0).Rows(k).Item(94)
                tb63a.Text = dsServer2Client.Tables(0).Rows(k).Item(95)
                tbA79b1.Text = dsServer2Client.Tables(0).Rows(k).Item(96)
                tbA79b2.Text = dsServer2Client.Tables(0).Rows(k).Item(97)
                tbA79b3.Text = dsServer2Client.Tables(0).Rows(k).Item(98)
                tbA79b4.Text = dsServer2Client.Tables(0).Rows(k).Item(99)
                tbPDVU.Text = dsServer2Client.Tables(0).Rows(k).Item(100)
                tb63b.Text = dsServer2Client.Tables(0).Rows(k).Item(101)
                tb62na.Text = dsServer2Client.Tables(0).Rows(k).Item(102)
                tb62nb.Text = dsServer2Client.Tables(0).Rows(k).Item(103)
                tb62nc.Text = dsServer2Client.Tables(0).Rows(k).Item(104)
                tb62nd.Text = dsServer2Client.Tables(0).Rows(k).Item(105)
                tbPDV.Text = dsServer2Client.Tables(0).Rows(k).Item(106)
                tbTug.Text = dsServer2Client.Tables(0).Rows(k).Item(107)
                tbNak1U.Text = dsServer2Client.Tables(0).Rows(k).Item(108)
                tbNak2U.Text = dsServer2Client.Tables(0).Rows(k).Item(109)
                tbNak3U.Text = dsServer2Client.Tables(0).Rows(k).Item(110)
                tbNak4U.Text = dsServer2Client.Tables(0).Rows(k).Item(111)
                tbPdvIznosU.Text = dsServer2Client.Tables(0).Rows(k).Item(112)
                tbTugU.Text = dsServer2Client.Tables(0).Rows(k).Item(113)
                tbSumaF.Text = dsServer2Client.Tables(0).Rows(k).Item(114)
                tbSumaU.Text = dsServer2Client.Tables(0).Rows(k).Item(115)
                If dsServer2Client.Tables(0).Rows(k).Item(116) = "1" Then
                    CheckBox6.Checked = True
                Else
                    CheckBox6.Checked = False
                End If
                tbR68b.Text = dsServer2Client.Tables(0).Rows(k).Item(117)
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

            If RecordAction = "P" Then
                DbVeza.Close()
            ElseIf RecordAction = "N" Then
                OkpDbVeza.Close()
            End If

        End Try
    End Sub

    Private Sub cmbManipulativnaMestaEx_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbManipulativnaMestaEx.Click
        'Nadzorna()
        'ExMMIndex = cmbManipulativnaMestaEx.SelectedIndex
    End Sub

    Private Sub FR_Stanica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FR_Stanica.KeyPress

        'Dim ascii As Integer = Asc(e.KeyChar.ToString)
        'If DecimalSeparator = "," Then
        '    If ascii = 46 Then
        '        e.KeyChar = ","
        '    End If
        'ElseIf DecimalSeparator = "." Then
        '    If ascii = 44 Then
        '        e.KeyChar = "."
        '    End If
        'End If

        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
    Private Sub FR_Stanica_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FR_Stanica.LostFocus
        Dim mBlagajna As Decimal = CDec(FR_Stanica.Text)
        FR_Stanica.Text = Format(mBlagajna, "###,###,##0.00")

        Dim mRazlika As Decimal = CDec(FR_Stanica.Text)
        Dim mSumaDinari As Decimal = CDec(tbSumaF.Text)
        mRazlika = mBlagajna - mSumaDinari
        bRazlikaFr = mRazlika
        FR_Razlika.Text = Format(mRazlika, "###,###,##0.00")
        lblFrankoRazlika.Text = Format(mRazlika, "###,###,##0.00")
    End Sub


    Private Sub ComboBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox3.Validating

        Select Case ComboBox3.SelectedIndex
            Case 0                      ' pojedinacna posiljka  00
                bTarifa72 = 0
            Case 1                      ' grupa kola            49
                bTarifa72 = 49
            Case 2                      ' marsrutni voz         46
                bTarifa72 = 46
            Case 3                      ' P9 uputnica za besplatan prevoz   91
                bTarifa72 = 91
            Case 4                      ' SPT49 prevoz za potrebe ZS        92
                bTarifa72 = 92
            Case 5                      ' NP narocite posiljke              93
                bTarifa72 = 93
            Case 6                      ' Mesoviti vojni transport - cl.45, t.4     39
                bTarifa72 = 39
            Case 7                      ' Mesoviti vojni transport - cl.45, t.6     40
                bTarifa72 = 40
            Case 8                      ' Tov. pribor vlasnistvo kor. prevoza - cl.52, t.9
                bTarifa72 = 43
            Case 9                      ' poseban voz           48
                bTarifa72 = 48
            Case 10                     ' besplatan prevoz      99
                bTarifa72 = 99
            Case 11                     ' doracunska karta      94
                bTarifa72 = 94
                gbDorKarta.Visible = True
        End Select

        If Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 1) = "1" Then
            tbStanicaOtp.SelectAll()
            tbStanicaOtp.Focus()
        Else

        End If


        If Not (bTarifa72 = 94) Then
            gbDorKarta.Visible = False
        End If


    End Sub

    Private Sub UP_Stanica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UP_Stanica.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub UP_Stanica_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UP_Stanica.LostFocus
        Dim mBlagajna2 As Decimal = CDec(UP_Stanica.Text)
        UP_Stanica.Text = Format(mBlagajna2, "###,###,##0.00")

        Dim mRazlika2 As Decimal = CDec(UP_Stanica.Text)
        Dim mSumaDinari2 As Decimal = CDec(tbSumaU.Text)
        mRazlika2 = mBlagajna2 - mSumaDinari2
        bRazlikaUp = mRazlika2
        UP_Razlika.Text = Format(mRazlika2, "###,###,##0.00")
        If (bRazlikaFr <= -250) Or (bRazlikaUp <= -250) Then
            Me.Button6.Focus()
        Else
            Me.btnUpis.Focus()
        End If
        lblUpucenoRazlika.Text = Format(mRazlika2, "###,###,##0.00")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim frmK211 As New FormK211
        frmK211.ShowDialog()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim DaNe As Boolean = False
        Dim VPPForma As New VPP
        Dim VPPPregledForma As New VPPPregled
        upit = "VPP"



        Dim St1, St2 As String

        If cmbManipulativnaMestaEx.Text = "" Then
            St1 = mStanica1
        Else
            St1 = Microsoft.VisualBasic.Left(Me.cmbManipulativnaMestaEx.Text, 5)
        End If

        If cmbManipulativnaMestaIm.Text = "" Then
            St2 = mStanica2
        Else
            St2 = Microsoft.VisualBasic.Left(Me.cmbManipulativnaMestaIm.Text, 5)
        End If


        'VPPPregledForma.bPotraziVPP(mStanica1, mStanica2, DaNe)
        VPPPregledForma.bPotraziVPP(St1, St2, DaNe)

        If DaNe = True Then
            VPPPregledForma.ShowDialog()
        Else
            VPPForma.ShowDialog()
        End If

        'Me.tbKm1.Focus()
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

    Private Sub cbZsPrevozniPut_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbZsPrevozniPut.Leave

        If Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "3" Or Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "4" Then
            tbPrev1.Visible = True
            tbPrev2.Visible = True

            Lomljena = "D"
            tbStanicaLom.Visible = True
            tbStanicaLom.Enabled = True
            tbR53_LP2.Enabled = True
            tbR53_LP2.Visible = True
            tbStanicaLom.Focus()

        ElseIf Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "2" Then
            tbPrev1.Visible = False
            tbPrev2.Visible = False

            Lomljena = "N"
            tbStanicaLom.Visible = False
            tbStanicaLom.Enabled = False
            tbR53_LP2.Visible = False
            Me.Button5.Visible = True
            Button5.Focus()

        ElseIf Microsoft.VisualBasic.Left(cbZsPrevozniPut.Text, 1) = "1" Then
            tbPrev1.Visible = False
            tbPrev2.Visible = False

            Lomljena = "N"
            tbStanicaLom.Visible = False
            tbStanicaLom.Enabled = False
            tbR53_LP2.Visible = False

        End If

    End Sub
    Private Sub CheckBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CheckBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub CheckBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CheckBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub CheckBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CheckBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub CheckBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CheckBox4.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub CheckBox4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CheckBox4.Validating
        If CheckBox4.Checked = True Then
            Me.tbR44Iznos.Focus()
        Else
            tbR44Iznos.Text = 0
            'Me.Button18.Focus()
            Me.btnUnosRobe.Focus()
        End If
    End Sub

    Private Sub Button18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Button18.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbR11_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbR11.Validating
        Dim xNaziv As String = ""
        Dim xMesto As String = ""
        Dim xZemlja As String = ""
        Dim xAdresa As String = ""
        Dim xPovVrednost As String = ""

        Util.sNadjiKorisnika(tbR11.Text, xNaziv, xMesto, xZemlja, xAdresa, xPovVrednost)

        If xPovVrednost <> "" Then
            rtbR10.Text = "Nepostojeci korisnik"
            tbR11.Focus()
        Else
            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            rtbR10.Text = xNaziv & vbCrLf & vbCrLf & xZemlja & vbCrLf & xMesto & vbCrLf & xAdresa
            Me.tbR17.Focus()
        End If

        If (tbR11.Text = "") Or (tbR11.Text = "0") Then
            mPosiljalac = 0
        Else
            mPosiljalac = tbR11.Text
        End If

    End Sub
    Private Sub tbR11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbR11.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbR17_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbR17.Validating
        Dim xNaziv As String = ""
        Dim xMesto As String = ""
        Dim xZemlja As String = ""
        Dim xAdresa As String = ""
        Dim xPovVrednost As String = ""

        Util.sNadjiKorisnika(tbR17.Text, xNaziv, xMesto, xZemlja, xAdresa, xPovVrednost)

        If xPovVrednost <> "" Then
            rtbR16.Text = "Nepostojeci korisnik"
            tbR17.Focus()
        Else
            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            rtbR16.Text = xNaziv & vbCrLf & vbCrLf & xZemlja & vbCrLf & xMesto & vbCrLf & xAdresa
            'Me.btnUpis.Focus()
            btnUnosRobe.Focus()
        End If

        If (tbR17.Text = "") Or (tbR17.Text = "0") Then
            mPrimalac = 0
        Else
            mPrimalac = tbR17.Text
        End If

        CheckBox1.Focus()

    End Sub
    Private Sub tbR17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbR17.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbPDV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbPDV.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbPDV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPDV.Click
        If cbPDV.Checked = True Then

        Else

        End If

    End Sub

    'Private Sub cbPDV_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbPDV.Validating
    '    Me.ComboBox4.Focus()
    'End Sub

    Private Sub tbBrojPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojPr.Validating
        If tbBrojPr.Text = "0" Then
            ErrorProvider1.SetError(Label21, "Broj otpravljanja ne moze da bude nula!")
            tbBrojPr.Focus()
        Else
            If tbBrojPr.Text = Nothing Then
                ErrorProvider1.SetError(Label21, "Neispravan broj prispeæa!")
                tbBrojPr.Focus()
            Else
                'If IsNumeric(tbBrojPr.Text) = True Then
                '    Me.tbR13_2.Text = Me.tbBrojOtp.Text

                '    ErrorProvider1.SetError(Label21, "")
                'Else
                '    ErrorProvider1.SetError(Label21, "Neispravan unos!")
                '    tbBrojPr.Focus()
                'End If


                If IsNumeric(tbBrojPr.Text) = True Then

                    '---------------kontrola duplih prispeca za unutrasnji
                    If IzborSaobracaja = "1" Then
                        Dim mRetVal As String = ""
                        Dim mRecID As Int32
                        Dim mStanicaRecID As String

                        NadjiRacunskiMesecIGodinu()

                        NadjiTLpr(tbStanicaPr.Text, tbBrojPr.Text, mObrGodina, mRecID, mStanicaRecID, mRetVal)

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
    Private Sub bNadjiIPrikaziKurseve(ByVal inSifraValute As String)

        Dim strRetVal As String = ""
        Dim bVrstaKursa As String = ""

        If (mBrojUg = "200379" Or mVrstaObracuna = "CD") Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then
            bVrstaKursa = "3"
        Else
            bVrstaKursa = "1"
        End If

        If Not (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then         ' 25.07.2016 za sada; treba ukljuciti da li su cene u RSD ili EUR
            If inSifraValute = "17" Then
                NadjiKurs(inSifraValute, bVrstaKursa, mOtpDatum, bKursOt, strRetVal)
                NadjiKurs(inSifraValute, bVrstaKursa, mPrDatum, bKursPr, strRetVal)
                Label25.Visible = True
                Label26.Visible = True
                Label28.Visible = True
                TextBox3.Visible = False
                TextBox4.Visible = False
                TextBox3.Text = bKursOt
                TextBox4.Text = bKursPr
                lblOtpKurs.Visible = True
                lblOtpKurs.Text = bKursOt
                lblPrKurs.Visible = True
                lblPrKurs.Text = bKursPr
            End If
        ElseIf (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then
            Label25.Visible = False
            Label26.Visible = False
            Label28.Visible = False
            TextBox3.Visible = False
            TextBox4.Visible = False
            lblOtpKurs.Visible = False
            lblPrKurs.Visible = False
        End If


    End Sub

    Private Sub DateTimePicker2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker2.Validating
        If bVrstaSaobracaja <> 0 Then
            bNadjiIPrikaziKurseve(bValuta)
        Else
            If mBrojUg = "200379" Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then         ' 25.07.2016 za sada; treba ukljuciti da li su cene u RSD ili EUR
                bNadjiIPrikaziKurseve("17")
            End If
        End If
        If mOtpDatum > mPrDatum Then
            ErrorProvider1.SetError(Label20, "Neispravan datum!")
            DateTimePicker2.Focus()
        Else
            ErrorProvider1.SetError(Label20, "")
        End If
        If bTarifa72 = 94 Then
            tbDKIznos.Focus()
            gbDorKarta.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        End If

    End Sub

    Private Sub DateTimePicker2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.LostFocus
        mPrDatum = DateTimePicker2.Text
    End Sub
    Private Sub bPripremiZaUpisUBazu()
        bSumaLevo = CType(tbSumaF.Text, Decimal)
        bSumaDesno = CType(tbSumaU.Text, Decimal)
        bPrevozninaLevo = CType(tbPrevF.Text, Decimal)
        bPrevozninaDesno = CType(tbPrevU.Text, Decimal)
        bSumaNaknadaLevo = CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)
        bSumaNaknadaDesno = CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)

        If (tbR11.Text = "") Or (tbR11.Text = "0") Then
            mPosiljalac = 0
        Else
            mPosiljalac = tbR11.Text
        End If

        If (tbR17.Text = "") Or (tbR17.Text = "0") Then
            mPrimalac = 0
        Else
            mPrimalac = tbR17.Text
        End If




    End Sub
    Private Sub bIzbrisiNaknadeNaTL()

        tbNak1F.Text = 0
        tbNak1U.Text = 0
        tbA79a1.Text = ""
        tbA79b1.Text = ""
        tb62na.Text = ""

        tbNak2F.Text = 0
        tbNak2U.Text = 0
        tbA79a2.Text = ""
        tbA79b2.Text = ""
        tb62nb.Text = ""

        tbNak3F.Text = 0
        tbNak3U.Text = 0
        tbA79a3.Text = ""
        tbA79b3.Text = ""
        tb62nc.Text = ""

        tbNak4F.Text = 0
        tbNak4U.Text = 0
        tbA79a4.Text = ""
        tbA79b4.Text = ""
        tb62nd.Text = ""

    End Sub

    Private Sub tbR50_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbR50.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbR50_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbR50.Validating
        'Me.btnKalk_Click(Me, Nothing)      iskljucena kalkulacija da se ne bi menjala prevoznina
        tbR51.Text = tbR50.Text
        bbPredujam = tbR51.Text
        bOsveziIznoseLevoDesno()
    End Sub
    Private Sub bOsveziIznoseLevoDesno()

        Dim strRetVal As String = ""
        Dim bVrstaKursa As String = ""

        If mBrojUg = "200379" Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then         ' 25.07.2016 za sada; treba ukljuciti da li su cene u RSD ili EUR
            bVrstaKursa = "3"
        Else
            bVrstaKursa = "1"
        End If

        If bValuta = "17" Then
            NadjiKurs("17", bVrstaKursa, mOtpDatum, bKursOt, strRetVal)
            NadjiKurs("17", bVrstaKursa, mPrDatum, bKursPr, strRetVal)
            'mOutKurs = bKursPr                                  ' za sada; dovesti u vezu sa izjavom o placanju
        Else
            bKursOt = 1
            bKursPr = 1
            'mOutKurs = 1
        End If


        If (dtKola.Rows.Count > 0 And cbR4K.Checked = True) Or (bTarifa72 = 94) Then        ' kolske ili doracunska karta
            mStanica1 = Me.tbStanicaOtp.Text
            mStanica2 = Me.tbStanicaPr.Text

            UTLNaknadeR44(0) = Microsoft.VisualBasic.Trim(tb20a.Text)
            UTLNaknadeR44(1) = Microsoft.VisualBasic.Trim(tb20b.Text)
            UTLNaknadeR44(2) = Microsoft.VisualBasic.Trim(tb20c.Text)
            UTLNaknadeR44(3) = Microsoft.VisualBasic.Trim(tb20d.Text)

            mSifraIzjave = "0"

            If Me.CheckBox1.Checked = True Then
                mSifraIzjave = "1"
            End If
            If Me.CheckBox2.Checked = True Then
                mSifraIzjave = "2"
            End If
            If Me.CheckBox3.Checked = True Then
                mSifraIzjave = "3"
            End If
            If Me.CheckBox4.Checked = True Then
                mSifraIzjave = "4"
            End If

            If bTarifa72 = 91 And bNepokrivenaMasa > 0 Then
                bNadjiPDVKoef(mDatumKalk, bPDVKoef, bPDVKoefString)             ' 11.12.2013
                mPrevoznina = bPr91Nepokrivena * (bPDVKoef + 1)                 ' dodavanje pdv u prevozninu jer jedino tako moze da se prikaze
            End If

            '============= prikaz naknada
            If IzborSaobracaja = "1" Then
                ''        bNadjiPrevozninuGlavni()

                '================== konverzija EUR  -> RSD ==========================
                'Dim strRetVal As String = ""
                'Dim mOutKurs As Decimal = 0
                Dim mIznosDin As Decimal = 0


                If bValuta = "17" Then
                    Dim bKurs As Decimal
                    If bIzTBPrevoznina = True Then
                        mIznosDin = mPrevoznina
                    Else
                        If mSifraIzjave = "1" Then      ' franko svi troskovi
                            bKurs = bKursOt
                        ElseIf mSifraIzjave = "2" Then  ' franko prevoznina ukljucivo
                            bKurs = bKursOt
                        ElseIf mSifraIzjave = "3" Then  ' franko prevoznina
                            bKurs = bKursOt
                        ElseIf mSifraIzjave = "4" Then  ' franko do iznosa

                        ElseIf mSifraIzjave = "0" Then  ' upuceno sve
                            bKurs = bKursPr
                        End If
                        If (_OpenForm = "Naknade") Then
                            mIznosDin = mPrevoznina
                        Else
                            mIznosDin = bKurs * bbPrevozninaUEvrima
                            bZaokruziNaDeseteNavise(mIznosDin)
                        End If
                    End If
                    mPrevoznina = mIznosDin

                End If
                '====================================================================
                If mSifraIzjave = "1" Then 'franko svi troskovi
                    'tbPrevF.Text = mPrevoznina
                    tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevU.Text = 0
                    bPrevozninaLevo = mPrevoznina
                    bPrevozninaDesno = 0
                ElseIf mSifraIzjave = "2" Then ' franko prevoznina ukljucivo
                    'tbPrevF.Text = mPrevoznina
                    tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevU.Text = 0
                    bPrevozninaLevo = mPrevoznina
                    bPrevozninaDesno = 0
                ElseIf mSifraIzjave = "3" Then 'franko prevoznina 
                    'tbPrevF.Text = mPrevoznina
                    tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevU.Text = 0
                    bPrevozninaLevo = mPrevoznina
                    bPrevozninaLevo = 0
                ElseIf mSifraIzjave = "4" Then 'franko do iznosa
                Else ' upuceno svi troskovi
                    'tbPrevU.Text = mPrevoznina
                    tbPrevU.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevF.Text = 0
                    bPrevozninaLevo = 0
                    bPrevozninaDesno = mPrevoznina
                End If

                '------------------------------------------------

                tbPrevStav1.Text = Format(bVozarinskiStavPoKolima, "###,###,##0.00")
                tbR54_1.Text = dtNhm.Rows(0).Item(4)
                tbR42a.Text = dtNhm.Rows(0).Item(1)
                tbR41Suma.Text = dtNhm.Compute("SUM(Masa)", String.Empty)

                Dim Rz1, Rz2, Rz3 As String
                Dim M1, M2, M3 As Decimal
                bNadjiRacunskuMasuPoPosiljciPoRazredima(Rz1, M1, Rz2, M2, Rz3, M3)

                If M1 > 0 Then
                    tbR54_1.Text = Rz1
                    tbR57_1.Text = Format(M1, "###,###,##0.00")
                End If
                If M2 > 0 Then
                    tbR54_2.Text = Rz2
                    tbR57_2.Text = Format(M2, "###,###,##0.00")
                End If
                If M3 > 0 Then
                    tbR54_3.Text = Rz3
                    tbR57_3.Text = Format(M3, "###,###,##0.00")
                End If

                'tbR21_1.Text = dtKola.Rows(0).Item(3)
                'Me.tbIBK.Text = dtKola.Rows(0).Item(0)
                'tbR23_1.Text = dtKola.Rows(0).Item(7)
                'tbR24_1.Text = dtKola.Rows(0).Item(6)
                'tbR25a_1.Text = dtKola.Rows(0).Item(2)
                'tbR25b_1.Text = dtKola.Rows.Count
                'tbR26_1.Text = dtKola.Rows(0).Item(5)

                ' zbog drugacije strukture dtKola:
                tbR21_1.Text = dtKola.Rows(0).Item(4)
                Me.tbIBK.Text = dtKola.Rows(0).Item(0)
                tbR23_1.Text = dtKola.Rows(0).Item(7)
                tbR24_1.Text = dtKola.Rows(0).Item(1)
                tbR25a_1.Text = dtKola.Rows(0).Item(9)
                tbR25b_1.Text = dtKola.Rows.Count
                tbR26_1.Text = dtKola.Rows(0).Item(2)


                Me.tbSumaNeto.Text = tbR24_1.Text
                Me.tbSumaKola.Text = dtKola.Rows.Count
                Me.tbSumaOsovina.Text = tbR26_1.Text


                Dim i_TotalNak As String = ""
                Dim i_Pronasao As Int32 = 0
                Dim tmp_Naknada As Decimal
                'Dim tmp_pdv_f As Decimal
                'Dim tmp_pdv_u As Decimal
                Dim tmp_suma_f As Decimal
                Dim tmp_suma_u As Decimal
                Dim Nak_Red As DataRow
                Dim tmp_red As Int16 = 1

                If dtNaknade.Rows.Count > 0 Then
                    Dim bKursZaPrikazNaknada As Decimal = 1
                    For Each Nak_Red In dtNaknade.Rows

                        If Nak_Red.Item("Sifra") <> "62" Then

                            i_TotalNak = Nak_Red.Item("Sifra")
                            i_Pronasao = 0

                            If mSifraIzjave = "1" Then 'franko svi troskovi
                                If _OpenForm = "Naknade" Then
                                    bKursZaPrikazNaknada = bKursOt
                                Else
                                    bKursZaPrikazNaknada = bKursOt
                                    ' E bKursZaPrikazNaknada = 1
                                End If

                                If tmp_red = 1 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak1F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak1F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak1U.Text = 0
                                    tbA79a1.Text = Nak_Red.Item("Sifra")
                                    tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                    tb62na.Text = bNazivNaknadeArr(0)
                                ElseIf tmp_red = 2 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak2F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak2F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak2U.Text = 0
                                    tbA79a2.Text = Nak_Red.Item("Sifra")
                                    tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nb.Text = bNazivNaknadeArr(1)
                                ElseIf tmp_red = 3 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak3F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak3F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak3U.Text = 0
                                    tbA79a3.Text = Nak_Red.Item("Sifra")
                                    tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nc.Text = bNazivNaknadeArr(2)
                                ElseIf tmp_red = 4 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak4F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak4F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak4U.Text = 0
                                    tbA79a4.Text = Nak_Red.Item("Sifra")
                                    tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nd.Text = bNazivNaknadeArr(3)
                                End If

                            ElseIf mSifraIzjave = "2" Then ' franko prevoznina ukljucivo


                                For aa As Int16 = 0 To 3
                                    If UTLNaknadeR44(aa) = i_TotalNak Then
                                        i_Pronasao = 1
                                        Exit For
                                    End If
                                Next

                                If i_Pronasao = 1 Then

                                    If _OpenForm = "Naknade" Then
                                        bKursZaPrikazNaknada = bKursOt
                                    Else
                                        bKursZaPrikazNaknada = bKursOt
                                        ' E bKursZaPrikazNaknada = 1
                                    End If

                                    If tmp_red = 1 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak1F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak1F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak1U.Text = 0
                                        tbA79a1.Text = Nak_Red.Item("Sifra")
                                        tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                        tb62na.Text = bNazivNaknadeArr(0)
                                    ElseIf tmp_red = 2 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak2F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak2F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak2U.Text = 0
                                        tbA79a2.Text = Nak_Red.Item("Sifra")
                                        tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nb.Text = bNazivNaknadeArr(1)
                                    ElseIf tmp_red = 3 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak3F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak3F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak3U.Text = 0
                                        tbA79a3.Text = Nak_Red.Item("Sifra")
                                        tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nc.Text = bNazivNaknadeArr(2)
                                    ElseIf tmp_red = 4 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak4F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak4F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak4U.Text = 0
                                        tbA79a4.Text = Nak_Red.Item("Sifra")
                                        tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nd.Text = bNazivNaknadeArr(3)
                                    End If
                                Else
                                    If _OpenForm = "Naknade" Then
                                        bKursZaPrikazNaknada = bKursPr
                                    Else
                                        bKursZaPrikazNaknada = bKursPr
                                        ' E bKursZaPrikazNaknada = 1
                                    End If

                                    If tmp_red = 1 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak1U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak1F.Text = 0
                                        tbA79a1.Text = Nak_Red.Item("Sifra")
                                        tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                        tb62na.Text = bNazivNaknadeArr(0)
                                    ElseIf tmp_red = 2 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak2U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak2F.Text = 0
                                        tbA79a2.Text = Nak_Red.Item("Sifra")
                                        tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nb.Text = bNazivNaknadeArr(1)
                                    ElseIf tmp_red = 3 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak3U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak3F.Text = 0
                                        tbA79a3.Text = Nak_Red.Item("Sifra")
                                        tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nc.Text = bNazivNaknadeArr(2)
                                    ElseIf tmp_red = 4 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak4U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak4F.Text = 0
                                        tbA79a4.Text = Nak_Red.Item("Sifra")
                                        tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nd.Text = bNazivNaknadeArr(3)
                                    End If
                                End If

                            ElseIf mSifraIzjave = "3" Then 'franko prevoznina 
                                If _OpenForm = "Naknade" Then
                                    bKursZaPrikazNaknada = bKursPr
                                Else
                                    bKursZaPrikazNaknada = bKursPr
                                    ' E bKursZaPrikazNaknada = 1
                                End If

                                If tmp_red = 1 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak1U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak1F.Text = 0
                                    tbA79a1.Text = Nak_Red.Item("Sifra")
                                    tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                    tb62na.Text = bNazivNaknadeArr(0)
                                ElseIf tmp_red = 2 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak2U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak2F.Text = 0
                                    tbA79a2.Text = Nak_Red.Item("Sifra")
                                    tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nb.Text = bNazivNaknadeArr(1)
                                ElseIf tmp_red = 3 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak3U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak3F.Text = 0
                                    tbA79a3.Text = Nak_Red.Item("Sifra")
                                    tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nc.Text = bNazivNaknadeArr(2)
                                ElseIf tmp_red = 4 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak4U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak4F.Text = 0
                                    tbA79a4.Text = Nak_Red.Item("Sifra")
                                    tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nd.Text = bNazivNaknadeArr(3)
                                End If
                            ElseIf mSifraIzjave = "4" Then ' franko do iznosa

                            Else ' upuceno svi troskovi

                                If _OpenForm = "Naknade" Then
                                    bKursZaPrikazNaknada = bKursPr
                                Else
                                    bKursZaPrikazNaknada = bKursPr
                                    ' E bKursZaPrikazNaknada = 1
                                End If

                                If tmp_red = 1 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak1U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak1F.Text = 0
                                    tbA79a1.Text = Nak_Red.Item("Sifra")
                                    tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                    tb62na.Text = bNazivNaknadeArr(0)
                                ElseIf tmp_red = 2 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak2U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak2F.Text = 0
                                    tbA79a2.Text = Nak_Red.Item("Sifra")
                                    tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nb.Text = bNazivNaknadeArr(1)
                                ElseIf tmp_red = 3 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak3U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak3F.Text = 0
                                    tbA79a3.Text = Nak_Red.Item("Sifra")
                                    tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nc.Text = bNazivNaknadeArr(2)
                                ElseIf tmp_red = 4 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak4U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bKursZaPrikazNaknada * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak4F.Text = 0
                                    tbA79a4.Text = Nak_Red.Item("Sifra")
                                    tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nd.Text = bNazivNaknadeArr(3)
                                End If
                            End If
                            tmp_red = tmp_red + 1
                        End If
                    Next
                End If

                '--- pdv 18%

                bNadjiPDVKoef(mDatumKalk, bPDVKoef, bPDVKoefString)


                Dim bPDV As Decimal = 0
                If Me.cbPDV.Checked = True Then
                    bPDV = bPDVKoef
                Else
                    bPDV = 0
                End If

                '''If Me.cbPDV.Checked = True Then

                '''    tmp_pdv_f = (CType(tbPrevF.Text, Decimal) + CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)) * PDVKoef
                '''    tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")

                '''    If CType(Me.tbPdvIznosF.Text, Decimal) > 0 Then
                '''        Me.tbPDVF.Text = "62.1"
                '''        Me.tbPDV.Text = "PDV 18%"
                '''    Else
                '''        Me.tbPDVF.Text = ""
                '''    End If

                '''    tmp_pdv_u = (CType(tbPrevU.Text, Decimal) + CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)) * PDVKoef
                '''    tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")

                '''    If CType(Me.tbPdvIznosU.Text, Decimal) > 0 Then
                '''        Me.tbPDVU.Text = "62.0"
                '''        Me.tbPDV.Text = "PDV 18%"
                '''    Else
                '''        Me.tbPDVU.Text = ""
                '''    End If
                '''    If Me.cbPDV.Checked = False Then
                '''        Me.tbPDV.Text = ""
                '''    End If

                '''    tmp_suma_f = CType(tbPrevF.Text, Decimal) + _
                '''                      CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal) + _
                '''                      CType(Me.tbPdvIznosF.Text, Decimal)
                '''    tbSumaF.Text = Format(tmp_suma_f, "###,###,##0.00")
                '''    tmp_suma_u = CType(tbPrevU.Text, Decimal) + _
                '''                      CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + _
                '''                      CType(Me.tbPdvIznosU.Text, Decimal)
                '''    tbSumaU.Text = Format(tmp_suma_u, "###,###,##0.00")


                '''    bSumaNaknadaLevo = CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)
                '''    bSumaNaknadaDesno = CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)

                '''Else

                '''End If

                If Not (bIzTBPrevoznina = True And bTarifa72 = 91) Then
                    tmp_pdv_f = (CType(tbPrevF.Text, Decimal) + CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)) * bPDV
                    If (mVrstaObracuna = "CO") And (bVrstaSaobracaja <> 0) Then         '0206
                        bZaokruziNaDeseteNavise(tmp_pdv_f)
                    End If
                    tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")
                End If

                If Not (mSifraIzjave = "0") And (bTarifa72 = 91) Then
                    tmp_pdv_f = bPrevoznina91ZaPDV * bPDV
                    tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")
                End If

                If CType(Me.tbPdvIznosF.Text, Decimal) > 0 Then
                    Me.tbPDVF.Text = "62.1"
                    Me.tbPDV.Text = "PDV " + bPDVKoefString
                Else
                    Me.tbPDVF.Text = ""
                End If

                If (tbR50.Text = Nothing) Or (tbR50.Text = "") Then
                    tbR50.Text = 0
                End If
                If Not (bIzTBPrevoznina = True And bTarifa72 = 91) Then
                    tmp_pdv_u = (CType(tbPrevU.Text, Decimal) + CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + CType(tbR50.Text, Decimal)) * bPDV
                    If (mVrstaObracuna = "CO") And (bVrstaSaobracaja <> 0) Then
                        bZaokruziNaDeseteNavise(tmp_pdv_u)
                    End If
                    tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")
                End If

                If (mSifraIzjave = "0") And (bTarifa72 = 91) Then
                    'tmp_pdv_u = bPrevoznina91ZaPDV * bPDV
                    tmp_pdv_u = (bPrevoznina91ZaPDV + CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + CType(tbR50.Text, Decimal)) * bPDV
                    tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")

                End If

                If CType(Me.tbPdvIznosU.Text, Decimal) > 0 Then
                    Me.tbPDVU.Text = "62.2"
                    Me.tbPDV.Text = "PDV " + bPDVKoefString
                Else
                    Me.tbPDVU.Text = ""
                End If
                If Me.cbPDV.Checked = False Then
                    Me.tbPDV.Text = ""
                End If


                Dim FPDV As Decimal = CType(Me.tbPdvIznosF.Text, Decimal)
                Dim UPDV As Decimal = CType(Me.tbPdvIznosU.Text, Decimal)



                ' ***** stavljeno pod komentar zbog uracunavanja nepokrivene mase 12.09.2012
                If bTarifa72 = 91 Then                ' P9
                    If Not (bIzTBPrevoznina = True) Then
                        'tbPrevF.Text = 0   *****
                        'tbPrevU.Text = 0   *****
                    End If
                    bIznoseNaknadaUTLNaNulu()
                    'FPDV = 0               *****
                    'UPDV = 0               *****    
                End If
                ' stavljeno pod komentar zbog uracunavanja nepokrivene mase 12.09.2012


                If bTarifa72 = 99 Then                ' besplatan prevoz, sve nula
                    tbPrevF.Text = 0
                    tbPrevU.Text = 0
                    bIznoseNaknadaUTLNaNulu()
                    bIznosePDVUTLNaNulu()
                    FPDV = 0
                    UPDV = 0
                End If

                If (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then
                    bCoPDV = FPDV + UPDV
                Else
                    bCoPDV = 0
                End If


                tmp_suma_f = CType(tbPrevF.Text, Decimal) + _
                                  CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal) + _
                                  FPDV
                If bTarifa72 = 91 Then
                    tmp_suma_f = 0
                End If
                tbSumaF.Text = Format(tmp_suma_f, "###,###,##0.00")
                tmp_suma_u = CType(tbPrevU.Text, Decimal) + _
                                  CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + CType(tbR50.Text, Decimal) + _
                                  UPDV

                If bTarifa72 = 91 Then
                    tmp_suma_u = CType(tbPrevU.Text, Decimal)
                    'Else
                    '    tmp_suma_u = 0
                End If

                tbSumaU.Text = Format(tmp_suma_u, "###,###,##0.00")


                bSumaNaknadaLevo = CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)
                bSumaNaknadaDesno = CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)






                bSumaLevo = tmp_suma_f
                bSumaDesno = tmp_suma_u

            End If
            '============= end prikaz naknada


            '============= rekalkulacija razlika
            Dim mBlagajna As Decimal = CDec(FR_Stanica.Text)
            FR_Stanica.Text = Format(mBlagajna, "###,###,##0.00")

            Dim mRazlika As Decimal = CDec(FR_Stanica.Text)
            Dim mSumaDinari As Decimal = CDec(tbSumaF.Text)
            mRazlika = mBlagajna - mSumaDinari
            If bTarifa72 = 91 Then
                mRazlika = 0
            End If
            bRazlikaFr = mRazlika
            If (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then      '0206
                mRazlika = 0
            End If
            FR_Razlika.Text = Format(mRazlika, "###,###,##0.00")
            lblFrankoRazlika.Text = FR_Razlika.Text

            Dim mBlagajna2 As Decimal = CDec(UP_Stanica.Text)
            UP_Stanica.Text = Format(mBlagajna2, "###,###,##0.00")

            Dim mRazlika2 As Decimal = CDec(UP_Stanica.Text)
            Dim mSumaDinari2 As Decimal = CDec(tbSumaU.Text)
            mRazlika2 = mBlagajna2 - mSumaDinari2
            If bTarifa72 = 91 Then
                mRazlika2 = 0
            End If
            bRazlikaUp = mRazlika2
            If (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then      '0206
                mRazlika2 = 0
            End If
            UP_Razlika.Text = Format(mRazlika2, "###,###,##0.00")
            lblUpucenoRazlika.Text = UP_Razlika.Text

            If (bRazlikaFr <= -250) Or (bRazlikaUp <= 250) Then
                Me.Button6.Focus()
            Else
                Me.btnUpis.Focus()
            End If

            '============= rekalkulacija razlika

        Else
            'If cbR4D.Checked = True Then            ' dencane
            '    'bNadjiPrevozninuGlavni()
            'Else
            '    MsgBox("Niste uneli podatke o kolima!")
            'End If

        End If

    End Sub
    Private Sub bOsveziIznoseLevoDesnoBezRacunanja()

        Dim strRetVal As String = ""
        Dim bVrstaKursa As String = ""

        If mBrojUg = "200379" Or (Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786") Then         ' 25.07.2016 za sada; treba ukljuciti da li su cene u RSD ili EUR
            bVrstaKursa = "3"
        Else
            bVrstaKursa = "1"
        End If
        '28.02.2013
        ''''''''''If bValuta = "17" Then
        ''''''''''    NadjiKurs("17", bVrstaKursa, mOtpDatum, bKursOt, strRetVal)
        ''''''''''    NadjiKurs("17", bVrstaKursa, mPrDatum, bKursPr, strRetVal)
        ''''''''''    'mOutKurs = bKursPr                                  ' za sada; dovesti u vezu sa izjavom o placanju
        ''''''''''Else
        ''''''''''    bKursOt = 1
        ''''''''''    bKursPr = 1
        ''''''''''    'mOutKurs = 1
        ''''''''''End If

        ' Zbog E
        '
        ' bKursOt = 1
        ' bKursPr = 1
        '
        ' Zbog E


        If (dtKola.Rows.Count > 0 And cbR4K.Checked = True) Or (bTarifa72 = 94) Then           ' kolske ili doracunska karta
            mStanica1 = Me.tbStanicaOtp.Text
            mStanica2 = Me.tbStanicaPr.Text

            UTLNaknadeR44(0) = Microsoft.VisualBasic.Trim(tb20a.Text)
            UTLNaknadeR44(1) = Microsoft.VisualBasic.Trim(tb20b.Text)
            UTLNaknadeR44(2) = Microsoft.VisualBasic.Trim(tb20c.Text)
            UTLNaknadeR44(3) = Microsoft.VisualBasic.Trim(tb20d.Text)

            mSifraIzjave = "0"

            If Me.CheckBox1.Checked = True Then
                mSifraIzjave = "1"
            End If
            If Me.CheckBox2.Checked = True Then
                mSifraIzjave = "2"
            End If
            If Me.CheckBox3.Checked = True Then
                mSifraIzjave = "3"
            End If
            If Me.CheckBox4.Checked = True Then
                mSifraIzjave = "4"
            End If

            '============= prikaz naknada
            If IzborSaobracaja = "1" Then
                ''        bNadjiPrevozninuGlavni()

                '================== konverzija EUR  -> RSD ==========================
                'Dim strRetVal As String = ""
                'Dim mOutKurs As Decimal = 0
                Dim mIznosDin As Decimal = 0


                If bValuta = "17" And Not (_OpenForm = "Empty") Then
                    'Dim bKurs As Decimal
                    If bIzTBPrevoznina = True Then
                        mIznosDin = mPrevoznina
                    Else
                        If mSifraIzjave = "1" Then      ' franko svi troskovi
                            bkurs = bKursOt
                        ElseIf mSifraIzjave = "2" Then  ' franko prevoznina ukljucivo
                            bkurs = bKursOt
                        ElseIf mSifraIzjave = "3" Then  ' franko prevoznina
                            bkurs = bKursOt
                        ElseIf mSifraIzjave = "4" Then  ' franko do iznosa

                        ElseIf mSifraIzjave = "0" Then  ' upuceno sve
                            bkurs = bKursPr
                        End If

                        'If mVrstaObracuna = "CO" Then
                        '    bkurs = 1
                        'End If

                        mIznosDin = bkurs * bbPrevozninaUEvrima
                        bZaokruziNaDeseteNavise(mIznosDin)
                    End If
                    mPrevoznina = mIznosDin
                End If
                '====================================================================
                If mSifraIzjave = "1" Then 'franko svi troskovi
                    'tbPrevF.Text = mPrevoznina
                    tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevU.Text = 0
                    bPrevozninaLevo = mPrevoznina
                    bPrevozninaDesno = 0
                ElseIf mSifraIzjave = "2" Then ' franko prevoznina ukljucivo
                    'tbPrevF.Text = mPrevoznina
                    tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevU.Text = 0
                    bPrevozninaLevo = mPrevoznina
                    bPrevozninaDesno = 0
                ElseIf mSifraIzjave = "3" Then 'franko prevoznina 
                    'tbPrevF.Text = mPrevoznina
                    tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevU.Text = 0
                    bPrevozninaLevo = mPrevoznina
                    bPrevozninaLevo = 0
                ElseIf mSifraIzjave = "4" Then 'franko do iznosa
                Else ' upuceno svi troskovi
                    'tbPrevU.Text = mPrevoznina
                    tbPrevU.Text = Format(mPrevoznina, "###,###,##0.00")
                    tbPrevF.Text = 0
                    bPrevozninaLevo = 0
                    bPrevozninaDesno = mPrevoznina
                End If

                '------------------------------------------------

                If Not (bTarifa72 = 94) Then
                    tbPrevStav1.Text = Format(bVozarinskiStavPoKolima, "###,###,##0.00")
                    tbR54_1.Text = dtNhm.Rows(0).Item(4)
                    tbR42a.Text = dtNhm.Rows(0).Item(1)
                    tbR41Suma.Text = dtNhm.Compute("SUM(Masa)", String.Empty)
                End If


                If Not (bTarifa72 = 94) Then
                    Dim Rz1, Rz2, Rz3 As String
                    Dim M1, M2, M3 As Decimal
                    bNadjiRacunskuMasuPoPosiljciPoRazredima(Rz1, M1, Rz2, M2, Rz3, M3)
                    If M1 > 0 Then
                        tbR54_1.Text = Rz1
                        tbR57_1.Text = Format(M1, "###,###,##0.00")
                    End If
                    If M2 > 0 Then
                        tbR54_2.Text = Rz2
                        tbR57_2.Text = Format(M2, "###,###,##0.00")
                    End If
                    If M3 > 0 Then
                        tbR54_3.Text = Rz3
                        tbR57_3.Text = Format(M3, "###,###,##0.00")
                    End If
                End If


                'tbR21_1.Text = dtKola.Rows(0).Item(3)
                'Me.tbIBK.Text = dtKola.Rows(0).Item(0)
                'tbR23_1.Text = dtKola.Rows(0).Item(7)
                'tbR24_1.Text = dtKola.Rows(0).Item(6)
                'tbR25a_1.Text = dtKola.Rows(0).Item(2)
                'tbR25b_1.Text = dtKola.Rows.Count
                'tbR26_1.Text = dtKola.Rows(0).Item(5)

                ' zbog drugacije strukture dtKola:

                If Not (bTarifa72 = 94) Then
                    tbR21_1.Text = dtKola.Rows(0).Item(4)
                    Me.tbIBK.Text = dtKola.Rows(0).Item(0)
                    tbR23_1.Text = dtKola.Rows(0).Item(7)
                    tbR24_1.Text = dtKola.Rows(0).Item(1)
                    tbR25a_1.Text = dtKola.Rows(0).Item(9)
                    tbR25b_1.Text = dtKola.Rows.Count
                    tbR26_1.Text = dtKola.Rows(0).Item(2)


                    Me.tbSumaNeto.Text = tbR24_1.Text
                    Me.tbSumaKola.Text = dtKola.Rows.Count
                    Me.tbSumaOsovina.Text = tbR26_1.Text
                End If


                Dim i_TotalNak As String = ""
                Dim i_Pronasao As Int32 = 0
                Dim tmp_Naknada As Decimal
                'Dim tmp_pdv_f As Decimal
                'Dim tmp_pdv_u As Decimal
                'Dim tmp_suma_f As Decimal
                'Dim tmp_suma_u As Decimal
                Dim Nak_Red As DataRow
                Dim tmp_red As Int16 = 1

                If dtNaknade.Rows.Count > 0 Then
                    Dim bkurs As Decimal = 1
                    For Each Nak_Red In dtNaknade.Rows

                        If Nak_Red.Item("Sifra") <> "62" Then

                            i_TotalNak = Nak_Red.Item("Sifra")
                            i_Pronasao = 0

                            If mSifraIzjave = "1" Then 'franko svi troskovi
                                bkurs = bKursOt
                                If tmp_red = 1 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak1F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak1F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak1U.Text = 0
                                    tbA79a1.Text = Nak_Red.Item("Sifra")
                                    tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                    tb62na.Text = bNazivNaknadeArr(0)
                                ElseIf tmp_red = 2 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak2F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak2F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak2U.Text = 0
                                    tbA79a2.Text = Nak_Red.Item("Sifra")
                                    tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nb.Text = bNazivNaknadeArr(1)
                                ElseIf tmp_red = 3 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak3F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak3F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak3U.Text = 0
                                    tbA79a3.Text = Nak_Red.Item("Sifra")
                                    tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nc.Text = bNazivNaknadeArr(2)
                                ElseIf tmp_red = 4 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak4F.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak4F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak4U.Text = 0
                                    tbA79a4.Text = Nak_Red.Item("Sifra")
                                    tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nd.Text = bNazivNaknadeArr(3)
                                End If

                            ElseIf mSifraIzjave = "2" Then ' franko prevoznina ukljucivo


                                For aa As Int16 = 0 To 3
                                    If UTLNaknadeR44(aa) = i_TotalNak Then
                                        i_Pronasao = 1
                                        Exit For
                                    End If
                                Next

                                If i_Pronasao = 1 Then
                                    bkurs = bKursOt
                                    If tmp_red = 1 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak1F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bkurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak1F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak1U.Text = 0
                                        tbA79a1.Text = Nak_Red.Item("Sifra")
                                        tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                        tb62na.Text = bNazivNaknadeArr(0)
                                    ElseIf tmp_red = 2 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak2F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bkurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak2F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak2U.Text = 0
                                        tbA79a2.Text = Nak_Red.Item("Sifra")
                                        tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nb.Text = bNazivNaknadeArr(1)
                                    ElseIf tmp_red = 3 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak3F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bkurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak3F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak3U.Text = 0
                                        tbA79a3.Text = Nak_Red.Item("Sifra")
                                        tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nc.Text = bNazivNaknadeArr(2)
                                    ElseIf tmp_red = 4 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak4F.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bkurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak4F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak4U.Text = 0
                                        tbA79a4.Text = Nak_Red.Item("Sifra")
                                        tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nd.Text = bNazivNaknadeArr(3)
                                    End If
                                Else
                                    bkurs = bKursPr
                                    If tmp_red = 1 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak1U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bkurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak1F.Text = 0
                                        tbA79a1.Text = Nak_Red.Item("Sifra")
                                        tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                        tb62na.Text = bNazivNaknadeArr(0)
                                    ElseIf tmp_red = 2 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak2U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bkurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak2F.Text = 0
                                        tbA79a2.Text = Nak_Red.Item("Sifra")
                                        tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nb.Text = bNazivNaknadeArr(1)
                                    ElseIf tmp_red = 3 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak3U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bkurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak3F.Text = 0
                                        tbA79a3.Text = Nak_Red.Item("Sifra")
                                        tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nc.Text = bNazivNaknadeArr(2)
                                    ElseIf tmp_red = 4 Then
                                        tmp_Naknada = Nak_Red.Item("Iznos")
                                        'tbNak4U.Text = Nak_Red.Item("Iznos")
                                        If Nak_Red.Item("Valuta") = "17" Then
                                            tmp_Naknada = bkurs * tmp_Naknada
                                            bZaokruziNaDeseteNavise(tmp_Naknada)
                                        End If
                                        tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                        tbNak4F.Text = 0
                                        tbA79a4.Text = Nak_Red.Item("Sifra")
                                        tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                        tb62nd.Text = bNazivNaknadeArr(3)
                                    End If
                                End If

                            ElseIf mSifraIzjave = "3" Then 'franko prevoznina 

                                bkurs = bKursPr
                                If tmp_red = 1 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak1U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak1F.Text = 0
                                    tbA79a1.Text = Nak_Red.Item("Sifra")
                                    tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                    tb62na.Text = bNazivNaknadeArr(0)
                                ElseIf tmp_red = 2 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak2U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak2F.Text = 0
                                    tbA79a2.Text = Nak_Red.Item("Sifra")
                                    tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nb.Text = bNazivNaknadeArr(1)
                                ElseIf tmp_red = 3 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak3U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak3F.Text = 0
                                    tbA79a3.Text = Nak_Red.Item("Sifra")
                                    tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nc.Text = bNazivNaknadeArr(2)
                                ElseIf tmp_red = 4 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak4U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak4F.Text = 0
                                    tbA79a4.Text = Nak_Red.Item("Sifra")
                                    tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nd.Text = bNazivNaknadeArr(3)
                                End If
                            ElseIf mSifraIzjave = "4" Then ' franko do iznosa

                            Else ' upuceno svi troskovi
                                bkurs = bKursPr
                                If tmp_red = 1 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak1U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak1F.Text = 0
                                    tbA79a1.Text = Nak_Red.Item("Sifra")
                                    tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                                    tb62na.Text = bNazivNaknadeArr(0)
                                ElseIf tmp_red = 2 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak2U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak2F.Text = 0
                                    tbA79a2.Text = Nak_Red.Item("Sifra")
                                    tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nb.Text = bNazivNaknadeArr(1)
                                ElseIf tmp_red = 3 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak3U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak3F.Text = 0
                                    tbA79a3.Text = Nak_Red.Item("Sifra")
                                    tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nc.Text = bNazivNaknadeArr(2)
                                ElseIf tmp_red = 4 Then
                                    tmp_Naknada = Nak_Red.Item("Iznos")
                                    'tbNak4U.Text = Nak_Red.Item("Iznos")
                                    If Nak_Red.Item("Valuta") = "17" Then
                                        tmp_Naknada = bkurs * tmp_Naknada
                                        bZaokruziNaDeseteNavise(tmp_Naknada)
                                    End If
                                    tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                    tbNak4F.Text = 0
                                    tbA79a4.Text = Nak_Red.Item("Sifra")
                                    tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                                    tb62nd.Text = bNazivNaknadeArr(3)
                                End If
                            End If
                            tmp_red = tmp_red + 1
                        End If
                    Next
                End If

                '--- pdv 18%
                bNadjiPDVKoef(mDatumKalk, bPDVKoef, bPDVKoefString)

                Dim bPDV As Decimal = 0
                If Me.cbPDV.Checked = True Then
                    bPDV = bPDVKoef
                Else
                    bPDV = 0
                End If

                '''If Me.cbPDV.Checked = True Then

                '''    tmp_pdv_f = (CType(tbPrevF.Text, Decimal) + CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)) * PDVKoef
                '''    tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")

                '''    If CType(Me.tbPdvIznosF.Text, Decimal) > 0 Then
                '''        Me.tbPDVF.Text = "62.1"
                '''        Me.tbPDV.Text = "PDV 18%"
                '''    Else
                '''        Me.tbPDVF.Text = ""
                '''    End If

                '''    tmp_pdv_u = (CType(tbPrevU.Text, Decimal) + CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)) * PDVKoef
                '''    tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")

                '''    If CType(Me.tbPdvIznosU.Text, Decimal) > 0 Then
                '''        Me.tbPDVU.Text = "62.0"
                '''        Me.tbPDV.Text = "PDV 18%"
                '''    Else
                '''        Me.tbPDVU.Text = ""
                '''    End If
                '''    If Me.cbPDV.Checked = False Then
                '''        Me.tbPDV.Text = ""
                '''    End If

                '''    tmp_suma_f = CType(tbPrevF.Text, Decimal) + _
                '''                      CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal) + _
                '''                      CType(Me.tbPdvIznosF.Text, Decimal)
                '''    tbSumaF.Text = Format(tmp_suma_f, "###,###,##0.00")
                '''    tmp_suma_u = CType(tbPrevU.Text, Decimal) + _
                '''                      CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + _
                '''                      CType(Me.tbPdvIznosU.Text, Decimal)
                '''    tbSumaU.Text = Format(tmp_suma_u, "###,###,##0.00")


                '''    bSumaNaknadaLevo = CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)
                '''    bSumaNaknadaDesno = CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)

                '''Else

                '''End If

                'If Not (bIzTBPrevoznina = True And bTarifa72 = 91) Then
                '    tmp_pdv_f = (CType(tbPrevF.Text, Decimal) + CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)) * bPDV
                '    tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")
                'End If

                tbPdvIznosF.Text = Format(bPDV1IzSloga, "###,###,##0.00")

                If CType(Me.tbPdvIznosF.Text, Decimal) > 0 Then
                    Me.tbPDVF.Text = "62.1"
                    Me.tbPDV.Text = bPDVKoefString
                Else
                    Me.tbPDVF.Text = ""
                End If

                If (tbR50.Text = Nothing) Or (tbR50.Text = "") Then
                    tbR50.Text = 0
                End If

                'If Not (bIzTBPrevoznina = True And bTarifa72 = 91) Then
                '    tmp_pdv_u = (CType(tbPrevU.Text, Decimal) + CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + CType(tbR50.Text, Decimal)) * bPDV
                '    tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")
                'End If

                tbPdvIznosU.Text = Format(bPDV2IzSloga, "###,###,##0.00")

                If CType(Me.tbPdvIznosU.Text, Decimal) > 0 Then
                    Me.tbPDVU.Text = "62.2"
                    Me.tbPDV.Text = "PDV " + bPDVKoefString
                Else
                    Me.tbPDVU.Text = ""
                End If
                If Me.cbPDV.Checked = False Then
                    Me.tbPDV.Text = ""
                End If


                Dim FPDV As Decimal = CType(Me.tbPdvIznosF.Text, Decimal)
                Dim UPDV As Decimal = CType(Me.tbPdvIznosU.Text, Decimal)

                'If bTarifa72 = 91 Then                ' P9
                '    If Not (bIzTBPrevoznina = True) Then
                '        tbPrevF.Text = 0
                '        tbPrevU.Text = 0
                '    End If
                '    bIznoseNaknadaUTLNaNulu()
                '    FPDV = 0
                '    UPDV = 0
                'End If


                'If bTarifa72 = 99 Then                ' besplatan prevoz, sve nula
                '    tbPrevF.Text = 0
                '    tbPrevU.Text = 0
                '    bIznoseNaknadaUTLNaNulu()
                '    bIznosePDVUTLNaNulu()
                '    FPDV = 0
                '    UPDV = 0
                'End If


                'tmp_suma_f = CType(tbPrevF.Text, Decimal) + _
                '                  CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal) + _
                '                  FPDV


                'tbSumaF.Text = Format(tmp_suma_f, "###,###,##0.00")

                tbSumaF.Text = Format(bSumaLevo, "###,###,##0.00")
                'tmp_suma_u = CType(tbPrevU.Text, Decimal) + _
                '                  CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + CType(tbR50.Text, Decimal) + _
                '                  UPDV

                'tbSumaU.Text = Format(tmp_suma_u, "###,###,##0.00")
                tbSumaU.Text = Format(bSumaDesno, "###,###,##0.00")


                bSumaNaknadaLevo = CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)
                bSumaNaknadaDesno = CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)



                'bSumaLevo = tmp_suma_f
                'bSumaDesno = tmp_suma_u

            End If
            '============= end prikaz naknada
            FR_Stanica.Text = Format(bBlagFranko, "###,###,##0.00")
            UP_Stanica.Text = Format(bBlagUpuceno, "###,###,##0.00")


            '============= rekalkulacija razlika
            '''''''''Dim mBlagajna As Decimal = CDec(FR_Stanica.Text)
            '''''''''FR_Stanica.Text = Format(mBlagajna, "###,###,##0.00")

            '''''''''Dim mRazlika As Decimal = CDec(FR_Stanica.Text)
            '''''''''Dim mSumaDinari As Decimal = CDec(tbSumaF.Text)
            '''''''''mRazlika = mBlagajna - mSumaDinari
            '''''''''bRazlikaFr = mRazlika
            '''''''''FR_Razlika.Text = Format(mRazlika, "###,###,##0.00")

            '''''''''Dim mBlagajna2 As Decimal = CDec(UP_Stanica.Text)
            '''''''''UP_Stanica.Text = Format(mBlagajna2, "###,###,##0.00")

            '''''''''Dim mRazlika2 As Decimal = CDec(UP_Stanica.Text)
            '''''''''Dim mSumaDinari2 As Decimal = CDec(tbSumaU.Text)
            '''''''''mRazlika2 = mBlagajna2 - mSumaDinari2
            '''''''''bRazlikaUp = mRazlika2
            '''''''''UP_Razlika.Text = Format(mRazlika2, "###,###,##0.00")

            '''''''''If (bRazlikaFr <= -250) Or (bRazlikaUp <= 250) Then
            '''''''''    Me.Button6.Focus()
            '''''''''Else
            '''''''''    Me.btnUpis.Focus()
            '''''''''End If
            '============= rekalkulacija razlika

        Else
            'If cbR4D.Checked = True Then            ' dencane
            '    'bNadjiPrevozninuGlavni()
            'Else
            '    MsgBox("Niste uneli podatke o kolima!")
            'End If

        End If

    End Sub
    Private Sub tbPrevF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbPrevF.Validating
        If tbPrevF.Text = Nothing Then
            tbPrevF.Text = "0"
        End If
        mPrevoznina = CDec(tbPrevF.Text)
        bIzTBPrevoznina = True
        bOsveziIznoseLevoDesno()
    End Sub
    Private Sub tbPrevU_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbPrevU.Validating
        If tbPrevU.Text = Nothing Then
            tbPrevU.Text = "0"
        End If
        mPrevoznina = CDec(tbPrevU.Text)
        bIzTBPrevoznina = True
        bOsveziIznoseLevoDesno()
    End Sub
    Private Sub tbPrevF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrevF.KeyPress
        'Dim ascii As Integer = Asc(e.KeyChar.ToString)
        'If DecimalSeparator = "," Then
        '    If ascii = 46 Then
        '        e.KeyChar = ","
        '    End If
        'ElseIf DecimalSeparator = "." Then
        '    If ascii = 44 Then
        '        e.KeyChar = "."
        '    End If
        'End If

        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub tbPrevU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrevU.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    'Private Sub tbPDVIznosF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPdvIznosF.KeyPress
    '    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    '        e.Handled = True
    '        SendKeys.Send(Chr(9))
    '    End If
    'End Sub
    'Private Sub tbPDVIznosU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPdvIznosU.KeyPress
    '    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    '        e.Handled = True
    '        SendKeys.Send(Chr(9))
    '    End If
    'End Sub
    Public Sub bIznoseNaknadaUTLNaNulu()
        tbNak1F.Text = 0
        tbNak2F.Text = 0
        tbNak3F.Text = 0
        tbNak4F.Text = 0
        tbNak1U.Text = 0
        tbNak2U.Text = 0
        tbNak3U.Text = 0
        tbNak4U.Text = 0
    End Sub
    Public Sub bIznosePDVUTLNaNulu()
        tbPdvIznosF.Text = 0
        tbPdvIznosU.Text = 0
    End Sub

    'Private Sub tbPdvIznosF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbPdvIznosF.Validating        
    '    Dim PDVF, TUGF As Decimal
    '    PDVF = tbPdvIznosF.Text
    '    TUGF = tbTugF.Text
    '    bOsveziIznoseLevoDesno()
    '    tbPdvIznosF.Text = PDVF
    '    tbSumaF.Text = PDVF + TUGF
    'End Sub

    'Private Sub tbPdvIznosU_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbPdvIznosU.Validating
    '    Dim PDVU, TUGU As Decimal
    '    PDVU = tbPdvIznosU.Text
    '    TUGU = tbTugU.Text
    '    bOsveziIznoseLevoDesno()
    '    tbPdvIznosU.Text = PDVU
    '    tbSumaU.Text = PDVU + TUGU
    'End Sub

    Private Sub btnSTV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTV.Click
        m_Tacka = "2"
        If Len(tbStanicaPr.Text) < 5 Then
            ErrorProvider1.SetError(Label18, "Neispravna sifra stanice!")
            Me.tbStanicaPr.SelectAll()
            If bShiftTab Then
                tbStanicaOtp.Focus()
            Else
                tbStanicaPr.Focus()
            End If
        Else
            Dim xNaziv As String = ""
            Dim xKB As String = ""
            Dim xZemlja As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiStanicu("ZsStanice", tbStanicaPr.Text, "", "", mBrojPokusaja, xNaziv, xKB, xZemlja, xPovVrednost)

            If xPovVrednost <> "" Then
                If mBrojPokusaja > 3 Then
                    mBrojPokusaja = 1
                    Label13.Text = "Nepostojeca sifra stanice"
                    mPrStanica = tbStanicaPr.Text
                    Me.tbStanicaPr.BackColor = System.Drawing.Color.Red
                    ErrorProvider1.SetError(Label18, "")
                Else
                    mBrojPokusaja = mBrojPokusaja + 1
                    ErrorProvider1.SetError(Label18, "Nepostojeca stanica!")
                    Me.tbStanicaPr.SelectAll()

                    If bShiftTab Then
                        tbStanicaOtp.Focus()
                    Else
                        tbStanicaPr.Focus()
                    End If

                End If
            Else
                mBrojPokusaja = 1
                Me.tbStanicaPr.BackColor = System.Drawing.Color.White
                Label13.Text = xNaziv
                mPrStanica = tbStanicaPr.Text
                tbR30Sifra.Text = tbStanicaPr.Text
                tbR30Naziv.Text = xNaziv
                tbR33_1.Text = tbR30Sifra.Text

                ErrorProvider1.SetError(Label18, "")
                If m_Tacka = "2" Then
                    Nadzorna()
                End If

            End If
        End If

    End Sub
    Public Sub bOsveziIzBazePriUpd()

        ''Dim   As Boolean = False
        ''DaLiVaziPDV(ImaPDV)

        'If ImaPDV Then
        '    cbPDV.Checked = True
        'Else
        '    cbPDV.Checked = False
        'End If

        'tbStanicaOtp.Text = mOtpStanica
        'tbStanicaPr.Text = Microsoft.VisualBasic.Right(mPrStanica, 5)

        'tbBrojOtp.Text = mOtpBroj
        'tbBrojPr.Text = mPrBroj

        'DatumOtp.Value = mOtpDatum
        'DateTimePicker2.Value = mPrDatum

        'Select Case mSifraIzjave
        '    Case 0
        '        Me.CheckBox1.Checked = False
        '        Me.CheckBox2.Checked = False
        '        Me.CheckBox3.Checked = False
        '        Me.CheckBox4.Checked = False
        '    Case 1
        '        Me.CheckBox1.Checked = True
        '        Me.CheckBox2.Checked = False
        '        Me.CheckBox3.Checked = False
        '        Me.CheckBox4.Checked = False
        '    Case 2
        '        Me.CheckBox1.Checked = False
        '        Me.CheckBox2.Checked = True
        '        Me.CheckBox3.Checked = False
        '        Me.CheckBox4.Checked = False
        '    Case 3
        '        Me.CheckBox1.Checked = False
        '        Me.CheckBox2.Checked = False
        '        Me.CheckBox3.Checked = True
        '        Me.CheckBox4.Checked = False
        '    Case 4
        '        Me.CheckBox1.Checked = False
        '        Me.CheckBox2.Checked = False
        '        Me.CheckBox3.Checked = False
        '        Me.CheckBox4.Checked = True
        'End Select

    End Sub
    Public Sub bPrikazIzSloga()

        ' zvezdica ( * ) u komentaru oznacava da je vec postavljeno


        ' POMOCNA POLJA:
        ' posiljka podleze PDV-u
        ' vrsta saobracaja
        ' tarifa (1-2)   
        ' broj ugovora
        ' nacin prevoza
        ' otpravna stanica
        ' manipulativno mesto (otp.)
        ' broj otpravljanja
        ' datum otpravljanja
        ' uputna stanica
        ' manipulativno mesto (up.)
        ' broj prispeca
        ' datum prispeca
        ' naplaceno na blagajni:
        '   franko
        '   upuceno
        '   razlika franko
        '   razlika upuceno
        '
        '
        '
        '  4 vrsta posiljke
        '  5 nacin prevoza
        '  8 sifra vrste saobracaja
        ' 10 posiljalac
        ' 11 sifra posiljaoca
        ' 12 otpravna stanica sifra
        ' 12 otpravna stanica naziv
        ' 13 nalepnica otpravne stanice
        ' 13.1 sifra otpravne stanice
        ' 13.2 broj otpravljanja
        ' 14 manipulativno mesto sifra
        ' 14 manipulativno mesto naziv
        ' 15 mesto utovara
        ' 16 primalac
        ' 17 sifra primaoca
        ' 21 serija kola        (1-4)
        ' 22 broj kola          (1-4)
        ' 23 granica tovarenja  (1-4)
        ' 24 sopstvena masa     (1-4) + UKUPNO
        ' 25 tip kola           (1-4)
        ' 25 kolicina           (1-4) + UKUPNO
        ' 26 broj osovina       (1-4) + UKUPNO
        ' 30 uputna stanica sifra
        ' 30 uputna stanica naziv
        ' 31 manipulativno mesto sifra
        ' 31 manipulativno mesto naziv
        ' 32 mesto utovara
        ' 33 nalepnica uputne stanice
        ' 33.1 sifra uputne stanice
        ' 33.2 broj prispeca
        ' 35 prevozni put
        ' 36 sifra prevoznog puta
        ' 42 pozicija iz klasifikacije  (1-6)
        ' 43 sifra tarife               (1-6)
        ' 44 izjava o placanju
        ' 47 iznos po izjavi
        ' 50 predujam
        ' 53 tarifski kilometri         (1-2)
        ' 54 tarifski razred            (1-3)
        ' 55 prevozni stav              (1-3)
        ' 56 povlastica                 (1-3)
        ' 57 racunska masa              (1-3)
        ' 60 tarifa
        ' 61 prevoznina                 (F-U, LP1, LP2)
        ' 62,64 naknade
        '       iznosF, sifra, ivicni broj, naziv, IznosU   (1-5)
        ' 63 troskovi u gotovom
        '       iznosF, sifra, ivicni broj, naziv, IznosU
        ' 65 ukupni troskovi (F-U)


        ' Dakle:

        '*posiljka podleze PDV-u
        If ImaPDV Then
            cbPDV.Checked = True
        Else
            cbPDV.Checked = False
        End If

        '*vrsta saobracaja
        'tbR8.Text = bVrstaSaobracaja
        If bVrstaSaobracaja < 7 Then
            ComboBox4.SelectedIndex = bVrstaSaobracaja
        Else
            ComboBox4.SelectedIndex = bVrstaSaobracaja - 1
        End If
        tbR8.Text = bVrstaSaobracaja
        ComboBox4_Validating(Me, Nothing)

        '*tarifa (1-2)   
        '*broj ugovora
        '*nacin prevoza
        If mTarifa = "36" Then
            tbR60.Text = "Spt 36"
            ComboBox1.SelectedIndex = 0
        ElseIf mTarifa = "00" Then
            tbR60.Text = "Ug.kom.pov."
            ComboBox1.SelectedIndex = 1
            tbUgovor.Enabled = True
            tbUgovor.Text = mBrojUg
            ComboBox3.Text = ""
        End If

        '*najava
        If mBrojUg = "525501" Or mBrojUg = "524801" Or mBrojUg = "625501" Or mBrojUg = "624801" Or mBrojUg = "048601" Or mBrojUg = "028601" Then
            tbNajava.Text = mNajava
        End If

        Select Case bTarifa72
            Case 0                              ' pojedinacna posiljka  00
                ComboBox3.SelectedIndex = 0
            Case 49                             ' grupa kola            49
                ComboBox3.SelectedIndex = 1
            Case 46                             ' marsrutni voz         46
                ComboBox3.SelectedIndex = 2
            Case 91                             ' P9 uputnica za besplatan prevoz   91
                ComboBox3.SelectedIndex = 3
            Case 92                             ' SPT49 prevoz za potrebe ZS        92
                ComboBox3.SelectedIndex = 4
            Case 93                             ' NP narocite posiljke              93
                ComboBox3.SelectedIndex = 5
            Case 39                             ' Mesoviti vojni transport - cl.45, t.4     39
                ComboBox3.SelectedIndex = 6
            Case 40                             ' Mesoviti vojni transport - cl.45, t.6     40
                ComboBox3.SelectedIndex = 7
            Case 43                             ' Tov. pribor vlasnistvo kor. prevoza - cl.52, t.9
                ComboBox3.SelectedIndex = 8
            Case 48                             ' poseban voz           48
                ComboBox3.SelectedIndex = 9
            Case 99                             ' besplatan prevoz      99
                ComboBox3.SelectedIndex = 10
            Case 94                             ' doracunska karta      94
                ComboBox3.SelectedIndex = 11
        End Select

        If mBrojUg <> "" Then
            If mVrstaPrevoza = "P" Then
                Me.ComboBox2.SelectedIndex = 0
            ElseIf mVrstaPrevoza = "G" Then
                Me.ComboBox2.SelectedIndex = 1
            ElseIf mVrstaPrevoza = "V" Then
                Me.ComboBox2.SelectedIndex = 2
            End If
            Me.ComboBox3.Text = ""
            Me.ComboBox3.Enabled = False
            Me.ComboBox3.SelectedIndex = -1
        End If
        '*otpravna stanica
        ' manipulativno mesto (otp.)



        tbStanicaOtp.Text = mOtpStanica
        Me.tbStanicaOtp_Validating(Me, Nothing)
        Dim MMExCount As Byte
        MMExCount = cmbManipulativnaMestaEx.Items.Count

        If MMExCount > 0 Then
            For i As Byte = 0 To MMExCount - 1
                If Microsoft.VisualBasic.Left(mManipulativnoMesto1, 5) = Microsoft.VisualBasic.Left(cmbManipulativnaMestaEx.Items(i), 5) Then
                    cmbManipulativnaMestaEx.SelectedIndex = i
                    ExMMIndex = i
                End If
            Next
            cmbManipulativnaMestaEx_Validating(Me, Nothing)
        End If


        '*broj otpravljanja        

        tbBrojOtp.Text = mOtpBroj

        '*datum otpravljanja

        If AkcijaZaPreuzimanje = "Da" Then
            DatumOtp.Value = mOtpDatum
        Else
            DatumOtp.Value = bDatumOtpIzSloga
        End If



        '*uputna stanica
        If Len(mPrStanica) = 7 Then
            tbStanicaPr.Text = Microsoft.VisualBasic.Mid(mPrStanica, 3, 5)
            mPrStanica = tbStanicaPr.Text
        ElseIf Len(mPrStanica) = 5 Then
            tbStanicaPr.Text = mPrStanica
        End If


        mDatumKalk = mOtpDatum

        Me.tbStanicaPr_Validating(Me, Nothing)
        tbStanicaPr.Text = Microsoft.VisualBasic.Right(mPrStanica, 5)

        '*manipulativno mesto (up.)
        Dim MMImCount As Byte
        MMImCount = cmbManipulativnaMestaIm.Items.Count

        If MMImCount > 0 Then
            For j As Byte = 0 To MMImCount - 1
                If Microsoft.VisualBasic.Left(mManipulativnoMesto2, 5) = Microsoft.VisualBasic.Left(cmbManipulativnaMestaIm.Items(j), 5) Then
                    cmbManipulativnaMestaIm.SelectedIndex = j
                    ImMMIndex = j
                End If
            Next
            cmbManipulativnaMestaIm_Validating(Me, Nothing)
        End If


        '*broj prispeca

        tbBrojPr.Text = mPrBroj
        '*datum prispeca
        DateTimePicker2.Value = mPrDatum

        ' naplaceno na blagajni:

        If (mVrstaObracuna = "CO" Or mVrstaObracuna = "CD") Then
            GroupBox6.Visible = False
            GroupBox6.Enabled = False
        Else
            GroupBox6.Visible = True
            GroupBox6.Enabled = True
        End If

        '   franko
        FR_Stanica.Text = bBlagFranko

        '   upuceno
        UP_Stanica.Text = bBlagUpuceno

        '   razlika franko
        FR_Razlika.Text = bRazlikaFr
        lblFrankoRazlika.Text = FR_Razlika.Text


        '   razlika upuceno
        UP_Razlika.Text = bRazlikaUp
        lblUpucenoRazlika.Text = UP_Razlika.Text
        '
        '
        '
        '  4 vrsta posiljke
        '  5 nacin prevoza
        '  8 sifra vrste saobracaja
        ' 10 posiljalac
        ' 11 sifra posiljaoca
        tbR11.Text = mPosiljalac
        tbR11_Validating(Me, Nothing)
        ' 12 otpravna stanica sifra
        ' 12 otpravna stanica naziv
        ' 13 nalepnica otpravne stanice
        ' 13.1 sifra otpravne stanice
        ' 13.2 broj otpravljanja
        ' 14 manipulativno mesto sifra
        ' 14 manipulativno mesto naziv
        ' 15 mesto utovara
        ' 16 primalac
        ' 17 sifra primaoca
        tbR17.Text = mPrimalac
        tbR17_Validating(Me, Nothing)
        ' 21 serija kola        (1-4)
        ' 22 broj kola          (1-4)
        ' 23 granica tovarenja  (1-4)
        ' 24 sopstvena masa     (1-4) + UKUPNO
        ' 25 tip kola           (1-4)
        ' 25 kolicina           (1-4) + UKUPNO
        ' 26 broj osovina       (1-4) + UKUPNO
        ' 30 uputna stanica sifra
        ' 30 uputna stanica naziv
        ' 31 manipulativno mesto sifra
        ' 31 manipulativno mesto naziv
        ' 32 mesto utovara
        ' 33 nalepnica uputne stanice
        ' 33.1 sifra uputne stanice
        ' 33.2 broj prispeca
        ' 35 prevozni put   
        '       prebacen na kraj procedure

        ' 36 sifra prevoznog puta
        ' 42 pozicija iz klasifikacije  (1-6)
        ' 43 sifra tarife               (1-6)
        ' 44 izjava o placanju

        Select Case mSifraIzjave
            Case 0
                Me.CheckBox1.Checked = False
                Me.CheckBox2.Checked = False
                Me.CheckBox3.Checked = False
                Me.CheckBox4.Checked = False
            Case 1
                Me.CheckBox1.Checked = True
                Me.CheckBox2.Checked = False
                Me.CheckBox3.Checked = False
                Me.CheckBox4.Checked = False
            Case 2
                Me.CheckBox1.Checked = False
                Me.CheckBox2.Checked = True
                Me.CheckBox3.Checked = False
                Me.CheckBox4.Checked = False
            Case 3
                Me.CheckBox1.Checked = False
                Me.CheckBox2.Checked = False
                Me.CheckBox3.Checked = True
                Me.CheckBox4.Checked = False
            Case 4
                Me.CheckBox1.Checked = False
                Me.CheckBox2.Checked = False
                Me.CheckBox3.Checked = False
                Me.CheckBox4.Checked = True
        End Select

        ' franko naknade uljucivo

        tb20a.Text = ""
        tb20b.Text = ""
        tb20c.Text = ""
        tb20d.Text = ""

        If mSifraIzjave = 2 Then
            upis_mFrNaknade = Microsoft.VisualBasic.RTrim(upis_mFrNaknade)
            Dim Duzina As Int16 = Microsoft.VisualBasic.Len(upis_mFrNaknade)
            If Duzina = 2 Then
                tb20a.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 1, 2)
            ElseIf Duzina = 4 Then
                tb20a.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 1, 2)
                tb20b.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 3, 2)
            ElseIf Duzina = 6 Then
                tb20a.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 1, 2)
                tb20b.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 3, 2)
                tb20c.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 5, 2)
            ElseIf Duzina = 8 Then
                tb20a.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 1, 2)
                tb20b.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 3, 2)
                tb20c.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 5, 2)
                tb20d.Text = Microsoft.VisualBasic.Mid(upis_mFrNaknade, 7, 2)
            End If
        End If
        bOsveziNizNazivaNaknada()

        bOsveziIznoseLevoDesnoBezRacunanja()

        ' 47 iznos po izjavi
        ' 50 predujam
        If Not (bTarifa72 = 94) Then
            tbR50.Text = bbPredujam
            tbR51.Text = bbPredujam
            gbDorKarta.Visible = False
        Else                                    ' doracunska karta
            gbDorKarta.Visible = True
            bDKIznos = bbPredujam
            tbDKIznos.Text = bDKIznos
            bbPredujam = 0
        End If


        ' 53 tarifski kilometri         (1-2)
        tbR53.Text = updbTkm
        ' 54 tarifski razred            (1-3)
        ' 55 prevozni stav              (1-3)
        ' 56 povlastica                 (1-3)
        ' 57 racunska masa              (1-3)
        '*60 tarifa
        ' 61 prevoznina                 (F-U, LP1, LP2)
        ' 62,64 naknade
        '       iznosF, sifra, ivicni broj, naziv, IznosU   (1-5)
        ' 63 troskovi u gotovom
        '       iznosF, sifra, ivicni broj, naziv, IznosU
        ' 65 ukupni troskovi (F-U)

        Select Case bPrevozniPutZS
            Case 1
                cbZsPrevozniPut.SelectedIndex = 0
            Case 2
                cbZsPrevozniPut.SelectedIndex = 1
            Case 3
                cbZsPrevozniPut.SelectedIndex = 2
            Case 4
                cbZsPrevozniPut.SelectedIndex = 3
        End Select


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_Tacka = "1"

        If Len(tbStanicaOtp.Text) < 5 Then
            ErrorProvider1.SetError(Label10, "Neispravna sifra stanice!")
            Me.tbStanicaOtp.SelectAll()
            Me.tbStanicaOtp.Focus()
        Else
            Dim xNaziv As String = ""
            Dim xKB As String = ""
            Dim xZemlja As String = ""
            Dim xPovVrednost As String = ""

            Util.sNadjiStanicu("ZsStanice", tbStanicaOtp.Text, "", "", mBrojPokusaja, xNaziv, xKB, xZemlja, xPovVrednost)

            If xPovVrednost <> "" Then
                If mBrojPokusaja > 3 Then
                    mBrojPokusaja = 1
                    Label12.Text = "Nepostojeca sifra stanice"
                    mOtpStanica = tbStanicaOtp.Text
                    Me.tbStanicaOtp.BackColor = System.Drawing.Color.Red
                    ErrorProvider1.SetError(Label10, "")
                Else
                    mBrojPokusaja = mBrojPokusaja + 1
                    ErrorProvider1.SetError(Label10, "Nepostojeca stanica!")
                    Me.tbStanicaOtp.SelectAll()
                    tbStanicaOtp.Focus()
                End If
            Else
                mBrojPokusaja = 1
                Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
                Label12.Text = xNaziv
                tbR12Sifra.Text = tbStanicaOtp.Text
                tbR13_1.Text = tbStanicaOtp.Text
                tbR12Naziv.Text = xNaziv
                mOtpStanica = tbStanicaOtp.Text
                ErrorProvider1.SetError(tbStanicaOtp, "")

                Nadzorna()

            End If
            ErrorProvider1.SetError(Label10, "")
        End If
    End Sub

    Private Sub FR_Stanica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FR_Stanica.Validating
        bBlagFranko = FR_Stanica.Text
    End Sub

    Private Sub UP_Stanica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UP_Stanica.Validating
        bBlagUpuceno = UP_Stanica.Text
    End Sub

    Friend Sub NadjiRacunskiMesecIGodinu()
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
        '------------------------------------------

    End Sub

    Private Sub cbPDV_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbPDV.Validating
        Me.ComboBox4.Focus()
    End Sub
    Private Sub bNadjiPDVKoef(ByVal inDatum As Date, ByRef outPDVKoef As Decimal, ByRef outPDVString As String)

        If (inDatum < #10/1/2012#) Then
            outPDVKoef = 0.18
            outPDVString = "18 %"
        Else
            outPDVKoef = 0.2
            outPDVString = "20 %"

        End If

    End Sub

    Private Sub tbR53_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbR53.Validating

        If (bPrevozniPutZS = 2) Or (bPrevozniPutZS = 4) Then
            If Not (_OpenForm = "VPP") Then
                If (bPrevozniPutZS = 2) Then
                    bTkm = tbR53.Text
                ElseIf (bPrevozniPutZS = 4) Then
                    bTkm1 = tbR53.Text
                    bTkm2 = tbR53_LP2.Text
                End If
                bTkm = tbR53.Text
            Else
                tbR53.Text = bTkm
                _OpenForm = "Empty"
            End If
            'btnKalk_Click(Me, Nothing)
        Else
            If (bPrevozniPutZS = 1) Then
                tbR53.Text = bTkm
            ElseIf (bPrevozniPutZS = 3) Then
                tbR53.Text = bTkm1
                tbR53_LP2.Text = bTkm2
            End If
            tbR53.Text = bTkm1
        End If
        btnKalk_Click(Me, Nothing)
    End Sub

    Private Sub tbR53_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbR53.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUgovor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.GotFocus
        Me.tbUgovor.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbUgovor.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbUgovor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.LostFocus
        Me.tbUgovor.BackColor = System.Drawing.Color.White
        Me.tbUgovor.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbStanicaOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaOtp.GotFocus
        Me.tbStanicaOtp.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbStanicaOtp.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbStanicaOtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaOtp.LostFocus
        Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
        Me.tbStanicaOtp.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbStanicaPr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.GotFocus
        Me.tbStanicaPr.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbStanicaPr.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbStanicaPr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.LostFocus
        Me.tbStanicaPr.BackColor = System.Drawing.Color.White
        Me.tbStanicaPr.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbBrojOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.GotFocus
        Me.tbBrojOtp.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbBrojOtp.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbBrojOtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.LostFocus
        Me.tbBrojOtp.BackColor = System.Drawing.Color.White
        Me.tbBrojOtp.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbBrojPr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojPr.GotFocus
        Me.tbBrojPr.BackColor = System.Drawing.Color.RoyalBlue
        Me.tbBrojPr.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbBrojPr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojPr.LostFocus
        Me.tbBrojPr.BackColor = System.Drawing.Color.White
        Me.tbBrojPr.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub cbPDV_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPDV.GotFocus
        'Me.cbPDV.BackColor = System.Drawing.Color.RoyalBlue
        'Me.cbPDV.ForeColor = System.Drawing.Color.White
        'Me.cbPDV.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub cbPDV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPDV.LostFocus
        Me.cbPDV.BackColor = System.Drawing.Color.Transparent
        Me.cbPDV.ForeColor = System.Drawing.Color.Black
    End Sub
    Private Sub btnUnosRobe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnosRobe.GotFocus
        'Me.btnUnosRobe.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.btnUnosRobe.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        'Me.btnUnosRobe.BackColor = System.Drawing.Color.RoyalBlue
        'Me.btnUnosRobe.ForeColor = System.Drawing.Color.White
    End Sub
    Private Sub btnUnosRobe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnosRobe.LostFocus
        Me.btnUnosRobe.BackColor = System.Drawing.Color.Transparent
        Me.btnUnosRobe.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub CheckBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.GotFocus
        Me.CheckBox1.BackColor = System.Drawing.Color.RoyalBlue
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub CheckBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.LostFocus
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
    End Sub
    Private Sub CheckBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.GotFocus
        Me.CheckBox2.BackColor = System.Drawing.Color.RoyalBlue
        Me.CheckBox2.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub CheckBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.LostFocus
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.ForeColor = System.Drawing.Color.Black
    End Sub
    Private Sub CheckBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.GotFocus
        Me.CheckBox3.BackColor = System.Drawing.Color.RoyalBlue
        Me.CheckBox3.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub CheckBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.LostFocus
        Me.CheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox3.ForeColor = System.Drawing.Color.Black
    End Sub
    Private Sub CheckBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.GotFocus
        Me.CheckBox4.BackColor = System.Drawing.Color.RoyalBlue
        Me.CheckBox4.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub CheckBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.LostFocus
        Me.CheckBox4.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox4.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub Button18_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button18.GotFocus
        'Me.Button18.BackColor = System.Drawing.Color.RoyalBlue
        'Me.Button18.ForeColor = System.Drawing.Color.White
        Me.Button18.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Private Sub Button18_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button18.LostFocus
        Me.Button18.BackColor = System.Drawing.Color.Transparent
        Me.Button18.ForeColor = System.Drawing.Color.Black
    End Sub
    Private Sub Button6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.GotFocus
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        'Me.Button6.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub Button6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.LostFocus
        Me.Button6.BackColor = System.Drawing.Color.Transparent
        Me.Button6.ForeColor = System.Drawing.Color.Black
    End Sub
    Private Sub btnUpis_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.GotFocus
        Me.btnUpis.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        'Me.btnUpis.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub btnUpis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.LostFocus
        Me.btnUpis.BackColor = System.Drawing.Color.Transparent
        Me.btnUpis.ForeColor = System.Drawing.Color.Black
    End Sub


    Private Sub cbZsPrevozniPut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbZsPrevozniPut.SelectedIndexChanged

        Select Case Me.cbZsPrevozniPut.SelectedIndex
            Case 0
                bPrevozniPutZS = 1
                tbR53.ReadOnly = True
                tbR53_LP2.ReadOnly = True
                tbStanicaLom.Text = ""
                Daljinar()
                tbR53.Text = bTkm
                If Not (_OpenForm = "Empty") Then
                    btnKalk_Click(Me, Nothing)
                End If
                Button5.Enabled = False
            Case 1
                bPrevozniPutZS = 2
                tbR53.ReadOnly = False
                tbR53_LP2.ReadOnly = True
                tbStanicaLom.Text = ""
                Button5.Enabled = True
            Case 2
                bPrevozniPutZS = 3
                tbR53.ReadOnly = True
                tbR53_LP2.ReadOnly = True
                tbStanicaLom.Focus()
            Case 3
                bPrevozniPutZS = 4
                'tbR53.ReadOnly = False
                'tbR53_LP2.ReadOnly = False
                Button5.Enabled = True
                tbStanicaLom.Focus()
        End Select

    End Sub


    Private Sub tbStanicaLom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaLom.Validating

        bStanicaVia = tbStanicaLom.Text

        If Not (bStanicaVia = "") Then
            DaljinarLom(bTkm1, bTkm2, bSkm1, bSkm2)
            bTkm = bTkm1 + bTkm2
            bSkm = bSkm1 + bSkm2
        End If
        btnKalk_Click(Me, Nothing)
        btnKalk.Focus()

    End Sub

    Private Sub DaljinarLom(ByRef outTkm1 As Integer, ByRef outTkm2 As Integer, ByRef outSkm1 As Integer, ByRef outSkm2 As Integer)
        Dim sql_text As String

        Dim St1, St2, StLom As String 'string 5

        outTkm1 = 0
        outTkm2 = 0
        outSkm1 = 0
        outSkm2 = 0

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        If cmbManipulativnaMestaEx.Text = "" Then
            St1 = mStanica1
        Else
            St1 = Microsoft.VisualBasic.Left(Me.cmbManipulativnaMestaEx.Text, 5)
        End If

        If cmbManipulativnaMestaIm.Text = "" Then
            St2 = mStanica2
        Else
            St2 = Microsoft.VisualBasic.Left(Me.cmbManipulativnaMestaIm.Text, 5)
        End If

        StLom = bStanicaVia

        If Int(St1) < Int(StLom) Then
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                       "FROM dbo.ZsDaljinar " & _
                       "WHERE (Stanica1 = '" & St1 & "') AND (Stanica2 = '" & StLom & "')"
        Else
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                       "FROM dbo.ZsDaljinar " & _
                       "WHERE (Stanica1 = '" & StLom & "') AND (Stanica2 = '" & St1 & "')"
        End If

        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrDalj As SqlClient.SqlDataReader

        rdrDalj = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrDalj.Read()
            outTkm1 = rdrDalj.GetInt16(0)
            outSkm1 = rdrDalj.GetInt16(1)
            tbR53.Text = outTkm1
        Loop
        rdrDalj.Close()
        DbVeza.Close()

        '2.deo
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        If Int(StLom) < Int(St2) Then
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                       "FROM dbo.ZsDaljinar " & _
                       "WHERE (Stanica1 = '" & StLom & "') AND (Stanica2 = '" & St2 & "')"
        Else
            sql_text = "SELECT TarifskiKm, StvarniKm " & _
                       "FROM dbo.ZsDaljinar " & _
                       "WHERE (Stanica1 = '" & St2 & "') AND (Stanica2 = '" & StLom & "')"
        End If

        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrDalj1 As SqlClient.SqlDataReader

        rdrDalj1 = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrDalj1.Read()
            outTkm2 = rdrDalj1.GetInt16(0)
            outSkm2 = rdrDalj1.GetInt16(1)
            tbR53_LP2.Text = outTkm2
        Loop
        rdrDalj1.Close()
        DbVeza.Close()

    End Sub

    Private Sub tbStanicaLom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaLom.KeyPress

        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbR53_LP2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbR53_LP2.KeyPress

        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbTugF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbTugF.Validating
        bTUGF = tbTugF.Text
        tbTugF.Text = Format(bTUGF, "###,###,##0.00")

    End Sub

    Private Sub tbTugU_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbTugU.Validating
        bTUGU = tbTugU.Text
        tbTugU.Text = Format(bTUGU, "###,###,##0.00")
    End Sub

    Private Sub tbTugF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbTugF.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbTugU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbTugU.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbDKIznos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDKIznos.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbDKIznos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbDKIznos.Validating
        bDKIznos = tbDKIznos.Text
        tbDKIznos.Text = Format(bDKIznos, "###,###,##0.00")
        bOsveziZaDKIPripremiZaUpis()
        Button1.Focus()
    End Sub

    Private Sub bOsveziZaDKIPripremiZaUpis()

        tbSumaF.Text = 0
        tbSumaU.Text = tbDKIznos.Text
        tbPrevF.Text = 0
        tbPrevU.Text = 0
        tbNak1F.Text = 0
        tbNak2F.Text = 0
        tbNak3F.Text = 0
        tbNak4F.Text = 0
        tbNak1U.Text = 0
        tbNak2U.Text = 0
        tbNak3U.Text = 0
        tbNak4U.Text = 0
        'UP_Stanica.Text = tbDKIznos.Text

        bSumaLevo = CType(tbSumaF.Text, Decimal)
        bSumaDesno = CType(tbSumaU.Text, Decimal)
        bPrevozninaLevo = CType(tbPrevF.Text, Decimal)
        bPrevozninaDesno = CType(tbPrevU.Text, Decimal)
        bSumaNaknadaLevo = CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)
        bSumaNaknadaDesno = CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)

    End Sub

    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        If bTarifa72 = 94 Then
            UP_Stanica.Focus()
        End If
    End Sub

    Private Sub tb20a_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb20a.Validating
        bUkljucujuciNiz(0) = tb20a.Text
    End Sub

    Private Sub tb20b_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb20b.Validating
        bUkljucujuciNiz(1) = tb20b.Text
    End Sub

    Private Sub tb20c_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb20c.Validating
        bUkljucujuciNiz(2) = tb20c.Text
    End Sub

    Private Sub tb20d_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb20d.Validating
        bUkljucujuciNiz(3) = tb20d.Text
    End Sub

    Private Sub tbR44Iznos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbR44Iznos.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbR44Iznos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbR44Iznos.Validating
        bIznosPoIzjavi = tbR44Iznos.Text
        tbR44Iznos.Text = Format(bIznosPoIzjavi, "###,###,##0.00")
        Button18.Focus()
    End Sub
    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        rtbR10.Text = ug_mNazivKomitentaPP & vbCrLf & vbCrLf & ug_mZemljaKomitentaPP & vbCrLf & ug_mGradKomitentaPP & vbCrLf & ug_mAdresaKomitentaPP
        Me.tbR11.Text = ug_mPraviPlatilac.ToString
    End Sub
    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        rtbR16.Text = ug_mNazivKomitentaPP & vbCrLf & vbCrLf & ug_mZemljaKomitentaPP & vbCrLf & ug_mGradKomitentaPP & vbCrLf & ug_mAdresaKomitentaPP
        Me.tbR17.Text = ug_mPraviPlatilac.ToString
    End Sub
    Private Sub tbNajava_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNajava.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub tbNajava_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbNajava.Validating
        mNajava = tbNajava.Text
    End Sub
End Class
