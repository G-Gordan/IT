

Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Module Util
    Public ConnectionString As String = " Server = 10.0.4.31;database=OkpWinRoba;user =roba214kp; password=Katarina"
    'Public Const ConnectionString As String = "Server=10.0.4.31;DataBase=WinRoba;User=Radnik;Password=roba2006"

    Public Sub Raspod(ByVal connnectionString As String, ByVal ObrMesec As String, ByVal ObrGodina As String, ByRef outRetVal As String)
        'Public Sub Raspod(ByVal connnectionString As String, ByVal ObrMesec As String, ByVal ObrGodina As String)

        'Dim connection As New SqlConnection(ConnectionString)

        'Public Function Raspod(ByVal connnectionString As String, ObrMesec, ObrGodina, rv) As DataRow

        Dim connection As New SqlConnection(ConnectionString)
        Dim result As DataRow
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter

        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

        outRetVal = ""

        'If OkpDbVeza.State = ConnectionState.Closed Then
        '    OkpDbVeza.Open()
        'End If

        Dim spKomanda As New SqlClient.SqlCommand("dbo.Raspod1", connection)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim inObrMesec As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inObrMesec", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "ObrMesec", DataRowVersion.Current, ObrMesec))
        Dim inObrGodina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inObrGodina", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "ObrGodina", DataRowVersion.Current, ObrGodina))

        Dim izlRetVal As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outRetVal", SqlDbType.VarChar, 20))
        izlRetVal.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outRetVal").Value = outRetVal

        Try
            spKomanda.ExecuteScalar()
            outRetVal = spKomanda.Parameters("@outRetVal").Value
        Catch sqlexp As Exception
            outRetVal = sqlexp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outRetVal = Err.Description & " Greska u programu!"
        Finally
            connection.Close()
            spKomanda.Dispose()
        End Try
    End Sub





End Module
