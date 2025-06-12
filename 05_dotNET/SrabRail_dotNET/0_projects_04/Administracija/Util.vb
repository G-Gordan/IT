Imports System.Data.SqlClient
public Module Util
    Public Const SQL_CONNECTION_STRING As String = _
            "Server=(local);" & _
            "DataBase=Roba;" & _
            "Integrated Security=SSPI"
    Public Const MASTER_CONNECTION_STRING As String = _
            "Server=(local);" & _
            "DataBase=master;" & _
            "Integrated Security=SSPI"

    Public cnRoba As New SqlConnection(SQL_CONNECTION_STRING)
    Public cnMaster As New SqlConnection(MASTER_CONNECTION_STRING)

    Public gv_Korisnik As String = "admin"  'Korisnik ulogovan u sistem
    Public Const KrajReda As Char = vbCrLf  'Za Kraj Reda uzet je <RETURN>  

    Public dirSlike As String = "d:\appl\VB.NET\VB-MyPrograms\Slike\"
    Public imageAsc As Image = Image.FromFile(dirSlike & "SortA.bmp")
    Public imageDesc As Image = Image.FromFile(dirSlike & "SortD.bmp")
    Public imagePrint As Image = Image.FromFile(dirSlike & "Print.bmp")

    public Function ts() As String
        Return (Format(Year(Now), "0000") & "." & Format(Month(Now), "00") & "." & Format(Microsoft.VisualBasic.DateAndTime.Day(Now), "00") & " " & Format(Hour(Now), "00") & ":" & Format(Minute(Now), "00") & ":" & Format(Second(Now), "00"))
    End Function
    'Za ComboBox - vraca Kljuc ako se funkciji prosledi niz i Opis
    public Function aComboVK(ByVal niz() As String, ByVal opis As String) As String
        Dim ii As Int16 = 0
        Dim aKljuc As String = "?"  'Vraca upitnik ako nesto nije u redu
        For ii = 0 To niz.Length - 1
            If (ii Mod 2 > 0 And niz(ii) = opis) Then
                aKljuc = niz(ii - 1)
            End If
        Next
        Return aKljuc
    End Function
    'Za ComboBox - vraca Opis ako se funkciji prosledi niz i Kljuc
    public Function aComboVO(ByVal niz() As String, ByVal kljuc As String) As String
        Dim ii As Int16 = 0
        Dim aOpis As String = "?"  'Vraca upitnik ako nesto nije u redu
        For ii = 0 To niz.Length - 1
            If (ii Mod 2 = 0 And niz(ii) = kljuc) Then
                aOpis = niz(ii + 1)
            End If
        Next
        Return aOpis
    End Function
    public Function fNadjiNaziv(ByVal Sifra As String, ByVal upHelpGrid As String) As String
        Dim Naziv As String = ""

        Dim uspKomanda As New SqlClient.SqlCommand(upHelpGrid, cnRoba)
        uspKomanda.CommandType = CommandType.StoredProcedure

        Dim RetVal As SqlClient.SqlParameter
        RetVal = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@RETURN_VALUE", SqlDbType.Int, 5))
        RetVal.Direction = ParameterDirection.ReturnValue

        Dim ipSifra As SqlClient.SqlParameter
        ipSifra = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ipSifra", SqlDbType.NVarChar, 200))
        ipSifra.Direction = ParameterDirection.Input
        uspKomanda.Parameters("@ipSifra").Value = Sifra

        Dim opNaziv As SqlClient.SqlParameter
        opNaziv = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@opNaziv", SqlDbType.NVarChar, 500))
        opNaziv.Direction = ParameterDirection.Output

        Try
            cnRoba.Open()
            uspKomanda.ExecuteScalar()
            If uspKomanda.Parameters("@RETURN_VALUE").Value = 0 Then
                Naziv = "Slog NE POSTOJI !"  ' Slog nije pronadjen --> @@ROWCOUNT == 0
            Else
                If IsDBNull(uspKomanda.Parameters("@opNaziv").Value) Then
                    Naziv = ""   'Slog nadjen - naziv prazan
                Else
                    Naziv = uspKomanda.Parameters("@opNaziv").Value  'Slog nadjen - naziv popunjen
                End If
                Naziv = Naziv & " ."
            End If
        Catch SQLExp As SqlException
            Naziv = SQLExp.Message & " ?"  'Greska - SQL greska
        Catch Exp As Exception
            Naziv = Err.Description & "??" 'Greska - bilo koja
        Finally
            cnRoba.Close()
            uspKomanda.Dispose()
        End Try
        Return Naziv
    End Function
    public Function ObradaSQLServerGreske(ByVal BrojGreske As Int16) As String
        Dim SQLOpisGreske As String = ""

        'Definisanje komanda, sa konekcijom: SQLKonekcija, u Uskladistenoj Proceduri uspGetErrorMessage
        Dim uspKomanda As New SqlClient.SqlCommand("uspGetErrorMessage", cnMaster)
        uspKomanda.CommandType = CommandType.StoredProcedure

        'Definisanje ulaznog parametra ip_ErrorNumber = BrojGreske
        Dim ipBrojGreske As SqlClient.SqlParameter
        ipBrojGreske = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@ip_ErrorNumber", SqlDbType.Int, 5))
        ipBrojGreske.Direction = ParameterDirection.Input
        uspKomanda.Parameters("@ip_ErrorNumber").Value = BrojGreske

        'Definisanje izaznog parametra op_ErrorDescription (Opis SQL Greske)
        Dim opOpisGreske As SqlClient.SqlParameter
        opOpisGreske = uspKomanda.Parameters.Add(New SqlClient.SqlParameter("@op_ErrorText", SqlDbType.VarChar, 500))
        opOpisGreske.Direction = ParameterDirection.Output

        Try
            cnMaster.Open()
            uspKomanda.ExecuteScalar()
            If IsDBNull(uspKomanda.Parameters("@op_ErrorText").Value) Then
                SQLOpisGreske = ""
            Else
                SQLOpisGreske = uspKomanda.Parameters("@op_ErrorText").Value
            End If
        Catch
            SQLOpisGreske = Err.Description
        Finally
            cnMaster.Close()
        End Try
        Return SQLOpisGreske
    End Function
End Module
