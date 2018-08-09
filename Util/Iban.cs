using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace Util
{


    public class IbanData
    {
        public string CountryCode;
        public int Lenght;
        public string RegexStructure;
        public bool IsEU924;
        public string Sample;
         
        public IbanData()
        {
        }
        public IbanData(string countryCode, int lenght, string regexStructure, bool isEU924, string sample)
            : this()
        {
            CountryCode = countryCode;
            Lenght = lenght;
            RegexStructure = regexStructure;
            IsEU924 = isEU924;
            Sample = sample;
        }

    }

    /// <summary>
    /// CheckIban return value data structure
    /// </summary>
    public class StatusData
    {
        public bool IsValid;
        public string Message;

        public StatusData(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }

    public static class Iban
    {
        // error messages
        // you can translate this to your language
        static string[] errorMessages =
        {
            "The IBAN contains illegal characters.",
			"The structure of IBAN is wrong.",
			"The check digits of IBAN are wrong.",
			"IBAN for country {0} currently is not avaliable.",
			"The IBAN of {0} needs to be {1} characters long.",
			"The country specific structure of IBAN is wrong.",
			"The IBAN is incorrect.",
			"The IBAN seems to be correct.",
        };

        /// <summary>
        /// Main method that checks if the supplied IBAN code is valid
        /// </summary>
        /// If true it will clear and capitalize the supplied IBAN number
        public static StatusData CheckIban(string iban, bool cleanText)
        {
            try
            {
                if (cleanText)
                    iban = Regex.Replace(iban, @"\s", "").ToUpper(); // remove empty space & convert all uppercase

                if (Regex.IsMatch(iban, @"\W")) // contains chars other than (a-zA-Z0-9)
                    return new StatusData(false, errorMessages[0]);

                if (!Regex.IsMatch(iban, @"^\D\D\d\d.+")) // first chars are letter letter digit digit
                    return new StatusData(false, errorMessages[1]);

                if (Regex.IsMatch(iban, @"^\D\D00.+|^\D\D01.+|^\D\D99.+")) // check digit are 00 or 01 or 99
                    return new StatusData(false, errorMessages[2]);

                string countryCode = iban.Substring(0, 2);

                IbanData currentIbanData = (from id in IBANList()
                                            where id.CountryCode == countryCode
                                            select id).FirstOrDefault();

                if (currentIbanData == null) // test if country respected
                    return new StatusData(false, string.Format(errorMessages[3], countryCode));

                if (iban.Length != currentIbanData.Lenght) // fits length to country
                    return new StatusData(false, string.Format(errorMessages[4], countryCode, currentIbanData.Lenght));

                if (!Regex.IsMatch(iban.Remove(0, 4), currentIbanData.RegexStructure)) // check country specific structure
                    return new StatusData(false, errorMessages[5]);

                // ******* from wikipedia.org
                //The checksum is a basic ISO 7064 mod 97-10 calculation where the remainder must equal 1.
                //To validate the checksum:
                //1- Check that the total IBAN length is correct as per the country. If not, the IBAN is invalid. 
                //2- Move the four initial characters to the end of the string. 
                //3- Replace each letter in the string with two digits, thereby expanding the string, where A=10, B=11, ..., Z=35. 
                //4- Interpret the string as a decimal integer and compute the remainder of that number on division by 97. 
                //The IBAN number can only be valid if the remainder is 1.
                string modifiedIban = iban.ToUpper().Substring(4) + iban.Substring(0, 4);
                modifiedIban = Regex.Replace(modifiedIban, @"\D", m => ((int)m.Value[0] - 55).ToString());

                int remainer = 0;
                while (modifiedIban.Length >= 7)
                {
                    remainer = int.Parse(remainer + modifiedIban.Substring(0, 7)) % 97;
                    modifiedIban = modifiedIban.Substring(7);
                }
                remainer = int.Parse(remainer + modifiedIban) % 97;

                if (remainer != 1)
                    return new StatusData(false, errorMessages[6]);


                return new StatusData(true, errorMessages[7]);
            }
            catch (Exception)
            {
                return new StatusData(false, "(exception) " + errorMessages[6]);
            }
        }

        /// <summary>
        /// If you develop another code/algorithm you can use this list
        /// check updates @ http://www.tbg5-finance.org/checkiban.js
        /// </summary>
        public static List<IbanData> IBANList()
        {
            List<IbanData> newList = new List<IbanData>();
            newList.Add(new IbanData("AD", 24, @"\d{8}[a-zA-Z0-9]{12}", false, "AD1200012030200359100100"));
            newList.Add(new IbanData("AL", 28, @"\d{8}[a-zA-Z0-9]{16}", false, "AL47212110090000000235698741"));
            newList.Add(new IbanData("AT", 20, @"\d{16}", true, "AT611904300234573201"));
            newList.Add(new IbanData("BA", 20, @"\d{16}", false, "BA391290079401028494"));
            newList.Add(new IbanData("BE", 16, @"\d{12}", true, "BE68539007547034"));
            newList.Add(new IbanData("BG", 22, @"[A-Z]{4}\d{6}[a-zA-Z0-9]{8}", true, "BG80BNBG96611020345678"));
            newList.Add(new IbanData("CH", 21, @"\d{5}[a-zA-Z0-9]{12}", false, "CH9300762011623852957"));
            newList.Add(new IbanData("CY", 28, @"\d{8}[a-zA-Z0-9]{16}", true, "CY17002001280000001200527600"));
            newList.Add(new IbanData("CZ", 24, @"\d{20}", true, "CZ6508000000192000145399"));
            newList.Add(new IbanData("DE", 22, @"\d{18}", true, "DE89370400440532013000"));
            newList.Add(new IbanData("DK", 18, @"\d{14}", true, "DK5000400440116243"));
            newList.Add(new IbanData("EE", 20, @"\d{16}", true, "EE382200221020145685"));
            newList.Add(new IbanData("ES", 24, @"\d{20}", true, "ES9121000418450200051332"));
            newList.Add(new IbanData("FI", 18, @"\d{14}", true, "FI2112345600000785"));
            newList.Add(new IbanData("FO", 18, @"\d{14}", false, "FO6264600001631634"));
            newList.Add(new IbanData("FR", 27, @"\d{10}[a-zA-Z0-9]{11}\d\d", true, "FR1420041010050500013M02606"));
            newList.Add(new IbanData("GB", 22, @"[A-Z]{4}\d{14}", true, "GB29NWBK60161331926819"));
            newList.Add(new IbanData("GI", 23, @"[A-Z]{4}[a-zA-Z0-9]{15}", true, "GI75NWBK000000007099453"));
            newList.Add(new IbanData("GL", 18, @"\d{14}", false, "GL8964710001000206"));
            newList.Add(new IbanData("GR", 27, @"\d{7}[a-zA-Z0-9]{16}", true, "GR1601101250000000012300695"));
            newList.Add(new IbanData("HR", 21, @"\d{17}", false, "HR1210010051863000160"));
            newList.Add(new IbanData("HU", 28, @"\d{24}", true, "HU42117730161111101800000000"));
            newList.Add(new IbanData("IE", 22, @"[A-Z]{4}\d{14}", true, "IE29AIBK93115212345678"));
            newList.Add(new IbanData("IL", 23, @"\d{19}", false, "IL620108000000099999999"));
            newList.Add(new IbanData("IS", 26, @"\d{22}", true, "IS140159260076545510730339"));
            newList.Add(new IbanData("IT", 27, @"[A-Z]\d{10}[a-zA-Z0-9]{12}", true, "IT60X0542811101000000123456"));
            newList.Add(new IbanData("LB", 28, @"\d{4}[a-zA-Z0-9]{20}", false, "LB62099900000001001901229114"));
            newList.Add(new IbanData("LI", 21, @"\d{5}[a-zA-Z0-9]{12}", true, "LI21088100002324013AA"));
            newList.Add(new IbanData("LT", 20, @"\d{16}", true, "LT121000011101001000"));
            newList.Add(new IbanData("LU", 20, @"\d{3}[a-zA-Z0-9]{13}", true, "LU280019400644750000"));
            newList.Add(new IbanData("LV", 21, @"[A-Z]{4}[a-zA-Z0-9]{13}", true, "LV80BANK0000435195001"));
            newList.Add(new IbanData("MC", 27, @"\d{10}[a-zA-Z0-9]{11}\d\d", true, "MC1112739000700011111000h79"));
            newList.Add(new IbanData("ME", 22, @"\d{18}", false, "ME25505000012345678951"));
            newList.Add(new IbanData("MK", 19, @"\d{3}[a-zA-Z0-9]{10}\d\d", false, "MK07300000000042425"));
            newList.Add(new IbanData("MT", 31, @"[A-Z]{4}\d{5}[a-zA-Z0-9]{18}", true, "MT84MALT011000012345MTLCAST001S"));
            newList.Add(new IbanData("MU", 30, @"[A-Z]{4}\d{19}[A-Z]{3}", false, "MU17BOMM0101101030300200000MUR"));
            newList.Add(new IbanData("NL", 18, @"[A-Z]{4}\d{10}", true, "NL91ABNA0417164300"));
            newList.Add(new IbanData("NO", 15, @"\d{11}", true, "NO9386011117947"));
            newList.Add(new IbanData("PL", 28, @"\d{8}[a-zA-Z0-9]{16}", true, "PL27114020040000300201355387"));
            newList.Add(new IbanData("PT", 25, @"\d{21}", true, "PT50000201231234567890154"));
            newList.Add(new IbanData("RO", 24, @"[A-Z]{4}[a-zA-Z0-9]{16}", true, "RO49AAAA1B31007593840000"));
            newList.Add(new IbanData("RS", 22, @"\d{18}", false, "RS35260005601001611379"));
            newList.Add(new IbanData("SA", 24, @"\d{2}[a-zA-Z0-9]{18}", false, "SA0380000000608010167519"));
            newList.Add(new IbanData("SE", 24, @"\d{20}", true, "SE4550000000058398257466"));
            newList.Add(new IbanData("SI", 19, @"\d{15}", true, "SI56191000000123438"));
            newList.Add(new IbanData("SK", 24, @"\d{20}", true, "SK3112000000198742637541"));
            newList.Add(new IbanData("SM", 27, @"[A-Z]\d{10}[a-zA-Z0-9]{12}", false, "SM86U0322509800000000270100"));
            newList.Add(new IbanData("TN", 24, @"\d{20}", false, "TN5914207207100707129648"));
            newList.Add(new IbanData("TR", 26, @"\d{5}[a-zA-Z0-9]{17}", false, "TR330006100519786457841326"));

            return newList;
        }

        public static string KvKIban(string kvk)
        {
            kvk += "0000";
            Int64 kvknr = Convert.ToInt64(kvk + "232100");
            kvknr = 98 - (kvknr % 97);
            return "NL" + kvknr.ToString("0#") + "ZZZ" + kvk;
        }
    }


    public class BicData
    {
        public string Bank;
        public string Bic;
        public BicData()
        {
        }
        public BicData(string bank, string bic)
            : this()
        {
            Bank = bank;
            Bic = bic;
        }
    }

    public static class Bic
    {
        public static string GetBicFromIban(string IBAN)
        {
            try
            {
                BicData currentBicData = (from id in BicList()
                                          where id.Bank == IBAN.Substring(4, 4)
                                          select id).FirstOrDefault();
                return currentBicData.Bic;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static List<BicData> BicList()
        {
            List<BicData> newList = new List<BicData>();
            newList.Add(new BicData("ABNA", "ABNANL2A"));
            newList.Add(new BicData("AEGO", "AEGONL2U"));
            newList.Add(new BicData("ANDL", "ANDLNL2A"));
            newList.Add(new BicData("ARBN", "ARBNNL22"));
            newList.Add(new BicData("ARSN", "ARSNNL21"));
            newList.Add(new BicData("ARTE", "ARTENL2A"));
            newList.Add(new BicData("ASNB", "ASNBNL21"));
            newList.Add(new BicData("ASRB", "ASRBNL2R"));
            newList.Add(new BicData("ATBA", "ATBANL2A"));
            newList.Add(new BicData("BBRU", "BBRUNL2X"));
            newList.Add(new BicData("BCDM", "BCDMNL22"));
            newList.Add(new BicData("BCIT", "BCITNL2A"));
            newList.Add(new BicData("BICK", "BICKNL2A"));
            newList.Add(new BicData("BKMG", "BKMGNL2A"));
            newList.Add(new BicData("BNGH", "BNGHNL2G"));
            newList.Add(new BicData("BNPA", "BNPANL2A"));
            newList.Add(new BicData("BOFA", "BOFANLNX"));
            newList.Add(new BicData("BOTK", "BOTKNL2X"));
            newList.Add(new BicData("CITC", "CITCNL2A"));
            newList.Add(new BicData("CITI", "CITINL2X"));
            newList.Add(new BicData("COBA", "COBANL2X"));
            newList.Add(new BicData("DEUT", "DEUTNL2N"));
            newList.Add(new BicData("DHBN", "DHBNNL2R"));
            newList.Add(new BicData("DLBK", "DLBKNL2A"));
            newList.Add(new BicData("DNIB", "DNIBNL2G"));
            newList.Add(new BicData("FBHL", "FBHLNL2A"));
            newList.Add(new BicData("FLOR", "FLORNL2A"));
            newList.Add(new BicData("FRBK", "FRBKNL2L"));
            newList.Add(new BicData("FRGH", "FRGHNL21"));
            newList.Add(new BicData("FTSB", "FTSBNL2R"));
            newList.Add(new BicData("FVLB", "FVLBNL22"));
            newList.Add(new BicData("GILL", "GILLNL2A"));
            newList.Add(new BicData("HAND", "HANDNL2A"));
            newList.Add(new BicData("HHBA", "HHBANL22"));
            newList.Add(new BicData("HSBC", "HSBCNL2A"));
            newList.Add(new BicData("ICBK", "ICBKNL2A"));
            newList.Add(new BicData("INGB", "INGBNL2A"));
            newList.Add(new BicData("INKB", "INKBNL21"));
            newList.Add(new BicData("INSI", "INSINL2A"));
            newList.Add(new BicData("ISBK", "ISBKNL2A"));
            newList.Add(new BicData("KABA", "KABANL2A"));
            newList.Add(new BicData("KASA", "KASANL2A"));
            newList.Add(new BicData("KNAB", "KNABNL2H"));
            newList.Add(new BicData("KOEX", "KOEXNL2A"));
            newList.Add(new BicData("KRED", "KREDNL2X"));
            newList.Add(new BicData("LOCY", "LOCYNL2A"));
            newList.Add(new BicData("LOYD", "LOYDNL2A"));
            newList.Add(new BicData("LPLN", "LPLNNL2F"));
            newList.Add(new BicData("MHCB", "MHCBNL2A"));
            newList.Add(new BicData("NNBA", "NNBANL2G"));
            newList.Add(new BicData("NWAB", "NWABNL2G"));
            newList.Add(new BicData("OVBN", "OVBNNL22"));
            newList.Add(new BicData("RABO", "RABONL2U"));
            newList.Add(new BicData("RBOS", "RBOSNL2A"));
            newList.Add(new BicData("RBRB", "RBRBNL21"));
            newList.Add(new BicData("RGRB", "RGRBNL2R"));
            newList.Add(new BicData("SNSB", "SNSBNL2A"));
            newList.Add(new BicData("SOGE", "SOGENL2A"));
            newList.Add(new BicData("STAL", "STALNL2G"));
            newList.Add(new BicData("TEBU", "TEBUNL2A"));
            newList.Add(new BicData("TRIO", "TRIONL2U"));
            newList.Add(new BicData("UBSW", "UBSWNL2A"));
            newList.Add(new BicData("UGBI", "UGBINL2A"));
            newList.Add(new BicData("VOWA", "VOWANL21"));
            newList.Add(new BicData("VPVG", "VPVGNL22"));
            return newList;
        }
    }
    
}