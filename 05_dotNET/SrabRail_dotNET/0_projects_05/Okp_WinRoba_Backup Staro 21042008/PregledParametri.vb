Public Class PregledParametri
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btn165 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PregledParametri))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btn165 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(336, 80)
        Me.TextBox1.MaxLength = 12
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(112, 24)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(192, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Individualni broj kola"
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(368, 256)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 7
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn165
        '
        Me.btn165.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btn165.Image = CType(resources.GetObject("btn165.Image"), System.Drawing.Image)
        Me.btn165.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn165.Location = New System.Drawing.Point(256, 256)
        Me.btn165.Name = "btn165"
        Me.btn165.Size = New System.Drawing.Size(88, 64)
        Me.btn165.TabIndex = 6
        Me.btn165.Text = "Prihvati "
        Me.btn165.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(192, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 100)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(32, 24)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(176, 24)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Pogled u bazu podataka"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(32, 64)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(176, 24)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Pogled u najave vozova"
        '
        'PregledParametri
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 342)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btn165)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "PregledParametri"
        Me.Text = "PregledParametri"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub btn165_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn165.Click
        mIBK = TextBox1.Text
        If Me.RadioButton1.Checked = True Then
            mPregledUnosa = "TK"
        Else
            mPregledUnosa = "TKN"
        End If

        Dim Form2pp As New FormGrid
        Form2pp.ShowDialog()

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub PregledParametri_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
