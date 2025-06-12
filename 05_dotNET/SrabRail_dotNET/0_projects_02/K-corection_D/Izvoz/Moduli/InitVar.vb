Module InitVar
    Public mUserID As String
    Public PrBroj As String
    Public PrStan As String
    Public PrUpr As String
    Public a As String
    Public RecID As Integer
    Public Korisnik As String
    Public User As String
    Public Stanica As String

    Public PregledAddList As ArrayList = New ArrayList
    Public PregledRemoveList As ArrayList = New ArrayList
    Public dtPregled As DataTable = New DataTable("Pregled")
    Public dcKor As DataColumn = dtPregled.Columns.Add("Korisnik", Type.GetType("System.String"))
    Public dcRB As DataColumn = dtPregled.Columns.Add("RedBr", Type.GetType("System.Int16"))
    Public dcStan As DataColumn = dtPregled.Columns.Add("Stanica", Type.GetType("System.String"))
    Public dcPrBr As DataColumn = dtPregled.Columns.Add("PrBroj", Type.GetType("System.String"))
    Public dcBrPr As DataColumn = dtPregled.Columns.Add("BrPed", Type.GetType("System.String"))
    Public dcV As DataColumn = dtPregled.Columns.Add("Visak", Type.GetType("System.Decimal"))
    Public dcVN As DataColumn = dtPregled.Columns.Add("VisakN", Type.GetType("System.Decimal"))
    Public dcRV As DataColumn = dtPregled.Columns.Add("RazlVisak", Type.GetType("System.Decimal"))
    Public dcM As DataColumn = dtPregled.Columns.Add("Manjak", Type.GetType("System.Decimal"))
    Public dcRM As DataColumn = dtPregled.Columns.Add("RazlManj", Type.GetType("System.Decimal"))
    Public dcPZ As DataColumn = dtPregled.Columns.Add("PZO", Type.GetType("System.Decimal"))
    Public dcPC As DataColumn = dtPregled.Columns.Add("CP", Type.GetType("System.Decimal"))
    Public dcNak As DataColumn = dtPregled.Columns.Add("Naknade", Type.GetType("System.Decimal"))
    Public dcTG As DataColumn = dtPregled.Columns.Add("TruGot", Type.GetType("System.Decimal"))
    Public dcPr As DataColumn = dtPregled.Columns.Add("Pred", Type.GetType("System.Decimal"))
    Public dcU As DataColumn = dtPregled.Columns.Add("Uk", Type.GetType("System.Decimal"))
   

End Module
