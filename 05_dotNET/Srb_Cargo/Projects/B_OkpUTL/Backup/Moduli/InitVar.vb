Module InitVar
    Friend mPreviewDL As String = "D"
    Friend bVozarinskiStavPoKolima As Decimal = 0
    Friend bRacunskaMasaPoKolima As Decimal = 0
    Friend pubSerijaKola As String
    Friend pubIBK As String
    Friend webTLID As String
    Friend xml_ZemljaOtp, xml_StanicaOtp, xml_NazivStaniceOtp, xml_OperaterOtp, xml_ZemljaPr, _
           xml_StanicaPr, xml_NazivStanicePr As String
    Friend xml_BrojCimOtp, xml_tara, xml_netoInt As Int32
    Friend xml_osovine As Int16
    Friend xml_GrTov, xml_netoDec As Decimal
    Friend xml_R16a, xml_R16b, xml_R16c, xml_R16d, xml_R16god, xml_R16e, xml_R20a, xml_R20b, xml_R20c, _
           xml_R20d, xml_R20f, xml_R10a, xml_R10b, xml_R10c, xml_R10d, xml_R12, xml_R29a, xml_R29b, _
           xml_R50, xml_R57a, xml_R57b, xml_R57a1, xml_R57a2, xml_R57b1, xml_R57b1a, xml_R57b2, xml_R57b2a As String
    Friend xml_R2, xml_R1a, xml_R1b, xml_R1c, xml_R1d, _
           xml_R5, xml_R4a, xml_R4b, xml_R4c, xml_R4d, xml_IBK, xml_Nhm, xml_R57_ulaz, xml_R57_izlaz As String
    Friend tmp_prelaz As Int16 = 6

    'deklaracije za web2tl
    Friend web02, web03, web04, web05, web06, web07, web08, web09, web10, web11 As String
    Friend web12, webSumaKola, web13, web28, web36, web38, web39, web42, web45 As Integer
    Friend web14, web15, web16, web17, web18, web19, web20, web21, web22, web23, web24, web25, web26, web27, web29, web30, _
           web35, web40, web41, web43, web44, web46, web47, web48
    Friend web31, web32, web33, web37 As Decimal
    Friend web_IBK As String

    '----------------

    'deklaracije za server2client
    Friend r02, r03, r04, r05, r06, r07, r08, r09, r10, r11 As String


    '----------------

    Friend mCarStanicaStart As String
    Friend mMasaDec As Decimal = 0
    Friend mPregledUnosa As String = "M"
    Friend mDoPrelaza As String = ""
    Friend mIncoterms As String = ""
    Friend upis_mFrNaknade As String = ""
    Friend mSumaIznos As Decimal = 0
    Friend mPrBroj As Int32
    Friend RecordAction As String = "I" '"N"
    Friend r57_mUprava1 As String
    Friend r57_mUprava2 As String
    Friend mUlPrelaz, mIzPrelaz As String

    Friend StampaId As String
    Friend jci_NazivRobe As String = ""
    Friend jci_NHM As String = ""
    Friend m_UicPrevozniPut As String = ""
    Friend mNHM As String = ""
    Friend File4Transfer As String
    Friend ZaBrisanje As String = ""
    Friend Stampa As String
    Friend _Kontrola_NemaUgovora As Int16 = 0
    Friend _temp_mBrojUg As String = ""

    'novo zbog azuriranja
    Friend eRazmena As String = "Ne"
    Friend eWebRazmena As String = "Ne"
    Friend MasterAction As String = "New" 'Upd=ako se azurira iz baze
    Friend mMesec As String
    Friend mDan As String
    Friend mGodina As String
    Friend UpdRecID As Int32 'Stanica u kojoj je obavljen unos + RecID
    Friend UpdStanicaRecID As String 'Stanica u kojoj je obavljen unos + RecID
    Friend mizlazObject As Object

    Friend mrA79a1, mrA79a2, mrA79a3 As String
    Friend mrA79b1, mrA79b2, mrA79b3 As Decimal

    Friend mRBKolauVozu As Int16 = 1
    Friend EventsActived As Boolean = True 'za help grid-enter
    '----------------bata-------------------
    Friend bSvaTovarena As String = "TK"
    Friend bTovarenaPrazna As String ' isto kao bSvaTovarena

    Friend bTkm As Integer = 0
    Friend bSkm As Integer = 0
    Friend _mNHM As String = ""
    Friend bVrstaSaobracaja As Integer = 0
    Friend bVrstaPosiljke As String = "K"
    Friend bVlasnistvo As String ' mVlasnik

    Friend bVrstaStanice As String = "M" 'utvrditi procedurom; za UTL je uvek "M"
    Friend bRedovanOrocen As String = "R" ' za unutrasnji
    Friend bValuta As String = "72"

    Friend bStavKoef As Decimal = 1
    Friend bKoef As Decimal = 1 'ne koristi se

    Friend bPrevozninaKoef As Decimal = 1
    Friend bMinPrevoznina As Decimal = 0
    Friend bDodPrevoznina As Decimal = 0
    Friend bDugacka As String = "N"
    Friend bKoefNak As Decimal = 1
    Friend bKoefInd As Decimal = 1
    Friend bKoefInd1 As Decimal = 1
    Friend bKoefRid As Decimal = 1
    Friend bPouzece As Decimal = 0
    Friend bPredujam As Decimal = 0
    Friend bKontejneri As Boolean = False
    'Friend bRetVal As String 'izbrisati

    Friend bSifraNaknade As String
    Friend bIvicniBroj As String
    Friend bPodBroj As String
    Friend bbDatum As DateTime = mDatumKalk          ' datum kalkulacije za naknade

    Friend bds As New DataSet
    '------------------- upit za help formu --------------------
    Friend upit As String
    Friend helpUprava As String
    Friend mIzlaz1 As String
    Friend mIzlaz2 As String
    Friend mIzlaz3 As Decimal
    Friend mIzlaz4 As String
    Friend mIzlaz5 As Int32
    '-----------------------------------------------------------

    Friend mAzuriranje As String = "1" ' 1=unos novog TL, 2=azuriranje vec unetog TL
    Friend mAkcija As String = "New"
    Friend _OpenForm As String = "Empty"

    Friend IzborSaobracaja As String = "1"
    Friend mVrPrevoza As String = "R" 'R=redovan O=orocen
    Friend mVrstaSaobracaja As Int16 'zbog uvoza 2,3,4,5...
    Friend mMasaRobe As Int32

    'Friend mIzjava As Int16 ' String
    Friend mVrstaPrevoza As String = "P" 'P=pojedinacna, G=grupa, V=voz
    Friend mVrstaObracuna As String = "RO" 'IC=Intercontainer, CO=centralni obracun, RO=redovni obracun
    Friend mFrRacun As String = ""
    Friend bRacunskaMasa As Decimal = 0

    'Friend mVrPos As String = "K"  bVrstaPosiljke
    Friend mRazred As String
    Friend mRazredRid As Int16
    Friend mIBK As String
    Friend mIBK_KB As String = ""
    Friend mBrojUg As String = "000000"
    Friend mPosiljalac As Int32
    Friend mPrimalac As Int32
    'Friend mNazivKomitenta As String = "" kom. zbog mCarPrNaziv
    Friend mSumaKola As Int16
    Friend mSumaRobe, mSumaBruto, mSumaTara As Int32

    Friend mTabelaCena As String
    Friend mDatumKalk As Date

    Friend mUserID As String

    Friend UpdUprava As String
    Friend UpdStanica As String
    Friend UpdBroj As Int32
    Friend UpdDatum As Date = Today()

    Friend TipTranzita As String = "ulaz"
    Friend mOtpUprava As String
    Friend mOtpStanica As String
    Friend mOtpBroj As Int32
    Friend eOtpBroj As String
    Friend mOtpDatum As Date = Today()
    Friend mObrMesec As String
    Friend mObrGodina As String
    Friend mStanica1 As String = "" '***
    Friend mUlEtiketa As Int32 = 0 '***
    Friend mDatumUlaza As Date '***
    Friend mStanica2 As String = "" '***
    Friend mIzEtiketa As Int32 = 0 '***
    Friend mDatumIzlaza As Date '***
    Friend mPrUprava As String
    Friend mPrStanica As String
    Friend mPrispece As Int32 = 0 '***
    Friend mPrDatum As Date = Today()
    Friend mBrojVoza As String = "0" 'Int32
    Friend msBrojVoza As Int32 = 0 'Int32
    Friend msBrojVoza2 As Int32 = 0 'broj voza na izlasku zbog BGR
    Friend mSatVoza As String = "00"
    Friend mSatVoza2 As String = "00"
    Friend mNajava As String = "0"
    Friend mNajavaKola As String = "0"
    Friend mTarifa As String
    Friend mManipulativnoMesto1 As String = ""
    Friend mManipulativnoMesto2 As String = ""
    Friend _TL_Kola As Int16 = 1
    Friend UTLNaknadeR44(3) As String
    Friend mSifraUic As String

    Friend mSifraIzjave As Int16
    Friend mSifraKorisnika As Int32

    Friend mPrikazKalkulacije As String = "N"
    Friend mPrevoznina As Decimal = 0
    Friend mSumaNak As Decimal = 0

    Friend tempNHM As New ArrayList

    Friend dtNaknade As DataTable = New DataTable("NAKNADE")
    Friend nCol0 As DataColumn = dtNaknade.Columns.Add("Sifra", Type.GetType("System.String"))
    Friend nCol1 As DataColumn = dtNaknade.Columns.Add("IvicniBroj", Type.GetType("System.String"))
    Friend nCol2 As DataColumn = dtNaknade.Columns.Add("Iznos", Type.GetType("System.Decimal"))
    Friend nCol3 As DataColumn = dtNaknade.Columns.Add("Valuta", Type.GetType("System.String"))
    Friend nCol4 As DataColumn = dtNaknade.Columns.Add("Kolicina", Type.GetType("System.Int32"))
    Friend nCol5 As DataColumn = dtNaknade.Columns.Add("DanCas", Type.GetType("System.Int32"))
    Friend nCol6 As DataColumn = dtNaknade.Columns.Add("Placanje", Type.GetType("System.String"))
    Friend nCol7 As DataColumn = dtNaknade.Columns.Add("Obracun", Type.GetType("System.String"))
    Friend nCol8 As DataColumn = dtNaknade.Columns.Add("Action", Type.GetType("System.String"))

    '----------------------- KOLA --------------------------
    '''Friend dtKola As DataTable = New DataTable("KOLA")
    '''Friend kCol1 As DataColumn = dtKola.Columns.Add("IndBrojKola", Type.GetType("System.String"))
    '''Friend kCol2 As DataColumn = dtKola.Columns.Add("Uprava", Type.GetType("System.String"))
    '''Friend kCol3 As DataColumn = dtKola.Columns.Add("Vlasnik", Type.GetType("System.String"))
    '''Friend kCol4 As DataColumn = dtKola.Columns.Add("Serija", Type.GetType("System.String"))
    '''Friend kCol5 As DataColumn = dtKola.Columns.Add("Vrsta", Type.GetType("System.String"))
    '''Friend kCol6 As DataColumn = dtKola.Columns.Add("Osovine", Type.GetType("System.Int16"))
    '''Friend kCol7 As DataColumn = dtKola.Columns.Add("Tara", Type.GetType("System.Int32"))
    '''Friend kCol8 As DataColumn = dtKola.Columns.Add("GrTov", Type.GetType("System.Decimal"))
    '''Friend kCol9 As DataColumn = dtKola.Columns.Add("Stitna", Type.GetType("System.String"))
    '''Friend kCol10 As DataColumn = dtKola.Columns.Add("Tip", Type.GetType("System.String"))
    '''Friend kCol11 As DataColumn = dtKola.Columns.Add("Prevoznina", Type.GetType("System.Decimal"))
    '''Friend kCol12 As DataColumn = dtKola.Columns.Add("Naknada", Type.GetType("System.Decimal"))
    '''Friend kCol13 As DataColumn = dtKola.Columns.Add("ICF", Type.GetType("System.String"))
    '''Friend kCol14 As DataColumn = dtKola.Columns.Add("KB", Type.GetType("System.String"))
    '''Friend kCol15 As DataColumn = dtKola.Columns.Add("Action", Type.GetType("System.String"))
    '''Friend kCol16 As DataColumn = dtKola.Columns.Add("RacunskaMasa", Type.GetType("System.Decimal"))
    '''Friend kCol17 As DataColumn = dtKola.Columns.Add("VozarinskiStav", Type.GetType("System.Decimal"))    

    Friend mNemaTare As String = "0"
    Friend dtKola As DataTable = New DataTable("KOLA")
    Friend kCol1 As DataColumn = dtKola.Columns.Add("IndBrojKola", Type.GetType("System.String"))
    Friend kCol2 As DataColumn = dtKola.Columns.Add("Tara", Type.GetType("System.Int32"))
    Friend kCol3 As DataColumn = dtKola.Columns.Add("Osovine", Type.GetType("System.Int16"))
    Friend kCol4 As DataColumn = dtKola.Columns.Add("Vlasnik", Type.GetType("System.String"))
    Friend kCol5 As DataColumn = dtKola.Columns.Add("Serija", Type.GetType("System.String"))
    Friend kCol6 As DataColumn = dtKola.Columns.Add("Vrsta", Type.GetType("System.String"))
    Friend kCol7 As DataColumn = dtKola.Columns.Add("Uprava", Type.GetType("System.String"))
    Friend kCol8 As DataColumn = dtKola.Columns.Add("GrTov", Type.GetType("System.Decimal"))
    Friend kCol9 As DataColumn = dtKola.Columns.Add("Stitna", Type.GetType("System.String"))
    Friend kCol10 As DataColumn = dtKola.Columns.Add("Tip", Type.GetType("System.String"))
    Friend kCol11 As DataColumn = dtKola.Columns.Add("Prevoznina", Type.GetType("System.Decimal"))
    Friend kCol12 As DataColumn = dtKola.Columns.Add("Naknada", Type.GetType("System.Decimal"))
    Friend kCol13 As DataColumn = dtKola.Columns.Add("ICF", Type.GetType("System.String"))
    Friend kCol14 As DataColumn = dtKola.Columns.Add("KB", Type.GetType("System.String"))
    Friend kCol15 As DataColumn = dtKola.Columns.Add("Action", Type.GetType("System.String"))
    ' -------- 1.2.2007.
    Friend kCol16 As DataColumn = dtKola.Columns.Add("RacunskaMasa", Type.GetType("System.Decimal"))
    Friend kCol17 As DataColumn = dtKola.Columns.Add("VozarinskiStav", Type.GetType("System.Decimal"))


    Friend mVlasnik As String
    Friend mSerija As String
    Friend mVrsta As String
    Friend mOsovine As Int16
    '-------------------------------------------------------

    ''''Friend dtNhm As DataTable = New DataTable("NHM")
    ''''Friend rCol0 As DataColumn = dtNhm.Columns.Add("IndBrojKola", Type.GetType("System.String")) '0
    ''''Friend rCol1 As DataColumn = dtNhm.Columns.Add("NHM", Type.GetType("System.String")) '1
    ''''Friend rCol1a As DataColumn = dtNhm.Columns.Add("MasaDec", Type.GetType("System.Decimal")) '1a Stvarna masa pošiljke decimal
    ''''Friend rCol2 As DataColumn = dtNhm.Columns.Add("Masa", Type.GetType("System.Int32")) '2 Stvarna masa pošiljke integer
    ''''Friend rCol3 As DataColumn = dtNhm.Columns.Add("R", Type.GetType("System.String")) '3
    ''''Friend rCol4 As DataColumn = dtNhm.Columns.Add("RID", Type.GetType("System.String")) '4
    ''''Friend rCol6 As DataColumn = dtNhm.Columns.Add("UTI", Type.GetType("System.String")) '5 tip 
    ''''Friend rCol5 As DataColumn = dtNhm.Columns.Add("UTIIB", Type.GetType("System.String")) '6 Ind. broj kontenera [GRANICA]
    ''''Friend rCol7 As DataColumn = dtNhm.Columns.Add("UTITara", Type.GetType("System.Int32")) '7 tara kontenera [GRANICA]
    ''''Friend rCol8 As DataColumn = dtNhm.Columns.Add("UTIRaster", Type.GetType("System.Decimal")) '8 primenjeni raster
    ''''Friend rCol9 As DataColumn = dtNhm.Columns.Add("UTINHM", Type.GetType("System.String")) '9 roba u konteneru [GRANICA]
    ''''Friend rCol10 As DataColumn = dtNhm.Columns.Add("UTIBuletin", Type.GetType("System.String")) '10 predajni list [GRANICA]
    ''''Friend rCol11 As DataColumn = dtNhm.Columns.Add("UTIPlombe", Type.GetType("System.String")) '11broj plombi [GRANICA]
    ''''Friend rCol12 As DataColumn = dtNhm.Columns.Add("Action", Type.GetType("System.String")) '12
    ''''Friend rCol13 As DataColumn = dtNhm.Columns.Add("RacMasaNHM", Type.GetType("System.Int32")) ' 16.                  13 Racunska masa po robi
    ''''Friend rCol14 As DataColumn = dtNhm.Columns.Add("VozarinskiStavNHM", Type.GetType("System.Decimal")) '  20.    14 Vozarinski stav po robi

    Friend dtNhm As DataTable = New DataTable("NHM")
    Friend rCol0 As DataColumn = dtNhm.Columns.Add("IndBrojKola", Type.GetType("System.String")) ' 1.                      0
    Friend rCol1 As DataColumn = dtNhm.Columns.Add("NHM", Type.GetType("System.String")) ' 13.                               1
    Friend rCol2 As DataColumn = dtNhm.Columns.Add("Masa", Type.GetType("System.Int32")) ' 15.                               2 Stvarna masa pošiljke
    Friend rCol3 As DataColumn = dtNhm.Columns.Add("UTI", Type.GetType("System.String")) ' 18.                                  5 tip 
    Friend rCol4 As DataColumn = dtNhm.Columns.Add("RID", Type.GetType("System.String")) ' 17.                                  4
    Friend rCol5 As DataColumn = dtNhm.Columns.Add("UTIIB", Type.GetType("System.String")) '                                     6 Ind. broj kontenera [GRANICA]
    Friend rCol6 As DataColumn = dtNhm.Columns.Add("R", Type.GetType("System.String")) ' 14.                                     3
    Friend rCol7 As DataColumn = dtNhm.Columns.Add("UTITara", Type.GetType("System.Int32")) '                                  7 tara kontenera [GRANICA]
    Friend rCol8 As DataColumn = dtNhm.Columns.Add("UTIRaster", Type.GetType("System.Decimal")) '                            8 primenjeni raster
    Friend rCol9 As DataColumn = dtNhm.Columns.Add("UTINHM", Type.GetType("System.String")) '                                  9 roba u konteneru [GRANICA]
    Friend rCol10 As DataColumn = dtNhm.Columns.Add("UTIBuletin", Type.GetType("System.String")) '                           10 predajni list [GRANICA]
    Friend rCol11 As DataColumn = dtNhm.Columns.Add("UTIPlombe", Type.GetType("System.String")) '                           11broj plombi [GRANICA]
    Friend rCol12 As DataColumn = dtNhm.Columns.Add("Action", Type.GetType("System.String")) '                                  12
    'Bata 06.02.2007.
    Friend rCol13 As DataColumn = dtNhm.Columns.Add("RacMasaNHM", Type.GetType("System.Int32")) ' 16.                  13 Racunska masa po robi
    Friend rCol14 As DataColumn = dtNhm.Columns.Add("VozarinskiStavNHM", Type.GetType("System.Decimal")) '  20.    14 Vozarinski stav po robi
    Friend rCol15 As DataColumn = dtNhm.Columns.Add("PorekloRobe", Type.GetType("System.Int16")) '         15 Poreklo robe: 0 - domaca, 1 - strana

    Friend dtDencane As DataTable = New DataTable("DENCANE")
    Friend dCol0 As DataColumn = dtDencane.Columns.Add("SMasa", Type.GetType("System.Int32"))
    Friend dCol1 As DataColumn = dtDencane.Columns.Add("RMasa", Type.GetType("System.Int32"))
    Friend dCol2 As DataColumn = dtDencane.Columns.Add("Tarifa", Type.GetType("System.String"))
    Friend dCol3 As DataColumn = dtDencane.Columns.Add("Tip", Type.GetType("System.Int32"))
    Friend dCol4 As DataColumn = dtDencane.Columns.Add("Komada", Type.GetType("System.Int32"))
    Friend dCol5 As DataColumn = dtDencane.Columns.Add("Iznos", Type.GetType("System.Decimal"))
    Friend dCol6 As DataColumn = dtDencane.Columns.Add("Valuta", Type.GetType("System.String"))
    Friend dCol7 As DataColumn = dtDencane.Columns.Add("Action", Type.GetType("System.String"))

    Friend dtUic As DataTable = New DataTable("UIC")
    Friend dtUicNak As DataTable = New DataTable("UICNAK")

    Friend dtKorekcija As DataTable = New DataTable("KOREKCIJA")
    Friend korCol0 As DataColumn = dtKorekcija.Columns.Add("Saobracaj", Type.GetType("System.String"))
    Friend korCol1 As DataColumn = dtKorekcija.Columns.Add("Markica", Type.GetType("System.Int32"))
    Friend korCol2 As DataColumn = dtKorekcija.Columns.Add("StanicaOtp", Type.GetType("System.String"))
    Friend korCol3 As DataColumn = dtKorekcija.Columns.Add("BrojOtp", Type.GetType("System.Int32"))
    Friend korCol4 As DataColumn = dtKorekcija.Columns.Add("JCI", Type.GetType("System.String"))
    Friend korCol5 As DataColumn = dtKorekcija.Columns.Add("DatumOd", Type.GetType("System.DateTime"))
    Friend korCol6 As DataColumn = dtKorekcija.Columns.Add("RokCarinjenja", Type.GetType("System.DateTime"))
    Friend korCol7 As DataColumn = dtKorekcija.Columns.Add("RecID", Type.GetType("System.Int32"))
    Friend korCol8 As DataColumn = dtKorekcija.Columns.Add("Stanica", Type.GetType("System.String"))

    Friend mCarStanica As String = ""
    Friend mCarStanica2 As String = ""
    Friend mCarValuta As String = ""
    Friend mCarFaktura As Decimal = 0
    Friend mCarDoc As String = ""
    Friend mCarBrDoc As String = ""
    Friend mCarKnjiga As String = ""
    Friend mCarPrPIB As String = ""
    Friend mCarPrNaziv As String = ""
    Friend mCarPrSediste As String = ""
    Friend mCarPrZemlja As String = ""

    Friend mCarXML As String = "0"
    Friend mServer As String = "0"

    '------------zavrsiti!!
    'Friend dtCarina As DataTable = New DataTable("CARINA")

    'Friend cCol1 As DataColumn = dtCarina.Columns.Add("Sifra", Type.GetType("System.String"))
    'Friend cCol2 As DataColumn = dtCarina.Columns.Add("Orig_x", Type.GetType("System.String"))
    'Friend cCol3 As DataColumn = dtCarina.Columns.Add("Godina", Type.GetType("System.Int32"))

    '----------------- Error -------------------------
    Friend dtError As DataTable = New DataTable("ERROR")
    Friend eCol1 As DataColumn = dtError.Columns.Add("Greska", Type.GetType("System.String"))
    '''Friend eCol2 As DataColumn = dtError.Columns.Add("Opis", Type.GetType("System.String"))

    Friend dtCarina As DataTable = New DataTable("CARINA")
    Friend carinaCol1 As DataColumn = dtCarina.Columns.Add("Ispravi", Type.GetType("System.String"))
    Friend carinaCol2 As DataColumn = dtCarina.Columns.Add("OpisGreske", Type.GetType("System.String"))

    '--------------- Transfer -----------------------
    Friend dtTransfer As DataTable = New DataTable("TRANSFER")
    Friend nTran0 As DataColumn = dtTransfer.Columns.Add("Slog", Type.GetType("System.String"))

    Friend dtK211 As DataTable = New DataTable("K211")
    Friend dkCol0 As DataColumn = dtK211.Columns.Add("Sifra", Type.GetType("System.Int32"))
    ' prethodno je polje bilo char(2) Friend dkCol0 As DataColumn = dtK211.Columns.Add("Sifra", Type.GetType("System.String"))
    Friend dkCol1 As DataColumn = dtK211.Columns.Add("Naziv", Type.GetType("System.String"))
    Friend dkCol2 As DataColumn = dtK211.Columns.Add("Action", Type.GetType("System.String"))

    Friend kBrOsov As String
    Friend kTipKola As String
    Friend kStitna As String
    Friend kUTI As String
    Friend kVlasn As String
    Friend kSer As String
    Friend kSifTar As Integer
    Friend kIznosMinPrev As Decimal = 0
    '''Friend tUTI As String
    Friend Lomljena As String = "N"


    Friend mNak_BrojKola As Int16
    Friend mSumaNakCo As Decimal = 0
    Friend mSumaNakRo As Decimal = 0
    Friend mSumaNakCo82 As Decimal = 0

    Friend bNazivNaknade As String = ""
    Friend bIznos1 As Decimal
    Friend bIznos2 As Decimal
    Friend bIznos3 As Decimal
    Friend bMinimum As Decimal


    Friend bNazivNaknadeArr(10) As String

    Friend bTarifa72 As Integer = 0

    Friend bNarocitaPosiljka As Boolean = False
    Friend bNPUkupno As Integer = 0
    Friend bNPKoef As Decimal = 1

    Friend bKursOt As Decimal = 1
    Friend bKursPr As Decimal = 1

    'Friend mOutKurs As Decimal = 0
    Friend bbPrevozninaUEvrima As Decimal = 0

    Friend bIzTBPrevoznina As Boolean = False

    Friend b35Posto As Boolean = False

    Friend bRacunskaMasa571 As Decimal = 0

    ' doterivanje dela za rad sa bazom
    Friend mCistUnos As String = "Da"
    Friend AkcijaZaPreuzimanje As String = "Ne"
    Friend MM_Action As String

    Friend UpdStanicaPr As String
    Friend UpdBrojPr As Int32
    Friend mTL_upuceno As Decimal = 0
    Friend mSumaDinari As Decimal = 0
    Friend mBlagajna As Decimal = 0
    Friend mRazlika As Decimal = 0
    Friend mTL_franko As Decimal = 0
    Friend tmpAkcija_TipNalepnice As String
    Friend tmpAkcija_Stanica As String
    Friend tmpAkcija_Nalepnica As Int32 = 0
    Friend _mNakPoKolima As Int32 = 0
    Friend mPkola = False    
    Friend tempNhm8216 As String = "T"
    Friend _mSMasa As Int32 = 0
    Friend _mTara As String = ""
    Friend mManipulativnoMesto As String = ""
    Friend MM_Count As Int16 = 0

    Friend tmp_pdv_f As Decimal = 0
    Friend tmp_pdv_u As Decimal = 0

    Friend ImaPDV As Boolean = True

    Public bPrevozninaLevo As Decimal = 0
    Public bPrevozninaDesno As Decimal = 0
    Public bSumaLevo As Decimal = 0
    Public bSumaDesno As Decimal = 0
    Public bSumaNaknadaLevo As Decimal = 0
    Public bSumaNaknadaDesno As Decimal = 0

    Friend bBlagFranko As Decimal = 0
    Friend bBlagUpuceno As Decimal = 0
    Friend bRazlikaFr As Decimal = 0
    Friend bRazlikaUp As Decimal = 0

    Friend ExMMIndex As Integer = -1
    Friend ImMMIndex As Integer = -1

    Friend bManipulativnoMesto1IzSloga As String = ""
    Friend bManipulativnoMesto2IzSloga As String = ""

    Friend bPDV1IzSloga As Decimal = 0
    Friend bPDV2IzSloga As Decimal = 0

    Friend bUkupnoIzBaze As Byte = 0

    Friend bNepokrivenaMasa As Decimal = 0

    Friend bPDVKoef As Decimal = 0.18
    Friend bPDVKoefString As String = "18 %"

    Friend bKurs As Decimal = 1

    Friend bCoPDV As Decimal = 0

    Friend ci As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
    Friend DecimalSeparator As String = ci.NumberFormat.CurrencyDecimalSeparator

    Friend sql_UpitPregled As String = ""

    Friend bPorekloRobe As Int16 = 0   '  0 - pretezno domaceg porekla, 1 - pretezno stranog porekla
    Friend bVrstaSaobracajaTemp As Integer = 0

    Friend bKoefZaKoloseke As Decimal = 1   ' bilo 0.8475 do 30.09.2012.

    Friend bPregledObrMesec As String
    Friend bPregledObrGodina As String

    Friend bPrevoznina91ZaPDV As Decimal = 0     ' zbog P9

    Friend bPrevozniPutZS As Int32 = 1          ' 1 - redovan, 2 - vanredan, 3 - lomljen redovan, 4 - lomljen vanredan

    Friend bStanicaVia As String = ""           ' za lomljen prevozni put

    Friend updbTkm As Int32 = 0

    Friend bDatumOtpIzSloga As DateTime

    Friend bTkm1 As Integer = 0
    Friend bTkm2 As Integer = 0
    Friend bSkm1 As Integer = 0
    Friend bSkm2 As Integer = 0

    Friend bIzlaz1 As String = ""       ' zbog podbroja naknada

    Friend bUserIDGrupa As String = ""

    Friend DatumPrikaza As String = ""

    Friend bUkupnoK211IzBaze = 0

    Friend bOrder As Int16 = 1

    Friend bbPredujam As Decimal = 0

    Friend bObrMesecIzSlogaKalk As String = ""
    Friend bObrGodinaIzSlogaKalk As String = ""

    Friend bTUGF As Decimal = 0
    Friend bTUGU As Decimal = 0

    'Friend Const SND_ASYNC As Integer = &H1
    'Friend Const SND_FILENAME As Integer = &H20000
    'Friend Const SND_NODEFAULT As Integer = &H2

    Friend bGreska As Int16 = 0

    Friend bPovlastica1 As Decimal = 0      ' po razredima, za prikaz na TL
    Friend bPovlastica2 As Decimal = 0
    Friend bPovlastica3 As Decimal = 0

    Friend mSifraK211 As String = ""
    Friend pomSrp As String

    Friend bAdmin As Boolean = False
    Friend bAdmin77 As Boolean = False

    Friend bVrstaPregledGrida As String = ""
    Friend bNarocitaPosiljkaChar As String = ""

    Friend bDKIznos As Decimal = 0          ' iznos po doracunskoj karti

    Friend bNHMKao8606 As Boolean = False

    Friend bUkljucujuci As String = ""

    Friend bUkljucujuciNiz(3) As String

    Friend bIznosPoIzjavi As Decimal = 0

    Friend bIzlazNazivKoloseka As String = ""
    Friend bIzlazCena1 As String = ""
    Friend bIzlazCena2 As String = ""
    Friend bIzlazCena3 As String = ""

    Friend bPregledTekucegMeseca As Boolean = True

    Friend bDupliKoloseci As Boolean = False

    Friend bDatumObrade As Date
    'Friend bDatumObrade As Date
    Friend bDatumObradeIzSloga As Date

    Friend bPr91Nepokrivena As Decimal = 0

    Friend mSifraKorisnikaP As Int32
    Friend mSifraKorisnikaPP As Int32

    Friend bOpisPrevoznogPuta As String = ""

    Friend NHM4 As String = ""

    Friend bVSTemp As Integer = 0

    Friend bNajava As String = ""

    ' pregled i korekcija po najavi za CO (CD) 
    Friend bpNajava As String = ""
    Friend bpUgovor As String = ""
    Friend bpDatumOd As Date
    Friend bpDatumDo As Date
    Friend bpObrMesec As String
    Friend bpObrGodina As String
    Friend bpJedanTLPoNajavi As String = "1"        ' "1" - jedan tov. list za sva kola;   "0" - pojedinaèni tov. listovi po kolima
    Friend bpValuta As String = "RSD"               ' RSD ili EUR
    Friend bpDaPDV As String = "0"                  ' "1" - najava podleže PDV-u; "0" - najava ne podleže PDV-u;

    Friend bpPrevozninaPoNajavi As Decimal = 0
    Friend bpRacMasaPoNajavi As Decimal = 0
    Friend bpVozStavPonajavi As Decimal = 0
    Friend bpSumaPoNajavi As Decimal = 0
    Friend bpPDVPoNajavi As Decimal = 0

    Friend bpRecIDNiz(30) As Integer
    Friend bpStvMasa(30) As Integer
    Friend bpRacMasa(30) As Integer
    Friend bpVozStav(30) As Decimal

    Friend bpUkupnoKolaPoNajavi As Integer = 0

    Friend bpDatumOdStr As String
    Friend bpDatumDoStr As String

    Friend bCBObracun As Boolean = False

    Friend bVOP As String = "R"             '  vrsta obraèuna prevoznine; "R" - na blagajni;    "C" - centralni obraèun  ( zbog NIS-a )

End Module

