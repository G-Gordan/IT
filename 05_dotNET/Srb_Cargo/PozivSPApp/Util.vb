Imports System.Data.SqlClient
Module Util
    Public Sub bNadjiPDVIzSloga(ByVal inRecID As Int32, ByRef outPDV1 As Decimal, ByRef outPDV2 As Decimal, _
                                           ByRef outRetVal As String)


        Dim OKPSQL_CONNECTION_STRING As String
        OKPSQL_CONNECTION_STRING = "Server=(local);DataBase=OKPWinRoba;Integrated Security=SSPI"        ' za lokalni server

        'OKPSQL_CONNECTION_STRING="Server=10.0.4.31;DataBase=OKPWinRoba;User=Radnik;Password=roba2006"            ' za konekciju na 10.0.4.31

        Dim OkpDBVeza As New SqlConnection(OKPSQL_CONNECTION_STRING)



        outRetVal = ""

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        'Dim spKomanda As New SqlClient.SqlCommand("radnik.bNadjiPDV", OkpDbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("dbo.gmNadjiPDV", OkpDBVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulRecID As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inRecID", SqlDbType.Int))
        ulRecID.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inRecID").Value = inRecID

        '-------------------------------------- Izlazne promenljive ----------------------------------------------
        Dim izlPDV1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPDV1", SqlDbType.Decimal, 9))
        izlPDV1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPDV1").Precision = 12
        spKomanda.Parameters("@outPDV1").Scale = 2
        spKomanda.Parameters("@outPDV1").Value = outPDV1


        Dim izlPDV2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPDV2", SqlDbType.Decimal, 9))
        izlPDV2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPDV2").Precision = 12
        spKomanda.Parameters("@outPDV2").Scale = 2
        spKomanda.Parameters("@outPDV2").Value = outPDV2

        '---------------------------------------------------------------------------------------------------------

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.Char))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()

            outPDV1 = spKomanda.Parameters("@outPDV1").Value
            outPDV2 = spKomanda.Parameters("@outPDV2").Value
            outRetVal = spKomanda.Parameters("@outRetVal").Value

        Catch SQLExp As SqlException
            outRetVal = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

        If outRetVal <> "" Then
            outPDV1 = 0
            outPDV2 = 0
        End If

    End Sub
End Module
