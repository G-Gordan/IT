Imports System.Data.SqlClient
Module Upis
    Friend Sub UpisOgr(ByVal ipTrans As SqlTransaction, ByVal Akcija As String, ByVal Uprava As String, ByVal BrTrOgrZS As String, ByVal BrTel As String, ByVal TelDat As String, ByVal BrTrOgrUprave As String, ByVal Razlog As String, ByVal UspPos As String, ByVal VaziOd As DateTime, ByVal DoOpoziva As String, ByVal VaziDo As DateTime, ByVal NazivFile As String, ByRef opPovVrednost As String)

        Dim uspUpisTrOgr As New SqlClient.SqlCommand("radnik.kUpisTrOgrText", WebVeza)
        uspUpisTrOgr.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inAkcija As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inAkcija", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Current, Akcija))
        Dim inUprava As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inUprava", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Uprava", DataRowVersion.Current, Uprava))
        Dim inBrTrOgrZS As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inBrTrOgrZS", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "BrTrOgrZS", DataRowVersion.Current, BrTrOgrZS))
        Dim inBrTel As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inBrTel", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "BrTel", DataRowVersion.Current, BrTel))
        Dim inTelDat As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inTelDat", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "TelDat", DataRowVersion.Current, TelDat))
        Dim inBrTrOgrUprave As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inBrTrOgrUprave", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "BrTrOgrUprave", DataRowVersion.Current, BrTrOgrUprave))
        Dim inRazlog As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inRazlog", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "Razlog", DataRowVersion.Current, Razlog))
        Dim inUspPos As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inUspPos", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "UspPos", DataRowVersion.Current, UspPos))
        Dim inVaziOd As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inVaziOd", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "VaziOd", DataRowVersion.Current, VaziOd))
        Dim inDoOpoziva As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inDoOpoziva", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "DoOpoziva", DataRowVersion.Current, DoOpoziva))
        Dim inVaziDo As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inVaziDo", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "VaziDo", DataRowVersion.Current, VaziDo))
        Dim inNazivFile As SqlClient.SqlParameter = uspUpisTrOgr.Parameters.Add(New SqlClient.SqlParameter("@inNazivFile", SqlDbType.VarChar, 30, ParameterDirection.Input, False, 0, 0, "NazivFile", DataRowVersion.Current, NazivFile))
        uspUpisTrOgr.Transaction = ipTrans

        Try
            uspUpisTrOgr.ExecuteNonQuery()
            If uspUpisTrOgr.Parameters("@RETURN_VALUE").Value = 0 And Akcija <> "Del" Then opPovVrednost = "Ništa nije upisano!"
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            opPovVrednost = Err.Description     'Greska - bilo koja
        Finally
            uspUpisTrOgr.Dispose()
        End Try

    End Sub
End Module
