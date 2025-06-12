function fPrikazKor() {
    var vPrikazKor = {
        $tabKorp: $('.tabKorp'),
        $btnStampa: $('.btnStampa'),
        $dCekaj: $('.dCekaj'),

        jsfINIT: function () {
         
            vPrikazKor.jsfPrikaziKorisnike();
           vPrikazKor.$dCekaj.hide();

            vPrikazKor.$btnStampa.on('click', function () {               
               
                mPutanjaPdf = vPrikazKor.jsfNapraviListu('SP', 0);
                if (mPutanjaPdf == '*') {
                    alert('Greska u izvestaju');
                }
                else {
                    window.open('ReportPdf/Spisak.pdf', 'mywindow');
                }

            });
           

        },

        //======================================
        jsfPrikaziKorisnike: function () {
        //======================================           
        
        vPrikazKor.$tabKorp.find('tr').remove();
            
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
                    var mPreduzece = items[i].Preduzece.toString();
                    var mOrgDeo = items[i].OrgDeo.toString();
                    var mReon = items[i].Reon.toString();
                    var mBrLK = items[i].BrLK.toString();
                    var mSUP = items[i].SUP.toString();
                    var mDatum = items[i].Datum.toString();
                    var mStampa = items[i].Stampa.toString();
                    var mIzdata = 'Ne';
                    if (mStampa == 1) var mIzdata = 'Da';
                    ii = Math.round(i/2);                  
                    if (i == ii * 2) {
                        var mRed = '<tr class="pRed1"><td class="pBroj" >' + mBroj + '</td> <td class="pIme" >' + mIme + '</td>  <td class="pZvanje" >' + mZvanje + '</td> <td  class="pPreduzece" >' + mPreduzece + '</td> <td class="pOrg" >' + mOrgDeo + '</td>  <td class="pReon">' + mReon + '</td> <td class="pBrl">' + mBrLK + '</td> <td class="pSup">' + mSUP + '</td> <td class="pDat">' + mDatum + '</td><td class="pIzd">' + mIzdata + '</td> </tr>';
                    }
                    else {
                        var mRed = '<tr class="pRed2"><td class="pBroj" >' + mBroj + '</td> <td class="pIme" >' + mIme + '</td>  <td class="pZvanje" >' + mZvanje + '</td> <td  class="pPreduzece" >' + mPreduzece + '</td> <td class="pOrg" >' + mOrgDeo + '</td>  <td class="pReon">' + mReon + '</td> <td class="pBrl">' + mBrLK + '</td> <td class="pSup">' + mSUP + '</td> <td class="pDat">' + mDatum + '</td><td class="pIzd">' + mIzdata + '</td> </tr>';
                    }                   
                    /* vPrikazKor.$tabKorp.append('<tr class="pRed1"><td class="pBroj" >' + mBroj + '</td> <td class="pIme" >' + mIme + '</td>  <td class="pZvanje" >' + mZvanje + '</td> <td  class="pPreduzece" >' + mPreduzece + '</td> <td class="pOrg" >' + mOrgDeo + '</td>  <td class="pReon">' + mReon + '</td> <td class="pBrl">' + mBrLK + '</td> <td class="pSup">' + mSUP + '</td> <td class="pDat">' + mDatum + '</td><td class="pIzd">' + mIzdata + '</td> </tr>') */
                    vPrikazKor.$tabKorp.append(mRed);                }
            },
            complete: function (xhr, status) {
            },
            error: function () { console.log(' errr'); }
        }).done(function () {                
                   

        }).fail(function () { console.log(' fail'); });  // end ajax

        }, //jsfPrikazi Korisnika
        //-----------------------------------------------
        jsfNapraviListu: function (mRep, mDoz) {
            //-----------------------------------------------
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
                    vPrikazKor.$dCekaj.show();
                },
                async: false,
                success: function (data) {
                    mPutanjaPdf = data.d;                                            
                },

                complete: function (xhr, status) {
                    vPrikazKor.$dCekaj.hide();

                },
                error: function () { alert('Greska jsfNapraviListu'); }
            }).done(function () {

            }).fail(function () { });  // end ajax

            return mPutanjaPdf;
        }   //jsfNapraviListu


    };
    vPrikazKor.jsfINIT();
}