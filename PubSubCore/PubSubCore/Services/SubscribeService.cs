using System;
using System.Collections.Generic;
using System.Text;
using PubSub.Subscribers;
using PubSubCore.Filters;
using PubSubCore.Subscribers;

namespace PubSubCore.Services
{
	public class SubscribeService : ISubscribeService
	{
		public void Subscribe(string topicName, List<ISubscriber> subscribers)
		{
			foreach (var subscriber in subscribers)
			{
				Filter.AddSubscriber(topicName, subscriber);
			}

		}

		public void UnSubscribe(string topicName, List<ISubscriber> subscribers)
		{
			foreach (var subscriber in subscribers)
			{
				Filter.RemoveSubscriber(topicName, subscriber);
			}
		}
	}
}
