using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PubSubCore.Extensions;
using PubSubCore.Services;

namespace PubSubCoreTests
{
	[TestFixture]
	public class DataTransformServiceTests
	{
		private IDataTransformService _service;

		[SetUp]
		public void SetUp()
		{
			_service = new DataTransformService();
		}

		[Test]
		public void TransformData_NullArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => _service.TransformData(null, null, null, null));
		}

		[Test]
		public void TransformData_EmptyTitle_ReturnsNull()
		{
			string title = string.Empty;
			string category = "test";
			string author = "Author 1";
			string description = "test description";
			Assert.AreEqual(_service.TransformData(title, category, author, description), null);
		}

		[Test]
		public void TransformData_EmptyCategory_ReturnsNull()
		{
			string title = "test title";
			string category = string.Empty;
			string author = "Author 1";
			string description = "test description";
			Assert.AreEqual(_service.TransformData(title, category, author, description), null);
		}

		[Test]
		public void TransformData_EmptyDescription_ReturnsNull()
		{
			string title = "test title";
			string category = "test";
			string author = "Author 1";
			string description = string.Empty;
			Assert.AreEqual(_service.TransformData(title, category, author, description), null);
		}

		[Test]
		public void TransformData_EmptyAuthor_DataWithoutAuthorReturned()
		{
			string title = "title 1";
			string category = "test";
			string author = string.Empty;
			string description = "test description";
			var data = _service.TransformData(title, category, author, description);
			Assert.AreEqual(data.Author, string.Empty);
		}

		[Test]
		public void TransformData_ValidArguments_DataWithValidDateReturned()
		{
			string title = "test title";
			string category = "test";
			string author = "Author 1";
			string description = "test description";
			var data = _service.TransformData(title, category, author, description);
			Assert.IsNotNull(data.PublishDate);
			Assert.AreEqual(data.PublishDate.Date,DateTime.Now.Date);
		}
	}
}
