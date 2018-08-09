<?php
require("config.inc.php");
require("checkuser.php");
require ("incgetfieldsfromurl.php");

$query = "INSERT INTO Incasso (
LidNr,
RekeningSeqNr,
Omschrijving,
TypeRekening,
TotaalBedrag,
IBAN,
BIC,
AanmaakDatum,
VerstuurdDatum,
Verstuurd,
PeilDatum,
CompetitieBijdrage,
ContributieBedrag,
Bondsbijdrage,
ExtraBedrag,
Korting,
Gestorneerd,
KostenStornering,
MailOnderdrukken,
BedragKortingVrijwilliger,
Extra1,
Extra2,
Extra3,
ExtraA,
ExtraB,
ExtraC
)VALUES (
$LidNr,
$RekeningSeqNr,
'$Omschrijving',
$TypeRekening,
$TotaalBedrag,
'$IBAN',
'$BIC',
DATE '$AanmaakDatum',
DATE '$VerstuurdDatum',
$Verstuurd,
DATE '$PeilDatum',
$CompetitieBijdrage,
$ContributieBedrag,
$Bondsbijdrage,
$ExtraBedrag,
$Korting,
$Gestorneerd,
$KostenStornering,
$MailOnderdrukken ,
$BedragKortingVrijwilliger,
$Extra1,
$Extra2,
$Extra3,
'$ExtraA',
'$ExtraB',
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
