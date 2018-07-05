using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Publishers;
using PubSub.Subscribers;

namespace PubSub.Filters
{
	public class Filter
	{
		static Dictionary<string, List<ISubscriber>> _subscribersList = new Dictionary<string, List<ISubscriber>>();

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
