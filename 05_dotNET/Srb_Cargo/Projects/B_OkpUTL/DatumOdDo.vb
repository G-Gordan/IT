Imports CrystalDecisions.Shared
Public Class DatumOdDo
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
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents DatumOd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DatumDo As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.DatumOd = New System.Windows.Forms.DateTimePicker
        Me.DatumDo = New System.Windows.Forms.DateTimePicker
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(184, 224)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(77, 64)
        Me.btnPrihvati.TabIndex = 4
        Me.btnPrihvati.Text = "Prihvati"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(288, 224)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(77, 64)
        Me.btnOtkazi.TabIndex = 8
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'DatumOd
        '
        Me.DatumOd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumOd.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumOd.Location = New System.Drawing.Point(56, 168)
        Me.DatumOd.Name = "DatumOd"
        Me.DatumOd.Size = New System.Drawing.Size(100, 24)
        Me.DatumOd.TabIndex = 9
        '
        'DatumDo
        '
        Me.DatumDo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DatumDo.Location = New System.Drawing.Point(224, 168)
        Me.DatumDo.Name = "DatumDo"
        Me.DatumDo.Size = New System.Drawing.Size(100, 24)
        Me.DatumDo.TabIndex = 10
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(56, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Beograd"
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(56, 104)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.TabIndex = 12
        Me.CheckBox2.Text = "Novi Sad"
        '
        'DatumOdDo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(392, 310)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DatumDo)
        Me.Controls.Add(Me.DatumOd)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Name = "DatumOdDo"
        Me.Text = "Pregled unosa za odreðeni vremenski period"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Me.Close()
    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim FIzv1 As New FormCR72
        Dim FIzv2 As New FormCR72

        Dim CRIzv2 As New OdDo2
        Dim CRIzv1 As New OdDo1

        Dim CRConec1 As New ConnectionInfo
        Dim CRConec2 As New ConnectionInfo

        'FIzv1.CrystalReportViewer1.ReportSource = CRIzv1
        'FIzv2.CrystalReportViewer2.ReportSource = CRIzv2

        Dim param1 As Date      'parametar koji se odnosi na datum od
        Dim param2 As Date      'parametar koji se odnosi na datum do
        Dim param3 As Integer    'parametar koji se odnosi na ZTP

        If (CheckBox1.Checked = True) And (CheckBox2.Checked = True) Then

            FIzv1.CrystalReportViewer1.ReportSource = CRIzv1
           

            param1 = DatumOd.Value
            param2 = DatumDo.Value
            CRConec1 = FIzv1.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            CRConec1.ServerName = "10.0.4.31"
            CRConec1.DatabaseName = "OKPWinRoba"
            CRConec1.UserID = "Radnik"
            CRConec1.Password = "roba2006"

            FIzv1.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Saobracaj} = '" & 1 & "' and {SlogKalk.DatumObrade}>= date('" & DatumOd.Text & "') and {SlogKalk.DatumObrade}<= date('" & DatumDo.Text & "')"
            CRIzv1.SetParameterValue(0, param1)
            CRIzv1.SetParameterValue(1, param2)

            FIzv1.Show()
        ElseIf ((CheckBox1.Checked = True) And (CheckBox2.Checked = False)) Or ((CheckBox1.Checked = False) And (CheckBox2.Checked = True)) Then
            FIzv2.CrystalReportViewer1.ReportSource = CRIzv2

            param1 = DatumOd.Value
            param2 = DatumDo.Value
            If (CheckBox1.Checked = True) And (CheckBox2.Checked = False) Then
                param3 = 1
            End If
            If (CheckBox1.Checked = False) And (CheckBox2.Checked = True) Then
                param3 = 2
            End If

            '"{SlogKalk.Saobracaj} = '" & 1 & "' and {SlogKalk.DatumObrade}>= date('" & DatumOd.Text & "') and {SlogKalk.DatumObrade}<= date('" & DatumDo.Text & "')"
            '"{SlogKalk.Saobracaj} = '" & 1 & "' and {SlogKalk.DatumObrade}>= date('" & DatumOd.Text & "') and {SlogKalk.DatumObrade}<= date('" & DatumDo.Text & "') and {ZsStanice.Ztp} = '" & param3 & "'"


            CRConec2 = FIzv2.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            CRConec2.ServerName = "10.0.4.31"
            CRConec2.DatabaseName = "OKPWinRoba"
            CRConec2.UserID = "Radnik"
            CRConec2.Password = "roba2006"

            '{SlogKalk.Saobracaj} = "1" and {SlogKalk.DatumObrade} >= {?DatumObradeOd} and {SlogKalk.DatumObrade} <= {?DatumObradeDo} and {ZsStanice.Ztp} = {?Param1}

            FIzv2.CrystalReportViewer1.SelectionFormula = "{SlogKalk.Saobracaj} = '" & 1 & "' and {SlogKalk.DatumObrade}>= date('" & DatumOd.Text & "') and {SlogKalk.DatumObrade}<= date('" & DatumDo.Text & "') and {ZsStanice.Ztp} = " & param3 & ""
            CRIzv2.SetParameterValue(0, param1)
            CRIzv2.SetParameterValue(1, param2)
            CRIzv2.SetParameterValue(2, param3)
            FIzv2.Show()
        Else
            MsgBox("Nista nije izabrano!")
            CheckBox1.Focus()
        End If

        'param1 = DatumOd.Value
        'param2 = DatumDo.Value
        ' za probu
        'CRIzv.SetParameterValue(0, param1)
        'CRIzv.SetParameterValue(1, param2)
        'CRIzv.SetParameterValue(2, param3)
        'FIzv.Show()

    End Sub
End Class
