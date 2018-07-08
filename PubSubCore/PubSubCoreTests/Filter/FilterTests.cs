using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PubSubCore.Models;
using PubSubCore.Subscribers;
using filter = PubSubCore.Filters;

namespace PubSubCoreTests.Filter
{
	[TestFixture]
	public class FilterTests
	{
		[Test]
		public void PushToSubscribers_NullArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.PushToSubscribers(null, null));
		}

		[Test]
		public void PushToSubscribers_EmptyString_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.PushToSubscribers(new NewsDetailsModel(), string.Empty));
		}

		[Test]
		public void PushToSubscribers_NullData_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.PushToSubscribers(null, "test"));
		}

		[Test]
		public void PushToSubscribers_ValidArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.PushToSubscribers(new NewsDetailsModel(), "test"));
		}

		[Test]
		public void AddSubscriber_NullArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.AddSubscriber(null, null));
		}

		[Test]
		public void AddSubscriber_EmptyString_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.AddSubscriber(null, null));
		}

		[Test]
		public void AddSubscriber_NullSubscriber_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.AddSubscriber("test", null));
		}

		[Test]
		public void AddSubscriber_ValidArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.AddSubscriber("test", new EconomicNewsSubscriber()));
		}

		[Test]
		public void AddSubscriber_ValidArguments_AddsSubscriber()
		{
			filter.Filter.AddSubscriber("test", new EconomicNewsSubscriber());
			var list = new Dictionary<string, ISubscriber>
			{
				{ "test", new EconomicNewsSubscriber() }
			};
			Assert.That(filter.Filter.SubscribersList.ContainsKey("test"));
			Assert.IsInstanceOf(typeof(EconomicNewsSubscriber), filter.Filter.SubscribersList["test"].FirstOrDefault());
		}

		[Test]
		public void RemoveSubscriber_NullArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.RemoveSubscriber(null, null));
		}

		[Test]
		public void RemoveSubscriber_EmptyString_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.RemoveSubscriber(null, null));
		}

		[Test]
		public void RemoveSubscriber_NullSubscriber_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.RemoveSubscriber("test", null));
		}

		[Test]
		public void RemoveSubscriber_ValidArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.RemoveSubscriber("test", new EconomicNewsSubscriber()));
		}

		[Test]
		public void RemoveSubscriber_ValidArguments_RemovesSubscriber()
		{
			var subscriber = new EconomicNewsSubscriber();
			filter.Filter.AddSubscriber("test", subscriber);
			filter.Filter.RemoveSubscriber("test", subscriber);
			Assert.That(!filter.Filter.SubscribersList["test"].Contains(subscriber));
		}

	}
}
