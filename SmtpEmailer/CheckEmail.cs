using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Util.Email
{
    /// <summary>
    /// Return data
    /// </summary>
    public class StatusData
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsValid;
        /// <summary>
        /// 
        /// </summary>
        public string Message;

        /// <summary>
        /// 
        /// </summary>
        public StatusData(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }

    /// <summary>
    /// Class with static methods to check or manipulate 
    /// </summary>
    public static class CheckEmail
    {
        static string[] errorMessages =
        {
            "The Email address seems to be correct",
            "Structure Email address is invalid",
        };
        
        /// <summary>
        /// Check if the format of an email address is valid
        /// </summary>
        public static StatusData CheckEmailAddress(string email)
        {

            // Return true if strIn is in valid e-mail format. 
            try
            {
                if ( Regex.IsMatch(email,
                      @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      RegexOptions.IgnoreCase))
                    return new StatusData(true, errorMessages[0]);
                else
                     return new StatusData(false, errorMessages[1]);
               
                }
            catch (Exception e)
            {
              return new StatusData(true, e.ToString());
            }
        }
        /// <summary>
        /// Check if an email address contains a 'smaller' sign. If so the email address is formatted with a name.
        /// </summary>
        public static bool ContainsEditedAddress (string email)
        {
            return (email.Contains("<"));
        }

        /// <summary>
        /// Strip the name from a email address
        /// </summary>
        public static string StripEditedAddress(string email)
        {
            if (CheckEmail.ContainsEditedAddress(email))
            {
                string[] l = email.Split(new char[] { '<', '>' });
                return l[1];
            }
            else
                return email;
        }
    }
}