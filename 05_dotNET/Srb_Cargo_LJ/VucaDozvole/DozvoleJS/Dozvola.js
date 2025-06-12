function fDozvola() {
    var vDozvola = {

        $btnDozvola: $('.btnDozvola'),

        jsfINIT: function () {
            vDozvola.$btnDozvola.on('click', function () {
                alert('aaa');
                mPutanjaPdf = vDozvola.jsfNapraviListu('DOZ', 10);
                if (mPutanjaPdf == '*') {
                    alert('Greska u izvestaju');
                }
                else {
                    window.open('ReportPdf/Dozvola.pdf', 'mywindow');
                }

            });

        },
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
            /*  url: "../AspxForme/WSTelefoni.aspx/FormirajListu",*/
            dataType: "json",
            data: udfParam,
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
               // vReports.$dCekaj.show();
            },
            async: false,               
            success: function (data) {
                mPutanjaPdf = data.d;
                //if (mRep == 'MT')  vReports.$lblRep1.text('Prikazano !!!');
                ////alert('mPutanjaPdf'); alert(mPutanjaPdf);
                //if (mRep == 'T') vReports.$lblRep7.text('Prikazano !!!');
                //if (mRep == 'OR') vReports.$lblRep6.text('Prikazano !!!');
                //if (mRep == 'RK') { 
                //    if (mPutanjaPdf == 'P') vReports.$lblRep2.text('NE POSTOJI KONAČNI OBRAČUN !!!');
                //    else vReports.$lblRep2.text('Prikazano !!!');
                //}
                //if (mRep == 'ZB') vReports.$lblRep3.text('Prikazano !!!');
                //if (mRep == 'R')  vReports.$lblRep4.text('Prikazano !!!');
                //if (mRep == 'O')  vReports.$lblRep5.text('Prikazano !!!');                              
            },

            complete: function (xhr, status) {
              //  vReports.$dCekaj.hide();
                    
            },
            error: function () { alert('Greska jsfNapraviListu'); }
        }).done(function () {               
                
        }).fail(function () { });  // end ajax

        return mPutanjaPdf;
    }   //jsfNapraviListu

    }
    vDozvola.jsfINIT();
}