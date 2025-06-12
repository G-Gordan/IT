Module InitVar
    'Friend mUserID As String
    'Friend mUpdate As String = "Ne"
    'Friend mAkcija As String
    'Friend SifraPrelaza As String = ""
    'Friend Upr1 As String = ""
    'Friend Upr2 As String = ""
    'Friend NazivPr As String = ""
    'Friend SifraUprave As String = ""
    'Friend SifraUprave2 As String = ""
    'Friend GrPrelaz As String = ""
    'Friend SifraStanice As String = ""
    'Friend SifraKoloseka As Int32 = 0
    'Friend IDKoloseka As Int32 = 0
    'Friend Firma As String = ""
    'Friend PodrVaz As String = "U"
    'Friend IndKol As Int32
    'Friend PodrVaz1 As String = "O"
    'Friend PomU As String = 0
    'Friend PomO As String = 0
    'Friend Izlaz1 As String
    'Friend Izlaz2 As String
    'Friend SifraRobe As String
    'Friend SifraGlave As String
    'Friend StavkaRobe As String   '? da li
    'Friend UNBroj As String
    'Friend TekstualniOpisRobe As String
    'Friend Pom As String
    'Friend upit As String
    'Friend UpOtpPodr As String = "U"

    'Friend WithEvents dgStan As System.Windows.Forms.DataGrid
    'Friend UputPodrAddList As ArrayList = New ArrayList
    'Friend UputPodrRemoveList As ArrayList = New ArrayList
    'Friend dtStan As DataTable = New DataTable("dtStan")
    'Friend StavSt As DataColumn = dtStan.Columns.Add("Stavka", Type.GetType("System.Int32"))
    'Friend Uprava As DataColumn = dtStan.Columns.Add("Uprava", Type.GetType("System.String"))
    'Friend Stanica As DataColumn = dtStan.Columns.Add("Stanica", Type.GetType("System.String"))
    'Friend Naziv As DataColumn = dtStan.Columns.Add("Naziv", Type.GetType("System.String"))
    'Friend IndKolosek As DataColumn = dtStan.Columns.Add("IndKolosek", Type.GetType("System.Int32"))
    ''Friend IdKol As DataColumn = dtStan.Columns.Add("IdKoloseka", Type.GetType("System.Int32"))
    ''Friend StrIndKol As DataColumn = dtStan.Columns.Add("StrIndKo", Type.GetType("System.String"))
    'Friend StrIndKol As DataColumn = dtStan.Columns.Add("StrIndKol", Type.GetType("System.String"))
    'Friend Fir As DataColumn = dtStan.Columns.Add("Firma", Type.GetType("System.String"))
    'Friend PodrVazU As DataColumn = dtStan.Columns.Add("PodrVaz", Type.GetType("System.String"))

    'Public WithEvents cmbUprava As System.Windows.Forms.ComboBox

   
   

    'Friend dtCena As DataTable = New DataTable("Cena")
    'Friend dcRB As DataColumn = dtCena.Columns.Add("StavkaStanice", Type.GetType("System.Int16"))
    Friend Uprava As String
    Friend BrTrOgrZS As String
    Friend BrTrOgrUprave As String
    Friend BrTel As String ' = "1"
    Friend TelDat As Date = Now.Date
    Friend TrOgrPostoji As String = "N"
    Friend SlogTrans As String
    Friend VaziOd As Date
    Friend VaziDo As Date
    Friend DoOpoziva As String = "N"
    Friend Razlog As String
    Friend UspPos As String
    Friend NazivFile As String
    Friend Datum
    Friend ToFile As String
    Friend broj As String
    Friend broj1 As String
    Friend makcija As String
    Friend mUpdate As String

    '2.12.2011
    ''Dim SentBytes, RecBytes As Int32
    ''Public FromFile As String = ClientPath
    ''Public ToFile As String = "z:"
    ''Public mFileSize1, mFileSize2 As Long
    '2.12.2011

    'Friend a As String
    Friend combo_linija1 As String = ""

    Private Sub InitializeComponent()
        'cmbUprava = New System.Windows.Forms.ComboBox
        'cmbUprava.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        'cmbUprava.Items.AddRange(New Object() {"00 - sve uprave", "10 - Finska", "20 - Rusija", "21 - Belorusija", "22 - Ukrajina", "23 - Moldavija", "24 - Litvanija", "25 - Letonija", "26 - Estonija", "27 - Kazahstan", "28 - Gruzija", "29 - Uzbekistan", "30 - S.Koreja", "31 - Mongolija", "32 - Vijetnam", "33 - Kina", "34 -" & Microsoft.VisualBasic.ChrW(9), "35 -", "36 -", "37 -", "39 -", "41 - Albanija", "42 - Japan", "43 - Madjarska", "44 - Republika Srpska", "45 -", "46 - ", "47 -", "48 -", "49 -", "50 - Bosna i Hercegovina", "51 - Poljska", "52 - Bugarska", "53 - Rumunija", "54 - Ceska", "55 - Madjarska", "56 - Slovacka", "57 - Azerbeidzan", "58 - Jermenija", "59 - Kirgistan", "60 - Irska", "61 - Koreja", "62 - Crna Gora", "63 -", "64 - Nord-Milano", "65 - Makedonija", "66 - Tadzikistan", "67 - Turkmenistan", "68 - Ahaus-Alster", "69 -", "70 - Velika Britanija", "71 - Spanija", "72 - Srbija", "73 - Grcka", "74 - Svedska", "75 - Turska", "76 - Norveska", "77 -", "78 - Hrvatska", "79 - Slovenija", "80 - Nemacka", "81 - Austrija", "82 - Luksemburg", "83 - Italija", "84 - Holandija", "85 - Svajcarska", "86 - Danska", "87 - Francuska", "88 - Belgija", "90 - Egipat", "91 - Tunis", "92 - Alzir", "93 - Maroko", "94 - Portugal", "95 - Izrael", "96 - Irak", "97 - Sirija", "98 - Liban", "99 - Iran"})
        'cmbUprava.Location = New System.Drawing.Point(120, 80)
        'cmbUprava.Name = "cmbUprava"
        'cmbUprava.Size = New System.Drawing.Size(176, 24)
        'cmbUprava.TabIndex = 51
    End Sub
End Module
