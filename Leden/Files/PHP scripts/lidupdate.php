<?php
require("config.inc.php");
require("checkuser.php");
require ("lidgetfieldsfromurl.php");

$query = "UPDATE Lid SET
	Voornaam = '$Voornaam',
	Achternaam = '$Achternaam',
	Tussenvoegsel = '$Tussenvoegsel',
	Adres = '$Adres',
	Woonplaats = '$Woonplaats',
	Postcode = '$Postcode',
	Mobiel = '$Mobiel',
	Telefoon = '$Telefoon',
	BondsNr = '$BondsNr',
	Geslacht = '$Geslacht',
	GeboorteDatum = DATE '$GeboorteDatum',
	Email1 = '$Email1',
	Email2 = '$Email2',
	IBAN = '$IBAN',
	BIC = '$BIC',
	LidBond = $LidBond,
	CompGerechtigd = $CompGerechtigd,
	ToernooiSpeler = $ToernooiSpeler,
	LidType = '$LidType',
	LidVanaf = DATE '$LidVanaf',
	Opgezegd = $Opgezegd,
	LidTot = DATE '$LidTot',
	Medisch = '$Medisch',
	Gemerkt = $Gemerkt,
	U_PasNr = '$U_PasNr',
	PakketTot = DATE '$PakketTot',
	BetaalWijze = '$BetaalWijze',
	VastBedrag = $VastBedrag,
	Korting = $Korting,
	Geincasseerd = $Geincasseerd,
	Ouder1_Naam = '$Ouder1_Naam',
	Ouder1_Email1 = '$Ouder1_Email1',
	Ouder1_Email2 = '$Ouder1_Email2',
	Ouder1_Mobiel = '$Ouder1_Mobiel',
	Ouder1_Telefoon = '$Ouder1_Telefoon',
	Ouder2_Naam = '$Ouder2_Naam',
	Ouder2_Email1 = '$Ouder2_Email1',
	Ouder2_Email2 = '$Ouder2_Email2',
	Ouder2_Mobiel = '$Ouder2_Mobiel',
	Ouder2_Telefoon = '$Ouder2_Telefoon',
	VrijwillgersRegelingIsVanToepassing = $VrijwillgersRegelingIsVanToepassing,
	VrijwillgersVasteTaak = $VrijwillgersVasteTaak,
	VrijwillgersAfgekocht = $VrijwillgersAfgekocht,
	VrijwillgersToelichting = '$VrijwillgersToelichting',
	LicentieSen = '$LicentieSen',
	LicentieJun = '$LicentieJun',
	Extra1 = $Extra1,
	Extra2 = $Extra2,
	Extra3 = $Extra3,
	Extra4 = $Extra4,
	Extra5 = $Extra5,
	ExtraA = '$ExtraA',
	ExtraB = '$ExtraB',
	ExtraC = '$ExtraC',
	ExtraD = '$ExtraD',
	ExtraE = '$ExtraE',
	ToegangsCode = '$ToegangsCode',
	Rol = '$Rol',
        DatumWijziging = now()
WHERE LidNr = $LidNr";

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
