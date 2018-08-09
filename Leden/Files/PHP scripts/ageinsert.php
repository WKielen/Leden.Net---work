<?php
require("config.inc.php");
require("checkuser.php");
require ("agegetfieldsfromurl.php");


$query = "INSERT INTO Agenda (
	Datum                 ,
	Tijd                  ,
	EvenementNaam         ,
	Lokatie               ,
	Type                  ,
	DoelGroep             ,
	Toelichting           ,
	Inschrijven,
	Inschrijfgeld         ,
	BetaalMethode         ,
        ContactPersoon,
	Vervoer               ,
	VerzamelAfspraak      ,
	Extra1                ,
	Extra2                ,
	ExtraA                ,
	ExtraB
)VALUES (
	 DATE '$Datum'           ,
	'$Tijd'                  ,
	'$EvenementNaam'         ,
	'$Lokatie'               ,
	'$Type'                  ,
	'$DoelGroep'             ,
	'$Toelichting'           ,
        '$Inschrijven'   ,
	$Inschrijfgeld         ,
	'$BetaalMethode'         ,
        '$ContactPersoon' ,
	'$Vervoer'               ,
	'$VerzamelAfspraak'      ,
	$Extra1                ,
	$Extra2                ,
	'$ExtraA'                ,
	'$ExtraB')";

//execute query
try {
	$stmt   = $db->prepare($query);
	$result = $stmt->execute($query_params);
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
