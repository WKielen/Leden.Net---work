<?php
require("config.inc.php");
require("checkuser.php");
require ("incgetfieldsfromurl.php");

$query = "UPDATE Incasso SET
	Omschrijving = '$Omschrijving',
	TypeRekening = '$TypeRekening',
	TotaalBedrag = '$TotaalBedrag',
	IBAN = '$IBAN',
	BIC = '$BIC',
	AanmaakDatum = '$AanmaakDatum',
	VerstuurdDatum = '$VerstuurdDatum',
	Verstuurd = '$Verstuurd',
	PeilDatum = '$PeilDatum',
	CompetitieBijdrage = '$CompetitieBijdrage',
	ContributieBedrag = '$ContributieBedrag',
	Bondsbijdrage = '$Bondsbijdrage',
	ExtraBedrag = '$ExtraBedrag',
	Korting = '$Korting',
	Gestorneerd = '$Gestorneerd',
	KostenStornering = '$KostenStornering',
	MailOnderdrukken = '$MailOnderdrukken',
	BedragKortingVrijwilliger = '$BedragKortingVrijwilliger',
	Extra1 = '$Extra1',
	Extra2 = '$Extra2',
	Extra3 = '$Extra3',
	ExtraA = '$ExtraA',
	ExtraB = '$ExtraB',
	ExtraC = '$ExtraC',
	DatumWijziging = now()
WHERE LidNr = $LidNr AND RekeningSeqNr = $RekeningSeqNr";
//print ("query = $query\n");
//execute query
try {
    $stmt   = $db->prepare($query);
    $result = $stmt->execute($query_params);
    $rc = $stmt->rowCount();
}
catch (PDOException $ex) {
    $response["success"] = 0;
    $response["message"] = "Database Error!";
    die(json_encode($response));
}

if ($result == 1) {
    if ($rc ==1) {
          $response["success"] = 1;
          $response["message"] = "Update succeeded";
     }
     else {
          // Hier zijn 2 mogelijkheden. Of het record bestaat niet of alle velden zijn hetzelfde
          $response["success"] = 4;
          $response["message"] = "Update succeeded but no changes";
     }
}
else {
    $response["success"] = 3;
    $response["message"] = "Update failed";
}
echo json_encode($response);

?>
