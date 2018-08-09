<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<meta http-equiv="Content-Language" content="nl">
<title>Agenda TTVN</title><base target="_self">
<style type="text/css">
    body {scrollbar-face-color: #FFCC99;
    scrollbar-shadow-color:;
    scrollbar-base-color: #FFCC66;
    scrollbar-highlight-color:;
    scrollbar-3dlight-color: #FFFFFF;
    scrollbar-darkshadow-color:;
    scrollbar-track-color: FFFFCC;
    scrollbar-arrow-color:;}
</style>
<script type="text/javascript" src="../javascript/frames.js"></script>
<script type="text/javascript" src="agenda_tooltip.js"></script>
<script type="text/javascript" src="../javascript/highslide/highslide-with-html.js"></script>
<link rel="stylesheet" type="text/css" href="../javascript/highslide/highslide.css">
<script type="text/javascript">
    hs.graphicsDir = '../javascript/highslide/graphics/';
	hs.outlineType = 'rounded-white';	
	hs.wrapperClassName = 'draggable-header';
</script><!--mstheme--><link rel="stylesheet" type="text/css" href="../_themes/ttvn-2005/ttvn1011.css"><meta name="Microsoft Theme" content="ttvn-2005 1011, default">
</head>

<body scroll="auto" topmargin="0" bottommargin="0">

<div align="left">
<table cellpadding="0" cellspacing="0" width="770">
<!-- MSTableType="layout" -->
<tbody><tr>
<td width="770">
<h2 style="text-align: center;">Agenda</h2>
<div align="center">
<table style="border-color:#CC5200; border-collapse: collapse" id="table4" border="1" cellpadding="4">
<tbody><tr>
<td style="border-top: 1px solid rgb(204, 82, 0); border-left: 1px solid rgb(204, 82, 0); border-bottom: 1px solid rgb(204, 82, 0); text-align: center;" bgcolor="#ffb062" width="80px">
<p style="margin-left: 5px; margin-right: 5px;"><b>
<font color="#800000" size="3">Datum</font></b></p></td>
<td style="border-top: 1px solid rgb(204, 82, 0); border-bottom: 1px solid rgb(204, 82, 0);" bgcolor="#ffb062">
<p style="margin-left: 5px; margin-right: 5px;"><b>
<font color="#800000" size="3">Evenement</font></b></p></td>
<td style="border-top: 1px solid rgb(204, 82, 0); border-right: 1px solid rgb(204, 82, 0); border-bottom: 1px solid rgb(204, 82, 0); text-align:center" bgcolor="#ffb062">
<p style="margin-left: 5px; margin-right: 5px;"><b>
<font color="#800000" size="3">Plaats</font></b></p></td>
<td style="border-top: 1px solid rgb(204, 82, 0); border-bottom: 1px solid rgb(204, 82, 0);" bgcolor="#ffb062">
<p style="margin-left: 5px; margin-right: 5px;"><b>
<font color="#800000" size="3">Informatie</font></b></p></td>
</tr>


<?php
session_start();
$dbname = "ttvn";
require("../../subdomains/android/httpdocs/webservice/config.inc.php");

//execute query
try {
	$query = "Select * FROM Agenda WHERE Datum >= CURDATE() ORDER BY Datum";
    $stmt   = $db->prepare($query);
    $result = $stmt->execute($query_params);
}
catch (PDOException $ex) {
    $response["success"] = 0;
    $response["message"] = "Database Error!";
}
$rows = $stmt->fetchAll();

	$geleregeloneven = "<td style='border-left:1px solid #CC5200; text-align: left;' bgcolor='#FFFFCC'>";
	$geleregeleven = "<td style='border-left:1px solid #CC5200; text-align: left;'>";
	$geleregel = "";
	$regelnummer = 0;
	
    foreach ($rows as $row) {
		
		if ($regelnummer == 0){
			$geleregel = $geleregeleven."<p style='margin:0 5px; text-align: left; '>";
			$regelnummer = 1;
		} else {
			$geleregel = $geleregeloneven."<p style='margin:0 5px; text-align: left; '>";
			$regelnummer = 0;
		}
				
		echo "<tr>".$geleregel;
		$date = $row["Datum"];
		$dag = "";
		switch (date('w', strtotime($date))) {
			case 0: $dag = "Zondag"; break;
			case 1: $dag = "Maandag"; break;
			case 2: $dag = "Dinsdag"; break;
			case 3: $dag = "Woensdag"; break;
			case 4: $dag = "Donderdag"; break;
			case 5: $dag = "Vrijdag"; break;
			case 6: $dag = "Zaterdag"; break;
		}
		//echo $weekday = date('l', strtotime($date)); 
		echo $dag;
		echo "<br>";

		//echo date("d-m-Y", strtotime($date));
		echo "<b>".date("d-m-y", strtotime($date))."</b>";
		echo "</p></td>".$geleregel;
		echo $row["EvenementNaam"];
		echo "</p></td>".$geleregel;
		echo $row["Lokatie"];
		echo "</p></td>".$geleregel;
        
		$informatie = "";
		$var = trim($row["DoelGroep"]);
		if ($var != ''){
			if ($var == "S") {
				$informatie .= "Senioren ";
			} else{
				$informatie .= "Jeugd ";
			}
		}	
		
		$var = trim($row["Type"]);
		if ($var != ''){
			if ($var == "T") {
				$informatie .= "Toernooi ";
			} else{
				$informatie .= "Competitie ";
			}
		}
		
		$var = trim($row["Tijd"]);
		if ($var != ''){
			$informatie .= "<br>"."Tijd: ".$var;
		}
		
		$var = trim($row["Inschrijven"]);
		if ($var != ''){
			$informatie .= "<br>"."Inschrijven: ".$var;
		}

		$var = trim($row["Vervoer"]);
		if ($var != ''){
			$informatie .= "<br>"."Vervoer: ".$var;
		}

		$var = trim($row["ContactPersoon"]);
		if ($var != ''){
			$informatie .= "<br>"."ContactPersoon: ".$var;
		}

		$var = trim($row["Inschrijfgeld"]);
		if ($var != '' && $var != 0){
			$informatie .= "<br>"."Inschrijfgeld: ".$var." euro";
		}

		$var = trim($row["BetaalMethode"]);
		if ($var != ''){
			$informatie .= "<br>"."Betalen: ".$var;
		}

		$var = trim($row["VerzamelAfspraak"]);
		if ($var != ''){
			$informatie .= "<br>"."Verzamelen: ".$var;
		}

		$var = trim($row["Toelichting"]);
		if ($var != ''){
			$informatie .= "<br>"."Toelichting: ".$var;
		}

		echo $informatie;
		echo "</p></td></tr>";
		}
?>


</tbody>
</table>
<p style="text-align: left; margin: 0 5px">&nbsp;</div>
<!--CheckStat Free 4.2 Begin-->
<!--LET OP: De teller zal worden verwijderd indien-->
<!--aanpassingen zijn gemaakt aan deze code of-->
<!--wanneer het icoon niet zichtbaar is op de site.-->
<script type="text/javascript" language="javascript">
function checkstat(a,v){var set=new Array();if(typeof v=="string")
{set[0]=parseInt(v.substring(0,1))}else{set[0]=(v==3||v==4)?0:1}
var jv,sz,sc,i;js="";var td=new Date();var tm=td.getTime();
var s=screen;var d=document;var l="http://checkstat.nl/cgi-bin/";
var lo=d.URL;var n=navigator;var re=typeof(top.document)=="object"?
top.document.referrer:d.referrer;for(i=0;i<=5;i++)
{d.write('<script language="javascript1.'+i+'">js="'+i+'"<\/script>')}
if(js>=1){jv=n.javaEnabled()?"y":"n"}if(js>=2){sz=s.width+"*"+s.height;
sc=n.appName.substring(0,9)=="Microsoft"?s.colorDepth:s.pixelDepth;}
var ar="&location="+escape(lo)+"&screensize="+sz+"&screencolors="+sc+
"&javascript=1."+js+"&java="+jv+"&referrer="+escape(re)+"&time="+tm;
if(set[0]){d.write('<a target=_blank href="'+l+'show.cgi?'+a+
'"><img nosave name=icon width=19 height=19 border=0 alt="CheckStat" '+
'src="'+l+'count.cgi?'+a+ar+'"><\/a>')}else{d.write('<img width=1 '+
'height=1 src="'+l+'count.cgi?'+a+ar+'">')}}checkstat('ttvnagenda','110')
</script><noscript>
<a href="http://checkstat.nl/cgi-bin/show.cgi?ttvnagenda"
target=_blank><img name=icon width=19 height=19
src="http://checkstat.nl/cgi-bin/count.cgi?ttvnagenda"
border=0 alt=CheckStat></a></noscript>

<p>

<!--CheckStat Free 4.2 End-->
<script type="text/javascript">
var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
</script>
<script type="text/javascript">
try {
var pageTracker = _gat._getTracker("UA-6840617-1");
pageTracker._trackPageview();
} catch(err) {}</script>
</p>
</td>
</tr>
</tbody></table>
</div>
</body></html>