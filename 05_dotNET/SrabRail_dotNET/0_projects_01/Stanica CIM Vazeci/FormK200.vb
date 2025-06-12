Imports CrystalDecisions.Shared
Public Class FormK200
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
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents btn165 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DatumIzvestaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbSatVoza As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormK200))
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btn165 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DatumIzvestaja = New System.Windows.Forms.DateTimePicker
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbSatVoza = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(221, 216)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(88, 64)
        Me.btnOtkazi.TabIndex = 5
        Me.btnOtkazi.Text = "Otkazi"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn165
        '
        Me.btn165.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btn165.Image = CType(resources.GetObject("btn165.Image"), System.Drawing.Image)
        Me.btn165.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn165.Location = New System.Drawing.Point(24, 216)
        Me.btn165.Name = "btn165"
        Me.btn165.Size = New System.Drawing.Size(88, 64)
        Me.btn165.TabIndex = 3
        Me.btn165.Text = "Prihvati "
        Me.btn165.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(112, 112)
        Me.TextBox1.MaxLength = 5
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(88, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(112, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Trasa voza"
        '
        'DatumIzvestaja
        '
        Me.DatumIzvestaja.Location = New System.Drawing.Point(112, 168)
        Me.DatumIzvestaja.Name = "DatumIzvestaja"
        Me.DatumIzvestaja.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(112, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 23)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Izaberite datum za koji se pravi izvestaj"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbSatVoza
        '
        Me.tbSatVoza.Location = New System.Drawing.Point(232, 112)
        Me.tbSatVoza.MaxLength = 2
        Me.tbSatVoza.Name = "tbSatVoza"
        Me.tbSatVoza.Size = New System.Drawing.Size(80, 20)
        Me.tbSatVoza.TabIndex = 1
        Me.tbSatVoza.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(232, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Sat voza"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(128, 216)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 64)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Evidencija o tranzitnim postupcima"
        '
        'FormK200
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(328, 294)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbSatVoza)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DatumIzvestaja)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btn165)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormK200"
        Me.Text = "FormK200"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btn165_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn165.Click
        If StampaId = "CarSpec" Then

            Dim xNaziv As String = ""
            Dim xKB As String = ""
            Dim xZemlja As String = ""
            Dim xPovVrednost As String = ""

            ''' Da li je potrebno?? - Util.sNadjiNaziv("TrasaCar", Me.TextBox1.Text, "", "", 1, xNaziv, xPovVrednost)
            If xPovVrednost <> "" Then
                ErrorProvider1.SetError(TextBox1, "Voz sa ovom trasom nije predvidjen za stampu!")
            Else
                Me.Text = xNaziv
                ErrorProvider1.SetError(TextBox1, "")
                '-----------------------------------------
                Dim FIzvK200 As New FormK200rpt
                Dim CRIzv As New SpecVagonaTL1
                FIzvK200.CrystalReportViewer1.ReportSource = CRIzv

                Dim CRConec As New ConnectionInfo
                CRConec = FIzvK200.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
                CRConec.ServerName = "10.0.4.31"
                CRConec.DatabaseName = "WinRoba"
                CRConec.UserID = "Radnik"
                CRConec.Password = "roba2006"

                Dim param1 As String
                Dim param2 As Int32
                Dim param3 As String
                Dim param4 As Date

                param1 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
                param2 = CType(TextBox1.Text, Int32)
                param3 = Me.tbSatVoza.Text
                param4 = DatumIzvestaja.Value

                Try
                    'bez praznih kola
                    ''FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                    ''                                                 " and  (microsoft.visualbasic.left({SlogRoba.Nhm},4)= '9922' or microsoft.visualbasic.left({SlogRoba.Nhm},4)= '9921')" & _
                    ''                                                 " and {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

                    FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                                                                     " and {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

                    'FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                    '                                                 " and {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') "


                    'FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & " and  {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

                    CRIzv.SetParameterValue(0, param1)
                    CRIzv.SetParameterValue(1, param2)
                    CRIzv.SetParameterValue(2, param3)
                    CRIzv.SetParameterValue(3, param4)

                    FIzvK200.Show()

                Catch ex As Exception

                    MsgBox(ex.ToString)
                Finally

                End Try

            End If
        Else
            Dim FIzvK200 As New FormK200rpt
            Dim CRIzv As New K200
            FIzvK200.CrystalReportViewer1.ReportSource = CRIzv

            Dim CRConec As New ConnectionInfo
            CRConec = FIzvK200.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            CRConec.ServerName = "10.0.4.31"
            CRConec.DatabaseName = "WinRoba"
            CRConec.UserID = "Radnik"
            CRConec.Password = "roba2006"

            Dim param1 As String
            Dim param2 As Int32
            Dim param3 As Date
            Dim param4 As String


            param1 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
            param2 = CType(TextBox1.Text, Int32)
            param3 = DatumIzvestaja.Value
            param4 = Me.tbSatVoza.Text

            Try

                FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza2}= " & param2 & " and  {SlogKalk.SatVoza2}=('" & Me.tbSatVoza.Text & "') and {SlogKalk.DatumIzlaza}= date('" & DatumIzvestaja.Text & "')"

                CRIzv.SetParameterValue(0, param1)
                CRIzv.SetParameterValue(1, param2)
                CRIzv.SetParameterValue(2, param3)
                CRIzv.SetParameterValue(3, param4)

                FIzvK200.Show()

            Catch ex As Exception

                MsgBox(ex.ToString)
            Finally

            End Try

        End If

        'Private Sub MenuItem53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem53.Click
        '       Dim FIzvK200 As New FormK200rpt
        '       Dim CRIzv As New Carr
        '       FIzvK200.CrystalReportViewer1.ReportSource = CRIzv
        '       Dim CRConec As New ConnectionInfo
        '       CRConec = FIzvK200.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        '       CRConec.ServerName = "10.0.4.31"
        '       CRConec.DatabaseName = "WinRoba"
        '       CRConec.UserID = "roba214kp"
        '       CRConec.Password = "Katarina"
        '       FIzvK200.Show()
        'End Sub

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub DatumIzvestaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatumIzvestaja.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub tbSatVoza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSatVoza.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub FormK200_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If StampaId = "CarSpec" Then
            Me.Text = "Specifikacija vagona za Carinu"
        Else
            Me.Text = "K-200"

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If StampaId = "CarSpec" Then

        Dim xNaziv As String = ""
        Dim xKB As String = ""
        Dim xZemlja As String = ""
        Dim xPovVrednost As String = ""

        ''' Da li je potrebno?? - Util.sNadjiNaziv("TrasaCar", Me.TextBox1.Text, "", "", 1, xNaziv, xPovVrednost)
        'If xPovVrednost <> "" Then
        ErrorProvider1.SetError(TextBox1, "Voz sa ovom trasom nije predvidjen za stampu!")

        Me.Text = xNaziv
        ErrorProvider1.SetError(TextBox1, "")
        '-----------------------------------------
      


        If bVrstaSaobracaja = 2 Or bVrstaSaobracaja = 4 Then

            Dim FIzvK200 As New FormK200rpt
            Dim CRIzv As New CarPosNew
            FIzvK200.CrystalReportViewer1.ReportSource = CRIzv
            Dim CRConec As New ConnectionInfo
            CRConec = FIzvK200.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            CRConec.ServerName = "10.0.4.31"
            CRConec.DatabaseName = "WinRoba"
            CRConec.UserID = "roba214kp"
            CRConec.Password = "Katarina"

            Dim param1 As String
            Dim param2 As Int32
            Dim param3 As String
            Dim param4 As Date
            'Dim param5 As String

            param1 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
            param2 = CType(TextBox1.Text, Int32)
            param3 = Me.tbSatVoza.Text
            param4 = DatumIzvestaja.Value
            ' param5 = mCarPost


            Try
                'bez praznih kola
                ''FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                ''                                                 " and  (microsoft.visualbasic.left({SlogRoba.Nhm},4)= '9922' or microsoft.visualbasic.left({SlogRoba.Nhm},4)= '9921')" & _
                ''                                                 " and {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

                FIzvK200.CrystalReportViewer1.SelectionFormula = "{CarPosNew.DatumUlaza}= date('" & DatumIzvestaja.Text & "') and {CarPosNew.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "')and {CarPosNew.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                                                                 "  and {CarPosNew.SatVoza}=('" & Me.tbSatVoza.Text & "')   "
                'and {carpost.CarPost}= 'd'
                '''FIzvK200.CrystalReportViewer1.SelectionFormula = "{CarPosNew.DatumUlaza}= date('" & DatumIzvestaja.Text & "')  "
                'FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                '                                                 " and {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') "


                'FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & " and  {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

                CRIzv.SetParameterValue(0, param4)
                CRIzv.SetParameterValue(1, param1)
                CRIzv.SetParameterValue(2, param2)
                CRIzv.SetParameterValue(3, param3)



                FIzvK200.Show()

            Catch ex As Exception

                MsgBox(ex.ToString)
            Finally
            End Try

        ElseIf bVrstaSaobracaja = 3 Then

            Dim FIzvK200 As New FormK200rpt
            Dim CRIzv As New CarrrIz
            FIzvK200.CrystalReportViewer1.ReportSource = CRIzv
            Dim CRConec As New ConnectionInfo
            CRConec = FIzvK200.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
            CRConec.ServerName = "10.0.4.31"
            CRConec.DatabaseName = "WinRoba"
            CRConec.UserID = "roba214kp"
            CRConec.Password = "Katarina"


            Dim param1 As String
            Dim param2 As Int32
            Dim param3 As String
            Dim param4 As Date
            'Dim param5 = mCarPost

            ' param1 = Microsoft.VisualBasic.Right(otpStanica, 5) '(otpStanica.Length) - 2)
            param1 = mOtpStanica
            param2 = CType(TextBox1.Text, Int32)
            param3 = Me.tbSatVoza.Text
            param4 = DatumIzvestaja.Value
            'param5 = mCarPost

            Try
                'bez praznih kola
                ''FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                ''                                                 " and  (microsoft.visualbasic.left({SlogRoba.Nhm},4)= '9922' or microsoft.visualbasic.left({SlogRoba.Nhm},4)= '9921')" & _
                ''                                                 " and {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

                'FIzvK200.CrystalReportViewer1.SelectionFormula = "{carpost.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Right(otpStanica, 5) & "') and {carpost.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                '                                                 " and {carpost.SatVoza}=('" & Me.tbSatVoza.Text & "') and {carpost.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

                FIzvK200.CrystalReportViewer1.SelectionFormula = "{CarPostIz.otpStanica}=  '" & mOtpStanica & "'  and {CarPostIz.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                                                                                    " and {CarPostIz.SatVoza}=('" & Me.tbSatVoza.Text & "') and {CarPostIz.DatumUlaza}= date('" & DatumIzvestaja.Text & "') "

                'FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & _
                '                                                 " and {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') "


                'FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsUlPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza}= " & CType(TextBox1.Text, Int32) & " and  {SlogKalk.SatVoza}=('" & Me.tbSatVoza.Text & "') and {SlogKalk.DatumUlaza}= date('" & DatumIzvestaja.Text & "')"

                CRIzv.SetParameterValue(0, param1)
                CRIzv.SetParameterValue(1, param2)
                CRIzv.SetParameterValue(2, param3)
                CRIzv.SetParameterValue(3, param4)
                'CRIzv.SetParameterValue(4, param5)


                FIzvK200.Show()

            Catch ex As Exception

                MsgBox(ex.ToString)
            Finally

            End Try
        End If


        'End If
        'Else
        'Dim FIzvK200 As New FormK200rpt
        'Dim CRIzv As New K200
        'FIzvK200.CrystalReportViewer1.ReportSource = CRIzv

        'Dim CRConec As New ConnectionInfo
        'CRConec = FIzvK200.CrystalReportViewer1.LogOnInfo.Item(0).ConnectionInfo
        'CRConec.ServerName = "10.0.4.31"
        'CRConec.DatabaseName = "WinRoba"
        'CRConec.UserID = "Radnik"
        'CRConec.Password = "roba2006"

        'Dim param1 As String
        'Dim param2 As Int32
        'Dim param3 As Date
        'Dim param4 As String


        'param1 = Microsoft.VisualBasic.Right(StanicaUnosa, (StanicaUnosa.Length) - 4)
        'param2 = CType(TextBox1.Text, Int32)
        'param3 = DatumIzvestaja.Value
        'param4 = Me.tbSatVoza.Text

        'Try

        '    FIzvK200.CrystalReportViewer1.SelectionFormula = "{SlogKalk.ZsIzPrelaz}=('" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "') and {SlogKalk.BrojVoza2}= " & param2 & " and  {SlogKalk.SatVoza2}=('" & Me.tbSatVoza.Text & "') and {SlogKalk.DatumIzlaza}= date('" & DatumIzvestaja.Text & "')"

        '    CRIzv.SetParameterValue(0, param1)
        '    CRIzv.SetParameterValue(1, param2)
        '    CRIzv.SetParameterValue(2, param3)
        '    CRIzv.SetParameterValue(3, param4)

        '    FIzvK200.Show()

        'Catch ex As Exception

        '    MsgBox(ex.ToString)
        'Finally

        'End Try

        'End If



    End Sub

End Class
