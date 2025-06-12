Module InitVar
    Friend PPov As Decimal = 0.0
    Friend PSmanj As Decimal
    Friend PStim As Decimal
    Friend GPov As Decimal
    Friend GSmanj As Decimal
    Friend GStim As Decimal
    Friend VPov As Decimal
    Friend VSmanj As Decimal
    Friend VStim As Decimal

    Friend WithEvents dgKorIzv As System.Windows.Forms.DataGrid
    Friend KorIzvAddList As ArrayList = New ArrayList
    Friend KorIzvRemoveList As ArrayList = New ArrayList
    Friend dtKorIzv As DataTable = New DataTable("KorIzv")
    Friend Pojj As DataColumn = dtKorIzv.Columns.Add("Pojedinacno", Type.GetType("System.Decimal"))
    Friend Grr As DataColumn = dtKorIzv.Columns.Add("Grupa", Type.GetType("System.Decimal"))
    Friend Vozz As DataColumn = dtKorIzv.Columns.Add("Voz", Type.GetType("System.Decimal"))
    'Friend GPovI As DataColumn = dtKorIzv.Columns.Add("GPov", Type.GetType("System.Decimal"))
    'Friend GSmanjI As DataColumn = dtKorIzv.Columns.Add("GSmanj", Type.GetType("System.Decimal"))
    'Friend GStimI As DataColumn = dtKorIzv.Columns.Add("GStim", Type.GetType("System.Decimal"))
    'Friend VPovI As DataColumn = dtKorIzv.Columns.Add("VPov", Type.GetType("System.Decimal"))
    'Friend VSmanjI As DataColumn = dtKorIzv.Columns.Add("VSmanj", Type.GetType("System.Decimal"))
    'Friend VStimI As DataColumn = dtKorIzv.Columns.Add("VStim", Type.GetType("System.Decimal"))
    'Friend Ukupno As DataColumn = dtDataGrid3.Columns.Add("Ukupno", Type.GetType("System.Decimal"))
    'Friend BrKor As DataColumn = dtKorekc.Columns.Add("BrKor", Type.GetType("System.String"))

    'Friend WithEvents dgDataGrid4 As System.Windows.Forms.DataGrid
    'Friend Korekc2AddList As ArrayList = New ArrayList
    'Friend Korekc2RemoveList As ArrayList = New ArrayList
    'Friend dtDataGrid4 As DataTable = New DataTable("DataGrid4")
    ''Friend Ugovor As DataColumn = dtDataGrid3.Columns.Add("Ugovor", Type.GetType("System.String"))
    'Friend PPov1 As DataColumn = dtDataGrid3.Columns.Add("PPov", Type.GetType("System.Decimal"))
    'Friend PSmanj1 As DataColumn = dtDataGrid3.Columns.Add("PSmanj", Type.GetType("System.Decimal"))
    'Friend PStim1 As DataColumn = dtDataGrid3.Columns.Add("PStim", Type.GetType("System.Decimal"))
    'Friend GPov1 As DataColumn = dtDataGrid3.Columns.Add("GPov", Type.GetType("System.Decimal"))
    'Friend GSmanj1 As DataColumn = dtDataGrid3.Columns.Add("GSmanj", Type.GetType("System.Decimal"))
    'Friend GStim1 As DataColumn = dtDataGrid3.Columns.Add("GStim", Type.GetType("System.Decimal"))
    'Friend VPov1 As DataColumn = dtDataGrid3.Columns.Add("VPov", Type.GetType("System.Decimal"))
    'Friend VSmanj1 As DataColumn = dtDataGrid3.Columns.Add("VSmanj", Type.GetType("System.Decimal"))
    'Friend VStim1 As DataColumn = dtDataGrid3.Columns.Add("VStim", Type.GetType("System.Decimal"))
    ''Friend Ukupno As DataColumn = dtDataGrid3.Columns.Add("Ukupno", Type.GetType("System.Decimal"))
    ''Friend BrKor As DataColumn = dtKorekc.Columns.Add("BrKor", Type.GetType("System.String"))

    'Friend WithEvents dgDataGrid5 As System.Windows.Forms.DataGrid
    'Friend Korekc3AddList As ArrayList = New ArrayList
    'Friend Korekc3RemoveList As ArrayList = New ArrayList
    'Friend dtDataGrid5 As DataTable = New DataTable("DataGrid5")
    ''Friend Ugovor As DataColumn = dtDataGrid3.Columns.Add("Ugovor", Type.GetType("System.String"))
    'Friend PPov2 As DataColumn = dtDataGrid3.Columns.Add("PPov", Type.GetType("System.Decimal"))
    'Friend PSmanj2 As DataColumn = dtDataGrid3.Columns.Add("PSmanj", Type.GetType("System.Decimal"))
    'Friend PStim2 As DataColumn = dtDataGrid3.Columns.Add("PStim", Type.GetType("System.Decimal"))
    'Friend GPov2 As DataColumn = dtDataGrid3.Columns.Add("GPov", Type.GetType("System.Decimal"))
    'Friend GSmanj2 As DataColumn = dtDataGrid3.Columns.Add("GSmanj", Type.GetType("System.Decimal"))
    'Friend GStim2 As DataColumn = dtDataGrid3.Columns.Add("GStim", Type.GetType("System.Decimal"))
    'Friend VPov2 As DataColumn = dtDataGrid3.Columns.Add("VPov", Type.GetType("System.Decimal"))
    'Friend VSmanj2 As DataColumn = dtDataGrid3.Columns.Add("VSmanj", Type.GetType("System.Decimal"))
    'Friend VStim2 As DataColumn = dtDataGrid3.Columns.Add("VStim", Type.GetType("System.Decimal"))
    ''Friend Ukupno As DataColumn = dtDataGrid3.Columns.Add("Ukupno", Type.GetType("System.Decimal"))
    ''Friend BrKor As DataColumn = dtKorekc.Columns.Add("BrKor", Type.GetType("System.String"))

    Friend Sifra As Int16

    Friend Saobracaj As String
    Friend Mesec As String
    Friend Godina As String
    Friend Posiljka As String
    Friend Poj As Decimal
    Friend Gr As Decimal
    Friend Voz As Decimal

End Module
