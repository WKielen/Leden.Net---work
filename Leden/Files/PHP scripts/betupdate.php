<?php
require("config.inc.php");
require("checkuser.php");
require ("betgetfieldsfromurl.php");

$query = "UPDATE Betaling SET
	BetalingsSeqNr           = '$BetalingsSeqNr',
	IBAN_Creditor            = '$IBAN_Creditor',
	BIC_Creditor             = '$BIC_Creditor',
	Omschrijving             = '$Omschrijving',
	EndToEndId               = '$EndToEndId',
	TotaalBedrag             = '$TotaalBedrag',
	TypeBetaling             = '$TypeBetaling',
	AanmaakDatum             = '$AanmaakDatum',
	Verstuurd                = '$Verstuurd',
	VerstuurdDatum           = '$VerstuurdDatum',
	GewensteVerwerkingsDatum = '$GewensteVerwerkingsDatum',
	Crediteur                = '$Crediteur',
	Extra1                    = '$Extra1',
	Extra2                   = '$Extra2',
	Extra3                   = '$Extra3',
	ExtraA                   = '$ExtraA',
	ExtraB                   = '$ExtraB',
	ExtraC                   = '$ExtraC',
	DatumWijziging = now()
WHERE BetalingsSeqNr = $BetalingsSeqNr";

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
