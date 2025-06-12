Imports CrystalDecisions.Shared
Public Class Form1
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents Button28 As System.Windows.Forms.Button
    Friend WithEvents Button29 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Button31 As System.Windows.Forms.Button
    Friend WithEvents Button32 As System.Windows.Forms.Button
    Friend WithEvents Button30 As System.Windows.Forms.Button
    Friend WithEvents Button33 As System.Windows.Forms.Button
    Friend WithEvents Button34 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Button36 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button37 As System.Windows.Forms.Button
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents Button44 As System.Windows.Forms.Button
    Friend WithEvents Button45 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button48 As System.Windows.Forms.Button
    Friend WithEvents Button49 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button50 As System.Windows.Forms.Button
    Friend WithEvents Button58 As System.Windows.Forms.Button
    Friend WithEvents Button60 As System.Windows.Forms.Button
    Friend WithEvents Button61 As System.Windows.Forms.Button
    Friend WithEvents Button64 As System.Windows.Forms.Button
    Friend WithEvents Button66 As System.Windows.Forms.Button
    Friend WithEvents Button67 As System.Windows.Forms.Button
    Friend WithEvents Button68 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button70 As System.Windows.Forms.Button
    Friend WithEvents Button71 As System.Windows.Forms.Button
    Friend WithEvents Button52 As System.Windows.Forms.Button
    Friend WithEvents Button72 As System.Windows.Forms.Button
    Friend WithEvents Button73 As System.Windows.Forms.Button
    Friend WithEvents Button74 As System.Windows.Forms.Button
    Friend WithEvents Button75 As System.Windows.Forms.Button
    Friend WithEvents Button76 As System.Windows.Forms.Button
    Friend WithEvents Button59 As System.Windows.Forms.Button
    Friend WithEvents Button79 As System.Windows.Forms.Button
    Friend WithEvents Button81 As System.Windows.Forms.Button
    Friend WithEvents Button38 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button35 As System.Windows.Forms.Button
    Friend WithEvents Button41 As System.Windows.Forms.Button
    Friend WithEvents Button42 As System.Windows.Forms.Button
    Friend WithEvents Button47 As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button53 As System.Windows.Forms.Button
    Friend WithEvents Button62 As System.Windows.Forms.Button
    Friend WithEvents Button63 As System.Windows.Forms.Button
    Friend WithEvents Button65 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button57 As System.Windows.Forms.Button
    Friend WithEvents Button78 As System.Windows.Forms.Button
    Friend WithEvents Button82 As System.Windows.Forms.Button
    Friend WithEvents Button83 As System.Windows.Forms.Button
    Friend WithEvents Button84 As System.Windows.Forms.Button
    Friend WithEvents Button87 As System.Windows.Forms.Button
    Friend WithEvents Button88 As System.Windows.Forms.Button
    Friend WithEvents Button89 As System.Windows.Forms.Button
    Friend WithEvents Button90 As System.Windows.Forms.Button
    Friend WithEvents Button92 As System.Windows.Forms.Button
    Friend WithEvents Button94 As System.Windows.Forms.Button
    Friend WithEvents Button96 As System.Windows.Forms.Button
    Friend WithEvents Button97 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button100 As System.Windows.Forms.Button
    Friend WithEvents Button43 As System.Windows.Forms.Button
    Friend WithEvents Button102 As System.Windows.Forms.Button
    Friend WithEvents Button103 As System.Windows.Forms.Button
    Friend WithEvents Button39 As System.Windows.Forms.Button
    Friend WithEvents Button54 As System.Windows.Forms.Button
    Friend WithEvents Button56 As System.Windows.Forms.Button
    Friend WithEvents Button86 As System.Windows.Forms.Button
    Friend WithEvents Button95 As System.Windows.Forms.Button
    Friend WithEvents Button77 As System.Windows.Forms.Button
    Friend WithEvents Button101 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button40 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button55 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button51 As System.Windows.Forms.Button
    Friend WithEvents Button69 As System.Windows.Forms.Button
    Friend WithEvents Button46 As System.Windows.Forms.Button
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Button85 As System.Windows.Forms.Button
    Friend WithEvents Button91 As System.Windows.Forms.Button
    Friend WithEvents Button93 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button16 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button18 = New System.Windows.Forms.Button
        Me.Button19 = New System.Windows.Forms.Button
        Me.Button20 = New System.Windows.Forms.Button
        Me.Button21 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button22 = New System.Windows.Forms.Button
        Me.Button24 = New System.Windows.Forms.Button
        Me.Button25 = New System.Windows.Forms.Button
        Me.Button26 = New System.Windows.Forms.Button
        Me.Button27 = New System.Windows.Forms.Button
        Me.Button28 = New System.Windows.Forms.Button
        Me.Button29 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Button31 = New System.Windows.Forms.Button
        Me.Button32 = New System.Windows.Forms.Button
        Me.Button30 = New System.Windows.Forms.Button
        Me.Button33 = New System.Windows.Forms.Button
        Me.Button34 = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Button36 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button37 = New System.Windows.Forms.Button
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter
        Me.Button44 = New System.Windows.Forms.Button
        Me.Button45 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button48 = New System.Windows.Forms.Button
        Me.Button49 = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Button50 = New System.Windows.Forms.Button
        Me.Button58 = New System.Windows.Forms.Button
        Me.Button60 = New System.Windows.Forms.Button
        Me.Button61 = New System.Windows.Forms.Button
        Me.Button64 = New System.Windows.Forms.Button
        Me.Button66 = New System.Windows.Forms.Button
        Me.Button67 = New System.Windows.Forms.Button
        Me.Button68 = New System.Windows.Forms.Button
        Me.Button17 = New System.Windows.Forms.Button
        Me.Button70 = New System.Windows.Forms.Button
        Me.Button71 = New System.Windows.Forms.Button
        Me.Button52 = New System.Windows.Forms.Button
        Me.Button72 = New System.Windows.Forms.Button
        Me.Button73 = New System.Windows.Forms.Button
        Me.Button74 = New System.Windows.Forms.Button
        Me.Button75 = New System.Windows.Forms.Button
        Me.Button76 = New System.Windows.Forms.Button
        Me.Button59 = New System.Windows.Forms.Button
        Me.Button79 = New System.Windows.Forms.Button
        Me.Button81 = New System.Windows.Forms.Button
        Me.Button38 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Button35 = New System.Windows.Forms.Button
        Me.Button41 = New System.Windows.Forms.Button
        Me.Button42 = New System.Windows.Forms.Button
        Me.Button47 = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Button53 = New System.Windows.Forms.Button
        Me.Button62 = New System.Windows.Forms.Button
        Me.Button63 = New System.Windows.Forms.Button
        Me.Button65 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button57 = New System.Windows.Forms.Button
        Me.Button78 = New System.Windows.Forms.Button
        Me.Button82 = New System.Windows.Forms.Button
        Me.Button83 = New System.Windows.Forms.Button
        Me.Button84 = New System.Windows.Forms.Button
        Me.Button87 = New System.Windows.Forms.Button
        Me.Button88 = New System.Windows.Forms.Button
        Me.Button89 = New System.Windows.Forms.Button
        Me.Button90 = New System.Windows.Forms.Button
        Me.Button92 = New System.Windows.Forms.Button
        Me.Button94 = New System.Windows.Forms.Button
        Me.Button96 = New System.Windows.Forms.Button
        Me.Button97 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button100 = New System.Windows.Forms.Button
        Me.Button43 = New System.Windows.Forms.Button
        Me.Button102 = New System.Windows.Forms.Button
        Me.Button103 = New System.Windows.Forms.Button
        Me.Button39 = New System.Windows.Forms.Button
        Me.Button54 = New System.Windows.Forms.Button
        Me.Button56 = New System.Windows.Forms.Button
        Me.Button86 = New System.Windows.Forms.Button
        Me.Button95 = New System.Windows.Forms.Button
        Me.Button77 = New System.Windows.Forms.Button
        Me.Button101 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button40 = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Button55 = New System.Windows.Forms.Button
        Me.Button23 = New System.Windows.Forms.Button
        Me.Button51 = New System.Windows.Forms.Button
        Me.Button69 = New System.Windows.Forms.Button
        Me.Button46 = New System.Windows.Forms.Button
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button85 = New System.Windows.Forms.Button
        Me.Button91 = New System.Windows.Forms.Button
        Me.Button93 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(552, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(24, 26)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Red
        Me.TextBox2.Location = New System.Drawing.Point(584, 32)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(44, 26)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = ""
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Red
        Me.Button3.Location = New System.Drawing.Point(56, 128)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(192, 32)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "1.2m  Direktni vozovi"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(528, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Unesite raèunski mesec (1,2,3,4,5,6,7,8,9,10,11,12) i godinu (2016):"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(16, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1256, 22)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "TRANZIT - MESEÈNI  IZVEŠTAJI "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(232, 24)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "FAKTURE  RCH "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button5.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Red
        Me.Button5.Location = New System.Drawing.Point(56, 288)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(192, 32)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "1.4m  Pojedinaène pošiljke"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button6.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Red
        Me.Button6.Location = New System.Drawing.Point(296, 88)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(208, 32)
        Me.Button6.TabIndex = 9
        Me.Button6.Text = "2.1 CO -svi ugovori"
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button16.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button16.Location = New System.Drawing.Point(512, 240)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(248, 32)
        Me.Button16.TabIndex = 17
        Me.Button16.Text = "3.7  Privatna kola ug. 601..."
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Font = New System.Drawing.Font("Arial Black", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(552, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 24)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "REKAPITULACIJA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button4.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Red
        Me.Button4.Location = New System.Drawing.Point(56, 248)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(192, 32)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "1.3m  Kontenerski vozovi"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(56, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(192, 32)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "1.1m   Vozovi do Makiša"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button7.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Red
        Me.Button7.Location = New System.Drawing.Point(296, 128)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(208, 32)
        Me.Button7.TabIndex = 10
        Me.Button7.Text = "2.2m Izbor ugovora "
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button9.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.Red
        Me.Button9.Location = New System.Drawing.Point(296, 168)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(208, 48)
        Me.Button9.TabIndex = 12
        Me.Button9.Text = "2.4   AdriaC. / kontokorentni obraèun tranzit+uvoz+izvoz"
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button10.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.Blue
        Me.Button10.Location = New System.Drawing.Point(512, 88)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(48, 24)
        Me.Button10.TabIndex = 13
        Me.Button10.Text = "3.1d  "
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button11.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.DarkViolet
        Me.Button11.Location = New System.Drawing.Point(512, 432)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(248, 32)
        Me.Button11.TabIndex = 14
        Me.Button11.Text = "3.13   Vozovi od Makiša"
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button12.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.Red
        Me.Button12.Location = New System.Drawing.Point(560, 112)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(200, 24)
        Me.Button12.TabIndex = 15
        Me.Button12.Text = "3.2m  Direktni vozovi ug. 601..."
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button13.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button13.ForeColor = System.Drawing.Color.Red
        Me.Button13.Location = New System.Drawing.Point(560, 136)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(200, 32)
        Me.Button13.TabIndex = 16
        Me.Button13.Text = "3.3 Izbor ugovora - vozovi"
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.MediumBlue
        Me.Button14.Location = New System.Drawing.Point(632, 24)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(112, 40)
        Me.Button14.TabIndex = 3
        Me.Button14.Text = "osvežite podatke-tranzit "
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Font = New System.Drawing.Font("Arial Black", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label4.Location = New System.Drawing.Point(824, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 24)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "PROVERA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button18.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button18.Location = New System.Drawing.Point(768, 208)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(104, 32)
        Me.Button18.TabIndex = 20
        Me.Button18.Text = "4.6  Špedicije"
        '
        'Button19
        '
        Me.Button19.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button19.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button19.Location = New System.Drawing.Point(768, 248)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(104, 32)
        Me.Button19.TabIndex = 21
        Me.Button19.Text = "4.8a Lista za OKP"
        '
        'Button20
        '
        Me.Button20.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button20.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button20.Location = New System.Drawing.Point(936, 248)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(80, 32)
        Me.Button20.TabIndex = 22
        Me.Button20.Text = "4.9 L. B-rekap"
        '
        'Button21
        '
        Me.Button21.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button21.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button21.Location = New System.Drawing.Point(872, 248)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(64, 32)
        Me.Button21.TabIndex = 23
        Me.Button21.Text = "4.8 Lista B"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Underline)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label5.Location = New System.Drawing.Point(1032, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(224, 24)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "MESEÈNA STATISTIKA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button22.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button22.ForeColor = System.Drawing.Color.Black
        Me.Button22.Location = New System.Drawing.Point(768, 288)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(144, 32)
        Me.Button22.TabIndex = 24
        Me.Button22.Text = "4.10  Lista B po tarifi"
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button24.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button24.ForeColor = System.Drawing.Color.Red
        Me.Button24.Location = New System.Drawing.Point(56, 328)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(192, 32)
        Me.Button24.TabIndex = 48
        Me.Button24.Text = "1.6m Grupe kola-svi ug."
        '
        'Button25
        '
        Me.Button25.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button25.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button25.ForeColor = System.Drawing.Color.Red
        Me.Button25.Location = New System.Drawing.Point(512, 200)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(48, 40)
        Me.Button25.TabIndex = 49
        Me.Button25.Text = "3.5d "
        '
        'Button26
        '
        Me.Button26.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button26.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button26.Location = New System.Drawing.Point(1024, 120)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(136, 40)
        Me.Button26.TabIndex = 50
        Me.Button26.Text = "5.2  RCH-broj direktnih vozova"
        '
        'Button27
        '
        Me.Button27.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button27.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button27.Location = New System.Drawing.Point(1024, 88)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(248, 32)
        Me.Button27.TabIndex = 51
        Me.Button27.Text = "5.1  RCH-broj vozova do Makiša"
        '
        'Button28
        '
        Me.Button28.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button28.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button28.ForeColor = System.Drawing.Color.DarkViolet
        Me.Button28.Location = New System.Drawing.Point(1024, 432)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(144, 32)
        Me.Button28.TabIndex = 52
        Me.Button28.Text = "5.13 Broj vozova od Makiša"
        '
        'Button29
        '
        Me.Button29.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button29.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button29.ForeColor = System.Drawing.Color.MediumBlue
        Me.Button29.Location = New System.Drawing.Point(1160, 120)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(112, 40)
        Me.Button29.TabIndex = 53
        Me.Button29.Text = "5.3  Izbor ug. - broj vozova"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(8, 472)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(1264, 24)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "TRANZIT - PODACI OD POÈETKA GODINE-(osim vozova od Makiša)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkViolet
        Me.Label9.Location = New System.Drawing.Point(8, 400)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(1264, 22)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "TRANZIT - MESEÈNI IZVEŠTAJI ZA VOZOVE OD MAKIŠA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(8, 504)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(248, 32)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Unesite raèunsku godinu (2012, ...2016): "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.PaleGreen
        Me.TextBox5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.ForestGreen
        Me.TextBox5.Location = New System.Drawing.Point(264, 504)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(44, 26)
        Me.TextBox5.TabIndex = 58
        Me.TextBox5.Text = ""
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button31
        '
        Me.Button31.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button31.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button31.ForeColor = System.Drawing.Color.Green
        Me.Button31.Location = New System.Drawing.Point(8, 544)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(128, 40)
        Me.Button31.TabIndex = 59
        Me.Button31.Text = "osvežite podatke za CO, CD i IC"
        '
        'Button32
        '
        Me.Button32.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button32.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button32.ForeColor = System.Drawing.Color.Red
        Me.Button32.Location = New System.Drawing.Point(1024, 168)
        Me.Button32.Name = "Button32"
        Me.Button32.Size = New System.Drawing.Size(248, 32)
        Me.Button32.TabIndex = 60
        Me.Button32.Text = "5.5  Konteneri po ugovorima"
        '
        'Button30
        '
        Me.Button30.BackColor = System.Drawing.Color.Yellow
        Me.Button30.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button30.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button30.Location = New System.Drawing.Point(512, 504)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(248, 32)
        Me.Button30.TabIndex = 61
        Me.Button30.Text = "3.14 Izbor saob.- Svi ugovori-godina"
        '
        'Button33
        '
        Me.Button33.BackColor = System.Drawing.Color.Yellow
        Me.Button33.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button33.ForeColor = System.Drawing.Color.Maroon
        Me.Button33.Location = New System.Drawing.Point(512, 696)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(248, 30)
        Me.Button33.TabIndex = 62
        Me.Button33.Text = "3.18 Od Makiša prihod po kor. god"
        '
        'Button34
        '
        Me.Button34.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button34.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button34.ForeColor = System.Drawing.Color.Maroon
        Me.Button34.Location = New System.Drawing.Point(336, 696)
        Me.Button34.Name = "Button34"
        Me.Button34.Size = New System.Drawing.Size(152, 30)
        Me.Button34.TabIndex = 63
        Me.Button34.Text = "osvežite podatke"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DarkCyan
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(8, 696)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(256, 24)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Unesite raèunsku godinu: "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.TextBox6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox6.ForeColor = System.Drawing.Color.Maroon
        Me.TextBox6.Location = New System.Drawing.Point(280, 696)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(44, 26)
        Me.TextBox6.TabIndex = 66
        Me.TextBox6.Text = ""
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button36
        '
        Me.Button36.BackColor = System.Drawing.Color.Yellow
        Me.Button36.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button36.ForeColor = System.Drawing.Color.Black
        Me.Button36.Location = New System.Drawing.Point(512, 584)
        Me.Button36.Name = "Button36"
        Me.Button36.Size = New System.Drawing.Size(248, 32)
        Me.Button36.TabIndex = 70
        Me.Button36.Text = "3.16    Stimulacije-svi ugovori-god."
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label13.Font = New System.Drawing.Font("Arial Black", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label13.Location = New System.Drawing.Point(280, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(208, 24)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "FAKTURE -OSTALI"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button37
        '
        Me.Button37.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button37.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button37.ForeColor = System.Drawing.Color.DarkViolet
        Me.Button37.Location = New System.Drawing.Point(1168, 432)
        Me.Button37.Name = "Button37"
        Me.Button37.Size = New System.Drawing.Size(112, 32)
        Me.Button37.TabIndex = 73
        Me.Button37.Text = "5.14 Rad od Makiša"
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
        Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
        '
        'Button44
        '
        Me.Button44.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button44.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button44.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button44.Location = New System.Drawing.Point(1024, 624)
        Me.Button44.Name = "Button44"
        Me.Button44.Size = New System.Drawing.Size(248, 32)
        Me.Button44.TabIndex = 81
        Me.Button44.Text = "5.18 Svi direktni vozovi po mesecima"
        '
        'Button45
        '
        Me.Button45.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button45.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button45.ForeColor = System.Drawing.Color.Black
        Me.Button45.Location = New System.Drawing.Point(1024, 696)
        Me.Button45.Name = "Button45"
        Me.Button45.Size = New System.Drawing.Size(248, 30)
        Me.Button45.TabIndex = 82
        Me.Button45.Text = "5.19** Br. voz. od Makiša po mesecima"
        '
        'Button48
        '
        Me.Button48.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button48.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button48.ForeColor = System.Drawing.Color.DarkViolet
        Me.Button48.Location = New System.Drawing.Point(768, 432)
        Me.Button48.Name = "Button48"
        Me.Button48.Size = New System.Drawing.Size(248, 32)
        Me.Button48.TabIndex = 85
        Me.Button48.Text = "4.13 Zaostala kola u Makišu"
        '
        'Button49
        '
        Me.Button49.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button49.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button49.ForeColor = System.Drawing.Color.Green
        Me.Button49.Location = New System.Drawing.Point(768, 504)
        Me.Button49.Name = "Button49"
        Me.Button49.Size = New System.Drawing.Size(248, 32)
        Me.Button49.TabIndex = 87
        Me.Button49.Text = "4.14 ? Ugovor po mesecima"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(8, 664)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(1264, 24)
        Me.Label15.TabIndex = 88
        Me.Label15.Text = "TRANZIT - PODACI OD POÈETKA GODINE ZA VOZOVE OD MAKIŠA"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button50
        '
        Me.Button50.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button50.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button50.ForeColor = System.Drawing.Color.Black
        Me.Button50.Location = New System.Drawing.Point(1024, 544)
        Me.Button50.Name = "Button50"
        Me.Button50.Size = New System.Drawing.Size(248, 32)
        Me.Button50.TabIndex = 89
        Me.Button50.Text = "5.16** Broj vozova-?ugov.?prel.?nhm"
        '
        'Button58
        '
        Me.Button58.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button58.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button58.ForeColor = System.Drawing.Color.Red
        Me.Button58.Location = New System.Drawing.Point(512, 168)
        Me.Button58.Name = "Button58"
        Me.Button58.Size = New System.Drawing.Size(48, 32)
        Me.Button58.TabIndex = 97
        Me.Button58.Text = "3.4d"
        '
        'Button60
        '
        Me.Button60.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button60.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button60.ForeColor = System.Drawing.Color.Green
        Me.Button60.Location = New System.Drawing.Point(768, 624)
        Me.Button60.Name = "Button60"
        Me.Button60.Size = New System.Drawing.Size(248, 32)
        Me.Button60.TabIndex = 99
        Me.Button60.Text = "4.17  RID  materije  po mesecima"
        '
        'Button61
        '
        Me.Button61.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button61.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button61.Location = New System.Drawing.Point(888, 168)
        Me.Button61.Name = "Button61"
        Me.Button61.Size = New System.Drawing.Size(128, 32)
        Me.Button61.TabIndex = 100
        Me.Button61.Text = "4.5 Materije iz gl. 27 "
        '
        'Button64
        '
        Me.Button64.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button64.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button64.ForeColor = System.Drawing.Color.Black
        Me.Button64.Location = New System.Drawing.Point(1024, 584)
        Me.Button64.Name = "Button64"
        Me.Button64.Size = New System.Drawing.Size(248, 32)
        Me.Button64.TabIndex = 103
        Me.Button64.Text = "5.17** ? Ugovor ? NHM - po mesecima"
        '
        'Button66
        '
        Me.Button66.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button66.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button66.ForeColor = System.Drawing.Color.Green
        Me.Button66.Location = New System.Drawing.Point(768, 584)
        Me.Button66.Name = "Button66"
        Me.Button66.Size = New System.Drawing.Size(248, 32)
        Me.Button66.TabIndex = 105
        Me.Button66.Text = "4.16 ? Korisnik-po glavama NHM"
        '
        'Button67
        '
        Me.Button67.BackColor = System.Drawing.Color.Yellow
        Me.Button67.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button67.ForeColor = System.Drawing.Color.Black
        Me.Button67.Location = New System.Drawing.Point(512, 544)
        Me.Button67.Name = "Button67"
        Me.Button67.Size = New System.Drawing.Size(248, 32)
        Me.Button67.TabIndex = 106
        Me.Button67.Text = "3.15  Korisnik-ug. prihod-godina"
        '
        'Button68
        '
        Me.Button68.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button68.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button68.Location = New System.Drawing.Point(768, 128)
        Me.Button68.Name = "Button68"
        Me.Button68.Size = New System.Drawing.Size(136, 32)
        Me.Button68.TabIndex = 107
        Me.Button68.Text = "4.2 Naknade radiološke"
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button17.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button17.ForeColor = System.Drawing.Color.Black
        Me.Button17.Location = New System.Drawing.Point(768, 88)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(160, 40)
        Me.Button17.TabIndex = 109
        Me.Button17.Text = "4.1 Nelogiènosti-unutr. uvoz, izvoz, tranzit"
        '
        'Button70
        '
        Me.Button70.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button70.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button70.Location = New System.Drawing.Point(904, 128)
        Me.Button70.Name = "Button70"
        Me.Button70.Size = New System.Drawing.Size(112, 32)
        Me.Button70.TabIndex = 114
        Me.Button70.Text = "4.3 Nak. veterinar."
        '
        'Button71
        '
        Me.Button71.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button71.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button71.Location = New System.Drawing.Point(768, 168)
        Me.Button71.Name = "Button71"
        Me.Button71.Size = New System.Drawing.Size(120, 32)
        Me.Button71.TabIndex = 115
        Me.Button71.Text = "4.4 Nakn. ekološke"
        '
        'Button52
        '
        Me.Button52.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button52.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button52.ForeColor = System.Drawing.Color.Red
        Me.Button52.Location = New System.Drawing.Point(256, 224)
        Me.Button52.Name = "Button52"
        Me.Button52.Size = New System.Drawing.Size(40, 56)
        Me.Button52.TabIndex = 117
        Me.Button52.Text = "2.6d"
        '
        'Button72
        '
        Me.Button72.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button72.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button72.ForeColor = System.Drawing.Color.Green
        Me.Button72.Location = New System.Drawing.Point(768, 544)
        Me.Button72.Name = "Button72"
        Me.Button72.Size = New System.Drawing.Size(248, 30)
        Me.Button72.TabIndex = 118
        Me.Button72.Text = "4.15 Proseèno kola-?Ugovor ?relacija"
        '
        'Button73
        '
        Me.Button73.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button73.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button73.ForeColor = System.Drawing.Color.Red
        Me.Button73.Location = New System.Drawing.Point(256, 288)
        Me.Button73.Name = "Button73"
        Me.Button73.Size = New System.Drawing.Size(40, 72)
        Me.Button73.TabIndex = 119
        Me.Button73.Text = "2.7d  "
        '
        'Button74
        '
        Me.Button74.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button74.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button74.ForeColor = System.Drawing.Color.OrangeRed
        Me.Button74.Location = New System.Drawing.Point(1096, 24)
        Me.Button74.Name = "Button74"
        Me.Button74.Size = New System.Drawing.Size(176, 40)
        Me.Button74.TabIndex = 120
        Me.Button74.Text = "osvežite CO, CD, RO, IC uvoz+izvoz+tranzit+unut."
        '
        'Button75
        '
        Me.Button75.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button75.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button75.ForeColor = System.Drawing.Color.Red
        Me.Button75.Location = New System.Drawing.Point(512, 336)
        Me.Button75.Name = "Button75"
        Me.Button75.Size = New System.Drawing.Size(128, 64)
        Me.Button75.TabIndex = 121
        Me.Button75.Text = "3.11 Rek. CO uvoz+izvoz+tranzit+un.-izbor ugovora"
        '
        'Button76
        '
        Me.Button76.BackColor = System.Drawing.Color.White
        Me.Button76.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button76.ForeColor = System.Drawing.Color.Red
        Me.Button76.Location = New System.Drawing.Point(768, 328)
        Me.Button76.Name = "Button76"
        Me.Button76.Size = New System.Drawing.Size(48, 40)
        Me.Button76.TabIndex = 122
        Me.Button76.Text = "4.11d  "
        '
        'Button59
        '
        Me.Button59.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button59.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button59.ForeColor = System.Drawing.Color.Red
        Me.Button59.Location = New System.Drawing.Point(256, 128)
        Me.Button59.Name = "Button59"
        Me.Button59.Size = New System.Drawing.Size(40, 32)
        Me.Button59.TabIndex = 125
        Me.Button59.Text = "2.2d  "
        '
        'Button79
        '
        Me.Button79.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button79.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button79.ForeColor = System.Drawing.Color.Red
        Me.Button79.Location = New System.Drawing.Point(16, 432)
        Me.Button79.Name = "Button79"
        Me.Button79.Size = New System.Drawing.Size(48, 32)
        Me.Button79.TabIndex = 126
        Me.Button79.Text = "1.9 d "
        '
        'Button81
        '
        Me.Button81.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button81.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button81.ForeColor = System.Drawing.Color.Red
        Me.Button81.Location = New System.Drawing.Point(1024, 208)
        Me.Button81.Name = "Button81"
        Me.Button81.Size = New System.Drawing.Size(48, 32)
        Me.Button81.TabIndex = 128
        Me.Button81.Text = "5.8d "
        '
        'Button38
        '
        Me.Button38.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button38.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button38.ForeColor = System.Drawing.Color.Black
        Me.Button38.Location = New System.Drawing.Point(1024, 504)
        Me.Button38.Name = "Button38"
        Me.Button38.Size = New System.Drawing.Size(248, 32)
        Me.Button38.TabIndex = 129
        Me.Button38.Text = "5.15**  Broj vozova po relac. i mes."
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Info
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(8, 728)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(1264, 16)
        Me.Label11.TabIndex = 130
        Me.Label11.Text = """SRBIJA KARGO"" A.D. Sektor za informciono komunikacione tehnologije - Jovanka Pop" & _
        "ov, tel. 021 523 577  ŽAT: 800-147 "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button35
        '
        Me.Button35.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button35.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button35.ForeColor = System.Drawing.Color.Maroon
        Me.Button35.Location = New System.Drawing.Point(768, 696)
        Me.Button35.Name = "Button35"
        Me.Button35.Size = New System.Drawing.Size(248, 30)
        Me.Button35.TabIndex = 131
        Me.Button35.Text = "4.18  Rad od Makiša po iz. prelazima"
        '
        'Button41
        '
        Me.Button41.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button41.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button41.ForeColor = System.Drawing.Color.Black
        Me.Button41.Location = New System.Drawing.Point(1120, 336)
        Me.Button41.Name = "Button41"
        Me.Button41.Size = New System.Drawing.Size(152, 64)
        Me.Button41.TabIndex = 135
        Me.Button41.Text = "5.10m** Suma po obraèunima"
        '
        'Button42
        '
        Me.Button42.BackColor = System.Drawing.Color.Yellow
        Me.Button42.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button42.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button42.Location = New System.Drawing.Point(512, 624)
        Me.Button42.Name = "Button42"
        Me.Button42.Size = New System.Drawing.Size(248, 32)
        Me.Button42.TabIndex = 136
        Me.Button42.Text = "3.17  Vozovi preko 1300 t - svi"
        '
        'Button47
        '
        Me.Button47.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button47.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button47.Location = New System.Drawing.Point(912, 288)
        Me.Button47.Name = "Button47"
        Me.Button47.Size = New System.Drawing.Size(104, 32)
        Me.Button47.TabIndex = 138
        Me.Button47.Text = "4.10 r Relacije"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(1088, 464)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(184, 32)
        Me.Label16.TabIndex = 139
        Me.Label16.Text = "**  Ako su slova na dugmetu crna - ne treba osvežatati podatke"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button53
        '
        Me.Button53.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button53.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button53.ForeColor = System.Drawing.Color.Black
        Me.Button53.Location = New System.Drawing.Point(256, 544)
        Me.Button53.Name = "Button53"
        Me.Button53.Size = New System.Drawing.Size(248, 40)
        Me.Button53.TabIndex = 140
        Me.Button53.Text = "2.9 IZBOR konten. ugovora-cene za bruto i redni br. voza"
        '
        'Button62
        '
        Me.Button62.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button62.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button62.ForeColor = System.Drawing.Color.Black
        Me.Button62.Location = New System.Drawing.Point(256, 584)
        Me.Button62.Name = "Button62"
        Me.Button62.Size = New System.Drawing.Size(248, 32)
        Me.Button62.TabIndex = 141
        Me.Button62.Text = "2.10** Vozovi bez prevoznine"
        '
        'Button63
        '
        Me.Button63.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button63.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button63.ForeColor = System.Drawing.Color.Red
        Me.Button63.Location = New System.Drawing.Point(1024, 288)
        Me.Button63.Name = "Button63"
        Me.Button63.Size = New System.Drawing.Size(48, 40)
        Me.Button63.TabIndex = 142
        Me.Button63.Text = "5.11d "
        '
        'Button65
        '
        Me.Button65.BackColor = System.Drawing.Color.White
        Me.Button65.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button65.ForeColor = System.Drawing.Color.MediumBlue
        Me.Button65.Location = New System.Drawing.Point(928, 88)
        Me.Button65.Name = "Button65"
        Me.Button65.Size = New System.Drawing.Size(88, 40)
        Me.Button65.TabIndex = 143
        Me.Button65.Text = "4.1a Provera naknada"
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.Red
        Me.Button8.Location = New System.Drawing.Point(560, 200)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(200, 40)
        Me.Button8.TabIndex = 144
        Me.Button8.Text = "3.5m Sve najave.- uvoz + izvoz + tranzit+un- Izbor ug."
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button15.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button15.ForeColor = System.Drawing.Color.Red
        Me.Button15.Location = New System.Drawing.Point(296, 288)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(208, 72)
        Me.Button15.TabIndex = 145
        Me.Button15.Text = "2.7  Zbirna faktura u Eur unutr.+uvoz+izvoz+tranzit osim do i do Makiša"
        '
        'Button57
        '
        Me.Button57.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button57.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button57.ForeColor = System.Drawing.Color.Red
        Me.Button57.Location = New System.Drawing.Point(64, 432)
        Me.Button57.Name = "Button57"
        Me.Button57.Size = New System.Drawing.Size(184, 32)
        Me.Button57.TabIndex = 148
        Me.Button57.Text = "1.9  Vozovi od Makiša"
        '
        'Button78
        '
        Me.Button78.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button78.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button78.ForeColor = System.Drawing.Color.Blue
        Me.Button78.Location = New System.Drawing.Point(560, 88)
        Me.Button78.Name = "Button78"
        Me.Button78.Size = New System.Drawing.Size(200, 24)
        Me.Button78.TabIndex = 149
        Me.Button78.Text = "3.1m  Vozovi do Makiša"
        '
        'Button82
        '
        Me.Button82.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button82.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button82.ForeColor = System.Drawing.Color.Red
        Me.Button82.Location = New System.Drawing.Point(512, 112)
        Me.Button82.Name = "Button82"
        Me.Button82.Size = New System.Drawing.Size(48, 24)
        Me.Button82.TabIndex = 150
        Me.Button82.Text = "3.2d"
        '
        'Button83
        '
        Me.Button83.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button83.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button83.ForeColor = System.Drawing.Color.Red
        Me.Button83.Location = New System.Drawing.Point(560, 168)
        Me.Button83.Name = "Button83"
        Me.Button83.Size = New System.Drawing.Size(200, 32)
        Me.Button83.TabIndex = 151
        Me.Button83.Text = "3.4m Izbor ugovora-grupe"
        '
        'Button84
        '
        Me.Button84.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button84.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button84.ForeColor = System.Drawing.Color.Red
        Me.Button84.Location = New System.Drawing.Point(512, 136)
        Me.Button84.Name = "Button84"
        Me.Button84.Size = New System.Drawing.Size(48, 32)
        Me.Button84.TabIndex = 152
        Me.Button84.Text = "3.3d "
        '
        'Button87
        '
        Me.Button87.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button87.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button87.Location = New System.Drawing.Point(8, 88)
        Me.Button87.Name = "Button87"
        Me.Button87.Size = New System.Drawing.Size(48, 32)
        Me.Button87.TabIndex = 156
        Me.Button87.Text = "1.1d "
        '
        'Button88
        '
        Me.Button88.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button88.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button88.ForeColor = System.Drawing.Color.Red
        Me.Button88.Location = New System.Drawing.Point(8, 128)
        Me.Button88.Name = "Button88"
        Me.Button88.Size = New System.Drawing.Size(48, 32)
        Me.Button88.TabIndex = 157
        Me.Button88.Text = "1.2d "
        '
        'Button89
        '
        Me.Button89.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button89.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button89.ForeColor = System.Drawing.Color.Red
        Me.Button89.Location = New System.Drawing.Point(8, 248)
        Me.Button89.Name = "Button89"
        Me.Button89.Size = New System.Drawing.Size(48, 32)
        Me.Button89.TabIndex = 158
        Me.Button89.Text = "1.3d"
        '
        'Button90
        '
        Me.Button90.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button90.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button90.ForeColor = System.Drawing.Color.Red
        Me.Button90.Location = New System.Drawing.Point(8, 288)
        Me.Button90.Name = "Button90"
        Me.Button90.Size = New System.Drawing.Size(48, 32)
        Me.Button90.TabIndex = 159
        Me.Button90.Text = "1.4d"
        '
        'Button92
        '
        Me.Button92.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button92.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button92.ForeColor = System.Drawing.Color.Red
        Me.Button92.Location = New System.Drawing.Point(8, 328)
        Me.Button92.Name = "Button92"
        Me.Button92.Size = New System.Drawing.Size(48, 32)
        Me.Button92.TabIndex = 161
        Me.Button92.Text = "1.6d"
        '
        'Button94
        '
        Me.Button94.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button94.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button94.ForeColor = System.Drawing.Color.Black
        Me.Button94.Location = New System.Drawing.Point(1024, 336)
        Me.Button94.Name = "Button94"
        Me.Button94.Size = New System.Drawing.Size(96, 64)
        Me.Button94.TabIndex = 164
        Me.Button94.Text = "5.10d** Suma po obraèunima"
        '
        'Button96
        '
        Me.Button96.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button96.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button96.ForeColor = System.Drawing.Color.Black
        Me.Button96.Location = New System.Drawing.Point(256, 616)
        Me.Button96.Name = "Button96"
        Me.Button96.Size = New System.Drawing.Size(248, 48)
        Me.Button96.TabIndex = 166
        Me.Button96.Text = "2.11.Po obraè.: Železnice Sr. do 10. 8. 2015 i Srbija Kargo od 10.8.2015."
        '
        'Button97
        '
        Me.Button97.BackColor = System.Drawing.Color.White
        Me.Button97.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button97.ForeColor = System.Drawing.Color.Red
        Me.Button97.Location = New System.Drawing.Point(816, 328)
        Me.Button97.Name = "Button97"
        Me.Button97.Size = New System.Drawing.Size(200, 40)
        Me.Button97.TabIndex = 167
        Me.Button97.Text = "4.11 mŠpedicije-uv. izv. tranzit"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button98.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button98.ForeColor = System.Drawing.Color.Red
        Me.Button98.Location = New System.Drawing.Point(1072, 208)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(200, 32)
        Me.Button98.TabIndex = 168
        Me.Button98.Text = "5.8 m  CO Tr. Iz. Uv Un. po ugo"
        '
        'Button100
        '
        Me.Button100.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button100.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button100.ForeColor = System.Drawing.Color.Red
        Me.Button100.Location = New System.Drawing.Point(1072, 288)
        Me.Button100.Name = "Button100"
        Me.Button100.Size = New System.Drawing.Size(200, 40)
        Me.Button100.TabIndex = 170
        Me.Button100.Text = "5.11m Definitivni CO, IC"
        '
        'Button43
        '
        Me.Button43.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Button43.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button43.ForeColor = System.Drawing.Color.Black
        Me.Button43.Location = New System.Drawing.Point(872, 208)
        Me.Button43.Name = "Button43"
        Me.Button43.Size = New System.Drawing.Size(144, 32)
        Me.Button43.TabIndex = 172
        Me.Button43.Text = "4.7 Provera ugovora"
        '
        'Button102
        '
        Me.Button102.BackColor = System.Drawing.Color.White
        Me.Button102.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button102.ForeColor = System.Drawing.Color.Black
        Me.Button102.Location = New System.Drawing.Point(768, 368)
        Me.Button102.Name = "Button102"
        Me.Button102.Size = New System.Drawing.Size(120, 32)
        Me.Button102.TabIndex = 173
        Me.Button102.Text = "4.12i Iskaz razlike"
        '
        'Button103
        '
        Me.Button103.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button103.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button103.ForeColor = System.Drawing.Color.Red
        Me.Button103.Location = New System.Drawing.Point(552, 272)
        Me.Button103.Name = "Button103"
        Me.Button103.Size = New System.Drawing.Size(208, 64)
        Me.Button103.TabIndex = 174
        Me.Button103.Text = "3.10 Rekap. CD uvoz+izvoz+un.-izbor ugovora"
        '
        'Button39
        '
        Me.Button39.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button39.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button39.ForeColor = System.Drawing.Color.Red
        Me.Button39.Location = New System.Drawing.Point(296, 224)
        Me.Button39.Name = "Button39"
        Me.Button39.Size = New System.Drawing.Size(208, 56)
        Me.Button39.TabIndex = 175
        Me.Button39.Text = "2.6 Zbirna faktura u RSD   unutr.+uvoz+izvoz+tranzit"
        '
        'Button54
        '
        Me.Button54.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button54.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button54.ForeColor = System.Drawing.Color.Red
        Me.Button54.Location = New System.Drawing.Point(512, 272)
        Me.Button54.Name = "Button54"
        Me.Button54.Size = New System.Drawing.Size(40, 64)
        Me.Button54.TabIndex = 176
        Me.Button54.Text = "3.10d"
        '
        'Button56
        '
        Me.Button56.BackColor = System.Drawing.Color.FromArgb(CType(200, Byte), CType(255, Byte), CType(200, Byte))
        Me.Button56.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button56.ForeColor = System.Drawing.Color.Red
        Me.Button56.Location = New System.Drawing.Point(640, 336)
        Me.Button56.Name = "Button56"
        Me.Button56.Size = New System.Drawing.Size(120, 64)
        Me.Button56.TabIndex = 177
        Me.Button56.Text = "3.12 Rekap.  RO  uvoz + izvoz +un. -  izbor korisnika"
        '
        'Button86
        '
        Me.Button86.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Button86.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button86.ForeColor = System.Drawing.Color.Green
        Me.Button86.Location = New System.Drawing.Point(8, 584)
        Me.Button86.Name = "Button86"
        Me.Button86.Size = New System.Drawing.Size(128, 80)
        Me.Button86.TabIndex = 178
        Me.Button86.Text = "1.11 Rekap.  CO, IC, CD u Eur  uvoz + izvoz + tranzit+un. -  izbor kor. GODINA"
        '
        'Button95
        '
        Me.Button95.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button95.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button95.ForeColor = System.Drawing.Color.Green
        Me.Button95.Location = New System.Drawing.Point(136, 584)
        Me.Button95.Name = "Button95"
        Me.Button95.Size = New System.Drawing.Size(120, 80)
        Me.Button95.TabIndex = 179
        Me.Button95.Text = "1.12 Rekap.  RO, CD   uvoz + izvoz +un. -  izbor korisnika GODINA"
        '
        'Button77
        '
        Me.Button77.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button77.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button77.ForeColor = System.Drawing.Color.Red
        Me.Button77.Location = New System.Drawing.Point(1072, 248)
        Me.Button77.Name = "Button77"
        Me.Button77.Size = New System.Drawing.Size(200, 32)
        Me.Button77.TabIndex = 180
        Me.Button77.Text = "5.9 m Rekap. CO-Tr+Iz+Uv+Un."
        '
        'Button101
        '
        Me.Button101.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button101.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button101.ForeColor = System.Drawing.Color.Green
        Me.Button101.Location = New System.Drawing.Point(136, 544)
        Me.Button101.Name = "Button101"
        Me.Button101.Size = New System.Drawing.Size(120, 40)
        Me.Button101.TabIndex = 181
        Me.Button101.Text = "osvežite podatke za RO i CD"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(256, 168)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 48)
        Me.Button2.TabIndex = 182
        Me.Button2.Text = "2.4d  "
        '
        'Button40
        '
        Me.Button40.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button40.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button40.ForeColor = System.Drawing.Color.Red
        Me.Button40.Location = New System.Drawing.Point(256, 88)
        Me.Button40.Name = "Button40"
        Me.Button40.Size = New System.Drawing.Size(40, 32)
        Me.Button40.TabIndex = 183
        Me.Button40.Text = "2.1d  "
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label17.Font = New System.Drawing.Font("Arial Black", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label17.Location = New System.Drawing.Point(24, 168)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(208, 32)
        Me.Label17.TabIndex = 184
        Me.Label17.Text = "FAKTURE -OSTALI"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button55
        '
        Me.Button55.BackColor = System.Drawing.Color.White
        Me.Button55.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button55.ForeColor = System.Drawing.Color.MediumBlue
        Me.Button55.Location = New System.Drawing.Point(40, 208)
        Me.Button55.Name = "Button55"
        Me.Button55.Size = New System.Drawing.Size(168, 30)
        Me.Button55.TabIndex = 185
        Me.Button55.Text = "ažuriranje broja vozova"
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.Color.White
        Me.Button23.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button23.ForeColor = System.Drawing.Color.Red
        Me.Button23.Location = New System.Drawing.Point(744, 24)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(112, 40)
        Me.Button23.TabIndex = 186
        Me.Button23.Text = "osvežite podatke-tranzit "
        '
        'Button51
        '
        Me.Button51.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button51.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button51.ForeColor = System.Drawing.Color.Red
        Me.Button51.Location = New System.Drawing.Point(1024, 248)
        Me.Button51.Name = "Button51"
        Me.Button51.Size = New System.Drawing.Size(48, 32)
        Me.Button51.TabIndex = 187
        Me.Button51.Text = "5.9d "
        '
        'Button69
        '
        Me.Button69.BackColor = System.Drawing.Color.White
        Me.Button69.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button69.ForeColor = System.Drawing.Color.Black
        Me.Button69.Location = New System.Drawing.Point(888, 368)
        Me.Button69.Name = "Button69"
        Me.Button69.Size = New System.Drawing.Size(128, 32)
        Me.Button69.TabIndex = 188
        Me.Button69.Text = "4.12  DATUMI OBRADE"
        '
        'Button46
        '
        Me.Button46.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button46.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button46.ForeColor = System.Drawing.Color.Green
        Me.Button46.Location = New System.Drawing.Point(312, 504)
        Me.Button46.Name = "Button46"
        Me.Button46.Size = New System.Drawing.Size(192, 40)
        Me.Button46.TabIndex = 189
        Me.Button46.Text = "osvežite pod. za CO, IC, RO i CD svi saobraæaji"
        '
        'Button80
        '
        Me.Button80.BackColor = System.Drawing.Color.FromArgb(CType(200, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button80.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button80.ForeColor = System.Drawing.Color.OrangeRed
        Me.Button80.Location = New System.Drawing.Point(976, 24)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(120, 40)
        Me.Button80.TabIndex = 190
        Me.Button80.Text = "osvežite CD svi"
        '
        'Button85
        '
        Me.Button85.BackColor = System.Drawing.Color.White
        Me.Button85.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button85.ForeColor = System.Drawing.Color.Red
        Me.Button85.Location = New System.Drawing.Point(856, 24)
        Me.Button85.Name = "Button85"
        Me.Button85.Size = New System.Drawing.Size(120, 40)
        Me.Button85.TabIndex = 191
        Me.Button85.Text = "osvežite CO svi"
        '
        'Button91
        '
        Me.Button91.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button91.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button91.ForeColor = System.Drawing.Color.Red
        Me.Button91.Location = New System.Drawing.Point(296, 360)
        Me.Button91.Name = "Button91"
        Me.Button91.Size = New System.Drawing.Size(208, 39)
        Me.Button91.TabIndex = 192
        Me.Button91.Text = "2.7  Zbirna faktura u Eur æirilicom-Smartcargo"
        '
        'Button93
        '
        Me.Button93.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button93.Font = New System.Drawing.Font("Arial Narrow", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button93.ForeColor = System.Drawing.Color.Red
        Me.Button93.Location = New System.Drawing.Point(256, 360)
        Me.Button93.Name = "Button93"
        Me.Button93.Size = New System.Drawing.Size(40, 40)
        Me.Button93.TabIndex = 193
        Me.Button93.Text = "2.7d  "
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 22)
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.ClientSize = New System.Drawing.Size(1284, 778)
        Me.Controls.Add(Me.Button93)
        Me.Controls.Add(Me.Button91)
        Me.Controls.Add(Me.Button85)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button46)
        Me.Controls.Add(Me.Button69)
        Me.Controls.Add(Me.Button51)
        Me.Controls.Add(Me.Button23)
        Me.Controls.Add(Me.Button55)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Button40)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button101)
        Me.Controls.Add(Me.Button77)
        Me.Controls.Add(Me.Button95)
        Me.Controls.Add(Me.Button86)
        Me.Controls.Add(Me.Button56)
        Me.Controls.Add(Me.Button54)
        Me.Controls.Add(Me.Button39)
        Me.Controls.Add(Me.Button103)
        Me.Controls.Add(Me.Button102)
        Me.Controls.Add(Me.Button43)
        Me.Controls.Add(Me.Button100)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button97)
        Me.Controls.Add(Me.Button96)
        Me.Controls.Add(Me.Button94)
        Me.Controls.Add(Me.Button92)
        Me.Controls.Add(Me.Button90)
        Me.Controls.Add(Me.Button89)
        Me.Controls.Add(Me.Button88)
        Me.Controls.Add(Me.Button87)
        Me.Controls.Add(Me.Button84)
        Me.Controls.Add(Me.Button83)
        Me.Controls.Add(Me.Button82)
        Me.Controls.Add(Me.Button78)
        Me.Controls.Add(Me.Button57)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button65)
        Me.Controls.Add(Me.Button63)
        Me.Controls.Add(Me.Button62)
        Me.Controls.Add(Me.Button53)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Button47)
        Me.Controls.Add(Me.Button42)
        Me.Controls.Add(Me.Button41)
        Me.Controls.Add(Me.Button35)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button38)
        Me.Controls.Add(Me.Button81)
        Me.Controls.Add(Me.Button79)
        Me.Controls.Add(Me.Button59)
        Me.Controls.Add(Me.Button76)
        Me.Controls.Add(Me.Button75)
        Me.Controls.Add(Me.Button74)
        Me.Controls.Add(Me.Button73)
        Me.Controls.Add(Me.Button72)
        Me.Controls.Add(Me.Button52)
        Me.Controls.Add(Me.Button71)
        Me.Controls.Add(Me.Button70)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.Button68)
        Me.Controls.Add(Me.Button67)
        Me.Controls.Add(Me.Button66)
        Me.Controls.Add(Me.Button64)
        Me.Controls.Add(Me.Button61)
        Me.Controls.Add(Me.Button60)
        Me.Controls.Add(Me.Button58)
        Me.Controls.Add(Me.Button50)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Button49)
        Me.Controls.Add(Me.Button48)
        Me.Controls.Add(Me.Button45)
        Me.Controls.Add(Me.Button44)
        Me.Controls.Add(Me.Button37)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button36)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Button34)
        Me.Controls.Add(Me.Button33)
        Me.Controls.Add(Me.Button30)
        Me.Controls.Add(Me.Button32)
        Me.Controls.Add(Me.Button31)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button29)
        Me.Controls.Add(Me.Button28)
        Me.Controls.Add(Me.Button27)
        Me.Controls.Add(Me.Button26)
        Me.Controls.Add(Me.Button25)
        Me.Controls.Add(Me.Button24)
        Me.Controls.Add(Me.Button22)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button21)
        Me.Controls.Add(Me.Button20)
        Me.Controls.Add(Me.Button19)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.Text = """SRBIJA KARGO"" A. D.-CENTAR ZA KONTROLU PRIHODA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_1_1
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "left({tempTranzitCO.Ugovor},2)=['10','11','12','80','81','60'] and " & _
            "right({tempTranzitCO.Ugovor},2)= ['97','96','01'] and {@najava1}='1'"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svi
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.ServerName = "10.0.4.31"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {TempTranzitCO.Saobracaj}='4' and  left({tempTranzitCO.Ugovor},2)=['80','81','60' ] and right({tempTranzitCO.Ugovor},2)= ['97','96','01'] and {@najava1}='0'"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svi
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            ' connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {TempTranzitCO.Saobracaj}='4' and right({tempTranzitCO.Ugovor},2)=['33','44','66']  and {tempTranzitCO.Saobracaj}='4' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svi
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {TempTranzitCO.Saobracaj}='4' and {tempTranzitCO.Prevoz}='P' and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} and ({TempTranzitCO.VrstaObracuna} in ['CO', 'CD']) "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svi
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {tempTranzitCO.Prevoz}='G' and {tempTranzitCO.Saobracaj} = '4'  and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} and ({TempTranzitCO.VrstaObracuna} in ['CO', 'CD'])"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svi
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCO.Saobracaj}='4' and {TempTranzitCO.VrstaObracuna} = ['CO','CD'] and {@najava1} = '0' and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2}"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "left({TempTranzitCO.Ugovor},3) = left({?ugovor1},3) and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} and {TempTranzitCO.VrstaObracuna} = 'CO' and {TempTranzitCO.Saobracaj} = '4' and {@najava1} = '0' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " left({TempTranzitCO.Ugovor},3) = left({?ugovor1},3) and {TempTranzitCO.VrstaObracuna} = 'IC' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1_d_doM
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "  {TempTranzitCO.Najava} > '0'  and {TempTranzitCO.Saobracaj} = '4' and  {tempTranzitCO.Prevoz}= 'V' and {@najava1}='1'  and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_11_Prodos_R_vozovi_odMakisaN
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            ' repform1.CrystalReportViewer1.SelectionFormula = " left({TempTranzitCO.Ugovor},2) like ['10','80','81','60'] and right({TempTranzitCO.Ugovor},1)= '1' and {TempTranzitCO.Najava2} > '0'"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_12_lista_za_OKP_M1M2_N
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {tempTranzitCO.ObrMesec} <> {tempTranzitCO.ObrMesec2} and {TempTranzitCO.Najava2} > 'X'"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " left({TempTranzitCO.Ugovor},3) =left({?ugovor1},3) and right({TempTranzitCO.Ugovor},2) ='01' and {TempTranzitCO.Najava} > '0' and {TempTranzitCO.ObrMesec2} = {TempTranzitCO.ObrMesec} and {TempTranzitCO.Saobracaj} = '4' and  {tempTranzitCO.Prevoz}= 'V' and {@najava1}='0'  "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "{TempTranzitCO.Prevoz}= 'V' and {TempTranzitCO.Najava} > '0' and {TempTranzitCO.VrstaObracuna} in ['CO', 'IC'] and left({TempTranzitCO.Ugovor},3) =left( {?ugovor1},3)"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OKPWINROBA;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table dbo.tempTranzitCO_" & mUserID _
                                      & " SELECT SlogKalk.RecID,SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj, SlogKalk.OtpDatum, SlogKalk.PrDatum, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.UkupnoKola, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.TkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrPrevoza,SlogKalk.NarPos,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO,SlogKalk.tlNakFr, SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM, SlogRoba.SMasa, SlogRoba.RMasa, SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred, SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.PaleteR,SlogRoba.PaleteBox,SlogRoba.UTiIb,SlogRoba.UTiTara,SlogRoba.UTiRaster,SlogRoba.UTiNaknada,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr,SlogKalk.DatumObrade, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.Stitna,SlogKola.TipKola,SlogKola.Prevoznina,SlogKola.ICF " _
                                      & "into dbo.tempTranzitCO_" & mUserID _
                                      & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) FULL JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) INNER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) FULL JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                                      & "WHERE  (SlogKalk.Saobracaj='4' and Ugovori.SifraKorisnika < 300 AND Ugovori.VrstaObracuna<>'RO' AND  SlogKalk.ObrGodina='" & TextBox2.Text.Trim & "' AND SlogKalk.ObrMesec='" & TextBox1.Text.Trim & "' AND  SlogKalk.ObrGodina2< '2017' ) " _
                                      & "CREATE INDEX I1 on dbo.tempTranzitCO_" & Trim(mUserID) & " (Ugovor ASC) " _
                                      & "CREATE INDEX I2 on dbo.tempTranzitCO_" & Trim(mUserID) & " (Najava ASC) " _
                                      & "CREATE INDEX I3 on dbo.tempTranzitCO_" & Trim(mUserID) & " (OtpStanica ASC)" _
                                      & "CREATE INDEX I4 on dbo.tempTranzitCO_" & Trim(mUserID) & " (OtpBroj ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA ZA TRANZIT ! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OKPWINROBA;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table dbo.tempTranzitCOg_" & mUserID _
            & " SELECT SlogKalk.RecID,SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj, SlogKalk.OtpDatum, SlogKalk.DatumObrade, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.NajavaKola2,SlogKalk.UkupnoKola, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrSao,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO, SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKalk.tlSumaFrDin, SlogKalk.tlNakFrDin, SlogKalk.tlPrevUp, SlogKalk.tlNakUp, SlogKalk.tlNakFr, SlogKalk.tlSumaUpDin, SlogKalk.rSumaUpDin, SlogKalk.rSumaFrDin, SlogKalk.rSumaUp, SlogKalk.rSumaFr,SlogKalk.tlPrevUpDin, SlogKalk.tlPrevFrDin,SlogKalk.tlNakUpDin, SlogKalk.rPrevUpDin, SlogKalk.rPrevFrDin, SlogKalk.rNakUpDin, SlogKalk.rNakFrDin, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM,  SlogRoba.SMasa, SlogRoba.RMasa,SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred,SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.UTiIb,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.TipKola,SlogKola.Prevoznina " _
                                                  & "into dbo.tempTranzitCOg_" & mUserID _
                                                  & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) INNER JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                                                   & "WHERE  (SlogKalk.Saobracaj<'5' and Ugovori.VrstaObracuna<>'RO' AND  SlogKalk.ObrGodina ='" & TextBox5.Text.Trim & "' AND SlogKalk.ObrGodina<'2017') " _
                                                  & "CREATE INDEX I2 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Ugovor ASC) " _
                                                  & "CREATE INDEX I1 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Saobracaj ASC)" _
                                                  & "CREATE INDEX I3 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Najava ASC)" _
                                                  & "CREATE INDEX I4 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Najava2 ASC)" _
                                                  & "CREATE INDEX I5 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (OtpStanica ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA ZA UNUTR.S, UVOZ, IZVOZ I TRANZIT JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub
    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OkpWinRoba;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table dbo.tempTranzitCOg_" & mUserID _
                         & " SELECT SELECT SlogKalk.RecID,SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj, SlogKalk.OtpDatum, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.NajavaKola2, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.TkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrPrevoza,SlogKalk.NarPos,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO,SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM,  SlogRoba.SMasa, SlogRoba.RMasa,SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred,SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.PaleteR,SlogRoba.PaleteBox,SlogRoba.UTiIb,SlogRoba.UTiTara,SlogRoba.UTiRaster,SlogRoba.UTiNaknada,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.Stitna,SlogKola.TipKola,SlogKola.Prevoznina,SlogKola.ICF " _
                         & "into dbo.tempTranzitCOg_" & mUserID _
                         & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) INNER JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) INNER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                         & "WHERE  (SlogKalk.Saobracaj='4' AND SlogKalk.ObrGodina2='" & TextBox6.Text.Trim & "' and SlogKalk.ObrGodina <'2017') " _
                         & "CREATE INDEX I1 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Ugovor ASC)" _
                                                & "CREATE INDEX I2 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Najava2 ASC)" _
                                                & "CREATE INDEX I3 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (OtpStanica ASC)" _
                                                & "CREATE INDEX I4 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (OtpBroj ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA za pošiljke od Makiša JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA ZA TRANZIT ! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub



    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_8
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " right({tempTranzitCO.Ugovor},2)=['01','96','97' ] and left({tempTranzitCO.Ugovor},2)= ['10','80','60'] and  {@Pkola}='P' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_6_CO_SpedicijeN
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCO.VrstaObracuna}<>'RT' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_7_lista_za_OKP_M1jeM2_N
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_9_listaB_kratkaN
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {tempTranzitCO.VrstaObracuna} <> 'RO' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_8_listaB_N
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCO.ObrMesec} ={tempTranzitCO.ObrMesec} and {tempTranzitCO.ObrGodina} = {tempTranzitCO.ObrGodina} and {tempTranzitCO.VrstaObracuna} <> 'RO' and {tempTranzitCO.Ugovor} <> '      '  "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_10_nov
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " ({tempTranzitCO.Ugovor} in ['929100', '00'] or {tempTranzitCO.SifraTarife} in [ '36', '68' ]) "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1_d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " left({TempTranzitCO.Ugovor},3) =left({?ugovor1},3) and right({TempTranzitCO.Ugovor},2) ='01' and {TempTranzitCO.Najava} > '0' and {TempTranzitCO.ObrMesec2} = {TempTranzitCO.ObrMesec} and {TempTranzitCO.Saobracaj} = '4' and  {tempTranzitCO.Prevoz}= 'V' and {@najava1}='1'  and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_2_PrExSh_direktni_relacije_zbirN
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " mid ({tempTranzitCO.Najava},2,1)<>'X' and left({tempTranzitCO.Ugovor},2)=['02','10','11','12','80','81','98','60' ] and right({tempTranzitCO.Ugovor} ,2)=[ '01','97' ,'96','44','33' ]"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_1_PrExSh_doMakisa_relacije_zbirN
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {@najava1}='1' and left({tempTranzitCO.Ugovor},2)=['10','11','12','80','81','60' ]  "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_13_PrExSh_odMakisai_relacije_zbirN
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "left({tempTranzitCO.Najava2},1)='X'  "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_3
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            ' repform1.CrystalReportViewer1.SelectionFormula = " {@ugo} = {?ugovor} and {tempTranzitCO.Najava} > '0' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_5kon
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " right({tempTranzitCO.Ugovor},2)=['33','22','42','44'] "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        Try
            If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_3_10a_CO2god_sao
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                'connectionInf.ServerName = "NSVST20008SQL"
                connectionInf.DatabaseName = "OkpWinRoba"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        Try
            If MsgBox("Da li ste osvežili podatke u braon polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then

                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_3_16_RAD_UGOVORI_god_od_RanzirneN
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                'connectionInf.ServerName = "NSVST20008SQL"
                connectionInf.DatabaseName = "OkpWinRoba"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                repform1.CrystalReportViewer1.SelectionFormula = " {tempTranzitCOg.Najava2} > 'X' "
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_14_StimulacijeSviN_v
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OkpWinRoba"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " right({Vtranzitg.Ugovor},2)='00' and {Vtranzitg.Najava2} < '1' and {Vtranzitg.OtpDatum} in {?od} to {?do} and not ({Vtranzitg.NHM} in ['860500', '860600', '860700', '929100', '992200'])"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button44.Click
        Try
            If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_5_18
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                'connectionInf.ServerName = "NSVST20008SQL"
                connectionInf.DatabaseName = "OkpWinRoba"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                'repform1.CrystalReportViewer1.SelectionFormula = " left({tempTranzitCOg.Ugovor},2) = ['10','80','81','98','60']  "
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button49.Click
        Try
            If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_4_14_ugovor_god_mesNHM
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                'connectionInf.ServerName = "NSVST20008SQL"
                connectionInf.DatabaseName = "OkpWinRoba"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                'repform1.CrystalReportViewer1.SelectionFormula = "left({tempTranzitCOg.Ugovor},2) = left({?ugovor},2)"
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_16
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OkpWinRoba"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "{Vtranzitg.ZsIzPrelaz} = {?izlazni prelaz} and {Vtranzitg.ZsUlPrelaz} = {?ulazni prelaz} and left({Vtranzitg.Ugovor},4) = left({?ugovor},4) and left({Vtranzitg.NHM},4) like left({?NHM1},4)and {Vtranzitg.Najava} > '0' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_19_tranzit_broj_vozova_po_relacijama_i_mesecima_odMakisaView
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OkpWinRoba"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " {Vtranzitg.Prevoz} = 'V' and left({Vtranzitg.Najava2},1) = 'X' and {Vtranzitg.ObrGodina2} = {?godina}"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_14
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OkpWinRoba"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "left({tempTranzitCO.Najava2},1)='X' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub
    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub
    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Button58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button58.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1_d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "  {TempTranzitCO.Najava} > '0' and {TempTranzitCO.Saobracaj} = '4' and  {tempTranzitCO.Prevoz}= 'G' and left({TempTranzitCO.Ugovor},3) =left({?ugovor1},3) and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button60.Click
        Try
            If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_4_17
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                'connectionInf.ServerName = "NSVST20008SQL"
                connectionInf.DatabaseName = "OkpWinRoba"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                'repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCOg.NHM} = ['282990', '284440', '290420', '290490',  '290890', '291639', '292142', '292144',  '292410',  '300390', '310230', '310510',  '360100',  '360200', '360300','360410','360490', '391220', '930621', '930630','930690'] or {tempTranzitCOg.UtiNHM} = ['282990', '284440', '290420', '290490',  '290890', '291639', '292142', '292144',  '292410',  '300390', '310230', '310510',  '360100',  '360200', '360300','360410','360490', '391220', '930621', '930630','930690']"
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button61.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_5_ProveraNNmunicijaUg
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "left({tempTranzitCO.NHM},4)=['2709','2710','2711','2721','2722','2723','2724','2725','2726','2727','2728','2729','2730','2731','2732','2733','2734','2735','2736','2737','2738','2739','2740','2741','2742','2743','2744','2745','2746', '2747', '2748', '2749', '9306'] or left({tempTranzitCO.UtiNHM},4)=['2709','2710','2711','2721','2722','2723','2724','2725','2726','2727','2728','2729','2730','2731','2732','2733','2734','2735','2736','2737','2738','2739','2740','2741','2742','2743','2744','2745','2746','2747','2748','2749','9306'] "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub


    Private Sub Button64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button64.Click
        Try
            ' If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_17
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OkpWinRoba"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " (left({Vtranzitg.NHM},4) =  left({?NHM},4)  or left({Vtranzitg.UtiNHM},4) = left({?NHM},4)) and left({Vtranzitg.Ugovor},4) =left( {?ugovor},4) and {Vtranzitg.ObrGodina} = {?Godina}"
            repform1.Show()
            ' End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub


    Private Sub Button66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button66.Click
        Try
            'If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_16_god_mesNHM
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OkpWinRoba"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "left({tempTranzitCOg.ugovor},2) = left({?ugovor},2)"
            repform1.Show()
            ' End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button67.Click
        Try
            'If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            'Dim r1 As New TS_RAD_KORISNIK_GOD
            Dim r1 As New T_3_13_ugovor_god_mes_v
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OkpWinRoba"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "{Vtranzitg.ObrGodina} = {?Godina} and left({Vtranzitg.Ugovor},4) =left( {?ugovor},4) "
            repform1.Show()
            '  End If
        Catch
            '   MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub SqlDataAdapter1_RowUpdated(ByVal sender As System.Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs) Handles SqlDataAdapter1.RowUpdated

    End Sub

    Private Sub Button68_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button68.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_2_ProveraR
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {@radioloska} = 'R' or {@radioloskauti} = 'R' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New Pogresan_unos_ili_obradapodataka_v
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " {tempTranzitCO.Tara} < 8000 or {tempTranzitCO.SMasa} > 100000 or {tempTranzitCO.SMasa} < 1 or Val({tempTranzitCO.IBK})< 100000000000 or {tempTranzitCO.UTiNHM} = '992200' or ({tempTranzitCO.Naknada} > 1.00 and left({tempTranzitCO.IBK},7)='3143455' and {tempTranzitCO.ZsUlPrelaz}=['23499','12498'] and {tempTranzitCO.ZsIzPrelaz}=['23499','12498']) "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button70_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button70.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_2_ProveraR
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {@veterinarska} = 'V' or {@veterinarskauti} = 'V' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button71.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_2_ProveraR
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {@ekoloska} = 'E' or {@ekoloskaiti}= 'E'  "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_1_7_tovarena_kola_sever_jug_parametar
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " not (left({tempTranzitCOr.NHM},3) like '992') and left({tempTranzitCOr.Ugovor},2) = ['81','80','10','11'] and {@godmesec} in [totext({?Godina})+totext({?RacMesec}), totext({?godina2})+totext({?RacMesec2})] and {tempTranzitCOr.Vlasnik} = 'Z' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button52.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New U_CO2_600300tr_svi_DatKurs15
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button72.Click
        Try
            If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_4_15_Prodos_prosek_brvoz_bruto_neto
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                connectionInf.DatabaseName = "OKPWINROBA"
                'connectionInf.ServerName = "NSVST20008SQL"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                repform1.CrystalReportViewer1.SelectionFormula = " left({tempTranzitCOg.Ugovor},2) =left({?ugovor},2) and {@Najava1} = '0' and right({tempTranzitCOg.Ugovor},2) =['01','96'] and {tempTranzitCOg.ZsUlPrelaz} = {?Ulazni prelaz} and {tempTranzitCOg.ZsIzPrelaz} = {?Izlazni prelaz} "
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button73.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7aPDV
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " left({tempTranzitCO.Ugovor},3)= left({?ugovor1},3) and {tempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} and {TempTranzitCO.VrstaObracuna} ='CO' and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button74_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button74.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OKPWINROBA;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table dbo.tempTranzitCOMakis_" & mUserID _
             & " SELECT SlogKalk.RecID, SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj,SlogKalk.PrBroj, SlogKalk.OtpDatum, SlogKalk.PrDatum,  SlogKalk.DatumObrade, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.NajavaKola2,SlogKalk.UkupnoKola, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.TkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrSao,SlogKalk.NarPos,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO, SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKalk.tlSumaFrDin, SlogKalk.tlNakFrDin, SlogKalk.tlPrevUp, SlogKalk.tlNakUp, SlogKalk.tlNakFr, SlogKalk.tlSumaUpDin, SlogKalk.tlSumaUp,SlogKalk.tlSumaFr, SlogKalk.rSumaUpDin, SlogKalk.rSumaFrDin, SlogKalk.rPrevUpDin, SlogKalk.rPrevFrDin, SlogKalk.rNakUpDin, SlogKalk.rNakFrDin, SlogKalk.rSumaUp, SlogKalk.rSumaFr, SlogKalk.tlPrevUpDin, SlogKalk.tlPrevFrDin,SlogKalk.tlNakUpDin, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM,  SlogRoba.SMasa, SlogRoba.RMasa,SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred,SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.PaleteR,SlogRoba.PaleteBox,SlogRoba.UTiIb,SlogRoba.UTiTara,SlogRoba.UTiRaster,SlogRoba.UTiNaknada,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.Stitna,SlogKola.TipKola,SlogKola.Prevoznina,SlogKola.ICF " _
                                                  & "into dbo.tempTranzitCOMakis_" & mUserID _
                                                  & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) INNER JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                                                   & "WHERE  (SlogKalk.Saobracaj<'5' and Ugovori.VrstaObracuna<>'RD' AND  SlogKalk.ObrGodina2 ='" & TextBox2.Text.Trim & "' AND SlogKalk.ObrMesec2 ='" & TextBox1.Text.Trim & "' AND  SlogKalk.ObrGodina2<'2017') " _
                                                  & "CREATE INDEX I2 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Ugovor ASC) " _
                                                  & "CREATE INDEX I1 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Saobracaj ASC)" _
                                                  & "CREATE INDEX I3 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Najava ASC)" _
                                                  & "CREATE INDEX I4 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Najava2 ASC)" _
                                                  & "CREATE INDEX I5 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (OtpStanica ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA ZA UVOZ IZVOZ I TRANZIT JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA ZA UVOZ IZVOZ I TRANZIT! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button75_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button75.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_10a
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button76_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button76.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_11d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCOMakis_t004.VrstaObracuna} = {?VRSTA OVRACUNA} "
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub



    Private Sub Button59_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button59.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " left({tempTranzitCO.Ugovor},3)= left({?ugovor1},3) and {tempTranzitCO.Saobracaj}='4' and {tempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2}"
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button79_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button79.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_1_9_d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "left({TempTranzitCO.Ugovor},2) = left({?ugovor1},2) and {TempTranzitCO.ObrMesec2} = {?RacMesec} and {TempTranzitCO.Saobracaj} = '4' and {TempTranzitCO.Najava2} > 'X' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub



    Private Sub Button81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button81.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_8d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " {TempTranzitCO.ObrMesec2} = {?RacMesec}and {TempTranzitCO.VrstaObracuna} in ['CO', 'IC'] "
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_15
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " {Vtranzitg.ObrGodina} = {?godina} and {Vtranzitg.Prevoz} = 'V'  "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_18_Prodos_god_relacije_samoN2N
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            ' connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OkpWinRoba"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {tempTranzitCOg.Najava2} > 'X' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_10aa
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " {KP211ung.ObrMesec2} = {?RacMesec}  "
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        Try
            If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_3_15
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                'connectionInf.ServerName = "NSVST20008SQL"
                connectionInf.DatabaseName = "OKPWINROBA"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                'repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCOg.Prevoz} = 'V' "
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik2;integrated security=false;data source=10.0.4.39;persist security info=False;initial catalog=OkpWinRoba;password=roba2012"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        Dim TransPretBD As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table radnik2.tempTranzitCO_" & mUserID _
                                      & " SELECT SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj, SlogKalk.OtpDatum, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.NajavaKola2, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.TkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrPrevoza,SlogKalk.NarPos,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO,SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM, SlogRoba.SMasa, SlogRoba.RMasa, SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred, SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.PaleteR,SlogRoba.PaleteBox,SlogRoba.UTiIb,SlogRoba.UTiTara,SlogRoba.UTiRaster,SlogRoba.UTiNaknada,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.Stitna,SlogKola.TipKola,SlogKola.Prevoznina,SlogKola.ICF " _
                                      & "into radnik2.tempTranzitCO_" & mUserID _
                                      & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) FULL JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) INNER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) FULL JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                                      & "WHERE  (SlogKalk.Saobracaj='4' AND Ugovori.VrstaObracuna<>'RO' AND  SlogKalk.ObrGodina='" & TextBox2.Text.Trim & "' AND SlogKalk.ObrMesec='" & TextBox1.Text.Trim & "' ) " _
                                      & "CREATE INDEX I1 on radnik2.tempTranzitCO_" & Trim(mUserID) & " (Ugovor ASC) " _
                                      & "CREATE INDEX I2 on radnik2.tempTranzitCO_" & Trim(mUserID) & " (Najava ASC) " _
                                      & "CREATE INDEX I3 on radnik2.tempTranzitCO_" & Trim(mUserID) & " (OtpStanica ASC)" _
                                      & "CREATE INDEX I4 on radnik2.tempTranzitCO_" & Trim(mUserID) & " (OtpBroj ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            cn.Close()
            cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OkpWinRoba;password=roba2006"
            cn.ConnectionString = cnT
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                TransPretBD = cn.BeginTransaction("ZapisiVD")
                MyComandPretB.Transaction = TransPretBD
                Try
                    MyComandPretB.CommandText = "Drop table OkpWinRoba.dbo.tempTranzitCO_" & Trim(mUserID)
                    MyComandPretB.ExecuteNonQuery()
                Catch
                    MsgBox(Err.Description())
                End Try
                MyComandPretB.CommandText = "SELECT * INTO OkpWinRoba.dbo.tempTranzitCO_" & Trim(mUserID) & " FROM OPENROWSET('sqloledb','10.0.4.39';'radnik2';'roba2012','SELECT * FROM OkpWinRoba.radnik2.tempTranzitCO_" & Trim(mUserID) & "' ) AS a"
                MyComandPretB.ExecuteNonQuery()
                TransPretBD.Commit()
            Catch ex As Exception
                MsgBox("NIJE USPELO PREUZIMANJE PODATAKA ZA IZVOZ ! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
                TransPretBD.Rollback("ZapisiVD")
                MyComandPretB.ResetCommandTimeout()
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA ZA IZVOZ ! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            Try
                TransPretB.Rollback("ZapisiV")
            Catch
            End Try
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_10_CO_SpedicijeN_relacije
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button53.Click
        Try
            'If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_9nov
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "left({Vtranzitg.Ugovor},6) = left({?ugovor},6) and {Vtranzitg.ObrGodina} = {?godina}  "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button62.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_10
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            ' repform1.CrystalReportViewer1.SelectionFormula = " {Vtranzitg.ObrGodina} = {?godina} and {Vtranzitg.Prevoz} = 'V' "
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button63.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_11ad
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " {TempTranzitCO.ObrMesec2} = {?RacMesec}"
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button65.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_1a_provera_naknad
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " {TempTranzitCO.ObrMesec2} = {?RacMesec}"
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " left({TempTranzitCO.Ugovor},3) =left({?ugovor1},3) and right({TempTranzitCO.Ugovor},2) ='01' and {TempTranzitCO.Najava} > '0' and {TempTranzitCO.ObrMesec2} = {TempTranzitCO.ObrMesec} and {TempTranzitCO.Saobracaj} = '4' and  {tempTranzitCO.Prevoz}= 'V' and {@najava1}='1'  "
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7aPDV
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " left({tempTranzitCO.Ugovor},3)= left({?ugovor1},3) and {TempTranzitCO.VrstaObracuna} ='CO' and {@najava1} = '0' and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button57.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_1_9
            'Dim r1 As New T_2_8b
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "left({TempTranzitCO.Ugovor},2) like ['10','80','81'] and right({TempTranzitCO.Ugovor},2)='01' and {TempTranzitCO.Najava2} > '0' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button78_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button78.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1_doM
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "  right({TempTranzitCO.Ugovor},2) ='01' and {TempTranzitCO.Najava} > '0' and {TempTranzitCO.Saobracaj} = '4' and  {tempTranzitCO.Prevoz}= 'V' and {@najava1}='1'  "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button82.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1_d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " left({TempTranzitCO.Ugovor},3) =left({?ugovor1},3) and right({TempTranzitCO.Ugovor},2) ='01' and {TempTranzitCO.Najava} > '0' and {TempTranzitCO.ObrMesec2} = {TempTranzitCO.ObrMesec} and {TempTranzitCO.Saobracaj} = '4' and  {tempTranzitCO.Prevoz}= 'V' and {@najava1}='0' and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button83_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button83.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {TempTranzitCO.Najava} > '0' and {TempTranzitCO.Saobracaj} = '4' and  {tempTranzitCO.Prevoz}= 'G' and left({TempTranzitCO.Ugovor},3) =left({?ugovor1},3) "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button84_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button84.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_1_d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " left({TempTranzitCO.Ugovor},3) =left({?ugovor1},3) and {TempTranzitCO.Najava} > '0' and {TempTranzitCO.ObrMesec2} = {TempTranzitCO.ObrMesec} and {TempTranzitCO.Saobracaj} = '4' and  {tempTranzitCO.Prevoz}= 'V' and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2}  "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub




    Private Sub Button89_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button89.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svidd
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            ' connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = " {tempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} and right({tempTranzitCO.Ugovor},2)=['33','66','44'] and {tempTranzitCO.Saobracaj}='4' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button87_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button87.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_1_1_d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCO.DatumObrade} >= {?dat o 1} and left({tempTranzitCO.Ugovor},2)=['02','10','11','12','80','81','60'] and right({tempTranzitCO.Ugovor},2)= ['97','96','01'] and {@najava1}='1' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button88_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button88.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svidd
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} and {TempTranzitCO.Saobracaj}='4' and  left({tempTranzitCO.Ugovor},2)=['80','81','60' ] and right({tempTranzitCO.Ugovor},2)= ['97','96','01'] and {@najava1}='0' "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button90_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button90.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svidd
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCO.Prevoz}='P' and {tempTranzitCO.Saobracaj} = '4'  and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} and ({TempTranzitCO.VrstaObracuna} in ['CO', 'CD']) and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2}"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button92_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button92.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svidd
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCO.Prevoz}='G' and {tempTranzitCO.Saobracaj} = '4'  and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} and ({TempTranzitCO.VrstaObracuna} in ['CO', 'CD']) and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2}"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button94_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button94.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_10aad
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            ' repform1.CrystalReportViewer1.SelectionFormula = "left({tempTranzitCO.Ugovor},2)= left({?ugovor},2) and right({tempTranzitCO.Ugovor},2)=['33','44','22'] and {tempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button96_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button96.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_10aRdo_i_od10_8_2015bb
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            ' repform1.CrystalReportViewer1.SelectionFormula = "left({tempTranzitCO.Ugovor},2)= left({?ugovor},2) and right({tempTranzitCO.Ugovor},2)=['33','44','22'] and {tempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button97_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button97.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_4_11
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "{tempTranzitCOMakis_t004.VrstaObracuna} = {?VRSTA OVRACUNA} "
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_8
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " {TempTranzitCO.ObrMesec2} = {?RacMesec}and {TempTranzitCO.VrstaObracuna} in ['CO', 'IC'] "
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button100.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_11a
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            ' repform1.CrystalReportViewer1.SelectionFormula = " {TempTranzitCO.ObrMesec2} = {?RacMesec} and {TempTranzitCO.VrstaObracuna} in ['CO', 'IC'] "
            repform1.Show()
            '-----------------------------------------------
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button43_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New proveraug
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button102.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New IskazRazlike_J
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button103.Click
        Try
            If MsgBox("Da li ste pozvali listu provere podataka u bazi na dugmetu 4.1?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_3_10a_Eur_svi_KP211UNG
                'Dim r1 As New T_3_10a_Din_d
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                connectionInf.DatabaseName = "OKPWINROBA"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New U_CO2_600300tr_svi_DatKurs15
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button56.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_3_10a_RO_nov
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button95_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button95.Click
        Try
            If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_3_10a_RO2god_nov
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                'connectionInf.ServerName = "NSVST20008SQL"
                connectionInf.DatabaseName = "OkpWinRoba"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button86_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button86.Click
        Try
            If MsgBox("Da li ste osvežili podatke u zelenom polju ?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_3_10a_CO2god
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                'connectionInf.ServerName = "NSVST20008SQL"
                connectionInf.DatabaseName = "OkpWinRoba"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button77_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button77.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_9
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button54.Click
        Try
            If MsgBox("Da li ste pozvali listu provere podataka u bazi na dugmetu 4.1?", MsgBoxStyle.OKCancel, "Upozorenje!") = MsgBoxResult.OK Then
                Dim repform1 As New IZVESTAJ
                Dim SelectFormula As String
                Dim r1 As New T_3_10a_Eur_svi_KP211UNG
                'Dim r1 As New T_3_10a_Din_d
                repform1.CrystalReportViewer1.ReportSource = r1
                Dim logOnInf As New TableLogOnInfo
                Dim connectionInf As New ConnectionInfo
                Dim int As New ConnectionState
                connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                connectionInf.ServerName = "10.0.4.31"
                connectionInf.DatabaseName = "OKPWINROBA"
                connectionInf.UserID = "radnik"
                connectionInf.Password = "roba2006"
                repform1.Show()
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "left({TempTranzitCO.Ugovor},3) = left({?ugovor1},3) and {TempTranzitCO.VrstaObracuna} = 'IC' and {tempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_2_7a_svidd
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            repform1.CrystalReportViewer1.SelectionFormula = "{TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} and {TempTranzitCO.VrstaObracuna} = ['CO','CD']  and {TempTranzitCO.Saobracaj} = '4' and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button55.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OKPWINROBA;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "Drop table radnik.tabVozovi " _
               & "(SELECT  dbo.SlogKola.RecID,dbo.SlogKalk.ObrMesec,dbo.SlogKalk.ObrGodina,dbo.SlogKalk.Saobracaj,dbo.SlogKalk.Ugovor,dbo.SlogKalk.Najava, dbo.SlogKola.IBK into tmp1 FROM SlogKalk INNER JOIN SlogKola ON SlogKalk.RecID=SlogKola.RecID WHERE  dbo.SlogKalk.Saobracaj='4' AND LEN(Najava)>5 and  SUBSTRING(Ugovor,1,6) in ('961633','961533','981633','601633','111666','121533','741644') AND SUBSTRING(Najava,2,1)<>'x' AND ObrGodina='2016') " _
               & "SELECT Min(RecID) as ID,Ugovor,Najava,MIN(Cast(ObrMesec as Int)) as M,ObrGodina as G,DuplaNajava='1' into tmp2 FROM tmp1 " _
               & "GROUP BY Ugovor,Najava,ObrGodina " _
               & "ORDER BY Ugovor,Najava,ObrGodina " _
               & "SELECT Max(RecID) as ID,Ugovor,Najava,MAX(Cast(ObrMesec as Int))as M, ObrGodina as G,DuplaNajava='0' into tmp3 FROM tmp1 " _
               & "GROUP BY Ugovor,Najava,ObrGodina " _
               & "ORDER BY Ugovor,Najava,ObrGodina " _
               & "Select * into tmp4 from tmp3 where tmp3.ID not in (SELECT tmp2.ID FROM tmp2) " _
               & "SELECT tmp4.ID,tmp4.Ugovor,tmp4.Najava,tmp4.M,tmp4.G,tmp4.DuplaNajava into tmp5 From tmp4 INNER JOIN tmp2 ON tmp4.Ugovor=tmp2.Ugovor and tmp4.Najava=tmp2.Najava and tmp4.M > tmp2.M and tmp2.G=tmp4.G " _
               & "SELECT * into tabVozovi " _
               & "FROM tmp2 " _
               & "UNION " _
               & "SELECT * " _
               & "FROM tmp5 " _
               & "DROP TABLE tmp1 " _
               & "DROP TABLE tmp2 " _
               & "DROP TABLE tmp3 " _
               & "DROP TABLE tmp4 " _
               & "DROP TABLE tmp5 "
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("BROJ VOZOVA JE AŽURIRAN!", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO AŽURIRANJE BROJA VOZOVA", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OKPWINROBA;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table dbo.tempTranzitCOMakis_" & mUserID _
             & " SELECT SlogKalk.RecID, SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj,SlogKalk.PrBroj, SlogKalk.OtpDatum, SlogKalk.PrDatum, SlogKalk.DatumObrade, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.NajavaKola2,SlogKalk.UkupnoKola, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.TkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrSao,SlogKalk.NarPos,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO, SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKalk.tlSumaFrDin, SlogKalk.tlNakFrDin, SlogKalk.tlPrevUp, SlogKalk.tlNakUp, SlogKalk.tlNakFr, SlogKalk.tlSumaUpDin, SlogKalk.tlPrevUpDin, SlogKalk.tlPrevFrDin,SlogKalk.tlNakUpDin, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM,  SlogRoba.SMasa, SlogRoba.RMasa,SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred,SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.PaleteR,SlogRoba.PaleteBox,SlogRoba.UTiIb,SlogRoba.UTiTara,SlogRoba.UTiRaster,SlogRoba.UTiNaknada,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.Stitna,SlogKola.TipKola,SlogKola.Prevoznina,SlogKola.ICF " _
                                                  & "into dbo.tempTranzitCOMakis_" & mUserID _
                                                  & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) INNER JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                                                   & "WHERE  (SlogKalk.Saobracaj='4' and Ugovori.VrstaObracuna<>'RC' AND  SlogKalk.ObrGodina ='" & TextBox2.Text.Trim & "' AND SlogKalk.ObrMesec2 ='" & TextBox1.Text.Trim & "' AND  SlogKalk.ObrGodina2<'2017') " _
                                                  & "CREATE INDEX I2 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Ugovor ASC) " _
                                                  & "CREATE INDEX I1 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Saobracaj ASC)" _
                                                  & "CREATE INDEX I3 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Najava ASC)" _
                                                  & "CREATE INDEX I4 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Najava2 ASC)" _
                                                  & "CREATE INDEX I5 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (OtpStanica ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA ZA TRANZIT JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA ZA TRANZIT! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_5_9d
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "{TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} and {TempTranzitCO.VrstaObracuna} = ['CO','CD']  and {TempTranzitCO.Saobracaj} = '4' and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button69_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button69.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New T_DATUMI_OBRADE
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            'connectionInf.ServerName = "NSVST20008SQL"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = "{TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} and {TempTranzitCO.VrstaObracuna} = ['CO','CD']  and {TempTranzitCO.Saobracaj} = '4' and {TempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button101.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OKPWINROBA;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table dbo.tempTranzitCOg_" & mUserID _
             & " SELECT SlogKalk.RecID,SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj, SlogKalk.OtpDatum, SlogKalk.DatumObrade, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.NajavaKola2,SlogKalk.UkupnoKola, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrSao,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO, SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKalk.tlSumaFrDin, SlogKalk.tlNakFrDin, SlogKalk.tlPrevUp, SlogKalk.tlNakUp, SlogKalk.tlNakFr, SlogKalk.tlSumaUpDin, SlogKalk.rSumaUpDin, SlogKalk.rSumaFrDin, SlogKalk.rSumaUp, SlogKalk.rSumaFr,SlogKalk.tlPrevUpDin, SlogKalk.tlPrevFrDin,SlogKalk.tlNakUpDin, SlogKalk.rPrevUpDin, SlogKalk.rPrevFrDin, SlogKalk.rNakUpDin, SlogKalk.rNakFrDin, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM,  SlogRoba.SMasa, SlogRoba.RMasa,SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred,SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.UTiIb,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.TipKola,SlogKola.Prevoznina " _
                                                  & "into dbo.tempTranzitCOg_" & mUserID _
                                                  & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) INNER JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                                                   & "WHERE  (SlogKalk.Saobracaj<'5' and Ugovori.VrstaObracuna<>'CO' and Ugovori.VrstaObracuna<>'IC' AND  SlogKalk.ObrGodina ='" & TextBox5.Text.Trim & "' AND SlogKalk.ObrGodina<'2017') " _
                                                  & "CREATE INDEX I2 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Ugovor ASC) " _
                                                  & "CREATE INDEX I1 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Saobracaj ASC)" _
                                                  & "CREATE INDEX I3 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Najava ASC)" _
                                                  & "CREATE INDEX I4 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Najava2 ASC)" _
                                                  & "CREATE INDEX I5 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (OtpStanica ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA ZA UNUTR.S, UVOZ, IZVOZ I TRANZIT JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OKPWINROBA;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table dbo.tempTranzitCOg_" & mUserID _
             & " SELECT SlogKalk.RecID,SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj, SlogKalk.OtpDatum, SlogKalk.DatumObrade, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.NajavaKola2,SlogKalk.UkupnoKola, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrSao,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO, SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKalk.tlSumaFrDin, SlogKalk.tlNakFrDin, SlogKalk.tlPrevUp, SlogKalk.tlNakUp, SlogKalk.tlNakFr, SlogKalk.tlSumaUpDin, SlogKalk.rSumaUpDin, SlogKalk.rSumaFrDin, SlogKalk.rSumaUp, SlogKalk.rSumaFr,SlogKalk.tlPrevUpDin, SlogKalk.tlPrevFrDin,SlogKalk.tlNakUpDin, SlogKalk.rPrevUpDin, SlogKalk.rPrevFrDin, SlogKalk.rNakUpDin, SlogKalk.rNakFrDin, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM,  SlogRoba.SMasa, SlogRoba.RMasa,SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred,SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.UTiIb,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.TipKola,SlogKola.Prevoznina " _
                                                  & "into dbo.tempTranzitCOg_" & mUserID _
                                                  & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) INNER JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                                                   & "WHERE  (SlogKalk.Saobracaj<'5' and Ugovori.VrstaObracuna<>'RD' and SlogKalk.SifraTarife='00' AND  SlogKalk.ObrGodina ='" & TextBox5.Text.Trim & "' AND SlogKalk.ObrGodina<'2017') " _
                                                  & "CREATE INDEX I2 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Ugovor ASC) " _
                                                  & "CREATE INDEX I1 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Saobracaj ASC)" _
                                                  & "CREATE INDEX I3 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Najava ASC)" _
                                                  & "CREATE INDEX I4 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (Najava2 ASC)" _
                                                  & "CREATE INDEX I5 on dbo.tempTranzitCOg_" & Trim(mUserID) & " (OtpStanica ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA ZA UNUTR.S, UVOZ, IZVOZ I TRANZIT JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OKPWINROBA;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table dbo.tempTranzitCOMakis_" & mUserID _
             & " SELECT SlogKalk.RecID, SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj,SlogKalk.PrBroj, SlogKalk.OtpDatum, SlogKalk.PrDatum,  SlogKalk.DatumObrade, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.NajavaKola2,SlogKalk.UkupnoKola, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.TkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrSao,SlogKalk.NarPos,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO, SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKalk.tlSumaFrDin, SlogKalk.tlNakFrDin, SlogKalk.tlPrevUp, SlogKalk.tlNakUp, SlogKalk.tlNakFr, SlogKalk.tlSumaUpDin, SlogKalk.tlSumaUp,SlogKalk.tlSumaFr, SlogKalk.rSumaUpDin, SlogKalk.rSumaFrDin, SlogKalk.rPrevUpDin, SlogKalk.rPrevFrDin, SlogKalk.rNakUpDin, SlogKalk.rNakFrDin, SlogKalk.rSumaUp, SlogKalk.rSumaFr, SlogKalk.tlPrevUpDin, SlogKalk.tlPrevFrDin,SlogKalk.tlNakUpDin, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM,  SlogRoba.SMasa, SlogRoba.RMasa,SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred,SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.PaleteR,SlogRoba.PaleteBox,SlogRoba.UTiIb,SlogRoba.UTiTara,SlogRoba.UTiRaster,SlogRoba.UTiNaknada,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.Stitna,SlogKola.TipKola,SlogKola.Prevoznina,SlogKola.ICF " _
                                                  & "into dbo.tempTranzitCOMakis_" & mUserID _
                                                  & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) INNER JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                                                   & "WHERE  (SlogKalk.Saobracaj<'5' and left(Ugovori.VrstaObracuna,1)='C' and left(SlogKalk.Ugovor,3)<'088' AND  SlogKalk.ObrGodina ='" & TextBox2.Text.Trim & "' AND SlogKalk.ObrMesec ='" & TextBox1.Text.Trim & "' AND  SlogKalk.ObrGodina<'2017') " _
                                                  & "CREATE INDEX I2 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Ugovor ASC) " _
                                                  & "CREATE INDEX I1 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Saobracaj ASC)" _
                                                  & "CREATE INDEX I3 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Najava ASC)" _
                                                  & "CREATE INDEX I4 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Najava2 ASC)" _
                                                  & "CREATE INDEX I5 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (OtpStanica ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA ZA UVOZ IZVOZ I TRANZIT JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA ZA UVOZ IZVOZ I TRANZIT! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button85_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button85.Click
        Dim cn As New SqlClient.SqlConnection
        Dim cnT As String
        cnT = "packet size=4096;user id=radnik;integrated security=false;data source=10.0.4.31;persist security info=False;initial catalog=OKPWINROBA;password=roba2006"
        cn.ConnectionString = cnT
        cn.Open()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim MyComandPretB As New SqlClient.SqlCommand
        Dim TransPretB As SqlClient.SqlTransaction
        MyComandPretB.Connection = cn
        Try
            TransPretB = cn.BeginTransaction("ZapisiV")
            MyComandPretB.Transaction = TransPretB
            MyComandPretB.CommandText = "drop table dbo.tempTranzitCOMakis_" & mUserID _
             & " SELECT SlogKalk.RecID, SlogKalk.OtpUprava, SlogKalk.OtpStanica, SlogKalk.OtpBroj,SlogKalk.PrBroj, SlogKalk.OtpDatum, SlogKalk.PrDatum,  SlogKalk.DatumObrade, SlogKalk.ObrMesec,SlogKalk.IzEtiketa,SlogKalk.ZsUlPrelaz,SlogKalk.ZsIzPrelaz, SlogKalk.ObrMesec2, SlogKalk.ObrGodina2,SlogKalk.PrUprava, SlogKalk.Najava, SlogKalk.NajavaKola,SlogKalk.NajavaKola2,SlogKalk.UkupnoKola, SlogKalk.Ugovor,SlogKalk.SifraTarife,SlogKalk.Posiljalac,SlogKalk.SkmZS,SlogKalk.TkmZS,SlogKalk.Primalac,SlogKalk.PlatilacFRR,SlogKalk.PlatilacNFR,SlogKalk.VrPos,SlogKalk.VrSao,SlogKalk.NarPos,SlogKalk.StanicaRee,SlogKalk.SifraIzjave,SlogKalk.tlValuta,SlogKalk.tlNakCO, SlogKalk.tlNakCO82, SlogKalk.tlPrevFr, SlogKalk.tlSumaFrDin, SlogKalk.tlNakFrDin, SlogKalk.tlPrevUp, SlogKalk.tlNakUp, SlogKalk.tlNakFr, SlogKalk.tlSumaUpDin, SlogKalk.rSumaUpDin, SlogKalk.rSumaFrDin, SlogKalk.rPrevUpDin, SlogKalk.rPrevFrDin, SlogKalk.rNakUpDin, SlogKalk.rNakFrDin, SlogKalk.rSumaUp, SlogKalk.rSumaFr, SlogKalk.tlPrevUpDin, SlogKalk.tlPrevFrDin,SlogKalk.tlNakUpDin, SlogKola.IBK, SlogKola.Tara, SlogRoba.NHM,  SlogRoba.SMasa, SlogRoba.RMasa,SlogRoba.UtiTip, Ugovori.VrstaObracuna, SlogRoba.NHMRazred,SlogRoba.RID, SlogRoba.RIDRazred,SlogRoba.RIDKlasa,SlogRoba.RobaStavka,SlogRoba.Vozstav,SlogRoba.VozStavSifra,SlogRoba.PaleteR,SlogRoba.PaleteBox,SlogRoba.UTiIb,SlogRoba.UTiTara,SlogRoba.UTiRaster,SlogRoba.UTiNaknada,SlogRoba.UTiNHM,SlogRoba.UTiPredajniList,co_german.Nemacki, SlogKalk.PrStanica, SlogKalk.Najava2, SlogKalk.ObrGodina, Komitent.Naziv, Komitent.Mesto, Komitent.Adresa, Komitent.Zemlja, SlogKalk.Prevoz,SlogKalk.rPrevFr,SlogKalk.rNakFr, SlogKola.KolaStavka, ZsPrelazi.SifraPrelaza4,ZsPrelazi_1.SifraPrelaza4 as prel,ZsPrelazi.Naziv as naziv1,ZsPrelazi_1.Naziv as naziv2, SlogKalk.Saobracaj, SlogNaknada.Iznos, SlogNaknada.SifraNaknade,SlogNaknada.IvicniBroj,SlogNaknada.Valuta,SlogNaknada.Kolicina,SlogKola.Naknada,SlogKola.Serija,SlogKola.Vlasnik,SlogKola.Osovine,SlogKola.Stitna,SlogKola.TipKola,SlogKola.Prevoznina,SlogKola.ICF " _
                                                  & "into dbo.tempTranzitCOMakis_" & mUserID _
                                                  & " FROM   (((((OkpWinRoba.dbo.SlogNaknada SlogNaknada FULL OUTER JOIN ((OkpWinRoba.dbo.SlogRoba SlogRoba INNER JOIN OkpWinRoba.dbo.SlogKola SlogKola ON ((SlogRoba.RecID=SlogKola.RecID) AND (SlogRoba.Stanica=SlogKola.Stanica)) AND (SlogRoba.KolaStavka=SlogKola.KolaStavka)) INNER JOIN OkpWinRoba.dbo.SlogKalk SlogKalk ON (SlogKola.RecID=SlogKalk.RecID) AND (SlogKola.Stanica=SlogKalk.Stanica)) ON (SlogNaknada.RecID=SlogKalk.RecID) AND (SlogNaknada.Stanica=SlogKalk.Stanica)) INNER JOIN OkpWinRoba.dbo.co_german co_german ON SlogKalk.Prevoz=co_german.Prevoz) INNER JOIN OkpWinRoba.dbo.Ugovori Ugovori ON SlogKalk.Ugovor=Ugovori.BrojUgovora) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi_1 ON SlogKalk.ZsIzPrelaz=ZsPrelazi_1.SifraPrelaza) FULL OUTER JOIN OkpWinRoba.dbo.ZsPrelazi ZsPrelazi ON SlogKalk.ZsUlPrelaz=ZsPrelazi.SifraPrelaza) INNER JOIN OkpWinRoba.dbo.Komitent Komitent ON Ugovori.SifraKorisnika=Komitent.Sifra " _
                                                   & "WHERE  (SlogKalk.Saobracaj<'5' and Ugovori.VrstaObracuna='CO' AND  SlogKalk.ObrGodina2 ='" & TextBox2.Text.Trim & "' AND SlogKalk.ObrMesec2 ='" & TextBox1.Text.Trim & "' AND  SlogKalk.ObrGodina2<'2017') " _
                                                  & "CREATE INDEX I2 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Ugovor ASC) " _
                                                  & "CREATE INDEX I1 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Saobracaj ASC)" _
                                                  & "CREATE INDEX I3 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Najava ASC)" _
                                                  & "CREATE INDEX I4 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (Najava2 ASC)" _
                                                  & "CREATE INDEX I5 on dbo.tempTranzitCOMakis_" & Trim(mUserID) & " (OtpStanica ASC)"
            MyComandPretB.CommandTimeout = 200000
            Me.Cursor = Cursors.AppStarting
            MyComandPretB.ExecuteNonQuery()
            TransPretB.Commit()
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            MsgBox("PREUZIMANJE PODATAKA ZA UVOZ IZVOZ I TRANZIT JE USPEŠNO ZAVRŠENO !", MsgBoxStyle.Information, "USPEŠNO PREUZIMANJE PODATAKA")
        Catch
            MsgBox("NIJE USPELO PREUZIMANJE PODATAKA ZA UVOZ IZVOZ I TRANZIT! POKUŠAJTE PONOVO !!", MsgBoxStyle.Information, "GREŠKA KOD PREUZIMANJA PODATAKA")
            TransPretB.Rollback("ZapisiV")
            MyComandPretB.ResetCommandTimeout()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button91_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button91.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New U_CO2_600300tr_svi_DatBezKursa15_3C
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " left({tempTranzitCO.Ugovor},3)= left({?ugovor1},3) and {tempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} and {TempTranzitCO.VrstaObracuna} ='CO' and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button93_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button93.Click
        Try
            Dim repform1 As New IZVESTAJ
            Dim SelectFormula As String
            Dim r1 As New U_CO2_600300tr_svi_DatBezKursa15_3C
            repform1.CrystalReportViewer1.ReportSource = r1
            Dim logOnInf As New TableLogOnInfo
            Dim connectionInf As New ConnectionInfo
            Dim int As New ConnectionState
            connectionInf = repform1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            connectionInf.ServerName = "10.0.4.31"
            connectionInf.DatabaseName = "OKPWINROBA"
            connectionInf.UserID = "radnik"
            connectionInf.Password = "roba2006"
            'repform1.CrystalReportViewer1.SelectionFormula = " left({tempTranzitCO.Ugovor},3)= left({?ugovor1},3) and {tempTranzitCO.DatumObrade} in {?dat o 1} to {?dat o 2} and {TempTranzitCO.VrstaObracuna} ='CO' and {TempTranzitCO.ObrMesec} = {TempTranzitCO.ObrMesec2} "
            repform1.Show()
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
End Class

