Imports System.Data.SqlClient
Public Class PregledPoNajavi
    Inherits System.Windows.Forms.Form

    Dim ds1 As New DataSet("ds1") ' SlogKalk
    Dim ds2 As New DataSet("ds2") ' SlogKola
    Dim ds3 As New DataSet("ds3") ' SlogRoba
    Dim ds4 As New DataSet("ds4") ' Naknade
    'Dim ds5 As New DataSet("ds5") ' Kont. primedbe
    Dim ds6 As New DataSet("ds6") ' PDV
    Dim ds7 As New DataSet("ds7") ' Manip. mesta
    Dim ds8 As New DataSet("ds8") ' naplata na blagajni uz CO

    Dim bpDataSetRoba As New DataSet("bpDataSetRoba")  'SlogRoba za pregled
    Dim bPregledRecID As Integer


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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid3 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid4 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid6 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid7 As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents bpDataGridRoba As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid8 As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.DataGrid3 = New System.Windows.Forms.DataGrid
        Me.DataGrid4 = New System.Windows.Forms.DataGrid
        Me.DataGrid7 = New System.Windows.Forms.DataGrid
        Me.DataGrid6 = New System.Windows.Forms.DataGrid
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.bpDataGridRoba = New System.Windows.Forms.DataGrid
        Me.DataGrid8 = New System.Windows.Forms.DataGrid
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bpDataGridRoba, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 32)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(896, 184)
        Me.DataGrid1.TabIndex = 0
        '
        'DataGrid2
        '
        Me.DataGrid2.CaptionText = "Kola"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(16, 240)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.Size = New System.Drawing.Size(432, 144)
        Me.DataGrid2.TabIndex = 1
        '
        'DataGrid3
        '
        Me.DataGrid3.CaptionText = "Roba"
        Me.DataGrid3.DataMember = ""
        Me.DataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid3.Location = New System.Drawing.Point(480, 240)
        Me.DataGrid3.Name = "DataGrid3"
        Me.DataGrid3.Size = New System.Drawing.Size(432, 144)
        Me.DataGrid3.TabIndex = 2
        '
        'DataGrid4
        '
        Me.DataGrid4.CaptionText = "Naknade"
        Me.DataGrid4.DataMember = ""
        Me.DataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid4.Location = New System.Drawing.Point(16, 400)
        Me.DataGrid4.Name = "DataGrid4"
        Me.DataGrid4.Size = New System.Drawing.Size(432, 136)
        Me.DataGrid4.TabIndex = 3
        '
        'DataGrid7
        '
        Me.DataGrid7.CaptionText = "Manipulativna mesta"
        Me.DataGrid7.DataMember = ""
        Me.DataGrid7.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid7.Location = New System.Drawing.Point(480, 400)
        Me.DataGrid7.Name = "DataGrid7"
        Me.DataGrid7.Size = New System.Drawing.Size(200, 88)
        Me.DataGrid7.TabIndex = 4
        '
        'DataGrid6
        '
        Me.DataGrid6.CaptionText = "PDV"
        Me.DataGrid6.DataMember = ""
        Me.DataGrid6.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid6.Location = New System.Drawing.Point(704, 400)
        Me.DataGrid6.Name = "DataGrid6"
        Me.DataGrid6.Size = New System.Drawing.Size(208, 88)
        Me.DataGrid6.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1016, 512)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Zatvori"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(648, 512)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Korekcija"
        '
        'bpDataGridRoba
        '
        Me.bpDataGridRoba.DataMember = ""
        Me.bpDataGridRoba.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.bpDataGridRoba.Location = New System.Drawing.Point(920, 240)
        Me.bpDataGridRoba.Name = "bpDataGridRoba"
        Me.bpDataGridRoba.Size = New System.Drawing.Size(232, 248)
        Me.bpDataGridRoba.TabIndex = 8
        '
        'DataGrid8
        '
        Me.DataGrid8.CaptionText = "Blagajna uz CO"
        Me.DataGrid8.DataMember = ""
        Me.DataGrid8.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid8.Location = New System.Drawing.Point(920, 32)
        Me.DataGrid8.Name = "DataGrid8"
        Me.DataGrid8.Size = New System.Drawing.Size(232, 144)
        Me.DataGrid8.TabIndex = 9
        '
        'PregledPoNajavi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1160, 562)
        Me.Controls.Add(Me.DataGrid8)
        Me.Controls.Add(Me.bpDataGridRoba)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid6)
        Me.Controls.Add(Me.DataGrid7)
        Me.Controls.Add(Me.DataGrid4)
        Me.Controls.Add(Me.DataGrid3)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "PregledPoNajavi"
        Me.Text = "Pregled po najavi"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bpDataGridRoba, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub PregledPoNajavi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ii1 As Int32 'Broj ucitanih slogova
        Dim ii2 As Int32 'Broj ucitanih slogova
        'Dim bObrMesec77 As String = "77"

        'If bPregledTekucegMeseca Then
        '    bPostaviObracunskiMesec(bPregledObrMesec, bPregledObrGodina)
        'End If

        DataGrid1.AllowSorting = False

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        Dim SQLTxt As String = ""
        Dim bpSQLTxt As String = ""

        Dim OrderString As String = "" ' "ORDER BY OtpStanica, OtpBroj, Ugovor"

        'If bOrder = 1 Then
        '    OrderString = "ORDER BY OtpStanica, OtpBroj, Ugovor"
        'ElseIf bOrder = 2 Then
        '    OrderString = "ORDER BY OtpBroj, OtpStanica, Ugovor"
        'ElseIf bOrder = 3 Then
        '    OrderString = "ORDER BY PrStanica, PrBroj, Ugovor"
        'ElseIf bOrder = 4 Then
        '    OrderString = "ORDER BY PrBroj, PrStanica, Ugovor"
        'ElseIf bOrder = 5 Then
        '    OrderString = "ORDER BY Ugovor, OtpStanica, OtpBroj"
        'End If

        OrderString = "ORDER BY dbo.SlogKalk.RecID"

        'Dim SQLTxt1 = "SELECT Right(dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, dbo.SlogKalk.SifraTarife AS Tarifa,Ugovor, Posiljalac, Primalac, VrPos,Prevoz, Saobracaj, VrSao, VrPrevoza, dbo.SlogKalk.Narpos AS NP,UkupnoKola, dbo.SlogKalk.PrevozniPutZs AS PP,dbo.SlogKalk.StanicaRee AS StanicaVia,dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SkmZS AS skm,dbo.SlogKalk.SifraIzjave AS Izjava, tlSumaFrDin, tlPrevFrDin, tlNakFrDin, tlSumaUpDin, tlPrevUpDin, tlNakUpDin, (tlSumaFrDin+rSumaFrDin)AS FRANKO, (tlSumaUpDin+rSumaUpDin) AS UPUCENO, rSumaFrDin, rSumaUpDin, tlNakCo82, dbo.SlogKalk.referent1 AS R , dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
        '                                             "FROM dbo.SlogKalk " & _
        '                                             "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (DatumObrade = " & "'" & Today.Month.ToString & "." & Today.Day.ToString & "." & Today.Year.ToString & "') " & _
        '                                             OrderString

        'Dim SQLTxt2 = "SELECT Right(dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, dbo.SlogKalk.SifraTarife AS Tarifa,Ugovor, Posiljalac, Primalac, VrPos,Prevoz, Saobracaj, VrSao, VrPrevoza, dbo.SlogKalk.Narpos AS NP,UkupnoKola, dbo.SlogKalk.PrevozniPutZs AS PP,dbo.SlogKalk.StanicaRee AS StanicaVia,dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SkmZS AS skm,dbo.SlogKalk.SifraIzjave AS Izjava, tlSumaFrDin, tlPrevFrDin, tlNakFrDin, tlSumaUpDin, tlPrevUpDin, tlNakUpDin, (tlSumaFrDin+rSumaFrDin)AS FRANKO, (tlSumaUpDin+rSumaUpDin) AS UPUCENO, rSumaFrDin, rSumaUpDin ,tlNakCo82, dbo.SlogKalk.referent1 AS R , dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
        '                                             "FROM dbo.SlogKalk " & _
        '                                             "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (ObrGodina = '" & bPregledObrGodina & "') AND (ObrMesec = '" & bPregledObrMesec & "') " & _
        '                                             OrderString

        'Dim SQLTxt3 = "SELECT dbo.SlogKalk.Najava, Right( dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, Ugovor, UkupnoKola, dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SifraIzjave AS Izjava, tlSumaFrDin, tlPrevFrDin, tlNakFrDin, tlSumaUpDin, tlPrevUpDin, tlNakUpDin, (tlSumaFrDin+rSumaFrDin)AS FRANKO, (tlSumaUpDin+rSumaUpDin) AS UPUCENO, rSumaFrDin, rSumaUpDin ,tlNakCo82 AS PDV,  dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
        '                                             "FROM dbo.SlogKalk " & _
        '                                             "WHERE (Najava = '" & bNajava & "') AND (DatumOtp >= '" & bpDatumOd & "') AND (DatumOtp <= '" & bpDatumDo & "')" & _
        '                                             OrderString
        'Dim SQLTxt4 = "SELECT dbo.SlogKalk.Najava, Right( dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, Ugovor, UkupnoKola, dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SifraIzjave AS Izjava,  tlPrevFrDin, tlNakFrDin, tlSumaFrDin,  tlPrevUpDin, tlNakUpDin, tlSumaUpDin,(tlSumaFrDin+rSumaFrDin)AS FRANKO, (tlSumaUpDin+rSumaUpDin) AS UPUCENO, rSumaFrDin, rSumaUpDin ,tlPrevFr, tlNakFr, tlSumaFr,  tlPrevUp, tlNakUp, tlSumaUp,tlNakCo82 AS PDV, dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
        '                                             "FROM dbo.SlogKalk " & _
        '                                             "WHERE (Najava = '" & bNajava & "')" & _
        '                                             OrderString
        'If DatumPrikaza = "Dnevni" Then
        '    SQLTxt = SQLTxt1
        '    Me.DataGrid1.CaptionText = "Pregled tovarnih listova unetih danas"
        'ElseIf DatumPrikaza = "Mesecni" Then
        '    SQLTxt = SQLTxt2
        '    If bPregledTekucegMeseca Then
        '        Me.DataGrid1.CaptionText = "Pregled tovarnih listova unetih tekuceg obracunskog meseca"
        '    Else
        '        Me.DataGrid1.CaptionText = "Pregled tovarnih listova unetih   " & bPregledObrMesec & "." & bPregledObrGodina & "."
        '    End If
        'End If

        'Dim SQLRSD1 = "SELECT dbo.SlogKalk.Najava, Right( dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, Ugovor, UkupnoKola, dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SifraIzjave AS Izjava,  tlPrevFrDin, tlNakFrDin, tlSumaFrDin,  tlPrevUpDin, tlNakUpDin, tlSumaUpDin ,tlNakCo82 AS PDV82, dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
        '                                                     "FROM dbo.SlogKalk " & _
        '                                                     "WHERE (Najava = '" & bNajava & "') And  (Ugovor = '" & bpUgovor & "')" & _
        '                                                     OrderString


        'Dim SQLEUR1 = "SELECT dbo.SlogKalk.Najava, Right( dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, Ugovor, UkupnoKola, dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SifraIzjave AS Izjava,  tlPrevFr, tlNakFr, tlSumaFr,  tlPrevUp, tlNakUp, tlSumaUp ,tlNakCo82 AS PDV82, dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
        '                                                            "FROM dbo.SlogKalk " & _
        '                                                            "WHERE (Najava = '" & bNajava & "' And  (Ugovor = '" & bpUgovor & "'))" & _
        '                                                            OrderString

        Dim SQLRSD1 = "SELECT dbo.SlogKalk.Najava, Right( dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, Ugovor, UkupnoKola, dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SifraIzjave AS Izjava,  tlPrevFrDin, tlNakFrDin, tlSumaFrDin,  tlPrevUpDin, tlNakUpDin, tlSumaUpDin ,tlNakCo82 AS PDV82, dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
                                                               "FROM dbo.SlogKalk " & _
                                                               "WHERE (Najava = '" & bNajava & "') And  (Ugovor = '" & bpUgovor & "')" & _
                                                               "And (dbo.SlogKalk.DatumObrade >= CONVERT(DATETIME, '" & bpDatumOdStr & "', 102)) AND (dbo.SlogKalk.DatumObrade <= CONVERT(DATETIME, '" & bpDatumDoStr & "', 102))" & OrderString


        Dim SQLEUR1 = "SELECT dbo.SlogKalk.Najava, Right( dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, Ugovor, UkupnoKola, dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SifraIzjave AS Izjava,  tlPrevFr, tlNakFr, tlSumaFr,  tlPrevUp, tlNakUp, tlSumaUp ,tlNakCo82 AS PDV82, dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
                                                               "FROM dbo.SlogKalk " & _
                                                               "WHERE (Najava = '" & bNajava & "' And  (Ugovor = '" & bpUgovor & "'))" & _
                                                                "And (dbo.SlogKalk.DatumObrade >= CONVERT(DATETIME, '" & bpDatumOdStr & "', 102)) AND (dbo.SlogKalk.DatumObrade <= CONVERT(DATETIME, '" & bpDatumDoStr & "', 102))" & OrderString


        If bpValuta = "RSD" = True Then
            SQLTxt = SQLRSD1
        Else
            SQLTxt = SQLEUR1
        End If


        'If bOrder = 77 Then
        '    OrderString = "ORDER BY OtpStanica, OtpBroj, Ugovor"
        '    SQLTxt = "SELECT Right(dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, dbo.SlogKalk.SifraTarife AS Tarifa,Ugovor, Posiljalac, Primalac, VrPos,Prevoz, Saobracaj, VrSao, VrPrevoza, dbo.SlogKalk.Narpos AS NP,UkupnoKola, dbo.SlogKalk.PrevozniPutZs AS PP,dbo.SlogKalk.StanicaRee AS StanicaVia,dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SkmZS AS skm,dbo.SlogKalk.SifraIzjave AS Izjava, tlSumaFrDin, tlPrevFrDin, tlNakFrDin, tlSumaUpDin, tlPrevUpDin, tlNakUpDin, (tlSumaFrDin+rSumaFrDin)AS FRANKO, (tlSumaUpDin+rSumaUpDin) AS UPUCENO, rSumaFrDin, rSumaUpDin, tlNakCo82, dbo.SlogKalk.referent1 AS R , dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
        '                                                         "FROM dbo.SlogKalk " & _
        '                                                         "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (ObrMesec = 77) " & OrderString

        'End If


        Dim ad1 As New SqlDataAdapter(SQLTxt, OkpDbVeza)         'DataAdapter
       
        Try

            ii1 = ad1.Fill(ds1)
            DataGrid1.DataSource = ds1.Tables(0)

            'ii1 = bpAdapterRoba.Fill(bpDataSetRoba)
            'bpDataGridRoba.DataSource = bpDataSetRoba.Tables(0)


            'tableTemp =  DataGrid1.DataSource

            '            Me.bindingSourceBerechnung.DataSource = tableTempJDL
            'Later on, you can bind above binding source in your datagridview in following way:
            '            Me.DataGridViewBerechnung.DataSource = Me.bindingSourceBerechnung

        Catch ex As Exception
            MessageBox.Show("Baza nije otvorena!", "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try


        ' ucitavanje iz tabela za izabranu najavu:

        If bpJedanTLPoNajavi = "1" Then
            bpUkupnoKolaPoNajavi = ds1.Tables(0).Rows(0).Item(8)
        Else
            bpUkupnoKolaPoNajavi = ds1.Tables(0).Rows.Count
        End If



        Dim k As Integer
        For k = 0 To bpUkupnoKolaPoNajavi - 1
            bpRecIDNiz(k) = 0
            bpStvMasa(k) = 0
            bpRacMasa(k) = 0
        Next

        bpDataSetRoba.Clear()
       
        For k = 0 To bpUkupnoKolaPoNajavi - 1

            If bpJedanTLPoNajavi = "1" Then
                bpRecIDNiz(k) = ds1.Tables(0).Rows(0).Item(18)
            Else
                bpRecIDNiz(k) = ds1.Tables(0).Rows(k).Item(18)
            End If


            If bpJedanTLPoNajavi = "0" Then             ' više TL
                Dim bpAdapterRoba As New SqlDataAdapter(" SELECT SMasa, RMasa, VozStav " _
                                                                    & " FROM   dbo.SlogRoba " _
                                                                    & " WHERE (dbo.SlogRoba.RecID = '" & bpRecIDNiz(k) & "')", OkpDbVeza)
                ii2 = bpAdapterRoba.Fill(bpDataSetRoba)
            Else                                        ' jedan TL                                                                     
                Dim bpAdapterRoba As New SqlDataAdapter(" SELECT SMasa, RMasa, VozStav " _
                                                                    & " FROM   dbo.SlogRoba " _
                                                                    & " WHERE (dbo.SlogRoba.RecID = '" & bpRecIDNiz(k) & "') AND (dbo.SlogRoba.KolaStavka = '" & (k + 1) & "') ", OkpDbVeza)
                ii2 = bpAdapterRoba.Fill(bpDataSetRoba)

            End If

            bpDataGridRoba.DataSource = bpDataSetRoba.Tables(0)

            bpStvMasa(k) = bpDataSetRoba.Tables(0).Rows(k).Item(0)
            bpRacMasa(k) = bpDataSetRoba.Tables(0).Rows(k).Item(1)
            bpVozStav(k) = bpDataSetRoba.Tables(0).Rows(k).Item(2)
        Next

        bpPrevozninaPoNajavi = 0
        bpRacMasaPoNajavi = 0
        bpVozStavPonajavi = 0
        bpSumaPoNajavi = 0
        bpPDVPoNajavi = 0

        bpPrevozninaPoNajavi = ds1.Tables(0).Rows(0).Item(11)
        For k = 0 To bpUkupnoKolaPoNajavi - 1
            bpRacMasaPoNajavi = bpRacMasaPoNajavi + bpStvMasa(k)
        Next
        bZaokruziMasuNa100k(bpRacMasaPoNajavi)

        bpVozStavPonajavi = bpVozStav(0)
        bpSumaPoNajavi = ds1.Tables(0).Rows(0).Item(13)
        bpPDVPoNajavi = ds1.Tables(0).Rows(0).Item(17)

        'If ds1.Tables(0).Rows(jj).Item(17) <> "00000000000" Then
        '    drNHM.ItemArray() = New Object() {dsSlogKola.Tables(0).Rows(jj).Item(0), dsSlogKola.Tables(0).Rows(jj).Item(4), _
        '                                      dsSlogKola.Tables(0).Rows(jj).Item(3), 1, "0", _
        '                                      dsSlogKola.Tables(0).Rows(jj).Item(18), dsSlogKola.Tables(0).Rows(jj).Item(17), _
        '                                      dsSlogKola.Tables(0).Rows(jj).Item(19), 0, dsSlogKola.Tables(0).Rows(jj).Item(21), _
        '                                      dsSlogKola.Tables(0).Rows(jj).Item(22), "", "I"}
        '    dtNhm.Rows.Add(drNHM)
        'End If



        OkpDbVeza.Close()
    End Sub
    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click

        ds2.Clear()
        ds3.Clear()
        ds4.Clear()
        'ds5.Clear()
        ds6.Clear()
        ds7.Clear()
        ds8.Clear()

        Dim ii2 As Int32
        Dim ii3 As Int32
        Dim ii4 As Int32
        Dim ii5 As Int32
        Dim ii6 As Int32
        Dim ii7 As Int32
        Dim ii8 As Int32

        Dim currRowKola As DataRow

        '            Me.bindingSourceBerechnung.DataSource = tableTempJDL
        'Later on, you can bind above binding source in your datagridview in following way:
        '            Me.DataGridViewBerechnung.DataSource = Me.bindingSourceBerechnung

        'Me.DataGrid1.DataSource = tableTemp

        currRowKola = CType(Me.DataGrid1.DataSource, DataTable).Rows(DataGrid1.CurrentCell.RowNumber)

        'bPregledRecID = currRowKola(34, DataRowVersion.Current)
        'bPregledRecID = currRowKola(22, DataRowVersion.Current)
        bPregledRecID = currRowKola(18, DataRowVersion.Current)

        Dim ad2 As New SqlDataAdapter(" SELECT KolaStavka AS RBKola, IBK, Kontrola, Uprava, Vlasnik, Serija, Osovine, Tara, GranTov, Stitna, TipKola " _
                                    & " FROM   dbo.SlogKola " _
                                    & " WHERE (dbo.SlogKola.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad3 As New SqlDataAdapter(" SELECT KolaStavka AS RBKola, RobaStavka AS RBRobe, NHM, NHMRazred, SMasa, RMasa, RID, VozStav " _
                                    & " FROM   dbo.SlogRoba " _
                                    & " WHERE (dbo.SlogRoba.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad4 As New SqlDataAdapter(" SELECT NaknadeStavka AS RBNaknade, SifraNaknade, IvicniBroj, Iznos, Valuta, Kolicina, DanCas, Placanje, Vrsta " _
                                    & " FROM   dbo.SlogNaknada " _
                                    & " WHERE (dbo.SlogNaknada.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        'Dim ad5 As New SqlDataAdapter(" SELECT Stavka AS RBPrimedbe, SifraK211 AS SifraPrimedbe " _
        '                            & " FROM   dbo.SlogK211 " _
        '                            & " WHERE (dbo.SlogK211.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad6 As New SqlDataAdapter(" SELECT PDV1, PDV2  " _
                                    & " FROM   dbo.SlogKalkPDV " _
                                    & " WHERE (dbo.SlogKalkPDV.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad7 As New SqlDataAdapter(" SELECT PodStanica1, PodStanica2 " _
                                    & " FROM   dbo.SlogKalkPS " _
                                    & " WHERE (dbo.SlogKalkPS.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad8 As New SqlDataAdapter(" SELECT Iznos1 as BlagFrCO, Iznos2 as  RazlBlagFrCO, Iznos3 as BlagUpCO, Iznos4 as RazlBlagUPCO " _
                                          & " FROM   dbo.SlogKalkPlusOKP " _
                                          & " WHERE (dbo.SlogKalkPlusOKP.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        ii2 = ad2.Fill(ds2)
        ii3 = ad3.Fill(ds3)
        ii4 = ad4.Fill(ds4)
        'ii5 = ad5.Fill(ds5)
        ii6 = ad6.Fill(ds6)
        ii7 = ad7.Fill(ds7)
        ii8 = ad8.Fill(ds8)

        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            DataGrid2.DataSource = ds2.Tables(0)
            DataGrid3.DataSource = ds3.Tables(0)
            DataGrid4.DataSource = ds4.Tables(0)
            'DataGrid5.DataSource = ds5.Tables(0)
            DataGrid6.DataSource = ds6.Tables(0)
            DataGrid7.DataSource = ds7.Tables(0)
            DataGrid8.DataSource = ds8.Tables(0)

        Catch ex As Exception
            MessageBox.Show("Baza nije otvorena!", "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim FormKPN As New KorekcijaPoNajavi
        FormKPN.ShowDialog()
    End Sub

End Class
