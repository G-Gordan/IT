 window.onload = function () {
	 
	var dugme;
	
	dugme = 1, 2, 3;
	
	dugme = get.ElementById('random_brojevi');
	dugme.addEventListener('click', random_brojevi) 
	
 }
 	
	function random_brojevi() 
		{
		var x = document.getElementById("1")
		x.innerHTML = Math.floor((Math.random() * 48) + 1);
		}
	