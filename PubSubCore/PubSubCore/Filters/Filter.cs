using System;
using System.Collections.Generic;
using PubSub.Subscribers;
using PubSubCore.Models;
using PubSubCore.Subscribers;

namespace PubSubCore.Filters
{
	public class Filter
	{
		private static Dictionary<string, List<ISubscriber>> _subscribersList = new Dictionary<string, List<ISubscriber>>();

		public static Dictionary<string, List<ISubscriber>> SubscribersList
		{
			get
			{
				lock (_subscribersList)
				{
					return _subscribersList;
				}
			}
		}

		public static void PushToSubscribers(NewsDetailsModel data, string topicName)
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

		private static List<ISubscriber> GetSubscribers(string topicName)
		{
			lock (_subscribersList)
			{
				return _subscribersList.ContainsKey(topicName) ? _subscribersList[topicName] : null;
			}
		}

		public static void AddSubscriber(string topicName, ISubscriber subscriberReference)
		{
			if (string.IsNullOrWhiteSpace(topicName) || subscriberReference == null)
				return;
			lock (_subscribersList)
			{
				if (_subscribersList.ContainsKey(topicName))
				{
					if (!_subscribersList[topicName].Contains(subscriberReference))
					{
						_subscribersList[topicName].Add(subscriberReference);
					}
				}
				else
				{
					var newSubscribersList = new List<ISubscriber> { subscriberReference };
					_subscribersList.Add(topicName, newSubscribersList);
				}
			}

		}

		public static void RemoveSubscriber(string topicName, ISubscriber subscriberReference)
		{
			if (string.IsNullOrWhiteSpace(topicName) || subscriberReference == null)
				return;
			lock (_subscribersList)
			{
				if (_subscribersList.ContainsKey(topicName))
				{
					if (_subscribersList[topicName].Contains(subscriberReference))
					{
						_subscribersList[topicName].Remove(subscriberReference);
					}
				}
			}
		}

	}
}
