using System;
using System.Collections.Generic;
using System.Text;
using PubSub.Subscribers;
using PubSubCore.Subscribers;

namespace PubSubCore.Services
{
	interface ISubscribeService
	{
		void Subscribe(string topicName, List<ISubscriber> subscribers);
		void UnSubscribe(string topicName, List<ISubscriber> subscriber);
	}
}
