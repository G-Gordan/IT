<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.IzvestajiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NedostajuciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VanRasponaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RazlikeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IzvestajiK165ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NedostajuciToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.VanRasponaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RazlikeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.IzveštajiZaPeriodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Nedostajući140ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(88, 236)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Ucitaj datoteke"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1  -  Januar", "2  -  Februar", "3  -  Mart", "4  -  April", "5  -  Maj", "6  -  Jun", "7  -  Jul", "8  -  Avgust", "9  -  Septembar", "10 - Oktobar", "11 - Novembar", "12 - Decembar"})
        Me.ComboBox1.Location = New System.Drawing.Point(88, 124)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(131, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(85, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Mesec"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"2016", "2017", "2018", "2019", "2020"})
        Me.ComboBox2.Location = New System.Drawing.Point(88, 183)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(131, 21)
        Me.ComboBox2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Godina"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IzvestajiToolStripMenuItem, Me.IzvestajiK165ToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripTextBox1, Me.IzveštajiZaPeriodeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(588, 27)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'IzvestajiToolStripMenuItem
        '
        Me.IzvestajiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NedostajuciToolStripMenuItem, Me.VanRasponaToolStripMenuItem, Me.RazlikeToolStripMenuItem})
        Me.IzvestajiToolStripMenuItem.Name = "IzvestajiToolStripMenuItem"
        Me.IzvestajiToolStripMenuItem.Size = New System.Drawing.Size(88, 23)
        Me.IzvestajiToolStripMenuItem.Text = "Izvestaji K140"
        '
        'NedostajuciToolStripMenuItem
        '
        Me.NedostajuciToolStripMenuItem.Name = "NedostajuciToolStripMenuItem"
        Me.NedostajuciToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.NedostajuciToolStripMenuItem.Text = "&Nedostajuci"
        '
        'VanRasponaToolStripMenuItem
        '
        Me.VanRasponaToolStripMenuItem.Name = "VanRasponaToolStripMenuItem"
        Me.VanRasponaToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.VanRasponaToolStripMenuItem.Text = "&Van Raspona"
        '
        'RazlikeToolStripMenuItem
        '
        Me.RazlikeToolStripMenuItem.Name = "RazlikeToolStripMenuItem"
        Me.RazlikeToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.RazlikeToolStripMenuItem.Text = "&Razlike"
        '
        'IzvestajiK165ToolStripMenuItem
        '
        Me.IzvestajiK165ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NedostajuciToolStripMenuItem1, Me.VanRasponaToolStripMenuItem1, Me.RazlikeToolStripMenuItem1})
        Me.IzvestajiK165ToolStripMenuItem.Name = "IzvestajiK165ToolStripMenuItem"
        Me.IzvestajiK165ToolStripMenuItem.Size = New System.Drawing.Size(88, 23)
        Me.IzvestajiK165ToolStripMenuItem.Text = "Izvestaji K165"
        '
        'NedostajuciToolStripMenuItem1
        '
        Me.NedostajuciToolStripMenuItem1.Name = "NedostajuciToolStripMenuItem1"
        Me.NedostajuciToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.NedostajuciToolStripMenuItem1.Text = "Nedostajuci"
        '
        'VanRasponaToolStripMenuItem1
        '
        Me.VanRasponaToolStripMenuItem1.Name = "VanRasponaToolStripMenuItem1"
        Me.VanRasponaToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.VanRasponaToolStripMenuItem1.Text = "VanRaspona"
        '
        'RazlikeToolStripMenuItem1
        '
        Me.RazlikeToolStripMenuItem1.Name = "RazlikeToolStripMenuItem1"
        Me.RazlikeToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.RazlikeToolStripMenuItem1.Text = "Razlike"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(25, 23)
        Me.ToolStripMenuItem1.Text = "  "
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
        '
        'IzveštajiZaPeriodeToolStripMenuItem
        '
        Me.IzveštajiZaPeriodeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Nedostajući140ToolStripMenuItem})
        Me.IzveštajiZaPeriodeToolStripMenuItem.Name = "IzveštajiZaPeriodeToolStripMenuItem"
        Me.IzveštajiZaPeriodeToolStripMenuItem.Size = New System.Drawing.Size(117, 23)
        Me.IzveštajiZaPeriodeToolStripMenuItem.Text = "Izveštaji za periode"
        '
        'Nedostajući140ToolStripMenuItem
        '
        Me.Nedostajući140ToolStripMenuItem.Name = "Nedostajući140ToolStripMenuItem"
        Me.Nedostajući140ToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.Nedostajući140ToolStripMenuItem.Text = "Nedostajući 140"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(520, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Kada želite da dobijete izveštaj prvo unesite mesec i godinu, a zatim u meniju iz" & _
            "aberite Izveštaj K 140 ili K165,"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(15, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(382, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "u tom meniju će se pojaviti padajuća lista iz koje treba izabrati izveštaj koji ž" & _
            "elite."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.UnK140K165.My.Resources.Resources.trein_ico
        Me.PictureBox1.Location = New System.Drawing.Point(276, 108)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 205)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(588, 372)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents IzvestajiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NedostajuciToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VanRasponaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RazlikeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IzvestajiK165ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NedostajuciToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VanRasponaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RazlikeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents IzveštajiZaPeriodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nedostajući140ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
