<?php
require("config.inc.php");
require("checkuser.php");
require ("progetfieldsfromurl.php");

$query = "UPDATE Programma SET  Datum = DATE '$Datum', Results =  '$Results', DatumWijziging = now()  WHERE Offset = $Offset";
//echo ($query);
//execute query
try {
    $stmt   = $db->prepare($query);
    $result = $stmt->execute();
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
