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
			Assert.AreEqual(text.ToTitleCase(), "This is a string");
		}

		[Test]
		public void ToTitleCase_AllLower_ReturnsCorrectCasing()
		{
			string text = "this is a string";
			Assert.AreEqual(text.ToTitleCase(), "This Is a string");
		}
	}
}
