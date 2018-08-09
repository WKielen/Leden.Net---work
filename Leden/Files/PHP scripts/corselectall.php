<?php
require("config.inc.php");
require("checkuser.php");

//initial query
$query = "Select * FROM CompResult";

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
		$post["LidNr"] = $row["LidNr"];
		$post["Jaar"] = $row["Jaar"];
		$post["Seizoen"] = $row["Seizoen"];
		$post["CompetitieType"] = $row["CompetitieType"];
		$post["Klasse"] = $row["Klasse"];
		$post["Percentage"] = $row["Percentage"];


		$post["RekeningSeqNr"] = $row["RekeningSeqNr"];
		$post["Omschrijving"] = $row["Omschrijving"];
		$post["TypeRekening"] = $row["TypeRekening"];
		$post["TotaalBedrag"] = $row["TotaalBedrag"];
		$post["IBAN"] = $row["IBAN"];
		$post["BIC"] = $row["BIC"];
		$post["AanmaakDatum"] = $row["AanmaakDatum"];
		$post["VerstuurdDatum"] = $row["VerstuurdDatum"];
		$post["Verstuurd"] = $row["Verstuurd"];
		$post["PeilDatum"] = $row["PeilDatum"];
		$post["CompetitieBijdrage"] = $row["CompetitieBijdrage"];
		$post["ContributieBedrag"] = $row["ContributieBedrag"];
		$post["Bondsbijdrage"] = $row["Bondsbijdrage"];
		$post["ExtraBedrag"] = $row["ExtraBedrag"];
		$post["Korting"] = $row["Korting"];
		$post["Gestorneerd"] = $row["Gestorneerd"];
		$post["KostenStornering"] = $row["KostenStornering"];
		$post["MailOnderdrukken"] = $row["MailOnderdrukken"];
		$post["BedragKortingVrijwilliger"] = $row["BedragKortingVrijwilliger"];
		$post["Extra1"] = $row["Extra1"];
		$post["Extra2"] = $row["Extra2"];
		$post["Extra3"] = $row["Extra3"];
		$post["ExtraA"] = $row["ExtraA"];
		$post["ExtraB"] = $row["ExtraB"];
		$post["ExtraC"] = $row["ExtraC"];
		$post["DatumWijziging"] = $row["DatumWijziging"];

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
