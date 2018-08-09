<?php
require("config.inc.php");
require("checkuser.php");
require ("pougetfieldsfromurl.php");

$query = "INSERT INTO Poule (PouleId, SeqNr, Omschrijving, DoelGroep, DoelTeam, Results) VALUES ('$PouleId', '$SeqNr', '$Omschrijving', '$DoelGroep', '$DoelTeam', '$Results');";
//echo $query;
//execute query
try {
	$stmt   = $db->prepare($query);
	$result = $stmt->execute();
        $insertkey = $db->lastInsertId();
}
catch (PDOException $ex) {
	if ($ex->errorInfo[1] == 1062) {
	        $response["success"] = 2;
		$response["message"] = "Duplicate Key";
	} else {
        	$response["success"] = 0;
		$response["message"] = "Database Error!";
	}
    die(json_encode($response));
}
$response["success"] = 1;
$response["message"] = "Record Inserted";
$response["insertkey"] = $insertkey;
die(json_encode($response));
?>
