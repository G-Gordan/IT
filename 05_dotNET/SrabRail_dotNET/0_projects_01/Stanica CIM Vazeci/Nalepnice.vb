Imports System.Data.SqlClient
Public Class Nalepnice
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents fxUlazna As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents fxIzlazna As FlxMaskBox.FlexMaskEditBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Nalepnice))
        Me.Label1 = New System.Windows.Forms.Label
        Me.fxUlazna = New FlxMaskBox.FlexMaskEditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.fxIzlazna = New FlxMaskBox.FlexMaskEditBox
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(200, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 56)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Poslednje upotrebljene tranzitne nalepnice"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fxUlazna
        '
        Me.fxUlazna.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxUlazna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxUlazna.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxUlazna.Location = New System.Drawing.Point(288, 112)
        Me.fxUlazna.Mask = "######"
        Me.fxUlazna.Name = "fxUlazna"
        Me.fxUlazna.TabIndex = 1
        Me.fxUlazna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(200, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 32)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ulazne"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(200, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 32)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Izlazne"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fxIzlazna
        '
        Me.fxIzlazna.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
        Me.fxIzlazna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.fxIzlazna.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fxIzlazna.Location = New System.Drawing.Point(288, 160)
        Me.fxIzlazna.Mask = "######"
        Me.fxIzlazna.Name = "fxIzlazna"
        Me.fxIzlazna.TabIndex = 4
        Me.fxIzlazna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(304, 216)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 6
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(200, 216)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 5
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
        Me.PictureBox1.Location = New System.Drawing.Point(16, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 192)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Nalepnice
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 310)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.fxIzlazna)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.fxUlazna)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Nalepnice"
        Me.Text = "IZMENA TRANZITNIH NALEPNICA"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        If (fxUlazna.Text = Nothing Or fxUlazna.Text = 0) Or (fxIzlazna.Text = Nothing Or fxIzlazna.Text = 0) Then
            ErrorProvider1.SetError(fxUlazna, "Markica mora imati vrednost")
            fxUlazna.Focus()
        Else
            ErrorProvider1.SetError(fxUlazna, "")
            Dim slogTrans As SqlTransaction
            Dim rv As String

            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            slogTrans = DbVeza.BeginTransaction()
            mAkcija = "Upd"

            Try

                Upis.UpdateTrzNalepnice(slogTrans, mAkcija, Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5), CType(fxUlazna.Text, Int32), CType(fxIzlazna.Text, Int32), rv)

                If rv = "" Then
                    slogTrans.Commit()
                Else
                    MsgBox(rv)
                    slogTrans.Rollback()
                End If

            Catch ex As Exception
                rv = ex.Message
                MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch sqlex As SqlException
                MsgBox(sqlex.Message)
            Finally
                DbVeza.Close()
            End Try

            Close()
        End If
    End Sub

    Private Sub Nalepnice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim sql_text As String = "SELECT UlaznaNalepnica,IzlaznaNalepnica " & _
                                 "FROM dbo.ZsTrzNalepnice " & _
                                 "WHERE (dbo.ZsTrzNalepnice.Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')"

        Dim sql_comm As New SqlClient.SqlCommand(sql_text, DbVeza)
        Dim rdrTrz As SqlClient.SqlDataReader

        rdrTrz = sql_comm.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdrTrz.Read()
            fxUlazna.Text = rdrTrz.GetInt32(0)
            fxIzlazna.Text = rdrTrz.GetInt32(1)
        Loop
        rdrTrz.Close()
        DbVeza.Close()

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub fxUlazna_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fxUlazna.Validating
        If fxUlazna.Text = Nothing Or fxUlazna.Text = 0 Then
            ErrorProvider1.SetError(fxUlazna, "Markica mora imati vrednost")
            fxUlazna.Focus()
        Else
            ErrorProvider1.SetError(fxUlazna, "")
        End If
    End Sub

    Private Sub fxIzlazna_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fxIzlazna.Validating
        If fxIzlazna.Text = Nothing Or fxIzlazna.Text = 0 Then
            ErrorProvider1.SetError(fxIzlazna, "Markica mora imati vrednost")
            fxIzlazna.Focus()
        Else
            ErrorProvider1.SetError(fxIzlazna, "")
        End If

    End Sub
End Class
