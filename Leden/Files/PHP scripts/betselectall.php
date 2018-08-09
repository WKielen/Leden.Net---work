<?php
require("config.inc.php");
require("checkuser.php");

//initial query
$query = "Select * FROM Betaling";

//execute query
try {
    $stmt   = $db->prepare($query);
    $result = $stmt->execute($query_params);
}
catch (PDOException $ex) {
    $response["success"] = 0;
    $response["message"] = "Database Error!";
    die(json_encode($response));
}

// Finally, we can retrieve all of the found rows into an array using fetchAll
$rows = $stmt->fetchAll();


if ($rows) {
    $response["success"] = 1;
    $response["message"] = "Records Available";
    $response["posts"]   = array();

    foreach ($rows as $row) {
        $post             = array();
		$post["BetalingsSeqNr"]           = $row["BetalingsSeqNr"];
		$post["IBAN_Creditor"]            = $row["IBAN_Creditor"];
		$post["BIC_Creditor"]             = $row["BIC_Creditor"];
		$post["Omschrijving"]             = $row["Omschrijving"];
		$post["EndToEndId"]               = $row["EndToEndId"];
		$post["TotaalBedrag"]             = $row["TotaalBedrag"];
		$post["TypeBetaling"]             = $row["TypeBetaling"];
		$post["AanmaakDatum"]             = $row["AanmaakDatum"];
		$post["Verstuurd"]                = $row["Verstuurd"];
		$post["VerstuurdDatum"]           = $row["VerstuurdDatum"];
		$post["GewensteVerwerkingsDatum"] = $row["GewensteVerwerkingsDatum"];
		$post["Crediteur"]                = $row["Crediteur"];
		$post["Extra1"]                   = $row["Extra1"];
		$post["Extra2"]                   = $row["Extra2"];
		$post["Extra3"]                   = $row["Extra3"];
		$post["ExtraA"]                   = $row["ExtraA"];
		$post["ExtraB"]                   = $row["ExtraB"];
		$post["ExtraC"]                   = $row["ExtraC"];

        //update our repsonse JSON data
        array_push($response["posts"], $post);
    }

    // echoing JSON response
    echo json_encode($response);


} else {
    $response["success"] = 2;
    $response["message"] = "No Records Available";
    die(json_encode($response));
}

?>
