	function telefon2(event){
						
							if(event.keyCode >= 48 && event.keyCode <= 57) {
								return true;
							}
							return false;
						}
					
						function validacija(){
							var rezultat = true;
						
							var status = document.getElementById("status");
						
							/*
							//proveri da li imeprezime ima bar 3 slova unutra
							var imeprez = document.getElementById("imeprezime");
							if(imeprez.value.length < 3){
								//greska!
								status.innerHTML = "Popunite ime i prezime";
								status.style.backgroundColor = 'silver';
								imeprez.style.borderColor='red';
								rezultat = false;
							}
							//proveri da li telefon ima tacno 10 brojeva unutra
							var telefon = document.getElementById("telefon");
							if(telefon.value.length != 10){
								//greska!
								status.innerHTML = status.innerHTML+ "Popunite telefon";
								status.style.backgroundColor = 'silver';
								telefon.style.borderColor='red';
								rezultat = false;
							}
							*/
							
							// 3 ili vise slova, razmak, tri ili vise slova
							var imeprez = document.getElementById("imeprezime");
							var imeprez_re = /^\w{3,} \w{3,}$/i
							if(!imeprez.value.match(imeprez_re)){
								//greska!
								status.innerHTML = "Popunite ime i prezime";
								
								imeprez.style.borderColor='red';
								rezultat = false;
							}
							
							//proveri da li telefon ima format 000/000-0000  sa opcionim znakom -
							var telefon = document.getElementById("telefon");
							var telefon_re = /^\d{3}\/\d{3}\-?\d{3,4}$/;
							if( !telefon.value.match(telefon_re) ){ //ako match varti false, negacija od false je true, i onda if prolazi dalje
								//greska!
								status.innerHTML = status.innerHTML+ "Popunite telefon";
								
								telefon.style.borderColor='red';
								rezultat = false;
							}
							
							//proveri da li mail ima format nesto@nesto.com
							var mail = document.getElementById("email");
							
							var mail_re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
							
							if( !mail_re.test(mail.value) ){ //ako match varti false, negacija od false je true, i onda if prolazi dalje
								//greska!
								status.innerHTML = status.innerHTML+ "Popunite mail";
								
								mail.style.borderColor='red';
								rezultat = false;
							}
							
							if(status.innerHTML.length > 0){
								status.style.display = 'block';
							}
							
							return rezultat;
							
						}
		//definisane funkcije lepim za elemente html-a				
		document.getElementById("telefon").onkeypress = function(){
			//ovde ide kod funkcije...
			return telefon2();
		};