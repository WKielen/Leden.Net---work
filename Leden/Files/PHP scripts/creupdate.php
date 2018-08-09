<?php
require("config.inc.php");
require("checkuser.php");
require ("cregetfieldsfromurl.php");

$query = "UPDATE Crediteur SET
	Naam           = '$Naam',
	IBAN           = '$IBAN',
	BIC            = '$BIC',
	Omschrijving   = '$Omschrijving',
	DatumWijziging = now()
WHERE Crediteur = '$Crediteur'";
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
