Imports System.Data.SqlClient
Module Korisnici
    Friend ds As New DataSet("Korisnici")
    Friend dt As DataTable = New DataTable("Korisnici")

    Friend Akcija As String = ""
    Friend dwClosed As Integer = 0  ' Dialog Window: 0 - CANCEL, ESC, CLOSE ; 1 - OK

    'Polja za formu
    Friend f_KorisnikL As String = ""
    Friend f_Lozinka As String = ""
    Friend f_Prezime As String = ""
    Friend f_Ime As String = ""
    Friend f_KorGrupa As String = ""
    Friend f_Privilegije As Int16 = 0
    Friend f_dAktiviranja As Date = "1.1.2000"
    Friend f_dPromeneLozinke As Date = "1.1.2000"
    Friend f_LozinkaDana As Int16 = 100
    Friend f_tsZadnjiLogin As String = ""
    Friend f_Aktivan As Char = "N"
    Friend f_Napomena As String = ""
    Friend f_ts As String = ""

    Friend Sub subKorisniciMan(ByRef GreskaOpisTrans As String)
        Dim rv As Int16
        Dim VBGreskaOpisTrans As String = ""
        Dim SQLGreskaOpisTrans As String = ""

        Dim uspKorisniciMan As New SqlClient.SqlCommand("uspKorisniciMan", cnRoba)
        uspKorisniciMan.CommandType = CommandType.StoredProcedure

        ' Definisanje Parametara za Uskladistenu Proceduru
        Dim RetVal As SqlClient.SqlParameter
        RetVal = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5))
        RetVal.Direction = ParameterDirection.ReturnValue

        Dim ipAkcija As SqlClient.SqlParameter
        ipAkcija = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipAkcija", SqlDbType.Char, 6))
        ipAkcija.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipAkcija").Value = Akcija

        Dim ipKorisnikL As SqlClient.SqlParameter
        ipKorisnikL = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipKorisnikL", SqlDbType.NChar, 10))
        ipKorisnikL.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipKorisnikL").Value = f_KorisnikL

        Dim ipLozinka As SqlClient.SqlParameter
        ipLozinka = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipLozinka", SqlDbType.NChar, 10))
        ipLozinka.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipLozinka").Value = f_Lozinka

        Dim ipPrezime As SqlClient.SqlParameter
        ipPrezime = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipPrezime", SqlDbType.NVarChar, 20))
        ipPrezime.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipPrezime").Value = f_Prezime

        Dim ipIme As SqlClient.SqlParameter
        ipIme = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipIme", SqlDbType.NVarChar, 20))
        ipIme.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipIme").Value = f_Ime

        Dim ipKorGrupa As SqlClient.SqlParameter
        ipKorGrupa = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipKorGrupa", SqlDbType.NChar, 10))
        ipKorGrupa.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipKorGrupa").Value = f_KorGrupa

        Dim ipPrivilegije As SqlClient.SqlParameter
        ipPrivilegije = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipPrivilegije", SqlDbType.Int, 1))
        ipPrivilegije.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipPrivilegije").Value = f_Privilegije

        Dim ipdAktiviranja As SqlClient.SqlParameter
        ipdAktiviranja = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipdAktiviranja", SqlDbType.SmallDateTime, 4))
        ipdAktiviranja.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipdAktiviranja").Value = f_dAktiviranja

        Dim ipdPromeneLozinke As SqlClient.SqlParameter
        ipdPromeneLozinke = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipdPromeneLozinke", SqlDbType.SmallDateTime, 4))
        ipdPromeneLozinke.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipdPromeneLozinke").Value = f_dPromeneLozinke

        Dim ipLozinkaDana As SqlClient.SqlParameter
        ipLozinkaDana = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipLozinkaDana", SqlDbType.Int, 4))
        ipLozinkaDana.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipLozinkaDana").Value = f_LozinkaDana

        Dim iptsZadnjiLogin As SqlClient.SqlParameter
        iptsZadnjiLogin = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@iptsZadnjiLogin", SqlDbType.Char, 19))
        iptsZadnjiLogin.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@iptsZadnjiLogin").Value = f_tsZadnjiLogin

        Dim ipAktivan As SqlClient.SqlParameter
        ipAktivan = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipAktivan", SqlDbType.Char, 1))
        ipAktivan.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipAktivan").Value = f_Aktivan

        Dim ipNapomena As SqlClient.SqlParameter
        ipNapomena = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipNapomena", SqlDbType.NVarChar, 8000))
        ipNapomena.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipNapomena").Value = f_Napomena

        Dim ipTStamp As SqlClient.SqlParameter
        ipTStamp = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipTStamp", SqlDbType.Char, 19))
        ipTStamp.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipTStamp").Value = ts()

        Dim ipKorisnik As SqlClient.SqlParameter
        ipKorisnik = uspKorisniciMan.Parameters.Add(New SqlClient.SqlParameter("@ipKorisnik", SqlDbType.Char, 10))
        ipKorisnik.Direction = ParameterDirection.Input
        uspKorisniciMan.Parameters("@ipKorisnik").Value = gv_Korisnik

        cnRoba.Open()
        Try
            uspKorisniciMan.ExecuteNonQuery()
            cnRoba.BeginTransaction.Commit()
        Catch SQLExp As SqlException
            cnRoba.BeginTransaction.Rollback()
            VBGreskaOpisTrans = SQLExp.Message & vbCrLf
        Catch Exp As Exception
            cnRoba.BeginTransaction.Rollback()
            VBGreskaOpisTrans = Err.Description & vbCrLf
        Finally
            cnRoba.Close()
            uspKorisniciMan.Dispose()
        End Try
        rv = uspKorisniciMan.Parameters("@RETURN_VALUE").Value
        If rv > 0 Then
            VBGreskaOpisTrans = VBGreskaOpisTrans & "GREŠKA_TRANSAKCIJE_BROJ_" & rv.ToString() & vbCrLf
        End If
        GreskaOpisTrans = VBGreskaOpisTrans
    End Sub
    Friend Function fProveriKorGrupa(ByVal ipPolje As String, ByVal ipKorGrupa As String) As String
        Dim povVrednost As String = ""
        Dim oznaka As String = ""

        povVrednost = Trim(fcvKorGrupa(ipKorGrupa))
        oznaka = Microsoft.VisualBasic.Right(povVrednost, 1)
        If oznaka = "?" Or oznaka = "!" Then
            povVrednost = ipPolje & vbCrLf & vbCrLf & povVrednost
        Else
            povVrednost = ""
        End If
        Return povVrednost
    End Function
End Module