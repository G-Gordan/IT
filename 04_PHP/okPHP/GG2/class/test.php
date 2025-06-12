
<?php

Function mesec($m){
    $prnt="";
    	If (!is_numeric($m)) { exit("Mora biti broj"); }
    	Else{ If ($m<1 && $m>12) { exit("Mora biti broj od 1 do 12"); }
            	Else{ If ($m==1) { $prnt="Januar"; }
                	Else { If ($m==2) { $prnt="Februar"; }
                    	Else{ If ($m==3) { $prnt="Mart"; }
                        	Else{ If ($m==4) { $prnt="April"; }
                            	Else{ If ($m==5) { $prnt="Maj"; }
                                	Else{ If ($m==6) { $prnt="Jun"; }
                                    	Else{ If ($m==7) { $prnt="Jul"; }
                                        	Else{ If ($m==8) { $prnt="Avgust"; }
                                            	Else{ If ($m==9) { $prnt="Septembar"; }
                                                	Else{ If ($m==10) { $prnt="Oktobar"; }
                                                    	Else{ If ($m==11) { $prnt="Novembar"; }
                                                        	Else{ If ($m==12) { $prnt="Decembar"; }
                                                           	}
                                                    	}
                                                	}
                                            	}
                                        	}
                                    	}
                                	}
                            	}
                        	}
                    	}
                	}
            	}
        }
    
return $prnt;
}
print_r(mesec(5));
       
?>

