<?php
require("config.inc.php");
require("checkuser.php");
require ("progetfieldsfromurl.php");

$query = "INSERT INTO Programma (Offset, Datum, Results) VALUES ($Offset, DATE '$Datum', '$Results');";
//echo $query;
//execute query
try {
	$stmt   = $db->prepare($query);
	$result = $stmt->execute();
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
die(json_encode($response));
?>
