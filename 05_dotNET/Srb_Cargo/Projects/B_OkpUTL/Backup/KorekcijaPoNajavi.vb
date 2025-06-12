Imports System.Data.SqlClient
Public Class KorekcijaPoNajavi
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox13 = New System.Windows.Forms.TextBox
        Me.TextBox14 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(272, 480)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Prihvati korekciju"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(456, 480)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Odustani"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(64, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Prevoznina za najavu"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(64, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "PDV za najavu"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(72, 488)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(152, 24)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Pošiljka podleže PDV-u"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(232, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(232, 112)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = ""
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(376, 392)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {2017, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(48, 20)
        Me.NumericUpDown2.TabIndex = 7
        Me.NumericUpDown2.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(264, 392)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 23)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Obraèunska godina"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(192, 392)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(32, 20)
        Me.NumericUpDown1.TabIndex = 6
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(64, 392)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 23)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Obraèunski mesec"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(72, 440)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(200, 24)
        Me.CheckBox2.TabIndex = 8
        Me.CheckBox2.Text = "Svaka kola imaju svoj tovarni list"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(232, 352)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.TabIndex = 4
        Me.TextBox3.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(64, 344)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 23)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Raèunska masa za najavu"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(232, 296)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.TabIndex = 3
        Me.TextBox4.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(64, 296)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 23)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Vozarinski stav za najavu"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(232, 152)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.TabIndex = 2
        Me.TextBox5.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(64, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 23)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Suma za najavu"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(376, 296)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(176, 32)
        Me.Button3.TabIndex = 22
        Me.Button3.Text = "Ponovo kalkuliši i osveži polja"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(408, 32)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.TabIndex = 23
        Me.TextBox6.Text = ""
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(408, 112)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.TabIndex = 24
        Me.TextBox7.Text = ""
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(408, 152)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.TabIndex = 25
        Me.TextBox8.Text = ""
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(232, 72)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.TabIndex = 26
        Me.TextBox9.Text = ""
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(408, 72)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.TabIndex = 27
        Me.TextBox10.Text = ""
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(64, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 23)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Suma naknada za najavu"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(410, 208)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.TabIndex = 31
        Me.TextBox11.Text = ""
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(234, 208)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.TabIndex = 29
        Me.TextBox12.Text = ""
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(66, 208)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 23)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Naplaæeno na blagajni"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(410, 248)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.TabIndex = 34
        Me.TextBox13.Text = ""
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(234, 248)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.TabIndex = 32
        Me.TextBox14.Text = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(66, 248)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 23)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Razlika na blagajni"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(256, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "FRANKO"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(432, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "UPUÆENO"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(360, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 16)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "RSD"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(360, 192)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 16)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "RSD"
        '
        'KorekcijaPoNajavi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 570)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox13)
        Me.Controls.Add(Me.TextBox14)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox11)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "KorekcijaPoNajavi"
        Me.Text = "Korekcija po najavi"
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' SlogKalkUpdate, SlogPDVUpdate, SlogRobaUpdate

        Dim k As Int16
        Dim ProsecnaMasa As Decimal = CInt(bpRacMasaPoNajavi / bpUkupnoKolaPoNajavi)


        Dim slogTrans As SqlTransaction
        Dim inAkcija As String = ""
        Dim inRecID As Integer = 0
        Dim inObrMesec As String = ""
        Dim inObrGodina As String = ""
        Dim inPrevozninaRSD As Decimal = 0
        Dim inPrevozninaEUR As Decimal = 0
        Dim inSumaRSD As Decimal = 0
        Dim inSumaEUR As Decimal = 0
        'Dim inImaPDV As String = "0"
        Dim inPDV As Decimal = 0
        Dim outPovVrednost1 As String = ""
        Dim outPovVrednost2 As String = ""
        Dim rv As String


        For k = 0 To bpUkupnoKolaPoNajavi - 2
            bpRacMasa(k) = ProsecnaMasa
            bZaokruziMasuNa100k(bpRacMasa(k))
        Next
        bpRacMasa(bpUkupnoKolaPoNajavi - 1) = bpRacMasaPoNajavi - ProsecnaMasa * (bpUkupnoKolaPoNajavi - 1)

        bpPrevozninaPoNajavi = TextBox1.Text
        bpRacMasaPoNajavi = TextBox3.Text
        bpVozStavPonajavi = TextBox4.Text
        bpSumaPoNajavi = TextBox5.Text
        bpPDVPoNajavi = TextBox2.Text
        bpObrMesec = NumericUpDown1.Text
        bpObrGodina = NumericUpDown2.Text
        If CheckBox1.Checked Then
            bpDaPDV = "1"
        Else
            bpDaPDV = "0"
        End If
        If CheckBox2.Checked Then
            bpJedanTLPoNajavi = "0"
        Else
            bpJedanTLPoNajavi = "1"
        End If
        If bpValuta = "RSD" Then
            inPrevozninaRSD = bpPrevozninaPoNajavi
            inSumaRSD = bpSumaPoNajavi
        Else
            inPrevozninaEUR = bpPrevozninaPoNajavi
            inSumaEUR = bpSumaPoNajavi
        End If


        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If
            slogTrans = OkpDbVeza.BeginTransaction()

            '--------------------------------------- Upis u SlogKalk ---------------------------------------------
            Dim bAkcija As String = "Upd"

            'upis

            'regulisati(SlogKalkPDV)


            If bpJedanTLPoNajavi = "1" Then
                inRecID = bpRecIDNiz(0)

                bKorekcijaPoNajaviSlogKalk(slogTrans, bAkcija, inRecID, _
                                                   bpObrGodina, bpObrMesec, _
                                                   inPrevozninaRSD, inPrevozninaEUR, _
                                                   inSumaRSD, inSumaEUR, _
                                                   bpDaPDV, bpPDVPoNajavi, _
                                                   outPovVrednost1)
                Dim n As Int16 = 0
                For n = 0 To bpUkupnoKolaPoNajavi - 1
                    bKorekcijaPoNajaviSlogRoba(slogTrans, bAkcija, _
                                                        bpRecIDNiz(0), n + 1, 1, _
                                                        bpRacMasa(n), bpVozStav(n), _
                                                        outPovVrednost2)
                Next

                Dim outPV As String = ""
                Dim outPV2 As String = ""
                bNadjiSlogKalkPDV(slogTrans, inRecID, outPV)
                If outPV = "" Then
                    bKorekcijaPoNajaviSlogKalkPDV(slogTrans, bAkcija, inRecID, _
                                                       bpPDVPoNajavi, 0, _
                                                       outPV2)
                End If






            ElseIf bpJedanTLPoNajavi = "0" Then

                    bKorekcijaPoNajaviSlogKalk(slogTrans, bAkcija, bpRecIDNiz(0), _
                                                                 bpObrGodina, bpObrMesec, _
                                                                 inPrevozninaRSD, inPrevozninaEUR, _
                                                                 inSumaRSD, inSumaEUR, _
                                                                 bpDaPDV, bpPDVPoNajavi, _
                                                                 outPovVrednost1)
                    bKorekcijaPoNajaviSlogRoba(slogTrans, bAkcija, _
                                                                            bpRecIDNiz(0), 1, 1, _
                                                                            bpRacMasa(0), bpVozStav(0), _
                                                                            outPovVrednost2)

                Dim outPV As String = ""
                Dim outPV2 As String = ""
                bNadjiSlogKalkPDV(slogTrans, bpRecIDNiz(0), outPV)
                    If outPV = "" Then
                    bKorekcijaPoNajaviSlogKalkPDV(slogTrans, bAkcija, bpRecIDNiz(0), _
                                                                     bpPDVPoNajavi, 0, _
                                                                     outPV2)
                    End If

                    Dim n As Int16 = 0
                    For n = 1 To bpUkupnoKolaPoNajavi - 1
                        bKorekcijaPoNajaviSlogKalk(slogTrans, bAkcija, bpRecIDNiz(n), _
                                                                                    bpObrGodina, bpObrMesec, _
                                                                                    0, 0, _
                                                                                    0, 0, _
                                                                                    bpDaPDV, 0, _
                                                                                    outPovVrednost1)

                    bKorekcijaPoNajaviSlogRoba(slogTrans, bAkcija, _
                                                        bpRecIDNiz(n), 1, 1, _
                                                        bpRacMasa(n), bpVozStav(0), _
                                                        outPovVrednost2)

                    Dim outPV1 As String = ""
                    outPV2 = ""
                    bNadjiSlogKalkPDV(slogTrans, bpRecIDNiz(n), outPV1)
                    If outPV1 = "" Then
                        bKorekcijaPoNajaviSlogKalkPDV(slogTrans, bAkcija, bpRecIDNiz(n), _
                                                                                           0, 0, _
                                                                                           outPV2)
                    End If

                Next

                End If

                ' upis u  SlogKalk
                ' upis u  SlogRoba
                ' upis u  SlogKalkPDV

                rv = outPovVrednost1 & outPovVrednost2
                If rv <> "" Then Throw New Exception(rv)

                'proveriti da li da ide na #100
                If rv = "" Then
                    slogTrans.Commit()
                    'ClearDocZaPregled()
                    Me.Text = " ::: Uspesan upis korekcije! :::"
                Else
                    MessageBox.Show(rv, "Poruka iz baze", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    slogTrans.Rollback()
                End If

                'ClearDocZaPregled() ' brise polja pre novog unosa

        Catch ex As Exception
            rv = ex.Message
            MessageBox.Show(rv, "Greska u pristupu bazi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch sqlex As SqlException
            MsgBox(sqlex.Message)
        Finally
            '#100
            OkpDbVeza.Close()
        End Try



        Me.Close()
    End Sub

    Private Sub CheckBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CheckBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub CheckBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CheckBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
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
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub KorekcijaPoNajavi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bpValuta = "RSD" Then
            Label13.Text = "< RSD >"



        ElseIf bpValuta = "EUR" Then
            Label13.Text = "< EUR >"
        End If
        TextBox1.Text = bpPrevozninaPoNajavi
        TextBox3.Text = bpRacMasaPoNajavi
        TextBox4.Text = bpVozStavPonajavi
        TextBox5.Text = bpSumaPoNajavi
        TextBox2.Text = bpPDVPoNajavi
        


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        bpPrevozninaPoNajavi = CDec(TextBox3.Text) * CDec(TextBox4.Text) / 1000
        TextBox1.Text = bpPrevozninaPoNajavi

        Dim k As Int16
        Dim ProsecnaMasa As Decimal = CInt(bpRacMasaPoNajavi / bpUkupnoKolaPoNajavi)
        For k = 0 To bpUkupnoKolaPoNajavi - 2
            bpRacMasa(k) = ProsecnaMasa
            bZaokruziMasuNa100k(bpRacMasa(k))
        Next
        bpRacMasa(bpUkupnoKolaPoNajavi - 1) = bpRacMasaPoNajavi - ProsecnaMasa * (bpUkupnoKolaPoNajavi - 1)

    End Sub
End Class
