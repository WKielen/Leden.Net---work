<?php
require("config.inc.php");
require("checkuser.php");
require ("betgetfieldsfromurl.php");

$query = "INSERT INTO Betaling (
	BetalingsSeqNr          ,
	IBAN_Creditor           ,
	BIC_Creditor            ,
	Omschrijving            ,
	EndToEndId              ,
	TotaalBedrag            ,
	TypeBetaling            ,
	AanmaakDatum            ,
	Verstuurd               ,
	VerstuurdDatum          ,
	GewensteVerwerkingsDatum,
	Crediteur               ,
	Extra1 			    ,
	Extra2                 ,
	Extra3                 ,
	ExtraA                 ,
	ExtraB                 ,
	ExtraC
)VALUES (
	$BetalingsSeqNr          ,
	'$IBAN_Creditor'           ,
	'$BIC_Creditor'            ,
	'$Omschrijving'            ,
	'$EndToEndId'              ,
	$TotaalBedrag            ,
	$TypeBetaling            ,
	DATE '$AanmaakDatum'            ,
	$Verstuurd               ,
	DATE '$VerstuurdDatum'          ,
	DATE '$GewensteVerwerkingsDatum',
	'$Crediteur'               ,
	$Extra1 			    ,
	$Extra2                 ,
	$Extra3                 ,
	'$ExtraA'                 ,
	'$ExtraB'                 ,
	'$ExtraC'
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
