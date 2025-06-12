Imports System.Data.SqlClient
Public Class RacunskiMesec
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RacunskiMesec))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mesec"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Godina"
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(328, 336)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 2
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(216, 336)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 1
        Me.btnPrihvati.Text = "Prihvati "
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 192)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(128, 31)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(88, 23)
        Me.NumericUpDown1.TabIndex = 0
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown2.Location = New System.Drawing.Point(128, 71)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {2006, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(88, 23)
        Me.NumericUpDown2.TabIndex = 1
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown2.Value = New Decimal(New Integer() {2006, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(176, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Postavite racunski mesec "
        '
        'RacunskiMesec
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(430, 412)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RacunskiMesec"
        Me.Text = "IZMENA RACUNSKOG MESECA"
        Me.TopMost = True
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        ''Dim slogTrans As SqlTransaction
        ''Dim rv As String

        ''If OkpDbVeza.State = ConnectionState.Closed Then
        ''    OkpDbVeza.Open()
        ''End If

        ''slogTrans = OkpDbVeza.BeginTransaction()
        ''mAkcija = "Upd"

        ''Try
        ''    If SetMesec = "CR" Then
        ''        Upis.UpdateMesecPrint(slogTrans, mAkcija, IzborSaobracaja, Me.NumericUpDown1.Text, Me.NumericUpDown2.Text, rv)
        ''    Else
        ''        Upis.UpdateMesecUnosa(slogTrans, mAkcija, IzborSaobracaja, Me.NumericUpDown1.Text, Me.NumericUpDown2.Text, rv)
        ''    End If
        ''    'Upis.UpdateMesecUnosa(slogTrans, mAkcija, IzborSaobracaja, Me.NumericUpDown1.Text, Me.NumericUpDown2.Text, rv)

        ''    If rv = "" Then
        ''        slogTrans.Commit()
        ''    Else
        ''        MsgBox(rv)
        ''        slogTrans.Rollback()
        ''    End If

        ''Catch ex As Exception
        ''    rv = ex.Message
        ''    MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ''Catch sqlex As SqlException
        ''    MsgBox(sqlex.Message)
        ''Finally
        ''    OkpDbVeza.Close()
        ''End Try
        CrRacunskiMesec = Me.NumericUpDown1.Text
        Close()


    End Sub

    Private Sub Nalepnice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '-------------------- postavljanje racunskog meseca ---------------------
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        Dim sql_text1 As String = ""
        
        If SetMesec = "CR" Then
            GroupBox1.Text = "Postavite mesec za stampu"
            sql_text1 = "SELECT Mesec, Godina FROM RacMesec " & _
                        "WHERE (VSaob = '" & IzborSaobracaja & "')"
        Else
            GroupBox1.Text = "Postavite mesec za unos"
            sql_text1 = "SELECT MesecUnosa, GodinaUnosa FROM RacMesec " & _
                                    "WHERE (VSaob = '" & IzborSaobracaja & "')"
        End If

        'Dim sql_text1 As String = "SELECT MesecUnosa, GodinaUnosa FROM RacMesec " & _
        '                          "WHERE (VSaob = '" & IzborSaobracaja & "')"


        Dim sql_comm1 As New SqlClient.SqlCommand(sql_text1, OkpDbVeza)
        Dim rdrRm As SqlClient.SqlDataReader
        rdrRm = sql_comm1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrRm.Read()
            Me.NumericUpDown1.Text = rdrRm.GetString(0)
            Me.NumericUpDown2.Text = rdrRm.GetString(1)
        Loop
        rdrRm.Close()

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub



    Private Sub NumericUpDown1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumericUpDown1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub

    Private Sub NumericUpDown2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumericUpDown2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
End Class
