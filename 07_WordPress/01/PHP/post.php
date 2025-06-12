



<form method="POST" action="obrada.php">
	<div>
		<label for="naziv">Naziv</label>
		<input type="text"name=naziv" id="naziv" />
	</div>
	<div>
		<label for="autor">Autor Knjige</label>
		<select name="autor" id="autor">
			<option value="1"Ivo Andric</option>
			<option value="2" Mesa Selimovic</option>
			<option value="3" Dobrica Cosic</option>
		</select>
	</div>
	<div>
		<label for="godine">Godine<label/>
		<input type="number" name="godine"/>
	</div>
	
	<input type="submit" name="posalji" value="posalji" />

</form>