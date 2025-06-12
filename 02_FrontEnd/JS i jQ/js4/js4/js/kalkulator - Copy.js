/* ostavljam radi beleske...
						function saberi(){
							//dohvati value od input-a a
							//dohvati value od input-a b
							//sabere ta dva
							//zbir ubaci u value od input-a zbir
							var a = parseInt(document.getElementById('a').value);
							var b = parseInt(document.getElementById('b').value);
							var zbir = a+b;
							//document.getElementById('zbir').value = zbir;
							document.getElementById('zbir').innerHTML
									= 'Zbir = <b class="crveno">' + zbir + '</b>';
							if( uslov ){
								neki.kod;
							}
							else if( drugi uslov ){
								neki.drugi.kod;
							}
							else{
								ako nista onda ovo
							}
						}
						*/
						function saberi(){
							var pr1 = parseInt(document.getElementById('pr1').value);
							var pr2 = parseInt(document.getElementById('pr2').value);
							var pr3 = parseInt(document.getElementById('pr3').value);
							var pr4 = parseInt(document.getElementById('pr4').value);
							var pr5 = parseInt(document.getElementById('pr5').value);
							var pr6 = parseInt(document.getElementById('pr6').value);
							
							var prosek = (pr1 + pr2 + pr3 + pr4 + pr5 + pr6 ) / 6;
							
							document.getElementById("rezultat").innerHTML = prosek.toFixed(2);
							
							/*prvi nacin za uspeh*/
							//odredim na osnovu proseka koji je uspeh
							var uspeh = "Odlican";
							
							if(prosek < 4.5){
								uspeh = "Vrlo dobar";
							}
							
							if(prosek < 3.5){
								uspeh = "Dobar";
							}
							
							if(prosek < 2.5){
								uspeh = "Dovoljan";
							}
							
							if(prosek < 2){
								uspeh = "Nedovoljan";
							}
							//proverim izuzetak, kada ima neku jedinicu a ima jak prosek
							if(pr1==1 || pr2==1 || pr3==1 || pr4==1 || pr5==1 || pr6==1){
								uspeh = "Nedovoljan";
							}
							
							/*drugi nacin za uspeh... */
							/*
							if(prosek > 4.5 && prosek <=5){
								uspeh = "Odlican";
							}
							
							if(prosek > 3.5 && prosek <=4.5){
								uspeh = "Vrlo dobar";
							}
							
							if(prosek > 2.5 && prosek <=3.5){
								uspeh = "Dobar";
							}
							
							if(prosek > 2 && prosek <=2.5){
								uspeh = "Dovoljan";
							}
							
							if(prosek > 0 && prosek <=2){
								uspeh = "Nedovoljan";
							}
							*/
							/*treci nacin za uspeh?   */
							/*
							if(prosek > 4.5 && prosek <=5){
								uspeh = "Odlican";
							}
							else if(prosek > 3.5 && prosek <=4.5){
								uspeh = "Vrlo dobar";
							}
							else if(prosek > 2.5 && prosek <=3.5){
								uspeh = "Dobar";
							}
							else if(prosek > 2 && prosek <=2.5){
								uspeh = "Dovoljan";
							}
							else{
								uspeh = "Nedovoljan";
							}
							*/
							/* cetvrti nacin... treci+prvi*/
							/*
							uspeh="Odlican";
							if(prosek > 3.5 && prosek <=4.5){
								uspeh = "Vrlo dobar";
							}
							else if(prosek > 2.5 && prosek <=3.5){
								uspeh = "Dobar";
							}
							else if(prosek > 2 && prosek <=2.5){
								uspeh = "Dovoljan";
							}
							else{
								uspeh = "Nedovoljan";
							}
							*/
							/* druga struktura, ako imate konkretne vrednosti (ne vazi za uspeh, jer uspeh ima opseg, nema jednu vrednost)
							switch(ocena){
								case 1: 
										console.log("Nedovoljan");
									break;
								case 2: 
										console.log("Dovoljan");
									break;
								default:
									console.log("Nesto trece...");
							}
							
							if(ocena==1){
								console.log("Nedovoljan");
							}
							else if(ocena==2){
								console.log("Dovoljan");
							}
							else{
								console.log("Nesto trece...");
							}
							*/
							document.getElementById("uspeh").innerHTML = uspeh;
						}