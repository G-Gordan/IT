Public Class FormPregledTL
    Inherits System.Windows.Forms.Form
    Public EventsActived As Boolean = True

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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents gbSaobracaj As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents rbUgovor As System.Windows.Forms.RadioButton
    Friend WithEvents rbUgovori As System.Windows.Forms.RadioButton
    Friend WithEvents rbSve As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormPregledTL))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.gbSaobracaj = New System.Windows.Forms.GroupBox
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.RadioButton7 = New System.Windows.Forms.RadioButton
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.rbUgovor = New System.Windows.Forms.RadioButton
        Me.rbUgovori = New System.Windows.Forms.RadioButton
        Me.rbSve = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.gbSaobracaj.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(40, 152)
        Me.TextBox1.MaxLength = 6
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = ""
        '
        'gbSaobracaj
        '
        Me.gbSaobracaj.Controls.Add(Me.RadioButton6)
        Me.gbSaobracaj.Controls.Add(Me.RadioButton7)
        Me.gbSaobracaj.Controls.Add(Me.RadioButton5)
        Me.gbSaobracaj.Controls.Add(Me.RadioButton4)
        Me.gbSaobracaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSaobracaj.Location = New System.Drawing.Point(16, 104)
        Me.gbSaobracaj.Name = "gbSaobracaj"
        Me.gbSaobracaj.Size = New System.Drawing.Size(176, 200)
        Me.gbSaobracaj.TabIndex = 0
        Me.gbSaobracaj.TabStop = False
        Me.gbSaobracaj.Text = "[ Vrsta saobracaja ]"
        '
        'RadioButton6
        '
        Me.RadioButton6.Location = New System.Drawing.Point(22, 107)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.TabIndex = 2
        Me.RadioButton6.Text = "Izvoz"
        '
        'RadioButton7
        '
        Me.RadioButton7.Location = New System.Drawing.Point(22, 145)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.TabIndex = 3
        Me.RadioButton7.Text = "Lokal"
        '
        'RadioButton5
        '
        Me.RadioButton5.Location = New System.Drawing.Point(22, 68)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.TabIndex = 1
        Me.RadioButton5.Text = "Uvoz"
        '
        'RadioButton4
        '
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(22, 33)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.TabIndex = 0
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Tranzit"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.rbUgovor)
        Me.GroupBox1.Controls.Add(Me.rbUgovori)
        Me.GroupBox1.Controls.Add(Me.rbSve)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(216, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 200)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Tarifa ]"
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(176, 152)
        Me.TextBox2.MaxLength = 10
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = ""
        '
        'rbUgovor
        '
        Me.rbUgovor.Location = New System.Drawing.Point(22, 107)
        Me.rbUgovor.Name = "rbUgovor"
        Me.rbUgovor.Size = New System.Drawing.Size(146, 24)
        Me.rbUgovor.TabIndex = 2
        Me.rbUgovor.Text = "Pojedinacni ugovor"
        '
        'rbUgovori
        '
        Me.rbUgovori.Location = New System.Drawing.Point(22, 68)
        Me.rbUgovori.Name = "rbUgovori"
        Me.rbUgovori.TabIndex = 1
        Me.rbUgovori.Text = "Svi ugovori"
        '
        'rbSve
        '
        Me.rbSve.Checked = True
        Me.rbSve.Location = New System.Drawing.Point(22, 33)
        Me.rbSve.Name = "rbSve"
        Me.rbSve.Size = New System.Drawing.Size(162, 24)
        Me.rbSve.TabIndex = 0
        Me.rbSve.TabStop = True
        Me.rbSve.Text = "Kompletan materijal"
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Broj ugovora"
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(192, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Broj najave"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label7)
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox8.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(216, 16)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(304, 80)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = " [ Obracunski period ] "
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(183, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Godina"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mesec"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(16, 35)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(88, 23)
        Me.NumericUpDown1.TabIndex = 0
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown1.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NumericUpDown2.Location = New System.Drawing.Point(160, 35)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {2016, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {2007, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(96, 23)
        Me.NumericUpDown2.TabIndex = 1
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown2.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(328, 320)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(77, 64)
        Me.btnPrihvati.TabIndex = 3
        Me.btnPrihvati.Text = "Prihvati"
        '
        'btnOtkazi
        '
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(440, 320)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(77, 64)
        Me.btnOtkazi.TabIndex = 4
        Me.btnOtkazi.Text = "Otkazi"
        '
        'FormPregledTL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 398)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbSaobracaj)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPregledTL"
        Me.Text = "Pogled u bazu podataka"
        Me.gbSaobracaj.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If EventsActived = True Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                Me.EventsActived = False
                Dim Form2 As New FormGrid
                Form2.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        Dim qObrMesec As String
        Dim qObrGodina As String


        EventsActived = True

        qObrMesec = NumericUpDown1.Value
        qObrGodina = NumericUpDown2.Value

        If Me.RadioButton4.Checked = True Then
            IzborSaobracaja = "4"
        End If
        If Me.RadioButton5.Checked = True Then
            IzborSaobracaja = "2"
        End If
        If Me.RadioButton6.Checked = True Then
            IzborSaobracaja = "3"
        End If
        If Me.RadioButton7.Checked = True Then
            IzborSaobracaja = "1"
        End If


        If rbSve.Checked = True Then
            sql_UpitPregled = "SELECT OtpUprava, OtpStanica, OtpBroj, OtpDatum, ZsUlPrelaz, UlEtiketa, ZsIzPrelaz, IzEtiketa, PrUprava, PrStanica, PrBroj, Ugovor, Najava, UkupnoKola, tlSumaFr, tlSumaUp, tlPrevFr, tlPrevUp, tlNakFr, tlNakUp, tlNakCo, tlSumaFrDin, tlSumaUpDin, referent1 " & _
                              "FROM dbo.SlogKalk " & _
                              "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (ObrGodina = '" & qObrGodina & "') AND (ObrMesec = '" & qObrMesec & "') " & _
                              "ORDER BY ZsUlPrelaz, UlEtiketa, ZsIzPrelaz, IzEtiketa"


        End If

        If rbUgovori.Checked = True Then
            sql_UpitPregled = "SELECT Ugovor, Najava, OtpUprava, OtpStanica, OtpBroj, OtpDatum, ZsUlPrelaz, UlEtiketa, ZsIzPrelaz, IzEtiketa, PrUprava, PrStanica,  PrBroj, UkupnoKola, tlSumaFr, tlSumaUp, tlPrevFr, tlPrevUp, tlNakFr, tlNakUp, tlNakCo, tlSumaFrDin, tlSumaUpDin, referent1 " & _
                                         "FROM dbo.SlogKalk " & _
                                         "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (ObrGodina = '" & qObrGodina & "') AND (ObrMesec = '" & qObrMesec & "') AND (SifraTarife = '00') " & _
                                         "ORDER BY Ugovor, Najava, ZsUlPrelaz, UlEtiketa, ZsIzPrelaz, IzEtiketa"

        End If

        If rbUgovor.Checked = True Then
            If TextBox1.Text <> "" Then
                mBrojUg = TextBox1.Text
                If TextBox2.Text <> "" Then
                    mNajava = TextBox2.Text

                    If Microsoft.VisualBasic.Mid(mNajava, 1, 1) = "X" Then
                        sql_UpitPregled = "SELECT dbo.SlogKalk.Najava, dbo.SlogKalk.OtpUprava, dbo.SlogKalk.OtpStanica, dbo.SlogKalk.OtpBroj, " & _
                                                     "dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.UlEtiketa, dbo.SlogKalk.ZsIzPrelaz, dbo.SlogKalk.IzEtiketa, dbo.SlogKalk.PrUprava, dbo.SlogKalk.PrStanica, dbo.SlogKalk.PrBroj, " & _
                                                     "UkupnoKola, dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.rSumaFr, dbo.SlogKalk.rPrevFr, dbo.SlogKalk.rNakFr, tlNakUp,tlNakCo,referent1 " & _
                                                     "FROM dbo.SlogKalk INNER JOIN " & _
                                                     "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                                                     "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND " & _
                                                     "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
                                                     "WHERE (dbo.SlogKalk.Saobracaj = '" & IzborSaobracaja & "') AND (dbo.SlogKalk.ObrGodina = '" & qObrGodina & "') AND (dbo.SlogKalk.ObrMesec = '" & qObrMesec & "')  " & _
                                                     "AND (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava2 = '" & mNajava & "') " & _
                                                     "ORDER BY dbo.SlogKalk.Najava, dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.UlEtiketa, dbo.SlogKalk.ZsIzPrelaz, dbo.SlogKalk.IzEtiketa"

                    Else
                        sql_UpitPregled = "SELECT dbo.SlogKalk.Najava, dbo.SlogKalk.OtpUprava, dbo.SlogKalk.OtpStanica, dbo.SlogKalk.OtpBroj, " & _
                                                     "dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.UlEtiketa, dbo.SlogKalk.ZsIzPrelaz, dbo.SlogKalk.IzEtiketa, dbo.SlogKalk.PrUprava, dbo.SlogKalk.PrStanica, dbo.SlogKalk.PrBroj, " & _
                                                     "UkupnoKola, dbo.SlogKola.IBK, dbo.SlogKola.Tara, dbo.SlogRoba.SMasa, dbo.SlogKalk.tlSumaFr, dbo.SlogKalk.tlPrevFr, dbo.SlogKalk.tlNakFr, dbo.SlogKalk.tlNakUp, tlNakCo,referent1 " & _
                                                     "FROM dbo.SlogKalk INNER JOIN " & _
                                                     "dbo.SlogKola ON dbo.SlogKalk.RecID = dbo.SlogKola.RecID AND dbo.SlogKalk.Stanica = dbo.SlogKola.Stanica INNER JOIN " & _
                                                     "dbo.SlogRoba ON dbo.SlogKola.RecID = dbo.SlogRoba.RecID AND dbo.SlogKola.Stanica = dbo.SlogRoba.Stanica AND " & _
                                                     "dbo.SlogKola.KolaStavka = dbo.SlogRoba.KolaStavka " & _
                                                     "WHERE (dbo.SlogKalk.Saobracaj = '" & IzborSaobracaja & "') AND (dbo.SlogKalk.ObrGodina = '" & qObrGodina & "') AND (dbo.SlogKalk.ObrMesec = '" & qObrMesec & "')  " & _
                                                     "AND (dbo.SlogKalk.Ugovor = '" & mBrojUg & "') AND (dbo.SlogKalk.Najava = '" & mNajava & "') " & _
                                                     "ORDER BY dbo.SlogKalk.Najava, dbo.SlogKalk.ZsUlPrelaz, dbo.SlogKalk.UlEtiketa, dbo.SlogKalk.ZsIzPrelaz, dbo.SlogKalk.IzEtiketa"

                    End If

                Else

                    If IzborSaobracaja = "4" Then
                        sql_UpitPregled = "SELECT OtpUprava, OtpStanica, OtpBroj, OtpDatum, ZsUlPrelaz, UlEtiketa, ZsIzPrelaz, IzEtiketa, PrUprava, PrStanica, PrBroj, Najava, UkupnoKola, tlSumaFr, tlPrevFr, tlNakFr, tlNakUp, tlNakUp,tlNakCo,referent1 " & _
                                                     "FROM dbo.SlogKalk " & _
                                                     "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (ObrGodina = '" & qObrGodina & "') AND (ObrMesec = '" & qObrMesec & "')  " & _
                                                     "AND (Ugovor = '" & mBrojUg & "')  " & _
                                                     "ORDER BY ZsUlPrelaz, UlEtiketa, ZsIzPrelaz, IzEtiketa"
                    ElseIf (IzborSaobracaja = "2" Or IzborSaobracaja = "3") Then
                        sql_UpitPregled = "SELECT Ugovor, Najava, OtpUprava, OtpStanica, OtpBroj, OtpDatum, ZsUlPrelaz, UlEtiketa, ZsIzPrelaz, IzEtiketa, PrUprava, PrStanica,  PrBroj, UkupnoKola,tlPrevFr, tlPrevUp, tlNakFr, tlNakUp,tlSumaFr, tlSumaUp, tlNakCo, tlPrevFrDin, tlPrevUpDin,  tlSumaFrDin, tlSumaUpDin, referent1 " & _
                                                                                           "FROM dbo.SlogKalk " & _
                                                                                           "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (ObrGodina = '" & qObrGodina & "') AND (ObrMesec = '" & qObrMesec & "')  " & _
                                                                                           "AND (Ugovor = '" & mBrojUg & "')  " & _
                                                                                           "ORDER BY Ugovor,OtpStanica, OtpBroj"
                    End If
                End If
            End If
        End If

        btnPrihvati_MouseUp1(Me, Nothing)

    End Sub

    Private Sub btnPrihvati_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPrihvati.MouseUp
        If EventsActived = True Then
            'Me.EventsActived = False
            EventsActived = False
            Dim Form2 As New FormGrid
            Form2.ShowDialog()

        End If

    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Me.Close()

    End Sub

    Private Sub rbUgovor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbUgovor.Click
    

        TextBox1.Enabled = True
        TextBox2.Enabled = True

    End Sub

    Private Sub rbSve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSve.Click
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        mBrojUg = TextBox1.Text
        mNajava = TextBox2.Text


    End Sub

    Private Sub rbUgovori_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbUgovori.Click
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        mBrojUg = TextBox1.Text
        mNajava = TextBox2.Text

    End Sub

    Private Sub FormPregledTL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '        btnPrihvati.Focus()
        Me.NumericUpDown1.Value = Today.Month.ToString

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If

    End Sub
End Class
