<?php
//print('RADI2');
function novniz(){
	print('RADI3');
	exit('1234');
}

//novniz();

//If -> $i == i integer i string, a Case - striktno razlikuje integer i string
//ULEPSAVANJE KODA: Slack 
//ULEPSAVANJE KODA ONLINE: Google-> indent php code online
//http://www.phpformatter.com/
//http://phpbeautifier.com/
//https://www.tutorialspoint.com/online_php_formatter.htm
//http://beautifytools.com/php-beautifier.php - URL: NOT SECURE!

function slucaj($cpar1, $cpar2){
	Switch($cpar){
		Case 1 :
			print("Parametar 1 je broj 1");
			If($cpar2=1){
				print("Parametar 2 je broj 1");
			}Elseif($cpar2=2){
				print("Parametar 2 je broj 2");
			}Elseif($cpar2=3){
				print("Parametar 2 je broj 3");
			}Else{
				print("Parametar 2 je brojveci od 3");
			}
			
			break;
		Case 2 :
			print("Broj 2");
			break;	
		Case 3 :
			print("Broj 3");
			break;
		Default :
			print("Greska");		

	}

} 

function slucaj2($cpar){
		If($cpar=1){
			print("Broj 1");
		}	
		Elseif($cpar=2){
			print("Broj 2");
		}
		Elseif($cpar=3){
			print("Broj 3");
		}
		Else{
			print("Greska");
		}

}

function slucaj3($par1, $par2){
	Switch($par1){
		case 0 :
		print("Parametar 1 je broj 0");
		print("<br>");
			If($par1<$par2){
				print('RADI IF');
				for($i=$par1; $i > $par2; $i++){
					print('RADI LOOP');
					print($i);
					print("<br>");
				}
			}
		break;
		case 1 :
		print("Parametar 1 je broj 1");
		print("<br>");
			If($par1<$par2){
				For($i=$par1; $i>$par2; $i++){
					print($i);
					print("<br>");
				}
			}
		break;
		case 2 :
		print("Parametar 1 je broj 2");
		print("<br>");
			If($par1<$par2){
				For($i=$par1; $i>$par2; $i++){
					print($i);
					print("<br>");
				}
			}	
		break;
	}
		
}

?>