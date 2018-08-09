using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Util.Forms;
using Util.Text;
using Util.Extensions;

namespace Leden.Net
{
    public static class MailRoutines
    {
        /// <summary>
        /// This routine replaces keywords with values from the Lid object 
        /// 
        /// Replace ***voornaam***            --> lid.Voornaam
        /// Replace ***tussen***              --> lid.Tussenvoegsel
        /// Replace ***achternaam***          --> lid.Achternaam
        /// Replace ***adres***               --> lid.Adres
        /// Replace ***postcode***            --> lid.Postcode
        /// Replace ***woonplaats***          --> lid.Woonplaats
        /// Replace ***telefoon***            --> lid.Telefoon
        /// Replace ***mobiel***              --> lid.Mobiel
        /// Replace ***email1***              --> lid.Email1
        /// Replace ***email2***              --> lid.Email2
        /// Replace ***geboortedatum***       --> lid.GeboorteDatum
        /// Replace ***geslacht***            --> lid.Geslacht
        /// Replace ***rekeningnummer***      --> lid.IBAN
        /// Replace ***lidnr***               --> lid.LidNr
        /// Replace ***bijzonderheden***      --> lid.Medisch
        /// Replace ***voornaam***            --> lid.Voornaam
        /// Replace ***uitschrijfdatum****    --> lid.LidTot
        /// </summary>
        /// <param name="mailString">template</param>
        /// <param name="Object">tblLid or tblRekening</param>
        /// <returns>
        /// </returns>
        public static string ReplaceKeyWords(string mailString, object Object, tblParameters param)
        {
            if (Object is tblLid)
            {
                tblLid lid = (tblLid)Object;
                return ReplaceLid(mailString, lid, param);
            }
            if (Object is tblRekening)
            {
                tblRekening rekening = (tblRekening)Object;
                return ReplaceRekening(mailString, rekening, param);
            }
            throw new NotImplementedException();
        }

        private static string ReplaceRekening(string mailString, tblRekening rekening, tblParameters param)
        {
            mailString = ReplaceLid(mailString, rekening.Lid, param);
            mailString = mailString.Replace("***bedrag***", rekening.TotaalBedrag.ToEuroString());
            mailString = mailString.Replace("***totaalbedrag***", rekening.TotaalBedrag.ToEuroString());
            mailString = mailString.Replace("***omschrijving***", rekening.Omschrijving);
            mailString = mailString.Replace("***aanmaakdatum***", rekening.AanmaakDatum.ToShortDateString());
            mailString = mailString.Replace("***verstuurddatum***", rekening.VerstuurdDatum.ToShortDateString());
            mailString = mailString.Replace("***competitiebijdrage***", rekening.CompetitieBijdrage.ToEuroString());
            mailString = mailString.Replace("***contributiebedrag***", rekening.ContributieBedrag.ToEuroString());
            mailString = mailString.Replace("***bondsbijdrage***", rekening.Bondsbijdrage.ToEuroString());
            mailString = mailString.Replace("***extrabedrag***", rekening.ExtraBedrag.ToEuroString());
            mailString = mailString.Replace("***korting***", rekening.Korting.ToEuroString());
            mailString = mailString.Replace("***kostenstornering***", rekening.KostenStornering.ToEuroString());
            
            return mailString;
        }
        private static string ReplaceLid(string input, tblLid lid, tblParameters param)
        {
            input = input.Replace("***voornaam***", lid.Voornaam);
            input = input.Replace("***tussen***", lid.Tussenvoegsel);
            input = input.Replace("***achternaam***", lid.Achternaam);
            input = input.Replace("***adres***", lid.Adres);
            input = input.Replace("***postcode***", lid.Postcode);
            input = input.Replace("***woonplaats***", lid.Woonplaats);
            input = input.Replace("***telefoon***", lid.Telefoon);
            input = input.Replace("***mobiel***", lid.Mobiel);
            input = input.Replace("***email1***", lid.Email1);
            input = input.Replace("***email2***", lid.Email2);
            input = input.Replace("***geboortedatum***", lid.GeboorteDatum.ToShortDateString());
            input = input.Replace("***geslacht***", lid.Geslacht);
            input = input.Replace("***rekeningnummer***", lid.IBAN);
            input = input.Replace("***lidnr***", lid.LidNr.ToString());
            input = input.Replace("***bijzonderheden***", lid.Medisch);
            input = input.Replace("***voornaam***", lid.Voornaam);
            input = input.Replace("***uitschrijfdatum****", lid.LidTot.ToShortDateString());
            input = input.Replace("***volledigenaam***", lid.VolledigeNaam);
            input = input.Replace("***nettenaam***", lid.NetteNaam);
            input = input.Replace("***vrijwregeling***", lid.VrijwillgersRegelingIsVanToepassing ? "Ja" : "Nee");
            input = input.Replace("***rating***", lid.Rating.ToString());
            input = input.Replace("***vastetaak***", lid.VrijwillgersVasteTaak ? "Ja" : "Nee");
            input = input.Replace("***leeftijdscategorie***", lid.LeeftijdCategorieLong);
            input = input.Replace("***leeftijd ***", lid.Leeftijd.ToString());
            input = input.Replace("***iban***", lid.IBAN);
            input = input.Replace("***ibanvereniging***", param.IBAN);
            input = input.Replace("***naamverenigingkort***", param.ClubNameShort);
            input = input.Replace("***naamvereniginglang***", param.ClubNameLong);

            return input;
        }
    }


    public class ReportRoutines
    {    
        #region CreateIncassoReport
        /// <summary>
        /// Schrijft aangemaakte rekeningen aan het einde van een file.
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="rekeningen"></param>
        /// <param name="outputfile"></param>
        /// <param name="append">Append or new file</param>
        public static void CreateRekeningingenReport(string titel, RekeningenLijst rekeningen, string outputfile, bool append)
        {
            StreamWriter sw = new StreamWriter(outputfile, append);
            sw.WriteLine(titel + "    *** " + DateTime.Today.ToShortDateString() + " ***");
            decimal amtTotal = 0;
            decimal amtKorting = 0;
            decimal amtCompetitieBijdrage = 0;
            decimal amtContributieBedrag = 0;
            decimal amtBondsbijdrage = 0;
            decimal amtExtraBedrag = 0;
            decimal amtAfkoopTaak = 0;
            List<string> columns = new List<string>();

            columns.Add("Lidnr");
            columns.Add("Naam");
            columns.Add("LB");
            columns.Add("CG");
            columns.Add("Leeftijd");
            columns.Add("LidType");
            columns.Add("BetaalWijze");
            columns.Add("RekType");
            columns.Add("TotBedrag");
            columns.Add("ContBedrag");
            columns.Add("Korting");
            columns.Add("CompBijdr");
            columns.Add("Bondsbijdr");
            columns.Add("ExtraBedr");
            columns.Add("Taakafkoop");
            columns.Add("Omschrijving");
            columns.Add("Verstuurd");
            columns.Add("IBAN");
            columns.Add("BIC");
            columns.Add("U-Pas");


            sw.WriteLine(String.Join(";", columns.ToArray()));
            
            foreach (tblRekening rekening in rekeningen)
            {
                columns.Clear();
 
                columns.Add(rekening.Lid.LidNr.ToString());
                columns.Add(rekening.Lid.VolledigeNaam);
                columns.Add(rekening.Lid.LidBond ? "J" : "N");
                columns.Add(rekening.Lid.CompGerechtigd ? "J" : "N");
                columns.Add(DateRoutines.LeeftijdCategorieContributie(rekening.Lid.GeboorteDatum, rekening.PeilDatum));
                columns.Add(rekening.Lid.LidType);
                columns.Add(rekening.Lid.BetaalWijze);

                columns.Add(rekening.TypeRekening.ToString());
                columns.Add(rekening.TotaalBedrag.ToCSVString());
                if (rekening.IsContributie)
                {
                    columns.Add(rekening.ContributieBedrag.ToCSVString());
                    columns.Add(rekening.Korting.ToCSVString());
                    columns.Add(rekening.CompetitieBijdrage.ToCSVString());
                    columns.Add(rekening.Bondsbijdrage.ToCSVString());
                    columns.Add(rekening.ExtraBedrag.ToCSVString());
                    columns.Add(rekening.BedragKortingVrijwilliger.ToCSVString());
                }
                else
                {
                    columns.Add(string.Empty);
                    columns.Add(string.Empty);
                    columns.Add(string.Empty);
                    columns.Add(string.Empty);
                    columns.Add(string.Empty);
                    columns.Add(string.Empty);
                }
                columns.Add(rekening.Omschrijving);
                columns.Add(rekening.Verstuurd ?  "J" : "N");
                columns.Add(rekening.IBAN);
                columns.Add(rekening.BIC);
                columns.Add(rekening.Lid.U_PasNr);

                amtTotal += rekening.TotaalBedrag;
                amtKorting += rekening.Korting;
                amtCompetitieBijdrage += rekening.CompetitieBijdrage;
                amtContributieBedrag += rekening.ContributieBedrag;
                amtBondsbijdrage += rekening.Bondsbijdrage;
                amtExtraBedrag += rekening.ExtraBedrag;
                amtAfkoopTaak += rekening.BedragKortingVrijwilliger;
                sw.WriteLine(String.Join(";", columns.ToArray()));
            }

            columns.Clear();
            columns.Add("Totaal bestand");
            columns.Add(string.Empty);
            columns.Add(string.Empty);
            columns.Add(string.Empty);
            columns.Add(string.Empty);
            columns.Add(string.Empty);
            columns.Add(string.Empty);
            columns.Add(amtTotal.ToCSVString());
            columns.Add(amtContributieBedrag.ToCSVString());
            columns.Add(amtKorting.ToCSVString());
            columns.Add(amtCompetitieBijdrage.ToCSVString());
            columns.Add(amtBondsbijdrage.ToCSVString());
            columns.Add(amtExtraBedrag.ToCSVString());
            columns.Add(amtAfkoopTaak.ToCSVString());

            sw.WriteLine(String.Join(";", columns.ToArray()));

            sw.Close();

        }
        #endregion
    }


	public class DateRoutines
	{
        /// <summary>
        /// Calculates the age 
        /// </summary>
        /// <param name="birthdate">The birthdate</param>
        /// <returns>Age</returns>
        public static int Age (DateTime birthdate)
        {
            return Age(birthdate, DateTime.Now);
        }

        /// <summary>
        /// Calculates the age on a specifc referencedate
        /// </summary>
        /// <param name="birthdate">The birthdate</param>
        /// <param name="referenceDate">The date on which the age must be calculated</param>
        /// <returns>Age</returns>
        public static int Age(DateTime birthdate, DateTime referenceDate)
        {
            int yearsOld = referenceDate.Year - birthdate.Year;
            if (referenceDate < birthdate.AddYears(yearsOld)) yearsOld--;
            return yearsOld;
        }
        /// <summary>
        /// Berekend leeftijdcategory voor contributie 
        /// </summary>
        /// <param name="birthdate"></param>
        /// <param name="referenceDate"></param>
        /// <returns>"PUP", "JUN", "SEN", "65+"</returns>
        public static string LeeftijdCategorieContributie(DateTime birthdate, DateTime referenceDate)
        {
            int yearsOld = Age(birthdate, referenceDate);
            if (yearsOld <= 12)                   return tblLid.constPupil;
            if (yearsOld >= 13 && yearsOld <= 17) return tblLid.constJunior;
            if (yearsOld >= 18 && yearsOld <= 65) return tblLid.constSenior;
            return tblLid.const65Plus;
        }
        /// <summary>
        /// Berekend de lange of korte leefdtijdscategory
        /// </summary>
        /// <param name="birthdate"></param>
        /// <param name="longversion"></param>
        /// <returns>WLP, PUP, CAD, JUN, SEN of WLP1, ... , SEN1, SEN</returns>
        public static string LeeftijdCategorieBond(DateTime birthdate, bool longversion)
        {
            int yearsOld = BondsLeeftijd(birthdate);

            if (longversion)
            {
                if (yearsOld <= 06) return tblLid.constWelpMin2;
                if (yearsOld == 07) return tblLid.constWelpMin1;
                if (yearsOld == 08) return tblLid.constWelp0;
                if (yearsOld == 09) return tblLid.constWelp1;
                if (yearsOld == 10) return tblLid.constWelp2;
                                           
                if (yearsOld == 11) return tblLid.constPupil1;
                if (yearsOld == 12) return tblLid.constPupil2;
                                          
                if (yearsOld == 13) return tblLid.constCadet1;
                if (yearsOld == 14) return tblLid.constCadet2;
                                         
                if (yearsOld == 15) return tblLid.constJunior1;
                if (yearsOld == 16) return tblLid.constJunior2;
                if (yearsOld == 17) return tblLid.constJunior3;

                if (yearsOld == 18) return tblLid.constSenior1;
                return tblLid.constSenior;
            }
            else
            {
                if (yearsOld <= 10) return tblLid.constWelp;
                if (yearsOld == 11 || yearsOld == 12) return tblLid.constPupil;
                if (yearsOld == 13 || yearsOld == 14) return tblLid.constCadet;
                if (yearsOld == 15 || yearsOld == 16 || yearsOld == 17) return tblLid.constJunior;
                return tblLid.constSenior;
            }
        }

        /// <summary>
        /// Berekend de leeftijd om de leefdtijdscategory van de bond te bereken of korte leefdtijdscategory
        /// </summary>
        /// <param name="birthdate"></param>
        /// <returns>Age</returns>
        private static int BondsLeeftijd(DateTime birthdate)
        {
            int yearsOld = 0;
            DateTime now_date = DateTime.Now;
            DateTime july_1_thisYear = new DateTime(DateTime.Now.Year, 7, 1, 0, 0, 0);
            yearsOld 
                = now_date.Year - birthdate.Year;
            if (now_date < july_1_thisYear)                    // We zitten voor 1 juli van dit jaar dus geldt de geboortejaar van vorig jaar
                yearsOld--;
            return yearsOld;
        }
	}

    


     public class BodyString
     {
         private string _a;
         public BodyString ( string a )
         {
            _a = a;
         }
         public string Value
         {
            get { return _a; }
         }
 
         public static implicit operator BodyString ( string a )
         {
            return new BodyString( a );
         }
 
         public static implicit operator string ( BodyString a )
         {
            return a._a;
         }
     }
}
