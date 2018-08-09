<?php
require("config.inc.php");
require("checkuser.php");
require ("agegetfieldsfromurl.php");

$query = "UPDATE Agenda SET
		Datum                        = DATE '$Datum',
		Tijd                         = '$Tijd',
		EvenementNaam                = '$EvenementNaam',
		Lokatie                      = '$Lokatie',
		Type                         = '$Type',
		DoelGroep                    = '$DoelGroep',
		Toelichting                  = '$Toelichting',
		Inschrijven                  = '$Inschrijven',
		Inschrijfgeld                = $Inschrijfgeld,
		BetaalMethode                = '$BetaalMethode',
                ContactPersoon         = '$ContactPersoon',
		Vervoer                      = '$Vervoer',
		VerzamelAfspraak             = '$VerzamelAfspraak',
		Extra1                       = $Extra1,
		Extra2                       = $Extra2,
		ExtraA                       = '$ExtraA',
		ExtraB                       = '$ExtraB',
        DatumWijziging = now()
WHERE Id = $Id";

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
