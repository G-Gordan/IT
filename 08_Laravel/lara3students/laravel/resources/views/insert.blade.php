<?php

use Illuminate\Support\Facades\Input;

use App\Http\Requests;

?>
<!DOCTYPE html>
<html>
<head>
	<title></title>
</head>
<body>


<form action="/insert/doInsert" method="post">
	
<input type="hidden" name="_token" value="{{csrf_token()}}">
<input type="text" name="ime" value="" placeholder="Ime"><br><br>
<input type="text" name="prezime" placeholder="Prezime"><br><br>
<input type="text" name="bri" placeholder="Br indeksa"><br><br>
<input type="text" name="godu" placeholder="Godina upisa"><br><br>
<input type="text" name="gods" placeholder="Godina studija"><br>
<h4>Izaberite smer:</h4>
<select name="smer">
	  <option value="1">Elektrotehnicko i racunarsko inzenjerstvo</option>
	  <option value="2">Tehnika i informatika</option>
	  <option value="3">Informacione tehnologije</option>
	  <option value="4">Saobracajno inzenjerstvo</option>
	  <option value="5">Inzenjerski menadzment</option>
</select>
<br><br>
<input type="submit" name="submit" value="Unesi">

</form>

</body>
</html>




@if($errors->any())
	@foreach ($errors->all() as $error) 
	{{$error}}<br><br>
	
	@endforeach
	

@endif

@if(session('message'))

{{session('message.text')}}
@endif



