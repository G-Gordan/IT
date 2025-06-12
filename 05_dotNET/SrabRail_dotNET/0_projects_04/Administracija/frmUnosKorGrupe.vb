Public Class frmUnos
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
    Friend WithEvents btnPonisti As System.Windows.Forms.Button
    Friend WithEvents btnSacuvaj As System.Windows.Forms.Button
    Friend WithEvents lblKorGrupa As System.Windows.Forms.Label
    Friend WithEvents txtKorGrupa As System.Windows.Forms.TextBox
    Friend WithEvents lblNapomena As System.Windows.Forms.Label
    Friend WithEvents txtNapomena As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblKorGrupa = New System.Windows.Forms.Label
        Me.lblNapomena = New System.Windows.Forms.Label
        Me.txtNapomena = New System.Windows.Forms.TextBox
        Me.btnPonisti = New System.Windows.Forms.Button
        Me.btnSacuvaj = New System.Windows.Forms.Button
        Me.txtKorGrupa = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lblKorGrupa
        '
        Me.lblKorGrupa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblKorGrupa.Location = New System.Drawing.Point(16, 16)
        Me.lblKorGrupa.Name = "lblKorGrupa"
        Me.lblKorGrupa.Size = New System.Drawing.Size(112, 16)
        Me.lblKorGrupa.TabIndex = 0
        Me.lblKorGrupa.Text = "Korisnicka Grupa:"
        Me.lblKorGrupa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNapomena
        '
        Me.lblNapomena.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblNapomena.Location = New System.Drawing.Point(24, 48)
        Me.lblNapomena.Name = "lblNapomena"
        Me.lblNapomena.Size = New System.Drawing.Size(104, 16)
        Me.lblNapomena.TabIndex = 4
        Me.lblNapomena.Text = "Napomena:"
        Me.lblNapomena.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNapomena
        '
        Me.txtNapomena.Location = New System.Drawing.Point(144, 48)
        Me.txtNapomena.Multiline = True
        Me.txtNapomena.Name = "txtNapomena"
        Me.txtNapomena.Size = New System.Drawing.Size(352, 72)
        Me.txtNapomena.TabIndex = 5
        Me.txtNapomena.Text = ""
        '
        'btnPonisti
        '
        Me.btnPonisti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPonisti.Location = New System.Drawing.Point(424, 128)
        Me.btnPonisti.Name = "btnPonisti"
        Me.btnPonisti.TabIndex = 6
        Me.btnPonisti.Text = "Poništi"
        '
        'btnSacuvaj
        '
        Me.btnSacuvaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSacuvaj.Location = New System.Drawing.Point(344, 128)
        Me.btnSacuvaj.Name = "btnSacuvaj"
        Me.btnSacuvaj.TabIndex = 7
        Me.btnSacuvaj.Text = "Sacuvaj"
        '
        'txtKorGrupa
        '
        Me.txtKorGrupa.Location = New System.Drawing.Point(144, 16)
        Me.txtKorGrupa.Name = "txtKorGrupa"
        Me.txtKorGrupa.Size = New System.Drawing.Size(232, 20)
        Me.txtKorGrupa.TabIndex = 8
        Me.txtKorGrupa.Text = ""
        '
        'frmUnos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.ClientSize = New System.Drawing.Size(504, 157)
        Me.Controls.Add(Me.txtKorGrupa)
        Me.Controls.Add(Me.btnSacuvaj)
        Me.Controls.Add(Me.btnPonisti)
        Me.Controls.Add(Me.txtNapomena)
        Me.Controls.Add(Me.lblNapomena)
        Me.Controls.Add(Me.lblKorGrupa)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUnos"
        Me.Text = "Unos Podataka"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnPonisti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPonisti.Click
        Me.Close()
    End Sub
    Private Sub subInit()
        txtKorGrupa.Text = ""
        txtNapomena.Text = ""
    End Sub
    Private Sub subAssign()
        txtKorGrupa.Text = KorGrupe.f_KorGrupa
        txtNapomena.Text = KorGrupe.f_Napomena
    End Sub
    Private Sub subAssignSave(ByRef GreskaOpisTrans As String)
        Try
            KorGrupe.f_KorGrupa = txtKorGrupa.Text
            KorGrupe.f_Napomena = txtNapomena.Text
        Catch
            GreskaOpisTrans = Err.Description
        End Try
    End Sub
    Private Sub subEnableControls()
        Select Case KorGrupe.Akcija
            Case "dodaj"
                subInit()
                txtKorGrupa.Enabled = True
                txtNapomena.Enabled = True
            Case "izmeni"
                subAssign()
                txtNapomena.Enabled = True
            Case Else
                MsgBox("Nepoznata Akcija: " & KorGrupe.Akcija & " !?!", MsgBoxStyle.Critical, "Greška u programu")
        End Select
    End Sub
    Private Sub frmUnos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KorGrupe.dwClosed = 0  'Inicijalno se stavlja kao da ce se postupak OBUSTAVITI
        subEnableControls()
    End Sub
    Private Sub frmUnos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If KorGrupe.Akcija = "dodaj" Then
            txtKorGrupa.Focus()
        Else 'KorGrupe.Akcija = "izmeni"
            txtNapomena.Focus()
        End If
    End Sub
    Private Sub btnSacuvaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacuvaj.Click
        Dim GreskaOpis As String = ""
        subAssignSave(GreskaOpis)
        If Trim(GreskaOpis) <> "" Then
            MsgBox(GreskaOpis, MsgBoxStyle.OKOnly, "Transakcijska Greška")
            btnSacuvaj.Focus()
        Else
            subKorGrupeMan(GreskaOpis)
            If Trim(GreskaOpis) <> "" Then
                MsgBox(GreskaOpis, MsgBoxStyle.OKOnly, "Transakcijska Greška")
                btnSacuvaj.Focus()
            Else
                KorGrupe.dwClosed = 1
                Me.Close()
            End If
        End If
    End Sub
End Class