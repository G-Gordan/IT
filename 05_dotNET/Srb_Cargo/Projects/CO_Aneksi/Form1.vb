Public Class Form1
    Inherits System.Windows.Forms.Form
    Public SSS As String
    Public PPP As String

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
    Friend WithEvents btnIzlaz As System.Windows.Forms.Button
    Friend WithEvents btnPristup As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.btnIzlaz = New System.Windows.Forms.Button
        Me.btnPristup = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnIzlaz
        '
        Me.btnIzlaz.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.btnIzlaz.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIzlaz.ForeColor = System.Drawing.Color.Red
        Me.btnIzlaz.Image = CType(resources.GetObject("btnIzlaz.Image"), System.Drawing.Image)
        Me.btnIzlaz.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIzlaz.Location = New System.Drawing.Point(408, 440)
        Me.btnIzlaz.Name = "btnIzlaz"
        Me.btnIzlaz.Size = New System.Drawing.Size(168, 96)
        Me.btnIzlaz.TabIndex = 0
        Me.btnIzlaz.Text = "NAPUŠTANJE APLIKACIJE"
        Me.btnIzlaz.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIzlaz.Visible = False
        '
        'btnPristup
        '
        Me.btnPristup.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.btnPristup.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPristup.ForeColor = System.Drawing.Color.Blue
        Me.btnPristup.Image = CType(resources.GetObject("btnPristup.Image"), System.Drawing.Image)
        Me.btnPristup.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPristup.Location = New System.Drawing.Point(352, 240)
        Me.btnPristup.Name = "btnPristup"
        Me.btnPristup.Size = New System.Drawing.Size(264, 176)
        Me.btnPristup.TabIndex = 1
        Me.btnPristup.Text = "Pristupanje bazi"
        Me.btnPristup.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPristup.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 746)
        Me.Controls.Add(Me.btnPristup)
        Me.Controls.Add(Me.btnIzlaz)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
        Dim Nova22 As New Form2
        Nova22.ShowDialog()
    End Sub

    Private Sub btnIzlaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzlaz.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPristup.Click
        'Dim Nova22 As New Form2
        'Nova22.Show()
    End Sub

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'Dim FormUnos As New Form7
        'FormUnos.Show()
    End Sub
End Class
