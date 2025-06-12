<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Upit_1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OtpBrSt = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'OtpBrSt
        '
        Me.OtpBrSt.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.OtpBrSt.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.OtpBrSt.Location = New System.Drawing.Point(598, 41)
        Me.OtpBrSt.Name = "OtpBrSt"
        Me.OtpBrSt.Size = New System.Drawing.Size(133, 79)
        Me.OtpBrSt.TabIndex = 0
        Me.OtpBrSt.Text = "Otpravljanje broj i stanica"
        Me.OtpBrSt.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(88, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(229, 103)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "FORMA br 2"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Upit_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(803, 510)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.OtpBrSt)
        Me.Font = New System.Drawing.Font("Monotype Corsiva", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Name = "Upit_1"
        Me.Text = "Upit 1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OtpBrSt As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
