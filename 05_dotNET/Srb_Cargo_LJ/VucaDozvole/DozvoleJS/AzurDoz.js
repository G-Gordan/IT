function fAzurDoz() {
    var vAzurDoz = {
        $lstDoz: $('.lstDoz'),
        $tdBroj: $('.tdBroj'),
        $tdStatus: $('.tdStatus'),
        $tbIme: $('.tbIme'),
        $tbZvanje: $('.tbZvanje'),
        $tbPreduzece: $('.tbPreduzece'),
        $tbOrg: $('.tbOrg'),
        $tbReon: $('.tbReon'),
        $tbBrLK: $('.tbBrLK'),
        $tbSUP: $('.tbSUP'),
        $tbDatum: $('.tbDatum'),

        $btnPotAz: $('.btnPotAz'),
        $btnBrisi: $('.btnBrisi'),       

        jsfINIT: function () {

            vAzurDoz.jsfNapunDoz();

            vAzurDoz.$btnPotAz.on('click', function () {
                vAzurDoz.jsfIzmeniKorisnika();
            });

            vAzurDoz.$btnBrisi.on('click', function () {
                vAzurDoz.jsfBrisiKorisnika();
            });

        },


        //======================================      
        jsfNapunDoz: function () {
            //======================================             
            
            mST = 2;
            var dataParam = "{mST:" + mST + "}";

            vAzurDoz.$lstDoz.find('option').remove();
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/NapuniZaStampu"),               
                dataType: "json",
                data: dataParam,
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var items = $.parseJSON(data.d);
                    vAzurDoz.$lstDoz.append('<option value="0">izaberi broj</option>')
                    for (var i = 0; i < items.length; i++) {
                        var mIdDoz = items[i].IdDoz.toString();
                        var mBroj = items[i].IdDozC.toString();
                        vAzurDoz.$lstDoz.append('<option value="' + mIdDoz + '">' + mBroj + '</option>')
                    }

                },
                complete: function (xhr, status) {
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {

                var opcije = vAzurDoz.$lstDoz.find('option');
                opcije.on('click', function () {
                    $this = $(this);
                    var mIdDoz = $this.val();
                    var mBroj = $this.text();
                    vAzurDoz.jsfPrikaziKorisnika1(mBroj);

                });

            }).fail(function () { console.log(' fail'); });  // end ajax

        },


        //======================================
        jsfPrikaziKorisnika1: function (mBroj) {
            //======================================    
            if (vAzurDoz.$lstDoz.val() == 0) {
                alert("Izaberite dozvolu !!!");
                return;
            }

            var dataParam = "{mBroj:'" + mBroj + "'}";
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/PrikaziKorisnika1"),                
                dataType: "json",
                data: dataParam,
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    var itemss = data.d;
                    var items = $.parseJSON(data.d);

                    var mBroj = items[0].IdDozC.toString();
                    var mIme = items[0].Ime.toString();
                    var mZvanje = items[0].Zvanje.toString();
                    var mPreduzece = items[0].Preduzece.toString();
                    var mOrgDeo = items[0].OrgDeo.toString();
                    var mReon = items[0].Reon.toString();
                    var mBrLK = items[0].BrLK.toString();
                    var mSUP = items[0].SUP.toString();
                    var mDatum = items[0].Datum.toString();
                    var mStampa = items[0].Stampa.toString();

                    if (mStampa == 0) var mStatus = 'NIJE ODSTAMPANA ';
                    else var mStatus = 'ODSTAMPANA ';

                    var mPO = mPreduzece + ' -  ' + mOrgDeo

                    vAzurDoz.$tdBroj.text(mBroj);
                    vAzurDoz.$tdStatus.text(mStatus);
                    vAzurDoz.$tbIme.val(mIme);
                    vAzurDoz.$tbZvanje.val(mZvanje);
                    vAzurDoz.$tbPreduzece.val(mPreduzece);
                    vAzurDoz.$tbOrg.val(mOrgDeo);
                    vAzurDoz.$tbReon.val(mReon);
                    vAzurDoz.$tbBrLK.val(mBrLK);
                    vAzurDoz.$tbSUP.val(mSUP);
                    vAzurDoz.$tbDatum.val(mDatum);

                },
                complete: function (xhr, status) {
                },
                error: function () { console.log(' errr'); }
            }).done(function () {

            }).fail(function () { console.log(' fail'); });  // end ajax

        }, //jsfPrikazi Korisnika
        //======================================
        jsfIzmeniKorisnika: function () {
        //======================================

            if (vAzurDoz.$lstDoz.val() == 0) {
                alert("Izaberite dozvolu !!!");
                return;
            }

            var mUsp = "X";

            var mBroj = vAzurDoz.$tdBroj.text().trim();
            var mIme = vAzurDoz.$tbIme.val().trim();
            var mZvanje = vAzurDoz.$tbZvanje.val().trim();
            var mPred = vAzurDoz.$tbPreduzece.val().trim();
            var mOrg = vAzurDoz.$tbOrg.val().trim();
            var mReon = vAzurDoz.$tbReon.val().trim();
            var mBrLK = vAzurDoz.$tbBrLK.val().trim();
            var mSUP = vAzurDoz.$tbSUP.val().trim();
            var mDatum = vAzurDoz.$tbDatum.val().trim();

            var mPP = ' ';
            var myJSONObject = {
                "Parametri4UDF": {
                    mBroj: mBroj,
                    mIme: mIme,
                    mZvanje: mZvanje,
                    mPred: mPred,
                    mOrg: mOrg,
                    mReon: mReon,
                    mBrLK: mBrLK,
                    mSUP: mSUP,
                    mDatum: mDatum
                }
            };
            var udfParam = JSON.stringify(myJSONObject);
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/IzmeniKorisnika"),                
                dataType: "json",
                data: udfParam,
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    mUsp = data.d;

                },
                complete: function (xhr, status) {
                    if (mUsp == "U") { alert("Uspesna izmena !!!"); }
                    else { alert("NEUSPESNA IZMENA !!!"); }
                },
                error: function () { alert('Greska jsfDodajKorisnika'); }
            }).done(function () {

            }).fail(function () { });  // end ajax     

        }, //jsfIzmeniSlog
        //-----------------------------------------------
        jsfBrisiKorisnika: function () {
            //-----------------------------------------------         

            if (vAzurDoz.$lstDoz.val() == 0) {
                alert("Izaberite dozvolu !!!");
                return;
            }
            var uspesno = "X";
            var mBroj = vAzurDoz.$tdBroj.text();
            var dataParam = "{mBroj:'" + mBroj + "'}";

            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/BrisiKorisnika"),                
                dataType: "json",
                data: dataParam,
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    uspesno = data.d;                  
                },

                complete: function (xhr, status) {
                    if (uspesno == "U") {                        
                        vAzurDoz.jsfNapunDoz();
                        alert("Uspesno brisanje !!!");
                    }
                    else { alert("NEUSPESNO BRISANJE !!!"); }

                },
                error: function () { alert('Greska jsfBrisiDozvolu'); }
            }).done(function () {

                vAzurDoz.$tdBroj.text(" ");
                vAzurDoz.$tdStatus.text(" ");
                vAzurDoz.$tbIme.val(" ");
                vAzurDoz.$tbZvanje.val(" ");
                vAzurDoz.$tbPreduzece.val(" ");
                vAzurDoz.$tbOrg.val(" ");
                vAzurDoz.$tbReon.val(" ");
                vAzurDoz.$tbBrLK.val(" ");
                vAzurDoz.$tbSUP.val(" ");
                vAzurDoz.$tbDatum.val(" ");

            }).fail(function () { });  // end ajax           
        }
    }
    vAzurDoz.jsfINIT();
}