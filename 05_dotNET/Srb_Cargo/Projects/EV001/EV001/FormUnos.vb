<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormUnos
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
        Me.GlavniMeni = New System.Windows.Forms.MenuStrip
        Me.AžuriranjeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IzveštajiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RaznoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GrBoxGlavna = New System.Windows.Forms.GroupBox
        Me.GlavniMeni.SuspendLayout()
        Me.SuspendLayout()
        '
        'GlavniMeni
        '
        Me.GlavniMeni.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AžuriranjeToolStripMenuItem, Me.IzveštajiToolStripMenuItem, Me.RaznoToolStripMenuItem})
        Me.GlavniMeni.Location = New System.Drawing.Point(0, 0)
        Me.GlavniMeni.Name = "GlavniMeni"
        Me.GlavniMeni.Size = New System.Drawing.Size(1436, 24)
        Me.GlavniMeni.TabIndex = 10
        Me.GlavniMeni.Text = "GlavniMeni"
        '
        'AžuriranjeToolStripMenuItem
        '
        Me.AžuriranjeToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.AžuriranjeToolStripMenuItem.Name = "AžuriranjeToolStripMenuItem"
        Me.AžuriranjeToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.AžuriranjeToolStripMenuItem.Text = "Osnovno...?"
        '
        'IzveštajiToolStripMenuItem
        '
        Me.IzveštajiToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.IzveštajiToolStripMenuItem.Name = "IzveštajiToolStripMenuItem"
        Me.IzveštajiToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.IzveštajiToolStripMenuItem.Text = "Izveštaji"
        '
        'RaznoToolStripMenuItem
        '
        Me.RaznoToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.RaznoToolStripMenuItem.Name = "RaznoToolStripMenuItem"
        Me.RaznoToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.RaznoToolStripMenuItem.Text = "Razno...?"
        '
        'GrBoxGlavna
        '
        Me.GrBoxGlavna.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrBoxGlavna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GrBoxGlavna.Location = New System.Drawing.Point(25, 30)
        Me.GrBoxGlavna.Name = "GrBoxGlavna"
        Me.GrBoxGlavna.Size = New System.Drawing.Size(1399, 892)
        Me.GrBoxGlavna.TabIndex = 12
        Me.GrBoxGlavna.TabStop = False
        Me.GrBoxGlavna.Text = "UNOS PODATAKA"
        '
        'FormUnos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1436, 934)
        Me.Controls.Add(Me.GrBoxGlavna)
        Me.Controls.Add(Me.GlavniMeni)
        Me.MainMenuStrip = Me.GlavniMeni
        Me.Name = "FormUnos"
        Me.Text = "EV unos"
        Me.GlavniMeni.ResumeLayout(False)
        Me.GlavniMeni.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GlavniMeni As System.Windows.Forms.MenuStrip
    Friend WithEvents AžuriranjeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IzveštajiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RaznoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrBoxGlavna As System.Windows.Forms.GroupBox


    Private Sub ButUnos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

End Class


