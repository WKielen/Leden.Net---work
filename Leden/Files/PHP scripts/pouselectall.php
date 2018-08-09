<?php
require("config.inc.php");

//initial query
$query = "Select * FROM Poule ORDER BY SeqNr";

//execute query
try {
    $stmt   = $db->prepare($query);
    $result = $stmt->execute();
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
		$post["PouleId"] = $row["PouleId"];
		$post["SeqNr"] = $row["SeqNr"];
		$post["Omschrijving"] = $row["Omschrijving"];
		$post["DoelGroep"] = $row["DoelGroep"];
		$post["DoelTeam"] = $row["DoelTeam"];
		$post["Results"] = $row["Results"];

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
