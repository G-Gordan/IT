function fMasterDoz() {
    var vMasterDoz = {


        $btnSpisak: $('.btnSpisak'),
        $btnAzurDoz: $('.btnAzurDoz'),
        $btnDozvola: $('.btnDozvola'),
        $btnPrikazKor: $('.btnPrikazKor'),
        $btnStampaDoz: $('.btnStampaDoz'),
        $btnStampaDoz1: $('.btnStampaDoz1'),
        $btnOvera: $('.btnOvera'),

        $dSadrzaj: $('.dSadrzaj'),


        jsfINIT: function () {
            var $aha
            $aha = this.$dSadrzaj.load(Url("/HtmlPages/Spisak.html .dSpisak"), function () {
                fSpisak();
            });

            var $aha1
            vMasterDoz.$btnSpisak.on('click', function () {
                $aha1 = vMasterDoz.$dSadrzaj.load(Url("/HtmlPages/Spisak.html .dSpisak"), function () {
                    fSpisak();
                });

            });

            var $aha1
            vMasterDoz.$btnAzurDoz.on('click', function () {               
                $aha1 = vMasterDoz.$dSadrzaj.load(Url("/HtmlPages/AzurDoz.html .dAzurDoz"), function () {
                    fAzurDoz();
                });

            });
           
            var $aha1
            vMasterDoz.$btnPrikazKor.on('click', function () {
                $aha1 = vMasterDoz.$dSadrzaj.load(Url("/HtmlPages/PrikazKor.html .dPrikazKor"), function () {
                    fPrikazKor();
                });

            });
            
            var $aha1
            vMasterDoz.$btnStampaDoz1.on('click', function () {
                $aha1 = vMasterDoz.$dSadrzaj.load(Url("/HtmlPages/StampaDoz1.html .dStampaDoz1"), function () {
                    fStampaDoz();
                });

            });

            var $aha1
            vMasterDoz.$btnOvera.on('click', function () {              
                $aha1 = vMasterDoz.$dSadrzaj.load(Url("/HtmlPages/Overa.html .dOvera"), function () {
                    fOvera();
                });

            });
        }


    };
    vMasterDoz.jsfINIT();
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