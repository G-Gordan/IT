Public Class BlagajnaSaCO
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
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUpucenoRazlika As System.Windows.Forms.Label
    Friend WithEvents lblFrankoRazlika As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents FR_Stanica As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents UP_Stanica As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.lblUpucenoRazlika = New System.Windows.Forms.Label
        Me.lblFrankoRazlika = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.FR_Stanica = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.UP_Stanica = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.GroupBox6.Controls.Add(Me.lblUpucenoRazlika)
        Me.GroupBox6.Controls.Add(Me.lblFrankoRazlika)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.FR_Stanica)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.UP_Stanica)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(248, 128)
        Me.GroupBox6.TabIndex = 455
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = " [ NAPLACENO NA BLAGAJNI UZ CO] "
        '
        'lblUpucenoRazlika
        '
        Me.lblUpucenoRazlika.BackColor = System.Drawing.Color.White
        Me.lblUpucenoRazlika.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUpucenoRazlika.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblUpucenoRazlika.Location = New System.Drawing.Point(128, 80)
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
        Me.lblFrankoRazlika.Location = New System.Drawing.Point(16, 80)
        Me.lblFrankoRazlika.Name = "lblFrankoRazlika"
        Me.lblFrankoRazlika.Size = New System.Drawing.Size(104, 19)
        Me.lblFrankoRazlika.TabIndex = 4901
        Me.lblFrankoRazlika.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label22
        '
        Me.Label22.Enabled = False
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label22.Location = New System.Drawing.Point(136, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 19)
        Me.Label22.TabIndex = 492
        Me.Label22.Text = "U p u c e n o"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'FR_Stanica
        '
        Me.FR_Stanica.BackColor = System.Drawing.Color.White
        Me.FR_Stanica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.FR_Stanica.ForeColor = System.Drawing.Color.Black
        Me.FR_Stanica.Location = New System.Drawing.Point(16, 40)
        Me.FR_Stanica.MaxLength = 18
        Me.FR_Stanica.Name = "FR_Stanica"
        Me.FR_Stanica.Size = New System.Drawing.Size(104, 21)
        Me.FR_Stanica.TabIndex = 300
        Me.FR_Stanica.Text = "0"
        Me.FR_Stanica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Enabled = False
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label19.Location = New System.Drawing.Point(96, 61)
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
        Me.Label24.Location = New System.Drawing.Point(24, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 19)
        Me.Label24.TabIndex = 227
        Me.Label24.Text = "F r a n k o"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'UP_Stanica
        '
        Me.UP_Stanica.BackColor = System.Drawing.Color.White
        Me.UP_Stanica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.UP_Stanica.ForeColor = System.Drawing.Color.Black
        Me.UP_Stanica.Location = New System.Drawing.Point(128, 40)
        Me.UP_Stanica.MaxLength = 18
        Me.UP_Stanica.Name = "UP_Stanica"
        Me.UP_Stanica.Size = New System.Drawing.Size(104, 21)
        Me.UP_Stanica.TabIndex = 489
        Me.UP_Stanica.Text = "0"
        Me.UP_Stanica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(32, 168)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 456
        Me.Button1.Text = "OK"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(152, 168)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 457
        Me.Button2.Text = "Odustani"
        '
        'BlagajnaSaCO
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(264, 218)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Name = "BlagajnaSaCO"
        Me.Text = "Blagajna uz CO"
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
