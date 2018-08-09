<?php
       function CheckUser ($db, $user, $pw) {

	$query = "Select ToegangsCode FROM Lid WHERE BondsNr= $user";

	//execute query
	try {
		$stmt   = $db->prepare($query);
		$result = $stmt->execute();
	}
	catch (PDOException $ex) {
		$response["success"] = 0;
		$response["message"] = "Database Error!";
		die(json_encode($response));
	}
	$tg = $stmt->fetchColumn(0);

	if ($tg != $pw) {
	   $response["success"] = 0;
		$response["message"] = "Login error";
		die(json_encode($response));
	}
}
$user= $_POST['user'];
$pw= $_POST['pw'];
CheckUser($db, $user, $pw);
