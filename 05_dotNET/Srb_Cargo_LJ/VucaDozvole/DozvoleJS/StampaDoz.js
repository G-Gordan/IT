function fStampaDoz() {
    var vStampaDoz = {
        $tbBrojS: $('.tbBrojS'),
        $lstDoz: $('.lstDoz'),
        $lstDozO: $('.lstDozO'),
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

        $staIme: $('.staIme'),
        $staZv: $('.staZv'),
        $staSek: $('.staSek'),
        $staFir: $('.staFir'),
        $staPru: $('.staPru'),
        $staLk: $('.staLk'),
        $staSup: $('.staSup'),
        $staDat: $('.staDat'),

        $stsBroj: $('.stsBroj'),
        $stsIme: $('.stsIme'),
        $stsZv: $('.stsZv'),
        $stsSek: $('.stsSek'),
        $stsFir: $('.stsFir'),
        $stsPru: $('.stsPru'),
        $stsLk: $('.stsLk'),
        $stsSup: $('.stsSup'),
        $stsDat: $('.stsDat'),


        $btnPrikk: $('.btnPrikk'),
        $btnStampp: $('.btnStampp'),
        $btnStampv: $('.btnStampv'),
        // $btnStamA4: $('.btnStamA4'),
        $btnPrikk1: $('.btnPrikk1'),
        $btnStampp1: $('.btnStampp1'),
        $btnStamAA: $('.btnStamAA'),
        $btnBrisi: $('.btnBrisi'),       

        $dCekaj: $('.dCekaj'),
        $embPdf: $('.embPdf'),

        $btnProba: $('.btnProba'),
        $btnProba1: $('.btnProba1'),
        $dProba: $('.dProba'),
        $dZaStampu: $('.dZaStampu'),  
        jsfINIT: function () {        
            
            vStampaDoz.jsfNapuniZaStampu();
            vStampaDoz.jsfNapuniOdstampane();
            vStampaDoz.$dCekaj.hide()

            vStampaDoz.$btnPrikk.on('click', function () {
                vStampaDoz.jsfNapraviListu('SL');
                if (mPutanjaPdf == '*') {
                    alert('Greska u izvestaju');
                }
                else {
                    window.open('ReportPdf/DozvolaVidi.pdf', 'mywindow');
                }
            });
            vStampaDoz.$btnPrikk1.on('click', function () {
                
            });

            vStampaDoz.$btnStampp.on('click', function () {
                mPutanjaPdf = vStampaDoz.jsfNapraviListu('PR');
                vStampaDoz.jsfNapuniZaStampu();
                vStampaDoz.jsfNapuniOdstampane();               
            });

            vStampaDoz.$btnStampp1.on('click', function () {              
               
                var mbr = vStampaDoz.$stsBroj.text();
                if (mbr == ' ') { alert('Izaberite dozvolu !!!'); return; }
                if (mbr == null) { alert('Izaberite dozvolu !!!'); return; }

               // alert('d11 !!!');
                var divElements = vStampaDoz.$dZaStampu.html();
               
                var mywindow = window.open('', 'dZaStampu', 'height=400,width=400');
                mywindow.document.write('<html><head><title>my div</title>');
                mywindow.document.write('</head><body >');
                mywindow.document.write(divElements);
                mywindow.document.write('</body></html>');

                mywindow.document.close(); // necessary for IE >= 10
                mywindow.focus(); // necessary for IE >= 10

                mywindow.print();
                mywindow.close();
                //alert('osštampano !!!'); 

                vStampaDoz.jsfStampana();
                vStampaDoz.jsfNapuniZaStampu();
                vStampaDoz.jsfNapuniOdstampane();

                vStampaDoz.$stsBroj.text(" ");
                vStampaDoz.$stsIme.text(" ");
                vStampaDoz.$stsZv.text(" ");
                vStampaDoz.$stsSek.text(" ");
                vStampaDoz.$stsPru.text(" ");
                vStampaDoz.$stsLk.text(" ");
                vStampaDoz.$stsSup.text(" ");
                vStampaDoz.$stsDat.text(" ");



                vStampaDoz.$staIme.text(" ");
                vStampaDoz.$staZv.text(" ");
                vStampaDoz.$staSek.text(" ");
                vStampaDoz.$staPru.text(" ");
                vStampaDoz.$staLk.text(" ");
                vStampaDoz.$staSup.text(" ");
                vStampaDoz.$staDat.text(" ");

               
            });

            //CR
            vStampaDoz.$btnStampv.on('click', function () {
                mPutanjaPdf = vStampaDoz.jsfNapraviListu('PRV');
                if (mPutanjaPdf == '*') {
                    alert('Greska u izvestaju');
                }
                else {
                    window.open('ReportPdf/DozvolaStampaj.pdf', 'mywindow');
                }
                
                vStampaDoz.jsfNapuniZaStampu();
                vStampaDoz.jsfNapuniOdstampane();
            });           
               
          
            vStampaDoz.$btnProba.on('click', function () {

                var opcije = vStampaDoz.$lstDozO.find('option');
                var doc = vStampaDoz.$dProba.find('embPdf');

                //var doc = document.getElementById(embPdf);
                //var doc = vStampaDoz.$embPdf;
                alert(doc);

                ////Wait until PDF is ready to print    
                //if (typeof doc.print === 'undefined') {
                //    setTimeout(function () { printDocument(embPdf); }, 1000);
                //} else {
                //    doc.print();
                //}


                
            });

            vStampaDoz.$btnBrisi.on('click', function () {
               vStampaDoz.jsfBrisi();
              //  alert(mPutanjaPdf);
                vStampaDoz.jsfNapuniZaStampu();
                vStampaDoz.jsfNapuniOdstampane();

               
            });          
           

        },
        //======================================      
        jsfNapuniZaStampu: function () {
            //======================================             
            // var dataParam = "{mST:" + mST + "}";
            mST = 0;
            var dataParam = "{mST:" + mST + "}";

            vStampaDoz.$lstDoz.find('option').remove();
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/NapuniZaStampu"),               
                dataType: "json",
                data: dataParam,
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {                  
                    var items = $.parseJSON(data.d);                    
                    vStampaDoz.$lstDoz.append('<option value="0">izaberi broj</option>')
                    for (var i = 0; i < items.length; i++) {
                        var mIdDoz = items[i].IdDoz.toString();
                        var mBroj = items[i].IdDozC.toString();
                        vStampaDoz.$lstDoz.append('<option value="' + mIdDoz + '">' + mBroj + '</option>')
                    }

                },
                complete: function (xhr, status) {
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {               
               
                var opcije = vStampaDoz.$lstDoz.find('option');
                opcije.on('click', function () {
                    $this = $(this);
                    var mIdDoz = $this.val();
                    var mBroj = $this.text();                    
                    vStampaDoz.jsfPrikaziKorisnika1(mBroj);

                });

            }).fail(function () { console.log(' fail'); });  // end ajax

        },
        //======================================      
        jsfNapuniOdstampane: function () {
            //======================================             
           
            mST = 1;
            var dataParam = "{mST:" + mST + "}";

            vStampaDoz.$lstDozO.find('option').remove();
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/NapuniZaStampu"),                
                dataType: "json",
                data: dataParam,
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {                  
                
                    var items = $.parseJSON(data.d);                    
                    vStampaDoz.$lstDozO.append('<option value="0">izaberi broj</option>')
                    for (var i = 0; i < items.length; i++) {
                        var mIdDoz = items[i].IdDoz.toString();
                        var mBroj = items[i].IdDozC.toString();                      

                        vStampaDoz.$lstDozO.append('<option value="' + mIdDoz + '">' + mBroj + '</option>')
                    }

                },
                complete: function (xhr, status) {
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {              
               
                var opcije = vStampaDoz.$lstDozO.find('option');
                opcije.on('click', function () {
                    $this = $(this);
                    var mIdDoz = $this.val();
                    var mBroj = $this.text();                   
                    vStampaDoz.jsfPrikaziKorisnika1(mBroj);

                });

            }).fail(function () { console.log(' fail'); });  // end ajax

        },
        //======================================
        jsfPrikaziKorisnika1: function (mBroj) {
        //======================================          
              
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
                    

                    var mPO = mPreduzece + ' -  ' + mOrgDeo

                    vStampaDoz.$stsBroj.text(mBroj);
                    vStampaDoz.$stsIme.text(mIme);
                    vStampaDoz.$stsZv.text(mZvanje);
                    vStampaDoz.$stsSek.text(mPO);
                    vStampaDoz.$stsPru.text(mReon);
                    vStampaDoz.$stsLk.text(mBrLK);
                    vStampaDoz.$stsSup.text(mSUP);
                    vStampaDoz.$stsDat.text(mDatum);

                                                      
                    
                    vStampaDoz.$staIme.text(mIme);
                    vStampaDoz.$staZv.text(mZvanje);
                    vStampaDoz.$staSek.text(mPO);
                    vStampaDoz.$staPru.text(mReon);
                    vStampaDoz.$staLk.text(mBrLK);
                    vStampaDoz.$staSup.text(mSUP);
                    vStampaDoz.$staDat.text(mDatum);

                   

             
            },
            complete: function (xhr, status) {
            },
            error: function () { console.log(' errr'); }
        }).done(function () {               
            


        }).fail(function () { console.log(' fail'); });  // end ajax

        }, //jsfPrikazi Korisnika
        
        //======================================      
        jsfStampana: function () {
        //======================================            
           
            var mBroj = vStampaDoz.$stsBroj.text().trim();
            var dataParam = "{mBroj:'" + mBroj + "'}";
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/Stampana"),
                dataType: "json",
                data: dataParam,
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    mBroj = data.d;

                },
                complete: function (xhr, status) {
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {

            }).fail(function () { console.log(' fail'); });  // end ajax

        },//jsfNapraviListu
        //-----------------------------------------------
        jsfNapraviListu: function (mRep) {
        //-----------------------------------------------         
          
            var mDoz = vStampaDoz.$stsBroj.text();        

            var myJSONObject = {
                "Parametri4UDF": {
                    mRep: mRep,
                    mDoz: mDoz
                }
            };
            var udfParam = JSON.stringify(myJSONObject);

            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/FormirajListu"),
                /*  url: "../AspxForme/WSTelefoni.aspx/FormirajListu",*/
                dataType: "json",
                data: udfParam,
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {
                        vStampaDoz.$dCekaj.show();
                  }, 
                async: false,
                success: function (data) {
                    mPutanjaPdf = data.d;                                            
                },

                complete: function (xhr, status) {
                     vStampaDoz.$dCekaj.hide();

                },
                error: function () { alert('Greska jsfNapraviListu'); }
            }).done(function () {

            }).fail(function () { });  // end ajax

            return mPutanjaPdf;
        }


    }
    vStampaDoz.jsfINIT();
}