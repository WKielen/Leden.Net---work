using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Util
{
    public static class TelephoneNumber
    {
        static string[] errorMessages =
        {
            "The phonenumber seems to be correct",
            "Structure mobile phonenumber is invalid",
            "Structure phonenumber is invalid",
        };
        
        public static StatusData CheckPhoneNumber(string phoneNumber, bool mobile)
        {

            // Return true if strIn is in valid e-mail format. 
            try
            {
                if (mobile)
                {
                    if (Regex.IsMatch(phoneNumber, "06-[1-9]{1}[0-9]{7}$"))
                        return new StatusData(true, errorMessages[0]);
                    else
                        return new StatusData(false, errorMessages[1]);
                }
                else
                {
                    if (Regex.IsMatch(phoneNumber, "0[0-9]{2}-[0-9]{7}$|0[0-9]{3}-[0-9]{6}$"))
                        return new StatusData(true, errorMessages[0]);
                    else
                        return new StatusData(false, errorMessages[2]);
 
                }
            }
            catch (Exception e)
            {
              return new StatusData(true, e.ToString());
            }
        }
    }
}