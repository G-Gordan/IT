Module InitVar

    Friend mCarPost As String = "N"
    Friend mRanzirna As String = ""
    Friend mRealizovan As String = ""
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

    Friend web02, web03, web04, web05, web06, web07, web08, web09, web10, web11 As String
    Friend web12, webSumaKola, web13, web28, web36, web38, web39, web42, web45 As Integer
    Friend web14, web15, web16, web17, web18, web19, web20, web21, web22, web23, web24, web25, web26, web27, web29, web30, _
           web35, web40, web41, web43, web44, web46, web47, web48
    Friend web31, web32, web33, web37 As Decimal

    Friend web_IBK As String

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
    Friend SendOrfeus As String = "N"
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
    Friend sTkm As Integer = 0
    Friend bVrstaSaobracaja As Integer = 4
    Friend bVrstaPosiljke As String = "K"
    Friend bVlasnistvo As String ' mVlasnik

    Friend bVrstaStanice As String 'utvrditi procedurom
    Friend bRedovanOrocen As String = "R" ' za unutrasnji
    Friend bValuta As String = "17"

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
    Friend bRetVal As String 'izbrisati

    Friend bSifraNaknade As String
    Friend bIvicniBroj As String

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
    Friend _OpenForm As String = "Roba"

    Friend IzborSaobracaja As String = ""
    Friend mVrPrevoza As String = "R" 'R=redovan O=orocen
    Friend mVrstaSaobracaja As Int16 'zbog uvoza 2,3,4,5...
    Friend mMasaRobe As Int32

    Friend mIzjava As Int16 ' String
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
    Friend nmNazivOtpSt As String = ""
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
    Friend _TL_Kola As Int16 = 1
    Friend UTLNaknadeR44(3) As String
    Friend mSifraUic As String

    Friend mSifraIzjave As Int16
    Friend mSifraKorisnika As Int32

    Friend mPrikazKalkulacije As String = "N"
    Friend mPrevoznina As Decimal = 0
    Friend mDinaraPoTL As Decimal = 0
    Friend mSumaNak As Decimal = 0

    Friend tempNHM As New ArrayList

    Friend InitNumKola As Int32 = 0
    Friend InitNumRoba As Int32 = 0
    Friend InitNumNak As Int32 = 0

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
    Friend dtKola As DataTable = New DataTable("KOLA")
    Friend kCol1 As DataColumn = dtKola.Columns.Add("IndBrojKola", Type.GetType("System.String"))
    Friend kCol2 As DataColumn = dtKola.Columns.Add("Uprava", Type.GetType("System.String"))
    Friend kCol3 As DataColumn = dtKola.Columns.Add("Vlasnik", Type.GetType("System.String"))
    Friend kCol4 As DataColumn = dtKola.Columns.Add("Serija", Type.GetType("System.String"))
    Friend kCol5 As DataColumn = dtKola.Columns.Add("Vrsta", Type.GetType("System.String"))
    Friend kCol6 As DataColumn = dtKola.Columns.Add("Osovine", Type.GetType("System.Int16"))
    Friend kCol7 As DataColumn = dtKola.Columns.Add("Tara", Type.GetType("System.Int32"))
    Friend kCol8 As DataColumn = dtKola.Columns.Add("GrTov", Type.GetType("System.Decimal"))
    Friend kCol9 As DataColumn = dtKola.Columns.Add("Stitna", Type.GetType("System.String"))
    Friend kCol10 As DataColumn = dtKola.Columns.Add("Tip", Type.GetType("System.String"))
    Friend kCol11 As DataColumn = dtKola.Columns.Add("Prevoznina", Type.GetType("System.Decimal"))
    Friend kCol12 As DataColumn = dtKola.Columns.Add("Naknada", Type.GetType("System.Decimal"))
    Friend kCol13 As DataColumn = dtKola.Columns.Add("ICF", Type.GetType("System.String"))
    Friend kCol14 As DataColumn = dtKola.Columns.Add("KB", Type.GetType("System.String"))
    Friend kCol15 As DataColumn = dtKola.Columns.Add("Action", Type.GetType("System.String"))

    Friend mVlasnik As String
    Friend mSerija As String
    Friend mVrsta As String
    Friend mOsovine As Int16
    '-------------------------------------------------------

    Friend dtNhm As DataTable = New DataTable("NHM")
    Friend rCol0 As DataColumn = dtNhm.Columns.Add("IndBrojKola", Type.GetType("System.String")) '0
    Friend rCol1 As DataColumn = dtNhm.Columns.Add("NHM", Type.GetType("System.String")) '1
    Friend rCol1a As DataColumn = dtNhm.Columns.Add("MasaDec", Type.GetType("System.Decimal")) '1a Stvarna masa pošiljke decimal
    Friend rCol2 As DataColumn = dtNhm.Columns.Add("Masa", Type.GetType("System.Int32")) '2 Stvarna masa pošiljke integer
    Friend rCol3 As DataColumn = dtNhm.Columns.Add("R", Type.GetType("System.String")) '3
    Friend rCol4 As DataColumn = dtNhm.Columns.Add("RID", Type.GetType("System.String")) '4
    Friend rCol6 As DataColumn = dtNhm.Columns.Add("UTI", Type.GetType("System.String")) '5 tip 
    Friend rCol5 As DataColumn = dtNhm.Columns.Add("UTIIB", Type.GetType("System.String")) '6 Ind. broj kontenera [GRANICA]
    Friend rCol7 As DataColumn = dtNhm.Columns.Add("UTITara", Type.GetType("System.Int32")) '7 tara kontenera [GRANICA]
    Friend rCol8 As DataColumn = dtNhm.Columns.Add("UTIRaster", Type.GetType("System.Decimal")) '8 primenjeni raster
    Friend rCol9 As DataColumn = dtNhm.Columns.Add("UTINHM", Type.GetType("System.String")) '9 roba u konteneru [GRANICA]
    Friend rCol10 As DataColumn = dtNhm.Columns.Add("UTIBuletin", Type.GetType("System.String")) '10 predajni list [GRANICA]
    Friend rCol11 As DataColumn = dtNhm.Columns.Add("UTIPlombe", Type.GetType("System.String")) '11broj plombi [GRANICA]
    Friend rCol12 As DataColumn = dtNhm.Columns.Add("Action", Type.GetType("System.String")) '12

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


End Module
