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
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.PushToSubscribers(null, null));
		}

		[Test]
		public void PushToSubscribers_EmptyString_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.PushToSubscribers(new NewsDetailsModel(), string.Empty));
		}

		[Test]
		public void PushToSubscribers_NullData_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.PushToSubscribers(null, "test"));
		}

		[Test]
		public void PushToSubscribers_ValidArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.PushToSubscribers(new NewsDetailsModel(), "test"));
		}

		[Test]
		public void AddSubscriber_NullArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.AddSubscriber(null, null));
		}

		[Test]
		public void AddSubscriber_EmptyString_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.AddSubscriber(null, null));
		}

		[Test]
		public void AddSubscriber_NullSubscriber_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.AddSubscriber("test", null));
		}

		[Test]
		public void AddSubscriber_ValidArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.AddSubscriber("test", new EconomicNewsSubscriber()));
		}

		[Test]
		public void AddSubscriber_ValidArguments_AddsSubscriber()
		{
			filter.Filter.FilterInstance.AddSubscriber("test", new EconomicNewsSubscriber());
			var list = new Dictionary<string, ISubscriber>
			{
				{ "test", new EconomicNewsSubscriber() }
			};
			Assert.That(filter.Filter.FilterInstance.SubscribersList.ContainsKey("test"));
			Assert.IsInstanceOf(typeof(EconomicNewsSubscriber), filter.Filter.FilterInstance.SubscribersList["test"].FirstOrDefault());
		}

		[Test]
		public void RemoveSubscriber_NullArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.RemoveSubscriber(null, null));
		}

		[Test]
		public void RemoveSubscriber_EmptyString_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.RemoveSubscriber(null, null));
		}

		[Test]
		public void RemoveSubscriber_NullSubscriber_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.RemoveSubscriber("test", null));
		}

		[Test]
		public void RemoveSubscriber_ValidArguments_DoesNotThrow()
		{
			Assert.DoesNotThrow(() => filter.Filter.FilterInstance.RemoveSubscriber("test", new EconomicNewsSubscriber()));
		}

		[Test]
		public void RemoveSubscriber_ValidArguments_RemovesSubscriber()
		{
			var subscriber = new EconomicNewsSubscriber();
			filter.Filter.FilterInstance.AddSubscriber("test", subscriber);
			filter.Filter.FilterInstance.RemoveSubscriber("test", subscriber);
			Assert.That(!filter.Filter.FilterInstance.SubscribersList["test"].Contains(subscriber));
		}

	}
}
