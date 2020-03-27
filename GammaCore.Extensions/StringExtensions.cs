using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GammaCore.Extensions
{
	public static class StringExtensions
	{
		#region CONSTANTS

		/// <summary>
		/// The RegEx to check if a string is an email address
		/// </summary>
		private const string FindEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

		/// <summary>
		/// The RegEx to find all br tags
		/// </summary>
		private const string FindHtmlBrTag = "/<br\\s*\\/?>/gi";

		/// <summary>
		/// The RegEx to find all HTML tags
		/// </summary>
		private const string FindAllHtmlTag = "<[^>]*>";

		/// <summary>
		/// The RegEx to find all non alphanumeric chars
		/// </summary>
		private const string FindNonAlphanumericChars = "[^a-zA-Z0-9]";

		/// <summary>
		/// The RegEx to find all alphanumeric chars
		/// </summary>
		private const string FindAlphanumericChars = "[a-zA-Z0-9]";

		/// <summary>
		/// The RegEx to find all multiple white spaces strings
		/// </summary>
		private const string FindMultipleWhiteSpaces = "  +";

		#endregion

		/// <summary>
		/// Remove the HTML tags from the text
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string RemoveHtml(this string text)
		{
			CheckText(text);

			text = Regex.Replace(text, FindHtmlBrTag, Environment.NewLine);

			text = Regex.Replace(text, FindAllHtmlTag, " ");

			text = Regex.Replace(text, "(&nbsp;)", " ");

			text = text.ClearMultipleWhiteSpaces();

			return text;
		}

		/// <summary>
		/// Replace the New line chars with the HTML br tag 
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string AddHtmlTagBr(this string text)
		{
			CheckText(text);

			return text.Replace(Environment.NewLine, "<br />");
		}

		/// <summary>
		/// Extract the preview chars from the text
		/// </summary>
		/// <param name="fullText"></param>
		/// <param name="previewChars">If 0 it returns the full text</param>
		/// <param name="addThreeDots">If true add thre dots at the end of the returned text</param>
		/// <returns></returns>
		public static string GetPreview(this string text, int previewChars = 0, bool addThreeDots = false)
		{
			CheckText(text);

			if (previewChars == 0) { previewChars = text.Length; }

			var regex = new Regex("(?s)\\b.{1," + previewChars + "}\\b", RegexOptions.Compiled);
			string result = regex.Match(text).Value;

			if (addThreeDots && result.Length < text.Length)
			{
				result += "...";
			}
			return result;
		}

		/// <summary>
		/// Remove all the New line chars and replace them with a white space
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ToSingleLine(this string text)
		{
			CheckText(text);

			return text.Replace(Environment.NewLine, " ");
		}

		/// <summary>
		/// Create a Camel case string with first char Upper case
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ToPascalCaseText(this string text)
		{
			CheckText(text);

			string camelCase = ToCamelCaseText(text);

			string firstChar = camelCase.Trim().ToCharArray()[0].ToString();

			string result = $"{firstChar.ToUpperInvariant()}{camelCase.Substring(1)}";

			return result;
		}

		/// <summary>
		/// Create a Camel case string with first char lower case
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ToCamelCaseText(this string text)
		{
			CheckText(text);

			List<string> strings = text.ClearMultipleWhiteSpaces().Trim()
										.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
										.ToList();

			StringBuilder result = new StringBuilder();
			result.Append(strings[0].ToLowerInvariant());

			foreach (string s in strings)
			{
				if (!(strings.IndexOf(s) == 0))
				{
					result.Append(s.Substring(0, 1).ToUpperInvariant());
					result.Append(s.Substring(1).ToLowerInvariant());
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Replace special chars with HTML code
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ReplaceSpecialCharsWithHtml(this string text)
		{
			CheckText(text);

			text = text.Replace("&", "&amp;");
			text = text.Replace("ò", "&ograve;");
			text = text.Replace("ò", "&oacute;");
			text = text.Replace("Ó", "&Oacute;");
			text = text.Replace("Ò", "&Ograve;");
			text = text.Replace("à", "&agrave;");
			text = text.Replace("á", "&aacute;");
			text = text.Replace("Á", "&Aacute;");
			text = text.Replace("À", "&Agrave;");
			text = text.Replace("â", "&acirc;");
			text = text.Replace("Å", "&Acirc;");
			text = text.Replace("ã", "&atilde;");
			text = text.Replace("Ã", "&Atilde;");
			text = text.Replace("è", "&egrave;");
			text = text.Replace("é", "&eacute;");
			text = text.Replace("É", "&Eacute;");
			text = text.Replace("È", "&Egrave;");
			text = text.Replace("ê", "&ecirc;");
			text = text.Replace("Ê", "&Ecirc;");
			text = text.Replace("ì", "&igrave;");
			text = text.Replace("ì", "&iacute;");
			text = text.Replace("Í", "&Iacute;");
			text = text.Replace("Ì", "&Igrave;");
			text = text.Replace("î", "&icirc;");
			text = text.Replace("Î", "&Icirc;");
			text = text.Replace("ù", "&ugrave;");
			text = text.Replace("ù", "&uacute;");
			text = text.Replace("Ú", "&Uacute;");
			text = text.Replace("Ù", "&Ugrave;");
			text = text.Replace("û", "&ucirc;");
			text = text.Replace("Û", "&Ucirc;");
			text = text.Replace("ç", "&ccedil;");
			text = text.Replace("Ç", "&Ccedil;");
			text = text.Replace("–", "&ndash;");
			text = text.Replace(">", "&gt;");
			text = text.Replace("<", "&lt;");
			text = text.Replace("€", "&euro;");
			text = text.Replace("’", "&rsquo;");
			text = text.Replace("'", "&#39;");
			text = text.Replace("°", "&deg;");

			return text;
		}

		/// <summary>
		/// Format the string for URL specifics compliance
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string FormatStringForUrl(this string text)
		{
			CheckText(text);

			string result = text;

			result = result.Trim().ToLowerInvariant();

			// replace accents
			result = result.Replace("°", "");
			result = result.Replace("à", "a");
			result = result.Replace("â", "a");
			result = result.Replace("è", "e");
			result = result.Replace("é", "e");
			result = result.Replace("ê", "e");
			result = result.Replace("ì", "i");
			result = result.Replace("ï", "i");
			result = result.Replace("ò", "o");
			result = result.Replace("ù", "u");

			// replace all non alphanumeric chars with a space
			result = Regex.Replace(result, FindNonAlphanumericChars, " ");

			// replace all multiple spaces with a single space
			result = result.ClearMultipleWhiteSpaces();

			//replace all spaces with a minus
			result = Regex.Replace(result, " ", "-");

			return result;
		}

		/// <summary>
		/// Replace multiple white spaces with a single one
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ClearMultipleWhiteSpaces(this string text)
		{
			CheckText(text);

			string result = text.Trim();

			result = Regex.Replace(result, FindMultipleWhiteSpaces, " ");

			return result.Trim();
		}

		/// <summary>
		/// Remove all white spaces from a text
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string RemoveWhiteSpaces(this string text)
		{
			CheckText(text);

			string result = text.ClearMultipleWhiteSpaces();

			return result.Replace(" ", "");
		}

		/// <summary>
		/// Check if the string is an email address
		/// </summary>
		/// <param name="valore"></param>
		/// <returns></returns>
		public static bool IsEmail(this string text)
		{
			CheckText(text);

			return Regex.IsMatch(text.ToLowerInvariant(), FindEmail, RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// Return a <see cref="NameValueCollection"/> from a string
		/// </summary>
		/// <param name="text">The <see cref="string"/> to parse</param>
		/// <param name="keyValuePairsSepChar">The char used to divide the name value pairs</param>
		/// <param name="keyValueSepChar">The char used to divide the name and the value</param>
		/// <returns></returns>
		public static NameValueCollection ToNameValueCollection(this string text, char keyValuePairsSepChar = '&', char keyValueSepChar = '=')
		{
			CheckText(text);

			NameValueCollection result = new NameValueCollection();

			string[] valoriQuery = text.Split(keyValuePairsSepChar);

			foreach (string item in valoriQuery)
			{
				string[] valore = item.Split(keyValueSepChar);

				result.Add(valore[0], valore[1]);
			}

			return result;
		}

		/// <summary>
		/// Return a dictionary from a key value pairs string
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="text"></param>
		/// <param name="pairsSepChar">The char used to separate each KeyValue pair contained in the string</param>
		/// <param name="keyValueSepChar">The char used to separate the Key and the Value contained in each KeyValue pair</param>
		/// <returns></returns>
		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this string text, char keyValuePairsSepChar, char keyValueSepChar)
			where TKey : struct
			where TValue : struct
		{
			CheckText(text);

			Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();

			string[] keyvalues = text.Split(new[] { keyValuePairsSepChar }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string item in keyvalues)
			{
				string[] keyValue = item.Split(keyValueSepChar);
				result.Add((TKey)Convert.ChangeType(keyValue[0], typeof(TKey)), (TValue)Convert.ChangeType(keyValue[1], typeof(TValue)));
			}

			return result;
		}

		#region HELPERS

		/// <summary>
		/// Check if the text is not null or empty.
		/// </summary>
		/// <param name="text"></param>
		/// <exception cref="ArgumentNullException"></exception>
		private static void CheckText(string text)
		{
			if (string.IsNullOrEmpty(text?.Trim())) { throw new ArgumentNullException(nameof(text)); }
		}

		#endregion
	}
}
