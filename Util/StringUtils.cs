using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Util.Text
{
	/// <summary>
	/// Collection of string utilities
	/// </summary>
	public class StringUtil
	{
		// a lookup table to spped up hex conversions
		private static string[] byteToHex;

		/// <summary>Initialise StringUtils internal tables</summary>
		static StringUtil()
		{
			byteToHex = new string[256];
			for (int i = 0; i < 256; ++i)
				byteToHex[i] = i.ToString("X2");
		}

        public static string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"•", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"‹", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"›", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"™", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"⁄", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @">", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"©", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"®", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
 //               MessageBox.Show("Error");
                return source;
            }
        } 
		private StringUtil() {}

		/// <summary>
		/// Return the left portion of a string. Doesn't blow up if a string is null or zero-length.
		/// </summary>
		/// <param name="str">The string to get a substring from</param>
		/// <param name="count">The number of characters to get</param>
		/// <returns>
		/// <i>count</i> characters from the left of <i>str</i> if available. If the length of <i>str</i> is
		/// smaller than <i>count</i>, str will be returned. If <i>str</i> is <c>null</c>, the length of <i>str</i> is 0,
		/// or <i>count</i> is 0, than <c>String.Empty</c> is returned.
		/// </returns>
		public static string Left(string str, int count)
		{
			if (str == null || str.Length == 0 || count == 0) return String.Empty;
			if (count > str.Length) return str;
			return str.Substring(0, count); 
		}

		/// <summary>
		/// Return the right portion of a string. Doesn't blow up if a string is null or zero-length.
		/// </summary>
		/// <param name="str">The string to get a substring from</param>
		/// <param name="count">The number of characters to get</param>
		/// <returns>
		/// <i>count</i> characters from the right of <i>str</i> if available. If the length of <i>str</i> is
		/// smaller than <i>count</i>, str will be returned. If <i>str</i> is <c>null</c>, the length of <i>str</i> is 0,
		/// or <i>count</i> is 0, than <c>String.Empty</c> is returned.
		/// </returns>
		public static string Right(string str, int count)
		{
			if (str == null || str.Length == 0 || count == 0) return String.Empty;
			if (count > str.Length) return str;
			return str.Substring(str.Length - count, count); 
		}

		/// <summary>
		/// Return a portion of a string. Doesn't blow up if pos or count are OOB.
		/// </summary>
		/// <param name="str">The string to get a portion of</param>
		/// <param name="pos">The position to start getting from</param>
		/// <param name="count">The number of characters to get</param>
		/// <returns>
		/// An empty string (<c>String.Empty</c>) if <i>str</i> is <c>null</c>, <c>str.Length</c> is 0, <i>count</i> is 0,
		/// <i>pos</i> is smaller than 0, or <i>pos</i> is larger than <c>str.Length</c>,
		/// else a substring starting at <i>pos</i> is returned.
		/// </returns>
		public static string Mid(string str, int pos, int count)
		{
			if (str == null || str.Length == 0 || count == 0) return String.Empty;
			if (pos >= str.Length || pos < 0) return String.Empty;
			if (pos + count > str.Length)
				count = str.Length - pos; 
			return str.Substring(pos, count);
		}

		/// <summary>
		/// Specialisation of Mid(string, int, int) which returns the trailing part of a string from a given position.
		/// Compare with Right, in which a length is specified instead. 
		/// </summary>
		/// <param name="str">The string to get a portion of</param>
		/// <param name="pos">The position to start getting from</param>
		/// <returns>
		/// An empty string (<c>String.Empty</c>) if <i>str</i> is <c>null</c>, <c>str.Length</c> is 0,
		/// <i>pos</i> is smaller than 0, or <i>pos</i> is larger than <c>str.Length</c>,
		/// else the trailing part of <i>str</i> is returned from the given <i>pos</i>,
		/// </returns>
		public static string Mid(string str, int pos)
		{
			return Mid(str, pos, str.Length); 
		}

		/// <summary>
		/// Return the (space-delimited) first token in a string of tokens. Returns null when string is exhausted.
		/// </summary>
		/// <param name="str">The string to get a token from</param>
		/// <returns>The first token from <i>str</i>, or <c>null</c>, if there are no more tokens.</returns>
		public static string Head(ref string str)
		{
			if (str == null || str.Length == 0) return null;

			StringBuilder sb = new StringBuilder(); 
			int pos = 0;
			int quoteStartPos = -1;
			while (pos < str.Length)
			{
				if (str[pos] == ' ') // its a space, then 
				{
					if (quoteStartPos != -1) // in quotes
						sb.Append(str[pos++]); // add it and keep going 
					else if (sb.Length > 0)
					{
						++pos; // point past the space char 
						break;	
					}
					else
						++pos; // ignore the space and keep looking
				}
				else if (str[pos] == '"')
				{
					// if entering quotes
					if (quoteStartPos == -1)
					{
						if (sb.Length > 0)
							break;
						++pos;
						quoteStartPos = pos;
					}
					else // in quotes
					{
						++pos;
						break;
					}
				}
				else
					sb.Append(str[pos++]); 
			}

			// after the loop pos points to the first char which should be retained. or past the last char
			str = Mid(str, pos);
			string result = sb.ToString(); 
			if (result.Length == 0 && quoteStartPos == -1)
				return null;
			return result;

		}

		/// <summary>A simple way of extracting capture groups from a string</summary>
		/// <param name="sourceText"></param>
		/// <param name="searchPattern"></param>
		/// <returns></returns>
		public static string[] GetMatches(string sourceText, string searchPattern)
		{
			MatchCollection mc = Regex.Matches(sourceText, searchPattern, RegexOptions.CultureInvariant);
			ArrayList arr = new ArrayList();
			Match m = Regex.Match(sourceText, searchPattern, RegexOptions.CultureInvariant); 
			for (int i = 0; m.Groups[i].Value != string.Empty; ++i) 
				arr.Add(m.Groups[i].Value); 
			return (string[]) arr.ToArray(typeof(string));
		}

		/// <summary>Trim a string (allowing quoted strings to retain whitespace)</summary>
		public static string TrimString(string str)
		{
			// is the first 
			string trimmed = str.Trim(); 
			int len = trimmed.Length;
			if (len > 1)
			{
				if (trimmed[0] == '\'' && trimmed[len-1] == '\'')
					trimmed = trimmed.Substring(1, len - 2);
				else if (trimmed[0] == '"' && trimmed[len-1] == '"')
					trimmed = trimmed.Substring(1, len - 2);
			}
			return trimmed; 
		}
		/// <summary>
		/// Like String.Replace() but case insensitive
		/// </summary>
		/// <param name="original"></param>
		/// <param name="pattern"></param>
		/// <param name="replacement"></param>
		/// <returns></returns>
		public static string ReplaceEx(string original, 
			string pattern, string replacement)
		{
			int count, position0, position1;
			count = position0 = position1 = 0;
			string upperString = original.ToUpper();
			string upperPattern = pattern.ToUpper();
			int inc = (original.Length/pattern.Length) * 
				(replacement.Length-pattern.Length);
			char [] chars = new char[original.Length + Math.Max(0, inc)];
			while( (position1 = upperString.IndexOf(upperPattern, 
				position0)) != -1 )
			{
				for ( int i=position0 ; i < position1 ; ++i )
					chars[count++] = original[i];
				for ( int i=0 ; i < replacement.Length ; ++i )
					chars[count++] = replacement[i];
				position0 = position1+pattern.Length;
			}
			if ( position0 == 0 ) return original;
			for ( int i=position0 ; i < original.Length ; ++i )
				chars[count++] = original[i];
			return new string(chars, 0, count);
		}

		/// <summary>
		/// Parse a command line into command (turned to lower case) and parameters - allows quoted strings with
		/// embedded spaces. Always returns non-null command and parameters.  
		/// </summary>
		/// <param name="commandLine"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public static string ParseCommand(string commandLine, out string[] parameters)
		{
			string result = Head(ref commandLine);

			string p;
			ArrayList arr = new ArrayList(); 
			while ((p = Head(ref commandLine)) != null)
				arr.Add(p); 

			parameters = (string[]) arr.ToArray(typeof(string)); 
			return result == null ? string.Empty : result.ToLower();
		}


		/// <summary>
		/// Convert a byte array to a memory-dump format. (Used ASCII for character decoding)
		/// </summary>
		/// <param name="bytes">the byte array to dump</param>
		/// <returns>The text formatted string</returns>
		public static string Dump(byte[] bytes)
		{
			return Dump(bytes, Encoding.ASCII); 
		}


		private const string dumpPrefixFormat = "{0:x8}  ";
		private const string dumpTemplate = "AA BB CC DD EE FF GG HH  II JJ KK LL MM NN OO PP  abcdefghijklmnop";

		/// <summary>
		/// Convert a byte array to a memory-dump format. Uses the passed encoding
		/// </summary>
		/// <param name="bytes">the byte array to dump</param>
		/// <param name="encoder">the encoder to use for character decoding</param>
		/// <returns>The text formatted string</returns>
		public static string Dump(byte[] bytes, Encoding encoder)
		{
			if (bytes == null)	throw new ArgumentNullException("bytes");
			if (encoder == null) encoder = Encoding.ASCII;

			byte questionMarkByteValue = encoder.GetBytes("?")[0];


			StringBuilder sb = new StringBuilder(); 
			int nRows = (bytes.Length + 15) / 16;
			for (int row = 0; row < nRows ; ++row)
			{
				string line = dumpTemplate;
				for (int col = 0; col < 16; ++col)
				{
					int index = row * 16 + col; 
					string hexVal;
					string charVal;
					if (index >= bytes.Length)
					{
						hexVal = "  ";
						charVal = " ";
					}
					else
					{
						byte byteValue = bytes[index];
						hexVal = byteValue.ToString("X2"); 
						char c = encoder.GetChars(new byte[] {byteValue})[0];
						if (char.IsControl(c) || (c == '?' && byteValue != questionMarkByteValue)) c = '.';
						charVal = new string(c, 1);
					}
					line = Splice(line, hexVal, dumpTemplate.IndexOf((char) ('A' + col)), 2); 
					line = Splice(line, charVal, dumpTemplate.IndexOf((char) ('a' + col)), 1); 
				}
				sb.Append(string.Format(dumpPrefixFormat, row*16));
				sb.Append(line);
				if (row < nRows-1)
					sb.Append(Environment.NewLine);
			}
			return sb.ToString(); 
		}

		/// <summary>
		/// COnvert back from a dump format strign to the original binary
		/// </summary>
		/// <param name="dumpString"></param>
		/// <returns></returns>
		public static byte[] UnDump(string dumpString)
		{
			if (dumpString == null) throw new ArgumentNullException("dumpString");
			if (dumpString.Length < dumpTemplate.Length) return new byte[0];

			StringBuilder sb = new StringBuilder(); 
			int hexPartStart = string.Format(dumpPrefixFormat, 0).Length;
			int hexPartLength = dumpTemplate.IndexOf("a");
			foreach (string line in dumpString.Split('\n'))
				sb.Append(Mid(line, hexPartStart, hexPartLength).Replace(" ", "")); 
			return FromBase16String(sb.ToString()); 
		}


		/// <summary>Compare binaries and return the index of the first differing byte</summary>
		/// <returns>
		/// -1 if the binaries are identical, else the offset.
		/// </returns>
		public static int CompareBinary(byte[] a, byte[] b)
		{
			int max = a.Length < b.Length ? a.Length : b.Length;
			for (int i = 0; i < max; i++)
				if (a[i] != b[i]) return i;
			if (a.Length < b.Length)	return a.Length;
			if (b.Length < a.Length)	return b.Length;
			return -1;
		}

        ///// <summary>
        ///// Check whether a character is numeric in a given base. 
        ///// </summary>
        ///// <param name="c">The character to check</param>
        ///// <param name="numberBase">The number-base to use</param>
        ///// <returns>true when the character is numeric according to the specified base.</returns>
        public static bool IsNumeric(char c, int numberBase)
        {
            if (numberBase <= 10)
                return (c >= '0' && c <= ('0' + numberBase - 1));
            else
            {
                c = char.ToUpper(c);
                return (c >= '0' && c <= '9') || (c >= 'A' && c <= ('A' + numberBase - 11));
            }
        }

        ///// <summary>
        ///// Check whether a string consists solely of charcteris which are numeric in a given number base
        ///// </summary>
        ///// <param name="s">The string to check</param>
        ///// <param name="numberBase">The number-base to use</param>
        ///// <returns>true when all characters in the string are numeric according to the specified base.</returns>
        public static bool IsNumeric(string s, int numberBase)
        {
            foreach (char c in s)
                if (IsNumeric(c, numberBase) == false)
                    return false;
            return true;
        }

		/// <summary>
		/// Replace a substring with a new string. E.h. Splice("abcdefgh", "oxo", 3, 2) = "abcoxofgh")
		/// </summary>
		/// <param name="original">The original string</param>
		/// <param name="added">the string to insert into <i>original</i></param>
		/// <param name="pos">the position to start replacing/inserting</param>
		/// <param name="len">the number of characters from <i>original</i> that need to be replaced</param>
		/// <returns></returns>
		public static string Splice(string original, string added, int pos, int len)
		{
			if (original == null) original = string.Empty; 
			if (added == null) added = string.Empty; 
			return Left(original, pos) + added + Mid(original, pos + len); 
		}

		/// <summary>
		/// Fit a string into a fixed width for display - if we have to compress then an ellipsis '<c>...</c>' is added
		/// </summary>
		/// <param name="str">The string to justify</param>
		/// <param name="width">The maximum width of the returned string</param>
		/// <param name="useLeading">Put ellipsis instead of first characters if <i>true</i>, at end if <i>false</i></param>
		/// <returns>The justified string</returns>
		public static string Justify(string str, int width, bool useLeading)
		{
			if (width < 1) return string.Empty;
			if (str.Length <= width) 
				return string.Concat(str, new string(' ', width - str.Length) );
			if (width < 3) 
				return useLeading ? Left(str, width) : Right(str, width); 
			if (useLeading) 
				return Left(str, width - 3) + "...";
			else
				return "..." + Right(str, width - 3);
		}

		#region byte[] to string representations
		/// <summary>
		/// Convert a byte array to a string in Base64 encoding
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns>the encoded string</returns>
		/// <remarks>Base 64 is a .Net default encoding for binary data</remarks>
		public static string ToBase64String(byte[] bytes)
		{
			return Convert.ToBase64String(bytes);
		}

		/// <summary>
		/// Convert a string in Base64 encoding to a byte array
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		/// <remarks>Base 64 is a .Net default encoding for binary data</remarks>
		public static byte[] FromBase64String(string str)
		{
			if (str.Length == 0)
				return new byte[0];
			return Convert.FromBase64String(str); 
		}

		private static int HexCharToInt(char c)
		{
			if (c >= '0' && c <= '9') return c - '0';
			if (c >= 'A' && c <= 'F') return 10 + c - 'A';
			if (c >= 'a' && c <= 'f') return 10 + c - 'a';
			throw new FormatException("Invalid hex character"); 
		}

		/// <summary>
		/// Convert a byte array to a Hex representation
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns>The hex representation of the byte array</returns>
		public static string ToBase16String(byte[] bytes)
		{
			StringBuilder sb = new StringBuilder(bytes.Length * 2);
			for (int i = 0, j = bytes.Length; i < j; ++i)
				sb.Append(byteToHex[bytes[i]]);
			return sb.ToString();
		}

		/// <summary>
		/// Convert a byte to a Hex representation
		/// </summary>
		/// <param name="b"></param>
		/// <returns>The hex representation of the byte</returns>
		public static string ToBase16String(byte b)
		{
			return byteToHex[b];
		}

		/// <summary>
		/// Convert a string in Hex encoding to a byte array
		/// </summary>
		/// <param name="str"></param>
		/// <returns>the byte array represented by the string</returns>
		public static byte[] FromBase16String(string str)
		{
			int strLength = str.Length;
			byte[] bytes = new byte[strLength >> 1];
			for (int byteIndex = 0, charIndex = 0; charIndex < strLength; charIndex = ++byteIndex << 1)
				bytes[byteIndex] = (byte) (HexCharToInt(str[charIndex]) * 16 + HexCharToInt(str[charIndex+1]));
			return bytes; 
		}

		/// <summary>
		/// Convert a byte array to a string in Base24 encoding
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns>the encoded string</returns>
		/// <remarks>Base 24 is <b>not</b> a .Net default encoding for binary data. It represents 3 bytes in 4 characters, by shifting 6 bits at the time into the printable region of the codetable</remarks>
		public static string ToBase24String(byte[] bytes)
		{
			byte[] encodeBuffer = new byte[(bytes.Length * 8 + 5) / 6];

			StringBuilder sOutput = new StringBuilder();
			Array.Copy (bytes,encodeBuffer,bytes.Length );
			int result = 0;
			for(int i=0;i<(((bytes.Length + 2) / 3) * 3) ;i+=3)
			{
				// 1 ste 6 bits
				result = ((encodeBuffer[i] >> 2) + 48);
				sOutput.Append ((char)result); 

				// 2nd 6 bits
				result = ( ((encodeBuffer[i] & 0x03) << 4) + 
					(encodeBuffer[i+1] >> 4) + 48 );
				sOutput.Append ((char)result);

				// 3rd 6 bits
				if ((i+1)>=bytes.Length) break;
				result = ( ((encodeBuffer[i+1] & 0x0F) << 2) + 
					((encodeBuffer[i+2]  & 0xC0) >> 6) + 48);
				sOutput.Append ((char)result);

				// 4th 6 bits
				if ((i+2)>=bytes.Length) break;
				result = ((encodeBuffer[i+2] & 0x3F) + 48);
				sOutput.Append ((char)result);
	
			}
			return sOutput.ToString();
		}

		/// <summary>
		/// Convert a string in Base24 encoding to a byte array
		/// </summary>
		/// <param name="str"></param>
		/// <returns>the byte array represented by the string</returns>
		/// <remarks>Base 24 is <b>not</b> a .Net default encoding for binary data. It represents 3 bytes in 4 characters, by shifting 6 bits at the time into the printable region of the codetable</remarks>
		public static byte[] FromBase24String(string str)
		{
			byte[] baResult = new byte[((str.Length * 6) / 8)];
			int j = 0;
			for (int i = 0;i<(((str.Length + 3) / 4) * 4); i+=4)
			{
				if (str.Length <= (i+1)) break;
				baResult[j++] = (byte) (((str[i] - 48) << 2) + 
					(((str[i+1] - 48) & 0x30) >> 4));

				if (str.Length <= (i+2)) break;
				baResult[j++] = (byte) (((str[i+1] - 48) << 4) + 
					(((str[i+2] - 48) & 0x3C) >> 2));

				if (str.Length <= (i+3)) break;
				baResult[j++] = (byte) ((((str[i+2] - 48) & 0x03) << 6) + 
					((str[i+3] - 48) & 0x3F));
			}
			return baResult;
		}
		#endregion

		/// <summary>Join an array of strings into a single string - the opposite of Split()</summary>
		/// <param name="items"></param>
		/// <param name="delimiter"></param>
		/// <returns></returns>
		public static string Join(string[] items, char delimiter)
		{
			StringBuilder sb = new StringBuilder(); 
			if (items != null) 
				for (int i = 0; i < items.Length; ++i)
				{
					sb.Append(items[i]);
					if (i != items.Length-1)
						sb.Append(delimiter); 
				}
			return sb.ToString(); 
		}

		/// <summary>
		/// string.Split offering a single char as the delimiter argument. A partner to the Join method
		/// </summary>
		/// <param name="str"></param>
		/// <param name="delimiter"></param>
		/// <returns></returns>
        //public static string[] Split(string str, char delimiter)
        //{
        //    return str.Split(new char[] {delimiter}); 
        //}
        public static List<string> Split(string str, char delimiter)
        {
             return str.Split(new char[] {delimiter}).Cast<string>().ToList();
        }

		/// <summary>
		/// Get a textual description of an exception - including nested exceptions. NOT culture-independant.
		/// </summary>
		/// <param name="e"></param>
		/// <param name="verbose"></param>
		/// <returns></returns>
		public static string GetExceptionText(Exception e, bool verbose)
		{
			return GetExceptionText(e, verbose, "Exception", "Source", "Stack Trace", "Nested Exception", 
				"Start of Exception Details", "End of Exception Details"); 
		}

		/// <summary>Get a textual description of an exception</summary>
		/// <param name="e"></param>
		/// <param name="verbose"></param>
		/// <param name="exceptionToken"></param>
		/// <param name="sourceToken"></param>
		/// <param name="stackTraceToken"></param>
		/// <param name="nestedExceptionToken"></param>
		/// <param name="startDetailsToken"></param>
		/// <param name="endDetailsToken"></param>
		/// <returns></returns>
		public static string GetExceptionText(
			Exception e, 
			bool verbose, 
			string exceptionToken, 
			string sourceToken, 
			string stackTraceToken, 
			string nestedExceptionToken, 
			string startDetailsToken,
			string endDetailsToken)
		{
			StringBuilder sb = new StringBuilder(1024);
			if (verbose)
				sb.Append(exceptionToken + ":" + Environment.NewLine); 

			// get the messages from the innermost -> outermost
			Stack stack = new Stack();
			Exception ex = e;
			while (ex != null)
			{
				stack.Push(ex);
				ex = ex.InnerException;
			}
			int levels = stack.Count; 
			for (int i = 0; i < levels; ++i)
			{
				ex = (Exception) stack.Pop();
				if (verbose) sb.AppendFormat("  {0}: ", i); 
				sb.Append("(" + ex.GetType().Name + ") " + ex.Message); 
				if (verbose)
					sb.Append(Environment.NewLine);
				else if (i < stack.Count-1) 
					sb.Append(" => ");
			}

			// Finished? 
			if (verbose == false) 
			{
				sb.AppendFormat(", {0}:{1}", sourceToken, e.Source);
				return sb.ToString(); 
			}

			// do the stack trace
			sb.Append(stackTraceToken);
			sb.Append(" :"); 

			int indent = 2;
			--levels; 
			string nl = new string(Char.MinValue, 1); 
			ex = e;
			while (ex != null)
			{
				string tab = Environment.NewLine + new String(' ', indent); 
				sb.AppendFormat("{0}{1}{2} ========> {3}: ({4}) {5}", 
					Environment.NewLine, tab, (string) (indent == 2 ? exceptionToken : nestedExceptionToken), levels--, ex.GetType().Name, ex.Message); 
				sb.AppendFormat("{0}{1}: {2}", tab, sourceToken, ex.Source);

				if (ex.StackTrace != null && ex.StackTrace.Length > 0)
				{
					// bug in stack trace -> uses \n instead of Environment.NewLine
					string trace = ex.StackTrace.Replace(Environment.NewLine, nl).Replace('\n', nl[0]);
					sb.Append(tab + trace.Replace(nl, tab));
				}

				ex = ex.InnerException;
				indent += 2;
			}
			return sb.ToString();
		}

		#region EBCDIC conversion
		/// <summary>Convert a string from ANSI/ASCII-ISO to EBCDIC representation</summary>
		/// <param name="str"></param>
		/// <returns>the EBCDIC representation of the string</returns>
		public static byte[] ToEbcdic(string str)
		{
			return EbcdicEncoding.ToEbcdic(str);
		}
		/// <summary>Convert a string from EBCDIC to ANSI/ASCII-ISO representation</summary>
		/// <param name="bytes"></param>
		/// <returns>the ANSI representation of the byte array</returns>
		public static string FromEbcdic(byte[] bytes)
		{
			return EbcdicEncoding.FromEbcdic(bytes);
		}
		/// <summary>
		/// Nested class using the Windows encoder to do the work. Uses <see cref="System.Text.Encoding.GetEncoding(int)"/>,
		/// using <see cref="System.Globalization.TextInfo.EBCDICCodePage"/> from <see cref="System.Globalization.CultureInfo.InvariantCulture"/>.
		/// </summary>
		public class EbcdicEncoding
		{
			private static readonly Encoding encoding = Encoding.GetEncoding(System.Globalization.CultureInfo.InvariantCulture.TextInfo.EBCDICCodePage);
			/// <summary>Convert a string from ANSI/ASCII-ISO to EBCDIC representation</summary>
			/// <param name="str"></param>
			/// <returns>the EBCDIC representation of the string</returns>
			public static byte[] ToEbcdic(string str)
			{
				return encoding.GetBytes(str);
			}
			/// <summary>Convert a string from EBCDIC to ANSI/ASCII-ISO representation</summary>
			/// <param name="bytes"></param>
			/// <returns>the ANSI representation of the byte array</returns>
			public static string FromEbcdic(byte[] bytes)
			{
				return encoding.GetString(bytes);
			}
			/// <summary>Get the EbcdicEncoding for the InvariantCulture.</summary>
			public static Encoding Encoding { get { return encoding; } }
		}
		#endregion
	}

	#region Tagger
	/// <summary>
	/// Simple Tag extraction from byte arrays. 
	/// </summary>
	public class Tagger
	{
		/// <summary>The tag string used to initialise this tagger instance</summary>
		public string TagString;

		/// <summary>The set of Tags described by the tag string</summary>
		public readonly Tag[] tags; 

		/// <summary>A class which can extract a single tag from the byte stream</summary>
		public class Tag
		{
			private Encoding encoding; 
			private static string defaultValue = string.Empty; 

			/// <summary>Tags can be in either of these formats</summary>
			public enum TagFormat {
				/// <summary>Simple text form (usually ASCII)</summary>
				Text, 
				/// <summary>Binary form (we convert to hex for cmoparisons)</summary>
				Binary
			}; 
			/// <summary>The tag format associated withi this tag</summary>
			public TagFormat Format;
			/// <summary>The start position of teh tag within the byte stream</summary>
			public int StartPos;
			/// <summary>The length of the tag within the byte stream</summary>
			public int Length;

			/// <summary>Construct a Tag instance with defaul ASCII encoding</summary>
			/// <param name="tag"></param>
			internal Tag(string tag) : this(tag, Encoding.ASCII) {}

			/// <summary>Construct a Tag instance</summary>
			/// <param name="tag"></param>
			/// <param name="encoding"></param>
			internal Tag(string tag, Encoding encoding)
			{
				if (tag == null) throw new ArgumentNullException("tag"); 
				this.encoding = encoding;
				if (tag.Length < 3) throw new ArgumentException("Invalid tag length: " + tag, tag); 
				char last = tag[tag.Length-1];
				if (last == 'a' || last == 'A') 
				{
					this.Format = TagFormat.Text;
					tag = StringUtil.Left(tag, tag.Length-1); 
				}
				else if (last == 'b' || last == 'B') 
				{
					this.Format = TagFormat.Binary;
					tag = StringUtil.Left(tag, tag.Length-1); 
				}
				else if (char.IsDigit(last)) // none specified
					this.Format = TagFormat.Text;
				else
					throw new ArgumentException("Invalid tag type: " + tag, tag);

				int colonPos = tag.IndexOf(':');
				this.StartPos = int.Parse(tag.Substring(0, colonPos));
				this.Length = int.Parse(tag.Substring(colonPos + 1)); 
			}

			/// <summary>Return a single tag from the presented binary data</summary>
			/// <param name="bytes"></param>
			/// <param name="offset"></param>
			/// <returns></returns>
			public string GetTag(byte[] bytes, int offset)
			{
				int firstByte = StartPos + offset;
				if (firstByte + Length > bytes.Length) 
					return defaultValue;

				if (Format == TagFormat.Text)
					return encoding.GetString(bytes, firstByte, Length); 

				if (Format == TagFormat.Binary)
				{
					byte[] tagBytes = new byte[Length]; 
					Array.Copy(bytes, firstByte, tagBytes, 0, Length); 
					return StringUtil.ToBase16String(tagBytes); 
				}
				
				return defaultValue; 
			}
		}

		/// <summary>Construct a tagger with a default ASCII encoding</summary>
		public Tagger(string tagsSpecifier) : this(tagsSpecifier, Encoding.ASCII) {}
		
		/// <summary>
		/// Construct a tagger from a teg specifier string. For example <c>3:7a;1:2b</c> would extract 7 ascii characters from position 3 and 
		/// the hex representation of the 2 bytes from position 1, concatenated together.
		/// </summary>
		/// <param name="tagsSpecifier"></param>
		/// <param name="encoding"></param>
		public Tagger(string tagsSpecifier, Encoding encoding)
		{
			if (tagsSpecifier == null)
				throw new ArgumentNullException("tagsSpecifier");

			this.TagString = tagsSpecifier; 

			string[] tagSpecifiers = tagsSpecifier.Trim().Split(';');
			if (tagSpecifiers.Length < 1)
				throw new ArgumentException("Invalid tag specification string", tagsSpecifier);

			ArrayList tagsList = new ArrayList(); 
			for (int i = 0; i < tagSpecifiers.Length; ++i)
				if (tagSpecifiers[i].Length > 0)
					tagsList.Add(new Tag(tagSpecifiers[i], encoding));
			tags = (Tag[]) tagsList.ToArray(typeof(Tag)); 
		}

		/// <summary>Calculate how many bytes we need to read ahead</summary>
		public int GetReadAheadLength()
		{
			int result = int.MinValue;
			for (int i = 0; i < tags.Length; ++i)
			{
				int readAhead = tags[i].StartPos + tags[i].Length;
				if (readAhead > result)
					result = readAhead;
			}
			return result;
		}

		/// <summary>Return the tag value from a message.</summary>
		public string GetTag(byte[] message)
		{
			return GetTag(message, 0); 
		}

		/// <summary>
		/// Return the tag value from a message.
		/// </summary>
		/// <param name="message">The message (in binary form) to search</param>
		/// <param name="offset">The position to search from</param>
		/// <returns></returns>
		public string GetTag(byte[] message, int offset)
		{
			StringBuilder sb = new StringBuilder(32);
			foreach (Tag tag in tags)
				sb.Append(tag.GetTag(message, offset));
			return sb.ToString(); 
		}
	}
	#endregion
}
