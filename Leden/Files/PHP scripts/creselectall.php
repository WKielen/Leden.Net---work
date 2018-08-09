<?php
require("config.inc.php");
require("checkuser.php");

//initial query
$query = "Select * FROM Crediteur";

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
	
		$post["Naam"]           = $row["Naam"];
		$post["IBAN"]           = $row["IBAN"];
		$post["BIC"]            = $row["BIC"];
		$post["Omschrijving"]   = $row["Omschrijving"];
		
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
