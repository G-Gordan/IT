Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data.SqlClient
Module CarinaXML
    'Definicija primarnog kljuca za SlogKalk
    Dim pRecID As Int32
    Dim pStanica As String

    Dim xSekcija As String = ""
    Dim zagSaobracaj As String
    Dim zagStanica As String
    Dim zagOtpStanica As String
    Dim zagPrStanica As String
    Dim zagVrPos As String
    Dim zagUkupnoKola As Int32
    Dim zagCarStanica As String
    Dim zagCarPrimalacPIB As String
    Dim zagCarPrimalacNaziv As String
    Dim zagCarPrimalacSediste As String
    Dim zagCarPrimalacZemlja As String
    Dim zagCarValuta As String
    Dim zagCarFakturaIznos As Decimal
    Dim zagCarDokumenti As String
    Dim zagCarFakturaBroj As String
    Dim zagCarDatum As DateTime
    Dim zagCarAgent As String
    Dim zagCarKnjiga As String

    Dim kolaStavka As String = ""
    Dim kolaIBK As String = ""

    Friend Sub sPocetak(ByVal ipSifraOperatera As String, ByVal ipSifStanice As String, ByVal ipBroj As Int32, ByVal ipDatum As Date, ByRef opXMLFile As String, ByRef opPovVrednost As String)
        opPovVrednost = ""
        Dim dr As DataRow
        Dim slogTrans As SqlTransaction
        Try
            'Provera Input podataka
            If cnWinRoba.State.Open Then cnWinRoba.Close() 'Za slucaj da je veza ostala otvorena iz prosle aplikacije
            If Not CarinaUtil.fcvSlogPostoji(Nothing, "UicOperateri", ipSifraOperatera, "", "", "") Then Throw New System.Exception("Uic Operater: " & ipSifraOperatera & " - NE POSTOJI.")
            If Not CarinaUtil.fcvSlogPostoji(Nothing, "UicStanice", ipSifStanice, "", "", "") Then Throw New System.Exception("Otpravna Stanica: " & ipSifStanice & " - NE POSTOJI.")
            If ipBroj = Nothing Then Throw New System.Exception("Broj otpravljanja neispravan !")
            If ipDatum = Nothing Then Throw New System.Exception("Datum otpravljanja neispravan !")

            cnWinRoba.Open()
            slogTrans = cnWinRoba.BeginTransaction()

            sNadjiSlogKalkPrimKljuc(slogTrans, ipSifraOperatera, ipSifStanice, ipBroj, ipDatum, pRecID, pStanica, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)

            'Punjenje DataTable
            sPuniDataTable(slogTrans, pRecID, pStanica, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)

            'Citanje tabela i punjenje DataTable
            'ZAGLAVLJE
            sSlogKalkProcitaj(slogTrans, pRecID, pStanica, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)

            'NAIMENOVANJA
            sSlogRobaProcitaj(slogTrans, pRecID, pStanica, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)

            'POMOCNA
            sPomocna(slogTrans, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)

            'Documents - uvek ima samo dve sekcije, bez obzira na broj roba
            sDocuments(slogTrans, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)

            'Vehicle
            sSlogKolaProcitaj(slogTrans, pRecID, pStanica, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)

            'Kreiranje XML fajla
            'MsgBox("Broj Slogova u DT: " & VarDef.dt.Rows.Count)
            sXMLPisi(slogTrans, ipSifStanice, opXMLFile, opPovVrednost)
            If opPovVrednost = "" Then
                slogTrans.Commit()
            Else
                If File.Exists(opXMLFile) Then Kill(opXMLFile) 'Export neuspesan - obrisiJCL file
                Throw New System.Exception(opPovVrednost)
            End If
        Catch
            opPovVrednost = Err.Description
            slogTrans.Rollback()
        Finally
            cnWinRoba.Close()
        End Try
    End Sub
    Friend Sub sSlogKalkProcitaj(ByVal ipTrans As SqlTransaction, ByVal ipRecID As Int32, ByVal ipStanica As String, ByRef opPovVrednost As String)
        opPovVrednost = ""
        Dim xx As String = ""   'Nepoznata vrednost (tek se treba izracunati)
        Dim sqlComm As New SqlCommand("SELECT Saobracaj, Stanica, OtpStanica, PrStanica, VrPos, UkupnoKola, CarStanica, CarPrimalacPIB, CarPrimalacNaziv, CarPrimalacSediste, CarPrimalacZemlja, CarValuta, CarFaktura, CarBrojFakture, CarDokumenti, CarDatum , CarAgent, CarKnjiga FROM SlogKalk WHERE RecID = " & ipRecID & " AND Stanica = '" & ipStanica & "'", cnWinRoba)
        Dim rdr As SqlDataReader
        Try
            sqlComm.Transaction = ipTrans
            rdr = sqlComm.ExecuteReader()
            If rdr.Read() Then
                zagSaobracaj = CarinaUtil.fRDRNullUString(rdr, 0)
                zagStanica = CarinaUtil.fRDRNullUString(rdr, 1)
                zagOtpStanica = CarinaUtil.fRDRNullUString(rdr, 2)
                'If zagOtpStanica.Length > 5 Then zagOtpStanica = zagOtpStanica.Substring(2, 5)
                zagPrStanica = CarinaUtil.fRDRNullUString(rdr, 3)
                'If zagPrStanica.Length > 5 Then zagPrStanica = zagPrStanica.Substring(2, 5)
                zagVrPos = CarinaUtil.fRDRNullUString(rdr, 4)
                zagUkupnoKola = CarinaUtil.fRDRNullUInt32(rdr, 5)
                zagCarStanica = CarinaUtil.fRDRNullUString(rdr, 6)
                zagCarPrimalacPIB = CarinaUtil.fRDRNullUString(rdr, 7)
                zagCarPrimalacNaziv = CarinaUtil.fRDRNullUString(rdr, 8)
                zagCarPrimalacSediste = CarinaUtil.fRDRNullUString(rdr, 9)
                zagCarPrimalacZemlja = CarinaUtil.fRDRNullUString(rdr, 10)
                zagCarValuta = CarinaUtil.fRDRNullUString(rdr, 11)
                zagCarFakturaIznos = CarinaUtil.fRDRNullUDec(rdr, 12)
                zagCarFakturaBroj = CarinaUtil.fRDRNullUString(rdr, 13)
                zagCarDokumenti = CarinaUtil.fRDRNullUString(rdr, 14)
                zagCarDatum = CarinaUtil.fRDRNullUDate(rdr, 15)
                zagCarAgent = CarinaUtil.fRDRNullUString(rdr, 16)
                zagCarKnjiga = CarinaUtil.fRDRNullUString(rdr, 17)
            Else
                Throw New System.Exception("Slog Kalkulacije broj: " & ipRecID & " , za Stanicu: " & ipStanica & " - NE POSTOJI !")
            End If
        Catch
            opPovVrednost = "Greska u proceduri: ""sSlogKalkProcitaj 1""" & vbNewLine & vbNewLine & Err.Description
        Finally
            rdr.Close()
            sqlComm.Dispose()
        End Try

        If opPovVrednost = "" Then
            Try
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB1III", "I", zagSaobracaj, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB3I", "K", "1", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB3II", "K", "1", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB4", "K", "1", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB5", "K", "1", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB6", "I", zagVrPos, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB8Red1", "I", zagSaobracaj, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB8Red2", "K", zagCarPrimalacNaziv, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB8Red3Prvi", "K", zagCarPrimalacSediste, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB8Red3Drugi", "K", zagCarPrimalacZemlja, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB14Red1Prvi", "K", "N", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB14Red1Drugi", "K", "103859991", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB14Red2", "K", "Zeleznice Srbije", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB14Red3", "K", "Nemanjina 6, Beograd", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB15", "I", zagOtpStanica, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB15a", "I", zagOtpStanica, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB17", "I", zagPrStanica, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB17a", "I", zagPrStanica, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB18I", "I", zagUkupnoKola, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB18IDrugi", "I", zagUkupnoKola, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB18II", "I", zagUkupnoKola, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB19", "I", xx, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB22I", "K", zagCarValuta, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB22II", "K", Format(zagCarFakturaIznos, "###,###,##0.00"), opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB25", "K", "20", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB52II", "K", "0", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB53", "K", zagCarStanica, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUBARed1Drugi", "I", zagCarStanica, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUBARed2Prvi", "K", zagCarKnjiga, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "broj", "K", "2", opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB54Red1", "I", zagStanica, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                'Dim dd As String = Format(Day(zagCarDatum), "00") & "." & Format(Month(zagCarDatum), "00") & Format(Year(zagCarDatum), "0000")
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB54Red1Drugi", "K", Format(Day(zagCarDatum), "00") & "." & Format(Month(zagCarDatum), "00") & "." & Format(Year(zagCarDatum), "0000"), opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                sDtUpdate(ipTrans, "ZAGLAVLJE", 1, "RUB54Red2", "K", zagCarAgent, opPovVrednost)
                If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            Catch
                opPovVrednost = "Greska u proceduri: ""sSlogKalkProcitaj 2""" & vbNewLine & vbNewLine & Err.Description
            End Try
        End If
    End Sub
    Private Sub sSlogRobaProcitaj(ByVal ipTrans As SqlTransaction, ByVal ipRecID As Int32, ByVal ipStanica As String, ByRef opPovVrednost As String)
        'Od svih podataka potrebna nam je samo suma stvarne mase robe za odredjeni Tovarni List
        Dim ySMasaRobe As Int32 = 0
        Dim strSMasaRobe As String = ""
        opPovVrednost = ""
        Dim sqlComm As New SqlCommand("SELECT SUM(SMasa) FROM SlogRoba WHERE RecID = " & pRecID & " AND Stanica = '" & pStanica & "'", cnWinRoba)
        Try
            sqlComm.Transaction = ipTrans
            ySMasaRobe = Trim(sqlComm.ExecuteScalar)
            If IsDBNull(ySMasaRobe) Or ySMasaRobe = Nothing Then
                strSMasaRobe = "0.00"
            Else
                strSMasaRobe = Format(ySMasaRobe, "###,###,###0.00")
            End If
        Catch SQLExp As SqlException
            opPovVrednost = SQLExp.Message  'Greska - SQL greska
        Catch
            opPovVrednost = Err.Description  'Greska - bilo koja"
        Finally
            sqlComm.Dispose()
        End Try

        Try
            sDtUpdate(ipTrans, "NAIMENOVANJA", 1, "RUB31Red1Prvi", "K", "1", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "NAIMENOVANJA", 1, "RUB31Red1Drugi", "K", "po CIM-u", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "NAIMENOVANJA", 1, "RUB31Red2", "K", "po CIM-u", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "NAIMENOVANJA", 1, "RUB32", "K", "1", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "NAIMENOVANJA", 1, "RUB35", "K", strSMasaRobe, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "NAIMENOVANJA", 1, "RUB42", "K", Format(zagCarFakturaIznos, "###,###,##0.00"), opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "NAIMENOVANJA", 1, "RUB44", "K", zagCarDokumenti, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "NAIMENOVANJA", 1, "brojN", "K", "1", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
        Catch
            opPovVrednost = "Greska u proceduri: ""sSlogRobaProcitaj""" & vbNewLine & vbNewLine & Err.Description
        End Try
    End Sub
    Private Sub sPomocna(ByVal ipTrans As SqlTransaction, ByRef opPovVrednost As String)
        Try
            sDtUpdate(ipTrans, "POMOCNA", 1, "STATUS", "K", "TRANZIT", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
        Catch
            opPovVrednost = "Greska u proceduri: ""sPomocna""" & vbNewLine & vbNewLine & Err.Description
        End Try
    End Sub
    Private Sub sDocuments(ByVal ipTrans As SqlTransaction, ByRef opPovVrednost As String)
        Try
            sDtUpdate(ipTrans, "Documents", 1, "Rbr", "K", "1", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "Documents", 1, "Sifra", "K", "O05", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "Documents", 1, "BrNaim", "K", "0", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "Documents", 2, "Rbr", "K", "2", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "Documents", 2, "Sifra", "K", "F01", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "Documents", 2, "Orig_x0020_br_x0020_dokumenta", "I", zagCarDokumenti, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "Documents", 2, "Godina", "I", zagCarDokumenti, opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
            sDtUpdate(ipTrans, "Documents", 2, "BrNaim", "K", "0", opPovVrednost)
            If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
        Catch
            opPovVrednost = "Greska u proceduri: ""sDocuments""" & vbNewLine & vbNewLine & Err.Description
        End Try
    End Sub
    Private Sub sSlogKolaProcitaj(ByVal ipTrans As SqlTransaction, ByVal ipRecID As Int32, ByVal ipStanica As String, ByRef opPovVrednost As String)
        opPovVrednost = ""
        Dim yCarinaOznaka As String = ""
        Dim sqlComm As New SqlCommand("SELECT SlogKola.KolaStavka , SlogKola.IBK , UicUprave.CarinaOznaka FROM SlogKola , UicUprave WHERE SlogKola.RecID = " & ipRecID & " AND SlogKola.Stanica = '" & ipStanica & "' AND UicUprave.SifraUprave = SUBSTRING(SlogKola.IBK,3,2)", cnWinRoba)
        Dim rdr As SqlDataReader
        kolaStavka = 0
        kolaIBK = ""
        Try
            sqlComm.Transaction = ipTrans
            rdr = sqlComm.ExecuteReader()
            While rdr.Read()
                kolaStavka = CarinaUtil.fRDRNullUInt32(rdr, 0)
                kolaIBK = CarinaUtil.fRDRNullUString(rdr, 1)
                yCarinaOznaka = CarinaUtil.fRDRNullUString(rdr, 2)
                If kolaIBK.Length > 0 Then
                    sDtUpdate(ipTrans, "Vehicle", kolaStavka, "Rbr", "K", kolaStavka, opPovVrednost)
                    If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                    sDtUpdate(ipTrans, "Vehicle", kolaStavka, "RegBr", "K", kolaIBK.Substring(0, 10), opPovVrednost)
                    If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                    sDtUpdate(ipTrans, "Vehicle", kolaStavka, "RegPrik", "K", kolaIBK.Substring(10, 2), opPovVrednost)
                    If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                    sDtUpdate(ipTrans, "Vehicle", kolaStavka, "ZemljaReg", "K", yCarinaOznaka, opPovVrednost)
                    If opPovVrednost <> "" Then Throw New System.Exception(opPovVrednost)
                Else
                    Throw New System.Exception("Za Kola broj: " & ipRecID & " , za Stanicu: " & ipStanica & " i Stavku: " & kolaStavka & " - NIJE DEFINISAN ""IBK"" !")
                End If
            End While
        Catch
            opPovVrednost = "Greska u proceduri: ""sSlogKolaProcitaj""" & vbNewLine & vbNewLine & Err.Description
        Finally
            rdr.Close()
            sqlComm.Dispose()
        End Try
    End Sub

    ' 1. Naziv Sekcije  ;  2. Naziv reda  ;  3. Vrsta ("K" - konstanta , "I" - Izracunava se)  ;  4. Vrednost  ;  5. Povratna Vrednost
    Private Sub sDtUpdate(ByVal ipTrans As SqlTransaction, ByVal ipSekcija As String, ByVal ipIteracija As Byte, ByVal ipRed As String, ByVal ipVrsta As String, ByVal ipVrednost As String, ByRef opPovVrednost As String)
        Dim drs() As DataRow
        Dim yCarinaNaziv As String
        Dim yCarinaOznaka As String
        Dim yNHMPrvi As String
        Dim yDencanoUkupnoStavki As Int32
        Dim yZagStanicaNaziv As String
        Dim ySifraCarina As String
        Dim yNazivPrelaza As String
        Try
            drs = dt.Select("SekcijaNaziv = '" & ipSekcija & "' AND Iteracija = " & ipIteracija & " AND PoljeNaziv = '" & ipRed & "'", "SekcijaNaziv,Iteracija,PoljeNaziv")
            If drs.Length > 1 Then
                Throw New System.Exception("Više redova pronadjeno sa Sekcijom: " & ipSekcija & " i Redom: " & ipRed & " !")
            ElseIf drs.Length < 1 Then
                Throw New System.Exception("Nijedan red nije pronadjen sa Sekcijom: " & ipSekcija & " i Redom: " & ipRed & " !")
            Else
                If ipVrsta = "K" Then   'Konstanta
                    drs(0)("Vrednost") = ipVrednost
                Else                    '"I" - Izracinata vrednost
                    Select Case ipSekcija & ipRed
                        Case "ZAGLAVLJE" & "RUB1III"
                            If ipVrednost = "2" Then
                                drs(0)("Vrednost") = "TD"
                            ElseIf ipVrednost = "4" Then
                                drs(0)("Vrednost") = "TP"
                            End If
                        Case "ZAGLAVLJE" & "RUB6"
                            If ipVrednost = "D" Then
                                sDencanoUkupnoStavki(ipTrans, yDencanoUkupnoStavki, opPovVrednost)
                                If opPovVrednost = "" Then drs(0)("Vrednost") = yCarinaOznaka
                            Else
                                drs(0)("Vrednost") = "1"
                            End If
                        Case "ZAGLAVLJE" & "RUB8Red1"
                            If ipVrednost = "2" Then
                                drs(0)("Vrednost") = zagCarPrimalacPIB
                            ElseIf ipVrednost = "4" Then
                                drs(0)("Vrednost") = "000912000"
                            End If
                        Case "ZAGLAVLJE" & "RUB15"
                            sNadjiUicUpravu(ipTrans, ipVrednost, yCarinaNaziv, yCarinaOznaka, opPovVrednost)
                            If opPovVrednost = "" Then drs(0)("Vrednost") = yCarinaNaziv
                        Case "ZAGLAVLJE" & "RUB15a"
                            sNadjiUicUpravu(ipTrans, ipVrednost, yCarinaNaziv, yCarinaOznaka, opPovVrednost)
                            If opPovVrednost = "" Then drs(0)("Vrednost") = yCarinaOznaka
                        Case "ZAGLAVLJE" & "RUB17"
                            sNadjiUicUpravu(ipTrans, ipVrednost, yCarinaNaziv, yCarinaOznaka, opPovVrednost)
                            If opPovVrednost = "" Then drs(0)("Vrednost") = yCarinaNaziv
                        Case "ZAGLAVLJE" & "RUB17a"
                            sNadjiUicUpravu(ipTrans, ipVrednost, yCarinaNaziv, yCarinaOznaka, opPovVrednost)
                            If opPovVrednost = "" Then drs(0)("Vrednost") = yCarinaOznaka
                        Case "ZAGLAVLJE" & "RUB18I"
                            If ipVrednost = 1 Then
                                sNadjiKolaIBK(ipTrans, pRecID, pStanica, kolaIBK, opPovVrednost)
                                If opPovVrednost = "" Then If kolaIBK <> "" Then drs(0)("Vrednost") = kolaIBK.Substring(0, 10)
                            Else
                                drs(0)("Vrednost") = "specifikacija"
                            End If
                        Case "ZAGLAVLJE" & "RUB18IDrugi"
                            If ipVrednost = 1 And kolaIBK <> "" Then drs(0)("Vrednost") = kolaIBK.Substring(10, 2)
                        Case "ZAGLAVLJE" & "RUB18II"
                            If ipVrednost = 1 And Not kolaIBK = Nothing Then
                                sNadjiUicUpravu(ipTrans, kolaIBK.Substring(2, 2), yCarinaNaziv, yCarinaOznaka, opPovVrednost)
                                If opPovVrednost = "" Then drs(0)("Vrednost") = yCarinaOznaka
                            End If
                        Case "ZAGLAVLJE" & "RUB19"
                            sNadjiSlogRobaPrvi(ipTrans, yNHMPrvi, opPovVrednost)
                            If opPovVrednost = "" Then
                                If (yNHMPrvi.Substring(0, 4) = "9941" Or yNHMPrvi.Substring(0, 4) = "9931") Then
                                    drs(0)("Vrednost") = 1
                                Else
                                    drs(0)("Vrednost") = 0
                                End If
                            End If
                        Case "ZAGLAVLJE" & "RUBARed1Drugi"
                                sNadjiZSPrelaz(ipTrans, pStanica, ySifraCarina, yNazivPrelaza, opPovVrednost)
                                If opPovVrednost = "" Then drs(0)("Vrednost") = ySifraCarina
                        Case "ZAGLAVLJE" & "RUB54Red1"
                                sNadjiZSPrelaz(ipTrans, pStanica, ySifraCarina, yNazivPrelaza, opPovVrednost)
                                If opPovVrednost = "" Then drs(0)("Vrednost") = yNazivPrelaza

                        Case "Documents" & "Orig_x0020_br_x0020_dokumenta"
                                If IsNumeric(zagCarFakturaIznos) Then
                                    If zagCarFakturaIznos = 1 Then  'kada je faktura 1.00 ==> znaci da NEMA FAKTURE
                                        drs(0)("Vrednost") = "nema fakture"
                                    Else
                                        '                              0123456789012345678901234567890
                                        'String iz koga se racuna je: "(O01)/(F01)(broj_fakture ) (godina )" - broj 12 je pocetno mesto broja fakture
                                        'If ipVrednost <> Nothing And ipVrednost.Length > 12 Then drs(0)("Vrednost") = ipVrednost.Substring(12, ipVrednost.IndexOf(" ") - 12)
                                        drs(0)("Vrednost") = zagCarFakturaBroj      'Uvedeno je novo polje u SlogKalk.CarBrojFakture
                                    End If
                                End If
                        Case "Documents" & "Godina"
                                If IsNumeric(zagCarFakturaIznos) And zagCarFakturaIznos = 1 Then  'kada je faktura 1.00 ==> znaci da NEMA FAKTURE
                                    drs(0)("Vrednost") = System.DBNull.Value
                                Else
                                    'String iz koga se racuna je: "(O01)/(F01)(broj_fakture ) (godina )" - posto je broj fakture varijabilne duzine, godina se racuna sa desne strane - od kraja
                                    If ipVrednost <> Nothing And ipVrednost.Length > 12 Then drs(0)("Vrednost") = ipVrednost.Substring(ipVrednost.Length - 6, 4)
                                End If
                    End Select
                End If
            End If
        Catch
            opPovVrednost = "Greska u proceduri: ""sDtUpdate"", Sekciji: """ & ipSekcija & """ i Redu: """ & ipRed & """" & vbNewLine & vbNewLine & Err.Description
        End Try
    End Sub

    Private Sub sXMLPisi(ByVal ipTrans As SqlTransaction, ByVal ipSifStanice As String, ByRef opXMLFileName As String, ByRef opPovVrednost As String)
        Dim iiKolaStavki As Byte = 0
        Dim dr As DataRow
        Dim drs() As DataRow
        Dim yLinija As String = ""
        opXMLFileName = Format(Year(Today), "0000") & Format(Month(Today), "00") _
                    & Format(Day(Today), "00") & "_" & Format(Hour(Today.Now), "00") _
                    & Format(Minute(Today.Now), "00") & Format(Second(Today.Now), "00") _
                    & "_" & zagCarKnjiga & ".jci"
        If Not VarDef.cCarinaApplParProcitani Then sApplParProcitaj(ipTrans, opPovVrednost)
        If opPovVrednost = "" Then
            Try
                'Ako ima samo jedna kola onda brisemo u potpunosti sekciju 'Vehicle' - a podatak iz SlokKalk.UkupnoKola za sada je NEPOUZDAN !
                Dim sqlComm2 As New SqlCommand("SELECT count(*) FROM SlogKola WHERE RecID = " & pRecID & " AND Stanica = '" & pStanica & "'", cnWinRoba)
                sqlComm2.Transaction = ipTrans
                iiKolaStavki = Trim(sqlComm2.ExecuteScalar)
                If iiKolaStavki <= 1 Then
                    drs = dt.Select("SekcijaNaziv = 'Vehicle'")
                    For Each dr In drs
                        dt.Rows.Remove(dr)
                    Next
                End If

                opXMLFileName = VarDef.cCarinaDirZaSlanje & "\" & opXMLFileName
                FileOpen(1, opXMLFileName, OpenMode.Output, OpenAccess.Write)
                drs = dt.Select(Nothing, "RedosledXML ASC , Iteracija ASC , PoljeRedBr ASC", DataViewRowState.CurrentRows)
                For Each dr In drs
                    sXMLPopuniRed(dr, yLinija, opPovVrednost)
                    If opPovVrednost <> "" Then Throw New System.Exception("GRESKA,  " & opPovVrednost)
                    If yLinija.Length > 0 Then PrintLine(1, yLinija)
                    'PrintLine(1, dr("SekcijaNaziv") & vbTab & dr("Iteracija") & vbTab & dr("PoljeRedBr") & vbTab & dr("PoljeNaziv"))
                Next

            Catch
                opPovVrednost = "Greska u proceduri: ""sXMLPisi""" & vbNewLine & vbNewLine & Err.Description
            Finally
                FileClose()
            End Try
        End If
    End Sub
    Private Sub sXMLPopuniRed(ByVal ipDR As DataRow, ByRef opLinija As String, ByRef opPovVrednost As String)
        opLinija = ""
        opPovVrednost = ""
        Try
            Select Case ipDR("SekcijaNaziv")
                Case "POCETAK"
                    If ipDR("PoljeRedBr") > 0 Then
                        opLinija = ipDR("Vrednost")
                    End If
                Case "KRAJ"
                    If ipDR("PoljeRedBr") > 0 Then
                        opLinija = ipDR("Vrednost")
                    End If
                Case Else
                    If IsDBNull(ipDR("PoljeNaziv")) Or Trim(ipDR("PoljeNaziv")) = "" Then     'Prvi i zadnji red u sekciji
                        If ipDR("PoljeRedBr") = 0 Then  'Prvi red u sekciji
                            opLinija = vbTab & VarDef.fXML(ipDR("SekcijaNaziv"), "P")
                        Else                            'Zadnji red u sekciji
                            opLinija = vbTab & VarDef.fXML(ipDR("SekcijaNaziv"), "K")
                        End If
                    Else                                'Ostala polja u sekciji
                        If IsDBNull(ipDR("Vrednost")) Then  'Vrednost polja je NULL
                            opLinija = vbTab & vbTab & VarDef.fXML(ipDR("PoljeNaziv"), "N")
                        Else                                'Polje ima neku vrednost - makar i prazno
                            opLinija = vbTab & vbTab & VarDef.fXML(ipDR("PoljeNaziv"), "P") & ipDR("Vrednost") & VarDef.fXML(ipDR("PoljeNaziv"), "K")
                        End If
                    End If
            End Select
        Catch
            opLinija = ""
            opPovVrednost = "Greska u proceduri: ""sXMLPopuniRed"", Sekciji: " & ipDR("SekcijaNaziv") & " i redu " & ipDR("PoljeNaziv") & vbNewLine & vbNewLine & Err.Description
        End Try
    End Sub
    Private Sub sNadjiUicUpravu(ByVal ipTrans As SqlTransaction, ByVal ipUprava As String, ByRef opCarinaNaziv As String, ByRef opCarinaOznaka As String, ByRef opPovVrednost As String)
        opCarinaNaziv = ""
        opCarinaOznaka = ""
        opPovVrednost = ""
        Dim rdr As SqlDataReader
        Try
            Dim sqlComm As New SqlCommand("SELECT CarinaNaziv , CarinaOznaka FROM UicUprave WHERE SifraUprave = '" & ipUprava.Substring(0, 2) & "'", cnWinRoba)
            sqlComm.Transaction = ipTrans
            rdr = sqlComm.ExecuteReader()
            If rdr.Read() Then
                opCarinaNaziv = CarinaUtil.fRDRNullUString(rdr, 0)
                opCarinaOznaka = CarinaUtil.fRDRNullUString(rdr, 1)
            End If
        Catch SQLExp As SqlException
            opPovVrednost = "Greska u proceduri: ""sNadjiUicUpravu""" & vbNewLine & vbNewLine & SQLExp.Message  'Greska - SQL greska
        Catch
            opPovVrednost = "Greska u proceduri: ""sNadjiUicUpravu""" & vbNewLine & vbNewLine & Err.Description  'Greska - bilo koja"
        Finally
            rdr.Close()
            'sqlComm.Dispose()
        End Try
    End Sub
    Private Sub sNadjiZSPrelaz(ByVal ipTrans As SqlTransaction, ByVal ipSifStanice As String, ByRef opSifraCarina As String, ByRef opNazivPrelaza As String, ByRef opPovVrednost As String)
        opSifraCarina = ""
        opNazivPrelaza = ""
        opPovVrednost = ""
        Dim rdr As SqlDataReader
        Try
            Dim sqlComm As New SqlCommand("SELECT SifraCarina , Naziv FROM ZSPrelazi WHERE SifraPrelaza = '" & ipSifStanice & "'", cnWinRoba)
            sqlComm.Transaction = ipTrans
            rdr = sqlComm.ExecuteReader()
            If rdr.Read() Then
                opSifraCarina = CarinaUtil.fRDRNullUString(rdr, 0)
                opNazivPrelaza = CarinaUtil.fRDRNullUString(rdr, 1)
            End If
        Catch SQLExp As SqlException
            opPovVrednost = "Greska u proceduri: ""sNadjiZSPrelaz""" & vbNewLine & vbNewLine & SQLExp.Message  'Greska - SQL greska
        Catch
            opPovVrednost = "Greska u proceduri: ""sNadjiZSPrelaz""" & vbNewLine & vbNewLine & Err.Description  'Greska - bilo koja"
        Finally
            rdr.Close()
            'sqlComm.Dispose()
        End Try
    End Sub
    Private Sub sNadjiKolaIBK(ByVal ipTrans As SqlTransaction, ByVal ipRecID As Int32, ByVal ipStanica As String, ByRef opKolaIBK As String, ByRef opPovVrednost As String)
        opPovVrednost = ""
        Dim sqlComm As New SqlCommand("SELECT TOP 1 IBK FROM SlogKola WHERE RecID = " & ipRecID & " AND Stanica = '" & ipStanica & "'", cnWinRoba)
        Try
            sqlComm.Transaction = ipTrans
            opKolaIBK = sqlComm.ExecuteScalar
            If IsDBNull(opKolaIBK) Then Throw New System.Exception("Slog Kola broj: " & ipRecID & " , za Stanicu: " & ipStanica & " - NE POSTOJI !")
        Catch
            opPovVrednost = "Greska u proceduri: ""sNadjiKolaIBK""" & vbNewLine & vbNewLine & Err.Description
        Finally
            sqlComm.Dispose()
        End Try
    End Sub
    Private Sub sNadjiSlogRobaPrvi(ByVal ipTrans As SqlTransaction, ByRef opNHM4 As String, ByRef opPovVrednost As String)
        opNHM4 = ""
        opPovVrednost = ""
        Dim sqlComm As New SqlCommand("SELECT TOP 1 NHM FROM SlogRoba WHERE RecID = " & pRecID & " AND Stanica = '" & pStanica & "'", cnWinRoba)
        Try
            sqlComm.Transaction = ipTrans
            opNHM4 = Trim(sqlComm.ExecuteScalar)
            If IsDBNull(opNHM4) Then Throw New System.Exception("Prvi Slog Roba broj: " & pRecID & " , za Stanicu: " & pStanica & " - NE POSTOJI !")
        Catch SQLExp As SqlException
            opPovVrednost = "Greska u proceduri: ""sNadjiSlogRobaPrvi""" & vbNewLine & vbNewLine & SQLExp.Message  'Greska - SQL greska
        Catch
            opPovVrednost = "Greska u proceduri: ""sNadjiSlogRobaPrvi""" & vbNewLine & vbNewLine & Err.Description  'Greska - bilo koja"
        Finally
            'sqlComm.Dispose()
        End Try
    End Sub

    Private Sub sNadjiSlogKalkPrimKljuc(ByVal ipTrans As SqlTransaction, ByVal ipSifraOperatera As String, ByVal ipOtpStanica As String, ByVal ipOtpBroj As Int32, ByVal ipOtpDatum As Date, ByRef opRecID As Int32, ByRef opStanica As String, ByRef opPovVrednost As String)
        opPovVrednost = ""
        Dim xOtpDatum As String = Format(Month(ipOtpDatum), "00") & "." & Format(Day(ipOtpDatum), "00") & "." & Format(Microsoft.VisualBasic.Year(ipOtpDatum), "0000")
        Dim sqlText As String = "SELECT RecID , Stanica FROM SlogKalk WHERE OtpUprava = '" & ipSifraOperatera & "' AND OtpStanica = '" & ipOtpStanica & "' AND OtpBroj = " & ipOtpBroj & " AND OtpDatum = '" & xOtpDatum & "'"
        Dim rdr As SqlDataReader
        Try
            Dim sqlComm As New SqlCommand(sqlText, cnWinRoba)
            sqlComm.Transaction = ipTrans
            rdr = sqlComm.ExecuteReader()
            If rdr.Read() Then
                opRecID = CarinaUtil.fRDRNullUInt32(rdr, 0)
                opStanica = CarinaUtil.fRDRNullUString(rdr, 1)
            Else
                Throw New System.Exception("Slog Kalkulacije NIJE PRONADJEN !")
            End If
        Catch SQLExp As SqlException
            opPovVrednost = "Greska u proceduri: ""sNadjiSlogKalkPrimKljuc""" & vbNewLine & vbNewLine & SQLExp.Message  'Greska - SQL greska
        Catch
            opPovVrednost = "Greska u proceduri: ""sNadjiSlogKalkPrimKljuc""" & vbNewLine & vbNewLine & Err.Description  'Greska - bilo koja"
        Finally
            rdr.Close()
            'sqlComm.Dispose()
        End Try
    End Sub
    Private Sub sDencanoUkupnoStavki(ByVal ipTrans As SqlTransaction, ByRef opDencanoUkupnoStavki As Int32, ByRef opPovVrednost As String)
        opDencanoUkupnoStavki = 0
        opPovVrednost = ""
        If opPovVrednost = "" Then
            Dim sqlComm As New SqlCommand("SELECT count(*) FROM SlogDencane WHERE RecID = " & pRecID & " AND Stanica = '" & pStanica & "'", cnWinRoba)
            Try
                sqlComm.Transaction = ipTrans
                opDencanoUkupnoStavki = Trim(sqlComm.ExecuteScalar)
                If IsDBNull(opDencanoUkupnoStavki) Then opPovVrednost = "Slog NE POSTOJI !"
            Catch SQLExp As SqlException
                opPovVrednost = "Greska u proceduri: ""sDencanoUkupnoStavki""" & vbNewLine & vbNewLine & SQLExp.Message  'Greska - SQL greska
            Catch
                opPovVrednost = "Greska u proceduri: ""sDencanoUkupnoStavki""" & vbNewLine & vbNewLine & Err.Description  'Greska - bilo koja"
            Finally
                'sqlComm.Dispose()
            End Try
        End If
    End Sub
    Private Sub sNadjiNazivUicStanice(ByVal ipTrans As SqlTransaction, ByRef ipSifStanice As String, ByRef opNaziv As String, ByRef opPovVrednost As String)
        opNaziv = ""
        opPovVrednost = ""
        If opPovVrednost = "" Then
            Dim sqlComm As New SqlCommand("SELECT Naziv FROM UicStanice WHERE SifraStanice = '" & ipSifStanice & "'", cnWinRoba)
            Try
                sqlComm.Transaction = ipTrans
                opNaziv = Trim(sqlComm.ExecuteScalar)
                If IsDBNull(opNaziv) Then opPovVrednost = "Uic Stanica sa brojem: " & ipSifStanice & " - NE POSTOJI !"
            Catch SQLExp As SqlException
                opPovVrednost = "Greska u proceduri: ""sNadjiNazivUicStanice""" & vbNewLine & vbNewLine & SQLExp.Message  'Greska - SQL greska
            Catch
                opPovVrednost = "Greska u proceduri: ""sNadjiNazivUicStanice""" & vbNewLine & vbNewLine & Err.Description  'Greska - bilo koja"
            Finally
                'sqlComm.Dispose()
            End Try
        End If
    End Sub
    Private Sub sApplParProcitaj(ByVal ipTrans As SqlTransaction, ByRef opPovVrednost As String)
        CarinaUtil.sNadjiApplPar(ipTrans, "CARINA-DIR", VarDef.cCarinaDir, opPovVrednost)
        If opPovVrednost = "" Then
            CarinaUtil.sNadjiApplPar(ipTrans, "CARINA-DIR-ZASLANJE", VarDef.cCarinaDirZaSlanje, opPovVrednost)
            If opPovVrednost = "" Then
                CarinaUtil.sNadjiApplPar(ipTrans, "CARINA-DIR-POSLATO", VarDef.cCarinaDirPoslato, opPovVrednost)
            End If
        End If
    End Sub
    Private Sub sPuniDataTable(ByVal ipTrans As SqlTransaction, ByVal ipRecID As Int32, ByVal ipStanica As String, ByRef opPovVrednost As String)
        opPovVrednost = ""
        Dim ii As Int16 = 0
        'Dim iiRobaStavki As Int16 = 0
        Dim iiKolaStavki As Int16 = 0
        Dim dtRow As DataRow
        Dim xRedosledXML As Byte
        Dim xSekcijaNaziv As String
        Dim xIteracija As Byte
        Dim xPoljeRedBr As Int16
        Dim xPoljeNaziv As String
        Dim xVrednost As String
        Dim rdr As SqlDataReader
        Try
            VarDef.dt.Clear()

            'Dim sqlComm1 As New SqlCommand("SELECT count(*) FROM SlogRoba WHERE RecID = " & ipRecID & " AND Stanica = '" & ipStanica & "'", cnWinRoba)
            'sqlComm1.Transaction = ipTrans
            'iiRobaStavki = Trim(sqlComm1.ExecuteScalar)
            'If iiRobaStavki = 0 Then iiRobaStavki = 1

            Dim sqlComm2 As New SqlCommand("SELECT count(*) FROM SlogKola WHERE RecID = " & ipRecID & " AND Stanica = '" & ipStanica & "'", cnWinRoba)
            sqlComm2.Transaction = ipTrans
            iiKolaStavki = Trim(sqlComm2.ExecuteScalar)
            If iiKolaStavki = 0 Then iiKolaStavki = 1

            Dim sqlComm3 As New SqlCommand("SELECT RedosledXML , SekcijaNaziv , Iteracija , PoljeRedBr , PoljeNaziv , Vrednost FROM CarinaXML WHERE Iteracija = 1", cnWinRoba)
            sqlComm3.Transaction = ipTrans
            rdr = sqlComm3.ExecuteReader()
            While rdr.Read()
                xRedosledXML = CarinaUtil.fRDRNullUTinyInt(rdr, 0)
                xSekcijaNaziv = CarinaUtil.fRDRNullUString(rdr, 1)
                xIteracija = CarinaUtil.fRDRNullUTinyInt(rdr, 2)
                xPoljeRedBr = CarinaUtil.fRDRNullUInt16(rdr, 3)
                xPoljeNaziv = CarinaUtil.fRDRNullUString(rdr, 4)
                xVrednost = CarinaUtil.fRDRNullUString(rdr, 5)
                'If xSekcijaNaziv = "NAIMENOVANJA" Then
                '    For ii = 1 To iiRobaStavki
                '        dtRow = VarDef.dt.NewRow
                '        VarDef.dt.Rows.Add(New Object() {xRedosledXML, xSekcijaNaziv, ii, xPoljeRedBr, xPoljeNaziv, IIf(xVrednost = Nothing, System.DBNull.Value, xVrednost)})
                '    Next
                If xSekcijaNaziv = "Documents" Then
                    For ii = 1 To 2 'iiRobaStavki
                        dtRow = VarDef.dt.NewRow
                        VarDef.dt.Rows.Add(New Object() {xRedosledXML, xSekcijaNaziv, ii, xPoljeRedBr, xPoljeNaziv, IIf(xVrednost = Nothing, System.DBNull.Value, xVrednost)})
                    Next
                ElseIf xSekcijaNaziv = "Vehicle" Then
                    For ii = 1 To iiKolaStavki
                        dtRow = VarDef.dt.NewRow
                        VarDef.dt.Rows.Add(New Object() {xRedosledXML, xSekcijaNaziv, ii, xPoljeRedBr, xPoljeNaziv, IIf(xVrednost = Nothing, System.DBNull.Value, xVrednost)})
                    Next
                Else
                    dtRow = VarDef.dt.NewRow
                    VarDef.dt.Rows.Add(New Object() {xRedosledXML, xSekcijaNaziv, 1, xPoljeRedBr, xPoljeNaziv, IIf(xVrednost = Nothing, System.DBNull.Value, xVrednost)})
                End If
            End While
        Catch
            opPovVrednost = "Greska u proceduri: ""sPuniDataTable""" & vbNewLine & vbNewLine & Err.Description
        Finally
            rdr.Close()
        End Try
        VarDef.dt.PrimaryKey = New DataColumn() {VarDef.dt.Columns("RedosledXML"), VarDef.dt.Columns("Iteracija"), VarDef.dt.Columns("PoljeRedBr")}
    End Sub
End Module