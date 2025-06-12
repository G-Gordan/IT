Module InitVar
    Friend mUserID As String
    Friend PrBroj As String
    Friend PrStan As String
    Friend PrUpr As String
    Friend a As String
    Friend RecID As Integer
    Friend Korisnik As String
    Friend User As String
    Friend Stanica As String

    Friend PregledAddList As ArrayList = New ArrayList
    Friend PregledRemoveList As ArrayList = New ArrayList
    Friend dtPregled As DataTable = New DataTable("Pregled")
    Friend dcKor As DataColumn = dtPregled.Columns.Add("Korisnik", Type.GetType("System.String"))
    Friend dcRB As DataColumn = dtPregled.Columns.Add("RedBr", Type.GetType("System.Int16"))
    Friend dcStan As DataColumn = dtPregled.Columns.Add("Stanica", Type.GetType("System.String"))
    Friend dcPrBr As DataColumn = dtPregled.Columns.Add("PrBroj", Type.GetType("System.String"))
    Friend dcBrPr As DataColumn = dtPregled.Columns.Add("BrPed", Type.GetType("System.String"))
    Friend dcV As DataColumn = dtPregled.Columns.Add("Visak", Type.GetType("System.Decimal"))
    Friend dcVN As DataColumn = dtPregled.Columns.Add("VisakN", Type.GetType("System.Decimal"))
    Friend dcRV As DataColumn = dtPregled.Columns.Add("RazlVisak", Type.GetType("System.Decimal"))
    Friend dcM As DataColumn = dtPregled.Columns.Add("Manjak", Type.GetType("System.Decimal"))
    Friend dcRM As DataColumn = dtPregled.Columns.Add("RazlManj", Type.GetType("System.Decimal"))
    Friend dcPZ As DataColumn = dtPregled.Columns.Add("PZO", Type.GetType("System.Decimal"))
    Friend dcPC As DataColumn = dtPregled.Columns.Add("CP", Type.GetType("System.Decimal"))
    Friend dcNak As DataColumn = dtPregled.Columns.Add("Naknade", Type.GetType("System.Decimal"))
    Friend dcTG As DataColumn = dtPregled.Columns.Add("TruGot", Type.GetType("System.Decimal"))
    Friend dcPr As DataColumn = dtPregled.Columns.Add("Pred", Type.GetType("System.Decimal"))
    Friend dcU As DataColumn = dtPregled.Columns.Add("Uk", Type.GetType("System.Decimal"))
   

End Module
