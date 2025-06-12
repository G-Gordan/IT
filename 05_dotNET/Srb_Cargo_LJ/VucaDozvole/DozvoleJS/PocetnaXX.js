function fPocetna() {
    var vPocetna = {        
        $dMesec: $('.dMesec'),
        $zagMesec: $('.zagMesec'),
        $zagGodina: $('.zagGodina'),
        $lblMesecPos: $('.lblMesecPos'),
       // $lstMeseci: $('.$lstMeseci'),
        //$lblMesec: $('.lblMesec'),       
        //$lblPoruka: $('.lblPoruka'),
        $btnRacunPR: $('.btnRacunPR'),
        $btnMaticnaPR: $('.btnMaticnaPR'),       
        $lstMeseci: $('.lstMeseci'),

        $lblMM: $('.lblMM'),
        $td1: $('.td1'),
        $td2: $('.td2'),
        $td3: $('.td3'),
        $td4: $('.td4'),
        $td5: $('.td5'),
        $td6: $('.td6'),
        $td7: $('.td7'),
        $td8: $('.td8'),
        $td10: $('.td10'),
      //  $td11: $('.td11'),

        jsfINIT: function () {         
            this.jsfPocetnoStanje();
           //alert('aaaa111');
            var mMesec = vPocetna.$zagMesec.text().toString();
            var mGodina = vPocetna.$zagGodina.text().toString();

            //var mm = vPocetna.$dMesec.attr('data-mesec').toString();
            //var gg = vPocetna.$dMesec.attr('data-godina').toString();
            //alert('aaaa'); alert(mm); alert(gg);

            //var mMesec1=vPocetna.$dMesec.attr('data-mesec');
            //var mGodina1 = vPocetna.$dMesec.attr('data-godina');

           // alert('ppp'); alert(mMesec1); alert(mGodina1);
            this.jsfStatistika();
            
            var opcije = vPocetna.$lstMeseci.find('option');
            opcije.on('click', function () {
                $this = $(this);                
                var mMM = $this.val();              
                vPocetna.$zagMesec.text(mMM);
                vPocetna.$dMesec.attr('data-mesec', mMM);
               // vPocetna.jsfStatistika(mMesec, mGodina);
                vPocetna.jsfStatistika();
               
            });

            this.$btnRacunPR.on('click', function () {
                var mMesec = vPocetna.$zagMesec.text().toString();
                var mGodina = vPocetna.$zagGodina.text().toString();               
                vPocetna.jsfPostojiRacun(mMesec, mGodina);              
            });
            this.$btnMaticnaPR.on('click', function () {
                var mMesec = vPocetna.$zagMesec.text().toString();
                var mGodina = vPocetna.$zagGodina.text().toString();
                vPocetna.jsfPostojiMaticna(mMesec, mGodina);
            });
           
        },
        //======================================      
        jsfPocetnoStanje : function () {
         //======================================    
          //  alert('pocetna');
           //var  mMesecPos=
           //var  mGodina=
           vPocetna.$lblMesecPos.text('');       
           $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSTelefoni.aspx/PocetnoStanje"),
               /* url: "../AspxForme/WSTelefoni.aspx/PocetnoStanje",    */      
                dataType: "json",
                data: {},
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {                  
                    var items = $.parseJSON(data.d);
                    mMesecPos = items[0].MesecPos.toString();                  
                    mGodina = items[0].Godina.toString();
                   // alert('pppa'); alert(mMesecPos); alert(mGodina);
                },
                complete: function (xhr, status) {
                    vPocetna.$lblMesecPos.text(mMesecPos);
                    var mMesecTekN = parseInt(mMesecPos) + 1;
                    if (mMesecTekN > 12) mMesecTekN = 12;
                    var mMesecTek = String(mMesecTekN);
                    var mMesecTek = String(mMesecTekN);
                    if (mMesecTek.length == 1) mMesecTek = '0' + mMesecTek;
                    // vPocetna.$lstMeseci.find('option[value=07]').attr("selected", "selected");
                    vPocetna.$lstMeseci.find('option[value=' + mMesecTek + ']').attr("selected", "selected");
                    vPocetna.$zagMesec.text(mMesecTek);
                    vPocetna.$zagGodina.text(mGodina);
                    vPocetna.$dMesec.attr('data-mesec', mMesecTek);
                    vPocetna.$dMesec.attr('data-godina', mGodina);

                    vPocetna.$lblMM.text(mMesecTek);

                    //var mm = vPocetna.$dMesec.attr('data-mesec').toString();
                    //var gg = vPocetna.$dMesec.attr('data-godina').toString();
                    //alert('pppab'); alert(mm); alert(gg);

                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {             
            
                //vPocetna.$lblMesecPos.text(mMesecPos);
                //var mMesecTekN = parseInt(mMesecPos) + 1;
                //if (mMesecTekN > 12) mMesecTekN = 12;
                //var mMesecTek = String(mMesecTekN);
                //var mMesecTek = String(mMesecTekN);
                //if (mMesecTek.length == 1) mMesecTek = '0' + mMesecTek;             
                //// vPocetna.$lstMeseci.find('option[value=07]').attr("selected", "selected");
                //vPocetna.$lstMeseci.find('option[value='+mMesecTek+']').attr("selected", "selected");                         
                //vPocetna.$zagMesec.text(mMesecTek);
                //vPocetna.$zagGodina.text(mGodina);
                //vPocetna.$dMesec.attr('data-mesec', mMesecTek);
                //vPocetna.$dMesec.attr('data-godina', mGodina);
                
                ////var mm = vPocetna.$dMesec.attr('data-mesec').toString();
                ////var gg = vPocetna.$dMesec.attr('data-godina').toString();
                ////alert('pppab'); alert(mm); alert(gg);

            }).fail(function () { console.log(' fail'); });  // end ajax

        }, //jsfPocetnoStanje
        //======================================      
        jsfPostojiRacun: function (mMesec, mGodina) {
            //======================================        
           
            var myJSONObject = { "Parametri4UDF": { mMesec: mMesec, mGodina: mGodina } };
            var udfParam = JSON.stringify(myJSONObject);
       
            var mPostoji = '9';
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSTelefoni.aspx/RacunPostoji"),
                /* url: "../AspxForme/WSTelefoni.aspx/RacunPRostoji",    */
                dataType: "json",
                data: udfParam,
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {                  
                    mPostoji = data.d;
                                                 
                },
                complete: function (xhr, status) {                   
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {
                if (mPostoji == '0') { vPocetna.jsfPripremiRacun(); }
                else if (mPostoji == '1') {                  
                    var txt;
                    var r = confirm("Račun već postoji !!! Želite li da ponovite pripremu računa ?");
                    if (r == true) {
                        vPocetna.jsfPripremiRacun();                        
                    } else {
                       
                    }
                }
                else { alert('GRESKA u jsfPostojiRacun'); };

            }).fail(function () { console.log(' fail'); });  // end ajax

        }, //jsfPocetnoStanje
        //======================================      
        jsfPripremiRacun : function () {
        //======================================        
        
         var mMesec = vPocetna.$zagMesec.text().toString();
         var mGodina = vPocetna.$zagGodina.text().toString();
        
        var myJSONObject = { "Parametri4UDF": { mMesec: mMesec, mGodina: mGodina } };
        var udfParam = JSON.stringify(myJSONObject);
       
        var mRezultat = 0;
        $.ajax({
            type: "POST",
            url: Url("/AspxForme/WSTelefoni.aspx/RacunPR"),
            /* url: "../AspxForme/WSTelefoni.aspx/RacunPR",    */
            dataType: "json",
            data: udfParam,
            async: false,
            contentType: "application/json; charset=utf-8",
            success: function (data) {                  
                mRezultat = data.d;
                                                 
            },
            complete: function (xhr, status) {                   
                console.log(' comp');
            },
            error: function () { console.log(' errr'); }
        }).done(function () {
           // alert('gotovo'); alert(mRezultat);
            if (mRezultat == 0) { alert('Nema pebačenih slogova !!!'); }
            else { vPocetna.$td2.text(mRezultat); alert('Završena priprema računa !!!'); };

        }).fail(function () { console.log(' fail'); });  // end ajax

        }, //jsfPocetnoStanje  

        //======================================      
        jsfPostojiMaticna: function (mMesec, mGodina) {
            //======================================        

            var myJSONObject = { "Parametri4UDF": { mMesec: mMesec, mGodina: mGodina } };
            var udfParam = JSON.stringify(myJSONObject);

            var mPostoji = '9';
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSTelefoni.aspx/MaticnaPostoji"),
                /* url: "../AspxForme/WSTelefoni.aspx/RacunPRostoji",    */
                dataType: "json",
                data: udfParam,
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    mPostoji = data.d;

                },
                complete: function (xhr, status) {
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {
                if (mPostoji == '0') { vPocetna.jsfPripremiMaticnu(); }
                else if (mPostoji == '1') {
                    var txt;
                    var r = confirm("Već postoje podaci u matičnoj za  tekući mesec !!! Želite li da ponovite postupak ?");
                    if (r == true) {
                        vPocetna.jsfPripremiMaticnu();
                    } else {

                    }
                }
                else { alert('GRESKA u jsfPostojiRacun'); };

            }).fail(function () { console.log(' fail'); });  // end ajax

        }, //jsfPocetnoStanje
        //======================================      
        jsfPripremiMaticnu: function () {
            //======================================        

            var mMesec = vPocetna.$zagMesec.text().toString();
            var mGodina = vPocetna.$zagGodina.text().toString();

            var myJSONObject = { "Parametri4UDF": { mMesec: mMesec, mGodina: mGodina } };
            var udfParam = JSON.stringify(myJSONObject);

            var mRezultat = ' ';
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSTelefoni.aspx/MaticnaPR"),
                /* url: "../AspxForme/WSTelefoni.aspx/RacunPR",    */
                dataType: "json",
                data: udfParam,
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    mRezultat = data.d;

                },
                complete: function (xhr, status) {
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {
                if (mRezultat == 'N') { alert('GRESKA u jsfPripremiMaticnu'); }
                else { alert('Završena priprema matične !!!'); };

            }).fail(function () { console.log(' fail'); });  // end ajax

        }, //jsfPocetnoStanje  
        //======================================      
        jsfStatistika: function () {
        //======================================        
           // alert('jsfStatistika');

            var mMesec = vPocetna.$dMesec.attr('data-mesec').toString();
            var mGodina = vPocetna.$dMesec.attr('data-godina').toString();
        //  alert('jsfStatistika 2b'); alert(mMesec); alert(mGodina);
        //var mMesec = vPocetna.$zagMesec.text().toString();
            //var mGodina = vPocetna.$zagGodina.text().toString();
            vPocetna.$lblMM.text(mMesec);
        
        var myJSONObject = { "Parametri4UDF": { mMesec: mMesec, mGodina: mGodina } };
        var udfParam = JSON.stringify(myJSONObject);
        //alert(udfParam);
        var mRezultat = ' ';
        $.ajax({
            type: "POST",           
            url: Url("/AspxForme/WSTelefoni.aspx/Statistika"),
           // url: "../AspxForme/WSTelefoni.aspx/Statistika",
            dataType: "json",
            data: udfParam,
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                //alert('aaa');
                var items = $.parseJSON(data.d);
                mSMS = items[0].mSMS.toString();               
                mRoming = items[0].mRoming.toString();;
                mMedjun = items[0].mMedjun.toString();;
                mPlacTelekomu = items[0].mPlacTelekomu.toString();;
                mNaRate = items[0].mNaRate.toString();
                mUplatnice = items[0].mUplatnice.toString();;
                mMaticna = items[0].mMaticna.toString();;
                mTelekom = items[0].mTelekom.toString();;
                mRacunObr = items[0].mRacunObr.toString();;
               //mRacunLD = items[0].mRacunLD.toString();

                vPocetna.$td1.text(mMaticna);
                vPocetna.$td2.text(mTelekom);
                vPocetna.$td3.text(mSMS);
                vPocetna.$td4.text(mRoming);
                vPocetna.$td5.text(mMedjun);
                vPocetna.$td6.text(mPlacTelekomu);
                vPocetna.$td7.text(mNaRate);
                vPocetna.$td8.text(mUplatnice);

                vPocetna.$td10.text(mRacunObr);
              // vPocetna.$td11.text(mRacunLD);
                                                               
            },
            complete: function (xhr, status) {                   
                console.log(' comp');
            },
            error: function () { console.log(' errr'); }
        }).done(function () {               
            

        }).fail(function () { console.log(' fail'); });  // end ajax

    } //jsfPocetnoStanje     
    };
    vPocetna.jsfINIT();
}