<?php
require("config.inc.php");
require("checkuser.php");
require ("corgetfieldsfromurl.php");

$query = "INSERT INTO CompResult (
LidNr,
Jaar,
Seizoen,
CompetitieType,
Klasse,
Percentage
)VALUES (
$LidNr,
$Jaar,
'$Seizoen',
'$CompetitieType',
'$Klasse',
$Percentage
)";

//print ("query = $query\n");

//execute query
try {
	$stmt   = $db->prepare($query);
	$result = $stmt->execute($query_params);
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
