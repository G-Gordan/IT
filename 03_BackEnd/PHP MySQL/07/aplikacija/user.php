<?php
$ACCESS_LEVEL = 0;
require_once "init.php"; 

//ovo je deo za login
if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='login' ){
	$username = $_POST['u'];
	$password = $_POST['p'];
	
	$upit = " SELECT * FROM users WHERE username='$username' AND password='$password' ";
	$rez = $db->query($upit);
	$user = $rez->fetch_object();
	if($user){
		//super, fetch-ovao je jedan red, korisnik ovakav postoji
		
		session_start();
		$_SESSION['username'] = $user->username;
		$_SESSION['access_level'] = $user->access_level;
		
		header("Location: index.php");
	}
	else{
		//ne valja, upit nije vratio nista
		//$status = 'Login nije uspeo';
		header("Location: login.php");
	}
}

//deo za logout
if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='logout' ){
	$_SESSION['username'] = '';
	$_SESSION['access_level'] = 0;
	//$status = 'Odjavljeni ste';
	header("Location: login.php");
}
	
if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='register' ){
	//uhvati iz forme
	$username = $db->real_escape_string($_REQUEST['u']);
	$password = $db->real_escape_string($_REQUEST['p']);
	$password2 = $db->real_escape_string($_REQUEST['p2']);
	$email = $db->real_escape_string($_REQUEST['email']);
	
	if($password!=$password2){
		echo 'Ne slaze se'; die();
	}
	
	//prvoeriti da li vec postoji takav username!
	$upit = " select * from users where username='$username' ";
	$rez = $db->query($upit);
	if($rez->num_rows > 0){
		echo 'Zauzet username!'; die();
	}
	
	$upit = " INSERT INTO users (username, password, email, access_level)
					VALUES ('$username','$password','$email',1)";
	$db->query($upit);
	mail($email, 'Vas nalog je napravljen', 'Dobrodosli na nas super sajt!

Mozete se prijavti na www.saj.com/login.php
sa podacima:

username: '.$username.'
password: '.$password.'


Sacuvajte ovaj mejl jer password ne cuvamo u citljivom obliku.
');
	
	
	header("Location: login.php");
}

if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='change-password' ){
	//promena passworda - update
	$username = $_SESSION['username'];
	$oldpassword = $db->real_escape_string($_REQUEST['u']);
	$password = $db->real_escape_string($_REQUEST['p']);
	$password2 = $db->real_escape_string($_REQUEST['p2']);
	
	//prvo nadjem tog usera po username, pa proverim da li je stari password kao u bazi
	//i ako je sve ok, uradi se update
	
	if( $password!=$password2 ){
		echo 'Passwordi se ne slazu'; die();
	}
	
	$upit = "select * from users where username='$username'";
	$rz = $db->query($upit);
	$user = $rz->fetch_object();
	
	if($user->password != $oldpassword){
		echo 'Stari Password nije tacan'; die();
	}
	
	//tacno? super, idemo dalje...
	$upit2 = "  UPDATE users SET password='$password' WHERE username='$username' ";
	$db->query($upit2);
	
	header("Location: login.php");
}

if( isset($_REQUEST['akcija']) and $_REQUEST['akcija']=='reset-password' ){
	$username = $_SESSION['username'];
	$email = $db->real_escape_string($_REQUEST['email']);
	
	
	$dozvoljenaslova = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_-!@#$%^&*()_-!@#$%^&*()_-"
	/*
	$novpassword = '';
	
	for($i=0;$i<8;$i++){
		$slucajnoslovo = $dozvoljenaslova[ rand(0, strlen($dozvoljenaslova)) ];
		$novpassword .= $slucajnoslovo;
	}
	*/
	
	$izmesanaslova = str_shuffle($dozvoljenaslova);
	$novpassword = substr($izmesanaslova, 0, 8);
	
	
	$upit = " UPDATE users SET password='$novpassword' WHERE username='$username' ";
	$db->query($upit);
	mail($email, 'Vas password je resetovan', 'Na vas zahtev resetovali smo password.

Mozete se prijavti na www.saj.com/login.php
sa podacima:

password: '.$novpassword.'


Ako ovo nije doslo po vasem zahtevu, promenite password i javite se administratoru.
');

}

?>