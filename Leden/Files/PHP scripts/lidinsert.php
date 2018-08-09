<?php
require("config.inc.php");
require("checkuser.php");
require ("lidgetfieldsfromurl.php");


$query = "INSERT INTO Lid (
	LidNr,
	Voornaam,
	Achternaam,
	Tussenvoegsel,
	Adres,
	Woonplaats,
	Postcode,
	Mobiel,
	Telefoon,
	BondsNr,
	Geslacht,
	GeboorteDatum,
	Email1,
	Email2,
	IBAN,
	BIC,
	LidBond,
	CompGerechtigd,
	ToernooiSpeler,
	LidType,
	LidVanaf,
	Opgezegd,
	LidTot,
	Medisch,
	Gemerkt,
	U_PasNr,
	PakketTot,
	BetaalWijze,
	VastBedrag,
	Korting,
	Geincasseerd,
	Ouder1_Naam,
	Ouder1_Email1,
	Ouder1_Email2,
	Ouder1_Mobiel,
	Ouder1_Telefoon,
	Ouder2_Naam,
	Ouder2_Email1,
	Ouder2_Email2,
	Ouder2_Mobiel,
	Ouder2_Telefoon,
	VrijwillgersRegelingIsVanToepassing,
	VrijwillgersVasteTaak,
	VrijwillgersAfgekocht,
	VrijwillgersToelichting,
	LicentieSen,
	LicentieJun,
	Extra1,
	Extra2,
	Extra3,
	Extra4,
	Extra5,
	ExtraA,
	ExtraB,
	ExtraC,
	ExtraD,
	ExtraE,
	ToegangsCode,
	Rol

)VALUES (

$LidNr,
'$Voornaam',
'$Achternaam',
'$Tussenvoegsel',
'$Adres',
'$Woonplaats',
'$Postcode',
'$Mobiel',
'$Telefoon',
'$BondsNr',
'$Geslacht',
DATE '$GeboorteDatum',
'$Email1',
'$Email2',
'$IBAN',
'$BIC',
$LidBond,
$CompGerechtigd,
$ToernooiSpeler,
'$LidType',
DATE '$LidVanaf',
$Opgezegd,
DATE '$LidTot',
'$Medisch',
$Gemerkt,
'$U_PasNr',
DATE '$PakketTot',
'$BetaalWijze',
$VastBedrag,
$Korting,
$Geincasseerd,
'$Ouder1_Naam',
'$Ouder1_Email1',
'$Ouder1_Email2',
'$Ouder1_Mobiel',
'$Ouder1_Telefoon',
'$Ouder2_Naam',
'$Ouder2_Email1',
'$Ouder2_Email2',
'$Ouder2_Mobiel',
'$Ouder2_Telefoon',
$VrijwillgersRegelingIsVanToepassing,
$VrijwillgersVasteTaak,
$VrijwillgersAfgekocht,
'$VrijwillgersToelichting',
'$LicentieSen',
'$LicentieJun',
$Extra1,
$Extra2,
$Extra3,
$Extra4,
$Extra5,
'$ExtraA',
'$ExtraB',
'$ExtraC',
'$ExtraD',
'$ExtraE',
'$ToegangsCode',
'$Rol')";

//print ("query = $query\n");

//execute query
try {
	$stmt   = $db->prepare($query);
	$result = $stmt->execute($query_params);
}
catch (PDOException $ex) {
	if ($ex->errorInfo[1] == 1062) {
	        $response["success"] = 2;
		$response["message"] = "Duplicate Key";
	} else {
        	$response["success"] = 0;
		$response["message"] = "Database Error!";
	}
    die(json_encode($response));
}
$response["success"] = 1;
$response["message"] = "Record Inserted";
die(json_encode($response));


?>
