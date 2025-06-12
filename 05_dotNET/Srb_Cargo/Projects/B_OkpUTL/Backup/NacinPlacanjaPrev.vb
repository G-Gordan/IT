Public Class NacinPlacanjaPrev
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
    Friend WithEvents cbObracun As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cbObracun = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cbObracun
        '
        Me.cbObracun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObracun.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbObracun.Items.AddRange(New Object() {"1 = Naplaceno na blagajni", "2 = Centralni obracun"})
        Me.cbObracun.Location = New System.Drawing.Point(136, 24)
        Me.cbObracun.Name = "cbObracun"
        Me.cbObracun.Size = New System.Drawing.Size(168, 24)
        Me.cbObracun.TabIndex = 58
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Vrsta obraèuna"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(96, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 60
        Me.Button1.Text = "OK"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(232, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 61
        Me.Button2.Text = "Odustani"
        '
        'NacinPlacanjaPrev
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(400, 146)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbObracun)
        Me.Controls.Add(Me.Label1)
        Me.Name = "NacinPlacanjaPrev"
        Me.Text = "Vrsta obraèuna prevoznine"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
