Imports System.Data.SqlClient
Public Class Info_Uvoz
    Inherits System.Windows.Forms.Form
    Public dvUicObracun As New DataView(dtUic2)

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
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents dgUicObracun As System.Windows.Forms.DataGrid
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents tbSumaDinariUpuceno As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbKurs As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbVS As System.Windows.Forms.TextBox
    Friend WithEvents tbSumRM As System.Windows.Forms.TextBox
    Friend WithEvents tbSumSM As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbKM2 As System.Windows.Forms.TextBox
    Friend WithEvents tbKM1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Info_Uvoz))
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.dgUicObracun = New System.Windows.Forms.DataGrid
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.tbSumaDinariUpuceno = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbKurs = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbVS = New System.Windows.Forms.TextBox
        Me.tbSumRM = New System.Windows.Forms.TextBox
        Me.tbSumSM = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbKM2 = New System.Windows.Forms.TextBox
        Me.tbKM1 = New System.Windows.Forms.TextBox
        CType(Me.dgUicObracun, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(921, 584)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 7
        Me.btnPrihvati.Text = "Prihvati  "
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'dgUicObracun
        '
        Me.dgUicObracun.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 26.0!)
        Me.dgUicObracun.CaptionText = "Podaci o stranim upravama"
        Me.dgUicObracun.ColumnHeadersVisible = False
        Me.dgUicObracun.DataMember = ""
        Me.dgUicObracun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgUicObracun.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUicObracun.Location = New System.Drawing.Point(16, 232)
        Me.dgUicObracun.Name = "dgUicObracun"
        Me.dgUicObracun.PreferredColumnWidth = 106
        Me.dgUicObracun.Size = New System.Drawing.Size(993, 296)
        Me.dgUicObracun.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(352, 208)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(18, 234)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(352, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "F R A N K O"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gray
        Me.Button2.Location = New System.Drawing.Point(370, 234)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 46)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "U P R A V A "
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(52, 257)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Prevoznina"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(158, 257)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(106, 23)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "Naknade"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(264, 257)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(106, 23)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Suma"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Gray
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Button6.Location = New System.Drawing.Point(476, 234)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(106, 46)
        Me.Button6.TabIndex = 15
        Me.Button6.Text = "[ V A L U T A ]"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Button7.Location = New System.Drawing.Point(794, 257)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(106, 23)
        Me.Button7.TabIndex = 19
        Me.Button7.Text = "Suma"
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Button8.Location = New System.Drawing.Point(688, 257)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(106, 23)
        Me.Button8.TabIndex = 18
        Me.Button8.Text = "Naknade"
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Button9.Location = New System.Drawing.Point(582, 257)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(106, 23)
        Me.Button9.TabIndex = 17
        Me.Button9.Text = "Prevoznina"
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Button10.Location = New System.Drawing.Point(582, 234)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(318, 23)
        Me.Button10.TabIndex = 16
        Me.Button10.Text = "U P U C E N O"
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Button11.Location = New System.Drawing.Point(900, 234)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(106, 46)
        Me.Button11.TabIndex = 20
        Me.Button11.Text = "U P U C E N O     D I N A R I"
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(18, 257)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(34, 23)
        Me.Button12.TabIndex = 21
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(400, 16)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(144, 104)
        Me.Button13.TabIndex = 22
        Me.Button13.Text = "Button13"
        Me.Button13.Visible = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(582, 528)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(320, 23)
        Me.Button14.TabIndex = 23
        Me.Button14.Text = "S U M A    D I N A R I   U P U C E N O"
        Me.Button14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbSumaDinariUpuceno
        '
        Me.tbSumaDinariUpuceno.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.tbSumaDinariUpuceno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSumaDinariUpuceno.ForeColor = System.Drawing.Color.Black
        Me.tbSumaDinariUpuceno.Location = New System.Drawing.Point(904, 528)
        Me.tbSumaDinariUpuceno.Name = "tbSumaDinariUpuceno"
        Me.tbSumaDinariUpuceno.Size = New System.Drawing.Size(106, 24)
        Me.tbSumaDinariUpuceno.TabIndex = 24
        Me.tbSumaDinariUpuceno.Text = ""
        Me.tbSumaDinariUpuceno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(784, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(192, 24)
        Me.TextBox1.TabIndex = 32
        Me.TextBox1.Text = ""
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(640, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Vrsta obracuna :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(725, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Kurs :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbKurs
        '
        Me.tbKurs.BackColor = System.Drawing.Color.White
        Me.tbKurs.Enabled = False
        Me.tbKurs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKurs.ForeColor = System.Drawing.Color.Black
        Me.tbKurs.Location = New System.Drawing.Point(784, 152)
        Me.tbKurs.Name = "tbKurs"
        Me.tbKurs.Size = New System.Drawing.Size(192, 24)
        Me.tbKurs.TabIndex = 29
        Me.tbKurs.Text = ""
        '
        'Label5
        '
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(592, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 23)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Vozarinski stav"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(592, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 23)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Suma racunska masa"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(634, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Suma stvarna masa"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbVS
        '
        Me.tbVS.BackColor = System.Drawing.Color.White
        Me.tbVS.Enabled = False
        Me.tbVS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbVS.ForeColor = System.Drawing.Color.Black
        Me.tbVS.Location = New System.Drawing.Point(784, 120)
        Me.tbVS.Name = "tbVS"
        Me.tbVS.Size = New System.Drawing.Size(192, 24)
        Me.tbVS.TabIndex = 39
        Me.tbVS.Text = ""
        '
        'tbSumRM
        '
        Me.tbSumRM.BackColor = System.Drawing.Color.White
        Me.tbSumRM.Enabled = False
        Me.tbSumRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSumRM.ForeColor = System.Drawing.Color.Black
        Me.tbSumRM.Location = New System.Drawing.Point(784, 88)
        Me.tbSumRM.Name = "tbSumRM"
        Me.tbSumRM.Size = New System.Drawing.Size(192, 24)
        Me.tbSumRM.TabIndex = 38
        Me.tbSumRM.Text = ""
        '
        'tbSumSM
        '
        Me.tbSumSM.BackColor = System.Drawing.Color.White
        Me.tbSumSM.Enabled = False
        Me.tbSumSM.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSumSM.ForeColor = System.Drawing.Color.Black
        Me.tbSumSM.Location = New System.Drawing.Point(784, 56)
        Me.tbSumSM.Name = "tbSumSM"
        Me.tbSumSM.Size = New System.Drawing.Size(192, 24)
        Me.tbSumSM.TabIndex = 37
        Me.tbSumSM.Text = ""
        '
        'Label6
        '
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(664, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Kilometri"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbKM2
        '
        Me.tbKM2.BackColor = System.Drawing.Color.White
        Me.tbKM2.Enabled = False
        Me.tbKM2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKM2.ForeColor = System.Drawing.Color.Black
        Me.tbKM2.Location = New System.Drawing.Point(888, 184)
        Me.tbKM2.Name = "tbKM2"
        Me.tbKM2.Size = New System.Drawing.Size(88, 24)
        Me.tbKM2.TabIndex = 44
        Me.tbKM2.Text = ""
        '
        'tbKM1
        '
        Me.tbKM1.BackColor = System.Drawing.Color.White
        Me.tbKM1.Enabled = False
        Me.tbKM1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKM1.ForeColor = System.Drawing.Color.Black
        Me.tbKM1.Location = New System.Drawing.Point(784, 184)
        Me.tbKM1.Name = "tbKM1"
        Me.tbKM1.Size = New System.Drawing.Size(88, 24)
        Me.tbKM1.TabIndex = 43
        Me.tbKM1.Text = ""
        '
        'Info_Uvoz
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1030, 668)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbKM2)
        Me.Controls.Add(Me.tbKM1)
        Me.Controls.Add(Me.tbVS)
        Me.Controls.Add(Me.tbSumRM)
        Me.Controls.Add(Me.tbSumSM)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.tbKurs)
        Me.Controls.Add(Me.tbSumaDinariUpuceno)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgUicObracun)
        Me.Controls.Add(Me.btnPrihvati)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Info_Uvoz"
        Me.Text = "Podaci o kalkulaciji"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgUicObracun, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim dsUic2 As DataSet
    Private Sub FormatUicObracun()
        If dsUic2 Is Nothing Then
            dgUicObracun.DataSource = dtUic2
        Else
            dgUicObracun.DataSource = dsUic2.Tables(0)
        End If
    End Sub

    Private Sub Info_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FormatUicObracun()
        Izjava()

        Button13_Click(Me, Nothing)
    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        mPrikazKalkulacije = "D"
        _OpenForm = "Info"
        bSumaDinari = (mPrevoznina + mSumaNak) * bOutKurs           '24.08.2016
        Close()

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        dtUic2.Clear()
        Dim mOutKurs As Decimal = 0

        If dtUic2.Rows.Count = 0 Then

            Dim UpravaRed As DataRow
            mOutKurs = 0
            Dim strRetVal As String = ""
            Dim uic_Dinari As Decimal
            For Each UpravaRed In dtUic.Rows

                ' preuzeti kurs valute!
                uic_Dinari = 0
                If mBrojUg = "200379" Then 'Sartid
                    NadjiKurs(UpravaRed.Item("Valuta"), "3", mPrDatum, mOutKurs, strRetVal)
                ElseIf mBrojUg = "617902" Then 'Sartid
                    NadjiKurs(UpravaRed.Item("Valuta"), "3", mPrDatum, mOutKurs, strRetVal)
                ElseIf mBrojUg = "617903" Then 'Sartid
                    NadjiKurs(UpravaRed.Item("Valuta"), "3", mPrDatum, mOutKurs, strRetVal)
                ElseIf mBrojUg = "617904" Then 'Sartid
                    NadjiKurs(UpravaRed.Item("Valuta"), "3", mPrDatum, mOutKurs, strRetVal)
                Else
                    NadjiKurs(UpravaRed.Item("Valuta"), "1", mPrDatum, mOutKurs, strRetVal)
                End If

                If Microsoft.VisualBasic.Left(mBrojUg, 4) = "0786" Then 'Hesteel
                    NadjiKurs(UpravaRed.Item("Valuta"), "3", mPrDatum, mOutKurs, strRetVal)
                End If

                uic_Dinari = UpravaRed.Item("PU") + UpravaRed.Item("NU")

                If uic_Dinari > 0 Then
                    uic_Dinari = (UpravaRed.Item("PU") + UpravaRed.Item("NU")) * mOutKurs
                    bZaokruziNaDeseteNavise(uic_Dinari)
                End If

                UpravaRed.Item("DU") = uic_Dinari

                dtUic2.Rows.Add(New Object() {UpravaRed.Item("PF"), UpravaRed.Item("NF"), UpravaRed.Item("PF") + UpravaRed.Item("NF"), _
                                              UpravaRed.Item("Uprava"), UpravaRed.Item("Valuta"), _
                                              UpravaRed.Item("PU"), UpravaRed.Item("NU"), UpravaRed.Item("PU") + UpravaRed.Item("NU"), _
                                              uic_Dinari})

                'bSumaDinari = (mPrevoznina + mSumaNak) * mOutKurs           '23.08.2016
                bOutKurs = mOutKurs
            Next

            ''IzjavaZs()

            If mVrstaObracuna = "CO" Or mVrstaObracuna = "CD" Or mVrstaObracuna = "IC" Then         '   6.6.2016.
                IzjavaZs_CO()
                TextBox1.Text = "Centralni obracun"
            Else
                IzjavaZs()
                TextBox1.Text = "Redovni obracun"
            End If

        End If

        Dim tmp_Iznos As Decimal = 0
        Dim tmp_SumRM As Int32 = 0
        tbKurs.Text = Format(mOutKurs, "###,###,##0.0000")
        If (mBrojUg = "617902" Or mBrojUg = "617903" Or mBrojUg = "617904") And mVrstaObracuna = "RO" Then

            tmp_Iznos = dtUic2.Compute("SUM(USuma)", String.Empty)
            'bZaokruziNaCeleNavise(tmp_Iznos)

            'dodato zbog zaokruzivanja za TEA tarifu
            Dim zaokruziIznos As Decimal = 0
            zaokruziIznos = dtUic2.Compute("SUM(USuma)", String.Empty)
            bZaokruziNaDeseteNavise(zaokruziIznos)
            upis_u_suma = zaokruziIznos

            tmp_Iznos = tmp_Iznos * mOutKurs
        Else
            tmp_Iznos = dtUic2.Compute("SUM(UDinari)", String.Empty)
        End If

        bZaokruziNaDeseteNavise(tmp_Iznos)
        'tmp_Iznos = dtUic2.Compute("SUM(UDinari)", String.Empty)
        Me.tbSumaDinariUpuceno.Text = tmp_Iznos
        mSumaDinari = CDec(Me.tbSumaDinariUpuceno.Text)

        If bVrstaPosiljke = "K" Then
            Me.tbSumSM.Text = dtNhm.Compute("SUM(Masa)", String.Empty)
            'Me.tbSumRM.Text = dtNhm.Compute("SUM(RacMasaNHM)", String.Empty)

            '======= 27.03.2012 Mandic ===========
            tmp_SumRM = Int((dtNhm.Compute("SUM(RacMasaNHM)", String.Empty) + 99) / 100) * 100
            Me.tbSumRM.Text = tmp_SumRM
            '=====================================

            Dim drNHM As DataRow
            For Each drNHM In dtNhm.Rows
                Me.tbVS.Text = drNHM("VozarinskiStavNHM")
                Exit For
            Next
        Else
            Me.tbSumSM.Text = dtDencane.Compute("SUM(SMasa)", String.Empty)
            Me.tbSumRM.Text = dtDencane.Compute("SUM(RMasa)", String.Empty)
            Me.tbVS.Text = ""
        End If

        If Lom_btkm1 > 0 And Lom_btkm2 > 0 Then
            tbKM1.Visible = True
            tbKM2.Visible = True

            Me.tbKM1.Text = Lom_btkm1
            Me.tbKM2.Text = Lom_btkm2
        Else
            tbKM1.Visible = True
            tbKM2.Visible = False
            Me.tbKM1.Text = bTkm
        End If
        Me.tbSumaDinariUpuceno.Text = tmp_Iznos
    End Sub


End Class
