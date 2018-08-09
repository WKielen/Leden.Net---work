using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{

	public class OutlookAgendaRegel 
	{ 
		public OutlookAgendaRegel()
		{
			onderwerp = "Onderwerp";
			beginDatum = "Begindatum";
			beginTijd = "Begintijd";
			eindDatum = "Einddatum";
			eindTijd = "Eindtijd";
			gebeurtenisDuurtHeleDag = "Gebeurtenis, duurt hele dag";
			herinneringenAanUit = "Herinneringen aan/uit";
			herinneringsDatum = "Herinneringsdatum";
			herinneringsTijd = "Herinneringstijd";
			organisatorVanVergadering = "Organisator van vergadering";
			vereisteGenodigden = "Vereiste genodigden";
			optioneleGenodigden = "Optionele genodigden";
			vergaderVoorzieningen = "Vergadervoorzieningen";
			beschrijving = "Beschrijving";
			categorie = "Categorieen";
			factuurInformatie = "Factuurinformatie";
			gevoeligheid = "Gevoeligheid";
			locatie = "Locatie";
			prioriteit = "Prioriteit";
			prive = "Prive";
			reisAfstand = "Reisafstand";
			tijdWeergevenAls = "Tijd weergeven als";
		}


		private string onderwerp;
		public string Onderwerp
		{
			get {return onderwerp;}
			set {onderwerp = value;}
		}
		private string beginDatum;
		public string BeginDatum
		{
			get {return beginDatum;}
			set {beginDatum = value;}
		}
		private string beginTijd;
		public string BeginTijd
		{
			get {return beginTijd;}
			set {beginTijd = value;}
		}
		private string eindDatum;
		public string EindDatum
		{
			get {return eindDatum;}
			set {eindDatum = value;}
		}
		private string eindTijd;
		public string EindTijd
		{
			get {return eindTijd;}
			set {eindTijd = value;}
		}
		private string gebeurtenisDuurtHeleDag;
		public string GebeurtenisDuurtHeleDag
		{
			get {return gebeurtenisDuurtHeleDag;}
			set {gebeurtenisDuurtHeleDag = value;}
		}
		private string herinneringenAanUit;
		public string HerinneringenAanUit
		{
			get {return herinneringenAanUit;}
			set {herinneringenAanUit = value;}
		}
		private string herinneringsDatum;
		public string HerinneringsDatum
		{
			get {return herinneringsDatum;}
			set {herinneringsDatum = value;}
		}
		private string herinneringsTijd;
		public string HerinneringsTijd
		{
			get {return herinneringsTijd;}
			set {herinneringsTijd = value;}
		}
		private string organisatorVanVergadering;
		public string OrganisatorVanVergadering
		{
			get {return organisatorVanVergadering;}
			set {organisatorVanVergadering = value;}
		}
		private string vereisteGenodigden;
		public string VereisteGenodigden
		{
			get {return vereisteGenodigden;}
			set {vereisteGenodigden = value;}
		}
		private string optioneleGenodigden;
		public string OptioneleGenodigden
		{
			get {return optioneleGenodigden;}
			set {optioneleGenodigden = value;}
		}
		private string vergaderVoorzieningen;
		public string VergaderVoorzieningen
		{
			get {return vergaderVoorzieningen;}
			set {vergaderVoorzieningen = value;}
		}
		private string beschrijving;
		public string Beschrijving
		{
			get {return beschrijving;}
			set {beschrijving = value;}
		}
		private string categorie;
		public string Categorie
		{
			get {return categorie;}
			set {categorie = value;}
		}
		private string factuurInformatie;
		public string FactuurInformatie
		{
			get {return factuurInformatie;}
			set {factuurInformatie = value;}
		}
		private string gevoeligheid;
		public string Gevoeligheid
		{
			get {return gevoeligheid;}
			set {gevoeligheid = value;}
		}
		private string locatie;
		public string Locatie
		{
			get {return locatie;}
			set {locatie = value;}
		}
		private string prioriteit;
		public string Prioriteit
		{
			get {return prioriteit;}
			set {prioriteit = value;}
		}
		private string prive;
		public string Prive
		{
			get {return prive;}
			set {prive = value;}
		}
		private string reisAfstand;
		public string ReisAfstand
		{
			get {return reisAfstand;}
			set {reisAfstand = value;}
		}
		private string tijdWeergevenAls;
		public string TijdWeergevenAls
		{
			get {return tijdWeergevenAls;}
			set {tijdWeergevenAls = value;}
		}
		public override string ToString() 
		{ 
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			string sep = "\t";
			sb.Append(@"""");
			sb.Append(onderwerp);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(beginDatum);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(beginTijd);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(eindDatum);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(eindTijd);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(gebeurtenisDuurtHeleDag);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(herinneringenAanUit);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(herinneringsDatum);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(herinneringsTijd);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(organisatorVanVergadering);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(vereisteGenodigden);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(optioneleGenodigden);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(vergaderVoorzieningen);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(beschrijving);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(categorie);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(factuurInformatie);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(gevoeligheid);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(locatie);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(prioriteit);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(prive);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(reisAfstand);
			sb.Append(@"""");
			sb.Append(sep);
			sb.Append(@"""");
			sb.Append(tijdWeergevenAls);
			sb.Append(@"""");

			return sb.ToString();			
		}
	}
}
