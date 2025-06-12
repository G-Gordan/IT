Imports System.Data.SqlClient
Module KalkModulKatarina
    Public Sub bNadjiPrevozninuROKP(ByRef kPrevoznina As Decimal, ByRef kPovVrROKP As String)
        Dim KolaRed As DataRow
        Dim UicRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, Serija As String
        Dim NHM, UTINhm, Uprava As String
        Dim Aneks As Integer
        Dim BrOsovina As Byte
        Dim MasaTemp As Integer
        Dim RacMasaPoKolima As Integer
        Dim RacMasaPoKolimaTone As Decimal
        Dim PrevozninaPoKolima As Decimal
        Dim VozarinskiStav As Decimal
        Dim PrevozninaPoUg, PrevozninaZaVoz As Decimal
        Dim kPV, kPovVr, kPovVred, kPovratnaVred As String
        Dim kNhm, kNhmSif As String
        Dim Pojed As Decimal
        Dim Grupa As Decimal
        Dim Voz As Decimal
        Dim IznosMinPrev As Decimal
        Dim Prevoznina As Decimal
        Dim PrevozninaPoUgP, PrevozninaPoUgG, PrevozninaPoUgV As Decimal
        Dim BrAneksa As Integer
        Dim kTonskiStav As String
        Dim TipUTI As String
        Dim kNacinObrac As Integer
        Dim kStavka As Integer
        Dim kStavkaSt As Integer
        Dim Status As String
        Dim kStatus As String = "T"
        Dim kSifraKor As Integer
        Dim kUprava As String
        Dim OdStan, DoStan As String
        Dim kStanica1, kStanica2 As String
        Dim UkupnoKola As Byte
        Dim kIzlMasa As Integer
        Dim kSifraSt As String
        Dim PrevozninaOsPrit As Decimal = 0
        Dim OsPr As String
        Dim i, j, k, l, m As Integer
        Dim Ug_Greska As String = "N"
        Dim Upit0 As String
        Dim Upit1 As String
        Dim Upit2 As String
        Dim UpitTP As String
        Dim UpitJ As String


        '   bNadjiPrevozninuRO  -   "cist" obracun po tarifi, nema KP ugovora;
        '   bNadjiPrevozninuKP  -   obracun kod ugovora sa kom. povlasticama;
        '
        '           u ovom slucaju, uopsteno, kalkulacija se vrsi na dva nacina:
        '           1.  -   jednostavniji i "cistiji"   - ceo nacin kalkulacije je dat u ugovoru,
        '                   pa se cene iz redovne tarife ni ne konsultuju, eventualno se, u zavisnosti
        '                   od ugovora, primenjuje neki od uslova iz redovne tarife - zavisnost od tipa
        '                   kola, naknade itd.
        '           2.  -   kod ovih KP ugovora "preplicu" se redovna tarifa i sam KP ugovor; neophodno
        '                   je iskalkulisati troskove po redovnoj tarifi, pa na njih primeniti uslove
        '                   iz KP ugovora;
        '           
        '           Na osnovu podataka unetih na pocetnim panelima iz baze se ucitaju parametri vezani
        '               za odgovarajuci ugovor i odgovarajuci aneks.
        '           
        '           Pre kalkulacije posebnom procedurom se proveri 
        '               da li podaci iz tovarnog lista zadovoljavaju uslove ugovora
        '
        '           - Na osnovu vrste cene odredjuje se nacin kalkulacije; 
        '           - vrsta cene mora da bude JEDNOZNACNA:
        '           1. povlastica na redovni tarifu        K: OVO SE NE PRIMENJUJE (VALJDA)
        '           2. cena po toni                        K: URADJENO
        '           3. cena po tonskom stavu ( date su cene za 10-to tonski stav, 15-to tonski stav, ... ) K: URADJENO DELIMICNO (poziva samo poslednju stavku)
        '           4. cena po kolima                      K: URADJENO  
        '           5. cena za UTI - univerzalno           K: OVO JE OBUHVACENO 6.-icom
        '           6. cena za UTI - kombinacije           K: URADJENO 
        '           7. cena po vozu                        K: URADJENO ? (da li je to to)
        '           1. - 6. - radi se  kroz petlje po kolima i robi;
        '               u petlji po kolima za svaka kola se trazi min. prevoznina (NadjiSveIzZSKoefPos)
        '               iz ugovora se vidi kako se min. prevoznina tretira ( "vrsta" min prevoznine )
        '           1. povlastica na redovni tarifu
        '               nadje se prevoznina po redovnoj tarifi i mnozi povlasticom iz ugovora;
        '               uzme se u obzir i koeficijent za tip kola
        '               zaokruzi se i uporedi sa minimalnom prevozninom
        '           2. cena po toni
        '               kroz petlje po kolima i robi nadje se racunska masa
        '               cena po toni se mnozi ukupnom racunskom masom, 
        '               uzme se u obzir i koeficijent za tip kola
        '               zaokruzi se i uporedi sa minimalnom prevozninom
        '           3. cena po tonskom stavu
        '               radi se potpuno isto kao 1. , ali se cene za pojedine tonske stavove uzimaju
        '               iz ugovora, a ne iz redovne tarife
        '           4. cena po kolima
        '               u petlji po kolima se cena po kolima mnozi koeficijentom za tip kola
        '               i uporedjuju za min. prevozninom ( u zavisnosti od "vrste" min. prevoznine )
        '               moze da se desi da se cena po kolima samo mnozi ukupnim brojem kola
        '           5. cena za UTI - univerzalno
        '               u petlji po kolima se cena po kolima dobija tako sto se u zavisnosti od
        '               duzine kontejnera nadje cena po kontejneru i sabira po kolima;
        '               zatim se mnozi koeficijentom za tip kola i posle zaokruzivanja uporedjuje
        '               sa min. prevozninom ( u zavisnosti od "vrste" min. prevoznine )
        '           6. cena za UTI - kombinacije
        '               u petlji po kolima posebnom procedurom se nadje vrsta kombinacije kontejnera,
        '               iz ugovora se nadje sena za odgovarajucu kombinaciju;
        '               zatim se mnozi koeficijentom za tip kola i posle zaokruzivanja uporedjuje
        '               sa min. prevozninom ( u zavisnosti od "vrste" min. prevoznine )
        '           7. cena po vozu
        '               cena posiljke je data cenom po vozu iz ugovora i, uglavnom, nema
        '               uzimanja u obzir koficijenata za tip kola i min. prevoznine
        '
        '
        ' -----------------------------------------
        'mVrstaObracuna = "RO"
        Dim NhmRoba As DataRow
        For Each NhmRoba In dtNhm.Rows
            If Microsoft.VisualBasic.Left(NhmRoba.Item("NHM"), 4) = "9921" Or Microsoft.VisualBasic.Left(NhmRoba.Item("NHM"), 4) = "9922" Then
                kStatus = "P"
            Else
                kStatus = "T"
            End If
        Next

        kPrevoznina = 0
        If dtKola.Rows.Count > 0 Then
            'RedniBroj = 0
            For Each KolaRed In dtKola.Rows    ' petlja po kolima
                ' ucitavanje polja
                'dodeliti vrednosti za promenljive
                IBK = KolaRed.Item("IndBrojKola")
                kVrsta = KolaRed.Item("Vrsta")     ' 1 - obicna,  2 - specijalna
                kTipKola = Left(KolaRed.Item("Tip"), 1)
                kVlasn = KolaRed.Item("Vlasnik")
                kBrOsov = KolaRed.Item("Osovine")
                kSer = KolaRed.Item("Serija")

                '' za svaki sluèaj'
                'mOtpUprava = tbUpravaOtp.Text
                'mOtpStanica = tbStanicaOtp.Text
                'mPrUprava = tbUpravaPr.Text
                'mPrStanica = tbStanicaPr.Text
                ''bStitna = KolaRed.Item("Stitna")
                ''$$$
                If kVrsta = "O" Then
                    kVrsta = 1
                End If
                If kVrsta = "S" Then
                    kVrsta = 2
                End If
                '$$$
                ' Nadji tip kola i Koeficijent za tip kola   KolKoef
                'povratak praznih kola
                Dim mOtpStP As String
                Dim mPrStP As String
                'dodato 9.4.'08
                Dim intCounterTP As Integer
                Dim daTP As SqlClient.SqlDataAdapter
                Dim dsTP As New Data.DataSet
                Dim objCommTP As SqlClient.SqlCommand
                UpitTP = "SELECT  BrojUgovora, Status " & _
                                        "FROM dbo.UgKp_Tip5 " & _
                                        "WHERE BrojUgovora = '" & mBrojUg & "' "

                objCommTP = New SqlClient.SqlCommand(UpitTP, DbVeza)
                If DbVeza.State = ConnectionState.Closed Then
                    DbVeza.Open()
                End If
                'objCommTP.Connection.Open()
                daTP = New SqlClient.SqlDataAdapter(UpitTP, DbVeza)
                daTP.Fill(dsTP)

                With dsTP.Tables(0)
                    'k = 0
                    For intCounterTP = 0 To .Rows.Count - 1
                        Status = .Rows(intCounterTP).Item("Status")
                        If kStatus = Status Then
                            Exit For
                        End If
                    Next
                End With
                If kTipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If

                If IzborSaobracaja = 2 Then
                    kOtpUprava = Microsoft.VisualBasic.Left(mOtpStanica, 2)
                ElseIf IzborSaobracaja = 3 Then
                    kOtpUprava = Microsoft.VisualBasic.Left(mPrStanica, 2)
                End If

                Dim intCounter0 As Integer
                Dim daAneks As SqlClient.SqlDataAdapter
                Dim dsAneks As New Data.DataSet
                Dim objComm0 As SqlClient.SqlCommand

                Upit0 = "SELECT BrojUgovora, Aneks, VaziOd, VaziDo, PrimenjenaTarifa " & _
                        "FROM Cena_UgovorKP " & _
                        "WHERE BrojUgovora='" & mBrojUg & "' "


                objComm0 = New SqlClient.SqlCommand(Upit0, DbVeza)
                'objComm0.Connection.Open()
                daAneks = New SqlClient.SqlDataAdapter(Upit0, DbVeza)
                daAneks.Fill(dsAneks)

                With dsAneks.Tables(0)
                    m = 0
                    For intCounter0 = 0 To .Rows.Count - 1
                        BrAneksa = .Rows(intCounter0).Item("Aneks")
                        kVaziOd = .Rows(intCounter0).Item("VaziOd")
                        kVaziDo = .Rows(intCounter0).Item("VaziDo")
                        kSifTar = .Rows(intCounter0).Item("PrimenjenaTarifa")

                        If BrAneksa = BrAneksa And (mDatumKalk >= kVaziOd And mDatumKalk <= kVaziDo) Then
                            ''m = 1

                            Dim intCounter2 As Integer
                            Dim daUprava As SqlClient.SqlDataAdapter
                            Dim dsUprava As New Data.DataSet
                            Dim objComm2 As SqlClient.SqlCommand

                            Upit2 = "SELECT UgKp_Tip5.Aneks, UgKp_Uprava.Uprava, UgKp_Tip5.OdStanice, UgKp_Tip5.DoStanice  " & _
                                    "FROM  UgKp_Uprava INNER JOIN UgKp_Tip5 ON UgKp_Uprava.BrojUgovora = UgKp_Tip5.BrojUgovora " & _
                                    "WHERE (UgKp_Tip5.BrojUgovora = '" & mBrojUg & "') AND ( UgKp_Tip5.Aneks = '" & BrAneksa & "') "

                            objComm2 = New SqlClient.SqlCommand(Upit2, DbVeza)
                            daUprava = New SqlClient.SqlDataAdapter(Upit2, DbVeza)
                            daUprava.Fill(dsUprava)

                            With dsUprava.Tables(0)
                                i = 0
                                For intCounter2 = 0 To .Rows.Count - 1
                                    If kStatus = "T" Then
                                        Aneks = .Rows(intCounter2).Item("Aneks")
                                        Uprava = .Rows(intCounter2).Item("Uprava")
                                        OdStan = .Rows(intCounter2).Item("OdStanice")
                                        DoStan = .Rows(intCounter2).Item("DoStanice")

                                    Else
                                        Aneks = .Rows(intCounter2).Item("Aneks")
                                        Uprava = .Rows(intCounter2).Item("Uprava")
                                        DoStan = .Rows(intCounter2).Item("OdStanice")
                                        OdStan = .Rows(intCounter2).Item("DoStanice")

                                    End If

                                    If kOtpUprava = Uprava And mStanica1 = OdStan And mStanica2 = DoStan And BrAneksa = Aneks Then
                                        i = 1
                                        kIznosMinPrev = 0
                                        kNadjiSveKPovl(mBrojUg, BrAneksa, mDatumKalk, mTarifa, bVrstaSaobracaja, kVlasn, kTipKola, _
                                                       kSer, kBrOsov, kIznosMinPrev, kPovVr)         'ps. ako javi neuspešan upit proveriti datume važenja ugovora
                                        If Not (kPovVr = "                                                  " Or kPovVr = "") Then
                                            MessageBox.Show("Greška u upitu! Neki parametri ne zadovoljavaju uslov, primenice se redovna tarifa.", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                            bValuta = "17"
                                            mTabelaCena = "122"
                                            bNadjiPrevozninu00T(mTabelaCena, mPrevoznina)
                                        End If
                                        ' Nadji tip kola i Koeficijent za tip kola   KolKoef
                                        RacMasaPoKolima = 0

                                        If dtNhm.Rows.Count > 0 Then
                                            'ubaceno K: 13.11.2007 
                                            Dim StavkaNhm As Integer = 0
                                            Dim pomStavkaNhm As String
                                            Dim pomkNhmSif As String
                                            Dim intCounter1 As Integer
                                            Dim daStavkaNhm As SqlClient.SqlDataAdapter
                                            Dim dsStavkaNhm As New Data.DataSet
                                            Dim objComm1 As SqlClient.SqlCommand

                                            Upit1 = "SELECT UgKp_Nhm.BrojUgovora, UgKp_Nhm.Aneks, UgKp_Nhm.StavkaNhm, UgKp_Nhm.NhmSifra from UgKp_Nhm " & _
                                                    "WHERE (UgKp_Nhm.BrojUgovora = '" & mBrojUg & "') AND (UgKp_Nhm.Aneks = '" & BrAneksa & "') "

                                            objComm1 = New SqlClient.SqlCommand(Upit1, DbVeza)
                                            objComm1.Connection.Open()
                                            daStavkaNhm = New SqlClient.SqlDataAdapter(Upit1, DbVeza)
                                            daStavkaNhm.Fill(dsStavkaNhm)
                                            Dim KBrojUgovora As String

                                            For Each NHMRed In dtNhm.Rows
                                                If NHMRed.Item("IndBrojKola") = IBK Then

                                                    kNhm = Microsoft.VisualBasic.Left(NHMRed.Item("NHM"), 4)
                                                    MasaTemp = NHMRed.Item("Masa")
                                                    RacMasaPoKolima = RacMasaPoKolima + MasaTemp
                                                    bZaokruziMasuNa100k(RacMasaPoKolima)
                                                    kVozStavKP(mBrojUg, BrAneksa, mDatumKalk, kStavka, kNhmSif, kPovVred)
                                                    UTINhm = Microsoft.VisualBasic.Left(NHMRed.Item("UtiNHM"), 4)
                                                    j = 0
                                                    With dsStavkaNhm.Tables(0)
                                                        For intCounter1 = 0 To .Rows.Count - 1
                                                            KBrojUgovora = .Rows(intCounter1).Item("BrojUgovora")
                                                            Aneks = .Rows(intCounter1).Item("Aneks")
                                                            kNhmSif = Microsoft.VisualBasic.Left(.Rows(intCounter1).Item("NhmSifra"), 4)
                                                            If Aneks = BrAneksa And (kNhm = kNhmSif Or UTINhm = kNhmSif) Then
                                                                j = 1
                                                                Exit For      'ako je zadovoljen uslov kNhm = kNhmSif Or UTINhm = kNhmSif izadji 
                                                            End If
                                                        Next                  'ucitava sledeci nhm

                                                    End With                  'zavrsava ucitavanje nhm-a
                                                    If j = 0 Then
                                                        MessageBox.Show("Nhm pozicija nije odgovarajuca! Primenjuje se redovna tarifa.", "Upozorenje")
                                                        Ug_Greska = "D"
                                                    End If
                                                End If                        'kraj od if NHMRed.Item("IndBrojKola")=IBK
                                            Next                  'sledeca roba ???


                                            '--------------------------------------------------------
                                            Dim NacinObrade
                                            Dim intCounterj As Integer
                                            Dim daj As SqlClient.SqlDataAdapter
                                            Dim dsj As New Data.DataSet
                                            Dim objCommj As SqlClient.SqlCommand

                                            If Microsoft.VisualBasic.Left(kNhm, 4) = "9921" Or Microsoft.VisualBasic.Left(kNhm, 4) = "9922" Then
                                                kStatus = "P"
                                            End If

                                            UpitJ = "SELECT UgKp_Tip5.BrojUgovora, UgKp_Tip5.Aneks, UgKp_Tip5.StavkaStanice, UgKp_Tip5.OdStanice, UgKp_Tip5.DoStanice,  " & _
                                                    "UgKp_Tip5.Status, Pojedinacna, Grupa, Voz, MinPrevozninaIznos, NacinObrade, SifraValute, OsPritisak " & _
                                                    "FROM   UgKp_Tip5 INNER JOIN Cena_UgovorKP ON UgKp_Tip5.BrojUgovora = Cena_UgovorKP.BrojUgovora AND " & _
                                                    "UgKp_Tip5.Aneks = Cena_UgovorKP.Aneks INNER JOIN " & _
                                                    "UgKp_Nhm ON Cena_UgovorKP.BrojUgovora = UgKp_Nhm.BrojUgovora AND Cena_UgovorKP.Aneks = UgKp_Nhm.Aneks " & _
                                                    "GROUP BY UgKp_Tip5.BrojUgovora, UgKp_Tip5.Aneks, UgKp_Tip5.StavkaStanice, UgKp_Tip5.OdStanice, UgKp_Tip5.DoStanice, UgKp_Tip5.Status,   " & _
                                                    "Cena_UgovorKP.VaziOd, Cena_UgovorKP.VaziDo, Cena_UgovorKP.NacinObrade, Cena_UgovorKP.SifraValute, UgKp_Tip5.OsPritisak,  " & _
                                                    "UgKp_Tip5.Pojedinacna, UgKp_Tip5.Grupa, UgKp_Tip5.Voz, Cena_UgovorKP.MinPrevozninaIznos " & _
                                                    "HAVING    ( UgKp_Tip5.BrojUgovora= '" & mBrojUg & "') AND (UgKp_Tip5.Aneks = '" & BrAneksa & "') "

                                            m = 1

                                            objCommj = New SqlClient.SqlCommand(UpitJ, DbVeza)
                                            objCommj.Connection.Open()
                                            daj = New SqlClient.SqlDataAdapter(UpitJ, DbVeza)
                                            daj.Fill(dsj)
                                            With dsj.Tables(0)
                                                k = 0
                                                For intCounterj = 0 To .Rows.Count - 1
                                                    If kStatus = "T" Then
                                                        kStavkaSt = .Rows(intCounterj).Item("StavkaStanice")
                                                        mBrojUg = .Rows(intCounterj).Item("BrojUgovora")
                                                        Aneks = .Rows(intCounterj).Item("Aneks")
                                                        Status = .Rows(intCounterj).Item("Status")
                                                        OdStan = .Rows(intCounterj).Item("OdStanice")
                                                        DoStan = .Rows(intCounterj).Item("DoStanice")
                                                        kNacinObrac = .Rows(intCounterj).Item("NacinObrade")
                                                        Pojed = .Rows(intCounterj).Item("Pojedinacna")
                                                        Grupa = .Rows(intCounterj).Item("Grupa")
                                                        Voz = .Rows(intCounterj).Item("Voz")
                                                        kValuta = .Rows(intCounterj).Item("SifraValute")
                                                        OsPr = .Rows(intCounterj).Item("OsPritisak")
                                                        IznosMinPrev = .Rows(intCounterj).Item("MinPrevozninaIznos")
                                                    Else
                                                        kStavkaSt = .Rows(intCounterj).Item("StavkaStanice")
                                                        mBrojUg = .Rows(intCounterj).Item("BrojUgovora")
                                                        Aneks = .Rows(intCounterj).Item("Aneks")
                                                        Status = .Rows(intCounterj).Item("Status")
                                                        OdStan = .Rows(intCounterj).Item("DoStanice")
                                                        DoStan = .Rows(intCounterj).Item("OdStanice")
                                                        kNacinObrac = .Rows(intCounterj).Item("NacinObrade")
                                                        Pojed = .Rows(intCounterj).Item("Pojedinacna")
                                                        Grupa = .Rows(intCounterj).Item("Grupa")
                                                        Voz = .Rows(intCounterj).Item("Voz")
                                                        kValuta = .Rows(intCounterj).Item("SifraValute")
                                                        OsPr = .Rows(intCounterj).Item("OsPritisak")
                                                        IznosMinPrev = .Rows(intCounterj).Item("MinPrevozninaIznos")
                                                    End If
                                                    If j = 1 Then
                                                        'If KBrojUgovora = mBrojUg And Aneks = BrAneksa And mStanica1 = OdStan And mStanica2 = DoStan And kStatus = Status Then
                                                        If Aneks = BrAneksa And mStanica1 = OdStan And mStanica2 = DoStan And kStatus = Status Then
                                                            k = 1
                                                            RacMasaPoKolimaTone = RacMasaPoKolima / 1000
                                                            If kNacinObrac = 4 Then           '4. cena po kolima
                                                                If mVrstaPrevoza = "P" Then
                                                                    PrevozninaPoUgP = 0
                                                                    PrevozninaPoUgP = RacMasaPoKolimaTone * Pojed
                                                                    bZaokruziNaDeseteNavise(PrevozninaPoUgP)
                                                                End If
                                                                If mVrstaPrevoza = "G" Or dtKola.Rows.Count >= 6 Then   'da li je ovo dobro???
                                                                    PrevozninaPoUgG = 0
                                                                    PrevozninaPoUgG = RacMasaPoKolimaTone * Grupa
                                                                    bZaokruziNaDeseteNavise(PrevozninaPoUgG)
                                                                End If
                                                                If mVrstaPrevoza = "V" Then
                                                                    PrevozninaPoUgV = 0

                                                                    PrevozninaPoUgV = RacMasaPoKolimaTone * Voz
                                                                    bZaokruziNaDeseteNavise(PrevozninaPoUgV)
                                                                End If

                                                                PrevozninaPoUg = PrevozninaPoUgP + PrevozninaPoUgG + PrevozninaPoUgV

                                                                'Testiraj na minimalnu prevozninu  
                                                                If PrevozninaPoUg <= IznosMinPrev Then
                                                                    PrevozninaPoUg = IznosMinPrev
                                                                End If
                                                            ElseIf kNacinObrac = 2 Then         ' 2. cena po toni
                                                                If mVrstaPrevoza = "P" Then
                                                                    PrevozninaPoUgP = 0
                                                                    PrevozninaPoUgP = RacMasaPoKolimaTone * Pojed
                                                                    bZaokruziNaDeseteNavise(PrevozninaPoUgP)
                                                                End If
                                                                If mVrstaPrevoza = "G" Or dtKola.Rows.Count >= 6 Then   'da li je ovo dobro???
                                                                    PrevozninaPoUgG = 0
                                                                    PrevozninaPoUgG = RacMasaPoKolimaTone * Grupa
                                                                    bZaokruziNaDeseteNavise(PrevozninaPoUgG)
                                                                End If
                                                                If mVrstaPrevoza = "V" Then
                                                                    PrevozninaPoUgV = 0
                                                                    PrevozninaPoUgV = RacMasaPoKolimaTone * Voz
                                                                    bZaokruziNaDeseteNavise(PrevozninaPoUgV)
                                                                End If

                                                                PrevozninaPoUg = PrevozninaPoUgP + PrevozninaPoUgG + PrevozninaPoUgV

                                                                ' Testiraj na minimalnu prevozninu  
                                                                If PrevozninaPoUg <= IznosMinPrev Then
                                                                    PrevozninaPoUg = IznosMinPrev
                                                                End If

                                                            ElseIf kNacinObrac = 3 Then        '3. cena po tonskom stavu ( date su cene za 10-to tonski stav, 15-to tonski stav, ... )
                                                                bNadjiMasuIStavDo45(RacMasaPoKolima, kIzlMasa, kSifraSt)
                                                                kTonskiStav = kSifraSt
                                                                kTonskiStavKP(mBrojUg, BrAneksa, mDatumKalk, kTonskiStav, kNacinObrac, bValuta, Pojed, Grupa, Voz, IznosMinPrev, kPovratnaVred)

                                                                If kSifraSt = kTonskiStav Then
                                                                    If mVrstaPrevoza = "P" Then
                                                                        PrevozninaPoUgP = 0
                                                                        PrevozninaPoUgP = RacMasaPoKolimaTone * Pojed
                                                                        bZaokruziNaDeseteNavise(PrevozninaPoUgP)
                                                                    End If
                                                                    If mVrstaPrevoza = "G" Or dtKola.Rows.Count >= 6 Then   'da li je ovo dobro???
                                                                        PrevozninaPoUgG = 0
                                                                        PrevozninaPoUgG = RacMasaPoKolimaTone * Grupa
                                                                        bZaokruziNaDeseteNavise(PrevozninaPoUgG)
                                                                    End If
                                                                    If mVrstaPrevoza = "V" Then
                                                                        PrevozninaPoUgV = 0
                                                                        PrevozninaPoUgV = RacMasaPoKolimaTone * Voz
                                                                        bZaokruziNaDeseteNavise(PrevozninaPoUgV)
                                                                    End If

                                                                    PrevozninaPoUg = PrevozninaPoUgP + PrevozninaPoUgG + PrevozninaPoUgV

                                                                    ' Testiraj na minimalnu prevozninu  
                                                                    If PrevozninaPoUg <= IznosMinPrev Then
                                                                        PrevozninaPoUg = IznosMinPrev
                                                                    End If
                                                                End If

                                                            ElseIf kNacinObrac = 6 Then         '6. cena za UTI kombinovano
                                                                kTipUTI(mBrojUg, BrAneksa, mDatumKalk, kNacinObrac, bValuta, Pojed, Grupa, Voz, TipUTI, IznosMinPrev, kPovratnaVred)

                                                                If mVrstaPrevoza = "P" Then
                                                                    PrevozninaPoUgP = 0
                                                                    PrevozninaPoUgP = RacMasaPoKolimaTone * Pojed
                                                                    bZaokruziNaDeseteNavise(PrevozninaPoUgP)
                                                                End If
                                                                If mVrstaPrevoza = "G" Or dtKola.Rows.Count >= 6 Then   'da li je ovo dobro???
                                                                    PrevozninaPoUgG = 0
                                                                    PrevozninaPoUgG = RacMasaPoKolimaTone * Grupa
                                                                    bZaokruziNaDeseteNavise(PrevozninaPoUgG)
                                                                End If
                                                                If mVrstaPrevoza = "V" Then
                                                                    PrevozninaPoUgV = 0
                                                                    'If RacMasaPoKolima * UkupnoKola >= 500000 Then
                                                                    PrevozninaPoUgV = RacMasaPoKolimaTone * Voz
                                                                    bZaokruziNaDeseteNavise(PrevozninaPoUgV)
                                                                End If

                                                                PrevozninaPoUg = PrevozninaPoUgP + PrevozninaPoUgG + PrevozninaPoUgV

                                                                ' Testiraj na minimalnu prevozninu  
                                                                If PrevozninaPoUg <= IznosMinPrev Then
                                                                    PrevozninaPoUg = IznosMinPrev
                                                                End If

                                                                'PrevozninaPoUg = PrevozninaPoUgP + PrevozninaPoUgG + PrevozninaPoUgV
                                                            ElseIf kNacinObrac = 7 Then
                                                                PrevozninaPoUgV = RacMasaPoKolimaTone * Voz
                                                            End If        'kNacinObracuna je redovna tarifa

                                                            bRacunskaMasaPoKolima = RacMasaPoKolimaTone

                                                            If mVrstaPrevoza = "P" Then
                                                                KolaRed.Item("Prevoznina") = PrevozninaPoUg
                                                                KolaRed.Item("RacunskaMasa") = RacMasaPoKolimaTone * 1000
                                                                KolaRed.Item("VozarinskiStav") = Pojed

                                                                kPrevoznina = kPrevoznina + PrevozninaPoUg + PrevozninaOsPrit
                                                                bRacunskaMasa = bRacunskaMasa + RacMasaPoKolimaTone
                                                                For Each NHMRed In dtNhm.Rows
                                                                    If NHMRed.Item("IndBrojKola") = IBK Then
                                                                        NHMRed.Item("RacMasaNHM") = RacMasaPoKolimaTone * 1000
                                                                        NHMRed.Item("VozarinskiStavNHM") = Pojed
                                                                    End If
                                                                Next
                                                            ElseIf mVrstaPrevoza = "G" Then
                                                                KolaRed.Item("Prevoznina") = PrevozninaPoUg
                                                                KolaRed.Item("RacunskaMasa") = RacMasaPoKolimaTone * 1000
                                                                KolaRed.Item("VozarinskiStav") = Grupa

                                                                kPrevoznina = kPrevoznina + PrevozninaPoUg + PrevozninaOsPrit
                                                                bRacunskaMasa = bRacunskaMasa + RacMasaPoKolimaTone
                                                                For Each NHMRed In dtNhm.Rows
                                                                    If NHMRed.Item("IndBrojKola") = IBK Then
                                                                        NHMRed.Item("RacMasaNHM") = RacMasaPoKolimaTone * 1000
                                                                        NHMRed.Item("VozarinskiStavNHM") = Grupa
                                                                    End If
                                                                Next

                                                            ElseIf mVrstaPrevoza = "V" Then
                                                                KolaRed.Item("Prevoznina") = PrevozninaPoUg
                                                                KolaRed.Item("RacunskaMasa") = RacMasaPoKolimaTone * 1000
                                                                KolaRed.Item("VozarinskiStav") = Voz

                                                                kPrevoznina = kPrevoznina + PrevozninaPoUg + PrevozninaOsPrit
                                                                bRacunskaMasa = bRacunskaMasa + RacMasaPoKolimaTone

                                                                For Each NHMRed In dtNhm.Rows
                                                                    If NHMRed.Item("IndBrojKola") = IBK Then
                                                                        NHMRed.Item("RacMasaNHM") = RacMasaPoKolimaTone * 1000
                                                                        NHMRed.Item("VozarinskiStavNHM") = Voz
                                                                    End If
                                                                Next
                                                            End If

                                                            PrevozninaPoUg = PrevozninaPoUgP + PrevozninaPoUgG + PrevozninaPoUgV


                                                        End If  'Kraj za kNacinObracuna
                                                    End If   ' kraj od dtNhm.Rows.Count > 0 
                                                    'End If  'nije dobra stanica
                                                    If k = 1 Then
                                                        Exit For    'vraæa cene ako su zadovoljeni svi 
                                                    End If
                                                Next
                                            End With
                                        End If
                                        'End If      'nije dobra stanica
                                    End If          'nije dobra uprava

                                    If i = 1 Then
                                        Exit For    'ako je zadovoljen uslov kOtpUprava = Uprava 
                                    End If
                                Next                'ucitava sledecu upravu

                            End With                'zavrsava ucitavanje uprava

                        End If
                        If m = 1 Then
                            Exit For    'ako je zadovoljen broj aneksa
                        End If
                    Next                'ucitava sledeci aneks

                End With                'zavrsava ucitavanje aneksa


                If k = 0 Then
                    MessageBox.Show("Primenjuje se redovna tarifa.", "Upozorenje")

                End If
                If i = 0 Then
                    MessageBox.Show("Uprava, otpravna ili uputna stanica nisu odgovarajuce! Primenjuje se redovna tarifa.", "Upozorenje")
                    Ug_Greska = "D"
                End If
            Next                        'nema ni kola ni prevoznine

        End If
        DbVeza.Close()
        mPrevoznina = kPrevoznina

        If Ug_Greska = "D" Then
            bValuta = "17"
            mTabelaCena = "122"
            bNadjiPrevozninu00T(mTabelaCena, mPrevoznina)
        End If

    End Sub    '******************************************************
    Public Sub kVozStavKP(ByVal inBrojUgovora As String, _
              ByRef outAneks As Integer, _
              ByVal inDatumTarifiranja As Date, _
              ByRef outStavkaNhm As Integer, _
              ByRef outNhmSifra As String, _
              ByRef outPovratnaVrednost As String)

        outPovratnaVrednost = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("kVozStavKP", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUg As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUg.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        Dim izlAneks As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAneks", SqlDbType.Int))
        izlAneks.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outAneks").Value = outAneks

        Dim ulDatTar As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumTarifiranja", SqlDbType.DateTime))
        ulDatTar.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatumTarifiranja").Value = inDatumTarifiranja

        Dim izlStavka As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStavka", SqlDbType.Int))
        izlStavka.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStavka").Value = outStavkaNhm


        Dim izlNhmSifra As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNhmSifra", SqlDbType.Char, 6))
        izlNhmSifra.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNhmSifra").Value = outNhmSifra

        Dim izlPovVr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.Char, 50))
        izlPovVr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPovratnaVrednost").Value = outPovratnaVrednost
        '---------------------------- Data Set --------------------------------

        Try
            spKomanda.ExecuteScalar()
            outNhmSifra = spKomanda.Parameters("@outNhmSifra").Value
            outStavkaNhm = spKomanda.Parameters("@outStavka").Value
            outPovratnaVrednost = spKomanda.Parameters("@outPovratnaVrednost").Value
            'If outPovratnaVrednost <> "" Then outPovratnaVrednost = " Neuspesan upit!"

        Catch SQLExp As SqlException
            outPovratnaVrednost = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outPovratnaVrednost = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub kNacinObracuna(ByVal inBrojUgovora As String, _
                       ByRef outAneks As Integer, _
                       ByRef outStavkaStanice As Int16, _
                       ByVal inDatumTarifiranja As Date, _
                       ByRef outNacinObrade As Integer, _
                       ByRef outValuta As String, _
                       ByRef outOsPrit As String, _
                       ByRef outPojedinacna As Decimal, _
                       ByRef outGrupa As Decimal, _
                       ByRef outVoz As Decimal, _
                       ByRef outIznosMinPrev As Decimal, _
                       ByRef outPovratnaVrednost As String)
        outPovratnaVrednost = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("kNacinObracuna", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUg As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUg.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        Dim izlAneks As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAneks", SqlDbType.Int))
        izlAneks.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outAneks").Value = outAneks

        Dim izlStavkaStanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStavkaStanice", SqlDbType.Int))
        izlStavkaStanice.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outStavkaStanice").Value = outStavkaStanice

        Dim ulDatTar As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumTarifiranja", SqlDbType.DateTime))
        ulDatTar.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatumTarifiranja").Value = inDatumTarifiranja

        Dim izNacinObracuna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNacinObrade", SqlDbType.Int))
        izNacinObracuna.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNacinObrade").Value = outNacinObrade

        Dim izlValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraValute", SqlDbType.Int))
        izlValuta.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraValute").Value = outValuta

        Dim izlOsPrit As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOsovinskiPritisak", SqlDbType.Char, 1))
        izlOsPrit.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOsovinskiPritisak").Value = outOsPrit

        Dim izlPojed As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPojedinacna", SqlDbType.Decimal))
        izlPojed.Direction = ParameterDirection.Output
        izlPojed.Size = 12
        izlPojed.Precision = 9
        izlPojed.Scale = 2
        spKomanda.Parameters("@outPojedinacna").Value = outPojedinacna

        Dim izlGrup As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrupa", SqlDbType.Decimal))
        izlGrup.Direction = ParameterDirection.Output
        izlGrup.Size = 12
        izlGrup.Precision = 9
        izlGrup.Scale = 2
        spKomanda.Parameters("@outGrupa").Value = outGrupa

        Dim izlVoz1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVoz", SqlDbType.Decimal))
        izlVoz1.Direction = ParameterDirection.Output
        izlVoz1.Size = 12
        izlVoz1.Precision = 9
        izlVoz1.Scale = 2
        spKomanda.Parameters("@outVoz").Value = outVoz

        'Dim izTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTonskiStav", SqlDbType.Char, 2))
        'izTonskiStav.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outTonskiStav").Value = outTonskiStav

        Dim izlIznMinPrev As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznosMinPrev", SqlDbType.Decimal))
        izlIznMinPrev.Direction = ParameterDirection.Output
        izlIznMinPrev.Size = 12
        izlIznMinPrev.Precision = 9
        izlIznMinPrev.Scale = 2
        spKomanda.Parameters("@outIznosMinPrev").Value = outIznosMinPrev

        Dim izlPovratnaVrednos As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.Char, 50))
        izlPovratnaVrednos.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPovratnaVrednost").Value = outPovratnaVrednost
        '---------------------------- Data Set --------------------------------

        Try
            spKomanda.ExecuteScalar()
            outAneks = spKomanda.Parameters("@outAneks").Value
            outStavkaStanice = spKomanda.Parameters("@outStavkaStanice").Value
            outValuta = spKomanda.Parameters("@outSifraValute").Value
            outOsPrit = spKomanda.Parameters("@outOsovinskiPritisak").Value
            outPojedinacna = spKomanda.Parameters("@outPojedinacna").Value
            outGrupa = spKomanda.Parameters("@outGrupa").Value
            outVoz = spKomanda.Parameters("@outVoz").Value
            outIznosMinPrev = spKomanda.Parameters("@outIznosMinPrev").Value
            outNacinObrade = spKomanda.Parameters("@outNacinObrade").Value
            'outTonskiStav = spKomanda.Parameters("@outTonskiStav").Value
            outPovratnaVrednost = spKomanda.Parameters("@outPovratnaVrednost").Value
            'If outPovratnaVrednost <> "" Then outPovratnaVrednost = " Neuspesan upit!"

        Catch SQLExp As SqlException
            outPovratnaVrednost = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outPovratnaVrednost = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub kTonskiStavKP(ByVal inBrojUgovora As String, _
                        ByRef outAneks As Integer, _
                        ByVal inDatumTarifiranja As Date, _
                        ByRef inTonskiStav As String, _
                        ByRef outNacinObrade As Integer, _
                        ByRef outValuta As String, _
                        ByRef outPojedinacna As Decimal, _
                        ByRef outGrupa As Decimal, _
                        ByRef outVoz As Decimal, _
                        ByRef outIznosMinPrev As Decimal, _
                        ByRef outPovratnaVrednost As String)
        outPovratnaVrednost = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("kTonStav", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUg As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUg.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        Dim izlAneks As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAneks", SqlDbType.Int))
        izlAneks.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outAneks").Value = outAneks

        'Dim izlStavkaStanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStavkaStanice", SqlDbType.Int))
        'izlStavkaStanice.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outStavkaStanice").Value = outAneks

        Dim ulDatTar As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumTarifiranja", SqlDbType.DateTime))
        ulDatTar.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatumTarifiranja").Value = inDatumTarifiranja

        Dim ulTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTonskiStav", SqlDbType.Char, 2))
        ulTonskiStav.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTonskiStav").Value = inTonskiStav

        'Dim izlTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTonskiStav", SqlDbType.Char, 2))
        'izlTonskiStav.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outTonskiStav").Value = outTonskiStav

        Dim izNacinObracuna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNacinObrade", SqlDbType.Int))
        izNacinObracuna.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNacinObrade").Value = outNacinObrade

        Dim izlValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraValute", SqlDbType.Int))
        izlValuta.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraValute").Value = outValuta

        Dim izlPojed As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPojedinacna", SqlDbType.Decimal))
        izlPojed.Direction = ParameterDirection.Output
        izlPojed.Size = 12
        izlPojed.Precision = 9
        izlPojed.Scale = 2
        spKomanda.Parameters("@outPojedinacna").Value = outPojedinacna

        Dim izlGrup As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrupa", SqlDbType.Decimal))
        izlGrup.Direction = ParameterDirection.Output
        izlGrup.Size = 12
        izlGrup.Precision = 9
        izlGrup.Scale = 2

        Dim izlVoz1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVoz", SqlDbType.Decimal))
        izlVoz1.Direction = ParameterDirection.Output
        izlVoz1.Size = 12
        izlVoz1.Precision = 9
        izlVoz1.Scale = 2

        Dim izlIznMinPrev As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznosMinPrev", SqlDbType.Decimal))
        izlIznMinPrev.Direction = ParameterDirection.Output
        izlIznMinPrev.Size = 12
        izlIznMinPrev.Precision = 9
        izlIznMinPrev.Scale = 2

        Dim izlPovratnaVrednos As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.Char, 50))
        izlPovratnaVrednos.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPovratnaVrednost").Value = outPovratnaVrednost
        '---------------------------- Data Set --------------------------------

        Try
            spKomanda.ExecuteScalar()
            outAneks = spKomanda.Parameters("@outAneks").Value
            'outStavkaStanice = spKomanda.Parameters("@outStavkaStanice").Value
            outValuta = spKomanda.Parameters("@outSifraValute").Value
            outPojedinacna = spKomanda.Parameters("@outPojedinacna").Value
            outGrupa = spKomanda.Parameters("@outGrupa").Value
            outVoz = spKomanda.Parameters("@outVoz").Value
            outIznosMinPrev = spKomanda.Parameters("@outIznosMinPrev").Value
            outNacinObrade = spKomanda.Parameters("@outNacinObrade").Value
            'outTonskiStav = spKomanda.Parameters("@outTonskiStav").Value
            outPovratnaVrednost = spKomanda.Parameters("@outPovratnaVrednost").Value
            'If outPovratnaVrednost <> "" Then outPovratnaVrednost = " Neuspesan upit!"

        Catch SQLExp As SqlException
            outPovratnaVrednost = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outPovratnaVrednost = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub kTipUTI(ByVal inBrojUgovora As String, _
                       ByRef outAneks As Integer, _
                       ByVal inDatumTarifiranja As Date, _
                       ByRef outNacinObrade As Integer, _
                       ByRef outValuta As String, _
                       ByRef outPojedinacna As Decimal, _
                       ByRef outGrupa As Decimal, _
                       ByRef outVoz As Decimal, _
                       ByRef outTipUTI As String, _
                       ByRef outIznosMinPrev As Decimal, _
                       ByRef outPovratnaVrednost As String)
        outPovratnaVrednost = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("kTipUTI", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUg As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUg.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        Dim izlAneks As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAneks", SqlDbType.Int))
        izlAneks.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outAneks").Value = outAneks

        'Dim izlStavkaStanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outStavkaStanice", SqlDbType.Int))
        'izlStavkaStanice.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outStavkaStanice").Value = outAneks

        Dim ulDatTar As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumTarifiranja", SqlDbType.DateTime))
        ulDatTar.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatumTarifiranja").Value = inDatumTarifiranja

        Dim izNacinObracuna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNacinObrade", SqlDbType.Int))
        izNacinObracuna.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNacinObrade").Value = outNacinObrade

        Dim izlValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifraValute", SqlDbType.Int))
        izlValuta.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifraValute").Value = outValuta

        Dim izlPojed As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPojedinacna", SqlDbType.Decimal))
        izlPojed.Direction = ParameterDirection.Output
        izlPojed.Size = 12
        izlPojed.Precision = 9
        izlPojed.Scale = 2
        spKomanda.Parameters("@outPojedinacna").Value = outPojedinacna

        Dim izlGrup As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrupa", SqlDbType.Decimal))
        izlGrup.Direction = ParameterDirection.Output
        izlGrup.Size = 12
        izlGrup.Precision = 9
        izlGrup.Scale = 2

        Dim izlVoz1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVoz", SqlDbType.Decimal))
        izlVoz1.Direction = ParameterDirection.Output
        izlVoz1.Size = 12
        izlVoz1.Precision = 9
        izlVoz1.Scale = 2

        Dim izlTipUTI As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTipUTI", SqlDbType.Char, 6))
        izlTipUTI.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTipUTI").Value = outTipUTI

        Dim izlIznMinPrev As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outIznosMinPrev", SqlDbType.Decimal))
        izlIznMinPrev.Direction = ParameterDirection.Output
        izlIznMinPrev.Size = 12
        izlIznMinPrev.Precision = 9
        izlIznMinPrev.Scale = 2

        Dim izlPovratnaVrednos As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.Char, 50))
        izlPovratnaVrednos.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPovratnaVrednost").Value = outPovratnaVrednost
        '---------------------------- Data Set --------------------------------

        Try
            spKomanda.ExecuteScalar()
            outAneks = spKomanda.Parameters("@outAneks").Value
            'outStavkaStanice = spKomanda.Parameters("@outStavkaStanice").Value
            outValuta = spKomanda.Parameters("@outSifraValute").Value
            outPojedinacna = spKomanda.Parameters("@outPojedinacna").Value
            outGrupa = spKomanda.Parameters("@outGrupa").Value
            outVoz = spKomanda.Parameters("@outVoz").Value
            outIznosMinPrev = spKomanda.Parameters("@outIznosMinPrev").Value
            outNacinObrade = spKomanda.Parameters("@outNacinObrade").Value
            outTipUTI = spKomanda.Parameters("@outTonskiStav").Value
            outPovratnaVrednost = spKomanda.Parameters("@outPovratnaVrednost").Value
            'If outPovratnaVrednost <> "" Then outPovratnaVrednost = " Neuspesan upit!"

        Catch SQLExp As SqlException
            outPovratnaVrednost = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outPovratnaVrednost = Err.Description & " Greska u programu!"
        Finally
            DbVeza.Close()
            spKomanda.Dispose()
        End Try
    End Sub
    Public Sub kNadjiSveKPovl(ByVal inBrojUgovora As String, _
                                      ByRef outAneks As Integer, _
                                      ByVal inDatumTarifiranja As Date, _
                                      ByVal inTarifa As String, _
                                      ByVal inSaobracaj As Integer, _
                                      ByVal inVlasnistvoKola As String, _
                                      ByVal inStatus As String, _
                                      ByVal inSerija As String, _
                                      ByVal inBrojOsovina As Char, _
                                      ByRef outMinPrevIznos As Decimal, _
                                      ByRef outPovVred As String)

        ' TovarenaPrazna - tovarena, prazna, tovaren UTI, prazan UTI
        outPovVred = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        Dim spKomanda As New SqlClient.SqlCommand("kNadjiSveKPovl", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUg As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUg.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        Dim izAneks As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAneks", SqlDbType.Int))
        izAneks.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outAneks").Value = outAneks

        Dim ulDatTar As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumTarifiranja", SqlDbType.DateTime))
        ulDatTar.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatumTarifiranja").Value = inDatumTarifiranja

        'Dim ulBrojUgovora As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        'ulBrojUgovora.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        'Dim ulDatTar As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumTarifiranja", SqlDbType.DateTime))
        'ulDatTar.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inDatumTarifiranja").Value = inDatumTarifiranja

        Dim ulTarifa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrimenjenaTarifa", SqlDbType.Char, 2))
        ulTarifa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrimenjenaTarifa").Value = inTarifa

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSaobracaj").Value = inSaobracaj

        'Dim ulValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifrValute", SqlDbType.Int))
        'ulValuta.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inSifraValute").Value = inSifraValute

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 3))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulStatus As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStatus", SqlDbType.Char, 1))
        ulStatus.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStatus").Value = inStatus

        Dim ulSerija As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSerija", SqlDbType.Char, 3))
        ulSerija.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSerija").Value = inSerija

        Dim ulBrojOsovina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojOsovina", SqlDbType.Char, 1))
        ulBrojOsovina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojOsovina").Value = inBrojOsovina

        'Dim ulSpecKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSpecLoca", SqlDbType.Char, 1))
        'ulSpecKola.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inSpecKola").Value = inSpecijalnaKola

        Dim izlMinPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinPrevozninaIznos", SqlDbType.Decimal))
        izlMinPrevoznina.Size = 9
        izlMinPrevoznina.Precision = 10
        izlMinPrevoznina.Scale = 2
        izlMinPrevoznina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinPrevozninaIznos").Value = outMinPrevIznos

        Dim izlPovVred As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovVred", SqlDbType.Char, 50))
        izlPovVred.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPovVred").Value = outPovVred

        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            'spKomanda.ExecuteScalar()
            'Dim Pom As Int16 = spKomanda.Parameters("@PovrVrednost").Value
            'Pom = spKomanda.Parameters("@PovrVrednost").Value
            'If Pom <> 0 Then outRetVal = " Neuspesan upit!" 'Pom = spKomanda.Parameters("@PovrVrednost").Value

            spKomanda.ExecuteScalar()
            outMinPrevIznos = spKomanda.Parameters("@outMinPrevozninaIznos").Value
            outPovVred = spKomanda.Parameters("@outPovVred").Value
            'If outPovVred <> "" Then outPovVred = " Neuspesan upit!"

        Catch SQLExp As SqlException
            outPovVred = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outPovVred = Err.Description & " Greska u programu!"
        Finally

            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub
    Public Sub kAneks(ByVal inBrojUgovora As String, _
                                      ByRef outAneks As Integer, _
                                      ByVal inDatumTarifiranja As Date, _
                                      ByVal inTarifa As String, _
                                      ByVal inSaobracaj As Integer, _
                                      ByVal inVlasnistvoKola As String, _
                                      ByVal inStatus As String, _
                                      ByVal inSerija As String, _
                                      ByVal inBrojOsovina As Char, _
                                      ByRef outMinPrevIznos As Decimal, _
                                      ByRef outPovVred As String)

        ' TovarenaPrazna - tovarena, prazna, tovaren UTI, prazan UTI
        outPovVred = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        Dim spKomanda As New SqlClient.SqlCommand("kNadjiSveKPovl", DbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUg As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUg.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        Dim izAneks As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outAneks", SqlDbType.Int))
        izAneks.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outAneks").Value = outAneks

        Dim ulDatTar As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumTarifiranja", SqlDbType.DateTime))
        ulDatTar.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatumTarifiranja").Value = inDatumTarifiranja

        'Dim ulBrojUgovora As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        'ulBrojUgovora.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        'Dim ulDatTar As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumTarifiranja", SqlDbType.DateTime))
        'ulDatTar.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inDatumTarifiranja").Value = inDatumTarifiranja

        Dim ulTarifa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inPrimenjenaTarifa", SqlDbType.Char, 2))
        ulTarifa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inPrimenjenaTarifa").Value = inTarifa

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSaobracaj").Value = inSaobracaj

        'Dim ulValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifrValute", SqlDbType.Int))
        'ulValuta.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inSifraValute").Value = inSifraValute

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 3))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulStatus As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStatus", SqlDbType.Char, 1))
        ulStatus.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStatus").Value = inStatus

        Dim ulSerija As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSerija", SqlDbType.Char, 3))
        ulSerija.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSerija").Value = inSerija

        Dim ulBrojOsovina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojOsovina", SqlDbType.Char, 1))
        ulBrojOsovina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojOsovina").Value = inBrojOsovina

        'Dim ulSpecKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSpecLoca", SqlDbType.Char, 1))
        'ulSpecKola.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inSpecKola").Value = inSpecijalnaKola

        Dim izlMinPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinPrevozninaIznos", SqlDbType.Decimal))
        izlMinPrevoznina.Size = 9
        izlMinPrevoznina.Precision = 10
        izlMinPrevoznina.Scale = 2
        izlMinPrevoznina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinPrevozninaIznos").Value = outMinPrevIznos

        Dim izlPovVred As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovVred", SqlDbType.Char, 50))
        izlPovVred.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPovVred").Value = outPovVred

        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            'spKomanda.ExecuteScalar()
            'Dim Pom As Int16 = spKomanda.Parameters("@PovrVrednost").Value
            'Pom = spKomanda.Parameters("@PovrVrednost").Value
            'If Pom <> 0 Then outRetVal = " Neuspesan upit!" 'Pom = spKomanda.Parameters("@PovrVrednost").Value

            spKomanda.ExecuteScalar()
            outMinPrevIznos = spKomanda.Parameters("@outMinPrevozninaIznos").Value
            outPovVred = spKomanda.Parameters("@outPovVred").Value
            'If outPovVred <> "" Then outPovVred = " Neuspesan upit!"

        Catch SQLExp As SqlException
            outPovVred = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outPovVred = Err.Description & " Greska u programu!"
        Finally

            DbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

    Public Sub KP11(ByVal inBrojUgovora As String, _
                ByVal inDatumTarifiranja As Date, _
                ByRef outOdStanice As String, _
                ByRef outDoStanice As String, _
                ByRef outUprava As String, _
                ByRef outSifKor As Integer, _
                ByRef outPovratnaVrednost As String)

        outPovratnaVrednost = ""
        If OkpDbVeza.State = ConnectionState.Closed Then
            OkpDbVeza.Open()
        End If

        Dim spKomanda As New SqlClient.SqlCommand("kKP11", OkpDbVeza)
        spKomanda.CommandType = CommandType.StoredProcedure

        Dim ulBrUg As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojUgovora", SqlDbType.Char, 6))
        ulBrUg.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojUgovora").Value = inBrojUgovora

        Dim ulDatTar As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDatumTarifiranja", SqlDbType.DateTime))
        ulDatTar.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDatumTarifiranja").Value = inDatumTarifiranja

        Dim izlOdStanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outOdStanice", SqlDbType.Char, 5))
        izlOdStanice.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outOdStanice").Value = outOdStanice

        Dim izlDoStanice As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outDoStanice", SqlDbType.Char, 5))
        izlDoStanice.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outDoStanice").Value = outDoStanice

        Dim izlSifKor As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outSifKor", SqlDbType.Int))
        izlSifKor.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outSifKor").Value = outSifKor

        Dim izlUpr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outUprava", SqlDbType.Char, 2))
        izlUpr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outUprava").Value = outUprava

        Dim izlPovVr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovratnaVrednost", SqlDbType.Char, 50))
        izlPovVr.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPovratnaVrednost").Value = outPovratnaVrednost
        '---------------------------- Data Set --------------------------------
        Try
            spKomanda.ExecuteScalar()
            'Dim Pom As Int16 = spKomanda.Parameters("@outPovratnaVrednost").Value
            'If Pom <> 0 Then
            '    outPovratnaVrednost = "Neuspešan upit!"
            'End If

            outOdStanice = spKomanda.Parameters("@outOdStanice").Value
            outDoStanice = spKomanda.Parameters("@outDoStanice").Value
            outUprava = spKomanda.Parameters("@outUprava").Value
            outSifKor = spKomanda.Parameters("@outSifKor").Value
            outPovratnaVrednost = spKomanda.Parameters("@outPovratnaVrednost").Value
            'If outPovratnaVrednost <> "" Then outPovratnaVrednost = " Neuspesan upit!"


        Catch SQLExp As SqlException
            outPovratnaVrednost = SQLExp.Message & " SQL greska u programu!"
        Catch Exp As Exception
            outPovratnaVrednost = Err.Description & " Greska u programu!"
        Finally
            OkpDbVeza.Close()
            spKomanda.Dispose()
        End Try

    End Sub

End Module