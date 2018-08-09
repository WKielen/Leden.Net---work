using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Text;
using System.Reflection;
using System.Globalization;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Runtime.Serialization;

using Mosaic.Common.IO;
using Mosaic.Common.Diagnostics;

namespace Mosaic.Common.Xml.Xsl
{
	/// <summary>
	/// A Method that Transforms a XML InputString using a XSL String
	/// </summary>
	#region ExecuteXSL
	public class ExecuteXsl
	{
		private ExecuteXsl(){}
		/// <summary>
		/// Transform returns the result of transforming the supplied xmlString with
		/// the supplied xslString.
		/// </summary>
		/// <param name="xslString"></param>
		/// <param name="xmlString"></param>
		/// <returns></returns>
		public static String Transform (string xslString, string xmlString)
		{
			try
			{
				// Load the XSL script into de Transform
				XmlTextReader xmlTextXSL = new XmlTextReader(new StringReader(xslString));
				XslTransform xslt = new XslTransform();
				xslt.Load(xmlTextXSL, null, null);
				// Convert Input from string to XPathNavigator via XPathDocument
				XmlTextReader xmlTextInput = new XmlTextReader(new StringReader(xmlString));
				XPathNavigator nav = new XPathDocument(xmlTextInput).CreateNavigator();
				// Output goes to a StringWriter
				StringWriter strWrt = new  StringWriter();
				XmlTextWriter xmlTextOutput = new XmlTextWriter(strWrt);
				xmlTextOutput.Formatting = Formatting.Indented;
				//
				// Transform input
				//
				xslt.Transform(nav, null, xmlTextOutput, null);
				return strWrt.ToString();
			}
			catch(Exception ex)
			{
				throw (new ApplicationException ("XSL Transform Error", ex));

			}
		}
	}
	#endregion
}

namespace Mosaic.Common.Xml.XPath
{
	/// <summary>
	/// An evaluation result is the result of evaluating an XPath expression. It allows coercion (following 
	/// the normal XPath coercion rules) to one of the four XPath data types. 
	/// </summary>
	#region EvaluationResult class
	public class EvaluationResult
	{
		private XPathResultType resultType;

		/// <summary>An evaluation result of an unknown type</summary>
		public static EvaluationResult None = new EvaluationResult(XPathResultType.Any, null);

		/// <summary>Default double style used for parsing double from string</summary>
		public const NumberStyles DefaultDoubleStyle = NumberStyles.Float & (NumberStyles.Any ^ NumberStyles.AllowExponent);

		/// <summary>The result returned from the execution of the xpath expression</summary>
		public object Result;

		private EvaluationResult(XPathResultType resultType, object result)
		{
			this.Result = result;
			this.resultType = resultType;
		}

		/// <summary>Execute an XPath expression and return the EvaluationResult</summary>
		/// <returns>An EvaluationResult - call <see cref="ToString"/>, <see cref="ToBool"/> etc. for coercion to the required type.</returns>
		public static EvaluationResult Evaluate(XPathNavigator nav, XPathExpression expr)
		{
			object result = nav.Evaluate(expr); 
			XPathResultType resultType = expr.ReturnType;
			switch(resultType)
			{
				case XPathResultType.Number:
				case XPathResultType.Boolean:
				case XPathResultType.String:
				case XPathResultType.NodeSet:
					return new EvaluationResult(resultType, result);
				default:
					return EvaluationResult.None;
			}
		}

		/// <summary>Compile, the execute an XPath expression and return the EvaluationResult</summary>
		/// <returns>An EvaluationResult - call <see cref="ToString"/>, <see cref="ToBool"/> etc. for coercion to the required type.</returns>
		public static EvaluationResult Evaluate(XPathNavigator nav, string expression)
		{
			XPathExpression expr = nav.Compile(expression);
			return Evaluate(nav, expr); 
		}

		// Before coercing, verify that the result is valid
		private void ValidateResultType()
		{
			switch (resultType)
			{
				case XPathResultType.Number:
				case XPathResultType.Boolean:
				case XPathResultType.String:
				case XPathResultType.NodeSet:
				case XPathResultType.Any:
					return;
				default:
					throw new ApplicationException("Attempt to coerce an XPath result of type " + resultType);
			}
		}

		#region ToBool
		/// <summary>Coerce this <see cref="EvaluationResult"/> to a bool</summary>
		public bool ToBool()
		{
			ValidateResultType();
			switch(resultType)
			{
				case XPathResultType.NodeSet:
					return ((XPathNodeIterator) Result).MoveNext();
				case XPathResultType.String:
					string str = (string) Result;
					if (str == null || str.Length == 0)
						return false;
					return true;
				case XPathResultType.Number:
					double res = (double)Result;
					return res != 0.0 && res != -0.0 && res != double.NaN;
				case XPathResultType.Boolean:
					return (bool)Result;
			}
			return false;
		}
		#endregion
		#region ToString
		/// <summary>Coerce this <see cref="EvaluationResult"/> to a string</summary>
		public override string ToString() { return ToString(false); }
		/// <summary>Coerce this <see cref="EvaluationResult"/> to a string</summary>
		/// <param name="useSpace">If true (and result is a node-set), will introduce spaces between each node value</param>
		public string ToString(bool useSpace)
		{
			ValidateResultType();
			switch(resultType)
			{
				case XPathResultType.NodeSet:
					StringBuilder sb = new StringBuilder();
					XPathNodeIterator it = (XPathNodeIterator)((XPathNodeIterator)Result).Clone();
					bool isFirst = true;
					while(it.MoveNext())
					{
						string s = it.Current.Value;
						if (s == null || s.Length == 0)
							continue;
						if (useSpace)
						{
							if (isFirst)
								isFirst = false;
							else
								sb.Append(" ");
						}
						sb.Append(s);
					}
					return sb.ToString();
				case XPathResultType.String:
					return (string) Result;
				case XPathResultType.Number:
					return ((double) Result).ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
				case XPathResultType.Boolean:
					return ((bool) Result).ToString();
			}
			return string.Empty;
		}
		#endregion
		#region ToDouble
		/// <summary>Coerce this <see cref="EvaluationResult"/> to a double using the default number style</summary>
		/// <returns></returns>
		public double ToDouble()
		{
			return ToDouble(DefaultDoubleStyle);
		}
		/// <summary>Coerce this <see cref="EvaluationResult"/> to a double</summary>
		public double ToDouble(NumberStyles doubleStyle)
		{
			ValidateResultType();
			try 
			{
				switch(resultType)
				{
					case XPathResultType.NodeSet:
						return Double.Parse(ToString(), doubleStyle, NumberFormatInfo.InvariantInfo);
					case XPathResultType.String:
						return Double.Parse(ToString(), doubleStyle, NumberFormatInfo.InvariantInfo);
					case XPathResultType.Number:
						return (double) Result;
					case XPathResultType.Boolean:
						bool isTrue = (bool) Result;
						return isTrue ? 1 : 0;
				}
			}
			catch {}
			return Double.NaN;
		}
		#endregion
		#region ToNodeSet
		/// <summary>Coerce this <see cref="EvaluationResult"/> to a bool</summary>
		/// <remarks>Returns null for anything other than an actual node-set result</remarks>
		public XPathNodeIterator ToNodeSet()
		{
			ValidateResultType();
			switch(resultType)
			{
				case XPathResultType.NodeSet:
					return (XPathNodeIterator) Result;
				default: break;
			}
			return null;
		}
		#endregion
	}
	#endregion
}

namespace Mosaic.Common.Xml
{

	/// <summary>XmlReader which allows files to include other xml files.</summary>
	#region XmlIncludeReader
	public class XmlIncludeReader : XmlTextReader
	{
		// nested reader for processing XInclude elements
		private XmlIncludeReader nestedReader = null;

		// filename of nested reader
		private string nestedFilename = null;

		/// <summary>
		/// Custom implementation of <see cref="XmlTextReader.Read">Read</see>: if a nested reader exists, delegate
		/// otherwise, Read the next node and check for xinc:include if one exists create another nested reader and continue
		/// </summary>
		public override bool Read()
		{
			bool bMore;
			string strHref = null;
			string[] tokens = new string[0]; 
			string[] replaceText = new string[0];

			// if nested reader exists, delegate
			if (nestedReader != null)
			{
				bMore = nestedReader.Read();
				// if done with nested reader, free resources & reset state
				if (!bMore)
					return CloseNestedReader();
				else 
					return true;
			}
			else
			{
				// read the next node and check for <xinc:include href="<filename>" />
				bMore = base.Read();

				if (bMore && base.NodeType == XmlNodeType.Element)
				{
					// If you're xml file contains an error, the return error information is not
					// always that useful. Enable the following line to get element and line number
					//System.Diagnostics.Trace.WriteLine(String.Format("Reading element: {0} at line {1}", base.LocalName, base.LineNumber));

					// attempt to process XmlBase and XmlInclude noted
					if (string.Compare(base.NamespaceURI, "http://www.w3.org/1999/XML/xinclude", true)==0 && string.Compare(base.LocalName, "include", true)==0)
					{
						if (!IsEmptyElement)
							throw new XmlException("Include directive should be empty element, e.g. <include href=\"...\" />", null);

						strHref = base.GetAttribute("href");
						if (strHref == null)
							throw new XmlException("Missing 'href' attribute from XmlInclude element", null);

						string parseType = base.GetAttribute("parse");
						if (parseType != null && parseType.ToLower() != "xml")
							throw new XmlException("parse attribute on include element can only be \"xml\" ", null);

						string tokenList = base.GetAttribute("tokens");
						if (tokenList != null)
						{
							string replaceTextList = base.GetAttribute("replace");
							if (replaceTextList == null)
								throw new XmlException("if 'tokens' attribute is specified, 'replace' must be also", null);
							tokens = tokenList.Split(new char[] {';'}); 
							replaceText = replaceTextList.Split(new char[] {';'});
							if (tokens.Length != replaceText.Length)
								throw new XmlException("mismatch between 'tokens' and 'replace' attributes", null);
						}

					}
				}

				// if found, create a new nested reader and move to the first node
				if (strHref != null)
				{
					// load the whole file
					string safeFileName = null;
					if (Path.IsPathRooted(strHref))
						safeFileName = strHref;
					else
					{
						safeFileName = XmlHelper.GetImageFilename("", Path.GetFileNameWithoutExtension(strHref), Path.GetExtension(strHref) );
						if (safeFileName == null && base.BaseURI.Length > 0)
						{
							string localFile = Path.GetDirectoryName(base.BaseURI) + "\\" + strHref;
							if (File.Exists(localFile))
								safeFileName = localFile;
						}
						
					}
					if (safeFileName == null || File.Exists(safeFileName) == false)
						throw new XmlConfigException("Missing XIncluded file : " + strHref + " (this must be found in the executable path)"); 
					string subFile = StringFileIO.Read(safeFileName);

					// change the tokens
					if (tokens.Length > 0) 
						for (int i = 0; i < tokens.Length; ++i)
							subFile = subFile.Replace("@" + tokens[i].Trim() + "@", replaceText[i].Trim());

					// now we'll read from the changed string 
					nestedReader = new XmlIncludeReader(new StringReader(subFile)); 
					nestedReader.WhitespaceHandling = this.WhitespaceHandling;
					nestedFilename = subFile;
					nestedReader.MoveToContent();
					return true;
				}
				else
					return bMore;
			}
		}

		private bool CloseNestedReader()
		{
			nestedReader.Close();
			nestedReader = null;
			nestedFilename = null;
			return base.Read();
		}

		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(System.IO.TextReader input): base(input) {}
		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(System.IO.Stream input) : base(input) {}
		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(System.IO.TextReader input, System.Xml.XmlNameTable nt) : base(input, nt) {}
		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(System.IO.Stream input, System.Xml.XmlNameTable nt) : base(input, nt) {}
		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(string url) : base(url) {}
		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(string url, System.IO.TextReader input) : base(url, input) {}
		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(string url, System.IO.Stream input) : base (url, input) {}
		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(string url, System.IO.Stream input, System.Xml.XmlNameTable nt) : base (url, input, nt) {}
		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(string url, System.IO.TextReader input, System.Xml.XmlNameTable nt): base (url, input, nt) {}
		/// <summary>Initialise a new XmlIncludeReader instance</summary>
		public XmlIncludeReader(string url, System.Xml.XmlNameTable nt): base (url, nt) {}

		// Properties
		/// <summary>Get the number of <see cref="XmlTextReader.AttributeCount">attributes</see> of the current node</summary>
		public override int AttributeCount 
		{
			get 
			{
				if (nestedReader == null) return base.AttributeCount; else return nestedReader.AttributeCount; 
			} 
		}
		
		/// <summary>Get the <see cref="XmlTextReader.BaseURI">base URI</see> of the current node</summary>
		public override string BaseURI 
		{
			get 
			{
				if (nestedReader == null) return base.BaseURI; else return nestedReader.BaseURI; 
			} 
		}
		/// <summary>See <see cref="XmlReader.CanResolveEntity"/></summary>
		public override bool CanResolveEntity 
		{
			get 
			{
				if (nestedReader == null) return base.CanResolveEntity; else return nestedReader.CanResolveEntity; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.Depth"/></summary>
		public override int Depth 
		{
			get 
			{
				if (nestedReader == null) return base.Depth; else return nestedReader.Depth; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.Depth"/></summary>
		public override bool EOF 
		{
			get 
			{
				if (nestedReader == null) return base.EOF; else return nestedReader.EOF; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.Depth"/></summary>
		public override bool HasAttributes 
		{
			get 
			{
				if (nestedReader == null) return base.HasAttributes; else return nestedReader.HasAttributes; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.HasValue"/></summary>
		public override bool HasValue 
		{
			get 
			{
				if (nestedReader == null) return base.HasValue; else return nestedReader.HasValue; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.IsDefault"/></summary>
		public override bool IsDefault 
		{
			get 
			{
				if (nestedReader == null) return base.IsDefault; else return nestedReader.IsDefault; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.IsEmptyElement"/></summary>
		public override bool IsEmptyElement 
		{
			get 
			{
				if (nestedReader == null) return base.IsEmptyElement; else return nestedReader.IsEmptyElement; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.this[int]"/></summary>
		public override string this[ int i ] 
		{
			get 
			{
				if (nestedReader == null) return base[i]; else return nestedReader[i]; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.this[string,string]"/></summary>
		public override string this[ string name, string namespaceURI ] 
		{
			get 
			{
				if (nestedReader == null) return base[name, namespaceURI]; else return nestedReader[name, namespaceURI]; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.this[string]"/></summary>
		public override string this[ string name ] 
		{
			get 
			{
				if (nestedReader == null) return base[name]; else return nestedReader[name]; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.LocalName"/></summary>
		public override string LocalName 
		{
			get 
			{
				if (nestedReader == null) return base.LocalName; else return nestedReader.LocalName; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.Name"/></summary>
		public override string Name 
		{
			get 
			{
				if (nestedReader == null) return base.Name; else return nestedReader.Name; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.NamespaceURI"/></summary>
		public override string NamespaceURI 
		{
			get 
			{
				if (nestedReader == null) return base.NamespaceURI; else return nestedReader.NamespaceURI; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.NameTable"/></summary>
		public override XmlNameTable NameTable 
		{
			get 
			{
				if (nestedReader == null) return base.NameTable; else return nestedReader.NameTable; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.NodeType"/></summary>
		public override XmlNodeType NodeType 
		{
			get 
			{
				if (nestedReader == null) return base.NodeType; else return nestedReader.NodeType; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.Prefix"/></summary>
		public override string Prefix 
		{
			get 
			{
				if (nestedReader == null) return base.Prefix; else return nestedReader.Prefix; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.QuoteChar"/></summary>
		public override char QuoteChar 
		{
			get 
			{
				if (nestedReader == null) return base.QuoteChar; else return nestedReader.QuoteChar; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.ReadState"/></summary>
		public override ReadState ReadState 
		{
			get 
			{
				if (nestedReader == null) return base.ReadState; else return nestedReader.ReadState; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.Value"/></summary>
		public override string Value 
		{
			get 
			{
				if (nestedReader == null) return base.Value; else return nestedReader.Value; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.XmlLang"/></summary>
		public override string XmlLang 
		{
			get 
			{
				if (nestedReader == null) return base.XmlLang; else return nestedReader.XmlLang; 
			} 
		}
		
		/// <summary>See <see cref="XmlTextReader.XmlSpace"/></summary>
		public override XmlSpace XmlSpace 
		{
			get 
			{
				if (nestedReader == null) return base.XmlSpace; else return nestedReader.XmlSpace; 
			} 
		}

		// Methods
		/// <summary>See <see cref="XmlTextReader.Close"/></summary>
		public override void Close()
		{
			if (nestedReader != null)
				nestedReader.Close();
			base.Close();
		}
		/// <summary>See <see cref="Object.Equals"/></summary>
		public override bool Equals(object obj)
		{
			if (nestedReader == null)
				return base.Equals(obj);
			else
				return nestedReader.Equals(obj);
		}
		/// <summary>See <see cref="XmlTextReader.GetAttribute(int)"/></summary>
		public override string GetAttribute(int i)
		{
			if (nestedReader == null)
				return base.GetAttribute(i);
			else
				return nestedReader.GetAttribute(i);
		}
		/// <summary>See <see cref="XmlTextReader.GetAttribute(string,string)"/></summary>
		public override string GetAttribute(string localName, string namespaceURI)
		{
			if (nestedReader == null)
				return base.GetAttribute(localName, namespaceURI);
			else
				return nestedReader.GetAttribute(localName, namespaceURI);
		}
		/// <summary>See <see cref="XmlTextReader.GetAttribute(string)"/></summary>
		public override string GetAttribute(string name)
		{
			if (nestedReader == null)
				return base.GetAttribute(name);
			else
				return nestedReader.GetAttribute(name);
		}
		/// <summary>See <see cref="Object.GetHashCode"/></summary>
		public override int GetHashCode()
		{
			if (nestedReader == null)
				return base.GetHashCode();
			else
				return nestedReader.GetHashCode();
		}
		/// <summary>See <see cref="XmlReader.IsStartElement()"/></summary>
		public override bool IsStartElement()
		{
			if (nestedReader == null)
				return base.IsStartElement();
			else
				return nestedReader.IsStartElement();
		}
		/// <summary>See <see cref="XmlReader.IsStartElement(string,string)"/></summary>
		public override bool IsStartElement(string localname, string ns)
		{
			if (nestedReader == null)
				return base.IsStartElement(localname, ns);
			else
				return nestedReader.IsStartElement(localname, ns);
		}
		/// <summary>See <see cref="XmlReader.IsStartElement(string)"/></summary>
		public override bool IsStartElement(string name)
		{
			if (nestedReader == null)
				return base.IsStartElement(name);
			else
				return nestedReader.IsStartElement(name);
		}
		/// <summary>See <see cref="XmlTextReader.LookupNamespace"/></summary>
		public override string LookupNamespace(string prefix)
		{
			if (nestedReader == null)
				return base.LookupNamespace(prefix);
			else
				return nestedReader.LookupNamespace(prefix);
		}
		/// <summary>See <see cref="XmlTextReader.MoveToAttribute(int)"/></summary>
		public override void MoveToAttribute(int i)
		{
			if (nestedReader == null)
				base.MoveToAttribute(i);
			else
				nestedReader.MoveToAttribute(i);
		}
		/// <summary>See <see cref="XmlTextReader.MoveToAttribute(string,string)"/></summary>
		public override bool MoveToAttribute(string localName, string namespaceURI)
		{
			if (nestedReader == null)
				return base.MoveToAttribute(localName, namespaceURI);
			else
				return nestedReader.MoveToAttribute(localName, namespaceURI);
		}
		/// <summary>See <see cref="XmlTextReader.MoveToAttribute(string)"/></summary>
		public override bool MoveToAttribute(string name)
		{
			if (nestedReader == null)
				return base.MoveToAttribute(name);
			else
				return nestedReader.MoveToAttribute(name);
		}
		/// <summary>See <see cref="XmlReader.MoveToContent"/></summary>
		public override XmlNodeType MoveToContent()
		{
			if (nestedReader == null)
				return base.MoveToContent();
			else
				return nestedReader.MoveToContent();
		}
		/// <summary>See <see cref="XmlTextReader.MoveToElement"/></summary>
		public override bool MoveToElement()
		{
			if (nestedReader == null)
				return base.MoveToElement();
			else
				return nestedReader.MoveToElement();
		}
		/// <summary>See <see cref="XmlTextReader.MoveToFirstAttribute"/></summary>
		public override bool MoveToFirstAttribute()
		{
			if (nestedReader == null)
				return base.MoveToFirstAttribute();
			else
				return nestedReader.MoveToFirstAttribute();
		}
		/// <summary>See <see cref="XmlTextReader.MoveToNextAttribute"/></summary>
		public override bool MoveToNextAttribute()
		{
			if (nestedReader == null)
				return base.MoveToNextAttribute();
			else
				return nestedReader.MoveToNextAttribute();
		}
		/// <summary>See <see cref="XmlTextReader.ReadAttributeValue"/></summary>
		public override bool ReadAttributeValue()
		{
			if (nestedReader == null)
				return base.ReadAttributeValue();
			else
				return nestedReader.ReadAttributeValue();
		}
		/// <summary>See <see cref="XmlReader.ReadElementString()"/></summary>
		public override string ReadElementString()
		{
			if (nestedReader == null)
				return base.ReadElementString();
			else
				return nestedReader.ReadElementString();
		}
		/// <summary>See <see cref="XmlReader.ReadElementString(string,string)"/></summary>
		public override string ReadElementString(string localname, string ns)
		{
			if (nestedReader == null)
				return base.ReadElementString(localname, ns);
			else
				return nestedReader.ReadElementString(localname, ns);
		}
		/// <summary>See <see cref="XmlReader.ReadElementString(string)"/></summary>
		public override string ReadElementString(string name)
		{
			if (nestedReader == null)
				return base.ReadElementString(name);
			else
				return nestedReader.ReadElementString(name);
		}
		/// <summary>See <see cref="XmlReader.ReadEndElement"/></summary>
		public override void ReadEndElement()
		{
			if (nestedReader == null)
				base.ReadEndElement();
			else
				nestedReader.ReadEndElement();
		}
		/// <summary>See <see cref="System.Xml.XmlReader.ReadInnerXml"/></summary>
		public override string ReadInnerXml()
		{
			if (NodeType == XmlNodeType.Attribute)
				return Value; 

			if (NodeType != XmlNodeType.Element || IsEmptyElement)
			{
				Read();
				return string.Empty;
			}

			StringBuilder sb = new StringBuilder(); 
			Read(); // into children
			while (NodeType != XmlNodeType.EndElement)
			{
				if (IsStartElement())
					sb.Append(ReadOuterXml()); 
				else if (NodeType == XmlNodeType.Text)
				{
					sb.Append(Value);
					Read();
				}
				else if (NodeType != XmlNodeType.EndElement)
					Read();
			}

			// read past EndElement
			Read(); 
			return sb.ToString(); 
		}
		private string EntitizeAttributeValue(string val)
		{
			if (val == null || val.Length == 0)
				return val;
			string ret = val;
			if (ret.IndexOfAny(new Char[] { '&', '<', '>', this.QuoteChar}) != -1)
			{
				ret = ret.Replace("&", "&amp;");
				ret = ret.Replace("<", "&lt;");
				ret = ret.Replace(">", "&gt;");
				if (this.QuoteChar == '\'')
					ret = ret.Replace("'", "&rsquo;");
				else
					ret = ret.Replace("\"", "&quot;");
			}
			return ret;
		}
		/// <summary>See <see cref="System.Xml.XmlReader.ReadOuterXml"/></summary>
		public override string ReadOuterXml()
		{
			if (NodeType == XmlNodeType.Attribute)
			{
				string val = EntitizeAttributeValue(this.Value);
				return string.Format("{0}={2}{1}{2}", Name, val, this.QuoteChar);
			}

			if (NodeType != XmlNodeType.Element)
			{
				Read();
				return string.Empty;
			}

			// get the attributes
			StringBuilder sb = new StringBuilder(); 
			int attributeCount = AttributeCount;
			for (int i = 0; i < attributeCount; i++)
			{
				MoveToAttribute(i);
				sb.Append(" "); 
				sb.Append(ReadOuterXml()); 
			}
			MoveToElement();
			
			string tag = Name;
			string innerXml = ReadInnerXml();
			if (innerXml.Length == 0)
				return string.Format("<{0} {1}/>", tag, sb.ToString()); 
			else
				return string.Format("<{0} {2}>{1}</{0}>", tag, innerXml, sb.ToString()); 
		}
		/// <summary>See <see cref="XmlReader.ReadStartElement"/></summary>
		public override void ReadStartElement()
		{
			if (nestedReader == null)
				base.ReadStartElement();
			else
				nestedReader.ReadStartElement();
		}
		/// <summary>See <see cref="XmlReader.ReadStartElement(string,string)"/></summary>
		public override void ReadStartElement(string localname, string ns)
		{
			if (nestedReader == null)
				base.ReadStartElement(localname, ns);
			else
				nestedReader.ReadStartElement(localname, ns);
		}
		/// <summary>See <see cref="XmlReader.ReadStartElement(string)"/></summary>
		public override void ReadStartElement(string name)
		{
			if (nestedReader == null)
				base.ReadStartElement();
			else
				nestedReader.ReadStartElement();
		}
		/// <summary>See <see cref="System.Xml.XmlReader.ReadString"/></summary>
		public override string ReadString()
		{
			if (nestedReader == null)
				return base.ReadString();
			else
				return nestedReader.ReadString();
		}
		/// <summary>See <see cref="XmlTextReader.ResolveEntity"/></summary>
		public override void ResolveEntity()
		{
			if (nestedReader == null)
				base.ResolveEntity();
			else
				nestedReader.ResolveEntity();
		}
		/// <summary>See <see cref="XmlReader.Skip"/></summary>
		public override void Skip()
		{
			if (nestedReader == null)
				base.Skip();
			else
				nestedReader.Skip();
		}
		/// <summary>See <see cref="Object.ToString"/></summary>
		public override string ToString()
		{
			if (nestedReader == null)
				return base.ToString();
			else
				return nestedReader.ToString();
		}

		/// <summary>Return the filename currently being processed</summary>
		public string GetFileName(string outerFilename)
		{
			return (nestedReader != null) ? nestedReader.GetFileName(nestedFilename) : outerFilename;
		}

		/// <summary>Return the filename</summary>
		/// <remarks>Returns string.Empty if the filename is not known (i.e. the 'outer' file)</remarks>
		public string FileName {get {return GetFileName(string.Empty);} }

		/// <summary>Return the line number within the file</summary>
		public int Line {get {return (nestedReader != null) ? nestedReader.LineNumber : base.LineNumber;} }

		/// <summary>Return the column within the file</summary>
		public int Column {get {return (nestedReader != null) ? nestedReader.LinePosition : base.LinePosition;} }
	}
	#endregion

	/// <summary>
	/// Common Xml routines. These routines throw <see cref="XmlConfigException"/>s when
	/// they fail to find required attributes. 
	/// </summary>
	#region XmlHelper
	public class XmlHelper
	{
		private XmlHelper() {}

		// get a path to a given element 
		private static string GetPath(XmlElement element)
		{
			XmlElement parent = element.ParentNode as XmlElement;
			string parentPath = (parent != null ? GetPath(parent) : string.Empty); 
			string name = element.HasAttribute("name") ? element.Attributes["name"].Value : element.Name;
			return string.Concat(parentPath, "/", name); 
		}

		// used by GetAttribute()
		private static XmlAttribute FindAttribute(XmlElement xmlNode, string attrName, bool mustFind)
		{
			XmlElement element = (XmlElement) xmlNode;
			foreach (XmlAttribute attr in element.Attributes)
				if (string.Compare(attr.Name, attrName, true, CultureInfo.InvariantCulture) == 0)
					return attr;
			if (mustFind)
				throw new XmlConfigException("Missing attribute " + attrName + " on element " + GetPath(element) + " or parent.", xmlNode);
			return null;
		}

		// used by GetAttribute()
		private static XmlAttribute FindDefaultableAttribute(XmlElement xmlNode, string attrName, bool mustFind)
		{
			XmlNode node = xmlNode;
			while (node != null && node is XmlElement)
			{
				XmlAttribute attr = FindAttribute((XmlElement) node, attrName, false); 
				if (attr != null) return attr;
				node = node.ParentNode;
			}
			if (mustFind)
				throw new XmlConfigException("Missing attribute " + attrName + " on element " + xmlNode.Name + " or parent.", xmlNode);
			return null;
		}

		/// <summary>
		/// Locate an attribute, ignoring case of the attribute name. 
		/// </summary>
		/// <param name="xmlNode">the XmlElement holding the attribute</param>
		/// <param name="attrName">the name (case-insensitive) of the attribute</param>
		/// <param name="mustFind">when true, throw an exception if not found</param>
		/// <param name="searchParent">if unfound, search ancestor elements</param>
		/// <returns></returns>
		private static XmlAttribute GetAttribute(XmlElement xmlNode, string attrName, bool mustFind, bool searchParent)
		{
			if (searchParent)
				return FindDefaultableAttribute(xmlNode, attrName, mustFind);
			else
				return FindAttribute(xmlNode, attrName, mustFind); 
		}

		/// <summary>Return a boolean attribute (allows 'true' or 'false')</summary>
		/// <param name="xmlNode">the XmlElement holding the attribute</param>
		/// <param name="attrName">the name (case-insensitive) of the attribute</param>
		/// <param name="mustFind">when true, throw an exception if not found</param>
		/// <param name="searchParent">if unfound, search ancestor elements</param>
		/// <param name="defaultValue">(mustFind is false) return this value if not found</param>
		/// <returns></returns>
		public static bool GetBoolAttribute(XmlElement xmlNode, string attrName, bool mustFind, bool searchParent, bool defaultValue)
		{
			XmlAttribute attr = GetAttribute(xmlNode, attrName, mustFind, searchParent);
			if (attr == null)
			{
				if (mustFind)
					throw new XmlConfigException("Missing required attribute " + attrName + " on element " + xmlNode.Name, xmlNode);
				return defaultValue;
			}
			string val = attr.Value.Trim().ToLower();
			if (val == "true") return true;
			if (val == "false") return false;
			throw new XmlConfigException("Expected 'true' or 'false'", attr.OwnerElement);
		}
		/// <summary>Locate and return attribute value. If unfound an exception is generated.</summary>
		/// <param name="xmlNode">the XmlElement holding the attribute</param>
		/// <param name="attrName">the name (case-insensitive) of the attribute</param>
		/// <returns></returns>
		public static bool GetBoolAttribute(XmlElement xmlNode, string attrName)
		{
			return GetBoolAttribute(xmlNode, attrName, true, false, false); 
		}

		/// <summary>
		/// Return an integer attribute (anything understood by int.Parse())
		/// </summary>
		/// <param name="xmlNode">the XmlElement holding the attribute</param>
		/// <param name="attrName">the name (case-insensitive) of the attribute</param>
		/// <param name="mustFind">when true, throw an exception if not found</param>
		/// <param name="searchParent">if unfound, search ancestor elements</param>
		/// <param name="defaultValue">(mustFind is false) return this value if not found</param>
		/// <returns></returns>
		public static int GetIntAttribute(XmlElement xmlNode, string attrName, bool mustFind, bool searchParent, int defaultValue)
		{
			string val = GetStringAttribute(xmlNode, attrName, mustFind, searchParent, defaultValue.ToString()); 
			try
			{
				if (val.Length > 2 && val[0] == '0' && (val[1] == 'x' || val[1] == 'X'))
					return Int32.Parse(val.Substring(2), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo);
				else
					return Int32.Parse(val.Trim(), NumberFormatInfo.InvariantInfo);
			}
			catch (FormatException)
			{
				throw new XmlConfigException("Invalid integer " + attrName + " on element " + xmlNode.Name, xmlNode);
			}
		}

		/// <summary>
		/// Locate and return attribute value. If unfound an exception is generated. 
		/// </summary>
		/// <param name="xmlNode">the XmlElement holding the attribute</param>
		/// <param name="attrName">the name (case-insensitive) of the attribute</param>
		/// <returns></returns>
		public static int GetIntAttribute(XmlElement xmlNode, string attrName)
		{
			return GetIntAttribute(xmlNode, attrName, true, false, 0); 
		}

		/// <summary>
		/// Return a string attribute 
		/// </summary>
		/// <param name="xmlNode">the XmlElement holding the attribute</param>
		/// <param name="attrName">the name (case-insensitive) of the attribute</param>
		/// <param name="mustFind">when true, throw an exception if not found</param>
		/// <param name="searchParent">if unfound, search ancestor elements</param>
		/// <param name="defaultValue">(mustFind is false) return this value if not found</param>
		/// <param name="choices">if non-null is the set of allowed values</param>
		/// <returns></returns>
		public static string GetStringAttribute(XmlElement xmlNode, string attrName, bool mustFind, bool searchParent, string defaultValue, string[] choices)
		{
			XmlAttribute attr = GetAttribute(xmlNode, attrName, mustFind, searchParent);
			if (attr == null)
			{
				if (mustFind)
					throw new XmlConfigException("Missing required attribute " + attrName + " on element " + xmlNode.Name, xmlNode);
				return defaultValue;
			}
			if (choices != null && Array.IndexOf(choices, attr.Value) < 0)
				throw new XmlConfigException("Invalid atribute value " + attr.Value + " on element " + xmlNode.Name, xmlNode);
			return attr.Value;
		}

		/// <summary>
		/// Locate and return attribute value. If unfound an exception is generated. 
		/// </summary>
		/// <param name="xmlNode">the XmlElement holding the attribute</param>
		/// <param name="attrName">the name (case-insensitive) of the attribute</param>
		/// <returns></returns>
		public static string GetStringAttribute(XmlElement xmlNode, string attrName)
		{
			return GetStringAttribute(xmlNode, attrName, true, false, null); 
		}

		/// <summary>
		/// Return a string attribute 
		/// </summary>
		/// <param name="xmlNode">the XmlElement holding the attribute</param>
		/// <param name="attrName">the name (case-insensitive) of the attribute</param>
		/// <param name="mustFind">when true, throw an exception if not found</param>
		/// <param name="searchParent">if unfound, search ancestor elements</param>
		/// <param name="defaultValue">(mustFind is false) return this value if not found</param>
		/// <returns></returns>
		public static string GetStringAttribute(XmlElement xmlNode, string attrName, bool mustFind, bool searchParent, string defaultValue)
		{
			return GetStringAttribute(xmlNode, attrName, mustFind, searchParent, defaultValue, null); 
		}

		/// <summary>
		/// Return a enum type attribute. (i.e. get a string attribute, and return <see cref="Enum.Parse"/> of the value).
		/// </summary>
		/// <param name="xmlNode">the XmlElement holding the attribute</param>
		/// <param name="enumType">the type of the enum to get from the attribute. (case insensitive <see cref="Enum.Parse"/>)</param>
		/// <param name="attrName">the name (case-insensitive) of the attribute</param>
		/// <param name="mustFind">when true, throw an exception if not found</param>
		/// <param name="searchParent">if unfound, search ancestor elements</param>
		/// <param name="defaultValue">(mustFind is false) return this value if not found</param>
		/// <returns></returns>
		public static object GetEnumAttribute(XmlElement xmlNode, Type enumType, string attrName, bool mustFind, bool searchParent, object defaultValue)
		{
			if (defaultValue == null)
				throw new ArgumentNullException("defaultValue", "A default value is mandatory when getting a enum attribute");
			if (defaultValue.GetType() != enumType)
				throw new ArgumentException("defaultValue", "the 'defaultValue' must be of the same type as the 'enumType'");
			string enumString = GetStringAttribute(xmlNode, attrName, mustFind, searchParent, null);
			if (enumString == null)
				return defaultValue;
			return Enum.Parse(enumType, enumString, true);
		}

		/// <summary>
		/// Return a Type from a type description. 
		/// </summary>
		/// <param name="xmlElement">The xml element containing the type attributes</param>
		/// <param name="typeAttr">if null, defaults to "type"</param>
		/// <param name="namespaceAttr">if null, defaults to "namespace"</param>
		/// <param name="assemblyAttr">if null, defaults to "assembly"</param>
		/// <param name="assemblyFileAttr">if null, defaults to "assemblyfile"</param>
		/// <param name="versionAttr">if null, defaults to "version"</param>
		/// <param name="keyAttr">if null, defaults to "key"</param>
		/// <param name="cultureAttr">if null, defaults to "culture"</param>
		/// <returns></returns>
		public static Type GetTypeDescription(XmlElement xmlElement,
			string typeAttr, string namespaceAttr, string assemblyAttr, string assemblyFileAttr,
			string versionAttr, string keyAttr, string cultureAttr)
		{
#if DEBUG
			//BooleanSwitch ts = BooleanSwitchCollector.CreateSwitch("TypeLoadingTrace", "Trace instantiation of components from xml type information");
			//Diagnostics.ColorConsoleTraceListener.AddPrefixColor("TYP", Diagnostics.ConsoleColors.FgYellow);
			BooleanSwitch ts = new BooleanSwitch("for", "testing"); 
#endif

			if (typeAttr == null) typeAttr = "type";
			if (namespaceAttr == null) namespaceAttr = "namespace";
			if (assemblyAttr  == null) assemblyAttr  = "assembly";
			if (assemblyFileAttr == null) assemblyFileAttr = "assemblyfile";

			Assembly ass;
			string typeName; 
			string qualifiedAssemblyName; 

			try
			{

				typeName = GetStringAttribute(xmlElement, typeAttr, true, true, null); 
				string nameSpace = GetStringAttribute(xmlElement, namespaceAttr, false, true, null);
				if (nameSpace != null) typeName = nameSpace + "." + typeName;

				// because either assembly or assemblyfile can be given we want to take the local attribute in preference
				// to an inherited attribute. 
				string assemblyName = GetStringAttribute(xmlElement, assemblyAttr, false, false, null);
				string assemblyFileName = GetStringAttribute(xmlElement, assemblyFileAttr, false, false, null);
				if (assemblyName == null && assemblyFileName == null)
				{
					assemblyName = GetStringAttribute(xmlElement, assemblyAttr, false, true, null);
					assemblyFileName = GetStringAttribute(xmlElement, assemblyFileAttr, false, true, null);
				}
				if ((assemblyName == null) == (assemblyFileName == null)) 
					throw new XmlConfigException(
						string.Format("Either '{0}' or '{1}' must be specified", assemblyAttr, assemblyFileAttr), xmlElement); 

				// try for file-base loading first
				if (assemblyFileName != null)
				{
					// should have a filename, which might have .dll or .exe on it. 
					string path = Path.GetDirectoryName(assemblyFileName);
					string filename = Path.GetFileNameWithoutExtension(assemblyFileName);
					string ext = Path.GetExtension(assemblyFileName);
					qualifiedAssemblyName = GetImageFilename(path, filename, ext); 
					if (qualifiedAssemblyName == null)
						throw new XmlConfigException("Unable to locate assembly file " + assemblyFileName, xmlElement);

					// we have the file, load the assembly 
					ass = Assembly.LoadFrom(qualifiedAssemblyName); 
				}
				else
				{
					if (versionAttr == null) versionAttr = "version";
					if (keyAttr == null) keyAttr = "key";
					if (cultureAttr == null) cultureAttr = "culture";

					string version = GetStringAttribute(xmlElement, versionAttr, false, true, null);
					string publicKey = GetStringAttribute(xmlElement, keyAttr, false, true, null);
					string culture = GetStringAttribute(xmlElement, cultureAttr, false, true, null);

					// format a partially qualified assembly name 
					AssemblyName assName = new AssemblyName();
					assName.Name = assemblyName;
					if (culture != null)
						assName.CultureInfo = new CultureInfo(culture); 
					if (publicKey != null)
						assName.SetPublicKeyToken(Text.StringUtil.FromBase16String(publicKey));
					if (version != null)
						assName.Version = new Version(version); 

					// Load the assembly using the normal binding algorithm (GAC is check before local files)
					qualifiedAssemblyName = assName.ToString();
					ass = Assembly.LoadWithPartialName(qualifiedAssemblyName);
				}
			}
			catch (Exception e)
			{
#if DEBUG		
				if (ts.Enabled)
				{
					Trace.WriteLine("TYP: Assembly Load Failure --------------------- ");
					Trace.WriteLine("TYP: Configuration : ");
					Trace.WriteLine("TYP: " + xmlElement.OuterXml);
					Trace.WriteLine("TYP: Exception : " + e.Message); 
					Trace.WriteLine("TYP: ------------------------------------------- "); 
				}
#endif
				throw new XmlConfigException("Failed to load assembly from xml attributes: ", xmlElement, e); 
			}
				
			try
			{
				// load up the type - throw on error
				Type t = ass.GetType(typeName, true, true);
#if DEBUG		
				if (ts.Enabled)
					Trace.WriteLine(string.Format("TYP: Type {0} loaded", t.FullName /*t.Assembly.FullName*/)); 
#endif
				return t;

			}
			catch (Exception e)
			{
#if DEBUG
				if (ts.Enabled)
				{
					Trace.WriteLine("TYP: Type Load Failure ------------------------- ");
					Trace.WriteLine("TYP: Configuration : ");
					Trace.WriteLine("TYP: " + xmlElement.OuterXml);
					Trace.WriteLine("TYP: Exception : " + e.Message); 
					Trace.WriteLine("TYP: ------------------------------------------- "); 
				}
#endif
				throw new XmlConfigException("Failed to instantiate type information from xml attributes: " + xmlElement.OuterXml, xmlElement, e); 
			}
		}

		/// <summary>
		/// Return a Type from a type description. Uses type, namespace and assembly attributes
		/// on the passed element or a parent to construct a type. 
		/// </summary>
		/// <param name="xmlElement"></param>
		/// <returns></returns>
		public static Type GetTypeDescription(XmlElement xmlElement)
		{
			return GetTypeDescription(xmlElement, null, null, null, null, null, null, null); 
		}

		/// <summary>
		/// Create an instance of a configured component using the type information in the passed element's attributes
		/// </summary>
		/// <param name="xmlElement"></param>
		/// <param name="requestedType"></param>
		/// <returns></returns>
		public static object GetComponent(XmlElement xmlElement, Type requestedType)
		{
			Type type = GetTypeDescription(xmlElement); 
			object instance = Activator.CreateInstance(type);
			if (requestedType.IsAssignableFrom(instance.GetType()) == false)
				throw new XmlConfigException(
					string.Format("The configured component is not type-compatible with {0}", requestedType.ToString()), xmlElement);
			return instance;
		}

		/// <summary>
		/// Get an image filename. If no extension is specified we look for dll or exe. 
		/// </summary>
		/// <param name="path"></param>
		/// <param name="filename"></param>
		/// <param name="ext"></param>
		/// <returns></returns>
		public static string GetImageFilename(string path, string filename, string ext)
		{
			// deal with the case where no extension was specified. 
			if (ext.Length == 0)
			{
				string result = GetImageFilename(path, filename, ".dll"); 
				if (result != null) return result;
				return GetImageFilename(path, filename, ".exe"); 
			}

			string fname = filename + ext; 

			// try an explicitly named path
			if (path.Length != 0)
			{
				string explicitFilename = Path.Combine(path, fname);
				return File.Exists(explicitFilename) ? explicitFilename : null;
			}

			// try the standard search paths
			string baseFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fname);
			if (File.Exists(baseFilename)) return baseFilename;

			// try the relative paths below that
			string relativeSearchPath = AppDomain.CurrentDomain.RelativeSearchPath;
			if (relativeSearchPath != null && relativeSearchPath.Length > 0)
			{
				string [] alternativePaths = AppDomain.CurrentDomain.RelativeSearchPath.Split(Path.PathSeparator);
				foreach(string alternativePath in alternativePaths)
				{
					string altFilename = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, Path.Combine(alternativePath, fname) ); 
					if (File.Exists(altFilename))
						return altFilename;
				}
			}

			// couldn't find it
			return null;
		}


		/// <summary>
		/// Get a named child element. 
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="name">name of child element to find</param>
		/// <param name="matchCase">true if case sensitive</param>
		/// <param name="mustFind">when true, throws an exception if not found</param>
		/// <returns></returns>
		public static XmlElement GetChildElement(XmlElement parent, string name, bool matchCase, bool mustFind)
		{
			if (matchCase == false) name = name.ToLower(); 
			foreach (XmlNode node in parent.ChildNodes)
				if (node.NodeType == XmlNodeType.Element)
				{
					string localName = node.LocalName;
					if (matchCase == false) 
						localName = localName.ToLower(); 
					if (localName == name)
						return (XmlElement) node;
				}
			if (mustFind)
				throw new XmlConfigException("Missing element '" + name + "' under " + parent.LocalName, parent);
			return null;
		}

		/// <summary>
		/// Get a named child element. 
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="name">name of child element to find (case sensitive and must find it)</param>
		/// <returns></returns>
		public static XmlElement GetChildElement(XmlElement parent, string name)
		{
			return GetChildElement(parent, name, true, true); 
		}

		/// <summary>
		/// Get the first child element.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="mustFind">when true, throws an exception if not found</param>
		/// <returns></returns>
		public static XmlElement GetFirstChildElement(XmlElement parent, bool mustFind)
		{
			foreach (XmlNode node in parent.ChildNodes)
				if (node.NodeType == XmlNodeType.Element)
					return (XmlElement) node;
			if (mustFind)
				throw new XmlConfigException("Missing element under " + parent.LocalName, parent);
			return null;
		}

		/// <summary>
		/// Given a filename, check that the filename exists with the given extension, or with
		/// the 'other' extension (.dll or .exe). If the filename has no path then both extensions
		/// are checked. 
		/// </summary>
		/// <param name="filename"></param>
		/// <returns>The filename to use or null if the file doesn't exist</returns>
		public static string GetImageFilename(string filename)
		{
			filename = filename.ToLower(); 
			string alt;
			if (filename.EndsWith(".dll"))
				alt = ".exe";
			else if (filename.EndsWith(".exe"))
				alt = ".dll";
			else
			{
				filename = filename + ".dll";
				alt = ".exe";
			}
			if (File.Exists(filename))
				return filename;
			filename = Path.ChangeExtension(filename, alt);
			if (File.Exists(filename))
				return filename;
			return null;
		}
	}
	#endregion

	/// <summary>
	/// <see cref="XmlSerializer"/> class that does not emit namespaces in the 
	/// produced XML root node when serializing
	/// </summary>
	#region XmlBareSerializer
	public class XmlBareSerializer
	{
		private readonly XmlSerializer xmlSerializer;
		private readonly XmlSerializerNamespaces namespaces;
		/// <summary>Initialise a new XmlBareSerializer instance</summary>
		public XmlBareSerializer(Type type)
		{
			this.xmlSerializer = new XmlSerializer(type);
			this.namespaces = new XmlSerializerNamespaces();
			this.namespaces.Add("", "");	// this avoids namespaces
		}
		/// <summary>Serialize the passed object to the <see cref="Stream"/>, outputs no namespaces.</summary>
		public virtual void Serialize( Stream stream, object o )
		{
			xmlSerializer.Serialize(stream, o, namespaces);
		}
		/// <summary>Serialize the passed object to the <see cref="TextWriter"/>, outputs no namespaces.</summary>
		public virtual void Serialize( TextWriter textWriter, object o )
		{
			xmlSerializer.Serialize( textWriter, o, namespaces);
		}
		/// <summary>Serialize the passed object to the <see cref="XmlWriter"/>, outputs no namespaces.</summary>
		public virtual void Serialize( XmlWriter xmlWriter, object o )
		{
			xmlSerializer.Serialize(xmlWriter, o, namespaces);
		}
		/// <summary>Deserialize an object from the <see cref="Stream"/>.</summary>
		public virtual object Deserialize(Stream stream)
		{
			return this.xmlSerializer.Deserialize(stream);
		}
		/// <summary>Deserialize an object from the <see cref="TextReader"/>.</summary>
		public virtual object Deserialize(TextReader textReader)
		{
			return this.xmlSerializer.Deserialize(textReader);
		}
		/// <summary>Deserialize an object from the <see cref="XmlReader"/>.</summary>
		public virtual object Deserialize(XmlReader xmlReader)
		{
			return this.xmlSerializer.Deserialize(xmlReader);
		}
	}
	#endregion

	/// <summary>
	/// A XmlTextWriter that prevents the &lt;?xml ... ?&gt; tag from being emited at 
	/// the beginning of the XML document it is going to produce.
	/// </summary>
	#region XmlNoPrefixWriter
	public class XmlNoPrefixWriter : XmlTextWriter
	{
		/// <summary>Initialise a new XmlNoPrefixWriter instance</summary>
		public XmlNoPrefixWriter(TextWriter writer) : base(writer){}
		/// <summary>See <see cref="XmlTextWriter.WriteStartDocument"/>. This override does not write anything.</summary>
		public override void WriteStartDocument(){}
	}
	#endregion

	/// <summary>Exception class used to identify a configuration exception and guve a clue where in the Xml document it is.</summary>
	#region XmlConfigException
	[Serializable]
	public sealed class XmlConfigException : Exception, ISerializable
	{
		/// <summary>Initialise a new XmlConfigException instance with default values.</summary>
		public XmlConfigException() : base() {}
		/// <summary>Initialise a new XmlConfigException instance.</summary>
		public XmlConfigException(string message) : this(message, null, null) {}
		/// <summary>Initialise a new XmlConfigException instance.</summary>
		public XmlConfigException(string message, XmlElement element) : this (message, element, null) {}
		/// <summary>Initialise a new XmlConfigException instance.</summary>
		public XmlConfigException(string message, XmlElement element, Exception innerException) : base (message, innerException) 
		{
			this.elementName = GetElementName(element); 
		}

		// the name of the element if provided
		private string elementName = string.Empty;

		/// <summary>Textual description of the exception event.</summary>
		public override string Message
		{
			get
			{
				string msg = base.Message;
				if (elementName.Length > 0) msg += Environment.NewLine + "Element: " + ElementName;
				return msg;
			}
		}

		/// <summary>Return the name of the element causing the problem</summary>
		public string ElementName {get {return elementName;} }

		// Get the (qualified) name of an element
		private string GetElementName(XmlElement element)
		{
			if (element == null) return "/";

			if (element.HasAttribute("name"))
				return string.Concat(GetElementName(element.ParentNode as XmlElement), "/", element.Attributes["name"].Value); 
			else
				return string.Concat(GetElementName(element.ParentNode as XmlElement), "/", element.Name); 
		}

		// serialization constructor
		private XmlConfigException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			elementName = info.GetString("elementName");
		}

		/// <summary>Deserialisation override.</summary>
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("elementName", elementName);
			base.GetObjectData(info, context); 
		}
	}
	#endregion
}
