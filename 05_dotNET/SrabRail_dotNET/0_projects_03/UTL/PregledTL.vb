Imports System.Data.SqlClient

Public Class PregledTL
    Inherits System.Windows.Forms.Form
    Public mUg As String
    Public mUgAn As String

    Dim ds1 As New DataSet("ds1") ' SlogKalk
    Dim ds2 As New DataSet("ds2") ' SlogKola
    Dim ds3 As New DataSet("ds3") ' SlogRoba
    Dim ds4 As New DataSet("ds4") ' Naknade
    Dim ds5 As New DataSet("ds5") ' Kont. primedbe
    Dim ds6 As New DataSet("ds6") ' PDV
    Dim ds7 As New DataSet("ds7") ' Manip. mesta

    Dim Forma1 As Form1

    Dim bPregledRecID As Integer

    Dim tableTemp As DataTable


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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid3 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid4 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid5 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid6 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid8 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid7 As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.DataGrid3 = New System.Windows.Forms.DataGrid
        Me.DataGrid4 = New System.Windows.Forms.DataGrid
        Me.DataGrid8 = New System.Windows.Forms.DataGrid
        Me.DataGrid6 = New System.Windows.Forms.DataGrid
        Me.DataGrid5 = New System.Windows.Forms.DataGrid
        Me.DataGrid7 = New System.Windows.Forms.DataGrid
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(17, 10)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(991, 206)
        Me.DataGrid1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(904, 680)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 32)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Zatvori"
        '
        'DataGrid2
        '
        Me.DataGrid2.BackgroundColor = System.Drawing.Color.Gray
        Me.DataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.DataGrid2.CaptionForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.DataGrid2.CaptionText = "Kola"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(16, 224)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.Size = New System.Drawing.Size(480, 232)
        Me.DataGrid2.TabIndex = 8
        '
        'DataGrid3
        '
        Me.DataGrid3.BackgroundColor = System.Drawing.Color.Gray
        Me.DataGrid3.CaptionBackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.DataGrid3.CaptionForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.DataGrid3.CaptionText = "Roba"
        Me.DataGrid3.DataMember = ""
        Me.DataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid3.Location = New System.Drawing.Point(504, 224)
        Me.DataGrid3.Name = "DataGrid3"
        Me.DataGrid3.ReadOnly = True
        Me.DataGrid3.Size = New System.Drawing.Size(504, 232)
        Me.DataGrid3.TabIndex = 9
        '
        'DataGrid4
        '
        Me.DataGrid4.BackgroundColor = System.Drawing.Color.Gray
        Me.DataGrid4.CaptionBackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.DataGrid4.CaptionForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.DataGrid4.CaptionText = "Naknade"
        Me.DataGrid4.DataMember = ""
        Me.DataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid4.Location = New System.Drawing.Point(16, 464)
        Me.DataGrid4.Name = "DataGrid4"
        Me.DataGrid4.ReadOnly = True
        Me.DataGrid4.Size = New System.Drawing.Size(736, 152)
        Me.DataGrid4.TabIndex = 10
        '
        'DataGrid8
        '
        Me.DataGrid8.BackgroundColor = System.Drawing.Color.Gray
        Me.DataGrid8.CaptionBackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.DataGrid8.CaptionForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.DataGrid8.CaptionText = "Prevozni put"
        Me.DataGrid8.DataMember = ""
        Me.DataGrid8.Enabled = False
        Me.DataGrid8.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid8.Location = New System.Drawing.Point(304, 632)
        Me.DataGrid8.Name = "DataGrid8"
        Me.DataGrid8.ReadOnly = True
        Me.DataGrid8.Size = New System.Drawing.Size(296, 48)
        Me.DataGrid8.TabIndex = 13
        Me.DataGrid8.Visible = False
        '
        'DataGrid6
        '
        Me.DataGrid6.BackgroundColor = System.Drawing.Color.Gray
        Me.DataGrid6.CaptionBackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.DataGrid6.CaptionForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.DataGrid6.CaptionText = "PDV"
        Me.DataGrid6.DataMember = ""
        Me.DataGrid6.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid6.Location = New System.Drawing.Point(16, 632)
        Me.DataGrid6.Name = "DataGrid6"
        Me.DataGrid6.ReadOnly = True
        Me.DataGrid6.Size = New System.Drawing.Size(200, 64)
        Me.DataGrid6.TabIndex = 14
        '
        'DataGrid5
        '
        Me.DataGrid5.BackgroundColor = System.Drawing.Color.Gray
        Me.DataGrid5.CaptionBackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.DataGrid5.CaptionForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.DataGrid5.CaptionText = "Kontrolne primedbe"
        Me.DataGrid5.DataMember = ""
        Me.DataGrid5.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid5.Location = New System.Drawing.Point(760, 464)
        Me.DataGrid5.Name = "DataGrid5"
        Me.DataGrid5.ReadOnly = True
        Me.DataGrid5.Size = New System.Drawing.Size(240, 96)
        Me.DataGrid5.TabIndex = 15
        '
        'DataGrid7
        '
        Me.DataGrid7.BackgroundColor = System.Drawing.Color.Gray
        Me.DataGrid7.CaptionBackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.DataGrid7.CaptionForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.DataGrid7.CaptionText = "Manipulativna mesta"
        Me.DataGrid7.DataMember = ""
        Me.DataGrid7.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid7.Location = New System.Drawing.Point(760, 568)
        Me.DataGrid7.Name = "DataGrid7"
        Me.DataGrid7.ReadOnly = True
        Me.DataGrid7.Size = New System.Drawing.Size(240, 64)
        Me.DataGrid7.TabIndex = 16
        '
        'PregledTL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.DataGrid7)
        Me.Controls.Add(Me.DataGrid5)
        Me.Controls.Add(Me.DataGrid6)
        Me.Controls.Add(Me.DataGrid8)
        Me.Controls.Add(Me.DataGrid4)
        Me.Controls.Add(Me.DataGrid3)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "PregledTL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pregled tovarnog lista"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PregledTL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ii1 As Int32 'Broj ucitanih slogova
        'Dim bObrMesec77 As String = "77"

        If bPregledTekucegMeseca Then
            bPostaviObracunskiMesec(bPregledObrMesec, bPregledObrGodina)
        End If

        DataGrid1.AllowSorting = False

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If
        Dim SQLTxt As String = ""

        Dim OrderString As String = "ORDER BY OtpStanica, OtpBroj, Ugovor"

        If bOrder = 1 Then
            OrderString = "ORDER BY OtpStanica, OtpBroj, Ugovor"
        ElseIf bOrder = 2 Then
            OrderString = "ORDER BY OtpBroj, OtpStanica, Ugovor"
        ElseIf bOrder = 3 Then
            OrderString = "ORDER BY PrStanica, PrBroj, Ugovor"
        ElseIf bOrder = 4 Then
            OrderString = "ORDER BY PrBroj, PrStanica, Ugovor"
        ElseIf bOrder = 5 Then
            OrderString = "ORDER BY Ugovor, OtpStanica, OtpBroj"
        End If


        Dim SQLTxt1 = "SELECT Right(dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, dbo.SlogKalk.SifraTarife AS Tarifa,Ugovor, Posiljalac, Primalac, VrPos,Prevoz, Saobracaj, VrSao, VrPrevoza, dbo.SlogKalk.Narpos AS NP,UkupnoKola, dbo.SlogKalk.PrevozniPutZs AS PP,dbo.SlogKalk.StanicaRee AS StanicaVia,dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SkmZS AS skm,dbo.SlogKalk.SifraIzjave AS Izjava, tlSumaFrDin, tlPrevFrDin, tlNakFrDin, tlSumaUpDin, tlPrevUpDin, tlNakUpDin, (tlSumaFrDin+rSumaFrDin)AS FRANKO, (tlSumaUpDin+rSumaUpDin) AS UPUCENO, rSumaFrDin, rSumaUpDin, tlNakCo82, dbo.SlogKalk.referent1 AS R , dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
                                                     "FROM dbo.SlogKalk " & _
                                                     "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (DatumObrade = " & "'" & Today.Month.ToString & "." & Today.Day.ToString & "." & Today.Year.ToString & "') " & _
                                                     OrderString

        Dim SQLTxt2 = "SELECT Right(dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, dbo.SlogKalk.SifraTarife AS Tarifa,Ugovor, Posiljalac, Primalac, VrPos,Prevoz, Saobracaj, VrSao, VrPrevoza, dbo.SlogKalk.Narpos AS NP,UkupnoKola, dbo.SlogKalk.PrevozniPutZs AS PP,dbo.SlogKalk.StanicaRee AS StanicaVia,dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SkmZS AS skm,dbo.SlogKalk.SifraIzjave AS Izjava, tlSumaFrDin, tlPrevFrDin, tlNakFrDin, tlSumaUpDin, tlPrevUpDin, tlNakUpDin, (tlSumaFrDin+rSumaFrDin)AS FRANKO, (tlSumaUpDin+rSumaUpDin) AS UPUCENO, rSumaFrDin, rSumaUpDin ,tlNakCo82, dbo.SlogKalk.referent1 AS R , dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
                                                     "FROM dbo.SlogKalk " & _
                                                     "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (ObrGodina = '" & bPregledObrGodina & "') AND (ObrMesec = '" & bPregledObrMesec & "') " & _
                                                     OrderString

        If DatumPrikaza = "Dnevni" Then
            SQLTxt = SQLTxt1
            Me.DataGrid1.CaptionText = "Pregled tovarnih listova unetih danas"
        ElseIf DatumPrikaza = "Mesecni" Then
            SQLTxt = SQLTxt2
            If bPregledTekucegMeseca Then
                Me.DataGrid1.CaptionText = "Pregled tovarnih listova unetih tekuceg obracunskog meseca"
            Else
                Me.DataGrid1.CaptionText = "Pregled tovarnih listova unetih   " & bPregledObrMesec & "." & bPregledObrGodina & "."
            End If




        End If


        If bOrder = 77 Then
            OrderString = "ORDER BY OtpStanica, OtpBroj, Ugovor"
            SQLTxt = "SELECT Right(dbo.SlogKalk.OtpStanica,5) AS OtSt, dbo.SlogKalk.OtpBroj AS BrOt, dbo.SlogKalk.OtpDatum AS DatOt, Right(dbo.SlogKalk.PrStanica,5) AS UpSt,dbo.SlogKalk.PrBroj AS BrPr, dbo.SlogKalk.PrDatum AS DatPr, dbo.SlogKalk.SifraTarife AS Tarifa,Ugovor, Posiljalac, Primalac, VrPos,Prevoz, Saobracaj, VrSao, VrPrevoza, dbo.SlogKalk.Narpos AS NP,UkupnoKola, dbo.SlogKalk.PrevozniPutZs AS PP,dbo.SlogKalk.StanicaRee AS StanicaVia,dbo.SlogKalk.TkmZs AS tkm ,dbo.SlogKalk.SkmZS AS skm,dbo.SlogKalk.SifraIzjave AS Izjava, tlSumaFrDin, tlPrevFrDin, tlNakFrDin, tlSumaUpDin, tlPrevUpDin, tlNakUpDin, (tlSumaFrDin+rSumaFrDin)AS FRANKO, (tlSumaUpDin+rSumaUpDin) AS UPUCENO, rSumaFrDin, rSumaUpDin, tlNakCo82, dbo.SlogKalk.referent1 AS R , dbo.SlogKalk.RecID , dbo.SlogKalk.ObrMesec, dbo.SlogKalk.ObrGodina " & _
                                                                 "FROM dbo.SlogKalk " & _
                                                                 "WHERE (Saobracaj = '" & IzborSaobracaja & "') AND (ObrMesec = 77) " & OrderString



        End If


        Dim ad1 As New SqlDataAdapter(SQLTxt, OkpDbVeza)         'DataAdapter


        Try

            ii1 = ad1.Fill(ds1)
            DataGrid1.DataSource = ds1.Tables(0)

            'tableTemp =  DataGrid1.DataSource

            '            Me.bindingSourceBerechnung.DataSource = tableTempJDL
            'Later on, you can bind above binding source in your datagridview in following way:
            '            Me.DataGridViewBerechnung.DataSource = Me.bindingSourceBerechnung

        Catch ex As Exception
            MessageBox.Show("Baza nije otvorena!", "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        OkpDbVeza.Close()
    End Sub

    Public Sub setOutData(ByRef form1 As Form1)
        Forma1 = form1
    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click

        ds2.Clear()
        ds3.Clear()
        ds4.Clear()
        ds5.Clear()
        ds6.Clear()
        ds7.Clear()

        Dim ii2 As Int32
        Dim ii3 As Int32
        Dim ii4 As Int32
        Dim ii5 As Int32
        Dim ii6 As Int32
        Dim ii7 As Int32

        Dim currRowKola As DataRow

        '            Me.bindingSourceBerechnung.DataSource = tableTempJDL
        'Later on, you can bind above binding source in your datagridview in following way:
        '            Me.DataGridViewBerechnung.DataSource = Me.bindingSourceBerechnung

        'Me.DataGrid1.DataSource = tableTemp

        currRowKola = CType(Me.DataGrid1.DataSource, DataTable).Rows(DataGrid1.CurrentCell.RowNumber)

        bPregledRecID = currRowKola(34, DataRowVersion.Current)

        'Dim ad2 As New SqlDataAdapter(" SELECT dbo.UgKP_Tip5.StavkaStanice, dbo.UgKP_Tip5.NacinObrade, dbo.UgKP_Tip5.OdStanice, dbo.UgKP_Tip5.DoStanice,  dbo.UgKP_Tip5.Status, dbo.UgKP_Tip5.TipUTI, dbo.UgKP_Tip5.BMasaUti1, dbo.UgKP_Tip5.BMasaUti2, dbo.UgKP_Tip5.VlasnistvoKola, dbo..UgKP_Tip5.KolaZemlja, dbo.UgKP_Tip5.Serija, dbo.UgKP_Tip5.BrojOsovina, dbo.UgKP_Tip5.OsPritisak, dbo.UgKP_Tip5.Pojedinacna, dbo.UgKP_Tip5.Grupa, dbo.UgKP_Tip5.Voz, dbo.UgKP_Tip5.TonskiStav, dbo.UgKP_Tip5.GranicnaMasa, dbo.UgKP_Tip5.SpecijalnaKola " _
        '                            & " FROM   dbo.Cena_UgovorKP INNER JOIN " _
        '                            & " dbo.UgKP_Tip5 ON dbo.Cena_UgovorKP.BrojUgovora = dbo.UgKP_Tip5.BrojUgovora AND dbo.Cena_UgovorKP.Aneks = dbo.UgKP_Tip5.Aneks " _
        '                            & " WHERE (dbo.UgKP_Tip5.BrojUgovora = '" & mUg & "')" & " AND (dbo.UgKP_Tip5.Aneks = '" & mUgAn & "')", OkpDbVeza)

        'Dim ad3 As New SqlDataAdapter(" SELECT dbo.UgKp_Nhm.StavkaNhm, dbo.UgKp_Nhm.NhmSifra, dbo.UgKp_Nhm.NhmGlava " _
        '                            & " FROM   dbo.Cena_UgovorKP INNER JOIN " _
        '                            & " dbo.UgKp_Nhm ON dbo.Cena_UgovorKP.BrojUgovora = dbo.UgKp_Nhm.BrojUgovora AND dbo.Cena_UgovorKP.Aneks = dbo.UgKp_Nhm.Aneks " _
        '                            & " WHERE (dbo.Cena_UgovorKP.BrojUgovora = '" & mUg & "')" & " AND (dbo.Cena_UgovorKP.Aneks = '" & mUgAn & "')", OkpDbVeza)

        'Dim ad4 As New SqlDataAdapter(" SELECT dbo.UgKp_Uprava.StavkaUprava, dbo.UgKp_Uprava.Uprava " _
        '                            & " FROM dbo.Cena_UgovorKP INNER JOIN " _
        '                            & " dbo.UgKp_Uprava ON dbo.Cena_UgovorKP.BrojUgovora = dbo.UgKp_Uprava.BrojUgovora AND dbo.Cena_UgovorKP.Aneks = dbo.UgKp_Uprava.Aneks " _
        '                            & " WHERE (dbo.UgKp_Uprava.BrojUgovora = '" & mUg & "')" & " AND (dbo.UgKp_Uprava.Aneks = '" & mUgAn & "')", OkpDbVeza)

        'Dim ad5 As New SqlDataAdapter(" SELECT  dbo.Ugovori.Saobracaj, dbo.Ugovori.SifraKorisnika " _
        '                            & " FROM dbo.Cena_UgovorKP INNER JOIN " _
        '                            & " dbo.Ugovori ON dbo.Cena_UgovorKP.BrojUgovora = dbo.Ugovori.BrojUgovora " _
        '                            & " WHERE (Cena_UgovorKP.BrojUgovora = '" & mUg & "')", OkpDbVeza)

        'Dim ad6 As New SqlDataAdapter(" SELECT dbo.UgKp_Naknada.StavkaNaknada, dbo.UgKp_Naknada.Naknada " _
        '                            & " FROM dbo.Cena_UgovorKP INNER JOIN " _
        '                            & " dbo.UgKp_Naknada ON dbo.Cena_UgovorKP.BrojUgovora = dbo.UgKp_Naknada.BrojUgovora AND dbo.Cena_UgovorKP.Aneks = dbo.UgKp_Naknada.Aneks " _
        '                            & " WHERE (dbo.UgKp_Naknada.BrojUgovora = '" & mUg & "')" & " AND (dbo.UgKp_Naknada.Aneks = '" & mUgAn & "')", OkpDbVeza)


        Dim ad2 As New SqlDataAdapter(" SELECT KolaStavka AS RBKola, IBK, Kontrola, Uprava, Vlasnik, Serija, Osovine, Tara, GranTov, Stitna, TipKola, Prevoznina, Naknada " _
                                    & " FROM   dbo.SlogKola " _
                                    & " WHERE (dbo.SlogKola.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad3 As New SqlDataAdapter(" SELECT KolaStavka AS RBKola, RobaStavka AS RBRobe, NHM, NHMRazred, SMasa, RMasa, RID, VozStav, PaleteR AS Poreklo, UtiTip, UtiRaster, UtiNaknada " _
                                    & " FROM   dbo.SlogRoba " _
                                    & " WHERE (dbo.SlogRoba.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad4 As New SqlDataAdapter(" SELECT NaknadeStavka AS RBNaknade, SifraNaknade, IvicniBroj, Iznos, Valuta, Kolicina, DanCas, Placanje, Vrsta " _
                                    & " FROM   dbo.SlogNaknada " _
                                    & " WHERE (dbo.SlogNaknada.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad5 As New SqlDataAdapter(" SELECT Stavka AS RBPrimedbe, SifraK211 AS SifraPrimedbe " _
                                    & " FROM   dbo.SlogK211 " _
                                    & " WHERE (dbo.SlogK211.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad6 As New SqlDataAdapter(" SELECT PDV1, PDV2  " _
                                    & " FROM   dbo.SlogKalkPDV " _
                                    & " WHERE (dbo.SlogKalkPDV.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        Dim ad7 As New SqlDataAdapter(" SELECT PodStanica1, PodStanica2 " _
                                    & " FROM   dbo.SlogKalkPS " _
                                    & " WHERE (dbo.SlogKalkPS.RecID = '" & bPregledRecID & "')", OkpDbVeza)

        ii2 = ad2.Fill(ds2)
        ii3 = ad3.Fill(ds3)
        ii4 = ad4.Fill(ds4)
        ii5 = ad5.Fill(ds5)
        ii6 = ad6.Fill(ds6)
        ii7 = ad7.Fill(ds7)

        Try
            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            DataGrid2.DataSource = ds2.Tables(0)
            DataGrid3.DataSource = ds3.Tables(0)
            DataGrid4.DataSource = ds4.Tables(0)
            DataGrid5.DataSource = ds5.Tables(0)
            DataGrid6.DataSource = ds6.Tables(0)
            DataGrid7.DataSource = ds7.Tables(0)

        Catch ex As Exception
            MessageBox.Show("Baza nije otvorena!", "Informacija o pristupu bazi", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'NhmAddList.Clear()
        'NhmRemoveList.Clear()
        'UpraveAddList.Clear()
        'UpraveRemoveList.Clear()
        'NaknadeAddList.Clear()
        'NaknadeRemoveList.Clear()
        'CeneAddList.Clear()
        'CeneRemoveList.Clear()
        Me.Close()
    End Sub

End Class
