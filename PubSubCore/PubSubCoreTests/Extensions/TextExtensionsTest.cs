using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PubSubCore.Extensions;

namespace PubSubCoreTests.Extensions
{

	[TestFixture]
	public class TextExtensionsTests
	{
		[Test]
		public void ToTitleCase_EmptyString_DoesNotThrow()
		{
			string text = string.Empty;
			Assert.DoesNotThrow(() => text.ToTitleCase());
		}

		[Test]
		public void ToTitleCase_AllCaps_ReturnsCorrectCasing()
		{
			string text = "THIS IS A STRING";
			Assert.AreEqual(text.ToTitleCase(), "This Is A String");
		}

		[Test]
		public void ToTitleCase_AllLower_ReturnsCorrectCasing()
		{
			string text = "this is a string";
			Assert.AreEqual(text.ToTitleCase(), "This Is A String");
		}

		[Test]
		public void TrimLength_EmptyStringArgument_DoesNotThrow()
		{
			string text = string.Empty;
			int noOfChars = 10;
			Assert.DoesNotThrow(() => text.TrimLength(noOfChars));
		}

		[Test]
		public void TrimLength_ZeroNumberofCharsArgument_ReturnsEmptyString()
		{
			string text = "this is a string";
			int noOfChars = 0;
			Assert.AreEqual(text.TrimLength(noOfChars), string.Empty);
		}

		[Test]
		public void TrimLength_NumberofCharsArgGreaterThanStringLenth_DoesNotThrow()
		{
			string text = "This is a string";
			int noOfChars = 50;
			Assert.DoesNotThrow(()=>text.TrimLength(noOfChars));
		}

		[Test]
		public void TrimLength_NumberofCharsArgGreaterThanStringLenth_ReturnsOriginalString()
		{
			string text = "This is a string";
			int noOfChars = 50;
			Assert.AreEqual(text.TrimLength(noOfChars), "This is a string");
		}

		[Test]
		public void TrimLength_ValidNumberofCharsArgument_ReturnsCorrectResult()
		{
			string text = "This is another string which has a length greater than ten";
			int noOfChars = 10;
			Assert.AreEqual(text.TrimLength(noOfChars), "This is an");
		}

		[Test]
		public void TrimLength_StringWithSpaces_ReturnsCorrectSpaceTrimmedResult()
		{
			string text = "This is an example of a string which has a length greater than ten";
			int noOfChars = 10;
			Assert.AreEqual(text.TrimLength(noOfChars), "This is an");
		}
	}
}
