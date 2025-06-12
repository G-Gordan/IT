Imports System.Data.SqlClient
Public Class VPP

    Inherits System.Windows.Forms.Form
    Public Count As Int16 = 0
    'Dim NazivStanice1 As String
    'Dim NazivStanice2 As String
    Dim NazivStanice As String
    Dim Sk As String = ""
    Dim Psk As String = ""
    Dim RaskS1 As Integer = 0
    Dim RaskS2 As Integer = 0

    Dim PS1(5) As Integer            ' Deonice Stanice1
    Dim PS2(5) As Integer            ' Deonice Stanice2
    Dim PSTemp(5) As Integer         ' privr. promenjiva

    Dim PovrVrednost As String = ""
    Dim DaNeDugme As Int16 = 0       ' "yes"-6, "no"-7
    Dim bbSkm As Integer = 0
    Dim bbTkm As Integer = 0
    Dim Rask(29) As String           ' niz cvorova koji cine prevozni put
    'Dim PP As String = ""            ' niz cvorova koji cine prevozni put sklopljeni u jedan string
    Dim RaskTempSN(29) As String     ' privr. promenljiva ( sifra + ' ' + naziv )
    Dim NazivRaskTemp(29) As String  ' privr. promenljiva
    Dim PPCvor(29) As String         ' izabran prev. put ( sifre stanica )
    Dim PPCvorNaziv(29) As String    ' izabran prev. put ( nazivi stanica )
    Dim RB As Int16 = 0              ' redni broj trenutno fokusiranog cvora
    Dim bNazivStanice1, bNazivStanice2, bPP, bPP1, bPP2 As String
    Dim St1, St2 As String

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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnPrihvati As System.Windows.Forms.Button
    Friend WithEvents btnOtkazi As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSacuvaj As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VPP))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.btnOtkazi = New System.Windows.Forms.Button
        Me.btnPrihvati = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnSacuvaj = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Otpravna stanica"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Uputna stanica"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(112, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 16)
        Me.Label3.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(112, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(264, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Preko:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Location = New System.Drawing.Point(304, 8)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(192, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(8, 80)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(208, 316)
        Me.ListBox1.TabIndex = 9
        '
        'btnOtkazi
        '
        Me.btnOtkazi.BackColor = System.Drawing.SystemColors.Control
        Me.btnOtkazi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnOtkazi.Image = CType(resources.GetObject("btnOtkazi.Image"), System.Drawing.Image)
        Me.btnOtkazi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtkazi.Location = New System.Drawing.Point(640, 408)
        Me.btnOtkazi.Name = "btnOtkazi"
        Me.btnOtkazi.Size = New System.Drawing.Size(96, 65)
        Me.btnOtkazi.TabIndex = 10
        Me.btnOtkazi.Text = "Otkaži"
        Me.btnOtkazi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrihvati
        '
        Me.btnPrihvati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnPrihvati.Image = CType(resources.GetObject("btnPrihvati.Image"), System.Drawing.Image)
        Me.btnPrihvati.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrihvati.Location = New System.Drawing.Point(336, 408)
        Me.btnPrihvati.Name = "btnPrihvati"
        Me.btnPrihvati.Size = New System.Drawing.Size(88, 64)
        Me.btnPrihvati.TabIndex = 11
        Me.btnPrihvati.Text = "Prihvati  [ F12 ]"
        Me.btnPrihvati.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(504, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Da"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(664, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(552, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Tarifsko rastojanje"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(552, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Stvarno rastojanje"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(664, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 15
        '
        'btnSacuvaj
        '
        Me.btnSacuvaj.BackColor = System.Drawing.SystemColors.Control
        Me.btnSacuvaj.Enabled = False
        Me.btnSacuvaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnSacuvaj.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSacuvaj.Location = New System.Drawing.Point(488, 408)
        Me.btnSacuvaj.Name = "btnSacuvaj"
        Me.btnSacuvaj.Size = New System.Drawing.Size(96, 65)
        Me.btnSacuvaj.TabIndex = 16
        Me.btnSacuvaj.Text = "Sacuvaj prevozni put"
        Me.btnSacuvaj.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'VPP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(752, 486)
        Me.Controls.Add(Me.btnSacuvaj)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnPrihvati)
        Me.Controls.Add(Me.btnOtkazi)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "VPP"
        Me.Text = "Vanredni prevozni put"
        Me.ResumeLayout(False)

    End Sub

#End Region
    'Public Sub bNadjiVanredniPrevozniPut72L(ByVal inStanica1 As String, _
    '                                    ByVal inStanica2 As String, _
    '                                    ByRef outPP As String)

    '    ' - za otpravnu stanicu se izlistaju susedni cvorovi, ako uputna stanica nije na istoj pruzi
    '    ' - ako su otpravna i uputna stanica na istoj pruzi, postaviti pitanje za kraj prevoznog puta



    '    Dim KrajPuta As Boolean = False
    '    Dim St1, St2 As String
    '    Dim Sk As String = ""
    '    Dim Psk As String = ""
    '    Dim RaskS1 As Integer = 0
    '    Dim RaskS2 As Integer = 0
    '    Dim PS1(5) As Integer            ' Deonice
    '    Dim PS2(5) As Integer            ' Deonice

    '    While Not (KrajPuta)
    '        If KrajPuta Then Exit While
    '        ' naci parametre stanica ( trebaju nam njihove pruge-deonice)
    '        bNadjiStanicu72L(St1, bNazivStanice1, Sk, Psk, RaskS1, PS1(0), PS1(1), PS1(2), PS1(3), PS1(4), PS1(5), PovrVrednost)
    '        bNadjiStanicu72L(St2, bNazivStanice2, Sk, Psk, RaskS1, PS2(0), PS2(1), PS2(2), PS2(3), PS2(4), PS2(5), PovrVrednost)


    '        ' ako nije izabran kraj puta izlistati susedne cvorove;

    '        ' kada se izabere sledeci cvor, postaviti njega na prvu fokusiranu stanicu
    '        ' ponovo testirati sa uputnom stanicom ( da li je kraj puta )
    '        ' ako je moguc kraj puta, a nije izabran, izlistati susedne cvorove . . .itd

    '    End While


    'End Sub
    Public Sub bIzracunajVanredniPrevozniPut72L(ByVal inStan1 As String, _
                                                    ByVal inStan2 As String, _
                                                    ByVal inPP As String, _
                                                    ByRef outSkm As Integer, _
                                                    ByRef outTkm As Integer)
        ' - za otpravnu stanicu se izlistaju susedni cvorovi, ako uputna stanica nije na istoj pruzi
        ' - ako su otpravna i uputna stanica na istoj pruzi, postaviti pitanje za kraj prevoznog puta
        ' - Racunanje:
        '       pocetni deo - od otpravne stanice do prvog cvora,
        '       krajnji deo - od poslednjeg cvora do uputne stanice,
        '       srednji deo - suma celih deonica
        '       u zavisnosti od prevoznog puta, nisu svi delovi obavezni
        '
        Dim k As Int16
        Dim PocetniDeoSkm As Integer = 0
        Dim PocetniDeoTkm As Integer = 0
        Dim KrajnjiDeoSkm As Integer = 0
        Dim KrajnjiDeoTkm As Integer = 0
        Dim SrDeoSkm As Integer = 0
        Dim SrDeoTkm As Integer = 0
        Dim SrednjiDeoSkm(29) As Integer
        For k = 0 To 29
            SrednjiDeoSkm(k) = 0
        Next
        Dim SrednjiDeoTkm(29) As Integer
        For k = 0 To 29
            SrednjiDeoTkm(k) = 0
        Next
        Dim OsOptx10(29) As Integer
        For k = 0 To 29
            OsOptx10(k) = 0
        Next

        Dim PSI(5) As Integer            ' Deonice prvog cvora
        Dim PSII(5) As Integer           ' Deonice poslednjeg cvora
        For k = 0 To 5
            PS1(k) = 0
            PS2(k) = 0
            PSI(k) = 0
            PSII(k) = 0
        Next        

        For k = 0 To 29
            Rask(k) = ""
        Next

        Dim DuzinaPP As Int16 = 0

        outTkm = 0
        outSkm = 0

        DuzinaPP = Microsoft.VisualBasic.Len(inPP) / 5      ' broj raskrsca - cvornih stanicana na PP

        For k = 0 To DuzinaPP - 1
            Rask(k) = Microsoft.VisualBasic.Mid(inPP, (k + 1) * 5 - 4, 5)
        Next

        ' otpravna stanica:
        bNadjiStanicu72L(mStanica1, bNazivStanice1, Sk, Psk, RaskS1, PS1(0), PS1(1), PS1(2), PS1(3), PS1(4), PS1(5), PovrVrednost)

        If DuzinaPP > 0 Then
            ' prvi cvor:
            bNadjiStanicu72L(Rask(0), NazivStanice, Sk, Psk, RaskS1, PSI(0), PSI(1), PSI(2), PSI(3), PSI(4), PSI(5), PovrVrednost)

            ' poslednji cvor:
            bNadjiStanicu72L(Rask(DuzinaPP - 1), NazivStanice, Sk, Psk, RaskS2, PSII(0), PSII(1), PSII(2), PSII(3), PSII(4), PSII(5), PovrVrednost)
        End If


        ' uputna stanica:
        bNadjiStanicu72L(mStanica2, bNazivStanice2, Sk, Psk, RaskS2, PS2(0), PS2(1), PS2(2), PS2(3), PS2(4), PS2(5), PovrVrednost)


        Dim a, b As Int16
        Dim P As Integer    ' zajednicka pruga (deonica) za stanice
        Dim S2 As String

        ' Pocetni deo - postoji uvek

        If DuzinaPP < 1 Then
            For a = 0 To 5
                For b = 0 To 5
                    If (PS1(a) = PS2(b)) And (PS1(a) <> 0) Then
                        P = PS1(a)
                        S2 = inStan2
                    End If
                Next
            Next
        Else
            For a = 0 To 5
                For b = 0 To 5
                    If (PS1(a) = PSI(b)) And (PS1(a) <> 0) Then
                        P = PS1(a)
                        S2 = Rask(0)
                    End If
                Next
            Next
        End If

        bNadjiRastojanjeNaDeonici72L(P, inStan1, S2, PocetniDeoSkm, PocetniDeoTkm, PovrVrednost)

        ' Srednji deo - postoji ako je DuzinaPP > 1
        If DuzinaPP > 1 Then
            For k = 0 To DuzinaPP - 2
                bNadjiCeluDeonicuPoStanicama72L(Rask(k), Rask(k + 1), SrednjiDeoSkm(k), SrednjiDeoTkm(k), OsOptx10(k), PovrVrednost)
                SrDeoSkm = SrDeoSkm + SrednjiDeoSkm(k)
                SrDeoTkm = SrDeoTkm + SrednjiDeoTkm(k)
            Next
        End If


        ' Krajnji deo - postoji ako je DuzinaPP > 0
        If DuzinaPP > 0 Then
            For a = 0 To 5
                For b = 0 To 5
                    If PS2(a) = PSII(b) And (PS2(a) <> 0) Then
                        P = PS2(a)
                    End If
                Next
            Next
            bNadjiRastojanjeNaDeonici72L(P, Rask(DuzinaPP - 1), inStan2, KrajnjiDeoSkm, KrajnjiDeoTkm, PovrVrednost)
        End If

        outSkm = PocetniDeoSkm + SrDeoSkm + KrajnjiDeoSkm
        outTkm = PocetniDeoTkm + SrDeoTkm + KrajnjiDeoTkm

    End Sub
    Public Sub bNadjiStanicu72L(ByVal inSifraStanice As String, _
                                ByRef outNazivStanice As String, _
                                ByRef outSkupina As String, _
                                ByRef outPodskupina As String, _
                                ByRef outSifraRaskrsca As Integer, _
                                ByRef outP1 As Integer, _
                                ByRef outP2 As Integer, _
                                ByRef outP3 As Integer, _
                                ByRef outP4 As Integer, _
                                ByRef outP5 As Integer, _
                                ByRef outP6 As Integer, _
                                ByRef outRetVal As String)

        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.bspNadjiStanicu72L", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulSifraStanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraStanice", SqlDbType.Char, 5))
        ulSifraStanice.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraStanice").Value = inSifraStanice

        Dim izNazivStanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNazivStanice", SqlDbType.Char, 20))
        izNazivStanice.Direction = ParameterDirection.Output

        Dim izSkupina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSkupina", SqlDbType.Char, 1))
        izSkupina.Direction = ParameterDirection.Output

        Dim izPodskupina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPodskupina", SqlDbType.Char, 2))
        izPodskupina.Direction = ParameterDirection.Output

        Dim izSifraRaskrsca As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraRaskrsca", SqlDbType.Int))
        izSifraRaskrsca.Direction = ParameterDirection.Output

        Dim izP1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outP1", SqlDbType.Int))
        izP1.Direction = ParameterDirection.Output

        Dim izP2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outP2", SqlDbType.Int))
        izP2.Direction = ParameterDirection.Output

        Dim izP3 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outP3", SqlDbType.Int))
        izP3.Direction = ParameterDirection.Output

        Dim izP4 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outP4", SqlDbType.Int))
        izP4.Direction = ParameterDirection.Output

        Dim izP5 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outP5", SqlDbType.Int))
        izP5.Direction = ParameterDirection.Output

        Dim izP6 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outP6", SqlDbType.Int))
        izP6.Direction = ParameterDirection.Output

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()
            outNazivStanice = spKomanda.Parameters("@outNazivStanice").Value
            outSkupina = spKomanda.Parameters("@outSkupina").Value
            outPodskupina = spKomanda.Parameters("@outPodskupina").Value
            outSifraRaskrsca = spKomanda.Parameters("@outSifraRaskrsca").Value
            outP1 = spKomanda.Parameters("@outP1").Value
            outP2 = spKomanda.Parameters("@outP2").Value
            outP3 = spKomanda.Parameters("@outP3").Value
            outP4 = spKomanda.Parameters("@outP4").Value
            outP5 = spKomanda.Parameters("@outP5").Value
            outP6 = spKomanda.Parameters("@outP6").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            If outRetVal = "                                                  " Then
                outRetVal = ""
            End If            
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Public Sub bNadjiCeluDeonicuPoSifri72L(ByVal inSifraDeonice As Integer, _
                                           ByRef outskm As Integer, _
                                           ByRef outtkm As Integer, _
                                           ByRef outOsOptx10 As Integer, _
                                           ByRef outRetVal As String)

        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.bspNadjiDeonicuPoSifri72L", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulSifraDeonice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraDeonice", SqlDbType.Int))
        ulSifraDeonice.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraDeonice").Value = inSifraDeonice

        Dim izskm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outskm", SqlDbType.Int))
        izskm.Direction = ParameterDirection.Output

        Dim iztkm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outtkm", SqlDbType.Int))
        iztkm.Direction = ParameterDirection.Output

        Dim izOsOptx10 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOsOptx10", SqlDbType.Int))
        izOsOptx10.Direction = ParameterDirection.Output

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()

            outskm = spKomanda.Parameters("@outskm").Value
            outtkm = spKomanda.Parameters("@outtkm").Value
            outOsOptx10 = spKomanda.Parameters("@outOsOptx10").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            If outRetVal = "                                                  " Then
                outRetVal = ""
            End If
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub bNadjiCeluDeonicuPoStanicama72L(ByVal inStanica1 As String, _
                                               ByVal inStanica2 As String, _
                                               ByRef outskm As Integer, _
                                               ByRef outtkm As Integer, _
                                               ByRef outOsOptx10 As Integer, _
                                               ByRef outRetVal As String)

        outRetVal = ""

        Dim STemp As String
        Dim S1Int, S2Int As Integer

        S1Int = CType(inStanica1, Integer)
        S2Int = CType(inStanica2, Integer)

        If S1Int > S2Int Then
            STemp = inStanica1
            inStanica1 = inStanica2
            inStanica2 = STemp
        End If

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.bspNadjiDeonicuPoStanicama72L", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica1", SqlDbType.Char, 5))
        ulStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica1").Value = inStanica1

        Dim ulStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica2", SqlDbType.Char, 5))
        ulStanica2.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica2").Value = inStanica2

        Dim izskm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outskm", SqlDbType.Int))
        izskm.Direction = ParameterDirection.Output

        Dim iztkm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outtkm", SqlDbType.Int))
        iztkm.Direction = ParameterDirection.Output

        Dim izOsOptx10 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOsOptx10", SqlDbType.Int))
        izOsOptx10.Direction = ParameterDirection.Output

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()
            outskm = spKomanda.Parameters("@outskm").Value
            outtkm = spKomanda.Parameters("@outtkm").Value
            outOsOptx10 = spKomanda.Parameters("@outOsOptx10").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            If outRetVal = "                                                  " Then
                outRetVal = ""
            End If
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub bNadjiRastojanjeNaDeonici72L(ByVal inSifraDeonice As String, _
                                           ByVal inStanica1 As String, _
                                           ByVal inStanica2 As String, _
                                           ByRef outskm As Integer, _
                                           ByRef outtkm As Integer, _
                                           ByRef outRetVal As String)

        outRetVal = ""


        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.bspNadjiRastojanjeNaDeonici72L", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulSifraDeonice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraDeonice", SqlDbType.Int))
        ulSifraDeonice.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraDeonice").Value = inSifraDeonice

        Dim ulStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica1", SqlDbType.Char, 5))
        ulStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica1").Value = inStanica1

        Dim ulStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica2", SqlDbType.Char, 5))
        ulStanica1.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica2").Value = inStanica2

        Dim izskm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outskm", SqlDbType.Int))
        izskm.Direction = ParameterDirection.Output

        Dim iztkm As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outtkm", SqlDbType.Int))
        iztkm.Direction = ParameterDirection.Output

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()
            outskm = spKomanda.Parameters("@outskm").Value
            outtkm = spKomanda.Parameters("@outtkm").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            If outRetVal = "                                                  " Then
                outRetVal = ""
            End If
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub bNadjiSusedneCvorove72L(ByVal inStanica As Integer, _
                                           ByRef outSusedniCvorovi As String, _
                                           ByRef outRetVal As String)

        outRetVal = ""

        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("radnik.bspNadjiSusedneCvorove72L", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulStanica As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5))
        ulStanica.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStanica").Value = inStanica

        Dim izSusedniCvorovi As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSusedniCvorovi", SqlDbType.VarChar, 156))
        izSusedniCvorovi.Direction = ParameterDirection.Output

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
        izlRetVal.Direction = ParameterDirection.Output

        Try
            spKomanda.ExecuteScalar()

            outSusedniCvorovi = spKomanda.Parameters("@outSusedniCvorovi").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            If outRetVal = "                                                  " Then
                outRetVal = ""
            End If
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Private Sub VPP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim SusedniCvoroviStr As String = ""
        Dim CvorSN(5) As String        ' cvor - (sifra+naziv)

        Dim k As Int16 = 0
        For k = 0 To 29
            Rask(k) = ""
            RaskTempSN(k) = ""
            NazivRaskTemp(k) = ""
            PPCvor(k) = ""
            PPCvorNaziv(k) = ""
        Next

        Me.Label6.Visible = False
        Me.Label7.Visible = False
        Me.Label8.Visible = False
        Me.Label9.Visible = False


        'Dim St1, St2 As String
        If mManipulativnoMesto1 = "" Then
            St1 = mStanica1
        Else
            St1 = Microsoft.VisualBasic.Left(mManipulativnoMesto1, 5)
        End If
        If mManipulativnoMesto2 = "" Then
            St2 = mStanica2
        Else
            St2 = Microsoft.VisualBasic.Left(mManipulativnoMesto2, 5)
        End If

        ' postaviti otpravnu i uputnu stanicu na fokusirane stanice:
        'bNadjiStanicu72L(mStanica1, bNazivStanice1, Sk, Psk, RaskS1, PS1(0), PS1(1), PS1(2), PS1(3), PS1(4), PS1(5), PovrVrednost)
        'bNadjiStanicu72L(mStanica2, bNazivStanice2, Sk, Psk, RaskS2, PS2(0), PS2(1), PS2(2), PS2(3), PS2(4), PS2(5), PovrVrednost)

        'Me.Label3.Text = mStanica1.ToString + " " + bNazivStanice1.ToString
        'Me.Label4.Text = mStanica2.ToString + " " + bNazivStanice2.ToString

        bNadjiStanicu72L(St1, bNazivStanice1, Sk, Psk, RaskS1, PS1(0), PS1(1), PS1(2), PS1(3), PS1(4), PS1(5), PovrVrednost)
        bNadjiStanicu72L(St2, bNazivStanice2, Sk, Psk, RaskS2, PS2(0), PS2(1), PS2(2), PS2(3), PS2(4), PS2(5), PovrVrednost)

        Me.Label3.Text = St1.ToString + " " + bNazivStanice1.ToString
        Me.Label4.Text = St2.ToString + " " + bNazivStanice2.ToString


        ' naci cvorove koji su susedni PRVOJ stanici
        'bNadjiSusedneCvorove72L(mStanica1, SusedniCvoroviStr, PovrVrednost)
        bNadjiSusedneCvorove72L(St1, SusedniCvoroviStr, PovrVrednost)

        Dim UkupnoSusednihCvorova As String = Microsoft.VisualBasic.Len(SusedniCvoroviStr) / 26      ' broj raskrsca - cvornih stanicana na PP     

        For k = 0 To UkupnoSusednihCvorova - 1
            CvorSN(k) = Microsoft.VisualBasic.Mid(SusedniCvoroviStr, (k + 1) * 26 - 25, 26)
            Me.ComboBox1.Items.Add(CvorSN(k))
        Next


    End Sub

    Public Sub bPrikaziPP()

        Dim k As Int16
        Dim DuzinaPP As Int16 = 0
        Dim mObjekat As Object


        DuzinaPP = Microsoft.VisualBasic.Len(bPP) / 5      ' broj raskrsca - cvornih stanicana na PP
        Me.ListBox1.Items.Clear()
        For k = 0 To DuzinaPP - 1
            mObjekat = PPCvor(k) & "  " & PPCvorNaziv(k)
            Me.ListBox1.Items.Add(mObjekat)

        Next

    End Sub

    Private Sub VPP_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Dim a, b As Int16
        Dim P As Integer    ' zajednicka pruga (deonica) za stanice
        Dim S2 As String


        If Count = 0 Then
            For a = 0 To 5
                For b = 0 To 5
                    If (PS1(a) = PS2(b)) And (PS1(a) <> 0) Then
                        DaNeDugme = MsgBox("Kraj prevoznog puta u stanici " + mStanica2 + " " + RTrim(bNazivStanice2) + "?", MsgBoxStyle.YesNo)
                        Exit For
                    End If
                Next
            Next

            If DaNeDugme = 6 Then   'kraj prevoznog puta
                bPP = ""
                bIzracunajVanredniPrevozniPut72L(mStanica1, mStanica2, bPP, bbSkm, bbTkm)
                Count = Count + 1
                Me.Label6.Visible = True
                Me.Label7.Visible = True
                Me.Label8.Visible = True
                Me.Label9.Visible = True

                Me.Label7.Text = bbSkm.ToString + " km"
                Me.Label6.Text = bbTkm.ToString + " km"

                Me.btnSacuvaj.Enabled = True
                Me.btnSacuvaj.Focus()
            Else


                ' bIzlistajVPP(mStanica1, mStanica2, PovrVrednost)
            End If
            Count = Count + 1
        End If

    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        Me.ComboBox1.SelectedIndex = 0
        Me.ComboBox1.DroppedDown = True
    End Sub

    Private Sub ComboBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
    End Sub

    Private Sub btnOtkazi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOtkazi.Click
        Close()
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar() = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            SendKeys.Send(Chr(9))
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' naci cvorove koji su susedni prvoj stanici
        Dim mStan As String
        Dim SusedniCvoroviStr As String

        'bPP = ""

        mStan = Microsoft.VisualBasic.Left(ComboBox1.Text, 5)   ' izabrana stanica

        PPCvor(RB) = mStan
        bNadjiStanicu72L(mStan, NazivStanice, Sk, Psk, RaskS1, PSTemp(0), PSTemp(1), PSTemp(2), PSTemp(3), PSTemp(4), PSTemp(5), PovrVrednost)
        PPCvorNaziv(RB) = NazivStanice
        bPP = bPP + mStan
        bPrikaziPP()

        RB = RB + 1
        bNadjiSusedneCvorove72L(mStan, SusedniCvoroviStr, PovrVrednost)

        Dim UkupnoSusednihCvorova As String = Microsoft.VisualBasic.Len(SusedniCvoroviStr) / 26     ' broj raskrsca - cvornih stanicana na PP

        ' proveriti da li je kraj puta
        Dim a, b As Int16
        For a = 0 To 5
            For b = 0 To 5
                If (PSTemp(a) = PS2(b) And (PSTemp(a) <> 0)) Then
                    DaNeDugme = MsgBox("Kraj prevoznog puta u stanici " + mStanica2 + " " + RTrim(bNazivStanice2) + "?", MsgBoxStyle.YesNo)
                    Exit For
                End If
            Next
        Next

        If DaNeDugme = 6 Then   'kraj prevoznog puta

            Count = Count + 1
            bIzracunajVanredniPrevozniPut72L(mStanica1, mStanica2, bPP, bbSkm, bbTkm)
            Count = Count + 1

            Me.Label6.Visible = True
            Me.Label7.Visible = True
            Me.Label8.Visible = True
            Me.Label9.Visible = True

            Me.Label7.Text = bbSkm.ToString + " km"
            Me.Label6.Text = bbTkm.ToString + " km"

            Me.btnSacuvaj.Enabled = True
            Me.btnSacuvaj.Focus()
        Else
            Me.ComboBox1.Focus()
            Dim k As Int16
            Me.ComboBox1.Items.Clear()
            For k = 0 To UkupnoSusednihCvorova - 1
                RaskTempSN(k) = Microsoft.VisualBasic.Mid(SusedniCvoroviStr, (k + 1) * 26 - 25, 26)
                Me.ComboBox1.Items.Add(RaskTempSN(k))
            Next

        End If

    End Sub

    Private Sub btnPrihvati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrihvati.Click
        bSkm = bbSkm
        bTkm = bbTkm
        'PP = PP
        _OpenForm = "VPP"
        Me.Close()
    End Sub
    Friend Sub bSacuvajVPP(ByVal inTrans As SqlTransaction, ByVal inStanica1 As String, ByVal inStanica2 As String, _
                                 ByVal inOpisVPP As String, ByVal inSkm As Integer, ByVal inTkm As Integer, _
                                ByRef outRetVal As String)

        outRetVal = ""


        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim bspVPP As New SqlClient.SqlCommand("radnik.bspInsertVPP", DbVeza)
        bspVPP.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50, ParameterDirection.Output, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim ulStanica1 As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inStanica1", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica1", DataRowVersion.Current, inStanica1))
        Dim ulStanica2 As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inStanica2", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica2", DataRowVersion.Current, inStanica2))
        Dim ulOpisVPP As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inOpisVPP", SqlDbType.Char, 150, ParameterDirection.Input, False, 0, 0, "OpisVPP", DataRowVersion.Current, inOpisVPP))
        Dim ulSkm As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inSkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Skm", DataRowVersion.Current, inSkm))
        Dim ulTkm As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inTkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Tkm", DataRowVersion.Current, inTkm))
        bspVPP.Transaction = inTrans

        Try
            bspVPP.ExecuteNonQuery()

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            outRetVal = Err.Description     'Greska - bilo koja
        Finally
            bspVPP.Dispose()
            DbVeza.Close()
        End Try
    End Sub
    Friend Sub bSacuvajVPP2(ByVal inTrans As SqlTransaction, ByVal inVrstaVPP As Integer, ByVal inSifraVPP As Integer, ByVal inStanica1 As String, ByVal inStanica2 As String, _
                                ByVal inOpisVPP As String, ByVal inSkm As Integer, ByVal inTkm As Integer, _
                               ByRef outRetVal As String)

        outRetVal = ""


        If inVrstaVPP = 1 Then
            inSifraVPP = 1000
        ElseIf inVrstaVPP = 2 Then

        ElseIf inVrstaVPP = 3 Then

        ElseIf inVrstaVPP = 4 Then

        End If




        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim bspVPP As New SqlClient.SqlCommand("roba1708.bspInsertVPP2", DbVeza)
        bspVPP.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50, ParameterDirection.Output, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim ulSifraVPP As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inSifraVPP", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Skm", DataRowVersion.Current, inSifraVPP))
        Dim ulStanica1 As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inStanica1", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica1", DataRowVersion.Current, inStanica1))
        Dim ulStanica2 As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inStanica2", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica2", DataRowVersion.Current, inStanica2))
        Dim ulOpisVPP As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inOpisVPP", SqlDbType.Char, 150, ParameterDirection.Input, False, 0, 0, "OpisVPP", DataRowVersion.Current, inOpisVPP))
        Dim ulSkm As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inSkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Skm", DataRowVersion.Current, inSkm))
        Dim ulTkm As SqlClient.SqlParameter = bspVPP.Parameters.Add(New SqlClient.SqlParameter("@inTkm", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "Tkm", DataRowVersion.Current, inTkm))
        bspVPP.Transaction = inTrans

        Try
            bspVPP.ExecuteNonQuery()

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            outRetVal = Err.Description     'Greska - bilo koja
        Finally
            bspVPP.Dispose()
            DbVeza.Close()
        End Try
    End Sub

    Private Sub btnSacuvaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacuvaj.Click
        Dim slogTrans As SqlTransaction

        If mManipulativnoMesto1 = "" Then
            St1 = mStanica1
        Else
            St1 = Microsoft.VisualBasic.Left(mManipulativnoMesto1, 5)
        End If
        If mManipulativnoMesto2 = "" Then
            St2 = mStanica2
        Else
            St2 = Microsoft.VisualBasic.Left(mManipulativnoMesto2, 5)
        End If


        bSacuvajVPP(slogTrans, St1, St2, bPP, bbSkm, bbTkm, PovrVrednost)
        Me.btnPrihvati.Focus()

    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        If ComboBox1.SelectedItem = Nothing Then
            Me.ComboBox1.DroppedDown = True
            ComboBox1.Focus()
        End If
    End Sub

    'Public Sub bIzlistajVPP(ByVal inStanica1 As Integer, ByVal inStanica2 As String, ByRef outRetVal As String)

    '    outRetVal = ""

    '    If DbVeza.State = ConnectionState.Closed Then
    '        DbVeza.Open()
    '    End If

    '    Dim spKomanda As New SqlClient.SqlCommand("radnik.bspIzlistajVPPuteve", DbVeza)
    '    spKomanda.CommandType = CommandType.StoredProcedure

    '    Dim ulStanica1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica1", SqlDbType.Char, 5))
    '    ulStanica1.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inStanica1").Value = inStanica1

    '    Dim ulStanica2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStanica2", SqlDbType.Char, 5))
    '    ulStanica2.Direction = ParameterDirection.Input
    '    spKomanda.Parameters("@inStanica2").Value = inStanica2


    '    Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 50))
    '    izlRetVal.Direction = ParameterDirection.Output

    '    Try
    '        spKomanda.ExecuteScalar()

    '        'outSusedniCvorovi = spKomanda.Parameters("@outSusedniCvorovi").Value
    '        outRetVal = spKomanda.Parameters("@outRetVal").Value

    '    Catch SQLExp As SqlException
    '        outRetVal = SQLExp.Message & " SQL greska u programu!"
    '    Catch Exp As Exception
    '        outRetVal = Err.Description & " Greska u programu!"
    '    Finally
    '        If outRetVal = "                                                  " Then
    '            outRetVal = ""
    '        End If
    '        DbVeza.Close()
    '        spKomanda.Dispose()
    '    End Try

    'End Sub

End Class


