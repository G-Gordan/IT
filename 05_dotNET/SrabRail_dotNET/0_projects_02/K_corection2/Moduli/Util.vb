Imports System.Data.SqlClient
Module Util
    Public tempIznos8216 As Decimal = 15
    Dim dsSlogKola As New DataSet("dsSlogKola")
    Dim dsSlogNHM As New DataSet("dsSlogNHM")
    Dim dsSlogNak As New DataSet("dsSlogNak")
    Dim dsSlogK211 As New DataSet("dsSlogK211")
    Dim dsSlogUic As New DataSet("dsSlogUic")

    Dim result As DataRow
    Dim command As SqlCommand
    Dim adapter As SqlDataAdapter
    'Public Const OKP_CONNECTION_STRING As String = "Server=10.0.4.31;DataBase=OkpWinRoba;User=Radnik;Password=roba2006"
    'Public OkpDbVeza As New SqlConnection(OKP_CONNECTION_STRING)

    Public Sub bZaokruziNaDeseteNavise(ByRef izlaz As Decimal)
        ' ulaz - decimalan broj sa dve decimale
        ' izlaz - zaokruzen na desete delove navise
        'Dim izl1 As String
        Dim a As Decimal = 0
        a = izlaz - Int(izlaz) + 0.0001
        'If a = 0 Then
        '    izlaz = Int((izlaz + 0.099) * 10) / 10
        If Microsoft.VisualBasic.Mid(a, 4, 1) < 5 Then ' 0 Or Microsoft.VisualBasic.Mid(a, 4, 1) = 1 Or Microsoft.VisualBasic.Mid(a, 4, 1) = 2 Or Microsoft.VisualBasic.Mid(a, 4, 1) = 3 Or Microsoft.VisualBasic.Mid(a, 4, 1) = 4 Then
            'MsgBox(Microsoft.VisualBasic.Mid(a, 4, 1))
            izlaz = Int((izlaz) * 10) / 10
        ElseIf Microsoft.VisualBasic.Mid(a, 4, 1) >= 5 Then
            izlaz = Int((izlaz + 0.09) * 10) / 10

            'izlaz = Int((izlaz + 0.01) * 10) / 10
            'If Microsoft.VisualBasic.Mid(a, 3, 1) >= 5 Then
            '    izlaz = Int((izlaz + 0.1) * 10) / 10
            'End If
        End If
        'If Microsoft.VisualBasic.Mid(a, 4, 1) < 5 Then ' 0 Or Microsoft.VisualBasic.Mid(a, 4, 1) = 1 Or Microsoft.VisualBasic.Mid(a, 4, 1) = 2 Or Microsoft.VisualBasic.Mid(a, 4, 1) = 3 Or Microsoft.VisualBasic.Mid(a, 4, 1) = 4 Then
        '    MsgBox(Microsoft.VisualBasic.Mid(a, 4, 1))
        '    izlaz = Int((izlaz + 0.09) * 10) / 10
        'ElseIf Microsoft.VisualBasic.Mid(a, 4, 1) >= 5 Then
        '    MsgBox(Microsoft.VisualBasic.Mid(a, 1, 1), "1")
        '    MsgBox(Microsoft.VisualBasic.Mid(a, 2, 1), "2")
        '    MsgBox(Microsoft.VisualBasic.Mid(a, 3, 1), "3")
        '    MsgBox(Microsoft.VisualBasic.Mid(a, 4, 1), "4")

        '    izlaz = Int((izlaz + 0.01) * 10) / 10
        '    'If Microsoft.VisualBasic.Mid(a, 3, 1) >= 5 Then
        '    '    izlaz = Int((izlaz + 0.1) * 10) / 10

    End Sub

    Public Function UpdateKorekcija(ByVal Korisnik As String, ByVal RedBr As Int16, ByVal Stanica As String, ByVal OtpBroj As String, ByVal BrPred As String, ByVal Visak As Decimal, ByVal VisakN As Decimal, ByVal V As Decimal, ByVal Manjak As Decimal, ByVal ManjakN As Decimal, ByVal M As Decimal, ByVal PZORazl As Decimal, ByVal CPRazl As Decimal, ByVal Nak As Decimal, ByVal TruGot As Decimal, ByVal Preduj As Decimal, ByVal Uk As Decimal, ByRef PovVrednost As String) As DataRow

        Dim command As New SqlClient.SqlCommand("KorekcUpdateIzv", OkpDbVeza)
        command.CommandType = CommandType.StoredProcedure

        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim KorisnikParm As SqlParameter = command.Parameters.Add("@inKorisnik", SqlDbType.Char, 4)
        KorisnikParm.Direction = ParameterDirection.Input
        KorisnikParm.Value = Korisnik

        Dim StanicaParm As SqlParameter = command.Parameters.Add("@inStanica", SqlDbType.Char, 5)
        StanicaParm.Direction = ParameterDirection.Input
        StanicaParm.Value = Stanica

        Dim RedBrParm As SqlParameter = command.Parameters.Add("@inRedBr", SqlDbType.Int, 4)
        RedBrParm.Direction = ParameterDirection.Input
        RedBrParm.Value = RedBr

        Dim OtpBrojParm As SqlParameter = command.Parameters.Add("@inOtpBroj", SqlDbType.Char, 6)
        OtpBrojParm.Direction = ParameterDirection.Input
        OtpBrojParm.Value = OtpBroj

        Dim BrPredParm As SqlParameter = command.Parameters.Add("@inBrPred", SqlDbType.Char, 10)
        BrPredParm.Direction = ParameterDirection.Input
        BrPredParm.Value = BrPred

        Dim VisakParm As SqlParameter = command.Parameters.Add("@inVisak", SqlDbType.Decimal, 9)
        VisakParm.Direction = ParameterDirection.Input
        VisakParm.Value = Visak

        Dim VisakNParm As SqlParameter = command.Parameters.Add("@inVisakN", SqlDbType.Decimal, 9)
        VisakNParm.Direction = ParameterDirection.Input
        VisakNParm.Value = VisakN

        Dim RazlVisakParm As SqlParameter = command.Parameters.Add("@inRazlVisak", SqlDbType.Decimal, 9)
        RazlVisakParm.Direction = ParameterDirection.Input
        RazlVisakParm.Value = V

        Dim ManjakParm As SqlParameter = command.Parameters.Add("@inManjak", SqlDbType.Decimal, 9)
        ManjakParm.Direction = ParameterDirection.Input
        ManjakParm.Value = Manjak

        Dim ManjakNParm As SqlParameter = command.Parameters.Add("@inManjakN", SqlDbType.Decimal, 9)
        ManjakNParm.Direction = ParameterDirection.Input
        ManjakNParm.Value = ManjakN

        Dim RazlManjParm As SqlParameter = command.Parameters.Add("@inRazlManj", SqlDbType.Decimal, 9)
        RazlManjParm.Direction = ParameterDirection.Input
        RazlManjParm.Value = M

        Dim PZOParm As SqlParameter = command.Parameters.Add("@inPZO", SqlDbType.Decimal, 9)
        PZOParm.Direction = ParameterDirection.Input
        PZOParm.Value = PZORazl

        Dim CPParm As SqlParameter = command.Parameters.Add("@inCP", SqlDbType.Decimal, 9)
        CPParm.Direction = ParameterDirection.Input
        CPParm.Value = CPRazl

        Dim NaknadeParm As SqlParameter = command.Parameters.Add("@inNaknade", SqlDbType.Decimal, 9)
        NaknadeParm.Direction = ParameterDirection.Input
        NaknadeParm.Value = Nak

        Dim TruGotParm As SqlParameter = command.Parameters.Add("@inTruGot", SqlDbType.Decimal, 9)
        TruGotParm.Direction = ParameterDirection.Input
        TruGotParm.Value = TruGot

        Dim PredParm As SqlParameter = command.Parameters.Add("@inPred", SqlDbType.Decimal, 9)
        PredParm.Direction = ParameterDirection.Input
        PredParm.Value = Preduj

        Dim UkParm As SqlParameter = command.Parameters.Add("@inUk", SqlDbType.Decimal, 9)
        UkParm.Direction = ParameterDirection.Input
        UkParm.Value = Uk

        Dim RetValParm As SqlParameter = command.Parameters.Add("@outRetVal", SqlDbType.Char, 9)
        RetValParm.Direction = ParameterDirection.Output
        RetValParm.Value = PovVrednost
        'Dim RetVal As SqlClient.SqlParameter = UpdateKorekcija.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))

        Try
            command.ExecuteNonQuery()
            'If UpisKorekcija.Parameters("@RETURN_VALUE").Value <> 0 Then PovVrednost = "Ništa nije upisano!"
        Catch SQLExp As SqlException
            PovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            PovVrednost = Err.Description     'Greska - bilo koja
        Finally
            'UpdateKorekcija.Dispose()
        End Try

        Return result
    End Function

    Friend Sub UpisKorekcija(ByVal Korisnik As String, ByVal RedBr As Int16, ByVal Stanica As String, ByVal OtpBroj As String, ByVal BrPred As String, ByVal Visak As Decimal, ByVal VisakN As Decimal, ByVal V As Decimal, ByVal Manjak As Decimal, ByVal ManjakN As Decimal, ByVal M As Decimal, ByVal PZORazl As Decimal, ByVal CPRazl As Decimal, ByVal Nak As Decimal, ByVal TruGot As Decimal, ByVal Preduj As Decimal, ByVal Uk As Decimal, ByRef PovVrednost As String)

        Dim UpisKorekcija As New SqlClient.SqlCommand("roba214kp.KorekcijaIzv1", OkpDbVeza)
        UpisKorekcija.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 4, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
        Dim inKorisnik As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inKorisnik", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Korisnik", DataRowVersion.Current, Korisnik))
        Dim inRedBr As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inRedBr", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RedBr", DataRowVersion.Current, RedBr))
        Dim inStanica As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "Stanica  ", DataRowVersion.Current, Stanica))
        Dim inOtpBroj As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, OtpBroj))
        Dim inBrPred As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inBrPred", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "BrPred", DataRowVersion.Current, BrPred))
        Dim inVisak As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inVisak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Visak", DataRowVersion.Current, Visak))
        Dim inVisakN As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inVisakN", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VisakN", DataRowVersion.Current, VisakN))
        Dim inRazlVisak As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inRazlVisak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "RazlVisak", DataRowVersion.Current, V))
        Dim inManjak As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inManjak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Manjak", DataRowVersion.Current, Manjak))
        Dim inManjakN As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inManjakN", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "ManjakM", DataRowVersion.Current, ManjakN))
        Dim inRazlManj As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inRazlManj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "RazlManj", DataRowVersion.Current, M))
        Dim inPZO As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inPZO", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PZO", DataRowVersion.Current, PZORazl))
        Dim inCP As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inCP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "CP", DataRowVersion.Current, CPRazl))
        Dim inNaknade As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inNaknade", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Naknade", DataRowVersion.Current, Nak))
        Dim inTruGot As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inTruGot", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "TruGot", DataRowVersion.Current, TruGot))
        Dim inPred As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inPred", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pred", DataRowVersion.Current, Preduj))
        Dim inUk As SqlClient.SqlParameter = UpisKorekcija.Parameters.Add(New SqlClient.SqlParameter("@inUk", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Uk", DataRowVersion.Current, Uk))

        Try
            UpisKorekcija.ExecuteNonQuery()
            'If UpisKorekcija.Parameters("@RETURN_VALUE").Value <> 0 Then PovVrednost = "Ništa nije upisano!"
        Catch SQLExp As SqlException
            PovVrednost = SQLExp.Message      'Greska - SQL greska
        Catch Exp As Exception
            PovVrednost = Err.Description     'Greska - bilo koja
        Finally
            UpisKorekcija.Dispose()
        End Try

    End Sub

    Public Function BrisiKorekcija(ByVal Korisnik As String, ByRef PovVrednost As String) As DataRow
        'Dim connection As New SqlConnection(ConnectionString)
       
        Try
            command = New SqlCommand("roba214kp.KorekcijaBrisiIzv11", OkpDbVeza)
            command.CommandType = CommandType.StoredProcedure

            If OkpDbVeza.State = ConnectionState.Closed Then
                OkpDbVeza.Open()
            End If

            Dim RetVal As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 20, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
            'Dim inRedBr As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inRedBr", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RedBr", DataRowVersion.Current, RedBr))
            Dim inKorisnik As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inKorisnik", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Korisnik", DataRowVersion.Current, Korisnik))
            'Dim inStanica As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Stanica  ", DataRowVersion.Current, Stanica))
            'Dim inOtpBroj As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, OtpBroj))
            'Dim inBrPred As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inBrPred", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "BrPred", DataRowVersion.Current, BrPred))
            'Dim inVisak As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inVisak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Visak", DataRowVersion.Current, Visak))
            'Dim inVisakN As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inVisakN", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VisakN", DataRowVersion.Current, VisakN))
            'Dim inRazlVisak As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inRazlVisak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "RazlVisak", DataRowVersion.Current, V))
            'Dim inManjak As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inManjak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Manjak", DataRowVersion.Current, Manjak))
            'Dim inManjakN As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inManjakN", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "ManjakM", DataRowVersion.Current, ManjakN))
            'Dim inRazlManj As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inRazlManj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "RazlManj", DataRowVersion.Current, M))
            'Dim inPZO As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inPZO", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PZO", DataRowVersion.Current, PZORazl))
            'Dim inCP As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inCP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "CP", DataRowVersion.Current, CPRazl))
            'Dim inNaknade As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inNaknade", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Naknade", DataRowVersion.Current, Nak))
            'Dim inTruGot As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inTruGot", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "TruGot", DataRowVersion.Current, TruGot))
            'Dim inPred As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inPred", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pred", DataRowVersion.Current, Preduj))
            'Dim inUk As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inUk", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Uk", DataRowVersion.Current, Uk))

            Dim datatable As New DataTable
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datatable)

        Catch ex As Exception
            MsgBox(ex.ToString)


        Finally
            If Not adapter Is Nothing Then
                adapter.Dispose()
            End If
            If Not command Is Nothing Then
                command.Dispose()
            End If
        End Try
        Return result
    End Function
    'Public Function BrisiKorekcija(ByVal Korisnik As String, ByVal RedBr As Int16, ByVal Stanica As String, ByVal OtpBroj As String, ByVal BrPred As String, ByVal Visak As Decimal, ByVal VisakN As Decimal, ByVal V As Decimal, ByVal Manjak As Decimal, ByVal ManjakN As Decimal, ByVal M As Decimal, ByVal PZORazl As Decimal, ByVal CPRazl As Decimal, ByVal Nak As Decimal, ByVal TruGot As Decimal, ByVal Preduj As Decimal, ByVal Uk As Decimal, ByRef PovVrednost As String) As DataRow
    '    'Dim connection As New SqlConnection(ConnectionString)
    '    Dim result As DataRow
    '    Dim command As SqlCommand
    '    Dim adapter As SqlDataAdapter
    '    Try
    '        command = New SqlCommand("KorekcijaBrisiIzv", OkpDbVeza)
    '        command.CommandType = CommandType.StoredProcedure

    '        If OkpDbVeza.State = ConnectionState.Closed Then
    '            OkpDbVeza.Open()
    '        End If

    '        Dim RetVal As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
    '        Dim inRedBr As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inRedBr", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RedBr", DataRowVersion.Current, RedBr))
    '        Dim inKorisnik As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inKorisnik", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Korisnik", DataRowVersion.Current, Korisnik))
    '        Dim inStanica As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Stanica  ", DataRowVersion.Current, Stanica))
    '        Dim inOtpBroj As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, OtpBroj))
    '        Dim inBrPred As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inBrPred", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "BrPred", DataRowVersion.Current, BrPred))
    '        Dim inVisak As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inVisak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Visak", DataRowVersion.Current, Visak))
    '        Dim inVisakN As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inVisakN", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VisakN", DataRowVersion.Current, VisakN))
    '        Dim inRazlVisak As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inRazlVisak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "RazlVisak", DataRowVersion.Current, V))
    '        Dim inManjak As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inManjak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Manjak", DataRowVersion.Current, Manjak))
    '        Dim inManjakN As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inManjakN", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "ManjakM", DataRowVersion.Current, ManjakN))
    '        Dim inRazlManj As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inRazlManj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "RazlManj", DataRowVersion.Current, M))
    '        Dim inPZO As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inPZO", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PZO", DataRowVersion.Current, PZORazl))
    '        Dim inCP As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inCP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "CP", DataRowVersion.Current, CPRazl))
    '        Dim inNaknade As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inNaknade", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Naknade", DataRowVersion.Current, Nak))
    '        Dim inTruGot As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inTruGot", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "TruGot", DataRowVersion.Current, TruGot))
    '        Dim inPred As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inPred", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pred", DataRowVersion.Current, Preduj))
    '        Dim inUk As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inUk", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Uk", DataRowVersion.Current, Uk))

    '        Dim datatable As New DataTable
    '        adapter = New SqlDataAdapter(command)
    '        adapter.Fill(datatable)

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)


    '    Finally
    '        If Not adapter Is Nothing Then
    '            adapter.Dispose()
    '        End If
    '        If Not command Is Nothing Then
    '            command.Dispose()
    '        End If
    '    End Try
    '    Return result
    'End Function
    'Public Function BrisiKorekcija1(ByVal Korisnik As String, ByVal RedBr As Int16, ByVal Stanica As String, ByVal OtpBroj As String, ByVal BrPred As String, ByVal Visak As Decimal, ByVal VisakN As Decimal, ByVal V As Decimal, ByVal Manjak As Decimal, ByVal ManjakN As Decimal, ByVal M As Decimal, ByVal PZORazl As Decimal, ByVal CPRazl As Decimal, ByVal Nak As Decimal, ByVal TruGot As Decimal, ByVal Preduj As Decimal, ByVal Uk As Decimal, ByRef PovVrednost As String) As DataRow
    '    'Dim connection As New SqlConnection(ConnectionString)
    '    Dim result As DataRow
    '    Dim command As SqlCommand
    '    Dim adapter As SqlDataAdapter
    '    Try
    '        command = New SqlCommand("KorekcijaBrisiIzv1", OkpDbVeza)
    '        command.CommandType = CommandType.StoredProcedure

    '        If OkpDbVeza.State = ConnectionState.Closed Then
    '            OkpDbVeza.Open()
    '        End If

    '        Dim RetVal As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5, ParameterDirection.ReturnValue, True, 0, 0, "", DataRowVersion.Current, ""))
    '        Dim inRedBr As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inRedBr", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, "RedBr", DataRowVersion.Current, RedBr))
    '        Dim inKorisnik As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inKorisnik", SqlDbType.Char, 4, ParameterDirection.Input, False, 0, 0, "Korisnik", DataRowVersion.Current, Korisnik))
    '        Dim inStanica As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inStanica", SqlDbType.Char, 7, ParameterDirection.Input, False, 0, 0, "Stanica", DataRowVersion.Current, Stanica))
    '        Dim inOtpBroj As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inOtpBroj", SqlDbType.Char, 6, ParameterDirection.Input, False, 0, 0, "OtpBroj", DataRowVersion.Current, OtpBroj))
    '        Dim inBrPred As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inBrPred", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "BrPred", DataRowVersion.Current, BrPred))
    '        Dim inVisak As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inVisak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Visak", DataRowVersion.Current, Visak))
    '        Dim inVisakN As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inVisakN", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "VisakN", DataRowVersion.Current, VisakN))
    '        Dim inRazlVisak As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inRazlVisak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "RazlVisak", DataRowVersion.Current, V))
    '        Dim inManjak As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inManjak", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Manjak", DataRowVersion.Current, Manjak))
    '        Dim inManjakN As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inManjakN", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "ManjakM", DataRowVersion.Current, ManjakN))
    '        Dim inRazlManj As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inRazlManj", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "RazlManj", DataRowVersion.Current, M))
    '        Dim inPZO As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inPZO", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "PZO", DataRowVersion.Current, PZORazl))
    '        Dim inCP As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inCP", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "CP", DataRowVersion.Current, CPRazl))
    '        Dim inNaknade As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inNaknade", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Naknade", DataRowVersion.Current, Nak))
    '        Dim inTruGot As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inTruGot", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "TruGot", DataRowVersion.Current, TruGot))
    '        Dim inPred As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inPred", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Pred", DataRowVersion.Current, Preduj))
    '        Dim inUk As SqlClient.SqlParameter = command.Parameters.Add(New SqlClient.SqlParameter("@inUk", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 0, 0, "Uk", DataRowVersion.Current, Uk))

    '        Dim datatable As New DataTable
    '        adapter = New SqlDataAdapter(command)
    '        adapter.Fill(datatable)

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)

    '    Finally
    '        If Not adapter Is Nothing Then
    '            adapter.Dispose()
    '        End If
    '        If Not command Is Nothing Then
    '            command.Dispose()
    '        End If
    '    End Try
    '    Return result
    'End Function

    Public Sub sNadjiNaziv(ByVal ipTabela As String, ByVal ipSifra1 As String, ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                           ByRef opCount As Int16, ByRef opNaziv As String, _
                           ByRef opPovVrednost As String)

        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True

        Select Case ipTabela
            Case "UicUprave"
                sqlText = "SELECT Oznaka FROM UicUprave WHERE SifraUprave = '" & ipSifra1 & "'"
            Case "NazivTabele"
                sqlText = "SELECT SifTab FROM SifTabCen WHERE Ugovor = '" & ipSifra1 & "'"
            Case "UicOperateri"
                sqlText = "SELECT Oznaka FROM UicOperateri WHERE Operater = '" & ipSifra1 & "' AND SifraUprave = '" & ipSifra2 & "'"
            Case "UicStanice"
                sqlText = "SELECT Naziv FROM UicStanice WHERE SifraStanice = '" & ipSifra1 & "'"
            Case "UicPrelaz"
                sqlText = "SELECT Naziv FROM UicPrelazi WHERE Uprava1 = '" & ipSifra1 & "' AND SifraPrelaza = '" & ipSifra2 & "'"
            Case "ZsStanice"
                sqlText = "SELECT SifraStanice, Naziv FROM ZsStanice WHERE NadzornaStanicaSifra  = '" & ipSifra1 & "'"
            Case "NHMPozicije"
                sqlText = "SELECT Naziv FROM NHMPozicije WHERE NHMPozicije.NHMSifra = '" & ipSifra1 & "'"
            Case "Tarife"
                sqlText = "SELECT Naziv WHERE Oznaka = '" & ipSifra1 & "'"
            Case "TabNaziv"
                sqlText = "SELECT SifTab FROM TabNaziv WHERE Ugovor = '" & ipSifra1 & "'"
            Case "UserTab"
                sqlText = "SELECT UserID, Lozinka, Stanica FROM UserTab WHERE UserID = '" & ipSifra1 & "' AND Lozinka = '" & ipSifra2 & "' AND Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "'"
            Case "Ugovori"
                sqlText = " SELECT  dbo.Komitent.Naziv, dbo.Komitent.Mesto " _
                        & " FROM    dbo.Cena_UgovorKP INNER JOIN " _
                        & " dbo.Ugovori ON dbo.Cena_UgovorKP.BrojUgovora = dbo.Ugovori.BrojUgovora INNER JOIN " _
                        & " dbo.Komitent ON dbo.Ugovori.SifraKorisnika = dbo.Komitent.Sifra " _
                        & " WHERE dbo.Ugovori.BrojUgovora = '" & ipSifra1 & "'"
            Case "Komitent"
                sqlText = "SELECT Naziv From Komitent WHERE Sifra = '" & ipSifra1 & "'"
            Case "UNalepnica"
                sqlText = "SELECT UlEtiketa From dbo.SlogKalk WHERE UlEtiketa = '" & ipSifra1 & "' AND ZsUlPrelaz = '" & ipSifra2 & "'"
            Case "TaraKola"
                sqlText = "SELECT Tara From dbo.IBK Where IBK = '" & ipSifra1 & "'"
            Case Else
                opPovVrednost = "Data Table: " & ipTabela & " - NE POSTOJI !!! , Greska u Programu"
        End Select

        If opPovVrednost = "" Then
            Dim uspKomanda As New SqlClient.SqlCommand(sqlText, DbVeza)
            Try
                If DbVeza.State = ConnectionState.Closed Then
                    DbVeza.Open()
                Else
                    closeConn = False
                End If
                opNaziv = uspKomanda.ExecuteScalar()
                If opNaziv = Nothing Then opPovVrednost = "Ne postoji takav podatak!" ' SLOG NE POSTOJI !!!
            Catch SQLExp As SqlException
                opPovVrednost = SQLExp.Message & "??"  'Greska - SQL greska
            Catch Exp As Exception
                opPovVrednost = Err.Description & " ?"  'Greska - bilo koja"
            Finally
                If closeConn Then DbVeza.Close()
                uspKomanda.Dispose()
            End Try
        End If
    End Sub

    Public Sub Lozinka(ByVal ipSifra1 As String, ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                       ByRef opCount As Int16, ByRef opNaziv As String, _
                       ByRef opPovVrednost As String)


        'ipTabela=Tabela koja se koristi
        'ipSifra1=Sifra1 iz te tabele
        'ipSifra2=Sifra2 iz te tabele(ako je ima)
        'ipSifra3=Sifra3 iz te tabele(ako je ima)
        'broj neuspesnih pokusaja
        'opNaziv=povratna vrednost naziva
        'opPovVrednost=povratna vrednost 

        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True

        sqlText = "SELECT UserID, Lozinka, Stanica FROM UserTab WHERE UserID = '" & ipSifra1 & "' AND Lozinka = '" & ipSifra2 & "' AND Stanica = '" & Microsoft.VisualBasic.Mid(StanicaUnosa, 5, 5) & "'"

        If opPovVrednost = "" Then
            Dim uspKomanda As New SqlClient.SqlCommand(sqlText, OkpDbVeza)
            Try
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                Else
                    closeConn = False
                End If
                opNaziv = uspKomanda.ExecuteScalar()
                If opNaziv = Nothing Then opPovVrednost = "Ne postoji takav podatak!" ' SLOG NE POSTOJI !!!
            Catch SQLExp As SqlException
                opPovVrednost = SQLExp.Message & "??"  'Greska - SQL greska
            Catch Exp As Exception
                opPovVrednost = Err.Description & " ?"  'Greska - bilo koja"
            Finally
                If closeConn Then OkpDbVeza.Close()
                uspKomanda.Dispose()
            End Try
        End If
    End Sub

    Public Sub sNadjiNalepnicu(ByVal ipSifra1 As Int32, ByVal ipSifra2 As String, ByVal ipSifra3 As String, _
                               ByVal ipSifra4 As String, ByRef opNaziv As String, _
                               ByRef opPovVrednost As String)

        'opNaziv=povratna vrednost naziva
        'opPovVrednost=povratna vrednost 

        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""
        Dim closeConn As Boolean = True

        sqlText = "SELECT UlEtiketa From dbo.SlogKalk " _
                & "WHERE UlEtiketa = " & ipSifra1 _
                & " AND ZsUlPrelaz = '" & ipSifra2 & "'" _
                & " AND ObrGodina = '" & ipSifra3 & "'" _
                & " AND ObrMesec = '" & ipSifra4 & "'"

        If opPovVrednost = "" Then
            Dim uspKomanda As New SqlClient.SqlCommand(sqlText, OkpDbVeza)
            Try
                If OkpDbVeza.State = ConnectionState.Closed Then
                    OkpDbVeza.Open()
                Else
                    closeConn = False
                End If
                opNaziv = uspKomanda.ExecuteScalar()
                If opNaziv = Nothing Then opPovVrednost = "Ne postoji takav podatak!" ' SLOG NE POSTOJI !!!
            Catch SQLExp As SqlException
                opPovVrednost = SQLExp.Message & "??"  'Greska - SQL greska
            Catch Exp As Exception
                opPovVrednost = Err.Description & " ?"  'Greska - bilo koja"
            Finally
                If closeConn Then OkpDbVeza.Close()
                uspKomanda.Dispose()
            End Try
        End If
    End Sub

End Module
