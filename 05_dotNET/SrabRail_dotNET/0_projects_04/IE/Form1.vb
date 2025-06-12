Public Class frmHTML
    Inherits System.Windows.Forms.Form

    Public WithEvents Explorer As SHDocVw.InternetExplorer

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
    Friend WithEvents btnHTML As System.Windows.Forms.Button
    Friend WithEvents lblURL As System.Windows.Forms.Label
    Friend WithEvents cbURL As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnHTML = New System.Windows.Forms.Button
        Me.cbURL = New System.Windows.Forms.ComboBox
        Me.lblURL = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnHTML
        '
        Me.btnHTML.Location = New System.Drawing.Point(528, 8)
        Me.btnHTML.Name = "btnHTML"
        Me.btnHTML.TabIndex = 0
        Me.btnHTML.Text = "Kreni"
        '
        'cbURL
        '
        Me.cbURL.Location = New System.Drawing.Point(128, 8)
        Me.cbURL.Name = "cbURL"
        Me.cbURL.Size = New System.Drawing.Size(384, 21)
        Me.cbURL.TabIndex = 1
        '
        'lblURL
        '
        Me.lblURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblURL.Location = New System.Drawing.Point(8, 8)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(120, 23)
        Me.lblURL.TabIndex = 2
        Me.lblURL.Text = "Izaberite adresu:"
        Me.lblURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmHTML
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(904, 341)
        Me.Controls.Add(Me.lblURL)
        Me.Controls.Add(Me.cbURL)
        Me.Controls.Add(Me.btnHTML)
        Me.Name = "frmHTML"
        Me.Text = "Show HTML"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHTML.Click
        Explorer = New SHDocVw.InternetExplorer
        Explorer.Visible = True
        Explorer.Navigate(cbURL.text)
    End Sub

    Private Sub frmHTML_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbURL.Items.Add("http://www.cg.yu")
        cbURL.Items.Add("http://www.microsoft.com/vbasic")
        cbURL.Items.Add("http://www.progress.com")
        cbURL.Items.Add("http://www.cnn.com")
        cbURL.Items.Add("http://www.mbsoft.co.yu")
        cbURL.Items.Add("http://www.theweathernetwork.com")
        cbURL.Items.Add("http://www.pancevac.co.yu")
    End Sub

    Private Sub Explorer_NavigateComplete2(ByVal pDisp As Object, ByRef URL As Object) Handles Explorer.NavigateComplete2
        cbURL.Items.Add(Explorer.LocationURL)
    End Sub
End Class
