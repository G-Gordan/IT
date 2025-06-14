Imports System.Data.SqlClient
Module KalkModulKatarina
    Public Sub bNadjiPrevozninuROKP(ByRef kPrevoznina As Decimal, ByRef kPovVrROKP As String)
        Dim KolaRed As DataRow
        Dim UicRed As DataRow
        Dim NHMRed As DataRow
        Dim IBK, Vrsta, TipKola, Vlasnistvo, TovarenaPrazna, Serija As String
        Dim NHM, UTINhm, Uprava As String
        Dim Aneks As Integer = 0
        Dim BrOsovina As Byte
        Dim MasaTemp As Integer
        Dim MasaTempT As Decimal = 0
        Dim RacMasaPoKolima As Integer
        Dim RacMasaPoKolimaTone As Decimal
        Dim PrevozninaPoKolima As Decimal
        Dim PrevV, PrevG, PrevP As Decimal
        Dim VozarinskiStav As Decimal
        Dim PrevozninaPoUg, PrevozninaZaVoz As Decimal
        Dim kPV, kPovVr, kPovVred, kPovratnaVred As String
        Dim kNhm, kNhmSif As String
        Dim kStat As String = "T"
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
        Dim VlasnistvoKola As String
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
        Dim SifraPrelaza As String
        Dim i, j, k, l, m, n As Integer
        Dim Ug_Greska As String = "N"
        Dim Upit0 As String
        Dim Upit1 As String
        Dim Upit2 As String
        Dim UpitKKKK As String
        Dim UpitJ As String
        Dim UpitUTI As String
        Dim UpitGrSt As String
        Dim MasaUti As Decimal
        Dim Greska As String
        Dim KolaZ As String

        Dim RMPK As Decimal = 0
        Dim RacMasaNhm As Decimal = 0
        Dim MasaU1 As Decimal = 0
        Dim MasaU2 As Decimal = 0

        Dim kSpecKola As Char = "N"

        Dim bStanicaTemp1 = ""
        Dim bStanicaTemp2 = ""

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
        '           5. cena po UTI-ju                      K: OVO JE OBUHVACENO 6.-icom
        '           6. cena po kolima za UTI - kombinacije K: URADJENO 
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
        '           5. cena po UTI - ju
        '               u petlji po kolima se cena po kolima dobija tako sto se u zavisnosti od
        '               duzine kontejnera nadje cena po kontejneru i sabira po kolima;
        '               zatim se mnozi koeficijentom za tip kola i posle zaokruzivanja uporedjuje
        '               sa min. prevozninom ( u zavisnosti od "vrste" min. prevoznine )
        '           6. cena po kolima za UTI - kombinacije
        '               u petlji po kolima posebnom procedurom se nadje vrsta kombinacije kontejnera,
        '               iz ugovora se nadje cena za odgovarajucu kombinaciju;
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
            If Microsoft.VisualBasic.Left(NhmRoba.Item("NHM"), 4) = "9921" Or Microsoft.VisualBasic.Left(NhmRoba.Item("NHM"), 4) = "9922" Or Microsoft.VisualBasic.Left(NhmRoba.Item("NHM"), 4) = "9931" Then
                '
                kStatus = "P"
            Else
                kStatus = "T"
            End If
            _mNHM = NhmRoba.Item("NHM")
        Next

        PrevozninaPoUgP = 0
        PrevozninaPoUgG = 0
        PrevozninaPoUgV = 0
        kPrevoznina = 0
        PrevozninaPoKolima = 0
        RacMasaPoKolima = 0

        If mManipulativnoMesto1 <> "" Then
            bStanicaTemp1 = mStanica1
            mStanica1 = mManipulativnoMesto1
        End If

        If mManipulativnoMesto2 <> "" Then
            bStanicaTemp2 = mStanica2
            mStanica2 = mManipulativnoMesto2
        End If


        If dtKola.Rows.Count > 0 Then
            'RedniBroj = 0

            For Each KolaRed In dtKola.Rows    ' pocetak petlje po kolima
                PrevozninaPoKolima = 0
                RacMasaPoKolima = 0


                ' ucitavanje polja
                'dodeliti vrednosti za promenljive
                IBK = KolaRed.Item("IndBrojKola")
                kStitna = KolaRed.Item("Stitna")     ' N - obicna,  D - stitna
                kTipKola = Left(KolaRed.Item("Tip"), 1)
                kVlasn = KolaRed.Item("Vlasnik")
                kBrOsov = KolaRed.Item("Osovine")
                kSer = KolaRed.Item("Serija")

                If kVlasn = "Z" Then
                    KolaZ = Microsoft.VisualBasic.Mid(IBK, 3, 2)
                Else
                    KolaZ = "00"
                End If

                Dim mOtpStP As String
                Dim mPrStP As String

                If kTipKola = "7" Then
                    TovarenaPrazna = "PK"
                Else
                    TovarenaPrazna = "TK"
                End If

                If kTipKola = 2 Or kTipKola = 4 Or kTipKola = 6 Then
                    kSpecKola = "D"
                Else
                    kSpecKola = "N"
                End If

                '##### dodato za unutrasnji saobracaj u bNadjiSveIzZSKoefPos
                ' umesto bVrstaSaobracaja - IzborSaobracaja
                ' umesto bVrstaStanice - "M"
                ' umesto mTarifa - "36"
                ' inace je:     IzborSaobracaja je 1,2,3,4   , 
                '               bVrstaSaobracaja je 0,1,2,...,9
                '               za bVrstaSaobracaja = 0 bValuta je "72", a za ostale je "17"
                'End If

                '##### dodato za unutrasnji saobracaj u bNadjiSveIzZSKoefPos



                Dim bSaobracaj As Integer
                If bValuta = "72" Then
                    bSaobracaj = 1
                ElseIf bValuta = "17" Then
                    bSaobracaj = 2
                End If
                Dim bRetValLok As String = ""

                Dim bNHM8606 As Boolean = False

                bProveri8606(_mNHM, bNHM8606, bNHMKao8606)

                If bNHM8606 Or bNHMKao8606 Then

                    Dim TovPraMP As String
                    Dim VlasnMP As String
                    bPraznaKaoRobaTar2015(mDatumKalk, NHM, TovPraMP, VlasnMP)
                    If TovPraMP = "" Then
                        TovPraMP = "PK"
                    End If
                    If VlasnMP = "" Then
                        VlasnMP = kVlasn
                    End If
                    bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", VlasnMP, _
                                          TovPraMP, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                          bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)
                    ' Tarifa 2015
                    'bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", kVlasn, _
                    '                      "PK", bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                    '                      bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)

                Else

                    Dim TovPraMP As String
                    Dim VlasnMP As String
                    bPraznaKaoRobaTar2015(mDatumKalk, _mNHM, TovPraMP, VlasnMP)
                    If TovPraMP = "" Then
                        TovPraMP = TovarenaPrazna
                    End If
                    If VlasnMP = "" Then
                        VlasnMP = kVlasn
                    End If
                    bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", VlasnMP, _
                                          TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                                          bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)
                    ' Tarifa 2015
                    'bNadjiSveIzZSKoefPos(bSaobracaj, "36", bVrstaPosiljke, "M", kVlasn, _
                    '                      TovarenaPrazna, bMinPrevoznina, bDodPrevoznina, bKoef, bKoefNak, bKoefInd, bKoefInd1, bKoefRid, _
                    '                      bPouzece, bPredujam, mDatumKalk, bRedovanOrocen, bValuta, bRetValLok)
                End If


                'If IzborSaobracaja = 2 Then
                '    Uprava = Microsoft.VisualBasic.Left(mOtpStanica, 2)
                '    OdStan = mStanica1
                '    DoStan = mStanica2
                'ElseIf IzborSaobracaja = 3 Then
                '    Uprava = Microsoft.VisualBasic.Left(mPrStanica, 2)
                '    OdStan = mStanica1
                '    DoStan = mStanica2
                'ElseIf IzborSaobracaja = 1 Then ' dodato formalno                    
                '    OdStan = mStanica1
                '    DoStan = mStanica2

                'End If
                'za testiranje vozova 

                Uprava = "72"
                kSifTar = "36"
                '_mNHM = NhmRoba.Item("NHM")

                ' KolaZ = "00"

                'If kStatus = "P" Then
                '    '???da li menja i saobracaj i upave?
                '    If IzborSaobracaja = 2 Then
                '        OdStan = mStanica2
                '        DoStan = mStanica1
                '    ElseIf IzborSaobracaja = 3 Then
                '        OdStan = mStanica1
                '        DoStan = mStanica2
                '    End If
                'End If

                If kStatus = "P" Then
                    OdStan = mStanica2
                    DoStan = mStanica1
                Else
                    OdStan = mStanica1
                    DoStan = mStanica2
                End If

                'k1NadjiSveKomPovl(mBrojUg, Aneks, mDatumKalk, kSifTar, bVrstaSaobracaja, kVlasn, KolaZ, kStatus, OdStan, DoStan, kNacinObrac, _
                '                   bValuta, kBrOsov, kSpecKola, kIznosMinPrev, Uprava, _mNHM, Pojed, Grupa, Voz, MasaU1, MasaU2, TipUTI, kPovVr)

                If mVrstaPrevoza = "P" Then
                    k11NadjiSveKomPovl(mBrojUg, Aneks, mDatumKalk, kSifTar, bVrstaSaobracaja, kVlasn, KolaZ, kStatus, OdStan, DoStan, _
                                      kNacinObrac, bValuta, kBrOsov, kSpecKola, kIznosMinPrev, Uprava, _mNHM, Pojed, Grupa, Voz, MasaU1, MasaU2, TipUTI, kPovVr)

                ElseIf mVrstaPrevoza = "G" Then
                    k1GNadjiSveKomPovl(mBrojUg, Aneks, mDatumKalk, kSifTar, bVrstaSaobracaja, kVlasn, KolaZ, kStatus, OdStan, DoStan, _
                                       kNacinObrac, bValuta, kBrOsov, kSpecKola, kIznosMinPrev, Uprava, _mNHM, Pojed, Grupa, Voz, MasaU1, MasaU2, TipUTI, kPovVr)
                Else
                    'bVrstaSaobracaja = 1   za probu
                    k1NadjiSveKomPovl(mBrojUg, Aneks, mDatumKalk, kSifTar, bVrstaSaobracaja, kVlasn, KolaZ, kStatus, OdStan, DoStan, _
                  kNacinObrac, bValuta, kBrOsov, kSpecKola, kIznosMinPrev, Uprava, _mNHM, Pojed, Grupa, Voz, MasaU1, MasaU2, TipUTI, kPovVr)
                End If


                Dim K20, K30, K40 As Int16

                K20 = 0
                K30 = 0
                K40 = 0

                Dim bRazred As Char

                Dim PV As String


                If dtNhm.Rows.Count > 0 Then
                    For Each NHMRed In dtNhm.Rows
                        If NHMRed.Item("IndBrojKola") = IBK Then
                            Dim RMNHM As Decimal = 0
                            MasaTemp = NHMRed.Item("Masa")
                            RMNHM = MasaTemp
                            bZaokruziMasuNa100k(RMNHM)
                            NHMRed.Item("RacMasaNHM") = RMNHM                          ' inicijalno; posle ce biti korigovano po kNacinObrac; 14.01.2015
                            RacMasaPoKolima = RacMasaPoKolima + MasaTemp
                            bZaokruziMasuNa100k(RacMasaPoKolima)
                            MasaTempT = RacMasaPoKolima / 1000
                            '                            bRazred = dtNhm.Rows(0).Item("Razred")
                            If kNacinObrac = 6 Then
                                ' nalazenje sifre kombinacije kontejnera
                                If NHMRed.Item("UTI") = "20" Then
                                    K20 = K20 + 1
                                ElseIf NHMRed.Item("UTI") = "30" Then
                                    K30 = K30 + 1
                                ElseIf NHMRed.Item("UTI") = "40" Then
                                    K40 = K40 + 1
                                End If
                            End If
                        End If
                    Next
                End If

                If kNacinObrac = 6 Then
                    Dim Kombinacija As String
                    Kombinacija = CType(K40, String) + CType(K30, String) + CType(K20, String)

                    If Kombinacija = "001" Then
                        TipUTI = "20"
                    ElseIf Kombinacija = "010" Then
                        TipUTI = "30"
                    ElseIf Kombinacija = "002" Then
                        TipUTI = "2*20"
                    ElseIf Kombinacija = "100" Then
                        TipUTI = "40"
                    ElseIf Kombinacija = "011" Then
                        TipUTI = "20 30"
                    ElseIf Kombinacija = "101" Then
                        TipUTI = "20 40"
                    ElseIf Kombinacija = "003" Then
                        TipUTI = "3*20"
                    ElseIf Kombinacija = "020" Then
                        TipUTI = "2*30"
                    ElseIf Kombinacija = "012" Then
                        TipUTI = "30 2*20"
                    ElseIf Kombinacija = "110" Then
                        TipUTI = "30 40"
                    ElseIf Kombinacija = "004" Then
                        TipUTI = "4*20"
                    ElseIf Kombinacija = "102" Then
                        TipUTI = "40 2*20"
                    ElseIf Kombinacija = "200" Then
                        TipUTI = "2*40"
                    End If

                End If


                '   RacMasaPoKolima = 0

                '   PrevozninaPoUg = 0

                '   ' zbog kNacinaObrac=4
                '            Dim bRazred As Char
                '            Dim PV As String
                '            ' zbog kNacinaObrac=4

                '            kNhm = NHMRed.Item("NHM")
                '            MasaTemp = NHMRed.Item("Masa")
                '            bZaokruziMasuNa100k(MasaTemp)
                '            kUTI = NHMRed.Item("UTI")
                '            bRazred = NHMRed.Item("R")
                '            '============================================
                '            RacMasaPoKolima = RacMasaPoKolima + MasaTemp
                '            'bZaokruziMasuNa100k(RacMasaPoKolima)
                '            MasaTempT = RacMasaPoKolima / 1000
                '            '============================================


                If Microsoft.VisualBasic.Left(kNhm, 4) = "9921" Or Microsoft.VisualBasic.Left(kNhm, 4) = "9922" Or Microsoft.VisualBasic.Left(NhmRoba.Item("NHM"), 4) = "9931" Then
                    kStatus = "P"
                End If


                '           'PO�INJE RA�UNANJE PREVOZNINE:

                '1. povlastica na cenu
                If kNacinObrac = 1 Then
                    ' racuna po redovnoj tarifi

                    ' 2. cena po toni
                ElseIf kNacinObrac = 2 Then
                    If mVrstaPrevoza = "P" Then
                        PrevozninaPoUg = MasaTempT * Pojed
                        bZaokruziNaDeseteNavise(PrevozninaPoUg)
                        bVozarinskiStavPoKolima = Pojed
                    End If
                    If mVrstaPrevoza = "G" Then
                        PrevozninaPoUg = MasaTempT * Grupa
                        bZaokruziNaDeseteNavise(PrevozninaPoUg)
                        bVozarinskiStavPoKolima = Grupa
                    End If
                    If mVrstaPrevoza = "V" Then
                        PrevozninaPoUg = MasaTempT * Voz
                        bZaokruziNaDeseteNavise(PrevozninaPoUg)
                        bVozarinskiStavPoKolima = Voz
                    End If

                    PrevozninaPoKolima = PrevozninaPoUg
                    KolaRed.Item("RacunskaMasa") = RacMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                    NHMRed.Item("RacMasaNHM") = RacMasaPoKolima                             '   14.01.2015
                    '3. cena po toni za odre�eni tonski stav ( date su cene za 10-to tonski stav, 15-to tonski stav, ... )
                ElseIf kNacinObrac = 3 Then
                    Aneks = 0
                    kNacinObrac = 0
                    kIznosMinPrev = 0
                    Pojed = 0
                    Grupa = 0
                    Voz = 0
                    MasaU1 = 0
                    MasaU2 = 0
                    TipUTI = ""
                    kPovVr = ""

                    If bVrstaSaobracaja = 0 Then
                        bNadjiMasuIStavDo25(RacMasaPoKolima, kIzlMasa, kSifraSt)
                    Else
                        bNadjiMasuIStavDo45(RacMasaPoKolima, kIzlMasa, kSifraSt)
                    End If

                    ' --------novo
                    RacMasaPoKolima = kIzlMasa
                    MasaTempT = RacMasaPoKolima / 1000
                    ' --------------
                    kTonskiStav = kSifraSt
                    k2NadjiSveKomPovl(mBrojUg, Aneks, mDatumKalk, kSifTar, bVrstaSaobracaja, kVlasn, KolaZ, kStatus, OdStan, DoStan, kNacinObrac, bValuta, _
                                    kBrOsov, kSpecKola, kIznosMinPrev, Uprava, _mNHM, Pojed, Grupa, Voz, MasaU1, MasaU1, TipUTI, kTonskiStav, kPovVr)

                    If kNacinObrac = 3 Then
                        If mVrstaPrevoza = "P" Then
                            PrevozninaPoUg = MasaTempT * Pojed
                            bZaokruziNaDeseteNavise(PrevozninaPoUg)
                            bVozarinskiStavPoKolima = Pojed
                        End If
                        If mVrstaPrevoza = "G" Then
                            PrevozninaPoUg = MasaTempT * Grupa
                            bZaokruziNaDeseteNavise(PrevozninaPoUg)
                            bVozarinskiStavPoKolima = Grupa
                        End If
                        If mVrstaPrevoza = "V" Then
                            PrevozninaPoUg = MasaTempT * Voz
                            bZaokruziNaDeseteNavise(PrevozninaPoUg)
                            bVozarinskiStavPoKolima = Voz
                            NHMRed.Item("VozarinskiStavNHM") = Voz
                        End If
                    ElseIf kNacinObrac = 0 Then
                        If bValuta = "72" Then
                            mTabelaCena = "121"
                        Else
                            mTabelaCena = "122"
                        End If

                        Dim RacunskiRazred As String
                        If bRazred = "3" Then
                            RacunskiRazred = "2"
                        Else
                            RacunskiRazred = bRazred
                        End If

                        bNadjiVozarinskiStav(mTabelaCena, mDatumKalk, MasaTempT, bTkm, RacunskiRazred, VozarinskiStav, PV)
                        PrevozninaPoUg = MasaTempT * VozarinskiStav
                        bVozarinskiStavPoKolima = VozarinskiStav
                    End If
                    PrevozninaPoKolima = PrevozninaPoUg
                    KolaRed.Item("RacunskaMasa") = RacMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                    NHMRed.Item("RacMasaNHM") = RacMasaPoKolima                             '   14.01.2015
                    '4. cena po kolima
                ElseIf kNacinObrac = 4 Then
                    If mVrstaPrevoza = "P" Then
                        PrevozninaPoUg = Pojed
                        bVozarinskiStavPoKolima = Pojed
                        bVozarinskiStavPoKolima = Pojed
                    End If
                    If mVrstaPrevoza = "G" Then
                        PrevozninaPoUg = Grupa
                        bVozarinskiStavPoKolima = Grupa
                        bVozarinskiStavPoKolima = Grupa
                    End If
                    If mVrstaPrevoza = "V" Then
                        PrevozninaPoUg = Voz
                        bVozarinskiStavPoKolima = Voz
                        bVozarinskiStavPoKolima = Voz
                    End If
                    PrevozninaPoKolima = PrevozninaPoUg
                    KolaRed.Item("RacunskaMasa") = RacMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                    NHMRed.Item("RacMasaNHM") = RacMasaPoKolima                             '   14.01.2015
                    ' 5. cena po kontejneru 
                ElseIf kNacinObrac = 5 Then
                    Aneks = 0
                    kNacinObrac = 0
                    kIznosMinPrev = 0
                    Pojed = 0
                    Grupa = 0
                    Voz = 0
                    MasaU1 = 0
                    MasaU2 = 0
                    kPovVr = ""
                    TipUTI = kUTI

                    If dtNhm.Rows.Count > 0 Then
                        For Each NHMRed In dtNhm.Rows
                            If NHMRed.Item("IndBrojKola") = IBK Then

                                MasaTemp = NHMRed.Item("Masa")
                                TipUTI = NHMRed.Item("UTI")
                                '           RacMasaPoKolima = RacMasaPoKolima + MasaTemp
                                '           bZaokruziMasuNa100k(RacMasaPoKolima)
                                'MasaTempT = RacMasaPoKolima / 1000

                                k3NadjiSveKomPovl(mBrojUg, Aneks, mDatumKalk, kSifTar, bVrstaSaobracaja, kVlasn, KolaZ, kStatus, OdStan, DoStan, kNacinObrac, bValuta, _
                                   kBrOsov, kSpecKola, kIznosMinPrev, Uprava, _mNHM, Pojed, Grupa, Voz, MasaU1, MasaU2, TipUTI, MasaTempT, kPovVr)

                                MasaUti = MasaTemp

                                Greska = "0"
                                If mVrstaPrevoza = "P" Then
                                    PrevozninaPoUg = Pojed
                                    bZaokruziNaDeseteNavise(PrevozninaPoUg)
                                    bVozarinskiStavPoKolima = Pojed
                                ElseIf mVrstaPrevoza = "G" Then
                                    PrevozninaPoUg = Grupa
                                    bZaokruziNaDeseteNavise(PrevozninaPoUg)
                                    bVozarinskiStavPoKolima = Grupa
                                ElseIf mVrstaPrevoza = "V" Then
                                    PrevozninaPoUg = Voz
                                    bZaokruziNaDeseteNavise(PrevozninaPoUg)
                                    bVozarinskiStavPoKolima = Voz
                                End If

                                KolaRed.Item("RacunskaMasa") = RacMasaPoKolima
                                KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                                KolaRed.Item("Prevoznina") = PrevozninaPoKolima
                                PrevozninaPoKolima = PrevozninaPoKolima + PrevozninaPoUg
                                NHMRed.Item("RacMasaNHM") = RacMasaPoKolima                             '   14.01.2015
                            End If
                        Next
                    End If
                    KolaRed.Item("Prevoznina") = PrevozninaPoKolima

                    ' 6. cena za kombinaciju kontejnera ( po kolima )
                ElseIf kNacinObrac = 6 Then

                    Aneks = 0
                    kNacinObrac = 0
                    kIznosMinPrev = 0
                    Pojed = 0
                    Grupa = 0
                    Voz = 0
                    MasaU1 = 0
                    MasaU2 = 0
                    kPovVr = ""
                    'kUTI = TipUTI ?????


                    PrevozninaPoUg = 0
                    k3NadjiSveKomPovl(mBrojUg, Aneks, mDatumKalk, kSifTar, bVrstaSaobracaja, kVlasn, KolaZ, kStatus, OdStan, DoStan, kNacinObrac, bValuta, _
                                                                                        kBrOsov, kSpecKola, kIznosMinPrev, Uprava, _mNHM, Pojed, Grupa, Voz, MasaU1, MasaU2, TipUTI, MasaTempT, kPovVr)
                    MasaUti = MasaTemp

                    'If Trim(TipUTI) = kUTI Then
                    'Greska = "0"

                    If mVrstaPrevoza = "P" Then
                        PrevozninaPoUg = Pojed
                        bZaokruziNaDeseteNavise(PrevozninaPoUg)
                        bVozarinskiStavPoKolima = Pojed
                    ElseIf mVrstaPrevoza = "G" Then
                        PrevozninaPoUg = Grupa
                        bZaokruziNaDeseteNavise(PrevozninaPoUg)
                        bVozarinskiStavPoKolima = Grupa
                    ElseIf mVrstaPrevoza = "V" Then
                        PrevozninaPoUg = Voz
                        bZaokruziNaDeseteNavise(PrevozninaPoUg)
                        bVozarinskiStavPoKolima = Voz
                    End If
                    PrevozninaPoKolima = PrevozninaPoUg
                    KolaRed.Item("RacunskaMasa") = RacMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima
                    NHMRed.Item("RacMasaNHM") = RacMasaPoKolima                             '   14.01.2015
                    ' cena po vozu
                ElseIf kNacinObrac = 7 Then

                    PrevozninaPoKolima = Voz
                    bVozarinskiStavPoKolima = Voz
                    KolaRed.Item("RacunskaMasa") = RacMasaPoKolima
                    KolaRed.Item("VozarinskiStav") = bVozarinskiStavPoKolima

                End If              'za na�in obra�una

                'If kIznosMinPrev > 0 Then
                '    bMinPrevoznina = kIznosMinPrev
                'End If


                If mBrojUg = "160000" Then            ' po Mandicevom tumacenju
                    bMinPrevoznina = 1657
                End If


                If PrevozninaPoKolima <= bMinPrevoznina Then
                    PrevozninaPoKolima = bMinPrevoznina
                End If

                If kNacinObrac <> 7 Then
                    kPrevoznina = kPrevoznina + PrevozninaPoKolima
                Else
                    kPrevoznina = PrevozninaPoKolima
                End If

                ' zbog upisa vozarinskog stava NHM
                For Each NHMRed In dtNhm.Rows
                    If NHMRed.Item("IndBrojKola") = IBK Then
                        NHMRed.Item("VozarinskiStavNHM") = bVozarinskiStavPoKolima
                    End If
                Next
                ' zbog upisa vozarinskog stava NHM


            Next                        'kraj petlje po kolima 


            ' ponovo petlja po kolima zbog marsrutnih vozova i zaokruzivanja zbira stvarnih masa itd.
            Dim bUkupnaStvarnaMasa As Decimal = 0
            Dim bRacunskaMasaPoPosiljci As Decimal = 0

            If (dtKola.Rows.Count > 6) And ((kNacinObrac = 2) Or (kNacinObrac = 3)) And ((mVrstaPrevoza = "V") Or (mVrstaPrevoza = "G")) Then


                For Each KolaRed In dtKola.Rows    ' pocetak petlje po kolima


                    PrevozninaPoKolima = 0
                    RacMasaPoKolima = 0

                    IBK = KolaRed.Item("IndBrojKola")
                    kStitna = KolaRed.Item("Stitna")     ' N - obicna,  D - stitna
                    kTipKola = Left(KolaRed.Item("Tip"), 1)
                    kVlasn = KolaRed.Item("Vlasnik")
                    kBrOsov = KolaRed.Item("Osovine")
                    kSer = KolaRed.Item("Serija")

                    If kVlasn = "Z" Then
                        KolaZ = Microsoft.VisualBasic.Mid(IBK, 3, 2)
                    Else
                        KolaZ = "00"
                    End If

                    Dim mOtpStP As String
                    Dim mPrStP As String

                    If kTipKola = "7" Then
                        TovarenaPrazna = "PK"
                    Else
                        TovarenaPrazna = "TK"
                    End If

                    If kTipKola = 2 Or kTipKola = 4 Or kTipKola = 6 Then
                        kSpecKola = "D"
                    Else
                        kSpecKola = "N"
                    End If


                    If dtNhm.Rows.Count > 0 Then
                        For Each NHMRed In dtNhm.Rows
                            If NHMRed.Item("IndBrojKola") = IBK Then
                                MasaTemp = NHMRed.Item("Masa")
                                NHMRed.Item("RacMasaNHM") = MasaTemp
                                KolaRed.Item("RacunskaMasa") = MasaTemp
                                If (mVrstaPrevoza = "G") Then
                                    KolaRed.Item("VozarinskiStav") = Grupa
                                ElseIf (mVrstaPrevoza = "V") Then
                                    KolaRed.Item("VozarinskiStav") = Voz
                                End If
                            Else
                                MasaTemp = 0
                            End If
                            bUkupnaStvarnaMasa = bUkupnaStvarnaMasa + MasaTemp
                        Next

                    End If
                Next


                bRacunskaMasaPoPosiljci = bUkupnaStvarnaMasa
                bZaokruziMasuNa100k(bRacunskaMasaPoPosiljci)

                bRacunskaMasa571 = bRacunskaMasaPoPosiljci

                Dim bCena As Decimal = 0

                If (mVrstaPrevoza = "G") Then
                    bCena = Grupa
                ElseIf (mVrstaPrevoza = "V") Then
                    bCena = Voz
                End If

                mPrevoznina = bRacunskaMasaPoPosiljci * bCena / 1000

                bZaokruziNaDeseteNavise(mPrevoznina)

                If mBrojUg = "506403" And _mNHM = "260300" Then             ' HCD 11.08.2015
                    bMinPrevoznina = 58
                End If

                If mPrevoznina <= bMinPrevoznina * dtKola.Rows.Count Then
                    mPrevoznina = bMinPrevoznina * dtKola.Rows.Count
                End If

            End If
            ' ponovo petlja po kolima zbog marsrutnih vozova i zaokruzivanja zbira stvarnih masa itd.
        End If

        If DbVeza.State = ConnectionState.Open Then
            DbVeza.Close()
        End If
        DbVeza.Close()
        mPrevoznina = kPrevoznina

        If (Ug_Greska = "D") Or (kNacinObrac = 1) Then

            If bVrstaSaobracaja = 0 Then
                bValuta = "72"
                mTabelaCena = "121"
            Else
                bValuta = "17"
                mTabelaCena = "122"
            End If

            If bTarifa72 = 0 Then
                bNadjiPrevozninu00L(mTabelaCena, mPrevoznina)
            Else
                bNadjiPrevozninuNeNulaL(mTabelaCena, mPrevoznina)
            End If

            If kNacinObrac = 1 Then
                If mVrstaPrevoza = "P" Then
                    mPrevoznina = mPrevoznina * Pojed
                ElseIf mVrstaPrevoza = "G" Then
                    mPrevoznina = mPrevoznina * Grupa
                ElseIf mVrstaPrevoza = "V" Then
                    mPrevoznina = mPrevoznina * Voz
                End If
                bZaokruziNaDeseteNavise(mPrevoznina)
            End If

        End If

        If mManipulativnoMesto1 <> "" Then
            mStanica1 = bStanicaTemp1
        End If

        If mManipulativnoMesto2 <> "" Then
            mStanica2 = bStanicaTemp2
        End If

    End Sub    '******************************************************

    Public Sub k1NadjiSveKomPovl(ByVal inBrojUgovora As String, _
                              ByRef outAneks As Integer, _
                              ByVal inDatumTarifiranja As Date, _
                              ByVal inTarifa As String, _
                              ByVal inSaobracaj As Integer, _
                              ByVal inVlasnistvoKola As String, _
                              ByVal inKolaZemlja As String, _
                              ByVal inStatus As String, _
                              ByVal inOdStanica As String, _
                              ByVal inDoStanica As String, _
                              ByRef outNacinObrade As Integer, _
                              ByVal inSifraValute As Integer, _
                              ByVal inBrojOsovina As String, _
                              ByVal inSpecijalnaKola As Char, _
                              ByRef outMinPrevIznos As Decimal, _
                              ByVal inUprava As String, _
                              ByVal in_mNHM As String, _
                              ByRef outPojedinacna As Decimal, _
                              ByRef outGrupa As Decimal, _
                              ByRef outVoz As Decimal, _
                              ByRef outBMasaUti1 As Decimal, _
                              ByRef outBMasaUti2 As Decimal, _
                              ByRef outTipUTI As String, _
                              ByRef outPovVred As String)

        ' TovarenaPrazna - tovarena, prazna, tovaren UTI, prazan UTI
        outPovVred = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        'Dim spKomanda As New SqlClient.SqlCommand("radnik.k1NadjiSveKomPovl", DbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.k1b72NadjiSveKomPovl", DbVeza)
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

        Dim ulOdStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOdStanica", SqlDbType.Char, 5))
        ulOdStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOdStanica").Value = inOdStanica

        Dim ulDoStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDoStanica", SqlDbType.Char, 5))
        ulDoStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDoStanica").Value = inDoStanica

        Dim izlNacinObrade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNacinObrade", SqlDbType.Int))
        izlNacinObrade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNacinObrade").Value = outNacinObrade

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSaobracaj").Value = inSaobracaj

        Dim ulValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraValute", SqlDbType.Int))
        ulValuta.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraValute").Value = inSifraValute

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 3))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulKolaZemlja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inKolaZemlja", SqlDbType.Char, 2))
        ulKolaZemlja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inKolaZemlja").Value = inKolaZemlja

        Dim ulStatus As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStatus", SqlDbType.Char, 1))
        ulStatus.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStatus").Value = inStatus

        'Dim ulTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTonskiStav", SqlDbType.Char, 2))
        'ulTonskiStav.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inTonskiStav").Value = inTonskiStav

        'Dim ulSerija As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSerija", SqlDbType.Char, 3))
        'ulSerija.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inSerija").Value = inSerija

        Dim ulBrojOsovina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojOsovina", SqlDbType.Char, 1))
        ulBrojOsovina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojOsovina").Value = inBrojOsovina

        Dim ulSpecijalnaKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSpecijalnaKola", SqlDbType.Char, 1))
        ulSpecijalnaKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSpecijalnaKola").Value = inSpecijalnaKola

        Dim izlMinPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinPrevozninaIznos", SqlDbType.Decimal))
        izlMinPrevoznina.Size = 9
        izlMinPrevoznina.Precision = 10
        izlMinPrevoznina.Scale = 2
        izlMinPrevoznina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinPrevozninaIznos").Value = outMinPrevIznos

        Dim ulUpr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUprava", SqlDbType.Char, 2))
        ulUpr.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUprava").Value = inUprava

        Dim ulNHM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@in_mNHM", SqlDbType.Char, 6))
        ulNHM.Direction = ParameterDirection.Input
        spKomanda.Parameters("@in_mNHM").Value = in_mNHM

        Dim izlPojedinacna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPojedinacna", SqlDbType.Decimal))
        izlPojedinacna.Size = 9
        izlPojedinacna.Precision = 10
        izlPojedinacna.Scale = 2
        izlPojedinacna.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPojedinacna").Value = outPojedinacna

        Dim izlGrupa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrupa", SqlDbType.Decimal))
        izlGrupa.Size = 9
        izlGrupa.Precision = 10
        izlGrupa.Scale = 2
        izlGrupa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outGrupa").Value = outGrupa

        Dim izlVoz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVoz", SqlDbType.Decimal))
        izlVoz.Size = 9
        izlVoz.Precision = 10
        izlVoz.Scale = 2
        izlVoz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVoz").Value = outVoz

        Dim izlMasa1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti1", SqlDbType.Decimal))
        izlMasa1.Size = 5
        izlMasa1.Precision = 5
        izlMasa1.Scale = 1
        izlMasa1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti1").Value = outBMasaUti1

        Dim izlMasa2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti2", SqlDbType.Decimal))
        izlMasa2.Size = 5
        izlMasa2.Precision = 5
        izlMasa2.Scale = 1
        izlMasa2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti2").Value = outBMasaUti2

        Dim izlTipUTI As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTipUTI", SqlDbType.Char, 6))
        izlTipUTI.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTipUTI").Value = outTipUTI

        'Dim izTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTonskiStav", SqlDbType.Char, 2))
        'izTonskiStav.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outTonskiStav").Value = outTonskiStav

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
            outAneks = spKomanda.Parameters("@outAneks").Value
            outNacinObrade = spKomanda.Parameters("@outNacinObrade").Value
            outPojedinacna = spKomanda.Parameters("@outPojedinacna").Value
            outGrupa = spKomanda.Parameters("@outGrupa").Value
            outVoz = spKomanda.Parameters("@outVoz").Value
            outMinPrevIznos = spKomanda.Parameters("@outMinPrevozninaIznos").Value
            outBMasaUti1 = spKomanda.Parameters("@outBMasaUti1").Value
            outBMasaUti2 = spKomanda.Parameters("@outBMasaUti2").Value
            outTipUTI = spKomanda.Parameters("@outTipUTI").Value
            'outTonskiStav = spKomanda.Parameters("@outTonskiStav").Value
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
    Public Sub k3NadjiSveKomPovl(ByVal inBrojUgovora As String, _
                                      ByRef outAneks As Integer, _
                                      ByVal inDatumTarifiranja As Date, _
                                      ByVal inTarifa As String, _
                                      ByVal inSaobracaj As Integer, _
                                      ByVal inVlasnistvoKola As String, _
                                      ByVal inKolaZemlja As String, _
                                      ByVal inStatus As String, _
                                      ByVal inOdStanica As String, _
                                      ByVal inDoStanica As String, _
                                      ByRef outNacinObrade As Integer, _
                                      ByVal inSifraValute As Integer, _
                                      ByVal inBrojOsovina As Char, _
                                      ByVal inSpecijalnaKola As Char, _
                                      ByRef outMinPrevIznos As Decimal, _
                                      ByVal inUprava As String, _
                                      ByVal in_mNHM As String, _
                                      ByRef outPojedinacna As Decimal, _
                                      ByRef outGrupa As Decimal, _
                                      ByRef outVoz As Decimal, _
                                      ByRef outBMasaUti1 As Decimal, _
                                      ByRef outBMasaUti2 As Decimal, _
                                      ByVal inTipUTI As String, _
                                      ByVal inMasa As Decimal, _
                                      ByRef outPovVred As String)

        ' TovarenaPrazna - tovarena, prazna, tovaren UTI, prazan UTI
        outPovVred = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        'Dim spKomanda As New SqlClient.SqlCommand("k3NadjiSveKomPovl", DbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.k3b72NadjiSveKomPovl", DbVeza)
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

        Dim ulOdStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOdStanica", SqlDbType.Char, 5))
        ulOdStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOdStanica").Value = inOdStanica

        Dim ulDoStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDoStanica", SqlDbType.Char, 5))
        ulDoStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDoStanica").Value = inDoStanica

        Dim izlNacinObrade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNacinObrade", SqlDbType.Int))
        izlNacinObrade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNacinObrade").Value = outNacinObrade

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSaobracaj").Value = inSaobracaj

        Dim ulValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraValute", SqlDbType.Int))
        ulValuta.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraValute").Value = inSifraValute

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 3))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulKolaZemlja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inKolaZemlja", SqlDbType.Char, 2))
        ulKolaZemlja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inKolaZemlja").Value = inKolaZemlja

        Dim ulStatus As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStatus", SqlDbType.Char, 1))
        ulStatus.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStatus").Value = inStatus

        'Dim ulTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTonskiStav", SqlDbType.Char, 2))
        'ulTonskiStav.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inTonskiStav").Value = inTonskiStav

        'Dim ulSerija As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSerija", SqlDbType.Char, 3))
        'ulSerija.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inSerija").Value = inSerija

        Dim ulBrojOsovina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojOsovina", SqlDbType.Char, 1))
        ulBrojOsovina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojOsovina").Value = inBrojOsovina

        Dim ulSpecijalnaKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSpecijalnaKola", SqlDbType.Char, 1))
        ulSpecijalnaKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSpecijalnaKola").Value = inSpecijalnaKola

        Dim izlMinPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinPrevozninaIznos", SqlDbType.Decimal))
        izlMinPrevoznina.Size = 9
        izlMinPrevoznina.Precision = 10
        izlMinPrevoznina.Scale = 2
        izlMinPrevoznina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinPrevozninaIznos").Value = outMinPrevIznos

        Dim ulUpr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUprava", SqlDbType.Char, 2))
        ulUpr.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUprava").Value = inUprava

        Dim ulNHM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@in_mNHM", SqlDbType.Char, 6))
        ulNHM.Direction = ParameterDirection.Input
        spKomanda.Parameters("@in_mNHM").Value = in_mNHM

        Dim izlPojedinacna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPojedinacna", SqlDbType.Decimal))
        izlPojedinacna.Size = 9
        izlPojedinacna.Precision = 10
        izlPojedinacna.Scale = 2
        izlPojedinacna.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPojedinacna").Value = outPojedinacna

        Dim izlGrupa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrupa", SqlDbType.Decimal))
        izlGrupa.Size = 9
        izlGrupa.Precision = 10
        izlGrupa.Scale = 2
        izlGrupa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outGrupa").Value = outGrupa

        Dim izlVoz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVoz", SqlDbType.Decimal))
        izlVoz.Size = 9
        izlVoz.Precision = 10
        izlVoz.Scale = 2
        izlVoz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVoz").Value = outVoz

        Dim izlMasa1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti1", SqlDbType.Decimal))
        izlMasa1.Size = 5
        izlMasa1.Precision = 5
        izlMasa1.Scale = 1
        izlMasa1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti1").Value = outBMasaUti1

        Dim izlMasa2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti2", SqlDbType.Decimal))
        izlMasa2.Size = 5
        izlMasa2.Precision = 5
        izlMasa2.Scale = 1
        izlMasa2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti2").Value = outBMasaUti2

        Dim ulTipUTI As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTipUTI", SqlDbType.Char, 6))
        ulTipUTI.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTipUTI").Value = inTipUTI

        'Dim izTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTonskiStav", SqlDbType.Char, 2))
        'izTonskiStav.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outTonskiStav").Value = outTonskiStav

        Dim ulMasa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inMasa", SqlDbType.Decimal))
        ulMasa.Size = 5
        ulMasa.Precision = 5
        ulMasa.Scale = 1
        ulMasa.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inMasa").Value = inMasa

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
            outAneks = spKomanda.Parameters("@outAneks").Value
            outNacinObrade = spKomanda.Parameters("@outNacinObrade").Value
            outPojedinacna = spKomanda.Parameters("@outPojedinacna").Value
            outGrupa = spKomanda.Parameters("@outGrupa").Value
            outVoz = spKomanda.Parameters("@outVoz").Value
            outMinPrevIznos = spKomanda.Parameters("@outMinPrevozninaIznos").Value
            outBMasaUti1 = spKomanda.Parameters("@outBMasaUti1").Value
            outBMasaUti2 = spKomanda.Parameters("@outBMasaUti2").Value
            'outTipUTI = spKomanda.Parameters("@outTipUTI").Value
            'outTonskiStav = spKomanda.Parameters("@outTonskiStav").Value
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
    Public Sub k2NadjiSveKomPovl(ByVal inBrojUgovora As String, _
                                      ByRef outAneks As Integer, _
                                      ByVal inDatumTarifiranja As Date, _
                                      ByVal inTarifa As String, _
                                      ByVal inSaobracaj As Integer, _
                                      ByVal inVlasnistvoKola As String, _
                                      ByVal inKolaZemlja As String, _
                                      ByVal inStatus As String, _
                                      ByVal inOdStanica As String, _
                                      ByVal inDoStanica As String, _
                                      ByRef outNacinObrade As Integer, _
                                      ByVal inSifraValute As Integer, _
                                      ByVal inBrojOsovina As Char, _
                                      ByVal inSpecijalnaKola As Char, _
                                      ByRef outMinPrevIznos As Decimal, _
                                      ByVal inUprava As String, _
                                      ByVal in_mNHM As String, _
                                      ByRef outPojedinacna As Decimal, _
                                      ByRef outGrupa As Decimal, _
                                      ByRef outVoz As Decimal, _
                                      ByRef outBMasaUti1 As Decimal, _
                                      ByRef outBMasaUti2 As Decimal, _
                                      ByRef outTipUTI As String, _
                                      ByVal inTonskiStav As String, _
                                      ByRef outPovVred As String)

        ' TovarenaPrazna - tovarena, prazna, tovaren UTI, prazan UTI
        outPovVred = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        'Dim spKomanda As New SqlClient.SqlCommand("k2NadjiSveKomPovl", DbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.k2b72NadjiSveKomPovl", DbVeza)
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

        Dim ulOdStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOdStanica", SqlDbType.Char, 5))
        ulOdStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOdStanica").Value = inOdStanica

        Dim ulDoStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDoStanica", SqlDbType.Char, 5))
        ulDoStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDoStanica").Value = inDoStanica

        Dim izlNacinObrade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNacinObrade", SqlDbType.Int))
        izlNacinObrade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNacinObrade").Value = outNacinObrade

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSaobracaj").Value = inSaobracaj

        Dim ulValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraValute", SqlDbType.Int))
        ulValuta.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraValute").Value = inSifraValute

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 3))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulKolaZemlja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inKolaZemlja", SqlDbType.Char, 2))
        ulKolaZemlja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inKolaZemlja").Value = inKolaZemlja

        Dim ulStatus As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStatus", SqlDbType.Char, 1))
        ulStatus.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStatus").Value = inStatus

        Dim ulTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTonskiStav", SqlDbType.Char, 2))
        ulTonskiStav.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inTonskiStav").Value = inTonskiStav

        'Dim ulSerija As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSerija", SqlDbType.Char, 3))
        'ulSerija.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inSerija").Value = inSerija

        Dim ulBrojOsovina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojOsovina", SqlDbType.Char, 1))
        ulBrojOsovina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojOsovina").Value = inBrojOsovina

        Dim ulSpecijalnaKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSpecijalnaKola", SqlDbType.Char, 1))
        ulSpecijalnaKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSpecijalnaKola").Value = inSpecijalnaKola

        Dim izlMinPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinPrevozninaIznos", SqlDbType.Decimal))
        izlMinPrevoznina.Size = 9
        izlMinPrevoznina.Precision = 10
        izlMinPrevoznina.Scale = 2
        izlMinPrevoznina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinPrevozninaIznos").Value = outMinPrevIznos

        Dim ulUpr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUprava", SqlDbType.Char, 2))
        ulUpr.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUprava").Value = inUprava

        Dim ulNHM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@in_mNHM", SqlDbType.Char, 6))
        ulNHM.Direction = ParameterDirection.Input
        spKomanda.Parameters("@in_mNHM").Value = in_mNHM

        Dim izlPojedinacna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPojedinacna", SqlDbType.Decimal))
        izlPojedinacna.Size = 9
        izlPojedinacna.Precision = 10
        izlPojedinacna.Scale = 2
        izlPojedinacna.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPojedinacna").Value = outPojedinacna

        Dim izlGrupa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrupa", SqlDbType.Decimal))
        izlGrupa.Size = 9
        izlGrupa.Precision = 10
        izlGrupa.Scale = 2
        izlGrupa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outGrupa").Value = outGrupa

        Dim izlVoz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVoz", SqlDbType.Decimal))
        izlVoz.Size = 9
        izlVoz.Precision = 10
        izlVoz.Scale = 2
        izlVoz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVoz").Value = outVoz

        Dim izlMasa1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti1", SqlDbType.Decimal))
        izlMasa1.Size = 5
        izlMasa1.Precision = 4
        izlMasa1.Scale = 1
        izlMasa1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti1").Value = outBMasaUti1

        Dim izlMasa2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti2", SqlDbType.Decimal))
        izlMasa2.Size = 5
        izlMasa2.Precision = 4
        izlMasa2.Scale = 1
        izlMasa2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti2").Value = outBMasaUti2

        Dim izlTipUTI As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTipUTI", SqlDbType.Char, 6))
        izlTipUTI.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTipUTI").Value = outTipUTI

        'Dim izTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTonskiStav", SqlDbType.Char, 2))
        'izTonskiStav.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outTonskiStav").Value = outTonskiStav

        Dim izlPovVred As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPovVred", SqlDbType.Char, 50))
        izlPovVred.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPovVred").Value = outPovVred

        Try
            If DbVeza.State = ConnectionState.Closed Then
                DbVeza.Open()
            End If

            spKomanda.ExecuteScalar()
            outAneks = spKomanda.Parameters("@outAneks").Value
            outNacinObrade = spKomanda.Parameters("@outNacinObrade").Value
            outPojedinacna = spKomanda.Parameters("@outPojedinacna").Value
            outGrupa = spKomanda.Parameters("@outGrupa").Value
            outVoz = spKomanda.Parameters("@outVoz").Value
            outMinPrevIznos = spKomanda.Parameters("@outMinPrevozninaIznos").Value
            outBMasaUti1 = spKomanda.Parameters("@outbMasaUti1").Value
            outBMasaUti2 = spKomanda.Parameters("@outbMasaUti2").Value
            outTipUTI = spKomanda.Parameters("@outTipUTI").Value
            'outTonskiStav = spKomanda.Parameters("@outTonskiStav").Value
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
    Public Sub k11NadjiSveKomPovl(ByVal inBrojUgovora As String, _
                                      ByRef outAneks As Integer, _
                                      ByVal inDatumTarifiranja As Date, _
                                      ByVal inTarifa As String, _
                                      ByVal inSaobracaj As Integer, _
                                      ByVal inVlasnistvoKola As String, _
                                      ByVal inKolaZemlja As String, _
                                      ByVal inStatus As String, _
                                      ByVal inOdStanica As String, _
                                      ByVal inDoStanica As String, _
                                      ByRef outNacinObrade As Integer, _
                                      ByVal inSifraValute As Integer, _
                                      ByVal inBrojOsovina As String, _
                                      ByVal inSpecijalnaKola As Char, _
                                      ByRef outMinPrevIznos As Decimal, _
                                      ByVal inUprava As String, _
                                      ByVal in_mNHM As String, _
                                      ByRef outPojedinacna As Decimal, _
                                      ByRef outGrupa As Decimal, _
                                      ByRef outVoz As Decimal, _
                                      ByRef outBMasaUti1 As Decimal, _
                                      ByRef outBMasaUti2 As Decimal, _
                                      ByRef outTipUTI As String, _
                                      ByRef outPovVred As String)

        ' TovarenaPrazna - tovarena, prazna, tovaren UTI, prazan UTI
        outPovVred = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        'Dim spKomanda As New SqlClient.SqlCommand("k11NadjiSveKomPovl", DbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.k11b72NadjiSveKomPovl", DbVeza)
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

        Dim ulOdStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOdStanica", SqlDbType.Char, 5))
        ulOdStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOdStanica").Value = inOdStanica

        Dim ulDoStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDoStanica", SqlDbType.Char, 5))
        ulDoStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDoStanica").Value = inDoStanica

        Dim izlNacinObrade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNacinObrade", SqlDbType.Int))
        izlNacinObrade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNacinObrade").Value = outNacinObrade

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSaobracaj").Value = inSaobracaj

        Dim ulValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraValute", SqlDbType.Int))
        ulValuta.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraValute").Value = inSifraValute

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 3))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulKolaZemlja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inKolaZemlja", SqlDbType.Char, 2))
        ulKolaZemlja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inKolaZemlja").Value = inKolaZemlja

        Dim ulStatus As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStatus", SqlDbType.Char, 1))
        ulStatus.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStatus").Value = inStatus

        'Dim ulTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTonskiStav", SqlDbType.Char, 2))
        'ulTonskiStav.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inTonskiStav").Value = inTonskiStav

        'Dim ulSerija As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSerija", SqlDbType.Char, 3))
        'ulSerija.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inSerija").Value = inSerija

        Dim ulBrojOsovina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojOsovina", SqlDbType.Char, 1))
        ulBrojOsovina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojOsovina").Value = inBrojOsovina

        Dim ulSpecKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSpecijalnaKola", SqlDbType.Char, 1))
        ulSpecKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSpecijalnaKola").Value = inSpecijalnaKola

        Dim izlMinPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinPrevozninaIznos", SqlDbType.Decimal))
        izlMinPrevoznina.Size = 9
        izlMinPrevoznina.Precision = 10
        izlMinPrevoznina.Scale = 2
        izlMinPrevoznina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinPrevozninaIznos").Value = outMinPrevIznos

        Dim ulUpr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUprava", SqlDbType.Char, 2))
        ulUpr.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUprava").Value = inUprava

        Dim ulNHM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@in_mNHM", SqlDbType.Char, 6))
        ulNHM.Direction = ParameterDirection.Input
        spKomanda.Parameters("@in_mNHM").Value = in_mNHM

        Dim izlPojedinacna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPojedinacna", SqlDbType.Decimal))
        izlPojedinacna.Size = 9
        izlPojedinacna.Precision = 10
        izlPojedinacna.Scale = 2
        izlPojedinacna.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPojedinacna").Value = outPojedinacna

        Dim izlGrupa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrupa", SqlDbType.Decimal))
        izlGrupa.Size = 9
        izlGrupa.Precision = 10
        izlGrupa.Scale = 2
        izlGrupa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outGrupa").Value = outGrupa

        Dim izlVoz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVoz", SqlDbType.Decimal))
        izlVoz.Size = 9
        izlVoz.Precision = 10
        izlVoz.Scale = 2
        izlVoz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVoz").Value = outVoz

        Dim izlMasa1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti1", SqlDbType.Decimal))
        izlMasa1.Size = 5
        izlMasa1.Precision = 5
        izlMasa1.Scale = 1
        izlMasa1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti1").Value = outBMasaUti1

        Dim izlMasa2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti2", SqlDbType.Decimal))
        izlMasa2.Size = 5
        izlMasa2.Precision = 5
        izlMasa2.Scale = 1
        izlMasa2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti2").Value = outBMasaUti2

        Dim izlTipUTI As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTipUTI", SqlDbType.Char, 6))
        izlTipUTI.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTipUTI").Value = outTipUTI

        'Dim izTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTonskiStav", SqlDbType.Char, 2))
        'izTonskiStav.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outTonskiStav").Value = outTonskiStav

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
            outAneks = spKomanda.Parameters("@outAneks").Value
            outNacinObrade = spKomanda.Parameters("@outNacinObrade").Value
            outPojedinacna = spKomanda.Parameters("@outPojedinacna").Value
            outGrupa = spKomanda.Parameters("@outGrupa").Value
            outVoz = spKomanda.Parameters("@outVoz").Value
            outMinPrevIznos = spKomanda.Parameters("@outMinPrevozninaIznos").Value
            outBMasaUti1 = spKomanda.Parameters("@outBMasaUti1").Value
            outBMasaUti2 = spKomanda.Parameters("@outBMasaUti2").Value
            outTipUTI = spKomanda.Parameters("@outTipUTI").Value
            'outTonskiStav = spKomanda.Parameters("@outTonskiStav").Value
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

    Public Sub k1GNadjiSveKomPovl(ByVal inBrojUgovora As String, _
                                         ByRef outAneks As Integer, _
                                         ByVal inDatumTarifiranja As Date, _
                                         ByVal inTarifa As String, _
                                         ByVal inSaobracaj As Integer, _
                                         ByVal inVlasnistvoKola As String, _
                                         ByVal inKolaZemlja As String, _
                                         ByVal inStatus As String, _
                                         ByVal inOdStanica As String, _
                                         ByVal inDoStanica As String, _
                                         ByRef outNacinObrade As Integer, _
                                         ByVal inSifraValute As Integer, _
                                         ByVal inBrojOsovina As String, _
                                         ByVal inSpecijalnaKola As Char, _
                                         ByRef outMinPrevIznos As Decimal, _
                                         ByVal inUprava As String, _
                                         ByVal in_mNHM As String, _
                                         ByRef outPojedinacna As Decimal, _
                                         ByRef outGrupa As Decimal, _
                                         ByRef outVoz As Decimal, _
                                         ByRef outBMasaUti1 As Decimal, _
                                         ByRef outBMasaUti2 As Decimal, _
                                         ByRef outTipUTI As String, _
                                         ByRef outPovVred As String)

        ' TovarenaPrazna - tovarena, prazna, tovaren UTI, prazan UTI
        outPovVred = ""
        If DbVeza.State = ConnectionState.Closed Then
            DbVeza.Open()
        End If
        'Dim spKomanda As New SqlClient.SqlCommand("k1GNadjiSveKomPovl", DbVeza)
        Dim spKomanda As New SqlClient.SqlCommand("roba1708.k1Gb72NadjiSveKomPovl", DbVeza)
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

        Dim ulOdStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inOdStanica", SqlDbType.Char, 5))
        ulOdStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inOdStanica").Value = inOdStanica

        Dim ulDoStan As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inDoStanica", SqlDbType.Char, 5))
        ulDoStan.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inDoStanica").Value = inDoStanica

        Dim izlNacinObrade As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outNacinObrade", SqlDbType.Int))
        izlNacinObrade.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outNacinObrade").Value = outNacinObrade

        Dim ulVrstaSaobracaja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSaobracaj", SqlDbType.Int))
        ulVrstaSaobracaja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSaobracaj").Value = inSaobracaj

        Dim ulValuta As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSifraValute", SqlDbType.Int))
        ulValuta.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSifraValute").Value = inSifraValute

        Dim ulVlasnistvoKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inVlasnistvoKola", SqlDbType.Char, 3))
        ulVlasnistvoKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inVlasnistvoKola").Value = inVlasnistvoKola

        Dim ulKolaZemlja As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inKolaZemlja", SqlDbType.Char, 2))
        ulKolaZemlja.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inKolaZemlja").Value = inKolaZemlja

        Dim ulStatus As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inStatus", SqlDbType.Char, 1))
        ulStatus.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inStatus").Value = inStatus

        'Dim ulTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inTonskiStav", SqlDbType.Char, 2))
        'ulTonskiStav.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inTonskiStav").Value = inTonskiStav

        'Dim ulSerija As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSerija", SqlDbType.Char, 3))
        'ulSerija.Direction = ParameterDirection.Input
        'spKomanda.Parameters("@inSerija").Value = inSerija

        Dim ulBrojOsovina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inBrojOsovina", SqlDbType.Char, 1))
        ulBrojOsovina.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inBrojOsovina").Value = inBrojOsovina

        Dim ulSpecKola As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inSpecijalnaKola", SqlDbType.Char, 1))
        ulSpecKola.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inSpecijalnaKola").Value = inSpecijalnaKola

        Dim izlMinPrevoznina As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outMinPrevozninaIznos", SqlDbType.Decimal))
        izlMinPrevoznina.Size = 9
        izlMinPrevoznina.Precision = 10
        izlMinPrevoznina.Scale = 2
        izlMinPrevoznina.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outMinPrevozninaIznos").Value = outMinPrevIznos

        Dim ulUpr As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@inUprava", SqlDbType.Char, 2))
        ulUpr.Direction = ParameterDirection.Input
        spKomanda.Parameters("@inUprava").Value = inUprava

        Dim ulNHM As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@in_mNHM", SqlDbType.Char, 6))
        ulNHM.Direction = ParameterDirection.Input
        spKomanda.Parameters("@in_mNHM").Value = in_mNHM

        Dim izlPojedinacna As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outPojedinacna", SqlDbType.Decimal))
        izlPojedinacna.Size = 9
        izlPojedinacna.Precision = 10
        izlPojedinacna.Scale = 2
        izlPojedinacna.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outPojedinacna").Value = outPojedinacna

        Dim izlGrupa As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outGrupa", SqlDbType.Decimal))
        izlGrupa.Size = 9
        izlGrupa.Precision = 10
        izlGrupa.Scale = 2
        izlGrupa.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outGrupa").Value = outGrupa

        Dim izlVoz As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outVoz", SqlDbType.Decimal))
        izlVoz.Size = 9
        izlVoz.Precision = 10
        izlVoz.Scale = 2
        izlVoz.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outVoz").Value = outVoz

        Dim izlMasa1 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti1", SqlDbType.Decimal))
        izlMasa1.Size = 5
        izlMasa1.Precision = 5
        izlMasa1.Scale = 1
        izlMasa1.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti1").Value = outBMasaUti1

        Dim izlMasa2 As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outbMasaUti2", SqlDbType.Decimal))
        izlMasa2.Size = 5
        izlMasa2.Precision = 5
        izlMasa2.Scale = 1
        izlMasa2.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outbMasaUti2").Value = outBMasaUti2

        Dim izlTipUTI As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTipUTI", SqlDbType.Char, 6))
        izlTipUTI.Direction = ParameterDirection.Output
        spKomanda.Parameters("@outTipUTI").Value = outTipUTI

        'Dim izTonskiStav As SqlClient.SqlParameter = spKomanda.Parameters.Add(New SqlClient.SqlParameter("@outTonskiStav", SqlDbType.Char, 2))
        'izTonskiStav.Direction = ParameterDirection.Output
        'spKomanda.Parameters("@outTonskiStav").Value = outTonskiStav

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
            outAneks = spKomanda.Parameters("@outAneks").Value
            outNacinObrade = spKomanda.Parameters("@outNacinObrade").Value
            outPojedinacna = spKomanda.Parameters("@outPojedinacna").Value
            outGrupa = spKomanda.Parameters("@outGrupa").Value
            outVoz = spKomanda.Parameters("@outVoz").Value
            outMinPrevIznos = spKomanda.Parameters("@outMinPrevozninaIznos").Value
            outBMasaUti1 = spKomanda.Parameters("@outBMasaUti1").Value
            outBMasaUti2 = spKomanda.Parameters("@outBMasaUti2").Value
            outTipUTI = spKomanda.Parameters("@outTipUTI").Value
            'outTonskiStav = spKomanda.Parameters("@outTonskiStav").Value
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
End Module
