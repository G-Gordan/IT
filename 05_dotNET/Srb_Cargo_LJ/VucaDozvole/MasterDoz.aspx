<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterDoz.aspx.cs" Inherits="VucaDozvole.MasterDoz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <title>Dozvole</title>
    <%="<link href='" + ResolveUrl("~/Stilovi/jquery-ui-1.10.0.custom.min.css") + "' rel='stylesheet' type='text/css' />"%>  
     <%="<link href='" + ResolveUrl("~/Stilovi/jquery-ui-1.8.6.custom.css") + "' rel='stylesheet' type='text/css' />"%>  
     <%="<link href='" + ResolveUrl("~/StyleDoz.css") + "' rel='stylesheet' type='text/css' />"%>  

     <%="<script src='" + ResolveUrl("~/jQueryJS/jquery-1.10.2.js") + "' type='text/javascript'></script> "%>
     <%="<script src='" + ResolveUrl("~/jQueryJS/jquery-ui-1.10.0.custom.min.js") + "' type='text/javascript'></script> "%>

     <%="<script src='" + ResolveUrl("~/DozvoleJS/MasterDoz.js") + "' type='text/javascript'></script> "%> 


    <%-- <%="<script src='" + ResolveUrl("~/TelefoniJS/Pocetna.js") + "' type='text/javascript'></script> "%> 
     <%="<script src='" + ResolveUrl("~/TelefoniJS/Tekuci.js") + "' type='text/javascript'></script> "%> 
     <%="<script src='" + ResolveUrl("~/TelefoniJS/Reports.js") + "' type='text/javascript'></script> "%> 

     <%="<script src='" + ResolveUrl("~/TelefoniJS/ExportZaLD.js") + "' type='text/javascript'></script> "%> 
     <%="<script src='" + ResolveUrl("~/TelefoniJS/Tabele.js") + "' type='text/javascript'></script> "%> 
     <%="<script src='" + ResolveUrl("~/TelefoniJS/RacunObr.js") + "' type='text/javascript'></script> "%> --%>

     <%="<script src='" + ResolveUrl("~/DozvoleJS/Spisak.js") + "' type='text/javascript'></script> "%> 
    <%="<script src='" + ResolveUrl("~/DozvoleJS/Dozvola.js") + "' type='text/javascript'></script> "%> 
    <%="<script src='" + ResolveUrl("~/DozvoleJS/PrikazKor.js") + "' type='text/javascript'></script> "%> 
     <%="<script src='" + ResolveUrl("~/DozvoleJS/StampaDoz.js") + "' type='text/javascript'></script> "%> 
      <%="<script src='" + ResolveUrl("~/DozvoleJS/Overa.js") + "' type='text/javascript'></script> "%> 
     <%="<script src='" + ResolveUrl("~/DozvoleJS/AzurDoz.js") + "' type='text/javascript'></script> "%> 

     <script type="text/javascript">

      //  var _relativeRoot = "<%= ResolveUrl("~/") %>";
        $(document).ready(       

        function () {
            var _relativeRoot = "<%= ResolveUrl("~/") %>";
            $("#RelativeUrl").attr('RelativeURL', _relativeRoot);
            // alert('_relativeRoot'); alert(_relativeRoot); 
           
            fMasterDoz();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dOkvir" class="dOkvir">
     <div id="dZaglavlje" class="dZaglavlje"  >
         <div class="dZgLevo"  style="float:left; width:150px;padding-left:20px;">             <img src="Images/SrbVoz.PNG" />         </div>         
         <div  class="dZgDesno" style="float:left; color: #0076AE; font:bold 30px  Pristina;  font-style:italic; padding-left:100px;">    Dozvole za vožnju u upravljačnici vučnog vozila    </div>
         <div style="clear:both; font:normal 14px  arial;text-align:right; padding-right:20px;">Sektor  za IKT i marketing</div>
     </div>

     <div id="dMenu" class="dMenu" >           
         <input id="btnSpisak" type="button" value="Unos korisnika dozvole"  class="btnMenu btnSpisak" />  
          <input id="btnAzurDoz" type="button" value="Izmena podataka na dozvoli"  class="btnMenu btnAzurDoz" />        
         <input id="btnPrikazKor" type="button" value="Prikaz korisnika dozvole"  class="btnMenu btnPrikazKor" />
       <%--  <input id="btnStampaDoz" type="button" value="Stampa dozvole"  class="btnMenu btnStampaDoz" />--%>
         <input id="btnStampaDoz1" type="button" value="Stampa dozvole"  class="btnMenu btnStampaDoz1" />
         <input id="btnOvera" type="button" value="Overavanje dozvole"  class="btnMenu btnOvera" />


     </div>
    <div id="dMesec" class="dMesec" data-mesec="0" data-godina="0">       
        <span id="RelativeUrl" RelativeURL= ""></span> 
    </div>
   
     <div id="dSadrzaj" class="dSadrzaj">
     </div>

    </div>
    </form>
</body>
</html>
