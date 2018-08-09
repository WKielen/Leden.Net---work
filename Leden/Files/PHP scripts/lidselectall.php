<?php
require("config.inc.php");
require("checkuser.php");

//initial query
$query = "Select * FROM Lid ORDER BY Achternaam, Voornaam";

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
        $post["Voornaam"]    = $row["Voornaam"];
		$post["LidNr"] = $row["LidNr"];
		$post["Achternaam"] = $row["Achternaam"];
		$post["Tussenvoegsel"] = $row["Tussenvoegsel"];
		$post["Adres"] = $row["Adres"];
		$post["Woonplaats"] = $row["Woonplaats"];
		$post["Postcode"] = $row["Postcode"];
		$post["Mobiel"] = $row["Mobiel"];
		$post["Telefoon"] = $row["Telefoon"];
		$post["BondsNr"] = $row["BondsNr"];
		$post["Geslacht"] = $row["Geslacht"];
		$post["GeboorteDatum"] = $row["GeboorteDatum"];
		$post["Email1"] = $row["Email1"];
		$post["Email2"] = $row["Email2"];
		$post["IBAN"] = $row["IBAN"];
		$post["BIC"] = $row["BIC"];
		$post["LidBond"] = $row["LidBond"];
		$post["CompGerechtigd"] = $row["CompGerechtigd"];
		$post["ToernooiSpeler"] = $row["ToernooiSpeler"];
		$post["LidType"] = $row["LidType"];
		$post["LidVanaf"] = $row["LidVanaf"];
		$post["Opgezegd"] = $row["Opgezegd"];
		$post["LidTot"] = $row["LidTot"];
		$post["Medisch"] = $row["Medisch"];
		$post["Gemerkt"] = $row["Gemerkt"];
		$post["U_PasNr"] = $row["U_PasNr"];
		$post["PakketTot"] = $row["PakketTot"];
		$post["BetaalWijze"] = $row["BetaalWijze"];
		$post["VastBedrag"] = $row["VastBedrag"];
		$post["Korting"] = $row["Korting"];
		$post["Geincasseerd"] = $row["Geincasseerd"];
		$post["Ouder1_Naam"] = $row["Ouder1_Naam"];
		$post["Ouder1_Email1"] = $row["Ouder1_Email1"];
		$post["Ouder1_Email2"] = $row["Ouder1_Email2"];
		$post["Ouder1_Mobiel"] = $row["Ouder1_Mobiel"];
		$post["Ouder1_Telefoon"] = $row["Ouder1_Telefoon"];
		$post["Ouder2_Naam"] = $row["Ouder2_Naam"];
		$post["Ouder2_Email1"] = $row["Ouder2_Email1"];
		$post["Ouder2_Email2"] = $row["Ouder2_Email2"];
		$post["Ouder2_Mobiel"] = $row["Ouder2_Mobiel"];
		$post["Ouder2_Telefoon"] = $row["Ouder2_Telefoon"];
		$post["VrijwillgersRegelingIsVanToepassing"] = $row["VrijwillgersRegelingIsVanToepassing"];
		$post["VrijwillgersVasteTaak"] = $row["VrijwillgersVasteTaak"];
		$post["VrijwillgersAfgekocht"] = $row["VrijwillgersAfgekocht"];
		$post["VrijwillgersToelichting"] = $row["VrijwillgersToelichting"];
		$post["LicentieSen"] = $row["LicentieSen"];
		$post["LicentieJun"] = $row["LicentieJun"];
		$post["Extra1"] = $row["Extra1"];
		$post["Extra2"] = $row["Extra2"];
		$post["Extra3"] = $row["Extra3"];
		$post["Extra4"] = $row["Extra4"];
		$post["Extra5"] = $row["Extra5"];
		$post["ExtraA"] = $row["ExtraA"];
		$post["ExtraB"] = $row["ExtraB"];
		$post["ExtraC"] = $row["ExtraC"];
		$post["ExtraD"] = $row["ExtraD"];
		$post["ExtraE"] = $row["ExtraE"];
		$post["ToegangsCode"] = $row["ToegangsCode"];
		$post["Rol"] = $row["Rol"];

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
