using System;
using System.Collections.Generic;
using PubSub.Subscribers;
using PubSubCore.Models;
using PubSubCore.Subscribers;

namespace PubSubCore.Filters
{
	public sealed class Filter
	{
		private static readonly Lazy<Filter> LazyFilter =
			new Lazy<Filter>(() => new Filter());
		private Filter()
		{
		}
		public static Filter FilterInstance => LazyFilter.Value;

		public Dictionary<string, List<ISubscriber>> SubscribersList { get; } = new Dictionary<string, List<ISubscriber>>();

		public void PushToSubscribers(NewsDetailsModel data, string topicName)
		{
			if (data == null || string.IsNullOrWhiteSpace(topicName))
				return;
			List<ISubscriber> subscribers = GetSubscribers(topicName);
			if (subscribers == null) return;

			foreach (var subscriber in subscribers)
			{
				try
				{
					subscriber.DisplayData(data);
				}
				catch
				{
					Console.WriteLine("Error in subscriber");
				}
			}
		}

		private List<ISubscriber> GetSubscribers(string topicName)
		{

			return SubscribersList.ContainsKey(topicName) ? SubscribersList[topicName] : null;

		}

		public void AddSubscriber(string topicName, ISubscriber subscriberReference)
		{
			if (string.IsNullOrWhiteSpace(topicName) || subscriberReference == null)
				return;

			if (SubscribersList.ContainsKey(topicName))
			{
				if (!SubscribersList[topicName].Contains(subscriberReference))
				{
					SubscribersList[topicName].Add(subscriberReference);
				}
			}
			else
			{
				var newSubscribersList = new List<ISubscriber> { subscriberReference };
				SubscribersList.Add(topicName, newSubscribersList);
			}
		}

		public void RemoveSubscriber(string topicName, ISubscriber subscriberReference)
		{
			if (string.IsNullOrWhiteSpace(topicName) || subscriberReference == null)
				return;
			if (!SubscribersList.ContainsKey(topicName)) return;
			if (SubscribersList[topicName].Contains(subscriberReference))
			{
				SubscribersList[topicName].Remove(subscriberReference);
			}

		}

	}
}
