Imports Microsoft.VisualBasic
Imports System.Xml.Serialization
Imports System.IO
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.Collections
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class FormCim
    Inherits System.Windows.Forms.Form
    Public mBrojPokusaja As Int16 = 1
    Public ErrKontrola As String = "NO"
    Public tmpUgovor As String = ""
    Public _ForNum As Int16 = 0
    Public NumNizR50 As Int16 = 0
    Public SourceFile As String
    Dim str_R50, str_R50naziv As String
    'Dim NizR50(10, 2) As String
    Dim BrojPrelazaUNizu As Int16 = 0
    Dim SkokNaVoz As String = "Da"
    Public NizR50(10, 2) As String
    Public mPanelFocus As Int16 = 1
    Public x_UicPP As String '78..79..81
    Public R57RedniBrojUprave As Int16 = 0
    Public nmAllowExit As Boolean = False
    Public nmHzAdd As Boolean = False
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnStanicaOtp As System.Windows.Forms.Button
    Friend WithEvents tbBrojOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbUpravaOtp As System.Windows.Forms.TextBox
    Friend WithEvents btnUpravaOtp As System.Windows.Forms.Button
    Friend WithEvents DatumOtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnStanicaPr As System.Windows.Forms.Button
    Friend WithEvents tbBrojPr As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaPr As System.Windows.Forms.TextBox
    Friend WithEvents tbUpravaPr As System.Windows.Forms.TextBox
    Friend WithEvents btnUpravaPr As System.Windows.Forms.Button
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents kbBrojOtp As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents kbBrojPr As System.Windows.Forms.TextBox
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents ListBox4 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button22p As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cbR57 As System.Windows.Forms.ComboBox
    Friend WithEvents rtb57a As System.Windows.Forms.ListBox
    Friend WithEvents rtb57b As System.Windows.Forms.ListBox
    Friend WithEvents rtb57b2 As System.Windows.Forms.ListBox
    Friend WithEvents rtb57c As System.Windows.Forms.ListBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents r13 As System.Windows.Forms.ListBox
    Friend WithEvents r9 As System.Windows.Forms.ListBox
    Friend WithEvents r7 As System.Windows.Forms.ListBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents lblBrutoValue As System.Windows.Forms.Label
    Friend WithEvents lblTaraValue As System.Windows.Forms.Label
    Friend WithEvents lblBruto As System.Windows.Forms.Label
    Friend WithEvents lblTara As System.Windows.Forms.Label
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents tb4b2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents tb4b1 As System.Windows.Forms.TextBox
    Friend WithEvents tb29b_3 As System.Windows.Forms.TextBox
    Friend WithEvents tb29b_2 As System.Windows.Forms.TextBox
    Friend WithEvents tb29b_1 As System.Windows.Forms.TextBox
    Friend WithEvents tb1b2 As System.Windows.Forms.TextBox
    Friend WithEvents tb1b1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbKolauVozu As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents tb13 As System.Windows.Forms.TextBox
    Friend WithEvents rtb9 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents TB58b As System.Windows.Forms.TextBox
    Friend WithEvents tbPolaznaCarina As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents rtb7 As System.Windows.Forms.RichTextBox
    Friend WithEvents rtb56 As System.Windows.Forms.RichTextBox
    Friend WithEvents rtb55 As System.Windows.Forms.RichTextBox
    Friend WithEvents rtb21 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents TextBox49 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox51 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox69 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox70 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox46 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox47 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox48 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox42 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox43 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox44 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox45 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox38 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox39 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox40 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox41 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox28 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox35 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox36 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox37 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79b3 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79a3 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79b2 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79a2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents tb16b As System.Windows.Forms.TextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents btnCarinarnica As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbCarinjenje As System.Windows.Forms.TextBox
    Friend WithEvents lblCarinarnica As System.Windows.Forms.Label
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbsBrojVoza As System.Windows.Forms.TextBox
    Friend WithEvents tbsSatVoza As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents tb52c As System.Windows.Forms.TextBox
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents combo73A As System.Windows.Forms.ComboBox
    Friend WithEvents tbA70b2 As System.Windows.Forms.TextBox
    Friend WithEvents tbA70a2 As System.Windows.Forms.TextBox
    Friend WithEvents tbA78 As System.Windows.Forms.TextBox
    Friend WithEvents tbA77 As System.Windows.Forms.TextBox
    Friend WithEvents tbA76 As System.Windows.Forms.TextBox
    Friend WithEvents tbA75 As System.Windows.Forms.TextBox
    Friend WithEvents tbA74d1 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79b1 As System.Windows.Forms.TextBox
    Friend WithEvents tbA79a1 As System.Windows.Forms.TextBox
    Friend WithEvents tbA72d As System.Windows.Forms.TextBox
    Friend WithEvents tb71 As System.Windows.Forms.TextBox
    Friend WithEvents tbA70b1 As System.Windows.Forms.TextBox
    Friend WithEvents tbA70a1 As System.Windows.Forms.TextBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents tb49g As System.Windows.Forms.TextBox
    Friend WithEvents tb49f As System.Windows.Forms.TextBox
    Friend WithEvents tb49e As System.Windows.Forms.TextBox
    Friend WithEvents tb49d As System.Windows.Forms.TextBox
    Friend WithEvents tb49c As System.Windows.Forms.TextBox
    Friend WithEvents tb49b As System.Windows.Forms.TextBox
    Friend WithEvents tb51b As System.Windows.Forms.TextBox
    Friend WithEvents TextBox80 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox81 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox78 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox79 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox76 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox77 As System.Windows.Forms.TextBox
    Friend WithEvents tb59b As System.Windows.Forms.TextBox
    Friend WithEvents tb59a As System.Windows.Forms.TextBox
    Friend WithEvents tb28 As System.Windows.Forms.TextBox
    Friend WithEvents tb27 As System.Windows.Forms.TextBox
    Friend WithEvents btnUnosRobe As System.Windows.Forms.Button
    Friend WithEvents tb4c As System.Windows.Forms.TextBox
    Friend WithEvents tb10b As System.Windows.Forms.TextBox
    Friend WithEvents tb52e As System.Windows.Forms.TextBox
    Friend WithEvents tb52d As System.Windows.Forms.TextBox
    Friend WithEvents tb52b As System.Windows.Forms.TextBox
    Friend WithEvents tb52a As System.Windows.Forms.TextBox
    Friend WithEvents TextBox66 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox67 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox68 As System.Windows.Forms.TextBox
    Friend WithEvents TB58a2 As System.Windows.Forms.TextBox
    Friend WithEvents TB58a1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox57 As System.Windows.Forms.TextBox
    Friend WithEvents tb51c As System.Windows.Forms.TextBox
    Friend WithEvents tb51a As System.Windows.Forms.TextBox
    Friend WithEvents tb50 As System.Windows.Forms.TextBox
    Friend WithEvents tb49h As System.Windows.Forms.TextBox
    Friend WithEvents tb49a As System.Windows.Forms.TextBox
    Friend WithEvents tb29b As System.Windows.Forms.TextBox
    Friend WithEvents tb29a As System.Windows.Forms.TextBox
    Friend WithEvents cbVal28 As System.Windows.Forms.ComboBox
    Friend WithEvents tb26 As System.Windows.Forms.TextBox
    Friend WithEvents cbVal27 As System.Windows.Forms.ComboBox
    Friend WithEvents cbVal26 As System.Windows.Forms.ComboBox
    Friend WithEvents tb25 As System.Windows.Forms.TextBox
    Friend WithEvents tb24 As System.Windows.Forms.TextBox
    Friend WithEvents tb16c As System.Windows.Forms.TextBox
    Friend WithEvents tb20a As System.Windows.Forms.TextBox
    Friend WithEvents tb20f As System.Windows.Forms.TextBox
    Friend WithEvents tb20e As System.Windows.Forms.TextBox
    Friend WithEvents tb20d As System.Windows.Forms.TextBox
    Friend WithEvents tb20c As System.Windows.Forms.TextBox
    Friend WithEvents tb20b As System.Windows.Forms.TextBox
    Friend WithEvents tb17 As System.Windows.Forms.TextBox
    Friend WithEvents tb16a As System.Windows.Forms.TextBox
    Friend WithEvents tb16e As System.Windows.Forms.TextBox
    Friend WithEvents tb16d As System.Windows.Forms.TextBox
    Friend WithEvents tb15 As System.Windows.Forms.TextBox
    Friend WithEvents tb14a As System.Windows.Forms.TextBox
    Friend WithEvents tb14b As System.Windows.Forms.TextBox
    Friend WithEvents TextBox34 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox33 As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents tb4a As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tb1a As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents comboIncoterms As System.Windows.Forms.ComboBox
    Friend WithEvents cbIncoterms As System.Windows.Forms.CheckBox
    Friend WithEvents cbFrankoPrevoznina As System.Windows.Forms.CheckBox
    Friend WithEvents tbIBK As System.Windows.Forms.TextBox
    Friend WithEvents tb1c As System.Windows.Forms.TextBox
    Friend WithEvents tb6 As System.Windows.Forms.TextBox
    Friend WithEvents tb4b As System.Windows.Forms.TextBox
    Friend WithEvents tb5 As System.Windows.Forms.TextBox
    Friend WithEvents tb3 As System.Windows.Forms.TextBox
    Friend WithEvents tb1b As System.Windows.Forms.TextBox
    Friend WithEvents tb10a As System.Windows.Forms.TextBox
    Friend WithEvents tb12 As System.Windows.Forms.TextBox
    Friend WithEvents cbCUV As System.Windows.Forms.CheckBox
    Friend WithEvents cbCIM As System.Windows.Forms.CheckBox
    Friend WithEvents tb2 As System.Windows.Forms.TextBox
    Friend WithEvents tbControl As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents lbR57 As System.Windows.Forms.ListBox
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents cbOperaterAdd As System.Windows.Forms.ComboBox
    Friend WithEvents btnOperaterAdd As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormCim))
        Me.cmbPrevPut = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbUlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.tbIzlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Button11 = New System.Windows.Forms.Button
        Me.btnUpis = New System.Windows.Forms.Button
        Me.btnUpravaOtp = New System.Windows.Forms.Button
        Me.btnUpravaPr = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.tbBrojOtp = New System.Windows.Forms.TextBox
        Me.tbStanicaOtp = New System.Windows.Forms.TextBox
        Me.tbUpravaOtp = New System.Windows.Forms.TextBox
        Me.tbBrojPr = New System.Windows.Forms.TextBox
        Me.tbStanicaPr = New System.Windows.Forms.TextBox
        Me.tbUpravaPr = New System.Windows.Forms.TextBox
        Me.kbBrojOtp = New System.Windows.Forms.TextBox
        Me.kbBrojPr = New System.Windows.Forms.TextBox
        Me.Button19 = New System.Windows.Forms.Button
        Me.Button22p = New System.Windows.Forms.Button
        Me.Button22 = New System.Windows.Forms.Button
        Me.Button21 = New System.Windows.Forms.Button
        Me.r13 = New System.Windows.Forms.ListBox
        Me.r9 = New System.Windows.Forms.ListBox
        Me.r7 = New System.Windows.Forms.ListBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button20 = New System.Windows.Forms.Button
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.tb4b2 = New System.Windows.Forms.TextBox
        Me.ComboBox5 = New System.Windows.Forms.ComboBox
        Me.tb4b1 = New System.Windows.Forms.TextBox
        Me.tb29b_3 = New System.Windows.Forms.TextBox
        Me.tb29b_2 = New System.Windows.Forms.TextBox
        Me.tb29b_1 = New System.Windows.Forms.TextBox
        Me.tb1b2 = New System.Windows.Forms.TextBox
        Me.tb1b1 = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button17 = New System.Windows.Forms.Button
        Me.TB58b = New System.Windows.Forms.TextBox
        Me.tbPolaznaCarina = New System.Windows.Forms.TextBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button18 = New System.Windows.Forms.Button
        Me.TextBox49 = New System.Windows.Forms.TextBox
        Me.TextBox51 = New System.Windows.Forms.TextBox
        Me.TextBox69 = New System.Windows.Forms.TextBox
        Me.TextBox70 = New System.Windows.Forms.TextBox
        Me.TextBox46 = New System.Windows.Forms.TextBox
        Me.TextBox47 = New System.Windows.Forms.TextBox
        Me.TextBox48 = New System.Windows.Forms.TextBox
        Me.TextBox42 = New System.Windows.Forms.TextBox
        Me.TextBox43 = New System.Windows.Forms.TextBox
        Me.TextBox44 = New System.Windows.Forms.TextBox
        Me.TextBox45 = New System.Windows.Forms.TextBox
        Me.TextBox38 = New System.Windows.Forms.TextBox
        Me.TextBox39 = New System.Windows.Forms.TextBox
        Me.TextBox40 = New System.Windows.Forms.TextBox
        Me.TextBox41 = New System.Windows.Forms.TextBox
        Me.TextBox28 = New System.Windows.Forms.TextBox
        Me.TextBox35 = New System.Windows.Forms.TextBox
        Me.TextBox36 = New System.Windows.Forms.TextBox
        Me.TextBox37 = New System.Windows.Forms.TextBox
        Me.tbA79b3 = New System.Windows.Forms.TextBox
        Me.tbA79a3 = New System.Windows.Forms.TextBox
        Me.tbA79b2 = New System.Windows.Forms.TextBox
        Me.tbA79a2 = New System.Windows.Forms.TextBox
        Me.TextBox21 = New System.Windows.Forms.TextBox
        Me.TextBox22 = New System.Windows.Forms.TextBox
        Me.TextBox23 = New System.Windows.Forms.TextBox
        Me.TextBox15 = New System.Windows.Forms.TextBox
        Me.TextBox16 = New System.Windows.Forms.TextBox
        Me.TextBox17 = New System.Windows.Forms.TextBox
        Me.TextBox18 = New System.Windows.Forms.TextBox
        Me.TextBox19 = New System.Windows.Forms.TextBox
        Me.TextBox20 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.tb16b = New System.Windows.Forms.TextBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.btnCarinarnica = New System.Windows.Forms.Button
        Me.tbCarinjenje = New System.Windows.Forms.TextBox
        Me.Button16 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.tbsBrojVoza = New System.Windows.Forms.TextBox
        Me.tbsSatVoza = New System.Windows.Forms.NumericUpDown
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.tb52c = New System.Windows.Forms.TextBox
        Me.Button13 = New System.Windows.Forms.Button
        Me.combo73A = New System.Windows.Forms.ComboBox
        Me.tbA70b2 = New System.Windows.Forms.TextBox
        Me.tbA70a2 = New System.Windows.Forms.TextBox
        Me.tbA78 = New System.Windows.Forms.TextBox
        Me.tbA77 = New System.Windows.Forms.TextBox
        Me.tbA76 = New System.Windows.Forms.TextBox
        Me.tbA75 = New System.Windows.Forms.TextBox
        Me.tbA74d1 = New System.Windows.Forms.TextBox
        Me.tbA79b1 = New System.Windows.Forms.TextBox
        Me.tbA79a1 = New System.Windows.Forms.TextBox
        Me.tbA72d = New System.Windows.Forms.TextBox
        Me.tb71 = New System.Windows.Forms.TextBox
        Me.tbA70b1 = New System.Windows.Forms.TextBox
        Me.tbA70a1 = New System.Windows.Forms.TextBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.tb49g = New System.Windows.Forms.TextBox
        Me.tb49f = New System.Windows.Forms.TextBox
        Me.tb49e = New System.Windows.Forms.TextBox
        Me.tb49d = New System.Windows.Forms.TextBox
        Me.tb49c = New System.Windows.Forms.TextBox
        Me.tb49b = New System.Windows.Forms.TextBox
        Me.tb59b = New System.Windows.Forms.TextBox
        Me.tb59a = New System.Windows.Forms.TextBox
        Me.tb28 = New System.Windows.Forms.TextBox
        Me.tb27 = New System.Windows.Forms.TextBox
        Me.btnUnosRobe = New System.Windows.Forms.Button
        Me.tb4c = New System.Windows.Forms.TextBox
        Me.tb10b = New System.Windows.Forms.TextBox
        Me.tb52e = New System.Windows.Forms.TextBox
        Me.tb52d = New System.Windows.Forms.TextBox
        Me.tb52b = New System.Windows.Forms.TextBox
        Me.tb52a = New System.Windows.Forms.TextBox
        Me.TextBox66 = New System.Windows.Forms.TextBox
        Me.TextBox67 = New System.Windows.Forms.TextBox
        Me.TextBox68 = New System.Windows.Forms.TextBox
        Me.TB58a2 = New System.Windows.Forms.TextBox
        Me.TB58a1 = New System.Windows.Forms.TextBox
        Me.tb51a = New System.Windows.Forms.TextBox
        Me.tb50 = New System.Windows.Forms.TextBox
        Me.tb49h = New System.Windows.Forms.TextBox
        Me.tb49a = New System.Windows.Forms.TextBox
        Me.tb29b = New System.Windows.Forms.TextBox
        Me.tb29a = New System.Windows.Forms.TextBox
        Me.cbVal28 = New System.Windows.Forms.ComboBox
        Me.tb26 = New System.Windows.Forms.TextBox
        Me.cbVal27 = New System.Windows.Forms.ComboBox
        Me.cbVal26 = New System.Windows.Forms.ComboBox
        Me.tb17 = New System.Windows.Forms.TextBox
        Me.tb16a = New System.Windows.Forms.TextBox
        Me.tb14a = New System.Windows.Forms.TextBox
        Me.tb14b = New System.Windows.Forms.TextBox
        Me.TextBox34 = New System.Windows.Forms.TextBox
        Me.TextBox33 = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.tb4a = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.tb1a = New System.Windows.Forms.TextBox
        Me.comboIncoterms = New System.Windows.Forms.ComboBox
        Me.tb1c = New System.Windows.Forms.TextBox
        Me.tb6 = New System.Windows.Forms.TextBox
        Me.tb4b = New System.Windows.Forms.TextBox
        Me.tb5 = New System.Windows.Forms.TextBox
        Me.tb3 = New System.Windows.Forms.TextBox
        Me.tb1b = New System.Windows.Forms.TextBox
        Me.tb10a = New System.Windows.Forms.TextBox
        Me.tb12 = New System.Windows.Forms.TextBox
        Me.tb2 = New System.Windows.Forms.TextBox
        Me.Button23 = New System.Windows.Forms.Button
        Me.Button24 = New System.Windows.Forms.Button
        Me.Button26 = New System.Windows.Forms.Button
        Me.btnOperaterAdd = New System.Windows.Forms.Button
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
        Me.Button25 = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.DatumOtp = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnStanicaOtp = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnStanicaPr = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.gbPrevozniPut = New System.Windows.Forms.GroupBox
        Me.lblPP = New System.Windows.Forms.Label
        Me.ListBox4 = New System.Windows.Forms.ListBox
        Me.ListBox3 = New System.Windows.Forms.ListBox
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.cbOperaterAdd = New System.Windows.Forms.ComboBox
        Me.lbR57 = New System.Windows.Forms.ListBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cbR57 = New System.Windows.Forms.ComboBox
        Me.rtb57a = New System.Windows.Forms.ListBox
        Me.rtb57b = New System.Windows.Forms.ListBox
        Me.rtb57b2 = New System.Windows.Forms.ListBox
        Me.rtb57c = New System.Windows.Forms.ListBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.lblBrutoValue = New System.Windows.Forms.Label
        Me.lblTaraValue = New System.Windows.Forms.Label
        Me.lblBruto = New System.Windows.Forms.Label
        Me.lblTara = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbKolauVozu = New System.Windows.Forms.TextBox
        Me.tb13 = New System.Windows.Forms.TextBox
        Me.rtb9 = New System.Windows.Forms.RichTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.rtb7 = New System.Windows.Forms.RichTextBox
        Me.rtb56 = New System.Windows.Forms.RichTextBox
        Me.rtb55 = New System.Windows.Forms.RichTextBox
        Me.rtb21 = New System.Windows.Forms.RichTextBox
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblCarinarnica = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox13 = New System.Windows.Forms.TextBox
        Me.tb51b = New System.Windows.Forms.TextBox
        Me.TextBox80 = New System.Windows.Forms.TextBox
        Me.TextBox81 = New System.Windows.Forms.TextBox
        Me.TextBox78 = New System.Windows.Forms.TextBox
        Me.TextBox79 = New System.Windows.Forms.TextBox
        Me.TextBox76 = New System.Windows.Forms.TextBox
        Me.TextBox77 = New System.Windows.Forms.TextBox
        Me.TextBox57 = New System.Windows.Forms.TextBox
        Me.tb51c = New System.Windows.Forms.TextBox
        Me.tb25 = New System.Windows.Forms.TextBox
        Me.tb24 = New System.Windows.Forms.TextBox
        Me.tb16c = New System.Windows.Forms.TextBox
        Me.tb20a = New System.Windows.Forms.TextBox
        Me.tb20f = New System.Windows.Forms.TextBox
        Me.tb20e = New System.Windows.Forms.TextBox
        Me.tb20d = New System.Windows.Forms.TextBox
        Me.tb20c = New System.Windows.Forms.TextBox
        Me.tb20b = New System.Windows.Forms.TextBox
        Me.tb16e = New System.Windows.Forms.TextBox
        Me.tb16d = New System.Windows.Forms.TextBox
        Me.tb15 = New System.Windows.Forms.TextBox
        Me.CheckBox7 = New System.Windows.Forms.CheckBox
        Me.CheckBox6 = New System.Windows.Forms.CheckBox
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.cbIncoterms = New System.Windows.Forms.CheckBox
        Me.cbFrankoPrevoznina = New System.Windows.Forms.CheckBox
        Me.tbIBK = New System.Windows.Forms.TextBox
        Me.cbCUV = New System.Windows.Forms.CheckBox
        Me.cbCIM = New System.Windows.Forms.CheckBox
        Me.tbControl = New System.Windows.Forms.TextBox
        Me.CheckBox8 = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.tbsSatVoza, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbPrevPut
        '
        Me.cmbPrevPut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrevPut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrevPut.Location = New System.Drawing.Point(5, 15)
        Me.cmbPrevPut.Name = "cmbPrevPut"
        Me.cmbPrevPut.Size = New System.Drawing.Size(211, 23)
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
        Me.Button11.Location = New System.Drawing.Point(856, 613)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(72, 40)
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
        Me.btnUpis.Location = New System.Drawing.Point(928, 613)
        Me.btnUpis.Name = "btnUpis"
        Me.btnUpis.Size = New System.Drawing.Size(72, 40)
        Me.btnUpis.TabIndex = 246
        Me.btnUpis.Text = "  Upis"
        Me.btnUpis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnUpis, "Upis u bazu")
        '
        'btnUpravaOtp
        '
        Me.btnUpravaOtp.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnUpravaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnUpravaOtp.Location = New System.Drawing.Point(63, 25)
        Me.btnUpravaOtp.Name = "btnUpravaOtp"
        Me.btnUpravaOtp.Size = New System.Drawing.Size(24, 22)
        Me.btnUpravaOtp.TabIndex = 5
        Me.btnUpravaOtp.Text = "..."
        Me.ToolTip1.SetToolTip(Me.btnUpravaOtp, "Izbor operatera")
        '
        'btnUpravaPr
        '
        Me.btnUpravaPr.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnUpravaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnUpravaPr.Location = New System.Drawing.Point(63, 28)
        Me.btnUpravaPr.Name = "btnUpravaPr"
        Me.btnUpravaPr.Size = New System.Drawing.Size(24, 22)
        Me.btnUpravaPr.TabIndex = 32
        Me.btnUpravaPr.Text = "..."
        Me.ToolTip1.SetToolTip(Me.btnUpravaPr, "Izbor operatera")
        '
        'Button12
        '
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button12.Location = New System.Drawing.Point(928, 655)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(72, 40)
        Me.Button12.TabIndex = 249
        Me.Button12.Text = "  Izlaz"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Button12, "Povratak u osnovni meni")
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(780, 613)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 40)
        Me.Button3.TabIndex = 313
        Me.Button3.Text = "Stampa"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Button3, "Upis u bazu")
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.BackColor = System.Drawing.Color.White
        Me.tbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojOtp.Location = New System.Drawing.Point(5, 78)
        Me.tbBrojOtp.MaxLength = 5
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.Size = New System.Drawing.Size(51, 22)
        Me.tbBrojOtp.TabIndex = 2
        Me.tbBrojOtp.Text = ""
        Me.tbBrojOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbBrojOtp, "Broj otpravljanja")
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
        Me.tbStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaOtp.Location = New System.Drawing.Point(92, 25)
        Me.tbStanicaOtp.MaxLength = 7
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.Size = New System.Drawing.Size(62, 22)
        Me.tbStanicaOtp.TabIndex = 1
        Me.tbStanicaOtp.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbStanicaOtp, "Otpravna stanica")
        '
        'tbUpravaOtp
        '
        Me.tbUpravaOtp.BackColor = System.Drawing.Color.White
        Me.tbUpravaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUpravaOtp.Location = New System.Drawing.Point(5, 25)
        Me.tbUpravaOtp.MaxLength = 4
        Me.tbUpravaOtp.Name = "tbUpravaOtp"
        Me.tbUpravaOtp.Size = New System.Drawing.Size(38, 22)
        Me.tbUpravaOtp.TabIndex = 0
        Me.tbUpravaOtp.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbUpravaOtp, "Otpravna uprava")
        '
        'tbBrojPr
        '
        Me.tbBrojPr.Enabled = False
        Me.tbBrojPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBrojPr.Location = New System.Drawing.Point(5, 83)
        Me.tbBrojPr.MaxLength = 5
        Me.tbBrojPr.Name = "tbBrojPr"
        Me.tbBrojPr.Size = New System.Drawing.Size(51, 22)
        Me.tbBrojPr.TabIndex = 2
        Me.tbBrojPr.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbBrojPr, "Broj prispeca")
        '
        'tbStanicaPr
        '
        Me.tbStanicaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStanicaPr.Location = New System.Drawing.Point(92, 28)
        Me.tbStanicaPr.MaxLength = 7
        Me.tbStanicaPr.Name = "tbStanicaPr"
        Me.tbStanicaPr.Size = New System.Drawing.Size(62, 22)
        Me.tbStanicaPr.TabIndex = 1
        Me.tbStanicaPr.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbStanicaPr, "Stanica prispeca")
        '
        'tbUpravaPr
        '
        Me.tbUpravaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUpravaPr.Location = New System.Drawing.Point(5, 28)
        Me.tbUpravaPr.MaxLength = 4
        Me.tbUpravaPr.Name = "tbUpravaPr"
        Me.tbUpravaPr.Size = New System.Drawing.Size(38, 22)
        Me.tbUpravaPr.TabIndex = 0
        Me.tbUpravaPr.Text = ""
        Me.ToolTip1.SetToolTip(Me.tbUpravaPr, "Uprava prispeca")
        '
        'kbBrojOtp
        '
        Me.kbBrojOtp.BackColor = System.Drawing.Color.White
        Me.kbBrojOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kbBrojOtp.Location = New System.Drawing.Point(64, 78)
        Me.kbBrojOtp.MaxLength = 1
        Me.kbBrojOtp.Name = "kbBrojOtp"
        Me.kbBrojOtp.Size = New System.Drawing.Size(19, 22)
        Me.kbBrojOtp.TabIndex = 3
        Me.kbBrojOtp.Text = ""
        Me.kbBrojOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.kbBrojOtp, "Broj otpravljanja")
        '
        'kbBrojPr
        '
        Me.kbBrojPr.BackColor = System.Drawing.Color.White
        Me.kbBrojPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kbBrojPr.Location = New System.Drawing.Point(64, 83)
        Me.kbBrojPr.MaxLength = 1
        Me.kbBrojPr.Name = "kbBrojPr"
        Me.kbBrojPr.Size = New System.Drawing.Size(19, 22)
        Me.kbBrojPr.TabIndex = 3
        Me.kbBrojPr.Text = ""
        Me.kbBrojPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.kbBrojPr, "Broj otpravljanja")
        '
        'Button19
        '
        Me.Button19.Enabled = False
        Me.Button19.Location = New System.Drawing.Point(780, 656)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(72, 40)
        Me.Button19.TabIndex = 448
        Me.Button19.Text = "Kalkulacija"
        Me.ToolTip1.SetToolTip(Me.Button19, "Upis u bazu")
        '
        'Button22p
        '
        Me.Button22p.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button22p.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button22p.Location = New System.Drawing.Point(608, 304)
        Me.Button22p.Name = "Button22p"
        Me.Button22p.Size = New System.Drawing.Size(80, 24)
        Me.Button22p.TabIndex = 332
        Me.Button22p.Text = "Ponovi"
        Me.ToolTip1.SetToolTip(Me.Button22p, "Upis u bazu")
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button22.Image = CType(resources.GetObject("Button22.Image"), System.Drawing.Image)
        Me.Button22.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button22.Location = New System.Drawing.Point(608, 200)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(80, 56)
        Me.Button22.TabIndex = 331
        Me.Button22.Text = "Prihvati"
        Me.Button22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.Button22, "Upis u bazu")
        '
        'Button21
        '
        Me.Button21.BackColor = System.Drawing.Color.White
        Me.Button21.Image = CType(resources.GetObject("Button21.Image"), System.Drawing.Image)
        Me.Button21.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button21.Location = New System.Drawing.Point(331, 296)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(25, 41)
        Me.Button21.TabIndex = 347
        Me.ToolTip1.SetToolTip(Me.Button21, "Izaberi izjavu posiljaoca")
        '
        'r13
        '
        Me.r13.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.r13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.r13.Location = New System.Drawing.Point(8, 296)
        Me.r13.Name = "r13"
        Me.r13.Size = New System.Drawing.Size(310, 43)
        Me.r13.TabIndex = 346
        Me.ToolTip1.SetToolTip(Me.r13, "Dupli klik misem = brisanje polja")
        '
        'r9
        '
        Me.r9.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.r9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.r9.Location = New System.Drawing.Point(366, 141)
        Me.r9.Name = "r9"
        Me.r9.Size = New System.Drawing.Size(344, 69)
        Me.r9.TabIndex = 345
        Me.ToolTip1.SetToolTip(Me.r9, "Dupli klik misem = brisanje polja")
        '
        'r7
        '
        Me.r7.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.r7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.r7.Location = New System.Drawing.Point(366, 68)
        Me.r7.Name = "r7"
        Me.r7.Size = New System.Drawing.Size(344, 56)
        Me.r7.TabIndex = 344
        Me.ToolTip1.SetToolTip(Me.r7, "Dupli klik misem = brisanje polja")
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.Location = New System.Drawing.Point(286, 801)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(20, 38)
        Me.Button6.TabIndex = 306
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button6, "Izaberi pošiljaoca")
        '
        'Button20
        '
        Me.Button20.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button20.Location = New System.Drawing.Point(384, 792)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(23, 23)
        Me.Button20.TabIndex = 343
        Me.Button20.Text = "X"
        Me.ToolTip1.SetToolTip(Me.Button20, "Izbrisi sadrzaj rubrike 57")
        Me.Button20.Visible = False
        '
        'ComboBox6
        '
        Me.ComboBox6.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox6.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox6.ItemHeight = 14
        Me.ComboBox6.Items.AddRange(New Object() {"RS - Srbija               ", "AL - Albanija             ", "AM - Jermenija            ", "AT - Austrija             ", "AZ - Azerbeidzan          ", "BA - Bosna i Hercegovina  ", "BE - Belgija              ", "BG - Bugarska             ", "BY - Belorusija           ", "CH - Svajcarska           ", "CY - Kipar                ", "CZ - Ceska Republika      ", "DE - Nemacka              ", "DK - Danska               ", "EE - Estonija             ", "ES - Spanija              ", "FI - Finska               ", "FR - Francuska            ", "GB - Velika Britanija     ", "GE - Gruzija              ", "GR - Grcka                ", "HR - Hrvatska             ", "HU - Madjarska            ", "HU - Madjarska            ", "IE - Irska                ", "IQ - Irak                 ", "IR - Iran                 ", "IT - Italija              ", "KZ - Kazahstan            ", "LI - Lihtenstajn          ", "LT - Litvanija            ", "LU - Luksemburg           ", "LV - Letonija             ", "MD - Moldavija            ", "ME - Crna Gora            ", "MK - Makedonija           ", "NL - Holandija            ", "NO - Norveska             ", "PL - Poljska              ", "PT - Portugal             ", "RO - Rumunija             ", "RU - Rusija               ", "SE - Svedska              ", "SI - Slovenija            ", "SK - Slovacka             ", "TR - Turska               ", "UA - Ukrajina             ", "US - SAD                  ", "UZ - Uzbekistan           ", "VI - Devicanska Ostrva    ", "ZF - Federacija BIH       ", "ZS - Republika Srpska     "})
        Me.ComboBox6.Location = New System.Drawing.Point(192, 102)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(65, 22)
        Me.ComboBox6.TabIndex = 336
        Me.ToolTip1.SetToolTip(Me.ComboBox6, "Izbor zemlje")
        '
        'tb4b2
        '
        Me.tb4b2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb4b2.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb4b2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb4b2.Location = New System.Drawing.Point(160, 189)
        Me.tb4b2.Name = "tb4b2"
        Me.tb4b2.Size = New System.Drawing.Size(32, 20)
        Me.tb4b2.TabIndex = 335
        Me.tb4b2.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb4b2, "Zemlja")
        '
        'ComboBox5
        '
        Me.ComboBox5.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox5.ItemHeight = 14
        Me.ComboBox5.Items.AddRange(New Object() {"RS - Srbija               ", "AL - Albanija             ", "AM - Jermenija            ", "AT - Austrija             ", "AZ - Azerbeidzan          ", "BA - Bosna i Hercegovina  ", "BE - Belgija              ", "BG - Bugarska             ", "BY - Belorusija           ", "CH - Svajcarska           ", "CY - Kipar                ", "CZ - Ceska Republika      ", "DE - Nemacka              ", "DK - Danska               ", "EE - Estonija             ", "ES - Spanija              ", "FI - Finska               ", "FR - Francuska            ", "GB - Velika Britanija     ", "GE - Gruzija              ", "GR - Grcka                ", "HR - Hrvatska             ", "HU - Madjarska            ", "HU - Madjarska            ", "IE - Irska                ", "IQ - Irak                 ", "IR - Iran                 ", "IT - Italija              ", "KZ - Kazahstan            ", "LI - Lihtenstajn          ", "LT - Litvanija            ", "LU - Luksemburg           ", "LV - Letonija             ", "MD - Moldavija            ", "ME - Crna Gora            ", "MK - Makedonija           ", "NL - Holandija            ", "NO - Norveska             ", "PL - Poljska              ", "PT - Portugal             ", "RO - Rumunija             ", "RU - Rusija               ", "SE - Svedska              ", "SI - Slovenija            ", "SK - Slovacka             ", "TR - Turska               ", "UA - Ukrajina             ", "US - SAD                  ", "UZ - Uzbekistan           ", "VI - Devicanska Ostrva    ", "ZF - Federacija BIH       ", "ZS - Republika Srpska     "})
        Me.ComboBox5.Location = New System.Drawing.Point(192, 188)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(65, 22)
        Me.ComboBox5.TabIndex = 334
        Me.ToolTip1.SetToolTip(Me.ComboBox5, "Izbor zemlje")
        '
        'tb4b1
        '
        Me.tb4b1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb4b1.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb4b1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb4b1.Location = New System.Drawing.Point(8, 189)
        Me.tb4b1.Name = "tb4b1"
        Me.tb4b1.Size = New System.Drawing.Size(152, 20)
        Me.tb4b1.TabIndex = 333
        Me.tb4b1.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb4b1, "Grad (bez postanskog broja)")
        '
        'tb29b_3
        '
        Me.tb29b_3.BackColor = System.Drawing.Color.Silver
        Me.tb29b_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb29b_3.Location = New System.Drawing.Point(488, 928)
        Me.tb29b_3.MaxLength = 4
        Me.tb29b_3.Name = "tb29b_3"
        Me.tb29b_3.Size = New System.Drawing.Size(40, 20)
        Me.tb29b_3.TabIndex = 332
        Me.tb29b_3.Text = "2009"
        Me.ToolTip1.SetToolTip(Me.tb29b_3, "Datum ispostavljanja tovarnog lista")
        Me.tb29b_3.Visible = False
        '
        'tb29b_2
        '
        Me.tb29b_2.BackColor = System.Drawing.Color.Silver
        Me.tb29b_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb29b_2.Location = New System.Drawing.Point(464, 928)
        Me.tb29b_2.MaxLength = 2
        Me.tb29b_2.Name = "tb29b_2"
        Me.tb29b_2.Size = New System.Drawing.Size(24, 20)
        Me.tb29b_2.TabIndex = 331
        Me.tb29b_2.Text = "12"
        Me.ToolTip1.SetToolTip(Me.tb29b_2, "Datum ispostavljanja tovarnog lista")
        Me.tb29b_2.Visible = False
        '
        'tb29b_1
        '
        Me.tb29b_1.BackColor = System.Drawing.Color.Silver
        Me.tb29b_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb29b_1.Location = New System.Drawing.Point(440, 928)
        Me.tb29b_1.MaxLength = 2
        Me.tb29b_1.Name = "tb29b_1"
        Me.tb29b_1.Size = New System.Drawing.Size(24, 20)
        Me.tb29b_1.TabIndex = 330
        Me.tb29b_1.Text = "31"
        Me.ToolTip1.SetToolTip(Me.tb29b_1, "Datum ispostavljanja tovarnog lista")
        Me.tb29b_1.Visible = False
        '
        'tb1b2
        '
        Me.tb1b2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb1b2.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb1b2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb1b2.Location = New System.Drawing.Point(160, 103)
        Me.tb1b2.Name = "tb1b2"
        Me.tb1b2.Size = New System.Drawing.Size(32, 20)
        Me.tb1b2.TabIndex = 329
        Me.tb1b2.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb1b2, "Zemlja")
        '
        'tb1b1
        '
        Me.tb1b1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb1b1.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb1b1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb1b1.Location = New System.Drawing.Point(8, 103)
        Me.tb1b1.Name = "tb1b1"
        Me.tb1b1.Size = New System.Drawing.Size(152, 20)
        Me.tb1b1.TabIndex = 328
        Me.tb1b1.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb1b1, "Grad (bez postanskog broja)")
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.Location = New System.Drawing.Point(720, 335)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(20, 20)
        Me.Button4.TabIndex = 321
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button4, "Izaberi korisnièku šifru onoga koji plaæa nefrankirane (upuæene) troškove")
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.White
        Me.Button17.Image = CType(resources.GetObject("Button17.Image"), System.Drawing.Image)
        Me.Button17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button17.Location = New System.Drawing.Point(716, 140)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(25, 69)
        Me.Button17.TabIndex = 318
        Me.ToolTip1.SetToolTip(Me.Button17, "Izaberi prilog uz tovarni list")
        '
        'TB58b
        '
        Me.TB58b.BackColor = System.Drawing.Color.Wheat
        Me.TB58b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB58b.Location = New System.Drawing.Point(253, 930)
        Me.TB58b.MaxLength = 4
        Me.TB58b.Name = "TB58b"
        Me.TB58b.Size = New System.Drawing.Size(48, 20)
        Me.TB58b.TabIndex = 317
        Me.TB58b.Text = ""
        Me.ToolTip1.SetToolTip(Me.TB58b, "Šifra preduzeæa")
        '
        'tbPolaznaCarina
        '
        Me.tbPolaznaCarina.BackColor = System.Drawing.Color.SandyBrown
        Me.tbPolaznaCarina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPolaznaCarina.Location = New System.Drawing.Point(560, 495)
        Me.tbPolaznaCarina.MaxLength = 5
        Me.tbPolaznaCarina.Name = "tbPolaznaCarina"
        Me.tbPolaznaCarina.Size = New System.Drawing.Size(56, 20)
        Me.tbPolaznaCarina.TabIndex = 313
        Me.tbPolaznaCarina.Text = ""
        Me.tbPolaznaCarina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbPolaznaCarina, "Šifra polazne carinske ispostave")
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.White
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button9.Location = New System.Drawing.Point(520, 896)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(25, 26)
        Me.Button9.TabIndex = 310
        Me.ToolTip1.SetToolTip(Me.Button9, "Unos podataka o robi i kolima")
        Me.Button9.Visible = False
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.Color.White
        Me.Button18.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button18.Image = CType(resources.GetObject("Button18.Image"), System.Drawing.Image)
        Me.Button18.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button18.Location = New System.Drawing.Point(310, 588)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(20, 47)
        Me.Button18.TabIndex = 296
        Me.ToolTip1.SetToolTip(Me.Button18, "Unos podataka o naknadama za sporedne usluge")
        '
        'TextBox49
        '
        Me.TextBox49.BackColor = System.Drawing.Color.Wheat
        Me.TextBox49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox49.Location = New System.Drawing.Point(360, 756)
        Me.TextBox49.MaxLength = 6
        Me.TextBox49.Name = "TextBox49"
        Me.TextBox49.Size = New System.Drawing.Size(56, 20)
        Me.TextBox49.TabIndex = 295
        Me.TextBox49.Text = ""
        Me.TextBox49.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox49, "Šifra stanice")
        '
        'TextBox51
        '
        Me.TextBox51.BackColor = System.Drawing.Color.Wheat
        Me.TextBox51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox51.Location = New System.Drawing.Point(332, 756)
        Me.TextBox51.MaxLength = 2
        Me.TextBox51.Name = "TextBox51"
        Me.TextBox51.Size = New System.Drawing.Size(24, 20)
        Me.TextBox51.TabIndex = 294
        Me.TextBox51.Text = ""
        Me.TextBox51.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox51, "Šifra frankiranja")
        '
        'TextBox69
        '
        Me.TextBox69.BackColor = System.Drawing.Color.Wheat
        Me.TextBox69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox69.Location = New System.Drawing.Point(360, 732)
        Me.TextBox69.MaxLength = 6
        Me.TextBox69.Name = "TextBox69"
        Me.TextBox69.Size = New System.Drawing.Size(56, 20)
        Me.TextBox69.TabIndex = 293
        Me.TextBox69.Text = ""
        Me.TextBox69.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox69, "Šifra stanice")
        '
        'TextBox70
        '
        Me.TextBox70.BackColor = System.Drawing.Color.Wheat
        Me.TextBox70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox70.Location = New System.Drawing.Point(332, 732)
        Me.TextBox70.MaxLength = 2
        Me.TextBox70.Name = "TextBox70"
        Me.TextBox70.Size = New System.Drawing.Size(24, 20)
        Me.TextBox70.TabIndex = 292
        Me.TextBox70.Text = ""
        Me.TextBox70.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox70, "Šifra frankiranja")
        '
        'TextBox46
        '
        Me.TextBox46.BackColor = System.Drawing.Color.Wheat
        Me.TextBox46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox46.Location = New System.Drawing.Point(74, 732)
        Me.TextBox46.MaxLength = 6
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.Size = New System.Drawing.Size(48, 20)
        Me.TextBox46.TabIndex = 290
        Me.TextBox46.Text = ""
        Me.TextBox46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox46, "Šifra stanice")
        '
        'TextBox47
        '
        Me.TextBox47.BackColor = System.Drawing.Color.Wheat
        Me.TextBox47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox47.Location = New System.Drawing.Point(44, 732)
        Me.TextBox47.MaxLength = 2
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Size = New System.Drawing.Size(24, 20)
        Me.TextBox47.TabIndex = 289
        Me.TextBox47.Text = ""
        Me.TextBox47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox47, "Šifra frankiranja")
        '
        'TextBox48
        '
        Me.TextBox48.BackColor = System.Drawing.Color.Wheat
        Me.TextBox48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox48.Location = New System.Drawing.Point(226, 732)
        Me.TextBox48.MaxLength = 6
        Me.TextBox48.Name = "TextBox48"
        Me.TextBox48.Size = New System.Drawing.Size(80, 20)
        Me.TextBox48.TabIndex = 288
        Me.TextBox48.Text = ""
        Me.TextBox48.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox48, "Raèunska masa")
        '
        'TextBox42
        '
        Me.TextBox42.BackColor = System.Drawing.Color.Wheat
        Me.TextBox42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox42.Location = New System.Drawing.Point(242, 756)
        Me.TextBox42.MaxLength = 6
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.Size = New System.Drawing.Size(64, 20)
        Me.TextBox42.TabIndex = 287
        Me.TextBox42.Text = ""
        Me.TextBox42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox42, "Prevozni stav")
        '
        'TextBox43
        '
        Me.TextBox43.BackColor = System.Drawing.Color.Wheat
        Me.TextBox43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox43.Location = New System.Drawing.Point(179, 756)
        Me.TextBox43.MaxLength = 3
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.Size = New System.Drawing.Size(40, 20)
        Me.TextBox43.TabIndex = 286
        Me.TextBox43.Text = ""
        Me.TextBox43.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox43, "Dodaci/umanjenja")
        '
        'TextBox44
        '
        Me.TextBox44.BackColor = System.Drawing.Color.Wheat
        Me.TextBox44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox44.Location = New System.Drawing.Point(124, 756)
        Me.TextBox44.MaxLength = 3
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.Size = New System.Drawing.Size(32, 20)
        Me.TextBox44.TabIndex = 285
        Me.TextBox44.Text = ""
        Me.TextBox44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox44, "Km/zona")
        '
        'TextBox45
        '
        Me.TextBox45.BackColor = System.Drawing.Color.Wheat
        Me.TextBox45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox45.Location = New System.Drawing.Point(44, 756)
        Me.TextBox45.MaxLength = 6
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.Size = New System.Drawing.Size(57, 20)
        Me.TextBox45.TabIndex = 284
        Me.TextBox45.Text = ""
        Me.TextBox45.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox45, "Korisnièki sporazum ili tarifa")
        '
        'TextBox38
        '
        Me.TextBox38.BackColor = System.Drawing.Color.Wheat
        Me.TextBox38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox38.Location = New System.Drawing.Point(242, 686)
        Me.TextBox38.MaxLength = 6
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New System.Drawing.Size(64, 20)
        Me.TextBox38.TabIndex = 283
        Me.TextBox38.Text = ""
        Me.TextBox38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox38, "Prevozni stav")
        '
        'TextBox39
        '
        Me.TextBox39.BackColor = System.Drawing.Color.Wheat
        Me.TextBox39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox39.Location = New System.Drawing.Point(179, 686)
        Me.TextBox39.MaxLength = 3
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.Size = New System.Drawing.Size(40, 20)
        Me.TextBox39.TabIndex = 282
        Me.TextBox39.Text = ""
        Me.TextBox39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox39, "Dodaci/umanjenja")
        '
        'TextBox40
        '
        Me.TextBox40.BackColor = System.Drawing.Color.Wheat
        Me.TextBox40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox40.Location = New System.Drawing.Point(124, 686)
        Me.TextBox40.MaxLength = 3
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Size = New System.Drawing.Size(32, 20)
        Me.TextBox40.TabIndex = 281
        Me.TextBox40.Text = ""
        Me.TextBox40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox40, "Km/zona")
        '
        'TextBox41
        '
        Me.TextBox41.BackColor = System.Drawing.Color.Wheat
        Me.TextBox41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox41.Location = New System.Drawing.Point(44, 686)
        Me.TextBox41.MaxLength = 6
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Size = New System.Drawing.Size(57, 20)
        Me.TextBox41.TabIndex = 280
        Me.TextBox41.Text = ""
        Me.TextBox41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox41, "Korisnièki sporazum ili tarifa")
        '
        'TextBox28
        '
        Me.TextBox28.BackColor = System.Drawing.Color.Wheat
        Me.TextBox28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox28.Location = New System.Drawing.Point(360, 686)
        Me.TextBox28.MaxLength = 6
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(56, 20)
        Me.TextBox28.TabIndex = 279
        Me.TextBox28.Text = ""
        Me.TextBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox28, "Šifra stanice")
        '
        'TextBox35
        '
        Me.TextBox35.BackColor = System.Drawing.Color.Wheat
        Me.TextBox35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox35.Location = New System.Drawing.Point(332, 686)
        Me.TextBox35.MaxLength = 2
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New System.Drawing.Size(24, 20)
        Me.TextBox35.TabIndex = 278
        Me.TextBox35.Text = ""
        Me.TextBox35.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox35, "Šifra frankiranja")
        '
        'TextBox36
        '
        Me.TextBox36.BackColor = System.Drawing.Color.Wheat
        Me.TextBox36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox36.Location = New System.Drawing.Point(360, 663)
        Me.TextBox36.MaxLength = 6
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New System.Drawing.Size(56, 20)
        Me.TextBox36.TabIndex = 277
        Me.TextBox36.Text = ""
        Me.TextBox36.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox36, "Šifra stanice")
        '
        'TextBox37
        '
        Me.TextBox37.BackColor = System.Drawing.Color.Wheat
        Me.TextBox37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox37.Location = New System.Drawing.Point(332, 663)
        Me.TextBox37.MaxLength = 2
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Size = New System.Drawing.Size(24, 20)
        Me.TextBox37.TabIndex = 276
        Me.TextBox37.Text = ""
        Me.TextBox37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox37, "Šifra frankiranja")
        '
        'tbA79b3
        '
        Me.tbA79b3.BackColor = System.Drawing.Color.Wheat
        Me.tbA79b3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b3.Location = New System.Drawing.Point(360, 615)
        Me.tbA79b3.MaxLength = 6
        Me.tbA79b3.Name = "tbA79b3"
        Me.tbA79b3.Size = New System.Drawing.Size(56, 20)
        Me.tbA79b3.TabIndex = 275
        Me.tbA79b3.Text = ""
        Me.tbA79b3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbA79b3, "Šifra stanice")
        '
        'tbA79a3
        '
        Me.tbA79a3.BackColor = System.Drawing.Color.Wheat
        Me.tbA79a3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a3.Location = New System.Drawing.Point(332, 615)
        Me.tbA79a3.MaxLength = 2
        Me.tbA79a3.Name = "tbA79a3"
        Me.tbA79a3.Size = New System.Drawing.Size(24, 20)
        Me.tbA79a3.TabIndex = 274
        Me.tbA79a3.Text = ""
        Me.tbA79a3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA79a3, "Šifra frankiranja")
        '
        'tbA79b2
        '
        Me.tbA79b2.BackColor = System.Drawing.Color.Wheat
        Me.tbA79b2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b2.Location = New System.Drawing.Point(360, 592)
        Me.tbA79b2.MaxLength = 6
        Me.tbA79b2.Name = "tbA79b2"
        Me.tbA79b2.Size = New System.Drawing.Size(56, 20)
        Me.tbA79b2.TabIndex = 273
        Me.tbA79b2.Text = ""
        Me.tbA79b2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbA79b2, "Šifra stanice")
        '
        'tbA79a2
        '
        Me.tbA79a2.BackColor = System.Drawing.Color.Wheat
        Me.tbA79a2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a2.Location = New System.Drawing.Point(332, 592)
        Me.tbA79a2.MaxLength = 2
        Me.tbA79a2.Name = "tbA79a2"
        Me.tbA79a2.Size = New System.Drawing.Size(24, 20)
        Me.tbA79a2.TabIndex = 272
        Me.tbA79a2.Text = ""
        Me.tbA79a2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA79a2, "Šifra frankiranja")
        '
        'TextBox21
        '
        Me.TextBox21.BackColor = System.Drawing.Color.Wheat
        Me.TextBox21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox21.Location = New System.Drawing.Point(74, 663)
        Me.TextBox21.MaxLength = 6
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(48, 20)
        Me.TextBox21.TabIndex = 270
        Me.TextBox21.Text = ""
        Me.TextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox21, "Šifra stanice")
        '
        'TextBox22
        '
        Me.TextBox22.BackColor = System.Drawing.Color.Wheat
        Me.TextBox22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox22.Location = New System.Drawing.Point(44, 663)
        Me.TextBox22.MaxLength = 2
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(24, 20)
        Me.TextBox22.TabIndex = 269
        Me.TextBox22.Text = ""
        Me.TextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox22, "Šifra frankiranja")
        '
        'TextBox23
        '
        Me.TextBox23.BackColor = System.Drawing.Color.Wheat
        Me.TextBox23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox23.Location = New System.Drawing.Point(226, 663)
        Me.TextBox23.MaxLength = 6
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(80, 20)
        Me.TextBox23.TabIndex = 268
        Me.TextBox23.Text = ""
        Me.TextBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox23, "Raèunska masa")
        '
        'TextBox15
        '
        Me.TextBox15.BackColor = System.Drawing.Color.Wheat
        Me.TextBox15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox15.Location = New System.Drawing.Point(360, 709)
        Me.TextBox15.MaxLength = 6
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(56, 20)
        Me.TextBox15.TabIndex = 267
        Me.TextBox15.Text = ""
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox15, "Šifra stanice")
        '
        'TextBox16
        '
        Me.TextBox16.BackColor = System.Drawing.Color.Wheat
        Me.TextBox16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox16.Location = New System.Drawing.Point(332, 709)
        Me.TextBox16.MaxLength = 2
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(24, 20)
        Me.TextBox16.TabIndex = 266
        Me.TextBox16.Text = ""
        Me.TextBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox16, "Šifra frankiranja")
        '
        'TextBox17
        '
        Me.TextBox17.BackColor = System.Drawing.Color.Wheat
        Me.TextBox17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox17.Location = New System.Drawing.Point(226, 709)
        Me.TextBox17.MaxLength = 6
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(80, 20)
        Me.TextBox17.TabIndex = 265
        Me.TextBox17.Text = ""
        Me.TextBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox17, "Šifra NHM")
        '
        'TextBox18
        '
        Me.TextBox18.BackColor = System.Drawing.Color.Wheat
        Me.TextBox18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox18.Location = New System.Drawing.Point(146, 709)
        Me.TextBox18.MaxLength = 3
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(50, 20)
        Me.TextBox18.TabIndex = 264
        Me.TextBox18.Text = ""
        Me.TextBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox18, "Šifra prevoznog puta")
        '
        'TextBox19
        '
        Me.TextBox19.BackColor = System.Drawing.Color.Wheat
        Me.TextBox19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox19.Location = New System.Drawing.Point(74, 709)
        Me.TextBox19.MaxLength = 6
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(48, 20)
        Me.TextBox19.TabIndex = 263
        Me.TextBox19.Text = ""
        Me.TextBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox19, "Šifra stanice")
        '
        'TextBox20
        '
        Me.TextBox20.BackColor = System.Drawing.Color.Wheat
        Me.TextBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox20.Location = New System.Drawing.Point(44, 709)
        Me.TextBox20.MaxLength = 2
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(24, 20)
        Me.TextBox20.TabIndex = 262
        Me.TextBox20.Text = ""
        Me.TextBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox20, "Šifra zemlje")
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Wheat
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(360, 640)
        Me.TextBox3.MaxLength = 6
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(56, 20)
        Me.TextBox3.TabIndex = 261
        Me.TextBox3.Text = ""
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox3, "Šifra stanice")
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.Wheat
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(332, 640)
        Me.TextBox4.MaxLength = 2
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(24, 20)
        Me.TextBox4.TabIndex = 260
        Me.TextBox4.Text = ""
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox4, "Šifra frankiranja")
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.Wheat
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(226, 640)
        Me.TextBox5.MaxLength = 6
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(80, 20)
        Me.TextBox5.TabIndex = 259
        Me.TextBox5.Text = ""
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox5, "Šifra NHM")
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.Color.Wheat
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(147, 640)
        Me.TextBox8.MaxLength = 3
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(50, 20)
        Me.TextBox8.TabIndex = 258
        Me.TextBox8.Text = ""
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox8, "Šifra prevoznog puta")
        '
        'TextBox9
        '
        Me.TextBox9.BackColor = System.Drawing.Color.Wheat
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(74, 640)
        Me.TextBox9.MaxLength = 6
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(48, 20)
        Me.TextBox9.TabIndex = 257
        Me.TextBox9.Text = ""
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox9, "Šifra stanice")
        '
        'TextBox11
        '
        Me.TextBox11.BackColor = System.Drawing.Color.Wheat
        Me.TextBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(44, 640)
        Me.TextBox11.MaxLength = 2
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(24, 20)
        Me.TextBox11.TabIndex = 256
        Me.TextBox11.Text = ""
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox11, "Šifra zemlje")
        '
        'tb16b
        '
        Me.tb16b.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb16b.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb16b.Location = New System.Drawing.Point(596, 240)
        Me.tb16b.Name = "tb16b"
        Me.tb16b.Size = New System.Drawing.Size(144, 20)
        Me.tb16b.TabIndex = 255
        Me.tb16b.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb16b, "Mesto (ukljuèujuæi stanicu i zemlju) preuzimanja robe na prevoz")
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.Location = New System.Drawing.Point(720, 212)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(20, 22)
        Me.Button7.TabIndex = 254
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button7, "Izaberi korisnièku šifru onoga koji plaæa nefrankirane (upuæene) troškove")
        '
        'btnCarinarnica
        '
        Me.btnCarinarnica.BackColor = System.Drawing.Color.White
        Me.btnCarinarnica.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCarinarnica.Image = CType(resources.GetObject("btnCarinarnica.Image"), System.Drawing.Image)
        Me.btnCarinarnica.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCarinarnica.Location = New System.Drawing.Point(620, 514)
        Me.btnCarinarnica.Name = "btnCarinarnica"
        Me.btnCarinarnica.Size = New System.Drawing.Size(20, 20)
        Me.btnCarinarnica.TabIndex = 252
        Me.btnCarinarnica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnCarinarnica, "Izaberi mesto carinjenja")
        '
        'tbCarinjenje
        '
        Me.tbCarinjenje.BackColor = System.Drawing.Color.SandyBrown
        Me.tbCarinjenje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbCarinjenje.Location = New System.Drawing.Point(560, 514)
        Me.tbCarinjenje.MaxLength = 5
        Me.tbCarinjenje.Name = "tbCarinjenje"
        Me.tbCarinjenje.Size = New System.Drawing.Size(56, 20)
        Me.tbCarinjenje.TabIndex = 250
        Me.tbCarinjenje.Text = ""
        Me.tbCarinjenje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbCarinjenje, "Šifra odredišne carinske ispostave")
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.White
        Me.Button16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button16.Image = CType(resources.GetObject("Button16.Image"), System.Drawing.Image)
        Me.Button16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button16.Location = New System.Drawing.Point(336, 211)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(20, 22)
        Me.Button16.TabIndex = 249
        Me.Button16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button16, "Izaberi pošiljaoca")
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(204, 211)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 22)
        Me.Button2.TabIndex = 248
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button2, "Izaberi pošiljaoca")
        '
        'tbsBrojVoza
        '
        Me.tbsBrojVoza.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.tbsBrojVoza.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbsBrojVoza.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbsBrojVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbsBrojVoza.Location = New System.Drawing.Point(486, 5)
        Me.tbsBrojVoza.MaxLength = 5
        Me.tbsBrojVoza.Name = "tbsBrojVoza"
        Me.tbsBrojVoza.Size = New System.Drawing.Size(55, 16)
        Me.tbsBrojVoza.TabIndex = 231
        Me.tbsBrojVoza.Text = ""
        Me.tbsBrojVoza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbsBrojVoza, "Unos saobracajnog broja voza/trase voza")
        '
        'tbsSatVoza
        '
        Me.tbsSatVoza.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.tbsSatVoza.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbsSatVoza.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbsSatVoza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbsSatVoza.Location = New System.Drawing.Point(488, 25)
        Me.tbsSatVoza.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.tbsSatVoza.Name = "tbsSatVoza"
        Me.tbsSatVoza.Size = New System.Drawing.Size(55, 16)
        Me.tbsSatVoza.TabIndex = 232
        Me.tbsSatVoza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbsSatVoza, "Sat voza")
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.White
        Me.Button15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button15.Location = New System.Drawing.Point(336, 150)
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
        Me.Button14.Location = New System.Drawing.Point(337, 67)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(20, 22)
        Me.Button14.TabIndex = 227
        Me.Button14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button14, "Izaberi korisnièku šifru onoga koji plaæa frankirane troškove")
        '
        'tb52c
        '
        Me.tb52c.BackColor = System.Drawing.Color.Wheat
        Me.tb52c.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb52c.Location = New System.Drawing.Point(707, 865)
        Me.tb52c.MaxLength = 1
        Me.tb52c.Name = "tb52c"
        Me.tb52c.Size = New System.Drawing.Size(32, 21)
        Me.tb52c.TabIndex = 226
        Me.tb52c.Text = ""
        Me.tb52c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb52c, "Kontrolni broj")
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.White
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button13.Location = New System.Drawing.Point(204, 144)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(20, 22)
        Me.Button13.TabIndex = 225
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button13, "Izaberi pošiljaoca")
        '
        'combo73A
        '
        Me.combo73A.BackColor = System.Drawing.Color.Wheat
        Me.combo73A.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo73A.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.combo73A.ItemHeight = 12
        Me.combo73A.Items.AddRange(New Object() {"EUR", "RSD", "USD", "CHF"})
        Me.combo73A.Location = New System.Drawing.Point(147, 592)
        Me.combo73A.Name = "combo73A"
        Me.combo73A.Size = New System.Drawing.Size(50, 20)
        Me.combo73A.TabIndex = 223
        Me.ToolTip1.SetToolTip(Me.combo73A, "Valuta")
        '
        'tbA70b2
        '
        Me.tbA70b2.BackColor = System.Drawing.Color.Wheat
        Me.tbA70b2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA70b2.Location = New System.Drawing.Point(74, 592)
        Me.tbA70b2.MaxLength = 6
        Me.tbA70b2.Name = "tbA70b2"
        Me.tbA70b2.Size = New System.Drawing.Size(48, 20)
        Me.tbA70b2.TabIndex = 222
        Me.tbA70b2.Text = ""
        Me.tbA70b2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA70b2, "Šifra stanice")
        '
        'tbA70a2
        '
        Me.tbA70a2.BackColor = System.Drawing.Color.Wheat
        Me.tbA70a2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA70a2.Location = New System.Drawing.Point(44, 592)
        Me.tbA70a2.MaxLength = 2
        Me.tbA70a2.Name = "tbA70a2"
        Me.tbA70a2.Size = New System.Drawing.Size(24, 20)
        Me.tbA70a2.TabIndex = 221
        Me.tbA70a2.Text = ""
        Me.tbA70a2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA70a2, "Šifra frankiranja")
        '
        'tbA78
        '
        Me.tbA78.BackColor = System.Drawing.Color.Wheat
        Me.tbA78.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA78.Location = New System.Drawing.Point(242, 615)
        Me.tbA78.MaxLength = 6
        Me.tbA78.Name = "tbA78"
        Me.tbA78.Size = New System.Drawing.Size(64, 20)
        Me.tbA78.TabIndex = 220
        Me.tbA78.Text = ""
        Me.tbA78.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA78, "Prevozni stav")
        '
        'tbA77
        '
        Me.tbA77.BackColor = System.Drawing.Color.Wheat
        Me.tbA77.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA77.Location = New System.Drawing.Point(179, 615)
        Me.tbA77.MaxLength = 3
        Me.tbA77.Name = "tbA77"
        Me.tbA77.Size = New System.Drawing.Size(40, 20)
        Me.tbA77.TabIndex = 219
        Me.tbA77.Text = ""
        Me.tbA77.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA77, "Dodaci/umanjenja")
        '
        'tbA76
        '
        Me.tbA76.BackColor = System.Drawing.Color.Wheat
        Me.tbA76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA76.Location = New System.Drawing.Point(124, 615)
        Me.tbA76.MaxLength = 3
        Me.tbA76.Name = "tbA76"
        Me.tbA76.Size = New System.Drawing.Size(32, 20)
        Me.tbA76.TabIndex = 218
        Me.tbA76.Text = ""
        Me.tbA76.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA76, "Km/zona")
        '
        'tbA75
        '
        Me.tbA75.BackColor = System.Drawing.Color.Wheat
        Me.tbA75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA75.Location = New System.Drawing.Point(44, 615)
        Me.tbA75.MaxLength = 6
        Me.tbA75.Name = "tbA75"
        Me.tbA75.Size = New System.Drawing.Size(57, 20)
        Me.tbA75.TabIndex = 217
        Me.tbA75.Text = ""
        Me.tbA75.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA75, "Korisnièki sporazum ili tarifa")
        '
        'tbA74d1
        '
        Me.tbA74d1.BackColor = System.Drawing.Color.Wheat
        Me.tbA74d1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA74d1.Location = New System.Drawing.Point(226, 592)
        Me.tbA74d1.MaxLength = 6
        Me.tbA74d1.Name = "tbA74d1"
        Me.tbA74d1.Size = New System.Drawing.Size(80, 20)
        Me.tbA74d1.TabIndex = 216
        Me.tbA74d1.Text = ""
        Me.tbA74d1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA74d1, "Raèunska masa")
        '
        'tbA79b1
        '
        Me.tbA79b1.BackColor = System.Drawing.Color.Wheat
        Me.tbA79b1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79b1.Location = New System.Drawing.Point(360, 569)
        Me.tbA79b1.MaxLength = 6
        Me.tbA79b1.Name = "tbA79b1"
        Me.tbA79b1.Size = New System.Drawing.Size(56, 20)
        Me.tbA79b1.TabIndex = 214
        Me.tbA79b1.Text = ""
        Me.tbA79b1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tbA79b1, "Šifra stanice")
        '
        'tbA79a1
        '
        Me.tbA79a1.BackColor = System.Drawing.Color.Wheat
        Me.tbA79a1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA79a1.Location = New System.Drawing.Point(332, 569)
        Me.tbA79a1.MaxLength = 2
        Me.tbA79a1.Name = "tbA79a1"
        Me.tbA79a1.Size = New System.Drawing.Size(24, 20)
        Me.tbA79a1.TabIndex = 213
        Me.tbA79a1.Text = ""
        Me.tbA79a1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA79a1, "Šifra frankiranja")
        '
        'tbA72d
        '
        Me.tbA72d.BackColor = System.Drawing.Color.Wheat
        Me.tbA72d.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA72d.Location = New System.Drawing.Point(226, 569)
        Me.tbA72d.MaxLength = 6
        Me.tbA72d.Name = "tbA72d"
        Me.tbA72d.Size = New System.Drawing.Size(80, 20)
        Me.tbA72d.TabIndex = 212
        Me.tbA72d.Text = ""
        Me.tbA72d.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA72d, "Šifra NHM")
        '
        'tb71
        '
        Me.tb71.BackColor = System.Drawing.Color.Wheat
        Me.tb71.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb71.Location = New System.Drawing.Point(147, 569)
        Me.tb71.MaxLength = 3
        Me.tb71.Name = "tb71"
        Me.tb71.Size = New System.Drawing.Size(50, 20)
        Me.tb71.TabIndex = 211
        Me.tb71.Text = ""
        Me.tb71.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb71, "Šifra prevoznog puta")
        '
        'tbA70b1
        '
        Me.tbA70b1.BackColor = System.Drawing.Color.Wheat
        Me.tbA70b1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA70b1.Location = New System.Drawing.Point(74, 569)
        Me.tbA70b1.MaxLength = 6
        Me.tbA70b1.Name = "tbA70b1"
        Me.tbA70b1.Size = New System.Drawing.Size(48, 20)
        Me.tbA70b1.TabIndex = 210
        Me.tbA70b1.Text = ""
        Me.tbA70b1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA70b1, "Šifra stanice")
        '
        'tbA70a1
        '
        Me.tbA70a1.BackColor = System.Drawing.Color.Wheat
        Me.tbA70a1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbA70a1.Location = New System.Drawing.Point(44, 569)
        Me.tbA70a1.MaxLength = 2
        Me.tbA70a1.Name = "tbA70a1"
        Me.tbA70a1.Size = New System.Drawing.Size(24, 20)
        Me.tbA70a1.TabIndex = 209
        Me.tbA70a1.Text = ""
        Me.tbA70a1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tbA70a1, "Šifra zemlje")
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.Location = New System.Drawing.Point(716, 743)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(26, 32)
        Me.Button8.TabIndex = 208
        Me.ToolTip1.SetToolTip(Me.Button8, "Izaberi razlog produženja isporuke")
        '
        'tb49g
        '
        Me.tb49g.BackColor = System.Drawing.Color.Wheat
        Me.tb49g.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb49g.Location = New System.Drawing.Point(642, 568)
        Me.tb49g.MaxLength = 2
        Me.tb49g.Name = "tb49g"
        Me.tb49g.Size = New System.Drawing.Size(24, 20)
        Me.tb49g.TabIndex = 202
        Me.tb49g.Text = ""
        Me.tb49g.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb49g, "Šifra zemlje")
        '
        'tb49f
        '
        Me.tb49f.BackColor = System.Drawing.Color.Wheat
        Me.tb49f.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb49f.Location = New System.Drawing.Point(618, 568)
        Me.tb49f.MaxLength = 2
        Me.tb49f.Name = "tb49f"
        Me.tb49f.Size = New System.Drawing.Size(24, 20)
        Me.tb49f.TabIndex = 201
        Me.tb49f.Text = ""
        Me.tb49f.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb49f, "Šifra troškova koji pada na teret pošiljaoca")
        '
        'tb49e
        '
        Me.tb49e.BackColor = System.Drawing.Color.Wheat
        Me.tb49e.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb49e.Location = New System.Drawing.Point(594, 568)
        Me.tb49e.MaxLength = 2
        Me.tb49e.Name = "tb49e"
        Me.tb49e.Size = New System.Drawing.Size(24, 20)
        Me.tb49e.TabIndex = 200
        Me.tb49e.Text = ""
        Me.tb49e.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb49e, "Šifra troškova koji pada na teret pošiljaoca")
        '
        'tb49d
        '
        Me.tb49d.BackColor = System.Drawing.Color.Wheat
        Me.tb49d.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb49d.Location = New System.Drawing.Point(570, 568)
        Me.tb49d.MaxLength = 2
        Me.tb49d.Name = "tb49d"
        Me.tb49d.Size = New System.Drawing.Size(24, 20)
        Me.tb49d.TabIndex = 199
        Me.tb49d.Text = ""
        Me.tb49d.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb49d, "Šifra troškova koji pada na teret pošiljaoca")
        '
        'tb49c
        '
        Me.tb49c.BackColor = System.Drawing.Color.Wheat
        Me.tb49c.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb49c.Location = New System.Drawing.Point(546, 568)
        Me.tb49c.MaxLength = 2
        Me.tb49c.Name = "tb49c"
        Me.tb49c.Size = New System.Drawing.Size(24, 20)
        Me.tb49c.TabIndex = 198
        Me.tb49c.Text = ""
        Me.tb49c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb49c, "Šifra troškova koji pada na teret pošiljaoca")
        '
        'tb49b
        '
        Me.tb49b.BackColor = System.Drawing.Color.Wheat
        Me.tb49b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb49b.Location = New System.Drawing.Point(522, 568)
        Me.tb49b.MaxLength = 2
        Me.tb49b.Name = "tb49b"
        Me.tb49b.Size = New System.Drawing.Size(24, 20)
        Me.tb49b.TabIndex = 197
        Me.tb49b.Text = ""
        Me.tb49b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb49b, "Šifra troškova koji pada na teret pošiljaoca")
        '
        'tb59b
        '
        Me.tb59b.BackColor = System.Drawing.Color.Wheat
        Me.tb59b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb59b.Location = New System.Drawing.Point(326, 888)
        Me.tb59b.MaxLength = 4
        Me.tb59b.Name = "tb59b"
        Me.tb59b.Size = New System.Drawing.Size(88, 20)
        Me.tb59b.TabIndex = 189
        Me.tb59b.Text = ""
        Me.tb59b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb59b, "Broj prispeca ")
        '
        'tb59a
        '
        Me.tb59a.BackColor = System.Drawing.Color.Wheat
        Me.tb59a.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb59a.Location = New System.Drawing.Point(326, 868)
        Me.tb59a.Name = "tb59a"
        Me.tb59a.Size = New System.Drawing.Size(88, 21)
        Me.tb59a.TabIndex = 188
        Me.tb59a.Text = ""
        Me.tb59a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb59a, "Datum prispeca posiljke u uputnu stanicu")
        '
        'tb28
        '
        Me.tb28.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb28.Location = New System.Drawing.Point(646, 513)
        Me.tb28.MaxLength = 4
        Me.tb28.Name = "tb28"
        Me.tb28.Size = New System.Drawing.Size(96, 20)
        Me.tb28.TabIndex = 187
        Me.tb28.Text = "0"
        Me.tb28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb28, "Pouzece")
        '
        'tb27
        '
        Me.tb27.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb27.Location = New System.Drawing.Point(646, 465)
        Me.tb27.MaxLength = 4
        Me.tb27.Name = "tb27"
        Me.tb27.Size = New System.Drawing.Size(96, 20)
        Me.tb27.TabIndex = 186
        Me.tb27.Text = "0"
        Me.tb27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb27, "Obezbedjenje uredne isporuke")
        '
        'btnUnosRobe
        '
        Me.btnUnosRobe.BackColor = System.Drawing.Color.White
        Me.btnUnosRobe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUnosRobe.Image = CType(resources.GetObject("btnUnosRobe.Image"), System.Drawing.Image)
        Me.btnUnosRobe.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUnosRobe.Location = New System.Drawing.Point(536, 278)
        Me.btnUnosRobe.Name = "btnUnosRobe"
        Me.btnUnosRobe.Size = New System.Drawing.Size(25, 26)
        Me.btnUnosRobe.TabIndex = 185
        Me.ToolTip1.SetToolTip(Me.btnUnosRobe, "Unos podataka o robi i kolima")
        '
        'tb4c
        '
        Me.tb4c.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb4c.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb4c.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb4c.Location = New System.Drawing.Point(257, 189)
        Me.tb4c.Name = "tb4c"
        Me.tb4c.Size = New System.Drawing.Size(98, 20)
        Me.tb4c.TabIndex = 184
        Me.tb4c.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb4c, "Telefon/Fax")
        '
        'tb10b
        '
        Me.tb10b.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb10b.Location = New System.Drawing.Point(254, 249)
        Me.tb10b.Name = "tb10b"
        Me.tb10b.Size = New System.Drawing.Size(104, 20)
        Me.tb10b.TabIndex = 183
        Me.tb10b.Text = ""
        Me.tb10b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb10b, "Uputna zemlja")
        '
        'tb52e
        '
        Me.tb52e.BackColor = System.Drawing.Color.Wheat
        Me.tb52e.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb52e.Location = New System.Drawing.Point(635, 886)
        Me.tb52e.MaxLength = 6
        Me.tb52e.Name = "tb52e"
        Me.tb52e.Size = New System.Drawing.Size(104, 21)
        Me.tb52e.TabIndex = 181
        Me.tb52e.Text = ""
        Me.tb52e.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb52e, "Broj otpravljanja (6 cifara: 5 + kontrolni broj)")
        '
        'tb52d
        '
        Me.tb52d.BackColor = System.Drawing.Color.Wheat
        Me.tb52d.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb52d.Location = New System.Drawing.Point(588, 886)
        Me.tb52d.MaxLength = 4
        Me.tb52d.Name = "tb52d"
        Me.tb52d.Size = New System.Drawing.Size(47, 21)
        Me.tb52d.TabIndex = 179
        Me.tb52d.Text = ""
        Me.tb52d.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb52d, "Šifra prevoznika")
        '
        'tb52b
        '
        Me.tb52b.BackColor = System.Drawing.Color.Wheat
        Me.tb52b.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb52b.Location = New System.Drawing.Point(635, 865)
        Me.tb52b.MaxLength = 5
        Me.tb52b.Name = "tb52b"
        Me.tb52b.Size = New System.Drawing.Size(72, 21)
        Me.tb52b.TabIndex = 177
        Me.tb52b.Text = ""
        Me.tb52b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb52b, "Šifra stanice")
        '
        'tb52a
        '
        Me.tb52a.BackColor = System.Drawing.Color.Wheat
        Me.tb52a.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb52a.Location = New System.Drawing.Point(588, 865)
        Me.tb52a.MaxLength = 2
        Me.tb52a.Name = "tb52a"
        Me.tb52a.Size = New System.Drawing.Size(47, 21)
        Me.tb52a.TabIndex = 176
        Me.tb52a.Text = ""
        Me.tb52a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb52a, "Šifra zemlje")
        '
        'TextBox66
        '
        Me.TextBox66.BackColor = System.Drawing.Color.Wheat
        Me.TextBox66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox66.Location = New System.Drawing.Point(446, 867)
        Me.TextBox66.MaxLength = 2
        Me.TextBox66.Name = "TextBox66"
        Me.TextBox66.Size = New System.Drawing.Size(32, 20)
        Me.TextBox66.TabIndex = 167
        Me.TextBox66.Text = ""
        Me.TextBox66.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox66, "Stavljeno na raspolaganje: mesec-dan-èas")
        '
        'TextBox67
        '
        Me.TextBox67.BackColor = System.Drawing.Color.Wheat
        Me.TextBox67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox67.Location = New System.Drawing.Point(510, 867)
        Me.TextBox67.MaxLength = 2
        Me.TextBox67.Name = "TextBox67"
        Me.TextBox67.Size = New System.Drawing.Size(32, 20)
        Me.TextBox67.TabIndex = 169
        Me.TextBox67.Text = ""
        Me.TextBox67.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox67, "Stavljeno na raspolaganje: mesec-dan-èas")
        '
        'TextBox68
        '
        Me.TextBox68.BackColor = System.Drawing.Color.Wheat
        Me.TextBox68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox68.Location = New System.Drawing.Point(478, 867)
        Me.TextBox68.MaxLength = 2
        Me.TextBox68.Name = "TextBox68"
        Me.TextBox68.Size = New System.Drawing.Size(32, 20)
        Me.TextBox68.TabIndex = 168
        Me.TextBox68.Text = ""
        Me.TextBox68.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox68, "Stavljeno na raspolaganje: mesec-dan-èas")
        '
        'TB58a2
        '
        Me.TB58a2.BackColor = System.Drawing.Color.Wheat
        Me.TB58a2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB58a2.Location = New System.Drawing.Point(37, 888)
        Me.TB58a2.MaxLength = 35
        Me.TB58a2.Name = "TB58a2"
        Me.TB58a2.Size = New System.Drawing.Size(267, 20)
        Me.TB58a2.TabIndex = 161
        Me.TB58a2.Text = "ZELEZNICE SRBIJE"
        Me.ToolTip1.SetToolTip(Me.TB58a2, "Naziv preduzeæa")
        '
        'TB58a1
        '
        Me.TB58a1.BackColor = System.Drawing.Color.Wheat
        Me.TB58a1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB58a1.Location = New System.Drawing.Point(37, 869)
        Me.TB58a1.MaxLength = 4
        Me.TB58a1.Name = "TB58a1"
        Me.TB58a1.Size = New System.Drawing.Size(48, 20)
        Me.TB58a1.TabIndex = 160
        Me.TB58a1.Text = "0072"
        Me.ToolTip1.SetToolTip(Me.TB58a1, "Šifra preduzeæa")
        '
        'tb51a
        '
        Me.tb51a.BackColor = System.Drawing.Color.Wheat
        Me.tb51a.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb51a.Location = New System.Drawing.Point(493, 640)
        Me.tb51a.MaxLength = 2
        Me.tb51a.Multiline = True
        Me.tb51a.Name = "tb51a"
        Me.tb51a.Size = New System.Drawing.Size(136, 20)
        Me.tb51a.TabIndex = 128
        Me.tb51a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb51a, "Upisuje se naziv i šifra stanice u kojoj treba da se obave carinske i druge admin" & _
        "istrativne formalnosti")
        '
        'tb50
        '
        Me.tb50.BackColor = System.Drawing.Color.Wheat
        Me.tb50.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb50.Location = New System.Drawing.Point(497, 596)
        Me.tb50.MaxLength = 200
        Me.tb50.Multiline = True
        Me.tb50.Name = "tb50"
        Me.tb50.Size = New System.Drawing.Size(243, 40)
        Me.tb50.TabIndex = 126
        Me.tb50.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb50, "Podatak o stvarnom prevoznom putu uz korišæenje šifara koje važe za granice")
        '
        'tb49h
        '
        Me.tb49h.BackColor = System.Drawing.Color.Wheat
        Me.tb49h.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb49h.Location = New System.Drawing.Point(666, 568)
        Me.tb49h.MaxLength = 2
        Me.tb49h.Name = "tb49h"
        Me.tb49h.Size = New System.Drawing.Size(75, 20)
        Me.tb49h.TabIndex = 124
        Me.tb49h.Text = ""
        Me.tb49h.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb49h, "Šifra stanice")
        '
        'tb49a
        '
        Me.tb49a.BackColor = System.Drawing.Color.Wheat
        Me.tb49a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb49a.Location = New System.Drawing.Point(497, 568)
        Me.tb49a.MaxLength = 2
        Me.tb49a.Name = "tb49a"
        Me.tb49a.Size = New System.Drawing.Size(24, 20)
        Me.tb49a.TabIndex = 117
        Me.tb49a.Text = "10"
        Me.tb49a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb49a, "Šifra frankiranja")
        '
        'tb29b
        '
        Me.tb29b.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb29b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb29b.Location = New System.Drawing.Point(678, 928)
        Me.tb29b.Name = "tb29b"
        Me.tb29b.Size = New System.Drawing.Size(64, 20)
        Me.tb29b.TabIndex = 113
        Me.tb29b.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb29b, "Datum ispostavljanja tovarnog lista")
        '
        'tb29a
        '
        Me.tb29a.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb29a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb29a.Location = New System.Drawing.Point(556, 928)
        Me.tb29a.Name = "tb29a"
        Me.tb29a.Size = New System.Drawing.Size(122, 20)
        Me.tb29a.TabIndex = 1
        Me.tb29a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb29a, "Mesto ispostavljanja tovarnog lista")
        '
        'cbVal28
        '
        Me.cbVal28.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cbVal28.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVal28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbVal28.ItemHeight = 13
        Me.cbVal28.Items.AddRange(New Object() {"EUR", "RSD", "USD", "CHF"})
        Me.cbVal28.Location = New System.Drawing.Point(678, 491)
        Me.cbVal28.Name = "cbVal28"
        Me.cbVal28.Size = New System.Drawing.Size(65, 21)
        Me.cbVal28.TabIndex = 59
        Me.ToolTip1.SetToolTip(Me.cbVal28, "Izbor valute")
        '
        'tb26
        '
        Me.tb26.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb26.Location = New System.Drawing.Point(646, 419)
        Me.tb26.MaxLength = 4
        Me.tb26.Name = "tb26"
        Me.tb26.Size = New System.Drawing.Size(96, 20)
        Me.tb26.TabIndex = 57
        Me.tb26.Text = "0"
        Me.tb26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb26, "Vrednost robe")
        '
        'cbVal27
        '
        Me.cbVal27.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cbVal27.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVal27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbVal27.ItemHeight = 13
        Me.cbVal27.Items.AddRange(New Object() {"EUR", "RSD", "USD", "CHF"})
        Me.cbVal27.Location = New System.Drawing.Point(678, 443)
        Me.cbVal27.Name = "cbVal27"
        Me.cbVal27.Size = New System.Drawing.Size(65, 21)
        Me.cbVal27.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.cbVal27, "Izbor valute")
        '
        'cbVal26
        '
        Me.cbVal26.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cbVal26.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVal26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbVal26.ItemHeight = 13
        Me.cbVal26.Items.AddRange(New Object() {"EUR", "RSD", "USD", "CHF"})
        Me.cbVal26.Location = New System.Drawing.Point(678, 396)
        Me.cbVal26.Name = "cbVal26"
        Me.cbVal26.Size = New System.Drawing.Size(64, 21)
        Me.cbVal26.TabIndex = 56
        Me.ToolTip1.SetToolTip(Me.cbVal26, "Izbor valute")
        '
        'tb17
        '
        Me.tb17.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb17.Location = New System.Drawing.Point(631, 213)
        Me.tb17.MaxLength = 8
        Me.tb17.Name = "tb17"
        Me.tb17.Size = New System.Drawing.Size(81, 20)
        Me.tb17.TabIndex = 96
        Me.tb17.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb17, "Šifra mesta preuzimanja na prevoz")
        '
        'tb16a
        '
        Me.tb16a.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb16a.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb16a.Location = New System.Drawing.Point(368, 240)
        Me.tb16a.Name = "tb16a"
        Me.tb16a.Size = New System.Drawing.Size(210, 20)
        Me.tb16a.TabIndex = 95
        Me.tb16a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb16a, "Mesto (ukljuèujuæi stanicu i zemlju) preuzimanja robe na prevoz")
        '
        'tb14a
        '
        Me.tb14a.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb14a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb14a.Location = New System.Drawing.Point(220, 274)
        Me.tb14a.MaxLength = 1
        Me.tb14a.Name = "tb14a"
        Me.tb14a.Size = New System.Drawing.Size(20, 20)
        Me.tb14a.TabIndex = 85
        Me.tb14a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb14a, "1=korisnièki sporazum, 2=tarifa")
        '
        'tb14b
        '
        Me.tb14b.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb14b.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb14b.Location = New System.Drawing.Point(254, 274)
        Me.tb14b.MaxLength = 6
        Me.tb14b.Name = "tb14b"
        Me.tb14b.Size = New System.Drawing.Size(104, 20)
        Me.tb14b.TabIndex = 84
        Me.tb14b.Text = ""
        Me.tb14b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.tb14b, "Broj korisnièkog sporazuma ili tarife")
        '
        'TextBox34
        '
        Me.TextBox34.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.TextBox34.Cursor = System.Windows.Forms.Cursors.Help
        Me.TextBox34.Location = New System.Drawing.Point(134, 213)
        Me.TextBox34.MaxLength = 6
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New System.Drawing.Size(64, 20)
        Me.TextBox34.TabIndex = 79
        Me.TextBox34.Text = ""
        Me.ToolTip1.SetToolTip(Me.TextBox34, "Šifra mesta izdavanja")
        '
        'TextBox33
        '
        Me.TextBox33.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.TextBox33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox33.Location = New System.Drawing.Point(677, 46)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New System.Drawing.Size(65, 20)
        Me.TextBox33.TabIndex = 78
        Me.TextBox33.Text = ""
        Me.ToolTip1.SetToolTip(Me.TextBox33, "Broj obaveštenja")
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.Location = New System.Drawing.Point(716, 67)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(25, 56)
        Me.Button5.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.Button5, "Izaberi izjavu posiljaoca")
        '
        'tb4a
        '
        Me.tb4a.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb4a.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb4a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb4a.Location = New System.Drawing.Point(8, 144)
        Me.tb4a.MaxLength = 35
        Me.tb4a.Name = "tb4a"
        Me.tb4a.Size = New System.Drawing.Size(184, 20)
        Me.tb4a.TabIndex = 29
        Me.tb4a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb4a, "Ime ili naziv")
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(200, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 22)
        Me.Button1.TabIndex = 24
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button1, "Izaberi pošiljaoca")
        '
        'tb1a
        '
        Me.tb1a.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb1a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb1a.Location = New System.Drawing.Point(8, 60)
        Me.tb1a.MaxLength = 35
        Me.tb1a.Name = "tb1a"
        Me.tb1a.Size = New System.Drawing.Size(184, 20)
        Me.tb1a.TabIndex = 19
        Me.tb1a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb1a, "Ime ili naziv")
        '
        'comboIncoterms
        '
        Me.comboIncoterms.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.comboIncoterms.Cursor = System.Windows.Forms.Cursors.Hand
        Me.comboIncoterms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboIncoterms.Enabled = False
        Me.comboIncoterms.ItemHeight = 13
        Me.comboIncoterms.Items.AddRange(New Object() {"EXW - sve placa primalac", "FCA - franko organizator prevoza", "CPT - franko do odredista", "CIP - franko osigurano do odredista", "DAF - placa posiljalac do granice", "DDU - placa posiljalac do mesta izdavanja", "DDP - placa posiljalac do mesta izdavanja"})
        Me.comboIncoterms.Location = New System.Drawing.Point(494, 367)
        Me.comboIncoterms.Name = "comboIncoterms"
        Me.comboIncoterms.Size = New System.Drawing.Size(249, 21)
        Me.comboIncoterms.TabIndex = 46
        Me.ToolTip1.SetToolTip(Me.comboIncoterms, "Izaberi Incoterms")
        '
        'tb1c
        '
        Me.tb1c.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb1c.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb1c.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb1c.Location = New System.Drawing.Point(257, 103)
        Me.tb1c.Name = "tb1c"
        Me.tb1c.Size = New System.Drawing.Size(98, 20)
        Me.tb1c.TabIndex = 35
        Me.tb1c.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb1c, "Telefon/Fax")
        '
        'tb6
        '
        Me.tb6.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb6.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb6.Location = New System.Drawing.Point(257, 151)
        Me.tb6.Name = "tb6"
        Me.tb6.Size = New System.Drawing.Size(74, 20)
        Me.tb6.TabIndex = 34
        Me.tb6.Text = ""
        Me.tb6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb6, "Korisnièka šifra onoga koji plaæa nefrankirane (upuæene) troškove")
        '
        'tb4b
        '
        Me.tb4b.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb4b.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb4b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb4b.Location = New System.Drawing.Point(8, 165)
        Me.tb4b.Name = "tb4b"
        Me.tb4b.Size = New System.Drawing.Size(184, 20)
        Me.tb4b.TabIndex = 30
        Me.tb4b.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb4b, "Adresa")
        '
        'tb5
        '
        Me.tb5.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb5.Location = New System.Drawing.Point(257, 128)
        Me.tb5.Name = "tb5"
        Me.tb5.Size = New System.Drawing.Size(74, 20)
        Me.tb5.TabIndex = 28
        Me.tb5.Text = "0"
        Me.tb5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb5, "Korisnicka sifra primaoca")
        '
        'tb3
        '
        Me.tb3.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb3.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb3.Location = New System.Drawing.Point(257, 68)
        Me.tb3.Name = "tb3"
        Me.tb3.Size = New System.Drawing.Size(74, 20)
        Me.tb3.TabIndex = 27
        Me.tb3.Text = ""
        Me.tb3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb3, "Korisnicka sifra onoga koji placa frankirane troskove")
        '
        'tb1b
        '
        Me.tb1b.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb1b.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb1b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb1b.Location = New System.Drawing.Point(8, 81)
        Me.tb1b.Name = "tb1b"
        Me.tb1b.Size = New System.Drawing.Size(184, 20)
        Me.tb1b.TabIndex = 25
        Me.tb1b.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb1b, "Adresa")
        '
        'tb10a
        '
        Me.tb10a.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb10a.Location = New System.Drawing.Point(46, 249)
        Me.tb10a.Name = "tb10a"
        Me.tb10a.Size = New System.Drawing.Size(168, 20)
        Me.tb10a.TabIndex = 23
        Me.tb10a.Text = ""
        Me.ToolTip1.SetToolTip(Me.tb10a, "Naziv uputne stanice")
        '
        'tb12
        '
        Me.tb12.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb12.Location = New System.Drawing.Point(254, 213)
        Me.tb12.MaxLength = 8
        Me.tb12.Name = "tb12"
        Me.tb12.Size = New System.Drawing.Size(74, 20)
        Me.tb12.TabIndex = 15
        Me.tb12.Text = ""
        Me.tb12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb12, "Šifra stanice koja se nalazi u mestu izdavanja")
        '
        'tb2
        '
        Me.tb2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb2.Cursor = System.Windows.Forms.Cursors.Help
        Me.tb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb2.Location = New System.Drawing.Point(257, 45)
        Me.tb2.Name = "tb2"
        Me.tb2.Size = New System.Drawing.Size(74, 20)
        Me.tb2.TabIndex = 3
        Me.tb2.Text = "0"
        Me.tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.tb2, "Korisnicka sifra posiljaoca")
        '
        'Button23
        '
        Me.Button23.Image = CType(resources.GetObject("Button23.Image"), System.Drawing.Image)
        Me.Button23.Location = New System.Drawing.Point(656, 8)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(32, 32)
        Me.Button23.TabIndex = 336
        Me.ToolTip1.SetToolTip(Me.Button23, "Ponisti")
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button24.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button24.Location = New System.Drawing.Point(432, 56)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(88, 32)
        Me.Button24.TabIndex = 338
        Me.Button24.Text = "Izaberi  prelaz"
        Me.ToolTip1.SetToolTip(Me.Button24, "Upis u bazu")
        Me.Button24.Visible = False
        '
        'Button26
        '
        Me.Button26.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button26.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button26.Location = New System.Drawing.Point(608, 256)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(80, 47)
        Me.Button26.TabIndex = 339
        Me.Button26.Text = "Izmeni operatera"
        Me.ToolTip1.SetToolTip(Me.Button26, "Upis u bazu")
        '
        'btnOperaterAdd
        '
        Me.btnOperaterAdd.BackColor = System.Drawing.Color.PapayaWhip
        Me.btnOperaterAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOperaterAdd.Location = New System.Drawing.Point(178, 327)
        Me.btnOperaterAdd.Name = "btnOperaterAdd"
        Me.btnOperaterAdd.Size = New System.Drawing.Size(48, 20)
        Me.btnOperaterAdd.TabIndex = 341
        Me.btnOperaterAdd.Text = "Izaberi"
        Me.ToolTip1.SetToolTip(Me.btnOperaterAdd, "Upis u bazu")
        Me.btnOperaterAdd.Visible = False
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
        Me.GroupBox2.Location = New System.Drawing.Point(888, 664)
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
        Me.tbPrevoznina.Location = New System.Drawing.Point(7, 15)
        Me.tbPrevoznina.MaxLength = 12
        Me.tbPrevoznina.Name = "tbPrevoznina"
        Me.tbPrevoznina.Size = New System.Drawing.Size(145, 22)
        Me.tbPrevoznina.TabIndex = 232
        Me.tbPrevoznina.Text = ""
        Me.tbPrevoznina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbSaobracaj
        '
        Me.gbSaobracaj.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gbSaobracaj.Controls.Add(Me.rbKolska)
        Me.gbSaobracaj.Controls.Add(Me.rbDencana)
        Me.gbSaobracaj.Location = New System.Drawing.Point(904, 3)
        Me.gbSaobracaj.Name = "gbSaobracaj"
        Me.gbSaobracaj.Size = New System.Drawing.Size(96, 77)
        Me.gbSaobracaj.TabIndex = 235
        Me.gbSaobracaj.TabStop = False
        Me.gbSaobracaj.Text = " [ POSILJKA ]  "
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
        Me.ComboBox1.Items.AddRange(New Object() {"1. Spt 38", "2. Tea 9291", "3. Ugovor"})
        Me.ComboBox1.Location = New System.Drawing.Point(6, 16)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(210, 23)
        Me.ComboBox1.TabIndex = 237
        '
        'tbUgovor
        '
        Me.tbUgovor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUgovor.Location = New System.Drawing.Point(6, 64)
        Me.tbUgovor.MaxLength = 6
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(56, 21)
        Me.tbUgovor.TabIndex = 239
        Me.tbUgovor.Text = ""
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.Items.AddRange(New Object() {"1. Pojedinacna", "2. Grupa kola", "3. Voz"})
        Me.ComboBox2.Location = New System.Drawing.Point(64, 63)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(152, 23)
        Me.ComboBox2.TabIndex = 240
        '
        'Label5
        '
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(92, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 23)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "Nacin prevoza"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbUgovor)
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Location = New System.Drawing.Point(780, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(220, 91)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ IZBOR TARIFE ] "
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(6, 42)
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
        Me.GroupBox3.Location = New System.Drawing.Point(780, 251)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(220, 56)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " [ TRANZITNE NALEPNICE ]"
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox10.Controls.Add(Me.cbSmer1)
        Me.GroupBox10.Controls.Add(Me.cbSmer2)
        Me.GroupBox10.Controls.Add(Me.Label33)
        Me.GroupBox10.Controls.Add(Me.Label32)
        Me.GroupBox10.Location = New System.Drawing.Point(780, 165)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(220, 88)
        Me.GroupBox10.TabIndex = 2
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "[ IZBOR PRAVCA ]"
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
        Me.cbSmer2.Items.AddRange(New Object() {"1 - 23499 Subotica", "2 - 22899 Kikinda", "3 - 21099 Vrsac", "4 - 12498 Dimitrovgrad", "5 - 11028 Presevo", "6 - 15723 Prijepolje Teretna", "7 - 16319 Brasina", "8 - 16517 Sid", "9 - 25471 Bogojevo"})
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
        Me.GroupBox4.Controls.Add(Me.Button25)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.kbBrojOtp)
        Me.GroupBox4.Controls.Add(Me.DatumOtp)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.tbBrojOtp)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.tbStanicaOtp)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.tbUpravaOtp)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.Controls.Add(Me.btnStanicaOtp)
        Me.GroupBox4.Controls.Add(Me.btnUpravaOtp)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(780, 304)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(220, 105)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = " [ OTPRAVLJANJE ] "
        '
        'Button25
        '
        Me.Button25.Location = New System.Drawing.Point(168, 8)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(48, 16)
        Me.Button25.TabIndex = 230
        Me.Button25.Text = "valid"
        Me.Button25.Visible = False
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(56, 79)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(8, 16)
        Me.Label22.TabIndex = 228
        Me.Label22.Text = "-"
        '
        'DatumOtp
        '
        Me.DatumOtp.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.DatumOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOtp.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOtp.Location = New System.Drawing.Point(92, 77)
        Me.DatumOtp.Name = "DatumOtp"
        Me.DatumOtp.Size = New System.Drawing.Size(124, 22)
        Me.DatumOtp.TabIndex = 4
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
        Me.Label10.Location = New System.Drawing.Point(93, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 11)
        Me.Label10.TabIndex = 227
        Me.Label10.Text = "Stanica"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 11)
        Me.Label4.TabIndex = 226
        Me.Label4.Text = "Operater"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(92, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 15)
        Me.Label12.TabIndex = 37
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label11
        '
        Me.Label11.Enabled = False
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(5, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 15)
        Me.Label11.TabIndex = 36
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(160, 25)
        Me.TextBox1.MaxLength = 1
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(15, 22)
        Me.TextBox1.TabIndex = 51
        Me.TextBox1.Text = ""
        '
        'btnStanicaOtp
        '
        Me.btnStanicaOtp.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnStanicaOtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnStanicaOtp.Location = New System.Drawing.Point(192, 25)
        Me.btnStanicaOtp.Name = "btnStanicaOtp"
        Me.btnStanicaOtp.Size = New System.Drawing.Size(24, 22)
        Me.btnStanicaOtp.TabIndex = 6
        Me.btnStanicaOtp.Text = "..."
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox5.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox5.Controls.Add(Me.tbBrojPr)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.tbStanicaPr)
        Me.GroupBox5.Controls.Add(Me.tbUpravaPr)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.btnStanicaPr)
        Me.GroupBox5.Controls.Add(Me.btnUpravaPr)
        Me.GroupBox5.Controls.Add(Me.TextBox2)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.kbBrojPr)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(780, 408)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(220, 112)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = " [ PRISPECE ] "
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(92, 83)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(124, 22)
        Me.DateTimePicker2.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.Enabled = False
        Me.Label20.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label20.Location = New System.Drawing.Point(95, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 11)
        Me.Label20.TabIndex = 231
        Me.Label20.Text = "Datum"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label21
        '
        Me.Label21.Enabled = False
        Me.Label21.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 72)
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
        Me.Label18.Location = New System.Drawing.Point(95, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 11)
        Me.Label18.TabIndex = 229
        Me.Label18.Text = "Stanica"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label19.Location = New System.Drawing.Point(4, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 11)
        Me.Label19.TabIndex = 228
        Me.Label19.Text = "Operater"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label13
        '
        Me.Label13.Enabled = False
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(92, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 15)
        Me.Label13.TabIndex = 39
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Enabled = False
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(5, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 15)
        Me.Label14.TabIndex = 38
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnStanicaPr
        '
        Me.btnStanicaPr.Cursor = System.Windows.Forms.Cursors.Help
        Me.btnStanicaPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnStanicaPr.Location = New System.Drawing.Point(192, 28)
        Me.btnStanicaPr.Name = "btnStanicaPr"
        Me.btnStanicaPr.Size = New System.Drawing.Size(24, 22)
        Me.btnStanicaPr.TabIndex = 33
        Me.btnStanicaPr.Text = "..."
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(160, 28)
        Me.TextBox2.MaxLength = 1
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(15, 22)
        Me.TextBox2.TabIndex = 52
        Me.TextBox2.Text = ""
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(56, 86)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(8, 16)
        Me.Label23.TabIndex = 230
        Me.Label23.Text = "-"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox6.Controls.Add(Me.Label30)
        Me.GroupBox6.Controls.Add(Me.tbPrevoznina)
        Me.GroupBox6.Enabled = False
        Me.GroupBox6.Location = New System.Drawing.Point(780, 566)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(220, 44)
        Me.GroupBox6.TabIndex = 247
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Franko iznos po tov. listu"
        Me.GroupBox6.Visible = False
        '
        'Label30
        '
        Me.Label30.Enabled = False
        Me.Label30.Location = New System.Drawing.Point(160, 20)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 13)
        Me.Label30.TabIndex = 233
        Me.Label30.Text = "[ dinara ]"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox7.Controls.Add(Me.RadioButton2)
        Me.GroupBox7.Controls.Add(Me.RadioButton1)
        Me.GroupBox7.Controls.Add(Me.RadioButton3)
        Me.GroupBox7.Location = New System.Drawing.Point(780, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(123, 77)
        Me.GroupBox7.TabIndex = 248
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = " [ POSILJKA ]  "
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
        Me.gbPrevozniPut.Location = New System.Drawing.Point(780, 519)
        Me.gbPrevozniPut.Name = "gbPrevozniPut"
        Me.gbPrevozniPut.Size = New System.Drawing.Size(220, 48)
        Me.gbPrevozniPut.TabIndex = 312
        Me.gbPrevozniPut.TabStop = False
        Me.gbPrevozniPut.Text = " PREVOZNI PUT UIC"
        '
        'lblPP
        '
        Me.lblPP.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.lblPP.Location = New System.Drawing.Point(176, 8)
        Me.lblPP.Name = "lblPP"
        Me.lblPP.Size = New System.Drawing.Size(24, 16)
        Me.lblPP.TabIndex = 312
        Me.lblPP.Text = "err"
        '
        'ListBox4
        '
        Me.ListBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ListBox4.Location = New System.Drawing.Point(704, 780)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(31, 69)
        Me.ListBox4.TabIndex = 352
        '
        'ListBox3
        '
        Me.ListBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ListBox3.Location = New System.Drawing.Point(616, 780)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(88, 69)
        Me.ListBox3.TabIndex = 351
        '
        'ListBox2
        '
        Me.ListBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ListBox2.Location = New System.Drawing.Point(528, 780)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(88, 69)
        Me.ListBox2.TabIndex = 350
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ListBox1.Location = New System.Drawing.Point(416, 780)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(112, 69)
        Me.ListBox1.TabIndex = 349
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SandyBrown
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.Label34)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.btnOperaterAdd)
        Me.Panel2.Controls.Add(Me.cbOperaterAdd)
        Me.Panel2.Controls.Add(Me.Button26)
        Me.Panel2.Controls.Add(Me.Button24)
        Me.Panel2.Controls.Add(Me.lbR57)
        Me.Panel2.Controls.Add(Me.Button23)
        Me.Panel2.Controls.Add(Me.Button22p)
        Me.Panel2.Controls.Add(Me.Button22)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.cbR57)
        Me.Panel2.Controls.Add(Me.rtb57a)
        Me.Panel2.Controls.Add(Me.rtb57b)
        Me.Panel2.Controls.Add(Me.rtb57b2)
        Me.Panel2.Controls.Add(Me.rtb57c)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Controls.Add(Me.Label29)
        Me.Panel2.Location = New System.Drawing.Point(15, 384)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(89, 184)
        Me.Panel2.TabIndex = 348
        Me.Panel2.Visible = False
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(344, 328)
        Me.Label34.Name = "Label34"
        Me.Label34.TabIndex = 343
        Me.Label34.Text = "Label34"
        Me.Label34.Visible = False
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(248, 328)
        Me.Label31.Name = "Label31"
        Me.Label31.TabIndex = 342
        Me.Label31.Text = "Label31"
        Me.Label31.Visible = False
        '
        'cbOperaterAdd
        '
        Me.cbOperaterAdd.Location = New System.Drawing.Point(16, 326)
        Me.cbOperaterAdd.Name = "cbOperaterAdd"
        Me.cbOperaterAdd.Size = New System.Drawing.Size(160, 21)
        Me.cbOperaterAdd.TabIndex = 340
        Me.cbOperaterAdd.Visible = False
        '
        'lbR57
        '
        Me.lbR57.Location = New System.Drawing.Point(16, 56)
        Me.lbR57.Name = "lbR57"
        Me.lbR57.Size = New System.Drawing.Size(400, 121)
        Me.lbR57.TabIndex = 337
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label25.Location = New System.Drawing.Point(16, 8)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(400, 23)
        Me.Label25.TabIndex = 328
        Me.Label25.Text = "Rubrika 57 - Ostali prevoznici"
        '
        'cbR57
        '
        Me.cbR57.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.cbR57.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbR57.ItemHeight = 15
        Me.cbR57.Location = New System.Drawing.Point(432, 32)
        Me.cbR57.Name = "cbR57"
        Me.cbR57.Size = New System.Drawing.Size(48, 23)
        Me.cbR57.TabIndex = 230
        Me.cbR57.Visible = False
        '
        'rtb57a
        '
        Me.rtb57a.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.rtb57a.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtb57a.ItemHeight = 15
        Me.rtb57a.Location = New System.Drawing.Point(16, 200)
        Me.rtb57a.Name = "rtb57a"
        Me.rtb57a.Size = New System.Drawing.Size(160, 124)
        Me.rtb57a.TabIndex = 322
        '
        'rtb57b
        '
        Me.rtb57b.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.rtb57b.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtb57b.ItemHeight = 15
        Me.rtb57b.Location = New System.Drawing.Point(176, 200)
        Me.rtb57b.Name = "rtb57b"
        Me.rtb57b.Size = New System.Drawing.Size(96, 124)
        Me.rtb57b.TabIndex = 323
        '
        'rtb57b2
        '
        Me.rtb57b2.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.rtb57b2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtb57b2.ItemHeight = 15
        Me.rtb57b2.Location = New System.Drawing.Point(272, 200)
        Me.rtb57b2.Name = "rtb57b2"
        Me.rtb57b2.Size = New System.Drawing.Size(96, 124)
        Me.rtb57b2.TabIndex = 324
        '
        'rtb57c
        '
        Me.rtb57c.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.rtb57c.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtb57c.ItemHeight = 15
        Me.rtb57c.Location = New System.Drawing.Point(368, 200)
        Me.rtb57c.Name = "rtb57c"
        Me.rtb57c.Size = New System.Drawing.Size(48, 124)
        Me.rtb57c.TabIndex = 325
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label26.Location = New System.Drawing.Point(16, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(352, 23)
        Me.Label26.TabIndex = 329
        Me.Label26.Text = "Izaberi granicni prelaz na prevoznom putu"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label28.Location = New System.Drawing.Point(212, 183)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(28, 17)
        Me.Label28.TabIndex = 334
        Me.Label28.Text = "ulaz"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label27.Location = New System.Drawing.Point(69, 183)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(51, 17)
        Me.Label27.TabIndex = 333
        Me.Label27.Text = "prevoznik"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label29.Location = New System.Drawing.Point(308, 183)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(28, 17)
        Me.Label29.TabIndex = 335
        Me.Label29.Text = "izlaz"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBrutoValue
        '
        Me.lblBrutoValue.BackColor = System.Drawing.Color.Transparent
        Me.lblBrutoValue.Location = New System.Drawing.Point(586, 457)
        Me.lblBrutoValue.Name = "lblBrutoValue"
        Me.lblBrutoValue.Size = New System.Drawing.Size(50, 16)
        Me.lblBrutoValue.TabIndex = 340
        Me.lblBrutoValue.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTaraValue
        '
        Me.lblTaraValue.BackColor = System.Drawing.Color.Transparent
        Me.lblTaraValue.Location = New System.Drawing.Point(586, 441)
        Me.lblTaraValue.Name = "lblTaraValue"
        Me.lblTaraValue.Size = New System.Drawing.Size(50, 16)
        Me.lblTaraValue.TabIndex = 339
        Me.lblTaraValue.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBruto
        '
        Me.lblBruto.BackColor = System.Drawing.Color.Transparent
        Me.lblBruto.Location = New System.Drawing.Point(548, 457)
        Me.lblBruto.Name = "lblBruto"
        Me.lblBruto.Size = New System.Drawing.Size(37, 16)
        Me.lblBruto.TabIndex = 338
        Me.lblBruto.Text = "Bruto : "
        '
        'lblTara
        '
        Me.lblTara.BackColor = System.Drawing.Color.Transparent
        Me.lblTara.Location = New System.Drawing.Point(548, 441)
        Me.lblTara.Name = "lblTara"
        Me.lblTara.Size = New System.Drawing.Size(37, 16)
        Me.lblTara.TabIndex = 337
        Me.lblTara.Text = "Tara  :"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(308, 816)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 16)
        Me.Label9.TabIndex = 327
        Me.Label9.Text = "[Sifre prelaza izmedju  uprava]"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label9.Visible = False
        '
        'tbKolauVozu
        '
        Me.tbKolauVozu.BackColor = System.Drawing.Color.White
        Me.tbKolauVozu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbKolauVozu.Enabled = False
        Me.tbKolauVozu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKolauVozu.Location = New System.Drawing.Point(561, 284)
        Me.tbKolauVozu.MaxLength = 4
        Me.tbKolauVozu.Name = "tbKolauVozu"
        Me.tbKolauVozu.Size = New System.Drawing.Size(24, 13)
        Me.tbKolauVozu.TabIndex = 53
        Me.tbKolauVozu.Text = ""
        Me.tbKolauVozu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb13
        '
        Me.tb13.BackColor = System.Drawing.Color.Yellow
        Me.tb13.Location = New System.Drawing.Point(200, 8)
        Me.tb13.Multiline = True
        Me.tb13.Name = "tb13"
        Me.tb13.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb13.Size = New System.Drawing.Size(32, 24)
        Me.tb13.TabIndex = 320
        Me.tb13.Text = ""
        Me.tb13.Visible = False
        '
        'rtb9
        '
        Me.rtb9.BackColor = System.Drawing.Color.Yellow
        Me.rtb9.Location = New System.Drawing.Point(168, 8)
        Me.rtb9.Name = "rtb9"
        Me.rtb9.Size = New System.Drawing.Size(26, 27)
        Me.rtb9.TabIndex = 319
        Me.rtb9.Text = ""
        Me.rtb9.Visible = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Sienna
        Me.Label16.Location = New System.Drawing.Point(440, 499)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 16)
        Me.Label16.TabIndex = 312
        Me.Label16.Text = "Pocetna carinarnica"
        '
        'rtb7
        '
        Me.rtb7.BackColor = System.Drawing.Color.Yellow
        Me.rtb7.Location = New System.Drawing.Point(136, 8)
        Me.rtb7.Name = "rtb7"
        Me.rtb7.Size = New System.Drawing.Size(24, 20)
        Me.rtb7.TabIndex = 301
        Me.rtb7.Text = ""
        Me.rtb7.Visible = False
        '
        'rtb56
        '
        Me.rtb56.BackColor = System.Drawing.Color.Wheat
        Me.rtb56.Location = New System.Drawing.Point(16, 800)
        Me.rtb56.Name = "rtb56"
        Me.rtb56.Size = New System.Drawing.Size(264, 40)
        Me.rtb56.TabIndex = 305
        Me.rtb56.Text = ""
        '
        'rtb55
        '
        Me.rtb55.BackColor = System.Drawing.Color.Wheat
        Me.rtb55.Location = New System.Drawing.Point(443, 742)
        Me.rtb55.Name = "rtb55"
        Me.rtb55.Size = New System.Drawing.Size(272, 34)
        Me.rtb55.TabIndex = 302
        Me.rtb55.Text = ""
        '
        'rtb21
        '
        Me.rtb21.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.rtb21.Location = New System.Drawing.Point(8, 419)
        Me.rtb21.Name = "rtb21"
        Me.rtb21.Size = New System.Drawing.Size(422, 140)
        Me.rtb21.TabIndex = 300
        Me.rtb21.Text = ""
        '
        'ComboBox4
        '
        Me.ComboBox4.BackColor = System.Drawing.Color.Wheat
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox4.ItemHeight = 12
        Me.ComboBox4.Items.AddRange(New Object() {"EUR", "RSD", "USD", "CHF"})
        Me.ComboBox4.Location = New System.Drawing.Point(148, 732)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(50, 20)
        Me.ComboBox4.TabIndex = 291
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.Color.Wheat
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBox3.ItemHeight = 12
        Me.ComboBox3.Items.AddRange(New Object() {"EUR", "RSD", "USD", "CHF"})
        Me.ComboBox3.Location = New System.Drawing.Point(148, 663)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(50, 20)
        Me.ComboBox3.TabIndex = 271
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Sienna
        Me.Label6.Location = New System.Drawing.Point(440, 519)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 251
        Me.Label6.Text = "Odredišna carinarnica"
        '
        'lblCarinarnica
        '
        Me.lblCarinarnica.BackColor = System.Drawing.Color.Transparent
        Me.lblCarinarnica.Enabled = False
        Me.lblCarinarnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblCarinarnica.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.lblCarinarnica.Location = New System.Drawing.Point(440, 536)
        Me.lblCarinarnica.Name = "lblCarinarnica"
        Me.lblCarinarnica.Size = New System.Drawing.Size(200, 32)
        Me.lblCarinarnica.TabIndex = 253
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.PapayaWhip
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(400, 11)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 247
        Me.PictureBox3.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Sienna
        Me.Label7.Location = New System.Drawing.Point(365, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 23)
        Me.Label7.TabIndex = 233
        Me.Label7.Text = "Sat voza"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Sienna
        Me.Label3.Location = New System.Drawing.Point(364, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 23)
        Me.Label3.TabIndex = 234
        Me.Label3.Text = "Broj voza"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox13
        '
        Me.TextBox13.BackColor = System.Drawing.Color.Wheat
        Me.TextBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox13.Location = New System.Drawing.Point(553, 686)
        Me.TextBox13.MaxLength = 12
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(76, 20)
        Me.TextBox13.TabIndex = 207
        Me.TextBox13.Text = ""
        Me.TextBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb51b
        '
        Me.tb51b.BackColor = System.Drawing.Color.Wheat
        Me.tb51b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb51b.Location = New System.Drawing.Point(632, 640)
        Me.tb51b.MaxLength = 2
        Me.tb51b.Name = "tb51b"
        Me.tb51b.Size = New System.Drawing.Size(24, 20)
        Me.tb51b.TabIndex = 196
        Me.tb51b.Text = ""
        Me.tb51b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox80
        '
        Me.TextBox80.BackColor = System.Drawing.Color.Wheat
        Me.TextBox80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox80.Location = New System.Drawing.Point(694, 710)
        Me.TextBox80.MaxLength = 2
        Me.TextBox80.Name = "TextBox80"
        Me.TextBox80.Size = New System.Drawing.Size(24, 20)
        Me.TextBox80.TabIndex = 194
        Me.TextBox80.Text = ""
        Me.TextBox80.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox81
        '
        Me.TextBox81.BackColor = System.Drawing.Color.Wheat
        Me.TextBox81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox81.Location = New System.Drawing.Point(720, 710)
        Me.TextBox81.MaxLength = 2
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New System.Drawing.Size(24, 20)
        Me.TextBox81.TabIndex = 195
        Me.TextBox81.Text = ""
        Me.TextBox81.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox78
        '
        Me.TextBox78.BackColor = System.Drawing.Color.Wheat
        Me.TextBox78.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox78.Location = New System.Drawing.Point(694, 686)
        Me.TextBox78.MaxLength = 2
        Me.TextBox78.Name = "TextBox78"
        Me.TextBox78.Size = New System.Drawing.Size(24, 20)
        Me.TextBox78.TabIndex = 192
        Me.TextBox78.Text = ""
        Me.TextBox78.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox79
        '
        Me.TextBox79.BackColor = System.Drawing.Color.Wheat
        Me.TextBox79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox79.Location = New System.Drawing.Point(720, 686)
        Me.TextBox79.MaxLength = 2
        Me.TextBox79.Name = "TextBox79"
        Me.TextBox79.Size = New System.Drawing.Size(24, 20)
        Me.TextBox79.TabIndex = 193
        Me.TextBox79.Text = ""
        Me.TextBox79.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox76
        '
        Me.TextBox76.BackColor = System.Drawing.Color.Wheat
        Me.TextBox76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox76.Location = New System.Drawing.Point(694, 664)
        Me.TextBox76.MaxLength = 2
        Me.TextBox76.Name = "TextBox76"
        Me.TextBox76.Size = New System.Drawing.Size(24, 20)
        Me.TextBox76.TabIndex = 190
        Me.TextBox76.Text = ""
        Me.TextBox76.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox77
        '
        Me.TextBox77.BackColor = System.Drawing.Color.Wheat
        Me.TextBox77.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox77.Location = New System.Drawing.Point(720, 664)
        Me.TextBox77.MaxLength = 2
        Me.TextBox77.Name = "TextBox77"
        Me.TextBox77.Size = New System.Drawing.Size(24, 20)
        Me.TextBox77.TabIndex = 191
        Me.TextBox77.Text = ""
        Me.TextBox77.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox57
        '
        Me.TextBox57.BackColor = System.Drawing.Color.Wheat
        Me.TextBox57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox57.Location = New System.Drawing.Point(553, 710)
        Me.TextBox57.MaxLength = 12
        Me.TextBox57.Name = "TextBox57"
        Me.TextBox57.Size = New System.Drawing.Size(76, 20)
        Me.TextBox57.TabIndex = 141
        Me.TextBox57.Text = ""
        Me.TextBox57.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb51c
        '
        Me.tb51c.BackColor = System.Drawing.Color.Wheat
        Me.tb51c.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb51c.Location = New System.Drawing.Point(662, 640)
        Me.tb51c.MaxLength = 6
        Me.tb51c.Name = "tb51c"
        Me.tb51c.Size = New System.Drawing.Size(80, 20)
        Me.tb51c.TabIndex = 130
        Me.tb51c.Text = ""
        Me.tb51c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb25
        '
        Me.tb25.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb25.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb25.Location = New System.Drawing.Point(552, 417)
        Me.tb25.MaxLength = 4
        Me.tb25.Name = "tb25"
        Me.tb25.Size = New System.Drawing.Size(88, 23)
        Me.tb25.TabIndex = 107
        Me.tb25.Text = ""
        Me.tb25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb24
        '
        Me.tb24.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb24.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb24.Location = New System.Drawing.Point(456, 417)
        Me.tb24.MaxLength = 4
        Me.tb24.Name = "tb24"
        Me.tb24.Size = New System.Drawing.Size(71, 23)
        Me.tb24.TabIndex = 106
        Me.tb24.Text = ""
        Me.tb24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb16c
        '
        Me.tb16c.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb16c.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb16c.Location = New System.Drawing.Point(531, 213)
        Me.tb16c.MaxLength = 2
        Me.tb16c.Name = "tb16c"
        Me.tb16c.Size = New System.Drawing.Size(23, 20)
        Me.tb16c.TabIndex = 90
        Me.tb16c.Text = ""
        Me.tb16c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb20a
        '
        Me.tb20a.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb20a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20a.Location = New System.Drawing.Point(495, 336)
        Me.tb20a.MaxLength = 2
        Me.tb20a.Name = "tb20a"
        Me.tb20a.Size = New System.Drawing.Size(24, 20)
        Me.tb20a.TabIndex = 40
        Me.tb20a.Text = ""
        '
        'tb20f
        '
        Me.tb20f.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb20f.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20f.Location = New System.Drawing.Point(620, 336)
        Me.tb20f.MaxLength = 4
        Me.tb20f.Name = "tb20f"
        Me.tb20f.TabIndex = 45
        Me.tb20f.Text = ""
        Me.tb20f.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb20e
        '
        Me.tb20e.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb20e.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20e.Location = New System.Drawing.Point(591, 336)
        Me.tb20e.MaxLength = 2
        Me.tb20e.Name = "tb20e"
        Me.tb20e.Size = New System.Drawing.Size(24, 20)
        Me.tb20e.TabIndex = 44
        Me.tb20e.Text = ""
        '
        'tb20d
        '
        Me.tb20d.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb20d.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20d.Location = New System.Drawing.Point(567, 336)
        Me.tb20d.MaxLength = 2
        Me.tb20d.Name = "tb20d"
        Me.tb20d.Size = New System.Drawing.Size(24, 20)
        Me.tb20d.TabIndex = 43
        Me.tb20d.Text = ""
        '
        'tb20c
        '
        Me.tb20c.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb20c.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20c.Location = New System.Drawing.Point(543, 336)
        Me.tb20c.MaxLength = 2
        Me.tb20c.Name = "tb20c"
        Me.tb20c.Size = New System.Drawing.Size(24, 20)
        Me.tb20c.TabIndex = 42
        Me.tb20c.Text = ""
        '
        'tb20b
        '
        Me.tb20b.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb20b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb20b.Location = New System.Drawing.Point(519, 336)
        Me.tb20b.MaxLength = 2
        Me.tb20b.Name = "tb20b"
        Me.tb20b.Size = New System.Drawing.Size(24, 20)
        Me.tb20b.TabIndex = 41
        Me.tb20b.Text = ""
        '
        'tb16e
        '
        Me.tb16e.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb16e.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb16e.Location = New System.Drawing.Point(579, 213)
        Me.tb16e.MaxLength = 2
        Me.tb16e.Name = "tb16e"
        Me.tb16e.Size = New System.Drawing.Size(23, 20)
        Me.tb16e.TabIndex = 92
        Me.tb16e.Text = ""
        Me.tb16e.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb16d
        '
        Me.tb16d.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb16d.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tb16d.Location = New System.Drawing.Point(555, 213)
        Me.tb16d.MaxLength = 2
        Me.tb16d.Name = "tb16d"
        Me.tb16d.Size = New System.Drawing.Size(23, 20)
        Me.tb16d.TabIndex = 91
        Me.tb16d.Text = ""
        Me.tb16d.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb15
        '
        Me.tb15.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tb15.Location = New System.Drawing.Point(8, 354)
        Me.tb15.Multiline = True
        Me.tb15.Name = "tb15"
        Me.tb15.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb15.Size = New System.Drawing.Size(350, 40)
        Me.tb15.TabIndex = 87
        Me.tb15.Text = ""
        '
        'CheckBox7
        '
        Me.CheckBox7.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox7.Location = New System.Drawing.Point(610, 657)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(24, 32)
        Me.CheckBox7.TabIndex = 55
        '
        'CheckBox6
        '
        Me.CheckBox6.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox6.Location = New System.Drawing.Point(417, 390)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(24, 32)
        Me.CheckBox6.TabIndex = 49
        '
        'CheckBox5
        '
        Me.CheckBox5.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox5.Location = New System.Drawing.Point(339, 390)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(24, 32)
        Me.CheckBox5.TabIndex = 48
        '
        'cbIncoterms
        '
        Me.cbIncoterms.BackColor = System.Drawing.Color.Transparent
        Me.cbIncoterms.Location = New System.Drawing.Point(371, 362)
        Me.cbIncoterms.Name = "cbIncoterms"
        Me.cbIncoterms.Size = New System.Drawing.Size(24, 24)
        Me.cbIncoterms.TabIndex = 39
        '
        'cbFrankoPrevoznina
        '
        Me.cbFrankoPrevoznina.BackColor = System.Drawing.Color.Transparent
        Me.cbFrankoPrevoznina.Checked = True
        Me.cbFrankoPrevoznina.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbFrankoPrevoznina.Location = New System.Drawing.Point(371, 338)
        Me.cbFrankoPrevoznina.Name = "cbFrankoPrevoznina"
        Me.cbFrankoPrevoznina.Size = New System.Drawing.Size(16, 17)
        Me.cbFrankoPrevoznina.TabIndex = 38
        '
        'tbIBK
        '
        Me.tbIBK.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.tbIBK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbIBK.Location = New System.Drawing.Point(384, 280)
        Me.tbIBK.MaxLength = 12
        Me.tbIBK.Name = "tbIBK"
        Me.tbIBK.Size = New System.Drawing.Size(144, 23)
        Me.tbIBK.TabIndex = 36
        Me.tbIBK.Text = ""
        Me.tbIBK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbCUV
        '
        Me.cbCUV.BackColor = System.Drawing.Color.Transparent
        Me.cbCUV.Location = New System.Drawing.Point(330, 5)
        Me.cbCUV.Name = "cbCUV"
        Me.cbCUV.Size = New System.Drawing.Size(24, 31)
        Me.cbCUV.TabIndex = 10
        '
        'cbCIM
        '
        Me.cbCIM.BackColor = System.Drawing.Color.Transparent
        Me.cbCIM.Checked = True
        Me.cbCIM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCIM.Location = New System.Drawing.Point(118, 2)
        Me.cbCIM.Name = "cbCIM"
        Me.cbCIM.Size = New System.Drawing.Size(13, 37)
        Me.cbCIM.TabIndex = 9
        '
        'tbControl
        '
        Me.tbControl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbControl.Enabled = False
        Me.tbControl.ForeColor = System.Drawing.Color.Silver
        Me.tbControl.Location = New System.Drawing.Point(550, 960)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.Size = New System.Drawing.Size(128, 13)
        Me.tbControl.TabIndex = 0
        Me.tbControl.Text = "CIM/RCA_FB"
        '
        'CheckBox8
        '
        Me.CheckBox8.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox8.Location = New System.Drawing.Point(284, 903)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(24, 32)
        Me.CheckBox8.TabIndex = 50
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(184, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 341
        Me.Label8.Text = "Zemlja"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DimGray
        Me.Label24.Location = New System.Drawing.Point(184, 176)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 16)
        Me.Label24.TabIndex = 342
        Me.Label24.Text = "Zemlja"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.PapayaWhip
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.ListBox4)
        Me.Panel1.Controls.Add(Me.ListBox3)
        Me.Panel1.Controls.Add(Me.ListBox2)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.Button21)
        Me.Panel1.Controls.Add(Me.r13)
        Me.Panel1.Controls.Add(Me.r9)
        Me.Panel1.Controls.Add(Me.r7)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button20)
        Me.Panel1.Controls.Add(Me.lblBrutoValue)
        Me.Panel1.Controls.Add(Me.lblTaraValue)
        Me.Panel1.Controls.Add(Me.lblBruto)
        Me.Panel1.Controls.Add(Me.lblTara)
        Me.Panel1.Controls.Add(Me.ComboBox6)
        Me.Panel1.Controls.Add(Me.tb4b2)
        Me.Panel1.Controls.Add(Me.ComboBox5)
        Me.Panel1.Controls.Add(Me.tb4b1)
        Me.Panel1.Controls.Add(Me.tb29b_3)
        Me.Panel1.Controls.Add(Me.tb29b_2)
        Me.Panel1.Controls.Add(Me.tb29b_1)
        Me.Panel1.Controls.Add(Me.tb1b2)
        Me.Panel1.Controls.Add(Me.tb1b1)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.tbKolauVozu)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.tb13)
        Me.Panel1.Controls.Add(Me.rtb9)
        Me.Panel1.Controls.Add(Me.Button17)
        Me.Panel1.Controls.Add(Me.TB58b)
        Me.Panel1.Controls.Add(Me.tbPolaznaCarina)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Controls.Add(Me.rtb7)
        Me.Panel1.Controls.Add(Me.rtb56)
        Me.Panel1.Controls.Add(Me.rtb55)
        Me.Panel1.Controls.Add(Me.rtb21)
        Me.Panel1.Controls.Add(Me.Button18)
        Me.Panel1.Controls.Add(Me.TextBox49)
        Me.Panel1.Controls.Add(Me.TextBox51)
        Me.Panel1.Controls.Add(Me.TextBox69)
        Me.Panel1.Controls.Add(Me.TextBox70)
        Me.Panel1.Controls.Add(Me.ComboBox4)
        Me.Panel1.Controls.Add(Me.TextBox46)
        Me.Panel1.Controls.Add(Me.TextBox47)
        Me.Panel1.Controls.Add(Me.TextBox48)
        Me.Panel1.Controls.Add(Me.TextBox42)
        Me.Panel1.Controls.Add(Me.TextBox43)
        Me.Panel1.Controls.Add(Me.TextBox44)
        Me.Panel1.Controls.Add(Me.TextBox45)
        Me.Panel1.Controls.Add(Me.TextBox38)
        Me.Panel1.Controls.Add(Me.TextBox39)
        Me.Panel1.Controls.Add(Me.TextBox40)
        Me.Panel1.Controls.Add(Me.TextBox41)
        Me.Panel1.Controls.Add(Me.TextBox28)
        Me.Panel1.Controls.Add(Me.TextBox35)
        Me.Panel1.Controls.Add(Me.TextBox36)
        Me.Panel1.Controls.Add(Me.TextBox37)
        Me.Panel1.Controls.Add(Me.tbA79b3)
        Me.Panel1.Controls.Add(Me.tbA79a3)
        Me.Panel1.Controls.Add(Me.tbA79b2)
        Me.Panel1.Controls.Add(Me.tbA79a2)
        Me.Panel1.Controls.Add(Me.ComboBox3)
        Me.Panel1.Controls.Add(Me.TextBox21)
        Me.Panel1.Controls.Add(Me.TextBox22)
        Me.Panel1.Controls.Add(Me.TextBox23)
        Me.Panel1.Controls.Add(Me.TextBox15)
        Me.Panel1.Controls.Add(Me.TextBox16)
        Me.Panel1.Controls.Add(Me.TextBox17)
        Me.Panel1.Controls.Add(Me.TextBox18)
        Me.Panel1.Controls.Add(Me.TextBox19)
        Me.Panel1.Controls.Add(Me.TextBox20)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.TextBox5)
        Me.Panel1.Controls.Add(Me.TextBox8)
        Me.Panel1.Controls.Add(Me.TextBox9)
        Me.Panel1.Controls.Add(Me.TextBox11)
        Me.Panel1.Controls.Add(Me.tb16b)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.btnCarinarnica)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.tbCarinjenje)
        Me.Panel1.Controls.Add(Me.lblCarinarnica)
        Me.Panel1.Controls.Add(Me.Button16)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.tbsBrojVoza)
        Me.Panel1.Controls.Add(Me.tbsSatVoza)
        Me.Panel1.Controls.Add(Me.Button15)
        Me.Panel1.Controls.Add(Me.Button14)
        Me.Panel1.Controls.Add(Me.tb52c)
        Me.Panel1.Controls.Add(Me.Button13)
        Me.Panel1.Controls.Add(Me.combo73A)
        Me.Panel1.Controls.Add(Me.tbA70b2)
        Me.Panel1.Controls.Add(Me.tbA70a2)
        Me.Panel1.Controls.Add(Me.tbA78)
        Me.Panel1.Controls.Add(Me.tbA77)
        Me.Panel1.Controls.Add(Me.tbA76)
        Me.Panel1.Controls.Add(Me.tbA75)
        Me.Panel1.Controls.Add(Me.tbA74d1)
        Me.Panel1.Controls.Add(Me.tbA79b1)
        Me.Panel1.Controls.Add(Me.tbA79a1)
        Me.Panel1.Controls.Add(Me.tbA72d)
        Me.Panel1.Controls.Add(Me.tb71)
        Me.Panel1.Controls.Add(Me.tbA70b1)
        Me.Panel1.Controls.Add(Me.tbA70a1)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.TextBox13)
        Me.Panel1.Controls.Add(Me.tb49g)
        Me.Panel1.Controls.Add(Me.tb49f)
        Me.Panel1.Controls.Add(Me.tb49e)
        Me.Panel1.Controls.Add(Me.tb49d)
        Me.Panel1.Controls.Add(Me.tb49c)
        Me.Panel1.Controls.Add(Me.tb49b)
        Me.Panel1.Controls.Add(Me.tb51b)
        Me.Panel1.Controls.Add(Me.TextBox80)
        Me.Panel1.Controls.Add(Me.TextBox81)
        Me.Panel1.Controls.Add(Me.TextBox78)
        Me.Panel1.Controls.Add(Me.TextBox79)
        Me.Panel1.Controls.Add(Me.TextBox76)
        Me.Panel1.Controls.Add(Me.TextBox77)
        Me.Panel1.Controls.Add(Me.tb59b)
        Me.Panel1.Controls.Add(Me.tb59a)
        Me.Panel1.Controls.Add(Me.tb28)
        Me.Panel1.Controls.Add(Me.tb27)
        Me.Panel1.Controls.Add(Me.btnUnosRobe)
        Me.Panel1.Controls.Add(Me.tb4c)
        Me.Panel1.Controls.Add(Me.tb10b)
        Me.Panel1.Controls.Add(Me.tb52e)
        Me.Panel1.Controls.Add(Me.tb52d)
        Me.Panel1.Controls.Add(Me.tb52b)
        Me.Panel1.Controls.Add(Me.tb52a)
        Me.Panel1.Controls.Add(Me.TextBox66)
        Me.Panel1.Controls.Add(Me.TextBox67)
        Me.Panel1.Controls.Add(Me.TextBox68)
        Me.Panel1.Controls.Add(Me.TB58a2)
        Me.Panel1.Controls.Add(Me.TB58a1)
        Me.Panel1.Controls.Add(Me.TextBox57)
        Me.Panel1.Controls.Add(Me.tb51c)
        Me.Panel1.Controls.Add(Me.tb51a)
        Me.Panel1.Controls.Add(Me.tb50)
        Me.Panel1.Controls.Add(Me.tb49h)
        Me.Panel1.Controls.Add(Me.tb49a)
        Me.Panel1.Controls.Add(Me.tb29b)
        Me.Panel1.Controls.Add(Me.tb29a)
        Me.Panel1.Controls.Add(Me.cbVal28)
        Me.Panel1.Controls.Add(Me.tb26)
        Me.Panel1.Controls.Add(Me.cbVal27)
        Me.Panel1.Controls.Add(Me.cbVal26)
        Me.Panel1.Controls.Add(Me.tb25)
        Me.Panel1.Controls.Add(Me.tb24)
        Me.Panel1.Controls.Add(Me.tb16c)
        Me.Panel1.Controls.Add(Me.tb20a)
        Me.Panel1.Controls.Add(Me.tb20f)
        Me.Panel1.Controls.Add(Me.tb20e)
        Me.Panel1.Controls.Add(Me.tb20d)
        Me.Panel1.Controls.Add(Me.tb20c)
        Me.Panel1.Controls.Add(Me.tb20b)
        Me.Panel1.Controls.Add(Me.tb17)
        Me.Panel1.Controls.Add(Me.tb16a)
        Me.Panel1.Controls.Add(Me.tb16e)
        Me.Panel1.Controls.Add(Me.tb16d)
        Me.Panel1.Controls.Add(Me.tb15)
        Me.Panel1.Controls.Add(Me.tb14a)
        Me.Panel1.Controls.Add(Me.tb14b)
        Me.Panel1.Controls.Add(Me.TextBox34)
        Me.Panel1.Controls.Add(Me.TextBox33)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.CheckBox7)
        Me.Panel1.Controls.Add(Me.tb4a)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.tb1a)
        Me.Panel1.Controls.Add(Me.CheckBox6)
        Me.Panel1.Controls.Add(Me.CheckBox5)
        Me.Panel1.Controls.Add(Me.comboIncoterms)
        Me.Panel1.Controls.Add(Me.cbIncoterms)
        Me.Panel1.Controls.Add(Me.cbFrankoPrevoznina)
        Me.Panel1.Controls.Add(Me.tbIBK)
        Me.Panel1.Controls.Add(Me.tb1c)
        Me.Panel1.Controls.Add(Me.tb6)
        Me.Panel1.Controls.Add(Me.tb4b)
        Me.Panel1.Controls.Add(Me.tb5)
        Me.Panel1.Controls.Add(Me.tb3)
        Me.Panel1.Controls.Add(Me.tb1b)
        Me.Panel1.Controls.Add(Me.tb10a)
        Me.Panel1.Controls.Add(Me.tb12)
        Me.Panel1.Controls.Add(Me.cbCUV)
        Me.Panel1.Controls.Add(Me.cbCIM)
        Me.Panel1.Controls.Add(Me.tb2)
        Me.Panel1.Controls.Add(Me.tbControl)
        Me.Panel1.Controls.Add(Me.CheckBox8)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Location = New System.Drawing.Point(9, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(768, 700)
        Me.Panel1.TabIndex = 6
        '
        'FormCim
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(937, 606)
        Me.Controls.Add(Me.Button19)
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
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCim"
        Me.Text = "CIM"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tbsSatVoza, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim err As DataSet
    Dim NizUic(57, 2) As String
    Dim mUgovorZaUporedjenje As String
    Dim stepR57 As Int16 = 0
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FormatErrGrid()

        Dim intY As Int32 = Screen.PrimaryScreen.Bounds.Height

        'Me.Panel1.Location = New Point(9, 1)
        Me.Panel1.Size = New Size(768, intY - 10)
        _OpenForm = ""
        If eRazmena = "Ne" Then
            dtKola.Clear()
            dtNhm.Clear()
            Me.tbKolauVozu.Text = ""
        Else
            Me.tbKolauVozu.Text = CStr(dtKola.Rows.Count)
            'Me.tbKolauVozu.Text = "[ " & CStr(dtKola.Rows.Count) & " ]"
        End If
        dtNaknade.Clear()

        nmNazivOtpSt = ""
        Me.tbsBrojVoza.Text = msBrojVoza
        Me.tbsSatVoza.Text = mSatVoza
        Me.ComboBox1.Text = mTarifa
        If mBrojUg = "000000" Then
            Me.tbUgovor.Clear()
        Else
            Me.tbUgovor.Text = mBrojUg
        End If

        tbsSatVoza.Text = Today.Now.Hour.ToString
        If Len(tbsSatVoza.Text) = 1 Then
            Me.tbsSatVoza.Text = "0" & Me.tbsSatVoza.Text
        End If

        If IzborSaobracaja = "2" Then
            Me.RadioButton2.Checked = True
            Label20.Text = "Datum"
        ElseIf IzborSaobracaja = "3" Then
            Me.RadioButton3.Checked = True
            Label20.Text = "Datum izlaza"
        ElseIf IzborSaobracaja = "4" Then
            Me.RadioButton1.Checked = True
            Label20.Text = "Datum"
        End If
        If Me.rbKolska.Checked = True Then
            bVrstaPosiljke = "K"
        Else
            bVrstaPosiljke = "D"
        End If
        Me.r7.Items.Clear()

        If GranicnaStanica = "N" Then
            mDinaraPoTL = 0
            If IzborSaobracaja = "2" Then
                Me.GroupBox6.Visible = True
                Me.GroupBox6.Enabled = True
                Me.GroupBox6.Text = "Upuceni iznos po tov. listu"
                tbPrevoznina.Visible = True
                tbPrevoznina.Text = Format(mDinaraPoTL, "###,###,##0.00")
                tbPrevoznina.Enabled = True
            ElseIf IzborSaobracaja = "3" Then
                Me.GroupBox6.Visible = True
                Me.GroupBox6.Enabled = True
                Me.GroupBox6.Text = "Franko iznos po tov. listu"
                tbPrevoznina.Visible = True
                tbPrevoznina.Text = Format(mDinaraPoTL, "###,###,##0.00")
                tbPrevoznina.Enabled = True
            End If
        Else
            mDinaraPoTL = 0
            Me.GroupBox6.Visible = False
        End If

        Init_Tarifa()



        ' !!! ===================================== da li se preuzima eCIM ===========================================

        If eRazmena = "Ne" Then                     ' Obièan unos
            If RecordAction = "I" Then 'Insert
                Init_Forma()

            ElseIf RecordAction = "N" Then ' Izmena
                'popuniti polja na formi vrednostima iz baze
                Dim drKola, drNhm As DataRow
                For Each drKola In dtKola.Rows
                    mIBK = drKola.Item("IndBrojKola")
                Next
                For Each drNhm In dtNhm.Rows
                    mNHM = drNhm.Item("NHM")
                Next
                mSumaRobe = dtNhm.Compute("SUM(Masa)", String.Empty)

                Me.tbIBK.Text = mIBK
                Me.tb24.Text = mNHM
                Me.tb25.Text = mSumaRobe.ToString

                If IzborSaobracaja = "4" Then
                    If TipTranzita = "ulaz" Then
                        cbSmer1.Text = mUlPrelaz
                        cbSmer2.Text = mIzPrelaz
                        tbUlaznaNalepnica.Text = mUlEtiketa
                        tbIzlaznaNalepnica.Text = mIzEtiketa
                    Else
                        cbSmer1.Text = mIzPrelaz
                        cbSmer2.Text = mUlPrelaz
                        tbUlaznaNalepnica.Text = mIzEtiketa
                        tbIzlaznaNalepnica.Text = mUlEtiketa
                    End If

                ElseIf IzborSaobracaja = "2" Then

                ElseIf IzborSaobracaja = "3" Then

                End If

                Me.tbUpravaOtp.Text = mOtpUprava
                Me.tbStanicaOtp.Text = mOtpStanica
                Me.tbBrojOtp.Text = mOtpBroj
                Me.DatumOtp.Value = mOtpDatum
                Me.tbUpravaPr.Text = mPrUprava
                Me.tbStanicaPr.Text = mPrStanica

                PostaviPrelaz(mUlPrelaz, mIzPrelaz)

                Me.cbSmer1.Text = mStanica1
                Me.cbSmer2.Text = mStanica2

                Me.tbUlaznaNalepnica.Text = mUlEtiketa
                Me.tbIzlaznaNalepnica.Text = mIzEtiketa

                '-- podaci o korisniku
                If mTarifa = "00" Then 'ugovor
                    Dim mRetVal As String
                    Dim ug_mNazivKomitenta As String
                    Dim ug_mAdresaKomitenta As String
                    Dim ug_mGradKomitenta As String
                    Dim ug_mZemljaKomitenta As String
                    Dim ug_mPrimalac As String
                    Dim ug_mVrstaObracuna As String
                    tbUgovor.Text = mBrojUg

                    NadjiUgovor(tbUgovor.Text, ug_mNazivKomitenta, ug_mPrimalac, ug_mVrstaObracuna, ug_mAdresaKomitenta, ug_mGradKomitenta, ug_mZemljaKomitenta, mRetVal)

                    If mRetVal = "" Then
                        mPrimalac = ug_mPrimalac
                        mSifraKorisnika = ug_mPrimalac
                        mVrstaObracuna = ug_mVrstaObracuna

                        Me.tb1a.Text = ug_mNazivKomitenta
                        Me.tb1b.Text = ug_mAdresaKomitenta
                        Me.tb1b1.Text = ug_mGradKomitenta
                        Me.tb1b2.Text = ug_mZemljaKomitenta
                        Me.tb2.Text = ug_mPrimalac
                        Me.tb14b.Text = tbUgovor.Text
                        Me.tbA75.Text = tbUgovor.Text

                        '---------
                        If mTarifa = "00" Then
                            ComboBox2.Items.Clear()
                            If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "01" Then
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "02" Then
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.SelectedText = "2. Grupa kola"
                                ComboBox2.SelectedIndex = 0
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "67" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedIndex = 1
                            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                            Else
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.Items.Add("2. Grupa kola")
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedIndex = 0
                            End If

                            'za Intercontainer
                            If mSifraKorisnika = 43 Then
                                ComboBox2.Items.Add("3. Kompletni vozovi")
                                ComboBox2.SelectedText = "3. Kompletni vozovi"
                                ComboBox2.SelectedIndex = 0
                            ElseIf mSifraKorisnika = 18 Then
                                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                                ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                                ComboBox2.SelectedIndex = 0
                            End If
                        End If
                        '---------
                    End If
                    Me.ComboBox1.SelectedIndex = 0
                Else
                    Me.ComboBox1.SelectedIndex = 1
                End If
                '-- end podaci o korisniku
            End If
        Else                                        ' preuzimanje eCIM.xml

            ''eInit_NewCim89()
            eInit_Forma()
            DownloadValues()

            'jer ako nema stanice fokus je na tbStanicaPr
            'tbUpravaPr_Validating(Me, Nothing)
            'tbStanicaPr_Validating(Me, Nothing)


            Dim drKola, drNhm As DataRow
            For Each drKola In dtKola.Rows
                mIBK = drKola.Item("IndBrojKola")
            Next
            For Each drNhm In dtNhm.Rows
                mNHM = drNhm.Item("NHM")
            Next
            mSumaRobe = dtNhm.Compute("SUM(Masa)", String.Empty)
            mSumaTara = dtKola.Compute("SUM(Tara)", String.Empty)
            mSumaBruto = mSumaRobe + mSumaTara

            Me.tbA70a1.Text = "72"
            Me.tbA70a2.Text = "72"

            If IzborSaobracaja = "2" Then
                Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
                Me.tbA70b2.Text = Microsoft.VisualBasic.Right(Me.tbStanicaPr.Text, 5)
            ElseIf IzborSaobracaja = "4" Then
                Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
                Me.tbA70b2.Text = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
            End If


            Me.tbIBK.Text = mIBK
            Me.tb24.Text = mNHM
            Me.tbA72d.Text = mNHM
            Me.tb25.Text = mSumaRobe.ToString
            Me.lblTaraValue.Text = mSumaTara.ToString
            Me.lblBrutoValue.Text = mSumaBruto.ToString

            If IzborSaobracaja = "4" Then
                '''''''''''''''''''''tbUlaznaNalepnica.Text = mUlEtiketa
                cbSmer1.Enabled = True
            ElseIf IzborSaobracaja = "2" Then
                cbSmer2.SelectedIndex = -1
                cbSmer2.Enabled = False
            End If

        End If
        ' !!! ===================================== end da li se preuzima eCIM ===========================================


        If IzborSaobracaja = "3" Then
            Label20.Text = "Datum izlaza"
        End If
        If CheckBox8.Checked Then
            mCarPost = "D"
        Else : mCarPost = "N"
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
            If eCimDa = "D" Then
                If IzborSaobracaja = "3" Then

                    If Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "1" Or Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "8" Or _
                       Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "9" Then

                        If Me.tb4a.Text = Nothing Then
                            errText14 = "Primalac"
                            dtError.NewRow()
                            dtError.Rows.Add(New Object() {errText14})
                        End If
                        If Me.tb1a.Text = Nothing Then
                            errText14 = "Posiljalac"
                            dtError.NewRow()
                            dtError.Rows.Add(New Object() {errText14})
                        End If

                    Else


                    End If

                    ''If Me.tb4a.Text = Nothing Then
                    ''    errText14 = "Primalac"
                    ''    dtError.NewRow()
                    ''    dtError.Rows.Add(New Object() {errText14})
                    ''End If
                    ''If Me.tb1a.Text = Nothing Then
                    ''    errText14 = "Posiljalac"
                    ''    dtError.NewRow()
                    ''    dtError.Rows.Add(New Object() {errText14})
                    ''End If
                End If
            End If

            If Me.tbA76.Text = Nothing Then 'Or CType(tbKm1.Text, Integer) = 0 Then
                errText5 = "Tarifski kilometri"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText5})
            End If
            If Me.tbUpravaOtp.Text = Nothing Then
                errText6 = "Otpravna uprava - operater"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText6})
            ElseIf Len(Me.tbUpravaOtp.Text) > 0 And Len(Me.tbUpravaOtp.Text) < 4 Then
                errText6 = "Otpravna uprava - operater"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText6})
            End If
            If Me.tbStanicaOtp.Text = Nothing Then
                errText7 = "Otpravna stanica"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText7})
            ElseIf Len(Me.tbStanicaOtp.Text) > 0 And Len(Me.tbStanicaOtp.Text) < 7 Then
                errText7 = "Otpravna stanica"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText7})
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
            If Me.tbUpravaPr.Text = Nothing Then
                errText9 = "Uputna uprava - operater"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText9})
            ElseIf Len(Me.tbUpravaPr.Text) > 0 And Len(Me.tbUpravaPr.Text) < 4 Then
                errText9 = "Uputna uprava - operater"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText9})
            End If
            If Me.tbStanicaPr.Text = Nothing Then
                errText10 = "Uputna stanica"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText10})
            ElseIf Len(Me.tbStanicaPr.Text) > 0 And Len(Me.tbStanicaPr.Text) < 7 Then
                errText10 = "Uputna stanica"
                dtError.NewRow()
                dtError.Rows.Add(New Object() {errText10})
            End If
            If bVrstaPosiljke = "K" Then
                If dtKola.Rows.Count = 0 Then
                    errText11 = "Unos robe"
                    dtError.NewRow()
                    dtError.Rows.Add(New Object() {errText11})
                End If
            End If
            If Me.tbCarinjenje.Text = Nothing Then
                If IzborSaobracaja = "2" Then
                    If Microsoft.VisualBasic.Mid(tb24.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tb24.Text, 1, 4) = "9922" Then

                    Else
                        errText12 = "Odredisna carinarnica"
                        dtError.NewRow()
                        dtError.Rows.Add(New Object() {errText12})
                    End If
                ElseIf IzborSaobracaja = "4" Then
                    errText12 = "Odredisna carinarnica"
                    dtError.NewRow()
                    dtError.Rows.Add(New Object() {errText12})
                ElseIf IzborSaobracaja = "3" Then

                End If
            End If

            If IzborSaobracaja = 3 And eCimDa = "D" Then
                If Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "1" Or Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "8" Or _
                       Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "9" Then

                    If Me.tb16c.Text = Nothing Then
                        errText13 = "Preuzimanje na prevoz"
                        dtError.NewRow()
                        dtError.Rows.Add(New Object() {errText13})
                    End If
                Else

                End If

                'If Me.tb16c.Text = Nothing Then
                '    errText13 = "Preuzimanje na prevoz"
                '    dtError.NewRow()
                '    dtError.Rows.Add(New Object() {errText13})
                'End If
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
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim GridNaknade As New naknade
        GridNaknade.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        mTarifa = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)
        If mTarifa = "00" Then 'Ugovor
            ComboBox2.Text = ""
            Button10.Visible = True
            tbUgovor.Enabled = True
        Else
            tbUgovor.Text = " "
            Button10.Visible = False
            tbUgovor.Enabled = False
            ComboBox2.Enabled = True
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        mTarifa = Microsoft.VisualBasic.Left(ComboBox1.Text, 2)
        If mTarifa = "00" Then
            tb14a.Text = "1"
        Else
            tb14a.Text = "2"
            Me.tbA75.Text = "0000" & mTarifa
            Me.tb14b.Text = Me.tbA75.Text
        End If

        If ComboBox1.Text = Nothing Then
            ''ErrorProvider1.SetError(ComboBox1, "Obavezan izbor tarife!")
            ComboBox1.Focus()
        Else
            ''ErrorProvider1.SetError(ComboBox1, "")
            If IzborSaobracaja = "2" Then
                Me.Text = ":: CIM - U V O Z ::"
            ElseIf IzborSaobracaja = "3" Then
                Me.Text = ":: CIM - I Z V O Z ::"
            ElseIf IzborSaobracaja = "4" Then
                Me.Text = ":: CIM - T R A N Z I T ::"
            End If

        End If
    End Sub
    Private Sub ComboBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox2.Validating
        If ComboBox2.Text = Nothing Then
            ErrorProvider1.SetError(Label5, "Obavezan izbor vrste posiljke!")
            ComboBox2.Focus()
        Else
            ErrorProvider1.SetError(Label5, "")
            If Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "1" Then
                mVrstaPrevoza = "P"
            ElseIf Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "2" Then
                mVrstaPrevoza = "G"
            ElseIf Microsoft.VisualBasic.Left(ComboBox2.Text, 1) = "3" Then
                mVrstaPrevoza = "V"
            End If
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
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

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.GotFocus
        If mTarifa = "00" Then
            ComboBox2.Items.Clear()
            If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Then
                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                ComboBox2.Text = "1. Pojedinacna posiljka"
                Me.GroupBox3.Focus()
            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "01" Then
                ComboBox2.Items.Add("3. Kompletni vozovi")
                ComboBox2.Text = "3. Kompletni vozovi"
                Me.GroupBox3.Focus()
            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "02" Then
                ComboBox2.Items.Add("2. Grupa kola")
                ComboBox2.Text = "2. Grupa kola"
                Me.GroupBox3.Focus()
            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                ComboBox2.Text = "1. Pojedinacna posiljka"
                ComboBox2.SelectedIndex = 0
                Me.GroupBox3.Focus()
            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "67" Then
                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                ComboBox2.Items.Add("3. Kompletni vozovi")

            ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Then
                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                ComboBox2.Text = "1. Pojedinacna posiljka"
                Me.GroupBox3.Focus()
            Else
                ComboBox2.Items.Clear()
                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                ComboBox2.Items.Add("2. Grupa kola")
                ComboBox2.Items.Add("3. Kompletni vozovi")
            End If

            'za Intercontainer
            If mSifraKorisnika = 43 Then
                ComboBox2.Items.Add("3. Kompletni vozovi")
                ComboBox2.Text = "3. Kompletni vozovi"
                Me.GroupBox3.Focus()
            ElseIf mSifraKorisnika = 18 Then
                ComboBox2.Items.Add("1. Pojedinacna posiljka")
                ComboBox2.Text = "1. Pojedinacna posiljka"
                Me.GroupBox3.Focus()
            End If
        Else
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("1. Pojedinacna posiljka")
            ComboBox2.Items.Add("2. Grupa kola")
            ComboBox2.Items.Add("3. Kompletni vozovi")
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

                    If eRazmena = "Da" Then

                    Else
                        Me.tb1a.Text = ug_mNazivKomitenta
                        Me.tb1b.Text = ug_mAdresaKomitenta
                        Me.tb1b1.Text = ug_mGradKomitenta
                        Me.tb1b2.Text = ug_mZemljaKomitenta
                        Me.tb2.Text = ug_mPrimalac
                        Me.tb14b.Text = tbUgovor.Text
                        Me.tbA75.Text = tbUgovor.Text
                    End If


                    '---------
                    If mTarifa = "00" Then
                        ComboBox2.Items.Clear()
                        If Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "00" Then
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0

                            'Me.GroupBox3.Focus()
                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "01" Then
                            ComboBox2.Items.Add("3. Kompletni vozovi")
                            ComboBox2.SelectedText = "3. Kompletni vozovi"
                            ComboBox2.SelectedIndex = 0
                            'Me.GroupBox3.Focus()
                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "02" Then
                            ComboBox2.Items.Add("2. Grupa kola")
                            ComboBox2.SelectedText = "2. Grupa kola"
                            ComboBox2.SelectedIndex = 0
                            'Me.GroupBox3.Focus()
                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "11" Then
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0
                            'Me.GroupBox3.Focus()
                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "67" Then
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.Items.Add("3. Kompletni vozovi")
                            ComboBox2.SelectedIndex = 1
                            'ComboBox2.DroppedDown = True

                            'ComboBox2.Focus()
                        ElseIf Microsoft.VisualBasic.Right(tbUgovor.Text, 2) = "69" Then
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0
                            'Me.GroupBox3.Focus()
                        Else
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.Items.Add("2. Grupa kola")
                            ComboBox2.Items.Add("3. Kompletni vozovi")
                            ComboBox2.SelectedIndex = 0
                        End If

                        'za Intercontainer
                        If mSifraKorisnika = 43 Then
                            ComboBox2.Items.Add("3. Kompletni vozovi")
                            ComboBox2.SelectedText = "3. Kompletni vozovi"
                            ComboBox2.SelectedIndex = 0
                            'Me.GroupBox3.Focus()
                        ElseIf mSifraKorisnika = 18 Then
                            ComboBox2.Items.Add("1. Pojedinacna posiljka")
                            ComboBox2.SelectedText = "1. Pojedinacna posiljka"
                            ComboBox2.SelectedIndex = 0
                            'Me.GroupBox3.Focus()
                        End If
                        If IzborSaobracaja = "4" Then
                            Me.cbSmer1.Focus()
                        Else
                            If IzborSaobracaja = "2" Then
                                Me.cbSmer1.Focus()
                            Else
                                Me.cbSmer2.Focus()
                            End If
                        End If
                    End If
                    ErrorProvider1.SetError(tbUgovor, "")

                    If TipTranzita = "izlaz" Then
                        Me.tbUlaznaNalepnica.Focus()

                    End If
                    '---------
                Else
                    _Kontrola_NemaUgovora = 1
                    ErrorProvider1.SetError(tbUgovor, "")
                    'MessageBox.Show(mRetVal, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation)
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

    Private Sub tbsBrojVoza_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbsBrojVoza_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsNumeric(tbsBrojVoza.Text) = True Then
            If tbsBrojVoza.Text = "" Then
                tbsBrojVoza.Text = "0"
            End If
            If CType(tbsBrojVoza.Text, Int32) = 0 Then
                ErrorProvider1.SetError(tbsBrojVoza, "Obavezan unos saobracajnog broja voza!")
                tbsBrojVoza.Focus()
            Else
                ErrorProvider1.SetError(tbsBrojVoza, "")
            End If
        Else
            ErrorProvider1.SetError(tbsBrojVoza, "Neispravan unos!")
            tbsBrojVoza.Focus()
        End If
    End Sub

    Private Sub tbsSatVoza_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbsSatVoza_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If CType(tbsSatVoza.Text, Int16) > 23 Then
            ErrorProvider1.SetError(tbsSatVoza, "Sat voza je manji od 24")
            tbsSatVoza.Focus()
        Else
            ErrorProvider1.SetError(tbsSatVoza, "")
        End If
    End Sub
    Private Sub rbKolska_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbKolska.MouseUp
        If Me.rbKolska.Checked = True Then
            bVrstaPosiljke = "K"
        Else
            bVrstaPosiljke = "D"
        End If
    End Sub

    Private Sub rbDencana_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbDencana.MouseUp
        If Me.rbKolska.Checked = True Then
            bVrstaPosiljke = "K"
        Else
            bVrstaPosiljke = "D"
        End If
    End Sub

    Private Sub cbCIM_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbCIM.MouseUp
        If Me.cbCIM.Checked = True Then
            Me.cbCUV.Checked = False
        Else
            Me.cbCUV.Checked = True
        End If
    End Sub

    Private Sub cbCUV_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbCUV.MouseUp
        If Me.cbCUV.Checked = True Then
            Me.cbCIM.Checked = False
        Else
            Me.cbCIM.Checked = True
        End If

    End Sub

    Private Sub cbSmer1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbSmer2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSmer2.KeyPress
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

    Private Sub tbUlaznaNalepnica_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUlaznaNalepnica.Validating
        If tbUlaznaNalepnica.Text = Nothing Then
            ErrorProvider1.SetError(tbUlaznaNalepnica, "Unesite broj tranzitne nalepnice")
            tbUlaznaNalepnica.Focus()
        Else
            If IsNumeric(tbUlaznaNalepnica.Text) Then
                If CType(tbUlaznaNalepnica.Text, Int32) = 0 Then
                    ErrorProvider1.SetError(tbUlaznaNalepnica, "Neispravan broj tranzitne nalepnice!")
                    tbUlaznaNalepnica.Focus()
                Else

                    ''If TipTranzita = "ulaz" Then
                    ''    Dim xNaziv As String = ""
                    ''    Dim xPovVrednost As String = ""

                    ''    Util.sNadjiNalepnicu(tbUlaznaNalepnica.Text, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mObrGodina, mObrMesec, xNaziv, xPovVrednost)

                    ''    If xPovVrednost <> "" Then
                    ''        ErrorProvider1.SetError(tbUlaznaNalepnica, "")
                    ''    Else
                    ''        ErrorProvider1.SetError(tbUlaznaNalepnica, "Nalepnica sa tim brojem je uneta!")
                    ''        tbUlaznaNalepnica.Focus()
                    ''    End If
                    ''End If
                    ''Ispitati kod upisa u bazu
                End If

            Else
                ErrorProvider1.SetError(tbUlaznaNalepnica, "Neispravan broj tranzitne nalepnice!")
                tbUlaznaNalepnica.Focus()
            End If
        End If

    End Sub

    Private Sub tbIzlaznaNalepnica_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbIzlaznaNalepnica.Validated
        If tbIzlaznaNalepnica.Text = Nothing Then
            tbIzlaznaNalepnica.Focus()
        Else
            Me.tbUpravaOtp.Focus()
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "     Primalac"
        upit = "Primalac"
        helpUic.ShowDialog()
        Me.tb4a.Text = mIzlaz2
        Me.tb4b.Text = mIzlaz4
        Me.tb4b1.Text = Microsoft.VisualBasic.Mid(mIzlaz1, 3, Len(mIzlaz1))
        Me.tb4b2.Text = Microsoft.VisualBasic.Left(mIzlaz1, 2)
        Me.tb5.Text = CType(mIzlaz5, Integer)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "     Pošiljalac"
        upit = "Posiljalac"
        helpUic.ShowDialog()
        Me.tb1a.Text = mIzlaz2
        Me.tb1b.Text = mIzlaz4
        Me.tb1b1.Text = Microsoft.VisualBasic.Mid(mIzlaz1, 3, Len(mIzlaz1))
        Me.tb1b2.Text = Microsoft.VisualBasic.Left(mIzlaz1, 2)
        Me.tb2.Text = CType(mIzlaz5, Integer)


    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "     Korisnièke šifre"
        upit = "SifreKorisnika"
        helpUic.ShowDialog()
        Me.tb3.Text = CType(mIzlaz5, Integer)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "     Korisnièke šifre"
        upit = "SifreKorisnika"
        helpUic.ShowDialog()
        Me.tb6.Text = CType(mIzlaz5, Integer)

    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'upit
        'SELECT UicStanice.SifraStanice, UicStanice.Naziv, UicUprave.NazivE
        'FROM   UicStanice INNER JOIN
        '       UicUprave ON UicStanice._SifraUprave = UicUprave.SifraUprave
        'WHERE  (UicStanice.SifraStanice = '5106870')

    End Sub

    Private Sub tbUpravaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUpravaOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub tbStanicaOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaOtp.Validating
        If Len(tbStanicaOtp.Text) < 7 Then
            ErrorProvider1.SetError(tbStanicaOtp, "Neispravna sifra stanice!")
        Else
            Dim xNaziv As String = ""
            Dim xKB As String = ""
            Dim xZemlja As String = ""
            Dim xPovVrednost As String = ""

            '21.11.2013: ako je izvoz da ode u ZsStanice i prikaze broj blagajni!

            Util.sNadjiStanicu("UicStanice", tbStanicaOtp.Text, "", "", mBrojPokusaja, xNaziv, xKB, xZemlja, xPovVrednost)

            '21.11.2013: ako je izvoz da ode i u ZsStanice i prikaze broj blagajni!

            If xPovVrednost <> "" Then
                If mBrojPokusaja > 3 Then
                    mBrojPokusaja = 1
                    Label12.Text = "Nepostojeca sifra stanice"
                    mOtpStanica = tbStanicaOtp.Text
                    Me.tbStanicaOtp.BackColor = System.Drawing.Color.Red
                    ErrorProvider1.SetError(TextBox1, "")
                Else
                    mBrojPokusaja = mBrojPokusaja + 1
                    ErrorProvider1.SetError(TextBox1, "Nepostojeca stanica!")
                    tbStanicaOtp.Focus()
                End If
            Else
                ''zbog 3009!
                ''If Microsoft.VisualBasic.Right(Me.tbUpravaOtp.Text, 2) <> Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2) Then
                ''    mBrojPokusaja = mBrojPokusaja + 1
                ''    ErrorProvider1.SetError(TextBox1, "Sifre nisu uskladjene!")

                ''    tbUpravaOtp.Focus()
                ''Else
                ''    mBrojPokusaja = 1
                ''    Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
                ''    Label12.Text = xNaziv
                ''    mOtpStanica = tbStanicaOtp.Text

                ''    Me.tb16a.Text = xNaziv
                ''    Me.tb16b.Text = xZemlja
                ''    Me.tb17.Text = tbStanicaOtp.Text + TextBox1.Text
                ''    Me.tb29a.Text = xNaziv
                ''    tbA70a1.Text = "72"

                ''    Me.TextBox1.Text = xKB
                ''    ErrorProvider1.SetError(TextBox1, "")
                ''    mOtpUprava = Microsoft.VisualBasic.Mid(mOtpStanica, 1, 2)
                ''End If

                mBrojPokusaja = 1
                Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
                nmNazivOtpSt = xNaziv
                Label12.Text = xNaziv
                mOtpStanica = tbStanicaOtp.Text

                If eRazmena = "Da" Then

                Else
                    Me.tb16a.Text = xNaziv
                    Me.tb16b.Text = xZemlja
                    Me.tb17.Text = tbStanicaOtp.Text + TextBox1.Text
                    Me.tb29a.Text = xNaziv
                    tbA70a1.Text = "72"
                End If

                Me.TextBox1.Text = xKB
                ErrorProvider1.SetError(TextBox1, "")
                mOtpUprava = Microsoft.VisualBasic.Mid(mOtpStanica, 1, 2)
            End If
        End If

    End Sub

    Private Sub tbStanicaOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaOtp.Leave
        Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
        Me.tbStanicaOtp.ForeColor = System.Drawing.Color.Black

        If Len(tbStanicaOtp.Text) = 0 Then
            ErrorProvider1.SetError(tbStanicaOtp, "")
            ErrorProvider1.SetError(TextBox1, "")
            tbUpravaOtp.Focus()
        Else
            If Len(tbStanicaOtp.Text) < 7 Then
                ErrorProvider1.SetError(Me.TextBox1, "Neispravna sifra stanice!")
                tbStanicaOtp.Focus()
            Else
                ErrorProvider1.SetError(Me.TextBox1, "")
            End If
        End If

    End Sub

    Private Sub tbUpravaOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUpravaOtp.Validating
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""

        If Len(tbUpravaOtp.Text) = 0 Then
            ErrorProvider1.SetError(tbUpravaOtp, "")
            ComboBox1.Focus()
        Else
            Util.sNadjiNaziv("UicOperateri", tbUpravaOtp.Text, "", "", 1, xNaziv, xPovVrednost)
            '
            '''       Util.sNadjiNaziv("UicOperateri", Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 1, 2), Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2), "", 1, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                ErrorProvider1.SetError(tbUpravaOtp, "Nepostojeca uprava!")
                tbUpravaOtp.Focus()
            Else
                Label11.Text = Microsoft.VisualBasic.Mid(xNaziv, 3, Len(xNaziv))
                ''mOtpUprava = Microsoft.VisualBasic.Mid(tbStanicaOtp.Text, 1, 2)
                mOtpUprava = Microsoft.VisualBasic.Left(xNaziv, 2)

                If Len(tbStanicaOtp.Text) = 7 Then

                Else

                    tbStanicaOtp.Text = mOtpUprava 'Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2)
                    tbStanicaOtp.SelectionStart = 3
                End If
                ErrorProvider1.SetError(tbUpravaOtp, "")
            End If

        End If


    End Sub

    Private Sub tbStanicaOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
            'ElseIf e.KeyChar() = Microsoft.VisualBasic.ChrW(97) Then
            '    'MsgBox("ok")
            ''    Me.tbUpravaOtp.Focus()

        End If
    End Sub

    Private Sub tbBrojOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbBrojOtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.LostFocus
        If tbBrojOtp.Text = Nothing Then
            mOtpBroj = 0
        Else
            mOtpBroj = tbBrojOtp.Text
            If IzborSaobracaja <> "3" Then
                TB58a1.Text = Me.tbUpravaOtp.Text
                TB58a2.Text = Me.Label11.Text
            End If
        End If
    End Sub

    Private Sub tbBrojOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojOtp.Validating

        If tbBrojOtp.Text = "0" Then
            ErrorProvider1.SetError(Label15, "Broj otpravljanja ne moze da bude nula!")
            tbBrojOtp.Focus()
        Else
            If tbBrojOtp.Text = Nothing Then
                ErrorProvider1.SetError(Label15, "Neispravan broj otpravljanja!")
                tbStanicaOtp.Focus()

                'tbBrojOtp.Focus()
            Else
                If IsNumeric(tbBrojOtp.Text) = True Then
                    Dim tmp_kbotp As String
                    Dim tmp_brojotp As String

                    tmp_brojotp = Microsoft.VisualBasic.Right("00000" & tbBrojOtp.Text.ToString, 5)
                    'tmp_brojotp = tbBrojOtp.Text.ToString

                    b5Modul(tmp_brojotp, tmp_kbotp)
                    kbBrojOtp.Text = tmp_kbotp
                    ErrorProvider1.SetError(Label15, "")
                    tbBrojOtp.Text = Microsoft.VisualBasic.Right("00000" & tbBrojOtp.Text.ToString, 5)
                    Me.DatumOtp.Focus()

                Else
                    ErrorProvider1.SetError(Label15, "Neispravan unos!")
                    tbBrojOtp.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub DatumOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            'mOtpDatum = DatumOtp.Value.ToShortDateString
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub DatumOtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.LostFocus
        ''mOtpDatum = DatumOtp.Text

        mOtpDatum = DatumOtp.Value.ToShortDateString
        If nmAllowExit = False Then
            Button25_Click(Me, Nothing)
        End If

    End Sub

    Private Sub DatumOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DatumOtp.Validating
        'Dim mRetVal As String
        'Dim mRecID As Int32
        'Dim mStanicaRecID As String
        'Dim strOtpBroj As String = CType(tbBrojOtp.Text, String) & CType(kbBrojOtp.Text, String)
        'mRanzirna = ""
        'mRealizovan = ""

        ''---------------------------
        'Dim izPrUprava As String
        'Dim izPrStanica As String
        'Dim izPrDatum As Date
        'Dim izSaobracaj As String
        'Dim izZsPrelaz As String
        'Dim izZsUlPrelaz As String
        'Dim izZsIzPrelaz As String
        'Dim izNalepnica As Int32
        'Dim izNajava As String
        'Dim izNajava2 As String
        'Dim izSifraTarife As String
        'Dim izUgovor As String
        'Dim mDatum As Date
        ''---------------------------

        'mOtpDatum = Me.DatumOtp.Value.ToShortDateString

        'mMesec = mOtpDatum.Month.ToString
        'mDan = mOtpDatum.Day.ToString
        'mGodina = mOtpDatum.Year.ToString

        ''---------------------------------------------------------------
        'If IzborSaobracaja = "3" Then   'izvoz ŽS
        '    'mGodina: traži u tekucoj godini

        '    NadjiTL1(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), mGodina, mRecID, mStanicaRecID, mOtpDatum, mRanzirna, mRealizovan, mRetVal)

        '    If mRetVal <> "" Then '------------ našao!
        '        If mRealizovan = "99999" Then 'pr. subotica
        '            ' zašto je ovo trebalo? mOtpDatum = Me.DatumOtp.Value.ToShortDateString
        '            MessageBox.Show("Ovaj tovarni list je obradjen! Promenite podatke o posiljci.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Me.tbBrojOtp.Focus()
        '        Else 'pr. mladenovac/bg ranžirna
        '            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) <> mStanicaRecID Then
        '                MessageBox.Show("Ovaj dokument je unet u stanici " & RTrim(Label12.Text), "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Me.Close()

        '                mRetVal = ""
        '                Util.eNadjiTovarniListUI(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), mOtpDatum, mRecID, mStanicaRecID, _
        '                                         mUlPrelaz, mIzPrelaz, msBrojVoza, mSatVoza, msBrojVoza2, mSatVoza2, _
        '                                         mDatumUlaza, mDatumIzlaza, izSifraTarife, izUgovor, mCarStanica, mCarStanica2, _
        '                                         mRetVal)

        '                If mRetVal = "" Then
        '                    UpdRecID = mRecID
        '                    UpdStanicaRecID = mStanicaRecID
        '                    UpdUprava = mOtpUprava
        '                    UpdStanica = mOtpStanica
        '                    UpdBroj = mOtpBroj
        '                    UpdDatum = mOtpDatum

        '                    mTarifa = izSifraTarife
        '                    mBrojUg = izUgovor

        '                    Dim form2 As New FormUpdateCimGr
        '                    form2.ShowDialog()
        '                    Close()

        '                Else
        '                    MessageBox.Show("Ne postoji mogucnost prikaza podataka!" & mRetVal, "Poruka iz baze: 5284", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                End If
        '            Else
        '                MessageBox.Show("Ovaj dokument je unet u stanici " & RTrim(Label12.Text) & ". Promenite broj tovarnog lista.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                tbBrojOtp.Focus()

        '            End If
        '        End If
        '    Else                 '------------ nije našao!

        '        mDatumKalk = DatumOtp.Value
        '        mOtpDatum = DatumOtp.Text
        '        Me.tb52a.Text = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2)
        '        Me.tb52b.Text = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5)
        '        Me.tb52c.Text = Me.TextBox1.Text
        '        Me.tb52d.Text = Me.tbUpravaOtp.Text
        '        Me.tb52e.Text = Me.tbBrojOtp.Text & Me.kbBrojOtp.Text

        '        Me.tb29b.Text = Me.DatumOtp.Value.Year.ToString + "-" + Me.DatumOtp.Value.Month.ToString + "-" + Me.DatumOtp.Value.Day.ToString
        '        Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString
        '        Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString

        '        Me.tb16c.Text = Me.DatumOtp.Value.Month.ToString
        '        Me.tb16d.Text = Me.DatumOtp.Value.Day.ToString

        '        If Len(Me.tb29b_1.Text) = 1 Then
        '            Me.tb29b_1.Text = "0" & Me.DatumOtp.Value.Day.ToString + "."
        '        Else
        '            Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString + "."
        '        End If
        '        If Len(Me.tb29b_2.Text) = 1 Then
        '            Me.tb29b_2.Text = "0" & Me.DatumOtp.Value.Month.ToString + "."
        '        Else
        '            Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString + "."
        '        End If
        '        Me.tb29b_3.Text = Me.DatumOtp.Value.Year.ToString

        '        Me.tbUpravaPr.Focus()

        '    End If

        'Else 'Tranzit/Uvoz
        '    'mOtpDatum = DatumOtp.Text
        '    'mOtpDatum = DatumOtp.Value.ToShortDateString

        '    NadjiTL1TU(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), mOtpDatum, mRecID, mStanicaRecID, mRetVal)
        '    'NadjiTL1TU(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), Me.DatumOtp.Value.ToShortDateString, mRecID, mStanicaRecID, mRetVal)

        '    If mRetVal <> "" Then '------------ našao!
        '        tbBrojOtp.Focus()

        '    Else                  '------------ nije našao!
        '        tbUpravaPr.Focus()
        '    End If
        '    'NadjiTLuBazi(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), mOtpDatum, UpdRecID, UpdStanicaRecID, mRetVal)
        'End If
        ''---------------------------------------------------------------

        ''If mRetVal = "" Then 'nasao!

        ''    mDatumKalk = DatumOtp.Value
        ''    mOtpDatum = DatumOtp.Text
        ''    Me.tb52a.Text = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2)
        ''    Me.tb52b.Text = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5)
        ''    Me.tb52c.Text = Me.TextBox1.Text
        ''    Me.tb52d.Text = Me.tbUpravaOtp.Text
        ''    Me.tb52e.Text = Me.tbBrojOtp.Text & Me.kbBrojOtp.Text

        ''    Me.tb29b.Text = Me.DatumOtp.Value.Year.ToString + "-" + Me.DatumOtp.Value.Month.ToString + "-" + Me.DatumOtp.Value.Day.ToString
        ''    Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString
        ''    Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString

        ''    Me.tb16c.Text = Me.DatumOtp.Value.Month.ToString
        ''    Me.tb16d.Text = Me.DatumOtp.Value.Day.ToString

        ''    If Len(Me.tb29b_1.Text) = 1 Then
        ''        Me.tb29b_1.Text = "0" & Me.DatumOtp.Value.Day.ToString + "."
        ''    Else
        ''        Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString + "."
        ''    End If
        ''    If Len(Me.tb29b_2.Text) = 1 Then
        ''        Me.tb29b_2.Text = "0" & Me.DatumOtp.Value.Month.ToString + "."
        ''    Else
        ''        Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString + "."
        ''    End If
        ''    Me.tb29b_3.Text = Me.DatumOtp.Value.Year.ToString

        ''    If IzborSaobracaja = "2" Then
        ''        If GranicnaStanica = "D" Then
        ''            Me.tbStanicaPr.Focus()
        ''            Me.tbStanicaPr.Text = "72"
        ''            Me.tbStanicaPr.SelectionStart = 3
        ''        Else
        ''            Me.tbStanicaPr.Text = "72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)
        ''            'Me.tbStanicaPr.SelectionStart = 3
        ''            Me.tbStanicaPr.Focus()
        ''        End If
        ''    Else
        ''        Me.tbUpravaPr.Focus()
        ''    End If

        ''Else

        ''    If RecordAction = "N" And UpdUprava = tbUpravaOtp.Text And UpdStanica = tbStanicaOtp.Text And UpdBroj = tbBrojOtp.Text And UpdDatum = mOtpDatum Then
        ''        tbUpravaPr.Focus()
        ''    Else

        ''        If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) <> mStanicaRecID Then
        ''            If mRanzirna = "R" And mRealizovan <> "99999" Then 'update pa formira fb-xml
        ''                mDatumKalk = DatumOtp.Value
        ''                'mOtpDatum = DatumOtp.Text
        ''                Me.tb52a.Text = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2)
        ''                Me.tb52b.Text = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5)
        ''                Me.tb52c.Text = Me.TextBox1.Text
        ''                Me.tb52d.Text = Me.tbUpravaOtp.Text
        ''                Me.tb52e.Text = Me.tbBrojOtp.Text & Me.kbBrojOtp.Text

        ''                Me.tb29b.Text = Me.DatumOtp.Value.Year.ToString + "-" + Me.DatumOtp.Value.Month.ToString + "-" + Me.DatumOtp.Value.Day.ToString
        ''                Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString
        ''                Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString

        ''                Me.tb16c.Text = Me.DatumOtp.Value.Month.ToString
        ''                Me.tb16d.Text = Me.DatumOtp.Value.Day.ToString

        ''                If Len(Me.tb29b_1.Text) = 1 Then
        ''                    Me.tb29b_1.Text = "0" & Me.DatumOtp.Value.Day.ToString + "."
        ''                Else
        ''                    Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString + "."
        ''                End If
        ''                If Len(Me.tb29b_2.Text) = 1 Then
        ''                    Me.tb29b_2.Text = "0" & Me.DatumOtp.Value.Month.ToString + "."
        ''                Else
        ''                    Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString + "."
        ''                End If
        ''                Me.tb29b_3.Text = Me.DatumOtp.Value.Year.ToString

        ''                'popuni sva polja i 2 grida

        ''                Util.NadjiCIM_L(mRecID, mStanicaRecID, izPrUprava, izPrStanica, mRetVal)

        ''                If dtKola.Rows.Count > 0 Then
        ''                    'Me.tbKolauVozu.Text = "[ " & CStr(dtKola.Rows.Count) & " ]"
        ''                    Me.tbKolauVozu.Text = CStr(dtKola.Rows.Count)
        ''                End If

        ''                Me.tbUpravaPr.Text = izPrUprava
        ''                Me.tbStanicaPr.Text = izPrStanica

        ''                mAkcija = "Upd"

        ''                Me.tbUpravaPr.Focus()

        ''            Else
        ''                If mRealizovan = "99999" Then
        ''                    MessageBox.Show("Ovaj dokument je obradjen! Promenite broj tovarnog lista.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''                    Me.Close()
        ''                Else
        ''                    If IzborSaobracaja = "3" Then
        ''                        MessageBox.Show("Ovaj dokument je unet u stanici " & Label12.Text, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''                        Me.Close()

        ''                        '=============== Prikazi podatke =================================================================
        ''                        mRetVal = ""
        ''                        'Dim izSifraTarife As String
        ''                        'Dim izUgovor As String
        ''                        IzborSaobracaja = "3"

        ''                        Util.eNadjiTovarniListUI(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), mOtpDatum, mRecID, mStanicaRecID, _
        ''                                                 mUlPrelaz, mIzPrelaz, msBrojVoza, mSatVoza, msBrojVoza2, mSatVoza2, _
        ''                                                 mDatumUlaza, mDatumIzlaza, izSifraTarife, izUgovor, mCarStanica, mCarStanica2, _
        ''                                                 mRetVal)

        ''                        If mRetVal = "" Then
        ''                            UpdRecID = mRecID
        ''                            UpdStanicaRecID = mStanicaRecID
        ''                            UpdUprava = mOtpUprava
        ''                            UpdStanica = mOtpStanica
        ''                            UpdBroj = mOtpBroj
        ''                            UpdDatum = mOtpDatum

        ''                            mTarifa = izSifraTarife
        ''                            mBrojUg = izUgovor

        ''                            Dim form2 As New FormUpdateCimGr
        ''                            form2.ShowDialog()
        ''                            Close()

        ''                        Else
        ''                            MessageBox.Show("Ne postoji mogucnost prikaza podataka!" & mRetVal, "Poruka iz baze: 5284", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ''                        End If

        ''                    Else
        ''                        mDatumKalk = DatumOtp.Value
        ''                        'mOtpDatum = DatumOtp.Text
        ''                        Me.tb52a.Text = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2)
        ''                        Me.tb52b.Text = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5)
        ''                        Me.tb52c.Text = Me.TextBox1.Text
        ''                        Me.tb52d.Text = Me.tbUpravaOtp.Text
        ''                        Me.tb52e.Text = Me.tbBrojOtp.Text & Me.kbBrojOtp.Text

        ''                        Me.tb29b.Text = Me.DatumOtp.Value.Year.ToString + "-" + Me.DatumOtp.Value.Month.ToString + "-" + Me.DatumOtp.Value.Day.ToString
        ''                        Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString
        ''                        Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString

        ''                        Me.tb16c.Text = Me.DatumOtp.Value.Month.ToString
        ''                        Me.tb16d.Text = Me.DatumOtp.Value.Day.ToString

        ''                        If Len(Me.tb29b_1.Text) = 1 Then
        ''                            Me.tb29b_1.Text = "0" & Me.DatumOtp.Value.Day.ToString + "."
        ''                        Else
        ''                            Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString + "."
        ''                        End If
        ''                        If Len(Me.tb29b_2.Text) = 1 Then
        ''                            Me.tb29b_2.Text = "0" & Me.DatumOtp.Value.Month.ToString + "."
        ''                        Else
        ''                            Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString + "."
        ''                        End If
        ''                        Me.tb29b_3.Text = Me.DatumOtp.Value.Year.ToString

        ''                        Me.tbUpravaPr.Focus()

        ''                    End If

        ''                    'MessageBox.Show("Ovaj dokument je unet u stanici " & Label12.Text, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''                    'Me.Close()

        ''                    ''=============== Prikazi podatke =================================================================
        ''                    'mRetVal = ""
        ''                    ''Dim izSifraTarife As String
        ''                    ''Dim izUgovor As String
        ''                    'IzborSaobracaja = "3"

        ''                    'Util.eNadjiTovarniListUI(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), mOtpDatum, mRecID, mStanicaRecID, _
        ''                    '                         mUlPrelaz, mIzPrelaz, msBrojVoza, mSatVoza, msBrojVoza2, mSatVoza2, _
        ''                    '                         mDatumUlaza, mDatumIzlaza, izSifraTarife, izUgovor, mCarStanica, mCarStanica2, _
        ''                    '                         mRetVal)

        ''                    'If mRetVal = "" Then
        ''                    '    UpdRecID = mRecID
        ''                    '    UpdStanicaRecID = mStanicaRecID
        ''                    '    UpdUprava = mOtpUprava
        ''                    '    UpdStanica = mOtpStanica
        ''                    '    UpdBroj = mOtpBroj
        ''                    '    UpdDatum = mOtpDatum

        ''                    '    mTarifa = izSifraTarife
        ''                    '    mBrojUg = izUgovor

        ''                    '    Dim form2 As New FormUpdateCimGr
        ''                    '    form2.ShowDialog()
        ''                    '    Close()

        ''                    'Else
        ''                    '    MessageBox.Show("Ne postoji mogucnost prikaza podataka!" & mRetVal, "Poruka iz baze: 5284", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ''                    'End If

        ''                End If

        ''            End If
        ''        Else
        ''            MessageBox.Show("Takav broj otpravljanja je vec unet! ", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ''            tbBrojOtp.Focus()
        ''        End If
        ''    End If
        ''End If

    End Sub

    Private Sub tbUpravaPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbUpravaPr.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbUpravaPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUpravaPr.Validating
        Dim xNaziv As String = ""
        Dim xPovVrednost As String = ""

        If Len(tbUpravaPr.Text) = 0 Then
            ErrorProvider1.SetError(tbUpravaPr, "")
            DatumOtp.Focus()
        Else
            Util.sNadjiNaziv("UicOperateri", tbUpravaPr.Text, "", "", 1, xNaziv, xPovVrednost)
            'Util.sNadjiNaziv("UicOperateri", Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 1, 2), Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2), "", 1, xNaziv, xPovVrednost)

            If xPovVrednost <> "" Then
                ErrorProvider1.SetError(tbUpravaPr, "Nepostojeca uprava!")
                tbUpravaPr.Focus()
            Else
                If tbUpravaOtp.Text = tbUpravaPr.Text Then
                    ErrorProvider1.SetError(tbUpravaPr, "Otpravna i uputna uprava moraju biti razlicite!")
                    tbUpravaPr.Focus()
                Else
                    Label14.Text = Microsoft.VisualBasic.Mid(xNaziv, 3, Len(xNaziv))
                    mPrUprava = Microsoft.VisualBasic.Left(xNaziv, 2)

                    If Len(tbStanicaPr.Text) = 7 Then

                    Else
                        tbStanicaPr.Text = mPrUprava
                        tbStanicaPr.SelectionStart = 3
                    End If
                    ErrorProvider1.SetError(tbUpravaPr, "")

                End If
            End If

        End If
    End Sub

    Private Sub tbStanicaPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbStanicaPr.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbStanicaPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.Leave
        Me.tbStanicaPr.BackColor = System.Drawing.Color.White
        Me.tbStanicaPr.ForeColor = System.Drawing.Color.Black

        If Len(tbStanicaPr.Text) = 0 Then
            ErrorProvider1.SetError(tbStanicaPr, "")
            ErrorProvider1.SetError(TextBox2, "")
            tbUpravaPr.Focus()
        Else
            If Len(tbStanicaPr.Text) < 7 Then
                ErrorProvider1.SetError(Me.TextBox2, "Neispravna sifra stanice!")
                tbStanicaPr.Focus()
            Else
                ErrorProvider1.SetError(Me.TextBox2, "")
                If IzborSaobracaja = "2" Then
                    Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
                    Me.tbA70b2.Text = Microsoft.VisualBasic.Right(Me.tbStanicaPr.Text, 5)
                ElseIf IzborSaobracaja = "3" Then
                    Me.tbA70b1.Text = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5)
                    Me.tbA70b2.Text = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
                ElseIf IzborSaobracaja = "4" Then
                    Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
                    Me.tbA70b2.Text = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
                End If
                Daljinar()

                '------------------------------------------------------------------------------
                If IzborSaobracaja = "3" Then
                    '''novo
                    ''If eCimDa = "D" Then
                    ''    If (Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55") Or _
                    ''       (Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "53") Or _
                    ''       (Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52") Or _
                    ''       (Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65") Or _
                    ''       (Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62") Or _
                    ''       (Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44") Or _
                    ''       (Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78") Or _
                    ''       (Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78") Then

                    ''        Me.gbPrevozniPut.Enabled = False
                    ''        Me.cbR57.Enabled = False
                    ''        Me.tbsBrojVoza.Focus()
                    ''    Else 'nije susedna uprava

                    ''        'stanica na mrezi
                    ''        If GranicnaStanica = "N" Then


                    ''        Else


                    ''        End If

                    ''        If GranicnaStanica = "N" And (Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Or _
                    ''           Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "50" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44" Or _
                    ''           Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65" Or _
                    ''           Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "73" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "75" Or _
                    ''           Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "53") Then

                    ''        Else 'granicna

                    ''            Me.gbPrevozniPut.Enabled = True
                    ''            Me.cbR57.Enabled = True
                    ''            Me.cmbPrevPut.Focus()
                    ''        End If

                    ''    End If


                    ''Else
                    ''    Me.gbPrevozniPut.Enabled = False
                    ''    Me.cbR57.Enabled = False
                    ''    Me.tbsBrojVoza.Focus()

                    ''End If
                    '''end novo



                    If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then
                        Me.gbPrevozniPut.Enabled = False
                        Me.cbR57.Enabled = False
                        Me.tbsBrojVoza.Focus()
                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "53" Then
                        Me.gbPrevozniPut.Enabled = False
                        Me.cbR57.Enabled = False
                        Me.tbsBrojVoza.Focus()
                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Then
                        Me.gbPrevozniPut.Enabled = False
                        Me.cbR57.Enabled = False
                        Me.tbsBrojVoza.Focus()
                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65" Then
                        Me.gbPrevozniPut.Enabled = False
                        Me.cbR57.Enabled = False
                        Me.tbsBrojVoza.Focus()
                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62" Then
                        Me.gbPrevozniPut.Enabled = False
                        Me.cbR57.Enabled = False
                        Me.tbsBrojVoza.Focus()
                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44" Then
                        Me.gbPrevozniPut.Enabled = False
                        Me.cbR57.Enabled = False
                        Me.tbsBrojVoza.Focus()
                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
                        Me.gbPrevozniPut.Enabled = False
                        Me.cbR57.Enabled = False
                        Me.tbsBrojVoza.Focus()
                    ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
                        Me.gbPrevozniPut.Enabled = False
                        Me.cbR57.Enabled = False
                        Me.tbsBrojVoza.Focus()
                    Else
                        If eCimDa = "D" Then

                            If GranicnaStanica = "N" And (Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Or _
                               Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "50" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44" Or _
                               Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65" Or _
                               Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "73" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "75" Or _
                               Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "41" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Or Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "53") Then

                                '(Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) <> "23499" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) <> "16517" Or Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) <> "25471") Then

                                Me.gbPrevozniPut.Enabled = False
                                Me.cbR57.Enabled = False
                                'Me.tbsBrojVoza.Focus()
                                btnUnosRobe_Click(Me, Nothing)

                            Else
                                Me.gbPrevozniPut.Enabled = True
                                Me.cbR57.Enabled = True
                                Me.cmbPrevPut.Focus()
                            End If

                        Else
                            Me.gbPrevozniPut.Enabled = False
                            Me.cbR57.Enabled = False
                            Me.tbsBrojVoza.Focus()
                        End If
                    End If
                Else
                    If BlagajnaUnosa = Microsoft.VisualBasic.Right(Me.tbStanicaPr.Text, 5) Then
                        'Me.tbBrojPr.Focus()
                        If GranicnaStanica = "N" Then
                            Me.tbBrojPr.Focus()
                        Else
                            Me.tbsBrojVoza.Focus()
                        End If

                    Else
                        Me.tbBrojPr.Text = 0
                        Me.kbBrojPr.Text = 0

                        Me.tbsBrojVoza.Focus()
                    End If
                End If

            End If

        End If
    End Sub

    Private Sub tbStanicaPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStanicaPr.Validating
        If Len(tbStanicaPr.Text) = 0 Then
            tbUpravaPr.Focus()
        Else
            If Len(tbStanicaPr.Text) < 7 Then
                ErrorProvider1.SetError(tbStanicaPr, "Neispravna sifra stanice!")
            Else
                Dim xNaziv As String = ""
                Dim xKB As String = ""
                Dim xZemlja As String = ""
                Dim xPovVrednost As String = ""

                Util.sNadjiStanicu("UicStanice", tbStanicaPr.Text, "", "", mBrojPokusaja, xNaziv, xKB, xZemlja, xPovVrednost)

                If xPovVrednost <> "" Then
                    If mBrojPokusaja > 3 Then
                        mBrojPokusaja = 1
                        Label13.Text = "Nepostojeca sifra stanice"
                        mPrStanica = tbStanicaPr.Text
                        Me.tbStanicaPr.BackColor = System.Drawing.Color.Red
                        ErrorProvider1.SetError(TextBox2, "")
                    Else
                        mBrojPokusaja = mBrojPokusaja + 1
                        ErrorProvider1.SetError(TextBox2, "Nepostojeca stanica!")
                        tbStanicaPr.Focus()
                    End If
                Else
                    '--iskljucena kontrola identicnosti zbog novih operatera 15.12.2010
                    mBrojPokusaja = 1
                    Me.tbStanicaPr.BackColor = System.Drawing.Color.White
                    Label13.Text = xNaziv

                    If eRazmena = "Da" Then

                    Else
                        tbA70a2.Text = "72"
                        Me.tb10a.Text = xNaziv
                        Me.tb10b.Text = xZemlja
                        Me.tb12.Text = tbStanicaPr.Text
                    End If

                    '---
                    mPrStanica = tbStanicaPr.Text
                    Me.TextBox2.Text = xKB
                    ErrorProvider1.SetError(TextBox2, "")
                    mPrUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)

                    '---------------------
                    If IzborSaobracaja = "3" Then
                        'granicne stanice
                        If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()

                            m_UicPrevozniPut = "55"
                            Me.cmbPrevPut.Text = "55"
                            Me.tb50.Text = "5511 SUBOTICA"

                            Me.ListBox1.Items.Add("2155 MAV Cargo")
                            Me.ListBox2.Items.Add("550711")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")
                        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "53" Then
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()

                            m_UicPrevozniPut = "53"
                            Me.cmbPrevPut.Text = "53"
                            Me.tb50.Text = "5311 ST.MORAVITA"

                            Me.ListBox1.Items.Add("2153 CFR Marfa")
                            Me.ListBox2.Items.Add("530661")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")

                        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Then
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()

                            m_UicPrevozniPut = "52"
                            Me.cmbPrevPut.Text = "52"
                            Me.tb50.Text = "5262 DIMITROVGRAD"

                            Me.ListBox1.Items.Add("0052 BDZ")
                            Me.ListBox2.Items.Add("520620")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")

                        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65" Then
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()

                            m_UicPrevozniPut = "65"
                            Me.cmbPrevPut.Text = "65"
                            Me.tb50.Text = "6576 PRESEVO"

                            Me.ListBox1.Items.Add("0065 MZ")
                            Me.ListBox2.Items.Add("650676")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")

                        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62" Then
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()

                            m_UicPrevozniPut = "62"
                            Me.cmbPrevPut.Text = "62"
                            Me.tb50.Text = "6271 PRIJEPOLJE"

                            Me.ListBox1.Items.Add("1062 ZCG")
                            Me.ListBox2.Items.Add("620671")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")

                        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44" Then
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()

                            m_UicPrevozniPut = "44"
                            Me.cmbPrevPut.Text = "44"
                            Me.tb50.Text = "4491 BRASINA"
                            Me.rtb57a.Items.Add("0044 ZRS")
                            Me.rtb57b.Items.Add("440591")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")
                        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "50" Then
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()

                            m_UicPrevozniPut = "50"
                            Me.cmbPrevPut.Text = "50"
                            Me.tb50.Text = "5091 BRASINA"
                            Me.rtb57a.Items.Add("0050 ZFBH")
                            Me.rtb57b.Items.Add("500591")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")
                        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()

                            m_UicPrevozniPut = "78"
                            Me.cmbPrevPut.Text = "78"
                            Me.tb50.Text = "7801 SID"

                            Me.ListBox1.Items.Add("2178 HZ Cargo")
                            Me.ListBox2.Items.Add("780501")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")

                        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
                        Else
                        End If

                        'stanice na mrezi
                        If GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then
                            Me.rtb57a.Items.Clear()
                            Me.rtb57b.Items.Clear()
                            Me.rtb57b2.Items.Clear()
                            Me.rtb57c.Items.Clear()

                            m_UicPrevozniPut = "55"
                            Me.cmbPrevPut.Text = "55"
                            Me.tb50.Text = "5511 SUBOTICA"
                            'NizR50(0, 0) = 5511
                            'NizR50(0, 1) = "KELEBIA"
                            Me.rtb57a.Items.Add("2155 RCH")
                            Me.rtb57b.Items.Add("550711")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")

                            '=novo 23.12.2011
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()

                            'm_UicPrevozniPut = "55"
                            'Me.cmbPrevPut.Text = "55"
                            'Me.tb50.Text = "5511 SUBOTICA"

                            Me.ListBox1.Items.Add("2155 RCH")
                            Me.ListBox2.Items.Add("550711")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")

                        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
                            Me.rtb57a.Items.Clear()
                            Me.rtb57b.Items.Clear()
                            Me.rtb57b2.Items.Clear()
                            Me.rtb57c.Items.Clear()

                            m_UicPrevozniPut = "78"
                            Me.cmbPrevPut.Text = "78"
                            Me.tb50.Text = "7801 SID"
                            'NizR50(0, 0) = 5511
                            'NizR50(0, 1) = "KELEBIA"
                            Me.rtb57a.Items.Add("0078 HZ Cargo")
                            Me.rtb57b.Items.Add("780501")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()
                            Me.ListBox1.Items.Add("2178 HZ Cargo")
                            Me.ListBox2.Items.Add("780501")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")
                        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "50" Then
                            Me.rtb57a.Items.Clear()
                            Me.rtb57b.Items.Clear()
                            Me.rtb57b2.Items.Clear()
                            Me.rtb57c.Items.Clear()

                            m_UicPrevozniPut = "50"
                            Me.cmbPrevPut.Text = "50"
                            Me.tb50.Text = "5091 BRASINA"
                            'NizR50(0, 0) = 5511
                            'NizR50(0, 1) = "KELEBIA"
                            Me.rtb57a.Items.Add("0050 ZFBIH")
                            Me.rtb57b.Items.Add("500591")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()
                            Me.ListBox1.Items.Add("0050 ZFBIH")
                            Me.ListBox2.Items.Add("500591")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")
                        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44" Then
                            Me.rtb57a.Items.Clear()
                            Me.rtb57b.Items.Clear()
                            Me.rtb57b2.Items.Clear()
                            Me.rtb57c.Items.Clear()

                            m_UicPrevozniPut = "44"
                            Me.cmbPrevPut.Text = "44"
                            Me.tb50.Text = "4491 BRASINA"
                            'NizR50(0, 0) = 5511
                            'NizR50(0, 1) = "KELEBIA"
                            Me.rtb57a.Items.Add("0044 ZRS")
                            Me.rtb57b.Items.Add("440591")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()
                            Me.ListBox1.Items.Add("0044 ZRS")
                            Me.ListBox2.Items.Add("440591")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")
                        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62" Then
                            Me.rtb57a.Items.Clear()
                            Me.rtb57b.Items.Clear()
                            Me.rtb57b2.Items.Clear()
                            Me.rtb57c.Items.Clear()

                            m_UicPrevozniPut = "62"
                            Me.cmbPrevPut.Text = "62"
                            Me.tb50.Text = "6271 PRIJEPOLJE"
                            Me.rtb57a.Items.Add("2162 ZCG")
                            Me.rtb57b.Items.Add("620671")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()
                            Me.ListBox1.Items.Add("2162 ZCG")
                            Me.ListBox2.Items.Add("620671")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")
                        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65" Then
                            Me.rtb57a.Items.Clear()
                            Me.rtb57b.Items.Clear()
                            Me.rtb57b2.Items.Clear()
                            Me.rtb57c.Items.Clear()

                            m_UicPrevozniPut = "65"
                            Me.cmbPrevPut.Text = "65"
                            Me.tb50.Text = "6576 PRESEVO"
                            Me.rtb57a.Items.Add("2165 MZ")
                            Me.rtb57b.Items.Add("650676")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()
                            Me.ListBox1.Items.Add("2165 MZ")
                            Me.ListBox2.Items.Add("650676")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")
                        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Then
                            Me.rtb57a.Items.Clear()
                            Me.rtb57b.Items.Clear()
                            Me.rtb57b2.Items.Clear()
                            Me.rtb57c.Items.Clear()

                            m_UicPrevozniPut = "52"
                            Me.cmbPrevPut.Text = "52"
                            Me.tb50.Text = "5262 DIMITROVGRAD"
                            'NizR50(0, 0) = 5511
                            'NizR50(0, 1) = "KELEBIA"
                            Me.rtb57a.Items.Add("2152 BDZ")
                            Me.rtb57b.Items.Add("520620")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()
                            Me.ListBox1.Items.Add("2152 BDZ")
                            Me.ListBox2.Items.Add("520620")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")
                        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "53" Then
                            Me.rtb57a.Items.Clear()
                            Me.rtb57b.Items.Clear()
                            Me.rtb57b2.Items.Clear()
                            Me.rtb57c.Items.Clear()

                            m_UicPrevozniPut = "53"
                            Me.cmbPrevPut.Text = "53"
                            Me.tb50.Text = "5361 VRSAC"
                            'NizR50(0, 0) = 5511
                            'NizR50(0, 1) = "KELEBIA"
                            Me.rtb57a.Items.Add(tbUpravaPr.Text & " " & RTrim(Label14.Text)) 'Me.rtb57a.Items.Add("2153 CFR")
                            Me.rtb57b.Items.Add("530661")
                            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.rtb57c.Items.Add("1")
                            Me.ListBox1.Items.Clear()
                            Me.ListBox2.Items.Clear()
                            Me.ListBox3.Items.Clear()
                            Me.ListBox4.Items.Clear()
                            Me.ListBox1.Items.Add(tbUpravaPr.Text & " " & RTrim(Label14.Text)) 'Me.ListBox1.Items.Add("2153 CFR")
                            Me.ListBox2.Items.Add("530661")
                            Me.ListBox3.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                            Me.ListBox4.Items.Add("1")
                        End If
                    End If
                    '--end

                    '''If Microsoft.VisualBasic.Right(Me.tbUpravaPr.Text, 2) <> Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) Then
                    '''    mBrojPokusaja = mBrojPokusaja + 1
                    '''    ErrorProvider1.SetError(TextBox2, "Sifre nisu iskladjene!")
                    '''    tbUpravaPr.Focus()
                    '''Else
                    '''    mBrojPokusaja = 1
                    '''    Me.tbStanicaPr.BackColor = System.Drawing.Color.White
                    '''    Label13.Text = xNaziv

                    '''    If eRazmena = "Da" Then

                    '''    Else
                    '''        tbA70a2.Text = "72"
                    '''        Me.tb10a.Text = xNaziv
                    '''        Me.tb10b.Text = xZemlja
                    '''        Me.tb12.Text = tbStanicaPr.Text
                    '''    End If

                    '''    '---
                    '''    mPrStanica = tbStanicaPr.Text
                    '''    Me.TextBox2.Text = xKB
                    '''    ErrorProvider1.SetError(TextBox2, "")
                    '''    mPrUprava = Microsoft.VisualBasic.Mid(mPrStanica, 1, 2)

                    '''    '---------------------
                    '''    If IzborSaobracaja = "3" Then
                    '''        'granicne stanice
                    '''        If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then
                    '''            '''Me.rtb57a.Items.Clear()
                    '''            '''Me.rtb57b.Items.Clear()
                    '''            '''Me.rtb57b2.Items.Clear()
                    '''            '''Me.rtb57c.Items.Clear()

                    '''            Me.ListBox1.Items.Clear()
                    '''            Me.ListBox2.Items.Clear()
                    '''            Me.ListBox3.Items.Clear()
                    '''            Me.ListBox4.Items.Clear()


                    '''            m_UicPrevozniPut = "55"
                    '''            Me.cmbPrevPut.Text = "55"
                    '''            Me.tb50.Text = "5511 SUBOTICA"
                    '''            'NizR50(0, 0) = 5511
                    '''            'NizR50(0, 1) = "KELEBIA"
                    '''            '''Me.rtb57a.Items.Add("2155 MAV Cargo")
                    '''            '''Me.rtb57b.Items.Add("550711")
                    '''            '''Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            '''Me.rtb57c.Items.Add("1")

                    '''            Me.ListBox1.Items.Add("2155 MAV Cargo")
                    '''            Me.ListBox1.Items.Add("550711")
                    '''            Me.ListBox1.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            Me.ListBox1.Items.Add("1")


                    '''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "53" Then
                    '''            'Me.cmbPrevPut.Text = "53"
                    '''            'Me.tb50.Text = "5311 ST.MORAVITA"
                    '''            'Me.rtb57a.Items.Add("2153 CFR Marfa")
                    '''            'Me.rtb57b.Items.Add("530661")
                    '''            'Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            'Me.rtb57c.Items.Add("1")

                    '''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Then
                    '''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65" Then
                    '''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62" Then
                    '''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44" Then
                    '''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
                    '''        ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
                    '''        Else
                    '''        End If

                    '''        'stanice na mrezi
                    '''        If GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then
                    '''            Me.rtb57a.Items.Clear()
                    '''            Me.rtb57b.Items.Clear()
                    '''            Me.rtb57b2.Items.Clear()
                    '''            Me.rtb57c.Items.Clear()

                    '''            m_UicPrevozniPut = "55"
                    '''            Me.cmbPrevPut.Text = "55"
                    '''            Me.tb50.Text = "5511 SUBOTICA"
                    '''            'NizR50(0, 0) = 5511
                    '''            'NizR50(0, 1) = "KELEBIA"
                    '''            Me.rtb57a.Items.Add("2155 Rail Cargo Hungaria")
                    '''            Me.rtb57b.Items.Add("550711")
                    '''            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            Me.rtb57c.Items.Add("1")
                    '''        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "78" Then
                    '''            Me.rtb57a.Items.Clear()
                    '''            Me.rtb57b.Items.Clear()
                    '''            Me.rtb57b2.Items.Clear()
                    '''            Me.rtb57c.Items.Clear()

                    '''            m_UicPrevozniPut = "78"
                    '''            Me.cmbPrevPut.Text = "78"
                    '''            Me.tb50.Text = "7801 SID"
                    '''            'NizR50(0, 0) = 5511
                    '''            'NizR50(0, 1) = "KELEBIA"
                    '''            Me.rtb57a.Items.Add("0078 HZ Cargo")
                    '''            Me.rtb57b.Items.Add("780501")
                    '''            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            Me.rtb57c.Items.Add("1")
                    '''        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "50" Then
                    '''            Me.rtb57a.Items.Clear()
                    '''            Me.rtb57b.Items.Clear()
                    '''            Me.rtb57b2.Items.Clear()
                    '''            Me.rtb57c.Items.Clear()

                    '''            m_UicPrevozniPut = "50"
                    '''            Me.cmbPrevPut.Text = "50"
                    '''            Me.tb50.Text = "5091 BRASINA"
                    '''            'NizR50(0, 0) = 5511
                    '''            'NizR50(0, 1) = "KELEBIA"
                    '''            Me.rtb57a.Items.Add("0050 ZFBIH")
                    '''            Me.rtb57b.Items.Add("500591")
                    '''            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            Me.rtb57c.Items.Add("1")
                    '''        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "44" Then
                    '''            Me.rtb57a.Items.Clear()
                    '''            Me.rtb57b.Items.Clear()
                    '''            Me.rtb57b2.Items.Clear()
                    '''            Me.rtb57c.Items.Clear()

                    '''            m_UicPrevozniPut = "44"
                    '''            Me.cmbPrevPut.Text = "44"
                    '''            Me.tb50.Text = "4491 BRASINA"
                    '''            'NizR50(0, 0) = 5511
                    '''            'NizR50(0, 1) = "KELEBIA"
                    '''            Me.rtb57a.Items.Add("0044 ZRS")
                    '''            Me.rtb57b.Items.Add("440591")
                    '''            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            Me.rtb57c.Items.Add("1")
                    '''        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "62" Then
                    '''            Me.rtb57a.Items.Clear()
                    '''            Me.rtb57b.Items.Clear()
                    '''            Me.rtb57b2.Items.Clear()
                    '''            Me.rtb57c.Items.Clear()

                    '''            m_UicPrevozniPut = "62"
                    '''            Me.cmbPrevPut.Text = "62"
                    '''            Me.tb50.Text = "6271 PRIJEPOLJE"
                    '''            'NizR50(0, 0) = 5511
                    '''            'NizR50(0, 1) = "KELEBIA"
                    '''            Me.rtb57a.Items.Add("0062 ZCG")
                    '''            Me.rtb57b.Items.Add("620671")
                    '''            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            Me.rtb57c.Items.Add("1")
                    '''        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "65" Then
                    '''            Me.rtb57a.Items.Clear()
                    '''            Me.rtb57b.Items.Clear()
                    '''            Me.rtb57b2.Items.Clear()
                    '''            Me.rtb57c.Items.Clear()

                    '''            m_UicPrevozniPut = "65"
                    '''            Me.cmbPrevPut.Text = "65"
                    '''            Me.tb50.Text = "6576 PRESEVO"
                    '''            'NizR50(0, 0) = 5511
                    '''            'NizR50(0, 1) = "KELEBIA"
                    '''            Me.rtb57a.Items.Add("0065 MZ")
                    '''            Me.rtb57b.Items.Add("650676")
                    '''            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            Me.rtb57c.Items.Add("1")
                    '''        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Then
                    '''            Me.rtb57a.Items.Clear()
                    '''            Me.rtb57b.Items.Clear()
                    '''            Me.rtb57b2.Items.Clear()
                    '''            Me.rtb57c.Items.Clear()

                    '''            m_UicPrevozniPut = "52"
                    '''            Me.cmbPrevPut.Text = "52"
                    '''            Me.tb50.Text = "5262 DIMITROVGRAD"
                    '''            'NizR50(0, 0) = 5511
                    '''            'NizR50(0, 1) = "KELEBIA"
                    '''            Me.rtb57a.Items.Add("0052 BDZ")
                    '''            Me.rtb57b.Items.Add("520620")
                    '''            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            Me.rtb57c.Items.Add("1")
                    '''        ElseIf GranicnaStanica = "N" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "52" Then
                    '''            Me.rtb57a.Items.Clear()
                    '''            Me.rtb57b.Items.Clear()
                    '''            Me.rtb57b2.Items.Clear()
                    '''            Me.rtb57c.Items.Clear()

                    '''            m_UicPrevozniPut = "53"
                    '''            Me.cmbPrevPut.Text = "53"
                    '''            Me.tb50.Text = "5361 VRSAC"
                    '''            'NizR50(0, 0) = 5511
                    '''            'NizR50(0, 1) = "KELEBIA"
                    '''            Me.rtb57a.Items.Add("2153 CFR")
                    '''            Me.rtb57b.Items.Add("530661")
                    '''            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text & Me.TextBox2.Text)
                    '''            Me.rtb57c.Items.Add("1")

                    '''        End If

                    '''    End If
                    '''    '---------------
                    '''End If
                End If
            End If

        End If

    End Sub
    Private Sub Daljinar()
        Dim sql_text As String

        '---------------------------------------------------------------------------
        If IzborSaobracaja = "1" Then
            mStanica1 = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
        ElseIf IzborSaobracaja = "2" Then
            mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5)
        ElseIf IzborSaobracaja = "3" Then
            mStanica1 = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
        ElseIf IzborSaobracaja = "4" Then
            mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
            mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
        End If


        'If mTarifa = "00" And (mVrstaObracuna = "CO" Or mVrstaObracuna = "IC") Then
        '    If mVrstaPrevoza <> "P" Then ' grupa ili voz => moze da pozove najavu
        '        'mStanica1 = cbSmer1.Text
        '        'mStanica2 = cbSmer2.Text
        '        mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
        '        mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
        '    Else
        '        mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
        '        mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
        '    End If
        'Else
        '    mStanica1 = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)
        '    mStanica2 = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
        'End If
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
                tbKm1.Text = rdrDalj.GetInt16(0)
                bTkm = tbKm1.Text
                sTkm = rdrDalj.GetInt16(1)
                tbA76.Text = tbKm1.Text
            Loop
            rdrDalj.Close()
            DbVeza.Close()
        Else
            tbKm1.Text = 0
            bTkm = 0
            sTkm = 0
            tbA76.Text = 0
        End If
    End Sub

    Private Sub tbBrojPr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbBrojPr.KeyPress
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

    Private Sub DateTimePicker2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.Leave
        Me.DateTimePicker2.BackColor = System.Drawing.Color.White
        If IzborSaobracaja = "3" Then
            Me.cmbPrevPut.Focus()
        Else
            If IzborSaobracaja = "2" Then
                Me.tb59a.Text = Me.DateTimePicker2.Value.Year.ToString + "-" + Me.DateTimePicker2.Value.Month.ToString + "-" + Me.DateTimePicker2.Value.Day.ToString
            End If
            Me.tbsBrojVoza.Focus()
        End If

    End Sub

    Private Sub FormCim_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnUnosRobe_Click(Me, Nothing)
        ElseIf e.KeyCode = Keys.F11 Then
            'Button4_Click(Me, Nothing)
        ElseIf e.KeyCode = Keys.F10 Then
            'Button7_Click(Me, Nothing)
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

    Private Sub tbsBrojVoza_KeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsBrojVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbsSatVoza_KeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbsSatVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub FormCim_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        If dtKola.Rows.Count = 1 Then
            tbIBK.Text = mIBK
            Me.tb25.Text = mSumaRobe
            Me.lblTaraValue.Text = mSumaTara.ToString
            Me.lblBrutoValue.Text = mSumaBruto.ToString


            Me.tb24.Text = mNHM
            Me.tbA72d.Text = mNHM

            Me.rtb21.Text = " 1 vagon - " & jci_NazivRobe
            rtb21.Text = rtb21.Text + Environment.NewLine

            Me.tbA74d1.Text = bRacunskaMasa 'mSumaRobe 'treba racunska
        ElseIf dtKola.Rows.Count > 1 Then
            tbIBK.Text = "Vidi spisak kola"
            Me.tb25.Text = mSumaRobe
            Me.lblTaraValue.Text = mSumaTara.ToString
            Me.lblBrutoValue.Text = mSumaBruto.ToString

            Me.tb24.Text = mNHM
            Me.tbA72d.Text = mNHM
            Me.rtb21.Text = dtKola.Rows.Count.ToString & " vagona - " & jci_NazivRobe
            rtb21.Text = rtb21.Text + Environment.NewLine
            'DODATI U R21: bruto, tara, neto

            Me.tbA74d1.Text = bRacunskaMasa 'mSumaRobe 'treba racunska
        End If
        combo73A.SelectedIndex = 0

        If dtKola.Rows.Count = 0 Then
            tbIBK.Text = ""
        End If

        If dtNaknade.Rows.Count = 1 Then
            tbA79a1.Text = mrA79a1
            tbA79b1.Text = mrA79b1
            tbA79a2.Text = ""
            tbA79b2.Text = ""
            tbA79a3.Text = ""
            tbA79b3.Text = ""
        ElseIf dtNaknade.Rows.Count = 2 Then
            tbA79a1.Text = mrA79a1
            tbA79b1.Text = mrA79b1
            tbA79a2.Text = mrA79a2
            tbA79b2.Text = mrA79b2
            tbA79a3.Text = ""
            tbA79b3.Text = ""
        ElseIf dtNaknade.Rows.Count >= 3 Then
            tbA79a1.Text = mrA79a1
            tbA79b1.Text = mrA79b1
            tbA79a2.Text = mrA79a2
            tbA79b2.Text = mrA79b2
            tbA79a3.Text = mrA79a3
            tbA79b3.Text = mrA79b3
        End If

        'If PrikazKalkulacije = "D" Then
        '    tbPrevoznina.Text = Format(mPrevoznina, "###,###,##0.00")
        'Else
        '    tbPrevoznina.Text = ""
        'End If

        If _OpenForm = "Roba" Then
            Me.tbKolauVozu.Text = CStr(dtKola.Rows.Count)
            'Me.tbKolauVozu.Text = "[ " & CStr(dtKola.Rows.Count) & " ]"
            If IzborSaobracaja = "3" And eCimDa = "D" Then
                If Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "1" Or Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "8" Or _
                                       Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "9" Then

                    Me.tb16c.Focus()
                Else
                    tbPrevoznina.Focus()

                    'btnUpis.Focus()
                End If
                '''Me.tb16c.Focus()
            Else
                If IzborSaobracaja = "2" Then
                    If Microsoft.VisualBasic.Mid(tb24.Text, 1, 4) = "9921" Or Microsoft.VisualBasic.Mid(tb24.Text, 1, 4) = "9922" Then
                        Me.btnUpis.Focus()
                    Else
                        Me.tbCarinjenje.Focus()
                    End If
                Else
                    Me.btnUpis.Focus()
                End If

            End If
        ElseIf _OpenForm = "Naknade" Then
        ElseIf _OpenForm = "IzvozUpd" Then
            Me.Text = " ::: USPESAN UPIS PODATAKA ! :::"
            ClearDoc()
            tbBrojOtp.Focus()
        ElseIf _OpenForm = "IzvozUpdErr" Then
            Me.Text = " ::: N E U S P E S A N   U P I S   U   B A Z U! :::"
            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()
            ClearDoc()
        ElseIf _OpenForm = "IzvozUpdNO" Then
            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()
            ClearDoc()
            tbBrojOtp.Focus()
        ElseIf _OpenForm = "Upis" Then
            Me.btnUpis.Focus()
        End If
        
        If CheckBox8.Checked Then
            mCarPost = "D"
        Else : mCarPost = "N"
        End If

    End Sub

    Private Sub Button16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        'Dim helpUic As New HelpForm
        'helpUic.Text = "UIC"
        'upit = "Posiljalac"
        'helpUic.ShowDialog()
        'Me.tb1a.Text = mIzlaz2
        'Me.tb1b.Text = mIzlaz4
        'Me.tb2.Text = CType(mIzlaz5, Integer)
    End Sub

    'Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarinarnica.Click
    '    Dim helpUic As New HelpForm
    '    helpUic.Text = "help carinarnice"
    '    upit = "CARINA"
    '    helpUic.ShowDialog()

    '    Me.tbCarinjenje.Text = mIzlaz1
    '    Me.lblCarinarnica.Text = mIzlaz2

    '    '''If IzborSaobracaja = "3" Then
    '    tb51a.Text = lblCarinarnica.Text
    '    tb51b.Text = "72"
    '    tb51c.Text = tbCarinjenje.Text

    '    '''End If

    'End Sub

    Private Sub cbFrankoPrevoznina_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbFrankoPrevoznina.MouseUp
        If Me.cbFrankoPrevoznina.Checked = True Then
            Me.comboIncoterms.Enabled = False
            Me.cbIncoterms.Checked = False
            Me.comboIncoterms.SelectedIndex = -1
            tb20a.Focus()
        Else
            Me.cbIncoterms.Checked = True
            Me.comboIncoterms.Enabled = True
            Me.comboIncoterms.Focus()
        End If

    End Sub

    Private Sub cbIncoterms_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbIncoterms.MouseUp
        If Me.cbIncoterms.Checked = True Then
            Me.comboIncoterms.Enabled = True
            Me.cbFrankoPrevoznina.Checked = False
            Me.comboIncoterms.Focus()
        Else
            Me.comboIncoterms.SelectedIndex = -1
            Me.comboIncoterms.Enabled = False
            Me.cbFrankoPrevoznina.Checked = True
            tb20a.Focus()
        End If

    End Sub

    Private Sub tb20a_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20a.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb20b_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20b.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb20c_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20c.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb20d_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20d.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb20e_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20e.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb20f_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb20f.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb16c_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb16c.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb16d_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb16d.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb16e_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb16e.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb20a_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb20a.Validating
        If tb20a.Text = Nothing Then

        Else
            Me.tb49b.Text = tb20a.Text
            Me.tb49a.Text = "11"
        End If

    End Sub

    Private Sub tb20b_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb20b.Validating
        Me.tb49c.Text = tb20b.Text
        Me.tb49a.Text = "11"
    End Sub

    Private Sub tb20a_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb20a.Leave
        If Len(tb20a.Text) = 0 Then
            Me.tb20f.Focus()
        End If
    End Sub

    Private Sub tb20b_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb20b.Leave
        If Len(tb20b.Text) = 0 Then
            Me.tb20f.Focus()
        End If

    End Sub

    Private Sub cbSmer1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer1.Leave
        Me.tbA70a1.Text = "72"
        Me.tbA70a2.Text = "72"

        ''Me.tbA70b1.Text = Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5)


    End Sub

    Private Sub cbSmer2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSmer2.Leave
        ''Me.tbA70b2.Text = Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5)
        If cbSmer2.Text = Nothing Then
            cbSmer2.Focus()

        Else
            If cbSmer2.Text = cbSmer1.Text Then
                cbSmer2.Focus()
            Else
                If IzborSaobracaja = "4" Then
                    If TipTranzita = "izlaz" Then
                        Me.tbUlaznaNalepnica.Focus()
                    Else
                        Me.tbUpravaOtp.Focus()
                    End If
                ElseIf IzborSaobracaja = "3" Then
                ElseIf IzborSaobracaja = "4" Then
                End If
            End If
        End If

    End Sub

    Private Sub tb20f_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb20f.Leave
        Me.btnCarinarnica.Focus()

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Dim GridNaknade As New naknade
        GridNaknade.ShowDialog()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim helpUic As New HelpForm
        upit = "R55"
        helpUic.ShowDialog()
        Me.rtb55.AppendText(mizlazObject)
        rtb55.Text = rtb55.Text + Environment.NewLine
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim helpUic As New HelpForm
        upit = "R7"
        helpUic.ShowDialog()
        Me.r7.Items.Add(mizlazObject)
        r7.Focus()

        'Me.rtb7.AppendText(mizlazObject)
        'rtb7.Text = rtb7.Text + Environment.NewLine


    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim helpUic As New HelpForm
        upit = "R56"
        helpUic.ShowDialog()
        Me.rtb56.AppendText(mizlazObject)
        rtb56.Text = rtb56.Text + Environment.NewLine
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

        '--- NOVO 17.3.2011 !!!
        'Dim aString As String = ""
        'Dim aString1 As String = ""
        'Dim ijk As Int16 = 0
        '--- end NOVO 17.3.2011 !!!


        cmbPrevPut.Items.Clear()
        dsPrevPut.Clear()

        If IzborSaobracaja = "2" Then
            upit = "SELECT * FROM UicPrevozniPutStavka WHERE (Uprava = '" & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & "')"
        Else
            '3.3.2011
            upit = "SELECT * FROM UicPrevozniPutStavka WHERE (Uprava = '" & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & "')"
            'upit = "SELECT * FROM UicPrevozniPutStavka WHERE (Uprava = '" & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & "')" & "ORDER BY SifraPP, Stavka DESC"

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
                        cmbPrevPut.Items.Add(combo_linija1)
                    Else
                        'combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
                        combo_linija1 = Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo

                        '3.3.2011: prikazuje puteve samo preko tog prelaza

                        If Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "1" Then
                            If Microsoft.VisualBasic.Right(combo_linija1, 2) = "55" Then
                                cmbPrevPut.Items.Add(combo_linija1)
                                'okrenuti smer!!
                            End If
                        ElseIf Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "8" Or Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "9" Then
                            If Microsoft.VisualBasic.Right(combo_linija1, 2) = "78" Then
                                cmbPrevPut.Items.Add(combo_linija1)  'DO SADA 17.3.2011

                                ''okrenuti smer!!
                                '''--------------- okrenuti smer zbog izvoza !!! NECE TREBATI nakon promene !!
                                'For ijk = (Len(combo_linija1) / 2) To 1 Step -1
                                '    aString = aString & Microsoft.VisualBasic.Mid(combo_linija1, 2 * ijk - 1, 2)
                                'Next

                                ''For ijk = 1 To (Len(combo_linija1) / 2)
                                ''    aString1 = aString1 & "  " & Microsoft.VisualBasic.Mid(aString, 2 * ijk - 1, 2)
                                ''Next

                                'm_UicPrevozniPut = Microsoft.VisualBasic.LTrim(aString)
                                '''----------------------------------------

                                'cmbPrevPut.Items.Add(m_UicPrevozniPut)

                            End If
                        End If


                    End If
                    'combo_linija1 = mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo
                    'cmbPrevPut.Items.Add(combo_linija1)
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
                        ''''''''''''''''''''''''combo_linija1 = Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo

                        '-----------novo
                        If Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "1" Then
                            If Microsoft.VisualBasic.Right(ZaCombo, 2) = "55" Then
                                combo_linija1 = Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
                                cmbPrevPut.Items.Add(combo_linija1)
                            End If
                        ElseIf Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "6" Then
                            If Microsoft.VisualBasic.Right(ZaCombo, 2) = "62" Then
                                combo_linija1 = Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
                                cmbPrevPut.Items.Add(combo_linija1)
                            End If
                        ElseIf Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "8" Or Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "9" Then
                            If Microsoft.VisualBasic.Right(ZaCombo, 2) = "78" Then
                                combo_linija1 = Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo
                                cmbPrevPut.Items.Add(combo_linija1)
                            End If
                        End If
                        '-----------end novo
                    End If
                    '''''''cmbPrevPut.Items.Add(combo_linija1)
                    SamoJedanPut = "Ne"
                End If
            Next

            If SamoJedanPut = "Da" Then
                If IzborSaobracaja = "2" Then
                    cmbPrevPut.Items.Add(mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2) & ZaCombo)
                Else
                    'cmbPrevPut.Items.Add(mSifraPrevPuta & " > " & Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo)
                    cmbPrevPut.Items.Add(Microsoft.VisualBasic.Left(tbStanicaPr.Text, 2) & ZaCombo)
                End If
            End If

        Catch ex As Exception
            MsgBox("Nama podataka za upravu " & Microsoft.VisualBasic.Left(tbStanicaOtp.Text, 2))
            Close()

        End Try

        OkpDbVeza.Close()

    End Sub
    Private Sub cmbPrevPut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.GotFocus
        Katarina()
        cmbPrevPut.DroppedDown = True
        ''''''''''Me.cbR57.Visible = True 3.3.2011

    End Sub

    Private Sub cmbPrevPut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPrevPut.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub cmbPrevPut_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbPrevPut.Validating
        Dim tmpUicPut As String = ""
        m_UicPrevozniPut = ""


        If ListBox1.Items.Count = 0 Then
            Me.tb50.Text = ""
            Me.rtb57a.Items.Clear()
            Me.rtb57b.Items.Clear()
            Me.rtb57b2.Items.Clear()
            Me.rtb57c.Items.Clear()

            Me.ListBox1.Items.Clear()
            Me.ListBox2.Items.Clear()
            Me.ListBox3.Items.Clear()
            Me.ListBox4.Items.Clear()
            str_R50 = ""

            tmpUicPut = cmbPrevPut.Text '17.3.2011 test - zemlje na PP treba da budu kao: 78 79 81 !!! a ne obratno

            For ii As Int16 = 1 To Len(tmpUicPut)
                If Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1) <> " " Then
                    m_UicPrevozniPut = m_UicPrevozniPut & Microsoft.VisualBasic.Mid(tmpUicPut, ii, 1)
                End If
            Next

            If IzborSaobracaja = "3" And eCimDa = "D" Then

                '--------------- okrenuti smer zbog izvoza !!! NECE TREBATI nakon promene !!
                Dim aString As String = ""
                Dim aString1 As String = ""
                Dim ijk As Int16 = 0
                Dim ctrlPrelaz As Boolean = False

                For ijk = (Len(m_UicPrevozniPut) / 2) To 1 Step -1
                    aString = aString & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, 2 * ijk - 1, 2)
                Next

                For ijk = 1 To (Len(m_UicPrevozniPut) / 2)
                    aString1 = aString1 & "  " & Microsoft.VisualBasic.Mid(aString, 2 * ijk - 1, 2)
                Next
                m_UicPrevozniPut = Microsoft.VisualBasic.LTrim(aString1)
                '----------------------------------------

                If Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "55" Then 'If Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "55" Then
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "1" Then
                        ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
                        'cmbPrevPut.Focus()
                    Else
                        ctrlPrelaz = True
                        ErrorProvider1.SetError(lblPP, "")
                    End If
                ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "53" Then
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "2" And Microsoft.VisualBasic.Left(cbSmer1.Text, 1) <> "3" Then
                        ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
                        'cmbPrevPut.Focus()
                    Else
                        ctrlPrelaz = True
                        ErrorProvider1.SetError(lblPP, "")
                    End If
                ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "52" Then
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "4" Then
                        ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
                        'cmbPrevPut.Focus()
                    Else
                        ctrlPrelaz = True
                        ErrorProvider1.SetError(lblPP, "")
                    End If
                ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "65" Then
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "5" Then
                        ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
                        'cmbPrevPut.Focus()
                    Else
                        ctrlPrelaz = True
                        ErrorProvider1.SetError(lblPP, "")
                    End If
                ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "62" Then
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "6" Then
                        ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
                        'cmbPrevPut.Focus()
                    Else
                        ctrlPrelaz = True
                        ErrorProvider1.SetError(lblPP, "")
                    End If
                ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "44" Then
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "7" Then
                        ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
                        'cmbPrevPut.Focus()
                    Else
                        ctrlPrelaz = True
                        ErrorProvider1.SetError(lblPP, "")
                    End If
                ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "50" Then
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "7" Then
                        ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
                        'cmbPrevPut.Focus()
                    Else
                        ctrlPrelaz = True
                        ErrorProvider1.SetError(lblPP, "")
                    End If
                ElseIf Microsoft.VisualBasic.Left(m_UicPrevozniPut, 2) = "78" Then
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) <> "8" And Microsoft.VisualBasic.Left(cbSmer2.Text, 2) <> "9" Then
                        ErrorProvider1.SetError(lblPP, "Prevozni put i granicni prelaz nisu saglasni!")
                        'cmbPrevPut.Focus()
                    Else
                        ctrlPrelaz = True
                        ErrorProvider1.SetError(lblPP, "")
                    End If
                End If


                If ctrlPrelaz = True Then
                    Dim x1 As Int16 = 0
                    x_UicPP = ""
                    For x1 = 1 To Len(m_UicPrevozniPut) Step 4
                        x_UicPP = x_UicPP & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, x1, 2)
                    Next

                    If Len(m_UicPrevozniPut) = 2 Then
                        Me.tbsBrojVoza.Focus()
                    Else
                        mPanelFocus = 1

                        Panel2.Location = New Point(15, 384)
                        Panel2.Width = 700
                        Panel2.Height = 360
                        'Panel2.Width = 560
                        'Panel2.Height = 309
                        Panel2.Visible = True
                        Panel2.Focus()

                    End If
                Else
                    cmbPrevPut.Focus()
                End If

            End If

        Else

        End If


    End Sub

    Private Sub cbSmer2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSmer2.Validating
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim asql_trz1 As String = "SELECT ZsPrelazi.SifraCarina, ZsCarinarnice.Naziv " _
                                & "FROM ZsPrelazi INNER JOIN " _
                                & "ZsCarinarnice ON ZsPrelazi.SifraCarina = ZsCarinarnice.Sifra " _
                                & "WHERE (dbo.ZsPrelazi.SifraPrelaza = '" & Microsoft.VisualBasic.Mid(cbSmer2.Text, 5, 5) & "') "

        Dim asql_commpr1 As New SqlClient.SqlCommand(asql_trz1, DbVeza)
        Dim ardrPrelaz1 As SqlClient.SqlDataReader

        Try
            ardrPrelaz1 = asql_commpr1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While ardrPrelaz1.Read()
                tbCarinjenje.Text = ardrPrelaz1.GetString(0)
                Me.lblCarinarnica.Text = ardrPrelaz1.GetString(1)
            Loop
            ardrPrelaz1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Catch exsql As SqlException
            MsgBox(exsql.ToString)
        End Try
        DbVeza.Close()
    End Sub

    Private Sub cbSmer1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSmer1.Validating
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim asql_trz1 As String = "SELECT ZsPrelazi.SifraCarina " _
                                & "FROM ZsPrelazi " _
                                & "WHERE (dbo.ZsPrelazi.SifraPrelaza = '" & Microsoft.VisualBasic.Mid(cbSmer1.Text, 5, 5) & "') "

        Dim asql_commpr1 As New SqlClient.SqlCommand(asql_trz1, DbVeza)
        Dim ardrPrelaz1 As SqlClient.SqlDataReader

        Try
            ardrPrelaz1 = asql_commpr1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While ardrPrelaz1.Read()
                Me.tbPolaznaCarina.Text = ardrPrelaz1.GetString(0)
            Loop
            ardrPrelaz1.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Catch exsql As SqlException
            MsgBox(exsql.ToString)
        End Try
        DbVeza.Close()

    End Sub

    Private Sub tbsSatVoza_Validating1(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbsSatVoza.Validating
        If GranicnaStanica = "D" Then
            If CType(Me.tbsSatVoza.Text, Int32) > 24 Then
                Me.tbsSatVoza.Focus()
            End If
        Else

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
        Me.dgError.Visible = False

        '------------- Akcija ----------------
        If mm = "Izlazni granicni prelaz" Then
            cbSmer2.Focus()
        ElseIf mm = "Ulazna tranzitna nalepnica" Then
            Me.tbUlaznaNalepnica.Focus()
        ElseIf mm = "Izlazna tranzitna nalepnica" Then
            Me.tbIzlaznaNalepnica.Focus()
        ElseIf mm = "Tarifski kilometri" Then
            Me.tbA76.Focus()
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
        ElseIf mm = "Odredisna carinarnica" Then
            Me.tbCarinjenje.Focus()
        ElseIf mm = "Preuzimanje na prevoz" Then
            Me.tbCarinjenje.Focus()
        ElseIf mm = "Posiljalac" Then
            Me.tb1a.Focus()
        ElseIf mm = "Primalac" Then
            Me.tb4a.Focus()
        ElseIf mm = "Unos robe" Then
            Dim GridKola As New kola
            GridKola.Show()
        End If
        '-------------------------------------
    End Sub

    Private Sub btnUpravaOtp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpravaOtp.Click
        Me.tbStanicaOtp.Clear()
        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UPR1"
        helpUic.ShowDialog()
        Me.tbUpravaOtp.Text = mIzlaz1
        Label11.Text = mIzlaz2
        tbStanicaOtp.Focus()
    End Sub

    Private Sub btnStanicaOtp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStanicaOtp.Click
        helpUprava = Microsoft.VisualBasic.Mid(tbUpravaOtp.Text, 3, 2)
        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UIC"
        helpUic.ShowDialog()
        Me.tbStanicaOtp.Text = mIzlaz1
        Label12.Text = mIzlaz2
        tbStanicaPr.Focus()
    End Sub

    Private Sub btnUpravaPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpravaPr.Click
        Me.tbStanicaPr.Clear()
        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UPR1"
        helpUic.ShowDialog()

        ErrorProvider1.SetError(TextBox1, "")
        Me.tbUpravaPr.Text = mIzlaz1
        Label14.Text = RTrim(mIzlaz2)
        Me.tbStanicaPr.Text = CStr(mIzlaz3)
        helpUprava = CStr(mIzlaz3)

        tbStanicaPr.Focus()
    End Sub

    Private Sub btnStanicaPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStanicaPr.Click
        helpUprava = Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2)
        'helpUprava = Microsoft.VisualBasic.Mid(tbUpravaPr.Text, 3, 2)
        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UIC"
        helpUic.ShowDialog()

        ErrorProvider1.SetError(TextBox2, "")
        Me.tbStanicaPr.Text = mIzlaz1
        Label13.Text = mIzlaz2
        Me.TextBox2.Text = mIzlaz3
        Me.DateTimePicker2.Focus()
    End Sub


    Private Sub cmbPrevPut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.Click
        Katarina()
    End Sub
    Private Sub InitNizUic()

        NizUic(0, 0) = "0010"
        NizUic(0, 1) = "VR         "
        NizUic(1, 0) = "2120"
        NizUic(1, 1) = "RZD        "
        NizUic(2, 0) = "0021"
        NizUic(2, 1) = "BC         "
        NizUic(3, 0) = "0022"
        NizUic(3, 1) = "UZ         "
        NizUic(4, 0) = "0023"
        NizUic(4, 1) = "CFM        "
        NizUic(5, 0) = "0024"
        NizUic(5, 1) = "LG         "
        NizUic(6, 0) = "0025"
        NizUic(6, 1) = "LDZ        "
        NizUic(7, 0) = "0026"
        NizUic(7, 1) = "EVR        "
        NizUic(8, 0) = "0027"
        NizUic(8, 1) = "KTZ        "
        NizUic(9, 0) = "0028"
        NizUic(9, 1) = "GR         "
        NizUic(10, 0) = "0029"
        NizUic(10, 1) = "UTI        "
        NizUic(11, 0) = "0041"
        NizUic(11, 1) = "HSH        "
        NizUic(12, 0) = "0044"
        NizUic(12, 1) = "ZRS        "
        NizUic(13, 0) = "0050"
        NizUic(13, 1) = "ZFBH       "
        NizUic(14, 0) = "2151"
        NizUic(14, 1) = "PKP CARGO  "
        NizUic(15, 0) = "2152"
        NizUic(15, 1) = "BDZ-F      "
        NizUic(16, 0) = "2153"
        NizUic(16, 1) = "CFR Marfa  "
        NizUic(17, 0) = "2154"
        NizUic(17, 1) = "CD Cargo   "
        NizUic(18, 0) = "2155"
        NizUic(18, 1) = "RCH        "
        NizUic(19, 0) = "2156"
        NizUic(19, 1) = "ZSSK Cargo "
        NizUic(20, 0) = "0057"
        NizUic(20, 1) = "AZ         "
        NizUic(21, 0) = "0058"
        NizUic(21, 1) = "ARM        "
        NizUic(22, 0) = "0059"
        NizUic(22, 1) = "KRG        "
        NizUic(23, 0) = "0060"
        NizUic(23, 1) = "CIE        "
        NizUic(24, 0) = "2162"
        NizUic(24, 1) = "ZCG        "
        NizUic(25, 0) = "0065"
        NizUic(25, 1) = "CFARYM     "
        NizUic(26, 0) = "0066"
        NizUic(26, 1) = "TDZ        "
        NizUic(27, 0) = "0067"
        NizUic(27, 1) = "TRK        "
        NizUic(28, 0) = "0068"
        NizUic(28, 1) = "AAE        "
        NizUic(29, 0) = "2370"
        NizUic(29, 1) = "UK-F       "
        NizUic(30, 0) = "1071"
        NizUic(30, 1) = "Renfe      "
        NizUic(31, 0) = "0072"
        NizUic(31, 1) = "ZS         "
        NizUic(32, 0) = "0073"
        NizUic(32, 1) = "OSE        "
        NizUic(33, 0) = "2174"
        NizUic(33, 1) = "Green Cargo"
        NizUic(34, 0) = "0075"
        NizUic(34, 1) = "TCDD       "
        NizUic(35, 0) = "2176"
        NizUic(35, 1) = "CargoNET AS"
        NizUic(36, 0) = "2178"
        NizUic(36, 1) = "HZ Cargo   "
        NizUic(37, 0) = "2179"
        NizUic(37, 1) = "SZ         "
        NizUic(38, 0) = "2180"
        NizUic(38, 1) = "DBSDE      "
        NizUic(39, 0) = "2181"
        NizUic(39, 1) = "RCA        "
        NizUic(40, 0) = "2182"
        NizUic(40, 1) = "ELC        "
        NizUic(41, 0) = "0083"
        NizUic(41, 1) = "FS         "
        NizUic(42, 0) = "2184"
        NizUic(42, 1) = "DBSNL      "
        NizUic(43, 0) = "2185"
        NizUic(43, 1) = "SBB Cargo  "
        NizUic(44, 0) = "2186"
        NizUic(44, 1) = "DBSSC      "
        NizUic(45, 0) = "2187"
        NizUic(45, 1) = "SNCF-Fret  "
        NizUic(46, 0) = "2188"
        NizUic(46, 1) = "SNCB Logist"
        NizUic(47, 0) = "0090"
        NizUic(47, 1) = "ENR        "
        NizUic(48, 0) = "0091"
        NizUic(48, 1) = "SNCFT      "
        NizUic(49, 0) = "0092"
        NizUic(49, 1) = "SNTF       "
        NizUic(50, 0) = "0093"
        NizUic(50, 1) = "ONCFM      "
        NizUic(51, 0) = "2194"
        NizUic(51, 1) = "CP Cargo   "
        NizUic(52, 0) = "0095"
        NizUic(52, 1) = "IR         "
        NizUic(53, 0) = "0096"
        NizUic(53, 1) = "RAI        "
        NizUic(54, 0) = "0097"
        NizUic(54, 1) = "CFS        "
        NizUic(55, 0) = "0098"
        NizUic(55, 1) = "CEL        "
        NizUic(56, 0) = "0099"
        NizUic(56, 1) = "IRR        "

    End Sub
    Private Sub PopuniR57a()

        Dim ki, kj As Int16
        Dim i_Pronasao As Int16 = 0
        'Dim mUprava123 As String = "81"
        Dim mNizUic As String

        Me.rtb57a.Items.Clear()
        Me.rtb57c.Items.Clear()

        InitNizUic()

        mNizUic = m_UicPrevozniPut
        mNizUic = Microsoft.VisualBasic.Trim(mNizUic)

        For kj = 1 To Len(mNizUic) Step 4
            For ki = 0 To 56
                If Microsoft.VisualBasic.Right(NizUic(ki, 0), 2) = Microsoft.VisualBasic.Mid(mNizUic, kj, 2) Then
                    i_Pronasao = 1
                    Me.rtb57a.Items.Add(NizUic(ki, 0) & " - " & NizUic(ki, 1))
                    Me.rtb57c.Items.Add("1")

                    Exit For
                End If
            Next
        Next
    End Sub
    Private Sub PopuniR57_x()

        Dim ki, kj As Int16
        Dim i_Pronasao As Int16 = 0
        'Dim mUprava123 As String = "81"
        Dim mNizUic As String

        Me.rtb57a.Items.Clear()
        Me.rtb57c.Items.Clear()

        InitNizUic()

        mNizUic = m_UicPrevozniPut
        mNizUic = Microsoft.VisualBasic.Trim(mNizUic)

        For kj = 1 To Len(mNizUic) Step 4
            For ki = 0 To 56
                If Microsoft.VisualBasic.Right(NizUic(ki, 0), 2) = Microsoft.VisualBasic.Mid(mNizUic, kj, 2) Then
                    i_Pronasao = 1
                    Me.rtb57a.Items.Add(NizUic(ki, 0) & " - " & NizUic(ki, 1))
                    Me.rtb57c.Items.Add("1")

                    Exit For
                End If
            Next
        Next

        'Hrvatska
        nmHzAdd = False
        If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "1" Or Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "8" Then
            Dim tmpHZ As String = ""
            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "8" Then
                tmpHZ = "780501"
            ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "9" Then
                tmpHZ = "780502"
            End If

            If mNizUic = "78  79" Then
                Me.rtb57b.Items.Add(tmpHZ)
                Me.rtb57b2.Items.Add("780550")
                Me.rtb57b.Items.Add("790550")
                Me.rtb57b2.Items.Add(mPrStanica)
                nmHzAdd = True
            ElseIf mNizUic = "78  79  83" Then
                Me.rtb57b.Items.Add(tmpHZ)
                Me.rtb57b2.Items.Add("780550")
                Me.rtb57b.Items.Add("790550")
                Me.rtb57b2.Items.Add("790310")
                Me.rtb57b.Items.Add("830310")
                Me.rtb57b2.Items.Add(mPrStanica)
                nmHzAdd = True
            ElseIf mNizUic = "78  79  81" Then
                Me.rtb57b.Items.Add(tmpHZ)
                Me.rtb57b2.Items.Add("780550")
                Me.rtb57b.Items.Add("790550")
                Me.rtb57b2.Items.Add("790440")
                Me.rtb57b.Items.Add("810440")
                Me.rtb57b2.Items.Add(mPrStanica)
                nmHzAdd = True
            ElseIf mNizUic = "78  50" Then
                Me.rtb57b.Items.Add(tmpHZ)
                Me.rtb57b2.Items.Add("780524")
                Me.rtb57b.Items.Add("500524")
                Me.rtb57b2.Items.Add(mPrStanica)
                nmHzAdd = True
            ElseIf mNizUic = "78  44" Then
                Me.rtb57b.Items.Add(tmpHZ)
                Me.rtb57b2.Items.Add("780524")
                Me.rtb57b.Items.Add("440524")
                Me.rtb57b2.Items.Add(mPrStanica)
                nmHzAdd = True
            End If
        End If

    End Sub


    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim helpUic As New HelpForm
        upit = "R9"
        helpUic.ShowDialog()
        Me.r9.Items.Add(mizlazObject)
        Me.r9.Focus()

        'Me.rtb9.AppendText(mizlazObject)
        'rtb9.Text = rtb9.Text + Environment.NewLine
        'rtb9.Focus()

    End Sub
    Private Sub tbBrojPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojPr.Leave
        Me.tbBrojPr.BackColor = System.Drawing.Color.White
        Me.tbBrojPr.ForeColor = System.Drawing.Color.Black
        Me.tb59b.Text = Me.tbBrojPr.Text
    End Sub

    Private Sub tb49h_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb49h.Validating
        If Me.tb49h.Text <> Nothing Then
            Me.tb49a.Text = "14"
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.tb20f.Clear()
        Dim helpUic As New HelpForm
        helpUic.Text = "help UIC"
        upit = "UICPREL"
        helpUic.ShowDialog()
        Me.tb20f.Text = mIzlaz1 & " " & mIzlaz2
        Me.btnUpis.Focus()

    End Sub

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        If GranicnaStanica = "D" Then
            If IzborSaobracaja = "3" Then
                Me.tbStanicaOtp.Focus()
                Me.tbStanicaOtp.SelectionStart = 3
            ElseIf IzborSaobracaja = "4" Then
                Me.cbSmer2.Focus()
            ElseIf IzborSaobracaja = "2" Then
                Me.tbUpravaOtp.Focus()
            End If
        Else
            If IzborSaobracaja = "3" Then
                Me.cbSmer2.Focus()
            ElseIf IzborSaobracaja = "2" Then
                Me.cbSmer1.Focus()
            End If
        End If

    End Sub

    Private Sub tb20f_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb20f.Validating
        Me.tb49h.Text = Microsoft.VisualBasic.Left(tb20f.Text, 4)
        Me.tb49a.Text = "14"
    End Sub

    Private Sub btnUpis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpis.Click

        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Button11_Click(Me, Nothing) 'kontrola

        If ErrKontrola = "OK" Then
            _OpenForm = "Upis"
            mCarStanica = Me.tbCarinjenje.Text
            mCarStanicaStart = Me.tbPolaznaCarina.Text

            eInit_NewCim89()

            If IzborSaobracaja = "4" Then
                UpisTranzita()
                Cursor.Current = System.Windows.Forms.Cursors.Default

                If TipTranzita = "ulaz" Then
                    Me.ComboBox1.Focus()
                Else
                    Close()
                End If
            Else
                UpisExIm()
                Cursor.Current = System.Windows.Forms.Cursors.Default

                Me.ComboBox1.Focus()
            End If
        Else
            Cursor.Current = System.Windows.Forms.Cursors.Default
            dgError.Focus()
        End If

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        nmAllowExit = True
        dtKola.Clear()
        dtNhm.Clear()
        dtNaknade.Clear()

        eInit_NewCim89()

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

        Close()

    End Sub
    Private Sub UpisTranzita()

        Dim slogTrans As SqlTransaction
        Dim rv As String
        Dim drKola As DataRow
        Dim drNhm As DataRow
        Dim drDencane As DataRow
        Dim drNaknade As DataRow
        Dim mopRecID As Int32 = 0
        Dim mUkljucujuci As String = ""
        Dim mDoPrelaza As String = ""
        Dim mValUrIsp, mValPouz, mValVR As String
        Dim mPos1, mPos2, mPri1, mPri2 As Int32

        If TipTranzita = "ulaz" Then
            mUlEtiketa = CType(tbUlaznaNalepnica.Text, Int32)
            If RecordAction = "N" Then
                mIzEtiketa = CType(tbIzlaznaNalepnica.Text, Int32)
            Else
                mIzEtiketa = 0
            End If
        Else
            mUlEtiketa = CType(tbUlaznaNalepnica.Text, Int32)
            mIzEtiketa = CType(tbIzlaznaNalepnica.Text, Int32)
        End If

        mPrikazKalkulacije = "N"

        '-------------------- Izjava -----------------------
        mSifraIzjave = 0
        If cbFrankoPrevoznina.Checked Then
            mSifraIzjave = 1
            mUkljucujuci = RTrim(tb20a.Text & tb20b.Text & tb20c.Text)
            mDoPrelaza = Microsoft.VisualBasic.Left(Me.tb20f.Text, 4)
        End If
        If cbIncoterms.Checked Then
            mSifraIzjave = 2
        End If

        '-- Kontrola pre upisa
        If Me.cbVal26.Text = Nothing Then
            mValVR = ""
        Else
            mValVR = Me.cbVal26.Text
        End If
        If Me.cbVal27.Text = Nothing Then
            mValUrIsp = ""
        Else
            mValUrIsp = Me.cbVal27.Text
        End If
        If Me.cbVal28.Text = Nothing Then
            mValPouz = ""
        Else
            mValPouz = Me.cbVal28.Text
        End If

        If Me.tb2.Text = Nothing Then
            mPri1 = 0
        Else
            mPri1 = Me.tb2.Text
        End If
        If Me.tb3.Text = Nothing Then
            mPri2 = 0
        Else
            mPri2 = Me.tb3.Text
        End If
        If Me.tb5.Text = Nothing Then
            mPos1 = 0
        Else
            mPos1 = Me.tb5.Text
        End If
        If Me.tb6.Text = Nothing Then
            mPos2 = 0
        Else
            mPos2 = Me.tb5.Text
        End If

        If kbBrojPr.Text = Nothing Then
            kbBrojPr.Text = 0
        End If

        Dim strOtpBroj As String = CType(tbBrojOtp.Text, String) & CType(kbBrojOtp.Text, String)
        Dim strPrBroj As String = CType(tbBrojPr.Text, String) & CType(kbBrojPr.Text, String)

        '---------------------------------- Pristupa bazi -----------------------------------
        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If
            slogTrans = DbVeza.BeginTransaction()

            ' -- 1. Upis u SlogKalk ---------------------------------------------
            If MasterAction = "New" Then
                mAkcija = "New"
            Else
                mAkcija = "Upd"
            End If

            ' upis na prvim kolima kompletenog voza !!! 
            If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "01" Then
                If mVrstaObracuna = "CO" Then
                    If mTabelaCena = "210" Or mTabelaCena = "211" Then
                        If CType(tbKolauVozu.Text, Int16) > 1 Then
                            mPrevoznina = 0    'prevoznina se upisuje samo na prvim kolima
                        End If
                    End If
                End If
            End If
            If mBrojUg = "9933553" Or mBrojUg = "993354" Then
                If CType(tbKolauVozu.Text, Int16) > 1 Then
                    mPrevoznina = 0    'prevoznina se upisuje samo na prvim kolima
                End If
            End If

            Upis.UpisSlogKalk(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
                    tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, mObrGodina, mObrMesec, mStanica1, mUlEtiketa, _
                    Today(), mStanica2, mIzEtiketa, Today(), tbUpravaPr.Text, tbStanicaPr.Text, _
                    CType(strPrBroj, Int32), DateTimePicker2.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, mNajava, CType(mNajavaKola, Integer), _
                    mTarifa, mBrojUg, mPos1, mPos2, mPri1, mPri2, bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, _
                    mVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bTkm, sTkm, mSifraIzjave, mFrRacun, mUkljucujuci, _
                    mDoPrelaza, Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), mValUrIsp, CType(Me.tb27.Text, Decimal), _
                    mValPouz, CType(Me.tb28.Text, Decimal), mValVR, CType(Me.tb26.Text, Decimal), _
                    bValuta, (mPrevoznina + mSumaNak), 0, mPrevoznina, 0, mSumaNak, 0, mUserID, Today(), _
                    mCarStanica, mCarStanicaStart, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
                    mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, _
                    mopRecID, rv)
            Upis.UpisSlogKalkPlus(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mCarPost, _
                                                "", "", "", "", 0, 0, 0, "", "", 0, Today(), rv)

            If rv <> "" Then Throw New Exception(rv)
            '-- End Upis u SlogKalk -----------------------------------------

            '-- 2. Upis u SlogKola ---------------------------------------------  
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

                        Upis.UpisSlogKola(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, rbKola, _
                                     drKola("IndBrojKola"), drKola("KB"), drKola("Uprava"), drKola("Vlasnik"), drKola("Serija"), _
                                     drKola("Osovine"), drKola("Tara"), drKola("GrTov"), drKola("Stitna"), drKola("Tip"), drKola("Prevoznina"), _
                                     drKola("Naknada"), drKola("ICF"), rv)
                        '-- 2.1. Upis u SlogRoba ---------------------------------------------  
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

                                Upis.UpisSlogRobaDec(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
                                                    rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("MasaDec"), drNhm("Masa"), drNhm("RID"), drNhm("UTI"), _
                                                    drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), drNhm("UTINHM"), _
                                                    drNhm("UTIBuletin"), drNhm("UTIPlombe"), rv)

                                rbRoba = rbRoba + 1
                            End If
                        Next
                        '-- End Upis u SlogRoba -----------------------------------------  
                        rbKola = rbKola + 1
                        rbRoba = 1
                    Next
                End If
                '-- End Upis u SlogRoba -----------------------------------------  
                If rv <> "" Then Throw New Exception(rv)
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
                                tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
                                rbDencane, drDencane("SMasa"), drDencane("RMasa"), _
                                drDencane("Tarifa"), drDencane("Tip"), drDencane("Komada"), _
                                drDencane("Iznos"), drDencane("Valuta"), rv)

                    rbDencane = rbDencane + 1
                Next
                If rv <> "" Then Throw New Exception(rv)
            End If
            '-- 3. Upis u SlogNaknada ------------------------------------------
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

                    Upis.UpisSlogNaknada(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
                          rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
                         drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

                    rbNaknade = rbNaknade + 1
                Next
            End If
            '-- End Upis u SlogNaknada --------------------------------------

            If rv = "" Then
                slogTrans.Commit()
                Me.Text = " ::: Uspesan upis! :::"
            Else
                MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                slogTrans.Rollback()
            End If
            '-- Zavrsetak upisa u Slog*

            '-- Azuriranje tranzitnih nalepnica ----------------------------------------
            'If TipTranzita = "ulaz" Then

            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If
            slogTrans = DbVeza.BeginTransaction()

            Try
                Dim ulTrzNalepnica As Int32
                Dim izTrzNalepnica As Int32
                Dim _Stanica As String

                rv = ""

                mAkcija = "Upd"

                If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = mStanica1 Then 'ulaz
                    ulTrzNalepnica = mUlEtiketa
                    izTrzNalepnica = mIzEtiketa
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = mStanica2 Then 'izlaz
                    izTrzNalepnica = mIzEtiketa
                    ulTrzNalepnica = mUlEtiketa
                End If

                If TipTranzita = "ulaz" Then
                    Upis.UpisTrzNalepnice(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), ulTrzNalepnica, 0, rv)
                Else
                    Upis.UpisTrzNalepnice(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), 0, izTrzNalepnica, rv)
                End If

                If rv = "" Then
                    slogTrans.Commit()
                    '-------------------------------------------------
                    ' Upisati podatke u NajavaNCTS + NajavaNCTS1
                    '
                    '-------------------------------------------------
                Else
                    MsgBox(rv)
                    slogTrans.Rollback()
                End If
            Catch ex As Exception
                rv = ex.Message
                MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch sqlex As SqlException
                MsgBox(sqlex.Message)
            Finally
                DbVeza.Close()
            End Try
            'End If
            '-- END azuriranje tranzitnih nalepnica --------------------------------

            '-- Ovde dolazi deo za podnosenje eJCI, sada iskljuceno
            '-- End

            '-- Priprema za sledeci unos ------------------------------------------------------------------

            'mUlEtiketa = 0
            'mIzEtiketa = 0

            Me.tbStanicaOtp.BackColor = System.Drawing.Color.White
            Me.tbStanicaPr.BackColor = System.Drawing.Color.White

            '-- Zbog upisivanja prevoznine
            If Microsoft.VisualBasic.Right(Me.tbUgovor.Text, 2) = "01" Or Me.tbUgovor.Text = "993353" Or Me.tbUgovor.Text = "993354" Then
                If tmpUgovor = Me.tbUgovor.Text Or CType(tbKolauVozu.Text, Int16) = 1 Then
                    'vazno: prethodni upis u bazu za vozove-prevoznina samo na prvim kolima voza!!
                    tbKolauVozu.Text = CType(tbKolauVozu.Text, Int16) + 1
                    'Me.ComboBox1.Focus()
                End If
            End If

            If TipTranzita = "ulaz" Then
                Me.tbUlaznaNalepnica.Text = CType(Me.tbUlaznaNalepnica.Text, Int32) + 1
            Else
                Me.tbIzlaznaNalepnica.Text = CType(Me.tbIzlaznaNalepnica.Text, Int32) + 1
            End If

            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()
            ClearDoc()

            tmpUgovor = Me.tbUgovor.Text
            Me.ComboBox1.Focus()
        Catch ex As Exception
            rv = ex.Message
            MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch sqlex As SqlException
            MsgBox(sqlex.Message)
        Finally
            DbVeza.Close()
        End Try

    End Sub
    Private Sub UpisExIm()
        Dim slogTrans As SqlTransaction
        Dim rv As String = ""
        Dim drKola As DataRow
        Dim drNhm As DataRow
        Dim drDencane As DataRow
        Dim drNaknade As DataRow
        Dim mopRecID As Int32 = 0
        Dim mUkljucujuci As String = ""
        Dim mDoPrelaza As String = ""
        Dim mValUrIsp, mValPouz, mValVR As String
        Dim mPos1, mPos2, mPri1, mPri2 As Int32
        Dim _prazanString As String = " "

        mPrikazKalkulacije = "N"
        mIzEtiketa = 0
        mUlEtiketa = 0
        If Me.tbBrojPr.Text = Nothing Then
            mPrispece = 0
        Else
            mPrispece = CType(tbBrojPr.Text, Int32)
        End If

        '-------------------- Izjava -----------------------
        mSifraIzjave = 0
        If cbFrankoPrevoznina.Checked Then
            mSifraIzjave = 1
            mUkljucujuci = RTrim(tb20a.Text & tb20b.Text & tb20c.Text)
            mDoPrelaza = Microsoft.VisualBasic.Left(Me.tb20f.Text, 4)
        End If
        If cbIncoterms.Checked Then
            mSifraIzjave = 2
        End If

        If mTarifa = "36" Then
            mBrojUg = ""
        End If

        '-- Kontrola pre upisa
        If Me.cbVal26.Text = Nothing Then
            mValVR = ""
        Else
            mValVR = Me.cbVal26.Text
        End If
        If Me.cbVal27.Text = Nothing Then
            mValUrIsp = ""
        Else
            mValUrIsp = Me.cbVal27.Text
        End If
        If Me.cbVal28.Text = Nothing Then
            mValPouz = ""
        Else
            mValPouz = Me.cbVal28.Text
        End If

        If Me.tb2.Text = Nothing Then
            mPri1 = 0
        Else
            mPri1 = Me.tb2.Text
        End If
        If Me.tb3.Text = Nothing Then
            mPri2 = 0
        Else
            mPri2 = Me.tb3.Text
        End If
        If Me.tb5.Text = Nothing Then
            mPos1 = 0
        Else
            mPos1 = Me.tb5.Text
        End If
        If Me.tb6.Text = Nothing Then
            mPos2 = 0
        Else
            mPos2 = Me.tb5.Text
        End If

        If kbBrojPr.Text = Nothing Then
            kbBrojPr.Text = 0
        End If

        Dim strOtpBroj As String = CType(tbBrojOtp.Text, String) & CType(kbBrojOtp.Text, String)
        Dim strPrBroj As String = CType(tbBrojPr.Text, String) & CType(kbBrojPr.Text, String)

        '------------------------- pristupa bazi -----------------------------------------------------
        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If
            slogTrans = DbVeza.BeginTransaction()

            '--------------------------------------- Upis u SlogKalk ---------------------------------------------
            If MasterAction = "New" Then
                mAkcija = "New"
            Else
                mAkcija = "Upd"
            End If
            If mRanzirna = "R" Then 'ako preuzme iz ranžirne 
                mAkcija = "Upd"
            End If
            '----------------------------------- upis na prvim kolima kompletenog voza !!! --------------------
            If Microsoft.VisualBasic.Mid(mBrojUg, 5, 2) = "01" Then
                If mVrstaObracuna = "CO" Then
                    If mTabelaCena = "210" Or mTabelaCena = "211" Then
                        If CType(tbKolauVozu.Text, Int16) > 1 Then
                            mPrevoznina = 0    'prevoznina se upisuje samo na prvim kolima
                        End If
                    End If
                End If
            End If
            '--------------------------------------------------------------------------------------------------
            If IzborSaobracaja = 2 Then
                Upis.UpisSlogKalk2New(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
                                      tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, mObrGodina, mObrMesec, mStanica1, mUlEtiketa, _
                                      Today(), _prazanString, mIzEtiketa, Today(), tbUpravaPr.Text, tbStanicaPr.Text, mRBB, _
                                      CType(strPrBroj, Int32), DateTimePicker2.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, mNajava, 0, _
                                      mTarifa, mBrojUg, mPos1, mPos2, mPri1, mPri2, bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, _
                                      mVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bTkm, sTkm, mSifraIzjave, mFrRacun, mUkljucujuci, _
                                      mDoPrelaza, Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), mValUrIsp, CType(Me.tb27.Text, Decimal), _
                                      mValPouz, CType(Me.tb28.Text, Decimal), mValVR, CType(Me.tb26.Text, Decimal), _
                                      bValuta, (mPrevoznina + mSumaNak), 0, mDinaraPoTL, mPrevoznina, 0, mSumaNak, 0, mUserID, Today(), _
                                      mCarStanica, mCarStanicaStart, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
                                      mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, mopRecID, rv)
                Upis.UpisSlogKalkPlus(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mCarPost, _
                                     "", "", "", "", 0, 0, 0, "", "", 0, Today(), rv)
            ElseIf IzborSaobracaja = 3 Then
                Upis.UpisSlogKalkIzvozSt2New(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
                                           tbStanicaOtp.Text, mRBB, CType(strOtpBroj, Int32), DatumOtp.Text, mObrGodina, mObrMesec, "0", mUlEtiketa, _
                                           Today(), mStanica2, mIzEtiketa, Me.DateTimePicker2.Text, tbUpravaPr.Text, tbStanicaPr.Text, _
                                           CType(strPrBroj, Int32), DateTimePicker2.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, mNajava, 0, _
                                           mTarifa, mBrojUg, mPos1, mPos2, mPri1, mPri2, bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, _
                                           mVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bTkm, sTkm, mSifraIzjave, mFrRacun, mUkljucujuci, _
                                           mDoPrelaza, Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), mValUrIsp, CType(Me.tb27.Text, Decimal), _
                                           mValPouz, CType(Me.tb28.Text, Decimal), mValVR, CType(Me.tb26.Text, Decimal), _
                                           bValuta, (mPrevoznina + mSumaNak), 0, mDinaraPoTL, mPrevoznina, 0, mSumaNak, 0, mUserID, Today(), _
                                           mCarStanica, mCarStanicaStart, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
                                           mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, mopRecID, rv)
                Upis.UpisSlogKalkPlus(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), mCarPost, _
                                       "", "", "", "", 0, 0, 0, "", "", 0, Today(), rv)
                'Upis.UpisSlogKalkIzvozSt2New(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
                '                             tbStanicaOtp.Text, mRBB, CType(strOtpBroj, Int32), DatumOtp.Text, mObrGodina, mObrMesec, "0", mUlEtiketa, _
                '                              Today(), mStanica2, mIzEtiketa, Today(), tbUpravaPr.Text, tbStanicaPr.Text, _
                '                             CType(strPrBroj, Int32), DateTimePicker2.Text, CType(Me.tbsBrojVoza.Text, Int32), tbsSatVoza.Text, mNajava, 0, _
                '                             mTarifa, mBrojUg, mPos1, mPos2, mPri1, mPri2, bVrstaPosiljke, mVrstaPrevoza, IzborSaobracaja, _
                '                             mVrstaSaobracaja, mVrPrevoza, dtKola.Rows.Count, bTkm, sTkm, mSifraIzjave, mFrRacun, mUkljucujuci, _
                '                             mDoPrelaza, Microsoft.VisualBasic.Mid(Me.comboIncoterms.Text, 1, 3), mValUrIsp, CType(Me.tb27.Text, Decimal), _
                '                             mValPouz, CType(Me.tb28.Text, Decimal), mValVR, CType(Me.tb26.Text, Decimal), _
                '                             bValuta, (mPrevoznina + mSumaNak), 0, mDinaraPoTL, mPrevoznina, 0, mSumaNak, 0, mUserID, Today(), _
                '                             mCarStanica, mCarStanicaStart, mCarPrPIB, mCarPrNaziv, mCarPrSediste, mCarPrZemlja, mCarValuta, mCarFaktura, mCarBrDoc, mCarDoc, _
                '                             mCarKnjiga, Today(), CarinskiAgent, mCarXML, mServer, mopRecID, rv)
            End If


            If rv <> "" Then Throw New Exception(rv)
            '-- End Upis u SlogKalk -----------------------------------------

            '-- 2. Upis u SlogKola -------------------------------------------  
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
                        If mRanzirna = "R" Then
                            mAkcija = "Upd"
                        End If

                        Upis.UpisSlogKola(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
                                          tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, rbKola, _
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
                                If mRanzirna = "R" Then
                                    mAkcija = "Upd"
                                End If

                                Upis.UpisSlogRobaDec(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                                     tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
                                                     rbKola, rbRoba, drNhm("NHM"), drNhm("R"), drNhm("MasaDec"), drNhm("Masa"), _
                                                     drNhm("RID"), drNhm("UTI"), drNhm("UTIIB"), drNhm("UTITara"), drNhm("UTIRaster"), _
                                                     drNhm("UTINHM"), drNhm("UTIBuletin"), drNhm("UTIPlombe"), rv)

                                rbRoba = rbRoba + 1
                            End If
                        Next
                        '-- End Upis u SlogRoba -----------------------------------------  
                        rbKola = rbKola + 1
                        rbRoba = 1
                    Next
                End If
                If rv <> "" Then Throw New Exception(rv)
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
                                         tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
                                         rbDencane, drDencane("SMasa"), drDencane("RMasa"), drDencane("Tarifa"), drDencane("Tip"), _
                                         drDencane("Komada"), drDencane("Iznos"), drDencane("Valuta"), rv)

                    rbDencane = rbDencane + 1
                Next
                If rv <> "" Then Throw New Exception(rv)
            End If

            '-- 3 minus. Upis u SlogGP ------------------------------------------
            If IzborSaobracaja = "3" And eCimDa = "D" Then
                Dim rbGP As Int16 = 1
                Dim kj As Int32 = 1
                Dim _string1 As String = ""
                Dim _string2 As String = ""
                Dim _string3 As String = ""
                'Dim aaa1 As Int16 = rtb57a.Items.Count - 1 '3-1
                Dim aaa1 As Int16 = ListBox1.Items.Count - 1

                If aaa1 <= 0 Then
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "1" Then
                        _string1 = "7211"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "2" Then
                        _string1 = "7260"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "3" Then
                        _string1 = "7261"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "4" Then
                        _string1 = "7220"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "5" Then
                        _string1 = "7276"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "6" Then
                        _string1 = "7271"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "7" Then
                        _string1 = "7291"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "8" Then
                        _string1 = "7201"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "9" Then
                        _string1 = "7202"
                    End If
                    _string2 = tbUpravaOtp.Text
                    _string3 = tbUpravaPr.Text

                    Upis.UpisSlogGP(slogTrans, "New", mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                    1, _string2, _string3, _string1, rv)

                    If rv <> "" Then Throw New Exception(rv)
                Else
                    If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "1" Then
                        _string1 = "7211"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "2" Then
                        _string1 = "7260"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "3" Then
                        _string1 = "7261"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "4" Then
                        _string1 = "7220"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "5" Then
                        _string1 = "7276"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "6" Then
                        _string1 = "7271"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "7" Then
                        _string1 = "7291"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "8" Then
                        _string1 = "7201"
                    ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "9" Then
                        _string1 = "7202"
                    End If
                    _string2 = tbUpravaOtp.Text
                    _string3 = Microsoft.VisualBasic.Left(rtb57a.Items(0), 4)

                    Upis.UpisSlogGP(slogTrans, "New", mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                    1, _string2, _string3, _string1, rv)
                    If rv <> "" Then Throw New Exception(rv)

                    For rbGP = 0 To aaa1
                        If rbGP < aaa1 Then
                            _string1 = Microsoft.VisualBasic.Left(rtb57b2.Items(rbGP), 2) & Microsoft.VisualBasic.Right(rtb57b2.Items(rbGP), 2) '_string1 = NizR50(rbGP + 1, 0)
                            '_string1 = Microsoft.VisualBasic.Left(rtb57b.Items(rbGP), 2) & Microsoft.VisualBasic.Right(rtb57b.Items(rbGP), 2) '_string1 = NizR50(rbGP + 1, 0)
                            _string2 = Microsoft.VisualBasic.Left(rtb57a.Items(rbGP), 4)
                            _string3 = Microsoft.VisualBasic.Left(rtb57a.Items(rbGP + 1), 4)

                            Upis.UpisSlogGP(slogTrans, "New", mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), _
                                            rbGP + 2, _string2, _string3, _string1, rv)

                            If rv <> "" Then Throw New Exception(rv)
                        End If
                    Next
                End If

            End If

            '-- 3. Upis u SlogNaknada ------------------------------------------
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

                    Upis.UpisSlogNaknada(slogTrans, mAkcija, mopRecID, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), tbUpravaOtp.Text, _
                                         tbStanicaOtp.Text, CType(strOtpBroj, Int32), DatumOtp.Text, _
                                         rbNaknade, drNaknade("Sifra"), drNaknade("IvicniBroj"), drNaknade("Iznos"), drNaknade("Valuta"), _
                                         drNaknade("Kolicina"), drNaknade("DanCas"), drNaknade("Placanje"), drNaknade("Obracun"), rv)

                    rbNaknade = rbNaknade + 1
                Next
            End If
            '-- End Upis u SlogNaknada --------------------------------------

            If rv = "" Then
                slogTrans.Commit()

                Me.Text = " ::: USPESAN UPIS PODATAKA ! :::"


                '*********************************** formiranje XML-a za razmenu ****************************************************
                If IzborSaobracaja = "3" And eCimDa = "D" And mAkcija = "New" Then 'mAkcija # "New" => ne salje xml!!               

                    ''==========================================================
                    ''Dim mOrfeus As String = "8874818085878382868455"
                    'Dim mKorak As Int16 = 1
                    'Dim strOrfeus As String
                    'Dim mKorakDo As Int16 = Len(eRD) - 1
                    'SendOrfeus = "N"
                    'For mKorak = 1 To mKorakDo Step 2
                    '    strOrfeus = Microsoft.VisualBasic.Mid(eRD, mKorak, 2)
                    '    If InStr(m_UicPrevozniPut, strOrfeus) = 0 Then
                    '        SendOrfeus = "N"
                    '    Else
                    '        SendOrfeus = "D"
                    '        Exit For
                    '    End If
                    'Next
                    ''==========================================================

                    'samo za RD Orfeus members i HZ Cargo i RCH 
                    'novo, 2014: sve prelo RCH i HZC

                    '------------------------------------------------------------------------------------------------------
                    If (mStanica2 = "23499" Or mStanica2 = "16517" Or mStanica2 = "25471") Then 'And SendOrfeus = "D" Then
                        KreirajFbXml()
                    End If
                    '------------------------------------------------------------------------------------------------------

                End If
                '********************************************************************************************************************

            Else
                MessageBox.Show(rv, "Poruka iz baze - greska kod upisa 1", MessageBoxButtons.OK, MessageBoxIcon.Error)
                slogTrans.Rollback()
            End If
            '-- Zavrsetak upisa u Slog*

            'bilo eJCI
            'end

            '-- 2. Obrisati prethodni unos sem broja voza --------------------------------------------------------
            mUlEtiketa = 0
            mIzEtiketa = 0

            If Microsoft.VisualBasic.Left(Me.ComboBox2.Text, 1) = "3" Then
                If tmpUgovor = Me.tbUgovor.Text Then
                    'vazno: prethodni upis u bazu za vozove-prevoznina samo na prvim kolima voza!!
                    tbKolauVozu.Text = CType(tbKolauVozu.Text, Int16) + 1
                Else
                    tbKolauVozu.Text = 1
                End If
            Else
                tbKolauVozu.Text = 1
            End If
            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()
            ClearDoc()

            tmpUgovor = Me.tbUgovor.Text
            Me.ComboBox1.Focus()
        Catch ex As Exception
            rv = ex.Message
            MessageBox.Show(rv, "Greska u pristupu bazi - greska kod upisa 2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Me.Text = " ::: N E U S P E S A N   U P I S   U   B A Z U! :::"

            dtKola.Clear()
            dtNhm.Clear()
            dtNaknade.Clear()
            ClearDoc()

        Catch sqlex As SqlException
            MsgBox(sqlex.Message)
        Finally
            DbVeza.Close()
        End Try

    End Sub

    Private Sub tbUgovor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.Leave
        mUgovorZaUporedjenje = Me.tbUgovor.Text

    End Sub
    Private Sub ClearDoc()

        tbKolauVozu.Text = "1"
        'tbUgovor.Text = ""
        'Me.ComboBox1.SelectedIndex = -1
        'Me.ComboBox2.SelectedIndex = -1

        Me.tbBrojOtp.Text = ""
        Me.kbBrojOtp.Text = ""

        If IzborSaobracaja = "3" Then

        Else
            Me.tb1a.Text = ""
            Me.tb1b.Text = ""
            Me.tb1b1.Text = ""
            Me.tb1b2.Text = ""
            Me.tb4a.Text = ""
            Me.tb4b.Text = ""
            Me.tb4b1.Text = ""
            Me.tb4b2.Text = ""
            Me.tb10b.Text = ""
            Me.tb13.Text = ""
            Me.tb14a.Text = ""
            Me.tb14b.Text = ""
            Me.tb15.Text = ""
            Me.tb16a.Text = ""
            Me.tb16b.Text = ""
            Me.tbCarinjenje.Text = ""
            Me.lblCarinarnica.Text = ""

        End If

        'Me.tbPolaznaCarina.Text = ""

        Me.r7.Items.Clear()
        Me.r9.Items.Clear()
        Me.tb10a.Text = ""
        Me.r13.Items.Clear()

        'Me.rtb57a.Items.Clear()
        'Me.rtb57b.Items.Clear()
        'Me.rtb57b2.Items.Clear()
        'Me.rtb57c.Items.Clear()
        'Me.tb50.Text = ""
        'Me.ListBox1.Items.Clear()
        'Me.ListBox2.Items.Clear()
        'Me.ListBox3.Items.Clear()
        'Me.ListBox4.Items.Clear()


        Me.rtb9.Text = ""
        Me.tb12.Text = ""
        Me.tb17.Text = ""
        Me.rtb21.Text = ""
        Me.tb51a.Text = ""
        Me.tb51b.Text = ""
        Me.tb51c.Text = ""
        Me.rtb55.Text = ""
        Me.tb29a.Text = ""
        Me.tb29b.Text = ""

        Me.tb52a.Text = ""
        Me.tb52b.Text = ""
        Me.tb52c.Text = ""
        Me.tb52d.Text = ""
        Me.tb52e.Text = ""

        'Me.TB58a1.Text = ""
        'Me.TB58a2.Text = ""
        Me.tb59a.Text = ""
        Me.tb59b.Text = ""
        Me.tbIBK.Text = ""
        Me.tb24.Text = ""
        Me.tb25.Text = ""

        Me.tbA70a1.Text = ""
        Me.tbA70b1.Text = ""
        Me.tbA70a2.Text = ""
        Me.tbA70b2.Text = ""
        Me.tbA72d.Text = ""
        Me.combo73A.SelectedIndex = 0
        Me.tbA74d1.Text = ""
        Me.tbA75.Text = ""
        Me.tbA76.Text = ""
        Me.tbA77.Text = ""
        Me.tbA78.Text = ""

        Me.tbA79a1.Text = ""
        Me.tbA79b1.Text = ""
        Me.tbA79a2.Text = ""
        Me.tbA79b2.Text = ""
        Me.tbA79a3.Text = ""
        Me.tbA79b3.Text = ""


        Me.tbCarinjenje.Text = ""

        ''''Me.NizR50.Clear(NizR50, NizR50.GetLowerBound(0), NizR50.Length)




    End Sub
    Private Sub KreirajFbXml()

        Dim Doc As New XmlDocument
        Dim newAtt As XmlAttribute
        Dim TempNode As XmlElement
        Dim fb_godina As String = Today.Year().ToString

        '----------------------- date/time ------------------------
        Dim tempMonth As String = Today.Now.Month
        If Len(tempMonth) = 1 Then
            tempMonth = "0" & tempMonth
        End If
        Dim tempDay As String = Today.Now.Day
        If Len(tempDay) = 1 Then
            tempDay = "0" & tempDay
        End If
        Dim tempYear As String = Today.Now.Year
        Dim tempHour As String = Today.Now.Hour
        If Len(tempHour) = 1 Then
            tempHour = "0" & tempHour
        End If
        Dim tempMinute As String = Today.Now.Minute
        If Len(tempMinute) = 1 Then
            tempMinute = "0" & tempMinute
        End If
        Dim tempSeconds As String = Today.Now.Second
        If Len(tempSeconds) = 1 Then
            tempSeconds = "0" & tempSeconds
        End If
        '---------------------------------------------------------

        Dim RcaFbStr1_1 As String = "0072" '"ZS"
        Dim RcaFbStr1_2 As String '= "0_EVUH_0072_" ' bilo "" bilo 0  bilo "0_ZS_"

        Dim RcaFbStr1_2_1 As String '= Me.tbUpravaOtp.Text & "_"
        Dim RcaFbStr1_2_2 As String '= Today.Now.Year & Today.Now.Month & Today.Now.Day & "_"
        Dim RcaFbStr1_2_3 As String '= "" 'Today.Now.Hour & Today.Now.Minute & "_"  '& "_EVU_WLV_OUT_" iskljuceno zbog MAVC
        Dim RcaFbStr1_2_4 As String '= Me.tbStanicaOtp.Text & "_" & Me.tbBrojOtp.Text.ToString & Me.kbBrojOtp.Text.ToString ' & ".xml"

        'RcaFbStr1_2 = RcaFbStr1_2 & RcaFbStr1_2_1 & RcaFbStr1_2_2 & RcaFbStr1_2_3 & RcaFbStr1_2_4
        'novo zbog RCA
        RcaFbStr1_2 = "0_EVUH_0072_"
        RcaFbStr1_2_2 = Today.Now.Year & Today.Now.Month & Today.Now.Day & "_"
        RcaFbStr1_2_3 = Microsoft.VisualBasic.Right("0" & Today.Now.Hour.ToString, 2) & Microsoft.VisualBasic.Right("0" & Today.Now.Minute.ToString, 2) & "_EVUH_WLV_IN_"

        'If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5) Then
        '    RcaFbStr1_2_3 = "0_EVUH_WLV_IN_"
        'Else
        '    RcaFbStr1_2_3 = "1_EVUH_WLV_IN_"
        'End If
        RcaFbStr1_2_4 = Me.tbBrojOtp.Text.ToString & Me.kbBrojOtp.Text.ToString

        RcaFbStr1_2 = RcaFbStr1_2 & RcaFbStr1_2_2 & RcaFbStr1_2_3 & RcaFbStr1_2_4
        RcaFbStr1_2 = RcaFbStr1_2 & ".xml"
        'end novo zbog RCA

        '-------------------------------------------------------------------------------------------------------------------
        'If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5) Then
        '    RcaFbStr1_2 = RcaFbStr1_2 & "_0" & ".xml"
        'Else
        '    RcaFbStr1_2 = RcaFbStr1_2 & "_1" & ".xml"
        'End If
        '-------------------------------------------------------------------------------------------------------------------
        SourceFile = RcaFbStr1_2

        Dim RcaFbStr1_3 As String = "fb0413"
        Dim RcaFbStr1_4 As String = "fb0413.xsd"

        Dim RcaFbStr2_1 As String = "O" 'O=osnovni dokument, U=update
        Dim RcaFbStr2_2 As String = Today.Now.Year & Today.Now.Month & Today.Now.Day & Today.Now.Hour & Today.Now.Minute & Today.Now.Second & Today.Now.Millisecond


        'Ispravka!!! treba da bude: time="01.12.2008 13:31:33" ok
        Dim RcaFbStr2_3 As String = tempDay & "." & tempMonth & "." & tempYear & " " & tempHour & ":" & tempMinute & ":" & tempSeconds

        Dim RcaFbStr3_1a As String = "CIM"
        Dim RcaFbStr3_1b As String = "0"
        Dim RcaFbStr3_1c As String = "1"

        Dim RcaFbStr3_2a As String = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2) '"72" -otpravljanje
        Dim RcaFbStr3_2b As String = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5) & Me.TextBox1.Text  '"234500"
        Dim RcaFbStr3_2c As String = RTrim(Me.tb16a.Text) ' "SUBOTICA"
        Dim RcaFbStr3_2d As String = Me.tbUpravaOtp.Text '"0072"
        Dim RcaFbStr3_2e As Int32 = Me.tbBrojOtp.Text & Me.kbBrojOtp.Text '524322

        Dim RcaFbStr3_3a As String = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2) ' "72" preuzimanje na prevoz
        Dim RcaFbStr3_3b As String = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5) & Me.TextBox1.Text ' "234500"
        Dim RcaFbStr3_3c As String = RTrim(Me.tb16a.Text)
        Dim RcaFbStr3_3d As String = Me.tbUpravaOtp.Text '"0072"

        Dim RcaFbStr3_3e As String
        If Len(Me.tb16d.Text) < 2 Then
            Me.tb16d.Text = "0" & Me.tb16d.Text
        End If
        If Len(Me.tb16c.Text) < 2 Then
            Me.tb16c.Text = "0" & Me.tb16c.Text
        End If
        If Len(Me.tb16e.Text) < 2 Then
            Me.tb16e.Text = "0" & Me.tb16e.Text
        End If

        RcaFbStr3_3e = Me.tb16d.Text & "." & _
                       Me.tb16c.Text & "." & _
                       fb_godina & " " & _
                       Me.tb16e.Text
        'dan-mesec-godina-cas "11.04.2008 00"  '[ P16. PREUZIMANJE NA PREVOZ ]

        Dim RcaFbStr3_4a As String = Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) '"81"
        Dim RcaFbStr3_4b As String = Microsoft.VisualBasic.Right(Me.tbStanicaPr.Text, 5) & Me.TextBox2.Text '"037143"
        Dim RcaFbStr3_4c As String = RTrim(Me.tb10a.Text) '"FRANTSCHACH-ST.GERTR"

        Dim RcaFbStr3_6a As String = "absender"
        Dim RcaFbStr3_6b As Int32 = Me.tb2.Text '100078
        Dim RcaFbStr3_6c As String = RTrim(Me.tb1a.Text) 'naziv
        Dim RcaFbStr3_6d As String = RTrim(Me.tb1b.Text) 'adresa
        Dim RcaFbStr3_6e As String = " " 'postcode ne do daljnjeg
        Dim RcaFbStr3_6f As String = RTrim(Me.tb1b1.Text) 'grad
        Dim RcaFbStr3_6g As String = Me.tb1b2.Text 'zemlja

        Dim RcaFbStr3_7a As String = "empfaenger"
        Dim RcaFbStr3_7b As Int32 = Me.tb2.Text '100078
        Dim RcaFbStr3_7c As String = RTrim(Me.tb4a.Text) 'naziv
        Dim RcaFbStr3_7d As String = RTrim(Me.tb4b.Text) 'adresa
        Dim RcaFbStr3_7e As String = " " 'postcode ne do daljnjeg
        Dim RcaFbStr3_7f As String = RTrim(Me.tb4b1.Text) 'grad
        Dim RcaFbStr3_7g As String = Me.tb4b2.Text 'zemlja

        Dim RcaFbStr3_13b As String = Me.tb14b.Text '"000036"
        Dim RcaFbStr4_8a As String = Me.tb24.Text '"992200" ' [ NHM ]
        Dim RcaFbStr4_8b As String = RTrim(jci_NazivRobe) '"KOLA KORISN.PREVOZA VISEOSOVNA,PRAZNA" ' [ NHM NAZIV ]

        'trazi broj granicnih prelaza
        For i As Integer = 0 To 9
            For j As Integer = 0 To 1
                If NizR50(i, j) = Nothing Then
                    NumNizR50 = i
                    Exit For
                End If
            Next
            If NumNizR50 > 0 Then
                Exit For
            End If
        Next

        Dim RcaFbStr58a1 As String = Me.TB58a1.Text ' [ Ugovorni prevoznik - sifra ]
        Dim RcaFbStr58a2 As String = Me.TB58a2.Text ' [ Ugovorni prevoznik - naziv ]

        '+========================================================= 1. frachtbriefe ===============================================================
        Dim dec As XmlDeclaration = Doc.CreateXmlDeclaration("1.0", "ISO-8859-1", "yes")
        Doc.AppendChild(dec)

        Dim DocRoot As XmlElement = Doc.CreateElement("frachtbriefe")
        newAtt = Doc.CreateAttribute("absender")
        newAtt.Value = RcaFbStr1_1
        DocRoot.Attributes.Append(newAtt)

        newAtt = Doc.CreateAttribute("original_filename")
        newAtt.Value = RcaFbStr1_2
        DocRoot.Attributes.Append(newAtt)

        newAtt = Doc.CreateAttribute("version_xsd")
        newAtt.Value = RcaFbStr1_3
        DocRoot.Attributes.Append(newAtt)

        newAtt = Doc.CreateAttribute("xsi:noNamespaceSchemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
        newAtt.Value = RcaFbStr1_4
        DocRoot.SetAttributeNode(newAtt)

        Doc.AppendChild(DocRoot)

        '+========================================================= 2. frachtbrief ===============================================================
        Dim frachtbrief As XmlNode = Doc.CreateElement("frachtbrief")
        newAtt = Doc.CreateAttribute("osu_kennzeichen")
        newAtt.Value = RcaFbStr2_1
        frachtbrief.Attributes.Append(newAtt)

        newAtt = Doc.CreateAttribute("referenznummer")
        newAtt.Value = RcaFbStr2_2
        frachtbrief.Attributes.Append(newAtt)

        newAtt = Doc.CreateAttribute("time")
        newAtt.Value = RcaFbStr2_3
        frachtbrief.Attributes.Append(newAtt)

        DocRoot.AppendChild(frachtbrief)

        '========================================================= 3. sendungskopf ===============================================================
        Dim sendungskopf As XmlNode = Doc.CreateElement("sendungskopf")
        frachtbrief.AppendChild(sendungskopf)

        '+- 3_1a. sendungsart
        Dim sendungsart As XmlNode = Doc.CreateElement("sendungsart")
        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = RcaFbStr3_1a
        sendungsart.Attributes.Append(newAtt)

        sendungskopf.AppendChild(sendungsart)

        '+- 3_1b. retourfrachtbrief
        Dim retourfrachtbrief As XmlNode = Doc.CreateElement("retourfrachtbrief")

        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = RcaFbStr3_1b
        retourfrachtbrief.Attributes.Append(newAtt)

        sendungskopf.AppendChild(retourfrachtbrief)

        '+- 3_1c. originalfrachtbrief
        Dim originalfrachtbrief As XmlNode = Doc.CreateElement("originalfrachtbrief")
        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = RcaFbStr3_1c
        originalfrachtbrief.Attributes.Append(newAtt)

        sendungskopf.AppendChild(originalfrachtbrief)

        '+----------------- 3_2. versandbhf [ P82. OTPRAVLJANJE ]
        Dim versandbhf As XmlNode = Doc.CreateElement("versandbhf")
        sendungskopf.AppendChild(versandbhf)

        '+------- 3_2a. vw
        Dim vw As XmlNode = Doc.CreateElement("vw")
        vw.InnerText = RcaFbStr3_2a
        versandbhf.AppendChild(vw)

        '+------- 3_2b. bhfnr
        Dim bhfnr As XmlNode = Doc.CreateElement("bhfnr")
        bhfnr.InnerText = RcaFbStr3_2b
        versandbhf.AppendChild(bhfnr)

        '+------- 3_2c. bhfnr
        Dim bhfname As XmlNode = Doc.CreateElement("bhfname")
        bhfname.InnerText = RcaFbStr3_2c
        versandbhf.AppendChild(bhfname)

        '+------- 3_2d. evu
        Dim evu As XmlNode = Doc.CreateElement("evu")
        evu.InnerText = RcaFbStr3_2d
        versandbhf.AppendChild(evu)

        '+------- 3_2e. versandnr
        Dim versandnr As XmlNode = Doc.CreateElement("versandnr")
        'versandnr.InnerText = RcaFbStr3_2e.ToString

        'izmenjeno zbog RCH:
        versandnr.InnerText = RcaFbStr3_2e.ToString.PadLeft(6, "0"c)
        versandbhf.AppendChild(versandnr)

        '+----------------- 3_3. uebernahmestelle [P16. PREUZIMANJE NA PREVOZ]
        Dim uebernahmestelle As XmlNode = Doc.CreateElement("uebernahmestelle")
        sendungskopf.AppendChild(uebernahmestelle)

        '+------- 3_3a. vw
        vw = Doc.CreateElement("vw")
        vw.InnerText = RcaFbStr3_3a
        uebernahmestelle.AppendChild(vw)

        '+------- 3_3b. bhfnr
        bhfnr = Doc.CreateElement("bhfnr")
        bhfnr.InnerText = RcaFbStr3_3b
        uebernahmestelle.AppendChild(bhfnr)

        '+------- 3_3c. bhfnr
        bhfname = Doc.CreateElement("bhfname")
        bhfname.InnerText = RcaFbStr3_3c
        uebernahmestelle.AppendChild(bhfname)

        '+------- 3_3d. evu
        evu = Doc.CreateElement("uebernahmeort_name")
        evu.InnerText = RcaFbStr3_3c
        uebernahmestelle.AppendChild(evu)

        '+------- 3_3e. versandnr
        versandnr = Doc.CreateElement("uebernahmezeitpunkt")
        versandnr.InnerText = RcaFbStr3_3e
        uebernahmestelle.AppendChild(versandnr)

        '+----------------- 3_4. empfangsbhf [P12. UPUTNA STANICA]
        Dim empfangsbhf As XmlNode = Doc.CreateElement("empfangsbhf")
        sendungskopf.AppendChild(empfangsbhf)

        '+------- 3_4a. vw
        vw = Doc.CreateElement("vw")
        vw.InnerText = RcaFbStr3_4a
        empfangsbhf.AppendChild(vw)

        '+------- 3_4b. bhfnr
        bhfnr = Doc.CreateElement("bhfnr")
        bhfnr.InnerText = RcaFbStr3_4b
        empfangsbhf.AppendChild(bhfnr)

        '+------- 3_4c. bhfnr
        bhfname = Doc.CreateElement("bhfname")
        bhfname.InnerText = RcaFbStr3_4c
        empfangsbhf.AppendChild(bhfname)

        '+----------------- 3_5. ablieferungsstelle [P10. Mesto izdavanja]
        Dim ablieferungsstelle As XmlNode = Doc.CreateElement("ablieferungsstelle")
        sendungskopf.AppendChild(ablieferungsstelle)

        '+------- 3_5a. vw
        vw = Doc.CreateElement("vw")
        vw.InnerText = RcaFbStr3_4a
        ablieferungsstelle.AppendChild(vw)

        '+------- 3_5b. bhfnr
        bhfnr = Doc.CreateElement("bhfnr")
        bhfnr.InnerText = RcaFbStr3_4b
        ablieferungsstelle.AppendChild(bhfnr)

        '+------- 3_5c. bhfnr
        bhfname = Doc.CreateElement("bhfname")
        bhfname.InnerText = RcaFbStr3_4c
        ablieferungsstelle.AppendChild(bhfname)

        '+------- 3_5d. evu : OPTIONAL
        ''evu = Doc.CreateElement("bhfrpc")
        ''evu.InnerText = "001" 'RcaFbStr3_3d
        ''ablieferungsstelle.AppendChild(evu)

        '+------- 3_5e. versandnr
        versandnr = Doc.CreateElement("ablieferungsort_name")
        versandnr.InnerText = RcaFbStr3_4c
        ablieferungsstelle.AppendChild(versandnr)

        '----------------- 3_6. kunde [P1. POSILJALAC]
        Dim kunde As XmlNode = Doc.CreateElement("kunde")
        sendungskopf.AppendChild(kunde)

        '+------ 3_6a. beteiligungsart
        Dim beteiligungsart As XmlNode = Doc.CreateElement("beteiligungsart")
        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = "absender"
        beteiligungsart.Attributes.Append(newAtt)
        kunde.AppendChild(beteiligungsart)

        '+------- 3_6b. kundennr
        Dim kundennr As XmlNode = Doc.CreateElement("kundennr")
        If RcaFbStr3_6b > 0 Then ' ------------------------------------- proveriti za numeric type!!!
            kundennr.InnerText = RcaFbStr3_6b.ToString
            kunde.AppendChild(kundennr)
        End If

        '+------- 3_6c. name
        Dim name As XmlNode = Doc.CreateElement("name")
        If Len(Trim(RcaFbStr3_6c)) > 0 Then
            name.InnerText = RcaFbStr3_6c
            kunde.AppendChild(name)
        End If

        '+------- 3_6d. strasse 
        Dim strasse As XmlNode = Doc.CreateElement("strasse")
        If Len(Trim(RcaFbStr3_6d)) > 0 Then
            strasse.InnerText = RcaFbStr3_6d
            kunde.AppendChild(strasse)
        End If

        '+------- 3_6e. plz 'iskljucen postanski broj
        'Dim plz As XmlNode = Doc.CreateElement("plz")
        'plz.InnerText = RcaFbStr3_6e
        'kunde.AppendChild(plz)

        '+------- 3_6f. plz
        Dim ort As XmlNode = Doc.CreateElement("ort")
        If Len(Trim(RcaFbStr3_6f)) > 0 Then
            ort.InnerText = RcaFbStr3_6f
            kunde.AppendChild(ort)
        End If

        '+------- 3_6g. land
        Dim land As XmlNode = Doc.CreateElement("land")
        If Len(Trim(RcaFbStr3_6g)) > 0 Then
            land.InnerText = RcaFbStr3_6g
            kunde.AppendChild(land)
        End If

        '+----------------- 3_7. kunde [P4. PRIMALAC]
        kunde = Doc.CreateElement("kunde")
        sendungskopf.AppendChild(kunde)

        '+------- 3_7a. beteiligungsart
        beteiligungsart = Doc.CreateElement("beteiligungsart")
        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = "empfaenger"
        beteiligungsart.Attributes.Append(newAtt)
        kunde.AppendChild(beteiligungsart)

        If RcaFbStr3_7b > 0 Then 'numeric ????????????????????
            '------- 3_7b. kundennr
            kundennr = Doc.CreateElement("kundennr")
            kundennr.InnerText = RcaFbStr3_7b.ToString
            kunde.AppendChild(kundennr)
        End If

        '------- 3_7c. name
        name = Doc.CreateElement("name")
        If Len(Trim(RcaFbStr3_7c)) > 0 Then
            name.InnerText = RcaFbStr3_7c
            kunde.AppendChild(name)
        End If


        '''------- 3_7c2. name2 ISKLJUCENO DO DALJNJEG
        ''Dim name2 As XmlNode = Doc.CreateElement("name2")
        ''name2.InnerText = RcaFbStr3_7c
        ''kunde.AppendChild(name2)

        If Len(Trim(RcaFbStr3_7d)) > 0 Then
            '------- 3_7d. strasse
            strasse = Doc.CreateElement("strasse")
            strasse.InnerText = RcaFbStr3_7d
            kunde.AppendChild(strasse)
        End If

        '''------- 3_7e. plz ISKLJUCENO DO DALJNJEG
        ''plz = Doc.CreateElement("plz")
        ''plz.InnerText = RcaFbStr3_7e
        ''kunde.AppendChild(plz)

        If Len(Trim(RcaFbStr3_7f)) > 0 Then
            '------- 3_7f. ort
            ort = Doc.CreateElement("ort")
            ort.InnerText = RcaFbStr3_7f
            kunde.AppendChild(ort)
        End If

        If Len(Trim(RcaFbStr3_7g)) > 0 Then
            '------- 3_7g. land
            land = Doc.CreateElement("land")
            land.InnerText = RcaFbStr3_7g
            kunde.AppendChild(land)
        End If

        '+----------------- 3_8. ausstellungsort [P29. MESTO ISPOSTAVLJANJA]
        Dim ausstellungsort As XmlNode = Doc.CreateElement("ausstellungsort")
        ausstellungsort.InnerText = RTrim(Me.tb29a.Text) '"SUBOTICA"
        sendungskopf.AppendChild(ausstellungsort)

        '+----------------- 3_9. ausstellungdatum [P29. DATUM ISPOSTAVLJANJA]
        Dim ausstellungsdatum As XmlNode = Doc.CreateElement("ausstellungsdatum")

        If Len(Me.tb29b_1.Text) = 1 Then
            Me.tb29b_1.Text = "0" & Me.tb29b_1.Text
        End If
        If Len(Me.tb29b_2.Text) = 1 Then
            Me.tb29b_2.Text = "0" & Me.tb29b_2.Text
        End If
        ausstellungsdatum.InnerText = Me.tb29b_1.Text & Me.tb29b_2.Text & Me.tb29b_3.Text '"11.04.2008"
        sendungskopf.AppendChild(ausstellungsdatum)

        '+----------------- 3_10. frankaturcode [P20. IZJAVA O PLACANJU ]
        Dim frankaturcode As XmlNode = Doc.CreateElement("frankaturcode")
        sendungskopf.AppendChild(frankaturcode)

        '+------- 3_10a. frankaturcode_id
        Dim frankaturcode_id As XmlNode = Doc.CreateElement("frankaturcode_id")
        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = Me.tb49a.Text '"16"
        frankaturcode_id.Attributes.Append(newAtt)
        frankaturcode.AppendChild(frankaturcode_id)

        '+------- 3_10b. frankaturcode_id
        ' 16 = ako je franko do prelaza


        ' ok* ----------------- 3_11. erklaerungen [P7. IZJAVA POSILJAOCA ] PROVERITI DUZINU ZBOG VISE REDOVA
        If Me.r7.Items.Count > 0 Then
            Dim ii7 As Int16
            Dim erklaerungen1, erklaerungen_code1 As XmlNode

            For ii7 = 0 To Me.r7.Items.Count - 1
                If Trim(Microsoft.VisualBasic.Left(Me.r7.Items.Item(ii7), 2)) <> "" Then
                    erklaerungen1 = Doc.CreateElement("erklaerungen")
                    sendungskopf.AppendChild(erklaerungen1)

                    '+------- 3_11a. erklaerungen_code
                    erklaerungen_code1 = Doc.CreateElement("erklaerungen_code")
                    newAtt = Doc.CreateAttribute("value")
                    newAtt.Value = Trim(Microsoft.VisualBasic.Left(Me.r7.Items.Item(ii7), 2)) '"16"
                    erklaerungen_code1.Attributes.Append(newAtt)
                    erklaerungen1.AppendChild(erklaerungen_code1)
                    '+------- 3_11b. erklaerungen_text
                    bhfnr = Doc.CreateElement("erklaerungen_text")
                    bhfnr.InnerText = Microsoft.VisualBasic.Mid(Me.r7.Items.Item(ii7), 5, 100)
                    erklaerungen1.AppendChild(bhfnr)
                End If

                ''erklaerungen1 = Doc.CreateElement("erklaerungen")
                ''sendungskopf.AppendChild(erklaerungen1)

                '''+------- 3_11a. erklaerungen_code
                ''erklaerungen_code1 = Doc.CreateElement("erklaerungen_code")
                ''newAtt = Doc.CreateAttribute("value")
                ''newAtt.Value = Trim(Microsoft.VisualBasic.Left(Me.r7.Items.Item(ii7), 2)) '"16"
                ''erklaerungen_code1.Attributes.Append(newAtt)
                ''erklaerungen1.AppendChild(erklaerungen_code1)
                '''+------- 3_11b. erklaerungen_text
                ''bhfnr = Doc.CreateElement("erklaerungen_text")
                ''bhfnr.InnerText = Microsoft.VisualBasic.Mid(Me.r7.Items.Item(ii7), 5, 100)
                ''erklaerungen1.AppendChild(bhfnr)
            Next
        End If

        ' OMG ---------------- 3_12. kommerz_bed [P13. KOMERCIJALNI USLOVI ]
        If Me.r13.Items.Count > 0 Then ' NOVO
            Dim ii13 As Int16
            Dim kommerz_bed1, kommerz_bed_code1 As XmlNode

            For ii13 = 0 To Me.r13.Items.Count - 1
                If Trim(Microsoft.VisualBasic.Left(Me.r13.Items.Item(ii13), 2)) <> "" Then
                    kommerz_bed1 = Doc.CreateElement("kommerz_bed")
                    sendungskopf.AppendChild(kommerz_bed1)
                    '+------ 3_12a. kommerz_bed_code
                    kommerz_bed_code1 = Doc.CreateElement("kommerz_bed_code")
                    newAtt = Doc.CreateAttribute("value")
                    newAtt.Value = Trim(Microsoft.VisualBasic.Left(Me.r13.Items.Item(ii13), 2)) '"9999" '"5"
                    kommerz_bed_code1.Attributes.Append(newAtt)
                    kommerz_bed1.AppendChild(kommerz_bed_code1)
                    '+------ 3_12b. kommerz_bed_text - do 160!
                    bhfnr = Doc.CreateElement("kommerz_bed_text")
                    bhfnr.InnerText = RTrim(Microsoft.VisualBasic.Mid(Me.r13.Items.Item(ii13), 5, 160))
                    kommerz_bed1.AppendChild(bhfnr)
                End If

                ''kommerz_bed1 = Doc.CreateElement("kommerz_bed")
                ''sendungskopf.AppendChild(kommerz_bed1)
                '''+------ 3_12a. kommerz_bed_code
                ''kommerz_bed_code1 = Doc.CreateElement("kommerz_bed_code")
                ''newAtt = Doc.CreateAttribute("value")
                ''newAtt.Value = Trim(Microsoft.VisualBasic.Left(Me.r13.Items.Item(ii13), 2)) '"9999" '"5"
                ''kommerz_bed_code1.Attributes.Append(newAtt)
                ''kommerz_bed1.AppendChild(kommerz_bed_code1)
                '''+------ 3_12b. kommerz_bed_text - do 160!
                ''bhfnr = Doc.CreateElement("kommerz_bed_text")
                ''bhfnr.InnerText = RTrim(Microsoft.VisualBasic.Mid(Me.r13.Items.Item(ii13), 5, 160))
                ''kommerz_bed1.AppendChild(bhfnr)
            Next
        End If


        ' ok ---------------- 3_13. tarif [P14. BROJ UGOVORA ILI TARIFE ]
        Dim tarif As XmlNode = Doc.CreateElement("tarif")
        sendungskopf.AppendChild(tarif)

        '+------ 3_13a. tarif_kz
        Dim tarif_kz As XmlNode = Doc.CreateElement("tarif_kz")
        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = Me.tb14a.Text '1=ugovor, 2=tarifa
        tarif_kz.Attributes.Append(newAtt)
        tarif.AppendChild(tarif_kz)

        '+------ 3_13b. tarif_nr
        If Len(Trim(RcaFbStr3_13b)) > 0 Then
            bhfnr = Doc.CreateElement("vertrag_nr")
            bhfnr.InnerText = RcaFbStr3_13b
            tarif.AppendChild(bhfnr)
        End If

        ' ok ----------------- 3_14. zolldaten 
        Dim zolldaten As XmlNode = Doc.CreateElement("zolldaten")
        sendungskopf.AppendChild(zolldaten)

        '+------ 3_14a. vgvv tarif [P .  xxxxxxxxxxxxxxxxxxxx ]
        Dim vgvv As XmlNode = Doc.CreateElement("vgvv")
        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = "0"
        vgvv.Attributes.Append(newAtt)
        zolldaten.AppendChild(vgvv)

        'OK ----------------- 3_15. leitungsweg [P50. PREVOZNI PUT ] -trenutno iskljuceno 11.11.2010 !!!
        Dim ijk As Int16 = 1
        Dim leitungsweg As XmlNode

        ''''''''ŽS
        leitungsweg = Doc.CreateElement("leitungsweg")
        sendungskopf.AppendChild(leitungsweg)
        '+------ 3_15a. leitungsweg_code
        vw = Doc.CreateElement("leitungsweg_code")
        '''''vw.InnerText = "72" & Microsoft.VisualBasic.Mid(Me.rtb57b.Items(0), 5, 2)
        vw.InnerText = "72" & Microsoft.VisualBasic.Mid(Me.ListBox2.Items(0), 5, 2)
        leitungsweg.AppendChild(vw)
        '+------ 3_15b. leitungsweg_bezeichnung
        bhfnr = Doc.CreateElement("leitungsweg_bezeichnung")
        bhfnr.InnerText = Microsoft.VisualBasic.Mid(Me.cbSmer2.Text, 11, Len(Me.cbSmer2.Text))
        leitungsweg.AppendChild(bhfnr)

        If NumNizR50 > 0 Then
            If NizR50(1, 0) <> Nothing Then
                For ijk = 1 To NumNizR50 - 1
                    leitungsweg = Doc.CreateElement("leitungsweg")
                    sendungskopf.AppendChild(leitungsweg)
                    '+------ 3_15a. leitungsweg_code
                    vw = Doc.CreateElement("leitungsweg_code")
                    vw.InnerText = NizR50(ijk, 0)
                    leitungsweg.AppendChild(vw)
                    '+------ 3_15b. leitungsweg_bezeichnung
                    bhfnr = Doc.CreateElement("leitungsweg_bezeichnung")
                    bhfnr.InnerText = NizR50(ijk, 1)
                    leitungsweg.AppendChild(bhfnr)
                Next
            End If
        End If


        ' ok* ----------------- 3_16. dokument [P9. PRILOZI ] - > Loop PROVERITI DUZINU ZBOG VISE REDOVA
        If Me.r9.Items.Count > 0 Then ' NOVO
            Dim ii9 As Int16
            Dim dokument1, dokument_typid1 As XmlNode

            For ii9 = 0 To Me.r9.Items.Count - 1
                If Trim(Microsoft.VisualBasic.Left(Me.r9.Items.Item(ii9), 4)) <> "" Then
                    dokument1 = Doc.CreateElement("dokument")
                    sendungskopf.AppendChild(dokument1)
                    '+------ 3_16a. dokument_typid
                    dokument_typid1 = Doc.CreateElement("dokument_typid")
                    newAtt = Doc.CreateAttribute("value")
                    newAtt.Value = Trim(Microsoft.VisualBasic.Left(Me.r9.Items.Item(ii9), 4)) '"9999"
                    dokument_typid1.Attributes.Append(newAtt)
                    dokument1.AppendChild(dokument_typid1)
                    '+------ 3_16b. dokument_text
                    bhfnr = Doc.CreateElement("dokument_text")
                    bhfnr.InnerText = RTrim(Microsoft.VisualBasic.Mid(Me.r9.Items.Item(ii9), 6, 35)) '"Clan 24 stav 1, tacka 9 zakona"
                    dokument1.AppendChild(bhfnr)
                End If
                ''dokument1 = Doc.CreateElement("dokument")
                ''sendungskopf.AppendChild(dokument1)
                '''+------ 3_16a. dokument_typid
                ''dokument_typid1 = Doc.CreateElement("dokument_typid")
                ''newAtt = Doc.CreateAttribute("value")
                ''newAtt.Value = Trim(Microsoft.VisualBasic.Left(Me.r9.Items.Item(ii9), 4)) '"9999"
                ''dokument_typid1.Attributes.Append(newAtt)
                ''dokument1.AppendChild(dokument_typid1)
                '''+------ 3_16b. dokument_text
                ''bhfnr = Doc.CreateElement("dokument_text")
                ''bhfnr.InnerText = RTrim(Microsoft.VisualBasic.Mid(Me.r9.Items.Item(ii9), 6, 35)) '"Clan 24 stav 1, tacka 9 zakona"
                ''dokument1.AppendChild(bhfnr)
            Next
        End If


        'OK ----------------- 3_17. Andere_befoerderer [P57. OSTALI PREVOZNICI ]
        Dim andere_befoerderer, strecke_von, str_v_bahnhof, strecke_bis, str_b_grenzpunkt, an_bef_eigenschaft As XmlNode
        Dim str_v_grenzpunkt, str_b_bahnhof As XmlNode

        'ŽS
        andere_befoerderer = Doc.CreateElement("andere_befoerderer")
        sendungskopf.AppendChild(andere_befoerderer)
        '+------- 3_17a. an_bef_evu
        vw = Doc.CreateElement("an_bef_evu")
        vw.InnerText = RcaFbStr3_3d
        andere_befoerderer.AppendChild(vw)
        '+------- 3_17b. strecke_von
        strecke_von = Doc.CreateElement("strecke_von")
        andere_befoerderer.AppendChild(strecke_von)
        '+---------------- 3_17b1. str_v_bahnhof
        str_v_bahnhof = Doc.CreateElement("str_v_bahnhof")
        strecke_von.AppendChild(str_v_bahnhof)

        vw = Doc.CreateElement("str_v_vw")
        vw.InnerText = "72"
        str_v_bahnhof.AppendChild(vw)

        vw = Doc.CreateElement("str_v_bhfnr")
        vw.InnerText = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5) & Me.TextBox1.Text
        str_v_bahnhof.AppendChild(vw)

        vw = Doc.CreateElement("str_v_bhfname")
        vw.InnerText = RTrim(Me.Label12.Text)
        str_v_bahnhof.AppendChild(vw)

        '+------- 3_17c. strecke_bis
        strecke_bis = Doc.CreateElement("strecke_bis")
        andere_befoerderer.AppendChild(strecke_bis)
        '+---------------- 3_17c1. str_b_grenzpunkt
        str_b_grenzpunkt = Doc.CreateElement("str_b_grenzpunkt")
        strecke_bis.AppendChild(str_b_grenzpunkt)

        vw = Doc.CreateElement("str_b_vw")
        vw.InnerText = "72"
        str_b_grenzpunkt.AppendChild(vw)

        '----------------------------------------------------------------------------
        If Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "1" Then
            vw = Doc.CreateElement("str_b_code")
            vw.InnerText = "711"
            str_b_grenzpunkt.AppendChild(vw)

            vw = Doc.CreateElement("str_b_bezeichnung")
            vw.InnerText = "SUBOTICA GR."
            str_b_grenzpunkt.AppendChild(vw)
        ElseIf Microsoft.VisualBasic.Left(Me.cbSmer2.Text, 1) = "8" Then
            vw = Doc.CreateElement("str_b_code")
            vw.InnerText = "501"
            str_b_grenzpunkt.AppendChild(vw)

            vw = Doc.CreateElement("str_b_bezeichnung")
            vw.InnerText = "SID GR."
            str_b_grenzpunkt.AppendChild(vw)
        End If
        '-----------------------------------------------------------------------------

        '+------- 3_17d. an_bef_eigenschaft
        an_bef_eigenschaft = Doc.CreateElement("an_bef_eigenschaft")
        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = "0" 'umesto "1" - A.Martinez 16.11.2010.
        an_bef_eigenschaft.Attributes.Append(newAtt)
        andere_befoerderer.AppendChild(an_bef_eigenschaft)

        For ijk = 0 To Me.rtb57a.Items.Count - 1
            If ijk = Me.rtb57a.Items.Count - 1 Then ' --------------------------- Uputna uprava
                andere_befoerderer = Doc.CreateElement("andere_befoerderer")
                sendungskopf.AppendChild(andere_befoerderer)

                '+------- 3_18a. an_bef_evu
                vw = Doc.CreateElement("an_bef_evu")
                vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57a.Items(ijk), 4)
                andere_befoerderer.AppendChild(vw)

                '+------- 3_18b. strecke_von
                strecke_von = Doc.CreateElement("strecke_von")
                andere_befoerderer.AppendChild(strecke_von)

                '+---------------- 3_18b1. str_v_bahnhof
                str_v_grenzpunkt = Doc.CreateElement("str_v_grenzpunkt")
                strecke_von.AppendChild(str_v_grenzpunkt)

                vw = Doc.CreateElement("str_v_vw")
                vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57b.Items(ijk), 2)
                str_v_grenzpunkt.AppendChild(vw)

                vw = Doc.CreateElement("str_v_code")
                vw.InnerText = Microsoft.VisualBasic.Mid(Me.rtb57b.Items(ijk), 4, 3)
                str_v_grenzpunkt.AppendChild(vw)

                'Opciono
                '''vw = Doc.CreateElement("str_v_bezeichnung")
                '''vw.InnerText = "SOPRON"
                '''str_v_grenzpunkt.AppendChild(vw)

                '+------- 3_18c. strecke_bis
                strecke_bis = Doc.CreateElement("strecke_bis")
                andere_befoerderer.AppendChild(strecke_bis)

                '+---------------- 3_18c1. str_b_bahnhof
                str_b_bahnhof = Doc.CreateElement("str_b_bahnhof")
                strecke_bis.AppendChild(str_b_bahnhof)

                vw = Doc.CreateElement("str_b_vw")
                vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57b2.Items(ijk), 2)
                str_b_bahnhof.AppendChild(vw)

                vw = Doc.CreateElement("str_b_bhfnr")
                vw.InnerText = Microsoft.VisualBasic.Mid(Me.rtb57b2.Items(ijk), 3, 6)
                str_b_bahnhof.AppendChild(vw)

                'Opciono
                vw = Doc.CreateElement("str_b_bhfname")
                vw.InnerText = RTrim(Me.Label13.Text) 'naziv uputne stanice
                str_b_bahnhof.AppendChild(vw)

                '+------- 3_18d. an_bef_eigenschaft
                an_bef_eigenschaft = Doc.CreateElement("an_bef_eigenschaft")
                newAtt = Doc.CreateAttribute("value")
                newAtt.Value = "1"
                an_bef_eigenschaft.Attributes.Append(newAtt)
                andere_befoerderer.AppendChild(an_bef_eigenschaft)

            Else ' ---------------------------------------------------------------Prolazna uprava

                andere_befoerderer = Doc.CreateElement("andere_befoerderer")
                sendungskopf.AppendChild(andere_befoerderer)

                '+------- 3_18a. an_bef_evu
                vw = Doc.CreateElement("an_bef_evu")
                vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57a.Items(ijk), 4)
                andere_befoerderer.AppendChild(vw)

                '+------- 3_18b. strecke_von
                strecke_von = Doc.CreateElement("strecke_von")
                andere_befoerderer.AppendChild(strecke_von)

                '+---------------- 3_18b1. str_v_grenzpunkt
                str_v_grenzpunkt = Doc.CreateElement("str_v_grenzpunkt")
                strecke_von.AppendChild(str_v_grenzpunkt)

                vw = Doc.CreateElement("str_v_vw")
                vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57b.Items(ijk), 2)
                str_v_grenzpunkt.AppendChild(vw)

                vw = Doc.CreateElement("str_v_code")
                vw.InnerText = Microsoft.VisualBasic.Mid(Me.rtb57b.Items(ijk), 4, 3)
                str_v_grenzpunkt.AppendChild(vw)

                'Opciono - dodati iz niza prelaza Rubrika 50!
                '''vw = Doc.CreateElement("str_v_bezeichnung")
                '''vw.InnerText = "KELEBIA"
                '''str_v_grenzpunkt.AppendChild(vw)

                '+------- 3_18c. strecke_bis
                strecke_bis = Doc.CreateElement("strecke_bis")
                andere_befoerderer.AppendChild(strecke_bis)

                '+---------------- 3_18c1. str_b_bahnhof
                str_b_grenzpunkt = Doc.CreateElement("str_b_grenzpunkt")
                strecke_bis.AppendChild(str_b_grenzpunkt)

                vw = Doc.CreateElement("str_b_vw")
                vw.InnerText = Microsoft.VisualBasic.Left(Me.rtb57b2.Items(ijk), 2)
                str_b_grenzpunkt.AppendChild(vw)

                vw = Doc.CreateElement("str_b_code")
                vw.InnerText = Microsoft.VisualBasic.Mid(Me.rtb57b2.Items(ijk), 4, 3)
                str_b_grenzpunkt.AppendChild(vw)

                'Opciono - dodati iz niza prelaza Rubrika 50!
                '''vw = Doc.CreateElement("str_b_bezeichnung")
                '''vw.InnerText = "SOPRON"
                '''str_b_bahnhof.AppendChild(vw)

                '+------- 3_18d. an_bef_eigenschaft
                an_bef_eigenschaft = Doc.CreateElement("an_bef_eigenschaft")
                newAtt = Doc.CreateAttribute("value")
                newAtt.Value = "1"
                an_bef_eigenschaft.Attributes.Append(newAtt)
                andere_befoerderer.AppendChild(an_bef_eigenschaft)

            End If
        Next

        '+----------------- [P58a. UGOVORNI PREVOZNIK] ?? automatski dedeljuje 0072 & ZS & RS
        Dim vertr_befoerderer As XmlNode = Doc.CreateElement("vertr_befoerderer")
        sendungskopf.AppendChild(vertr_befoerderer)

        '+------- 58_1. ver_b_evu

        vw = Doc.CreateElement("ver_b_evu")
        vw.InnerText = "0072" 'RcaFbStr58a1
        vertr_befoerderer.AppendChild(vw)

        '+------- 58_2. ver_b_name
        bhfnr = Doc.CreateElement("ver_b_name")
        bhfnr.InnerText = "ZELEZNICE SRBIJE" 'RcaFbStr58a2
        vertr_befoerderer.AppendChild(bhfnr)

        '+------- 58_3. ver_b_land
        bhfname = Doc.CreateElement("ver_b_land")
        bhfname.InnerText = "RS"
        vertr_befoerderer.AppendChild(bhfname)


        ' OK --------------------------------------------------------- 4. Wagen
        Dim fb_Kola As String
        Dim fb_Osovine As Int32
        Dim fb_Tara As Decimal 'Int32 bilo u prvoj verziji
        Dim fb_Neto As Decimal
        Dim wagen As XmlNode
        Dim KolaRed As DataRow
        Dim NhmRed As DataRow

        For Each KolaRed In dtKola.Rows
            fb_Kola = KolaRed.Item("IndBrojKola")
            fb_Osovine = KolaRed.Item("Osovine")
            fb_Tara = KolaRed.Item("Tara") 'tezina kola
            fb_Neto = 0 'masa robe

            If Microsoft.VisualBasic.Left(RcaFbStr4_8a, 4) <> "9921" And Microsoft.VisualBasic.Left(RcaFbStr4_8a, 4) <> "9922" Then
                For Each NhmRed In dtNhm.Rows
                    If NhmRed.Item("IndBrojKola") = fb_Kola Then
                        fb_Neto = fb_Neto + NhmRed.Item("MasaDec")
                    End If
                Next
            Else
                fb_Neto = 0
            End If

            ''ispravljeno zbog praznih kola
            ''For Each NhmRed In dtNhm.Rows
            ''    If NhmRed.Item("IndBrojKola") = fb_Kola Then
            ''        fb_Neto = fb_Neto + NhmRed.Item("MasaDec")
            ''    End If
            ''Next
            fb_Neto = Decimal.Round(fb_Neto, 1)
            fb_Tara = Decimal.Round(fb_Tara, 1)

            wagen = Doc.CreateElement("wagen")
            frachtbrief.AppendChild(wagen)
            '+------- 4_1. wg_nr
            vw = Doc.CreateElement("wg_nr")
            vw.InnerText = fb_Kola
            wagen.AppendChild(vw)
            '+------- 4_2. wg_gesamtgewicht_kg - BRUTO MASA KOLA I ROBE
            vw = Doc.CreateElement("wg_gesamtgewicht_kg")
            'vw.InnerText = (fb_Tara + CType(fb_Neto, Int32)).ToString

            'decimalni zbir zbog XSD, RCH:
            vw.InnerText = (fb_Tara + fb_Neto).ToString
            wagen.AppendChild(vw)
            '+------- 4_3. wg_eigengewicht_kg  - TARA
            vw = Doc.CreateElement("wg_eigengewicht_kg")
            vw.InnerText = fb_Tara.ToString
            wagen.AppendChild(vw)
            '+------- 4_5. wg_anz_achsen       - OSOVINE
            vw = Doc.CreateElement("wg_anz_achsen")
            vw.InnerText = fb_Osovine.ToString
            wagen.AppendChild(vw)
            '+------- 4_8. ladegut    - ROBA
            Dim ladegut As XmlNode = Doc.CreateElement("ladegut")
            wagen.AppendChild(ladegut)
            '+------- 4_8a. nhm
            vw = Doc.CreateElement("nhm")
            vw.InnerText = RcaFbStr4_8a
            ladegut.AppendChild(vw)
            '+------ 4_8a. nhm_bezeichnung
            vw = Doc.CreateElement("nhm_bezeichnung")
            vw.InnerText = RcaFbStr4_8b
            ladegut.AppendChild(vw)
            '+------- 4_8a. bruttogewicht_kg  - NETO = BRUTO MASA ROBE
            vw = Doc.CreateElement("bruttogewicht_kg")
            vw.InnerText = fb_Neto.ToString
            ladegut.AppendChild(vw)
        Next


        ' ----------------------------------------------------------- 4. Fba

        Dim fba As XmlNode = Doc.CreateElement("fba")
        frachtbrief.AppendChild(fba)

        '+------- 5_1. verwaltung_von - Otpravna uprava
        vw = Doc.CreateElement("verwaltung_von")
        vw.InnerText = "72"
        fba.AppendChild(vw)

        '+------- 5_2. verwaltung_bis - Uputna uprava
        vw = Doc.CreateElement("verwaltung_bis")
        vw.InnerText = Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2)
        fba.AppendChild(vw)

        '+------- 5_3. strecke
        Dim strecke As XmlNode = Doc.CreateElement("strecke")
        fba.AppendChild(strecke)

        '+------- 5_3b. eintrittsbahnhof 
        Dim eintrittsbahnhof As XmlNode = Doc.CreateElement("eintrittsbahnhof")
        strecke.AppendChild(eintrittsbahnhof)

        '+------- 5_3b1. vw
        vw = Doc.CreateElement("vw")
        vw.InnerText = "72"
        eintrittsbahnhof.AppendChild(vw)

        '+------- 5_3b2. vw
        vw = Doc.CreateElement("bhfnr")
        vw.InnerText = Microsoft.VisualBasic.Mid(Me.tbStanicaOtp.Text, 3, 5) & Me.TextBox1.Text
        eintrittsbahnhof.AppendChild(vw)

        '+------- 5_3b. austrittsbahnhof 
        Dim austrittsbahnhof As XmlNode = Doc.CreateElement("austrittsbahnhof")
        strecke.AppendChild(austrittsbahnhof)

        '+------- 5_3b1. vw
        vw = Doc.CreateElement("vw")
        vw.InnerText = Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2)
        austrittsbahnhof.AppendChild(vw)

        '+------- 5_3b2. vw
        vw = Doc.CreateElement("bhfnr")
        vw.InnerText = Microsoft.VisualBasic.Mid(Me.tbStanicaPr.Text, 3, 5) & Me.TextBox2.Text
        austrittsbahnhof.AppendChild(vw)

        '+------- 5_4. fba_tarif
        Dim fba_tarif As XmlNode = Doc.CreateElement("fba_tarif")
        fba.AppendChild(fba_tarif)

        '+------- 5_4a nhm
        vw = Doc.CreateElement("nhm")
        vw.InnerText = Me.tb24.Text
        fba_tarif.AppendChild(vw)

        '+------- 5_4b tarif_nr
        vw = Doc.CreateElement("tarif_nr")
        vw.InnerText = RcaFbStr3_13b
        fba_tarif.AppendChild(vw)

        '+------- 5_4c frachtpflicht_kg()  [ P74. RACUNSKA MASA ]
        vw = Doc.CreateElement("frachtpflicht_kg")
        vw.InnerText = tbA74d1.Text
        fba_tarif.AppendChild(vw)

        '+------- 5_4d frachtkosten
        Dim frachtkosten As XmlNode = Doc.CreateElement("frachtkosten")
        fba_tarif.AppendChild(frachtkosten)

        Dim waehrung As XmlNode = Doc.CreateElement("waehrung")
        newAtt = Doc.CreateAttribute("value")
        newAtt.Value = "EUR"
        waehrung.Attributes.Append(newAtt)
        frachtkosten.AppendChild(waehrung)

        '========== 5b. fba [ P79. NAKNADE ZA SPOREDNE USLUGE ]
        If Len(Trim(Me.tbA79a1.Text)) > 0 Then
            fba = Doc.CreateElement("fba")
            frachtbrief.AppendChild(fba)
            '+------- 5b_1. verwaltung_von
            vw = Doc.CreateElement("verwaltung_von")
            vw.InnerText = "72"
            fba.AppendChild(vw)
            '+------- 5b_2. verwaltung_bis
            vw = Doc.CreateElement("verwaltung_bis")
            vw.InnerText = "72"
            fba.AppendChild(vw)
            '------- 5b_3. fba_nebengebuehr  [ P79. NAKNADE ZA SPOREDNE USLUGE ] #1
            Dim fba_nebengebuehr As XmlNode = Doc.CreateElement("fba_nebengebuehr")
            fba.AppendChild(fba_nebengebuehr)
            '+------- 5_3a. nbgcode 
            vw = Doc.CreateElement("nbgcode")
            vw.InnerText = Me.tbA79a1.Text
            fba_nebengebuehr.AppendChild(vw)

            '+------- 5_3b. nbgkosten 
            Dim nbgkosten As XmlNode = Doc.CreateElement("nbgkosten")
            fba_nebengebuehr.AppendChild(nbgkosten)

            '+------- 5_3b_1. frankiert 
            vw = Doc.CreateElement("frankiert")
            vw.InnerText = Me.tbA79b1.Text
            nbgkosten.AppendChild(vw)

            '+------- 5_3b_2. waehrung 
            waehrung = Doc.CreateElement("waehrung")
            newAtt = Doc.CreateAttribute("value")
            newAtt.Value = "EUR"
            waehrung.Attributes.Append(newAtt)
            nbgkosten.AppendChild(waehrung)

            If Len(Trim(Me.tbA79a2.Text)) > 0 Then
                '#2
                '+------- 5b_3. fba_nebengebuehr  [ P79. NAKNADE ZA SPOREDNE USLUGE ]
                fba_nebengebuehr = Doc.CreateElement("fba_nebengebuehr")
                fba.AppendChild(fba_nebengebuehr)

                '+------- 5_3a. nbgcode 
                vw = Doc.CreateElement("nbgcode")
                vw.InnerText = Me.tbA79a2.Text
                fba_nebengebuehr.AppendChild(vw)

                '+------- 5_3b. nbgkosten 
                nbgkosten = Doc.CreateElement("nbgkosten")
                fba_nebengebuehr.AppendChild(nbgkosten)

                '+------- 5_3b_1. frankiert 
                vw = Doc.CreateElement("frankiert")
                vw.InnerText = Me.tbA79b2.Text
                nbgkosten.AppendChild(vw)

                '+------- 5_3b_2. waehrung 
                waehrung = Doc.CreateElement("waehrung")
                newAtt = Doc.CreateAttribute("value")
                newAtt.Value = "EUR"
                waehrung.Attributes.Append(newAtt)
                nbgkosten.AppendChild(waehrung)

                If Len(Trim(Me.tbA79a3.Text)) > 0 Then
                    '#3
                    '+------- 5b_3. fba_nebengebuehr  [ P79. NAKNADE ZA SPOREDNE USLUGE ]
                    fba_nebengebuehr = Doc.CreateElement("fba_nebengebuehr")
                    fba.AppendChild(fba_nebengebuehr)

                    '+------- 5_3a. nbgcode 
                    vw = Doc.CreateElement("nbgcode")
                    vw.InnerText = Me.tbA79a3.Text
                    fba_nebengebuehr.AppendChild(vw)

                    '+------- 5_3b. nbgkosten 
                    nbgkosten = Doc.CreateElement("nbgkosten")
                    fba_nebengebuehr.AppendChild(nbgkosten)

                    '+------- 5_3b_1. frankiert 
                    vw = Doc.CreateElement("frankiert")
                    vw.InnerText = Me.tbA79b3.Text
                    nbgkosten.AppendChild(vw)

                    '+------- 5_3b_2. waehrung 
                    waehrung = Doc.CreateElement("waehrung")
                    newAtt = Doc.CreateAttribute("value")
                    newAtt.Value = "EUR"
                    waehrung.Attributes.Append(newAtt)
                    nbgkosten.AppendChild(waehrung)
                End If
            End If
        End If

        '========== Formira xml
        Doc.Save(FolderXml & RcaFbStr1_2)

        '========== Salje xml
        PosaljiXml()  '''iskljuciti kada radi na lokalnom racunaru!!

    End Sub


    Private Sub R57_Init()
        _ForNum = 0

        If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "1" Then 'preko Subotice
            Me.rtb57b.Items.Add("550711")
        ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "8" Then ' preko Sida
            Me.rtb57b.Items.Add("780501")
        End If


        '''''''''Me.rtb57b.Items.Add("550711")


        If rtb57a.Items.Count > 1 Then
            r57_mUprava1 = Me.rtb57a.Items.Item(_ForNum)
            r57_mUprava2 = Me.rtb57a.Items.Item(_ForNum + 1)
            R57_FillCombo()
            'cbR57_Validating(Me, Nothing)
            Me.cbR57.DroppedDown = True
        Else
            'Me.rtb57b2.Items.Add("55100170")
        End If

    End Sub

    Private Sub cbR57_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbR57.Validating

        If mPanelFocus + 1 < Len(x_UicPP) Then
            'If mPanelFocus * 2 <= Len(x_UicPP) Then
            Dim daPrevPut As SqlClient.SqlDataAdapter
            Dim dsPrevPut As New Data.DataSet
            Dim pomSifraPP As String
            Dim upit As String = ""
            Dim objComm As SqlClient.SqlCommand
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If
            '---------------
            Dim ii As Int32 = 0

            cbR57.Items.Clear()
            Me.lbR57.Items.Clear() '------------------------------


            dsPrevPut.Clear()
            upit = "SELECT SifraPrelaza, Naziv " _
                 & "FROM UicPrelazi " _
                 & "WHERE Uprava1 = '" & Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus, 2) & "' AND Uprava2 = '" & Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus + 2, 2) & "' AND LEFT(SifraPrelaza, 1) = '0'"
            Try
                objComm = New SqlClient.SqlCommand(upit, DbVeza)
                daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)
                ii = daPrevPut.Fill(dsPrevPut)
                ''''For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
                ''''    Me.cbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
                ''''Next

                For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
                    Me.lbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
                Next


            Catch ex As Exception
                MsgBox("Nema podataka!")
            Finally
                DbVeza.Close()
                mPanelFocus = mPanelFocus + 2 '797881
                ''''''''''''''''''''''''''''Me.cbR57.Focus() !!
                Me.lbR57.Focus()


            End Try
        Else
            Me.cbR57.Visible = False
            '============================================================================================================================
            '-------------------------------------------------------- rtb57b2 kraj ------------------------------------------------------
            Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text)
            '-------------------------------------------------------- rtb57b prvi red ---------------------------------------------------
            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "1" Then
                Me.rtb57b.Items.Add("550711")
            ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "8" Then
                Me.rtb57b.Items.Add("780501")
            End If
            '-------------------------------------------------------- rtb57b ostatak ----------------------------------------------------
            Dim ii As Int16
            Dim x_string As String
            Dim x_ukred As Int16 = Me.rtb57b2.Items.Count

            For ii = 0 To Me.rtb57b2.Items.Count - 1

                If ii + 1 <= Me.rtb57b2.Items.Count - 1 Then
                    x_string = Me.rtb57b2.Items.Item(ii)
                    rtb57b.Items.Add(Microsoft.VisualBasic.Left(Me.rtb57b2.Items.Item(ii + 1), 2) & Microsoft.VisualBasic.Mid(x_string, 3, 4))
                End If

                'x_string = Me.rtb57b2.Items.Item(ii)
                'rtb57b.Items.Add(Microsoft.VisualBasic.Left(Me.rtb57b2.Items.Item(ii + 1), 2) & Microsoft.VisualBasic.Mid(x_string, 3, 4))

            Next
            '----------------------------------------------------------------------------------------------------------------------------
            '' PopuniR57_x()
            '============================================================================================================================
            Me.Button22.Focus()
        End If
        '''Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) & Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 5))

        ''''Dim daPrevPut As SqlClient.SqlDataAdapter
        ''''Dim dsPrevPut As New Data.DataSet
        ''''Dim pomSifraPP As String
        ''''Dim upit As String = ""
        ''''Dim objComm As SqlClient.SqlCommand

        ''''If _ForNum < Me.rtb57a.Items.Count - 1 Then
        ''''    upit = ""
        ''''End If

        ''''If DbVeza.State = ConnectionState.Closed Then
        ''''    DbVeza.Open()
        ''''End If
        '''''---------------
        ''''Dim ii As Int32 = 0

        ''''cbR57.Items.Clear()
        ''''dsPrevPut.Clear()

        ''''upit = "SELECT SifraPrelaza, Naziv " _
        ''''     & "FROM UicPrelazi " _
        ''''     & "WHERE Uprava1 = '" & Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & "' AND Uprava2 = '" & Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & "' AND LEFT(SifraPrelaza, 1) = '0'"

        ''''Try
        ''''    objComm = New SqlClient.SqlCommand(upit, DbVeza)
        ''''    daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)
        ''''    ii = daPrevPut.Fill(dsPrevPut)
        ''''    For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
        ''''        Me.cbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
        ''''    Next

        ''''Catch ex As Exception
        ''''    MsgBox("Nema podataka!")
        ''''Finally
        ''''    DbVeza.Close()
        ''''    Me.cbR57.Focus()
        ''''End Try

    End Sub

    Private Sub cbR57_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbR57.GotFocus
        Me.cbR57.DroppedDown = True
    End Sub

    Private Sub cbR57_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbR57.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub cbR57_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbR57.Leave
        '''novo 3.3.2011
        '''Dim str_R50_x As String

        '''Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus - 2, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))    '780501
        '''stepR57 = stepR57 + 1

        '''str_R50_x = Microsoft.VisualBasic.Mid(Me.rtb57a.Items.Item(stepR57 - 1), 3, 2)
        '''str_R50 = str_R50 & str_R50_x & Microsoft.VisualBasic.Mid(RTrim(cbR57.Text), 3, Len(cbR57.Text)) & " - "

        ''''--------------------------------------------------------------------------------------------
        '''NizR50(stepR57, 0) = str_R50_x & Microsoft.VisualBasic.Mid(cbR57.Text, 3, 2)
        '''NizR50(stepR57, 1) = RTrim(Microsoft.VisualBasic.Right(cbR57.Text, Len(cbR57.Text) - 5))
        ''''--------------------------------------------------------------------------------------------
        '''end novo 3.3.2011



        'If mPanelFocus = 1 Then
        '    Me.rtb57b.Items.Add("78501")
        '    'Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))      '780501
        'Else
        '    'Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))   '790442
        '    'Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))      '780501

        '    Me.rtb57b2.Items.Add(Me.rtb57b.Items.Item(1))
        '    Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))      '780501

        'End If

        'Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus + 2, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4)) '790442
        'Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))      '780501



        'Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))
        'Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))


        'Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))
        'Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))

        'str_R50 = Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & Microsoft.VisualBasic.Mid(Me.cbR57.Text, 3, 2)
        'str_R50naziv = Microsoft.VisualBasic.Mid(Me.cbR57.Text, 5, Len(Me.cbR57.Text) - 4)

        ''tb50.Text = tb50.Text & str_R50 & " " & RTrim(str_R50naziv) & " - "

        'NizR50(_ForNum, 0) = str_R50
        'NizR50(_ForNum, 1) = RTrim(str_R50naziv)

        'tb50.Text = tb50.Text & NizR50(_ForNum, 0) & " " & NizR50(_ForNum, 1) & " - "

        ''!?!?!?!?!?!?!?!?!?!
        ''ako je susedna uprava-niz je null i len je error

        '_ForNum = _ForNum + 1
        'BrojPrelazaUNizu = _ForNum

        'If _ForNum < Me.rtb57a.Items.Count - 1 Then
        '    'Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))
        '    'Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & Microsoft.VisualBasic.Left(Me.cbR57.Text, 4))

        '    Me.cbR57.Enabled = True
        '    r57_mUprava1 = Me.rtb57a.Items.Item(_ForNum)
        '    r57_mUprava2 = Me.rtb57a.Items.Item(_ForNum + 1)
        '    SkokNaVoz = "Ne"
        'ElseIf _ForNum = Me.rtb57a.Items.Count - 1 Then
        '    Me.rtb57b2.Items.Add(tbStanicaPr.Text & Me.TextBox2.Text) 'uputna stanica
        '    tb50.Text = Microsoft.VisualBasic.Left(tb50.Text, Len(tb50.Text) - 3)

        '    Me.cbR57.SelectedIndex = -1
        '    Me.Button22.Focus()


        '    '++++++++++++++++++++Me.cbR57.Enabled = False
        '    '++++++++++++++++++++SkokNaVoz = "Da" 'Treba da skoèi na tbsbrojvoza

        '    '''Me.btnUpis.Focus()

        'End If
    End Sub
    Private Sub R57_FillCombo()
        Dim daPrevPut As SqlClient.SqlDataAdapter
        Dim dsPrevPut As New Data.DataSet
        Dim pomSifraPP As String
        Dim upit As String = ""
        Dim objComm As SqlClient.SqlCommand

        If _ForNum < Me.rtb57a.Items.Count - 1 Then
            upit = ""
        End If

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        '---------------
        Dim ii As Int32 = 0

        cbR57.Items.Clear()
        dsPrevPut.Clear()

        upit = "SELECT SifraPrelaza, Naziv " _
             & "FROM UicPrelazi " _
             & "WHERE Uprava1 = '" & Microsoft.VisualBasic.Mid(r57_mUprava1, 3, 2) & "' AND Uprava2 = '" & Microsoft.VisualBasic.Mid(r57_mUprava2, 3, 2) & "' AND LEFT(SifraPrelaza, 1) = '0'"

        Try
            objComm = New SqlClient.SqlCommand(upit, DbVeza)
            daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)
            ii = daPrevPut.Fill(dsPrevPut)
            For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
                Me.cbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
            Next

        Catch ex As Exception
            MsgBox("Nema podataka!")
        Finally
            DbVeza.Close()
            Me.cbR57.Focus()
        End Try

    End Sub
    Private Sub PosaljiXml()
        Dim SentBytes, RecBytes As Int32
        Dim FromFile As String = FolderXml & SourceFile
        Dim ToFile As String = FolderFtp & SourceFile 'rch
        Dim mFileSize1, mFileSize2 As Long

        '*******************************************************
        If mStanica2 = "23499" Then
            ToFile = FolderFtp & SourceFile
        ElseIf mStanica2 = "16517" Or mStanica2 = "25471" Then
            ToFile = FolderFtp2 & SourceFile
        End If
        '*******************************************************

        GetFileSize(FromFile, mFileSize1)
        If System.IO.File.Exists(FromFile) = True Then
            Try
                System.IO.File.Copy(FromFile, ToFile)
                GetFileSize(ToFile, mFileSize2)
                If mFileSize1 = mFileSize2 Then
                    MessageBox.Show("Uspesan transfer podataka!", "Poruka sa servera", MessageBoxButtons.OK)
                    System.IO.File.Delete(FromFile)
                Else
                    MsgBox("Neuspešan transfer e-Cim XML : " & mFileSize1.ToString & " -> " & mFileSize2.ToString)
                End If
            Catch ex As Exception
                MessageBox.Show("Elektronski dokument nije poslat.  Opis greške:  " & ex.ToString, "Greška", MessageBoxButtons.OK)
            End Try

        End If
    End Sub
    Private Sub GetFileSize(ByVal MyFilePath As String, ByRef MyFileSize As Long)
        Dim MyFile As New FileInfo(MyFilePath)
        MyFileSize = MyFile.Length

    End Sub
    Private Sub tb16e_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb16e.Validating

        ''If tb16e.Text = Nothing Then
        ''    tb16e.Focus()
        ''Else
        ''    If IsNumeric(tb16e.Text) = True Then
        ''        If CType(Me.tb16e.Text, Int16) > 23 Then
        ''            Me.tb16e.Focus()
        ''        Else
        ''            If Len(m_UicPrevozniPut) = 2 Then
        ''                Me.btnUpis.Focus()
        ''            Else
        ''                '-- da li samo u slucaju 2155
        ''                If IzborSaobracaja = "3" Then
        ''                    If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then

        ''                    End If
        ''                Else
        ''                    PopuniR57a()
        ''                    R57_Init()
        ''                End If
        ''                '-- end da li samo u slucaju 2155
        ''                '''''PopuniR57a()
        ''                '''''R57_Init()

        ''                Me.btnUpis.Focus()
        ''            End If
        ''        End If
        ''    Else
        ''        Me.tb16e.Focus()
        ''    End If
        ''End If

        '''''''''''''
        If IsNumeric(tb16e.Text) = True Then
            If CType(Me.tb16e.Text, Int16) >= 0 And CType(Me.tb16e.Text, Int16) < 24 Then
                If Len(tb16e.Text) = 1 Then
                    Me.tb16e.Text = "0" & Me.tb16e.Text
                End If
                If Len(m_UicPrevozniPut) = 2 Then
                    If IzborSaobracaja = "3" And eCimDa = "D" Then
                        If Me.tb4a.Text = Nothing Then
                            Me.tb4a.Focus()
                        Else
                            Me.btnUpis.Focus()
                        End If
                    Else
                        Me.btnUpis.Focus()
                    End If
                Else
                    If IzborSaobracaja = "3" And eCimDa = "D" Then
                        If Me.tb4a.Text = Nothing Then
                            Me.tb4a.Focus()
                        Else
                            Me.btnUpis.Focus()
                        End If
                    Else
                        Me.btnUpis.Focus()
                    End If
                    ''If IzborSaobracaja = "3" And eCimDa = "D" Then
                    ''    If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" And Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) = "55" Then
                    ''        ''Me.btnUpis.Focus()
                    ''    Else
                    ''        PopuniR57a()
                    ''        R57_Init()
                    ''    End If
                    ''End If

                End If

                ''If IzborSaobracaja = "3" And eCimDa = "D" Then
                ''    Me.cbR57.Focus()
                ''Else
                ''    Me.btnUpis.Focus()
                ''End If
            Else
                Me.tb16e.Focus()
            End If
        Else
            Me.tb16e.Focus()
        End If

    End Sub

    Private Sub tb16c_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb16c.Validating
        If IsNumeric(tb16c.Text) = True Then
            If CType(Me.tb16c.Text, Int16) > 0 And CType(Me.tb16c.Text, Int16) < 13 Then
                If Len(Me.tb16c.Text) = 1 Then
                    Me.tb16c.Text = "0" & Me.tb16c.Text
                End If
                Me.tb16d.Focus()
            Else
                Me.tb16c.Focus()
            End If
        Else
            Me.tb16c.Focus()
        End If
    End Sub
    Private Sub tb16d_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb16d.Validating
        If IsNumeric(tb16d.Text) = True Then
            If CType(Me.tb16d.Text, Int16) > 0 And CType(Me.tb16d.Text, Int16) < 32 Then
                If Len(Me.tb16d.Text) = 1 Then
                    Me.tb16d.Text = "0" & Me.tb16d.Text
                End If
                Me.tb16e.Focus()
            Else
                Me.tb16d.Focus()
            End If
        Else
            Me.tb16d.Focus()
        End If
    End Sub
    Private Sub ComboBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.Leave
        Me.ComboBox5.Width = 45
        Me.tb4b2.Text = Microsoft.VisualBasic.Left(Me.ComboBox5.Text, 2)
        Me.btnUpis.Focus()
    End Sub

    '''Private Sub ComboBox5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox5.MouseUp
    '''    Me.ComboBox5.Width = 150
    '''End Sub

    Private Sub ComboBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox5.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub ComboBox6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.Leave
        Me.ComboBox6.Width = 45
        Me.tb1b2.Text = Microsoft.VisualBasic.Left(Me.ComboBox6.Text, 2)
        Me.btnUpis.Focus()
    End Sub

    ''Private Sub ComboBox6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox6.MouseUp
    ''    Me.ComboBox6.Width = 150
    ''End Sub

    Private Sub ComboBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox6.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub tbUgovor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUgovor.GotFocus
        Me.tbUgovor.SelectionStart = 0
        Me.tbUgovor.SelectionLength = Len(tbUgovor.Text)

    End Sub
    Private Sub Init_Tarifa()
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim sql_trz1 As String = "SELECT dbo.ZsTarifa.SifraTarife, dbo.ZsTarifa.Opis FROM dbo.ZsTarifa " & _
                                 "WHERE (dbo.ZsTarifa.SifraVS = '" & IzborSaobracaja & "')"

        Dim sql_commTrz1 As New SqlClient.SqlCommand(sql_trz1, DbVeza)
        Dim rdrTar As SqlClient.SqlDataReader
        Dim combo_linija1 As String = ""
        ComboBox1.Items.Clear()
        rdrTar = sql_commTrz1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrTar.Read()
            combo_linija1 = rdrTar.GetString(0) & " - " & rdrTar.GetString(1)
            ComboBox1.Items.Add(combo_linija1)
        Loop
        rdrTar.Close()
        DbVeza.Close()
    End Sub
    Private Sub Init_Forma()

        If IzborSaobracaja = "4" Then
            Me.TB58a1.Text = ""
            Me.TB58a2.Text = ""
            Me.GroupBox3.Enabled = True
            Me.tbBrojPr.Enabled = False
            Me.gbPrevozniPut.Visible = False
            If TipTranzita = "ulaz" Then
                tbUlaznaNalepnica.Enabled = True
                tbIzlaznaNalepnica.Enabled = False

                Me.cbSmer1.Enabled = False
                Me.cbSmer1.Text = StanicaUnosa
                Me.cbSmer2.Enabled = True

                If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
                    Me.tbPolaznaCarina.Text = "25046"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
                    Me.tbPolaznaCarina.Text = "23035"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
                    Me.tbPolaznaCarina.Text = "13021"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
                    Me.tbPolaznaCarina.Text = "15288"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
                    Me.tbPolaznaCarina.Text = "14125"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
                    Me.tbPolaznaCarina.Text = "42153"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
                    Me.tbPolaznaCarina.Text = "21083"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
                    Me.tbPolaznaCarina.Text = "22136"
                End If

                '----------------- inicijalizacija tranzitnih nalepnica
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
                tbUlaznaNalepnica.Text = mUlEtiketa
                '-----------------
            Else

                Me.cbSmer1.Text = UlazniTranzit
                Me.cbSmer2.Text = StanicaUnosa
                Me.cbSmer1.Enabled = False
                Me.cbSmer2.Enabled = False
                tbUlaznaNalepnica.Enabled = True
                tbIzlaznaNalepnica.Enabled = True

                If Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "23499" Then
                    Me.tbPolaznaCarina.Text = "25046"
                ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "21099" Then
                    Me.tbPolaznaCarina.Text = "23035"
                ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "12498" Then
                    Me.tbPolaznaCarina.Text = "13021"
                ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "11028" Then
                    Me.tbPolaznaCarina.Text = "15288"
                ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "15723" Then
                    Me.tbPolaznaCarina.Text = "14125"
                ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "16319" Then
                    Me.tbPolaznaCarina.Text = "42153"
                ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "16517" Then
                    Me.tbPolaznaCarina.Text = "21083"
                ElseIf Microsoft.VisualBasic.Mid(UlazniTranzit, 5, 5) = "25471" Then
                    Me.tbPolaznaCarina.Text = "22136"
                End If

                If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
                    Me.tbCarinjenje.Text = "25046"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
                    Me.tbCarinjenje.Text = "23035"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
                    Me.tbCarinjenje.Text = "13021"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
                    Me.tbCarinjenje.Text = "15288"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
                    Me.tbCarinjenje.Text = "14125"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
                    Me.tbCarinjenje.Text = "42153"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
                    Me.tbCarinjenje.Text = "21083"
                ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
                    Me.tbCarinjenje.Text = "22136"
                End If

                '----------------- inicijalizacija tranzitnih nalepnica
                If DbVeza.State = ConnectionState.Closed Then
                    DbVeza.Open()
                End If

                Dim sql_text As String = "SELECT IzlaznaNalepnica " & _
                                         "FROM dbo.ZsTrzNalepnice " & _
                                         "WHERE (dbo.ZsTrzNalepnice.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

                Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
                Dim rdrTrz As SqlClient.SqlDataReader

                rdrTrz = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdrTrz.Read()
                    mIzEtiketa = rdrTrz.GetInt32(0) '+ 1
                Loop
                rdrTrz.Close()
                DbVeza.Close()
                '----------------- 
                tbIzlaznaNalepnica.Text = mIzEtiketa + 1
            End If
        ElseIf IzborSaobracaja = "2" Then
            Me.TB58a1.Text = ""
            Me.TB58a2.Text = ""
            Me.gbPrevozniPut.Enabled = False

            If GranicnaStanica = "D" Then
                Me.cbSmer1.Enabled = False
                Me.cbSmer1.Text = StanicaUnosa
            Else
                Me.cbSmer1.Enabled = True
                Me.cbSmer1.Text = StanicaUnosa
            End If

            'Me.cbSmer1.Enabled = True 'False 
            'Me.cbSmer1.Text = StanicaUnosa
            Me.cbSmer2.Enabled = False

            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
                Me.tbPolaznaCarina.Text = "25046"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
                Me.tbPolaznaCarina.Text = "23035"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
                Me.tbPolaznaCarina.Text = "13021"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
                Me.tbPolaznaCarina.Text = "15288"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
                Me.tbPolaznaCarina.Text = "14125"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
                Me.tbPolaznaCarina.Text = "42153"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
                Me.tbPolaznaCarina.Text = "21083"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
                Me.tbPolaznaCarina.Text = "22136"
            End If

            Me.GroupBox3.Enabled = False
            Me.tbBrojPr.Enabled = True
            Me.tbUpravaPr.Text = "0072"
            Me.Label14.Text = "ZS"
        ElseIf IzborSaobracaja = "3" Then
            Me.TB58a1.Text = "0072"
            Me.TB58a2.Text = "ZELEZNICE SRBIJE" ', Nemanjina 6, Beograd, Serbia"
            Me.tb13.Text = "13.1  " & RTrim(Microsoft.VisualBasic.Mid(StanicaUnosa, 11, Len(StanicaUnosa))) & " Gr"

            Me.gbPrevozniPut.Enabled = True
            Me.cbSmer1.Enabled = False

            Me.tbUpravaOtp.Text = "0072"
            Me.Label11.Text = "ZS"
            'TLSNET
            If GranicnaStanica = "D" Then
                Me.cbSmer2.Text = StanicaUnosa
                Me.tbStanicaOtp.Text = "72"
            Else
                Me.cbSmer2.Enabled = True
                Me.tbStanicaOtp.Text = "72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)
            End If

            Me.GroupBox3.Enabled = False
            Me.tbBrojPr.Enabled = False

        End If

        mAkcija = "New"
        mObrMesec = Today.Month
        mObrGodina = Today.Year

    End Sub
    Private Sub eInit_NewCim89()

        'brisanje vrednosti promenljivih pre novog unosa
        xml_ZemljaOtp = ""
        xml_StanicaOtp = ""
        xml_NazivStaniceOtp = ""
        xml_OperaterOtp = ""
        xml_ZemljaPr = ""
        xml_StanicaPr = ""
        xml_NazivStanicePr = ""
        xml_BrojCimOtp = 0
        xml_tara = 0
        xml_netoInt = 0
        xml_osovine = 0
        xml_GrTov = 0
        xml_netoDec = 0
        xml_R16a = ""
        xml_R16b = ""
        xml_R16c = ""
        xml_R16d = ""
        xml_R16god = ""
        xml_R16e = ""
        xml_R20a = ""
        xml_R20b = ""
        xml_R20c = ""
        xml_R20d = ""
        xml_R20f = ""
        xml_R10a = ""
        xml_R10b = ""
        xml_R10c = ""
        xml_R10d = ""
        xml_R12 = ""
        xml_R29a = ""
        xml_R29b = ""
        xml_R50 = ""
        xml_R57a = ""
        xml_R57b = ""
        xml_R57a1 = ""
        xml_R57a2 = ""
        xml_R57b1 = ""
        xml_R57b1a = ""
        xml_R57b2 = ""
        xml_R57b2a = ""
        xml_R2 = ""
        xml_R1a = ""
        xml_R1b = ""
        xml_R1c = ""
        xml_R1d = ""
        xml_R5 = ""
        xml_R4a = ""
        xml_R4b = ""
        xml_R4c = ""
        xml_R4d = ""
        xml_IBK = ""
        xml_Nhm = ""
        xml_R57_ulaz = ""
        xml_R57_izlaz = ""

    End Sub
    Private Sub eInit_Forma()


        If IzborSaobracaja = "4" Then
            Me.TB58a1.Text = ""
            Me.TB58a2.Text = ""
            Me.GroupBox3.Enabled = True
            Me.tbBrojPr.Enabled = False
            Me.gbPrevozniPut.Visible = False

            tbUlaznaNalepnica.Enabled = True
            tbIzlaznaNalepnica.Enabled = False

            Me.cbSmer1.Enabled = False
            Me.cbSmer1.Text = StanicaUnosa
            Me.cbSmer2.Enabled = True

            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
                Me.tbPolaznaCarina.Text = "25046"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
                Me.tbPolaznaCarina.Text = "23035"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
                Me.tbPolaznaCarina.Text = "13021"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
                Me.tbPolaznaCarina.Text = "15288"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
                Me.tbPolaznaCarina.Text = "14125"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
                Me.tbPolaznaCarina.Text = "42153"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
                Me.tbPolaznaCarina.Text = "21083"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
                Me.tbPolaznaCarina.Text = "22136"
            End If

            '----------------- inicijalizacija tranzitnih nalepnica
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
            tbUlaznaNalepnica.Text = mUlEtiketa

        ElseIf IzborSaobracaja = "2" Then
            Me.TB58a1.Text = ""
            Me.TB58a2.Text = ""
            Me.gbPrevozniPut.Enabled = False
            Me.cbSmer1.Enabled = False
            Me.cbSmer1.Text = StanicaUnosa
            Me.cbSmer2.Enabled = False

            If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "23499" Then
                Me.tbPolaznaCarina.Text = "25046"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "21099" Then
                Me.tbPolaznaCarina.Text = "23035"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "12498" Then
                Me.tbPolaznaCarina.Text = "13021"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "11028" Then
                Me.tbPolaznaCarina.Text = "15288"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "15723" Then
                Me.tbPolaznaCarina.Text = "14125"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16319" Then
                Me.tbPolaznaCarina.Text = "42153"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "16517" Then
                Me.tbPolaznaCarina.Text = "21083"
            ElseIf Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) = "25471" Then
                Me.tbPolaznaCarina.Text = "22136"
            End If

            Me.GroupBox3.Enabled = False
            Me.tbBrojPr.Enabled = True
            Me.tbUpravaPr.Text = "0072"
            Me.Label14.Text = "ZS"
        End If

        mAkcija = "New"
        mObrMesec = Today.Month
        mObrGodina = Today.Year

    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        IzborSaobracaja = "4"
        TipTranzita = "ulaz"
        Me.Text = ":: CIM - Tranzit ULAZ ::"
        Init_Tarifa()
        Init_Forma()
        Me.ComboBox1.Focus()

    End Sub

    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        IzborSaobracaja = "2"
        Me.Text = ":: CIM - U V O Z ::"
        Init_Tarifa()
        Init_Forma()
        Me.ComboBox1.Focus()
    End Sub

    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        IzborSaobracaja = "3"
        Me.Text = ":: CIM - I Z V O Z ::"
        Init_Tarifa()
        Init_Forma()
        Me.ComboBox1.Focus()
    End Sub

    Private Sub tbsBrojVoza_Validating1(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbsBrojVoza.Validating
        If tbsBrojVoza.Text Is Nothing Then
            If GranicnaStanica = "D" Then
                ErrorProvider1.SetError(PictureBox3, "Neispravan broj voza!")
                ErrorProvider1.SetIconAlignment(PictureBox3, ErrorIconAlignment.TopLeft)
                tbsBrojVoza.Focus()
            Else
                ErrorProvider1.SetError(PictureBox3, "")
            End If

        Else
            If IsNumeric(tbsBrojVoza.Text) = True Then
                If CType(Me.tbsBrojVoza.Text, Int32) > 0 Then
                    ErrorProvider1.SetError(PictureBox3, "")
                    Me.tbsSatVoza.Focus()
                Else
                    If GranicnaStanica = "D" Then
                        ErrorProvider1.SetError(PictureBox3, "Neispravan broj voza!")
                        ErrorProvider1.SetIconAlignment(PictureBox3, ErrorIconAlignment.TopLeft)
                        tbsBrojVoza.Focus()
                    Else
                        ErrorProvider1.SetError(PictureBox3, "")
                    End If
                End If
            Else
                ErrorProvider1.SetError(PictureBox3, "Neispravan broj voza!")
                ErrorProvider1.SetIconAlignment(PictureBox3, ErrorIconAlignment.TopLeft)
                tbsBrojVoza.Focus()
            End If
        End If
    End Sub

    Private Sub tb1a_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb1a.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb1a_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb1a.Leave
        Me.tb1a.BackColor = System.Drawing.Color.DarkSeaGreen
        tb1b.Focus()
    End Sub

    Private Sub tb1b_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb1b.Leave
        Me.tb1b.BackColor = System.Drawing.Color.DarkSeaGreen
        tb1b1.Focus()
    End Sub

    Private Sub tb1b1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb1b1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb1b_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb1b.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb4a_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb4a.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb4a_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb4a.Leave
        Me.tb4a.BackColor = System.Drawing.Color.DarkSeaGreen
        tb4b.Focus()

    End Sub

    Private Sub tb4b_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb4b.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tb4b_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb4b.Leave
        Me.tb4b.BackColor = System.Drawing.Color.DarkSeaGreen
        tb4b1.Focus()

    End Sub

    Private Sub tb4b1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb4b1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub btnUpis_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.GotFocus
        Me.btnUpis.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.btnUpis.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub btnUpis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpis.Leave
        Me.btnUpis.BackColor = System.Drawing.Color.PapayaWhip
        Me.btnUpis.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "     Ugovori"
        upit = "Ugovori"
        helpUic.ShowDialog()
        Me.tbUgovor.Focus()
        Me.tbUgovor.Text = mIzlaz2
    End Sub
    Private Sub tbsBrojVoza_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsBrojVoza.GotFocus
        Me.tbsBrojVoza.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbsBrojVoza.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbsBrojVoza_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsBrojVoza.Leave
        Me.tbsBrojVoza.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.tbsBrojVoza.ForeColor = System.Drawing.Color.Black

        If GranicnaStanica = "D" Then
            Me.tbsSatVoza.Focus()
        Else

        End If

    End Sub

    Private Sub tbsSatVoza_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsSatVoza.GotFocus
        Me.tbsSatVoza.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbsSatVoza.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tb16c_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb16c.GotFocus
        Me.tb16c.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tb16d_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb16d.GotFocus
        Me.tb16d.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tb16e_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb16e.GotFocus
        Me.tb16e.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tb16c_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb16c.Leave
        Me.tb16c.BackColor = System.Drawing.Color.DarkSeaGreen
    End Sub

    Private Sub tb16d_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb16d.Leave
        Me.tb16d.BackColor = System.Drawing.Color.DarkSeaGreen
    End Sub
    Private Sub tb16e_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb16e.Leave
        Me.tb16e.BackColor = System.Drawing.Color.DarkSeaGreen
    End Sub
    Private Sub tbsSatVoza_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsSatVoza.Leave
        Me.tbsSatVoza.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.tbsSatVoza.ForeColor = System.Drawing.Color.Black

        If GranicnaStanica = "D" Then
            If CType(Me.tbsSatVoza.Text, Int32) > 24 Then
                Me.tbsSatVoza.Focus()
            Else
                If eRazmena = "Da" Then
                    btnUpis.Focus()
                Else
                    btnUnosRobe_Click(Me, Nothing)
                End If

            End If
        Else
            btnUnosRobe_Click(Me, Nothing)
        End If

    End Sub
    Private Sub tb1a_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb1a.GotFocus
        Me.tb1a.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tb1b_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb1b.GotFocus
        Me.tb1b.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tb1b1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb1b1.GotFocus
        Me.tb1b1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tb4a_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb4a.GotFocus
        Me.tb4a.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tb4b_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb4b.GotFocus
        Me.tb4b.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tb4b1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb4b1.GotFocus
        Me.tb4b1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tb1b1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb1b1.Leave
        Me.tb1b1.BackColor = System.Drawing.Color.DarkSeaGreen
    End Sub

    Private Sub tb4b1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb4b1.Leave
        Me.tb4b1.BackColor = System.Drawing.Color.DarkSeaGreen
    End Sub

    Private Sub tbUpravaOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaOtp.GotFocus
        Me.tbUpravaOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbUpravaOtp.ForeColor = System.Drawing.Color.White

    End Sub

    Private Sub tbUpravaOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaOtp.Leave
        Me.tbUpravaOtp.BackColor = System.Drawing.Color.White
        Me.tbUpravaOtp.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbStanicaOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaOtp.GotFocus
        Me.tbStanicaOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbStanicaOtp.ForeColor = System.Drawing.Color.White

        If GranicnaStanica = "N" Then
            Me.tbStanicaOtp.SelectionStart = 2
            Me.tbStanicaOtp.SelectionLength = 5
        End If
    End Sub
    Private Sub tbBrojOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.GotFocus
        Me.tbBrojOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbBrojOtp.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbBrojOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojOtp.Leave
        Me.tbBrojOtp.BackColor = System.Drawing.Color.White
        Me.tbBrojOtp.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub DatumOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.GotFocus
        Me.DatumOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.DatumOtp.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub DatumOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumOtp.Leave
        Me.DatumOtp.BackColor = System.Drawing.Color.White
        Me.DatumOtp.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbUpravaPr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaPr.GotFocus
        Me.tbUpravaPr.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbUpravaPr.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbUpravaPr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUpravaPr.Leave
        Me.tbUpravaPr.BackColor = System.Drawing.Color.White
        Me.tbUpravaPr.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbStanicaPr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStanicaPr.GotFocus
        Me.tbStanicaPr.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbStanicaPr.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbBrojPr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbBrojPr.GotFocus
        Me.tbBrojPr.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbBrojPr.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub DateTimePicker2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.GotFocus
        Me.DateTimePicker2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
    End Sub

    Private Sub tbUlaznaNalepnica_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUlaznaNalepnica.GotFocus
        Me.tbUlaznaNalepnica.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbUlaznaNalepnica.ForeColor = System.Drawing.Color.White

    End Sub

    Private Sub tbUlaznaNalepnica_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbUlaznaNalepnica.Leave
        Me.tbUlaznaNalepnica.BackColor = System.Drawing.SystemColors.Control
        Me.tbUlaznaNalepnica.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub tbIzlaznaNalepnica_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbIzlaznaNalepnica.GotFocus
        Me.tbIzlaznaNalepnica.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbIzlaznaNalepnica.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub tbIzlaznaNalepnica_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbIzlaznaNalepnica.Leave
        Me.tbIzlaznaNalepnica.BackColor = System.Drawing.SystemColors.Control
        Me.tbIzlaznaNalepnica.ForeColor = System.Drawing.Color.Black

    End Sub

    Private Sub tbCarinjenje_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbCarinjenje.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbCarinjenje_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCarinjenje.Leave
        Me.tbCarinjenje.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.tbCarinjenje.ForeColor = System.Drawing.Color.Black
        Me.btnUpis.Focus()

    End Sub

    Private Sub tbCarinjenje_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCarinjenje.GotFocus
        Me.tbCarinjenje.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.tbCarinjenje.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub kbBrojOtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles kbBrojOtp.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub kbBrojOtp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles kbBrojOtp.Leave
        Me.kbBrojOtp.BackColor = System.Drawing.Color.White
        Me.kbBrojOtp.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub kbBrojOtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles kbBrojOtp.GotFocus
        Me.kbBrojOtp.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.kbBrojOtp.ForeColor = System.Drawing.Color.White
    End Sub

    Private Sub kbBrojOtp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles kbBrojOtp.Validating
        'zbog Italije!!

        '''If kbBrojOtp.Text = Nothing Then
        '''    ErrorProvider1.SetError(Label15, "Unesite kontrolni broj")
        '''    kbBrojOtp.Focus()
        '''Else
        '''    If IsNumeric(kbBrojOtp.Text) = True Then
        '''        ErrorProvider1.SetError(Label15, "")
        '''    Else
        '''        ErrorProvider1.SetError(Label15, "Neispravan unos kontrolnog broja!")
        '''        tbBrojOtp.Focus()
        '''    End If
        '''End If

    End Sub
    Public Sub DownloadValues()

        tbUpravaOtp.Text = xml_OperaterOtp
        tbStanicaOtp.Text = xml_ZemljaOtp & Microsoft.VisualBasic.Left(xml_StanicaOtp, 5)
        TextBox1.Text = Microsoft.VisualBasic.Right(xml_StanicaOtp, 1)
        Me.tbBrojOtp.Text = Microsoft.VisualBasic.Left(xml_BrojCimOtp.ToString, Len(xml_BrojCimOtp.ToString) - 1)
        kbBrojOtp.Text = Microsoft.VisualBasic.Right(xml_BrojCimOtp.ToString, 1)
        Label12.Text = xml_NazivStaniceOtp

        Me.DatumOtp.Text = xml_R16c & "." & xml_R16d & "." & xml_R16god

        '''''tb17.Text = xml_R16c & "." & xml_R16d & "." & xml_R16a

        tb16a.Text = xml_R16b
        tb16c.Text = xml_R16c
        tb16d.Text = xml_R16d
        tb16e.Text = xml_R16e

        If IzborSaobracaja = "2" Then
            tbUpravaPr.Text = "0072"
        Else
            tbUpravaPr.Text = xml_ZemljaPr
        End If

        Me.tbStanicaPr.Text = Microsoft.VisualBasic.Right(xml_ZemljaPr, 2) & Microsoft.VisualBasic.Left(xml_StanicaPr, 5)
        Me.tb17.Text = Me.tbStanicaOtp.Text
        Me.TextBox2.Text = Microsoft.VisualBasic.Right(xml_StanicaPr, 1)
        Me.Label13.Text = xml_NazivStanicePr

        Me.tb2.Text = xml_R2
        Me.tb1a.Text = xml_R1a
        Me.tb1b.Text = xml_R1b
        Me.tb1b1.Text = xml_R1c
        Me.tb1c.Text = xml_R1d

        Me.tb5.Text = xml_R5
        Me.tb4a.Text = xml_R4a
        Me.tb4b.Text = xml_R4b
        Me.tb4b1.Text = xml_R4c
        Me.tb4c.Text = xml_R4d

        Me.tb50.Text = xml_R50

        Me.rtb57a.Items.Clear()
        Me.rtb57b.Items.Clear()
        Me.rtb57b2.Items.Clear()
        Me.rtb57c.Items.Clear()

        Dim aa57 As Int16

        For aa57 = 1 To Len(RTrim(xml_R57a2)) Step 41
            Me.rtb57a.Items.Add(Microsoft.VisualBasic.Mid(xml_R57a2, aa57, 40))
        Next
        For aa57 = 1 To Len(RTrim(xml_R57b1a)) Step 48
            Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(xml_R57b1a, aa57, 46))
        Next
        For aa57 = 1 To Len(RTrim(xml_R57b2a)) Step 48
            Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(xml_R57b2a, aa57, 46))
        Next
        For aa57 = 1 To Me.rtb57a.Items.Count
            Me.rtb57c.Items.Add(1)
        Next

        Select Case xml_R57_izlaz
            Case "7211"
                mStanica2 = "1 - 23499 Subotica"
                tbCarinjenje.Text = "25046"
            Case "7260"
                mStanica2 = "2 - 22899 Kikinda"
                tbCarinjenje.Text = "24015"
            Case "7261"
                mStanica2 = "3 - 21099 Vrsac"
                tbCarinjenje.Text = "23035"
            Case "7220"
                mStanica2 = "4 - 12498 Dimitrovgrad"
                tbCarinjenje.Text = "13021"
            Case "7276"
                mStanica2 = "5 - 11028 Presevo"
                tbCarinjenje.Text = "15288"
            Case "7271"
                mStanica2 = "6 - 15723 Prijepolje Teretna"
                tbCarinjenje.Text = "14443"
            Case "7291"
                mStanica2 = "7 - 16319 Brasina"
                tbCarinjenje.Text = "42153"
            Case "7201"
                mStanica2 = "8 - 16517 Sid"
                tbCarinjenje.Text = "21083"
            Case "7202"
                mStanica2 = "10 - 25471 Bogojevo"
                tbCarinjenje.Text = "22292"
        End Select
        Me.cbSmer2.Text = mStanica2

        tb29a.Text = xml_R29a
        tb29b.Text = xml_R29b

        tb10a.Text = xml_R10a & " " & xml_R10b
        TextBox34.Text = xml_R10d
        tb12.Text = xml_R12

        tb52a.Text = xml_ZemljaOtp
        tb52b.Text = Microsoft.VisualBasic.Left(xml_StanicaOtp, 5)
        tb52c.Text = Microsoft.VisualBasic.Right(xml_StanicaOtp, 1)
        tb52d.Text = xml_OperaterOtp
        tb52e.Text = xml_BrojCimOtp

        Me.tb49a.Text = xml_R20a

        Daljinar()

        If xml_R20b = "EXW" Or xml_R20b = "FCA" Or xml_R20b = "CPT" Or _
           xml_R20b = "CIP" Or xml_R20b = "DAF" Or xml_R20b = "DDU" Or xml_R20b = "DDP" Then
            Me.cbFrankoPrevoznina.Checked = False
            Me.cbIncoterms.Checked = True
            Me.cbIncoterms.Enabled = True
            comboIncoterms.Enabled = True

            If xml_R20b = "EXW" Then
                comboIncoterms.SelectedIndex = 0
            ElseIf xml_R20b = "FCA" Then
                comboIncoterms.SelectedIndex = 1
            ElseIf xml_R20b = "CPT" Then
                comboIncoterms.SelectedIndex = 2
            ElseIf xml_R20b = "CIP" Then
                comboIncoterms.SelectedIndex = 3
            ElseIf xml_R20b = "DAF" Then
                comboIncoterms.SelectedIndex = 4
            ElseIf xml_R20b = "DDU" Then
                comboIncoterms.SelectedIndex = 5
            ElseIf xml_R20b = "DDP" Then
                comboIncoterms.SelectedIndex = 6
            End If

        Else
            Me.cbIncoterms.Checked = False
            Me.cbFrankoPrevoznina.Checked = True
        End If

        Me.tb49h.Text = xml_R20c
        Me.tb20f.Text = xml_R20d

        tb20a.Text = Microsoft.VisualBasic.Left(xml_R20f, 2)
        tb20b.Text = Microsoft.VisualBasic.Mid(xml_R20f, 3, 2)
        tb20c.Text = Microsoft.VisualBasic.Mid(xml_R20f, 5, 2)
        tb20d.Text = Microsoft.VisualBasic.Mid(xml_R20f, 7, 2)
        tb20e.Text = Microsoft.VisualBasic.Mid(xml_R20f, 9, 2)

        tb49b.Text = Microsoft.VisualBasic.Left(xml_R20f, 2)
        tb49c.Text = Microsoft.VisualBasic.Mid(xml_R20f, 3, 2)
        tb49d.Text = Microsoft.VisualBasic.Mid(xml_R20f, 5, 2)
        tb49e.Text = Microsoft.VisualBasic.Mid(xml_R20f, 7, 2)
        tb49f.Text = Microsoft.VisualBasic.Mid(xml_R20f, 9, 2)



        Kola_eValidating()
        eUskladiTipKola()

        If IzborSaobracaja = "4" Then
            mTarifa = "00"
        Else
            mTarifa = "36"
        End If
        'da bi dodelio tarifski razred pre izbora tarife
        eUskladiNhm()


    End Sub
    ''Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
    ''    Me.ComboBox5.Width = 25
    ''    Me.tb4b2.Text = Microsoft.VisualBasic.Left(Me.ComboBox5.Text, 2)
    ''    Me.btnUpis.Focus()
    ''End Sub

    ''Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
    ''    Me.ComboBox6.Width = 25
    ''    Me.tb1b2.Text = Microsoft.VisualBasic.Left(Me.ComboBox6.Text, 2)
    ''    Me.btnUpis.Focus()
    ''End Sub

    Private Sub ComboBox5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.GotFocus
        Me.ComboBox5.Width = 170
        Me.ComboBox5.DroppedDown = True

    End Sub

    Private Sub ComboBox6_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.GotFocus
        Me.ComboBox6.Width = 170
        Me.ComboBox6.DroppedDown = True
    End Sub
    'Private Sub ComboBox5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.Click
    '    Me.ComboBox5.Width = 25
    '    Me.tb4b2.Text = Microsoft.VisualBasic.Left(Me.ComboBox5.Text, 2)
    '    Me.btnUpis.Focus()
    'End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim RacunskiDeo As New RacunskiOdseci
        RacunskiDeo.ShowDialog()
    End Sub

    ''Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
    ''    Me.rtb57a.Items.Clear()
    ''    Me.rtb57b.Items.Clear()
    ''    Me.rtb57b2.Items.Clear()
    ''    Me.rtb57c.Items.Clear()

    ''    Me.cmbPrevPut.Items.Clear()
    ''    'Me.cmbPrevPut.SelectedIndex = -1
    ''    Me.cmbPrevPut.Focus()

    ''End Sub
    Private Sub r7_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r7.DoubleClick
        Me.r7.Items.Clear()

    End Sub
    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Dim helpUic As New HelpForm
        upit = "R13"
        helpUic.ShowDialog()
        Me.r13.Items.Add(mizlazObject)
        r13.Focus()
    End Sub
    Private Sub r9_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r9.DoubleClick
        Me.r9.Items.Clear()
    End Sub
    Private Sub r13_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r13.DoubleClick
        Me.r13.Items.Clear()
    End Sub

    Private Sub btnCarinarnica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarinarnica.Click
        Dim helpUic As New HelpForm
        helpUic.Text = "help carinarnice"
        upit = "CARINA"
        helpUic.ShowDialog()

        Me.tbCarinjenje.Text = mIzlaz1
        Me.lblCarinarnica.Text = mIzlaz2

        '''If IzborSaobracaja = "3" Then
        tb51a.Text = lblCarinarnica.Text
        tb51b.Text = "72"
        tb51c.Text = tbCarinjenje.Text

        '''End If
    End Sub
    Private Sub Panel2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.GotFocus
        'stepR57 = stepR57 + 1
        Me.lbR57.Visible = True
        Me.Button24.Visible = True
        Me.Button22.BackColor = System.Drawing.Color.PapayaWhip

        If mPanelFocus = 1 Then
            PopuniR57_x()

            '''''''''''''''''''''''''''''''''PanelFokus()

            PanelFokus2()

            ''Dim daPrevPut As SqlClient.SqlDataAdapter
            ''Dim dsPrevPut As New Data.DataSet
            ''Dim pomSifraPP As String
            ''Dim upit As String = ""
            ''Dim objComm As SqlClient.SqlCommand
            ''If DbVeza.State = ConnectionState.Closed Then
            ''    DbVeza.Open()
            ''End If
            '''---------------
            ''Dim ii As Int32 = 0

            ''cbR57.Items.Clear()
            ''dsPrevPut.Clear()
            ''upit = "SELECT SifraPrelaza, Naziv " _
            ''     & "FROM UicPrelazi " _
            ''     & "WHERE Uprava1 = '" & Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus, 2) & "' AND Uprava2 = '" & Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus + 2, 2) & "' AND LEFT(SifraPrelaza, 1) = '0'"
            ''Try
            ''    objComm = New SqlClient.SqlCommand(upit, DbVeza)
            ''    daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)
            ''    ii = daPrevPut.Fill(dsPrevPut)
            ''    For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
            ''        Me.cbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
            ''    Next

            ''Catch ex As Exception
            ''    MsgBox("Nema podataka!")
            ''Finally
            ''    DbVeza.Close()
            ''    mPanelFocus = mPanelFocus + 2 '797881
            ''    Me.cbR57.Focus()


            ''End Try

            ''Me.cbR57.Focus()
        End If
    End Sub

    Private Sub cmbPrevPut_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrevPut.Leave
        'Dim x1 As Int16 = 0
        'x_UicPP = ""
        'For x1 = 1 To Len(m_UicPrevozniPut) Step 4
        '    x_UicPP = x_UicPP & Microsoft.VisualBasic.Mid(m_UicPrevozniPut, x1, 2)
        'Next

        ''?? sto ne radi ? mPanelFocus = 1

    End Sub


    Private Sub Button22p_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22p.Click
        R57RedniBrojUprave = 0
        Me.lbR57.Visible = True
        Me.Button24.Visible = True

        mPanelFocus = 1
        str_R50 = ""
        stepR57 = 0

        rtb57a.Items.Clear()
        rtb57b.Items.Clear()
        rtb57b2.Items.Clear()
        rtb57c.Items.Clear()

        ListBox1.Items.Clear()
        ListBox1.Items.Clear()
        ListBox1.Items.Clear()
        ListBox1.Items.Clear()

        'Me.cbR57.Visible = True 3.3.2011
        PopuniR57_x()
        'PanelFokus() 3.3.2011
        PanelFokus2()
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        'kontrola
        'R57RedniBrojUprave = 0
        'stepR57 = 0

        Dim ii As Int16
        Dim x_check As Boolean = True

        Me.cbOperaterAdd.Visible = False
        Me.btnOperaterAdd.Visible = False

        For ii = 0 To Me.rtb57b.Items.Count - 1
            If Len(RTrim(Me.rtb57b.Items.Item(ii))) <> 6 Then
                MsgBox("Podaci u rubrici 57 nisu ispravni! Ponovite postupak")
                x_check = False
                Exit For
            End If
        Next

        For ii = 0 To Me.rtb57b2.Items.Count - 1
            If ii = Me.rtb57b2.Items.Count - 1 Then
                If Len(RTrim(Me.rtb57b2.Items.Item(ii))) <> 7 Then
                    MsgBox("Podaci u rubrici 57 nisu ispravni! Ponovite postupak")
                    x_check = False
                    Exit For
                End If
            Else
                If Len(RTrim(Me.rtb57b2.Items.Item(ii))) <> 6 Then
                    MsgBox("Podaci u rubrici 57 nisu ispravni! Ponovite postupak")
                    x_check = False
                    Exit For
                End If
            End If
        Next

        'If x_check = True Then
        '    If Microsoft.VisualBasic.Mid(Me.rtb57a.Items.Item(Me.rtb57a.Items.Count - 1), 3, 2) = Microsoft.VisualBasic.Left(Me.tbStanicaPr.Text, 2) Then
        '        x_check = True
        '    Else
        '        MsgBox("Podaci u rubrici 57 nisu ispravni! Ponovite postupak")
        '        x_check = False
        '    End If
        'End If


        'akcija
        If x_check = False Then
            Button22p_Click(Me, Nothing)
        Else
            For ii = 0 To Me.rtb57a.Items.Count - 1
                ListBox1.Items.Add(Me.rtb57a.Items.Item(ii))
                ListBox2.Items.Add(Me.rtb57b.Items.Item(ii))
                ListBox3.Items.Add(Me.rtb57b2.Items.Item(ii))
                ListBox4.Items.Add(Me.rtb57c.Items.Item(ii))
                'str_R50 = Microsoft.VisualBasic.Left(str_R50, Len(str_R50) - 3)
                'tb50.Text = Microsoft.VisualBasic.Left(str_R50, Len(str_R50) - 3)
            Next
            Panel2.Visible = False
            Me.tbsBrojVoza.Focus()

            'ako radi ŠID/BOGOJEVO FBXML
            If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "1" Or Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "8" And nmHzAdd = True Then
                Dim tmpHZ As String = ""
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "8" Then
                    tmpHZ = "780501"
                ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "9" Then
                    tmpHZ = "780502"
                End If

                If m_UicPrevozniPut = "78  79" Then
                    tb50.Text = "7801 SID - 7850 SAVSKI MAROF"
                ElseIf m_UicPrevozniPut = "78  79  83" Then
                    tb50.Text = "7801 SID - 7850 SAVSKI MAROF - 7910 SEZANA"
                ElseIf m_UicPrevozniPut = "78  79  81" Then
                    tb50.Text = "7801 SID - 7850 SAVSKI MAROF - 7940 JESENICE"
                ElseIf m_UicPrevozniPut = "78  50" Then
                    tb50.Text = "7801 SID - 7824 SAMAC"
                ElseIf m_UicPrevozniPut = "78  44" Then
                    tb50.Text = "7801 SID - 7824 SAMAC"
                End If

            Else
                For ii = 1 To R57RedniBrojUprave
                    tb50.Text = tb50.Text & NizR50(ii, 0) & " " & NizR50(ii, 1) & " - "
                Next
                tb50.Text = Microsoft.VisualBasic.Left(tb50.Text, Len(tb50.Text) - 3)
            End If

            R57RedniBrojUprave = 0
            mPanelFocus = 1 '????

        End If
        'R57RedniBrojUprave = 0

    End Sub
    Private Sub PanelFokus()
        Dim daPrevPut As SqlClient.SqlDataAdapter
        Dim dsPrevPut As New Data.DataSet
        Dim pomSifraPP As String
        Dim upit As String = ""
        Dim objComm As SqlClient.SqlCommand
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        '---------------
        Dim ii As Int32 = 0

        cbR57.Items.Clear()
        dsPrevPut.Clear()
        upit = "SELECT SifraPrelaza, Naziv " _
             & "FROM UicPrelazi " _
             & "WHERE Uprava1 = '" & Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus, 2) & "' AND Uprava2 = '" & Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus + 2, 2) & "' AND LEFT(SifraPrelaza, 1) = '0'"
        Try
            objComm = New SqlClient.SqlCommand(upit, DbVeza)
            daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)
            ii = daPrevPut.Fill(dsPrevPut)
            For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
                Me.cbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
            Next

        Catch ex As Exception
            MsgBox("Nema podataka!")
        Finally
            DbVeza.Close()
            mPanelFocus = mPanelFocus + 2 '797881
            Me.cbR57.Focus()
        End Try

        Me.cbR57.Focus()

    End Sub
    Private Sub PanelFokus2()
        Dim daPrevPut As SqlClient.SqlDataAdapter
        Dim dsPrevPut As New Data.DataSet
        Dim pomSifraPP As String
        Dim upit As String = ""
        Dim objComm As SqlClient.SqlCommand

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        '---------------
        Dim ii As Int32 = 0

        lbR57.Items.Clear()
        dsPrevPut.Clear()
        upit = "SELECT SifraPrelaza, Naziv " _
             & "FROM UicPrelazi " _
             & "WHERE Uprava1 = '" & Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus, 2) & "' AND Uprava2 = '" & Microsoft.VisualBasic.Mid(x_UicPP, mPanelFocus + 2, 2) & "' AND LEFT(SifraPrelaza, 1) = '0'"
        Try
            objComm = New SqlClient.SqlCommand(upit, DbVeza)
            daPrevPut = New SqlClient.SqlDataAdapter(upit, DbVeza)

            ii = daPrevPut.Fill(dsPrevPut)

            For kk As Int16 = 0 To dsPrevPut.Tables(0).Rows.Count - 1
                Me.lbR57.Items.Add(dsPrevPut.Tables(0).Rows(kk).Item("SifraPrelaza") & " " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv"))
            Next

        Catch ex As Exception
            MsgBox("Nema podataka!")
        Finally
            DbVeza.Close()
            mPanelFocus = mPanelFocus + 2 '797881
            If ii = 0 Then
                If Me.rtb57b2.Items.Count < Me.rtb57b.Items.Count Then
                    Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text)
                End If
                '''Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text)

                Me.lbR57.Visible = False
                Me.Button24.Visible = False

                Me.Button22.BackColor = System.Drawing.Color.DarkSeaGreen
                Me.Button22.Focus()

            Else
                Me.lbR57.Focus()
            End If

        End Try

        ''''''''''''Me.lbR57.Focus()

    End Sub
    Private Sub tbPrevoznina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrevoznina.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbPrevoznina_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPrevoznina.LostFocus
        mDinaraPoTL = CDec(tbPrevoznina.Text)
        tbPrevoznina.Text = Format(mDinaraPoTL, "###,###,##0.00")

    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        mPanelFocus = 1
        str_R50 = ""
        stepR57 = 0

        If rtb57a.Items.Count > 0 Then
            rtb57a.Items.Clear()
            rtb57b.Items.Clear()
            rtb57b2.Items.Clear()
            rtb57c.Items.Clear()

            ListBox1.Items.Clear()
            ListBox1.Items.Clear()
            ListBox1.Items.Clear()
            ListBox1.Items.Clear()
        End If

        Me.Panel2.Visible = False

        '''Me.cbR57.Visible = True
        '''PopuniR57_x()
        '''PanelFokus()
        '-----------
        Me.cmbPrevPut.Focus()
    End Sub


    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        R57RedniBrojUprave = R57RedniBrojUprave + 1

        'MsgBox(Me.lbR57.SelectedItem)
        'MsgBox(Microsoft.VisualBasic.Left(Me.rtb57a.Items(R57RedniBrojUprave - 1), 4) & " " & Me.rtb57a.Items.Count() & "  -" & mPanelFocus)
        Try
            If R57RedniBrojUprave - 1 = 0 Then
                If Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "1" Then
                    Me.rtb57b.Items.Add("550711")
                ElseIf Microsoft.VisualBasic.Left(cbSmer2.Text, 1) = "8" Then
                    Me.rtb57b.Items.Add("780501")
                End If
                Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(Me.rtb57a.Items(R57RedniBrojUprave - 1), 3, 2) & Microsoft.VisualBasic.Left(Me.lbR57.SelectedItem, 4))
                Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(Me.rtb57a.Items(R57RedniBrojUprave), 3, 2) & Microsoft.VisualBasic.Left(Me.lbR57.SelectedItem, 4))

                'ElseIf R57RedniBrojUprave - 1 = Me.rtb57a.Items.Count() Then
                ''    Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text)
            Else
                Me.rtb57b2.Items.Add(Microsoft.VisualBasic.Mid(Me.rtb57a.Items(R57RedniBrojUprave - 1), 3, 2) & Microsoft.VisualBasic.Left(Me.lbR57.SelectedItem, 4))
                Me.rtb57b.Items.Add(Microsoft.VisualBasic.Mid(Me.rtb57a.Items(R57RedniBrojUprave), 3, 2) & Microsoft.VisualBasic.Left(Me.lbR57.SelectedItem, 4))

                If R57RedniBrojUprave + 1 = Me.rtb57a.Items.Count() Then
                    If Me.rtb57b2.Items.Count < Me.rtb57b.Items.Count Then
                        Me.rtb57b2.Items.Add(Me.tbStanicaPr.Text)
                    End If

                    Me.lbR57.Visible = False
                    Me.Button24.Visible = False

                    'Me.Button22.BackColor = System.Drawing.Color.PapayaWhip 
                    Me.Button22.BackColor = System.Drawing.Color.DarkSeaGreen
                    Me.Button22.Focus()
                End If
            End If

            '=========================================================================
            Dim str_R50_x As String

            '''''''stepR57 = stepR57 + 1

            str_R50_x = Microsoft.VisualBasic.Mid(Me.rtb57a.Items.Item(R57RedniBrojUprave - 1), 3, 2)
            str_R50 = str_R50 & str_R50_x & Microsoft.VisualBasic.Mid(RTrim(cbR57.Text), 3, Len(cbR57.Text)) & " - "

            '--------------------------------------------------------------------------------------------
            NizR50(R57RedniBrojUprave, 0) = str_R50_x & Microsoft.VisualBasic.Mid(lbR57.Text, 3, 2)
            NizR50(R57RedniBrojUprave, 1) = RTrim(Microsoft.VisualBasic.Right(lbR57.Text, Len(lbR57.Text) - 5))

            '=========================================================================


            PanelFokus2()

        Catch ex As Exception
            MessageBox.Show("Neispravan izbor, ponovite postupak!", "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub lbR57_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbR57.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Len(Me.lbR57.SelectedItem) = 0 Then
                ErrorProvider1.SetError(lbR57, "Niste izabrali granicni prelaz!")
                Me.lbR57.Focus()
            Else
                ErrorProvider1.SetError(lbR57, "")
                Button24_Click(Me, Nothing)
            End If
        End If

    End Sub

    Private Sub tbBrojPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbBrojPr.Validating
        Dim tmp_kbpr As String
        Dim tmp_brojpr As String

        tmp_brojpr = tbBrojPr.Text.ToString
        b5Modul(tmp_brojpr, tmp_kbpr)
        kbBrojPr.Text = tmp_kbpr
    End Sub


    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Dim mRetVal As String
        Dim mRecID As Int32
        Dim mStanicaRecID As String
        Dim strOtpBroj As String = CType(tbBrojOtp.Text, String) & CType(kbBrojOtp.Text, String)
        mRanzirna = ""
        mRealizovan = ""

        '---------------------------
        Dim izPrUprava As String
        Dim izPrStanica As String
        Dim izPrDatum As Date
        Dim izSaobracaj As String
        Dim izZsPrelaz As String
        Dim izZsUlPrelaz As String
        Dim izZsIzPrelaz As String
        Dim izNalepnica As Int32
        Dim izNajava As String
        Dim izNajava2 As String
        Dim izSifraTarife As String
        Dim izUgovor As String
        Dim mDatum As Date
        '---------------------------

        mOtpDatum = Me.DatumOtp.Value.ToShortDateString

        mMesec = mOtpDatum.Month.ToString
        mDan = mOtpDatum.Day.ToString
        mGodina = mOtpDatum.Year.ToString

        '---------------------------------------------------------------
        If IzborSaobracaja = "3" Then   'izvoz ŽS
            'mGodina: traži u tekucoj godini

            NadjiTL1(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), mGodina, mRecID, mStanicaRecID, mOtpDatum, mRanzirna, mRealizovan, mRetVal)

            If mRetVal <> "" Then '------------ našao!
                If mRealizovan = "99999" Then 'pr. subotica
                    ' zašto je ovo trebalo? mOtpDatum = Me.DatumOtp.Value.ToShortDateString
                    MessageBox.Show("Ovaj tovarni list je obradjen! Promenite podatke o posiljci.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.tbBrojOtp.Focus()
                Else 'pr. mladenovac/pancevo/bg ranžirna
                    Dim aa As String = Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)
                    Dim aa2 As String = mStanicaRecID

                    If Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) <> mStanicaRecID Then

                        'MessageBox.Show("Ovaj dokument je unet u stanici " & RTrim(Label12.Text), "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Me.Close()

                        mRetVal = ""
                        Util.eNadjiTovarniListUI(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), mOtpDatum, mRecID, mStanicaRecID, _
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

                            '* * * * * * * * * * * * * * * * * 
                            Dim form2 As New FormUpdateCimGr
                            form2.ShowDialog()
                            '* * * * * * * * * * * * * * * * * 

                            'Close()

                        Else
                            MessageBox.Show("Ne postoji mogucnost prikaza podataka!" & mRetVal, "Poruka iz baze: 5284", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else

                        MessageBox.Show("Ovaj dokument je unet u stanici " & RTrim(Label12.Text) & ". Promenite broj tovarnog lista.", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        tbStanicaOtp.Focus() 'BrojOtp.Focus()

                    End If
                End If
            Else                 '------------ nije našao!

                mDatumKalk = DatumOtp.Value
                mOtpDatum = DatumOtp.Text
                Me.tb52a.Text = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2)
                Me.tb52b.Text = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5)
                Me.tb52c.Text = Me.TextBox1.Text
                Me.tb52d.Text = Me.tbUpravaOtp.Text
                Me.tb52e.Text = Me.tbBrojOtp.Text & Me.kbBrojOtp.Text

                Me.tb29b.Text = Me.DatumOtp.Value.Year.ToString + "-" + Me.DatumOtp.Value.Month.ToString + "-" + Me.DatumOtp.Value.Day.ToString
                Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString
                Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString

                Me.tb16c.Text = Me.DatumOtp.Value.Month.ToString
                Me.tb16d.Text = Me.DatumOtp.Value.Day.ToString
                Me.tb16e.Text = Me.DatumOtp.Value.Hour.ToString

                If Len(Me.tb29b_1.Text) = 1 Then
                    Me.tb29b_1.Text = "0" & Me.DatumOtp.Value.Day.ToString + "."
                Else
                    Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString + "."
                End If
                If Len(Me.tb29b_2.Text) = 1 Then
                    Me.tb29b_2.Text = "0" & Me.DatumOtp.Value.Month.ToString + "."
                Else
                    Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString + "."
                End If
                Me.tb29b_3.Text = Me.DatumOtp.Value.Year.ToString

                Me.tbUpravaPr.Focus()

            End If

        Else 'Tranzit/Uvoz

            NadjiTL1TU(tbUpravaOtp.Text, tbStanicaOtp.Text, CType(strOtpBroj, Int32), mOtpDatum, mRecID, mStanicaRecID, mRetVal)

            If mRetVal <> "" Then '------------ našao!
                If RecordAction = "N" And UpdUprava = tbUpravaOtp.Text And UpdStanica = tbStanicaOtp.Text And UpdBroj = tbBrojOtp.Text And UpdDatum = mOtpDatum Then
                    tbUpravaPr.Focus()
                Else
                    nmAllowExit = True
                    MessageBox.Show("Takav broj otpravljanja je vec unet! ", "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If eRazmena = "Da" Then
                        Close()
                    End If
                    tbBrojOtp.Focus()
                End If
            Else                  '------------ nije našao!
                mDatumKalk = DatumOtp.Value
                mOtpDatum = DatumOtp.Text
                Me.tb52a.Text = Microsoft.VisualBasic.Left(Me.tbStanicaOtp.Text, 2)
                Me.tb52b.Text = Microsoft.VisualBasic.Right(Me.tbStanicaOtp.Text, 5)
                Me.tb52c.Text = Me.TextBox1.Text
                Me.tb52d.Text = Me.tbUpravaOtp.Text
                Me.tb52e.Text = Me.tbBrojOtp.Text & Me.kbBrojOtp.Text

                Me.tb29b.Text = Me.DatumOtp.Value.Year.ToString + "-" + Me.DatumOtp.Value.Month.ToString + "-" + Me.DatumOtp.Value.Day.ToString
                Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString
                Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString

                Me.tb16c.Text = Me.DatumOtp.Value.Month.ToString
                Me.tb16d.Text = Me.DatumOtp.Value.Day.ToString

                If Len(Me.tb29b_1.Text) = 1 Then
                    Me.tb29b_1.Text = "0" & Me.DatumOtp.Value.Day.ToString + "."
                Else
                    Me.tb29b_1.Text = Me.DatumOtp.Value.Day.ToString + "."
                End If
                If Len(Me.tb29b_2.Text) = 1 Then
                    Me.tb29b_2.Text = "0" & Me.DatumOtp.Value.Month.ToString + "."
                Else
                    Me.tb29b_2.Text = Me.DatumOtp.Value.Month.ToString + "."
                End If
                Me.tb29b_3.Text = Me.DatumOtp.Value.Year.ToString

                If IzborSaobracaja = "2" Then
                    If GranicnaStanica = "D" Then
                        If eRazmena = "Da" Then
                            Me.tbStanicaPr.Focus()
                        Else
                            Me.tbStanicaPr.Focus()
                            Me.tbStanicaPr.Text = "72"
                            Me.tbStanicaPr.SelectionStart = 3
                        End If
                    Else
                        If eRazmena = "Da" Then
                        Else
                            Me.tbStanicaPr.Text = "72" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5)
                            Me.tbStanicaPr.Focus()
                        End If

                    End If
                Else
                    Me.tbUpravaPr.Focus()
                End If

            End If
        End If

    End Sub

    Private Sub tbPrevoznina_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbPrevoznina.Validating
        btnUpis.Focus()

    End Sub
    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        'MsgBox(Me.rtb57b.SelectedIndex())
        'MsgBox(Me.rtb57b.SelectedItem)



    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click

        Me.cbOperaterAdd.Visible = True
        Me.btnOperaterAdd.Visible = True

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        cbOperaterAdd.Items.Clear()
        Dim sql_textAdd As String = "SELECT SifraOperatera, Oznaka FROM UicOperateri WHERE (SifraOperatera <> '0000') "

        Dim sql_commAdd As New SqlClient.SqlCommand(sql_textAdd, DbVeza)
        Dim rdrTrzAdd As SqlClient.SqlDataReader

        rdrTrzAdd = sql_commAdd.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrTrzAdd.Read()
            cbOperaterAdd.Items.Add(rdrTrzAdd.GetString(0) & " - " & rdrTrzAdd.GetString(1))
        Loop
        rdrTrzAdd.Close()
        DbVeza.Close()

    End Sub
    Private Sub rtb57a_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtb57a.Click
        Label31.Text = rtb57a.SelectedItem
        Label34.Text = rtb57a.SelectedIndex.ToString
    End Sub

    Private Sub btnOperaterAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOperaterAdd.Click
        Try
            rtb57a.Items.Item(CInt(Me.Label34.Text)) = RTrim(Me.cbOperaterAdd.Text)
        Catch ex As Exception
            MessageBox.Show("Niste izabrali operatera u rubrici 57", "Poruka iz baze: 2265", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnOperaterAdd.Focus()
        End Try
    End Sub

    Private Sub CheckBox8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox8.Click
        mCarPost = "N"
        If CheckBox8.Checked Then
            mCarPost = "D"
        End If
    End Sub

    Private Sub CheckBox8_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CheckBox8.Validating
        mCarPost = "N"
        If CheckBox8.Checked Then
            mCarPost = "D"
        End If
    End Sub
End Class
