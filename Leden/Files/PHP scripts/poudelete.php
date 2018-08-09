<?php
require("config.inc.php");
require("checkuser.php");
require ("pougetfieldsfromurl.php");

$query = "DELETE FROM Poule WHERE Id = $Id";
//echo $query;
//execute query
try {
    $stmt   = $db->prepare($query);
    $result = $stmt->execute();
    $rc = $stmt->rowCount();
}
catch (PDOException $ex) {
    $response["success"] = 0;
    $response["message"] = "Database Error deleting!";
    die(json_encode($response));
}

if ($result == 1) {
    if ($rc ==1) {
          $response["success"] = 1;
          $response["message"] = "Delete succeeded";
     }
     else {
          // Hier zijn 2 mogelijkheden. Of het record bestaat niet of alle velden zijn hetzelfde
          $response["success"] = 4;
          $response["message"] = "Delete failed";
     }
}
else {
    $response["success"] = 3;
    $response["message"] = "Delete failed";
}
echo json_encode($response);

?>
