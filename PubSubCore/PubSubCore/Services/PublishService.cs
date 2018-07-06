using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using PubSub.Filters;
using PubSub.Models;
using PubSub.Subscribers;

namespace PubSubCore.Services
{
	public class PublishService : IPublishService
	{
		public void Publish(NewsDetailsModel data, string topicName)
		{
			List<ISubscriber> subscribers = Filter.GetSubscribers(topicName);
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
	}
}
