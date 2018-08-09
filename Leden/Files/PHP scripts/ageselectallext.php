<?php
require("config.inc.php");

//initial query
$query = "Select * FROM Agenda  ORDER BY Datum";

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

		$post["Id"] = $row["Id"];
		$post["Datum"] = $row["Datum"];
		$post["Tijd"] = $row["Tijd"];
		$post["EvenementNaam"] = $row["EvenementNaam"];
		$post["Lokatie"] = $row["Lokatie"];
		$post["Type"] = $row["Type"];
		$post["DoelGroep"] = $row["DoelGroep"];
		$post["Toelichting"] = $row["Toelichting"];
		$post["DatumEindeInschrijving"] = $row["DatumEindeInschrijving"];
		$post["Inschrijfgeld"] = $row["Inschrijfgeld"];
		$post["BetaalMethode"] = $row["BetaalMethode"];
		$post["ContactPersoon"] = $row["ContactPersoon"];
		$post["Vervoer"] = $row["Vervoer"];
		$post["VerzamelAfspraak"] = $row["VerzamelAfspraak"];
		$post["Extra1"] = $row["Extra1"];
		$post["Extra2"] = $row["Extra2"];
		$post["ExtraA"] = $row["ExtraA"];
		$post["ExtraB"] = $row["ExtraB"];
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
