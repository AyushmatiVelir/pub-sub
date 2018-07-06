using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PubSubCore.Extensions
{
	public static class TextExtensions
	{
		public static string ToTitleCase(this string text)
		{
			if (string.IsNullOrWhiteSpace(text))
				return string.Empty;
			TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
			return textInfo.ToTitleCase(text.ToLower());
		}

		public static string TrimLength(this string text, int numberOfChars)
		{
			if (string.IsNullOrWhiteSpace(text))
				return string.Empty;
			return numberOfChars > text.Length ? text : text.Substring(0, numberOfChars).Trim();
		}
	}
}
