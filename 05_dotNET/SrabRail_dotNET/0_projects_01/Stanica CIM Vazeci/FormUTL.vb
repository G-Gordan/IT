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
Public Class FormUTL
    Inherits System.Windows.Forms.Form
    Public mBrojPokusaja As Int16 = 1
    Public ErrKontrola As String = "NO"
    Public tmpUgovor As String = ""
    Public _ForNum As Int16 = 0
    Public NumNizR50 As Int16 = 0
    Public SourceFile As String
    Dim str_R50, str_R50naziv As String
    Dim NizR50(10, 2) As String
    Dim BrojPrelazaUNizu As Int16 = 0
    Dim SkokNaVoz As String = "Da"

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbKm2 As System.Windows.Forms.TextBox
    Friend WithEvents tbKm1 As System.Windows.Forms.TextBox
    Friend WithEvents cbZsPrevozniPut As System.Windows.Forms.ComboBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents tbPrevoznina As System.Windows.Forms.TextBox
    Friend WithEvents gbSaobracaj As System.Windows.Forms.GroupBox
    Friend WithEvents rbKolska As System.Windows.Forms.RadioButton
    Friend WithEvents rbDencana As System.Windows.Forms.RadioButton
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSmer1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbSmer2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents dgError As System.Windows.Forms.DataGrid
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents tbUlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents tbIzlaznaNalepnica As System.Windows.Forms.TextBox
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
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpis As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents cmbPrevPut As System.Windows.Forms.ComboBox
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents gbPrevozniPut As System.Windows.Forms.GroupBox
    Friend WithEvents lblPP As System.Windows.Forms.Label
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormUTL))
        Me.cmbPrevPut = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbUlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.tbIzlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Button11 = New System.Windows.Forms.Button
        Me.btnUpis = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.tbBrojOtp = New System.Windows.Forms.TextBox
        Me.tbStanicaOtp = New System.Windows.Forms.TextBox
        Me.tbBrojPr = New System.Windows.Forms.TextBox
        Me.tbStanicaPr = New System.Windows.Forms.TextBox
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.tbKm2 = New System.Windows.Forms.TextBox
        Me.tbKm1 = New System.Windows.Forms.TextBox
        Me.cbZsPrevozniPut = New System.Windows.Forms.ComboBox
        Me.tbPrevoznina = New System.Windows.Forms.TextBox
        Me.gbSaobracaj = New System.Windows.Forms.GroupBox
        Me.rbKolska = New System.Windows.Forms.RadioButton
        Me.rbDencana = New System.Windows.Forms.RadioButton
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Button10 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.cbSmer1 = New System.Windows.Forms.ComboBox
        Me.cbSmer2 = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
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
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.gbPrevozniPut = New System.Windows.Forms.GroupBox
        Me.lblPP = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
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
        Me.tbR43a = New System.Windows.Forms.TextBox
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
        Me.tbIBK_4 = New System.Windows.Forms.TextBox
        Me.tbR21_3 = New System.Windows.Forms.TextBox
        Me.tbIBK_3 = New System.Windows.Forms.TextBox
        Me.tbR21_2 = New System.Windows.Forms.TextBox
        Me.tbIBK_2 = New System.Windows.Forms.TextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cbPDV = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        Me.gbSaobracaj.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.gbPrevozniPut.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbPrevPut
        '
        Me.cmbPrevPut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrevPut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrevPut.Location = New System.Drawing.Point(9, 15)
        Me.cmbPrevPut.Name = "cmbPrevPut"
        Me.cmbPrevPut.Size = New System.Drawing.Size(207, 23)
        Me.cmbPrevPut.TabIndex = 311
        '
        'tbUlaznaNalepnica
        '
        Me.tbUlaznaNalepnica.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.tbUlaznaNalepnica.Cursor = System.Windows.Forms.Cursors.Help
        Me.tbUlaznaNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbUlaznaNalepnica.ForeColor = System.Drawing.Color.Black
        Me.tbUlaznaNalepnica.Location = New System.Drawing.Point(8, 27)
        Me.tbUlaznaNalepnica.MaxLength = 5
        Me.tbUlaznaNalepnica.Name = "tbUlaznaNalepnica"
        Me.tbUlaznaNalepnica.Size = New System.Drawing.Size(80, 23)
        Me.tbUlaznaNalepnica.TabIndex = 224
        Me.tbUlaznaNalepnica.Text = ""
        Me.tbUlaznaNalepnica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbUlaznaNalepnica, "Ulazna tranzitna nalepnica")
        '
        'tbIzlaznaNalepnica
        '
        Me.tbIzlaznaNalepnica.BackColor = System.Drawing.Color.White
        Me.tbIzlaznaNalepnica.Cursor = System.Windows.Forms.Cursors.Help
        Me.tbIzlaznaNalepnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIzlaznaNalepnica.ForeColor = System.Drawing.Color.Black
        Me.tbIzlaznaNalepnica.Location = New System.Drawing.Point(121, 27)
        Me.tbIzlaznaNalepnica.MaxLength = 5
        Me.tbIzlaznaNalepnica.Name = "tbIzlaznaNalepnica"
        Me.tbIzlaznaNalepnica.Size = New System.Drawing.Size(80, 23)
        Me.tbIzlaznaNalepnica.TabIndex = 226
        Me.tbIzlaznaNalepnica.Text = ""
        Me.tbIzlaznaNalepnica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbIzlaznaNalepnica, "Izlazna tranzitna nalepnica")
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button11.Location = New System.Drawing.Point(850, 598)
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
        Me.btnUpis.Location = New System.Drawing.Point(922, 598)
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
        Me.Button12.Location = New System.Drawing.Point(922, 654)
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
        Me.Button3.Location = New System.Drawing.Point(778, 654)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 56)
        Me.Button3.TabIndex = 313
        Me.Button3.Text = "Stampa"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Button3, "Upis u bazu")
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.BackColor = System.Drawing.Color.White
        Me.tbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojOtp.Location = New System.Drawing.Point(8, 78)
        Me.tbBrojOtp.MaxLength = 5
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.Size = New System.Drawing.Size(62, 22)
        Me.tbBrojOtp.TabIndex = 1
        Me.tbBrojOtp.Text = ""
        Me.tbBrojOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbBrojOtp, "Broj otpravljanja")
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
        Me.tbStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaOtp.Location = New System.Drawing.Point(8, 25)
        Me.tbStanicaOtp.MaxLength = 5
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.Size = New System.Drawing.Size(62, 22)
        Me.tbStanicaOtp.TabIndex = 0
        Me.tbStanicaOtp.Text = ""
        Me.tbStanicaOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbStanicaOtp, "Otpravna stanica")
        '
        'tbBrojPr
        '
        Me.tbBrojPr.Enabled = False
        Me.tbBrojPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojPr.Location = New System.Drawing.Point(8, 83)
        Me.tbBrojPr.MaxLength = 5
        Me.tbBrojPr.Name = "tbBrojPr"
        Me.tbBrojPr.Size = New System.Drawing.Size(62, 22)
        Me.tbBrojPr.TabIndex = 1
        Me.tbBrojPr.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbBrojPr, "Broj prispeca")
        '
        'tbStanicaPr
        '
        Me.tbStanicaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaPr.Location = New System.Drawing.Point(8, 28)
        Me.tbStanicaPr.MaxLength = 5
        Me.tbStanicaPr.Name = "tbStanicaPr"
        Me.tbStanicaPr.Size = New System.Drawing.Size(62, 22)
        Me.tbStanicaPr.TabIndex = 0
        Me.tbStanicaPr.Text = ""
        Me.tbStanicaPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbStanicaPr, "Stanica prispeca")
        '
        'tbR47
        '
        Me.tbR47.BackColor = System.Drawing.Color.LightPink
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
        Me.tbPrevU.BackColor = System.Drawing.Color.LightPink
        Me.tbPrevU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevU.Location = New System.Drawing.Point(636, 776)
        Me.tbPrevU.MaxLength = 18
        Me.tbPrevU.Name = "tbPrevU"
        Me.tbPrevU.Size = New System.Drawing.Size(96, 20)
        Me.tbPrevU.TabIndex = 375
        Me.tbPrevU.Text = "0"
        Me.tbPrevU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbPrevU, "Pouzece")
        '
        'tbR45b
        '
        Me.tbR45b.BackColor = System.Drawing.Color.LightPink
        Me.tbR45b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR45b.Location = New System.Drawing.Point(216, 612)
        Me.tbR45b.Name = "tbR45b"
        Me.tbR45b.Size = New System.Drawing.Size(240, 20)
        Me.tbR45b.TabIndex = 365
        Me.tbR45b.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR45b, "Datum ispostavljanja tovarnog lista")
        '
        'tbR44Iznos
        '
        Me.tbR44Iznos.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR44Iznos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR44Iznos.Location = New System.Drawing.Point(520, 656)
        Me.tbR44Iznos.MaxLength = 4
        Me.tbR44Iznos.Name = "tbR44Iznos"
        Me.tbR44Iznos.Size = New System.Drawing.Size(96, 20)
        Me.tbR44Iznos.TabIndex = 364
        Me.tbR44Iznos.Text = "0"
        Me.tbR44Iznos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR44Iznos, "Pouzece")
        '
        'tbR41Suma
        '
        Me.tbR41Suma.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR41Suma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR41Suma.Location = New System.Drawing.Point(520, 611)
        Me.tbR41Suma.MaxLength = 12
        Me.tbR41Suma.Name = "tbR41Suma"
        Me.tbR41Suma.Size = New System.Drawing.Size(96, 20)
        Me.tbR41Suma.TabIndex = 363
        Me.tbR41Suma.Text = "0"
        Me.tbR41Suma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR41Suma, "Pouzece")
        '
        'tbR32a
        '
        Me.tbR32a.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR32a.Location = New System.Drawing.Point(356, 402)
        Me.tbR32a.Name = "tbR32a"
        Me.tbR32a.Size = New System.Drawing.Size(224, 20)
        Me.tbR32a.TabIndex = 362
        Me.tbR32a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR32a, "Naziv uputne stanice")
        '
        'tbR31Sifra
        '
        Me.tbR31Sifra.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR31Sifra.Location = New System.Drawing.Point(356, 373)
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
        Me.tbR31naziv.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR31naziv.Location = New System.Drawing.Point(444, 373)
        Me.tbR31naziv.Name = "tbR31naziv"
        Me.tbR31naziv.Size = New System.Drawing.Size(168, 20)
        Me.tbR31naziv.TabIndex = 360
        Me.tbR31naziv.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR31naziv, "Naziv uputne stanice")
        '
        'tbR50
        '
        Me.tbR50.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR50.Location = New System.Drawing.Point(520, 691)
        Me.tbR50.MaxLength = 12
        Me.tbR50.Name = "tbR50"
        Me.tbR50.Size = New System.Drawing.Size(96, 20)
        Me.tbR50.TabIndex = 359
        Me.tbR50.Text = "0"
        Me.tbR50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR50, "Predujam")
        '
        'tbR15
        '
        Me.tbR15.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR15.Location = New System.Drawing.Point(356, 130)
        Me.tbR15.Name = "tbR15"
        Me.tbR15.Size = New System.Drawing.Size(224, 20)
        Me.tbR15.TabIndex = 356
        Me.tbR15.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR15, "Naziv mesta utovara")
        '
        'tbR14Sifra
        '
        Me.tbR14Sifra.BackColor = System.Drawing.Color.LemonChiffon
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
        Me.tbR14Naziv.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR14Naziv.Location = New System.Drawing.Point(443, 102)
        Me.tbR14Naziv.Name = "tbR14Naziv"
        Me.tbR14Naziv.Size = New System.Drawing.Size(168, 20)
        Me.tbR14Naziv.TabIndex = 354
        Me.tbR14Naziv.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR14Naziv, "Naziv manipulativnog mesta")
        '
        'tbR12Naziv
        '
        Me.tbR12Naziv.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR12Naziv.Location = New System.Drawing.Point(443, 72)
        Me.tbR12Naziv.Name = "tbR12Naziv"
        Me.tbR12Naziv.Size = New System.Drawing.Size(168, 20)
        Me.tbR12Naziv.TabIndex = 353
        Me.tbR12Naziv.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR12Naziv, "Naziv otpravne stanice")
        '
        'tbR12Sifra
        '
        Me.tbR12Sifra.BackColor = System.Drawing.Color.LemonChiffon
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
        Me.tbCtrlNum.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbCtrlNum.Cursor = System.Windows.Forms.Cursors.Help
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
        Me.Button15.Location = New System.Drawing.Point(328, 160)
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
        Me.Button14.Location = New System.Drawing.Point(328, 68)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(20, 22)
        Me.Button14.TabIndex = 227
        Me.Button14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button14, "Izaberi korisnièku šifru onoga koji plaæa frankirane troškove")
        '
        'tbR49
        '
        Me.tbR49.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR49.Location = New System.Drawing.Point(346, 691)
        Me.tbR49.MaxLength = 12
        Me.tbR49.Name = "tbR49"
        Me.tbR49.Size = New System.Drawing.Size(96, 20)
        Me.tbR49.TabIndex = 187
        Me.tbR49.Text = "0"
        Me.tbR49.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR49, "Pouzece")
        '
        'btnUnosRobe
        '
        Me.btnUnosRobe.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnUnosRobe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUnosRobe.Image = CType(resources.GetObject("btnUnosRobe.Image"), System.Drawing.Image)
        Me.btnUnosRobe.Location = New System.Drawing.Point(488, 232)
        Me.btnUnosRobe.Name = "btnUnosRobe"
        Me.btnUnosRobe.Size = New System.Drawing.Size(32, 80)
        Me.btnUnosRobe.TabIndex = 185
        Me.ToolTip1.SetToolTip(Me.btnUnosRobe, "Unos podataka o robi i kolima")
        '
        'tbR35
        '
        Me.tbR35.BackColor = System.Drawing.Color.LightPink
        Me.tbR35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR35.Location = New System.Drawing.Point(280, 440)
        Me.tbR35.MaxLength = 100
        Me.tbR35.Multiline = True
        Me.tbR35.Name = "tbR35"
        Me.tbR35.Size = New System.Drawing.Size(336, 40)
        Me.tbR35.TabIndex = 126
        Me.tbR35.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR35, "Opis prevoznog puta")
        '
        'tbR45a
        '
        Me.tbR45a.BackColor = System.Drawing.Color.LightPink
        Me.tbR45a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR45a.Location = New System.Drawing.Point(139, 613)
        Me.tbR45a.Name = "tbR45a"
        Me.tbR45a.Size = New System.Drawing.Size(64, 20)
        Me.tbR45a.TabIndex = 113
        Me.tbR45a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR45a, "Datum ispostavljanja tovarnog lista")
        '
        'tbR17
        '
        Me.tbR17.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR17.Location = New System.Drawing.Point(259, 162)
        Me.tbR17.Name = "tbR17"
        Me.tbR17.Size = New System.Drawing.Size(61, 20)
        Me.tbR17.TabIndex = 28
        Me.tbR17.Text = "0"
        Me.tbR17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR17, "Korisnicka sifra primaoca")
        '
        'tbR30Naziv
        '
        Me.tbR30Naziv.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR30Naziv.Location = New System.Drawing.Point(88, 384)
        Me.tbR30Naziv.Name = "tbR30Naziv"
        Me.tbR30Naziv.Size = New System.Drawing.Size(256, 20)
        Me.tbR30Naziv.TabIndex = 23
        Me.tbR30Naziv.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR30Naziv, "Naziv uputne stanice")
        '
        'tbR30Sifra
        '
        Me.tbR30Sifra.BackColor = System.Drawing.Color.LemonChiffon
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
        Me.tbR11.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR11.Cursor = System.Windows.Forms.Cursors.Help
        Me.tbR11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR11.Location = New System.Drawing.Point(259, 72)
        Me.tbR11.Name = "tbR11"
        Me.tbR11.Size = New System.Drawing.Size(61, 20)
        Me.tbR11.TabIndex = 3
        Me.tbR11.Text = "0"
        Me.tbR11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR11, "Korisnicka sifra posiljaoca")
        '
        'tbR23_4
        '
        Me.tbR23_4.BackColor = System.Drawing.Color.LightPink
        Me.tbR23_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR23_4.Location = New System.Drawing.Point(527, 292)
        Me.tbR23_4.Name = "tbR23_4"
        Me.tbR23_4.Size = New System.Drawing.Size(41, 18)
        Me.tbR23_4.TabIndex = 410
        Me.tbR23_4.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR23_4, "Datum ispostavljanja tovarnog lista")
        '
        'tbR23_3
        '
        Me.tbR23_3.BackColor = System.Drawing.Color.LightPink
        Me.tbR23_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR23_3.Location = New System.Drawing.Point(527, 276)
        Me.tbR23_3.Name = "tbR23_3"
        Me.tbR23_3.Size = New System.Drawing.Size(41, 18)
        Me.tbR23_3.TabIndex = 409
        Me.tbR23_3.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR23_3, "Datum ispostavljanja tovarnog lista")
        '
        'tbR23_2
        '
        Me.tbR23_2.BackColor = System.Drawing.Color.LightPink
        Me.tbR23_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR23_2.Location = New System.Drawing.Point(527, 260)
        Me.tbR23_2.Name = "tbR23_2"
        Me.tbR23_2.Size = New System.Drawing.Size(41, 18)
        Me.tbR23_2.TabIndex = 408
        Me.tbR23_2.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR23_2, "Datum ispostavljanja tovarnog lista")
        '
        'tbR23_1
        '
        Me.tbR23_1.BackColor = System.Drawing.Color.LightPink
        Me.tbR23_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR23_1.Location = New System.Drawing.Point(527, 244)
        Me.tbR23_1.Name = "tbR23_1"
        Me.tbR23_1.Size = New System.Drawing.Size(41, 18)
        Me.tbR23_1.TabIndex = 407
        Me.tbR23_1.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR23_1, "Datum ispostavljanja tovarnog lista")
        '
        'tbR48a
        '
        Me.tbR48a.BackColor = System.Drawing.Color.LightPink
        Me.tbR48a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR48a.Location = New System.Drawing.Point(181, 690)
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
        Me.tbR48b.BackColor = System.Drawing.Color.LightPink
        Me.tbR48b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR48b.Location = New System.Drawing.Point(181, 712)
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
        Me.tbR53.BackColor = System.Drawing.Color.LightPink
        Me.tbR53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR53.Location = New System.Drawing.Point(296, 723)
        Me.tbR53.MaxLength = 4
        Me.tbR53.Name = "tbR53"
        Me.tbR53.Size = New System.Drawing.Size(56, 20)
        Me.tbR53.TabIndex = 413
        Me.tbR53.Text = "0"
        Me.tbR53.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR53, "Pouzece")
        '
        'tbR60
        '
        Me.tbR60.BackColor = System.Drawing.Color.LightPink
        Me.tbR60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR60.Location = New System.Drawing.Point(296, 757)
        Me.tbR60.MaxLength = 12
        Me.tbR60.Name = "tbR60"
        Me.tbR60.Size = New System.Drawing.Size(56, 20)
        Me.tbR60.TabIndex = 414
        Me.tbR60.Text = "0"
        Me.tbR60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR60, "Pouzece")
        '
        'tbR54_1
        '
        Me.tbR54_1.BackColor = System.Drawing.Color.LightPink
        Me.tbR54_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR54_1.Location = New System.Drawing.Point(368, 728)
        Me.tbR54_1.MaxLength = 4
        Me.tbR54_1.Name = "tbR54_1"
        Me.tbR54_1.Size = New System.Drawing.Size(24, 18)
        Me.tbR54_1.TabIndex = 415
        Me.tbR54_1.Text = "0"
        Me.tbR54_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR54_1, "Pouzece")
        '
        'tbR54_2
        '
        Me.tbR54_2.BackColor = System.Drawing.Color.LightPink
        Me.tbR54_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR54_2.Location = New System.Drawing.Point(368, 744)
        Me.tbR54_2.MaxLength = 4
        Me.tbR54_2.Name = "tbR54_2"
        Me.tbR54_2.Size = New System.Drawing.Size(24, 18)
        Me.tbR54_2.TabIndex = 416
        Me.tbR54_2.Text = "0"
        Me.tbR54_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR54_2, "Pouzece")
        '
        'tbR54_3
        '
        Me.tbR54_3.BackColor = System.Drawing.Color.LightPink
        Me.tbR54_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR54_3.Location = New System.Drawing.Point(368, 759)
        Me.tbR54_3.MaxLength = 4
        Me.tbR54_3.Name = "tbR54_3"
        Me.tbR54_3.Size = New System.Drawing.Size(24, 18)
        Me.tbR54_3.TabIndex = 417
        Me.tbR54_3.Text = "0"
        Me.tbR54_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR54_3, "Pouzece")
        '
        'tbPrevStav3
        '
        Me.tbPrevStav3.BackColor = System.Drawing.Color.LightPink
        Me.tbPrevStav3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevStav3.Location = New System.Drawing.Point(404, 759)
        Me.tbPrevStav3.MaxLength = 4
        Me.tbPrevStav3.Name = "tbPrevStav3"
        Me.tbPrevStav3.Size = New System.Drawing.Size(52, 18)
        Me.tbPrevStav3.TabIndex = 420
        Me.tbPrevStav3.Text = "0"
        Me.tbPrevStav3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbPrevStav3, "Pouzece")
        '
        'tbPrevStav2
        '
        Me.tbPrevStav2.BackColor = System.Drawing.Color.LightPink
        Me.tbPrevStav2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevStav2.Location = New System.Drawing.Point(404, 743)
        Me.tbPrevStav2.MaxLength = 4
        Me.tbPrevStav2.Name = "tbPrevStav2"
        Me.tbPrevStav2.Size = New System.Drawing.Size(52, 18)
        Me.tbPrevStav2.TabIndex = 419
        Me.tbPrevStav2.Text = "0"
        Me.tbPrevStav2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbPrevStav2, "Pouzece")
        '
        'tbPrevStav1
        '
        Me.tbPrevStav1.BackColor = System.Drawing.Color.LightPink
        Me.tbPrevStav1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevStav1.Location = New System.Drawing.Point(404, 727)
        Me.tbPrevStav1.MaxLength = 4
        Me.tbPrevStav1.Name = "tbPrevStav1"
        Me.tbPrevStav1.Size = New System.Drawing.Size(52, 18)
        Me.tbPrevStav1.TabIndex = 418
        Me.tbPrevStav1.Text = "0"
        Me.tbPrevStav1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbPrevStav1, "Pouzece")
        '
        'tb56c
        '
        Me.tb56c.BackColor = System.Drawing.Color.LightPink
        Me.tb56c.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb56c.Location = New System.Drawing.Point(475, 759)
        Me.tb56c.MaxLength = 4
        Me.tb56c.Name = "tb56c"
        Me.tb56c.Size = New System.Drawing.Size(32, 18)
        Me.tb56c.TabIndex = 423
        Me.tb56c.Text = "0"
        Me.tb56c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb56c, "Pouzece")
        '
        'tb56b
        '
        Me.tb56b.BackColor = System.Drawing.Color.LightPink
        Me.tb56b.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb56b.Location = New System.Drawing.Point(475, 743)
        Me.tb56b.MaxLength = 4
        Me.tb56b.Name = "tb56b"
        Me.tb56b.Size = New System.Drawing.Size(32, 18)
        Me.tb56b.TabIndex = 422
        Me.tb56b.Text = "0"
        Me.tb56b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb56b, "Pouzece")
        '
        'tb56a
        '
        Me.tb56a.BackColor = System.Drawing.Color.LightPink
        Me.tb56a.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb56a.Location = New System.Drawing.Point(475, 727)
        Me.tb56a.MaxLength = 4
        Me.tb56a.Name = "tb56a"
        Me.tb56a.Size = New System.Drawing.Size(32, 18)
        Me.tb56a.TabIndex = 421
        Me.tb56a.Text = "0"
        Me.tb56a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb56a, "Pouzece")
        '
        'tbR57_3
        '
        Me.tbR57_3.BackColor = System.Drawing.Color.LightPink
        Me.tbR57_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR57_3.Location = New System.Drawing.Point(520, 759)
        Me.tbR57_3.MaxLength = 4
        Me.tbR57_3.Name = "tbR57_3"
        Me.tbR57_3.Size = New System.Drawing.Size(96, 18)
        Me.tbR57_3.TabIndex = 426
        Me.tbR57_3.Text = "0"
        Me.tbR57_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR57_3, "Pouzece")
        '
        'tbR57_2
        '
        Me.tbR57_2.BackColor = System.Drawing.Color.LightPink
        Me.tbR57_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR57_2.Location = New System.Drawing.Point(520, 743)
        Me.tbR57_2.MaxLength = 4
        Me.tbR57_2.Name = "tbR57_2"
        Me.tbR57_2.Size = New System.Drawing.Size(96, 18)
        Me.tbR57_2.TabIndex = 425
        Me.tbR57_2.Text = "0"
        Me.tbR57_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR57_2, "Pouzece")
        '
        'tbR57_1
        '
        Me.tbR57_1.BackColor = System.Drawing.Color.LightPink
        Me.tbR57_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR57_1.Location = New System.Drawing.Point(520, 727)
        Me.tbR57_1.MaxLength = 4
        Me.tbR57_1.Name = "tbR57_1"
        Me.tbR57_1.Size = New System.Drawing.Size(96, 18)
        Me.tbR57_1.TabIndex = 424
        Me.tbR57_1.Text = "0"
        Me.tbR57_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbR57_1, "Pouzece")
        '
        'tbR28
        '
        Me.tbR28.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR51.BackColor = System.Drawing.Color.LightPink
        Me.tbR51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR51.Location = New System.Drawing.Point(636, 691)
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
        Me.tbR9.BackColor = System.Drawing.Color.LightPink
        Me.tbR9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR9.Location = New System.Drawing.Point(5, 81)
        Me.tbR9.MaxLength = 100
        Me.tbR9.Multiline = True
        Me.tbR9.Name = "tbR9"
        Me.tbR9.Size = New System.Drawing.Size(48, 279)
        Me.tbR9.TabIndex = 455
        Me.tbR9.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbR9, "Podatak o stvarnom prevoznom putu uz korišæenje šifara koje važe za granice")
        '
        'tbR32b
        '
        Me.tbR32b.BackColor = System.Drawing.Color.LightPink
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
        Me.tb15_1.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR2.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR58.BackColor = System.Drawing.Color.LightPink
        Me.tbR58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR58.Location = New System.Drawing.Point(144, 757)
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
        Me.tbR59.BackColor = System.Drawing.Color.LightPink
        Me.tbR59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR59.Location = New System.Drawing.Point(256, 757)
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
        Me.tbR46.BackColor = System.Drawing.Color.LightPink
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
        Me.btnKalk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKalk.Location = New System.Drawing.Point(778, 598)
        Me.btnKalk.Name = "btnKalk"
        Me.btnKalk.Size = New System.Drawing.Size(72, 56)
        Me.btnKalk.TabIndex = 448
        Me.btnKalk.Text = "Kalkulacija"
        Me.ToolTip1.SetToolTip(Me.btnKalk, "Upis u bazu")
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.Color.LightPink
        Me.Button18.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button18.Image = CType(resources.GetObject("Button18.Image"), System.Drawing.Image)
        Me.Button18.Location = New System.Drawing.Point(155, 792)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(40, 82)
        Me.Button18.TabIndex = 296
        Me.Button18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.Button18, "Izbor naknada za sporedne usluge")
        '
        'tbR24_4
        '
        Me.tbR24_4.BackColor = System.Drawing.Color.LightPink
        Me.tbR24_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR24_4.Location = New System.Drawing.Point(584, 293)
        Me.tbR24_4.Name = "tbR24_4"
        Me.tbR24_4.Size = New System.Drawing.Size(56, 18)
        Me.tbR24_4.TabIndex = 388
        Me.tbR24_4.Text = ""
        '
        'tbR24_3
        '
        Me.tbR24_3.BackColor = System.Drawing.Color.LightPink
        Me.tbR24_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR24_3.Location = New System.Drawing.Point(584, 277)
        Me.tbR24_3.Name = "tbR24_3"
        Me.tbR24_3.Size = New System.Drawing.Size(56, 18)
        Me.tbR24_3.TabIndex = 387
        Me.tbR24_3.Text = ""
        '
        'tbR24_2
        '
        Me.tbR24_2.BackColor = System.Drawing.Color.LightPink
        Me.tbR24_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR24_2.Location = New System.Drawing.Point(584, 261)
        Me.tbR24_2.Name = "tbR24_2"
        Me.tbR24_2.Size = New System.Drawing.Size(56, 18)
        Me.tbR24_2.TabIndex = 386
        Me.tbR24_2.Text = ""
        '
        'tbR24_1
        '
        Me.tbR24_1.BackColor = System.Drawing.Color.LightPink
        Me.tbR24_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR24_1.Location = New System.Drawing.Point(584, 245)
        Me.tbR24_1.Name = "tbR24_1"
        Me.tbR24_1.Size = New System.Drawing.Size(56, 18)
        Me.tbR24_1.TabIndex = 385
        Me.tbR24_1.Text = ""
        '
        'tbA79b4
        '
        Me.tbA79b4.BackColor = System.Drawing.Color.LightPink
        Me.tbA79b4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b4.Location = New System.Drawing.Point(236, 840)
        Me.tbA79b4.MaxLength = 6
        Me.tbA79b4.Name = "tbA79b4"
        Me.tbA79b4.Size = New System.Drawing.Size(41, 20)
        Me.tbA79b4.TabIndex = 370
        Me.tbA79b4.Text = ""
        Me.tbA79b4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbA79a4
        '
        Me.tbA79a4.BackColor = System.Drawing.Color.LightPink
        Me.tbA79a4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a4.Location = New System.Drawing.Point(196, 840)
        Me.tbA79a4.MaxLength = 2
        Me.tbA79a4.Name = "tbA79a4"
        Me.tbA79a4.Size = New System.Drawing.Size(40, 20)
        Me.tbA79a4.TabIndex = 369
        Me.tbA79a4.Text = ""
        Me.tbA79a4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbA79b3
        '
        Me.tbA79b3.BackColor = System.Drawing.Color.LightPink
        Me.tbA79b3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b3.Location = New System.Drawing.Point(236, 824)
        Me.tbA79b3.MaxLength = 6
        Me.tbA79b3.Name = "tbA79b3"
        Me.tbA79b3.Size = New System.Drawing.Size(41, 20)
        Me.tbA79b3.TabIndex = 275
        Me.tbA79b3.Text = ""
        Me.tbA79b3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbA79a3
        '
        Me.tbA79a3.BackColor = System.Drawing.Color.LightPink
        Me.tbA79a3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a3.Location = New System.Drawing.Point(196, 824)
        Me.tbA79a3.MaxLength = 2
        Me.tbA79a3.Name = "tbA79a3"
        Me.tbA79a3.Size = New System.Drawing.Size(40, 20)
        Me.tbA79a3.TabIndex = 274
        Me.tbA79a3.Text = ""
        Me.tbA79a3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbA79b2
        '
        Me.tbA79b2.BackColor = System.Drawing.Color.LightPink
        Me.tbA79b2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b2.Location = New System.Drawing.Point(236, 808)
        Me.tbA79b2.MaxLength = 6
        Me.tbA79b2.Name = "tbA79b2"
        Me.tbA79b2.Size = New System.Drawing.Size(41, 20)
        Me.tbA79b2.TabIndex = 273
        Me.tbA79b2.Text = ""
        Me.tbA79b2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbA79a2
        '
        Me.tbA79a2.BackColor = System.Drawing.Color.LightPink
        Me.tbA79a2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a2.Location = New System.Drawing.Point(196, 808)
        Me.tbA79a2.MaxLength = 2
        Me.tbA79a2.Name = "tbA79a2"
        Me.tbA79a2.Size = New System.Drawing.Size(40, 20)
        Me.tbA79a2.TabIndex = 272
        Me.tbA79a2.Text = ""
        Me.tbA79a2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbA79b1
        '
        Me.tbA79b1.BackColor = System.Drawing.Color.LightPink
        Me.tbA79b1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b1.Location = New System.Drawing.Point(236, 792)
        Me.tbA79b1.MaxLength = 6
        Me.tbA79b1.Name = "tbA79b1"
        Me.tbA79b1.Size = New System.Drawing.Size(41, 20)
        Me.tbA79b1.TabIndex = 214
        Me.tbA79b1.Text = ""
        Me.tbA79b1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbA79a1
        '
        Me.tbA79a1.BackColor = System.Drawing.Color.LightPink
        Me.tbA79a1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a1.Location = New System.Drawing.Point(196, 792)
        Me.tbA79a1.MaxLength = 2
        Me.tbA79a1.Name = "tbA79a1"
        Me.tbA79a1.Size = New System.Drawing.Size(40, 20)
        Me.tbA79a1.TabIndex = 213
        Me.tbA79a1.Text = ""
        Me.tbA79a1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb63a
        '
        Me.tb63a.BackColor = System.Drawing.Color.LightPink
        Me.tb63a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb63a.Location = New System.Drawing.Point(196, 880)
        Me.tb63a.MaxLength = 6
        Me.tb63a.Name = "tb63a"
        Me.tb63a.Size = New System.Drawing.Size(40, 20)
        Me.tb63a.TabIndex = 427
        Me.tb63a.Text = ""
        Me.tb63a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb62nd
        '
        Me.tb62nd.BackColor = System.Drawing.Color.LightPink
        Me.tb62nd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb62nd.Location = New System.Drawing.Point(277, 840)
        Me.tb62nd.MaxLength = 40
        Me.tb62nd.Name = "tb62nd"
        Me.tb62nd.Size = New System.Drawing.Size(264, 20)
        Me.tb62nd.TabIndex = 431
        Me.tb62nd.Text = ""
        '
        'tb62nc
        '
        Me.tb62nc.BackColor = System.Drawing.Color.LightPink
        Me.tb62nc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb62nc.Location = New System.Drawing.Point(277, 824)
        Me.tb62nc.MaxLength = 40
        Me.tb62nc.Name = "tb62nc"
        Me.tb62nc.Size = New System.Drawing.Size(264, 20)
        Me.tb62nc.TabIndex = 430
        Me.tb62nc.Text = ""
        '
        'tb62nb
        '
        Me.tb62nb.BackColor = System.Drawing.Color.LightPink
        Me.tb62nb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb62nb.Location = New System.Drawing.Point(277, 808)
        Me.tb62nb.MaxLength = 40
        Me.tb62nb.Name = "tb62nb"
        Me.tb62nb.Size = New System.Drawing.Size(264, 20)
        Me.tb62nb.TabIndex = 429
        Me.tb62nb.Text = ""
        '
        'tb62na
        '
        Me.tb62na.BackColor = System.Drawing.Color.LightPink
        Me.tb62na.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb62na.Location = New System.Drawing.Point(277, 792)
        Me.tb62na.MaxLength = 40
        Me.tb62na.Name = "tb62na"
        Me.tb62na.Size = New System.Drawing.Size(264, 20)
        Me.tb62na.TabIndex = 428
        Me.tb62na.Text = ""
        '
        'tbTug
        '
        Me.tbTug.BackColor = System.Drawing.Color.LightPink
        Me.tbTug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbTug.Location = New System.Drawing.Point(277, 880)
        Me.tbTug.MaxLength = 40
        Me.tbTug.Name = "tbTug"
        Me.tbTug.Size = New System.Drawing.Size(264, 20)
        Me.tbTug.TabIndex = 432
        Me.tbTug.Text = ""
        '
        'tbSumaNeto
        '
        Me.tbSumaNeto.BackColor = System.Drawing.Color.LightPink
        Me.tbSumaNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaNeto.Location = New System.Drawing.Point(584, 312)
        Me.tbSumaNeto.Name = "tbSumaNeto"
        Me.tbSumaNeto.Size = New System.Drawing.Size(56, 18)
        Me.tbSumaNeto.TabIndex = 448
        Me.tbSumaNeto.Text = ""
        '
        'tbR25a_2
        '
        Me.tbR25a_2.BackColor = System.Drawing.Color.LightPink
        Me.tbR25a_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25a_2.Location = New System.Drawing.Point(645, 261)
        Me.tbR25a_2.Name = "tbR25a_2"
        Me.tbR25a_2.Size = New System.Drawing.Size(16, 18)
        Me.tbR25a_2.TabIndex = 390
        Me.tbR25a_2.Text = ""
        '
        'tbR25a_1
        '
        Me.tbR25a_1.BackColor = System.Drawing.Color.LightPink
        Me.tbR25a_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25a_1.Location = New System.Drawing.Point(645, 245)
        Me.tbR25a_1.Name = "tbR25a_1"
        Me.tbR25a_1.Size = New System.Drawing.Size(16, 18)
        Me.tbR25a_1.TabIndex = 389
        Me.tbR25a_1.Text = ""
        '
        'tbR36
        '
        Me.tbR36.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR33_2.BackColor = System.Drawing.Color.LightPink
        Me.tbR33_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR33_2.Location = New System.Drawing.Point(660, 405)
        Me.tbR33_2.Name = "tbR33_2"
        Me.tbR33_2.Size = New System.Drawing.Size(72, 20)
        Me.tbR33_2.TabIndex = 383
        Me.tbR33_2.Text = ""
        Me.tbR33_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR33_1
        '
        Me.tbR33_1.BackColor = System.Drawing.Color.LightPink
        Me.tbR33_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR33_1.Location = New System.Drawing.Point(660, 376)
        Me.tbR33_1.Name = "tbR33_1"
        Me.tbR33_1.Size = New System.Drawing.Size(72, 20)
        Me.tbR33_1.TabIndex = 382
        Me.tbR33_1.Text = ""
        Me.tbR33_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox28
        '
        Me.TextBox28.BackColor = System.Drawing.Color.LightPink
        Me.TextBox28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox28.Location = New System.Drawing.Point(660, 344)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(72, 20)
        Me.TextBox28.TabIndex = 381
        Me.TextBox28.Text = ""
        '
        'tbR13_2
        '
        Me.tbR13_2.BackColor = System.Drawing.Color.LightPink
        Me.tbR13_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR13_2.Location = New System.Drawing.Point(660, 134)
        Me.tbR13_2.Name = "tbR13_2"
        Me.tbR13_2.Size = New System.Drawing.Size(72, 20)
        Me.tbR13_2.TabIndex = 380
        Me.tbR13_2.Text = ""
        Me.tbR13_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR13_1
        '
        Me.tbR13_1.BackColor = System.Drawing.Color.LightPink
        Me.tbR13_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR13_1.Location = New System.Drawing.Point(660, 104)
        Me.tbR13_1.Name = "tbR13_1"
        Me.tbR13_1.Size = New System.Drawing.Size(72, 20)
        Me.tbR13_1.TabIndex = 379
        Me.tbR13_1.Text = ""
        Me.tbR13_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox23
        '
        Me.TextBox23.BackColor = System.Drawing.Color.LightPink
        Me.TextBox23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox23.Location = New System.Drawing.Point(660, 73)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(72, 20)
        Me.TextBox23.TabIndex = 378
        Me.TextBox23.Text = ""
        '
        'tbPrevF
        '
        Me.tbPrevF.BackColor = System.Drawing.Color.LightPink
        Me.tbPrevF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevF.Location = New System.Drawing.Point(8, 776)
        Me.tbPrevF.MaxLength = 18
        Me.tbPrevF.Name = "tbPrevF"
        Me.tbPrevF.Size = New System.Drawing.Size(96, 20)
        Me.tbPrevF.TabIndex = 376
        Me.tbPrevF.Text = "0"
        Me.tbPrevF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbSumaU
        '
        Me.tbSumaU.BackColor = System.Drawing.Color.LightPink
        Me.tbSumaU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaU.Location = New System.Drawing.Point(636, 903)
        Me.tbSumaU.MaxLength = 18
        Me.tbSumaU.Name = "tbSumaU"
        Me.tbSumaU.Size = New System.Drawing.Size(96, 20)
        Me.tbSumaU.TabIndex = 374
        Me.tbSumaU.Text = "0"
        Me.tbSumaU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbSumaF
        '
        Me.tbSumaF.BackColor = System.Drawing.Color.LightPink
        Me.tbSumaF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaF.Location = New System.Drawing.Point(8, 901)
        Me.tbSumaF.MaxLength = 18
        Me.tbSumaF.Name = "tbSumaF"
        Me.tbSumaF.Size = New System.Drawing.Size(96, 20)
        Me.tbSumaF.TabIndex = 373
        Me.tbSumaF.Text = "0"
        Me.tbSumaF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR25a_4
        '
        Me.tbR25a_4.BackColor = System.Drawing.Color.LightPink
        Me.tbR25a_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25a_4.Location = New System.Drawing.Point(645, 293)
        Me.tbR25a_4.Name = "tbR25a_4"
        Me.tbR25a_4.Size = New System.Drawing.Size(16, 18)
        Me.tbR25a_4.TabIndex = 398
        Me.tbR25a_4.Text = ""
        '
        'tbR25a_3
        '
        Me.tbR25a_3.BackColor = System.Drawing.Color.LightPink
        Me.tbR25a_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25a_3.Location = New System.Drawing.Point(645, 277)
        Me.tbR25a_3.Name = "tbR25a_3"
        Me.tbR25a_3.Size = New System.Drawing.Size(16, 18)
        Me.tbR25a_3.TabIndex = 397
        Me.tbR25a_3.Text = ""
        '
        'tbR25b_4
        '
        Me.tbR25b_4.BackColor = System.Drawing.Color.LightPink
        Me.tbR25b_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25b_4.Location = New System.Drawing.Point(669, 293)
        Me.tbR25b_4.Name = "tbR25b_4"
        Me.tbR25b_4.Size = New System.Drawing.Size(25, 18)
        Me.tbR25b_4.TabIndex = 402
        Me.tbR25b_4.Text = ""
        '
        'tbR25b_3
        '
        Me.tbR25b_3.BackColor = System.Drawing.Color.LightPink
        Me.tbR25b_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25b_3.Location = New System.Drawing.Point(669, 277)
        Me.tbR25b_3.Name = "tbR25b_3"
        Me.tbR25b_3.Size = New System.Drawing.Size(25, 18)
        Me.tbR25b_3.TabIndex = 401
        Me.tbR25b_3.Text = ""
        '
        'tbR25b_2
        '
        Me.tbR25b_2.BackColor = System.Drawing.Color.LightPink
        Me.tbR25b_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25b_2.Location = New System.Drawing.Point(669, 261)
        Me.tbR25b_2.Name = "tbR25b_2"
        Me.tbR25b_2.Size = New System.Drawing.Size(25, 18)
        Me.tbR25b_2.TabIndex = 400
        Me.tbR25b_2.Text = ""
        '
        'tbR25b_1
        '
        Me.tbR25b_1.BackColor = System.Drawing.Color.LightPink
        Me.tbR25b_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR25b_1.Location = New System.Drawing.Point(669, 245)
        Me.tbR25b_1.Name = "tbR25b_1"
        Me.tbR25b_1.Size = New System.Drawing.Size(25, 18)
        Me.tbR25b_1.TabIndex = 399
        Me.tbR25b_1.Text = ""
        '
        'tbR26_4
        '
        Me.tbR26_4.BackColor = System.Drawing.Color.LightPink
        Me.tbR26_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR26_4.Location = New System.Drawing.Point(707, 292)
        Me.tbR26_4.Name = "tbR26_4"
        Me.tbR26_4.Size = New System.Drawing.Size(25, 18)
        Me.tbR26_4.TabIndex = 406
        Me.tbR26_4.Text = ""
        '
        'tbR26_3
        '
        Me.tbR26_3.BackColor = System.Drawing.Color.LightPink
        Me.tbR26_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR26_3.Location = New System.Drawing.Point(707, 276)
        Me.tbR26_3.Name = "tbR26_3"
        Me.tbR26_3.Size = New System.Drawing.Size(25, 18)
        Me.tbR26_3.TabIndex = 405
        Me.tbR26_3.Text = ""
        '
        'tbR26_2
        '
        Me.tbR26_2.BackColor = System.Drawing.Color.LightPink
        Me.tbR26_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR26_2.Location = New System.Drawing.Point(707, 260)
        Me.tbR26_2.Name = "tbR26_2"
        Me.tbR26_2.Size = New System.Drawing.Size(25, 18)
        Me.tbR26_2.TabIndex = 404
        Me.tbR26_2.Text = ""
        '
        'tbR26_1
        '
        Me.tbR26_1.BackColor = System.Drawing.Color.LightPink
        Me.tbR26_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR26_1.Location = New System.Drawing.Point(707, 244)
        Me.tbR26_1.Name = "tbR26_1"
        Me.tbR26_1.Size = New System.Drawing.Size(25, 18)
        Me.tbR26_1.TabIndex = 403
        Me.tbR26_1.Text = ""
        '
        'tbNak1F
        '
        Me.tbNak1F.BackColor = System.Drawing.Color.LightPink
        Me.tbNak1F.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak1F.Location = New System.Drawing.Point(8, 792)
        Me.tbNak1F.MaxLength = 18
        Me.tbNak1F.Name = "tbNak1F"
        Me.tbNak1F.Size = New System.Drawing.Size(96, 20)
        Me.tbNak1F.TabIndex = 433
        Me.tbNak1F.Text = "0"
        Me.tbNak1F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak2F
        '
        Me.tbNak2F.BackColor = System.Drawing.Color.LightPink
        Me.tbNak2F.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak2F.Location = New System.Drawing.Point(8, 808)
        Me.tbNak2F.MaxLength = 18
        Me.tbNak2F.Name = "tbNak2F"
        Me.tbNak2F.Size = New System.Drawing.Size(96, 20)
        Me.tbNak2F.TabIndex = 434
        Me.tbNak2F.Text = "0"
        Me.tbNak2F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak4F
        '
        Me.tbNak4F.BackColor = System.Drawing.Color.LightPink
        Me.tbNak4F.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak4F.Location = New System.Drawing.Point(8, 840)
        Me.tbNak4F.MaxLength = 18
        Me.tbNak4F.Name = "tbNak4F"
        Me.tbNak4F.Size = New System.Drawing.Size(96, 20)
        Me.tbNak4F.TabIndex = 436
        Me.tbNak4F.Text = "0"
        Me.tbNak4F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak3F
        '
        Me.tbNak3F.BackColor = System.Drawing.Color.LightPink
        Me.tbNak3F.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak3F.Location = New System.Drawing.Point(8, 824)
        Me.tbNak3F.MaxLength = 18
        Me.tbNak3F.Name = "tbNak3F"
        Me.tbNak3F.Size = New System.Drawing.Size(96, 20)
        Me.tbNak3F.TabIndex = 435
        Me.tbNak3F.Text = "0"
        Me.tbNak3F.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTugF
        '
        Me.tbTugF.BackColor = System.Drawing.Color.LightPink
        Me.tbTugF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbTugF.Location = New System.Drawing.Point(8, 880)
        Me.tbTugF.MaxLength = 18
        Me.tbTugF.Name = "tbTugF"
        Me.tbTugF.Size = New System.Drawing.Size(96, 20)
        Me.tbTugF.TabIndex = 437
        Me.tbTugF.Text = "0"
        Me.tbTugF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTugU
        '
        Me.tbTugU.BackColor = System.Drawing.Color.LightPink
        Me.tbTugU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbTugU.Location = New System.Drawing.Point(636, 880)
        Me.tbTugU.MaxLength = 18
        Me.tbTugU.Name = "tbTugU"
        Me.tbTugU.Size = New System.Drawing.Size(96, 20)
        Me.tbTugU.TabIndex = 442
        Me.tbTugU.Text = "0"
        Me.tbTugU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak4U
        '
        Me.tbNak4U.BackColor = System.Drawing.Color.LightPink
        Me.tbNak4U.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak4U.Location = New System.Drawing.Point(636, 840)
        Me.tbNak4U.MaxLength = 18
        Me.tbNak4U.Name = "tbNak4U"
        Me.tbNak4U.Size = New System.Drawing.Size(96, 20)
        Me.tbNak4U.TabIndex = 441
        Me.tbNak4U.Text = "0"
        Me.tbNak4U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak3U
        '
        Me.tbNak3U.BackColor = System.Drawing.Color.LightPink
        Me.tbNak3U.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak3U.Location = New System.Drawing.Point(636, 824)
        Me.tbNak3U.MaxLength = 18
        Me.tbNak3U.Name = "tbNak3U"
        Me.tbNak3U.Size = New System.Drawing.Size(96, 20)
        Me.tbNak3U.TabIndex = 440
        Me.tbNak3U.Text = "0"
        Me.tbNak3U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak2U
        '
        Me.tbNak2U.BackColor = System.Drawing.Color.LightPink
        Me.tbNak2U.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak2U.Location = New System.Drawing.Point(636, 808)
        Me.tbNak2U.MaxLength = 18
        Me.tbNak2U.Name = "tbNak2U"
        Me.tbNak2U.Size = New System.Drawing.Size(96, 20)
        Me.tbNak2U.TabIndex = 439
        Me.tbNak2U.Text = "0"
        Me.tbNak2U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbNak1U
        '
        Me.tbNak1U.BackColor = System.Drawing.Color.LightPink
        Me.tbNak1U.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNak1U.Location = New System.Drawing.Point(636, 792)
        Me.tbNak1U.MaxLength = 18
        Me.tbNak1U.Name = "tbNak1U"
        Me.tbNak1U.Size = New System.Drawing.Size(96, 20)
        Me.tbNak1U.TabIndex = 438
        Me.tbNak1U.Text = "0"
        Me.tbNak1U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR8
        '
        Me.tbR8.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR20a.BackColor = System.Drawing.Color.LightPink
        Me.tbR20a.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR20a.Location = New System.Drawing.Point(691, 184)
        Me.tbR20a.Name = "tbR20a"
        Me.tbR20a.Size = New System.Drawing.Size(41, 18)
        Me.tbR20a.TabIndex = 444
        Me.tbR20a.Text = ""
        '
        'tbR20b
        '
        Me.tbR20b.BackColor = System.Drawing.Color.LightPink
        Me.tbR20b.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR20b.Location = New System.Drawing.Point(691, 200)
        Me.tbR20b.Name = "tbR20b"
        Me.tbR20b.Size = New System.Drawing.Size(41, 18)
        Me.tbR20b.TabIndex = 445
        Me.tbR20b.Text = ""
        '
        'tbR7
        '
        Me.tbR7.BackColor = System.Drawing.Color.LightPink
        Me.tbR7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR7.Location = New System.Drawing.Point(716, 11)
        Me.tbR7.Name = "tbR7"
        Me.tbR7.Size = New System.Drawing.Size(16, 18)
        Me.tbR7.TabIndex = 447
        Me.tbR7.Text = ""
        '
        'tbSumaOsovina
        '
        Me.tbSumaOsovina.BackColor = System.Drawing.Color.LightPink
        Me.tbSumaOsovina.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaOsovina.Location = New System.Drawing.Point(707, 312)
        Me.tbSumaOsovina.Name = "tbSumaOsovina"
        Me.tbSumaOsovina.Size = New System.Drawing.Size(25, 18)
        Me.tbSumaOsovina.TabIndex = 450
        Me.tbSumaOsovina.Text = ""
        '
        'tbSumaKola
        '
        Me.tbSumaKola.BackColor = System.Drawing.Color.LightPink
        Me.tbSumaKola.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbSumaKola.Location = New System.Drawing.Point(669, 312)
        Me.tbSumaKola.Name = "tbSumaKola"
        Me.tbSumaKola.Size = New System.Drawing.Size(25, 18)
        Me.tbSumaKola.TabIndex = 449
        Me.tbSumaKola.Text = ""
        '
        'tbR18
        '
        Me.tbR18.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR19.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR68b.BackColor = System.Drawing.Color.LightPink
        Me.tbR68b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR68b.Location = New System.Drawing.Point(400, 1008)
        Me.tbR68b.MaxLength = 20
        Me.tbR68b.Name = "tbR68b"
        Me.tbR68b.Size = New System.Drawing.Size(120, 20)
        Me.tbR68b.TabIndex = 453
        Me.tbR68b.Text = "0"
        Me.tbR68b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 225
        Me.Label1.Text = "Ulazna"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(137, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 23)
        Me.Label2.TabIndex = 227
        Me.Label2.Text = "Izlazna"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.DarkGray
        Me.GroupBox2.Controls.Add(Me.tbKm2)
        Me.GroupBox2.Controls.Add(Me.tbKm1)
        Me.GroupBox2.Controls.Add(Me.cbZsPrevozniPut)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(856, 664)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(24, 32)
        Me.GroupBox2.TabIndex = 228
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ PREVOZNI PUT ŽS ]"
        Me.GroupBox2.Visible = False
        '
        'tbKm2
        '
        Me.tbKm2.Enabled = False
        Me.tbKm2.Location = New System.Drawing.Point(200, 8)
        Me.tbKm2.Name = "tbKm2"
        Me.tbKm2.Size = New System.Drawing.Size(14, 21)
        Me.tbKm2.TabIndex = 5
        Me.tbKm2.Text = ""
        Me.tbKm2.Visible = False
        '
        'tbKm1
        '
        Me.tbKm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbKm1.Location = New System.Drawing.Point(160, 25)
        Me.tbKm1.Name = "tbKm1"
        Me.tbKm1.Size = New System.Drawing.Size(51, 20)
        Me.tbKm1.TabIndex = 4
        Me.tbKm1.Text = ""
        '
        'cbZsPrevozniPut
        '
        Me.cbZsPrevozniPut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbZsPrevozniPut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbZsPrevozniPut.Items.AddRange(New Object() {"Redovan", "Vanredan", "Lomljen redovan", "Lomljen vanredan"})
        Me.cbZsPrevozniPut.Location = New System.Drawing.Point(8, 24)
        Me.cbZsPrevozniPut.Name = "cbZsPrevozniPut"
        Me.cbZsPrevozniPut.Size = New System.Drawing.Size(144, 21)
        Me.cbZsPrevozniPut.TabIndex = 2
        '
        'tbPrevoznina
        '
        Me.tbPrevoznina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrevoznina.Location = New System.Drawing.Point(8, 16)
        Me.tbPrevoznina.Name = "tbPrevoznina"
        Me.tbPrevoznina.Size = New System.Drawing.Size(64, 22)
        Me.tbPrevoznina.TabIndex = 232
        Me.tbPrevoznina.Text = "0"
        Me.tbPrevoznina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbSaobracaj
        '
        Me.gbSaobracaj.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gbSaobracaj.Controls.Add(Me.rbKolska)
        Me.gbSaobracaj.Controls.Add(Me.rbDencana)
        Me.gbSaobracaj.Location = New System.Drawing.Point(888, 536)
        Me.gbSaobracaj.Name = "gbSaobracaj"
        Me.gbSaobracaj.Size = New System.Drawing.Size(48, 37)
        Me.gbSaobracaj.TabIndex = 235
        Me.gbSaobracaj.TabStop = False
        Me.gbSaobracaj.Text = " [ POSILJKA ]  "
        Me.gbSaobracaj.Visible = False
        '
        'rbKolska
        '
        Me.rbKolska.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.rbKolska.Checked = True
        Me.rbKolska.Location = New System.Drawing.Point(5, 22)
        Me.rbKolska.Name = "rbKolska"
        Me.rbKolska.Size = New System.Drawing.Size(86, 21)
        Me.rbKolska.TabIndex = 26
        Me.rbKolska.TabStop = True
        Me.rbKolska.Text = "K o l s k a "
        Me.rbKolska.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(6, 133)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(58, 21)
        Me.tbUgovor.TabIndex = 3
        Me.tbUgovor.Text = ""
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.Items.AddRange(New Object() {"1. Pojedinacna", "2. Grupa kola", "3. Voz"})
        Me.ComboBox2.Location = New System.Drawing.Point(64, 132)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(152, 23)
        Me.ComboBox2.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(92, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "Nacin prevoza"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
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
        Me.ComboBox4.Items.AddRange(New Object() {"0 Unutrasnji saobracaj", "1 Uvoz reekspedicija", "2 Izvoz reekspedicija", "3 Lucki uvoz", "4 Lucki izvoz", "5 Recni uvoz", "6 Recni izvoz", "8 Uvoz zeleznica-drum", "9 Izvoz zeleznica-drum"})
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
        Me.ComboBox3.Items.AddRange(New Object() {"00 Redovan prevoz", "39 Mesoviti vojni transport - clan 45, tacka 4", "40 Mesoviti vojni transport - clan 45, tacka 6", "42 Pokrivaci i nosaci pokrivaca vlasnistvo korisnika prevoza - clan 51, tacka 11", "43 Ostali tovarni pribor vlasnistvo korisnika prevoza - clan 52, tacka 9", "44 Spec. kola za prevoz plina (gasa) u gasovitom stanju clan 55, tacka 2", "45 Prazna kola korisnika prevoza sa masinama za hladjenje  clan 56, t 6. i clan 3" & _
        "9, t 8", "46 Posiljaocev marsutni voz - clan 57, tacka 1", "47 Posiljaocev marsutni voz - clan 57, tacka 5", "48 Poseban voz - clan 58, tacka 5", "49 Grupa kola - clan 59, tacka 4", "50 Vracanje pretega u otpravnu stanicu cl.63 tac.1 pod b", "99 Posiljke koje se besplatno prevoze"})
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
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox3.Controls.Add(Me.tbUlaznaNalepnica)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.tbIzlaznaNalepnica)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(904, 576)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(40, 24)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " [ TRANZITNE NALEPNICE ]"
        Me.GroupBox3.Visible = False
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox10.Controls.Add(Me.cbSmer1)
        Me.GroupBox10.Controls.Add(Me.cbSmer2)
        Me.GroupBox10.Controls.Add(Me.Label33)
        Me.GroupBox10.Controls.Add(Me.Label32)
        Me.GroupBox10.Location = New System.Drawing.Point(952, 568)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(32, 16)
        Me.GroupBox10.TabIndex = 2
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "[ IZBOR PRAVCA ]"
        Me.GroupBox10.Visible = False
        '
        'cbSmer1
        '
        Me.cbSmer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer1.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer1.Location = New System.Drawing.Point(6, 21)
        Me.cbSmer1.Name = "cbSmer1"
        Me.cbSmer1.Size = New System.Drawing.Size(210, 23)
        Me.cbSmer1.TabIndex = 1
        '
        'cbSmer2
        '
        Me.cbSmer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSmer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSmer2.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 16201 Beograd Ranzirna", "10- 25471 Bogojevo"})
        Me.cbSmer2.Location = New System.Drawing.Point(6, 59)
        Me.cbSmer2.Name = "cbSmer2"
        Me.cbSmer2.Size = New System.Drawing.Size(210, 23)
        Me.cbSmer2.TabIndex = 2
        '
        'Label33
        '
        Me.Label33.Enabled = False
        Me.Label33.Location = New System.Drawing.Point(142, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 13)
        Me.Label33.TabIndex = 47
        Me.Label33.Text = "Ulazni prelaz"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label32
        '
        Me.Label32.Enabled = False
        Me.Label32.Location = New System.Drawing.Point(142, 45)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(70, 15)
        Me.Label32.TabIndex = 46
        Me.Label32.Text = "Izlazni prelaz"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.BottomRight
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
        Me.dgError.Location = New System.Drawing.Point(888, 672)
        Me.dgError.Name = "dgError"
        Me.dgError.ParentRowsBackColor = System.Drawing.Color.White
        Me.dgError.ParentRowsForeColor = System.Drawing.Color.Black
        Me.dgError.PreferredColumnWidth = 230
        Me.dgError.SelectionBackColor = System.Drawing.Color.Navy
        Me.dgError.SelectionForeColor = System.Drawing.Color.White
        Me.dgError.Size = New System.Drawing.Size(16, 16)
        Me.dgError.TabIndex = 245
        Me.dgError.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.PaleGoldenrod
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
        Me.DatumOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOtp.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOtp.Location = New System.Drawing.Point(92, 78)
        Me.DatumOtp.Name = "DatumOtp"
        Me.DatumOtp.Size = New System.Drawing.Size(124, 22)
        Me.DatumOtp.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.Enabled = False
        Me.Label17.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label17.Location = New System.Drawing.Point(93, 65)
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
        Me.Label15.Location = New System.Drawing.Point(6, 65)
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
        Me.Label10.Location = New System.Drawing.Point(6, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 11)
        Me.Label10.TabIndex = 227
        Me.Label10.Text = "Stanica"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(8, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(200, 15)
        Me.Label12.TabIndex = 37
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(80, 25)
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
        Me.btnStanicaOtp.Location = New System.Drawing.Point(112, 25)
        Me.btnStanicaOtp.Name = "btnStanicaOtp"
        Me.btnStanicaOtp.Size = New System.Drawing.Size(24, 22)
        Me.btnStanicaOtp.TabIndex = 6
        Me.btnStanicaOtp.Text = "..."
        Me.btnStanicaOtp.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.LightSteelBlue
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
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(92, 83)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(124, 22)
        Me.DateTimePicker2.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.Enabled = False
        Me.Label20.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label20.Location = New System.Drawing.Point(95, 74)
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
        Me.Label21.Location = New System.Drawing.Point(6, 74)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 11)
        Me.Label21.TabIndex = 230
        Me.Label21.Text = "Broj"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label18
        '
        Me.Label18.Enabled = False
        Me.Label18.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 11)
        Me.Label18.TabIndex = 229
        Me.Label18.Text = "Stanica"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label13
        '
        Me.Label13.Enabled = False
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(8, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(200, 15)
        Me.Label13.TabIndex = 39
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnStanicaPr
        '
        Me.btnStanicaPr.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnStanicaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnStanicaPr.Location = New System.Drawing.Point(112, 28)
        Me.btnStanicaPr.Name = "btnStanicaPr"
        Me.btnStanicaPr.Size = New System.Drawing.Size(24, 22)
        Me.btnStanicaPr.TabIndex = 33
        Me.btnStanicaPr.Text = "..."
        Me.btnStanicaPr.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(80, 28)
        Me.TextBox2.MaxLength = 1
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(15, 22)
        Me.TextBox2.TabIndex = 52
        Me.TextBox2.Text = ""
        Me.TextBox2.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox6.Controls.Add(Me.tbPrevoznina)
        Me.GroupBox6.Enabled = False
        Me.GroupBox6.Location = New System.Drawing.Point(781, 480)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(216, 32)
        Me.GroupBox6.TabIndex = 247
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = " Prevoznina                        Naknade "
        Me.GroupBox6.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox7.Controls.Add(Me.RadioButton2)
        Me.GroupBox7.Controls.Add(Me.RadioButton1)
        Me.GroupBox7.Controls.Add(Me.RadioButton3)
        Me.GroupBox7.Location = New System.Drawing.Point(944, 536)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(40, 29)
        Me.GroupBox7.TabIndex = 248
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = " [ POSILJKA ]  "
        Me.GroupBox7.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton2.Location = New System.Drawing.Point(20, 31)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(86, 24)
        Me.RadioButton2.TabIndex = 27
        Me.RadioButton2.Text = "U v o z"
        '
        'RadioButton1
        '
        Me.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(20, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(86, 24)
        Me.RadioButton1.TabIndex = 26
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "T r a n z i t"
        Me.RadioButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'RadioButton3
        '
        Me.RadioButton3.CheckAlign = System.Drawing.ContentAlignment.BottomRight
        Me.RadioButton3.Location = New System.Drawing.Point(20, 55)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(86, 15)
        Me.RadioButton3.TabIndex = 28
        Me.RadioButton3.Text = "I z v o z"
        Me.RadioButton3.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'gbPrevozniPut
        '
        Me.gbPrevozniPut.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gbPrevozniPut.Controls.Add(Me.cmbPrevPut)
        Me.gbPrevozniPut.Controls.Add(Me.lblPP)
        Me.gbPrevozniPut.Location = New System.Drawing.Point(780, 432)
        Me.gbPrevozniPut.Name = "gbPrevozniPut"
        Me.gbPrevozniPut.Size = New System.Drawing.Size(220, 48)
        Me.gbPrevozniPut.TabIndex = 312
        Me.gbPrevozniPut.TabStop = False
        Me.gbPrevozniPut.Text = " PREVOZNI PUT UIC"
        Me.gbPrevozniPut.Visible = False
        '
        'lblPP
        '
        Me.lblPP.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.lblPP.Location = New System.Drawing.Point(176, 8)
        Me.lblPP.Name = "lblPP"
        Me.lblPP.Size = New System.Drawing.Size(40, 16)
        Me.lblPP.TabIndex = 312
        Me.lblPP.Text = "err"
        Me.lblPP.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(276, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 372
        Me.Label3.Text = "Kontrolni broj"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.PapayaWhip
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(258, 105)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 371
        Me.PictureBox3.TabStop = False
        '
        'tbR21_1
        '
        Me.tbR21_1.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR21_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR21_1.Location = New System.Drawing.Point(356, 242)
        Me.tbR21_1.MaxLength = 12
        Me.tbR21_1.Name = "tbR21_1"
        Me.tbR21_1.Size = New System.Drawing.Size(32, 20)
        Me.tbR21_1.TabIndex = 368
        Me.tbR21_1.Text = ""
        Me.tbR21_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox6
        '
        Me.CheckBox6.BackColor = System.Drawing.Color.White
        Me.CheckBox6.Location = New System.Drawing.Point(406, 967)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(16, 16)
        Me.CheckBox6.TabIndex = 366
        '
        'CheckBox7
        '
        Me.CheckBox7.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox7.Checked = True
        Me.CheckBox7.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox7.Location = New System.Drawing.Point(595, 345)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(16, 17)
        Me.CheckBox7.TabIndex = 358
        '
        'CheckBox5
        '
        Me.CheckBox5.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox5.Location = New System.Drawing.Point(516, 345)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(16, 17)
        Me.CheckBox5.TabIndex = 357
        '
        'cbR6
        '
        Me.cbR6.BackColor = System.Drawing.Color.Transparent
        Me.cbR6.Location = New System.Drawing.Point(646, 40)
        Me.cbR6.Name = "cbR6"
        Me.cbR6.Size = New System.Drawing.Size(16, 17)
        Me.cbR6.TabIndex = 351
        '
        'cbR5D
        '
        Me.cbR5D.BackColor = System.Drawing.Color.Transparent
        Me.cbR5D.Location = New System.Drawing.Point(528, 47)
        Me.cbR5D.Name = "cbR5D"
        Me.cbR5D.Size = New System.Drawing.Size(16, 17)
        Me.cbR5D.TabIndex = 350
        '
        'cbR5O
        '
        Me.cbR5O.BackColor = System.Drawing.Color.Transparent
        Me.cbR5O.Location = New System.Drawing.Point(528, 31)
        Me.cbR5O.Name = "cbR5O"
        Me.cbR5O.Size = New System.Drawing.Size(16, 17)
        Me.cbR5O.TabIndex = 349
        '
        'cbR5R
        '
        Me.cbR5R.BackColor = System.Drawing.Color.Transparent
        Me.cbR5R.Checked = True
        Me.cbR5R.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbR5R.Location = New System.Drawing.Point(528, 15)
        Me.cbR5R.Name = "cbR5R"
        Me.cbR5R.Size = New System.Drawing.Size(16, 17)
        Me.cbR5R.TabIndex = 348
        '
        'cbR4D
        '
        Me.cbR4D.BackColor = System.Drawing.Color.Transparent
        Me.cbR4D.Location = New System.Drawing.Point(408, 40)
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
        Me.CheckBox4.BackColor = System.Drawing.Color.White
        Me.CheckBox4.Location = New System.Drawing.Point(335, 663)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(129, 16)
        Me.CheckBox4.TabIndex = 345
        Me.CheckBox4.Text = " 4 Franko iznos"
        '
        'CheckBox3
        '
        Me.CheckBox3.BackColor = System.Drawing.Color.White
        Me.CheckBox3.Location = New System.Drawing.Point(336, 640)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(152, 16)
        Me.CheckBox3.TabIndex = 344
        Me.CheckBox3.Text = " 3 Franko prevoznina"
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.White
        Me.CheckBox2.Location = New System.Drawing.Point(16, 664)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(176, 16)
        Me.CheckBox2.TabIndex = 343
        Me.CheckBox2.Text = " 2 Franko prevoznina ukljucivo"
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.White
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(16, 640)
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
        Me.tbKolauVozu.Location = New System.Drawing.Point(444, 230)
        Me.tbKolauVozu.MaxLength = 4
        Me.tbKolauVozu.Name = "tbKolauVozu"
        Me.tbKolauVozu.Size = New System.Drawing.Size(24, 11)
        Me.tbKolauVozu.TabIndex = 53
        Me.tbKolauVozu.Text = ""
        Me.tbKolauVozu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rtbR34
        '
        Me.rtbR34.BackColor = System.Drawing.Color.LemonChiffon
        Me.rtbR34.Location = New System.Drawing.Point(8, 433)
        Me.rtbR34.Name = "rtbR34"
        Me.rtbR34.Size = New System.Drawing.Size(250, 52)
        Me.rtbR34.TabIndex = 319
        Me.rtbR34.Text = ""
        '
        'rtbR27
        '
        Me.rtbR27.BackColor = System.Drawing.Color.LemonChiffon
        Me.rtbR27.Location = New System.Drawing.Point(56, 256)
        Me.rtbR27.Name = "rtbR27"
        Me.rtbR27.Size = New System.Drawing.Size(288, 104)
        Me.rtbR27.TabIndex = 301
        Me.rtbR27.Text = ""
        '
        'rtb37
        '
        Me.rtb37.BackColor = System.Drawing.Color.LemonChiffon
        Me.rtb37.Location = New System.Drawing.Point(8, 506)
        Me.rtb37.Name = "rtb37"
        Me.rtb37.Size = New System.Drawing.Size(608, 94)
        Me.rtb37.TabIndex = 300
        Me.rtb37.Text = ""
        '
        'tb20a
        '
        Me.tb20a.BackColor = System.Drawing.Color.LemonChiffon
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
        Me.tb20d.BackColor = System.Drawing.Color.LemonChiffon
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
        Me.tb20c.BackColor = System.Drawing.Color.LemonChiffon
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
        Me.tb20b.BackColor = System.Drawing.Color.LemonChiffon
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
        Me.cbR4K.Location = New System.Drawing.Point(408, 24)
        Me.cbR4K.Name = "cbR4K"
        Me.cbR4K.Size = New System.Drawing.Size(16, 17)
        Me.cbR4K.TabIndex = 38
        '
        'tbIBK
        '
        Me.tbIBK.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbIBK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIBK.Location = New System.Drawing.Point(392, 242)
        Me.tbIBK.MaxLength = 12
        Me.tbIBK.Name = "tbIBK"
        Me.tbIBK.Size = New System.Drawing.Size(88, 20)
        Me.tbIBK.TabIndex = 36
        Me.tbIBK.Text = ""
        Me.tbIBK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbControl
        '
        Me.tbControl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbControl.Enabled = False
        Me.tbControl.ForeColor = System.Drawing.Color.Silver
        Me.tbControl.Location = New System.Drawing.Point(16, 1016)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.Size = New System.Drawing.Size(128, 13)
        Me.tbControl.TabIndex = 0
        Me.tbControl.Text = "UTL/WEB2ZS"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.PapayaWhip
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
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
        Me.Panel1.Controls.Add(Me.tbCtrlNum)
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
        Me.Panel1.Controls.Add(Me.tbIBK_4)
        Me.Panel1.Controls.Add(Me.tbR21_3)
        Me.Panel1.Controls.Add(Me.tbIBK_3)
        Me.Panel1.Controls.Add(Me.tbR21_2)
        Me.Panel1.Controls.Add(Me.tbIBK_2)
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
        Me.Panel1.Controls.Add(Me.tbIBK)
        Me.Panel1.Controls.Add(Me.tbR17)
        Me.Panel1.Controls.Add(Me.tbR30Naziv)
        Me.Panel1.Controls.Add(Me.tbR30Sifra)
        Me.Panel1.Controls.Add(Me.tbR11)
        Me.Panel1.Controls.Add(Me.tbControl)
        Me.Panel1.Location = New System.Drawing.Point(9, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(768, 700)
        Me.Panel1.TabIndex = 6
        '
        'tbR43f
        '
        Me.tbR43f.BackColor = System.Drawing.Color.LightPink
        Me.tbR43f.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR43f.Location = New System.Drawing.Point(707, 584)
        Me.tbR43f.MaxLength = 2
        Me.tbR43f.Name = "tbR43f"
        Me.tbR43f.Size = New System.Drawing.Size(24, 18)
        Me.tbR43f.TabIndex = 482
        Me.tbR43f.Text = ""
        '
        'tbR43e
        '
        Me.tbR43e.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR43d.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR43c.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR43b.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR42f.BackColor = System.Drawing.Color.LightPink
        Me.tbR42f.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR42f.Location = New System.Drawing.Point(636, 584)
        Me.tbR42f.MaxLength = 6
        Me.tbR42f.Name = "tbR42f"
        Me.tbR42f.Size = New System.Drawing.Size(56, 18)
        Me.tbR42f.TabIndex = 477
        Me.tbR42f.Text = ""
        Me.tbR42f.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR42e
        '
        Me.tbR42e.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR42d.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR42c.BackColor = System.Drawing.Color.LightPink
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
        Me.tbR42b.BackColor = System.Drawing.Color.LightPink
        Me.tbR42b.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR42b.Location = New System.Drawing.Point(636, 522)
        Me.tbR42b.MaxLength = 6
        Me.tbR42b.Name = "tbR42b"
        Me.tbR42b.Size = New System.Drawing.Size(56, 18)
        Me.tbR42b.TabIndex = 473
        Me.tbR42b.Text = ""
        Me.tbR42b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR43a
        '
        Me.tbR43a.BackColor = System.Drawing.Color.LightPink
        Me.tbR43a.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR43a.Location = New System.Drawing.Point(707, 506)
        Me.tbR43a.MaxLength = 2
        Me.tbR43a.Name = "tbR43a"
        Me.tbR43a.Size = New System.Drawing.Size(24, 18)
        Me.tbR43a.TabIndex = 472
        Me.tbR43a.Text = ""
        '
        'tbR42a
        '
        Me.tbR42a.BackColor = System.Drawing.Color.LightPink
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
        Me.tbPdvIznosU.BackColor = System.Drawing.Color.LightPink
        Me.tbPdvIznosU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPdvIznosU.Location = New System.Drawing.Point(636, 856)
        Me.tbPdvIznosU.MaxLength = 18
        Me.tbPdvIznosU.Name = "tbPdvIznosU"
        Me.tbPdvIznosU.Size = New System.Drawing.Size(96, 20)
        Me.tbPdvIznosU.TabIndex = 470
        Me.tbPdvIznosU.Text = "0"
        Me.tbPdvIznosU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPdvIznosF
        '
        Me.tbPdvIznosF.BackColor = System.Drawing.Color.LightPink
        Me.tbPdvIznosF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPdvIznosF.Location = New System.Drawing.Point(8, 856)
        Me.tbPdvIznosF.MaxLength = 18
        Me.tbPdvIznosF.Name = "tbPdvIznosF"
        Me.tbPdvIznosF.Size = New System.Drawing.Size(96, 20)
        Me.tbPdvIznosF.TabIndex = 469
        Me.tbPdvIznosF.Text = "0"
        Me.tbPdvIznosF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb63b
        '
        Me.tb63b.BackColor = System.Drawing.Color.LightPink
        Me.tb63b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb63b.Location = New System.Drawing.Point(236, 880)
        Me.tb63b.MaxLength = 6
        Me.tb63b.Name = "tb63b"
        Me.tb63b.Size = New System.Drawing.Size(41, 20)
        Me.tb63b.TabIndex = 468
        Me.tb63b.Text = ""
        Me.tb63b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPDV
        '
        Me.tbPDV.BackColor = System.Drawing.Color.LightPink
        Me.tbPDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPDV.Location = New System.Drawing.Point(277, 856)
        Me.tbPDV.MaxLength = 40
        Me.tbPDV.Name = "tbPDV"
        Me.tbPDV.Size = New System.Drawing.Size(264, 20)
        Me.tbPDV.TabIndex = 467
        Me.tbPDV.Text = ""
        '
        'tbPDVU
        '
        Me.tbPDVU.BackColor = System.Drawing.Color.LightPink
        Me.tbPDVU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPDVU.Location = New System.Drawing.Point(236, 856)
        Me.tbPDVU.MaxLength = 6
        Me.tbPDVU.Name = "tbPDVU"
        Me.tbPDVU.Size = New System.Drawing.Size(41, 20)
        Me.tbPDVU.TabIndex = 466
        Me.tbPDVU.Text = ""
        Me.tbPDVU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPDVF
        '
        Me.tbPDVF.BackColor = System.Drawing.Color.LightPink
        Me.tbPDVF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPDVF.Location = New System.Drawing.Point(196, 856)
        Me.tbPDVF.MaxLength = 2
        Me.tbPDVF.Name = "tbPDVF"
        Me.tbPDVF.Size = New System.Drawing.Size(40, 20)
        Me.tbPDVF.TabIndex = 465
        Me.tbPDVF.Text = ""
        Me.tbPDVF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(280, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 40)
        Me.Label4.TabIndex = 464
        Me.Label4.Text = "1"
        '
        'rtbR16
        '
        Me.rtbR16.BackColor = System.Drawing.Color.LemonChiffon
        Me.rtbR16.Location = New System.Drawing.Point(56, 164)
        Me.rtbR16.Name = "rtbR16"
        Me.rtbR16.Size = New System.Drawing.Size(192, 80)
        Me.rtbR16.TabIndex = 457
        Me.rtbR16.Text = ""
        '
        'rtbR10
        '
        Me.rtbR10.BackColor = System.Drawing.Color.LemonChiffon
        Me.rtbR10.Location = New System.Drawing.Point(56, 71)
        Me.rtbR10.Name = "rtbR10"
        Me.rtbR10.Size = New System.Drawing.Size(192, 80)
        Me.rtbR10.TabIndex = 456
        Me.rtbR10.Text = ""
        '
        'tbR21_4
        '
        Me.tbR21_4.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR21_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR21_4.Location = New System.Drawing.Point(356, 292)
        Me.tbR21_4.MaxLength = 12
        Me.tbR21_4.Name = "tbR21_4"
        Me.tbR21_4.Size = New System.Drawing.Size(32, 20)
        Me.tbR21_4.TabIndex = 396
        Me.tbR21_4.Text = ""
        Me.tbR21_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbIBK_4
        '
        Me.tbIBK_4.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbIBK_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIBK_4.Location = New System.Drawing.Point(392, 292)
        Me.tbIBK_4.MaxLength = 12
        Me.tbIBK_4.Name = "tbIBK_4"
        Me.tbIBK_4.Size = New System.Drawing.Size(88, 20)
        Me.tbIBK_4.TabIndex = 395
        Me.tbIBK_4.Text = ""
        Me.tbIBK_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR21_3
        '
        Me.tbR21_3.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR21_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR21_3.Location = New System.Drawing.Point(356, 276)
        Me.tbR21_3.MaxLength = 12
        Me.tbR21_3.Name = "tbR21_3"
        Me.tbR21_3.Size = New System.Drawing.Size(32, 20)
        Me.tbR21_3.TabIndex = 394
        Me.tbR21_3.Text = ""
        Me.tbR21_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbIBK_3
        '
        Me.tbIBK_3.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbIBK_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIBK_3.Location = New System.Drawing.Point(392, 276)
        Me.tbIBK_3.MaxLength = 12
        Me.tbIBK_3.Name = "tbIBK_3"
        Me.tbIBK_3.Size = New System.Drawing.Size(88, 20)
        Me.tbIBK_3.TabIndex = 393
        Me.tbIBK_3.Text = ""
        Me.tbIBK_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbR21_2
        '
        Me.tbR21_2.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbR21_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbR21_2.Location = New System.Drawing.Point(356, 260)
        Me.tbR21_2.MaxLength = 12
        Me.tbR21_2.Name = "tbR21_2"
        Me.tbR21_2.Size = New System.Drawing.Size(32, 20)
        Me.tbR21_2.TabIndex = 392
        Me.tbR21_2.Text = ""
        Me.tbR21_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbIBK_2
        '
        Me.tbIBK_2.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbIBK_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIBK_2.Location = New System.Drawing.Point(392, 260)
        Me.tbIBK_2.MaxLength = 12
        Me.tbIBK_2.Name = "tbIBK_2"
        Me.tbIBK_2.Size = New System.Drawing.Size(88, 20)
        Me.tbIBK_2.TabIndex = 391
        Me.tbIBK_2.Text = ""
        Me.tbIBK_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'FormUTL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(954, 477)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnKalk)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.dgError)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.gbPrevozniPut)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.btnUpis)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbSaobracaj)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUTL"
        Me.Text = "UTL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.gbSaobracaj.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.dgError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.gbPrevozniPut.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
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
    ''Private Sub tbStanicaOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaOtp.Validating
    ''    If Len(tbStanicaOtp.Text) < 7 Then
    ''        ErrorProvider1.SetError(tbStanicaOtp, "Neispravna sifra stanice!")
    ''    Else
    ''        Dim xNaziv As String = ""
    ''        Dim xKB As String = ""
    ''        Dim xZemlja As String = ""
    ''        Dim xPovVrednost As String = ""

    ''        Util.sNadjiStanicu("UicStanice", tbStanicaOtp.Text, "", "", mBrojPokusaja, xNaziv, xKB, xZemlja, xPovVrednost)
    ''        If xPovVrednost <> "" Then
    ''            If mBrojPokusaja > 3 Then
    ''                mBrojPokusaja = 1
    ''                Label12.Text = "Nepostojeca sifra stanice"
    ''                mOtpStanica = tbStanicaOtp.Text
    ''                Me.tbStanicaOtp.BackColor = System.Drawing.Color.Red
    ''                ErrorProvider1.SetError(TextBox1, "")
    ''            Else
    ''                mBrojPokusaja = mBrojPokusaja + 1
    ''                ErrorProvider1.SetError(TextBox1, "Nepostojeca stanica!")
    ''                tbStanicaOtp.Focus()
    ''            End If
    ''        Else
    ''            ''zbog 3009!
    ''            ''If Microsoft.VisualBasic.Right(Me.tbUpravaOtp.Text, 2) <> Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2) Then
    ''            ''    mBrojPokusaja = mBrojPokusaja + 1
    ''            ''    ErrorProvider1.SetError(TextBox1, "Sifre nisu uskladjene!")

    ''            ''    tbUpravaOtp.Focus()
    ''            ''Else
    ''            ''    mBrojPokusaja = 1
    ''            ''    Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
    ''            ''    Label12.Text = xNaziv
    ''            ''    mOtpStanica = tbStanicaOtp.Text

    ''            ''    Me.tb16a.Text = xNaziv
    ''            ''    Me.tb16b.Text = xZemlja
    ''            ''    Me.tb17.Text = tbStanicaOtp.Text + TextBox1.Text
    ''            ''    Me.tb29a.Text = xNaziv
    ''            ''    tbA70a1.Text = "72"

    ''            ''    Me.TextBox1.Text = xKB
    ''            ''    ErrorProvider1.SetError(TextBox1, "")
    ''            ''    mOtpUprava = Microsoft.VisualBasic.Mid(mOtpStanica, 1, 2)
    ''            ''End If

    ''            mBrojPokusaja = 1
    ''            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
    ''            Label12.Text = xNaziv
    ''            mOtpStanica = tbStanicaOtp.Text

    ''            If eRazmena = "Da" Then

    ''            Else
    ''                Me.tb16a.Text = xNaziv
    ''                Me.tb16b.Text = xZemlja
    ''                Me.tb17.Text = tbStanicaOtp.Text + TextBox1.Text
    ''                Me.tb29a.Text = xNaziv
    ''                tbA70a1.Text = "72"
    ''            End If

    ''            Me.TextBox1.Text = xKB
    ''            ErrorProvider1.SetError(TextBox1, "")
    ''            mOtpUprava = Microsoft.VisualBasic.Mid(mOtpStanica, 1, 2)
    ''        End If
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

    ''Private Sub tbStanicaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaOtp.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

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

    ''Private Sub DatumOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumOtp.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub DatumOtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.LostFocus
    ''    mOtpDatum = DatumOtp.Text
    ''End Sub

    Private Sub DatumOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DatumOtp.Validating
        ''Dim mRetVal As String
        ''Dim mRecID As Int32
        ''Dim mStanicaRecID As String
        ''Dim strOtpBroj As String = CType(tbBrojOtp.Text, String) '& CType(kbBrojOtp.Text, String)

        ''mOtpDatum = Me.DatumOtp.Value.ToShortDateString
        ''mMesec = mOtpDatum.Month.ToString
        ''mDan = mOtpDatum.Day.ToString
        ''mGodina = mOtpDatum.Year.ToString

        ''NadjiTL1("72", tbStanicaOtp.Text, CType(strOtpBroj, Int32), mOtpDatum, mRecID, mStanicaRecID, mRetVal)
        ''''NadjiTL1(tbUpravaOtp.Text, tbStanicaOtp.Text, tbBrojOtp.Text, mOtpDatum, mRecID, mStanicaRecID, mRetVal)

        ''If mRetVal = "" Then
        ''    mDatumKalk = DatumOtp.Value
        ''    mOtpDatum = DatumOtp.Text

        ''    If IzborSaobracaja = "1" Then
        ''        Me.tbStanicaPr.Focus()
        ''    End If
        ''Else
        ''    tbBrojOtp.Focus()
        ''End If
    End Sub

    ''Private Sub tbUpravaPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUpravaPr.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbUpravaPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUpravaPr.Validating
    ''    Dim xNaziv As String = ""
    ''    Dim xPovVrednost As String = ""

    ''    Util.sNadjiNaziv("UicOperateri", tbUpravaPr.Text, "", "", 1, xNaziv, xPovVrednost)
    ''    'Util.sNadjiNaziv("UicOperateri", Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 1, 2), Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2), "", 1, xNaziv, xPovVrednost)

    ''    If xPovVrednost <> "" Then
    ''        ErrorProvider1.SetError(tbUpravaPr, "Nepostojeca uprava!")
    ''        tbUpravaPr.Focus()
    ''    Else
    ''        If tbUpravaOtp.Text = tbUpravaPr.Text Then
    ''            ErrorProvider1.SetError(tbUpravaPr, "Otpravna i uputna uprava moraju biti razlicite!")
    ''            tbUpravaPr.Focus()
    ''        Else
    ''            Label14.Text = Microsoft.VisualBasic.Mid(xNaziv, 3, Len(xNaziv))
    ''            mPrUprava = Microsoft.VisualBasic.Left(xNaziv, 2)

    ''            If Len(tbStanicaPr.Text) = 7 Then

    ''            Else
    ''                tbStanicaPr.Text = mPrUprava
    ''                tbStanicaPr.SelectionStart = 3
    ''            End If
    ''            ErrorProvider1.SetError(tbUpravaPr, "")

    ''        End If
    ''    End If
    ''End Sub

    ''Private Sub tbStanicaPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaPr.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbStanicaPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.Leave
    ''    Me.tbStanicaPr.BackColor = System.Drawing.Color.White
    ''    Me.tbStanicaPr.ForeColor = System.Drawing.Color.Black

    ''    If Len(tbStanicaPr.Text) < 7 Then
    ''        ErrorProvider1.SetError(Me.TextBox2, "Neispravna sifra stanice!")
    ''        tbStanicaPr.Focus()
    ''    Else
    ''        ErrorProvider1.SetError(Me.TextBox2, "")
    ''        If IzborSaobracaja = "2" Then
    ''            Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
    ''            Me.tbA70b2.Text = Microsoft.VisualBasic.Right(Me.tbStanicaPr.Text, 5)
    ''        ElseIf IzborSaobracaja = "3" Then
    ''            Me.tbA70b1.Text = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5)
    ''            Me.tbA70b2.Text = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
    ''        ElseIf IzborSaobracaja = "4" Then
    ''            Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
    ''            Me.tbA70b2.Text = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
    ''        End If
    ''        Daljinar()

    ''        If IzborSaobracaja = "3" Then
    ''            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then
    ''                Me.gbPrevozniPut.Enabled = False
    ''                Me.cbR57.Enabled = False
    ''                Me.tbsBrojVoza.Focus()
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "53" Then
    ''                Me.gbPrevozniPut.Enabled = False
    ''                Me.cbR57.Enabled = False
    ''                Me.tbsBrojVoza.Focus()
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Then
    ''                Me.gbPrevozniPut.Enabled = False
    ''                Me.cbR57.Enabled = False
    ''                Me.tbsBrojVoza.Focus()
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65" Then
    ''                Me.gbPrevozniPut.Enabled = False
    ''                Me.cbR57.Enabled = False
    ''                Me.tbsBrojVoza.Focus()
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62" Then
    ''                Me.gbPrevozniPut.Enabled = False
    ''                Me.cbR57.Enabled = False
    ''                Me.tbsBrojVoza.Focus()
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44" Then
    ''                Me.gbPrevozniPut.Enabled = False
    ''                Me.cbR57.Enabled = False
    ''                Me.tbsBrojVoza.Focus()
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
    ''                Me.gbPrevozniPut.Enabled = False
    ''                Me.cbR57.Enabled = False
    ''                Me.tbsBrojVoza.Focus()
    ''            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
    ''                Me.gbPrevozniPut.Enabled = False
    ''                Me.cbR57.Enabled = False
    ''                Me.tbsBrojVoza.Focus()
    ''            Else
    ''                If eCimDa = "D" Then
    ''                    Me.gbPrevozniPut.Enabled = True
    ''                    Me.cbR57.Enabled = True
    ''                    Me.cmbPrevPut.Focus()
    ''                Else
    ''                    Me.gbPrevozniPut.Enabled = False
    ''                    Me.cbR57.Enabled = False
    ''                    Me.tbsBrojVoza.Focus()
    ''                End If
    ''            End If
    ''        Else
    ''            If BlagajnaUnosa = Microsoft.VisualBasic.Right(Me.tbStanicaPr.Text, 5) Then
    ''                'Me.tbBrojPr.Focus()

    ''                Me.tbsBrojVoza.Focus()
    ''            Else
    ''                Me.tbBrojPr.Text = 0
    ''                Me.kbBrojPr.Text = 0

    ''                Me.tbsBrojVoza.Focus()
    ''            End If
    ''        End If

    ''    End If
    ''End Sub

    ''Private Sub tbStanicaPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaPr.Validating
    ''    If Len(tbStanicaPr.Text) < 7 Then
    ''        ErrorProvider1.SetError(tbStanicaPr, "Neispravna sifra stanice!")
    ''    Else
    ''        Dim xNaziv As String = ""
    ''        Dim xKB As String = ""
    ''        Dim xZemlja As String = ""
    ''        Dim xPovVrednost As String = ""

    ''        Util.sNadjiStanicu("UicStanice", tbStanicaPr.Text, "", "", mBrojPokusaja, xNaziv, xKB, xZemlja, xPovVrednost)

    ''        If xPovVrednost <> "" Then
    ''            If mBrojPokusaja > 3 Then
    ''                mBrojPokusaja = 1
    ''                Label13.Text = "Nepostojeca sifra stanice"
    ''                mPrStanica = tbStanicaPr.Text
    ''                Me.tbStanicaPr.BackColor = System.Drawing.Color.Red
    ''                ErrorProvider1.SetError(TextBox2, "")
    ''            Else
    ''                mBrojPokusaja = mBrojPokusaja + 1
    ''                ErrorProvider1.SetError(TextBox2, "Nepostojeca stanica!")
    ''                tbStanicaPr.Focus()
    ''            End If
    ''        Else
    ''            If Microsoft.VisualBasic.Right(Me.tbUpravaPr.Text, 2) <> Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) Then
    ''                mBrojPokusaja = mBrojPokusaja + 1
    ''                ErrorProvider1.SetError(TextBox2, "Sifre nisu iskladjene!")
    ''                tbUpravaPr.Focus()
    ''            Else
    ''                mBrojPokusaja = 1
    ''                Me.tbStanicaPr.BackColor = System.Drawing.Color.White
    ''                Label13.Text = xNaziv

    ''                If eRazmena = "Da" Then

    ''                Else
    ''                    tbA70a2.Text = "72"
    ''                    Me.tb10a.Text = xNaziv
    ''                    Me.tb10b.Text = xZemlja
    ''                    Me.tb12.Text = tbStanicaPr.Text
    ''                End If

    ''                '---
    ''                mPrStanica = tbStanicaPr.Text
    ''                Me.TextBox2.Text = xKB
    ''                ErrorProvider1.SetError(TextBox2, "")
    ''                mPrUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)

    ''                '---------------------
    ''                If IzborSaobracaja = "3" Then
    ''                    If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then
    ''                        Me.rtb57a.Items.Clear()
    ''                        Me.rtb57b.Items.Clear()
    ''                        Me.rtb57b2.Items.Clear()
    ''                        Me.rtb57c.Items.Clear()

    ''                        m_UicPrevozniPut = "55"
    ''                        Me.cmbPrevPut.Text = "55"
    ''                        Me.tb50.Text = "5511 SUBOTICA"
    ''                        'NizR50(0, 0) = 5511
    ''                        'NizR50(0, 1) = "KELEBIA"
    ''                        Me.rtb57a.Items.Add("2155 MAV Cargo")
    ''                        Me.rtb57b.Items.Add("550711")
    ''                        Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
    ''                        Me.rtb57c.Items.Add("1")

    ''                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "53" Then
    ''                        'Me.cmbPrevPut.Text = "53"
    ''                        'Me.tb50.Text = "5311 ST.MORAVITA"
    ''                        'Me.rtb57a.Items.Add("2153 CFR Marfa")
    ''                        'Me.rtb57b.Items.Add("530661")
    ''                        'Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
    ''                        'Me.rtb57c.Items.Add("1")

    ''                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Then
    ''                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65" Then
    ''                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62" Then
    ''                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44" Then
    ''                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
    ''                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
    ''                    Else
    ''                    End If
    ''                End If
    ''                '---------------
    ''            End If
    ''        End If
    ''    End If

    ''End Sub
    ''Private Sub Daljinar()
    ''    Dim sql_text As String

    ''    '---------------------------------------------------------------------------
    ''    If IzborSaobracaja = "1" Then
    ''        mStanica1 = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5)
    ''        mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
    ''    ElseIf IzborSaobracaja = "2" Then
    ''        mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
    ''        mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
    ''    ElseIf IzborSaobracaja = "3" Then
    ''        mStanica1 = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5)
    ''        mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
    ''    ElseIf IzborSaobracaja = "4" Then
    ''        mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
    ''        mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
    ''    End If


    ''    'If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then
    ''    '    If mVrstaPrevoza <> "P" Then ' grupa ili voz => moze da pozove najavu
    ''    '        'mStanica1 = cbSmer1.Text
    ''    '        'mStanica2 = cbSmer2.Text
    ''    '        mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
    ''    '        mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
    ''    '    Else
    ''    '        mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
    ''    '        mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
    ''    '    End If
    ''    'Else
    ''    '    mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
    ''    '    mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
    ''    'End If
    ''    '----------------------------------------------------------------------------
    ''    If Len(mStanica1) > 0 And Len(mStanica2) > 0 Then
    ''        If DbVeza.State = ConnectionState.Closed Then
    ''            DbVeza.Open()
    ''        End If

    ''        If Int(mStanica1) < Int(mStanica2) Then
    ''            sql_text = "SELECT TarifskiKm, StvarniKm " & _
    ''                                     "FROM dbo.ZsDaljinar " & _
    ''                                     "WHERE (Stanica1 = '" & mStanica1 & "') AND (Stanica2 = '" & mStanica2 & "')"

    ''        Else
    ''            sql_text = "SELECT TarifskiKm, StvarniKm " & _
    ''                                     "FROM dbo.ZsDaljinar " & _
    ''                                     "WHERE (Stanica1 = '" & mStanica2 & "') AND (Stanica2 = '" & mStanica1 & "')"

    ''        End If

    ''        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
    ''        Dim rdrDalj As SqlClient.SqlDataReader

    ''        rdrDalj = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
    ''        Do While rdrDalj.Read()
    ''            tbKm1.Text = rdrDalj.GetInt16(0)
    ''            bTkm = tbKm1.Text
    ''            sTkm = rdrDalj.GetInt16(1)
    ''            tbA76.Text = tbKm1.Text
    ''        Loop
    ''        rdrDalj.Close()
    ''        DbVeza.Close()
    ''    Else
    ''        tbKm1.Text = 0
    ''        bTkm = 0
    ''        sTkm = 0
    ''        tbA76.Text = 0
    ''    End If
    ''End Sub

    ''Private Sub tbBrojPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojPr.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub


    ''Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub DateTimePicker2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.Leave
    ''    Me.DateTimePicker2.BackColor = System.Drawing.Color.White
    ''    If IzborSaobracaja = "3" Then
    ''        Me.cmbPrevPut.Focus()
    ''    Else
    ''        If IzborSaobracaja = "2" Then
    ''            Me.tb59a.Text = Me.DateTimePicker2.Value.Year.ToString + "-" + Me.DateTimePicker2.Value.Month.ToString + "-" + Me.DateTimePicker2.Value.Day.ToString
    ''        End If
    ''        Me.tbsBrojVoza.Focus()
    ''    End If

    ''End Sub

    ''Private Sub FormUTL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    ''    If e.KeyCode = Keys.F12 Then
    ''        btnUnosRobe_Click(Me, Nothing)
    ''    ElseIf e.KeyCode = Keys.F11 Then
    ''        'Button4_Click(Me, Nothing)
    ''    ElseIf e.KeyCode = Keys.F10 Then
    ''        'Button7_Click(Me, Nothing)
    ''    End If
    ''End Sub

    ''Private Sub btnUnosRobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnosRobe.Click
    ''    If bVrstaPosiljke = "K" Then
    ''        Dim GridKola As New kola
    ''        GridKola.Show()

    ''    Else
    ''        Dim GridDencane As New Dencane
    ''        GridDencane.Show()
    ''    End If

    ''End Sub

    ''Private Sub tbsBrojVoza_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsBrojVoza.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tbsSatVoza_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsSatVoza.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
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

    ''Private Sub tb20a_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20a.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb20b_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20b.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb20c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20c.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb20d_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20d.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb20e_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20e.KeyPress
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

    ''Private Sub tb20f_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''    If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
    ''        e.Handled = True
    ''        SendKeys.Send(Chr(9))
    ''    End If
    ''End Sub

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

    ''Private Sub cbSmer2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSmer2.Validating
    ''    If DbVeza.State = ConnectionState.Closed Then
    ''        DbVeza.Open()
    ''    End If

    ''    Dim asql_trz1 As String = "SELECT ZsPrelazi.SifraCarina, ZsCarinarnice.Naziv " _
    ''                            & "FROM ZsPrelazi INNER JOIN " _
    ''                            & "ZsCarinarnice ON ZsPrelazi.SifraCarina = ZsCarinarnice.Sifra " _
    ''                            & "WHERE (dbo.ZsPrelazi.SifraPrelaza = '" & Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5) & "') "

    ''    Dim asql_commpr1 As New SqlClient.SqlCommand(asql_trz1, DbVeza)
    ''    Dim ardrPrelaz1 As SqlClient.SqlDataReader

    ''    Try
    ''        ardrPrelaz1 = asql_commpr1.ExecuteReader(CommandBehavior.CloseConnection)
    ''        Do While ardrPrelaz1.Read()
    ''            tbCarinjenje.Text = ardrPrelaz1.GetString(0)
    ''            Me.lblCarinarnica.Text = ardrPrelaz1.GetString(1)
    ''        Loop
    ''        ardrPrelaz1.Close()
    ''    Catch ex As Exception
    ''        MsgBox(ex.ToString)
    ''    Catch exsql As SqlException
    ''        MsgBox(exsql.ToString)
    ''    End Try
    ''    DbVeza.Close()
    ''End Sub

    ''Private Sub cbSmer1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSmer1.Validating
    ''    If DbVeza.State = ConnectionState.Closed Then
    ''        DbVeza.Open()
    ''    End If

    ''    Dim asql_trz1 As String = "SELECT ZsPrelazi.SifraCarina " _
    ''                            & "FROM ZsPrelazi " _
    ''                            & "WHERE (dbo.ZsPrelazi.SifraPrelaza = '" & Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5) & "') "

    ''    Dim asql_commpr1 As New SqlClient.SqlCommand(asql_trz1, DbVeza)
    ''    Dim ardrPrelaz1 As SqlClient.SqlDataReader

    ''    Try
    ''        ardrPrelaz1 = asql_commpr1.ExecuteReader(CommandBehavior.CloseConnection)
    ''        Do While ardrPrelaz1.Read()
    ''            Me.tbPolaznaCarina.Text = ardrPrelaz1.GetString(0)
    ''        Loop
    ''        ardrPrelaz1.Close()
    ''    Catch ex As Exception
    ''        MsgBox(ex.ToString)
    ''    Catch exsql As SqlException
    ''        MsgBox(exsql.ToString)
    ''    End Try
    ''    DbVeza.Close()

    ''End Sub

    ''Private Sub tbsSatVoza_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbsSatVoza.Validating
    ''    If CType(Me.tbsSatVoza.Text, Int32) > 24 Then
    ''        Me.tbsSatVoza.Focus()

    ''    End If
    ''End Sub

    ''Private Sub FormatErrGrid()
    ''    If err Is Nothing Then
    ''        dgError.DataSource = dtError
    ''    Else
    ''        dgError.DataSource = err.Tables(0)
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

    ''Private Sub btnUpravaOtp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpravaOtp.Click
    ''    Me.tbStanicaOtp.Clear()
    ''    Dim helpUic As New HelpForm
    ''    helpUic.Text = "help UIC"
    ''    upit = "UPR1"
    ''    helpUic.ShowDialog()
    ''    Me.tbUpravaOtp.Text = mIzlaz1
    ''    Label11.Text = mIzlaz2
    ''    tbStanicaOtp.Focus()
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
        FormatErrGrid()

        Me.ComboBox4.SelectedIndex = 0

        If eWebRazmena = "Da" Then

            tbCtrlNum.Text = webTLID
            If web02 = "K" Then
                Me.cbR4K.Checked = True
                Me.cbR4D.Checked = False
            ElseIf web02 = "D" Then
                Me.cbR4K.Checked = False
                Me.cbR4D.Checked = True
            End If

            If web03 = "R" Then
                Me.cbR5R.Checked = True
                Me.cbR5O.Checked = False
                Me.cbR5D.Checked = False
            ElseIf web03 = "O" Then
                Me.cbR5R.Checked = False
                Me.cbR5O.Checked = True
                Me.cbR5D.Checked = False
            ElseIf web03 = "D" Then
                Me.cbR5R.Checked = False
                Me.cbR5O.Checked = False
                Me.cbR5D.Checked = True
            End If

            If web04 = "N" Then
                Me.cbR6.Checked = False
            ElseIf web02 = "D" Then
                Me.cbR6.Checked = True
            End If

            Me.rtbR10.Text = web05
            Me.tbR11.Text = web06
            Me.tbR12Sifra.Text = web07
            Me.tbR12Naziv.Text = web08

            Me.tbStanicaOtp.Text = Microsoft.VisualBasic.Right(web07, 5)
            Me.tbR13_1.Text = Microsoft.VisualBasic.Right(web07, 5)
            Me.Label12.Text = web08

            Me.tbR14Naziv.Text = web09

            'R14,R15

            Me.rtbR16.Text = web11
            Me.tbR17.Text = web12

            Me.rtbR27.Text = web22
            Me.tbR30Sifra.Text = web23
            Me.tbR30Naziv.Text = web24

            Me.tbStanicaPr.Text = Microsoft.VisualBasic.Right(web23, 5)
            Me.tbR33_1.Text = Microsoft.VisualBasic.Right(web23, 5)
            Me.Label13.Text = web24
            Me.tbKolauVozu.Text = webSumaKola

            'pozvati daljinar
            Daljinar()

            Me.rtbR34.Text = web25
            Me.rtb37.Text = web27

            If web26 = "D" Then
                Me.cbRID.Checked = True
            Else
                Me.cbRID.Checked = False
            End If

            Me.tbR41Suma.Text = web28
            If web29 = "1" Then
                Me.CheckBox1.Checked = True
                Me.CheckBox2.Checked = False
                Me.CheckBox3.Checked = False
                Me.CheckBox4.Checked = False
                mSifraIzjave = 1
            ElseIf web29 = "2" Then
                mSifraIzjave = 2
                Me.CheckBox1.Checked = False
                Me.CheckBox2.Checked = True
                Me.CheckBox3.Checked = False
                Me.CheckBox4.Checked = False

                If Len(web30) > 0 Then
                    Me.tb20a.Text = Microsoft.VisualBasic.Left(web30, 2)
                    If Len(web30) > 2 Then
                        Me.tb20b.Text = Microsoft.VisualBasic.Mid(web30, 3, 2)
                    End If
                    If Len(web30) > 4 Then
                        Me.tb20c.Text = Microsoft.VisualBasic.Mid(web30, 5, 2)
                    End If
                    If Len(web30) > 6 Then
                        Me.tb20d.Text = Microsoft.VisualBasic.Right(web30, 2)
                    End If
                Else
                    Me.tb20a.Text = ""
                    Me.tb20b.Text = ""
                    Me.tb20c.Text = ""
                    Me.tb20d.Text = ""
                End If
            ElseIf web29 = "3" Then
                mSifraIzjave = 3
                Me.CheckBox1.Checked = False
                Me.CheckBox2.Checked = False
                Me.CheckBox3.Checked = True
                Me.CheckBox4.Checked = False
            ElseIf web29 = "4" Then
                mSifraIzjave = 4
                Me.CheckBox1.Checked = False
                Me.CheckBox2.Checked = False
                Me.CheckBox3.Checked = False
                Me.CheckBox4.Checked = True
            ElseIf web29 = "0" Then
                mSifraIzjave = 0
                Me.CheckBox1.Checked = False
                Me.CheckBox2.Checked = False
                Me.CheckBox3.Checked = False
                Me.CheckBox4.Checked = False
            End If



            Me.tbR49.Text = web32
            Me.tbR50.Text = web33



        Else

        End If


    End Sub

    Private Sub btnUnosRobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnosRobe.Click
        If bVrstaPosiljke = "K" Then
            Dim GridKola As New kola
            GridKola.Show()

        Else
            Dim GridDencane As New Dencane
            GridDencane.Show()
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()

        Close()

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "     Pošiljalac"
        upit = "Posiljalac"
        helpUic.ShowDialog()
        Me.tbR11.Text = CType(mIzlaz5, Integer)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "     Korisnièke šifre"
        upit = "SifreKorisnika"
        helpUic.ShowDialog()
        Me.tbR17.Text = CType(mIzlaz5, Integer)

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
            Me.ComboBox3.Enabled = True
            Me.ComboBox3.SelectedIndex = 0
            Me.ComboBox3.Focus()

        Else
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
        tbBrojOtp.Focus()

    End Sub

    Private Sub tbBrojOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub


    Private Sub DatumOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.Leave
        Me.btnKalk.Focus()

    End Sub

    Private Sub DatumOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub btnKalk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKalk.Click
        mStanica1 = Me.tbStanicaOtp.Text
        mStanica2 = Me.tbStanicaPr.Text

        UTLNaknadeR44(0) = Microsoft.VisualBasic.Trim(tb20a.Text)
        UTLNaknadeR44(1) = Microsoft.VisualBasic.Trim(tb20b.Text)
        UTLNaknadeR44(2) = Microsoft.VisualBasic.Trim(tb20c.Text)
        UTLNaknadeR44(3) = Microsoft.VisualBasic.Trim(tb20d.Text)

        '============= prikaz naknada
        If IzborSaobracaja = "1" Then
            bNadjiPrevozninuGlavni()

            If mSifraIzjave = "1" Then 'franko svi troskovi
                'tbPrevF.Text = mPrevoznina
                tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                tbPrevU.Text = 0
            ElseIf mSifraIzjave = "2" Then ' franko prevoznina ukljucivo
                'tbPrevF.Text = mPrevoznina
                tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                tbPrevU.Text = 0
            ElseIf mSifraIzjave = "3" Then 'franko prevoznina 
                'tbPrevF.Text = mPrevoznina
                tbPrevF.Text = Format(mPrevoznina, "###,###,##0.00")
                tbPrevU.Text = 0
            ElseIf mSifraIzjave = "4" Then 'franko do iznosa
            Else ' upuceno svi troskovi
                'tbPrevU.Text = mPrevoznina
                tbPrevU.Text = Format(mPrevoznina, "###,###,##0.00")
                tbPrevF.Text = 0
            End If
            tbPrevStav1.Text = Format(bVozarinskiStavPoKolima, "###,###,##0.00")
            tbR54_1.Text = dtNhm.Rows(0).Item(4)
            tbR42a.Text = dtNhm.Rows(0).Item(1)
            tbR41Suma.Text = dtNhm.Compute("SUM(Masa)", String.Empty)

            tbR57_1.Text = Format(bRacunskaMasaPoKolima, "###,###,##0.00")

            tbR21_1.Text = dtKola.Rows(0).Item(3)
            Me.tbIBK.Text = dtKola.Rows(0).Item(0)
            tbR23_1.Text = dtKola.Rows(0).Item(7)
            tbR24_1.Text = dtNhm.Rows(0).Item(3)
            tbR25a_1.Text = dtKola.Rows(0).Item(2)
            tbR25b_1.Text = dtKola.Rows.Count
            tbR26_1.Text = dtKola.Rows(0).Item(5)

            Me.tbSumaNeto.Text = tbR24_1.Text
            Me.tbSumaKola.Text = dtKola.Rows.Count
            Me.tbSumaOsovina.Text = tbR26_1.Text


            Dim i_TotalNak As String = ""
            Dim i_Pronasao As Int32 = 0
            Dim tmp_Naknada As Decimal
            Dim tmp_pdv_f As Decimal
            Dim tmp_pdv_u As Decimal
            Dim tmp_suma_f As Decimal
            Dim tmp_suma_u As Decimal
            Dim Nak_Red As DataRow
            Dim tmp_red As Int16 = 1

            If dtNaknade.Rows.Count > 0 Then

                For Each Nak_Red In dtNaknade.Rows
                    i_TotalNak = Nak_Red.Item("Sifra")
                    i_Pronasao = 0

                    If mSifraIzjave = "1" Then 'franko svi troskovi


                        If tmp_red = 1 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak1F.Text = Nak_Red.Item("Iznos")
                            tbNak1F.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak1U.Text = 0
                            tbA79a1.Text = Nak_Red.Item("Sifra")
                            tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                        ElseIf tmp_red = 2 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak2F.Text = Nak_Red.Item("Iznos")
                            tbNak2F.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak2U.Text = 0
                            tbA79a2.Text = Nak_Red.Item("Sifra")
                            tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                        ElseIf tmp_red = 3 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak3F.Text = Nak_Red.Item("Iznos")
                            tbNak3F.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak3U.Text = 0
                            tbA79a3.Text = Nak_Red.Item("Sifra")
                            tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                        ElseIf tmp_red = 4 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak4F.Text = Nak_Red.Item("Iznos")
                            tbNak4F.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak4U.Text = 0
                            tbA79a4.Text = Nak_Red.Item("Sifra")
                            tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                        End If

                    ElseIf mSifraIzjave = "2" Then ' franko prevoznina ukljucivo


                        For aa As Int16 = 0 To 3
                            If UTLNaknadeR44(aa) = i_TotalNak Then
                                i_Pronasao = 1
                                Exit For
                            End If
                        Next

                        If i_Pronasao = 1 Then
                            If tmp_red = 1 Then
                                tmp_Naknada = Nak_Red.Item("Iznos")
                                'tbNak1F.Text = Nak_Red.Item("Iznos")
                                tbNak1F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                tbNak1U.Text = 0
                                tbA79a1.Text = Nak_Red.Item("Sifra")
                                tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                            ElseIf tmp_red = 2 Then
                                tmp_Naknada = Nak_Red.Item("Iznos")
                                'tbNak2F.Text = Nak_Red.Item("Iznos")
                                tbNak2F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                tbNak2U.Text = 0
                                tbA79a2.Text = Nak_Red.Item("Sifra")
                                tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                            ElseIf tmp_red = 3 Then
                                tmp_Naknada = Nak_Red.Item("Iznos")
                                'tbNak3F.Text = Nak_Red.Item("Iznos")
                                tbNak3F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                tbNak3U.Text = 0
                                tbA79a3.Text = Nak_Red.Item("Sifra")
                                tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                            ElseIf tmp_red = 4 Then
                                tmp_Naknada = Nak_Red.Item("Iznos")
                                'tbNak4F.Text = Nak_Red.Item("Iznos")
                                tbNak4F.Text = Format(tmp_Naknada, "###,###,##0.00")
                                tbNak4U.Text = 0
                                tbA79a4.Text = Nak_Red.Item("Sifra")
                                tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                            End If
                        Else
                            If tmp_red = 1 Then
                                tmp_Naknada = Nak_Red.Item("Iznos")
                                'tbNak1U.Text = Nak_Red.Item("Iznos")
                                tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                tbNak1F.Text = 0
                                tbA79a1.Text = Nak_Red.Item("Sifra")
                                tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                            ElseIf tmp_red = 2 Then
                                tmp_Naknada = Nak_Red.Item("Iznos")
                                'tbNak2U.Text = Nak_Red.Item("Iznos")
                                tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                tbNak2F.Text = 0
                                tbA79a2.Text = Nak_Red.Item("Sifra")
                                tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                            ElseIf tmp_red = 3 Then
                                tmp_Naknada = Nak_Red.Item("Iznos")
                                'tbNak3U.Text = Nak_Red.Item("Iznos")
                                tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                tbNak3F.Text = 0
                                tbA79a3.Text = Nak_Red.Item("Sifra")
                                tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                            ElseIf tmp_red = 4 Then
                                tmp_Naknada = Nak_Red.Item("Iznos")
                                'tbNak4U.Text = Nak_Red.Item("Iznos")
                                tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                                tbNak4F.Text = 0
                                tbA79a4.Text = Nak_Red.Item("Sifra")
                                tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                            End If
                        End If

                    ElseIf mSifraIzjave = "3" Then 'franko prevoznina 


                        If tmp_red = 1 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak1U.Text = Nak_Red.Item("Iznos")
                            tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak1F.Text = 0
                            tbA79a1.Text = Nak_Red.Item("Sifra")
                            tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                        ElseIf tmp_red = 2 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak2U.Text = Nak_Red.Item("Iznos")
                            tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak2F.Text = 0
                            tbA79a2.Text = Nak_Red.Item("Sifra")
                            tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                        ElseIf tmp_red = 3 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak3U.Text = Nak_Red.Item("Iznos")
                            tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak3F.Text = 0
                            tbA79a3.Text = Nak_Red.Item("Sifra")
                            tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                        ElseIf tmp_red = 4 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak4U.Text = Nak_Red.Item("Iznos")
                            tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak4F.Text = 0
                            tbA79a4.Text = Nak_Red.Item("Sifra")
                            tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                        End If
                    ElseIf mSifraIzjave = "4" Then ' franko do iznosa

                    Else ' upuceno svi troskovi


                        If tmp_red = 1 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak1U.Text = Nak_Red.Item("Iznos")
                            tbNak1U.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak1F.Text = 0
                            tbA79a1.Text = Nak_Red.Item("Sifra")
                            tbA79b1.Text = Nak_Red.Item("IvicniBroj")
                        ElseIf tmp_red = 2 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak2U.Text = Nak_Red.Item("Iznos")
                            tbNak2U.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak2F.Text = 0
                            tbA79a2.Text = Nak_Red.Item("Sifra")
                            tbA79b2.Text = Nak_Red.Item("IvicniBroj")
                        ElseIf tmp_red = 3 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak3U.Text = Nak_Red.Item("Iznos")
                            tbNak3U.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak3F.Text = 0
                            tbA79a3.Text = Nak_Red.Item("Sifra")
                            tbA79b3.Text = Nak_Red.Item("IvicniBroj")
                        ElseIf tmp_red = 4 Then
                            tmp_Naknada = Nak_Red.Item("Iznos")
                            'tbNak4U.Text = Nak_Red.Item("Iznos")
                            tbNak4U.Text = Format(tmp_Naknada, "###,###,##0.00")
                            tbNak4F.Text = 0
                            tbA79a4.Text = Nak_Red.Item("Sifra")
                            tbA79b4.Text = Nak_Red.Item("IvicniBroj")
                        End If
                    End If

                    tmp_red = tmp_red + 1

                Next

            End If
            ' --- pdv 18%



            'Me.tbPdvIznosF.Text = (CType(tbPrevF.Text, Decimal) + CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)) * 0.18
            tmp_pdv_f = (CType(tbPrevF.Text, Decimal) + CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal)) * 0.18

            tbPdvIznosF.Text = Format(tmp_pdv_f, "###,###,##0.00")
            If CType(Me.tbPdvIznosF.Text, Decimal) > 0 Then
                Me.tbPDVF.Text = "62.1"
                Me.tbPDV.Text = "PDV 18%"
            Else
                Me.tbPDVF.Text = ""
            End If

            'Me.tbPdvIznosU.Text = (CType(tbPrevU.Text, Decimal) + CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)) * 0.18
            tmp_pdv_u = (CType(tbPrevU.Text, Decimal) + CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal)) * 0.18

            tbPdvIznosU.Text = Format(tmp_pdv_u, "###,###,##0.00")
            If CType(Me.tbPdvIznosU.Text, Decimal) > 0 Then
                Me.tbPDVU.Text = "62.0"
                Me.tbPDV.Text = "PDV 18%"
            Else
                Me.tbPDVU.Text = ""
            End If
            If Me.cbPDV.Checked = False Then
                Me.tbPDV.Text = ""
            End If


            'Me.tbSumaF.Text = CType(tbPrevF.Text, Decimal) + _
            '                  CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal) + _
            '                  CType(Me.tbPdvIznosF.Text, Decimal)

            tmp_suma_f = CType(tbPrevF.Text, Decimal) + _
                              CType(tbNak1F.Text, Decimal) + CType(tbNak2F.Text, Decimal) + CType(tbNak3F.Text, Decimal) + CType(tbNak4F.Text, Decimal) + _
                              CType(Me.tbPdvIznosF.Text, Decimal)
            tbSumaF.Text = Format(tmp_suma_f, "###,###,##0.00")

            'Me.tbSumaU.Text = CType(tbPrevU.Text, Decimal) + _
            '                  CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + _
            '                  CType(Me.tbPdvIznosU.Text, Decimal)

            tmp_suma_u = CType(tbPrevU.Text, Decimal) + _
                              CType(tbNak1U.Text, Decimal) + CType(tbNak2U.Text, Decimal) + CType(tbNak3U.Text, Decimal) + CType(tbNak4U.Text, Decimal) + _
                              CType(Me.tbPdvIznosU.Text, Decimal)
            tbSumaU.Text = Format(tmp_suma_u, "###,###,##0.00")
        End If
        '============= end prikaz naknada




    End Sub

    Private Sub Daljinar()
        Dim sql_text As String

        '---------------------------------------------------------------------------
        If IzborSaobracaja = "1" Then
            mStanica1 = Me.tbStanicaOtp.Text
            mStanica2 = Me.tbStanicaPr.Text
        End If


        '----------------------------------------------------------------------------
        If Len(mStanica1) > 0 And Len(mStanica2) > 0 Then
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
                tbR53.Text = rdrDalj.GetInt16(0)
                bTkm = tbR53.Text
                sTkm = rdrDalj.GetInt16(1)

            Loop
            rdrDalj.Close()
            DbVeza.Close()
        Else
            bTkm = 0
            sTkm = 0
            tbR53.Text = 0
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
        Else
            mSifraIzjave = 0
            Me.CheckBox2.Checked = False
            Me.CheckBox3.Checked = False
            Me.CheckBox1.Checked = False
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim CR_Utl As New FormK200rpt
        Dim CRIzv As New UTL_v5 ''' UTL_v4
        Dim CRIzv2 As New UTL_p3 'xx

        CR_Utl.CrystalReportViewer1.ReportSource = CRIzv
        CR_Utl.CrystalReportViewer1.ReportSource = CRIzv2 'xx

        ''Dim CRConec As New ConnectionInfo
        ''CRConec = CR_Utl.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        ''CRConec.ServerName = "10.0.4.31"
        ''CRConec.DatabaseName = "WinRoba"
        ''CRConec.UserID = "Radnik"
        ''CRConec.Password = "roba2006"

        Dim pStrana, pNaslov As String ' strana i naslov
        Dim r2 As String = Me.tbR2.Text
        Dim r4_1, r4_2, r5_1, r5_2, r5_3, r5_4, r6, r7, r8, r9, r10, r10_kb, r11 As String
        Dim r12_1, r12_2, r13_1, r13_2, r14_1, r14_2, r15, r15_1, r16, r17, r18, r19, r20_1, r20_2 As String
        Dim r21_1, r21_2, r21_3, r21_4, r22_1, r22_2, r22_3, r22_4 As String
        Dim r23_1, r23_2, r23_3, r23_4, r24_1, r24_2, r24_3, r24_4 As String
        Dim r25t_1, r25t_2, r25t_3, r25t_4, r25k_1, r25k_2, r25k_3, r25k_4 As String
        Dim r26_1, r26_2, r26_3, r26_4 As String
        Dim r27, r28 As String
        Dim rSumaTara, rSumaKola, rSumaOs As String ' Number?
        Dim r29_1, r29_2, r30_1, r30_2, r31_1, r31_2, r32, r32_1, r33_1, r33_2 As String
        Dim r34, r35, r36 As String
        Dim rRID, r37 As String
        Dim r42_1, r42_2, r42_3, r42_4, r42_5, r42_6, r43_1, r43_2, r43_3, r43_4, r43_5, r43_6 As String
        Dim r44_1, r44_2, r44_3, r44_4, r44n1, r44n2, r44n3, r44n4, r44i, r45_1, r45_2, r41Suma, r46 As String
        Dim r47, r48_1, r48_2 As String '?number
        Dim r49, r50, r51, r52 As String '?number
        Dim r53, r54_1, r54_2, r54_3 As String
        Dim r55_1, r55_2, r55_3, r56_1, r56_2, r56_3, r57_1, r57_2, r57_3, r58, r59, r60 As String
        Dim r61F, r61U As String '?number
        Dim r64F_1, r64F_2, r64F_3, r64F_4, r64F_5, r64F_6 As String '?number
        Dim r64U_1, r64U_2, r64U_3, r64U_4, r64U_5, r64U_6 As String '?number
        Dim r62a_1, r62a_2, r62a_3, r62a_4, r62a_5, r62a_6, r62b_1, r62b_2, r62b_3, r62b_4, r62b_5, r62b_6 As String
        Dim r62c_1, r62c_2, r62c_3, r62c_4, r62c_5, r62c_6 As String
        Dim R65f, R65u As String '?NUMBER
        Dim r66a, r66b As String


        If Me.cbR4K.Checked = True Then
            r4_1 = "x"
        Else
            r4_1 = " "
        End If
        If Me.cbR4D.Checked = True Then
            r4_2 = "x"
        Else
            r4_2 = " "
        End If

        If Me.cbR5R.Checked = True Then
            r5_1 = "x"
        Else
            r5_1 = " "
        End If
        If Me.cbR5O.Checked = True Then
            r5_2 = "x"
        Else
            r5_2 = " "
        End If
        If Me.cbR5D.Checked = True Then
            r5_3 = "x"
        Else
            r5_3 = " "
        End If
        r5_4 = " "

        If Me.cbR6.Checked = True Then
            r6 = "x"
        Else
            r6 = " "
        End If
        r7 = Me.tbR7.Text
        r8 = Me.tbR8.Text
        r9 = Me.tbR9.Text
        r10 = Me.rtbR10.Text
        r10_kb = tbCtrlNum.Text
        r11 = Me.tbR11.Text
        r12_1 = Me.tbR12Sifra.Text
        r12_2 = Me.tbR12Naziv.Text
        r13_1 = tbR13_1.Text
        r13_2 = tbR13_2.Text
        r14_1 = tbR14Sifra.Text
        r14_2 = tbR14Naziv.Text
        r15 = Me.tbR15.Text
        r15_1 = Me.tb15_1.Text
        r16 = Me.rtbR16.Text
        r17 = Me.tbR17.Text
        r18 = Me.tbR18.Text
        r19 = Me.tbR19.Text
        r20_1 = Me.tbR20a.Text
        r20_2 = Me.tbR20b.Text
        r21_1 = tbR21_1.Text
        r21_2 = tbR21_2.Text
        r21_3 = tbR21_3.Text
        r21_4 = tbR21_4.Text
        r22_1 = tbIBK.Text
        r22_2 = tbIBK_2.Text
        r22_3 = tbIBK_3.Text
        r22_4 = tbIBK_4.Text
        r23_1 = tbR23_1.Text
        r23_2 = tbR23_2.Text
        r23_3 = tbR23_3.Text
        r23_4 = tbR23_4.Text
        r24_1 = tbR24_1.Text
        r24_2 = tbR24_2.Text
        r24_3 = tbR24_3.Text
        r24_4 = tbR24_4.Text
        r25t_1 = tbR25a_1.Text
        r25t_2 = tbR25a_2.Text
        r25t_3 = tbR25a_3.Text
        r25t_4 = tbR25a_4.Text
        r25k_1 = tbR25b_1.Text
        r25k_2 = tbR25b_2.Text
        r25k_3 = tbR25b_3.Text
        r25k_4 = tbR25b_4.Text
        r26_1 = tbR26_1.Text
        r26_2 = tbR26_2.Text
        r26_3 = tbR26_3.Text
        r26_4 = tbR26_4.Text
        r27 = rtbR27.Text
        r28 = tbR28.Text
        rSumaTara = tbSumaNeto.Text
        rSumaKola = Me.tbSumaKola.Text
        rSumaOs = Me.tbSumaOsovina.Text
        If Me.CheckBox5.Checked = True Then
            r29_1 = "x"
            r29_2 = " "
        Else
            r29_1 = " "
            r29_2 = "x"
        End If
        If Me.CheckBox7.Checked = True Then
            r29_2 = "x"
            r29_1 = " "
        Else
            r29_2 = " "
            r29_1 = "x"
        End If

        r30_1 = Me.tbR30Sifra.Text
        r30_2 = Me.tbR30Naziv.Text
        r31_1 = Me.tbR31Sifra.Text
        r31_2 = Me.tbR31naziv.Text
        r32 = Me.tbR32a.Text
        r32_1 = Me.tbR32b.Text
        r33_1 = Me.tbR33_1.Text
        r33_2 = Me.tbR33_2.Text

        r34 = Me.rtbR34.Text
        r35 = Me.tbR35.Text
        r36 = Me.tbR36.Text

        If Me.cbRID.Checked = True Then
            rRID = "x"
        Else
            rRID = " "
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
            r44_1 = "x"
            r44_2 = " "
            r44_3 = " "
            r44_4 = " "
        End If
        If Me.CheckBox2.Checked = True Then
            r44_1 = " "
            r44_2 = "x"
            r44_3 = " "
            r44_4 = " "
        End If
        If Me.CheckBox3.Checked = True Then
            r44_1 = " "
            r44_2 = " "
            r44_3 = "x"
            r44_4 = " "
        End If
        If Me.CheckBox4.Checked = True Then
            r44_1 = " "
            r44_2 = " "
            r44_3 = " "
            r44_4 = "x"
        End If
        If Me.CheckBox1.Checked = False And Me.CheckBox2.Checked = False And _
           Me.CheckBox3.Checked = False And Me.CheckBox4.Checked = False Then
            r44_1 = " "
            r44_2 = " "
            r44_3 = " "
            r44_4 = " "
        End If

        r44n1 = Me.tb20a.Text
        r44n2 = Me.tb20b.Text
        r44n3 = Me.tb20c.Text
        r44n4 = Me.tb20d.Text
        r44i = Me.tbR44Iznos.Text
        r45_1 = Me.tbR45a.Text
        r45_2 = Me.tbR45b.Text
        r41Suma = Me.tbR41Suma.Text
        r46 = Me.tbR46.Text
        r47 = Me.tbR47.Text
        r48_1 = Me.tbR48a.Text
        r48_2 = Me.tbR48b.Text
        r49 = Me.tbR49.Text
        r50 = Me.tbR50.Text
        r51 = Me.tbR51.Text
        r53 = Me.tbR53.Text
        r54_1 = Me.tbR54_1.Text
        r54_2 = Me.tbR54_2.Text
        r54_3 = Me.tbR54_3.Text
        r55_1 = Me.tbPrevStav1.Text
        r55_2 = Me.tbPrevStav2.Text
        r55_3 = Me.tbPrevStav3.Text
        r56_1 = Me.tb56a.Text
        r56_2 = Me.tb56b.Text
        r56_3 = Me.tb56c.Text
        r57_1 = Me.tbR57_1.Text
        r57_2 = Me.tbR57_2.Text
        r57_3 = Me.tbR57_3.Text
        r58 = Me.tbR58.Text
        r59 = Me.tbR59.Text
        r60 = Me.tbR60.Text
        r61F = Me.tbPrevF.Text
        r61U = Me.tbPrevU.Text

        r64F_1 = Me.tbNak1F.Text
        r64F_2 = Me.tbNak2F.Text
        r64F_3 = Me.tbNak3F.Text
        r64F_4 = Me.tbNak4F.Text
        r64F_5 = Me.tbPdvIznosF.Text
        r64F_6 = Me.tbTugF.Text

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

        r64U_1 = Me.tbNak1U.Text
        r64U_2 = Me.tbNak2U.Text
        r64U_3 = Me.tbNak3U.Text
        r64U_4 = Me.tbNak4U.Text
        r64U_5 = Me.tbPdvIznosU.Text
        r64U_6 = Me.tbTugU.Text

        R65f = Me.tbSumaF.Text
        R65u = Me.tbSumaU.Text

        If Me.CheckBox6.Checked = True Then
            r66a = "x"
        Else
            r66a = " "
        End If
        r66b = tbR68b.Text


        Try
            pNaslov = "Original"
            pStrana = "1"

            CRIzv.SetParameterValue(0, pNaslov)
            CRIzv.SetParameterValue(1, pStrana)
            CRIzv.SetParameterValue(2, r2)
            CRIzv.SetParameterValue(3, r4_1)
            CRIzv.SetParameterValue(4, r4_2)
            CRIzv.SetParameterValue(5, r5_1)
            CRIzv.SetParameterValue(6, r5_2)
            CRIzv.SetParameterValue(7, r5_3)
            CRIzv.SetParameterValue(8, r5_4)
            CRIzv.SetParameterValue(9, r6)
            CRIzv.SetParameterValue(10, r7)
            CRIzv.SetParameterValue(11, r8)
            CRIzv.SetParameterValue(12, r9)
            CRIzv.SetParameterValue(13, r10)
            CRIzv.SetParameterValue(14, r10_kb)
            CRIzv.SetParameterValue(15, r11)
            CRIzv.SetParameterValue(16, r12_1)
            CRIzv.SetParameterValue(17, r12_2)
            CRIzv.SetParameterValue(18, r13_1)
            CRIzv.SetParameterValue(19, r13_2)
            CRIzv.SetParameterValue(20, r14_1)
            CRIzv.SetParameterValue(21, r14_2)
            CRIzv.SetParameterValue(22, r15)
            CRIzv.SetParameterValue(23, r15_1)
            CRIzv.SetParameterValue(24, r16)
            CRIzv.SetParameterValue(25, r17)
            CRIzv.SetParameterValue(26, r18)
            CRIzv.SetParameterValue(27, r19)
            CRIzv.SetParameterValue(28, r20_1)
            CRIzv.SetParameterValue(29, r20_2)
            CRIzv.SetParameterValue(30, r21_1)
            CRIzv.SetParameterValue(31, r21_2)
            CRIzv.SetParameterValue(32, r21_3)
            CRIzv.SetParameterValue(33, r21_4)
            CRIzv.SetParameterValue(34, r22_1)
            CRIzv.SetParameterValue(35, r22_2)
            CRIzv.SetParameterValue(36, r22_3)
            CRIzv.SetParameterValue(37, r22_4)
            CRIzv.SetParameterValue(38, r23_1)
            CRIzv.SetParameterValue(39, r23_2)
            CRIzv.SetParameterValue(40, r23_3)
            CRIzv.SetParameterValue(41, r23_4)
            CRIzv.SetParameterValue(42, r24_1)
            CRIzv.SetParameterValue(43, r24_2)
            CRIzv.SetParameterValue(44, r24_3)
            CRIzv.SetParameterValue(45, r24_4)
            CRIzv.SetParameterValue(46, r25t_1)
            CRIzv.SetParameterValue(47, r25t_2)
            CRIzv.SetParameterValue(48, r25t_3)
            CRIzv.SetParameterValue(49, r25t_4)
            CRIzv.SetParameterValue(50, r25k_1)
            CRIzv.SetParameterValue(51, r25k_2)
            CRIzv.SetParameterValue(52, r25k_3)
            CRIzv.SetParameterValue(53, r25k_4)
            CRIzv.SetParameterValue(54, r26_1)
            CRIzv.SetParameterValue(55, r26_2)
            CRIzv.SetParameterValue(56, r26_3)
            CRIzv.SetParameterValue(57, r26_4)
            CRIzv.SetParameterValue(58, r27)
            CRIzv.SetParameterValue(59, r28)
            CRIzv.SetParameterValue(60, rSumaTara)
            CRIzv.SetParameterValue(61, rSumaKola)
            CRIzv.SetParameterValue(62, rSumaOs)
            CRIzv.SetParameterValue(63, r29_1)
            CRIzv.SetParameterValue(64, r29_2)
            CRIzv.SetParameterValue(65, r30_1)
            CRIzv.SetParameterValue(66, r30_2)
            CRIzv.SetParameterValue(67, r31_1)
            CRIzv.SetParameterValue(68, r31_2)
            CRIzv.SetParameterValue(69, r32)
            CRIzv.SetParameterValue(70, r32_1)
            CRIzv.SetParameterValue(71, r33_1)
            CRIzv.SetParameterValue(72, r33_2)
            CRIzv.SetParameterValue(73, r34)
            CRIzv.SetParameterValue(74, r35)
            CRIzv.SetParameterValue(75, r36)
            CRIzv.SetParameterValue(76, rRID)
            CRIzv.SetParameterValue(77, r37)
            CRIzv.SetParameterValue(78, r42_1)
            CRIzv.SetParameterValue(79, r42_2)
            CRIzv.SetParameterValue(80, r42_3)
            CRIzv.SetParameterValue(81, r42_4)
            CRIzv.SetParameterValue(82, r42_5)
            CRIzv.SetParameterValue(83, r43_1)
            CRIzv.SetParameterValue(84, r43_2)
            CRIzv.SetParameterValue(85, r43_3)
            CRIzv.SetParameterValue(86, r43_4)
            CRIzv.SetParameterValue(87, r43_5)
            CRIzv.SetParameterValue(88, r44_1)
            CRIzv.SetParameterValue(89, r44_2)
            CRIzv.SetParameterValue(90, r44_3)
            CRIzv.SetParameterValue(91, r44_4)
            CRIzv.SetParameterValue(92, r44n1)
            CRIzv.SetParameterValue(93, r44n2)
            CRIzv.SetParameterValue(94, r44n3)
            CRIzv.SetParameterValue(95, r44n4)
            CRIzv.SetParameterValue(96, r44i)
            CRIzv.SetParameterValue(97, r45_1)
            CRIzv.SetParameterValue(98, r45_2)
            CRIzv.SetParameterValue(99, r41Suma)
            CRIzv.SetParameterValue(100, r46)
            CRIzv.SetParameterValue(101, r47)
            CRIzv.SetParameterValue(102, r48_1)
            CRIzv.SetParameterValue(103, r48_2)
            CRIzv.SetParameterValue(104, r49)
            CRIzv.SetParameterValue(105, r50)
            CRIzv.SetParameterValue(106, r51)
            CRIzv.SetParameterValue(107, r53)
            CRIzv.SetParameterValue(108, r54_1)
            CRIzv.SetParameterValue(109, r54_2)
            CRIzv.SetParameterValue(110, r54_3)
            CRIzv.SetParameterValue(111, r55_1)
            CRIzv.SetParameterValue(112, r55_2)
            CRIzv.SetParameterValue(113, r55_3)
            CRIzv.SetParameterValue(114, r56_1)
            CRIzv.SetParameterValue(115, r56_2)
            CRIzv.SetParameterValue(116, r56_3)
            CRIzv.SetParameterValue(117, r57_1)
            CRIzv.SetParameterValue(118, r57_2)
            CRIzv.SetParameterValue(119, r57_3)
            CRIzv.SetParameterValue(120, r58)
            CRIzv.SetParameterValue(121, r59)
            CRIzv.SetParameterValue(122, r60)
            CRIzv.SetParameterValue(123, r61F)
            CRIzv.SetParameterValue(124, r61U)
            CRIzv.SetParameterValue(125, r64F_1)
            CRIzv.SetParameterValue(126, r64F_2)
            CRIzv.SetParameterValue(127, r64F_3)
            CRIzv.SetParameterValue(128, r64F_4)
            CRIzv.SetParameterValue(129, r64F_5)
            CRIzv.SetParameterValue(130, r64F_6)
            CRIzv.SetParameterValue(131, r62a_1)
            CRIzv.SetParameterValue(132, r62a_2)
            CRIzv.SetParameterValue(133, r62a_3)
            CRIzv.SetParameterValue(134, r62a_4)
            CRIzv.SetParameterValue(135, r62a_5)
            CRIzv.SetParameterValue(136, r62a_6)
            CRIzv.SetParameterValue(137, r62b_1)
            CRIzv.SetParameterValue(138, r62b_2)
            CRIzv.SetParameterValue(139, r62b_3)
            CRIzv.SetParameterValue(140, r62b_4)
            CRIzv.SetParameterValue(141, r62b_5)
            CRIzv.SetParameterValue(142, r62b_6)
            CRIzv.SetParameterValue(143, r62c_1)
            CRIzv.SetParameterValue(144, r62c_2)
            CRIzv.SetParameterValue(145, r62c_3)
            CRIzv.SetParameterValue(146, r62c_4)
            CRIzv.SetParameterValue(147, r62c_5)
            CRIzv.SetParameterValue(148, r62c_6)
            CRIzv.SetParameterValue(149, r64U_1)
            CRIzv.SetParameterValue(150, r64U_2)
            CRIzv.SetParameterValue(151, r64U_3)
            CRIzv.SetParameterValue(152, r64U_4)
            CRIzv.SetParameterValue(153, r64U_5)
            CRIzv.SetParameterValue(154, r64U_6)
            CRIzv.SetParameterValue(155, R65f)
            CRIzv.SetParameterValue(156, R65u)
            CRIzv.SetParameterValue(157, r66a)
            CRIzv.SetParameterValue(158, r66b)

            '''            CR_Utl.Show()
            CRIzv.PrintToPrinter(1, False, 0, 0)




            pStrana = "2"
            pNaslov = "Tovarni list"

            CRIzv.SetParameterValue(0, pNaslov)
            CRIzv.SetParameterValue(1, pStrana)
            CRIzv.SetParameterValue(2, r2)
            CRIzv.SetParameterValue(3, r4_1)
            CRIzv.SetParameterValue(4, r4_2)
            CRIzv.SetParameterValue(5, r5_1)
            CRIzv.SetParameterValue(6, r5_2)
            CRIzv.SetParameterValue(7, r5_3)
            CRIzv.SetParameterValue(8, r5_4)
            CRIzv.SetParameterValue(9, r6)
            CRIzv.SetParameterValue(10, r7)
            CRIzv.SetParameterValue(11, r8)
            CRIzv.SetParameterValue(12, r9)
            CRIzv.SetParameterValue(13, r10)
            CRIzv.SetParameterValue(14, r10_kb)
            CRIzv.SetParameterValue(15, r11)
            CRIzv.SetParameterValue(16, r12_1)
            CRIzv.SetParameterValue(17, r12_2)
            CRIzv.SetParameterValue(18, r13_1)
            CRIzv.SetParameterValue(19, r13_2)
            CRIzv.SetParameterValue(20, r14_1)
            CRIzv.SetParameterValue(21, r14_2)
            CRIzv.SetParameterValue(22, r15)
            CRIzv.SetParameterValue(23, r15_1)
            CRIzv.SetParameterValue(24, r16)
            CRIzv.SetParameterValue(25, r17)
            CRIzv.SetParameterValue(26, r18)
            CRIzv.SetParameterValue(27, r19)
            CRIzv.SetParameterValue(28, r20_1)
            CRIzv.SetParameterValue(29, r20_2)
            CRIzv.SetParameterValue(30, r21_1)
            CRIzv.SetParameterValue(31, r21_2)
            CRIzv.SetParameterValue(32, r21_3)
            CRIzv.SetParameterValue(33, r21_4)
            CRIzv.SetParameterValue(34, r22_1)
            CRIzv.SetParameterValue(35, r22_2)
            CRIzv.SetParameterValue(36, r22_3)
            CRIzv.SetParameterValue(37, r22_4)
            CRIzv.SetParameterValue(38, r23_1)
            CRIzv.SetParameterValue(39, r23_2)
            CRIzv.SetParameterValue(40, r23_3)
            CRIzv.SetParameterValue(41, r23_4)
            CRIzv.SetParameterValue(42, r24_1)
            CRIzv.SetParameterValue(43, r24_2)
            CRIzv.SetParameterValue(44, r24_3)
            CRIzv.SetParameterValue(45, r24_4)
            CRIzv.SetParameterValue(46, r25t_1)
            CRIzv.SetParameterValue(47, r25t_2)
            CRIzv.SetParameterValue(48, r25t_3)
            CRIzv.SetParameterValue(49, r25t_4)
            CRIzv.SetParameterValue(50, r25k_1)
            CRIzv.SetParameterValue(51, r25k_2)
            CRIzv.SetParameterValue(52, r25k_3)
            CRIzv.SetParameterValue(53, r25k_4)
            CRIzv.SetParameterValue(54, r26_1)
            CRIzv.SetParameterValue(55, r26_2)
            CRIzv.SetParameterValue(56, r26_3)
            CRIzv.SetParameterValue(57, r26_4)
            CRIzv.SetParameterValue(58, r27)
            CRIzv.SetParameterValue(59, r28)
            CRIzv.SetParameterValue(60, rSumaTara)
            CRIzv.SetParameterValue(61, rSumaKola)
            CRIzv.SetParameterValue(62, rSumaOs)
            CRIzv.SetParameterValue(63, r29_1)
            CRIzv.SetParameterValue(64, r29_2)
            CRIzv.SetParameterValue(65, r30_1)
            CRIzv.SetParameterValue(66, r30_2)
            CRIzv.SetParameterValue(67, r31_1)
            CRIzv.SetParameterValue(68, r31_2)
            CRIzv.SetParameterValue(69, r32)
            CRIzv.SetParameterValue(70, r32_1)
            CRIzv.SetParameterValue(71, r33_1)
            CRIzv.SetParameterValue(72, r33_2)
            CRIzv.SetParameterValue(73, r34)
            CRIzv.SetParameterValue(74, r35)
            CRIzv.SetParameterValue(75, r36)
            CRIzv.SetParameterValue(76, rRID)
            CRIzv.SetParameterValue(77, r37)
            CRIzv.SetParameterValue(78, r42_1)
            CRIzv.SetParameterValue(79, r42_2)
            CRIzv.SetParameterValue(80, r42_3)
            CRIzv.SetParameterValue(81, r42_4)
            CRIzv.SetParameterValue(82, r42_5)
            CRIzv.SetParameterValue(83, r43_1)
            CRIzv.SetParameterValue(84, r43_2)
            CRIzv.SetParameterValue(85, r43_3)
            CRIzv.SetParameterValue(86, r43_4)
            CRIzv.SetParameterValue(87, r43_5)
            CRIzv.SetParameterValue(88, r44_1)
            CRIzv.SetParameterValue(89, r44_2)
            CRIzv.SetParameterValue(90, r44_3)
            CRIzv.SetParameterValue(91, r44_4)
            CRIzv.SetParameterValue(92, r44n1)
            CRIzv.SetParameterValue(93, r44n2)
            CRIzv.SetParameterValue(94, r44n3)
            CRIzv.SetParameterValue(95, r44n4)
            CRIzv.SetParameterValue(96, r44i)
            CRIzv.SetParameterValue(97, r45_1)
            CRIzv.SetParameterValue(98, r45_2)
            CRIzv.SetParameterValue(99, r41Suma)
            CRIzv.SetParameterValue(100, r46)
            CRIzv.SetParameterValue(101, r47)
            CRIzv.SetParameterValue(102, r48_1)
            CRIzv.SetParameterValue(103, r48_2)
            CRIzv.SetParameterValue(104, r49)
            CRIzv.SetParameterValue(105, r50)
            CRIzv.SetParameterValue(106, r51)
            CRIzv.SetParameterValue(107, r53)
            CRIzv.SetParameterValue(108, r54_1)
            CRIzv.SetParameterValue(109, r54_2)
            CRIzv.SetParameterValue(110, r54_3)
            CRIzv.SetParameterValue(111, r55_1)
            CRIzv.SetParameterValue(112, r55_2)
            CRIzv.SetParameterValue(113, r55_3)
            CRIzv.SetParameterValue(114, r56_1)
            CRIzv.SetParameterValue(115, r56_2)
            CRIzv.SetParameterValue(116, r56_3)
            CRIzv.SetParameterValue(117, r57_1)
            CRIzv.SetParameterValue(118, r57_2)
            CRIzv.SetParameterValue(119, r57_3)
            CRIzv.SetParameterValue(120, r58)
            CRIzv.SetParameterValue(121, r59)
            CRIzv.SetParameterValue(122, r60)
            CRIzv.SetParameterValue(123, r61F)
            CRIzv.SetParameterValue(124, r61U)
            CRIzv.SetParameterValue(125, r64F_1)
            CRIzv.SetParameterValue(126, r64F_2)
            CRIzv.SetParameterValue(127, r64F_3)
            CRIzv.SetParameterValue(128, r64F_4)
            CRIzv.SetParameterValue(129, r64F_5)
            CRIzv.SetParameterValue(130, r64F_6)
            CRIzv.SetParameterValue(131, r62a_1)
            CRIzv.SetParameterValue(132, r62a_2)
            CRIzv.SetParameterValue(133, r62a_3)
            CRIzv.SetParameterValue(134, r62a_4)
            CRIzv.SetParameterValue(135, r62a_5)
            CRIzv.SetParameterValue(136, r62a_6)
            CRIzv.SetParameterValue(137, r62b_1)
            CRIzv.SetParameterValue(138, r62b_2)
            CRIzv.SetParameterValue(139, r62b_3)
            CRIzv.SetParameterValue(140, r62b_4)
            CRIzv.SetParameterValue(141, r62b_5)
            CRIzv.SetParameterValue(142, r62b_6)
            CRIzv.SetParameterValue(143, r62c_1)
            CRIzv.SetParameterValue(144, r62c_2)
            CRIzv.SetParameterValue(145, r62c_3)
            CRIzv.SetParameterValue(146, r62c_4)
            CRIzv.SetParameterValue(147, r62c_5)
            CRIzv.SetParameterValue(148, r62c_6)
            CRIzv.SetParameterValue(149, r64U_1)
            CRIzv.SetParameterValue(150, r64U_2)
            CRIzv.SetParameterValue(151, r64U_3)
            CRIzv.SetParameterValue(152, r64U_4)
            CRIzv.SetParameterValue(153, r64U_5)
            CRIzv.SetParameterValue(154, r64U_6)
            CRIzv.SetParameterValue(155, R65f)
            CRIzv.SetParameterValue(156, R65u)
            CRIzv.SetParameterValue(157, r66a)
            CRIzv.SetParameterValue(158, r66b)
            CRIzv.PrintToPrinter(1, False, 0, 0)

            pStrana = "3"
            pNaslov = "Izvestaj o prispecu"
            CRIzv.SetParameterValue(0, pNaslov)
            CRIzv.SetParameterValue(1, pStrana)
            CRIzv.SetParameterValue(2, r2)
            CRIzv.SetParameterValue(3, r4_1)
            CRIzv.SetParameterValue(4, r4_2)
            CRIzv.SetParameterValue(5, r5_1)
            CRIzv.SetParameterValue(6, r5_2)
            CRIzv.SetParameterValue(7, r5_3)
            CRIzv.SetParameterValue(8, r5_4)
            CRIzv.SetParameterValue(9, r6)
            CRIzv.SetParameterValue(10, r7)
            CRIzv.SetParameterValue(11, r8)
            CRIzv.SetParameterValue(12, r9)
            CRIzv.SetParameterValue(13, r10)
            CRIzv.SetParameterValue(14, r10_kb)
            CRIzv.SetParameterValue(15, r11)
            CRIzv.SetParameterValue(16, r12_1)
            CRIzv.SetParameterValue(17, r12_2)
            CRIzv.SetParameterValue(18, r13_1)
            CRIzv.SetParameterValue(19, r13_2)
            CRIzv.SetParameterValue(20, r14_1)
            CRIzv.SetParameterValue(21, r14_2)
            CRIzv.SetParameterValue(22, r15)
            CRIzv.SetParameterValue(23, r15_1)
            CRIzv.SetParameterValue(24, r16)
            CRIzv.SetParameterValue(25, r17)
            CRIzv.SetParameterValue(26, r18)
            CRIzv.SetParameterValue(27, r19)
            CRIzv.SetParameterValue(28, r20_1)
            CRIzv.SetParameterValue(29, r20_2)
            CRIzv.SetParameterValue(30, r21_1)
            CRIzv.SetParameterValue(31, r21_2)
            CRIzv.SetParameterValue(32, r21_3)
            CRIzv.SetParameterValue(33, r21_4)
            CRIzv.SetParameterValue(34, r22_1)
            CRIzv.SetParameterValue(35, r22_2)
            CRIzv.SetParameterValue(36, r22_3)
            CRIzv.SetParameterValue(37, r22_4)
            CRIzv.SetParameterValue(38, r23_1)
            CRIzv.SetParameterValue(39, r23_2)
            CRIzv.SetParameterValue(40, r23_3)
            CRIzv.SetParameterValue(41, r23_4)
            CRIzv.SetParameterValue(42, r24_1)
            CRIzv.SetParameterValue(43, r24_2)
            CRIzv.SetParameterValue(44, r24_3)
            CRIzv.SetParameterValue(45, r24_4)
            CRIzv.SetParameterValue(46, r25t_1)
            CRIzv.SetParameterValue(47, r25t_2)
            CRIzv.SetParameterValue(48, r25t_3)
            CRIzv.SetParameterValue(49, r25t_4)
            CRIzv.SetParameterValue(50, r25k_1)
            CRIzv.SetParameterValue(51, r25k_2)
            CRIzv.SetParameterValue(52, r25k_3)
            CRIzv.SetParameterValue(53, r25k_4)
            CRIzv.SetParameterValue(54, r26_1)
            CRIzv.SetParameterValue(55, r26_2)
            CRIzv.SetParameterValue(56, r26_3)
            CRIzv.SetParameterValue(57, r26_4)
            CRIzv.SetParameterValue(58, r27)
            CRIzv.SetParameterValue(59, r28)
            CRIzv.SetParameterValue(60, rSumaTara)
            CRIzv.SetParameterValue(61, rSumaKola)
            CRIzv.SetParameterValue(62, rSumaOs)
            CRIzv.SetParameterValue(63, r29_1)
            CRIzv.SetParameterValue(64, r29_2)
            CRIzv.SetParameterValue(65, r30_1)
            CRIzv.SetParameterValue(66, r30_2)
            CRIzv.SetParameterValue(67, r31_1)
            CRIzv.SetParameterValue(68, r31_2)
            CRIzv.SetParameterValue(69, r32)
            CRIzv.SetParameterValue(70, r32_1)
            CRIzv.SetParameterValue(71, r33_1)
            CRIzv.SetParameterValue(72, r33_2)
            CRIzv.SetParameterValue(73, r34)
            CRIzv.SetParameterValue(74, r35)
            CRIzv.SetParameterValue(75, r36)
            CRIzv.SetParameterValue(76, rRID)
            CRIzv.SetParameterValue(77, r37)
            CRIzv.SetParameterValue(78, r42_1)
            CRIzv.SetParameterValue(79, r42_2)
            CRIzv.SetParameterValue(80, r42_3)
            CRIzv.SetParameterValue(81, r42_4)
            CRIzv.SetParameterValue(82, r42_5)
            CRIzv.SetParameterValue(83, r43_1)
            CRIzv.SetParameterValue(84, r43_2)
            CRIzv.SetParameterValue(85, r43_3)
            CRIzv.SetParameterValue(86, r43_4)
            CRIzv.SetParameterValue(87, r43_5)
            CRIzv.SetParameterValue(88, r44_1)
            CRIzv.SetParameterValue(89, r44_2)
            CRIzv.SetParameterValue(90, r44_3)
            CRIzv.SetParameterValue(91, r44_4)
            CRIzv.SetParameterValue(92, r44n1)
            CRIzv.SetParameterValue(93, r44n2)
            CRIzv.SetParameterValue(94, r44n3)
            CRIzv.SetParameterValue(95, r44n4)
            CRIzv.SetParameterValue(96, r44i)
            CRIzv.SetParameterValue(97, r45_1)
            CRIzv.SetParameterValue(98, r45_2)
            CRIzv.SetParameterValue(99, r41Suma)
            CRIzv.SetParameterValue(100, r46)
            CRIzv.SetParameterValue(101, r47)
            CRIzv.SetParameterValue(102, r48_1)
            CRIzv.SetParameterValue(103, r48_2)
            CRIzv.SetParameterValue(104, r49)
            CRIzv.SetParameterValue(105, r50)
            CRIzv.SetParameterValue(106, r51)
            CRIzv.SetParameterValue(107, r53)
            CRIzv.SetParameterValue(108, r54_1)
            CRIzv.SetParameterValue(109, r54_2)
            CRIzv.SetParameterValue(110, r54_3)
            CRIzv.SetParameterValue(111, r55_1)
            CRIzv.SetParameterValue(112, r55_2)
            CRIzv.SetParameterValue(113, r55_3)
            CRIzv.SetParameterValue(114, r56_1)
            CRIzv.SetParameterValue(115, r56_2)
            CRIzv.SetParameterValue(116, r56_3)
            CRIzv.SetParameterValue(117, r57_1)
            CRIzv.SetParameterValue(118, r57_2)
            CRIzv.SetParameterValue(119, r57_3)
            CRIzv.SetParameterValue(120, r58)
            CRIzv.SetParameterValue(121, r59)
            CRIzv.SetParameterValue(122, r60)
            CRIzv.SetParameterValue(123, r61F)
            CRIzv.SetParameterValue(124, r61U)
            CRIzv.SetParameterValue(125, r64F_1)
            CRIzv.SetParameterValue(126, r64F_2)
            CRIzv.SetParameterValue(127, r64F_3)
            CRIzv.SetParameterValue(128, r64F_4)
            CRIzv.SetParameterValue(129, r64F_5)
            CRIzv.SetParameterValue(130, r64F_6)
            CRIzv.SetParameterValue(131, r62a_1)
            CRIzv.SetParameterValue(132, r62a_2)
            CRIzv.SetParameterValue(133, r62a_3)
            CRIzv.SetParameterValue(134, r62a_4)
            CRIzv.SetParameterValue(135, r62a_5)
            CRIzv.SetParameterValue(136, r62a_6)
            CRIzv.SetParameterValue(137, r62b_1)
            CRIzv.SetParameterValue(138, r62b_2)
            CRIzv.SetParameterValue(139, r62b_3)
            CRIzv.SetParameterValue(140, r62b_4)
            CRIzv.SetParameterValue(141, r62b_5)
            CRIzv.SetParameterValue(142, r62b_6)
            CRIzv.SetParameterValue(143, r62c_1)
            CRIzv.SetParameterValue(144, r62c_2)
            CRIzv.SetParameterValue(145, r62c_3)
            CRIzv.SetParameterValue(146, r62c_4)
            CRIzv.SetParameterValue(147, r62c_5)
            CRIzv.SetParameterValue(148, r62c_6)
            CRIzv.SetParameterValue(149, r64U_1)
            CRIzv.SetParameterValue(150, r64U_2)
            CRIzv.SetParameterValue(151, r64U_3)
            CRIzv.SetParameterValue(152, r64U_4)
            CRIzv.SetParameterValue(153, r64U_5)
            CRIzv.SetParameterValue(154, r64U_6)
            CRIzv.SetParameterValue(155, R65f)
            CRIzv.SetParameterValue(156, R65u)
            CRIzv.SetParameterValue(157, r66a)
            CRIzv.SetParameterValue(158, r66b)

            CRIzv.PrintToPrinter(1, False, 0, 0)

            ''''------------------------------ Poledjina 3. lista

            CR_Utl.CrystalReportViewer1.ReportSource = CRIzv2
            CRIzv2.PrintToPrinter(1, False, 0, 0)



            pStrana = "4"
            pNaslov = "Duplikat"
            CRIzv.SetParameterValue(0, pNaslov)
            CRIzv.SetParameterValue(1, pStrana)
            CRIzv.SetParameterValue(2, r2)
            CRIzv.SetParameterValue(3, r4_1)
            CRIzv.SetParameterValue(4, r4_2)
            CRIzv.SetParameterValue(5, r5_1)
            CRIzv.SetParameterValue(6, r5_2)
            CRIzv.SetParameterValue(7, r5_3)
            CRIzv.SetParameterValue(8, r5_4)
            CRIzv.SetParameterValue(9, r6)
            CRIzv.SetParameterValue(10, r7)
            CRIzv.SetParameterValue(11, r8)
            CRIzv.SetParameterValue(12, r9)
            CRIzv.SetParameterValue(13, r10)
            CRIzv.SetParameterValue(14, r10_kb)
            CRIzv.SetParameterValue(15, r11)
            CRIzv.SetParameterValue(16, r12_1)
            CRIzv.SetParameterValue(17, r12_2)
            CRIzv.SetParameterValue(18, r13_1)
            CRIzv.SetParameterValue(19, r13_2)
            CRIzv.SetParameterValue(20, r14_1)
            CRIzv.SetParameterValue(21, r14_2)
            CRIzv.SetParameterValue(22, r15)
            CRIzv.SetParameterValue(23, r15_1)
            CRIzv.SetParameterValue(24, r16)
            CRIzv.SetParameterValue(25, r17)
            CRIzv.SetParameterValue(26, r18)
            CRIzv.SetParameterValue(27, r19)
            CRIzv.SetParameterValue(28, r20_1)
            CRIzv.SetParameterValue(29, r20_2)
            CRIzv.SetParameterValue(30, r21_1)
            CRIzv.SetParameterValue(31, r21_2)
            CRIzv.SetParameterValue(32, r21_3)
            CRIzv.SetParameterValue(33, r21_4)
            CRIzv.SetParameterValue(34, r22_1)
            CRIzv.SetParameterValue(35, r22_2)
            CRIzv.SetParameterValue(36, r22_3)
            CRIzv.SetParameterValue(37, r22_4)
            CRIzv.SetParameterValue(38, r23_1)
            CRIzv.SetParameterValue(39, r23_2)
            CRIzv.SetParameterValue(40, r23_3)
            CRIzv.SetParameterValue(41, r23_4)
            CRIzv.SetParameterValue(42, r24_1)
            CRIzv.SetParameterValue(43, r24_2)
            CRIzv.SetParameterValue(44, r24_3)
            CRIzv.SetParameterValue(45, r24_4)
            CRIzv.SetParameterValue(46, r25t_1)
            CRIzv.SetParameterValue(47, r25t_2)
            CRIzv.SetParameterValue(48, r25t_3)
            CRIzv.SetParameterValue(49, r25t_4)
            CRIzv.SetParameterValue(50, r25k_1)
            CRIzv.SetParameterValue(51, r25k_2)
            CRIzv.SetParameterValue(52, r25k_3)
            CRIzv.SetParameterValue(53, r25k_4)
            CRIzv.SetParameterValue(54, r26_1)
            CRIzv.SetParameterValue(55, r26_2)
            CRIzv.SetParameterValue(56, r26_3)
            CRIzv.SetParameterValue(57, r26_4)
            CRIzv.SetParameterValue(58, r27)
            CRIzv.SetParameterValue(59, r28)
            CRIzv.SetParameterValue(60, rSumaTara)
            CRIzv.SetParameterValue(61, rSumaKola)
            CRIzv.SetParameterValue(62, rSumaOs)
            CRIzv.SetParameterValue(63, r29_1)
            CRIzv.SetParameterValue(64, r29_2)
            CRIzv.SetParameterValue(65, r30_1)
            CRIzv.SetParameterValue(66, r30_2)
            CRIzv.SetParameterValue(67, r31_1)
            CRIzv.SetParameterValue(68, r31_2)
            CRIzv.SetParameterValue(69, r32)
            CRIzv.SetParameterValue(70, r32_1)
            CRIzv.SetParameterValue(71, r33_1)
            CRIzv.SetParameterValue(72, r33_2)
            CRIzv.SetParameterValue(73, r34)
            CRIzv.SetParameterValue(74, r35)
            CRIzv.SetParameterValue(75, r36)
            CRIzv.SetParameterValue(76, rRID)
            CRIzv.SetParameterValue(77, r37)
            CRIzv.SetParameterValue(78, r42_1)
            CRIzv.SetParameterValue(79, r42_2)
            CRIzv.SetParameterValue(80, r42_3)
            CRIzv.SetParameterValue(81, r42_4)
            CRIzv.SetParameterValue(82, r42_5)
            CRIzv.SetParameterValue(83, r43_1)
            CRIzv.SetParameterValue(84, r43_2)
            CRIzv.SetParameterValue(85, r43_3)
            CRIzv.SetParameterValue(86, r43_4)
            CRIzv.SetParameterValue(87, r43_5)
            CRIzv.SetParameterValue(88, r44_1)
            CRIzv.SetParameterValue(89, r44_2)
            CRIzv.SetParameterValue(90, r44_3)
            CRIzv.SetParameterValue(91, r44_4)
            CRIzv.SetParameterValue(92, r44n1)
            CRIzv.SetParameterValue(93, r44n2)
            CRIzv.SetParameterValue(94, r44n3)
            CRIzv.SetParameterValue(95, r44n4)
            CRIzv.SetParameterValue(96, r44i)
            CRIzv.SetParameterValue(97, r45_1)
            CRIzv.SetParameterValue(98, r45_2)
            CRIzv.SetParameterValue(99, r41Suma)
            CRIzv.SetParameterValue(100, r46)
            CRIzv.SetParameterValue(101, r47)
            CRIzv.SetParameterValue(102, r48_1)
            CRIzv.SetParameterValue(103, r48_2)
            CRIzv.SetParameterValue(104, r49)
            CRIzv.SetParameterValue(105, r50)
            CRIzv.SetParameterValue(106, r51)
            CRIzv.SetParameterValue(107, r53)
            CRIzv.SetParameterValue(108, r54_1)
            CRIzv.SetParameterValue(109, r54_2)
            CRIzv.SetParameterValue(110, r54_3)
            CRIzv.SetParameterValue(111, r55_1)
            CRIzv.SetParameterValue(112, r55_2)
            CRIzv.SetParameterValue(113, r55_3)
            CRIzv.SetParameterValue(114, r56_1)
            CRIzv.SetParameterValue(115, r56_2)
            CRIzv.SetParameterValue(116, r56_3)
            CRIzv.SetParameterValue(117, r57_1)
            CRIzv.SetParameterValue(118, r57_2)
            CRIzv.SetParameterValue(119, r57_3)
            CRIzv.SetParameterValue(120, r58)
            CRIzv.SetParameterValue(121, r59)
            CRIzv.SetParameterValue(122, r60)
            CRIzv.SetParameterValue(123, r61F)
            CRIzv.SetParameterValue(124, r61U)
            CRIzv.SetParameterValue(125, r64F_1)
            CRIzv.SetParameterValue(126, r64F_2)
            CRIzv.SetParameterValue(127, r64F_3)
            CRIzv.SetParameterValue(128, r64F_4)
            CRIzv.SetParameterValue(129, r64F_5)
            CRIzv.SetParameterValue(130, r64F_6)
            CRIzv.SetParameterValue(131, r62a_1)
            CRIzv.SetParameterValue(132, r62a_2)
            CRIzv.SetParameterValue(133, r62a_3)
            CRIzv.SetParameterValue(134, r62a_4)
            CRIzv.SetParameterValue(135, r62a_5)
            CRIzv.SetParameterValue(136, r62a_6)
            CRIzv.SetParameterValue(137, r62b_1)
            CRIzv.SetParameterValue(138, r62b_2)
            CRIzv.SetParameterValue(139, r62b_3)
            CRIzv.SetParameterValue(140, r62b_4)
            CRIzv.SetParameterValue(141, r62b_5)
            CRIzv.SetParameterValue(142, r62b_6)
            CRIzv.SetParameterValue(143, r62c_1)
            CRIzv.SetParameterValue(144, r62c_2)
            CRIzv.SetParameterValue(145, r62c_3)
            CRIzv.SetParameterValue(146, r62c_4)
            CRIzv.SetParameterValue(147, r62c_5)
            CRIzv.SetParameterValue(148, r62c_6)
            CRIzv.SetParameterValue(149, r64U_1)
            CRIzv.SetParameterValue(150, r64U_2)
            CRIzv.SetParameterValue(151, r64U_3)
            CRIzv.SetParameterValue(152, r64U_4)
            CRIzv.SetParameterValue(153, r64U_5)
            CRIzv.SetParameterValue(154, r64U_6)
            CRIzv.SetParameterValue(155, R65f)
            CRIzv.SetParameterValue(156, R65u)
            CRIzv.SetParameterValue(157, r66a)
            CRIzv.SetParameterValue(158, r66b)

            CRIzv.PrintToPrinter(1, False, 0, 0)

            pStrana = "5"
            pNaslov = "Kopija"
            CRIzv.SetParameterValue(0, pNaslov)
            CRIzv.SetParameterValue(1, pStrana)
            CRIzv.SetParameterValue(2, r2)
            CRIzv.SetParameterValue(3, r4_1)
            CRIzv.SetParameterValue(4, r4_2)
            CRIzv.SetParameterValue(5, r5_1)
            CRIzv.SetParameterValue(6, r5_2)
            CRIzv.SetParameterValue(7, r5_3)
            CRIzv.SetParameterValue(8, r5_4)
            CRIzv.SetParameterValue(9, r6)
            CRIzv.SetParameterValue(10, r7)
            CRIzv.SetParameterValue(11, r8)
            CRIzv.SetParameterValue(12, r9)
            CRIzv.SetParameterValue(13, r10)
            CRIzv.SetParameterValue(14, r10_kb)
            CRIzv.SetParameterValue(15, r11)
            CRIzv.SetParameterValue(16, r12_1)
            CRIzv.SetParameterValue(17, r12_2)
            CRIzv.SetParameterValue(18, r13_1)
            CRIzv.SetParameterValue(19, r13_2)
            CRIzv.SetParameterValue(20, r14_1)
            CRIzv.SetParameterValue(21, r14_2)
            CRIzv.SetParameterValue(22, r15)
            CRIzv.SetParameterValue(23, r15_1)
            CRIzv.SetParameterValue(24, r16)
            CRIzv.SetParameterValue(25, r17)
            CRIzv.SetParameterValue(26, r18)
            CRIzv.SetParameterValue(27, r19)
            CRIzv.SetParameterValue(28, r20_1)
            CRIzv.SetParameterValue(29, r20_2)
            CRIzv.SetParameterValue(30, r21_1)
            CRIzv.SetParameterValue(31, r21_2)
            CRIzv.SetParameterValue(32, r21_3)
            CRIzv.SetParameterValue(33, r21_4)
            CRIzv.SetParameterValue(34, r22_1)
            CRIzv.SetParameterValue(35, r22_2)
            CRIzv.SetParameterValue(36, r22_3)
            CRIzv.SetParameterValue(37, r22_4)
            CRIzv.SetParameterValue(38, r23_1)
            CRIzv.SetParameterValue(39, r23_2)
            CRIzv.SetParameterValue(40, r23_3)
            CRIzv.SetParameterValue(41, r23_4)
            CRIzv.SetParameterValue(42, r24_1)
            CRIzv.SetParameterValue(43, r24_2)
            CRIzv.SetParameterValue(44, r24_3)
            CRIzv.SetParameterValue(45, r24_4)
            CRIzv.SetParameterValue(46, r25t_1)
            CRIzv.SetParameterValue(47, r25t_2)
            CRIzv.SetParameterValue(48, r25t_3)
            CRIzv.SetParameterValue(49, r25t_4)
            CRIzv.SetParameterValue(50, r25k_1)
            CRIzv.SetParameterValue(51, r25k_2)
            CRIzv.SetParameterValue(52, r25k_3)
            CRIzv.SetParameterValue(53, r25k_4)
            CRIzv.SetParameterValue(54, r26_1)
            CRIzv.SetParameterValue(55, r26_2)
            CRIzv.SetParameterValue(56, r26_3)
            CRIzv.SetParameterValue(57, r26_4)
            CRIzv.SetParameterValue(58, r27)
            CRIzv.SetParameterValue(59, r28)
            CRIzv.SetParameterValue(60, rSumaTara)
            CRIzv.SetParameterValue(61, rSumaKola)
            CRIzv.SetParameterValue(62, rSumaOs)
            CRIzv.SetParameterValue(63, r29_1)
            CRIzv.SetParameterValue(64, r29_2)
            CRIzv.SetParameterValue(65, r30_1)
            CRIzv.SetParameterValue(66, r30_2)
            CRIzv.SetParameterValue(67, r31_1)
            CRIzv.SetParameterValue(68, r31_2)
            CRIzv.SetParameterValue(69, r32)
            CRIzv.SetParameterValue(70, r32_1)
            CRIzv.SetParameterValue(71, r33_1)
            CRIzv.SetParameterValue(72, r33_2)
            CRIzv.SetParameterValue(73, r34)
            CRIzv.SetParameterValue(74, r35)
            CRIzv.SetParameterValue(75, r36)
            CRIzv.SetParameterValue(76, rRID)
            CRIzv.SetParameterValue(77, r37)
            CRIzv.SetParameterValue(78, r42_1)
            CRIzv.SetParameterValue(79, r42_2)
            CRIzv.SetParameterValue(80, r42_3)
            CRIzv.SetParameterValue(81, r42_4)
            CRIzv.SetParameterValue(82, r42_5)
            CRIzv.SetParameterValue(83, r43_1)
            CRIzv.SetParameterValue(84, r43_2)
            CRIzv.SetParameterValue(85, r43_3)
            CRIzv.SetParameterValue(86, r43_4)
            CRIzv.SetParameterValue(87, r43_5)
            CRIzv.SetParameterValue(88, r44_1)
            CRIzv.SetParameterValue(89, r44_2)
            CRIzv.SetParameterValue(90, r44_3)
            CRIzv.SetParameterValue(91, r44_4)
            CRIzv.SetParameterValue(92, r44n1)
            CRIzv.SetParameterValue(93, r44n2)
            CRIzv.SetParameterValue(94, r44n3)
            CRIzv.SetParameterValue(95, r44n4)
            CRIzv.SetParameterValue(96, r44i)
            CRIzv.SetParameterValue(97, r45_1)
            CRIzv.SetParameterValue(98, r45_2)
            CRIzv.SetParameterValue(99, r41Suma)
            CRIzv.SetParameterValue(100, r46)
            CRIzv.SetParameterValue(101, r47)
            CRIzv.SetParameterValue(102, r48_1)
            CRIzv.SetParameterValue(103, r48_2)
            CRIzv.SetParameterValue(104, r49)
            CRIzv.SetParameterValue(105, r50)
            CRIzv.SetParameterValue(106, r51)
            CRIzv.SetParameterValue(107, r53)
            CRIzv.SetParameterValue(108, r54_1)
            CRIzv.SetParameterValue(109, r54_2)
            CRIzv.SetParameterValue(110, r54_3)
            CRIzv.SetParameterValue(111, r55_1)
            CRIzv.SetParameterValue(112, r55_2)
            CRIzv.SetParameterValue(113, r55_3)
            CRIzv.SetParameterValue(114, r56_1)
            CRIzv.SetParameterValue(115, r56_2)
            CRIzv.SetParameterValue(116, r56_3)
            CRIzv.SetParameterValue(117, r57_1)
            CRIzv.SetParameterValue(118, r57_2)
            CRIzv.SetParameterValue(119, r57_3)
            CRIzv.SetParameterValue(120, r58)
            CRIzv.SetParameterValue(121, r59)
            CRIzv.SetParameterValue(122, r60)
            CRIzv.SetParameterValue(123, r61F)
            CRIzv.SetParameterValue(124, r61U)
            CRIzv.SetParameterValue(125, r64F_1)
            CRIzv.SetParameterValue(126, r64F_2)
            CRIzv.SetParameterValue(127, r64F_3)
            CRIzv.SetParameterValue(128, r64F_4)
            CRIzv.SetParameterValue(129, r64F_5)
            CRIzv.SetParameterValue(130, r64F_6)
            CRIzv.SetParameterValue(131, r62a_1)
            CRIzv.SetParameterValue(132, r62a_2)
            CRIzv.SetParameterValue(133, r62a_3)
            CRIzv.SetParameterValue(134, r62a_4)
            CRIzv.SetParameterValue(135, r62a_5)
            CRIzv.SetParameterValue(136, r62a_6)
            CRIzv.SetParameterValue(137, r62b_1)
            CRIzv.SetParameterValue(138, r62b_2)
            CRIzv.SetParameterValue(139, r62b_3)
            CRIzv.SetParameterValue(140, r62b_4)
            CRIzv.SetParameterValue(141, r62b_5)
            CRIzv.SetParameterValue(142, r62b_6)
            CRIzv.SetParameterValue(143, r62c_1)
            CRIzv.SetParameterValue(144, r62c_2)
            CRIzv.SetParameterValue(145, r62c_3)
            CRIzv.SetParameterValue(146, r62c_4)
            CRIzv.SetParameterValue(147, r62c_5)
            CRIzv.SetParameterValue(148, r62c_6)
            CRIzv.SetParameterValue(149, r64U_1)
            CRIzv.SetParameterValue(150, r64U_2)
            CRIzv.SetParameterValue(151, r64U_3)
            CRIzv.SetParameterValue(152, r64U_4)
            CRIzv.SetParameterValue(153, r64U_5)
            CRIzv.SetParameterValue(154, r64U_6)
            CRIzv.SetParameterValue(155, R65f)
            CRIzv.SetParameterValue(156, R65u)
            CRIzv.SetParameterValue(157, r66a)
            CRIzv.SetParameterValue(158, r66b)

            CRIzv.PrintToPrinter(1, False, 0, 0)

            ''''''------------------------------ Poledjina 3. lista

            ''Dim CRIzv2 As New UTL_p3
            ''CR_Utl.CrystalReportViewer1.ReportSource = CRIzv2
            ''CRIzv2.PrintToPrinter(1, False, 0, 0)

            'CR_Utl.Show()
        Catch ex As Exception

            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub ComboBox4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox4.Validating
        tbR8.Text = Microsoft.VisualBasic.Left(Me.ComboBox4.Text, 1)

        If Microsoft.VisualBasic.Left(Me.ComboBox4.Text, 1) = "0" Then
            bValuta = "72"
        Else
            bValuta = "17"
        End If
    End Sub

    Private Sub tbBrojOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojOtp.Validating


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
            If Me.rtbR10.Text = Nothing Then
                errText14 = "Primalac"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText14})
            End If
            If Me.rtbR16.Text = Nothing Then
                errText14 = "Posiljalac"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText14})
            End If
            If Me.ComboBox1.SelectedText = Nothing Then
                errText9 = "Tarifa"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText9})
            End If
            If Me.tbR53.Text = Nothing Then 'Or CType(tbKm1.Text, Integer) = 0 Then
                errText5 = "Tarifski kilometri"
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
                If dtKola.Rows.Count = 0 Then
                    errText11 = "Unos robe"
                    dtError.NewRow()
                    dtError.Rows.Add(New Object() {errText11})
                End If
            End If

            If dtError.Rows.Count = 0 Then
                dgError.Visible = False
                ErrKontrola = "OK"
            Else
                dgError.Visible = True
                ErrKontrola = "NO"
            End If
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
        If _OpenForm = "Naknade" Then 'posle unosa naknada

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

        End If
    End Sub
    Private Sub tbUgovor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUgovor.Validating
        If IsNumeric(tbUgovor.Text) = True Then
            If tbUgovor.Text = Nothing Then
                ComboBox1.Focus()
            Else
                Dim mRetVal As String
                Dim ug_mNazivKomitenta As String
                Dim ug_mAdresaKomitenta As String
                Dim ug_mGradKomitenta As String
                Dim ug_mZemljaKomitenta As String
                Dim ug_mPrimalac As String
                Dim ug_mVrstaObracuna As String

                NadjiUgovor(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, ug_mAdresaKomitenta, ug_mGradKomitenta, ug_mZemljaKomitenta, mRetVal)

                If mRetVal = "" Then
                    _Kontrola_NemaUgovora = 0
                    _temp_mBrojUg = ""
                    mBrojUg = Me.tbUgovor.Text

                    mPrimalac = ug_mPrimalac
                    mSifraKorisnika = ug_mPrimalac
                    mVrstaObracuna = ug_mVrstaObracuna

                    ErrorProvider1.SetError(tbUgovor, "")

                    Me.tbR60.Text = "Ug. " & mBrojUg

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

    End Sub

End Class
