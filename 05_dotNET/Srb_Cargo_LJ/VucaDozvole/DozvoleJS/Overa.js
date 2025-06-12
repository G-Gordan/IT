function fOvera() {
    var vOvera = {


        $lstDoz: $('.lstDoz'),
        $lstGod: $('.lstGod'),

        $btnOvera: $('.btnOvera'),
        $tabOv: $('.tabOv'),
       
        jsfINIT: function () {                      
           
            vOvera.jsfNapuniDozvole();
            vOvera.jsfNapuniGodine();        

            vOvera.jsfPrikaziOverene();
            vOvera.$btnOvera.on('click', function () {               
                vOvera.jsfDodajOveru();
            });
        },
        //======================================      
        jsfNapuniDozvole: function () {
            //======================================             
           
            vOvera.$lstDoz.find('option').remove();
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/NapuniDozvole"),               
                dataType: "json",
                data: {},
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var items = $.parseJSON(data.d);
                    vOvera.$lstDoz.append('<option value="0">izaberi broj</option>')
                    for (var i = 0; i < items.length; i++) {
                        var mIdDoz = items[i].IdDoz.toString();
                        var mBroj = items[i].IdDozC.toString();
                        vOvera.$lstDoz.append('<option value="' + mIdDoz + '">' + mBroj + '</option>')
                    }

                },
                complete: function (xhr, status) {
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {

                var opcije = vOvera.$lstDoz.find('option');
                opcije.on('click', function () {                  
                    $this = $(this);
                    var mIdDoz = $this.val();
                    var mBroj = $this.text();
                    vOvera.jsfNapuniGodine();
                    
                 
                });

            }).fail(function () { console.log(' fail'); });  // end ajax

        },
        //======================================      
        jsfNapuniGodine: function () {
            //======================================             
            var today = new Date();
            var god = today.getFullYear();           
            var god1 = god + 1;
            var god2 = god + 2;          
            vOvera.$lstGod.find('option').remove();
            vOvera.$lstGod.append('<option value=' + god + '>' + god + '</option>')
            vOvera.$lstGod.append('<option value=' + god1 + '>' + god1 + '</option>')
            vOvera.$lstGod.append('<option value=' + god2 + '>' + god2 + '</option>')          

        },
        //======================================   
        jsfDodajOveru: function () {
         //====================================== 
        
          mIdDoz = vOvera.$lstDoz.val();
          if (mIdDoz == 0) {
              alert('Izaberite dozvolu !!!');
              return;
          }
           mGodina =  vOvera.$lstGod.val();            
            var mPoruka = ' ';
            var myJSONObject = {
                "Parametri4UDF": {
                    mIdDoz: mIdDoz,
                    mGodina: mGodina
                   
                }
            };
            var udfParam = JSON.stringify(myJSONObject);

            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/DodajOveru"),              
                dataType: "json",
                data: udfParam,
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {                  
                    mPoruka = data.d;                  
               

                },
                complete: function (xhr, status) {
                    console.log(' comp');
                },
                error: function () { console.log(' errr'); }
            }).done(function () {               

                if (mPoruka == 'U') {
                    alert('Uspesno !!!');
                    vOvera.jsfPrikaziOverene();
                }
                if (mPoruka == 'N') {
                    alert('NEUSPEŠAN UNOS !!!');
                }
                if (mPoruka == 'P') {
                    alert('OVA DOZVOLA JE VEĆ OVERENA ZA IZABRANU GODINU !!!');
                }
                
               

            }).fail(function () { console.log(' fail'); });  // end ajax

        }, // jsfDodajOveru
        //======================================
        jsfPrikaziOverene: function () {
            //======================================            

            vOvera.$tabOv.find('tr').remove();
            $.ajax({
                type: "POST",
                url: Url("/AspxForme/WSDozvole.aspx/PrikaziOverene"),               
                dataType: "json",
                data: {},
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    var itemss = data.d;
                    var items = $.parseJSON(data.d);

                    for (var i = 0; i < items.length; i++) {
                        var mBroj = items[i].Broj.toString();
                        var mGodina = items[i].Godina.toString();
                        
                        vOvera.$tabOv.append('<tr><td  class="ovBroj">' + mBroj + '</td> <td class="ovGodina" >' + mGodina + '</td>  </tr>')
                    }
                },
                complete: function (xhr, status) {
                },
                error: function () { console.log(' errr'); }
            }).done(function () {


            }).fail(function () { console.log(' fail'); });  // end ajax

        } //jsfPrikazi Overene
       


    };
    vOvera.jsfINIT();
}