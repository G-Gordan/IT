function fMasterTel() {
    var vMasterTel = {     

        $btnSpisak: $('.btnSpisak'),
        $btnDozvola: $('.btnDozvola'),
        $btnPrikazKor: $('.btnPrikazKor'),
        $btnStampaDoz: $('.btnStampaDoz'),

        $dSadrzaj: $('.dSadrzaj'),
         

        jsfINIT: function () {
            alert("master");
            var $aha
            $aha = this.$dSadrzaj.load(Url("/HtmlPages/Spisak.html .dSpisak"), function () {
                fSpisak();
            });           

            var $aha1
            vMasterTel.$btnSpisak.on('click', function () {
                    $aha1 = vMasterTel.$dSadrzaj.load(Url("/HtmlPages/Spisak.html .dSpisak"), function () {
                    fSpisak();
                });

            });
            var $aha1
            vMasterTel.$btnDozvola.on('click', function () {
                $aha1 = vMasterTel.$dSadrzaj.load(Url("/HtmlPages/Dozvola.html .dDozvola"), function () {
                   // fDozvola();
                });

            });
            var $aha1
            vMasterTel.$btnPrikazKor.on('click', function () {               
                $aha1 = vMasterTel.$dSadrzaj.load(Url("/HtmlPages/PrikazKor.html .dPrikazKor"), function () {
                    fPrikazKor();
                });

            });
            var $aha1
            vMasterTel.$btnStampaDoz.on('click', function () {
                alert('sssstttt');
                $aha1 = vMasterTel.$dSadrzaj.load(Url("/HtmlPages/StampaDoz.html .dStampaDoz"), function () {
                    fStampaDoz();
                });

            });
     
          
        }
         
       
   };
    vMasterTel.jsfINIT();
}
//..............................................................
function Url(relative)
//..............................................................
{
    var _relativeRoot = $("#RelativeUrl").attr('RelativeURL');// '<%= ResolveUrl("~/") %>';


    var resolved = relative;

    if (_relativeRoot != '/') resolved = _relativeRoot + relative;
    return resolved;
}