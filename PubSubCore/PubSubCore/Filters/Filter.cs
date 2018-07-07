using System;
using System.Collections.Generic;
using PubSub.Models;
using PubSub.Subscribers;

namespace PubSub.Filters
{
	public class Filter
	{
		static Dictionary<string, List<ISubscriber>> _subscribersList = new Dictionary<string, List<ISubscriber>>();

		public static void PushToSubscribers(NewsDetailsModel data, string topicName)
		{
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

		public static Dictionary<string, List<ISubscriber>> SubscribersList
		{
			get
			{
				lock (typeof(Filter))
				{
					return _subscribersList;
				}
			}

		}

		public static List<ISubscriber> GetSubscribers(String topicName)
		{
			lock (typeof(Filter))
			{
				if (SubscribersList.ContainsKey(topicName))
				{
					return SubscribersList[topicName];
				}
				else
					return null;
			}
		}

		public static void AddSubscriber(String topicName, ISubscriber subscriberCallbackReference)
		{
			lock (typeof(Filter))
			{
				if (SubscribersList.ContainsKey(topicName))
				{
					if (!SubscribersList[topicName].Contains(subscriberCallbackReference))
					{
						SubscribersList[topicName].Add(subscriberCallbackReference);
					}
				}
				else
				{
					List<ISubscriber> newSubscribersList = new List<ISubscriber>();
					newSubscribersList.Add(subscriberCallbackReference);
					SubscribersList.Add(topicName, newSubscribersList);
				}
			}

		}

		public static void RemoveSubscriber(String topicName, ISubscriber subscriberCallbackReference)
		{
			lock (typeof(Filter))
			{
				if (SubscribersList.ContainsKey(topicName))
				{
					if (SubscribersList[topicName].Contains(subscriberCallbackReference))
					{
						SubscribersList[topicName].Remove(subscriberCallbackReference);
					}
				}
			}
		}

	}
}
