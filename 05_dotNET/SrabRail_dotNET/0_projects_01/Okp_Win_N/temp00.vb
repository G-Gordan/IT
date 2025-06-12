Public Class temp00
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
    Friend WithEvents tbRazlika As System.Windows.Forms.TextBox
    Friend WithEvents tbTL As System.Windows.Forms.TextBox
    Friend WithEvents tbPrevoznina As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbValuta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tbRazlika = New System.Windows.Forms.TextBox
        Me.tbTL = New System.Windows.Forms.TextBox
        Me.tbPrevoznina = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbValuta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'tbRazlika
        '
        Me.tbRazlika.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbRazlika.Location = New System.Drawing.Point(104, 136)
        Me.tbRazlika.Name = "tbRazlika"
        Me.tbRazlika.TabIndex = 28
        Me.tbRazlika.Text = "0"
        Me.tbRazlika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTL
        '
        Me.tbTL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbTL.Location = New System.Drawing.Point(104, 96)
        Me.tbTL.Name = "tbTL"
        Me.tbTL.TabIndex = 27
        Me.tbTL.Text = "0"
        Me.tbTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbPrevoznina
        '
        Me.tbPrevoznina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbPrevoznina.Location = New System.Drawing.Point(104, 56)
        Me.tbPrevoznina.Name = "tbPrevoznina"
        Me.tbPrevoznina.TabIndex = 26
        Me.tbPrevoznina.Text = "0"
        Me.tbPrevoznina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 23)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Razlika"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 32)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Iznos po tovarnom listu"
        '
        'tbValuta
        '
        Me.tbValuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbValuta.Location = New System.Drawing.Point(104, 24)
        Me.tbValuta.MaxLength = 2
        Me.tbValuta.Name = "tbValuta"
        Me.tbValuta.TabIndex = 22
        Me.tbValuta.Text = "Euro"
        Me.tbValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.ContextMenu = Me.ContextMenu1
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Valuta"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Prevoznina"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "11"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "22"
        '
        'temp00
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 406)
        Me.Controls.Add(Me.tbRazlika)
        Me.Controls.Add(Me.tbTL)
        Me.Controls.Add(Me.tbPrevoznina)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbValuta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "temp00"
        Me.Text = "temp00"
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
