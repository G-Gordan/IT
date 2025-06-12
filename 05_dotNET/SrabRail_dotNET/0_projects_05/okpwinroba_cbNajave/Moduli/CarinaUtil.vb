Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Module CarinaUtil
    Friend ffrmListUicUprave As Boolean = False
    Friend ffrmListUicStanice As Boolean = False

    Public Const cKrajReda As Char = vbCrLf         'Za Kraj Reda uzet je <RETURN>  
    Public Const cDirRep As String = "c:"           'Default Direktorijum za Izvestaje
    Public Const cSlash As Char = "\"               'Direktorijum Delimiter (zavisno od Operativnog Sistema)

    'Public cnWinRoba As New SqlConnection("Server=ilic;DataBase=WinRoba;Integrated Security=SSPI")

    'Public imageDir As String = "..\slike\"
    'Public imagePrint As Image = Image.FromFile(imageDir & "Print.bmp")
    'Public imageAsc As Image = Image.FromFile(imageDir & "SortA.bmp")
    'Public imageDesc As Image = Image.FromFile(imageDir & "SortD.bmp")

    Public Function ts() As String
        Return (Format(Year(Now), "0000") & "." & Format(Month(Now), "00") & "." & Format(Microsoft.VisualBasic.DateAndTime.Day(Now), "00") & " " & Format(Hour(Now), "00") & ":" & Format(Minute(Now), "00") & ":" & Format(Second(Now), "00"))
    End Function

    Public Function aComboVK(ByVal niz() As String, ByVal opis As String) As String
        Dim ii As Int16 = 0
        Dim aKljuc As String = "?"  'Vraca upitnik ako nesto nije u redu
        For ii = 0 To niz.Length - 1
            If (ii Mod 2 > 0 And niz(ii) = opis) Then
                aKljuc = niz(ii - 1)
                Exit For
            End If
        Next
        Return aKljuc
    End Function
    'Za ComboBox - vraca Opis ako se funkciji prosledi niz i Kljuc
    Public Function aComboVO(ByVal niz() As String, ByVal kljuc As String) As String
        Dim ii As Int16 = 0
        Dim aOpis As String = "?"  'Vraca upitnik ako nesto nije u redu
        For ii = 0 To niz.Length - 1
            If (ii Mod 2 = 0 And niz(ii) = kljuc) Then
                aOpis = niz(ii + 1)
                Exit For
            End If
        Next
        Return aOpis
    End Function

    Public Sub sNadjiApplPar(ByVal ipTrans As SqlTransaction, ByVal ipNaziv As String, ByRef opVrednost As String, ByRef opPovVrednost As String)
        opPovVrednost = ""
        Dim uspKomanda As New SqlClient.SqlCommand("SELECT Vrednost FROM ApplPar WHERE Naziv = '" & ipNaziv & "'", cnWinRoba)
        Try
            If ipTrans Is Nothing Or cnWinRoba.State.Closed Then
                cnWinRoba.Open()
            Else
                uspKomanda.Transaction = ipTrans
            End If
            opVrednost = uspKomanda.ExecuteScalar()
            If IsDBNull(opVrednost) Or opVrednost = Nothing Then opPovVrednost = "Applikacioni Parametar: """ & ipNaziv & """ - NE POSTOJI u tabeli ""ApplPar"""
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message
        Catch Exp As Exception
            opPovVrednost = Err.Description
        Finally
            If ipTrans Is Nothing Then cnWinRoba.Close()
            uspKomanda.Dispose()
        End Try
    End Sub

    Public Function fcvSlogPostoji(ByVal ipTrans As SqlTransaction, ByVal ipTabela As String, ByVal ipSifra1 As String, ByVal ipSifra2 As String, ByVal ipSifra3 As String, ByVal ipSifra4 As String) As Boolean
        Dim opPovVrednost As Boolean = False
        Dim poruka As String = ""
        Dim sqlText As String = ""

        Select Case ipTabela
            Case "UicOperateri"
                sqlText = "SELECT count(*) FROM UicOperateri WHERE SifraOperatera = '" & ipSifra1 & "'"
            Case "UicStanice"
                sqlText = "SELECT count(*) FROM UicStanice WHERE SifraStanice = '" & ipSifra1 & "'"
            Case Else
                poruka = "Procedure nije definisana za tabelu: " & ipTabela
        End Select
        If poruka = "" Then
            Dim uspKomanda As New SqlCommand(sqlText, cnWinRoba)
            Try
                If ipTrans Is Nothing Or cnWinRoba.State.Closed Then
                    cnWinRoba.Open()
                Else
                    uspKomanda.Transaction = ipTrans
                End If
                If uspKomanda.ExecuteScalar() > 0 Then opPovVrednost = True
            Catch SQLExp As SqlException
                poruka = SQLExp.Message
            Catch Exp As Exception
                poruka = Err.Description
            Finally
                If ipTrans Is Nothing Then cnWinRoba.Close()
                uspKomanda.Dispose()
            End Try
        Else
            opPovVrednost = False
            MsgBox(poruka, MsgBoxStyle.Exclamation, "Greška")
        End If
        Return opPovVrednost
    End Function


    'Ispituje postojanje sloga u bilo kojoj tabeli u bazi sa najvise 3 ulazna parametra i vraca String polje
    Public Sub sNadjiNaziv(ByVal ipTrans As SqlTransaction, ByVal ipTabela As String, ByVal ipSifra1 As String, ByVal ipSifra2 As String, ByVal ipSifra3 As String, ByRef opNaziv As String, ByRef opPovVrednost As String)
        opNaziv = ""
        opPovVrednost = ""
        Dim sqlText As String = ""

        Select Case ipTabela
            Case "UicOperateri"
                sqlText = "SELECT Naziv FROM UicOperateri WHERE SifraOperatera = '" & ipSifra1 & "'"
            Case "UicStanice"
                sqlText = "SELECT Naziv FROM UicStanice WHERE SifraStanice = '" & ipSifra1 & "'"
            Case Else
                opPovVrednost = "Procedure nije definisana za: " & ipTabela & " tabelu !!! , Greska u Programu"
        End Select

        If opPovVrednost = "" Then
            Dim uspKomanda As New SqlCommand(sqlText, cnWinRoba)
            Try
                If ipTrans Is Nothing Or cnWinRoba.State.Closed Then
                    cnWinRoba.Open()
                Else
                    uspKomanda.Transaction = ipTrans
                End If
                opNaziv = Trim(uspKomanda.ExecuteScalar)
                If IsDBNull(opNaziv) Or opNaziv = Nothing Then opPovVrednost = "Slog NE POSTOJI !" ' SLOG NE POSTOJI !!!
            Catch SQLExp As SqlException
                opPovVrednost = SQLExp.Message  'Greska - SQL greska
            Catch
                opPovVrednost = Err.Description  'Greska - bilo koja"
            Finally
                If ipTrans Is Nothing Then cnWinRoba.Close()
                uspKomanda.Dispose()
            End Try
        End If
    End Sub

    Public Function fNullUString(ByVal ipString As Object) As String
        Dim retVal As String
        If Not IsDBNull(ipString) Then retVal = ipString
        Return retVal
    End Function
    Public Function fNullUByte(ByVal ipString As Object) As Byte
        Dim retVal As Byte
        If Not IsDBNull(ipString) And IsNumeric(ipString) Then retVal = ipString
        Return retVal
    End Function
    Public Function fNullUInt16(ByVal ipString As Object) As Int16
        Dim retVal As Int16
        If Not IsDBNull(ipString) And IsNumeric(ipString) Then retVal = ipString
        Return retVal
    End Function
    Public Function fNullUInt32(ByVal ipString As Object) As Int32
        Dim retVal As Int32
        If Not IsDBNull(ipString) And IsNumeric(ipString) Then retVal = ipString
        Return retVal
    End Function
    Public Function fNullUDec(ByVal ipString As Object) As Decimal
        Dim retVal As Decimal
        If Not IsDBNull(ipString) And IsNumeric(ipString) Then retVal = ipString
        Return retVal
    End Function
    Public Function fNullUDate(ByVal ipString As Object) As Date
        Dim retVal As Date = Nothing
        If Not IsDBNull(ipString) And IsDate(ipString) Then retVal = ipString
        Return retVal
    End Function

    Public Function fRDRNullUString(ByVal rdr As SqlDataReader, ByVal broj As Int16) As String
        Dim retVal As String
        If Not rdr.IsDBNull(broj) Then retVal = Trim(rdr.GetString(broj))
        Return retVal
    End Function
    Public Function fRDRNullUDec(ByVal rdr As SqlDataReader, ByVal broj As Int16) As Decimal
        Dim retVal As Decimal
        If Not rdr.IsDBNull(broj) Then retVal = rdr.GetDecimal(broj)
        Return retVal
    End Function
    Public Function fRDRNullUTinyInt(ByVal rdr As SqlDataReader, ByVal broj As Int16) As Byte
        Dim retVal As Byte
        If Not rdr.IsDBNull(broj) Then retVal = rdr.GetByte(broj)
        Return retVal
    End Function
    Public Function fRDRNullUInt16(ByVal rdr As SqlDataReader, ByVal broj As Int16) As Int16
        Dim retVal As Int16
        If Not rdr.IsDBNull(broj) Then retVal = rdr.GetInt16(broj)
        Return retVal
    End Function
    Public Function fRDRNullUInt32(ByVal rdr As SqlDataReader, ByVal broj As Int16) As Int32
        Dim retVal As Int32
        If Not rdr.IsDBNull(broj) Then retVal = rdr.GetInt32(broj)
        Return retVal
    End Function
    Public Function fRDRNullUInt64(ByVal rdr As SqlDataReader, ByVal broj As Int16) As Int64
        Dim retVal As Int64
        If Not rdr.IsDBNull(broj) Then retVal = rdr.GetInt64(broj)
        Return retVal
    End Function
    Public Function fRDRNullUDate(ByVal rdr As SqlDataReader, ByVal broj As Int16) As Date
        Dim retVal As Date  ' = "#1.1.1#"
        If Not rdr.IsDBNull(broj) Then retVal = rdr.GetDateTime(broj)
        Return retVal
    End Function
    Public Function fRDRNullUBool(ByVal rdr As SqlDataReader, ByVal broj As Int16) As Boolean
        Dim retVal As Boolean '= False
        If Not rdr.IsDBNull(broj) Then retVal = rdr.GetBoolean(broj)
        Return retVal
    End Function

    'Popunjava DataTabelu iz baze podataka
    'Poziva se: sDataTablePuni(DataTable,"SQL SELECT naredba")  npr. sDataTablePuni(UicStanice, "SELECT SifraUprave AS SifraUprave , SifraStanice AS SifraStanice , Naziv AS Naziv FROM UicStanice")
    Public Sub sDataTablePuni(ByVal ipDataTable As DataTable, ByVal ipSQLText As String)
        Dim iiRowAffected As Integer = 0
        Try
            Dim da As New SqlDataAdapter(ipSQLText, cnWinRoba)
            ipDataTable.Clear()
            iiRowAffected = da.Fill(ipDataTable)
        Catch e As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Greška u Popunjavanju Data Tabele: " & ipDataTable.ToString)
        End Try
    End Sub

    Public Function fMEDInit(ByVal ipMED As Object, ByVal ipSelText As String, ByVal ipMask As String)
        Try
            ipMED.Mask = ""
            ipMED.SelText = ipSelText
            ipMED.Mask = ipMask
        Catch ex As Exception
            MsgBox("MaskEdit Control: " & ipMED.name.ToString & " - se ne može ispravno inicijalizirati", MsgBoxStyle.Critical, "Greška u programu")
        End Try
    End Function
    Public Function fMEDInit(ByVal ipMED As Object, ByVal ipSelTextMask As String)
        Dim jj As Int32 = Trim(ipSelTextMask).Length
        Dim ss As New String("_", jj)
        Try
            ipMED.Mask = ""
            ipMED.SelText = ss
            ipMED.Mask = ipSelTextMask
        Catch ex As Exception
            MsgBox("MaskEdit Control: " & ipMED.name.ToString & " - se ne može ispravno inicijalizirati", MsgBoxStyle.Critical, "Greška u programu")
        End Try
    End Function
    Public Sub sMEDSet(ByRef ipMED As Object, ByVal ipSelText As String)
        Try
            ipMED.SelStart = 0
            ipMED.SelLength = ipMED.MaxLength
            ipMED.SelText = ipSelText
        Catch ex As Exception
            MsgBox("MaskEdit Control: " & ipMED.name.ToString & " - se ne može ispravno inicijalizirati", MsgBoxStyle.Critical, "Greška u programu")
        End Try
    End Sub

    Public Function fMesecNaziv(ByVal ipMesecBroj As Int16) As String
        Dim retVal As String = ""
        Select Case ipMesecBroj
            Case 1
                retVal = "Januar"
            Case 2
                retVal = "Februar"
            Case 3
                retVal = "Mart"
            Case 4
                retVal = "April"
            Case 5
                retVal = "Maj"
            Case 6
                retVal = "Jun"
            Case 7
                retVal = "Jul"
            Case 8
                retVal = "Avgust"
            Case 9
                retVal = "Septembar"
            Case 10
                retVal = "Oktobar"
            Case 11
                retVal = "Novembar"
            Case 12
                retVal = "Decembar"
        End Select
        Return retVal
    End Function
    Public Function fDanNaziv(ByVal ipDanBroj As Int16) As String
        Dim retVal As String = ""
        Select Case ipDanBroj
            Case 1
                retVal = "Ponedeljak"
            Case 2
                retVal = "Utorak"
            Case 3
                retVal = "Sreda"
            Case 4
                retVal = "Cetvrtak"
            Case 5
                retVal = "Petak"
            Case 6
                retVal = "Subota"
            Case 7
                retVal = "Nedelja"
        End Select
        Return retVal
    End Function
End Module