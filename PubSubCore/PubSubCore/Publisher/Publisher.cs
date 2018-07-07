using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using PubSub.Filters;
using PubSub.Models;
using PubSub.Subscribers;

namespace PubSubCore.Services
{
	public class Publisher : IPublisher
	{
		public void Publish(NewsDetailsModel data, string topicName)
		{
			Filter.PushToSubscribers(data, topicName);
		}
	}
}
