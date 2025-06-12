<?php
use App\Http\Requests;

namespace App\Http\Controllers;
use Validator;
use DB;

use Illuminate\Http\Request;

class StudentController extends Controller
{
    //
public function inputStudent(Request $request){

$messages=[
'required'=>'Morate popuniti polje :attribute',
'numeric'=>'Polje :attribute mora biti broj',
'smer.required'=>'Morate odabrati smer'
];


$validator=Validator::make(
$request->all(),

[
'ime'=>'required',
'prezime'=>'required',
'bri'=>'required|numeric',
'godu'=>'required|numeric',
'gods'=>'required|numeric',
'smer'=>'required'
], $messages);

if($validator->fails()){

	return redirect('/showInsert')->withErrors($validator)
	                              ->withInput();

}

$ime=$request->input('ime');
$prezime=$request->input('prezime');
$bri=$request->input('bri');
$godu=$request->input('godu');
$gods=$request->input('gods');
$smer=$request->input('smer');


DB::table('students')->insert(['ime'=>$ime, 'prezime'=>$prezime,'broj_indeksa'=>$bri, 'godina_upisa'=>$godu,'godina_studija'=>$gods,'smer_id'=>$smer]);

return redirect('/showInsert')->with(['message'=>['type'=>'success', 'text'=>'Uspesan unos']]);





}






}
