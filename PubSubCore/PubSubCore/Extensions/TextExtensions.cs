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
			TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
			return textInfo.ToTitleCase(text);
		}

		public static string TrimLength(this string text,int numberOfChars)
		{
			return text.Substring(0, numberOfChars).Trim();
		}
	}
}
