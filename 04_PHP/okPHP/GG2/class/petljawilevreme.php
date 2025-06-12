
<?php  

$vreme = date("Y-m-d H:i:s");
$period = date('Y-m-d H:i:s',strtotime('+5 seconds',strtotime($vreme)));
//print($vreme);
//echo "<br>";
//print($period);
//echo "<br>";
//$perraz = strtotime($period)-strtotime($vreme);
//print($perraz);
//echo "<br>";
$perraz3=date('Y-m-d H:i:s',strtotime('+1 seconds',strtotime($vreme)));
//print($perraz3);

while($vreme <= $period) {

 if($vreme==$perraz3){
 	echo "<br>";
 	print(strtotime($period)-strtotime($vreme));
 	$perraz3=date('Y-m-d H:i:s',strtotime('+1 seconds',strtotime($perraz3)));
 }
 $vreme = date("Y-m-d H:i:s");
 } 
 //die();

 ?>  