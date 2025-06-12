			/* dva nacina pisanja funkcija
		function init(){
			//document.getElementById("telefon").onkeypress = telefon2;
			document.getElementById("telefon").onkeypress = function(){
				//ovde ide kod funkcije...
				return telefon2();
			};
			
			function a(){ alert(1); }
			a = function(){ alert(1); }
		}
			*/
		
		
		$(document).ready(function(){
			
			window.alert(1);
			
		});
			
			/*
			var linkovi = document.querySelectAll('nav > ul > li > a ');
			for(...){
				linkovi[i].style.color='blue';
			}
			
			$('nav > ul > li > a').css('color', 'blue');
			$('nav > ul > li > a').addClass('istaknuto');
			$('nav > ul > li > a').removeClass('istaknuto');
			$('nav > ul > li > a').toggleClass('istaknuto');
			*/
			//za telefon keypress da spreci unos svega osim cifara
			$("input.ocena").keypress(function(){
				if(event.keyCode >= 48 && event.keyCode <= 57) {
					return true;
				}
				return false;
			});
			
			//za formu submit da pozove validaciju
			$('#kontaktforma').submit(function(){
				//return validacija(); suvisno! stavicu celu validacija() ovde...
							var rezultat = true;
						
							var status = $("#status");
						
							// 3 ili vise slova, razmak, tri ili vise slova
							var imeprez = $("#imeprezime");
							var imeprez_re = /^\w{3,} \w{3,}$/i
							if(!imeprez.val().match(imeprez_re)){
								//greska!
								status.html( "Popunite ime i prezime" );
								//$("#imeprezime").css('border-color', 'red'); //necemo da mesamo css i js
								$("#imeprezime").addClass('validacija_greska');
								//imeprez.style.borderColor='red';
								rezultat = false;
							}
							
							//proveri da li telefon ima format 000/000-0000  sa opcionim znakom -
							var telefon = $("#telefon");
							var telefon_re = /^\d{3}\/\d{3}\-?\d{3,4}$/;
							if( !telefon.val().match(telefon_re) ){ //ako match varti false, negacija od false je true, i onda if prolazi dalje
								//greska!
								status.html( status.html() + "Popunite telefon" );
								//telefon.css('border-color', 'red');
								telefon.addClass('validacija_greska');
								rezultat = false;
							}
							
							//proveri da li mail ima format nesto@nesto.com
							var mail = $("#email");
							
							var mail_re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
							
							if( !mail_re.test(mail.val()) ){ //ako match varti false, negacija od false je true, i onda if prolazi dalje
								//greska!
								status.html(status.html()+ "Popunite mail");
								
								//mail.css('border-color','red');
								mail.addClass('validacija_greska');
								rezultat = false;
							}
							
							if(status.html().length > 0){
								status.show();
								//status.style.display = 'block';
							}
							
							return rezultat;
			}); //end-submit
		
			$("#kontaktforma input[type='text']").focus(function(){
				
				//za taj kome se desio onfocus, skloni crveni border, ako ga ima...
				//this.style.borderColor = 'silver'; cist js, necemo...
				//$(this).css('border-color','silver'); //jquery - malo bolje...
				$(this).removeClass('validacija_greska');
				
			});
			
			$("saberi").click(function(){
				//sta se desava kad se klikne na dugme...
				
			});
		
		}); //end-ready
		
		/*
		$(function(){
			//isto onload...
		});
		*/
		