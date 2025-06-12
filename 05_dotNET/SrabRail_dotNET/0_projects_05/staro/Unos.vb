Public Class Unos
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents tbBrojOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbUpravaOtp As System.Windows.Forms.TextBox
    Friend WithEvents cbTarifa As System.Windows.Forms.ComboBox
    Friend WithEvents btnUicUprave As System.Windows.Forms.Button
    Friend WithEvents btnKalkulacija As System.Windows.Forms.Button
    Friend WithEvents btnUpravaOtp As System.Windows.Forms.Button
    Friend WithEvents btnStanicaOtp As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStanicaPr As System.Windows.Forms.Button
    Friend WithEvents tbBrojPr As System.Windows.Forms.TextBox
    Friend WithEvents tbStanicaPr As System.Windows.Forms.TextBox
    Friend WithEvents tbUpravaPr As System.Windows.Forms.TextBox
    Friend WithEvents btnUpravaPr As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbUicPrevozniPut As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIzborTarife As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbVrstaSaobracaja As System.Windows.Forms.ComboBox
    Friend WithEvents tbPosiljalac As System.Windows.Forms.TextBox
    Friend WithEvents tbPrimalac As System.Windows.Forms.TextBox
    Friend WithEvents tbPrekoStanice As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents tbUgovor As System.Windows.Forms.TextBox
    Friend WithEvents btnPosiljalac As System.Windows.Forms.Button
    Friend WithEvents btPrimalac As System.Windows.Forms.Button
    Friend WithEvents btnBrojUgovora As System.Windows.Forms.Button
    Friend WithEvents cbZsPrevozniPut As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cbZsPrelaz1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbUlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbZsPrelaz2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbIzlaznaNalepnica As System.Windows.Forms.TextBox
    Friend WithEvents cbUicGlobalniStav As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrekoStanice As System.Windows.Forms.Button
    Friend WithEvents btnUnosRobe As System.Windows.Forms.Button
    Friend WithEvents btnGlobalniStav As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem41 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem43 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem44 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem45 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem46 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem47 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem48 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem49 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem50 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem35 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem36 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem38 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Friend WithEvents cbVrstaPoUgovoru As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rbVoz As System.Windows.Forms.RadioButton
    Friend WithEvents rbGrupa As System.Windows.Forms.RadioButton
    Friend WithEvents rbPojedinacna As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzjava As System.Windows.Forms.Button
    Friend WithEvents tbFrankoDoIznosa As System.Windows.Forms.TextBox
    Friend WithEvents tbFrankoPrelaz As System.Windows.Forms.TextBox
    Friend WithEvents tbFrankoNaknada4 As System.Windows.Forms.TextBox
    Friend WithEvents tbFrankoNaknada3 As System.Windows.Forms.TextBox
    Friend WithEvents tbFrankoNaknada2 As System.Windows.Forms.TextBox
    Friend WithEvents rbUpuceno As System.Windows.Forms.RadioButton
    Friend WithEvents rbFrankoTroskovi As System.Windows.Forms.RadioButton
    Friend WithEvents rbFrankoDoIznosa As System.Windows.Forms.RadioButton
    Friend WithEvents rbFrankoPrevoznina As System.Windows.Forms.RadioButton
    Friend WithEvents tbFrankoNaknada1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnNajava As System.Windows.Forms.Button
    Friend WithEvents tbNajava As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Unos))
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.cbTarifa = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnNajava = New System.Windows.Forms.Button
        Me.tbNajava = New System.Windows.Forms.TextBox
        Me.btnBrojUgovora = New System.Windows.Forms.Button
        Me.btPrimalac = New System.Windows.Forms.Button
        Me.btnPosiljalac = New System.Windows.Forms.Button
        Me.tbUgovor = New System.Windows.Forms.TextBox
        Me.tbPrimalac = New System.Windows.Forms.TextBox
        Me.tbPosiljalac = New System.Windows.Forms.TextBox
        Me.cbVrstaSaobracaja = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblIzborTarife = New System.Windows.Forms.Label
        Me.btnUicUprave = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.btnKalkulacija = New System.Windows.Forms.Button
        Me.ComboBox5 = New System.Windows.Forms.ComboBox
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
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnGlobalniStav = New System.Windows.Forms.Button
        Me.cbUicGlobalniStav = New System.Windows.Forms.ComboBox
        Me.btnPrekoStanice = New System.Windows.Forms.Button
        Me.tbPrekoStanice = New System.Windows.Forms.TextBox
        Me.cbZsPrevozniPut = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbUicPrevozniPut = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.cbVrstaPoUgovoru = New System.Windows.Forms.GroupBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.rbVoz = New System.Windows.Forms.RadioButton
        Me.rbGrupa = New System.Windows.Forms.RadioButton
        Me.rbPojedinacna = New System.Windows.Forms.RadioButton
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnUnosRobe = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.tbIzlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbZsPrelaz2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbUlaznaNalepnica = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbZsPrelaz1 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.MenuItem41 = New System.Windows.Forms.MenuItem
        Me.MenuItem43 = New System.Windows.Forms.MenuItem
        Me.MenuItem44 = New System.Windows.Forms.MenuItem
        Me.MenuItem45 = New System.Windows.Forms.MenuItem
        Me.MenuItem46 = New System.Windows.Forms.MenuItem
        Me.MenuItem47 = New System.Windows.Forms.MenuItem
        Me.MenuItem48 = New System.Windows.Forms.MenuItem
        Me.MenuItem49 = New System.Windows.Forms.MenuItem
        Me.MenuItem50 = New System.Windows.Forms.MenuItem
        Me.MenuItem42 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.MenuItem32 = New System.Windows.Forms.MenuItem
        Me.MenuItem33 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.MenuItem34 = New System.Windows.Forms.MenuItem
        Me.MenuItem35 = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem36 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem40 = New System.Windows.Forms.MenuItem
        Me.MenuItem38 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.MenuItem37 = New System.Windows.Forms.MenuItem
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnIzjava = New System.Windows.Forms.Button
        Me.tbFrankoDoIznosa = New System.Windows.Forms.TextBox
        Me.tbFrankoPrelaz = New System.Windows.Forms.TextBox
        Me.tbFrankoNaknada4 = New System.Windows.Forms.TextBox
        Me.tbFrankoNaknada3 = New System.Windows.Forms.TextBox
        Me.tbFrankoNaknada2 = New System.Windows.Forms.TextBox
        Me.rbUpuceno = New System.Windows.Forms.RadioButton
        Me.rbFrankoTroskovi = New System.Windows.Forms.RadioButton
        Me.rbFrankoDoIznosa = New System.Windows.Forms.RadioButton
        Me.rbFrankoPrevoznina = New System.Windows.Forms.RadioButton
        Me.tbFrankoNaknada1 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.cbVrstaPoUgovoru.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 192)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [ OTPRAVLJANJE ] "
        '
        'Label18
        '
        Me.Label18.Enabled = False
        Me.Label18.Location = New System.Drawing.Point(32, 152)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 23)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "Datum"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Location = New System.Drawing.Point(40, 120)
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
        Me.Label12.Location = New System.Drawing.Point(106, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 15)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Munchen"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(106, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 15)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "DB"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnStanicaOtp
        '
        Me.btnStanicaOtp.Location = New System.Drawing.Point(16, 70)
        Me.btnStanicaOtp.Name = "btnStanicaOtp"
        Me.btnStanicaOtp.Size = New System.Drawing.Size(75, 21)
        Me.btnStanicaOtp.TabIndex = 33
        Me.btnStanicaOtp.Text = "Stanica"
        '
        'tbBrojOtp
        '
        Me.tbBrojOtp.Location = New System.Drawing.Point(109, 120)
        Me.tbBrojOtp.Name = "tbBrojOtp"
        Me.tbBrojOtp.TabIndex = 2
        Me.tbBrojOtp.Text = ""
        '
        'tbStanicaOtp
        '
        Me.tbStanicaOtp.Location = New System.Drawing.Point(109, 70)
        Me.tbStanicaOtp.Name = "tbStanicaOtp"
        Me.tbStanicaOtp.TabIndex = 1
        Me.tbStanicaOtp.Text = ""
        '
        'tbUpravaOtp
        '
        Me.tbUpravaOtp.Location = New System.Drawing.Point(109, 24)
        Me.tbUpravaOtp.Name = "tbUpravaOtp"
        Me.tbUpravaOtp.TabIndex = 0
        Me.tbUpravaOtp.Text = ""
        '
        'btnUpravaOtp
        '
        Me.btnUpravaOtp.Location = New System.Drawing.Point(16, 24)
        Me.btnUpravaOtp.Name = "btnUpravaOtp"
        Me.btnUpravaOtp.Size = New System.Drawing.Size(75, 21)
        Me.btnUpravaOtp.TabIndex = 2
        Me.btnUpravaOtp.Text = "Uprava"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker1.Location = New System.Drawing.Point(109, 157)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(100, 21)
        Me.DateTimePicker1.TabIndex = 3
        '
        'cbTarifa
        '
        Me.cbTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTarifa.Items.AddRange(New Object() {"1. SPT 36 Redovna tarifa", "2. UIC 9291 TEA tarifa", "3. Ugovor"})
        Me.cbTarifa.Location = New System.Drawing.Point(143, 18)
        Me.cbTarifa.Name = "cbTarifa"
        Me.cbTarifa.Size = New System.Drawing.Size(192, 23)
        Me.cbTarifa.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(22, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 23)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Vrsta pošiljke"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnNajava)
        Me.GroupBox3.Controls.Add(Me.tbNajava)
        Me.GroupBox3.Controls.Add(Me.btnBrojUgovora)
        Me.GroupBox3.Controls.Add(Me.btPrimalac)
        Me.GroupBox3.Controls.Add(Me.btnPosiljalac)
        Me.GroupBox3.Controls.Add(Me.tbUgovor)
        Me.GroupBox3.Controls.Add(Me.tbPrimalac)
        Me.GroupBox3.Controls.Add(Me.tbPosiljalac)
        Me.GroupBox3.Controls.Add(Me.cbVrstaSaobracaja)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.lblIzborTarife)
        Me.GroupBox3.Controls.Add(Me.cbTarifa)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(496, 152)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(376, 240)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " [ IZBOR TARIFE ] "
        '
        'btnNajava
        '
        Me.btnNajava.Enabled = False
        Me.btnNajava.Location = New System.Drawing.Point(16, 85)
        Me.btnNajava.Name = "btnNajava"
        Me.btnNajava.Size = New System.Drawing.Size(80, 24)
        Me.btnNajava.TabIndex = 46
        Me.btnNajava.Text = "Najava"
        '
        'tbNajava
        '
        Me.tbNajava.Enabled = False
        Me.tbNajava.Location = New System.Drawing.Point(144, 85)
        Me.tbNajava.Name = "tbNajava"
        Me.tbNajava.Size = New System.Drawing.Size(192, 21)
        Me.tbNajava.TabIndex = 2
        Me.tbNajava.Text = ""
        '
        'btnBrojUgovora
        '
        Me.btnBrojUgovora.Enabled = False
        Me.btnBrojUgovora.Location = New System.Drawing.Point(16, 52)
        Me.btnBrojUgovora.Name = "btnBrojUgovora"
        Me.btnBrojUgovora.Size = New System.Drawing.Size(80, 24)
        Me.btnBrojUgovora.TabIndex = 44
        Me.btnBrojUgovora.Text = "Ugovor"
        '
        'btPrimalac
        '
        Me.btPrimalac.Location = New System.Drawing.Point(16, 170)
        Me.btPrimalac.Name = "btPrimalac"
        Me.btPrimalac.Size = New System.Drawing.Size(80, 24)
        Me.btPrimalac.TabIndex = 43
        Me.btPrimalac.Text = "Primalac"
        '
        'btnPosiljalac
        '
        Me.btnPosiljalac.Location = New System.Drawing.Point(16, 138)
        Me.btnPosiljalac.Name = "btnPosiljalac"
        Me.btnPosiljalac.Size = New System.Drawing.Size(80, 24)
        Me.btnPosiljalac.TabIndex = 42
        Me.btnPosiljalac.Text = "Pošiljalac"
        '
        'tbUgovor
        '
        Me.tbUgovor.Enabled = False
        Me.tbUgovor.Location = New System.Drawing.Point(144, 52)
        Me.tbUgovor.Name = "tbUgovor"
        Me.tbUgovor.Size = New System.Drawing.Size(192, 21)
        Me.tbUgovor.TabIndex = 1
        Me.tbUgovor.Text = ""
        '
        'tbPrimalac
        '
        Me.tbPrimalac.Location = New System.Drawing.Point(144, 170)
        Me.tbPrimalac.Name = "tbPrimalac"
        Me.tbPrimalac.Size = New System.Drawing.Size(88, 21)
        Me.tbPrimalac.TabIndex = 4
        Me.tbPrimalac.Text = ""
        '
        'tbPosiljalac
        '
        Me.tbPosiljalac.Location = New System.Drawing.Point(144, 138)
        Me.tbPosiljalac.Name = "tbPosiljalac"
        Me.tbPosiljalac.Size = New System.Drawing.Size(88, 21)
        Me.tbPosiljalac.TabIndex = 3
        Me.tbPosiljalac.Text = ""
        '
        'cbVrstaSaobracaja
        '
        Me.cbVrstaSaobracaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVrstaSaobracaja.Items.AddRange(New Object() {"2. Uvoz", "4. Suvozemni tranzit", "5. Lucki tranzit (OtpUpr-Luka)", "6. Lucki tranzit (Luka-OtpUpr)", "7. Tranzit drum-zeleznica", "8. Tranzit zeleznica-drum"})
        Me.cbVrstaSaobracaja.Location = New System.Drawing.Point(144, 200)
        Me.cbVrstaSaobracaja.Name = "cbVrstaSaobracaja"
        Me.cbVrstaSaobracaja.Size = New System.Drawing.Size(192, 23)
        Me.cbVrstaSaobracaja.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 23)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Vrsta saobraæaja"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblIzborTarife
        '
        Me.lblIzborTarife.Location = New System.Drawing.Point(16, 18)
        Me.lblIzborTarife.Name = "lblIzborTarife"
        Me.lblIzborTarife.Size = New System.Drawing.Size(70, 23)
        Me.lblIzborTarife.TabIndex = 13
        Me.lblIzborTarife.Text = "Izbor tarife"
        Me.lblIzborTarife.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnUicUprave
        '
        Me.btnUicUprave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnUicUprave.Location = New System.Drawing.Point(10, 610)
        Me.btnUicUprave.Name = "btnUicUprave"
        Me.btnUicUprave.Size = New System.Drawing.Size(96, 48)
        Me.btnUicUprave.TabIndex = 0
        Me.btnUicUprave.Text = "Strane uprave"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 673)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(880, 8)
        Me.StatusBar1.TabIndex = 23
        Me.StatusBar1.Text = "Unos dokumenta"
        '
        'btnKalkulacija
        '
        Me.btnKalkulacija.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnKalkulacija.Location = New System.Drawing.Point(299, 610)
        Me.btnKalkulacija.Name = "btnKalkulacija"
        Me.btnKalkulacija.Size = New System.Drawing.Size(94, 48)
        Me.btnKalkulacija.TabIndex = 7
        Me.btnKalkulacija.Text = "Kalkulacija"
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.Items.AddRange(New Object() {"1. Kolska pošiljka", "2. Denèana pošiljka", "3. Ekspresna pošiljka"})
        Me.ComboBox5.Location = New System.Drawing.Point(144, 23)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(224, 23)
        Me.ComboBox5.TabIndex = 0
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
        Me.GroupBox5.Location = New System.Drawing.Point(256, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(232, 192)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = " [ PRISPEÆE ] "
        '
        'Label17
        '
        Me.Label17.Enabled = False
        Me.Label17.Location = New System.Drawing.Point(34, 148)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 23)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "Datum"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label15
        '
        Me.Label15.Enabled = False
        Me.Label15.Location = New System.Drawing.Point(40, 116)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 23)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Broj"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(109, 154)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(100, 21)
        Me.DateTimePicker2.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(107, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 15)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Beograd"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(107, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 15)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "ŽS"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnStanicaPr
        '
        Me.btnStanicaPr.Location = New System.Drawing.Point(16, 70)
        Me.btnStanicaPr.Name = "btnStanicaPr"
        Me.btnStanicaPr.Size = New System.Drawing.Size(75, 21)
        Me.btnStanicaPr.TabIndex = 33
        Me.btnStanicaPr.Text = "Stanica"
        '
        'tbBrojPr
        '
        Me.tbBrojPr.Location = New System.Drawing.Point(109, 120)
        Me.tbBrojPr.Name = "tbBrojPr"
        Me.tbBrojPr.TabIndex = 2
        Me.tbBrojPr.Text = ""
        '
        'tbStanicaPr
        '
        Me.tbStanicaPr.Location = New System.Drawing.Point(109, 70)
        Me.tbStanicaPr.Name = "tbStanicaPr"
        Me.tbStanicaPr.TabIndex = 1
        Me.tbStanicaPr.Text = ""
        '
        'tbUpravaPr
        '
        Me.tbUpravaPr.Location = New System.Drawing.Point(109, 24)
        Me.tbUpravaPr.Name = "tbUpravaPr"
        Me.tbUpravaPr.TabIndex = 0
        Me.tbUpravaPr.Text = ""
        '
        'btnUpravaPr
        '
        Me.btnUpravaPr.Location = New System.Drawing.Point(16, 24)
        Me.btnUpravaPr.Name = "btnUpravaPr"
        Me.btnUpravaPr.Size = New System.Drawing.Size(75, 21)
        Me.btnUpravaPr.TabIndex = 32
        Me.btnUpravaPr.Text = "Uprava"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.btnGlobalniStav)
        Me.GroupBox2.Controls.Add(Me.cbUicGlobalniStav)
        Me.GroupBox2.Controls.Add(Me.btnPrekoStanice)
        Me.GroupBox2.Controls.Add(Me.tbPrekoStanice)
        Me.GroupBox2.Controls.Add(Me.cbZsPrevozniPut)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbUicPrevozniPut)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 393)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(480, 207)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " [ PREVOZNI PUT ]"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.Location = New System.Drawing.Point(323, 168)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 20)
        Me.Button2.TabIndex = 44
        Me.Button2.Text = "..."
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(232, 167)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(73, 21)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.Text = ""
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(152, 167)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(73, 21)
        Me.TextBox3.TabIndex = 4
        Me.TextBox3.Text = ""
        '
        'Label10
        '
        Me.Label10.Enabled = False
        Me.Label10.Location = New System.Drawing.Point(40, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 22)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Kilometri"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(323, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 20)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "..."
        '
        'btnGlobalniStav
        '
        Me.btnGlobalniStav.Enabled = False
        Me.btnGlobalniStav.Location = New System.Drawing.Point(16, 55)
        Me.btnGlobalniStav.Name = "btnGlobalniStav"
        Me.btnGlobalniStav.Size = New System.Drawing.Size(96, 24)
        Me.btnGlobalniStav.TabIndex = 39
        Me.btnGlobalniStav.Text = "Globalni stav"
        '
        'cbUicGlobalniStav
        '
        Me.cbUicGlobalniStav.Enabled = False
        Me.cbUicGlobalniStav.Location = New System.Drawing.Point(152, 55)
        Me.cbUicGlobalniStav.Name = "cbUicGlobalniStav"
        Me.cbUicGlobalniStav.Size = New System.Drawing.Size(152, 23)
        Me.cbUicGlobalniStav.TabIndex = 1
        '
        'btnPrekoStanice
        '
        Me.btnPrekoStanice.Enabled = False
        Me.btnPrekoStanice.Location = New System.Drawing.Point(16, 128)
        Me.btnPrekoStanice.Name = "btnPrekoStanice"
        Me.btnPrekoStanice.Size = New System.Drawing.Size(96, 24)
        Me.btnPrekoStanice.TabIndex = 36
        Me.btnPrekoStanice.Text = "Preko stanice"
        '
        'tbPrekoStanice
        '
        Me.tbPrekoStanice.Enabled = False
        Me.tbPrekoStanice.Location = New System.Drawing.Point(152, 130)
        Me.tbPrekoStanice.Name = "tbPrekoStanice"
        Me.tbPrekoStanice.Size = New System.Drawing.Size(73, 21)
        Me.tbPrekoStanice.TabIndex = 3
        Me.tbPrekoStanice.Text = ""
        '
        'cbZsPrevozniPut
        '
        Me.cbZsPrevozniPut.Items.AddRange(New Object() {"Redovan", "Vanredan", "Lomljen redovan", "Lomljen vanredan"})
        Me.cbZsPrevozniPut.Location = New System.Drawing.Point(152, 92)
        Me.cbZsPrevozniPut.Name = "cbZsPrevozniPut"
        Me.cbZsPrevozniPut.Size = New System.Drawing.Size(152, 23)
        Me.cbZsPrevozniPut.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 23)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Prevozni put ŽS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbUicPrevozniPut
        '
        Me.cbUicPrevozniPut.Location = New System.Drawing.Point(152, 18)
        Me.cbUicPrevozniPut.Name = "cbUicPrevozniPut"
        Me.cbUicPrevozniPut.Size = New System.Drawing.Size(152, 23)
        Me.cbUicPrevozniPut.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 23)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Prevozni put UIC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbVrstaPoUgovoru)
        Me.GroupBox6.Controls.Add(Me.btnUnosRobe)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.ComboBox5)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(496, 392)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(376, 208)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = " [ VRSTA POŠILJKE ] "
        '
        'cbVrstaPoUgovoru
        '
        Me.cbVrstaPoUgovoru.Controls.Add(Me.TextBox2)
        Me.cbVrstaPoUgovoru.Controls.Add(Me.Label2)
        Me.cbVrstaPoUgovoru.Controls.Add(Me.Label9)
        Me.cbVrstaPoUgovoru.Controls.Add(Me.rbVoz)
        Me.cbVrstaPoUgovoru.Controls.Add(Me.rbGrupa)
        Me.cbVrstaPoUgovoru.Controls.Add(Me.rbPojedinacna)
        Me.cbVrstaPoUgovoru.Controls.Add(Me.TextBox1)
        Me.cbVrstaPoUgovoru.Enabled = False
        Me.cbVrstaPoUgovoru.Location = New System.Drawing.Point(24, 56)
        Me.cbVrstaPoUgovoru.Name = "cbVrstaPoUgovoru"
        Me.cbVrstaPoUgovoru.Size = New System.Drawing.Size(232, 144)
        Me.cbVrstaPoUgovoru.TabIndex = 32
        Me.cbVrstaPoUgovoru.TabStop = False
        Me.cbVrstaPoUgovoru.Text = " [ * ]"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(160, 104)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(46, 21)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(48, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Broj kola u vozu"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(48, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 23)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Broj kola u grupi"
        '
        'rbVoz
        '
        Me.rbVoz.Location = New System.Drawing.Point(16, 83)
        Me.rbVoz.Name = "rbVoz"
        Me.rbVoz.Size = New System.Drawing.Size(192, 24)
        Me.rbVoz.TabIndex = 3
        Me.rbVoz.Text = "Pošiljka u maršrutnom vozu"
        '
        'rbGrupa
        '
        Me.rbGrupa.Location = New System.Drawing.Point(16, 39)
        Me.rbGrupa.Name = "rbGrupa"
        Me.rbGrupa.Size = New System.Drawing.Size(144, 24)
        Me.rbGrupa.TabIndex = 1
        Me.rbGrupa.Text = "Pošiljka u grupi kola"
        '
        'rbPojedinacna
        '
        Me.rbPojedinacna.Checked = True
        Me.rbPojedinacna.Location = New System.Drawing.Point(16, 15)
        Me.rbPojedinacna.Name = "rbPojedinacna"
        Me.rbPojedinacna.Size = New System.Drawing.Size(152, 24)
        Me.rbPojedinacna.TabIndex = 0
        Me.rbPojedinacna.TabStop = True
        Me.rbPojedinacna.Text = "Pojedinaèna pošiljka"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(160, 55)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(46, 21)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = ""
        '
        'btnUnosRobe
        '
        Me.btnUnosRobe.Image = CType(resources.GetObject("btnUnosRobe.Image"), System.Drawing.Image)
        Me.btnUnosRobe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUnosRobe.Location = New System.Drawing.Point(273, 132)
        Me.btnUnosRobe.Name = "btnUnosRobe"
        Me.btnUnosRobe.Size = New System.Drawing.Size(90, 64)
        Me.btnUnosRobe.TabIndex = 1
        Me.btnUnosRobe.Text = "Unos robe"
        Me.btnUnosRobe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.tbIzlaznaNalepnica)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.cbZsPrelaz2)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.tbUlaznaNalepnica)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Controls.Add(Me.cbZsPrelaz1)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(8, 202)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(480, 190)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = " [ GRANIÈNI PRELAZI ]"
        '
        'tbIzlaznaNalepnica
        '
        Me.tbIzlaznaNalepnica.Enabled = False
        Me.tbIzlaznaNalepnica.Location = New System.Drawing.Point(206, 151)
        Me.tbIzlaznaNalepnica.Name = "tbIzlaznaNalepnica"
        Me.tbIzlaznaNalepnica.Size = New System.Drawing.Size(152, 21)
        Me.tbIzlaznaNalepnica.TabIndex = 3
        Me.tbIzlaznaNalepnica.Text = ""
        '
        'Label8
        '
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(22, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 23)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Izlazna tranzitna nalepnica"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbZsPrelaz2
        '
        Me.cbZsPrelaz2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbZsPrelaz2.Enabled = False
        Me.cbZsPrelaz2.Items.AddRange(New Object() {"711 Subotica", "660 Kikinda", "661 Vrsac", "620 Dimitrovgrad", "676 Presevo", "591 Brasina", "501 Sid"})
        Me.cbZsPrelaz2.Location = New System.Drawing.Point(206, 107)
        Me.cbZsPrelaz2.Name = "cbZsPrelaz2"
        Me.cbZsPrelaz2.Size = New System.Drawing.Size(152, 23)
        Me.cbZsPrelaz2.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Enabled = False
        Me.Label7.Location = New System.Drawing.Point(22, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 23)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Izlazni prelaz ŽS"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbUlaznaNalepnica
        '
        Me.tbUlaznaNalepnica.Enabled = False
        Me.tbUlaznaNalepnica.Location = New System.Drawing.Point(206, 65)
        Me.tbUlaznaNalepnica.Name = "tbUlaznaNalepnica"
        Me.tbUlaznaNalepnica.Size = New System.Drawing.Size(152, 21)
        Me.tbUlaznaNalepnica.TabIndex = 1
        Me.tbUlaznaNalepnica.Text = ""
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(22, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 23)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Ulazna tranzitna nalepnica"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbZsPrelaz1
        '
        Me.cbZsPrelaz1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbZsPrelaz1.Items.AddRange(New Object() {"711 Subotica", "660 Kikinda", "661 Vrsac", "620 Dimitrovgrad", "676 Presevo", "591 Brasina", "501 Sid"})
        Me.cbZsPrelaz1.Location = New System.Drawing.Point(206, 23)
        Me.cbZsPrelaz1.Name = "cbZsPrelaz1"
        Me.cbZsPrelaz1.Size = New System.Drawing.Size(152, 23)
        Me.cbZsPrelaz1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(22, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 23)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Ulazni prelaz ŽS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem9, Me.MenuItem6, Me.MenuItem7, Me.MenuItem8, Me.MenuItem12})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem13, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5})
        Me.MenuItem1.Text = "Unos"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Novi dokument"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 1
        Me.MenuItem13.Text = "Unos po najavi"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "Izmena postojeæeg dokumenta"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "-"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.Text = "Izlaz iz programa"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 1
        Me.MenuItem9.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem10, Me.MenuItem14, Me.MenuItem15})
        Me.MenuItem9.Text = "Funkcije"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 0
        Me.MenuItem10.Text = "Brisanje dokumenta"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 1
        Me.MenuItem14.Text = "Arhiviranje mesecnog materijala"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 2
        Me.MenuItem15.Text = "Kompletnost"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem18, Me.MenuItem19, Me.MenuItem20, Me.MenuItem21, Me.MenuItem22, Me.MenuItem23})
        Me.MenuItem6.Text = "Pregled"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 0
        Me.MenuItem18.Text = "Pregled rada referenata"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 1
        Me.MenuItem19.Text = "Zaduzenja po stanicama"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 2
        Me.MenuItem20.Text = "Pregled prema upravama"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 3
        Me.MenuItem21.Text = "Pregled primenjenih tarifa"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 4
        Me.MenuItem22.Text = "Pregled centralnog obracuna"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 5
        Me.MenuItem23.Text = "Pregled troskova u gotovom"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 3
        Me.MenuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem26, Me.MenuItem41, Me.MenuItem42})
        Me.MenuItem7.Text = "Stampa"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 0
        Me.MenuItem26.Text = "Obracunske liste centralnog obracuna"
        '
        'MenuItem41
        '
        Me.MenuItem41.Index = 1
        Me.MenuItem41.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem43, Me.MenuItem44, Me.MenuItem47, Me.MenuItem48, Me.MenuItem49, Me.MenuItem50})
        Me.MenuItem41.Text = "Kontrolne primedbe K-211"
        '
        'MenuItem43
        '
        Me.MenuItem43.Index = 0
        Me.MenuItem43.Text = "Pregled kontrolnih primedbi"
        '
        'MenuItem44
        '
        Me.MenuItem44.Index = 1
        Me.MenuItem44.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem45, Me.MenuItem46})
        Me.MenuItem44.Text = "Stampanje "
        '
        'MenuItem45
        '
        Me.MenuItem45.Index = 0
        Me.MenuItem45.Text = "Pojedinacna "
        '
        'MenuItem46
        '
        Me.MenuItem46.Index = 1
        Me.MenuItem46.Text = "Sve"
        '
        'MenuItem47
        '
        Me.MenuItem47.Index = 2
        Me.MenuItem47.Text = "Parametri"
        '
        'MenuItem48
        '
        Me.MenuItem48.Index = 3
        Me.MenuItem48.Text = "-"
        '
        'MenuItem49
        '
        Me.MenuItem49.Index = 4
        Me.MenuItem49.Text = "Racun razlike"
        '
        'MenuItem50
        '
        Me.MenuItem50.Index = 5
        Me.MenuItem50.Text = "Vise naplaceni prevozni troskovi Kp-103m"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 2
        Me.MenuItem42.Text = "Spisak kontrolnih primedbi  Kp-41"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 4
        Me.MenuItem8.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem28, Me.MenuItem31, Me.MenuItem27, Me.MenuItem34, Me.MenuItem35, Me.MenuItem24, Me.MenuItem36, Me.MenuItem25})
        Me.MenuItem8.Text = "Odrzavanje"
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 0
        Me.MenuItem28.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem29, Me.MenuItem30})
        Me.MenuItem28.Text = "Ugovori po komercijalnim povlasticama"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 0
        Me.MenuItem29.Text = "Unos novog ugovora"
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 1
        Me.MenuItem30.Text = "Pregled ugovora iz baze"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 1
        Me.MenuItem31.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem32, Me.MenuItem33})
        Me.MenuItem31.Text = "Ugovori po centralnom obracunu"
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 0
        Me.MenuItem32.Text = "Unos novog ugovora"
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 1
        Me.MenuItem33.Text = "Pregled ugovora iz baze"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 2
        Me.MenuItem27.Text = "-"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 3
        Me.MenuItem34.Text = "Koeficijenti za prevozne stavove..."
        '
        'MenuItem35
        '
        Me.MenuItem35.Index = 4
        Me.MenuItem35.Text = "-"
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 5
        Me.MenuItem24.Text = "Arhiviranje zavrsenog obracunskog meseca"
        '
        'MenuItem36
        '
        Me.MenuItem36.Index = 6
        Me.MenuItem36.Text = "Postavljanje trenutnog racunskog meseca"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 7
        Me.MenuItem25.Text = "Back up sifarnika"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 5
        Me.MenuItem12.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem11, Me.MenuItem40, Me.MenuItem38, Me.MenuItem39, Me.MenuItem37})
        Me.MenuItem12.Text = "Pomoc"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 0
        Me.MenuItem11.Text = "Index"
        '
        'MenuItem40
        '
        Me.MenuItem40.Index = 1
        Me.MenuItem40.Text = "Pomoc u radu sa programom"
        '
        'MenuItem38
        '
        Me.MenuItem38.Index = 2
        Me.MenuItem38.Text = "Tehnicka podrska"
        '
        'MenuItem39
        '
        Me.MenuItem39.Index = 3
        Me.MenuItem39.Text = "-"
        '
        'MenuItem37
        '
        Me.MenuItem37.Index = 4
        Me.MenuItem37.Text = "O programu "
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button8.Location = New System.Drawing.Point(658, 610)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(94, 64)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "Prihvati"
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Location = New System.Drawing.Point(775, 610)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(97, 64)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "Otkaži"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnIzjava)
        Me.GroupBox4.Controls.Add(Me.tbFrankoDoIznosa)
        Me.GroupBox4.Controls.Add(Me.tbFrankoPrelaz)
        Me.GroupBox4.Controls.Add(Me.tbFrankoNaknada4)
        Me.GroupBox4.Controls.Add(Me.tbFrankoNaknada3)
        Me.GroupBox4.Controls.Add(Me.tbFrankoNaknada2)
        Me.GroupBox4.Controls.Add(Me.rbUpuceno)
        Me.GroupBox4.Controls.Add(Me.rbFrankoTroskovi)
        Me.GroupBox4.Controls.Add(Me.rbFrankoDoIznosa)
        Me.GroupBox4.Controls.Add(Me.rbFrankoPrevoznina)
        Me.GroupBox4.Controls.Add(Me.tbFrankoNaknada1)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(496, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(376, 144)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = " [ IZJAVA O PLACANJU ]"
        '
        'btnIzjava
        '
        Me.btnIzjava.Location = New System.Drawing.Point(179, 51)
        Me.btnIzjava.Name = "btnIzjava"
        Me.btnIzjava.Size = New System.Drawing.Size(84, 21)
        Me.btnIzjava.TabIndex = 34
        Me.btnIzjava.Text = "Do prelaza"
        '
        'tbFrankoDoIznosa
        '
        Me.tbFrankoDoIznosa.Location = New System.Drawing.Point(180, 84)
        Me.tbFrankoDoIznosa.Name = "tbFrankoDoIznosa"
        Me.tbFrankoDoIznosa.Size = New System.Drawing.Size(69, 21)
        Me.tbFrankoDoIznosa.TabIndex = 30
        Me.tbFrankoDoIznosa.Text = ""
        '
        'tbFrankoPrelaz
        '
        Me.tbFrankoPrelaz.Location = New System.Drawing.Point(276, 50)
        Me.tbFrankoPrelaz.Name = "tbFrankoPrelaz"
        Me.tbFrankoPrelaz.Size = New System.Drawing.Size(52, 21)
        Me.tbFrankoPrelaz.TabIndex = 29
        Me.tbFrankoPrelaz.Text = ""
        '
        'tbFrankoNaknada4
        '
        Me.tbFrankoNaknada4.Location = New System.Drawing.Point(294, 22)
        Me.tbFrankoNaknada4.Name = "tbFrankoNaknada4"
        Me.tbFrankoNaknada4.Size = New System.Drawing.Size(32, 21)
        Me.tbFrankoNaknada4.TabIndex = 27
        Me.tbFrankoNaknada4.Text = ""
        '
        'tbFrankoNaknada3
        '
        Me.tbFrankoNaknada3.Location = New System.Drawing.Point(256, 22)
        Me.tbFrankoNaknada3.Name = "tbFrankoNaknada3"
        Me.tbFrankoNaknada3.Size = New System.Drawing.Size(32, 21)
        Me.tbFrankoNaknada3.TabIndex = 26
        Me.tbFrankoNaknada3.Text = ""
        '
        'tbFrankoNaknada2
        '
        Me.tbFrankoNaknada2.Location = New System.Drawing.Point(218, 22)
        Me.tbFrankoNaknada2.Name = "tbFrankoNaknada2"
        Me.tbFrankoNaknada2.Size = New System.Drawing.Size(32, 21)
        Me.tbFrankoNaknada2.TabIndex = 25
        Me.tbFrankoNaknada2.Text = ""
        '
        'rbUpuceno
        '
        Me.rbUpuceno.Location = New System.Drawing.Point(232, 114)
        Me.rbUpuceno.Name = "rbUpuceno"
        Me.rbUpuceno.Size = New System.Drawing.Size(88, 20)
        Me.rbUpuceno.TabIndex = 3
        Me.rbUpuceno.Text = "Upuceno"
        '
        'rbFrankoTroskovi
        '
        Me.rbFrankoTroskovi.Location = New System.Drawing.Point(16, 114)
        Me.rbFrankoTroskovi.Name = "rbFrankoTroskovi"
        Me.rbFrankoTroskovi.Size = New System.Drawing.Size(152, 20)
        Me.rbFrankoTroskovi.TabIndex = 2
        Me.rbFrankoTroskovi.Text = "Franko svi troskovi"
        '
        'rbFrankoDoIznosa
        '
        Me.rbFrankoDoIznosa.Location = New System.Drawing.Point(16, 83)
        Me.rbFrankoDoIznosa.Name = "rbFrankoDoIznosa"
        Me.rbFrankoDoIznosa.Size = New System.Drawing.Size(152, 23)
        Me.rbFrankoDoIznosa.TabIndex = 1
        Me.rbFrankoDoIznosa.Text = "Franko do iznosa"
        '
        'rbFrankoPrevoznina
        '
        Me.rbFrankoPrevoznina.Checked = True
        Me.rbFrankoPrevoznina.Location = New System.Drawing.Point(16, 24)
        Me.rbFrankoPrevoznina.Name = "rbFrankoPrevoznina"
        Me.rbFrankoPrevoznina.Size = New System.Drawing.Size(152, 24)
        Me.rbFrankoPrevoznina.TabIndex = 0
        Me.rbFrankoPrevoznina.TabStop = True
        Me.rbFrankoPrevoznina.Text = "Franko prevoznina"
        '
        'tbFrankoNaknada1
        '
        Me.tbFrankoNaknada1.Location = New System.Drawing.Point(180, 22)
        Me.tbFrankoNaknada1.Name = "tbFrankoNaknada1"
        Me.tbFrankoNaknada1.Size = New System.Drawing.Size(32, 21)
        Me.tbFrankoNaknada1.TabIndex = 23
        Me.tbFrankoNaknada1.Text = ""
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.Location = New System.Drawing.Point(106, 610)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 48)
        Me.Button3.TabIndex = 37
        Me.Button3.Text = "..."
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button4.Location = New System.Drawing.Point(203, 610)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(96, 48)
        Me.Button4.TabIndex = 38
        Me.Button4.Text = "..."
        '
        'Unos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(880, 681)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnKalkulacija)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.btnUicUprave)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "Unos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.cbVrstaPoUgovoru.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnUnosRobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnosRobe.Click
        Dim GridKola As New kola
        GridKola.Show()

    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        Close()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Close()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Close()

    End Sub

    Private Sub Unos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IzborSaobracaja = "1" Then
        ElseIf IzborSaobracaja = "3" Then
            Me.Label1.Enabled = False
            Me.cbUicPrevozniPut.Enabled = False
            Me.btnUicUprave.Text = "..."
            Me.btnUicUprave.Enabled = False
            Me.Label4.Enabled = True
            Me.Label7.Enabled = True
            Me.Label8.Enabled = True
            Me.tbUlaznaNalepnica.Enabled = True
            Me.tbIzlaznaNalepnica.Enabled = True
            Me.cbZsPrelaz2.Enabled = True
        ElseIf IzborSaobracaja = "4" Then
            Me.GroupBox7().Enabled = False
            Me.Label1.Enabled = False
            Me.cbUicPrevozniPut.Enabled = False
            Me.btnUicUprave.Text = "..."
            Me.btnUicUprave.Enabled = False
            Me.Label4.Enabled = True
            Me.Label7.Enabled = True
            Me.Label8.Enabled = True
            Me.tbUlaznaNalepnica.Enabled = True
            Me.tbIzlaznaNalepnica.Enabled = True
            Me.cbZsPrelaz2.Enabled = True
        End If
    End Sub
    Private Sub cbzsprelaz1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbZsPrelaz1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub GroupBox7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox7.Enter

    End Sub
End Class
