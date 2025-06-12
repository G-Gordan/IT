Imports System.Data.SqlClient
Public Class Nadzorna
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUpis As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents cmbManipulativnaMesta As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Nadzorna))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbManipulativnaMesta = New System.Windows.Forms.ComboBox
        Me.btnUpis = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(184, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'cmbManipulativnaMesta
        '
        Me.cmbManipulativnaMesta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbManipulativnaMesta.Location = New System.Drawing.Point(181, 92)
        Me.cmbManipulativnaMesta.Name = "cmbManipulativnaMesta"
        Me.cmbManipulativnaMesta.Size = New System.Drawing.Size(264, 24)
        Me.cmbManipulativnaMesta.TabIndex = 1
        '
        'btnUpis
        '
        Me.btnUpis.BackColor = System.Drawing.SystemColors.Control
        Me.btnUpis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnUpis.Image = CType(resources.GetObject("btnUpis.Image"), System.Drawing.Image)
        Me.btnUpis.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpis.Location = New System.Drawing.Point(261, 164)
        Me.btnUpis.Name = "btnUpis"
        Me.btnUpis.Size = New System.Drawing.Size(80, 72)
        Me.btnUpis.TabIndex = 5
        Me.btnUpis.Text = "Upis u bazu"
        Me.btnUpis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(365, 164)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(80, 72)
        Me.Button9.TabIndex = 6
        Me.Button9.Text = "Otkaži"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Nadzorna
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(466, 256)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.btnUpis)
        Me.Controls.Add(Me.cmbManipulativnaMesta)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Nadzorna"
        Me.Text = " Manipulativno mesto"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Nadzorna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Nadzorna()

    End Sub
    Public Sub Nadzorna()
        Dim daPrevPut As SqlClient.SqlDataAdapter
        Dim dsPrevPut As New Data.DataSet
        Dim pomSifraPP As String
        Dim ZaCombo As String = ""
        Dim upit As String = ""
        Dim combo_linija1 As String = ""
        Dim objComm As SqlClient.SqlCommand

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        '---------------
        Dim ii As Int32 = 0
        Dim mSifraPrevPuta As String = ""
        Dim mSifra As String = ""
        Dim SamoJedanPut As String = "Da"

        Me.cmbManipulativnaMesta.Items.Clear()
        dsPrevPut.Clear()

        upit = "SELECT SifraStanice, Naziv FROM ZsStanice WHERE NadzornaStanicaSifra = '" & Microsoft.VisualBasic.Right(mPrStanica, 5) & "'"
        objComm = New SqlClient.SqlCommand(upit, OkpDbVeza)
        daPrevPut = New SqlClient.SqlDataAdapter(upit, OkpDbVeza)
        ii = daPrevPut.Fill(dsPrevPut)
        ZaCombo = ""
        Try
            If ii > 0 Then
                For kk As Int16 = 0 To ii - 1 'dsPrevPut.Tables(0).Rows.Count - 1
                    combo_linija1 = dsPrevPut.Tables(0).Rows(kk).Item("SifraStanice") & " - " & dsPrevPut.Tables(0).Rows(kk).Item("Naziv")
                    cmbManipulativnaMesta.Items.Add(combo_linija1)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        OkpDbVeza.Close()
    End Sub

    Private Sub btnUpis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpis.Click
        Nadzorna()

    End Sub
End Class
