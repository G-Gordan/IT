function pridruzivanje_dogadjaja_inputima(){
	$("input.ocena").keypress(function(e){
					//da li je pritisnuta cifra ili nesto drugo
					if( e.keyCode >= 48 && e.keyCode <= 57 ){
						//cifra je ok, prihvatam je, prvoerim da li je duzina 0, ako je 0 onda moze, ako je vece ne moze
						if( $(this).val().length<1 ){
							//ako je prazan - moze, ako nije prazan ne moze
							return true;
						} else {
							return false;
						}
					} else {
						//nesto drugo
						return false;
					}
	});
	
	$("input.ocena").focus(function(){
		$(this).removeClass('greska');
	});
	
	$("input.obrisi").click(function(){
		this.parentNode.parentNode.removeChild( this.parentNode );
	});
}


$(document).ready(function(){
			
	$("#izracunaj_button").click(function(){
						var dobro = true;
						
						/*
						pr1 = $("#pr1");
						pr2 = $("#pr2");
						pr3 = $("#pr3");
						pr4 = $("#pr4");
						pr5 = $("#pr5");
						pr6 = $("#pr6");
						
						var regex = /^[0-9]$/;
						if(!pr1.val().match(regex)){
							dobro = false;
							//dodaj klasu greska
							pr1.addClass('greska');
						}
						if(!pr2.val().match(regex)){
							dobro = false;
							//dodaj klasu greska
							pr2.addClass('greska');
						}
						if(!pr3.val().match(regex)){
							dobro = false;
							//dodaj klasu greska
							pr3.addClass('greska');
						}
						if(!pr4.val().match(regex)){
							dobro = false;
							//dodaj klasu greska
							pr4.addClass('greska');
						}
						if(!pr5.val().match(regex)){
							dobro = false;
							//dodaj klasu greska
							pr5.addClass('greska');
						}
						if(!pr6.val().match(regex)){
							dobro = false;
							//dodaj klasu greska
							pr6.addClass('greska');
						}
						*/
						$(".ocena").each(function(){
							var regex = /^[0-9]$/;
							if(!$(this).val().match(regex)){
								dobro = false;
								//dodaj klasu greska
								$(this).addClass('greska');
							}
						});
						
						//ako nije dobro - prekinem funkciju
						if(dobro==false){
							return; //ako nije dobro, zavrsi funkciju ovde
						}
		
						//ako je dobro
							/*
							
							var pr1 = parseInt(document.getElementById('pr1').value);
							var pr2 = parseInt(document.getElementById('pr2').value);
							var pr3 = parseInt(document.getElementById('pr3').value);
							var pr4 = parseInt(document.getElementById('pr4').value);
							var pr5 = parseInt(document.getElementById('pr5').value);
							var pr6 = parseInt(document.getElementById('pr6').value);
							
							var prosek = (pr1 + pr2 + pr3 + pr4 + pr5 + pr6 ) / 6;
							
							var prosek = 0;
							var polja = document.querySelectorAll('.ocena');
							for(i = 0; i<polja.length; i++){
								prosek = prosek + parseInt(polja[i].value);
							}
							*/
							var zbir = 0;
							var prosek = 0;
							var brojocena = 0;
							$(".ocena").each(function(){
								zbir = zbir + parseInt($(this).val());
								brojocena++;
							});
							prosek = zbir / brojocena;
							
							$("#rezultat").html(prosek.toFixed(2));
							
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
							/*
							//proverim izuzetak, kada ima neku jedinicu a ima jak prosek
							if(pr1==1 || pr2==1 || pr3==1 || pr4==1 || pr5==1 || pr6==1){
								uspeh = "Nedovoljan";
							}
							*/
							$(".ocena").each(function(){
								if( $(this).val()=='1' ){
									uspeh = "Nedovoljan";
								}
							});
							
							$("#uspeh").html(uspeh);
		
	});
	
	pridruzivanje_dogadjaja_inputima();
	
});


function obrisi(){
	input = document.getElementById("pr1");
	
	
}

function dodaj(){
	var imepredmeta = window.prompt("Unesite ime predmeta");
	if(!imepredmeta){
		return; //ako confirm jeste vratio false, onda prekidamo izvrsenje, kliknuto je na cancel
	}
	
	var div_sveocene = document.getElementById("sveocene");
	//div.innerHTML = div.innerHTML + '<div>'+imepredmeta+' <input type="text" class="ocena" /> </div>';
	
	var novipredmet_div = document.createElement('div');
	var novipredmet_naziv = document.createTextNode(imepredmeta);
	var novipredmet_input = document.createElement("input");
	var novipredmet_button = document.createElement("input");
	
	
	//novipredmet_input.onkeypress = function(){ ... };
	novipredmet_input.type = 'text';
	novipredmet_input.className = 'ocena'; 
	
	novipredmet_button.type='button';
	novipredmet_button.className='obrisi';
	novipredmet_button.value='X';
	
	novipredmet_div.appendChild(novipredmet_naziv);
	novipredmet_div.appendChild(novipredmet_input);
	novipredmet_div.appendChild(novipredmet_button);
	
	div_sveocene.appendChild(novipredmet_div);
	
	pridruzivanje_dogadjaja_inputima();
	
}