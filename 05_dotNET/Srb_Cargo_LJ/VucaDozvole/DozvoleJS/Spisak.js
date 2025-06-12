function fSpisak() {
    var vSpisak = {       

        $tbBroj: $('.tbBroj'),
        $tbIme: $('.tbIme'),
        $tbZvanje: $('.tbZvanje'),
        $tbPred: $('.tbPred'),
        $tbOrg: $('.tbOrg'),
        $tbReon: $('.tbReon'),
        $tbBrLK: $('.tbBrLK'),
        $tbSUP: $('.tbSUP'),
        $tbDatum: $('.tbDatum'),
        
        $btnNovi: $('.btnNovi'),
        $btnUnos: $('.btnUnos'),
        $dSP: $('.dSP'),
       
        $btnStDoz: $('.btnStDoz'),
        $btnStPrik: $('.btnStPrik'),

        $tabKor: $('.tabKor'),
        $dCekaj: $('.dCekaj'),
        $dCekajImg: $('.dCekajImg'),
        $dSlikaU: $('.dSlikaU'),
        $dZaStampu: $('.dZaStampu'),

        $stsBroj: $('.stsBroj'),
        $stsIme: $('.stsIme'),
        $stsZv: $('.stsZv'),
        $stsSek: $('.stsSek'),
        $stsFir: $('.stsFir'),
        $stsPru: $('.stsPru'),
        $stsLk: $('.stsLk'),
        $stsSup: $('.stsSup'),
        $stsDat: $('.stsDat'),

        $staIme: $('.staIme'),
        $staZv: $('.staZv'),
        $staSek: $('.staSek'),
        $staFir: $('.staFir'),
        $staPru: $('.staPru'),
        $staLk: $('.staLk'),
        $staSup: $('.staSup'),
        $staDat: $('.staDat'),
       

        jsfINIT: function () {

            vSpisak.$tbIme.val(" ");
            vSpisak.$tbZvanje.val(" ");
            vSpisak.$tbPred.val(" ");
            vSpisak.$tbOrg.val(" ");
            vSpisak.$tbReon.val(" ");
            vSpisak.$tbBrLK.val(" ");
            vSpisak.$tbSUP.val(" ");
            vSpisak.$tbDatum.val(" ");

            vSpisak.$tbBroj.keyup(function (event) {
                if (event.keyCode == 13) {
                    vSpisak.$tbIme.focus();
                    mBroj=vSpisak.$tbBroj.val();
                    var mPostoji = vSpisak.jsfPostojiBroj();                 
                    if (mPostoji == 0) { vSpisak.$tbIme.focus(); }                   
                  
                }
            });

            //vSpisak.$tbIme.on('input', function () {
            //    alert('input');
              
            //    var mPostoji = vSpisak.jsfPostojiBroj();               
            //    if (mPostoji == 0) {
            //        alert('duzzzzzz'); 

            //        mBroj = vSpisak.$tbBroj.val();
            //        duz = mBroj.length;
            //        alert('duz'); alert(duz);
            //        if (duz == 1) nule = '000';
            //        if (duz == 2) nule = '00';
            //        if (duz == 3) nule = '0';
            //        mBrojC = nule + mBroj;
            //        alert('mBrojC'); alert(mBrojC);

            //        //var ans = ('0000' + mBroj).substring(mBroj.length);
            //        //alert('ans'); alert(ans);
            //        vSpisak.$tbBroj.val(mBrojC);
                   

            //    }

            //});

            vSpisak.$tbIme.keyup(function (event) {
                if (event.keyCode == 13) {                     
                    vSpisak.$tbZvanje.focus();
                }
            });
            vSpisak.$tbZvanje.keyup(function (event) {
                if (event.keyCode == 13) {
                    vSpisak.$tbPred.focus();
                }
            });
            vSpisak.$tbPred.keyup(function (event) {
                if (event.keyCode == 13) {
                    vSpisak.$tbOrg.focus();
                }
            });
            vSpisak.$tbOrg.keyup(function (event) {
                if (event.keyCode == 13) {
                    vSpisak.$tbReon.focus();
                }
            });
            vSpisak.$tbReon.keyup(function (event) {
                if (event.keyCode == 13) {
                    vSpisak.$tbBrLK.focus();
                }
            });

            vSpisak.$tbBrLK.keyup(function (event) {
                if (event.keyCode == 13) {
                    vSpisak.$tbSUP.focus();
                }
            });

            vSpisak.$tbSUP.keyup(function (event) {
                if (event.keyCode == 13) {
                    vSpisak.$tbDatum.focus();
                }
            });

            vSpisak.$tbDatum.keyup(function (event) {
                if (event.keyCode == 13) {
                    vSpisak.$btnStPrik.focus();
                }
            });

            

            vSpisak.jsfPrikaziBroj();
            vSpisak.jsfPrikaziKorisnike();

          
            vSpisak.$btnUnos.hide();
            vSpisak.$btnStDoz.hide();

            vSpisak.$dSP.hide();
            vSpisak.$dCekaj.hide();
            vSpisak.$dCekajImg.attr('src', Url("/Images/progressbar1.gif"));

            vSpisak.$btnNovi.on('click', function () {             
              
                vSpisak.$btnUnos.hide();
                vSpisak.$btnStDoz.hide();

                vSpisak.$tbBroj.val(" ");
                vSpisak.$tbIme.val(" ");
                vSpisak.$tbZvanje.val(" ");
                vSpisak.$tbOrg.val(" ");
                vSpisak.$tbPred.val(" ");
                vSpisak.$tbReon.val(" ");
                vSpisak.$tbBrLK.val(" ");
                vSpisak.$tbSUP.val(" ");
                vSpisak.$tbDatum.val(" ");

                vSpisak.$stsBroj.text(" ");
                vSpisak.$stsIme.text(" ");
                vSpisak.$stsZv.text(" ");
                vSpisak.$stsSek.text(" ");
                vSpisak.$stsPru.text(" ");
                vSpisak.$stsLk.text(" ");
                vSpisak.$stsSup.text(" ");
                vSpisak.$stsDat.text(" ");

                vSpisak.jsfPrikaziBroj();
             
                vSpisak.$btnUnos.hide();
                vSpisak.$btnStDoz.hide();
                          
            });

            vSpisak.$btnUnos.on('click', function () {
               if ( vSpisak.$tbIme.val()==" ") {
                    alert("Unesite Ime i prezime !!!");
                }
               else {                  
                    vSpisak.jsfDodajKorisnika(0);

                    vSpisak.jsfPrikaziBroj();

                    vSpisak.$tbIme.val(" ");
                    vSpisak.$tbZvanje.val(" ");
                    vSpisak.$tbOrg.val(" ");
                    vSpisak.$tbPred.val(" ");
                    vSpisak.$tbReon.val(" ");
                    vSpisak.$tbBrLK.val(" ");
                    vSpisak.$tbSUP.val(" ");
                    vSpisak.$tbDatum.val(" ");

                    vSpisak.$stsBroj.text(" ");
                    vSpisak.$stsIme.text(" ");
                    vSpisak.$stsZv.text(" ");
                    vSpisak.$stsSek.text(" ");
                    vSpisak.$stsPru.text(" ");
                    vSpisak.$stsLk.text(" ");
                    vSpisak.$stsSup.text(" ");
                    vSpisak.$stsDat.text(" ");
                    
                    vSpisak.$staIme.text(" ");
                    vSpisak.$staZv.text(" ");
                    vSpisak.$staSek.text(" ");
                    vSpisak.$staPru.text(" ");
                    vSpisak.$staLk.text(" ");
                    vSpisak.$staSup.text(" ");
                    vSpisak.$staDat.text(" ");

                    vSpisak.$btnUnos.hide();
                    vSpisak.$btnStDoz.hide();
                       
               }
              
                          
            });

            vSpisak.$btnStPrik.on('click', function () {
                mBroj = vSpisak.$tbBroj.val();
                var mPostoji = vSpisak.jsfPostojiBroj(mBroj);
               // alert('mPostoji'); alert(mPostoji);
                if (mPostoji == 1 || mPostoji == 0)
                {
                    if (mPostoji == 1) {
                        // vSpisak.$tbZvanje.focus();
                     //   alert('p1');
                        return;
                    } else
                      //  alert('p0');
                    if (vSpisak.$tbIme.val() == " ") {
                        alert("Unesite Ime i prezime !!!");
                        return;
                    } else {
                        var nule = '';
                        mBroj = vSpisak.$tbBroj.val();
                        duz = mBroj.length;
                      //  alert('duz'); alert(duz);
                        if (duz == 1) nule = '000';
                        if (duz == 2) nule = '00';
                        if (duz == 3) nule = '0';
                        mBrojC = nule + mBroj;
                      //  alert('mBrojC'); alert(mBrojC);                                           

                        vSpisak.$tbBroj.val(mBrojC);

                        mIme = vSpisak.$tbIme.val();
                        mZvanje = vSpisak.$tbZvanje.val();
                        mPO = vSpisak.$tbPred.val() + " - " + vSpisak.$tbOrg.val();
                        mReon = vSpisak.$tbReon.val();
                        mBrLK = vSpisak.$tbBrLK.val();
                        mSUP = vSpisak.$tbSUP.val();
                        mDatum = vSpisak.$tbDatum.val();

                        vSpisak.$stsBroj.text(mBrojC);
                        vSpisak.$stsIme.text(mIme);
                        vSpisak.$stsZv.text(mZvanje);
                        vSpisak.$stsSek.text(mPO);
                        vSpisak.$stsPru.text(mReon);
                        vSpisak.$stsLk.text(mBrLK);
                        vSpisak.$stsSup.text(mSUP);
                        vSpisak.$stsDat.text(mDatum);

                        vSpisak.$staIme.text(mIme);
                        vSpisak.$staZv.text(mZvanje);
                        vSpisak.$staSek.text(mPO);
                        vSpisak.$staPru.text(mReon);
                        vSpisak.$staLk.text(mBrLK);
                        vSpisak.$staSup.text(mSUP);
                        vSpisak.$staDat.text(mDatum);

                        vSpisak.$btnUnos.show();
                        vSpisak.$btnStDoz.show();
                    }


                    //mIme = vSpisak.$tbIme.val();
                    //mZvanje = vSpisak.$tbZvanje.val();
                    //mPO = vSpisak.$tbPred.val() + " - " + vSpisak.$tbOrg.val();
                    //mReon = vSpisak.$tbReon.val();
                    //mBrLK = vSpisak.$tbBrLK.val();
                    //mSUP = vSpisak.$tbSUP.val();
                    //mDatum = vSpisak.$tbDatum.val();

                    //vSpisak.$stsIme.text(mIme);
                    //vSpisak.$stsZv.text(mZvanje);
                    //vSpisak.$stsSek.text(mPO);
                    //vSpisak.$stsPru.text(mReon);
                    //vSpisak.$stsLk.text(mBrLK);
                    //vSpisak.$stsSup.text(mSUP);
                    //vSpisak.$stsDat.text(mDatum);

                    //vSpisak.$staIme.text(mIme);
                    //vSpisak.$staZv.text(mZvanje);
                    //vSpisak.$staSek.text(mPO);
                    //vSpisak.$staPru.text(mReon);
                    //vSpisak.$staLk.text(mBrLK);
                    //vSpisak.$staSup.text(mSUP);
                    //vSpisak.$staDat.text(mDatum);

                    //vSpisak.$btnUnos.show();
                    //vSpisak.$btnStDoz.show();
                }
            else {alert('Nesto nije u redu !!!');}
            });

            vSpisak.$btnStDoz.on('click', function () {
                if (vSpisak.$tbIme.val() == " ") {
                    alert("Unesite Ime i prezime !!!");
                }
                else {                 
                   
                   // alert('s11');
                    var divElements = vSpisak.$dZaStampu.html();                 
                    var mywindow = window.open('', 'dZaStampu', 'height=800,width=800');
                    mywindow.document.write('<html><head><title>my div</title>');
                    mywindow.document.write('</head><body >');
                    mywindow.document.write(divElements);
                    mywindow.document.write('</body></html>');

                    mywindow.document.close(); // necessary for IE >= 10
                    mywindow.focus(); // necessary for IE >= 10

                    mywindow.print();
                    mywindow.close();
                    //alert('odštampano !!!');

                    vSpisak.jsfDodajKorisnika(1);
                    //vSpisak.jsfStampana();
                    vSpisak.jsfPrikaziKorisnike();                    
                   

                    vSpisak.jsfPrikaziBroj();
                    vSpisak.$tbIme.val(" ");
                    vSpisak.$tbZvanje.val(" ");
                    vSpisak.$tbOrg.val(" ");
                    vSpisak.$tbPred.val(" ");
                    vSpisak.$tbReon.val(" ");
                    vSpisak.$tbBrLK.val(" ");
                    vSpisak.$tbSUP.val(" ");
                    vSpisak.$tbDatum.val(" ");

                    vSpisak.$staIme.text(" ");
                    vSpisak.$staZv.text(" ");
                    vSpisak.$staSek.text(" ");
                    vSpisak.$staPru.text(" ");
                    vSpisak.$staLk.text(" ");
                    vSpisak.$staSup.text(" ");
                    vSpisak.$staDat.text(" ");

                    vSpisak.$stsIme.text(" ");
                    vSpisak.$stsZv.text(" ");
                    vSpisak.$stsSek.text(" ");
                    vSpisak.$stsPru.text(" ");
                    vSpisak.$stsLk.text(" ");
                    vSpisak.$stsSup.text(" ");
                    vSpisak.$stsDat.text(" ");

                    vSpisak.$btnUnos.hide();
                    vSpisak.$btnStDoz.hide();
                   
                      
                }               
           
            });
      
        },
        //======================================      
        jsfPrikaziBroj: function () {
        //======================================             

            var mBroj = '0000';
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/MaxBroj"),               
                dataType: "json",
                data: {},
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
              //  vSpisak.$tdBroj.text(mBroj);
                vSpisak.$tbBroj.val(mBroj);
               

            }).fail(function () { console.log(' fail'); });  // end ajax

        },
        //======================================      
        jsfPostojiBroj: function () {
        //======================================             
           // alert('b1');
            var mPostoji = 7;
            var mBroj = vSpisak.$tbBroj.val().trim();
            var dataParam = "{mBroj:'" + mBroj + "'}";
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/PostojiBroj"),
                dataType: "json",
                data: dataParam,
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    mPostoji = data.d;
                //    alert('b2');

                },
                complete: function (xhr, status) {
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {
              //  alert('b3');
                //  vSpisak.$tdBroj.text(mBroj);
                // vSpisak.$tbBroj.val(mBroj);
                if (mPostoji == 1) {
                    alert('Ovaj broj vec postoji !!!');
                    vSpisak.$tbBroj.focus();
                } else {
                    vSpisak.$tbIme.focus();
                }


            }).fail(function () { console.log(' fail'); });  // end ajax
            return mPostoji;
        },
        //======================================
        jsfDodajKorisnika: function (mStampa) {
        //======================================
          
            var mDat = vSpisak.$tbDatum.val();          

            var mUsp = "X";

          //  var mBroj = vSpisak.$tdBroj.text().trim();
            var mBroj = vSpisak.$tbBroj.val().trim();
            var mIme = vSpisak.$tbIme.val().trim();
            var mZvanje = vSpisak.$tbZvanje.val().trim();
            var mPred = vSpisak.$tbPred.val().trim();
            var mOrg = vSpisak.$tbOrg.val().trim();
            var mReon = vSpisak.$tbReon.val().trim();
            var mBrLK = vSpisak.$tbBrLK.val().trim();
            var mSUP = vSpisak.$tbSUP.val().trim();
            var mDatum = vSpisak.$tbDatum.val().trim();

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
                    mDatum: mDatum,
                    mStampa: mStampa
                }
            };
            var udfParam = JSON.stringify(myJSONObject);
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/DodajKorisnika"),               
                dataType: "json",
                data: udfParam,
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    mUsp = data.d;

                },
                complete: function (xhr, status) {
                    if (mUsp == "U") {                       
                         vSpisak.jsfPrikaziKorisnike();
                    }
                },
                error: function () { alert('Greska jsfDodajKorisnika'); }
            }).done(function () {

            }).fail(function () { });  // end ajax     
           
        }, //jsfDodajSlog
        //======================================
        jsfPrikaziKorisnike: function () {
        //======================================            
          
            vSpisak.$tabKor.find('tr').remove();         
             $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/PrikaziKorisnike"),                
                dataType: "json",
                data: {},
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    var itemss = data.d;
                    var items = $.parseJSON(data.d);
                
                    for (var i = 0; i < items.length; i++) {                     
                        var mBroj = items[i].IdDozC.toString();                     
                        var mIme = items[i].Ime.toString();
                        var mZvanje = items[i].Zvanje.toString();
                        var mOrgDeo = items[i].OrgDeo.toString();
                        var mReon = items[i].Reon.toString();
                        var mBrLK = items[i].BrLK.toString();
                        var mSUP = items[i].SUP.toString();
                        var mDatum = items[i].Datum.toString();
                        var mStampa = items[i].Stampa.toString();
                        var mIzdata = 'Ne';
                        if (mStampa == 1) var mIzdata = 'Da';
                        vSpisak.$tabKor.append('<tr><td  class="prBroj">' + mBroj + '</td> <td class="prIme" >' + mIme + '</td> <td class="prBrl">' + mBrLK + '</td> <td class="prDat">' + mDatum + ' <td  class="prIzd">' + mIzdata + '</td> </tr>')
                    }
                },
                complete: function (xhr, status) {
                },
                error: function () { console.log(' errr'); }
            }).done(function () {              
                             

            }).fail(function () { console.log(' fail'); });  // end ajax

        }, //jsfPrikazi Korisnika
        //-----------------------------------------------
        jsfNapraviListu: function (mRep) {
            //-----------------------------------------------
          //  var mDoz = vSpisak.$tdBroj.text().trim();
            var mDoz = vSpisak.$tbBroj.val().trim();
            
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
                dataType: "json",
                data: udfParam,
                contentType: "application/json; charset=utf-8",
                beforeSend: function () {
                    vSpisak.$dCekaj.show();
                }, 
                async: false,
                success: function (data) {
                    mPutanjaPdf = data.d;
                                               
                },

                complete: function (xhr, status) {
                    vSpisak.$dCekaj.hide();

                },
                error: function () { alert('Greska jsfNapraviListu'); }
            }).done(function () {

            }).fail(function () { });  // end ajax

            return mPutanjaPdf;
        },
        //======================================      
        jsfStampana: function () {
        //======================================            
        
         //   var mBroj = vSpisak.$tdBroj.text().trim();
            var mBroj = vSpisak.$tbBroj.val().trim();
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

        //======================================      
        jsfIsDate: function (mDatum0) {
            //======================================  
            var mDatum = vSpisak.jsfTrim(mDatum0);           
            
            var d = mDatum.substring(0, 2);
            var m = mDatum.substring(3, 5);
            var y = mDatum.substring(6);
           
            var composedDate = new Date(y, m, d);
            var cd = composedDate.getDate() == d &&
                    composedDate.getMonth() == m &&
                    composedDate.getFullYear() == y;

            return cd;
        },
        //======================================      
        jsfPadder: function (len, pad) {
            //======================================  
            if (len === undefined) {
                len = 1;
            } else if (pad === undefined) {
                pad = '0';
            }

            var pads = '';
            while (pads.length < len) {
                pads += pad;
            }

            this.pad = function (what) {
                var s = what.toString();
                return pads.substring(0, pads.length - s.length) + s;
            };
        },
        //======================================      
        jsfTrim: function (mString) {
            //======================================  
            return mString.replace(/^\s+|\s+$/g, "");
        }

    };
    vSpisak.jsfINIT();
}