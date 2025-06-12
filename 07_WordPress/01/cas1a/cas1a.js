
	window.onload = function() {
		console.log("radi");
		
		var dugme;
		var vrednost;
		
		dugme = document.querySelector('.racunaj');
		vrednost = document.querySelector('.vrednost');
		
		dugme.addEventListener('click', ispis);
	
		
		function racunaj(c)
		{
			var f;
			//var c;
		
			//c = vrednost.value;
		
			f = (c-32)/1.8;
			
			//console.log(f);
		
			return f;
		}
		
		function ispis ()
		{
			document.getElementById('rez').innerHTML = racunaj(vrednost.value);
		}
		
		
		
		
		var dugme;
		var vrednost;
		
		dugme1 = document.querySelector('.racunaj1');
		vrednost1 = document.querySelector('.vrednost1');
		
		dugme1.addEventListener('click', ispis1);
		
		function ispis1 ()
		{
			document.getElementById('rez1').innerHTML = racunaj(vrednost1.value);
		}
		
	
	}
	
