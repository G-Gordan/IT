Module InitVar
    Friend pubSerijaKola As String
    Friend pubIBK As String
    Friend mNak_BrojKola As Int16
    Friend mNastavljaNajavu As Boolean = False
    Friend upis_mFrNaknade As String = ""
    Friend mUicPrelaz As String
    Friend mTL_franko As Decimal = 0
    Friend mTL_upuceno As Decimal = 0
    Friend upis_f_suma As Decimal = 0
    Friend upis_u_suma As Decimal = 0
    Friend upis_f_prev As Decimal = 0
    Friend upis_u_prev As Decimal = 0
    Friend upis_f_nak As Decimal = 0
    Friend upis_u_nak As Decimal = 0
    Friend upis_f_prev_din As Decimal = 0
    Friend upis_u_prev_din As Decimal = 0
    Friend upis_f_nak_din As Decimal = 0
    Friend upis_u_nak_din As Decimal = 0

    Friend upis_u_din As Decimal = 0

    Friend mSifraK211 As String = ""
    Friend Lomljena As String = "N"
    Friend LomPrev1 As Decimal = 0
    Friend LomPrev2 As Decimal = 0
    Friend LomStanica As String = ""
    Friend Lom_btkm1 As Integer = 0
    Friend Lom_btkm2 As Integer = 0

    ''''Friend mUkljucujuci As String = ""
    Friend mUkljucujuci(4) As String
    Friend mDoPrelaza As String = ""
    Friend UpisPoKolima As Boolean = False ' zbog ugovora 480701, upis cene na svakom tovarnom lilstu
    Friend CrRacunskiMesec As String
    Friend mProcenatBM As Decimal = 0
    Friend SetMesec As String = "UNOS"
    Friend VozoviMakis As String = "Novi"
    Friend ZaostalaKola As String = "Ne"
    Friend _mTara As String = ""
    Friend _mSMasa As Int32 = 0
    Friend _mNHM As String = ""
    Friend m_UicPrevozniPut As String = ""

    Friend mRucnaNajava As String = "N"
    Friend mMakis As String = "NN"
    Friend _PraviPrelaz As String = ""  ' zbog Makisa
    Friend mPregledUnosa As String = "M"
    Friend tempNhm8216 As String = "T"
    Friend AkcijaZaPreuzimanje As String = "Ne"
    Friend tmpAkcija_TipNalepnice As String
    Friend tmpAkcija_Stanica As String
    Friend tmpAkcija_Nalepnica As Int32 = 0

    Friend sql_UpitPregled As String = ""

    Friend mBrutoMasaPoPosiljci As Int32 = 0

    Friend RecordAction As String = "N"
    Friend Stampa As String
    Friend _Kontrola_NemaUgovora As Int16 = 0
    Friend _temp_mBrojUg As String = ""

    Friend Info_ObrMesec As String = ""
    Friend Info_ObrIzvos As Decimal = 0

    'novo zbog azuriranja
    Friend MasterAction As String = "New" 'Upd=ako se azurira iz baze
    Friend MM_Action As String
    Friend MM_Count As Int16 = 0
    Friend mMesec As String
    Friend mDan As String
    Friend mGodina As String
    'Friend ForUpdRecID As Int32 ' Kod izmene u bazi sa kombinovanim New i Upd
    Friend UpdRecID As Int32 = 0
    Friend UpdStanicaRecID As String = ""
    Friend UpdUprava As String
    Friend UpdStanica As String
    Friend UpdBroj As Int32
    Friend UpdDatum As Date = Today()

    Friend mRBKolauVozu As Int16 = 1
    Friend EventsActived As Boolean = True 'za help grid-enter

    '----------------bata-------------------
    Friend bSvaTovarena As String = "TK"
    Friend bTovarenaPrazna As String ' isto kao bSvaTovarena

    Friend bTkm As Integer
    Friend sTkm As Integer
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
    Friend mIzlaz3 As Decimal ' String
    '-----------------------------------------------------------

    Friend mAzuriranje As String = "1" ' 1=unos novog TL, 2=azuriranje vec unetog TL
    Friend mAkcija As String = "New"
    Friend _OpenForm As String = "Roba"

    Friend IzborSaobracaja As String = ""
    Friend mVrPrevoza As String = "R" 'R=redovan O=orocen
    Friend mVrstaSaobracaja As Int16 ' String  'zbog uvoza 2,3,4,5,6
    Friend mMasaRobe As Int32
    Friend tmp_nhm As String
    Friend tmp_masa As String
    Friend MasaRobe As Int32


    Friend mIzjava As Int16 ' String
    Friend mIncoterms As String = ""
    Friend mVrstaPrevoza As String = "P" 'P=pojedinacna, G=grupa, V=voz
    Friend mVrstaObracuna As String = "RO" 'IC=Intercontainer, CO=centralni obracun, RO=redovni obracun
    Friend mFrRacun As String = ""

    'Friend mVrPos As String = "K"  bVrstaPosiljke
    Friend mRazred As String
    Friend mRazredRid As Int16
    Friend mIBK As String
    Friend mIBK_KB As String = ""
    Friend mBrojUg As String = "000000"
    Friend mPosiljalac As Int32
    Friend mPrimalac As Int32
    Friend mNazivKomitenta As String = ""
    Friend mSumaKola As Int16

    Friend mTabelaCena As String
    Friend mDatumKalk As Date

    Friend mUserID As String

    Friend TipTranzita As String = "ulaz"
    Friend mOtpUprava As String
    Friend mOtpStanica As String
    Friend mManipulativnoMesto As String = ""
    Friend mOtpBroj As Int32
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
    Friend UpdStanicaPr As String
    Friend mPrBroj As Int32
    Friend UpdBrojPr As Int32
    Friend mPrispece As Int32 = 0 '***
    Friend mPrDatum As Date = Today()
    Friend mBrojVoza As String = "0" 'Int32
    Friend msBrojVoza As Int32 = 0 'Int32
    Friend msBrojVoza2 As Int32 = 0 'broj voza na izlasku zbog BGR
    Friend mSatVoza As String = "00"
    Friend mNajava As String = "0"
    Friend mNajava2 As String = "0"
    Friend mNajavaKola As String = "0"
    Friend mNajavaKolaReal As String = "0"
    Friend mTarifa As String
    Friend _TL_Kola As Int16 = 1

    Friend mSifraUic As String

    Friend mSifraIzjave As Int16
    Friend mSifraKorisnika As Int32

    Friend mPrikazKalkulacije As String = "N"
    Friend mSumaIznos As Decimal = 0
    Friend mBlagajna As Decimal = 0
    Friend mBlagajnaK115 As Decimal = 0
    Friend mSumaDinari As Decimal = 0
    Friend mPrevoznina As Decimal = 0
    Friend mRazlika As Decimal = 0
    Friend mSumaNak As Decimal = 0
    Friend mSumaNakCo As Decimal = 0
    Friend mSumaNakRo As Decimal = 0
    Friend mSumaNakCo82 As Decimal = 0

    Friend tempNHM As New ArrayList

    Friend dtUic As DataTable = New DataTable("UicUprave")
    Friend UicCol0 As DataColumn = dtUic.Columns.Add("Uprava", Type.GetType("System.String"))
    Friend UicCol1 As DataColumn = dtUic.Columns.Add("Ulaz", Type.GetType("System.String"))
    Friend UicCol2 As DataColumn = dtUic.Columns.Add("Izlaz", Type.GetType("System.String"))
    Friend UicCol3 As DataColumn = dtUic.Columns.Add("Valuta", Type.GetType("System.String"))
    Friend UicCol4 As DataColumn = dtUic.Columns.Add("Prevoznina", Type.GetType("System.Decimal"))
    Friend UicCol5 As DataColumn = dtUic.Columns.Add("Nak1", Type.GetType("System.String"))
    Friend UicCol6 As DataColumn = dtUic.Columns.Add("Iznos1", Type.GetType("System.Decimal"))
    Friend UicCol7 As DataColumn = dtUic.Columns.Add("Nak2", Type.GetType("System.String"))
    Friend UicCol8 As DataColumn = dtUic.Columns.Add("Iznos2", Type.GetType("System.Decimal"))
    Friend UicCol9 As DataColumn = dtUic.Columns.Add("Nak3", Type.GetType("System.String"))
    Friend UicCol10 As DataColumn = dtUic.Columns.Add("Iznos3", Type.GetType("System.Decimal"))
    Friend UicCol11 As DataColumn = dtUic.Columns.Add("SifraGS", Type.GetType("System.String"))
    Friend UicCol12 As DataColumn = dtUic.Columns.Add("ValPredujam", Type.GetType("System.String"))
    Friend UicCol13 As DataColumn = dtUic.Columns.Add("Predujam", Type.GetType("System.Decimal"))
    Friend UicCol14 As DataColumn = dtUic.Columns.Add("TLVal", Type.GetType("System.String"))
    Friend UicCol15 As DataColumn = dtUic.Columns.Add("TLFranko", Type.GetType("System.Decimal"))
    Friend UicCol16 As DataColumn = dtUic.Columns.Add("TLUpuceno", Type.GetType("System.Decimal"))
    Friend uicCol17 As DataColumn = dtUic.Columns.Add("Action", Type.GetType("System.String"))
    'dodato zbog vise uprava i sortiranja
    Friend uicCol18 As DataColumn = dtUic.Columns.Add("rbr", Type.GetType("System.Decimal"))
    Friend UicCol18a As DataColumn = dtUic.Columns.Add("TLUpucenoDin", Type.GetType("System.Decimal"))
    'dodato zbog preracuna franko / upuceno
    Friend uicCol19 As DataColumn = dtUic.Columns.Add("PF", Type.GetType("System.Decimal")) 'Prevoznina franko
    Friend uicCol20 As DataColumn = dtUic.Columns.Add("PU", Type.GetType("System.Decimal")) 'Prevoznina upuceno
    Friend uicCol21 As DataColumn = dtUic.Columns.Add("NF", Type.GetType("System.Decimal")) 'Naknade franko
    Friend uicCol22 As DataColumn = dtUic.Columns.Add("NU", Type.GetType("System.Decimal")) 'Naknade upuceno
    Friend uicCol23 As DataColumn = dtUic.Columns.Add("DU", Type.GetType("System.Decimal")) 'Dinari upuceno


    Friend dtUic2 As DataTable = New DataTable("Uic2")
    Friend UicObr1 As DataColumn = dtUic2.Columns.Add("FPrev", Type.GetType("System.Decimal"))
    Friend UicObr2 As DataColumn = dtUic2.Columns.Add("FNak", Type.GetType("System.Decimal"))
    Friend UicObr3 As DataColumn = dtUic2.Columns.Add("FSuma", Type.GetType("System.Decimal"))
    Friend UicObr4 As DataColumn = dtUic2.Columns.Add("Uprava", Type.GetType("System.String"))
    Friend UicObr5 As DataColumn = dtUic2.Columns.Add("Valuta", Type.GetType("System.String"))
    Friend UicObr6 As DataColumn = dtUic2.Columns.Add("UPrev", Type.GetType("System.Decimal"))
    Friend UicObr7 As DataColumn = dtUic2.Columns.Add("UNak", Type.GetType("System.Decimal"))
    Friend UicObr8 As DataColumn = dtUic2.Columns.Add("USuma", Type.GetType("System.Decimal"))
    Friend UicObr9 As DataColumn = dtUic2.Columns.Add("UDinari", Type.GetType("System.Decimal"))

    Friend dtUicEx As DataTable = New DataTable("UicEx")
    Friend UicEx1 As DataColumn = dtUicEx.Columns.Add("FPrev", Type.GetType("System.Decimal"))
    Friend UicEx2 As DataColumn = dtUicEx.Columns.Add("FNak", Type.GetType("System.Decimal"))
    Friend UicEx3 As DataColumn = dtUicEx.Columns.Add("FSuma", Type.GetType("System.Decimal"))
    Friend UicEx4 As DataColumn = dtUicEx.Columns.Add("Uprava", Type.GetType("System.String"))
    Friend UicEx5 As DataColumn = dtUicEx.Columns.Add("Valuta", Type.GetType("System.String"))
    Friend UicEx6 As DataColumn = dtUicEx.Columns.Add("UPrev", Type.GetType("System.Decimal"))
    Friend UicEx7 As DataColumn = dtUicEx.Columns.Add("UNak", Type.GetType("System.Decimal"))
    Friend UicEx8 As DataColumn = dtUicEx.Columns.Add("USuma", Type.GetType("System.Decimal"))
    Friend UicEx9 As DataColumn = dtUicEx.Columns.Add("UDinari", Type.GetType("System.Decimal"))

    Friend dtMakis As DataTable = New DataTable("MAKIS")
    Friend makCol0 As DataColumn = dtMakis.Columns.Add("RBR", Type.GetType("System.Int32"))
    Friend makCol1 As DataColumn = dtMakis.Columns.Add("IBK", Type.GetType("System.String"))
    Friend makCol2 As DataColumn = dtMakis.Columns.Add("Izlaz", Type.GetType("System.String"))
    Friend makCol3 As DataColumn = dtMakis.Columns.Add("Real", Type.GetType("System.String"))
    Friend makCol4 As DataColumn = dtMakis.Columns.Add("DoMakisa", Type.GetType("System.String"))
    Friend makCol5 As DataColumn = dtMakis.Columns.Add("Tara", Type.GetType("System.Int32"))
    Friend makCol6 As DataColumn = dtMakis.Columns.Add("Masa", Type.GetType("System.Int32"))
    Friend makCol7 As DataColumn = dtMakis.Columns.Add("RecID", Type.GetType("System.Int32"))

    Friend dtMakis1 As DataTable = New DataTable("MAKIS1")
    Friend mak1Col0 As DataColumn = dtMakis1.Columns.Add("RBR", Type.GetType("System.Int32"))
    Friend mak1Col1 As DataColumn = dtMakis1.Columns.Add("Mesec", Type.GetType("System.String"))
    Friend mak1Col2 As DataColumn = dtMakis1.Columns.Add("BrojOtp", Type.GetType("System.String"))
    Friend mak1Col3 As DataColumn = dtMakis1.Columns.Add("IBK", Type.GetType("System.String"))
    Friend mak1Col4 As DataColumn = dtMakis1.Columns.Add("Tara", Type.GetType("System.Int32"))
    Friend mak1Col5 As DataColumn = dtMakis1.Columns.Add("Masa", Type.GetType("System.Int32"))
    Friend mak1Col6 As DataColumn = dtMakis1.Columns.Add("Prevoznina", Type.GetType("System.Decimal"))
    Friend mak1Col7 As DataColumn = dtMakis1.Columns.Add("Naknada", Type.GetType("System.Decimal"))
    Friend mak1Col8 As DataColumn = dtMakis1.Columns.Add("RecID", Type.GetType("System.Int32"))

    Friend dtKorekcija As DataTable = New DataTable("KOREKCIJA")
    Friend korCol0 As DataColumn = dtKorekcija.Columns.Add("RBR", Type.GetType("System.Int32"))
    Friend korCol1 As DataColumn = dtKorekcija.Columns.Add("Najavljeno", Type.GetType("System.Int32"))
    Friend korCol2 As DataColumn = dtKorekcija.Columns.Add("Mesec", Type.GetType("System.String"))
    Friend korCol3 As DataColumn = dtKorekcija.Columns.Add("BrojOtp", Type.GetType("System.Int32"))
    Friend korCol4 As DataColumn = dtKorekcija.Columns.Add("Makis", Type.GetType("System.String"))
    Friend korCol5 As DataColumn = dtKorekcija.Columns.Add("IBK", Type.GetType("System.String"))
    Friend korCol6 As DataColumn = dtKorekcija.Columns.Add("Tara", Type.GetType("System.Int32"))
    Friend korCol7 As DataColumn = dtKorekcija.Columns.Add("Masa", Type.GetType("System.Int32"))
    Friend korCol8 As DataColumn = dtKorekcija.Columns.Add("Prevoznina", Type.GetType("System.Decimal"))
    Friend korCol9 As DataColumn = dtKorekcija.Columns.Add("Naknada", Type.GetType("System.Decimal"))
    Friend korCol10 As DataColumn = dtKorekcija.Columns.Add("NHM", Type.GetType("System.String"))
    '''Friend korCol10 As DataColumn = dtKorekcija.Columns.Add("NakZaCO", Type.GetType("System.Decimal"))
    Friend korCol11 As DataColumn = dtKorekcija.Columns.Add("NakPoKolima", Type.GetType("System.Decimal"))
    Friend korCol12 As DataColumn = dtKorekcija.Columns.Add("RecID", Type.GetType("System.Int32"))
    'DODATO ZBOG KOREKCIJE VOZ SA JEDNIM TOVARNIM LISTOM 08.08.2010:
    Friend korCol13 As DataColumn = dtKorekcija.Columns.Add("KolaRb", Type.GetType("System.Int32"))
    Friend korCol14 As DataColumn = dtKorekcija.Columns.Add("RobaRb", Type.GetType("System.Int32"))

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
    ' -----------------

    Friend mVlasnik As String
    Friend mSerija As String
    Friend mVrsta As String
    Friend mOsovine As Int16
    '-------------------------------------------------------

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

    Friend dtDencane As DataTable = New DataTable("DENCANE")
    Friend dCol0 As DataColumn = dtDencane.Columns.Add("SMasa", Type.GetType("System.Int32"))
    Friend dCol1 As DataColumn = dtDencane.Columns.Add("RMasa", Type.GetType("System.Int32"))
    Friend dCol2 As DataColumn = dtDencane.Columns.Add("Tarifa", Type.GetType("System.String"))
    Friend dCol3 As DataColumn = dtDencane.Columns.Add("Tip", Type.GetType("System.Int32"))
    Friend dCol4 As DataColumn = dtDencane.Columns.Add("Komada", Type.GetType("System.Int32"))
    Friend dCol5 As DataColumn = dtDencane.Columns.Add("Iznos", Type.GetType("System.Decimal"))
    Friend dCol6 As DataColumn = dtDencane.Columns.Add("Valuta", Type.GetType("System.String"))
    Friend dCol7 As DataColumn = dtDencane.Columns.Add("Action", Type.GetType("System.String"))

    Friend mCarStanica As String = ""
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
    Friend eCol2 As DataColumn = dtError.Columns.Add("Opis", Type.GetType("System.String"))

    Friend dtCarina As DataTable = New DataTable("CARINA")
    Friend carinaCol1 As DataColumn = dtCarina.Columns.Add("Ispravi", Type.GetType("System.String"))
    Friend carinaCol2 As DataColumn = dtCarina.Columns.Add("OpisGreske", Type.GetType("System.String"))

    Friend dtK211 As DataTable = New DataTable("K211")
    Friend dkCol0 As DataColumn = dtK211.Columns.Add("Sifra", Type.GetType("System.Int32"))
    ' prethodno je polje bilo char(2) Friend dkCol0 As DataColumn = dtK211.Columns.Add("Sifra", Type.GetType("System.String"))
    Friend dkCol1 As DataColumn = dtK211.Columns.Add("Naziv", Type.GetType("System.String"))
    Friend dkCol2 As DataColumn = dtK211.Columns.Add("Action", Type.GetType("System.String"))

    Friend bRacunskaMasaPoKolima As Decimal = 0
    Friend bRacunskaMasa As Decimal = 0
    Friend bVozarinskiStavPoKolima As Decimal = 0
    Friend bVozarinskiStav As Decimal = 0

    ' --------------- Katarina 
    Friend kBrUgov As String
    Friend kAneks As Integer
    Friend kVaziOd As Date
    Friend kVaziDo As Date
    Friend kSifTar As Integer
    Friend kSaobr As String
    Friend kNhmSifra As String
    Friend kUprava As String
    Friend kSifVal As Integer
    Friend kOdStan As String
    Friend kDoStan As String
    Friend kVlasn As String
    Friend kVrsta As String
    Friend kSpecKola As String
    Friend kSer As String
    Friend kBrOsov As String
    Friend kOsPrit As String
    Friend kTipKola As String
    Friend kStitna As String
    Friend kUTI As String
    Friend tUTI As String
    Friend TipUTI As String
    Friend kPorez As String
    Friend kNaknada As String
    Friend kTipUTI As String
    Friend kTonStav As String
    Friend kValuta As String
    Friend kPojedin As Decimal
    Friend kGrupa As Decimal
    Friend kVoz As Decimal
    Friend kIznosMinPrev As Decimal = 0
    Friend kRetVal
    Friend kVozarinskiStavKP As Decimal
    Friend kDatumKalk As Date
    Friend WithEvents tbStanicaOtp As System.Windows.Forms.TextBox
    Friend WithEvents tbUpravaOtp As System.Windows.Forms.TextBox
    Friend WithEvents cbSmer1 As System.Windows.Forms.ComboBox
    Friend WithEvents tbStanicaPr As System.Windows.Forms.TextBox
    Friend WithEvents tbNHM As System.Windows.Forms.TextBox
    'Friend WithEvents tbUtiNHM As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents tbPrevoznina As System.Windows.Forms.TextBox
    Friend kPrevoznina As Decimal = 0
    Friend kOtpUprava As String

    Friend bMasaAKombiPoTL As Integer

End Module
